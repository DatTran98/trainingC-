'-----------------------------------------------------------------------
' <copyright file="LoginController.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Web.Mvc
Imports System.Object
Imports ManageUser.UserModel
Imports ManageUser.LoginModel
Imports ManageUser.Common
Imports System.Data.SqlClient

Namespace Controllers
    ''' ------------------------------------
    ''' Project  : Traning_nic_vb
    ''' Class  : LoginController
    ''' ------------------------------------ 
    ''' <summary>
    ''' Controller to control login permision task
    ''' </summary>
    ''' <history>
    '''  DatTB 25/06/2021 Created
    ''' </history>
    ''' ------------------------------------
    Public Class LoginController
        Inherits Controller
        ' GET: Login
        ''' ------------------------------------
        ''' <summary>
        ''' Get method to show login view
        ''' </summary>
        ''' <returns>The result as view</returns>
        ''' ------------------------------------
        Function Login() As ActionResult
            ViewBag.WelcomeString = Constant.WELCOME_LOGIN
            Return View()
        End Function
        ' POST: Verify
        ''' ------------------------------------
        ''' <summary>
        ''' Post method to verify login request
        ''' </summary>
        ''' <returns>The result login</returns>
        ''' ------------------------------------
        <Obsolete>
        Function Verify() As ActionResult
            Dim user As New UserModel()
            user.Username = Request.Form(Constant.USERNAME_FILL)
            user.PassWord = Request.Form(Constant.PASSWORD_FILL)
            Try
                If Not user.Username Is Nothing And Not user.PassWord Is Nothing Then
                    Dim passEncript As String = Common.EncryptPassword(user.PassWord)
                    user.PassWord = passEncript

                    Dim loginModel As LoginModel = New LoginModel

                    Dim res As Boolean = loginModel.Verify(user)

                    If res Then
                        Session.Add(Constant.USERNAME, user.Username.ToString())
                        Return RedirectToAction(Constant.LIST_USERS_URL)
                    Else

                        Session.Add(Constant.MESSAGE, Constant.INVALID_LOGIN)
                        Return View(Constant.lOGIN_VIEW)
                    End If
                Else
                    Session.Add(Constant.MESSAGE, Constant.EMPTYFILL_LOGIN)
                    Return View(Constant.lOGIN_VIEW)
                End If

            Catch ex As Exception
                Session.Add(Constant.ERRORS, Constant.PROBLEM_DB_CONNECT)
                Return View(Constant.ERROR_VIEW)
            End Try
        End Function
    End Class
End Namespace