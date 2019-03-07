Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Namespace Monitors
    Public Class MonitorMetadata

#Region "Private Properties"
        Private mSQLConn As String
        Private mIsNewInstance As Boolean

		'Monitor metadata
		Private mCurrentDT As Date
        Private mIsEnabled As Boolean
        Private mMonitorID As Integer
        Private mMonitorName As String
        Private mMonitorXML As XmlDocument
        Private mMonitorXMLString As String
        Private mOfflineTime1 As OfflineTime
        Private mOfflineTime2 As OfflineTime
        Private mMessageSubjectTemplate As String
        Private mMessageBodyTemplate As String
        Private mTriggerMod As Integer

        'Monitor Type metadata
        Private mMonitorTypeID As Integer
        Private mMonitorType As String
        Private mMonitorAssembly As String
        Private mEditorAssembly As String

        'Monitor Alert Rules
        Private mAlertAfterEveryNEvent As Integer
        Private mAlertAfterEveryNewFailure As Boolean
        Private mAlertAfterEveryNFailures As Integer
        Private mAlertAfterEveryFailToOK As Boolean
        Private mAlertAfterEveryNewWarning As Boolean
        Private mAlertAfterEveryNWarnings As Integer
		Private mAlertAfterEveryWarnToOK As Boolean

		'RetentionScheme
		Private mMaxMonthsRaw As Integer
		Private mMaxMonthsDaily As Integer
		Private mMaxMonthsWeekly As Integer
		Private mMaxMonthsMonthly As Integer

		'After Event Action Script
		Private mAfterEventScript As String = Nothing
		Private mAfterEventScriptEngine As ScriptEngines.ScriptEngine
		Private mAfterEventIsEnabled As Boolean = False
#End Region

#Region "Public Interface"
		Public ReadOnly Property CurrentDT() As Date
			Get
				Return mCurrentDT
			End Get
		End Property
		Public ReadOnly Property MonitorID() As Integer
			Get
				Return mMonitorID
			End Get
		End Property
		Public Property Enabled() As Boolean
			Get
				Return mIsEnabled
			End Get
			Set(ByVal Value As Boolean)
				mIsEnabled = Value
			End Set
		End Property
		Public Property MonitorName() As String
			Get
				Return mMonitorName
			End Get
			Set(ByVal Value As String)
				If Value.Length > 50 Then
					Throw New System.Exception("Monitor Name cannot exceed 50 characters")
				Else
					mMonitorName = Value
				End If
			End Set
		End Property
		Public ReadOnly Property MonitorXML() As XmlDocument
			Get
				Return mMonitorXML
			End Get
		End Property
		Public Property MonitorXMLString() As String
			Get
				Return mMonitorXMLString
			End Get
			Set(ByVal Value As String)
				mMonitorXMLString = Value
				If mMonitorXML Is Nothing Then mMonitorXML = New XmlDocument
				mMonitorXML.LoadXml(Value)
			End Set
		End Property
		Public Property OfflineTime1() As OfflineTime
			Get
				Return mOfflineTime1
			End Get
			Set(ByVal Value As OfflineTime)
				mOfflineTime1 = Value
			End Set
		End Property
		Public Property OfflineTime2() As OfflineTime
			Get
				Return mOfflineTime2
			End Get
			Set(ByVal Value As OfflineTime)
				mOfflineTime2 = Value
			End Set
		End Property
		Public Property MessageSubjectTemplate() As String
			Get
				Return mMessageSubjectTemplate
			End Get
			Set(ByVal Value As String)
				If Value.Length > 100 Then
					Throw New System.Exception("Subject Template cannot exceed 100 characters.")
				Else
					mMessageSubjectTemplate = Value
				End If
			End Set
		End Property
		Public Property MessageBodyTemplate() As String
			Get
				Return mMessageBodyTemplate
			End Get
			Set(ByVal Value As String)
				If Value.Length > 3000 Then
					Throw New System.Exception("Subject Template cannot exceed 3000 characters.")
				Else
					mMessageBodyTemplate = Value
				End If
			End Set
		End Property
		Public Property TriggerMod() As Integer
			Get
				Return mTriggerMod
			End Get
			Set(ByVal Value As Integer)
				mTriggerMod = Value
			End Set
		End Property

		Public Property AlertAfterEveryNEvent() As Integer
			Get
				Return mAlertAfterEveryNEvent
			End Get
			Set(ByVal Value As Integer)
				mAlertAfterEveryNEvent = Value
			End Set
		End Property
		Public Property AlertAfterEveryNewFailure() As Boolean
			Get
				Return mAlertAfterEveryNewFailure
			End Get
			Set(ByVal Value As Boolean)
				mAlertAfterEveryNewFailure = Value
			End Set
		End Property
		Public Property AlertAfterEveryNFailures() As Integer
			Get
				Return mAlertAfterEveryNFailures
			End Get
			Set(ByVal Value As Integer)
				mAlertAfterEveryNFailures = Value
			End Set
		End Property
		Public Property AlertAfterEveryFailToOK() As Boolean
			Get
				Return mAlertAfterEveryFailToOK
			End Get
			Set(ByVal Value As Boolean)
				mAlertAfterEveryFailToOK = Value
			End Set
		End Property
		Public Property AlertAfterEveryNewWarning() As Boolean
			Get
				Return mAlertAfterEveryNewWarning
			End Get
			Set(ByVal Value As Boolean)
				mAlertAfterEveryNewWarning = Value
			End Set
		End Property
		Public Property AlertAfterEveryNWarnings() As Integer
			Get
				Return mAlertAfterEveryNWarnings
			End Get
			Set(ByVal Value As Integer)
				mAlertAfterEveryNWarnings = Value
			End Set
		End Property
		Public Property AlertAfterEveryWarnToOK() As Boolean
			Get
				Return mAlertAfterEveryWarnToOK
			End Get
			Set(ByVal Value As Boolean)
				mAlertAfterEveryWarnToOK = Value
			End Set
		End Property

		Public Property RetentionRaw() As Integer
			Get
				Return mMaxMonthsRaw
			End Get
			Set(ByVal value As Integer)
				mMaxMonthsRaw = value
			End Set
		End Property
		Public Property RetentionDaily() As Integer
			Get
				Return mMaxMonthsDaily
			End Get
			Set(ByVal value As Integer)
				mMaxMonthsDaily = value
			End Set
		End Property
		Public Property RetentionWeekly() As Integer
			Get
				Return mMaxMonthsWeekly
			End Get
			Set(ByVal value As Integer)
				mMaxMonthsWeekly = value
			End Set
		End Property
		Public Property RetentionMonthly() As Integer
			Get
				Return mMaxMonthsMonthly
			End Get
			Set(ByVal value As Integer)
				mMaxMonthsMonthly = value
			End Set
		End Property


		Public Property MonitorTypeID() As Integer
			Get
				Return mMonitorTypeID
			End Get
			Set(ByVal Value As Integer)
				Dim IsOK As Boolean = SetMonitorType(Value)
				If IsOK Then
					mMonitorTypeID = Value
				Else
					Throw New System.Exception("Specified Monitor Type ID does not exist.")
				End If
			End Set
		End Property
		Public ReadOnly Property MonitorType() As String
			Get
				Return mMonitorType
			End Get
		End Property
		Public ReadOnly Property MonitorAssembly() As String
			Get
				Return mMonitorAssembly
			End Get
		End Property
		Public ReadOnly Property EditorAssembly() As String
			Get
				Return mEditorAssembly
			End Get
		End Property

		Public Property AfterEventIsEnabled() As Boolean
			Get
				Return mAfterEventIsEnabled
			End Get
			Set(ByVal value As Boolean)
				mAfterEventIsEnabled = value
			End Set
		End Property
		Public Property AfterEventScriptEngine() As PolyMon.ScriptEngines.ScriptEngine
			Get
				Return mAfterEventScriptEngine
			End Get
			Set(ByVal value As PolyMon.ScriptEngines.ScriptEngine)
				mAfterEventScriptEngine = value
			End Set
		End Property
		Public Property AfterEventScript() As String
			Get
				Return mAfterEventScript
			End Get
			Set(ByVal value As String)
				mAfterEventScript = value
			End Set
		End Property

		Public Sub New()
			mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
			mIsNewInstance = True
			mOfflineTime1 = New OfflineTime("00:00", "00:00")
			mOfflineTime2 = New OfflineTime("00:00", "00:00")

			Dim mDefRet As New PolyMon.General.DefaultRetentionSettings()
			mMaxMonthsRaw = mDefRet.Raw
			mMaxMonthsDaily = mDefRet.Daily
			mMaxMonthsWeekly = mDefRet.Weekly
			mMaxMonthsMonthly = mDefRet.Monthly
		End Sub
		Public Sub New(ByVal MonitorID As Integer)
			mMonitorID = MonitorID

			'Read connection string from app config
			mSQLConn = CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
			'Read Monitor metadata from database
			ReadMonitorMetadata(MonitorID)
		End Sub

		Public Sub Save()
			SaveMonitorMetadata()
		End Sub
		Public Sub Delete()
			DeleteMonitor()
		End Sub
		Public Sub DeleteData()
			DeleteMonitorData()
		End Sub
		Public Class OfflineTime
			Private mStartTime As String
			Private mEndTime As String

			Friend Sub New(ByVal StartTime As String, ByVal EndTime As String)
				mStartTime = StartTime
				mEndTime = EndTime
			End Sub

			Public Property StartTime() As String
				Get
					Return mStartTime
				End Get
				Set(ByVal Value As String)
					mStartTime = Value
				End Set
			End Property
			Public Property EndTime() As String
				Get
					Return mEndTime
				End Get
				Set(ByVal Value As String)
					mEndTime = Value
				End Set
			End Property
			Public Function IsOfflineTime() As Boolean
				'Determines if current time is within stated offline times
				Dim OffStart As Integer
				Dim OffEnd As Integer
				Dim CurrTime As Integer
				Dim IsOffline As Boolean = False

				OffStart = CInt(mStartTime.Replace(":", Nothing))
				OffEnd = CInt(mEndTime.Replace(":", Nothing))
				CurrTime = CInt(Format(Now(), "HH:mm").Replace(":", Nothing))

				If OffStart < OffEnd Then
					If CurrTime >= OffStart And CurrTime <= OffEnd Then IsOffline = True
				ElseIf OffStart > OffEnd Then
					If (CurrTime >= OffStart And CurrTime <= 2400) Or (CurrTime < OffEnd) Then IsOffline = True
				End If

				Return IsOffline
			End Function
		End Class
#End Region

#Region "Private Methods"
		Private Sub SaveMonitorMetadata()
			Dim SQLConn As New SqlConnection(mSQLConn)
			Dim sp As String = "polymon_hyb_SaveMonitorMetadata"

			'Assemble parameters into XML string
			Dim XML As New System.Text.StringBuilder

			XML.Append("<Monitor ")
			If mIsNewInstance Then
				XML.Append("MonitorID=''>")
			Else
				XML.Append("MonitorID='" & mMonitorID & "'>")
			End If
			XML.Append("<Name><![CDATA[" & mMonitorName & "]]></Name>")
			XML.Append("<MonitorTypeID>" & mMonitorTypeID & "</MonitorTypeID>")
			'XML.Append("<MonitorXML><![CDATA[" & Me.MonitorXMLString & "]]></MonitorXML>")
			XML.Append("<MonitorXML>" & XMLEncode(Me.MonitorXMLString) & "</MonitorXML>")
			XML.Append("<OfflineTime1Start>" & mOfflineTime1.StartTime & "</OfflineTime1Start>")
			XML.Append("<OfflineTime1End>" & mOfflineTime1.EndTime & "</OfflineTime1End>")
			XML.Append("<OfflineTime2Start>" & mOfflineTime2.StartTime & "</OfflineTime2Start>")
			XML.Append("<OfflineTime2End>" & mOfflineTime2.EndTime & "</OfflineTime2End>")
			XML.Append("<MessageSubjectTemplate><![CDATA[" & mMessageSubjectTemplate & "]]></MessageSubjectTemplate>")
			XML.Append("<MessageBodyTemplate><![CDATA[" & mMessageBodyTemplate & "]]></MessageBodyTemplate>")
			XML.Append("<TriggerMod>" & mTriggerMod & "</TriggerMod>")
			XML.Append("<IsEnabled>" & CStr(IIf(mIsEnabled, 1, 0)) & "</IsEnabled>")

			XML.Append("<AlertAfterEveryNEvent>" & Me.mAlertAfterEveryNEvent & "</AlertAfterEveryNEvent>")
			XML.Append("<AlertAfterEveryNewFailure>" & CStr(IIf(Me.AlertAfterEveryNewFailure, 1, 0)) & "</AlertAfterEveryNewFailure>")
			XML.Append("<AlertAfterEveryNFailures>" & Me.mAlertAfterEveryNFailures & "</AlertAfterEveryNFailures>")
			XML.Append("<AlertAfterEveryFailToOK>" & CStr(IIf(Me.AlertAfterEveryFailToOK, 1, 0)) & "</AlertAfterEveryFailToOK>")
			XML.Append("<AlertAfterEveryNewWarning>" & CStr(IIf(Me.AlertAfterEveryNewWarning, 1, 0)) & "</AlertAfterEveryNewWarning>")
			XML.Append("<AlertAfterEveryNWarnings>" & Me.AlertAfterEveryNWarnings & "</AlertAfterEveryNWarnings>")
			XML.Append("<AlertAfterEveryWarnToOK>" & CStr(IIf(Me.AlertAfterEveryWarnToOK, 1, 0)) & "</AlertAfterEveryWarnToOK>")

			XML.AppendFormat("<RetentionMaxMonthsRaw>{0}</RetentionMaxMonthsRaw>", mMaxMonthsRaw.ToString())
			XML.AppendFormat("<RetentionMaxMonthsDaily>{0}</RetentionMaxMonthsDaily>", mMaxMonthsDaily.ToString())
			XML.AppendFormat("<RetentionMaxMonthsWeekly>{0}</RetentionMaxMonthsWeekly>", mMaxMonthsWeekly.ToString())
			XML.AppendFormat("<RetentionMaxMonthsMonthly>{0}</RetentionMaxMonthsMonthly>", mMaxMonthsMonthly.ToString())


			XML.Append("</Monitor>")

			Dim prmXML As New SqlParameter
			With prmXML
				.ParameterName = "@MetadataXML"
				.SqlDbType = SqlDbType.NText
				.Direction = ParameterDirection.Input
				.Value = XML.ToString()
			End With

			Dim prmMonitorID As New SqlParameter
			With prmMonitorID
				.ParameterName = "@MonitorID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Output
			End With

			Dim sqlCmd As New SqlCommand
			With sqlCmd
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = sp
				.Parameters.Add(prmXML)
				.Parameters.Add(prmMonitorID)
			End With

			Try
				SQLConn.Open()

				'Save Monitor Metadata
				sqlCmd.ExecuteNonQuery()
				mMonitorID = CInt(prmMonitorID.Value)
				mIsNewInstance = False

				'Save Monitor Action Scripts
				'After Event trigger
				If String.IsNullOrEmpty(mAfterEventScript) Then mAfterEventIsEnabled = False

				sqlCmd.CommandText = "polymon_hyb_SaveMonitorActionScript"
				sqlCmd.Parameters.Clear()
				Dim prmActionMonitorID As New SqlParameter
				With prmActionMonitorID
					.ParameterName = "@MonitorID"
					.SqlDbType = SqlDbType.Int
					.Direction = ParameterDirection.Input
					.Value = mMonitorID
				End With
				Dim prmTriggerTypeID As New SqlParameter
				With prmTriggerTypeID
					.ParameterName = "@TriggerTypeID"
					.SqlDbType = SqlDbType.TinyInt
					.Direction = ParameterDirection.Input
					.Value = 0 'After Event trigger type
				End With
				Dim prmIsEnabled As New SqlParameter
				With prmIsEnabled
					.ParameterName = "@IsEnabled"
					.SqlDbType = SqlDbType.Bit
					.Direction = ParameterDirection.Input
					.Value = mAfterEventIsEnabled
				End With
				Dim prmScriptEngineID As New SqlParameter
				With prmScriptEngineID
					.ParameterName = "@ScriptEngineID"
					.SqlDbType = SqlDbType.TinyInt
					.Direction = ParameterDirection.Input
					.Value = CInt(mAfterEventScriptEngine.EngineID)
				End With
				Dim prmScript As New SqlParameter
				With prmScript
					.ParameterName = "@Script"
					.SqlDbType = SqlDbType.NText
					.Direction = ParameterDirection.Input
					.Value = mAfterEventScript
				End With
				sqlCmd.Parameters.Add(prmActionMonitorID)
				sqlCmd.Parameters.Add(prmTriggerTypeID)
				sqlCmd.Parameters.Add(prmIsEnabled)
				sqlCmd.Parameters.Add(prmScriptEngineID)
				sqlCmd.Parameters.Add(prmScript)
				sqlCmd.ExecuteNonQuery()
			Catch ex As Exception
				Throw New System.Exception(ex.Message, ex)
			Finally
				sqlCmd.Dispose()
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End Try
		End Sub
		Private Sub DeleteMonitor()
			Dim SQLConn As New SqlConnection(mSQLConn)
			Dim sp As String = "polymon_del_DeleteMonitor"

			Dim prmMonitorID As New SqlParameter
			With prmMonitorID
				.ParameterName = "@MonitorID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Input
				.Value = mMonitorID
			End With

			Dim sqlCmd As New SqlCommand
			With sqlCmd
				.Connection = SQLConn
				.CommandTimeout = 10 * 60 '10 minutes
				.CommandType = CommandType.StoredProcedure
				.CommandText = sp
				.Parameters.Add(prmMonitorID)
			End With

			Try
				SQLConn.Open()
				sqlCmd.ExecuteNonQuery()
				SQLConn.Close()
				ClearClassData()
			Catch ex As Exception
				Throw New System.Exception(ex.Message, ex)
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End Try
		End Sub
		Private Sub DeleteMonitorData()
			Dim SQLConn As New SqlConnection(mSQLConn)
			Dim sp As String = "polymon_del_MonitorData"

			Dim prmMonitorID As New SqlParameter
			With prmMonitorID
				.ParameterName = "@MonitorID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Input
				.Value = mMonitorID
			End With

			Dim sqlCmd As New SqlCommand
			With sqlCmd
				.Connection = SQLConn
				.CommandTimeout = 10 * 60 '10 minutes
				.CommandType = CommandType.StoredProcedure
				.CommandText = sp
				.Parameters.Add(prmMonitorID)
			End With

			Try
				SQLConn.Open()
				sqlCmd.ExecuteNonQuery()
				SQLConn.Close()
			Catch ex As Exception
				Throw New System.Exception(ex.Message, ex)
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End Try
		End Sub
		Private Sub ClearClassData()
			mIsNewInstance = Nothing

			'Monitor metadata
			mIsEnabled = Nothing
			mMonitorID = Nothing
			mMonitorName = Nothing
			mMonitorXML = Nothing
			mOfflineTime1 = New OfflineTime("00:00", "00:00")
			mOfflineTime2 = New OfflineTime("00:00", "00:00")
			mMessageSubjectTemplate = Nothing
			mMessageBodyTemplate = Nothing
			mTriggerMod = Nothing


			'Monitor Type metadata
			mMonitorTypeID = Nothing
			mMonitorType = Nothing
			mMonitorAssembly = Nothing
			mEditorAssembly = Nothing

			'Monitor Alert Rules
			mAlertAfterEveryNEvent = Nothing
			mAlertAfterEveryNewFailure = Nothing
			mAlertAfterEveryNFailures = Nothing
			mAlertAfterEveryFailToOK = Nothing
			mAlertAfterEveryNewWarning = Nothing
			mAlertAfterEveryNWarnings = Nothing
			mAlertAfterEveryWarnToOK = Nothing

			'Action Scripts
			mAfterEventScriptEngine = Nothing
			mAfterEventScript = Nothing
			mAfterEventIsEnabled = False
		End Sub
		Private Sub ReadMonitorMetadata(ByVal MonitorID As Integer)
			Dim SQLConn As New SqlConnection(mSQLConn)
			Dim sp As String = "polymon_sel_MonitorMetadata"

			Dim prmMonitorID As New SqlParameter
			With prmMonitorID
				.ParameterName = "@MonitorID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Input
				.Value = MonitorID
			End With

			Dim sqlCmd As New SqlCommand
			sqlCmd.Connection = SQLConn
			sqlCmd.CommandType = CommandType.StoredProcedure
			sqlCmd.CommandText = sp
			sqlCmd.Parameters.Add(prmMonitorID)

			Try
				SQLConn.Open()
				Dim drMonitor As SqlDataReader = sqlCmd.ExecuteReader()
				With drMonitor
					.Read()
					mCurrentDT = CDate(.Item("MetadataCurrentDT"))
					mIsEnabled = CBool(.Item("IsEnabled"))
					mMonitorName = CStr(.Item("Name"))

                    If String.IsNullOrEmpty(CStr(.Item("MonitorXML"))) Then
                        mMonitorXMLString = Nothing
                        mMonitorXML = Nothing
                    Else
                        mMonitorXMLString = CStr(.Item("MonitorXML"))
                        mMonitorXML = New XmlDocument
                        mMonitorXML.LoadXml(CStr((.Item("MonitorXML"))))
                    End If

                    mOfflineTime1 = New OfflineTime(CStr(.Item("OfflineTime1Start")), CStr(.Item("OfflineTime1End")))
                    mOfflineTime2 = New OfflineTime(CStr(.Item("OfflineTime2Start")), CStr(.Item("OfflineTime2End")))
                    mMessageSubjectTemplate = CStr(.Item("MessageSubjectTemplate"))
                    If IsDBNull(.Item("MessageBodyTemplate")) OrElse .Item("MessageBodyTemplate") Is Nothing Then
                        mMessageBodyTemplate = Nothing
                    Else
                        mMessageBodyTemplate = CStr(.Item("MessageBodyTemplate"))
                    End If
                    mTriggerMod = CInt(.Item("TriggerMod"))

                    mMonitorTypeID = CInt(.Item("MonitorTypeID"))
                    mMonitorType = CStr(.Item("MonitorTypeName"))
                    mMonitorAssembly = CStr(.Item("MonitorAssembly"))
                    mEditorAssembly = CStr(.Item("EditorAssembly"))

                    mAlertAfterEveryNEvent = CInt(.Item("AlertAfterEveryNEvent"))
                    mAlertAfterEveryNewFailure = CBool(.Item("AlertAfterEveryNewFailure"))
                    mAlertAfterEveryNFailures = CInt(.Item("AlertAfterEveryNFailures"))
                    mAlertAfterEveryFailToOK = CBool(.Item("AlertAfterEveryFailToOK"))
                    mAlertAfterEveryNewWarning = CBool(.Item("AlertAfterEveryNewWarning"))
                    mAlertAfterEveryNWarnings = CInt(.Item("AlertAfterEveryNWarnings"))
                    mAlertAfterEveryWarnToOK = CBool(.Item("AlertAfterEveryWarnToOK"))


                    mMaxMonthsRaw = CInt(.Item("MaxMonthsRaw"))
                    mMaxMonthsDaily = CInt(.Item("MaxMonthsDaily"))
                    mMaxMonthsWeekly = CInt(.Item("MaxMonthsWeekly"))
                    mMaxMonthsMonthly = CInt(.Item("MaxMonthsMonthly"))

                    mIsNewInstance = False
				End With


				'Read Action Scripts
				drMonitor.Close()
				sqlCmd.CommandText = "polymon_sel_MonitorActionScripts"
				If SQLConn.State <> ConnectionState.Open Then SQLConn.Open()
				Dim drActionScripts As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
				With drActionScripts
					While drActionScripts.Read()
						Select Case CInt(.Item("TriggerTypeID"))
							Case 0 'After Event
								mAfterEventIsEnabled = CBool(.Item("IsEnabled"))
								Dim ScriptEngines As New PolyMon.ScriptEngines.ScriptEngines
								Dim EngineID As Integer = CInt(.Item("ScriptEngineID"))
								mAfterEventScriptEngine = ScriptEngines.ScriptEngine(EngineID)
								If IsDBNull(.Item("Script")) Then
									mAfterEventScript = Nothing
								Else
									mAfterEventScript = CStr(.Item("Script"))
								End If
							Case 1 'On OK
								'Not implemented
							Case 2 'On Warning
								'Not implemented
							Case 3 'On Failure
								'Not implemented
						End Select
					End While
				End With
			Catch ex As Exception
				Throw New System.Exception(ex.Message, ex)
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End Try
		End Sub
		Private Function SetMonitorType(ByVal MonitorTypeID As Integer) As Boolean
			Dim SQLConn As New SqlConnection(mSQLConn)
			Dim sp As String = "polymon_sel_MonitorTypeMetadata"
			Dim IsOK As Boolean = False

			Dim prmMonitorTypeID As New SqlParameter
			With prmMonitorTypeID
				.ParameterName = "@MonitorTypeID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Input
				.Value = MonitorTypeID
			End With

			Dim sqlCmd As New SqlCommand
			With sqlCmd
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = sp
				.Parameters.Add(prmMonitorTypeID)
			End With

			Try
				SQLConn.Open()
				Dim drMonitorType As SqlDataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
				If Not (drMonitorType.HasRows) Then
					IsOK = False
				Else
					drMonitorType.Read()
					With drMonitorType
						mMonitorType = CStr(.Item("Name"))
						mMonitorAssembly = CStr(.Item("MonitorAssembly"))
						mEditorAssembly = CStr(.Item("EditorAssembly"))
					End With
					IsOK = True
				End If
			Catch ex As Exception
				Throw New System.Exception(ex.Message, ex)
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
				sqlCmd.Dispose()
			End Try

			Return IsOK
		End Function

		Private Function XMLEncode(ByVal XMLString As String) As String
			Dim tmpStr As String = XMLString

			tmpStr = tmpStr.Replace("&", "&amp;")
			tmpStr = tmpStr.Replace("<", "&lt;")
			tmpStr = tmpStr.Replace(">", "&gt;")
			tmpStr = tmpStr.Replace("""", "&quot;")
			tmpStr = tmpStr.Replace("'", "&apos;")

			Return tmpStr
		End Function

		Private Function XMLDecode(ByVal XMLString As String) As String
			Dim tmpStr As String = XMLString

			tmpStr = tmpStr.Replace("&amp;", "&")
			tmpStr = tmpStr.Replace("&lt;", "<")
			tmpStr = tmpStr.Replace("&gt;", ">")
			tmpStr = tmpStr.Replace("&quot;", """")
			tmpStr = tmpStr.Replace("&apos;", "'")

			Return tmpStr
		End Function

#End Region

	End Class
End Namespace