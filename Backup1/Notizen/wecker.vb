Public Class wecker


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            GroupBox2.Enabled = True
        Else
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(DateTimePicker1.Value)
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            TextBox2.Text = ""
            TextBox2.Visible = False
            Label7.Visible = False
            Label6.Visible = False
            CheckBox9.Visible = False
            CheckBox10.Visible = False
            CheckBox11.Visible = False
            CheckBox12.Visible = False
            CheckBox13.Visible = False
            CheckBox14.Visible = False
            CheckBox15.Visible = False
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            TextBox2.Visible = True
            'Label7.Text = "wiederhole alle"
            Label6.Text = "Wochen"
            Label7.Visible = True
            Label6.Visible = True
            CheckBox9.Visible = True
            CheckBox10.Visible = True
            CheckBox11.Visible = True
            CheckBox12.Visible = True
            CheckBox13.Visible = True
            CheckBox14.Visible = True
            CheckBox15.Visible = True
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked Then
            TextBox2.Visible = True
            'Label7.Text = "wiederhole alle"
            Label6.Text = "Monate"
            Label7.Visible = True
            Label6.Visible = True
            CheckBox9.Visible = False
            CheckBox10.Visible = False
            CheckBox11.Visible = False
            CheckBox12.Visible = False
            CheckBox13.Visible = False
            CheckBox14.Visible = False
            CheckBox15.Visible = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            TextBox2.Visible = True
            'Label7.Text = "wiederhole alle"
            Label6.Text = "Tage"
            Label7.Visible = True
            Label6.Visible = True
            CheckBox9.Visible = False
            CheckBox10.Visible = False
            CheckBox11.Visible = False
            CheckBox12.Visible = False
            CheckBox13.Visible = False
            CheckBox14.Visible = False
            CheckBox15.Visible = False
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked Then
            TextBox2.Visible = True
            'Label7.Text = "wiederhole alle"
            Label6.Text = "Jahre"
            Label7.Visible = True
            Label6.Visible = True
            CheckBox9.Visible = False
            CheckBox10.Visible = False
            CheckBox11.Visible = False
            CheckBox12.Visible = False
            CheckBox13.Visible = False
            CheckBox14.Visible = False
            CheckBox15.Visible = False
        End If
    End Sub
End Class