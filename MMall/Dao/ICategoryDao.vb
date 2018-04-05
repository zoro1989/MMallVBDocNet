Public Interface ICategoryDao
    Function SelectAllCategory() As List(Of Category)
    Function SelectCategoryItems(parentId As Integer) As List(Of Category)
    Function SelectCategoryNoTire() As List(Of Category)
End Interface
