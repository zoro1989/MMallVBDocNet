@Code
    ViewData("Title") = "注册成功"
End Code
<link href="@Url.Content("~/Content/result.css")" rel="stylesheet" type="text/css" />
@RenderPage("~/Views/Shared/_Header2.vbhtml")
<div class="page-wrap w">
    <div class="result-con register-success">
        <h1 class="result-title">恭喜您，重置密码成功！</h1>
        <div class="result-content">
            <a class="link" href="@Url.Action("Index", "Home")">回到首页</a>
            <a class="link" href="@Url.Action("Login", "User")">立即去登录</a>
        </div>
    </div>
</div>

