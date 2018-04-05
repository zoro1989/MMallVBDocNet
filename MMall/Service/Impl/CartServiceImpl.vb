Imports MMall

Public Class CartServiceImpl : Implements ICartService
    Private _cartDao As ICartDao = New CartDaoImpl
    Private _orderDao As IOrderDao = New OrderDaoImpl
    Private _orderItemDao As IOrderItemDao = New OrderItemDaoImpl
    Private _productDao As IProductDao = New ProductDaoImpl
    Private _shippingDao As IShippingDao = New ShippingDaoImpl

    Public Function CreateOrder(shippingId As String, userId As String) As ServerResponse(Of Boolean) Implements ICartService.CreateOrder
        Dim checkedCartList As List(Of Cart) = _cartDao.SelectCheckedCartByUserId(userId)
        Dim resList As List(Of CartItem) = New List(Of CartItem)
        Dim cartTotalPrice As Decimal = New Decimal(0)
        Me.ComputedTotalPrice(checkedCartList, resList, cartTotalPrice)
        Dim order As Order = Me.AssembleOrder(userId, shippingId, cartTotalPrice)
        Dim result As Boolean = _orderDao.CreateOrder(order)
        If Not result Then
            Return ServerResponse(Of Boolean).CreateByErrorMessage("创建订单失败")
        End If
        For Each orderItem In Me.AssembleOrderItems(userId, order.OrderNo, resList)
            result = _orderItemDao.CreateOrderItem(orderItem)
            If Not result Then
                Return ServerResponse(Of Boolean).CreateByErrorMessage("创建订单子表失败")
            End If
        Next
        result = _cartDao.DeleteCheckedCart(userId)
        If Not result Then
            Return ServerResponse(Of Boolean).CreateByErrorMessage("清空购物车失败")
        End If
        Return ServerResponse(Of Boolean).createBySuccess(result)
    End Function
    Private Function AssembleOrder(userId As String, shippingId As String, cartTotalPrice As Decimal) As Order
        Dim order As Order = New Order
        order.OrderNo = Me.CreateOrder()
        order.UserId = Convert.ToInt32(userId)
        order.ShippingId = Convert.ToInt32(shippingId)
        order.Payment = cartTotalPrice
        order.PaymentType = 1
        order.Postage = 0
        order.Status = 10
        Return order
    End Function
    Private Function AssembleOrderItems(userId As String, orderNo As Long, resList As List(Of CartItem)) As List(Of OrderItem)
        Dim orderItemList As List(Of OrderItem) = New List(Of OrderItem)
        For Each item In resList
            Dim orderItem As OrderItem = New OrderItem
            orderItem.UserId = Convert.ToInt32(userId)
            orderItem.OrderNo = orderNo
            orderItem.ProductId = item.Product.Id
            orderItem.ProductName = item.Product.Name
            orderItem.ProductImage = item.Product.MainImage
            orderItem.CurrentUnitPrice = item.Product.Price
            orderItem.Quantity = item.Cart.Quantity
            orderItem.TotalPrice = CDec(item.TotalPrice)
            orderItemList.Add(orderItem)
        Next
        Return orderItemList
    End Function

    Public Function DeleteCartById(cartIds() As String, userId As String) As ServerResponse(Of Integer) Implements ICartService.DeleteCartById
        Dim result As Boolean = True
        For Each cartId In cartIds
            Dim res As Boolean = _cartDao.DeleteCartById(cartId, userId)
            If Not res Then
                Return ServerResponse(Of Integer).CreateByErrorMessage("删除失败")
            End If
        Next
        Dim cartCount As Integer = _cartDao.SelectCartCount(userId)(0).Count
        Return ServerResponse(Of Integer).createBySuccess(cartCount)
    End Function

    Public Function GetAllCartProducts(userId As String) As ServerResponse(Of CartInfo) Implements ICartService.GetAllCartProducts
        Dim cartList As List(Of Cart) = _cartDao.SelectCartByUserId(userId)
        If cartList.Count = 0 Then
            Return ServerResponse(Of CartInfo).CreateByErrorMessage("您的购物车空空如野")

        End If
        Dim info As CartInfo = New CartInfo
        Dim resList As List(Of CartItem) = New List(Of CartItem)
        For Each cart In cartList
            Dim item As CartItem = New CartItem
            item.Cart = cart

            Dim proList As List(Of Product) = _productDao.SelectDetailByProductId(Convert.ToString(cart.ProductId))
            If proList.Count <> 0 Then
                item.Product = proList(0)
                item.TotalPrice = Convert.ToString(Decimal.Multiply(New Decimal(item.Product.Price), New Decimal(item.Cart.Quantity)))
            End If
            resList.Add(item)
        Next
        info.CartList = resList
        Return ServerResponse(Of CartInfo).createBySuccess(info)
    End Function

    Public Function GetAllCheckedCartInfoByUserId(userId As String) As ServerResponse(Of CartInfo) Implements ICartService.GetAllCheckedCartInfoByUserId
        Dim checkedCartList As List(Of Cart) = _cartDao.SelectCheckedCartByUserId(userId)
        Dim productList As List(Of Product) = New List(Of Product)

        Dim info As CartInfo = New CartInfo
        Dim resList As List(Of CartItem) = New List(Of CartItem)
        Dim cartTotalPrice As Decimal = New Decimal(0)

        Me.ComputedTotalPrice(checkedCartList, resList, cartTotalPrice)
        info.CartList = resList
        info.ShippingList = _shippingDao.GetAllShippingByUserId(userId)
        info.CartTotalPrice = Convert.ToString(cartTotalPrice)
        Return ServerResponse(Of CartInfo).createBySuccess(info)
    End Function

    Public Function UpdateCartInfo(carts As List(Of CartConfirmDto), user As User) As ServerResponse(Of Boolean) Implements ICartService.UpdateCartInfo
        If user Is Nothing Then
            Return ServerResponse(Of Boolean).createByErrorCodeMessage(ResponseCode.NEED_LOGIN.Code, "请重新登录")
        End If
        Dim res As Boolean
        For Each cart In carts
            If "1".Equals(cart.IsChecked) Then
                res = _cartDao.UpdateCartInfoById(cart.CartId, cart.Quantity, Convert.ToString(user.Id))
            ElseIf "0".Equals(cart.IsChecked) Then
                res = _cartDao.UpdateNotCheckedCartInfoById(cart.CartId, cart.Quantity, Convert.ToString(user.Id))
            End If

            If Not res Then
                Return ServerResponse(Of Boolean).CreateByErrorMessage("更新购物车失败")
            End If
        Next
        Return ServerResponse(Of Boolean).CreateBySuccessMessage("更新购物车成功")
    End Function
    Private Sub ComputedTotalPrice(checkedCartList As List(Of Cart), ByRef resList As List(Of CartItem), ByRef cartTotalPrice As Decimal)
        For Each cart In checkedCartList
            Dim item As CartItem = New CartItem
            item.Cart = cart

            Dim proList As List(Of Product) = _productDao.SelectDetailByProductId(Convert.ToString(cart.ProductId))
            If proList.Count <> 0 Then
                item.Product = proList(0)
                item.TotalPrice = Convert.ToString(Decimal.Multiply(New Decimal(item.Product.Price), New Decimal(item.Cart.Quantity)))
                cartTotalPrice = Decimal.Add(cartTotalPrice, Decimal.Multiply(New Decimal(item.Product.Price), New Decimal(item.Cart.Quantity)))
            End If
            resList.Add(item)
        Next
    End Sub
    Private Function CreateOrder() As Long
        Dim dateStart As DateTime = New DateTime(1970, 1, 1, 8, 0, 0)
        Dim currentTime As Long = Convert.ToInt32((DateTime.Now - dateStart).TotalSeconds)
        Return CLng(currentTime & String.Empty & Convert.ToInt32(Rnd() * 100))
    End Function
End Class
