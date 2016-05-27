Imports System.IO
Imports Semico.ClsQuickCode
Public Class ClsFile

    Function GetExtension(ByVal pathFile As String) As String
        pathFile = IIf(pathFile Like "*\*", pathFile, AppPath(pathFile))
        Dim MyFileInfo As New FileInfo(pathFile)
        Return MyFileInfo.Extension()
    End Function

    Shared Function GetSeize(ByVal pathFile As String) As Long
        pathFile = IIf(pathFile Like "*\*", pathFile, AppPath(pathFile))
        Dim MyFileInfo As New FileInfo(pathFile)
        Return MyFileInfo.Length
    End Function

    Shared Sub DeleteFile(ByVal pathFile As String)
        pathFile = IIf(pathFile Like "*\*", pathFile, AppPath(pathFile))
        Dim MyFileInfo As New FileInfo(pathFile)
        MyFileInfo.Delete()
    End Sub

    Shared Sub CopyTo(ByVal pathFile As String, ByVal destination As String)
        pathFile = IIf(pathFile Like "*\*", pathFile, AppPath(pathFile))
        Dim MyFileInfo As New FileInfo(pathFile)
        MyFileInfo.CopyTo(destination)
    End Sub

    Shared Sub MoveTo(ByVal pathFile As String, ByVal Destination As String)
        pathFile = IIf(pathFile Like "*\*", pathFile, AppPath(pathFile))
        Dim MyFileInfo As New FileInfo(pathFile)
        MyFileInfo.MoveTo(Destination)
    End Sub

    Shared Function FindFile(ByVal folderPath As String, ByVal fileName As String, ByVal searchType As FileIO.SearchOption) As ArrayList
        Dim temp As New ArrayList
        Dim Tempx As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(folderPath, searchType, fileName)
        Dim c As Integer = Tempx.Count
        For i As Byte = 0 To c - 1
            temp.Add(Tempx.Item(0))
        Next
        Return temp
    End Function

    Shared Function ExistFile(ByVal pathFile As String) As Boolean
        pathFile = IIf(pathFile Like "*\*", pathFile, AppPath(pathFile))
        Dim MyFileInfo As New FileInfo(pathFile)
        Return MyFileInfo.Exists()
    End Function

    Public Shared Function OpenTXT(ByVal pathFile As String) As String
        Dim temp = ""
        pathFile = IIf(pathFile Like "*\*", pathFile, AppPath(pathFile))
        Dim OP As New StreamReader(pathFile)
        temp = OP.ReadToEnd()
        OP.Close()
        Return temp
    End Function

    Public Shared Sub WriteTXT(ByVal pathFile As String, ByVal text As String)
        pathFile = IIf(pathFile Like "*\*", pathFile, AppPath(pathFile))
        Dim OP As New StreamWriter(pathFile)
        OP.WriteLine(text)
        OP.Close()
    End Sub

End Class
