

Public Class Datei
    Private dateiname As String = "unbenannt.alx"
    'Private startverzeichnis As String = System.Environment.ExpandEnvironmentVariables("%userprofile%") + "\Desktop"
    Private startverzeichnis As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Notizen"
    Private verzname As String = startverzeichnis
    Public datei_da As Boolean = False

    Public saved As Boolean = False

    Property SaveName() As String
        Get
            Return dateiname
        End Get
        Set(ByVal value As String)
            If value.Substring(dateiname.LastIndexOf("\") + 1).Length > 1 Then
                dateiname = value.Substring(value.LastIndexOf("\") + 1)
                verzname = value.Substring(0, value.LastIndexOf("\"))
            Else
                dateiname = value
            End If
            datei_da = True
        End Set
    End Property

    Property Verzeichnis() As String
        Get
            Return verzname
        End Get
        Set(ByVal value As String)
            If value.Length < 2 Then
                verzname = startverzeichnis
            Else
                verzname = value
            End If
        End Set
    End Property

    Public Sub New()
        If Not My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Notizen") Then
            Try
                My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Notizen")
            Catch ex As Exception
                Throw ex
                End
            End Try
        End If
    End Sub
End Class