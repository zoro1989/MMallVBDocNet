@ModelType UserLoginViewModel
@Code
    ViewData("Title") = "登录"
End Code
<link href="@Url.Content("~/Content/login.css")" rel="stylesheet" type="text/css" />
@RenderPage("~/Views/Shared/_Header2.vbhtml")
@Using Html.BeginForm()
@<div class="page-wrap">
    <div class="w">
        <div class="user-con">
            <div class="user-title">用户录入</div>
            <div class="user-box">
                @If Model.Result IsNot Nothing AndAlso （Not Model.Result.IsSuccess) Then
                @<div Class="error-item">
                    <i Class="fa fa-minus-circle error-icon"></i>
                    @Html.ValidationMessage("error-field", New With {Key .class = "err-msg"}).
                </div>
                End If
                <div class="user-item">
                    <label class="user-label" for="username">
                        <i class="fa fa-user"></i>
                    </label>
                    @Html.TextBoxFor(Function(model) model.Username, "", New With {Key .class = "user-content", .placeholder = "请输入用户名", .autocomplete = "off"})
                </div>
                <div class="user-item">
                    <label class="user-label" for="password">
                        <i class="fa fa-lock"></i>
                    </label>
                    @Html.PasswordFor(Function(model) model.Password, New With {Key .class = "user-content", .placeholder = "请输入密码", .autocomplete = "off"})
                </div>
                <input class="btn btn-submit" type="submit" value="登录" />
                <div class="link-item">
                    <a class="link" href="@Url.Action("ForgetPassword", "User")">忘记密码</a>
                    <a Class="link" href="@Url.Action("Register", "User")">免费注册</a>
                </div>
            </div>
        </div>
    </div>
</div>

End Using