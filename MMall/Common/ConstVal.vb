Public Class ConstVal
    ' 当前登录用户session的key
    Public Shared CURRENT_USER As String = "currentUser"
    ' 当前搜索框输入值session的key
    Public Shared CURRENT_INPUT As String = "currentInput"
    ' 当前选择商品类别session的key
    Public Shared CURRENT_CATEGORYID As String = "currentCategoryId"
    ' 当前购物车数量session的key
    Public Shared CURRENT_CART_COUNT As String = "currentCartCount"
    ' 历史记录urlsession的key
    Public Shared HISTORY_URL As String = "historyUrl"
    Public Shared EMAIL As String = "email"
    Public Shared USERNAME As String = "username"
    ' 订单分页的pagesize
    Public Shared PAGE_SIZE As Integer = 10
    ' 商品数量的pagesize
    Public Shared PAGE_SIZE_GODDS As Integer = 12
    Public Class Role
        Public Shared ROLE_CUSTOMER As Integer = 0
        Public Shared ROLE_ADMIN As Integer = 1
    End Class
End Class
