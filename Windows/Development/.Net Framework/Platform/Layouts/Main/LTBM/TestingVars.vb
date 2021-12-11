Imports AeonLabs.Environment
Imports AeonLabs.Environment.menuEnvironmentVarsClass

Module TestingVars
    Public Function loadTestingEnvironmentVars(envars As environmentVarsCore) As environmentVarsCore
        Const PROFILE As Integer = 1
        Const HELP As Integer = 100
        Const PROFILE2 As Integer = 200
        Const PROFILE3 As Integer = 300

        With envars.customization
            .ApplicationBrandNAme = "MainTestApp"

            .designLayoutAssemblyFileName = "ltbm.layout.dll"
            .designLayoutAssemblyNameSpace = "AeonLabs.Layouts.Main"

            .designStartupLayoutAssemblyFileName = "medieval.startup.layout.dll"
            .designStartupLayoutAssemblyNameSpace = "AeonLabs.Layouts.StartUp"

            .hasLogin = True
            .hasSetup = True

            .hasLocalSettings = True
            .hasCloudSettings = True

            .hasStaticAssemblies = True
            .hasDynamicAssemblies = True

            .hasStaticDocumentTemplates = True
            .hasDynamicDocumentTemplates = True

            'TODO: replace by API ACCESS KEY string : office435dfgjdn4235
            .softwareAccessMode = "humanResources"  'possible values: office, site, contractor, rh
            .expireDate = "01/01/2021"
            .updateServerAddr = "http://www.store.aeonlabs.solutions/index.php"
            .crashReportServerAddr = "http://www.sitelogistics.construction/shared/crash/api.php?task=crash"
            .websiteToLoadProgram = "http://www.sitelogistics.construction"
        End With

        With envars.layoutDesign
            .PanelBackColor = Color.Black
            .PanelTransparencyIndex = 70
            .IconsDefaultSize = 40
            .PANEL_SCROOL_UNDERLAY = 100
        End With

        'MENUS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        With envars.layoutDesign.menu.properties
            .ClosedStateSize = 40
            .height = 40
            .width = 400
            .activeBarWidth = 5
            .activeBarColor = Color.Orange
        End With

        'MENU PRIFILE ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Dim menuItem As New menuItemClass
        Dim subMenuIdx As Integer = 0
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Profile"
            .assemblyFilename = "profile.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = "usersProfileForm"
            .showAsDialog = True
            .icon = "icon.person.png"
            .subMenuIndex = False
            .menuIndex = PROFILE
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU SETTINGS
        menuItem = New menuItemClass
        subMenuIdx += 1
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Settings"
            .assemblyFilename = "settings.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU LOGOUT 
        menuItem = New menuItemClass
        subMenuIdx += 1
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Logout"
            .assemblyFilename = Nothing
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE
            .tasks.Add(runInternalTask.LOGOUT)
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU EXIT APP
        menuItem = New menuItemClass
        subMenuIdx += 1
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Exit"
            .assemblyFilename = Nothing
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = Nothing
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE
            .tasks.Add(runInternalTask.EXITAPP)
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'MENU profile 2 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        menuItem = New menuItemClass
        subMenuIdx = 0
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Profile"
            .assemblyFilename = "profile.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = "usersProfileForm"
            .showAsDialog = True
            .icon = "icon.person.png"
            .subMenuIndex = False
            .menuIndex = PROFILE2
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU SETTINGS
        menuItem = New menuItemClass
        subMenuIdx += 1
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Settings"
            .assemblyFilename = "settings.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE2
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU LOGOUT 
        menuItem = New menuItemClass
        subMenuIdx += 1
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Logout"
            .assemblyFilename = Nothing
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE2
            .tasks.Add(runInternalTask.LOGOUT)
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU EXIT APP
        menuItem = New menuItemClass
        subMenuIdx += 1
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Exit"
            .assemblyFilename = Nothing
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = Nothing
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE2
            .tasks.Add(runInternalTask.EXITAPP)
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'MENU PRIFILE 3++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        menuItem = New menuItemClass
        subMenuIdx = 0
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Profile"
            .assemblyFilename = "profile.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = "usersProfileForm"
            .showAsDialog = True
            .icon = "icon.person.png"
            .subMenuIndex = False
            .menuIndex = PROFILE3
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU SETTINGS
        menuItem = New menuItemClass
        subMenuIdx += 1
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Settings"
            .assemblyFilename = "settings.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE3
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU LOGOUT 
        menuItem = New menuItemClass
        subMenuIdx += 1
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Logout"
            .assemblyFilename = Nothing
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE3
            .tasks.Add(runInternalTask.LOGOUT)
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU EXIT APP
        menuItem = New menuItemClass
        subMenuIdx += 1
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Exit"
            .assemblyFilename = Nothing
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = Nothing
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = PROFILE3
            .tasks.Add(runInternalTask.EXITAPP)
        End With
        envars.layoutDesign.menu.items.Add(menuItem)
        'MENU HELP ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        subMenuIdx = 0
        menuItem = New menuItemClass
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Help"
            .assemblyFilename = Nothing
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = "icon.help.png"
            .subMenuIndex = False
            .menuIndex = HELP
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU CHECK FOR UPDATES
        subMenuIdx += 1
        menuItem = New menuItemClass
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "Update"
            .assemblyFilename = "update.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = HELP
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        'SUB MENU ABOUT
        menuItem = New menuItemClass
        subMenuIdx += 1
        With menuItem
            .menuUID = Guid.NewGuid.ToString().Replace("-", "")
            .menuTitle = "About"
            .assemblyFilename = "about.dll"
            .formWithContentsToLoad = Nothing
            .nameSpaceString = ""
            .showAsDialog = True
            .icon = ""
            .subMenuIndex = subMenuIdx
            .menuIndex = HELP
        End With
        envars.layoutDesign.menu.items.Add(menuItem)

        Return envars
    End Function
End Module
