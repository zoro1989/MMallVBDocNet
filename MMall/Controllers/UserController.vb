Imports System.Web.Mvc

Namespace Controllers
    Public Class UserController
        Inherits Controller

        Private _userService As IUserService = New UserServiceImpl
        ''' <summary>
        ''' 登录
        ''' </summary>
        ''' <returns></returns>
        Function Login() As ActionResult
            Dim viewModel As UserLoginViewModel = New UserLoginViewModel
            Return View(viewModel)
        End Function
        ''' <summary>
        ''' 登录action
        ''' </summary>
        ''' <param name="viewModel"></param>
        ''' <returns></returns>
        <HttpPost()>
        Function Login(ByVal viewModel As UserLoginViewModel) As ActionResult

            Dim res As ServerResponse(Of UserLoginDto) = _userService.Login(viewModel)
            If res.IsSuccess Then
                ' 在session中保存用户对象
                Session(ConstVal.CURRENT_USER) = res.Data.User
                ' 在session中保存购物车数量
                Session(ConstVal.CURRENT_CART_COUNT) = res.Data.CartCount
                ' 获取session中的历史url信息,若有历史记录则跳转历史记录中的url
                Dim history As HistoryUrlDto = DirectCast(Session(ConstVal.HISTORY_URL), HistoryUrlDto)
                If history Is Nothing Then
                    Return RedirectToAction("Index", "Home")
                Else
                    Return RedirectToAction(history.ActionName, history.ControllerName, history.RouteValues)
                End If

            Else
                ModelState.AddModelError("error-field", res.Msg)
            End If
            viewModel.Result = res
            Return View(viewModel)

        End Function
        ''' <summary>
        ''' 退出登录
        ''' </summary>
        ''' <returns></returns>
        Function Logout() As ActionResult
            Session.Remove(ConstVal.CURRENT_USER)
            Return RedirectToAction("Index", "Home")
        End Function
        ''' <summary>
        ''' 注册初始化
        ''' </summary>
        ''' <returns></returns>
        <HttpGet>
        Function Register() As ActionResult
            Dim viewModel As UserRegisterViewModel = New UserRegisterViewModel
            Return View(viewModel)
        End Function
        ''' <summary>
        ''' 注册表单提交
        ''' </summary>
        ''' <param name="viewModel"></param>
        ''' <returns></returns>
        <HttpPost>
        Function Register(viewModel As UserRegisterViewModel) As ActionResult
            Dim res As ServerResponse(Of String) = _userService.Register(viewModel)
            If res.IsSuccess Then
                Return RedirectToAction("RegisterSuccess", "User")
            Else
                ModelState.AddModelError("error-field", res.Msg)
            End If
            viewModel.Result = res
            Return View(viewModel)
        End Function
        ''' <summary>
        ''' 注册成功
        ''' </summary>
        ''' <returns></returns>
        Function RegisterSuccess() As ActionResult
            Return View()
        End Function

        ''' <summary>
        ''' 忘记密码
        ''' </summary>
        ''' <returns></returns>
        Function ForgetPassword() As ActionResult
            Dim viewModel As ForgetPasswrodViewModel = New ForgetPasswrodViewModel
            Return View(viewModel)
        End Function
        ''' <summary>
        ''' 忘记密码提交
        ''' </summary>
        ''' <param name="viewModel"></param>
        ''' <returns></returns>
        <HttpPost>
        Function ForgetPassword(viewModel As ForgetPasswrodViewModel) As ActionResult
            Dim res As ServerResponse(Of String) = _userService.SelectQuestion(viewModel)
            If res.IsSuccess Then
                Return RedirectToAction("ForgetPasswordAnswer", "User", New With {Key .Username = viewModel.Username, .Question = res.Data})
            Else
                ModelState.AddModelError("error-field", res.Msg)
            End If
            viewModel.Result = res
            Return View(viewModel)
        End Function
        ''' <summary>
        ''' 忘记密码-答案
        ''' </summary>
        ''' <param name="username"></param>
        ''' <param name="question"></param>
        ''' <returns></returns>
        Function ForgetPasswordAnswer(username As String, question As String) As ActionResult
            Dim viewModel As ForgetPasswrodViewModel = New ForgetPasswrodViewModel
            viewModel.Username = username
            viewModel.Question = question
            Return View(viewModel)
        End Function
        ''' <summary>
        ''' 忘记密码-答案提交
        ''' </summary>
        ''' <param name="viewModel"></param>
        ''' <returns></returns>
        <HttpPost>
        Function ForgetPasswordAnswer(viewModel As ForgetPasswrodViewModel) As ActionResult
            Dim res As ServerResponse(Of String) = _userService.CheckAnswer(viewModel)
            If res.IsSuccess Then
                Return RedirectToAction("ForgetPasswrodNewPassword", "User", New With {Key .Username = viewModel.Username, .ForgetToken = res.Data})
            Else
                ModelState.AddModelError("error-field", res.Msg)
            End If
            viewModel.Result = res
            Return View(viewModel)
        End Function
        ''' <summary>
        ''' 忘记密码-新密码
        ''' </summary>
        ''' <param name="username"></param>
        ''' <param name="forgetToken"></param>
        ''' <returns></returns>
        Function ForgetPasswrodNewPassword(username As String, forgetToken As String) As ActionResult
            Dim viewModel As ForgetPasswrodViewModel = New ForgetPasswrodViewModel
            viewModel.Username = username
            ' 讲密码token返回给前端
            viewModel.ForgetToken = forgetToken
            Return View(viewModel)
        End Function
        ''' <summary>
        ''' 忘记喵喵-新密码提交
        ''' </summary>
        ''' <param name="viewModel"></param>
        ''' <returns></returns>
        <HttpPost>
        Function ForgetPasswrodNewPassword(viewModel As ForgetPasswrodViewModel) As ActionResult
            Dim res As ServerResponse(Of String) = _userService.ForgetResetPassword(viewModel)
            If res.IsSuccess Then
                Return RedirectToAction("ResetPasswordSuccess", "User")
            Else
                ModelState.AddModelError("error-field", res.Msg)
            End If
            viewModel.Result = res
            Return View(viewModel)
        End Function

        Function ResetPasswordSuccess() As ActionResult
            Return View()
        End Function

    End Class
End Namespace