$(function () {
    var size = $(".image-wrapper").children().length
    var first = $(".image-wrapper .image").first().clone()
    var last = $(".image-wrapper .image").last().clone()
    var imgWidth = $(".image-wrapper .image").first().width()
    $(".image-wrapper").append(first).prepend(last)
    $(".image-wrapper").width(imgWidth * (size + 2))
    var currentIndex = 1
    var timmer;
    goToPage()
    $(".prev").click(function () {
        currentIndex = currentIndex - 2;
        if (currentIndex < 1) {
            currentIndex = 1
        }
        goToPage()
    })
    $(".next").click(function () {
        goToPage()
    })
    function goToPage() {
        clearTimeout(timmer)
        currentIndex++;
        if (currentIndex > size) {
            currentIndex = 1
            $(".image-wrapper").css("left", "0")
        }
        console.log(currentIndex)
        $(".image-wrapper").animate({ left: currentIndex * -770 + "px" }, 2000, function () {
            $(".dots li").eq(currentIndex - 1).addClass("active").siblings().removeClass("active")
        })
        timmer = setTimeout(goToPage, 4000)
    }
})