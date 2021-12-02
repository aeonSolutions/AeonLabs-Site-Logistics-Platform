Imports System.IO
Imports System.Text
Imports AeonLabs.Environment

Public Module quoteOfTheDayLib
    Public Function loadSentenceQuoteOfTheDay() As String
        Dim state As New environmentVarsCore
        Dim fileName As String = Path.Combine(state.libraryPath, "quotes.eon")
        Dim quotesFile = New FileInfo(fileName)
        Dim sArray As String()
        Dim Index As Integer = 0
        ReDim Preserve sArray(Index)
        Dim found As Boolean = False

        quotesFile.Refresh()
        If quotesFile.Exists Then
            Try
                'with Array
                Dim fStream = New System.IO.FileStream(fileName, IO.FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Dim sReader = New System.IO.StreamReader(fStream, Encoding.UTF8)

                Do While sReader.Peek >= 0
                    Dim line = sReader.ReadLine
                    If IsNothing(line) Then
                        Continue Do
                    End If

                    If line.Equals("") Then
                        Continue Do
                    End If

                    ReDim Preserve sArray(Index)
                    sArray(Index) = line
                    Index += 1
                Loop
                fStream.Close()
                sReader.Close()
            Catch ex As Exception
                Return ex.Message
            End Try

            Dim rnd As New Random
            Randomize()
            Return sArray(rnd.Next(0, sArray.Length - 1))
        Else
            Return "quotes file not found"
        End If
    End Function

End Module
