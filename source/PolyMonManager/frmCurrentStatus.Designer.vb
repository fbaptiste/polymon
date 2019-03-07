<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCurrentStatus
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCurrentStatus))
        Me.ImageListStatus_Small = New System.Windows.Forms.ImageList(Me.components)
        Me.lvMonitors = New System.Windows.Forms.ListView()
        Me.ImageListStatus_Large = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tbtnViews = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tbtnTiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbtnIcons = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbtnDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbtnRefreshView = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tabMonitor = New System.Windows.Forms.TabControl()
        Me.tpStatus = New System.Windows.Forms.TabPage()
        Me.lblDetails_Elapsed = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblDetails_Ended = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblDetails_Started = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblOT2 = New System.Windows.Forms.Label()
        Me.txtStatusMessage = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pcbStatus = New System.Windows.Forms.PictureBox()
        Me.lblLifetimePercUptime = New System.Windows.Forms.Label()
        Me.lblMonitorType = New System.Windows.Forms.Label()
        Me.lblOfflineTimesLabel = New System.Windows.Forms.Label()
        Me.lblEventDT = New System.Windows.Forms.Label()
        Me.lblOT1 = New System.Windows.Forms.Label()
        Me.lblAsOfLabel = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.tpCounters = New System.Windows.Forms.TabPage()
        Me.dgvCounters = New System.Windows.Forms.DataGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tbtnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tbtnRun = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnHistory = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnMonitorDef = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.lblMonitorName = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        Me.tabMonitor.SuspendLayout
        Me.tpStatus.SuspendLayout
        CType(Me.pcbStatus,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tpCounters.SuspendLayout
        CType(Me.dgvCounters,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStrip2.SuspendLayout
        Me.SuspendLayout
        '
        'ImageListStatus_Small
        '
        Me.ImageListStatus_Small.ImageStream = CType(resources.GetObject("ImageListStatus_Small.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListStatus_Small.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageListStatus_Small.Images.SetKeyName(0, "Help.bmp")
        Me.ImageListStatus_Small.Images.SetKeyName(1, "OK.bmp")
        Me.ImageListStatus_Small.Images.SetKeyName(2, "Warning.bmp")
        Me.ImageListStatus_Small.Images.SetKeyName(3, "Critical.bmp")
        Me.ImageListStatus_Small.Images.SetKeyName(4, "Disabled.bmp")
        '
        'lvMonitors
        '
        Me.lvMonitors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lvMonitors.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lvMonitors.LargeImageList = Me.ImageListStatus_Large
        Me.lvMonitors.Location = New System.Drawing.Point(3, 3)
        Me.lvMonitors.MultiSelect = false
        Me.lvMonitors.Name = "lvMonitors"
        Me.lvMonitors.Size = New System.Drawing.Size(586, 322)
        Me.lvMonitors.SmallImageList = Me.ImageListStatus_Small
        Me.lvMonitors.TabIndex = 2
        Me.lvMonitors.UseCompatibleStateImageBehavior = false
        '
        'ImageListStatus_Large
        '
        Me.ImageListStatus_Large.ImageStream = CType(resources.GetObject("ImageListStatus_Large.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListStatus_Large.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListStatus_Large.Images.SetKeyName(0, "help.ico")
        Me.ImageListStatus_Large.Images.SetKeyName(1, "Go.ico")
        Me.ImageListStatus_Large.Images.SetKeyName(2, "14.ICO")
        Me.ImageListStatus_Large.Images.SetKeyName(3, "stop.ICO")
        Me.ImageListStatus_Large.Images.SetKeyName(4, "Disabled.ico")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnViews, Me.tbtnRefreshView})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(592, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tbtnViews
        '
        Me.tbtnViews.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnTiles, Me.tbtnIcons, Me.tbtnDetails})
        Me.tbtnViews.Image = Global.PolyMonManager.My.Resources.Resources.View
        Me.tbtnViews.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnViews.Name = "tbtnViews"
        Me.tbtnViews.Size = New System.Drawing.Size(66, 22)
        Me.tbtnViews.Text = "Views"
        '
        'tbtnTiles
        '
        Me.tbtnTiles.Name = "tbtnTiles"
        Me.tbtnTiles.Size = New System.Drawing.Size(109, 22)
        Me.tbtnTiles.Text = "Tiles"
        '
        'tbtnIcons
        '
        Me.tbtnIcons.Name = "tbtnIcons"
        Me.tbtnIcons.Size = New System.Drawing.Size(109, 22)
        Me.tbtnIcons.Text = "Icons"
        '
        'tbtnDetails
        '
        Me.tbtnDetails.Name = "tbtnDetails"
        Me.tbtnDetails.Size = New System.Drawing.Size(109, 22)
        Me.tbtnDetails.Text = "Details"
        '
        'tbtnRefreshView
        '
        Me.tbtnRefreshView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbtnRefreshView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnRefreshView.Image = Global.PolyMonManager.My.Resources.Resources.Refresh
        Me.tbtnRefreshView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnRefreshView.Name = "tbtnRefreshView"
        Me.tbtnRefreshView.Size = New System.Drawing.Size(23, 22)
        Me.tbtnRefreshView.Text = "Refresh View"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = true
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvMonitors)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblMonitorName)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMonitor)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip2)
        Me.SplitContainer1.Size = New System.Drawing.Size(592, 516)
        Me.SplitContainer1.SplitterDistance = 328
        Me.SplitContainer1.TabIndex = 7
        '
        'tabMonitor
        '
        Me.tabMonitor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tabMonitor.Controls.Add(Me.tpStatus)
        Me.tabMonitor.Controls.Add(Me.tpCounters)
        Me.tabMonitor.Location = New System.Drawing.Point(3, 25)
        Me.tabMonitor.Name = "tabMonitor"
        Me.tabMonitor.SelectedIndex = 0
        Me.tabMonitor.Size = New System.Drawing.Size(586, 135)
        Me.tabMonitor.TabIndex = 3
        '
        'tpStatus
        '
        Me.tpStatus.Controls.Add(Me.lblDetails_Elapsed)
        Me.tpStatus.Controls.Add(Me.Label10)
        Me.tpStatus.Controls.Add(Me.lblDetails_Ended)
        Me.tpStatus.Controls.Add(Me.Label8)
        Me.tpStatus.Controls.Add(Me.lblDetails_Started)
        Me.tpStatus.Controls.Add(Me.Label5)
        Me.tpStatus.Controls.Add(Me.lblOT2)
        Me.tpStatus.Controls.Add(Me.txtStatusMessage)
        Me.tpStatus.Controls.Add(Me.Label1)
        Me.tpStatus.Controls.Add(Me.pcbStatus)
        Me.tpStatus.Controls.Add(Me.lblLifetimePercUptime)
        Me.tpStatus.Controls.Add(Me.lblMonitorType)
        Me.tpStatus.Controls.Add(Me.lblOfflineTimesLabel)
        Me.tpStatus.Controls.Add(Me.lblEventDT)
        Me.tpStatus.Controls.Add(Me.lblOT1)
        Me.tpStatus.Controls.Add(Me.lblAsOfLabel)
        Me.tpStatus.Controls.Add(Me.lblStatus)
        Me.tpStatus.Location = New System.Drawing.Point(4, 22)
        Me.tpStatus.Name = "tpStatus"
        Me.tpStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStatus.Size = New System.Drawing.Size(578, 109)
        Me.tpStatus.TabIndex = 0
        Me.tpStatus.Text = "Status"
        Me.tpStatus.UseVisualStyleBackColor = true
        '
        'lblDetails_Elapsed
        '
        Me.lblDetails_Elapsed.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDetails_Elapsed.Location = New System.Drawing.Point(445, 70)
        Me.lblDetails_Elapsed.Name = "lblDetails_Elapsed"
        Me.lblDetails_Elapsed.Size = New System.Drawing.Size(130, 15)
        Me.lblDetails_Elapsed.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = true
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(334, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Time in Current Status"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDetails_Ended
        '
        Me.lblDetails_Ended.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDetails_Ended.Location = New System.Drawing.Point(445, 51)
        Me.lblDetails_Ended.Name = "lblDetails_Ended"
        Me.lblDetails_Ended.Size = New System.Drawing.Size(130, 15)
        Me.lblDetails_Ended.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = true
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(335, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Current Status Ended"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDetails_Started
        '
        Me.lblDetails_Started.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDetails_Started.Location = New System.Drawing.Point(445, 32)
        Me.lblDetails_Started.Name = "lblDetails_Started"
        Me.lblDetails_Started.Size = New System.Drawing.Size(130, 15)
        Me.lblDetails_Started.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = true
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(334, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Current Status Started"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOT2
        '
        Me.lblOT2.ForeColor = System.Drawing.Color.Navy
        Me.lblOT2.Location = New System.Drawing.Point(327, 93)
        Me.lblOT2.Name = "lblOT2"
        Me.lblOT2.Size = New System.Drawing.Size(80, 16)
        Me.lblOT2.TabIndex = 5
        Me.lblOT2.Text = "00:00 - 00:00"
        '
        'txtStatusMessage
        '
        Me.txtStatusMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtStatusMessage.Location = New System.Drawing.Point(48, 33)
        Me.txtStatusMessage.Multiline = true
        Me.txtStatusMessage.Name = "txtStatusMessage"
        Me.txtStatusMessage.ReadOnly = true
        Me.txtStatusMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStatusMessage.Size = New System.Drawing.Size(282, 52)
        Me.txtStatusMessage.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(445, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Uptime"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pcbStatus
        '
        Me.pcbStatus.Location = New System.Drawing.Point(6, 6)
        Me.pcbStatus.Name = "pcbStatus"
        Me.pcbStatus.Size = New System.Drawing.Size(32, 32)
        Me.pcbStatus.TabIndex = 6
        Me.pcbStatus.TabStop = false
        '
        'lblLifetimePercUptime
        '
        Me.lblLifetimePercUptime.AutoSize = true
        Me.lblLifetimePercUptime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblLifetimePercUptime.ForeColor = System.Drawing.Color.Navy
        Me.lblLifetimePercUptime.Location = New System.Drawing.Point(497, 91)
        Me.lblLifetimePercUptime.Name = "lblLifetimePercUptime"
        Me.lblLifetimePercUptime.Size = New System.Drawing.Size(62, 17)
        Me.lblLifetimePercUptime.TabIndex = 11
        Me.lblLifetimePercUptime.Text = "99.95%"
        Me.lblLifetimePercUptime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.lblLifetimePercUptime, "Lifetime % Uptime")
        '
        'lblMonitorType
        '
        Me.lblMonitorType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblMonitorType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblMonitorType.Location = New System.Drawing.Point(384, 6)
        Me.lblMonitorType.Name = "lblMonitorType"
        Me.lblMonitorType.Size = New System.Drawing.Size(188, 27)
        Me.lblMonitorType.TabIndex = 2
        Me.lblMonitorType.Text = "Label1"
        Me.lblMonitorType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOfflineTimesLabel
        '
        Me.lblOfflineTimesLabel.AutoSize = true
        Me.lblOfflineTimesLabel.ForeColor = System.Drawing.Color.Navy
        Me.lblOfflineTimesLabel.Location = New System.Drawing.Point(174, 93)
        Me.lblOfflineTimesLabel.Name = "lblOfflineTimesLabel"
        Me.lblOfflineTimesLabel.Size = New System.Drawing.Size(71, 13)
        Me.lblOfflineTimesLabel.TabIndex = 3
        Me.lblOfflineTimesLabel.Text = "Offline Times:"
        '
        'lblEventDT
        '
        Me.lblEventDT.ForeColor = System.Drawing.Color.Navy
        Me.lblEventDT.Location = New System.Drawing.Point(37, 93)
        Me.lblEventDT.Name = "lblEventDT"
        Me.lblEventDT.Size = New System.Drawing.Size(131, 16)
        Me.lblEventDT.TabIndex = 10
        Me.lblEventDT.Text = "Label2"
        '
        'lblOT1
        '
        Me.lblOT1.ForeColor = System.Drawing.Color.Navy
        Me.lblOT1.Location = New System.Drawing.Point(251, 93)
        Me.lblOT1.Name = "lblOT1"
        Me.lblOT1.Size = New System.Drawing.Size(80, 13)
        Me.lblOT1.TabIndex = 4
        Me.lblOT1.Text = "00:00 - 00:00"
        '
        'lblAsOfLabel
        '
        Me.lblAsOfLabel.AutoSize = true
        Me.lblAsOfLabel.ForeColor = System.Drawing.Color.Navy
        Me.lblAsOfLabel.Location = New System.Drawing.Point(3, 93)
        Me.lblAsOfLabel.Name = "lblAsOfLabel"
        Me.lblAsOfLabel.Size = New System.Drawing.Size(34, 13)
        Me.lblAsOfLabel.TabIndex = 9
        Me.lblAsOfLabel.Text = "As of:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = true
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblStatus.Location = New System.Drawing.Point(45, 12)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(57, 17)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "Label2"
        '
        'tpCounters
        '
        Me.tpCounters.Controls.Add(Me.dgvCounters)
        Me.tpCounters.Location = New System.Drawing.Point(4, 22)
        Me.tpCounters.Name = "tpCounters"
        Me.tpCounters.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCounters.Size = New System.Drawing.Size(578, 109)
        Me.tpCounters.TabIndex = 1
        Me.tpCounters.Text = "Counters"
        Me.tpCounters.UseVisualStyleBackColor = true
        '
        'dgvCounters
        '
        Me.dgvCounters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCounters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCounters.Location = New System.Drawing.Point(3, 3)
        Me.dgvCounters.Name = "dgvCounters"
        Me.dgvCounters.Size = New System.Drawing.Size(572, 103)
        Me.dgvCounters.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnRefresh, Me.tbtnRun, Me.ToolStripSeparator1, Me.tbtnHistory, Me.ToolStripSeparator3, Me.tbtnMonitorDef})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 159)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(592, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
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
        Me.tbtnRun.Image = CType(resources.GetObject("tbtnRun.Image"),System.Drawing.Image)
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
        Me.tbtnHistory.Image = CType(resources.GetObject("tbtnHistory.Image"),System.Drawing.Image)
        Me.tbtnHistory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnHistory.Name = "tbtnHistory"
        Me.tbtnHistory.Size = New System.Drawing.Size(23, 22)
        Me.tbtnHistory.ToolTipText = "View History & Trends"
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
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "polymon.chm"
        '
        'lblMonitorName
        '
        Me.lblMonitorName.AutoSize = true
        Me.lblMonitorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblMonitorName.Location = New System.Drawing.Point(7, 4)
        Me.lblMonitorName.Name = "lblMonitorName"
        Me.lblMonitorName.Size = New System.Drawing.Size(62, 17)
        Me.lblMonitorName.TabIndex = 4
        Me.lblMonitorName.Text = "Monitor"
        '
        'frmCurrentStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(592, 541)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.HelpProvider1.SetHelpKeyword(Me, "47")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmCurrentStatus"
        Me.HelpProvider1.SetShowHelp(Me, true)
        Me.Text = "Current Status"
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        Me.SplitContainer1.Panel2.PerformLayout
        Me.SplitContainer1.ResumeLayout(false)
        Me.tabMonitor.ResumeLayout(false)
        Me.tpStatus.ResumeLayout(false)
        Me.tpStatus.PerformLayout
        CType(Me.pcbStatus,System.ComponentModel.ISupportInitialize).EndInit
        Me.tpCounters.ResumeLayout(false)
        CType(Me.dgvCounters,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ImageListStatus_Small As System.Windows.Forms.ImageList
    Friend WithEvents lvMonitors As System.Windows.Forms.ListView
    Friend WithEvents ImageListStatus_Large As System.Windows.Forms.ImageList
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbtnViews As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tbtnTiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbtnIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbtnDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbtnRefreshView As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblMonitorType As System.Windows.Forms.Label
    Friend WithEvents lblOfflineTimesLabel As System.Windows.Forms.Label
    Friend WithEvents lblOT2 As System.Windows.Forms.Label
    Friend WithEvents lblOT1 As System.Windows.Forms.Label
    Friend WithEvents pcbStatus As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblEventDT As System.Windows.Forms.Label
    Friend WithEvents lblAsOfLabel As System.Windows.Forms.Label
    Friend WithEvents tbtnRun As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnHistory As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnMonitorDef As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblLifetimePercUptime As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents tabMonitor As System.Windows.Forms.TabControl
    Friend WithEvents tpStatus As System.Windows.Forms.TabPage
    Friend WithEvents tpCounters As System.Windows.Forms.TabPage
    Friend WithEvents dgvCounters As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtStatusMessage As System.Windows.Forms.TextBox
    Friend WithEvents lblDetails_Elapsed As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblDetails_Ended As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblDetails_Started As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblMonitorName As System.Windows.Forms.Label
End Class
