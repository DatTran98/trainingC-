'-----------------------------------------------------------------------
' <copyright file="AddEmployeeController.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Web.Mvc

Namespace Controllers
    '''' ------------------------------------
    ''' Project  : Traning_nic_vb
    ''' Class  : AddEmployeeController
    ''' ------------------------------------ 
    ''' <summary>
    ''' Controller to control Create permision task
    ''' </summary>
    ''' <history>
    '''  DatTB 25/06/2021 Created
    ''' </history>
    ''' ------------------------------------
    Public Class AddEmployeeController
        Inherits Controller
        ''' ------------------------------------
        ''' <summary>
        ''' Get method to show view add employee
        ''' </summary>
        ''' <returns>The result</returns>
        ''' ------------------------------------
        <HttpGet>
        Function CreateEmployee() As ActionResult
            If (Session(Constant.USERNAME) Is Nothing) Then
                Return RedirectToAction("../Login/Login")
            Else
                Dim employee As EmployeeModel = New EmployeeModel
                Dim listJob = Common.GetListJobTitle()
                listJob.AsEnumerable()
                ViewData("List") = New SelectList(listJob, "Value", "Text")
                Return View(employee)
            End If

        End Function
        ''' ------------------------------------
        ''' <summary>
        ''' Post method to control Add new employee
        ''' </summary>
        ''' <returns></returns>
        '''  ------------------------------------
        <HttpPost>
        <Obsolete>
        Function AddEmployee() As ActionResult
            'Do validate
            Try
                Dim empAdd As EmployeeModel = New EmployeeModel()
                If (Session(Constant.USERNAME) Is Nothing) Then
                    Return RedirectToAction("../Login/Login")
                Else
                    If ModelState.IsValid Then
                        Dim listJob = Common.GetListJobTitle()
                        listJob.AsEnumerable()
                        ViewData("List") = New SelectList(listJob, "Value", "Text")
                        Dim fullname = Request.Form(Constant.FULLNAME_VALUE_FILL)
                        Dim email = Request.Form(Constant.EMAIL_VALUE_FILL)
                        Dim phone = Request.Form(Constant.PHONE_VALUE_FILL)
                        Dim jobTitle = Request.Form(Constant.JOBTITLE_VALUE_FILL)
                        Dim address = Request.Form(Constant.ADDRESS_VALUE_FILL)
                        Dim oldEmail = String.Empty
                        Dim oldPhone = String.Empty
                        Dim empId = String.Empty

                        empAdd.Fullname = fullname
                        empAdd.Email = email
                        empAdd.Phone = phone
                        empAdd.JobTitle = jobTitle
                        empAdd.Address = address
                        'Check input
                        Dim errorString As String = Common.ValidateEmp(empAdd, oldEmail, oldPhone)
                        'Create new Emp
                        If String.Empty.Equals(errorString) Then
                            Dim addEmp As CreateNewEmployeeModel = New CreateNewEmployeeModel
                            addEmp.CreateNewEmployee(empAdd)
                            empAdd = New EmployeeModel()
                        Else
                            ViewData(Constant.MESSAGE) = errorString
                            Return View("CreateEmployee", empAdd)
                        End If
                    End If
                End If

                ViewData(Constant.MESSAGE) = Constant.SUCCESS_CREATING
                Return View("CreateEmployee", empAdd)
            Catch ex As Exception
                Session.Add(Constant.ERRORS, Constant.PROBLEM_DB_CONNECT)
                Return View(Constant.ERROR_VIEW)
            End Try
        End Function
    End Class
End Namespace