<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WMIMonitorEditor
	Inherits PolyMon.MonitorEditors.GenericMonitorEditor

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WMIMonitorEditor))
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMonitorQuery = New System.Windows.Forms.TextBox
        Me.btnMonitorQueryBuilder = New System.Windows.Forms.Button
        Me.chkEnableWarning = New System.Windows.Forms.CheckBox
        Me.cboWarningOperator = New System.Windows.Forms.ComboBox
        Me.cboFailureOperator = New System.Windows.Forms.ComboBox
        Me.chkEnableFailure = New System.Windows.Forms.CheckBox
        Me.nudWarningCount = New System.Windows.Forms.NumericUpDown
        Me.nudFailureCount = New System.Windows.Forms.NumericUpDown
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCounterQueryBuilder = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtCounterQuery = New System.Windows.Forms.TextBox
        CType(Me.nudWarningCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFailureCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(43, 6)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(326, 20)
        Me.txtHost.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Host"
        '
        'txtMonitorQuery
        '
        Me.txtMonitorQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMonitorQuery.Location = New System.Drawing.Point(6, 19)
        Me.txtMonitorQuery.Multiline = True
        Me.txtMonitorQuery.Name = "txtMonitorQuery"
        Me.txtMonitorQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMonitorQuery.Size = New System.Drawing.Size(343, 74)
        Me.txtMonitorQuery.TabIndex = 5
        '
        'btnMonitorQueryBuilder
        '
        Me.btnMonitorQueryBuilder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMonitorQueryBuilder.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMonitorQueryBuilder.Image = CType(resources.GetObject("btnMonitorQueryBuilder.Image"), System.Drawing.Image)
        Me.btnMonitorQueryBuilder.Location = New System.Drawing.Point(355, 19)
        Me.btnMonitorQueryBuilder.Name = "btnMonitorQueryBuilder"
        Me.btnMonitorQueryBuilder.Size = New System.Drawing.Size(29, 22)
        Me.btnMonitorQueryBuilder.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.btnMonitorQueryBuilder, "WMI Query Builder")
        Me.btnMonitorQueryBuilder.UseVisualStyleBackColor = True
        '
        'chkEnableWarning
        '
        Me.chkEnableWarning.AutoSize = True
        Me.chkEnableWarning.Location = New System.Drawing.Point(7, 101)
        Me.chkEnableWarning.Name = "chkEnableWarning"
        Me.chkEnableWarning.Size = New System.Drawing.Size(181, 17)
        Me.chkEnableWarning.TabIndex = 7
        Me.chkEnableWarning.Text = "Warn when # returned instances"
        Me.chkEnableWarning.UseVisualStyleBackColor = True
        '
        'cboWarningOperator
        '
        Me.cboWarningOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWarningOperator.FormattingEnabled = True
        Me.cboWarningOperator.Location = New System.Drawing.Point(194, 99)
        Me.cboWarningOperator.Name = "cboWarningOperator"
        Me.cboWarningOperator.Size = New System.Drawing.Size(52, 21)
        Me.cboWarningOperator.TabIndex = 8
        '
        'cboFailureOperator
        '
        Me.cboFailureOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFailureOperator.FormattingEnabled = True
        Me.cboFailureOperator.Location = New System.Drawing.Point(193, 125)
        Me.cboFailureOperator.Name = "cboFailureOperator"
        Me.cboFailureOperator.Size = New System.Drawing.Size(52, 21)
        Me.cboFailureOperator.TabIndex = 11
        '
        'chkEnableFailure
        '
        Me.chkEnableFailure.AutoSize = True
        Me.chkEnableFailure.Location = New System.Drawing.Point(6, 127)
        Me.chkEnableFailure.Name = "chkEnableFailure"
        Me.chkEnableFailure.Size = New System.Drawing.Size(171, 17)
        Me.chkEnableFailure.TabIndex = 10
        Me.chkEnableFailure.Text = "Fail when # returned instances"
        Me.chkEnableFailure.UseVisualStyleBackColor = True
        '
        'nudWarningCount
        '
        Me.nudWarningCount.Location = New System.Drawing.Point(252, 99)
        Me.nudWarningCount.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudWarningCount.Name = "nudWarningCount"
        Me.nudWarningCount.Size = New System.Drawing.Size(80, 20)
        Me.nudWarningCount.TabIndex = 12
        '
        'nudFailureCount
        '
        Me.nudFailureCount.Location = New System.Drawing.Point(252, 125)
        Me.nudFailureCount.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudFailureCount.Name = "nudFailureCount"
        Me.nudFailureCount.Size = New System.Drawing.Size(80, 20)
        Me.nudFailureCount.TabIndex = 13
        '
        'btnCounterQueryBuilder
        '
        Me.btnCounterQueryBuilder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCounterQueryBuilder.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCounterQueryBuilder.Image = CType(resources.GetObject("btnCounterQueryBuilder.Image"), System.Drawing.Image)
        Me.btnCounterQueryBuilder.Location = New System.Drawing.Point(355, 19)
        Me.btnCounterQueryBuilder.Name = "btnCounterQueryBuilder"
        Me.btnCounterQueryBuilder.Size = New System.Drawing.Size(29, 22)
        Me.btnCounterQueryBuilder.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.btnCounterQueryBuilder, "WMI Query Builder")
        Me.btnCounterQueryBuilder.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMonitorQuery)
        Me.GroupBox1.Controls.Add(Me.nudFailureCount)
        Me.GroupBox1.Controls.Add(Me.btnMonitorQueryBuilder)
        Me.GroupBox1.Controls.Add(Me.nudWarningCount)
        Me.GroupBox1.Controls.Add(Me.chkEnableWarning)
        Me.GroupBox1.Controls.Add(Me.cboFailureOperator)
        Me.GroupBox1.Controls.Add(Me.cboWarningOperator)
        Me.GroupBox1.Controls.Add(Me.chkEnableFailure)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 152)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Monitoring"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCounterQuery)
        Me.GroupBox2.Controls.Add(Me.btnCounterQueryBuilder)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 190)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(390, 104)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Counters"
        '
        'txtCounterQuery
        '
        Me.txtCounterQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCounterQuery.Location = New System.Drawing.Point(7, 19)
        Me.txtCounterQuery.Multiline = True
        Me.txtCounterQuery.Name = "txtCounterQuery"
        Me.txtCounterQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCounterQuery.Size = New System.Drawing.Size(342, 79)
        Me.txtCounterQuery.TabIndex = 7
        '
        'WMIMonitorEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.Label1)
        Me.Name = "WMIMonitorEditor"
        Me.Size = New System.Drawing.Size(402, 302)
        CType(Me.nudWarningCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFailureCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents txtHost As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents txtMonitorQuery As System.Windows.Forms.TextBox
	Friend WithEvents btnMonitorQueryBuilder As System.Windows.Forms.Button
	Friend WithEvents chkEnableWarning As System.Windows.Forms.CheckBox
	Friend WithEvents cboWarningOperator As System.Windows.Forms.ComboBox
	Friend WithEvents cboFailureOperator As System.Windows.Forms.ComboBox
	Friend WithEvents chkEnableFailure As System.Windows.Forms.CheckBox
	Friend WithEvents nudWarningCount As System.Windows.Forms.NumericUpDown
	Friend WithEvents nudFailureCount As System.Windows.Forms.NumericUpDown
	Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents txtCounterQuery As System.Windows.Forms.TextBox
	Friend WithEvents btnCounterQueryBuilder As System.Windows.Forms.Button

End Class
