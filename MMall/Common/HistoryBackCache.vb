Public Class HistoryBackCache
    Shared Function SetHistoryUrl(actionName As String, controllerName As String, routeValues As Object) As HistoryUrlDto
        Dim dto As HistoryUrlDto = New HistoryUrlDto()
        dto.ActionName = actionName
        dto.ControllerName = controllerName
        dto.RouteValues = routeValues
        Return dto
    End Function

End Class
