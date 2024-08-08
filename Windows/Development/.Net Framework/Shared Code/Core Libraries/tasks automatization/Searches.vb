Imports System.Windows.Forms

Public Module Searches
    Public Sub doSearchWorkers(start As Integer, firstTime As Boolean, hasAddNew As Boolean, works_worker As Dictionary(Of String, List(Of String)), ListBox_works As ListBox, SearchText As String)
        Dim msgbox As messageboxForm
        Dim translations As languageTranslations
        Dim state As New environmentVarsCore

        translations = New languageTranslations(state)
        If Not IsNothing(works_worker) Then
            Dim found As Boolean = False
            For i = start + 1 To works_worker.Item("cod_worker").Count - 1
                If Not works_worker.Item("name")(i).ToLower.IndexOf(SearchText.ToLower) = -1 Then
                    ListBox_works.SelectedIndex = i + If(hasAddNew, 1, 0)
                    found = True
                    Exit For
                End If
            Next i
            If firstTime.Equals(False) And Not found Then
                translations.load("infoMessages")
                Dim message3 As String = translations.getText("searchResultsNotFound")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                msgbox.ShowDialog()
            ElseIf Not found Then
                translations.load("infoMessages")
                Dim message3 As String = translations.getText("searchResultsNotFound") & ". " & translations.getText("searchAgainQuestion")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If msgbox.ShowDialog = DialogResult.OK Then
                    doSearchWorkers(0, False, hasAddNew, works_worker, ListBox_works, SearchText)
                End If
            End If
        End If
    End Sub

End Module
