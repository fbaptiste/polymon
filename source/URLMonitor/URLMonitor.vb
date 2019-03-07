Imports System.Xml

'This monitor will download an HTTP stream from a specified URL 
'In addition it can test for the presence of specified text in the returned HTTP stream.


'The XML definition for this monitor's settings is specified as follows:
'<URLMonitor>
'	<URL>http://www.nrscorp.com/ContactForm.aspx</URL>
'	<Timeout>30</Timeout>
'   <WarnLoadTime Enabled="1">20</WarnLoadTime>
'	<FailCheckContent Enabled="1" Negated="1">Satisfaction Solutions (Consulting Services)</FailCheckContent>
'	<WarnCheckContent Enabled="1" Negated="1">Satisfaction Solutions</WarnCheckContent>
'</URLMonitor>


'Notes: 
'Fail/Warn Timeout specifies, in seconds, the time interval after which the test is deemed to have failed/generated a warning.
'Use a Timeout of 0 for infinite timeout. This of course, will block all monitoring if the site does not respond.
'FailCheckContents indicates whether a Fail status should be returned if certain text is or is not found in the stream
'WarnCheckContents indicates whether a Warning should be returned if certain test is or is not found in the stream.
'A Failure takes precedence over a warning.

'This monitor generates a single counter indicating the load times (in seconds).
'
'Enhancements contributed by Rod Sawers: 10/25/2006

Imports PolyMon.Status

Namespace Monitors
	Public Class URLMonitor
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
				If ReadXMLAttributeValue(RootNode.SelectSingleNode("FailCheckContent").Attributes("Negated")) = Nothing Then
					FailCheckContentNegated = False
				Else
					FailCheckContentNegated = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("FailCheckContent").Attributes("Negated")))
				End If

				'Warn Check Content
				WarnCheckContentEnabled = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnCheckContent").Attributes("Enabled")))
				If WarnCheckContentEnabled Then
					WarnCheckContent = CStr(ReadXMLNodeValue(RootNode.SelectSingleNode("WarnCheckContent")))
				End If
				If ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnCheckContent").Attributes("Negated")) = Nothing Then
					WarnCheckContentNegated = False
				Else
					WarnCheckContentNegated = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnCheckContent").Attributes("Negated")))
				End If

				'Load URL
				Dim StartTime As Date = Now()
				Dim myDownload As New URLDownload(URL, Timeout)
				Dim EndTime As Date = Now()

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
						Dim HTTPResponse As String = myDownload.HTTPResponse

						'Check Fail Contents
						If FailCheckContentEnabled Then
							If HTTPResponse.IndexOf(FailCheckContent) < 0 Then
								IsFailCheckContent = True
							End If
							If FailCheckContentNegated Then
								IsFailCheckContent = Not IsFailCheckContent
							End If
						End If

						'Warn Check Contents
						If WarnCheckContentEnabled Then
							If HTTPResponse.IndexOf(WarnCheckContent) < 0 Then
								IsWarnCheckContent = True
							End If
							If WarnCheckContentNegated Then
								IsWarnCheckContent = Not IsWarnCheckContent
							End If
						End If
					End If



					If IsFailCheckContent Then
						If FailCheckContentNegated Then
							StatusMessage = "Fail. Contents contained specified failure text."
						Else
							StatusMessage = "Fail. Contents did not contain specified failure text."
						End If
					ElseIf IsWarnCheckContent Then
						If WarnCheckContentNegated Then
							StatusMessage = "Warning. Contents contained specified warning text."
						Else
							StatusMessage = "Warning. Contents did not contain specified warning text."
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
						Return MonitorExecutor.MonitorStatus.Fail
					Else
						If IsWarnLoadTime Or IsWarnCheckContent Then
							Return MonitorExecutor.MonitorStatus.Warn
						Else
							StatusMessage = "OK."
							Return MonitorExecutor.MonitorStatus.OK
						End If
					End If
				End If
			Catch ex As Exception
				StatusMessage = ex.Message
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