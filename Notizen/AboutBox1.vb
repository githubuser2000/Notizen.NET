Imports System.Net
Imports System.IO.Compression
Imports System.IO
Imports System.Text

Public NotInheritable Class AboutBox1


    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Legen Sie den Titel des Formulars fest.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Info {0}", ApplicationTitle)
        ' Initialisieren Sie den gesamten Text, der im Infofeld angezeigt wird.
        ' TODO: Passen Sie die Assemblyinformationen der Anwendung im Bereich "Anwendung" des Dialogfelds für die 
        '    Projekteigenschaften (im Menü "Projekt") an.
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Dispose()
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        Me.LabelProductName.Text += " " + Notizen.version
        If Notizen.lang_chosen = Notizen.lang_enum.Deutsch Then
            Me.TextBoxDescription.Text = ChrW(8226) + " Eine Haftnotiz erstellt man mit dem Menü eines Knotens und erreicht man dann über das Menü des Trayicons." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
     ChrW(8226) + " Einzelne Knoten lassen sich als rtf Datei zusammenfassen, die z.B. mit Wordpad lesbar sind." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
     ChrW(8226) + " Erstellt man eine Verknüpfung mit dem Ziel ""C:\Ort1\Notizen.exe"" -min ""C:\Dokumente und Einstellungen\Benutzer\Eigene Dateien\Notizen\datei.alx"" also erst Notizen.exe und die alx-Datei, dann öffnet sich das Programm zusammen mit der Notizendatei. Beide Ortsangaben müssen am Besten in Anführungszeichen stehen. Stellt man diese Verknüpfung in den Autostartordner, so hat man immer seine gut sortierten Notizen zur Hand." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
     ChrW(8226) + " Die Anhabe /min sorgt als Programmstartangabe z.B. in einer Verknüpfung für ein minimiertes Hauptfenster bei Beginn. (notizen.exe /min Zieldatei)"" " + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
     ChrW(8226) + " Startet man Notizen .Net mit Adminrechten kann danach eine alx-Datei durch den Explorerer erkannt werden."
            Me.Label1.Text = "persönliche Meinung / Fehlermeldung / Feature-Vorschlag"
            bt_close.Text = "schließen"
            bt_send.Text = "senden"
        Else 'If Notizen.lang_chosen = Notizen.lang_enum.English Then
            Me.TextBoxDescription.Text = ChrW(8226) + " A desknote can be created by using the menu of the node and can be reached by the trayicon menu." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
ChrW(8226) + " Nodes can be summed up as rtf file, witch can be read with Wordpad, Word or OpenOffice." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
ChrW(8226) + " Create a Link with with a destination: ""C:\Ort1\Notizen.exe"" -min ""C:\Dokumente und Einstellungen\Benutzer\Eigene Dateien\Notizen\datei.alx"" , first Notizen.exe and the alx file, the program will be opend by opening the File. Both Locations should be better into double quotes. If you put the link into the autostart folder you have your notes by starting the Computer." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
ChrW(8226) + " The argument /min after Notizen.exe, maybe in a line of a link, makes the programm running minimized at startup. (notizen.exe /min destination file)"" " + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
     ChrW(8226) + "If you run Notizen .Net with Administrator permissions once, the explorer will know Notizen .NET alx Files."
            Me.Label1.Text = "opinion / bug report / feature request"
            bt_close.Text = "close"
            bt_send.Text = "send"
        End If
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Private Sub lb_web_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lb_web.LinkClicked
        Process.Start("http://www.notiza.de")
    End Sub

    Private Sub TableLayoutPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel.Paint

    End Sub

    Private Sub bt_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_send.Click
        If feedback.Text.Length > 9 Then
            Dim datei_speicher_stream As Stream = Nothing
            Dim kompr_stream As Stream = Nothing
            Try
                Dim ftpUrl As String = "ftp://notizen:notizen@notiza.de/feedback." + System.DateTime.Now.Year.ToString + "-" + System.DateTime.Now.Month.ToString + "-" + System.DateTime.Now.Day.ToString + "-" + System.DateTime.Now.TimeOfDay.ToString + ".txt.gz"
                Dim uploadRequest As FtpWebRequest = WebRequest.Create(ftpUrl)
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile
                uploadRequest.Proxy = Nothing
                datei_speicher_stream = uploadRequest.GetRequestStream()
                kompr_stream = New GZipStream(datei_speicher_stream, CompressionMode.Compress)
                'zeichen2 = Encoding.Convert(System.Text.Encoding.Unicode, System.Text.Encoding.Default, Encoding.Unicode.GetBytes(Me.feedback.Text))      
                kompr_stream.Write(Encoding.Unicode.GetBytes(Me.feedback.Text), 0, Encoding.Unicode.GetBytes(Me.feedback.Text).Length)
            Catch 'ex As Exception
                If Notizen.lang_chosen = Notizen.lang_enum.Deutsch Then
                    MsgBox("Feedback konnte nicht gesendet werden.")
                Else
                    MsgBox("Feedback was not transmitted.")
                End If
            Finally
                If Not kompr_stream Is Nothing Then kompr_stream.Close()
                If Not datei_speicher_stream Is Nothing Then datei_speicher_stream.Close()
            End Try
            Me.Dispose()
        Else
            If Notizen.lang_chosen = Notizen.lang_enum.Deutsch Then
                MsgBox("Geben sie mindestens 10 Zeichen ein!")
            Else 'If Notizen.lang_chosen = Notizen.lang_enum.English Then
                MsgBox("A minimal input of 10 Characters is requiered.")
            End If
        End If
    End Sub
End Class
