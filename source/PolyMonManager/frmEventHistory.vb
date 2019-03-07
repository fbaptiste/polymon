
Public Class frmEventHistory

    Private Sub frmEventHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitForm()
    End Sub

    Private Sub InitForm()
        'Set Custom Date formats
        With Me.dtpTPLo
            .CustomFormat = "MMM dd, yyyy"
            .Format = DateTimePickerFormat.Custom
        End With

        With Me.dtpTPHi
            .CustomFormat = "MMM dd, yyyy"
            .Format = DateTimePickerFormat.Custom
        End With

        'Generate pre-set timeframes
		With Me.cboTP
			.Items.Clear()
			.Items.Add("Today")
			.Items.Add("Yesterday")
			.Items.Add("This Week")
			.Items.Add("Last Week")
			.Items.Add("This Month")
			.Items.Add("Last Month")
			.SelectedIndex = 0
		End With
    End Sub

	Private Class TP
		Dim mTPName As String
		Dim mTPLo As Date
		Dim mTPHi As Date

		Public Sub New(ByVal TPName As String, ByVal DateLo As Date, ByVal DateHi As Date)
			mTPLo = CDate(CStr(Year(DateLo)) & "/" & CStr(Month(DateLo)) & "/" & CStr(Microsoft.VisualBasic.DateAndTime.Day(DateLo)) & " 00:00:00")
			mTPHi = CDate(CStr(Year(DateHi)) & "/" & CStr(Month(DateHi)) & "/" & CStr(Microsoft.VisualBasic.DateAndTime.Day(DateHi)) & " 23:59:59")
			mTPName = TPName
		End Sub

		Public ReadOnly Property TPName() As String
			Get
				Return mTPName
			End Get
		End Property
		Public ReadOnly Property TPLo() As Date
			Get
				Return mTPLo
			End Get
		End Property
		Public ReadOnly Property TPHi() As Date
			Get
				Return mTPHi
			End Get
		End Property
	End Class

	Private Function CalcDateRange(ByVal Timeframe As String) As TP
		Dim RetTP As TP
		Dim DateLo, DateHi As DateTime

		Select Case Timeframe
			Case "Today"
				'Today
				RetTP = New TP("Today", Now(), Now())
			Case "Yesterday"
				'Yesterday
				DateLo = DateAdd(DateInterval.Day, -1, Now())
				DateHi = DateLo
				RetTP = New TP("Yesterday", DateLo, DateHi)
			Case "This Week"
				'This week (week is Mon-Sun)
				DateLo = DateAdd(DateInterval.Day, 1 - Weekday(Now, FirstDayOfWeek.Monday), Now())
				DateHi = Now()
				RetTP = New TP("This Week", DateLo, DateHi)
			Case "Last Week"
				'Last Week (week is Mon-Sun)
				DateLo = DateAdd(DateInterval.WeekOfYear, -1, DateAdd(DateInterval.Day, 1 - Weekday(Now, FirstDayOfWeek.Monday), Now()))
				DateHi = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Day, 1 - Weekday(Now, FirstDayOfWeek.Monday), Now()))
				RetTP = New TP("Last Week", DateLo, DateHi)
			Case "This Month"
				'This Month
				DateLo = CDate(Year(Now()) & "/" & Month(Now()) & "/1")
				DateHi = Now()
				RetTP = New TP("This Month", DateLo, DateHi)
			Case "Last Month"
				'Last Month
				DateLo = DateAdd(DateInterval.Month, -1, CDate(Year(Now()) & "/" & Month(Now()) & "/1"))
				DateHi = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateLo))
				RetTP = New TP("Last Month", DateLo, DateHi)
			Case "Year to Date"
				'Year to Date
				DateLo = CDate("1/1/" & Year(Now()))
				DateHi = Now()
				RetTP = New TP("Year to Date", DateLo, DateHi)
			Case "Last 6 Months"
				'Last 6 Months
				DateLo = DateAdd(DateInterval.Month, -6, CDate(Year(Now()) & "/" & Month(Now()) & "/1"))
				DateHi = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 6, DateLo))
				RetTP = New TP("Last 6 Months", DateLo, DateHi)
			Case "Last 12 Months"
				'Last 12 Months
				DateLo = DateAdd(DateInterval.Month, -12, CDate(Year(Now()) & "/" & Month(Now()) & "/1"))
				DateHi = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 12, DateLo))
				RetTP = New TP("Last 12 Months", DateLo, DateHi)
			Case Else
				'Default to Today
				RetTP = New TP("Today", Now(), Now())
		End Select
		Return RetTP
	End Function

    Private Sub SetTPEditStatus(ByVal IsPresetTP As Boolean)
        Me.cboTP.Enabled = IsPresetTP
        Me.dtpTPLo.Enabled = Not (IsPresetTP)
        Me.dtpTPHi.Enabled = Not (IsPresetTP)
    End Sub

    Private Sub radPreset_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radPreset.CheckedChanged
        SetTPEditStatus(Me.radPreset.Checked)
    End Sub

    Private Sub ResetResultsGrid()
        Me.dgvResults.DataSource = Nothing
    End Sub
    Private Sub RunReport()
        Dim DateLo As Date
        Dim DateHi As Date

        ResetResultsGrid()

        If Me.radPreset.Checked Then
			Dim myTP As TP = CalcDateRange(Me.cboTP.Text)
			DateLo = myTP.TPLo
			DateHi = myTP.TPHi
        Else
            DateLo = Me.dtpTPLo.Value
            DateHi = Me.dtpTPHi.Value
        End If

        Dim Results As PolyMon.MonitorEvents.EventHistory
        Dim tblResults As DataTable
        Try
            Results = New PolyMon.MonitorEvents.EventHistory(Me.chkInclOK.Checked, Me.chkInclWarning.Checked, Me.chkInclFail.Checked, DateLo, DateHi)
            tblResults = Results.EventHistory

            With Me.dgvResults
                .SuspendLayout()


                .EnableHeadersVisualStyles = False

                .DefaultCellStyle.BackColor = Color.WhiteSmoke

                .AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None

                Dim HStyle As New DataGridViewCellStyle
                HStyle.ForeColor = Color.White
                HStyle.BackColor = Color.DarkBlue
                HStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                HStyle.Padding = New Padding(5)
                .ColumnHeadersDefaultCellStyle = HStyle

                .AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None
				.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single


                .RowHeadersVisible = False

                .AllowUserToResizeRows = False
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ReadOnly = True
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue


                .DataSource = tblResults

                'Hidden Columns
                .Columns("MonitorID").Visible = False
                .Columns("EventID").Visible = False
                .Columns("StatusID").Visible = False

                'Event Date
                .Columns("EventDT").HeaderText = "Event Date"
                .Columns("EventDT").DisplayIndex = 0

                'Monitor
                .Columns("Monitor").HeaderText = "Monitor"
                .Columns("Monitor").DisplayIndex = 1
                .Columns("Monitor").DefaultCellStyle.ForeColor = Color.DarkBlue
                .Columns("Monitor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("Monitor").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Monitor Type
                .Columns("MonitorType").HeaderText = "Monitor Type"
                .Columns("MonitorType").DisplayIndex = 2
                .Columns("MonitorType").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("MonitorType").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Status
                .Columns("Status").HeaderText = "Status"
                .Columns("Status").DisplayIndex = 3
                .Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Status").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Current Status
                .Columns("CurrentStatus").HeaderText = "Current Status"
                .Columns("CurrentStatus").DisplayIndex = 4
                .Columns("CurrentStatus").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("CurrentStatus").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                '% Uptime
                .Columns("% Uptime").DisplayIndex = 5
                .Columns("% Uptime").DefaultCellStyle.ForeColor = Color.DarkBlue
                .Columns("% Uptime").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                .Columns("% Uptime").DefaultCellStyle.Format = "##0.###"
                .Columns("% Uptime").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("% Uptime").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Status Message
                .Columns("StatusMessage").HeaderText = "Status Message"
                .Columns("StatusMessage").DisplayIndex = 6


                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
                .ResumeLayout()
            End With
        Catch ex As Exception
            MsgBox("Error running report." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "PolyMon Error...")
        End Try


        
        
    End Sub

    Private Sub btnRunReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunReport.Click
        Me.Cursor = Cursors.WaitCursor
        RunReport()
        Me.Cursor = Cursors.Default
    End Sub
End Class