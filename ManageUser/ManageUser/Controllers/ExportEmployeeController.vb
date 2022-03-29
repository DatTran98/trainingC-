'-----------------------------------------------------------------------
' <copyright file="ExportEmployeeController.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.IO
Imports System.Text
Imports System.Web.Mvc

Namespace Controllers
    '''' ------------------------------------
    ''' Project  : Traning_nic_vb
    ''' Class  : ExportEmployeeController
    ''' ------------------------------------ 
    ''' <summary>
    ''' Controller to control Export permision task
    ''' </summary>
    ''' <history>
    '''  DatTB 25/06/2021 Created
    ''' </history>
    ''' ------------------------------------
    Public Class ExportEmployeeController
        Inherits Controller

        ''' ------------------------------------
        ''' <summary>
        ''' Get Mothod to do export employ and download to location file
        ''' </summary>
        ''' <returns>The result</returns>
        ''' ------------------------------------
        <Obsolete>
        Function ExportEmp() As ActionResult
            Try
                If (Session(Constant.USERNAME) Is Nothing) Then
                    Return RedirectToAction("../Login/Login")
                Else
                    Dim message As String = String.Empty
                    Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
                    Dim fileName As String = "ExportEmpoyee.csv"
                    Dim des = path & "/Downloads/" & fileName
                    If (Not System.IO.Directory.Exists(path)) Then
                        System.IO.Directory.CreateDirectory(des)
                    End If
                    Dim listUserModel As ListUserModel = New ListUserModel
                    Dim dt As DataTable = New DataTable
                    dt = listUserModel.GetListUser(String.Empty)
                    If dt.Rows.Count <= 0 Then
                        message = Constant.NO_DATA_FIT
                        ViewData(Constant.MESSAGE) = message
                    Else
                        Dim resWriteCSV = WriteToCSV(dt, des)
                        If resWriteCSV Then
                            message = Constant.EXPORT_SUCESSED
                            ViewData(Constant.MESSAGE) = message
                        Else
                            message = Constant.EXPORT_FAILED
                            ViewData(Constant.MESSAGE) = message
                        End If
                    End If
                End If
            Catch ex As Exception
                Session.Add(Constant.ERRORS, Constant.EXCEPTION_PROB)
                Return View(Constant.ERROR_VIEW)
            End Try
            Return View()
        End Function
        ''' ------------------------------------
        ''' <summary>
        ''' Function to write data to csvfile
        ''' </summary>
        ''' <param name="dataTable"></param>
        ''' <param name="filePath"></param>
        ''' <returns></returns>
        ''' ------------------------------------
        Public Function WriteToCSV(dataTable As DataTable, filePath As String) As Boolean
            Dim fileStream As FileStream
            Dim streamWriter As StreamWriter
            Dim i, j As Integer
            Dim strRow As String

            Try
                If (IO.File.Exists(filePath)) Then
                    IO.File.Delete(filePath)
                End If

                fileStream = New FileStream(filePath, FileMode.CreateNew, FileAccess.Write)

                If Not dataTable Is Nothing Then
                    streamWriter = New StreamWriter(fileStream, Encoding.UTF8)

                    For i = 0 To dataTable.Rows.Count - 1
                        strRow = ""
                        For j = 0 To dataTable.Columns.Count - 1
                            strRow += dataTable(i)(j)
                            If j < dataTable.Columns.Count - 1 Then
                                strRow += ","
                            End If
                        Next
                        streamWriter.WriteLine(strRow)
                    Next
                    streamWriter.Close()
                End If
                fileStream.Close()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class
End Namespace