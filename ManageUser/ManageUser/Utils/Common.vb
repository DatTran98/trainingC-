'-----------------------------------------------------------------------
' <copyright file="Common.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : Common
''' ------------------------------------ 
''' <summary>
''' Class Include the utils funtion
''' </summary>
''' <history>
'''  DatTB 25/06/2021 Created
''' </history>
''' ------------------------------------
Public Class Common
    ''' ------------------------------------
    ''' <summary>
    ''' Function to encrypt password
    ''' </summary>
    ''' <param name="strToHash">String to encryt</param>
    ''' <returns>String encrypted</returns>
    ''' ------------------------------------
    Public Shared Function EncryptPassword(strToHash As String) As String
        Dim strResult As String = Nothing
        Dim md5Obj As New Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function
    ''' ------------------------------------
    ''' <summary>
    ''' Give the list Item
    ''' </summary>
    ''' <returns>list item job data</returns>
    ''' ------------------------------------
    Public Shared Function GetListJobTitle() As List(Of SelectListItem)
        Dim listJobry = New List(Of SelectListItem)
        listJobry.Add(New SelectListItem With {.Value = Nothing, .Text = Constant.SELECT_JOBTITLE})
        listJobry.Add(New SelectListItem With {.Value = "DESIGNER", .Text = Constant.DESIIGNER})
        listJobry.Add(New SelectListItem With {.Value = "DEVELOPER", .Text = Constant.DEVELOPER})
        listJobry.Add(New SelectListItem With {.Value = "TESTER", .Text = Constant.TESTER})
        Return listJobry
    End Function
    ''' ------------------------------------
    ''' <summary>
    ''' Validate infor for Employee
    ''' </summary>
    ''' <param name="empEdit">employee need to validate</param>
    ''' <param name="oldEmail">Old Email of employee</param>
    ''' <param name="oldPhone">Old Phone of employee</param>
    ''' <returns>String error if has</returns>
    ''' ------------------------------------
    <Obsolete>
    Friend Shared Function ValidateEmp(empEdit As EmployeeModel, oldEmail As String, oldPhone As String) As String
        Dim employeeDetailEdit As EmloyeeDetailEdit = New EmloyeeDetailEdit()
        Dim errorString As String = String.Empty
        Dim fullname As String = empEdit.Fullname
        Dim email As String = empEdit.Email

        If String.IsNullOrEmpty(fullname) Then
            errorString &= Constant.FULLNAME_REQUIRED_FILL
        ElseIf String.IsNullOrEmpty(email) Then
            errorString &= Constant.EMAIL_REQUIRED_FILL
        ElseIf String.IsNullOrEmpty(empEdit.JobTitle) Then
            errorString &= Constant.JOB_REQUIRED_FILL
        ElseIf fullname.Length > Constant.MAX_LENGTH Then
            errorString &= Constant.FULLNAME_REQUIRED_MAXLENGTH
        ElseIf Not Regex.IsMatch(fullname, Constant.FULLNAME_REREX) Then
            errorString &= Constant.FULLNAME_FOMAT
        ElseIf Not Regex.IsMatch(email, Constant.EMAIL_REREX) Then
            errorString &= Constant.EMAIL_FOMAT
        ElseIf (Not email.Equals(oldEmail)) And employeeDetailEdit.VerifyEmailExist(empEdit.Email) Then
            errorString &= Constant.EMAIL_EXIST
        ElseIf (Not empEdit.Phone.Equals(oldPhone)) And employeeDetailEdit.VerifyPhoneExist(empEdit.Phone) Then
            errorString &= Constant.PHONE_EXIST
        End If
        Return errorString
    End Function
End Class
