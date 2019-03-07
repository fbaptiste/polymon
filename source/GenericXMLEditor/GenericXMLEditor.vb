Public Class GenericXMLEditor

#Region "Private Attributes"
    Private mXMLTemplate As String
#End Region

#Region "Public Interface"
	Public Sub New()

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		InitForm()
	End Sub
	Public Overrides Property XMLTemplate() As String
		Get
			Return mXMLTemplate
		End Get
		Set(ByVal value As String)
			mXMLTemplate = value
			If mXMLTemplate = Nothing OrElse mXMLTemplate.Length = 0 Then
				Me.tbtnLoadTemplate.Enabled = False
			Else
				Me.tbtnLoadTemplate.Enabled = True
			End If
		End Set
	End Property
	Public Overrides Property XMLSettings() As String
		Get
			Return Me.txtXMLSettings.Text
		End Get
		Set(ByVal value As String)
			Me.txtXMLSettings.Text = value
		End Set
	End Property
	Public Overrides Sub LoadTemplateDefaults()
		Me.txtXMLSettings.Text = mXMLTemplate
	End Sub
#End Region

#Region "Event Handlers"
	Private Sub InitForm()
		With Me.tcbFontSize
			.Items.Clear()
			.Items.Add("8.25 pt")
			.Items.Add("9 pt")
			.Items.Add("10 pt")
			.Items.Add("11 pt")
			.Items.Add("12 pt")
			.Items.Add("14 pt")
			.Items.Add("16 pt")
			.SelectedIndex = 2
		End With
	End Sub
    Private Sub tbtnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnUndo.Click
        If txtXMLSettings.CanUndo Then
            txtXMLSettings.Undo()
        End If
    End Sub
    Private Sub tbtnLoadTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnLoadTemplate.Click
        txtXMLSettings.SelectAll()
        Clipboard.SetText(mXMLTemplate)
        Me.txtXMLSettings.Paste()
    End Sub
    Private Sub tbtnRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRedo.Click
        If txtXMLSettings.CanRedo Then
            txtXMLSettings.Redo()
        End If
    End Sub
    Private Sub tcbFontSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcbFontSize.SelectedIndexChanged
        Dim emSize As Single
        Dim FontSize As String
        FontSize = CStr(Me.tcbFontSize.SelectedItem).Trim
        emSize = CSng(FontSize.Substring(0, FontSize.Length - 3))
        Me.txtXMLSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", emSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    End Sub
#End Region
End Class
