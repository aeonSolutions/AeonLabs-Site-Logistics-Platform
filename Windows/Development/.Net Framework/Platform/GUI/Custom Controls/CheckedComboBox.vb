Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Diagnostics

Namespace CheckComboBox
    Public Class CheckedComboBox
        Inherits ComboBox

        Friend Shadows Class Dropdown
            Inherits Form

            Friend Class CCBoxEventArgs
                Inherits EventArgs

                Private assignVals As Boolean

                Public Property AssignValues As Boolean
                    Get
                        Return assignVals
                    End Get
                    Set(ByVal value As Boolean)
                        assignVals = value
                    End Set
                End Property

                Private e As EventArgs

                Public Property EventArgs As EventArgs
                    Get
                        Return e
                    End Get
                    Set(ByVal value As EventArgs)
                        e = value
                    End Set
                End Property

                Public Sub New(ByVal e As EventArgs, ByVal assignValues As Boolean)
                    MyBase.New()
                    Me.e = e
                    Me.AssignValues = assignValues
                End Sub
            End Class

            Friend Class CustomCheckedListBox
                Inherits CheckedListBox

                Private curSelIndex As Integer = -1

                Public Sub New()
                    MyBase.New()
                    Me.SelectionMode = SelectionMode.One
                    Me.HorizontalScrollbar = True
                End Sub

                Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
                    If e.KeyCode = Keys.Enter Then
                        CType(Parent, CheckedComboBox.Dropdown).OnDeactivate(New CCBoxEventArgs(Nothing, True))
                        e.Handled = True
                    ElseIf e.KeyCode = Keys.Escape Then
                        CType(Parent, CheckedComboBox.Dropdown).OnDeactivate(New CCBoxEventArgs(Nothing, False))
                        e.Handled = True
                    ElseIf e.KeyCode = Keys.Delete Then

                        For i As Integer = 0 To Items.Count - 1
                            SetItemChecked(i, e.Shift)
                        Next

                        e.Handled = True
                    End If

                    MyBase.OnKeyDown(e)
                End Sub

                Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
                    MyBase.OnMouseMove(e)
                    Dim index As Integer = IndexFromPoint(e.Location)
                    Debug.WriteLine("Mouse over item: " & (If(index >= 0, GetItemText(Items(index)), "None")))

                    If (index >= 0) AndAlso (index <> curSelIndex) Then
                        curSelIndex = index
                        SetSelected(index, True)
                    End If
                End Sub
            End Class

            Private ccbParent As CheckedComboBox
            Private oldStrValue As String = ""

            Public ReadOnly Property ValueChanged As Boolean
                Get
                    Dim newStrValue As String = ccbParent.Text

                    If (oldStrValue.Length > 0) AndAlso (newStrValue.Length > 0) Then
                        Return (oldStrValue.CompareTo(newStrValue) <> 0)
                    Else
                        Return (oldStrValue.Length <> newStrValue.Length)
                    End If
                End Get
            End Property

            Private checkedStateArr As Boolean()
            Private dropdownClosed As Boolean = True
            Private cclb As CustomCheckedListBox

            Public Property List As CustomCheckedListBox
                Get
                    Return cclb
                End Get
                Set(ByVal value As CustomCheckedListBox)
                    cclb = value
                End Set
            End Property

            Public Sub New(ByVal _ccbParent As CheckedComboBox)
                Me.ccbParent = _ccbParent
                Me.SuspendLayout()
                InitializeComponent()
                Me.ResumeLayout()
                Me.ShowInTaskbar = False
                AddHandler Me.cclb.ItemCheck, New ItemCheckEventHandler(AddressOf Me.cclb_ItemCheck)
            End Sub

            Private Sub InitializeComponent()
                Me.cclb = New CustomCheckedListBox()
                Me.SuspendLayout()
                Me.cclb.BorderStyle = System.Windows.Forms.BorderStyle.None
                Me.cclb.Dock = System.Windows.Forms.DockStyle.Fill
                Me.cclb.FormattingEnabled = True
                Me.cclb.Location = New System.Drawing.Point(0, 0)
                Me.cclb.Name = "cclb"
                Me.cclb.Size = New System.Drawing.Size(47, 15)
                Me.cclb.TabIndex = 0
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.BackColor = Drawing.Color.White
                Me.ClientSize = New System.Drawing.Size(47, 16)
                Me.ControlBox = False
                Me.Controls.Add(Me.cclb)
                Me.ForeColor = System.Drawing.Color.Black
                Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
                Me.MinimizeBox = False
                Me.Name = "ccbParent"
                Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
                Me.ResumeLayout(False)
            End Sub

            Public Function GetCheckedItemsStringValue() As String
                Dim sb As StringBuilder = New StringBuilder("")

                For i As Integer = 0 To cclb.CheckedItems.Count - 1
                    sb.Append(cclb.GetItemText(cclb.CheckedItems(i))).Append(ccbParent.ValueSeparator)
                Next

                If sb.Length > 0 Then
                    sb.Remove(sb.Length - ccbParent.ValueSeparator.Length, ccbParent.ValueSeparator.Length)
                End If

                Return sb.ToString()
            End Function

            Public Sub CloseDropdown(ByVal enactChanges As Boolean)
                If dropdownClosed Then
                    Return
                End If

                Debug.WriteLine("CloseDropdown")

                If enactChanges Then
                    ccbParent.SelectedIndex = -1
                    ccbParent.Text = GetCheckedItemsStringValue()
                Else

                    For i As Integer = 0 To cclb.Items.Count - 1
                        cclb.SetItemChecked(i, checkedStateArr(i))
                    Next
                End If

                dropdownClosed = True
                ccbParent.Focus()
                Me.Hide()
                ccbParent.OnDropDownClosed(New CCBoxEventArgs(Nothing, False))
            End Sub

            Protected Overrides Sub OnActivated(ByVal e As EventArgs)
                Debug.WriteLine("OnActivated")
                MyBase.OnActivated(e)
                dropdownClosed = False
                oldStrValue = ccbParent.Text
                checkedStateArr = New Boolean(cclb.Items.Count - 1) {}

                For i As Integer = 0 To cclb.Items.Count - 1
                    checkedStateArr(i) = cclb.GetItemChecked(i)
                Next
            End Sub

            Protected Overrides Sub OnDeactivate(ByVal e As EventArgs)
                Debug.WriteLine("OnDeactivate")
                MyBase.OnDeactivate(e)
                Dim ce As CCBoxEventArgs = TryCast(e, CCBoxEventArgs)

                If ce IsNot Nothing Then
                    CloseDropdown(ce.AssignValues)
                Else
                    CloseDropdown(True)
                End If
            End Sub

            Private Sub cclb_ItemCheck(ByVal sender As Object, ByVal e As ItemCheckEventArgs)
                'RaiseEvent ccbParent.ItemCheck(sender, e)
            End Sub
        End Class

        Private components As System.ComponentModel.IContainer = Nothing
        Private _dropdown As Dropdown
        Private _valueSeparator As String

        Public Property ValueSeparator As String
            Get
                Return _valueSeparator
            End Get
            Set(ByVal value As String)
                _valueSeparator = value
            End Set
        End Property

        Public Property CheckOnClick As Boolean
            Get
                Return _dropdown.List.CheckOnClick
            End Get
            Set(ByVal value As Boolean)
                _dropdown.List.CheckOnClick = value
            End Set
        End Property

        Public Overloads Property DisplayMember As String
            Get
                Return _dropdown.List.DisplayMember
            End Get
            Set(ByVal value As String)
                _dropdown.List.DisplayMember = value
            End Set
        End Property

        Public Overloads ReadOnly Property Items As CheckedListBox.ObjectCollection
            Get
                Return _dropdown.List.Items
            End Get
        End Property

        Public ReadOnly Property CheckedItems As CheckedListBox.CheckedItemCollection
            Get
                Return _dropdown.List.CheckedItems
            End Get
        End Property

        Public ReadOnly Property CheckedIndices As CheckedListBox.CheckedIndexCollection
            Get
                Return _dropdown.List.CheckedIndices
            End Get
        End Property

        Public ReadOnly Property ValueChanged As Boolean
            Get
                Return _dropdown.ValueChanged
            End Get
        End Property


        Public Event ItemCheck As ItemCheckEventHandler

        'Public Event ItemCheck(sender As Object, e As ItemCheckEventHandler)

        Public Sub New()
            MyBase.New()
            Me.DrawMode = DrawMode.OwnerDrawVariable
            Me.valueSeparator = ", "
            Me.DropDownHeight = 1
            Me.DropDownStyle = ComboBoxStyle.DropDown
            Me._dropdown = New Dropdown(Me)
            Me.CheckOnClick = True
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnDropDown(ByVal e As EventArgs)
            MyBase.OnDropDown(e)
            DoDropDown()
        End Sub

        Private Sub DoDropDown()
            If Not _dropdown.Visible Then
                Dim rect As Rectangle = RectangleToScreen(Me.ClientRectangle)
                _dropdown.Location = New Point(rect.X, rect.Y + Me.Size.Height)
                Dim count As Integer = _dropdown.List.Items.Count

                If count > Me.MaxDropDownItems Then
                    count = Me.MaxDropDownItems
                ElseIf count = 0 Then
                    count = 1
                End If

                _dropdown.Size = New Size(Me.Size.Width, (_dropdown.List.ItemHeight) * count + 2)
                _dropdown.Show(Me)
            End If
        End Sub

        Protected Overrides Sub OnDropDownClosed(ByVal e As EventArgs)
            If TypeOf e Is Dropdown.CCBoxEventArgs Then
                MyBase.OnDropDownClosed(e)
            End If
        End Sub

        Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
            If e.KeyCode = Keys.Down Then
                OnDropDown(Nothing)
            End If

            e.Handled = Not e.Alt AndAlso Not (e.KeyCode = Keys.Tab) AndAlso Not ((e.KeyCode = Keys.Left) OrElse (e.KeyCode = Keys.Right) OrElse (e.KeyCode = Keys.Home) OrElse (e.KeyCode = Keys.[End]))
            MyBase.OnKeyDown(e)
        End Sub

        Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
            e.Handled = True
            MyBase.OnKeyPress(e)
        End Sub

        Public Function GetItemChecked(ByVal index As Integer) As Boolean
            If index < 0 OrElse index > Items.Count Then
                Throw New ArgumentOutOfRangeException("index", "value out of range")
            Else
                Return _dropdown.List.GetItemChecked(index)
            End If
        End Function

        Public Sub SetItemChecked(ByVal index As Integer, ByVal isChecked As Boolean)
            If index < 0 OrElse index > Items.Count Then
                Throw New ArgumentOutOfRangeException("index", "value out of range")
            Else
                _dropdown.List.SetItemChecked(index, isChecked)
                Me.Text = _dropdown.GetCheckedItemsStringValue()
            End If
        End Sub

        Public Function GetItemCheckState(ByVal index As Integer) As CheckState
            If index < 0 OrElse index > Items.Count Then
                Throw New ArgumentOutOfRangeException("index", "value out of range")
            Else
                Return _dropdown.List.GetItemCheckState(index)
            End If
        End Function

        Public Sub SetItemCheckState(ByVal index As Integer, ByVal stateCore As CheckState)
            If index < 0 OrElse index > Items.Count Then
                Throw New ArgumentOutOfRangeException("index", "value out of range")
            Else
                _dropdown.List.SetItemCheckState(index, stateCore)
                Me.Text = _dropdown.GetCheckedItemsStringValue()
            End If
        End Sub
    End Class
End Namespace

