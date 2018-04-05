Public Interface IProductService
    Function GetProductByKeyword(viewModel As GoodsListViewModel) As ServerResponse(Of ProductInfoDto)
    Function GetProductDetailById(productId As String) As ServerResponse(Of ProductDtailInfoDto)
    Function AddProductToCart(viewModel As GoodsAddCartSuccessViewModel) As ServerResponse(Of Integer)
End Interface
