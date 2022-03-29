'-----------------------------------------------------------------------
' <copyright file="UserModel.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'-----------------------------------------------------------------------

''' ------------------------------------
''' Project  : Traning_nic_vb
''' Class  : UserModel
''' ------------------------------------ 
''' <summary>
''' Model As A User to save User properties
''' </summary>
''' <history>
'''  DatTB 05/07/2021 Created
''' </history>
''' ------------------------------------
Public Class UserModel
    Private _username As String
    Private _password As String
    ''' ---------------------------------
    ''' <summary>
    ''' Getter and Setter Username Property
    ''' </summary>
    ''' ---------------------------------
    Public Property Username
        Get
            Return _username
        End Get
        Set(value)
            _username = value
        End Set
    End Property
    ''' ---------------------------------
    ''' <summary>
    ''' Getter and Setter PassWord Property
    ''' </summary>
    ''' ---------------------------------
    Public Property PassWord
        Get
            Return _password
        End Get
        Set(value)
            _password = value
        End Set
    End Property
End Class
