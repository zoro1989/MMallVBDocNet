Public Class ServiceFactory
    Public Shared Function GetClass(Of T As {New})() As T
        Return New T
    End Function

End Class
