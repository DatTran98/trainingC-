'-----------------------------------------------------------------------
' <copyright file="CreateNewEmployeeModel.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.Data.SqlClient
''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : Public Class CreateNewEmployeeModel
''' ------------------------------------ 
''' <summary>
''' Class model to connect DB and add new employee
''' </summary>
''' <history>
'''  DatTB 25/06/2021 Created
''' </history>
''' ------------------------------------
Public Class CreateNewEmployeeModel
    Dim con As SqlConnection = New SqlConnection
    Dim cmd As SqlCommand = New SqlCommand
    Dim sqlRead As SqlDataReader
    ''' <summary>
    ''' Set connectionString 
    ''' </summary>
    Sub ConnectionString()
        con.ConnectionString = Constant.CONNECTION_STRING
    End Sub
    ''' <summary>
    ''' Connect DB and create new employee
    ''' </summary>
    ''' <param name="model">model As a Employee</param>
    <Obsolete>
    Sub CreateNewEmployee(model As EmployeeModel)
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
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
        End Try
    End Sub
End Class
