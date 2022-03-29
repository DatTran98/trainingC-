'-----------------------------------------------------------------------
' <copyright file="DeleteEmployeeController.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Web.Mvc

Namespace Controllers
    ''' ------------------------------------
    ''' Project  : Traning_nic_vb
    ''' Class  : DeleteEmployeeController
    ''' ------------------------------------ 
    ''' <summary>
    ''' Controller to control deleting permision task
    ''' </summary>
    ''' <history>
    '''  DatTB 25/06/2021 Created
    ''' </history>
    ''' ------------------------------------

    Public Class DeleteEmployeeController
        Inherits Controller
        ''' ------------------------------------
        ''' <summary>
        ''' Funtion to call Model do delete Employee
        ''' </summary>
        ''' <returns></returns>
        ''' ------------------------------------
        <Obsolete>
        Function DeleteEmployee() As ActionResult
            Try
                If (Session(Constant.USERNAME) Is Nothing) Then
                    Return RedirectToAction("../Login/Login")
                Else
                    ViewData(Constant.MESSAGE) = String.Empty
                    Dim email As String = Request.QueryString(Constant.VALUE)
                    Dim emPloyeeDetal As EmloyeeDetailEdit = New EmloyeeDetailEdit()
                    Dim empModel As EmployeeModel = New EmployeeModel()
                    empModel = emPloyeeDetal.GetDetailEmployeeByEmail(email)
                    If (String.IsNullOrEmpty(empModel.Fullname)) Then
                        ViewData(Constant.MESSAGE) = Constant.NOT_EXIST_EMP
                    Else
                        Dim delModel As DeleteEmpModel = New DeleteEmpModel()
                        delModel.DeleteEmployee(email)
                        ViewData(Constant.MESSAGE) = Constant.DELETE_SUCCESS
                    End If
                End If
            Catch ex As Exception
                Session.Add(Constant.ERRORS, Constant.EXCEPTION_PROB)
                Return View(Constant.ERROR_VIEW)
            End Try
            Return RedirectToAction(Constant.LIST_USERS_URL)
        End Function
    End Class
End Namespace