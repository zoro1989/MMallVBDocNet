Public Class Page
    Private _count As Integer
    Private _pageCount As Integer
    Private _currentPage As Integer
    Private _hasNextPage As Boolean
    Private _hasPrevPage As Boolean
    Public Property Count As Integer
        Get
            Return _count
        End Get
        Set(value As Integer)
            _count = value
        End Set
    End Property

    Public Property PageCount As Integer
        Get
            Return _pageCount
        End Get
        Set(value As Integer)
            _pageCount = value
        End Set
    End Property

    Public Property CurrentPage As Integer
        Get
            Return _currentPage
        End Get
        Set(value As Integer)
            _currentPage = value
        End Set
    End Property

    Public Property HasNextPage As Boolean
        Get
            Return _hasNextPage
        End Get
        Set(value As Boolean)
            _hasNextPage = value
        End Set
    End Property

    Public Property HasPrevPage As Boolean
        Get
            Return _hasPrevPage
        End Get
        Set(value As Boolean)
            _hasPrevPage = value
        End Set
    End Property
End Class
