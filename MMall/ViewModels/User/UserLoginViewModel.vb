Imports MMall

Public Class UserLoginViewModel
    Private _username As String
    Private _password As String
    Private _result As ServerResponse(Of UserLoginDto)

    Public Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Public Property Result As ServerResponse(Of UserLoginDto)
        Get
            Return _result
        End Get
        Set(value As ServerResponse(Of UserLoginDto))
            _result = value
        End Set
    End Property
End Class
