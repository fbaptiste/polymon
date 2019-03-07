Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports PolyMon.Status

'<SQLMonitor>
'	<ConnectionString>...</ConnectionString>
'	<SP>
'		<Name>...</Name>
'		<Parameters>
'			<Parameter Name="...">...</Parameter>
'			...
'		</Parameters>
'	</SP>
'</SQLMonitor>

Namespace Monitors
    Public Class SQLMonitor
        Inherits PolyMon.Monitors.MonitorExecutor

        Public Sub New(ByVal MonitorID As Integer)
            MyBase.New(MonitorID)
        End Sub

		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As MonitorExecutor.MonitorStatus
			'Read Monitor configuration from XML
			Dim ConnectionString As String = Nothing
			Dim SPName As String = Nothing
			Dim Parameters As New Dictionary(Of String, String)


			Dim SQLConn As New System.Data.OleDb.OleDbConnection

			Try

				Dim RootNode As XmlNode = MonitorXML.DocumentElement

				ConnectionString = ReadXMLNodeValue(RootNode.SelectSingleNode("ConnectionString"))

				Dim SPNode As XmlNode = RootNode.SelectSingleNode("SP")
				SPName = ReadXMLNodeValue(SPNode.SelectSingleNode("Name"))

				With SQLConn
					.ConnectionString = ConnectionString
				End With

				Dim SP As New System.Data.OleDb.OleDbCommand
				With SP
					.CommandType = CommandType.StoredProcedure
					.CommandText = SPName
					.Connection = SQLConn

					Dim ParamName As String = Nothing
					Dim ParamValue As String = Nothing
					For Each xmlNode As XmlNode In SPNode.SelectSingleNode("Parameters").ChildNodes
						ParamName = ReadXMLAttributeValue(xmlNode.Attributes("Name"))
						ParamValue = ReadXMLNodeValue(xmlNode)
						SP.Parameters.AddWithValue(ParamName, ParamValue)
					Next
				End With

				Dim prmStatusCode As New OleDbParameter
				With prmStatusCode
					.ParameterName = "@StatusCode"
					.Direction = ParameterDirection.InputOutput
					.DbType = DbType.Int16
					.Value = DBNull.Value
				End With
				SP.Parameters.Add(prmStatusCode)

				Dim prmStatusMessage As New OleDbParameter
				With prmStatusMessage
					.ParameterName = "@StatusMessage"
					.Direction = ParameterDirection.InputOutput
					.DbType = DbType.String
					.Size = 8000
					.Value = DBNull.Value
				End With
				SP.Parameters.Add(prmStatusMessage)


				SQLConn.Open()
				Dim rd As OleDb.OleDbDataReader = SP.ExecuteReader()

				While rd.Read()
					Counters.Add(New Counter(CStr(rd.Item("Counter")), CDbl(rd.Item("Value"))))
				End While
				rd.Close() 'Reader has to be closed *before* any return values can be read

				Dim SQLStatus As String = CStr(prmStatusMessage.Value)
				Dim SQLRet As Integer = CInt(prmStatusCode.Value)


				If SQLStatus = Nothing OrElse SQLStatus.Trim.Length = 0 Then
					StatusMessage = "OK."
				Else
					StatusMessage = SQLStatus
				End If

				Select Case SQLRet
					Case 1
						Return MonitorStatus.OK
					Case 2
						Return MonitorStatus.Warn
					Case Else
						Return MonitorStatus.Fail
				End Select

			Catch ex As Exception
				'Return Fail and error message
				StatusMessage = ex.Message
				Return MonitorStatus.Fail
			Finally
				If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
				SQLConn.Dispose()
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