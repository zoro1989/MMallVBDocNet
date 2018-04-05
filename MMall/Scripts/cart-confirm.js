// 添加地址激活样式
function addActiveStyle() {
    $(this).addClass("active").siblings().removeClass("active")
}
// 删除地址
function delAddress() {
    var addressNode = $(this).parent().parent()
    $.ajax({
        url: "/Shipping/Delete",
        type: "post",
        dataType: "json",
        data: {shippingId: addressNode.data("id")},
        success: function (res) {
            var result = res.IsSuccess
            if (result) {
                addressNode.remove()
            }
        }
    });
}
// 编辑地址
function editAddress() {
    var addressNode = $(this).parent().parent()
    $.ajax({
        url: "/Shipping/Edit",
        type: "get",
        dataType: "json",
        data: { shippingId: addressNode.data("id") },
        success: function (res) {
            var result = res.IsSuccess
            var data = res.Data
            if (result) {
                $(".modal-body").find("#shipping-id").val(data.Id)
                $(".modal-body").find("#receiver-name").val(data.ReceiverName)
                $(".modal-body").find("#receiver-province").val(data.ReceiverProvince)
                $(".modal-body").find("#receiver-city").val(data.ReceiverCity)
                $(".modal-body").find("#receiver-address").val(data.ReceiverAddress)
                $(".modal-body").find("#receiver-phone").val(data.ReceiverPhone)
                $(".modal-body").find("#receiver-zip").val(data.ReceiverZip)
                $(".modal-wrap").fadeIn("slow")
            }
        }
    });
}
$(function () {
    // 绑定地址的点击事件
    $(".address-item").click(addActiveStyle)
    // 提交地址
    $(".order-submit").click(function () {
        // 必须选择一个地址
        if ($(".address-item.active").length === 0) {
            alert("请选择收货地址")
            return;
        }
        // 跳转订单确认页
        window.location.href = "/Cart/OrderCommit?shippingId=" + $(".address-item.active").data("id")
    })
    // 添加地址
    $(".address-add").click(function () {
        $(".modal-wrap").fadeIn("slow")
    })
    // 删除地址
    $(".address-delete").click(delAddress)
    // 更新地址
    $(".address-update").click(editAddress)
    // 表单验证
    $(".form").validate({
        rules: {
            receiverName: {
                required: true,
                maxlength: 10
            },
            receiverProvince: {
                required: true
            },
            receiverCity: {
                required: true
            },
            receiverAddress: {
                required: true,
                maxlength: 100
            },
            receiverPhone: {
                required: true,
                maxlength: 11,
                number: true
            },
            receiverZip: {
                required: true,
                number: true,
                rangelength: [5, 6]
            }
        }
    })
    // 保存地址
    $(".address-btn").click(function () {
        // 校验表单
        if ($(".form").valid()) {
            var shippingId = $("#shipping-id").val()
            // 无地址id则为新增地址
            if (shippingId === undefined || shippingId === '') {
                $.ajax({
                    url: "/Shipping/Add",
                    type: "post",
                    dataType: "json",
                    data: $(".form").serialize(), // 序列化表单
                    success: function (res) {
                        var data = res.Data
                        var newShippingDom = `<div class="address-item" data-id="${data.Id}">
                                        <div class="address-title">
                                            ${data.ReceiverCity} ${data.ReceiverProvince} （ ${data.ReceiverName} 收 ）
                                        </div>
                                        <div class="address-detail">
                                            ${data.ReceiverAddress} ${data.ReceiverMobile}
                                        </div>
                                        <div class="address-opera">
                                            <span class="link address-update">编辑</span>
                                            <span class="link address-delete">删除</span>
                                        </div>
                                        </div>`
                        var $newShippingDom = $(newShippingDom)
                        $newShippingDom.click(addActiveStyle)
                        $newShippingDom.find(".address-delete").click(delAddress)
                        $newShippingDom.find(".address-update").click(editAddress)

                        $(".address-add").before($newShippingDom)
                        $(".modal-wrap").fadeOut("slow")
                        $(".form")[0].reset()
                    }
                });
                // 更新地址
            } else {
                $.ajax({
                    url: "/Shipping/Add",
                    type: "post",
                    dataType: "json",
                    data: $(".form").serialize(),
                    success: function (res) {
                        var data = res.Data
                        var newShippingDom = `<div class="address-item" data-id="${data.Id}">
                                        <div class="address-title">
                                            ${data.ReceiverCity} ${data.ReceiverProvince} （ ${data.ReceiverName} 收 ）
                                        </div>
                                        <div class="address-detail">
                                            ${data.ReceiverAddress} ${data.ReceiverMobile}
                                        </div>
                                        <div class="address-opera">
                                            <span class="link address-update">编辑</span>
                                            <span class="link address-delete">删除</span>
                                        </div>
                                        </div>`
                        var $newShippingDom = $(newShippingDom)
                        $newShippingDom.click(addActiveStyle)
                        $newShippingDom.find(".address-delete").click(delAddress)
                        $newShippingDom.find(".address-update").click(editAddress)
                        // 更新地址信息
                        $(".address-item[data-id=" + data.Id + "]").before($newShippingDom).remove()
                        $(".modal-wrap").fadeOut("slow")
                        // 重置表单
                        $(".form")[0].reset()
                    }
                });
            }
            

            //do ajax but not submit
            return false;
        }
        // checkdata
        return true;
    })
    // 关闭地址弹窗
    $(".fa-close.close").click(function () {
        $(".modal-wrap").fadeOut("slow")
    })
})