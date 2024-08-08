Imports System.Text

Public Module Strings
    Public Function EncodeString(ByRef SourceData As String, ByRef CharSet As String) As String
        'get a byte pointer To the source data
        Dim bSourceData As Byte() = System.Text.Encoding.Unicode.GetBytes(SourceData)

        'get destination encoding 
        Dim OutEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding(CharSet)

        'Encode the data To destination code page/charset
        Dim bytes As Byte() = System.Text.Encoding.Convert(System.Text.Encoding.Unicode, OutEncoding, bSourceData)

        Return System.Text.Encoding.Unicode.GetString(bytes)
    End Function

    Public Function AddSpaces(str As String, numChars As Integer) As String
        Dim builder As New StringBuilder(str)
        Dim EndIndex = str.Length - (str.Length Mod numChars) + 1

        builder.Insert((str.Length Mod numChars), " "c)
        For i As Int32 = (str.Length Mod numChars) + numChars To EndIndex Step numChars + 1
            builder.Insert(i + 1, " "c)
        Next i
        Return builder.ToString()
    End Function

    Public Function randomString(ByVal Optional size = Nothing)
        Dim r As New Random
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim sb As New StringBuilder
        Dim cnt As Integer

        If IsNothing(size) Then
            cnt = r.Next(15, 33)
        Else
            cnt = size
        End If
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function
End Module
