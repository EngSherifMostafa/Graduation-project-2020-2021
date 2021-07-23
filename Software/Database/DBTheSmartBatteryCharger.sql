--create main database
CREATE DATABASE DBTheSmartBatteryCharger


--go to main database
USE [DBTheSmartBatteryCharger]
GO


--create main table
CREATE TABLE tblLogFile
(
	colIndex INT IDENTITY(1,1) PRIMARY KEY,
	colDate DATE NOT NULL,
	colTime TIME NOT NULL,
	colBatteryPercent INT NOT NULL,
	colChargerStatus CHAR(7) NOT NULL CONSTRAINT colChargerStatus_Chk CHECK (colChargerStatus IN ('Online','Offline')),
	colCpuPerformance INT NOT NULL,
	colRamPerformance INT NOT NULL,
	colHardDiskPerformance INT NOT NULL
)


--before insert, check to keep a constant number of records in the table
SELECT COUNT(*) FROM tblLogFile
DELETE FROM [tblLogFile] WHERE colIndex IN (SELECT TOP 100 colIndex FROM tblLogFile ORDER BY (PARSE(CONCAT(colDate, ' ', colTime) AS DATETIME)))


--insert statement
INSERT INTO tblLogFile VALUES
(
	(FORMAT (GETDATE(), 'dd MMMM yyyy')), 
	(FORMAT (GETDATE(), 'hh:mm:ss tt')), 
	79, 
	'Online',
	15,
	50,
	2
)


--delete statement
DELETE FROM [tblLogFile] WHERE colIndex = 282


--count number of records
SELECT COUNT(*) FROM tblLogFile


--select all from main table
SELECT
	colIndex AS [Index],
	FORMAT ([colDate], 'dd MMMM yyyy') AS [Date],
	(SELECT FORMAT (CAST ([colTime] AS DATETIME), 'hh:mm:ss tt')) AS [Time],
	[colBatteryPercent] AS [Battery Status],
	TRIM([colChargerStatus]) AS [Charger Status],
	[colCpuPerformance] AS [Cpu Utilization],
	[colRamPerformance] AS [Ram Utilization],
	[colHardDiskPerformance] AS [Hard Disk Utilization]
FROM [tblLogFile]


--create view for report
CREATE VIEW [vWReport]
	AS
	SELECT
		colIndex,
		PARSE(CONCAT(colDate,' ', colTime) AS DATETIME) AS [colCurrentDate],
		LAG(PARSE(CONCAT(colDate, ' ', colTime) AS DATETIME), 1, (PARSE(CONCAT(colDate, ' ', colTime) AS DATETIME))) OVER(ORDER BY colDate, colTime) AS [colLagDate],
		[colBatteryPercent],
		LAG(colBatteryPercent, 1, colBatteryPercent) OVER(ORDER BY colDate, colTime) AS [colLagBatteryPercent],
		[tblLogFile].[colCpuPerformance], [tblLogFile].[colRamPerformance], [tblLogFile].[colHardDiskPerformance], [tblLogFile].[colChargerStatus]
	FROM tblLogFile


--create report from view
SELECT
	[vWReport].[colCurrentDate], [vWReport].[colLagDate],
	(DATEDIFF(SECOND, [vWReport].[colLagDate], [vWReport].[colCurrentDate])) AS [colDateTimeDiff],
	[vWReport].[colBatteryPercent], [vWReport].[colLagBatteryPercent], ([vWReport].[colBatteryPercent] - [vWReport].[colLagBatteryPercent]) AS [colBatteryPercentDiff],
	ABS(ISNULL(
	(DATEDIFF(SECOND, [vWReport].[colLagDate], [vWReport].[colCurrentDate])) /
	NULLIF(([vWReport].[colBatteryPercent] - [vWReport].[colLagBatteryPercent]), 0), 0))
	AS [colTimeOfBatteryChangeOnePercentUpOrDown],
	[vWReport].[colCpuPerformance], [vWReport].[colRamPerformance], [vWReport].[colHardDiskPerformance], [vWReport].[colChargerStatus]
FROM vWReport
WHERE [vWReport].[colCurrentDate] BETWEEN '2021-06-11 00:51:10' AND '2021-06-26 14:05:15'
ORDER BY [vWReport].[colIndex]
-----------------------------------------------------------------------------------------

exec sp_help vWReport

SELECT *
FROM sys.dm_os_wait_stats dows where dows.wait_type like '%ram%'
ORDER BY dows.wait_type DESC;

SELECT dosi.physical_memory_kb, 
       dosi.virtual_memory_kb, 
       dosi.committed_kb, 
       dosi.committed_target_kb
FROM sys.dm_os_sys_info dosi;

SELECT
		(SELECT MIN(CONCAT(colDate, 'T', colTime, '+02:00')) WHERE [colChargerStatus] = [colChargerStatus]) AS [First Date],
		(SELECT MAX(CONCAT(colDate, 'T', colTime, '+02:00')) WHERE [colChargerStatus] = [colChargerStatus]) AS [Last Time],

		(DATEDIFF
		(
			SECOND,
			(SELECT MIN(CONCAT(colDate, 'T', colTime, '+02:00')) WHERE [colChargerStatus] = [colChargerStatus]),
			(SELECT MAX(CONCAT(colDate, 'T', colTime, '+02:00')) WHERE [colChargerStatus] = [colChargerStatus]))
		)
		AS [Difference of Date and Time],

		TRIM([colChargerStatus]) AS [Charger Status],

		(SELECT COUNT([colChargerStatus])) AS [Count of Charge / Discharge],

		AVG([colCpuPerformance]) AS [Average of Cpu Utilization],
		AVG([colRamPerformance]) AS [Average of Ram Utilization],
		AVG([colHardDiskPerformance]) AS [Average of Hard Disk Utilization]
FROM tblLogFile
GROUP By [colChargerStatus]
ORDER BY [colChargerStatus] DESC