Imports System.Drawing.Text


Public Class setupWizard_platformType
    Private state As New State
    Private translations As languageTranslations

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()
    End Sub

    Private Sub setupWizard_1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(setupWizard_country.state)
            translations.load("setupWizard")
            title.Text = translations.getText("titlePlatformType")
            subtitle.Text = translations.getText("subtitlePlatformType")
            btnBackTxt.Text = translations.getText("btnBack")
            btnContinueTxt.Text = translations.getText("btnContinue")
            sharedBtn.Text = translations.getText("sharedPlatform")
            ownBtn.Text = translations.getText("ownPlatform")
            sharedSetupNew.Text = translations.getText("setupNewPlatform")
            SharedConnectExisting.Text = translations.getText("connectExistingPlatform")
            ownSetupNew.Text = translations.getText("setupNewPlatform")
            ownConnectExisting.Text = translations.getText("connectExistingPlatform")

            If Not IsNothing(setupWizard_country.settings.isSharedServer) Then
                If Not IsNothing(setupWizard_country.settings.isNewServer) Then
                    If setupWizard_country.settings.isSharedServer Then
                        sharedBtn.Checked = True
                        ownBtn.Checked = False
                        If Not IsNothing(setupWizard_country.settings.disableOptions) Then
                            If setupWizard_country.settings.disableOptions.Equals(True) Then
                                ownBtn.Enabled = False
                                sharedBtn.Enabled = False
                            End If
                        End If
                        If setupWizard_country.settings.isNewServer Then
                            sharedSetupNew.Checked = True
                            SharedConnectExisting.Checked = False
                            ownSetupNew.Checked = False
                            ownConnectExisting.Checked = False
                            If Not IsNothing(setupWizard_country.settings.disableOptions) Then
                                If setupWizard_country.settings.disableOptions.Equals(True) Then
                                    SharedConnectExisting.Enabled = False
                                    ownSetupNew.Enabled = False
                                    ownConnectExisting.Enabled = False
                                End If
                            End If
                        Else
                            sharedSetupNew.Checked = False
                            SharedConnectExisting.Checked = True
                            ownSetupNew.Checked = False
                            ownConnectExisting.Checked = False
                            If Not IsNothing(setupWizard_country.settings.disableOptions) Then
                                If setupWizard_country.settings.disableOptions.Equals(True) Then
                                    sharedSetupNew.Enabled = False
                                    ownConnectExisting.Enabled = False
                                    ownSetupNew.Enabled = False
                                End If
                            End If
                        End If
                    Else
                        sharedBtn.Checked = False
                        ownBtn.Checked = True
                        If Not IsNothing(setupWizard_country.settings.disableOptions) Then
                            If setupWizard_country.settings.disableOptions.Equals(True) Then
                                sharedBtn.Enabled = False
                                ownBtn.Enabled = False
                            End If
                        End If

                        If setupWizard_country.settings.isNewServer Then
                            sharedSetupNew.Checked = False
                            SharedConnectExisting.Checked = False
                            ownSetupNew.Checked = True
                            ownConnectExisting.Checked = False
                            If Not IsNothing(setupWizard_country.settings.disableOptions) Then
                                If setupWizard_country.settings.disableOptions.Equals(True) Then
                                    SharedConnectExisting.Enabled = False
                                    sharedSetupNew.Enabled = False
                                    ownConnectExisting.Enabled = False
                                End If
                            End If
                        Else
                            sharedSetupNew.Checked = False
                            SharedConnectExisting.Checked = False
                            ownSetupNew.Checked = False
                            ownConnectExisting.Checked = True
                            If Not IsNothing(setupWizard_country.settings.disableOptions) Then
                                If setupWizard_country.settings.disableOptions.Equals(True) Then
                                    sharedSetupNew.Enabled = False
                                    SharedConnectExisting.Enabled = False
                                    ownSetupNew.Enabled = False
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()
        btnBack.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Bold)
        btnContinue.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Bold)
        ownBtn.Font = New Font(state.fontTitle.Families(0), 11, FontStyle.Bold)
        sharedBtn.Font = New Font(state.fontTitle.Families(0), 11, FontStyle.Bold)
        title.Font = New Font(state.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(state.fontTitle.Families(0), 12, FontStyle.Regular)
        sharedSetupNew.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Bold)
        SharedConnectExisting.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Bold)
        ownSetupNew.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Bold)
        ownConnectExisting.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Bold)
        Me.ResumeLayout()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles btnBackTxt.Click
        wizardGoBack()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        wizardGoBack()
    End Sub

    Private Sub wizardGoBack()
        Me.Hide()
        setupWizard_language.Show()
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        wizardGoForward()
    End Sub

    Private Sub btnContinueTxt_Click(sender As Object, e As EventArgs) Handles btnContinueTxt.Click
        wizardGoForward()
    End Sub

    Private Sub wizardGoForward()
        If sharedBtn.Checked Then
            setupWizard_country.settings.isSharedServer = True
            If SharedConnectExisting.Checked Then
                setupWizard_country.settings.isNewServer = False
            Else
                setupWizard_country.settings.isNewServer = True
            End If
        Else
            setupWizard_country.settings.isSharedServer = False
            If ownConnectExisting.Checked Then
                setupWizard_country.settings.isNewServer = False
            Else
                setupWizard_country.settings.isNewServer = True
            End If
        End If
        Me.Hide()
        If setupWizard_country.settings.isSharedServer Then
            If setupWizard_country.settings.isNewServer Then
                'ToDo: setup new shared
            Else
                setupWizard_country.settings.serverWebAddr = "http://www.sitelogistics.construction/shared"
                setupWizard_country.settings.isNewServer = False
                setupWizard_country.settings.ApiServerAddrPath = "/csaml/api/index.php"
                Me.Hide()
                setupWizard_signIn.Show()
            End If
        Else
            If setupWizard_country.settings.isNewServer Then
                setupWizard_NewFtpWebSettings.Show()
            Else
                setupWizard_ServerAddress.Show()
            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub



    Private Sub sharedSetupNew_CheckedChanged(sender As Object, e As EventArgs) Handles sharedSetupNew.CheckedChanged
        If sharedSetupNew.Checked Then
            SharedConnectExisting.Checked = False
            ownConnectExisting.Enabled = False
            ownSetupNew.Enabled = False
        End If
        If (sharedSetupNew.Checked Or SharedConnectExisting.Checked) Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub SharedConnectExisting_CheckedChanged(sender As Object, e As EventArgs) Handles SharedConnectExisting.CheckedChanged
        If SharedConnectExisting.Checked Then
            sharedSetupNew.Checked = False
            ownSetupNew.Checked = False
            ownConnectExisting.Checked = False
        End If
        If (sharedSetupNew.Checked Or SharedConnectExisting.Checked) Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub ownSetupNew_CheckedChanged(sender As Object, e As EventArgs) Handles ownSetupNew.CheckedChanged
        If ownSetupNew.Checked Then
            ownConnectExisting.Checked = False
            SharedConnectExisting.Enabled = False
            sharedSetupNew.Enabled = False
        End If
        If (ownSetupNew.Checked Or ownConnectExisting.Checked) Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub ownConnectExisting_CheckedChanged(sender As Object, e As EventArgs) Handles ownConnectExisting.CheckedChanged
        If ownConnectExisting.Checked Then
            ownSetupNew.Checked = False
            SharedConnectExisting.Enabled = False
            sharedSetupNew.Enabled = False
        End If
        If (ownSetupNew.Checked Or ownConnectExisting.Checked) Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub sharedBtn_CheckedChanged(sender As Object, e As EventArgs) Handles sharedBtn.CheckedChanged
        If sharedBtn.Checked Then
            ownConnectExisting.Enabled = False
            ownSetupNew.Enabled = False
            ownSetupNew.Checked = False
            ownConnectExisting.Checked = False

            SharedConnectExisting.Enabled = True
            sharedSetupNew.Enabled = True
            SharedConnectExisting.Checked = False
            sharedSetupNew.Checked = False

            ownBtn.Checked = False
        Else
            SharedConnectExisting.Enabled = False
            sharedSetupNew.Enabled = False
            SharedConnectExisting.Checked = False
            sharedSetupNew.Checked = False
        End If
        If (sharedSetupNew.Checked Or SharedConnectExisting.Checked) Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub ownBtn_CheckedChanged(sender As Object, e As EventArgs) Handles ownBtn.CheckedChanged
        If ownBtn.Checked Then
            SharedConnectExisting.Enabled = False
            sharedSetupNew.Enabled = False

            ownConnectExisting.Enabled = True
            ownSetupNew.Enabled = True
            ownSetupNew.Checked = False
            ownConnectExisting.Checked = False

            SharedConnectExisting.Enabled = False
            sharedSetupNew.Enabled = False
            SharedConnectExisting.Checked = False
            sharedSetupNew.Checked = False

            sharedBtn.Checked = False
        Else
            ownConnectExisting.Enabled = False
            ownSetupNew.Enabled = False
            ownSetupNew.Checked = False
            ownConnectExisting.Checked = False
        End If
        If (ownSetupNew.Checked Or ownConnectExisting.Checked) Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub subtitle_Click(sender As Object, e As EventArgs) Handles subtitle.Click

    End Sub
End Class