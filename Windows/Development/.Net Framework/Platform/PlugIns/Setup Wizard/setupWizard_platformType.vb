Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class setupWizard_platformType
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private mainform As setupWizardMainForm
    Public Sub preLoadData(_mainForm As setupWizardMainForm)
        mainform = _mainForm
        stateCore = mainform.enVars
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)


        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()
    End Sub

    Private Sub setupWizard_1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(mainform.enVars)
            translations.load("setupWizard")


            sharedBtn.Text = translations.getText("sharedPlatform")
            ownBtn.Text = translations.getText("ownPlatform")
            sharedSetupNew.Text = translations.getText("setupNewPlatform")
            SharedConnectExisting.Text = translations.getText("connectExistingPlatform")
            ownSetupNew.Text = translations.getText("setupNewPlatform")
            ownConnectExisting.Text = translations.getText("connectExistingPlatform")

            If Not IsNothing(mainform.settings.isSharedServer) Then
                If Not IsNothing(mainform.settings.isNewServer) Then
                    If mainform.settings.isSharedServer Then
                        sharedBtn.Checked = True
                        ownBtn.Checked = False
                        If Not IsNothing(mainform.settings.disableOptions) Then
                            If mainform.settings.disableOptions.Equals(True) Then
                                ownBtn.Enabled = False
                                sharedBtn.Enabled = False
                            End If
                        End If
                        If mainform.settings.isNewServer Then
                            sharedSetupNew.Checked = True
                            SharedConnectExisting.Checked = False
                            ownSetupNew.Checked = False
                            ownConnectExisting.Checked = False
                            If Not IsNothing(mainform.settings.disableOptions) Then
                                If mainform.settings.disableOptions.Equals(True) Then
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
                            If Not IsNothing(mainform.settings.disableOptions) Then
                                If mainform.settings.disableOptions.Equals(True) Then
                                    sharedSetupNew.Enabled = False
                                    ownConnectExisting.Enabled = False
                                    ownSetupNew.Enabled = False
                                End If
                            End If
                        End If
                    Else
                        sharedBtn.Checked = False
                        ownBtn.Checked = True
                        If Not IsNothing(mainform.settings.disableOptions) Then
                            If mainform.settings.disableOptions.Equals(True) Then
                                sharedBtn.Enabled = False
                                ownBtn.Enabled = False
                            End If
                        End If

                        If mainform.settings.isNewServer Then
                            sharedSetupNew.Checked = False
                            SharedConnectExisting.Checked = False
                            ownSetupNew.Checked = True
                            ownConnectExisting.Checked = False
                            If Not IsNothing(mainform.settings.disableOptions) Then
                                If mainform.settings.disableOptions.Equals(True) Then
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
                            If Not IsNothing(mainform.settings.disableOptions) Then
                                If mainform.settings.disableOptions.Equals(True) Then
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

        ownBtn.Font = New Font(stateCore.fontTitle.Families(0), 11, FontStyle.Bold)
        sharedBtn.Font = New Font(stateCore.fontTitle.Families(0), 11, FontStyle.Bold)

        sharedSetupNew.Font = New Font(stateCore.fontTitle.Families(0), 9, FontStyle.Bold)
        SharedConnectExisting.Font = New Font(stateCore.fontTitle.Families(0), 9, FontStyle.Bold)
        ownSetupNew.Font = New Font(stateCore.fontTitle.Families(0), 9, FontStyle.Bold)
        ownConnectExisting.Font = New Font(stateCore.fontTitle.Families(0), 9, FontStyle.Bold)
        Me.ResumeLayout()
    End Sub


    Private Sub updateSettings()
        If sharedBtn.Checked Then
            mainform.settings.isSharedServer = True
            If SharedConnectExisting.Checked Then
                mainform.settings.isNewServer = False
            Else
                mainform.settings.isNewServer = True

            End If
        Else
            mainform.settings.isSharedServer = False
            If ownConnectExisting.Checked Then
                mainform.settings.isNewServer = False
            Else
                mainform.settings.isNewServer = True
            End If
        End If
        If mainform.settings.isSharedServer Then
            If mainform.settings.isNewServer Then
                'ToDo: setup new shared
            Else
                mainform.settings.serverWebAddr = "http://www.sitelogistics.construction/shared"
                mainform.settings.isNewServer = False
                mainform.settings.ApiServerAddrPath = "/csaml/api/index.php"

            End If
        Else
            If mainform.settings.isNewServer Then

            Else

            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub



    Private Sub sharedSetupNew_CheckedChanged(sender As Object, e As EventArgs) Handles sharedSetupNew.CheckedChanged
        If sharedSetupNew.Checked Then
            SharedConnectExisting.Checked = False
            ownConnectExisting.Enabled = False
            ownSetupNew.Enabled = False
        End If
        updateSettings()
    End Sub

    Private Sub SharedConnectExisting_CheckedChanged(sender As Object, e As EventArgs) Handles SharedConnectExisting.CheckedChanged
        If SharedConnectExisting.Checked Then
            sharedSetupNew.Checked = False
            ownSetupNew.Checked = False
            ownConnectExisting.Checked = False
        End If
        updateSettings()
    End Sub

    Private Sub ownSetupNew_CheckedChanged(sender As Object, e As EventArgs) Handles ownSetupNew.CheckedChanged
        If ownSetupNew.Checked Then
            ownConnectExisting.Checked = False
            SharedConnectExisting.Enabled = False
            sharedSetupNew.Enabled = False
        End If
        updateSettings()
    End Sub

    Private Sub ownConnectExisting_CheckedChanged(sender As Object, e As EventArgs) Handles ownConnectExisting.CheckedChanged
        If ownConnectExisting.Checked Then
            ownSetupNew.Checked = False
            SharedConnectExisting.Enabled = False
            sharedSetupNew.Enabled = False
        End If
        updateSettings()
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
        updateSettings()
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
        updateSettings()
    End Sub
End Class