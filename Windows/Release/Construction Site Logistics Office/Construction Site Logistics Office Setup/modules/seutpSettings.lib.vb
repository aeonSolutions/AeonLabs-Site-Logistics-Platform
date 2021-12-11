Imports System.IO
Imports System.Text
Imports ConstructionSiteLogistics

Public Class setupSettings

    Private setupConfig As Dictionary(Of String, String)
    Private state As State

    Public Sub New(ByVal Optional _state As State = Nothing)
        setupConfig = New Dictionary(Of String, String)
        If IsNothing(_state) Then
            state = New State
        Else
            state = _state
        End If
    End Sub

    Public Function load() As Boolean
        Dim langFile As String
        setupConfig = New Dictionary(Of String, String)
        Dim sArray As String()
        Dim Index As Integer = 0
        ReDim Preserve sArray(Index)

        Try
            langFile = Path.Combine(state.libraryPath, "setup.cfg")
            Dim checkFile = New FileInfo(langFile)
            checkFile.Refresh()
            If Not checkFile.Exists Then ' get the current app lang
                Return False
            End If

            'with Array
            Dim fStream = New System.IO.FileStream(langFile, IO.FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim sReader = New System.IO.StreamReader(fStream, Encoding.UTF8)

            Do While sReader.Peek >= 0
                Dim line = sReader.ReadLine
                If IsNothing(line) Then
                    Continue Do
                End If
                If line.Equals("") Then
                    Continue Do
                End If
                If line.Substring(0, 1).Equals("'") Then
                    Continue Do
                End If

                ReDim Preserve sArray(Index)
                sArray(Index) = line
                Index += 1
            Loop
            fStream.Close()
            sReader.Close()
        Catch ex As Exception
            Return False
        End Try

        For i = 0 To sArray.Length - 1
            If IsNothing(sArray(i)) Then
                Continue For
            End If
            If sArray(i).IndexOf("=") > 0 Then
                Dim str() As String = sArray(i).Split("=")
                If Not setupConfig.ContainsKey(str(0)) Then
                    setupConfig.Add(str(0).Replace(" ", ""), str(1).Replace(" ", ""))
                End If
            End If
        Next i
        Return True
    End Function

    Public Function getText(key As String) As String
        If setupConfig.ContainsKey(key) Then
            Return setupConfig.Item(key)
        Else
            Return "error"
        End If
    End Function

End Class
