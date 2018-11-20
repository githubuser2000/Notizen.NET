Public Class desknote_kontext_opacy
    Inherits ContextMenuStrip
    Private haftnotiz As desknote
    Public Sub New(ByRef desknote As desknote)
        Me.haftnotiz = desknote
        Me.Items.Add("90 %")
        Me.Items.Add("80 %")
        Me.Items.Add("70 %")
        Me.Items.Add("60 %")
        Me.Items.Add("50 %")
        Me.Items.Add("40 %")
        Me.Items.Add("30 %")
        Me.Items.Add("20 %")
        Me.Items.Add("10 %")
        Me.Items.Add(" 0 %")
    End Sub


    Private Sub desknote_kontext_opacy_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Me.ItemClicked
        If e.ClickedItem Is Me.Items(0) Then
            Me.haftnotiz.Opacity = 0.1
        ElseIf e.ClickedItem Is Me.Items(1) Then
            Me.haftnotiz.Opacity = 0.2
        ElseIf e.ClickedItem Is Me.Items(2) Then
            Me.haftnotiz.Opacity = 0.3
        ElseIf e.ClickedItem Is Me.Items(3) Then
            Me.haftnotiz.Opacity = 0.4
        ElseIf e.ClickedItem Is Me.Items(4) Then
            Me.haftnotiz.Opacity = 0.5
        ElseIf e.ClickedItem Is Me.Items(5) Then
            Me.haftnotiz.Opacity = 0.6
        ElseIf e.ClickedItem Is Me.Items(6) Then
            Me.haftnotiz.Opacity = 0.7
        ElseIf e.ClickedItem Is Me.Items(7) Then
            Me.haftnotiz.Opacity = 0.8
        ElseIf e.ClickedItem Is Me.Items(8) Then
            Me.haftnotiz.Opacity = 0.9
        ElseIf e.ClickedItem Is Me.Items(9) Then
            Me.haftnotiz.Opacity = 1.0
        End If
        Me.haftnotiz.opacity2 = Me.haftnotiz.Opacity
    End Sub
End Class
