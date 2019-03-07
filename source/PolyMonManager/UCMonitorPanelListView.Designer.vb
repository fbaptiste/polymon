<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCMonitorPanelListView
    Inherits UCMonitorPanel


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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCMonitorPanelListView))
        Me.ImageListStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.pcbStatus = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblMonitorType = New System.Windows.Forms.Label()
        Me.lblLastEventDT = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnRun = New System.Windows.Forms.Button()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.btnRemoveMonitor = New System.Windows.Forms.Button()
        Me.btnMonitorDef = New System.Windows.Forms.Button()
        Me.lblHealth = New System.Windows.Forms.Label()
        Me.lblMonitorName = New System.Windows.Forms.Label()
        CType(Me.pcbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageListStatus
        '
        Me.ImageListStatus.ImageStream = CType(resources.GetObject("ImageListStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListStatus.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageListStatus.Images.SetKeyName(0, "Help.bmp")
        Me.ImageListStatus.Images.SetKeyName(1, "OK.bmp")
        Me.ImageListStatus.Images.SetKeyName(2, "Warning.bmp")
        Me.ImageListStatus.Images.SetKeyName(3, "Critical.bmp")
        Me.ImageListStatus.Images.SetKeyName(4, "204_27.ico")
        Me.ImageListStatus.Images.SetKeyName(5, "TRFFC10A.ICO")
        Me.ImageListStatus.Images.SetKeyName(6, "warning.ico")
        Me.ImageListStatus.Images.SetKeyName(7, "error.ico")
        Me.ImageListStatus.Images.SetKeyName(8, "Disabled.ico")
        '
        'pcbStatus
        '
        Me.pcbStatus.Location = New System.Drawing.Point(3, 8)
        Me.pcbStatus.Name = "pcbStatus"
        Me.pcbStatus.Size = New System.Drawing.Size(18, 18)
        Me.pcbStatus.TabIndex = 4
        Me.pcbStatus.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoEllipsis = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblStatus.Location = New System.Drawing.Point(583, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(124, 32)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.lblStatus, "Time elapsed in current status")
        '
        'lblMonitorType
        '
        Me.lblMonitorType.AutoEllipsis = True
        Me.lblMonitorType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonitorType.Location = New System.Drawing.Point(340, 0)
        Me.lblMonitorType.Name = "lblMonitorType"
        Me.lblMonitorType.Size = New System.Drawing.Size(127, 32)
        Me.lblMonitorType.TabIndex = 6
        Me.lblMonitorType.Text = "Monitor Type"
        Me.lblMonitorType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLastEventDT
        '
        Me.lblLastEventDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastEventDT.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblLastEventDT.Location = New System.Drawing.Point(715, 0)
        Me.lblLastEventDT.Name = "lblLastEventDT"
        Me.lblLastEventDT.Size = New System.Drawing.Size(106, 32)
        Me.lblLastEventDT.TabIndex = 7
        Me.lblLastEventDT.Text = "Last Event DT"
        Me.lblLastEventDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMessage
        '
        Me.lblMessage.AutoEllipsis = True
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(473, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(106, 32)
        Me.lblMessage.TabIndex = 9
        Me.lblMessage.Text = "Last Event DT long long line to see what happens"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRefresh
        '
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = Global.PolyMonManager.My.Resources.Resources.Refresh
        Me.btnRefresh.Location = New System.Drawing.Point(826, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(20, 20)
        Me.btnRefresh.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.btnRefresh, "Refresh current status from database")
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnRun
        '
        Me.btnRun.FlatAppearance.BorderSize = 0
        Me.btnRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRun.Image = CType(resources.GetObject("btnRun.Image"), System.Drawing.Image)
        Me.btnRun.Location = New System.Drawing.Point(847, 6)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(20, 20)
        Me.btnRun.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.btnRun, "Run Monitor Now")
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.FlatAppearance.BorderSize = 0
        Me.btnHistory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistory.Image = CType(resources.GetObject("btnHistory.Image"), System.Drawing.Image)
        Me.btnHistory.Location = New System.Drawing.Point(874, 6)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(20, 20)
        Me.btnHistory.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.btnHistory, "View History & Trends")
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'btnRemoveMonitor
        '
        Me.btnRemoveMonitor.FlatAppearance.BorderSize = 0
        Me.btnRemoveMonitor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnRemoveMonitor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnRemoveMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveMonitor.Image = Global.PolyMonManager.My.Resources.Resources.DeleteHS
        Me.btnRemoveMonitor.Location = New System.Drawing.Point(921, 6)
        Me.btnRemoveMonitor.Name = "btnRemoveMonitor"
        Me.btnRemoveMonitor.Size = New System.Drawing.Size(20, 20)
        Me.btnRemoveMonitor.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnRemoveMonitor, "Remove Monitor from this Group")
        Me.btnRemoveMonitor.UseVisualStyleBackColor = True
        '
        'btnMonitorDef
        '
        Me.btnMonitorDef.BackgroundImage = Global.PolyMonManager.My.Resources.Resources.MonitorDefinitions
        Me.btnMonitorDef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMonitorDef.FlatAppearance.BorderSize = 0
        Me.btnMonitorDef.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnMonitorDef.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnMonitorDef.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMonitorDef.Location = New System.Drawing.Point(898, 6)
        Me.btnMonitorDef.Name = "btnMonitorDef"
        Me.btnMonitorDef.Size = New System.Drawing.Size(20, 20)
        Me.btnMonitorDef.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnMonitorDef, "Edit Monitor Configuration")
        Me.btnMonitorDef.UseVisualStyleBackColor = True
        '
        'lblHealth
        '
        Me.lblHealth.AutoEllipsis = True
        Me.lblHealth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHealth.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblHealth.Location = New System.Drawing.Point(275, 0)
        Me.lblHealth.Name = "lblHealth"
        Me.lblHealth.Size = New System.Drawing.Size(59, 32)
        Me.lblHealth.TabIndex = 15
        Me.lblHealth.Text = "99.999%"
        Me.lblHealth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.lblHealth, "Lifetime Percentage Uptime")
        '
        'lblMonitorName
        '
        Me.lblMonitorName.AutoSize = True
        Me.lblMonitorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonitorName.Location = New System.Drawing.Point(37, 10)
        Me.lblMonitorName.Name = "lblMonitorName"
        Me.lblMonitorName.Size = New System.Drawing.Size(108, 17)
        Me.lblMonitorName.TabIndex = 16
        Me.lblMonitorName.Text = "Monitor Name"
        '
        'UCMonitorPanelListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.lblMonitorName)
        Me.Controls.Add(Me.lblHealth)
        Me.Controls.Add(Me.btnMonitorDef)
        Me.Controls.Add(Me.btnRemoveMonitor)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblLastEventDT)
        Me.Controls.Add(Me.lblMonitorType)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pcbStatus)
        Me.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
        Me.Name = "UCMonitorPanelListView"
        Me.Size = New System.Drawing.Size(947, 32)
        CType(Me.pcbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents ImageListStatus As System.Windows.Forms.ImageList
	Friend WithEvents pcbStatus As System.Windows.Forms.PictureBox
	Friend WithEvents lblStatus As System.Windows.Forms.Label
	Friend WithEvents lblMonitorType As System.Windows.Forms.Label
	Friend WithEvents lblLastEventDT As System.Windows.Forms.Label
	Friend WithEvents lblMessage As System.Windows.Forms.Label
	Friend WithEvents btnRefresh As System.Windows.Forms.Button
	Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
	Friend WithEvents btnRun As System.Windows.Forms.Button
	Friend WithEvents btnHistory As System.Windows.Forms.Button
	Friend WithEvents btnRemoveMonitor As System.Windows.Forms.Button
	Friend WithEvents btnMonitorDef As System.Windows.Forms.Button
    Friend WithEvents lblHealth As System.Windows.Forms.Label
    Friend WithEvents lblMonitorName As System.Windows.Forms.Label

End Class
