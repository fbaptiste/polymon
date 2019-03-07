Public NotInheritable Class frmAboutPolyMon

    Private Sub frmAboutPolyMon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)

		Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName

		Dim sbDescription As New System.Text.StringBuilder
		With sbDescription
			.Append("{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset2 Symbol;}}")
			.Append("{\colortbl ;\red0\green0\blue128;\red0\green128\blue0;}")
			.Append("{\*\generator Msftedit 5.41.15.1507;}\viewkind4\uc1\pard\cf1\b\f0\fs20 PolyMon\cf0\b0  is an open source distributed monitoring system that provides monitoring, alerting and historical analysis that uses the .NET 2.0 framework and Microsoft SQL Server.\par ")
			.Append("\par ")
			.Append("Licensing information, source code and further information can be found at http://www.codeplex.com/polymon \par ")
			.Append("\par ")
			.Append("\b Acknowledgements\par")
			.Append("\b0 Many thanks to the following people:\par")
			.Append("\pard{\pntext\f1\'B7\tab}{\*\pn\pnlvlblt\pnf1\pnindent0{\pntxtb\'B7}}\fi-360\li360\cf2\b CodePlex \cf0\b0 (http://www.codeplex.com) for providing the project hosting environment\par")
			.Append("\cf2\b{\pntext\f1\'B7\tab}ZedGraph \cf0\b0 (http://zedgraph.org) for fantastic Charting components\par")
			.Append("\cf2\b{\pntext\f1\'B7\tab}WiX \cf0\b0 (http://wix.sourceforge.net) for an oustanding Windows Installer toolset\par")
			.Append("\cf2\b{\pntext\f1\'B7\tab}Ascend.Net \cf0\b0 (http://www.codeplex.com/ascendnet) for great GUI components\par")
			.Append("}")
		End With

		Me.txtDescription.Rtf = sbDescription.ToString()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub txtDescription_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtDescription.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub
End Class
