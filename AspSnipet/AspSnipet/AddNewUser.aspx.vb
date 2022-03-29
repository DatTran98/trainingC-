Public Class AddNewUser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''' ------------------------------------
    ''' <summary>
    ''' Handles the Select dropdown change event of the control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The instance containing the event data.</param>
    ''' ------------------------------------
    Protected Sub Selection_Change(sender As Object, e As EventArgs) Handles NewJob.SelectedIndexChanged
        MessageAdd.Text = String.Empty
        Dim selectValue As String = NewJob.SelectedItem.Value
        NewJob.SelectedValue = selectValue
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
        SetAllTextBoxDefault()
        KeepPopUpShowing()
        MessageAdd.Text = "Add User Succesfully"
    End Sub
    '''  ------------------------------------
    '''  <summary>
    ''' Handles the Button Cancel Add Employee event of the GridViewUser control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The instance containing the event data.</param>
    ''' ------------------------------------
    Protected Sub CancelButton_Onclick(sender As Object, e As EventArgs) Handles BtnCancel.Click
        SetAllTextBoxDefault()
        KeepPopUpShowing()
    End Sub
    '''  ------------------------------------
    '''  <summary>
    ''' Set All textbox on view to Empty
    ''' </summary>
    ''' ------------------------------------
    Private Sub SetAllTextBoxDefault()
        MessageAdd.Text = String.Empty
        NewFullname.Text = String.Empty
        NewEmail.Text = String.Empty
        NewJob.SelectedValue = String.Empty
        NewPhone.Text = String.Empty
        NewAddress.Text = String.Empty
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
            MessageAdd.Text = " Email was Existed"
            NewEmail.Text = String.Empty
        End If
        KeepPopUpShowing()
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
    Protected Sub Phone_TextChange(sender As Object, e As EventArgs) Handles NewPhone.TextChanged
        MessageAdd.Text = String.Empty
        Dim phone As String = NewPhone.Text.Trim
        Dim queryDB As DBQuery = New DBQuery
        If queryDB.VerifyPhoneExist(phone) Then
            MessageAdd.Text = " Phone was Existed"
            NewPhone.Text = String.Empty
        End If
        KeepPopUpShowing()
    End Sub
End Class