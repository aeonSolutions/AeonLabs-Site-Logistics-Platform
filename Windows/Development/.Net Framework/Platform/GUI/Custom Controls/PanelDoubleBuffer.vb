Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class PanelDoubleBuffer
    Inherits Panel

    'MAIN LAYOUT design scheme
    Public Property PANEL_CLOSED_STATE_DIM As Integer = 40
    Public Property PANEL_OPEN_STATE_DIM As Integer = 400
    Public Property ShowVerticalScrolBar As Boolean = False
    Public Property ShowHorizontalScrolBar As Boolean = False

    Public Sub New()
        SuspendLayout()

        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)

        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        Me.UpdateStyles()
        Dim t = ShowHorizontalScrolBar
        ResumeLayout()
    End Sub

    <DllImport("user32.dll")>
    Private Shared Function ShowScrollBar(ByVal hWnd As IntPtr, ByVal wBar As Integer, ByVal bShow As Boolean) As Boolean
    End Function

    Public Property SB_HORZ As Integer = ShowHorizontalScrolBar
    Public Property SB_VERT As Integer = ShowVerticalScrolBar
    Public Property SB_CTL As Integer = 2
    Public Property SB_BOTH As Integer = 3

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = &H85 Then
            ShowScrollBar(Me.Handle, CInt(SB_BOTH), False)
        End If

        MyBase.WndProc(m)
    End Sub


    <DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    Private Const WM_SETREDRAW As Integer = &HB

    Private Sub PanelView_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs)
        Dim control As Control = TryCast(sender, Control)

        If control IsNot Nothing Then

            If e.Type = ScrollEventType.ThumbTrack Then
                SendMessage(control.Handle, WM_SETREDRAW, 1, 0)
                control.Refresh()
                SendMessage(control.Handle, WM_SETREDRAW, 0, 0)
            Else
                SendMessage(control.Handle, WM_SETREDRAW, 1, 0)
                control.Invalidate()
            End If
        End If
    End Sub
End Class
