<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgMonitor
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
        Me.Label = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lstviewMonitors = New System.Windows.Forms.ListView()
        Me.Monitors_ColH_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Monitors_ColH_MonitorType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Monitors_ColH_Enabled = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Monitors_ColH_Mod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Monitors_ColH_MonitorID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(12, 6)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(124, 13)
        Me.Label.TabIndex = 4
        Me.Label.Text = "Please choose a Monitor"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(381, 473)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'lstviewMonitors
        '
        Me.lstviewMonitors.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstviewMonitors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstviewMonitors.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Monitors_ColH_Name, Me.Monitors_ColH_MonitorType, Me.Monitors_ColH_Enabled, Me.Monitors_ColH_Mod, Me.Monitors_ColH_MonitorID})
        Me.lstviewMonitors.FullRowSelect = True
        Me.lstviewMonitors.HideSelection = False
        Me.lstviewMonitors.Location = New System.Drawing.Point(12, 33)
        Me.lstviewMonitors.Name = "lstviewMonitors"
        Me.lstviewMonitors.Size = New System.Drawing.Size(515, 434)
        Me.lstviewMonitors.TabIndex = 5
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
        'dlgMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 514)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lstviewMonitors)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgMonitor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Monitor..."
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lstviewMonitors As System.Windows.Forms.ListView
    Friend WithEvents Monitors_ColH_Name As System.Windows.Forms.ColumnHeader
    Friend WithEvents Monitors_ColH_MonitorType As System.Windows.Forms.ColumnHeader
    Friend WithEvents Monitors_ColH_Enabled As System.Windows.Forms.ColumnHeader
    Friend WithEvents Monitors_ColH_Mod As System.Windows.Forms.ColumnHeader
    Friend WithEvents Monitors_ColH_MonitorID As System.Windows.Forms.ColumnHeader

End Class
