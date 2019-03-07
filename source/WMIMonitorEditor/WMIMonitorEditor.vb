Imports System.Xml
Imports System.Text

Public Class WMIMonitorEditor

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

#Region "Private"

	Private Sub InitForm()
		With Me.cboFailureOperator
			.Items.Clear()
			.Items.Add("<")
			.Items.Add(">")
			.SelectedIndex = 0
		End With

		With Me.cboWarningOperator
			.Items.Clear()
			.Items.Add("<")
			.Items.Add(">")
			.SelectedIndex = 0
		End With
	End Sub

	Private Sub LoadXMLValues(ByVal XML As String)
		'Get default data from XML template (mXMLTemplate)
		Dim XMLDoc As New XmlDocument

		If String.IsNullOrEmpty(XML) Then
			txtHost.Text = Nothing
			txtMonitorQuery.Text = Nothing
			chkEnableFailure.Checked = False
			chkEnableWarning.Checked = False
			nudFailureCount.Value = nudFailureCount.Minimum
			nudWarningCount.Value = nudWarningCount.Minimum
		Else
			XMLDoc.LoadXml(XML)
			Dim QueryString As String = Nothing
			Dim EnableFailures As Boolean = False
			Dim FailureOperator As String = Nothing
			Dim FailureValue As Double = 0
			Dim EnableWarnings As Boolean = False
			Dim WarningOperator As String = Nothing
			Dim WarningValue As Double = 0


			Dim RootNode As XmlNode = XMLDoc.DocumentElement
			Dim NodeValue As String

			Try
				'Host
				txtHost.Text = ReadXMLNodeValue(RootNode.SelectSingleNode("Host"))

				'MonitorQueryString
				txtMonitorQuery.Text = ReadXMLNodeValue(RootNode.SelectSingleNode("MonitorQuery"))

				'CounterQueryString
				txtCounterQuery.Text = ReadXMLNodeValue(RootNode.SelectSingleNode("CounterQuery"))

				'Enable Failures
				NodeValue = Me.ReadXMLAttributeValue(RootNode.SelectSingleNode("Failure").Attributes("Enable"))
				chkEnableFailure.Checked = CBool(IIf(NodeValue Is Nothing, 0, NodeValue))

				'Failure Operator
				NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("Failure").Attributes("Operator"))
				If NodeValue <> "<" AndAlso NodeValue <> ">" Then
					cboFailureOperator.SelectedIndex = 0
				Else
					cboFailureOperator.SelectedItem = NodeValue
				End If

				'Failure Count
				NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("Failure").Attributes("Value"))
				If Not (String.IsNullOrEmpty(NodeValue)) AndAlso (IsNumeric(NodeValue)) Then
					nudFailureCount.Value = CInt(NodeValue)
				End If

				'Enable Warnings
				NodeValue = Me.ReadXMLAttributeValue(RootNode.SelectSingleNode("Warning").Attributes("Enable"))
				chkEnableWarning.Checked = CBool(IIf(NodeValue Is Nothing, 0, NodeValue))

				'Warning Operator
				NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("Warning").Attributes("Operator"))
				If NodeValue <> "<" AndAlso NodeValue <> ">" Then
					cboWarningOperator.SelectedIndex = 0
				Else
					cboWarningOperator.SelectedItem = NodeValue
				End If

				'Warning Count
				NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("Warning").Attributes("Value"))
				If Not (String.IsNullOrEmpty(NodeValue)) AndAlso (IsNumeric(NodeValue)) Then
					nudWarningCount.Value = CInt(NodeValue)
				End If
			Catch ex As Exception
			End Try
		End If
	End Sub
	Private Function BuildXMLParams() As String
		Dim s As New StringBuilder

		s.Append("<WMIMonitor>" & vbCrLf)
		s.AppendFormat(vbTab & "<Host>{0}</Host>" & vbCrLf, txtHost.Text)
		s.AppendFormat(vbTab & "<MonitorQuery><![CDATA[{0}]]></MonitorQuery>" & vbCrLf, txtMonitorQuery.Text)
		s.AppendFormat(vbTab & "<CounterQuery><![CDATA[{0}]]></CounterQuery>" & vbCrLf, txtCounterQuery.Text)
		s.AppendFormat(vbTab & "<Failure Enable=""{0}"" Operator=""{1}"" Value=""{2}""/>" & vbCrLf, CStr(IIf(chkEnableFailure.Checked, "1", "0")), XMLEncode(CStr(cboFailureOperator.SelectedItem)), nudFailureCount.Value)
		s.AppendFormat(vbTab & "<Warning Enable=""{0}"" Operator=""{1}"" Value=""{2}""/>" & vbCrLf, CStr(IIf(chkEnableWarning.Checked, "1", "0")), XMLEncode(CStr(cboWarningOperator.SelectedItem)), nudWarningCount.Value)
		s.Append("</WMIMonitor>")

		Return s.ToString()
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
#End Region

	Private Sub btnMonitorQueryBuilder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonitorQueryBuilder.Click
		Dim WMIBrowser As New frmWMIBrowser(txtHost.Text, txtMonitorQuery.Text)
		Dim ret As System.Windows.Forms.DialogResult = WMIBrowser.ShowDialog()
		If ret = Windows.Forms.DialogResult.OK Then
			'Pull data back from dialog
			Dim QueryString As String = WMIBrowser.Query()
			If Not String.IsNullOrEmpty(QueryString) Then
				Me.txtMonitorQuery.Text = QueryString
			End If
		End If
	End Sub

	Private Sub btnCounterQueryBuilder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCounterQueryBuilder.Click
		Dim WMIBrowser As New frmWMIBrowser(txtHost.Text, txtCounterQuery.Text)
		Dim ret As System.Windows.Forms.DialogResult = WMIBrowser.ShowDialog()
		If ret = Windows.Forms.DialogResult.OK Then
			'Pull data back from dialog
			Dim QueryString As String = WMIBrowser.Query()
			If Not String.IsNullOrEmpty(QueryString) Then
				Me.txtCounterQuery.Text = QueryString
			End If
		End If
	End Sub

	Private Function XMLEncode(ByVal XMLString As String) As String
		If XMLString Is Nothing Then
			Return Nothing
		Else
			Dim tmpStr As String = XMLString

			tmpStr = tmpStr.Replace("&", "&amp;")
			tmpStr = tmpStr.Replace("<", "&lt;")
			tmpStr = tmpStr.Replace(">", "&gt;")
			tmpStr = tmpStr.Replace("""", "&quot;")
			tmpStr = tmpStr.Replace("'", "&apos;")

			Return tmpStr
		End If
	End Function
End Class
