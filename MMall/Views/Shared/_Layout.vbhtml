<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryval")
</head>
<body>
    @RenderBody()
    <div class="footer">
        <div class="w">
            <div class="links">
                <a class="link">博客</a>|
                <a class="link">百度</a>|
                <a class="link">淘宝</a>|
                <a class="link">知乎</a>
                <div class="copyright">
                    COPYRIGHT 长春必捷必 入职培训
                </div>
            </div>
        </div>
    </div>
    @Scripts.Render("~/bundles/common")
    @RenderSection("scripts", required:=False)
</body>
</html>
