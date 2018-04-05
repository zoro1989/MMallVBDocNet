Public Interface ICartService
    Function GetAllCartProducts(userId As String) As ServerResponse(Of CartInfo)
    Function DeleteCartById(cartIds() As String, userId As String) As ServerResponse(Of Integer)
    Function UpdateCartInfo(carts As List(Of CartConfirmDto), user As User) As ServerResponse(Of Boolean)
    Function GetAllCheckedCartInfoByUserId(userId As String) As ServerResponse(Of CartInfo)
    Function CreateOrder(shippingId As String, userId As String) As ServerResponse(Of Boolean)
End Interface
