﻿Imports MMall

Public Class UserServiceImpl : Implements IUserService
    Private _userDao As IUserDao = New UserDaoImpl
    Private _cartDao As ICartDao = New CartDaoImpl
    ''' <summary>
    ''' 监测答案
    ''' </summary>
    ''' <param name="viewModel"></param>
    ''' <returns></returns>
    Public Function CheckAnswer(viewModel As ForgetPasswrodViewModel) As ServerResponse(Of String) Implements IUserService.CheckAnswer
        Dim resultCount As Integer = _userDao.CheckAnswer(viewModel.Username, viewModel.Question, viewModel.Answer).Count
        If resultCount > 0 Then
            ' 检索到答案,存一个token在服务端,饼把token传给前端,因为token设置了100秒过时,稍微保障了一下安全性,防止别人恶意无限改密码
            Dim forgetToken As String = Guid.NewGuid.ToString
            TokenCache.SetKey(TokenCache.TOKEN_PREFIX & viewModel.Username, forgetToken)
            Return ServerResponse(Of String).createBySuccess(forgetToken)
        End If
        Return ServerResponse(Of String).CreateByErrorMessage("问题答案错误")
    End Function
    ''' <summary>
    ''' 重置密码
    ''' </summary>
    ''' <param name="viewModel"></param>
    ''' <returns></returns>
    Public Function ForgetResetPassword(viewModel As ForgetPasswrodViewModel) As ServerResponse(Of String) Implements IUserService.ForgetResetPassword
        ' 若前端没有传token,则是虚假请求
        If String.IsNullOrEmpty(viewModel.ForgetToken) Then
            Return ServerResponse(Of String).CreateByErrorMessage("参数错误,token需要传递")
        End If
        Dim resultCount As Integer = _userDao.CheckUsername(viewModel.Username).Count
        If resultCount = 0 Then
            Return ServerResponse(Of String).CreateByErrorMessage("用户不存在")
        End If
        ' 服务端取得的token要是没有,就说明token过期了
        Dim token As String = TokenCache.GetKey(TokenCache.TOKEN_PREFIX & viewModel.Username)
        If String.IsNullOrEmpty(token) Then
            Return ServerResponse(Of String).CreateByErrorMessage("token无效或过期")
        End If
        ' 只有前端传过来的token和服务端保存的一样才允许修改密码
        If token.Equals(viewModel.ForgetToken) Then
            Dim md5Password As String = Md5Util.SetMd5Pass(viewModel.PasswordNew)
            Dim res As Boolean = _userDao.UpdatePasswordByUsername(viewModel.Username, md5Password)
            If res Then
                Return ServerResponse(Of String).CreateBySuccessMessage("修改密码成功")
            End If
        Else
            Return ServerResponse(Of String).CreateByErrorMessage("token错误,请重新获取重置密码的token")
        End If
        Return ServerResponse(Of String).CreateByErrorMessage("修改密码失败")
    End Function
    ''' <summary>
    ''' 登录
    ''' </summary>
    ''' <param name="viewModel"></param>
    ''' <returns></returns>
    Public Function Login(viewModel As UserLoginViewModel) As ServerResponse(Of UserLoginDto) Implements IUserService.Login
        Dim resultCount As Integer = _userDao.CheckUsername(viewModel.Username).Count
        If resultCount = 0 Then
            Return ServerResponse(Of UserLoginDto).CreateByErrorMessage("用户名不存在")
        End If
        Dim md5Password As String = Md5Util.SetMd5Pass(viewModel.Password)

        Dim userList As List(Of User) = _userDao.SelectLogin(viewModel.Username, md5Password)
        If userList.Count = 0 Then
            Return ServerResponse(Of UserLoginDto).CreateByErrorMessage("密码错误")
        End If
        Dim user As User = userList(0)
        user.Password = String.Empty

        Dim cartCount As Integer = _cartDao.SelectCartCount(Convert.ToString(user.Id))(0).Count
        Dim dto As UserLoginDto = New UserLoginDto
        dto.User = user
        dto.CartCount = cartCount
        Return ServerResponse(Of UserLoginDto).createBySuccess("登录成功", dto)
    End Function
    ''' <summary>
    ''' 注册
    ''' </summary>
    ''' <param name="viewModel"></param>
    ''' <returns></returns>
    Public Function Register(viewModel As UserRegisterViewModel) As ServerResponse(Of String) Implements IUserService.Register
        Dim validResponse As ServerResponse(Of String) = Me.CheckValid(viewModel.Username, ConstVal.USERNAME)
        If Not validResponse.IsSuccess Then
            Return validResponse
        End If
        validResponse = Me.CheckValid(viewModel.Email, ConstVal.EMAIL)
        If Not validResponse.IsSuccess Then
            Return validResponse
        End If
        validResponse = Me.CheckPasswrod(viewModel.Password, viewModel.PasswordConfirm)
        If Not validResponse.IsSuccess Then
            Return validResponse
        End If
        ' 普通用户权限
        viewModel.Role = ConstVal.Role.ROLE_CUSTOMER
        ' 密码进行md5加密
        viewModel.Password = Md5Util.SetMd5Pass(viewModel.Password)
        Dim result As Boolean = _userDao.InsertUser(viewModel)
        If Not result Then
            Return ServerResponse(Of String).CreateByErrorMessage("注册失败")
        End If
        Return ServerResponse(Of String).CreateBySuccessMessage("注册成功")
    End Function
    ''' <summary>
    ''' 检索问题
    ''' </summary>
    ''' <param name="viewModel"></param>
    ''' <returns></returns>
    Public Function SelectQuestion(viewModel As ForgetPasswrodViewModel) As ServerResponse(Of String) Implements IUserService.SelectQuestion

        If String.IsNullOrEmpty(viewModel.Username) Then
            Return ServerResponse(Of String).CreateByErrorMessage("请输入用户名")
        End If

        Dim validResponse As ServerResponse(Of String) = Me.CheckValid(viewModel.Username, ConstVal.USERNAME)
        If validResponse.IsSuccess Then
            Return ServerResponse(Of String).CreateByErrorMessage("用户不存在")
        End If

        Dim res As List(Of User) = _userDao.SelectQuestionByUsername(viewModel.Username)
        If res.Count > 0 Then
            Dim question As String = res(0).Question
            Return ServerResponse(Of String).createBySuccess(question)
        End If
        Return ServerResponse(Of String).CreateByErrorMessage("找回密码的问题是空的")
    End Function
    ''' <summary>
    ''' 检测密码
    ''' </summary>
    ''' <param name="password"></param>
    ''' <param name="passwordConfirm"></param>
    ''' <returns></returns>
    Private Function CheckPasswrod(password As String, passwordConfirm As String) As ServerResponse(Of String)
        If String.IsNullOrEmpty(password) Then
            Return ServerResponse(Of String).CreateByErrorMessage("请输入密码")
        End If
        If String.IsNullOrEmpty(passwordConfirm) Then
            Return ServerResponse(Of String).CreateByErrorMessage("请输入确认密码")
        End If
        If Not password.Equals(passwordConfirm) Then
            Return ServerResponse(Of String).CreateByErrorMessage("密码和确认密码不一致")
        End If
        Return ServerResponse(Of String).CreateBySuccessMessage("校验成功")
    End Function
    ''' <summary>
    ''' 输入校验
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="type"></param>
    ''' <returns></returns>
    Private Function CheckValid(str As String, type As String) As ServerResponse(Of String)
        If Not String.IsNullOrEmpty(type) Then
            ' 开始校验
            If ConstVal.USERNAME.Equals(type) Then

                Dim resultCount As Integer = _userDao.CheckUsername(str).Count
                If resultCount > 0 Then
                    Return ServerResponse(Of String).CreateByErrorMessage("用户名已存在")
                End If
            End If
            If ConstVal.EMAIL.Equals(type) Then
                Dim resultCount As Integer = _userDao.CheckEmail(str).Count
                If resultCount > 0 Then
                    Return ServerResponse(Of String).CreateByErrorMessage("email已存在")
                End If
            End If
        Else
            Return ServerResponse(Of String).CreateByErrorMessage("参数错误")
        End If
        Return ServerResponse(Of String).CreateBySuccessMessage("校验成功")
    End Function
End Class
