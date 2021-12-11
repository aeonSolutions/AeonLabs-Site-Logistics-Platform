Imports System.Drawing.Text

Class WorkersDataTable
    Public works_site, works_sections, works_entreprise, works_category As Dictionary(Of String, List(Of String))
    Public state As State
    Public fontText As New PrivateFontCollection()
    Public numDays As Integer
    Public holidays As DateTime() = Nothing
    Public closures As DateTime() = Nothing
    Public absense As Integer(,) = Nothing
    Public record As Integer(,) = Nothing
    Public serverData As logger_frm.workersJson(,)
    Public idxTableWorkerPos As Integer()
    Public AttendanceTable As String(,)
    Public calendar As MonthCalendar




    Public Sub loadLayout(ByRef datatable As DataGridView, RowIndex As Integer, ColumnIndex As Integer)
        If IsNothing(AttendanceTable) Then
            Exit Sub
        End If
        If UBound(AttendanceTable, 1) < RowIndex Or UBound(AttendanceTable, 2) < ColumnIndex Then
            Exit Sub
        End If
        With datatable
            If ColumnIndex.Equals(0) Then
                .Rows(RowIndex).Cells(ColumnIndex).Style.Alignment = DataGridViewContentAlignment.BottomLeft

                If InQueryDictionary(works_site, AttendanceTable(RowIndex, 0), "name") > -1 And Not .Rows(RowIndex).DefaultCellStyle.BackColor.Equals(Color.Aquamarine) Then ' obra
                    '.Rows(RowIndex).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                    .Rows(RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                End If

                Dim t = InQueryDictionary(works_sections, serverData(RowIndex, 0).section, "cod_section")
                Dim tt = .Rows(RowIndex).DefaultCellStyle.BackColor
                If InQueryDictionary(works_sections, serverData(RowIndex, 0).section, "cod_section") > -1 And Not .Rows(RowIndex).DefaultCellStyle.BackColor.Equals(Color.Aquamarine) Then
                    If AttendanceTable(RowIndex, 0).Equals(" " & works_sections.Item("description")(InQueryDictionary(works_sections, serverData(RowIndex, 0).section, "cod_section"))) Then ' section
                        '.Rows(RowIndex).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                        .Rows(RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                    End If
                End If
                If InQueryDictionary(works_sections, serverData(RowIndex, 0).company, "cod_section") > -1 And Not .Rows(RowIndex).DefaultCellStyle.BackColor.Equals(Color.Beige) Then
                    If AttendanceTable(RowIndex, 0).Equals("  " & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, serverData(RowIndex, 0).company, "cod_entreprise"))) Then ' company
                        ' .Rows(RowIndex).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                        .Rows(RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(RowIndex).DefaultCellStyle.BackColor = Color.Beige
                    End If
                End If
                If InQueryDictionary(works_category, serverData(RowIndex, 0).category, "cod_category") > -1 And Not .Rows(RowIndex).DefaultCellStyle.BackColor.Equals(Color.Beige) Then
                    If AttendanceTable(RowIndex, 0).Equals("   " & works_category.Item("designation")(InQueryDictionary(works_category, serverData(RowIndex, 0).category, "cod_category"))) Then ' category
                        ' .Rows(RowIndex).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                        .Rows(RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(RowIndex).DefaultCellStyle.BackColor = Color.Beige
                    End If
                End If
            End If


            'absenses
            If Not IsNothing(absense) And ColumnIndex > 0 And ColumnIndex <= numDays Then
                If InArrayInt(idxTableWorkerPos, RowIndex) > -1 Then
                    If (absense(InArrayInt(idxTableWorkerPos, RowIndex), ColumnIndex).Equals(1)) Then
                        .Rows(RowIndex).Cells(ColumnIndex).Style.BackColor = Color.PaleGoldenrod
                    End If
                End If
            End If


            If Not IsNothing(record) And ColumnIndex > 0 And ColumnIndex <= numDays Then
                If InArrayInt(idxTableWorkerPos, RowIndex) > -1 Then
                    If AttendanceTable(RowIndex, ColumnIndex).Equals("P") Then
                        .Rows(RowIndex).Cells(ColumnIndex).Style.BackColor = Color.FromArgb(192, 255, 192)
                    ElseIf AttendanceTable(RowIndex, ColumnIndex).Equals("EP") Then
                        .Rows(RowIndex).Cells(ColumnIndex).Style.BackColor = Color.FromArgb(204, 255, 117)
                    ElseIf AttendanceTable(RowIndex, ColumnIndex).Equals("MO") Then
                        .Rows(RowIndex).Cells(ColumnIndex).Style.BackColor = Color.LightSkyBlue
                    ElseIf AttendanceTable(RowIndex, ColumnIndex).IndexOf("H") > 0 Then
                        .Rows(RowIndex).Cells(ColumnIndex).Style.BackColor = Color.FromArgb(255, 218, 117)
                    ElseIf AttendanceTable(RowIndex, ColumnIndex).Equals("FA") Then
                        .Rows(RowIndex).Cells(ColumnIndex).Style.ForeColor = Color.LightGray
                    ElseIf Not AttendanceTable(RowIndex, ColumnIndex).Equals("") Then
                        .Rows(RowIndex).Cells(ColumnIndex).Style.BackColor = Color.MistyRose
                    End If

                    If (Not serverData(RowIndex, ColumnIndex).checkin.Equals("00:00:00") And Not serverData(RowIndex, ColumnIndex).checkin.Equals("")) Then
                        .Rows(RowIndex).Cells(ColumnIndex).Style.BackColor = Color.Gold
                    End If
                End If
            End If

            'holidays
            If Not IsNothing(holidays) And Not .Columns(ColumnIndex).DefaultCellStyle.BackColor.Equals(Color.FromArgb(204, 236, 255)) And ColumnIndex > 0 And ColumnIndex <= numDays Then
                If holidays.Contains(Convert.ToDateTime(calendar.SelectionStart.ToString("yyyy-MM-") & If(ColumnIndex < 10, "0" & ColumnIndex, ColumnIndex))) Then
                    .Columns(ColumnIndex).DefaultCellStyle.BackColor = Color.FromArgb(204, 236, 255)
                End If
            End If

            'weekends
            If ColumnIndex > 0 And ColumnIndex <= numDays Then
                If Not IsWeekday(calendar.SelectionStart.ToString("yyyy-MM") & "-" & ColumnIndex.ToString()) And Not .Columns(ColumnIndex).DefaultCellStyle.BackColor.Equals(Color.IndianRed) Then
                    .Columns(ColumnIndex).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            End If

            'users without record
            If ColumnIndex = 0 And serverData(RowIndex, 0).data.ToString("yyyy-MM-dd").Equals("1970-01-01") And InArrayInt(idxTableWorkerPos, RowIndex) > -1 Then
                .Rows(RowIndex).Cells(0).Style.ForeColor = Color.IndianRed
            End If

            If RowIndex.Equals(datatable.Rows.Count - 2) Then
                .Rows(RowIndex).Cells(ColumnIndex).Style.BackColor = Color.LightGray
            End If
            If RowIndex.Equals(datatable.Rows.Count - 1) Then
                .Rows(RowIndex).Cells(ColumnIndex).Style.BackColor = Color.Gainsboro
            End If
            If RowIndex.Equals(datatable.Rows.Count - 3) Then
                .Rows(RowIndex).Cells(ColumnIndex).Style.BackColor = Color.Gainsboro
            End If
            .Rows(RowIndex).Cells(ColumnIndex).Value = AttendanceTable(RowIndex, ColumnIndex)
        End With

    End Sub
End Class
