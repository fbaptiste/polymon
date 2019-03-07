Imports System.Xml
Imports System.Text

Public Class CPUMonitorEditor

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
		End Set
	End Property
	Public Overrides Property XMLSettings() As String
		Get
			Return BuildXMLParams()
		End Get
		Set(ByVal value As String)
			LoadXMLValues(value)
		End Set
	End Property
	Public Overrides Sub LoadTemplateDefaults()
		LoadXMLValues(mXMLTemplate)
	End Sub
#End Region


	Private Sub LoadXMLValues(ByVal XML As String)
		Dim XMLDoc As New XmlDocument

		If XML Is Nothing OrElse XML.Trim.Length = 0 Then
			InitForm()
		Else
			XMLDoc.LoadXml(XML)
			Dim RootNode As XmlNode = XMLDoc.DocumentElement

			Dim Value As String
			Dim XMLNode As XmlNode = Nothing
			Dim XMLAttribute As XmlAttribute = Nothing

			'Host
			txtHost.Text = ReadXMLNodeValue(RootNode.SelectSingleNode("Host"))

			'Fail (Enabled/Type/Value)
			XMLNode = RootNode.SelectSingleNode("Fail")
			Value = ReadXMLAttributeValue(XMLNode.Attributes("Enabled"))
			If String.IsNullOrEmpty(Value) Then
				Me.chkFail.Checked = False
			Else
				Me.chkFail.Checked = MakeBoolean(Value)
			End If
			Value = ReadXMLAttributeValue(XMLNode.Attributes("Type"))
			If String.IsNullOrEmpty(Value) OrElse Value.Trim.ToUpper <> "ANY" Then
				Me.cboFailType.Text = "Total"
			Else
				Me.cboFailType.Text = Value.Trim()
			End If
			Value = XMLNode.InnerText
			If String.IsNullOrEmpty(Value) OrElse Not (IsNumeric(Value)) Then
				Me.nudFailValue.Value = 0
			ElseIf CInt(Value) < 0 Then
				Me.nudFailValue.Value = 0
			ElseIf CInt(Value) > 100 Then
				Me.nudFailValue.Value = 100
			Else
				Me.nudFailValue.Value = CInt(Value)
			End If

			'Warning (Enabled/Type/Value)
			XMLNode = RootNode.SelectSingleNode("Warn")
			Value = ReadXMLAttributeValue(XMLNode.Attributes("Enabled"))
			If String.IsNullOrEmpty(Value) Then
				Me.chkWarn.Checked = False
			Else
				Me.chkWarn.Checked = MakeBoolean(Value)
			End If
			Value = ReadXMLAttributeValue(XMLNode.Attributes("Type"))
			If String.IsNullOrEmpty(Value) OrElse Value.Trim.ToUpper <> "ANY" Then
				Me.cboWarnType.Text = "Total"
			Else
				Me.cboWarnType.Text = Value.Trim()
			End If
			Value = XMLNode.InnerText
			If String.IsNullOrEmpty(Value) OrElse Not (IsNumeric(Value)) Then
				Me.nudWarnValue.Value = 0
			ElseIf CInt(Value) < 0 Then
				Me.nudWarnValue.Value = 0
			ElseIf CInt(Value) > 100 Then
				Me.nudWarnValue.Value = 100
			Else
				Me.nudWarnValue.Value = CInt(Value)
			End If

			XMLNode = Nothing
		End If
	End Sub
	Private Function BuildXMLParams() As String
		Dim s As New StringBuilder

		s.Append("<CPUMonitor>" & vbCrLf)

		s.AppendFormat(vbTab & "<Host>{0}</Host>" & vbCrLf, txtHost.Text)
		s.AppendFormat(vbTab & "<Fail Enabled='{0}' Type='{1}'>{2}</Fail>" & vbCrLf, Me.chkFail.Checked, Me.cboFailType.Text, Me.nudFailValue.Value)
		s.AppendFormat(vbTab & "<Warn Enabled='{0}' Type='{1}'>{2}</Warn>" & vbCrLf, Me.chkWarn.Checked, Me.cboWarnType.Text, Me.nudWarnValue.Value)
		s.Append("</CPUMonitor>")

		Return s.ToString()
	End Function

	Private Function MakeBoolean(ByVal Value As String) As Boolean
		Try
			Return CBool(Value)
		Catch ex As Exception
			Return False
		End Try
	End Function
	Private Function ReadXMLNodeValue(ByVal myXMLNode As XmlNode) As String
		If myXMLNode Is Nothing Then
			Return Nothing
		Else
			If myXMLNode Is Nothing OrElse myXMLNode.InnerText = Nothing Then
				Return Nothing
			Else
				Return myXMLNode.InnerText.Trim()
			End If
		End If
	End Function
	Private Function ReadXMLAttributeValue(ByVal myXMLAttribute As XmlAttribute) As String
		If myXMLAttribute Is Nothing Then
			Return Nothing
		Else
			If myXMLAttribute.Value Is Nothing OrElse myXMLAttribute.Value.Trim() = "" Then
				Return Nothing
			Else
				Return myXMLAttribute.Value.Trim()
			End If
		End If
	End Function


	Private Sub InitForm()
		With cboWarnType
			.Items.Clear()
			.Items.Add("Total")
			.Items.Add("Any")
			.SelectedIndex = 0
		End With
		With cboFailType
			.Items.Clear()
			.Items.Add("Total")
			.Items.Add("Any")
			.SelectedIndex = 0
		End With
		Me.chkFail.Checked = False
		SetFailState(False)

		Me.chkWarn.Checked = False
		SetWarnState(False)
	End Sub

	Private Sub chkWarn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWarn.CheckedChanged
		SetWarnState(Me.chkWarn.Checked)
	End Sub

	Private Sub chkFail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFail.CheckedChanged
		SetFailState(Me.chkFail.Checked)
	End Sub

	Private Sub SetWarnState(ByVal Enabled As Boolean)
		Me.cboWarnType.Enabled = Enabled
		Me.nudWarnValue.Enabled = Enabled
	End Sub
	Private Sub SetFailState(ByVal Enabled As Boolean)
		Me.cboFailType.Enabled = Enabled
		Me.nudFailValue.Enabled = Enabled
	End Sub
End Class
