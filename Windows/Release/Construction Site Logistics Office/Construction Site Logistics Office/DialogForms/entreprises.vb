Public Class entreprises_frm
    Private response As String = ""

    Dim works As String(,)
    Sub load_list()


        response = NetworkRequest(false, "get", "task=query&request=entreprises")
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        works = ConvertDataToArray(response)

        listview_works.Items.Clear()
        listview_works.Items.Add("Adicionar Nova empresa")

        If Not works(1, 1).Equals("") Then
            For i = 1 To works.GetLength(0) - 1
                listview_works.Items.Add(works(i, 2))
            Next i
        End If

    End Sub

    Private Sub entreprises_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub entreprises_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        MainMdiForm.busy.Close(True)


        load_list()
        LinkLabel_del.Enabled = False

    End Sub




    Private Sub LinkLabel_del_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_del.LinkClicked
        Dim msgbox As message_box_frm

        If (listview_works.SelectedItems.Count > 0) Then
            msgbox = New message_box_frm("Tem a certeza que quer remover?", "Questão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If (msgbox.ShowDialog = DialogResult.OK) Then
                Dim cod_prod As String = works(listview_works.SelectedIndices(0), 1)
                response = NetworkRequest(False, "get", "task=entreprises&type=del&cod=" & cod_prod)
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                If Not IsResponseOk(response) Then
                    msgbox = New message_box_frm(GetMessage(response), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()

                End If
                txt_name.Text = ""
                txt_contact.Text = ""
                load_list()
                msgbox = New message_box_frm("Empresa eliminada (" & cod_prod & ")", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                msgbox.ShowDialog()

            End If
        End If
    End Sub

    Private Sub LinkLabel_save_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_save.LinkClicked
        Dim cod_prod As String
        Dim msgbox As message_box_frm
        If txt_name.Text <> "" And txt_contact.Text <> "" Then
            If (listview_works.SelectedItems.Count > 0) Then
                If (listview_works.SelectedIndices(0) = 0) Then 'new item

                    response = NetworkRequest(False, "get", "task=entreprises&type=add&name=" & txt_name.Text & "&contact=" & txt_contact.Text)
                    If Not IsNothing(MainMdiForm.busy) Then
                        If MainMdiForm.busy.isActive().Equals(True) Then
                            MainMdiForm.busy.Close(True)
                        End If
                    End If
                    If Not IsResponseOk(response) Then
                        msgbox = New message_box_frm(GetMessage(response), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        msgbox.ShowDialog()

                    End If
                    msgbox = New message_box_frm("Empresa adicionada ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    msgbox.ShowDialog()
                Else ' edit item
                    cod_prod = works(listview_works.SelectedIndices(0), 1)
                    response = NetworkRequest(False, "get", "task=entreprises&type=edit&name=" & txt_name.Text & "&contact=" & txt_contact.Text & "&cod=" & cod_prod)
                    If Not IsNothing(MainMdiForm.busy) Then
                        If MainMdiForm.busy.isActive().Equals(True) Then
                            MainMdiForm.busy.Close(True)
                        End If
                    End If
                    If Not IsResponseOk(response) Then
                        msgbox = New message_box_frm(GetMessage(response), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        msgbox.ShowDialog()
                    End If

                    msgbox = New message_box_frm("Empresa editada (" & cod_prod & ")", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    msgbox.ShowDialog()

                End If
            Else ' new item
                response = NetworkRequest(False, "get", "task=entreprises&type=add&name=" & txt_name.Text & "&contact=" & txt_contact.Text)
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                If Not IsResponseOk(response) Then
                    msgbox = New message_box_frm(GetMessage(response), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()

                End If
                msgbox = New message_box_frm("Empresa adicionada ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                msgbox.ShowDialog()
            End If
            load_list()
            txt_name.Text = ""
            txt_contact.Text = ""
        Else
            msgbox = New message_box_frm("Campo nao pode estar vazio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            If txt_name.Text = "" Then
                txt_name.Focus()
            Else
                txt_contact.Focus()
            End If
        End If

    End Sub



    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        load_list()
    End Sub



    Private Sub listview_works_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles listview_works.SelectedIndexChanged
        If (listview_works.SelectedItems.Count > 0) Then
            txt_name.Text = listview_works.SelectedItems(0).ToString
            If listview_works.SelectedIndices(0) = 0 Then
                LinkLabel_del.Enabled = False
                txt_contact.Text = ""
            Else
                If (listview_works.SelectedItems.Count > 0) Then
                    txt_contact.Text = works(listview_works.SelectedIndices(0), 3)
                End If
                LinkLabel_del.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub
End Class