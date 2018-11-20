Public Class inhalt
    Inherits RichTextBox

    Private _node As TreeNode
    'Property scrolls() As Integer
    '    Get
    '        Return Me.ScrollBars
    '    End Get
    '    Set(ByVal value As Integer)
    '        Select Case value
    '            Case 0 : Me.ScrollBars = RichTextBoxScrollBars.None
    '            Case 1 : Me.ScrollBars = RichTextBoxScrollBars.Horizontal
    '            Case 2 : Me.ScrollBars = RichTextBoxScrollBars.Vertical
    '            Case 3 : Me.ScrollBars = RichTextBoxScrollBars.Both
    '        End Select
    '    End Set
    'End Property


    ReadOnly Property node() As TreeNode
        Get
            Return _node
        End Get
    End Property

    Public Sub node_set(ByRef value As TreeNode)
        If TypeOf value Is TreeNode Then
            _node = value
            If Not value.Tag Is Nothing Then Rtf = value.Tag.text Else value.Tag = New CText
            Notizen.txt2.Text = value.Text
        End If
    End Sub

    Private Sub rtf_to_node_to_desknote()
        If TypeOf _node Is TreeNode Then
            If TypeOf _node.Tag Is CText Then
                If Not Me.Rtf Is Nothing And Not _node.Tag.text Is Nothing Then
                    'Try
                    _node.Tag.text = Me.Rtf
                    'Catch ex As Exception
                    'MessageBox.Show((Not Nothing Is Notizen.Baum.TopNode).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
                    'End Try
                End If
                ' Try
                If Not node.Tag.desknote Is Nothing Then node.Tag.desknote.reload_texts()
                'Catch ex As Exception
                'End Try
            Else
                _node.Tag = New CText
                _node.Tag.text = ""
                _node.Text = ""
            End If
        End If
    End Sub


    Public Sub rtf_to_node_to_desknote_and_have_changed()
        Notizen.have_changed_file()
        rtf_to_node_to_desknote()
    End Sub

    
    Private Sub inhalt_CursorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CursorChanged


    End Sub


    'Private Sub rtfbox_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ClientSizeChanged
    '    'Windows.Forms.MessageBox.Show("clientsize", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification, False)

    'End Sub
    'Private Sub rtfbox_VScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VScroll
    '    Windows.Forms.MessageBox.Show("vscroll", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification, False)
    'End Sub

    'Private Sub rtfbox_HScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HScroll
    '    'Windows.Forms.MessageBox.Show("hscroll", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification, False)
    'End Sub


    Private Sub rtfbox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        'If TypeOf Notizen.Baum.SelectedNode Is TreeNode Then
        '    _node = Notizen.Baum.SelectedNode
        '    rtf_to_node_to_desknote()
        'End If
        Dim a As New System.Security.Permissions.UIPermissionClipboard
        a = Security.Permissions.UIPermissionClipboard.OwnClipboard
        Notizen.focus_was = Notizen.formenum.inhalt
        If Not Clipboard.GetImage Is Nothing Then
            Clipboard.SetImage(Clipboard.GetImage)
        End If
    End Sub

    Private Sub inhalt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Not SelectionFont Is Nothing And Not Notizen.ToolStrip_fontsizenumber Is Nothing Then
            Notizen.ToolStrip_fontsizenumber.Text = SelectionFont.Size.ToString
        End If
        If e.KeyValue = Keys.S Then

        End If
        If e.Control = True And e.Alt = False Then
            Select Case e.KeyCode
                Case Keys.Space : Notizen.tastendruck(sender, e)
                Case Keys.S : Notizen.tastendruck(sender, e)
                Case Keys.O : Notizen.tastendruck(sender, e)
                Case Keys.N : Notizen.tastendruck(sender, e)
                Case Keys.Q : Notizen.tastendruck(sender, e)
                Case Keys.Add : Notizen.tastendruck(sender, e)
                Case Keys.Subtract : Notizen.tastendruck(sender, e)
                Case Keys.F : Notizen.tastendruck(sender, e)
            End Select
        End If
    End Sub


    'Private Sub rtfbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    Notizen.Notizen_KeyDown(sender, e)
    'End Sub

    Private Sub rtfbox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    End Sub




    Private Sub rtfbox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        If Me.Modified Then
            rtf_to_node_to_desknote_and_have_changed()
        End If
    End Sub

    Public Sub New()
        MyBase.new()
        Me.HideSelection = False
        Me.AutoWordSelection = False
        Me.ImeMode = Windows.Forms.ImeMode.On
    End Sub

    Private Sub inhalt_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Notizen.ToolStrip_fontsizenumber.Text = SelectionFont.Size.ToString
    End Sub

    Private Sub rtfbox_MultilineChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MultilineChanged
        If Me.Modified Then
            rtf_to_node_to_desknote_and_have_changed()
        End If
    End Sub


    Private Sub inhalt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        If Modified Then
            rtf_to_node_to_desknote_and_have_changed()
        End If
    End Sub
End Class
