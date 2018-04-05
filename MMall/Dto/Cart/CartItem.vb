Public Class CartItem
    Private _cart As Cart
    Private _product As Product
    Private _totalPrice As String

    Public Property Cart As Cart
        Get
            Return _cart
        End Get
        Set(value As Cart)
            _cart = value
        End Set
    End Property

    Public Property Product As Product
        Get
            Return _product
        End Get
        Set(value As Product)
            _product = value
        End Set
    End Property

    Public Property TotalPrice As String
        Get
            Return _totalPrice
        End Get
        Set(value As String)
            _totalPrice = value
        End Set
    End Property
End Class
