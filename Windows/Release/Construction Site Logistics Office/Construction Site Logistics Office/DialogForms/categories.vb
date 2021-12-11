Public Class categories_frm
    Dim works As String(,)
    Private response As String = ""

    Private Sub CloseMe()
        Me.Close()
    End Sub


    Sub load_list()
        Dim item As New ListViewItem




        response = NetworkRequest(False, "get", "task=query&request=categories")
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        works = ConvertDataToArray(response)

        listview_works.Items.Clear()
        listview_works.Items.Add("Adicionar nova categoria")

        If Not works(1, 1).Equals("") Then
            For i = 1 To works.GetLength(0) - 1
                listview_works.Items.Add(works(i, 2))
            Next i
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
    End Sub

    Private Sub categories_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub categories_frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        MainMdiForm.busy.Close(True)

        load_list()
        LinkLabel_del.Enabled = False

    End Sub




    Private Sub LinkLabel_del_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_del.LinkClicked
        Dim cod_prod As String
        Dim msgbox As message_box_frm

        If (listview_works.SelectedItems.Count > 0) Then
            msgbox = New message_box_frm("Tem a certeza que quer remover?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If (msgbox.ShowDialog = DialogResult.OK) Then
                cod_prod = works(listview_works.SelectedIndices(0), 1)
                response = NetworkRequest(False, "get", "task=categories&type=del&cod=" & cod_prod)
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
                load_list()
                msgbox = New message_box_frm("Tipo de categoria eliminado (" & cod_prod & ")", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()

            End If
        End If
    End Sub

    Private Sub LinkLabel_save_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_save.LinkClicked
        Dim cod_prod As String
        Dim msgbox As message_box_frm


        If txt_name.Text <> "" Then
            If (listview_works.SelectedItems.Count > 0) Then
                If (listview_works.SelectedIndices(0) = 0) Then 'new item
                    response = NetworkRequest(False, "get", "task=categories&type=add&name=" & txt_name.Text)
                    If Not IsNothing(MainMdiForm.busy) Then
                        If MainMdiForm.busy.isActive().Equals(True) Then
                            MainMdiForm.busy.Close(True)
                        End If
                    End If
                    If Not IsResponseOk(response) Then
                        msgbox = New message_box_frm(GetMessage(response), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        msgbox.ShowDialog()

                    Else
                        msgbox = New message_box_frm("Tipo de categoria adicionado ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        msgbox.ShowDialog()

                    End If
                Else ' edit item
                    cod_prod = works(listview_works.SelectedIndices(0), 1)
                    response = NetworkRequest(False, "get", "task=categories&type=edit&name=" & txt_name.Text & "&cod=" & cod_prod)
                    If Not IsNothing(MainMdiForm.busy) Then
                        If MainMdiForm.busy.isActive().Equals(True) Then
                            MainMdiForm.busy.Close(True)
                        End If
                    End If
                    If Not IsResponseOk(response) Then
                        msgbox = New message_box_frm(GetMessage(response), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        msgbox.ShowDialog()

                    Else
                        msgbox = New message_box_frm("Tipo de categoria editada (" & cod_prod & ")", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        msgbox.ShowDialog()

                    End If
                End If
            Else ' new item
                response = NetworkRequest(False, "get", "task=categories&type=add&name=" & txt_name.Text)
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                If Not IsResponseOk(response) Then
                    msgbox = New message_box_frm(GetMessage(response), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                Else
                    msgbox = New message_box_frm("Tipo de categoria adicionado ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    msgbox.ShowDialog()
                End If
            End If
            txt_name.Text = ""
            load_list()
        Else
            msgbox = New message_box_frm("Campo nao pode estar vazio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()

            txt_name.Focus()
        End If

    End Sub

    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        Me.Close()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        load_list()
    End Sub

    Private Sub listview_works_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listview_works.SelectedIndexChanged
        If (listview_works.SelectedItems.Count > 0) Then
            txt_name.Text = listview_works.SelectedItems(0).ToString
            If listview_works.SelectedIndices(0) = 0 Then
                LinkLabel_del.Enabled = False
            Else
                LinkLabel_del.Enabled = True
            End If
        End If
    End Sub
End Class