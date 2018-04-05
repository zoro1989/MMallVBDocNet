Imports MMall

Public Class ForgetPasswrodViewModel
    Private _username As String
    Private _question As String
    Private _answer As String
    Private _passwordNew As String
    Private _forgetToken As String
    Private _result As ServerResponse(Of String)

    Public Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    Public Property Question As String
        Get
            Return _question
        End Get
        Set(value As String)
            _question = value
        End Set
    End Property

    Public Property Answer As String
        Get
            Return _answer
        End Get
        Set(value As String)
            _answer = value
        End Set
    End Property

    Public Property PasswordNew As String
        Get
            Return _passwordNew
        End Get
        Set(value As String)
            _passwordNew = value
        End Set
    End Property

    Public Property Result As ServerResponse(Of String)
        Get
            Return _result
        End Get
        Set(value As ServerResponse(Of String))
            _result = value
        End Set
    End Property

    Public Property ForgetToken As String
        Get
            Return _forgetToken
        End Get
        Set(value As String)
            _forgetToken = value
        End Set
    End Property
End Class
