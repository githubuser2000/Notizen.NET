Imports System.Runtime.InteropServices
Module Modul

    <DllImport("kernel32.dll")> Public Sub ZeroMemory(ByVal addr As IntPtr, ByVal size As Integer)
    End Sub

End Module
