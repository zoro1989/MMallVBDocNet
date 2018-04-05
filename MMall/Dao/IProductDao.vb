Public Interface IProductDao
    Function SelectByProductName(viewModel As GoodsListViewModel) As List(Of Product)
    Function SelectCountByProductName(viewModel As GoodsListViewModel) As List(Of Page)
    Function SelectDetailByProductId(productId As String) As List(Of Product)

End Interface
