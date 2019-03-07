-- =============================================
-- Script Template Update DB 1.10 to 1.30
-- =============================================
set nocount on
GO

ALTER PROCEDURE [dbo].[polymon_hyb_SaveOperator]
@OperatorID int output,
@Name nvarchar(255),
@IsEnabled bit,
@EmailAddress varchar(255),
@OfflineTimeStart char(5),
@OfflineTimeEnd char(5),
@IncludeMessageBody bit,
@QueuedNotify tinyint,
@SummaryNotify tinyint,
@SummaryNotifyOK bit,
@SummaryNotifyWarn bit,
@SummaryNotifyFail bit,
@SummaryNotifyTime char(5)
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

--If SummaryNotify has been set determine when next notification date time should be
Declare @NextDT datetime
Declare @NotifyTime int
Declare @CurrTime int

set dateformat ymd

--Removed this condition, so it always saves it. No reason not to.
--if @SummaryNotify=1
-- begin
 set @NotifyTime =cast(replace(coalesce(@SummaryNotifyTime, '00:00'), ':', '') as integer)
 set @CurrTime =  cast(replace(convert(varchar(5), getdate(), 8), ':', '') as integer)

 if @NotifyTime <= @CurrTime
  set @NextDT = cast(convert(varchar(10), dateadd(dd, 1, getdate()), 101) + ' ' + @SummaryNotifyTime as datetime)
 else
  set @NextDT = cast(convert(varchar(10), getdate(), 101) + ' ' + @SummaryNotifyTime as datetime)
-- end
--else
-- set @NextDT = NULL

if @OperatorID is NULL
begin
 --Create new Operator Record
 insert into Operator (Name, IsEnabled, EmailAddress, OfflineTimeStart, OfflineTimeEnd, IncludeMessageBody, QueuedNotify, SummaryNotify, SummaryNotifyOK, SummaryNotifyWarn, SummaryNotifyFail, SummaryNotifyTime, SummaryNextNotifyDT)
 values (@Name, @IsEnabled, @EmailAddress, @OfflineTimeStart, @OfflineTimeEnd, @IncludeMessageBody, @QueuedNotify, @SummaryNotify, @SummaryNotifyOK, @SummaryNotifyWarn, @SummaryNotifyFail, @SummaryNotifyTime, @NextDT)

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
   IncludeMessageBody=@IncludeMessageBody,
   QueuedNotify=@QueuedNotify,
   SummaryNotify=@SummaryNotify,
   SummaryNotifyOK=@SummaryNotifyOK,
   SummaryNotifyWarn=@SummaryNotifyWarn,
   SummaryNotifyFail=@SummaryNotifyFail,
   SummaryNotifyTime=@SummaryNotifyTime,
   SummaryNextNotifyDT=@NextDT
  where OperatorID=@OperatorID
 end
end
GO


--Set Database Version --
update SysSettings
set DBVersion = '1.30'
GO