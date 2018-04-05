Imports MMall

Public Class OrderListInfoDto
    Private _orderListDto As List(Of OrderInfoDto)
    Private _page As Page

    Public Property OrderListDto As List(Of OrderInfoDto)
        Get
            Return _orderListDto
        End Get
        Set(value As List(Of OrderInfoDto))
            _orderListDto = value
        End Set
    End Property

    Public Property Page As Page
        Get
            Return _page
        End Get
        Set(value As Page)
            _page = value
        End Set
    End Property
End Class
