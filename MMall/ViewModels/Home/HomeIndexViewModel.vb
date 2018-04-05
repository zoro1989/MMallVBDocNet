Imports MMall

Public Class HomeIndexViewModel
    Private _result As ServerResponse(Of HomeDataDto)

    Public Property Result As ServerResponse(Of HomeDataDto)
        Get
            Return _result
        End Get
        Set(value As ServerResponse(Of HomeDataDto))
            _result = value
        End Set
    End Property
End Class
