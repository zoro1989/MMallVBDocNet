Public Class Shipping
    Private _id As Integer

    Private _userId As Integer

    Private _receiverName As String

    Private _receiverPhone As String

    Private _receiverMobile As String

    Private _receiverProvince As String

    Private _receiverCity As String

    Private _receiverDistrict As String

    Private _receiverAddress As String

    Private _receiverZip As String

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

    Public Property ReceiverName As String
        Get
            Return _receiverName
        End Get
        Set(value As String)
            _receiverName = value
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

    Public Property ReceiverMobile As String
        Get
            Return _receiverMobile
        End Get
        Set(value As String)
            _receiverMobile = value
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

    Public Property ReceiverDistrict As String
        Get
            Return _receiverDistrict
        End Get
        Set(value As String)
            _receiverDistrict = value
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

    Public Property ReceiverZip As String
        Get
            Return _receiverZip
        End Get
        Set(value As String)
            _receiverZip = value
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
