Imports System.Windows.Forms

Public Class wanna_save

    Private Sub Yes(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub No(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nein.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Close()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        Me.Text = Notizen.lang_pointer(Notizen.lang_keys.Strip1_4)
        Me.Label1.Text = Notizen.lang_pointer(Notizen.lang_keys.saveA)
        Me.OK_Button.Text = Notizen.lang_pointer(Notizen.lang_keys.ja)
        Me.nein.Text = Notizen.lang_pointer(Notizen.lang_keys.nein)
        Me.Button1.Text = Notizen.lang_pointer(Notizen.lang_keys.abbrechen)
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub
End Class
