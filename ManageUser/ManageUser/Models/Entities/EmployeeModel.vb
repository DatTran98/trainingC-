'-----------------------------------------------------------------------
' <copyright file="EmployeeModel.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------
''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : EmployeeModel
''' ------------------------------------ 
''' <summary>
''' Model As A Employee to save Employee properties
''' </summary>
''' <history>
'''  DatTB 25/06/2021 Created
''' </history>
''' ------------------------------------
Public Class EmployeeModel
    Private _fullname As String
    Private _email As String
    Private _phone As String
    Private _jobTitle As String
    Private _address As String
    Private _listJobTitle As List(Of SelectListItem)
    ''' ---------------------------------
    ''' <summary>
    ''' Getter and Setter Fullname Property
    ''' </summary>
    ''' ---------------------------------
    Public Property Fullname
        Get
            Return _fullname
        End Get
        Set(value)
            _fullname = value
        End Set
    End Property
    ''' ---------------------------------
    ''' <summary>
    ''' Getter and Setter Email Property
    ''' </summary>
    ''' ---------------------------------
    Public Property Email
        Get
            Return _email
        End Get
        Set(value)
            _email = value
        End Set
    End Property
    ''' ---------------------------------
    ''' <summary>
    ''' Getter and Setter Phone Property
    ''' </summary>
    ''' ---------------------------------
    Public Property Phone
        Get
            Return _phone
        End Get
        Set(value)
            _phone = value
        End Set
    End Property
    ''' ---------------------------------
    ''' <summary>
    ''' Getter and Setter JobTitle Property
    ''' </summary>
    ''' ---------------------------------
    Public Property JobTitle
        Get
            Return _jobTitle
        End Get
        Set(value)
            _jobTitle = value
        End Set
    End Property
    ''' ---------------------------------
    ''' <summary>
    ''' Getter and Setter Address Property
    ''' </summary>
    ''' ---------------------------------
    Public Property Address
        Get
            Return _address
        End Get
        Set(value)
            _address = value
        End Set
    End Property
    Public Property ListJobTitle
        Get
            Return _listJobTitle
        End Get
        Set(value)
            _listJobTitle = value
        End Set
    End Property
End Class
