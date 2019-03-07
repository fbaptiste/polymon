<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCMonitorPanelDetailsView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCMonitorPanelDetailsView))
        Me.ImageListStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageListAvailStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblTimeElapsed = New System.Windows.Forms.Label()
        Me.lblHealth = New System.Windows.Forms.Label()
        Me.lblMonitorName = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tabMonitorInfo = New System.Windows.Forms.TabControl()
        Me.tpStatus = New System.Windows.Forms.TabPage()
        Me.lblLastEventDT = New System.Windows.Forms.Label()
        Me.lblMonitorType = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pcbStatus = New System.Windows.Forms.PictureBox()
        Me.tpStatusDetails = New System.Windows.Forms.TabPage()
        Me.pcbDetails_Status = New System.Windows.Forms.PictureBox()
        Me.lblDetails_Elapsed = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblDetails_Ended = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblDetails_Started = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDetails_Status = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tpCounters = New System.Windows.Forms.TabPage()
        Me.dgvCounters = New System.Windows.Forms.DataGridView()
        Me.tpInfo = New System.Windows.Forms.TabPage()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lstOperators = New System.Windows.Forms.ListBox()
        Me.lblOT2 = New System.Windows.Forms.Label()
        Me.lblOT1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFrequency = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.toolstripPanel = New System.Windows.Forms.ToolStrip()
        Me.tbtnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tbtnRun = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnHistory = New System.Windows.Forms.ToolStripButton()
        Me.tbtnDeleteMonitor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnMonitorDef = New System.Windows.Forms.ToolStripButton()
        Me.Panel1.SuspendLayout()
        Me.tabMonitorInfo.SuspendLayout()
        Me.tpStatus.SuspendLayout()
        CType(Me.pcbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpStatusDetails.SuspendLayout()
        CType(Me.pcbDetails_Status, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCounters.SuspendLayout()
        CType(Me.dgvCounters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpInfo.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolstripPanel.SuspendLayout()
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
        'ImageListAvailStatus
        '
        Me.ImageListAvailStatus.ImageStream = CType(resources.GetObject("ImageListAvailStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListAvailStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListAvailStatus.Images.SetKeyName(0, "Run.bmp")
        Me.ImageListAvailStatus.Images.SetKeyName(1, "Pause.bmp")
        '
        'lblTimeElapsed
        '
        Me.lblTimeElapsed.AutoSize = True
        Me.lblTimeElapsed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeElapsed.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTimeElapsed.Location = New System.Drawing.Point(14, 43)
        Me.lblTimeElapsed.Name = "lblTimeElapsed"
        Me.lblTimeElapsed.Size = New System.Drawing.Size(88, 13)
        Me.lblTimeElapsed.TabIndex = 24
        Me.lblTimeElapsed.Text = "Time in Status"
        Me.ToolTip1.SetToolTip(Me.lblTimeElapsed, "Time in current status")
        '
        'lblHealth
        '
        Me.lblHealth.AutoSize = True
        Me.lblHealth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHealth.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblHealth.Location = New System.Drawing.Point(200, 43)
        Me.lblHealth.Name = "lblHealth"
        Me.lblHealth.Size = New System.Drawing.Size(44, 13)
        Me.lblHealth.TabIndex = 23
        Me.lblHealth.Text = "Health"
        Me.ToolTip1.SetToolTip(Me.lblHealth, "Lifetime Percentage Uptime")
        '
        'lblMonitorName
        '
        Me.lblMonitorName.AutoSize = True
        Me.lblMonitorName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMonitorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonitorName.Location = New System.Drawing.Point(0, 0)
        Me.lblMonitorName.Name = "lblMonitorName"
        Me.lblMonitorName.Size = New System.Drawing.Size(108, 17)
        Me.lblMonitorName.TabIndex = 0
        Me.lblMonitorName.Text = "Monitor Name"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.tabMonitorInfo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Panel1.Size = New System.Drawing.Size(258, 173)
        Me.Panel1.TabIndex = 22
        '
        'tabMonitorInfo
        '
        Me.tabMonitorInfo.Controls.Add(Me.tpStatus)
        Me.tabMonitorInfo.Controls.Add(Me.tpStatusDetails)
        Me.tabMonitorInfo.Controls.Add(Me.tpCounters)
        Me.tabMonitorInfo.Controls.Add(Me.tpInfo)
        Me.tabMonitorInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMonitorInfo.Location = New System.Drawing.Point(0, 3)
        Me.tabMonitorInfo.Name = "tabMonitorInfo"
        Me.tabMonitorInfo.Padding = New System.Drawing.Point(6, 2)
        Me.tabMonitorInfo.SelectedIndex = 0
        Me.tabMonitorInfo.Size = New System.Drawing.Size(258, 170)
        Me.tabMonitorInfo.TabIndex = 19
        '
        'tpStatus
        '
        Me.tpStatus.Controls.Add(Me.lblTimeElapsed)
        Me.tpStatus.Controls.Add(Me.lblLastEventDT)
        Me.tpStatus.Controls.Add(Me.lblHealth)
        Me.tpStatus.Controls.Add(Me.lblMonitorType)
        Me.tpStatus.Controls.Add(Me.txtMessage)
        Me.tpStatus.Controls.Add(Me.lblStatus)
        Me.tpStatus.Controls.Add(Me.pcbStatus)
        Me.tpStatus.Location = New System.Drawing.Point(4, 20)
        Me.tpStatus.Name = "tpStatus"
        Me.tpStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStatus.Size = New System.Drawing.Size(250, 146)
        Me.tpStatus.TabIndex = 0
        Me.tpStatus.Text = "Status"
        Me.tpStatus.UseVisualStyleBackColor = True
        '
        'lblLastEventDT
        '
        Me.lblLastEventDT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastEventDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastEventDT.Location = New System.Drawing.Point(6, 124)
        Me.lblLastEventDT.Name = "lblLastEventDT"
        Me.lblLastEventDT.Size = New System.Drawing.Size(238, 17)
        Me.lblLastEventDT.TabIndex = 22
        Me.lblLastEventDT.Text = "Last Event DT"
        Me.lblLastEventDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMonitorType
        '
        Me.lblMonitorType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMonitorType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonitorType.Location = New System.Drawing.Point(81, 23)
        Me.lblMonitorType.Name = "lblMonitorType"
        Me.lblMonitorType.Size = New System.Drawing.Size(163, 13)
        Me.lblMonitorType.TabIndex = 19
        Me.lblMonitorType.Text = "Monitor Type"
        Me.lblMonitorType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtMessage.Location = New System.Drawing.Point(17, 59)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ReadOnly = True
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(227, 65)
        Me.txtMessage.TabIndex = 21
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblStatus.Location = New System.Drawing.Point(47, 5)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(124, 16)
        Me.lblStatus.TabIndex = 18
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcbStatus
        '
        Me.pcbStatus.Location = New System.Drawing.Point(13, 5)
        Me.pcbStatus.Name = "pcbStatus"
        Me.pcbStatus.Size = New System.Drawing.Size(16, 16)
        Me.pcbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbStatus.TabIndex = 20
        Me.pcbStatus.TabStop = False
        '
        'tpStatusDetails
        '
        Me.tpStatusDetails.Controls.Add(Me.pcbDetails_Status)
        Me.tpStatusDetails.Controls.Add(Me.lblDetails_Elapsed)
        Me.tpStatusDetails.Controls.Add(Me.Label10)
        Me.tpStatusDetails.Controls.Add(Me.lblDetails_Ended)
        Me.tpStatusDetails.Controls.Add(Me.Label8)
        Me.tpStatusDetails.Controls.Add(Me.lblDetails_Started)
        Me.tpStatusDetails.Controls.Add(Me.Label5)
        Me.tpStatusDetails.Controls.Add(Me.lblDetails_Status)
        Me.tpStatusDetails.Controls.Add(Me.Label4)
        Me.tpStatusDetails.Location = New System.Drawing.Point(4, 20)
        Me.tpStatusDetails.Name = "tpStatusDetails"
        Me.tpStatusDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStatusDetails.Size = New System.Drawing.Size(250, 146)
        Me.tpStatusDetails.TabIndex = 3
        Me.tpStatusDetails.Text = "Status Details"
        Me.tpStatusDetails.UseVisualStyleBackColor = True
        '
        'pcbDetails_Status
        '
        Me.pcbDetails_Status.Location = New System.Drawing.Point(9, 8)
        Me.pcbDetails_Status.Name = "pcbDetails_Status"
        Me.pcbDetails_Status.Size = New System.Drawing.Size(16, 16)
        Me.pcbDetails_Status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbDetails_Status.TabIndex = 13
        Me.pcbDetails_Status.TabStop = False
        '
        'lblDetails_Elapsed
        '
        Me.lblDetails_Elapsed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetails_Elapsed.Location = New System.Drawing.Point(114, 101)
        Me.lblDetails_Elapsed.Name = "lblDetails_Elapsed"
        Me.lblDetails_Elapsed.Size = New System.Drawing.Size(130, 15)
        Me.lblDetails_Elapsed.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(3, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Time in Current Status"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDetails_Ended
        '
        Me.lblDetails_Ended.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetails_Ended.Location = New System.Drawing.Point(114, 77)
        Me.lblDetails_Ended.Name = "lblDetails_Ended"
        Me.lblDetails_Ended.Size = New System.Drawing.Size(130, 15)
        Me.lblDetails_Ended.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(3, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Current Status Ended"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDetails_Started
        '
        Me.lblDetails_Started.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetails_Started.Location = New System.Drawing.Point(114, 53)
        Me.lblDetails_Started.Name = "lblDetails_Started"
        Me.lblDetails_Started.Size = New System.Drawing.Size(130, 15)
        Me.lblDetails_Started.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(3, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Current Status Started"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDetails_Status
        '
        Me.lblDetails_Status.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetails_Status.Location = New System.Drawing.Point(114, 30)
        Me.lblDetails_Status.Name = "lblDetails_Status"
        Me.lblDetails_Status.Size = New System.Drawing.Size(130, 13)
        Me.lblDetails_Status.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(3, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Current Status"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpCounters
        '
        Me.tpCounters.Controls.Add(Me.dgvCounters)
        Me.tpCounters.Location = New System.Drawing.Point(4, 20)
        Me.tpCounters.Name = "tpCounters"
        Me.tpCounters.Size = New System.Drawing.Size(250, 146)
        Me.tpCounters.TabIndex = 2
        Me.tpCounters.Text = "Counters"
        Me.tpCounters.UseVisualStyleBackColor = True
        '
        'dgvCounters
        '
        Me.dgvCounters.BackgroundColor = System.Drawing.Color.White
        Me.dgvCounters.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCounters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCounters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCounters.Location = New System.Drawing.Point(0, 0)
        Me.dgvCounters.Name = "dgvCounters"
        Me.dgvCounters.Size = New System.Drawing.Size(250, 146)
        Me.dgvCounters.TabIndex = 0
        '
        'tpInfo
        '
        Me.tpInfo.Controls.Add(Me.pnlInfo)
        Me.tpInfo.Location = New System.Drawing.Point(4, 20)
        Me.tpInfo.Name = "tpInfo"
        Me.tpInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInfo.Size = New System.Drawing.Size(250, 146)
        Me.tpInfo.TabIndex = 1
        Me.tpInfo.Text = "Info"
        Me.tpInfo.UseVisualStyleBackColor = True
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.PictureBox1)
        Me.pnlInfo.Controls.Add(Me.lstOperators)
        Me.pnlInfo.Controls.Add(Me.lblOT2)
        Me.pnlInfo.Controls.Add(Me.lblOT1)
        Me.pnlInfo.Controls.Add(Me.Label2)
        Me.pnlInfo.Controls.Add(Me.lblFrequency)
        Me.pnlInfo.Controls.Add(Me.Label3)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInfo.Location = New System.Drawing.Point(3, 3)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(244, 140)
        Me.pnlInfo.TabIndex = 15
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PolyMonManager.My.Resources.Resources.Operators
        Me.PictureBox1.Location = New System.Drawing.Point(6, 57)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'lstOperators
        '
        Me.lstOperators.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstOperators.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lstOperators.FormattingEnabled = True
        Me.lstOperators.Location = New System.Drawing.Point(35, 57)
        Me.lstOperators.Name = "lstOperators"
        Me.lstOperators.Size = New System.Drawing.Size(206, 69)
        Me.lstOperators.TabIndex = 7
        '
        'lblOT2
        '
        Me.lblOT2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOT2.Location = New System.Drawing.Point(60, 40)
        Me.lblOT2.Name = "lblOT2"
        Me.lblOT2.Size = New System.Drawing.Size(181, 11)
        Me.lblOT2.TabIndex = 5
        Me.lblOT2.Text = "OT2"
        '
        'lblOT1
        '
        Me.lblOT1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOT1.Location = New System.Drawing.Point(60, 25)
        Me.lblOT1.Name = "lblOT1"
        Me.lblOT1.Size = New System.Drawing.Size(181, 15)
        Me.lblOT1.TabIndex = 4
        Me.lblOT1.Text = "OT1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(1, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Offline"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFrequency
        '
        Me.lblFrequency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFrequency.Location = New System.Drawing.Point(60, 5)
        Me.lblFrequency.Name = "lblFrequency"
        Me.lblFrequency.Size = New System.Drawing.Size(181, 13)
        Me.lblFrequency.TabIndex = 2
        Me.lblFrequency.Text = "Freq"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(1, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Frequency"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'toolstripPanel
        '
        Me.toolstripPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.toolstripPanel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripPanel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnRefresh, Me.tbtnRun, Me.ToolStripSeparator1, Me.tbtnHistory, Me.tbtnDeleteMonitor, Me.ToolStripSeparator3, Me.tbtnMonitorDef})
        Me.toolstripPanel.Location = New System.Drawing.Point(0, 190)
        Me.toolstripPanel.Name = "toolstripPanel"
        Me.toolstripPanel.Size = New System.Drawing.Size(258, 25)
        Me.toolstripPanel.TabIndex = 21
        '
        'tbtnRefresh
        '
        Me.tbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnRefresh.Image = Global.PolyMonManager.My.Resources.Resources.Refresh
        Me.tbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnRefresh.Name = "tbtnRefresh"
        Me.tbtnRefresh.Size = New System.Drawing.Size(23, 22)
        Me.tbtnRefresh.ToolTipText = "Reload Current Status from database"
        '
        'tbtnRun
        '
        Me.tbtnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnRun.Image = CType(resources.GetObject("tbtnRun.Image"), System.Drawing.Image)
        Me.tbtnRun.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnRun.Name = "tbtnRun"
        Me.tbtnRun.Size = New System.Drawing.Size(23, 22)
        Me.tbtnRun.Text = "Run Monitor"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnHistory
        '
        Me.tbtnHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnHistory.Image = CType(resources.GetObject("tbtnHistory.Image"), System.Drawing.Image)
        Me.tbtnHistory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnHistory.Name = "tbtnHistory"
        Me.tbtnHistory.Size = New System.Drawing.Size(23, 22)
        Me.tbtnHistory.ToolTipText = "View History & Trends"
        '
        'tbtnDeleteMonitor
        '
        Me.tbtnDeleteMonitor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbtnDeleteMonitor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnDeleteMonitor.Image = Global.PolyMonManager.My.Resources.Resources.DeleteHS
        Me.tbtnDeleteMonitor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnDeleteMonitor.Name = "tbtnDeleteMonitor"
        Me.tbtnDeleteMonitor.Size = New System.Drawing.Size(23, 22)
        Me.tbtnDeleteMonitor.Text = "Remove Monitor"
        Me.tbtnDeleteMonitor.ToolTipText = "Remove Monitor from Group"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnMonitorDef
        '
        Me.tbtnMonitorDef.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnMonitorDef.Image = Global.PolyMonManager.My.Resources.Resources.MonitorDefinitions
        Me.tbtnMonitorDef.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnMonitorDef.Name = "tbtnMonitorDef"
        Me.tbtnMonitorDef.Size = New System.Drawing.Size(23, 22)
        Me.tbtnMonitorDef.ToolTipText = "Edit Monitor definition"
        '
        'UCMonitorPanelDetailsView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.toolstripPanel)
        Me.Controls.Add(Me.lblMonitorName)
        Me.Name = "UCMonitorPanelDetailsView"
        Me.Size = New System.Drawing.Size(258, 215)
        Me.Panel1.ResumeLayout(False)
        Me.tabMonitorInfo.ResumeLayout(False)
        Me.tpStatus.ResumeLayout(False)
        Me.tpStatus.PerformLayout()
        CType(Me.pcbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpStatusDetails.ResumeLayout(False)
        Me.tpStatusDetails.PerformLayout()
        CType(Me.pcbDetails_Status, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCounters.ResumeLayout(False)
        CType(Me.dgvCounters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpInfo.ResumeLayout(False)
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolstripPanel.ResumeLayout(False)
        Me.toolstripPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents ImageListStatus As System.Windows.Forms.ImageList
	Friend WithEvents ImageListAvailStatus As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblMonitorName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tabMonitorInfo As System.Windows.Forms.TabControl
    Friend WithEvents tpStatus As System.Windows.Forms.TabPage
    Friend WithEvents lblTimeElapsed As System.Windows.Forms.Label
    Friend WithEvents lblLastEventDT As System.Windows.Forms.Label
    Friend WithEvents lblHealth As System.Windows.Forms.Label
    Friend WithEvents lblMonitorType As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pcbStatus As System.Windows.Forms.PictureBox
    Friend WithEvents tpStatusDetails As System.Windows.Forms.TabPage
    Friend WithEvents pcbDetails_Status As System.Windows.Forms.PictureBox
    Friend WithEvents lblDetails_Elapsed As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblDetails_Ended As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblDetails_Started As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDetails_Status As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tpCounters As System.Windows.Forms.TabPage
    Friend WithEvents dgvCounters As System.Windows.Forms.DataGridView
    Friend WithEvents tpInfo As System.Windows.Forms.TabPage
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lstOperators As System.Windows.Forms.ListBox
    Friend WithEvents lblOT2 As System.Windows.Forms.Label
    Friend WithEvents lblOT1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFrequency As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents toolstripPanel As System.Windows.Forms.ToolStrip
    Friend WithEvents tbtnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnRun As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnHistory As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnDeleteMonitor As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnMonitorDef As System.Windows.Forms.ToolStripButton

End Class
