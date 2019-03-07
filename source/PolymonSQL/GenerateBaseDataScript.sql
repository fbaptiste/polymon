--DB Version 1.10
set nocount on


--LookupEventStatus--
select '--LookupEventStatus--'
select 'delete from LookupEventStatus'
select 'insert into LookupEventStatus(StatusID, Status) values(' + cast(StatusID as varchar(1)) + ', ''' + Status + ''')'
from LookupEventStatus
select ' '



--SysSettings
select '--SysSettings--'
select 'delete from SysSettings'
select 'insert into SysSettings (Name, IsEnabled, ServiceServer, MainTimerInterval, UseInternalSMTP, SMTPFromName, SMTPFromAddress, ExtSMTPPort, DBVersion) ' + 
 'values(''PolyMon'', 1, ''127.0.0.1'', 60, 0, ''PolyMon'', ''<insert you From email address here>'', 25, 1.10)'
select ' '


--MonitorType
select '--MonitorType--'
select 'delete from MonitorType'
select 'insert into MonitorType (Name, MonitorAssembly, EditorAssembly, MonitorXMLTemplate) values(''' + Name + ''', ''' +  MonitorAssembly + ''', ''' + EditorAssembly + ''', ''' 
	+ replace(cast(MonitorXMLTemplate as varchar(8000)), '''', '''''') + ''')' + char(10) + char(13)
from MonitorType
where MonitorAssembly <> 'NRSPortalMonitor.dll'

--MonitorTriggerActionType
select '--MonitorActionTriggerType--'
select 'delete from MonitorActionTriggerType'
select 'insert into MonitorActionTriggerType (TriggerTypeID, TriggerType) values(' + cast(TriggerTypeID as varchar(3))+ ', ''' +  cast(TriggerType as nvarchar(50)) + ''')' + char(10) + char(13)
from MonitorActionTriggerType

--ScriptEngine
select '--ScriptEngine--'
select 'delete from ScriptEngine'
select 'insert into ScriptEngine (ScriptEngineID, ScriptEngine) values(' + cast(ScriptEngineID as varchar(3))+ ', ''' +  cast(ScriptEngine as nvarchar(50)) + ''')' + char(10) + char(13)
from ScriptEngine

--Executive
select '--Executive--'
select 'delete from Executive'
select 'set IDENTITY_INSERT Executive ON'
select 'insert into Executive (ExecutiveID, Server) values(1, ''127.0.0.1'')'
select 'set IDENTITY_INSERT Executive OFF'

--Retention Scheme Job (PolyMon job)
select '--Retention Scheme Schedule--'
select 'delete from Monitor'

select 'declare @MonitorTypeID int'

select 'select @MonitorTypeID =MonitorTypeID from MonitorType where Name = ''SQL Monitor'''

select 'insert into Monitor (Name, MonitorTypeID, MonitorXML, OfflineTime1Start, OfflineTime1End, OfflineTime2Start, OfflineTime2End,
	MessageSubjectTemplate, MessageBodyTemplate, TriggerMod, IsEnabled, ExecutiveID) 
	values('  
	+ '''' + replace([Name], '''', '''''') + ''', ' 
	+ '@MonitorTypeID, '
	+ '''' + replace(cast(MonitorXML as varchar(8000)), '''', '''''') + ''', ' 
	+ '''' + OfflineTime1Start + ''', '
	+ '''' + OfflineTime1End + ''', '
	+ '''' + OfflineTime2Start + ''', '
	+ '''' + OfflineTime2End + ''', '
	+ '''' + replace(MessageSubjectTemplate, '''', '''''') + ''', '
	+ '''' + replace(MessageBodyTemplate, '''', '''''') + ''', '
	+ cast(TriggerMod as varchar(10)) + ', '
	+ cast(IsEnabled as varchar(10)) + ', '
	+ cast(ExecutiveID as varchar(10)) 
	+ ')'
from Monitor where MonitorID=165
