Imports System.Xml
Imports System.Text

Public Class SNMPMonitorEditor

#Region "Private Attributes"
    Private mXMLTemplate As String
#End Region

#Region "Public Interface"
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

#Region "Form Events"
	Public Sub New()

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		InitForm()
	End Sub
	Private Sub chkWarning_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWarning.CheckedChanged
		SetWarnState(Me.chkWarning.Checked)
	End Sub
	Private Sub chkFailure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFailure.CheckedChanged
		SetFailState(Me.chkFailure.Checked)
	End Sub
#End Region

#Region "Private Methods"
	Private Sub InitForm()
		txtHost.Text = Nothing
		txtPort.Text = Nothing
		txtReadCommunity.Text = Nothing
		txtOID.Text = Nothing
		numTimeout.Value = 1

		With cboFailDataType
			.Items.Clear()
			.Items.Add("Numeric")
			.Items.Add("String")
			.SelectedIndex = 0
		End With

		With cboFailComparison
			.Items.Clear()
			.Items.Add("<")
			.Items.Add("<=")
			.Items.Add(">")
			.Items.Add(">=")
			.Items.Add("=")
			.Items.Add("<>")
			.SelectedIndex = 0
		End With

		With cboWarnDataType
			.Items.Clear()
			.Items.Add("Numeric")
			.Items.Add("String")
			.SelectedIndex = 0
		End With

		With cboWarnComparison
			.Items.Clear()
			.Items.Add("<")
			.Items.Add("<=")
			.Items.Add(">")
			.Items.Add(">=")
			.Items.Add("=")
			.Items.Add("<>")
			.SelectedIndex = 0
		End With

		Me.chkWarning.Checked = False
		Me.chkFailure.Checked = False
		SetWarnState(False)
		SetFailState(False)
	End Sub

	Private Sub SetWarnState(ByVal IsEnabled As Boolean)
		Me.cboWarnComparison.Enabled = IsEnabled
		Me.cboWarnDataType.Enabled = IsEnabled
		Me.txtWarnThresholdValue.Enabled = IsEnabled
	End Sub
	Private Sub SetFailState(ByVal IsEnabled As Boolean)
		Me.cboFailComparison.Enabled = IsEnabled
		Me.cboFailDataType.Enabled = IsEnabled
		Me.txtFailThresholdValue.Enabled = IsEnabled
	End Sub

	Private Sub LoadXMLValues(ByVal XML As String)
		'Get default data from XML template (mXMLTemplate)
		Dim XMLDoc As New XmlDocument

		If XML Is Nothing OrElse XML.Trim.Length = 0 Then
			InitForm()
		Else
			XMLDoc.LoadXml(XML)
			Dim RootNode As XmlNode = XMLDoc.DocumentElement

			Dim XMLNode As XmlNode = Nothing
			Dim XMLAttribute As XmlAttribute = Nothing

			'Host
			XMLNode = RootNode.SelectSingleNode("Host")
			txtHost.Text = CStr(XMLNode.InnerText).Trim()
			XMLNode = Nothing

			'Port
			XMLNode = RootNode.SelectSingleNode("Port")
			txtPort.Text = CStr(XMLNode.InnerText).Trim()
			XMLNode = Nothing

			'ReadCommunity
			XMLNode = RootNode.SelectSingleNode("ReadCommunity")
			txtReadCommunity.Text = CStr(XMLNode.InnerText).Trim()
			XMLNode = Nothing

			'OID
			XMLNode = RootNode.SelectSingleNode("OID")
			txtOID.Text = CStr(XMLNode.InnerText).Trim()
			XMLNode = Nothing

			'Timeout
			XMLNode = RootNode.SelectSingleNode("Timeout")
			If XMLNode Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText)) Then
				numTimeout.Value = 1
			Else
				Dim Timeout As Integer
				Timeout = CInt(XMLNode.InnerText)
				If Timeout < numTimeout.Minimum Then Timeout = CInt(numTimeout.Minimum)
				If Timeout > numTimeout.Maximum Then Timeout = CInt(numTimeout.Maximum)
				numTimeout.Value = Timeout
			End If
			XMLNode = Nothing

			'Fail Threshold Node (2 Attributes + Node value)
			'Threshold: DataType
			XMLNode = RootNode.SelectSingleNode("Threshold")

			If Not (XMLNode Is Nothing) Then
				'Enabled
				XMLAttribute = XMLNode.Attributes("Enabled")
				If XMLAttribute Is Nothing OrElse XMLAttribute.Value Is Nothing OrElse CInt(XMLAttribute.Value) = 0 Then
					Me.chkFailure.Checked = False
				Else
					Me.chkFailure.Checked = True
				End If

				'Data Type
				XMLAttribute = XMLNode.Attributes("DataType")
				If XMLAttribute Is Nothing OrElse XMLAttribute.Value Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
					'Default to String datatype
					cboFailDataType.SelectedIndex = 1
				Else
					Dim DataType As String = XMLAttribute.Value.Trim
					Dim CBOIndex As Integer = cboFailDataType.FindStringExact(DataType)
					If CBOIndex < 0 Then
						'default to String datatype
						cboFailDataType.SelectedIndex = 1
					Else
						cboFailDataType.SelectedIndex = CBOIndex
					End If
				End If

				'Threshold: Comparison
				XMLAttribute = XMLNode.Attributes("Comparison")
				If XMLAttribute Is Nothing OrElse XMLAttribute.Value Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
					'Default to < comparison
					cboFailComparison.SelectedIndex = 0
				Else
					Dim Comparison As String = XMLAttribute.Value.Trim
					Dim CBOIndex As Integer = cboFailComparison.FindStringExact(Comparison)
					If CBOIndex < 0 Then
						'default to String datatype
						cboFailComparison.SelectedIndex = 1
					Else
						cboFailComparison.SelectedIndex = CBOIndex
					End If
				End If

				'Threshold: Value
				txtFailThresholdValue.Text = XMLNode.InnerText
			Else
				'Node does not exist...
				Me.chkFailure.Checked = False
				cboFailDataType.SelectedIndex = 1
				cboFailComparison.SelectedIndex = 0
				txtFailThresholdValue.Text = Nothing
			End If

			'Warn Threshold Node (2 Attributes + Node value)
			'Threshold: DataType
			XMLNode = RootNode.SelectSingleNode("WarnThreshold")

			If Not (XMLNode Is Nothing) Then
				'Enabled
				XMLAttribute = XMLNode.Attributes("Enabled")
				If XMLAttribute Is Nothing OrElse XMLAttribute.Value Is Nothing OrElse CInt(XMLAttribute.Value) = 0 Then
					Me.chkWarning.Checked = False
				Else
					Me.chkWarning.Checked = True
				End If

				'Data Type
				XMLAttribute = XMLNode.Attributes("DataType")
				If XMLAttribute Is Nothing OrElse XMLAttribute.Value Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
					'Default to String datatype
					cboWarnDataType.SelectedIndex = 1
				Else
					Dim DataType As String = XMLAttribute.Value.Trim
					Dim CBOIndex As Integer = cboWarnDataType.FindStringExact(DataType)
					If CBOIndex < 0 Then
						'default to String datatype
						cboWarnDataType.SelectedIndex = 1
					Else
						cboWarnDataType.SelectedIndex = CBOIndex
					End If
				End If

				'Threshold: Comparison
				XMLAttribute = XMLNode.Attributes("Comparison")
				If XMLAttribute Is Nothing OrElse XMLAttribute.Value Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
					'Default to < comparison
					cboWarnComparison.SelectedIndex = 0
				Else
					Dim Comparison As String = XMLAttribute.Value.Trim
					Dim CBOIndex As Integer = cboWarnComparison.FindStringExact(Comparison)
					If CBOIndex < 0 Then
						'default to String datatype
						cboWarnComparison.SelectedIndex = 1
					Else
						cboWarnComparison.SelectedIndex = CBOIndex
					End If
				End If

				'Threshold: Value
				txtWarnThresholdValue.Text = XMLNode.InnerText
			Else
				'Node does not exist...
				Me.chkWarning.Checked = False
				cboWarnDataType.SelectedIndex = 1
				cboWarnComparison.SelectedIndex = 0
				txtWarnThresholdValue.Text = Nothing
			End If

		End If
	End Sub
	Private Function BuildXMLParams() As String
		Dim s As New StringBuilder

		s.Append("<SNMPMonitor>" & vbCrLf)
		s.Append(vbTab & "<Host>" & txtHost.Text & "</Host>" & vbCrLf)
		s.Append(vbTab & "<Port>" & txtPort.Text & "</Port>" & vbCrLf)
		s.Append(vbTab & "<ReadCommunity>" & txtReadCommunity.Text & "</ReadCommunity>" & vbCrLf)
		s.Append(vbTab & "<OID>" & txtOID.Text & "</OID>" & vbCrLf)
		s.Append(vbTab & "<Timeout>" & numTimeout.Value & "</Timeout>" & vbCrLf)
		s.Append(vbTab & "<Threshold")
		s.Append(vbTab & " Enabled='" & CStr(IIf(chkFailure.Checked, "1", "0")) & "'")
		s.Append(" DataType='" & CStr(cboFailDataType.SelectedItem) & "'")
		s.Append(" Comparison='" & XMLEncode(CStr(cboFailComparison.SelectedItem)) & "'>")
		s.Append(XMLEncode(txtFailThresholdValue.Text))
		s.Append("</Threshold>")
		s.Append(vbTab & "<WarnThreshold")
		s.Append(vbTab & " Enabled='" & CStr(IIf(chkWarning.Checked, "1", "0")) & "'")
		s.Append(" DataType='" & CStr(cboWarnDataType.SelectedItem) & "'")
		s.Append(" Comparison='" & XMLEncode(CStr(cboWarnComparison.SelectedItem)) & "'>")
		s.Append(XMLEncode(txtWarnThresholdValue.Text))
		s.Append("</WarnThreshold>")
		s.Append("</SNMPMonitor>")

		Return s.ToString()
	End Function
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
#End Region


End Class
