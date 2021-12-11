Module UI
    Public Sub enableButtonsAndLinks(ByVal form As Control, ByVal state As Boolean)
        Dim Buttons As New List(Of Control)
        For Each button As Button In FindControlRecursive(Buttons, form, GetType(Button))
            button.Enabled = state
        Next
        Dim PictureLinks As New List(Of Control)
        For Each pictureLink As PictureBox In FindControlRecursive(PictureLinks, form, GetType(PictureBox))
            pictureLink.Enabled = state
        Next
        Dim LabelLinks As New List(Of Control)
        For Each labelLink As LinkLabel In FindControlRecursive(LabelLinks, form, GetType(LinkLabel))
            labelLink.Enabled = state
        Next
        Dim ComboBoxes As New List(Of Control)
        For Each comboBox As ComboBox In FindControlRecursive(ComboBoxes, form, GetType(ComboBox))
            comboBox.Enabled = state
        Next
        Dim TextBoxes As New List(Of Control)
        For Each textBox As TextBox In FindControlRecursive(TextBoxes, form, GetType(TextBox))
            textBox.Enabled = state
        Next
        Dim DateTimePickers As New List(Of Control)
        For Each dateTimePicker As DateTimePicker In FindControlRecursive(DateTimePickers, form, GetType(DateTimePicker))
            dateTimePicker.Enabled = state
        Next
        Dim MonthCalendars As New List(Of Control)
        For Each monthCalendar As MonthCalendar In FindControlRecursive(MonthCalendars, form, GetType(MonthCalendar))
            monthCalendar.Enabled = state
        Next
    End Sub
    Public Function FindControlRecursive(ByVal list As List(Of Control), ByVal parent As Control, ByVal ctrlType As System.Type) As List(Of Control)
        If parent Is Nothing Then Return list
        If parent.GetType Is ctrlType Then
            list.Add(parent)
        End If
        For Each child As Control In parent.Controls
            FindControlRecursive(list, child, ctrlType)
        Next
        Return list
    End Function
End Module
