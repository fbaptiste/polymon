<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneralSettings
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneralSettings))
        Me.tsGeneralSettingsEditor = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.udSysMainTimerInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSysServiceServer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnSendTestMail = New System.Windows.Forms.Button()
        Me.chkSysSMTPUseSSL = New System.Windows.Forms.CheckBox()
        Me.upSysSMTPPort = New System.Windows.Forms.NumericUpDown()
        Me.txtSysSMTPFromAddress = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSysSMTPFromName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSysSMTPPwd = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSysSMTPUserID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSysSMTPServer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkSysEnabled = New System.Windows.Forms.CheckBox()
        Me.txtSysName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboMDIBackColor = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkBalloonAlerts = New System.Windows.Forms.CheckBox()
        Me.cboTimerIntervals = New System.Windows.Forms.ComboBox()
        Me.chkAudioAlert = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpSysSettings = New System.Windows.Forms.TabPage()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tpRetentionScheme = New System.Windows.Forms.TabPage()
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbSaveRetentionScheme = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelRetentionScheme = New System.Windows.Forms.ToolStripButton()
        Me.tpUserSettings = New System.Windows.Forms.TabPage()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.imglstStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.tsGeneralSettingsEditor.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.udSysMainTimerInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.upSysSMTPPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpSysSettings.SuspendLayout()
        Me.tpRetentionScheme.SuspendLayout()
        CType(Me.trMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trWeekly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trDaily, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trRaw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.tpUserSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsGeneralSettingsEditor
        '
        Me.tsGeneralSettingsEditor.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsGeneralSettingsEditor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbCancel})
        Me.tsGeneralSettingsEditor.Location = New System.Drawing.Point(3, 3)
        Me.tsGeneralSettingsEditor.Name = "tsGeneralSettingsEditor"
        Me.tsGeneralSettingsEditor.Size = New System.Drawing.Size(387, 25)
        Me.tsGeneralSettingsEditor.TabIndex = 4
        Me.tsGeneralSettingsEditor.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSave.Image = Global.PolyMonManager.My.Resources.Resources.saveHS
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(23, 22)
        Me.tsbSave.Text = "Save"
        Me.tsbSave.ToolTipText = "Save General Settings"
        '
        'tsbCancel
        '
        Me.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCancel.Image = Global.PolyMonManager.My.Resources.Resources.Edit_UndoHS
        Me.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancel.Name = "tsbCancel"
        Me.tsbCancel.Size = New System.Drawing.Size(23, 22)
        Me.tsbCancel.Text = "Cancel"
        Me.tsbCancel.ToolTipText = "Cancel all changes"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.udSysMainTimerInterval)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtSysServiceServer)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.ForeColor = System.Drawing.Color.MediumBlue
        Me.GroupBox2.Location = New System.Drawing.Point(6, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(376, 88)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Polymon Executive"
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(224, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 20)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "seconds"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'udSysMainTimerInterval
        '
        Me.udSysMainTimerInterval.Location = New System.Drawing.Point(148, 56)
        Me.udSysMainTimerInterval.Maximum = New Decimal(New Integer() {86400, 0, 0, 0})
        Me.udSysMainTimerInterval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udSysMainTimerInterval.Name = "udSysMainTimerInterval"
        Me.udSysMainTimerInterval.Size = New System.Drawing.Size(72, 20)
        Me.udSysMainTimerInterval.TabIndex = 2
        Me.udSysMainTimerInterval.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(12, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Main Timer Interval"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSysServiceServer
        '
        Me.txtSysServiceServer.Location = New System.Drawing.Point(148, 24)
        Me.txtSysServiceServer.MaxLength = 255
        Me.txtSysServiceServer.Name = "txtSysServiceServer"
        Me.txtSysServiceServer.Size = New System.Drawing.Size(204, 20)
        Me.txtSysServiceServer.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(12, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Service Server"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btnSendTestMail)
        Me.GroupBox1.Controls.Add(Me.chkSysSMTPUseSSL)
        Me.GroupBox1.Controls.Add(Me.upSysSMTPPort)
        Me.GroupBox1.Controls.Add(Me.txtSysSMTPFromAddress)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtSysSMTPFromName)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtSysSMTPPwd)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtSysSMTPUserID)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtSysSMTPServer)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.ForeColor = System.Drawing.Color.MediumBlue
        Me.GroupBox1.Location = New System.Drawing.Point(6, 191)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 266)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SMTP"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(55, 241)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(201, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Please save settings before testing email."
        '
        'btnSendTestMail
        '
        Me.btnSendTestMail.Location = New System.Drawing.Point(260, 236)
        Me.btnSendTestMail.Name = "btnSendTestMail"
        Me.btnSendTestMail.Size = New System.Drawing.Size(96, 23)
        Me.btnSendTestMail.TabIndex = 19
        Me.btnSendTestMail.Text = "Send Test Email"
        Me.btnSendTestMail.UseVisualStyleBackColor = True
        '
        'chkSysSMTPUseSSL
        '
        Me.chkSysSMTPUseSSL.AutoSize = True
        Me.chkSysSMTPUseSSL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkSysSMTPUseSSL.Location = New System.Drawing.Point(152, 215)
        Me.chkSysSMTPUseSSL.Name = "chkSysSMTPUseSSL"
        Me.chkSysSMTPUseSSL.Size = New System.Drawing.Size(68, 17)
        Me.chkSysSMTPUseSSL.TabIndex = 18
        Me.chkSysSMTPUseSSL.Text = "Use SSL"
        Me.chkSysSMTPUseSSL.UseVisualStyleBackColor = True
        '
        'upSysSMTPPort
        '
        Me.upSysSMTPPort.Location = New System.Drawing.Point(152, 60)
        Me.upSysSMTPPort.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
        Me.upSysSMTPPort.Name = "upSysSMTPPort"
        Me.upSysSMTPPort.Size = New System.Drawing.Size(68, 20)
        Me.upSysSMTPPort.TabIndex = 2
        '
        'txtSysSMTPFromAddress
        '
        Me.txtSysSMTPFromAddress.Location = New System.Drawing.Point(152, 188)
        Me.txtSysSMTPFromAddress.MaxLength = 255
        Me.txtSysSMTPFromAddress.Name = "txtSysSMTPFromAddress"
        Me.txtSysSMTPFromAddress.Size = New System.Drawing.Size(204, 20)
        Me.txtSysSMTPFromAddress.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(16, 188)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 20)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "SMTP (From) Email"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSysSMTPFromName
        '
        Me.txtSysSMTPFromName.Location = New System.Drawing.Point(152, 156)
        Me.txtSysSMTPFromName.MaxLength = 50
        Me.txtSysSMTPFromName.Name = "txtSysSMTPFromName"
        Me.txtSysSMTPFromName.Size = New System.Drawing.Size(204, 20)
        Me.txtSysSMTPFromName.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 156)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 20)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "SMTP (From) Name"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSysSMTPPwd
        '
        Me.txtSysSMTPPwd.Location = New System.Drawing.Point(152, 124)
        Me.txtSysSMTPPwd.MaxLength = 50
        Me.txtSysSMTPPwd.Name = "txtSysSMTPPwd"
        Me.txtSysSMTPPwd.Size = New System.Drawing.Size(204, 20)
        Me.txtSysSMTPPwd.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "SMTP Password"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSysSMTPUserID
        '
        Me.txtSysSMTPUserID.Location = New System.Drawing.Point(152, 92)
        Me.txtSysSMTPUserID.MaxLength = 50
        Me.txtSysSMTPUserID.Name = "txtSysSMTPUserID"
        Me.txtSysSMTPUserID.Size = New System.Drawing.Size(204, 20)
        Me.txtSysSMTPUserID.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "SMTP User ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 20)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "SMTP Port"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSysSMTPServer
        '
        Me.txtSysSMTPServer.Location = New System.Drawing.Point(152, 28)
        Me.txtSysSMTPServer.MaxLength = 255
        Me.txtSysSMTPServer.Name = "txtSysSMTPServer"
        Me.txtSysSMTPServer.Size = New System.Drawing.Size(204, 20)
        Me.txtSysSMTPServer.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "SMTP Server"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkSysEnabled
        '
        Me.chkSysEnabled.Location = New System.Drawing.Point(6, 37)
        Me.chkSysEnabled.Name = "chkSysEnabled"
        Me.chkSysEnabled.Size = New System.Drawing.Size(104, 23)
        Me.chkSysEnabled.TabIndex = 7
        Me.chkSysEnabled.Text = "System Enabled"
        '
        'txtSysName
        '
        Me.txtSysName.Enabled = False
        Me.txtSysName.Location = New System.Drawing.Point(142, 67)
        Me.txtSysName.MaxLength = 50
        Me.txtSysName.Name = "txtSysName"
        Me.txtSysName.Size = New System.Drawing.Size(148, 20)
        Me.txtSysName.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "PolyMon Instance Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboMDIBackColor)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.chkBalloonAlerts)
        Me.GroupBox3.Controls.Add(Me.cboTimerIntervals)
        Me.GroupBox3.Controls.Add(Me.chkAudioAlert)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.ForeColor = System.Drawing.Color.MediumBlue
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(376, 142)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Polymon Manager"
        '
        'cboMDIBackColor
        '
        Me.cboMDIBackColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMDIBackColor.FormattingEnabled = True
        Me.cboMDIBackColor.Location = New System.Drawing.Point(153, 113)
        Me.cboMDIBackColor.Name = "cboMDIBackColor"
        Me.cboMDIBackColor.Size = New System.Drawing.Size(167, 21)
        Me.cboMDIBackColor.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(16, 113)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(151, 20)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Main Background Color"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkBalloonAlerts
        '
        Me.chkBalloonAlerts.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBalloonAlerts.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBalloonAlerts.Location = New System.Drawing.Point(15, 82)
        Me.chkBalloonAlerts.Name = "chkBalloonAlerts"
        Me.chkBalloonAlerts.Size = New System.Drawing.Size(152, 25)
        Me.chkBalloonAlerts.TabIndex = 10
        Me.chkBalloonAlerts.Text = "Balloon Alerts"
        '
        'cboTimerIntervals
        '
        Me.cboTimerIntervals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTimerIntervals.FormattingEnabled = True
        Me.cboTimerIntervals.Location = New System.Drawing.Point(153, 24)
        Me.cboTimerIntervals.Name = "cboTimerIntervals"
        Me.cboTimerIntervals.Size = New System.Drawing.Size(168, 21)
        Me.cboTimerIntervals.TabIndex = 9
        '
        'chkAudioAlert
        '
        Me.chkAudioAlert.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAudioAlert.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAudioAlert.Location = New System.Drawing.Point(15, 55)
        Me.chkAudioAlert.Name = "chkAudioAlert"
        Me.chkAudioAlert.Size = New System.Drawing.Size(152, 25)
        Me.chkAudioAlert.TabIndex = 8
        Me.chkAudioAlert.Text = "Audio Alert"
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(12, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 20)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Status Refresh Interval"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(108, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(275, 23)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "(if unchecked, PolyMon executive will not be able to start)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpSysSettings)
        Me.TabControl1.Controls.Add(Me.tpRetentionScheme)
        Me.TabControl1.Controls.Add(Me.tpUserSettings)
        Me.TabControl1.Location = New System.Drawing.Point(5, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(401, 523)
        Me.TabControl1.TabIndex = 13
        '
        'tpSysSettings
        '
        Me.tpSysSettings.BackColor = System.Drawing.SystemColors.Control
        Me.tpSysSettings.Controls.Add(Me.Label21)
        Me.tpSysSettings.Controls.Add(Me.Label2)
        Me.tpSysSettings.Controls.Add(Me.GroupBox2)
        Me.tpSysSettings.Controls.Add(Me.tsGeneralSettingsEditor)
        Me.tpSysSettings.Controls.Add(Me.chkSysEnabled)
        Me.tpSysSettings.Controls.Add(Me.GroupBox1)
        Me.tpSysSettings.Controls.Add(Me.txtSysName)
        Me.tpSysSettings.Controls.Add(Me.Label1)
        Me.tpSysSettings.Location = New System.Drawing.Point(4, 22)
        Me.tpSysSettings.Name = "tpSysSettings"
        Me.tpSysSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSysSettings.Size = New System.Drawing.Size(393, 497)
        Me.tpSysSettings.TabIndex = 0
        Me.tpSysSettings.Text = "System Settings"
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(9, 464)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(373, 30)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "* Note that any changes made here will require a Stop/Start of PolyMon Executive " & _
    "of the service in order to take effect."
        '
        'tpRetentionScheme
        '
        Me.tpRetentionScheme.BackColor = System.Drawing.SystemColors.Control
        Me.tpRetentionScheme.Controls.Add(Me.lblMonthly)
        Me.tpRetentionScheme.Controls.Add(Me.lblWeekly)
        Me.tpRetentionScheme.Controls.Add(Me.lblDaily)
        Me.tpRetentionScheme.Controls.Add(Me.lblRaw)
        Me.tpRetentionScheme.Controls.Add(Me.Label20)
        Me.tpRetentionScheme.Controls.Add(Me.Label19)
        Me.tpRetentionScheme.Controls.Add(Me.Label18)
        Me.tpRetentionScheme.Controls.Add(Me.Label17)
        Me.tpRetentionScheme.Controls.Add(Me.trMonthly)
        Me.tpRetentionScheme.Controls.Add(Me.trWeekly)
        Me.tpRetentionScheme.Controls.Add(Me.trDaily)
        Me.tpRetentionScheme.Controls.Add(Me.trRaw)
        Me.tpRetentionScheme.Controls.Add(Me.Label16)
        Me.tpRetentionScheme.Controls.Add(Me.Label15)
        Me.tpRetentionScheme.Controls.Add(Me.ToolStrip1)
        Me.tpRetentionScheme.Location = New System.Drawing.Point(4, 22)
        Me.tpRetentionScheme.Name = "tpRetentionScheme"
        Me.tpRetentionScheme.Size = New System.Drawing.Size(393, 497)
        Me.tpRetentionScheme.TabIndex = 2
        Me.tpRetentionScheme.Text = "Retention Scheme"
        '
        'lblMonthly
        '
        Me.lblMonthly.AutoSize = True
        Me.lblMonthly.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMonthly.Location = New System.Drawing.Point(319, 336)
        Me.lblMonthly.Name = "lblMonthly"
        Me.lblMonthly.Size = New System.Drawing.Size(63, 13)
        Me.lblMonthly.TabIndex = 26
        Me.lblMonthly.Text = "999 Months"
        '
        'lblWeekly
        '
        Me.lblWeekly.AutoSize = True
        Me.lblWeekly.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblWeekly.Location = New System.Drawing.Point(319, 285)
        Me.lblWeekly.Name = "lblWeekly"
        Me.lblWeekly.Size = New System.Drawing.Size(63, 13)
        Me.lblWeekly.TabIndex = 25
        Me.lblWeekly.Text = "999 Months"
        '
        'lblDaily
        '
        Me.lblDaily.AutoSize = True
        Me.lblDaily.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDaily.Location = New System.Drawing.Point(319, 234)
        Me.lblDaily.Name = "lblDaily"
        Me.lblDaily.Size = New System.Drawing.Size(63, 13)
        Me.lblDaily.TabIndex = 24
        Me.lblDaily.Text = "999 Months"
        '
        'lblRaw
        '
        Me.lblRaw.AutoSize = True
        Me.lblRaw.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRaw.Location = New System.Drawing.Point(319, 183)
        Me.lblRaw.Name = "lblRaw"
        Me.lblRaw.Size = New System.Drawing.Size(63, 13)
        Me.lblRaw.TabIndex = 23
        Me.lblRaw.Text = "999 Months"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.Location = New System.Drawing.Point(5, 336)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 13)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Monthly Aggs"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.Location = New System.Drawing.Point(5, 285)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "Weekly Aggs"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.Location = New System.Drawing.Point(5, 234)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 13)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Daily Aggs"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.Location = New System.Drawing.Point(5, 183)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 13)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "Raw Data"
        '
        'trMonthly
        '
        Me.trMonthly.AutoSize = False
        Me.trMonthly.BackColor = System.Drawing.SystemColors.Control
        Me.trMonthly.Location = New System.Drawing.Point(79, 326)
        Me.trMonthly.Maximum = 120
        Me.trMonthly.Minimum = 1
        Me.trMonthly.Name = "trMonthly"
        Me.trMonthly.Size = New System.Drawing.Size(234, 33)
        Me.trMonthly.TabIndex = 18
        Me.trMonthly.TickFrequency = 5
        Me.trMonthly.Value = 1
        '
        'trWeekly
        '
        Me.trWeekly.AutoSize = False
        Me.trWeekly.BackColor = System.Drawing.SystemColors.Control
        Me.trWeekly.Location = New System.Drawing.Point(79, 275)
        Me.trWeekly.Maximum = 120
        Me.trWeekly.Minimum = 1
        Me.trWeekly.Name = "trWeekly"
        Me.trWeekly.Size = New System.Drawing.Size(234, 33)
        Me.trWeekly.TabIndex = 17
        Me.trWeekly.TickFrequency = 5
        Me.trWeekly.Value = 1
        '
        'trDaily
        '
        Me.trDaily.AutoSize = False
        Me.trDaily.BackColor = System.Drawing.SystemColors.Control
        Me.trDaily.Location = New System.Drawing.Point(79, 224)
        Me.trDaily.Maximum = 120
        Me.trDaily.Minimum = 1
        Me.trDaily.Name = "trDaily"
        Me.trDaily.Size = New System.Drawing.Size(234, 33)
        Me.trDaily.TabIndex = 16
        Me.trDaily.TabStop = False
        Me.trDaily.TickFrequency = 5
        Me.trDaily.Value = 1
        '
        'trRaw
        '
        Me.trRaw.AutoSize = False
        Me.trRaw.BackColor = System.Drawing.SystemColors.Control
        Me.trRaw.Location = New System.Drawing.Point(79, 173)
        Me.trRaw.Maximum = 120
        Me.trRaw.Minimum = 1
        Me.trRaw.Name = "trRaw"
        Me.trRaw.Size = New System.Drawing.Size(234, 33)
        Me.trRaw.TabIndex = 15
        Me.trRaw.TabStop = False
        Me.trRaw.TickFrequency = 5
        Me.trRaw.Value = 1
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(12, 95)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(364, 75)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = resources.GetString("Label16.Text")
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(12, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(364, 59)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = resources.GetString("Label15.Text")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSaveRetentionScheme, Me.tsbCancelRetentionScheme})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(393, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbSaveRetentionScheme
        '
        Me.tsbSaveRetentionScheme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSaveRetentionScheme.Image = Global.PolyMonManager.My.Resources.Resources.saveHS
        Me.tsbSaveRetentionScheme.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSaveRetentionScheme.Name = "tsbSaveRetentionScheme"
        Me.tsbSaveRetentionScheme.Size = New System.Drawing.Size(23, 22)
        Me.tsbSaveRetentionScheme.Text = "Save"
        Me.tsbSaveRetentionScheme.ToolTipText = "SaveRetentionScheme"
        '
        'tsbCancelRetentionScheme
        '
        Me.tsbCancelRetentionScheme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCancelRetentionScheme.Image = Global.PolyMonManager.My.Resources.Resources.Edit_UndoHS
        Me.tsbCancelRetentionScheme.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelRetentionScheme.Name = "tsbCancelRetentionScheme"
        Me.tsbCancelRetentionScheme.Size = New System.Drawing.Size(23, 22)
        Me.tsbCancelRetentionScheme.Text = "Cancel"
        Me.tsbCancelRetentionScheme.ToolTipText = "Cancel all changes"
        '
        'tpUserSettings
        '
        Me.tpUserSettings.BackColor = System.Drawing.SystemColors.Control
        Me.tpUserSettings.Controls.Add(Me.GroupBox3)
        Me.tpUserSettings.Location = New System.Drawing.Point(4, 22)
        Me.tpUserSettings.Name = "tpUserSettings"
        Me.tpUserSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUserSettings.Size = New System.Drawing.Size(393, 497)
        Me.tpUserSettings.TabIndex = 1
        Me.tpUserSettings.Text = "User Settings"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "polymon.chm"
        '
        'imglstStatus
        '
        Me.imglstStatus.ImageStream = CType(resources.GetObject("imglstStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglstStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.imglstStatus.Images.SetKeyName(0, "Go.ico")
        Me.imglstStatus.Images.SetKeyName(1, "Alerts.ico")
        '
        'frmGeneralSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 528)
        Me.Controls.Add(Me.TabControl1)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "10")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGeneralSettings"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "General Settings"
        Me.tsGeneralSettingsEditor.ResumeLayout(False)
        Me.tsGeneralSettingsEditor.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.udSysMainTimerInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.upSysSMTPPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpSysSettings.ResumeLayout(False)
        Me.tpSysSettings.PerformLayout()
        Me.tpRetentionScheme.ResumeLayout(False)
        Me.tpRetentionScheme.PerformLayout()
        CType(Me.trMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trWeekly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trDaily, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trRaw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tpUserSettings.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
	Friend WithEvents tsGeneralSettingsEditor As System.Windows.Forms.ToolStrip
	Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
	Friend WithEvents tsbCancel As System.Windows.Forms.ToolStripButton
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents Label11 As System.Windows.Forms.Label
	Friend WithEvents udSysMainTimerInterval As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents txtSysServiceServer As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents upSysSMTPPort As System.Windows.Forms.NumericUpDown
	Friend WithEvents txtSysSMTPFromAddress As System.Windows.Forms.TextBox
	Friend WithEvents Label10 As System.Windows.Forms.Label
	Friend WithEvents txtSysSMTPFromName As System.Windows.Forms.TextBox
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents txtSysSMTPPwd As System.Windows.Forms.TextBox
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents txtSysSMTPUserID As System.Windows.Forms.TextBox
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents txtSysSMTPServer As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents chkSysEnabled As System.Windows.Forms.CheckBox
	Friend WithEvents txtSysName As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
	Friend WithEvents cboTimerIntervals As System.Windows.Forms.ComboBox
	Friend WithEvents chkAudioAlert As System.Windows.Forms.CheckBox
	Friend WithEvents Label14 As System.Windows.Forms.Label
	Friend WithEvents chkBalloonAlerts As System.Windows.Forms.CheckBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label12 As System.Windows.Forms.Label
	Friend WithEvents cboMDIBackColor As System.Windows.Forms.ComboBox
	Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
	Friend WithEvents tpSysSettings As System.Windows.Forms.TabPage
	Friend WithEvents tpUserSettings As System.Windows.Forms.TabPage
	Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
	Friend WithEvents btnSendTestMail As System.Windows.Forms.Button
	Friend WithEvents chkSysSMTPUseSSL As System.Windows.Forms.CheckBox
	Friend WithEvents Label13 As System.Windows.Forms.Label
	Friend WithEvents tpRetentionScheme As System.Windows.Forms.TabPage
	Friend WithEvents Label16 As System.Windows.Forms.Label
	Friend WithEvents Label15 As System.Windows.Forms.Label
	Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
	Friend WithEvents tsbSaveRetentionScheme As System.Windows.Forms.ToolStripButton
	Friend WithEvents tsbCancelRetentionScheme As System.Windows.Forms.ToolStripButton
	Friend WithEvents trMonthly As System.Windows.Forms.TrackBar
	Friend WithEvents trWeekly As System.Windows.Forms.TrackBar
	Friend WithEvents trDaily As System.Windows.Forms.TrackBar
	Friend WithEvents trRaw As System.Windows.Forms.TrackBar
	Friend WithEvents Label20 As System.Windows.Forms.Label
	Friend WithEvents Label19 As System.Windows.Forms.Label
	Friend WithEvents Label18 As System.Windows.Forms.Label
	Friend WithEvents Label17 As System.Windows.Forms.Label
	Friend WithEvents lblMonthly As System.Windows.Forms.Label
	Friend WithEvents lblWeekly As System.Windows.Forms.Label
	Friend WithEvents lblDaily As System.Windows.Forms.Label
	Friend WithEvents lblRaw As System.Windows.Forms.Label
	Friend WithEvents Label21 As System.Windows.Forms.Label
	Friend WithEvents imglstStatus As System.Windows.Forms.ImageList
End Class
