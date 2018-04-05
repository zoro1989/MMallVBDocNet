Public Class User
    Private _id As Integer

    Private _username As String

    Private _password As String

    Private _email As String

    Private _phone As String

    Private _question As String

    Private _answer As String

    Private _role As Integer

    Private _createTime As Date

    Private _updateTime As Date

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

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

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property Phone As String
        Get
            Return _phone
        End Get
        Set(value As String)
            _phone = value
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

    Public Property Role As Integer
        Get
            Return _role
        End Get
        Set(value As Integer)
            _role = value
        End Set
    End Property

    Public Property CreateTime As Date
        Get
            Return _createTime
        End Get
        Set(value As Date)
            _createTime = value
        End Set
    End Property

    Public Property UpdateTime As Date
        Get
            Return _updateTime
        End Get
        Set(value As Date)
            _updateTime = value
        End Set
    End Property
End Class
