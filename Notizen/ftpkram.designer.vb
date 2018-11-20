<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ftpkram
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Notizen.ftpToolStripMenuItem.Enabled = True
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ftpkram))
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TB_IP = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_Account = New System.Windows.Forms.TextBox
        Me.TB_Passwort = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_Pfad = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(278, 104)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Laden"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP/Domain/Hostname:"
        '
        'TB_IP
        '
        Me.TB_IP.Location = New System.Drawing.Point(132, 12)
        Me.TB_IP.Name = "TB_IP"
        Me.TB_IP.Size = New System.Drawing.Size(100, 20)
        Me.TB_IP.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Account:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(257, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Passwort:"
        '
        'TB_Account
        '
        Me.TB_Account.Location = New System.Drawing.Point(132, 38)
        Me.TB_Account.Name = "TB_Account"
        Me.TB_Account.Size = New System.Drawing.Size(100, 20)
        Me.TB_Account.TabIndex = 5
        '
        'TB_Passwort
        '
        Me.TB_Passwort.Location = New System.Drawing.Point(334, 38)
        Me.TB_Passwort.Name = "TB_Passwort"
        Me.TB_Passwort.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TB_Passwort.Size = New System.Drawing.Size(100, 20)
        Me.TB_Passwort.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Pfad+Datei:"
        '
        'TB_Pfad
        '
        Me.TB_Pfad.Location = New System.Drawing.Point(132, 67)
        Me.TB_Pfad.Name = "TB_Pfad"
        Me.TB_Pfad.Size = New System.Drawing.Size(302, 20)
        Me.TB_Pfad.TabIndex = 8
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(359, 104)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Speichern"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(197, 104)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Schließen"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ftpkram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 139)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TB_Pfad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TB_Passwort)
        Me.Controls.Add(Me.TB_Account)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_IP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(463, 177)
        Me.Name = "ftpkram"
        Me.Text = "FTP"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_IP As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_Account As System.Windows.Forms.TextBox
    Friend WithEvents TB_Passwort As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_Pfad As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        Notizen.ftpToolStripMenuItem.Enabled = False
        Label3.Text = Notizen.lang_pointer(Notizen.lang_keys.passwort)
        Label4.Text = Notizen.lang_pointer(Notizen.lang_keys.pfaddatei)
        TB_Account.Text = Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").Attributes("name").Value.ToString
        TB_Passwort.Text = Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").Attributes("pass").Value.ToString
        TB_Pfad.Text = Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").Attributes("path").Value.ToString
        TB_IP.Text = Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").Attributes("host").Value.ToString
        Button3.Text = Notizen.lang_pointer(Notizen.lang_keys.Strip1_6)
        Button1.Text = Notizen.lang_pointer(Notizen.lang_keys.Strip1_3)
        Button2.Text = Notizen.lang_pointer(Notizen.lang_keys.Strip1_4)
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub
End Class
