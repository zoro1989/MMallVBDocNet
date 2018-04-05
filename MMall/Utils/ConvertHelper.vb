Imports System.Data.SqlClient
Imports System.Collections.Generic  '增加泛型的命名空间      
Imports System.Reflection '引入反射
Public Class ConvertHelper

    '将datatable转化为泛型集合      
    Public Shared Function convertToList(Of T As {New})(ByVal dt As DataTable) As List(Of T)
        'convertToList(Of Turn As {New}) 这里的new是用来约束T的     

        Dim myList As New List(Of T)   '定义最终返回的集合      
        Dim myTpye As Type = GetType(T) '得到实体类的类型名      
        Dim dr As DataRow   '定义行集      
        Dim tempName As String = String.Empty   '定义一个临时变量   
        Dim tempNameUnderLine As String = String.Empty   '定义一个临时变量  

        '遍历DataTable的所有数据行      
        For Each dr In dt.Rows

            Dim _T As New T    '定义一个实体类的对象      
            Dim propertys() As PropertyInfo = _T.GetType().GetProperties()  '定义属性集合      
            Dim Pr As PropertyInfo

            '遍历该对象的所有属性      
            For Each Pr In propertys
                tempName = Pr.Name '将属性名称赋值给临时变量     
                tempNameUnderLine = HandlePro(tempName)
                If (dt.Columns.Contains(tempNameUnderLine)) Then     '将此属性与datatable里的列名比较，查看datatable是否包含此属性      
                    '判断此属性是否有Setter      
                    If (Pr.CanWrite = False) Then   '判断此属性是否可写，如果不可写，跳出本次循环      
                        Continue For
                    End If
                    Dim value As Object = dr(tempNameUnderLine)  '定义一个对象型的变量来保存列的值      
                    If (value.ToString <> DBNull.Value.ToString()) Then '如果非空，则赋给对象的属性      
                        Pr.SetValue(_T, value, Nothing)    '在运行期间，通过反射，动态的访问一个对象的属性      
                    End If
                End If
            Next
            myList.Add(_T)   '添加到集合      
        Next
        Return myList   '返回实体集合      
    End Function

    Shared Function HandlePro(ByVal pro As String) As String
        If pro Is Nothing Or pro Is String.Empty Then
            Return ""
        End If
        Dim len = pro.Length
        Dim ret As String = ""
        For Each item As Char In pro.ToCharArray
            If Char.IsUpper(item) Then
                ret += "_" & Char.ToLower(item)
            Else
                ret += Char.ToLower(item)
            End If

        Next
        Return ret.Substring(1)
    End Function
End Class
