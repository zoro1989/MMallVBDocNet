function goToPage(pageNo) {
    if (pageNo === '' || pageNo === undefined) {
            pageNo = 1
    }
    window.location.href = '/Order/List?pageNo=' + pageNo
}

function goToPrevPage(pageNo) {
    if (pageNo === '' || pageNo === undefined) {
        pageNo = 1
    } else {
        pageNo = pageNo - 1
    }
    window.location.href = '/Order/List?pageNo=' + pageNo

}

function goToNextPage(pageNo) {
    if (pageNo === '' || pageNo === undefined) {
        pageNo = 1
    } else {
        pageNo = pageNo + 1
    }
    window.location.href = '/Order/List?pageNo=' + pageNo

}