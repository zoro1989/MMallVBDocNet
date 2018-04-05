Imports MMall

Public Class OrderServiceImpl : Implements IOrderService
    Private _orderDao As IOrderDao = New OrderDaoImpl
    Private _orderItemDao As IOrderItemDao = New OrderItemDaoImpl
    Private _shippingDao As IShippingDao = New ShippingDaoImpl
    ''' <summary>
    ''' 获取订单详情
    ''' </summary>
    ''' <param name="orderNumber"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function GetOrderDetail(orderNumber As String, userId As String) As ServerResponse(Of OrderInfoDto) Implements IOrderService.GetOrderDetail
        Dim orderList As List(Of Order) = _orderDao.SelectOrderDetailById(orderNumber, userId)
        If orderList.Count = 0 Then
            Return ServerResponse(Of OrderInfoDto).CreateByErrorMessage("没有找到对应的订单")
        End If
        Dim order As Order = orderList(0)
        Dim dto As OrderInfoDto = Me.AssembleOrderList(order, userId)
        ' 获取订单子表信息
        dto.OrderItemList = _orderItemDao.SelectOrderItemListByOrderNo(order.OrderNo)
        Return ServerResponse(Of OrderInfoDto).createBySuccess(dto)
    End Function
    ''' <summary>
    ''' 获取订单列表
    ''' </summary>
    ''' <param name="user"></param>
    ''' <param name="pageNo"></param>
    ''' <param name="pageSize"></param>
    ''' <returns></returns>
    Public Function GetOrderList(user As User, pageNo As Integer, pageSize As Integer) As ServerResponse(Of OrderListInfoDto) Implements IOrderService.GetOrderList

        Dim orderList As List(Of Order) = _orderDao.SelectOrderListByUserId(user.Id, pageNo, pageSize)
        Dim page As Page = _orderDao.SelectOrderListCount(user.Id)(0)

        page = PageUtils.ComputedPage(page, pageNo, pageSize)

        Dim orderInfoList As List(Of OrderInfoDto) = New List(Of OrderInfoDto)
        For Each order In orderList
            Dim dto As OrderInfoDto = Me.AssembleOrderList(order, Convert.ToString(user.Id))
            dto.OrderItemList = _orderItemDao.SelectOrderItemListByOrderNo(order.OrderNo)
            orderInfoList.Add(dto)
        Next
        If orderInfoList.Count = 0 Then
            Return ServerResponse(Of OrderListInfoDto).CreateByErrorMessage("未检索到订单")
        End If
        Dim res As OrderListInfoDto = New OrderListInfoDto
        res.OrderListDto = orderInfoList
        res.Page = page

        Return ServerResponse(Of OrderListInfoDto).createBySuccess(res)
    End Function
    ''' <summary>
    ''' 组装订单列表
    ''' </summary>
    ''' <param name="order"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Private Function AssembleOrderList(order As Order, userId As String) As OrderInfoDto
        Dim orderInfo As OrderInfoDto = New OrderInfoDto
        orderInfo.Id = order.Id
        orderInfo.OrderNo = order.OrderNo
        orderInfo.UserId = order.UserId
        orderInfo.ShippingId = order.ShippingId

        Dim shippingList As List(Of Shipping) = _shippingDao.GetShippingById(Convert.ToString(orderInfo.ShippingId), userId)
        If shippingList.Count > 0 Then
            Dim shipping As Shipping = shippingList(0)
            orderInfo.ReceiverName = shipping.ReceiverName
            orderInfo.ReceiverProvince = shipping.ReceiverProvince
            orderInfo.ReceiverCity = shipping.ReceiverCity
            orderInfo.ReceiverAddress = shipping.ReceiverAddress
            orderInfo.ReceiverMobile = shipping.ReceiverMobile
        End If
        orderInfo.Payment = order.Payment
        Dim paymentType As Integer = order.PaymentType
        If paymentType = 1 Then
            orderInfo.PaymentType = "在线支付"
        Else
            orderInfo.PaymentType = "其他"
        End If

        orderInfo.Postage = order.Postage
        Dim status As Integer = order.Status
        Dim statusStr As String = String.Empty
        If status = 0 Then
            statusStr = "已取消"
        ElseIf status = 10 Then
            statusStr = "未付款"
        ElseIf status = 20 Then
            statusStr = "已付款"
        ElseIf status = 40 Then
            statusStr = "已发货"
        ElseIf status = 50 Then
            statusStr = "交易成功"
        ElseIf status = 60 Then
            statusStr = "交易关闭"
        End If
        If status = 10 Then
            orderInfo.NeedPay = True
            orderInfo.IsCancelable = True
        Else
            orderInfo.NeedPay = False
            orderInfo.IsCancelable = False
        End If
        orderInfo.Status = statusStr
        orderInfo.PaymentTime = order.PaymentTime
        orderInfo.SendTime = order.SendTime
        orderInfo.EndTime = order.EndTime
        orderInfo.CreateTime = order.CreateTime
        Return orderInfo
    End Function

End Class
