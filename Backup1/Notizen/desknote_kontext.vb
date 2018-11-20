Public Class desknote_kontext
    Inherits ContextMenuStrip
    Private haftnotiz As desknote
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Public Sub New(ByRef desknote As desknote)
        Me.haftnotiz = desknote
        Me.Items.Add("")
        Me.Items.Add("")
        Me.Items.Add("")
        'Me.Items.Add("Transparenz")
    End Sub

    Private Sub desknote_kontext_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Me.ItemClicked
        Me.Hide()
        If e.ClickedItem Is Me.Items(0) Then
            Dim b As New ColorDialog
            If b.ShowDialog() = DialogResult.OK Then
                haftnotiz.RichTextBox1.BackColor = b.Color
            End If
            'ElseIf e.ClickedItem Is Me.Items(1) Then
            '    Dim a As New desknote_kontext_opacy(Me.haftnotiz)
            '    a.Show(New Point(MousePosition.X, MousePosition.Y))
            'End If
        ElseIf e.ClickedItem Is Me.Items(1) Then
            'Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("en-US")            
            haftnotiz.Visible = False
        ElseIf e.ClickedItem Is Me.Items(2) Then
            haftnotiz.schliesse()
        End If
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(desknote_kontext))
        Me.SuspendLayout()
        '
        'desknote_kontext
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Nothing
        Me.Font = Nothing
        Me.ResumeLayout(False)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    
    Private Sub desknote_kontext_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Opening
        If Notizen.lang_chosen = Notizen.lang_enum.Deutsch Then
            Me.Items.Item(0).Text = Notizen.languages_.deutsch(Notizen.lang_keys.kontext8)
            Me.Items.Item(1).Text = Notizen.languages_.deutsch(Notizen.lang_keys.kontext9)
            Me.Items.Item(2).Text = Notizen.languages_.deutsch(Notizen.lang_keys.kontext10)
        ElseIf Notizen.lang_chosen = Notizen.lang_enum.English Then
            Me.Items.Item(0).Text = Notizen.languages_.english(Notizen.lang_keys.kontext8)
            Me.Items.Item(1).Text = Notizen.languages_.english(Notizen.lang_keys.kontext9)
            Me.Items.Item(2).Text = Notizen.languages_.english(Notizen.lang_keys.kontext10)
        End If
    End Sub
End Class
