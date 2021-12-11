Imports System.Threading
Imports System.Drawing.Text

Public Class waitingServer
    Private state As State
    Private translations As languageTranslations
     
    Private setTitle As String = ""
    Private time As Integer
    Private t, loadTimer As System.Timers.Timer
    Private holdOnTimeMessage As String = ""
    Private tsk As Task
    Private cts As New CancellationTokenSource
    Private token As CancellationToken = cts.Token
    Private waiting As Boolean
    Private loaded = False


    Public Sub New(ByVal Optional text As String = "")
        setTitle = text
        InitializeComponent()
        Me.ControlBox = False
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close()
                waiting = True
            End If
        End If
        loaded = False
    End Sub

    Private Sub waiting_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Me.Location = New Point(mainMdiForm.Location.X + mainMdiForm.Width / 2 - Me.Width / 2, mainMdiForm.Location.Y + mainMdiForm.Height / 2 - Me.Height / 2)
        Me.SuspendLayout()
        state = MainMdiForm.state
        translations = New languageTranslations(state)
         
         
        title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        message.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        translations.load("waitingDialog")
        If setTitle.Equals("") Then
            title.Text = translations.getText("titleServer")
        Else
            title.Text = Text
        End If
        message.Text = translations.getText("waitAmoment")
        holdOnTimeMessage = translations.getText("holdOnTimeMessage")
        translations.load("commonForm")
        cancelLink.Text = translations.getText("cancelBtn")
        Me.ResumeLayout()
        Me.Refresh()
    End Sub

    Private Sub waitingServer_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        waiting = False
        t = New System.Timers.Timer(1000)
        startTesting()
        Me.Refresh()
    End Sub


    Public Sub ChangeText(ByVal newText As String)
        BeginInvoke(CType(Sub()
                              Me.Text = newText
                          End Sub, Action))
    End Sub
    Public Sub setMessage(text As String)
        setTitle = text
    End Sub



    Private Sub startTesting()
        cts = New CancellationTokenSource
        token = cts.Token
        tsk = New Task(Sub() _startTesting(token), token)
        tsk.Start()
    End Sub

    Private Sub _startTesting(token As CancellationToken)
        If token.IsCancellationRequested Then
            token.ThrowIfCancellationRequested()
            Exit Sub
        End If
        If Not loaded Then
            loadTimer = New System.Timers.Timer(2000)
            AddHandler loadTimer.Elapsed, AddressOf loadTimerTickHandler
            loadTimer.AutoReset = True
            loadTimer.Enabled = True
            loadTimer.Start()
        End If
        translations.load("waitingDialog")
        MainMdiForm.statusMessage = translations.getText("checkingConnection")

        Dim objUrl As New System.Uri(state.ServerBaseAddr)

        If Not IsNothing(t) Then
            t.Stop()
            t = New System.Timers.Timer(1000)
        End If

        Try
            If My.Computer.Network.Ping(objUrl) Then
                While Not loaded
                End While
                MainMdiForm.statusMessage = translations.getText("serverOnline")

                Me.Invoke(Sub()
                              Me.DialogResult = Windows.Forms.DialogResult.OK
                              Me.Close()
                              If Not IsNothing(MainMdiForm.busy) Then
                                  If MainMdiForm.busy.isActive().Equals(False) And waiting Then
                                      MainMdiForm.busy.Show()
                                      waiting = False
                                  End If
                              End If
                          End Sub)
                Exit Sub
            Else

                MainMdiForm.statusMessage = translations.getText("serverOffline")

            End If
        Catch ex As Exception
            MainMdiForm.statusMessage = translations.getText("serverOffline")
        End Try

        AddHandler t.Elapsed, AddressOf MyTickHandler
        t.AutoReset = True
        t.Enabled = True
        t.Start()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles cancelLink.Click
        Try
            message.Text = translations.getText("cancelling") & " ..."
            message.Refresh()
            time = 0
            cts.Cancel()
            While Not tsk.IsCanceled()

            End While
            tsk.Dispose()
        Catch ex As Exception
            MainMdiForm.statusMessage = ex.ToString
        Finally
            cts.Dispose()
        End Try
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) And waiting Then
                MainMdiForm.busy.Show()
                waiting = False
            End If
        End If
    End Sub


    Sub MyTickHandler(ByVal sender As Object, ByVal e As EventArgs)
        If cts.IsCancellationRequested Then
            Exit Sub
        End If
        If time < 1 Then
            Me.Invoke(Sub()
                          Me.BackColor = Color.Beige
                      End Sub)
            message.Invoke(Sub()
                               message.Text = translations.getText("waitAmoment")
                           End Sub)
            t.Stop()
            time = 20
            startTesting()
        Else
            Me.Invoke(Sub()
                          Me.BackColor = Color.LightSalmon
                      End Sub)
            message.Invoke(Sub()
                               message.Text = holdOnTimeMessage & " " & time & " s..."
                           End Sub)
        End If
        time = time - 1
    End Sub

    Sub loadTimerTickHandler(ByVal sender As Object, ByVal e As EventArgs)
        loaded = True
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

End Class