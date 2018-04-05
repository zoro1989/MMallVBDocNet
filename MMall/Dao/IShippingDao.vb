Public Interface IShippingDao
    Function GetShippingById(shippingId As String, userId As String) As List(Of Shipping)
    Function GetAllShippingByUserId(userId As String) As List(Of Shipping)
    Function InsertShipping(shipping As Shipping) As Integer
    Function DeleteShippingById(shippingId As String, userId As String) As Boolean
    Function UpdateShipping(shipping As Shipping) As Boolean
End Interface
