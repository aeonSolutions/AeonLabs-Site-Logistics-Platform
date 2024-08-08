Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class holidays_frm
    Private state As New environmentVars
    Private translations As languageTranslations

    Private msgbox As messageBoxForm


    Private holidays As Dictionary(Of String, List(Of String))
    Private response As String = ""
    Private WithEvents bwSites As BackgroundWorker

    Private mainForm As MainMdiForm

    Public Sub New(_mainMdiForm As MainMdiForm, _state As environmentVars)
        mainForm = _mainMdiForm
        state = _state
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()
    End Sub

    Private Sub holidays_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        translations = New languageTranslations(state)
        Me.SuspendLayout()



        title.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        updateLink.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        add.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        remove.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        ListView_holidays.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        calendar.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor
        divider.BackColor = state.dividerColor

        translations.load("holidaysDialog")
        title.Text = translations.getText("title")
        translations.load("commonForm")
        updateLink.Text = translations.getText("updateLink")
        add.Text = translations.getText("addLink")
        remove.Text = translations.getText("removeLink")
        closeBtn.Text = translations.getText("closeBtn")

        ListView_holidays.Height = calendar.Height
        remove.Location = New Point(ListView_holidays.Location.X + ListView_holidays.Width - remove.Width, remove.Location.Y)
        add.Location = New Point(calendar.Location.X + calendar.Width - add.Width, add.Location.Y)
        Me.ResumeLayout()
    End Sub

    Private Sub holidays_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        load_list()
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles updateLink.LinkClicked
        load_list()
    End Sub

    Sub load_list()

        mainForm.busy.Show()
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
        vars.Add("request", "holidays")
        vars.Add("startdate", "null")
        vars.Add("enddate", "null")
        Dim request As New HttpDataCore(state)
        Dim response As String = "" ''request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        holidays = request.ConvertDataToArray("holidays", state.queryHolidaysFields, response)
        If IsNothing(holidays) Then
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
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        ListView_holidays.Items.Clear()
        For i = 0 To holidays.Item("date").Count - 1
            ListView_holidays.Items.Add(holidays.Item("date")(i))
        Next i

        mainForm.busy.Close(True)
    End Sub



    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles remove.LinkClicked
        Dim cod_worker As String = ""
        Dim msgbox As messageBoxForm

        If ListView_holidays.SelectedItems.Count = 0 Then
            translations.load("EditRegieDialog")
            Dim message3 As String = translations.getText("errorSelectDate")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        translations.load("EditRegieDialog")
        Dim message2 As String = translations.getText("removeRecordQuestion")
        translations.load("messagebox")
        msgbox = New messageBoxForm(message2 & "? ", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If (msgbox.ShowDialog = DialogResult.Yes) Then
            'remover da DB
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "9")
            vars.Add("type", "del")
            vars.Add("date", Convert.ToDateTime(ListView_holidays.SelectedItems(0).ToString).ToString("yyyy-MM-dd"))
            Dim request As New HttpDataCore(state)
            Dim response As String = "" ''request.RequestData(vars)
            mainForm.busy.Close(True)
            If Not IsResponseOk(response) Then
                translations.load("messagebox")
                msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        End If
        load_list()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles add.LinkClicked
        add_date()

        load_list()
    End Sub



    Sub add_date()

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "9")
        vars.Add("type", "add")
        vars.Add("date", calendar.SelectionStart.ToString("yyyy-MM-dd"))
        Dim request As New HttpDataCore(state)
        Dim response As String = "" ''request.RequestData(vars)
        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If

        mainForm.busy.Close(True)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class