Imports AeonLabs.Environment

Public Class updateEnvironmentClass
    Public Shared Event UpDateEnvironemnt(sender As Object, envars As environmentVarsCore)

    Public Sub RaiseEnventUpDateEnvironemnt(sender As Object, envars As environmentVarsCore)
        RaiseEvent UpDateEnvironemnt(sender, envars)
    End Sub

    Public Sub New()

    End Sub

    Public Function addAssemblies(assembly As Object) As Dictionary(Of String, environmentAssembliesClass)
        Dim result As New Dictionary(Of String, environmentAssembliesClass)
        Dim assToLoad As New environmentAssembliesClass

        If TypeOf assembly Is Dictionary(Of String, String) Then
            For Each ass In assembly
                assToLoad = New environmentAssembliesClass
                assToLoad.friendlyUID = ass.key
                assToLoad.assemblyFileName = ass.value
                result.Add(ass.key, assToLoad)
            Next
        End If

        Return result
    End Function
End Class
