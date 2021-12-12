Imports System.Drawing.Text

Public Class message_box_frm
    Private titleMsg As String
    Private messageText As String
    Private iconImage As MessageBoxIcon
    Private buttons As MessageBoxButtons
    Private translations As languageTranslations
    Private state As New State


    Public Sub New(_message As String, _title As String, _buttons As MessageBoxButtons, _icon As MessageBoxIcon, ByVal Optional posx As Integer = -1, ByVal Optional posy As Integer = -1, ByVal Optional _state As State = Nothing)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        titleMsg = _title
        messageText = _message
        iconImage = _icon
        buttons = _buttons

        Dim monitorWidth As Integer = My.Computer.Screen.WorkingArea.Size.Width
        Dim monitorHeight As Integer = My.Computer.Screen.WorkingArea.Size.Height
        posx = monitorWidth / 2
        posy = monitorHeight / 2

        Me.Location = New Point(posx - Me.Width / 2, posy - Me.Height / 2)


        If IsNothing(_state) Then
            state = setupWizard_country.state
        Else
            state = _state
        End If

        title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
            message.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
            ContinueBtn.Font = New Font(state.fontText.Families(0), state.buttonFontSize, FontStyle.Regular)
            cancelBtn.Font = New Font(state.fontText.Families(0), state.buttonFontSize, FontStyle.Regular)

    End Sub
    Private Sub message_box_frm_load(sender As Object, e As EventArgs) Handles MyBase.Load
        SuspendLayout()
        translations = New languageTranslations(state)
        translations.load("messagebox")

        Dim fontToMeasure As New Font(state.fontText.Families(0), 8, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics
        sizeOfString = g.MeasureString(titleMsg, fontToMeasure)
        title.Location = New Point(Me.Width / 2 - sizeOfString.Width / 2, title.Location.Y)
        title.Text = titleMsg
        message.Text = messageText
        Me.BackColor = Color.Honeydew
        message.BackColor = Color.Honeydew

        If iconImage.Equals(MessageBoxIcon.Information) Then
            iconBox.Image = Image.FromFile(state.imagesPath & Convert.ToString("information.png"))
        ElseIf iconImage.Equals(MessageBoxIcon.Question) Then
            iconBox.Image = Image.FromFile(state.imagesPath & Convert.ToString("question.png"))
        ElseIf iconImage.Equals(MessageBoxIcon.Warning) Then
            iconBox.Image = Image.FromFile(state.imagesPath & Convert.ToString("warning.png"))
            Me.BackColor = Color.Bisque
            message.BackColor = Color.Bisque
        ElseIf iconImage.Equals(MessageBoxIcon.Exclamation) Then
            iconBox.Image = Image.FromFile(state.imagesPath & Convert.ToString("exclamation.png"))
            Me.BackColor = Color.Bisque
            message.BackColor = Color.Bisque
        ElseIf iconImage.Equals(MessageBoxIcon.Error) Then
            iconBox.Image = Image.FromFile(state.imagesPath & Convert.ToString("error.png"))
            Me.BackColor = Color.Bisque
            message.BackColor = Color.Bisque
        End If
        iconBox.SizeMode = PictureBoxSizeMode.StretchImage

        If buttons.Equals(MessageBoxButtons.OK) Then
            ContinueBtn.Text = translations.getText("ok")
            ContinueBtn.Visible = True
            cancelBtn.Visible = False
            ContinueBtn.Location = New Point(Me.Width / 2 - ContinueBtn.Width / 2, ContinueBtn.Location.Y)
        ElseIf buttons.Equals(MessageBoxButtons.OKCancel) Then
            ContinueBtn.Text = translations.getText("ok")
            ContinueBtn.Visible = True
            cancelBtn.Text = translations.getText("cancel")
            cancelBtn.Visible = True
        ElseIf buttons.Equals(MessageBoxButtons.YesNo) Then
            ContinueBtn.Text = translations.getText("yes")
            ContinueBtn.Visible = True
            cancelBtn.Text = translations.getText("no")
            cancelBtn.Visible = True
        ElseIf buttons.Equals(MessageBoxButtons.RetryCancel) Then
            ContinueBtn.Text = translations.getText("retry")
            ContinueBtn.Visible = True
            cancelBtn.Text = translations.getText("cancel")
            cancelBtn.Visible = True
        End If
        ResumeLayout()
        Refresh()

    End Sub


    Private Sub message_box_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        If buttons.Equals(MessageBoxButtons.OK) Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        ElseIf buttons.Equals(MessageBoxButtons.OKCancel) Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        ElseIf buttons.Equals(MessageBoxButtons.YesNo) Then
            Me.DialogResult = Windows.Forms.DialogResult.No
        ElseIf buttons.Equals(MessageBoxButtons.RetryCancel) Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
        Me.Close()
    End Sub

    Private Sub ContinueBtn_Click(sender As Object, e As EventArgs) Handles ContinueBtn.Click
        If buttons.Equals(MessageBoxButtons.OK) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        ElseIf buttons.Equals(MessageBoxButtons.OKCancel) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        ElseIf buttons.Equals(MessageBoxButtons.YesNo) Then
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        ElseIf buttons.Equals(MessageBoxButtons.RetryCancel) Then
            Me.DialogResult = Windows.Forms.DialogResult.Retry
        End If

        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub message_TextChanged(sender As Object, e As EventArgs) Handles message.TextChanged

    End Sub

End Class