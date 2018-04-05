Imports MMall

Public Class CartInfo
    Private _shippingList As List(Of Shipping)
    Private _cartList As List(Of CartItem)
    Private _cartTotalPrice As String

    Public Property CartList As List(Of CartItem)
        Get
            Return _cartList
        End Get
        Set(value As List(Of CartItem))
            _cartList = value
        End Set
    End Property

    Public Property CartTotalPrice As String
        Get
            Return _cartTotalPrice
        End Get
        Set(value As String)
            _cartTotalPrice = value
        End Set
    End Property

    Public Property ShippingList As List(Of Shipping)
        Get
            Return _shippingList
        End Get
        Set(value As List(Of Shipping))
            _shippingList = value
        End Set
    End Property
End Class
