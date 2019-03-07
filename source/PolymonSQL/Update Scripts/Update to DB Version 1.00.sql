SET NOCOUNT ON
 
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MonitorAlert
	DROP CONSTRAINT FK_MonitorAlert_MonitorEvent
GO
ALTER TABLE dbo.MonitorEventCounter
	DROP CONSTRAINT FK_MonitorEventCounter_MonitorEvent
GO
ALTER TABLE dbo.MonitorEvent
	DROP CONSTRAINT PK_MonitorEvent
GO
ALTER TABLE dbo.MonitorEvent ADD CONSTRAINT
	PK_MonitorEvent PRIMARY KEY CLUSTERED 
	(
	EventID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]

GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MonitorEventCounter WITH NOCHECK ADD CONSTRAINT
	FK_MonitorEventCounter_MonitorEvent FOREIGN KEY
	(
	EventID
	) REFERENCES dbo.MonitorEvent
	(
	EventID
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MonitorAlert WITH NOCHECK ADD CONSTRAINT
	FK_MonitorAlert_MonitorEvent FOREIGN KEY
	(
	EventID
	) REFERENCES dbo.MonitorEvent
	(
	EventID
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT

GO
create index idx_MonitorAlert_MonitorID_EventDT_EventID on dbo.MonitorAlert
( MonitorID, EventDT, EventID) 
GO

--Add two columns
alter table MonitorCurrentStatus
add LifetimeUptime bigint NOT NULL
default 0 with values
GO
alter table MonitorCurrentStatus
add LifetimeDowntime bigint NOT NULL
default 0 with values
GO

--Calculate Lifetime Uptime/Downtime numbers
Declare @tmp as table(MonitorID int, UpTime bigint, DownTime bigint)

insert into @tmp (MonitorID, UpTime, DownTime)
select MonitorID, 
	coalesce(sum(case when UpDownTimesecs >0 then UpDownTimeSecs else 0 end),0) ,
	abs(coalesce(sum(case when UpDownTimesecs <0 then UpDownTimeSecs else 0 end),0))
from MonitorEvent
group by MonitorID

update MonitorCurrentStatus
set LifetimeUpTime=Uptime, LifetimeDowntime=Downtime,
	LifetimePercUptime = 
		case when (LifetimeUptime+LifetimeDowntime=0) then 0
		else  cast(100 * cast(LifetimeUptime as dec(20,3)) / (cast(LifetimeUptime as dec(20,3)) + cast(LifetimeDowntime as dec(20,3))) as dec(6,3)) end
from @tmp TBL
where MonitorCurrentStatus.MonitorID=TBL.MonitorID


CREATE NONCLUSTERED INDEX [IX_MonitorEvent_3] ON [dbo].[MonitorEvent] 
(
	[EventDT] ASC,
	[StatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF) ON [PRIMARY]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_LifetimePercUptime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_LifetimePercUptime]
GO

update [dbo].[syssettings]
set DBVersion = 1.0
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_MonitorMetadata]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_MonitorMetadata]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_ins_MonitorEvent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_ins_MonitorEvent]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_ins_MonitorEventCounter]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_ins_MonitorEventCounter]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_MonitorList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_MonitorList]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_PendingEmailAlerts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_PendingEmailAlerts]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_hyb_MarkEmailSent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_hyb_MarkEmailSent]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_MonitorOperators]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_MonitorOperators]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_Operator]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_Operator]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_hyb_SaveOperator]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_hyb_SaveOperator]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_del_DeleteOperator]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_del_DeleteOperator]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_ins_AssignMonitorOperator]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_ins_AssignMonitorOperator]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_del_RemoveMonitorOperator]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_del_RemoveMonitorOperator]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_MonitorMetadataCurrentDT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_MonitorMetadataCurrentDT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_hyb_SaveMonitorMetadata]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_hyb_SaveMonitorMetadata]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_del_DeleteMonitor]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_del_DeleteMonitor]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_Operators]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_Operators]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_MonitorTypeMetadata]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_MonitorTypeMetadata]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_MonitorTypes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_MonitorTypes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_hyb_SaveMonitorType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_hyb_SaveMonitorType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_del_DeleteMonitorType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_del_DeleteMonitorType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agg_RebuildAggStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[agg_RebuildAggStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_MonitorType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_MonitorType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agg_RebuildAggCounter]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[agg_RebuildAggCounter]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_ins_EvaluateEventAlertStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_ins_EvaluateEventAlertStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agg_Monitor_ApplyRetentionScheme]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[agg_Monitor_ApplyRetentionScheme]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_DashboardGroups]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_DashboardGroups]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[executive_MonitorMetadataLatestUpdateDT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[executive_MonitorMetadataLatestUpdateDT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_hyb_SetExecutiveService]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_hyb_SetExecutiveService]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_DashboardGroupPanels]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_DashboardGroupPanels]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_del_MonitorData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_del_MonitorData]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_del_DeleteDashboardGroup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_del_DeleteDashboardGroup]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_hyb_SaveDashboardGroup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_hyb_SaveDashboardGroup]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_hyb_SaveDashboardPanel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_hyb_SaveDashboardPanel]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_del_DeleteDashboardPanel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_del_DeleteDashboardPanel]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_DashboardGroup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_DashboardGroup]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_ins_DashBoardPanel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_ins_DashBoardPanel]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_DashboardPanel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_DashboardPanel]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_LastMonitorStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_LastMonitorStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_NonNominalMonitors]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_NonNominalMonitors]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_HistMonitorEvents_NDays]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_HistMonitorEvents_NDays]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_HistMonitorEvents_FreqDist]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_HistMonitorEvents_FreqDist]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_HistMonitorCounter_NDays]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_HistMonitorCounter_NDays]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_HistMonitorCounters_NDays]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_HistMonitorCounters_NDays]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_HistMonitorCounters_Averages]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_HistMonitorCounters_Averages]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_DashboardGroupAvailableMonitors]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_DashboardGroupAvailableMonitors]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_StatusData_CustomFreq]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_StatusData_CustomFreq]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_EventHistory]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_EventHistory]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_SysSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_SysSettings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_GetStatusDateRanges]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_GetStatusDateRanges]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_hyb_SaveSysSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_hyb_SaveSysSettings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_CounterData_Daily]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_CounterData_Daily]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_MonitorCurrentStatusID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_MonitorCurrentStatusID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_StatusData_Daily]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_StatusData_Daily]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_CounterData_Monthly]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_CounterData_Monthly]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_StatusData_Monthly]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_StatusData_Monthly]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_CounterData_Weekly]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_CounterData_Weekly]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_StatusData_Weekly]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_StatusData_Weekly]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_CurrentStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_CurrentStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_StatusSummary_Raw]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_StatusSummary_Raw]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_hyb_SaveDefaultRetentionSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_hyb_SaveDefaultRetentionSettings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_CounterData_CustomAverage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_CounterData_CustomAverage]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_PercUptimeAnalysis]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_PercUptimeAnalysis]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_CounterData_Raw]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_CounterData_Raw]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_StatusData_Raw]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_StatusData_Raw]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_sel_AllCurrentStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_sel_AllCurrentStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_IsOfflineTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_IsOfflineTime]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[polymon_ins_GenerateAlert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[polymon_ins_GenerateAlert]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agg_UpdateCounterTables]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[agg_UpdateCounterTables]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agg_ApplyRetentionScheme]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[agg_ApplyRetentionScheme]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_PercUptime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_PercUptime]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_MonitorCurrentStatus]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_MonitorCurrentStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agg_UpdateStatusTables]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[agg_UpdateStatusTables]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_PrevEventDT]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_PrevEventDT]
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[polymon_ins_MonitorEventCounter] 
@EventID int,
@MonitorID int,
@CounterName varchar(255),
@CounterValue decimal(30,10)
AS

/*
===================================================================
Procedure Name: polymon_ins_MonitorEventCounter
Author: Fred Baptiste
Create Date: 10/21/2005
Purpose:  inserts a monitor counter record
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

Declare @EventDT datetime
select @EventDT = EventDT from MonitorEvent where EventID=@EventID

insert into MonitorEventCounter (EventID, CounterName, CounterValue, MonitorID, EventDT)
values (@EventID, @CounterName, @CounterValue, @MonitorID, @EventDT)
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[polymon_del_DeleteMonitor]
@MonitorID int
AS

/*
===================================================================
Procedure Name: polymon_del_DeleteMonitor
Author: Fred Baptiste
Create Date: 10/27/2005	
Purpose:  Deletes a monitor and all relatred data
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

Delete from Monitor where MonitorID=@MonitorID
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/16/2007
-- Description:	Saves Default Retention Settings
-- =============================================
CREATE PROCEDURE [dbo].[polymon_hyb_SaveDefaultRetentionSettings] 
	@RetentionMaxMonthsRaw smallint,
	@RetentionMaxMonthsDaily smallint,
	@RetentionMaxMonthsWeekly smallint,
	@RetentionMaxMonthsMonthly smallint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if exists(select * from SysSettings)
	begin
		update SysSettings
		set RetentionMaxMonthsRaw = @RetentionMaxMonthsRaw,
			RetentionMaxMonthsDaily = @RetentionMaxMonthsDaily,
			RetentionMaxMonthsWeekly = @RetentionMaxMonthsWeekly,
			RetentionMaxMonthsMonthly = @RetentionMaxMonthsMonthly
	end
	else
	begin
		Declare @ErrMsg varchar(400)
		set @ErrMsg = 'You cannot save Default Retention Settings before first saving primary system settings.'
		raiserror(@ErrMsg, 16, 1)
		return -1
	end
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/7/2006
-- Description:	Frequency distribution of Event Status for specified time periods and buckets for specified Monitor
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_HistMonitorEvents_FreqDist] 
	@MonitorID int, 
	@LastNDays int,
	@TPHours int
AS
BEGIN
	SET NOCOUNT ON;

	if object_id('tempdb..#TimePeriods') is not null
	drop table #TimePeriods

	create table #TimePeriods (TPNum int, TPStartDT datetime, TPEndDT datetime)

	Declare @StartDT datetime
	Declare @EndDT datetime

	set @EndDT = cast(convert(varchar(10), GetDate(), 120) + ' 23:59:59' as datetime)
	set @StartDT = cast(convert(varchar(10), dateadd(dd, -@LastNDays, @EndDT), 120) + ' 00:0:00' as datetime)

	Declare @NumPeriods int
	set @NumPeriods = datediff(hh,@StartDT, @EndDT)/@TPHours

	Declare @TPNum int
	set @TPNum = 0
	while @TPNum<=@NumPeriods
	begin
		set @TPNum = @TPNum+1
		insert into #TimePeriods (TPNum, TPStartDT, TPEndDT)
		values(@TPNum, 
			dateadd(hh, (@TPNum-1)*@TPHours, @StartDT),
			dateadd(hh, (@TPNum)*@TPHours, @StartDT))
		
	end

	select TP.TPNum, 
			convert(varchar(19), TP.TPStartDT, 120) as [Start DT], 
			convert(varchar(19), TP.TPEndDT, 120) as [End DT],
			TP.TPStartDT as [StartDT_Raw],
			TP.TPEndDT as [EndDT_Raw],
			coalesce(sum(case when MonitorEvent.StatusID=1 then 1 else 0 end),0) as NumOK,
			coalesce(sum(case when MonitorEvent.StatusID=2 then 1 else 0 end),0) as NumWarning,
			coalesce(sum(case when MonitorEvent.StatusID=3 then 1 else 0 end),0) as NumFail,
			dbo.fn_PercUptime(@MonitorID, TP.TPStartDT, TP.TPEndDT) as PercUptime
	from #TimePeriods TP
		left outer join MonitorEvent with(NOLOCK) on MonitorEvent.MonitorID=@MonitorID
			and MonitorEvent.EventDT >= TP.TPStartDT and MonitorEvent.EventDT < TP.TPEndDT
	group by TP.TPNum, TP.TPStartDT, TP.TPEndDT
	having coalesce(sum(case when MonitorEvent.StatusID=1 then 1 else 0 end),0) 
		+ coalesce(sum(case when MonitorEvent.StatusID=2 then 1 else 0 end),0) 
		+ coalesce(sum(case when MonitorEvent.StatusID=3 then 1 else 0 end),0) >0
	order by TP.TPNum desc

	if object_id('tempdb..#TimePeriods') is not null
	drop table #TimePeriods
END












GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/9/2006
-- Description:	Returns Last N Days of all defined counters for specified Monitor
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_HistMonitorCounter_NDays] 
	@MonitorID int, 
	@CounterName varchar(800),
	@LastNDays int
AS
BEGIN
	SET NOCOUNT ON;


	select EventID, EventDT, CounterValue
	from MonitorCounterEvent with(NOLOCK)
	where MonitorID=@MonitorID
		and CounterName=@CounterName
		and datediff(dd, EventDT, GetDate())<=@LastNDays
	order by EventID desc
END



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/7/2006
-- Description:	Frequency distribution of Event Status for specified time periods and buckets for specified Monitor
-- =============================================
CREATE PROCEDURE [dbo].[rpt_StatusData_CustomFreq] 
	@MonitorID int, 
	@StartDT datetime,
	@EndDT datetime,
	@TPMinutes int
AS
BEGIN
	SET NOCOUNT ON;

	if object_id('tempdb..#TimePeriods') is not null
	drop table #TimePeriods

	create table #TimePeriods (TPNum int, TPStartDT datetime, TPEndDT datetime)

	Declare @NumPeriods int
	set @NumPeriods = datediff(mi,@StartDT, @EndDT)/@TPMinutes

	if @NumPeriods<=0
		return 1


	Declare @TPNum int
	set @TPNum = 0
	while @TPNum<=@NumPeriods
	begin
		set @TPNum = @TPNum+1
		insert into #TimePeriods (TPNum, TPStartDT, TPEndDT)
		values(@TPNum, 
			dateadd(mi, (@TPNum-1)*@TPMinutes, @StartDT),
			dateadd(mi, (@TPNum)*@TPMinutes, @StartDT))
		
	end

	select TP.TPNum, 
			TP.TPStartDT as [StartDT_Raw],
			TP.TPEndDT as [EndDT_Raw],
			convert(varchar(19), TP.TPStartDT, 120) as [StartDT_Display], 
			convert(varchar(19), TP.TPEndDT, 120) as [EndDT_Display],
			coalesce(sum(case when MonitorEvent.StatusID=1 then 1 else 0 end),0) as OKCount,
			coalesce(sum(case when MonitorEvent.StatusID=2 then 1 else 0 end),0) as WarningCount,
			coalesce(sum(case when MonitorEvent.StatusID=3 then 1 else 0 end),0) as FailureCount,
			dbo.fn_PercUptime(@MonitorID, TP.TPStartDT, TP.TPEndDT) as PercUpTime
	from #TimePeriods TP
		left outer join MonitorEvent with(NOLOCK) on MonitorEvent.MonitorID=@MonitorID
			and MonitorEvent.EventDT >= TP.TPStartDT and MonitorEvent.EventDT < TP.TPEndDT
	group by TP.TPNum, TP.TPStartDT, TP.TPEndDT
	having coalesce(sum(case when MonitorEvent.StatusID=1 then 1 else 0 end),0) 
		+ coalesce(sum(case when MonitorEvent.StatusID=2 then 1 else 0 end),0) 
		+ coalesce(sum(case when MonitorEvent.StatusID=3 then 1 else 0 end),0) >0
	order by TP.TPNum desc

	if object_id('tempdb..#TimePeriods') is not null
	drop table #TimePeriods
END
















GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[polymon_sel_SysSettings]

AS

/*
===================================================================
Procedure Name: polymon_sel_SysSettings
Author: Fred Baptiste	
Create Date: 11/1/2005
Purpose:  
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

select * from SysSettings
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[polymon_hyb_SaveSysSettings]
@Name varchar(50),
@IsEnabled bit,
@ServiceServer varchar(255),
@MainTimerInterval int, 
@UseInternalSMTP bit, 
@SMTPFromName varchar(50),
@SMTPFromAddress varchar(255),
@ExtSMTPServer varchar(255) = NULL,
@ExtSMTPPort int = NULL,
@ExtSMTPUserID varchar(50) = NULL,
@ExtSMTPPwd varchar(50) = NULL,
@ExtSMTPUseSSL bit = NULL
AS

set nocount on

if exists(select * from SysSettings)
begin
	update SysSettings
	set Name=@Name,
		IsEnabled=@IsEnabled,
		ServiceServer=@ServiceServer,
		MainTimerInterval=@MainTimerInterval,
		UseInternalSMTP=@UseInternalSMTP,
		SMTPFromName=@SMTPFromName,
		SMTPFromAddress=@SMTPFromAddress,
		ExtSMTPServer=@ExtSMTPServer,
		ExtSMTPPort=@ExtSMTPPort,
		ExtSMTPUserID=@ExtSMTPUserID,
		ExtSMTPPwd=@ExtSMTPPwd,
		ExtSMTPUseSSL=@ExtSMTPUseSSL
end
else
begin
	insert into SysSettings (IsEnabled, ServiceServer, MainTimerInterval, UseInternalSMTP, SMTPFromName, SMTPFromAddress,
				ExtSMTPServer, ExtSMTPPort, ExtSMTPUserID, ExtSMTPPwd, ExtSMTPUseSSL)
	values(@IsEnabled, @ServiceServer, @MainTimerInterval, @UseInternalSMTP, @SMTPFromName, @SMTPFromAddress,
				@ExtSMTPServer, @ExtSMTPPort, @ExtSMTPUserID, @ExtSMTPPwd, @ExtSMTPUseSSL)
end




GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Fred Baptiste
-- Create date: 10/6/2006
-- Description:	Returns Uptime% Lifetime and Specific Time Period
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_PercUptimeAnalysis] 
	-- Add the parameters for the stored procedure here
	@StartDT datetime, 
	@EndDT datetime,
	@IncludeLifetime bit = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

if object_id('Tempdb..#MonitorUptime') is not null
	drop table #MonitorUptime


set @StartDT=cast(convert(varchar(10), @StartDT, 120) + ' 00:00:00' as datetime)
set @EndDT = cast(convert(varchar(10), @EndDT, 120) + ' 23:59:59' as datetime)


create table #MonitorUptime (MonitorID int, TPPercUptime decimal(6,3), LifetimePercUpTime decimal(6,3))

insert into #MonitorUptime (MonitorID)
select distinct MonitorID from Monitor with(NOLOCK)

/*
if @IncludeLifetime=1
	begin
	update #MonitorUptime
	set LifetimePercUpTime = Tbl1.PercUptime
	from
	(select MonitorID, cast(100*(1-cast((sum(abs(UpDownTimeSecs))-sum(UpDownTimeSecs))/2 as float) / cast(sum(abs(UpDownTimeSecs)) as float)) as decimal(6,3)) as PercUptime
	from MonitorEvent
	group by MonitorID) as Tbl1
	where Tbl1.MonitorID=#MonitorUptime.MonitorID
	end
*/

if @IncludeLifetime=1
	begin
	update #MonitorUptime
	set LifetimePercUptime=MCS.LifetimePercUptime
	from MonitorCurrentStatus MCS
	where #MonitorUptime.MonitorID=MCS.MonitorID
	end

update #MonitorUptime
set TPPercUpTime = Tbl1.PercUptime
from
(select MonitorID, cast(100*(1-cast((sum(abs(UpDownTimeSecs))-sum(UpDownTimeSecs))/2 as float) / cast(sum(abs(UpDownTimeSecs)) as float)) as decimal(6,3)) as PercUptime
from MonitorEvent
where MonitorEvent.EventDT between @StartDT and @EndDT
group by MonitorID) as Tbl1
where Tbl1.MonitorID=#MonitorUptime.MonitorID

update #MonitorUpTime
set LifetimePercUpTime=0
where LifetimePercUpTime is null

update #MonitorUpTime
set TPPercUpTime=0
where TPPercUpTime is null

if @IncludeLifetime=1
	begin
	select Monitor.MonitorID as [Monitor ID], 
		Monitor.Name as Monitor, 
		MonitorType.Name as [Monitor Type], 
		#MonitorUptime.TPPercUptime as [% Uptime], 
		#MonitorUptime.LifetimePercUptime as [Lifetime % Uptime]
	from #MonitorUptime 
		inner join Monitor with(NOLOCK) on #MonitorUptime.MonitorID=Monitor.MonitorID
		inner join MonitorType with(NOLOCK) on Monitor.MonitorTypeID=MonitorType.MonitorTypeID
	end
else
	begin
	select Monitor.MonitorID as [Monitor ID], 
		Monitor.Name as Monitor, 
		MonitorType.Name as [Monitor Type], 
		#MonitorUptime.TPPercUptime as [% Uptime]
	from #MonitorUptime 
		inner join Monitor with(NOLOCK) on #MonitorUptime.MonitorID=Monitor.MonitorID
		inner join MonitorType with(NOLOCK) on Monitor.MonitorTypeID=MonitorType.MonitorTypeID
	end

if object_id('Tempdb..#MonitorUptime') is not null
	drop table #MonitorUptime

END





GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE FUNCTION [dbo].[fn_IsOfflineTime]
(@OTStart char(5), @OTEnd char(5), @CurrDT datetime)
RETURNS bit AS  
BEGIN 

Declare @QTStart int
Declare @QTEnd int
Declare @CurrTime as integer

set @QTStart=cast(replace(coalesce(@OTStart, '00:00'), ':', '') as int)
set @QTEnd = cast(replace(coalesce(@OTEnd, '00:00'), ':', '') as int)

set @CurrTime =  cast(replace(convert(varchar(5), @CurrDT, 8), ':', '') as integer)

Declare @IsQT bit

set @IsQT=0

if @QTStart<@QTEnd
	begin
	--straight test
	if @CurrTime>=@QTStart and @CurrTime<=@QTEnd
		set @IsQT=1
	end

if @QTStart>@QTEnd
	begin
	--split test over 24:00
	if (@CurrTime>=@QTStart and @CurrTime <=2400) or (@CurrTime<=@QTEnd)
		set @IsQT=1
	end

return @IsQT
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/21/2007
-- Description:	Returns Daily historical Status data for specified MonitorID
-- =============================================
CREATE PROCEDURE [dbo].[rpt_StatusData_Daily] 
	@MonitorID int, 
	@StartDT datetime,
	@EndDT datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	set @StartDT = cast(convert(varchar(10), @StartDT, 120) + ' 00:00:00' as datetime)
	set @EndDT = cast(convert(varchar(10), @EndDT, 120) + ' 23:59:59' as datetime)

	select	T.DT as DT_Raw,
			convert(varchar(10), T.DT, 120) as DT_Display,
			OKCount, 
			WarningCount, 
			FailureCount, 
			TotalUpTime, 
			TotalDownTime,
			cast(round(	case when TotalUpTime + TotalDownTime = 0 then 0 else
							100 * cast(TotalUpTime as float) / (cast(TotalUpTime as float) + cast(TotalDownTime as float))
						end, 3) as decimal(6,3)) as PercUpTime
	from AggStatus_Daily Agg with(NOLOCK)
		inner join TSDaily T with(NOLOCK) on Agg.TimespanID = T.TimespanID
	where Agg.MonitorID=@MonitorID and T.DT between @StartDT and @EndDT
	order by T.DT desc
END











GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/21/2007
-- Description:	Returns Daily Counter Data for specified Monitor and date range
-- =============================================
CREATE PROCEDURE [dbo].[rpt_CounterData_Daily] 
	@MonitorID int, 
	@StartDT datetime,
	@EndDT datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	set @StartDT = cast(convert(varchar(10), @StartDT, 120) + ' 00:00:00' as datetime)
	set @EndDT = cast(convert(varchar(10), @EndDT, 120) + ' 23:59:59' as datetime)

	Declare @CounterNames as table (CounterName varchar(800))

	insert into @CounterNames
	select distinct CounterName 
		from AggCounter_Daily Agg with(NOLOCK)
			inner join TSDaily TS with(NOLOCK) on Agg.TimespanID=TS.TimespanID
		where MonitorID = @MonitorID
			and TS.DT between @StartDT and @EndDT

	Declare @NumCounters int
	select @NumCounters = count(*) from @CounterNames

	if @NumCounters=0
	return 1

/*
Sample: Monitor contains two counters, AvgRTT and PercOK

select TS.DT as [DT_Raw], 
	convert(varchar(10), TS.DT, 101) as [DT_Display],
	sum(case when CounterName='AvgRTT' then 
			case when NumCounterSamples=0 then 0 else SumCounterValue/NumCounterSamples end
		else 0 end) as [AvgRTT (Avg)],
	sum(case when CounterName='AvgRTT' then NumCounterSamples else 0 end) as [AvgRTT (# Samples)],
	sum(case when CounterName='PercOK' then 
		case when NumCounterSamples=0 then 0 else SumCounterValue/NumCounterSamples end
	else 0 end) as [PercOK (Avg)],
	sum(case when CounterName='PercOK' then NumCounterSamples else 0 end) as [PercOK (# Samples)]
from AggCounter_Daily Agg
	inner join TSDaily TS on Agg.TimespanID=TS.TimespanID
where Agg.MonitorID=34 and TS.DT between '2/1/2007' and '2/21/2007'
group by TS.DT
order by TS.DT desc
*/

Declare @SQL varchar(8000)

	set @SQL = 'select TS.DT as [DT_Raw], convert(varchar(10), TS.DT, 120) as [DT_Display], '
	
	select @SQL = @SQL + 'sum(case when CounterName=''' + CounterName + ''' then case when NumCounterSamples=0 then 0 else SumCounterValue/NumCounterSamples end else 0 end) as [' + CounterName + ' (Avg)],'
		+ 'sum(case when CounterName=''' + CounterName + ''' then NumCounterSamples else 0 end) as [' + CounterName + ' (# Samples)],'
	from @CounterNames order by CounterName

	set @SQL = substring(@SQL, 1, len(@SQL)-1) + ' '

	set @SQL = @SQL + ' from AggCounter_Daily Agg with(NOLOCK) inner join TSDaily TS with(NOLOCK) on Agg.TimespanID=TS.TimespanID '
	set @SQL = @SQL + ' where Agg.MonitorID = ' + cast(@MonitorID as varchar(10)) 
	set @SQL = @SQL + ' and TS.DT between ''' + convert(varchar(10), @StartDT, 101) + ' 00:00:00' + ''' '
	set @SQL = @SQL + ' and ''' + convert(varchar(10), @EndDT, 101) + ' 23:59:59' + ''' '
	set @SQL = @SQL + ' group by TS.DT order by TS.DT desc'


	EXEC(@SQL)	


END







GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/16/2007
-- Description:	Updates AggStatus Tables
-- =============================================
CREATE PROCEDURE [dbo].[agg_UpdateStatusTables] 
	@MonitorID int,
	@EventDT datetime,
	@StatusID tinyint,
	@UpDownTimeSecs int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--Status: 1=OK, 2=Warning, 3=Fail
	Declare @TimespanID smallint


	Declare @WarningCount int
	Declare @FailureCount int
	Declare @OKCount int
	Declare @UpTime int
	Declare @DownTime int

	select @WarningCount = case when @StatusID=2 then 1 else 0 end,
		@FailureCount = case when @StatusID=3 then 1 else 0 end,
		@OKCount = case when @StatusID=1 then 1 else 0 end,
		@UpTime = case when @UpDownTimeSecs>0 then @UpDownTimeSecs else 0 end,
		@DownTime = case when @UpDownTimeSecs<0 then abs(@UpDownTimeSecs) else 0 end


	--Update AggStatus_Daily
	select @TimespanID=TimespanID
	from TSDaily
	where Year=year(@EventDT) and Month=month(@EventDT) and Day=day(@EventDT)

	if exists(select * from AggStatus_Daily where MonitorID=@MonitorID and TimespanID=@TimespanID)
		begin
		--Update record
		update AggStatus_Daily
		set WarningCount = WarningCount + @WarningCount,
			FailureCount = FailureCount + @FailureCount,
			OKCount = OKCount + @OKCount,
			TotalUpTime = TotalUpTime + @Uptime,
			TotalDownTime = TotalDownTime + @DownTime
		where MonitorID=@MonitorID and TimespanID=@TimespanID
		end
	else
		begin
		insert into AggStatus_Daily (MonitorID, TimespanID, WarningCount, FailureCount, OKCount, TotalUpTime, TotalDownTime)
		select @MonitorID, @TimespanID, @WarningCount, @FailureCount, @OKCount, @UpTime, @DownTime
		end

	--Update AggStatus_Weekly
	select @TimespanID=TimespanID
	from TSWeekly
	where Year=year(@EventDT) and WeekOfYear=datepart(ww,@EventDT)

	if exists(select * from AggStatus_Weekly where MonitorID=@MonitorID and TimespanID=@TimespanID)
		begin
		--Update
		update AggStatus_Weekly
		set WarningCount = WarningCount + @WarningCount,
			FailureCount = FailureCount + @FailureCount,
			OKCount = OKCount + @OKCount,
			TotalUpTime = TotalUpTime + @UpTime,
			TotalDownTime = TotalDownTime + @DownTime
		where MonitorID=@MonitorID and TimespanID=@TimespanID
		end
	else
		begin
		--Insert
		insert into AggStatus_Weekly (MonitorID, TimespanID, WarningCount, FailureCount, OKCount, TotalUpTime, TotalDownTime)
		values (@MonitorID, @TimespanID, @WarningCount, @FailureCount, @OKCount, @UpTime, @DownTime)
		end


	--Update AggStatus_Monthly
	select @TimespanID=TimespanID
	from TSMonthly
	where Year=year(@EventDT) and Month=month(@EventDT)

	if exists(select * from AggStatus_Monthly where MonitorID=@MonitorID and TimespanID=@TimespanID)
		begin
		--Update
		update AggStatus_Monthly
		set WarningCount = WarningCount + @WarningCount,
			FailureCount = FailureCount + @FailureCount,
			OKCount = OKCount + @OKCount,
			TotalUpTime = TotalUpTime + @UpTime,
			TotalDownTime = TotalDownTime + @DownTime
		where MonitorID=@MonitorID and TimespanID=@TimespanID
		end
	else
		begin
		--Insert
		insert into AggStatus_Monthly (MonitorID, TimespanID, WarningCount, FailureCount, OKCount, TotalUpTime, TotalDownTime)
		values (@MonitorID, @TimespanID, @WarningCount, @FailureCount, @OKCount, @UpTime, @DownTime)
		end

END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/16/2007
-- Description:	Updates AggCounter Tables
-- =============================================
CREATE PROCEDURE [dbo].[agg_UpdateCounterTables] 
	@MonitorID int,
	@EventDT datetime,
	@CounterName varchar(800),
	@CounterValue decimal(30,10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @TimespanID smallint


	--Update AggCounter_Daily
	select @TimespanID=TimespanID
	from TSDaily
	where Year=year(@EventDT) and Month=month(@EventDT) and Day=day(@EventDT)

	if exists(select * from AggCounter_Daily where MonitorID=@MonitorID and TimespanID=@TimespanID and CounterName=@CounterName)
		begin
		--Update record
		update AggCounter_Daily
		set SumCounterValue = SumCounterValue + @CounterValue,
			NumCounterSamples = NumCounterSamples+1
		where MonitorID=@MonitorID and TimespanID=@TimespanID and CounterName=@CounterName
		end
	else
		begin
		insert into AggCounter_Daily (MonitorID, TimespanID, CounterName, SumCounterValue, NumCounterSamples)
		select @MonitorID, @TimespanID, @CounterName, @CounterValue, 1
		end

	--Update AggCounter_Weekly
	select @TimespanID=TimespanID
	from TSWeekly
	where Year=year(@EventDT) and WeekOfYear=datepart(ww,@EventDT)

	if exists(select * from AggCounter_Weekly where MonitorID=@MonitorID and TimespanID=@TimespanID and CounterName=@CounterName)
		begin
		--Update record
		update AggCounter_Weekly
		set SumCounterValue = SumCounterValue + @CounterValue,
			NumCounterSamples = NumCounterSamples+1
		where MonitorID=@MonitorID and TimespanID=@TimespanID and CounterName=@CounterName
		end
	else
		begin
		insert into AggCounter_Weekly (MonitorID, TimespanID, CounterName, SumCounterValue, NumCounterSamples)
		select @MonitorID, @TimespanID, @CounterName, @CounterValue, 1
		end


	--Update AggCounter_Monthly
	select @TimespanID=TimespanID
	from TSMonthly
	where Year=year(@EventDT) and Month=month(@EventDT)

	if exists(select * from AggCounter_Monthly where MonitorID=@MonitorID and TimespanID=@TimespanID and CounterName=@CounterName)
		begin
		--Update record
		update AggCounter_Monthly
		set SumCounterValue = SumCounterValue + @CounterValue,
			NumCounterSamples = NumCounterSamples+1
		where MonitorID=@MonitorID and TimespanID=@TimespanID and CounterName=@CounterName
		end
	else
		begin
		insert into AggCounter_Monthly (MonitorID, TimespanID, CounterName, SumCounterValue, NumCounterSamples)
		select @MonitorID, @TimespanID, @CounterName, @CounterValue, 1
		end
	
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/22/2007
-- Description:	Returns Start/End Dates of Monitor Data
-- =============================================
CREATE PROCEDURE [dbo].[rpt_GetStatusDateRanges] 
	-- Add the parameters for the stored procedure here
	@MonitorID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--Min/Max Dates for Raw Data
	Declare @RawStartDT datetime
	Declare @RawEndDT datetime
	select @RawStartDT=min(EventDT), @RawEndDT=max(EventDT)
	from MonitorEvent with(NOLOCK) where MonitorID=@MonitorID

	--Min/Max Dates for Daily Data
	Declare @DailyStartDT datetime
	Declare @DailyEndDT datetime
	select @DailyStartDT=min(TSDaily.DT), @DailyEndDT=max(TSDaily.DT)
	from AggStatus_Daily with(NOLOCK)
		inner join TSDaily with(NOLOCK) on AggStatus_Daily.TimespanID=TSDaily.TimespanID
	where AggStatus_Daily.MonitorID=@MonitorID

	--Min.Max Dates for Weekly Data
	Declare @WeeklyStartDT datetime
	Declare @WeeklyEndDT datetime
	select @WeeklyStartDT=min(TSWeekly.StartDT), @WeeklyEndDT=max(TSWeekly.EndDT)
	from AggStatus_Weekly with(NOLOCK)
		inner join TSWeekly with(NOLOCK) on AggStatus_Weekly.TimespanID=TSWeekly.TimespanID
	where AggStatus_Weekly.MonitorID=@MonitorID

	--Min.Max Dates for Monthly Data
	Declare @MonthlyStartDT datetime
	Declare @MonthlyEndDT datetime
	select @MonthlyStartDT=min(TSMonthly.StartDT), @MonthlyEndDT=max(TSMonthly.EndDT)
	from AggStatus_Monthly with(NOLOCK)
		inner join TSMonthly with(NOLOCK) on AggStatus_Monthly.TimespanID=TSMonthly.TimespanID
	where AggStatus_Monthly.MonitorID=@MonitorID
    
	
	select @RawStartDT as RawStartDT,
		@RawEndDT as RawEndDT,
		@DailyStartDT as DailyStartDT,
		@DailyEndDT as DailyEndDT,
		@WeeklyStartDT as WeeklyStartDT,
		@WeeklyEndDT as WeeklyEndDT,
		@MonthlyStartDT as MonthlyStartDT,
		@MonthlyEndDT as MonthlyEndDT
END





GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/15/2007
-- Description:	Rebuilds AggStatus_xxx tables (Daily, Monthly, Yearly, Weekly)
-- =============================================
CREATE PROCEDURE [dbo].[agg_RebuildAggStatus]
	@ConfirmDelete varchar(50) = 'Not confirmed.'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

if @ConfirmDelete <> 'Confirm delete.'
	begin
	Declare @ErrMsg varchar(500)
	set @ErrMsg = 'This procedure will erase all your historical aggregate status data.' + char(10) + char(13) 
		+ 'New aggregates will be created only from whatever Raw data is in your database and as such may contain less information than what you currently have aggregated.'
		+ char(13) + char(10) + 'To proceed with this, please call this procedure with a parameter value of ''Confirm delete.'''
	raiserror(@ErrMsg, 16, 1)
	return -1
	end


	delete from AggStatus_Daily
	delete from AggStatus_Monthly
	delete from AggStatus_Weekly

	insert into AggStatus_Daily (MonitorID, TimespanID, WarningCount, FailureCount, OKCount, TotalUpTime, TotalDownTime)
	select MonitorEvent.MonitorID,
		TSDaily.TimespanID,
		sum(case when MonitorEvent.StatusID=2 then 1 else 0 end) as WarningCount,
		sum(case when MonitorEvent.StatusID=3 then 1 else 0 end) as FailureCount,
		sum(case when MonitorEvent.StatusID=1 then 1 else 0 end) as OKCount,
		sum(case when MonitorEvent.UpDownTimeSecs>0 then MonitorEvent.UpDownTimeSecs else 0 end) as TotalUpTime,
		sum(case when MonitorEvent.UpDownTimeSecs<0 then abs(MonitorEvent.UpDownTimeSecs) else 0 end) as TotalDownTime
	from TSDaily
		inner join MonitorEvent 
			on TSDaily.Year = year(MonitorEvent.EventDT)
				and TSDaily.Month=month(MonitorEvent.EventDT)
				and TSDaily.Day = day(MonitorEvent.EventDT)
	group by MonitorEvent.MonitorID,
		TSDaily.TimeSpanID


	insert into AggStatus_Monthly (MonitorID, TimespanID, WarningCount, FailureCount, OKCount, TotalUpTime, TotalDownTime)
	select MonitorID,
		TSMonthly.TimespanID,
		sum(WarningCount),
		sum(FailureCount),
		sum(OKCount),
		sum(TotalUpTime),
		sum(TotalDownTime)
	from TSDaily
		inner join TSMonthly on TSDaily.Year=TSMonthly.Year
			and TSDaily.Month = TSMonthly.Month
		inner join AggStatus_Daily
			on TSDaily.TimespanID=AggStatus_Daily.TimespanID
	group by TSMonthly.TimespanID, MonitorID


	insert into AggStatus_Weekly (MonitorID, TimespanID, WarningCount, FailureCount, OKCount, TotalUpTime, TotalDownTime)
	select MonitorEvent.MonitorID,
		TSWeekly.TimespanID,
		sum(case when MonitorEvent.StatusID=2 then 1 else 0 end) as WarningCount,
		sum(case when MonitorEvent.StatusID=3 then 1 else 0 end) as FailureCount,
		sum(case when MonitorEvent.StatusID=1 then 1 else 0 end) as OKCount,
		sum(case when MonitorEvent.UpDownTimeSecs>0 then MonitorEvent.UpDownTimeSecs else 0 end) as TotalUpTime,
		sum(case when MonitorEvent.UpDownTimeSecs<0 then abs(MonitorEvent.UpDownTimeSecs) else 0 end) as TotalDownTime
	from TSWeekly
		inner join MonitorEvent 
			on TSWeekly.Year = year(MonitorEvent.EventDT)
				and TSWeekly.WeekOfYear=datepart(ww,MonitorEvent.EventDT)
	group by MonitorEvent.MonitorID,
		TSWeekly.TimeSpanID
END




GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/15/2007
-- Description:	Rebuilds AggCounter_xxx tables (Daily, Monthly, Yearly, Weekly)
-- =============================================
CREATE PROCEDURE [dbo].[agg_RebuildAggCounter]
	@ConfirmDelete varchar(50) = 'Not confirmed.'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

if @ConfirmDelete <> 'Confirm delete.'
	begin
	Declare @ErrMsg varchar(500)
	set @ErrMsg = 'This procedure will erase all your historical aggregate counter data.' + char(10) + char(13) 
		+ 'New aggregates will be created only from whatever Raw data is in your database and as such may contain less information than what you currently have aggregated.'
		+ char(13) + char(10) + 'To proceed with this, please call this procedure with a parameter value of ''Confirm delete.'''
	raiserror(@ErrMsg, 16, 1)
	return -1
	end
		

	delete from AggCounter_Daily
	delete from AggCounter_Monthly
	delete from AggCounter_Weekly

	insert into AggCounter_Daily (MonitorID, TimespanID, CounterName, SumCounterValue, NumCounterSamples)
	select MonitorEventCounter.MonitorID,
		TSDaily.TimespanID,
		CounterName,
		sum(CounterValue),
		count(*)
	from TSDaily
		inner join MonitorEventCounter
			on TSDaily.Year = year(MonitorEventCounter.EventDT)
				and TSDaily.Month=month(MonitorEventCounter.EventDT)
				and TSDaily.Day = day(MonitorEventCounter.EventDT)
	group by MonitorID,
		TimeSpanID,
		CounterName


	insert into AggCounter_Monthly (MonitorID, TimespanID, CounterName, SumCounterValue, NumCounterSamples)
	select MonitorID,
		TSMonthly.TimespanID,
		CounterName,
		sum(SumCounterValue),
		sum(NumCounterSamples)
	from TSDaily
		inner join TSMonthly on TSDaily.Year=TSMonthly.Year
			and TSDaily.Month = TSMonthly.Month
		inner join AggCounter_Daily
			on TSDaily.TimespanID=AggCounter_Daily.TimespanID
	group by TSMonthly.TimespanID, MonitorID, CounterName

	
	insert into AggCounter_Weekly (MonitorID, TimespanID, CounterName, SumCounterValue, NumCounterSamples)
	select MonitorEventCounter.MonitorID,
		TSWeekly.TimespanID,
		CounterName,
		sum(CounterValue),
		count(*)
	from TSWeekly
		inner join MonitorEventCounter
			on TSWeekly.Year = year(MonitorEventCounter.EventDT)
				and TSWeekly.WeekOfYear=datepart(ww, MonitorEventCounter.EventDT)
	group by MonitorID,
		TimeSpanID,
		CounterName
END






GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/21/2007
-- Description:	Returns Monthly Counter Data for specified Monitor and date range
-- =============================================
CREATE PROCEDURE [dbo].[rpt_CounterData_Monthly] 
	@MonitorID int, 
	@StartDT datetime,
	@EndDT datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	set @StartDT = cast(convert(varchar(10), @StartDT, 120) + ' 00:00:00' as datetime)
	set @EndDT = cast(convert(varchar(10), @EndDT, 120) + ' 23:59:59' as datetime)

	Declare @CounterNames as table (CounterName varchar(800))

	insert into @CounterNames
	select distinct CounterName 
		from AggCounter_Monthly Agg with(NOLOCK)
			inner join TSMonthly TS with(NOLOCK) on Agg.TimespanID=TS.TimespanID
		where MonitorID = @MonitorID
			and TS.StartDT <= @EndDT and Ts.EndDT >= @StartDT

	Declare @NumCounters int
	select @NumCounters = count(*) from @CounterNames

	if @NumCounters=0
	return 1

/*
Sample: Monitor contains two counters, AvgRTT and PercOK

select max(TS.StartDT) as [StartDT_Raw], 
	convert(varchar(10), max(TS.StartDT), 101) as [StartDT_Display],
	max(TS.EndDT) as [EndDT_Raw],
	convert(varchar(10), max(TS.EndDT), 101) as [EndDT_Display],
	max([Year]) as [Year],
	max([Month]) as [Month],
	sum(case when CounterName='AvgRTT' then 
			case when NumCounterSamples=0 then 0 else SumCounterValue/NumCounterSamples end
		else 0 end) as [AvgRTT (Avg)],
	sum(case when CounterName='AvgRTT' then NumCounterSamples else 0 end) as [AvgRTT (# Samples)],
	sum(case when CounterName='PercOK' then 
		case when NumCounterSamples=0 then 0 else SumCounterValue/NumCounterSamples end
	else 0 end) as [PercOK (Avg)],
	sum(case when CounterName='PercOK' then NumCounterSamples else 0 end) as [PercOK (# Samples)]
from AggCounter_Monthly Agg
	inner join TSMonthly TS on Agg.TimespanID=TS.TimespanID
where Agg.MonitorID=34 and TS.StartDT <= '2/18/2007' and TS.EndDT >= '2/1/2007'
group by TS.TimespanID
order by max(TS.StartDT) desc
*/

	Declare @SQL varchar(8000)

	set @SQL = 'select max(TS.StartDT) as [StartDT_Raw], 
	convert(varchar(10), max(TS.StartDT), 120) as [StartDT_Display],
	max(TS.EndDT) as [EndDT_Raw],
	convert(varchar(10), max(TS.EndDT), 120) as [EndDT_Display],
	max([Year]) as [Year],
	max([Month]) as [Month], '
	
	select @SQL = @SQL + 'sum(case when CounterName=''' + CounterName + ''' then case when NumCounterSamples=0 then 0 else SumCounterValue/NumCounterSamples end else 0 end) as [' + CounterName + ' (Avg)],'
		+ 'sum(case when CounterName=''' + CounterName + ''' then NumCounterSamples else 0 end) as [' + CounterName + ' (# Samples)],'
	from @CounterNames order by CounterName

	set @SQL = substring(@SQL, 1, len(@SQL)-1) + ' '

	set @SQL = @SQL + ' from AggCounter_Monthly Agg with(NOLOCK) inner join TSMonthly TS with(NOLOCK) on Agg.TimespanID=TS.TimespanID '
	set @SQL = @SQL + ' where Agg.MonitorID = ' + cast(@MonitorID as varchar(10)) 
	set @SQL = @SQL + ' and TS.StartDT <= ''' + convert(varchar(10), @EndDT, 101) + ' 23:59:59' + ''' '
	set @SQL = @SQL + ' and TS.EndDT >= ''' + convert(varchar(10), @StartDT, 101) + ' 00:00:00' + ''' '
	set @SQL = @SQL + ' group by TS.TimespanID order by max(TS.StartDT) desc'

	EXEC(@SQL)	


END







GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/21/2007
-- Description:	Returns Monthly historical Status data for specified MonitorID
-- =============================================
CREATE PROCEDURE [dbo].[rpt_StatusData_Monthly] 
	@MonitorID int, 
	@StartDT datetime,
	@EndDT datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	set @StartDT = cast(convert(varchar(10), @StartDT, 120) + ' 00:00:00' as datetime)
	set @EndDT = cast(convert(varchar(10), @EndDT, 120) + ' 23:59:59' as datetime)

	select	T.Year,
			T.Month,
			T.StartDT as StartDT_Raw,
			T.EndDT as EndDT_Raw,
			convert(varchar(10), T.StartDT, 120) as StartDT_Display,
			convert(varchar(10), T.EndDT, 120) as EndDT_Display,
			OKCount, 
			WarningCount, 
			FailureCount, 
			TotalUpTime, 
			TotalDownTime,
			cast(round(	case when TotalUpTime + TotalDownTime = 0 then 0 else
							100 * cast(TotalUpTime as float) / (cast(TotalUpTime as float) + cast(TotalDownTime as float))
						end, 3) as decimal(7,3)) as PercUpTime
	from AggStatus_Monthly Agg with(NOLOCK)
		inner join TSMonthly T  with(NOLOCK) on Agg.TimespanID = T.TimespanID
	where Agg.MonitorID=@MonitorID and T.StartDT <= @EndDT and T.EndDT >= @StartDT
	order by T.StartDT desc
END









GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/21/2007
-- Description:	Returns Weekly historical Status data for specified MonitorID
-- =============================================
CREATE PROCEDURE [dbo].[rpt_StatusData_Weekly] 
	@MonitorID int, 
	@StartDT datetime,
	@EndDT datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	set @StartDT = cast(convert(varchar(10), @StartDT, 120) + ' 00:00:00' as datetime)
	set @EndDT = cast(convert(varchar(10), @EndDT, 120) + ' 23:59:59' as datetime)

	select	T.Year,
			T.WeekOfYear,
			T.StartDT as StartDT_Raw,
			T.EndDT as EndDT_Raw,
			convert(varchar(10), T.StartDT, 120) as StartDT_Display,
			convert(varchar(10), T.EndDT, 120) as EndDT_Display,
			OKCount, 
			WarningCount, 
			FailureCount, 
			TotalUpTime, 
			TotalDownTime,
			cast(round(	case when TotalUpTime + TotalDownTime = 0 then 0 else
							100 * cast(TotalUpTime as float) / (cast(TotalUpTime as float) + cast(TotalDownTime as float))
						end, 3) as decimal(7,3)) as PercUpTime
	from AggStatus_Weekly Agg with(NOLOCK)
		inner join TSWeekly T with(NOLOCK) on Agg.TimespanID = T.TimespanID
	where Agg.MonitorID=@MonitorID and T.StartDT <= @EndDT and T.EndDT >= @StartDT
	order by T.StartDT desc
END










GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/21/2007
-- Description:	Returns Weekly Counter Data for specified Monitor and date range
-- =============================================
CREATE PROCEDURE [dbo].[rpt_CounterData_Weekly] 
	@MonitorID int, 
	@StartDT datetime,
	@EndDT datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	set @StartDT = cast(convert(varchar(10), @StartDT, 120) + ' 00:00:00' as datetime)
	set @EndDT = cast(convert(varchar(10), @EndDT, 120) + ' 23:59:59' as datetime)

	Declare @CounterNames as table (CounterName varchar(800))

	insert into @CounterNames
	select distinct CounterName 
		from AggCounter_Weekly Agg with(NOLOCK)
			inner join TSWeekly TS with(NOLOCK) on Agg.TimespanID=TS.TimespanID
		where MonitorID = @MonitorID
			and TS.StartDT <= @EndDT and Ts.EndDT >= @StartDT

	Declare @NumCounters int
	select @NumCounters = count(*) from @CounterNames

	if @NumCounters=0
	return 1

/*
Sample: Monitor contains two counters, AvgRTT and PercOK

select max(TS.StartDT) as [StartDT_Raw], 
	convert(varchar(10), max(TS.StartDT), 101) as [StartDT_Display],
	max(TS.EndDT) as [EndDT_Raw],
	convert(varchar(10), max(TS.EndDT), 101) as [EndDT_Display],
	max([Year]) as [Year],
	max(WeekOfYear) as WeekOfYear,
	sum(case when CounterName='AvgRTT' then 
			case when NumCounterSamples=0 then 0 else SumCounterValue/NumCounterSamples end
		else 0 end) as [AvgRTT (Avg)],
	sum(case when CounterName='AvgRTT' then NumCounterSamples else 0 end) as [AvgRTT (# Samples)],
	sum(case when CounterName='PercOK' then 
		case when NumCounterSamples=0 then 0 else SumCounterValue/NumCounterSamples end
	else 0 end) as [PercOK (Avg)],
	sum(case when CounterName='PercOK' then NumCounterSamples else 0 end) as [PercOK (# Samples)]
from AggCounter_Weekly Agg
	inner join TSWeekly TS on Agg.TimespanID=TS.TimespanID
where Agg.MonitorID=34 and TS.StartDT <= '2/18/2007' and TS.EndDT >= '2/1/2007'
group by TS.TimespanID
order by max(TS.StartDT) desc
*/

Declare @SQL varchar(8000)

	set @SQL = 'select max(TS.StartDT) as [StartDT_Raw], 
	convert(varchar(10), max(TS.StartDT), 120) as [StartDT_Display],
	max(TS.EndDT) as [EndDT_Raw],
	convert(varchar(10), max(TS.EndDT), 120) as [EndDT_Display],
	max([Year]) as [Year],
	max(WeekOfYear) as WeekOfYear, '
	
	select @SQL = @SQL + 'sum(case when CounterName=''' + CounterName + ''' then case when NumCounterSamples=0 then 0 else SumCounterValue/NumCounterSamples end else 0 end) as [' + CounterName + ' (Avg)],'
		+ 'sum(case when CounterName=''' + CounterName + ''' then NumCounterSamples else 0 end) as [' + CounterName + ' (# Samples)],'
	from @CounterNames order by CounterName

	set @SQL = substring(@SQL, 1, len(@SQL)-1) + ' '

	set @SQL = @SQL + ' from AggCounter_Weekly Agg with(NOLOCK) inner join TSWeekly TS with(NOLOCK) on Agg.TimespanID=TS.TimespanID '
	set @SQL = @SQL + ' where Agg.MonitorID = ' + cast(@MonitorID as varchar(10)) 
	set @SQL = @SQL + ' and TS.StartDT <= ''' + convert(varchar(10), @EndDT, 120) + ' 23:59:59' + ''' '
	set @SQL = @SQL + ' and TS.EndDT >= ''' + convert(varchar(10), @StartDT, 120) + ' 00:00:00' + ''' '
	set @SQL = @SQL + ' group by TS.TimespanID order by max(TS.StartDT) desc'

	EXEC(@SQL)	


END






GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/15/2007
-- Description:	Deletes Monitor Data for specified Monitor
-- =============================================
CREATE PROCEDURE [dbo].[polymon_del_MonitorData] 
	-- Add the parameters for the stored procedure here
	@MonitorID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if not exists(select * from Monitor where MonitorID=@MonitorID)
		return --bail out is monitor does not exist

	Declare @IsEnabled bit
	select @IsEnabled=IsEnabled from Monitor where MonitorID=@MonitorID

	--First turn monitor off to prevent any further processing
	update Monitor
	set IsEnabled=0 where MonitorID=@MonitorID

	Declare @Err int
	--Delete Data
	begin tran
		delete from AggStatus_Monthly where MonitorID=@MonitorID
		set @Err=@@ERROR
		if @Err<>0
			begin
			rollback tran
			goto Cleanup
			return
			end

		delete from AggCounter_Monthly where MonitorID=@MonitorID
		set @Err=@@ERROR
		if @Err<>0
			begin
			rollback tran
			goto Cleanup
			return
			end

		delete from AggStatus_Weekly where MonitorID=@MonitorID
		set @Err=@@ERROR
		if @Err<>0
			begin
			rollback tran
			goto Cleanup
			return
			end

		delete from AggCounter_Weekly where MonitorID=@MonitorID
		set @Err=@@ERROR
		if @Err<>0
			begin
			rollback tran
			goto Cleanup
			return
			end

		delete from AggStatus_Daily where MonitorID=@MonitorID
		set @Err=@@ERROR
		if @Err<>0
			begin
			rollback tran
			goto Cleanup
			return
			end

		delete from AggCounter_Daily where MonitorID=@MonitorID
		set @Err=@@ERROR
		if @Err<>0
			begin
			rollback tran
			goto Cleanup
			return
			end

		delete from MonitorEvent where MonitorID=@MonitorID
		set @Err=@@ERROR
		if @Err<>0
			begin
			rollback tran
			goto Cleanup
			return
			end

		delete from MonitorEventCounter where MonitorID=@MonitorID
		set @Err=@@ERROR
		if @Err<>0
			begin
			rollback tran
			goto Cleanup
			return
			end

		delete from MonitorCurrentStatus where MonitorID=@MonitorID
		set @Err=@@ERROR
		if @Err<>0
			begin
			rollback tran
			goto Cleanup
			return
			end

	commit tran

Cleanup:
	--Finally restore enabled flag to what it was
	update Monitor
	set IsEnabled=@IsEnabled
	where MonitorID=@MonitorID
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/7/2007
-- Description:	Registers a PolyMon Executive Service
-- =============================================
CREATE PROCEDURE [dbo].[polymon_hyb_SetExecutiveService] 
	-- Add the parameters for the stored procedure here
	@ExecutiveID int, 
	@Host varchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if exists(select * from SysSettings)
		update SysSettings
		set ServiceServer=@Host

	if exists(select * from Executive where ExecutiveID=@ExecutiveID)
		update Executive
		set Server=@Host
		where ExecutiveID=@ExecutiveID
	else
		insert into Executive (ExecutiveID, Server) values(@ExecutiveID, @Host)


END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/21/2007
-- Description:	Reports Current Status info for specified Monitor
-- =============================================
CREATE PROCEDURE [dbo].[rpt_CurrentStatus] 
	@MonitorID int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select MonitorCurrentSTatus.MonitorID,
			MonitorCurrentStatus.EventDT as LastEventDT_Raw,
			convert(varchar(23), EventDT, 120)  as LastEventDT_Display,
			MonitorCurrentStatus.EventID as LastEventID,
			MonitorCurrentStatus.StatusID as LastStatusID,
			coalesce(LookupEventStatus.Status, 'Unknown') as LastStatus,
			MonitorCurrentStatus.StatusMessage as LastStatusMessage,
			Monitor.IsEnabled as IsEnabled,
			Monitor.TriggerMod as TriggerMod,
			MonitorCurrentStatus.LifetimePercUpTime as LifetimePercUpTime
	from Monitor with(NOLOCK)
		inner join MonitorCurrentStatus with(NOLOCK)
			on Monitor.MonitorID=MonitorCurrentStatus.MonitorID
		left outer join LookupEventStatus with(NOLOCK)
			on MonitorCurrentStatus.StatusID = LookupEventStatus.StatusID
	where MonitorCurrentStatus.MonitorID=@MonitorID
END








GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Fred Baptiste
-- Create date: 12/28/2006
-- Description:	Returns list of all monitors and current status
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_AllCurrentStatus] 

AS
BEGIN
	SET NOCOUNT ON;


select Monitor.MonitorID,
		Monitor.Name,
		MonitorType.Name as MonitorType,
		coalesce(MCS.EventDT,getdate()) as EventDT,
		coalesce(MCS.StatusID, 0) as StatusID,
		coalesce(LookupEventStatus.Status, 'Unknown') as Status,
		coalesce(MCS.StatusMessage, 'Unknown') as StatusMessage,
		coalesce(MCS.LifetimePercUptime,0) as LifetimePercUptime,
		Monitor.IsEnabled
from Monitor with(NOLOCK) 
	left outer join MonitorCurrentStatus MCS with(NOLOCK) on Monitor.MonitorID=MCS.MonitorID
	left outer join MonitorType with(NOLOCK) on Monitor.MonitorTypeID=MonitorType.MonitorTypeID
	left outer join LookupEventStatus with(NOLOCK) on MCS.StatusID=LookupEventStatus.StatusID
--where Monitor.IsEnabled=1
order by Monitor.Name


END





GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/16/2006
-- Description:	Returns Monitors not already in specified Group
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_DashboardGroupAvailableMonitors] 
	@GroupID int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Monitor.*
	from Monitor  with(NOLOCK)
		inner join MonitorType  with(NOLOCK) on Monitor.MonitorTypeID = MonitorType.MonitorTypeID
	where MonitorID not in (select distinct MonitorID from DashboardGroupMonitorDefault  with(NOLOCK) where GroupID=@GroupID)
	order by MonitorType.Name, Monitor.Name
END



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[polymon_sel_MonitorList]
	@ExecutiveID int = NULL
AS

/*
===================================================================
Procedure Name: polymon_sel_MonitorList
Author: Fred Baptiste	
Create Date: 10/21/2005
Purpose:  List all monitors
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

select MonitorID,
	Monitor.Name,
	MonitorType.Name as MonitorType,
	MonitorType.MonitorAssembly,
	MonitorType.EditorAssembly
from Monitor with(NOLOCK)
	inner join MonitorType with(NOLOCK) on Monitor.MonitorTypeID=MonitorType.MonitorTypeID
where (Monitor.ExecutiveID = @ExecutiveID or @ExecutiveID is NULL )
order by MonitorType.Name, Monitor.Name



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[polymon_sel_MonitorMetadata]
@MonitorID integer
AS

/*
===================================================================
Procedure Name: polymon_sel_MonitorMetadata
Author: Fred Baptiste
Create Date: 10/21/2005
Purpose:  Retrieves metadata for specified MonitorID
Parameters: @MonitorID - ID of Monitor for which to retrieve metadata
	
Output:  Resultset containing a single record corresponding to specified MonitorID
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

--Default Retention Settings
Declare @DefaultMaxRaw smallint
Declare @DefaultMaxDaily smallint
Declare @DefaultMaxWeekly smallint
Declare @DefaultMaxMonthly smallint


select @DefaultMaxRaw = RetentionMaxMonthsRaw,
	@DefaultMaxDaily = RetentionMaxMonthsDaily,
	@DefaultMaxWeekly = RetentionMaxMonthsWeekly,
	@DefaultMaxMonthly = RetentionMaxMonthsMonthly
from SysSettings


select Monitor.*,
	coalesce(Monitor.AuditUpdateDT, Monitor.AuditCreateDT) as MetadataCurrentDT,
	MonitorType.Name as MonitorTypeName,
	MonitorType.MonitorAssembly,
	MonitorType.EditorAssembly,
	coalesce(MonitorAlertRule.AlertAfterEveryNEvent, 0) as AlertAfterEveryNEvent,
	coalesce(MonitorAlertRule.AlertAfterEveryNewFailure, 1) as AlertAfterEveryNewFailure,
	coalesce(MonitorAlertRule.AlertAfterEveryNFailures, 0) as AlertAfterEveryNFailures,
	coalesce(MonitorAlertRule.AlertAfterEveryFailToOK, 1) as AlertAfterEveryFailToOK,
	coalesce(MonitorAlertRule.AlertAfterEveryNewWarning, 0) as AlertAfterEveryNewWarning,
	coalesce(MonitorAlertRule.AlertAfterEveryNWarnings, 0) as AlertAfterEveryNWarnings,
	coalesce(MonitorAlertRule.AlertAfterEveryWarnToOK, 0) as AlertAfterEveryWarnToOK,
	coalesce(MaxMonthsRaw, @DefaultMaxRaw) as MaxMonthsRaw,
	coalesce(MaxMonthsDaily, @DefaultMaxDaily) as MaxMonthsDaily,
	coalesce(MaxMonthsWeekly, @DefaultMaxWeekly) as MaxMonthsWeekly,
	coalesce(MaxMonthsMonthly, @DefaultMaxMonthly) as MaxMonthsMonthly
from Monitor with(NOLOCK)
	inner join MonitorType with(NOLOCK) on Monitor.MonitorTypeID=MonitorType.MonitorTypeID
	left outer join MonitorAlertRule with(NOLOCK) on Monitor.MonitorID=MonitorAlertRule.MonitorID
	left outer join MonitorRetentionScheme with(NOLOCK) on Monitor.MonitorID=MonitorRetentionScheme.MonitorID
where Monitor.MonitorID=@MonitorID


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[polymon_sel_MonitorMetadataCurrentDT]
@MonitorID int
AS

/*
===================================================================
Procedure Name: polymon_sel_MonitorMetadataCurrentDT
Author: Fred Baptiste	
Create Date: 10/27/2005
Purpose:  Returns the most recent create/update date on the Monitor table
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

select coalesce(AuditUpdateDT, AuditCreateDT) as MetadataCurrentDT
from Monitor with(NOLOCK)
where MonitorID=@MonitorID

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[polymon_hyb_SaveMonitorMetadata]
@MetadataXML ntext,
@MonitorID int output
AS

/*
===================================================================
Procedure Name: polymon_hyb_SaveMonitorMetadata
Author: Fred Baptiste
Create Date: 10/27/2005
Purpose:  Saves Monitor definition to database, creating a new MonitorID if neccesary.
Parameters: 
@MetadataXML contains monitor metadata
@MonitorID - returns existing or new MonitorID
	
Output:  
Notes:
@MetadataXML must follow this format:
<Monitor MonitorID="">	<!--leave MonitorID blank for a new monitor-->
	<Name>...</Name>
	<MonitorTypeID>...</MonitorTypeID>
	<MonitorXML>...</MonitorXML>
	<OfflineTime1Start>...</OfflineTime1Start>
	<OfflineTime1End>...</OfflineTime1End>
	<OfflineTime2Start>...</OfflineTime2Start>
	<OfflineTime2End>...</OfflineTime2End>
	<MessageSubjectTemplate>...</MessageSubjectTemplate>
	<MessageBodyTemplate>...</MessageBodyTemplate>
	<TriggerMod>...</TriggerMod>
	<IsEnabled>0|1</IsEnabled>
	<AlertAfterEveryNEvent>...</AlertAfterEveryNEvent>
	<AlertAfterEveryNewFailure>0|1</AlertAfterEveryNewFailure>
	<AlertAfterEveryNFailures>...</AlertAfterEveryNFailures>
	<AlertAfterEveryFailToOK>0|1</AlertAfterEveryFailToOK>
	<AlertAfterEveryNewWarning>0|1</AlertAfterEveryNewWarning>
	<AlertAfterEveryNWarnings>...</AlertAfterEveryNWarnings>
	<AlertAfterEveryWarnToOK>0|1</AlertAfterEveryWarnToOK>
	<RetentionMaxMonthsRaw>...</RetentionMaxMonthsRaw>
	<RetentionMaxMonthsDaily>...</RetentionMaxMonthsDaily>
	<RetentionMaxMonthsWeekly>...</RetentionMaxMonthsWeekly>
	<RetentionMaxMonthsMonthly>...</RetentionMaxMonthsMonthly>
</Monitor>
===================================================================
Revision History:


===================================================================
*/
set nocount on

Declare @hDoc int
Declare @IsNewMonitor bit
Declare @LocMonitorID int
Declare @Err int

exec sp_xml_preparedocument @hDoc OUTPUT,@MetadataXML

--Unfortunately, looks like an empty node in XML, when cast to an int, is returned as ) instead of a NULL value.
--Ah well, since we start numbering records in the Monitor table at 1, we can use 0 to effectively represent a NULL value.
select @LocMonitorID=case when MonitorID=0 then NULL else MonitorID end 
from OpenXML (@hDoc, 'Monitor')
with (MonitorID int '@MonitorID')

if @LocMonitorID is NULL 
	set @IsNewMonitor=1
else
	set @IsNewMonitor=0

if @IsNewMonitor=0
	set @MonitorID=@LocMonitorID

--Default Retention Settings
Declare @DefaultMaxRaw smallint
Declare @DefaultMaxDaily smallint
Declare @DefaultMaxWeekly smallint
Declare @DefaultMaxMonthly smallint


select @DefaultMaxRaw = RetentionMaxMonthsRaw,
	@DefaultMaxDaily = RetentionMaxMonthsDaily,
	@DefaultMaxWeekly = RetentionMaxMonthsWeekly,
	@DefaultMaxMonthly = RetentionMaxMonthsMonthly
from SysSettings



if @IsNewMonitor=1
begin
	--Insert new records
	begin tran
	insert into Monitor (Name, MonitorTypeID, MonitorXML, OfflineTime1Start, OfflineTime1End, OfflineTime2Start, OfflineTime2End, MessageSubjectTemplate, MessageBodyTemplate, TriggerMod, IsEnabled)
	select Name, 
		MonitorTypeID, 
		MonitorXML, 
		OfflineTime1Start, OfflineTime1End, 
		OfflineTime2Start, OfflineTime2End, 
		MessageSubjectTemplate, MessageBodyTemplate, 
		TriggerMod, IsEnabled
	from OpenXML(@hDoc, 'Monitor')
	with (Name varchar(50) 'Name',
		MonitorTypeID int 'MonitorTypeID',
		MonitorXML text 'MonitorXML',
		OfflineTime1Start char(5) 'OfflineTime1Start',
		OfflineTime1End char(5) 'OfflineTime1End',
		OfflineTime2Start char(5) 'OfflineTime2Start',
		OfflineTime2End char(5) 'OfflineTime2End',
		MessageSubjectTemplate nvarchar(100) 'MessageSubjectTemplate',
		MessageBodyTemplate nvarchar(3000) 'MessageBodyTemplate',
		TriggerMod int 'TriggerMod',
		IsEnabled bit 'IsEnabled')
	set @Err=@@ERROR
	if @Err<>0
	begin
		rollback tran
		return -1
	end

	set @LocMonitorID=@@IDENTITY

	insert into MonitorAlertRule (MonitorID, AlertAfterEveryNEvent, AlertAfterEveryNewFailure, AlertAfterEveryNFailures, AlertAfterEveryFailToOK, AlertAfterEveryNewWarning, AlertAfterEveryNWarnings, AlertAfterEveryWarnToOK)
	select 	@LocMonitorID, 
		AlertAfterEveryNEvent, 
		AlertAfterEveryNewFailure, 
		AlertAfterEveryNFailures, 
		AlertAfterEveryFailToOK, 
		AlertAfterEveryNewWarning, 
		AlertAfterEveryNWarnings, 
		AlertAfterEveryWarnToOK
	from OpenXML(@hDoc, 'Monitor')
	with (AlertAfterEveryNEvent int 'AlertAfterEveryNEvent', 
		AlertAfterEveryNewFailure bit 'AlertAfterEveryNewFailure', 
		AlertAfterEveryNFailures int 'AlertAfterEveryNFailures', 
		AlertAfterEveryFailToOK bit 'AlertAfterEveryFailToOK', 
		AlertAfterEveryNewWarning bit 'AlertAfterEveryNewWarning', 
		AlertAfterEveryNWarnings int 'AlertAfterEveryNWarnings', 
		AlertAfterEveryWarnToOK bit 'AlertAfterEveryWarnToOK')

	set @Err=@@ERROR
	if @Err<>0
	begin
		rollback tran
		return -1
	end

	insert into MonitorRetentionScheme (MonitorID, MaxMonthsRaw, MaxMonthsDaily, MaxMonthsWeekly, MaxMonthsMonthly)
	select @LocMonitorID,
		coalesce(RetentionMaxMonthsRaw, @DefaultMaxRaw),
		coalesce(RetentionMaxMonthsDaily, @DefaultMaxDaily),
		coalesce(RetentionMaxMonthsWeekly, @DefaultMaxWeekly),
		coalesce(RetentionMaxMonthsMonthly, @DefaultMaxMonthly)
	from OpenXML(@hDoc, 'Monitor')
	with (RetentionMaxMonthsRaw smallint 'RetentionMaxMonthsRaw',
		RetentionMaxMonthsDaily smallint 'RetentionMaxMonthsDaily',
		RetentionMaxMonthsWeekly smallint 'RetentionMaxMonthsWeekly',
		RetentionMaxMonthsMonthly smallint 'RetentionMaxMonthsMonthly')


	set @Err=@@ERROR
	if @Err<>0
	begin
		rollback tran
		return -1
	end
	else
	begin
		commit tran
		set @MonitorID=@LocMonitorID
		return 0
	end
end
else
begin
	--Update existing records
	begin tran
	update Monitor
	set Name=xName,
		MonitorTypeID =xMonitorTypeID,
		MonitorXML = xMonitorXML,
		OfflineTime1Start = xOfflineTime1Start,
		OfflineTime1End=xOfflineTime1End,
		OfflineTime2Start=xOfflineTime2Start,
		OfflineTime2End=xOfflineTime2End,
		MessageSubjectTemplate=xMessageSubjectTemplate,
		MessageBodyTemplate=xMessageBodyTemplate,
		TriggerMod=xTriggerMod,
		IsEnabled=xIsEnabled
	from OpenXML(@hDoc, 'Monitor')
		with (xName varchar(50) 'Name',
			xMonitorTypeID int 'MonitorTypeID',
			xMonitorXML text 'MonitorXML',
			xOfflineTime1Start char(5) 'OfflineTime1Start',
			xOfflineTime1End char(5) 'OfflineTime1End',
			xOfflineTime2Start char(5) 'OfflineTime2Start',
			xOfflineTime2End char(5) 'OfflineTime2End',
			xMessageSubjectTemplate nvarchar(100) 'MessageSubjectTemplate',
			xMessageBodyTemplate nvarchar(3000) 'MessageBodyTemplate',
			xTriggerMod int 'TriggerMod',
			xIsEnabled bit 'IsEnabled')
	where Monitor.MonitorID=@LocMonitorID

	set @Err=@@ERROR
	if @Err<>0
	begin
		rollback tran
		return -1
	end

	if exists(select * from MonitorAlertRule where MonitorID=@LocMonitorID)
		begin
		update MonitorAlertRule
		set AlertAfterEveryNEvent=xAlertAfterEveryNEvent, 
			AlertAfterEveryNewFailure=xAlertAfterEveryNewFailure, 
			AlertAfterEveryNFailures=xAlertAfterEveryNFailures, 
			AlertAfterEveryFailToOK=xAlertAfterEveryFailToOK, 
			AlertAfterEveryNewWarning=xAlertAfterEveryNewWarning, 
			AlertAfterEveryNWarnings=xAlertAfterEveryNWarnings, 
			AlertAfterEveryWarnToOK=xAlertAfterEveryWarnToOK
		from OpenXML(@hDoc, 'Monitor')
		with (xAlertAfterEveryNEvent int 'AlertAfterEveryNEvent', 
			xAlertAfterEveryNewFailure bit 'AlertAfterEveryNewFailure', 
			xAlertAfterEveryNFailures int 'AlertAfterEveryNFailures', 
			xAlertAfterEveryFailToOK bit 'AlertAfterEveryFailToOK', 
			xAlertAfterEveryNewWarning bit 'AlertAfterEveryNewWarning', 
			xAlertAfterEveryNWarnings int 'AlertAfterEveryNWarnings', 
			xAlertAfterEveryWarnToOK bit 'AlertAfterEveryWarnToOK')
		where MonitorAlertRule.MonitorID=@LocMonitorID
		end
	else
		begin
		insert into MonitorAlertRule (MonitorID, AlertAfterEveryNEvent, AlertAfterEveryNewFailure, AlertAfterEveryNFailures, AlertAfterEveryFailToOK, AlertAfterEveryNewWarning, AlertAfterEveryNWarnings, AlertAfterEveryWarnToOK)
		select 	@LocMonitorID, 
			AlertAfterEveryNEvent, 
			AlertAfterEveryNewFailure, 
			AlertAfterEveryNFailures, 
			AlertAfterEveryFailToOK, 
			AlertAfterEveryNewWarning, 
			AlertAfterEveryNWarnings, 
			AlertAfterEveryWarnToOK
		from OpenXML(@hDoc, 'Monitor')
		with (AlertAfterEveryNEvent int 'AlertAfterEveryNEvent', 
			AlertAfterEveryNewFailure bit 'AlertAfterEveryNewFailure', 
			AlertAfterEveryNFailures int 'AlertAfterEveryNFailures', 
			AlertAfterEveryFailToOK bit 'AlertAfterEveryFailToOK', 
			AlertAfterEveryNewWarning bit 'AlertAfterEveryNewWarning', 
			AlertAfterEveryNWarnings int 'AlertAfterEveryNWarnings', 
			AlertAfterEveryWarnToOK bit 'AlertAfterEveryWarnToOK')
		end

	set @Err=@@ERROR
	if @Err<>0
	begin
		rollback tran
		return -1
	end

	if exists(select * from MonitorRetentionScheme where MonitorID=@LocMonitorID)
		begin
		update MonitorRetentionScheme
		set MaxMonthsRaw = coalesce(RetentionMaxMonthsRaw, @DefaultMaxRaw),
			MaxMonthsDaily = coalesce(RetentionMaxMonthsDaily, @DefaultMaxDaily),
			MaxMonthsWeekly = coalesce(RetentionMaxMonthsWeekly, @DefaultMaxWeekly),
			MaxMonthsMonthly = coalesce(RetentionMaxMonthsMonthly, @DefaultMaxMonthly)
		from OpenXML(@hDoc, 'Monitor')
		with (RetentionMaxMonthsRaw smallint 'RetentionMaxMonthsRaw',
			RetentionMaxMonthsDaily smallint 'RetentionMaxMonthsDaily',
			RetentionMaxMonthsWeekly smallint 'RetentionMaxMonthsWeekly',
			RetentionMaxMonthsMonthly smallint 'RetentionMaxMonthsMonthly')
		where MonitorRetentionScheme.MonitorID=@LocMonitorID
		end
	else
		begin
		insert into MonitorRetentionScheme (MonitorID, MaxMonthsRaw, MaxMonthsDaily, MaxMonthsWeekly, MaxMonthsMonthly)
		select @LocMonitorID,
			coalesce(RetentionMaxMonthsRaw, @DefaultMaxRaw),
			coalesce(RetentionMaxMonthsDaily, @DefaultMaxDaily),
			coalesce(RetentionMaxMonthsWeekly, @DefaultMaxWeekly),
			coalesce(RetentionMaxMonthsMonthly, @DefaultMaxMonthly)
		from OpenXML(@hDoc, 'Monitor')
		with (RetentionMaxMonthsRaw smallint 'RetentionMaxMonthsRaw',
			RetentionMaxMonthsDaily smallint 'RetentionMaxMonthsDaily',
			RetentionMaxMonthsWeekly smallint 'RetentionMaxMonthsWeekly',
			RetentionMaxMonthsMonthly smallint 'RetentionMaxMonthsMonthly')
		end

	set @Err=@@Error
	if @Err<>0
	begin
		rollback tran
		return -1
	end
	else
	begin
		commit tran
		return 0
	end
end


exec sp_xml_removedocument @hDoc


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/23/2006
-- Description:	Returns a Panel record
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_DashboardPanel] 
	@PanelID int
AS
BEGIN
	SET NOCOUNT ON;

	select G.* , M.Name as MonitorName, MT.Name as MonitorType
	from DashboardGroupMonitorDefault G with(NOLOCK)
		inner join Monitor M  with(NOLOCK)on G.MonitorID=M.MonitorID
		inner join MonitorType MT  with(NOLOCK)on M.MonitorTypeID=MT.MonitorTypeID
	where PanelID=@PanelID
END



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/7/2006
-- Description:	Returns a list or all Monitors that are currently in Fail/Warn status and are enabled.
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_NonNominalMonitors] 
AS
BEGIN
	SET NOCOUNT ON

Declare @LastEvents table (MonitorID int, EventID int)


/*
insert into @LastEvents (MonitorID, EventID)
select MonitorID, max(EventID)
from MonitorEvent
group by MonitorID



select MonitorEvent.MonitorID, 
	MonitorEvent.EventID, 
	MonitorEvent.EventDT, 
	MonitorEvent.StatusID, 
	MonitorEvent.StatusMessage
from MonitorEvent
	inner join @LastEvents L on MonitorEvent.EventID=L.EventID
	inner join Monitor on MonitorEvent.MonitorID=Monitor.MonitorID
where StatusID <> 1 and Monitor.IsEnabled=1
order by MonitorEvent.StatusID desc
*/

/*
select MonitorEvent.MonitorID, 
	MonitorEvent.EventID, 
	MonitorEvent.EventDT, 
	MonitorEvent.StatusID, 
	MonitorEvent.StatusMessage
from MonitorEvent
	inner join Monitor on MonitorEvent.MonitorID=Monitor.MonitorID
where Monitor.IsEnabled=1
and MonitorEvent.EventID in (select MaxEventID
							from (select MonitorID, max(EventID) as MaxEventID, dbo.fn_MonitorCurrentStatusID(MonitorID) as StatusID
							from MonitorEvent
							group by MonitorID) Tbl
							where Tbl.StatusID<>1)
order by MonitorEvent.StatusID desc
*/

select Monitor.MonitorID,
		coalesce(MCS.EventID,0) as EventID,
		coalesce(MCS.EventDT, getdate()) as EventDT,
		coalesce(MCS.StatusID,0) as StatusID,
		coalesce('Unknown', MCS.StatusMessage) as StatusMessage
from Monitor  with(NOLOCK)
	left outer join MonitorCurrentStatus MCS with(NOLOCK) on Monitor.MonitorID=MCS.MonitorID
where Monitor.IsEnabled=1
	and MCS.StatusID<>1


END









GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/14/2006
-- Description:	Returns Panels for specified Group
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_DashboardGroupPanels] 
	-- Add the parameters for the stored procedure here
	@GroupID int 
AS
BEGIN
	SET NOCOUNT ON;

    
	SELECT T1.* 
	from DashboardGroupMonitorDefault T1 with(NOLOCK)
		inner join Monitor  with(NOLOCK) on T1.MonitorID=Monitor.MonitorID
	where GroupID=@GroupID
	order by DisplayOrder, Monitor.Name
END



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/2/2007
-- Description:	Indicates the last timestamp when a monitor definition was created/updated
-- =============================================
CREATE PROCEDURE [dbo].[executive_MonitorMetadataLatestUpdateDT] 
	@NumMonitors int output,
	@LatestDT datetime output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @MaxCreateDT datetime
	Declare @MaxUpdateDT datetime

	set @MaxCreateDT = '1990-01-01'
	set @MaxUpdateDT = '1990-01-01'

	select @MaxCreateDT = max(AuditCreateDT), @MaxUpdateDT=max(AuditUpdateDT)
	from Monitor with(NOLOCK)

	if @MaxCreateDT > @MaxUpdateDT
		set @LatestDT=@MaxCreateDT
	else
		set @LatestDT=@MaxUpdateDT


	select @NumMonitors=count(*) from Monitor with(NOLOCK)
END



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/28/2007
-- Description:	Applies Retention Scheme to Raw and Agg tables
-- =============================================
CREATE PROCEDURE [dbo].[agg_ApplyRetentionScheme] 
	@IsDebug bit = 1,
	@StatusMonthlyCount int output,
	@CounterMonthlyCount int output,
	@StatusWeeklyCount int output,
	@CounterWeeklyCount int output,
	@StatusDailyCount int output,
	@CounterDailyCount int output,
	@StatusRawCount int output,
	@CounterRawCount int output,
	@ErrMsg varchar(200) output,
	@Err int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--Default Retention Settings
	Declare @DefaultMaxRaw smallint
	Declare @DefaultMaxDaily smallint
	Declare @DefaultMaxWeekly smallint
	Declare @DefaultMaxMonthly smallint


	set @Err=0
	set @StatusMonthlyCount = 0
	set @CounterMonthlyCount = 0
	set @StatusWeeklyCount = 0
	set @CounterWeeklyCount = 0
	set @StatusDailyCount = 0
	set @CounterDailyCount = 0
	set @StatusRawCount = 0
	set @CounterRawCount = 0
	set @ErrMsg = NULL

	select @DefaultMaxRaw = RetentionMaxMonthsRaw,
		@DefaultMaxDaily = RetentionMaxMonthsDaily,
		@DefaultMaxWeekly = RetentionMaxMonthsWeekly,
		@DefaultMaxMonthly = RetentionMaxMonthsMonthly
	from SysSettings

	if object_id('tempdb..#RS') is not null
	drop table #RS

	create table #RS
	(
		MonitorID int primary key,
		MaxMonthsRaw int,
		MaxMonthsDaily int,
		MaxMonthsWeekly int,
		MaxMonthsMonthly int
	)
	insert #RS (MonitorID, MaxMonthsRaw, MaxMonthsDaily, MaxMonthsWeekly, MaxMonthsMonthly)
	select Monitor.MonitorID, 
		coalesce(MRS.MaxMonthsRaw, @DefaultMaxRaw) as MaxMonthsRaw,
		coalesce(MRS.MaxMonthsDaily, @DefaultMaxMonthly) as MaxMonthsDaily,
		coalesce(MRS.MaxMonthsWeekly, @DefaultMaxWeekly) as MaxMonthsWeekly,
		coalesce(MRS.MaxMonthsMonthly, @DefaultMaxMonthly) as MaxMonthsMonthly
	from Monitor left join MonitorRetentionScheme MRS on Monitor.MonitorID=MRS.MonitorID


	if @IsDebug=0
		begin tran

	
	/****** Delete Monthly Aggs, Status ******/
	if @IsDebug=1
		begin
		print 'Deleting: Status - Monthly...'
		select count(*) as [AggStatus_Monthly]
		from AggStatus_Monthly Agg
			inner join #RS RS on Agg.MonitorID=RS.MonitorID
			inner join TSMonthly TS on Agg.TimespanID=TS.TimespanID
		where TS.EndDT < dateadd(mm,-RS.MaxMonthsMonthly, getdate())

		set @StatusMonthlyCount=@@ROWCOUNT
		end
	else
		begin
		delete
		from AggStatus_Monthly
		from #RS RS, TSMonthly TS
		where AggStatus_Monthly.MonitorID=RS.MonitorID
		and AggStatus_Monthly.TimespanID=TS.TimespanID
		and TS.EndDT < dateadd(mm,-RS.MaxMonthsMonthly, getdate())

		select @Err=@@ERROR, @StatusMonthlyCount=@@ROWCOUNT
		if @Err<>0
			begin
			rollback tran
			set @StatusMonthlyCount = 0
			set @CounterMonthlyCount = 0
			set @StatusWeeklyCount = 0
			set @CounterWeeklyCount = 0
			set @StatusDailyCount = 0
			set @CounterDailyCount = 0
			set @StatusRawCount = 0
			set @CounterRawCount = 0
			set @ErrMsg = 'Error deleting from AggStatus_Monthly.'
			if object_id('tempdb..#RS') is not null
				drop table #RS
			return -1
			end
		end



	/****** Delete Monthly Aggs, Counters ******/
	if @IsDebug=1
		begin
		print 'Deleting Counters - Monthly...'
		select count(*) as [AggCounter_Monthly]
		from AggCounter_Monthly Agg
			inner join #RS RS on Agg.MonitorID=RS.MonitorID
			inner join TSMonthly TS on Agg.TimespanID=TS.TimespanID
		where TS.EndDT < dateadd(mm,-RS.MaxMonthsMonthly, getdate())

		set @CounterMonthlyCount=@@ROWCOUNT
		end
	else
		begin
		delete
		from AggCounter_Monthly 
		from #RS RS, TSMonthly TS
		where AggCounter_Monthly.MonitorID=RS.MonitorID
			and AggCounter_Monthly.TimespanID=TS.TimespanID
			and TS.EndDT < dateadd(mm,-RS.MaxMonthsMonthly, getdate())

		select @Err=@@ERROR, @CounterMonthlyCount=@@ROWCOUNT
		if @Err<>0
			begin
			rollback tran
			set @StatusMonthlyCount = 0
			set @CounterMonthlyCount = 0
			set @StatusWeeklyCount = 0
			set @CounterWeeklyCount = 0
			set @StatusDailyCount = 0
			set @CounterDailyCount = 0
			set @StatusRawCount = 0
			set @CounterRawCount = 0
			set @ErrMsg = 'Error deleting from AggCounter_Monthly.'
			if object_id('tempdb..#RS') is not null
				drop table #RS
			return -1
			end
		end


	/****** Delete Weekly Aggs, Status ******/
	if @IsDebug=1
		begin
		print 'Deleting Status - Weekly...'
		select count(*) as [AggStatus_Weekly]
		from AggStatus_Weekly Agg
			inner join #RS RS on Agg.MonitorID=RS.MonitorID
			inner join TSWeekly TS on Agg.TimespanID=TS.TimespanID
		where TS.EndDT < dateadd(mm,-RS.MaxMonthsWeekly, getdate())

		set @StatusWeeklyCount = @@ROWCOUNT
		end
	else
		begin
		delete
		from AggStatus_Weekly 
		from #RS RS, TSWeekly TS
		where AggStatus_Weekly.MonitorID=RS.MonitorID
			and AggStatus_Weekly.TimespanID=TS.TimespanID
			and TS.EndDT < dateadd(mm,-RS.MaxMonthsWeekly, getdate())

		select @Err=@@ERROR, @StatusWeeklyCount = @@ROWCOUNT
		if @Err<>0
			begin
			rollback tran
			set @StatusMonthlyCount = 0
			set @CounterMonthlyCount = 0
			set @StatusWeeklyCount = 0
			set @CounterWeeklyCount = 0
			set @StatusDailyCount = 0
			set @CounterDailyCount = 0
			set @StatusRawCount = 0
			set @CounterRawCount = 0
			set @ErrMsg = 'Error deleting from AggStatus_Weekly.'
			if object_id('tempdb..#RS') is not null
				drop table #RS
			return -1
			end
		end

		

	/****** Delete Weekly Aggs, Counter ******/
	if @IsDebug=1
		begin
		print 'Deleting Counters - Weekly...'
		select count(*) as [AggCounter_Weekly]
		from AggCounter_Weekly Agg
			inner join #RS RS on Agg.MonitorID=RS.MonitorID
			inner join TSWeekly TS on Agg.TimespanID=TS.TimespanID
		where TS.EndDT < dateadd(mm,-RS.MaxMonthsWeekly, getdate())

		set @CounterWeeklyCount = @@ROWCOUNT		
		end
	else
		begin
		delete
		from AggCounter_Weekly
		from #RS RS, TSWeekly TS
		where AggCounter_Weekly.MonitorID=RS.MonitorID
			and AggCounter_Weekly.TimespanID=TS.TimespanID
			and TS.EndDT < dateadd(mm,-RS.MaxMonthsWeekly, getdate())

		select @Err=@@ERROR, @CounterWeeklyCount = @@ROWCOUNT
		if @Err<>0
			begin
			rollback tran
			set @StatusMonthlyCount = 0
			set @CounterMonthlyCount = 0
			set @StatusWeeklyCount = 0
			set @CounterWeeklyCount = 0
			set @StatusDailyCount = 0
			set @CounterDailyCount = 0
			set @StatusRawCount = 0
			set @CounterRawCount = 0
			set @ErrMsg = 'Error deleting from AggCounter_Weekly.'
			if object_id('tempdb..#RS') is not null
				drop table #RS
			return -1
			end		
		end



	/****** Delete Daily Aggs, Status ******/
	if @IsDebug=1
		begin
		print 'Deleting Status - Daily...'
		select count(*) as [AggStatus_Daily]
		from AggStatus_Daily Agg
			inner join #RS RS on Agg.MonitorID=RS.MonitorID
			inner join TSDaily TS on Agg.TimespanID=TS.TimespanID
		where TS.DT < dateadd(mm,-RS.MaxMonthsDaily, getdate())

		set @StatusDailyCount = @@ROWCOUNT		
		end
	else
		begin
		delete
		from AggStatus_Daily
		from #RS RS, TSDaily TS
		where AggStatus_Daily.MonitorID=RS.MonitorID
			and AggStatus_Daily.TimespanID=TS.TimespanID
			and TS.DT < dateadd(mm,-RS.MaxMonthsDaily, getdate())

		select @Err=@@ERROR, @StatusDailyCount = @@ROWCOUNT
		if @Err<>0
			begin
			rollback tran
			set @StatusMonthlyCount = 0
			set @CounterMonthlyCount = 0
			set @StatusWeeklyCount = 0
			set @CounterWeeklyCount = 0
			set @StatusDailyCount = 0
			set @CounterDailyCount = 0
			set @StatusRawCount = 0
			set @CounterRawCount = 0
			set @ErrMsg = 'Error deleting from AggStatus_Daily.'
			if object_id('tempdb..#RS') is not null
				drop table #RS
			return -1
			end		
		end



	/****** Delete Daily Aggs, Counters ******/
	if @IsDebug=1
		begin
		print 'Deleting Counters - Daily...'
		select count(*) as [AggCounter_Daily]
		from AggCounter_Daily Agg
			inner join #RS RS on Agg.MonitorID=RS.MonitorID
			inner join TSDaily TS on Agg.TimespanID=TS.TimespanID
		where TS.DT < dateadd(mm,-RS.MaxMonthsDaily, getdate())

		set @CounterDailyCount = @@ROWCOUNT		
		end
	else
		begin
		delete
		from AggCounter_Daily
		from #RS RS, TSDaily TS
		where AggCounter_Daily.MonitorID=RS.MonitorID
			and AggCounter_Daily.TimespanID=TS.TimespanID
			and TS.DT < dateadd(mm,-RS.MaxMonthsDaily, getdate())

		select @Err=@@ERROR, @CounterDailyCount = @@ROWCOUNT
		if @Err<>0
			begin
			rollback tran
			set @StatusMonthlyCount = 0
			set @CounterMonthlyCount = 0
			set @StatusWeeklyCount = 0
			set @CounterWeeklyCount = 0
			set @StatusDailyCount = 0
			set @CounterDailyCount = 0
			set @StatusRawCount = 0
			set @CounterRawCount = 0
			set @ErrMsg = 'Error deleting from AggCounter_Daily.'
			if object_id('tempdb..#RS') is not null
				drop table #RS
			return -1
			end		
		end



	/****** Delete RawData, Counters ******/
	if @IsDebug=1
		begin
		print 'Deleting Counters - Raw...'
		select count(*) as [MonitorEventCounter] 
		from MonitorEventCounter with (index(IX_MonitorEvent_1))
			inner join #RS RS on MonitorEventCounter.MonitorID=RS.MonitorID
		where MonitorEventCounter.EventDT < dateadd(mm,-RS.MaxMonthsRaw, getdate())

		set @CounterRawCount = @@ROWCOUNT		
		end
	else
		begin
		delete
		from MonitorEventCounter
		from #RS RS
		where MonitorEventCounter.MonitorID=RS.MonitorID
			and MonitorEventCounter.EventDT < dateadd(mm,-RS.MaxMonthsRaw, getdate())

		select @Err=@@ERROR, @CounterRawCount = @@ROWCOUNT
		if @Err<>0
			begin
			rollback tran
			set @StatusMonthlyCount = 0
			set @CounterMonthlyCount = 0
			set @StatusWeeklyCount = 0
			set @CounterWeeklyCount = 0
			set @StatusDailyCount = 0
			set @CounterDailyCount = 0
			set @StatusRawCount = 0
			set @CounterRawCount = 0
			set @ErrMsg = 'Error deleting from MonitorEventCounter.'
			if object_id('tempdb..#RS') is not null
				drop table #RS
			return -1
			end		
		end


	/****** Delete RawData, Status ******/
	if @IsDebug=1
		begin
		print 'Deleting Status - Raw...'
		select count(*) as [MonitorEvent] 
		from MonitorEvent with (index(IX_MonitorEvent_1))
			inner join #RS RS on MonitorEvent.MonitorID=RS.MonitorID
		where MonitorEvent.EventDT < dateadd(mm,-RS.MaxMonthsRaw, getdate())

		set @StatusRawCount = @@ROWCOUNT		
		end
	else
		begin
		delete
		from MonitorEvent
		from #RS RS
		where MonitorEvent.MonitorID=RS.MonitorID
			and MonitorEvent.EventDT < dateadd(mm,-RS.MaxMonthsRaw, getdate())

		select @Err=@@ERROR, @StatusRawCount = @@ROWCOUNT
		if @Err<>0
			begin
			rollback tran
			set @StatusMonthlyCount = 0
			set @CounterMonthlyCount = 0
			set @StatusWeeklyCount = 0
			set @CounterWeeklyCount = 0
			set @StatusDailyCount = 0
			set @CounterDailyCount = 0
			set @StatusRawCount = 0
			set @CounterRawCount = 0
			set @ErrMsg = 'Error deleting from MonitorEvent.'
			if object_id('tempdb..#RS') is not null
				drop table #RS
			return -1
			end		
		end

	if @IsDebug=0
		begin
		commit tran

		set @Err=@@ERROR
		if @Err<>0
			begin
			rollback tran
			set @StatusMonthlyCount = 0
			set @CounterMonthlyCount = 0
			set @StatusWeeklyCount = 0
			set @CounterWeeklyCount = 0
			set @StatusDailyCount = 0
			set @CounterDailyCount = 0
			set @StatusRawCount = 0
			set @CounterRawCount = 0
			set @ErrMsg = 'Error committing transaction.'
			if object_id('tempdb..#RS') is not null
				drop table #RS
			return -1
			end
		end

	if object_id('tempdb..#RS') is not null
	drop table #RS
END




GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/23/2006
-- Description:	Returns last Status of specified Monitor
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_LastMonitorStatus] 
	@MonitorID int
AS
BEGIN
	SET NOCOUNT ON;


	Declare @CurrEventID int
	select @CurrEventID=EventID from MonitorCurrentStatus with(NOLOCK) where MonitorID=@MonitorID


if @CurrEventID is not NULL
begin
	select EventID,
		EventDT, 
		StatusID, 
		StatusMessage, 
		LifetimePercUptime
	from MonitorCurrentStatus with(NOLOCK)
	where MonitorID=@MonitorID

	select CounterName as [Counter], CounterValue as [Value]
	from MonitorEventCounter with(NOLOCK)
	where EventID=@CurrEventID
end


END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/9/2006
-- Description:	Returns a pivoted set of data containing all Counter values for specified Monitor and last N Days
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_HistMonitorCounters_NDays] 
	@MonitorID int, 
	@LastNDays int
AS
BEGIN
	SET NOCOUNT ON;

Declare @CounterNames as table (CounterName varchar(800))

insert into @CounterNames
select distinct CounterName from MonitorEventCounter where MonitorID = @MonitorID 

Declare @NumCounters int
select @NumCounters = count(*) from @CounterNames

if @NumCounters=0
	return 1


Declare @Select varchar(8000)
set @Select = 'select MonitorEventCounter.EventID, max(MonitorEventCounter.EventDT) as EventDT, '
set @select = @select + 'max(MonitorEvent.StatusID) as StatusID, '
set @select = @select + 'max(LookupEventStatus.Status) as Status, '

select @select = @select + 'sum(case when CounterName=''' + CounterName + ''' then CounterValue else NULL end) as [' + CounterName + '],'
from @CounterNames order by CounterName
set @select = substring(@select, 1, len(@select)-1) + ' '

set @select = @select + 'from MonitorEventCounter with (nolock, index(IX_MonitorEvent2)) inner join MonitorEvent with(NOLOCK) on MonitorEventCounter.EventID=MonitorEvent.EventID '
set @select = @select + 'inner join LookupEventStatus with(NOLOCK) on MonitorEvent.StatusID=LookupEventStatus.StatusID '
set @select = @select + 'where MonitorEventCounter.MonitorID=' + cast(@MonitorID as varchar(100)) + ' '
set @select = @select + 'and datediff(dd, MonitorEventCounter.EventDT, GetDate())<=' + cast(@LastNDays as varchar(100)) + ' '
set @select = @select + 'group by MonitorEventCounter.EventID '
set @select = @select + 'order by MonitorEventCounter.EventID desc'

EXEC(@select)


END








GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/14/2006
-- Description:	Returns a pivoted list of counter values for last N days averaged over specified time period increments for specified Monitor
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_HistMonitorCounters_Averages] 
	@MonitorID int, 
	@LastNDays int,
	@TPMinutes int
AS
BEGIN
	SET NOCOUNT ON;

    if object_id('tempdb..#TimePeriods') is not null
	drop table #TimePeriods

	if object_id('tempdb..#Averages') is not null
	drop table #Averages

	if object_id('tempdb..#Pivot') is not null
	drop table #Pivot

	Declare @CounterNames as table (CounterName varchar(800))

	insert into @CounterNames
	select distinct CounterName from MonitorEventCounter with(NOLOCK) where MonitorID = @MonitorID

	Declare @NumCounters int
	select @NumCounters = count(*) from @CounterNames

	if @NumCounters=0
	return 1

	create table #TimePeriods (TPNum int, TPStartDT datetime, TPEndDT datetime)

	Declare @StartDT datetime
	Declare @EndDT datetime

	set @EndDT = cast(convert(varchar(10), GetDate(), 120) + ' 23:59:59' as datetime)
	set @StartDT = cast(convert(varchar(10), dateadd(dd, -@LastNDays, @EndDT), 120) + ' 00:0:00' as datetime)

	Declare @NumPeriods int
	set @NumPeriods = datediff(mi,@StartDT, @EndDT)/@TPMinutes

	Declare @TPNum int
	set @TPNum = 0
	while @TPNum<=@NumPeriods
	begin
		set @TPNum = @TPNum+1
		insert into #TimePeriods (TPNum, TPStartDT, TPEndDT)
		values(@TPNum, 
			dateadd(mi, (@TPNum-1)*@TPMinutes, @StartDT),
			dateadd(mi, (@TPNum)*@TPMinutes, @StartDT))
	end

	--Create Averages over time periods
	create table #Averages(TPNum int, CounterName varchar(800), StartDT datetime, EndDT datetime, Average decimal(30,10), NumSamples int)
	
	insert into #Averages (TPNum, CounterName, StartDT, EndDT, Average, NumSamples)
	select TP.TPNum, 
		C.CounterName, 
		max(TP.TPStartDT) as StartDT, 
		max(TP.TPEndDT) as EndDT, 
		avg(CounterValue) as Average, 
		count(CounterValue) as NumSamples
	from  #TimePeriods TP 
		inner join MonitorEventCounter C with(NOLOCK)
			on C.EventDT >= TP.TPStartDT and C.EventDT<TP.TPEndDT
	where MonitorID=@MonitorID
	group by TP.TPNum, C.CounterName


	--Pivot data
	Declare @SQL varchar(8000)

	set @SQL = 'select convert(varchar(19), TP.TPStartDT, 120) as [Start DT], convert(varchar(19), TP.TPEndDT, 120) as [End DT], '
	set @SQL = @SQL + 'TP.TPStartDT as StartDT_Raw, TP.TPEndDT as EndDT_Raw, '
	select @SQL = @SQL + 'PV.[' + CounterName + ' (Avg)], ' + 'PV.[' + CounterName + ' (# Samples)],'
	from @CounterNames order by CounterName
	set @SQL = substring(@SQL, 1, len(@SQL)-1) + ' '

	set @SQL = @SQL + 'from #TimePeriods TP left outer join '

		set @SQL = @SQL + '(' + 'select TPNum, max(StartDT) as StartDT, max(EndDT) as EndDT, '
		select @SQL = @SQL + 'sum(case when CounterName=''' + CounterName + ''' then Average else NULL end) as [' + CounterName + ' (Avg)], '
			+ 'sum(case when CounterName=''' + CounterName + ''' then NumSamples else NULL end) as [' + CounterName + ' (# Samples)], '
		from @CounterNames order by CounterName

		set @SQL = substring(@SQL, 1, len(@SQL)-1) + ' '

		set @SQL = @SQL + 'from #Averages '
		set @SQL = @SQL + 'group by TPNum'

		set @SQL = @SQL + ') PV '

	set @SQL = @SQL + 'on TP.TPNum=PV.TPNum '

	--Only return rows that actually have some data (at least one sample)
	Declare @Where varchar(8000)
	set @Where = ''
	select @Where = @Where + '[' + CounterName + ' (# Samples)]' + '+'
	from @CounterNames order by CounterName
	set @Where = substring(@Where, 1, len(@Where)-1) + ' '
	set @SQL = @SQL + 'where ' + @Where + ' > 0 '

	set @SQL = @SQL + 'order by TP.TPNum desc'


	EXEC(@SQL)	


	if object_id('tempdb..#TimePeriods') is not null
	drop table #TimePeriods

	if object_id('tempdb..#Averages') is not null
	drop table #Averages

	if object_id('tempdb..#Pivot') is not null
	drop table #Pivot
END












GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/21/2007
-- Description:	Returns Raw Counter Data for specified Monitor and date range
-- =============================================
CREATE PROCEDURE [dbo].[rpt_CounterData_Raw] 
	@MonitorID int, 
	@StartDT datetime,
	@EndDT datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @CounterNames as table (CounterName varchar(800))

	insert into @CounterNames
	select distinct CounterName 
		from MonitorEventCounter with(NOLOCK)
		where MonitorID = @MonitorID
			and EventDT between @StartDT and @EndDT

	Declare @NumCounters int
	select @NumCounters = count(*) from @CounterNames

	if @NumCounters=0
	return 1

/*
Sample: Monitor contains two counters, AvgRTT and PercOK

select EventDT as DT_Raw,
		sum(case when CounterName = 'AvgRTT' then CounterValue else 0 end) as [AvgRTT],
		sum(case when CounterName = 'PercOK' then CounterValue else 0 end) as [PercOK]
from MonitorEventCounter
where MonitorID=34
and EventDT between '2/1/2007 10:00:00' and '2/1/2007 12:00:00'
group by EventDT
order by EventDT desc
*/

Declare @SQL varchar(8000)

	set @SQL = 'select EventDT as DT_Raw, convert(varchar(23), EventDT, 120) as DT_Display, '
	
	select @SQL = @SQL + 'sum(case when CounterName = ''' + CounterName + ''' then CounterValue else 0 end) as [' + CounterName + '],'
	from @CounterNames order by CounterName

	set @SQL = substring(@SQL, 1, len(@SQL)-1) + ' '

	set @SQL = @SQL + ' from MonitorEventCounter with (NOLOCK, index(IX_MonitorEvent2))'
	set @SQL = @SQL + ' where MonitorID = ' + cast(@MonitorID as varchar(10)) 
	set @SQL = @SQL + ' and EventDT between ''' + convert(varchar(19), @StartDT, 120) + ''' '
	set @SQL = @SQL + ' and ''' + convert(varchar(19), @EndDT, 120) + + ''' '
	set @SQL = @SQL + ' group by EventDT order by EventDT desc'

	EXEC(@SQL)	


END










GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/14/2006
-- Description:	Returns a pivoted list of counter values for last N days averaged over specified time period increments for specified Monitor
-- =============================================
CREATE PROCEDURE [dbo].[rpt_CounterData_CustomAverage] 
	@MonitorID int, 
	@StartDT datetime,
	@EndDT datetime,
	@TPMinutes int
AS
BEGIN
	SET NOCOUNT ON;

    if object_id('tempdb..#TimePeriods') is not null
	drop table #TimePeriods

	if object_id('tempdb..#Averages') is not null
	drop table #Averages

	if object_id('tempdb..#Pivot') is not null
	drop table #Pivot

	Declare @CounterNames as table (CounterName varchar(800))

	insert into @CounterNames
	select distinct CounterName from MonitorEventCounter with(NOLOCK) where MonitorID = @MonitorID

	Declare @NumCounters int
	select @NumCounters = count(*) from @CounterNames

	if @NumCounters=0
	return 1

	create table #TimePeriods (TPNum int, TPStartDT datetime, TPEndDT datetime)

	Declare @NumPeriods int
	set @NumPeriods = datediff(mi,@StartDT, @EndDT)/@TPMinutes

	if @NumPeriods<=0
		return 1

	Declare @TPNum int
	set @TPNum = 0
	while @TPNum<=@NumPeriods
	begin
		set @TPNum = @TPNum+1
		insert into #TimePeriods (TPNum, TPStartDT, TPEndDT)
		values(@TPNum, 
			dateadd(mi, (@TPNum-1)*@TPMinutes, @StartDT),
			dateadd(mi, (@TPNum)*@TPMinutes, @StartDT))
	end

	--Create Averages over time periods
	create table #Averages(TPNum int, CounterName varchar(800), StartDT datetime, EndDT datetime, Average decimal(30,10), NumSamples int)
	
	insert into #Averages (TPNum, CounterName, StartDT, EndDT, Average, NumSamples)
	select TP.TPNum, 
		C.CounterName, 
		max(TP.TPStartDT) as StartDT, 
		max(TP.TPEndDT) as EndDT, 
		avg(CounterValue) as Average, 
		count(CounterValue) as NumSamples
	from  #TimePeriods TP 
		inner join MonitorEventCounter C with(NOLOCK)
			on C.EventDT >= TP.TPStartDT and C.EventDT<TP.TPEndDT
	where MonitorID=@MonitorID
	group by TP.TPNum, C.CounterName


	--Pivot data
	Declare @SQL varchar(8000)

	set @SQL = 'select convert(varchar(19), TP.TPStartDT, 120) as [StartDT_Display], convert(varchar(19), TP.TPEndDT, 120) as [EndDT_Display], '
	set @SQL = @SQL + 'TP.TPStartDT as StartDT_Raw, TP.TPEndDT as EndDT_Raw, '
	select @SQL = @SQL + 'PV.[' + CounterName + ' (Avg)], ' + 'PV.[' + CounterName + ' (# Samples)],'
	from @CounterNames order by CounterName
	set @SQL = substring(@SQL, 1, len(@SQL)-1) + ' '

	set @SQL = @SQL + 'from #TimePeriods TP left outer join '

		set @SQL = @SQL + '(' + 'select TPNum, max(StartDT) as StartDT, max(EndDT) as EndDT, '
		select @SQL = @SQL + 'sum(case when CounterName=''' + CounterName + ''' then Average else NULL end) as [' + CounterName + ' (Avg)], '
			+ 'sum(case when CounterName=''' + CounterName + ''' then NumSamples else NULL end) as [' + CounterName + ' (# Samples)], '
		from @CounterNames order by CounterName

		set @SQL = substring(@SQL, 1, len(@SQL)-1) + ' '

		set @SQL = @SQL + 'from #Averages '
		set @SQL = @SQL + 'group by TPNum'

		set @SQL = @SQL + ') PV '

	set @SQL = @SQL + 'on TP.TPNum=PV.TPNum '

	--Only return rows that actually have some data (at least one sample)
	Declare @Where varchar(8000)
	set @Where = ''
	select @Where = @Where + '[' + CounterName + ' (# Samples)]' + '+'
	from @CounterNames order by CounterName
	set @Where = substring(@Where, 1, len(@Where)-1) + ' '
	set @SQL = @SQL + 'where ' + @Where + ' > 0 '

	set @SQL = @SQL + 'order by TP.TPStartDT desc'


	EXEC(@SQL)	


	if object_id('tempdb..#TimePeriods') is not null
	drop table #TimePeriods

	if object_id('tempdb..#Averages') is not null
	drop table #Averages

	if object_id('tempdb..#Pivot') is not null
	drop table #Pivot
END















GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/23/2006
-- Description:	Returns a single Dashboard Group
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_DashboardGroup] 
	@GroupID int
AS
BEGIN
	SET NOCOUNT ON;

	select * from DashboardGroupDefault with(NOLOCK) where GroupID=@GroupID
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/14/2006
-- Description:	Returns all dashboard groups
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_DashboardGroups] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * 
	from DashboardGroupDefault with(NOLOCK)
	order by DisplayOrder, Name
END



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/22/2006
-- Description:	Deletes (cascaded) an existing Dashboard Group
-- =============================================
CREATE PROCEDURE [dbo].[polymon_del_DeleteDashboardGroup] 
	@GroupID int 
AS
BEGIN
	SET NOCOUNT ON;

	delete from DashboardGroupDefault
	where GroupID=@GroupID
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/22/2006
-- Description:	Creates/Updates a DashboardGroup record
-- =============================================
CREATE PROCEDURE [dbo].[polymon_hyb_SaveDashboardGroup] 
	-- Add the parameters for the stored procedure here
	@GroupID int output, 
	@Name varchar(100),
	@DisplayOrder int
AS
BEGIN
	SET NOCOUNT ON;
	Declare @IsNew bit
	set @IsNew = 0

	if @GroupID is NULL
		set @IsNew=1

	if @IsNew=0 and not(exists(select * from DashboardGroupDefault where GroupID=@GroupID))
	begin
		raiserror('Specified Dashboard Group does not exist.', 16, 1)
		return -1
	end

	if @IsNew=0
	begin
		update DashboardGroupDefault
		set Name=@Name,
			DisplayOrder=@DisplayOrder
		where GroupID=@GroupID
	end
	else
	begin
		insert into DashboardGroupDefault (Name, DisplayOrder)
		values (@Name, @DisplayOrder)
		set @GroupID=@@IDENTITY
	end
END



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/22/2006
-- Description:	Creates/Updates a Dashboard Group Panel record
-- =============================================
CREATE PROCEDURE [dbo].[polymon_hyb_SaveDashboardPanel] 
	-- Add the parameters for the stored procedure here
	@PanelID int output, 
	@GroupID int,
	@MonitorID int,
	@DisplayOrder int
AS
BEGIN
	SET NOCOUNT ON;

	Declare @IsNew bit
	set @IsNew=0

	if @PanelID is NULL
		set @IsNew=1

	if @IsNew=0 and not(exists(select * from DashboardGroupMonitorDefault where PanelID=@PanelID))
	begin
		raiserror('Specified PanelID does not exist.', 16, 1)
		return -1
	end

	if not(exists(select * from DashboardGroupDefault where GroupID=@GroupID))
	begin
		raiserror('Specified GroupID does not exist.', 16, 1)
		return -1
	end

	if not(exists(select * from Monitor where MonitorID=@MonitorID))
	begin
		raiserror('Specified MonitorID does not exist.', 16, 1)
		return -1
	end

	if @IsNew=0
	begin
		--Update
		update DashboardGroupMonitorDefault
		set GroupID=@GroupID,
			MonitorID=@MonitorID,
			DisplayOrder=@DisplayOrder
		where PanelID=@PanelID
	end
	else
	begin
		--Insert
		insert into DashboardGroupMonitorDefault (GroupID, MonitorID, DisplayOrder)
		values (@GroupID, @MonitorID, @DisplayOrder)

		set @PanelID=@@IDENTITY
	end
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[polymon_ins_GenerateAlert]
@EventID int
AS

/*
===================================================================
Procedure Name: polymon_ins_GenerateAlert
Author: Fred Baptiste
Create Date: Creates MonitorAlert and OperatorAlert records for specified Event
Purpose:  
Parameters: 
	
Output:  
Notes:
The following substitution merge codes are supported:
<%Monitor%>
<%MonitorType%>
<%Status%>
<%StatusID%>
<%EventMessage%>
<%EventDT%>
===================================================================
Revision History:


===================================================================
*/

set nocount on

if exists(select * from MonitorAlert where EventID=@EventID)
begin
	--This Event has already been alerted, ignore request
	return -1
end

Declare @AlertID int

if not(exists(select * from MonitorEvent where EventID=@EventID))
begin
	raiserror('Invalid Event ID.', 16, 1)
	return -1
end

Declare @MonitorID int, @StatusID tinyint, @EventDT datetime, @DispEventDT varchar(25), @StatusMessage nvarchar(1000)
Declare @MonitorName varchar(50), @SubjectTemplate nvarchar(100), @BodyTemplate nvarchar(3000)
Declare @MonitorType varchar(50)

Declare @Status varchar(50)

select @MonitorID=MonitorID, @StatusID=StatusID, @EventDT=EventDT, @StatusMessage=StatusMessage
from MonitorEvent
where EventID=@EventID

set @DispEventDT= ltrim(rtrim(convert(varchar(11), @EventDT, 100))) + ' ' + convert(varchar(8), @EventDT, 108)

select @MonitorName=Monitor.Name, 
	@SubjectTemplate=MessageSubjectTemplate, 
	@BodyTemplate=MessageBodyTemplate,
	@MonitorType=MonitorType.Name
from Monitor
	inner join MonitorType on Monitor.MonitorTypeID=MonitorType.MonitorTypeID
where MonitorID=@MonitorID

select @Status=Status
from LookupEventStatus
where StatusID=@StatusID

Declare @MessageSubject nvarchar(255)
Declare @MessageBody nvarchar(3500)

/*Substitutions*/
set @MessageSubject=@SubjectTemplate
set @MessageSubject = replace(@MessageSubject, '<%Monitor%>', @MonitorName)
set @MessageSubject = replace(@MessageSubject, '<%Status%>', @Status)
set @MessageSubject = replace(@MessageSubject, '<%StatusID%>', cast(@StatusID as varchar(10)))
set @MessageSubject = replace(@MessageSubject, '<%EventDT%>', @DispEventDT )
set @MessageSubject = replace(@MessageSubject, '<%MonitorType%>', @MonitorType )

set @MessageBody=@BodyTemplate
set @MessageBody = replace(@MessageBody, '<%Monitor%>', @MonitorName)
set @MessageBody = replace(@MessageBody, '<%Status%>', @Status)
set @MessageBody = replace(@MessageBody, '<%StatusID%>', cast(@StatusID as varchar(10)))
set @MessageBody=replace(@MessageBody, '<%EventMessage%>', @StatusMessage)
set @MessageBody = replace(@MessageBody, '<%EventDT%>', @DispEventDT )
set @MessageBody = replace(@MessageBody, '<%MonitorType%>', @MonitorType )

insert into MonitorAlert (EventID, MonitorID, EventDT, StatusID, MessageSubject, MessageBody)
values(@EventID, @MonitorID, @EventDT, @StatusID, @MessageSubject, @MessageBody)

set @AlertID=@@IDENTITY

--and lastly assign this alert to any operator defined for this alert that is enabled
insert into OperatorAlert (AlertID, OperatorID, IsSent, SentDT)
select @AlertID, Operator.OperatorID, 0, NULL
from Operator
	inner join MonitorOperator on Operator.OperatorID=MonitorOperator.OperatorID
	left outer join OperatorAlert on OperatorAlert.AlertID=@AlertID and Operator.OperatorID=OperatorAlert.OperatorID
where MonitorOperator.MonitorID=@MonitorID
and Operator.IsEnabled=1
and OperatorAlert.AlertID is NULL



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[polymon_sel_MonitorType] 
@MonitorTypeID int
AS

/*
===================================================================
Procedure Name: polymon_sel_MonitorType
Author: Fred Baptiste
Create Date: 10/28/2005
Purpose:  
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

select * from MonitorType with(NOLOCK)
where MonitorTypeID=@MonitorTypeID

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[polymon_sel_MonitorTypeMetadata]
@MonitorTypeID int
AS

/*
===================================================================
Procedure Name: polymon_sel_MonitorTypeMetadata
Author: Fred Baptiste
Create Date: 10/27/2005
Purpose:  
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

select * from MonitorType with(NOLOCK)
where MonitorTypeID=@MonitorTypeID

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[polymon_sel_MonitorTypes]

AS

/*
===================================================================
Procedure Name: polymon_sel_MonitorTypes
Author: Fred Baptiste
Create Date: 10/28/2005
Purpose:  
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

select * from MonitorType with(NOLOCK)
order by Name


GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[polymon_hyb_SaveMonitorType]
@MonitorTypeID int output,
@Name varchar(50),
@MonitorAssembly varchar(100),
@EditorAssembly varchar(100),
@MonitorXMLTemplate ntext
AS

/*
===================================================================
Procedure Name: polymon_hyb_SaveMonitorType
Author: Fred Baptiste
Create Date: 10/28/2005
Purpose:  
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

Declare @IsNew bit

if @MonitorTypeID is NULL or @MonitorTypeID=-1
	set @IsNew=1
else
begin
	if exists(select * from MonitorType where MonitorTypeID=@MonitorTypeID)
		set @IsNew=0
	else
		set @IsNew=1
end

if @IsNew=0
begin
	update MonitorType
	set Name=@Name,
		MonitorAssembly=@MonitorAssembly,
		EditorAssembly=@EditorAssembly,
		MonitorXMLTemplate=@MonitorXMLTemplate
	where MonitorTypeID=@MonitorTypeID
end
else
begin
	insert into MonitorType (Name, MonitorAssembly, EditorAssembly, MonitorXMLTemplate)
	values(@Name, @MonitorAssembly, @EditorAssembly, @MonitorXMLTemplate)

	set @MonitorTypeID=@@IDENTITY
end
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[polymon_del_DeleteMonitorType]
@MonitorTypeID int
AS

/*
===================================================================
Procedure Name: polymon_del_DeleteMonitorType
Author: Fred Baptiste
Create Date: 10/28/2005
Purpose:  
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

delete from MonitorType where MonitorTypeID=@MonitorTypeID
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/23/2006
-- Description:	Returns a single Dashboard Panel
-- =============================================
CREATE PROCEDURE [dbo].[polymon_ins_DashBoardPanel] 
	@PanelID int
AS
BEGIN
	SET NOCOUNT ON;

	select * from DashboardGroupMonitorDefault
	where PanelID=@PanelID
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/22/2006
-- Description:	Deletes an existing Dashbiard Group Panel Record
-- =============================================
CREATE PROCEDURE [dbo].[polymon_del_DeleteDashboardPanel] 
	-- Add the parameters for the stored procedure here
	@PanelID int
AS
BEGIN
	SET NOCOUNT ON;

	delete from DashboardGroupMonitorDefault
	where PanelID=@PanelID
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[polymon_sel_MonitorOperators]
@MonitorID int
AS

/*
===================================================================
Procedure Name: polymon_sel_MonitorOperators
Author: Fred Baptiste
Create Date: 10/26/2005
Purpose:  Retrieves a list of all operators attached to a specified Monitor
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

select Operator.*
from Operator  with(NOLOCK)
	inner join MonitorOperator with(NOLOCK)
		on Operator.OperatorID=MonitorOperator.OperatorID
where MonitorOperator.MonitorID=@MonitorID
order by Name

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[polymon_sel_Operator]
@OperatorID int
AS

/*
===================================================================
Procedure Name: polymon_sel_Operator
Author: Fred Baptiste	
Create Date: 10/26/2005
Purpose:  Retrieves Operator metadata
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

select *
from Operator with(NOLOCK)
where OperatorID=@OperatorID

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[polymon_hyb_SaveOperator]
@OperatorID int output,
@Name nvarchar(255),
@IsEnabled bit,
@EmailAddress varchar(255),
@OfflineTimeStart char(5),
@OfflineTimeEnd char(5),
@IncludeMessageBody bit
AS

/*
===================================================================
Procedure Name: polymon_hyb_SaveOperator
Author: Fred Baptiste
Create Date: 10/26/2005
Purpose:  Creates/Updates an operator record.
Parameters: 
	
Output:  
Notes:
If @OperatorID is NULL, a new record will be created.
If @OperatorID is specified and it does not exist in the database, an error will be raised.
===================================================================
Revision History:


===================================================================
*/
set nocount on

if @OperatorID is NULL
begin
	--Create new Operator Record
	insert into Operator (Name, IsEnabled, EmailAddress, OfflineTimeStart, OfflineTimeEnd, IncludeMessageBody)
	values (@Name, @IsEnabled, @EmailAddress, @OfflineTimeStart, @OfflineTimeEnd, @IncludeMessageBody)

	set @OperatorID=@@IDENTITY
end
else
begin
	--Update existing Operator Record
	if not(exists(select * from Operator where OperatorID=@OperatorID))
	begin
		--Invalid OperatorID
		raiserror('Specified OperatorID does not exist. Action aborted.', 16, 1)
	end
	else
	begin	
		--Valid OperatorID
		update Operator
		set Name=@Name,
			IsEnabled=@IsEnabled,
			EmailAddress=@EmailAddress,
			OfflineTimeStart=@OfflineTimeStart,
			OfflineTimeEnd=@OfflineTimeEnd,
			IncludeMessageBody=@IncludeMessageBody
		where OperatorID=@OperatorID
	end
end
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[polymon_del_DeleteOperator] 
@OperatorID int
AS

/*
===================================================================
Procedure Name: polymon_del_DeleteOperator
Author: Fred Baptiste
Create Date: 10/26/2005
Purpose:  Deletes an existing Operator.
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

delete from Operator
where OperatorID=@OperatorID 

--other referenced tables are taken care of by cascaded deletes.
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/14/2007
-- Description:	Returns a list of email alerts that need to be sent
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_PendingEmailAlerts] 
@MaxCount int = 100
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SET ROWCOUNT @MaxCount

	select MonitorAlert.AlertID,
		Operator.OperatorID,
		Operator.Name,
		Operator.EmailAddress,
		Operator.IncludeMessageBody,
		MonitorAlert.MessageSubject,
		MonitorAlert.MessageBody
	from MonitorAlert with(NOLOCK)
		inner join OperatorAlert with(NOLOCK) on MonitorAlert.AlertID=OperatorAlert.AlertID
		inner join Operator with(NOLOCK) on OperatorAlert.OperatorID=Operator.OperatorID
	where OperatorAlert.IsSent=0
		and Operator.IsEnabled=1
		and dbo.fn_IsOfflineTime(Operator.OfflineTimeStart, Operator.OfflineTimeEnd, getdate())=0
	order by MonitorAlert.EventDT

SET ROWCOUNT 0
END



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[polymon_sel_Operators]
AS
BEGIN
/*
===================================================================
Procedure Name: polymon_sel_MonitorTypes
Author: Fred Baptiste
Create Date: 10/28/2005
Purpose:  
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
	SET NOCOUNT ON;

  select * from Operator with(NOLOCK)
END


GO





-- =============================================
-- Author:		Fred Baptiste
-- Create date: 3/7/2006
-- Description:	Returns Last N Days of specified Monitor Events
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_HistMonitorEvents_NDays] 
	@MonitorID int, 
	@LastNDays int
AS
BEGIN
	SET NOCOUNT ON;

	select MonitorID, 
		EventID, 
		EventDT, 
		MonitorEvent.StatusID, 
		LookupEventStatus.Status, 
		StatusMessage,
		datediff(dd, EventDT, GetDate()) as DaysAgo
	from MonitorEvent  with (NOLOCK, index(IX_MonitorEvent_2))
		inner join LookupEventStatus with(NOLOCK) on MonitorEvent.StatusID=LookupEventStatus.StatusID
	where MonitorID = @MonitorID
		and datediff(dd, EventDT, GetDate())<=@LastNDays
	order by EventID desc
END





GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Fred Baptiste
-- Create date: 6/8/2006
-- Description:	Returns Current StatusID for specified Monitor
-- =============================================
CREATE FUNCTION [dbo].[fn_MonitorCurrentStatusID] 
(
	-- Add the parameters for the function here
	@MonitorID int
)
RETURNS tinyint
AS
BEGIN
	DECLARE @Result tinyint


	Declare @LastEventID int

	select @LastEventID = max(EventID)
	from MonitorEvent
	where MonitorID=@MonitorID

	select @Result = MonitorEvent.StatusID
	from MonitorEvent with(NOLOCK)
	where MonitorEvent.EventID = @LastEventID

	-- Return the result of the function
	RETURN @Result

END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Fred Baptiste
-- Create date: 10/5/2006
-- Description:	Calculates % uptime for specified Monitor and timeframe
-- =============================================
CREATE FUNCTION [dbo].[fn_PercUptime] 
(
	-- Add the parameters for the function here
	@MonitorID int,
	@StartDT datetime,
	@EndDT datetime
)
RETURNS decimal(6,3)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result decimal(6,3)

	select 	@Result = case
			when sum(abs(UpDownTimeSecs))=0 then
				0
			else
				cast(100*(1-cast((sum(abs(UpDownTimeSecs))-sum(UpDownTimeSecs))/2 as float) / cast(sum(abs(UpDownTimeSecs)) as float)) as decimal(6,3))
			end
	from MonitorEvent with(NOLOCK)
	where MonitorID=@MonitorID
	and EventDT between @StartDT and @EndDT
	
	return coalesce(@Result,0)
END




GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Fred Baptiste
-- Create date: 10/5/2006
-- Description:	Returns DT of previous event
-- =============================================
CREATE FUNCTION [dbo].[fn_PrevEventDT] 
(
	-- Add the parameters for the function here
	@MonitorID int,
	@CurrEventID int
)
RETURNS datetime
AS
BEGIN
	Declare @PrevEventID int

	select @PrevEventID=max(EventID) from MonitorEvent with(NOLOCK) where MonitorID=@MonitorID and EventID<@CurrEventID

	Declare @PrevDT datetime
	select @PrevDT = EventDT from MonitorEvent  with(NOLOCK) where EventID=@PrevEventID

	-- Return the result of the function
	RETURN @PrevDT

END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/21/2007
-- Description:	Status Summary Information for specified Monitor and time frame
-- =============================================
CREATE PROCEDURE [dbo].[rpt_StatusSummary_Raw] 
	@MonitorID int,
	@StartDT datetime,
	@EndDT datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @LifeTimePercUptime as decimal(6,3)
	select @LifetimePercUptime = LifetimePercUptime from MonitorCurrentStatus with(NOLOCK) where MonitorID=@MonitorID

	Declare @NumOK int
	Declare @NumWarnings int
	Declare @NumFailures int
	Declare @UpTime int
	Declare @DownTime int
	Declare @PercUpTime decimal(6,3)

    select 
		@NumOK = sum(case when StatusID=1 then 1 else 0 end),
		@NumWarnings = sum(case when StatusID=2 then 1 else 0 end),
		@NumFailures = sum(case when StatusID=3 then 1 else 0 end),
		@UpTime = sum(case when UpDownTimeSecs > 0 then UpDownTimeSecs else 0 end),
		@DownTime = sum(case when UpDownTimeSecs < 0 then abs(UpDownTimeSecs) else 0 end)
	from MonitorEvent with(NOLOCK)
	where MonitorID=@MonitorID
	and EventDT between @StartDT and @EndDT

	if @UpTime + @DownTime = 0
		set @PercUpTime = 0
	else
		set @PercUpTime = cast(round((100 * cast(@UpTime as decimal(10,3)) / (cast(@UpTime as decimal(10,3)) + cast(@DownTime as decimal(10,3)))),3) as decimal(6,3))

	select @NumOK as OKCount,
			@NumWarnings as WarningCount,
			@NumFailures as FailureCount,
			@UpTime as TotalUpTime,
			@DownTime as TotalDownTime,
			@PercUpTime as PercUpTime,
			@LifetimePercUptime as LifetimePercUpTime	
END




GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/21/2007
-- Description:	Returns Raw historical Status data for specified MonitorID
-- =============================================
CREATE PROCEDURE [dbo].[rpt_StatusData_Raw] 
	@MonitorID int, 
	@StartDT datetime,
	@EndDT datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select	EventDT as DT_Raw,
			convert(varchar(23), EventDT, 120)  as DT_Display,
			case when StatusID= 1 then 1 else 0 end as IsOK, 
			case when StatusID= 2 then 1 else 0 end as IsWarning, 
			case when StatusID= 3 then 1 else 0 end as IsFailure, 
			case when UpDownTimeSecs >0 then UpDownTimesecs else 0 end as UpTime, 
			case when UpDownTimeSecs <0 then abs(UpDownTimeSecs) else 0 end as DownTime
	from MonitorEvent with(NOLOCK)
	where MonitorID=@MonitorID and EventDT between @StartDT and @EndDT
	order by EventDT desc
END














GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/14/2007
-- Description:	Marks an email as sent
-- =============================================
CREATE PROCEDURE [dbo].[polymon_hyb_MarkEmailSent] 
	@AlertID int, 
	@OperatorID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if exists(select * from OperatorAlert where AlertID=@AlertID and OperatorID=@OperatorID)
		begin
			update OperatorAlert
			set IsSent = 1, SentDT = getdate()
			where AlertID=@AlertID and OperatorID=@OperatorID
		end
		else
		begin
			insert into OperatorAlert (AlertID, OperatorID, IsSent, SentDT)
			values (@AlertID, @OperatorID, 1, getdate())
		end
END

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[polymon_ins_AssignMonitorOperator] 
@MonitorID int,
@OperatorID int,
@WasCreated bit output
AS

/*
===================================================================
Procedure Name: polymon_ins_AssignMonitorOperator
Author: Fred Baptiste
Create Date: 10/26/2005
Purpose:  Assigns an Operator to a Monitor.
Parameters: 
	@WasCreated will return 1 if the operator was newly assigned to the monitor,
	returns 0 if the Operator was already assigned to the monitor
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

Declare @Err int

set @WasCreated = 0
if not exists(select * from MonitorOperator where MonitorID=@MonitorID and OperatorID=@OperatorID)
begin
	insert into MonitorOperator (MonitorID, OperatorID) values (@MonitorID, @OperatorID)
	set @Err=@@ERROR
	if @Err=0
		set @WasCreated = 1
end
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[polymon_del_RemoveMonitorOperator]
@MonitorID int,
@OperatorID int,
@WasRemoved bit output
AS

/*
===================================================================
Procedure Name: polymon_del_RemoveMonitorOperator
Author: Fred Baptiste
Create Date: 10/26/2005
Purpose:  Removes an assigned operator from a monitor
Parameters: 
@WasRemoved indicates if this operator was removed from the list or not
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

Declare @Err int

set @WasRemoved = 0

if exists(select * from MonitorOperator where MonitorID=@MonitorID and OperatorID=@OperatorID)
begin
	delete from MonitorOperator
	where MonitorID=@MonitorID and OperatorID=@OperatorID
	set @Err=@@ERROR
	if @Err=0
		set @WasRemoved=1
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Fred Baptiste
-- Create date: 6/8/2006
-- Description:	Returns Current Status of specified Monitor
-- =============================================
CREATE FUNCTION [dbo].[fn_MonitorCurrentStatus] 
(
	-- Add the parameters for the function here
	@MonitorID int
)
RETURNS varchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(50)

/*
	Declare @LastEventID int

	select @LastEventID = max(EventID)
	from MonitorEvent
	where MonitorID=@MonitorID

	select @Result = LookupEventStatus.Status
	from MonitorEvent with(NOLOCK)
		inner join LookupEventStatus with(NOLOCK) on MonitorEvent.StatusID=LookupEventStatus.StatusID
	where MonitorEvent.EventID = @LastEventID
*/

	Declare @StatusID int
	select @StatusID = StatusID
	from MonitorCurrentStatus
	where MonitorID=@MonitorID

	if @StatusID is null
		begin
		set @Result='Unknown'
		end
	else
		begin
		select @Result = LookupEventStatus.Status
		from LookupEventStatus
		where StatusID=@StatusID
		end

	-- Return the result of the function
	RETURN @Result

END




GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:		Fred Baptiste
-- Create date: 6/8/2006
-- Description:	Returns a list of monitor events for specified time period and specified Statuses
-- =============================================
CREATE PROCEDURE [dbo].[polymon_sel_EventHistory] 
	@InclOK bit,
	@InclWarning bit,
	@InclFail bit,
	@StartDate datetime,
	@EndDate datetime
AS
BEGIN
	
	SET NOCOUNT ON;

Declare @IsOK tinyint
Declare @IsWarning tinyint
Declare @IsFail tinyint
Declare @DateLo datetime
Declare @DateHi datetime

if @InclOK=1
	set @IsOK=1
else
	set @IsOK=NULL

if @InclWarning=1
	set @IsWarning=2
else
	set @IsWarning=NULL

if @InclFail=1
	set @IsFail=3
else
	set @IsFail=NULL


set @DateLo = cast(convert(varchar(10), @StartDate, 120) + ' 00:00:00' as datetime)
set @DateHi = cast(convert(varchar(10), @EndDate, 120) + ' 23:59:59' as datetime)


Declare @tmp table (MonitorID int, CurrentStatus varchar(50), PercUptime dec(6,3))


insert into @tmp (MonitorID)
select distinct MonitorID
from MonitorEvent with (index(IX_MonitorEvent_3))
where EventDT between @DateLo and @DateHi 
	and StatusID in (@IsOK, @IsWarning, @IsFail)

update @tmp
set CurrentStatus = dbo.fn_MonitorCurrentStatus(MonitorID),
	PercUptime = dbo.fn_PercUptime(MonitorID, @DateLo, @DateHi)



select
	MonitorEvent.MonitorID,
	MonitorEvent.EventID,
	convert(varchar(50), MonitorEvent.EventDT, 120) as EventDT,
	Monitor.Name as Monitor,
	MonitorType.Name as MonitorType,
	MonitorEvent.StatusID, 
--	dbo.fn_MonitorCurrentStatus(MonitorEvent.MonitorID) as CurrentStatus,
T.CurrentStatus as CurrentStatus,
	LookupEventStatus.Status,
	MonitorEvent.StatusMessage,
--	dbo.fn_PercUptime(MonitorEvent.MonitorID, @DateLo, @DateHi) as [% Uptime]
T.PercUptime as [% Uptime]
from MonitorEvent with(NOLOCK)
		inner join Monitor on MonitorEvent.MonitorID=Monitor.MonitorID
		inner join MonitorType on Monitor.MonitorTypeID=MonitorType.MonitorTypeID
		inner join LookupEventStatus with(NOLOCK) on MonitorEvent.StatusID=LookupEventStatus.StatusID
		inner join @tmp T on T.MonitorID=MonitorEvent.MonitorID
where 	MonitorEvent.StatusID in (@IsOK, @IsWarning, @IsFail)
and MonitorEvent.EventDT >= @DateLo and MonitorEvent.EventDT <= @DateHi
order by MonitorEvent.EventDT--, Monitor.Name

END









GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[polymon_ins_EvaluateEventAlertStatus]
@CurrentEventID int
AS

/*
===================================================================
Procedure Name: polymon_ins_EvaluateEventAlertStatus
Author: Fred Baptiste
Create Date: 10/31/2005
Purpose:  Generates an alert (based on alert rules) for a specific new event
Parameters: 
	
Output:  
Notes:
===================================================================
Revision History:


===================================================================
*/

set nocount on

if exists(select * from MonitorAlert where EventID=@CurrentEventID)
begin
	--This event has already been alerted, ignore this request
	return -1
end

Declare @MonitorID int
Declare @CurrentStatusID tinyint --1=OK, 2=Warning, 3=Fail
select @MonitorID =MonitorID, 
	@CurrentStatusID=StatusID 
from MonitorEvent where EventID=@CurrentEventID

if @MonitorID is NULL or @CurrentStatusID is NULL
begin
	raiserror('Invalid CurrentEventID.', 16, 1)
	return 0
end


Declare @EveryNewFailure bit
Declare @EveryFailToOK bit
Declare @EveryNewWarning bit
Declare @EveryWarnToOK bit

Declare @EveryNEvent int
Declare @EveryNFailures int
Declare @EveryNWarnings int

select @EveryNewFailure=AlertAfterEveryNewFailure,
	@EveryFailToOK = AlertAfterEveryFailToOK,
	@EveryNewWarning = AlertAfterEveryNewWarning,
	@EveryWarnToOK = AlertAfterEveryWarnToOK,
	@EveryNEvent = AlertAfterEveryNEvent,
	@EveryNFailures = AlertAfterEveryNFailures,
	@EveryNWarnings = AlertAfterEveryNWarnings
from MonitorAlertRule
where MonitorID = @MonitorID


--Determine last Alert EventID
Declare @LastAlertEventID int
Declare @LastAlertEventDT as datetime
Declare @LastAlertEventStatusID tinyint
/*
select top 1 @LastAlertEventID = MonitorAlert.EventID
from MonitorEvent
	inner join MonitorAlert on MonitorEvent.EventID=MonitorAlert.EventID
where MonitorEvent.MonitorID=@MonitorID
order by MonitorEvent.EventDT desc
*/
select top 1 @LastAlertEventID=EventID
from MonitorAlert
where MonitorID=@MonitorID
order by EventDT desc

--If Monitor never generated an alert, @LastAlertEventID will be NULL
if not(@LastAlertEventID is NULL)
	select @LastAlertEventDT = EventDT, @LastAlertEventStatusID=StatusID
	from MonitorEvent
	where EventID=@LastAlertEventID
else
begin
	set @LastAlertEventDT = cast('1950-01-01' as datetime)
	set @LastAlertEventStatusID = 0
end

Declare @IsAlerted bit
set @IsAlerted=0

--Alert After Every New Failure
if (@IsAlerted=0) and (@CurrentStatusID=3) and (@EveryNewFailure=1) and (@LastAlertEventStatusID<>3)
begin
	-- Alert New Failure
	print 'New Failure'
	exec polymon_ins_GenerateAlert @CurrentEventID
	set @IsAlerted=1
end

--Alert After Every Fail to OK
if (@IsAlerted=0) and (@CurrentStatusID=1) and (@EveryFailToOK=1) and (@LastAlertEventStatusID=3)
begin
	-- Alert Fail-->OK
	print 'Fail to OK'
	exec polymon_ins_GenerateAlert @CurrentEventID
	set @IsAlerted=1
end

--Alert After Every New Warning
if (@IsAlerted=0) and (@CurrentStatusID=2) and (@EveryNewWarning=1) and (@LastAlertEventStatusID<>2)
begin
	-- Alert New Warning
	print 'New Warning'
	exec polymon_ins_GenerateAlert @CurrentEventID
	set @IsAlerted=1
end

--Alert After Every Warn to OK
if (@IsAlerted=0) and (@CurrentStatusID=1) and (@EveryWarnToOK=1) and (@LastAlertEventStatusID=2)
begin
	-- Alert Warn-->OK
	print 'Warn to OK'
	exec polymon_ins_GenerateAlert @CurrentEventID
	set @IsAlerted=1
end

--Alert After Every N Event
if (@IsAlerted=0) and (@EveryNEvent>0)
begin
	--Count number of events since last alert
	Declare @NumEvents int
	select @NumEvents = count(EventID)
	from MonitorEvent
	where MonitorID=@MonitorID
	and EventID<>@CurrentEventID
	and EventDT > @LastAlertEventDT

	if @NumEvents>=@EveryNEvent
	begin
		-- Alert Every N Event(s)
		print 'Every N Event'
		select @NumEvents, @MonitorID, @CurrentEventID, @LastAlertEventDT
		exec polymon_ins_GenerateAlert @CurrentEventID
		set @IsAlerted=1
	end
end


Declare @RowCount int, @NumNonFails int, @NumNonWarns int
Declare @SQL nvarchar(4000)
create table #Events (EventID int, EventDT datetime, StatusID tinyint)

--Alert After Every N Failures
if (@IsAlerted=0) and (@EveryNFailures>0)
begin
	set @SQL= 'insert into #Events (EventID, EventDT, StatusID) '
		+ 'select top ' + cast(@EveryNFailures as varchar(10)) + ' EventID, EventDT, StatusID ' +
		' from MonitorEvent ' +
		' where MonitorID=' + cast(@MonitorID as varchar(10)) + ' ' +
		' and EventDT > ''' +  convert(varchar(50), @LastAlertEventDT,121) + ''' ' +
		' order by EventDT desc'

	execute sp_executesql @SQL
	print @SQL
	

	select @RowCount=count(*) from #Events
	select @NumNonFails = count(*)
	from #Events
	where StatusID <> 3

	select @RowCount, @NumNonFails, @MonitorID, @CurrentEventID, @LastAlertEventDT

	if (@RowCount>=@EveryNFailures) and (@NumNonFails=0)
	begin
		-- Alert after every N Fails
		print 'Every N Fail'
		exec polymon_ins_GenerateAlert @CurrentEventID
		set @IsAlerted=1
	end
end


--Alert After Every N Warnings
if (@IsAlerted=0) and (@EveryNWarnings>0)
begin
	set @SQL= 'insert into #Events (EventID, EventDT, StatusID) '
		+ 'select top ' + cast(@EveryNWarnings as varchar(10)) + ' EventID, EventDT, StatusID ' +
		' from MonitorEvent ' +
		' where MonitorID=' + cast(@MonitorID as varchar(10)) + ' ' +
		' and EventDT > ''' + convert(varchar(50), @LastAlertEventDT,121) + ''' ' +
		' order by EventDT desc'

	execute sp_executesql @SQL
	select @RowCount=count(*) from #Events
	select @NumNonFails = count(*)
	from #Events
	where StatusID <> 2

	if (@RowCount>=@EveryNFailures) and (@NumNonFails=0)
	begin
		-- Alert after every N Warnings
		print 'Every N Warning'
		exec polymon_ins_GenerateAlert @CurrentEventID
		set @IsAlerted=1
	end
end

drop table #Events


GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[polymon_ins_MonitorEvent]
@MonitorID int,
@StatusID tinyint,
@StatusMessage nvarchar(1000),
@EventID int output
AS

/*
===================================================================
Procedure Name: polymon_ins_MonitorEvent
Author: Fred Baptiste	
Create Date: 10/21/2005
Purpose:  Inserts a new Event record in MonitorEvent table and generates Alerts based on 
	monitor operator settings and monitor alert rules
Parameters: 
	@MonitorID - the ID of the monitor for which the event is being saved
	@StatusID - the current status of the monitor
	@StatusMessage - associated event message
Output:  @EventID - the allocated ID for the event
Notes:
===================================================================
Revision History:


===================================================================
*/
set nocount on

Declare @EventDT datetime

set @EventDT = GetDate()

insert into MonitorEvent (MonitorID, EventDT, StatusID, StatusMessage)
values(@MonitorID, @EventDT, @StatusID, @StatusMessage)

set @EventID = @@IDENTITY --retrieve allocated EventID

--Generate any alerts required
exec polymon_ins_EvaluateEventAlertStatus @EventID
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/28/2007
-- Description:	PolyMon Monitor to apply Retention Scheme
-- =============================================
CREATE PROCEDURE [dbo].[agg_Monitor_ApplyRetentionScheme] 
	@StatusCode tinyint output,
	@StatusMessage varchar(8000) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Declare @Err int
	Declare @ErrMsg varchar(200)
	Declare @SPErr int
	Declare @StatusMonthlyCount int 
	Declare @CounterMonthlyCount int 
	Declare @StatusWeeklyCount int 
	Declare @CounterWeeklyCount int 
	Declare @StatusDailyCount int 
	Declare @CounterDailyCount int 
	Declare @StatusRawCount int 
	Declare @CounterRawCount int 


	set @Err=0

	exec agg_ApplyRetentionScheme 0, @StatusMonthlyCount output, 
		@CounterMonthlyCount output, 
		@StatusWeeklyCount output, 
		@CounterWeeklyCount output, 
		@StatusDailyCount output, 
		@CounterDailyCount output, 
		@StatusRawCount output, 
		@CounterRawCount output,
		@ErrMsg output,
		@SPErr output

	if @Err<>0 or @SPErr<>0
		begin
		set @StatusCode=3
		set @StatusMessage = 'Error occurred applying retention scheme.' + char(10) + char(13) 
			+ @ErrMsg + char(10) + char(13) + 'SQL Error: ' + cast(@SPErr as varchar(100))
			end
	else
		begin
		set @StatusCode=1
		set @StatusMessage = 'OK'
		end

	Declare @Counters table(Counter varchar(50), [Value] int, OrderBy tinyint)

	insert into @Counters (Counter, [Value], OrderBy) values('Raw Status - Rows Deleted', coalesce(@StatusRawCount,0), 1)
	insert into @Counters (Counter, [Value], OrderBy) values('Raw Counters - Rows Deleted', coalesce(@CounterRawCount,0), 1)
	insert into @Counters (Counter, [Value], OrderBy) values('Daily Status - Rows Deleted', coalesce(@StatusDailyCount,0), 1)
	insert into @Counters (Counter, [Value], OrderBy) values('Daily Counters - Rows Deleted', coalesce(@CounterDailyCount,0), 1)
	insert into @Counters (Counter, [Value], OrderBy) values('Weekly Status - Rows Deleted', coalesce(@StatusWeeklyCount,0), 1)
	insert into @Counters (Counter, [Value], OrderBy) values('Weekly Counters - Rows Deleted', coalesce(@CounterWeeklyCount,0), 1)
	insert into @Counters (Counter, [Value], OrderBy) values('Monthly Status - Rows Deleted', coalesce(@StatusMonthlyCount,0), 1)
	insert into @Counters (Counter, [Value], OrderBy) values('Monthly Counters - Rows Deleted', coalesce(@CounterMonthlyCount,0), 1)


	select Counter, [Value]
	from @Counters
	order by OrderBy
END

GO

ALTER TRIGGER [dbo].[UpDownTimeCalculation] 
   ON  [dbo].[MonitorEvent]
   AFTER INSERT
AS 
BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 SET NOCOUNT ON;


    -- Insert statements for trigger here
 Declare @MonitorID int
 Declare @CurrEventID int
 Declare @CurrEventDT datetime
 Declare @CurrStatusID int
 Declare @FailMult smallint
 Declare @CurrStatusMessage nvarchar(1000)
 Declare @LifetimePercUptime decimal(6,3)

 Declare @UpDownTimeSecs int

 select @MonitorID=MonitorID, @CurrEventID=EventID, @CurrEventDT=EventDT,
  @CurrStatusID=StatusID,
  @FailMult = case when StatusID=3 then -1 else 1 end,
  @CurrStatusMessage=StatusMessage
 from inserted

 --UpDownTimeSecs
 if exists(select * from MonitorEvent where MonitorID=@MonitorID and EventID <> @CurrEventID)
 begin
  set @UpDownTimeSecs = coalesce(datediff(ss, dbo.fn_PrevEventDT(@MonitorID, @CurrEventID), @CurrEventDT) * @FailMult,0)
  update MonitorEvent
  set UpDownTimeSecs = @UpDownTimeSecs
  where EventID=@CurrEventID
 end


 --MonitorCurrentStatus
 Declare @Uptime bigint
 Declare @Downtime bigint

if @UpDownTimeSecs is NULL
	set @UpDownTimeSecs=0

 if @UpDownTimeSecs<=0
  begin
  set @Uptime=0
  set @DownTime=abs(@UpDownTimeSecs)
  end
 else
  begin
  set @UpTime = @UpDownTimeSecs
  set @DownTime=0
  end

 if not exists(select * from MonitorCurrentStatus where MonitorID=@MonitorID)
 begin
  --Insert new record
  insert into MonitorCurrentStatus (MonitorID, EventID, EventDT, StatusID, StatusMessage, LifetimePercUptime, LifetimeUpTime, LifetimeDowntime)
  values (@MonitorID, @CurrEventID, @CurrEventDT, @CurrStatusID, @CurrStatusMessage, 
  0, @UpTime, @DownTime)
 end
 else
 begin
  --Update record
  update MonitorCurrentStatus
  set EventID=@CurrEventID,
   EventDT=@CurrEventDT,
   StatusID=@CurrStatusID,
   StatusMessage=@CurrStatusMessage,
   LifetimeUptime = coalesce(LifetimeUptime,0) + @Uptime,
   LifetimeDowntime = coalesce(LifetimeDowntime,0) + @Downtime,
   LifetimePercUptime = coalesce(cast(100 * cast(LifetimeUptime+@Uptime as dec(20,3)) / (cast(LifetimeUptime+@Uptime as dec(20,3)) + cast(LifetimeDowntime+@Downtime as dec(20,3))) as dec(6,3)),0)
  where MonitorID=@MonitorID

 end

 --Update Status Agg Tables
 exec agg_UpdateStatusTables @MonitorID, @CurrEventDT, @CurrStatusID, @UpDownTimeSecs

END

