Public interface IClsQBBase
    Function HSQL(ByVal str As String) As String

    ''' <summary>
    ''' Luis : Menterjemahkan String VB ke SQLserver
    ''' Menjadi Format dari "Luis" diubah 'Luis'
    ''' dan sudah menangani kutip ' di string
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CSQL(ByVal str As String) As String

    ''' <summary>
    ''' Menyamakan nilai (=)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Equal(ByVal Field As String, ByVal values As String) As String

    ''' <summary>
    ''' Tidak menyamakan Nilai 
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function NotEqual(ByVal Field As String, ByVal values As String) As String

    ''' <summary>
    ''' Lebih Besar Dari
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GreaterThan(ByVal Field As String, ByVal values As String) As String

    ''' <summary>
    ''' Lebih kecil dari 
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function LessThan(ByVal Field As String, ByVal values As String) As String

    ''' <summary>
    ''' Query Penghapusan
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QDelete(ByVal Tabel As String) As String

    ''' <summary>
    ''' Query Delete dengan where
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <param name="Field"></param>
    ''' <param name="Values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QDelete(ByVal Tabel As String, ByVal Field As String, ByVal Values As String) As String

    Function QDelete(ByVal Tabel As String, ByVal Field As String, ByVal Values As Integer) As String

    ''' <summary>
    ''' Query Pemilihan Smua kolom (*)
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QSelect(ByVal Tabel As String) As String

    ''' <summary>
    ''' Menjumlahkan Nilai dalam satu kolom (SUM)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QSelectSUM(ByVal Field As String, ByVal Tabel As String) As String

    ''' <summary>
    ''' Mendapatkan Nilai Terbesar dari satu kolom (MAX)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QSelectMAX(ByVal Field As String, ByVal Tabel As String) As String

    ''' <summary>
    ''' Kriteria tahun saat ini
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="year"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function EqualThisYear(ByVal Field As String, ByVal year As String) As String

    ''' <summary>
    ''' Kriteria hari ini
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Day"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function EqualThisDay(ByVal Field As String, ByVal Day As String) As String

    ''' <summary>
    ''' Mendapatkan nilai rata-rata dari satu kolom (AVERAGE)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QSelectAVG(ByVal Field As String, ByVal Tabel As String) As String

    ''' <summary>
    ''' Mendapatkan Nilai Terkecil dari satu kolom (MIN)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QSelectMIN(ByVal Field As String, ByVal Tabel As String) As String

    ''' <summary>
    ''' Minghitung jumlah baris (Count)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QSelectCOUNT(ByVal Field As String, ByVal Tabel As String) As String

    ''' <summary>
    ''' No duplicate Collumn (Distinct)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QSelectDistinct(ByVal Field As String, ByVal Tabel As String) As String

    ''' <summary>
    ''' Query Pemilihan Dengan Field spesifik
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Tabel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QSelect(ByVal Field As String, ByVal Tabel As String) As String

    ''' <summary>
    ''' Query Update
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <param name="Field"></param>
    ''' <param name="Values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QUpdate(ByVal Tabel As String, ByVal Field As ArrayList, ByVal Values As ArrayList) As String

    ''' <summary>
    ''' Penambahan awal Kriteria (Where)
    ''' </summary>
    ''' <param name="Syarat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AddCriteria(ByVal Syarat As String)

    ''' <summary>
    ''' Kriteria (AND)
    ''' </summary>
    ''' <param name="Syarat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AddAndCriteria(ByVal Syarat As String)

    ''' <summary>
    ''' Kriteria (OR)
    ''' </summary>
    ''' <param name="Syarat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AddORCriteria(ByVal Syarat As String)

    ''' <summary>
    ''' Pengurutan dari terkecil (Order by ASC)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AddOrderASC(ByVal Field As String)

    ''' <summary>
    ''' Add Group by statement
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function addGroupBy(ByVal Field As String)

    Function QSUM(ByVal Field As String) As String
    Function Qcount(ByVal Field As String) As String

    ''' <summary>
    ''' Pengurutan dari terbesar (order by DESC)
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AddOrderDSC(ByVal Field As String)

    Function QUpdate(ByVal Tabel As String, ByVal updated As String) As String

    ''' <summary>
    ''' Query Insert Data
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Qinsert(ByVal Tabel As String, ByVal values As String) As String

    ''' <summary>
    ''' Query Insert Values Only
    ''' </summary>
    ''' <param name="table"></param>
    ''' <param name="field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Qinsert(ByVal table As String, ByVal field As String, ByVal values As String) As String

    ''' <summary>
    ''' Query Insert Data
    ''' </summary>
    ''' <param name="Tabel"></param>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Qinsert(ByVal Tabel As String, ByVal Field As ArrayList, ByVal values As ArrayList) As String
end interface