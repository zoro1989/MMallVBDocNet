Public Class Cart
    Private _id As Integer

    Private _userId As Integer

    Private _productId As Integer

    Private _quantity As Integer

    Private _checked As Integer

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

    Public Property UserId As Integer
        Get
            Return _userId
        End Get
        Set(value As Integer)
            _userId = value
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

    Public Property Quantity As Integer
        Get
            Return _quantity
        End Get
        Set(value As Integer)
            _quantity = value
        End Set
    End Property

    Public Property Checked As Integer
        Get
            Return _checked
        End Get
        Set(value As Integer)
            _checked = value
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
