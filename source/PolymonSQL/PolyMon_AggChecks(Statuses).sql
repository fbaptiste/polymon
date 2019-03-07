/* Checks Status Aggregates */

Declare @MonitorID int
Declare @CheckDate datetime

set @MonitorID = 160
set @CheckDate = getdate()

Declare @TimespanID smallint
Declare @StartDT datetime
Declare @EndDT datetime

--Daily
select @TimespanID = TimespanID from TSDaily
where year=year(@CheckDate) and month=month(@CheckDate) and day=day(@CheckDate)
select @StartDT = cast(convert(varchar(10), @CheckDate, 101) + ' 00:00:00' as datetime)
select @EndDT = cast(convert(varchar(10), @CheckDate, 101) + ' 23:59:59' as datetime)

select 'Raw' as Source, sum(case when StatusID=1 then 1 else 0 end) as OKCount,
	sum(case when StatusID=2 then 1 else 0 end) as WarningCount,
	sum(case when StatusID=3 then 1 else 0 end) as FailureCount,
	sum(case when UpDownTimeSecs>0 then UpDownTimeSecs else 0 end) as TotalUpTime,
	sum(case when UpDownTimeSecs<0 then abs(UpDownTimeSecs) else 0 end) as TotalDownTime
from MonitorEvent
where MonitorID=@MonitorID and EventDT between @StartDT and @EndDT
UNION ALL
select 'Agg', OKCount, WarningCount, FailureCount, TotalUpTime, TotalDownTime
from AggStatus_Daily
where MonitorID=@MonitorID
and TimespanID=@TimespanID

--Weekly
select @TimespanID = TimespanID, @StartDT=StartDT, @EndDT=EndDT
from TSWeekly
where @CheckDate between StartDT and EndDT

select 'Raw' as Source, sum(case when StatusID=1 then 1 else 0 end) as OKCount,
	sum(case when StatusID=2 then 1 else 0 end) as WarningCount,
	sum(case when StatusID=3 then 1 else 0 end) as FailureCount,
	sum(case when UpDownTimeSecs>0 then UpDownTimeSecs else 0 end) as TotalUpTime,
	sum(case when UpDownTimeSecs<0 then abs(UpDownTimeSecs) else 0 end) as TotalDownTime
from MonitorEvent
where MonitorID=@MonitorID and EventDT between @StartDT and @EndDT
UNION ALL
select 'Agg', OKCount, WarningCount, FailureCount, TotalUpTime, TotalDownTime
from AggStatus_Weekly
where MonitorID=@MonitorID
and TimespanID=@TimespanID

--Monthly
select @TimespanID = TimespanID, @StartDT=StartDT, @EndDT=EndDT
from TSMonthly
where @CheckDate between StartDT and EndDT

select 'Raw' as Source, sum(case when StatusID=1 then 1 else 0 end) as OKCount,
	sum(case when StatusID=2 then 1 else 0 end) as WarningCount,
	sum(case when StatusID=3 then 1 else 0 end) as FailureCount,
	sum(case when UpDownTimeSecs>0 then UpDownTimeSecs else 0 end) as TotalUpTime,
	sum(case when UpDownTimeSecs<0 then abs(UpDownTimeSecs) else 0 end) as TotalDownTime
from MonitorEvent
where MonitorID=@MonitorID and EventDT between @StartDT and @EndDT
UNION ALL
select 'Agg', OKCount, WarningCount, FailureCount, TotalUpTime, TotalDownTime
from AggStatus_Monthly
where MonitorID=@MonitorID
and TimespanID=@TimespanID

--Yearly
select @TimespanID = TimespanID, @StartDT=StartDT, @EndDT=EndDT
from TSYearly
where @CheckDate between StartDT and EndDT

select 'Raw' as Source, sum(case when StatusID=1 then 1 else 0 end) as OKCount,
	sum(case when StatusID=2 then 1 else 0 end) as WarningCount,
	sum(case when StatusID=3 then 1 else 0 end) as FailureCount,
	sum(case when UpDownTimeSecs>0 then UpDownTimeSecs else 0 end) as TotalUpTime,
	sum(case when UpDownTimeSecs<0 then abs(UpDownTimeSecs) else 0 end) as TotalDownTime
from MonitorEvent
where MonitorID=@MonitorID and EventDT between @StartDT and @EndDT
UNION ALL
select 'Agg', OKCount, WarningCount, FailureCount, TotalUpTime, TotalDownTime
from AggStatus_Yearly
where MonitorID=@MonitorID
and TimespanID=@TimespanID