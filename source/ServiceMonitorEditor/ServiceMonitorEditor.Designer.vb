<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServiceMonitorEditor
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
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtServiceName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.radRunning = New System.Windows.Forms.RadioButton
        Me.radNotRunning = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(103, 13)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(234, 20)
        Me.txtHost.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Host"
        '
        'txtServiceName
        '
        Me.txtServiceName.Location = New System.Drawing.Point(103, 39)
        Me.txtServiceName.Name = "txtServiceName"
        Me.txtServiceName.Size = New System.Drawing.Size(234, 20)
        Me.txtServiceName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Service Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Nominal State is"
        '
        'radRunning
        '
        Me.radRunning.AutoSize = True
        Me.radRunning.Location = New System.Drawing.Point(103, 78)
        Me.radRunning.Name = "radRunning"
        Me.radRunning.Size = New System.Drawing.Size(65, 17)
        Me.radRunning.TabIndex = 3
        Me.radRunning.TabStop = True
        Me.radRunning.Text = "Running"
        Me.radRunning.UseVisualStyleBackColor = True
        '
        'radNotRunning
        '
        Me.radNotRunning.AutoSize = True
        Me.radNotRunning.Location = New System.Drawing.Point(174, 78)
        Me.radNotRunning.Name = "radNotRunning"
        Me.radNotRunning.Size = New System.Drawing.Size(85, 17)
        Me.radNotRunning.TabIndex = 4
        Me.radNotRunning.TabStop = True
        Me.radNotRunning.Text = "Not Running"
        Me.radNotRunning.UseVisualStyleBackColor = True
        '
        'ServiceMonitorEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.radNotRunning)
        Me.Controls.Add(Me.radRunning)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtServiceName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ServiceMonitorEditor"
        Me.Size = New System.Drawing.Size(366, 118)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtServiceName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents radRunning As System.Windows.Forms.RadioButton
    Friend WithEvents radNotRunning As System.Windows.Forms.RadioButton

End Class
