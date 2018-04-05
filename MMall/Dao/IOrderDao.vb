Public Interface IOrderDao
    Function SelectOrderListByUserId(userId As Integer, pageNo As Integer, pageSize As Integer) As List(Of Order)
    Function SelectOrderListCount(userId As Integer) As List(Of Page)
    Function SelectOrderDetailById(orderNumber As String, userId As String) As List(Of Order)
    Function CreateOrder(order As Order) As Boolean
End Interface
