/****** Object:  Table [dbo].[OperatorRole]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperatorRole](
	[RoleID] [tinyint] NOT NULL,
	[Role] [varchar](100) NOT NULL,
 CONSTRAINT [PK_OperatorRole] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSDaily]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSDaily](
	[TimespanID] [smallint] NOT NULL,
	[Year] [smallint] NOT NULL,
	[Month] [tinyint] NOT NULL,
	[Day] [tinyint] NOT NULL,
	[DT] [datetime] NULL,
 CONSTRAINT [PK_TSDaily] PRIMARY KEY CLUSTERED 
(
	[TimespanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSMonthly]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSMonthly](
	[TimespanID] [smallint] NOT NULL,
	[Year] [smallint] NOT NULL,
	[Month] [tinyint] NOT NULL,
	[StartDT] [datetime] NOT NULL,
	[EndDT] [datetime] NOT NULL,
 CONSTRAINT [PK_TSMonthly] PRIMARY KEY CLUSTERED 
(
	[TimespanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSWeekly]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSWeekly](
	[TimespanID] [smallint] NOT NULL,
	[Year] [smallint] NOT NULL,
	[WeekOfYear] [tinyint] NOT NULL,
	[StartDT] [datetime] NOT NULL,
	[EndDT] [datetime] NOT NULL,
 CONSTRAINT [PK_TSWeekly] PRIMARY KEY CLUSTERED 
(
	[TimespanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Executive]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Executive](
	[ExecutiveID] [smallint] IDENTITY(1,1) NOT NULL,
	[Server] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Executive] PRIMARY KEY CLUSTERED 
(
	[ExecutiveID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DashboardGroupDefault]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DashboardGroupDefault](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DisplayOrder] [int] NOT NULL CONSTRAINT [DF_DashboardGroupDefault_DisplayOrder]  DEFAULT ((0)),
 CONSTRAINT [PK_DashboardGroupDefault] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyBag]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyBag](
	[PropertyKey] [varchar](255) NOT NULL,
	[PropertyValue1] [nvarchar](3000) NULL,
	[PropertyValue2] [ntext] NULL,
 CONSTRAINT [PK_PropertyBag] PRIMARY KEY CLUSTERED 
(
	[PropertyKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonitorType]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitorType](
	[MonitorTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[MonitorAssembly] [varchar](255) NOT NULL,
	[EditorAssembly] [varchar](255) NOT NULL CONSTRAINT [DF_MonitorType_EditorAssembly]  DEFAULT ('XMLEditor.xml'),
	[MonitorXMLTemplate] [ntext] NULL,
 CONSTRAINT [PK_MonitorType] PRIMARY KEY CLUSTERED 
(
	[MonitorTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysSettings]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysSettings](
	[Name] [varchar](50) NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	[ServiceServer] [varchar](255) NOT NULL,
	[MainTimerInterval] [int] NOT NULL CONSTRAINT [DF_SysSettings_MainTimerInterval]  DEFAULT ((60000)),
	[UseInternalSMTP] [bit] NOT NULL,
	[SMTPFromName] [varchar](50) NOT NULL,
	[SMTPFromAddress] [varchar](255) NOT NULL,
	[ExtSMTPServer] [varchar](255) NULL,
	[ExtSMTPPort] [int] NULL,
	[ExtSMTPUserID] [varchar](50) NULL,
	[ExtSMTPPwd] [varchar](50) NULL,
	[ExtSMTPUseSSL] [bit] NOT NULL CONSTRAINT [DF_SysSettings_ExtUseSSL]  DEFAULT ((0)),
	[RetentionMaxMonthsRaw] [smallint] NOT NULL CONSTRAINT [DF_SysSettings_RetentionMaxMonthsRaw]  DEFAULT ((24)),
	[RetentionMaxMonthsDaily] [smallint] NOT NULL CONSTRAINT [DF_SysSettings_RetentionMaxMonthsDaily]  DEFAULT ((36)),
	[RetentionMaxMonthsWeekly] [smallint] NOT NULL CONSTRAINT [DF_SysSettings_RetentionMaxMonthsWeekly]  DEFAULT ((60)),
	[RetentionMaxMonthsMonthly] [smallint] NOT NULL CONSTRAINT [DF_SysSettings_RetentionMaxMonthsMonthly]  DEFAULT ((60)),
	[DBVersion] [decimal](5, 2) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Operator]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operator](
	[OperatorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[IsEnabled] [bit] NOT NULL CONSTRAINT [DF_Operator_IsEnabled]  DEFAULT (1),
	[EmailAddress] [varchar](255) NOT NULL,
	[OfflineTimeStart] [char](5) NOT NULL CONSTRAINT [DF_Operator_OfflineTimeStart]  DEFAULT ('00:00'),
	[OfflineTimeEnd] [char](5) NOT NULL CONSTRAINT [DF_Operator_OfflineTimeEnd]  DEFAULT ('00:00'),
	[IncludeMessageBody] [bit] NOT NULL CONSTRAINT [DF_Operator_IncludeMessageBody]  DEFAULT (1),
 CONSTRAINT [PK_Operator] PRIMARY KEY CLUSTERED 
(
	[OperatorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LookupEventStatus]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupEventStatus](
	[StatusID] [tinyint] NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LookupEventStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OperatorAccount]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperatorAccount](
	[OperatorID] [int] NOT NULL,
	[LoginID] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[RoleID] [tinyint] NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_OperatorAccount_IsActive]  DEFAULT ((1)),
	[IsPwdExpired] [bit] NOT NULL CONSTRAINT [DF_OperatorAccount_IsPwdExpired]  DEFAULT ((0)),
	[EnableStartDT] [datetime] NOT NULL CONSTRAINT [DF_OperatorAccount_EnableStartDT]  DEFAULT (getdate()),
	[EnableEndDT] [datetime] NOT NULL CONSTRAINT [DF_OperatorAccount_EnableEndDT]  DEFAULT (dateadd(year,(1),getdate())),
 CONSTRAINT [PK_OperatorAccount] PRIMARY KEY CLUSTERED 
(
	[OperatorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_OperatorAccount_LoginIDUnique]    Script Date: 06/12/2007 08:12:46 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_OperatorAccount_LoginIDUnique] ON [dbo].[OperatorAccount] 
(
	[LoginID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AggStatus_Daily]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AggStatus_Daily](
	[MonitorID] [int] NOT NULL,
	[TimespanID] [smallint] NOT NULL,
	[WarningCount] [int] NOT NULL,
	[FailureCount] [int] NOT NULL,
	[OKCount] [int] NOT NULL,
	[TotalUpTime] [int] NOT NULL,
	[TotalDownTime] [int] NOT NULL,
 CONSTRAINT [PK_AggStatus_Daily] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC,
	[TimespanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AggCounter_Daily]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AggCounter_Daily](
	[MonitorID] [int] NOT NULL,
	[TimespanID] [smallint] NOT NULL,
	[CounterName] [varchar](800) NOT NULL,
	[SumCounterValue] [decimal](30, 10) NOT NULL,
	[NumCounterSamples] [int] NOT NULL,
 CONSTRAINT [PK_AggCounter_Daily] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC,
	[TimespanID] ASC,
	[CounterName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AggStatus_Monthly]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AggStatus_Monthly](
	[MonitorID] [int] NOT NULL,
	[TimespanID] [smallint] NOT NULL,
	[WarningCount] [int] NOT NULL,
	[FailureCount] [int] NOT NULL,
	[OKCount] [int] NOT NULL,
	[TotalUpTime] [int] NOT NULL,
	[TotalDownTime] [int] NOT NULL,
 CONSTRAINT [PK_AggStatus_Monthly] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC,
	[TimespanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AggCounter_Monthly]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AggCounter_Monthly](
	[MonitorID] [int] NOT NULL,
	[TimespanID] [smallint] NOT NULL,
	[CounterName] [varchar](800) NOT NULL,
	[SumCounterValue] [decimal](30, 10) NOT NULL,
	[NumCounterSamples] [int] NOT NULL,
 CONSTRAINT [PK_AggCounter_Monthly] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC,
	[TimespanID] ASC,
	[CounterName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AggCounter_Weekly]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AggCounter_Weekly](
	[MonitorID] [int] NOT NULL,
	[TimespanID] [smallint] NOT NULL,
	[CounterName] [varchar](800) NOT NULL,
	[SumCounterValue] [decimal](30, 10) NOT NULL,
	[NumCounterSamples] [int] NOT NULL,
 CONSTRAINT [PK_AggCounter_Weekly] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC,
	[TimespanID] ASC,
	[CounterName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AggStatus_Weekly]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AggStatus_Weekly](
	[MonitorID] [int] NOT NULL,
	[TimespanID] [smallint] NOT NULL,
	[WarningCount] [int] NOT NULL,
	[FailureCount] [int] NOT NULL,
	[OKCount] [int] NOT NULL,
	[TotalUpTime] [int] NOT NULL,
	[TotalDownTime] [int] NOT NULL,
 CONSTRAINT [PK_AggStatus_Weekly] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC,
	[TimespanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Monitor]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monitor](
	[MonitorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[MonitorTypeID] [int] NOT NULL,
	[MonitorXML] [text] NOT NULL,
	[OfflineTime1Start] [char](5) NOT NULL CONSTRAINT [DF_Monitor_OfflineTime1Start]  DEFAULT ('00:00'),
	[OfflineTime1End] [char](5) NOT NULL CONSTRAINT [DF_Monitor_OfflineTime1End]  DEFAULT ('00:00'),
	[OfflineTime2Start] [char](5) NOT NULL CONSTRAINT [DF_Monitor_OfflineTime2Start]  DEFAULT ('00:00'),
	[OfflineTime2End] [char](5) NOT NULL CONSTRAINT [DF_Monitor_OfflineTime2End]  DEFAULT ('00:00'),
	[MessageSubjectTemplate] [nvarchar](100) NOT NULL,
	[MessageBodyTemplate] [nvarchar](3000) NULL,
	[TriggerMod] [int] NOT NULL CONSTRAINT [DF_Monitor_TriggerMod]  DEFAULT ((5)),
	[IsEnabled] [bit] NOT NULL CONSTRAINT [DF_Monitor_IsEnabled]  DEFAULT ((1)),
	[ExecutiveID] [smallint] NOT NULL CONSTRAINT [DF_Monitor_ExecutiveID]  DEFAULT ((1)),
	[AuditCreateDT] [datetime] NOT NULL CONSTRAINT [DF_Monitor_AuditCreateDT]  DEFAULT (getdate()),
	[AuditUpdateDT] [datetime] NULL,
 CONSTRAINT [PK_Monitor] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Trigger [dbo].[AuditUpdateDT]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[AuditUpdateDT] ON [dbo].[Monitor] 
FOR UPDATE
AS

update Monitor
set AuditUpdateDT=getdate()
where MonitorID in (select MonitorID from inserted)

GO
/****** Object:  Table [dbo].[MonitorRetentionScheme]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitorRetentionScheme](
	[MonitorID] [int] NOT NULL,
	[MaxMonthsRaw] [smallint] NOT NULL,
	[MaxMonthsDaily] [smallint] NOT NULL,
	[MaxMonthsWeekly] [smallint] NOT NULL,
	[MaxMonthsMonthly] [smallint] NOT NULL,
 CONSTRAINT [PK_MonitorRetentionScheme] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonitorEventCounter]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitorEventCounter](
	[EventID] [int] NOT NULL,
	[CounterName] [varchar](800) NOT NULL,
	[CounterValue] [decimal](30, 10) NULL,
	[MonitorID] [int] NOT NULL,
	[EventDT] [datetime] NOT NULL,
 CONSTRAINT [PK_MonitorEventCounter] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC,
	[CounterName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_MonitorEvent2]    Script Date: 06/12/2007 08:12:46 ******/
CREATE NONCLUSTERED INDEX [IX_MonitorEvent2] ON [dbo].[MonitorEventCounter] 
(
	[MonitorID] ASC,
	[EventDT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO

/****** Object:  Trigger [dbo].[AfterCounterInsert]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Fred Baptiste
-- Create date: 2/16/2007
-- Description:	
-- =============================================
CREATE TRIGGER [dbo].[AfterCounterInsert] 
   ON  [dbo].[MonitorEventCounter]
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Declare @MonitorID int
	Declare @EventDT datetime
	Declare @CounterName varchar(800)
	Declare @CounterValue decimal(30,10)

	select @MonitorID=MonitorID,
		@EventDT=EventDT,
		@CounterName=CounterName,
		@CounterValue=CounterValue
	from inserted

	exec agg_UpdateCounterTables @MonitorID, @EventDT, @CounterName, @CounterValue

END

GO
/****** Object:  Table [dbo].[MonitorAlertRule]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitorAlertRule](
	[MonitorID] [int] NOT NULL,
	[AlertAfterEveryNEvent] [int] NOT NULL CONSTRAINT [DF_MonitorAlertRule_AlertAfterEveryNEvent]  DEFAULT (0),
	[AlertAfterEveryNewFailure] [bit] NOT NULL CONSTRAINT [DF_MonitorAlertRule_AlertAfterEveryNewFailure]  DEFAULT (1),
	[AlertAfterEveryNFailures] [int] NOT NULL CONSTRAINT [DF_MonitorAlertRule_AlertAfterEveryNFailures]  DEFAULT (0),
	[AlertAfterEveryFailToOK] [bit] NOT NULL CONSTRAINT [DF_MonitorAlertRule_AlertAfterEveryFailToOK]  DEFAULT (1),
	[AlertAfterEveryNewWarning] [bit] NOT NULL CONSTRAINT [DF_MonitorAlertRule_AlertAfterEveryNewWarning]  DEFAULT (0),
	[AlertAfterEveryNWarnings] [int] NOT NULL CONSTRAINT [DF_MonitorAlertRule_AlertAfterEveryNWarnings]  DEFAULT (0),
	[AlertAfterEveryWarnToOK] [bit] NOT NULL CONSTRAINT [DF_MonitorAlertRule_AlertAfterEveryWarnToOK]  DEFAULT (0),
 CONSTRAINT [PK_MonitorAlertRule] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonitorEvent]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitorEvent](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[MonitorID] [int] NOT NULL,
	[EventDT] [datetime] NOT NULL,
	[StatusID] [tinyint] NOT NULL,
	[StatusMessage] [nvarchar](1000) NULL,
	[UpDownTimeSecs] [int] NULL,
 CONSTRAINT [PK_MonitorEvent] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_MonitorEvent]    Script Date: 06/12/2007 08:12:46 ******/
CREATE NONCLUSTERED INDEX [IX_MonitorEvent] ON [dbo].[MonitorEvent] 
(
	[EventDT] ASC,
	[StatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_MonitorEvent_1]    Script Date: 06/12/2007 08:12:46 ******/
CREATE NONCLUSTERED INDEX [IX_MonitorEvent_1] ON [dbo].[MonitorEvent] 
(
	[MonitorID] ASC,
	[EventDT] ASC,
	[StatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO

/****** Object:  Index [IX_MonitorEvent_2]    Script Date: 06/12/2007 08:12:46 ******/
CREATE NONCLUSTERED INDEX [IX_MonitorEvent_2] ON [dbo].[MonitorEvent] 
(
	[MonitorID] ASC,
	[EventID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO

/****** Object:  Index [IX_MonitorEvent_3]    Script Date: 06/12/2007 08:12:46 ******/
CREATE NONCLUSTERED INDEX [IX_MonitorEvent_3] ON [dbo].[MonitorEvent] 
(
	[EventDT] ASC,
	[StatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_MonitorEvent_MonitorID]    Script Date: 06/12/2007 08:12:46 ******/
CREATE NONCLUSTERED INDEX [IX_MonitorEvent_MonitorID] ON [dbo].[MonitorEvent] 
(
	[MonitorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO

/****** Object:  Index [IX_MonitorEventDT1]    Script Date: 06/12/2007 08:12:46 ******/
CREATE NONCLUSTERED INDEX [IX_MonitorEventDT1] ON [dbo].[MonitorEvent] 
(
	[MonitorID] ASC,
	[EventDT] ASC,
	[StatusID] ASC,
	[EventID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Trigger [dbo].[UpDownTimeCalculation]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Fred Baptiste
-- Create date: 10/5/2006
-- Description:	Trigger to calculate up/down time from previous event and maintain MonitorCurrentStatus
-- =============================================
CREATE TRIGGER [dbo].[UpDownTimeCalculation] 
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
		NULL, @UpTime, @DownTime)
	end
	else
	begin
		--Update record
		update MonitorCurrentStatus
		set EventID=@CurrEventID,
			EventDT=@CurrEventDT,
			StatusID=@CurrStatusID,
			StatusMessage=@CurrStatusMessage,
			LifetimeUptime = LifetimeUptime + @Uptime,
			LifetimeDowntime = LifetimeDowntime + @Downtime,
			LifetimePercUptime = cast(100 * cast(LifetimeUptime+@Uptime as dec(20,3)) / (cast(LifetimeUptime+@Uptime as dec(20,3)) + cast(LifetimeDowntime+@Downtime as dec(20,3))) as dec(6,3))
		where MonitorID=@MonitorID

	end

	--Update Status Agg Tables
	exec agg_UpdateStatusTables @MonitorID, @CurrEventDT, @CurrStatusID, @UpDownTimeSecs

END





GO
/****** Object:  Table [dbo].[DashboardGroupMonitorDefault]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DashboardGroupMonitorDefault](
	[PanelID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[MonitorID] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL CONSTRAINT [DF_DashboardGroupMonitorDefault_DisplayOrder]  DEFAULT ((0)),
 CONSTRAINT [PK_DashboardGroupPanelDefault] PRIMARY KEY CLUSTERED 
(
	[PanelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonitorOperator]    Script Date: 06/12/2007 08:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitorOperator](
	[MonitorID] [int] NOT NULL,
	[OperatorID] [int] NOT NULL,
 CONSTRAINT [PK_MonitorOperator] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC,
	[OperatorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonitorCurrentStatus]    Script Date: 06/12/2007 08:12:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitorCurrentStatus](
	[MonitorID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
	[EventDT] [datetime] NOT NULL,
	[StatusID] [tinyint] NOT NULL,
	[StatusMessage] [nvarchar](1000) NULL,
	[LifetimePercUptime] [decimal](6, 3) NULL,
	[LifetimeUptime] [bigint] NOT NULL DEFAULT ((0)),
	[LifetimeDowntime] [bigint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_MonitorCurrentStatus] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonitorAlert]    Script Date: 06/12/2007 08:12:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitorAlert](
	[AlertID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[MonitorID] [int] NOT NULL,
	[EventDT] [datetime] NOT NULL,
	[StatusID] [tinyint] NOT NULL,
	[MessageSubject] [nvarchar](255) NULL,
	[MessageBody] [nvarchar](3500) NULL,
 CONSTRAINT [PK_MonitorAlert] PRIMARY KEY CLUSTERED 
(
	[AlertID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [idx_MonitorAlert_MonitorID_EventDT_EventID]    Script Date: 06/12/2007 08:12:47 ******/
CREATE NONCLUSTERED INDEX [idx_MonitorAlert_MonitorID_EventDT_EventID] ON [dbo].[MonitorAlert] 
(
	[MonitorID] ASC,
	[EventDT] ASC,
	[EventID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_EventID]    Script Date: 06/12/2007 08:12:47 ******/
CREATE NONCLUSTERED INDEX [IX_EventID] ON [dbo].[MonitorAlert] 
(
	[EventID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperatorAlert]    Script Date: 06/12/2007 08:12:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperatorAlert](
	[AlertID] [int] NOT NULL,
	[OperatorID] [int] NOT NULL,
	[IsSent] [bit] NOT NULL CONSTRAINT [DF_OperatorAlert_IsSent]  DEFAULT (0),
	[SentDT] [datetime] NULL,
 CONSTRAINT [PK_OperatorAlert] PRIMARY KEY CLUSTERED 
(
	[AlertID] ASC,
	[OperatorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[OperatorAccount]  WITH CHECK ADD  CONSTRAINT [FK_OperatorAccount_Operator] FOREIGN KEY([OperatorID])
REFERENCES [dbo].[Operator] ([OperatorID])
GO
ALTER TABLE [dbo].[OperatorAccount] CHECK CONSTRAINT [FK_OperatorAccount_Operator]
GO
ALTER TABLE [dbo].[OperatorAccount]  WITH CHECK ADD  CONSTRAINT [FK_OperatorAccount_OperatorRole] FOREIGN KEY([RoleID])
REFERENCES [dbo].[OperatorRole] ([RoleID])
GO
ALTER TABLE [dbo].[OperatorAccount] CHECK CONSTRAINT [FK_OperatorAccount_OperatorRole]
GO
ALTER TABLE [dbo].[AggStatus_Daily]  WITH CHECK ADD  CONSTRAINT [FK_AggStatus_Daily_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AggStatus_Daily] CHECK CONSTRAINT [FK_AggStatus_Daily_Monitor]
GO
ALTER TABLE [dbo].[AggStatus_Daily]  WITH CHECK ADD  CONSTRAINT [FK_AggStatus_Daily_TSDaily] FOREIGN KEY([TimespanID])
REFERENCES [dbo].[TSDaily] ([TimespanID])
GO
ALTER TABLE [dbo].[AggStatus_Daily] CHECK CONSTRAINT [FK_AggStatus_Daily_TSDaily]
GO
ALTER TABLE [dbo].[AggCounter_Daily]  WITH CHECK ADD  CONSTRAINT [FK_AggCounter_Daily_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AggCounter_Daily] CHECK CONSTRAINT [FK_AggCounter_Daily_Monitor]
GO
ALTER TABLE [dbo].[AggCounter_Daily]  WITH CHECK ADD  CONSTRAINT [FK_AggCounter_Daily_TSDaily] FOREIGN KEY([TimespanID])
REFERENCES [dbo].[TSDaily] ([TimespanID])
GO
ALTER TABLE [dbo].[AggCounter_Daily] CHECK CONSTRAINT [FK_AggCounter_Daily_TSDaily]
GO
ALTER TABLE [dbo].[AggStatus_Monthly]  WITH CHECK ADD  CONSTRAINT [FK_AggStatus_Monthly_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AggStatus_Monthly] CHECK CONSTRAINT [FK_AggStatus_Monthly_Monitor]
GO
ALTER TABLE [dbo].[AggStatus_Monthly]  WITH CHECK ADD  CONSTRAINT [FK_AggStatus_Monthly_TSMonthly] FOREIGN KEY([TimespanID])
REFERENCES [dbo].[TSMonthly] ([TimespanID])
GO
ALTER TABLE [dbo].[AggStatus_Monthly] CHECK CONSTRAINT [FK_AggStatus_Monthly_TSMonthly]
GO
ALTER TABLE [dbo].[AggCounter_Monthly]  WITH CHECK ADD  CONSTRAINT [FK_AggCounter_Monthly_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AggCounter_Monthly] CHECK CONSTRAINT [FK_AggCounter_Monthly_Monitor]
GO
ALTER TABLE [dbo].[AggCounter_Monthly]  WITH CHECK ADD  CONSTRAINT [FK_AggCounter_Monthly_TSMonthly] FOREIGN KEY([TimespanID])
REFERENCES [dbo].[TSMonthly] ([TimespanID])
GO
ALTER TABLE [dbo].[AggCounter_Monthly] CHECK CONSTRAINT [FK_AggCounter_Monthly_TSMonthly]
GO
ALTER TABLE [dbo].[AggCounter_Weekly]  WITH CHECK ADD  CONSTRAINT [FK_AggCounter_Weekly_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AggCounter_Weekly] CHECK CONSTRAINT [FK_AggCounter_Weekly_Monitor]
GO
ALTER TABLE [dbo].[AggCounter_Weekly]  WITH CHECK ADD  CONSTRAINT [FK_AggCounter_Weekly_TSWeekly] FOREIGN KEY([TimespanID])
REFERENCES [dbo].[TSWeekly] ([TimespanID])
GO
ALTER TABLE [dbo].[AggCounter_Weekly] CHECK CONSTRAINT [FK_AggCounter_Weekly_TSWeekly]
GO
ALTER TABLE [dbo].[AggStatus_Weekly]  WITH CHECK ADD  CONSTRAINT [FK_AggStatus_Weekly_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AggStatus_Weekly] CHECK CONSTRAINT [FK_AggStatus_Weekly_Monitor]
GO
ALTER TABLE [dbo].[AggStatus_Weekly]  WITH CHECK ADD  CONSTRAINT [FK_AggStatus_Weekly_TSWeekly] FOREIGN KEY([TimespanID])
REFERENCES [dbo].[TSWeekly] ([TimespanID])
GO
ALTER TABLE [dbo].[AggStatus_Weekly] CHECK CONSTRAINT [FK_AggStatus_Weekly_TSWeekly]
GO
ALTER TABLE [dbo].[Monitor]  WITH CHECK ADD  CONSTRAINT [FK_Monitor_Executive] FOREIGN KEY([ExecutiveID])
REFERENCES [dbo].[Executive] ([ExecutiveID])
GO
ALTER TABLE [dbo].[Monitor] CHECK CONSTRAINT [FK_Monitor_Executive]
GO
ALTER TABLE [dbo].[Monitor]  WITH NOCHECK ADD  CONSTRAINT [FK_Monitor_MonitorType] FOREIGN KEY([MonitorTypeID])
REFERENCES [dbo].[MonitorType] ([MonitorTypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Monitor] CHECK CONSTRAINT [FK_Monitor_MonitorType]
GO
ALTER TABLE [dbo].[MonitorRetentionScheme]  WITH CHECK ADD  CONSTRAINT [FK_MonitorRetentionScheme_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MonitorRetentionScheme] CHECK CONSTRAINT [FK_MonitorRetentionScheme_Monitor]
GO
ALTER TABLE [dbo].[MonitorEventCounter]  WITH NOCHECK ADD  CONSTRAINT [FK_MonitorEventCounter_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
GO
ALTER TABLE [dbo].[MonitorEventCounter] CHECK CONSTRAINT [FK_MonitorEventCounter_Monitor]
GO
ALTER TABLE [dbo].[MonitorEventCounter]  WITH NOCHECK ADD  CONSTRAINT [FK_MonitorEventCounter_MonitorEvent] FOREIGN KEY([EventID])
REFERENCES [dbo].[MonitorEvent] ([EventID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MonitorEventCounter] CHECK CONSTRAINT [FK_MonitorEventCounter_MonitorEvent]
GO
ALTER TABLE [dbo].[MonitorAlertRule]  WITH NOCHECK ADD  CONSTRAINT [FK_MonitorAlertRule_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MonitorAlertRule] CHECK CONSTRAINT [FK_MonitorAlertRule_Monitor]
GO
ALTER TABLE [dbo].[MonitorEvent]  WITH NOCHECK ADD  CONSTRAINT [FK_MonitorEvent_LookupEventStatus] FOREIGN KEY([StatusID])
REFERENCES [dbo].[LookupEventStatus] ([StatusID])
GO
ALTER TABLE [dbo].[MonitorEvent] CHECK CONSTRAINT [FK_MonitorEvent_LookupEventStatus]
GO
ALTER TABLE [dbo].[MonitorEvent]  WITH NOCHECK ADD  CONSTRAINT [FK_MonitorEvent_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MonitorEvent] CHECK CONSTRAINT [FK_MonitorEvent_Monitor]
GO
ALTER TABLE [dbo].[DashboardGroupMonitorDefault]  WITH CHECK ADD  CONSTRAINT [FK_DashboardGroupMonitorDefault_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DashboardGroupMonitorDefault] CHECK CONSTRAINT [FK_DashboardGroupMonitorDefault_Monitor]
GO
ALTER TABLE [dbo].[DashboardGroupMonitorDefault]  WITH CHECK ADD  CONSTRAINT [FK_DashboardGroupPanelDefault_DashboardGroupDefault] FOREIGN KEY([GroupID])
REFERENCES [dbo].[DashboardGroupDefault] ([GroupID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DashboardGroupMonitorDefault] CHECK CONSTRAINT [FK_DashboardGroupPanelDefault_DashboardGroupDefault]
GO
ALTER TABLE [dbo].[MonitorOperator]  WITH NOCHECK ADD  CONSTRAINT [FK_MonitorOperator_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MonitorOperator] CHECK CONSTRAINT [FK_MonitorOperator_Monitor]
GO
ALTER TABLE [dbo].[MonitorOperator]  WITH CHECK ADD  CONSTRAINT [FK_MonitorOperator_Operator] FOREIGN KEY([OperatorID])
REFERENCES [dbo].[Operator] ([OperatorID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MonitorOperator] CHECK CONSTRAINT [FK_MonitorOperator_Operator]
GO
ALTER TABLE [dbo].[MonitorCurrentStatus]  WITH CHECK ADD  CONSTRAINT [FK_MonitorCurrentStatus_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MonitorCurrentStatus] CHECK CONSTRAINT [FK_MonitorCurrentStatus_Monitor]
GO
ALTER TABLE [dbo].[MonitorAlert]  WITH NOCHECK ADD  CONSTRAINT [FK_MonitorAlert_LookupEventStatus] FOREIGN KEY([StatusID])
REFERENCES [dbo].[LookupEventStatus] ([StatusID])
GO
ALTER TABLE [dbo].[MonitorAlert] CHECK CONSTRAINT [FK_MonitorAlert_LookupEventStatus]
GO
ALTER TABLE [dbo].[MonitorAlert]  WITH NOCHECK ADD  CONSTRAINT [FK_MonitorAlert_Monitor] FOREIGN KEY([MonitorID])
REFERENCES [dbo].[Monitor] ([MonitorID])
GO
ALTER TABLE [dbo].[MonitorAlert] CHECK CONSTRAINT [FK_MonitorAlert_Monitor]
GO
ALTER TABLE [dbo].[MonitorAlert]  WITH NOCHECK ADD  CONSTRAINT [FK_MonitorAlert_MonitorEvent] FOREIGN KEY([EventID])
REFERENCES [dbo].[MonitorEvent] ([EventID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MonitorAlert] CHECK CONSTRAINT [FK_MonitorAlert_MonitorEvent]
GO
ALTER TABLE [dbo].[OperatorAlert]  WITH NOCHECK ADD  CONSTRAINT [FK_OperatorAlert_MonitorAlert] FOREIGN KEY([AlertID])
REFERENCES [dbo].[MonitorAlert] ([AlertID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OperatorAlert] CHECK CONSTRAINT [FK_OperatorAlert_MonitorAlert]
GO
ALTER TABLE [dbo].[OperatorAlert]  WITH CHECK ADD  CONSTRAINT [FK_OperatorAlert_Operator] FOREIGN KEY([OperatorID])
REFERENCES [dbo].[Operator] ([OperatorID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OperatorAlert] CHECK CONSTRAINT [FK_OperatorAlert_Operator]
