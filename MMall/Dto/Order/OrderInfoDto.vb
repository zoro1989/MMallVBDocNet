Imports MMall

Public Class OrderInfoDto
    Private _id As Integer

    Private _orderNo As Long

    Private _userId As Integer

    Private _shippingId As Integer

    Private _payment As Decimal

    Private _paymentType As String

    Private _postage As Integer

    Private _status As String

    Private _paymentTime As Date

    Private _sendTime As Date

    Private _endTime As Date

    Private _closeTime As Date

    Private _createTime As Date

    Private _updateTime As Date

    Private _receiverName As String
    Private _receiverProvince As String
    Private _receiverCity As String
    Private _receiverAddress As String
    Private _receiverMobile As String
    Private _needPay As Boolean
    Private _isCancelable As Boolean
    Private _orderItemList As List(Of OrderItem)

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

    Public Property PaymentType As String
        Get
            Return _paymentType
        End Get
        Set(value As String)
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

    Public Property Status As String
        Get
            Return _status
        End Get
        Set(value As String)
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

    Public Property OrderItemList As List(Of OrderItem)
        Get
            Return _orderItemList
        End Get
        Set(value As List(Of OrderItem))
            _orderItemList = value
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

    Public Property ReceiverMobile As String
        Get
            Return _receiverMobile
        End Get
        Set(value As String)
            _receiverMobile = value
        End Set
    End Property

    Public Property ReceiverName As String
        Get
            Return _receiverName
        End Get
        Set(value As String)
            _receiverName = value
        End Set
    End Property

    Public Property NeedPay As Boolean
        Get
            Return _needPay
        End Get
        Set(value As Boolean)
            _needPay = value
        End Set
    End Property

    Public Property IsCancelable As Boolean
        Get
            Return _isCancelable
        End Get
        Set(value As Boolean)
            _isCancelable = value
        End Set
    End Property
End Class
