Imports MMall

Public Class CategoryFloorDto
    Private _parentCategory As Category
    Private _categoryList As List(Of Category) = New List(Of Category)

    Public Property ParentCategory As Category
        Get
            Return _parentCategory
        End Get
        Set(value As Category)
            _parentCategory = value
        End Set
    End Property

    Public Property CategoryList As List(Of Category)
        Get
            Return _categoryList
        End Get
        Set(value As List(Of Category))
            _categoryList = value
        End Set
    End Property
End Class
