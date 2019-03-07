Imports System.Xml
Imports System.Management
Imports PolyMon.Status

Namespace monitors
	'<WMIMonitor>
	'	<Host>...</Host>
	'	<MonitorQuery>..</MonitorQuery>
	'	<CounterQuery>...</CounterQuery>
	'	<Failure Enable="0|1" Operator="<|>" Value="..."/>
	'	<Warning Enable="0|1" Operator="<|>" Value="..."/>
	'</WMIMonitor>
	Public Class WMIMonitor
		Inherits PolyMon.monitors.MonitorExecutor

		Public Sub New(ByVal MonitorID As Integer)
			MyBase.New(MonitorID)
		End Sub

		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As MonitorExecutor.MonitorStatus
			Dim Host As String = Nothing
			Dim MonitorQueryString As String = Nothing
			Dim CounterQueryString As String = Nothing
			Dim EnableFailures As Boolean = False
			Dim FailureOperator As String = Nothing
			Dim FailureValue As Double = 0
			Dim EnableWarnings As Boolean = False
			Dim WarningOperator As String = Nothing
			Dim WarningValue As Double = 0


			Dim RootNode As XmlNode = Me.MonitorXML.DocumentElement
			Dim NodeValue As String

			StatusMessage = ""

			Try
				'Host
				Host = ReadXMLNodeValue(RootNode.SelectSingleNode("Host"))
				If String.IsNullOrEmpty(Host) Then Host = "localhost"

				'MonitorQueryString
				MonitorQueryString = ReadXMLNodeValue(RootNode.SelectSingleNode("MonitorQuery"))

				'CounterQueryString
				CounterQueryString = ReadXMLNodeValue(RootNode.SelectSingleNode("CounterQuery"))

				'EnableFailures
				NodeValue = Me.ReadXMLAttributeValue(RootNode.SelectSingleNode("Failure").Attributes("Enable"))
				EnableFailures = CBool(IIf(NodeValue Is Nothing, 0, NodeValue))
				If EnableFailures Then
					'FailureOperator
					FailureOperator = ReadXMLAttributeValue(RootNode.SelectSingleNode("Failure").Attributes("Operator"))
					If FailureOperator <> "<" AndAlso FailureOperator <> ">" Then
						EnableFailures = False
					Else
						'Failure Value
						NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("Failure").Attributes("Value"))
						If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) Then
							EnableFailures = False
						Else
							FailureValue = CDbl(NodeValue)
						End If
					End If
				End If
				'EnableWarnings
				NodeValue = Me.ReadXMLAttributeValue(RootNode.SelectSingleNode("Warning").Attributes("Enable"))
				EnableWarnings = CBool(IIf(NodeValue Is Nothing, 0, NodeValue))
				If EnableWarnings Then
					'WarningOperator
					WarningOperator = ReadXMLAttributeValue(RootNode.SelectSingleNode("Warning").Attributes("Operator"))
					If WarningOperator <> "<" AndAlso WarningOperator <> ">" Then
						EnableWarnings = False
					Else
						'Warning Value
						NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("Warning").Attributes("Value"))
						If String.IsNullOrEmpty(NodeValue) OrElse Not (IsNumeric(NodeValue)) Then
							EnableWarnings = False
						Else
							WarningValue = CDbl(NodeValue)
						End If
					End If
				End If

				Dim Scope As ManagementScope
				Dim Options As EnumerationOptions
				Dim Searcher As ManagementObjectSearcher
				Dim WMIChild As ManagementObject
				Dim DisplayName As String = Nothing
				Dim Cnt As Integer = 0
				Dim Results As ManagementObjectCollection

				'***** Run and retrieve Counters from Counter Query *****
				Try
					If String.IsNullOrEmpty(CounterQueryString) Then
						'No Counter Query was specified - nothing to run
					Else
						Dim CounterQuery As SelectQuery = New SelectQuery(CounterQueryString)
						'Make Sure Name property is returned so we can figure out instance names
						If CounterQuery.SelectedProperties.Count > 0 AndAlso Not (CounterQuery.SelectedProperties.Contains("Name")) Then CounterQuery.SelectedProperties.Add("Name")
						If CounterQuery.SelectedProperties.Count > 0 AndAlso Not (CounterQuery.SelectedProperties.Contains("DeviceID")) Then CounterQuery.SelectedProperties.Add("DeviceID")


						Scope = New ManagementScope(String.Format("\\{0}\root\cimv2", Host))
						Scope.Connect()

						Options = New EnumerationOptions
						Options.ReturnImmediately = False
						Options.UseAmendedQualifiers = True
						Options.EnumerateDeep = True
						Options.DirectRead = False
						Options.Timeout = New TimeSpan(0, 1, 0)
						Searcher = New ManagementObjectSearcher(Scope, CounterQuery, Options)
						Cnt = 0
						Try
							Results = Searcher.Get()
							
						Catch ex As Exception
							'Try query without DeviceID
							Scope = Nothing
							Searcher.Dispose()
							Searcher = Nothing
							CounterQuery = New SelectQuery(CounterQueryString)
							If CounterQuery.SelectedProperties.Count > 0 AndAlso Not (CounterQuery.SelectedProperties.Contains("Name")) Then CounterQuery.SelectedProperties.Add("Name")
							Scope = New ManagementScope(String.Format("\\{0}\root\cimv2", Host))
							Scope.Connect()

							Options = New EnumerationOptions
							Options.ReturnImmediately = False
							Options.UseAmendedQualifiers = True
							Options.EnumerateDeep = True
							Options.DirectRead = False
							Options.Timeout = New TimeSpan(0, 1, 0)
							Searcher = New ManagementObjectSearcher(Scope, CounterQuery, Options)
							Cnt = 0
							Results = Searcher.Get()
						End Try

						For Each WMIChild In Results
							Cnt += 1

							Try	'Error is thrown if DeviceID property does not exist
								DisplayName = WMIChild.Item("DeviceID").ToString()
							Catch
								Try	'Error is thrown if Name property does not exist...
									DisplayName = WMIChild.Item("Name").ToString
								Catch
									Try
										DisplayName = WMIChild("__RELPATH").ToString()
									Catch
										DisplayName = "?"
									End Try
								End Try
							End Try

							'Add any numeric returned counters to database
							For Each pd As PropertyData In WMIChild.Properties
								Select Case ConvertCIMType(pd.Type)
									Case TypeCode.Boolean, TypeCode.Decimal, TypeCode.Double, TypeCode.Int16, TypeCode.Int32, TypeCode.Int64, TypeCode.SByte, TypeCode.Byte, TypeCode.Single, TypeCode.UInt16, TypeCode.UInt32, TypeCode.UInt64
										'Record value
										If pd.Value IsNot Nothing Then
											Counters.Add(New Counter(String.Format("{0}.{1}", DisplayName, pd.Name), CDbl(pd.Value)))
										End If
								End Select
							Next
						Next
						
					End If
				Catch ex As Exception
					'Some error occurred running Monitor Query - just ignore...
				End Try
				'***** End of Counter Query *****

				'***** Monitor Query *****
				'Run and evaluate MonitorQuery
				If EnableWarnings Or EnableFailures Then
					'If no Warnings or Failures have not been set, don't bother running the Monitor Query
					Dim MonitorQuery As SelectQuery
					MonitorQuery = New SelectQuery(MonitorQueryString)

					Scope = New ManagementScope(String.Format("\\{0}\root\cimv2", Host))
					Scope.Connect()

					Options = New EnumerationOptions
					Options.ReturnImmediately = False
					Options.UseAmendedQualifiers = True
					Options.EnumerateDeep = True
					Options.DirectRead = False
					Options.Timeout = New TimeSpan(0, 1, 0)
					Searcher = New ManagementObjectSearcher(Scope, MonitorQuery, Options)

					Cnt = 0
					Results = Searcher.Get()
					'Count number of instances - apparently the Count property has not been implemented by MS because of high overhead
					For Each WMIChild In Results
						Cnt += 1
					Next

					'Monitor Status
					Dim blnFail As Boolean = False
					Dim blnWarning As Boolean = False

					'Failures
					If EnableFailures Then
						Select Case FailureOperator
							Case "<"
								If Cnt < FailureValue Then
									blnFail = True
									StatusMessage = "Instance Count was less than specified threshold value."
								End If
							Case ">"
								If Cnt > FailureValue Then
									blnFail = True
									StatusMessage = "Instance Count was greater than specified threshold value."
								End If
							Case Else
								StatusMessage = "Unsupported Failure Comparison Operator"
								Return MonitorStatus.Fail
						End Select
					End If

					'Warnings
					If Not (blnFail) AndAlso EnableWarnings Then
						Select Case WarningOperator
							Case "<"
								If Cnt < WarningValue Then
									blnWarning = True
									StatusMessage = "Instance Count was less than specified threshold value."
								End If
							Case ">"
								If Cnt > WarningValue Then
									blnWarning = True
									StatusMessage = "Instance Count was greater than specified threshold value."
								End If
							Case Else
								StatusMessage = "Unsupported Warning Comparison Operator"
								Return MonitorStatus.Fail
						End Select
					End If

					If blnFail Then
						'Failure
						Return MonitorStatus.Fail
					ElseIf blnWarning Then
						'Warning
						Return MonitorStatus.Warn
					Else
						'OK
						StatusMessage = "OK"
						Return MonitorStatus.OK
					End If
				Else
					'Nothing to test - just return OK
					StatusMessage = "OK."
					Return MonitorStatus.OK
				End If
				'***** End of Monitor Query *****


			Catch ex As Exception
				If ex.InnerException Is Nothing Then
					StatusMessage = ex.Message
				Else
					StatusMessage = ex.Message & vbCrLf & ex.InnerException.Message
				End If
				Return MonitorExecutor.MonitorStatus.Fail
			Finally
				RootNode = Nothing
			End Try
		End Function

		Private Function ReadXMLNodeValue(ByVal myXMLNode As XmlNode) As String
			If myXMLNode Is Nothing Then
				Return Nothing
			Else
				If myXMLNode Is Nothing OrElse myXMLNode.InnerText = Nothing Then
					Return Nothing
				Else
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
		Private Function ConvertCIMType(ByVal Type As System.Management.CimType) As System.TypeCode
			Select Case Type
				Case CimType.Boolean : Return TypeCode.Boolean
				Case CimType.Char16 : Return TypeCode.Char
				Case CimType.DateTime : Return TypeCode.DateTime
				Case CimType.None : Return TypeCode.Empty
				Case CimType.Object : Return TypeCode.Object
				Case CimType.Real32 : Return TypeCode.Single
				Case CimType.Real64 : Return TypeCode.Double
				Case CimType.Reference : Return TypeCode.Int16
				Case CimType.SInt16 : Return TypeCode.Int16
				Case CimType.SInt32 : Return TypeCode.Int32
				Case CimType.SInt64 : Return TypeCode.Int64
				Case CimType.SInt8 : Return TypeCode.SByte
				Case CimType.String : Return TypeCode.String
				Case CimType.UInt16 : Return TypeCode.UInt16
				Case CimType.UInt32 : Return TypeCode.UInt32
				Case CimType.UInt64 : Return TypeCode.UInt64
				Case CimType.UInt8 : Return TypeCode.Byte
				Case Else : Return TypeCode.Empty
			End Select
		End Function
	End Class
End Namespace