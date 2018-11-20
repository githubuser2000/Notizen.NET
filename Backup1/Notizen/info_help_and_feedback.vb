Imports System.Net
Imports System.IO.Compression
Imports System.IO
Imports System.Text

Public NotInheritable Class info_help_and_feedback


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
        Me.TextBoxDescription.Text = Notizen.lang_pointer(Notizen.lang_keys.aboutinfotext)
        Me.Label1.Text = Notizen.lang_pointer(Notizen.lang_keys.feedback)
        bt_close.Text = Notizen.lang_pointer(Notizen.lang_keys.close)
        bt_send.Text = Notizen.lang_pointer(Notizen.lang_keys.send)
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Private Sub lb_web_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lb_web.LinkClicked
        Process.Start("http://www.notiza.de")
    End Sub

    Private Sub TableLayoutPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel.Paint

    End Sub

    Private Sub bt_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_send.Click
        Try
            Dim when_ As Long = CLng(Notizen.xml_kram.doc.Item("notizen-alx").Item("x").Attributes("y").Value)
            Dim count As Byte = Notizen.xml_kram.doc.Item("notizen-alx").Item("x").Attributes("z").Value
            If when_ < System.DateTime.Today.Ticks _
            Or (when_ = DateTime.Today.Ticks And count < 30) Then
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
                        MsgBox(Notizen.lang_pointer(Notizen.lang_keys.no_feedback_sent))
                    Finally
                        If Not kompr_stream Is Nothing Then kompr_stream.Close()
                        If Not datei_speicher_stream Is Nothing Then datei_speicher_stream.Close()
                    End Try
                    If when_ < System.DateTime.Today.Ticks Then
                        Notizen.xml_kram.doc.Item("notizen-alx").Item("x").SetAttribute("z", "0")
                        MsgBox(when_.ToString + " " + System.DateTime.Today.Ticks)
                    Else
                        Notizen.xml_kram.doc.Item("notizen-alx").Item("x").SetAttribute("z", (count + 10).ToString)
                    End If
                    Notizen.xml_kram.save()
                    Notizen.xml_kram.doc.Item("notizen-alx").Item("x").SetAttribute("y", System.DateTime.Today.Ticks.ToString)
                    Me.Dispose()
                Else
                    MsgBox(Notizen.lang_pointer(Notizen.lang_keys.char10minimum))
                End If
            Else
                MsgBox(Notizen.lang_pointer(Notizen.lang_keys.no_send))
            End If
        Catch
            MsgBox("error")
        End Try
    End Sub
End Class
