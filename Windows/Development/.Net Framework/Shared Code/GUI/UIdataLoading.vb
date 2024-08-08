﻿Imports System.Drawing
Imports System.Windows.Forms
Imports ConstructionSiteLogistics.Libraries.Core

Public Module UIdataLoading
    Public Function orderTasksList(listDB As Dictionary(Of String, List(Of String))) As Dictionary(Of String, List(Of String))
        Dim newOrder() As Integer
        ReDim newOrder(listDB.Item("cod_task").Count - 1)
        Dim pos As Integer = 0
        Dim stateCore As New environmentVarsCore

        For i = 0 To listDB.Item("previous_task").Count - 1
            If listDB.Item("previous_task")(i).Equals("0") Then
                newOrder(pos) = i
                pos += 1
                Exit For
            End If
        Next i
        Dim foundTask As Boolean = True
        While foundTask
            Dim foundSubTask As Boolean = False
            For i = 0 To listDB.Item("cod_task").Count - 1
                If listDB.Item("previous_task")(i).Equals(listDB.Item("cod_task")(newOrder(pos - 1))) Then
                    newOrder(pos) = i
                    pos += 1
                    foundSubTask = True
                    Exit For
                End If
            Next i
            foundTask = If(foundSubTask, True, False)
        End While

        Dim results = New Dictionary(Of String, List(Of String))
        For k = 0 To stateCore.queryBordereauFields.Length - 1
            Dim fieldValues As List(Of String) = New List(Of String)
            For i = 0 To newOrder.Length - 1
                fieldValues.Add(listDB.Item(stateCore.queryBordereauFields(k))(newOrder(i)))
            Next i
            results.Add(stateCore.queryBordereauFields(k), fieldValues)
        Next k
        Return results

    End Function

    Public Function loadSitesWithSections(combo_site As ComboBox, sitesDB As Dictionary(Of String, List(Of String)), sectionsDB As Dictionary(Of String, List(Of String)), Optional loadAll As Boolean = True, Optional loadInactive As Boolean = False) As Integer(,)
        Dim translations As languageTranslations
        Dim state As environmentVars
        Dim siteSelection As Integer(,)

        state = New environmentVars(LOAD_SETTINGS)
        translations = New languageTranslations(state)
        translations.load("commonForm")
        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = New Form().CreateGraphics

        ReDim siteSelection(2 * sitesDB.Item("name").Count + sectionsDB.Item("cod_section").Count, 1)
        combo_site.Items.Clear()
        combo_site.Items.Add(translations.getText("dropdownSelectSite"))
        Dim numChars = CInt(combo_site.Width / (g.MeasureString(".", fontToMeasure).Width / 1.35)) + 1
        combo_site.Items.Add(StrDup(numChars, "_"))
        Dim pos As Integer = 0
        siteSelection(pos, 0) = -2
        siteSelection(pos, 1) = -2
        pos += 1
        For j = 0 To sitesDB.Item("name").Count - 1
            If Not loadInactive And sitesDB.Item("active")(j).Equals("0") Then
                Continue For
            End If

            If loadAll Then
                combo_site.Items.Add(sitesDB.Item("name")(j) & "  ( " & translations.getText("dropdownSelectAll") & " )")
                siteSelection(pos, 0) = sitesDB.Item("cod_site")(j)
                siteSelection(pos, 1) = -1
                pos += 1
            End If
            For i = 0 To sectionsDB.Item("cod_section").Count - 1
                If sectionsDB.Item("cod_site")(i).Equals(sitesDB.Item("cod_site")(j)) Then
                    If Not loadAll Then
                        combo_site.Items.Add(sitesDB.Item("name")(j) & " >> " & sectionsDB.Item("description")(i))
                    Else
                        combo_site.Items.Add(sectionsDB.Item("description")(i))
                    End If

                    siteSelection(pos, 0) = sitesDB.Item("cod_site")(j)
                    siteSelection(pos, 1) = sectionsDB.Item("cod_section")(i)
                    pos += 1
                End If
            Next i
            combo_site.Items.Add(StrDup(numChars, "_"))
            siteSelection(pos, 0) = -2
            siteSelection(pos, 1) = -2
            pos += 1
        Next j
        If loadAll Then
            combo_site.Items.Add(translations.getText("dropdownSelectAll"))
            combo_site.SelectedIndex = 0
            siteSelection(pos, 0) = -1
            siteSelection(pos, 1) = -1
        End If
        Return siteSelection
    End Function

    Public Function loadSitesWithSectionsChecked(combo_site As ListBox, sitesDB As Dictionary(Of String, List(Of String)), sectionsDB As Dictionary(Of String, List(Of String)), Optional loadAll As Boolean = True) As Integer(,)
        Dim translations As languageTranslations
        Dim stateCore As environmentVars
        Dim siteSelection As Integer(,)

        stateCore = New environmentVars(LOAD_SETTINGS)
        translations = New languageTranslations(stateCore)
        translations.load("commonForm")
        Dim fontToMeasure As New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = New Form().CreateGraphics

        ReDim siteSelection(2 * sitesDB.Item("name").Count + sectionsDB.Item("cod_section").Count, 1)
        combo_site.Items.Clear()
        Dim numChars = CInt(combo_site.Width / (g.MeasureString(".", fontToMeasure).Width / 1.35)) + 1
        Dim pos As Integer = 0
        For j = 0 To sitesDB.Item("name").Count - 1
            If loadAll Then
                combo_site.Items.Add(sitesDB.Item("name")(j) & "  ( " & translations.getText("dropdownSelectAll") & " )")
                siteSelection(pos, 0) = sitesDB.Item("cod_site")(j)
                siteSelection(pos, 1) = -1
                pos += 1
            End If
            For i = 0 To sectionsDB.Item("cod_section").Count - 1
                If sectionsDB.Item("cod_site")(i).Equals(sitesDB.Item("cod_site")(j)) Then
                    If loadAll Then
                        combo_site.Items.Add(sectionsDB.Item("description")(i))
                    Else
                        combo_site.Items.Add(sitesDB.Item("name")(j) & " >> " & sectionsDB.Item("description")(i))
                    End If
                    siteSelection(pos, 0) = sitesDB.Item("cod_site")(j)
                    siteSelection(pos, 1) = sectionsDB.Item("cod_section")(i)
                    pos += 1
                End If
            Next i
            combo_site.Items.Add(StrDup(numChars, "_"))
            siteSelection(pos, 0) = -2
            siteSelection(pos, 1) = -2
            pos += 1
        Next j
        If loadAll Then
            combo_site.Items.Add(translations.getText("dropdownSelectAll"))
            combo_site.SelectedIndex = 0
            siteSelection(pos, 0) = -1
            siteSelection(pos, 1) = -1
        End If
        Return siteSelection
    End Function
End Module
