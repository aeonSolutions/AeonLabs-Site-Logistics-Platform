Imports System.IO
Imports System.Reflection
Imports System.Xml

Module FileManagementLib

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
        If MainMdiForm.state.SendDiagnosticData.Equals(False) Then
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

End Module
