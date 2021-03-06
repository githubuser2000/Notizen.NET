Public Class einstellungen
    Private intaskbar As Boolean
    'Private sprachwahl As String

    Private Sub setup(ByVal sprachwahl As String)

        Notizen.xml_kram.language = sprachwahl
        Notizen.set_language(sprachwahl)
        change_lang()
        If Me.CheckBox1.Checked = True Then
            Notizen.xml_kram.show_in_deskbar = "yes"
        Else
            Notizen.xml_kram.show_in_deskbar = "no"
        End If
        SpracheToolStripMenuItem.Text = sprachwahl
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        If IsNumeric(TextBox1.Text) Then
            Notizen.xml_kram.doc.Item("notizen-alx").Item("saftycopies").SetAttribute("amount", TextBox1.Text)
            Notizen.xml_kram.doc.Save(Notizen.xml_kram.xml_dir + "notizen.config.xml")
        End If
        If CheckBox3.Checked Then
            Notizen.xml_kram.setshortcut(CheckBox4.Checked)
            Notizen.xml_kram.doc.Item("notizen-alx").Item("autorun").SetAttribute("if", "yes")
            If CheckBox4.Checked Then
                Notizen.xml_kram.doc.Item("notizen-alx").Item("autorun").SetAttribute("minimized", "yes")
            Else
                Notizen.xml_kram.doc.Item("notizen-alx").Item("autorun").SetAttribute("minimized", "no")
            End If
        Else
            Notizen.xml_kram.doc.Item("notizen-alx").Item("autorun").SetAttribute("if", "no")
            Dim linkdir As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
            Try
                If My.Computer.FileSystem.FileExists(linkdir + "\Notizen .NET.lnk") Then
                    My.Computer.FileSystem.DeleteFile(linkdir + "\Notizen .NET.lnk")
                End If
            Catch
                MsgBox("Autorun file could not be deleted.")
            End Try
        End If
        If IsNumeric(tb_seconds.Text) And tb_seconds.Text <> "0" Then
            'MsgBox("a")
            If CheckBox5.Checked And IsNumeric(tb_seconds.Text) Then
                'MsgBox("b")
                If tb_seconds.Text < 5 Then
                    tb_seconds.Text = 5
                End If
                Notizen.xml_kram.doc.Item("notizen-alx").Item("x").SetAttribute("a", tb_seconds.Text)
                Notizen.Autosavetimer.Enabled = True
                Notizen.Autosavetimer.Interval = tb_seconds.Text * 1000
                Notizen.Autosavetimer.Stop()
                Notizen.Autosavetimer.Start()
            Else
                'MsgBox("c")
                Notizen.xml_kram.doc.Item("notizen-alx").Item("x").SetAttribute("a", "0")
                Notizen.Autosavetimer.Enabled = False
                Notizen.Autosavetimer.Stop()
            End If
        Else
            'MsgBox("d")
            Notizen.xml_kram.doc.Item("notizen-alx").Item("x").SetAttribute("a", "0")
            Notizen.Autosavetimer.Enabled = False
            Notizen.Autosavetimer.Stop()
        End If
        Notizen.xml_kram.save()
        MyBase.Dispose()
        Me.Dispose()
    End Sub

    Public Sub New()
        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        change_lang()
        If Notizen.ShowInTaskbar Then
            Me.CheckBox1.Checked = True
        Else
            Me.CheckBox1.Checked = False
        End If
        With Notizen.xml_kram.doc.Item("notizen-alx")
            If .Item("desknotes").Attributes("show_desknote_borders").Value = "yes" Then
                Me.CheckBox2.Checked = True
            Else
                Me.CheckBox2.Checked = False
            End If
            intaskbar = Notizen.ShowInTaskbar
            TextBox1.Text = .Item("saftycopies").Attributes("amount").Value
            If .Item("autorun").Attributes("if").Value = "yes" Then
                CheckBox3.Checked = True : Else : CheckBox3.Checked = False
            End If
            If .Item("autorun").Attributes("minimized").Value = "yes" Then
                CheckBox4.Checked = True : Else : CheckBox4.Checked = False
            End If
            If CheckBox3.Checked Then
                CheckBox4.Enabled = True
                'CheckBox5.Enabled = True
            Else
                CheckBox4.Enabled = False
                'CheckBox5.Enabled = False
            End If
            tb_seconds.Text = .Item("x").Attributes("a").Value
        End With
        If tb_seconds.Text = "0" Then
            CheckBox5.Checked = False
        Else
            CheckBox5.Checked = True
        End If
        If CheckBox5.Checked Then
            tb_seconds.Enabled = True
        Else
            tb_seconds.Enabled = False
        End If
    End Sub

    Public Sub change_lang()
        Text = Notizen.lang_pointer(Notizen.lang_keys.e1)
        CheckBox1.Text = Notizen.lang_pointer(Notizen.lang_keys.e2)
        CheckBox2.Text = Notizen.lang_pointer(Notizen.lang_keys.e5)
        ok.Text = Notizen.lang_pointer(Notizen.lang_keys.e4)
        Label1.Text = Notizen.lang_pointer(Notizen.lang_keys.sicherungen)
        CheckBox3.Text = Notizen.lang_pointer(Notizen.lang_keys.autostart)
        CheckBox4.Text = Notizen.lang_pointer(Notizen.lang_keys.minautostart)
        CheckBox5.Text = Notizen.lang_pointer(Notizen.lang_keys.autosave)
        seconds.Text = Notizen.lang_pointer(Notizen.lang_keys.seconds)
    End Sub

    Private Sub SpracheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpracheToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.SpracheToolStripMenuItem.DropDownItems.Count - 1
            Me.SpracheToolStripMenuItem.DropDownItems.Item(i).Enabled = True
        Next
        'Me.SpracheToolStripMenuItem.DropDownItems.Item( = False
    End Sub

    Private Sub DeutschToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeutschToolStripMenuItem.Click
        setup("Deutsch")
    End Sub

    Private Sub EnglischToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglischToolStripMenuItem.Click
        setup("English")
    End Sub

    Private Sub ChineseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        setup("Chinese")
    End Sub
    Private Sub AutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoToolStripMenuItem.Click
        setup("Auto")
    End Sub
    Private Sub françaisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrançaisToolStripMenuItem.Click
        setup("français")
    End Sub
    Private Sub SpanishToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EspañolToolStripMenuItem.Click
        setup("spanish")
    End Sub
    Private Sub RussianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles РусскийToolStripMenuItem.Click
        setup("russian")
    End Sub
    Private Sub 中文ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 中文ToolStripMenuItem.Click
        setup("Chinese")
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            Notizen.xml_kram.show_in_deskbar = "yes"
            Notizen.ShowInTaskbar = True
        Else
            Notizen.xml_kram.show_in_deskbar = "no"
            Notizen.ShowInTaskbar = False
        End If
        'If intaskbar <> Me.CheckBox1.Checked Then
        '    Notizen.WindowState = FormWindowState.Minimized
        'End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked = True Then
            Notizen.xml_kram.show_desknote_borders = "yes"
            Notizen.showdesknoteborders = True
        Else
            Notizen.xml_kram.show_desknote_borders = "no"
            Notizen.showdesknoteborders = False
        End If
    End Sub
    Private Sub einstellungen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MyBase.Dispose()
        Me.Dispose()
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            CheckBox4.Enabled = True
            'CheckBox5.Enabled = True
        Else
            CheckBox4.Enabled = False
            'CheckBox5.Enabled = False
        End If
    End Sub

    
    Private Sub CheckBox5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked Then
            tb_seconds.Enabled = True
            If tb_seconds.Text = "0" Then
                tb_seconds.Text = "60"
            End If
        Else
            tb_seconds.Enabled = False
        End If
    End Sub


End Class