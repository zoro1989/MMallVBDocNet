// 按价格排序
function orderByPrice(orderBy) {
    var inputValue = document.getElementById("search-input").value
    var categoryValue = document.getElementById("categoryIdValue").value
    
    if (orderBy === undefined || orderBy === '') {
        window.location.href = "/Goods/List?keyword=" + inputValue + "&categoryId=" + categoryValue + "&orderBy=asc"
        return;
    }
    if (orderBy == 'asc') {
        window.location.href = "/Goods/List?keyword=" + inputValue + "&categoryId=" + categoryValue + "&orderBy=desc"
    } else if (orderBy == 'desc') {
        window.location.href = "/Goods/List?keyword=" + inputValue + "&categoryId=" + categoryValue + "&orderBy=asc"
    }
    
}
// 默认排序
function orderByDefault() {
    var inputValue = document.getElementById("search-input").value
    var categoryValue = document.getElementById("categoryIdValue").value
    window.location.href = "/Goods/List?keyword=" + inputValue + "&categoryId=" + categoryValue
}


// 跳转分页
function goToPage(pageNo, orderBy) {
    if (pageNo === '' || pageNo === undefined) {
        pageNo = 1
    }
    var inputValue = document.getElementById("search-input").value
    var categoryValue = document.getElementById("categoryIdValue").value
    window.location.href = "/Goods/List?keyword=" + inputValue + "&categoryId=" + categoryValue + "&orderBy=" + orderBy + "&pageNo=" + pageNo
}

// 上一页
function goToPrevPage(pageNo, orderBy) {
    if (pageNo === '' || pageNo === undefined) {
        pageNo = 1
    } else {
        pageNo = pageNo - 1
    }
    var inputValue = document.getElementById("search-input").value
    var categoryValue = document.getElementById("categoryIdValue").value
    window.location.href = "/Goods/List?keyword=" + inputValue + "&categoryId=" + categoryValue + "&orderBy=" + orderBy + "&pageNo=" + pageNo

}
// 下一页
function goToNextPage(pageNo, orderBy) {
    if (pageNo === '' || pageNo === undefined) {
        pageNo = 1
    } else {
        pageNo = pageNo + 1
    }
    var inputValue = document.getElementById("search-input").value
    var categoryValue = document.getElementById("categoryIdValue").value
    window.location.href = "/Goods/List?keyword=" + inputValue + "&categoryId=" + categoryValue + "&orderBy=" + orderBy + "&pageNo=" + pageNo

}