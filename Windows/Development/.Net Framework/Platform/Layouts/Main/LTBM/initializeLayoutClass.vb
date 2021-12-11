Imports AeonLabs.Environment

Public Class initializeLayoutClass

    Public Shared Function AssembliesToLoadAtStart() As Dictionary(Of String, Dictionary(Of String, environmentLoadedAssembliesClass))
        Dim returnAssemblies As New Dictionary(Of String, Dictionary(Of String, environmentLoadedAssembliesClass))
        Dim assembliesTypes As Dictionary(Of String, environmentLoadedAssembliesClass)
        Dim assemblyDetails As environmentLoadedAssembliesClass
        Dim fileName As String
        Dim formName As String

        'Add assembly
        assembliesTypes = New Dictionary(Of String, environmentLoadedAssembliesClass)
        assemblyDetails = New environmentLoadedAssembliesClass
        With assemblyDetails
            fileName = "settings.layout.widget.dll"
            formName = "lateralSettingsForm"
            .assemblyFormName = formName
            .spaceName = "AeonLabs.PlugIns.SideBar.Settings"
            .UID = "NPmPqPuuqlwPL6swalnnMSqKGCp6MTr9"

            .positionX = Nothing ' Nothing for default posX
            .positionY = Nothing ' Nothing for default poxY
            .anchor = AnchorStyles.Left Or AnchorStyles.Top
            .control = Nothing
        End With
        assembliesTypes.Add(formName, assemblyDetails)
        returnAssemblies.Add(fileName, assembliesTypes)
        'end of add assembly

        'RETURN ASSEMBLIES DICT list
        Return returnAssemblies
    End Function
End Class

