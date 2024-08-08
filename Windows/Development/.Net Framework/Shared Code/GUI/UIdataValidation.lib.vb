Imports System.Drawing
Imports System.Windows.Forms

Public Module UIdataValidationLibrary
    Public Sub ClearDate(context As TextBox)
        If (IsDate(context.Text)) Then
            context.Text = context.Text.Replace("/", "-")

            Dim arr As String()
            arr = context.Text.Split("-")

            Dim yeart As String = ""
            Dim mes As String = ""
            Dim dia As String = ""

            If arr(0).Length = 4 Then
                yeart = arr(0)
                If arr(2).Length < 2 Then
                    dia = "0" & arr(2)
                Else
                    dia = arr(2)
                End If
            Else
                yeart = arr(2)
                If arr(0).Length < 2 Then
                    dia = "0" & arr(0)
                Else
                    dia = arr(0)
                End If
            End If
            If arr(1).Length < 2 Then
                mes = "0" & arr(1)
            Else
                mes = arr(1)
            End If
            context.Text = yeart & "-" & mes & "-" & dia
            context.ForeColor = Color.Black
        Else
            context.ForeColor = Color.Red
        End If
    End Sub

    Public Function normDate(str As String) As String
        If (IsDate(str)) Then
            str = str.Replace("/", "-")

            Dim arr As String()
            arr = str.Split("-")

            Dim yeart As String = ""
            Dim mes As String = ""
            Dim dia As String = ""

            If arr(0).Length = 4 Then
                yeart = arr(0)
                If arr(2).Length < 2 Then
                    dia = "0" & arr(2)
                Else
                    dia = arr(2)
                End If
            Else
                yeart = arr(2)
                If arr(0).Length < 2 Then
                    dia = "0" & arr(0)
                Else
                    dia = arr(0)
                End If
            End If
            If arr(1).Length < 2 Then
                mes = "0" & arr(1)
            Else
                mes = arr(1)
            End If
            str = yeart & "-" & mes & "-" & dia
            Return str
        Else
            Return str
        End If
    End Function
End Module
