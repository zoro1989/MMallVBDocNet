@ModelType HomeIndexViewModel
@Code
    ViewData("Title") = "首页"
End Code
<link href="@Url.Content("~/Content/index.css")" rel="stylesheet" type="text/css" />
<script src="@Url.Content("~/Scripts/home-index.js")"></script>
@RenderPage("~/Views/Shared/_Header.vbhtml")
<div class="w">
    <div class="w">
        <ul class="keywords-list">
            @For Each item In Model.Result.Data.CategoryList
                @<li Class="keywords-item">
                    @For Each cate In item
                    @<a Class="link" href="@Url.Action("List", "Goods", New With {Key .categoryId = cate.Id})">@cate.Name</a>
                    Next
                </li>
            Next
        </ul>
        <div class="banner">
            <div class="image-wrapper">
                <img class="image" src="~/Content/images/banner/banner1.jpg">
                <img class="image" src="~/Content/images/banner/banner2.jpg">
                <img class="image" src="~/Content/images/banner/banner3.jpg">
                <img class="image" src="~/Content/images/banner/banner4.jpg">
                <img class="image" src="~/Content/images/banner/banner5.jpg">
            </div>
            <div class="banner-arrow prev">
                <i class="fa fa-angle-left"></i>
            </div>
            <div class="banner-arrow next">
                <i class="fa fa-angle-right"></i>
            </div>
            <div>
                <ul class="dots">
                    <li class="active"></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="w">
        @For Each floor In Model.Result.Data.FloorList
            @<div Class="floor-wrapper">
                <h1 Class="floor-title">@floor.ParentCategory.Name</h1>
                <ul Class="floor-list">
                   @For Each item In floor.CategoryList
                    @<li Class="floor-item">
                        <span Class="floor-text">@item.Name</span>
                        <img Class="floor-image" src="@item.ImgUrl">
                    </li>
                   Next
                </ul>
            </div>
        Next
        
    </div>
</div>
