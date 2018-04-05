Public Class PageUtils
    Shared Function ComputedPage(page As Page, pageNo As Integer, pageSize As Integer) As Page
        page.PageCount = Convert.ToInt32(Math.Ceiling(page.Count / pageSize))
        If pageNo = 1 Then
            page.HasPrevPage = False
        Else
            page.HasPrevPage = True
        End If
        If pageNo = page.PageCount Then
            page.HasNextPage = False
        Else
            page.HasNextPage = True
        End If
        page.CurrentPage = pageNo
        Return page
    End Function
End Class
