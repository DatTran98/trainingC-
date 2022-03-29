'-----------------------------------------------------------------------
' <copyright file="ImportController.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Web.Mvc

Namespace Controllers
    ''' ------------------------------------
    ''' Project  : Traning_nic_vb
    ''' Class  : ImportController
    ''' ------------------------------------ 
    ''' <summary>
    ''' Controller to control import Employee form csv file
    ''' </summary>
    ''' <history>
    '''  DatTB 25/06/2021 Created
    ''' </history>
    ''' ------------------------------------
    Public Class ImportController
        Inherits Controller

        ' GET: Import
        ''' ------------------------------------
        ''' <summary>
        ''' Funcion show view to do import file
        ''' </summary>
        ''' <returns></returns>
        ''' ------------------------------------
        <HttpGet>
        Function Index() As ActionResult
            If (Session(Constant.USERNAME) Is Nothing) Then
                Return RedirectToAction("../Login/Login")
            Else
                Return View()
            End If
        End Function
        ' Post: Import
        ''' ------------------------------------
        ''' <summary>
        ''' Funtion to directly import employee when click summit
        ''' </summary>
        ''' <param name="postFile">File send from client</param>
        ''' <returns></returns>
        ''' ------------------------------------
        <HttpPost>
        <Obsolete>
        Function ImportEmp(ByVal postFile As HttpPostedFileBase) As ActionResult
            Try
                If (Session(Constant.USERNAME) Is Nothing) Then
                    Return RedirectToAction("../Login/Login")
                Else
                    If (Not postFile Is Nothing) Then
                        If postFile.ContentLength > 0 Then
                            Dim path As String = IO.Path.Combine(Server.MapPath("~/file"),
                                    IO.Path.GetFileName(postFile.FileName))
                            postFile.SaveAs(path)
                            Dim lines = IO.File.ReadAllLines(path)
                            Dim tbl = New DataTable
                            Dim colCount = lines.First.Split(","c).Length
                            For i As Int32 = 1 To colCount
                                tbl.Columns.Add(New DataColumn("Column_" & i, GetType(String)))
                            Next
                            For Each line In lines
                                Dim objFields = From field In line.Split(","c)
                                                Select CType(field, Object)
                                Dim newRow = tbl.Rows.Add()
                                newRow.ItemArray = objFields.ToArray()
                            Next
                            If tbl.Rows.Count > 0 Then
                                Dim listEmp As List(Of EmployeeModel) = New List(Of EmployeeModel)
                                For Each row As DataRow In tbl.Rows

                                    Dim empModel As EmployeeModel = New EmployeeModel
                                    empModel.Fullname = row("Column_1")
                                    empModel.Email = row("Column_2")
                                    empModel.JobTitle = row("Column_3")
                                    empModel.Phone = row("Column_4")
                                    empModel.Address = row("Column_5")
                                    listEmp.Add(empModel)
                                Next
                                Dim stringValidateImport As String = String.Empty
                                stringValidateImport = ValidateEmpoyee(listEmp)
                                If Not String.IsNullOrEmpty(stringValidateImport) Then
                                    ViewData(Constant.MESSAGE) = stringValidateImport
                                Else
                                    For Each emp As EmployeeModel In listEmp
                                        Dim createEmp As CreateNewEmployeeModel = New CreateNewEmployeeModel
                                        createEmp.CreateNewEmployee(emp)
                                    Next
                                    ViewData(Constant.MESSAGE) = Constant.IMPORT_SUCESSED
                                End If
                            Else
                                ViewData(Constant.MESSAGE) = Constant.NOT_EXIST_EMP_IMPORT
                            End If
                            IO.File.Delete(path)
                        Else
                            ViewData(Constant.MESSAGE) = Constant.NOT_EXIST_EMP_IMPORT
                        End If
                    Else
                        ViewData(Constant.MESSAGE) = Constant.FILE_PROB
                    End If
                End If
            Catch ex As Exception
                Session.Add(Constant.ERRORS, Constant.IMPORT_FAILED & Constant.EXCEPTION_PROB)
                Return View(Constant.ERROR_VIEW)
            End Try
            Return View()
        End Function
        ''' ------------------------------------
        ''' <summary>
        ''' Function to check validate list employee from csv
        ''' </summary>
        ''' <param name="listEmp">list emplyee need to check before import</param>
        ''' <returns></returns>
        ''' ------------------------------------
        <Obsolete>
        Public Function ValidateEmpoyee(listEmp As List(Of EmployeeModel)) As String
            Dim index As Int32 = 1
            Dim errorString As String = String.Empty
            For Each emp As EmployeeModel In listEmp
                Dim email As String = String.Empty
                Dim phone As String = String.Empty
                Dim stringErrorEmp As String = Common.ValidateEmp(emp, email, phone)
                If Not String.IsNullOrEmpty(stringErrorEmp) Then
                    errorString = errorString & Constant.USER_VALIDATE & vbBack & index.ToString & vbBack & stringErrorEmp & vbNewLine
                End If
                index = index + 1
            Next
            Dim stringErrorEmail As String = CheckSimilarEmail(listEmp)
            Dim stringErrorPhone As String = CheckSimilarPhone(listEmp)
            If Not String.IsNullOrEmpty(stringErrorEmail) Then
                errorString &= stringErrorEmail
            End If
            If Not String.IsNullOrEmpty(stringErrorPhone) Then
                errorString &= stringErrorPhone
            End If
            Return errorString
        End Function
        ''' ------------------------------------
        ''' <summary>
        ''' Email check similar in import file
        ''' </summary>
        ''' <param name="listEmp">List employee from file</param>
        ''' <returns>message show the error</returns>
        ''' ------------------------------------
        Public Function CheckSimilarEmail(listEmp As List(Of EmployeeModel)) As String
            Dim mess As String = String.Empty
            Dim count = 0
            For i = 0 To listEmp.Count - 1
                For j = i + 1 To listEmp.Count - 2
                    If listEmp(i).Email.Equals(listEmp(j).Email) Then
                        count = count + 1
                    End If
                Next
            Next
            If count > 0 Then
                mess &= count & vbBack & Constant.SINILAR_EMAIL & vbNewLine
            End If
            Return mess
        End Function
        ''' ------------------------------------
        ''' <summary>
        ''' Phone check similar in import file
        ''' </summary>
        ''' <param name="listEmp">List employee from file</param>
        ''' <returns>message show the error</returns>
        ''' ------------------------------------
        Public Function CheckSimilarPhone(listEmp As List(Of EmployeeModel)) As String
            Dim mess As String = String.Empty
            Dim count = 0
            For i = 0 To listEmp.Count - 1
                For j = i + 1 To listEmp.Count - 2
                    If listEmp(i).Phone.Equals(listEmp(j).Phone) Then
                        count = count + 1
                    End If
                Next
            Next
            If count > 0 Then
                mess &= count & vbBack & Constant.SINILAR_PHONE & vbNewLine
            End If
            Return mess
        End Function
    End Class
End Namespace