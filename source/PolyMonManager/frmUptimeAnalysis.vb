Imports System.Data.SqlClient

Public Class frmUptimeAnalysis
#Region "Private Attributes"
    Private mSQLConn As String
#End Region

#Region "Event Handlers"
    Private Sub frmUptimeAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))

        Me.radPresetTP.Checked = True
        Me.cboTP.Enabled = True
        Me.dtpStart.Enabled = False
        Me.dtpEnd.Enabled = False
        Me.lblTo.Enabled = False


        'Set Custom Date formats
        With Me.dtpStart
            .CustomFormat = "MMM dd, yyyy"
            .Format = DateTimePickerFormat.Custom
        End With

        With Me.dtpEnd
            .CustomFormat = "MMM dd, yyyy"
            .Format = DateTimePickerFormat.Custom
        End With

        BuildPresetTPList()
    End Sub
    Private Sub radPresetTP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radPresetTP.CheckedChanged
        If radPresetTP.Checked Then
            Me.cboTP.Enabled = True
            Me.dtpStart.Enabled = False
            Me.dtpEnd.Enabled = False
            Me.lblTo.Enabled = False
        End If
    End Sub
    Private Sub radCustomTP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCustomTP.CheckedChanged
        If radCustomTP.Checked Then
            Me.cboTP.Enabled = False
            Me.dtpStart.Enabled = True
            Me.dtpEnd.Enabled = True
            Me.lblTo.Enabled = True
        End If
    End Sub
    Private Sub btnRunReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunReport.Click
        Me.Cursor = Cursors.WaitCursor
        RunReport()
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Private Methods"
    Private Sub BuildPresetTPList()
        'Generate pre-set timeframes
		With Me.cboTP
			.Items.Clear()
			.Items.Add("Today")
			.Items.Add("Yesterday")
			.Items.Add("This Week")
			.Items.Add("Last Week")
			.Items.Add("This Month")
			.Items.Add("Last Month")
			.Items.Add("Year to Date")
			.Items.Add("Last 6 Months")
			.Items.Add("Last 12 Months")

			.SelectedIndex = 0
		End With

    End Sub
    Private Sub ResetResultsGrid()
        Me.dgvResults.DataSource = Nothing
    End Sub
    Private Sub RunReport()
        Dim DateLo As Date
        Dim DateHi As Date
        Dim IncludeLifetime As Boolean

        ResetResultsGrid()

		If Me.radPresetTP.Checked Then
			Dim myTP As TP = CalcDateRange(Me.cboTP.Text)
			DateLo = myTP.TPLo
			DateHi = myTP.TPHi
		Else
			DateLo = Me.dtpStart.Value
			DateHi = Me.dtpEnd.Value
		End If

        If Me.chkIncludeLifetime.Checked Then IncludeLifetime = True Else IncludeLifetime = False

        Dim SQLConn As New SqlConnection(mSQLConn)

        Dim prmStartDT As New SqlParameter
        With prmStartDT
            .ParameterName = "@StartDT"
            .SqlDbType = SqlDbType.DateTime
            .Direction = ParameterDirection.Input
            .Value = DateLo
        End With

        Dim prmEndDT As New SqlParameter
        With prmEndDT
            .ParameterName = "@EndDT"
            .SqlDbType = SqlDbType.DateTime
            .Direction = ParameterDirection.Input
            .Value = DateHi
        End With

        Dim prmIncludeLifetime As New SqlParameter
        With prmIncludeLifetime
            .ParameterName = "@IncludeLifetime"
            .SqlDbType = SqlDbType.Bit
            .Direction = ParameterDirection.Input
            .Value = CInt(IIf(IncludeLifetime, 1, 0))
        End With

        Dim SQLCmd As New SqlCommand
        With SQLCmd
            .Connection = SQLConn
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 180 '3 minutes
            .CommandText = "polymon_sel_PercUptimeAnalysis"
            .Parameters.Add(prmStartDT)
            .Parameters.Add(prmEndDT)
            .Parameters.Add(prmIncludeLifetime)
        End With

        Dim tblResults As DataTable
        Dim dsResults As New DataSet
        Dim daSQL As New SqlDataAdapter(SQLCmd)

        Try
            SQLConn.Open()
            daSQL.Fill(dsResults)
            If dsResults.Tables.Count > 0 Then
                tblResults = dsResults.Tables(0)
                tblResults.TableName = "Results"

                With Me.dgvResults
                    .EnableHeadersVisualStyles = False

                    .DefaultCellStyle.BackColor = Color.WhiteSmoke

                    .AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None
                    '.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.InsetDouble

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

                    .Columns("Monitor ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Monitor ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter


                    .Columns("Monitor").DefaultCellStyle.ForeColor = Color.DarkBlue
                    .Columns("Monitor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Columns("Monitor").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    .Columns("Monitor Type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Monitor Type").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    .Columns("% Uptime").DefaultCellStyle.ForeColor = Color.DarkBlue
                    .Columns("% Uptime").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    .Columns("% Uptime").DefaultCellStyle.Format = "##0.###"
                    .Columns("% Uptime").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("% Uptime").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    If IncludeLifetime Then
                        .Columns("Lifetime % Uptime").DefaultCellStyle.ForeColor = Color.DarkGreen
                        .Columns("Lifetime % Uptime").DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        .Columns("Lifetime % Uptime").DefaultCellStyle.Format = "##0.###"
                        .Columns("Lifetime % Uptime").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns("Lifetime % Uptime").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End If

                    '                    .ResumeLayout()

                    .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                End With

            End If
        Catch ex As Exception
            MsgBox("Error running report:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "PolyMon Error")
        Finally
            If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
            daSQL.Dispose()
            SQLConn.Dispose()
        End Try
    End Sub
#End Region

#Region "Private Classes"
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
#End Region
End Class