<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CPUMonitorEditor
	Inherits PolyMon.MonitorEditors.GenericMonitorEditor

	'UserControl1 overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.txtHost = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.chkWarn = New System.Windows.Forms.CheckBox
		Me.cboWarnType = New System.Windows.Forms.ComboBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.cboFailType = New System.Windows.Forms.ComboBox
		Me.chkFail = New System.Windows.Forms.CheckBox
		Me.nudWarnValue = New System.Windows.Forms.NumericUpDown
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.nudFailValue = New System.Windows.Forms.NumericUpDown
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		CType(Me.nudWarnValue, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.nudFailValue, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'txtHost
		'
		Me.txtHost.Location = New System.Drawing.Point(81, 16)
		Me.txtHost.Name = "txtHost"
		Me.txtHost.Size = New System.Drawing.Size(242, 20)
		Me.txtHost.TabIndex = 3
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(46, 20)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(29, 13)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Host"
		'
		'chkWarn
		'
		Me.chkWarn.AutoSize = True
		Me.chkWarn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkWarn.Location = New System.Drawing.Point(15, 53)
		Me.chkWarn.Name = "chkWarn"
		Me.chkWarn.Size = New System.Drawing.Size(60, 17)
		Me.chkWarn.TabIndex = 6
		Me.chkWarn.Text = "Warn if"
		Me.chkWarn.UseVisualStyleBackColor = True
		'
		'cboWarnType
		'
		Me.cboWarnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboWarnType.FormattingEnabled = True
		Me.cboWarnType.Location = New System.Drawing.Point(81, 51)
		Me.cboWarnType.Name = "cboWarnType"
		Me.cboWarnType.Size = New System.Drawing.Size(98, 21)
		Me.cboWarnType.TabIndex = 7
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(183, 55)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(117, 13)
		Me.Label3.TabIndex = 10
		Me.Label3.Text = "CPU % Usage exceeds"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(183, 90)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(117, 13)
		Me.Label2.TabIndex = 14
		Me.Label2.Text = "CPU % Usage exceeds"
		'
		'cboFailType
		'
		Me.cboFailType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboFailType.FormattingEnabled = True
		Me.cboFailType.Location = New System.Drawing.Point(81, 86)
		Me.cboFailType.Name = "cboFailType"
		Me.cboFailType.Size = New System.Drawing.Size(98, 21)
		Me.cboFailType.TabIndex = 12
		'
		'chkFail
		'
		Me.chkFail.AutoSize = True
		Me.chkFail.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkFail.Location = New System.Drawing.Point(15, 88)
		Me.chkFail.Name = "chkFail"
		Me.chkFail.Size = New System.Drawing.Size(50, 17)
		Me.chkFail.TabIndex = 11
		Me.chkFail.Text = "Fail if"
		Me.chkFail.UseVisualStyleBackColor = True
		'
		'nudWarnValue
		'
		Me.nudWarnValue.Location = New System.Drawing.Point(307, 51)
		Me.nudWarnValue.Name = "nudWarnValue"
		Me.nudWarnValue.Size = New System.Drawing.Size(58, 20)
		Me.nudWarnValue.TabIndex = 15
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(371, 55)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(15, 13)
		Me.Label4.TabIndex = 16
		Me.Label4.Text = "%"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(371, 90)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(15, 13)
		Me.Label5.TabIndex = 18
		Me.Label5.Text = "%"
		'
		'nudFailValue
		'
		Me.nudFailValue.Location = New System.Drawing.Point(307, 86)
		Me.nudFailValue.Name = "nudFailValue"
		Me.nudFailValue.Size = New System.Drawing.Size(58, 20)
		Me.nudFailValue.TabIndex = 17
		'
		'Label6
		'
		Me.Label6.ForeColor = System.Drawing.Color.Red
		Me.Label6.Location = New System.Drawing.Point(15, 127)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(371, 31)
		Me.Label6.TabIndex = 19
		Me.Label6.Text = "* Note: This monitor uses the Windows Performance Counter (Processor : %Processor" & _
			" Time.)"
		'
		'Label7
		'
		Me.Label7.ForeColor = System.Drawing.Color.Red
		Me.Label7.Location = New System.Drawing.Point(15, 158)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(371, 48)
		Me.Label7.TabIndex = 20
		Me.Label7.Text = "If the monitored server (host) does not expose that counter, this monitor will no" & _
			"t work. In that case please use the PerfMonitor instead to use any specific Wind" & _
			"ows Performance Counter."
		'
		'CPUMonitorEditor
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.nudFailValue)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.nudWarnValue)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.cboFailType)
		Me.Controls.Add(Me.chkFail)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.cboWarnType)
		Me.Controls.Add(Me.chkWarn)
		Me.Controls.Add(Me.txtHost)
		Me.Controls.Add(Me.Label1)
		Me.Name = "CPUMonitorEditor"
		Me.Size = New System.Drawing.Size(401, 210)
		CType(Me.nudWarnValue, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.nudFailValue, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txtHost As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents chkWarn As System.Windows.Forms.CheckBox
	Friend WithEvents cboWarnType As System.Windows.Forms.ComboBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents cboFailType As System.Windows.Forms.ComboBox
	Friend WithEvents chkFail As System.Windows.Forms.CheckBox
	Friend WithEvents nudWarnValue As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents nudFailValue As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
