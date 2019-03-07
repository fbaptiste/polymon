Imports System.Threading

Public Class UCMonitorPanel


    Public Overridable Sub RefreshData()
    End Sub
    Public Overridable ReadOnly Property MonitorID() As Integer
        Get
            Return Nothing
        End Get
    End Property
    Public Overridable ReadOnly Property MonitorName() As String
        Get
            Return Nothing
        End Get
    End Property
    Public Overridable ReadOnly Property PanelID() As Integer
        Get
            Return Nothing
        End Get
    End Property
    Public Overridable ReadOnly Property GroupID() As Integer
        Get
            Return Nothing
        End Get
    End Property
    Public Overridable ReadOnly Property MonitorPanel() As PolyMon.Dashboard.MonitorPanel
        Get
            Return Nothing
        End Get
    End Property
    Public Overridable ReadOnly Property CurrentStatus() As PolyMon.Monitors.MonitorStatus.Current
        Get
            Return Nothing
        End Get
    End Property
	Public Overridable ReadOnly Property MonitorEnabled() As Boolean
		Get
			Return Nothing
		End Get
	End Property
    Public Event BeforeDelete As EventHandler
    Public Delegate Sub AlertEventHandler(ByVal sender As Object, ByVal e As AlertEventArgs)
    Public Event AlertEvent As AlertEventHandler

End Class
