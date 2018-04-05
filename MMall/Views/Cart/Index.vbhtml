@ModelType CartIndexViewModel
@Code
    ViewData("Title") = "购物车"
End Code
<link href="@Url.Content("~/Content/cart-index.css")" rel="stylesheet" type="text/css" />
<script src="@Url.Content("~/Scripts/cart-index.js")"></script>
@RenderPage("~/Views/Shared/_Header.vbhtml")
<div class="crumb">
    <div class="w">
        <div class="crumb-con">
            <a class="link" href="./index.html">Mall</a>
            <span>></span>
            <span class="link-text">购物车</span>
        </div>
    </div>
</div>
<div class="page-wrap w">
    @If Model.Result IsNot Nothing AndAlso Model.Result.Data IsNot Nothing Then
    @<div class="cart-header">
        <table class="cart-table">
            <tr>
                <th class="cart-cell cell-check">
                    <label class="cart-label">
                        <input type="checkbox" class="cart-select-all" />
                        <span>全选</span>
                    </label>
                </th>
                <th class="cart-cell cell-info">商品信息</th>
                <th class="cart-cell cell-price">单价</th>
                <th class="cart-cell cell-count">数量</th>
                <th class="cart-cell cell-total">合计</th>
                <th class="cart-cell cell-opera">操作</th>
            </tr>
        </table>
    </div>

    @<div class="cart-list">
        @For Each cartItem In Model.Result.Data.CartList
        @<div class="cart-table-wrapper">
            <table class="cart-table" data-cart-id="@cartItem.Cart.Id">
            <tr>
                <td class="cart-cell cell-check">
                    <label class="cart-label">
                        <input type="checkbox" class="cart-select" />
                    </label>
                </td>
                <td class="cart-cell cell-img">
                    <a class="link" href="./detail.html?productId=@cartItem.Cart.ProductId">
                        <img class="p-img" src="http://img.happymmall.com/@cartItem.Product.MainImage" alt="@cartItem.Product.Name" />
                    </a>
                </td>
                <td class="cart-cell cell-info">
                    <a class="link" href="./detail.html?productId=@cartItem.Product.Id">@cartItem.Product.Name</a>
                </td>
                <td class="cart-cell cell-price">￥@cartItem.Product.Price</td>
                <td class="cart-cell cell-count">
                    <span class="count-btn minus">-</span>
                    <input class="count-input" value="@cartItem.Cart.Quantity" data-max="@cartItem.Product.Stock" />
                    <span class="count-btn plus">+</span>
                </td>
                <td class="cart-cell cell-total">￥@cartItem.TotalPrice</td>
                <td class="cart-cell cell-opera">
                    <span class="link cart-delete" data-cartid="@cartItem.Cart.Id">删除</span>
                </td>
            </tr>
            </table>
        </div>
        Next
    </div>
    @<div Class="cart-footer">
        <div Class="select-con">
            <Label>
                <input type = "checkbox" Class="cart-select-all" />
                <span> 全选</span>
            </label>
        </div>
        <div Class="delete-con">
            <span Class="link delete-selected">
                <i Class="fa fa-trash-o"></i>
                <span> 删除选中</span>
            </span>
        </div>
        <div Class="submit-con">
            <span> 总价 ：  </span>
            <span Class="submit-total">￥0</span>
            <span Class="btn btn-submit">去结算</span>
        </div>
    </div>
    End If
    @If Model.Result IsNot Nothing AndAlso （Not Model.Result.IsSuccess) Then
        @Html.ValidationMessage("error-field", New With {Key .class = "err-tip"})
    End If
</div>

