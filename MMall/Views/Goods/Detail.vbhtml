@ModelType GoodsDetailViewModel
@Code
    ViewData("Title") = "商品详情"
End Code
<link href="@Url.Content("~/Content/goods-detail.css")" rel="stylesheet" type="text/css" />
<script src="@Url.Content("~/Scripts/goodsdetail.js")"></script>
@RenderPage("~/Views/Shared/_Header.vbhtml")
<div class="crumb">
    <div class="w">
        <div class="crumb-con">
            <a class="link" href="./index.html">Mall</a>
            <span>></span>
            <span class="link-text">商品详情</span>
        </div>
    </div>
</div>
@If Model.Result IsNot Nothing AndAlso Model.Result.Data IsNot Nothing Then
@<div Class="page-wrap w">
    <div Class="intro-wrap">
        <div Class="p-img-con">
            <div Class="main-img-con">
                <img Class="main-img" id="main-img" src="http://img.happymmall.com/@Model.Result.Data.MainImage" alt="@Model.Result.Data.Name" />
            </div>
            <ul Class="p-img-list">
                @For Each subImage In Model.Result.Data.SubImages
                @<li Class="p-img-item">
                    <img Class="p-img" src="http://img.happymmall.com/@subImage" alt="subImage" onmouseover="subImageOver('@subImage')" />
                </li>
                Next
            </ul>
        </div>
        <div Class="p-info-con">
            <h1 Class="p-name">@Model.Result.Data.Name</h1>
            <p Class="p-subtitle">@Model.Result.Data.Subtitle</p>
            <div Class="p-info-item p-price-con">
                <span Class="label">价格:</span>
                <span Class="info">￥@Model.Result.Data.Price</span>
            </div>
            <div class="p-info-item">
                <span class="label">库存:</span>
                <span class="info">@Model.Result.Data.Stock</span>
            </div>
            <div class="p-info-item p-count-con">
                <span class="label">数量:</span>
                <input class="p-count" value="@Model.Quantity" readonly="" id="p-count" />
                <span class="p-count-btn plus" onclick="countPlus('@Model.Result.Data.Stock')">+</span>
                <span class="p-count-btn minus" onclick="countMinus()">-</span>
            </div>
            <div class="p-info-item">
                <a class="btn cart-add" onclick="addToCart('@Model.Result.Data.Id')">加入购物车</a>
            </div>
        </div>
    </div>
    <div class="detail-wrap">
        <div class="detail-tab-con">
            <ul class="tab-list">
                <li class="tab-item active">详细描述</li>
            </ul>
        </div>
        <div class="detail-con">
            @Html.Raw(Model.Result.Data.Detail)
        </div>
    </div>
</div>
End If