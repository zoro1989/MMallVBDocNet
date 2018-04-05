Public Class TokenCache
    Public Shared TOKEN_PREFIX As String = "token_"
    ''' <summary>
    ''' 设置token
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="value"></param>
    Public Shared Sub SetKey(key As String, value As String)
        Dim cache As Cache = HttpRuntime.Cache
        ' 设置cache,100秒超时
        cache.Insert(key, value, Nothing, System.DateTime.Now.AddSeconds(100), TimeSpan.Zero)
    End Sub
    ''' <summary>
    ''' 获取cache
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns></returns>
    Public Shared Function GetKey(key As String) As String
        Dim cache As Cache = HttpRuntime.Cache
        Return Convert.ToString(cache.Get(key))
    End Function

End Class
