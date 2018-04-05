Imports MMall
Imports System.Data.SqlClient
Public Class CategoryDaoImpl : Implements ICategoryDao

    Private Const _baseColumnStr As String = "id, parent_id, name, status, sort_order, create_time, update_time, img_url"
    ''' <summary>
    ''' 获取所有商品类别
    ''' </summary>
    ''' <returns></returns>
    Public Function SelectAllCategory() As List(Of Category) Implements ICategoryDao.SelectAllCategory
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of Category) = New List(Of Category)
        Dim sqlStr As String = "select " & _baseColumnStr & " from cjbmall_category where parent_id=0"
        Dim dt As DataTable = helper.ExecSelectNo(sqlStr, CommandType.Text)
        Return ConvertHelper.convertToList(Of Category)(dt)
    End Function
    ''' <summary>
    ''' 根据父品类id获取所有子品类
    ''' </summary>
    ''' <param name="parentId"></param>
    ''' <returns></returns>
    Public Function SelectCategoryItems(parentId As Integer) As List(Of Category) Implements ICategoryDao.SelectCategoryItems
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of Category) = New List(Of Category)
        Dim sqlStr As String = "select " & _baseColumnStr & " from cjbmall_category where parent_id=@parentId"
        Dim params() As SqlParameter = {New SqlParameter("@parentId", parentId)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of Category)(dt)
    End Function
    ''' <summary>
    ''' 获取所有子品类
    ''' </summary>
    ''' <returns></returns>
    Public Function SelectCategoryNoTire() As List(Of Category) Implements ICategoryDao.SelectCategoryNoTire
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of Category) = New List(Of Category)
        Dim sqlStr As String = "select " & _baseColumnStr & " from cjbmall_category where parent_id <> 0"

        Dim dt As DataTable = helper.ExecSelectNo(sqlStr, CommandType.Text)
        Return ConvertHelper.convertToList(Of Category)(dt)
    End Function
End Class
