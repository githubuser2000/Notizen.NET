Imports System.Windows.Forms
Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Collections.Generic
Imports System.IO.Compression
Imports System.Xml.XPath
Imports System.Xml
Imports System.Net

Public Class passwort_dialog2
    Public fehler1 As String
    Dim fsread As FileStream
    Dim cryptostream1 As CryptoStream
    Dim cryptostream2 As CryptoStream
    Dim cryptostream3 As CryptoStream
    Dim kompr_stream As GZipStream
    Dim ftpversuche As Byte = 3
    Private ftpurl As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Notizen.p = TextBox1.Text
        Me.laden()
        Me.Dispose()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Public Sub New(ByVal b As String, ByVal c As String, Optional ByVal a As String = "")
        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        ftpurl = a
        Label1.Text = b
        fehler1 = c
        Me.Activate()
        Me.TextBox1.Select()
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
    End Sub


    Public Sub laden()

        Notizen.Baum.Visible = False
        Notizen.passwort_bearbeite()
        'MsgBox(Notizen.p.Length.ToString)
        'MsgBox(Notizen.p)
        ' For additional security, pin the key.
        Notizen.gch = GCHandle.Alloc(Notizen.p, GCHandleType.Pinned)

        Dim DES1 As New DESCryptoServiceProvider()
        DES1.Key() = ASCIIEncoding.ASCII.GetBytes(Notizen.p.Substring(0, 8))
        DES1.IV = ASCIIEncoding.ASCII.GetBytes(Notizen.p.Substring(0, 8))
        Dim DES2 As New DESCryptoServiceProvider()
        DES2.Key() = ASCIIEncoding.ASCII.GetBytes(Notizen.p.Substring(7, 8))
        DES2.IV = ASCIIEncoding.ASCII.GetBytes(Notizen.p.Substring(7, 8))
        Dim DES3 As New DESCryptoServiceProvider()
        DES3.Key() = ASCIIEncoding.ASCII.GetBytes(Notizen.p.Substring(15, 8))
        DES3.IV = ASCIIEncoding.ASCII.GetBytes(Notizen.p.Substring(15, 8))
        Dim kompr_stream As GZipStream = Nothing
        Dim reader As StreamReader = Nothing
        Dim fsread As Stream = Nothing
        Dim XMLReader As Xml.XmlReader = Nothing
        Try
            If ftpurl = "" Then
                fsread = New FileStream(Notizen.odatei.Verzeichnis + "\" + Notizen.odatei.SaveName, FileMode.Open, FileAccess.Read)
            Else
                Dim downloadRequest As FtpWebRequest = WebRequest.Create(ftpurl)
                Dim downloadResponse As FtpWebResponse = downloadRequest.GetResponse()
                fsread = downloadResponse.GetResponseStream()
            End If
            cryptostream1 = New CryptoStream(fsread, DES1.CreateDecryptor(), CryptoStreamMode.Read)
            cryptostream2 = New CryptoStream(cryptostream1, DES2.CreateDecryptor(), CryptoStreamMode.Read)
            cryptostream3 = New CryptoStream(cryptostream2, DES3.CreateDecryptor(), CryptoStreamMode.Read)
            kompr_stream = New GZipStream(cryptostream3, CompressionMode.Decompress, False)

            XMLReader = New Xml.XmlTextReader(kompr_stream)
            Notizen.Inhalt.node_set(Notizen.Baum.topnode)
            Notizen.Baum.Visible = False
            Notizen.xmlread(XMLReader)
        Catch ex As WebException
            If ex.Status = 7 And ftpversuche > 0 Then
                ftpversuche -= 1
                laden()
            Else
                MsgBox("WebException: " + ex.Message)
            End If
        Catch ex As Exception
            'MsgBox(Notizen.text_lang_1)
            Notizen.Invoke(New Notizen.schliessen_ohne_fragen_delegate(AddressOf Notizen.schliessen_ohne_fragen))

            MsgBox(Notizen.text_lang_2 + Chr(13) + fehler1 + Chr(13) + "Error: " + ex.Message)
            Notizen.error_with_file = True
        Finally
            Try
                If kompr_stream IsNot Nothing Then kompr_stream.Close()
                If cryptostream3 IsNot Nothing Then cryptostream3.Close()
                If cryptostream2 IsNot Nothing Then cryptostream2.Close()
                If cryptostream1 IsNot Nothing Then cryptostream1.Close()
                If fsread IsNot Nothing Then fsread.Close()
                If XMLReader IsNot Nothing Then XMLReader.Close()
            Catch
            End Try
            Notizen.Baum.Visible = True
            Notizen.oeffnen_datei_danachmach(ftpurl)
        End Try
    End Sub
End Class
