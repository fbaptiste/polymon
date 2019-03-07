Imports System.Xml
Imports system.Net.NetworkInformation
Imports Microsoft.VisualBasic
Imports PolyMon.Status

'This monitor checks remaining disk space and warns if disk space is lower than
'one threshold, and fails if it is lower than another.

'The XML definition for this monitor's settings is specified as follows:
'<DiskMonitor>
' <Drive>C</Drive>
' <TempNetMapDrive></TempNetMapDrive>
' <WarnMB>1024</WarnMB>
' <FailMB>512</FailMB>
' <ReportErrorAs>Fail</ReportErrorAs>
'</DiskMonitor>
'
'Notes: 
'Currently only supports Megabytes (1024x1024 bytes) as a unit of measurement.
'Future versions will support percentages and maybe KB or GB.  The values indicate
'the threshold with which to warn/fail based on space left, NOT space consumed.
'A blank 'host' means localhost.  Drive is either a single letter or "\\" followed
'by a UNC path to a share that will be mapped as a virtual drive for testing.
'In order to find out info on a remote host, the drive MUST be temporarily mapped.
'The TempNetMapDrive parameter allows you to do this. If it's empty, the monitor
'will use Z:.  Monitoring locally will ignore the TempNetMapDrive parameter.  
'ReportErrorAs must be either OK, Unknown, Warn, or Fail which indicates the level of 
'failure if the drive cannot be analyzed for any reason (default is Fail).
'
'Counter:
'FreeMB - MB available on the drive

Namespace Monitors
  Public Class DiskMonitor
    Inherits PolyMon.Monitors.MonitorExecutor

    Public Sub New(ByVal MonitorID As Integer)
      MyBase.New(MonitorID)
    End Sub

		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As MonitorExecutor.MonitorStatus
			Dim Drive As String = ""
			Dim TempNetMapDrive As String = ""
			Dim WarnMB As Long = 0
			Dim FailMB As Long = 0
			Dim ReportErrorAs As MonitorExecutor.MonitorStatus = MonitorStatus.Unknown

			Dim RootNode As XmlNode = Me.MonitorXML.DocumentElement
			Dim NodeValue As String

			Dim freeSpace As Long = 0

			Try

				'
				' Fetch parameters
				'

				Drive = ReadXMLNodeValue(RootNode.SelectSingleNode("Drive"))

				TempNetMapDrive = ReadXMLNodeValue(RootNode.SelectSingleNode("TempNetMapDrive"))

				NodeValue = ReadXMLNodeValue(RootNode.SelectSingleNode("WarnMB"))
				WarnMB = CType(IIf(NodeValue = Nothing, 1024, NodeValue), Long)

				NodeValue = ReadXMLNodeValue(RootNode.SelectSingleNode("FailMB"))
				FailMB = CType(IIf(NodeValue = Nothing, 512, NodeValue), Long)

				NodeValue = ReadXMLNodeValue(RootNode.SelectSingleNode("ReportErrorAs"))

				Select Case NodeValue.ToUpper
					Case "WARN"
						ReportErrorAs = MonitorStatus.Warn
					Case "UNKNOWN"
						ReportErrorAs = MonitorStatus.Unknown
					Case "OK"
						ReportErrorAs = MonitorStatus.OK
					Case Else
						ReportErrorAs = MonitorStatus.Fail
				End Select

				' Check to make sure we have a real drive/path to check
				If Drive Is Nothing OrElse Drive.Length < 1 Then
					Drive = "C"
				End If

				' Check to see if we have a drive letter to map to
				If TempNetMapDrive Is Nothing OrElse TempNetMapDrive.Length < 1 Then
					TempNetMapDrive = "Z"
				Else
					TempNetMapDrive = Left(TempNetMapDrive, 1)
				End If


				'
				' Check the drive
				'

				If Drive(0) = "\" Then
					' This is a network drive
					If UnmanagedMapDrive.MapDrive(Drive, TempNetMapDrive(0)) = 0 Then
						Try
							' Retrieve the free space
							freeSpace = New System.IO.DriveInfo(TempNetMapDrive).AvailableFreeSpace

							' Unmap the drive
							UnmanagedMapDrive.UnmapDrive(TempNetMapDrive(0))
						Catch ex As Exception
							StatusMessage = "Exception occurred when reading network drive space. Details: " & ex.Message & CStr(IIf(ex.InnerException IsNot Nothing, " ... " & ex.InnerException.Message, ""))
							Return ReportErrorAs
						End Try
					Else
						StatusMessage = "Could not map network drive for testing."
						Return ReportErrorAs
					End If
				Else
					' This is a local drive
					Try
						' Retrieve the free space
						freeSpace = New System.IO.DriveInfo(Drive(0).ToString).AvailableFreeSpace
					Catch ex As Exception
						StatusMessage = "Exception occurred when reading local drive space. Details: " & ex.Message & CStr(IIf(ex.InnerException IsNot Nothing, " ... " & ex.InnerException.Message, ""))
						Return ReportErrorAs
					End Try
				End If

				' Convert "free space" to MB
				freeSpace = CType(freeSpace / 1048576, Long)  ' 1048576 = 1024 * 1024

				' Add the counter
				Counters.Add(New Counter("FreeMB", freeSpace))

				'
				' Report the status
				'
				If freeSpace < FailMB Then
					StatusMessage = "Drive """ & Drive & """ is below FAILURE threshold of " & FailMB.ToString & "MB!  Current free space: " & freeSpace.ToString & "MB."
					Return MonitorStatus.Fail
				ElseIf freeSpace < WarnMB Then
					StatusMessage = "Drive """ & Drive & """ is below warning threshold of " & WarnMB.ToString & "MB.  Current free space: " & freeSpace.ToString & "MB."
					Return MonitorStatus.Warn
				Else
					StatusMessage = "Ok.  Current free space: " & freeSpace.ToString & "MB."
					Return MonitorStatus.OK
				End If
			Catch ex As Exception
				StatusMessage = "Unexpected Error:" & vbCrLf & ex.Message & vbCrLf & ex.InnerException.Message
				Return ReportErrorAs
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