Public Class ProductDtailInfoDto
    Private _id As Integer

    Private _categoryId As Integer

    Private _name As String

    Private _subtitle As String

    Private _mainImage As String

    Private _subImages() As String

    Private _detail As String

    Private _price As Decimal

    Private _stock As Integer

    Private _status As Integer

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

    Public Property CategoryId As Integer
        Get
            Return _categoryId
        End Get
        Set(value As Integer)
            _categoryId = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Subtitle As String
        Get
            Return _subtitle
        End Get
        Set(value As String)
            _subtitle = value
        End Set
    End Property

    Public Property MainImage As String
        Get
            Return _mainImage
        End Get
        Set(value As String)
            _mainImage = value
        End Set
    End Property

    Public Property SubImages As String()
        Get
            Return _subImages
        End Get
        Set(value As String())
            _subImages = value
        End Set
    End Property

    Public Property Detail As String
        Get
            Return _detail
        End Get
        Set(value As String)
            _detail = value
        End Set
    End Property

    Public Property Price As Decimal
        Get
            Return _price
        End Get
        Set(value As Decimal)
            _price = value
        End Set
    End Property

    Public Property Stock As Integer
        Get
            Return _stock
        End Get
        Set(value As Integer)
            _stock = value
        End Set
    End Property

    Public Property Status As Integer
        Get
            Return _status
        End Get
        Set(value As Integer)
            _status = value
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
