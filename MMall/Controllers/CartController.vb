Imports System.Web.Mvc
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Controllers
    Public Class CartController
        Inherits Controller
        Private _cartService As ICartService = New CartServiceImpl
        ' GET: Cart
        Function Index() As ActionResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            If user Is Nothing Then
                Return RedirectToAction("Login", "User")
            End If
            Dim res As ServerResponse(Of CartInfo) = _cartService.GetAllCartProducts(Convert.ToString(user.Id))
            If Not res.IsSuccess Then
                ModelState.AddModelError("error-field", res.Msg)
            End If
            Dim viewModel As CartIndexViewModel = New CartIndexViewModel
            viewModel.Result = res
            Return View(viewModel)
        End Function
        Function Delete(cartIds() As String) As JsonResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            Dim res As ServerResponse(Of Integer) = _cartService.DeleteCartById(cartIds, Convert.ToString(user.Id))
            Session(ConstVal.CURRENT_CART_COUNT) = res.Data
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function
        Function OrderConfirm(carts As String) As JsonResult
            Dim cartsObj As List(Of CartConfirmDto) = JsonConvert.DeserializeObject(Of List(Of CartConfirmDto))(carts)
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            Dim res As ServerResponse(Of Boolean) = _cartService.UpdateCartInfo(cartsObj, user)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function
        Function Confirm() As ActionResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            If user Is Nothing Then
                Return RedirectToAction("Login", "User")
            End If
            Dim res As ServerResponse(Of CartInfo) = _cartService.GetAllCheckedCartInfoByUserId(Convert.ToString(user.Id))
            If Not res.IsSuccess Then
                ModelState.AddModelError("error-field", res.Msg)
            End If
            Dim viewModel As CartConfirmViewModel = New CartConfirmViewModel
            viewModel.Result = res
            Return View(viewModel)
        End Function
        Function OrderCommit(shippingId As String) As ActionResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            If user Is Nothing Then
                Return RedirectToAction("Login", "User")
            End If
            Dim res As ServerResponse(Of Boolean) = _cartService.CreateOrder(shippingId, Convert.ToString(user.Id))
            Return Redirect("CreateOrderSuccess")
        End Function
        Function CreateOrderSuccess() As ActionResult
            Return View()
        End Function
    End Class
End Namespace