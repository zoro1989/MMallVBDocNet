Imports System.Web.Mvc

Namespace Controllers
    Public Class GoodsController
        Inherits Controller
        Dim _productService As IProductService = New ProductServiceImpl
        ' GET: Goods
        Function List(viewModel As GoodsListViewModel) As ActionResult

            If String.IsNullOrEmpty(viewModel.Keyword) Then
                Session(ConstVal.CURRENT_INPUT) = String.Empty
            Else
                Session(ConstVal.CURRENT_INPUT) = viewModel.Keyword
            End If
            If String.IsNullOrEmpty(viewModel.CategoryId) Then
                Session(ConstVal.CURRENT_CATEGORYID) = String.Empty
            Else
                Session(ConstVal.CURRENT_CATEGORYID) = viewModel.CategoryId
            End If

            Dim res As ServerResponse(Of ProductInfoDto) = _productService.GetProductByKeyword(viewModel)
            If Not res.IsSuccess Then
                ModelState.AddModelError("error-field", res.Msg)
            End If

            viewModel.Result = res
            Return View(viewModel)
        End Function
        Function Detail(productId As String, Optional quantity As Integer = 1) As ActionResult
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
        Function AddCartSuccess(viewModel As GoodsAddCartSuccessViewModel) As ActionResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            If user Is Nothing Then
                Dim history As HistoryUrlDto = HistoryBackCache.SetHistoryUrl("Detail", "Goods", New With {Key .Quantity = viewModel.Quantity, .ProductId = viewModel.ProductId})
                Session(ConstVal.HISTORY_URL) = history
                Return RedirectToAction("Login", "User")
            End If
            viewModel.UserId = Convert.ToString(user.Id)
            Dim res As ServerResponse(Of Integer) = _productService.AddProductToCart(viewModel)
            Session(ConstVal.CURRENT_CART_COUNT) = res.Data
            Return View()
        End Function

    End Class
End Namespace