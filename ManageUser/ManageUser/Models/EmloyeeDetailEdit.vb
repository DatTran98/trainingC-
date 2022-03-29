'-----------------------------------------------------------------------
' <copyright file="EmloyeeDetailEdit.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Data.SqlClient

''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : EmloyeeDetailEdit
''' ------------------------------------ 
''' <summary>
''' DAO to conect to DB and Edit Employee action
''' </summary>
''' <history>
'''  DatTB 25/06/2021 Created
''' </history>
''' ------------------------------------
Public Class EmloyeeDetailEdit
    Dim con As SqlConnection = New SqlConnection
    Dim cmd As SqlCommand = New SqlCommand
    Dim sqlRead As SqlDataReader
    ''' <summary>
    ''' Method to set string connect to DB
    ''' </summary>
    Sub ConnectionString()
        con.ConnectionString = Constant.CONNECTION_STRING
    End Sub
    ''' <summary>
    ''' Get Detail Data employee By email
    ''' </summary>
    ''' <param name="searchValue">Email'Employee want to search</param>
    ''' <returns>The Employee</returns>
    <Obsolete>
    Function GetDetailEmployeeByEmail(searchValue As String) As EmployeeModel
        Dim emp As EmployeeModel = New EmployeeModel()

        Try
            Dim sqlQuery As StringBuilder = New StringBuilder
            sqlQuery.Append("SELECT * FROM [DBO].EMPLOYEES ")
            If Not String.Empty.Equals(searchValue) Then
                sqlQuery.Append("WHERE EMAIL = @EMAIL")
            End If
            ConnectionString()
            con.Open()
            cmd = New SqlCommand(sqlQuery.ToString(), con)
            If Not String.Empty.Equals(searchValue) Then
                cmd.Parameters.Add("@EMAIL", searchValue)
            End If
            sqlRead = cmd.ExecuteReader()
            Do While sqlRead.Read()
                emp.Fullname = sqlRead.GetString(0)
                emp.Email = sqlRead.GetString(1)
                emp.JobTitle = sqlRead.GetString(2)
                emp.Phone = sqlRead.GetString(3)
                emp.Address = sqlRead.GetString(4)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
        Return emp
    End Function
    ''' <summary>
    ''' Check Email exist
    ''' </summary>
    ''' <param name="email">Email need to chec</param>
    ''' <returns>True if exist, false if not exist</returns>
    <Obsolete>
    Function VerifyEmailExist(email As String) As Boolean
        Dim result As Boolean
        Try
            Dim sqlQuery As StringBuilder = New StringBuilder
            sqlQuery.Append("SELECT * FROM [DBO].EMPLOYEES WHERE EMAIL = @EMAIL")

            ConnectionString()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = sqlQuery.ToString()
            cmd.Parameters.Add("@EMAIL", email)
            sqlRead = cmd.ExecuteReader()
            If sqlRead.Read() Then
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

    ''' <summary>
    ''' Check Email exist
    ''' </summary>
    ''' <param name="phone">Phone need to chec</param>
    ''' <returns>True if exist, false if not exist</returns>
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
            sqlRead = cmd.ExecuteReader()
            If sqlRead.Read() Then
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
    ''' <summary>
    ''' Update employee by email
    ''' </summary>
    ''' <param name="model">mEdel as infor employee </param>
    ''' <param name="email">Email employee want to update</param>
    <Obsolete>
    Sub UpdateNewEmployee(model As EmployeeModel, email As String)
        Try
            ConnectionString()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "UPDATE [dbo].[EMPLOYEES]
                               SET FULL_NAME =@FULLNAME, EMAIL = @EMAIL, PHONE = @PHONE, JOB_TITLE =@JOBTITLE, ADDRESS = @ADDRESS WHERE EMAIL = @OLDEMAIL;"
            cmd.Parameters.Add("@FULLNAME", model.Fullname)
            cmd.Parameters.Add("@EMAIL", model.Email)
            cmd.Parameters.Add("@PHONE", model.Phone)
            cmd.Parameters.Add("@JOBTITLE", model.JobTitle)
            cmd.Parameters.Add("@ADDRESS", model.Address)
            cmd.Parameters.Add("@OLDEMAIL", email)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Sub
End Class
