
Public Class AlertEventArgs
    Inherits EventArgs

    Private mAlertStatus As PolyMon.Monitors.MonitorStatus.Current

    Public Sub New(ByVal AlertStatus As PolyMon.Monitors.MonitorStatus.Current)
        mAlertStatus = AlertStatus
    End Sub

    Public ReadOnly Property AlertStatus() As PolyMon.Monitors.MonitorStatus.Current
        Get
            Return mAlertStatus
        End Get
    End Property
End Class
