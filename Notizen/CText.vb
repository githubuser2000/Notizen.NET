Public Class CText
    Private texta As String
    Private marki As Boolean
    Public shall_expand As Boolean
    Public desknote As desknote
    Property mark() As Boolean
        Get
            Return marki
        End Get
        Set(ByVal value As Boolean)
            marki = value
        End Set
    End Property
    Property text() As String
        Get
            Return texta
        End Get
        Set(ByVal value As String)
            If Not Notizen.Baum.TopNode Is Nothing Then
                If TypeOf (Notizen.Baum.TopNode.Tag) Is CText Then
                    If (Notizen.Baum.TopNode.Tag.mark = True) Then
                        marki = True
                    Else
                        marki = False
                    End If
                End If
            End If
            texta = value
        End Set
    End Property

    Public Sub New()
        Me.text = ""
    End Sub
End Class
