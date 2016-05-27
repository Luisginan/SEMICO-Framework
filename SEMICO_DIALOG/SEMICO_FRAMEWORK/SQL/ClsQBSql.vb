
Public Class ClsQBSql
#Region "SQLF ..."
    Inherits ClsQB
    ''' <summary>
    ''' Luis : Menyamakan Tanggal di server
    ''' menjadi Format = 'yyyy-MM-dd'
    ''' </summary>
    ''' <param name="DateField"></param>
    ''' <param name="DateValues"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EqualDate(ByVal DateField As String, ByVal DateValues As Date)
        Return String.Format("convert(char(10),{0},20)={1}", DateField, CSQL(DateValues.ToString("yyyy-MM-dd")))
    End Function

    ''' <summary>
    ''' Query Kriteria Like Comvert to String
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LIKESfix(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("CAST({0} AS Varchar) LIKE '%{1}%' ", Field, values)
    End Function
    Public Shared Function LIKES(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("{0} LIKE '%{1}%' ", Field, values)
    End Function
    ''' <summary>
    ''' Query kriteria Like First
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FirstLIKESfix(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("CAST({0} AS Varchar) LIKE '{1}%' ", Field, values)
    End Function
    Public Shared Function FirstLIKES(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("{0}  LIKE '{1}%' ", Field, values)
    End Function
    ''' <summary>
    ''' Query kriteria Last Like
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LastLIKESfix(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("CAST({0} AS Varchar) LIKE '%{1}' ", Field, values)
    End Function
    Public Shared Function LastLIKES(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("{0} LIKE '%{1}' ", Field, values)
    End Function
    ''' <summary>
    ''' Luis : Memformat tanggal tanpa jam
    ''' Menjadi Format = 'yyyy-MM-dd'
    ''' </summary>
    ''' <param name="tanggal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CSQLdate(ByVal tanggal As Date) As String
        Return String.Format("'{0}'", Format(tanggal, "yyyy-MM-dd"))
    End Function

    ''' <summary>
    ''' Luis : formatan pembanding tanggal di server
    ''' menjadi format 'yyyy-MM-dd' between 'yyyy-MM-dd' and 'yyyy-MM-dd'
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="tgl1"></param>
    ''' <param name="tgl2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BetweenDate(ByVal Field As String, ByVal tgl1 As Date, ByVal tgl2 As Date) As String
        Return String.Format("convert(char(10),{0},20) between {1} and {2}", Field, CSQLdate(tgl1.ToString), CSQLdate(tgl2.ToString))
    End Function

    ''' <summary>
    ''' Kriteria hari ini (Jam server)
    ''' </summary>
    ''' <param name="DateField"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EqualDateToday(ByVal DateField As String)
        Return String.Format("convert(char(10),{0},20)=convert(char(10),getdate(),20)", DateField)
    End Function

    Public Shared Function EqualThisMonth(ByVal DateField As String) As String
        Return String.Format(" Month([{0}]) = month(getdate()) and year([{0}]) =  year(getdate())", DateField)
    End Function

    ''' <summary>
    ''' Kriteria bulan yang spesifik , year tidak diisi berarti tahun sekarang
    ''' </summary>
    ''' <param name="DateField">Field Tanggal didatabase</param>
    ''' <param name="year">Tahun yang diinginkan (Optional)</param>
    ''' <returns>String Kriteria</returns>
    ''' <remarks></remarks>
    Public Shared Function EqualSpecMonth(ByVal DateField As String, Optional ByVal year As Integer = 0) As String
        Dim temp As String = ""
        If year <> 0 Then
            temp = String.Format(" Month([{0}]) = month(getdate()) and  and year([{0}]) =  year(getdate())", DateField)
        Else
            temp = String.Format(" Month([{0}]) = month(getdate()) and  and year([{0}]) = {1}", DateField, year)
        End If

        Return temp
    End Function

    Public Shared Function QSelectPages(Field As String, ByVal Tabel As String, startIndex As Integer, Lengthx As Integer, Optional Criteria As String = "", Optional WithNumberRow As Boolean = False) As String
        Dim RowNumber = ""
        If WithNumberRow = True Then RowNumber = "sub.RowIndex AS RowIndex ,"

        Dim SQL = String.Format("select {0} {1} from (select Row_Number() over (order by {1}) as RowIndex, * from {2} {3} ) as Sub Where Sub.RowIndex >= {4} and Sub.RowIndex < {5}", RowNumber, Field, Tabel, Criteria, startIndex, startIndex + Lengthx)
        Return SQL
    End Function

#End Region
End Class
