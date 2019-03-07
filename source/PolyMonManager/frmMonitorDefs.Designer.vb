<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitorDefs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonitorDefs))
        Me.pnlMonitors_Right = New System.Windows.Forms.Panel()
        Me.tabMonitors = New System.Windows.Forms.TabControl()
        Me.tabSettings = New System.Windows.Forms.TabPage()
        Me.pnlEditor = New System.Windows.Forms.Panel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.udTriggerMod = New System.Windows.Forms.NumericUpDown()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cboOT2_End_Minutes = New System.Windows.Forms.ComboBox()
        Me.cboOT2_End_Hour = New System.Windows.Forms.ComboBox()
        Me.cboOT2_Start_Minutes = New System.Windows.Forms.ComboBox()
        Me.cboOT2_Start_Hour = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cboOT1_End_Minutes = New System.Windows.Forms.ComboBox()
        Me.cboOT1_End_Hour = New System.Windows.Forms.ComboBox()
        Me.cboOT1_Start_Minutes = New System.Windows.Forms.ComboBox()
        Me.cboOT1_Start_Hour = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.cboMonitorType = New System.Windows.Forms.ComboBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tabTemplates = New System.Windows.Forms.TabPage()
        Me.txtBodyTemplate = New System.Windows.Forms.RichTextBox()
        Me.btnInsertSubjectTemplate = New System.Windows.Forms.Button()
        Me.cboSubjectTemplates = New System.Windows.Forms.ComboBox()
        Me.btnInsertBodyTemplate = New System.Windows.Forms.Button()
        Me.cboBodyTemplates = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtSubjectTemplate = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.tabRules = New System.Windows.Forms.TabPage()
        Me.chkEveryWarnToOK = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.udEveryNWarnings = New System.Windows.Forms.NumericUpDown()
        Me.chkAfterEveryNWarnings = New System.Windows.Forms.CheckBox()
        Me.chkAfterEveryNewWarning = New System.Windows.Forms.CheckBox()
        Me.chkEveryFailToOK = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.udEveryNFailures = New System.Windows.Forms.NumericUpDown()
        Me.chkAfterEveryNFailures = New System.Windows.Forms.CheckBox()
        Me.chkAfterEveryNewFailure = New System.Windows.Forms.CheckBox()
        Me.radAlertAfterOther = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.udEveryNEvents = New System.Windows.Forms.NumericUpDown()
        Me.radEveryNEvents = New System.Windows.Forms.RadioButton()
        Me.tabScripts = New System.Windows.Forms.TabPage()
        Me.btnLoadDefaultScriptTemplate = New System.Windows.Forms.Button()
        Me.cboScriptEngine = New System.Windows.Forms.ComboBox()
        Me.chkScriptEnabled = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.rtfScript = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tabOperators = New System.Windows.Forms.TabPage()
        Me.btnRemoveOperator = New System.Windows.Forms.Button()
        Me.btnAddOperator = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lstMonitorOperators = New System.Windows.Forms.ListBox()
        Me.lstAvailableOperators = New System.Windows.Forms.ListBox()
        Me.tabRetention = New System.Windows.Forms.TabPage()
        Me.lblMonthly = New System.Windows.Forms.Label()
        Me.lblWeekly = New System.Windows.Forms.Label()
        Me.lblDaily = New System.Windows.Forms.Label()
        Me.lblRaw = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.trMonthly = New System.Windows.Forms.TrackBar()
        Me.trWeekly = New System.Windows.Forms.TrackBar()
        Me.trDaily = New System.Windows.Forms.TrackBar()
        Me.trRaw = New System.Windows.Forms.TrackBar()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tabTest = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvCounters = New System.Windows.Forms.DataGridView()
        Me.txtResults = New System.Windows.Forms.TextBox()
        Me.btnRunMonitor = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tsMonitors = New System.Windows.Forms.ToolStrip()
        Me.tsbNewMonitor = New System.Windows.Forms.ToolStripButton()
        Me.tsbClone = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbDeleteData = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.pnlMonitors_Left = New System.Windows.Forms.Panel()
        Me.lstviewMonitors = New System.Windows.Forms.ListView()
        Me.Monitors_ColH_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Monitors_ColH_MonitorType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Monitors_ColH_Enabled = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Monitors_ColH_Mod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Monitors_ColH_MonitorID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.bwDeleteMonitor = New System.ComponentModel.BackgroundWorker()
        Me.bwDeleteMonitorData = New System.ComponentModel.BackgroundWorker()
        Me.pnlMonitors_Right.SuspendLayout()
        Me.tabMonitors.SuspendLayout()
        Me.tabSettings.SuspendLayout()
        CType(Me.udTriggerMod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTemplates.SuspendLayout()
        Me.tabRules.SuspendLayout()
        CType(Me.udEveryNWarnings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udEveryNFailures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udEveryNEvents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabScripts.SuspendLayout()
        Me.tabOperators.SuspendLayout()
        Me.tabRetention.SuspendLayout()
        CType(Me.trMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trWeekly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trDaily, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trRaw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTest.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCounters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMonitors.SuspendLayout()
        Me.pnlMonitors_Left.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMonitors_Right
        '
        Me.pnlMonitors_Right.BackColor = System.Drawing.Color.Transparent
        Me.pnlMonitors_Right.Controls.Add(Me.tabMonitors)
        Me.pnlMonitors_Right.Controls.Add(Me.tsMonitors)
        Me.pnlMonitors_Right.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMonitors_Right.Location = New System.Drawing.Point(260, 0)
        Me.pnlMonitors_Right.Name = "pnlMonitors_Right"
        Me.pnlMonitors_Right.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlMonitors_Right.Size = New System.Drawing.Size(768, 594)
        Me.pnlMonitors_Right.TabIndex = 7
        '
        'tabMonitors
        '
        Me.tabMonitors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMonitors.Controls.Add(Me.tabSettings)
        Me.tabMonitors.Controls.Add(Me.tabTemplates)
        Me.tabMonitors.Controls.Add(Me.tabRules)
        Me.tabMonitors.Controls.Add(Me.tabScripts)
        Me.tabMonitors.Controls.Add(Me.tabOperators)
        Me.tabMonitors.Controls.Add(Me.tabRetention)
        Me.tabMonitors.Controls.Add(Me.tabTest)
        Me.tabMonitors.Location = New System.Drawing.Point(5, 30)
        Me.tabMonitors.Multiline = True
        Me.tabMonitors.Name = "tabMonitors"
        Me.tabMonitors.SelectedIndex = 0
        Me.tabMonitors.Size = New System.Drawing.Size(761, 562)
        Me.tabMonitors.TabIndex = 0
        '
        'tabSettings
        '
        Me.tabSettings.BackColor = System.Drawing.SystemColors.Control
        Me.tabSettings.Controls.Add(Me.pnlEditor)
        Me.tabSettings.Controls.Add(Me.Label31)
        Me.tabSettings.Controls.Add(Me.Label34)
        Me.tabSettings.Controls.Add(Me.Label33)
        Me.tabSettings.Controls.Add(Me.udTriggerMod)
        Me.tabSettings.Controls.Add(Me.Label32)
        Me.tabSettings.Controls.Add(Me.Label30)
        Me.tabSettings.Controls.Add(Me.cboOT2_End_Minutes)
        Me.tabSettings.Controls.Add(Me.cboOT2_End_Hour)
        Me.tabSettings.Controls.Add(Me.cboOT2_Start_Minutes)
        Me.tabSettings.Controls.Add(Me.cboOT2_Start_Hour)
        Me.tabSettings.Controls.Add(Me.Label28)
        Me.tabSettings.Controls.Add(Me.cboOT1_End_Minutes)
        Me.tabSettings.Controls.Add(Me.cboOT1_End_Hour)
        Me.tabSettings.Controls.Add(Me.cboOT1_Start_Minutes)
        Me.tabSettings.Controls.Add(Me.cboOT1_Start_Hour)
        Me.tabSettings.Controls.Add(Me.Label29)
        Me.tabSettings.Controls.Add(Me.chkEnabled)
        Me.tabSettings.Controls.Add(Me.cboMonitorType)
        Me.tabSettings.Controls.Add(Me.txtName)
        Me.tabSettings.Controls.Add(Me.Label27)
        Me.tabSettings.Controls.Add(Me.Label26)
        Me.tabSettings.Controls.Add(Me.Label24)
        Me.tabSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSettings.Size = New System.Drawing.Size(753, 536)
        Me.tabSettings.TabIndex = 0
        Me.tabSettings.Text = "Settings"
        '
        'pnlEditor
        '
        Me.pnlEditor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEditor.Location = New System.Drawing.Point(106, 228)
        Me.pnlEditor.Name = "pnlEditor"
        Me.pnlEditor.Size = New System.Drawing.Size(641, 305)
        Me.pnlEditor.TabIndex = 75
        '
        'Label31
        '
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(12, 185)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(86, 20)
        Me.Label31.TabIndex = 74
        Me.Label31.Text = "Offline Time 2"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(101, 45)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(34, 13)
        Me.Label34.TabIndex = 73
        Me.Label34.Text = "Every"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(206, 45)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(37, 13)
        Me.Label33.TabIndex = 72
        Me.Label33.Text = "cycles"
        '
        'udTriggerMod
        '
        Me.udTriggerMod.Location = New System.Drawing.Point(140, 41)
        Me.udTriggerMod.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.udTriggerMod.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udTriggerMod.Name = "udTriggerMod"
        Me.udTriggerMod.Size = New System.Drawing.Size(64, 20)
        Me.udTriggerMod.TabIndex = 1
        Me.udTriggerMod.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(12, 45)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(64, 13)
        Me.Label32.TabIndex = 70
        Me.Label32.Text = "Trigger Mod"
        '
        'Label30
        '
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(206, 185)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(23, 20)
        Me.Label30.TabIndex = 65
        Me.Label30.Text = "to"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOT2_End_Minutes
        '
        Me.cboOT2_End_Minutes.FormattingEnabled = True
        Me.cboOT2_End_Minutes.Location = New System.Drawing.Point(283, 185)
        Me.cboOT2_End_Minutes.Name = "cboOT2_End_Minutes"
        Me.cboOT2_End_Minutes.Size = New System.Drawing.Size(46, 21)
        Me.cboOT2_End_Minutes.TabIndex = 11
        '
        'cboOT2_End_Hour
        '
        Me.cboOT2_End_Hour.FormattingEnabled = True
        Me.cboOT2_End_Hour.Location = New System.Drawing.Point(231, 185)
        Me.cboOT2_End_Hour.Name = "cboOT2_End_Hour"
        Me.cboOT2_End_Hour.Size = New System.Drawing.Size(46, 21)
        Me.cboOT2_End_Hour.TabIndex = 10
        '
        'cboOT2_Start_Minutes
        '
        Me.cboOT2_Start_Minutes.FormattingEnabled = True
        Me.cboOT2_Start_Minutes.Location = New System.Drawing.Point(154, 185)
        Me.cboOT2_Start_Minutes.Name = "cboOT2_Start_Minutes"
        Me.cboOT2_Start_Minutes.Size = New System.Drawing.Size(46, 21)
        Me.cboOT2_Start_Minutes.TabIndex = 9
        '
        'cboOT2_Start_Hour
        '
        Me.cboOT2_Start_Hour.FormattingEnabled = True
        Me.cboOT2_Start_Hour.Location = New System.Drawing.Point(104, 185)
        Me.cboOT2_Start_Hour.Name = "cboOT2_Start_Hour"
        Me.cboOT2_Start_Hour.Size = New System.Drawing.Size(46, 21)
        Me.cboOT2_Start_Hour.TabIndex = 8
        '
        'Label28
        '
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(206, 150)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(23, 20)
        Me.Label28.TabIndex = 60
        Me.Label28.Text = "to"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOT1_End_Minutes
        '
        Me.cboOT1_End_Minutes.FormattingEnabled = True
        Me.cboOT1_End_Minutes.Location = New System.Drawing.Point(283, 150)
        Me.cboOT1_End_Minutes.Name = "cboOT1_End_Minutes"
        Me.cboOT1_End_Minutes.Size = New System.Drawing.Size(46, 21)
        Me.cboOT1_End_Minutes.TabIndex = 7
        '
        'cboOT1_End_Hour
        '
        Me.cboOT1_End_Hour.FormattingEnabled = True
        Me.cboOT1_End_Hour.Location = New System.Drawing.Point(231, 150)
        Me.cboOT1_End_Hour.Name = "cboOT1_End_Hour"
        Me.cboOT1_End_Hour.Size = New System.Drawing.Size(46, 21)
        Me.cboOT1_End_Hour.TabIndex = 6
        '
        'cboOT1_Start_Minutes
        '
        Me.cboOT1_Start_Minutes.FormattingEnabled = True
        Me.cboOT1_Start_Minutes.Location = New System.Drawing.Point(154, 150)
        Me.cboOT1_Start_Minutes.Name = "cboOT1_Start_Minutes"
        Me.cboOT1_Start_Minutes.Size = New System.Drawing.Size(46, 21)
        Me.cboOT1_Start_Minutes.TabIndex = 5
        '
        'cboOT1_Start_Hour
        '
        Me.cboOT1_Start_Hour.FormattingEnabled = True
        Me.cboOT1_Start_Hour.Location = New System.Drawing.Point(104, 150)
        Me.cboOT1_Start_Hour.Name = "cboOT1_Start_Hour"
        Me.cboOT1_Start_Hour.Size = New System.Drawing.Size(46, 21)
        Me.cboOT1_Start_Hour.TabIndex = 4
        '
        'Label29
        '
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(12, 150)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(93, 20)
        Me.Label29.TabIndex = 59
        Me.Label29.Text = "Offline Time 1"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkEnabled
        '
        Me.chkEnabled.AutoSize = True
        Me.chkEnabled.Location = New System.Drawing.Point(12, 13)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(65, 17)
        Me.chkEnabled.TabIndex = 0
        Me.chkEnabled.Text = "Enabled"
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'cboMonitorType
        '
        Me.cboMonitorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonitorType.FormattingEnabled = True
        Me.cboMonitorType.Location = New System.Drawing.Point(104, 111)
        Me.cboMonitorType.Name = "cboMonitorType"
        Me.cboMonitorType.Size = New System.Drawing.Size(174, 21)
        Me.cboMonitorType.TabIndex = 3
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(103, 76)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(174, 20)
        Me.txtName.TabIndex = 2
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(12, 228)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(45, 13)
        Me.Label27.TabIndex = 54
        Me.Label27.Text = "Settings"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(12, 115)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(31, 13)
        Me.Label26.TabIndex = 53
        Me.Label26.Text = "Type"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(12, 80)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(35, 13)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "Name"
        '
        'tabTemplates
        '
        Me.tabTemplates.BackColor = System.Drawing.SystemColors.Control
        Me.tabTemplates.Controls.Add(Me.txtBodyTemplate)
        Me.tabTemplates.Controls.Add(Me.btnInsertSubjectTemplate)
        Me.tabTemplates.Controls.Add(Me.cboSubjectTemplates)
        Me.tabTemplates.Controls.Add(Me.btnInsertBodyTemplate)
        Me.tabTemplates.Controls.Add(Me.cboBodyTemplates)
        Me.tabTemplates.Controls.Add(Me.Label37)
        Me.tabTemplates.Controls.Add(Me.txtSubjectTemplate)
        Me.tabTemplates.Controls.Add(Me.Label36)
        Me.tabTemplates.Location = New System.Drawing.Point(4, 22)
        Me.tabTemplates.Name = "tabTemplates"
        Me.tabTemplates.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTemplates.Size = New System.Drawing.Size(753, 536)
        Me.tabTemplates.TabIndex = 1
        Me.tabTemplates.Text = "Notification Templates"
        '
        'txtBodyTemplate
        '
        Me.txtBodyTemplate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBodyTemplate.Location = New System.Drawing.Point(70, 116)
        Me.txtBodyTemplate.MaxLength = 3000
        Me.txtBodyTemplate.Name = "txtBodyTemplate"
        Me.txtBodyTemplate.Size = New System.Drawing.Size(663, 414)
        Me.txtBodyTemplate.TabIndex = 5
        Me.txtBodyTemplate.Text = ""
        '
        'btnInsertSubjectTemplate
        '
        Me.btnInsertSubjectTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertSubjectTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInsertSubjectTemplate.Image = Global.PolyMonManager.My.Resources.Resources.FillDownHS
        Me.btnInsertSubjectTemplate.Location = New System.Drawing.Point(707, 21)
        Me.btnInsertSubjectTemplate.Name = "btnInsertSubjectTemplate"
        Me.btnInsertSubjectTemplate.Size = New System.Drawing.Size(26, 21)
        Me.btnInsertSubjectTemplate.TabIndex = 1
        Me.btnInsertSubjectTemplate.UseVisualStyleBackColor = True
        '
        'cboSubjectTemplates
        '
        Me.cboSubjectTemplates.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSubjectTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubjectTemplates.FormattingEnabled = True
        Me.cboSubjectTemplates.Location = New System.Drawing.Point(568, 21)
        Me.cboSubjectTemplates.Name = "cboSubjectTemplates"
        Me.cboSubjectTemplates.Size = New System.Drawing.Size(133, 21)
        Me.cboSubjectTemplates.TabIndex = 0
        '
        'btnInsertBodyTemplate
        '
        Me.btnInsertBodyTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertBodyTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInsertBodyTemplate.Image = Global.PolyMonManager.My.Resources.Resources.FillDownHS
        Me.btnInsertBodyTemplate.Location = New System.Drawing.Point(707, 89)
        Me.btnInsertBodyTemplate.Name = "btnInsertBodyTemplate"
        Me.btnInsertBodyTemplate.Size = New System.Drawing.Size(26, 21)
        Me.btnInsertBodyTemplate.TabIndex = 4
        Me.btnInsertBodyTemplate.UseVisualStyleBackColor = True
        '
        'cboBodyTemplates
        '
        Me.cboBodyTemplates.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboBodyTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBodyTemplates.FormattingEnabled = True
        Me.cboBodyTemplates.Location = New System.Drawing.Point(568, 89)
        Me.cboBodyTemplates.Name = "cboBodyTemplates"
        Me.cboBodyTemplates.Size = New System.Drawing.Size(133, 21)
        Me.cboBodyTemplates.TabIndex = 3
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(15, 113)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(31, 13)
        Me.Label37.TabIndex = 84
        Me.Label37.Text = "Body"
        '
        'txtSubjectTemplate
        '
        Me.txtSubjectTemplate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubjectTemplate.Location = New System.Drawing.Point(68, 48)
        Me.txtSubjectTemplate.MaxLength = 100
        Me.txtSubjectTemplate.Name = "txtSubjectTemplate"
        Me.txtSubjectTemplate.Size = New System.Drawing.Size(665, 20)
        Me.txtSubjectTemplate.TabIndex = 2
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(15, 50)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(43, 13)
        Me.Label36.TabIndex = 82
        Me.Label36.Text = "Subject"
        '
        'tabRules
        '
        Me.tabRules.BackColor = System.Drawing.SystemColors.Control
        Me.tabRules.Controls.Add(Me.chkEveryWarnToOK)
        Me.tabRules.Controls.Add(Me.Label3)
        Me.tabRules.Controls.Add(Me.udEveryNWarnings)
        Me.tabRules.Controls.Add(Me.chkAfterEveryNWarnings)
        Me.tabRules.Controls.Add(Me.chkAfterEveryNewWarning)
        Me.tabRules.Controls.Add(Me.chkEveryFailToOK)
        Me.tabRules.Controls.Add(Me.Label2)
        Me.tabRules.Controls.Add(Me.udEveryNFailures)
        Me.tabRules.Controls.Add(Me.chkAfterEveryNFailures)
        Me.tabRules.Controls.Add(Me.chkAfterEveryNewFailure)
        Me.tabRules.Controls.Add(Me.radAlertAfterOther)
        Me.tabRules.Controls.Add(Me.Label1)
        Me.tabRules.Controls.Add(Me.udEveryNEvents)
        Me.tabRules.Controls.Add(Me.radEveryNEvents)
        Me.tabRules.Location = New System.Drawing.Point(4, 22)
        Me.tabRules.Name = "tabRules"
        Me.tabRules.Size = New System.Drawing.Size(753, 536)
        Me.tabRules.TabIndex = 2
        Me.tabRules.Text = "Notification Rules"
        '
        'chkEveryWarnToOK
        '
        Me.chkEveryWarnToOK.AutoSize = True
        Me.chkEveryWarnToOK.Location = New System.Drawing.Point(68, 255)
        Me.chkEveryWarnToOK.Name = "chkEveryWarnToOK"
        Me.chkEveryWarnToOK.Size = New System.Drawing.Size(126, 17)
        Me.chkEveryWarnToOK.TabIndex = 10
        Me.chkEveryWarnToOK.Text = "Every Warning to OK"
        Me.chkEveryWarnToOK.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(227, 223)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "consecutive Warning(s) thereafter"
        '
        'udEveryNWarnings
        '
        Me.udEveryNWarnings.Location = New System.Drawing.Point(182, 219)
        Me.udEveryNWarnings.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.udEveryNWarnings.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udEveryNWarnings.Name = "udEveryNWarnings"
        Me.udEveryNWarnings.Size = New System.Drawing.Size(42, 20)
        Me.udEveryNWarnings.TabIndex = 9
        Me.udEveryNWarnings.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkAfterEveryNWarnings
        '
        Me.chkAfterEveryNWarnings.AutoSize = True
        Me.chkAfterEveryNWarnings.Location = New System.Drawing.Point(107, 221)
        Me.chkAfterEveryNWarnings.Name = "chkAfterEveryNWarnings"
        Me.chkAfterEveryNWarnings.Size = New System.Drawing.Size(73, 17)
        Me.chkAfterEveryNWarnings.TabIndex = 8
        Me.chkAfterEveryNWarnings.Text = "and every"
        Me.chkAfterEveryNWarnings.UseVisualStyleBackColor = True
        '
        'chkAfterEveryNewWarning
        '
        Me.chkAfterEveryNewWarning.AutoSize = True
        Me.chkAfterEveryNewWarning.Location = New System.Drawing.Point(68, 198)
        Me.chkAfterEveryNewWarning.Name = "chkAfterEveryNewWarning"
        Me.chkAfterEveryNewWarning.Size = New System.Drawing.Size(200, 17)
        Me.chkAfterEveryNewWarning.TabIndex = 7
        Me.chkAfterEveryNewWarning.Text = "Every OK to Warning (New Warning)"
        Me.chkAfterEveryNewWarning.UseVisualStyleBackColor = True
        '
        'chkEveryFailToOK
        '
        Me.chkEveryFailToOK.AutoSize = True
        Me.chkEveryFailToOK.Location = New System.Drawing.Point(68, 135)
        Me.chkEveryFailToOK.Name = "chkEveryFailToOK"
        Me.chkEveryFailToOK.Size = New System.Drawing.Size(117, 17)
        Me.chkEveryFailToOK.TabIndex = 6
        Me.chkEveryFailToOK.Text = "Every Failure to OK"
        Me.chkEveryFailToOK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(227, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "consecutive Failure(s) thereafter"
        '
        'udEveryNFailures
        '
        Me.udEveryNFailures.Location = New System.Drawing.Point(182, 102)
        Me.udEveryNFailures.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.udEveryNFailures.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udEveryNFailures.Name = "udEveryNFailures"
        Me.udEveryNFailures.Size = New System.Drawing.Size(42, 20)
        Me.udEveryNFailures.TabIndex = 5
        Me.udEveryNFailures.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkAfterEveryNFailures
        '
        Me.chkAfterEveryNFailures.AutoSize = True
        Me.chkAfterEveryNFailures.Location = New System.Drawing.Point(107, 104)
        Me.chkAfterEveryNFailures.Name = "chkAfterEveryNFailures"
        Me.chkAfterEveryNFailures.Size = New System.Drawing.Size(73, 17)
        Me.chkAfterEveryNFailures.TabIndex = 4
        Me.chkAfterEveryNFailures.Text = "and every"
        Me.chkAfterEveryNFailures.UseVisualStyleBackColor = True
        '
        'chkAfterEveryNewFailure
        '
        Me.chkAfterEveryNewFailure.AutoSize = True
        Me.chkAfterEveryNewFailure.Location = New System.Drawing.Point(68, 81)
        Me.chkAfterEveryNewFailure.Name = "chkAfterEveryNewFailure"
        Me.chkAfterEveryNewFailure.Size = New System.Drawing.Size(227, 17)
        Me.chkAfterEveryNewFailure.TabIndex = 3
        Me.chkAfterEveryNewFailure.Text = "Every OK/Warning to Failure (New Failure)"
        Me.chkAfterEveryNewFailure.UseVisualStyleBackColor = True
        '
        'radAlertAfterOther
        '
        Me.radAlertAfterOther.AutoSize = True
        Me.radAlertAfterOther.Location = New System.Drawing.Point(27, 58)
        Me.radAlertAfterOther.Name = "radAlertAfterOther"
        Me.radAlertAfterOther.Size = New System.Drawing.Size(70, 17)
        Me.radAlertAfterOther.TabIndex = 2
        Me.radAlertAfterOther.Text = "Alert after"
        Me.radAlertAfterOther.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(184, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Events (OK/Warning/Failure)"
        '
        'udEveryNEvents
        '
        Me.udEveryNEvents.Location = New System.Drawing.Point(134, 17)
        Me.udEveryNEvents.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.udEveryNEvents.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udEveryNEvents.Name = "udEveryNEvents"
        Me.udEveryNEvents.Size = New System.Drawing.Size(42, 20)
        Me.udEveryNEvents.TabIndex = 1
        Me.udEveryNEvents.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'radEveryNEvents
        '
        Me.radEveryNEvents.AutoSize = True
        Me.radEveryNEvents.Checked = True
        Me.radEveryNEvents.Location = New System.Drawing.Point(27, 19)
        Me.radEveryNEvents.Name = "radEveryNEvents"
        Me.radEveryNEvents.Size = New System.Drawing.Size(100, 17)
        Me.radEveryNEvents.TabIndex = 0
        Me.radEveryNEvents.TabStop = True
        Me.radEveryNEvents.Text = "Alert after Every"
        Me.radEveryNEvents.UseVisualStyleBackColor = True
        '
        'tabScripts
        '
        Me.tabScripts.BackColor = System.Drawing.SystemColors.Control
        Me.tabScripts.Controls.Add(Me.btnLoadDefaultScriptTemplate)
        Me.tabScripts.Controls.Add(Me.cboScriptEngine)
        Me.tabScripts.Controls.Add(Me.chkScriptEnabled)
        Me.tabScripts.Controls.Add(Me.Label11)
        Me.tabScripts.Controls.Add(Me.rtfScript)
        Me.tabScripts.Controls.Add(Me.Label9)
        Me.tabScripts.Location = New System.Drawing.Point(4, 22)
        Me.tabScripts.Name = "tabScripts"
        Me.tabScripts.Padding = New System.Windows.Forms.Padding(3)
        Me.tabScripts.Size = New System.Drawing.Size(753, 536)
        Me.tabScripts.TabIndex = 6
        Me.tabScripts.Text = "Action Script"
        '
        'btnLoadDefaultScriptTemplate
        '
        Me.btnLoadDefaultScriptTemplate.Location = New System.Drawing.Point(185, 98)
        Me.btnLoadDefaultScriptTemplate.Name = "btnLoadDefaultScriptTemplate"
        Me.btnLoadDefaultScriptTemplate.Size = New System.Drawing.Size(132, 23)
        Me.btnLoadDefaultScriptTemplate.TabIndex = 21
        Me.btnLoadDefaultScriptTemplate.Text = "Load Default Template"
        Me.btnLoadDefaultScriptTemplate.UseVisualStyleBackColor = True
        '
        'cboScriptEngine
        '
        Me.cboScriptEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScriptEngine.FormattingEnabled = True
        Me.cboScriptEngine.Location = New System.Drawing.Point(20, 100)
        Me.cboScriptEngine.Name = "cboScriptEngine"
        Me.cboScriptEngine.Size = New System.Drawing.Size(159, 21)
        Me.cboScriptEngine.TabIndex = 20
        '
        'chkScriptEnabled
        '
        Me.chkScriptEnabled.AutoSize = True
        Me.chkScriptEnabled.Location = New System.Drawing.Point(20, 76)
        Me.chkScriptEnabled.Name = "chkScriptEnabled"
        Me.chkScriptEnabled.Size = New System.Drawing.Size(59, 17)
        Me.chkScriptEnabled.TabIndex = 19
        Me.chkScriptEnabled.Text = "Enable"
        Me.chkScriptEnabled.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(85, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Trigger: After Completion"
        '
        'rtfScript
        '
        Me.rtfScript.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtfScript.Location = New System.Drawing.Point(20, 127)
        Me.rtfScript.MaxLength = 3000
        Me.rtfScript.Name = "rtfScript"
        Me.rtfScript.Size = New System.Drawing.Size(727, 403)
        Me.rtfScript.TabIndex = 16
        Me.rtfScript.Text = ""
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(17, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(373, 48)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Use this feature to create a custom script to execute after a monitor has been ru" & _
    "n. The script environment provides objects containing the resulting status and c" & _
    "ounter values of the just run monitor."
        '
        'tabOperators
        '
        Me.tabOperators.BackColor = System.Drawing.SystemColors.Control
        Me.tabOperators.Controls.Add(Me.btnRemoveOperator)
        Me.tabOperators.Controls.Add(Me.btnAddOperator)
        Me.tabOperators.Controls.Add(Me.Label8)
        Me.tabOperators.Controls.Add(Me.Label7)
        Me.tabOperators.Controls.Add(Me.lstMonitorOperators)
        Me.tabOperators.Controls.Add(Me.lstAvailableOperators)
        Me.tabOperators.Location = New System.Drawing.Point(4, 22)
        Me.tabOperators.Name = "tabOperators"
        Me.tabOperators.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOperators.Size = New System.Drawing.Size(753, 536)
        Me.tabOperators.TabIndex = 4
        Me.tabOperators.Text = "Operators"
        '
        'btnRemoveOperator
        '
        Me.btnRemoveOperator.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemoveOperator.Image = Global.PolyMonManager.My.Resources.Resources.DataContainer_MovePreviousHS
        Me.btnRemoveOperator.Location = New System.Drawing.Point(264, 153)
        Me.btnRemoveOperator.Name = "btnRemoveOperator"
        Me.btnRemoveOperator.Size = New System.Drawing.Size(25, 25)
        Me.btnRemoveOperator.TabIndex = 5
        Me.btnRemoveOperator.TabStop = False
        Me.btnRemoveOperator.UseVisualStyleBackColor = True
        '
        'btnAddOperator
        '
        Me.btnAddOperator.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddOperator.Image = Global.PolyMonManager.My.Resources.Resources.DataContainer_MoveNextHS
        Me.btnAddOperator.Location = New System.Drawing.Point(264, 113)
        Me.btnAddOperator.Name = "btnAddOperator"
        Me.btnAddOperator.Size = New System.Drawing.Size(25, 25)
        Me.btnAddOperator.TabIndex = 4
        Me.btnAddOperator.TabStop = False
        Me.btnAddOperator.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(318, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Monitor Operators"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Available Operators"
        '
        'lstMonitorOperators
        '
        Me.lstMonitorOperators.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstMonitorOperators.FormattingEnabled = True
        Me.lstMonitorOperators.Location = New System.Drawing.Point(321, 59)
        Me.lstMonitorOperators.Name = "lstMonitorOperators"
        Me.lstMonitorOperators.Size = New System.Drawing.Size(202, 459)
        Me.lstMonitorOperators.Sorted = True
        Me.lstMonitorOperators.TabIndex = 1
        '
        'lstAvailableOperators
        '
        Me.lstAvailableOperators.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstAvailableOperators.FormattingEnabled = True
        Me.lstAvailableOperators.Location = New System.Drawing.Point(38, 59)
        Me.lstAvailableOperators.Name = "lstAvailableOperators"
        Me.lstAvailableOperators.Size = New System.Drawing.Size(202, 459)
        Me.lstAvailableOperators.Sorted = True
        Me.lstAvailableOperators.TabIndex = 0
        '
        'tabRetention
        '
        Me.tabRetention.BackColor = System.Drawing.SystemColors.Control
        Me.tabRetention.Controls.Add(Me.lblMonthly)
        Me.tabRetention.Controls.Add(Me.lblWeekly)
        Me.tabRetention.Controls.Add(Me.lblDaily)
        Me.tabRetention.Controls.Add(Me.lblRaw)
        Me.tabRetention.Controls.Add(Me.Label20)
        Me.tabRetention.Controls.Add(Me.Label19)
        Me.tabRetention.Controls.Add(Me.Label18)
        Me.tabRetention.Controls.Add(Me.Label17)
        Me.tabRetention.Controls.Add(Me.trMonthly)
        Me.tabRetention.Controls.Add(Me.trWeekly)
        Me.tabRetention.Controls.Add(Me.trDaily)
        Me.tabRetention.Controls.Add(Me.trRaw)
        Me.tabRetention.Controls.Add(Me.Label15)
        Me.tabRetention.Location = New System.Drawing.Point(4, 22)
        Me.tabRetention.Name = "tabRetention"
        Me.tabRetention.Size = New System.Drawing.Size(753, 536)
        Me.tabRetention.TabIndex = 5
        Me.tabRetention.Text = "Retention Schedule"
        '
        'lblMonthly
        '
        Me.lblMonthly.AutoSize = True
        Me.lblMonthly.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMonthly.Location = New System.Drawing.Point(400, 255)
        Me.lblMonthly.Name = "lblMonthly"
        Me.lblMonthly.Size = New System.Drawing.Size(63, 13)
        Me.lblMonthly.TabIndex = 38
        Me.lblMonthly.Text = "999 Months"
        '
        'lblWeekly
        '
        Me.lblWeekly.AutoSize = True
        Me.lblWeekly.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblWeekly.Location = New System.Drawing.Point(400, 204)
        Me.lblWeekly.Name = "lblWeekly"
        Me.lblWeekly.Size = New System.Drawing.Size(63, 13)
        Me.lblWeekly.TabIndex = 37
        Me.lblWeekly.Text = "999 Months"
        '
        'lblDaily
        '
        Me.lblDaily.AutoSize = True
        Me.lblDaily.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDaily.Location = New System.Drawing.Point(400, 153)
        Me.lblDaily.Name = "lblDaily"
        Me.lblDaily.Size = New System.Drawing.Size(63, 13)
        Me.lblDaily.TabIndex = 36
        Me.lblDaily.Text = "999 Months"
        '
        'lblRaw
        '
        Me.lblRaw.AutoSize = True
        Me.lblRaw.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRaw.Location = New System.Drawing.Point(400, 102)
        Me.lblRaw.Name = "lblRaw"
        Me.lblRaw.Size = New System.Drawing.Size(63, 13)
        Me.lblRaw.TabIndex = 35
        Me.lblRaw.Text = "999 Months"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.Location = New System.Drawing.Point(52, 255)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 13)
        Me.Label20.TabIndex = 34
        Me.Label20.Text = "Monthly Aggs"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.Location = New System.Drawing.Point(52, 204)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "Weekly Aggs"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.Location = New System.Drawing.Point(52, 153)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 13)
        Me.Label18.TabIndex = 32
        Me.Label18.Text = "Daily Aggs"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.Location = New System.Drawing.Point(52, 102)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 13)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "Raw Data"
        '
        'trMonthly
        '
        Me.trMonthly.AutoSize = False
        Me.trMonthly.BackColor = System.Drawing.SystemColors.Control
        Me.trMonthly.Location = New System.Drawing.Point(126, 245)
        Me.trMonthly.Maximum = 120
        Me.trMonthly.Minimum = 1
        Me.trMonthly.Name = "trMonthly"
        Me.trMonthly.Size = New System.Drawing.Size(268, 33)
        Me.trMonthly.TabIndex = 30
        Me.trMonthly.TickFrequency = 5
        Me.trMonthly.Value = 1
        '
        'trWeekly
        '
        Me.trWeekly.AutoSize = False
        Me.trWeekly.BackColor = System.Drawing.SystemColors.Control
        Me.trWeekly.Location = New System.Drawing.Point(126, 194)
        Me.trWeekly.Maximum = 120
        Me.trWeekly.Minimum = 1
        Me.trWeekly.Name = "trWeekly"
        Me.trWeekly.Size = New System.Drawing.Size(268, 33)
        Me.trWeekly.TabIndex = 29
        Me.trWeekly.TickFrequency = 5
        Me.trWeekly.Value = 1
        '
        'trDaily
        '
        Me.trDaily.AutoSize = False
        Me.trDaily.BackColor = System.Drawing.SystemColors.Control
        Me.trDaily.Location = New System.Drawing.Point(126, 143)
        Me.trDaily.Maximum = 120
        Me.trDaily.Minimum = 1
        Me.trDaily.Name = "trDaily"
        Me.trDaily.Size = New System.Drawing.Size(268, 33)
        Me.trDaily.TabIndex = 28
        Me.trDaily.TabStop = False
        Me.trDaily.TickFrequency = 5
        Me.trDaily.Value = 1
        '
        'trRaw
        '
        Me.trRaw.AutoSize = False
        Me.trRaw.BackColor = System.Drawing.SystemColors.Control
        Me.trRaw.Location = New System.Drawing.Point(126, 92)
        Me.trRaw.Maximum = 120
        Me.trRaw.Minimum = 1
        Me.trRaw.Name = "trRaw"
        Me.trRaw.Size = New System.Drawing.Size(268, 33)
        Me.trRaw.TabIndex = 27
        Me.trRaw.TabStop = False
        Me.trRaw.TickFrequency = 5
        Me.trRaw.Value = 1
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(17, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(364, 59)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = resources.GetString("Label15.Text")
        '
        'tabTest
        '
        Me.tabTest.BackColor = System.Drawing.SystemColors.Control
        Me.tabTest.Controls.Add(Me.Label5)
        Me.tabTest.Controls.Add(Me.GroupBox1)
        Me.tabTest.Controls.Add(Me.btnRunMonitor)
        Me.tabTest.Controls.Add(Me.Label4)
        Me.tabTest.Location = New System.Drawing.Point(4, 22)
        Me.tabTest.Name = "tabTest"
        Me.tabTest.Size = New System.Drawing.Size(753, 536)
        Me.tabTest.TabIndex = 3
        Me.tabTest.Text = "Test"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(18, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(456, 55)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "The Monitor assemblies (e.g. PingMonitor.dll, etc) MUST exist in a local director" & _
    "y (called Monitors) in the root path of this Management application."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dgvCounters)
        Me.GroupBox1.Controls.Add(Me.txtResults)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 184)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Size = New System.Drawing.Size(570, 335)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Results"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Counters"
        '
        'dgvCounters
        '
        Me.dgvCounters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCounters.Location = New System.Drawing.Point(9, 202)
        Me.dgvCounters.Name = "dgvCounters"
        Me.dgvCounters.Size = New System.Drawing.Size(551, 124)
        Me.dgvCounters.TabIndex = 1
        Me.dgvCounters.TabStop = False
        '
        'txtResults
        '
        Me.txtResults.Location = New System.Drawing.Point(9, 19)
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.ReadOnly = True
        Me.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResults.Size = New System.Drawing.Size(552, 144)
        Me.txtResults.TabIndex = 0
        Me.txtResults.TabStop = False
        '
        'btnRunMonitor
        '
        Me.btnRunMonitor.Location = New System.Drawing.Point(32, 143)
        Me.btnRunMonitor.Name = "btnRunMonitor"
        Me.btnRunMonitor.Size = New System.Drawing.Size(89, 35)
        Me.btnRunMonitor.TabIndex = 0
        Me.btnRunMonitor.Text = "Test Monitor"
        Me.btnRunMonitor.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(18, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(456, 55)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "The following runs the Monitor as currently saved in the database. To ensure a pr" & _
    "oper test, please save any changes first. Also note that this test does not log " & _
    "to the database or generate alerts."
        '
        'tsMonitors
        '
        Me.tsMonitors.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMonitors.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNewMonitor, Me.tsbClone, Me.tsbSave, Me.ToolStripSeparator7, Me.tsbCancel, Me.ToolStripSeparator8, Me.tsbDeleteData, Me.tsbDelete})
        Me.tsMonitors.Location = New System.Drawing.Point(2, 2)
        Me.tsMonitors.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.tsMonitors.Name = "tsMonitors"
        Me.tsMonitors.Size = New System.Drawing.Size(764, 25)
        Me.tsMonitors.TabIndex = 4
        Me.tsMonitors.Text = "ToolStrip1"
        '
        'tsbNewMonitor
        '
        Me.tsbNewMonitor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNewMonitor.Image = Global.PolyMonManager.My.Resources.Resources.AddTableHS
        Me.tsbNewMonitor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNewMonitor.Name = "tsbNewMonitor"
        Me.tsbNewMonitor.Size = New System.Drawing.Size(23, 22)
        Me.tsbNewMonitor.Text = "New Monitor"
        Me.tsbNewMonitor.ToolTipText = "Create New Monitor Instance"
        '
        'tsbClone
        '
        Me.tsbClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbClone.Image = CType(resources.GetObject("tsbClone.Image"), System.Drawing.Image)
        Me.tsbClone.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClone.Name = "tsbClone"
        Me.tsbClone.Size = New System.Drawing.Size(23, 22)
        Me.tsbClone.Text = "Clone"
        Me.tsbClone.ToolTipText = "Clone Selected Monitor"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSave.Image = Global.PolyMonManager.My.Resources.Resources.saveHS
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(23, 22)
        Me.tsbSave.Text = "Save"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tsbCancel
        '
        Me.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCancel.Image = Global.PolyMonManager.My.Resources.Resources.Edit_UndoHS
        Me.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancel.Name = "tsbCancel"
        Me.tsbCancel.Size = New System.Drawing.Size(23, 22)
        Me.tsbCancel.Text = "Cancel"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'tsbDeleteData
        '
        Me.tsbDeleteData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDeleteData.Image = CType(resources.GetObject("tsbDeleteData.Image"), System.Drawing.Image)
        Me.tsbDeleteData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeleteData.Name = "tsbDeleteData"
        Me.tsbDeleteData.Size = New System.Drawing.Size(23, 22)
        Me.tsbDeleteData.Text = "Delete Data"
        Me.tsbDeleteData.ToolTipText = "Delete Monitor Data"
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDelete.Image = Global.PolyMonManager.My.Resources.Resources.DeleteHS
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(23, 22)
        Me.tsbDelete.Text = "Delete Monitor"
        Me.tsbDelete.ToolTipText = "Delete Monitor (and all data)"
        '
        'pnlMonitors_Left
        '
        Me.pnlMonitors_Left.BackColor = System.Drawing.SystemColors.Control
        Me.pnlMonitors_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMonitors_Left.Controls.Add(Me.lstviewMonitors)
        Me.pnlMonitors_Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMonitors_Left.Location = New System.Drawing.Point(0, 0)
        Me.pnlMonitors_Left.Name = "pnlMonitors_Left"
        Me.pnlMonitors_Left.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlMonitors_Left.Size = New System.Drawing.Size(260, 594)
        Me.pnlMonitors_Left.TabIndex = 9
        '
        'lstviewMonitors
        '
        Me.lstviewMonitors.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstviewMonitors.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Monitors_ColH_Name, Me.Monitors_ColH_MonitorType, Me.Monitors_ColH_Enabled, Me.Monitors_ColH_Mod, Me.Monitors_ColH_MonitorID})
        Me.lstviewMonitors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstviewMonitors.FullRowSelect = True
        Me.lstviewMonitors.HideSelection = False
        Me.lstviewMonitors.Location = New System.Drawing.Point(2, 2)
        Me.lstviewMonitors.MultiSelect = False
        Me.lstviewMonitors.Name = "lstviewMonitors"
        Me.lstviewMonitors.Size = New System.Drawing.Size(254, 588)
        Me.lstviewMonitors.TabIndex = 0
        Me.lstviewMonitors.UseCompatibleStateImageBehavior = False
        Me.lstviewMonitors.View = System.Windows.Forms.View.Details
        '
        'Monitors_ColH_Name
        '
        Me.Monitors_ColH_Name.Text = "Monitor"
        Me.Monitors_ColH_Name.Width = 120
        '
        'Monitors_ColH_MonitorType
        '
        Me.Monitors_ColH_MonitorType.Text = "Type"
        Me.Monitors_ColH_MonitorType.Width = 120
        '
        'Monitors_ColH_Enabled
        '
        Me.Monitors_ColH_Enabled.Text = "Enabled"
        '
        'Monitors_ColH_Mod
        '
        Me.Monitors_ColH_Mod.Text = "Trigger Mod"
        '
        'Monitors_ColH_MonitorID
        '
        Me.Monitors_ColH_MonitorID.Text = "ID"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "polymon.chm"
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Splitter1.Location = New System.Drawing.Point(260, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 594)
        Me.Splitter1.TabIndex = 10
        Me.Splitter1.TabStop = False
        '
        'bwDeleteMonitor
        '
        '
        'bwDeleteMonitorData
        '
        '
        'frmMonitorDefs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1028, 594)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.pnlMonitors_Right)
        Me.Controls.Add(Me.pnlMonitors_Left)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "15")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMonitorDefs"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Monitors"
        Me.pnlMonitors_Right.ResumeLayout(False)
        Me.pnlMonitors_Right.PerformLayout()
        Me.tabMonitors.ResumeLayout(False)
        Me.tabSettings.ResumeLayout(False)
        Me.tabSettings.PerformLayout()
        CType(Me.udTriggerMod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTemplates.ResumeLayout(False)
        Me.tabTemplates.PerformLayout()
        Me.tabRules.ResumeLayout(False)
        Me.tabRules.PerformLayout()
        CType(Me.udEveryNWarnings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udEveryNFailures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udEveryNEvents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabScripts.ResumeLayout(False)
        Me.tabScripts.PerformLayout()
        Me.tabOperators.ResumeLayout(False)
        Me.tabOperators.PerformLayout()
        Me.tabRetention.ResumeLayout(False)
        Me.tabRetention.PerformLayout()
        CType(Me.trMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trWeekly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trDaily, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trRaw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTest.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCounters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMonitors.ResumeLayout(False)
        Me.tsMonitors.PerformLayout()
        Me.pnlMonitors_Left.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
	Friend WithEvents pnlMonitors_Right As System.Windows.Forms.Panel
	Friend WithEvents tabMonitors As System.Windows.Forms.TabControl
	Friend WithEvents tabTemplates As System.Windows.Forms.TabPage
	Friend WithEvents btnInsertSubjectTemplate As System.Windows.Forms.Button
	Friend WithEvents cboSubjectTemplates As System.Windows.Forms.ComboBox
	Friend WithEvents btnInsertBodyTemplate As System.Windows.Forms.Button
	Friend WithEvents cboBodyTemplates As System.Windows.Forms.ComboBox
	Friend WithEvents Label37 As System.Windows.Forms.Label
	Friend WithEvents txtSubjectTemplate As System.Windows.Forms.TextBox
	Friend WithEvents Label36 As System.Windows.Forms.Label
	Friend WithEvents tabRules As System.Windows.Forms.TabPage
	Friend WithEvents tabTest As System.Windows.Forms.TabPage
	Friend WithEvents tsMonitors As System.Windows.Forms.ToolStrip
	Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
	Friend WithEvents tsbCancel As System.Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents tsbNewMonitor As System.Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
	Friend WithEvents tabSettings As System.Windows.Forms.TabPage
	Friend WithEvents Label31 As System.Windows.Forms.Label
	Friend WithEvents Label34 As System.Windows.Forms.Label
	Friend WithEvents Label33 As System.Windows.Forms.Label
	Friend WithEvents udTriggerMod As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label32 As System.Windows.Forms.Label
	Friend WithEvents Label30 As System.Windows.Forms.Label
	Friend WithEvents cboOT2_End_Minutes As System.Windows.Forms.ComboBox
	Friend WithEvents cboOT2_End_Hour As System.Windows.Forms.ComboBox
	Friend WithEvents cboOT2_Start_Minutes As System.Windows.Forms.ComboBox
	Friend WithEvents cboOT2_Start_Hour As System.Windows.Forms.ComboBox
	Friend WithEvents Label28 As System.Windows.Forms.Label
	Friend WithEvents cboOT1_End_Minutes As System.Windows.Forms.ComboBox
	Friend WithEvents cboOT1_End_Hour As System.Windows.Forms.ComboBox
	Friend WithEvents cboOT1_Start_Minutes As System.Windows.Forms.ComboBox
	Friend WithEvents cboOT1_Start_Hour As System.Windows.Forms.ComboBox
	Friend WithEvents Label29 As System.Windows.Forms.Label
	Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
	Friend WithEvents cboMonitorType As System.Windows.Forms.ComboBox
	Friend WithEvents txtName As System.Windows.Forms.TextBox
	Friend WithEvents Label27 As System.Windows.Forms.Label
	Friend WithEvents Label26 As System.Windows.Forms.Label
	Friend WithEvents Label24 As System.Windows.Forms.Label
	Friend WithEvents pnlMonitors_Left As System.Windows.Forms.Panel
	Friend WithEvents lstviewMonitors As System.Windows.Forms.ListView
	Friend WithEvents Monitors_ColH_Name As System.Windows.Forms.ColumnHeader
	Friend WithEvents Monitors_ColH_MonitorType As System.Windows.Forms.ColumnHeader
	Friend WithEvents Monitors_ColH_Enabled As System.Windows.Forms.ColumnHeader
	Friend WithEvents Monitors_ColH_Mod As System.Windows.Forms.ColumnHeader
	Friend WithEvents Monitors_ColH_MonitorID As System.Windows.Forms.ColumnHeader
	Friend WithEvents radAlertAfterOther As System.Windows.Forms.RadioButton
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents udEveryNEvents As System.Windows.Forms.NumericUpDown
	Friend WithEvents radEveryNEvents As System.Windows.Forms.RadioButton
	Friend WithEvents chkAfterEveryNewFailure As System.Windows.Forms.CheckBox
	Friend WithEvents chkAfterEveryNFailures As System.Windows.Forms.CheckBox
	Friend WithEvents chkEveryWarnToOK As System.Windows.Forms.CheckBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents udEveryNWarnings As System.Windows.Forms.NumericUpDown
	Friend WithEvents chkAfterEveryNWarnings As System.Windows.Forms.CheckBox
	Friend WithEvents chkAfterEveryNewWarning As System.Windows.Forms.CheckBox
	Friend WithEvents chkEveryFailToOK As System.Windows.Forms.CheckBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents udEveryNFailures As System.Windows.Forms.NumericUpDown
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents txtResults As System.Windows.Forms.TextBox
	Friend WithEvents btnRunMonitor As System.Windows.Forms.Button
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents dgvCounters As System.Windows.Forms.DataGridView
	Friend WithEvents tabOperators As System.Windows.Forms.TabPage
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents lstMonitorOperators As System.Windows.Forms.ListBox
	Friend WithEvents lstAvailableOperators As System.Windows.Forms.ListBox
	Friend WithEvents btnRemoveOperator As System.Windows.Forms.Button
	Friend WithEvents btnAddOperator As System.Windows.Forms.Button
	Friend WithEvents txtBodyTemplate As System.Windows.Forms.RichTextBox
	Friend WithEvents tsbClone As System.Windows.Forms.ToolStripButton
	Friend WithEvents pnlEditor As System.Windows.Forms.Panel
	Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
	Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
	Friend WithEvents tabRetention As System.Windows.Forms.TabPage
	Friend WithEvents Label15 As System.Windows.Forms.Label
	Friend WithEvents lblMonthly As System.Windows.Forms.Label
	Friend WithEvents lblWeekly As System.Windows.Forms.Label
	Friend WithEvents lblDaily As System.Windows.Forms.Label
	Friend WithEvents lblRaw As System.Windows.Forms.Label
	Friend WithEvents Label20 As System.Windows.Forms.Label
	Friend WithEvents Label19 As System.Windows.Forms.Label
	Friend WithEvents Label18 As System.Windows.Forms.Label
	Friend WithEvents Label17 As System.Windows.Forms.Label
	Friend WithEvents trMonthly As System.Windows.Forms.TrackBar
	Friend WithEvents trWeekly As System.Windows.Forms.TrackBar
	Friend WithEvents trDaily As System.Windows.Forms.TrackBar
	Friend WithEvents trRaw As System.Windows.Forms.TrackBar
	Friend WithEvents tsbDeleteData As System.Windows.Forms.ToolStripButton
	Friend WithEvents bwDeleteMonitor As System.ComponentModel.BackgroundWorker
	Friend WithEvents bwDeleteMonitorData As System.ComponentModel.BackgroundWorker
	Friend WithEvents tabScripts As System.Windows.Forms.TabPage
	Friend WithEvents Label11 As System.Windows.Forms.Label
	Friend WithEvents rtfScript As System.Windows.Forms.RichTextBox
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents chkScriptEnabled As System.Windows.Forms.CheckBox
	Friend WithEvents btnLoadDefaultScriptTemplate As System.Windows.Forms.Button
	Friend WithEvents cboScriptEngine As System.Windows.Forms.ComboBox
End Class
