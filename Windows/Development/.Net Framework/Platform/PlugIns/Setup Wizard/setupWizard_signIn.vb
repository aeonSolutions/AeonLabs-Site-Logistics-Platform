Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class setupWizard_signIn
    Private showpass As Boolean
    Private translations As languageTranslations
    Private msgbox As messageBoxForm
    Private WithEvents bwRegie As New BackgroundWorker
    Private nfCard As IsmartCard
    Private authByCard As Boolean = False
    Private loginSuccess As Boolean = False

    Private WithEvents checkCredentialsHttp As HttpDataPostData
    Private WithEvents sendEmailHttp As HttpDataPostData

    Private mainform As setupWizardMainForm
    Public Sub preLoadData(_mainForm As setupWizardMainForm)
        mainform = _mainForm
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        sign_id.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        sign_in_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        forgot_id.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)

        signInCode.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        signInCode_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)

        email.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        email_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        send.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)

        server_msg.Font = New Font(mainform.enVars.fontTitle.Families(0), 8, FontStyle.Regular)

        Me.ResumeLayout()

    End Sub

    Private Sub setupWizard_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(mainform.enVars)
            translations.load("setupWizard")

            sign_in_lbl.Text = translations.getText("signIn")
            forgot_id.Text = translations.getText("forgotId") & " ?"
            email_lbl.Text = translations.getText("email")
            send.Text = translations.getText("send")
            signInCode_lbl.Text = translations.getText("code")
            Me.ResumeLayout()
            mainform.enVars.currentLang = mainform.settings.lang

            showpass = True
            authByCard = False
            server_msg.Visible = False

            mainform.forwardPicBtn.Visible = False

            Try
                nfCard = DirectCast(loadDllObject(mainform.enVars, "contactless.smartcards.dll", "smartCard"), IsmartCard)
            Catch ex As Exception
                nfCard = Nothing
            End Try

            If nfCard IsNot Nothing Then
                If nfCard.SelectDevice() Then
                    Dim smartCardReaders As New List(Of String)
                    Dim errMsg As String = ""
                    If nfCard.GetAvailableReaders(smartCardReaders, errMsg) Then
                        authByCard = True
                        server_msg.Visible = True
                        doCardAuth()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub doCardAuth()
        signInCode.Enabled = False
        translations.load("loginDialog")
        server_msg.Text = translations.getText("passCardOnReader")
        sign_id.Enabled = False
        bwRegie = New BackgroundWorker()
        bwRegie.WorkerSupportsCancellation = True
        bwRegie.RunWorkerAsync()
    End Sub

    Private Sub bwRegie_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwRegie.DoWork
        Dim cardData(1) As String
        loginSuccess = False

        If nfCard.SelectDevice() Then
            nfCard.establishContext()
            While loginSuccess.Equals(False)
                If nfCard.readCardUID() AndAlso Not nfCard.getCardUIDString().Equals("") Then
                    cardData(0) = Convert.ToInt64(nfCard.getCardUIDString(), 16).ToString()
                    cardData(1) = If(Not nfCard.readStringOnCard(12, 5), "", nfCard.getReadedString())
                    e.Result = cardData
                    nfCard.Close()
                    Exit Sub
                End If
            End While
        End If
    End Sub

    Private Sub bwRegie_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwRegie.RunWorkerCompleted
        translations.load("busyMessages")
        server_msg.Text = translations.getText("commServer")
        signInCode.Text = e.Result(1)
        sign_id.Text = e.Result(0)

        checkCredentialsOnWeb()
    End Sub

    Private Sub checkCredentialsOnWeb()
        If sign_id.Text.Equals("") Or Not IsNumeric(sign_id.Text) Then
            Exit Sub
        End If

        mainform.forwardPicBtn.Visible = False
        mainform.backPicBtn.Visible = False

        translations = New languageTranslations(mainform.enVars)
        translations.load("busyDialog")

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "101")
        vars.Add("id", sign_id.Text.ToString.Replace(" ", ""))
        vars.Add("idkey", signInCode.Text.ToString.Replace(" ", ""))
        vars.Add("type", "unknown")

        ' install default secret key
        mainform.enVars.secretKey = mainform.defaultEncryptionKey
        mainform.enVars.currentLang = mainform.settings.lang

        checkCredentialsHttp = New HttpDataPostData(mainform.enVars, mainform.settings.serverWebAddr & mainform.settings.ApiServerAddrPath)
        checkCredentialsHttp.loadQueue(vars)
        checkCredentialsHttp.startRequest()
    End Sub

    Private Sub checkCredentialsHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles checkCredentialsHttp.dataArrived

        If Not IsResponseOk(responseData) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(responseData), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, -1, -1, mainform.enVars)
            Me.BringToFront()
            Application.DoEvents()
            msgbox.ShowDialog()

            If authByCard Then
                doCardAuth()
            End If

            mainform.forwardPicBtn.Visible = True
            mainform.backPicBtn.Visible = True
            Exit Sub
        End If

        mainform.settings.userId = sign_id.Text

        mainform.forwardPicBtn.Visible = True
        mainform.backPicBtn.Visible = True
    End Sub

    Private Sub forgot_id_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles forgot_id.LinkClicked
        email.Visible = True
        email_lbl.Visible = True
        send.Visible = True
    End Sub



    Private Sub show_password_Click(sender As Object, e As EventArgs) Handles show_password.Click
        If showpass Then
            show_password.Image = Image.FromFile(mainform.enVars.imagesPath & Convert.ToString("show_password.png"))
            signInCode.PasswordChar = ""
            showpass = False
        Else
            show_password.Image = Image.FromFile(mainform.enVars.imagesPath & Convert.ToString("hide_password.png"))
            signInCode.PasswordChar = "•"
            showpass = True
        End If
    End Sub



    Private Sub send_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles send.LinkClicked
        If Not IsValidEmailFormat(email.Text) Then
            Exit Sub
        End If

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "1011")
        vars.Add("email", email.Text)
        vars.Add("type", "unknown")
        ' install default secret key
        mainform.enVars.secretKey = mainform.defaultEncryptionKey
        mainform.enVars.currentLang = mainform.settings.lang

        sendEmailHttp = New HttpDataPostData(mainform.enVars, mainform.settings.serverWebAddr & mainform.settings.ApiServerAddrPath)
        sendEmailHttp.loadQueue(vars)
        sendEmailHttp.startRequest()
    End Sub

    Private Sub sendEmailHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles sendEmailHttp.dataArrived
        If Not IsResponseOk(responseData) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(responseData), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, -1, -1, mainform.enVars)
            Me.BringToFront()
            Application.DoEvents()
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(responseData), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, -1, -1, mainform.enVars)
            Me.BringToFront()
            Application.DoEvents()
            msgbox.ShowDialog()
        End If
    End Sub

End Class