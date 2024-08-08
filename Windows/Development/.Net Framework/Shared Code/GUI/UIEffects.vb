Imports System.Drawing
Imports ConstructionSiteLogistics.Libraries.Core

Public Module UIEffects
    Private control As Object
    Private DropClickSearchBoxThread As Threading.Thread = Nothing
    Private DropClickUpdateThread As Threading.Thread = Nothing
    Private DropClickMenuThread As Threading.Thread = Nothing
    Private DropClickMaximizeThread As Threading.Thread = Nothing
    Private DropClickMinimizeThread As Threading.Thread = Nothing
    Private DropClickRestoreThread As Threading.Thread = Nothing

    Public Sub DropClickSearchBox(_control As Object)
        control = _control
        Randomize()
        If Not IsNothing(DropClickSearchBoxThread) Then
            If DropClickSearchBoxIsActive() Then
                DropClickSearchBoxThread.Join()
            End If
            DropClickSearchBoxThread = Nothing
        End If
        DropClickSearchBoxThread = New Threading.Thread(AddressOf _DropClickSearchBox)
        DropClickSearchBoxThread.SetApartmentState(Threading.ApartmentState.STA)
        DropClickSearchBoxThread.Priority = Threading.ThreadPriority.Highest
        DropClickSearchBoxThread.Name = "dropClickSearch_" & CInt(Int((30 * Rnd()) + 1)).ToString
        DropClickSearchBoxThread.Start()
    End Sub

    Private Sub _DropClickSearchBox()
        Dim state As New environmentVars(LOAD_SETTINGS)
        control.Invoke(Sub()
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("searchiconClicked.png"))
                           Threading.Thread.Sleep(400)
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("searchicon.png"))
                       End Sub)
    End Sub

    Private Function DropClickSearchBoxIsActive() As Boolean
        Try
            Return (DropClickSearchBoxThread.ThreadState = ThreadState.Initialized = True Or DropClickSearchBoxThread.ThreadState = ThreadState.Running = True)
        Catch ex As Exception
            Return False
        End Try

    End Function
    '_____________________________________________________________________________________________________________________________________________
    Public Sub DropClickMenu(_control As Object)
        control = _control
        Randomize()
        If Not IsNothing(DropClickMenuThread) Then
            If DropClickMenuIsActive() Then
                DropClickMenuThread.Join()
            End If
            DropClickMenuThread = Nothing
        End If
        DropClickMenuThread = New Threading.Thread(AddressOf _DropClickMenu)
        DropClickMenuThread.SetApartmentState(Threading.ApartmentState.STA)
        DropClickMenuThread.Priority = Threading.ThreadPriority.Highest
        DropClickMenuThread.Name = "dropClickMenu_" & CInt(Int((30 * Rnd()) + 1)).ToString
        DropClickMenuThread.Start()
    End Sub

    Private Sub _DropClickMenu()
        Dim state As New environmentVars(LOAD_SETTINGS)

        control.Invoke(Sub()
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("Menu_48px.clicked.png"))
                           Threading.Thread.Sleep(400)
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("Menu_48px.png"))
                       End Sub)
    End Sub

    Private Function DropClickMenuIsActive() As Boolean
        Try
            Return (DropClickMenuThread.ThreadState = ThreadState.Initialized = True Or DropClickMenuThread.ThreadState = ThreadState.Running = True)
        Catch ex As Exception
            Return False
        End Try
    End Function
    '_____________________________________________________________________________________________________________________________________________
    Public Sub DropClickUpdate(_control As Object)
        control = _control
        Randomize()
        If Not IsNothing(DropClickUpdateThread) Then
            If DropClickUpdateIsActive() Then
                DropClickUpdateThread.Join()
            End If
            DropClickUpdateThread = Nothing
        End If
        DropClickUpdateThread = New Threading.Thread(AddressOf _DropClickUpdate)
        DropClickUpdateThread.SetApartmentState(Threading.ApartmentState.STA)
        DropClickUpdateThread.Priority = Threading.ThreadPriority.Highest
        DropClickUpdateThread.Name = "dropClickUpdate_" & CInt(Int((30 * Rnd()) + 1)).ToString
        DropClickUpdateThread.Start()
    End Sub

    Private Sub _DropClickUpdate()
        Dim state As New environmentVars(LOAD_SETTINGS)

        control.Invoke(Sub()
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("refreshClicked.png"))
                           Threading.Thread.Sleep(400)
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("refresh.png"))
                       End Sub)
    End Sub

    Private Function DropClickUpdateIsActive() As Boolean
        Try
            Return (DropClickUpdateThread.ThreadState = ThreadState.Initialized = True Or DropClickUpdateThread.ThreadState = ThreadState.Running = True)
        Catch ex As Exception
            Return False
        End Try

    End Function

    '_____________________________________________________________________________________________________________________________________________
    Public Sub DropClickMaximize(_control As Object)
        control = _control
        Randomize()
        If Not IsNothing(DropClickMaximizeThread) Then
            If DropClickMaximizeIsActive() Then
                DropClickMaximizeThread.Join()
            End If
            DropClickMaximizeThread = Nothing
        End If
        DropClickMaximizeThread = New Threading.Thread(AddressOf _DropClickMaximize)
        DropClickMaximizeThread.SetApartmentState(Threading.ApartmentState.STA)
        DropClickMaximizeThread.Priority = Threading.ThreadPriority.Highest
        DropClickMaximizeThread.Name = "dropClickMaximize_" & CInt(Int((30 * Rnd()) + 1)).ToString
        DropClickMaximizeThread.Start()
    End Sub

    Private Sub _DropClickMaximize()
        Dim state As New environmentVars(LOAD_SETTINGS)

        control.Invoke(Sub()
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("Maximize Window_2 48px.clicked.png"))
                           Threading.Thread.Sleep(400)
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("Maximize Window_2 48px.png"))
                       End Sub)
    End Sub

    Private Function DropClickMaximizeIsActive() As Boolean
        Try
            Return (DropClickMaximizeThread.ThreadState = ThreadState.Initialized = True Or DropClickMaximizeThread.ThreadState = ThreadState.Running = True)
        Catch ex As Exception
            Return False
        End Try
    End Function

    '_____________________________________________________________________________________________________________________________________________
    Public Sub DropClickMinimize(_control As Object)
        control = _control
        Randomize()
        If Not IsNothing(DropClickMaximizeThread) Then
            If DropClickMinimizeIsActive() Then
                DropClickMinimizeThread.Join()
            End If
            DropClickMinimizeThread = Nothing
        End If
        DropClickMinimizeThread = New Threading.Thread(AddressOf _DropClickMinimize)
        DropClickMinimizeThread.SetApartmentState(Threading.ApartmentState.STA)
        DropClickMinimizeThread.Priority = Threading.ThreadPriority.Highest
        DropClickMinimizeThread.Name = "dropClickMinimize_" & CInt(Int((30 * Rnd()) + 1)).ToString
        DropClickMinimizeThread.Start()
    End Sub

    Private Sub _DropClickMinimize()
        Dim state As New environmentVars(LOAD_SETTINGS)

        control.Invoke(Sub()
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("Minimize Window_2 48px.clicked.png"))
                           Threading.Thread.Sleep(400)
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("Minimize Window_2 48px.png"))
                       End Sub)
    End Sub

    Private Function DropClickMinimizeIsActive() As Boolean
        Try
            Return (DropClickMinimizeThread.ThreadState = ThreadState.Initialized = True Or DropClickMinimizeThread.ThreadState = ThreadState.Running = True)
        Catch ex As Exception
            Return False
        End Try
    End Function

    '_____________________________________________________________________________________________________________________________________________
    Public Sub DropClickRestore(_control As Object)
        control = _control
        Randomize()
        If Not IsNothing(DropClickRestoreThread) Then
            If DropClickRestoreIsActive() Then
                DropClickRestoreThread.Join()
            End If
            DropClickRestoreThread = Nothing
        End If
        DropClickRestoreThread = New Threading.Thread(AddressOf _DropClickRestore)
        DropClickRestoreThread.SetApartmentState(Threading.ApartmentState.STA)
        DropClickRestoreThread.Priority = Threading.ThreadPriority.Highest
        DropClickRestoreThread.Name = "dropClickRestore_" & CInt(Int((30 * Rnd()) + 1)).ToString
        DropClickRestoreThread.Start()
    End Sub

    Private Sub _DropClickRestore()
        Dim state As New environmentVars(LOAD_SETTINGS)

        control.Invoke(Sub()
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("Restore Window 2_48px.clicked.png"))
                           Threading.Thread.Sleep(400)
                           control.Image = Image.FromFile(state.imagesPath & Convert.ToString("Restore Window 2_48px.png"))
                       End Sub)
    End Sub

    Private Function DropClickRestoreIsActive() As Boolean
        Try
            Return (DropClickRestoreThread.ThreadState = ThreadState.Initialized = True Or DropClickRestoreThread.ThreadState = ThreadState.Running = True)
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
