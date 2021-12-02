Imports System.Drawing
Imports System.Windows.Forms
Imports ConstructionSiteLogistics.Gui.Forms.Core
Imports ConstructionSiteLogistics.Libraries.Core
Imports siteConstructionSiteLogistics.SmartCards.Library

Public Class initializeSmartCard
    Private msgbox As messageBoxForm
    Private state As New environmentVars
    Private translations As languageTranslations
    Private nfCard As New smartCard

    public property mainForm as MainMdiForm

    Private currentUID As String = ""
    Private currentCode As String = ""
    Private currentPin As String = ""

    Private currentFormData As Dictionary(Of String, String)

    Public Event getSmartCardDetails(sender As Object, args As Dictionary(Of String, String))
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Sub New(_mainMdiForm As MainMdiForm, _state As environmentVars, _currentFormData As Dictionary(Of String, String))
        mainForm = _mainMdiForm
        state = _state
        currentFormData = _currentFormData
        'has: cardId, authString, userCode, pin

        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()

    End Sub

    Private Sub meteo_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = mainForm.state
        translations = New languageTranslations(state)

        Me.SuspendLayout()

        closeBtn.BackColor = state.buttonColor
        StartBtn.BackColor = state.buttonColor
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        StartBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

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
        nfCard = New smartCard
        Dim smartCardReaders As New List(Of String)
        Dim errMsg As String = ""

        StartBtn.Enabled = False
        readCodeOnly.Enabled = False
        cardIdCode.Visible = False
        authCode_lbl.Visible = False
        nfCard = New smartCard
        If nfCard.SelectDevice() Then
            If nfCard.GetAvailableReaders(smartCardReaders, errMsg) Then
                StartBtn.Enabled = True
                readCodeOnly.Enabled = True
                cardIdCode.Visible = True
                authCode_lbl.Visible = True
                nfCard.establishContext()
            End If
        End If
        progressBar.Value = 0
    End Sub
    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        If Not currentFormData("cardId").Equals(currentUID) Or Not currentFormData("authString").Equals(currentCode) Then
            translations.load("smartcard")
            Dim message As String = translations.getText("questionLoadValuesIntoForm")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message & " ?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msgbox.ShowDialog() = DialogResult.Yes Then
                Dim sendData As New Dictionary(Of String, String)
                sendData.Add("CardId", AddSpaces(currentUID, 3))
                sendData.Add("authString", currentCode.Substring(0, 4) & " - " & currentCode.Substring(4, 3) & " - " & currentCode.Substring(7, 5))
                RaiseEvent getSmartCardDetails(Me, sendData)
            End If
        End If
        Me.Close()
    End Sub

    Private Sub SaveAuthString_Click(sender As Object, e As EventArgs) Handles StartBtn.Click
        nfCard = New smartCard
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
                mainForm.statusMessage = "erro ao ler ID cartao"
                Exit Sub
            ElseIf nfCard.getCardUIDString().Equals("") Then
                progressBar.Value = 0
                StartBtn.Enabled = True
                readCodeOnly.Enabled = True
                mainForm.statusMessage = "erro ao ler ID vazio"
                Exit Sub
            End If

            Dim cardUID As String = nfCard.getCardUIDString()
            progressBar.Value = 50
            If cardUID.Equals(currentFormData("cardId").Replace(" ", "")) And Not currentFormData("authString").Equals("") Then
                translations.load("smartcard")
                Dim message As String = translations.getText("questionCardIsInitialized")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message, translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msgbox.ShowDialog() <> DialogResult.Yes Then
                    StartBtn.Enabled = True
                    readCodeOnly.Enabled = True
                    Exit Sub
                End If
            End If

            Dim workerCode As String = ""
            Dim rnd As New Random
            Randomize()

            If (CInt(currentFormData("userCode")) < 10) Then
                workerCode = "00" & CInt(currentFormData("userCode")).ToString
            ElseIf (CInt(currentFormData("userCode")) < 100) Then
                workerCode = "0" & CInt(currentFormData("userCode")).ToString
            Else
                workerCode = CInt(currentFormData("userCode")).ToString
            End If

            ' auth format is PIN number (4 digits) + cod_worker DB(3 digits including left zeros) + 5 digit random string for a total of 12 bytes or 3 blocks
            Dim newAuthStr As String
            If currentFormData.ContainsKey("pin") Then
                newAuthStr = currentFormData.ContainsKey("pin") & workerCode & randomString(5)
            Else
                newAuthStr = rnd.Next(1000, 10000).ToString & workerCode & randomString(5)
            End If

            If Not nfCard.SaveStringOnCard(newAuthStr, 5) Then 'Please make sure you do not write data into these Authentication Blocks 0-4 for mifare ntag 215.
                translations.load("messagebox")
                msgbox = New messageBoxForm(nfCard.errorMessage, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            currentPin = currentCode.Substring(0, 4)

            Dim sendData As New Dictionary(Of String, String)
            sendData.Add("CardId", AddSpaces(currentUID, 3))
            sendData.Add("authString", currentCode.Substring(0, 4) & " - " & currentCode.Substring(4, 3) & " - " & currentCode.Substring(7, 5))
            RaiseEvent getSmartCardDetails(Me, sendData)

        Else
            cardIdCode.Text = translations.getText("cardId") & ": - -"
            authCode_lbl.Text = translations.getText("authCode") & ": - -"
            Refresh()

            Dim sendData As New Dictionary(Of String, String)
            sendData.Add("CardId", "")
            sendData.Add("authString", "")
            RaiseEvent getSmartCardDetails(Me, sendData)

            currentUID = ""
            currentCode = ""
            currentPin = ""
        End If
        StartBtn.Enabled = True
        readCodeOnly.Enabled = True
    End Sub

    Private Sub readCodeOnly_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles readCodeOnly.LinkClicked
        nfCard = New smartCard

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
                mainForm.statusMessage = "erro ao ler ID cartao"
                Exit Sub
            ElseIf nfCard.getCardUIDString().Equals("") Then
                progressBar.Value = 0
                StartBtn.Enabled = True
                readCodeOnly.Enabled = True
                mainForm.statusMessage = "erro ao ler ID vazio"
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


