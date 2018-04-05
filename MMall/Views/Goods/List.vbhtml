@ModelType GoodsListViewModel
@Code
    ViewData("Title") = "商品列表"
End Code
<link href="@Url.Content("~/Content/goods-list.css")" rel="stylesheet" type="text/css" />
<link href="@Url.Content("~/Content/pagenation.css")" rel="stylesheet" type="text/css" />
<script src="@Url.Content("~/Scripts/goodslist.js")"></script>
@RenderPage("~/Views/Shared/_Header.vbhtml")
<div class="crumb">
    <div class="w">
        <div class="crumb-con">
            <a class="link" href="./index.html">Mall</a>
            <span>></span>
            <span class="link-text">商品列表</span>
        </div>
    </div>
</div>
<div class="page-wrap w">
    <ul class="sort-con">
        <li class="sort-item active" data-type="default" onclick="orderByDefault()">默认排序</li>
        <li class="sort-item" data-type="price" onclick="orderByPrice('@Model.OrderBy')">
            <span>价格</span>
            <i class="fa fa-sort-asc"></i>
            <i class="fa fa-sort-desc"></i>
        </li>
    </ul>
    <!-- list 容器 -->
    @If Model.Result IsNot Nothing AndAlso Model.Result.Data IsNot Nothing AndAlso Model.Result.Data.ProductList IsNot Nothing Then
    @<ul Class="p-list-con">

        @For Each product In Model.Result.Data.ProductList
            @<li class="p-item">
                <div class="p-img-con">
                    <a class="link" href="/Goods/Detail?productId=@product.Id" target="_blank">
                        <img class="p-img" src="http://img.happymmall.com/@product.MainImage" alt="@product.Name" />
                    </a>
                </div>
                <div class="p-price-con">
                    <span class="p-price">￥@product.Price</span>
                </div>
                <div class="p-name-con">
                    <a class="p-name" href="/Goods/Detail.html?productId=@product.Id" target="_blank">@product.Name</a>
                </div>
            </li>
        Next

    </ul>
    End If
    @If Model.Result IsNot Nothing AndAlso （Not Model.Result.IsSuccess) Then
        @Html.ValidationMessage("error-field", New With {Key .class = "err-tip"})
    Else
    @<div Class="pagination">
        <div Class="pg-content">
                @If Model.Result.Data.Page.HasPrevPage Then
                @<span Class="pg-item" onclick="goToPrevPage(@Model.Result.Data.Page.CurrentPage,'@Model.OrderBy')">上一页</span>
            Else
            @<span Class="pg-item disabled">上一页</span>
            End If

                @For i = 1 To Model.Result.Data.Page.PageCount
                If i = Model.Result.Data.Page.CurrentPage Then
                @<span class="pg-item active">@i</span>
                Else
            @<span class="pg-item" onclick="goToPage(@i,'@Model.OrderBy')">@i</span>
                End If

            Next
                @If Model.Result.Data.Page.HasNextPage Then
                @<span Class="pg-item" onclick="goToNextPage(@Model.Result.Data.Page.CurrentPage,'@Model.OrderBy')">下一页</span>
            Else
            @<span Class="pg-total">下一页</span>
            End If

        </div>
    </div>
    End If
    

</div>