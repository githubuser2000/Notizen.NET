Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Collections.Generic
Imports System.IO.Compression
Imports System.Xml
Imports System.Xml.XPath
Imports System.Net
Imports System.Windows.Forms

Public Structure langua
    Public deutsch() As String
    Public english() As String
    Public chinese() As String
    Public french() As String
    Public spanish() As String
    Public russian() As String
End Structure

Public Class Notizen

#Region "Attributes"
    Private minimizedstarted As Byte = 0
    Public open_this As Byte
    Public showdesknoteborders = True
    Private beenden As Boolean = False
    Private inmove_x As Integer
    Private inmove_y As Integer
    Private inmove_location_xdiff_was As Integer
    Private inmove_location_ydiff_was As Integer

    Private mouseclickmovetogether_resize As Boolean = False
    Private mouseclickmovetogether_place As Boolean = False
    Private mouseclickmovetogether_block As Boolean = False

    Public WithEvents ikontext As New kontext_inhalt
    Public startknoten As TreeNode
    Private anode As TreeNode
    Public odatei As New Datei
    Dim diff_baum As Short = 0
    Dim diff_text_x As Short = 0
    Dim diff_text_y As Short = 0
    Dim diff_text2_x As Short = 0
    Dim ifboxa As Boolean = False
    Private NotifyIcon1 As Icon
    Public suchbegriff As String
    Public norm0_or_max1 As Boolean
    Public veraendert As Boolean = False
    Public desk_notes As New System.Collections.Generic.SortedDictionary(Of desknote, TreeNode)
    Public desk_notes_list As New List(Of TreeNode)
    Public desk_notes_counter As Integer = 0
    Public WithEvents tray_kontext As New System.Windows.Forms.ContextMenuStrip
    Public xml_kram As New xml_kram
    Public languages_ As langua
    'Public deutsch(strings) As String
    'Public english(strings) As String
    'Public chinese(strings) As String
    Public lang_chosen As lang_enum
    Public onode As TreeNode
    Public version As String = My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString + "." + My.Application.Info.Version.Build.ToString
    'Private WithEvents docToPrint As New Printing.PrintDocument
    Dim hauptknoten As TreeNode
    Dim xml_schreib_stream As Xml.XmlTextWriter
    Dim fonts As New Drawing.Text.InstalledFontCollection
    Private fonts_loaded As Boolean = False
    Private unitylist As List(Of Integer)
    Private unitydeph As Integer
    Private unityrtfbox As Windows.Forms.RichTextBox
    'Private unityrtfbox2 As Windows.Forms.RichTextBox
    Private einstell As einstellungen
    Public focus_was As formenum
    Private fontfam As String
    Private fontstil As New FontStyle
    Private halbkreis(26) As Byte
    Public text_lang_1 As String
    Public text_lang_2 As String
    Private aboutbox As info_help_and_feedback
    Private passwort_dialog As passwort_dialog
    Private passwort_dialog2 As passwort_dialog2
    Public p As String = "                        "
    Dim haft As Boolean = False
    Dim window_haft As New Rectangle
    Private transparency_haftnotizen As Double
    Private farbe_haftnotizen As New Color
    Private isexpanded As Boolean
    Public suche As suche
    Public gch As GCHandle
    Private dateidialoge_strang As Threading.Thread
    Public ftpversuche As Byte
    Private ftpkram As ftpkram
    'Dim pseudolabel As New Label
    Public error_with_file As Boolean = False

    ReadOnly Property lang_pointer(ByVal key As lang_keys) As String
        Get
            Select Case lang_chosen
                Case lang_enum.Chinese
                    lang_pointer = Me.languages_.chinese(key)
                Case lang_enum.Deutsch
                    lang_pointer = Me.languages_.deutsch(key)
                Case lang_enum.French
                    lang_pointer = Me.languages_.french(key)
                Case lang_enum.Spanish
                    lang_pointer = Me.languages_.spanish(key)
                Case lang_enum.Russian
                    lang_pointer = Me.languages_.russian(key)
                Case Else
                    lang_pointer = Me.languages_.english(key)
            End Select
        End Get
    End Property
    Enum formenum As Byte
        inhalt
        baum
    End Enum
    Enum fontsettings As Byte
        size_bigger
        size_smaller
        family
        style
        setsize
    End Enum

#End Region

#Region "Methods"

    Private Sub Notizen_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        mouseclickmovetogether_block = False
        If Me.OpenFileDialog IsNot Nothing Then

        End If
        If Not ftpkram Is Nothing Then
            If ftpkram.Visible Then
                ftpkram.Activate()
                mouseclickmovetogether_block = True
            End If
        End If
        If Not passwort_dialog2 Is Nothing Then
            If passwort_dialog2.Visible Then
                passwort_dialog2.Activate()
                mouseclickmovetogether_block = True
            End If
        End If
        If Not passwort_dialog Is Nothing Then
            If passwort_dialog.Visible Then
                passwort_dialog.Activate()
                mouseclickmovetogether_block = True
            End If
        End If
        If Not aboutbox Is Nothing Then
            If aboutbox.Visible Then
                aboutbox.Activate()
                mouseclickmovetogether_block = True
            End If
        End If
        If Not einstellungen Is Nothing Then
            If einstellungen.Visible Then
                einstellungen.Activate()
                mouseclickmovetogether_block = True
            End If
        End If
        If Not suche Is Nothing Then
            If suche.Visible Then
                suche.Activate()
                mouseclickmovetogether_block = True
            End If
        End If
    End Sub

    Public Sub tastendruck(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control = True And e.Alt = False Then
            Select Case e.KeyCode
                Case Keys.Space : Dim wecker = New wecker : wecker.Show()
                Case Keys.S : If TypeOf (Baum.topnode) Is TreeNode Then save_anyway()
                Case Keys.O : oeffne()
                Case Keys.N : new_topnode()
                Case Keys.Q : Me.schliesse()
                Case Keys.C : If TypeOf (Baum.topnode) Is TreeNode And Not Baum.SelectedNode Is Nothing Then copy_node()
                Case Keys.V : If TypeOf (Baum.topnode) Is TreeNode And Not Baum.SelectedNode Is Nothing Then paste_anything(False)
                Case Keys.X : If TypeOf (Baum.topnode) Is TreeNode And Not Baum.SelectedNode Is Nothing Then cut_anything(False)
                Case Keys.U : If TypeOf (Baum.topnode) Is TreeNode And Not Baum.SelectedNode Is Nothing Then
                        Baum.LabelEdit = True
                        Baum.SelectedNode.BeginEdit()
                    End If
                Case Keys.Add
                    If focus_was = formenum.inhalt Then
                        font_set(FontStyle.Regular, fontsettings.size_bigger, "")
                    End If
                Case Keys.Subtract
                    If focus_was = formenum.inhalt Then
                        font_set(FontStyle.Regular, fontsettings.size_smaller, "")
                    End If
                Case Keys.F
                    If TypeOf (Baum.topnode) Is TreeNode And Not Baum.SelectedNode Is Nothing Then
                        'If Not TypeOf (suche) Is suche Then
                        suche = New suche
                        'End If
                        suche.Show()
                        suche.Activate()
                    End If
            End Select
        ElseIf e.Shift = True And e.Alt = False Then
            Select Case e.KeyCode
                Case Keys.Insert : If TypeOf (Baum.topnode) Is TreeNode And Not Baum.SelectedNode Is Nothing Then paste_anything(False)
                Case Keys.Delete : If TypeOf (Baum.topnode) Is TreeNode And Not Baum.SelectedNode Is Nothing Then cut_anything(False)
            End Select
        ElseIf e.Alt = False Then
            Select Case e.KeyCode
                Case Keys.Delete
                    If Baum.Focused And TypeOf (Baum.topnode) Is TreeNode And Not Baum.SelectedNode Is Nothing Then
                        Baum.element_loeschen()
                    End If
                Case Keys.Insert
                    If Baum.Focused And TypeOf (Baum.topnode) Is TreeNode And Not Baum.SelectedNode Is Nothing Then
                        Baum.element_dazu()
                    End If
                Case Keys.Return
                    If Baum.Focused And TypeOf (Baum.topnode) Is TreeNode And Not Baum.SelectedNode Is Nothing Then
                        neu_neben_knoten()
                    End If
            End Select
        End If
    End Sub


    Public Sub Notizen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        tastendruck(sender, e)
    End Sub


#Region "Language"

    Enum lang_enum As Byte
        Deutsch
        English
        Chinese
        French
        Spanish
        Russian
    End Enum
    Enum lang_keys As Byte
        Strip1_1
        Strip1_2
        Strip1_3
        Strip1_4
        Strip1_5
        Strip1_6
        Strip1_7
        Strip1_8
        Strip1_9
        Strip1_10
        Strip1_11
        Strip1_12
        Strip1_13
        Strip1_14
        Strip1_15
        Strip1_16
        Strip1_17
        Strip1_18
        Strip1_19
        Strip2_1
        Strip3_1
        Strip3_2
        Strip4_1
        Strip4_2
        Strip4_3
        e1
        e2
        e3
        e4
        kontext1
        kontext2
        kontext3
        kontext4
        kontext5
        kontext2_1
        kontext2_2
        kontext2_3
        kontext2_4
        kontext2_5
        etwa_loeschen
        ja
        nein
        info1
        info2
        info3
        suche1
        suche2
        suche3
        suche4
        suche5
        neu1
        neu2
        eeoff1
        eeoff2
        eeoff3
        saveA
        OK
        abbrechen
        kontext2_6
        kontext2_7
        kontext2_8
        font_regular
        font_bold
        font_italic
        font_underline
        font_strikeout
        font_bigger
        font_smaller
        unity_note
        Strip1_20
        Strip1_1_1
        Strip1_1_2
        fehler1
        fehler2
        strip1_21
        pass1
        pass2
        pass3
        passerror1
        passerror2
        password
        passwort_falsch
        passerror3
        pw_unten_info
        kontext6
        kontext7
        kontext8
        kontext9
        kontext10
        e5
        kontext2_9
        kontext2_10
        sicherungen
        autostart
        color
        passwort
        pfaddatei
        alxerror
        export
        exportrtf
        exporttxt
        exporttxt2
        nexxt
        under
        kontext11
        suche6
        suche7
        aboutinfotext
        feedback
        close
        send
        no_send
        char10minimum
        no_feedback_sent
        minautostart
        autosave
        seconds
        scroll
    End Enum

    '    Sub find_lang_words()

    '        Dim oeh As Integer = 0

    '        deutsch(oeh) = "&Menü"
    '        english(oeh) = "&Menu"
    '        chinese(oeh) = "文件"
    '        oeh += 1
    '        deutsch(oeh) = "&Neue Datei STRG+N"
    '        english(oeh) = "&New File   CTRL+N"
    '        chinese(oeh) = "新          CTRL+N"
    '        oeh += 1
    '        deutsch(oeh) = "&Öffnen        STRG+O"
    '        english(oeh) = "&Open        CTRL+O"
    '        chinese(oeh) = "打开        CTRL+O"
    '        oeh += 1
    '        deutsch(oeh) = "Speichern   STRG+S"
    '        english(oeh) = "Save         CTRL+S"
    '        chinese(oeh) = "保存        CTRL+S"
    '        oeh += 1
    '        deutsch(oeh) = "Speichern &unter"
    '        english(oeh) = "save &as"
    '        chinese(oeh) = "另存为"
    '        oeh += 1
    '        deutsch(oeh) = "Schliessen"
    '        english(oeh) = "&Close"
    '        chinese(oeh) = "关闭"
    '        oeh += 1
    '        deutsch(oeh) = "&Einstellungen"
    '        english(oeh) = "&Settings"
    '        chinese(oeh) = "安装"
    '        oeh += 1
    '        deutsch(oeh) = "&Beenden    STRG+Q"
    '        english(oeh) = "&Exit       CTRL+Q"
    '        chinese(oeh) = "结束        CTRL+Q"
    '        oeh += 1
    '        deutsch(oeh) = "&Hilfe"
    '        english(oeh) = "&Help"
    '        chinese(oeh) = "帮助"
    '        oeh += 1
    '        deutsch(oeh) = "fuer den Programmierer hoffentlich"
    '        english(oeh) = "for the programmer, I hope so"
    '        chinese(oeh) = "希望如此"
    '        oeh += 1
    '        deutsch(oeh) = "Neue Datei"
    '        english(oeh) = "new file"
    '        chinese(oeh) = "开始"
    '        oeh += 1
    '        deutsch(oeh) = "Oeffnen"
    '        english(oeh) = "open"
    '        chinese(oeh) = "打开"
    '        oeh += 1
    '        deutsch(oeh) = "Speichern "
    '        english(oeh) = "save"
    '        chinese(oeh) = "保存"
    '        oeh += 1
    '        deutsch(oeh) = "Schliessen"
    '        english(oeh) = "close"
    '        chinese(oeh) = "关闭"
    '        oeh += 1
    '        deutsch(oeh) = "Drucken"
    '        english(oeh) = "print"
    '        chinese(oeh) = "打印"
    '        oeh += 1
    '        deutsch(oeh) = "Schrift"
    '        english(oeh) = "font"
    '        chinese(oeh) = "字体"
    '        oeh += 1
    '        deutsch(oeh) = "Bearbeiten"
    '        english(oeh) = "change"
    '        chinese(oeh) = "修改"
    '        oeh += 1
    '        deutsch(oeh) = "Neu/Entf."
    '        english(oeh) = "newr/remove"
    '        chinese(oeh) = "新的/移动"
    '        oeh += 1
    '        deutsch(oeh) = "Werkzeug-Streifen"
    '        english(oeh) = "toolstrips"
    '        chinese(oeh) = "工具条"
    '        oeh += 1
    '        deutsch(oeh) = "Schrift"
    '        english(oeh) = "font"
    '        chinese(oeh) = "字体"
    '        oeh += 1
    '        deutsch(oeh) = "Neues Element"
    '        english(oeh) = "new element"
    '        chinese(oeh) = "新要素"
    '        oeh += 1
    '        deutsch(oeh) = "Element löschen"
    '        english(oeh) = "remove element"
    '        chinese(oeh) = "移动新要素"
    '        oeh += 1
    '        deutsch(oeh) = "Aussschneiden STRG+X"
    '        english(oeh) = "cut CTRL+X"
    '        chinese(oeh) = "剪切 CTRL++X"
    '        oeh += 1
    '        deutsch(oeh) = "Kopieren STRG+C"
    '        english(oeh) = "copy CTRL+C"
    '        chinese(oeh) = "复制 CTRL+C"
    '        oeh += 1
    '        deutsch(oeh) = "Einfügen STRG+V"
    '        english(oeh) = "paste CTRL+V"
    '        chinese(oeh) = "粘贴 CTRL+V"
    '        oeh += 1
    '        deutsch(oeh) = "Einstellungen"
    '        english(oeh) = "settings"
    '        chinese(oeh) = "安装"
    '        oeh += 1
    '        deutsch(oeh) = "In Deskbar zeigen"
    '        english(oeh) = "show in Deskbar"
    '        chinese(oeh) = "桌面"
    '        oeh += 1
    '        deutsch(oeh) = "Sprache"
    '        english(oeh) = "language"
    '        chinese(oeh) = "语言"
    '        oeh += 1
    '        deutsch(oeh) = "ok"
    '        english(oeh) = "ok"
    '        chinese(oeh) = "ok"
    '        oeh += 1
    '        deutsch(oeh) = "Kopieren"
    '        english(oeh) = "copy"
    '        chinese(oeh) = "复制"
    '        oeh += 1
    '        deutsch(oeh) = "Ausschneiden"
    '        english(oeh) = "cut"
    '        chinese(oeh) = "剪切"
    '        oeh += 1
    '        deutsch(oeh) = "Einfuegen"
    '        english(oeh) = "paste"
    '        chinese(oeh) = "粘贴"
    '        oeh += 1
    '        deutsch(oeh) = "Löschen"
    '        english(oeh) = "delete"
    '        chinese(oeh) = "删除"
    '        oeh += 1
    '        deutsch(oeh) = "Suchen"
    '        english(oeh) = "search"
    '        chinese(oeh) = "搜索"
    '        oeh += 1
    '        deutsch(oeh) = "Neu darunter [einfg]"
    '        english(oeh) = "new under [ins]"
    '        chinese(oeh) = "新的"
    '        oeh += 1
    '        deutsch(oeh) = "Umbenennen "
    '        english(oeh) = "rename"
    '        chinese(oeh) = "重命名"
    '        oeh += 1
    '        deutsch(oeh) = "Löschen [entf]"
    '        english(oeh) = "remove [del]"
    '        chinese(oeh) = "移动"
    '        oeh += 1
    '        deutsch(oeh) = "Speichern"
    '        english(oeh) = "save"
    '        chinese(oeh) = "保存"
    '        oeh += 1
    '        deutsch(oeh) = "Haft-Notiz"
    '        english(oeh) = "desk note"
    '        chinese(oeh) = "新窗口"
    '        oeh += 1
    '        deutsch(oeh) = "Moechten Sie den Knoten wirklich loeschen?"
    '        english(oeh) = "Do you want to remove this node?"
    '        chinese(oeh) = "是否移动此节点？"
    '        oeh += 1
    '        deutsch(oeh) = "Ja"
    '        english(oeh) = "Yes"
    '        chinese(oeh) = "是"
    '        oeh += 1
    '        deutsch(oeh) = "Nein"
    '        english(oeh) = "No"
    '        chinese(oeh) = "否"
    '        oeh += 1
    '        deutsch(oeh) = "Baum in dem die Notizen geordnet sind"
    '        english(oeh) = "notes tree"
    '        chinese(oeh) = "词条正确"
    '        oeh += 1
    '        deutsch(oeh) = "Anzeige der jeweiligen Notiz"
    '        english(oeh) = "place where Notes are shown"
    '        chinese(oeh) = "显示节点所在位置"
    '        oeh += 1
    '        deutsch(oeh) = "Zeigen/Ausblenden"
    '        english(oeh) = "Show/Hide"
    '        chinese(oeh) = "显示/隐藏"
    '        oeh += 1
    '        deutsch(oeh) = "Suche"
    '        english(oeh) = "search"
    '        chinese(oeh) = "搜索"
    '        oeh += 1
    '        deutsch(oeh) = "Suchen"
    '        english(oeh) = "search"
    '        chinese(oeh) = "搜索"
    '        oeh += 1
    '        deutsch(oeh) = "Fertig"
    '        english(oeh) = "back"
    '        chinese(oeh) = "完成"
    '        oeh += 1
    '        deutsch(oeh) = "Alle Knoten durchsuchen?"
    '        english(oeh) = "search all nodes?"
    '        chinese(oeh) = "搜索所有词条？"
    '        oeh += 1
    '        deutsch(oeh) = "Ergebnisse:"
    '        english(oeh) = "results:"
    '        chinese(oeh) = "结果"
    '        oeh += 1
    '        deutsch(oeh) = "Wollen Sie vorher speichern?"
    '        english(oeh) = "Do you want to save before?"
    '        chinese(oeh) = "是否将前面保存？"
    '        oeh += 1
    '        deutsch(oeh) = "von vorn beginnen"
    '        english(oeh) = "begin again"
    '        chinese(oeh) = "重新开始"
    '        oeh += 1
    '        deutsch(oeh) = "von vorn beginnen"
    '        english(oeh) = "begin again"
    '        chinese(oeh) = "重新开始"
    '        oeh += 1
    '        deutsch(oeh) = "Vorhandene Daten werden gelöscht."
    '        english(oeh) = "Data will be lost."
    '        chinese(oeh) = "消除日期"
    '        oeh += 1
    '        deutsch(oeh) = "Sind sie sicher, dass Sie vorn beginnen wollen?"
    '        english(oeh) = "Are you sure to begin again?"
    '        chinese(oeh) = "是否决定重新开始?"
    '        oeh += 1
    '        deutsch(oeh) = "Möchten Sie vorher speichern?"
    '        english(oeh) = "Do you want to save before?"
    '        chinese(oeh) = "是否将前面保存？"
    '        oeh += 1
    '        deutsch(oeh) = "OK"
    '        english(oeh) = "OK"
    '        chinese(oeh) = "OK"
    '        oeh += 1
    '        deutsch(oeh) = "abbrechen"
    '        english(oeh) = "cancel"
    '        chinese(oeh) = "中止"
    '        oeh += 1
    '        deutsch(oeh) = "Kopieren"
    '        english(oeh) = "copy"
    '        chinese(oeh) = "复制"
    '        oeh += 1
    '        deutsch(oeh) = "Ausschneiden"
    '        english(oeh) = "cut"
    '        chinese(oeh) = "剪切"
    '        oeh += 1
    '        deutsch(oeh) = "Einfuegen"
    '        english(oeh) = "paste"
    '        chinese(oeh) = "粘贴"
    '        oeh += 1
    '        deutsch(oeh) = "normale Schrift"
    '        english(oeh) = "regular font"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Fett-Schrift"
    '        english(oeh) = "bold font"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Kursiv-Schrift"
    '        english(oeh) = "italic font"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "unterstrichen"
    '        english(oeh) = "underline"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "durchgestrichen"
    '        english(oeh) = "strikeout"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "grössere Schrift"
    '        english(oeh) = "bigger font"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "kleinere Schrift"
    '        english(oeh) = "smaller font"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Zusammenfassen"
    '        english(oeh) = "together in one node"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Info + Hilfe + Feedback"
    '        english(oeh) = "info + help + feedback"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "alles"
    '        english(oeh) = "everything"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "unterhalb des markierten Knotens"
    '        english(oeh) = "inside the marked node"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Keine Datei wurde geladen."
    '        english(oeh) = "No file is loaded."
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Fehler beim Laden von XML Code:"
    '        english(oeh) = "Error when loading xml code:"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Passwort setzen"
    '        english(oeh) = "set password"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "altes Passwort"
    '        english(oeh) = "old password"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "neues Passwort"
    '        english(oeh) = "new password"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "wiederholen"
    '        english(oeh) = "again"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Das Passwort darf nicht mehr als 24 Zeichen haben."
    '        english(oeh) = "Not more than 24 characters are allowed."
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Das alte Passwort ist falsch."
    '        english(oeh) = "The old password is wrong."
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Passwort"
    '        english(oeh) = "password"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Passwort falsch oder Datei fehlerhaft"
    '        english(oeh) = "wrong password or incorrect file"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Die letzten beiden Eingaben sind nicht gleich."
    '        english(oeh) = "The last 3 entrys are not equal."
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Leeres Feld bedeutet kein Passwort."
    '        english(oeh) = "Empty textbox means no password."
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Bild einfügen"
    '        english(oeh) = "insert picture"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Datum einfügen"
    '        english(oeh) = "insert date"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Hintergrundfarbe"
    '        english(oeh) = "background color"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Minimieren"
    '        english(oeh) = "minimize"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Schließen"
    '        english(oeh) = "close"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Haftnotizfensterrand einblenden"
    '        english(oeh) = "show desknote borders"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Hintergrundfarbe"
    '        english(oeh) = "Background Color"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Schriftfarbe"
    '        english(oeh) = "Font Color"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Sicherungen der Notizen"
    '        english(oeh) = "backup copies"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Autostart"
    '        english(oeh) = "autorun"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Farbe"
    '        english(oeh) = "color"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Passwort"
    '        english(oeh) = "password"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Pfad+Datei"
    '        english(oeh) = "Path+File"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Die Datei muss auf .alx enden!"
    '        english(oeh) = "File has to end with .alx !"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Export"
    '        english(oeh) = "export"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "in rtf"
    '        english(oeh) = "in rtf"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "in ansi txt"
    '        english(oeh) = "in ansi txt"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "in unicode txt"
    '        english(oeh) = "in unicode txt"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "daneben [Enter]"
    '        english(oeh) = "next [Enter]"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "darunter [einfg]"
    '        english(oeh) = "under [insert]"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Neu daneben [Enter]"
    '        english(oeh) = "new next [Enter]"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "ganze Wörter"
    '        english(oeh) = "whole words"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Gross-/Klein-Schreibung beachten"
    '        english(oeh) = "case sensitive"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = ChrW(8226) + " Eine Haftnotiz erstellt man mit dem Menü eines Knotens und erreicht man dann über das Menü des Trayicons." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
    '     ChrW(8226) + " Einzelne Knoten lassen sich als rtf Datei zusammenfassen, die z.B. mit Wordpad lesbar sind." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
    '     ChrW(8226) + " Erstellt man eine Verknüpfung mit dem Ziel ""C:\Ort1\Notizen.exe"" -min ""C:\Dokumente und Einstellungen\Benutzer\Eigene Dateien\Notizen\datei.alx"" also erst Notizen.exe und die alx-Datei, dann öffnet sich das Programm zusammen mit der Notizendatei. Beide Ortsangaben müssen am Besten in Anführungszeichen stehen. Stellt man diese Verknüpfung in den Autostartordner, so hat man immer seine gut sortierten Notizen zur Hand." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
    '     ChrW(8226) + " Die Anhabe /min sorgt als Programmstartangabe z.B. in einer Verknüpfung für ein minimiertes Hauptfenster bei Beginn. (notizen.exe /min Zieldatei)"" " + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
    '     ChrW(8226) + " Startet man Notizen .Net mit Adminrechten kann danach eine alx-Datei durch den Explorerer erkannt werden."

    '        english(oeh) = ChrW(8226) + " A desknote can be created by using the menu of the node and can be reached by the trayicon menu." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
    'ChrW(8226) + " Nodes can be summed up as rtf file, witch can be read with Wordpad, Word or OpenOffice." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
    'ChrW(8226) + " Create a Link with with a destination: ""C:\Ort1\Notizen.exe"" -min ""C:\Dokumente und Einstellungen\Benutzer\Eigene Dateien\Notizen\datei.alx"" , first Notizen.exe and the alx file, the program will be opend by opening the File. Both Locations should be better into double quotes. If you put the link into the autostart folder you have your notes by starting the Computer." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
    'ChrW(8226) + " The argument /min after Notizen.exe, maybe in a line of a link, makes the programm running minimized at startup. (notizen.exe /min destination file)"" " + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
    '     ChrW(8226) + "If you run Notizen .Net with Administrator permissions once, the explorer will know Notizen .NET alx Files."
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "persönliche Meinung / Fehlermeldung / Feature-Vorschlag"
    '        english(oeh) = "opinion / bug report / feature request"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "persönliche Meinung / Fehlermeldung / Feature-Vorschlag"
    '        english(oeh) = "opinion / bug report / feature request"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "schließen"
    '        english(oeh) = "close"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "senden"
    '        english(oeh) = "send"
    '        chinese(oeh) = ""
    '        oeh += 1
    '        deutsch(oeh) = "Nach 3 Feebacks kann man erst wieder am nächsten Tag senden."
    '        english(oeh) = "After 3 Feedbacks sending feedback is only possible tomorrow."
    '        chinese(oeh) = ""


    '    End Sub
    Public Sub set_lang(ByVal language As lang_enum)

        Me.lang_chosen = language

        set_partial_scroll()

        ToolStrip_colormenue.Text = lang_pointer(lang_keys.color)
        bgcolorToolStripMenuItem.Text = lang_pointer(lang_keys.kontext2_9)
        fgcolorToolStripMenuItem.Text = lang_pointer(lang_keys.kontext2_10)

        ExportToolStripMenuItem.Text = lang_pointer(lang_keys.export)
        export_rtf_MenuItem.Text = lang_pointer(lang_keys.exportrtf)
        export_txt_MenuItem.Text = lang_pointer(lang_keys.exporttxt)
        export_txt2_MenuItem.Text = lang_pointer(lang_keys.exporttxt2)

        Startmenue.Text = lang_pointer(lang_keys.Strip1_1)

        'NeuToolStripMenuItem.Text = lang_pointer(lang_keys.Strip1_2)
        oeffnenToolStripMenuItem.Text = lang_pointer(lang_keys.Strip1_3)
        SpeichernToolStripMenuItem.Text = lang_pointer(lang_keys.Strip1_4)
        SpeichernUnterToolStripMenuItem.Text = lang_pointer(lang_keys.Strip1_5)
        SchliessenToolStripMenuItem.Text = lang_pointer(lang_keys.Strip1_6)
        ToolStripMenuItem1.Text = lang_pointer(lang_keys.Strip1_7)
        BeendenToolStripMenuItem.Text = lang_pointer(lang_keys.Strip1_8)
        EinheitToolStripMenuItem.Text = lang_pointer(lang_keys.unity_note)
        infoToolStripMenuItem.Text = lang_pointer(lang_keys.Strip1_20)
        einheit_start_MenuItem.Text = lang_pointer(lang_keys.Strip1_1_1)
        einheit_node_MenuItem.Text = lang_pointer(lang_keys.Strip1_1_2)
        passwortToolStripMenuItem.Text = lang_pointer(lang_keys.strip1_21)

        new_next_toolstripmenuitem.Text = lang_pointer(lang_keys.nexxt)
        new_under_toolstripmenuitem.Text = lang_pointer(lang_keys.under)
        'me.Baum.ContextMenuStrip.Items.Item(1).  ).new_under.Text = lang_pointer(lang_keys.nexxt)
        'Baum_Kontext_.t()
        ToolStrip_italic.ToolTipText = lang_pointer(lang_keys.font_italic)
        ToolStrip_underline.ToolTipText = lang_pointer(lang_keys.font_underline)
        ToolStrip_bigger.ToolTipText = lang_pointer(lang_keys.font_bigger)
        ToolStrip_bold.ToolTipText = lang_pointer(lang_keys.font_bold)
        ToolStrip_smaller.ToolTipText = lang_pointer(lang_keys.font_smaller)
        ToolStrip_strikeout.ToolTipText = lang_pointer(lang_keys.font_strikeout)
        ToolStrip_regular.ToolTipText = lang_pointer(lang_keys.font_regular)
        ToolStrip_fonts.ToolTipText = lang_pointer(lang_keys.Strip2_1)
        ToolStrip_fonts.Text = lang_pointer(lang_keys.Strip2_1)


        'Notizen.ToolStripDropDownButton2.Text = lang_pointer(lang_keys.Strip1-9).Item(wahl)
        'Notizen.F黵DenProgrammiererHofeToolStripMenuItem.Text = lang_pointer(lang_keys.Strip1-10).Item(wahl)

        'b_neu.Text = lang_pointer(lang_keys.Strip1_11)
        b_oeffnen.Text = lang_pointer(lang_keys.Strip1_12)
        b_sichern.Text = lang_pointer(lang_keys.Strip1_13)
        b_schliessen.Text = lang_pointer(lang_keys.Strip1_14)
        b_drucken.Text = lang_pointer(lang_keys.Strip1_15)

        SchriftToolStripMenuItem.Text = lang_pointer(lang_keys.Strip1_16)
        BearbeitenToolStripMenuItem.Text = lang_pointer(lang_keys.Strip1_17)
        NeuToolStripMenuItem1.Text = lang_pointer(lang_keys.Strip1_18)
        ToolStripSplitButton1.Text = lang_pointer(lang_keys.Strip1_19)

        'schrift.Text = lang_pointer(lang_keys.Strip2_1)

        NeuToolStripButton.Text = lang_pointer(lang_keys.Strip3_1)
        loeschen.Text = lang_pointer(lang_keys.Strip3_2)

        AusschneidenToolStripButton.Text = lang_pointer(lang_keys.Strip4_1)
        KopierenToolStripButton.Text = lang_pointer(lang_keys.Strip4_2)
        EinfuegenToolStripButton.Text = lang_pointer(lang_keys.Strip4_3)

        ikontext.Items(0).Text = lang_pointer(lang_keys.kontext1)
        ikontext.Items(1).Text = lang_pointer(lang_keys.kontext2)
        ikontext.Items(2).Text = lang_pointer(lang_keys.kontext3)
        ikontext.Items(3).Text = lang_pointer(lang_keys.kontext6)
        ikontext.Items(4).Text = lang_pointer(lang_keys.kontext7)
        ikontext.Items(5).Text = lang_pointer(lang_keys.kontext4)
        ikontext.Items(6).Text = lang_pointer(lang_keys.kontext5)

        Me.Baum.ContextMenuStrip.Items(0).Text = lang_pointer(lang_keys.kontext2_1)
        Me.Baum.ContextMenuStrip.Items(1).Text = lang_pointer(lang_keys.kontext11)
        Me.Baum.ContextMenuStrip.Items(2).Text = lang_pointer(lang_keys.kontext2_2)

        Me.Baum.ContextMenuStrip.Items(3).Text = lang_pointer(lang_keys.kontext2_6)
        Me.Baum.ContextMenuStrip.Items(4).Text = lang_pointer(lang_keys.kontext2_7)
        Me.Baum.ContextMenuStrip.Items(5).Text = lang_pointer(lang_keys.kontext2_8)

        Me.Baum.ContextMenuStrip.Items(6).Text = lang_pointer(lang_keys.kontext2_3)
        Me.Baum.ContextMenuStrip.Items(7).Text = lang_pointer(lang_keys.kontext2_4)
        Me.Baum.ContextMenuStrip.Items(8).Text = lang_pointer(lang_keys.kontext2_5)

        Me.Baum.ContextMenuStrip.Items(9).Text = lang_pointer(lang_keys.kontext2_9)
        Me.Baum.ContextMenuStrip.Items(10).Text = lang_pointer(lang_keys.kontext2_10)

        ToolTip1.SetToolTip(Me.Baum, lang_pointer(lang_keys.info1))
        ToolTip1.SetToolTip(Me.Inhalt, lang_pointer(lang_keys.info2))
        tray_kontext.Items(0).Text = lang_pointer(lang_keys.Strip1_8)
        tray_kontext.Items(1).Text = lang_pointer(lang_keys.info3)

        Me.text_lang_1 = lang_pointer(lang_keys.fehler1)
        Me.text_lang_2 = lang_pointer(lang_keys.fehler2)

    End Sub

#End Region
#Region "Drag n Drop"

    Public Function create_desknode_not_show(ByVal window As Rectangle, ByRef desktreenode As TreeNode, ByVal transparenz As Double, ByVal farbe As Color) As desknote
        If Not desktreenode.Tag.desknote Is Nothing Then
            desktreenode.Tag.desknote.schliesse()
            desktreenode.Tag.desknote = Nothing
        End If

        Dim new_desk_note As New desknote(desktreenode, window, transparenz, farbe)
        desk_notes.Add(new_desk_note, desktreenode)
        desk_notes_list.Add(desktreenode)
        new_desk_note.knoten.Tag.desknote = new_desk_note
        desk_notes_counter += 1

        If TrayIcon.ContextMenuStrip.Items.Count = 2 Then
            tray_kontext.Items.Add(New ToolStripSeparator)
        End If
        tray_kontext.Items.Add(desk_notes_counter.ToString + ". " + desktreenode.Text)
        tray_kontext.Items.Item(tray_kontext.Items.Count - 1).Tag = new_desk_note
        Return new_desk_note
    End Function

    'Private Sub MouseLeave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Baum.MouseLeave
    '    If MouseButtons = Windows.Forms.MouseButtons.Left Then
    '        If Not onode Is Nothing Then
    '            make_haft_notitz()
    '        End If
    '    End If
    'End Sub
#End Region
#Region "Rest"

    Sub close_all_haft()
        Dim i As Integer
        For i = 2 To Me.TrayIcon.ContextMenuStrip.Items.Count - 1
            Me.TrayIcon.ContextMenuStrip.Items.Item(2).Dispose()
        Next
        Dim desknotepair As New KeyValuePair(Of desknote, TreeNode)
        For Each desknotepair In desk_notes
            desknotepair.Key.Dispose()
        Next
        Me.desk_notes.Clear()
        Me.desk_notes_list.Clear()
        desk_notes_counter = 0
    End Sub

    Private Shadows Sub close()

    End Sub

    Private Sub schliesse()
        beenden = True
        xml_kram.on_exit()
        If schliessen() Then
            Me.Dispose()
        End If
    End Sub


    Public Sub have_changed_file()
        Me.veraendert = True
        Me.label_unten.Text = "*"
        Me.b_sichern.Enabled = True
        Me.b_sichernftp.Enabled = True
        Me.SpeichernToolStripMenuItem.Enabled = True
        'Baum.LabelEdit = False
    End Sub

#End Region
#Region "Menu"

    Private Sub BearbeitenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BearbeitenToolStripMenuItem.Click
        If BearbeitenToolStripMenuItem.Checked = False And Inhalt.Enabled = True Then
            BearbeitenToolStripMenuItem.Checked = True
            Me.ToolStrip3.Location = New Point(toolstrip_breite, 0)
            ToolStrip3.Visible = True
        ElseIf BearbeitenToolStripMenuItem.Checked = True Then
            BearbeitenToolStripMenuItem.Checked = False
            ToolStrip3.Visible = False
        End If
        'Me.resize2()
    End Sub

    Private Sub set_unchanged()
        Me.veraendert = False
        Me.label_unten.Text = ""
        Me.b_sichern.Enabled = False
        Me.SpeichernToolStripMenuItem.Enabled = False
    End Sub

    Public Sub passwort_bearbeite()
        If p.Length > 24 Then
            p = p.Substring(0, 24)
        ElseIf p.Length < 24 Then
            While Not p.Length = 24
                p += " "
            End While
        End If
    End Sub


    Public Sub oeffnen_streams(Optional ByVal ftpUrl As String = "")
        'Dim XMLReader1 As Xml.XmlReader = New Xml.XmlTextReader(odatei.Verzeichnis + "\" + odatei.SaveName)
        'Try
        '    xmlread(XMLReader1)
        'Catch
        Me.p = "                        "
        Dim kompr_stream As GZipStream = Nothing
        Dim reader As StreamReader = Nothing
        Dim fsread As Stream = Nothing
        Try
            If ftpUrl = "" Then
                fsread = New FileStream(odatei.Verzeichnis + "\" + odatei.SaveName, FileMode.Open, FileAccess.Read)
            Else
                Dim downloadRequest As FtpWebRequest = WebRequest.Create(ftpUrl)
                Dim downloadResponse As FtpWebResponse = downloadRequest.GetResponse()
                fsread = downloadResponse.GetResponseStream()
            End If
            kompr_stream = New GZipStream(fsread, CompressionMode.Decompress, False)
            Dim XMLReader As Xml.XmlReader = New Xml.XmlTextReader(kompr_stream)
            Inhalt.node_set(Baum.topnode)
            Baum.Visible = False
            xmlread(XMLReader)
        Catch ex As UriFormatException
            MsgBox("UriFormatException: " + ex.Message)

        Catch ex As WebException
            If ex.Status = 7 And ftpversuche > 0 Then
                ftpversuche -= 1
                oeffnen_streams(ftpUrl)
            Else
                MsgBox("WebException: " + ex.Message)

            End If
        Catch ex As InvalidDataException
            passwort_dialog2 = New passwort_dialog2(lang_pointer(lang_keys.password), lang_pointer(lang_keys.passwort_falsch), ftpUrl)
            passwort_dialog2.Show()
            passwort_dialog2.Activate()
        Catch ex As Exception
            MsgBox("Error: " + ex.Message)
            Me.error_with_file = True
        Finally
            'XMLReader1.Close()
            Try
                If kompr_stream IsNot Nothing Then kompr_stream.Close()
                If fsread IsNot Nothing Then fsread.Close()
                If reader IsNot Nothing Then reader.Close()
            Catch
            End Try
            Baum.Visible = True
        End Try

        'End Try
    End Sub

    Function toolstrip_breite()
        Dim item As ToolStrip
        Dim breite As Int16
        For Each item In Me.ToolStripContainer2.TopToolStripPanel.Controls
            If item.Visible Then
                breite += item.Width
            End If
        Next
        toolstrip_breite = breite
    End Function

    Private Sub merke_4dateien()
        If odatei.Verzeichnis + odatei.SaveName <> File1ToolStripMenuItem.Tag + File1ToolStripMenuItem.Text _
        And odatei.Verzeichnis + odatei.SaveName <> File2ToolStripMenuItem.Tag + File2ToolStripMenuItem.Text _
        And odatei.Verzeichnis + odatei.SaveName <> File3ToolStripMenuItem.Tag + File3ToolStripMenuItem.Text _
        And odatei.Verzeichnis + odatei.SaveName <> File4ToolStripMenuItem.Tag + File4ToolStripMenuItem.Text Then
            If Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1) Is BeendenToolStripMenuItem Then
                File1ToolStripMenuItem.Text = odatei.SaveName
                File1ToolStripMenuItem.Tag = odatei.Verzeichnis
                Startmenue.DropDownItems.Add(ToolStripSeparator5)
                Startmenue.DropDownItems.Add(File1ToolStripMenuItem)
            ElseIf Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1) Is File1ToolStripMenuItem Then
                File2ToolStripMenuItem.Text = odatei.SaveName
                File2ToolStripMenuItem.Tag = odatei.Verzeichnis
                Startmenue.DropDownItems.Add(File2ToolStripMenuItem)
            ElseIf Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1) Is File2ToolStripMenuItem Then
                File3ToolStripMenuItem.Text = odatei.SaveName
                File3ToolStripMenuItem.Tag = odatei.Verzeichnis
                Startmenue.DropDownItems.Add(File3ToolStripMenuItem)
            ElseIf Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1) Is File3ToolStripMenuItem Then
                File4ToolStripMenuItem.Text = odatei.SaveName
                File4ToolStripMenuItem.Tag = odatei.Verzeichnis
                Startmenue.DropDownItems.Add(File4ToolStripMenuItem)
            ElseIf Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1) Is File4ToolStripMenuItem Then
                File1ToolStripMenuItem.Text = File2ToolStripMenuItem.Text
                File1ToolStripMenuItem.Tag = File2ToolStripMenuItem.Tag
                File2ToolStripMenuItem.Text = File3ToolStripMenuItem.Text
                File2ToolStripMenuItem.Tag = File3ToolStripMenuItem.Tag
                File3ToolStripMenuItem.Text = File4ToolStripMenuItem.Text
                File3ToolStripMenuItem.Tag = File4ToolStripMenuItem.Tag
                File4ToolStripMenuItem.Text = odatei.SaveName
                File4ToolStripMenuItem.Tag = odatei.Verzeichnis
            End If
        End If
    End Sub
    Public Sub wasimbaum()
        If Not error_with_file Then
            odatei.saved = False
            ExportToolStripMenuItem.Enabled = True
            export_rtf_MenuItem.Enabled = True
            export_txt_MenuItem.Enabled = True
            EinheitToolStripMenuItem.Enabled = True
            einheit_node_MenuItem.Enabled = True
            einheit_start_MenuItem.Enabled = True
            Me.SpeichernUnterToolStripMenuItem.Enabled = True
            Me.SpeichernToolStripMenuItem.Enabled = True
            Me.SchliessenToolStripMenuItem.Enabled = True
            Me.passwortToolStripMenuItem.Enabled = True
            b_schliessen.Enabled = True
            Me.txt1.Text = Baum.topnode.Text
            Me.txt2.Text = Baum.topnode.Text
            ToolTip1.RemoveAll()
        End If
        Me.b_sichern.Enabled = True
        Me.Inhalt.Enabled = True
        Me.ToolStrip_fontstyle.Location = New Point(toolstrip_breite, 0)
        Me.ToolStrip_fontstyle.Visible = True
        SchriftToolStripMenuItem.Visible = True
        ToolStrip3.Visible = True
        Me.ToolStrip3.Location = New Point(toolstrip_breite, 0)
        BearbeitenToolStripMenuItem.Visible = True
        Me.loeschen.Enabled = True
        If Not Me.fonts_loaded Then fonts_insert()
        Baum.Visible = True
        Me.Baum.Enabled = True
        Me.Baum.Visible = True
    End Sub

    Public Sub oeffnen_datei_danachmach(ByRef ftpUrl As String)
        If TypeOf (Baum.topnode) Is TreeNode Then
            wasimbaum()
            If error_with_file = False Then
                'leser.Close()
                odatei.datei_da = True
                'Catch ex As Exception
                '    Dim fehler As Dialog_Error = New Dialog_Error(ex)
                '    fehler.Show()
                'End Try
                Me.Text = odatei.SaveName + " in " + odatei.Verzeichnis

                Baum.SelectedNode = Baum.topnode
                If TypeOf (Baum.SelectedNode.Tag) Is CText Then
                    Inhalt.Rtf = Baum.SelectedNode.Tag.text
                End If
                set_unchanged()
                Inhalt.node_set(Baum.topnode)
                BearbeitenToolStripMenuItem.Checked = True
                '------\

                If ftpUrl = "" Then merke_4dateien()
            End If
        End If
    End Sub

    Private Delegate Sub oeffne_datei_delegate(ByVal ort As String)
    Private Delegate Sub oeffne_datei_delegate2(ByVal ort As String, ByVal ftpUrl As String)

    Public Sub oeffne_datei(ByVal ort As String, Optional ByVal ftpUrl As String = "")
        Baum.Visible = False
        odatei.SaveName = ort
        'Try
        'Dim leser As New System.IO.StreamReader(odatei.SaveName)
        If Not Me.Baum.topnode Is Nothing Then
            Me.Baum.Nodes.Clear()
            Me.Inhalt.Text = ""
            Me.Inhalt.Enabled = False
            Me.txt2.Text = ""
        End If
        close_all_haft()
        oeffnen_streams(ftpUrl)
        oeffnen_datei_danachmach(ftpUrl)
        error_with_file = False
    End Sub

    Delegate Sub me_enable_delegate()
    Delegate Sub me_disable_delegate()
    Sub me_enable()
        Me.ToolStripContainer2.Enabled = False
    End Sub
    Sub me_disable()
        Me.ToolStripContainer2.Enabled = True
    End Sub

    Public Sub oeffnen_dialog()
        SyncLock Me
            If open_this = 0 Then
                ToolStripContainer2.Invoke(New me_enable_delegate(AddressOf me_enable))
                'OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
                OpenFileDialog.Filter = ".alx Dateien|*.alx;*.xml"
                OpenFileDialog.DefaultExt = "*.alx"
                OpenFileDialog.InitialDirectory = odatei.Verzeichnis
                OpenFileDialog.FileName = ""
                If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                    schliessen()
                    Me.Invoke(New oeffne_datei_delegate(AddressOf oeffne_datei), New Object() {OpenFileDialog.FileName})
                End If
                ToolStripContainer2.Invoke(New me_disable_delegate(AddressOf me_disable))
                'OpenFileDialog.Dispose()
                'OpenFileDialog = Nothing
            Else
                If schliessen() Then
                    Select Case open_this
                        Case 1
                            Me.Invoke(New oeffne_datei_delegate(AddressOf oeffne_datei), New Object() {File1ToolStripMenuItem.Tag + "\" + File1ToolStripMenuItem.Text})
                        Case 2
                            Me.Invoke(New oeffne_datei_delegate(AddressOf oeffne_datei), New Object() {File2ToolStripMenuItem.Tag + "\" + File2ToolStripMenuItem.Text})
                        Case 3
                            Me.Invoke(New oeffne_datei_delegate(AddressOf oeffne_datei), New Object() {File3ToolStripMenuItem.Tag + "\" + File3ToolStripMenuItem.Text})
                        Case 4
                            Me.Invoke(New oeffne_datei_delegate(AddressOf oeffne_datei), New Object() {File4ToolStripMenuItem.Tag + "\" + File4ToolStripMenuItem.Text})
                    End Select
                End If
            End If
        End SyncLock
    End Sub

    Public Sub oeffne()
        dateidialoge_strang = New Threading.Thread(AddressOf oeffnen_dialog)
        dateidialoge_strang.Name = "oeffnen"
        dateidialoge_strang.SetApartmentState(Threading.ApartmentState.STA)
        dateidialoge_strang.Start()
    End Sub

    Public Function speichern(Optional ByRef ftpurl As String = "") As Boolean
        Inhalt.node_set(Me.Inhalt.node)
        speichern_streams(ftpurl)
        Me.SpeichernToolStripMenuItem.Enabled = True
        If ftpurl = "" Then
            odatei.saved = True
            odatei.datei_da = True
            set_unchanged()
        End If
        If error_with_file = True Then
            error_with_file = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub tray_kontext_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles tray_kontext.Closing
        If e.CloseReason = ToolStripDropDownCloseReason.ItemClicked Then
            If Me.TrayIcon.ContextMenuStrip.Items.Item(0).Selected Then
                Me.schliesse() 'BeendenToolStripMenuItem_Click(sender, e)
            ElseIf Me.TrayIcon.ContextMenuStrip.Items.Item(1).Selected Then
                Me.change_win_state()
            Else
                Dim i As Byte
                For i = 3 To Me.TrayIcon.ContextMenuStrip.Items.Count - 1

                    ' Welche wurde Selektiert
                    If Me.TrayIcon.ContextMenuStrip.Items.Item(i).Selected Then
                        Me.TrayIcon.ContextMenuStrip.Items.Item(i).Tag.show()
                        Me.TrayIcon.ContextMenuStrip.Items.Item(i).Tag.Activate()
                        Me.TrayIcon.ContextMenuStrip.Items.Item(i).Tag.WindowState = FormWindowState.Normal
                        If Me.TrayIcon.ContextMenuStrip.Items.Item(i).Tag.Width < 100 Or Me.TrayIcon.ContextMenuStrip.Items.Item(i).Tag.Height < 100 Then
                            Me.TrayIcon.ContextMenuStrip.Items.Item(i).Tag.Size = New Point(100, 100)
                            Me.TrayIcon.ContextMenuStrip.Items.Item(i).Tag.reload_texts()
                        End If

                    End If
                Next
            End If
        End If
    End Sub

    Public Sub new_topnode()
        Me.have_changed_file()
        Me.p = ""
        If Not TypeOf (Baum.topnode) Is TreeNode Then
            If Not Me.fonts_loaded Then
                fonts_insert()
            End If
            Baum.element_dazu()
            odatei.datei_da = False
            close_all_haft()
            BearbeitenToolStripMenuItem.Checked = True
            Me.ToolStrip_fontstyle.Location = New Point(toolstrip_breite, 0)
            Me.ToolStrip_fontstyle.Visible = True
            Me.ToolStrip3.Location = New Point(toolstrip_breite, 0)
            ToolStrip3.Visible = True
            BearbeitenToolStripMenuItem.Visible = True
            SchriftToolStripMenuItem.Visible = True
            Me.EinheitToolStripMenuItem.Enabled = True
        Else
            Dim oneu As New wanna_restart
            If oneu.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                oneu.Dispose()
                If schliessen() Then new_topnode()
            Else
                oneu.Dispose()
            End If
        End If
    End Sub


    'Private Sub NeuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuToolStripMenuItem.Click
    '    new_topnode()
    'End Sub
    Private Sub ftpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftpToolStripMenuItem.Click
        ftpkram = New ftpkram
        ftpkram.Visible = True
        ftpkram.Activate()
    End Sub
    Private Sub SpeichernToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeichernToolStripMenuItem.Click
        Me.save_anyway()
    End Sub

    Private Sub OeffnenToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles oeffnenToolStripMenuItem.Click
        open_this = 0
        oeffne()
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.schliesse()
    End Sub

    Private Function speichern_unter() As Boolean
        SaveFileDialog2.Filter = "alx Dateien|*.alx"
        SaveFileDialog2.DefaultExt = "*.alx"
        SaveFileDialog2.InitialDirectory = odatei.Verzeichnis
        SaveFileDialog2.FileName = odatei.SaveName
        Dim bclick As DialogResult = SaveFileDialog2.ShowDialog()
        odatei.saved = False
        If bclick = DialogResult.OK Then
            odatei.SaveName = SaveFileDialog2.FileName

            'Try
            speichern_streams()
            odatei.datei_da = True
            odatei.saved = True
            set_unchanged()
            'Catch ex As Exception
            '    Dim fehler As Dialog_Error = New Dialog_Error(ex)
            '    fehler.Show()
            'End Try
            Me.Text = odatei.SaveName + " - " + odatei.Verzeichnis
            Me.merke_4dateien()
            Me.SpeichernToolStripMenuItem.Enabled = True
            Me.passwortToolStripMenuItem.Enabled = True
            Me.b_sichern.Enabled = True
            Return True
        Else : Return False
        End If
    End Function


    Private Sub SpeichernUnterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeichernUnterToolStripMenuItem.Click
        speichern_unter()
    End Sub


    Private Function save_and_if_canceled() As Boolean
        If Not Baum.topnode.FirstNode Is Nothing Or Inhalt.Text <> "" Then
            If veraendert And TypeOf Me.Baum.topnode Is TreeNode Then
                Dim if_save_dialog As New wanna_save
                if_save_dialog.ShowDialog()
                If if_save_dialog.DialogResult = Windows.Forms.DialogResult.Yes Then
                    Return Not save_anyway()
                ElseIf if_save_dialog.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
            Return False
        End If
    End Function

    Public Delegate Function schliessen_ohne_fragen_delegate() As Boolean

    Public Function schliessen_ohne_fragen() As Boolean
        'Me.p = "************************"
        If Not p Is Nothing Then
            If p.Length > 0 And gch = GCHandle.Alloc(p, GCHandleType.Pinned) Then
                ZeroMemory(gch.AddrOfPinnedObject(), p.Length * 2)
                gch.Free()
            End If
        End If
        Me.Baum.Nodes.Clear()
        Me.Inhalt.Text = ""
        Me.Inhalt.Enabled = False
        Me.txt1.Text = ""
        Me.txt2.Text = ""
        Me.SpeichernUnterToolStripMenuItem.Enabled = False
        Me.SpeichernToolStripMenuItem.Enabled = False
        Me.passwortToolStripMenuItem.Enabled = False
        Me.SchliessenToolStripMenuItem.Enabled = False
        Me.b_sichern.Enabled = False
        Me.Text = "Notizen .NET " + version
        odatei.datei_da = False
        odatei.saved = False
        b_schliessen.Enabled = False
        close_all_haft()
        BearbeitenToolStripMenuItem.Checked = False
        ToolStrip3.Visible = False
        BearbeitenToolStripMenuItem.Visible = False
        Me.loeschen.Enabled = False
        b_drucken.Visible = False
        veraendert = False
        label_unten.Text = ""
        Me.ToolStrip_fontstyle.Visible = False
        SchriftToolStripMenuItem.Visible = False
        ExportToolStripMenuItem.Enabled = False
        export_rtf_MenuItem.Enabled = False
        export_txt_MenuItem.Enabled = False
        EinheitToolStripMenuItem.Enabled = False
        einheit_node_MenuItem.Enabled = False
        einheit_start_MenuItem.Enabled = False
        'Me.resize2()
        new_topnode()
    End Function

    Private Delegate Function save_and_if_canceled_delegate()

    Public Function schliessen() As Boolean
        If Not CBool(Me.Baum.Invoke(New save_and_if_canceled_delegate(AddressOf save_and_if_canceled))) Then
            Me.Invoke(New schliessen_ohne_fragen_delegate(AddressOf schliessen_ohne_fragen))
            error_with_file = False
            Return True
        Else
            Return False
        End If
    End Function



    Public Sub SchliessenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SchliessenToolStripMenuItem.Click
        schliessen()
    End Sub


    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_neu.Click
    '    new_topnode()
    'End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_schliessen.Click
        SchliessenToolStripMenuItem_Click(sender, e)
    End Sub

    Public Function save_anyway() As Boolean
        If Not Me.Baum.topnode Is Nothing Then
            ToolTip1.RemoveAll()
            If odatei.datei_da And My.Computer.FileSystem.FileExists(odatei.Verzeichnis + "\" + odatei.SaveName) Then
                Return speichern()
            Else
                Return speichern_unter()
            End If
        Else
            Return False
        End If
    End Function


    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_sichern.Click
        save_anyway()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_oeffnen.Click
        open_this = 0
        oeffne()
    End Sub

    Public Sub neu_neben_knoten()
        Me.have_changed_file()
        If Not TypeOf (Baum.topnode) Is TreeNode Then
            new_topnode()
        Else
            If TypeOf Inhalt.node Is TreeNode Then
                Inhalt.node.EndEdit(True)
                If Inhalt.node.Level > 0 Then
                    Inhalt.node_set(Inhalt.node.Parent)
                    Me.Baum.SelectedNode = Inhalt.node
                End If
                Baum.element_dazu()
            End If
        End If
    End Sub

    Private Sub NeuToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuToolStripButton.Click
        'neu_neben_knoten()
    End Sub

    '    Private Sub NeuToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuToolStripMenuItem1.Click
    '   End Sub

    Private Sub SchriftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SchriftToolStripMenuItem.Click
        If SchriftToolStripMenuItem.Checked = False Then
            SchriftToolStripMenuItem.Checked = True
            Me.ToolStrip_fontstyle.Location = New Point(toolstrip_breite, 0)
            Me.ToolStrip_fontstyle.Visible = True
        Else
            SchriftToolStripMenuItem.Checked = False
            Me.ToolStrip_fontstyle.Visible = False
        End If
        'Me.resize2()
    End Sub



    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loeschen.Click
        If TypeOf Me.Baum.SelectedNode Is TreeNode Then
            Baum.element_loeschen()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            einstell.Dispose()
        Catch ex As Exception
        End Try
        einstell = New einstellungen
        einstell.Show()
        einstell.Activate()
    End Sub

    Private Function unity_list_begin(ByRef node As TreeNode) As Boolean
        If unitydeph >= unitylist.Count Then
            unitylist.Add(0)
        End If
        unitylist(unitydeph) += 1
        Dim i As Integer = 0
        Dim k As Integer = Me.unityrtfbox.Text.Length
        Dim anf As Integer = Me.unityrtfbox.Text.Length
        For i = 1 To unitydeph
            Clipboard.Clear()
            Clipboard.SetData(DataFormats.Rtf, unitylist(i).ToString + ".")
            If Clipboard.GetData(DataFormats.Rtf) IsNot Nothing Then
                Me.unityrtfbox.Select(Me.unityrtfbox.Text.Length, 0)
                Me.unityrtfbox.Paste()
            End If
        Next
        Clipboard.Clear()
        Clipboard.SetData(System.Windows.Forms.DataFormats.Text, " " + node.Text + Chr(10) + Chr(13) + Chr(10) + Chr(13))
        'Clipboard.SetText(" " + node.Text + Chr(10) + Chr(13) + Chr(10) + Chr(13))
        'Clipboard.SetData(DataFormats.Text, " " + node.Text + Chr(10) + Chr(13) + Chr(10) + Chr(13))
        Me.unityrtfbox.Select(Me.unityrtfbox.Text.Length, 0)
        If Clipboard.GetData(DataFormats.Text) IsNot Nothing Then
            Me.unityrtfbox.Paste()
        End If
        Me.unityrtfbox.Select(k, Me.unityrtfbox.TextLength - k)
        Me.unityrtfbox.SelectionFont = New Font("Arial", 14, FontStyle.Bold)

        If node.Tag.text <> "" Then
            Clipboard.Clear()
            Clipboard.SetData(DataFormats.Rtf, node.Tag.text)
            'If Me.unityrtfbox2.Text <> "" Then
            '    Me.unityrtfbox2.SelectAll()
            '    Me.unityrtfbox2.Copy()
            '    Me.unityrtfbox.Select(Me.unityrtfbox.Text.Length, 0)
            '    If Clipboard.GetData(DataFormats.Rtf) IsNot Nothing Then
            Me.unityrtfbox.Select(Me.unityrtfbox.TextLength, 0)
            Me.unityrtfbox.Paste()
            '    End If
            'End If
        End If
        'System.Threading.Thread.Sleep(500)
        'Clipboard.SetData(DataFormats.Text, Chr(10) + Chr(13) + Chr(10) + Chr(13))
        Clipboard.Clear()
        Clipboard.SetText(Chr(10) + Chr(13) + Chr(10) + Chr(13))
        Me.unityrtfbox.Select(Me.unityrtfbox.Text.Length, 0)
        If Clipboard.GetData(DataFormats.Text) IsNot Nothing Then
            Me.unityrtfbox.Paste()
        End If
        unitydeph += 1
    End Function

    Private Sub unity_list_end()
        If unitydeph >= unitylist.Count Then
            unitylist.Add(0)
        End If
        unitylist(unitydeph) = 0
        unitydeph -= 1
    End Sub

    Private Sub fasse_zusammen_sub(ByRef Ablageinhalt As IDataObject)
        Try
            Dim a As New System.Security.Permissions.UIPermissionClipboard
            a = Permissions.UIPermissionClipboard.AllClipboard
            'If System.Security.Permissions.UIPermissionClipboard.NoClipboard <> Permissions.UIPermissionClipboard.NoClipboard Then
            'Try
            'Dim objekt As New Object=my.co
            unitylist = New List(Of Integer)
            unitydeph = 0
            Me.Inhalt.Text = ""
            Me.unityrtfbox = New RichTextBox
            'Me.unityrtfbox2 = New RichTextBox
            Me.unityrtfbox.Text = ""
            'Me.unityrtfbox2.Text = ""
            Dim nodi As TreeNode
            If TypeOf Me.Baum.SelectedNode Is TreeNode Then
                nodi = Me.Baum.SelectedNode
            Else
                nodi = Me.Baum.topnode
            End If
            Ablageinhalt = Clipboard.GetDataObject
            Clipboard.Clear()
            'If Not nodi.FirstNode Is Nothing Then
            Try
                Me.Baum.allnodes(nodi, AddressOf unity_list_begin, AddressOf unity_list_end, nodi)
                Me.Baum.allnodes(nodi, AddressOf nix2, AddressOf nix, nodi)
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fasse_zusammen()
        Try
            Dim Ablageinhalt As IDataObject = Nothing
            fasse_zusammen_sub(Ablageinhalt)
            Inhalt.node_set(Me.Baum.topnode)
            Baum.SelectedNode = Me.Baum.topnode
            Baum.element_dazu()
            Me.Inhalt.Rtf = Me.unityrtfbox.Rtf
            Me.Inhalt.Copy()
            Me.Inhalt.rtf_to_node_to_desknote_and_have_changed()
            Me.unitydeph = 0
            Clipboard.Clear()
            Clipboard.SetDataObject(Ablageinhalt)
        Catch
        End Try
    End Sub
    Private Sub export_rtf_MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles export_rtf_MenuItem.Click
        export(1)
    End Sub
    Private Sub export_txt_MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles export_txt_MenuItem.Click
        export(0)
    End Sub
    Private Sub export_txt2_MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles export_txt2_MenuItem.Click
        export(2)
    End Sub

    Private Sub export(ByVal was As Integer)
        Try
            Dim Ablageinhalt As IDataObject = Nothing
            Baum.SelectedNode = Baum.topnode
            fasse_zusammen_sub(Ablageinhalt)
            With Baum.bkontext
                .SaveFileDialog1 = New SaveFileDialog
                If was = 1 Then .SaveFileDialog1.Filter = "rtf Files|*.rtf" _
                Else .SaveFileDialog1.Filter = "txt Files|*.txt"
                If was = 1 Then .SaveFileDialog1.DefaultExt = "*.rtf" _
                Else .SaveFileDialog1.DefaultExt = "*.txt"
                .SaveFileDialog1.InitialDirectory = odatei.Verzeichnis
                If was = 1 Then .SaveFileDialog1.FileName = "export.rtf" _
                Else .SaveFileDialog1.FileName = "export.txt"
                Dim bclick As DialogResult = .SaveFileDialog1.ShowDialog()
                If bclick = DialogResult.OK Then
                    Dim datenstrom As New System.IO.FileStream(.SaveFileDialog1.FileName, IO.FileMode.Create, IO.FileAccess.Write)
                    Dim schreiber As New System.IO.StreamWriter(datenstrom)
                    If was = 1 Then
                        schreiber.Write(Me.unityrtfbox.Rtf)
                    Else
                        Dim zeichen2(unityrtfbox.Text.Length) As Byte
                        Dim kette As String = ""
                        If was = 0 Then
                            zeichen2 = Encoding.Convert(System.Text.Encoding.Unicode, System.Text.Encoding.Default, Encoding.Unicode.GetBytes(unityrtfbox.Text))
                            For Each zeichen3 As Byte In zeichen2
                                If zeichen3 <> 10 Then
                                    kette += Chr(zeichen3)
                                Else
                                    kette += Chr(13) + Chr(10)
                                End If
                            Next
                        Else
                            kette = unityrtfbox.Text
                        End If
                        schreiber.Write(kette)
                    End If
                    schreiber.Close()
                End If
            End With
            Me.unitydeph = 0
            Clipboard.Clear()
            Clipboard.SetDataObject(Ablageinhalt)
            Me.unitylist.Clear()
            Me.unitylist = Nothing
            Me.unityrtfbox.Dispose()
        Catch
        End Try
    End Sub

    Private Sub einheit_node_MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles einheit_node_MenuItem.Click
        fasse_zusammen()
    End Sub

    Private Sub einheit_start_MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles einheit_start_MenuItem.Click
        Me.Baum.SelectedNode = Me.Baum.topnode
        Inhalt.node_set(Me.Baum.topnode)
        fasse_zusammen()
    End Sub

#End Region

#Region "changing windows"

    Private Sub Notizen_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        Me.Refresh()
    End Sub

    'Private Sub label1_set()
    '    Me.Label1.Text = Me.Text
    '    ' If Me.Label1.Width > Me.Width - 70 Then
    '    Me.Label1.MaximumSize = New Point(Me.Width - 70, Me.Label1.Height)
    '    'Else
    '    'Me.Label1.MaximumSize = New Point(0, 0)
    '    'End If
    '    If Me.Label1.Text.Substring(0, 7) = "Notizen" Then
    '        Me.Label1.Location = New Point(CInt((Me.Width - Me.Label1.Width) / 2), 10)
    '    Else
    '        Me.Label1.Location = New Point(37, 10)
    '    End If
    '    ''
    'End Sub

    Private Sub Notizen_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        'If Not mouseclickmovetogether_resize Then

        '    'Dim graphic As System.Windows.Forms.PaintEventArgs = e
        '    'label1_set()

        '    If Me.Text.Substring(0, 7) = "Notizen" Then
        '        'pseudolabel.Font = 
        '        'pseudolabel.Text = Me.Text
        '        e.Graphics.DrawString(Me.Text, New Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Pixel, 0), Brushes.Black, CInt(Me.Width / 2) - 86, 14)
        '        'pseudolabel.Dispose()
        '    Else
        '        e.Graphics.DrawString(Me.Text, New Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel, 0), Brushes.Black, 37, 18)
        '    End If
        '    e.Graphics.DrawImageUnscaledAndClipped(My.Resources.bb, New Rectangle(0, 0, 36, 40))
        '    e.Graphics.DrawImageUnscaledAndClipped(My.Resources.bb, New Rectangle(Me.Width - 36, 0, Me.Width, 40))

        '    Dim graphPath As New System.Drawing.Drawing2D.GraphicsPath
        '    For i As Integer = 0 To 26
        '        e.Graphics.FillRectangle(Brushes.Violet, 0, i, halbkreis(i), i + 1)
        '        e.Graphics.FillRectangle(Brushes.Violet, Me.Width - halbkreis(i), i, Me.Width, i + 1)
        '        e.Graphics.FillRectangle(Brushes.Violet, Me.Width - halbkreis(i), Me.Height - i, Me.Width, Me.Height - i + 1)
        '        e.Graphics.FillRectangle(Brushes.Violet, 0, Me.Height - i, halbkreis(i) - 1, Me.Height - i + 1)
        '    Next


        '    'graphic.Graphics.DrawLine(Pens.Black, 36, 26, Me.Width - 36, 26)
        '    e.Graphics.DrawLine(Pens.Black, 36, 0, 36, 40)
        '    e.Graphics.DrawLine(Pens.Black, Me.Width - 36, 0, Me.Width - 36, 40)
        '    e.Graphics.DrawLine(Pens.Black, 0, 40, 36, 40)
        '    e.Graphics.DrawLine(Pens.Black, Me.Width - 36, 40, Me.Width, 40)

        '    e.Graphics.DrawString("x", New Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel, 0), Brushes.Black, Me.Width - 30, 10)
        '    e.Graphics.DrawString("_", New Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel, 0), Brushes.Black, 10, 10)

        '    'Label1.Visible = True
        '    Me.ToolStripContainer2.Visible = True

        'End If
    End Sub
    Private Sub Notizen_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        'If Not mouseclickmovetogether_block Then
        '    If e.Location.Y < 40 And e.Button = Windows.Forms.MouseButtons.Left Then
        '        If e.Location.X > Me.Width - 36 Then
        '            'close()
        '            Me.WindowState = FormWindowState.Minimized
        '        ElseIf e.Location.X < 36 Then
        '            Me.WindowState = FormWindowState.Minimized
        '        Else
        '            load_vars_for_moving()
        '        End If
        '    Else
        '        load_vars_for_moving()
        '    End If
        'End If
    End Sub
    Private Sub Notizen_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'If Not mouseclickmovetogether_block Then
        '    mouse_inelement_move(e)

        '    If e.Location.Y > Me.Height - 40 Then
        '        If e.Location.X > Me.Width - 36 Then
        '            mouse_inelement_size_move2()
        '        Else
        '            mouse_inelement_place_move2()
        '        End If
        '    ElseIf e.Location.Y < 40 Then
        '        If e.Location.X > Me.Width - 36 Then
        '            Cursor.Current = Cursors.PanSouth
        '        ElseIf e.Location.X < 36 Then
        '            Cursor.Current = Cursors.PanSouth
        '        Else
        '            mouse_inelement_place_move2()
        '        End If
        '    Else
        '        mouse_inelement_place_move2()
        '    End If
        'End If
    End Sub
    Private Sub Notizen_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        'allmouseup()
    End Sub
    Private Sub mouse_inelement_size_move2()
        'Cursor.Current = Cursors.SizeNWSE
        'If MouseButtons = Windows.Forms.MouseButtons.Left Then
        '    mouseclickmovetogether_resize = True
        '    'Label1.Visible = False
        '    Me.ToolStripContainer2.Visible = False
        'End If

    End Sub
    Private Sub mouse_inelement_place_move2()
        'Cursor.Current = Cursors.SizeAll
        'If MouseButtons = Windows.Forms.MouseButtons.Left Then
        '    '    x = Me.MousePosition.X - Me.Location.X
        '    '    y = Me.MousePosition.Y - Me.Location.Y
        '    mouseclickmovetogether_place = True
        'End If
    End Sub
    Private Sub mouse_inelement_move(ByVal e As System.Windows.Forms.MouseEventArgs)

        'If mouseclickmovetogether_resize Then
        '    Me.Size = New Point(MousePosition.X - Me.Location.X, MousePosition.Y - Me.Location.Y)
        'ElseIf mouseclickmovetogether_place Then
        '    Me.Location = New Point(MousePosition.X - inmove_location_xdiff_was, MousePosition.Y - inmove_location_ydiff_was)
        'End If
    End Sub

    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'If Not mouseclickmovetogether_block Then
        '    load_vars_for_moving()
        'End If
    End Sub
    Private Sub Label1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'If Not mouseclickmovetogether_block Then
        '    mouse_inelement_move(e)
        '    mouse_inelement_place_move2()
        'End If
    End Sub
    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'mouseclickmovetogether_resize = False
        'mouseclickmovetogether_place = False
        'Me.Refresh()
    End Sub
    Private Sub Notizen_deaktiviert(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If Me.WindowState = FormWindowState.Minimized Then
            If ShowInTaskbar = False Then
                Me.Visible = False
            End If
        End If
    End Sub


    Public Sub create_desknode(ByRef window As Rectangle, ByRef knoten As TreeNode, ByVal transparenz As Double, ByVal farbe As Color)

        Dim desknote As desknote = create_desknode_not_show(window, knoten, transparenz, farbe)
        If Not desknote Is Nothing Then desknote.show2()
        Me.have_changed_file()
    End Sub

    Sub fonts_insert()
        Me.ToolStripContainer2.Visible = False
        Dim fontfam As FontFamily
        'Me.ToolStrip_fonts.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {item})
        For Each fontfam In fonts.Families
            Dim item As New ToolStripMenuItem
            item.Text = fontfam.Name
            Me.ToolStrip_fonts.DropDownItems.Add(item)
        Next
        fonts_loaded = True
        Me.ToolStripContainer2.Visible = True
    End Sub

    Private Sub TrayIcon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrayIcon.Click
        If MouseButtons = Windows.Forms.MouseButtons.Right Then Me.TrayIcon.ContextMenuStrip.Show() Else Me.Activate()
    End Sub
    Public Sub change_win_state()
        'Form anzeigen, falls sie minimiert ist: 
        'ShowInTaskbar = False
        If WindowState = FormWindowState.Minimized Or Visible = False Then

            Me.Visible = True
            If norm0_or_max1 Then
                Me.WindowState = FormWindowState.Maximized
            Else
                Me.WindowState = FormWindowState.Normal

            End If
        Else


            If ShowInTaskbar = False Then
                Visible = False
            Else
                WindowState = FormWindowState.Minimized
            End If
        End If
    End Sub
    Private Sub TrayIcon_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrayIcon.DoubleClick
        change_win_state()
    End Sub
    Private Sub Notizen_Location(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        If Me.WindowState = FormWindowState.Normal Then
            norm0_or_max1 = False
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            norm0_or_max1 = True
        End If
    End Sub
    'Private Sub resize_splitter_part()
    '    Baum.Size = New Size(SplitContainer1.Panel1.Width - 3, SplitContainer1.Height - txt1.Size.Height - 3)
    '    txt1.Size = New Size(Baum.Width - 1, txt1.Size.Height)
    '    Inhalt.Size = New Size(SplitContainer1.Panel2.Width - 3, SplitContainer1.Height - txt2.Size.Height - 3)
    '    txt2.Size = New Size(Inhalt.Width, txt2.Size.Height)
    'End Sub
    'Private Sub resize2()
    '    'SplitContainer1.Size = New Point(ToolStripContainer2.ContentPanel.Width - 3 - 10, ToolStripContainer2.ContentPanel.Height - 6 - 10)
    '    resize_splitter_part()
    'End Sub
    'Private Sub Notizen_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    resize2()
    'End Sub
    'Private Sub SplitContainer1_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
    '    resize_splitter_part()
    'End Sub
    'Private Sub make_size_better()
    '    If SplitContainer1.Height <> ToolStripContainer2.ContentPanel.Height - 6 Or SplitContainer1.Width <> ToolStripContainer2.ContentPanel.Width - 3 Then
    '        resize2()
    '    End If
    'End Sub
    'Private Sub ToolStrip1_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip1.LocationChanged
    '    make_size_better()
    'End Sub
    'Private Sub ToolStrip2_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    make_size_better()
    'End Sub
    'Private Sub ToolStrip3_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip3.LocationChanged
    '    make_size_better()
    'End Sub
    'Private Sub ToolStrip4_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip4.LocationChanged
    '    make_size_better()
    'End Sub
    'Private Sub ToolStrip5_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip5.LocationChanged
    '    make_size_better()
    'End Sub
    'Private Sub ToolStrip6_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip_fontstyle.LocationChanged
    '    make_size_better()
    'End Sub

#End Region
#Region "Dialog_Fonts"

    Private Sub ToolStripLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_bold.Click
        font_set(FontStyle.Bold, fontsettings.style, "")
    End Sub

    Private Sub ToolStripLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_italic.Click
        font_set(FontStyle.Italic, fontsettings.style, "")
    End Sub

    Private Sub ToolStripLabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_underline.Click
        font_set(FontStyle.Underline, fontsettings.style, "")
    End Sub

    Private Sub ToolStripLabel7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_regular.Click
        font_set(FontStyle.Regular, fontsettings.style, "")
    End Sub

    Private Sub ToolStripLabel8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_strikeout.Click
        font_set(FontStyle.Strikeout, fontsettings.style, "")
    End Sub

    Private Sub ToolStripLabel5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_bigger.Click
        font_set(FontStyle.Regular, fontsettings.size_bigger, "")
    End Sub

    Private Sub ToolStripLabel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_smaller.Click
        font_set(FontStyle.Regular, fontsettings.size_smaller, "")
    End Sub

    Private Function node_font(ByRef node As TreeNode) As Boolean
        node.NodeFont = New Font(fontfam, 10)
    End Function
    Private Function node_font_style(ByRef node As TreeNode) As Boolean
        node.NodeFont = New Font(fontfam, 10, fontstil)
    End Function



    Sub font_set(ByVal stil As FontStyle, ByVal funktion As fontsettings, ByVal fontfam2 As String, Optional ByVal newfontsize As Int16 = 0)
        If TypeOf Baum.topnode Is TreeNode Then

            Dim von As Integer = Inhalt.SelectionStart
            Dim von2 As Integer = von
            Dim lenght As Integer = Inhalt.SelectionLength
            Dim i As Integer
            If lenght = 0 Then
                von = 0
                lenght = Inhalt.Text.Length
                Inhalt.SelectAll()
            End If
            Try
                If Not Me.focus_was = formenum.baum Or funktion = fontsettings.family Then
                    Inhalt.Visible = False
                    For i = von To von + lenght - 1
                        Inhalt.Select(i, 1)
                        Select Case funktion
                            Case fontsettings.style
                                Inhalt.SelectionFont = New Font(Inhalt.SelectionFont, stil)
                            Case fontsettings.size_bigger
                                If Inhalt.SelectionFont.Size < 100 Then
                                    Inhalt.SelectionFont = New Font(Inhalt.SelectionFont.FontFamily, Inhalt.SelectionFont.Size + 1, Inhalt.SelectionFont.Style)
                                End If
                            Case fontsettings.size_smaller
                                If Inhalt.SelectionFont.Size > 8 Then
                                    Inhalt.SelectionFont = New Font(Inhalt.SelectionFont.FontFamily, Inhalt.SelectionFont.Size - 1, Inhalt.SelectionFont.Style)
                                End If
                            Case fontsettings.family
                                Inhalt.SelectionFont = New Font(fontfam2, Inhalt.SelectionFont.Size, Inhalt.SelectionFont.Style)
                            Case fontsettings.setsize
                                Inhalt.SelectionFont = New Font(Inhalt.SelectionFont.FontFamily, newfontsize, Inhalt.SelectionFont.Style)
                        End Select
                    Next
                    Inhalt.Visible = True
                Else
                    Select Case funktion
                        Case fontsettings.family
                            'Inhalt.SelectionFont = New Font(fontfam2, Inhalt.SelectionFont.Size, Inhalt.SelectionFont.Style)
                            '    fontfam = fontfam2
                            '    Me.Baum.allnodes(Me.Baum.TopNode, AddressOf node_font, AddressOf nix, Me.Baum.TopNode)
                        Case fontsettings.style
                            fontstil = stil
                            Me.Baum.allnodes(Me.Baum.topnode, AddressOf node_font_style, AddressOf nix, Me.Baum.topnode)
                            Me.Baum.allnodes(Me.Baum.topnode, AddressOf nix2, AddressOf nix, Me.Baum.topnode)
                    End Select
                    Baum.LabelEdit = True
                    Me.Baum.topnode.BeginEdit()
                    Me.Baum.topnode.EndEdit(True)
                    Baum.LabelEdit = False
                End If
            Catch ex As Exception
            End Try
            If Inhalt.Text.Length = lenght Then
                Inhalt.Select(von2, 0)
            Else
                Inhalt.Select(von2, lenght)
            End If
            Me.Inhalt.rtf_to_node_to_desknote_and_have_changed()

        End If
        If Not Inhalt.SelectionFont Is Nothing And Not ToolStrip_fontsizenumber Is Nothing Then
            ToolStrip_fontsizenumber.Text = Inhalt.SelectionFont.Size.ToString
        End If
    End Sub




    Private Sub ToolStrip_fonts_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip_fonts.DropDownItemClicked
        font_set(FontStyle.Regular, fontsettings.family, e.ClickedItem.Text)
    End Sub

    Public Sub cut_anything(ByVal a As Boolean)

        If Inhalt.Focused = True Then
            If a Then : Me.Inhalt.Cut() : End If
            Me.have_changed_file()
            Inhalt.rtf_to_node_to_desknote_and_have_changed()
        ElseIf Baum.Focused = True Then
            If Not Baum.SelectedNode Is Nothing Then
                copy_node()
                Baum.element_loeschen()
                have_changed_file()
            End If
        End If
    End Sub


    Private Sub AusschneidenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AusschneidenToolStripButton.Click
        cut_anything(True)
    End Sub

    Private Function kopiere_knoten(ByRef knoten As TreeNode) As Boolean
        Me.onode.Nodes.Add(knoten.Text)
        Me.onode = Me.onode.LastNode
        Me.onode.Tag = New CText
        Me.onode.Tag.text = knoten.Tag.text
    End Function

    Private Function fuege_ein_knoten(ByRef knoten As TreeNode) As Boolean

        anode.Nodes.Add(knoten.Text)
        anode = anode.LastNode
        anode.Tag = New CText
        anode.Tag.text = knoten.Tag.text

    End Function

    Private Sub kopiere_knoten2()
        Me.onode = Me.onode.Parent
    End Sub

    Private Sub fuege_ein_knoten2()
        anode = anode.Parent
    End Sub


    Public Sub copy_node()
        If Not Baum.SelectedNode Is Nothing Then
            Dim for_selected_node As TreeNode = Baum.SelectedNode
            Me.onode = New TreeNode
            Me.Baum.allnodes(Baum.SelectedNode, AddressOf kopiere_knoten, AddressOf kopiere_knoten2, Baum.SelectedNode)
            Me.onode = Me.onode.FirstNode
            Me.Baum.allnodes(Baum.SelectedNode, AddressOf nix2, AddressOf nix, Baum.SelectedNode)

            Baum.SelectedNode = for_selected_node
        End If
    End Sub

    Private Sub KopierenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KopierenToolStripButton.Click
        If Inhalt.Focused = True Then
            Me.Inhalt.Copy()
        ElseIf Baum.Focused = True Then
            copy_node()
        End If
    End Sub

    Public Sub paste_anything(ByVal a As Boolean)
        If Inhalt.Focused = True Then
            If a Then : Inhalt.Paste() : End If
            Me.have_changed_file()
            Inhalt.rtf_to_node_to_desknote_and_have_changed()
        ElseIf Baum.Focused = True Then
            If (Not Baum.SelectedNode Is Nothing) And (Not onode Is Nothing) Then
                anode = New TreeNode
                'Dim anode2 As TreeNode = anode
                'If onode.FirstNode IsNot Nothing Then
                Me.Baum.allnodes(onode, AddressOf nix2, AddressOf nix, onode)
                Me.Baum.allnodes(onode, AddressOf fuege_ein_knoten, AddressOf fuege_ein_knoten2, onode)
                'Else
                '    anode.Nodes.Add(onode.Text)
                '    anode = anode.LastNode
                '    anode.Tag = New CText
                '    anode.Tag.text = onode.Tag.text
                '    anode = 
                'End If
                'anode = anode2
                'MsgBox(anode.Nodes.Count)
                If Baum.SelectedNode Is Baum.topnode Then
                    Me.Baum.SelectedNode.Nodes.Insert(Me.Baum.SelectedNode.Index, anode.FirstNode)
                    'ElseIf anode.FirstNode Is Nothing Then
                    '    Me.Baum.SelectedNode.Parent.Nodes.Insert(Me.Baum.SelectedNode.Index, anode)
                Else
                    Me.Baum.SelectedNode.Parent.Nodes.Insert(Me.Baum.SelectedNode.Index, anode.FirstNode)
                End If
                have_changed_file()
            End If
        End If
    End Sub

    Private Sub EinfuegenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EinfuegenToolStripButton.Click
        paste_anything(True)
    End Sub

#End Region
    Public Function get_lightcolor() As Color
        Dim zufall_macher As New Random()
        Dim zufallszahl As Int16 = zufall_macher.Next(0, 14)
        Select Case zufallszahl
            Case 0
                get_lightcolor = Color.LightCoral
            Case 1
                get_lightcolor = Color.LightCyan
            Case 2
                get_lightcolor = Color.LightGreen
            Case 3
                get_lightcolor = Color.LightSkyBlue
            Case 4
                get_lightcolor = Color.LightYellow
            Case 5
                get_lightcolor = Color.LightSteelBlue
            Case 6
                get_lightcolor = Color.LightSalmon
            Case 7
                get_lightcolor = Color.LightGoldenrodYellow
            Case 8
                get_lightcolor = Color.LightBlue
            Case 9
                get_lightcolor = Color.SkyBlue
            Case 10
                get_lightcolor = Color.Yellow
            Case 11
                get_lightcolor = Color.White
            Case 12
                get_lightcolor = Color.GreenYellow
            Case 13
                get_lightcolor = Color.Cyan
            Case 14
                get_lightcolor = Color.Magenta
            Case Else
                get_lightcolor = Color.LightGray
        End Select

    End Function

    Private Sub is_element2(ByVal XMLReader As Xml.XmlReader)
        With XMLReader
            If Not TypeOf (Baum.topnode) Is TreeNode Then
                Baum.Nodes.Add(.GetAttribute("title"))
                Baum.SelectedNode = Baum.topnode
            Else
                Baum.SelectedNode.Nodes.Add(.GetAttribute("title"))
                'Baum.SelectedNode = Baum.SelectedNode.LastNode
            End If
            If TypeOf Baum.SelectedNode Is TreeNode Then
                'Baum.SelectedNode.Expand()
                If TypeOf Baum.SelectedNode.LastNode Is TreeNode Then
                    If Not TypeOf Baum.SelectedNode.LastNode.Tag Is CText Then
                        Baum.SelectedNode.LastNode.Tag = New CText
                    End If
                    If Not .IsEmptyElement Then
                        Baum.SelectedNode = Baum.SelectedNode.LastNode
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub is_element(ByVal XMLReader As Xml.XmlReader)
        With XMLReader
            If .GetAttribute("x") <> "" Then

                window_haft.X = CInt(.GetAttribute("x"))
                window_haft.Y = CInt(.GetAttribute("y"))
                window_haft.Width = CInt(.GetAttribute("width"))
                window_haft.Height = CInt(.GetAttribute("height"))
                'If .GetAttribute("visible") = "True" Then
                '    Me.sichtbar = True
                'Else
                '    Me.sichtbar = False
                'End If
                Try
                    Me.transparency_haftnotizen = CDbl(.GetAttribute("opacity"))
                    Me.farbe_haftnotizen = Color.FromArgb(CInt(.GetAttribute("argb")))
                Catch ex As Exception
                    transparency_haftnotizen = 0.85
                    farbe_haftnotizen = get_lightcolor()
                End Try
                haft = True
            Else

                haft = False
            End If
            Try
                Me.isexpanded = CBool(.GetAttribute("isexpanded"))
            Catch
                Me.isexpanded = True
            End Try

            If Not TypeOf (Baum.topnode) Is TreeNode Then
                Baum.Nodes.Add(.GetAttribute("name"))
                Baum.SelectedNode = Baum.topnode
                Baum.SelectedNode.Tag = New CText
                Baum.SelectedNode.Tag.shall_expand = isexpanded
                'Baum.TopNode.Expand()
            Else
                Baum.SelectedNode.Nodes.Add(.GetAttribute("name"))
            End If

            'MsgBox(isexpanded.ToString)
            If TypeOf Baum.SelectedNode.LastNode Is TreeNode Then
                If .GetAttribute("bgcolor") <> "" Then
                    If .GetAttribute("bgcolor") <> "0" Then Baum.SelectedNode.LastNode.BackColor = Color.FromArgb(.GetAttribute("bgcolor"))
                    If .GetAttribute("fgcolor") <> "0" Then Baum.SelectedNode.LastNode.ForeColor = Color.FromArgb(.GetAttribute("fgcolor"))
                End If
                If Not TypeOf Baum.SelectedNode.LastNode.Tag Is CText Then
                    Baum.SelectedNode.LastNode.Tag = New CText
                    Baum.SelectedNode.LastNode.Tag.shall_expand = isexpanded

                End If
                If Not .IsEmptyElement Then
                    Baum.SelectedNode = Baum.SelectedNode.LastNode
                End If
            End If
        End With
    End Sub

    Private Sub is_endelement(ByVal XMLReader As Xml.XmlReader)
        If TypeOf Baum.SelectedNode Is TreeNode Then
            If Baum.SelectedNode.Tag.shall_expand Then
                Baum.SelectedNode.Expand()
            Else
                Baum.SelectedNode.Collapse()
            End If
            If TypeOf Baum.SelectedNode.Parent Is TreeNode Then
                Baum.SelectedNode = Baum.SelectedNode.Parent
            End If
        End If
    End Sub

    Private Sub is_text2(ByVal XMLReader As Xml.XmlReader)
        With XMLReader
            If TypeOf Baum.SelectedNode Is TreeNode Then
                If Not TypeOf Baum.SelectedNode.Tag Is CText Then
                    Baum.SelectedNode.Tag = New CText
                End If
                Inhalt.Text = ""
                Do While .Read
                    If Xml.XmlNodeType.Element And .Name = "p" And Not .IsEmptyElement Then
                        'Windows.Forms.MessageBox.Show(.Name, "test", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
                        '        .Read()
                        '    If Xml.XmlNodeType.Text Then
                        .Read()
                        'Windows.Forms.MessageBox.Show(.ReadContentAsString, "test", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
                        Inhalt.Text += .ReadContentAsString + Chr(13)
                        '.ReadElementContentAsString
                        '        'End If
                        '
                    ElseIf Xml.XmlNodeType.EndElement And (.Name = "node" Or .Name = "leaf") Then
                        Baum.SelectedNode.Tag.text = Inhalt.Rtf
                        Inhalt.Text = ""
                        is_endelement(XMLReader)
                        Exit Do
                    End If
                Loop
                'If Xml.XmlNodeType.Element = .NodeType Then
                '    is_element(XMLReader)
                'ElseIf Xml.XmlNodeType.EndElement = .NodeType Then
                '    is_endelement(XMLReader)
                'End If
            End If
        End With
    End Sub

    Private Sub is_text(ByVal XMLReader As Xml.XmlReader)
        With XMLReader
            If TypeOf Baum.SelectedNode Is TreeNode Then
                If Not TypeOf Baum.SelectedNode.Tag Is CText Then
                    Baum.SelectedNode.Tag = New CText
                End If
                Baum.SelectedNode.Tag.text = .ReadContentAsString
                'If TypeOf Baum.SelectedNode Is TreeNode Then
                '    If TypeOf Baum.SelectedNode.Tag Is CText Then
                '        Windows.Forms.MessageBox.Show(Baum.TopNode.Tag.Text, "test", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
                '    End If
                'End If
                If haft = True Then
                    'Windows.Forms.MessageBox.Show(Me.height.ToString, Me.width.ToString, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
                    create_desknode(window_haft, Baum.SelectedNode, Me.transparency_haftnotizen, Me.farbe_haftnotizen)
                End If
                If Xml.XmlNodeType.Element = .NodeType Then
                    is_element(XMLReader)
                ElseIf Xml.XmlNodeType.EndElement = .NodeType Then
                    is_endelement(XMLReader)
                End If
            End If
        End With
    End Sub
    Public Sub xmlread(ByRef XmlReader As Xml.XmlReader)
        With XmlReader
            .Read()
            .Read()
            If .Name = "notizen-alx2" Then
                Do While .Read ' Es sind noch Daten vorhanden 
                    Select Case .NodeType
                        Case Xml.XmlNodeType.Element And .Name = "Notiz"
                            is_element(XmlReader)
                        Case Xml.XmlNodeType.Text
                            is_text(XmlReader)
                        Case Xml.XmlNodeType.EndElement
                            is_endelement(XmlReader)
                    End Select

                Loop  ' Weiter nach Daten schauen 
                .Close()  ' XMLTextReader schließen 
            Else
                .Read()
                If .Name = "notes_doc" Then
                    Do While .Read ' Es sind noch Daten vorhanden 
                        Select Case .NodeType
                            Case Xml.XmlNodeType.Element And (.Name = "node" Or .Name = "leaf")
                                is_element2(XmlReader)
                            Case Xml.XmlNodeType.Element And .Name = "leaf_text"
                                is_text2(XmlReader)
                            Case Xml.XmlNodeType.EndElement And (.Name = "node" Or .Name = "leaf")
                                is_endelement(XmlReader)
                        End Select

                    Loop  ' Weiter nach Daten schauen 
                    .Close()  ' XMLTextReader schließen 
                End If
            End If
            'Notizen.Inhalt.Rtf = Notizen.Baum.TopNode.Tag.text
            'Notizen.Baum.SelectedNode = Notizen.Baum.TopNode
        End With
    End Sub

    Public Function CreateShortcut(ByVal sLinkFile As String, ByVal sTargetFile As String, _
  Optional ByVal sArguments As String = "", Optional ByVal sDescription As String = "", _
  Optional ByVal sWorkingDir As String = "") As Boolean
        Try
            '        MsgBox(FileIO.FileSystem.DirectoryExists(Environment.GetFolderPath(Environment.SpecialFolder.Startup)))
            Dim oShell As New Shell32.Shell
            Dim oFolder As Shell32.Folder
            Dim oLink As Shell32.ShellLinkObject

            ' Ordner und Dateinamen extrahieren
            Dim sPath As String = sLinkFile.Substring(0, sLinkFile.LastIndexOf("\"))
            Dim sFile As String = sLinkFile.Substring(sLinkFile.LastIndexOf("\") + 1)

            ' Wichtig! Link-Datei erstellen (0 Bytes)
            Dim F As Short = FreeFile()

            FileOpen(F, sLinkFile, OpenMode.Output)
            FileClose(F)

            oFolder = oShell.NameSpace(sPath)
            oLink = oFolder.Items.Item(sFile).GetLink

            ' Eigenschaften der Verknüpfung
            With oLink
                If sArguments.Length > 0 Then .Arguments = sArguments
                If sDescription.Length > 0 Then .Description = sDescription
                If sWorkingDir.Length > 0 Then .WorkingDirectory = sWorkingDir
                .Path = sTargetFile
                ' Verknüpfung speichern
                .Save()
            End With

            ' Objekte zerstören
            oLink = Nothing
            oFolder = Nothing
            oShell = Nothing
            Return True
        Catch ex As Exception
            ' Fehler! ggf. Link-Datei löschen, falls bereit erstellt
            If System.IO.File.Exists(sLinkFile) Then Kill(sLinkFile)
            'MsgBox("Shortcut could not be created.")
            xml_kram.doc.Item("notizen-alx").Item("autorun").SetAttribute("if", "no")
            xml_kram.save()

            Return False
        End Try
    End Function

#Region "Save-As-XML"

    Private Function tostringfuehrnull(ByRef zahl As Int16) As String
        If zahl < 10 Then
            Return "0" + zahl.ToString
        Else
            Return zahl.ToString
        End If
    End Function

    Private Function speichern_streams(Optional ByRef ftpurl As String = "") As Boolean
        'Me.Baum, odatei.SaveName

        If ftpurl = "" And My.Computer.FileSystem.FileExists(odatei.Verzeichnis + "\" + odatei.SaveName) And IsNumeric(xml_kram.doc.Item("notizen-alx").Item("saftycopies").Attributes("amount").Value) And Not xml_kram.doc.Item("notizen-alx").Item("saftycopies").Attributes("amount").Value = "0" And ftpurl = "" Then
            Dim sicherungsort = odatei.Verzeichnis + "\" + odatei.SaveName.Substring(0, odatei.SaveName.Length - 4)
            If Not My.Computer.FileSystem.DirectoryExists(sicherungsort) Then
                Try
                    My.Computer.FileSystem.CreateDirectory(sicherungsort)
                Catch ex As Exception
                    MsgBox("error, when trying to create a directory for backups: " + ex.Message)
                End Try
            End If
            Dim sicherungsdatei = odatei.Verzeichnis + "\" + odatei.SaveName
            Dim sicherung = sicherungsort + "\" + odatei.SaveName.Substring(0, odatei.SaveName.Length - 4) + "-" + _
                Date.Now.Year.ToString + "-" + tostringfuehrnull(Date.Now.Month) + "-" + _
                tostringfuehrnull(Date.Now.Day.ToString) + "-" + tostringfuehrnull(Date.Now.Hour) + "-" + _
                tostringfuehrnull(Date.Now.Minute) + "-" + tostringfuehrnull(Date.Now.Second) + "-" + _
                Date.Now.Millisecond.ToString + ".alx"
            If Not My.Computer.FileSystem.FileExists(sicherung) Then
                Try
                    My.Computer.FileSystem.CopyFile(sicherungsdatei, sicherung)
                Catch ex As Exception
                    MsgBox("error, when trying to make a copy of the original file: " + ex.Message)
                End Try
                'Inhalt.Text = sicherung
            End If

            Dim sicherungen As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(sicherungsort)
            Dim dalassen As Int16 = xml_kram.doc.Item("notizen-alx").Item("saftycopies").Attributes("amount").Value
            Dim alxdateienliste As New List(Of String)
            If sicherungen.Count - dalassen > 0 Then
                For Each element As String In sicherungen
                    If element.Substring(element.Length - 4, 4) = ".alx" And element.Contains(odatei.SaveName.Substring(0, odatei.SaveName.Length - 4)) Then
                        alxdateienliste.Add(element)
                    End If
                Next
                Dim i As Int16 = 0
                For i = 0 To alxdateienliste.Count - 1 - dalassen
                    My.Computer.FileSystem.DeleteFile(alxdateienliste(i))
                Next
            End If
        End If
        Dim requestStream As Stream = Nothing
        Dim fileStream As FileStream = Nothing
        Dim uploadResponse As FtpWebResponse = Nothing
        Dim cryptostream1 As CryptoStream = Nothing
        Dim cryptostream2 As CryptoStream = Nothing
        Dim cryptostream3 As CryptoStream = Nothing
        Dim kompr_stream As GZipStream = Nothing
        Dim datei_speicher_stream As Stream = Nothing
        Dim uploadRequest As FtpWebRequest = Nothing
        'Dim fileName As String
        Dim uploadUrl As String
        Try
            Me.passwort_bearbeite()
            ' For additional security, pin the key.

            If ftpurl = "" Then
                datei_speicher_stream = New FileStream(odatei.Verzeichnis + "\" + odatei.SaveName, FileMode.Create, FileAccess.Write)
            Else
                'Dim uploadUrl As String = ftpurl.Substring(0, ftpurl.LastIndexOf("/"))
                'If "/" = ftpurl.Chars(ftpurl.LastIndexOf("/") - 1) Then
                '    uploadUrl += "/"
                'End If
                'fileName = ftpurl.Substring(ftpurl.LastIndexOf("/") + 1)
                uploadUrl = ftpurl
                'MsgBox(uploadUrl)
                'MsgBox(fileName)
                uploadRequest = WebRequest.Create(uploadUrl)
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile
                uploadRequest.Proxy = Nothing
                datei_speicher_stream = uploadRequest.GetRequestStream()
            End If


            Dim DES1 As New DESCryptoServiceProvider()
            DES1.Key = ASCIIEncoding.ASCII.GetBytes(p.Substring(0, 8))
            DES1.IV = ASCIIEncoding.ASCII.GetBytes(p.Substring(0, 8))
            Dim DES2 As New DESCryptoServiceProvider()
            DES2.Key = ASCIIEncoding.ASCII.GetBytes(p.Substring(7, 8))
            DES2.IV = ASCIIEncoding.ASCII.GetBytes(p.Substring(7, 8))
            Dim DES3 As New DESCryptoServiceProvider()
            DES3.Key = ASCIIEncoding.ASCII.GetBytes(p.Substring(15, 8))
            DES3.IV = ASCIIEncoding.ASCII.GetBytes(p.Substring(15, 8))
            cryptostream1 = New CryptoStream(datei_speicher_stream, DES1.CreateEncryptor(), CryptoStreamMode.Write)
            cryptostream2 = New CryptoStream(cryptostream1, DES2.CreateEncryptor(), CryptoStreamMode.Write)
            cryptostream3 = New CryptoStream(cryptostream2, DES3.CreateEncryptor(), CryptoStreamMode.Write)


            If p.Length <> 24 Or p = "                        " Then
                kompr_stream = New GZipStream(datei_speicher_stream, CompressionMode.Compress)
            Else
                kompr_stream = New GZipStream(cryptostream3, CompressionMode.Compress)
            End If


            'kompr_stream.Write(Buffer, 0, Buffer.Length)

            xml_schreib_stream = New Xml.XmlTextWriter(kompr_stream, New System.Text.UnicodeEncoding)

            'odatei.SaveName, New System.Text.UnicodeEncoding)

            xml_schreib_stream.WriteStartDocument()
            xml_schreib_stream.WriteStartElement("notizen-alx2")
            'Baum.SelectedNode = Me.Baum.TopNode

            Baum.allnodes(Me.Baum.topnode, AddressOf schreib_element_anfang, AddressOf schreib_element_ende, Me.Baum.topnode)
            Baum.allnodes(Me.Baum.topnode, AddressOf nix2, AddressOf nix, Me.Baum.topnode)
            xml_schreib_stream.WriteEndElement()
            If ftpurl <> "" Then
                If requestStream IsNot Nothing Then requestStream.Close()
                'If uploadRequest IsNot Nothing Then uploadResponse = uploadRequest.GetResponse()
            End If

            ' Remove the key from memory. 

        Catch ex As Exception
            MsgBox(ex.Message)
            error_with_file = True
        Finally
            If xml_schreib_stream IsNot Nothing Then xml_schreib_stream.Close()
            If kompr_stream IsNot Nothing Then kompr_stream.Close()
            If p.Length = 24 And p <> "                        " Then
                If cryptostream3 IsNot Nothing Then cryptostream3.Close()
                If cryptostream2 IsNot Nothing Then cryptostream2.Close()
                If cryptostream1 IsNot Nothing Then cryptostream1.Close()
                If uploadResponse IsNot Nothing Then
                    uploadResponse.Close()
                End If
                If fileStream IsNot Nothing Then
                    fileStream.Close()
                End If
                If requestStream IsNot Nothing Then
                    requestStream.Close()
                End If
                If datei_speicher_stream IsNot Nothing Then
                    datei_speicher_stream.Close()
                End If
            End If
        End Try
    End Function

    Private Function schreib_element_anfang(ByRef knoten As TreeNode) As Boolean
        xml_schreib_stream.WriteStartElement("Notiz")
        xml_schreib_stream.WriteAttributeString("name", knoten.Text)
        xml_schreib_stream.WriteAttributeString("isexpanded", knoten.IsExpanded.ToString)
        xml_schreib_stream.WriteAttributeString("bgcolor", knoten.BackColor.ToArgb.ToString)
        xml_schreib_stream.WriteAttributeString("fgcolor", knoten.ForeColor.ToArgb.ToString)
        'MsgBox(knoten.Text)
        If Not knoten.Tag.desknote Is Nothing Then
            'Me.Haft(Baum.SelectedNode.Tag.ext_id - 1).RichTextBox1.Rtf = inhalt.Rtf

            'Windows.Forms.MessageBox.Show((knoten.Tag.ext_id - 1).ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)

            If Not knoten.Tag.desknote.WindowState = FormWindowState.Minimized Then
                xml_schreib_stream.WriteAttributeString("visible", knoten.Tag.desknote.Visible.ToString)
                xml_schreib_stream.WriteAttributeString("x", knoten.Tag.desknote.window.x.ToString)
                xml_schreib_stream.WriteAttributeString("y", knoten.Tag.desknote.window.y.ToString)
                xml_schreib_stream.WriteAttributeString("width", knoten.Tag.desknote.window.width.ToString)
                xml_schreib_stream.WriteAttributeString("height", knoten.Tag.desknote.window.height.ToString)
                xml_schreib_stream.WriteAttributeString("opacity", knoten.Tag.desknote.Opacity.ToString)
                xml_schreib_stream.WriteAttributeString("argb", knoten.Tag.desknote.RichTextBox1.BackColor.ToArgb.ToString)
                'ext_id
            End If
        End If
        xml_schreib_stream.WriteString(Baum.fuelle(knoten))
        Return True
    End Function

    Private Sub schreib_element_ende()
        xml_schreib_stream.WriteEndElement()
    End Sub



    Private Sub nix()
    End Sub

    Private Function nix2(ByRef knoten As TreeNode) As Boolean
        Return True
    End Function



    Public Sub suche_alle()
        MyBase.Select()
        Baum.Select()
        Baum.Update()
        'Notizen.Baum.SelectedNode = Notizen.Baum.TopNode
        System.Threading.Thread.Sleep(200)
        Baum.allnodes(Baum.topnode, AddressOf suche.such_pro_knoten, AddressOf nix, Baum.topnode)
        Baum.allnodes(Baum.topnode, AddressOf nix2, AddressOf nix, Baum.topnode)
        MyBase.Select()
        Inhalt.Select()
    End Sub
#End Region

    Private Sub Notizen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If xml_kram.doc.Item("notizen-alx").Item("desknotes").Attributes("show_desknote_borders").Value = "yes" Then
            showdesknoteborders = True
        Else
            showdesknoteborders = False
        End If
        If My.Application.start_arguemnts.file <> "" Then
            If My.Application.start_arguemnts.file.Substring(0, 6) = "ftp://" Then
                Me.Invoke(New oeffne_datei_delegate2(AddressOf oeffne_datei), New Object() {"", My.Application.start_arguemnts.file})
            Else
                System.IO.Directory.SetCurrentDirectory(My.Application.start_arguemnts.file.Substring(0, My.Application.start_arguemnts.file.LastIndexOf("\")))
                Me.Invoke(New oeffne_datei_delegate(AddressOf oeffne_datei), New Object() {My.Application.start_arguemnts.file})
            End If
            My.Application.start_arguemnts.file = ""
        Else
            new_topnode()
        End If
    End Sub

    Private Sub infoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles infoToolStripMenuItem.Click
        'Windows.Forms.MessageBox.Show("Autor: Alexander Kern" + Chr(13) + "Kontakt: notizen@goexchange.de" + Chr(13) + "web: http://www.goexchange.de/notizen/", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
        aboutbox = New info_help_and_feedback
        aboutbox.Show()
        aboutbox.Activate()
    End Sub

    Private Sub load_vars_for_moving()
        mouseclickmovetogether_place = True
        inmove_y = MousePosition.Y
        inmove_x = MousePosition.X
        inmove_location_xdiff_was = MousePosition.X - Me.Location.X
        inmove_location_ydiff_was = MousePosition.Y - Me.Location.Y
    End Sub


    Private Sub ToolStrip_dot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip_dot.Click
        'If System.Security.Permissions.UIPermissionClipboard.NoClipboard <> Permissions.UIPermissionClipboard.NoClipboard Then
        Try
            Dim a As New System.Security.Permissions.UIPermissionClipboard
            a = Permissions.UIPermissionClipboard.AllClipboard
            Dim Ablageinhalt As IDataObject = Clipboard.GetDataObject
            Clipboard.Clear()
            Try
                Clipboard.SetText(Chr(13) + ChrW(8226) + "   ")
                'Clipboard.SetData(DataFormats.Text, Chr(13) + ChrW(8226) + "   ")
                Inhalt.Paste()
            Catch ex As Exception
            End Try
            Clipboard.Clear()
            Clipboard.SetDataObject(Ablageinhalt)
        Catch ex As Exception
        End Try
        'End If
        Inhalt.rtf_to_node_to_desknote_and_have_changed()
    End Sub

    Private Sub passwortToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles passwortToolStripMenuItem.Click
        Me.passwort_dialog = New passwort_dialog()
        passwort_dialog.Text = lang_pointer(lang_keys.strip1_21)
        passwort_dialog.lb_alt.Text = lang_pointer(lang_keys.pass1)
        passwort_dialog.lb_neu1.Text = lang_pointer(lang_keys.pass2)
        passwort_dialog.lb_neu2.Text = lang_pointer(lang_keys.pass3)
        passwort_dialog.fehler1 = lang_pointer(lang_keys.passerror1)
        passwort_dialog.fehler2 = lang_pointer(lang_keys.passerror2)
        passwort_dialog.fehler3 = lang_pointer(lang_keys.passerror3)
        passwort_dialog.lb_unten.Text = lang_pointer(lang_keys.pw_unten_info)
        Me.passwort_dialog.Show()
        Me.have_changed_file()
    End Sub
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Inhalt.Select()
        'Dim vari As String
        'For Each vari In Clipboard.GetDataObject.GetFormats(False)
        '    MsgBox(vari)
        'Next
        If Not Clipboard.GetImage Is Nothing Then
            Clipboard.Clear()
            Clipboard.SetImage(Clipboard.GetImage)
        End If

        'Clipboard.SetImage(Clipboard.GetImage)
        Inhalt.Paste()
    End Sub
    'Private Sub allmouseup()
    '    mouseclickmovetogether_resize = False
    '    mouseclickmovetogether_place = False
    '    Me.Refresh()
    'End Sub

    Private Sub Notizen_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        'allmouseup()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        get_lightcolor()
    End Sub

    Private Sub Notizen_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        'Me.ToolStripContainer2.Visible = False
    End Sub

    Private Sub Notizen_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Me.ToolStripContainer2.Visible = True
    End Sub

    Private Sub changefiletoolstripitems(ByRef item As System.Windows.Forms.ToolStripMenuItem)
        If Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1) Is File4ToolStripMenuItem Then
            Me.open_this = 4
        ElseIf Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1) Is File3ToolStripMenuItem Then
            Me.open_this = 3
        ElseIf Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1) Is File2ToolStripMenuItem Then
            Me.open_this = 2
        ElseIf Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1) Is File1ToolStripMenuItem Then
            Me.open_this = 1
        End If
        Dim m1 As String = item.Text
        Dim m2 As String = item.Tag
        item.Text = Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1).Text
        item.Tag = Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1).Tag
        Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1).Text = m1
        Startmenue.DropDownItems.Item(Startmenue.DropDownItems.Count - 1).Tag = m2
    End Sub


    Private Sub File1ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles File1ToolStripMenuItem.Click
        If My.Computer.FileSystem.FileExists(File1ToolStripMenuItem.Tag + "\" + File1ToolStripMenuItem.Text) Then
            changefiletoolstripitems(File1ToolStripMenuItem)
            Me.oeffne()
        Else
            MsgBox("File does not exist.")
        End If
    End Sub

    Private Sub File2ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles File2ToolStripMenuItem.Click
        If My.Computer.FileSystem.FileExists(File2ToolStripMenuItem.Tag + "\" + File2ToolStripMenuItem.Text) Then
            changefiletoolstripitems(File2ToolStripMenuItem)
            Me.oeffne()
        Else
            MsgBox("File does not exist.")
        End If
    End Sub

    Private Sub File3ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles File3ToolStripMenuItem.Click
        If My.Computer.FileSystem.FileExists(File3ToolStripMenuItem.Tag + "\" + File3ToolStripMenuItem.Text) Then
            changefiletoolstripitems(File3ToolStripMenuItem)
            Me.oeffne()
        Else
            MsgBox("File does not exist.")
        End If
    End Sub

    Private Sub File4ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles File4ToolStripMenuItem.Click
        If My.Computer.FileSystem.FileExists(File4ToolStripMenuItem.Tag + "\" + File4ToolStripMenuItem.Text) Then
            Me.open_this = 4
            Me.oeffne()
        Else
            MsgBox("File does not exist.")
        End If
    End Sub


    Private Sub Notizen_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible <> False And My.Application.start_arguemnts.minimizedstart And Not minimizedstarted = 2 Then
            minimizedstarted += 1
            If ShowInTaskbar = False Then
                Me.Visible = False
            Else
                WindowState = FormWindowState.Minimized
            End If
        End If
    End Sub
    Private Sub ToolStrip_whatscroll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip_whatscroll.Click
        If Inhalt.ScrollBars < 3 Then
            Inhalt.ScrollBars += 1
        Else
            Inhalt.ScrollBars = 0
        End If
        set_partial_scroll()
    End Sub

    Private Sub fgcolorToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles fgcolorToolStripMenuItem.Click
        Dim colordialog = New ColorDialog
        If colordialog.ShowDialog() = DialogResult.OK Then
            Inhalt.SelectionColor = colordialog.Color
            have_changed_file()
            Inhalt.rtf_to_node_to_desknote_and_have_changed()
        End If
    End Sub

    Private Sub bgcolorToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bgcolorToolStripMenuItem.Click
        Dim colordialog = New ColorDialog
        If colordialog.ShowDialog() = DialogResult.OK Then
            Inhalt.SelectionBackColor = colordialog.Color
            Inhalt.rtf_to_node_to_desknote_and_have_changed()
        End If
    End Sub


    Private Sub new_next_toolstripmenuitem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles new_next_toolstripmenuitem.Click
        neu_neben_knoten()
    End Sub

    Private Sub new_under_toolstripmenuitem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles new_under_toolstripmenuitem.Click
        Baum.element_dazu()
    End Sub

    Private Sub NeuToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NeuToolStripMenuItem1.Click
        If NeuToolStripMenuItem1.Checked = False Then
            NeuToolStripMenuItem1.Checked = True
            Me.ToolStrip4.Location = New Point(toolstrip_breite, 0)
            ToolStrip4.Visible = True
        Else
            NeuToolStripMenuItem1.Checked = False
            ToolStrip4.Visible = False
        End If
        'Me.resize2()

    End Sub

    Private Sub b_sichernftp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles b_sichernftp.Click
        ftpkram = New ftpkram
        ftpkram.Visible = False
        ftpkram.ftp_mach(False)
        If Not error_with_file Then
            Me.b_sichernftp.Enabled = False
        End If
        error_with_file = False
        ftpkram.Dispose()
    End Sub

    Private Sub Autosavetimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Autosavetimer.Tick
        'MsgBox(odatei.datei_da.ToString + " " + My.Computer.FileSystem.FileExists(odatei.Verzeichnis + "\" + odatei.SaveName).ToString + " " + veraendert.ToString)
        If Not Me.Baum.topnode Is Nothing _
        And odatei.datei_da _
        And My.Computer.FileSystem.FileExists(odatei.Verzeichnis + "\" + odatei.SaveName) _
        And veraendert Then
            save_anyway()
        End If

    End Sub
End Class
