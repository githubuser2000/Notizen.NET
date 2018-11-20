<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Notizen
    Inherits System.Windows.Forms.Form




    'Das Formular ueberschreibt den Loeschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If beenden Then
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        Else
            change_win_state()
        End If
    End Sub

    'Wird vom Windows Form-Designer benoetigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist fuer den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer moeglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht moeglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Notizen))
        Me.ToolStripContainer2 = New System.Windows.Forms.ToolStripContainer
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.txt1 = New System.Windows.Forms.TextBox
        Me.Baum = New BaumTyp
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.txt2 = New System.Windows.Forms.TextBox
        Me.Inhalt = New inhalt
        Me.ToolStrip_fontstyle = New System.Windows.Forms.ToolStrip
        Me.ToolStrip_regular = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip_bold = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip_italic = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip_underline = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip_strikeout = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip_bigger = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip_smaller = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip_fontsizenumber = New fontsize
        Me.ToolStrip_fonts = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStrip_dot = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip_whatscroll = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip_colormenue = New System.Windows.Forms.ToolStripDropDownButton
        Me.bgcolorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.fgcolorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip
        Me.label_unten = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip
        Me.AusschneidenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.KopierenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.EinfuegenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip
        Me.NeuToolStripButton = New System.Windows.Forms.ToolStripDropDownButton
        Me.new_next_toolstripmenuitem = New System.Windows.Forms.ToolStripButton
        Me.new_under_toolstripmenuitem = New System.Windows.Forms.ToolStripButton
        Me.loeschen = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Startmenue = New System.Windows.Forms.ToolStripDropDownButton
        Me.oeffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SpeichernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SchliessenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ftpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.passwortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EinheitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.einheit_start_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.einheit_node_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.export_rtf_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.export_txt_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.export_txt2_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.infoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.b_oeffnen = New System.Windows.Forms.ToolStripButton
        Me.b_sichern = New System.Windows.Forms.ToolStripButton
        Me.b_sichernftp = New System.Windows.Forms.ToolStripButton
        Me.b_schliessen = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.b_drucken = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton
        Me.SchriftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.File1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.File2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.File3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.File4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NeuToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog
        Me.Autosavetimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer2.ContentPanel.SuspendLayout()
        Me.ToolStripContainer2.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.ToolStrip_fontstyle.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer2
        '
        resources.ApplyResources(Me.ToolStripContainer2, "ToolStripContainer2")
        '
        'ToolStripContainer2.ContentPanel
        '
        resources.ApplyResources(Me.ToolStripContainer2.ContentPanel, "ToolStripContainer2.ContentPanel")
        Me.ToolStripContainer2.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.ToolStripContainer2.Name = "ToolStripContainer2"
        '
        'ToolStripContainer2.TopToolStripPanel
        '
        Me.ToolStripContainer2.TopToolStripPanel.Controls.Add(Me.ToolStrip_fontstyle)
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer3
        '
        resources.ApplyResources(Me.SplitContainer3, "SplitContainer3")
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.txt1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Baum)
        '
        'txt1
        '
        Me.txt1.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.txt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt1, "txt1")
        Me.txt1.Name = "txt1"
        Me.txt1.ReadOnly = True
        '
        'Baum
        '
        resources.ApplyResources(Me.Baum, "Baum")
        Me.Baum.HideSelection = False
        Me.Baum.Name = "Baum"
        '
        'SplitContainer2
        '
        resources.ApplyResources(Me.SplitContainer2, "SplitContainer2")
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.txt2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Inhalt)
        '
        'txt2
        '
        Me.txt2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.txt2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt2, "txt2")
        Me.txt2.Name = "txt2"
        '
        'Inhalt
        '
        Me.Inhalt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Inhalt, "Inhalt")
        Me.Inhalt.HideSelection = False
        Me.Inhalt.Name = "Inhalt"
        '
        'ToolStrip_fontstyle
        '
        resources.ApplyResources(Me.ToolStrip_fontstyle, "ToolStrip_fontstyle")
        Me.ToolStrip_fontstyle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrip_regular, Me.ToolStrip_bold, Me.ToolStrip_italic, Me.ToolStrip_underline, Me.ToolStrip_strikeout, Me.ToolStrip_bigger, Me.ToolStrip_smaller, Me.ToolStrip_fontsizenumber, Me.ToolStrip_fonts, Me.ToolStrip_dot, Me.ToolStrip_whatscroll, Me.ToolStrip_colormenue})
        Me.ToolStrip_fontstyle.Name = "ToolStrip_fontstyle"
        '
        'ToolStrip_regular
        '
        Me.ToolStrip_regular.Name = "ToolStrip_regular"
        resources.ApplyResources(Me.ToolStrip_regular, "ToolStrip_regular")
        '
        'ToolStrip_bold
        '
        resources.ApplyResources(Me.ToolStrip_bold, "ToolStrip_bold")
        Me.ToolStrip_bold.Name = "ToolStrip_bold"
        '
        'ToolStrip_italic
        '
        resources.ApplyResources(Me.ToolStrip_italic, "ToolStrip_italic")
        Me.ToolStrip_italic.Name = "ToolStrip_italic"
        '
        'ToolStrip_underline
        '
        resources.ApplyResources(Me.ToolStrip_underline, "ToolStrip_underline")
        Me.ToolStrip_underline.Name = "ToolStrip_underline"
        '
        'ToolStrip_strikeout
        '
        resources.ApplyResources(Me.ToolStrip_strikeout, "ToolStrip_strikeout")
        Me.ToolStrip_strikeout.Name = "ToolStrip_strikeout"
        '
        'ToolStrip_bigger
        '
        Me.ToolStrip_bigger.Name = "ToolStrip_bigger"
        resources.ApplyResources(Me.ToolStrip_bigger, "ToolStrip_bigger")
        '
        'ToolStrip_smaller
        '
        Me.ToolStrip_smaller.Name = "ToolStrip_smaller"
        resources.ApplyResources(Me.ToolStrip_smaller, "ToolStrip_smaller")
        '
        'ToolStrip_fontsizenumber
        '
        Me.ToolStrip_fontsizenumber.Name = "ToolStrip_fontsizenumber"
        resources.ApplyResources(Me.ToolStrip_fontsizenumber, "ToolStrip_fontsizenumber")
        '
        'ToolStrip_fonts
        '
        Me.ToolStrip_fonts.Name = "ToolStrip_fonts"
        resources.ApplyResources(Me.ToolStrip_fonts, "ToolStrip_fonts")
        '
        'ToolStrip_dot
        '
        Me.ToolStrip_dot.Name = "ToolStrip_dot"
        resources.ApplyResources(Me.ToolStrip_dot, "ToolStrip_dot")
        '
        'ToolStrip_whatscroll
        '
        Me.ToolStrip_whatscroll.Name = "ToolStrip_whatscroll"
        resources.ApplyResources(Me.ToolStrip_whatscroll, "ToolStrip_whatscroll")
        '
        'ToolStrip_colormenue
        '
        Me.ToolStrip_colormenue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStrip_colormenue.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bgcolorToolStripMenuItem, Me.fgcolorToolStripMenuItem})
        Me.ToolStrip_colormenue.Name = "ToolStrip_colormenue"
        resources.ApplyResources(Me.ToolStrip_colormenue, "ToolStrip_colormenue")
        '
        'bgcolorToolStripMenuItem
        '
        Me.bgcolorToolStripMenuItem.Name = "bgcolorToolStripMenuItem"
        resources.ApplyResources(Me.bgcolorToolStripMenuItem, "bgcolorToolStripMenuItem")
        '
        'fgcolorToolStripMenuItem
        '
        Me.fgcolorToolStripMenuItem.Name = "fgcolorToolStripMenuItem"
        resources.ApplyResources(Me.fgcolorToolStripMenuItem, "fgcolorToolStripMenuItem")
        '
        'ToolStrip5
        '
        resources.ApplyResources(Me.ToolStrip5, "ToolStrip5")
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.label_unten})
        Me.ToolStrip5.Name = "ToolStrip5"
        '
        'label_unten
        '
        Me.label_unten.Name = "label_unten"
        resources.ApplyResources(Me.label_unten, "label_unten")
        '
        'ToolStrip3
        '
        resources.ApplyResources(Me.ToolStrip3, "ToolStrip3")
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AusschneidenToolStripButton, Me.KopierenToolStripButton, Me.EinfuegenToolStripButton})
        Me.ToolStrip3.Name = "ToolStrip3"
        '
        'AusschneidenToolStripButton
        '
        Me.AusschneidenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.AusschneidenToolStripButton, "AusschneidenToolStripButton")
        Me.AusschneidenToolStripButton.Name = "AusschneidenToolStripButton"
        '
        'KopierenToolStripButton
        '
        Me.KopierenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.KopierenToolStripButton, "KopierenToolStripButton")
        Me.KopierenToolStripButton.Name = "KopierenToolStripButton"
        '
        'EinfuegenToolStripButton
        '
        Me.EinfuegenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EinfuegenToolStripButton.Image = Global.Notizen.My.Resources.Resources.einfueg
        Me.EinfuegenToolStripButton.Name = "EinfuegenToolStripButton"
        resources.ApplyResources(Me.EinfuegenToolStripButton, "EinfuegenToolStripButton")
        '
        'ToolStrip4
        '
        resources.ApplyResources(Me.ToolStrip4, "ToolStrip4")
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripButton, Me.loeschen})
        Me.ToolStrip4.Name = "ToolStrip4"
        '
        'NeuToolStripButton
        '
        Me.NeuToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NeuToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.new_next_toolstripmenuitem, Me.new_under_toolstripmenuitem})
        resources.ApplyResources(Me.NeuToolStripButton, "NeuToolStripButton")
        Me.NeuToolStripButton.Name = "NeuToolStripButton"
        '
        'new_next_toolstripmenuitem
        '
        Me.new_next_toolstripmenuitem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.new_next_toolstripmenuitem.Name = "new_next_toolstripmenuitem"
        resources.ApplyResources(Me.new_next_toolstripmenuitem, "new_next_toolstripmenuitem")
        '
        'new_under_toolstripmenuitem
        '
        Me.new_under_toolstripmenuitem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.new_under_toolstripmenuitem.Name = "new_under_toolstripmenuitem"
        resources.ApplyResources(Me.new_under_toolstripmenuitem, "new_under_toolstripmenuitem")
        '
        'loeschen
        '
        Me.loeschen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.loeschen, "loeschen")
        Me.loeschen.Image = Global.Notizen.My.Resources.Resources.del
        Me.loeschen.Name = "loeschen"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Startmenue, Me.ToolStripSeparator2, Me.b_oeffnen, Me.b_sichern, Me.b_sichernftp, Me.b_schliessen, Me.ToolStripLabel1, Me.b_drucken, Me.ToolStripSplitButton1})
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'Startmenue
        '
        Me.Startmenue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Startmenue.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.oeffnenToolStripMenuItem, Me.SpeichernToolStripMenuItem, Me.SpeichernUnterToolStripMenuItem, Me.SchliessenToolStripMenuItem, Me.ftpToolStripMenuItem, Me.passwortToolStripMenuItem, Me.EinheitToolStripMenuItem, Me.ExportToolStripMenuItem, Me.ToolStripSeparator4, Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.infoToolStripMenuItem, Me.ToolStripSeparator3, Me.BeendenToolStripMenuItem})
        Me.Startmenue.Name = "Startmenue"
        resources.ApplyResources(Me.Startmenue, "Startmenue")
        '
        'oeffnenToolStripMenuItem
        '
        Me.oeffnenToolStripMenuItem.Name = "oeffnenToolStripMenuItem"
        resources.ApplyResources(Me.oeffnenToolStripMenuItem, "oeffnenToolStripMenuItem")
        '
        'SpeichernToolStripMenuItem
        '
        resources.ApplyResources(Me.SpeichernToolStripMenuItem, "SpeichernToolStripMenuItem")
        Me.SpeichernToolStripMenuItem.Name = "SpeichernToolStripMenuItem"
        '
        'SpeichernUnterToolStripMenuItem
        '
        resources.ApplyResources(Me.SpeichernUnterToolStripMenuItem, "SpeichernUnterToolStripMenuItem")
        Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
        '
        'SchliessenToolStripMenuItem
        '
        resources.ApplyResources(Me.SchliessenToolStripMenuItem, "SchliessenToolStripMenuItem")
        Me.SchliessenToolStripMenuItem.Name = "SchliessenToolStripMenuItem"
        '
        'ftpToolStripMenuItem
        '
        Me.ftpToolStripMenuItem.Name = "ftpToolStripMenuItem"
        resources.ApplyResources(Me.ftpToolStripMenuItem, "ftpToolStripMenuItem")
        '
        'passwortToolStripMenuItem
        '
        resources.ApplyResources(Me.passwortToolStripMenuItem, "passwortToolStripMenuItem")
        Me.passwortToolStripMenuItem.Name = "passwortToolStripMenuItem"
        '
        'EinheitToolStripMenuItem
        '
        Me.EinheitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.einheit_start_MenuItem, Me.einheit_node_MenuItem})
        resources.ApplyResources(Me.EinheitToolStripMenuItem, "EinheitToolStripMenuItem")
        Me.EinheitToolStripMenuItem.Name = "EinheitToolStripMenuItem"
        '
        'einheit_start_MenuItem
        '
        resources.ApplyResources(Me.einheit_start_MenuItem, "einheit_start_MenuItem")
        Me.einheit_start_MenuItem.Name = "einheit_start_MenuItem"
        '
        'einheit_node_MenuItem
        '
        resources.ApplyResources(Me.einheit_node_MenuItem, "einheit_node_MenuItem")
        Me.einheit_node_MenuItem.Name = "einheit_node_MenuItem"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.export_rtf_MenuItem, Me.export_txt_MenuItem, Me.export_txt2_MenuItem})
        resources.ApplyResources(Me.ExportToolStripMenuItem, "ExportToolStripMenuItem")
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        '
        'export_rtf_MenuItem
        '
        resources.ApplyResources(Me.export_rtf_MenuItem, "export_rtf_MenuItem")
        Me.export_rtf_MenuItem.Name = "export_rtf_MenuItem"
        '
        'export_txt_MenuItem
        '
        resources.ApplyResources(Me.export_txt_MenuItem, "export_txt_MenuItem")
        Me.export_txt_MenuItem.Name = "export_txt_MenuItem"
        '
        'export_txt2_MenuItem
        '
        Me.export_txt2_MenuItem.Name = "export_txt2_MenuItem"
        resources.ApplyResources(Me.export_txt2_MenuItem, "export_txt2_MenuItem")
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'infoToolStripMenuItem
        '
        Me.infoToolStripMenuItem.Name = "infoToolStripMenuItem"
        resources.ApplyResources(Me.infoToolStripMenuItem, "infoToolStripMenuItem")
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        resources.ApplyResources(Me.BeendenToolStripMenuItem, "BeendenToolStripMenuItem")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'b_oeffnen
        '
        Me.b_oeffnen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.b_oeffnen.Image = Global.Notizen.My.Resources.Resources.o2
        resources.ApplyResources(Me.b_oeffnen, "b_oeffnen")
        Me.b_oeffnen.Name = "b_oeffnen"
        '
        'b_sichern
        '
        Me.b_sichern.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.b_sichern, "b_sichern")
        Me.b_sichern.Image = Global.Notizen.My.Resources.Resources.o3
        Me.b_sichern.Name = "b_sichern"
        '
        'b_sichernftp
        '
        Me.b_sichernftp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.b_sichernftp.Image = Global.Notizen.My.Resources.Resources.o5
        Me.b_sichernftp.Name = "b_sichernftp"
        resources.ApplyResources(Me.b_sichernftp, "b_sichernftp")
        '
        'b_schliessen
        '
        Me.b_schliessen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.b_schliessen, "b_schliessen")
        Me.b_schliessen.Image = Global.Notizen.My.Resources.Resources.o4
        Me.b_schliessen.Name = "b_schliessen"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        resources.ApplyResources(Me.ToolStripLabel1, "ToolStripLabel1")
        '
        'b_drucken
        '
        Me.b_drucken.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.b_drucken, "b_drucken")
        Me.b_drucken.Name = "b_drucken"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SchriftToolStripMenuItem, Me.BearbeitenToolStripMenuItem})
        resources.ApplyResources(Me.ToolStripSplitButton1, "ToolStripSplitButton1")
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        '
        'SchriftToolStripMenuItem
        '
        Me.SchriftToolStripMenuItem.Checked = True
        Me.SchriftToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SchriftToolStripMenuItem.Name = "SchriftToolStripMenuItem"
        resources.ApplyResources(Me.SchriftToolStripMenuItem, "SchriftToolStripMenuItem")
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        resources.ApplyResources(Me.BearbeitenToolStripMenuItem, "BearbeitenToolStripMenuItem")
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        '
        'File1ToolStripMenuItem
        '
        Me.File1ToolStripMenuItem.Name = "File1ToolStripMenuItem"
        resources.ApplyResources(Me.File1ToolStripMenuItem, "File1ToolStripMenuItem")
        '
        'File2ToolStripMenuItem
        '
        Me.File2ToolStripMenuItem.Name = "File2ToolStripMenuItem"
        resources.ApplyResources(Me.File2ToolStripMenuItem, "File2ToolStripMenuItem")
        '
        'File3ToolStripMenuItem
        '
        Me.File3ToolStripMenuItem.Name = "File3ToolStripMenuItem"
        resources.ApplyResources(Me.File3ToolStripMenuItem, "File3ToolStripMenuItem")
        '
        'File4ToolStripMenuItem
        '
        Me.File4ToolStripMenuItem.Name = "File4ToolStripMenuItem"
        resources.ApplyResources(Me.File4ToolStripMenuItem, "File4ToolStripMenuItem")
        '
        'NeuToolStripMenuItem1
        '
        Me.NeuToolStripMenuItem1.Checked = True
        Me.NeuToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.NeuToolStripMenuItem1.Name = "NeuToolStripMenuItem1"
        resources.ApplyResources(Me.NeuToolStripMenuItem1, "NeuToolStripMenuItem1")
        '
        'TrayIcon
        '
        resources.ApplyResources(Me.TrayIcon, "TrayIcon")
        '
        'ToolTip1
        '
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Notizen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.ToolStripContainer2)
        Me.Name = "Notizen"
        Me.ShowInTaskbar = False
        Me.TransparencyKey = System.Drawing.Color.Violet
        Me.ToolStripContainer2.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer2.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer2.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer2.ResumeLayout(False)
        Me.ToolStripContainer2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.ToolStrip_fontstyle.ResumeLayout(False)
        Me.ToolStrip_fontstyle.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Baum As BaumTyp
    Friend WithEvents Inhalt As inhalt
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Public Sub set_language(ByVal language As String)
        Select Case language
            Case "Deutsch"
                Me.set_lang(lang_enum.Deutsch)
            Case "English"
                Me.set_lang(lang_enum.English)
            Case "Chinese"
                Me.set_lang(lang_enum.Chinese)
            Case "français"
                Me.set_lang(lang_enum.French)
            Case "spanish"
                Me.set_lang(lang_enum.Spanish)
            Case "russian"
                Me.set_lang(lang_enum.Russian)
            Case Else
                Select Case System.Globalization.CultureInfo.InstalledUICulture.ToString
                    Case "de-DE"
                        Me.set_lang(lang_enum.Deutsch)
                        'Case "Chinese"
                        '    Me.set_lang(lang_enum.Chinese)
                    Case "fr-FR"
                        Me.set_lang(lang_enum.French)
                    Case "es-ES"
                        Me.set_lang(lang_enum.Spanish)
                    Case "ru-RU"
                        Me.set_lang(lang_enum.Russian)
                    Case "zh-Hans"
                        set_lang(Notizen.lang_enum.Chinese)
                    Case "zh-CN"
                        set_lang(Notizen.lang_enum.Chinese)
                    Case "zh-HK"
                        set_lang(Notizen.lang_enum.Chinese)
                    Case "zh-Hant"
                        set_lang(Notizen.lang_enum.Chinese)
                    Case Else
                        Me.set_lang(lang_enum.English)
                End Select
        End Select
    End Sub

    Public Sub New()
        'My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        'My.Application.Info.DirectoryPath
        'MsgBox(Process.GetCurrentProcess.ProcessName)

        ' Dieser Aufruf ist fuer den Windows Form-Designer erforderlich.
        InitializeComponent()
        Me.Text = "Notizen .NET " + version

        'Windows.Forms.MessageBox.Show(args(0).ToString, args(1).ToString, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
        'Me.CenterToScreen()

        ' Fuegen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Dim langu As languages = New languages
        languages_ = langu.find_lang_words()
        ToolTip1.SetToolTip(Me.Baum, lang_pointer(lang_keys.info1))
        ToolTip1.SetToolTip(Me.Inhalt, lang_pointer(lang_keys.info2))
        VerticalScroll.Enabled = False
        HorizontalScroll.Enabled = False
        diff_baum = Me.Size.Height - Baum.Size.Height
        diff_text_x = Me.Size.Width - Me.Inhalt.Size.Width - Me.Baum.Width
        diff_text_y = Me.Size.Height - Me.Inhalt.Size.Height
        diff_text2_x = Me.Size.Width - txt2.Width - Me.Baum.Width
        tray_kontext.Items.Add(lang_pointer(lang_keys.Strip1_8))
        tray_kontext.Items.Add(lang_pointer(lang_keys.info3))
        Me.TrayIcon.ContextMenuStrip = Me.tray_kontext
        Me.Inhalt.ContextMenuStrip = ikontext
        Me.label_unten.Text = ""

        If xml_kram.show_in_deskbar = "yes" Then
            Me.ShowInTaskbar = True
        Else
            Me.ShowInTaskbar = False
        End If
        set_language(xml_kram.language)
        Dim windowdata As windowdata = xml_kram.on_load()
        If Not windowdata.location.X = 0 And Not windowdata.location.Y = 0 Then
            Me.norm0_or_max1 = windowdata.norm0_or_max1
            Me.Location = windowdata.location
            Me.Size = windowdata.size
            Me.ShowInTaskbar = windowdata.ShowInTaskbar
            Me.WindowState = windowdata.WindowState
        End If

        odatei.Verzeichnis = xml_kram.get_dir

        Me.ToolStripContainer2.TopToolStripPanel.Controls.Add(Me.ToolStrip5)
        Me.ToolStrip1.Location = New Point(0, 0)
        Me.ToolStripContainer2.TopToolStripPanel.Controls.Add(Me.ToolStrip4)
        Me.ToolStrip4.Location = New Point(0, 0)

        Me.ToolStripContainer2.TopToolStripPanel.Controls.Add(Me.ToolStrip3)
        Me.ToolStrip3.Location = New Point(0, 0)
        Me.ToolStripContainer2.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        Me.ToolStrip1.Location = New Point(0, 0)


        Me.Baum.BorderStyle = BorderStyle.Fixed3D
        Me.Inhalt.BorderStyle = BorderStyle.FixedSingle

        'resize2()
        If My.Application.start_arguemnts.helptext Then
            MessageBox.Show("min            - minimum size" + Chr(13) + " file to load - for loading a file" + Chr(13) + " h or ""?""      - for help", "arguments, commandline", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading, False)
        End If
        Try
            'Dim readPerm1 As New System.Security.Permissions.RegistryPermission(System.Security.Permissions.RegistryPermissionAccess.AllAccess, "HKEY_CLASSES_ROOT")
            'readPerm1.AddPathList(System.Security.Permissions.RegistryPermissionAccess.AllAccess, "HKEY_CLASSES_ROOT\.alx")
            'readPerm1.Assert()

            'Dim user As String = Environment.UserDomainName & "\" & Environment.UserName
            'Dim mSec As New Security.AccessControl.RegistrySecurity()
            'Dim rule As New Security.AccessControl.RegistryAccessRule(user, _
            '    Security.AccessControl.RegistryRights.FullControl, _
            '    Security.AccessControl.InheritanceFlags.ContainerInherit, _
            '    Security.AccessControl.PropagationFlags.None, _
            '    Security.AccessControl.AccessControlType.Allow)
            'mSec.AddAccessRule(rule)
            'My.Computer.Registry.ClassesRoot.SetAccessControl(registrySecurity:=mSec)
            'Dim f As New System.Security.Permissions.RegistryPermission(System.Security.Permissions.RegistryPermissionAccess.AllAccess, "HKEY_CLASSES_ROOT\.alx")
            'pRegKey = pRegKey.OpenSubKey(".alx", True)
            'pRegKey.SetAccessControl(mSec)
            'My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\.alx", "", "Notizenfile")

            If Nothing Is My.Computer.Registry.GetValue("HKEY_CLASSES_ROOT\.alx", "", Nothing) Then
                My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\.alx", "", "Notizenfile")
                My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\.alx\OpenWithList", "", "")
                My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\.alx\OpenWithList\Notizen.exe", "", "")
                My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\.alx\OpenWithProgIds", "", "")
                My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\.alx\OpenWithProgIds\notizenfile", "", "")
            End If
            If Nothing Is My.Computer.Registry.GetValue("HKEY_CLASSES_ROOT\notizenfile", "", Nothing) Then
                My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\notizenfile", "", "")
                My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\notizenfile\Shell", "", "Open")
                My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\notizenfile\Shell\Open", "", "")
            End If
            My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\notizenfile\Shell\Open\Command", "", """" + My.Application.Info.DirectoryPath + "\" + My.Application.Info.AssemblyName + ".exe" + """ ""%1""")
            My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\notizenfile\DefaultIcon", "", My.Application.Info.DirectoryPath + "\" + My.Application.Info.AssemblyName + ".exe")

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        With xml_kram.doc.Item("notizen-alx").Item("files")


            If .Attributes("a").Value.IndexOf("\") > 0 Then
                File1ToolStripMenuItem.Text = .Attributes("a").Value.Substring(.Attributes("a").Value.LastIndexOf("\") + 1)
                File1ToolStripMenuItem.Tag = .Attributes("a").Value.Substring(0, (.Attributes("a").Value.LastIndexOf("\")))
                Startmenue.DropDownItems.Add(ToolStripSeparator5)
                Startmenue.DropDownItems.Add(File1ToolStripMenuItem)
            End If
            If .Attributes("b").Value.IndexOf("\") > 0 Then
                File2ToolStripMenuItem.Text = .Attributes("b").Value.Substring(.Attributes("b").Value.LastIndexOf("\") + 1)
                File2ToolStripMenuItem.Tag = .Attributes("b").Value.Substring(0, (.Attributes("b").Value.LastIndexOf("\")))
                Startmenue.DropDownItems.Add(File2ToolStripMenuItem)
            End If
            If .Attributes("c").Value.IndexOf("\") > 0 Then
                File3ToolStripMenuItem.Text = .Attributes("c").Value.Substring(.Attributes("c").Value.LastIndexOf("\") + 1)
                File3ToolStripMenuItem.Tag = .Attributes("c").Value.Substring(0, (.Attributes("c").Value.LastIndexOf("\")))
                Startmenue.DropDownItems.Add(File3ToolStripMenuItem)
            End If
            If .Attributes("d").Value.IndexOf("\") > 0 Then
                File4ToolStripMenuItem.Text = .Attributes("d").Value.Substring(.Attributes("d").Value.LastIndexOf("\") + 1)
                File4ToolStripMenuItem.Tag = .Attributes("d").Value.Substring(0, (.Attributes("d").Value.LastIndexOf("\")))
                Startmenue.DropDownItems.Add(File4ToolStripMenuItem)

            End If
        End With
        Try
            Inhalt.ScrollBars = xml_kram.doc.Item("notizen-alx").Item("scrolls").Attributes("choice").Value
            set_partial_scroll()
        Catch ex As Exception
        End Try
        If IsNumeric(xml_kram.doc.Item("notizen-alx").Item("x").Attributes("a").Value) Then
            Dim intervall As Int16 = xml_kram.doc.Item("notizen-alx").Item("x").Attributes("a").Value
            If intervall > 0 Then
                Autosavetimer.Interval = intervall * 1000
                Autosavetimer.Enabled = True
                Autosavetimer.Start()
            Else
                Autosavetimer.Enabled = False
            End If
        End If
    End Sub

    Sub set_partial_scroll()
        Select Case Inhalt.ScrollBars
            Case 0 : ToolStrip_whatscroll.Text = lang_pointer(lang_keys.scroll) + " "
                Inhalt.WordWrap = True
            Case 1 : ToolStrip_whatscroll.Text = lang_pointer(lang_keys.scroll) + " _"
                Inhalt.WordWrap = False
            Case 2 : ToolStrip_whatscroll.Text = lang_pointer(lang_keys.scroll) + " |"
                Inhalt.WordWrap = True
            Case 3 : ToolStrip_whatscroll.Text = lang_pointer(lang_keys.scroll) + "_|"
                Inhalt.WordWrap = False
        End Select
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Friend WithEvents ToolStrip_fontsizenumber As fontsize
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Startmenue As System.Windows.Forms.ToolStripDropDownButton
    'Friend WithEvents NeuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ftpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fgcolorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bgcolorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip_colormenue As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents einheit_start_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents einheit_node_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents export_rtf_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents export_txt_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents export_txt2_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents oeffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents infoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpeichernToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpeichernUnterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SchliessenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EinheitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip_whatscroll As System.Windows.Forms.ToolStripButton
    Friend WithEvents File1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents File2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents File3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents File4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    'Friend WithEvents b_neu As System.Windows.Forms.ToolStripButton
    Friend WithEvents b_oeffnen As System.Windows.Forms.ToolStripButton
    Friend WithEvents b_sichern As System.Windows.Forms.ToolStripButton
    Public WithEvents b_sichernftp As System.Windows.Forms.ToolStripButton
    Friend WithEvents b_schliessen As System.Windows.Forms.ToolStripButton
    'Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStripContainer2 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SchriftToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents b_drucken As System.Windows.Forms.ToolStripButton
    Friend WithEvents AusschneidenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents KopierenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EinfuegenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents BearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents NeuToolStripButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents new_under_toolstripmenuitem As System.Windows.Forms.ToolStripButton
    Friend WithEvents new_next_toolstripmenuitem As System.Windows.Forms.ToolStripButton
    Friend WithEvents NeuToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents loeschen As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog2 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents label_unten As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip_fontstyle As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrip_bold As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip_italic As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip_underline As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip_bigger As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip_fonts As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStrip_smaller As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip_regular As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip_strikeout As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip_dot As System.Windows.Forms.ToolStripLabel
    Friend WithEvents passwortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Public WithEvents Autosavetimer As System.Windows.Forms.Timer
    'Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    'Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog


End Class
