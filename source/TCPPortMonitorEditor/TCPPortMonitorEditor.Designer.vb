<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TCPPortMonitorEditor
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.numTCPPort = New System.Windows.Forms.NumericUpDown
        Me.numTimeout = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.numTCPPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "TCP Port"
        '
        'txtHost
        '
        Me.txtHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHost.Location = New System.Drawing.Point(66, 8)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(165, 20)
        Me.txtHost.TabIndex = 2
        '
        'numTCPPort
        '
        Me.numTCPPort.Location = New System.Drawing.Point(66, 34)
        Me.numTCPPort.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
        Me.numTCPPort.Name = "numTCPPort"
        Me.numTCPPort.Size = New System.Drawing.Size(76, 20)
        Me.numTCPPort.TabIndex = 3
        '
        'numTimeout
        '
        Me.numTimeout.Location = New System.Drawing.Point(66, 60)
        Me.numTimeout.Maximum = New Decimal(New Integer() {600000, 0, 0, 0})
        Me.numTimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numTimeout.Name = "numTimeout"
        Me.numTimeout.Size = New System.Drawing.Size(76, 20)
        Me.numTimeout.TabIndex = 5
        Me.numTimeout.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Timeout"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(144, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "(milliseconds)"
        '
        'TCPPortMonitorEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numTimeout)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numTCPPort)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TCPPortMonitorEditor"
        Me.Size = New System.Drawing.Size(242, 97)
        CType(Me.numTCPPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents numTCPPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents numTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
