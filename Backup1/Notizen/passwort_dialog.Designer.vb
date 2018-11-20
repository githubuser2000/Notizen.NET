<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class passwort_dialog
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(passwort_dialog))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.tb_alt = New System.Windows.Forms.TextBox
        Me.lb_alt = New System.Windows.Forms.Label
        Me.lb_neu1 = New System.Windows.Forms.Label
        Me.tb_neu1 = New System.Windows.Forms.TextBox
        Me.lb_neu2 = New System.Windows.Forms.Label
        Me.tb_neu2 = New System.Windows.Forms.TextBox
        Me.lb_unten = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(118, 125)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Abbrechen"
        '
        'tb_alt
        '
        Me.tb_alt.Location = New System.Drawing.Point(160, 6)
        Me.tb_alt.Name = "tb_alt"
        Me.tb_alt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tb_alt.Size = New System.Drawing.Size(100, 20)
        Me.tb_alt.TabIndex = 1
        '
        'lb_alt
        '
        Me.lb_alt.AutoSize = True
        Me.lb_alt.Location = New System.Drawing.Point(12, 9)
        Me.lb_alt.Name = "lb_alt"
        Me.lb_alt.Size = New System.Drawing.Size(13, 13)
        Me.lb_alt.TabIndex = 2
        Me.lb_alt.Text = "_"
        '
        'lb_neu1
        '
        Me.lb_neu1.AutoSize = True
        Me.lb_neu1.Location = New System.Drawing.Point(13, 35)
        Me.lb_neu1.Name = "lb_neu1"
        Me.lb_neu1.Size = New System.Drawing.Size(13, 13)
        Me.lb_neu1.TabIndex = 4
        Me.lb_neu1.Text = "_"
        '
        'tb_neu1
        '
        Me.tb_neu1.Location = New System.Drawing.Point(161, 32)
        Me.tb_neu1.Name = "tb_neu1"
        Me.tb_neu1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tb_neu1.Size = New System.Drawing.Size(100, 20)
        Me.tb_neu1.TabIndex = 3
        '
        'lb_neu2
        '
        Me.lb_neu2.AutoSize = True
        Me.lb_neu2.Location = New System.Drawing.Point(13, 61)
        Me.lb_neu2.Name = "lb_neu2"
        Me.lb_neu2.Size = New System.Drawing.Size(13, 13)
        Me.lb_neu2.TabIndex = 6
        Me.lb_neu2.Text = "_"
        '
        'tb_neu2
        '
        Me.tb_neu2.Location = New System.Drawing.Point(161, 58)
        Me.tb_neu2.Name = "tb_neu2"
        Me.tb_neu2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tb_neu2.Size = New System.Drawing.Size(100, 20)
        Me.tb_neu2.TabIndex = 5
        '
        'lb_unten
        '
        Me.lb_unten.AutoSize = True
        Me.lb_unten.Location = New System.Drawing.Point(12, 90)
        Me.lb_unten.Name = "lb_unten"
        Me.lb_unten.Size = New System.Drawing.Size(13, 13)
        Me.lb_unten.TabIndex = 7
        Me.lb_unten.Text = "_"
        '
        'passwort_dialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(276, 166)
        Me.Controls.Add(Me.lb_unten)
        Me.Controls.Add(Me.lb_neu2)
        Me.Controls.Add(Me.tb_neu2)
        Me.Controls.Add(Me.lb_neu1)
        Me.Controls.Add(Me.tb_neu1)
        Me.Controls.Add(Me.lb_alt)
        Me.Controls.Add(Me.tb_alt)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "passwort_dialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents tb_alt As System.Windows.Forms.TextBox
    Friend WithEvents lb_alt As System.Windows.Forms.Label
    Friend WithEvents lb_neu1 As System.Windows.Forms.Label
    Friend WithEvents tb_neu1 As System.Windows.Forms.TextBox
    Friend WithEvents lb_neu2 As System.Windows.Forms.Label
    Friend WithEvents tb_neu2 As System.Windows.Forms.TextBox
    Friend WithEvents lb_unten As System.Windows.Forms.Label

End Class
