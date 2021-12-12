Imports System.Drawing.Text

Public Class waiting_frm
    Private state As State
    Private translations As languageTranslations

    Private setTitleTxt As String = ""
    Private setMessageTxt As String = ""

    Public isClosed As Boolean
    Private loaded = False

    Private Sub waiting_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Me.Location = New Point(mainMdiForm.Location.X + mainMdiForm.Width / 2 - Me.Width / 2, mainMdiForm.Location.Y + mainMdiForm.Height / 2 - Me.Height / 2)
        Me.SuspendLayout()

        state = setupWizard_country.state

        translations = New languageTranslations(state)
         
         
        title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        message.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        translations.load("waitingDialog")
        If setTitleTxt.Equals("") Then
            title.Text = translations.getText("title")
            setTitleTxt = translations.getText("title")
        Else
            title.Text = setTitleTxt
        End If
        If setMessagetxt.Equals("") Then
            message.Text = translations.getText("waitAmoment") & "..."
            setMessageTxt = translations.getText("waitAmoment") & "..."
        Else
            message.Text = setMessagetxt
        End If

        Me.ResumeLayout()
        Me.Refresh()
        isClosed = False

    End Sub

    Private Sub waiting_frm_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Refresh()

    End Sub

    Public Sub New(ByVal Optional title As String = "", ByVal Optional message As String = "")
        InitializeComponent()
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
        While Not loaded
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
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

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
            '//MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        BeginInvoke(CType(Sub()
                              message.Text = setMessageTxt
                              title.Text = setTitleTxt
                          End Sub, Action))
    End Sub
End Class