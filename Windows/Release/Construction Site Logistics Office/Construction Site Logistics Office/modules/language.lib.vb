Imports System.IO
Imports System.Text

Public Class languageTranslations

    Private translations As Dictionary(Of String, String)
    Private state As State
    Private loadedKey As String = ""

    Public Sub New(ByVal Optional _state As State = Nothing)
        translations = New Dictionary(Of String, String)
        If IsNothing(_state) Then
            state = New State
        Else
            state = _state
        End If
    End Sub

    Public Sub load(form As String)
        If loadedKey.Equals(form) Then
            Exit Sub
        End If
        Dim langFile As String
        translations = New Dictionary(Of String, String)
        Dim sArray As String()
        Dim Index As Integer = 0
        ReDim Preserve sArray(Index)
        Dim found As Boolean = False

        Try
            If state.currentLang.Equals("") Then
                langFile = Path.Combine(state.libraryPath, "en.eon")
            Else
                Dim checkFile = New FileInfo(Path.Combine(state.libraryPath, state.currentLang & ".eon"))
                checkFile.Refresh()
                If checkFile.Exists Then ' get the current app lang
                    langFile = Path.Combine(state.libraryPath, state.currentLang & ".eon")
                Else
                    checkFile = New FileInfo(Path.Combine(state.libraryPath, "en.eon"))
                    checkFile.Refresh()
                    If checkFile.Exists Then
                        langFile = Path.Combine(state.libraryPath, "en.eon")
                    Else
                        Exit Sub
                    End If
                End If
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
                    If line.Equals("'" & form) Then
                        found = True
                    Else
                        found = False
                    End If
                    Continue Do
                End If
                If found Then
                    ReDim Preserve sArray(Index)
                    sArray(Index) = line
                    Index += 1
                End If
            Loop
            fStream.Close()
            sReader.Close()
        Catch ex As Exception
            MainMdiForm.statusMessage = ex.Message.ToString
            Exit Sub
        End Try

        For i = 0 To sArray.Length - 1
            If IsNothing(sArray(i)) Then
                Continue For
            End If
            If sArray(i).IndexOf("=") > 0 Then
                Dim str() As String = sArray(i).Split("=")
                If Not translations.ContainsKey(str(0)) Then
                    translations.Add(str(0).Replace(" ", ""), str(1))
                End If
            End If
        Next i
        loadedKey = form
    End Sub

    Public Function getText(key As String) As String
        If translations.ContainsKey(key) Then
            Return translations.Item(key).Replace("&", "&&")
        Else
            Return "err. trans."
        End If
    End Function

End Class
