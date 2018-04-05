Imports MMall

Public Class GoodsListViewModel
    Private _orderBy As String
    Private _keyword As String
    Private _categoryId As String
    Private _pageNo As Integer = 1
    Private _result As ServerResponse(Of ProductInfoDto)

    Public Property OrderBy As String
        Get
            Return _orderBy
        End Get
        Set(value As String)
            _orderBy = value
        End Set
    End Property

    Public Property Result As ServerResponse(Of ProductInfoDto)
        Get
            Return _result
        End Get
        Set(value As ServerResponse(Of ProductInfoDto))
            _result = value
        End Set
    End Property

    Public Property Keyword As String
        Get
            Return _keyword
        End Get
        Set(value As String)
            _keyword = value
        End Set
    End Property

    Public Property CategoryId As String
        Get
            Return _categoryId
        End Get
        Set(value As String)
            _categoryId = value
        End Set
    End Property

    Public Property PageNo As Integer
        Get
            Return _pageNo
        End Get
        Set(value As Integer)
            _pageNo = value
        End Set
    End Property
End Class
