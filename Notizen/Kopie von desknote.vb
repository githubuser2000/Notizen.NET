

Public Class desknote
    Implements IComparable(Of desknote)

    Private mouseclickmovetogether_resize As Boolean = False
    Private mouseclickmovetogether_place As Boolean = False
    Private halbkreis(26), i As Byte
    Public window As Rectangle
    Public knoten As TreeNode
    Private zeichen_anz As Integer = 0
    Private scroll_manual As Boolean = True
    Private zeit_absolute As Integer

    Private inmove_x As Integer
    Private inmove_y As Integer
    Private inmove_location_xdiff_was As Integer
    Private inmove_location_ydiff_was As Integer

#Region "events"
    'Private Sub RichTextBox1_VScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.VScroll
    '    My.Application.Log.WriteEntry("RichTextBox1_VScroll 46 " + Me.Label1.Text)
    '    'If Not mouseclickmovetogether_resize And Not mouseclickmovetogether_place Then
    '    '    set_clientsizes()
    '    'End If
    'End Sub


    'Private Sub RichTextBox1_HScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.HScroll
    '    My.Application.Log.WriteEntry("RichTextBox1_HScroll 47 " + Me.Label1.Text)
    '    'If Not mouseclickmovetogether_resize And Not mouseclickmovetogether_place Then
    '    '    set_clientsizes()
    '    'End If
    'End Sub

    Private Sub RichTextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RichTextBox1.KeyDown
        'My.Application.Log.WriteEntry("RichTextBox1_KeyUp 9 " + Me.Label1.Text)
        'pop_up_bigwin()
    End Sub

    Private Sub RichTextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RichTextBox1.MouseDown
        My.Application.Log.WriteEntry("RichTextBox1_MouseDown 10 " + Me.Label1.Text)
        'SyncLock Me
        '    load_vars_for_moving()
        'End SyncLock
    End Sub

    Private Sub RichTextBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.MouseHover
        'My.Application.Log.WriteEntry("RichTextBox1_MouseHover 11 " + Me.Label1.Text)
        'SyncLock Me
        '    mouseover_all()
        'End SyncLock
    End Sub

    Private Sub desknote_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        'My.Application.Log.WriteEntry("desknote_MouseEnter 12 " + Me.Label1.Text)
        'SyncLock Me
        '    mouse_up_all()
        'End SyncLock
    End Sub

    Private Sub desknote_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        'My.Application.Log.WriteEntry("desknote_MouseHover 13 " + Me.Label1.Text)
        'SyncLock Me
        '    mouseover_all()
        'End SyncLock
    End Sub

    Private Sub MouseLeave_(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        'My.Application.Log.WriteEntry("MouseLeave_ 14 " + Me.Label1.Text)
        'mouse_leave()
    End Sub

    Private Sub desknote_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'My.Application.Log.WriteEntry("desknote_MouseMove 15 " + Me.Label1.Text)
        'SyncLock Me
        '    mouse_inelement_move(e)
        '    If e.Location.Y > Me.Height - 40 Then
        '        If e.Location.X > Me.Width - 36 Then
        '            mouse_inelement_size_move2()
        '            My.Application.Log.WriteEntry("desknote_MouseMove 16 " + Me.Label1.Text)
        '        Else
        '            My.Application.Log.WriteEntry("desknote_MouseMove 17 " + Me.Label1.Text)
        '            mouse_inelement_place_move()
        '        End If
        '    ElseIf e.Location.Y < 40 Then
        '        If e.Location.X > Me.Width - 36 Then
        '            My.Application.Log.WriteEntry("desknote_MouseMove 18 " + Me.Label1.Text)
        '            Cursor.Current = Cursors.Arrow
        '        ElseIf e.Location.X < 36 Then
        '            My.Application.Log.WriteEntry("desknote_MouseMove 19 " + Me.Label1.Text)
        '            Cursor.Current = Cursors.PanSouth
        '        Else
        '            My.Application.Log.WriteEntry("desknote_MouseMove 20 " + Me.Label1.Text)
        '            mouse_inelement_place_move()
        '        End If
        '    Else
        '        My.Application.Log.WriteEntry("desknote_MouseMove 21 " + Me.Label1.Text)
        '        mouse_inelement_place_move()
        '    End If
        'End SyncLock
    End Sub

    Private Sub desknote_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        'My.Application.Log.WriteEntry("desknote_MouseUp 22 " + Me.Label1.Text)
        'SyncLock Me
        '    mouse_up_all()
        'End SyncLock
    End Sub


    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        My.Application.Log.WriteEntry("Form1_Paint 23 " + Me.Label1.Text)
        'If Not mouseclickmovetogether_resize And Me.RichTextBox1.Location.X <> 0 And Me.RichTextBox1.Location.Y <> 0 Then


        '    If CInt(Me.Width / 2) - CInt(Me.Label1.Width / 2) < 37 Then
        '        Me.Label1.Location = New Point(37, 10)
        '    Else
        '        Me.Label1.Location = New Point(CInt(Me.Width / 2) - CInt(Me.Label1.Width / 2), 10)
        '    End If

        '    If Me.Label1.Width > Me.Width - 70 Then

        '        Me.Label1.MaximumSize = New Point(Me.Width - 70, Me.Label1.Height)
        '    Else
        '        Me.Label1.MaximumSize = New Point(0, 0)
        '    End If

        '    e.Graphics.DrawImageUnscaledAndClipped(My.Resources.bb, New Rectangle(0, 0, 36, 40))
        '    e.Graphics.DrawImageUnscaledAndClipped(My.Resources.bb, New Rectangle(Me.Width - 36, 0, Me.Width, 40))
        '    For i = 0 To 26
        '        e.Graphics.FillRectangle(Brushes.Violet, 0, i, halbkreis(i) - 1, i + 1)
        '        e.Graphics.FillRectangle(Brushes.Violet, Me.Width - halbkreis(i), i, Me.Width, i + 1)
        '        e.Graphics.FillRectangle(Brushes.Violet, Me.Width - halbkreis(i), Me.Height - i, Me.Width, Me.Height - i + 1)
        '        e.Graphics.FillRectangle(Brushes.Violet, 0, Me.Height - i, halbkreis(i) - 1, Me.Height - i + 1)
        '    Next
        '    e.Graphics.DrawLine(Pens.Black, 36, 26, Me.Width - 36, 26)
        '    e.Graphics.DrawLine(Pens.Black, 36, 0, 36, 40)
        '    e.Graphics.DrawLine(Pens.Black, Me.Width - 36, 0, Me.Width - 36, 40)
        '    e.Graphics.DrawLine(Pens.Black, 0, 40, 36, 40)
        '    e.Graphics.DrawLine(Pens.Black, Me.Width - 36, 40, Me.Width, 40)

        '    e.Graphics.DrawString("x", New Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel, 0), Brushes.Black, Me.Width - 30, 5)
        '    e.Graphics.DrawString("_", New Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel, 0), Brushes.Black, 10, 5)


        'End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        My.Application.Log.WriteEntry("Timer1_Tick 48 " + Me.Label1.Text)
        '    If (Me.Location.X > MousePosition.X Or Me.Location.X + Me.Width < MousePosition.X) Or _
        '         Me.Location.Y > MousePosition.Y Or Me.Location.X + Me.Height < MousePosition.Y Then
        '        If Me.RichTextBox1.Location.X <> 0 And Me.RichTextBox1.Location.Y <> 0 Then
        '            mouse_leave_actions()
        '        End If
        '    End If
    End Sub

    Private Sub RichTextBox1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.SelectionChanged
        'My.Application.Log.WriteEntry("RichTextBox1_SelectionChanged 45 " + Me.Label1.Text)
        ''Me.RichTextBox1.SelectionStart = Me.RichTextBox1.Text.Length
        'Me.RichTextBox1.SelectionLength = 0
    End Sub

    Private Sub RichTextBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RichTextBox1.MouseDoubleClick
        'My.Application.Log.WriteEntry("RichTextBox1_MouseDoubleClick 28 " + Me.Label1.Text)
        'pop_up_bigwin()
    End Sub

    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        'My.Application.Log.WriteEntry("Label1_MouseDown 33 " + Me.Label1.Text)
        'SyncLock Me
        '    load_vars_for_moving()
        'End SyncLock
    End Sub

    Private Sub Label1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseHover
        'SyncLock Me
        '    My.Application.Log.WriteEntry("Label1_MouseHover 34 " + Me.Label1.Text)
        '    mouseover_all()
        'End SyncLock
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        'SyncLock Me
        '    My.Application.Log.WriteEntry("Label1_MouseLeave 35 " + Me.Label1.Text)
        '    mouse_leave()
        'End SyncLock
    End Sub

    Private Sub Label1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        'SyncLock Me
        '    My.Application.Log.WriteEntry("Label1_MouseMove 36 " + Me.Label1.Text)
        '    mouse_inelement_move(e)
        '    My.Application.Log.WriteEntry("Label1_MouseMove 37 " + Me.Label1.Text)
        '    mouse_inelement_place_move()
        'End SyncLock
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        'SyncLock Me
        '    My.Application.Log.WriteEntry("Label1_MouseUp 38 " + Me.Label1.Text)
        '    mouse_up_all()
        'End SyncLock
    End Sub

    Private Sub RichTextBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RichTextBox1.MouseMove
        'SyncLock Me
        '    My.Application.Log.WriteEntry("RichTextBox1_MouseMove 39 " + Me.Label1.Text)
        '    mouse_inelement_move(e)
        '    mouse_inelement_place_move()
        'End SyncLock
    End Sub

    Private Sub RichTextBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RichTextBox1.MouseUp
        'SyncLock Me
        '    My.Application.Log.WriteEntry("RichTextBox1_MouseUp 41 " + Me.Label1.Text)
        '    mouse_up_all()
        'End SyncLock
    End Sub

    Private Sub desknote_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        'My.Application.Log.WriteEntry("desknote_Deactivate 2 " + Me.Label1.Text)
        'If Me.RichTextBox1.Location.X <> 0 And Me.RichTextBox1.Location.Y <> 0 Then
        '    mouse_leave_actions()
        'End If
    End Sub




    Private Sub desknote_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDoubleClick
        'My.Application.Log.WriteEntry("desknote_MouseDoubleClick 3 " + Me.Label1.Text)
        'pop_up_bigwin()
    End Sub

    Private Sub desknote_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        'My.Application.Log.WriteEntry("desknote_MouseDown 4 " + Me.Label1.Text)
        'SyncLock Me
        '    If e.Location.Y < 40 And e.Button = Windows.Forms.MouseButtons.Left Then
        '        If e.Location.X > Me.Width - 36 Then
        '            schliesse()
        '        ElseIf e.Location.X < 36 Then
        '            Me.Visible = False
        '        Else
        '            load_vars_for_moving()
        '        End If
        '    Else
        '        load_vars_for_moving()
        '    End If
        'End SyncLock
    End Sub
#End Region

    Public Overloads Function CompareTo(ByVal other As desknote) As Integer Implements IComparable(Of desknote).CompareTo
        My.Application.Log.WriteEntry("CompareTo 2 " + Me.Label1.Text)
        Return 1
    End Function

    Private Sub load_vars_for_moving()
        'SyncLock Me
        '    My.Application.Log.WriteEntry("load_vars_for_moving() 48 " + Me.Label1.Text)
        '    mouseclickmovetogether_place = True
        '    inmove_y = MousePosition.Y
        '    inmove_x = MousePosition.X
        '    inmove_location_xdiff_was = MousePosition.X - Location.X
        '    inmove_location_ydiff_was = MousePosition.Y - Location.Y
        '    Me.RichTextBox1.Visible = False
        '    Me.zeit_absolute = My.Computer.Clock.TickCount
        'End SyncLock
    End Sub

    Private Sub pop_up_bigwin()
        'My.Application.Log.WriteEntry("pop_up_bigwin() 1 " + Me.Label1.Text)
        'If Notizen.WindowState = FormWindowState.Minimized Or Visible = False Then
        '    Notizen.change_win_state()
        'End If
        'Notizen.Activate()
        'Notizen.Baum.SelectedNode = Me.knoten
        'Notizen.Inhalt.node_set(Me.knoten)
        'Notizen.txt2.Text = Me.knoten.Text
        'Notizen.Inhalt.Rtf = Me.knoten.Tag.text
        'Notizen.Inhalt.Select()
    End Sub

    Private Sub mouseover_all()
        'SyncLock Me
        '    If Me.mouseis_inside(Me) Or Me.mouseis_inside(Me.RichTextBox1) Or Me.mouseis_inside(Label1) Then
        '        My.Application.Log.WriteEntry("mouseover_all() 5 " + Me.Label1.Text)
        '        If Me.RichTextBox1.Location.X <> 12 Or Me.RichTextBox1.Location.Y <> 32 Then
        '            Me.Location = New Point(Me.Location.X - 12, Me.Location.Y - 32)
        '            Me.Size = New Size(Me.Width + 26, Me.Height + 48)
        '            Me.RichTextBox1.Visible = False
        '            Me.RichTextBox1.Location = New Point(12, 32)
        '            Me.RichTextBox1.Size = New Point(Me.Width - 26, Me.Height - 48)
        '            Me.RichTextBox1.BorderStyle = BorderStyle.None
        '            Me.RichTextBox1.Visible = True
        '            Me.Label1.Visible = True
        '        End If
        '    End If
        'End SyncLock
    End Sub

    Private Function mouseis_outside(ByRef thing As Object) As Boolean
        'My.Application.Log.WriteEntry("mouseis_outside 6 " + Me.Label1.Text)
        'Return MousePosition.X + 3 >= thing.location.X + thing.size.Width Or MousePosition.X - 3 <= thing.location.X Or MousePosition.Y + 3 >= thing.location.Y + thing.size.Height Or MousePosition.Y - 3 <= thing.location.Y
    End Function

    Private Function mouseis_inside(ByRef thing As Object) As Boolean
        'My.Application.Log.WriteEntry("mouseis_inside 7 " + Me.Label1.Text)
        'Return MousePosition.X - 3 <= thing.location.X + thing.size.Width Or MousePosition.X + 3 >= thing.location.X Or MousePosition.Y - 3 <= thing.location.Y + thing.size.Height Or MousePosition.Y + 3 >= thing.location.Y
    End Function

    Private Sub mouse_leave_actions()
        'SyncLock Me
        '    My.Application.Log.WriteEntry("mouse_leave_actions() 8 " + Me.Label1.Text)
        '    If Me.RichTextBox1.Location.X <> 0 Or Me.RichTextBox1.Location.Y <> 0 Then
        '        Me.Location = New Point(Me.Location.X + 12, Me.Location.Y + 32)
        '        Me.Size = New Size(Me.Width - 26, Me.Height - 48)
        '        Me.RichTextBox1.BorderStyle = BorderStyle.None
        '        Me.RichTextBox1.Location = New Point(0, 0)
        '        Me.RichTextBox1.Size = Me.Size
        '        Me.Label1.Visible = False
        '    End If
        'End SyncLock
    End Sub

    Private Sub mouse_leave()
        'SyncLock Me
        '    My.Application.Log.WriteEntry("mouse_leave() 9 " + Me.Label1.Text)
        '    If (mouseis_outside(Me) Or Not (Me.mouseis_inside(Label1) And Me.mouseis_inside(Me.RichTextBox1))) Then
        '        mouse_leave_actions()
        '    End If
        'End SyncLock
    End Sub



    

    Public Sub schliesse()
        'My.Application.Log.WriteEntry("schliesse 24 " + Me.Label1.Text)
        'Notizen.have_changed_file()
        'Dim i As Integer = 3
        'Me.knoten.Tag.desknote = Nothing
        'While i < Notizen.TrayIcon.ContextMenuStrip.Items.Count
        '    If Notizen.TrayIcon.ContextMenuStrip.Items.Item(i).Tag Is Me Then
        '        Notizen.TrayIcon.ContextMenuStrip.Items.Item(i).Dispose()
        '        Exit While
        '    End If
        '    i += 1
        'End While
        'If Notizen.TrayIcon.ContextMenuStrip.Items.Count = 3 Then
        '    Notizen.tray_kontext.Items.Item(2).Dispose()
        'End If
        'Notizen.desk_notes.Remove(Me)
        'Dispose()
    End Sub

    Public Sub show2()
        My.Application.Log.WriteEntry("show2 25 " + Me.Label1.Text)
        MyBase.Show()
        'If Not Me.RichTextBox1.Visible Then
        '    Me.Location = New Point(window.Location.X + 12, window.Location.Y + 32)
        '    Me.Size = New Size(window.Width - 26, window.Height - 48)
        '    Me.RichTextBox1.Visible = True
        '    Me.RichTextBox1.Location = New Point(0, 0)
        '    Me.RichTextBox1.Size = Me.Size
        'End If
    End Sub


    Public Sub New(ByRef node As TreeNode, ByVal place_and_size As Rectangle, ByRef ecken() As Byte, ByVal transparenz As Double, ByVal farbe As Color)
        InitializeComponent()
        'Me.Opacity = transparenz
        'Me.RichTextBox1.BackColor = farbe
        'Me.RichTextBox1.Visible = False
        'halbkreis = ecken
        knoten = node
        'If place_and_size.Location.X > My.Computer.Screen.WorkingArea.Size.Width - 80 Then
        '    place_and_size.Location = New Point(My.Computer.Screen.WorkingArea.Size.Width - 80, place_and_size.Location.Y)
        'End If
        'If place_and_size.Location.Y > My.Computer.Screen.WorkingArea.Size.Height - 80 Then
        '    place_and_size.Location = New Point(place_and_size.Location.X, My.Computer.Screen.WorkingArea.Size.Height - 80)
        'End If
        'Me.window = place_and_size
        Me.reload_texts()
        'Me.ContextMenuStrip = New desknote_kontext(Me)
        'Me.RichTextBox1.ContextMenuStrip = New desknote_kontext(Me)
        My.Application.Log.WriteEntry("start " + Me.Label1.Text)
    End Sub

    Sub reload_texts()
        My.Application.Log.WriteEntry("reload_texts 26 " + Me.Label1.Text)
        RichTextBox1.Rtf = knoten.Tag.text
        'Label1.Text = knoten.Text
        'Me.Text = knoten.Text
        'set_clientsizes()
        'scroll_manual = False
    End Sub


    Private Sub resize_()
        'My.Application.Log.WriteEntry("resize_ 27 " + Me.Label1.Text)
        'Threading.Thread.Sleep(50)
        'If Me.RichTextBox1.Location.X = 0 And Me.RichTextBox1.Location.Y = 0 And RichTextBox1.BorderStyle = BorderStyle.None Then
        '    Me.RichTextBox1.Size = New Point(Me.Width, Me.Height)
        'Else
        '    Me.RichTextBox1.Size = New Point(Me.Width - 26, Me.Height - 48)
        'End If

    End Sub

    'Private Sub desknote_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    resize_()
    'End Sub


    'Private Sub Label1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.Click
    '    If Me.Label1.ForeColor = Color.Black Then
    '        Me.Label1.ForeColor = Color.WhiteSmoke
    '    Else
    '        Me.Label1.ForeColor = Color.Black
    '    End If
    'End Sub

    Private Sub mouse_inelement_size_move2()
        'SyncLock Me
        '    My.Application.Log.WriteEntry("mouse_inelement_size_move2 29 " + Me.Label1.Text)
        '    Cursor.Current = Cursors.SizeNWSE
        '    If MouseButtons = Windows.Forms.MouseButtons.Left Then
        '        mouseclickmovetogether_resize = True
        '    End If
        'End SyncLock
    End Sub

    Private Sub mouse_inelement_place_move()
        'Cursor.Current = Cursors.SizeAll
        'If MouseButtons = Windows.Forms.MouseButtons.Left Then
        '    'x = Me.MousePosition.X - Me.Location.X
        '    'y = Me.MousePosition.Y - Me.Location.Y
        '    mouseclickmovetogether_place = True
        'End If
    End Sub

    Private Sub mouse_inelement_move(ByVal e As System.Windows.Forms.MouseEventArgs)
        'SyncLock Me
        '    My.Application.Log.WriteEntry("mouse_inelement_move 30 " + Me.Label1.Text)
        '    If mouseclickmovetogether_resize And My.Computer.Clock.TickCount < Me.zeit_absolute + 4000 Then
        '        My.Application.Log.WriteEntry("mouse_inelement_move 31 " + Me.Label1.Text)
        '        Me.Size = New Point(MousePosition.X - Me.Location.X, MousePosition.Y - Me.Location.Y)
        '    ElseIf mouseclickmovetogether_place Then
        '        My.Application.Log.WriteEntry("mouse_inelement_move 32 " + Me.Label1.Text)
        '        'Me.Location = New Point(MousePosition.X - inmove_location_xdiff_was, MousePosition.Y - inmove_location_ydiff_was)
        '    End If
        'End SyncLock
    End Sub


    Private Sub mouse_up_all()
        'SyncLock Me
        '    My.Application.Log.WriteEntry("mouse_up_all " + Me.Label1.Text)
        '    Notizen.have_changed_file()
        '    mouseclickmovetogether_resize = False
        '    mouseclickmovetogether_place = False
        '    window.Height = MyBase.Height
        '    window.Width = MyBase.Width
        '    window.X = MyBase.Location.X
        '    window.Y = MyBase.Location.Y
        '    ' set_clientsizes()
        '    Me.RichTextBox1.Visible = True
        '    'Me.Refresh()
        '    'resize_()
        'End SyncLock
    End Sub


    Private Sub set_clientsizes_a(ByVal steps As Byte)
        Me.Refresh()
        Dim stopper As Boolean = False
        While ((Me.RichTextBox1.Width < Me.RichTextBox1.ClientSize.Width + 6) And Not stopper) And My.Computer.Clock.TickCount > Me.zeit_absolute + 4000
            Me.Size = New Size(Me.Width - steps, Me.Height - steps)
            If Me.Height < 111 Then stopper = True
            Me.Refresh()
        End While
    End Sub
    Private Sub set_clientsizes_b(ByVal steps As Byte)
        Me.Refresh()
        While (Me.RichTextBox1.Width > Me.RichTextBox1.ClientSize.Width + 6 And Me.Width < My.Computer.Screen.WorkingArea.Width - Me.Location.X - 11 And Me.Height < My.Computer.Screen.WorkingArea.Height - Me.Location.Y - 11) And My.Computer.Clock.TickCount > Me.zeit_absolute + 4000
            Me.Size = New Size(Me.Width + steps, Me.Height + steps)
            Me.Refresh()
        End While
    End Sub
    Private Sub set_clientsizes_c(ByVal steps As Byte)
        Me.Refresh()
        While (Me.RichTextBox1.Height > Me.RichTextBox1.ClientSize.Height + 6 And Me.Width < My.Computer.Screen.WorkingArea.Width - Me.Location.X - 11 And Me.Height < My.Computer.Screen.WorkingArea.Height - Me.Location.Y - 11) And My.Computer.Clock.TickCount > Me.zeit_absolute + 4000
            Me.Size = New Size(Me.Width + steps, Me.Height)
            Me.Refresh()
        End While
    End Sub

    Public Sub set_clientsizes()
        If (Not mouseclickmovetogether_resize And Not scroll_manual) And My.Computer.Clock.TickCount > Me.zeit_absolute + 400 Then
            My.Application.Log.WriteEntry("set_clientsizes() 44 " + Me.Label1.Text)
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
        End If
    End Sub


End Class