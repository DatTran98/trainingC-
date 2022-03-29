'-----------------------------------------------------------------------
' <copyright file="ListUsers.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : ListUsers
''' ------------------------------------ 
''' <summary>
''' Clas do the action in ListUsers page
''' </summary>
''' <history>
'''  DatTB 05/07/2021 Created
''' </history>
''' ------------------------------------
Public Class ListUsers
    Inherits System.Web.UI.Page
    Dim dtEmp As DataTable = New DataTable
    Dim userBin As Boolean = False
    '''  ------------------------------------
    '''  <summary>
    ''' Load the begin page with data
    ''' </summary>
    ''' <param name="sender">Object sender</param>
    ''' <param name="e">Event</param>
    '''  ------------------------------------
    <Obsolete>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session(Constant.USERNAME) Is Nothing Then
            Response.Redirect(Constant.LOGIN_VIEW_URL)
        End If
    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        If Not userBin Then
            For Each row As GridViewRow In GridViewEmployees.Rows

                If row.RowType = DataControlRowType.DataRow AndAlso row.RowState.HasFlag(DataControlRowState.Edit) = False Then
                    row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GridViewEmployees, "Edit$" & row.DataItemIndex, True)
                End If
            Next
            MyBase.Render(writer)
            userBin = True
        End If
    End Sub
    ''' ------------------------------------
    ''' <summary>
    ''' Handles the PreRender event of the Page control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    ''' ------------------------------------
    <Obsolete>
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Not userBin Then
            LoadData()
        End If

    End Sub
    '''  ------------------------------------
    '''  <summary>
    ''' Load Data to list user page
    ''' </summary>
    '''  ------------------------------------
    <Obsolete>
    Private Sub LoadData()
        Try
            Dim valueSearch As String = SearchValue.Text.Trim
            If String.IsNullOrEmpty(valueSearch) Then
                valueSearch = String.Empty
            End If

            Dim query As DBQuery = New DBQuery


            dtEmp = query.GetListUser(valueSearch)
            If dtEmp.Rows.Count > 0 Then
                GridViewEmployees.DataSource = dtEmp
                GridViewEmployees.DataBind()
            Else
                GridViewEmployees.DataBind()
                Message.Text = Constant.NO_DATA_FIT
            End If
        Catch ex As Exception
            Response.Redirect(Constant.ERROR_VIEW_URL)
        End Try
    End Sub
    '''  ------------------------------------
    '''  <summary>
    '''  Handles the RowCancelingEdit event of the GridViewUser control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    '''  ------------------------------------
    Protected Sub GridViewEmployees_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles GridViewEmployees.RowEditing
        Message.Text = String.Empty
        GridViewEmployees.EditIndex = e.NewEditIndex
    End Sub
    '''  ------------------------------------
    '''  <summary>
    ''' Handles the RowCancelingEdit event of the GridViewUser control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    '''  ------------------------------------
    Protected Sub GridViewEmployees_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs) Handles GridViewEmployees.RowCancelingEdit
        Message.Text = String.Empty
        GridViewEmployees.EditIndex = -1

    End Sub
    '''  ------------------------------------
    '''  <summary>
    ''' Handles the RowUpdating event of the GridViewUser control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    '''  ------------------------------------
    <Obsolete>
    Protected Sub GridViewEmployees_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs) Handles GridViewEmployees.RowUpdating
        Try
            Message.Text = String.Empty
            Dim keyEmail As String = GridViewEmployees.DataKeys(e.RowIndex).Value.ToString()
            Dim drop As DropDownList = CType(GridViewEmployees.Rows(e.RowIndex).FindControl("EditJobTitle"), DropDownList)
            Dim textPhone As TextBox = CType(GridViewEmployees.Rows(e.RowIndex).FindControl("PhoneEdit"), TextBox)
            Dim textNameEdit As TextBox = CType(GridViewEmployees.Rows(e.RowIndex).FindControl("NameEdit"), TextBox)

            Dim row As GridViewRow = GridViewEmployees.Rows(e.RowIndex)

            Dim textEmail As TextBox = row.Cells(2).Controls(0)
            Dim textAddress As TextBox = row.Cells(5).Controls(0)
            Dim oldPhone As TextBox = row.Cells(6).Controls(0)
            Dim textName As String = textNameEdit.Text
            Dim oldPhonetring As String = oldPhone.Text

            Dim emp As EmployeeModel = New EmployeeModel
            emp.Fullname = textName
            emp.Email = textEmail.Text
            emp.Phone = textPhone.Text
            emp.JobTitle = drop.SelectedValue.Trim
            emp.Address = textAddress.Text

            Dim errString As String = Common.ValidateEmp(emp, keyEmail, oldPhonetring)

            If String.IsNullOrEmpty(errString) Then
                Dim queryDB As DBQuery = New DBQuery
                If queryDB.VerifyEmailExist(keyEmail) Then
                    Dim resUpate As Boolean = queryDB.UpdateEmployee(emp, keyEmail)
                    If resUpate Then
                        Message.Text = Constant.UPDATE_SUCCESS
                        GridViewEmployees.EditIndex = -1
                    Else
                        Message.Text = Constant.UPDATE__FAILED
                    End If
                Else
                    Message.Text = Constant.NOT_EXIST_EMP
                End If
            Else
                Message.Text = errString
            End If

        Catch ex As Exception
            Response.Redirect(Constant.ERROR_VIEW_URL)
        End Try
    End Sub
    '''  ------------------------------------
    '''  <summary>
    ''' Handles the RowDeleting event of the GridViewUser control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    ''' ------------------------------------
    <Obsolete>
    Protected Sub GridViewEmployees_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridViewEmployees.RowDeleting
        Try
            Message.Text = String.Empty
            Dim keyEmail As String = GridViewEmployees.DataKeys(e.RowIndex).Value.ToString()
            'Dim row As GridViewRow = GridViewEmployees.Rows(e.RowIndex)
            'Dim textEmail As String = row.Cells(2).Text
            Dim query As DBQuery = New DBQuery
            If query.VerifyEmailExist(keyEmail) Then
                Dim res = query.DeleteEmployee(keyEmail)
                If res Then
                    Message.Text = Constant.DELETE_SUCCESS
                Else
                    Message.Text = Constant.DELETE_FAILED
                End If
            Else
                Message.Text = Constant.NOT_EXIST_EMP
            End If
        Catch ex As Exception
            Response.Redirect(Constant.ERROR_VIEW_URL)
        End Try
    End Sub
    '''  ------------------------------------
    '''  <summary>
    ''' Handles the Page Index changes event of the GridViewUser control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    ''' ------------------------------------
    Protected Sub Grid_PageIndexChanged(sender As Object, e As GridViewPageEventArgs) Handles GridViewEmployees.PageIndexChanging
        Message.Text = String.Empty
        GridViewEmployees.EditIndex = -1
        GridViewEmployees.PageIndex = e.NewPageIndex
        GridViewEmployees.DataBind()
    End Sub
    '''  ------------------------------------
    '''  <summary>
    ''' Handles the Button Add New Employee event of the GridViewUser control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The instance containing the event data.</param>
    ''' ------------------------------------
    <Obsolete>
    Protected Sub AddButton_Onclick(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Try
            Dim textName As String = NewFullname.Text.Trim
            Dim textEmail As String = NewEmail.Text.Trim
            Dim textJob As String = NewJob.SelectedValue.Trim
            Dim textPhone As String = NewPhone.Text.Trim
            Dim textAddress As String = NewAddress.Text.Trim
            Dim oldEmail As String = String.Empty
            Dim oldPhone As String = String.Empty

            Dim emp As EmployeeModel = New EmployeeModel
            emp.Fullname = textName
            emp.Email = textEmail
            emp.JobTitle = textJob
            emp.Phone = textPhone
            emp.Address = textAddress

            ' Check validate 
            Dim errString As String = Common.ValidateEmp(emp, oldEmail, oldPhone)
            If String.IsNullOrEmpty(errString) Then
                Dim query As DBQuery = New DBQuery
                Dim res As Boolean = query.CreateNewEmployee(emp)
                If res Then
                    DisplayEmptyTextBox()
                    Message.Text = Constant.ADD_SUCCEED
                Else
                    Message.Text = Constant.ADD_FAIL
                End If
            Else
                MessageAdd.Text = errString
                KeepPopUpShowing()
            End If

        Catch ex As Exception
            Response.Redirect(Constant.ERROR_VIEW_URL)
        End Try

    End Sub
    '''  ------------------------------------
    '''  <summary>
    ''' Handles the Button Search event of the GridViewUser control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The instance containing the event data.</param>
    ''' ------------------------------------
    <Obsolete>
    Protected Sub SearchButton_Onclick(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            Message.Text = String.Empty
            LoadData()
        Catch ex As Exception
            Response.Redirect(Constant.ERROR_VIEW_URL)
        End Try

    End Sub
    '''  ------------------------------------
    '''  <summary>
    ''' Handles the Button Import Employees event of the control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The instance containing the event data.</param>
    ''' ------------------------------------

    <Obsolete>
    Protected Sub ImportButton_Onclick(sender As Object, e As EventArgs) Handles BtnImport.Click
        Try
            Message.Text = String.Empty
            If (ImportFile.HasFile) Then
                Dim path As String = IO.Path.Combine(Server.MapPath("~/file"),
                                IO.Path.GetFileName(ImportFile.FileName))
                ImportFile.SaveAs(path)

                Dim lines = IO.File.ReadAllLines(path)
                Dim tbl = New DataTable
                Dim colCount = lines.First.Split(","c).Length
                For i As Int32 = 1 To colCount
                    tbl.Columns.Add(New DataColumn("Column_" & i, GetType(String)))
                Next
                For Each line In lines
                    Dim objFields = From field In line.Split(","c)
                                    Select CType(field, Object)
                    Dim newRow = tbl.Rows.Add()
                    newRow.ItemArray = objFields.ToArray()
                Next
                If tbl.Rows.Count > 0 Then
                    Dim listEmp As List(Of EmployeeModel) = New List(Of EmployeeModel)
                    For Each row As DataRow In tbl.Rows

                        Dim empModel As EmployeeModel = New EmployeeModel
                        empModel.Fullname = row("Column_1")
                        empModel.Email = row("Column_2")
                        empModel.JobTitle = row("Column_3")
                        empModel.Phone = row("Column_4")
                        empModel.Address = row("Column_5")
                        listEmp.Add(empModel)
                    Next
                    Dim stringValidateImport As String = String.Empty
                    stringValidateImport = ValidateEmpoyee(listEmp)
                    If Not String.IsNullOrEmpty(stringValidateImport) Then
                        Message.Text = stringValidateImport
                    Else
                        For Each emp As EmployeeModel In listEmp
                            Dim query As DBQuery = New DBQuery
                            query.CreateNewEmployee(emp)
                        Next
                        Message.Text = Constant.IMPORT_SUCESSED
                    End If
                Else
                    Message.Text = Constant.NOT_EXIST_EMP_IMPORT
                End If
                File.Delete(path)
            Else
                Message.Text = Constant.FILE_PROB
            End If
        Catch ex As Exception
            Message.Text = Constant.FILE_PROB

        End Try
    End Sub
    ''' ------------------------------------
    ''' <summary>
    ''' Handles the Button Export Employees event of the control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The instance containing the event data.</param>
    ''' ------------------------------------
    <Obsolete>
    Protected Sub ExportButton_Onclick(sender As Object, e As EventArgs) Handles BtnExport.Click
        Try
            Dim messageString As String = String.Empty
            Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            Dim fileName As String = "ExportEmpoyee.csv"
            Dim des = path & "\Downloads\" & fileName

            If (Not System.IO.Directory.Exists(path)) Then
                System.IO.Directory.CreateDirectory(des)
            End If
            Dim query As DBQuery = New DBQuery
            Dim dt As DataTable = New DataTable
            dt = query.GetListUser(String.Empty)
            If dt.Rows.Count <= 0 Then
                messageString = Constant.NO_DATA_FIT
                Message.Text = messageString
            Else
                Dim resWriteCSV = WriteToCSV(dt, des)
                If resWriteCSV Then
                    messageString = Constant.EXPORT_SUCESSED & vbNewLine & des
                    Message.Text = messageString
                Else
                    messageString = Constant.EXPORT_FAILED
                    Message.Text = messageString
                End If
            End If
        Catch ex As Exception
            Response.Redirect(Constant.ERROR_VIEW_URL)
        End Try
    End Sub
    ''' ------------------------------------
    ''' <summary>
    ''' Handles the Button Logout event of the control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The instance containing the event data.</param>
    ''' ------------------------------------
    <Obsolete>
    Protected Sub LogButton_Onclick(sender As Object, e As EventArgs) Handles BtnLogout.Click
        Try
            Session.RemoveAll()
            Response.Redirect(Constant.LOGIN_VIEW_URL, False)
        Catch ex As Exception
            Response.Redirect(Constant.ERROR_VIEW_URL)
        End Try
    End Sub
    ''' ------------------------------------
    ''' <summary>
    ''' Handles the Select dropdown change event of the control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The instance containing the event data.</param>
    ''' ------------------------------------
    Protected Sub Selection_Change(sender As Object, e As EventArgs) Handles NewJob.SelectedIndexChanged
        Message.Text = String.Empty
        Dim selectValue As String = NewJob.SelectedItem.Value
        NewJob.SelectedValue = selectValue
    End Sub
    ''' ------------------------------------
    ''' <summary>
    ''' The medthod set all textbox on view to Empty
    ''' </summary>
    ''' ------------------------------------
    Protected Sub DisplayEmptyTextBox()
        Message.Text = String.Empty
        MessageAdd.Text = String.Empty
        NewFullname.Text = String.Empty
        NewEmail.Text = String.Empty
        NewJob.Text = String.Empty
        NewPhone.Text = String.Empty
        NewAddress.Text = String.Empty

    End Sub
    ''' ------------------------------------
    ''' <summary>
    ''' Function to write data to csvfile
    ''' </summary>
    ''' <param name="dataTable"></param>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    ''' ------------------------------------
    Public Function WriteToCSV(dataTable As DataTable, filePath As String) As Boolean
        Dim fileStream As FileStream
        Dim streamWriter As StreamWriter
        Dim i, j As Integer
        Dim strRow As String

        Try
            If (IO.File.Exists(filePath)) Then
                IO.File.Delete(filePath)
            End If

            fileStream = New FileStream(filePath, FileMode.CreateNew, FileAccess.Write)

            If Not dataTable Is Nothing Then
                streamWriter = New StreamWriter(fileStream, Encoding.UTF8)

                For i = 0 To dataTable.Rows.Count - 1
                    strRow = ""
                    For j = 0 To dataTable.Columns.Count - 1
                        strRow += dataTable(i)(j)
                        If j < dataTable.Columns.Count - 1 Then
                            strRow += ","
                        End If
                    Next
                    streamWriter.WriteLine(strRow)
                Next
                streamWriter.Close()
            End If
            fileStream.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' ------------------------------------
    ''' <summary>
    ''' Function to check validate list employee from csv
    ''' </summary>
    ''' <param name="listEmp">list emplyee need to check before import</param>
    ''' <returns></returns>
    ''' ------------------------------------
    <Obsolete>
    Public Function ValidateEmpoyee(listEmp As List(Of EmployeeModel)) As String
        Dim index As Int32 = 1
        Dim errorString As String = String.Empty
        For Each emp As EmployeeModel In listEmp
            Dim email As String = String.Empty
            Dim phone As String = String.Empty
            Dim stringErrorEmp As String = Common.ValidateEmp(emp, email, phone)
            If Not String.IsNullOrEmpty(stringErrorEmp) Then
                errorString = errorString & Constant.USER_VALIDATE & " " & index.ToString & " " & stringErrorEmp & "<br/>"
            End If
            index = index + 1
        Next
        Dim stringErrorEmail As String = CheckSimilarEmail(listEmp)
        Dim stringErrorPhone As String = CheckSimilarPhone(listEmp)
        If Not String.IsNullOrEmpty(stringErrorEmail) Then
            errorString &= stringErrorEmail
        End If
        If Not String.IsNullOrEmpty(stringErrorPhone) Then
            errorString &= stringErrorPhone
        End If
        Return errorString
    End Function
    ''' ------------------------------------
    ''' <summary>
    ''' Email check similar in import file
    ''' </summary>
    ''' <param name="listEmp">List employee from file</param>
    ''' <returns>message show the error</returns>
    ''' ------------------------------------
    Public Function CheckSimilarEmail(listEmp As List(Of EmployeeModel)) As String
        Dim mess As String = String.Empty
        Dim count = 0
        For i = 0 To listEmp.Count - 1
            For j = i + 1 To listEmp.Count - 2
                If listEmp(i).Email.Equals(listEmp(j).Email) Then
                    count = count + 1
                End If
            Next
        Next
        If count > 0 Then
            mess &= count & " " & Constant.SINILAR_EMAIL & vbNewLine
        End If
        Return mess
    End Function
    ''' ------------------------------------
    ''' <summary>
    ''' Phone check similar in import file
    ''' </summary>
    ''' <param name="listEmp">List employee from file</param>
    ''' <returns>message show the error</returns>
    ''' ------------------------------------
    Public Function CheckSimilarPhone(listEmp As List(Of EmployeeModel)) As String
        Dim mess As String = String.Empty
        Dim count = 0
        For i = 0 To listEmp.Count - 1
            For j = i + 1 To listEmp.Count - 2
                If listEmp(i).Phone.Equals(listEmp(j).Phone) Then
                    count = count + 1
                End If
            Next
        Next
        If count > 0 Then
            mess &= count & " " & Constant.SINILAR_PHONE & vbNewLine
        End If
        Return mess
    End Function

    <Obsolete>
    Protected Sub ExportButton_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Try
            Dim messageString As String = String.Empty
            Dim fileName As String = "ExportEmpoyee.csv"
            Dim path As String = Server.MapPath("~/file")
            Dim des As String = IO.Path.Combine(Server.MapPath("~/file"),
                               fileName)

            If (Not System.IO.Directory.Exists(path)) Then
                System.IO.Directory.CreateDirectory(des)
            End If
            Dim query As DBQuery = New DBQuery
            Dim dt As DataTable = New DataTable
            dt = query.GetListUser(String.Empty)
            If dt.Rows.Count <= 0 Then
                messageString = Constant.NO_DATA_FIT
                Message.Text = messageString
            Else
                Dim resWriteCSV = WriteToCSV(dt, des)
                If resWriteCSV Then
                    messageString = Constant.EXPORT_SUCESSED & vbNewLine & des
                    Message.Text = messageString
                    Response.Redirect("Utils/DownloadFile.ashx?des=" & des, False)
                Else
                    messageString = Constant.EXPORT_FAILED
                    Message.Text = messageString
                End If
            End If
        Catch ex As Exception
            Response.Redirect(Constant.ERROR_VIEW_URL)
        End Try
    End Sub
    '''  ------------------------------------
    '''  <summary>
    ''' Handles the Button Cancel Add Employee event of the GridViewUser control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The instance containing the event data.</param>
    ''' ------------------------------------
    Protected Sub CancelButton_Onclick(sender As Object, e As EventArgs) Handles BtnCancel.Click
        DisplayEmptyTextBox()
    End Sub

    '''  ------------------------------------
    ''' <summary>
    ''' Keep popup on client showing
    ''' </summary>
    ''' ------------------------------------
    Private Sub KeepPopUpShowing()
        ClientScript.RegisterStartupScript(Me.GetType(), "Pop", "keepOpenSuggestPlaceModal();", True)
    End Sub

    ''' ------------------------------------
    ''' <summary>
    ''' Handles the Texxt Change  event of the control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The instance containing the event data.</param>
    ''' ------------------------------------
    <Obsolete>
    Protected Sub Email_TextChange(sender As Object, e As EventArgs) Handles NewEmail.TextChanged
        MessageAdd.Text = String.Empty
        Dim email As String = NewEmail.Text.Trim
        Dim queryDB As DBQuery = New DBQuery
        If queryDB.VerifyEmailExist(email) Then
            MessageAdd.Text = Constant.EMAIL_EXIST
            NewEmail.Text = String.Empty
        End If
        KeepPopUpShowing()
    End Sub
    ''' ------------------------------------
    ''' <summary>
    ''' Handles the Texxt Change  event of the control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The instance containing the event data.</param>
    ''' ------------------------------------
    <Obsolete>
    Protected Sub Phone_TextChange(sender As Object, e As EventArgs) Handles NewPhone.TextChanged
        MessageAdd.Text = String.Empty
        Dim phone As String = NewPhone.Text.Trim
        Dim queryDB As DBQuery = New DBQuery
        If queryDB.VerifyPhoneExist(phone) Then
            MessageAdd.Text = Constant.PHONE_EXIST
            NewPhone.Text = String.Empty
        End If
        KeepPopUpShowing()
    End Sub
End Class