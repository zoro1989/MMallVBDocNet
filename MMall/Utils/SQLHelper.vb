Imports System.Data.SqlClient
Imports System.Configuration
Public Class SQLHelper
    '定义变量     
    '获得数据库连接字符串    
    Private ReadOnly strConnection As String = System.Configuration.ConfigurationManager.AppSettings("strConnection")
    '设置连接    
    Dim conn As SqlConnection = New SqlConnection(strConnection)
    '定义cmd 命令    
    Dim cmd As New SqlCommand
    Public Function GetConn() As SqlConnection
        Return conn
    End Function
    Public Sub CloseConnCmd()
        Call CloseConn(conn)
        Call CloseCmd(cmd)
    End Sub
    ''' <summary>    
    ''' 执行增删改三个操作，（有参）返回值为Boolean类型，确认是否执行成功    
    ''' </summary>    
    '''<param name="cmdText">需要执行语句，一般是Sql语句，也有存储过程</param>    
    ''' <param name="paras">参数数组，无法确认有多少参数</param>    
    ''' <returns></returns>    
    '''<remarks></remarks>    
    Public Function ExecAddDelUpdate(ByVal cmdText As String, ByVal cmdType As CommandType, ByVal paras As SqlParameter(), Optional ByRef trans As SqlTransaction = Nothing) As Boolean
        '将传入的值，分别为cmd的属性赋值    
        cmd.Parameters.AddRange(paras)         '将参数传入    
        cmd.CommandType = cmdType              '设置一个值，解释cmdText    
        cmd.Connection = conn                  '设置连接，全局变量     
        cmd.CommandText = cmdText              '设置查询的语句    
        If trans Is Nothing Then
            cmd.Transaction = trans
        End If
        Try
            conn.Open()                      '打开连接    
            Return Convert.ToBoolean(cmd.ExecuteNonQuery())     '执行增删改操作    
            cmd.Parameters.Clear()          '清除参数    
        Catch ex As Exception
            MsgBox(ex.Message, , "数据库操作") '如果出错，返回0    
            Return False
        Finally
            Call CloseConn(conn)
            Call CloseCmd(cmd)
        End Try
    End Function
    ''' <summary>    
    ''' 执行增删改三个操作，（无参）返回值为Boolean类型，确认是否执行成功    
    ''' </summary>    
    '''<param name="cmdText">需要执行语句，一般是Sql语句，也有存储过程</param>    
    ''' <returns>Interger,受影响的行数</returns>    
    '''<remarks></remarks>    
    Public Function ExecAddDelUpdateNo(ByVal cmdText As String, ByVal cmdType As CommandType, Optional ByRef trans As SqlTransaction = Nothing) As Boolean
        '为要执行的命令cmd赋值    
        cmd.CommandText = cmdText    '先是查询的sql语句    
        cmd.CommandType = cmdType    '设置Sql语句如何解释    
        cmd.Connection = conn '设置连接
        If trans Is Nothing Then
            cmd.Transaction = trans
        End If
        '执行操作    
        Try
            conn.Open()
            Return Convert.ToBoolean(cmd.ExecuteNonQuery())

        Catch ex As Exception
            MsgBox(ex.Message, , "数据库操作") '如果出错，返回0    
            Return False
        Finally
            Call CloseConn(conn)
            Call CloseCmd(cmd)
        End Try
    End Function

    ''' <summary>    
    ''' 执行查询操作，（有参），返回值为datatable类型，参数不限    
    ''' </summary>    
    '''<param name="cmdText">需要执行语句，一般是Sql语句，也有存储过程</param>    
    '''<param name="paras">传入的参数</param>     
    ''' <returns></returns>    
    '''<remarks></remarks>    
    Public Function ExecSelect(ByVal cmdText As String, ByVal cmdType As CommandType, ByVal paras As SqlParameter()) As DataTable

        Dim sqlAdapter As SqlDataAdapter
        Dim dt As New DataTable
        Dim ds As New DataSet

        '给cmd赋值    
        cmd.CommandText = cmdText
        cmd.CommandType = cmdType
        cmd.Connection = conn
        cmd.Parameters.AddRange(paras)  '参数添加    
        sqlAdapter = New SqlDataAdapter(cmd)   '实例化adapter    
        Try
            sqlAdapter.Fill(ds)  '用adapter将dataset填充    
            dt = ds.Tables(0)
            cmd.Parameters.Clear()

        Catch ex As Exception
            'MsgBox(" 查询失败", CType(vbOKOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), "警告")    
            MsgBox(ex.Message, , "数据库操作")  '如果出错，返回0    

        Finally
            Call CloseCmd(cmd)
        End Try
        Return dt

    End Function
    ''' <summary>    
    ''' 执行查询操作，（无参），返回值为datatable类型    
    ''' </summary>    
    '''<param name="cmdText">需要执行语句，一般是Sql语句，也有存储过程</param>    
    '''<param name="cmdType">判断Sql语句的类型，一般都不是存储过程</param>     
    ''' <returns>dataTable,查询到的表格</returns>    
    '''<remarks></remarks>    
    Public Function ExecSelectNo(ByVal cmdText As String, ByVal cmdType As CommandType) As DataTable
        Dim sqlAdapter As SqlDataAdapter
        Dim dt As New DataTable
        Dim ds As New DataSet
        '给cmd赋值    
        cmd.CommandText = cmdText
        cmd.CommandType = cmdType
        cmd.Connection = conn
        sqlAdapter = New SqlDataAdapter(cmd)  '实例化adapter    
        Try
            sqlAdapter.Fill(ds)     '用adapter将dataset填充    
            dt = ds.Tables(0)       'datatable为dataSet的第一个表    
        Catch ex As Exception
            MsgBox(ex.Message, , "数据库操作")  '如果出错，返回0    
        Finally
            Call CloseCmd(cmd)

        End Try
        Return dt
    End Function

    ''' <summary>    
    ''' 关闭连接    
    ''' </summary>    
    '''<param name="conn ">需要关闭的连接</param>    
    '''<remarks></remarks>    
    Public Sub CloseConn(ByVal conn As SqlConnection)
        If (conn.State <> ConnectionState.Closed) Then '如果没有关闭    
            conn.Close()                               '关闭连接    
            conn = Nothing                             '不指向原对象    
        End If
    End Sub
    ''' <summary>    
    ''' 关闭命令    
    ''' </summary>    
    '''<param name="cmd ">需要关闭的命令 </param>    
    '''<remarks></remarks>    
    Public Sub CloseCmd(ByVal cmd As SqlCommand)
        If Not IsNothing(cmd) Then  '如果cmd命令存在    
            cmd.Dispose()           '销毁    
            cmd = Nothing
        End If
    End Sub
End Class
