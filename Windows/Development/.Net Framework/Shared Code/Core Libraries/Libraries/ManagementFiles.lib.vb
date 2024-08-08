Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Xml

Public Module FileManagementLib

    Public Function FileInUse(ByVal sFile As String) As Boolean
        Dim thisFileInUse As Boolean = False
        If System.IO.File.Exists(sFile) Then
            Try
                Using f As New IO.FileStream(sFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                    ' thisFileInUse = False
                End Using
            Catch
                thisFileInUse = True
            End Try
        End If
        Return thisFileInUse
    End Function

    Function saveCrash(e As Exception) As Boolean
        Dim state As New environmentVars(LOAD_SETTINGS)
        If state.SendDiagnosticData.Equals(False) Then
            Return True
        End If
        Dim trace = New Diagnostics.StackTrace(e, True)
        Dim line As String = Microsoft.VisualBasic.Right(trace.ToString, 5)
        Dim Xcont As Integer = 0
        Dim report As String = e.Message.ToString().Replace("'", "") & Environment.NewLine
        report += "--------- Stack trace ---------" & Environment.NewLine
        report += "----------" + DateTime.Now.ToString + "----------" & Environment.NewLine
        report += "----------OS version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString + "----------" & Environment.NewLine
        report += "    Error Line:" + Microsoft.VisualBasic.Right(trace.ToString, 5) & Environment.NewLine
        report += "-------------------------------" & Environment.NewLine

        report += "--------- Cause ---------" & Environment.NewLine
        For Each sf As StackFrame In trace.GetFrames
            Xcont = Xcont + 1
            report += Xcont & "- " & sf.GetMethod().ReflectedType.ToString.Replace("'", "") & " " & sf.GetMethod().Name.Replace("'", "") & Environment.NewLine
        Next
        report += "-------------end report---------------" & Environment.NewLine

        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        Try
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(Path.Combine(String.Format("{0}\", Environment.CurrentDirectory), "crash.log"), True)
            file.WriteLine(report & Environment.NewLine)
            file.Close()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

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
                Return ""
            End Try

            Dim rnd As New Random
            Randomize()
            Return sArray(rnd.Next(0, sArray.Length - 1))
        Else
            Return ""
        End If
    End Function

End Module
