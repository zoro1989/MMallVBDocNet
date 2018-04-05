// 跳转分页
function goToPage(pageNo) {
    if (pageNo === '' || pageNo === undefined) {
            pageNo = 1
    }
    window.location.href = '/Order/List?pageNo=' + pageNo
}
// 上一页
function goToPrevPage(pageNo) {
    if (pageNo === '' || pageNo === undefined) {
        pageNo = 1
    } else {
        pageNo = pageNo - 1
    }
    window.location.href = '/Order/List?pageNo=' + pageNo

}
// 下一页
function goToNextPage(pageNo) {
    if (pageNo === '' || pageNo === undefined) {
        pageNo = 1
    } else {
        pageNo = pageNo + 1
    }
    window.location.href = '/Order/List?pageNo=' + pageNo

}