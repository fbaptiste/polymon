<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBrowser))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.btnRefreshCategories = New System.Windows.Forms.Button
        Me.lstCounters = New System.Windows.Forms.ListBox
        Me.lstInstances = New System.Windows.Forms.ListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblInstances = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(75, 13)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(340, 20)
        Me.txtHost.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Category"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(75, 52)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(340, 21)
        Me.cboCategory.Sorted = True
        Me.cboCategory.TabIndex = 1
        '
        'btnRefreshCategories
        '
        Me.btnRefreshCategories.FlatAppearance.BorderSize = 0
        Me.btnRefreshCategories.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnRefreshCategories.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnRefreshCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefreshCategories.Image = CType(resources.GetObject("btnRefreshCategories.Image"), System.Drawing.Image)
        Me.btnRefreshCategories.Location = New System.Drawing.Point(418, 52)
        Me.btnRefreshCategories.Name = "btnRefreshCategories"
        Me.btnRefreshCategories.Size = New System.Drawing.Size(20, 20)
        Me.btnRefreshCategories.TabIndex = 2
        Me.btnRefreshCategories.UseVisualStyleBackColor = True
        '
        'lstCounters
        '
        Me.lstCounters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCounters.FormattingEnabled = True
        Me.lstCounters.Location = New System.Drawing.Point(75, 100)
        Me.lstCounters.Name = "lstCounters"
        Me.lstCounters.Size = New System.Drawing.Size(180, 134)
        Me.lstCounters.Sorted = True
        Me.lstCounters.TabIndex = 3
        '
        'lstInstances
        '
        Me.lstInstances.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstInstances.FormattingEnabled = True
        Me.lstInstances.Location = New System.Drawing.Point(261, 100)
        Me.lstInstances.Name = "lstInstances"
        Me.lstInstances.Size = New System.Drawing.Size(180, 134)
        Me.lstInstances.Sorted = True
        Me.lstInstances.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(75, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Counters"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(150, 242)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(232, 242)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblInstances
        '
        Me.lblInstances.AutoSize = True
        Me.lblInstances.Location = New System.Drawing.Point(261, 84)
        Me.lblInstances.Name = "lblInstances"
        Me.lblInstances.Size = New System.Drawing.Size(53, 13)
        Me.lblInstances.TabIndex = 28
        Me.lblInstances.Text = "Instances"
        '
        'frmBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 277)
        Me.Controls.Add(Me.lblInstances)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lstInstances)
        Me.Controls.Add(Me.lstCounters)
        Me.Controls.Add(Me.btnRefreshCategories)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmBrowser"
        Me.Text = "Performance Counters Browser"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefreshCategories As System.Windows.Forms.Button
    Friend WithEvents lstCounters As System.Windows.Forms.ListBox
    Friend WithEvents lstInstances As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblInstances As System.Windows.Forms.Label
End Class
