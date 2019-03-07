Imports System.Xml
Imports System.IO
Imports PolyMon.Status

'This monitor will test for the existence of files
'matching a specific pattern in a specified location
'OK, Fail, Warn is based on the age of the oldest file
'and/or the number of files matching the pattern in the 
'specified directory.
'This monitor type can be useful for monitoring a file based queue system
'where you would want to make sure no files older than a certain age exist
'or making sure that the queues are not getting backup up beyond a certain number of files

'This monitor generates a single counter indicating the number of files matching the pattern 
'in the specified directory.

'The XML definition for this monitor's settings is specified as follows:
'<FileMonitor>
'	<DirPath>c:\</DirPath>
'	<FilePattern>*.xml</FilePattern>
'   <WarnCount Enabled="1">50</WarnCount>
'	<MaxCount Enabled="1">100</MaxCount>
'	<MaxAge Enabled="1" AgeType="seconds|minutes|hours|days" DateType="created|modified|accessed" FileType="oldest|newest">1800</MaxAge>
'   <EnableCounters>1</EnableCounters>
'</FileMonitor>
'
'Notes: 
'MaxAge is specified in seconds. 
'If enabled, WarnCount specifies a threshold value at or above which a Warn alert will be generated.
'If enabled, MaxCount specifies a threshold value at or above which a Fail alert willbe generated.
'If EnableCounters is set to 1, any counters defined by this monitor will be logged to the database.

'Enhancements contributed by Rod Sawers: 10/25/2006
'Rod's Notes:
'FilePattern was not being used - now added to GetFiles() call
'When checking the oldest file in the folder (e.g. a queue), fail on first old file found.
'When checking the newest file in the folder (e.g. a logfile), check all files to find the newest; then check the timestamp.

Namespace Monitors
    Public Class FileMonitor
        Inherits PolyMon.Monitors.MonitorExecutor

        'Need to implement the New method since a constructor is required
        Public Sub New(ByVal MonitorID As Integer)
            MyBase.New(MonitorID)
        End Sub

        'Need to implement the MonitorTest function
        'This is the function that performs the monitoring and sets any warn/fail/ok statuses as well as any counters
		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As MonitorExecutor.MonitorStatus
			'Initialize
			Dim myStatus As MonitorStatus = MonitorExecutor.MonitorStatus.Fail
			Counters.Clear()
			StatusMessage = "Monitor not run."

			Try
				'Read in monitor/threshold definitions
				Dim DirPath As String
				Dim FilePattern As String
				Dim WarnCountEnabled As Boolean
				Dim WarnCountThreshold As Integer
				Dim MaxCountEnabled As Boolean
				Dim MaxCountThreshold As Integer
				Dim MaxAgeEnabled As Boolean
				Dim MaxAgeThreshold As Integer
				Dim EnableCounters As Boolean
				Dim MaxAgeAgeType As String
				Dim MaxAgeDateType As String
				Dim MaxAgeFileType As String

				Dim RootNode As XmlNode = Me.MonitorXML.DocumentElement

				DirPath = ReadXMLNodeValue(RootNode.SelectSingleNode("DirPath"))
				FilePattern = ReadXMLNodeValue(RootNode.SelectSingleNode("FilePattern"))

				MaxCountEnabled = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("MaxCount").Attributes("Enabled")))
				If MaxCountEnabled Then
					MaxCountThreshold = CInt(ReadXMLNodeValue(RootNode.SelectSingleNode("MaxCount")))
				End If

				WarnCountEnabled = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnCount").Attributes("Enabled")))
				If WarnCountEnabled Then
					WarnCountThreshold = CInt(ReadXMLNodeValue(RootNode.SelectSingleNode("WarnCount")))
				End If

				MaxAgeEnabled = CBool(ReadXMLAttributeValue(RootNode.SelectSingleNode("MaxAge").Attributes("Enabled")))
				If MaxAgeEnabled Then
					MaxAgeThreshold = CInt(ReadXMLNodeValue(RootNode.SelectSingleNode("MaxAge")))
				End If

				EnableCounters = CBool(ReadXMLNodeValue(RootNode.SelectSingleNode("EnableCounters")))

				Try
					MaxAgeAgeType = ReadXMLAttributeValue(RootNode.SelectSingleNode("MaxAge").Attributes("AgeType")).ToLower
				Catch ex As Exception
					MaxAgeAgeType = ""
				End Try
				If MaxAgeAgeType = "" Then MaxAgeAgeType = "seconds"

				' Convert the threshold to seconds.
				Select Case MaxAgeAgeType
					Case "minutes"
						MaxAgeThreshold *= 60
					Case "hours"
						MaxAgeThreshold *= 60 * 60
					Case "days"
						MaxAgeThreshold *= 60 * 60 * 24
				End Select

				Try
					MaxAgeDateType = ReadXMLAttributeValue(RootNode.SelectSingleNode("MaxAge").Attributes("DateType")).ToLower
				Catch ex As Exception
					MaxAgeDateType = ""
				End Try
				If MaxAgeDateType = "" Then MaxAgeDateType = "created"

				Try
					MaxAgeFileType = ReadXMLAttributeValue(RootNode.SelectSingleNode("MaxAge").Attributes("FileType")).ToLower
				Catch ex As Exception
					MaxAgeFileType = ""
				End Try
				If MaxAgeDateType = "" Then MaxAgeDateType = "oldest"

				'Run Monitor Test/Counters

				Dim FileDir As DirectoryInfo
				FileDir = New DirectoryInfo(DirPath)

				Dim myFiles() As FileInfo = FileDir.GetFiles(FilePattern)
				Dim FileCount As Integer = myFiles.GetLength(0)

				If EnableCounters Then
					Counters.Add(New Counter("File Count", FileCount))
				End If

				Dim IsOK As Boolean = True
				If MaxAgeEnabled AndAlso FileCount > 0 Then
					Dim myFile As FileInfo
					Dim checkTime As DateTime
					Dim newestTime As DateTime = DateTime.MinValue
					Dim newestFile As FileInfo = Nothing
					IsOK = True
					For Each myFile In myFiles

						Select Case MaxAgeDateType
							Case "modified"
								checkTime = myFile.LastWriteTime
							Case "accessed"
								checkTime = myFile.LastAccessTime
							Case Else
								checkTime = myFile.CreationTime
						End Select

						' Store the timestamp of the newest file in the folder.
						If checkTime > newestTime Then
							newestTime = checkTime
							newestFile = myFile
						End If

						' Checking 'oldest' file - we can stop as soon as we find any older file.
						If MaxAgeFileType = "oldest" Then
							If checkTime <= DateAdd(DateInterval.Second, -MaxAgeThreshold, Now()) Then
								StatusMessage = FormatStatusMessage(checkTime, MaxAgeDateType, MaxAgeAgeType)
								myStatus = MonitorExecutor.MonitorStatus.Fail
								IsOK = False
								Exit For 'No need to keep checking
							End If
						End If
					Next

					' Checking 'newest' file - we need to process all files in the folder.
					If MaxAgeFileType = "newest" Then
						If newestTime <= DateAdd(DateInterval.Second, -MaxAgeThreshold, Now()) Then
							StatusMessage = FormatStatusMessage(newestTime, MaxAgeDateType, MaxAgeAgeType) & _
							 vbCrLf & newestFile.FullName
							myStatus = MonitorExecutor.MonitorStatus.Fail
							IsOK = False
						End If
					End If

					myFile = Nothing
				End If

				If IsOK Then 'keep checking for FileCounts (if enabled)
					Dim IsWarn As Boolean = False
					Dim IsMax As Boolean = False

					If WarnCountEnabled AndAlso (FileCount > WarnCountThreshold) Then IsWarn = True
					If MaxCountEnabled AndAlso (FileCount > MaxCountThreshold) Then IsMax = True

					If IsMax Then
						'Max threshold reached...
						myStatus = MonitorExecutor.MonitorStatus.Fail
						StatusMessage = "Maximum File Count exceeded: Total Count=" & CStr(FileCount)
					ElseIf IsWarn Then
						myStatus = MonitorExecutor.MonitorStatus.Warn
						StatusMessage = "Warning File Count exceeded: Total Count=" & CStr(FileCount)
					Else
						myStatus = MonitorExecutor.MonitorStatus.OK
						StatusMessage = "OK. Total Count=" & CStr(FileCount)
					End If
				End If
				myFiles = Nothing
			Catch ex As Exception
				myStatus = MonitorExecutor.MonitorStatus.Fail
				StatusMessage = "Monitor Exception: " & vbCrLf & ex.Message
			End Try

			Return myStatus
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
        Private Function FormatStatusMessage(ByVal checkTime As DateTime, ByVal dateType As String, ByVal ageType As String) As String
            Dim checkAge As Double
            Select Case ageType
                Case "minutes"
                    checkAge = Now.Subtract(checkTime).TotalMinutes
                Case "hours"
                    checkAge = Now.Subtract(checkTime).TotalHours
                Case "days"
                    checkAge = Now.Subtract(checkTime).TotalDays
                Case Else
                    checkAge = Now.Subtract(checkTime).TotalSeconds
            End Select
            Return String.Format("File found with a {0} timestamp of: {1:MM/dd/yyyy hh:mm:ss tt} ({2:F} {3} ago)", dateType, checkTime, checkAge, ageType)
        End Function
    End Class
End Namespace