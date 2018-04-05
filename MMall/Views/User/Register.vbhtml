@ModelType UserRegisterViewModel
@Code
    ViewData("Title") = "注册"
End Code
<link href="@Url.Content("~/Content/register.css")" rel="stylesheet" type="text/css" />
@RenderPage("~/Views/Shared/_Header2.vbhtml")
@Using Html.BeginForm()
@<div Class="page-wrap">
    <div Class="w">
        <div Class="user-con">
            <div Class="user-title">用户注册</div>
            <div Class="user-box">
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
                <div class="user-item">
                    <label class="user-label" for="password-confirm">
                        <i class="fa fa-lock"></i>
                    </label>
                    @Html.PasswordFor(Function(model) model.PasswordConfirm, New With {Key .class = "user-content", .placeholder = "请再次输入密码", .autocomplete = "off"})
                </div>
                <div class="user-item">
                    <label class="user-label" for="phone">
                        <i class="fa fa-phone"></i>
                    </label>
                    @Html.TextBoxFor(Function(model) model.Phone, "", New With {Key .class = "user-content", .placeholder = "请输入手机号", .autocomplete = "off"})
                </div>
                <div class="user-item">
                    <label class="user-label" for="email">
                        <i class="fa fa-envelope"></i>
                    </label>
                    @Html.TextBoxFor(Function(model) model.Email, "", New With {Key .class = "user-content", .placeholder = "请输入邮箱", .autocomplete = "off"})
                </div>
                <div class="user-item">
                    <label class="user-label" for="question">
                        <i class="fa fa-question"></i>
                    </label>
                    @Html.TextBoxFor(Function(model) model.Question, "", New With {Key .class = "user-content", .placeholder = "请输入密码提示问题", .autocomplete = "off"})
                </div>
                <div class="user-item">
                    <label class="user-label" for="answer">
                        <i class="fa fa-key"></i>
                    </label>
                    @Html.TextBoxFor(Function(model) model.Answer, "", New With {Key .class = "user-content", .placeholder = "请输入密码提示问题答案", .autocomplete = "off"})
                </div>
                <input class="btn btn-submit" type="submit" value="立即注册" />
                <div class="link-item">
                    <a class="link" href="./user-login.html">已有帐号，去登录>></a>
                </div>
            </div>
        </div>
    </div>
</div>

End Using