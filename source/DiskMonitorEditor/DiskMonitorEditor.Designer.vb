<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiskMonitorEditor
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
    Me.RadioButtonLocalDrive = New System.Windows.Forms.RadioButton
    Me.RadioButtonNetworkShare = New System.Windows.Forms.RadioButton
    Me.DomainUpDownDrive = New System.Windows.Forms.DomainUpDown
    Me.TextBoxNetworkShare = New System.Windows.Forms.TextBox
    Me.DomainUpDownTempDrive = New System.Windows.Forms.DomainUpDown
    Me.LabelTempDrive = New System.Windows.Forms.Label
    Me.NumericUpDownWarnMB = New System.Windows.Forms.NumericUpDown
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.NumericUpDownFailMB = New System.Windows.Forms.NumericUpDown
    Me.Label5 = New System.Windows.Forms.Label
    Me.ComboBoxError = New System.Windows.Forms.ComboBox
    CType(Me.NumericUpDownWarnMB, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownFailMB, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'RadioButtonLocalDrive
    '
    Me.RadioButtonLocalDrive.AutoSize = True
    Me.RadioButtonLocalDrive.Checked = True
    Me.RadioButtonLocalDrive.Location = New System.Drawing.Point(3, 3)
    Me.RadioButtonLocalDrive.Name = "RadioButtonLocalDrive"
    Me.RadioButtonLocalDrive.Size = New System.Drawing.Size(82, 17)
    Me.RadioButtonLocalDrive.TabIndex = 0
    Me.RadioButtonLocalDrive.TabStop = True
    Me.RadioButtonLocalDrive.Text = "Local Drive:"
    Me.RadioButtonLocalDrive.UseVisualStyleBackColor = True
    '
    'RadioButtonNetworkShare
    '
    Me.RadioButtonNetworkShare.AutoSize = True
    Me.RadioButtonNetworkShare.Location = New System.Drawing.Point(3, 30)
    Me.RadioButtonNetworkShare.Name = "RadioButtonNetworkShare"
    Me.RadioButtonNetworkShare.Size = New System.Drawing.Size(99, 17)
    Me.RadioButtonNetworkShare.TabIndex = 2
    Me.RadioButtonNetworkShare.Text = "Network Share:"
    Me.RadioButtonNetworkShare.UseVisualStyleBackColor = True
    '
    'DomainUpDownDrive
    '
    Me.DomainUpDownDrive.Items.Add("A:")
    Me.DomainUpDownDrive.Items.Add("B:")
    Me.DomainUpDownDrive.Items.Add("C:")
    Me.DomainUpDownDrive.Items.Add("D:")
    Me.DomainUpDownDrive.Items.Add("E:")
    Me.DomainUpDownDrive.Items.Add("F:")
    Me.DomainUpDownDrive.Items.Add("G:")
    Me.DomainUpDownDrive.Items.Add("H:")
    Me.DomainUpDownDrive.Items.Add("I:")
    Me.DomainUpDownDrive.Items.Add("J:")
    Me.DomainUpDownDrive.Items.Add("K:")
    Me.DomainUpDownDrive.Items.Add("L:")
    Me.DomainUpDownDrive.Items.Add("M:")
    Me.DomainUpDownDrive.Items.Add("N:")
    Me.DomainUpDownDrive.Items.Add("O:")
    Me.DomainUpDownDrive.Items.Add("P:")
    Me.DomainUpDownDrive.Items.Add("Q:")
    Me.DomainUpDownDrive.Items.Add("R:")
    Me.DomainUpDownDrive.Items.Add("S:")
    Me.DomainUpDownDrive.Items.Add("T:")
    Me.DomainUpDownDrive.Items.Add("U:")
    Me.DomainUpDownDrive.Items.Add("V:")
    Me.DomainUpDownDrive.Items.Add("W:")
    Me.DomainUpDownDrive.Items.Add("X:")
    Me.DomainUpDownDrive.Items.Add("Y:")
    Me.DomainUpDownDrive.Items.Add("Z:")
    Me.DomainUpDownDrive.Location = New System.Drawing.Point(105, 3)
    Me.DomainUpDownDrive.Name = "DomainUpDownDrive"
    Me.DomainUpDownDrive.Size = New System.Drawing.Size(37, 20)
    Me.DomainUpDownDrive.TabIndex = 1
    Me.DomainUpDownDrive.Text = "C:"
    '
    'TextBoxNetworkShare
    '
    Me.TextBoxNetworkShare.Enabled = False
    Me.TextBoxNetworkShare.Location = New System.Drawing.Point(105, 29)
    Me.TextBoxNetworkShare.Name = "TextBoxNetworkShare"
    Me.TextBoxNetworkShare.Size = New System.Drawing.Size(249, 20)
    Me.TextBoxNetworkShare.TabIndex = 3
    '
    'DomainUpDownTempDrive
    '
    Me.DomainUpDownTempDrive.Enabled = False
    Me.DomainUpDownTempDrive.Items.Add("A:")
    Me.DomainUpDownTempDrive.Items.Add("B:")
    Me.DomainUpDownTempDrive.Items.Add("C:")
    Me.DomainUpDownTempDrive.Items.Add("D:")
    Me.DomainUpDownTempDrive.Items.Add("E:")
    Me.DomainUpDownTempDrive.Items.Add("F:")
    Me.DomainUpDownTempDrive.Items.Add("G:")
    Me.DomainUpDownTempDrive.Items.Add("H:")
    Me.DomainUpDownTempDrive.Items.Add("I:")
    Me.DomainUpDownTempDrive.Items.Add("J:")
    Me.DomainUpDownTempDrive.Items.Add("K:")
    Me.DomainUpDownTempDrive.Items.Add("L:")
    Me.DomainUpDownTempDrive.Items.Add("M:")
    Me.DomainUpDownTempDrive.Items.Add("N:")
    Me.DomainUpDownTempDrive.Items.Add("O:")
    Me.DomainUpDownTempDrive.Items.Add("P:")
    Me.DomainUpDownTempDrive.Items.Add("Q:")
    Me.DomainUpDownTempDrive.Items.Add("R:")
    Me.DomainUpDownTempDrive.Items.Add("S:")
    Me.DomainUpDownTempDrive.Items.Add("T:")
    Me.DomainUpDownTempDrive.Items.Add("U:")
    Me.DomainUpDownTempDrive.Items.Add("V:")
    Me.DomainUpDownTempDrive.Items.Add("W:")
    Me.DomainUpDownTempDrive.Items.Add("X:")
    Me.DomainUpDownTempDrive.Items.Add("Y:")
    Me.DomainUpDownTempDrive.Items.Add("Z:")
    Me.DomainUpDownTempDrive.Location = New System.Drawing.Point(201, 55)
    Me.DomainUpDownTempDrive.Name = "DomainUpDownTempDrive"
    Me.DomainUpDownTempDrive.Size = New System.Drawing.Size(37, 20)
    Me.DomainUpDownTempDrive.TabIndex = 5
    Me.DomainUpDownTempDrive.Text = "Z:"
    '
    'LabelTempDrive
    '
    Me.LabelTempDrive.AutoSize = True
    Me.LabelTempDrive.Enabled = False
    Me.LabelTempDrive.Location = New System.Drawing.Point(3, 57)
    Me.LabelTempDrive.Name = "LabelTempDrive"
    Me.LabelTempDrive.Size = New System.Drawing.Size(192, 13)
    Me.LabelTempDrive.TabIndex = 4
    Me.LabelTempDrive.Text = "Network Share Temporary Drive Letter:"
    '
    'NumericUpDownWarnMB
    '
    Me.NumericUpDownWarnMB.Location = New System.Drawing.Point(110, 81)
    Me.NumericUpDownWarnMB.Maximum = New Decimal(New Integer() {0, -2147483648, 0, 0})
    Me.NumericUpDownWarnMB.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.NumericUpDownWarnMB.Name = "NumericUpDownWarnMB"
    Me.NumericUpDownWarnMB.Size = New System.Drawing.Size(85, 20)
    Me.NumericUpDownWarnMB.TabIndex = 7
    Me.NumericUpDownWarnMB.Value = New Decimal(New Integer() {1024, 0, 0, 0})
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(3, 83)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(110, 13)
    Me.Label1.TabIndex = 6
    Me.Label1.Text = "Warn when less than "
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(196, 83)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(137, 13)
    Me.Label2.TabIndex = 8
    Me.Label2.Text = "MB free space is remaining."
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(3, 109)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(100, 13)
    Me.Label3.TabIndex = 9
    Me.Label3.Text = "Fail when less than "
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(187, 109)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(137, 13)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "MB free space is remaining."
    '
    'NumericUpDownFailMB
    '
    Me.NumericUpDownFailMB.Location = New System.Drawing.Point(102, 107)
    Me.NumericUpDownFailMB.Maximum = New Decimal(New Integer() {0, -2147483648, 0, 0})
    Me.NumericUpDownFailMB.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.NumericUpDownFailMB.Name = "NumericUpDownFailMB"
    Me.NumericUpDownFailMB.Size = New System.Drawing.Size(85, 20)
    Me.NumericUpDownFailMB.TabIndex = 10
    Me.NumericUpDownFailMB.Value = New Decimal(New Integer() {512, 0, 0, 0})
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(3, 136)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(82, 13)
    Me.Label5.TabIndex = 12
    Me.Label5.Text = "Report errors as"
    '
    'ComboBoxError
    '
    Me.ComboBoxError.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBoxError.FormattingEnabled = True
    Me.ComboBoxError.Items.AddRange(New Object() {"FAIL", "WARN", "UNKNOWN", "OK"})
    Me.ComboBoxError.Location = New System.Drawing.Point(91, 133)
    Me.ComboBoxError.Name = "ComboBoxError"
    Me.ComboBoxError.Size = New System.Drawing.Size(121, 21)
    Me.ComboBoxError.TabIndex = 13
    '
    'DiskMonitorEditor
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.ComboBoxError)
    Me.Controls.Add(Me.NumericUpDownFailMB)
    Me.Controls.Add(Me.NumericUpDownWarnMB)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LabelTempDrive)
    Me.Controls.Add(Me.TextBoxNetworkShare)
    Me.Controls.Add(Me.DomainUpDownTempDrive)
    Me.Controls.Add(Me.DomainUpDownDrive)
    Me.Controls.Add(Me.RadioButtonNetworkShare)
    Me.Controls.Add(Me.RadioButtonLocalDrive)
    Me.Name = "DiskMonitorEditor"
    Me.Size = New System.Drawing.Size(357, 179)
    CType(Me.NumericUpDownWarnMB, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownFailMB, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents RadioButtonLocalDrive As System.Windows.Forms.RadioButton
  Friend WithEvents RadioButtonNetworkShare As System.Windows.Forms.RadioButton
  Friend WithEvents DomainUpDownDrive As System.Windows.Forms.DomainUpDown
  Friend WithEvents TextBoxNetworkShare As System.Windows.Forms.TextBox
  Friend WithEvents DomainUpDownTempDrive As System.Windows.Forms.DomainUpDown
  Friend WithEvents LabelTempDrive As System.Windows.Forms.Label
  Friend WithEvents NumericUpDownWarnMB As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents NumericUpDownFailMB As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents ComboBoxError As System.Windows.Forms.ComboBox

End Class
