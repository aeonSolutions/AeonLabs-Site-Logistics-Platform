Imports System.Runtime.InteropServices

Partial Public Class FormCustomized
    Inherits Form
    Implements IMessageFilter


#Region "Variables"
    ''' <summary>
    ''' The opacity the form is transitioning to.
    ''' </summary>
    Private f_TargetOpacity As Double

    ''' <summary>
    ''' The time it takes to fade from 0 to 1 or the other way around.
    ''' </summary>
    Private f_FadeTime = 0.5

    ''' <summary>
    ''' The opacity that the form will transition to when the form gets focus.
    ''' </summary>
    Private f_ActiveOpacity As Double = 1

    ''' <summary>
    ''' the opacity that the form will transition to when the form doesn't have focus.
    ''' </summary>
    Private f_InactiveOpacity = 0.85

    ''' <summary>
    ''' the opacity that the form will transition to when the form is minimized.
    ''' </summary>
    Private f_MinimizedOpacity As Double = 0

    ''' <summary>
    ''' WindowsMessage that is being held until the end of a transition.
    ''' </summary>
    Private heldMessage As Message = New Message()

    ''' <summary>
    ''' Timer to aid in fade effects.
    ''' </summary>
    Private FadeFxTimer As Timer

    '''inactivity timer code auto logout
    Private inActivity As Stopwatch = Nothing
    Private WithEvents timerInactivity As New Timer
    Public Property InactivityTimeOut As New TimeSpan(0, 15, 0)
    Public Event InactivityDetected(sender As Object)
    Private isFormLoading As Boolean = True

#End Region

#Region "Properties"
    ''' <summary>
    ''' The opacity the form is transitioning to.
    ''' </summary>
    Public Property TargetOpacity As Double
        Set(ByVal value As Double)
            f_TargetOpacity = value
        End Set
        Get
            Return f_TargetOpacity
        End Get
    End Property

    ''' <summary>
    ''' The time it takes to fade from 1 to 0 or the other way around.
    ''' </summary>
    Public Property FadeTime As Double
        Get
            Return f_FadeTime
        End Get
        Set(ByVal value As Double)
            If value > 0 Then
                f_FadeTime = value
            Else
                Throw New ArgumentOutOfRangeException("The FadeTime must be a positive value")
            End If
        End Set
    End Property

    ''' <summary>
    ''' The opacity that the form will transition to when the form gets focus.
    ''' </summary>
    Public Property ActiveOpacity As Double
        Get
            Return f_ActiveOpacity
        End Get
        Set(ByVal value As Double)

            If value >= 0 Then
                f_ActiveOpacity = value
            Else
                Throw New ArgumentOutOfRangeException("The ActiveOpacity must be a positive value")
            End If

            If ContainsFocus Then
                TargetOpacity = f_ActiveOpacity
            End If
        End Set
    End Property

    ''' <summary>
    ''' the opacity that the form will transition to when the form doesn't have focus.
    ''' </summary>
    Public Property InactiveOpacity As Double
        Get
            Return f_InactiveOpacity
        End Get
        Set(ByVal value As Double)

            If value >= 0 Then
                f_InactiveOpacity = value
            Else
                Throw New ArgumentOutOfRangeException("The InactiveOpacity must be a positive value")
            End If

            If Not ContainsFocus AndAlso WindowState <> FormWindowState.Minimized Then
                TargetOpacity = f_InactiveOpacity
            End If
        End Set
    End Property

    ''' <summary>
    ''' the opacity that the form will transition to when the form is minimized.
    ''' </summary>
    Public Property MinimizedOpacity As Double
        Get
            Return f_MinimizedOpacity
        End Get
        Set(ByVal value As Double)

            If value >= 0 Then
                f_MinimizedOpacity = value
            Else
                Throw New ArgumentOutOfRangeException("The MinimizedOpacity must be a positive value")
            End If

            If Not ContainsFocus AndAlso WindowState <> FormWindowState.Minimized Then
                TargetOpacity = f_InactiveOpacity
            End If
        End Set
    End Property
#End Region

#Region "CustomMessageFilter"
    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        If m.Msg = &H20A Then
            Dim pos As Point = New Point(m.LParam.ToInt32())
            Dim hWnd As IntPtr = WindowFromPoint(pos)

            If hWnd <> IntPtr.Zero AndAlso hWnd <> m.HWnd AndAlso Control.FromHandle(hWnd) IsNot Nothing Then
                SendMessage(hWnd, m.Msg, m.WParam, m.LParam)
                Return True
            End If
        End If

        Return False
    End Function

    <DllImport("user32.dll")>
    Private Shared Function WindowFromPoint(ByVal pt As Point) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr
    End Function
#End Region

#Region "CONSTRUCTORS"
    ''' <summary>
    ''' Creates a new FormCustomized.
    ''' </summary>
    Public Sub New()
        isFormLoading = True
        SuspendLayout()

        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        '' SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.UpdateStyles()

        ResumeLayout()

        'fade in / out FX
        FadeFxTimer = New Timer()
        FadeFxTimer.Interval = 25
        AddHandler FadeFxTimer.Tick, New EventHandler(AddressOf timer_Tick)
        AddHandler Deactivate, New EventHandler(AddressOf FormCustomized_Deactivate)
        AddHandler Activated, New EventHandler(AddressOf FormCustomized_Activated)
        AddHandler Load, New EventHandler(AddressOf FormCustomized_Load)

        enableFadeFXandInacivityDetection()
    End Sub
#End Region

#Region "FADE IN/OUT FORM FX PLUS INACTIVITY"
    Public Sub enableFadeFXandInacivityDetection()
        inActivity = New Stopwatch
        'inactivity detection
        resetActivity()
        timerInactivity.Interval = 60 * 1000 'check every 1 second for new messages from the OS
        timerInactivity.Start()
        inActivity.Reset()
        inActivity.Start()

        'fade FX
        If Not FadeFxTimer.Enabled Then FadeFxTimer.Start()
    End Sub

    ''' <summary>
    ''' Turns off opacitiy fading.
    ''' </summary>
    Public Sub DisableFade()
        f_ActiveOpacity = 1
        f_InactiveOpacity = 1
        f_MinimizedOpacity = 1
    End Sub

    ''' <summary>
    ''' Turns on opacitiy fading.
    ''' </summary>
    Public Sub EnableFadeDefaults()
        f_ActiveOpacity = 1
        f_InactiveOpacity = 0.85
        f_MinimizedOpacity = 0
        f_FadeTime = 0.1
    End Sub
#End Region

#Region "inacitvity detection"
    Private Sub timerInactivity_tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerInactivity.Tick
        If inActivity.Elapsed > InactivityTimeOut Then
            RaiseEvent InactivityDetected(Me)
        End If
    End Sub
#End Region

#Region "WindowsMessageCodes"
    Private Const WM_SYSCOMMAND = &H112
    Private Const WM_COMMAND = &H111
    Private Const SC_MINIMIZE = &HF020
    Private Const SC_RESTORE = &HF120
    Private Const SC_CLOSE = &HF060
#End Region

#Region "misc"
    Public Property mbDoPaintBackground As Boolean
    Private Const CUSTOM_WM_SYSCOMMAND = &H112
    Private Const WM_MAXBUTTONSomethingSomething As Integer = &HF030  '61488
    Private Const WM_MINBUTTONSomethingSomething As Integer = &HF120   '61728

    ''' <summary>
    ''' Intercepts WindowMessages before they are processed.
    ''' </summary>
    Protected Overrides Sub WndProc(ByRef m As Message)
        'Traps specifically for "Maximize" button
        Try
            If m.Msg = CUSTOM_WM_SYSCOMMAND Then     'to address flickering on maximize form
                ' Handle running on 64-bit platforms
                Dim param As Long
                If (IntPtr.Size = 4) Then
                    param = CLng(m.WParam.ToInt32)
                Else
                    param = CLng(m.WParam.ToInt64)
                End If

                If CInt(param) = WM_MAXBUTTONSomethingSomething Then
                    mbDoPaintBackground = False
                ElseIf CInt(param) = WM_MINBUTTONSomethingSomething Then
                    mbDoPaintBackground = False
                End If
            ElseIf m.Msg = FormCustomized.WM_SYSCOMMAND OrElse m.Msg = FormCustomized.WM_COMMAND Then
                'Fade to zero on minimze
                If m.WParam = CType(FormCustomized.SC_MINIMIZE, IntPtr) Then
                    If heldMessage.WParam <> CType(FormCustomized.SC_MINIMIZE, IntPtr) Then
                        heldMessage = m
                        TargetOpacity = f_MinimizedOpacity
                    Else
                        heldMessage = New Message()
                        TargetOpacity = f_ActiveOpacity
                    End If

                    Exit Sub
                    'Fade in if the window is restored from the taskbar
                ElseIf m.WParam = CType(FormCustomized.SC_RESTORE, IntPtr) AndAlso WindowState = FormWindowState.Minimized Then
                    MyBase.WndProc(m)
                    TargetOpacity = f_ActiveOpacity
                    Exit Sub

                    'Fade out if the window is closed.
                ElseIf m.WParam = CType(FormCustomized.SC_CLOSE, IntPtr) Then
                    heldMessage = m
                    TargetOpacity = f_MinimizedOpacity
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
        'Listen for operating system messages to the application. If the form to expire is moved, mousemove detected, keydown detected it will stay open
        'When no message is sent from the OS within 30 seconds the form will expire.
        resetActivity()

        MyBase.WndProc(m)
    End Sub

    Public Sub resetActivity()
        If inActivity Is Nothing Then
            Exit Sub
        End If
        inActivity.Reset()
        inActivity.Start()
    End Sub


    'Causes the form to fade in.
    Private Sub FormCustomized_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not FadeFxTimer.Enabled Then
            Exit Sub
        End If
        Opacity = f_MinimizedOpacity
        TargetOpacity = f_ActiveOpacity
    End Sub

    'Performs fade increment.
    Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Dim fadeChangePerTick = FadeFxTimer.Interval * 1.0 / 1000 / f_FadeTime

        'Check to see if it is time to stop the timer
        If Math.Abs(f_TargetOpacity - Opacity) < fadeChangePerTick Then
            'There is an ugly black flash if you set the Opacity to 1.0
            If f_TargetOpacity = 1 Then
                Opacity = 0.99999999999
            Else
                Opacity = f_TargetOpacity
            End If
            'Process held Windows Message.
            MyBase.WndProc(heldMessage)
            heldMessage = New Message()
            'Stop the timer to save processor.
            isFormLoading = False
            FadeFxTimer.Stop()
        ElseIf f_TargetOpacity > Opacity Then
            Opacity += fadeChangePerTick
        ElseIf f_TargetOpacity < Opacity Then
            Opacity -= fadeChangePerTick
        End If
    End Sub

    'Fade out the form when it losses focus.
    Private Sub FormCustomized_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate
        If isFormLoading Then
            Exit Sub
        End If
        TargetOpacity = f_InactiveOpacity
    End Sub

    'Fade in the form when it gaines focus.
    Private Sub FormCustomized_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        If isFormLoading Then
            Exit Sub
        End If
        TargetOpacity = f_ActiveOpacity
    End Sub
#End Region

End Class


