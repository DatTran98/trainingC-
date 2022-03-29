'-----------------------------------------------------------------------
' <copyright file="DeleteEmpModel.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Data.SqlClient
''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : DeleteEmpModel
''' ------------------------------------ 
''' <summary>
''' DAO to conect to DB and Delete Employee action
''' </summary>
''' <history>
'''  DatTB 25/06/2021 Created
''' </history>
''' ------------------------------------
Public Class DeleteEmpModel
    Dim con As SqlConnection = New SqlConnection
    Dim cmd As SqlCommand = New SqlCommand
    ''' <summary>
    ''' Method to set string connect to DB
    ''' </summary>
    Sub ConnectionString()
        con.ConnectionString = Constant.CONNECTION_STRING
    End Sub
    ''' <summary>
    ''' Method to delete employee form list
    ''' </summary>
    ''' <param name="email">Email to match employee need to delete</param>
    <Obsolete>
    Sub DeleteEmployee(email As String)

        Try
            Dim sqlQuery As StringBuilder = New StringBuilder
            sqlQuery.Append("DELETE FROM [DBO].EMPLOYEES ")
            sqlQuery.Append("WHERE EMAIL = @EMAIL")
            ConnectionString()
            con.Open()
            cmd = New SqlCommand(sqlQuery.ToString(), con)
            cmd.Parameters.Add("@EMAIL", email)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Sub
End Class
