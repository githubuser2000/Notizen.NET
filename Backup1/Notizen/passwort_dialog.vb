Imports System.Windows.Forms

Public Class passwort_dialog
    Public fehler1 As String
    Public fehler2 As String
    Public fehler3 As String
    Public pold As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        pold = tb_alt.Text
        If pold.Length > 24 Then
            pold = pold.Substring(0, 24)
        ElseIf pold.Length < 24 Then
            While Not pold.Length = 24
                pold += " "
            End While
        End If
        Notizen.passwort_bearbeite()
        If tb_neu1.TextLength > 24 Or tb_neu2.TextLength > 24 Then
            MsgBox(fehler1)
        ElseIf pold <> Notizen.p And Not Notizen.p = "                        " Then
            MsgBox(fehler2)
        ElseIf tb_neu1.Text <> tb_neu2.Text Then
            MsgBox(fehler3)
        Else
            Notizen.p = tb_neu1.Text
            Me.Dispose()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Public Sub New()
        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        If Notizen.p = "" Then
            Notizen.p = "                        "
        End If
        If Notizen.p = "                        " Then
            tb_alt.Enabled = False
            tb_neu1.Select()
        Else
            tb_alt.Enabled = True
            tb_alt.Select()
        End If
    End Sub

  
End Class
