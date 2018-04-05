Public Class Category
    Private _id As Integer

    Private _parentId As Integer

    Private _name As String

    Private _status As Integer

    Private _sortOrder As Integer

    Private _createTime As Date

    Private _updateTime As Date

    Private _imgUrl As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property ParentId As Integer
        Get
            Return _parentId
        End Get
        Set(value As Integer)
            _parentId = value
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



    Public Property SortOrder As Integer
        Get
            Return _sortOrder
        End Get
        Set(value As Integer)
            _sortOrder = value
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

    Public Property Status As Integer
        Get
            Return _status
        End Get
        Set(value As Integer)
            _status = value
        End Set
    End Property

    Public Property ImgUrl As String
        Get
            Return _imgUrl
        End Get
        Set(value As String)
            _imgUrl = value
        End Set
    End Property
End Class
