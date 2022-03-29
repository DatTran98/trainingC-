'-----------------------------------------------------------------------
' <copyright file="ListUserModel.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Data.SqlClient
''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : ListUserModel
''' ------------------------------------ 
''' <summary>
''' DAO to conect to DB and Getlist Employee action
''' </summary>
''' <history>
'''  DatTB 25/06/2021 Created
''' </history>
''' ------------------------------------
Public Class ListUserModel
    Dim con As SqlConnection = New SqlConnection
    Dim cmd As SqlCommand
    Dim dataAdapter As SqlDataAdapter
    ''' <summary>
    ''' Method to set string connect to DB
    ''' </summary>
    Sub ConnectionString()
        con.ConnectionString = Constant.CONNECTION_STRING
    End Sub
    ''' <summary>
    ''' Get List user with search value
    ''' </summary>
    ''' <param name="searchValue">The email of employee case of user email</param>
    ''' <returns>Datatable include list employee</returns>
    <Obsolete>
    Function GetListUser(searchValue As String) As DataTable
        Dim ds As DataTable = New DataTable
        Try
            Dim sqlQuery As StringBuilder = New StringBuilder
            sqlQuery.Append("SELECT * FROM [DBO].EMPLOYEES ")
            If Not String.Empty.Equals(searchValue) Then
                sqlQuery.Append("WHERE EMAIL LIKE @EMAIL")
            End If
            ConnectionString()
            con.Open()
            cmd = New SqlCommand(sqlQuery.ToString(), con)
            If Not String.Empty.Equals(searchValue) Then
                cmd.Parameters.Add("@EMAIL", "%" & searchValue & "%")
            End If
            dataAdapter = New SqlDataAdapter(cmd)
            dataAdapter.Fill(ds)
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
        Return ds
    End Function
End Class
