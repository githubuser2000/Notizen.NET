Imports System.Windows.Forms

Public Class wanna_restart

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Public Sub New()

        ' Dieser Aufruf ist f黵 den Windows Form-Designer erforderlich.
        InitializeComponent()
        Me.Text = Notizen.lang_pointer(Notizen.lang_keys.eeoff1)
        Me.Label1.Text = Notizen.lang_pointer(Notizen.lang_keys.eeoff2)
        Me.Label2.Text = Notizen.lang_pointer(Notizen.lang_keys.eeoff3)
        ' F黦en Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub
End Class
