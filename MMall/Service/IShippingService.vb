Public Interface IShippingService
    Function AddShipping(viewModel As CartAddViewModel) As ServerResponse(Of Shipping)
    Function DeleteShipping(shippingId As String, userId As String) As ServerResponse(Of String)
    Function GetShippingInfoById(shippingId As String, userId As String) As ServerResponse(Of Shipping)
End Interface
