Imports System.Data.SqlClient
Imports ZedGraph

Public Class frmReports
#Region "Private Attributes"
	Private mMonitorID As Integer
	Private mSQLConn As String

	Private Const cFormatDate As String = "MMM dd, yyyy"
	Private Const cFormatDateHM As String = "MMM dd, yyyy HH:mm"
	Private Const cFormatDateHMS As String = "MMM dd, yyyy HH:mm:ss"
	Private Const cFormatDateHMSm As String = "MMM dd, yyyy HH:mm:ss.fff"

	Private mPointSymbolType As ZedGraph.SymbolType = SymbolType.Circle
	Private mPointSymbolFillColor As System.Drawing.Color = Color.Blue
	Private mPointSymbolFillIsVisible As Boolean = True
	Private mPointSymbolBorderIsVisible As Boolean = False
	Private mPointSymbolSize As Single = 7

	Private Const cChartWidth As Integer = 460
	Private Const cChartHeight As Integer = 180

	Private mMonitorStatusDateRanges As MonitorStatusDateRanges

	Private mStatusData_Daily As DataTable = Nothing
	Private mStatusData_Weekly As DataTable = Nothing
	Private mStatusData_Monthly As DataTable = Nothing
	Private mStatusData_Custom As DataTable = Nothing

	Private mCounterData_Daily As DataTable = Nothing
	Private mCounterData_Weekly As DataTable = Nothing
	Private mCounterData_Monthly As DataTable = Nothing
	Private mCounterData_Custom As DataTable = Nothing

	Private cDefSymbolMaxPts As Integer = 100
	Private cDefMaxDataPts As Integer = 4000
	Private mMaxDataPts As Integer
	Private mSymbolMaxPts As Integer
	Private Const cMaxReachedMsg As String = "Charts can display a maximum of {0} data points." & vbCrLf & "Limit exceeded." & vbCrLf & "Please view data by clicking on the ""View Data"" button."
#End Region

#Region "Public Interface"
	Public Sub New(ByVal MonitorID As Integer)
		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		mMonitorID = MonitorID
		mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
		If System.Configuration.ConfigurationManager.AppSettings("ChartMaxDataPts") Is Nothing Then
			mMaxDataPts = cDefMaxDataPts
		Else
			mMaxDataPts = CInt(System.Configuration.ConfigurationManager.AppSettings("ChartMaxDataPts"))
		End If
		If System.Configuration.ConfigurationManager.AppSettings("SymbolMaxPts") Is Nothing Then
			mSymbolMaxPts = cDefSymbolMaxPts
		Else
			mSymbolMaxPts = CInt(System.Configuration.ConfigurationManager.AppSettings("SymbolMaxPts"))
		End If

		Try
			mMonitorStatusDateRanges = New MonitorStatusDateRanges(MonitorID, mSQLConn)
		Finally
			'Do nothing!
		End Try
	End Sub
#End Region

#Region "Event Handlers"
	Private Sub frmReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        RefreshOverview()
        Me.Cursor = Cursors.Default
    End Sub
    
	Private Sub btnRunDaily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunDaily.Click
		Me.Cursor = Cursors.WaitCursor
		RunDaily()
		Me.Cursor = Cursors.Default
	End Sub
	Private Sub btnRunWeekly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunWeekly.Click
		Me.Cursor = Cursors.WaitCursor
		RunWeekly()
		Me.Cursor = Cursors.Default
	End Sub
	Private Sub btnRunMonthly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunMonthly.Click
		Me.Cursor = Cursors.WaitCursor
		RunMonthly()
		Me.Cursor = Cursors.Default
	End Sub
    Private Sub chkCustomGrouped_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustomGrouped.CheckedChanged
        nudCustomFrequency.Enabled = chkCustomGrouped.Checked
        cboCustomTimePeriods.Enabled = chkCustomGrouped.Checked
    End Sub
	Private Sub btnRunCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunCustom.Click
		Me.Cursor = Cursors.WaitCursor
		RunCustom()
		Me.Cursor = Cursors.Default
	End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
		Me.Cursor = Cursors.WaitCursor
        RefreshOverview()
        Me.Cursor = Cursors.Default
	End Sub
	Private Sub btnViewData_Daily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewData_Daily.Click
		Dim StatusData As DataTable = Nothing
		Dim CounterData As DataTable = Nothing
		Dim MonitorName As String = Nothing
		Dim MonitorType As String = Nothing

		MonitorName = lblMonitor.Text
		MonitorType = lblMonitorType.Text
		If mStatusData_Daily IsNot Nothing Then StatusData = mStatusData_Daily.Copy()
		If mCounterData_Daily IsNot Nothing Then CounterData = mCounterData_Daily.Copy()

		Dim DailyData As New frmReportData(mMonitorID, MonitorName, MonitorType, StatusData, CounterData)
		DailyData.MdiParent = Me.ParentForm
		DailyData.Show()
	End Sub
	Private Sub btnViewData_Weekly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewData_Weekly.Click
		Dim StatusData As DataTable = Nothing
		Dim CounterData As DataTable = Nothing
		Dim MonitorName As String = Nothing
		Dim MonitorType As String = Nothing

		MonitorName = lblMonitor.Text
		MonitorType = lblMonitorType.Text

		If mStatusData_Weekly IsNot Nothing Then StatusData = mStatusData_Weekly.Copy()
		If mCounterData_Weekly IsNot Nothing Then CounterData = mCounterData_Weekly.Copy()

		Dim DailyData As New frmReportData(mMonitorID, MonitorName, MonitorType, StatusData, CounterData)
		DailyData.MdiParent = Me.ParentForm
		DailyData.Show()
	End Sub
	Private Sub btnViewData_Monthly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewData_Monthly.Click
		Dim StatusData As DataTable = Nothing
		Dim CounterData As DataTable = Nothing
		Dim MonitorName As String = Nothing
		Dim MonitorType As String = Nothing

		MonitorName = lblMonitor.Text
		MonitorType = lblMonitorType.Text

		If mStatusData_Monthly IsNot Nothing Then StatusData = mStatusData_Monthly.Copy()
		If mCounterData_Monthly IsNot Nothing Then CounterData = mCounterData_Monthly.Copy()

		Dim DailyData As New frmReportData(mMonitorID, MonitorName, MonitorType, StatusData, CounterData)
		DailyData.MdiParent = Me.ParentForm
		DailyData.Show()
	End Sub
	Private Sub btnViewData_Custom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewData_Custom.Click
		Dim StatusData As DataTable = Nothing
		Dim CounterData As DataTable = Nothing
		Dim MonitorName As String = Nothing
		Dim MonitorType As String = Nothing

		MonitorName = lblMonitor.Text
		MonitorType = lblMonitorType.Text

		If mStatusData_Custom IsNot Nothing Then StatusData = mStatusData_Custom.Copy()
		If mCounterData_Custom IsNot Nothing Then CounterData = mCounterData_Custom.Copy()

		Dim DailyData As New frmReportData(mMonitorID, MonitorName, MonitorType, StatusData, CounterData)
		DailyData.MdiParent = Me.ParentForm
		DailyData.Show()
	End Sub
#End Region

#Region "Private Methods/Classes"
	Private Sub LoadCurrentStatus(ByVal MonitorID As Integer)
		Dim SQLConn As New SqlConnection(mSQLConn)

		Dim prmMonitorID As New SqlParameter
		With prmMonitorID
			.ParameterName = "@MonitorID"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = MonitorID
		End With

		Dim SQLCmd As New SqlCommand
		With SQLCmd
			.Connection = SQLConn
			.CommandType = CommandType.StoredProcedure
			.CommandTimeout = 180 '3 minutes
			.CommandText = "rpt_CurrentStatus"
			.Parameters.Add(prmMonitorID)
		End With

		Dim drResults As SqlDataReader

		Try
			SQLConn.Open()
			drResults = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection)
			While drResults.Read()
				SetCurrentStatus(CInt(drResults.Item("LastStatusID")))
				Me.lblStatusDate.Text = "(" & Format(CDate(drResults.Item("LastEventDT_Display")), cFormatDateHMSm) & ")"
				lblLifetimePercUptime.Text = CStr(drResults.Item("LifetimePercUptime")) & "%"
			End While
		Catch ex As Exception
			MsgBox("Error running Current Status report." & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Finally
			If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
			SQLConn.Dispose()
		End Try
	End Sub
	Private Sub SetCurrentStatus(ByVal StatusID As Integer)
		Select Case StatusID
			Case 1 'OK
				With lblOK
					.ForeColor = Color.Black
					.BackColor = Color.SkyBlue
				End With
				With lblWarning
					.ForeColor = Color.Gray
					.BackColor = Color.WhiteSmoke
				End With
				With lblFailure
					.ForeColor = Color.Gray
					.BackColor = Color.WhiteSmoke
				End With
			Case 2 ' Warning
				With lblOK
					.ForeColor = Color.Gray
					.BackColor = Color.WhiteSmoke
				End With
				With lblWarning
					.ForeColor = Color.White
					.BackColor = Color.Orange
				End With
				With lblFailure
					.ForeColor = Color.Gray
					.BackColor = Color.WhiteSmoke
				End With
			Case 3 ' Failure
				With lblOK
					.ForeColor = Color.Gray
					.BackColor = Color.WhiteSmoke
				End With
				With lblWarning
					.ForeColor = Color.Gray
					.BackColor = Color.WhiteSmoke
				End With
				With lblFailure
					.ForeColor = Color.White
					.BackColor = Color.Red
				End With
			Case Else
				With lblOK
					.ForeColor = Color.Gray
					.BackColor = Color.WhiteSmoke
				End With
				With lblWarning
					.ForeColor = Color.Gray
					.BackColor = Color.WhiteSmoke
				End With
				With lblFailure
					.ForeColor = Color.Gray
					.BackColor = Color.WhiteSmoke
				End With
		End Select
	End Sub
	Private Sub InitForm(ByVal MonitorID As Integer)
		SetCurrentStatus(-1)
		Me.lblStatusDate.Text = Nothing
		Me.lblLifetimePercUptime.Text = Nothing

		Dim MonitorMetadata As New PolyMon.Monitors.MonitorMetadata(MonitorID)
		lblMonitor.Text = MonitorMetadata.MonitorName
		lblMonitorType.Text = MonitorMetadata.MonitorType

		'Date/Time Pickers
		With Me.dtpDailyStartDT
			.CustomFormat = cFormatDate
			.Format = DateTimePickerFormat.Custom
		End With
		With Me.dtpDailyEndDT
			.CustomFormat = cFormatDate
			.Format = DateTimePickerFormat.Custom
		End With
		With Me.dtpMonthlyStartDT
			.CustomFormat = cFormatDate
			.Format = DateTimePickerFormat.Custom
		End With
		With Me.dtpMonthlyEndDT
			.CustomFormat = cFormatDate
			.Format = DateTimePickerFormat.Custom
		End With
		With Me.dtpWeeklyStartDT
			.CustomFormat = cFormatDate
			.Format = DateTimePickerFormat.Custom
		End With
		With Me.dtpWeeklyEndDT
			.CustomFormat = cFormatDate
			.Format = DateTimePickerFormat.Custom
		End With
		With Me.dtpCustomStartDT
			.CustomFormat = cFormatDate
			.Format = DateTimePickerFormat.Custom
		End With
		With Me.dtpCustomEndDT
			.CustomFormat = cFormatDate
			.Format = DateTimePickerFormat.Custom
		End With

		'Daily
		Me.lblDailyStartDT.Text = Format(mMonitorStatusDateRanges.DailyStartDT, cFormatDate)
		Me.lblDailyEndDT.Text = Format(mMonitorStatusDateRanges.DailyEndDT, cFormatDate)

		Me.dtpDailyStartDT.MinDate = mMonitorStatusDateRanges.DailyStartDT
		Me.dtpDailyStartDT.MaxDate = mMonitorStatusDateRanges.DailyEndDT
		Me.dtpDailyEndDT.MinDate = mMonitorStatusDateRanges.DailyStartDT
		Me.dtpDailyEndDT.MaxDate = mMonitorStatusDateRanges.DailyEndDT

		Me.dtpDailyStartDT.Value = mMonitorStatusDateRanges.DailyStartDT
		Me.dtpDailyEndDT.Value = mMonitorStatusDateRanges.DailyEndDT

		'Weekly
		Me.dtpWeeklyStartDT.MinDate = mMonitorStatusDateRanges.WeeklyStartDT
		Me.dtpWeeklyStartDT.MaxDate = mMonitorStatusDateRanges.WeeklyEndDT
		Me.dtpWeeklyEndDT.MinDate = mMonitorStatusDateRanges.WeeklyStartDT
		Me.dtpWeeklyEndDT.MaxDate = mMonitorStatusDateRanges.WeeklyEndDT

		Me.dtpWeeklyStartDT.Value = mMonitorStatusDateRanges.WeeklyStartDT
		Me.dtpWeeklyEndDT.Value = mMonitorStatusDateRanges.WeeklyEndDT

		Me.lblWeeklyStartDT.Text = Format(mMonitorStatusDateRanges.WeeklyStartDT, cFormatDate)
		Me.lblWeeklyEndDT.Text = Format(mMonitorStatusDateRanges.WeeklyEndDT, cFormatDate)

		'Monthly
		Me.dtpMonthlyStartDT.MinDate = mMonitorStatusDateRanges.MonthlyStartDT
		Me.dtpMonthlyStartDT.MaxDate = mMonitorStatusDateRanges.MonthlyEndDT
		Me.dtpMonthlyEndDT.MinDate = mMonitorStatusDateRanges.MonthlyStartDT
		Me.dtpMonthlyEndDT.MaxDate = mMonitorStatusDateRanges.MonthlyEndDT

		Me.dtpMonthlyStartDT.Value = mMonitorStatusDateRanges.MonthlyStartDT
		Me.dtpMonthlyEndDT.Value = mMonitorStatusDateRanges.MonthlyEndDT


		Me.lblMonthlyStartDT.Text = Format(mMonitorStatusDateRanges.MonthlyStartDT, cFormatDate)
		Me.lblMonthlyEndDT.Text = Format(mMonitorStatusDateRanges.MonthlyEndDT, cFormatDate)

		'Custom
		Me.dtpCustomStartDT.MinDate = mMonitorStatusDateRanges.RawStartDT
		Me.dtpCustomStartDT.MaxDate = mMonitorStatusDateRanges.RawEndDT
		Me.dtpCustomEndDT.MinDate = mMonitorStatusDateRanges.RawStartDT
		Me.dtpCustomEndDT.MaxDate = mMonitorStatusDateRanges.RawEndDT


		Me.dtpCustomEndDT.Value = mMonitorStatusDateRanges.RawEndDT

		If DateDiff(DateInterval.Day, mMonitorStatusDateRanges.RawStartDT, mMonitorStatusDateRanges.RawEndDT) > 31 Then
			Me.dtpCustomStartDT.Value = DateAdd(DateInterval.Month, -1, mMonitorStatusDateRanges.RawEndDT)
		Else
			Me.dtpCustomStartDT.Value = mMonitorStatusDateRanges.RawStartDT
		End If

		Me.lblCustomStartDT.Text = Format(mMonitorStatusDateRanges.RawStartDT, cFormatDate)
		Me.lblCustomEndDT.Text = Format(mMonitorStatusDateRanges.RawEndDT, cFormatDate)


		'Time Periods
		With Me.cboCustomTimePeriods
			.Items.Clear()

			.Items.Add("Minute")
			.Items.Add("Hour")
			.Items.Add("Day")

			.SelectedIndex = 1
		End With

		Me.chkCustomGrouped.Checked = False
		Me.nudCustomFrequency.Enabled = False
		Me.cboCustomTimePeriods.Enabled = False
	End Sub

	Private Sub RefreshOverview()
		InitForm(mMonitorID)
		LoadCurrentStatus(mMonitorID)

		Dim CurrDate As Date = Now()

		Dim ChartList As Dictionary(Of Integer, ZedGraphControl)

		'Raw Chart
		'Dim ChartStatusRaw As ZedGraphControl = GenChartStatusRaw(mMonitorID, DateAdd(DateInterval.Day, -24, Now()), Now())
		'ChartStatusRaw.Size = New System.Drawing.Size(400, 150)
		'Me.fpnlOverview.Controls.Add(ChartStatusRaw)

		With ChartsOverview
			.ColumnCount = 2
			.Controls.Clear()
			.RowCount = 1
			.RowStyles.Clear()
		End With

		'Daily Status Charts
		ChartList = GenChartsStatusDaily(mMonitorID, DateAdd(DateInterval.Day, -14, CurrDate), CurrDate)
		AddChartsToPanel(ChartList, ChartsOverview, 1)


		'Weekly Status Charts
		ChartList = GenChartsStatusWeekly(mMonitorID, DateAdd(DateInterval.WeekOfYear, -12, CurrDate), CurrDate)
		AddChartsToPanel(ChartList, ChartsOverview, 1)

		'Monthly Status Charts
		ChartList = GenChartsStatusMonthly(mMonitorID, DateAdd(DateInterval.Month, -24, CurrDate), CurrDate)
		AddChartsToPanel(ChartList, ChartsOverview, 1)

		'Raw Counter Charts
		ChartList = GenChartsCountersRaw(mMonitorID, DateAdd(DateInterval.Hour, -24, CurrDate), CurrDate)
		AddChartsToPanel(ChartList, ChartsOverview, 1)

		'Daily Counter Charts
		ChartList = GenChartsCountersDaily(mMonitorID, DateAdd(DateInterval.Day, -14, CurrDate), CurrDate)
		AddChartsToPanel(ChartList, ChartsOverview, 1)

		'Weekly Counter Charts
		ChartList = GenChartsCountersWeekly(mMonitorID, DateAdd(DateInterval.WeekOfYear, -12, CurrDate), CurrDate)
		AddChartsToPanel(ChartList, ChartsOverview, 1)

		'Monthly Counter Charts
		ChartList = GenChartsCountersMonthly(mMonitorID, DateAdd(DateInterval.Month, -24, CurrDate), CurrDate)
		AddChartsToPanel(ChartList, ChartsOverview, 1)
	End Sub
	Private Sub RunDaily()
		With ChartsDaily
			.ColumnCount = 2
			.Controls.Clear()
			.RowCount = 1
			.RowStyles.Clear()
		End With

		Me.btnViewData_Daily.Enabled = True
		mStatusData_Daily = Nothing
		mCounterData_Daily = Nothing

		Dim StartDT As Date = dtpDailyStartDT.Value
		Dim EndDT As Date = dtpDailyEndDT.Value

		'Strip out any times...
		StartDT = CDate(Format(StartDT, "MMM dd, yyyy") & " 00:00:00")
		EndDT = CDate(Format(EndDT, "MMM dd, yyyy") & " 23:59:59")

		Dim ChartList As Dictionary(Of Integer, ZedGraphControl)

		'Daily Status Charts
		ChartList = GenChartsStatusDaily(mMonitorID, StartDT, EndDT)
		AddChartsToPanel(ChartList, ChartsDaily, 1)

		'Daily Counter Charts
		'ChartList = GenChartsCountersDaily(mMonitorID, StartDT, EndDT)
		ChartList = GenChartsCountersDaily(mMonitorID, StartDT, EndDT)
		AddChartsToPanel(ChartList, ChartsDaily, 1)
	End Sub
	Private Sub RunWeekly()
		With ChartsWeekly
			.ColumnCount = 2
			.Controls.Clear()
			.RowCount = 1
			.RowStyles.Clear()
		End With
		btnViewData_Weekly.Enabled = True

		Dim StartDT As Date = dtpWeeklyStartDT.Value
		Dim EndDT As Date = dtpWeeklyEndDT.Value

		'Strip out any times...
		StartDT = CDate(Format(StartDT, "MMM dd, yyyy") & " 00:00:00")
		EndDT = CDate(Format(EndDT, "MMM dd, yyyy") & " 23:59:59")

		Dim ChartList As Dictionary(Of Integer, ZedGraphControl)

		'Weekly Status Charts
		ChartList = GenChartsStatusWeekly(mMonitorID, StartDT, EndDT)
		AddChartsToPanel(ChartList, ChartsWeekly, 1)

		'Weekly Counter Charts
		ChartList = GenChartsCountersWeekly(mMonitorID, StartDT, EndDT)
		AddChartsToPanel(ChartList, ChartsWeekly, 1)
	End Sub
	Private Sub RunMonthly()
		With ChartsMonthly
			.ColumnCount = 2
			.Controls.Clear()
			.RowCount = 1
			.RowStyles.Clear()
		End With
		btnViewData_Monthly.Enabled = True

		Dim StartDT As Date = dtpMonthlyStartDT.Value
		Dim EndDT As Date = dtpMonthlyEndDT.Value

		'Strip out any times...
		StartDT = CDate(Format(StartDT, "MMM dd, yyyy") & " 00:00:00")
		EndDT = CDate(Format(EndDT, "MMM dd, yyyy") & " 23:59:59")

		Dim ChartList As Dictionary(Of Integer, ZedGraphControl)

		'Monthly Status Charts
		ChartList = GenChartsStatusMonthly(mMonitorID, StartDT, EndDT)
		AddChartsToPanel(ChartList, ChartsMonthly, 1)

		'Monthly Counter Charts
		ChartList = GenChartsCountersMonthly(mMonitorID, StartDT, EndDT)
		AddChartsToPanel(ChartList, ChartsMonthly, 1)
	End Sub
	Private Sub RunCustom()
		Dim StartDT As Date = dtpCustomStartDT.Value
		Dim EndDT As Date = dtpCustomEndDT.Value
		Dim IsGrouped As Boolean = Me.chkCustomGrouped.Checked
		Dim Frequency As Integer
		Dim FrequencyMinutes As Integer
		Dim ChartList As Dictionary(Of Integer, ZedGraphControl)

		With ChartsCustom
			.ColumnCount = 2
			.Controls.Clear()
			.RowCount = 1
			.RowStyles.Clear()
		End With
		btnViewData_Custom.Enabled = True

		'Strip out any times...
		StartDT = CDate(Format(StartDT, "MMM dd, yyyy") & " 00:00:00")
		EndDT = CDate(Format(EndDT, "MMM dd, yyyy") & " 23:59:59")


		If IsGrouped Then
			Frequency = CInt(Me.nudCustomFrequency.Value)
			Select Case Me.cboCustomTimePeriods.Text
				Case "Minute"
					FrequencyMinutes = Frequency
				Case "Hour"
					FrequencyMinutes = Frequency * 60
				Case "Day"
					FrequencyMinutes = Frequency * 60 * 24
			End Select

			'Generate Status Frequency Charts
			ChartList = GenChartsStatusCustom(mMonitorID, StartDT, EndDT, FrequencyMinutes)
			AddChartsToPanel(ChartList, ChartsCustom, 2)

			'Generate Grouped (Averaged) Counter Charts
			ChartList = GenChartsCountersCustom(mMonitorID, StartDT, EndDT, FrequencyMinutes)
			AddChartsToPanel(ChartList, ChartsCustom, 2)
		Else
			'Status Charts
			ChartList = GenChartsStatusRaw(mMonitorID, StartDT, EndDT)
			AddChartsToPanel(ChartList, ChartsCustom, 2)


			'Generate Counter Charts
			ChartList = GenChartsCountersRaw(mMonitorID, StartDT, EndDT)
			AddChartsToPanel(ChartList, ChartsCustom, 2)
		End If
	End Sub


	Private Sub AddChartsToPanel(ByRef Charts As Dictionary(Of Integer, ZedGraphControl), ByRef Panel As TableLayoutPanel, ByVal ColSpan As Integer)
		Dim Cnt As Integer = 0
		Dim Column As Integer = 0
		Dim NumRows As Integer = Panel.RowCount
		Dim CurrRow As Integer
		Dim Chart As ZedGraphControl

		If ColSpan > 2 Then ColSpan = 2
		If ColSpan < 1 Then ColSpan = 1

		Dim ChartNum As Integer

		For Each ChartNum In Charts.Keys
			Chart = Charts.Item(ChartNum)
			If ColSpan = 1 Then
				'2 Charts per row
				Cnt += 1
				If Cnt Mod 2 = 1 Then
					'If panel has no child controls, then we are starting with
					'a blank panel and an empty row already exists, so use it
					'instead of moving to next row.
					If Panel.Controls.Count > 0 Then
						Panel.RowCount += 1
						CurrRow = Panel.RowCount - 1
					Else
						CurrRow = 0
					End If
					Panel.RowStyles.Add(New RowStyle(SizeType.Absolute, cChartHeight + Panel.Padding.Vertical + Panel.Margin.Vertical))
					Column = 0
				Else
					Column = 1
				End If

				Chart.Dock = DockStyle.Fill
				Chart.MinimumSize = New System.Drawing.Size(0, 180)
				Chart.MaximumSize = New System.Drawing.Size(0, 180)
				Panel.Controls.Add(Chart, Column, CurrRow)
			Else
				'1 Chart per row - each chart will span 2 columns
				Cnt += 1
				If Panel.Controls.Count > 0 Then
					Panel.RowCount += 1
					'CurrRow = NumRows
					CurrRow = Panel.RowCount - 1
				Else
					CurrRow = 0
				End If
				Panel.RowStyles.Add(New RowStyle(SizeType.Absolute, cChartHeight + Panel.Padding.Vertical + Panel.Margin.Vertical))
				Chart.Dock = DockStyle.Fill
				Chart.MinimumSize = New System.Drawing.Size(0, 180)
				Chart.MaximumSize = New System.Drawing.Size(0, 180)
				Panel.Controls.Add(Chart, 0, CurrRow)
				Panel.SetColumnSpan(Chart, 2)
			End If
		Next
	End Sub

	Private Class MonitorStatusDateRanges
		Private mRawStartDT As Date
		Private mRawEndDT As Date
		Private mDailyStartDT As Date
		Private mDailyEndDT As Date
		Private mWeeklyStartDT As Date
		Private mWeeklyEndDT As Date
		Private mMonthlyStartDT As Date
		Private mMonthlyEndDT As Date

		Public Sub New(ByVal MonitorID As Integer, ByVal SQLConnStr As String)
			Dim SQLConn As New SqlConnection(SQLConnStr)

			Dim prmMonitorID As New SqlParameter
			With prmMonitorID
				.ParameterName = "@MonitorID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Input
				.Value = MonitorID
			End With

			Dim SQLCmd As New SqlCommand
			With SQLCmd
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandTimeout = 30 '30 seconds
				.CommandText = "rpt_GetStatusDateRanges"
				.Parameters.Add(prmMonitorID)
			End With

			Dim drResults As SqlDataReader

			Try
				SQLConn.Open()
				drResults = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection)
				While drResults.Read()
					With drResults
						mRawStartDT = ExtractDate(.Item("RawStartDT"))
						mRawEndDT = ExtractDate(.Item("RawEndDT"))
						mDailyStartDT = ExtractDate(.Item("DailyStartDT"))
						mDailyEndDT = ExtractDate(.Item("DailyEndDT"))
						mWeeklyStartDT = ExtractDate(.Item("WeeklyStartDT"))
						mWeeklyEndDT = ExtractDate(.Item("WeeklyEndDT"))
						mMonthlyStartDT = ExtractDate(.Item("MonthlyStartDT"))
						mMonthlyEndDT = ExtractDate(.Item("MonthlyEndDT"))
					End With
				End While
			Catch ex As Exception
				MsgBox("Error running rpt_GetStatusDateRanges." & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End Try
		End Sub

		Public ReadOnly Property RawStartDT() As Date
			Get
				Return mRawStartDT
			End Get
		End Property
		Public ReadOnly Property RawEndDT() As Date
			Get
				Return mRawEndDT
			End Get
		End Property
		Public ReadOnly Property DailyStartDT() As Date
			Get
				Return mDailyStartDT
			End Get
		End Property
		Public ReadOnly Property DailyEndDT() As Date
			Get
				Return mDailyEndDT
			End Get
		End Property
		Public ReadOnly Property WeeklyStartDT() As Date
			Get
				Return mWeeklyStartDT
			End Get
		End Property
		Public ReadOnly Property WeeklyEndDT() As Date
			Get
				Return mWeeklyEndDT
			End Get
		End Property
		Public ReadOnly Property MonthlyStartDT() As Date
			Get
				Return mMonthlyStartDT
			End Get
		End Property
		Public ReadOnly Property MonthlyEndDT() As Date
			Get
				Return mMonthlyEndDT
			End Get
		End Property

		Private Function ExtractDate(ByRef Obj As Object) As Date
			Try
				If Obj Is Nothing OrElse IsDBNull(Obj) Then
					Return Now()
				Else
					Return CDate(Obj)
				End If
			Catch ex As Exception
				Return Now()
			End Try
		End Function
	End Class
#End Region

#Region "Chart/Report Generators"
	Private Function GenChartsStatusRaw(ByVal MonitorID As Integer, ByVal StartDT As Date, ByVal EndDT As Date) As Dictionary(Of Integer, ZedGraphControl)
		Dim Chart As New ZedGraphControl
		Dim ChartNum As Integer = 0

		GenChartsStatusRaw = New Dictionary(Of Integer, ZedGraphControl)

		'Retrieve data
		Dim SQLConn As New SqlConnection(mSQLConn)

		Dim prmMonitorID As New SqlParameter
		With prmMonitorID
			.ParameterName = "@MonitorID"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = MonitorID
		End With

		Dim prmStartDT As New SqlParameter
		With prmStartDT
			.ParameterName = "@StartDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = StartDT
		End With

		Dim prmEndDT As New SqlParameter
		With prmEndDT
			.ParameterName = "@EndDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = EndDT
		End With

		Dim SQLCmd As New SqlCommand
		With SQLCmd
			.Connection = SQLConn
			.CommandType = CommandType.StoredProcedure
			.CommandTimeout = 180 '3 minutes
			.CommandText = "rpt_StatusData_Raw"
			.Parameters.Add(prmMonitorID)
			.Parameters.Add(prmStartDT)
			.Parameters.Add(prmEndDT)
		End With

		Dim tblResults As DataTable
		Dim dsResults As New DataSet
		Dim daSQL As New SqlDataAdapter(SQLCmd)

		Try
			SQLConn.Open()
			daSQL.Fill(dsResults)
			If dsResults.Tables.Count > 0 Then
				tblResults = dsResults.Tables(0)

				tblResults.Columns("DT_Raw").ExtendedProperties.Add("Visible", False)
				With tblResults.Columns("DT_Display")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Event Date"
				End With
				With tblResults.Columns("IsOK")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Is OK"
				End With
				With tblResults.Columns("IsWarning")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Is Warning"
				End With
				With tblResults.Columns("IsFailure")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Is Failure"
				End With
				With tblResults.Columns("UpTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "UpTime"
				End With
				With tblResults.Columns("DownTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "DownTime"
				End With
				mStatusData_Custom = tblResults

				'Do no plot anything if rows exceed cMaxDataPts
				If tblResults.Rows.Count > mMaxDataPts Then
					Dim dummy As New ZedGraph.ZedGraphControl
					dummy.IsAntiAlias = True
					With dummy.GraphPane
						.Title.Text = "Status"
						.XAxis.Type = AxisType.Date
						.XAxis.Scale.Format = cFormatDate
						.XAxis.Scale.FontSpec.Size = 11
						.XAxis.Title.IsVisible = False

						.YAxis.Scale.FontSpec.Size = 11
						.YAxis.Title.IsVisible = False
						.YAxis.Scale.MinGrace = 0
						.YAxis.Scale.MaxGrace = 0

						.BaseDimension = 5.5
						.Legend.IsVisible = False
					End With
					Me.SetErrorWatermark(String.Format(cMaxReachedMsg, mMaxDataPts), dummy)
					GenChartsStatusRaw.Add(ChartNum, dummy)
					ChartNum += 1
					Exit Function
				End If '<= cMaxDataPts


				With Chart
					.GraphPane.Title.Text = "Status"
					.IsAntiAlias = True
					.IsShowPointValues = True
					.IsShowCursorValues = False
				End With


				Dim myPane As GraphPane = Chart.GraphPane
				With myPane
					.XAxis.Type = AxisType.Date
					.XAxis.Scale.Format = cFormatDateHM
					.XAxis.Scale.FontSpec.Size = 11
					.XAxis.Title.IsVisible = False
					.XAxis.Scale.MinGrace = 0
					.XAxis.Scale.MaxGrace = 0

					.YAxis.Scale.FontSpec.Size = 11
					.YAxis.Title.IsVisible = False
					.YAxis.Scale.MinGrace = 0
					.YAxis.Scale.MaxGrace = 0

					.BaseDimension = 5.5
					.Legend.IsVisible = True
					.Legend.Border.IsVisible = False
				End With

				myPane.XAxis.Type = AxisType.Date

				Dim dsplOK As New DataSourcePointList
				With dsplOK
					.DataSource = tblResults
					.XDataMember = "DT_Raw"
					.YDataMember = "IsOK"
					.ZDataMember = Nothing
				End With

				Dim dsplWarning As New DataSourcePointList
				With dsplWarning
					.DataSource = tblResults
					.XDataMember = "DT_Raw"
					.YDataMember = "IsWarning"
					.ZDataMember = Nothing
				End With

				Dim dsplFailure As New DataSourcePointList
				With dsplFailure
					.DataSource = tblResults
					.XDataMember = "DT_Raw"
					.YDataMember = "IsFailure"
					.ZDataMember = Nothing
				End With

				Dim curveOK As LineItem = myPane.AddCurve("OK", dsplOK, Color.Blue, SymbolType.None)
				curveOK.Line.StepType = StepType.ForwardStep

				Dim curveWarning As LineItem = myPane.AddCurve("Warning", dsplWarning, Color.Orange, SymbolType.None)
				curveWarning.Line.StepType = StepType.ForwardStep

				Dim curveFailure As LineItem = myPane.AddCurve("Failure", dsplFailure, Color.Red, SymbolType.None)
				curveFailure.Line.StepType = StepType.ForwardStep


				'Pad YAxis by 10%
				Chart.AxisChange()
				Dim YAxisRange As Double = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
				Dim Extra As Double = YAxisRange * 0.1
				myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
				myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra


				Chart.AxisChange()
				Chart.Refresh()
			End If

			GenChartsStatusRaw.Add(ChartNum, Chart)
			ChartNum += 1
		Catch ex As Exception
			MsgBox("Error running report:" & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Finally
			If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
			daSQL.Dispose()
			SQLConn.Dispose()
		End Try
	End Function
	Private Function GenChartsStatusDaily(ByVal MonitorID As Integer, ByVal StartDT As Date, ByVal EndDT As Date) As Dictionary(Of Integer, ZedGraphControl)
		Dim ChartStatus As New ZedGraphControl
		With ChartStatus
			.GraphPane.Title.Text = "Status Frequency - Daily"
			.Name = "chartDailyStatus"
			.IsAntiAlias = True
			.IsShowPointValues = True
		End With


		Dim ChartUptime As New ZedGraphControl
		With ChartUptime
			.GraphPane.Title.Text = "% Uptime - Daily"
			.Name = "chartDailyUptime"
			.IsAntiAlias = True
			.IsShowPointValues = True
		End With


		GenChartsStatusDaily = New Dictionary(Of Integer, ZedGraphControl)
		Dim ChartNum As Integer = 0


		'Retrieve data
		Dim SQLConn As New SqlConnection(mSQLConn)

		Dim prmMonitorID As New SqlParameter
		With prmMonitorID
			.ParameterName = "@MonitorID"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = MonitorID
		End With

		Dim prmStartDT As New SqlParameter
		With prmStartDT
			.ParameterName = "@StartDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = StartDT
		End With

		Dim prmEndDT As New SqlParameter
		With prmEndDT
			.ParameterName = "@EndDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = EndDT
		End With

		Dim SQLCmd As New SqlCommand
		With SQLCmd
			.Connection = SQLConn
			.CommandType = CommandType.StoredProcedure
			.CommandTimeout = 180 '3 minutes
			.CommandText = "rpt_StatusData_Daily"
			.Parameters.Add(prmMonitorID)
			.Parameters.Add(prmStartDT)
			.Parameters.Add(prmEndDT)
		End With

		Dim tblResults As DataTable
		Dim dsResults As New DataSet
		Dim daSQL As New SqlDataAdapter(SQLCmd)

		Try
			SQLConn.Open()
			daSQL.Fill(dsResults)
			If dsResults.Tables.Count > 0 Then
				tblResults = dsResults.Tables(0)

				tblResults.Columns("DT_Raw").ExtendedProperties.Add("Visible", False)
				With tblResults.Columns("DT_Display")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Date"
				End With
				With tblResults.Columns("OKCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# OK"
				End With
				With tblResults.Columns("WarningCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# Warnings"
				End With
				With tblResults.Columns("FailureCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# Failures"
				End With
				With tblResults.Columns("TotalUpTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Total UpTime (secs)"
				End With
				With tblResults.Columns("TotalDownTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Total DownTime (secs)"
				End With
				With tblResults.Columns("PercUpTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "% UpTime"
				End With
				mStatusData_Daily = tblResults


				'Status Chart
				Dim myPane As GraphPane = ChartStatus.GraphPane

				myPane.XAxis.Type = AxisType.Date
				myPane.XAxis.Scale.Format = cFormatDate
				myPane.XAxis.Scale.FontSpec.Size = 11
				myPane.XAxis.Title.IsVisible = False
				myPane.XAxis.Scale.MinGrace = 0
				myPane.XAxis.Scale.MaxGrace = 0

				myPane.YAxis.Scale.FontSpec.Size = 11
				myPane.YAxis.Title.IsVisible = False
				myPane.YAxis.Scale.MinGrace = 0
				myPane.YAxis.Scale.MaxGrace = 0
				myPane.BaseDimension = 5.5
				myPane.Legend.Border.IsVisible = False

				'Dim dsplOK As New DataSourcePointList
				'With dsplOK
				'	.DataSource = tblResults
				'	.XDataMember = "DT_Raw"
				'	.YDataMember = "OKCount"
				'	.ZDataMember = Nothing
				'End With

				Dim dsplWarning As New DataSourcePointList
				With dsplWarning
					.DataSource = tblResults
					.XDataMember = "DT_Raw"
					.YDataMember = "WarningCount"
					.ZDataMember = Nothing
				End With

				Dim dsplFailure As New DataSourcePointList
				With dsplFailure
					.DataSource = tblResults
					.XDataMember = "DT_Raw"
					.YDataMember = "FailureCount"
					.ZDataMember = Nothing
				End With

				Dim dsplPercUpTime As New DataSourcePointList
				With dsplPercUpTime
					.DataSource = tblResults
					.XDataMember = "DT_Raw"
					.YDataMember = "PercUptime"
					.ZDataMember = Nothing
				End With

				'Dim curveOK As LineItem = myPane.AddCurve("OK", dsplOK, Color.Blue, SymbolType.None)
				'curveOK.Line.StepType = StepType.ForwardStep

				Dim curveWarning As LineItem = myPane.AddCurve("Warning", dsplWarning, Color.Orange, SymbolType.None)
				curveWarning.Line.StepType = StepType.RearwardStep

				Dim curveFailure As LineItem = myPane.AddCurve("Failure", dsplFailure, Color.Red, SymbolType.None)
				curveFailure.Line.StepType = StepType.RearwardStep


				'Pad YAxis by 10%
				ChartStatus.AxisChange()
				Dim YAxisRange As Double = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
				Dim Extra As Double = YAxisRange * 0.1
				myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
				myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

				ChartStatus.AxisChange()
				ChartStatus.Refresh()
				GenChartsStatusDaily.Add(ChartNum, ChartStatus)
				ChartNum += 1

				'% Uptime Chart
				myPane = ChartUptime.GraphPane

				myPane.XAxis.Type = AxisType.Date
				myPane.XAxis.Scale.Format = cFormatDate
				myPane.XAxis.Scale.FontSpec.Size = 11
				myPane.XAxis.Title.IsVisible = False
				myPane.XAxis.Scale.MinGrace = 0
				myPane.XAxis.Scale.MaxGrace = 0
				myPane.YAxis.Scale.FontSpec.Size = 11
				myPane.YAxis.Title.IsVisible = False
				myPane.YAxis.Scale.MinGrace = 0
				myPane.YAxis.Scale.MaxGrace = 0
				myPane.BaseDimension = 5.5
				myPane.Legend.Border.IsVisible = False

				If tblResults.Rows.Count > mSymbolMaxPts Then
					Dim curvePercUpTime As LineItem = myPane.AddCurve("% Uptime", dsplPercUpTime, Color.Blue, SymbolType.None)
				Else
					Dim curvePercUpTime As LineItem = myPane.AddCurve("% Uptime", dsplPercUpTime, Color.Blue, mPointSymbolType)
					curvePercUpTime.Symbol.Fill.Color = mPointSymbolFillColor
					curvePercUpTime.Symbol.Fill.IsVisible = mPointSymbolFillIsVisible
					curvePercUpTime.Symbol.Border.IsVisible = mPointSymbolBorderIsVisible
					curvePercUpTime.Symbol.Size = mPointSymbolSize
				End If

				'Pad YAxis by 10%
				ChartUptime.AxisChange()
				YAxisRange = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
				Extra = YAxisRange * 0.1
				myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
				myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

				ChartUptime.AxisChange()
				ChartUptime.Refresh()
				GenChartsStatusDaily.Add(ChartNum, ChartUptime)
				ChartNum += 1
			End If

		Catch ex As Exception
			MsgBox("Error running report:" & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Finally
			If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
			daSQL.Dispose()
			SQLConn.Dispose()
		End Try

	End Function
	Private Function GenChartsStatusWeekly(ByVal MonitorID As Integer, ByVal StartDT As Date, ByVal EndDT As Date) As Dictionary(Of Integer, ZedGraphControl)
		Dim ChartStatus As New ZedGraphControl
		With ChartStatus
			.GraphPane.Title.Text = "Status Frequency - Weekly"
			.Name = "chartWeeklyStatus"
			.IsAntiAlias = True
			.IsShowPointValues = True
		End With


		Dim ChartUptime As New ZedGraphControl
		With ChartUptime
			.GraphPane.Title.Text = "% Uptime - Weekly"
			.Name = "chartWeeklyUptime"
			.IsAntiAlias = True
			.IsShowPointValues = True
		End With


		GenChartsStatusWeekly = New Dictionary(Of Integer, ZedGraphControl)
		Dim ChartNum As Integer = 0


		'Retrieve data
		Dim SQLConn As New SqlConnection(mSQLConn)

		Dim prmMonitorID As New SqlParameter
		With prmMonitorID
			.ParameterName = "@MonitorID"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = MonitorID
		End With

		Dim prmStartDT As New SqlParameter
		With prmStartDT
			.ParameterName = "@StartDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = StartDT
		End With

		Dim prmEndDT As New SqlParameter
		With prmEndDT
			.ParameterName = "@EndDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = EndDT
		End With

		Dim SQLCmd As New SqlCommand
		With SQLCmd
			.Connection = SQLConn
			.CommandType = CommandType.StoredProcedure
			.CommandTimeout = 180 '3 minutes
			.CommandText = "rpt_StatusData_Weekly"
			.Parameters.Add(prmMonitorID)
			.Parameters.Add(prmStartDT)
			.Parameters.Add(prmEndDT)
		End With

		Dim tblResults As DataTable
		Dim dsResults As New DataSet
		Dim daSQL As New SqlDataAdapter(SQLCmd)

		Try
			SQLConn.Open()
			daSQL.Fill(dsResults)
			If dsResults.Tables.Count > 0 Then
				tblResults = dsResults.Tables(0)


				tblResults.Columns("StartDT_Raw").ExtendedProperties.Add("Visible", False)
				tblResults.Columns("EndDT_Raw").ExtendedProperties.Add("Visible", False)
				With tblResults.Columns("Year")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Year"
				End With
				With tblResults.Columns("WeekOfYear")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Week"
				End With
				With tblResults.Columns("StartDT_Display")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Start Date"
				End With
				With tblResults.Columns("EndDT_Display")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "End Date"
				End With
				With tblResults.Columns("OKCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# OK"
				End With
				With tblResults.Columns("WarningCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# Warnings"
				End With
				With tblResults.Columns("FailureCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# Failures"
				End With
				With tblResults.Columns("TotalUpTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Total UpTime (secs)"
				End With
				With tblResults.Columns("TotalDownTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Total DownTime (secs)"
				End With
				With tblResults.Columns("PercUpTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "% UpTime"
				End With
				mStatusData_Weekly = tblResults


				'Status Chart
				Dim myPane As GraphPane = ChartStatus.GraphPane

				myPane.XAxis.Type = AxisType.Date
				myPane.XAxis.Scale.Format = cFormatDate
				myPane.XAxis.Scale.FontSpec.Size = 11
				myPane.XAxis.Title.IsVisible = False
				myPane.XAxis.Scale.MinGrace = 0
				myPane.XAxis.Scale.MaxGrace = 0
				myPane.YAxis.Scale.FontSpec.Size = 11
				myPane.YAxis.Title.IsVisible = False
				myPane.YAxis.Scale.MinGrace = 0
				myPane.YAxis.Scale.MaxGrace = 0
				myPane.BaseDimension = 5.5
				myPane.Legend.Border.IsVisible = False


				'Dim dsplOK As New DataSourcePointList
				'With dsplOK
				'	.DataSource = tblResults
				'	.XDataMember = "StartDT_Raw"
				'	.YDataMember = "OKCount"
				'	.ZDataMember = Nothing
				'End With

				Dim dsplWarning As New DataSourcePointList
				With dsplWarning
					.DataSource = tblResults
					.XDataMember = "StartDT_Raw"
					.YDataMember = "WarningCount"
					.ZDataMember = Nothing
				End With

				Dim dsplFailure As New DataSourcePointList
				With dsplFailure
					.DataSource = tblResults
					.XDataMember = "StartDT_Raw"
					.YDataMember = "FailureCount"
					.ZDataMember = Nothing
				End With

				Dim dsplPercUpTime As New DataSourcePointList
				With dsplPercUpTime
					.DataSource = tblResults
					.XDataMember = "StartDT_Raw"
					.YDataMember = "PercUptime"
					.ZDataMember = Nothing
				End With

				'Dim curveOK As LineItem = myPane.AddCurve("OK", dsplOK, Color.Blue, SymbolType.None)
				'curveOK.Line.StepType = StepType.ForwardStep

				Dim curveWarning As LineItem = myPane.AddCurve("Warning", dsplWarning, Color.Orange, SymbolType.None)
				curveWarning.Line.StepType = StepType.RearwardStep

				Dim curveFailure As LineItem = myPane.AddCurve("Failure", dsplFailure, Color.Red, SymbolType.None)
				curveFailure.Line.StepType = StepType.RearwardStep

				'Pad YAxis by 10%
				ChartStatus.AxisChange()
				Dim YAxisRange As Double = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
				Dim Extra As Double = YAxisRange * 0.1
				myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
				myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

				ChartStatus.AxisChange()
				ChartStatus.Refresh()
				GenChartsStatusWeekly.Add(ChartNum, ChartStatus)
				ChartNum += 1


				'% Uptime Chart
				myPane = ChartUptime.GraphPane

				myPane.XAxis.Type = AxisType.Date
				myPane.XAxis.Scale.Format = cFormatDate
				myPane.XAxis.Scale.FontSpec.Size = 11
				myPane.XAxis.Title.IsVisible = False
				myPane.XAxis.Scale.MinGrace = 0
				myPane.XAxis.Scale.MaxGrace = 0
				myPane.YAxis.Scale.FontSpec.Size = 11
				myPane.YAxis.Title.IsVisible = False
				myPane.YAxis.Scale.MinGrace = 0
				myPane.YAxis.Scale.MaxGrace = 0
				myPane.BaseDimension = 5.5
				myPane.Legend.Border.IsVisible = False

				If tblResults.Rows.Count > mSymbolMaxPts Then
					Dim curvePercUpTime As LineItem = myPane.AddCurve("% Uptime", dsplPercUpTime, Color.Blue, SymbolType.None)
				Else
					Dim curvePercUpTime As LineItem = myPane.AddCurve("% Uptime", dsplPercUpTime, Color.Blue, mPointSymbolType)
					curvePercUpTime.Symbol.Fill.Color = mPointSymbolFillColor
					curvePercUpTime.Symbol.Fill.IsVisible = mPointSymbolFillIsVisible
					curvePercUpTime.Symbol.Border.IsVisible = mPointSymbolBorderIsVisible
					curvePercUpTime.Symbol.Size = mPointSymbolSize
				End If

				'Pad YAxis by 10%
				ChartUptime.AxisChange()
				YAxisRange = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
				Extra = YAxisRange * 0.1
				myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
				myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

				ChartUptime.AxisChange()
				ChartUptime.Refresh()
				GenChartsStatusWeekly.Add(ChartNum, ChartUptime)
				ChartNum += 1
			End If

		Catch ex As Exception
			MsgBox("Error running report:" & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Finally
			If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
			daSQL.Dispose()
			SQLConn.Dispose()
		End Try

	End Function
	Private Function GenChartsStatusMonthly(ByVal MonitorID As Integer, ByVal StartDT As Date, ByVal EndDT As Date) As Dictionary(Of Integer, ZedGraphControl)
		Dim ChartStatus As New ZedGraphControl
		With ChartStatus
			.GraphPane.Title.Text = "Status Frequency - Monthly"
			.Name = "chartMonthlyStatus"
			.IsAntiAlias = True
			.IsShowPointValues = True
		End With


		Dim ChartUptime As New ZedGraphControl
		With ChartUptime
			.GraphPane.Title.Text = "% Uptime - Monthly"
			.Name = "chartMonthlyUptime"
			.IsAntiAlias = True
			.IsShowPointValues = True
		End With


		GenChartsStatusMonthly = New Dictionary(Of Integer, ZedGraphControl)
		Dim ChartNum As Integer = 0

		'Retrieve data
		Dim SQLConn As New SqlConnection(mSQLConn)

		Dim prmMonitorID As New SqlParameter
		With prmMonitorID
			.ParameterName = "@MonitorID"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = MonitorID
		End With

		Dim prmStartDT As New SqlParameter
		With prmStartDT
			.ParameterName = "@StartDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = StartDT
		End With

		Dim prmEndDT As New SqlParameter
		With prmEndDT
			.ParameterName = "@EndDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = EndDT
		End With

		Dim SQLCmd As New SqlCommand
		With SQLCmd
			.Connection = SQLConn
			.CommandType = CommandType.StoredProcedure
			.CommandTimeout = 180 '3 minutes
			.CommandText = "rpt_StatusData_Monthly"
			.Parameters.Add(prmMonitorID)
			.Parameters.Add(prmStartDT)
			.Parameters.Add(prmEndDT)
		End With

		Dim tblResults As DataTable
		Dim dsResults As New DataSet
		Dim daSQL As New SqlDataAdapter(SQLCmd)

		Try
			SQLConn.Open()
			daSQL.Fill(dsResults)
			If dsResults.Tables.Count > 0 Then
				tblResults = dsResults.Tables(0)

				tblResults.Columns("StartDT_Raw").ExtendedProperties.Add("Visible", False)
				tblResults.Columns("EndDT_Raw").ExtendedProperties.Add("Visible", False)
				With tblResults.Columns("Year")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Year"
				End With
				With tblResults.Columns("Month")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Month"
				End With
				With tblResults.Columns("StartDT_Display")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Start Date"
				End With
				With tblResults.Columns("EndDT_Display")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "End Date"
				End With
				With tblResults.Columns("OKCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# OK"
				End With
				With tblResults.Columns("WarningCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# Warnings"
				End With
				With tblResults.Columns("FailureCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# Failures"
				End With
				With tblResults.Columns("TotalUpTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Total UpTime (secs)"
				End With
				With tblResults.Columns("TotalDownTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Total DownTime (secs)"
				End With
				With tblResults.Columns("PercUpTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "% UpTime"
				End With
				mStatusData_Monthly = tblResults

				'Status Chart
				Dim myPane As GraphPane = ChartStatus.GraphPane

				myPane.XAxis.Type = AxisType.Date
				myPane.XAxis.Scale.Format = cFormatDate
				myPane.XAxis.Scale.FontSpec.Size = 11
				myPane.XAxis.Title.IsVisible = False
				myPane.XAxis.Scale.MinGrace = 0
				myPane.XAxis.Scale.MaxGrace = 0
				myPane.YAxis.Scale.FontSpec.Size = 11
				myPane.YAxis.Title.IsVisible = False
				myPane.YAxis.Scale.MinGrace = 0
				myPane.YAxis.Scale.MaxGrace = 0
				myPane.BaseDimension = 5.5
				myPane.Legend.Border.IsVisible = False


				'Dim dsplOK As New DataSourcePointList
				'With dsplOK
				'	.DataSource = tblResults
				'	.XDataMember = "StartDT_Raw"
				'	.YDataMember = "OKCount"
				'	.ZDataMember = Nothing
				'End With

				Dim dsplWarning As New DataSourcePointList
				With dsplWarning
					.DataSource = tblResults
					.XDataMember = "StartDT_Raw"
					.YDataMember = "WarningCount"
					.ZDataMember = Nothing
				End With

				Dim dsplFailure As New DataSourcePointList
				With dsplFailure
					.DataSource = tblResults
					.XDataMember = "StartDT_Raw"
					.YDataMember = "FailureCount"
					.ZDataMember = Nothing
				End With

				Dim dsplPercUpTime As New DataSourcePointList
				With dsplPercUpTime
					.DataSource = tblResults
					.XDataMember = "StartDT_Raw"
					.YDataMember = "PercUptime"
					.ZDataMember = Nothing
				End With

				'Dim curveOK As LineItem = myPane.AddCurve("OK", dsplOK, Color.Blue, SymbolType.None)
				'curveOK.Line.StepType = StepType.ForwardStep

				Dim curveWarning As LineItem = myPane.AddCurve("Warning", dsplWarning, Color.Orange, SymbolType.None)
				curveWarning.Line.StepType = StepType.RearwardStep

				Dim curveFailure As LineItem = myPane.AddCurve("Failure", dsplFailure, Color.Red, SymbolType.None)
				curveFailure.Line.StepType = StepType.RearwardStep

				'Pad YAxis by 10%
				ChartStatus.AxisChange()
				Dim YAxisRange As Double = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
				Dim Extra As Double = YAxisRange * 0.1
				myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
				myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

				ChartStatus.AxisChange()
				ChartStatus.Refresh()
				GenChartsStatusMonthly.Add(ChartNum, ChartStatus)
				ChartNum += 1


				'% Uptime Chart
				myPane = ChartUptime.GraphPane

				myPane.XAxis.Type = AxisType.Date
				myPane.XAxis.Scale.Format = cFormatDate
				myPane.XAxis.Scale.FontSpec.Size = 11
				myPane.XAxis.Title.IsVisible = False
				myPane.XAxis.Scale.MinGrace = 0
				myPane.XAxis.Scale.MaxGrace = 0
				myPane.YAxis.Scale.FontSpec.Size = 11
				myPane.YAxis.Title.IsVisible = False
				myPane.YAxis.Scale.MinGrace = 0
				myPane.YAxis.Scale.MaxGrace = 0
				myPane.BaseDimension = 5.5
				myPane.Legend.Border.IsVisible = False

				If tblResults.Rows.Count > mSymbolMaxPts Then
					Dim curvePercUpTime As LineItem = myPane.AddCurve("% Uptime", dsplPercUpTime, Color.Blue, SymbolType.None)
				Else
					Dim curvePercUpTime As LineItem = myPane.AddCurve("% Uptime", dsplPercUpTime, Color.Blue, mPointSymbolType)
					curvePercUpTime.Symbol.Fill.Color = mPointSymbolFillColor
					curvePercUpTime.Symbol.Fill.IsVisible = mPointSymbolFillIsVisible
					curvePercUpTime.Symbol.Border.IsVisible = mPointSymbolBorderIsVisible
					curvePercUpTime.Symbol.Size = mPointSymbolSize
				End If
				'Pad YAxis by 10%
				ChartUptime.AxisChange()
				YAxisRange = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
				Extra = YAxisRange * 0.1
				myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
				myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

				ChartUptime.AxisChange()
				ChartUptime.Refresh()
				GenChartsStatusMonthly.Add(ChartNum, ChartUptime)
				ChartNum += 1
			End If

		Catch ex As Exception
			MsgBox("Error running report:" & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Finally
			If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
			daSQL.Dispose()
			SQLConn.Dispose()
		End Try

	End Function
	Private Function GenChartsStatusCustom(ByVal MonitorID As Integer, ByVal StartDT As Date, ByVal EndDT As Date, ByVal TPMinutes As Integer) As Dictionary(Of Integer, ZedGraphControl)
		Dim ChartStatus As New ZedGraphControl
		With ChartStatus
			.GraphPane.Title.Text = "Status Frequency"
			.Name = "chartCustomStatus"
			.IsAntiAlias = True
			.IsShowPointValues = True
		End With


		Dim ChartUptime As New ZedGraphControl
		With ChartUptime
			.GraphPane.Title.Text = "% Uptime"
			.Name = "chartCustomUptime"
			.IsAntiAlias = True
			.IsShowPointValues = True
		End With


		GenChartsStatusCustom = New Dictionary(Of Integer, ZedGraphControl)
		Dim ChartNum As Integer = 0


		'Retrieve data
		Dim SQLConn As New SqlConnection(mSQLConn)

		Dim prmMonitorID As New SqlParameter
		With prmMonitorID
			.ParameterName = "@MonitorID"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = MonitorID
		End With

		Dim prmStartDT As New SqlParameter
		With prmStartDT
			.ParameterName = "@StartDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = StartDT
		End With

		Dim prmEndDT As New SqlParameter
		With prmEndDT
			.ParameterName = "@EndDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = EndDT
		End With

		Dim prmTPMinutes As New SqlParameter
		With prmTPMinutes
			.ParameterName = "@TPMinutes"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = TPMinutes
		End With

		Dim SQLCmd As New SqlCommand
		With SQLCmd
			.Connection = SQLConn
			.CommandType = CommandType.StoredProcedure
			.CommandTimeout = 180 '3 minutes
			.CommandText = "rpt_StatusData_CustomFreq"
			.Parameters.Add(prmMonitorID)
			.Parameters.Add(prmStartDT)
			.Parameters.Add(prmEndDT)
			.Parameters.Add(prmTPMinutes)
		End With

		Dim tblResults As DataTable
		Dim dsResults As New DataSet
		Dim daSQL As New SqlDataAdapter(SQLCmd)

		Try
			SQLConn.Open()
			daSQL.Fill(dsResults)
			If dsResults.Tables.Count > 0 Then
				tblResults = dsResults.Tables(0)

				tblResults.Columns("TPNum").ExtendedProperties.Add("Visible", False)
				tblResults.Columns("StartDT_Raw").ExtendedProperties.Add("Visible", False)
				tblResults.Columns("EndDT_Raw").ExtendedProperties.Add("Visible", False)
				With tblResults.Columns("StartDT_Display")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "Start Date"
				End With
				With tblResults.Columns("EndDT_Display")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "End Date"
				End With
				With tblResults.Columns("OKCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# OK"
				End With
				With tblResults.Columns("WarningCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# Warnings"
				End With
				With tblResults.Columns("FailureCount")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "# Failures"
				End With
				With tblResults.Columns("PercUpTime")
					.ExtendedProperties.Add("Visible", True)
					.Caption = "% UpTime"
				End With
				mStatusData_Custom = tblResults

				'Status Chart

				Dim myPane As GraphPane = ChartStatus.GraphPane

				'Do no plot anything if rows exceed cMaxDataPts
				'Do no plot anything if rows exceed cMaxDataPts
				If tblResults.Rows.Count > mMaxDataPts Then
					With ChartStatus.GraphPane
						.XAxis.Type = AxisType.Date
						.XAxis.Scale.Format = cFormatDate
						.XAxis.Scale.FontSpec.Size = 11
						.XAxis.Title.IsVisible = False

						.YAxis.Scale.FontSpec.Size = 11
						.YAxis.Title.IsVisible = False
						.YAxis.Scale.MinGrace = 0
						.YAxis.Scale.MaxGrace = 0

						.BaseDimension = 5.5
						.Legend.IsVisible = False
					End With
					Me.SetErrorWatermark(String.Format(cMaxReachedMsg, mMaxDataPts), ChartStatus)
					GenChartsStatusCustom.Add(ChartNum, ChartStatus)
					ChartNum += 1
					Exit Function
				End If '<= cMaxDataPts

				myPane.XAxis.Type = AxisType.Date
				myPane.XAxis.Scale.Format = cFormatDate
				myPane.XAxis.Scale.FontSpec.Size = 11
				myPane.XAxis.Title.IsVisible = False
				myPane.XAxis.Scale.MinGrace = 0
				myPane.XAxis.Scale.MaxGrace = 0
				myPane.YAxis.Scale.FontSpec.Size = 11
				myPane.YAxis.Title.IsVisible = False
				myPane.YAxis.Scale.MinGrace = 0
				myPane.YAxis.Scale.MaxGrace = 0
				myPane.BaseDimension = 5.5
				myPane.Legend.Border.IsVisible = False


				'Dim dsplOK As New DataSourcePointList
				'With dsplOK
				'	.DataSource = tblResults
				'	.XDataMember = "StartDT_Raw"
				'	.YDataMember = "OKCount"
				'	.ZDataMember = Nothing
				'End With

				Dim dsplWarning As New DataSourcePointList
				With dsplWarning
					.DataSource = tblResults
					.XDataMember = "StartDT_Raw"
					.YDataMember = "WarningCount"
					.ZDataMember = Nothing
				End With

				Dim dsplFailure As New DataSourcePointList
				With dsplFailure
					.DataSource = tblResults
					.XDataMember = "StartDT_Raw"
					.YDataMember = "FailureCount"
					.ZDataMember = Nothing
				End With

				Dim dsplPercUpTime As New DataSourcePointList
				With dsplPercUpTime
					.DataSource = tblResults
					.XDataMember = "StartDT_Raw"
					.YDataMember = "PercUptime"
					.ZDataMember = Nothing
				End With

				'Dim curveOK As LineItem = myPane.AddCurve("OK", dsplOK, Color.Blue, SymbolType.None)
				'curveOK.Line.StepType = StepType.ForwardStep

				Dim curveWarning As LineItem = myPane.AddCurve("Warning", dsplWarning, Color.Orange, SymbolType.None)
				curveWarning.Line.StepType = StepType.RearwardStep

				Dim curveFailure As LineItem = myPane.AddCurve("Failure", dsplFailure, Color.Red, SymbolType.None)
				curveFailure.Line.StepType = StepType.RearwardStep

				'Pad YAxis by 10%
				ChartStatus.AxisChange()
				Dim YAxisRange As Double = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
				Dim Extra As Double = YAxisRange * 0.1
				myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
				myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

				ChartStatus.AxisChange()
				ChartStatus.Refresh()
				GenChartsStatusCustom.Add(ChartNum, ChartStatus)
				ChartNum += 1


				'% Uptime Chart
				myPane = ChartUptime.GraphPane

				myPane.XAxis.Type = AxisType.Date
				myPane.XAxis.Scale.Format = cFormatDate
				myPane.XAxis.Scale.FontSpec.Size = 11
				myPane.XAxis.Title.IsVisible = False
				myPane.XAxis.Scale.MinGrace = 0
				myPane.XAxis.Scale.MaxGrace = 0
				myPane.YAxis.Scale.FontSpec.Size = 11
				myPane.YAxis.Title.IsVisible = False
				myPane.YAxis.Scale.MinGrace = 0
				myPane.YAxis.Scale.MaxGrace = 0
				myPane.BaseDimension = 5.5
				myPane.Legend.Border.IsVisible = False

				If tblResults.Rows.Count > mSymbolMaxPts Then
					Dim curvePercUpTime As LineItem = myPane.AddCurve("% Uptime", dsplPercUpTime, Color.Blue, SymbolType.None)
				Else
					Dim curvePercUpTime As LineItem = myPane.AddCurve("% Uptime", dsplPercUpTime, Color.Blue, mPointSymbolType)
					curvePercUpTime.Symbol.Fill.Color = mPointSymbolFillColor
					curvePercUpTime.Symbol.Fill.IsVisible = mPointSymbolFillIsVisible
					curvePercUpTime.Symbol.Border.IsVisible = mPointSymbolBorderIsVisible
					curvePercUpTime.Symbol.Size = mPointSymbolSize
				End If

				'Pad YAxis by 10%
				ChartUptime.AxisChange()
				YAxisRange = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
				Extra = YAxisRange * 0.1
				myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
				myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

				ChartUptime.AxisChange()
				ChartUptime.Refresh()
				GenChartsStatusCustom.Add(ChartNum, ChartUptime)
				ChartNum += 1
			End If

		Catch ex As Exception
			MsgBox("Error running report:" & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Finally
			If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
			daSQL.Dispose()
			SQLConn.Dispose()
		End Try

	End Function

	Private Function GenChartsCountersRaw(ByVal MonitorID As Integer, ByVal StartDT As Date, ByVal EndDT As Date) As Dictionary(Of Integer, ZedGraphControl)
		GenChartsCountersRaw = New Dictionary(Of Integer, ZedGraphControl)

		Dim ChartNum As Integer = 0

		'Retrieve data
		Dim SQLConn As New SqlConnection(mSQLConn)

		Dim prmMonitorID As New SqlParameter
		With prmMonitorID
			.ParameterName = "@MonitorID"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = MonitorID
		End With

		Dim prmStartDT As New SqlParameter
		With prmStartDT
			.ParameterName = "@StartDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = StartDT
		End With

		Dim prmEndDT As New SqlParameter
		With prmEndDT
			.ParameterName = "@EndDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = EndDT
		End With

		Dim SQLCmd As New SqlCommand
		With SQLCmd
			.Connection = SQLConn
			.CommandType = CommandType.StoredProcedure
			.CommandTimeout = 180 '3 minutes
			.CommandText = "rpt_CounterData_Raw"
			.Parameters.Add(prmMonitorID)
			.Parameters.Add(prmStartDT)
			.Parameters.Add(prmEndDT)
		End With

		Dim tblResults As DataTable
		Dim dsResults As New DataSet
		Dim daSQL As New SqlDataAdapter(SQLCmd)

		Try
			SQLConn.Open()
			daSQL.Fill(dsResults)
			If dsResults.Tables.Count > 0 Then
				tblResults = dsResults.Tables(0)

				For Each col As DataColumn In tblResults.Columns
					If col.ColumnName = "DT_Raw" Then
						col.ExtendedProperties.Add("Visible", False)
					Else
						col.ExtendedProperties.Add("Visible", True)
					End If
					If col.ColumnName = "DT_Display" Then
						col.Caption = "Event Date"
					Else
						col.Caption = col.ColumnName
					End If
				Next
				mCounterData_Custom = tblResults

				'Do no plot anything if rows exceed cMaxDataPts
				If tblResults.Rows.Count > mMaxDataPts Then
					Dim dummy As New ZedGraph.ZedGraphControl
					dummy.IsAntiAlias = True
					With dummy.GraphPane
						.Title.Text = "Counter"
						.XAxis.Type = AxisType.Date
						.XAxis.Scale.Format = cFormatDate
						.XAxis.Scale.FontSpec.Size = 11
						.XAxis.Title.IsVisible = False

						.YAxis.Scale.FontSpec.Size = 11
						.YAxis.Title.IsVisible = False
						.YAxis.Scale.MinGrace = 0
						.YAxis.Scale.MaxGrace = 0

						.BaseDimension = 5.5
						.Legend.IsVisible = False
					End With
					Me.SetErrorWatermark(String.Format(cMaxReachedMsg, mMaxDataPts), dummy)
					GenChartsCountersRaw.Add(ChartNum, dummy)
					ChartNum += 1
					Exit Function
				End If '<= cMaxDataPts

				Dim ColName As String
				Dim Column As DataColumn
				For Each Column In tblResults.Columns
					ColName = Column.ColumnName
					If Not (ColName = "DT_Raw" OrElse ColName = "DT_Display") Then
						'This is a counter column - Create a chart for it
						Dim Chart As New ZedGraphControl
						With Chart
							.GraphPane.Title.Text = String.Format("{0} - Detail", ColName)
							.IsAntiAlias = True
							.IsShowPointValues = True
							.IsShowCursorValues = False
						End With

						Dim myPane As GraphPane = Chart.GraphPane
						With myPane
							.XAxis.Type = AxisType.Date
							.XAxis.Scale.Format = cFormatDateHMS
							.XAxis.Scale.FontSpec.Size = 11
							.XAxis.Title.IsVisible = False
							.XAxis.Scale.MinGrace = 0
							.XAxis.Scale.MaxGrace = 0

							.YAxis.Scale.FontSpec.Size = 11
							.YAxis.Title.IsVisible = False
							.YAxis.Scale.MinGrace = 0
							.YAxis.Scale.MaxGrace = 0

							.BaseDimension = 5.5
							.Legend.IsVisible = False
						End With

						Dim dsplData As New DataSourcePointList
						With dsplData
							.DataSource = tblResults
							.XDataMember = "DT_Raw"
							.YDataMember = ColName
							.ZDataMember = Nothing
						End With

						Dim curveData As LineItem = myPane.AddCurve(ColName, dsplData, Color.Blue, SymbolType.None)

						'Pad YAxis by 10%
						Chart.AxisChange()
						Dim YAxisRange As Double = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
						Dim Extra As Double = YAxisRange * 0.1
						myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
						myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra


						Chart.AxisChange()
						Chart.Refresh()

						GenChartsCountersRaw.Add(ChartNum, Chart)
						ChartNum += 1
					End If
				Next
			End If

		Catch ex As Exception
			MsgBox("Error running report:" & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Finally
			If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
			daSQL.Dispose()
			SQLConn.Dispose()
		End Try
	End Function
	Private Function GenChartsCountersDaily(ByVal MonitorID As Integer, ByVal StartDT As Date, ByVal EndDT As Date) As Dictionary(Of Integer, ZedGraphControl)
		GenChartsCountersDaily = New Dictionary(Of Integer, ZedGraphControl)


		'Retrieve data
		Dim SQLConn As New SqlConnection(mSQLConn)

		Dim prmMonitorID As New SqlParameter
		With prmMonitorID
			.ParameterName = "@MonitorID"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = MonitorID
		End With

		Dim prmStartDT As New SqlParameter
		With prmStartDT
			.ParameterName = "@StartDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = StartDT
		End With

		Dim prmEndDT As New SqlParameter
		With prmEndDT
			.ParameterName = "@EndDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = EndDT
		End With

		Dim SQLCmd As New SqlCommand
		With SQLCmd
			.Connection = SQLConn
			.CommandType = CommandType.StoredProcedure
			.CommandTimeout = 180 '3 minutes
			.CommandText = "rpt_CounterData_Daily"
			.Parameters.Add(prmMonitorID)
			.Parameters.Add(prmStartDT)
			.Parameters.Add(prmEndDT)
		End With

		Dim tblResults As DataTable
		Dim dsResults As New DataSet
		Dim daSQL As New SqlDataAdapter(SQLCmd)

		Try
			SQLConn.Open()
			daSQL.Fill(dsResults)
			If dsResults.Tables.Count > 0 Then
				tblResults = dsResults.Tables(0)

				For Each col As DataColumn In tblResults.Columns
					If col.ColumnName = "DT_Raw" Then
						col.ExtendedProperties.Add("Visible", False)
					Else
						col.ExtendedProperties.Add("Visible", True)
					End If
					If col.ColumnName = "DT_Display" Then
						col.Caption = "Date"
					Else
						col.Caption = col.ColumnName
					End If
				Next
				mCounterData_Daily = tblResults


				Dim ChartNum As Integer = 0
				Dim ColName As String
				Dim Column As DataColumn
				For Each Column In tblResults.Columns
					ColName = Column.ColumnName
					If Not (ColName = "DT_Raw" OrElse ColName = "DT_Display" OrElse ColName.EndsWith("Avg") OrElse ColName.EndsWith("(# Samples)")) Then
						'This is a counter (average) column - Create a chart for it
						Dim Chart As New ZedGraphControl
						With Chart
							.GraphPane.Title.Text = String.Format("{0} - Daily", ColName)
							.IsAntiAlias = True
							.IsShowPointValues = True
							.IsShowCursorValues = False
						End With
						Dim myPane As GraphPane = Chart.GraphPane
						With myPane
							.XAxis.Type = AxisType.Date
							.XAxis.Scale.Format = cFormatDate
							.XAxis.Scale.FontSpec.Size = 11
							.XAxis.Title.IsVisible = False
							.XAxis.Scale.MinGrace = 0
							.XAxis.Scale.MaxGrace = 0

							.YAxis.Scale.FontSpec.Size = 11
							.YAxis.Title.IsVisible = False
							.YAxis.Scale.MinGrace = 0
							.YAxis.Scale.MaxGrace = 0

							.BaseDimension = 5.5
							.Legend.IsVisible = False
						End With

						Dim dsplData As New DataSourcePointList
						With dsplData
							.DataSource = tblResults
							.XDataMember = "DT_Raw"
							.YDataMember = ColName
							.ZDataMember = Nothing
						End With

						If tblResults.Rows.Count > mSymbolMaxPts Then
							Dim curveData As LineItem = myPane.AddCurve(ColName, dsplData, Color.Blue, SymbolType.None)
						Else
							Dim curveData As LineItem = myPane.AddCurve(ColName, dsplData, Color.Blue, mPointSymbolType)
							curveData.Symbol.Fill.Color = mPointSymbolFillColor
							curveData.Symbol.Fill.IsVisible = mPointSymbolFillIsVisible
							curveData.Symbol.Border.IsVisible = mPointSymbolBorderIsVisible
							curveData.Symbol.Size = mPointSymbolSize
						End If

						'Pad YAxis by 10%
						Chart.AxisChange()
						Dim YAxisRange As Double = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
						Dim Extra As Double = YAxisRange * 0.1
						myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
						myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

						Chart.AxisChange()
						Chart.Refresh()
						GenChartsCountersDaily.Add(ChartNum, Chart)
						ChartNum += 1
					End If
				Next
			End If

		Catch ex As Exception
			MsgBox("Error running report:" & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Finally
			If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
			daSQL.Dispose()
			SQLConn.Dispose()
		End Try
	End Function
	Private Function GenChartsCountersWeekly(ByVal MonitorID As Integer, ByVal StartDT As Date, ByVal EndDT As Date) As Dictionary(Of Integer, ZedGraphControl)
		GenChartsCountersWeekly = New Dictionary(Of Integer, ZedGraphControl)
		Dim ChartNum As Integer = 0


		'Retrieve data
		Dim SQLConn As New SqlConnection(mSQLConn)

		Dim prmMonitorID As New SqlParameter
		With prmMonitorID
			.ParameterName = "@MonitorID"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = MonitorID
		End With

		Dim prmStartDT As New SqlParameter
		With prmStartDT
			.ParameterName = "@StartDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = StartDT
		End With

		Dim prmEndDT As New SqlParameter
		With prmEndDT
			.ParameterName = "@EndDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = EndDT
		End With

		Dim SQLCmd As New SqlCommand
		With SQLCmd
			.Connection = SQLConn
			.CommandType = CommandType.StoredProcedure
			.CommandTimeout = 180 '3 minutes
			.CommandText = "rpt_CounterData_Weekly"
			.Parameters.Add(prmMonitorID)
			.Parameters.Add(prmStartDT)
			.Parameters.Add(prmEndDT)
		End With

		Dim tblResults As DataTable
		Dim dsResults As New DataSet
		Dim daSQL As New SqlDataAdapter(SQLCmd)

		Try
			SQLConn.Open()
			daSQL.Fill(dsResults)
			If dsResults.Tables.Count > 0 Then
				tblResults = dsResults.Tables(0)

				For Each col As DataColumn In tblResults.Columns
					If col.ColumnName = "StartDT_Raw" OrElse col.ColumnName = "EndDT_Raw" Then
						col.ExtendedProperties.Add("Visible", False)
					Else
						col.ExtendedProperties.Add("Visible", True)
					End If
					If col.ColumnName = "StartDT_Display" Then
						col.Caption = "Start Date"
					ElseIf col.ColumnName = "EndDT_Display" Then
						col.Caption = "End Date"
					ElseIf col.ColumnName = "WeekOfYear" Then
						col.Caption = "Week"
					Else
						col.Caption = col.ColumnName
					End If
				Next
				mCounterData_Weekly = tblResults

				Dim ColName As String
				Dim Column As DataColumn
				For Each Column In tblResults.Columns
					ColName = Column.ColumnName
					If Not (ColName = "StartDT_Raw" OrElse ColName = "StartDT_Display" OrElse ColName = "EndDT_Raw" OrElse ColName = "EndDT_Display" OrElse ColName = "Year" OrElse ColName = "WeekOfYear" OrElse ColName.EndsWith("Avg") OrElse ColName.EndsWith("(# Samples)")) Then
						'This is a counter (average) column - Create a chart for it
						Dim Chart As New ZedGraphControl
						With Chart
							.GraphPane.Title.Text = String.Format("{0} - Weekly", ColName)
							.IsAntiAlias = True
							.IsShowPointValues = True
							.IsShowCursorValues = False
						End With
						Dim myPane As GraphPane = Chart.GraphPane
						With myPane
							.XAxis.Type = AxisType.Date
							.XAxis.Scale.Format = cFormatDate
							.XAxis.Scale.FontSpec.Size = 11
							.XAxis.Title.IsVisible = False
							.XAxis.Scale.MinGrace = 0
							.XAxis.Scale.MaxGrace = 0

							.YAxis.Scale.FontSpec.Size = 11
							.YAxis.Title.IsVisible = False
							.YAxis.Scale.MinGrace = 0
							.YAxis.Scale.MaxGrace = 0

							.BaseDimension = 5.5
							.Legend.IsVisible = False
						End With

						Dim dsplData As New DataSourcePointList
						With dsplData
							.DataSource = tblResults
							.XDataMember = "StartDT_Raw"
							.YDataMember = ColName
							.ZDataMember = Nothing
						End With

						If tblResults.Rows.Count > mSymbolMaxPts Then
							Dim curveData As LineItem = myPane.AddCurve(ColName, dsplData, Color.Blue, SymbolType.None)
						Else
							Dim curveData As LineItem = myPane.AddCurve(ColName, dsplData, Color.Blue, mPointSymbolType)
							curveData.Symbol.Fill.Color = mPointSymbolFillColor
							curveData.Symbol.Fill.IsVisible = mPointSymbolFillIsVisible
							curveData.Symbol.Border.IsVisible = mPointSymbolBorderIsVisible
							curveData.Symbol.Size = mPointSymbolSize
						End If

						'Pad YAxis by 10%
						Chart.AxisChange()
						Dim YAxisRange As Double = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
						Dim Extra As Double = YAxisRange * 0.1
						myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
						myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

						Chart.AxisChange()
						Chart.Refresh()
						GenChartsCountersWeekly.Add(ChartNum, Chart)
						ChartNum += 1
					End If
				Next
			End If

		Catch ex As Exception
			MsgBox("Error running report:" & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Finally
			If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
			daSQL.Dispose()
			SQLConn.Dispose()
		End Try
	End Function
	Private Function GenChartsCountersMonthly(ByVal MonitorID As Integer, ByVal StartDT As Date, ByVal EndDT As Date) As Dictionary(Of Integer, ZedGraphControl)
		GenChartsCountersMonthly = New Dictionary(Of Integer, ZedGraphControl)
		Dim ChartNum As Integer = 0


		'Retrieve data
		Dim SQLConn As New SqlConnection(mSQLConn)

		Dim prmMonitorID As New SqlParameter
		With prmMonitorID
			.ParameterName = "@MonitorID"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = MonitorID
		End With

		Dim prmStartDT As New SqlParameter
		With prmStartDT
			.ParameterName = "@StartDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = StartDT
		End With

		Dim prmEndDT As New SqlParameter
		With prmEndDT
			.ParameterName = "@EndDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = EndDT
		End With

		Dim SQLCmd As New SqlCommand
		With SQLCmd
			.Connection = SQLConn
			.CommandType = CommandType.StoredProcedure
			.CommandTimeout = 180 '3 minutes
			.CommandText = "rpt_CounterData_Monthly"
			.Parameters.Add(prmMonitorID)
			.Parameters.Add(prmStartDT)
			.Parameters.Add(prmEndDT)
		End With

		Dim tblResults As DataTable
		Dim dsResults As New DataSet
		Dim daSQL As New SqlDataAdapter(SQLCmd)

		Try
			SQLConn.Open()
			daSQL.Fill(dsResults)
			If dsResults.Tables.Count > 0 Then
				tblResults = dsResults.Tables(0)

				For Each col As DataColumn In tblResults.Columns
					If col.ColumnName = "StartDT_Raw" OrElse col.ColumnName = "EndDT_Raw" Then
						col.ExtendedProperties.Add("Visible", False)
					Else
						col.ExtendedProperties.Add("Visible", True)
					End If
					If col.ColumnName = "StartDT_Display" Then
						col.Caption = "Start Date"
					ElseIf col.ColumnName = "EndDT_Display" Then
						col.Caption = "End Date"
					Else
						col.Caption = col.ColumnName
					End If
				Next
				mCounterData_Monthly = tblResults

				Dim ColName As String
				Dim Column As DataColumn
				For Each Column In tblResults.Columns
					ColName = Column.ColumnName
					If Not (ColName = "StartDT_Raw" OrElse ColName = "StartDT_Display" OrElse ColName = "EndDT_Raw" OrElse ColName = "EndDT_Display" OrElse ColName = "Year" OrElse ColName = "Month" OrElse ColName.EndsWith("Avg") OrElse ColName.EndsWith("(# Samples)")) Then
						'This is a counter (average) column - Create a chart for it
						Dim Chart As New ZedGraphControl
						With Chart
							.GraphPane.Title.Text = String.Format("{0} - Monthly", ColName)
							.IsAntiAlias = True
							.IsShowPointValues = True
							.IsShowCursorValues = False
						End With
						Dim myPane As GraphPane = Chart.GraphPane
						With myPane
							.XAxis.Type = AxisType.Date
							.XAxis.Scale.Format = cFormatDate
							.XAxis.Scale.FontSpec.Size = 11
							.XAxis.Title.IsVisible = False
							.XAxis.Scale.MinGrace = 0
							.XAxis.Scale.MaxGrace = 0

							.YAxis.Scale.FontSpec.Size = 11
							.YAxis.Title.IsVisible = False
							.YAxis.Scale.MinGrace = 0
							.YAxis.Scale.MaxGrace = 0

							.BaseDimension = 5.5
							.Legend.IsVisible = False
						End With

						Dim dsplData As New DataSourcePointList
						With dsplData
							.DataSource = tblResults
							.XDataMember = "StartDT_Raw"
							.YDataMember = ColName
							.ZDataMember = Nothing
						End With

						If tblResults.Rows.Count > mSymbolMaxPts Then
							Dim curveData As LineItem = myPane.AddCurve(ColName, dsplData, Color.Blue, SymbolType.None)
						Else
							Dim curveData As LineItem = myPane.AddCurve(ColName, dsplData, Color.Blue, mPointSymbolType)
							curveData.Symbol.Fill.Color = mPointSymbolFillColor
							curveData.Symbol.Fill.IsVisible = mPointSymbolFillIsVisible
							curveData.Symbol.Border.IsVisible = mPointSymbolBorderIsVisible
							curveData.Symbol.Size = mPointSymbolSize
						End If

						'Pad YAxis by 10%
						Chart.AxisChange()
						Dim YAxisRange As Double = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
						Dim Extra As Double = YAxisRange * 0.1
						myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
						myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

						Chart.AxisChange()
						Chart.Refresh()
						GenChartsCountersMonthly.Add(ChartNum, Chart)
						ChartNum += 1
					End If
				Next
			End If

		Catch ex As Exception
			MsgBox("Error running report:" & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Finally
			If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
			daSQL.Dispose()
			SQLConn.Dispose()
		End Try
	End Function
	Private Function GenChartsCountersCustom(ByVal MonitorID As Integer, ByVal StartDT As Date, ByVal EndDT As Date, ByVal TPMinutes As Integer) As Dictionary(Of Integer, ZedGraphControl)
		GenChartsCountersCustom = New Dictionary(Of Integer, ZedGraphControl)
		Dim ChartNum As Integer = 0


		'Retrieve data
		Dim SQLConn As New SqlConnection(mSQLConn)

		Dim prmMonitorID As New SqlParameter
		With prmMonitorID
			.ParameterName = "@MonitorID"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = MonitorID
		End With

		Dim prmStartDT As New SqlParameter
		With prmStartDT
			.ParameterName = "@StartDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = StartDT
		End With

		Dim prmEndDT As New SqlParameter
		With prmEndDT
			.ParameterName = "@EndDT"
			.SqlDbType = SqlDbType.DateTime
			.Direction = ParameterDirection.Input
			.Value = EndDT
		End With

		Dim prmTPMinutes As New SqlParameter
		With prmTPMinutes
			.ParameterName = "@TPMinutes"
			.SqlDbType = SqlDbType.Int
			.Direction = ParameterDirection.Input
			.Value = TPMinutes
		End With

		Dim SQLCmd As New SqlCommand
		With SQLCmd
			.Connection = SQLConn
			.CommandType = CommandType.StoredProcedure
			.CommandTimeout = 180 '3 minutes
			.CommandText = "rpt_CounterData_CustomAverage"
			.Parameters.Add(prmMonitorID)
			.Parameters.Add(prmStartDT)
			.Parameters.Add(prmEndDT)
			.Parameters.Add(prmTPMinutes)
		End With

		Dim tblResults As DataTable
		Dim dsResults As New DataSet
		Dim daSQL As New SqlDataAdapter(SQLCmd)

		Try
			SQLConn.Open()
			daSQL.Fill(dsResults)
			If dsResults.Tables.Count > 0 Then
				tblResults = dsResults.Tables(0)

				For Each col As DataColumn In tblResults.Columns
					If col.ColumnName = "StartDT_Raw" OrElse col.ColumnName = "EndDT_Raw" Then
						col.ExtendedProperties.Add("Visible", False)
					Else
						col.ExtendedProperties.Add("Visible", True)
					End If
					If col.ColumnName = "StartDT_Display" Then
						col.Caption = "Start Date"
					ElseIf col.ColumnName = "EndDT_Display" Then
						col.Caption = "End Date"
					ElseIf col.ColumnName = "WeekOfYear" Then
						col.Caption = "Week"
					Else
						col.Caption = col.ColumnName
					End If
				Next
				mCounterData_Custom = tblResults

				'Do no plot anything if rows exceed cMaxDataPts
				If tblResults.Rows.Count > mMaxDataPts Then
					Dim dummy As New ZedGraph.ZedGraphControl
					dummy.IsAntiAlias = True
					With dummy.GraphPane
						.Title.Text = "Counter"
						.XAxis.Type = AxisType.Date
						.XAxis.Scale.Format = cFormatDate
						.XAxis.Scale.FontSpec.Size = 11
						.XAxis.Title.IsVisible = False

						.YAxis.Scale.FontSpec.Size = 11
						.YAxis.Title.IsVisible = False
						.YAxis.Scale.MinGrace = 0
						.YAxis.Scale.MaxGrace = 0

						.BaseDimension = 5.5
						.Legend.IsVisible = False
					End With
					Me.SetErrorWatermark(String.Format(cMaxReachedMsg, mMaxDataPts), dummy)
					GenChartsCountersCustom.Add(ChartNum, dummy)
					ChartNum += 1
					Exit Function
				End If '<= cMaxDataPts


				Dim ColName As String
				Dim Column As DataColumn
				For Each Column In tblResults.Columns
					ColName = Column.ColumnName
					If Not (ColName = "StartDT_Raw" OrElse ColName = "StartDT_Display" OrElse ColName = "EndDT_Raw" OrElse ColName = "EndDT_Display" OrElse ColName.EndsWith("Avg") OrElse ColName.EndsWith("(# Samples)")) Then
						'This is a counter (average) column - Create a chart for it
						Dim Chart As New ZedGraphControl
						With Chart
							.GraphPane.Title.Text = ColName
							.IsAntiAlias = True
							.IsShowPointValues = True
							.IsShowCursorValues = False
						End With
						Dim myPane As GraphPane = Chart.GraphPane
						With myPane
							.XAxis.Type = AxisType.Date
							.XAxis.Scale.Format = cFormatDate
							.XAxis.Scale.FontSpec.Size = 11
							.XAxis.Title.IsVisible = False
							.XAxis.Scale.MinGrace = 0
							.XAxis.Scale.MaxGrace = 0

							.YAxis.Scale.FontSpec.Size = 11
							.YAxis.Title.IsVisible = False
							.YAxis.Scale.MinGrace = 0
							.YAxis.Scale.MaxGrace = 0

							.BaseDimension = 5.5
							.Legend.IsVisible = False
						End With

						Dim dsplData As New DataSourcePointList
						With dsplData
							.DataSource = tblResults
							.XDataMember = "StartDT_Raw"
							.YDataMember = ColName
							.ZDataMember = Nothing
						End With

						If tblResults.Rows.Count > mSymbolMaxPts Then
							Dim curveData As LineItem = myPane.AddCurve(ColName, dsplData, Color.Blue, SymbolType.None)
						Else
							Dim curveData As LineItem = myPane.AddCurve(ColName, dsplData, Color.Blue, mPointSymbolType)
							curveData.Symbol.Fill.Color = mPointSymbolFillColor
							curveData.Symbol.Fill.IsVisible = mPointSymbolFillIsVisible
							curveData.Symbol.Border.IsVisible = mPointSymbolBorderIsVisible
							curveData.Symbol.Size = mPointSymbolSize
						End If

						'Pad YAxis by 10%
						Chart.AxisChange()
						Dim YAxisRange As Double = Math.Abs(myPane.YAxis.Scale.Max) - Math.Abs(myPane.YAxis.Scale.Min)
						Dim Extra As Double = YAxisRange * 0.1
						myPane.YAxis.Scale.Min = myPane.YAxis.Scale.Min - Extra
						myPane.YAxis.Scale.Max = myPane.YAxis.Scale.Max + Extra

						Chart.AxisChange()
						Chart.Refresh()
						GenChartsCountersCustom.Add(ChartNum, Chart)
						ChartNum += 1
					End If
				Next
			End If

		Catch ex As Exception
			MsgBox("Error running report:" & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Finally
			If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
			daSQL.Dispose()
			SQLConn.Dispose()
		End Try
	End Function

	Private Sub SetErrorWatermark(ByVal ErrMsg As String, ByRef Chart As ZedGraph.ZedGraphControl)
		Dim Message As New TextObj(ErrMsg, 0.5, 0.5)
		Message.Location.CoordinateFrame = CoordType.PaneFraction
		Message.FontSpec.Angle = 0.0
		Message.FontSpec.FontColor = Color.FromArgb(100, 0, 0, 255)
		Message.FontSpec.Size = 20
		Message.FontSpec.IsBold = True
		Message.FontSpec.Border.IsVisible = False
		Message.FontSpec.Fill.IsVisible = False
		Message.Location.AlignH = AlignH.Center
		Message.Location.AlignV = AlignV.Center
		Message.ZOrder = ZOrder.A_InFront

		Chart.GraphPane.GraphObjList.Add(Message)
	End Sub
#End Region
End Class