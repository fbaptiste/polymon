Imports System.Xml
Imports System.ServiceProcess

'This monitor checks whether a Windows service is in a running state or not on a specified host.
'The nominal status can de defined as Running or Not Running.

'<ServiceMonitor>
'	<Host>NRSODS01</Host>
'	<ServiceName>MSSQLSERVER</ServiceName>
'	<NominalStateIsRunning>1</NominalStateIsRunning>
'</ServiceMonitor>

'No counters are defined for this monitor.
Namespace Monitors
    Public Class ServiceMonitor
        Inherits PolyMon.Monitors.MonitorExecutor

        Public Sub New(ByVal MonitorID As Integer)
            MyBase.New(MonitorID)
        End Sub

		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As PolyMon.Status.CounterList) As Monitors.MonitorExecutor.MonitorStatus
			'Read Monitor configuration from XML
			Dim Host As String
			Dim ServiceName As String
			Dim NominalStateIsRunning As Boolean

			Dim RootNode As XmlNode = MonitorXML.DocumentElement

			Host = ReadXMLNodeValue(RootNode.SelectSingleNode("Host"))
			ServiceName = ReadXMLNodeValue(RootNode.SelectSingleNode("ServiceName"))
			NominalStateIsRunning = CBool(ReadXMLNodeValue(RootNode.SelectSingleNode("NominalStateIsRunning")))

			'Check Service State
			Dim sc As ServiceController
			sc = New ServiceController(ServiceName, Host)

			Dim IsOK As Boolean
			Dim ServiceStatus As ServiceControllerStatus
			Try
				ServiceStatus = sc.Status

				If NominalStateIsRunning Then
					'Check to make sure service is running
					If ServiceStatus = ServiceControllerStatus.Running Then
						IsOK = True
						StatusMessage = "OK."
					Else
						IsOK = False
						StatusMessage = "Fail. Service state= " & ServiceStatus.ToString()
					End If
				Else
					'Check to make sure Service is NOT running
					If ServiceStatus = ServiceControllerStatus.Running Then
						IsOK = False
						StatusMessage = "Fail. Service is running."
					Else
						IsOK = True
						StatusMessage = "OK. Service state= " & ServiceStatus.ToString()
					End If
				End If
			Catch ex As Exception
				IsOK = False
				StatusMessage = ex.Message
			Finally
				sc = Nothing
			End Try


			If IsOK Then Return Monitors.MonitorExecutor.MonitorStatus.OK Else Return Monitors.MonitorExecutor.MonitorStatus.Fail
		End Function

        Private Function ReadXMLNodeValue(ByVal myXMLNode As XmlNode) As String
            If myXMLNode Is Nothing Then
                Return Nothing
            Else
                If myXMLNode Is Nothing OrElse myXMLNode.InnerXml = Nothing Then
                    Return Nothing
                Else
                    Return myXMLNode.InnerXml.Trim()
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