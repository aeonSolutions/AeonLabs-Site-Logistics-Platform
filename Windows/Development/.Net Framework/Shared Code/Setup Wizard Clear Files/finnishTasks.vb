Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

Public Class finnishTasks
    Private Sub finnishTasks_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Refresh()
        Application.DoEvents()

        Dim processes() As Process
        Dim instance As Process
        Dim process As New Process()
        processes = Process.GetProcesses
        For Each instance In processes
            If instance.ProcessName = "Construction Site Logistics" Then
                instance.CloseMainWindow()
            End If
        Next

        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Process.GetProcessesByName("Construction Site Logistics").Length > 0 And Microsoft.VisualBasic.Timer() < start + 10

        End While
        Dim fileName As String = Environment.CurrentDirectory & "\Setup.exe"
        While FileInUse(fileName)

        End While

        Dim setupFile = New FileInfo(fileName)
        setupFile.Refresh()

        If setupFile.Exists Then
            Try
                FileSystem.Kill(fileName)
            Catch ex As Exception
                message.Text = "(1) You need to delete setup.exe manually"
                Refresh()
                Threading.Thread.Sleep(5000)
                System.Windows.Forms.Application.Exit()
                Exit Sub
            End Try
            Try
                FileSystem.Kill(Environment.CurrentDirectory & "\library\setup.cfg")
            Catch ex As Exception
                message.Text = "(2) You need to delete setup.exe manually"
                Refresh()
                Threading.Thread.Sleep(5000)
                System.Windows.Forms.Application.Exit()
            End Try
        End If
        Try
            Threading.Thread.Sleep(2000)
            Process.Start(Path.Combine(Environment.CurrentDirectory, "Construction Site Logistics.exe"))
        Catch ex As Exception
            message.Text = "(3) You need to delete setup.exe manually"
            Refresh()
            Threading.Thread.Sleep(5000)
            System.Windows.Forms.Application.Exit()
        Finally

        End Try
        Try
            Dim dateTime As DateTime = Now
            dateTime.AddMinutes(5)
            Scheduler.SetTask("cmd.exe /C choice /C Y /N /D Y /T 3 & Del """ & Application.ExecutablePath & """", dateTime, True)
        Catch ex As Exception
            message.Text = "(4) You need To delete finnish.exe manually"
            Refresh()
            Threading.Thread.Sleep(5000)
            System.Windows.Forms.Application.Exit()
        Finally

        End Try
        System.Windows.Forms.Application.Exit()
    End Sub

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

    Private Sub Panel1_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class