@ModelType OrderListViewModel
@Code
    ViewData("Title") = "订单列表"
End Code
<link href="@Url.Content("~/Content/order-list.css")" rel="stylesheet" type="text/css" />
<link href="@Url.Content("~/Content/pagenation.css")" rel="stylesheet" type="text/css" />
<script src="@Url.Content("~/Scripts/orderlist.js")"></script>
@RenderPage("~/Views/Shared/_Header.vbhtml")
<div class="crumb">
    <div class="w">
        <div class="crumb-con">
            <a class="link" href="./index.html">Mall</a>
            <span>></span>
            <span class="link-text">订单列表</span>
        </div>
    </div>
</div>
<div class="page-wrap w">
    @RenderPage("~/Views/Shared/_NavSide.vbhtml")
    <div class="content with-nav">
        <div class="panel">
            <div class="panel-title">订单列表</div>
            <div class="panel-body">
                <div class="order-list-con">
                    <table class="order-list-table header">
                        <tr>
                            <th class="cell cell-img">&nbsp;</th>
                            <th class="cell cell-info">商品信息</th>
                            <th class="cell cell-price">单价</th>
                            <th class="cell cell-count">数量</th>
                            <th class="cell cell-total">小计</th>
                        </tr>
                    </table>
                    @For Each order In Model.Result.Data.OrderListDto
                    @<table class="order-list-table order-item">
                        <tr>
                            <td colspan = "5" Class="order-info">
                                <span Class="order-text">
                                    <span> 订单号 ：  </span>
                                    <a Class="link order-num" href="@Url.Action("Detail", "Order", New With {Key .OrderNumber = order.OrderNo})" target="_blank">@order.OrderNo</a>
                                </span>
                                <span Class="order-text">@order.CreateTime</span>
                                <span Class="order-text">收件人：@order.ReceiverName</span>
                                <span Class="order-text">订单状态：@order.Status</span>
                                <span Class="order-text">
                                    <span> 订单总价 ：  </span>
                                    <span Class="order-total">￥@order.Payment</span>
                                </span>
                                <a Class="link order-detail" href="@Url.Action("Detail", "Order", New With {Key .OrderNumber = order.OrderNo})" target="_blank">查看详情></a>
                            </td>
                        </tr>
                        @For Each orderItem In order.OrderItemList
                        @<tr>
                        <td Class="cell cell-img">
                                <a href = "./detail.html?productId=1" target="_blank">
                                    <img Class="p-img" src="http://img.happymmall.com/@orderItem.ProductImage" alt="@orderItem.ProductName" />
                                </a>
                            </td>
                            <td Class="cell cell-info">
                                <a Class="link" href="./detail.html?productId=1" target="_blank">@orderItem.ProductName</a>
                            </td>
                            <td Class="cell cell-price">￥@orderItem.CurrentUnitPrice</td>
                            <td Class="cell cell-count">@orderItem.Quantity</td>
                            <td Class="cell cell-total">￥@orderItem.TotalPrice</td>
                        </tr>
                        Next
                    </table>
                    Next
                    @*<p class="err-tip">您暂时还没有订单</p>*@
                </div>
                <div Class="pagination">
                    <div class="pg-content">
                        @If Model.Result.Data.Page.HasPrevPage Then
                             @<span Class="pg-item" onclick="goToPrevPage(@Model.Result.Data.Page.CurrentPage)">上一页</span>
                        Else
                            @<span Class="pg-item disabled">上一页</span>
                        End If
                       
                        @For i = 1 To Model.Result.Data.Page.PageCount
                            If i = Model.Result.Data.Page.CurrentPage Then
                                @<span class="pg-item active">@i</span>
                            Else
                                @<span class="pg-item" onclick="goToPage(@i)">@i</span>
                            End If

                        Next
                        @If Model.Result.Data.Page.HasNextPage Then
                            @<span Class="pg-item" onclick="goToNextPage(@Model.Result.Data.Page.CurrentPage)">下一页</span>
                        Else
                           @<span Class="pg-total">下一页</span>
                        End If
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>