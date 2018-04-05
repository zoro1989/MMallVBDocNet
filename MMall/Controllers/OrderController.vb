Imports System.Web.Mvc

Namespace Controllers
    Public Class OrderController
        Inherits Controller
        Dim _orderService As IOrderService = New OrderServiceImpl
        ' GET: Order
        Function List(Optional pageNo As Integer = 1) As ActionResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            If user Is Nothing Then
                Return RedirectToAction("Login", "User")
            End If
            Dim res As ServerResponse(Of OrderListInfoDto) = _orderService.GetOrderList(user, pageNo, ConstVal.PAGE_SIZE)

            If Not res.IsSuccess Then
                ModelState.AddModelError("error-field", res.Msg)
            End If
            Dim viewModel As OrderListViewModel = New OrderListViewModel
            viewModel.Result = res
            Return View(viewModel)
        End Function
        Function Detail(orderNumber As String) As ActionResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            If user Is Nothing Then
                Return RedirectToAction("Login", "User")
            End If
            Dim res As ServerResponse(Of OrderInfoDto) = _orderService.GetOrderDetail(orderNumber, Convert.ToString(user.Id))
            If Not res.IsSuccess Then
                ModelState.AddModelError("error-field", res.Msg)
            End If
            Dim viewModel As OrderDetailViewModel = New OrderDetailViewModel
            viewModel.Result = res
            Return View(viewModel)
        End Function
    End Class
End Namespace