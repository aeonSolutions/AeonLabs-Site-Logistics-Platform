Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frm_locate_worker
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
     
    Public works_worker As Dictionary(Of String, List(Of String))

    Private response, response2 As String
    Private mask As PictureBox = Nothing

    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()

    End Sub


    Private Sub frm_locate_worker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        Me.Controls.Add(mask)
        mask.BringToFront()
        Me.SuspendLayout()

         
         
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor
        workerGroupBox.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        divider.BackColor = state.dividerColor
        title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        seeInfo.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")
        seeInfo.Text = translations.getText("viewInfoLink")
        translations.load("workers")
        workerGroupBox.Text = translations.getText("workerInfo")
        title.Text = translations.getText("locateWorkerTitle")

        photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & "worker.png")
        photobox.SizeMode = PictureBoxSizeMode.StretchImage

        contents.Text = ""
        Me.ResumeLayout()
    End Sub

    Private Sub frm_locate_worker_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        load_list()

    End Sub

    Sub load_list()
        Dim checkConnection As waitingServer = New waitingServer()
        If Not (checkConnection.ShowDialog = DialogResult.OK) Then
            While Not Me.IsHandleCreated
                Application.DoEvents()
            End While
            Me.BeginInvoke(New MethodInvoker(AddressOf CloseMe))
            MainMdiForm.NoNetwork()
            Exit Sub
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If
        If Not IsNothing(bwSites) Then
            If bwSites.IsBusy Then
                bwSites.CancelAsync()
            End If
        End If

        bwSites = New BackgroundWorker()
        bwSites.WorkerSupportsCancellation = True
        bwSites.RunWorkerAsync()
    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "workers")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        works_worker = request.ConvertDataToArray("workers", state.queryWorkersFields, response)
        If IsNothing(works_worker) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
lastLine:
        Dim s(1) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = ""
            e.Result = s
        End If
    End Sub

    Private Sub bwSites_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwSites.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        listview_works.Items.Clear()
        For i = 0 To works_worker.Item("cod_worker").Count - 1
            listview_works.Items.Add(works_worker.Item("name")(i))
        Next i

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        removeMask()
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub removeMask()
        If loaded Then
            Exit Sub
        End If

        loaded = True
        Me.SuspendLayout()

        For i As Integer = 0 To Me.Controls.Count - 1
            Me.Controls(i).Visible = True
        Next
        Me.ResumeLayout()
        mask.Dispose()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles searchBoxBtn.Click
        DropClickSearchBox(searchBoxBtn)
        doSearchWorkers(0, True, False, works_worker, listview_works, searchbox.Text.ToString)
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles seeInfo.LinkClicked
        If listview_works.SelectedIndex > -1 Then
            Dim vars As New Dictionary(Of String, String)
            Dim errorFlag As Boolean = False
            Dim errorMsg As String = ""

            vars.Add("task", "27") 'workerdetails
            vars.Add("cod", works_worker.Item("cod_worker")(listview_works.SelectedIndex))
            Dim request As New HttpData(state)
            Dim response As String = request.RequestData(vars)
            translations.load("workers")
            Try
                Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
                Dim jsonarray As JArray = JArray.Parse(jsonResult.Item("data").ToString)
                contents.Text = jsonarray(0).Item("name").ToString & Environment.NewLine & Environment.NewLine _
                    & translations.getText("contact") & ": " & jsonarray(0).Item("contacto").ToString & Environment.NewLine _
                    & translations.getText("emergencyContact") & ": " & jsonarray(0).Item("emergencia").ToString & Environment.NewLine _
                    & translations.getText("email") & ": " & jsonarray(0).Item("email").ToString & Environment.NewLine _
                    & translations.getText("companyIdCard") & ": " & AddSpaces(jsonarray(0).Item("cartao").ToString, 3) & Environment.NewLine & Environment.NewLine _
                    & translations.getText("todaySite") & ": " & Environment.NewLine & jsonarray(0).Item("site").ToString.Replace("[newline]", Environment.NewLine) & Environment.NewLine _
                    & jsonarray(0).Item("address").ToString.Replace("[newline]", Environment.NewLine)

                If jsonarray(0).Item("photo").ToString.Equals("") Then
                    photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("worker.png"))
                Else
                    photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("loading.png"))
                    photobox.SizeMode = PictureBoxSizeMode.StretchImage
                    Dim tClient As WebClient = New WebClient
                    Try
                        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/works/photos/" & jsonarray(0).Item("photo").ToString)))
                        photobox.Image = tImage
                    Catch ex As Exception
                        photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & "worker.png")
                        translations.load("errorMessages")
                        MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
                    End Try
                    photobox.SizeMode = PictureBoxSizeMode.StretchImage
                End If
                translations.load("workers")

                contents.Text = contents.Text & Environment.NewLine & Environment.NewLine & translations.getText("thisMonthAlreadyWorked") & ":" & Environment.NewLine
                If jsonarray(0).Item("sites") IsNot Nothing Then
                    For Each sites In jsonarray(0).Item("sites")
                        contents.Text = contents.Text & sites.Item("name").ToString & Environment.NewLine
                    Next sites
                Else
                    contents.Text = contents.Text & translations.getText("noRecordOtherSites")
                End If


            Catch ex As Exception
                MainMdiForm.statusMessage = ex.Message.ToString
                saveCrash(ex)
            End Try
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
        End If
    End Sub

    Public Function IsNullOrEmpty(token As JToken) As Boolean

        Return (token.Equals(Nothing)) Or (token.Type.Equals(JTokenType.Array) And Not token.HasValues) Or (token.Type.Equals(JTokenType.Object) And Not token.HasValues) Or (token.Type.Equals(JTokenType.String) And token.ToString().Equals(String.Empty)) Or (token.Type.Equals(JTokenType.Null))
    End Function
    Private Sub ListView_works_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles listview_works.DrawItem
        e.DrawBackground()
        Dim selected As Boolean = False
        If e.Index > 0 Then
            If String.Compare(listview_works.Items(e.Index).ToString.Substring(0, 1).ToLower, listview_works.Items(e.Index - 1).ToString.Substring(0, 1).ToLower, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) Then
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.WhiteSmoke)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            Else
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.White)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            End If
        Else
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.WhiteSmoke)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            selected = True
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.Honeydew)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If
        Dim ForeColor As Color = Color.Black
        If selected Then
            ForeColor = Color.DarkGreen
        End If
        Using b As New SolidBrush(ForeColor)
            If Not IsNothing(listview_works) Then
                If listview_works.Items.Count > 0 Then
                    e.Graphics.DrawString(listview_works.GetItemText(listview_works.Items(e.Index)), e.Font, b, e.Bounds)
                End If
            End If
        End Using
        e.DrawFocusRectangle()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub listview_works_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listview_works.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub
End Class