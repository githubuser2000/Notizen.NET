Public Class Baum_Kontext_
    Inherits ContextMenuStrip
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    'Private wahl As Short

    Public Sub New()
        MyBase.New()
        Me.Items.Add("Neu")
        Me.Items.Add("Neu")
        Me.Items.Add("Umbenennen")
        Me.Items.Add("Kopieren")
        Me.Items.Add("Ausschneiden")
        Me.Items.Add("Einfuegen")
        Me.Items.Add("Loechen")
        Me.Items.Add("Speichern")
        Me.Items.Add("Haft-Notiz")
        Me.Items.Add("Hintergrundfarbe")
        Me.Items.Add("Schriftfarbe")
    End Sub

  

    Private Delegate Sub set_clientsizes_delegate()
    'Private Delegate Sub refresh()

    Private Sub enhance_desknote_from_selected_node(ByVal node As TreeNode)
        node.Tag.desknote.invoke(New set_clientsizes_delegate(AddressOf node.Tag.desknote.refresh))
        'If Not TypeOf node Is TreeNode Then
        '    MsgBox("0")
        'ElseIf Not TypeOf node.Tag Is CText Then
        '    MsgBox("1")
        'ElseIf Not TypeOf node.Tag.desknote Is desknote Then
        '    MsgBox("2")
        'End If
        'Threading.Thread.Sleep(1000)
        node.Tag.desknote.invoke(New set_clientsizes_delegate(AddressOf node.Tag.desknote.set_clientsizes))

    End Sub

    Private Sub Baum_Kontext__ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Me.ItemClicked
        Me.Hide()
        If e.ClickedItem Is Items(0) Then
            'wahl = 0
            'setzt eins drunter, aber editiert aktuelles
            Notizen.Baum.element_dazu()
        ElseIf e.ClickedItem Is Items(1) Then
            Notizen.neu_neben_knoten()
        ElseIf e.ClickedItem Is Items(2) Then
            'wahl = 1
            If Notizen.Baum.SelectedNode IsNot Nothing Then
                If Notizen.Baum.SelectedNode.IsEditing = False Then
                    Notizen.Baum.LabelEdit = True
                    Notizen.Baum.SelectedNode.BeginEdit()
                End If
            Else
                MsgBox("There must be a selected treenode.")
            End If
        ElseIf e.ClickedItem Is Items(6) Then
            'wahl = 2
            If Notizen.Baum.SelectedNode IsNot Nothing Then
                Notizen.Baum.element_loeschen()
            Else
                MsgBox("There must be a selected treenode.")
            End If
        ElseIf e.ClickedItem Is Items(7) Then
            If Notizen.Baum.SelectedNode IsNot Nothing Then
                Me.Show(0, 0)
                Me.Close()
                SaveFileDialog1 = New SaveFileDialog
                SaveFileDialog1.Filter = "rtf Files|*.rtf"
                SaveFileDialog1.DefaultExt = "*.rtf"
                SaveFileDialog1.InitialDirectory = Notizen.odatei.Verzeichnis
                SaveFileDialog1.FileName = "unbenannt.rtf"
                Dim bclick As DialogResult = SaveFileDialog1.ShowDialog()
                If bclick = DialogResult.OK Then
                    'Try
                    Dim datenstrom As New System.IO.FileStream(SaveFileDialog1.FileName, IO.FileMode.Create, IO.FileAccess.Write)
                    Dim schreiber As New System.IO.StreamWriter(datenstrom)
                    schreiber.Write(Notizen.Inhalt.node.Tag.text)
                    schreiber.Close()
                    'Catch ex As Exception
                    '    Dim fehler As Dialog_Error = New Dialog_Error(ex)
                    '    fehler.Show()
                    'End Try
                End If
            Else
                MsgBox("There must be a selected treenode.")
            End If
        ElseIf e.ClickedItem Is Items(8) Then
            'wahl = 4
            If Notizen.Baum.SelectedNode IsNot Nothing Then
                Notizen.create_desknode(New Rectangle(MousePosition.X, MousePosition.Y, 200, 200), Notizen.Baum.SelectedNode, 0.85, Notizen.get_lightcolor)
                Dim strang As New Threading.Thread(AddressOf enhance_desknote_from_selected_node)
                strang.Start(Notizen.Baum.SelectedNode)
            Else
                MsgBox("There must be a selected treenode.")
            End If
        ElseIf e.ClickedItem Is Items(3) Then
            If Notizen.Baum.SelectedNode IsNot Nothing Then
                Notizen.copy_node()
            Else
                MsgBox("There must be a selected treenode.")
            End If
        ElseIf e.ClickedItem Is Items(4) Then
            If Notizen.Baum.SelectedNode IsNot Nothing Then
                Notizen.cut_anything(False)
            Else
                MsgBox("There must be a selected treenode.")
            End If
        ElseIf e.ClickedItem Is Items(5) Then
            If Notizen.Baum.SelectedNode IsNot Nothing Then
                Notizen.paste_anything(False)
            Else
                MsgBox("There must be a selected treenode.")
            End If
        ElseIf e.ClickedItem Is Items(9) Then
            If Notizen.Baum.SelectedNode IsNot Nothing Then
                Dim b As New ColorDialog
                If b.ShowDialog() = DialogResult.OK And Notizen.Baum.SelectedNode IsNot Nothing Then
                    'MsgBox(Notizen.Baum.SelectedNode.BackColor.ToArgb.ToString)
                    Notizen.Baum.SelectedNode.BackColor = b.Color
                    Notizen.have_changed_file()
                End If
            Else
                MsgBox("There must be a selected treenode.")
            End If
        ElseIf e.ClickedItem Is Items(10) Then
            If Notizen.Baum.SelectedNode IsNot Nothing Then
                Dim b As New ColorDialog
                If b.ShowDialog() = DialogResult.OK And Notizen.Baum.SelectedNode IsNot Nothing Then
                    Notizen.Baum.SelectedNode.ForeColor = b.Color
                    Notizen.have_changed_file()
                End If
            Else
                MsgBox("There must be a selected treenode.")
            End If
        End If
    End Sub
End Class
