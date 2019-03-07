<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPolyMonExecutive
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPolyMonExecutive))
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pcbExecutiveStatus = New System.Windows.Forms.PictureBox()
        Me.btnExecutiveStatusRefresh = New System.Windows.Forms.Button()
        Me.lblExecutiveStatus = New System.Windows.Forms.Label()
        Me.btnExecutiveStop = New System.Windows.Forms.Button()
        Me.btnExecutiveStart = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblPath = New System.Windows.Forms.TextBox()
        Me.lblLogOnAs = New System.Windows.Forms.Label()
        Me.lblStartupType = New System.Windows.Forms.Label()
        Me.lblServiceHost = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pcbExecutiveStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "polymon.chm"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.pcbExecutiveStatus)
        Me.GroupBox1.Controls.Add(Me.btnExecutiveStatusRefresh)
        Me.GroupBox1.Controls.Add(Me.lblExecutiveStatus)
        Me.GroupBox1.Controls.Add(Me.btnExecutiveStop)
        Me.GroupBox1.Controls.Add(Me.btnExecutiveStart)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(382, 154)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Service Control"
        '
        'pcbExecutiveStatus
        '
        Me.pcbExecutiveStatus.Location = New System.Drawing.Point(6, 19)
        Me.pcbExecutiveStatus.Name = "pcbExecutiveStatus"
        Me.pcbExecutiveStatus.Size = New System.Drawing.Size(32, 32)
        Me.pcbExecutiveStatus.TabIndex = 10
        Me.pcbExecutiveStatus.TabStop = False
        '
        'btnExecutiveStatusRefresh
        '
        Me.btnExecutiveStatusRefresh.Image = Global.PolyMonManager.My.Resources.Resources.Refresh
        Me.btnExecutiveStatusRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExecutiveStatusRefresh.Location = New System.Drawing.Point(298, 57)
        Me.btnExecutiveStatusRefresh.Name = "btnExecutiveStatusRefresh"
        Me.btnExecutiveStatusRefresh.Size = New System.Drawing.Size(72, 28)
        Me.btnExecutiveStatusRefresh.TabIndex = 12
        Me.btnExecutiveStatusRefresh.Text = "Refresh"
        Me.btnExecutiveStatusRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblExecutiveStatus
        '
        Me.lblExecutiveStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblExecutiveStatus.Location = New System.Drawing.Point(46, 61)
        Me.lblExecutiveStatus.Name = "lblExecutiveStatus"
        Me.lblExecutiveStatus.Size = New System.Drawing.Size(232, 20)
        Me.lblExecutiveStatus.TabIndex = 11
        '
        'btnExecutiveStop
        '
        Me.btnExecutiveStop.Location = New System.Drawing.Point(193, 115)
        Me.btnExecutiveStop.Name = "btnExecutiveStop"
        Me.btnExecutiveStop.Size = New System.Drawing.Size(88, 24)
        Me.btnExecutiveStop.TabIndex = 14
        Me.btnExecutiveStop.Text = "Stop Service"
        '
        'btnExecutiveStart
        '
        Me.btnExecutiveStart.Location = New System.Drawing.Point(85, 115)
        Me.btnExecutiveStart.Name = "btnExecutiveStart"
        Me.btnExecutiveStart.Size = New System.Drawing.Size(88, 24)
        Me.btnExecutiveStart.TabIndex = 13
        Me.btnExecutiveStart.Text = "Start Service"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lblPath)
        Me.GroupBox2.Controls.Add(Me.lblLogOnAs)
        Me.GroupBox2.Controls.Add(Me.lblStartupType)
        Me.GroupBox2.Controls.Add(Me.lblServiceHost)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 173)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(382, 132)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Service Details"
        '
        'lblPath
        '
        Me.lblPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPath.Location = New System.Drawing.Point(114, 51)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.ReadOnly = True
        Me.lblPath.Size = New System.Drawing.Size(256, 20)
        Me.lblPath.TabIndex = 8
        '
        'lblLogOnAs
        '
        Me.lblLogOnAs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLogOnAs.AutoEllipsis = True
        Me.lblLogOnAs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLogOnAs.Location = New System.Drawing.Point(115, 103)
        Me.lblLogOnAs.Name = "lblLogOnAs"
        Me.lblLogOnAs.Size = New System.Drawing.Size(256, 20)
        Me.lblLogOnAs.TabIndex = 7
        Me.lblLogOnAs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStartupType
        '
        Me.lblStartupType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStartupType.AutoEllipsis = True
        Me.lblStartupType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStartupType.Location = New System.Drawing.Point(115, 77)
        Me.lblStartupType.Name = "lblStartupType"
        Me.lblStartupType.Size = New System.Drawing.Size(256, 20)
        Me.lblStartupType.TabIndex = 6
        Me.lblStartupType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblServiceHost
        '
        Me.lblServiceHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblServiceHost.AutoEllipsis = True
        Me.lblServiceHost.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblServiceHost.Location = New System.Drawing.Point(115, 25)
        Me.lblServiceHost.Name = "lblServiceHost"
        Me.lblServiceHost.Size = New System.Drawing.Size(256, 20)
        Me.lblServiceHost.TabIndex = 4
        Me.lblServiceHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(13, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Logon as"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(13, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Startup Type"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(13, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Path to executable"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(13, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Service Host"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmPolyMonExecutive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 319)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "18")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TopicId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPolyMonExecutive"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "PolyMon Executive"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.pcbExecutiveStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pcbExecutiveStatus As System.Windows.Forms.PictureBox
    Friend WithEvents btnExecutiveStatusRefresh As System.Windows.Forms.Button
    Friend WithEvents lblExecutiveStatus As System.Windows.Forms.Label
    Friend WithEvents btnExecutiveStop As System.Windows.Forms.Button
    Friend WithEvents btnExecutiveStart As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPath As System.Windows.Forms.TextBox
    Friend WithEvents lblLogOnAs As System.Windows.Forms.Label
    Friend WithEvents lblStartupType As System.Windows.Forms.Label
    Friend WithEvents lblServiceHost As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
