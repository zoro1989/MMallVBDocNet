Imports MMall
Imports System.Data.SqlClient
Public Class OrderDaoImpl : Implements IOrderDao

    Private Const _baseColumnStr As String = "id,order_no,user_id,shipping_id,payment,payment_type,postage,status,payment_time,send_time,end_time,close_time,create_time,update_time"

    Public Function CreateOrder(order As Order) As Boolean Implements IOrderDao.CreateOrder
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "insert into cjbmall_order (order_no,user_id,shipping_id,payment,payment_type,postage,status,payment_time,create_time,update_time) values(@order_no, @user_id, @shipping_id, 
@payment,@payment_type,@postage,@status,@payment_time,@create_time,@update_time)"
        Dim sqlParams() As SqlParameter = {
            New SqlParameter("@order_no", order.OrderNo),
            New SqlParameter("@user_id", order.UserId),
            New SqlParameter("@shipping_id", order.ShippingId),
            New SqlParameter("@payment", order.Payment),
            New SqlParameter("@payment_type", order.PaymentType),
            New SqlParameter("@postage", order.Postage),
            New SqlParameter("@status", order.Status),
            New SqlParameter("@payment_time", Date.Now),
            New SqlParameter("@create_time", Date.Now),
            New SqlParameter("@update_time", Date.Now)
            }
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)
        Return result
    End Function

    Public Function SelectOrderDetailById(orderNumber As String, userId As String) As List(Of Order) Implements IOrderDao.SelectOrderDetailById
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "select " & _baseColumnStr & " from  cjbmall_order where order_no=@orderNumber and user_id=@userId"
        Dim params() As SqlParameter = {New SqlParameter("@orderNumber", orderNumber), New SqlParameter("@userId", userId)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of Order)(dt)
    End Function

    '  Select * from(
    '　　select *, ROW_NUMBER() OVER(Order by Id ) As RowNumber from tablename  
    ') as b  
    'where RowNumber BETWEEN 当前页数-1*条数 And 页数*条数
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function SelectOrderListByUserId(userId As Integer, pageNo As Integer, pageSize As Integer) As List(Of Order) Implements IOrderDao.SelectOrderListByUserId
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "select " & _baseColumnStr & " from (select " & _baseColumnStr & " , ROW_NUMBER() OVER(Order by create_time desc) As RowNumber from cjbmall_order) as b where user_id=@userId and RowNumber between @pageStart and @pageEnd"
        Dim params() As SqlParameter = {New SqlParameter("@userId", userId),
            New SqlParameter("@pageStart", (pageNo - 1) * pageSize),
            New SqlParameter("@pageEnd", pageNo * pageSize)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of Order)(dt)
    End Function

    Private Function IOrderDao_SelectOrderListCount(userId As Integer) As List(Of Page) Implements IOrderDao.SelectOrderListCount
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "select count(id) as count from cjbmall_order where user_id=@userId"
        Dim params() As SqlParameter = {New SqlParameter("@userId", userId)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of Page)(dt)
    End Function
End Class
