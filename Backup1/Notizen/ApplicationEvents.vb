Structure Start_Arguments
    Public helptext As Boolean
    Public file As String
    Public minimizedstart As Boolean
End Structure

Namespace My
    ' F�r MyApplication sind folgende Ereignisse verf�gbar:
    ' 
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgel�st.
    ' Shutdown: Wird nach dem Schlie�en aller Anwendungsformulare ausgel�st. Dieses Ereignis wird nicht ausgel�st, wenn die Anwendung nicht normal beendet wird.
    ' UnhandledException: Wird ausgel�st, wenn in der Anwendung eine unbehandelte Ausnahme auftritt.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgel�st, wenn diese bereits aktiv ist. 
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgel�st.
    Partial Friend Class MyApplication

        Public start_arguemnts As New Start_Arguments

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            If e.CommandLine.Count > 0 Then
                start_arguemnts.helptext = False
                start_arguemnts.minimizedstart = False
                For Each kommandozeilenbefehl As String In e.CommandLine
                    If kommandozeilenbefehl.Substring(kommandozeilenbefehl.Length - 4, 4) = ".alx" Then
                        start_arguemnts.file = kommandozeilenbefehl 'e.CommandLine(e.CommandLine.Count - 1)
                        If Not System.IO.File.Exists(start_arguemnts.file) And start_arguemnts.file.Substring(0, 6) <> "ftp://" Then
                            start_arguemnts.file = ""
                            MsgBox("alx file does not exist.")
                        End If
                    End If
                    Select Case kommandozeilenbefehl
                        Case "/min"
                            start_arguemnts.minimizedstart = True
                        Case "/h"
                            start_arguemnts.helptext = True
                        Case "/?"
                            start_arguemnts.helptext = True
                        Case "-min"
                            start_arguemnts.minimizedstart = True
                        Case "-h"
                            start_arguemnts.helptext = True
                        Case "-?"
                            start_arguemnts.helptext = True
                        Case "min"
                            start_arguemnts.minimizedstart = True
                        Case "h"
                            start_arguemnts.helptext = True
                        Case "?"
                            start_arguemnts.helptext = True
                    End Select
                Next
            Else
                start_arguemnts.file = ""
                start_arguemnts.helptext = False
                start_arguemnts.minimizedstart = False
            End If
        End Sub
    End Class
End Namespace