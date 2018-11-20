<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class einstellungen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(einstellungen))
        Me.ok = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.SpracheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeutschToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EnglischToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FrançaisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.РусскийToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EspañolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.CheckBox5 = New System.Windows.Forms.CheckBox
        Me.tb_seconds = New System.Windows.Forms.TextBox
        Me.seconds = New System.Windows.Forms.Label
        Me.中文ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(156, 202)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(58, 23)
        Me.ok.TabIndex = 0
        Me.ok.Text = "ok"
        Me.ok.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(15, 84)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(112, 17)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "In Deskbar zeigen"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SpracheToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(15, 12)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(175, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SpracheToolStripMenuItem
        '
        Me.SpracheToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeutschToolStripMenuItem, Me.EnglischToolStripMenuItem, Me.AutoToolStripMenuItem, Me.FrançaisToolStripMenuItem, Me.РусскийToolStripMenuItem, Me.EspañolToolStripMenuItem, Me.中文ToolStripMenuItem})
        Me.SpracheToolStripMenuItem.Name = "SpracheToolStripMenuItem"
        Me.SpracheToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.SpracheToolStripMenuItem.Text = "&Language"
        '
        'DeutschToolStripMenuItem
        '
        Me.DeutschToolStripMenuItem.Name = "DeutschToolStripMenuItem"
        Me.DeutschToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeutschToolStripMenuItem.Text = "&Deutsch"
        '
        'EnglischToolStripMenuItem
        '
        Me.EnglischToolStripMenuItem.Name = "EnglischToolStripMenuItem"
        Me.EnglischToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EnglischToolStripMenuItem.Text = "&English"
        '
        'AutoToolStripMenuItem
        '
        Me.AutoToolStripMenuItem.Name = "AutoToolStripMenuItem"
        Me.AutoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AutoToolStripMenuItem.Text = "Auto"
        '
        'FrançaisToolStripMenuItem
        '
        Me.FrançaisToolStripMenuItem.Name = "FrançaisToolStripMenuItem"
        Me.FrançaisToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FrançaisToolStripMenuItem.Text = "français"
        '
        'РусскийToolStripMenuItem
        '
        Me.РусскийToolStripMenuItem.Name = "РусскийToolStripMenuItem"
        Me.РусскийToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.РусскийToolStripMenuItem.Text = "Русский"
        '
        'EspañolToolStripMenuItem
        '
        Me.EspañolToolStripMenuItem.Name = "EspañolToolStripMenuItem"
        Me.EspañolToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EspañolToolStripMenuItem.Text = "español"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(15, 61)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(176, 17)
        Me.CheckBox2.TabIndex = 8
        Me.CheckBox2.Text = "Haftnotizfensterrand einblenden"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Sicherheitskopien"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 107)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(38, 20)
        Me.TextBox1.TabIndex = 10
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(15, 133)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(68, 17)
        Me.CheckBox3.TabIndex = 11
        Me.CheckBox3.Text = "Autostart"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(35, 156)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(115, 17)
        Me.CheckBox4.TabIndex = 12
        Me.CheckBox4.Text = "minimierter Autotart"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(15, 179)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(32, 17)
        Me.CheckBox5.TabIndex = 13
        Me.CheckBox5.Text = "_"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'tb_seconds
        '
        Me.tb_seconds.Location = New System.Drawing.Point(15, 202)
        Me.tb_seconds.Name = "tb_seconds"
        Me.tb_seconds.Size = New System.Drawing.Size(38, 20)
        Me.tb_seconds.TabIndex = 14
        '
        'seconds
        '
        Me.seconds.AutoSize = True
        Me.seconds.Location = New System.Drawing.Point(59, 209)
        Me.seconds.Name = "seconds"
        Me.seconds.Size = New System.Drawing.Size(13, 13)
        Me.seconds.TabIndex = 15
        Me.seconds.Text = "_"
        '
        '中文ToolStripMenuItem
        '
        Me.中文ToolStripMenuItem.Name = "中文ToolStripMenuItem"
        Me.中文ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.中文ToolStripMenuItem.Text = "中文"
        '
        'einstellungen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(226, 239)
        Me.Controls.Add(Me.seconds)
        Me.Controls.Add(Me.tb_seconds)
        Me.Controls.Add(Me.CheckBox5)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ok)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "einstellungen"
        Me.ShowInTaskbar = False
        Me.Text = "Einstellungen"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SpracheToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeutschToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnglischToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents AutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FrançaisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents РусскийToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EspañolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents tb_seconds As System.Windows.Forms.TextBox
    Friend WithEvents seconds As System.Windows.Forms.Label
    Friend WithEvents 中文ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
