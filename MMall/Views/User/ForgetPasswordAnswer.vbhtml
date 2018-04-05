@ModelType ForgetPasswrodViewModel
@Code
    ViewData("Title") = "找回密码"
End Code

<link href="@Url.Content("~/Content/user-pass-reset.css")" rel="stylesheet" type="text/css" />
@RenderPage("~/Views/Shared/_Header2.vbhtml")
@Using Html.BeginForm
    Html.HiddenFor(Function(model) model.Username)
    Html.HiddenFor(Function(model) model.Question)
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
                <div class="step-con step-question">
                    <p class="user-item-text">密码提示问题是：<span class="question">@Model.Question</span></p>
                    <div class="user-item">
                        <label class="user-label" for="">
                            <i class="fa fa-key"></i>
                        </label>
                        @Html.TextBoxFor(Function(model) model.Answer, "", New With {Key .class = "user-content", .placeholder = "请输入密码提示问题答案", .autocomplete = "off"})
                    </div>
                    <input type="submit" class="btn btn-submit" value="下一步"/>
                </div>

                <div class="link-item">
                    <a class="link" href="./user-login.html" target="_blank">返回登录>></a>
                </div>
            </div>
        </div>
    </div>
</div>
End Using