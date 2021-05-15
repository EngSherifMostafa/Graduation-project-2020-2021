create database DBTheSmartBatteryCharger

use [DBTheSmartBatteryCharger]
go

create table tblLogFile
(
	colIndex int identity(1,1) primary key,
	colDate date not null,
	colTime time not null,
	colBatteryStatus int not null,
	colChargerStatus char(3) not null constraint colChargerStatus_Chk check (colChargerStatus in ('OnLine','Offline'))
)

insert into tblLogFile values
((SELECT CAST(GETDATE() AS Date)) ,(SELECT CONVERT(TIME(0),GETDATE())), 70, UPPER('on'))

Select colIndex as [Index], 
format ([colDate], 'dd MMMM yyyy') as [Date], 
format ([colTime], 'hh:mm:ss') as [Time], 
[colBatteryStatus] as [Battery Status], 
[colChargerStatus] as [Charger Status] 
from [tblLogFile]

delete from [tblLogFile] where colIndex = 5

--get time 24 hours system
SELECT CONVERT(TIME(0),GETDATE())
--get date
SELECT CAST(GETDATE() AS Date)