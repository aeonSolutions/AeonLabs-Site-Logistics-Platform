Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

Public Class ExportExcelClass
    Public Sub New()

    End Sub

    Public Sub ExportDataTable(ByVal table As DataTable, ByVal exportFile As String)
        ' Create a spreadsheet document by supplying the filepath.
        ' By default, AutoSave = true, Editable = true, and Type = xlsx.
        Dim spreadsheetDocument As SpreadsheetDocument = spreadsheetDocument.Create(exportFile, SpreadsheetDocumentType.Workbook)

        ' Add a WorkbookPart to the document.
        Dim workbook As WorkbookPart = spreadsheetDocument.AddWorkbookPart
        workbook.Workbook = New Workbook

        ' Add a WorksheetPart to the WorkbookPart.
        Dim Worksheet As WorksheetPart = workbook.AddNewPart(Of WorksheetPart)()
        Worksheet.Worksheet = New Worksheet(New SheetData())

        ' Add Sheets to the Workbook.
        Dim sheets As Sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(Of Sheets)(New Sheets())

        Dim data As SheetData = Worksheet.Worksheet.GetFirstChild(Of SheetData)()
        Dim Header As Row = New Row()
        Header.RowIndex = CType(1, UInt32)

        For Each column As DataColumn In table.Columns
            Dim headerCell As Cell = createTextCell(table.Columns.IndexOf(column) + 1, 1, column.ColumnName)
            Header.AppendChild(headerCell)
        Next

        data.AppendChild(Header)

        Dim contentRow As DataRow
        For i As Integer = 0 To table.Rows.Count - 1
            contentRow = table.Rows(i)
            data.AppendChild(createContentRow(contentRow, i + 2))
        Next

    End Sub

    Private Function createTextCell(ByVal columnIndex As Integer, ByVal rowIndex As Integer, ByVal cellValue As Object) As Cell
        Dim cell As Cell = New Cell()
        cell.DataType = CellValues.InlineString

        cell.CellReference = getColumnName(columnIndex) + rowIndex.ToString

        Dim inlineString As InlineString = New InlineString()
        Dim t As Text = New Text()
        t.Text = cellValue.ToString()
        inlineString.AppendChild(t)
        cell.AppendChild(inlineString)
        Return cell
    End Function

    Private Function createContentRow(ByVal dataRow As DataRow, ByVal rowIndex As Integer) As Row
        Dim row As Row = New Row With {
            .rowIndex = CType(rowIndex, UInt32)
        }

        For i As Integer = 0 To dataRow.Table.Columns.Count - 1
            Dim dataCell As Cell = createTextCell(i + 1, rowIndex, dataRow(i))
            row.AppendChild(dataCell)
        Next

        Return row
    End Function

    Private Function getColumnName(ByVal columnIndex As Integer) As String
        Dim dividend As Integer = columnIndex
        Dim columnName As String = String.Empty
        Dim modifier As Integer

        While dividend > 0
            modifier = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modifier).ToString() & columnName
            dividend = CInt(((dividend - modifier) / 26))
        End While

        Return columnName
    End Function
End Class
