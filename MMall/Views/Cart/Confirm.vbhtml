@ModelType CartConfirmViewModel
@Code
    ViewData("Title") = "订单确认"
End Code
<link href="@Url.Content("~/Content/cart-confirm.css")" rel="stylesheet" type="text/css" />
<script src="https://cdn.bootcss.com/jquery-validate/1.17.0/localization/messages_zh.min.js"></script>
<script src="@Url.Content("~/Scripts/cart-confirm.js")"></script>
@RenderPage("~/Views/Shared/_Header.vbhtml")
<div class="crumb">
    <div class="w">
        <div class="crumb-con">
            <a class="link" href="./index.html">Mall</a>
            <span>></span>
            <span class="link-text">订单确认</span>
        </div>
    </div>
</div>
<div class="page-wrap w">
    <div class="panel">
        <h1 class="panel-title">收货地址</h1>
        <div class="panel-body address-con">
            
            @For Each shipping In Model.Result.Data.ShippingList
                @<div Class="address-item" data-id="@shipping.Id">
                    <div Class="address-title">
                        @shipping.ReceiverCity @shipping.ReceiverProvince （ @shipping.ReceiverName 收 ）
                    </div>
                    <div Class="address-detail">
                        @shipping.ReceiverAddress @shipping.ReceiverMobile
                    </div>
                    <div Class="address-opera">
                        <span Class="link address-update">编辑</span>
                        <span Class="link address-delete">删除</span>
                    </div>
                </div>
            Next
                <div class="address-add">
                    <div class="address-new">
                        <i class="fa fa-plus"></i>
                        <div class="text">使用新地址</div>
                    </div>
                </div>
            </div>
            
    </div>
    <div class="panel">
        <h1 class="panel-title">商品清单</h1>
        <div class="panel-body product-con">
            <table class="product-table">
                <tr>
                    <th class="cell-img">&nbsp;</th>
                    <th class="cell-info">商品描述</th>
                    <th class="cell-price">价格</th>
                    <th class="cell-count">数量</th>
                    <th class="cell-total">小计</th>
                </tr>
                @For Each cartInfo In Model.Result.Data.CartList
                @<tr>
                    <td class="cell-img">
                        <a href="./detail.html?productId=@cartInfo.Product.Id" target="_blank">
                            <img class="p-img" src="http://img.happymmall.com/@cartInfo.Product.MainImage" alt="@cartInfo.Product.Name" />
                        </a>
                    </td>
                    <td class="cell-info">
                        <a class="link" href="./detail.html?productId=@cartInfo.Product.Id" target="_blank">@cartInfo.Product.Name</a>
                    </td>
                    <td class="cell-price">￥@cartInfo.Product.Price</td>
                    <td class="cell-count">@cartInfo.Cart.Quantity</td>
                    <td class="cell-total">￥@cartInfo.TotalPrice</td>
                </tr>
                Next
            </table>
            <div class="submit-con">
                <span>订单总价:</span>
                <span class="submit-total">￥@Model.Result.Data.CartTotalPrice</span>
                <span class="btn order-submit">提交订单</span>
            </div>
        </div>
    </div>
</div>
<div class="modal-wrap">
    <div class="modal close">
        <div class="modal-container">
            <div class="modal-header">
                <h1 class="modal-title">使用新地址</h1>
                <i class="fa fa-close close"></i>
            </div>
            <div class="modal-body">
                <form class="form" id="form" action="" method="post">
                    <input type="hidden" id="shipping-id" name="shippingId" value="" />
                    <div class="form-line">
                        <label class="label" for="receiver-name">
                            <span class="required">*</span>收件人姓名：
                        </label>
                        <input class="form-item" id="receiver-name" name="receiverName" placeholder="请输入收件人姓名" value="" />
                    </div>
                    <div class="form-line">
                        <label class="label" for="receiver-province">
                            <span class="required">*</span>
                            所在城市：
                        </label>
                        <select class="form-item" id="receiver-province" name="receiverProvince">
                            <option value="">请选择</option>
                            <option value="吉林">吉林</option>
                        </select>
                        <select class="form-item" id="receiver-city" name="receiverCity">
                            <option value="">请选择</option>
                            <option value="长春">长春</option>
                            <option value="吉林">吉林</option>
                        </select>
                    </div>
                    <div class="form-line">
                        <label class="label" for="receiver-ddress">
                            <span class="required">*</span>
                            详细地址：
                        </label>
                        <input class="form-item" id="receiver-address" name="receiverAddress" placeholder="请精确到门牌号" value="" />
                    </div>
                    <div class="form-line">
                        <label class="label" for="receiver-phone">
                            <span class="required">*</span>
                            收件人手机：
                        </label>
                        <input class="form-item" id="receiver-phone" name="receiverPhone" placeholder="请输入11位手机号" value="" />
                    </div>
                    <div class="form-line">
                        <label class="label" for="receiver-zip">邮政编码：</label>
                        <input class="form-item" id="receiver-zip" name="receiverZip" placeholder="如：100000" value="" />
                    </div>
                    <div class="form-line">
                        <input type="hidden" id="receiver-id" value="data.id" />
                        <a class="btn address-btn" >保存收货地址</a>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

