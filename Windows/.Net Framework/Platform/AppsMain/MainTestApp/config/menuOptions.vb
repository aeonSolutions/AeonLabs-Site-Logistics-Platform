Imports AeonLabs.Environment
Imports AeonLabs.Environment.menuEnvironmentVarsClass

Public Class menuOptions
    Private enVars As New environmentVarsCore

    Const PROFILE As Integer = 1
    Const HELP As Integer = 1000

    Public Function Load(_enVars) As environmentVarsCore
        enVars = _enVars
        load_profile_menu()
        load_menu_help()

        Return enVars
    End Function

#Region "MENU PROFILE"
    Private Sub load_profile_menu()
        Dim menuItem As New menuItemClass
        Dim subMenuIdx As Integer = 0
        With menuItem
            .menuUID = "MyProfile"
            .menuTitle = My.Resources.strings.menuItemMyProfile
            .friendlyUID = "profile.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = "usersProfileForm"
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = False
            .menuIndex = PROFILE
        End With
        enVars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU SETTINGS
        subMenuIdx += 1
        With menuItem
            .menuUID = "Settings"
            .menuTitle = My.Resources.strings.menuItemSettings
            .friendlyUID = "settings.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE
        End With
        enVars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU LOGOUT 
        subMenuIdx += 1
        With menuItem
            .menuUID = "Logout"
            .menuTitle = My.Resources.strings.menuItemLogout
            .friendlyUID = Nothing
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE
            .tasks.Add(runInternalTask.LOGOUT)
        End With
        enVars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU EXIT APP
        subMenuIdx += 1
        With menuItem
            .menuUID = "Exit"
            .menuTitle = My.Resources.strings.menuItemLogout
            .friendlyUID = Nothing
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = Nothing
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE
            .tasks.Add(runInternalTask.EXITAPP)
        End With
        enVars.layoutDesign.menu.items.Add(menuItem)
    End Sub
#End Region

#Region "LOAD MENU HELP"
    Private Sub load_menu_help()
        Dim subMenuIdx As Integer = 0
        Dim menuItem As New menuItemClass

        With menuItem
            .menuUID = "Help"
            .menuTitle = My.Resources.strings.menuHelpTitle
            .friendlyUID = Nothing
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = "help.icon.png"
            .subMenuIndex = False
            .menuIndex = HELP
        End With
        enVars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU CHECK FOR UPDATES
        subMenuIdx += 1
        With menuItem
            .menuUID = "CheckUpdates"
            .menuTitle = My.Resources.strings.menuItemCheckUpdate
            .friendlyUID = "update.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = HELP
        End With
        enVars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU ABOUT
        subMenuIdx += 1
        With menuItem
            .menuUID = "About"
            .menuTitle = My.Resources.strings.menuItemAbout & " " & enVars.customization.ApplicationBrandNAme
            .friendlyUID = "about.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = HELP
        End With
        enVars.layoutDesign.menu.items.Add(menuItem)
    End Sub
#End Region

End Class
