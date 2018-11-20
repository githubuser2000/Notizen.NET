<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox1
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
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.feedback = New System.Windows.Forms.TextBox
        Me.bt_send = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.lb_web = New System.Windows.Forms.LinkLabel
        Me.lb_name = New System.Windows.Forms.Label
        Me.TextBoxDescription = New System.Windows.Forms.TextBox
        Me.LabelProductName = New System.Windows.Forms.Label
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 2
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.080808!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.91919!))
        Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxDescription, 1, 4)
        Me.TableLayoutPanel.Controls.Add(Me.lb_name, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.lb_web, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.bt_close, 1, 5)
        Me.TableLayoutPanel.Controls.Add(Me.TextBox1, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.bt_send, 1, 9)
        Me.TableLayoutPanel.Controls.Add(Me.feedback, 1, 8)
        Me.TableLayoutPanel.Controls.Add(Me.Label1, 1, 7)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(9, 9)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 10
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.91603!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.534351!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.534351!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.714286!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.36461!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.383378!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(585, 586)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 375)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Feedback"
        '
        'feedback
        '
        Me.feedback.Location = New System.Drawing.Point(50, 400)
        Me.feedback.Multiline = True
        Me.feedback.Name = "feedback"
        Me.feedback.Size = New System.Drawing.Size(532, 137)
        Me.feedback.TabIndex = 6
        '
        'bt_send
        '
        Me.bt_send.Location = New System.Drawing.Point(50, 555)
        Me.bt_send.Name = "bt_send"
        Me.bt_send.Size = New System.Drawing.Size(532, 23)
        Me.bt_send.TabIndex = 4
        Me.bt_send.Text = "&Send"
        Me.bt_send.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(50, 61)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(182, 13)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "Email:  notizen@notiza.de"
        '
        'bt_close
        '
        Me.bt_close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_close.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bt_close.Location = New System.Drawing.Point(50, 323)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(532, 27)
        Me.bt_close.TabIndex = 0
        Me.bt_close.Text = "&Close"
        '
        'lb_web
        '
        Me.lb_web.AutoSize = True
        Me.lb_web.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_web.Location = New System.Drawing.Point(50, 39)
        Me.lb_web.Name = "lb_web"
        Me.lb_web.Size = New System.Drawing.Size(532, 19)
        Me.lb_web.TabIndex = 2
        Me.lb_web.TabStop = True
        Me.lb_web.Text = "http://www.notiza.de"
        '
        'lb_name
        '
        Me.lb_name.AutoSize = True
        Me.lb_name.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_name.Location = New System.Drawing.Point(53, 20)
        Me.lb_name.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.lb_name.MaximumSize = New System.Drawing.Size(0, 17)
        Me.lb_name.Name = "lb_name"
        Me.lb_name.Size = New System.Drawing.Size(529, 17)
        Me.lb_name.TabIndex = 1
        Me.lb_name.Text = "Alexander Kern"
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDescription.Location = New System.Drawing.Point(53, 81)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.TextBoxDescription.Multiline = True
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDescription.Size = New System.Drawing.Size(529, 236)
        Me.TextBoxDescription.TabIndex = 0
        Me.TextBoxDescription.TabStop = False
        '
        'LabelProductName
        '
        Me.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProductName.Location = New System.Drawing.Point(53, 0)
        Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(529, 17)
        Me.LabelProductName.TabIndex = 0
        Me.LabelProductName.Text = "Notizen .NET"
        Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AboutBox1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bt_close
        Me.ClientSize = New System.Drawing.Size(603, 604)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutBox1"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AboutBox1"
        Me.TopMost = True
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents lb_name As System.Windows.Forms.Label
    Friend WithEvents lb_web As System.Windows.Forms.LinkLabel
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents bt_send As System.Windows.Forms.Button
    Friend WithEvents feedback As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
