Public Class PayInfo
    Private _id As Integer

    Private _userId As Integer

    Private _orderNo As Long

    Private _payPlatform As Integer

    Private _platformNumber As String

    Private _platformStatus As String

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

    Public Property UserId As Integer
        Get
            Return _userId
        End Get
        Set(value As Integer)
            _userId = value
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

    Public Property PayPlatform As Integer
        Get
            Return _payPlatform
        End Get
        Set(value As Integer)
            _payPlatform = value
        End Set
    End Property

    Public Property PlatformNumber As String
        Get
            Return _platformNumber
        End Get
        Set(value As String)
            _platformNumber = value
        End Set
    End Property

    Public Property PlatformStatus As String
        Get
            Return _platformStatus
        End Get
        Set(value As String)
            _platformStatus = value
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
