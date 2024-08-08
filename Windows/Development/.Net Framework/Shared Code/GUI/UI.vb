Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms

Public Module UI
    Public Function ChangeOpacity(ByVal img As Image, ByVal opacityvalue As Single) As Bitmap
        Dim bmp As New Bitmap(img.Width, img.Height)
        Dim graphics__1 As Graphics = Graphics.FromImage(bmp)
        Dim colormatrix As New ColorMatrix
        colormatrix.Matrix33 = opacityvalue
        Dim imgAttribute As New ImageAttributes
        imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.[Default], ColorAdjustType.Bitmap)
        graphics__1.DrawImage(img, New Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height,
         GraphicsUnit.Pixel, imgAttribute)
        graphics__1.Dispose()
        Return bmp
    End Function
    Public Sub enableButtonsAndLinks(ByVal form As Control, ByVal stateCore As Boolean)
        Dim Buttons As New List(Of Control)
        For Each button As Button In FindControlRecursive(Buttons, form, GetType(Button))
            button.Enabled = stateCore
        Next
        Dim PictureLinks As New List(Of Control)
        For Each pictureLink As PictureBox In FindControlRecursive(PictureLinks, form, GetType(PictureBox))
            pictureLink.Enabled = stateCore
        Next
        Dim LabelLinks As New List(Of Control)
        For Each labelLink As LinkLabel In FindControlRecursive(LabelLinks, form, GetType(LinkLabel))
            labelLink.Enabled = stateCore
        Next
        Dim ComboBoxes As New List(Of Control)
        For Each comboBox As ComboBox In FindControlRecursive(ComboBoxes, form, GetType(ComboBox))
            comboBox.Enabled = stateCore
        Next
        Dim TextBoxes As New List(Of Control)
        For Each textBox As TextBox In FindControlRecursive(TextBoxes, form, GetType(TextBox))
            textBox.Enabled = stateCore
        Next
        Dim DateTimePickers As New List(Of Control)
        For Each dateTimePicker As DateTimePicker In FindControlRecursive(DateTimePickers, form, GetType(DateTimePicker))
            dateTimePicker.Enabled = stateCore
        Next
        Dim MonthCalendars As New List(Of Control)
        For Each monthCalendar As MonthCalendar In FindControlRecursive(MonthCalendars, form, GetType(MonthCalendar))
            monthCalendar.Enabled = stateCore
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
