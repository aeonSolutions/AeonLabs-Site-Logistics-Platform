Imports System.IO
Imports System.Reflection
Imports AeonLabs.Environment


Module CrashDataLib
    Function saveCrash(e As Exception) As Boolean
        Dim state As New environmentVarsCore()
        If state.SendDiagnosticData.Equals(False) Then
            Return True
        End If
        Dim trace = New Diagnostics.StackTrace(e, True)
        Dim line As String = Microsoft.VisualBasic.Right(trace.ToString, 5)
        Dim Xcont As Integer = 0
        Dim report As String = e.Message.ToString().Replace("'", "") & System.Environment.NewLine
        report += "--------- Stack trace ---------" & System.Environment.NewLine
        report += "----------" + DateTime.Now.ToString + "----------" & System.Environment.NewLine
        report += "----------OS version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString + "----------" & System.Environment.NewLine
        report += "    Error Line:" + Microsoft.VisualBasic.Right(trace.ToString, 5) & System.Environment.NewLine
        report += "-------------------------------" & System.Environment.NewLine

        report += "--------- Cause ---------" & System.Environment.NewLine
        For Each sf As StackFrame In trace.GetFrames
            Xcont = Xcont + 1
            report += Xcont & "- " & sf.GetMethod().ReflectedType.ToString.Replace("'", "") & " " & sf.GetMethod().Name.Replace("'", "") & System.Environment.NewLine
        Next
        report += "-------------end report---------------" & System.Environment.NewLine

        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        Try
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(Path.Combine(String.Format("{0}\", System.Environment.CurrentDirectory), "crash.log"), True)
            file.WriteLine(report & System.Environment.NewLine)
            file.Close()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

End Module
