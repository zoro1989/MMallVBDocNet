@ModelType OrderDetailViewModel
@Code
    ViewData("Title") = "订单详情"
End Code
<link href="@Url.Content("~/Content/order-detail.css")" rel="stylesheet" type="text/css" />
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
<div class="page-wrap w">
    @RenderPage("~/Views/Shared/_NavSide.vbhtml")
    <div class="content with-nav">
        <div class="panel">
            <div class="panel-title">订单信息</div>
            <div class="panel-body">
                <div class="order-info">
                    <div class="text-line">
                        <span class="text">订单号：@Model.Result.Data.OrderNo</span>
                        <span class="text">创建时间：@Model.Result.Data.CreateTime</span>
                    </div>
                    <div class="text-line">
                        <span class="text">
                            收件人：
                            @Model.Result.Data.ReceiverName
                            @Model.Result.Data.ReceiverProvince
                            @Model.Result.Data.ReceiverCity
                            @Model.Result.Data.ReceiverAddress
                            @Model.Result.Data.ReceiverMobile
                        </span>
                    </div>
                    <div class="text-line">
                        <span class="text">订单状态： @Model.Result.Data.Status</span>
                    </div>
                    <div class="text-line">
                        <span class="text">支付方式：@Model.Result.Data.PaymentType</span>
                    </div>
                    <div class="text-line">
                        @If Model.Result.Data.NeedPay Then
                        @<a class="btn" href="./payment.html?orderNumber=@Model.Result.Data.OrderNo">去支付</a>
                        End If  
                        @If Model.Result.Data.IsCancelable Then
                        @<a class="btn order-cancel">取消订单</a>
                        End If  
                    </div>
                </div>
            </div>
        </div>
        <div class="panel">
            <div class="panel-title">商品清单</div>
            <div class="panel-body">
                <table class="product-table">
                    <tr>
                        <th class="cell-th cell-img">&nbsp;</th>
                        <th class="cell-th cell-info">商品信息</th>
                        <th class="cell-th cell-price">单价</th>
                        <th class="cell-th cell-count">数量</th>
                        <th class="cell-th cell-total">小计</th>
                    </tr>
                    @For Each orderItem As OrderItem In Model.Result.Data.OrderItemList
                    @<tr>
                        <td class="cell cell-img">
                            <a href="./detail.html?productId=@orderItem.ProductId" target="_blank">
                                <img class="p-img" src="http://img.happymmall.com/@orderItem.ProductImage" alt="@orderItem.ProductName" />
                            </a>
                        </td>
                        <td class="cell cell-info">
                            <a class="link" href="./detail.html?productId=@orderItem.ProductId" target="_blank">@orderItem.ProductName</a>
                        </td>
                        <td class="cell cell-price">￥@orderItem.CurrentUnitPrice</td>
                        <td class="cell cell-count">@orderItem.Quantity</td>
                        <td class="cell cell-total">￥@orderItem.TotalPrice</td>
                    </tr>
                    Next
                </table>
                <p class="total">
                    <span>订单总价：</span>
                    <span class="total-price">￥@Model.Result.Data.Payment</span>
                </p>
            </div>
        </div>
    </div>
</div>
