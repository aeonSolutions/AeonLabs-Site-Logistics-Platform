Imports AeonLabs.Environment

Public Class assembliesToLoadClass
    Private enVars As New environmentVarsCore

    Public Function Load(_enVars) As environmentVarsCore
        enVars = _enVars
        load_profile_menu()
        load_help_menu()

        Return enVars
    End Function

#Region "Assemblies on MENU items"
#Region "profile menu"
    Private Sub load_profile_menu()
        Dim assItem As New environmentAssembliesClass
        With assItem
            .assemblyFileName = "profile.dll"
            .friendlyUID = "MyProfile"
            .UID = ""
            .assemblyFormName = ""
            .assemblyFormToLoad = Nothing
            .AssemblyObject = Nothing
            .spaceName = ""
        End With
        enVars.assemblies.Add("MyProfile", assItem)

        assItem = New environmentAssembliesClass
        With assItem
            .assemblyFileName = "settings.dll"
            .friendlyUID = "MySettings"
            .UID = ""
            .assemblyFormName = ""
            .assemblyFormToLoad = Nothing
            .AssemblyObject = Nothing
            .spaceName = "MySettings"
        End With
        enVars.assemblies.Add("MySettings", assItem)

    End Sub
#End Region

#Region "help menu"
    Private Sub load_help_menu()
        Dim assItem As New environmentAssembliesClass
        With assItem
            .assemblyFileName = "update.dll"
            .friendlyUID = "checkUpdate"
            .UID = ""
            .assemblyFormName = ""
            .assemblyFormToLoad = Nothing
            .AssemblyObject = Nothing
            .spaceName = ""
        End With
        enVars.assemblies.Add("checkUpdate", assItem)

        assItem = New environmentAssembliesClass
        With assItem
            .assemblyFileName = "about.dll"
            .friendlyUID = "about"
            .UID = ""
            .assemblyFormName = ""
            .assemblyFormToLoad = Nothing
            .AssemblyObject = Nothing
            .spaceName = ""
        End With
        enVars.assemblies.Add("about", assItem)

    End Sub
#End Region

#End Region

End Class
