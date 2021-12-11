Imports System
Imports System.IO

Module Program
    Sub Main(args As String())
        Dim fileName As String = Environment.CurrentDirectory & "\Setup.exe"
        While FileInUse(fileName)

        End While
        Dim setupFile = New FileInfo(fileName)
        setupFile.Refresh()
        File.WriteAllText(Environment.CurrentDirectory & "\debug.txt", Environment.CurrentDirectory & "\Setup.exe")
        'Console.WriteLine(Environment.CurrentDirectory & "\Setup.exe")

        If setupFile.Exists Then

            Try
                File.WriteAllText(Environment.CurrentDirectory & "\debug.txt", Environment.NewLine & "kill file")
                'Console.WriteLine("kill file")
                FileSystem.Kill(fileName)
            Catch ex As Exception
                'Console.WriteLine("error")
                Exit Sub
            End Try
            Try
                File.WriteAllText(Environment.CurrentDirectory & "\debug.txt", Environment.NewLine & "kill file")
                'Console.WriteLine("kill file")

                FileSystem.Kill(Environment.CurrentDirectory & "\library\setup.cfg")
            Catch ex As Exception
                'Console.WriteLine("error 2")

            End Try
        End If
        File.WriteAllText(Environment.CurrentDirectory & "\debug.txt", Environment.NewLine & "process start")
        Try
            Threading.Thread.Sleep(2000)
            Process.Start(Path.Combine(Environment.CurrentDirectory, "Construction Site Logistics.exe"))
        Catch ex As Exception
            'Console.WriteLine("file not found")
            Exit Sub
        Finally
            'Console.WriteLine("Continue....")
        End Try
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
End Module
