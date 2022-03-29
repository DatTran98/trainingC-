Imports System.Web.Mvc

Namespace Controllers
    Public Class ErrorController
        Inherits Controller

        ' GET: Error
        Function NotFoundPage() As ActionResult
            Return View()
        End Function
        Function ErrorPage() As ActionResult
            Return View()
        End Function

    End Class
End Namespace