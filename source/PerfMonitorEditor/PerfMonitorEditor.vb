Imports System.Xml
Imports System.Text

Public Class PerfMonitorEditor

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
        Me.txtHost.Text = Nothing
        Me.txtCategory.Text = Nothing
        Me.txtCounter.Text = Nothing
        Me.txtInstance.Text = Nothing
        Me.txtFailMin.Text = Nothing
        Me.txtFailMax.Text = Nothing
        Me.txtWarnMin.Text = Nothing
        Me.txtWarnMax.Text = Nothing
        Me.chkFailMin.Checked = False
        Me.chkFailMax.Checked = False
        Me.chkWarnMin.Checked = False
        Me.chkWarnMax.Checked = False
        Me.txtFailMin.Enabled = False
        Me.txtFailMax.Enabled = False
        Me.txtWarnMin.Enabled = False
        Me.txtWarnMax.Enabled = False
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

            'Category
            XMLNode = RootNode.SelectSingleNode("Category")
			txtCategory.Text = CStr(XMLNode.InnerText).Trim()
            XMLNode = Nothing

            'Counter
            XMLNode = RootNode.SelectSingleNode("Counter")
			txtCounter.Text = CStr(XMLNode.InnerText).Trim()
            XMLNode = Nothing

            'Instance
            XMLNode = RootNode.SelectSingleNode("Instance")
			txtInstance.Text = CStr(XMLNode.InnerText).Trim()
            XMLNode = Nothing

            'Fail Thresholds
            'Max
            XMLNode = RootNode.SelectSingleNode("FailThresholds/Max")
            Dim MaxEnabled As Boolean = False
            Dim MaxValue As String = Nothing
            If Not (XMLNode Is Nothing OrElse XMLNode.InnerText Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText))) Then
                XMLAttribute = XMLNode.Attributes("Enabled")
                If Not (XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0) Then
                    MaxEnabled = CBool(XMLAttribute.Value)
                    MaxValue = CStr(XMLNode.InnerText)
                End If
            End If
            chkFailMax.Checked = MaxEnabled
            txtFailMax.Text = MaxValue
            txtFailMax.Enabled = MaxEnabled
            'Min
            XMLNode = RootNode.SelectSingleNode("FailThresholds/Min")
            Dim MinEnabled As Boolean = False
            Dim MinValue As String = Nothing
            If Not (XMLNode Is Nothing OrElse XMLNode.InnerText Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText))) Then
                XMLAttribute = XMLNode.Attributes("Enabled")
                If Not (XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0) Then
                    MinEnabled = CBool(XMLAttribute.Value)
                    MinValue = CStr(XMLNode.InnerText)
                End If
            End If
            chkFailMin.Checked = MinEnabled
            txtFailMin.Text = MinValue
            txtFailMin.Enabled = MinEnabled
            XMLNode = Nothing

            'Warn Thresholds
            'Max
            XMLNode = RootNode.SelectSingleNode("WarnThresholds/Max")
            MaxEnabled = False
            MaxValue = Nothing
            If Not (XMLNode Is Nothing OrElse XMLNode.InnerText Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText))) Then
                XMLAttribute = XMLNode.Attributes("Enabled")
                If Not (XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0) Then
                    MaxEnabled = CBool(XMLAttribute.Value)
                    MaxValue = CStr(XMLNode.InnerText)
                End If
            End If
            chkWarnMax.Checked = MaxEnabled
            txtWarnMax.Text = MaxValue
            txtWarnMax.Enabled = MaxEnabled
            'Min
            XMLNode = RootNode.SelectSingleNode("WarnThresholds/Min")
            MinEnabled = False
            MinValue = Nothing
            If Not (XMLNode Is Nothing OrElse XMLNode.InnerText Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText))) Then
                XMLAttribute = XMLNode.Attributes("Enabled")
                If Not (XMLAttribute Is Nothing OrElse XMLAttribute.Value.Trim.Length = 0) Then
                    MinEnabled = CBool(XMLAttribute.Value)
                    MinValue = CStr(XMLNode.InnerText)
                End If
            End If
            chkWarnMin.Checked = MinEnabled
            txtWarnMin.Text = MinValue
            txtWarnMin.Enabled = MinEnabled
            XMLNode = Nothing


        End If
    End Sub
    Private Function BuildXMLParams() As String
        Dim s As New StringBuilder

        s.Append("<PerfMonitor>" & vbCrLf)
        s.Append(vbTab & "<Host>" & XMLEncode(txtHost.Text.Trim()) & "</Host>" & vbCrLf)
        s.Append(vbTab & "<Category>" & XMLEncode(txtCategory.Text.Trim()) & "</Category>" & vbCrLf)
        s.Append(vbTab & "<Counter>" & XMLEncode(txtCounter.Text.Trim()) & "</Counter>" & vbCrLf)
        s.Append(vbTab & "<Instance>" & XMLEncode(txtInstance.Text.Trim()) & "</Instance>" & vbCrLf)

        s.Append(vbTab & "<FailThresholds>" & vbCrLf)
        s.Append(vbTab & vbTab & "<Max Enabled='" & CStr(IIf(chkFailMax.Checked, 1, 0)) & "'>" & txtFailMax.Text & "</Max>" & vbCrLf)
        s.Append(vbTab & vbTab & "<Min Enabled='" & CStr(IIf(chkFailMin.Checked, 1, 0)) & "'>" & txtFailMin.Text & "</Min>" & vbCrLf)
        s.Append(vbTab & "</FailThresholds>" & vbCrLf)

        s.Append(vbTab & "<WarnThresholds>" & vbCrLf)
        s.Append(vbTab & vbTab & "<Max Enabled='" & CStr(IIf(chkWarnMax.Checked, 1, 0)) & "'>" & txtWarnMax.Text & "</Max>" & vbCrLf)
        s.Append(vbTab & vbTab & "<Min Enabled='" & CStr(IIf(chkWarnMin.Checked, 1, 0)) & "'>" & txtWarnMin.Text & "</Min>" & vbCrLf)
        s.Append(vbTab & "</WarnThresholds>" & vbCrLf)

        s.Append("</PerfMonitor>")

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

#Region "Event Handlers"
	Private Sub chkFailMin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFailMin.CheckedChanged
		txtFailMin.Enabled = chkFailMin.Checked
	End Sub
	Private Sub chkFailMax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFailMax.CheckedChanged
		txtFailMax.Enabled = chkFailMax.Checked
	End Sub
	Private Sub chkWarnMin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWarnMin.CheckedChanged
		txtWarnMin.Enabled = chkWarnMin.Checked
	End Sub
	Private Sub chkWarnMax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWarnMax.CheckedChanged
		txtWarnMax.Enabled = chkWarnMax.Checked
	End Sub
	Private Sub btnBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowser.Click
		Dim myBrowser As New frmBrowser()
		Dim retVal As DialogResult = myBrowser.ShowDialog()
		If retVal = DialogResult.OK Then
			Me.txtHost.Text = myBrowser.Host()
			Me.txtCategory.Text = myBrowser.Category()
			Me.txtCounter.Text = myBrowser.Counter()
			Me.txtInstance.Text = myBrowser.Instance()
		End If
	End Sub
#End Region

End Class
