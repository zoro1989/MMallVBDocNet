Imports MMall

Public Class CartConfirmInfoDto
    Private _shippingList As List(Of Shipping)
    Private _productList As List(Of Product)

    Public Property ShippingList As List(Of Shipping)
        Get
            Return _shippingList
        End Get
        Set(value As List(Of Shipping))
            _shippingList = value
        End Set
    End Property

    Public Property ProductList As List(Of Product)
        Get
            Return _productList
        End Get
        Set(value As List(Of Product))
            _productList = value
        End Set
    End Property
End Class
