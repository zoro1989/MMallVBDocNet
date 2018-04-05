// 鼠标滑进图片
function subImageOver(subImage) {
    var mainImage = document.getElementById("main-img")
    mainImage.src = "http://img.happymmall.com/" + subImage
}
// 增加数量
function countPlus(stock) {
    var countVal = document.getElementById("p-count").value
    var newCount = countVal * 1 + 1
    document.getElementById("p-count").value = newCount
    if (newCount > stock) {
        document.getElementById("p-count").value = stock
    }
}
// 减少数量
function countMinus() {
    var countVal = document.getElementById("p-count").value
    var newCount = countVal * 1 - 1
    document.getElementById("p-count").value = newCount
    if (newCount < 1) {
        document.getElementById("p-count").value = 1
    }
}
// 添加到购物车
function addToCart(productId) {
    var countVal = document.getElementById("p-count").value
    window.location.href = "/Goods/AddCartSuccess?quantity=" + countVal + "&productId=" + productId
}