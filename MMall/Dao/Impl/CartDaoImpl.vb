﻿Imports MMall
Imports System.Data.SqlClient
Public Class CartDaoImpl : Implements ICartDao
    Private Const _baseColumnStr As String = "id,user_id,product_id,quantity,checked,create_time,update_time"

    ''' <summary>
    ''' 删除购物车
    ''' </summary>
    ''' <param name="cartId"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function DeleteCartById(cartId As String, userId As String) As Boolean Implements ICartDao.DeleteCartById
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "delete from cjbmall_cart where id=@cartId and user_id=@userId"
        Dim sqlParams() As SqlParameter = {New SqlParameter("@userId", userId), New SqlParameter("@cartId", cartId)}
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)
        Return result
    End Function
    ''' <summary>
    ''' 删除选中的购物车
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function DeleteCheckedCart(userId As String) As Boolean Implements ICartDao.DeleteCheckedCart
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "delete from cjbmall_cart where checked=1 and user_id=@userId"
        Dim sqlParams() As SqlParameter = {New SqlParameter("@userId", userId)}
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)
        Return result
    End Function
    ''' <summary>
    ''' 插入购物车
    ''' </summary>
    ''' <param name="viewModel"></param>
    ''' <returns></returns>
    Public Function InsertCartByProductDetail(viewModel As GoodsAddCartSuccessViewModel) As Boolean Implements ICartDao.InsertCartByProductDetail
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "insert into cjbmall_cart values(@userId, @productId, @quantity, @checked,@createTime,@updateTime)"
        Dim sqlParams() As SqlParameter = {New SqlParameter("@userId", viewModel.UserId),
            New SqlParameter("@productId", viewModel.ProductId),
            New SqlParameter("@quantity", viewModel.Quantity),
            New SqlParameter("@checked", 0),
            New SqlParameter("@createTime", Date.Now),
            New SqlParameter("@updateTime", Date.Now)}
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)
        Return result
    End Function
    ''' <summary>
    ''' 搜索用户的购物车
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function SelectCartByUserId(userId As String) As List(Of Cart) Implements ICartDao.SelectCartByUserId
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "select " & _baseColumnStr & " from cjbmall_cart where user_id=@userId"
        Dim sqlParams() As SqlParameter = {New SqlParameter("@userId", userId)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, sqlParams)
        Return ConvertHelper.convertToList(Of Cart)(dt)
    End Function
    ''' <summary>
    ''' 搜索购物车的数量
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function SelectCartCount(userId As String) As List(Of Page) Implements ICartDao.SelectCartCount
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "select count(id) as count from cjbmall_cart where user_id=@userId"
        Dim sqlParams() As SqlParameter = {New SqlParameter("@userId", userId)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, sqlParams)
        Return ConvertHelper.convertToList(Of Page)(dt)
    End Function
    ''' <summary>
    ''' 获取选中的购物车
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function SelectCheckedCartByUserId(userId As String) As List(Of Cart) Implements ICartDao.SelectCheckedCartByUserId
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "select " & _baseColumnStr & " from cjbmall_cart where user_id=@userId and checked=1"
        Dim sqlParams() As SqlParameter = {New SqlParameter("@userId", userId)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, sqlParams)
        Return ConvertHelper.convertToList(Of Cart)(dt)
    End Function
    ''' <summary>
    ''' 更新购物车信息
    ''' </summary>
    ''' <param name="cartId"></param>
    ''' <param name="quantity"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function UpdateCartInfoById(cartId As String, quantity As String, userId As String) As Boolean Implements ICartDao.UpdateCartInfoById
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "update cjbmall_cart set quantity=@quantity, checked=@checked where id=@cartId and user_id=@userId"
        Dim sqlParams() As SqlParameter = {New SqlParameter("@quantity", quantity),
            New SqlParameter("@cartId", cartId),
            New SqlParameter("@userId", userId),
            New SqlParameter("@checked", 1),
            New SqlParameter("@updateTime", Date.Now)}
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)

        Return result
    End Function
    ''' <summary>
    ''' 更新购物车信息(不选中)
    ''' </summary>
    ''' <param name="cartId"></param>
    ''' <param name="quantity"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function UpdateNotCheckedCartInfoById(cartId As String, quantity As String, userId As String) As Boolean Implements ICartDao.UpdateNotCheckedCartInfoById
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "update cjbmall_cart set quantity=@quantity, checked=@checked where id=@cartId and user_id=@userId"
        Dim sqlParams() As SqlParameter = {New SqlParameter("@quantity", quantity),
            New SqlParameter("@cartId", cartId),
            New SqlParameter("@userId", userId),
            New SqlParameter("@checked", 0),
            New SqlParameter("@updateTime", Date.Now)}
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)
        Return result
    End Function
End Class
