Public Class fontsize
    Inherits ToolStripTextBox
    Private content As String = ""

    Private Sub fontsize_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(Text) Then
                Notizen.font_set(FontStyle.Regular, Notizen.fontsettings.setsize, "", Text)
            End If
        End If
    End Sub

    Private Sub fontsize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        If IsNumeric(Text) Then
            Dim num As Integer = Text
            If num < 8 Then
                'num = 8
            ElseIf num > 99 Then
                num = 99
            End If
            Text = Math.Round(num)
            content = Text
        ElseIf Text = "" Then
            'Text = "8"
        Else
            Text = content
        End If
    End Sub

    Public Sub New()
        MyBase.New()
        Me.Size = New Size(18, 10)
        Me.TextBoxTextAlign = HorizontalAlignment.Center
        Text = "8"
    End Sub
End Class
