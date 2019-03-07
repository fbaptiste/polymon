/* Checks Counter Aggregates */

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
select 'Raw' as Source, CounterName, sum(CounterValue) as SumCounterValue, count(*) as NumCounterSamples, avg(CounterValue) as Average
from MonitorEventCounter 
where MonitorID=@MonitorID and EventDT between @StartDT and @EndDT	
group by CounterName
UNION ALL
select 'Agg' as Source, 
	CounterName, 
	SumCounterValue, 
	NumCounterSamples, 
	case when NumCounterSamples=0 then 0 else cast(SumCounterValue as float)/cast(NumCounterSamples as float) end
from AggCounter_Daily
where MonitorID=@MonitorID and TimespanID=@TimespanID
order by CounterName, Source desc

--Weekly
select @TimespanID = TimespanID, @StartDT=StartDT, @EndDT=EndDT
from TSWeekly
where @CheckDate between StartDT and EndDT

select 'Raw' as Source, CounterName, sum(CounterValue) as SumCounterValue, count(*) as NumCounterSamples, avg(CounterValue) as Average
from MonitorEventCounter 
where MonitorID=@MonitorID and EventDT between @StartDT and @EndDT	
group by CounterName
UNION ALL
select 'Agg' as Source, 
	CounterName, 
	SumCounterValue, 
	NumCounterSamples, 
	case when NumCounterSamples=0 then 0 else cast(SumCounterValue as float)/cast(NumCounterSamples as float) end
from AggCounter_Weekly
where MonitorID=@MonitorID and TimespanID=@TimespanID
order by CounterName, Source desc

--Monthly
select @TimespanID = TimespanID, @StartDT=StartDT, @EndDT=EndDT
from TSMonthly
where @CheckDate between StartDT and EndDT

select 'Raw' as Source, CounterName, sum(CounterValue) as SumCounterValue, count(*) as NumCounterSamples, avg(CounterValue) as Average
from MonitorEventCounter 
where MonitorID=@MonitorID and EventDT between @StartDT and @EndDT	
group by CounterName
UNION ALL
select 'Agg' as Source, 
	CounterName, 
	SumCounterValue, 
	NumCounterSamples, 
	case when NumCounterSamples=0 then 0 else cast(SumCounterValue as float)/cast(NumCounterSamples as float) end
from AggCounter_Monthly
where MonitorID=@MonitorID and TimespanID=@TimespanID
order by CounterName, Source desc

--Yearly
select @TimespanID = TimespanID, @StartDT=StartDT, @EndDT=EndDT
from TSYearly
where @CheckDate between StartDT and EndDT

select 'Raw' as Source, CounterName, sum(CounterValue) as SumCounterValue, count(*) as NumCounterSamples, avg(CounterValue) as Average
from MonitorEventCounter 
where MonitorID=@MonitorID and EventDT between @StartDT and @EndDT	
group by CounterName
UNION ALL
select 'Agg' as Source, 
	CounterName, 
	SumCounterValue, 
	NumCounterSamples, 
	case when NumCounterSamples=0 then 0 else cast(SumCounterValue as float)/cast(NumCounterSamples as float) end
from AggCounter_Yearly
where MonitorID=@MonitorID and TimespanID=@TimespanID
order by CounterName, Source desc