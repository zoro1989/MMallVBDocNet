Imports MMall

Public Class ProductInfoDto
    Private _page As Page
    Private _productList As List(Of Product)

    Public Property Page As Page
        Get
            Return _page
        End Get
        Set(value As Page)
            _page = value
        End Set
    End Property

    Public Property ProductList As List(Of Product)
        Get
            Return _productList
        End Get
        Set(value As List(Of Product))
            _productList = value
        End Set
    End Property
End Class
