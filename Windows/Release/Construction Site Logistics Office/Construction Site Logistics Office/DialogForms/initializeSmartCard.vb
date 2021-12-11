Public Class initializeSmartCard
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
    Private nfCard As New NFCard
    Public Shared workersForm As workers_frm
    Public Shared siteForm As site_mng_frm
    Private currentUID As String = ""
    Private currentCode As String = ""


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub meteo_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = MainMdiForm.state
        translations = New languageTranslations(state)

        Me.SuspendLayout()

        closeBtn.BackColor = state.buttonColor
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")

        translations.load("smartcard")
        StartBtn.Text = translations.getText("newCard")
        readCodeOnly.Text = translations.getText("readCodeOnly")
        cardIdCode.Text = translations.getText("cardId") & ": - -"
        authCode_lbl.Text = translations.getText("authCode") & ": - -"
        ResumeLayout()

    End Sub

    Private Sub form_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        nfCard = New NFCard
        Dim smartCardReaders As New List(Of String)
        Dim errMsg As String = ""

        If Not IsNothing(workersForm) Then
            workersForm = MainMdiForm.CurrentWrapperForm.FindForm()
        Else
            siteForm = MainMdiForm.CurrentWrapperForm.FindForm()
        End If

        StartBtn.Enabled = False
        readCodeOnly.Enabled = False
        cardIdCode.Visible = False
        authCode_lbl.Visible = False
        nfCard = New NFCard
        If nfCard.SelectDevice() Then
            If nfCard.GetAvailableReaders(smartCardReaders, errMsg) Then
                StartBtn.Enabled = True
                readCodeOnly.Enabled = True
                nfCard.establishContext()
            End If
        End If
        progressBar.Value = 0
    End Sub
    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        workers_frm.initializeSmartCardCodeID = ""


        If Not IsNothing(workersForm) Then
            If Not workersForm.txt_nfc.Text.Equals(currentUID) Or Not workersForm.nfc_auth_code.Text.Equals(currentCode) Then
                translations.load("smartcard")
                Dim message As String = translations.getText("questionLoadValuesIntoForm")
                translations.load("messagebox")
                msgbox = New message_box_frm(message & " ?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msgbox.ShowDialog() = DialogResult.Yes Then
                    workersForm.txt_nfc.Text = AddSpaces(currentUID, 3)
                    workersForm.nfc_auth_code.Text = currentCode.Substring(0, 4) & " - " & currentCode.Substring(4, 3) & " - " & currentCode.Substring(7, 5)
                End If
            End If
        Else
            If Not siteForm.nfcResponsavel.Text.Equals(currentUID) Or Not siteForm.nfcCardCode.Text.Equals(currentCode) Then
                translations.load("smartcard")
                Dim message As String = translations.getText("questionLoadValuesIntoForm")
                translations.load("messagebox")
                msgbox = New message_box_frm(message & " ?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msgbox.ShowDialog() = DialogResult.Yes Then
                    siteForm.nfcResponsavel.Text = AddSpaces(currentUID, 3)
                    siteForm.nfcCardCode.Text = currentCode.Substring(0, 4) & " - " & currentCode.Substring(4, 3) & " - " & currentCode.Substring(7, 5)
                End If
            End If
        End If

        Me.Close()
    End Sub

    Private Sub SaveAuthString_Click(sender As Object, e As EventArgs) Handles StartBtn.Click
        nfCard = New NFCard
        If Not nfCard.SelectDevice() Then
            Exit Sub
        Else
            nfCard.establishContext()
        End If

        StartBtn.Enabled = False
        readCodeOnly.Enabled = False

        If nfCard.connectCard() Then
            progressBar.Value = 0
            If Not nfCard.readCardUID() Then
                progressBar.Value = 0
                StartBtn.Enabled = True
                readCodeOnly.Enabled = True
                MainMdiForm.statusMessage = "erro ao ler ID cartao"
                Exit Sub
            ElseIf nfCard.getCardUIDString().Equals("") Then
                progressBar.Value = 0
                StartBtn.Enabled = True
                readCodeOnly.Enabled = True
                MainMdiForm.statusMessage = "erro ao ler ID vazio"
                Exit Sub
            End If

            Dim cardUID As String = nfCard.getCardUIDString()
            progressBar.Value = 50
            If cardUID.Equals(workers_frm.txt_nfc.Text.ToString.Replace(" ", "")) And Not workers_frm.nfc_auth_code.Text.Equals("") Then
                translations.load("smartcard")
                Dim message As String = translations.getText("questionCardIsInitialized")
                translations.load("messagebox")
                msgbox = New message_box_frm(message, translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msgbox.ShowDialog() <> DialogResult.OK Then
                    StartBtn.Enabled = True
                    readCodeOnly.Enabled = True
                    Exit Sub
                End If
            End If

            Dim workerCode As String = ""
            Dim rnd As New Random
            Randomize()
            If Not IsNothing(workersForm) Then
                If (CInt(workers_frm.works_worker.Item("cod_worker")(workers_frm.posToLoad)) < 10) Then
                    workerCode = "00" & CInt(workers_frm.works_worker.Item("cod_worker")(workers_frm.posToLoad)).ToString
                ElseIf (CInt(workers_frm.works_worker.Item("cod_worker")(workers_frm.posToLoad)) < 100) Then
                    workerCode = "0" & CInt(workers_frm.works_worker.Item("cod_worker")(workers_frm.posToLoad)).ToString
                Else
                    workerCode = CInt(workers_frm.works_worker.Item("cod_worker")(workers_frm.posToLoad)).ToString
                End If
            Else
                If (CInt(site_mng_frm.query_manager.Item("cod_manager")(site_mng_frm.managerListPos)) < 10) Then
                    workerCode = "00" & CInt(site_mng_frm.query_manager.Item("cod_manager")(site_mng_frm.managerListPos)).ToString
                ElseIf (CInt(site_mng_frm.query_manager.Item("cod_manager")(site_mng_frm.managerListPos))) < 100 Then
                    workerCode = "0" & CInt(site_mng_frm.query_manager.Item("cod_manager")(site_mng_frm.managerListPos)).ToString
                Else
                    workerCode = CInt(site_mng_frm.query_manager.Item("cod_manager")(site_mng_frm.managerListPos)).ToString
                End If

            End If

            ' auth format is PIN number (4 digits) + cod_worker DB(3 digits including left zeros) + 5 digit random string for a total of 12 bytes or 3 blocks
            ' workerCode = "001"

            Dim newAuthStr As String = rnd.Next(1000, 10000).ToString & workerCode & randomString(5)


            If Not nfCard.SaveStringOnCard(newAuthStr, 5) Then 'Please make sure you do not write data into these Authentication Blocks 0-4 for mifare ntag 215.
                translations.load("messagebox")
                msgbox = New message_box_frm(nfCard.errorMessage, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                nfCard.Close()
                StartBtn.Enabled = True
                readCodeOnly.Enabled = True
                Exit Sub
            End If

            nfCard.Close()
            progressBar.Value = 100
            authCode_lbl.Text = translations.getText("authCode") & ": " & newAuthStr.Substring(0, 4) & " - " & newAuthStr.Substring(4, 3) & " - " & newAuthStr.Substring(7, 5)
            cardIdCode.Text = translations.getText("cardId") & ": " & AddSpaces(Convert.ToInt64(cardUID, 16).ToString, 3)
            Refresh()

            currentUID = Convert.ToInt64(cardUID, 16).ToString
            currentCode = newAuthStr

            If Not IsNothing(workersForm) Then
                workersForm.nfc_auth_code.Text = newAuthStr.Substring(0, 4) & " - " & newAuthStr.Substring(4, 3) & " - " & newAuthStr.Substring(7, 5)
                workersForm.nfc_auth_code.Refresh()

                workersForm.txt_nfc.Text = AddSpaces(Convert.ToInt64(cardUID, 16).ToString, 3)
                workersForm.txt_nfc.Refresh()
            Else
                siteForm.nfcResponsavel.Text = AddSpaces(currentUID, 3)
                siteForm.nfcResponsavel.Refresh()
                siteForm.nfcCardCode.Text = currentCode.Substring(0, 4) & " - " & currentCode.Substring(4, 3) & " - " & currentCode.Substring(7, 5)
                siteForm.nfcCardCode.Refresh()
            End If
        Else
            cardIdCode.Text = translations.getText("cardId") & ": - -"
            authCode_lbl.Text = translations.getText("authCode") & ": - -"
            Refresh()

            If Not IsNothing(workersForm) Then
                workersForm.txt_nfc.Text = ""
                workersForm.txt_nfc.Refresh()
                workersForm.nfc_auth_code.Text = ""
                workersForm.nfc_auth_code.Refresh()

            Else
                siteForm.nfcResponsavel.Text = ""
                siteForm.nfcResponsavel.Refresh()
                siteForm.nfcCardCode.Text = ""
                siteForm.nfcCardCode.Refresh()
            End If

            currentUID = ""
            currentCode = ""
        End If
        StartBtn.Enabled = True
        readCodeOnly.Enabled = True
    End Sub

    Private Sub readCodeOnly_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles readCodeOnly.LinkClicked
        nfCard = New NFCard

        If Not nfCard.SelectDevice() Then
            Exit Sub
        Else
            nfCard.establishContext()
        End If
        If nfCard.connectCard() Then
            progressBar.Value = 0
            If Not nfCard.readCardUID() Then
                progressBar.Value = 0
                StartBtn.Enabled = True
                readCodeOnly.Enabled = True
                MainMdiForm.statusMessage = "erro ao ler ID cartao"
                Exit Sub
            ElseIf nfCard.getCardUIDString().Equals("") Then
                progressBar.Value = 0
                StartBtn.Enabled = True
                readCodeOnly.Enabled = True
                MainMdiForm.statusMessage = "erro ao ler ID vazio"
                Exit Sub
            End If
            Dim cardUID As String = nfCard.getCardUIDString()
            progressBar.Value = 50
            If Not nfCard.readStringOnCard(12, 5) Then
                progressBar.Value = 0
                nfCard.Close()
                Exit Sub
            End If
            Dim cardAuth As String = nfCard.getReadedString()
            progressBar.Value = 100
            nfCard.Close()

            currentUID = Convert.ToInt64(cardUID, 16).ToString
            currentCode = cardAuth

            authCode_lbl.Text = translations.getText("authCode") & ": " & cardAuth.Substring(0, 4) & " - " & cardAuth.Substring(4, 3) & " - " & cardAuth.Substring(7, 5)
            cardIdCode.Text = translations.getText("cardId") & ": " & AddSpaces(Convert.ToInt64(cardUID, 16).ToString, 3)
            Refresh()

        Else
            cardIdCode.Text = translations.getText("cardId") & ": - -"
            authCode_lbl.Text = translations.getText("authCode") & ": - -"
            Refresh()
            currentUID = ""
            currentCode = ""
        End If
    End Sub
End Class


