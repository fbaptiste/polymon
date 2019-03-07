'Monitor contributed by Rod Sawers: 10/25/2006
Imports System.Xml
Imports PolyMon.Status

'This monitor will download an HTTP stream from a specified URL.
'It expects an XML document to be returned.
'In addition it can test for the presence or absence of specified nodes in the XML document.


'The XML definition for this monitor's settings is specified as follows:
'<URLXMLMonitor>
'	<URL>http://www.nrscorp.com/ContactForm.aspx</URL>
'	<Timeout>30</Timeout>
'   <WarnLoadTime Enabled="1">20</WarnLoadTime>
'	<FailCheckContent Enabled="1" Negated="1">//node[@attr='abc']</FailCheckContent>
'	<WarnCheckContent Enabled="1" Negated="1"></WarnCheckContent>
'</URLXMLMonitor>


'Notes: 
'Fail/Warn Timeout specifies, in seconds, the time interval after which the test is deemed to have failed/generated a warning.
'Use a Timeout of 0 for infinite timeout. This of course, will block all monitoring if the site does not respond.
'FailCheckContents indicates whether a Fail status should be returned if a nodelist defined by an XPath expression is or is not found.
'WarnCheckContents indicates whether a Warning should be returned if a nodelist defined by an XPath expression is or is not found in the stream.
'A Failure takes precedence over a warning.

'This monitor generates a single counter indicating the load times (in seconds).

Namespace Monitors
    Public Class URLXMLMonitor
        Inherits PolyMon.Monitors.MonitorExecutor

        Public Sub New(ByVal MonitorID As Integer)
            MyBase.New(MonitorID)
        End Sub

		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As Monitors.MonitorExecutor.MonitorStatus
			'Read Monitor configuration from XML
			Dim RootNode As XmlNode = Me.MonitorXML.DocumentElement

			Dim URL As String
			Dim Timeout As Integer
			Dim WarnLoadTimeEnabled As Boolean
			Dim WarnLoadTime As Integer
			Dim FailCheckContentEnabled As Boolean
			Dim FailCheckContent As String = Nothing
			Dim FailCheckContentNegated As Boolean
			Dim WarnCheckContentEnabled As Boolean
			Dim WarnCheckContent As String = Nothing
			Dim WarnCheckContentNegated As Boolean
			Dim responseText As String = Nothing

			Try
				'URL 
				URL = ReadXMLNodeValue(RootNode.SelectSingleNode("URL"))
				'Timeout 
				Timeout = CInt(ReadXMLNodeValue(RootNode.SelectSingleNode("Timeout")))

				'WarnLoadTime 
				WarnLoadTimeEnabled = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnLoadTime").Attributes("Enabled")))
				If WarnLoadTimeEnabled Then
					WarnLoadTime = CInt(ReadXMLNodeValue(RootNode.SelectSingleNode("WarnLoadTime")))
				End If

				'Fail Check Content
				FailCheckContentEnabled = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("FailCheckContent").Attributes("Enabled")))
				If FailCheckContentEnabled Then
					FailCheckContent = CStr(ReadXMLNodeValue(RootNode.SelectSingleNode("FailCheckContent")))
				End If
				FailCheckContentNegated = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("FailCheckContent").Attributes("Negated")))

				'Warn Check Content
				WarnCheckContentEnabled = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnCheckContent").Attributes("Enabled")))
				If WarnCheckContentEnabled Then
					WarnCheckContent = CStr(ReadXMLNodeValue(RootNode.SelectSingleNode("WarnCheckContent")))
				End If
				WarnCheckContentNegated = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnCheckContent").Attributes("Negated")))

				'Load URL
				Dim StartTime As Date = Now()
				Dim myDownload As New URLDownload(URL, Timeout)
				Dim EndTime As Date = Now()
				Dim responseXml As New XmlDocument

				If myDownload.StatusCode = URLDownload.StatusCodes.Failed Then
					StatusMessage = myDownload.StatusMessage
					Return MonitorExecutor.MonitorStatus.Fail
				Else
					'Resource loaded OK...
					Dim IsFailCheckContent As Boolean = False
					Dim IsWarnCheckContent As Boolean = False
					Dim IsWarnLoadTime As Boolean = False
					Dim ElapsedSecs As Double = EndTime.Subtract(StartTime).TotalSeconds

					'Add Load time to counters
					Counters.Add(New Counter("LoadTime", ElapsedSecs))

					'Check Warn timeout
					If WarnLoadTimeEnabled Then
						If ElapsedSecs > WarnLoadTime Then
							IsWarnLoadTime = True
						End If
					End If

					If FailCheckContentEnabled Or WarnCheckContentEnabled Then
						responseText = myDownload.HTTPResponse
						responseXml.LoadXml(responseText)

						Dim nl As XmlNodeList

						'Check Fail Contents
						If FailCheckContentEnabled AndAlso FailCheckContent.Trim.Length > 0 Then
							nl = responseXml.SelectNodes(FailCheckContent)
							If nl Is Nothing Then
								IsFailCheckContent = True
							End If
							If FailCheckContentNegated Then
								IsFailCheckContent = Not IsFailCheckContent
							End If
						End If

						'Warn Check Contents
						If WarnCheckContentEnabled AndAlso WarnCheckContent.Trim.Length > 0 Then
							nl = responseXml.SelectNodes(WarnCheckContent)
							If nl Is Nothing Then
								IsWarnCheckContent = True
							End If
							If WarnCheckContentNegated Then
								IsWarnCheckContent = Not IsWarnCheckContent
							End If
						End If
					End If

					If IsFailCheckContent Then
						If FailCheckContentNegated Then
							StatusMessage = "Fail. XML document contained specified failure node(s)."
						Else
							StatusMessage = "Fail. XML document did not contain specified failure node(s)."
						End If
					ElseIf IsWarnCheckContent Then
						If WarnCheckContentNegated Then
							StatusMessage = "Warning. XML document contained specified warning node(s)."
						Else
							StatusMessage = "Warning. XML documents did not contain specified warning node(s)."
						End If
					End If
					If IsWarnLoadTime Then
						If StatusMessage = Nothing Then
							StatusMessage = "Warning. Load time exceeded Warning threshold."
						Else
							StatusMessage &= vbCrLf & "Warning. Load time exceeded Warning threshold."
						End If
					End If


					If IsFailCheckContent Then
						StatusMessage &= vbCrLf & responseXml.OuterXml
						Return MonitorExecutor.MonitorStatus.Fail
					Else
						If IsWarnLoadTime Or IsWarnCheckContent Then
							StatusMessage &= vbCrLf & responseXml.OuterXml
							Return MonitorExecutor.MonitorStatus.Warn
						Else
							StatusMessage = "OK."
							StatusMessage &= vbCrLf & responseXml.OuterXml
							Return MonitorExecutor.MonitorStatus.OK
						End If
					End If
				End If
			Catch ex As Exception
				StatusMessage = ex.Message & vbCrLf & responseText
				Return MonitorExecutor.MonitorStatus.Fail
			Finally
				RootNode = Nothing
			End Try

		End Function

        Private Function ReadXMLNodeValue(ByVal myXMLNode As XmlNode) As String
            If myXMLNode Is Nothing Then
                Return Nothing
            Else
                If myXMLNode Is Nothing OrElse myXMLNode.InnerXml = Nothing Then
                    Return Nothing
                Else
                    'Return myXMLNode.InnerXml.Trim()
                    ' Must use InnerText to XmlDecode...
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
    End Class
End Namespace
