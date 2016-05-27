
Public Class ClsQB
#Region "SQLF ..."
    Public Shared Function HSQL(ByVal str As String) As String
        If IsNothing(str) Then
            Return ""
        ElseIf str = "" Then
            Return ""
        End If
        str = str.Replace("'", "''")
        Return (String.Format("{0}", str))
    End Function
    ''' <summary>
    ''' Luis : Menterjemahkan String VB ke SQLserver
    ''' Menjadi Format dari "Luis" diubah 'Luis'
    ''' dan sudah menangani kutip ' di string
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CSQL(ByVal str As String) As String

        If IsNothing(str) Then
            Return "''"
        End If
        str = str.Replace("'", "''")
        Return (String.Format("'{0}'", str))


    End Function
    ''' <summary>
    ''' Menyamakan nilai (=)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Equal(ByVal Field As String, ByVal values As String) As String
        Return String.Format("{0}={1}", Field, values)
    End Function
    ''' <summary>
    ''' Tidak menyamakan Nilai 
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NotEqual(ByVal Field As String, ByVal values As String) As String
        Return String.Format("{0}<>{1}", Field, values)
    End Function
    ''' <summary>
    ''' Lebih Besar Dari
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GreaterThan(ByVal Field As String, ByVal values As String) As String
        Return String.Format("{0}>{1}", Field, values)
    End Function
    ''' <summary>
    ''' Lebih kecil dari 
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LessThan(ByVal Field As String, ByVal values As String) As String
        Return String.Format("{0}<{1}", Field, values)
    End Function
    ''' <summary>
    ''' Query Penghapusan
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QDelete(ByVal Tabel As String) As String
        Return String.Format("Delete from {0} ", Tabel)
    End Function
    ''' <summary>
    ''' Query Delete dengan where
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <param name="Field"></param>
    ''' <param name="Values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QDelete(ByVal Tabel As String, ByVal Field As String, ByVal Values As String) As String
        Return String.Format("Delete from {0} where {1}={2}", Tabel, Field, CSQL(Values))
    End Function
    Public Shared Function QDelete(ByVal Tabel As String, ByVal Field As String, ByVal Values As Integer) As String
        Return String.Format("Delete from {0} where {1}={2}", Tabel, Field, Values)
    End Function
    ''' <summary>
    ''' Query Pemilihan Smua kolom (*)
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QSelect(ByVal Tabel As String) As String
        Return String.Format("select * from {0} ", Tabel)
    End Function
    ''' <summary>
    ''' Menjumlahkan Nilai dalam satu kolom (SUM)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QSelectSUM(ByVal Field As String, ByVal Tabel As String) As String
        Return String.Format("select SUM({0}) as {0} from {1} ", Field, Tabel)
    End Function
    ''' <summary>
    ''' Mendapatkan Nilai Terbesar dari satu kolom (MAX)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QSelectMAX(ByVal Field As String, ByVal Tabel As String) As String
        Return String.Format("select MAX({0}) as {0} from {1} ", Field, Tabel)
    End Function
    ''' <summary>
    ''' Kriteria tahun saat ini
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="year"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EqualThisYear(ByVal Field As String, ByVal year As String) As String
        Return String.Format(" Year([{0}] = {1} ", Field, year)
    End Function
    ''' <summary>
    ''' Kriteria hari ini
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Day"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EqualThisDay(ByVal Field As String, ByVal Day As String) As String
        Return String.Format(" Year([{0}] = {1} ", Field, Day)
    End Function


    ''' <summary>
    ''' Mendapatkan nilai rata-rata dari satu kolom (AVERAGE)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QSelectAVG(ByVal Field As String, ByVal Tabel As String) As String
        Return String.Format("select AVG({0}) as {0} from {1} ", Field, Tabel)
    End Function
    ''' <summary>
    ''' Mendapatkan Nilai Terkecil dari satu kolom (MIN)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QSelectMIN(ByVal Field As String, ByVal Tabel As String) As String
        Return String.Format("select MIN({0}) as {0} from {1} ", Field, Tabel)
    End Function
    ''' <summary>
    ''' Minghitung jumlah baris (Count)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QSelectCOUNT(ByVal Field As String, ByVal Tabel As String) As String
        Return String.Format("select COUNT({0}) as {0} from {1} ", Field, Tabel)
    End Function
    ''' <summary>
    ''' No duplicate Collumn (Distinct)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QSelectDistinct(ByVal Field As String, ByVal Tabel As String) As String
        Return String.Format("select distinct({0}) as {0} from {1} ", Field, Tabel)
    End Function
    ''' <summary>
    ''' Query Pemilihan Dengan Field spesifik
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QSelect(ByVal Field As String, ByVal Tabel As String) As String
        Return String.Format("select {0} from {1} ", Field, Tabel)
    End Function
    ''' <summary>
    ''' Query Update
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <param name="Field"></param>
    ''' <param name="Values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QUpdate(ByVal Tabel As String, ByVal Field As ArrayList, ByVal Values As ArrayList) As String
        Dim strSET As String = ""
        If Values.Count <> Field.Count Then Throw New Exception("Field and valueas must match count")
        For i As Integer = 0 To Field.Count - 1
            If i < Field.Count - 1 Then
                strSET += Equal(Field(i), Values(i)) & ","
            Else
                strSET += Equal(Field(i), Values(i)) & " "
            End If
        Next
        Return String.Format("Update {0} set {1}", Tabel, strSET)
    End Function
    ''' <summary>
    ''' Penambahan awal Kriteria (Where)
    ''' </summary>
    ''' <param name="Syarat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AddCriteria(ByVal Syarat As String)
        Return String.Format("where {0} ", Syarat)
    End Function
    ''' <summary>
    ''' Kriteria (AND)
    ''' </summary>
    ''' <param name="Syarat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AddAndCriteria(ByVal Syarat As String)
        Return String.Format("AND {0} ", Syarat)
    End Function
    ''' <summary>
    ''' Kriteria (OR)
    ''' </summary>
    ''' <param name="Syarat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AddORCriteria(ByVal Syarat As String)
        Return String.Format("OR {0} ", Syarat)
    End Function
    ''' <summary>
    ''' Pengurutan dari terkecil (Order by ASC)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AddOrderASC(ByVal Field As String)
        Return String.Format(" Order by {0} ASC", Field)
    End Function
    ''' <summary>
    ''' Add Group by statement
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function addGroupBy(ByVal Field As String)
        Return " Group by " & Field
    End Function
    Public Shared Function QSUM(ByVal Field As String) As String
        Return String.Format(" Sum({0}) ", Field)
    End Function
    Public Shared Function Qcount(ByVal Field As String) As String
        Return String.Format(" count({0}) ", Field)
    End Function
    ''' <summary>
    ''' Pengurutan dari terbesar (order by DESC)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AddOrderDSC(ByVal Field As String)
        Return String.Format(" Order by {0} DESC", Field)
    End Function
    Public Shared Function QUpdate(ByVal Tabel As String, ByVal updated As String) As String
        Return String.Format("Update {0} set {1}", Tabel, updated)
    End Function
    ''' <summary>
    ''' Query Insert Data
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Qinsert(ByVal Tabel As String, ByVal values As String) As String
        Return String.Format("Insert into {0} values ({1})", Tabel, values)
    End Function
    ''' <summary>
    ''' Query Insert Values Only
    ''' </summary>
    ''' <param name="table"></param>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Qinsert(ByVal table As String, ByVal field As String, ByVal values As String) As String
        Return String.Format("Insert into {0} ({1}) values ({2})", table, field, values)
    End Function


    ''' <summary>
    ''' Query Insert Data
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Qinsert(ByVal Tabel As String, ByVal Field As ArrayList, ByVal values As ArrayList) As String
        Dim strSQL As String = ""
        Dim strField As String = ""
        Dim strValues As String = ""
        For i As Integer = 0 To Field.Count - 1
            If i = 0 Then
                If Field.Count = 1 Then
                    strField += String.Format("({0})", Field(i))
                    Exit For
                Else
                    strField += String.Format("({0},", Field(i))
                End If
            ElseIf i < Field.Count - 1 Then
                strField += Field(i).ToString & ","
            ElseIf i = Field.Count - 1 Then
                strField += Field(i).ToString & ")"
            End If
        Next
        For i As Integer = 0 To values.Count - 1
            If i = 0 Then
                If values.Count = 1 Then
                    strValues += String.Format("({0})", values(i))
                    Exit For
                Else
                    strValues += String.Format("({0},", values(i))
                End If

            ElseIf i < Field.Count - 1 Then
                strValues += values(i).ToString & ","
            ElseIf i = Field.Count - 1 Then
                strValues += values(i).ToString & ")"
            End If
        Next
        strSQL = String.Format("Insert into {0} {1} values {2}", Tabel, strField, strValues)
        Return strSQL
    End Function
#End Region
End Class
