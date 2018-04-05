Imports MMall
Imports System.Data.SqlClient
Public Class ShippingDaoImpl : Implements IShippingDao
    Private Const _baseColumnStr As String = "id,user_id,receiver_name,receiver_phone,receiver_mobile,receiver_province,receiver_city,receiver_district,receiver_address,receiver_zip,create_time,update_time"
    ''' <summary>
    ''' 删除地址
    ''' </summary>
    ''' <param name="shippingId"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function DeleteShippingById(shippingId As String, userId As String) As Boolean Implements IShippingDao.DeleteShippingById
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "delete from cjbmall_shipping where id=@shippingId and user_id=@userId"
        Dim sqlParams() As SqlParameter = {New SqlParameter("@userId", userId), New SqlParameter("@shippingId", shippingId)}
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)
        Return result
    End Function
    ''' <summary>
    ''' 根据用户id获取所有地址
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function GetAllShippingByUserId(userId As String) As List(Of Shipping) Implements IShippingDao.GetAllShippingByUserId
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of Category) = New List(Of Category)
        Dim sqlStr As String = "select " & _baseColumnStr & " from cjbmall_shipping where user_id=@userId"
        Dim params() As SqlParameter = {New SqlParameter("@userId", userId)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of Shipping)(dt)
    End Function
    ''' <summary>
    ''' 获取地址信息
    ''' </summary>
    ''' <param name="shippingId"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function GetShippingById(shippingId As String, userId As String) As List(Of Shipping) Implements IShippingDao.GetShippingById
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of Category) = New List(Of Category)
        Dim sqlStr As String = "select " & _baseColumnStr & " from cjbmall_shipping where id=@shippingId and user_id = @userId"
        Dim params() As SqlParameter = {
            New SqlParameter("@shippingId", shippingId),
            New SqlParameter("@userId", userId)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of Shipping)(dt)
    End Function
    ''' <summary>
    ''' 新增地址
    ''' </summary>
    ''' <param name="shipping"></param>
    ''' <returns></returns>
    Public Function InsertShipping(shipping As Shipping) As Integer Implements IShippingDao.InsertShipping
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "insert into cjbmall_shipping values(@user_id, @receiver_name, @receiver_phone, 
@receiver_mobile,@receiver_province,@receiver_city,@receiver_district,@receiver_address,@receiver_zip, @create_time,@update_time);select @id= SCOPE_IDENTITY()"
        ' 组装插入参数,设置返回新插入数据的主键
        Dim sqlParams() As SqlParameter = {
            New SqlParameter("@id", SqlDbType.Int),
            New SqlParameter("@user_id", shipping.UserId),
            New SqlParameter("@receiver_name", shipping.ReceiverName),
            New SqlParameter("@receiver_phone", shipping.ReceiverPhone),
            New SqlParameter("@receiver_mobile", shipping.ReceiverMobile),
            New SqlParameter("@receiver_province", shipping.ReceiverProvince),
            New SqlParameter("@receiver_city", shipping.ReceiverCity),
            New SqlParameter("@receiver_district", shipping.ReceiverDistrict),
            New SqlParameter("@receiver_address", shipping.ReceiverAddress),
            New SqlParameter("@receiver_zip", shipping.ReceiverZip),
            New SqlParameter("@create_time", Date.Now),
            New SqlParameter("@update_time", Date.Now)
            }
        ' 设置返回新插入数据的主键
        sqlParams(0).Direction = ParameterDirection.Output
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)
        Return Convert.ToInt32(sqlParams(0).Value)
    End Function
    ''' <summary>
    ''' 更新地址
    ''' </summary>
    ''' <param name="shipping"></param>
    ''' <returns></returns>
    Public Function UpdateShipping(shipping As Shipping) As Boolean Implements IShippingDao.UpdateShipping
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "update cjbmall_shipping set user_id=@user_id, receiver_name=@receiver_name, receiver_phone=@receiver_phone, receiver_mobile=@receiver_mobile,receiver_province=@receiver_province,receiver_city=@receiver_city,receiver_district=@receiver_district,receiver_address=@receiver_address,receiver_zip=@receiver_zip, update_time=@update_time where id=@id"
        Dim sqlParams() As SqlParameter = {
            New SqlParameter("@id", shipping.Id),
            New SqlParameter("@user_id", shipping.UserId),
            New SqlParameter("@receiver_name", shipping.ReceiverName),
            New SqlParameter("@receiver_phone", shipping.ReceiverPhone),
            New SqlParameter("@receiver_mobile", shipping.ReceiverMobile),
            New SqlParameter("@receiver_province", shipping.ReceiverProvince),
            New SqlParameter("@receiver_city", shipping.ReceiverCity),
            New SqlParameter("@receiver_district", shipping.ReceiverDistrict),
            New SqlParameter("@receiver_address", shipping.ReceiverAddress),
            New SqlParameter("@receiver_zip", shipping.ReceiverZip),
            New SqlParameter("@update_time", Date.Now)
            }
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)
        Return result
    End Function
End Class
