'-----------------------------------------------------------------------
' <copyright file="EditEmployeeController.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Web.Mvc

Namespace Controllers
    ''' ------------------------------------
    ''' Project  : Traning_nic_vb
    ''' Class  : EditEmployeeController
    ''' ------------------------------------ 
    ''' <summary>
    ''' Controller to control edit permision task
    ''' </summary>
    ''' <history>
    '''  DatTB 25/06/2021 Created
    ''' </history>
    ''' ------------------------------------
    Public Class EditEmployeeController
        Inherits Controller
        ''' ------------------------------------
        ''' <summary>
        ''' Get detail user to show view to edit
        ''' </summary>
        ''' <returns>The result as view</returns>
        ''' ------------------------------------
        <HttpGet>
        <Obsolete>
        Function GetUserEdit() As ActionResult
            Dim empDetail As EmployeeModel = New EmployeeModel()

            Try
                If (Session(Constant.USERNAME) Is Nothing) Then
                    Return RedirectToAction("../Login/Login")
                Else
                    ViewData(Constant.MESSAGE) = String.Empty
                    Dim listJob = Common.GetListJobTitle()
                    listJob.AsEnumerable()
                    ViewData("List") = New SelectList(listJob, "Value", "Text")
                    Dim email As String = Request.QueryString(Constant.VALUE)
                    Dim emPloyeeDetal As EmloyeeDetailEdit = New EmloyeeDetailEdit()
                    empDetail = emPloyeeDetal.GetDetailEmployeeByEmail(email)
                    If (String.IsNullOrEmpty(empDetail.Fullname)) Then
                        ViewData(Constant.MESSAGE) = Constant.NOT_EXIST_EMP
                        empDetail = New EmployeeModel
                    End If
                    Session(Constant.EMAIL) = email
                    Session(Constant.PHONE) = empDetail.Phone
                End If
            Catch ex As Exception
                Session.Add(Constant.ERRORS, Constant.PROBLEM_DB_CONNECT)
                Return View(Constant.ERROR_VIEW)
            End Try
            Return View(empDetail)
        End Function
        ''' ------------------------------------
        ''' <summary>
        ''' Function To control update info employee
        ''' </summary>
        ''' <returns>The result as view</returns>
        ''' ------------------------------------
        <HttpPost>
        <Obsolete>
        Function EditEmployee() As ActionResult
            Try
                If (Session(Constant.USERNAME) Is Nothing) Then
                    Return RedirectToAction("../Login/Login")
                Else
                    Dim listJob = Common.GetListJobTitle()
                    listJob.AsEnumerable()
                    ViewData("List") = New SelectList(listJob, "Value", "Text")
                    Dim fullname = Request.Form(Constant.FULLNAME_VALUE_FILL)
                    Dim email = Request.Form(Constant.EMAIL_VALUE_FILL)
                    Dim phone = Request.Form(Constant.PHONE_VALUE_FILL)
                    Dim jobTitle = Request.Form(Constant.JOBTITLE_VALUE_FILL)
                    Dim address = Request.Form(Constant.ADDRESS_VALUE_FILL)
                    Dim oldEmail As String = Session(Constant.EMAIL)
                    Dim oldPhone As String = Session(Constant.PHONE)
                    Dim empEdit As EmployeeModel = New EmployeeModel()
                    empEdit.Fullname = fullname
                    empEdit.Email = email
                    empEdit.Phone = phone
                    empEdit.JobTitle = jobTitle
                    empEdit.Address = address
                    Dim errorString As String = Common.ValidateEmp(empEdit, oldEmail, oldPhone)
                    Dim employeeDetailEdit As EmloyeeDetailEdit = New EmloyeeDetailEdit()
                    If String.Empty.Equals(errorString) Then
                        employeeDetailEdit.UpdateNewEmployee(empEdit, oldEmail)
                        ViewData(Constant.MESSAGE) = Constant.UPDATE_SUCCESS
                    Else
                        ViewData(Constant.MESSAGE) = errorString
                        Return View("GetUserEdit", empEdit)
                    End If
                End If
            Catch ex As Exception
                Session.Add(Constant.ERRORS, Constant.EXCEPTION_PROB)
                Return View(Constant.ERROR_VIEW)
            End Try
            Return View()
        End Function
    End Class
End Namespace