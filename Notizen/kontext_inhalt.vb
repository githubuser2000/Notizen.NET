Public Class kontext_inhalt
    Inherits System.Windows.Forms.ContextMenuStrip

    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Sub New()
        MyBase.New()
        Me.Items.Add("Kopieren")
        Me.Items.Add("Ausschneiden")
        Me.Items.Add("Einfügen")
        Me.Items.Add("Bild einfügen")
        Me.Items.Add("Datum einfügen")
        Me.Items.Add("Löschen")
        Me.Items.Add("Suchen")
    End Sub


    Public Sub oeffne_bild_datei()
        OpenFileDialog1 = New OpenFileDialog
        OpenFileDialog1.Filter = "Bild-Dateien|*.bmp;*.gif;*.jpg;*.jpeg;*.tif;*.tif"
        OpenFileDialog1.DefaultExt = "*.*"
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        OpenFileDialog1.FileName = ""

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim bild As New Bitmap(OpenFileDialog1.FileName)
                Dim a As New System.Security.Permissions.UIPermissionClipboard
                a = Security.Permissions.UIPermissionClipboard.OwnClipboard
                Dim Ablageinhalt As System.Windows.Forms.IDataObject = Clipboard.GetDataObject
                Clipboard.SetImage(bild)
                Notizen.Inhalt.Paste()
                Clipboard.SetDataObject(Ablageinhalt)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        'If Not TypeOf (Baum.TopNode) Is TreeNode Then
        '    'MsgBox(text_lang_1)
        'End If
    End Sub

    Private Sub kontext_inhalt_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Me.ItemClicked
        If Me.Items.Item(0).Selected = True Then
            Me.Hide()
            Notizen.Inhalt.Copy()
        ElseIf Me.Items.Item(1).Selected = True Then
            Me.Hide()
            Notizen.Inhalt.Cut()
            Notizen.Inhalt.rtf_to_node_to_desknote_and_have_changed()
        ElseIf Me.Items.Item(2).Selected = True Then
            Me.Hide()
            Notizen.Inhalt.Paste()
            Notizen.Inhalt.rtf_to_node_to_desknote_and_have_changed()
        ElseIf Me.Items.Item(3).Selected = True Then
            Me.Hide()
            oeffne_bild_datei()
            Notizen.Inhalt.rtf_to_node_to_desknote_and_have_changed()
        ElseIf Me.Items.Item(4).Selected = True Then
            Me.Hide()
            Notizen.Inhalt.Text = Notizen.Inhalt.Text.Insert(Notizen.Inhalt.SelectionStart, " " + Date.Now.Day.ToString + "." + Date.Now.Month.ToString + "." + Date.Now.Year.ToString + " " + Date.Now.Hour.ToString + ":" + Date.Now.Minute.ToString + " ")
            'Notizen.Inhalt.SelectionStart
            Notizen.Inhalt.rtf_to_node_to_desknote_and_have_changed()
        ElseIf Me.Items.Item(5).Selected = True Then
            Me.Hide()
            Notizen.Inhalt.SelectedText = ""
            Notizen.Inhalt.rtf_to_node_to_desknote_and_have_changed()
        ElseIf Me.Items.Item(6).Selected = True Then
            Me.Hide()
            'If Not TypeOf (Notizen.suche) Is suche Then
            Notizen.suche = New suche
            'End If
            Notizen.suche.Show()
            Notizen.suche.Activate()
        End If
    End Sub

   

    Private Sub inhalt_kontext_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick

        'If e.Button = 2097152 Then
        '    Me.Show()
        'End If
    End Sub

    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'kontext_inhalt
        '
        Me.ResumeLayout(False)

    End Sub
End Class
