
Public Class ClsQBBase
    Implements IClsQBBase

#Region "SQLF ..."
    Public Function HSQL(ByVal str As String) As String Implements IClsQBBase.HSQL
        If IsNothing(str) Then
            Return ""
        ElseIf str = "" Then
            Return ""
        End If
        str = str.Replace("'", "''")
        Return (String.Format("{0}", str))
    End Function

    Public Function CSQL(ByVal str As String) As String Implements IClsQBBase.CSQL

        If IsNothing(str) Then
            Return "''"
        End If
        str = str.Replace("'", "''")
        Return (String.Format("'{0}'", str))


    End Function

    Public Function Equal(ByVal Field As String, ByVal values As String) As String Implements IClsQBBase.Equal
        Return String.Format("{0}={1}", Field, values)
    End Function

    Public Function NotEqual(ByVal Field As String, ByVal values As String) As String Implements IClsQBBase.NotEqual
        Return String.Format("{0}<>{1}", Field, values)
    End Function

    Public Function GreaterThan(ByVal Field As String, ByVal values As String) As String Implements IClsQBBase.GreaterThan
        Return String.Format("{0}>{1}", Field, values)
    End Function

    Public Function LessThan(ByVal Field As String, ByVal values As String) As String Implements IClsQBBase.LessThan
        Return String.Format("{0}<{1}", Field, values)
    End Function

    Public Function QDelete(ByVal Tabel As String) As String Implements IClsQBBase.QDelete
        Return String.Format("Delete from {0} ", Tabel)
    End Function

    Public Function QDelete(ByVal Tabel As String, ByVal Field As String, ByVal Values As String) As String Implements IClsQBBase.QDelete
        Return String.Format("Delete from {0} where {1}={2}", Tabel, Field, CSQL(Values))
    End Function
    Public Function QDelete(ByVal Tabel As String, ByVal Field As String, ByVal Values As Integer) As String Implements IClsQBBase.QDelete
        Return String.Format("Delete from {0} where {1}={2}", Tabel, Field, Values)
    End Function

    Public Function QSelect(ByVal Tabel As String) As String Implements IClsQBBase.QSelect
        Return String.Format("select * from {0} ", Tabel)
    End Function

    Public Function QSelectSUM(ByVal Field As String, ByVal Tabel As String) As String Implements IClsQBBase.QSelectSUM
        Return String.Format("select SUM({0}) as {0} from {1} ", Field, Tabel)
    End Function

    Public Function QSelectMAX(ByVal Field As String, ByVal Tabel As String) As String Implements IClsQBBase.QSelectMAX
        Return String.Format("select MAX({0}) as {0} from {1} ", Field, Tabel)
    End Function

    Public Function EqualThisYear(ByVal Field As String, ByVal year As String) As String Implements IClsQBBase.EqualThisYear
        Return String.Format(" Year([{0}] = {1} ", Field, year)
    End Function

    Public Function EqualThisDay(ByVal Field As String, ByVal Day As String) As String Implements IClsQBBase.EqualThisDay
        Return String.Format(" Year([{0}] = {1} ", Field, Day)
    End Function



    Public Function QSelectAVG(ByVal Field As String, ByVal Tabel As String) As String Implements IClsQBBase.QSelectAVG
        Return String.Format("select AVG({0}) as {0} from {1} ", Field, Tabel)
    End Function

    Public Function QSelectMIN(ByVal Field As String, ByVal Tabel As String) As String Implements IClsQBBase.QSelectMIN
        Return String.Format("select MIN({0}) as {0} from {1} ", Field, Tabel)
    End Function

    Public Function QSelectCOUNT(ByVal Field As String, ByVal Tabel As String) As String Implements IClsQBBase.QSelectCOUNT
        Return String.Format("select COUNT({0}) as {0} from {1} ", Field, Tabel)
    End Function

    Public Function QSelectDistinct(ByVal Field As String, ByVal Tabel As String) As String Implements IClsQBBase.QSelectDistinct
        Return String.Format("select distinct({0}) as {0} from {1} ", Field, Tabel)
    End Function

    Public Function QSelect(ByVal Field As String, ByVal Tabel As String) As String Implements IClsQBBase.QSelect
        Return String.Format("select {0} from {1} ", Field, Tabel)
    End Function

    Public Function QUpdate(ByVal Tabel As String, ByVal Field As ArrayList, ByVal Values As ArrayList) As String Implements IClsQBBase.QUpdate
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

    Public Function AddCriteria(ByVal Syarat As String) Implements IClsQBBase.AddCriteria
        Return String.Format("where {0} ", Syarat)
    End Function

    Public Function AddAndCriteria(ByVal Syarat As String) Implements IClsQBBase.AddAndCriteria
        Return String.Format("AND {0} ", Syarat)
    End Function

    Public Function AddORCriteria(ByVal Syarat As String) Implements IClsQBBase.AddORCriteria
        Return String.Format("OR {0} ", Syarat)
    End Function

    Public Function AddOrderASC(ByVal Field As String) Implements IClsQBBase.AddOrderASC
        Return String.Format(" Order by {0} ASC", Field)
    End Function

    Public Function addGroupBy(ByVal Field As String) Implements IClsQBBase.addGroupBy
        Return " Group by " & Field
    End Function
    Public Function QSUM(ByVal Field As String) As String Implements IClsQBBase.QSUM
        Return String.Format(" Sum({0}) ", Field)
    End Function
    Public Function Qcount(ByVal Field As String) As String Implements IClsQBBase.Qcount
        Return String.Format(" count({0}) ", Field)
    End Function

    Public Function AddOrderDSC(ByVal Field As String) Implements IClsQBBase.AddOrderDSC
        Return String.Format(" Order by {0} DESC", Field)
    End Function
    Public Function QUpdate(ByVal Tabel As String, ByVal updated As String) As String Implements IClsQBBase.QUpdate
        Return String.Format("Update {0} set {1}", Tabel, updated)
    End Function

    Public Function Qinsert(ByVal Tabel As String, ByVal values As String) As String Implements IClsQBBase.Qinsert
        Return String.Format("Insert into {0} values ({1})", Tabel, values)
    End Function

    Public Function Qinsert(ByVal table As String, ByVal field As String, ByVal values As String) As String Implements IClsQBBase.Qinsert
        Return String.Format("Insert into {0} ({1}) values ({2})", table, field, values)
    End Function

    Public Function Qinsert(ByVal Tabel As String, ByVal Field As ArrayList, ByVal values As ArrayList) As String Implements IClsQBBase.Qinsert
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
