Public Class OrderItem
    Private _id As Integer

    Private _orderNo As Long

    Private _productId As Integer

    Private _productName As String

    Private _productImage As String

    Private _currentUnitPrice As Decimal

    Private _quantity As Integer

    Private _totalPrice As Decimal

    Private _createTime As Date

    Private _updateTime As Date

    Private _userId As Integer

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property OrderNo As Long
        Get
            Return _orderNo
        End Get
        Set(value As Long)
            _orderNo = value
        End Set
    End Property

    Public Property ProductId As Integer
        Get
            Return _productId
        End Get
        Set(value As Integer)
            _productId = value
        End Set
    End Property

    Public Property ProductName As String
        Get
            Return _productName
        End Get
        Set(value As String)
            _productName = value
        End Set
    End Property

    Public Property ProductImage As String
        Get
            Return _productImage
        End Get
        Set(value As String)
            _productImage = value
        End Set
    End Property

    Public Property CurrentUnitPrice As Decimal
        Get
            Return _currentUnitPrice
        End Get
        Set(value As Decimal)
            _currentUnitPrice = value
        End Set
    End Property

    Public Property Quantity As Integer
        Get
            Return _quantity
        End Get
        Set(value As Integer)
            _quantity = value
        End Set
    End Property

    Public Property TotalPrice As Decimal
        Get
            Return _totalPrice
        End Get
        Set(value As Decimal)
            _totalPrice = value
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

    Public Property UserId As Integer
        Get
            Return _userId
        End Get
        Set(value As Integer)
            _userId = value
        End Set
    End Property
End Class
