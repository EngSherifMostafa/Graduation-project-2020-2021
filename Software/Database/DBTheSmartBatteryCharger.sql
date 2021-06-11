create database DBTheSmartBatteryCharger

use [DBTheSmartBatteryCharger]
go

create table tblLogFile
(
	colIndex int identity(1,1) primary key,
	colDate date not null,
	colTime time not null,
	colBatteryPercent int not null,
	colChargerStatus char(7) not null constraint colChargerStatus_Chk check (colChargerStatus in ('Online','Offline'))
	colCpuPerformance int not null,
	colRamPerformance int not null,
	colHardDiskPerformance int not null
)

insert into tblLogFile values
(
	(format (GETDATE(), 'dd MMMM yyyy')), 
	(format (GETDATE(), 'hh:mm:ss tt')), 
	70, 
	'Offline',
	50,
	60,
	2
)

delete from [tblLogFile] where colIndex = 5

Select colIndex as [Index], 
format ([colDate], 'dd MMMM yyyy') as [Date], 
(SELECT format (cast ([colTime] as datetime), 'hh:mm:ss tt')) as [Time], 
[colBatteryPercent] as [Battery Status], 



trim([colChargerStatus]) as [Charger Status] 


from [tblLogFile]