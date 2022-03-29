'-----------------------------------------------------------------------
' <copyright file="ListUsersController.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Web.Mvc

Namespace Controllers
    ''' ------------------------------------
    ''' Project  : Traning_nic_vb
    ''' Class  : ListUsersController
    ''' ------------------------------------ 
    ''' <summary>
    ''' Controller to control Getlist employee permision task
    ''' </summary>
    ''' <history>
    '''  DatTB 25/06/2021 Created
    ''' </history>
    ''' ------------------------------------
    Public Class ListUsersController
        Inherits Controller

        ' GET: ListUsers
        ''' ------------------------------------
        ''' <summary>
        ''' Get method to get all user form DB to show view
        ''' </summary>
        ''' <returns></returns>
        ''' ------------------------------------
        <Obsolete>
        Function GetListUsers() As ActionResult
            Dim listUsers As List(Of EmployeeModel) = New List(Of EmployeeModel)
            Try
                If (Session(Constant.USERNAME) Is Nothing) Then
                    Return RedirectToAction("../Login/Login")
                Else
                    Session.Remove(Constant.MESSAGE)
                    Dim searchValue = Request.Form(Constant.SEARCH_VALUE_FILL)
                    If searchValue Is Nothing Then
                        searchValue = String.Empty
                    Else
                        searchValue = searchValue.ToString()
                    End If
                    Console.WriteLine(searchValue)
                    Dim listUserModel As ListUserModel = New ListUserModel
                    Dim dataUsers As DataTable = New DataTable
                    dataUsers = listUserModel.GetListUser(searchValue)
                    For Each row In dataUsers.Rows
                        Dim emp As EmployeeModel = New EmployeeModel
                        emp.Fullname = row("FULL_NAME")
                        emp.Email = row("EMAIL")
                        emp.JobTitle = row("JOB_TITLE")
                        emp.Phone = row("PHONE")
                        emp.Address = row("ADDRESS")
                        listUsers.Add(emp)
                    Next
                    If listUsers.Count < 1 Then
                        Session.Add(Constant.MESSAGE, Constant.NO_DATA_FIT)
                    End If
                End If
            Catch ex As Exception
                Session.Add(Constant.ERRORS, Constant.PROBLEM_DB_CONNECT)
                Return View(Constant.ERROR_VIEW)
            End Try
            Return View(listUsers)
        End Function
    End Class
End Namespace