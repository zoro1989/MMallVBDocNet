// 搜索商品
function searchGoods() {
    var inputValue = document.getElementById("search-input").value
    window.location.href = "/Goods/List?keyword=" + inputValue
}