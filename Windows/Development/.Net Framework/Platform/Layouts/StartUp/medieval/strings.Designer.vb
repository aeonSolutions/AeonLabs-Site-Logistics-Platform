﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class strings
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("AeonLabs.Layouts.StartUp.strings", GetType(strings).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to code.
        '''</summary>
        Friend Shared ReadOnly Property accessCode() As String
            Get
                Return ResourceManager.GetString("accessCode", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to cancel.
        '''</summary>
        Friend Shared ReadOnly Property cancelBtn() As String
            Get
                Return ResourceManager.GetString("cancelBtn", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ID.
        '''</summary>
        Friend Shared ReadOnly Property cardId() As String
            Get
                Return ResourceManager.GetString("cardId", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to connecting to Cloud service.
        '''</summary>
        Friend Shared ReadOnly Property commServer() As String
            Get
                Return ResourceManager.GetString("commServer", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to loading.
        '''</summary>
        Friend Shared ReadOnly Property loading() As String
            Get
                Return ResourceManager.GetString("loading", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to authentication error.
        '''</summary>
        Friend Shared ReadOnly Property loginFailed() As String
            Get
                Return ResourceManager.GetString("loginFailed", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Pass smartcard.
        '''</summary>
        Friend Shared ReadOnly Property passCardOnReader() As String
            Get
                Return ResourceManager.GetString("passCardOnReader", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Question.
        '''</summary>
        Friend Shared ReadOnly Property question() As String
            Get
                Return ResourceManager.GetString("question", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to .
        '''</summary>
        Friend Shared ReadOnly Property s() As String
            Get
                Return ResourceManager.GetString("s", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Try again.
        '''</summary>
        Friend Shared ReadOnly Property tryAgain() As String
            Get
                Return ResourceManager.GetString("tryAgain", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to version.
        '''</summary>
        Friend Shared ReadOnly Property Version() As String
            Get
                Return ResourceManager.GetString("Version", resourceCulture)
            End Get
        End Property
    End Class
End Namespace