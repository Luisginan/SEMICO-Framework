Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Text


Public Class ClsValidationText
    ''' <summary>
    ''' Memastikan apakah terdapat karakter khusus pada String input.<br/>
    ''' Digunakan untuk validasi Nama
    ''' </summary>
    ''' <param name="target">String input</param>
    ''' <returns>True jika mengandung karakter khusus</returns>
    ''' <remarks></remarks>
    Public Shared Function isContainSpecialCharacter(ByVal target As String) As Boolean
        Dim r As Regex = New Regex("[^a-zA-Z ]")
        If r.IsMatch(target) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function isContainSpecialCharacter(ByVal target As String, ByVal chars As String) As Boolean
        Dim r As Regex = New Regex(String.Format("[{0}]", chars))
        If r.IsMatch(target) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function cleanAnyDoubleSpaces(ByVal target As String) As String
        Dim _s As String = Regex.Replace(target, "[\s]{2,}", " ", RegexOptions.Singleline)
        Return _s.Trim
    End Function

    Public Shared Function CleanAnySpecialCharacter(ByVal target As String) As String
        Dim _s As String = Regex.Replace(target, "[^a-zA-Z0-9 ]", " ", RegexOptions.Singleline)
        Return cleanAnyDoubleSpaces(_s)
    End Function


    ''' <summary>
    ''' _ Encrypt Data 2003 _
    ''' </summary>
    ''' <param name="cleanString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Encrypt2003(ByVal cleanString As String) As String
        Dim clearBytes As [Byte]() = New UnicodeEncoding().GetBytes(cleanString)
        Dim hashedBytes As [Byte]() = CType(CryptoConfig.CreateFromName("MD5"), HashAlgorithm).ComputeHash(clearBytes)
        Dim hashedText As String = BitConverter.ToString(hashedBytes)
        Return hashedText
    End Function

    ''' <summary>
    ''' 'Mengkoreksi string dengan konten alamat email
    ''' </summary>
    ''' <param name="email">luisginan@gmal.com</param>
    ''' <returns>True jika valid,False jika tidak valid</returns>
    ''' <remarks></remarks>
    Public Shared Function IsValidEmail(ByVal email As String) As Boolean
        Return (Regex.IsMatch(email, "^(.+)@([\w-]+\.)+[A-Za-z]{2,3}$"))
    End Function
End Class

