Imports System.Web.Mvc
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Controllers
    Public Class CartController
        Inherits Controller
        Private _cartService As ICartService = New CartServiceImpl
        ''' <summary>
        ''' 购物车列表
        ''' </summary>
        ''' <returns></returns>
        Function Index() As ActionResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            ' 未登录去登陆
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
        ''' <summary>
        ''' 根据购物车id数组删除购物车
        ''' </summary>
        ''' <param name="cartIds"></param>
        ''' <returns></returns>
        Function Delete(cartIds() As String) As JsonResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            Dim res As ServerResponse(Of Integer) = _cartService.DeleteCartById(cartIds, Convert.ToString(user.Id))
            ' 更新session中的购物车商品数量
            Session(ConstVal.CURRENT_CART_COUNT) = res.Data
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function
        ''' <summary>
        ''' 订单确认更新购物车信息,接收购物车对象数组json字符串(对象中是购物车id,选择的商品数量,是否选中)
        ''' </summary>
        ''' <param name="carts"></param>
        ''' <returns></returns>
        Function OrderConfirm(carts As String) As JsonResult
            ' 讲接收到的购物车信息json转成vb对象
            Dim cartsObj As List(Of CartConfirmDto) = JsonConvert.DeserializeObject(Of List(Of CartConfirmDto))(carts)
            ' 从session获取用户
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            Dim res As ServerResponse(Of Boolean) = _cartService.UpdateCartInfo(cartsObj, user)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function
        ''' <summary>
        ''' 订单确认页面初始化
        ''' </summary>
        ''' <returns></returns>
        Function Confirm() As ActionResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            ' 未登录去登陆
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
        ''' <summary>
        ''' 提交订单,生成订单
        ''' </summary>
        ''' <param name="shippingId"></param>
        ''' <returns></returns>
        Function OrderCommit(shippingId As String) As ActionResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            If user Is Nothing Then
                Return RedirectToAction("Login", "User")
            End If
            Dim res As ServerResponse(Of Boolean) = _cartService.CreateOrder(shippingId, Convert.ToString(user.Id))
            Return Redirect("CreateOrderSuccess")
        End Function
        ''' <summary>
        ''' 创建订单成功
        ''' </summary>
        ''' <returns></returns>
        Function CreateOrderSuccess() As ActionResult
            Return View()
        End Function
    End Class
End Namespace