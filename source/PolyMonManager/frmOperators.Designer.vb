<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperators
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperators))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tscOperators = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.cboSummaryNotifyHour = New System.Windows.Forms.ComboBox()
        Me.cboSummaryNotifyMinute = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkSummaryOK = New System.Windows.Forms.CheckBox()
        Me.chkSummaryFail = New System.Windows.Forms.CheckBox()
        Me.chkSummaryWarn = New System.Windows.Forms.CheckBox()
        Me.gbNotificationSettings = New System.Windows.Forms.GroupBox()
        Me.chkSummaryNotify = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboQueuedNotify = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkIncludeMessageBody = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboEndMinute = New System.Windows.Forms.ComboBox()
        Me.cboEndHour = New System.Windows.Forms.ComboBox()
        Me.cboStartHour = New System.Windows.Forms.ComboBox()
        Me.cboStartMinute = New System.Windows.Forms.ComboBox()
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.gbAvailability = New System.Windows.Forms.GroupBox()
        Me.pnlOfflineTime = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.radOffline = New System.Windows.Forms.RadioButton()
        Me.radAlwaysAvailable = New System.Windows.Forms.RadioButton()
        Me.gbAlertSettings = New System.Windows.Forms.GroupBox()
        Me.pnlOperator = New System.Windows.Forms.Panel()
        Me.errSummary = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pnlOperatorID = New System.Windows.Forms.Panel()
        Me.lblIDLabel = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.gbNotificationSettings.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbAvailability.SuspendLayout()
        Me.pnlOfflineTime.SuspendLayout()
        Me.gbAlertSettings.SuspendLayout()
        Me.pnlOperator.SuspendLayout()
        CType(Me.errSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOperatorID.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.tscOperators, Me.ToolStripSeparator4, Me.tsbNew, Me.tsbSave, Me.ToolStripSeparator5, Me.tsbCancel, Me.ToolStripSeparator6, Me.tsbDelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(411, 25)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "Monitor Types"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(54, 22)
        Me.ToolStripLabel2.Text = "Operator"
        '
        'tscOperators
        '
        Me.tscOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscOperators.MaxDropDownItems = 10
        Me.tscOperators.Name = "tscOperators"
        Me.tscOperators.Size = New System.Drawing.Size(150, 25)
        Me.tscOperators.Sorted = True
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbNew
        '
        Me.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNew.Image = Global.PolyMonManager.My.Resources.Resources.AddTableHS
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(23, 22)
        Me.tsbNew.Text = "tsbNew"
        Me.tsbNew.ToolTipText = "Create New Operator"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSave.Image = Global.PolyMonManager.My.Resources.Resources.saveHS
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(23, 22)
        Me.tsbSave.Text = "ToolStripButton1"
        Me.tsbSave.ToolTipText = "Save Operator Settings"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbCancel
        '
        Me.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCancel.Image = Global.PolyMonManager.My.Resources.Resources.Edit_UndoHS
        Me.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancel.Name = "tsbCancel"
        Me.tsbCancel.Size = New System.Drawing.Size(23, 22)
        Me.tsbCancel.Text = "tsbMonitorTypes_Undo"
        Me.tsbCancel.ToolTipText = "Cancel all changes"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDelete.Image = Global.PolyMonManager.My.Resources.Resources.DeleteHS
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(23, 22)
        Me.tsbDelete.Text = "ToolStripButton1"
        Me.tsbDelete.ToolTipText = "Delete Operator"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "polymon.chm"
        '
        'cboSummaryNotifyHour
        '
        Me.cboSummaryNotifyHour.FormattingEnabled = True
        Me.cboSummaryNotifyHour.Location = New System.Drawing.Point(91, 97)
        Me.cboSummaryNotifyHour.Name = "cboSummaryNotifyHour"
        Me.cboSummaryNotifyHour.Size = New System.Drawing.Size(46, 21)
        Me.cboSummaryNotifyHour.TabIndex = 35
        '
        'cboSummaryNotifyMinute
        '
        Me.cboSummaryNotifyMinute.FormattingEnabled = True
        Me.cboSummaryNotifyMinute.Location = New System.Drawing.Point(141, 97)
        Me.cboSummaryNotifyMinute.Name = "cboSummaryNotifyMinute"
        Me.cboSummaryNotifyMinute.Size = New System.Drawing.Size(46, 21)
        Me.cboSummaryNotifyMinute.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(3, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 20)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Notification Time"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkSummaryOK
        '
        Me.chkSummaryOK.AutoSize = True
        Me.chkSummaryOK.Location = New System.Drawing.Point(6, 28)
        Me.chkSummaryOK.Name = "chkSummaryOK"
        Me.chkSummaryOK.Size = New System.Drawing.Size(121, 17)
        Me.chkSummaryOK.TabIndex = 32
        Me.chkSummaryOK.Text = "Include Status = OK"
        Me.chkSummaryOK.UseVisualStyleBackColor = True
        '
        'chkSummaryFail
        '
        Me.chkSummaryFail.AutoSize = True
        Me.chkSummaryFail.Location = New System.Drawing.Point(6, 74)
        Me.chkSummaryFail.Name = "chkSummaryFail"
        Me.chkSummaryFail.Size = New System.Drawing.Size(122, 17)
        Me.chkSummaryFail.TabIndex = 34
        Me.chkSummaryFail.Text = "Include Status = Fail"
        Me.chkSummaryFail.UseVisualStyleBackColor = True
        '
        'chkSummaryWarn
        '
        Me.chkSummaryWarn.AutoSize = True
        Me.chkSummaryWarn.Location = New System.Drawing.Point(6, 51)
        Me.chkSummaryWarn.Name = "chkSummaryWarn"
        Me.chkSummaryWarn.Size = New System.Drawing.Size(132, 17)
        Me.chkSummaryWarn.TabIndex = 33
        Me.chkSummaryWarn.Text = "Include Status = Warn"
        Me.chkSummaryWarn.UseVisualStyleBackColor = True
        '
        'gbNotificationSettings
        '
        Me.gbNotificationSettings.Controls.Add(Me.cboSummaryNotifyHour)
        Me.gbNotificationSettings.Controls.Add(Me.chkSummaryOK)
        Me.gbNotificationSettings.Controls.Add(Me.cboSummaryNotifyMinute)
        Me.gbNotificationSettings.Controls.Add(Me.chkSummaryWarn)
        Me.gbNotificationSettings.Controls.Add(Me.Label2)
        Me.gbNotificationSettings.Controls.Add(Me.chkSummaryFail)
        Me.gbNotificationSettings.Location = New System.Drawing.Point(8, 332)
        Me.gbNotificationSettings.Name = "gbNotificationSettings"
        Me.gbNotificationSettings.Size = New System.Drawing.Size(391, 130)
        Me.gbNotificationSettings.TabIndex = 30
        Me.gbNotificationSettings.TabStop = False
        Me.gbNotificationSettings.Text = "Daily Notification Settings"
        '
        'chkSummaryNotify
        '
        Me.chkSummaryNotify.AutoSize = True
        Me.chkSummaryNotify.Location = New System.Drawing.Point(12, 309)
        Me.chkSummaryNotify.Name = "chkSummaryNotify"
        Me.chkSummaryNotify.Size = New System.Drawing.Size(235, 17)
        Me.chkSummaryNotify.TabIndex = 31
        Me.chkSummaryNotify.Text = "Send Daily Summary Notification (Heartbeat)"
        Me.chkSummaryNotify.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlOperatorID)
        Me.Panel1.Controls.Add(Me.txtEmailAddress)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Location = New System.Drawing.Point(12, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(387, 66)
        Me.Panel1.TabIndex = 32
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Location = New System.Drawing.Point(97, 39)
        Me.txtEmailAddress.MaxLength = 50
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(265, 20)
        Me.txtEmailAddress.TabIndex = 43
        '
        'Label20
        '
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(3, 39)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 20)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "Email Address"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(97, 11)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(164, 20)
        Me.txtName.TabIndex = 42
        '
        'Label19
        '
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(3, 11)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 20)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "Name"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboQueuedNotify
        '
        Me.cboQueuedNotify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQueuedNotify.FormattingEnabled = True
        Me.cboQueuedNotify.Location = New System.Drawing.Point(152, 44)
        Me.cboQueuedNotify.Name = "cboQueuedNotify"
        Me.cboQueuedNotify.Size = New System.Drawing.Size(215, 21)
        Me.cboQueuedNotify.TabIndex = 39
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Offline Time Queued Alerts"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkIncludeMessageBody
        '
        Me.chkIncludeMessageBody.AutoSize = True
        Me.chkIncludeMessageBody.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludeMessageBody.Location = New System.Drawing.Point(9, 19)
        Me.chkIncludeMessageBody.Name = "chkIncludeMessageBody"
        Me.chkIncludeMessageBody.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkIncludeMessageBody.Size = New System.Drawing.Size(134, 17)
        Me.chkIncludeMessageBody.TabIndex = 37
        Me.chkIncludeMessageBody.Text = "Include Message Body"
        Me.chkIncludeMessageBody.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(207, 10)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(23, 20)
        Me.Label23.TabIndex = 32
        Me.Label23.Text = "to"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(24, 10)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(75, 20)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "Offline Time"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEndMinute
        '
        Me.cboEndMinute.FormattingEnabled = True
        Me.cboEndMinute.Location = New System.Drawing.Point(284, 10)
        Me.cboEndMinute.Name = "cboEndMinute"
        Me.cboEndMinute.Size = New System.Drawing.Size(46, 21)
        Me.cboEndMinute.TabIndex = 36
        '
        'cboEndHour
        '
        Me.cboEndHour.FormattingEnabled = True
        Me.cboEndHour.Location = New System.Drawing.Point(232, 10)
        Me.cboEndHour.Name = "cboEndHour"
        Me.cboEndHour.Size = New System.Drawing.Size(46, 21)
        Me.cboEndHour.TabIndex = 35
        '
        'cboStartHour
        '
        Me.cboStartHour.FormattingEnabled = True
        Me.cboStartHour.Location = New System.Drawing.Point(105, 10)
        Me.cboStartHour.Name = "cboStartHour"
        Me.cboStartHour.Size = New System.Drawing.Size(46, 21)
        Me.cboStartHour.TabIndex = 33
        '
        'cboStartMinute
        '
        Me.cboStartMinute.FormattingEnabled = True
        Me.cboStartMinute.Location = New System.Drawing.Point(155, 10)
        Me.cboStartMinute.Name = "cboStartMinute"
        Me.cboStartMinute.Size = New System.Drawing.Size(46, 21)
        Me.cboStartMinute.TabIndex = 34
        '
        'chkEnabled
        '
        Me.chkEnabled.Location = New System.Drawing.Point(15, 7)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(120, 16)
        Me.chkEnabled.TabIndex = 44
        Me.chkEnabled.Text = "Enable Operator"
        '
        'gbAvailability
        '
        Me.gbAvailability.Controls.Add(Me.pnlOfflineTime)
        Me.gbAvailability.Controls.Add(Me.radOffline)
        Me.gbAvailability.Controls.Add(Me.radAlwaysAvailable)
        Me.gbAvailability.Location = New System.Drawing.Point(13, 90)
        Me.gbAvailability.Name = "gbAvailability"
        Me.gbAvailability.Size = New System.Drawing.Size(386, 123)
        Me.gbAvailability.TabIndex = 45
        Me.gbAvailability.TabStop = False
        Me.gbAvailability.Text = "Operator Availability"
        '
        'pnlOfflineTime
        '
        Me.pnlOfflineTime.Controls.Add(Me.Label3)
        Me.pnlOfflineTime.Controls.Add(Me.Label22)
        Me.pnlOfflineTime.Controls.Add(Me.Label23)
        Me.pnlOfflineTime.Controls.Add(Me.cboEndMinute)
        Me.pnlOfflineTime.Controls.Add(Me.cboEndHour)
        Me.pnlOfflineTime.Controls.Add(Me.cboStartMinute)
        Me.pnlOfflineTime.Controls.Add(Me.cboStartHour)
        Me.pnlOfflineTime.Location = New System.Drawing.Point(8, 67)
        Me.pnlOfflineTime.Name = "pnlOfflineTime"
        Me.pnlOfflineTime.Size = New System.Drawing.Size(358, 56)
        Me.pnlOfflineTime.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(315, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Note: 00:00 to 00:00 is the same as 'Always Available'"
        '
        'radOffline
        '
        Me.radOffline.AutoSize = True
        Me.radOffline.Location = New System.Drawing.Point(8, 44)
        Me.radOffline.Name = "radOffline"
        Me.radOffline.Size = New System.Drawing.Size(191, 17)
        Me.radOffline.TabIndex = 38
        Me.radOffline.TabStop = True
        Me.radOffline.Text = "Always available except between..."
        Me.radOffline.UseVisualStyleBackColor = True
        '
        'radAlwaysAvailable
        '
        Me.radAlwaysAvailable.AutoSize = True
        Me.radAlwaysAvailable.Checked = True
        Me.radAlwaysAvailable.Location = New System.Drawing.Point(8, 20)
        Me.radAlwaysAvailable.Name = "radAlwaysAvailable"
        Me.radAlwaysAvailable.Size = New System.Drawing.Size(104, 17)
        Me.radAlwaysAvailable.TabIndex = 37
        Me.radAlwaysAvailable.TabStop = True
        Me.radAlwaysAvailable.Text = "Always Available"
        Me.radAlwaysAvailable.UseVisualStyleBackColor = True
        '
        'gbAlertSettings
        '
        Me.gbAlertSettings.Controls.Add(Me.chkIncludeMessageBody)
        Me.gbAlertSettings.Controls.Add(Me.cboQueuedNotify)
        Me.gbAlertSettings.Controls.Add(Me.Label1)
        Me.gbAlertSettings.Location = New System.Drawing.Point(12, 219)
        Me.gbAlertSettings.Name = "gbAlertSettings"
        Me.gbAlertSettings.Size = New System.Drawing.Size(387, 83)
        Me.gbAlertSettings.TabIndex = 46
        Me.gbAlertSettings.TabStop = False
        Me.gbAlertSettings.Text = "Alert Settings"
        '
        'pnlOperator
        '
        Me.pnlOperator.Controls.Add(Me.chkEnabled)
        Me.pnlOperator.Controls.Add(Me.Panel1)
        Me.pnlOperator.Controls.Add(Me.gbAlertSettings)
        Me.pnlOperator.Controls.Add(Me.gbNotificationSettings)
        Me.pnlOperator.Controls.Add(Me.gbAvailability)
        Me.pnlOperator.Controls.Add(Me.chkSummaryNotify)
        Me.pnlOperator.Location = New System.Drawing.Point(0, 28)
        Me.pnlOperator.Name = "pnlOperator"
        Me.pnlOperator.Size = New System.Drawing.Size(411, 478)
        Me.pnlOperator.TabIndex = 47
        '
        'errSummary
        '
        Me.errSummary.ContainerControl = Me
        '
        'pnlOperatorID
        '
        Me.pnlOperatorID.Controls.Add(Me.lblID)
        Me.pnlOperatorID.Controls.Add(Me.lblIDLabel)
        Me.pnlOperatorID.Location = New System.Drawing.Point(267, 11)
        Me.pnlOperatorID.Name = "pnlOperatorID"
        Me.pnlOperatorID.Size = New System.Drawing.Size(100, 22)
        Me.pnlOperatorID.TabIndex = 44
        '
        'lblIDLabel
        '
        Me.lblIDLabel.AutoSize = True
        Me.lblIDLabel.Location = New System.Drawing.Point(6, 4)
        Me.lblIDLabel.Name = "lblIDLabel"
        Me.lblIDLabel.Size = New System.Drawing.Size(24, 13)
        Me.lblIDLabel.TabIndex = 0
        Me.lblIDLabel.Text = "ID: "
        Me.lblIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(23, 4)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(22, 13)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "NA"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmOperators
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 510)
        Me.Controls.Add(Me.pnlOperator)
        Me.Controls.Add(Me.ToolStrip1)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "16")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOperators"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Operators"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbNotificationSettings.ResumeLayout(False)
        Me.gbNotificationSettings.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbAvailability.ResumeLayout(False)
        Me.gbAvailability.PerformLayout()
        Me.pnlOfflineTime.ResumeLayout(False)
        Me.pnlOfflineTime.PerformLayout()
        Me.gbAlertSettings.ResumeLayout(False)
        Me.gbAlertSettings.PerformLayout()
        Me.pnlOperator.ResumeLayout(False)
        Me.pnlOperator.PerformLayout()
        CType(Me.errSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOperatorID.ResumeLayout(False)
        Me.pnlOperatorID.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscOperators As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents cboSummaryNotifyHour As System.Windows.Forms.ComboBox
    Friend WithEvents cboSummaryNotifyMinute As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSummaryOK As System.Windows.Forms.CheckBox
    Friend WithEvents chkSummaryFail As System.Windows.Forms.CheckBox
    Friend WithEvents chkSummaryWarn As System.Windows.Forms.CheckBox
    Friend WithEvents gbNotificationSettings As System.Windows.Forms.GroupBox
    Friend WithEvents chkSummaryNotify As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboQueuedNotify As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkIncludeMessageBody As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboEndMinute As System.Windows.Forms.ComboBox
    Friend WithEvents cboEndHour As System.Windows.Forms.ComboBox
    Friend WithEvents cboStartHour As System.Windows.Forms.ComboBox
    Friend WithEvents cboStartMinute As System.Windows.Forms.ComboBox
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents gbAvailability As System.Windows.Forms.GroupBox
    Friend WithEvents pnlOfflineTime As System.Windows.Forms.Panel
    Friend WithEvents radOffline As System.Windows.Forms.RadioButton
    Friend WithEvents radAlwaysAvailable As System.Windows.Forms.RadioButton
    Friend WithEvents gbAlertSettings As System.Windows.Forms.GroupBox
    Friend WithEvents pnlOperator As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents errSummary As System.Windows.Forms.ErrorProvider
    Friend WithEvents pnlOperatorID As System.Windows.Forms.Panel
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblIDLabel As System.Windows.Forms.Label
End Class
