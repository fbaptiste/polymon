Imports System.Xml
Imports System.Text

Public Class DiskMonitorEditor

#Region "Private Attributes"
  Private mXMLTemplate As String
#End Region

#Region "Public Interface"
	Public Sub New()

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Me.RadioButtonLocalDrive.Checked = True
		Me.ComboBoxError.SelectedIndex = 0
	End Sub
	Public Overrides Property XMLTemplate() As String
		Get
			Return mXMLTemplate
		End Get
		Set(ByVal value As String)
			mXMLTemplate = value
		End Set
	End Property
	Public Overrides Property XMLSettings() As String
		Get
			Return BuildXMLParams()
		End Get
		Set(ByVal value As String)
			LoadXMLValues(value)
		End Set
	End Property
	Public Overrides Sub LoadTemplateDefaults()
		LoadXMLValues(mXMLTemplate)
	End Sub
#End Region

#Region "Private Methods"
	Private Sub LoadXMLValues(ByVal XML As String)
		'Get default data from XML template (mXMLTemplate) 
		Dim XMLDoc As New XmlDocument

		XMLDoc.LoadXml(XML)

		Dim RootNode As XmlNode = XMLDoc.DocumentElement

		' Load information from the "Drive" node
		Dim Drive As String = ReadXMLNodeValue(RootNode.SelectSingleNode("Drive"))

		' Load information from the "TempNetMapDrive" node
		Dim tempDrive As String = ReadXMLNodeValue(RootNode.SelectSingleNode("TempNetMapDrive"))

		' Determine if we are looking at a network or local drive by the first character. 
		' The first character will be a backslash (\) indicating the start of a UNC file 
		' share if this is a network drive we are examining, otherwise assume local drive. 
		If Drive IsNot Nothing AndAlso Drive.Length > 0 AndAlso Drive(0) = "\" Then
			Me.RadioButtonNetworkShare.Checked = True
			Me.TextBoxNetworkShare.Text = Drive
			If tempDrive IsNot Nothing AndAlso tempDrive.Length > 0 Then
				Try
					' Attempt to assign temp drive letter as parameter from the TempNetMapDrive
					Me.DomainUpDownTempDrive.Text = CStr(tempDrive(0)).ToUpper & ":"
				Catch
				End Try
			End If
		Else
			Me.RadioButtonLocalDrive.Checked = True
			Try
				' Attempt to assign local drive letter as parameter
				Me.DomainUpDownDrive.Text = CStr(Drive(0)).ToUpper & ":"
			Catch
			End Try
		End If

		' Load MB thesholds 
		Try
			Me.NumericUpDownWarnMB.Value = Decimal.Parse(ReadXMLNodeValue(RootNode.SelectSingleNode("WarnMB")))
		Catch
		End Try

		Try
			Me.NumericUpDownFailMB.Value = Decimal.Parse(ReadXMLNodeValue(RootNode.SelectSingleNode("FailMB")))
		Catch
		End Try

		Try
			Me.ComboBoxError.SelectedIndex = Me.ComboBoxError.Items.IndexOf(ReadXMLNodeValue(RootNode.SelectSingleNode("ReportErrorAs")).ToUpper)
		Catch 
		End Try

	End Sub
	Private Function BuildXMLParams() As String
		Dim s As New StringBuilder

		s.Append("<DiskMonitor>" & vbCrLf)

		If Me.RadioButtonLocalDrive.Checked Then
			s.Append(vbTab & "<Drive>" & Me.DomainUpDownDrive.Text(0) & "</Drive>")
			s.Append(vbTab & "<TempNetMapDrive></TempNetMapDrive>")
		Else
			s.Append(vbTab & "<Drive>" & Me.TextBoxNetworkShare.Text.Trim & "</Drive>")
			s.Append(vbTab & "<TempNetMapDrive>" & Me.DomainUpDownTempDrive.Text(0) & "</TempNetMapDrive>")
		End If

		s.Append(vbTab & "<WarnMB>" & Me.NumericUpDownWarnMB.Value & "</WarnMB>" & vbCrLf)
		s.Append(vbTab & "<FailMB>" & Me.NumericUpDownFailMB.Value & "</FailMB>" & vbCrLf)
		s.Append(vbTab & "<ReportErrorAs>" & Me.ComboBoxError.SelectedItem.ToString & "</ReportErrorAs>" & vbCrLf)
		s.Append("</DiskMonitor>")

		Return s.ToString()
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
#End Region

#Region "Event Handlers"
	Private Sub RadioButtonLocalDrive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonLocalDrive.CheckedChanged, RadioButtonNetworkShare.CheckedChanged
		Me.DomainUpDownDrive.Enabled = Me.RadioButtonLocalDrive.Checked
		Me.TextBoxNetworkShare.Enabled = Me.RadioButtonNetworkShare.Checked
		Me.LabelTempDrive.Enabled = Me.RadioButtonNetworkShare.Checked
		Me.DomainUpDownTempDrive.Enabled = Me.RadioButtonNetworkShare.Checked
	End Sub
#End Region

End Class
