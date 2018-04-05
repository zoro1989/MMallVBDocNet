Public Class ResponseCode
    Public Class CodeValue
        Private _code As Integer
        Private _desc As String
        Public Sub New(code As Integer, desc As String)
            Me.Code = code
            Me.Desc = desc
        End Sub

        Public Property Code As Integer
            Get
                Return _code
            End Get
            Set(value As Integer)
                _code = value
            End Set
        End Property

        Public Property Desc As String
            Get
                Return _desc
            End Get
            Set(value As String)
                _desc = value
            End Set
        End Property
    End Class
    ' 成功
    Public Shared SUCCESS As CodeValue = New CodeValue(0, "成功")
    ' 失败
    Public Shared ERR As CodeValue = New CodeValue(1, "失败")
    ' 重新登录
    Public Shared NEED_LOGIN As CodeValue = New CodeValue(10, "重新登录")
    ' 参数无效
    Public Shared ILLEGAL_ARGUMENT As CodeValue = New CodeValue(2, "参数无效")
End Class
