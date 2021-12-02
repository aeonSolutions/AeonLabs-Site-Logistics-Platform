Imports AeonLabs.Environment

Public Class AuthorizedAssemblies
#Region "LOAD STATIC ASSEMBLIES"
    Public Shared Function loadStatic() As Dictionary(Of String, environmentAssembliesClass)
        Dim assemblies As New Dictionary(Of String, environmentAssembliesClass)
        Dim details As New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "TsRL8UBkdbPGq9ncvkMGvOQMM5q3dP29"
        End With
        assemblies.Add("attendance.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "Es42aOFmQN5JXp4gKgfsek795BpI8Mq0"
        End With
        assemblies.Add("attendance.report.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "NPmPqPuuqlwPL6swalnnMSqKGCp6MTr9"
        End With
        assemblies.Add("absences.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "XPuhFervQPJdDeIufzyQNDs9WvuwVL9n"
        End With
        assemblies.Add("clothes.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "DvqsDWYajUskhBN9LXRdx2mQJwojHnQP"
        End With
        assemblies.Add("workers.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "fSORC6dnPZNawPh5YMdTcqBRRVKBI6jB"
        End With
        assemblies.Add("workers.locate.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "jkVhlny1Kmf6ZlKI0LkhpOvV3fEUkapa"
        End With
        assemblies.Add("workers.templates.dll", details)

        Return assemblies
    End Function
#End Region

#Region "LOAD DYNAMIC ASSEMBLIES"
    Public Shared Function loadDynamic() As Dictionary(Of String, environmentAssembliesClass)
        Dim assemblies As New Dictionary(Of String, environmentAssembliesClass)
        Dim details As New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "TsRL8UBkdbPGq9ncvkMGvOQMM5q3dP29"
        End With
        assemblies.Add("attendance.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "Es42aOFmQN5JXp4gKgfsek795BpI8Mq0"
        End With
        assemblies.Add("attendance.report.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "NPmPqPuuqlwPL6swalnnMSqKGCp6MTr9"
        End With
        assemblies.Add("absences.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "XPuhFervQPJdDeIufzyQNDs9WvuwVL9n"
        End With
        assemblies.Add("clothes.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "DvqsDWYajUskhBN9LXRdx2mQJwojHnQP"
        End With
        assemblies.Add("workers.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "fSORC6dnPZNawPh5YMdTcqBRRVKBI6jB"
        End With
        assemblies.Add("workers.locate.dll", details)

        details = New environmentAssembliesClass
        With details
            .spaceName = ""
            .UID = "jkVhlny1Kmf6ZlKI0LkhpOvV3fEUkapa"
        End With
        assemblies.Add("workers.templates.dll", details)

        Return assemblies
    End Function
#End Region
End Class
