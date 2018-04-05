Imports MMall
Imports System.Data.SqlClient
Public Class ProductDaoImpl : Implements IProductDao
    Private Const _baseColumnStr As String = "id, category_id, name, subtitle, main_image, sub_images, detail, price, stock, status, create_time, update_time"


    'Select TOP 页大小 * 
    'FROM
    '    (
    '        Select ROW_NUMBER() OVER (ORDER BY id) As RowNumber,* FROM table1
    '    )   as A  
    'WHERE RowNumber > 页大小*(页数-1) 

    '--注解首先利用Row_number()为table1表的每一行添加一个行号，给行号这一列取名'RowNumber' 在over()方法中将'RowNumber'做了升序排列
    '--然后将'RowNumber'列 与table1表的所有列 形成一个表A
    '--重点在where条件。假如当前页(currentPage)是第2页，每页显示10个数据(pageSzie)。那么第一页的数据就是第11-20条
    '--所以为了显示第二页的数据，即显示第11-20条数据，那么就让RowNumber大于 10*(2-1) 即：页大小*(当前页-1)

    '  Select * from(
    '　　select *, ROW_NUMBER() OVER(Order by Id ) As RowNumber from tablename  
    ') as b  
    'where RowNumber BETWEEN 当前页数-1*条数 And 页数*条数
    Public Function SelectByProductName(viewModel As GoodsListViewModel) As List(Of Product) Implements IProductDao.SelectByProductName
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of Product) = New List(Of Product)

        Dim orderStr As String = String.Empty
        If Not String.IsNullOrEmpty(viewModel.OrderBy) Then
            orderStr = "order by price " & viewModel.OrderBy
        Else
            orderStr = "order by id"
        End If
        Dim categoryIdStr As String = String.Empty
        If Not String.IsNullOrEmpty(viewModel.CategoryId) Then
            categoryIdStr = " and category_id=" & viewModel.CategoryId
        End If
        'Dim sqlStr As String = "Select " & _baseColumnStr & " from (select " & _baseColumnStr & " ,ROW_NUMBER() OVER (Order by id) As RowNumber from cjbmall_product) as b where name Like '" & viewModel.Keyword & "'  " & categoryIdStr & orderStr & "and RowNumber Between @pageStart and @pageEnd"
        Dim sqlStr As String = "Select TOP  " & ConstVal.PAGE_SIZE_GODDS & "  a.* from (select ROW_NUMBER() OVER (" & orderStr & ") As RowNumber, * FROM cjbmall_product where name Like '" & viewModel.Keyword & "' " & categoryIdStr & ") as a where RowNumber > @endNo"
        'Dim params() As SqlParameter = {
        '    New SqlParameter("@pageStart", (viewModel.PageNo - 1) * ConstVal.PAGE_SIZE_GODDS + 1),
        '    New SqlParameter("@pageEnd", viewModel.PageNo * ConstVal.PAGE_SIZE_GODDS)}

        Dim params() As SqlParameter = {
            New SqlParameter("@endNo", ConstVal.PAGE_SIZE_GODDS * (viewModel.PageNo - 1))
        }

        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)

        Return ConvertHelper.convertToList(Of Product)(dt)
    End Function

    Public Function SelectCountByProductName(viewModel As GoodsListViewModel) As List(Of Page) Implements IProductDao.SelectCountByProductName
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of Product) = New List(Of Product)

        Dim categoryIdStr As String = String.Empty
        If Not String.IsNullOrEmpty(viewModel.CategoryId) Then
            categoryIdStr = " And category_id=" & viewModel.CategoryId
        End If
        Dim sqlStr As String = "Select count(id) As count from cjbmall_product where name Like '" & viewModel.Keyword & "'  " & categoryIdStr

        Dim dt As DataTable = helper.ExecSelectNo(sqlStr, CommandType.Text)

        Return ConvertHelper.convertToList(Of Page)(dt)
    End Function

    Public Function SelectDetailByProductId(productId As String) As List(Of Product) Implements IProductDao.SelectDetailByProductId
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "select " & _baseColumnStr & " from cjbmall_product where id=@productId"
        Dim params() As SqlParameter = {New SqlParameter("@productId", productId)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of Product)(dt)
    End Function
End Class
