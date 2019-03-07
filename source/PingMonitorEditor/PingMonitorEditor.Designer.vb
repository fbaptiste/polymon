<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PingMonitorEditor
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.numNumTries = New System.Windows.Forms.NumericUpDown
        Me.numMaxFailures = New System.Windows.Forms.NumericUpDown
        Me.numTimeout = New System.Windows.Forms.NumericUpDown
        Me.numTTL = New System.Windows.Forms.NumericUpDown
        Me.numDataSize = New System.Windows.Forms.NumericUpDown
        CType(Me.numNumTries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMaxFailures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTTL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDataSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "# Tries"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Max # Failures"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Timeout (ms)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "TTL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Data Size"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(109, 11)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(234, 20)
        Me.txtHost.TabIndex = 1
        '
        'numNumTries
        '
        Me.numNumTries.Location = New System.Drawing.Point(109, 39)
        Me.numNumTries.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.numNumTries.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numNumTries.Name = "numNumTries"
        Me.numNumTries.Size = New System.Drawing.Size(54, 20)
        Me.numNumTries.TabIndex = 2
        Me.numNumTries.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numMaxFailures
        '
        Me.numMaxFailures.Location = New System.Drawing.Point(109, 65)
        Me.numMaxFailures.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.numMaxFailures.Name = "numMaxFailures"
        Me.numMaxFailures.Size = New System.Drawing.Size(54, 20)
        Me.numMaxFailures.TabIndex = 3
        '
        'numTimeout
        '
        Me.numTimeout.Location = New System.Drawing.Point(109, 91)
        Me.numTimeout.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numTimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numTimeout.Name = "numTimeout"
        Me.numTimeout.Size = New System.Drawing.Size(54, 20)
        Me.numTimeout.TabIndex = 4
        Me.numTimeout.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numTTL
        '
        Me.numTTL.Location = New System.Drawing.Point(109, 117)
        Me.numTTL.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numTTL.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numTTL.Name = "numTTL"
        Me.numTTL.Size = New System.Drawing.Size(54, 20)
        Me.numTTL.TabIndex = 5
        Me.numTTL.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numDataSize
        '
        Me.numDataSize.Location = New System.Drawing.Point(109, 144)
        Me.numDataSize.Maximum = New Decimal(New Integer() {65527, 0, 0, 0})
        Me.numDataSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numDataSize.Name = "numDataSize"
        Me.numDataSize.Size = New System.Drawing.Size(54, 20)
        Me.numDataSize.TabIndex = 6
        Me.numDataSize.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'PingMonitorEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.numDataSize)
        Me.Controls.Add(Me.numTTL)
        Me.Controls.Add(Me.numTimeout)
        Me.Controls.Add(Me.numMaxFailures)
        Me.Controls.Add(Me.numNumTries)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PingMonitorEditor"
        Me.Size = New System.Drawing.Size(357, 179)
        CType(Me.numNumTries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMaxFailures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTTL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDataSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents numNumTries As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMaxFailures As System.Windows.Forms.NumericUpDown
    Friend WithEvents numTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents numTTL As System.Windows.Forms.NumericUpDown
    Friend WithEvents numDataSize As System.Windows.Forms.NumericUpDown

End Class
