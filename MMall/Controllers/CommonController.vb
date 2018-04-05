Imports System.Web.Mvc

Namespace Controllers
    Public Class CommonController
        Inherits Controller

        ' GET: Common
        Function Index(msg As String) As ActionResult
            Return View(msg)
        End Function
    End Class
End Namespace