Imports MMall

Public Class GoodsDetailViewModel
    Private _quantity As Integer

    Private _result As ServerResponse(Of ProductDtailInfoDto)

    Public Property Quantity As Integer
        Get
            Return _quantity
        End Get
        Set(value As Integer)
            _quantity = value
        End Set
    End Property

    Public Property Result As ServerResponse(Of ProductDtailInfoDto)
        Get
            Return _result
        End Get
        Set(value As ServerResponse(Of ProductDtailInfoDto))
            _result = value
        End Set
    End Property
End Class
