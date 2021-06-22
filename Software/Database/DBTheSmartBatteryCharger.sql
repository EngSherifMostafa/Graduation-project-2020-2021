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

--insert statement
INSERT INTO tblLogFile VALUES
(
	(FORMAT (GETDATE(), 'dd MMMM yyyy')), 
	(FORMAT (GETDATE(), 'hh:mm:ss tt')), 
	70, 
	'Offline',
	50,
	60,
	2
)

--delete statement
DELETE FROM [tblLogFile] WHERE colIndex = 154

--select * from main table
SELECT colIndex AS [Index],
FORMAT ([colDate], 'dd MMMM yyyy') AS [Date],
(SELECT FORMAT (CAST ([colTime] AS DATETIME), 'hh:mm:ss tt')) AS [Time],
[colBatteryPercent] AS [Battery Status],
TRIM([colChargerStatus]) AS [Charger Status],
[colCpuPerformance] AS [Cpu Utilization],
[colRamPerformance] AS [Ram Utilization],
[colHardDiskPerformance] AS [Hard Disk Utilization]
FROM [tblLogFile]


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

--create view for report
CREATE VIEW [vWReport]
	AS
	SELECT
		ColChargerStatus,

		PARSE(CONCAT(colDate,' ', colTime) AS DATETIME) AS [Current Date],
		LAG(PARSE(CONCAT(colDate, ' ', colTime) AS DATETIME), 1, NULL) OVER(ORDER BY colDate, colTime) AS [Lag Date],
	
		colBatteryPercent,
		LAG(colBatteryPercent, 1, NULL) OVER(ORDER BY colBatteryPercent) AS [colLeadBatteryPercent]
	FROM tblLogFile

----------------------------------------------------------------------------------------------------------------------------------

SELECT
	*,
	(colBatteryPercent - colLeadBatteryPercent) AS [colBatteryPercentDiff],
	
	(
		DATEDIFF
			(
				SECOND,
				[Current Date],
				[Lag Date]
			)
	)	AS [colDateTimeDiff]

FROM vWReport
ORDER BY [Lag Date]


exec sp_help vWReport