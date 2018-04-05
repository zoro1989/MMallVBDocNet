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
function orderByDefault() {
    var inputValue = document.getElementById("search-input").value
    var categoryValue = document.getElementById("categoryIdValue").value
    window.location.href = "/Goods/List?keyword=" + inputValue + "&categoryId=" + categoryValue
}



function goToPage(pageNo, orderBy) {
    if (pageNo === '' || pageNo === undefined) {
        pageNo = 1
    }
    var inputValue = document.getElementById("search-input").value
    var categoryValue = document.getElementById("categoryIdValue").value
    window.location.href = "/Goods/List?keyword=" + inputValue + "&categoryId=" + categoryValue + "&orderBy=" + orderBy + "&pageNo=" + pageNo
}

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