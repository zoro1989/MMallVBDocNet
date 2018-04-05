Public Class GoodsAddCartSuccessViewModel
    Private _quantity As String
    Private _productId As String
    Private _userId As String



    Public Property ProductId As String
        Get
            Return _productId
        End Get
        Set(value As String)
            _productId = value
        End Set
    End Property

    Public Property UserId As String
        Get
            Return _userId
        End Get
        Set(value As String)
            _userId = value
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
End Class
