Public Class CartConfirmDto
    Private _cartId As String
    Private _quantity As String
    Private _isChecked As String
    Public Property CartId As String
        Get
            Return _cartId
        End Get
        Set(value As String)
            _cartId = value
        End Set
    End Property

    Public Property Quantity As String
        Get
            Return _quantity
        End Get
        Set(value As String)
            _quantity = value
        End Set
    End Property

    Public Property IsChecked As String
        Get
            Return _isChecked
        End Get
        Set(value As String)
            _isChecked = value
        End Set
    End Property
End Class
