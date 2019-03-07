Imports System.Xml
Imports System.Text
Imports System.ServiceProcess

Public Class frmMonitorDefs

#Region "Public Interface"
    Public Sub New()
        InitializeComponent()
        InitForm()
    End Sub
    Public Sub New(ByVal MonitorID As Integer)
        InitializeComponent()

        InitForm()

        'Pre-select the specified Monitor in the monitor list (and implicitly loads Monitor metadata)
        lstviewMonitors.Items(CStr(MonitorID)).Selected = True
    End Sub
    Public Sub EditMonitor(ByVal MonitorID As Integer)
        lstviewMonitors.Items(CStr(MonitorID)).Selected = True
        lstviewMonitors.Items(CStr(MonitorID)).EnsureVisible()
    End Sub
#End Region

#Region "Private Attributes"
    Private mCurrMonitorDef As PolyMon.Monitors.MonitorMetadata = Nothing
    Private mIsNewCurrMonitorDef As Boolean = False
	Private mEditor As PolyMon.MonitorEditors.GenericMonitorEditor
	Private mIsLoading As Boolean = False
	Dim mDialogDeleting As dlgDeleting = Nothing
#End Region

#Region "Event Handlers"
    Private Sub lstviewMonitors_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstviewMonitors.ColumnClick
        Dim CurrColumn As Integer
        If lstviewMonitors.ListViewItemSorter Is Nothing Then
            Me.lstviewMonitors.ListViewItemSorter = New ListViewItemComparer(e.Column, True)
        Else
            CurrColumn = CType(lstviewMonitors.ListViewItemSorter, ListViewItemComparer).Column
            If CurrColumn = e.Column Then
                Me.lstviewMonitors.ListViewItemSorter = New ListViewItemComparer(e.Column, Not (CType(lstviewMonitors.ListViewItemSorter, ListViewItemComparer).SortAscending))
            Else
                Me.lstviewMonitors.ListViewItemSorter = New ListViewItemComparer(e.Column, True)
            End If
        End If
    End Sub
    Private Sub lstviewMonitors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstviewMonitors.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        'Load Monitor Metadata
        If lstviewMonitors.SelectedItems.Count > 0 Then
            LoadMonitorData(CInt(lstviewMonitors.SelectedItems(0).SubItems(0).Name))
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub radEveryNEvents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radEveryNEvents.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        SetRuleState(Me.radEveryNEvents.Checked)
        Me.Cursor = Cursors.Default
    End Sub
	Private Sub cboMonitorType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonitorType.SelectedIndexChanged
		If mIsLoading Then Exit Sub 'Loading monitor - loading/populating custom editor will be handled separately
		Dim MonitorType As PolyMon.MonitorTypes.MonitorType

		If Not (Me.cboMonitorType.SelectedItem Is Nothing) Then
			MonitorType = CType(Me.cboMonitorType.SelectedItem, PolyMon.MonitorTypes.MonitorType)
			LoadMonitorEditor(MonitorType.EditorAssembly, MonitorType.XMLTemplate)
			mEditor.LoadTemplateDefaults()
		End If
	End Sub
    Private Sub tsbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancel.Click
        Me.Cursor = Cursors.WaitCursor
        If Not mCurrMonitorDef Is Nothing Then
            If Me.mIsNewCurrMonitorDef Then
                ClearMonitorData()
            Else
                LoadMonitorData(mCurrMonitorDef.MonitorID)
            End If
        Else
            ClearMonitorData()
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Me.Cursor = Cursors.WaitCursor
        SaveMonitorData()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tsbNewMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNewMonitor.Click
        Me.Cursor = Cursors.WaitCursor
        CreateNewMonitor(False)
        Me.tabMonitors.SelectedTab = Me.tabSettings
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tsbClone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClone.Click
        Me.Cursor = Cursors.WaitCursor
        CreateNewMonitor(True)
        Me.tabMonitors.SelectedTab = Me.tabSettings
        Me.Cursor = Cursors.Default
	End Sub
	Private Sub tsbDeleteData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDeleteData.Click
		Me.Cursor = Cursors.WaitCursor
		DeleteMonitorData()
		Me.Cursor = Cursors.Default
	End Sub
    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click
        Me.Cursor = Cursors.WaitCursor
        DeleteMonitor()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnInsertSubjectTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertSubjectTemplate.Click
        If Me.cboSubjectTemplates.Text.Length > 0 Then
            With txtSubjectTemplate
                .Text = .Text.Insert(.SelectionStart, cboSubjectTemplates.Text)
            End With
        End If
    End Sub
    Private Sub btnInsertBodyTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertBodyTemplate.Click
        If Me.cboBodyTemplates.Text.Length > 0 Then
            With txtBodyTemplate
                .Text = .Text.Insert(.SelectionStart, cboBodyTemplates.Text)
            End With
        End If
    End Sub
    Private Sub lstAvailableOperators_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAvailableOperators.SelectedIndexChanged
        Me.btnAddOperator.Enabled = True
        Me.btnRemoveOperator.Enabled = False
    End Sub
    Private Sub lstMonitorOperators_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMonitorOperators.SelectedIndexChanged
        Me.btnAddOperator.Enabled = False
        Me.btnRemoveOperator.Enabled = True
    End Sub
    Private Sub btnAddOperator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOperator.Click
        If Not (Me.lstAvailableOperators.SelectedItem Is Nothing) Then
            Dim PMOperator As PolyMon.Operators.PMOperator = CType(lstAvailableOperators.SelectedItem, PolyMon.Operators.PMOperator)
            If Not (OperatorExists(PMOperator.OperatorID, Me.lstMonitorOperators)) Then
                Me.lstMonitorOperators.Items.Add(PMOperator)
                Me.lstAvailableOperators.Items.Remove(Me.lstAvailableOperators.SelectedItem)
            End If
        End If
    End Sub
    Private Sub btnRemoveOperator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOperator.Click
        If Not (Me.lstMonitorOperators.SelectedItem Is Nothing) Then
            Dim PMOperator As PolyMon.Operators.PMOperator = CType(lstMonitorOperators.SelectedItem, PolyMon.Operators.PMOperator)
            Me.lstAvailableOperators.Items.Add(PMOperator)
            Me.lstMonitorOperators.Items.Remove(Me.lstMonitorOperators.SelectedItem)
        End If
    End Sub
    Private Sub btnRunMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunMonitor.Click
        If Me.mIsNewCurrMonitorDef Then
            MsgBox("You must save (create) this monitor in the database before testing.", MsgBoxStyle.Information, "PolyMon")
        Else
            If Me.mCurrMonitorDef Is Nothing Then
                MsgBox("You must first select a Monitor.", MsgBoxStyle.Information, "PolyMon")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            RunMonitor(Me.mCurrMonitorDef.MonitorID)
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub trRaw_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trRaw.ValueChanged
        Me.lblRaw.Text = String.Format("{0} Months", trRaw.Value.ToString())
        If trDaily.Value < trRaw.Value Then trDaily.Value = trRaw.Value
    End Sub
    Private Sub trDaily_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trDaily.ValueChanged
        Me.lblDaily.Text = String.Format("{0} Months", trDaily.Value.ToString())
        If trWeekly.Value < trDaily.Value Then trWeekly.Value = trDaily.Value
        If trDaily.Value < trRaw.Value Then trDaily.Value = trRaw.Value
    End Sub
    Private Sub trWeekly_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trWeekly.ValueChanged
        Me.lblWeekly.Text = String.Format("{0} Months", trWeekly.Value.ToString())
        If trMonthly.Value < trWeekly.Value Then trMonthly.Value = trWeekly.Value
        If trWeekly.Value < trDaily.Value Then trWeekly.Value = trDaily.Value
    End Sub
    Private Sub trMonthly_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trMonthly.ValueChanged
        Me.lblMonthly.Text = String.Format("{0} Months", trMonthly.Value.ToString())
        If trMonthly.Value < trWeekly.Value Then trMonthly.Value = trWeekly.Value
	End Sub
	Private Sub btnLoadDefaultScriptTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadDefaultScriptTemplate.Click
		If Me.cboScriptEngine.SelectedIndex > -1 Then
			Me.rtfScript.Text = CType(cboScriptEngine.SelectedItem, PolyMon.ScriptEngines.ScriptEngine).DefaultTemplate
		End If
	End Sub
#End Region

#Region "Private Methods"
    Private Sub InitForm()

        SetEditState(False)

        'Init Offline Time Drop-Downs for Monitor Defs
        Dim CBHStart As ComboBox
        Dim cbMStart As ComboBox
        Dim cbHEnd As ComboBox
        Dim cbMEnd As ComboBox
        Dim i As Integer

        CBHStart = (CType(Me.cboOT1_Start_Hour, ComboBox))
        cbMStart = CType(Me.cboOT1_Start_Minutes, ComboBox)
        cbHEnd = CType(Me.cboOT1_End_Hour, ComboBox)
        cbMEnd = CType(Me.cboOT1_End_Minutes, ComboBox)
        CBHStart.Items.Clear()
        cbMStart.Items.Clear()
        cbHEnd.Items.Clear()
        cbMEnd.Items.Clear()
        For i = 0 To 23
            CBHStart.Items.Add(Format(i, "00"))
            cbHEnd.Items.Add(Format(i, "00"))
        Next
        For i = 0 To 59 Step 10
            cbMStart.Items.Add(Format(i, "00"))
            cbMEnd.Items.Add(Format(i, "00"))
        Next

        CBHStart = (CType(Me.cboOT2_Start_Hour, ComboBox))
        cbMStart = CType(Me.cboOT2_Start_Minutes, ComboBox)
        cbHEnd = CType(Me.cboOT2_End_Hour, ComboBox)
        cbMEnd = CType(Me.cboOT2_End_Minutes, ComboBox)
        CBHStart.Items.Clear()
        cbMStart.Items.Clear()
        cbHEnd.Items.Clear()
        cbMEnd.Items.Clear()
        For i = 0 To 23
            CBHStart.Items.Add(Format(i, "00"))
            cbHEnd.Items.Add(Format(i, "00"))
        Next
        For i = 0 To 59 Step 10
            cbMStart.Items.Add(Format(i, "00"))
            cbMEnd.Items.Add(Format(i, "00"))
        Next

        'Subject Templates
        With cboSubjectTemplates
            .Items.Clear()
            .Items.Add("<%Monitor%>")
            .Items.Add("<%MonitorType%>")
            .Items.Add("<%EventDT%>")
            .Items.Add("<%Status%>")
            .Items.Add("<%StatusID%>")
        End With


        'Body Templates
        With cboBodyTemplates
            .Items.Clear()
            .Items.Add("<%Monitor%>")
            .Items.Add("<%MonitorType%>")
            .Items.Add("<%EventDT%>")
            .Items.Add("<%Status%>")
            .Items.Add("<%StatusID%>")
			.Items.Add("<%EventMessage%>")
			.Items.Add("<%CurrStatusExtInfo%>")
        End With

		'Script Engines
		With Me.cboScriptEngine
			.Items.Clear()
			.DisplayMember = "Engine"
			.ValueMember = "EngineID"
			Dim ScriptEngines As New PolyMon.ScriptEngines.ScriptEngines()
			For Each Engine As PolyMon.ScriptEngines.ScriptEngine In ScriptEngines.Engines
				.Items.Add(Engine)
			Next
			.SelectedIndex = 0
		End With

        'Operator Lists
        With Me.lstAvailableOperators
            .DisplayMember = "Name"
            .ValueMember = "OperatorID"
        End With
        With Me.lstMonitorOperators
            .DisplayMember = "Name"
            .ValueMember = "OperatorID"
        End With
        Me.btnAddOperator.Enabled = False
        Me.btnRemoveOperator.Enabled = False

        'Load Monitor Type List
        LoadMonitorTypeList()

        'Load Monitor List
        LoadMonitorList()

        'Counter Grid
        With Me.dgvCounters
            .Columns.Add("Counter", "Counter")
            .Columns.Add("Value", "Value")
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .AlternatingRowsDefaultCellStyle.BackColor = Color.NavajoWhite
            .RowHeadersVisible = False
            .Visible = False
        End With
	End Sub

	Private Sub ClearMonitorData()
		Me.mIsNewCurrMonitorDef = False
		Me.mCurrMonitorDef = Nothing

		'Main Settings
		Me.chkEnabled.Checked = False
		Me.udTriggerMod.Value = 1
		Me.txtName.Text = Nothing
		Me.cboMonitorType.SelectedIndex = -1

		If Not mEditor Is Nothing Then mEditor.LoadTemplateDefaults()

		Me.cboOT1_Start_Hour.Text = "00"
		Me.cboOT1_Start_Minutes.Text = "00"
		Me.cboOT1_End_Hour.Text = "00"
		Me.cboOT1_End_Minutes.Text = "00"

		Me.cboOT2_Start_Hour.Text = "00"
		Me.cboOT2_Start_Minutes.Text = "00"
		Me.cboOT2_End_Hour.Text = "00"
		Me.cboOT2_End_Minutes.Text = "00"

		'Message Templates
		Me.txtSubjectTemplate.Text = Nothing
		Me.txtBodyTemplate.Text = Nothing

		'Rules
		Me.radEveryNEvents.Checked = True
		Me.chkAfterEveryNewFailure.Checked = False
		Me.chkAfterEveryNewWarning.Checked = False
		Me.chkAfterEveryNFailures.Checked = False
		Me.chkAfterEveryNWarnings.Checked = False
		Me.chkEveryFailToOK.Checked = False
		Me.chkEveryWarnToOK.Checked = False
		Me.udEveryNEvents.Value = 1
		Me.udEveryNFailures.Value = 1
		Me.udEveryNWarnings.Value = 1
		SetRuleState(True)

		'Action Scripts
		Me.cboScriptEngine.SelectedIndex = 0
		Me.rtfScript.Text = Nothing
		Me.chkScriptEnabled.Checked = False
		SetActionScriptState(False)

		'Operators
		Me.lstAvailableOperators.Items.Clear()
		Me.lstMonitorOperators.Items.Clear()

		'RetentionSchedule
		Me.trRaw.Value = 1
		Me.trDaily.Value = 1
		Me.trWeekly.Value = 1
		Me.trMonthly.Value = 1

		'Test Results
		Me.txtResults.Text = Nothing
		Me.dgvCounters.Rows.Clear()

		'Set Edit State to Off
		SetEditState(False)
	End Sub
    Private Sub SetRuleState(ByVal AfterEveryNEvent As Boolean)
        Me.radEveryNEvents.Checked = AfterEveryNEvent
        Me.radAlertAfterOther.Checked = Not (AfterEveryNEvent)

        Me.udEveryNEvents.Enabled = AfterEveryNEvent

        Me.chkAfterEveryNewFailure.Enabled = Not (AfterEveryNEvent)
        Me.chkAfterEveryNFailures.Enabled = Not (AfterEveryNEvent)
        Me.udEveryNFailures.Enabled = Not (AfterEveryNEvent)
        Me.chkEveryFailToOK.Enabled = Not (AfterEveryNEvent)

        Me.chkAfterEveryNewWarning.Enabled = Not (AfterEveryNEvent)
        Me.chkAfterEveryNWarnings.Enabled = Not (AfterEveryNEvent)
        Me.udEveryNWarnings.Enabled = Not (AfterEveryNEvent)
        Me.chkEveryWarnToOK.Enabled = Not (AfterEveryNEvent)
    End Sub
    Private Sub LoadMonitorList(Optional ByVal MonitorID As Integer = -1)
        Dim Monitors As New PolyMon.Monitors.MonitorList()
        Dim Monitor As PolyMon.Monitors.MonitorMetadata
        Dim ListItem As ListViewItem

        SetEditState(False)
        lstviewMonitors.Items.Clear()
        For Each Monitor In Monitors
            ListItem = New ListViewItem(Monitor.MonitorName, -1)
            ListItem.Name = CStr(Monitor.MonitorID)
            'ListItem.Text = Monitor.MonitorName
            'ListItem.ImageIndex = Nothing
            ListItem.SubItems.Add(Monitor.MonitorType)
            ListItem.SubItems.Add(CStr(IIf(Monitor.Enabled, "Yes", "No")))
            ListItem.SubItems.Add(CStr(Monitor.TriggerMod))
            ListItem.SubItems.Add(CStr(Monitor.MonitorID))
            'ListItem = lstviewMonitors.Items.Add(CStr(Monitor.MonitorID), Monitor.MonitorName, CStr(Nothing))
            lstviewMonitors.Items.Add(ListItem)
            

            If MonitorID > -1 Then
                If Monitor.MonitorID = MonitorID Then
                    'Pre-select this monitor
                    ListItem.Selected = True
                    'ListItem.EnsureVisible()
                    SetEditState(True)
                End If
            End If
        Next
        If lstviewMonitors.SelectedItems.Count > 0 Then lstviewMonitors.SelectedItems(0).EnsureVisible()
    End Sub
    Private Sub LoadMonitorData(Optional ByVal MonitorID As Integer = -1)
        ClearMonitorData()
        If MonitorID = -1 Then
            mCurrMonitorDef = New PolyMon.Monitors.MonitorMetadata()
            LoadAvailableOperators()
            Me.txtSubjectTemplate.Text = DefaultEmailSubject()
            Me.txtBodyTemplate.Text = DefaultEmailBody()
            trRaw.Value = mCurrMonitorDef.RetentionRaw
            trDaily.Value = mCurrMonitorDef.RetentionDaily
            trWeekly.Value = mCurrMonitorDef.RetentionWeekly
            trMonthly.Value = mCurrMonitorDef.RetentionMonthly
            mIsNewCurrMonitorDef = True
            SetEditState(True)
        Else
            mCurrMonitorDef = New PolyMon.Monitors.MonitorMetadata(MonitorID)

            'General Settings
            Me.chkEnabled.Checked = mCurrMonitorDef.Enabled
            Me.udTriggerMod.Value = mCurrMonitorDef.TriggerMod
            Me.txtName.Text = mCurrMonitorDef.MonitorName

			mIsLoading = True
			Dim MonitorType As New PolyMon.MonitorTypes.MonitorType(mCurrMonitorDef.MonitorTypeID)
			Me.cboMonitorType.Text = mCurrMonitorDef.MonitorType
			LoadMonitorEditor(MonitorType.EditorAssembly, MonitorType.XMLTemplate)
			mEditor.XMLTemplate = MonitorType.XMLTemplate
			mEditor.XMLSettings = CStr(mCurrMonitorDef.MonitorXMLString)
			mIsLoading = False


			Me.cboOT1_Start_Hour.Text = mCurrMonitorDef.OfflineTime1.StartTime.Split(CChar(":"))(0)
			Me.cboOT1_Start_Minutes.Text = mCurrMonitorDef.OfflineTime1.StartTime.Split(CChar(":"))(1)
			Me.cboOT1_End_Hour.Text = mCurrMonitorDef.OfflineTime1.EndTime.Split(CChar(":"))(0)
			Me.cboOT1_End_Minutes.Text = mCurrMonitorDef.OfflineTime1.EndTime.Split(CChar(":"))(1)

			Me.cboOT2_Start_Hour.Text = mCurrMonitorDef.OfflineTime2.StartTime.Split(CChar(":"))(0)
			Me.cboOT2_Start_Minutes.Text = mCurrMonitorDef.OfflineTime2.StartTime.Split(CChar(":"))(1)
			Me.cboOT2_End_Hour.Text = mCurrMonitorDef.OfflineTime2.EndTime.Split(CChar(":"))(0)
			Me.cboOT2_End_Minutes.Text = mCurrMonitorDef.OfflineTime2.EndTime.Split(CChar(":"))(1)

			'Notification Templates
			Me.txtSubjectTemplate.Text = mCurrMonitorDef.MessageSubjectTemplate
			Me.txtBodyTemplate.Text = mCurrMonitorDef.MessageBodyTemplate

			'Notification Rules
			If mCurrMonitorDef.AlertAfterEveryNEvent > 0 Then
				SetRuleState(True)
				Me.radEveryNEvents.Checked = True
				Me.radAlertAfterOther.Checked = False
				Me.udEveryNEvents.Value = mCurrMonitorDef.AlertAfterEveryNEvent
			Else
				SetRuleState(False)
				Me.radEveryNEvents.Checked = False
				Me.radAlertAfterOther.Checked = True

				Me.chkAfterEveryNewFailure.Checked = mCurrMonitorDef.AlertAfterEveryNewFailure
				If mCurrMonitorDef.AlertAfterEveryNFailures > 0 Then
					Me.chkAfterEveryNFailures.Checked = True
					Me.udEveryNFailures.Value = mCurrMonitorDef.AlertAfterEveryNFailures
				Else
					Me.chkAfterEveryNFailures.Checked = False
					Me.udEveryNFailures.Value = 1
				End If
				Me.chkEveryFailToOK.Checked = mCurrMonitorDef.AlertAfterEveryFailToOK

				Me.chkAfterEveryNewWarning.Checked = mCurrMonitorDef.AlertAfterEveryNewWarning
				If mCurrMonitorDef.AlertAfterEveryNWarnings > 0 Then
					Me.chkAfterEveryNWarnings.Checked = True
					Me.udEveryNWarnings.Value = mCurrMonitorDef.AlertAfterEveryNWarnings
				Else
					Me.chkAfterEveryNWarnings.Checked = False
					Me.udEveryNWarnings.Value = 1
				End If
				Me.chkEveryWarnToOK.Checked = mCurrMonitorDef.AlertAfterEveryWarnToOK
			End If

			'Action Script
			If mCurrMonitorDef.AfterEventScriptEngine IsNot Nothing Then
				For i As Integer = 0 To cboScriptEngine.Items.Count - 1
					If CType(Me.cboScriptEngine.Items(i), PolyMon.ScriptEngines.ScriptEngine).EngineID = mCurrMonitorDef.AfterEventScriptEngine.EngineID Then
						Me.cboScriptEngine.SelectedIndex = i
					End If
				Next
			End If
			Me.chkScriptEnabled.Checked = mCurrMonitorDef.AfterEventIsEnabled
			Me.rtfScript.Text = mCurrMonitorDef.AfterEventScript
			SetActionScriptState(mCurrMonitorDef.AfterEventIsEnabled)

			'Monitor Operators
			Dim PMOperator As PolyMon.Operators.PMOperator

			Dim MonitorOperators As PolyMon.Operators.MonitorOperators = New PolyMon.Operators.MonitorOperators(mCurrMonitorDef.MonitorID)
			Me.lstMonitorOperators.BeginUpdate()
			Me.lstMonitorOperators.Items.Clear()
			For Each PMOperator In MonitorOperators
				Me.lstMonitorOperators.Items.Add(PMOperator)
			Next
			Me.lstMonitorOperators.EndUpdate()

			LoadAvailableOperators()

			'Retention Schedule
			Me.trRaw.Value = mCurrMonitorDef.RetentionRaw
			Me.trDaily.Value = mCurrMonitorDef.RetentionDaily
			Me.trWeekly.Value = mCurrMonitorDef.RetentionWeekly
			Me.trMonthly.Value = mCurrMonitorDef.RetentionMonthly

			SetEditState(True)
		End If
    End Sub
    Private Sub LoadMonitorTypeList()
        Dim MonitorTypes As New PolyMon.MonitorTypes.MonitorTypes

        cboMonitorType.Items.Clear()
        cboMonitorType.ValueMember = "MonitorTypeID"
        cboMonitorType.DisplayMember = "Name"
        For Each MonitorType As PolyMon.MonitorTypes.MonitorType In MonitorTypes
            cboMonitorType.Items.Add(MonitorType)
        Next
    End Sub
    Private Sub LoadAvailableOperators()
        Dim PMOperator As PolyMon.Operators.PMOperator
        Me.lstAvailableOperators.BeginUpdate()
        Me.lstAvailableOperators.Items.Clear()
        Dim AvailableOperators As PolyMon.Operators.PMOperators = New PolyMon.Operators.PMOperators()
        For Each PMOperator In AvailableOperators
            If Not (OperatorExists(PMOperator.OperatorID, Me.lstMonitorOperators)) Then

                Me.lstAvailableOperators.Items.Add(PMOperator)
            End If
        Next
        Me.lstAvailableOperators.EndUpdate()
    End Sub
    Private Sub SaveMonitorData()
        If Not (ValidateData()) Then Exit Sub
        With mCurrMonitorDef
            Try
                .Enabled = Me.chkEnabled.Checked
                .TriggerMod = CInt(Me.udTriggerMod.Value)
                .MonitorName = Me.txtName.Text
                .MonitorTypeID = CType(Me.cboMonitorType.SelectedItem, PolyMon.MonitorTypes.MonitorType).MonitorTypeID

                .MonitorXMLString = mEditor.XMLSettings

                .OfflineTime1.StartTime = Me.cboOT1_Start_Hour.Text & ":" & Me.cboOT1_Start_Minutes.Text
                .OfflineTime1.EndTime = Me.cboOT1_End_Hour.Text & ":" & Me.cboOT1_End_Minutes.Text
                .OfflineTime2.StartTime = Me.cboOT2_Start_Hour.Text & ":" & Me.cboOT2_Start_Minutes.Text
                .OfflineTime2.EndTime = Me.cboOT2_End_Hour.Text & ":" & Me.cboOT2_End_Minutes.Text

                .MessageSubjectTemplate = Me.txtSubjectTemplate.Text
                .MessageBodyTemplate = Me.txtBodyTemplate.Text

                If Me.radEveryNEvents.Checked Then
                    .AlertAfterEveryNEvent = CInt(Me.udEveryNEvents.Value)
                Else
                    .AlertAfterEveryNEvent = 0
                    .AlertAfterEveryNewFailure = Me.chkAfterEveryNewFailure.Checked
                    If Me.chkAfterEveryNFailures.Checked Then
                        .AlertAfterEveryNFailures = CInt(Me.udEveryNFailures.Value)
                    Else
                        .AlertAfterEveryNFailures = 0
                    End If
                    .AlertAfterEveryFailToOK = Me.chkEveryFailToOK.Checked

                    .AlertAfterEveryNewWarning = Me.chkAfterEveryNewWarning.Checked
                    If Me.chkAfterEveryNWarnings.Checked Then
                        .AlertAfterEveryNWarnings = CInt(Me.udEveryNWarnings.Value)
                    Else
                        .AlertAfterEveryNWarnings = 0
                    End If
                    .AlertAfterEveryWarnToOK = Me.chkEveryWarnToOK.Checked
                End If

                .RetentionRaw = trRaw.Value
                .RetentionDaily = trDaily.Value
                .RetentionWeekly = trWeekly.Value
                .RetentionMonthly = trMonthly.Value

				.AfterEventIsEnabled = Me.chkScriptEnabled.Checked
				.AfterEventScriptEngine = CType(Me.cboScriptEngine.SelectedItem, PolyMon.ScriptEngines.ScriptEngine)
				.AfterEventScript = Me.rtfScript.Text

                .Save()

                'Now save operators
                Dim MonitorOperators As PolyMon.Operators.MonitorOperators = New PolyMon.Operators.MonitorOperators(mCurrMonitorDef.MonitorID)
                Dim PMOperator As PolyMon.Operators.PMOperator
                'Remove applicable operators
                For Each PMOperator In MonitorOperators
                    If Not (OperatorExists(PMOperator.OperatorID, Me.lstMonitorOperators)) Then
                        MonitorOperators.Remove(PMOperator)
                    End If
                Next
                'Add applicable operators
                For Each PMOperator In Me.lstMonitorOperators.Items
                    If Not (OperatorExists(PMOperator.OperatorID, MonitorOperators)) Then
                        MonitorOperators.Add(PMOperator)
                    End If
                Next

                Me.mIsNewCurrMonitorDef = False
                LoadMonitorList(Me.mCurrMonitorDef.MonitorID)
            Catch ex As Exception
                MsgBox("Error saving Monitor Definition:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Polymon Error...")
            End Try
        End With
    End Sub
    Private Sub CreateNewMonitor(ByVal Clone As Boolean)
        'Create a new monitor
        For Each item As ListViewItem In Me.lstviewMonitors.SelectedItems
            item.Selected = False
        Next
        If Clone Then
            'Leave existing data as is but clear out Name and current monitor
            Me.txtName.Text = Nothing
            mCurrMonitorDef = New PolyMon.Monitors.MonitorMetadata()
            LoadAvailableOperators()
            'Dim MonitorType As New PolyMon.MonitorTypes.MonitorType(mCurrMonitorDef.MonitorTypeID)
            'LoadMonitorEditor(MonitorType.EditorAssembly, MonitorType.XMLTemplate)
            'mEditor.LoadTemplateDefaults()
            mIsNewCurrMonitorDef = True
            SetEditState(True)
        Else
            LoadMonitorData(-1)
            LoadMonitorEditor(Nothing, Nothing)
        End If

    End Sub


    Private Sub RunMonitor(ByVal MonitorID As Integer)
        Dim AssemblyPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "Monitors/"
        Dim MonitorAssembly As String = Me.mCurrMonitorDef.MonitorAssembly

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
        myMonitor.RunMonitor()

        txtResults.Text = "Status: " & myMonitor.Status.ToString
        txtResults.Text &= vbCrLf & "Status Message: " & myMonitor.StatusMessage


		Dim Counter As PolyMon.Status.Counter
        Me.dgvCounters.Rows.Clear()
        If myMonitor.MonitorCounters.Count > 0 Then
            Me.dgvCounters.Visible = True
            For Each Counter In myMonitor.MonitorCounters
                Dim row() As String = {Counter.CounterName, CStr(Counter.CounterValue)}
                Me.dgvCounters.Rows.Add(row)
            Next
        Else
            Me.dgvCounters.Visible = False
        End If

        Me.dgvCounters.AutoResizeColumns()
        Me.dgvCounters.ClearSelection()

        myMonitor = Nothing
    End Sub

    Private Sub SetEditState(ByVal AllowEdits As Boolean)
        tabMonitors.Enabled = AllowEdits
        tsbSave.Enabled = AllowEdits
		tsbCancel.Enabled = AllowEdits
		tsbDeleteData.Enabled = AllowEdits
        tsbDelete.Enabled = AllowEdits
		tsbClone.Enabled = AllowEdits
	End Sub

    Private Overloads Function OperatorExists(ByVal OperatorID As Integer, ByVal OperatorList As ListBox) As Boolean
        Dim PMOperator As PolyMon.Operators.PMOperator
        For Each PMOperator In OperatorList.Items
            If PMOperator.OperatorID = OperatorID Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Overloads Function OperatorExists(ByVal OperatorID As Integer, ByVal OperatorList As PolyMon.Operators.MonitorOperators) As Boolean
        Dim PMOperator As PolyMon.Operators.PMOperator
        For Each PMOperator In OperatorList
            If PMOperator.OperatorID = OperatorID Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function ValidateData() As Boolean

        ValidateData = False

        'Trigger Mod
        With udTriggerMod
			If Not IsNumeric(.Value) OrElse CInt(.Value) < 1 Then
				msgInvalidData("Trigger Mod must be an integer numeric value greater than zero.", Me.udTriggerMod)
				Exit Function
			End If
        End With

        'Name
        With Me.txtName
            If .Text Is Nothing OrElse .Text.Trim.Length = 0 Then
                msgInvalidData("A Monitor Name cannot be blank.", Me.txtName)
                Exit Function
            End If
        End With

        'Monitor Type
        With Me.cboMonitorType
            If .SelectedItem Is Nothing OrElse .Text = Nothing Then
                msgInvalidData("You must select a Monitor Type", Me.cboMonitorType)
                Exit Function
            End If
        End With

        'If Me.XmlEditor1.XMLSettings = Nothing OrElse Me.XmlEditor1.XMLSettings.Trim.Length = 0 Then
        '    msgInvalidData("You must supply an XML string for this monitor definition.", Me.XmlEditor1)
        '    Exit Function
        'End If
        'Check well-formedness

        'Dim XMLDoc As New System.Xml.XmlDocument
        'Try
        '    XMLDoc.LoadXml(XmlEditor1.XMLSettings)
        'Catch ex As Exception
        '    msgInvalidData("XML Settings is not well-formed XML." & vbCrLf & ex.Message, XmlEditor1)
        '    Exit Function
        'End Try


        'Subject Template (Warning Only - and only for new monitors)
        With Me.txtSubjectTemplate
            If Me.mIsNewCurrMonitorDef AndAlso (.Text = Nothing OrElse .Text.Trim.Length = 0) Then
                Dim ret As MsgBoxResult = MsgBox("The Subject template is empty. This will result in email notifications that will not have a subject line. Are you sure you want to do this?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "PolyMon")
                If ret = MsgBoxResult.No Then
                    .Focus()
                    Me.tabMonitors.SelectTab(CType(.Parent, TabPage))
                    Exit Function
                End If
            End If
        End With

        'Body Template (Warning Only - and only for new monitors)
        With Me.txtBodyTemplate
            If Me.mIsNewCurrMonitorDef AndAlso (.Text = Nothing OrElse .Text.Trim.Length = 0) Then
                Dim ret As MsgBoxResult = MsgBox("The Body template is empty. This will result in email notifications that will not have a message body. Are you sure you want to do this?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "PolyMon")
                If ret = MsgBoxResult.No Then
                    .Focus()
                    Me.tabMonitors.SelectTab(CType(.Parent, TabPage))
                    Exit Function
                End If
            End If
        End With

        ValidateData = True
    End Function
    Private Sub msgInvalidData(ByVal Message As String, ByVal EditField As Control)
        MsgBox("Invalid data." & vbCrLf & vbCrLf & Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon")
        Me.tabMonitors.SelectTab(CType(EditField.Parent, TabPage))
        EditField.Focus()
    End Sub

    Private Function XMLEncode(ByVal XMLString As String) As String
        Dim tmpStr As String = XMLString

        tmpStr = tmpStr.Replace("&", "&amp;")
        tmpStr = tmpStr.Replace("<", "&lt;")
        tmpStr = tmpStr.Replace(">", "&gt;")
        tmpStr = tmpStr.Replace("""", "&quot;")
        tmpStr = tmpStr.Replace("'", "&apos;")

        Return tmpStr
    End Function

    Private Sub LoadMonitorEditor(ByVal EditorAssembly As String, ByVal XMLTemplate As String)
        Me.SuspendLayout()
        Dim Ctl As Windows.Forms.Control
        For Each Ctl In pnlEditor.Controls
            pnlEditor.Controls.Remove(Ctl)
        Next
        If Not mEditor Is Nothing Then CType(mEditor, Windows.Forms.Control).Dispose()
        mEditor = Nothing

        If Not EditorAssembly Is Nothing AndAlso EditorAssembly.Trim.Length > 0 Then
            Dim AssemblyPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "Monitors/"

            Dim myEditor As PolyMon.MonitorEditors.GenericMonitorEditor = Nothing

            Dim asm As Reflection.Assembly
            Dim EditorType As Type = Nothing
            Dim ty As Type
            Dim obj As Object
            Dim apppath As String = System.AppDomain.CurrentDomain.BaseDirectory()

            Try
                asm = Reflection.Assembly.LoadFrom(AssemblyPath & EditorAssembly)
                For Each ty In asm.GetExportedTypes
                    If ty.BaseType.FullName = GetType(PolyMon.MonitorEditors.GenericMonitorEditor).FullName Then
                        EditorType = ty
                        Exit For
                    End If
                Next

                If Not (EditorType Is Nothing) Then
                    obj = Activator.CreateInstance(EditorType)
                    myEditor = DirectCast(obj, PolyMon.MonitorEditors.GenericMonitorEditor)
                End If
            Catch ex As Exception
                'Could not find editor, simply default to Generic XML Editor
                MsgBox("Editor assembly could not be loaded." & vbCrLf & "Reverting to generic XML editor." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Editor Configuration Error")
                myEditor = New PolyMon.MonitorEditors.GenericXMLEditor
            End Try

            mEditor = myEditor
            mEditor.XMLTemplate = XMLTemplate
            pnlEditor.Controls.Add(mEditor)
			CType(mEditor, Windows.Forms.Control).Dock = DockStyle.Fill
		Else
			'No Monitor Editor dll was specified - default to XML editor
			Dim myEditor As PolyMon.MonitorEditors.GenericMonitorEditor = Nothing
			myEditor = New PolyMon.MonitorEditors.GenericXMLEditor
			mEditor = myEditor
			mEditor.XMLTemplate = XMLTemplate
			pnlEditor.Controls.Add(mEditor)
			CType(mEditor, Windows.Forms.Control).Dock = DockStyle.Fill
		End If
        Me.ResumeLayout(False)
    End Sub

    Private Function DefaultEmailSubject() As String
        Return "<%Monitor%> - <%Status%>"
    End Function
    Private Function DefaultEmailBody() As String
        Dim sb As New StringBuilder

        sb.Append("====================" & vbCrLf)
        sb.Append("<%Monitor%>" & vbCrLf)
        sb.Append("<%MonitorType%>" & vbCrLf)
        sb.Append("====================" & vbCrLf)
        sb.Append("Status: <%Status%>" & vbCrLf)
        sb.Append("Date: <%EventDT%>" & vbCrLf)
        sb.Append("====================" & vbCrLf)
        sb.Append("<%EventMessage%>" & vbCrLf)
        sb.Append("====================" & vbCrLf)

        Return sb.ToString()
    End Function

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
            If mSortAscending Then
                Return [String].Compare(CType(x, ListViewItem).SubItems(mCol).Text, CType(y, ListViewItem).SubItems(mCol).Text)
            Else
                Return [String].Compare(CType(y, ListViewItem).SubItems(mCol).Text, CType(x, ListViewItem).SubItems(mCol).Text)
            End If
        End Function
    End Class
#End Region


#Region "Delete Monitor Methods"
	Private Sub DeleteMonitor()
		If Me.mIsNewCurrMonitorDef Then
			'This is simply a new (unsaved) monitor, just clear data out
			ClearMonitorData()
		Else
			Dim result As MsgBoxResult = MsgBox("You are about to delete a monitor (" & Me.mCurrMonitorDef.MonitorName & ")." & vbCrLf & "Are you sure?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "PolyMon - Delete Monitor...")
			If result = MsgBoxResult.Yes Then

				'Run Monitor Deletion on a separate thread
				bwDeleteMonitor.RunWorkerAsync(Me.mCurrMonitorDef)

				'Display Deleting Dialog
				mDialogDeleting = New dlgDeleting(String.Format("Deleting Monitor ({0}). Please be patient.", mCurrMonitorDef.MonitorName))
				mDialogDeleting.ShowDialog()
			End If
		End If
	End Sub
	Private Sub bwDeleteMonitor_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDeleteMonitor.DoWork
		Try
			CType(e.Argument, PolyMon.Monitors.MonitorMetadata).Delete()
			e.Result = Nothing
		Catch ex As Exception
			e.Result = ex.Message
		End Try
	End Sub
	Private Sub bwDeleteMonitor_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDeleteMonitor.RunWorkerCompleted
		mDialogDeleting.CloseDialog()
		mDialogDeleting = Nothing

		If e.Result IsNot Nothing Then
			'An error occurred
			MsgBox("An error occurred deleting this monitor." & vbCrLf & e.Result.ToString(), MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		Else
			'Everything ran fine
			ClearMonitorData()
			LoadMonitorList()
		End If
	End Sub
#End Region

#Region "Delete Monitor Data Methods"
	Private Sub DeleteMonitorData()
		Dim result As MsgBoxResult = MsgBox("You are about to delete all data for this monitor (" & Me.mCurrMonitorDef.MonitorName & ")." & vbCrLf & "Are you sure?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "PolyMon - Delete Monitor Data...")
		If result = MsgBoxResult.Yes Then

			'Run Monitor Deletion on a separate thread
			bwDeleteMonitorData.RunWorkerAsync(Me.mCurrMonitorDef)

			'Display Deleting Dialog
			mDialogDeleting = New dlgDeleting(String.Format("Deleting Monitor Data ({0}). Please be patient.", mCurrMonitorDef.MonitorName))
			mDialogDeleting.ShowDialog()
		End If
	End Sub
	Private Sub bwDeleteMonitorData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDeleteMonitorData.DoWork
		Try
			CType(e.Argument, PolyMon.Monitors.MonitorMetadata).DeleteData()
			e.Result = Nothing
		Catch ex As Exception
			e.Result = ex.Message
		End Try
	End Sub
	Private Sub bwDeleteMonitorData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDeleteMonitorData.RunWorkerCompleted
		mDialogDeleting.CloseDialog()
		mDialogDeleting = Nothing

		If e.Result IsNot Nothing Then
			'An error occurred
			MsgBox("An error occurred deleting the monitor data." & vbCrLf & e.Result.ToString(), MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "PolyMon Error")
		End If
	End Sub
#End Region


	Private Sub chkScriptEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScriptEnabled.CheckedChanged
		SetActionScriptState(chkScriptEnabled.Checked)
	End Sub

	Private Sub SetActionScriptState(ByVal IsEnabled As Boolean)
		Me.cboScriptEngine.Enabled = IsEnabled
		Me.rtfScript.Enabled = IsEnabled
		Me.btnLoadDefaultScriptTemplate.Enabled = IsEnabled
	End Sub

End Class