Imports System.IO

Public Class customization
    Public Property ApplicationBrandNAme As String = "Missing brand"
    Public Property businessname As String = "missing business name"

    'default layout
    Public Property designLayoutAssemblyFileName As String = ""
    Public Property designLayoutAssemblyNameSpace As String = ""

    'úser defined custom layout
    Public Property designLayoutCustomAssemblyFileName As String = ""
    Public Property designLayoutCustomAssemblyNameSpace As String = ""

    Public Property designStartupLayoutAssemblyFileName As String = ""
    Public Property designStartupLayoutAssemblyNameSpace As String = ""

    Public Property hasCodedCustomizationSettings As Boolean = False

    Public Property hasLogin As Boolean = False
    Public Property hasSetup As Boolean = False

    Public Property hasLocalSettings As Boolean = False
    Public Property hasCloudSettings As Boolean = False

    Public Property hasStaticAssemblies As Boolean = True
    Public Property hasDynamicAssemblies As Boolean = True

    Public Property hasStaticDocumentTemplates As Boolean = True
    Public Property hasDynamicDocumentTemplates As Boolean = True

    Public Property websiteToLoadProgram As String = ""

    Public Property softwareAccessMode As String = ""
    Public Property expireDate As String = "" ''expire date dd/mm/yyyy

    Public Property updateServerAddr As String = "http://www.remoteattendance.logistics/update"
    Public Property crashReportServerAddr As String = ""

    Public Sub loadCustomizationFile(envars As environmentVarsCore)
        'ToDo check if customization file is present
        Dim custom = New FileInfo(envars.libraryPath & "custom.eon")
        custom.Refresh()
        If custom.Exists Then
            'TODO LOAD FILE
        Else
            'TODO LOAD BLANK UNCONFIGURED APP - MAKE AN external APP for building this file
        End If

    End Sub
End Class
