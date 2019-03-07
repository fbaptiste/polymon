Imports System.Net.Mail
Imports System.Net
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Text
Imports System.IO


Namespace Notifier
	Public Class PolyMonMailer
		Private mSQLConn As String = Nothing
		Private mSMTPClient As SmtpClient
		Private mSMTPFromName As String
		Private mSMTPFromAddress As String

		Public Sub New()
			mSQLConn = GetSQLConnStr()
			If String.IsNullOrEmpty(mSQLConn) Then Throw New Exception("Database connection string was not found.")
			BuildSMTPClient()
		End Sub

		Public Sub ProcessPendingEmailNotifications(Optional ByVal MaxBatchSize As Integer = 100)
			'Handle any pending Operator Notifications (Non-Queued notifications)

			Dim spSelect As String = "polymon_sel_PendingEmailAlerts"
			Dim spMarkSent As String = "polymon_hyb_MarkEmailSent"

			Dim SQLConn As New SqlConnection(mSQLConn)

			'Command - Get Email Batch
			Dim cmdEmails As New SqlCommand
			Dim prmMaxBatchSize As New SqlParameter("@MaxCount", SqlDbType.Int)
			With prmMaxBatchSize
				.Direction = ParameterDirection.Input
				.Value = MaxBatchSize
			End With
			With cmdEmails
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = spSelect
				.Parameters.Add(prmMaxBatchSize)
			End With

			'Command - Mark Email Sent
			Dim cmdMarkSent As New SqlCommand
			Dim prmAlertID As New SqlParameter("@AlertID", SqlDbType.Int)
			prmAlertID.Direction = ParameterDirection.Input
			Dim prmOperatorID As New SqlParameter("@OperatorID", SqlDbType.Int)
			prmOperatorID.Direction = ParameterDirection.Input
			With cmdMarkSent
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = spMarkSent
				.Parameters.Add(prmAlertID)
				.Parameters.Add(prmOperatorID)
			End With


			Dim tblEmails As DataTable = Nothing
			Dim daEmails As New SqlDataAdapter
			daEmails.SelectCommand = cmdEmails
			Dim dsEmails As New DataSet
			Dim drEmail As DataRow

			Try
				SQLConn.Open()
				daEmails.Fill(dsEmails)
				If dsEmails.Tables.Count > 0 Then
					tblEmails = dsEmails.Tables(0)

					For Each drEmail In tblEmails.Rows
						'Process each email and mark sent
						Dim AlertID As Integer = CInt(drEmail.Item("AlertID"))
						Dim OperatorID As Integer = CInt(drEmail.Item("OperatorID"))
						Dim Name As String = CStr(drEmail.Item("Name"))
						Dim EmailAddress As String = CStr(drEmail.Item("EmailAddress"))
						Dim IncludeMessageBody As Boolean = CBool(drEmail.Item("IncludeMessageBody"))
						Dim MessageSubject As String = CStr(drEmail.Item("MessageSubject"))
						Dim MessageBody As String = Nothing
						If IncludeMessageBody Then
							MessageBody = CStr(drEmail.Item("MessageBody"))
						End If


						Try
							'Send email
							If IncludeMessageBody Then
								SendMail(EmailAddress, Name, MessageSubject, MessageBody, False)
							Else
								SendMail(EmailAddress, Name, MessageSubject, Nothing, False)
							End If

							'And mark as sent
							prmAlertID.Value = AlertID
							prmOperatorID.Value = OperatorID
							cmdMarkSent.ExecuteNonQuery()
						Catch ex As Exception
							'TODO: Log error somewhere???
							'Ignore for now...
						End Try
					Next
				End If 'Tables > 0
			Catch ex As Exception
				Throw ex
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				dsEmails.Dispose()
				daEmails.Dispose()
				SQLConn.Dispose()
			End Try

		End Sub

		Public Sub ProcessQueuedNotifications(Optional ByVal MaxBatchSize As Integer = 100)
			'Handle any queued Notifications that need to be sent individually (i.e. not summarized in a Recap email)

			Dim spSelect As String = "polymon_sel_QueuedEmailAlerts"
			Dim spMarkSent As String = "polymon_hyb_MarkEmailSent"


			Dim SQLConn As New SqlConnection(mSQLConn)

			'Command - Get Email Batch
			Dim cmdEmails As New SqlCommand
			Dim prmMaxBatchSize As New SqlParameter("@MaxCount", SqlDbType.Int)
			With prmMaxBatchSize
				.Direction = ParameterDirection.Input
				.Value = MaxBatchSize
			End With
			With cmdEmails
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = spSelect
				.Parameters.Add(prmMaxBatchSize)
			End With

			'Command - Mark Email Sent
			Dim cmdMarkSent As New SqlCommand
			Dim prmAlertID As New SqlParameter("@AlertID", SqlDbType.Int)
			prmAlertID.Direction = ParameterDirection.Input
			Dim prmOperatorID As New SqlParameter("@OperatorID", SqlDbType.Int)
			prmOperatorID.Direction = ParameterDirection.Input
			With cmdMarkSent
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = spMarkSent
				.Parameters.Add(prmAlertID)
				.Parameters.Add(prmOperatorID)
			End With


			Dim tblEmails As DataTable = Nothing
			Dim daEmails As New SqlDataAdapter
			daEmails.SelectCommand = cmdEmails
			Dim dsEmails As New DataSet
			Dim drEmail As DataRow

			Try
				SQLConn.Open()
				daEmails.Fill(dsEmails)
				If dsEmails.Tables.Count > 0 Then
					tblEmails = dsEmails.Tables(0)

					For Each drEmail In tblEmails.Rows
						'Process each email and mark sent
						Dim AlertID As Integer = CInt(drEmail.Item("AlertID"))
						Dim OperatorID As Integer = CInt(drEmail.Item("OperatorID"))
						Dim Name As String = CStr(drEmail.Item("Name"))
						Dim EmailAddress As String = CStr(drEmail.Item("EmailAddress"))
						Dim IncludeMessageBody As Boolean = CBool(drEmail.Item("IncludeMessageBody"))
						Dim MessageSubject As String = CStr(drEmail.Item("MessageSubject"))
						Dim MessageBody As String = Nothing
						If IncludeMessageBody Then
							MessageBody = CStr(drEmail.Item("MessageBody"))
						End If


						Try
							'Send email
							If IncludeMessageBody Then
								SendMail(EmailAddress, Name, MessageSubject, MessageBody, False)
							Else
								SendMail(EmailAddress, Name, MessageSubject, Nothing, False)
							End If

							'And mark as sent
							prmAlertID.Value = AlertID
							prmOperatorID.Value = OperatorID
							cmdMarkSent.ExecuteNonQuery()
						Catch ex As Exception
							'TODO: Log error somewhere???
							'Ignore for now...
						End Try
					Next
				End If 'Tables > 0
			Catch ex As Exception
				Throw ex
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				dsEmails.Dispose()
				daEmails.Dispose()
				SQLConn.Dispose()
			End Try

		End Sub

		Public Sub ProcessPendingRecapNotifications()
			'Retrieve any Recap Alerts from server
			'Send each Operator recap email and mark alerts as Sent for that operator
			'Recap email body is generated using xslt (which must be present in root directory of PolyMon Executive)

			'TODO: Include XSLT in Install Scripts targeting PolyMon Executive binary folder

			Dim spSelect As String = "polymon_sel_RecapEmailAlerts"
			Dim spMarkSent As String = "polymon_hyb_SetQueuedAlertsSent"

			Dim SQLConn As New SqlConnection(mSQLConn)

			Dim cmdRecapAlerts As New SqlCommand
			With cmdRecapAlerts	'Returns an XML set
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = spSelect
			End With

			Dim prmOperatorID As New SqlParameter
			With prmOperatorID
				.ParameterName = "@OperatorID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Input
			End With
			Dim cmdMarkSent As New SqlCommand
			With cmdMarkSent
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = spMarkSent
				.Parameters.Add(prmOperatorID)
			End With

			Dim sbXML As New StringBuilder

			Try
				'Load XSLT 
				Dim str As New StreamReader(My.Application.Info.DirectoryPath & "\AlertRecap_Email.xsl")
				Dim XSLT As String = str.ReadToEnd()
				str.Close()

				SQLConn.Open()
				Dim xr1 As XmlReader = cmdRecapAlerts.ExecuteXmlReader()
				xr1.Read()
				Do While xr1.ReadState <> ReadState.EndOfFile
					sbXML.Append(xr1.ReadOuterXml)
				Loop
				xr1.Close()

				Dim xmlResults As New XmlDocument
				xmlResults.LoadXml(sbXML.ToString)
				Dim nodOperators As XmlNode = xmlResults.DocumentElement

				'Loop through each operator and send email / mark as sent
				For Each nodOperator As XmlNode In xmlResults.SelectNodes("//Operator")
					Dim OperatorID As Integer = CInt(nodOperator.Attributes("OperatorID").Value)
					Dim MessageXML As String = nodOperator.OuterXml.ToString
					Dim myOperator As New PolyMon.Operators.PMOperator(OperatorID)

					Dim myXML As New XmlDocument
					myXML.LoadXml(MessageXML)
					Dim EmailBody As String = TransformXML(myXML, XSLT)

					'Send Email
					SendMail(myOperator.EmailAddress, myOperator.Name, "PolyMon - Notification Recap", EmailBody, True)

					'Mark Notifications as sent
					prmOperatorID.Value = OperatorID
					cmdMarkSent.ExecuteNonQuery()
				Next
			Catch ex As Exception
				Throw ex
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End Try
		End Sub

		Public Sub ProcessPendingSummaryNotifications()
			'TODO: Include XSLT in Install Scripts targeting PolyMon Executive binary folder

			Dim spOperatorList As String = "polymon_sel_SummaryNotificationReadyOperators"
			Dim spGetMessageXML As String = "polymon_sel_OperatorCurrentMonitorStatus"
			Dim spMarkSent As String = "polymon_hyb_OperatorSummaryNotificationSent"

			Dim SQLConn As New SqlConnection(mSQLConn)

			Dim cmdOperatorList As New SqlCommand
			With cmdOperatorList	'Returns an XML set
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = spOperatorList
			End With

			Dim prmOperatorID As New SqlParameter
			With prmOperatorID
				.ParameterName = "@OperatorID"
				.SqlDbType = SqlDbType.Int
				.Direction = ParameterDirection.Input
			End With

			Dim prmIncludeOK As New SqlParameter
			With prmIncludeOK
				.ParameterName = "@IncludeOK"
				.SqlDbType = SqlDbType.Bit
				.Direction = ParameterDirection.Input
			End With
			Dim prmIncludeWarn As New SqlParameter
			With prmIncludeWarn
				.ParameterName = "@IncludeWarn"
				.SqlDbType = SqlDbType.Bit
				.Direction = ParameterDirection.Input
			End With
			Dim prmIncludeFail As New SqlParameter
			With prmIncludeFail
				.ParameterName = "@IncludeFail"
				.SqlDbType = SqlDbType.Bit
				.Direction = ParameterDirection.Input
			End With

			Dim cmdGetMessage As New SqlCommand
			With cmdGetMessage
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = spGetMessageXML
				.Parameters.Add(prmOperatorID)
				.Parameters.Add(prmIncludeOK)
				.Parameters.Add(prmIncludeWarn)
				.Parameters.Add(prmIncludeFail)
			End With

			Dim prmSentOperatorID As New SqlParameter
			With prmSentOperatorID
				.ParameterName = "@OperatorID"
				.Direction = ParameterDirection.Input
				.SqlDbType = SqlDbType.Int
			End With
			Dim cmdMarkSent As New SqlCommand
			With cmdMarkSent
				.Connection = SQLConn
				.CommandType = CommandType.StoredProcedure
				.CommandText = spMarkSent
				.Parameters.Add(prmSentOperatorID)
			End With

			Dim OperatorList As New List(Of PolyMon.Operators.PMOperator)
			Dim sbXML As StringBuilder = Nothing

			Try
				'Load XSLT 
				Dim str As New StreamReader(My.Application.Info.DirectoryPath & "\Heartbeat_Email.xsl")
				Dim XSLT As String = str.ReadToEnd()
				str.Close()

				SQLConn.Open()

				'Read in Operators
				Dim rdOperators As SqlDataReader = cmdOperatorList.ExecuteReader()
				While rdOperators.Read()
					OperatorList.Add(New PolyMon.Operators.PMOperator(CInt(rdOperators.Item("OperatorID"))))
				End While
				rdOperators.Close()

				'For each Operator, retrieve Email data and send it, then mark as sent
				For Each myOperator As PolyMon.Operators.PMOperator In OperatorList

					'Retrieve data from database
					prmOperatorID.Value = myOperator.OperatorID
					prmIncludeOK.Value = myOperator.SummaryNotifyOK
					prmIncludeWarn.Value = myOperator.SummaryNotifyWarn
					prmIncludeFail.Value = myOperator.SummaryNotifyFail

					sbXML = New StringBuilder
					Dim xr1 As XmlReader = cmdGetMessage.ExecuteXmlReader()
					xr1.Read()
					Do While xr1.ReadState <> ReadState.EndOfFile
						sbXML.Append(xr1.ReadOuterXml)
					Loop
					xr1.Close()

					Dim xmlData As New XmlDocument
					xmlData.LoadXml(sbXML.ToString)

					'Transform data using XSLT
					Dim EmailBody As String = TransformXML(xmlData, XSLT)

					'Send Email
					SendMail(myOperator.EmailAddress, myOperator.Name, "PolyMon - Summary Notification", EmailBody, True)

					'And mark as sent
					prmSentOperatorID.Value = myOperator.OperatorID
					cmdMarkSent.ExecuteNonQuery()
				Next
			Catch ex As Exception
				Throw ex
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
			End Try

		End Sub



		Public Sub SendMail(ByVal ToAddress As String, ByVal ToName As String, ByVal Subject As String, ByVal Body As String, ByVal IsHtml As Boolean)
			Dim Mail As New Mail.MailMessage
			With Mail
				.From = New MailAddress(mSMTPFromAddress, mSMTPFromName)
				.To.Add(New MailAddress(ToAddress, ToName))
				.Subject = Subject
				.Body = Body
				.IsBodyHtml = IsHtml
			End With

			mSMTPClient.Send(Mail)
		End Sub



		Private Function TransformXML(ByVal XMLDoc As XmlDocument, ByVal SourceXSLT As String) As String
			'Load Stylesheet
			Dim clsStream As System.IO.MemoryStream = New System.IO.MemoryStream()
			Dim clsWriter As System.IO.StreamWriter = New System.IO.StreamWriter(clsStream)
			clsWriter.Write(SourceXSLT)
			clsWriter.Flush()
			clsStream.Position = 0
			Dim clsReader As System.Xml.XmlReader = New System.Xml.XmlTextReader(clsStream)
			Dim clsStylesheet As System.Xml.Xsl.XslCompiledTransform = New System.Xml.Xsl.XslCompiledTransform()
			clsStylesheet.Load(clsReader)

			'Apply transform
			' apply the transformation to the specified xml... 
			clsStream = New System.IO.MemoryStream()
			Dim clsTransform As System.Xml.XmlWriter = New System.Xml.XmlTextWriter(clsStream, System.Text.Encoding.ASCII)
			clsStylesheet.Transform(XMLDoc, clsTransform)
			clsStream.Position = 0

			' extract content... 
			Dim bValue As Byte() = DirectCast(Array.CreateInstance(GetType(Byte), clsStream.Length), Byte())
			clsStream.Read(bValue, 0, Convert.ToInt32(clsStream.Length))

			' release... 
			clsStream.Close()
			clsStream.Dispose()
			clsTransform.Close()
			clsTransform = Nothing

			' return... 
			Return System.Text.UTF8Encoding.UTF8.GetString(bValue)
		End Function

		Private Sub BuildSMTPClient()
			Dim SysSettings As New PolyMon.General.SysSettings()
			mSMTPClient = New SmtpClient

			With mSMTPClient
				.Host = SysSettings.ExtSMTPServer
				.Port = SysSettings.ExtSMTPPort
				.EnableSsl = SysSettings.ExtSMTPUseSSL
				If Not String.IsNullOrEmpty(SysSettings.ExtSMTPUserID) Then
					.Credentials = New NetworkCredential(SysSettings.ExtSMTPUserID, SysSettings.ExtSMTPPwd)
				End If
			End With
			mSMTPFromName = SysSettings.SMTPFromName
			mSMTPFromAddress = SysSettings.SMTPFromAddress
		End Sub

		Private Function GetSQLConnStr() As String
			Try
				Return CStr(System.Configuration.ConfigurationManager.AppSettings("SQLConn"))
			Catch ex As Exception
				Return Nothing
			End Try
		End Function
	End Class
End Namespace