Imports MMall

Public Class UserLoginDto
    Private _user As User
    Private _cartCount As Integer

    Public Property User As User
        Get
            Return _user
        End Get
        Set(value As User)
            _user = value
        End Set
    End Property

    Public Property CartCount As Integer
        Get
            Return _cartCount
        End Get
        Set(value As Integer)
            _cartCount = value
        End Set
    End Property
End Class
