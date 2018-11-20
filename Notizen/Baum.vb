
Public Class BaumTyp
    Inherits TreeView
    Delegate Function mk_anf(ByRef knoten As TreeNode) As Boolean
    Delegate Sub mk_end()

#Region "Attribute"

    Public WithEvents bkontext As New Baum_Kontext_
    Private SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
    Private Const endure As Byte = 0
    Private node_to_move As TreeNode
    Private level As Short
    Private index As Short
    Private hauptknoten As TreeNode
    Private marki As Boolean

#End Region

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub zeige(ByRef e As System.Windows.Forms.TreeNodeMouseClickEventArgs)
        Me.ContextMenuStrip.Show(e.X + Notizen.Location.X, e.Y + Notizen.Location.Y)
    End Sub
    Private Sub InitializeComponent()
        'Me.SuspendLayout()
        'Me.Name = "kontext_baum"
        'Me.Size = New System.Drawing.Size(296, 277)
        'Me.ResumeLayout(False)
        Me.ContextMenuStrip = New Baum_Kontext_
        Me.HideSelection = False
    End Sub

#Region "durchgeh"
    Private Sub nodes_end(ByRef knoten As TreeNode)
        If knoten.Tag.mark = Not marki Then
            knoten.Tag.mark = marki
        End If
    End Sub
    Public Function fuelle(ByRef knoten As TreeNode)
        If TypeOf (knoten.Tag) Is CText And Not knoten.Tag Is Nothing Then
            Return knoten.Tag.text
        Else
            Return ""
        End If
    End Function
    Private Function ob_vater(ByRef knoten As TreeNode) As Boolean
        ' Wenn es keinen weiteren Bruder gibt
        ' Ob es einen Vater gibt
        If (TypeOf (knoten.Parent) Is TreeNode) Then

            ' Ob der Vater nicht der Vater aller ist
            If knoten.Parent IsNot hauptknoten Then
                Return True
            End If
        End If
        Return False
    End Function
    Private Function ob_bruder(ByRef knoten As TreeNode) As Boolean
        ' Ob es einen Bruder geben könnte
        If (TypeOf (knoten.NextNode) Is TreeNode) Then
            ' Ob es wirklich der Bruder ist
            'If (knoten.NextVisibleNode Is knoten.NextNode) Then
            If (knoten.Level = knoten.NextNode.Level) _
            Or (knoten.NextNode Is hauptknoten) Then

                ' mach alles für Brüder
                If knoten.NextNode.Tag.mark = Not marki Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function
    Private Function ob_kind(ByRef knoten As TreeNode) As Boolean
        ' Ob es ein Kind gibt
        If (TypeOf (knoten.FirstNode) Is TreeNode) Then
            ' Ob es das ERSTE Kind ist
            'Das heißt ob vorheriger knoten elternknoten war
            'If (knoten.FirstNode Is knoten.NextVisibleNode) Then
            If (knoten.Level + 1 = knoten.FirstNode.Level) _
            Or (knoten Is hauptknoten) Then
                ' mach alles für das Kind
                If knoten.Tag.mark = Not marki Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function
    Shadows Function topnode() As TreeNode
        topnode = MyBase.TopNode
        If MyBase.TopNode IsNot Nothing Then
            If TypeOf (MyBase.TopNode) Is TreeNode Then
                Dim node As TreeNode = MyBase.TopNode
                While TypeOf (node.Parent) Is TreeNode
                    node = node.Parent
                End While
                topnode = node
            Else
                topnode = Nothing
            End If
        Else
            topnode = Nothing
        End If
    End Function

    Public Sub allnodes(ByRef knoten As TreeNode, ByRef mache_zunaechst As mk_anf, ByRef mache_dann As mk_end, ByVal stoppknoten As TreeNode)
        'MsgBox("A: " + knoten.Text)
        If TypeOf (Me.topnode) Is TreeNode Then

            If knoten.Tag.mark = False Then
                Me.marki = True
            Else
                Me.marki = False
            End If
            Dim abbrechen As Boolean = False
            ' Werden markiert, alle erweitert, aufgezählt, Text zugewiesen
            'Me.Enabled = False
            Me.Visible = False
            If Not stoppknoten.FirstNode Is Nothing Then
                While (ob_bruder(knoten) Or ob_kind(knoten) Or ob_vater(knoten)) And Not abbrechen
                    'MsgBox("B: " + knoten.Text)
                    While ob_kind(knoten)
                        If knoten.Tag.mark <> marki Then
                            mache_zunaechst(knoten)
                        End If
                        nodes_end(knoten)
                        knoten = knoten.FirstNode
                        'System.Threading.Thread.Sleep(10 * endure)
                    End While

                    While ob_bruder(knoten) And Not ob_kind(knoten)
                        If knoten.Tag.mark <> marki Then
                            mache_zunaechst(knoten)
                            mache_dann()
                        End If
                        nodes_end(knoten)
                        knoten = knoten.NextNode
                        'System.Threading.Thread.Sleep(10 * endure)
                    End While
                    While ob_vater(knoten) And Not ob_bruder(knoten) And Not ob_kind(knoten) And Not stoppknoten Is knoten  'And Not stoppknoten.Parent Is knoten
                        If knoten.Tag.mark <> marki Then
                            mache_zunaechst(knoten)
                            mache_dann()
                        End If
                        mache_dann()
                        nodes_end(knoten)
                        knoten = knoten.Parent
                        'System.Threading.Thread.Sleep(10 * endure)
                    End While

                    If stoppknoten Is knoten Then abbrechen = True

                End While
            Else
                'If knoten.Tag.mark <> marki Then
                mache_zunaechst(knoten)
                'End If
                mache_dann()
                'nodes_end(knoten)
                'knoten = knoten.Parent
            End If
            nodes_end(knoten)
            Me.Visible = True
            'Me.Enabled = True
        ElseIf knoten.GetNodeCount(False) = 0 Then
            mache_zunaechst(knoten)
            mache_dann()
        End If

    End Sub
    Private Sub nix()
    End Sub
#End Region

    Private Function loesche_haftnotiz_aus_baum(ByRef knoten As TreeNode) As Boolean
        If TypeOf knoten.Tag Is CText Then
            If Not knoten.Tag.desknote Is Nothing Then
                knoten.Tag.desknote.schliesse()
            End If

        End If
        Return True
    End Function
    Private Sub mach_haft_weg()
        Dim knotena As TreeNode = SelectedNode
        allnodes(SelectedNode, AddressOf loesche_haftnotiz_aus_baum, AddressOf nix, SelectedNode)
        SelectedNode = knotena
        Notizen.have_changed_file()
    End Sub
    Public Sub element_dazu()
        Notizen.have_changed_file()
        If TypeOf (topnode()) Is TreeNode Then
            Notizen.Inhalt.node.Nodes.Add("...")
            Notizen.Inhalt.node.Expand()
            SelectedNode = Notizen.Inhalt.node.LastNode
            SelectedNode.Tag = New CText
            SelectedNode.Tag.text = ""
            Notizen.Inhalt.node_set(SelectedNode)
            LabelEdit = True
            'Notizen.Inhalt.node_set(SelectedNode)
            SelectedNode.BeginEdit()
            Notizen.Inhalt.Text = ""
            Notizen.ToolTip1.RemoveAll()
        Else
            Nodes.Add("start")
            topnode.Tag = New CText
            Notizen.Inhalt.node_set(topnode)
            Notizen.Inhalt.node.Tag = New CText
            Notizen.Inhalt.node.Tag.text = ""
            Notizen.Inhalt.Text = ""
            Notizen.txt1.Text = topnode.Text
            txt1_set()
            Notizen.wasimbaum()
            SelectedNode = topnode()
            Notizen.Inhalt.Select()
        End If
        Notizen.have_changed_file()
        Notizen.loeschen.Enabled = True
    End Sub
    Private Sub BaumTyp_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles Me.AfterLabelEdit
        node_infos_all_to_everything()
        Notizen.have_changed_file()
    End Sub
    Private Sub BaumTyp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        LabelEdit = False
        'node_infos_all_to_everything()
    End Sub
    Private Sub BaumTyp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If TypeOf (SelectedNode) Is TreeNode Then
            Notizen.txt2.Text = SelectedNode.Text
        End If
        Notizen.focus_was = Notizen.formenum.baum
    End Sub

    Private Sub txt1_set()
        If Notizen.Inhalt.node Is TopNode And Not TopNode Is Nothing Then
            Notizen.txt1.Text = TopNode.Text
            Notizen.have_changed_file()
        End If
    End Sub
    Private Sub node_infos_all_to_everything()
        If TypeOf (topnode()) Is TreeNode Then
            If Not SelectedNode Is Nothing Then
                Notizen.Inhalt.node_set(SelectedNode)
                If Not SelectedNode.Tag Is Nothing Then
                    If Not SelectedNode.Tag.desknote Is Nothing Then
                        SelectedNode.Tag.desknote.reload_texts()
                    End If
                Else
                    SelectedNode.Tag = New CText
                End If
            End If
            Notizen.txt2.Text = Notizen.Inhalt.node.Text
        End If

    End Sub
    Public Sub element_loeschen()
        If Not SelectedNode Is TopNode Then
            mach_haft_weg()
            Dim index_ As Integer = SelectedNode.Index
            Dim neuknoten As TreeNode
            'If children = 0 Then neuknoten = SelectedNode.Parent Else 
            neuknoten = SelectedNode.PrevVisibleNode
            SelectedNode.Remove()
            Notizen.have_changed_file()

            SelectedNode = neuknoten
            Notizen.Inhalt.node_set(neuknoten)
        Else
            Notizen.schliessen()
        End If
    End Sub

#Region "Events"

    Private Sub BaumTyp_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        node_infos_all_to_everything()
    End Sub

    Private Sub BaumTyp_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim knoten As TreeNode = GetNodeAt(New System.Drawing.Point(e.X, e.Y))
            If Not knoten Is Nothing Then
                node_to_move = knoten
            Else
                node_to_move = Nothing
            End If
        End If
    End Sub

    Private Sub BaumTyp_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles Me.NodeMouseClick
        'MsgBox(e.Node.Tag.shall_expand.ToString)
        SelectedNode = e.Node
        Notizen.Inhalt.node_set(e.Node)
    End Sub

    Private Sub Baum_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Dim knoten As TreeNode = Me.GetNodeAt(New System.Drawing.Point(e.X, e.Y))
            If (Not knoten Is Nothing) And (Not node_to_move Is Nothing) And (Not knoten Is node_to_move) Then

                Dim knoten_uebpr As TreeNode = knoten
                Dim ist_eltern_knoten As Boolean = False

                While TypeOf (knoten_uebpr.Parent) Is TreeNode
                    knoten_uebpr = knoten_uebpr.Parent
                    If knoten_uebpr Is node_to_move Then
                        ist_eltern_knoten = True
                    End If
                End While

                If Not knoten Is Me.TopNode _
                And Not Notizen.onode Is Me.TopNode _
                And ist_eltern_knoten = False Then
                    knoten.Parent.Nodes.Insert(Me.SelectedNode.Index, node_to_move.Clone)
                    node_to_move.Remove()
                    Notizen.have_changed_file()
                End If
            End If
        End If
    End Sub
    Private Sub BaumTyp_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then SelectedNode = GetNodeAt(New System.Drawing.Point(e.X, e.Y))
    End Sub
    Private Sub BaumTyp_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles Me.NodeMouseDoubleClick
        LabelEdit = True
        SelectedNode.BeginEdit()
    End Sub
#End Region

    Private Sub BaumTyp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Notizen.tastendruck(sender, e)
    End Sub
End Class
