Imports System.IO
Imports System.Reflection

Public NotInheritable Class SplashScreen

    Private translations As languageTranslations
    Public state As New State

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub SplashScreen1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Application.DoEvents()

        While Not Me.IsHandleCreated
        End While
        Dim settingsFile As FileInfo
        Dim setupFile = New FileInfo(Path.Combine(state.basePath, "Setup.exe"))
        setupFile.Refresh()
        If setupFile.Exists Then
            Try
                settingsFile = New FileInfo(Path.Combine(state.libraryPath, "ScrewDriver.eon"))
                settingsFile.Refresh()
                If settingsFile.Exists Then
                    FileSystem.Kill(Path.Combine(state.libraryPath, "ScrewDriver.eon"))
                End If
                Process.Start(Path.Combine(state.basePath, "Setup.exe"))
            Catch ex As Exception

            End Try
            Application.Exit()
            Exit Sub
        End If

        settingsFile = New FileInfo(Path.Combine(state.libraryPath, "ScrewDriver.eon"))
        settingsFile.Refresh()

        Dim today As New MonthCalendar
        Dim oneYear As New MonthCalendar
        oneYear.SetDate(Date.ParseExact("26/02/2022", "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo))

        If Not settingsFile.Exists Or today.TodayDate > oneYear.SelectionStart Then
            Dim msgbox As message_box_frm
            msgbox = New message_box_frm("You need to download and install the lastest version of the program at http://www.sitelogistics.construction ", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2, state)
            msgbox.ShowDialog()
            Application.Exit()
        Else
            Dim settings As New Settings(New State)
            Dim newState As State = Nothing

            newState = settings.load()
            If IsNothing(newState) Then
                Dim msgbox As message_box_frm
                msgbox = New message_box_frm("(2) You need to download and install the lastest version of the program at http://www.sitelogistics.construction ", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2, state)
                msgbox.ShowDialog()
                Application.Exit()
                Exit Sub
            End If

            Timer.Start()
            ProgressBar.Visible = True

        End If

    End Sub

    Private Sub setupWizard_1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            'Copyright info
            translations = New languageTranslations(state)
            translations.load("SplashScreen")
            Version.Text = translations.getText("Version") & " " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
            Me.ResumeLayout()
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        ProgressBar.Increment(1)
        If ProgressBar.Value = 100 Then
            Me.Hide()
            Timer.Enabled = False
            MainMdiForm.Show()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Version_Click(sender As Object, e As EventArgs) Handles Version.Click

    End Sub
End Class
