Imports System.Xml
Imports PolyMon.Status

'<SNMPMonitor>
'	<Host>hostname or ip</Host>
'	<Port>ignored for now - always set to 161</Port>
'	<ReadCommunity>public</ReadCommunity>
'	<OID>1.3.6.1.4.1.318.1.1.2.1.1.0</OID>
'	<Timeout>8000</Timeout>
'	<Threshold DataType="Numeric" Comparison="&gt;">28</Threshold>
'</SNMPMonitor>

Namespace Monitors
    Public Class SNMPMonitor
        Inherits PolyMon.Monitors.MonitorExecutor

        Private Enum ThresholdComparisonTypes As Integer
            Unknown = -1
            Equals = 0
            LessThan = 1
            LessThanOrEqualTo = 2
            GreaterThan = 3
            GreaterThanOrEqualTo = 4
            NotEqual = 5
        End Enum
        Private Enum ThresholdDataTypes As Integer
            Unknown = -1
            Numeric = 0
            Alphanumeric = 1
        End Enum

        Public Sub New(ByVal MonitorID As Integer)
            MyBase.New(MonitorID)
        End Sub

		Protected Overrides Function MonitorTest(ByRef StatusMessage As String, ByRef Counters As CounterList) As MonitorExecutor.MonitorStatus
			Dim RootNode As XmlNode = MonitorXML.DocumentElement
			Dim NodeValue As String

			Dim Host As String
			Dim Port As Integer
			Dim ReadCommunity As String
			Dim OID As String
			Dim Timeout As Integer
			Dim FailIsEnabled As Boolean
			Dim FailThresholdComparisonType As ThresholdComparisonTypes
			Dim FailThresholdDataType As ThresholdDataTypes
			Dim FailThresholdValue As String = Nothing
			Dim WarnIsEnabled As Boolean
			Dim WarnThresholdComparisonType As ThresholdComparisonTypes
			Dim WarnThresholdDataType As ThresholdDataTypes
			Dim WarnThresholdValue As String = Nothing
			Dim SNMPValue As String = Nothing
			Dim IsFailure As Boolean = False
			Dim IsWarning As Boolean = False

			StatusMessage = Nothing

			Try
				'Host 
				Host = ReadXMLNodeValue(RootNode.SelectSingleNode("Host"))
				'Port
				Port = CInt(ReadXMLNodeValue(RootNode.SelectSingleNode("Port")))
				'ReadCommunity
				ReadCommunity = ReadXMLNodeValue(RootNode.SelectSingleNode("ReadCommunity"))
				'OID
				OID = ReadXMLNodeValue(RootNode.SelectSingleNode("OID"))
				'Timeout
				NodeValue = ReadXMLNodeValue(RootNode.SelectSingleNode("Timeout"))
				Timeout = CInt(IIf(NodeValue = Nothing, 3000, NodeValue))


				'Warning Settings
				If RootNode.SelectSingleNode("WarnThreshold") Is Nothing Then
					WarnIsEnabled = False
				Else
					NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnThreshold").Attributes("Enabled"))
					If String.IsNullOrEmpty(NodeValue) OrElse CBool(NodeValue) = False Then
						WarnIsEnabled = False
					Else
						WarnIsEnabled = True

						NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnThreshold").Attributes("Comparison"))
						Select Case NodeValue
							Case "="
								WarnThresholdComparisonType = ThresholdComparisonTypes.Equals
							Case "<"
								WarnThresholdComparisonType = ThresholdComparisonTypes.LessThan
							Case "<="
								WarnThresholdComparisonType = ThresholdComparisonTypes.LessThanOrEqualTo
							Case ">"
								WarnThresholdComparisonType = ThresholdComparisonTypes.GreaterThan
							Case ">="
								WarnThresholdComparisonType = ThresholdComparisonTypes.GreaterThanOrEqualTo
							Case "<>"
								WarnThresholdComparisonType = ThresholdComparisonTypes.NotEqual
							Case Else
								WarnThresholdComparisonType = ThresholdComparisonTypes.Unknown
						End Select
						If WarnThresholdComparisonType = ThresholdComparisonTypes.Unknown Then
							Throw New System.Exception("Unknown Warning Threshold Comparison Type. Acceptable values are =, <>, <, <=, >, >=.")
						End If

						'Warning Threshold Data Type
						NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("WarnThreshold").Attributes("DataType"))
						Select Case NodeValue
							Case "Numeric"
								WarnThresholdDataType = ThresholdDataTypes.Numeric
							Case "String"
								WarnThresholdDataType = ThresholdDataTypes.Alphanumeric
							Case Else
								WarnThresholdDataType = ThresholdDataTypes.Unknown
						End Select
						If WarnThresholdDataType = ThresholdDataTypes.Unknown Then
							Throw New System.Exception("Unknown Warning Threshold Data Type. Acceptable Types are Numeric or String.")
						End If
						'Fail Threshold Value
						WarnThresholdValue = ReadXMLNodeValue(RootNode.SelectSingleNode("WarnThreshold"))

						If WarnThresholdDataType = ThresholdDataTypes.Numeric AndAlso Not (IsNumeric(WarnThresholdValue)) Then
							Throw New System.Exception("Specified Warning Threshold Value does not conform to specified Threshold Data Type.")
						End If
					End If
				End If


				'Failure Settings
				If RootNode.SelectSingleNode("Threshold") Is Nothing Then
					FailIsEnabled = False
				Else
					NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("Threshold").Attributes("Enabled"))
					If String.IsNullOrEmpty(NodeValue) OrElse CBool(NodeValue) = False Then
						FailIsEnabled = False
					Else
						FailIsEnabled = True

						NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("Threshold").Attributes("Comparison"))
						Select Case NodeValue
							Case "="
								FailThresholdComparisonType = ThresholdComparisonTypes.Equals
							Case "<"
								FailThresholdComparisonType = ThresholdComparisonTypes.LessThan
							Case "<="
								FailThresholdComparisonType = ThresholdComparisonTypes.LessThanOrEqualTo
							Case ">"
								FailThresholdComparisonType = ThresholdComparisonTypes.GreaterThan
							Case ">="
								FailThresholdComparisonType = ThresholdComparisonTypes.GreaterThanOrEqualTo
							Case "<>"
								FailThresholdComparisonType = ThresholdComparisonTypes.NotEqual
							Case Else
								FailThresholdComparisonType = ThresholdComparisonTypes.Unknown
						End Select
						If FailThresholdComparisonType = ThresholdComparisonTypes.Unknown Then
							Throw New System.Exception("Unknown Failure Threshold Comparison Type. Acceptable values are =, <>, <, <=, >, >=.")
						End If

						'Fail Threshold Data Type
						NodeValue = ReadXMLAttributeValue(RootNode.SelectSingleNode("Threshold").Attributes("DataType"))
						Select Case NodeValue
							Case "Numeric"
								FailThresholdDataType = ThresholdDataTypes.Numeric
							Case "String"
								FailThresholdDataType = ThresholdDataTypes.Alphanumeric
							Case Else
								FailThresholdDataType = ThresholdDataTypes.Unknown
						End Select
						If FailThresholdDataType = ThresholdDataTypes.Unknown Then
							Throw New System.Exception("Unknown Failure Threshold Data Type. Acceptable Types are Numeric or String.")
						End If
						'Fail Threshold Value
						FailThresholdValue = ReadXMLNodeValue(RootNode.SelectSingleNode("Threshold"))

						If FailThresholdDataType = ThresholdDataTypes.Numeric AndAlso Not (IsNumeric(FailThresholdValue)) Then
							Throw New System.Exception("Specified Failure Threshold Value does not conform to specified Threshold Data Type.")
						End If
					End If
				End If

				'Perform SNMP get
				Try
					SNMPValue = RunSNMPGet(Host, Port, Timeout, OID, ReadCommunity)
				Catch ex As Exception
					Throw New System.Exception("SNMP Error: " & ex.Message())
				End Try

				If IsNumeric(SNMPValue) Then
					MonitorCounters.Add(New Counter("SNMP", CDbl(SNMPValue)))
				End If

				If FailIsEnabled Then
					IsFailure = Not (EvaluateThresholdRules(FailThresholdDataType, FailThresholdComparisonType, FailThresholdValue, SNMPValue, StatusMessage))
				End If

				If Not (IsFailure) AndAlso WarnIsEnabled Then
					IsWarning = Not (EvaluateThresholdRules(WarnThresholdDataType, WarnThresholdComparisonType, WarnThresholdValue, SNMPValue, StatusMessage))
				End If

			Catch ex As Exception
				StatusMessage = ex.Message
				IsFailure = True
			End Try

			If IsFailure Then
				StatusMessage = String.Format("Failed. {0}", StatusMessage)
				Return MonitorStatus.Fail
			ElseIf IsWarning Then
				StatusMessage = String.Format("Warning. {0}", StatusMessage)
				Return MonitorStatus.Warn
			Else
				StatusMessage = String.Format("OK. SNMP Value={0}", SNMPValue)
				Return MonitorStatus.OK
			End If
		End Function


		Private Function EvaluateThresholdRules(ByVal DataType As ThresholdDataTypes, ByVal ComparisonType As ThresholdComparisonTypes, ByVal ThresholdValue As String, ByVal SNMPValue As String, ByRef StatusMessage As String) As Boolean
			Dim IsOK As Boolean = True
			StatusMessage = Nothing

			If DataType = ThresholdDataTypes.Numeric AndAlso Not (IsNumeric(SNMPValue)) Then
				Throw New System.Exception("Returned SNMP Value is not a numeric value but Threshold Data Type was specified as numeric.")
			End If

			Select Case ComparisonType
				Case ThresholdComparisonTypes.Equals
					If DataType = ThresholdDataTypes.Numeric Then
						If CDbl(SNMPValue) = CDbl(ThresholdValue) Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					Else
						If SNMPValue = ThresholdValue Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					End If
				Case ThresholdComparisonTypes.GreaterThan
					If DataType = ThresholdDataTypes.Numeric Then
						If CDbl(SNMPValue) > CDbl(ThresholdValue) Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					Else
						If SNMPValue > ThresholdValue Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					End If
				Case ThresholdComparisonTypes.GreaterThanOrEqualTo
					If DataType = ThresholdDataTypes.Numeric Then
						If CDbl(SNMPValue) >= CDbl(ThresholdValue) Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					Else
						If SNMPValue >= ThresholdValue Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					End If
				Case ThresholdComparisonTypes.LessThan
					If DataType = ThresholdDataTypes.Numeric Then
						If CDbl(SNMPValue) < CDbl(ThresholdValue) Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					Else
						If SNMPValue < ThresholdValue Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					End If
				Case ThresholdComparisonTypes.LessThanOrEqualTo
					If DataType = ThresholdDataTypes.Numeric Then
						If CDbl(SNMPValue) <= CDbl(ThresholdValue) Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					Else
						If SNMPValue <= ThresholdValue Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					End If
				Case ThresholdComparisonTypes.NotEqual
					If DataType = ThresholdDataTypes.Numeric Then
						If CDbl(SNMPValue) <> CDbl(ThresholdValue) Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					Else
						If SNMPValue <> ThresholdValue Then
							IsOK = False
							StatusMessage = "Threshold test failed. SNMP Value = " & SNMPValue
						End If
					End If
			End Select

			Return IsOK
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

        Private Function RunSNMPGet(ByVal Host As String, ByVal Port As Integer, ByVal Timeout As Integer, ByVal OID As String, ByVal ReadCommunity As String) As String
            Dim SNMPApi As New SNMPGet(Host, ReadCommunity, OID, Timeout)
            'Ignore Port since underlying SNMP class is hardcoded to standard SNMP port... Change this in the future.
            SNMPApi.SNMPGet()
            If Not (SNMPApi.IsOK) Then
                Throw New System.Exception(SNMPApi.StatusMessage)
                Return Nothing
            Else
                Return SNMPApi.SNMPValue
            End If
        End Function
    End Class
End Namespace