
Imports AeonLabs.Environment
Imports AeonLabs.Environment.Assembly

Public Class AuthorizedAssemblies
#Region "LOAD STATIC ASSEMBLIES"
    Public Shared Function loadStatic() As Dictionary(Of String, Dictionary(Of String, environmentLoadedAssembliesClass))
        'TODO
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
#End Region

#Region "LOAD DYNAMIC ASSEMBLIES"
    Public Shared Function loadDynamic() As Dictionary(Of String, Dictionary(Of String, environmentLoadedAssembliesClass))
        'TODO
        Return Nothing
    End Function

#End Region
End Class
