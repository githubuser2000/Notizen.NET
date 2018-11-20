Imports System.Net
Imports System.IO
Public Class ftpkram



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'components.Dispose()
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("path", TB_Pfad.Text)
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("name", TB_Account.Text)
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("pass", TB_Passwort.Text)
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("host", TB_IP.Text)
        Notizen.xml_kram.doc.Save(Notizen.xml_kram.xml_dir + "notizen.config.xml")
        MyBase.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("path", TB_Pfad.Text)
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("name", TB_Account.Text)
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("pass", TB_Passwort.Text)
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("host", TB_IP.Text)
        Notizen.xml_kram.doc.Save(Notizen.xml_kram.xml_dir + "notizen.config.xml")
        ftp_mach(True)
        MyBase.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("path", TB_Pfad.Text)
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("name", TB_Account.Text)
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("pass", TB_Passwort.Text)
        Notizen.xml_kram.doc.Item("notizen-alx").Item("ftp").SetAttribute("host", TB_IP.Text)
        Notizen.xml_kram.doc.Save(Notizen.xml_kram.xml_dir + "notizen.config.xml")
        If Notizen.Baum.topnode IsNot Nothing Then
            ftp_mach(False)

        End If
        MyBase.Dispose()
        Me.Dispose()
    End Sub


    Dim ftpUrl As String

    Public Sub ftp_mach(Optional ByRef was As Boolean = True)
        'System.Threading.Thread.Sleep(2000)
        Try
            If TB_IP.Text.Length > 1 Then
                If TB_IP.Text.Chars(TB_IP.Text.Length - 1) = "/" Then ' bei "domain/"            
                    TB_IP.Text = TB_IP.Text.Substring(0, TB_IP.Text.Length - 2)
                End If

                If TB_Pfad.Text.Chars(0) <> "/" Then ' bei "pfad ohne / vorn"
                    TB_Pfad.Text = "/" + TB_Pfad.Text
                End If
            Else
                Throw New Exception("wrong input")
            End If
            If TB_Pfad.Text.Length > 3 Then
                If TB_Pfad.Text.Substring(TB_Pfad.Text.Length - 4, 4) <> ".alx" Then
                    MsgBox(Notizen.lang_pointer(Notizen.lang_keys.alxerror))
                Else
                    ftpUrl = "ftp://"
                    If TB_Account.Text <> "" Then
                        ftpUrl += TB_Account.Text
                        If TB_Passwort.Text <> "" Then
                            ftpUrl += ":" + TB_Passwort.Text
                        End If
                        ftpUrl += "@"
                    End If
                    ftpUrl += TB_IP.Text + TB_Pfad.Text

                    If was Then
                        Notizen.ftpversuche = 3
                        Notizen.oeffne_datei("", ftpUrl)
                        Notizen.b_sichernftp.Enabled = True
                    Else
                        Notizen.speichern(ftpUrl)
                        If Notizen.error_with_file Then
                            Notizen.b_sichernftp.Enabled = False
                        End If
                    End If

                End If
            Else
                MsgBox("wrong input")
                Notizen.error_with_file = True
            End If
        Catch ex As Exception
            MsgBox("error: " + ex.Message)
            Notizen.error_with_file = True
        End Try
        'Notizen.error_with_file = False
    End Sub

    Private Sub ftpkram_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Notizen.error_with_file = False

    End Sub

    Private Sub ftpkram_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Notizen.error_with_file = False

    End Sub
End Class
