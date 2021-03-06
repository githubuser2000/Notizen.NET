

Public Class desknote
    Implements IComparable(Of desknote)

    Private mouseclickmovetogether_resize As Boolean = False
    Private mouseclickmovetogether_place As Boolean = False
    'Private halbkreis(26), i As Byte
    Public window As Rectangle
    Public knoten As TreeNode
    Private zeichen_anz As Integer = 0
    Private scroll_manual As Boolean = True
    Private zeit_absolute As Integer

    Private inmove_x As Integer
    Private inmove_y As Integer
    Private inmove_location_xdiff_was As Integer
    Private inmove_location_ydiff_was As Integer
    Public opacity2 As Double

    Public Sub reload_texts()
        RichTextBox1.Rtf = knoten.Tag.text
        Label1.Text = knoten.Text
        Me.Text = knoten.Text
        set_clientsizes()
        scroll_manual = False
    End Sub

    Private Sub pop_up_bigwin()
        If Notizen.WindowState = FormWindowState.Minimized Or Visible = False Then
            Notizen.change_win_state()
        End If
        Notizen.Activate()
        Notizen.Baum.SelectedNode = Me.knoten
        Notizen.Inhalt.node_set(Me.knoten)
        Notizen.txt2.Text = Me.knoten.Text
        Notizen.Inhalt.Rtf = Me.knoten.Tag.text
        Notizen.Inhalt.Select()
    End Sub

    Public Overloads Function CompareTo(ByVal other As desknote) As Integer Implements IComparable(Of desknote).CompareTo
        Return 1
    End Function

    Private Sub desknote_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        opacity_to_1()
    End Sub

    Private Sub desknote_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        opacity_to_opacity2()
        If Me.RichTextBox1.Location.X <> 0 And Me.RichTextBox1.Location.Y <> 0 Then
            mouse_leave_actions()
        End If
    End Sub




    Private Sub desknote_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDoubleClick
        opacity_to_1()
        pop_up_bigwin()
    End Sub

    Private Sub desknote_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        opacity_to_1()
        If e.Location.Y < 40 And e.Button = Windows.Forms.MouseButtons.Left Then
            If e.Location.X > Me.Width - 36 Then
                schliesse()
            ElseIf e.Location.X < 36 Then
                Me.Visible = False
            Else
                load_vars_for_moving()
            End If
        Else
            load_vars_for_moving()
        End If
    End Sub

    Private Sub mouse_over_all()
        If Notizen.showdesknoteborders Then
            'If Me.mouseis_inside(Me) Or Me.mouseis_inside(Me.RichTextBox1) Or Me.mouseis_inside(Label1) Then
            opacity_to_1()
            If Me.RichTextBox1.Location.X <> 12 Or Me.RichTextBox1.Location.Y <> 32 Then
                Me.Location = New Point(Me.Location.X - 12, Me.Location.Y - 32)
                Me.Size = New Size(Me.Width + 26, Me.Height + 48)
                Me.RichTextBox1.Visible = False
                Me.RichTextBox1.Location = New Point(12, 32)
                Me.RichTextBox1.Size = New Point(Me.Width - 26, Me.Height - 48)
                Me.RichTextBox1.BorderStyle = BorderStyle.None
                Me.RichTextBox1.Visible = True
                Me.Label1.Visible = True
            End If
        End If
        'End If
    End Sub

    Private Function mouse_is_outside(ByRef thing As Object) As Boolean
        Dim size As Size = thing.size
        Dim location As Point = thing.location
        Return MousePosition.X + 3 >= location.X + size.Width Or MousePosition.X - 3 <= location.X Or MousePosition.Y + 3 >= location.Y + size.Height Or MousePosition.Y - 3 <= location.Y
    End Function

    Private Function mouse_is_inside(ByRef thing As Object) As Boolean
        Dim size As Size = thing.size
        Dim location As Point = thing.location
        Return MousePosition.X - 3 <= location.X + size.Width Or MousePosition.X + 3 >= location.X Or MousePosition.Y - 3 <= location.Y + size.Height Or MousePosition.Y + 3 >= location.Y
    End Function
    Private Sub mouse_leave_actions()
        SyncLock Me
            Me.Location = New Point(Me.Location.X + 12, Me.Location.Y + 32)
            Me.Size = New Size(Me.Width - 26, Me.Height - 48)
            Me.RichTextBox1.BorderStyle = BorderStyle.None
            Me.RichTextBox1.Location = New Point(0, 0)
            Me.RichTextBox1.Size = Me.Size
            Me.Label1.Visible = False
        End SyncLock
    End Sub

    Private Sub mouse_leave()
        If Notizen.showdesknoteborders Then
            If (mouse_is_outside(Me) Or Not (Me.mouse_is_inside(Label1) And Me.mouse_is_inside(Me.RichTextBox1))) Then
                If Me.RichTextBox1.Location.X <> 0 Or Me.RichTextBox1.Location.Y <> 0 Then
                    mouse_leave_actions()
                End If
            End If
        End If
    End Sub

    Private Sub RichTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.GotFocus
        opacity_to_1()
    End Sub

    Private Sub RichTextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RichTextBox1.KeyDown
        pop_up_bigwin()
    End Sub

    Private Sub RichTextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RichTextBox1.MouseDown
        opacity_to_1()
        load_vars_for_moving()
    End Sub

    Private Sub RichTextBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.MouseHover
        mouse_over_all()
    End Sub

    Private Sub desknote_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        mouse_up_all()
    End Sub

    Private Sub desknote_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        mouse_over_all()
    End Sub

    Private Sub MouseLeave_(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        opacity_to_opacity2()
        mouse_leave()
    End Sub

    Private Sub opacity_to_1()
        'If Opacity <> 1 Then
        '    Opacity = 1
        '    Try
        '        Me.RichTextBox1.ScrollBars = RichTextBoxScrollBars.Both
        '    Catch
        '    End Try
        'End If
    End Sub
    Private Sub opacity_to_opacity2()
        'If Opacity <> opacity2 And Me.RichTextBox1.Visible = True Then
        '    Try
        '        Me.RichTextBox1.ScrollBars = RichTextBoxScrollBars.None
        '    Catch
        '    End Try
        '    Opacity = opacity2
        'End If
    End Sub

    Private Sub desknote_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

        opacity_to_1()
        mouse_inelement_move(e)
        If e.Location.Y > Me.Height - 40 Then
            If e.Location.X > Me.Width - 36 Then
                mouse_inelement_size_move()
            Else
                mouse_inelement_place_move()
            End If
        ElseIf e.Location.Y < 40 Then
            If e.Location.X > Me.Width - 36 Then
                Cursor.Current = Cursors.Arrow
            ElseIf e.Location.X < 36 Then
                Cursor.Current = Cursors.PanSouth
            Else
                mouse_inelement_place_move()
            End If
        Else
            mouse_inelement_place_move()
        End If
    End Sub

    Private Sub desknote_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        mouse_up_all()
    End Sub


    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If Not mouseclickmovetogether_resize And Me.RichTextBox1.Location.X <> 0 And Me.RichTextBox1.Location.Y <> 0 Then


            If CInt(Me.Width / 2) - CInt(Me.Label1.Width / 2) < 37 Then
                Me.Label1.Location = New Point(37, 10)
            Else
                Me.Label1.Location = New Point(CInt(Me.Width / 2) - CInt(Me.Label1.Width / 2), 10)
            End If

            If Me.Label1.Width > Me.Width - 70 Then

                Me.Label1.MaximumSize = New Point(Me.Width - 70, Me.Label1.Height)
            Else
                Me.Label1.MaximumSize = New Point(0, 0)
            End If

            e.Graphics.DrawImageUnscaledAndClipped(My.Resources.aa, New Rectangle(0, 0, 36, 40))
            e.Graphics.DrawImageUnscaledAndClipped(My.Resources.aa, New Rectangle(Me.Width - 36, 0, Me.Width, 40))
            'For i = 0 To 26
            '    e.Graphics.FillRectangle(Brushes.Violet, 0, i, halbkreis(i) - 1, i + 1)
            '    e.Graphics.FillRectangle(Brushes.Violet, Me.Width - halbkreis(i), i, Me.Width, i + 1)
            '    e.Graphics.FillRectangle(Brushes.Violet, Me.Width - halbkreis(i), Me.Height - i, Me.Width, Me.Height - i + 1)
            '    e.Graphics.FillRectangle(Brushes.Violet, 0, Me.Height - i, halbkreis(i) - 1, Me.Height - i + 1)
            'Next
            e.Graphics.DrawLine(Pens.Black, 36, 26, Me.Width - 36, 26)
            e.Graphics.DrawLine(Pens.Black, 36, 0, 36, 40)
            e.Graphics.DrawLine(Pens.Black, Me.Width - 36, 0, Me.Width - 36, 40)
            e.Graphics.DrawLine(Pens.Black, 0, 40, 36, 40)
            e.Graphics.DrawLine(Pens.Black, Me.Width - 36, 40, Me.Width, 40)

            e.Graphics.DrawString("x", New Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel, 0), Brushes.Black, Me.Width - 30, 5)
            e.Graphics.DrawString("_", New Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel, 0), Brushes.Black, 10, 5)


        End If
    End Sub

    Public Sub schliesse()
        Notizen.have_changed_file()
        Dim i As Integer = 3
        Me.knoten.Tag.desknote = Nothing
        While i < Notizen.TrayIcon.ContextMenuStrip.Items.Count
            If Notizen.TrayIcon.ContextMenuStrip.Items.Item(i).Tag Is Me Then
                Notizen.TrayIcon.ContextMenuStrip.Items.Item(i).Dispose()
                Exit While
            End If
            i += 1
        End While
        If Notizen.TrayIcon.ContextMenuStrip.Items.Count = 3 Then
            Notizen.tray_kontext.Items.Item(2).Dispose()
        End If
        Notizen.desk_notes.Remove(Me)
        Dispose()
    End Sub

    Public Shadows Sub show2()
        MyBase.Show()
        If Not Me.RichTextBox1.Visible Then
            Me.Location = New Point(window.Location.X + 12, window.Location.Y + 32)
            Me.Size = New Size(window.Width - 26, window.Height - 48)
            Me.RichTextBox1.Visible = True
            Me.RichTextBox1.Location = New Point(0, 0)
            Me.RichTextBox1.Size = Me.Size
            'Me.opacity_to_opacity2()
        End If
    End Sub


    Public Sub New(ByRef node As TreeNode, ByVal place_and_size As Rectangle, ByVal transparenz As Double, ByVal farbe As Color)
        InitializeComponent()
        'Me.RichTextBox1.ScrollBars = RichTextBoxScrollBars.None
        Me.RichTextBox1.Visible = False
        'halbkreis = ecken
        knoten = node
        If place_and_size.Location.X > My.Computer.Screen.WorkingArea.Size.Width - 80 Then
            place_and_size.Location = New Point(My.Computer.Screen.WorkingArea.Size.Width - 80, place_and_size.Location.Y)
        End If
        If place_and_size.Location.Y > My.Computer.Screen.WorkingArea.Size.Height - 80 Then
            place_and_size.Location = New Point(place_and_size.Location.X, My.Computer.Screen.WorkingArea.Size.Height - 80)
        End If
        Me.window = place_and_size
        reload_texts()
        Me.ContextMenuStrip = New desknote_kontext(Me)
        Me.RichTextBox1.ContextMenuStrip = New desknote_kontext(Me)
        Me.RichTextBox1.BackColor = farbe
        'Me.Opacity = transparenz
        'Me.opacity2 = transparenz
        Me.opacity2 = 1
    End Sub

    Private Sub resize_()
        If Me.RichTextBox1.Location.X = 0 And Me.RichTextBox1.Location.Y = 0 And RichTextBox1.BorderStyle = BorderStyle.None Then
            Me.RichTextBox1.Size = New Point(Me.Width, Me.Height)
        Else
            Me.RichTextBox1.Size = New Point(Me.Width - 26, Me.Height - 48)
        End If

    End Sub

    Private Sub desknote_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        resize_()
    End Sub

    Private Sub RichTextBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RichTextBox1.MouseDoubleClick
        opacity_to_1()
        pop_up_bigwin()
    End Sub

    Private Sub Label1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.Click
        opacity_to_1()
        If Me.Label1.ForeColor = Color.Black Then
            Me.Label1.ForeColor = Color.WhiteSmoke
        Else
            Me.Label1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub mouse_inelement_size_move()
        Cursor.Current = Cursors.SizeNWSE
        If MouseButtons = Windows.Forms.MouseButtons.Left Then
            mouseclickmovetogether_resize = True
        End If
    End Sub

    Private Sub mouse_inelement_place_move()
        Cursor.Current = Cursors.SizeAll
        If MouseButtons = Windows.Forms.MouseButtons.Left Then
            'x = Me.MousePosition.X - Me.Location.X
            'y = Me.MousePosition.Y - Me.Location.Y
            mouseclickmovetogether_place = True
        End If
    End Sub

    Private Sub mouse_inelement_move(ByVal e As System.Windows.Forms.MouseEventArgs)
        SyncLock Me
            opacity_to_1()
            If mouseclickmovetogether_resize Then
                Me.Size = New Point(MousePosition.X - Me.Location.X, MousePosition.Y - Me.Location.Y)
            ElseIf mouseclickmovetogether_place Then
                Me.Location = New Point(MousePosition.X - inmove_location_xdiff_was, MousePosition.Y - inmove_location_ydiff_was)
            End If
        End SyncLock
    End Sub

    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        load_vars_for_moving()
    End Sub


    Private Sub Label1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseHover
        mouse_over_all()
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        mouse_leave()
    End Sub

    Private Sub Label1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        mouse_inelement_move(e)
        mouse_inelement_place_move()
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        mouse_up_all()
    End Sub

    Private Sub RichTextBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RichTextBox1.MouseMove
        opacity_to_1()
        mouse_inelement_move(e)
        mouse_inelement_place_move()
    End Sub

    Private Sub RichTextBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RichTextBox1.MouseUp
        mouse_up_all()

    End Sub

    Private Sub mouse_up_all()
        opacity_to_1()
        mouseclickmovetogether_resize = False
        mouseclickmovetogether_place = False
        Notizen.have_changed_file()
        window.Height = MyBase.Height
        window.Width = MyBase.Width
        window.X = MyBase.Location.X
        window.Y = MyBase.Location.Y
        'set_clientsizes()
        Me.Refresh()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub




#Region "Scroll"



    Private Sub set_clientsizes_a(ByVal steps As Byte)
        Me.Refresh()
        Dim stopper As Boolean = False
        While ((Me.RichTextBox1.Width < Me.RichTextBox1.ClientSize.Width + 6) And Not stopper) And My.Computer.Clock.TickCount < Me.zeit_absolute + 4000
            Me.Size = New Size(Me.Width - steps, Me.Height - steps)
            If Me.Height < 111 Then stopper = True
            Me.Refresh()
        End While
    End Sub
    Private Sub set_clientsizes_b(ByVal steps As Byte)
        Me.Refresh()
        'MsgBox((Me.RichTextBox1.Width > Me.RichTextBox1.ClientSize.Width + 6).ToString + (Me.Width < My.Computer.Screen.WorkingArea.Width - Me.Location.X - 11).ToString + ((Me.Height < My.Computer.Screen.WorkingArea.Height - Me.Location.Y - 11)).ToString + (My.Computer.Clock.TickCount > Me.zeit_absolute + 4000).ToString)
        While (Me.RichTextBox1.Width > Me.RichTextBox1.ClientSize.Width + 6 And Me.Width < My.Computer.Screen.WorkingArea.Width - Me.Location.X - 11 And Me.Height < My.Computer.Screen.WorkingArea.Height - Me.Location.Y - 11) And My.Computer.Clock.TickCount < Me.zeit_absolute + 4000
            Me.Size = New Size(Me.Width + steps, Me.Height + steps)
            Me.Refresh()
        End While
    End Sub
    Private Sub set_clientsizes_c(ByVal steps As Byte)
        Me.Refresh()
        While (Me.RichTextBox1.Height > Me.RichTextBox1.ClientSize.Height + 6 And Me.Width < My.Computer.Screen.WorkingArea.Width - Me.Location.X - 11 And Me.Height < My.Computer.Screen.WorkingArea.Height - Me.Location.Y - 11) And My.Computer.Clock.TickCount < Me.zeit_absolute + 4000
            Me.Size = New Size(Me.Width + steps, Me.Height)
            Me.Refresh()
        End While
    End Sub

    Public Sub set_clientsizes()
        If (Not mouseclickmovetogether_resize And Not scroll_manual) And My.Computer.Clock.TickCount > Me.zeit_absolute + 400 Then
            SyncLock Me
                Me.opacity_to_1()
                'Try
                '    Me.RichTextBox1.ScrollBars = RichTextBoxScrollBars.Both
                'Catch
                'End Try
                Me.Refresh()
                Me.zeit_absolute = My.Computer.Clock.TickCount
                mouseclickmovetogether_resize = False
                mouseclickmovetogether_place = False
                set_clientsizes_a(10) ' verkleinern bis etwas zu klein
                set_clientsizes_b(10) ' normal vergrößern 1
                set_clientsizes_c(10) ' normal vergrößern 2
                scroll_manual = True
                window.Height = MyBase.Height
                window.Width = MyBase.Width
                window.X = MyBase.Location.X
                window.Y = MyBase.Location.Y
                'Me.RichTextBox1.ScrollBars = RichTextBoxScrollBars.None
                Me.opacity_to_opacity2()
            End SyncLock
        End If
    End Sub


    Private Sub RichTextBox1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.SelectionChanged
        'Me.RichTextBox1.SelectionStart = Me.RichTextBox1.Text.Length
        Me.RichTextBox1.SelectionLength = 0
    End Sub

    Private Sub RichTextBox1_VScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.VScroll
        set_clientsizes()
    End Sub

    Private Sub RichTextBox1_HScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.HScroll
        set_clientsizes()
    End Sub

#End Region

    Private Sub load_vars_for_moving()
        opacity_to_1()
        mouseclickmovetogether_place = True
        inmove_y = MousePosition.Y
        inmove_x = MousePosition.X
        inmove_location_xdiff_was = MousePosition.X - Location.X
        inmove_location_ydiff_was = MousePosition.Y - Location.Y
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (Me.Location.X > MousePosition.X Or Me.Location.X + Me.Width < MousePosition.X) Or Me.Location.Y > MousePosition.Y Or Me.Location.X + Me.Height < MousePosition.Y Then
            If Me.RichTextBox1.Location.X <> 0 And Me.RichTextBox1.Location.Y <> 0 Then
                mouse_leave_actions()
            End If
        End If

    End Sub

    Private Sub RichTextBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.MouseLeave
        opacity_to_opacity2()
    End Sub

    Private Sub RichTextBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.MouseEnter
        opacity_to_1()
        mouse_over_all()
        mouseclickmovetogether_resize = False
        mouseclickmovetogether_place = False
    End Sub

    Private Sub RichTextBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RichTextBox1.MouseClick
        opacity_to_1()
    End Sub
End Class