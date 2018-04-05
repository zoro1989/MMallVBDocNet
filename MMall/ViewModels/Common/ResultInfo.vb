Public Class ResultInfo
    Private _message As String

    Public Property Message As String
        Get
            Return _message
        End Get
        Set(value As String)
            _message = value
        End Set
    End Property
End Class
