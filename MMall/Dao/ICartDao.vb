Public Interface ICartDao
    Function InsertCartByProductDetail(viewModel As GoodsAddCartSuccessViewModel) As Boolean
    Function SelectCartCount(userId As String) As List(Of Page)
    Function SelectCartByUserId(userId As String) As List(Of Cart)
    Function DeleteCartById(cartId As String, userId As String) As Boolean
    Function UpdateCartInfoById(cartId As String, quantity As String, userId As String) As Boolean
    Function SelectCheckedCartByUserId(userId As String) As List(Of Cart)
    Function UpdateNotCheckedCartInfoById(cartId As String, quantity As String, userId As String) As Boolean
    Function DeleteCheckedCart(userId As String) As Boolean
End Interface
