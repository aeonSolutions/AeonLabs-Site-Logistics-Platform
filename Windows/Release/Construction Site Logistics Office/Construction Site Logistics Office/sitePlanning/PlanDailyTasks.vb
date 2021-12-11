Imports System.ComponentModel
Imports System.Reflection

Public Class PlanDailyTasks_frm
    Private mask As PictureBox = Nothing
    Private loadedForm As Boolean = False
    Private updated As Boolean = False
    Private db_sites, db_sections As String(,)
    Private qtdSectionsIndex As Integer()

    Private WithEvents bwSites As BackgroundWorker

    Private Sub CloseMe()
        Me.Close()
    End Sub


    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub


    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Application.DoEvents()
        SetDoubleBuffered(tasks_datatable)


        Me.WindowState = FormWindowState.Maximized

        Me.Refresh()
    End Sub

    Private Sub PlanDailyTasks_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadedForm = False

        MainMdiForm.childForm = "planDailyTasks"
        Me.SuspendLayout()

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.Height = Me.Height
        mask.Width = Me.Width
        mask.BackColor = Color.White
        mask.Top = TopMost
        Me.Controls.Add(mask)
        mask.BringToFront()
        Application.DoEvents()
        Me.SuspendLayout()

        Dim width As Integer = Me.Width
        Dim height As Integer = Me.Height

        DateTimePicker1.CustomFormat = "HH:mm"
        DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        DateTimePicker1.ShowUpDown = True
        DateTimePicker2.CustomFormat = "HH:mm"
        DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        DateTimePicker2.ShowUpDown = True

        'DateTimePicker1.Value.TimeOfDay.ToString()

        Me.ResumeLayout()
    End Sub


    Private Sub site_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        load_list()
    End Sub

    Private Sub removeMask()
        If loadedForm Then
            Exit Sub
        End If

        loadedForm = True
        Me.SuspendLayout()

        For i As Integer = 0 To Me.Controls.Count - 1
            Me.Controls(i).Visible = True
        Next
        Me.ResumeLayout()
        mask.Dispose()

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
            MainMdiForm.busy = New BusyThread
        End If
        If MainMdiForm.busy.isActive().Equals(False) Then
            MainMdiForm.busy = New BusyThread
            MainMdiForm.busy.Show()
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
        Dim msgbox As message_box_frm

        updated = False

        Dim response_site As String = NetworkRequest(False, "get", "task=query&request=site")
        If Not IsResponseOk(response_site) Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            msgbox = New message_box_frm(GetMessage(response_site), "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            msgbox.ShowDialog()
            Me.Close()
            Exit Sub
        End If
        db_sites = ConvertDataToArray(response_site)

        Dim response_sec As String = NetworkRequest(False, "get", "task=query&request=sections")
        If Not IsResponseOk(response_sec) Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            msgbox = New message_box_frm(GetMessage(response_sec), "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            msgbox.ShowDialog()
            Me.Close()
            Exit Sub
        End If
        db_sections = ConvertDataToArray(response_sec)

        ReDim qtdSectionsIndex(UBound(db_sections))

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub bwSites_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwSites.RunWorkerCompleted
        While Not Me.IsHandleCreated
            System.Windows.Forms.Application.DoEvents()
        End While

        Dim temp As String(,)
        temp = db_sites

        site_list.Items.Clear()
        site_list.Items.Add("Seleccionar Obra")

        If Not temp(1, 1).Equals("") Then
            For i = 1 To temp.GetLength(0) - 1
                site_list.Items.Add(temp(i, 2))

            Next
        End If
        site_list.SelectedIndex = 0

        site_list.Enabled = True
        updated = True

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        removeMask()
    End Sub
End Class