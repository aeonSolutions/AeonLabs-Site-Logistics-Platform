Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class attendanceTableBuilderClass
    Private translations As languageTranslations
    Private state As environmentVarsCore
    Private jsonData As String
    Private calendarDate As Date
    Private num_days As Integer
    Private works_entreprise, works_category, works_sections, works_site As Dictionary(Of String, List(Of String))

    Public Property errorMessage As String
    Public Property serverData As workersJson(,)
    Public Property stats As statsJson
    Public Property idxTableWorkerPos As Integer() = Nothing
    Public Property duplicateWorkerRecords As workerDuplicateRecordsJson()
    Public Property holidays As DateTime() = Nothing
    Public Property closures As DateTime() = Nothing
    Public Property absense As Integer(,) = Nothing
    Public Property record As Integer(,) = Nothing
    Public Property tableData As DataTable
    Public Property tableDataNotes As DataTable

    Structure workerDuplicateRecordsJson
        Public ReadOnly Property IsEmpty As Boolean
            Get
                Return Len(data) = 0
            End Get
        End Property

        Public data As String
        Public codRecord As String
        Public siteName As String
        Public sectionName As String
        Public workerName As String
        Public checkin As String
        Public checkout As String
        Public status As String
    End Structure
    Public Structure workersJson
        Public section As Integer
        Public site As Integer

        Public code As Integer
        Public name As String
        Public contact As String
        Public nfc As String
        Public category As Integer
        Public categoryToday As Integer
        Public assignments As String

        Public company As Integer
        Public eContact As String
        Public photo As String
        Public checkin As String
        Public checkout As String
        Public data As Date
        Public status As String
        Public absense As String
        Public notes As String
        Public validationReason As String
        Public reference As String
        Public duplicates As String
        Public otherSites As String
        Public foreman As Boolean
    End Structure
    Public Structure statsJson
        Public site As String
        Public data As String
        Public maxWorkers As Integer
        Public minWorkers As Integer
        Public absenseHours As TimeSpan
        Public totalDaysWorked As Integer
        Public totalWorkDays As Integer
        Public totalDaysInMonth As Integer
    End Structure

    Public Sub New(_state As environmentVarsCore, _jsonData As String, _calendarDate As Date, _works_entreprise As Dictionary(Of String, List(Of String)), _works_category As Dictionary(Of String, List(Of String)), _works_sections As Dictionary(Of String, List(Of String)), _works_site As Dictionary(Of String, List(Of String)))
        state = _state
        translations = New languageTranslations(state)
        jsonData = _jsonData
        calendarDate = _calendarDate
        num_days = System.DateTime.DaysInMonth(_calendarDate.Date.ToString("yyyy"), _calendarDate.Date.ToString("MM"))
        works_entreprise = _works_entreprise
        works_category = _works_category
        works_sections = _works_sections
        works_site = _works_site
        tableData = Nothing
    End Sub

    Public Function buildDataTable() As DataTable
        Dim rowpos As Integer = 0
        Dim statsI As New statsJson

        tabledata = New DataTable

        ReDim duplicateWorkerRecords(0)
        duplicateWorkerRecords(0).data = ""

        Dim holidaysJson As JArray = Nothing
        Dim ClosuresJson As JArray = Nothing
        Dim loadingState As Boolean = False
        Dim day As Integer = 0

        translations.load("commonForm")
        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonData)
            If Not data.ContainsKey("workers") Then
                errorMessage = "no workers"
                Return Nothing
            Else
                Dim workers As JArray = JArray.Parse(data.Item("workers").ToString)
                For i = 0 To workers.Count - 1
                    If i > 0 Then
                        If Not workers(i).Item("site").ToString.Equals(workers(i - 1).Item("site").ToString) Then ' obra
                            rowpos = rowpos + 1
                        End If
                        If Not workers(i).Item("section").ToString.Equals(workers(i - 1).Item("section").ToString) Then ' section
                            rowpos = rowpos + 1
                        End If
                        If Not workers(i).Item("company").ToString.Equals(workers(i - 1).Item("company").ToString) Or loadingState Then ' company
                            rowpos = rowpos + 1
                        End If
                        If Not workers(i).Item("cat").ToString.Equals(workers(i - 1).Item("cat").ToString) Or loadingState Then ' category
                            rowpos = rowpos + 1
                        End If
                    End If
                    rowpos = rowpos + 1
                Next i
                rowpos += 2 ' totals lines

                ReDim idxTableWorkerPos(workers.Count - 1)
                ReDim serverData(rowpos, 32)


                statsI.absenseHours = New TimeSpan(0, 0, 0)

                For i = 0 To rowpos
                    For j = 0 To 32
                        serverData(i, j).site = 0
                        serverData(i, j).section = 0
                        serverData(i, j).company = 0
                        serverData(i, j).category = 0
                        serverData(i, j).categoryToday = 0
                        serverData(i, j).code = 0
                        serverData(i, j).name = ""
                        serverData(i, j).contact = ""
                        serverData(i, j).nfc = ""
                        serverData(i, j).eContact = ""
                        serverData(i, j).checkin = ""
                        serverData(i, j).checkout = ""
                        serverData(i, j).status = ""
                        serverData(i, j).absense = ""
                        serverData(i, j).notes = ""
                        serverData(i, j).photo = ""
                        serverData(i, j).reference = ""
                        serverData(i, j).validationReason = ""
                        serverData(i, j).duplicates = ""
                        serverData(i, j).otherSites = ""

                        serverData(i, j).data = Convert.ToDateTime("1970-01-01")
                    Next j
                Next i
                ReDim absense(workers.Count - 1, 32)
                ReDim record(workers.Count - 1, 32)
                For i = 0 To workers.Count - 1
                    For j = 0 To 31
                        absense(i, j) = 0
                        record(i, j) = 0
                    Next j
                Next i

                tableData = New DataTable
                tableData.Columns.Add(translations.getText("tasksTableColumnReference"), GetType(String))
                For i = 0 To num_days
                    tableData.Columns.Add(i.ToString, GetType(String))
                Next i
                Dim dr(tableData.Columns.Count - 1) As Object

                If data.ContainsKey("holidays") Then
                    holidaysJson = JArray.Parse(data.Item("holidays").ToString)
                    ReDim holidays(holidaysJson.Count - 1)
                    For i = 0 To holidaysJson.Count - 1
                        holidays(i) = Convert.ToDateTime(holidaysJson(i).Item("date").ToString)
                    Next i
                End If

                rowpos = 0
                serverData(rowpos, 0).site = workers(0).Item("site").ToString
                Array.Clear(dr, 0, dr.Length)
                dr(0) = works_site.Item("name")(InQueryDictionary(works_site, workers(0).Item("site").ToString, "cod_site"))
                tableData.Rows.Add(dr)
                rowpos = rowpos + 1

                serverData(rowpos, 0).section = workers(0).Item("section").ToString
                Array.Clear(dr, 0, dr.Length)
                dr(0) = " " & works_sections.Item("description")(InQueryDictionary(works_sections, workers(0).Item("section").ToString, "cod_section"))
                tableData.Rows.Add(dr)
                rowpos = rowpos + 1

                serverData(rowpos, 0).company = workers(0).Item("company").ToString
                Array.Clear(dr, 0, dr.Length)
                dr(0) = "  " & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, workers(0).Item("company").ToString, "cod_entreprise"))
                tableData.Rows.Add(dr)
                rowpos = rowpos + 1

                serverData(rowpos, 0).category = workers(0).Item("cat").ToString
                Array.Clear(dr, 0, dr.Length)
                dr(0) = "   " & works_category.Item("designation")(InQueryDictionary(works_category, workers(0).Item("cat").ToString, "cod_category"))
                tableData.Rows.Add(dr)
                rowpos = rowpos + 1

                Dim posD As Integer = 0

                For i = 0 To workers.Count - 1
                    Array.Clear(dr, 0, dr.Length)

                    If i > 0 Then
                        If Not workers(i).Item("site").ToString.Equals(workers(i - 1).Item("site").ToString) Then ' obra
                            serverData(rowpos, 0).site = workers(i).Item("site").ToString
                            dr(0) = works_site.Item("name")(InQueryDictionary(works_site, workers(i).Item("site").ToString, "cod_site"))
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                        If Not workers(i).Item("section").ToString.Equals(workers(i - 1).Item("section").ToString) Then ' section
                            serverData(rowpos, 0).section = workers(i).Item("section").ToString
                            dr(0) = " " & works_sections.Item("description")(InQueryDictionary(works_sections, workers(i).Item("section").ToString, "cod_section"))
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                        If Not workers(i).Item("company").ToString.Equals(workers(i - 1).Item("company").ToString) Or loadingState Then ' company
                            serverData(rowpos, 0).company = workers(i).Item("company").ToString
                            dr(0) = "  " & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, workers(i).Item("company").ToString, "cod_entreprise"))
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                        If Not workers(i).Item("cat").ToString.Equals(workers(i - 1).Item("cat").ToString) Or loadingState Then ' category
                            serverData(rowpos, 0).category = workers(i).Item("cat").ToString
                            dr(0) = "   " & works_category.Item("designation")(InQueryDictionary(works_category, workers(i).Item("cat").ToString, "cod_category"))
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                    End If
                    loadingState = False
                    For j = 0 To num_days
                        serverData(rowpos, j).site = workers(i).Item("site").ToString
                        serverData(rowpos, j).section = workers(i).Item("section").ToString
                        serverData(rowpos, j).company = workers(i).Item("company").ToString
                        serverData(rowpos, j).category = workers(i).Item("cat").ToString
                        serverData(rowpos, j).code = workers(i).Item("code").ToString
                        serverData(rowpos, j).name = workers(i).Item("name").ToString
                        serverData(rowpos, j).contact = workers(i).Item("contact").ToString
                        serverData(rowpos, j).nfc = workers(i).Item("nfc").ToString
                        serverData(rowpos, j).eContact = workers(i).Item("112").ToString
                        serverData(rowpos, j).photo = workers(i).Item("photo").ToString
                        serverData(rowpos, j).reference = workers(i).Item("ref").ToString

                        serverData(rowpos, j).checkin = ""
                        serverData(rowpos, j).checkout = ""
                        serverData(rowpos, j).status = ""
                        serverData(rowpos, j).absense = ""
                        serverData(rowpos, j).notes = ""
                        serverData(rowpos, j).validationReason = ""
                        serverData(rowpos, j).data = Convert.ToDateTime("1970-01-01")

                    Next j

                    If data.ContainsKey("closure") Then
                        ClosuresJson = JArray.Parse(data.Item("closure").ToString)

                        For Each closureJson In ClosuresJson
                            Dim startP As DateTime = Convert.ToDateTime(closureJson.Item("start").ToString)
                            Dim endP As DateTime = Convert.ToDateTime(closureJson.Item("end").ToString)
                            Dim CurrD As DateTime = startP
                            While (CurrD <= endP)
                                If CurrD >= Convert.ToDateTime(calendarDate.Date.ToString("yyyy-MM-") & "01") And CurrD <= Convert.ToDateTime(calendarDate.Date.ToString("yyyy-MM-") & num_days) Then
                                    dr(CurrD.Day) = "FA"
                                End If
                                CurrD = CurrD.AddDays(1)
                            End While
                        Next closureJson
                    End If


                    Dim workerData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(workers(i).ToString)
                    If workerData.ContainsKey("record") Then
                        Dim records As JArray = JArray.Parse(workers(i).Item("record").ToString)
                        serverData(rowpos, 0).data = Convert.ToDateTime("1970-01-02")
                        Dim arr As String() = {"S", "EP", "MO"}
                        Dim planning As String() = {"EP", "MO"}

                        For Each recordJson In records
                            day = Convert.ToDateTime(recordJson.Item("date").ToString).Day

                            If recordJson.Item("site").ToString.Equals(workers(i).Item("site").ToString) And recordJson.Item("section").ToString.Equals(workers(i).Item("section").ToString) Then
                                serverData(rowpos, Day).checkin = recordJson.Item("checkin").ToString
                                serverData(rowpos, Day).checkout = recordJson.Item("checkout").ToString
                                serverData(rowpos, Day).status = recordJson.Item("status").ToString
                                serverData(rowpos, Day).absense = recordJson.Item("absense").ToString
                                serverData(rowpos, Day).notes = recordJson.Item("notas").ToString
                                serverData(rowpos, Day).data = Convert.ToDateTime(recordJson.Item("date").ToString)
                                serverData(rowpos, Day).validationReason = recordJson.Item("reason").ToString
                                serverData(rowpos, Day).categoryToday = recordJson.Item("category").ToString
                                serverData(rowpos, day).assignments = recordJson.Item("assignments").ToString

                                If TimeSpan.TryParse(recordJson.Item("absense").ToString, New TimeSpan()) Then
                                    statsI.absenseHours += TimeSpan.Parse(recordJson.Item("absense").ToString)
                                End If
                                If Not state.tableSearchOptions.viewPlanningAssignmentWorkers And Array.IndexOf(planning, recordJson.Item("status").ToString) > -1 Then
                                    dr(Day) = ""
                                Else
                                    dr(Day) = If(recordJson.Item("status").ToString.Equals("PI"), If(recordJson.Item("absense").ToString.Length < 5, recordJson.Item("absense").ToString, recordJson.Item("absense").ToString.Substring(0, 5).Replace(":", "H")), recordJson.Item("status").ToString)
                                End If

                                If Not recordJson.Item("notas").ToString().Equals("") Then
                                    dr(Day) = dr(Day) & "*"
                                End If
                            Else
                                Dim addSite As String = ""

                                If Not recordJson.Item("site").ToString.Equals(workers(i).Item("site").ToString) Or Not recordJson.Item("section").ToString.Equals(workers(i).Item("section").ToString) Then
                                    addSite = works_site("name")(InQueryDictionary(works_site, recordJson.Item("site").ToString, "cod_site"))
                                    If serverData(rowpos, Day).duplicates.IndexOf(addSite).Equals(-1) Then
                                        If state.tableSearchOptions.viewPlanningAssignmentWorkers Then
                                            serverData(rowpos, Day).duplicates &= addSite & Environment.NewLine
                                        ElseIf state.tableSearchOptions.viewOtherConstructionSitesAttendance And Array.IndexOf(arr, recordJson.Item("status").ToString) < 0 And ((Not recordJson.Item("checkout").ToString.Equals("") Or Not recordJson.Item("checkin").ToString.Equals("")) And Not recordJson.Item("status").ToString.Equals("")) Then
                                            serverData(rowpos, Day).duplicates &= addSite & Environment.NewLine
                                        End If
                                    End If
                                End If
                                addSite = works_site("initials")(InQueryDictionary(works_site, recordJson.Item("site").ToString, "cod_site"))
                                If recordJson.Item("status").ToString.Equals("EP") Then
                                    Dim sss = Array.IndexOf(arr, recordJson.Item("status").ToString)
                                    Dim ss = ""
                                End If
                                If serverData(rowpos, Day).otherSites.IndexOf(addSite).Equals(-1) And (Not recordJson.Item("site").ToString.Equals(workers(i).Item("site").ToString) Or Not recordJson.Item("section").ToString.Equals(workers(i).Item("section").ToString)) Then
                                    If state.tableSearchOptions.viewPlanningAssignmentWorkers Then
                                        serverData(rowpos, Day).otherSites &= If(serverData(rowpos, Day).otherSites.Equals(""), addSite, ", " & addSite)
                                    ElseIf state.tableSearchOptions.viewOtherConstructionSitesAttendance And Array.IndexOf(arr, recordJson.Item("status").ToString) < 0 And ((Not recordJson.Item("checkout").ToString.Equals("") Or Not recordJson.Item("checkin").ToString.Equals("")) And Not recordJson.Item("status").ToString.Equals("")) Then
                                        serverData(rowpos, Day).otherSites &= If(serverData(rowpos, Day).otherSites.Equals(""), addSite, ", " & addSite)
                                    End If
                                End If
                                If Array.IndexOf(arr, recordJson.Item("status").ToString) < 0 Then
                                    ReDim Preserve duplicateWorkerRecords(UBound(duplicateWorkerRecords) + 1)
                                    duplicateWorkerRecords(posD).data = recordJson.Item("date").ToString
                                    duplicateWorkerRecords(posD).codRecord = recordJson.Item("record").ToString
                                    duplicateWorkerRecords(posD).siteName = recordJson.Item("site").ToString
                                    duplicateWorkerRecords(posD).sectionName = recordJson.Item("section").ToString
                                    duplicateWorkerRecords(posD).workerName = workers(i).Item("name").ToString()
                                    duplicateWorkerRecords(posD).checkin = recordJson.Item("checkin").ToString
                                    duplicateWorkerRecords(posD).checkout = recordJson.Item("checkout").ToString
                                    duplicateWorkerRecords(posD).status = recordJson.Item("status").ToString()
                                    posD += 1
                                End If
                            End If

                        Next recordJson
                    End If

                    If workerData.ContainsKey("foreman") Then
                        Dim foremans As JArray = JArray.Parse(workers(i).Item("foreman").ToString)
                        For Each foremanJson In foremans
                            Day = Convert.ToDateTime(foremanJson.Item("date").ToString).Day
                            serverData(rowpos, Day).foreman = True
                        Next foremanJson
                    End If

                    If workerData.ContainsKey("absense") Then
                        Dim absensesJson As JArray = JArray.Parse(workers(i).Item("absense").ToString)
                        For Each absenseJson In absensesJson
                            Dim startP As DateTime = Convert.ToDateTime(absenseJson.Item("start").ToString)
                            Dim endP As DateTime = Convert.ToDateTime(absenseJson.Item("end").ToString)
                            Dim CurrD As DateTime = startP
                            While (CurrD <= endP)
                                If CurrD >= Convert.ToDateTime(calendarDate.Date.ToString("yyyy-MM-") & "01") And CurrD <= Convert.ToDateTime(calendarDate.Date.ToString("yyyy-MM-") & num_days) Then
                                    absense(i, CurrD.Day) = 1
                                End If
                                CurrD = CurrD.AddDays(1)
                            End While
                        Next absenseJson
                    End If

                    idxTableWorkerPos(i) = rowpos
                    dr(0) = workers(i).Item("name").ToString
                    rowpos = rowpos + 1
                    tableData.Rows.Add(dr)
                Next i


                translations.load("attendance")
                Array.Clear(dr, 0, dr.Length)
                dr(0) = translations.getText("tableRowTotalValidated")
                tableData.Rows.Add(dr)
                rowpos = rowpos + 1
                Array.Clear(dr, 0, dr.Length)
                dr(0) = translations.getText("tableRowTotalNonValidated")
                tableData.Rows.Add(dr)
                rowpos = rowpos + 1
                translations.load("commonForm")
                Array.Clear(dr, 0, dr.Length)
                dr(0) = translations.getText("tableRowTotal")
                tableData.Rows.Add(dr)
            End If

        Catch ex As Exception
            errorMessage = ex.Message.ToString
            saveCrash(ex)
            Return Nothing
        End Try

        'CALC TOTALS
        Dim horizontalCounter() As Integer
        Dim verticalCounter() As Integer
        Dim verticalCounterNonValidated() As Integer
        ReDim verticalCounter(num_days - 1)
        ReDim verticalCounterNonValidated(num_days - 1)
        ReDim horizontalCounter(tableData.Rows.Count - 3)

        statsI.totalDaysWorked = 0
        For i = 0 To tableData.Columns.Count - 3
            For j = 1 To num_days
                If IsDBNull(tableData.Rows(i)(j)) Then
                    Continue For
                End If

                If tableData.Rows(i)(j).Equals("P") Or tableData.Rows(i)(j).Equals("P*") Or tableData.Rows(i)(j).IndexOf("H") > 0 Then
                    horizontalCounter(i - 1) = If(Not IsNothing(horizontalCounter(i - 1)), horizontalCounter(i - 1) + 1, 1)
                    verticalCounter(j - 1) = If(Not IsNothing(verticalCounter(j - 1)), verticalCounter(j - 1) + 1, 1)
                End If
                If (tableData.Rows(i)(j).Equals("EP") Or tableData.Rows(i)(j).Equals("EP*") Or tableData.Rows(i)(j).Equals("")) And Not serverData(j, i).checkin.Equals("00:00:00") And Not serverData(j, i).checkin.Equals("") And Not serverData(j, i).checkin.Equals("null") Then
                    verticalCounterNonValidated(j - 1) = If(Not IsNothing(verticalCounterNonValidated(j - 1)), verticalCounterNonValidated(j - 1) + 1, 1)             ' num registered workers not validated
                End If

                If Not serverData(i, j).otherSites.Equals("") And state.tableSearchOptions.viewOtherConstructionSitesAttendance And (tableData.Rows(i)(j).Equals("") Or tableData.Rows(i)(j).IndexOf("EP") > -1 Or tableData.Rows(i)(j).IndexOf("MO") > -1) Then
                    tableData.Rows(i)(j) = serverData(i, j).otherSites
                ElseIf Not state.tableSearchOptions.viewPlanningAssignmentWorkers And (tableData.Rows(i)(j).Equals("EP") Or tableData.Rows(i)(j).Equals("EP*")) Then
                    tableData.Rows(i)(j) = ""
                ElseIf Not state.tableSearchOptions.viewPlanningAssignmentWorkers And (tableData.Rows(i)(j).Equals("MO") Or tableData.Rows(i)(j).Equals("MO*")) Then
                    tableData.Rows(i)(j) = ""
                End If
            Next j
            statsI.totalDaysWorked = Math.Max(stats.totalDaysWorked, horizontalCounter(i - 1))
            tabledata.Rows(i)(num_days + 1) = If(IsNothing(horizontalCounter(i - 1)), "", horizontalCounter(i - 1).ToString())
        Next i

        statsI.totalDaysInMonth = 0
        statsI.maxWorkers = 0
        statsI.minWorkers = 1000
        statsI.totalWorkDays = 0
        For i = 1 To num_days
            If IsWeekday(DateTime.Parse(calendarDate.Date.ToString("yyyy-MM") & "-" & If(i < 10, "0" & i.ToString, i.ToString))) Then
                statsI.totalDaysInMonth += 1

                If Not IsNothing(holidays) Then
                    If Not holidays.Contains(Convert.ToDateTime(calendarDate.Date.ToString("yyyy-MM-") & If(i < 10, "0" & i, i))) Then
                        statsI.totalWorkDays += 1
                    End If
                Else
                    statsI.totalWorkDays += 1
                End If

            End If
            'rows count-1 = totals
            'rows count-2 = totals non validated
            'rows count-3 = totals validated
            tabledata.Rows(tableData.Rows.Count - 3)(i) = If(IsNothing(verticalCounter(i - 1)), "", verticalCounter(i - 1).ToString())
            tableData.Rows(tableData.Rows.Count - 2)(i) = If(IsNothing(verticalCounterNonValidated(i - 1)), "", verticalCounterNonValidated(i - 1).ToString())
            Dim sumCounts As Integer = If(IsNothing(verticalCounter(i - 1)), 0, verticalCounter(i - 1)) + If(IsNothing(verticalCounterNonValidated(i - 1)), 0, verticalCounterNonValidated(i - 1))
            tableData.Rows(tableData.Rows.Count - 1)(i) = If(sumCounts.Equals(0), "", sumCounts.ToString())

            statsI.maxWorkers = Math.Max(stats.maxWorkers, If(tabledata(tabledata.Rows.Count - 1)(i).Equals(""), 0, Convert.ToInt32(tabledata(tabledata.Rows.Count - 1)(i))))
            If Not tableData(tableData.Rows.Count - 3)(i).Equals("0") And Not tableData(tableData.Rows.Count - 3)(i).Equals("") Then
                statsI.minWorkers = Math.Min(stats.minWorkers, Convert.ToInt32(tabledata(tabledata.Rows.Count - 3)(i)))
            End If
        Next i

        tableData.Rows(tableData.Rows.Count - 3)(num_days + 1) = horizontalCounter.Sum().ToString() & "(" & verticalCounter.Sum().ToString() & ")"
        tableData.Rows(tableData.Rows.Count - 2)(num_days + 1) = verticalCounterNonValidated.Sum().ToString()
        tableData.Rows(tableData.Rows.Count - 1)(num_days + 1) = (verticalCounterNonValidated.Sum() + horizontalCounter.Sum()).ToString()

        statsI.minWorkers = If(stats.minWorkers.Equals(1000), 0, stats.minWorkers)

        stats = statsI
        Return tabledata
    End Function

    Public Function BuildNotesTableData()
        If tableData Is Nothing Then
            Return Nothing
        End If
        tableDataNotes = New DataTable
        tableDataNotes.Columns.Add(translations.getText("tableHeaderName"), GetType(String))
        tableDataNotes.Columns.Add(translations.getText("dateTitle"), GetType(String))
        tableDataNotes.Columns.Add(translations.getText("dropdownSiteTitle"), GetType(String))
        tableDataNotes.Columns.Add(translations.getText("siteSection"), GetType(String))
        tableDataNotes.Columns.Add(translations.getText("reason"), GetType(String))
        tableDataNotes.Columns.Add(translations.getText("productionTableColumnAnnotations"), GetType(String))

        Dim dr(tableData.Columns.Count - 1) As Object

        For i = 0 To tableData.Rows.Count - 3
            For j = 1 To tableData.Columns.Count - 1

                If Not serverData(i, j).notes.Equals("") Then
                    Array.Clear(dr, 0, dr.Length)

                    dr(5).Value = serverData(i, j).notes
                    dr(1).Value = serverData(i, j).data
                    dr(0).Value = serverData(i, j).name
                    dr(2).Value = works_site("name")(InQueryDictionary(works_site, serverData(i, j).site, "cod_site"))
                    dr(3).Value = works_sections("description")(InQueryDictionary(works_sections, serverData(i, j).section, "cod_section"))
                    tableData.Rows.Add(dr)
                End If

                If Not serverData(i, j).validationReason.Equals("") Then
                    Array.Clear(dr, 0, dr.Length)

                    dr(4).Value = serverData(i, j).validationReason
                    dr(1).Value = serverData(i, j).data
                    dr(0).Value = serverData(i, j).name
                    dr(2).Value = works_site("name")(InQueryDictionary(works_site, serverData(i, j).site, "cod_site"))
                    dr(3).Value = works_sections("description")(InQueryDictionary(works_sections, serverData(i, j).section, "cod_section"))
                    tableData.Rows.Add(dr)
                End If
            Next j
        Next i

        Return tableDataNotes
    End Function
End Class
