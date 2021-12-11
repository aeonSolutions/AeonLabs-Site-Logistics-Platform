Imports System.ComponentModel
Imports AeonLabs.Connectivity.SmartCards
Imports AeonLabs.Environment
Imports AeonLabs.Backend.PlugIns.quoteOfTheDayLib
Imports AeonLabs.BasicLibraries
Imports AeonLabs.Connectivity.SmartCards.Interface
Imports AeonLabs.environmentLoading
Imports AeonLabs.StartUp

Public NotInheritable Class LayoutStartUpForm

    Public WithEvents enVars As environmentVarsCore
    Private WithEvents loadEnVars As environmentLoading.loadEnvironment
    Private WithEvents startupBackgroundTasks As startupBackgroundTasksClass

    Private updateMainApp As environmentVarsCore.updateMainLayoutDelegate

    Private showPass As Boolean
    Private msgbox As messageBoxForm

    Private WithEvents bwDoCardAuth As BackgroundWorker

    Private locationTextW, panelTextW As Integer

    Private WithEvents smartcard As smartCard

    Private authByCard As Boolean = False
    Private loading As Boolean = True


    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Public Sub New(_envarsCore As environmentVarsCore, ByRef _updateMainApp As environmentVarsCore.updateMainLayoutDelegate)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        enVars = _envarsCore
        updateMainApp = _updateMainApp

        startupBackgroundTasks = New startupBackgroundTasksClass(enVars)
    End Sub
    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SuspendLayout()
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(enVars.currentLang)

        cancelCard_lbl.Text = My.Resources.strings.cancelBtn
        cancelCard_lbl.Location = New Point(Me.Width - 5 - cancelCard_lbl.Width, Me.Height - 5 - cancelCard_lbl.Height)

        access_code.Text = My.Resources.strings.accessCode
        cardId_lbl.Text = My.Resources.strings.cardId

        cardId.Text = ""
        codetxt.Text = ""
        loginBtn.Enabled = True

        codetxt.Focus()
        Me.StartPosition = FormStartPosition.CenterScreen
        panelLogin.Visible = True
        panelLogin.Location = New Point(Me.Width / 2 - (panelLogin.Width) / 2, panelLogin.Location.Y)

        'Copyright info
        VersionLabel.Text = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
        versionTitleLabel.Text = My.Resources.strings.Version

        Dim padding As Integer = 50
        panelTextW = PanelLocationText.Width

        SuspendLayout()
        versionTitleLabel.Location = New Point(Me.Width - versionTitleLabel.Width - padding, versionTitleLabel.Location.Y)
        versionTitleLabel.Parent = animatedBackGround
        versionTitleLabel.BackColor = Color.Transparent

        VersionLabel.Location = New Point(Me.Width - VersionLabel.Width - padding, VersionLabel.Location.Y)
        VersionLabel.Parent = animatedBackGround
        VersionLabel.BackColor = Color.Transparent

        progressbar.Parent = animatedBackGround
        progressbar.BackColor = Color.Transparent
        progressbar.Location = New Point(Me.Width - progressbar.Width - padding, progressbar.Location.Y)
        progressbar.Visible = False

        statusMessage.Location = animatedBackGround.PointToClient(Me.PointToScreen(statusMessage.Location))
        statusMessage.Parent = animatedBackGround
        statusMessage.BackColor = Color.Transparent
        statusMessage.Location = New Point(Me.Width - statusMessage.Width - padding, statusMessage.Location.Y)

        titleLabel.Parent = animatedBackGround
        titleLabel.BackColor = Color.Transparent
        titleLabel.Location = New Point(Me.Width - titleLabel.Width - padding, titleLabel.Location.Y)

        TitleFlavourLabel.Parent = animatedBackGround
        TitleFlavourLabel.BackColor = Color.Transparent
        TitleFlavourLabel.Location = New Point(Me.Width - TitleFlavourLabel.Width - padding, TitleFlavourLabel.Location.Y)

        cancelCard_lbl.Parent = animatedBackGround
        cancelCard_lbl.BackColor = Color.Transparent
        cancelCard_lbl.Location = New Point(Me.Width - cancelCard_lbl.Width - padding, cancelCard_lbl.Location.Y)

        websiteLink.Parent = animatedBackGround
        websiteLink.BackColor = Color.Transparent
        websiteLink.Location = New Point(Me.Width - websiteLink.Width - padding, websiteLink.Location.Y)

        ''quoteLabel.Location = backGroundImage.PointToClient(Me.PointToScreen(quoteLabel.Location))
        quoteOfTheDaySentenceLabel.Parent = animatedBackGround
        quoteOfTheDaySentenceLabel.BackColor = Color.Transparent
        quoteOfTheDaySentenceLabel.Location = New Point(Me.Width - quoteOfTheDaySentenceLabel.Width - padding, quoteOfTheDaySentenceLabel.Location.Y)

        PanelLocationText.Location = New Point(Me.Width - PanelLocationText.Width - padding, PanelLocationText.Location.Y)
        PanelLocationText.Parent = animatedBackGround
        PanelLocationText.BackColor = Color.Transparent

        locationLabel.Parent = PanelLocationText
        locationLabel.BackColor = Color.Transparent
        ''locationLabel.Location = New Point(Me.Width - locationLabel.Width - padding, locationLabel.Location.Y)
        locationLabel.Text = ""

        panelLogin.Location = animatedBackGround.PointToClient(Me.PointToScreen(panelLogin.Location))
        panelLogin.Parent = animatedBackGround

        cardId_lbl.Location = animatedBackGround.PointToClient(Me.PointToScreen(cardId_lbl.Location))
        cardId_lbl.Parent = panelLogin

        cardId.Location = animatedBackGround.PointToClient(Me.PointToScreen(cardId.Location))
        cardId.Parent = panelLogin
        cardId.BackColor = Color.White

        access_code.Location = animatedBackGround.PointToClient(Me.PointToScreen(access_code.Location))
        access_code.Parent = panelLogin

        codetxt.Location = animatedBackGround.PointToClient(Me.PointToScreen(codetxt.Location))
        codetxt.Parent = panelLogin
        codetxt.BackColor = Color.White

        show_password.Location = animatedBackGround.PointToClient(Me.PointToScreen(show_password.Location))
        show_password.Parent = panelLogin

        loginBtn.Location = animatedBackGround.PointToClient(Me.PointToScreen(loginBtn.Location))
        loginBtn.Parent = panelLogin
        ResumeLayout()
        Refresh()

    End Sub
    Private Sub SplashScreen_visibility(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible And loading Then
            enVars.successLogin = False
            progressbar.Bar1.Value = 0
            progressbar.Visible = False
            progressbar.ResetText()
            statusMessage.Visible = True
            cardId.Text = ""
            codetxt.Text = ""
            panelLogin.Visible = False

            SuspendLayout()
            statusMessage.Text = My.Resources.strings.loading
            'LOAD COOL SENTENCE
            quoteOfTheDaySentenceLabel.Text = loadSentenceQuoteOfTheDay()

            ResumeLayout()

            locationTextTimer.Enabled = True
            locationTextTimer.Start()

            loadEnVars = New loadEnvironment(enVars)
            loadEnVars.loadLocation()

            showPass = True
            authByCard = False
            Try
                smartcard = DirectCast(loadExternalAssembly(enVars, "smartcard.dll", "smartCard"), IsmartCard)
            Catch ex As Exception
                smartcard = Nothing
            End Try
            If smartcard IsNot Nothing Then
                If smartcard.SelectDevice() Then
                    Dim smartCardReaders As New List(Of String)
                    Dim errMsg As String = ""
                    If smartcard.GetAvailableReaders(smartCardReaders, errMsg) Then
                        authByCard = True
                        doCardAuthByNFC()
                    End If
                End If
            End If
            panelLogin.Visible = True
        End If
    End Sub


    Private Sub SplashScreen1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub startupBackgroundTasks_updatePrgressBar(sender As Object, value As Integer) Handles startupBackgroundTasks.updatePrgressBar
        progressbar.Invoke(Sub()
                               progressbar.Visible = True
                               progressbar.Bar1.Value = value
                           End Sub)
    End Sub

    Private Sub startupBackgroundTasks_updateStatusMessage(sender As Object, message As String) Handles startupBackgroundTasks.updateStatusMessage
        statusMessage.Invoke(Sub()
                                 statusMessage.Text = message
                             End Sub)
    End Sub



    Private Sub startupBackgroundTasks_loginError(sender As Object, message As String) Handles startupBackgroundTasks.loginError
        msgbox = New messageBoxForm(message & " " & My.Resources.strings.tryAgain & " ?", My.Resources.strings.question, MessageBoxButtons.RetryCancel, MessageBoxIcon.Question)
        If Not message.Equals("skip") AndAlso (msgbox.ShowDialog = DialogResult.Cancel) Then
            System.Windows.Forms.Application.Exit()
            Exit Sub
        Else

            codetxt.Invoke(Sub()
                               codetxt.Enabled = True
                               codetxt.Text = ""
                           End Sub)


            cardId.Invoke(Sub()
                              cardId.Enabled = True
                              cardId.Text = ""
                          End Sub)
            panelLogin.Invoke(Sub()
                                  panelLogin.Visible = True

                              End Sub)

            If authByCard Then
                cancelCard_lbl.Invoke(Sub()
                                          cancelCard_lbl.Visible = True

                                      End Sub)
            Else
                cardId.Invoke(Sub()
                                  cardId.Visible = True
                              End Sub)
            End If

            If authByCard Then
                doCardAuthByNFC()
            End If
        End If
    End Sub

    Private Sub codetxt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codetxt.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            validateCode()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles show_password.Click
        If showPass Then
            show_password.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("show_password.png"))
            codetxt.PasswordChar = ""
            showPass = False
        Else
            show_password.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("hide_password.png"))
            codetxt.PasswordChar = "•"
            showPass = True
        End If
    End Sub

    '' finnsihed loading location data
    Private Sub state_environmentDataLoadedCompleted() Handles loadEnVars.environmentDataLoadedCompleted
        If Not Me.IsHandleCreated Then
            Exit Sub
        End If
        enVars = loadEnVars.GetEnviroment()
        locationLabel.Invoke(Sub()
                                 locationLabel.Text = enVars.locationData.state & ", " & enVars.locationData.country
                                 locationTextW = locationLabel.Width
                             End Sub)
    End Sub

    Private Sub doCardAuthByNFC()
        cancelCard_lbl.Visible = True
        statusMessage.Text = My.Resources.strings.passCardOnReader
        show_password.Visible = False
        cardId.Visible = False
        codetxt.Enabled = False
        cardId.Enabled = False
        bwDoCardAuth = New BackgroundWorker()
        bwDoCardAuth.WorkerSupportsCancellation = True
        bwDoCardAuth.RunWorkerAsync()
    End Sub

    Private Sub bwDoCardAuth_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwDoCardAuth.DoWork
        Dim cardData(1) As String
        enVars.successLogin = False

        If smartcard.SelectDevice() Then
            smartcard.establishContext()
            While enVars.successLogin.Equals(False)
                If smartcard.connectCard() Then
                    If smartcard.readCardUID() AndAlso Not smartcard.getCardUIDString().Equals("") Then
                        cardData(0) = Convert.ToInt64(smartcard.getCardUIDString(), 16).ToString()
                        cardData(1) = If(Not smartcard.readStringOnCard(12, 5), "", smartcard.getReadedString())
                        e.Result = cardData
                        smartcard.Close()
                        Exit Sub
                    End If
                End If
            End While
        End If
    End Sub

    Private Sub bwDoCardAuth_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwDoCardAuth.RunWorkerCompleted
        statusMessage.Text = My.Resources.strings.commServer
        codetxt.Text = e.Result(1)
        cardId.Text = e.Result(0)
        If authByCard Then
            cancelCard_lbl.Visible = False
        Else
            cardId.Visible = False
        End If

        validateCode()
    End Sub

    Private Sub validateCode()
        enVars.successLogin = False
        cardId.Enabled = False
        codetxt.Enabled = False
        statusMessage.Text = My.Resources.strings.commServer
        statusMessage.Visible = True
        If codetxt.Text.Equals("") Or Not IsNumeric(codetxt.Text) Or cardId.Text.Equals("") Or Not IsNumeric(cardId.Text) Then
            msgbox = New messageBoxForm(My.Resources.strings.loginFailed & ". " & My.Resources.strings.tryAgain & " ?", My.Resources.strings.question, MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            If (msgbox.ShowDialog = DialogResult.Cancel) Then
                System.Windows.Forms.Application.Exit()
                Exit Sub
            End If
            access_code.Text = My.Resources.strings.accessCode
            codetxt.Enabled = True
            cardId.Enabled = True
            cardId.Enabled = True
            statusMessage.Visible = True
            codetxt.Text = ""
            cardId.Text = ""
            Exit Sub
        End If
        panelLogin.Visible = False
        panelLogin.Refresh()

        startupBackgroundTasks.doLogin(cardId.Text.ToString, codetxt.Text.ToString)
    End Sub

    Private Sub startupBackgroundTasks_startUpTasksCompleted(sender As Object, enVarsResult As environmentVarsCore) Handles startupBackgroundTasks.startUpTasksCompleted
        enVars = enVarsResult

        Dim dataUpdate As New updateMainAppClass
        dataUpdate.envars = enVars
        dataUpdate.updateTask = updateMainAppClass.UPDATE_MAIN
        updateMainApp.Invoke(Me, dataUpdate)

        Me.Close()
    End Sub

    Private Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click
        validateCode()
    End Sub

    Private Sub cancelCard_lbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles cancelCard_lbl.LinkClicked
        Dim dataUpdate As New updateMainAppClass
        dataUpdate.envars = enVars
        dataUpdate.updateTask = updateMainAppClass.UPDATE_MAIN
        updateMainApp.Invoke(Me, dataUpdate)

        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub websiteLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles websiteLink.LinkClicked
        System.Diagnostics.Process.Start(enVars.customization.websiteToLoadProgram)
    End Sub



    Private Sub locationTextTimer_Tick(sender As Object, e As EventArgs) Handles locationTextTimer.Tick
        If locationTextW > panelTextW Then
            locationLabel.Left = locationLabel.Left - 3
            If locationLabel.Left < 0 - locationLabel.Width Then
                locationLabel.SuspendLayout()
                locationLabel.Left = PanelLocationText.Width
                locationLabel.ResumeLayout()
            End If
        End If

    End Sub
End Class
