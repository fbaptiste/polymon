<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Me.tctlReports = New System.Windows.Forms.TabControl()
        Me.tabOverview = New System.Windows.Forms.TabPage()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.ChartsOverview = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFailure = New System.Windows.Forms.Label()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.lblOK = New System.Windows.Forms.Label()
        Me.lblStatusDate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLifetimePercUptime = New System.Windows.Forms.Label()
        Me.tabDaily = New System.Windows.Forms.TabPage()
        Me.btnViewData_Daily = New System.Windows.Forms.Button()
        Me.ChartsDaily = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDailyStartDT = New System.Windows.Forms.Label()
        Me.lblDailyEndDT = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnRunDaily = New System.Windows.Forms.Button()
        Me.dtpDailyEndDT = New System.Windows.Forms.DateTimePicker()
        Me.dtpDailyStartDT = New System.Windows.Forms.DateTimePicker()
        Me.tabWeekly = New System.Windows.Forms.TabPage()
        Me.btnViewData_Weekly = New System.Windows.Forms.Button()
        Me.ChartsWeekly = New System.Windows.Forms.TableLayoutPanel()
        Me.lblWeeklyStartDT = New System.Windows.Forms.Label()
        Me.lblWeeklyEndDT = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnRunWeekly = New System.Windows.Forms.Button()
        Me.dtpWeeklyEndDT = New System.Windows.Forms.DateTimePicker()
        Me.dtpWeeklyStartDT = New System.Windows.Forms.DateTimePicker()
        Me.tabMonthly = New System.Windows.Forms.TabPage()
        Me.btnViewData_Monthly = New System.Windows.Forms.Button()
        Me.ChartsMonthly = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMonthlyStartDT = New System.Windows.Forms.Label()
        Me.lblMonthlyEndDT = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnRunMonthly = New System.Windows.Forms.Button()
        Me.dtpMonthlyEndDT = New System.Windows.Forms.DateTimePicker()
        Me.dtpMonthlyStartDT = New System.Windows.Forms.DateTimePicker()
        Me.tabRaw = New System.Windows.Forms.TabPage()
        Me.btnViewData_Custom = New System.Windows.Forms.Button()
        Me.ChartsCustom = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRunCustom = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboCustomTimePeriods = New System.Windows.Forms.ComboBox()
        Me.nudCustomFrequency = New System.Windows.Forms.NumericUpDown()
        Me.chkCustomGrouped = New System.Windows.Forms.CheckBox()
        Me.lblCustomStartDT = New System.Windows.Forms.Label()
        Me.lblCustomEndDT = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpCustomEndDT = New System.Windows.Forms.DateTimePicker()
        Me.dtpCustomStartDT = New System.Windows.Forms.DateTimePicker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblMonitorType = New System.Windows.Forms.Label()
        Me.lblMonitor = New System.Windows.Forms.Label()
        Me.tctlReports.SuspendLayout()
        Me.tabOverview.SuspendLayout()
        Me.tabDaily.SuspendLayout()
        Me.tabWeekly.SuspendLayout()
        Me.tabMonthly.SuspendLayout()
        Me.tabRaw.SuspendLayout()
        CType(Me.nudCustomFrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tctlReports
        '
        Me.tctlReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tctlReports.Controls.Add(Me.tabOverview)
        Me.tctlReports.Controls.Add(Me.tabDaily)
        Me.tctlReports.Controls.Add(Me.tabWeekly)
        Me.tctlReports.Controls.Add(Me.tabMonthly)
        Me.tctlReports.Controls.Add(Me.tabRaw)
        Me.tctlReports.Location = New System.Drawing.Point(4, 36)
        Me.tctlReports.Name = "tctlReports"
        Me.tctlReports.SelectedIndex = 0
        Me.tctlReports.Size = New System.Drawing.Size(632, 469)
        Me.tctlReports.TabIndex = 0
        '
        'tabOverview
        '
        Me.tabOverview.Controls.Add(Me.btnRefresh)
        Me.tabOverview.Controls.Add(Me.ChartsOverview)
        Me.tabOverview.Controls.Add(Me.lblFailure)
        Me.tabOverview.Controls.Add(Me.lblWarning)
        Me.tabOverview.Controls.Add(Me.lblOK)
        Me.tabOverview.Controls.Add(Me.lblStatusDate)
        Me.tabOverview.Controls.Add(Me.Label1)
        Me.tabOverview.Controls.Add(Me.lblLifetimePercUptime)
        Me.tabOverview.Location = New System.Drawing.Point(4, 22)
        Me.tabOverview.Name = "tabOverview"
        Me.tabOverview.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOverview.Size = New System.Drawing.Size(624, 443)
        Me.tabOverview.TabIndex = 0
        Me.tabOverview.Text = "Overview"
        Me.tabOverview.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = Global.PolyMonManager.My.Resources.Resources.Refresh
        Me.btnRefresh.Location = New System.Drawing.Point(355, 9)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(20, 20)
        Me.btnRefresh.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.btnRefresh, "Refresh current status from database")
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'ChartsOverview
        '
        Me.ChartsOverview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChartsOverview.AutoScroll = True
        Me.ChartsOverview.ColumnCount = 2
        Me.ChartsOverview.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsOverview.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsOverview.Location = New System.Drawing.Point(10, 48)
        Me.ChartsOverview.Name = "ChartsOverview"
        Me.ChartsOverview.RowCount = 1
        Me.ChartsOverview.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.0!))
        Me.ChartsOverview.Size = New System.Drawing.Size(606, 389)
        Me.ChartsOverview.TabIndex = 8
        '
        'lblFailure
        '
        Me.lblFailure.BackColor = System.Drawing.Color.Red
        Me.lblFailure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFailure.ForeColor = System.Drawing.Color.White
        Me.lblFailure.Location = New System.Drawing.Point(166, 8)
        Me.lblFailure.Name = "lblFailure"
        Me.lblFailure.Size = New System.Drawing.Size(57, 23)
        Me.lblFailure.TabIndex = 6
        Me.lblFailure.Text = "Failure"
        Me.lblFailure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWarning
        '
        Me.lblWarning.BackColor = System.Drawing.Color.Orange
        Me.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWarning.ForeColor = System.Drawing.Color.White
        Me.lblWarning.Location = New System.Drawing.Point(110, 8)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(57, 23)
        Me.lblWarning.TabIndex = 5
        Me.lblWarning.Text = "Warning"
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOK
        '
        Me.lblOK.BackColor = System.Drawing.Color.SkyBlue
        Me.lblOK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOK.ForeColor = System.Drawing.Color.Black
        Me.lblOK.Location = New System.Drawing.Point(54, 8)
        Me.lblOK.Name = "lblOK"
        Me.lblOK.Size = New System.Drawing.Size(57, 23)
        Me.lblOK.TabIndex = 4
        Me.lblOK.Text = "OK"
        Me.lblOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusDate
        '
        Me.lblStatusDate.AutoSize = True
        Me.lblStatusDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusDate.Location = New System.Drawing.Point(229, 13)
        Me.lblStatusDate.Name = "lblStatusDate"
        Me.lblStatusDate.Size = New System.Drawing.Size(95, 12)
        Me.lblStatusDate.TabIndex = 3
        Me.lblStatusDate.Text = "(2007-02-01 23:59:59)"
        Me.ToolTip1.SetToolTip(Me.lblStatusDate, "Date of last monitor event")
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Current"
        '
        'lblLifetimePercUptime
        '
        Me.lblLifetimePercUptime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLifetimePercUptime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLifetimePercUptime.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLifetimePercUptime.Location = New System.Drawing.Point(520, 13)
        Me.lblLifetimePercUptime.Name = "lblLifetimePercUptime"
        Me.lblLifetimePercUptime.Size = New System.Drawing.Size(96, 13)
        Me.lblLifetimePercUptime.TabIndex = 0
        Me.lblLifetimePercUptime.Text = "% Uptime (Lifetime)"
        Me.lblLifetimePercUptime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblLifetimePercUptime, "Lifetime % Uptime")
        '
        'tabDaily
        '
        Me.tabDaily.Controls.Add(Me.btnViewData_Daily)
        Me.tabDaily.Controls.Add(Me.ChartsDaily)
        Me.tabDaily.Controls.Add(Me.lblDailyStartDT)
        Me.tabDaily.Controls.Add(Me.lblDailyEndDT)
        Me.tabDaily.Controls.Add(Me.Label5)
        Me.tabDaily.Controls.Add(Me.Label2)
        Me.tabDaily.Controls.Add(Me.btnRunDaily)
        Me.tabDaily.Controls.Add(Me.dtpDailyEndDT)
        Me.tabDaily.Controls.Add(Me.dtpDailyStartDT)
        Me.tabDaily.Location = New System.Drawing.Point(4, 22)
        Me.tabDaily.Name = "tabDaily"
        Me.tabDaily.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDaily.Size = New System.Drawing.Size(624, 443)
        Me.tabDaily.TabIndex = 1
        Me.tabDaily.Text = "Daily"
        Me.tabDaily.UseVisualStyleBackColor = True
        '
        'btnViewData_Daily
        '
        Me.btnViewData_Daily.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewData_Daily.Enabled = False
        Me.btnViewData_Daily.Location = New System.Drawing.Point(543, 6)
        Me.btnViewData_Daily.Name = "btnViewData_Daily"
        Me.btnViewData_Daily.Size = New System.Drawing.Size(75, 23)
        Me.btnViewData_Daily.TabIndex = 17
        Me.btnViewData_Daily.Text = "View Data"
        Me.btnViewData_Daily.UseVisualStyleBackColor = True
        '
        'ChartsDaily
        '
        Me.ChartsDaily.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChartsDaily.AutoScroll = True
        Me.ChartsDaily.ColumnCount = 2
        Me.ChartsDaily.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsDaily.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsDaily.Location = New System.Drawing.Point(6, 47)
        Me.ChartsDaily.Name = "ChartsDaily"
        Me.ChartsDaily.RowCount = 2
        Me.ChartsDaily.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsDaily.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsDaily.Size = New System.Drawing.Size(612, 400)
        Me.ChartsDaily.TabIndex = 16
        '
        'lblDailyStartDT
        '
        Me.lblDailyStartDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDailyStartDT.Location = New System.Drawing.Point(63, 30)
        Me.lblDailyStartDT.Name = "lblDailyStartDT"
        Me.lblDailyStartDT.Size = New System.Drawing.Size(99, 13)
        Me.lblDailyStartDT.TabIndex = 15
        Me.lblDailyStartDT.Text = "Available"
        Me.lblDailyStartDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDailyEndDT
        '
        Me.lblDailyEndDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDailyEndDT.Location = New System.Drawing.Point(168, 30)
        Me.lblDailyEndDT.Name = "lblDailyEndDT"
        Me.lblDailyEndDT.Size = New System.Drawing.Size(99, 13)
        Me.lblDailyEndDT.TabIndex = 14
        Me.lblDailyEndDT.Text = "Available"
        Me.lblDailyEndDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Available"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(6, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Range"
        '
        'btnRunDaily
        '
        Me.btnRunDaily.Location = New System.Drawing.Point(273, 6)
        Me.btnRunDaily.Name = "btnRunDaily"
        Me.btnRunDaily.Size = New System.Drawing.Size(75, 23)
        Me.btnRunDaily.TabIndex = 11
        Me.btnRunDaily.Text = "Run"
        Me.btnRunDaily.UseVisualStyleBackColor = True
        '
        'dtpDailyEndDT
        '
        Me.dtpDailyEndDT.CustomFormat = ""
        Me.dtpDailyEndDT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDailyEndDT.Location = New System.Drawing.Point(168, 7)
        Me.dtpDailyEndDT.Name = "dtpDailyEndDT"
        Me.dtpDailyEndDT.Size = New System.Drawing.Size(99, 20)
        Me.dtpDailyEndDT.TabIndex = 10
        '
        'dtpDailyStartDT
        '
        Me.dtpDailyStartDT.CustomFormat = ""
        Me.dtpDailyStartDT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDailyStartDT.Location = New System.Drawing.Point(63, 7)
        Me.dtpDailyStartDT.Name = "dtpDailyStartDT"
        Me.dtpDailyStartDT.Size = New System.Drawing.Size(99, 20)
        Me.dtpDailyStartDT.TabIndex = 9
        '
        'tabWeekly
        '
        Me.tabWeekly.Controls.Add(Me.btnViewData_Weekly)
        Me.tabWeekly.Controls.Add(Me.ChartsWeekly)
        Me.tabWeekly.Controls.Add(Me.lblWeeklyStartDT)
        Me.tabWeekly.Controls.Add(Me.lblWeeklyEndDT)
        Me.tabWeekly.Controls.Add(Me.Label10)
        Me.tabWeekly.Controls.Add(Me.Label3)
        Me.tabWeekly.Controls.Add(Me.btnRunWeekly)
        Me.tabWeekly.Controls.Add(Me.dtpWeeklyEndDT)
        Me.tabWeekly.Controls.Add(Me.dtpWeeklyStartDT)
        Me.tabWeekly.Location = New System.Drawing.Point(4, 22)
        Me.tabWeekly.Name = "tabWeekly"
        Me.tabWeekly.Size = New System.Drawing.Size(624, 443)
        Me.tabWeekly.TabIndex = 2
        Me.tabWeekly.Text = "Weekly"
        Me.tabWeekly.UseVisualStyleBackColor = True
        '
        'btnViewData_Weekly
        '
        Me.btnViewData_Weekly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewData_Weekly.Enabled = False
        Me.btnViewData_Weekly.Location = New System.Drawing.Point(541, 6)
        Me.btnViewData_Weekly.Name = "btnViewData_Weekly"
        Me.btnViewData_Weekly.Size = New System.Drawing.Size(75, 23)
        Me.btnViewData_Weekly.TabIndex = 21
        Me.btnViewData_Weekly.Text = "View Data"
        Me.btnViewData_Weekly.UseVisualStyleBackColor = True
        '
        'ChartsWeekly
        '
        Me.ChartsWeekly.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChartsWeekly.AutoScroll = True
        Me.ChartsWeekly.ColumnCount = 2
        Me.ChartsWeekly.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsWeekly.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsWeekly.Location = New System.Drawing.Point(9, 47)
        Me.ChartsWeekly.Name = "ChartsWeekly"
        Me.ChartsWeekly.RowCount = 2
        Me.ChartsWeekly.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsWeekly.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsWeekly.Size = New System.Drawing.Size(607, 400)
        Me.ChartsWeekly.TabIndex = 20
        '
        'lblWeeklyStartDT
        '
        Me.lblWeeklyStartDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyStartDT.Location = New System.Drawing.Point(63, 30)
        Me.lblWeeklyStartDT.Name = "lblWeeklyStartDT"
        Me.lblWeeklyStartDT.Size = New System.Drawing.Size(99, 13)
        Me.lblWeeklyStartDT.TabIndex = 19
        Me.lblWeeklyStartDT.Text = "Available"
        Me.lblWeeklyStartDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWeeklyEndDT
        '
        Me.lblWeeklyEndDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyEndDT.Location = New System.Drawing.Point(168, 30)
        Me.lblWeeklyEndDT.Name = "lblWeeklyEndDT"
        Me.lblWeeklyEndDT.Size = New System.Drawing.Size(99, 13)
        Me.lblWeeklyEndDT.TabIndex = 18
        Me.lblWeeklyEndDT.Text = "Available"
        Me.lblWeeklyEndDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Available"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(6, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Range"
        '
        'btnRunWeekly
        '
        Me.btnRunWeekly.Location = New System.Drawing.Point(273, 6)
        Me.btnRunWeekly.Name = "btnRunWeekly"
        Me.btnRunWeekly.Size = New System.Drawing.Size(75, 23)
        Me.btnRunWeekly.TabIndex = 15
        Me.btnRunWeekly.Text = "Run"
        Me.btnRunWeekly.UseVisualStyleBackColor = True
        '
        'dtpWeeklyEndDT
        '
        Me.dtpWeeklyEndDT.CustomFormat = ""
        Me.dtpWeeklyEndDT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpWeeklyEndDT.Location = New System.Drawing.Point(168, 7)
        Me.dtpWeeklyEndDT.Name = "dtpWeeklyEndDT"
        Me.dtpWeeklyEndDT.Size = New System.Drawing.Size(99, 20)
        Me.dtpWeeklyEndDT.TabIndex = 14
        '
        'dtpWeeklyStartDT
        '
        Me.dtpWeeklyStartDT.CustomFormat = ""
        Me.dtpWeeklyStartDT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpWeeklyStartDT.Location = New System.Drawing.Point(63, 7)
        Me.dtpWeeklyStartDT.Name = "dtpWeeklyStartDT"
        Me.dtpWeeklyStartDT.Size = New System.Drawing.Size(99, 20)
        Me.dtpWeeklyStartDT.TabIndex = 13
        '
        'tabMonthly
        '
        Me.tabMonthly.Controls.Add(Me.btnViewData_Monthly)
        Me.tabMonthly.Controls.Add(Me.ChartsMonthly)
        Me.tabMonthly.Controls.Add(Me.lblMonthlyStartDT)
        Me.tabMonthly.Controls.Add(Me.lblMonthlyEndDT)
        Me.tabMonthly.Controls.Add(Me.Label13)
        Me.tabMonthly.Controls.Add(Me.Label4)
        Me.tabMonthly.Controls.Add(Me.btnRunMonthly)
        Me.tabMonthly.Controls.Add(Me.dtpMonthlyEndDT)
        Me.tabMonthly.Controls.Add(Me.dtpMonthlyStartDT)
        Me.tabMonthly.Location = New System.Drawing.Point(4, 22)
        Me.tabMonthly.Name = "tabMonthly"
        Me.tabMonthly.Size = New System.Drawing.Size(624, 443)
        Me.tabMonthly.TabIndex = 3
        Me.tabMonthly.Text = "Monthly"
        Me.tabMonthly.UseVisualStyleBackColor = True
        '
        'btnViewData_Monthly
        '
        Me.btnViewData_Monthly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewData_Monthly.Enabled = False
        Me.btnViewData_Monthly.Location = New System.Drawing.Point(541, 6)
        Me.btnViewData_Monthly.Name = "btnViewData_Monthly"
        Me.btnViewData_Monthly.Size = New System.Drawing.Size(75, 23)
        Me.btnViewData_Monthly.TabIndex = 25
        Me.btnViewData_Monthly.Text = "View Data"
        Me.btnViewData_Monthly.UseVisualStyleBackColor = True
        '
        'ChartsMonthly
        '
        Me.ChartsMonthly.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChartsMonthly.AutoScroll = True
        Me.ChartsMonthly.ColumnCount = 2
        Me.ChartsMonthly.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsMonthly.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsMonthly.Location = New System.Drawing.Point(9, 47)
        Me.ChartsMonthly.Name = "ChartsMonthly"
        Me.ChartsMonthly.RowCount = 2
        Me.ChartsMonthly.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsMonthly.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsMonthly.Size = New System.Drawing.Size(607, 400)
        Me.ChartsMonthly.TabIndex = 24
        '
        'lblMonthlyStartDT
        '
        Me.lblMonthlyStartDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthlyStartDT.Location = New System.Drawing.Point(63, 30)
        Me.lblMonthlyStartDT.Name = "lblMonthlyStartDT"
        Me.lblMonthlyStartDT.Size = New System.Drawing.Size(99, 13)
        Me.lblMonthlyStartDT.TabIndex = 23
        Me.lblMonthlyStartDT.Text = "Available"
        Me.lblMonthlyStartDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMonthlyEndDT
        '
        Me.lblMonthlyEndDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthlyEndDT.Location = New System.Drawing.Point(168, 30)
        Me.lblMonthlyEndDT.Name = "lblMonthlyEndDT"
        Me.lblMonthlyEndDT.Size = New System.Drawing.Size(99, 13)
        Me.lblMonthlyEndDT.TabIndex = 22
        Me.lblMonthlyEndDT.Text = "Available"
        Me.lblMonthlyEndDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Available"
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(6, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 16)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Range"
        '
        'btnRunMonthly
        '
        Me.btnRunMonthly.Location = New System.Drawing.Point(273, 6)
        Me.btnRunMonthly.Name = "btnRunMonthly"
        Me.btnRunMonthly.Size = New System.Drawing.Size(75, 23)
        Me.btnRunMonthly.TabIndex = 19
        Me.btnRunMonthly.Text = "Run"
        Me.btnRunMonthly.UseVisualStyleBackColor = True
        '
        'dtpMonthlyEndDT
        '
        Me.dtpMonthlyEndDT.CustomFormat = ""
        Me.dtpMonthlyEndDT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMonthlyEndDT.Location = New System.Drawing.Point(168, 7)
        Me.dtpMonthlyEndDT.Name = "dtpMonthlyEndDT"
        Me.dtpMonthlyEndDT.Size = New System.Drawing.Size(99, 20)
        Me.dtpMonthlyEndDT.TabIndex = 18
        '
        'dtpMonthlyStartDT
        '
        Me.dtpMonthlyStartDT.CustomFormat = ""
        Me.dtpMonthlyStartDT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMonthlyStartDT.Location = New System.Drawing.Point(63, 7)
        Me.dtpMonthlyStartDT.Name = "dtpMonthlyStartDT"
        Me.dtpMonthlyStartDT.Size = New System.Drawing.Size(99, 20)
        Me.dtpMonthlyStartDT.TabIndex = 17
        '
        'tabRaw
        '
        Me.tabRaw.Controls.Add(Me.btnViewData_Custom)
        Me.tabRaw.Controls.Add(Me.ChartsCustom)
        Me.tabRaw.Controls.Add(Me.btnRunCustom)
        Me.tabRaw.Controls.Add(Me.Label11)
        Me.tabRaw.Controls.Add(Me.cboCustomTimePeriods)
        Me.tabRaw.Controls.Add(Me.nudCustomFrequency)
        Me.tabRaw.Controls.Add(Me.chkCustomGrouped)
        Me.tabRaw.Controls.Add(Me.lblCustomStartDT)
        Me.tabRaw.Controls.Add(Me.lblCustomEndDT)
        Me.tabRaw.Controls.Add(Me.Label8)
        Me.tabRaw.Controls.Add(Me.Label9)
        Me.tabRaw.Controls.Add(Me.dtpCustomEndDT)
        Me.tabRaw.Controls.Add(Me.dtpCustomStartDT)
        Me.tabRaw.Location = New System.Drawing.Point(4, 22)
        Me.tabRaw.Name = "tabRaw"
        Me.tabRaw.Size = New System.Drawing.Size(624, 443)
        Me.tabRaw.TabIndex = 5
        Me.tabRaw.Text = "Custom"
        Me.tabRaw.UseVisualStyleBackColor = True
        '
        'btnViewData_Custom
        '
        Me.btnViewData_Custom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewData_Custom.Enabled = False
        Me.btnViewData_Custom.Location = New System.Drawing.Point(541, 9)
        Me.btnViewData_Custom.Name = "btnViewData_Custom"
        Me.btnViewData_Custom.Size = New System.Drawing.Size(75, 23)
        Me.btnViewData_Custom.TabIndex = 36
        Me.btnViewData_Custom.Text = "View Data"
        Me.btnViewData_Custom.UseVisualStyleBackColor = True
        '
        'ChartsCustom
        '
        Me.ChartsCustom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChartsCustom.AutoScroll = True
        Me.ChartsCustom.ColumnCount = 2
        Me.ChartsCustom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsCustom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsCustom.Location = New System.Drawing.Point(9, 86)
        Me.ChartsCustom.Name = "ChartsCustom"
        Me.ChartsCustom.RowCount = 2
        Me.ChartsCustom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsCustom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ChartsCustom.Size = New System.Drawing.Size(607, 351)
        Me.ChartsCustom.TabIndex = 35
        '
        'btnRunCustom
        '
        Me.btnRunCustom.Location = New System.Drawing.Point(437, 30)
        Me.btnRunCustom.Name = "btnRunCustom"
        Me.btnRunCustom.Size = New System.Drawing.Size(75, 23)
        Me.btnRunCustom.TabIndex = 34
        Me.btnRunCustom.Text = "Run"
        Me.btnRunCustom.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(346, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 16)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "intervals"
        '
        'cboCustomTimePeriods
        '
        Me.cboCustomTimePeriods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomTimePeriods.Enabled = False
        Me.cboCustomTimePeriods.FormattingEnabled = True
        Me.cboCustomTimePeriods.Location = New System.Drawing.Point(219, 49)
        Me.cboCustomTimePeriods.Name = "cboCustomTimePeriods"
        Me.cboCustomTimePeriods.Size = New System.Drawing.Size(121, 21)
        Me.cboCustomTimePeriods.TabIndex = 32
        '
        'nudCustomFrequency
        '
        Me.nudCustomFrequency.Enabled = False
        Me.nudCustomFrequency.Location = New System.Drawing.Point(148, 49)
        Me.nudCustomFrequency.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudCustomFrequency.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCustomFrequency.Name = "nudCustomFrequency"
        Me.nudCustomFrequency.Size = New System.Drawing.Size(62, 20)
        Me.nudCustomFrequency.TabIndex = 31
        Me.nudCustomFrequency.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkCustomGrouped
        '
        Me.chkCustomGrouped.AutoSize = True
        Me.chkCustomGrouped.Location = New System.Drawing.Point(63, 51)
        Me.chkCustomGrouped.Name = "chkCustomGrouped"
        Me.chkCustomGrouped.Size = New System.Drawing.Size(78, 17)
        Me.chkCustomGrouped.TabIndex = 30
        Me.chkCustomGrouped.Text = "Grouped in"
        Me.chkCustomGrouped.UseVisualStyleBackColor = True
        '
        'lblCustomStartDT
        '
        Me.lblCustomStartDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomStartDT.Location = New System.Drawing.Point(63, 30)
        Me.lblCustomStartDT.Name = "lblCustomStartDT"
        Me.lblCustomStartDT.Size = New System.Drawing.Size(99, 13)
        Me.lblCustomStartDT.TabIndex = 29
        Me.lblCustomStartDT.Text = "Available"
        Me.lblCustomStartDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomEndDT
        '
        Me.lblCustomEndDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomEndDT.Location = New System.Drawing.Point(168, 30)
        Me.lblCustomEndDT.Name = "lblCustomEndDT"
        Me.lblCustomEndDT.Size = New System.Drawing.Size(99, 13)
        Me.lblCustomEndDT.TabIndex = 28
        Me.lblCustomEndDT.Text = "Available"
        Me.lblCustomEndDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Available"
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.Location = New System.Drawing.Point(6, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 16)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Range"
        '
        'dtpCustomEndDT
        '
        Me.dtpCustomEndDT.CustomFormat = ""
        Me.dtpCustomEndDT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCustomEndDT.Location = New System.Drawing.Point(168, 7)
        Me.dtpCustomEndDT.Name = "dtpCustomEndDT"
        Me.dtpCustomEndDT.Size = New System.Drawing.Size(99, 20)
        Me.dtpCustomEndDT.TabIndex = 25
        '
        'dtpCustomStartDT
        '
        Me.dtpCustomStartDT.CustomFormat = ""
        Me.dtpCustomStartDT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCustomStartDT.Location = New System.Drawing.Point(63, 7)
        Me.dtpCustomStartDT.Name = "dtpCustomStartDT"
        Me.dtpCustomStartDT.Size = New System.Drawing.Size(99, 20)
        Me.dtpCustomStartDT.TabIndex = 24
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "polymon.chm"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblMonitorType)
        Me.Panel1.Controls.Add(Me.lblMonitor)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(636, 28)
        Me.Panel1.TabIndex = 4
        '
        'lblMonitorType
        '
        Me.lblMonitorType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMonitorType.BackColor = System.Drawing.Color.Transparent
        Me.lblMonitorType.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonitorType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMonitorType.Location = New System.Drawing.Point(323, 0)
        Me.lblMonitorType.Name = "lblMonitorType"
        Me.lblMonitorType.Size = New System.Drawing.Size(310, 30)
        Me.lblMonitorType.TabIndex = 6
        Me.lblMonitorType.Text = "Monitor Name"
        Me.lblMonitorType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMonitor
        '
        Me.lblMonitor.BackColor = System.Drawing.Color.Transparent
        Me.lblMonitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonitor.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMonitor.Location = New System.Drawing.Point(0, 0)
        Me.lblMonitor.Name = "lblMonitor"
        Me.lblMonitor.Size = New System.Drawing.Size(317, 28)
        Me.lblMonitor.TabIndex = 5
        Me.lblMonitor.Text = "Monitor Name"
        Me.lblMonitor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 507)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tctlReports)
        Me.HelpProvider1.SetHelpKeyword(Me, "39")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.MinimumSize = New System.Drawing.Size(652, 546)
        Me.Name = "frmReports"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Reports"
        Me.tctlReports.ResumeLayout(False)
        Me.tabOverview.ResumeLayout(False)
        Me.tabOverview.PerformLayout()
        Me.tabDaily.ResumeLayout(False)
        Me.tabDaily.PerformLayout()
        Me.tabWeekly.ResumeLayout(False)
        Me.tabWeekly.PerformLayout()
        Me.tabMonthly.ResumeLayout(False)
        Me.tabMonthly.PerformLayout()
        Me.tabRaw.ResumeLayout(False)
        Me.tabRaw.PerformLayout()
        CType(Me.nudCustomFrequency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tctlReports As System.Windows.Forms.TabControl
    Friend WithEvents tabOverview As System.Windows.Forms.TabPage
    Friend WithEvents tabDaily As System.Windows.Forms.TabPage
    Friend WithEvents tabWeekly As System.Windows.Forms.TabPage
    Friend WithEvents tabMonthly As System.Windows.Forms.TabPage
    Friend WithEvents tabRaw As System.Windows.Forms.TabPage
    Friend WithEvents lblLifetimePercUptime As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblStatusDate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFailure As System.Windows.Forms.Label
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents lblOK As System.Windows.Forms.Label
    Friend WithEvents btnRunDaily As System.Windows.Forms.Button
    Friend WithEvents dtpDailyEndDT As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDailyStartDT As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRunWeekly As System.Windows.Forms.Button
    Friend WithEvents dtpWeeklyEndDT As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpWeeklyStartDT As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRunMonthly As System.Windows.Forms.Button
    Friend WithEvents dtpMonthlyEndDT As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpMonthlyStartDT As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDailyStartDT As System.Windows.Forms.Label
    Friend WithEvents lblDailyEndDT As System.Windows.Forms.Label
    Friend WithEvents lblWeeklyStartDT As System.Windows.Forms.Label
    Friend WithEvents lblWeeklyEndDT As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblMonthlyStartDT As System.Windows.Forms.Label
    Friend WithEvents lblMonthlyEndDT As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ChartsOverview As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ChartsDaily As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ChartsWeekly As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ChartsMonthly As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkCustomGrouped As System.Windows.Forms.CheckBox
    Friend WithEvents lblCustomStartDT As System.Windows.Forms.Label
    Friend WithEvents lblCustomEndDT As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpCustomEndDT As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCustomStartDT As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboCustomTimePeriods As System.Windows.Forms.ComboBox
    Friend WithEvents nudCustomFrequency As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChartsCustom As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnRunCustom As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
	Friend WithEvents btnViewData_Daily As System.Windows.Forms.Button
	Friend WithEvents btnViewData_Weekly As System.Windows.Forms.Button
	Friend WithEvents btnViewData_Monthly As System.Windows.Forms.Button
	Friend WithEvents btnViewData_Custom As System.Windows.Forms.Button
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblMonitorType As System.Windows.Forms.Label
    Friend WithEvents lblMonitor As System.Windows.Forms.Label
End Class
