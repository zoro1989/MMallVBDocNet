Public Class HistoryUrlDto
    Private _actionName As String
    Private _controllerName As String
    Private _routeValues As Object

    Public Property ActionName As String
        Get
            Return _actionName
        End Get
        Set(value As String)
            _actionName = value
        End Set
    End Property

    Public Property ControllerName As String
        Get
            Return _controllerName
        End Get
        Set(value As String)
            _controllerName = value
        End Set
    End Property

    Public Property RouteValues As Object
        Get
            Return _routeValues
        End Get
        Set(value As Object)
            _routeValues = value
        End Set
    End Property
End Class
