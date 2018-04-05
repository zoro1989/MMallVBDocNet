Public Class HistoryBackCache
    ''' <summary>
    ''' 组织历史页面信息
    ''' </summary>
    ''' <param name="actionName"></param>
    ''' <param name="controllerName"></param>
    ''' <param name="routeValues"></param>
    ''' <returns></returns>
    Shared Function SetHistoryUrl(actionName As String, controllerName As String, routeValues As Object) As HistoryUrlDto
        Dim dto As HistoryUrlDto = New HistoryUrlDto()
        dto.ActionName = actionName
        dto.ControllerName = controllerName
        dto.RouteValues = routeValues
        Return dto
    End Function

End Class
