Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Private _homeService As IHomeService = New HomeServiceImpl
    ''' <summary>
    ''' 首页
    ''' </summary>
    ''' <returns></returns>
    Function Index() As ActionResult
        Dim user As User = DirectCast(Session(ConstVal.CURRENT_USER), User)
        Dim viewModel As HomeIndexViewModel = New HomeIndexViewModel
        Dim res As ServerResponse(Of HomeDataDto) = _homeService.SelectHomeData(user)
        viewModel.Result = res
        ' 更新session中购物车数量
        Session(ConstVal.CURRENT_CART_COUNT) = res.Data.CartCount
        Return View(viewModel)
    End Function
End Class
