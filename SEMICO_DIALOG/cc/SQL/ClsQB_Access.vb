
Public Class ClsQB_Access
    Inherits ClsQB
#Region "SQLF ..."

    ''' <summary>
    ''' Luis : Menyamakan Tanggal di server untuk access
    ''' menjadi Format = 'yyyy-MM-dd' 
    ''' </summary>
    ''' <param name="DateField"></param>
    ''' <param name="DateValues"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EqualDate(ByVal DateField As String, ByVal DateValues As Date)
        Return String.Format("{0}=#{1:yyyy-MM-dd}#", DateField, DateValues)
    End Function
    ''' <summary>
    ''' Like '* *'
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LIKES(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("{0} LIKE '*{1}*' ", Field, values)
    End Function

    Public Shared Function FirstLIKES(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("{0}  LIKE '{1}*' ", Field, values)
    End Function

    Public Shared Function LastLIKES(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("{0} LIKE '*{1}' ", Field, values)
    End Function

    Public Shared Function CSQLDate(ByVal tanggal As Date) As String
        Return String.Format("#{0}#", Format(tanggal, "yyyy-MM-dd"))
    End Function


    Public Shared Function BetweenDate(ByVal Field As String, ByVal Date1 As Date, ByVal Date2 As Date) As String
        Return String.Format("{0} between {1} and {2}", Field, CSQLDate(Date1.ToString), CSQLDate(Date2.ToString))
    End Function

    Public Shared Function EqualDateToday(ByVal DateField As String)
        Return DateField & "= date()"
    End Function

    Public Shared Function EqualThisMonth(ByVal DateField As String) As String
        Return String.Format(" Month([{0}]) = month(date()) and year([{0}]) =  year(date())", DateField)
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
            temp = String.Format(" Month([{0}]) = month(date()) and  and year([{0}]) =  year(date())", DateField)
        Else
            temp = String.Format(" Month([{0}]) = month(date()) and  and year([{0}]) = {1}", DateField, year)
        End If

        Return temp
    End Function
#End Region
End Class
