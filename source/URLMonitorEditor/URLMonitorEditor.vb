'Enhancements contributed by Rod Sawers: 10/25/2006

Imports System.Xml
Imports System.Text

Public Class URLMonitorEditor

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

#Region "Private Methods"
    Private Sub InitForm()
        chkWarnTimeout.Checked = False
        chkFailContent.Checked = False
        chkWarnContent.Checked = False

        cboFailNegated.SelectedIndex = 0
        cboWarnNegated.SelectedIndex = 0

        numWarnTimeout.Enabled = False
        txtFailContent.Enabled = False
        txtWarnContent.Enabled = False

        cboFailNegated.Enabled = False
        cboWarnNegated.Enabled = False

        txtURL.Text = Nothing
        numFailTimeout.Value = 1
        numWarnTimeout.Value = 1
        txtFailContent.Text = Nothing
        txtWarnContent.Text = Nothing
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

            'URL
            XMLNode = RootNode.SelectSingleNode("URL")
            txtURL.Text = CStr(XMLNode.InnerText).Trim()
            XMLNode = Nothing

            'Fail Timeout
            XMLNode = RootNode.SelectSingleNode("Timeout")
            If XMLNode Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText)) Then
                numFailTimeout.Value = 1
            Else
                Dim Timeout As Integer
                Timeout = CInt(XMLNode.InnerText)
                If Timeout < numFailTimeout.Minimum Then Timeout = CInt(numFailTimeout.Minimum)
                If Timeout > numFailTimeout.Maximum Then Timeout = CInt(numFailTimeout.Maximum)
                numFailTimeout.Value = Timeout
            End If
            XMLNode = Nothing

            'Warn Timeout
            XMLNode = RootNode.SelectSingleNode("WarnLoadTime")
            If XMLNode Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText)) Then
                chkWarnTimeout.Checked = False
                numWarnTimeout.Value = CInt(numWarnTimeout.Minimum)
            Else
                XMLAttribute = XMLNode.Attributes("Enabled")
                If XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
                    chkWarnTimeout.Checked = False
                Else
                    chkWarnTimeout.Checked = CBool(XMLAttribute.Value)
                End If
                Dim Timeout As Integer
                Timeout = CInt(XMLNode.InnerText)
                If Timeout < numWarnTimeout.Minimum Then Timeout = CInt(numWarnTimeout.Minimum)
                If Timeout > numWarnTimeout.Maximum Then Timeout = CInt(numWarnTimeout.Maximum)
                numWarnTimeout.Value = Timeout
            End If
            numWarnTimeout.Enabled = chkWarnTimeout.Checked
            XMLNode = Nothing


            'Fail Check Content
            XMLNode = RootNode.SelectSingleNode("FailCheckContent")
            If XMLNode Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 Then
                chkFailContent.Checked = False
                cboFailNegated.SelectedIndex = 0
                txtFailContent.Text = Nothing
            Else
                XMLAttribute = XMLNode.Attributes("Enabled")
                If XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
                    chkFailContent.Checked = False
                Else
                    chkFailContent.Checked = CBool(XMLAttribute.Value)
                End If
                XMLAttribute = XMLNode.Attributes("Negated")
                If XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
                    cboFailNegated.SelectedIndex = 0
                Else
                    cboFailNegated.SelectedIndex = CInt(XMLAttribute.Value)
                End If
                txtFailContent.Text = XMLNode.InnerText.Trim()
            End If
            txtFailContent.Enabled = chkFailContent.Checked
            XMLNode = Nothing

            'Warn Check Content
            XMLNode = RootNode.SelectSingleNode("WarnCheckContent")
            If XMLNode Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 Then
                chkWarnContent.Checked = False
                cboWarnNegated.SelectedIndex = 0
                txtWarnContent.Text = Nothing
            Else
                XMLAttribute = XMLNode.Attributes("Enabled")
                If XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
                    chkWarnContent.Checked = False
                Else
                    chkWarnContent.Checked = CBool(XMLAttribute.Value)
                End If
                XMLAttribute = XMLNode.Attributes("Negated")
                If XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
                    cboWarnNegated.SelectedIndex = 0
                Else
                    cboWarnNegated.SelectedIndex = CInt(XMLAttribute.Value)
                End If
                txtWarnContent.Text = XMLNode.InnerText.Trim()
            End If
            txtWarnContent.Enabled = chkWarnContent.Checked
            XMLNode = Nothing
        End If
    End Sub
    Private Function BuildXMLParams() As String
        Dim s As New StringBuilder

        s.Append("<URLMonitor>" & vbCrLf)
        s.Append(vbTab & "<URL>" & XMLEncode(txtURL.Text.Trim()) & "</URL>" & vbCrLf)
        s.Append(vbTab & "<Timeout>" & numFailTimeout.Value & "</Timeout>" & vbCrLf)
        s.Append(vbTab & "<WarnLoadTime Enabled='" & CStr(IIf(chkWarnTimeout.Checked, 1, 0)) & "'>" & numWarnTimeout.Value & "</WarnLoadTime>" & vbCrLf)
        s.Append(vbTab & "<FailCheckContent Enabled='" & CStr(IIf(chkFailContent.Checked, 1, 0)) & "' Negated='" & cboFailNegated.SelectedIndex & "'>" & XMLEncode(txtFailContent.Text) & "</FailCheckContent>" & vbCrLf)
        s.Append(vbTab & "<WarnCheckContent Enabled='" & CStr(IIf(chkWarnContent.Checked, 1, 0)) & "' Negated='" & cboWarnNegated.SelectedIndex & "'>" & XMLEncode(txtWarnContent.Text) & "</WarnCheckContent>" & vbCrLf)
        s.Append("</URLMonitor>")

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

#Region "Form Events"
    Private Sub chkWarnTimeout_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWarnTimeout.CheckedChanged
        numWarnTimeout.Enabled = chkWarnTimeout.Checked
    End Sub

    Private Sub chkFailContent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFailContent.CheckedChanged
        txtFailContent.Enabled = chkFailContent.Checked
        cboFailNegated.Enabled = chkFailContent.Checked
    End Sub

    Private Sub chkWarnContent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWarnContent.CheckedChanged
        txtWarnContent.Enabled = chkWarnContent.Checked
        cboWarnNegated.Enabled = chkWarnContent.Checked
    End Sub

#End Region
End Class
