Imports AeonLabs.Environment

Module AppCustomization

    Public Function setupCustomizationVariables(enVars As environmentVarsCore) As environmentVarsCore
        With enVars.customization
            .ApplicationBrandNAme = "Remote Attendance Logistics"

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
            .updateServerAddr = "http://www.sitelogistics.construction/shared/update/update.php"
            .crashReportServerAddr = "http://www.sitelogistics.construction/shared/crash/api.php?task=crash"
            .websiteToLoadProgram = "http://www.sitelogistics.construction"
        End With

        Return enVars
    End Function

End Module
