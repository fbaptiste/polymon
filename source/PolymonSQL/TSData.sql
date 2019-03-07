/*Generate TS Lookups*/
set nocount on

set dateformat ymd

Declare @StartDT datetime
Declare @EndDT datetime
set @StartDT = '2006-01-01 00:00:00'
set @EndDT = '2020-12-31 00:00:00'

Declare @StartYear int
Declare @EndYear int
set @StartYear = year(@StartDT)
set @EndYear = year(@EndDT)

Declare @Cnt int
Declare @CurrDate datetime
Declare @CurrYear int
Declare @CurrWeek smallint
Declare @LastWeekNum smallint
Declare @WeekStart datetime
Declare @WeekEnd datetime
Declare @CurrMonth tinyint
Declare @MonthStart datetime
Declare @MonthEnd datetime
Declare @YearStart datetime
Declare @YearEnd datetime


--Daily
Delete from TSDaily
set @Cnt=1
set @CurrDate = @StartDT
while @CurrDate < @EndDT
	begin
	insert into TSDaily (TimespanID, Year, Month, Day, DT)
	values (@Cnt, year(@CurrDate), month(@CurrDate), day(@CurrDate), cast(convert(varchar(10), @CurrDate, 120) + ' 00:00:00' as datetime))
	set @Cnt=@Cnt+1
	set @CurrDate = dateadd(dd, 1, @CurrDate)
	end



--Weekly
SET DATEFIRST 7 --sets first day of week to Sunday.

Delete from TSWeekly

set @CurrYear = @StartYear
set @Cnt=1
while @CurrYear<=@EndYear
	begin
	--For each year, calculate weeks
	set @CurrWeek = 1
	set @LastWeekNum = datepart(week, cast(cast(@CurrYear as varchar(4)) + '-12-31' as datetime))

	set @WeekStart = cast(cast(@CurrYear as varchar(4)) + '-01-01' as datetime)

	while @CurrWeek<=@LastWeekNum
		begin
		set @WeekEnd = dateadd(day, 7 - datepart(dw, @WeekStart), @WeekStart)

		if @WeekStart < cast(cast(@CurrYear as varchar(4)) + '-01-01' as datetime)
			set @WeekStart = cast(cast(@CurrYear as varchar(4)) + '-01-01' as datetime)
		if @WeekEnd > cast(cast(@CurrYear as varchar(4))+ '-12-31' as datetime)
			set @WeekEnd = cast(cast(@CurrYear as varchar(4)) + '-12-31' as datetime)

		insert into TSWeekly (TimespanID, Year, WeekOfYear, StartDT, EndDT)
		values(@Cnt, @CurrYear, datepart(week, @WeekStart), @WeekStart, @WeekEnd)
		

		set @CurrWeek = @CurrWeek + 1
		set @Cnt=@Cnt+1
		set @WeekStart = dateadd(day, 1, @WeekEnd)
		end

	--Move to next year
	set @CurrYear = @CurrYear + 1
	end



--Monthly
Delete from TSMonthly
set @Cnt=1
set @CurrYear = @StartYear


while @CurrYear <= @EndYear 
	begin
	set @CurrMonth = 1
	while @CurrMonth <= 12
		begin
		set @MonthStart = cast(cast(@CurrYear as varchar(4)) + '-' + cast(@CurrMonth as varchar(2)) + '-01'  as datetime)
		set @MonthEnd = dateadd(dd,-1,dateadd(mm,1,@MonthStart))
		insert into TSMonthly (TimespanID, Year, Month, StartDT, EndDT)
		values(@Cnt, @CurrYear, @CurrMonth, @MonthStart, @MonthEnd)
		set @CurrMonth = @CurrMonth + 1
		set @Cnt = @Cnt + 1
		end
	set @CurrYear = @CurrYear+1
	end


