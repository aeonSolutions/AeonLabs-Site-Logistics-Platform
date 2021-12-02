Public Module timeDateLibrary
    Public Function IsWeekday(theDate As Date) As Boolean
        IsWeekday = Weekday(theDate, vbMonday) <= 5
    End Function
    Public Function isValidTime(ByVal atimestring As String) As String
        Try
            Dim dt As DateTime = DateTime.ParseExact(atimestring, "HH:mm", Nothing)
            Return True
        Catch
            Return False
        End Try
    End Function
End Module
