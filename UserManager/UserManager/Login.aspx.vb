'-----------------------------------------------------------------------
' <copyright file="Login.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : Login
''' ------------------------------------ 
''' <summary>
''' Clas do the action in login page
''' </summary>
''' <history>
'''  DatTB 05/07/2021 Created
''' </history>
''' ------------------------------------
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session(Constant.USERNAME) Is Nothing Then
            Response.Redirect(Constant.LIST_USERS_URL, False)
        End If
    End Sub

    <Obsolete>
    Protected Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Try
            Dim name As String = Username.Text.Trim
            Dim pass As String = Password.Text.Trim
            pass = Common.EncryptPassword(pass)
            Dim user As UserModel = New UserModel
            user.Username = name
            user.PassWord = pass

            pass = Common.EncryptPassword(pass)
            Dim query As DBQuery = New DBQuery
            Dim resultCheck = query.VerifyLogin(user)
            If resultCheck Then
                Session(Constant.USERNAME) = name
                Message.Text = Constant.LOGIN_SUCCESSED
                Response.Redirect(Constant.LIST_USERS_URL, False)
            Else
                Message.Text = Constant.INVALID_LOGIN
            End If
        Catch ex As Exception
            Response.Redirect(Constant.ERROR_VIEW_URL)
        End Try
    End Sub
End Class