'-----------------------------------------------------------------------
' <copyright file="LoginModel.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Data.SqlClient
''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : LoginModel
''' ------------------------------------ 
''' <summary>
''' DAO to conect to DB and Login action
''' </summary>
''' <history>
'''  DatTB 25/06/2021 Created
''' </history>
''' ------------------------------------
Public Class LoginModel
    Dim con As SqlConnection = New SqlConnection
    Dim com As SqlCommand = New SqlCommand
    Dim dr As SqlDataReader
    ''' <summary>
    ''' Method to set string connect to DB
    ''' </summary>
    Sub ConnectionString()
        con.ConnectionString = Constant.CONNECTION_STRING
    End Sub
    ''' <summary>
    ''' Conect DB and check Verify Login
    ''' </summary>
    ''' <param name="user">Account need verify as user</param>
    ''' <returns>True if corect, fail if not</returns>
    <Obsolete>
    Function Verify(user As UserModel) As Boolean
        Dim result As Boolean
        Try
            ConnectionString()
            con.Open()
            com.Connection = con
            com.CommandText = "SELECT * FROM [DBO].USERS WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD"
            com.Parameters.Add("@USERNAME", user.Username.ToString())
            com.Parameters.Add("@PASSWORD", user.PassWord.ToString())
            dr = com.ExecuteReader()
            If dr.Read() Then
                con.Close()
                result = True
            Else
                con.Close()
                result = False
            End If

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
        Return result
    End Function
End Class
