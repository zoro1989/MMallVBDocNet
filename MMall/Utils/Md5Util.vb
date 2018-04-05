Imports System.Security.Cryptography

Public Class Md5Util
    Public Shared Function SetMd5Pass(ByVal InPutString As String) As String
        Dim Key As MD5 = MD5.Create
        Dim Bytes() As Byte = Key.ComputeHash(Encoding.Default.GetBytes(InPutString))
        Dim Sbuilter As New StringBuilder
        For i As Integer = 0 To Bytes.Length - 1
            Sbuilter.Append(Bytes(i).ToString("x2"))
        Next
        Return Sbuilter.ToString
    End Function
End Class
