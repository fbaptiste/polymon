<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.StatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.DashboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.CurrentStatusAllMonitorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.AlertsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.SystemHealthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.EventHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
		Me.RefreshCurrentStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.MonitorDefinitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.OperatorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
		Me.MonitorTypesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ExecutiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.GeneralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ArrangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.HorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.VerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
		Me.MinimizeAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.RestoreAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
		Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.tsTopStatus = New System.Windows.Forms.ToolStrip
		Me.tsbDashboard = New System.Windows.Forms.ToolStripButton
		Me.tsbAllStatus = New System.Windows.Forms.ToolStripButton
		Me.tsbAlerts = New System.Windows.Forms.ToolStripButton
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
		Me.tsbUptimeAnalysis = New System.Windows.Forms.ToolStripButton
		Me.tsbEventHistory = New System.Windows.Forms.ToolStripButton
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
		Me.tsbMonitorDefs = New System.Windows.Forms.ToolStripButton
		Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
		Me.Panel1 = New System.Windows.Forms.Panel
		Me.imglstStatus = New System.Windows.Forms.ImageList(Me.components)
		Me.TimerStatusRefresh = New System.Windows.Forms.Timer(Me.components)
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
		Me.tsbtnRefresh = New System.Windows.Forms.ToolStripDropDownButton
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me.tslblUnknown = New System.Windows.Forms.ToolStripStatusLabel
		Me.tslblOK = New System.Windows.Forms.ToolStripStatusLabel
		Me.tslblAlerts = New System.Windows.Forms.ToolStripStatusLabel
		Me.tslblAsOf = New System.Windows.Forms.ToolStripStatusLabel
		Me.tslblCenter = New System.Windows.Forms.ToolStripStatusLabel
		Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
		Me.tslblAutoRefreshInterval = New System.Windows.Forms.ToolStripStatusLabel
		Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
		Me.cmenuTrayIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.OpenPolyMonManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ClosePolyMonManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.imglstTrayIcons = New System.Windows.Forms.ImageList(Me.components)
		Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
		Me.MenuStrip1.SuspendLayout()
		Me.tsTopStatus.SuspendLayout()
		Me.ToolStripPanel1.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.StatusStrip1.SuspendLayout()
		Me.cmenuTrayIcon.SuspendLayout()
		Me.SuspendLayout()
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.StatusToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.MdiWindowListItem = Me.WindowToolStripMenuItem
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(1010, 24)
		Me.MenuStrip1.TabIndex = 0
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'FileToolStripMenuItem
		'
		Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
		Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
		Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
		Me.FileToolStripMenuItem.Text = "&File"
		'
		'ExitToolStripMenuItem
		'
		Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
		Me.ExitToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
					Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
		Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
		Me.ExitToolStripMenuItem.Text = "E&xit"
		'
		'StatusToolStripMenuItem
		'
		Me.StatusToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DashboardToolStripMenuItem, Me.CurrentStatusAllMonitorsToolStripMenuItem, Me.AlertsToolStripMenuItem, Me.SystemHealthToolStripMenuItem, Me.EventHistoryToolStripMenuItem, Me.ToolStripSeparator4, Me.RefreshCurrentStatusToolStripMenuItem})
		Me.StatusToolStripMenuItem.Name = "StatusToolStripMenuItem"
		Me.StatusToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
		Me.StatusToolStripMenuItem.Text = "&Status"
		'
		'DashboardToolStripMenuItem
		'
		Me.DashboardToolStripMenuItem.Image = Global.PolyMonManager.My.Resources.Resources.Dashboard
		Me.DashboardToolStripMenuItem.Name = "DashboardToolStripMenuItem"
		Me.DashboardToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
		Me.DashboardToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
		Me.DashboardToolStripMenuItem.Text = "&Dashboard"
		'
		'CurrentStatusAllMonitorsToolStripMenuItem
		'
		Me.CurrentStatusAllMonitorsToolStripMenuItem.Image = CType(resources.GetObject("CurrentStatusAllMonitorsToolStripMenuItem.Image"), System.Drawing.Image)
		Me.CurrentStatusAllMonitorsToolStripMenuItem.Name = "CurrentStatusAllMonitorsToolStripMenuItem"
		Me.CurrentStatusAllMonitorsToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
		Me.CurrentStatusAllMonitorsToolStripMenuItem.Text = "Current Status (All Monitors)"
		'
		'AlertsToolStripMenuItem
		'
		Me.AlertsToolStripMenuItem.Image = Global.PolyMonManager.My.Resources.Resources.Alerts
		Me.AlertsToolStripMenuItem.Name = "AlertsToolStripMenuItem"
		Me.AlertsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
		Me.AlertsToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
		Me.AlertsToolStripMenuItem.Text = "&Alerts"
		'
		'SystemHealthToolStripMenuItem
		'
		Me.SystemHealthToolStripMenuItem.Image = Global.PolyMonManager.My.Resources.Resources.SystemHealth
		Me.SystemHealthToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.SystemHealthToolStripMenuItem.Name = "SystemHealthToolStripMenuItem"
		Me.SystemHealthToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
		Me.SystemHealthToolStripMenuItem.Text = "&System Health"
		'
		'EventHistoryToolStripMenuItem
		'
		Me.EventHistoryToolStripMenuItem.Image = Global.PolyMonManager.My.Resources.Resources.EventHistory
		Me.EventHistoryToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
		Me.EventHistoryToolStripMenuItem.Name = "EventHistoryToolStripMenuItem"
		Me.EventHistoryToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
		Me.EventHistoryToolStripMenuItem.Text = "Event &History"
		'
		'ToolStripSeparator4
		'
		Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
		Me.ToolStripSeparator4.Size = New System.Drawing.Size(233, 6)
		'
		'RefreshCurrentStatusToolStripMenuItem
		'
		Me.RefreshCurrentStatusToolStripMenuItem.Image = Global.PolyMonManager.My.Resources.Resources.Refresh
		Me.RefreshCurrentStatusToolStripMenuItem.Name = "RefreshCurrentStatusToolStripMenuItem"
		Me.RefreshCurrentStatusToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
		Me.RefreshCurrentStatusToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
		Me.RefreshCurrentStatusToolStripMenuItem.Text = "&Refresh Current Status"
		'
		'SettingsToolStripMenuItem
		'
		Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MonitorDefinitionsToolStripMenuItem, Me.OperatorsToolStripMenuItem, Me.ToolStripSeparator2, Me.MonitorTypesToolStripMenuItem, Me.ExecutiveToolStripMenuItem, Me.GeneralToolStripMenuItem})
		Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
		Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
		Me.SettingsToolStripMenuItem.Text = "Se&ttings"
		'
		'MonitorDefinitionsToolStripMenuItem
		'
		Me.MonitorDefinitionsToolStripMenuItem.Image = Global.PolyMonManager.My.Resources.Resources.MonitorDefinitions
		Me.MonitorDefinitionsToolStripMenuItem.Name = "MonitorDefinitionsToolStripMenuItem"
		Me.MonitorDefinitionsToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
		Me.MonitorDefinitionsToolStripMenuItem.Text = "Monitor &Definitions"
		'
		'OperatorsToolStripMenuItem
		'
		Me.OperatorsToolStripMenuItem.Image = Global.PolyMonManager.My.Resources.Resources.Operators
		Me.OperatorsToolStripMenuItem.Name = "OperatorsToolStripMenuItem"
		Me.OperatorsToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
		Me.OperatorsToolStripMenuItem.Text = "&Operators"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(171, 6)
		'
		'MonitorTypesToolStripMenuItem
		'
		Me.MonitorTypesToolStripMenuItem.Image = Global.PolyMonManager.My.Resources.Resources.MonitorTypes
		Me.MonitorTypesToolStripMenuItem.Name = "MonitorTypesToolStripMenuItem"
		Me.MonitorTypesToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
		Me.MonitorTypesToolStripMenuItem.Text = "Monitor &Types"
		'
		'ExecutiveToolStripMenuItem
		'
		Me.ExecutiveToolStripMenuItem.Image = Global.PolyMonManager.My.Resources.Resources.Executive
		Me.ExecutiveToolStripMenuItem.Name = "ExecutiveToolStripMenuItem"
		Me.ExecutiveToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
		Me.ExecutiveToolStripMenuItem.Text = "&Executive"
		'
		'GeneralToolStripMenuItem
		'
		Me.GeneralToolStripMenuItem.Image = Global.PolyMonManager.My.Resources.Resources.GeneralSettings
		Me.GeneralToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
		Me.GeneralToolStripMenuItem.Name = "GeneralToolStripMenuItem"
		Me.GeneralToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
		Me.GeneralToolStripMenuItem.Text = "&General"
		'
		'WindowToolStripMenuItem
		'
		Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArrangeToolStripMenuItem, Me.ToolStripSeparator5, Me.MinimizeAllToolStripMenuItem, Me.RestoreAllToolStripMenuItem, Me.CloseAllToolStripMenuItem})
		Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
		Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
		Me.WindowToolStripMenuItem.Text = "&Window"
		'
		'ArrangeToolStripMenuItem
		'
		Me.ArrangeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HorizontalToolStripMenuItem, Me.VerticalToolStripMenuItem, Me.CascadeToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
		Me.ArrangeToolStripMenuItem.Name = "ArrangeToolStripMenuItem"
		Me.ArrangeToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
		Me.ArrangeToolStripMenuItem.Text = "&Arrange"
		'
		'HorizontalToolStripMenuItem
		'
		Me.HorizontalToolStripMenuItem.Name = "HorizontalToolStripMenuItem"
		Me.HorizontalToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
		Me.HorizontalToolStripMenuItem.Text = "Tile &Horizontal"
		'
		'VerticalToolStripMenuItem
		'
		Me.VerticalToolStripMenuItem.Name = "VerticalToolStripMenuItem"
		Me.VerticalToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
		Me.VerticalToolStripMenuItem.Text = "Tile &Vertical"
		'
		'CascadeToolStripMenuItem
		'
		Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
		Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
		Me.CascadeToolStripMenuItem.Text = "&Cascade"
		'
		'ArrangeIconsToolStripMenuItem
		'
		Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
		Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
		Me.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons"
		'
		'ToolStripSeparator5
		'
		Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
		Me.ToolStripSeparator5.Size = New System.Drawing.Size(135, 6)
		'
		'MinimizeAllToolStripMenuItem
		'
		Me.MinimizeAllToolStripMenuItem.Name = "MinimizeAllToolStripMenuItem"
		Me.MinimizeAllToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
		Me.MinimizeAllToolStripMenuItem.Text = "&Minimize All"
		'
		'RestoreAllToolStripMenuItem
		'
		Me.RestoreAllToolStripMenuItem.Name = "RestoreAllToolStripMenuItem"
		Me.RestoreAllToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
		Me.RestoreAllToolStripMenuItem.Text = "&Restore All"
		'
		'CloseAllToolStripMenuItem
		'
		Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
		Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
		Me.CloseAllToolStripMenuItem.Text = "&Close All"
		'
		'HelpToolStripMenuItem
		'
		Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.ToolStripSeparator6, Me.AboutToolStripMenuItem})
		Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
		Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
		Me.HelpToolStripMenuItem.Text = "&Help"
		'
		'ContentsToolStripMenuItem
		'
		Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
		Me.ContentsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
					Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
		Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
		Me.ContentsToolStripMenuItem.Text = "&Contents"
		'
		'ToolStripSeparator6
		'
		Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
		Me.ToolStripSeparator6.Size = New System.Drawing.Size(199, 6)
		'
		'AboutToolStripMenuItem
		'
		Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
		Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
		Me.AboutToolStripMenuItem.Text = "&About PolyMon Manager"
		'
		'tsTopStatus
		'
		Me.tsTopStatus.Dock = System.Windows.Forms.DockStyle.None
		Me.tsTopStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.tsTopStatus.ImageScalingSize = New System.Drawing.Size(32, 32)
		Me.tsTopStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDashboard, Me.tsbAllStatus, Me.tsbAlerts, Me.ToolStripSeparator1, Me.tsbUptimeAnalysis, Me.tsbEventHistory, Me.ToolStripSeparator3, Me.tsbMonitorDefs})
		Me.tsTopStatus.Location = New System.Drawing.Point(0, 0)
		Me.tsTopStatus.Name = "tsTopStatus"
		Me.tsTopStatus.Size = New System.Drawing.Size(1010, 39)
		Me.tsTopStatus.Stretch = True
		Me.tsTopStatus.TabIndex = 7
		'
		'tsbDashboard
		'
		Me.tsbDashboard.Image = Global.PolyMonManager.My.Resources.Resources.Dashboard
		Me.tsbDashboard.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbDashboard.Name = "tsbDashboard"
		Me.tsbDashboard.Size = New System.Drawing.Size(95, 36)
		Me.tsbDashboard.Text = "Dashboard"
		'
		'tsbAllStatus
		'
		Me.tsbAllStatus.Image = CType(resources.GetObject("tsbAllStatus.Image"), System.Drawing.Image)
		Me.tsbAllStatus.ImageTransparentColor = System.Drawing.Color.Teal
		Me.tsbAllStatus.Name = "tsbAllStatus"
		Me.tsbAllStatus.Size = New System.Drawing.Size(132, 36)
		Me.tsbAllStatus.Text = "All Monitors Status"
		'
		'tsbAlerts
		'
		Me.tsbAlerts.Image = Global.PolyMonManager.My.Resources.Resources.Alerts
		Me.tsbAlerts.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbAlerts.Name = "tsbAlerts"
		Me.tsbAlerts.Size = New System.Drawing.Size(71, 36)
		Me.tsbAlerts.Text = "Alerts"
		Me.tsbAlerts.ToolTipText = "Failures and Warnings"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
		'
		'tsbUptimeAnalysis
		'
		Me.tsbUptimeAnalysis.Image = Global.PolyMonManager.My.Resources.Resources.SystemHealth
		Me.tsbUptimeAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbUptimeAnalysis.Name = "tsbUptimeAnalysis"
		Me.tsbUptimeAnalysis.Size = New System.Drawing.Size(112, 36)
		Me.tsbUptimeAnalysis.Text = "System Health"
		Me.tsbUptimeAnalysis.ToolTipText = "System Health Report"
		'
		'tsbEventHistory
		'
		Me.tsbEventHistory.Image = Global.PolyMonManager.My.Resources.Resources.EventHistory
		Me.tsbEventHistory.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbEventHistory.Name = "tsbEventHistory"
		Me.tsbEventHistory.Size = New System.Drawing.Size(108, 36)
		Me.tsbEventHistory.Text = "Event History"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
		'
		'tsbMonitorDefs
		'
		Me.tsbMonitorDefs.Image = Global.PolyMonManager.My.Resources.Resources.MonitorDefinitions
		Me.tsbMonitorDefs.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbMonitorDefs.Name = "tsbMonitorDefs"
		Me.tsbMonitorDefs.Size = New System.Drawing.Size(132, 36)
		Me.tsbMonitorDefs.Text = "Monitor Definitions"
		Me.tsbMonitorDefs.ToolTipText = "Create/Edit Monitor Definitions"
		'
		'ToolStripPanel1
		'
		Me.ToolStripPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.ToolStripPanel1.Controls.Add(Me.tsTopStatus)
		Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 24)
		Me.ToolStripPanel1.Name = "ToolStripPanel1"
		Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
		Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
		Me.ToolStripPanel1.Size = New System.Drawing.Size(1010, 39)
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.MenuStrip1)
		Me.Panel1.Controls.Add(Me.ToolStripPanel1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1010, 62)
		Me.Panel1.TabIndex = 9
		'
		'imglstStatus
		'
		Me.imglstStatus.ImageStream = CType(resources.GetObject("imglstStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imglstStatus.TransparentColor = System.Drawing.Color.Transparent
		Me.imglstStatus.Images.SetKeyName(0, "warning.bmp")
		Me.imglstStatus.Images.SetKeyName(1, "Error.bmp")
		'
		'TimerStatusRefresh
		'
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnRefresh, Me.ToolStripStatusLabel1, Me.tslblUnknown, Me.tslblOK, Me.tslblAlerts, Me.tslblAsOf, Me.tslblCenter, Me.ToolStripStatusLabel2, Me.tslblAutoRefreshInterval})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 601)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(1010, 22)
		Me.StatusStrip1.TabIndex = 11
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'tsbtnRefresh
		'
		Me.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.tsbtnRefresh.Image = Global.PolyMonManager.My.Resources.Resources.Refresh
		Me.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbtnRefresh.Name = "tsbtnRefresh"
		Me.tsbtnRefresh.ShowDropDownArrow = False
		Me.tsbtnRefresh.Size = New System.Drawing.Size(20, 20)
		Me.tsbtnRefresh.Text = "Refresh Status"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(86, 17)
		Me.ToolStripStatusLabel1.Text = "Current Status:"
		'
		'tslblUnknown
		'
		Me.tslblUnknown.Image = Global.PolyMonManager.My.Resources.Resources.Unknown
		Me.tslblUnknown.Name = "tslblUnknown"
		Me.tslblUnknown.Size = New System.Drawing.Size(67, 17)
		Me.tslblUnknown.Text = "Unknown"
		'
		'tslblOK
		'
		Me.tslblOK.Image = CType(resources.GetObject("tslblOK.Image"), System.Drawing.Image)
		Me.tslblOK.ImageTransparentColor = System.Drawing.Color.Fuchsia
		Me.tslblOK.IsLink = True
		Me.tslblOK.Name = "tslblOK"
		Me.tslblOK.Size = New System.Drawing.Size(37, 17)
		Me.tslblOK.Text = "OK"
		'
		'tslblAlerts
		'
		Me.tslblAlerts.Image = Global.PolyMonManager.My.Resources.Resources.Warning
		Me.tslblAlerts.IsLink = True
		Me.tslblAlerts.Name = "tslblAlerts"
		Me.tslblAlerts.Size = New System.Drawing.Size(51, 17)
		Me.tslblAlerts.Text = "Alerts"
		'
		'tslblAsOf
		'
		Me.tslblAsOf.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
		Me.tslblAsOf.Name = "tslblAsOf"
		Me.tslblAsOf.Size = New System.Drawing.Size(46, 17)
		Me.tslblAsOf.Text = "(as of )"
		'
		'tslblCenter
		'
		Me.tslblCenter.Name = "tslblCenter"
		Me.tslblCenter.Size = New System.Drawing.Size(484, 17)
		Me.tslblCenter.Spring = True
		'
		'ToolStripStatusLabel2
		'
		Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
		Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(153, 17)
		Me.ToolStripStatusLabel2.Text = "Auto Status Refresh Interval: "
		Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'tslblAutoRefreshInterval
		'
		Me.tslblAutoRefreshInterval.IsLink = True
		Me.tslblAutoRefreshInterval.Name = "tslblAutoRefreshInterval"
		Me.tslblAutoRefreshInterval.Size = New System.Drawing.Size(51, 17)
		Me.tslblAutoRefreshInterval.Text = "Unknown"
		Me.tslblAutoRefreshInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'NotifyIcon1
		'
		Me.NotifyIcon1.ContextMenuStrip = Me.cmenuTrayIcon
		Me.NotifyIcon1.Text = "PolyMon"
		Me.NotifyIcon1.Visible = True
		'
		'cmenuTrayIcon
		'
		Me.cmenuTrayIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenPolyMonManagerToolStripMenuItem, Me.ClosePolyMonManagerToolStripMenuItem})
		Me.cmenuTrayIcon.Name = "cmenuTrayIcon"
		Me.cmenuTrayIcon.Size = New System.Drawing.Size(112, 48)
		'
		'OpenPolyMonManagerToolStripMenuItem
		'
		Me.OpenPolyMonManagerToolStripMenuItem.Image = CType(resources.GetObject("OpenPolyMonManagerToolStripMenuItem.Image"), System.Drawing.Image)
		Me.OpenPolyMonManagerToolStripMenuItem.Name = "OpenPolyMonManagerToolStripMenuItem"
		Me.OpenPolyMonManagerToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
		Me.OpenPolyMonManagerToolStripMenuItem.Text = "&Open"
		'
		'ClosePolyMonManagerToolStripMenuItem
		'
		Me.ClosePolyMonManagerToolStripMenuItem.Name = "ClosePolyMonManagerToolStripMenuItem"
		Me.ClosePolyMonManagerToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
		Me.ClosePolyMonManagerToolStripMenuItem.Text = "E&xit"
		'
		'imglstTrayIcons
		'
		Me.imglstTrayIcons.ImageStream = CType(resources.GetObject("imglstTrayIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imglstTrayIcons.TransparentColor = System.Drawing.Color.Transparent
		Me.imglstTrayIcons.Images.SetKeyName(0, "PolyMonOK.ico")
		Me.imglstTrayIcons.Images.SetKeyName(1, "PolyMonWarning.ico")
		'
		'HelpProvider1
		'
		Me.HelpProvider1.HelpNamespace = "PolyMon.chm"
		'
		'frmMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.ClientSize = New System.Drawing.Size(1010, 623)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.Panel1)
		Me.HelpButton = True
		Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TableOfContents)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.IsMdiContainer = True
		Me.MainMenuStrip = Me.MenuStrip1
		Me.Name = "frmMain"
		Me.HelpProvider1.SetShowHelp(Me, True)
		Me.Text = "PolyMon Manager"
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.tsTopStatus.ResumeLayout(False)
		Me.tsTopStatus.PerformLayout()
		Me.ToolStripPanel1.ResumeLayout(False)
		Me.ToolStripPanel1.PerformLayout()
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.cmenuTrayIcon.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DashboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlertsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeneralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExecutiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperatorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonitorTypesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonitorDefinitionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsTopStatus As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbDashboard As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAlerts As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents imglstStatus As System.Windows.Forms.ImageList
    Friend WithEvents TimerStatusRefresh As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblUnknown As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblOK As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblAlerts As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbtnRefresh As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblAutoRefreshInterval As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblCenter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblAsOf As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents imglstTrayIcons As System.Windows.Forms.ImageList
    Friend WithEvents cmenuTrayIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenPolyMonManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClosePolyMonManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbEventHistory As System.Windows.Forms.ToolStripButton
    Friend WithEvents EventHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbUptimeAnalysis As System.Windows.Forms.ToolStripButton
    Friend WithEvents SystemHealthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbMonitorDefs As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshCurrentStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MinimizeAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents CurrentStatusAllMonitorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbAllStatus As System.Windows.Forms.ToolStripButton

End Class
