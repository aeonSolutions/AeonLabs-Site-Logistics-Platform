Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Threading
Imports ConstructionSiteLogistics.Libraries.Core

Public Class waiting_frm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private holdOnTimeMessage As String = ""
    Private setTitleTxt As String = ""
    Private setMessageTxt As String = ""
    Private previousTitleTxt As String = ""
    Private previousMessageTxt As String = ""

    Private loaded = False
    Private time As Integer
    Private waitingTimer As System.Timers.Timer = Nothing
    Private loadTimer As System.Timers.Timer = Nothing
    Private tsk As Task
    Private cts As New CancellationTokenSource
    Private token As CancellationToken = cts.Token
    Private waiting As Boolean
    Private mainform As MainMdiForm
    Public isClosed As Boolean
    Public isCheckingConnection As Boolean = False
    Private WithEvents bwCheckConnection As BackgroundWorker

    Private Sub waiting_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Me.Location = New Point(mainForm.Location.X + mainForm.Width / 2 - Me.Width / 2, mainForm.Location.Y + mainForm.Height / 2 - Me.Height / 2)
        stateCore = New environmentVars(LOAD_SETTINGS)
        translations = New languageTranslations(stateCore)
        isCheckingConnection = False
        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, FontStyle.Bold)
        message.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        translations.load("waitingDialog")
        If setTitleTxt.Equals("") Then
            setTitleTxt = translations.getText("titleServer")
            title.Text = translations.getText("titleServer")
            previousTitleTxt = translations.getText("titleServer")
        Else
            title.Text = setTitleTxt
        End If
        If setMessageTxt.Equals("") Then
            previousMessageTxt = translations.getText("waitAmoment")
            setMessageTxt = translations.getText("waitAmoment")
            message.Text = translations.getText("waitAmoment")
        Else
            message.Text = setMessageTxt
            previousMessageTxt = setMessageTxt
        End If


        holdOnTimeMessage = translations.getText("holdOnTimeMessage")
        translations.load("commonForm")
        isClosed = False
    End Sub
    Private Sub loadDataUI()
        translations.load("waitingDialog")
        If setTitleTxt.Equals("") Then
            setTitle(translations.getText("title"))
        Else
            setTitle(setTitleTxt)
        End If
        If setMessageTxt.Equals("") Then
            setMessage(translations.getText("waitAmoment") & "...")
        Else
            setMessage(setMessageTxt)
        End If
    End Sub
    Private Sub waiting_frm_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        waiting = False
        startTesting()
        Me.Refresh()
    End Sub

    Public Sub New(_mainForm As MainMdiForm, ByVal Optional title As String = "", ByVal Optional message As String = "")
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        mainForm = _mainForm
        setTitleTxt = title
        setMessageTxt = message
        Me.ControlBox = False
        loaded = False
    End Sub

    Public Sub Start(ByVal Optional text As String = "")
        System.Threading.Tasks.Task.Run(Sub()
                                            Me.title.Text = text
                                            Me.isClosed = False
                                            Me.LoadingDelay.Start()
                                            Me.UpdateMessage.Start()
                                            If Not Me.IsDisposed Then
                                                Me.ShowDialog()
                                            End If
                                        End Sub)
    End Sub

    Public Sub [Stop]()
        While Not loaded Or Not Me.IsHandleCreated
        End While
        If Me.IsHandleCreated Then
            BeginInvoke(CType(Sub()
                                  Me.isClosed = True
                                  Me.Dispose(True)
                              End Sub, Action))
        Else
            Me.Dispose(True)
            Me.isClosed = True
        End If
    End Sub

    Public Sub ChangeText(ByVal newText As String)
        BeginInvoke(CType(Sub()
                              Me.Text = newText
                          End Sub, Action))
    End Sub
    Public Sub setMessage(text As String)
        setMessageTxt = text
    End Sub
    Public Sub setTitle(text As String)
        setTitleTxt = text
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles LoadingDelay.Tick
        loaded = True
    End Sub

    Private Sub UpdateMessage_Tick(sender As Object, e As EventArgs) Handles UpdateMessage.Tick
        Static start As Double
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If Not previousMessageTxt.Equals(setMessageTxt) Or Not previousTitleTxt.Equals(setTitleTxt) Then
            BeginInvoke(CType(Sub()
                                  message.Text = setMessageTxt
                                  title.Text = setTitleTxt
                              End Sub, Action))
        End If
    End Sub

    Private Sub bwCheckConnection_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwCheckConnection.DoWork

        translations.load("waitingDialog")
        mainForm.statusMessage = translations.getText("checkingConnection")
        Dim objUrl As New System.Uri(stateCore.ServerBaseAddr)
        e.Result = True

        Try
            If My.Computer.Network.Ping(objUrl) Then
                While Not loaded
                End While
                mainForm.statusMessage = translations.getText("serverOnline")
                isCheckingConnection = False
                e.Result = False

                If Not IsNothing(waitingTimer) Then
                    If waitingTimer.Enabled Then
                        waitingTimer.Enabled = False
                    End If
                End If
                Exit Sub
            Else
                mainForm.statusMessage = translations.getText("serverOffline")
            End If
        Catch ex As Exception
            mainForm.statusMessage = translations.getText("serverOffline")
        End Try
    End Sub

    Private Sub bwCheckConnection_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwCheckConnection.RunWorkerCompleted
        If e.Result.Equals(True) Then
            waitingTimer = New System.Timers.Timer(1000)
            AddHandler waitingTimer.Elapsed, AddressOf waitingTimerHandler
            waitingTimer.AutoReset = True
            waitingTimer.Enabled = True
            waitingTimer.Start()
        Else
            loadDataUI()
        End If
    End Sub

    Private Sub startTesting()
        If bwCheckConnection IsNot Nothing Then
            If bwCheckConnection.IsBusy Then
                bwCheckConnection.CancelAsync()
            End If
        End If

        bwCheckConnection = New BackgroundWorker()
        bwCheckConnection.WorkerSupportsCancellation = True
        bwCheckConnection.RunWorkerAsync()
    End Sub

    Sub waitingTimerHandler(ByVal sender As Object, ByVal e As EventArgs)
        If Not isCheckingConnection Then
            waitingTimer.Enabled = False
            Exit Sub
        End If
        If Not Me.IsHandleCreated Then
            Exit Sub
        End If
        If time < 1 Then
            Me.Invoke(Sub()
                          Me.BackColor = Color.Beige
                      End Sub)
            message.Invoke(Sub()
                               message.Text = translations.getText("waitAmoment")
                           End Sub)
            waitingTimer.Stop()
            time = 20
            startTesting()
            Exit Sub
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
End Class