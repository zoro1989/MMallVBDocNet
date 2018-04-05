@ModelType ForgetPasswrodViewModel
@Code
    ViewData("Title") = "找回密码"
End Code

<link href="@Url.Content("~/Content/user-pass-reset.css")" rel="stylesheet" type="text/css" />
@RenderPage("~/Views/Shared/_Header2.vbhtml")
@Using Html.BeginForm
    Html.HiddenFor(Function(model) model.Username)
    Html.HiddenFor(Function(model) model.ForgetToken)
@<div Class="page-wrap">
    <div Class="w">
        <div Class="user-con">
            <div Class="user-title">找回密码</div>
            <div Class="user-box">
                @If Model.Result IsNot Nothing AndAlso （Not Model.Result.IsSuccess) Then
                    @<div Class="error-item">
                        <i Class="fa fa-minus-circle error-icon"></i>
                        @Html.ValidationMessage("error-field", New With {Key .class = "err-msg"}).
                    </div>
                End If
                <div Class="step-con step-password">
                    <p Class="user-item-text">请输入新密码：</p>
                    <div Class="user-item">
                        <Label Class="user-label" for="">
                            <i Class="fa fa-lock"></i>
                        </label>
                        @Html.TextBoxFor(Function(model) model.PasswordNew, "", New With {Key .class = "user-content", .placeholder = "请输入新密码", .autocomplete = "off"})
                    </div>
                    <input class="btn btn-submit" type="submit" value="下一步" />
                </div>

                <div Class="link-item">
                    <a Class="link" href="./user-login.html" target="_blank">返回登录>></a>
                </div>
            </div>
        </div>
    </div>
</div>
End Using