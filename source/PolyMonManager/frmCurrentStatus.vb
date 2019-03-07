Imports System.Data.SqlClient
Imports System.Xml

Public Class frmCurrentStatus
#Region "Private Attributes"
    Private mCurrMonitorID As Integer = -1
#End Region

#Region "Public Interface"
    Public Event AlertEvent As EventHandler
    Public Event AllNominal As EventHandler

    Public Sub RefreshMonitors(ByVal RaiseErrors As Boolean)
        Dim sp As String = "polymon_sel_AllCurrentStatus"
        Dim strSQLConn As String = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
        Dim SQLConn As New SqlConnection(strSQLConn)
        Dim UserSettings As New UserSettings()

        Dim SQLCmd As New SqlCommand
        With SQLCmd
            .Connection = SQLConn
            .CommandType = CommandType.StoredProcedure
            .CommandText = sp
        End With

        Dim rdResults As SqlDataReader

        Dim MonitorID As Integer
        Dim MonitorName As String
        Dim MonitorType As String
        Dim EventDT As Date
        Dim StatusID As PolyMon.Monitors.MonitorStatus.eStatus
        Dim Status As String
        Dim StatusMessage As String
        Dim LifetimePercUptime As Double
        Dim ErrorsWarnings As Boolean = False
		Dim IsEnabled As Boolean = False
		Dim CurrStartDT As Date = Nothing
		Dim CurrEndDT As Date = Nothing
		Dim CurrTimeSecs As Integer = 0
		Dim CurrTime As String = Nothing

        Try
            Me.lvMonitors.Items.Clear()
            SQLConn.Open()
            rdResults = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rdResults.Read()
                MonitorID = CInt(rdResults.Item("MonitorID"))
                MonitorName = CStr(rdResults.Item("Name"))
                MonitorType = CStr(rdResults.Item("MonitorType"))
                EventDT = CDate(rdResults.Item("EventDT"))
                StatusID = CType(rdResults.Item("StatusID"), PolyMon.Monitors.MonitorStatus.eStatus)
                Status = CStr(rdResults.Item("Status"))
                StatusMessage = CStr(rdResults.Item("StatusMessage"))
                LifetimePercUptime = CDbl(rdResults.Item("LifetimePercUptime"))
				IsEnabled = CBool(rdResults.Item("IsEnabled"))
				CurrStartDT = CDate(rdResults.Item("StatusStartDT"))
				CurrEndDT = CDate(rdResults.Item("StatusEndDT"))
				CurrTimeSecs = CInt(rdResults.Item("TimeElapsedSecs"))
				CurrTime = CStr(rdResults.Item("TimeElapsedTxt"))
				

				Dim lvItem As ListViewItem
				lvItem = lvMonitors.Items.Add(CStr(MonitorID), MonitorName, 0)
				lvItem.Tag = CStr(MonitorID)

				If IsEnabled Then
					Select Case StatusID
						Case PolyMon.Monitors.MonitorStatus.eStatus.Unknown
							lvItem.ImageIndex = 0
						Case PolyMon.Monitors.MonitorStatus.eStatus.OK
							lvItem.ImageIndex = 1
						Case PolyMon.Monitors.MonitorStatus.eStatus.Warning
							lvItem.ImageIndex = 2
							ErrorsWarnings = True
						Case PolyMon.Monitors.MonitorStatus.eStatus.Fail
							lvItem.ImageIndex = 3
							ErrorsWarnings = True
					End Select

					lvItem.SubItems.Add(MonitorType)										'Monitor Type
					lvItem.SubItems.Add(Format(EventDT, "MMM dd, yyyy hh:mm:ss tt"))		'Event DT
					lvItem.SubItems.Add(Status)												'Status

					lvItem.SubItems.Add(Format(CurrStartDT, "MMM dd, yyyy hh:mm:ss tt"))	'Curr Status Start
					lvItem.SubItems.Add(Format(CurrEndDT, "MMM dd, yyyy hh:mm:ss tt"))		'Curr Status End
					lvItem.SubItems.Add(CStr(CurrTimeSecs))									'Time in Curr Status (secs)
					lvItem.SubItems.Add(CurrTime)											'Time in Curr Status


					lvItem.SubItems.Add(Format(LifetimePercUptime, "##0.00 \%"))			'LifetimePercUp
					lvItem.SubItems.Add(Status)												'Status Message

					lvItem.SubItems(1).ForeColor = Color.Gray
				Else
					'Monitor is disabled
					ErrorsWarnings = False
					lvItem.ImageIndex = 4

					lvItem.SubItems.Add(MonitorType)		'Monitor Type
					lvItem.SubItems.Add("")					'Event DT
					lvItem.SubItems.Add("Disabled")			'Status

					lvItem.SubItems.Add("")					'Curr Status Start
					lvItem.SubItems.Add("")					'Curr Status End
					lvItem.SubItems.Add("")					'Time in Curr Status (secs)
					lvItem.SubItems.Add("")					'Time in Curr Status

					lvItem.SubItems.Add("")					'LifetimePercUp
					lvItem.SubItems.Add("")					'Status Message

					lvItem.SubItems(1).ForeColor = Color.Gray

				End If

			End While

            If mCurrMonitorID > -1 Then
                'pre-select item in list view
                Dim SelectedIndex As Integer = lvMonitors.Items.IndexOfKey(CStr(mCurrMonitorID))
                If SelectedIndex > -1 Then
                    lvMonitors.Items(SelectedIndex).Selected = True
                    lvMonitors.Items(SelectedIndex).EnsureVisible()
                End If
            End If

            If ErrorsWarnings Then
                If RaiseErrors Then RaiseEvent AlertEvent(Me, System.EventArgs.Empty)
            Else
                RaiseEvent AllNominal(Me, System.EventArgs.Empty)
            End If
        Catch ex As Exception
            MsgBox("Error loading Current Status." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Polymon")
        Finally
            If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
            SQLConn.Dispose()
        End Try

    End Sub
#End Region

#Region "Event Handlers"
    Private Sub frmCurrentStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Me.Cursor = Cursors.WaitCursor
		InitGrid()
        ClearMonitorDetails()

        With Me.lvMonitors
            .Columns.Add("Name", "Name")
            .Columns.Add("Monitor Type", "Monitor Type")
            .Columns.Add("Event DT", "Event DT")
			.Columns.Add("Status", "Status")
			.Columns.Add("Curr Status Start", "Curr Status Start")
			.Columns.Add("Curr Status End", "Curr Status End")
			.Columns.Add("Time in Curr Status (secs)", "Time in Curr Status (secs)")
			.Columns.Add("Time in Curr Status", "Time in Curr Status")
            .Columns.Add("LifetimePercUp", "LifetimePercUp")
            .Columns.Add("Status Message", "Status Message")
        End With

        lvMonitors.Visible = False
        CType(Me.MdiParent, frmMain).RefreshMonitorStatuses(False, frmMain.StatusForms.CurrentStatus)
        lvMonitors.Visible = True

        SetViewStyle(View.Tile)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tbtnTiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnTiles.Click
        SetViewStyle(View.Tile)
    End Sub
    Private Sub tbtnIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnIcons.Click
        SetViewStyle(View.LargeIcon)
    End Sub
    Private Sub tbtnDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnDetails.Click
        SetViewStyle(View.Details)
    End Sub

    Private Sub lvMonitors_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvMonitors.ColumnClick
        Dim CurrColumn As Integer
        If lvMonitors.ListViewItemSorter Is Nothing Then
            Me.lvMonitors.ListViewItemSorter = New ListViewItemComparer(e.Column, True)
        Else
            CurrColumn = CType(lvMonitors.ListViewItemSorter, ListViewItemComparer).Column
            If CurrColumn = e.Column Then
                Me.lvMonitors.ListViewItemSorter = New ListViewItemComparer(e.Column, Not (CType(lvMonitors.ListViewItemSorter, ListViewItemComparer).SortAscending))
            Else
                Me.lvMonitors.ListViewItemSorter = New ListViewItemComparer(e.Column, True)
            End If
        End If
    End Sub

    Private Sub lvMonitors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMonitors.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        'Load Monitor Metadata
        If lvMonitors.SelectedItems.Count > 0 Then
            mCurrMonitorID = CInt(lvMonitors.SelectedItems(0).Tag)
            LoadMonitorData(mCurrMonitorID)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tbtnRefreshView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRefreshView.Click
        Me.Cursor = Cursors.WaitCursor
        ClearMonitorDetails()
        CType(Me.MdiParent, frmMain).RefreshMonitorStatuses(False, frmMain.StatusForms.CurrentStatus)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tbtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        If mCurrMonitorID > -1 Then LoadMonitorData(mCurrMonitorID)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tbtnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRun.Click
        Me.Cursor = Cursors.WaitCursor
        If mCurrMonitorID > -1 Then
            RunMonitor(mCurrMonitorID)
            LoadMonitorData(mCurrMonitorID)
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tbtnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnHistory.Click
        If mCurrMonitorID > -1 Then
			'Dim myHistory As New frmHistory(mCurrMonitorID)
			'myHistory.MdiParent = frmMain
			'myHistory.Show()
			Dim Reports As New frmReports(mCurrMonitorID)
			Reports.MdiParent = frmMain
			Reports.Show()
        End If
    End Sub
    Private Sub tbtnMonitorDef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnMonitorDef.Click
        If mCurrMonitorID > -1 Then
            Dim frmMonitorDefs As frmMonitorDefs = CType(CType(Me.ParentForm, frmMain).LoadChildForm("frmMonitorDefs"), frmMonitorDefs)
            frmMonitorDefs.EditMonitor(mCurrMonitorID)
        End If
    End Sub
#End Region

#Region "Private Methods"
	Private Sub InitGrid()
		With Me.dgvCounters
			.EnableHeadersVisualStyles = False

			.BackgroundColor = Color.White
			.BorderStyle = BorderStyle.None

			.DefaultCellStyle.BackColor = Color.WhiteSmoke

			.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None

			Dim HStyle As New DataGridViewCellStyle
			HStyle.ForeColor = Color.White
			HStyle.BackColor = Color.DarkBlue
			HStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			HStyle.Padding = New Padding(5)
			.ColumnHeadersDefaultCellStyle = HStyle

			.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None
			.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.InsetDouble

			.RowHeadersVisible = False

			.AllowUserToResizeRows = False
			.AllowUserToAddRows = False
			.AllowUserToDeleteRows = False
			.SelectionMode = DataGridViewSelectionMode.FullRowSelect
			.ReadOnly = True
			.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue
		End With
	End Sub
	Private Sub LoadMonitorData(ByVal MonitorID As Integer)
		Dim Metadata As PolyMon.Monitors.MonitorMetadata = New PolyMon.Monitors.MonitorMetadata(MonitorID)
		Dim CurrStatus As PolyMon.Monitors.MonitorStatus = New PolyMon.Monitors.MonitorStatus(MonitorID)

		lblAsOfLabel.Visible = True
		lblOfflineTimesLabel.Visible = True
		Me.tbtnRun.Enabled = True
		Me.tbtnRefresh.Enabled = True
		Me.tbtnHistory.Enabled = True
		Me.tbtnMonitorDef.Enabled = True

        lblMonitorName.Text = Metadata.MonitorName
		lblMonitorType.Text = Metadata.MonitorType

		If Metadata.Enabled Then
			lblLifetimePercUptime.Text = Format(CurrStatus.CurrentStatus.LifetimePercUptime, "##0.00 \%")

			lblOT1.Text = Metadata.OfflineTime1.StartTime & " - " & Metadata.OfflineTime1.EndTime
			lblOT2.Text = Metadata.OfflineTime2.StartTime & " - " & Metadata.OfflineTime2.EndTime

			lblStatus.Text = CurrStatus.CurrentStatus.Status.ToString
			txtStatusMessage.Text = CurrStatus.CurrentStatus.StatusMessage
			lblEventDT.Text = Format(CurrStatus.CurrentStatus.EventDate, "MMM dd, yyyy hh:mm:ss tt")

			Select Case CurrStatus.CurrentStatus.Status
				Case PolyMon.Monitors.MonitorStatus.eStatus.Unknown
                    pcbStatus.Image = Me.ImageListStatus_Large.Images(0)
                    lblMonitorName.ForeColor = Color.LightGray
				Case PolyMon.Monitors.MonitorStatus.eStatus.OK
					pcbStatus.Image = Me.ImageListStatus_Large.Images(1)
                    lblMonitorName.ForeColor = Color.LightSkyBlue
				Case PolyMon.Monitors.MonitorStatus.eStatus.Warning
					pcbStatus.Image = Me.ImageListStatus_Large.Images(2)
                    lblMonitorName.ForeColor = Color.Khaki
				Case PolyMon.Monitors.MonitorStatus.eStatus.Fail
					pcbStatus.Image = Me.ImageListStatus_Large.Images(3)
                    lblMonitorName.ForeColor = Color.OrangeRed
			End Select

			Me.lblDetails_Started.Text = Format(CurrStatus.CurrentStatus.StatusStartDT, "MMM dd, yyyy hh:mm:ss tt")
			Me.lblDetails_Ended.Text = Format(CurrStatus.CurrentStatus.StatusEndDT, "MMM dd, yyyy hh:mm:ss tt")
			Me.lblDetails_Elapsed.Text = CurrStatus.CurrentStatus.StatusElapsedTxt

			'And add Counter Info
			Dim Counters As DataTable
			Counters = CurrStatus.CurrentStatus.Counters
			Me.dgvCounters.DataSource = Counters
			Me.dgvCounters.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
		Else
			pcbStatus.Image = Me.ImageListStatus_Large.Images(4)
            lblMonitorName.ForeColor = Color.LightGray

			lblLifetimePercUptime.Text = Nothing

			lblOT1.Text = Metadata.OfflineTime1.StartTime & " - " & Metadata.OfflineTime1.EndTime
			lblOT2.Text = Metadata.OfflineTime2.StartTime & " - " & Metadata.OfflineTime2.EndTime

			lblStatus.Text = "Disabled"
			txtStatusMessage.Text = Nothing
			lblEventDT.Text = Nothing

			Me.dgvCounters.DataSource = Nothing
		End If
	End Sub
	Private Sub ClearMonitorDetails()
		lblAsOfLabel.Visible = False
		lblOfflineTimesLabel.Visible = False
		Me.tbtnRun.Enabled = False
		Me.tbtnRefresh.Enabled = False
		Me.tbtnHistory.Enabled = False
		Me.tbtnMonitorDef.Enabled = False
        lblMonitorName.Text = Nothing
		lblMonitorType.Text = Nothing
		lblOT1.Text = Nothing
		lblOT2.Text = Nothing
		lblStatus.Text = Nothing
		txtStatusMessage.Text = Nothing
		lblEventDT.Text = Nothing
		lblLifetimePercUptime.Text = Nothing
		Me.dgvCounters.DataSource = Nothing
	End Sub
	Private Sub SetViewStyle(ByVal ViewStyle As System.Windows.Forms.View)
		With lvMonitors
			.BeginUpdate()
			Select Case ViewStyle
				Case View.Details
					.View = View.Details
					If .Columns.IndexOfKey("Name") < 0 Then .Columns.Add("Name", "Name")
					If .Columns.IndexOfKey("Monitor Type") < 0 Then .Columns.Add("Monitor Type", "Monitor Type")
					If .Columns.IndexOfKey("Event DT") < 0 Then .Columns.Add("Event DT", "Event DT")
					If .Columns.IndexOfKey("Status") < 0 Then .Columns.Add("Status", "Status")

					If .Columns.IndexOfKey("Curr Status Start") < 0 Then .Columns.Add("Curr Status Start", "Curr Status Start")
					If .Columns.IndexOfKey("Curr Status End") < 0 Then .Columns.Add("Curr Status End", "Curr Status End")
					If .Columns.IndexOfKey("Time in Curr Status (secs)") < 0 Then .Columns.Add("Time in Curr Status (secs)", "Time in Curr Status (secs)")
					If .Columns.IndexOfKey("Time in Curr Status") < 0 Then .Columns.Add("Time in Curr Status", "Time in Curr Status")

					If .Columns.IndexOfKey("LifetimePercUp") < 0 Then .Columns.Add("LifetimePercUp", "LifetimePercUp")
					If .Columns.IndexOfKey("Status Message") < 0 Then .Columns.Add("Status Message", "Status Message")
					.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
					.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
					Me.tbtnDetails.Checked = True
					Me.tbtnTiles.Checked = False
					Me.tbtnIcons.Checked = False
				Case View.Tile
					.Visible = False
					.View = View.Tile
					.TileSize = New Drawing.Size(140, 70)
					If .Columns.IndexOfKey("Name") < 0 Then .Columns.Add("Name", "Name")
					If .Columns.IndexOfKey("Monitor Type") < 0 Then .Columns.Add("Monitor Type", "Monitor Type")
					If .Columns.IndexOfKey("Event DT") >= 0 Then .Columns.Remove(.Columns("Event DT"))
					If .Columns.IndexOfKey("Status") >= 0 Then .Columns.Remove(.Columns("Status"))

					If .Columns.IndexOfKey("Curr Status Start") >= 0 Then .Columns.Remove(.Columns("Curr Status Start"))
					If .Columns.IndexOfKey("Curr Status End") >= 0 Then .Columns.Remove(.Columns("Curr Status End"))
					If .Columns.IndexOfKey("Time in Curr Status (secs)") >= 0 Then .Columns.Remove(.Columns("Time in Curr Status (secs)"))
					If .Columns.IndexOfKey("Time in Curr Status") >= 0 Then .Columns.Remove(.Columns("Time in Curr Status"))

					If .Columns.IndexOfKey("LifetimePercUp") >= 0 Then .Columns.Remove(.Columns("LifetimePercUp"))
					If .Columns.IndexOfKey("Status Message") >= 0 Then .Columns.Remove(.Columns("Status Message"))
					.Visible = True
					Me.tbtnDetails.Checked = False
					Me.tbtnTiles.Checked = True
					Me.tbtnIcons.Checked = False
				Case Else
					.View = View.LargeIcon
					Me.tbtnDetails.Checked = False
					Me.tbtnTiles.Checked = False
					Me.tbtnIcons.Checked = True
			End Select
			.EndUpdate()
		End With
	End Sub
	Private Sub RunMonitor(ByVal MonitorID As Integer)
		Dim AssemblyPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "Monitors/"
		Dim MonitorMetadata As New PolyMon.Monitors.MonitorMetadata(MonitorID)
		Dim MonitorAssembly As String = MonitorMetadata.MonitorAssembly
		Dim myMonitor As PolyMon.Monitors.MonitorExecutor = Nothing

		Dim asm As Reflection.Assembly
		Dim MonitorType As Type = Nothing
		Dim ty As Type
		Dim types() As Type
		Dim ci As Reflection.ConstructorInfo
		Dim params() As Object
		Dim obj As Object
		Dim apppath As String = System.AppDomain.CurrentDomain.BaseDirectory()

		asm = Reflection.Assembly.LoadFrom(AssemblyPath & MonitorAssembly)
		For Each ty In asm.GetExportedTypes
			If ty.BaseType.FullName = GetType(PolyMon.Monitors.MonitorExecutor).FullName Then
				MonitorType = ty
				Exit For
			End If
		Next
		If Not (MonitorType Is Nothing) Then
			types = New Type() {GetType(System.Int32)}
			ci = MonitorType.GetConstructor(types)
			params = New Object() {MonitorID}
			obj = ci.Invoke(params)
			myMonitor = DirectCast(obj, PolyMon.Monitors.MonitorExecutor)
		End If

		myMonitor.ManualOverride = True
		myMonitor.ForceLog = True
		myMonitor.RunMonitor()

		MonitorMetadata = Nothing
		myMonitor = Nothing
	End Sub

	Private Class ListViewItemComparer
		Implements IComparer

		Private mCol As Integer
		Private mSortAscending As Boolean = True

		Public Sub New()
			mCol = 0
		End Sub

		Public ReadOnly Property Column() As Integer
			Get
				Return mCol
			End Get
		End Property

		Public ReadOnly Property SortAscending() As Boolean
			Get
				Return mSortAscending
			End Get
		End Property

		Public Sub New(ByVal Column As Integer, ByVal SortAscending As Boolean)
			mCol = Column
			mSortAscending = SortAscending
		End Sub

		Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

			Try
				If CType(x, ListViewItem).SubItems.Count > mCol AndAlso CType(y, ListViewItem).SubItems.Count > mCol Then
					Dim Val1 As Object = CType(x, ListViewItem).SubItems(mCol).Text
					Dim Val2 As Object = CType(y, ListViewItem).SubItems(mCol).Text

					If IsNumeric(Val1) AndAlso IsNumeric(Val2) Then
						'Do a numeric comparison
						If CDbl(Val1) < CDbl(Val2) Then
							If mSortAscending Then
								Return -1
							Else
								Return 1
							End If
						ElseIf CDbl(Val1) = CDbl(Val2) Then
							Return 0
						Else
							If mSortAscending Then
								Return 1
							Else
								Return -1
							End If
						End If
					ElseIf TypeOf (Val1) Is Date AndAlso TypeOf (Val2) Is Date Then
						'Do a date comparison
						If CDate(Val1) < CDate(Val2) Then
							If mSortAscending Then
								Return -1
							Else
								Return 1
							End If
						ElseIf CDate(Val1) = CDate(Val2) Then
							Return 0
						Else
							If mSortAscending Then
								Return 1
							Else
								Return -1
							End If
						End If
					Else
						'Do a string compare
						If mSortAscending Then
							Return [String].Compare(CType(x, ListViewItem).SubItems(mCol).Text, CType(y, ListViewItem).SubItems(mCol).Text)
						Else
							Return [String].Compare(CType(y, ListViewItem).SubItems(mCol).Text, CType(x, ListViewItem).SubItems(mCol).Text)
						End If
					End If
				Else
					Return 0
				End If
			Catch ex As Exception
				Return 0
			End Try
		End Function
	End Class
#End Region


End Class