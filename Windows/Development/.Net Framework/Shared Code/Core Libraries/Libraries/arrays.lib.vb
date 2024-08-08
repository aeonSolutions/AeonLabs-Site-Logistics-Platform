Public Module arraysLibrary
    Function InQueryDictionary(ByRef arr As Dictionary(Of String, List(Of String)), ByVal needle As String, ByVal key As String) As Integer
        Dim i As Integer
        If arr Is Nothing Then
            Return -2
        End If

        For i = 0 To arr.Item(key).Count - 1
            If arr.Item(key)(i).Equals(needle) Then
                Return i
            End If
        Next i
        Return -1
    End Function
    Function InArrayInt(ByVal arr As Array, ByVal needle As Integer) As Integer
        Dim i As Integer
        If arr Is Nothing Then
            Return -2
        End If

        For i = 0 To arr.Length - 1
            If arr(i) = needle Then
                Return i
                Exit Function
            End If
        Next i
        Return -1
    End Function
    Function InArray(ByRef arr As Array, ByVal needle As String, ByVal pos As Integer) As Integer
        Dim i As Integer
        If arr Is Nothing Then
            Return -2
        End If

        For i = 0 To arr.GetLength(0) - 1
            If arr(i, pos).ToString.Equals(needle) Then
                Return i
                Exit Function
            End If
        Next i
        Return -1
    End Function

End Module
