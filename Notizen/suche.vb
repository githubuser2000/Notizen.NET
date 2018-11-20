Public Class suche

    Private stellesuche As Int32 = 0
    'Private gefunden As Boolean = False
    Private suchwort_cached As String
    'Private suchart_caches As Boolean = True
    Private Suchliste As New List(Of suchergebnisse)
    Private listenzeiger As Integer
    Private rtbox As New System.Windows.Forms.RichTextBox
    Private was_wholewords_checked As Boolean = False
    Private was_allnodes_checked = False
    Private was_casesensitive_checked = False

    Private Function if_space(ByRef x As Char) As Boolean
        If x = " " Or x = " " Or x = Chr(13) Or x = Chr(10) Then Return True Else Return False
    End Function


    Private Function finde_text(ByVal text As String, ByVal suchtext As String) As Int32
        Dim i As Integer = 0

        If Not wholewords.Checked Then
            Dim k As Integer = 0
            For i = stellesuche To text.Length - 1
                'MsgBox(String.Compare(text(i), suchtext(k), True))
                If String.Compare(text(i), suchtext(k), True) = 0 Then
                    'If text(i) = suchtext(k) Then
                    k += 1
                    If k = suchtext.Length Then
                        If Not casesensitiv.Checked Then
                            Return i - suchtext.Length + 1
                        ElseIf casesensitiv.Checked And text.Substring(i - k + 1, k) = suchtext Then
                            'MsgBox(text.Substring(i - k + 1, k))
                            Return i - suchtext.Length + 1
                        Else
                            k = 0
                        End If
                    End If
                Else
                    k = 0
                End If
            Next
        Else
            Dim merke As String = ""
            'Dim flag As Boolean = False
            For i = stellesuche To text.Length - 1
                If Not if_space(text(i)) Then
                    merke += text(i)
                Else
                    If merke = suchtext Then
                        Return i - suchtext.Length
                    ElseIf String.Compare(merke, suchtext, True) = 0 And casesensitiv.Checked = False Then
                        'MsgBox(String.Compare(merke, suchtext, True))
                        Return i - suchtext.Length
                    End If
                End If

            Next
            If merke = suchtext Then
                Return text.Length - suchtext.Length
            ElseIf String.Compare(merke, suchtext, True) = 0 And casesensitiv.Checked = False Then
                Return text.Length - suchtext.Length
            End If
        End If
        Return -1
    End Function

    Private Sub simuliere_knoten_click(ByRef knoten As TreeNode)
        Notizen.Baum.SelectedNode = knoten
        Notizen.Baum.LabelEdit = False
        Notizen.Inhalt.node_set(knoten)
    End Sub

    Private Function put_stelle(ByRef stelle As Integer, ByRef knoten As TreeNode) As Boolean
        If stelle > -1 Then
            'Notizen.Inhalt.Select(stelle, Me.such.Text.Length)
            'Notizen.Select()
            'stellesuche = Notizen.Inhalt.SelectionStart + 1
            'gefunden = True

            Dim suchergebnis As New suchergebnisse
            suchergebnis.SelectionStart = stelle
            suchergebnis.knoten = knoten
            Me.Suchliste.Add(suchergebnis)

            Return False ' also stoppe
            'ElseIf gefunden = True Then ' wenn nichts mehr ZUSätzliches gefunden wird
            '    'stellesuche = 0
            '    gefunden = False
            '    'beginn_suche()
        End If
        Return True ' wenn nichts (mehr) gefunden wird
    End Function

    Public Function such_pro_knoten(ByRef knoten As TreeNode) As Boolean
        If TypeOf knoten Is TreeNode Then
            If TypeOf knoten.Tag Is CText Then
                Notizen.suchbegriff = Me.such.Text
                'If knoten.Tag.Text.Contains(Me.such.Text) Then
                ' bei finde_text > 0 --> ja suchergebn.
                ' bei put_stelle return true bei nichts mehr finden
                rtbox.Rtf = knoten.Tag.Text()
                stellesuche = 0
                While Not put_stelle(finde_text(rtbox.Text, Me.such.Text), knoten)
                    stellesuche = Suchliste(Suchliste.Count - 1).SelectionStart + Me.such.Text.Length
                    'Windows.Forms.MessageBox.Show(Suchliste(Suchliste.Count - 1).SelectionStart.ToString(), stellesuche.ToString, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
                End While
                'End If
            End If
        End If
        Return True
    End Function

    Private Sub ergebnis_such_je()
        If Me.Suchliste.Count > 0 Then
            If Suchliste.Count <= listenzeiger Then
                listenzeiger = 0
            End If
            Notizen.Select()
            Notizen.Activate()
            Notizen.Focus()
            simuliere_knoten_click(Suchliste(listenzeiger).knoten)
            Notizen.Inhalt.Select()
            Notizen.Inhalt.Focus()
            Notizen.Inhalt.Select(Suchliste(listenzeiger).SelectionStart, Me.such.Text.Length)
            Me.listenzeiger += 1
        End If
    End Sub

    Private Sub begin_search()
        If such.Text <> "" Then
            If such.Text <> suchwort_cached Or Me.was_allnodes_checked <> Me.etwa_alle.Checked Or Me.was_wholewords_checked <> wholewords.Checked Or was_casesensitive_checked <> casesensitiv.Checked Then

                Me.was_allnodes_checked = etwa_alle.Checked
                Me.was_wholewords_checked = wholewords.Checked
                was_casesensitive_checked = casesensitiv.Checked
                Me.Suchliste.Clear()
                Me.suchwort_cached = such.Text
                'gefunden = False
                If Not Me.etwa_alle.Checked Then
                    such_pro_knoten(Notizen.Inhalt.node)
                Else
                    Notizen.suche_alle()
                End If
                'Windows.Forms.MessageBox.Show(Suchliste(0).SelectionStart.ToString(), "test", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
                listenzeiger = 0
                Me.lb_anz_suchergeb.Text = Me.Suchliste.Count.ToString
            End If
            ergebnis_such_je()
            stellesuche = 0
            'gefunden = False
        End If
    End Sub

    Private Sub Suche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Suchen.Click
        begin_search()
    End Sub

    Private Sub Abbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        Me.such.Text = Notizen.suchbegriff
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.Text = Notizen.lang_pointer(Notizen.lang_keys.suche1)
        Me.Suchen.Text = Notizen.lang_pointer(Notizen.lang_keys.suche2)
        Me.fertig.Text = Notizen.lang_pointer(Notizen.lang_keys.suche3)
        Me.etwa_alle.Text = Notizen.lang_pointer(Notizen.lang_keys.suche4)
        Me.lb_Suchergebnisse.Text = Notizen.lang_pointer(Notizen.lang_keys.suche5)
        Me.lb_anz_suchergeb.Text = ""
        Me.wholewords.Text = Notizen.lang_pointer(Notizen.lang_keys.suche6)
        Me.casesensitiv.Text = Notizen.lang_pointer(Notizen.lang_keys.suche7)

    End Sub


    Private Sub fertig_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles fertig.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub such_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles such.KeyUp
        If e.KeyCode = Keys.Enter Then
            begin_search()
        End If
    End Sub
End Class
