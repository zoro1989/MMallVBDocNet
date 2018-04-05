Public Class Order
    Private _id As Integer

    Private _orderNo As Long

    Private _userId As Integer

    Private _shippingId As Integer

    Private _payment As Decimal

    Private _paymentType As Integer

    Private _postage As Integer

    Private _status As Integer

    Private _paymentTime As Date

    Private _sendTime As Date

    Private _endTime As Date

    Private _closeTime As Date

    Private _createTime As Date

    Private _updateTime As Date

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property OrderNo As Long
        Get
            Return _orderNo
        End Get
        Set(value As Long)
            _orderNo = value
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

    Public Property ShippingId As Integer
        Get
            Return _shippingId
        End Get
        Set(value As Integer)
            _shippingId = value
        End Set
    End Property

    Public Property Payment As Decimal
        Get
            Return _payment
        End Get
        Set(value As Decimal)
            _payment = value
        End Set
    End Property

    Public Property PaymentType As Integer
        Get
            Return _paymentType
        End Get
        Set(value As Integer)
            _paymentType = value
        End Set
    End Property

    Public Property Postage As Integer
        Get
            Return _postage
        End Get
        Set(value As Integer)
            _postage = value
        End Set
    End Property

    Public Property Status As Integer
        Get
            Return _status
        End Get
        Set(value As Integer)
            _status = value
        End Set
    End Property

    Public Property PaymentTime As Date
        Get
            Return _paymentTime
        End Get
        Set(value As Date)
            _paymentTime = value
        End Set
    End Property

    Public Property SendTime As Date
        Get
            Return _sendTime
        End Get
        Set(value As Date)
            _sendTime = value
        End Set
    End Property

    Public Property EndTime As Date
        Get
            Return _endTime
        End Get
        Set(value As Date)
            _endTime = value
        End Set
    End Property

    Public Property CloseTime As Date
        Get
            Return _closeTime
        End Get
        Set(value As Date)
            _closeTime = value
        End Set
    End Property

    Public Property CreateTime As Date
        Get
            Return _createTime
        End Get
        Set(value As Date)
            _createTime = value
        End Set
    End Property

    Public Property UpdateTime As Date
        Get
            Return _updateTime
        End Get
        Set(value As Date)
            _updateTime = value
        End Set
    End Property
End Class
