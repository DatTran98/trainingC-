'-----------------------------------------------------------------------
' <copyright file="DBQuery.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Data.SqlClient
''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : DBQuery
''' ------------------------------------ 
''' <summary>
''' DBQuery as a DAO layer to conect to DB and do actions
''' </summary>
''' <history>
'''  DatTB 05/07/2021 Created
''' </history>
''' ------------------------------------
Public Class DBQuery
    Dim con As SqlConnection = New SqlConnection
    Dim cmd As SqlCommand = New SqlCommand
    Dim dr As SqlDataReader
    Dim dataAdapter As SqlDataAdapter
    ''' ------------------------------------
    ''' <summary>
    ''' Method to set string connect to DB
    ''' </summary>
    ''' ------------------------------------
    Sub ConnectionString()
        con.ConnectionString = Constant.CONNECTION_STRING
    End Sub
    ''' ------------------------------------
    ''' <summary>
    ''' Conect DB and check Verify Login
    ''' </summary>
    ''' <param name="user">Account need verify as user</param>
    ''' <returns>True if corect, fail if not</returns>
    ''' ------------------------------------
    <Obsolete>
    Function VerifyLogin(user As UserModel) As Boolean
        Dim result As Boolean
        Try
            ConnectionString()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM [DBO].USERS WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD"
            cmd.Parameters.Add("@USERNAME", user.Username.ToString())
            cmd.Parameters.Add("@PASSWORD", user.PassWord.ToString())
            dr = cmd.ExecuteReader
            If dr.Read() Then
                result = True
            Else
                result = False
            End If

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
        Return result
    End Function
    ''' ------------------------------------
    ''' <summary>
    ''' Get List user with search value
    ''' </summary>
    ''' <param name="searchValue">The email of employee case of user email</param>
    ''' <returns>Datatable include list employee</returns>
    ''' ------------------------------------
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
                cmd.Parameters.Add("@EMAIL", String.Format("%{0}%", searchValue))
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
    ''' ------------------------------------
    ''' <summary>
    ''' Check Email exist
    ''' </summary>
    ''' <param name="email">Email need to chec</param>
    ''' <returns>True if exist, false if not exist</returns>
    ''' ------------------------------------
    <Obsolete>
    Function VerifyEmailExist(email As String) As Boolean
        Dim result As Boolean
        Try
            Dim sqlQuery As StringBuilder = New StringBuilder
            sqlQuery.Append("SELECT FULL_NAME FROM [DBO].EMPLOYEES WHERE EMAIL = @EMAIL")

            ConnectionString()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = sqlQuery.ToString()
            cmd.Parameters.Add("@EMAIL", email)
            dr = cmd.ExecuteReader()
            If dr.Read() Then
                result = True
            Else
                result = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
        Return result
    End Function

    ''' ------------------------------------
    ''' <summary>
    ''' Check Email exist
    ''' </summary>
    ''' <param name="phone">Phone need to chec</param>
    ''' <returns>True if exist, false if not exist</returns>
    ''' ------------------------------------
    <Obsolete>
    Function VerifyPhoneExist(phone As String) As Boolean
        Dim result As Boolean
        Try
            Dim sqlQuery As StringBuilder = New StringBuilder
            sqlQuery.Append("SELECT * FROM [DBO].EMPLOYEES WHERE PHONE = @PHONE")
            ConnectionString()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = sqlQuery.ToString()
            cmd.Parameters.Add("@PHONE", phone)
            dr = cmd.ExecuteReader()
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
    ''' ------------------------------------
    ''' <summary>
    ''' Update employee by email
    ''' </summary>
    ''' <param name="model">mEdel as infor employee </param>
    ''' <param name="email">Email employee want to update</param>
    ''' ------------------------------------
    <Obsolete>
    Function UpdateEmployee(model As EmployeeModel, email As String) As Boolean
        Dim res As Boolean
        Try
            Dim sqlQuery As StringBuilder = New StringBuilder
            sqlQuery.Append("UPDATE [dbo].[EMPLOYEES] ")
            sqlQuery.Append("SET FULL_NAME = @FULLNAME, ")
            If Not email.Equals(model.Email) Then
                sqlQuery.Append("EMAIL = @NEWEMAIL, ")
            End If
            sqlQuery.Append("JOB_TITLE = @JOBTITLE, ")
            sqlQuery.Append("PHONE = @PHONE, ")
            sqlQuery.Append("ADDRESS = @NEWADDRESS ")
            sqlQuery.Append("WHERE EMAIL = @OLDEMAIL ;")
            ConnectionString()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = sqlQuery.ToString
            cmd.Parameters.Add("@FULLNAME", model.Fullname)
            If Not email.Equals(model.Email) Then
                cmd.Parameters.Add("@NEWEMAIL", model.Email)
            End If
            cmd.Parameters.Add("@JOBTITLE", model.JobTitle)
            cmd.Parameters.Add("@PHONE", model.Phone)
            cmd.Parameters.Add("@NEWADDRESS", model.Address)
            cmd.Parameters.Add("@OLDEMAIL", email)
            Dim rowUpdate As Integer = cmd.ExecuteNonQuery()
            If rowUpdate > 0 Then
                res = True
            Else
                res = False
            End If
            Return res
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function
    ''' ------------------------------------
    ''' <summary>
    ''' Method to delete employee form list
    ''' </summary>
    ''' <param name="email">Email to match employee need to delete</param>
    ''' ------------------------------------
    <Obsolete>
    Function DeleteEmployee(email As String) As Boolean
        Dim res As Boolean
        Try
            Dim sqlQuery As StringBuilder = New StringBuilder
            sqlQuery.Append("DELETE FROM [DBO].EMPLOYEES ")
            sqlQuery.Append("WHERE EMAIL = @EMAIL")
            ConnectionString()
            con.Open()
            cmd = New SqlCommand(sqlQuery.ToString(), con)
            cmd.Parameters.Add("@EMAIL", email)
            Dim count As Integer = cmd.ExecuteNonQuery()
            If count > 0 Then
                res = True
            Else
                res = False
            End If
            Return res
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function
    ''' ------------------------------------
    ''' <summary>
    ''' Connect DB and create new employee
    ''' </summary>
    ''' <param name="model">model As a Employee</param>
    ''' ------------------------------------
    <Obsolete>
    Function CreateNewEmployee(model As EmployeeModel) As Boolean
        Dim res As Boolean
        Try
            Dim sqlQuery As StringBuilder = New StringBuilder()
            sqlQuery.Append("INSERT INTO [dbo].[EMPLOYEES]
           (FULL_NAME
           ,EMAIL
           ,JOB_TITLE
           ,PHONE
           ,ADDRESS) 
            VALUES
            (@FULLNAME
           ,@EMAIL
           ,@JOBTITLE
            ,@PHONE
           ,@ADDRESS)")
            ConnectionString()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = sqlQuery.ToString()
            cmd.Parameters.Add("@FULLNAME", model.Fullname)
            cmd.Parameters.Add("@EMAIL", model.Email)
            cmd.Parameters.Add("@PHONE", model.Phone)
            cmd.Parameters.Add("@JOBTITLE", model.JobTitle)
            cmd.Parameters.Add("@ADDRESS", model.Address)
            Dim count As Integer = cmd.ExecuteNonQuery()
            If count > 0 Then
                res = True
            Else
                res = False
            End If
            Return res
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Function
End Class
