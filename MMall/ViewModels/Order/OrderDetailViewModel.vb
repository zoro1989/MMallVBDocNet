Imports MMall

Public Class OrderDetailViewModel
    Private _result As ServerResponse(Of OrderInfoDto)

    Public Property Result As ServerResponse(Of OrderInfoDto)
        Get
            Return _result
        End Get
        Set(value As ServerResponse(Of OrderInfoDto))
            _result = value
        End Set
    End Property
End Class
