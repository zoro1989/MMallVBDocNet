Public Interface IOrderService
    Function GetOrderList(user As User, pageNo As Integer, pageSize As Integer) As ServerResponse(Of OrderListInfoDto)
    Function GetOrderDetail(orderNumber As String, userId As String) As ServerResponse(Of OrderInfoDto)
End Interface
