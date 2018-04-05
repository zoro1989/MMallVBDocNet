$(function () {
    // 减少商品数量
    $(".count-btn.minus").click(function () {
        // 库存
        var stock = $(this).next().data("max") * 1
        // 数量 -1
        var quantity = $(this).next().val() * 1 - 1
        if (quantity < 1) {
            return;
        }
        // 价格
        var price = $(this).parent().prev().text()
        price = price.substr(1) * 1
        // 更新总价
        $(this).parent().next().text("￥" + quantity * price)
        $(this).next().val(quantity)
        computTotalPrice()
    })
    $(".count-btn.plus").click(function () {
        // 库存
        var stock = $(this).prev().data("max") * 1
        // 商品数量
        var quantity = $(this).prev().val() * 1 + 1
        if (quantity > stock) {
            return;
        }
        // 价格
        var price = $(this).parent().prev().text()
        price = price.substr(1) * 1
        // 更新总价
        $(this).parent().next().text("￥" + quantity * price)
        $(this).prev().val(quantity)
        computTotalPrice()
    })
    // 勾选商品
    $(".cart-list .cart-table .cell-check .cart-select").click(function () {
        computTotalPrice()
    })
    // 全选
    $(".cart-select-all").click(function () {
        var ischecked = $(this).prop("checked")
        if (ischecked) {
            $(".cart-select").prop("checked", true)
            $(".cart-select-all").prop("checked", true)
        } else {
            $(".cart-select").prop("checked", false)
            $(".cart-select-all").prop("checked", false)
        }
        computTotalPrice()
    })
    // 计算总价
    function computTotalPrice() {
        var totalPrice = 0
        $(".cart-list .cart-table").each(function () {
            var isChecked = $(this).find(".cart-select").prop("checked")
            if (isChecked) {
                var price = $(this).find(".cell-price").text()
                price = price.substr(1) * 1
                var count = $(this).find(".cell-count .count-input").val() * 1
                totalPrice += price * count
            }
        })
        $(".submit-total").text("￥" + totalPrice)
    }
    // 拼接选中购物车id的数组
    function computSelectArr() {
        var arr = []
        $(".cart-list .cart-table").each(function () {
            var isChecked = $(this).find(".cart-select").prop("checked")
            if (isChecked) {
                arr.push($(this).data("cart-id"))
            }
        })
        return arr
    }
    // 删除一个购物车
    $(".cart-delete").click(function () {
        var cartid = $(this).data("cartid")
        var delNode = $(this)
        var cartIds = []
        cartIds.push(cartid)
        $.ajax({
            data: { "cartIds": cartIds },
            url: "/Cart/Delete",
            traditional: true, // 防止深层序列化
            success: function (result) {
                console.log(result)
                var res = result.IsSuccess
                if (res) {
                    delNode.parents(".cart-table-wrapper").slideUp("slow", function () {
                        // 移除节点
                        delNode.parents(".cart-table-wrapper").remove()
                        // 重算总价
                        computTotalPrice()
                        // 判断是否没有商品了
                        isNoNode()
                    })
                }
            }
        });
    })
    // 删除选中
    $(".delete-selected").click(function () {
        var delNode = $(".cart-list .cart-table .cell-check .cart-select:checked")
        // 选中购物车id数组
        var cartIds = computSelectArr()
        $.ajax({
            data: { "cartIds": cartIds },
            url: "/Cart/Delete",
            traditional: true,
            success: function (result) {
                console.log(result)
                var res = result.IsSuccess
                if (res) {
                    delNode.parents(".cart-table-wrapper").slideUp("slow", function () {
                        // 所有选中购物车数据都删除
                        delNode.parents(".cart-table-wrapper").remove()
                        // 从算总价
                        computTotalPrice()
                        // 判断购物车是否为空
                        isNoNode()
                    })
                }
            }
        });
    })

    function isNoNode() {
        // 若已没有购物车信息,显示错误信息
        if ($(".cart-list .cart-table tr").length === 0 && $(".err-tip").length === 0) {
            $(".cart-header").remove()
            $(".cart-list").remove()
            $(".cart-footer").remove()
            var errDom = '<span class="field-validation-error err-tip" data-valmsg-for="error-field" data-valmsg-replace="true">您的购物车空空如野</span>';
            $(".page-wrap.w").append(errDom)
        }
        $(".nav-list .nav-item .cart-count").text($(".cart-list .cart-table tr").length)
    }
    // 提交购物车
    $(".btn-submit").click(function () {
        // 得到购物信息数组
        var carts = computSelectCartArr()
        $.ajax({
            data: { "carts": JSON.stringify(carts) }, // 将购物车信息数组转成json字符串
            url: "/Cart/OrderConfirm",
            traditional: true,
            success: function (result) {
                var res = result.IsSuccess
                if (res) {
                    window.location.href = "/Cart/Confirm"
                } else {
                    // 若需重新登录
                    if (res.Status == '10') {
                        window.location.href = "/User/Login"
                    }
                }
            }
        });
    })
    // 拼接购物车信息数组
    function computSelectCartArr() {
        var arr = []
        $(".cart-list .cart-table").each(function () {
            var isChecked = $(this).find(".cart-select").prop("checked")
            var cartSelect = {}
            cartSelect.CartId = $(this).data("cart-id")
            cartSelect.Quantity = $(this).find(".count-input").val()
            if (isChecked) {
                cartSelect.IsChecked = '1'
            } else {
                cartSelect.IsChecked = '0'
            }
               
            arr.push(cartSelect)
        })
        return arr
    }

})