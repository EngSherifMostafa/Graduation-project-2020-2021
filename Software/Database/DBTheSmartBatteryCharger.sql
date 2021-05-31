create database DBTheSmartBatteryCharger

use [DBTheSmartBatteryCharger]
go

create table tblLogFile
(
	colIndex int identity(1,1) primary key,
	colDate date not null,
	colTime time not null,
	colBatteryStatus int not null,
	colChargerStatus char(7) not null constraint colChargerStatus_Chk check (colChargerStatus in ('Online','Offline'))
)

insert into tblLogFile values
(
	(format (GETDATE(), 'dd MMMM yyyy')), 
	(format (GETDATE(), 'hh:mm:ss tt')), 
	70, 
	'Offline'
)

delete from [tblLogFile] where colIndex = 5

Select colIndex as [Index], 
format ([colDate], 'dd MMMM yyyy') as [Date], 
(SELECT format (cast ([colTime] as datetime), 'hh:mm:ss tt')) as [Time], 
[colBatteryStatus] as [Battery Status], 
trim([colChargerStatus]) as [Charger Status] 
from [tblLogFile]