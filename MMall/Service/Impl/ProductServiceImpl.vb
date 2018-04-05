Imports MMall

Public Class ProductServiceImpl : Implements IProductService

    Private _productDao As IProductDao = New ProductDaoImpl
    Private _cartDao As ICartDao = New CartDaoImpl

    Public Function AddProductToCart(viewModel As GoodsAddCartSuccessViewModel) As ServerResponse(Of Integer) Implements IProductService.AddProductToCart
        If String.IsNullOrEmpty(viewModel.ProductId) Then
            Return ServerResponse(Of Integer).CreateByErrorMessage("参数错误")
        End If
        Dim result As Boolean = _cartDao.InsertCartByProductDetail(viewModel)
        If Not result Then
            Return ServerResponse(Of Integer).CreateByErrorMessage("添加到购物车失败")
        End If
        Dim count As Integer = _cartDao.SelectCartCount(viewModel.UserId)(0).Count
        Return ServerResponse(Of Integer).createBySuccess(count)
    End Function

    Public Function GetProductByKeyword(viewModel As GoodsListViewModel) As ServerResponse(Of ProductInfoDto) Implements IProductService.GetProductByKeyword

        viewModel.Keyword = "%" & viewModel.Keyword & "%"

        Dim page As Page = _productDao.SelectCountByProductName(viewModel)(0)
        page = PageUtils.ComputedPage(page, viewModel.PageNo, ConstVal.PAGE_SIZE_GODDS)


        Dim productList As List(Of Product) = _productDao.SelectByProductName(viewModel)
        If productList.Count = 0 Then
            Return ServerResponse(Of ProductInfoDto).CreateByErrorMessage("很抱歉，找不到您要的商品。")
        End If
        Dim dto As ProductInfoDto = New ProductInfoDto
        dto.Page = page
        dto.ProductList = productList
        Return ServerResponse(Of ProductInfoDto).createBySuccess(dto)
    End Function

    Public Function GetProductDetailById(productId As String) As ServerResponse(Of ProductDtailInfoDto) Implements IProductService.GetProductDetailById
        Dim list As List(Of Product) = _productDao.SelectDetailByProductId(productId)
        If list.Count = 0 Then
            Return ServerResponse(Of ProductDtailInfoDto).CreateByErrorMessage("没有对应的商品详情")
        End If
        Dim productDetail As Product = list(0)

        Return ServerResponse(Of ProductDtailInfoDto).createBySuccess(Me.Assemble(productDetail))
    End Function
    Private Function Assemble(product As Product) As ProductDtailInfoDto
        Dim dto As ProductDtailInfoDto = New ProductDtailInfoDto
        dto.Id = product.Id
        dto.CategoryId = product.CategoryId
        dto.Name = product.Name
        dto.Subtitle = product.Subtitle
        dto.MainImage = product.MainImage
        Dim subs() As String = Split(product.SubImages, ",")
        dto.SubImages = subs
        dto.Detail = product.Detail
        dto.Price = product.Price
        dto.Stock = product.Stock
        dto.Status = product.Status
        dto.CreateTime = product.CreateTime
        Return dto
    End Function
End Class
