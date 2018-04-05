Imports MMall

Public Class CartIndexViewModel
    Private _result As ServerResponse(Of CartInfo)

    Public Property Result As ServerResponse(Of CartInfo)
        Get
            Return _result
        End Get
        Set(value As ServerResponse(Of CartInfo))
            _result = value
        End Set
    End Property
End Class
