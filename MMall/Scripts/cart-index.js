$(function () {
    $(".count-btn.minus").click(function () {
        var stock = $(this).next().data("max")*1
        var quantity = $(this).next().val() * 1 - 1
        if (quantity < 1) {
            return;
        }
        var price = $(this).parent().prev().text()
        price = price.substr(1) * 1
        $(this).parent().next().text("￥" + quantity * price)
        $(this).next().val(quantity)
        computTotalPrice()
    })
    $(".count-btn.plus").click(function () {
        var stock = $(this).prev().data("max") * 1
        var quantity = $(this).prev().val() * 1 + 1
        if (quantity > stock) {
            return;
        }
        var price = $(this).parent().prev().text()
        price = price.substr(1) * 1
        $(this).parent().next().text("￥" + quantity * price)
        $(this).prev().val(quantity)
        computTotalPrice()
    })

    $(".cart-list .cart-table .cell-check .cart-select").click(function () {
        computTotalPrice()
    })

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
    $(".cart-delete").click(function () {
        var cartid = $(this).data("cartid")
        var delNode = $(this)
        var cartIds = []
        cartIds.push(cartid)
        $.ajax({
            data: { "cartIds": cartIds },
            url: "/Cart/Delete",
            traditional: true,
            success: function (result) {
                console.log(result)
                var res = result.IsSuccess
                if (res) {
                    delNode.parents(".cart-table-wrapper").slideUp("slow", function () {
                        delNode.parents(".cart-table-wrapper").remove()
                        computTotalPrice()
                        isNoNode()
                    })
                }
            }
        });
    })

    $(".delete-selected").click(function () {
        var delNode = $(".cart-list .cart-table .cell-check .cart-select:checked")
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
                        delNode.parents(".cart-table-wrapper").remove()
                        computTotalPrice()
                        isNoNode()
                    })
                }
            }
        });
    })

    function isNoNode() {
        if ($(".cart-list .cart-table tr").length === 0 && $(".err-tip").length === 0) {
            $(".cart-header").remove()
            $(".cart-list").remove()
            $(".cart-footer").remove()
            var errDom = '<span class="field-validation-error err-tip" data-valmsg-for="error-field" data-valmsg-replace="true">您的购物车空空如野</span>';
            $(".page-wrap.w").append(errDom)
        }
        $(".nav-list .nav-item .cart-count").text($(".cart-list .cart-table tr").length)
    }

    $(".btn-submit").click(function () {
        var carts = computSelectCartArr()
        debugger
        $.ajax({
            data: { "carts": JSON.stringify(carts) },
            url: "/Cart/OrderConfirm",
            traditional: true,
            success: function (result) {
                var res = result.IsSuccess
                if (res) {
                    window.location.href = "/Cart/Confirm"
                } else {
                    if (res.Status == '10') {
                        window.location.href = "/User/Login"
                    }
                }
            }
        });
    })

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