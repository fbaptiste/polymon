Imports System.Xml
Imports System.Text

Public Class TCPPortMonitorEditor

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
            numTCPPort.Value = numTCPPort.Minimum
            numTimeout.Value = numTimeout.Minimum
        Else
            XMLDoc.LoadXml(XML)
            Dim RootNode As XmlNode = XMLDoc.DocumentElement

            Dim XMLNode As XmlNode = Nothing

            'Host
            XMLNode = RootNode.SelectSingleNode("Host")
            txtHost.Text = CStr(XMLNode.InnerText).Trim()
            XMLNode = Nothing

            'TCPPort
            XMLNode = RootNode.SelectSingleNode("Port")
            With numTCPPort
                If XMLNode Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText)) Then
                    'XMLNode Value is blank or does not exist, set to minimum
                    .Value = .Minimum
                Else
                    Dim Value As Integer = CInt(XMLNode.InnerText)
                    If Value > .Maximum Then Value = CInt(.Maximum)
                    .Value = Value
                End If
            End With
            XMLNode = Nothing

            'Timeout
            XMLNode = RootNode.SelectSingleNode("Timeout")
            With numTimeout
                If XMLNode Is Nothing OrElse XMLNode.InnerText.Trim.Length = 0 OrElse Not (IsNumeric(XMLNode.InnerText)) Then
                    'XMLNode Value is blank or does not exist, set to minimum
                    .Value = .Minimum
                Else
                    Dim Value As Integer = CInt(XMLNode.InnerText)
                    If Value > .Maximum Then Value = CInt(.Maximum)
                    .Value = Value
                End If
            End With
            XMLNode = Nothing
        End If
    End Sub
    Private Function BuildXMLParams() As String
        Dim s As New StringBuilder

        s.Append("<TCPPortMonitor>" & vbCrLf)
        s.Append(vbTab & "<Host>" & txtHost.Text.Trim() & "</Host>" & vbCrLf)
        s.Append(vbTab & "<Port>" & numTCPPort.Value & "</Port>" & vbCrLf)
        s.Append(vbTab & "<Timeout>" & numTimeout.Value & "</Timeout>" & vbCrLf)
        s.Append("</TCPPortMonitor>")

        Return s.ToString()
    End Function
#End Region
End Class
