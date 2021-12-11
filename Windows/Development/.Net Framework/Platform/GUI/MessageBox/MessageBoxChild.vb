Imports System.Windows.Forms
Imports System.Drawing
Imports System.Resources
Public Class MessageBoxChild
    Private titleMsg As String
    Private messageText As String
    Private iconImage As MessageBoxIcon
    Private buttons As MessageBoxButtons
    Private enVars As New AeonLabs.Environment.environmentVarsCore
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property
    Public Sub New(_message As String, _title As String, _buttons As MessageBoxButtons, _icon As MessageBoxIcon, ByVal Optional posx As Integer = -1, ByVal Optional posy As Integer = -1, ByVal Optional _state As AeonLabs.Environment.environmentVarsCore = Nothing)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()

        titleMsg = _title
        messageText = _message
        iconImage = _icon
        buttons = _buttons



        If IsNothing(_state) Then
            enVars = New AeonLabs.Environment.environmentVarsCore
            enVars.loadEnvironmentcoreDefaults()
        Else
            enVars = _state
        End If

        title.Font = New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.DialogTitleFontSize, FontStyle.Bold)
        message.Font = New Font(enVars.layoutDesign.fontText.Families(0), enVars.layoutDesign.RegularTextFontSize, FontStyle.Regular)
        ContinueBtn.Font = New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.buttonFontSize, FontStyle.Bold)
        cancelBtn.Font = New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.buttonFontSize, FontStyle.Bold)
        ContinueBtn.BackColor = Color.FromArgb(200, Color.Black)
        ContinueBtn.Parent = AlphaGradientPanel1
        ContinueBtn.Location = New Point(40, Me.Height - 10 - ContinueBtn.Height)
        cancelBtn.BackColor = Color.FromArgb(200, Color.Black)
        cancelBtn.Parent = AlphaGradientPanel1
        cancelBtn.Location = New Point(Me.Width - 40 - cancelBtn.Width, Me.Height - 10 - cancelBtn.Height)
    End Sub

    Private Sub message_box_frm_load(sender As Object, e As EventArgs) Handles MyBase.Load
        SuspendLayout()


        title.Text = titleMsg
        Dim fontToMeasure As New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.DialogTitleFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics
        sizeOfString = g.MeasureString(titleMsg, fontToMeasure)
        title.Location = New Point(Me.Width / 2 - sizeOfString.Width / 2, title.Location.Y)

        fontToMeasure = New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.RegularTextFontSize, Drawing.FontStyle.Regular)
        sizeOfString = New SizeF
        g = Me.CreateGraphics
        sizeOfString = g.MeasureString("_", fontToMeasure)
        message.Text = messageText

        Dim numLines As Integer = CInt(messageText.Length / (message.Width / sizeOfString.Width)) + 1
        message.Height = numLines * sizeOfString.Height

        If iconImage.Equals(MessageBoxIcon.Information) Then
            Try
                iconBox.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("information.png"))
            Catch ex As Exception

            End Try
        ElseIf iconImage.Equals(MessageBoxIcon.Question) Then
            Try
                iconBox.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("question.png"))
            Catch ex As Exception

            End Try
        ElseIf iconImage.Equals(MessageBoxIcon.Warning) Then
            Try
                iconBox.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("warning.png"))
            Catch ex As Exception

            End Try
        ElseIf iconImage.Equals(MessageBoxIcon.Exclamation) Then
            Try
                iconBox.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("exclamation.png"))
            Catch ex As Exception

            End Try
        ElseIf iconImage.Equals(MessageBoxIcon.Error) Then
            Try
                iconBox.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("error.png"))
            Catch ex As Exception

            End Try
        End If
        iconBox.SizeMode = PictureBoxSizeMode.StretchImage
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(enVars.currentLang)

        If buttons.Equals(MessageBoxButtons.OK) Then
            ContinueBtn.Visible = True
            cancelBtn.Visible = False
            ContinueBtn.Location = New Point(Me.Width / 2 - ContinueBtn.Width / 2, ContinueBtn.Location.Y)
        ElseIf buttons.Equals(MessageBoxButtons.OKCancel) Then
            ContinueBtn.Text = My.Resources.strings.ok
            ContinueBtn.Visible = True
            cancelBtn.Text = My.Resources.strings.cancel
            cancelBtn.Visible = True
        ElseIf buttons.Equals(MessageBoxButtons.YesNo) Then
            ContinueBtn.Text = My.Resources.strings.yes
            ContinueBtn.Visible = True
            cancelBtn.Text = My.Resources.strings.no
            cancelBtn.Visible = True
        ElseIf buttons.Equals(MessageBoxButtons.RetryCancel) Then
            ContinueBtn.Text = My.Resources.strings.retry
            ContinueBtn.Visible = True
            cancelBtn.Text = My.Resources.strings.cancel
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

    Private Sub AlphaGradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles AlphaGradientPanel1.Paint

    End Sub

End Class