Imports MMall
Imports System.Data.SqlClient
Public Class OrderItemDaoImpl : Implements IOrderItemDao
    Private Const _baseColumnStr As String = "id,user_id,order_no,product_id,product_name,product_image,current_unit_price,quantity,total_price,create_time,update_time"

    Public Function CreateOrderItem(orderItem As OrderItem) As Boolean Implements IOrderItemDao.CreateOrderItem
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "insert into cjbmall_order_item values( @user_id, @order_no,@product_id, 
@product_name,@product_image,@current_unit_price,@quantity,@total_price,@create_time,@update_time)"
        Dim sqlParams() As SqlParameter = {
            New SqlParameter("@user_id", orderItem.UserId),
            New SqlParameter("@order_no", orderItem.OrderNo),
            New SqlParameter("@product_id", orderItem.ProductId),
            New SqlParameter("@product_name", orderItem.ProductName),
            New SqlParameter("@product_image", orderItem.ProductImage),
            New SqlParameter("@current_unit_price", orderItem.CurrentUnitPrice),
            New SqlParameter("@quantity", orderItem.Quantity),
            New SqlParameter("@total_price", orderItem.TotalPrice),
            New SqlParameter("@create_time", Date.Now),
            New SqlParameter("@update_time", Date.Now)
            }
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)
        Return result
    End Function

    Public Function SelectOrderItemListByOrderNo(orderNo As Long) As List(Of OrderItem) Implements IOrderItemDao.SelectOrderItemListByOrderNo
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "select " & _baseColumnStr & " from cjbmall_order_item where order_no=@orderNo"
        Dim params() As SqlParameter = {New SqlParameter("@orderNo", orderNo)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of OrderItem)(dt)
    End Function
End Class
