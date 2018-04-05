Public Class CartAddViewModel
    Private _shippingId As String
    Private _userId As Integer
    Private _receiverName As String
    Private _receiverProvince As String
    Private _receiverCity As String
    Private _receiverAddress As String
    Private _receiverPhone As String
    Private _receiverZip As String

    Public Property ReceiverName As String
        Get
            Return _receiverName
        End Get
        Set(value As String)
            _receiverName = value
        End Set
    End Property

    Public Property ReceiverProvince As String
        Get
            Return _receiverProvince
        End Get
        Set(value As String)
            _receiverProvince = value
        End Set
    End Property

    Public Property ReceiverCity As String
        Get
            Return _receiverCity
        End Get
        Set(value As String)
            _receiverCity = value
        End Set
    End Property

    Public Property ReceiverAddress As String
        Get
            Return _receiverAddress
        End Get
        Set(value As String)
            _receiverAddress = value
        End Set
    End Property

    Public Property ReceiverPhone As String
        Get
            Return _receiverPhone
        End Get
        Set(value As String)
            _receiverPhone = value
        End Set
    End Property

    Public Property ReceiverZip As String
        Get
            Return _receiverZip
        End Get
        Set(value As String)
            _receiverZip = value
        End Set
    End Property

    Public Property UserId As Integer
        Get
            Return _userId
        End Get
        Set(value As Integer)
            _userId = value
        End Set
    End Property

    Public Property ShippingId As String
        Get
            Return _shippingId
        End Get
        Set(value As String)
            _shippingId = value
        End Set
    End Property
End Class
