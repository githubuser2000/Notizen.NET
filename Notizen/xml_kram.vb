Imports System.Xml.XPath
Imports System.Xml

Public Structure windowdata
    Public size As Size
    Public location As Point
    Public WindowState As FormWindowState
    Public ShowInTaskbar As Boolean
    Public norm0_or_max1 As Byte
End Structure

Public Class xml_kram

    Public doc As New XmlDocument()
    Dim nodes As XmlNodeList
    Public xml_dir As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\"

    Public ReadOnly Property get_dir() As String
        Get
            doc.Load(xml_dir + "notizen.config.xml")
            Return doc.Item("notizen-alx").Item("open").Attributes("directory").Value
        End Get
    End Property
    Public ReadOnly Property get_file() As String
        Get
            doc.Load(xml_dir + "notizen.config.xml")
            Return doc.Item("notizen-alx").Item("open").Attributes("file").Value
        End Get
    End Property
    Public Property language() As String
        Get
            doc.Load(xml_dir + "notizen.config.xml")
            Return doc.Item("notizen-alx").Item("language").Attributes("choice").Value
        End Get
        Set(ByVal value As String)
            doc.Load(xml_dir + "notizen.config.xml")
            doc.Item("notizen-alx").Item("language").SetAttribute("choice", value)
            doc.Save(xml_dir + "notizen.config.xml")
        End Set
    End Property
    Public Property show_in_deskbar()
        Get
            doc.Load(xml_dir + "notizen.config.xml")
            Return doc.Item("notizen-alx").Item("minimized-show-in").Attributes("taskbar").Value
        End Get
        Set(ByVal value)
            doc.Load(xml_dir + "notizen.config.xml")
            doc.Item("notizen-alx").Item("minimized-show-in").SetAttribute("taskbar", value)
            doc.Save(xml_dir + "notizen.config.xml")
        End Set
    End Property
    Public Property show_desknote_borders()
        Get
            doc.Load(xml_dir + "notizen.config.xml")
            Return doc.Item("notizen-alx").Item("desknotes").Attributes("show_desknote_borders").Value
        End Get
        Set(ByVal value)
            doc.Load(xml_dir + "notizen.config.xml")
            doc.Item("notizen-alx").Item("desknotes").SetAttribute("show_desknote_borders", value)
            doc.Save(xml_dir + "notizen.config.xml")
        End Set
    End Property

    Public ReadOnly Property werkzeugstreifen(ByVal a As Byte) As Point
        Get
            Dim x1 As Integer
            Dim y1 As Integer

            doc.Load(xml_dir + "notizen.config.xml")
            Select Case (a)
                Case 1
                    x1 = doc.Item("notizen-alx").Item("tool-stripes").Item("haupt").Attributes("x").Value
                    y1 = doc.Item("notizen-alx").Item("tool-stripes").Item("haupt").Attributes("y").Value
                Case 2
                    x1 = doc.Item("notizen-alx").Item("tool-stripes").Item("font").Attributes("x").Value
                    y1 = doc.Item("notizen-alx").Item("tool-stripes").Item("font").Attributes("y").Value
                Case 3
                    If doc.Item("notizen-alx").Item("tool-stripes").Item("cutpastecopy").Attributes("x").Value >= 0 Then
                        x1 = doc.Item("notizen-alx").Item("tool-stripes").Item("cutpastecopy").Attributes("x").Value
                    Else
                        x1 = 0
                    End If
                    y1 = doc.Item("notizen-alx").Item("tool-stripes").Item("cutpastecopy").Attributes("y").Value
                Case 4
                    x1 = doc.Item("notizen-alx").Item("tool-stripes").Item("elements").Attributes("x").Value
                    y1 = doc.Item("notizen-alx").Item("tool-stripes").Item("elements").Attributes("y").Value
            End Select
            Return New Point(x1, y1)
        End Get
        'Set(ByVal value As String)
        '    doc.Load(xml_dir + "notizen.config.xml")
        '    Select Case (a)
        '        Case 1 : doc.Item("notizen-alx").Item("tool-stripes").SetAttribute("haupt", value)
        '        Case 2 : doc.Item("notizen-alx").Item("tool-stripes").SetAttribute("font", value)
        '        Case 3 : doc.Item("notizen-alx").Item("tool-stripes").SetAttribute("cutpastecopy", value)
        '        Case 4 : doc.Item("notizen-alx").Item("tool-stripes").SetAttribute("elements", value)
        '    End Select
        '    doc.Save(xml_dir + "notizen.config.xml")
        'End Set
    End Property

    Public Sub save()
        doc.Save(xml_dir + "notizen.config.xml")
    End Sub



    Public Function on_load() As windowdata
        doc.Load(xml_dir + "notizen.config.xml")
        Dim windowdata As New windowdata
        Dim punkt As New Point(doc.Item("notizen-alx").Item("main-form").Attributes("x").Value, doc.Item("notizen-alx").Item("main-form").Attributes("y").Value)
        If (punkt.X < My.Computer.Screen.WorkingArea.Width - 50) And (punkt.Y < My.Computer.Screen.WorkingArea.Height - 50) Then
            windowdata.location = punkt
        End If
        punkt = New Point(doc.Item("notizen-alx").Item("main-form").Attributes("width").Value, doc.Item("notizen-alx").Item("main-form").Attributes("height").Value)
        windowdata.size = punkt

        Dim fenster_status As String = doc.Item("notizen-alx").Item("main-form").Attributes("windowstate").Value
        If fenster_status = "Maximized" Then
            windowdata.WindowState = FormWindowState.Maximized
            windowdata.norm0_or_max1 = 1
        ElseIf fenster_status = "Minimized" Then
            windowdata.ShowInTaskbar = True
            windowdata.WindowState = FormWindowState.Minimized
            windowdata.ShowInTaskbar = False
        Else
            windowdata.WindowState = FormWindowState.Normal
            windowdata.norm0_or_max1 = 0
        End If
        Return windowdata
    End Function

    Public Sub on_exit()
        doc.Load(xml_dir + "notizen.config.xml")
        If Notizen.WindowState <> FormWindowState.Maximized Then
            doc.Item("notizen-alx").Item("main-form").SetAttribute("x", Notizen.Location.X)
            doc.Item("notizen-alx").Item("main-form").SetAttribute("y", Notizen.Location.Y)
            doc.Item("notizen-alx").Item("main-form").SetAttribute("width", Notizen.Size.Width)
            doc.Item("notizen-alx").Item("main-form").SetAttribute("height", Notizen.Size.Height)
        End If
        doc.Item("notizen-alx").Item("main-form").SetAttribute("windowstate", Notizen.WindowState.ToString)

        doc.Item("notizen-alx").Item("open").SetAttribute("directory", Notizen.odatei.Verzeichnis)
        doc.Item("notizen-alx").Item("open").SetAttribute("file", Notizen.odatei.SaveName)

        doc.Item("notizen-alx").Item("tool-stripes").Item("haupt").SetAttribute("x", Notizen.ToolStrip1.Location.X)
        doc.Item("notizen-alx").Item("tool-stripes").Item("haupt").SetAttribute("y", Notizen.ToolStrip1.Location.Y)
        doc.Item("notizen-alx").Item("tool-stripes").Item("elements").SetAttribute("x", Notizen.ToolStrip4.Location.X)
        doc.Item("notizen-alx").Item("tool-stripes").Item("elements").SetAttribute("y", Notizen.ToolStrip4.Location.Y)
        Dim abc As Integer = Notizen.Inhalt.ScrollBars
        doc.Item("notizen-alx").Item("scrolls").SetAttribute("choice", abc.ToString)
        If Notizen.showdesknoteborders Then
            doc.Item("notizen-alx").Item("desknotes").SetAttribute("show_desknote_borders", "yes")
        Else
            doc.Item("notizen-alx").Item("desknotes").SetAttribute("show_desknote_borders", "no")
        End If
        If Not Notizen.File1ToolStripMenuItem.Tag Is Nothing Then
            doc.Item("notizen-alx").Item("files").SetAttribute("a", Notizen.File1ToolStripMenuItem.Tag + "\" + Notizen.File1ToolStripMenuItem.Text)
        End If
        If Not Notizen.File2ToolStripMenuItem.Tag Is Nothing Then
            doc.Item("notizen-alx").Item("files").SetAttribute("b", Notizen.File2ToolStripMenuItem.Tag + "\" + Notizen.File2ToolStripMenuItem.Text)
        End If
        If Not Notizen.File3ToolStripMenuItem.Tag Is Nothing Then
            doc.Item("notizen-alx").Item("files").SetAttribute("c", Notizen.File3ToolStripMenuItem.Tag + "\" + Notizen.File3ToolStripMenuItem.Text)
        End If
        If Not Notizen.File4ToolStripMenuItem.Tag Is Nothing Then
            doc.Item("notizen-alx").Item("files").SetAttribute("d", Notizen.File4ToolStripMenuItem.Tag + "\" + Notizen.File4ToolStripMenuItem.Text)
        End If

        'doc.Item("notizen-alx").Item("tool-stripes").Item("font").SetAttribute("x", Notizen.ToolStrip2.Location.X)
        'doc.Item("notizen-alx").Item("tool-stripes").Item("font").SetAttribute("y", Notizen.ToolStrip2.Location.Y)
        'doc.Item("notizen-alx").Item("tool-stripes").Item("cutpastecopy").SetAttribute("x", Notizen.ToolStrip3.Location.X)
        'doc.Item("notizen-alx").Item("tool-stripes").Item("cutpastecopy").SetAttribute("y", Notizen.ToolStrip3.Location.Y)
        doc.Save(xml_dir + "notizen.config.xml")
        If doc.Item("notizen-alx").Item("autorun").Attributes("if").Value = "yes" Then
            If doc.Item("notizen-alx").Item("autorun").Attributes("minimized").Value = "yes" Then
                setshortcut(True)
            Else
                setshortcut(False)
            End If
        End If
    End Sub

    Public Sub setshortcut(ByRef min As Boolean)
        Try
            With doc.Item("notizen-alx").Item("files")
                Dim linkdir As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
                'If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.SpecialDirectories.Programs + "\Autostart") Then
                '    linkdir = My.Computer.FileSystem.SpecialDirectories.Programs + "\Autostart"
                'ElseIf My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.SpecialDirectories.Programs + "\Startup") Then
                '    linkdir = My.Computer.FileSystem.SpecialDirectories.Programs + "\Startup"
                'Else
                '    linkdir = My.Computer.FileSystem.SpecialDirectories.Programs
                'End If
                If .Attributes("d").Value.IndexOf("\") > 0 Then
                    If min Then Notizen.CreateShortcut(linkdir + "\Notizen .Net.lnk", My.Application.Info.DirectoryPath + "\" + Process.GetCurrentProcess.ProcessName, " -min """ + .Attributes("d").Value + """", "", My.Application.Info.DirectoryPath) _
                    Else Notizen.CreateShortcut(linkdir + "\Notizen .NET.lnk", My.Application.Info.DirectoryPath + "\" + Process.GetCurrentProcess.ProcessName, """" + .Attributes("d").Value + """", "", My.Application.Info.DirectoryPath) _
                    'MsgBox(linkdir + "\Notizen .Net.lnk," + My.Application.Info.DirectoryPath + "\" + Process.GetCurrentProcess.ProcessName + ".exe")
                ElseIf .Attributes("c").Value.IndexOf("\") > 0 Then
                    If min Then Notizen.CreateShortcut(linkdir + "\Notizen .NET.lnk", My.Application.Info.DirectoryPath + "\" + Process.GetCurrentProcess.ProcessName, " -min """ + .Attributes("c").Value + """", "", My.Application.Info.DirectoryPath) _
                    Else Notizen.CreateShortcut(linkdir + "\Notizen .Net.lnk", My.Application.Info.DirectoryPath + "\" + Process.GetCurrentProcess.ProcessName, """" + .Attributes("c").Value + """", "", My.Application.Info.DirectoryPath)
                ElseIf .Attributes("b").Value.IndexOf("\") > 0 Then
                    If min Then Notizen.CreateShortcut(linkdir + "\Notizen .NET.lnk", My.Application.Info.DirectoryPath + "\" + Process.GetCurrentProcess.ProcessName, " -min """ + .Attributes("b").Value + """", "", My.Application.Info.DirectoryPath) _
                    Else Notizen.CreateShortcut(linkdir + "\Notizen .Net.lnk", My.Application.Info.DirectoryPath + "\" + Process.GetCurrentProcess.ProcessName, """" + .Attributes("b").Value + """", "", My.Application.Info.DirectoryPath)
                ElseIf .Attributes("a").Value.IndexOf("\") > 0 Then
                    If min Then Notizen.CreateShortcut(linkdir + "\Notizen .NET.lnk", My.Application.Info.DirectoryPath + "\" + Process.GetCurrentProcess.ProcessName, " -min """ + .Attributes("a").Value + """", "", My.Application.Info.DirectoryPath) _
                    Else Notizen.CreateShortcut(linkdir + "\Notizen .Net.lnk .NET", My.Application.Info.DirectoryPath + "\" + Process.GetCurrentProcess.ProcessName, """" + .Attributes("a").Value + """", "", My.Application.Info.DirectoryPath)
                Else
                    If min Then Notizen.CreateShortcut(linkdir + "\Notizen .NET.lnk", My.Application.Info.DirectoryPath + "\" + Process.GetCurrentProcess.ProcessName, " -min", "", My.Application.Info.DirectoryPath) _
                    Else Notizen.CreateShortcut(linkdir + "\Notizen .NET.lnk", My.Application.Info.DirectoryPath + "\" + Process.GetCurrentProcess.ProcessName, "", "", My.Application.Info.DirectoryPath)
                End If
            End With
        Catch
        End Try
    End Sub

    Public Sub New()
        If Not My.Computer.FileSystem.DirectoryExists(xml_dir) Then
            Try
                My.Computer.FileSystem.CreateDirectory(xml_dir)
            Catch ex As Exception
                Throw ex
                End
            End Try
        End If
        If (Not My.Computer.FileSystem.FileExists(xml_dir + "notizen.config.xml")) Then
            Try
                Dim schreiber As New Xml.XmlTextWriter(xml_dir + "notizen.config.xml", New System.Text.UnicodeEncoding)
                With schreiber

                    .WriteStartDocument()
                    .WriteStartElement("notizen-alx")

                    .WriteStartElement("scrolls")
                    .WriteAttributeString("choice", "3")
                    .WriteEndElement()

                    .WriteStartElement("saftycopies")
                    .WriteAttributeString("amount", "30")
                    .WriteEndElement()

                    .WriteStartElement("autorun")
                    .WriteAttributeString("if", "yes")
                    '.WriteAttributeString("file", "")
                    .WriteAttributeString("minimized", "yes")
                    .WriteEndElement()

                    .WriteStartElement("ftp")
                    .WriteAttributeString("name", "")
                    .WriteAttributeString("pass", "")
                    .WriteAttributeString("host", "")
                    .WriteAttributeString("path", "")
                    .WriteEndElement()

                    .WriteStartElement("files")
                    .WriteAttributeString("a", "")
                    .WriteAttributeString("b", "")
                    .WriteAttributeString("c", "")
                    .WriteAttributeString("d", "")
                    .WriteEndElement()

                    .WriteStartElement("language")
                    .WriteAttributeString("choice", "Auto")
                    .WriteEndElement()

                    .WriteStartElement("open")
                    .WriteAttributeString("file", "")
                    .WriteAttributeString("directory", "")
                    .WriteStartElement("once-opened")
                    .WriteAttributeString("file", "")
                    .WriteAttributeString("timestamp", "")
                    .WriteEndElement()
                    .WriteEndElement()

                    .WriteStartElement("main-form")
                    .WriteAttributeString("x", "0")
                    .WriteAttributeString("y", "0")
                    .WriteAttributeString("width", "0")
                    .WriteAttributeString("height", "0")
                    .WriteAttributeString("windowstate", "minimized")
                    .WriteEndElement()

                    .WriteStartElement("minimized-show-in")
                    '.WriteAttributeString("trayicon", "yes")
                    .WriteAttributeString("taskbar", "no")
                    .WriteEndElement()

                    .WriteStartElement("desknotes")
                    .WriteAttributeString("show_desknote_borders", "yes")
                    .WriteEndElement()

                    .WriteStartElement("tool-stripes")
                    .WriteStartElement("haupt")
                    .WriteAttributeString("x", "0")
                    .WriteAttributeString("y", "0")
                    .WriteEndElement()
                    .WriteStartElement("elements")
                    .WriteAttributeString("x", "0")
                    .WriteAttributeString("y", "0")
                    .WriteEndElement()
                    .WriteStartElement("font")
                    .WriteAttributeString("x", "0")
                    .WriteAttributeString("y", "0")
                    .WriteEndElement()
                    .WriteStartElement("cutpastecopy")
                    .WriteAttributeString("x", "0")
                    .WriteAttributeString("y", "0")
                    .WriteEndElement()
                    .WriteEndElement()

                    .WriteStartElement("x")
                    .WriteAttributeString("y", DateTime.Today.Ticks.ToString)
                    .WriteAttributeString("z", "0")
                    .WriteAttributeString("a", "60")
                    .WriteEndElement()

                    .WriteEndElement()
                    .Close()
                End With
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
