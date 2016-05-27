
Public Class ClsCurensi
    Private Datang As String
    Private Result As String
    Private Belas As String
    Private Puluh As String
    Private Ratus As String
    Private satu As String
    Private Bag As String
    Private ekor As Boolean
    Private L As String
    Private i As Integer

    ''' <summary>
    ''' Fungsi Terbilang (input String)
    ''' </summary>
    ''' <param name="T"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function segmentasi(ByVal T As String) As String
        Dim F As Integer
        T = T.Replace(".", "")
        F = Len(T)
        Datang = T
        Result = ""
        For i = 1 To F
            KirimdataS(CDbl(Mid(Datang, i, 1)), (F + 1) - i)
            L = Result
        Next i
        L = Result
        Return Result
    End Function

    Private Sub KirimdataS(ByVal Data As Integer, ByVal pos As Integer)
        Zona(pos)
        Select Case pos
            Case 1, 4, 7, 10, 13, 16, 19
                If i > 1 Then
                    If CDbl(Mid(Datang, i - 1, 1)) > 1 Then
                        satuan(Data)
                        Result = String.Format("{0} {1}", Result, satu)
                    Else
                        If Data > 0 Then
                            If CDbl(Mid(Datang, i - 1, 1)) = 0 Then
                                satuan(Data)
                                Result = String.Format("{0} {1}", Result, satu)
                            End If
                        End If
                    End If
                ElseIf i = 1 Then
                    satuan(Data)
                    Result = satu
                End If
                If ekor = True Then
                    Result = String.Format("{0} {1}", Result, Bag)
                    ekor = False
                End If
            Case 2, 5, 8, 11, 14, 17, 20
                Puluhan(Data, Mid(Datang, i + 1, 1))
            Case 3, 6, 9, 12, 15, 18, 21
                Ratusan(Data)
        End Select
    End Sub

    Private Sub Zona(ByVal Zon As Integer)
        Bag = ""
        Select Case Zon
            Case 4
                Bag = "Ribu"
            Case 7
                Bag = "Juta"
            Case 10
                Bag = "Milyar"
            Case 13
                Bag = "Triliyun"
            Case 16
                Bag = "ribu Triliyun"
        End Select
    End Sub

    Private Sub Ratusan(ByVal A As Integer)
        Ratus = ""
        Select Case A
            Case 0
                Ratus = ""
            Case 1
                Ratus = "Seratus"
                ekor = True
                Result = String.Format("{0} {1}", Result, Ratus)
            Case Else
                satuan(A)
                Ratus = satu & " Ratus"
                Result = String.Format("{0} {1}", Result, Ratus)
        End Select
    End Sub

    Private Sub Puluhan(ByVal B As Integer, ByVal C As Integer)
        Puluh = ""
        Select Case B
            Case 0
                Puluh = ""
            Case 1
                If C > 0 Then
                    belasan(C)
                Else
                    Puluh = "Sepuluh"
                End If
                ekor = True
                Result = String.Format("{0} {1}", Result, Puluh)
            Case Else
                satuan(B)
                Puluh = satu & " Puluh"
                Result = String.Format("{0} {1}", Result, Puluh)
        End Select
    End Sub

    Private Sub belasan(ByVal C As Integer)
        Belas = ""
        Select Case C
            Case 1
                Belas = "Sebelas"
                Result = String.Format("{0} {1}", Result, Belas)
            Case Else
                satuan(C)
                Belas = satu & " Belas"
                Result = String.Format("{0} {1}", Result, Belas)
        End Select
    End Sub

    Private Sub satuan(ByVal S As Integer)
        Select Case S
            Case 0
                satu = ""
            Case 1
                satu = "Satu"
                ekor = True
            Case 2
                satu = "Dua"
                ekor = True
            Case 3
                satu = "Tiga"
                ekor = True
            Case 4
                satu = "Empat"
                ekor = True
            Case 5
                satu = "Lima"
                ekor = True
            Case 6
                satu = "Enam"
                ekor = True
            Case 7
                satu = "Tujuh"
                ekor = True
            Case 8
                satu = "Delapan"
                ekor = True
            Case 9
                satu = "Sembilan"
                ekor = True
        End Select

    End Sub
End Class

