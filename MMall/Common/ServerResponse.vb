Public Class ServerResponse(Of T)
    Private _status As Integer
    Private _msg As String
    Private _data As T
    Private _isSuccess As Boolean

    Public ReadOnly Property Status As Integer
        Get
            Return _status
        End Get
    End Property

    Public ReadOnly Property Msg As String
        Get
            Return _msg
        End Get
    End Property

    Public ReadOnly Property Data As T
        Get
            Return _data
        End Get
    End Property

    Public ReadOnly Property IsSuccess As Boolean
        Get
            Return Me.Status = ResponseCode.SUCCESS.Code
        End Get

    End Property

    Private Sub New(status As Integer)
        Me._status = status
    End Sub
    Private Sub New(status As Integer, data As T)
        Me._status = status
        Me._data = data
    End Sub
    Private Sub New(status As Integer, msg As String, data As T)
        Me._status = status
        Me._msg = msg
        Me._data = data
    End Sub
    Private Sub New(status As Integer, msg As String)
        Me._status = status
        Me._msg = msg
    End Sub

    Public Shared Function CreateBySuccess() As ServerResponse(Of T)
        Return New ServerResponse(Of T)(ResponseCode.SUCCESS.Code)
    End Function

    Public Shared Function CreateBySuccessMessage(msg As String) As ServerResponse(Of T)
        Return New ServerResponse(Of T)(ResponseCode.SUCCESS.Code, msg)
    End Function

    Public Shared Function createBySuccess(data As T) As ServerResponse(Of T)
        Return New ServerResponse(Of T)(ResponseCode.SUCCESS.Code, data)
    End Function

    Public Shared Function createBySuccess(msg As String, data As T) As ServerResponse(Of T)
        Return New ServerResponse(Of T)(ResponseCode.SUCCESS.Code, msg, data)
    End Function

    Public Shared Function CreateByError() As ServerResponse(Of T)
        Return New ServerResponse(Of T)(ResponseCode.ERR.Code, ResponseCode.ERR.Desc)
    End Function

    Public Shared Function CreateByErrorMessage(errorMessage As String) As ServerResponse(Of T)
        Return New ServerResponse(Of T)(ResponseCode.ERR.Code, errorMessage)
    End Function

    Public Shared Function createByErrorCodeMessage(errorCode As Integer, errorMessage As String) As ServerResponse(Of T)
        Return New ServerResponse(Of T)(errorCode, errorMessage)
    End Function
End Class
