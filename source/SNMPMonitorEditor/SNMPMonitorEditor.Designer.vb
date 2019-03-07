<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SNMPMonitorEditor
    Inherits PolyMon.MonitorEditors.GenericMonitorEditor

    'UserControl1 overrides dispose to clean up the component list.
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
		Me.Label1 = New System.Windows.Forms.Label
		Me.txtHost = New System.Windows.Forms.TextBox
		Me.txtPort = New System.Windows.Forms.TextBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.txtReadCommunity = New System.Windows.Forms.TextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.txtOID = New System.Windows.Forms.TextBox
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.numTimeout = New System.Windows.Forms.NumericUpDown
		Me.Label6 = New System.Windows.Forms.Label
		Me.cboFailDataType = New System.Windows.Forms.ComboBox
		Me.cboFailComparison = New System.Windows.Forms.ComboBox
		Me.txtFailThresholdValue = New System.Windows.Forms.TextBox
		Me.Label8 = New System.Windows.Forms.Label
		Me.chkFailure = New System.Windows.Forms.CheckBox
		Me.chkWarning = New System.Windows.Forms.CheckBox
		Me.Label7 = New System.Windows.Forms.Label
		Me.txtWarnThresholdValue = New System.Windows.Forms.TextBox
		Me.cboWarnComparison = New System.Windows.Forms.ComboBox
		Me.cboWarnDataType = New System.Windows.Forms.ComboBox
		CType(Me.numTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(17, 16)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(29, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Host"
		'
		'txtHost
		'
		Me.txtHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtHost.Location = New System.Drawing.Point(113, 13)
		Me.txtHost.Name = "txtHost"
		Me.txtHost.Size = New System.Drawing.Size(219, 20)
		Me.txtHost.TabIndex = 1
		'
		'txtPort
		'
		Me.txtPort.Location = New System.Drawing.Point(113, 39)
		Me.txtPort.Name = "txtPort"
		Me.txtPort.Size = New System.Drawing.Size(73, 20)
		Me.txtPort.TabIndex = 2
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(17, 42)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(26, 13)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Port"
		'
		'txtReadCommunity
		'
		Me.txtReadCommunity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtReadCommunity.Location = New System.Drawing.Point(113, 65)
		Me.txtReadCommunity.Name = "txtReadCommunity"
		Me.txtReadCommunity.Size = New System.Drawing.Size(219, 20)
		Me.txtReadCommunity.TabIndex = 3
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(17, 68)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(87, 13)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "Read Community"
		'
		'txtOID
		'
		Me.txtOID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtOID.Location = New System.Drawing.Point(113, 91)
		Me.txtOID.Name = "txtOID"
		Me.txtOID.Size = New System.Drawing.Size(219, 20)
		Me.txtOID.TabIndex = 4
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(17, 94)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(26, 13)
		Me.Label4.TabIndex = 6
		Me.Label4.Text = "OID"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(20, 125)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(45, 13)
		Me.Label5.TabIndex = 8
		Me.Label5.Text = "Timeout"
		'
		'numTimeout
		'
		Me.numTimeout.Location = New System.Drawing.Point(113, 121)
		Me.numTimeout.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
		Me.numTimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.numTimeout.Name = "numTimeout"
		Me.numTimeout.Size = New System.Drawing.Size(73, 20)
		Me.numTimeout.TabIndex = 5
		Me.numTimeout.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(195, 125)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(69, 13)
		Me.Label6.TabIndex = 10
		Me.Label6.Text = "(milliseconds)"
		'
		'cboFailDataType
		'
		Me.cboFailDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboFailDataType.FormattingEnabled = True
		Me.cboFailDataType.Location = New System.Drawing.Point(113, 272)
		Me.cboFailDataType.Name = "cboFailDataType"
		Me.cboFailDataType.Size = New System.Drawing.Size(73, 21)
		Me.cboFailDataType.TabIndex = 6
		'
		'cboFailComparison
		'
		Me.cboFailComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboFailComparison.FormattingEnabled = True
		Me.cboFailComparison.Location = New System.Drawing.Point(137, 299)
		Me.cboFailComparison.Name = "cboFailComparison"
		Me.cboFailComparison.Size = New System.Drawing.Size(46, 21)
		Me.cboFailComparison.TabIndex = 7
		'
		'txtFailThresholdValue
		'
		Me.txtFailThresholdValue.Location = New System.Drawing.Point(195, 300)
		Me.txtFailThresholdValue.Name = "txtFailThresholdValue"
		Me.txtFailThresholdValue.Size = New System.Drawing.Size(134, 20)
		Me.txtFailThresholdValue.TabIndex = 8
		'
		'Label8
		'
		Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.ForeColor = System.Drawing.Color.Red
		Me.Label8.Location = New System.Drawing.Point(140, 323)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(189, 33)
		Me.Label8.TabIndex = 15
		Me.Label8.Text = "(Failure occurs when Monitor Value fails test as specified above)"
		'
		'chkFailure
		'
		Me.chkFailure.AutoSize = True
		Me.chkFailure.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkFailure.Location = New System.Drawing.Point(23, 274)
		Me.chkFailure.Name = "chkFailure"
		Me.chkFailure.Size = New System.Drawing.Size(57, 17)
		Me.chkFailure.TabIndex = 16
		Me.chkFailure.Text = "Failure"
		Me.chkFailure.UseVisualStyleBackColor = True
		'
		'chkWarning
		'
		Me.chkWarning.AutoSize = True
		Me.chkWarning.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkWarning.Location = New System.Drawing.Point(20, 165)
		Me.chkWarning.Name = "chkWarning"
		Me.chkWarning.Size = New System.Drawing.Size(66, 17)
		Me.chkWarning.TabIndex = 21
		Me.chkWarning.Text = "Warning"
		Me.chkWarning.UseVisualStyleBackColor = True
		'
		'Label7
		'
		Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.ForeColor = System.Drawing.Color.Red
		Me.Label7.Location = New System.Drawing.Point(137, 214)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(192, 55)
		Me.Label7.TabIndex = 20
		Me.Label7.Text = "(Warning occurs when Monitor Value fails test as specified above, unless Failure " & _
			"condition is enabled and met)"
		'
		'txtWarnThresholdValue
		'
		Me.txtWarnThresholdValue.Location = New System.Drawing.Point(195, 191)
		Me.txtWarnThresholdValue.Name = "txtWarnThresholdValue"
		Me.txtWarnThresholdValue.Size = New System.Drawing.Size(134, 20)
		Me.txtWarnThresholdValue.TabIndex = 19
		'
		'cboWarnComparison
		'
		Me.cboWarnComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboWarnComparison.FormattingEnabled = True
		Me.cboWarnComparison.Location = New System.Drawing.Point(137, 190)
		Me.cboWarnComparison.Name = "cboWarnComparison"
		Me.cboWarnComparison.Size = New System.Drawing.Size(46, 21)
		Me.cboWarnComparison.TabIndex = 18
		'
		'cboWarnDataType
		'
		Me.cboWarnDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboWarnDataType.FormattingEnabled = True
		Me.cboWarnDataType.Location = New System.Drawing.Point(113, 163)
		Me.cboWarnDataType.Name = "cboWarnDataType"
		Me.cboWarnDataType.Size = New System.Drawing.Size(73, 21)
		Me.cboWarnDataType.TabIndex = 17
		'
		'SNMPMonitorEditor
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.chkWarning)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.txtWarnThresholdValue)
		Me.Controls.Add(Me.cboWarnComparison)
		Me.Controls.Add(Me.cboWarnDataType)
		Me.Controls.Add(Me.chkFailure)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.txtFailThresholdValue)
		Me.Controls.Add(Me.cboFailComparison)
		Me.Controls.Add(Me.cboFailDataType)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.numTimeout)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.txtOID)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.txtReadCommunity)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.txtPort)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.txtHost)
		Me.Controls.Add(Me.Label1)
		Me.Name = "SNMPMonitorEditor"
		Me.Size = New System.Drawing.Size(341, 363)
		CType(Me.numTimeout, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents txtHost As System.Windows.Forms.TextBox
	Friend WithEvents txtPort As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents txtReadCommunity As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents txtOID As System.Windows.Forms.TextBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents numTimeout As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents cboFailDataType As System.Windows.Forms.ComboBox
	Friend WithEvents cboFailComparison As System.Windows.Forms.ComboBox
	Friend WithEvents txtFailThresholdValue As System.Windows.Forms.TextBox
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents chkFailure As System.Windows.Forms.CheckBox
	Friend WithEvents chkWarning As System.Windows.Forms.CheckBox
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents txtWarnThresholdValue As System.Windows.Forms.TextBox
	Friend WithEvents cboWarnComparison As System.Windows.Forms.ComboBox
	Friend WithEvents cboWarnDataType As System.Windows.Forms.ComboBox

End Class
