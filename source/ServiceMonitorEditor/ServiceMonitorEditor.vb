Imports System.Xml
Imports System.Text

Public Class ServiceMonitorEditor
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

#Region "Private Methods"
    Private Sub LoadXMLValues(ByVal XML As String)
        'Get default data from XML template (mXMLTemplate)
        Dim XMLDoc As New XmlDocument

        If XML Is Nothing OrElse XML.Trim.Length = 0 Then
            txtHost.Text = Nothing
            txtServiceName.Text = Nothing
            radRunning.Checked = True
            radNotRunning.Checked = False
        Else
            XMLDoc.LoadXml(XML)
            Dim RootNode As XmlNode = XMLDoc.DocumentElement

            Dim XMLNode As XmlNode = Nothing

            'Host
            XMLNode = RootNode.SelectSingleNode("Host")
            txtHost.Text = CStr(XMLNode.InnerText).Trim()
            XMLNode = Nothing

            'Service Name
            XMLNode = RootNode.SelectSingleNode("ServiceName")
            txtServiceName.Text = CStr(XMLNode.InnerText).Trim()
            XMLNode = Nothing

            'NominalStateIsRunning
            XMLNode = RootNode.SelectSingleNode("NominalStateIsRunning")
            Dim NominalIsRunning As Boolean = True

            If XMLNode Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText)) Then
                'XMLNode Value is blank or does not exist, set to internal default
                NominalIsRunning = True
            Else
                NominalIsRunning = CBool(XMLNode.InnerText)
            End If
            If NominalIsRunning Then
                radRunning.Checked = True
                radNotRunning.Checked = False
            Else
                radNotRunning.Checked = True
                radRunning.Checked = False
            End If
            XMLNode = Nothing
        End If
    End Sub
    Private Function BuildXMLParams() As String
        Dim s As New StringBuilder

        s.Append("<ServiceMonitor>" & vbCrLf)
        s.Append(vbTab & "<Host>" & txtHost.Text.Trim() & "</Host>" & vbCrLf)
        s.Append(vbTab & "<ServiceName>" & txtServiceName.Text.Trim() & "</ServiceName>" & vbCrLf)
        s.Append(vbTab & "<NominalStateIsRunning>" & CStr(IIf(radRunning.Checked, 1, 0)) & "</NominalStateIsRunning>" & vbCrLf)
        s.Append("</ServiceMonitor>")

        Return s.ToString()
    End Function
#End Region
End Class
