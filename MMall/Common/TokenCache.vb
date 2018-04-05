Public Class TokenCache
    Public Shared TOKEN_PREFIX As String = "token_"
    Public Shared Sub SetKey(key As String, value As String)
        Dim cache As Cache = HttpRuntime.Cache
        cache.Insert(key, value, Nothing, System.DateTime.Now.AddSeconds(100), TimeSpan.Zero)
    End Sub
    Public Shared Function GetKey(key As String) As String
        Dim cache As Cache = HttpRuntime.Cache
        Return Convert.ToString(cache.Get(key))
    End Function

End Class
