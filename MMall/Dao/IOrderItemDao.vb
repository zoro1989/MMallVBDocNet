Public Interface IOrderItemDao
    Function SelectOrderItemListByOrderNo(orderNo As Long) As List(Of OrderItem)
    Function CreateOrderItem(orderItem As OrderItem) As Boolean
End Interface
