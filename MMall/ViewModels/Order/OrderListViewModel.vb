Imports MMall

Public Class OrderListViewModel
    Private _result As ServerResponse(Of OrderListInfoDto)

    Public Property Result As ServerResponse(Of OrderListInfoDto)
        Get
            Return _result
        End Get
        Set(value As ServerResponse(Of OrderListInfoDto))
            _result = value
        End Set
    End Property
End Class
