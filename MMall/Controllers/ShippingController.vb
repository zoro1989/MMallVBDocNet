Imports System.Web.Mvc

Namespace Controllers
    Public Class ShippingController
        Inherits Controller
        Dim _shippingService As IShippingService = New ShippingServiceImpl
        ' GET: Shipping
        <HttpPost>
        Function Add(viewModel As CartAddViewModel) As JsonResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            viewModel.UserId = user.Id
            Dim res As ServerResponse(Of Shipping) = _shippingService.AddShipping(viewModel)

            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Function Delete(shippingId As String) As JsonResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            Dim res As ServerResponse(Of String) = _shippingService.DeleteShipping(shippingId, Convert.ToString(user.Id))
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function
        Function Edit(shippingId As String) As JsonResult
            Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
            Dim res As ServerResponse(Of Shipping) = _shippingService.GetShippingInfoById(shippingId, Convert.ToString(user.Id))
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function
    End Class
End Namespace