Imports System.Web.Mvc

Namespace Controllers
    Public Class GoodsController
        Inherits Controller
        Dim _productService As IProductService = New ProductServiceImpl
        ''' <summary>
        ''' 商品列表
        ''' </summary>
        ''' <param name="viewModel"></param>
        ''' <returns></returns>
        Function List(viewModel As GoodsListViewModel) As ActionResult
            ' 更新session中搜索框关键字
            If String.IsNullOrEmpty(viewModel.Keyword) Then
                Session(ConstVal.CURRENT_INPUT) = String.Empty
            Else
                Session(ConstVal.CURRENT_INPUT) = viewModel.Keyword
            End If
            ' 更新session中商品类别Id
            If String.IsNullOrEmpty(viewModel.CategoryId) Then
                Session(ConstVal.CURRENT_CATEGORYID) = String.Empty
            Else
                Session(ConstVal.CURRENT_CATEGORYID) = viewModel.CategoryId
            End If

            Dim res As ServerResponse(Of ProductInfoDto) = _productService.GetProductByKeyword(viewModel)
            ' 若有错误,添加到modelstate
            If Not res.IsSuccess Then
                ModelState.AddModelError("error-field", res.Msg)
            End If

            viewModel.Result = res
            Return View(viewModel)
        End Function
        ''' <summary>
        ''' 商品详情
        ''' </summary>
        ''' <param name="productId"></param>
        ''' <param name="quantity"></param>
        ''' <returns></returns>
        Function Detail(productId As String, Optional quantity As Integer = 1) As ActionResult
            ' 清空session中的历史Url信息
            Session.Remove(ConstVal.HISTORY_URL)
            Dim res As ServerResponse(Of ProductDtailInfoDto) = _productService.GetProductDetailById(productId)
            If Not res.IsSuccess Then
                ModelState.AddModelError("error-field", res.Msg)
            End If
            Dim model As GoodsDetailViewModel = New GoodsDetailViewModel
            model.Result = res
            model.Quantity = quantity
            Return View(model)
        End Function
        ''' <summary>
        ''' 成功添加到购物车
        ''' </summary>
        ''' <param name="viewModel"></param>
        ''' <returns></returns>
        Function AddCartSuccess(viewModel As GoodsAddCartSuccessViewModel) As ActionResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            If user Is Nothing Then
                ' 若用户未登陆,保存商品详情页面的信息到session,以便登陆后回显
                Dim history As HistoryUrlDto = HistoryBackCache.SetHistoryUrl("Detail", "Goods", New With {Key .Quantity = viewModel.Quantity, .ProductId = viewModel.ProductId})
                Session(ConstVal.HISTORY_URL) = history
                ' 未登陆跳转登陆
                Return RedirectToAction("Login", "User")
            End If
            ' 已登陆设置用户Id
            viewModel.UserId = Convert.ToString(user.Id)
            Dim res As ServerResponse(Of Integer) = _productService.AddProductToCart(viewModel)
            Session(ConstVal.CURRENT_CART_COUNT) = res.Data
            Return View()
        End Function

    End Class
End Namespace