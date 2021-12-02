Imports AeonLabs.Environment

Public Module LayoutSettings
    Public Const LAYOUT_VERSION As String = "1.0.0"
    Public Const LAYOUT_COMPATIBILITY_WITH_MAIN As String = "1.0.0"

    Public Function layoutCompatibilityApps() As List(Of String)
        Dim apps As New List(Of String)

        apps.Add("remoteAttendance")

        Return apps
    End Function

    Public Function loadExternalFilesInUse(envars As environmentVarsCore) As environmentVarsCore
        With envars
            .externalFilesToLoad.Add("menuMinimizeArrow", "uparrow.png")
            .externalFilesToLoad.Add("menuExpandArrow", "downarrow.png")

            Dim testFilesExist As String = ""
            For Each item As KeyValuePair(Of String, String) In .externalFilesToLoad
                If Not My.Computer.FileSystem.FileExists(envars.imagesPath & item.Value) Then
                    testFilesExist &= item.Value & "; "
                End If
            Next
            If Not testFilesExist.Equals("") Then
                Microsoft.VisualBasic.MsgBox("Could not load the following files: " & testFilesExist)
                Return Nothing
            Else
                Return envars
            End If
        End With
    End Function
End Module

