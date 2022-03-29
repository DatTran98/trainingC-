<%@ WebHandler Language="VB" Class="DownloadFile" %>
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports System.Configuration
Public Class DownloadFile : Implements IHttpHandler

    Public ReadOnly Property IsReusable As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Public Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim request As HttpRequest = HttpContext.Current.Request
        Dim des As String = request.QueryString("des")
        Dim response As HttpResponse = HttpContext.Current.Response
        Dim fileName As String = "ExportEmpoyee.csv"
        response.ClearContent()
        response.Clear()
        response.ContentType = "text/plain"
        response.AddHeader("Content-Disposition",
                           "attachment; filename=" + fileName + ";")
        response.TransmitFile(des)
        response.Flush()
        response.End()

    End Sub
End Class
