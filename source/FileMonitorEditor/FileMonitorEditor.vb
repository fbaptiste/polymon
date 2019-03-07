'Enhancements contributed by Rod Sawers: 10/25/2006

Imports System.Xml
Imports System.Text

Public Class FileMonitorEditor

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

#Region "Form Events"
	Private Sub chkCountWarning_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCountWarning.CheckedChanged
		numCountWarning.Enabled = chkCountWarning.Checked
	End Sub
    Private Sub chkMaxCount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMaxCount.CheckedChanged
        numMaxCount.Enabled = chkMaxCount.Checked
    End Sub
    Private Sub chkMaxAge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMaxAge.CheckedChanged
        numMaxAge.Enabled = chkMaxAge.Checked
        cboAgeType.Enabled = chkMaxAge.Checked
        cboDateType.Enabled = chkMaxAge.Checked
        cboFileType.Enabled = chkMaxAge.Checked
    End Sub
#End Region

#Region "Private Methods"
    Private Sub InitForm()
        chkCountWarning.Checked = False
        chkMaxCount.Checked = False
        chkMaxAge.Checked = False
        cboAgeType.SelectedIndex = 0
        cboDateType.SelectedIndex = 0
        cboFileType.SelectedIndex = 0

        numCountWarning.Enabled = False
        numMaxCount.Enabled = False
        numMaxAge.Enabled = False
        cboAgeType.Enabled = False
        cboDateType.Enabled = False
        cboFileType.Enabled = False

        txtDirPath.Text = Nothing
        txtFilePattern.Text = "*.*"
        numCountWarning.Value = 0
        numMaxCount.Value = 0
        numMaxAge.Value = 0
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

            'DirPath
            XMLNode = RootNode.SelectSingleNode("DirPath")
            txtDirPath.Text = CStr(XMLNode.InnerText).Trim()
            XMLNode = Nothing

            'FilePattern
            XMLNode = RootNode.SelectSingleNode("FilePattern")
            txtFilePattern.Text = CStr(XMLNode.InnerText).Trim()

            'Count Warning
            XMLNode = RootNode.SelectSingleNode("WarnCount")
            If XMLNode Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText)) Then
                chkCountWarning.Checked = False
                numCountWarning.Value = 0
            Else
                XMLAttribute = XMLNode.Attributes("Enabled")
                If XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
                    chkCountWarning.Checked = False
                Else
                    chkCountWarning.Checked = CBool(XMLAttribute.Value)
                End If
                Dim MaxCount As Integer
                MaxCount = CInt(XMLNode.InnerText)
                If MaxCount < numCountWarning.Minimum Then MaxCount = CInt(numCountWarning.Minimum)
                If MaxCount > numCountWarning.Maximum Then MaxCount = CInt(numCountWarning.Maximum)
                numCountWarning.Value = MaxCount
            End If
            numCountWarning.Enabled = chkCountWarning.Checked
            XMLNode = Nothing

            'Max Count
            XMLNode = RootNode.SelectSingleNode("MaxCount")
            If XMLNode Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText)) Then
                chkMaxCount.Checked = False
                numMaxCount.Value = 0
            Else
                XMLAttribute = XMLNode.Attributes("Enabled")
                If XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
                    chkMaxCount.Checked = False
                Else
                    chkMaxCount.Checked = CBool(XMLAttribute.Value)
                End If
                Dim MaxCount As Integer
                MaxCount = CInt(XMLNode.InnerText)
                If MaxCount < numMaxCount.Minimum Then MaxCount = CInt(numMaxCount.Minimum)
                If MaxCount > numMaxCount.Maximum Then MaxCount = CInt(numMaxCount.Maximum)
                numMaxCount.Value = MaxCount
            End If
            numMaxCount.Enabled = chkMaxCount.Checked
            XMLNode = Nothing


            'Max Age
            XMLNode = RootNode.SelectSingleNode("MaxAge")
            If XMLNode Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText)) Then
                chkMaxAge.Checked = False
                numMaxAge.Value = 0
            Else
                XMLAttribute = XMLNode.Attributes("Enabled")
                If XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
                    chkMaxAge.Checked = False
                Else
                    chkMaxAge.Checked = CBool(XMLAttribute.Value)
                End If
                Dim MaxAge As Integer
                MaxAge = CInt(XMLNode.InnerText)
                If MaxAge < numMaxAge.Minimum Then MaxAge = CInt(numMaxAge.Minimum)
                If MaxAge > numMaxAge.Maximum Then MaxAge = CInt(numMaxAge.Maximum)
                numMaxAge.Value = MaxAge
                XMLAttribute = XMLNode.Attributes("AgeType")
                If XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
                    cboAgeType.SelectedIndex = 0
                Else
                    cboAgeType.SelectedIndex = cboAgeType.FindStringExact(XMLAttribute.Value.ToLower)
                End If
                XMLAttribute = XMLNode.Attributes("DateType")
                If XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
                    cboDateType.SelectedIndex = 0
                Else
                    cboDateType.SelectedIndex = cboDateType.FindStringExact(XMLAttribute.Value.ToLower)
                End If
                XMLAttribute = XMLNode.Attributes("FileType")
                If XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0 Then
                    cboFileType.SelectedIndex = 0
                Else
                    cboFileType.SelectedIndex = cboFileType.FindStringExact(XMLAttribute.Value.ToLower)
                End If
            End If
            numMaxAge.Enabled = chkMaxAge.Checked
            cboAgeType.Enabled = chkMaxAge.Checked
            cboDateType.Enabled = chkMaxAge.Checked
            cboFileType.Enabled = chkMaxAge.Checked
            XMLNode = Nothing

        End If
    End Sub
    Private Function BuildXMLParams() As String
        Dim s As New StringBuilder

        s.Append("<FileMonitor>" & vbCrLf)
        s.Append(vbTab & "<DirPath>" & XMLEncode(txtDirPath.Text.Trim()) & "</DirPath>" & vbCrLf)
        s.Append(vbTab & "<FilePattern>" & XMLEncode(txtFilePattern.Text.Trim()) & "</FilePattern>" & vbCrLf)
        s.Append(vbTab & "<WarnCount Enabled='" & CStr(IIf(chkCountWarning.Checked, 1, 0)) & "'>" & numCountWarning.Value & "</WarnCount>" & vbCrLf)
        s.Append(vbTab & "<MaxCount Enabled='" & CStr(IIf(chkMaxCount.Checked, 1, 0)) & "'>" & numMaxCount.Value & "</MaxCount>" & vbCrLf)
        s.Append(vbTab & "<MaxAge Enabled='" & CStr(IIf(chkMaxAge.Checked, 1, 0)) & "' AgeType='" & cboAgeType.Text & "' DateType='" & cboDateType.Text & "' FileType='" & cboFileType.Text & "'>" & numMaxAge.Value & "</MaxAge>" & vbCrLf)
        s.Append(vbTab & "<EnableCounters>1</EnableCounters>" & vbCrLf)
        s.Append("</FileMonitor>")

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
