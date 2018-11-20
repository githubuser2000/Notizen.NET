<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class suche
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(suche))
        Me.such = New System.Windows.Forms.TextBox
        Me.Suchen = New System.Windows.Forms.Button
        Me.fertig = New System.Windows.Forms.Button
        Me.etwa_alle = New System.Windows.Forms.CheckBox
        Me.lb_Suchergebnisse = New System.Windows.Forms.Label
        Me.lb_anz_suchergeb = New System.Windows.Forms.Label
        Me.wholewords = New System.Windows.Forms.CheckBox
        Me.casesensitiv = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'such
        '
        Me.such.Location = New System.Drawing.Point(12, 12)
        Me.such.Name = "such"
        Me.such.Size = New System.Drawing.Size(277, 20)
        Me.such.TabIndex = 0
        '
        'Suchen
        '
        Me.Suchen.Location = New System.Drawing.Point(11, 149)
        Me.Suchen.Name = "Suchen"
        Me.Suchen.Size = New System.Drawing.Size(75, 23)
        Me.Suchen.TabIndex = 1
        Me.Suchen.Text = "Suchen"
        Me.Suchen.UseVisualStyleBackColor = True
        '
        'fertig
        '
        Me.fertig.Location = New System.Drawing.Point(92, 149)
        Me.fertig.Name = "fertig"
        Me.fertig.Size = New System.Drawing.Size(75, 23)
        Me.fertig.TabIndex = 2
        Me.fertig.Text = "Fertig"
        Me.fertig.UseVisualStyleBackColor = True
        '
        'etwa_alle
        '
        Me.etwa_alle.AutoSize = True
        Me.etwa_alle.Location = New System.Drawing.Point(12, 38)
        Me.etwa_alle.Name = "etwa_alle"
        Me.etwa_alle.Size = New System.Drawing.Size(151, 17)
        Me.etwa_alle.TabIndex = 4
        Me.etwa_alle.Text = "Alle Knoten durchsuchen?"
        Me.etwa_alle.UseVisualStyleBackColor = True
        '
        'lb_Suchergebnisse
        '
        Me.lb_Suchergebnisse.AutoSize = True
        Me.lb_Suchergebnisse.Location = New System.Drawing.Point(28, 121)
        Me.lb_Suchergebnisse.Name = "lb_Suchergebnisse"
        Me.lb_Suchergebnisse.Size = New System.Drawing.Size(13, 13)
        Me.lb_Suchergebnisse.TabIndex = 5
        Me.lb_Suchergebnisse.Text = "_"
        '
        'lb_anz_suchergeb
        '
        Me.lb_anz_suchergeb.AutoSize = True
        Me.lb_anz_suchergeb.Location = New System.Drawing.Point(187, 121)
        Me.lb_anz_suchergeb.Name = "lb_anz_suchergeb"
        Me.lb_anz_suchergeb.Size = New System.Drawing.Size(13, 13)
        Me.lb_anz_suchergeb.TabIndex = 6
        Me.lb_anz_suchergeb.Text = "_"
        '
        'wholewords
        '
        Me.wholewords.AutoSize = True
        Me.wholewords.Location = New System.Drawing.Point(11, 61)
        Me.wholewords.Name = "wholewords"
        Me.wholewords.Size = New System.Drawing.Size(90, 17)
        Me.wholewords.TabIndex = 7
        Me.wholewords.Text = "ganze Wörter"
        Me.wholewords.UseVisualStyleBackColor = True
        '
        'casesensitiv
        '
        Me.casesensitiv.AutoSize = True
        Me.casesensitiv.Location = New System.Drawing.Point(11, 84)
        Me.casesensitiv.Name = "casesensitiv"
        Me.casesensitiv.Size = New System.Drawing.Size(84, 17)
        Me.casesensitiv.TabIndex = 8
        Me.casesensitiv.Text = "casesensitiv"
        Me.casesensitiv.UseVisualStyleBackColor = True
        '
        'suche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 182)
        Me.Controls.Add(Me.casesensitiv)
        Me.Controls.Add(Me.wholewords)
        Me.Controls.Add(Me.lb_anz_suchergeb)
        Me.Controls.Add(Me.lb_Suchergebnisse)
        Me.Controls.Add(Me.etwa_alle)
        Me.Controls.Add(Me.fertig)
        Me.Controls.Add(Me.Suchen)
        Me.Controls.Add(Me.such)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(309, 220)
        Me.MinimumSize = New System.Drawing.Size(309, 220)
        Me.Name = "suche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Suche"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents such As System.Windows.Forms.TextBox
    Friend WithEvents Suchen As System.Windows.Forms.Button
    Friend WithEvents fertig As System.Windows.Forms.Button
    Friend WithEvents etwa_alle As System.Windows.Forms.CheckBox
    Friend WithEvents lb_Suchergebnisse As System.Windows.Forms.Label
    Friend WithEvents lb_anz_suchergeb As System.Windows.Forms.Label
    Friend WithEvents wholewords As System.Windows.Forms.CheckBox
    Friend WithEvents casesensitiv As System.Windows.Forms.CheckBox
End Class
