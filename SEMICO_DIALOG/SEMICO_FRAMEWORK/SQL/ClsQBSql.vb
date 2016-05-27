
Public Class ClsQBSql
#Region "SQLF ..."
    Inherits ClsQBOledb
    Implements IClsQB

    Public Function EqualDate(ByVal DateField As String, ByVal DateValues As Date)
        Return String.Format("convert(char(10),{0},20)={1}", DateField, CSQL(DateValues.ToString("yyyy-MM-dd")))
    End Function


    Public Function LIKESfix(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("CAST({0} AS Varchar) LIKE '%{1}%' ", Field, values)
    End Function
    Public Function LIKES(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("{0} LIKE '%{1}%' ", Field, values)
    End Function

    Public Function FirstLIKESfix(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("CAST({0} AS Varchar) LIKE '{1}%' ", Field, values)
    End Function
    Public Function FirstLIKES(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("{0}  LIKE '{1}%' ", Field, values)
    End Function

    Public Function LastLIKESfix(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("CAST({0} AS Varchar) LIKE '%{1}' ", Field, values)
    End Function
    Public Function LastLIKES(ByVal Field As String, ByVal values As String) As String
        values = values.Replace("'", "''")
        Return String.Format("{0} LIKE '%{1}' ", Field, values)
    End Function

    Public Function CSQLdate(ByVal tanggal As Date) As String
        Return String.Format("'{0}'", Format(tanggal, "yyyy-MM-dd"))
    End Function


    Public Function BetweenDate(ByVal Field As String, ByVal tgl1 As Date, ByVal tgl2 As Date) As String
        Return String.Format("convert(char(10),{0},20) between {1} and {2}", Field, CSQLdate(tgl1.ToString), CSQLdate(tgl2.ToString))
    End Function


    Public Function EqualDateToday(ByVal DateField As String)
        Return String.Format("convert(char(10),{0},20)=convert(char(10),getdate(),20)", DateField)
    End Function

    Public Function EqualThisMonth(ByVal DateField As String) As String
        Return String.Format(" Month([{0}]) = month(getdate()) and year([{0}]) =  year(getdate())", DateField)
    End Function


    Public Function EqualSpecMonth(ByVal DateField As String, Optional ByVal year As Integer = 0) As String
        Dim temp As String = ""
        If year <> 0 Then
            temp = String.Format(" Month([{0}]) = month(getdate()) and  and year([{0}]) =  year(getdate())", DateField)
        Else
            temp = String.Format(" Month([{0}]) = month(getdate()) and  and year([{0}]) = {1}", DateField, year)
        End If

        Return temp
    End Function

    Public Function QSelectPages(Field As String, ByVal Tabel As String, startIndex As Integer, Lengthx As Integer, Optional Criteria As String = "", Optional WithNumberRow As Boolean = False) As String
        Dim RowNumber = ""
        If WithNumberRow = True Then RowNumber = "sub.RowIndex AS RowIndex ,"

        Dim SQL = String.Format("select {0} {1} from (select Row_Number() over (order by {1}) as RowIndex, * from {2} {3} ) as Sub Where Sub.RowIndex >= {4} and Sub.RowIndex < {5}", RowNumber, Field, Tabel, Criteria, startIndex, startIndex + Lengthx)
        Return SQL
    End Function

#End Region
End Class
