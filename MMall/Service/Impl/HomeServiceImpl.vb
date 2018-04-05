Imports MMall


Public Class HomeServiceImpl : Implements IHomeService
    Private _categoryDao As ICategoryDao = New CategoryDaoImpl
    Private _cartDao As ICartDao = New CartDaoImpl
    Public Function SelectHomeData(user As User) As ServerResponse(Of HomeDataDto) Implements IHomeService.SelectHomeData
        Dim parentCategories As List(Of Category) = _categoryDao.SelectAllCategory()
        Dim floorList As List(Of CategoryFloorDto) = New List(Of CategoryFloorDto)
        For Each pCategory In parentCategories
            Dim pModel As CategoryFloorDto = New CategoryFloorDto
            pModel.ParentCategory = pCategory
            pModel.CategoryList = _categoryDao.SelectCategoryItems(pCategory.Id)
            floorList.Add(pModel)
        Next

        Dim categoriesNoTire As List(Of Category) = _categoryDao.SelectCategoryNoTire()
        Dim categories As List(Of List(Of Category)) = New List(Of List(Of Category))

        Dim modCount As Integer = categoriesNoTire.Count Mod 3
        For i = 0 To categoriesNoTire.Count - 1 Step 3

            Dim categoriesOne As List(Of Category) = New List(Of Category)
            If i + 3 > categoriesNoTire.Count - 1 Then
                categoriesOne = categoriesNoTire.GetRange(i, modCount)
            Else
                categoriesOne = categoriesNoTire.GetRange(i, 3)
            End If

            categories.Add(categoriesOne)
        Next

        Dim model As HomeDataDto = New HomeDataDto
        model.FloorList = floorList
        model.CategoryList = categories
        If user IsNot Nothing Then
            model.CartCount = _cartDao.SelectCartCount(Convert.ToString(user.Id))(0).Count
        End If

        Return ServerResponse(Of HomeDataDto).createBySuccess("检索成功", model)
    End Function
End Class
