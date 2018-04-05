@Code
    ViewData("Title") = "添加订单成功"
End Code
<link href="@Url.Content("~/Content/result.css")" rel="stylesheet" type="text/css" />
@RenderPage("~/Views/Shared/_Header2.vbhtml")
<div class="page-wrap w">
    <div class="result-con register-success">
        <h1 class="result-title">添加订单成功</h1>
        <div class="result-content">
            <a class="link" href="@Url.Action("Index", "Home")">继续购物</a>
            <a class="link" href="@Url.Action("List", "Order")">去订单中心查看</a>
        </div>
    </div>
</div>
