<div class="nav">
    <div class="w">
        <div class="user">
            @If Session(ConstVal.CURRENT_USER) Is Nothing Then

            @<span><a class="link" href="@Url.Action("Login", "User")">登录</a></span>
            @<span><a class="link" href="@Url.Action("Register", "User")">注册</a></span>
            Else
            @<span class="user login">
                <span class="link-text">欢迎,
                    <span class="username">@Session("currentUser").Username</span>
                </span>
                <span><a class="link js-logout" href="@Url.Action("Logout", "User")">退出</a></span>
            </span>
            End If
        </div>
        @If Session(ConstVal.CURRENT_USER) IsNot Nothing Then
        @<ul Class="nav-list">
            <li Class="nav-item">
                <a Class="link" href="@Url.Action("Index", "Cart")">
                    <i Class="fa fa-shopping-cart"></i>购物车(<span class="cart-count">@Session(ConstVal.CURRENT_CART_COUNT)</span>)
                </a>
            </li>
            <li class="nav-item">
                <a class="link" href="@Url.Action("List", "Order")">我的订单</a>
            </li>
            <li class="nav-item">
                <a class="link">我的商城</a>
            </li>
        </ul>
        End If
    </div>
</div>
<div class="header">
    <div class="w">
        <a class="logo" href="@Url.Action("Index", "Home")">MMall</a>
        <div class="search">
            <input class="search-input" id="search-input" placeholder="请输入商品名称" value="@Session(ConstVal.CURRENT_INPUT)">
            <button class="search-btn btn" onclick="searchGoods()">搜索</button>
        </div>
    </div>
</div>
<input id="categoryIdValue" type="hidden" value="@Session(ConstVal.CURRENT_CATEGORYID)" />