''-----------------------------------------------------------------------
' <copyright file="Example.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------
'''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : Constant
''' ------------------------------------ 
''' <summary>
''' Clas contanin the const variable in project
''' </summary>
''' <history>
'''  DatTB 25/06/2021 Created
''' </history>
''' ------------------------------------
Public Class Constant
    'DB CONNECT STRING'
    Public Const CONNECTION_STRING As String = "data source = TRANBADAT\SQLEXPRESS; database = MANAGE_USER;integrated security = SSPI;"
    'MESSAGE
    Public Const INVALID_LOGIN As String = "Invalid Username or Password"
    Public Const PROBLEM_DB_CONNECT As String = "There is a ploblem when conect to DB"
    Public Const EMPTYFILL_LOGIN As String = "Please fill in full all the textbox"
    Public Const WELCOME_LOGIN As String = "Welcome to manager user login page"
    Public Const EXCEPTION_PROB As String = "Have occur exception"
    Public Const NO_DATA_FIT As String = "NO DATA EXIST"
    Public Const PLEASE_FILL_SEARCH As String = "You haven't fill in the textbox search"
    Public Const SUCCESS_CREATING As String = "Created Emloyee successfully"
    Public Const EMAIL_EXIST As String = "Email was exist"
    Public Const PHONE_EXIST As String = "Phone was exist"
    Public Const IMPORT_SUCESSED As String = "Export successfully"
    Public Const IMPORT_FAILED As String = "Export failed"
    Public Const EXPORT_SUCESSED As String = "Export successfully"
    Public Const EXPORT_FAILED As String = "Export failed"
    Public Const FULLNAME_REQUIRED_FILL As String = "Please fill Fullname"
    Public Const EMAIL_REQUIRED_FILL As String = "Please fill Email"
    Public Const JOB_REQUIRED_FILL As String = "Please fill Job title"
    Public Const FULLNAME_REQUIRED_MAXLENGTH As String = "Fullname can't not more than 100 character"
    Public Const FULLNAME_FOMAT As String = "Fullname wrong fomat (a-z|A-Z)"
    Public Const EMAIL_FOMAT As String = "Email wrong fomat (abc@bcd.com)"
    Public Const OLD_EMAIL_SIMILAR As String = "Email similar to old Email"
    Public Const UPDATE_SUCCESS As String = "Update Employee successfully"
    Public Const NOT_EXIST_EMP As String = "The employee you are deleting no exist/edited/deleted before"
    Public Const DELETE_SUCCESS As String = "The employee deleted successfully"
    Public Const USER_VALIDATE As String = "Found Employee"
    Public Const FILE_PROB As String = "Your haven't chose file or Check your File make sure it's correct"
    Public Const NOT_EXIST_EMP_IMPORT As String = "No data in file to import"
    Public Const SINILAR_EMAIL As String = "email exist similar in import file"
    Public Const SINILAR_PHONE As String = "phone exist similar in import file"

    'PROPERTIES
    Public Const MESSAGE As String = "message"
    Public Const ERRORS As String = "error"
    Public Const USERNAME As String = "username"
    Public Const EMAIL As String = "email"
    Public Const PHONE As String = "phone"
    Public Const ID As String = "id"
    Public Const VALUE As String = "value"

    'VIEW NAMED
    Public Const lOGIN_VIEW As String = "Login"
    Public Const ERROR_VIEW As String = "Error"

    'NAMED FILL FORM INPUTS
    Public Const USERNAME_FILL As String = "Username"
    Public Const PASSWORD_FILL As String = "PassWord"
    Public Const SEARCH_VALUE_FILL As String = "SearchValue"
    Public Const FULLNAME_VALUE_FILL As String = "Fullname"
    Public Const EMAIL_VALUE_FILL As String = "Email"
    Public Const PHONE_VALUE_FILL As String = "Phone"
    Public Const JOBTITLE_VALUE_FILL As String = "JobTitle"
    Public Const ADDRESS_VALUE_FILL As String = "Address"
    Public Const ID_VALUE_FILL As String = "id"


    'URL
    Public Const LIST_USERS_URL As String = "../ListUsers/GetListUsers"

    'VARIABLE DROPDOWM
    Public Const SELECT_JOBTITLE As String = "SELECT_JOBTITLE"
    Public Const DESIIGNER As String = "DESIGNER"
    Public Const DEVELOPER As String = "DEVELOPER"
    Public Const TESTER As String = "TESTER"

    'VALIDATE FOR INPUT
    Public Const MAX_LENGTH As Integer = 100

    'REGEX
    Public Const EMAIL_REREX As String = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
    Public Const FULLNAME_REREX As String = "^[a-zA-Z]"
    'ACTION
    Public Const ADD_ACTION As String = "add"
    Public Const EDIT_ACTION As String = "edit"
End Class
