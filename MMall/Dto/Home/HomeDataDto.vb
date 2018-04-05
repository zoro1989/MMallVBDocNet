Imports MMall

Public Class HomeDataDto
    Private _floorList As List(Of CategoryFloorDto) = New List(Of CategoryFloorDto)
    Private _categoryList As List(Of List(Of Category)) = New List(Of List(Of Category))
    Private _cartCount As Integer

    Public Property FloorList As List(Of CategoryFloorDto)
        Get
            Return _floorList
        End Get
        Set(value As List(Of CategoryFloorDto))
            _floorList = value
        End Set
    End Property

    Public Property CategoryList As List(Of List(Of Category))
        Get
            Return _categoryList
        End Get
        Set(value As List(Of List(Of Category)))
            _categoryList = value
        End Set
    End Property

    Public Property CartCount As Integer
        Get
            Return _cartCount
        End Get
        Set(value As Integer)
            _cartCount = value
        End Set
    End Property
End Class
