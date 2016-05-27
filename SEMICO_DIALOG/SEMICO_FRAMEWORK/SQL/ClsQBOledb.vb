Imports System.Data.Common
Imports System.Data.OleDb
Imports Semico.ClsQBBase
Imports Semico.ClsQuickCode

Public Class ClsQBOledb
    Inherits ClsQBBase
    Implements IDisposable
    Implements IClsQB

#Region "Fields..."
    Private cmd As IDbCommand
    Private irows As Int64 = 0
    Private dt As New DataTable
    Private rowsAffected As Integer
    Private connection As IDbConnection
    Private dataAdapter As IDbDataAdapter
#End Region

#Region "property .. ."

    Public Property TimeOut() As Integer Implements IClsQB.TimeOut
        Get
            Return cmd.CommandTimeout
        End Get
        Set(ByVal value As Integer)
            cmd.CommandTimeout = value
        End Set
    End Property
    Public ReadOnly Property HasRows() As Boolean Implements IClsQB.HasRows
        Get
            Dim temp As Boolean = False
            If RowCount > 0 Then
                temp = True
            Else
                temp = False
            End If
            Return temp
        End Get
    End Property
    Default Public ReadOnly Property Item(ByVal idx As Integer) As Object Implements IClsQB.Item
        Get
            Return ND(Table.Rows(irows).Item(idx))
        End Get
    End Property
    Default Public ReadOnly Property Item(ByVal FieldName As String) As Object Implements IClsQB.Item
        Get
            Return Table.Rows(irows).Item(FieldName)
        End Get
    End Property
    Public ReadOnly Property Collumn() As DataRow Implements IClsQB.Collumn
        Get
            Return Table.Rows(irows)
        End Get
    End Property
    Public ReadOnly Property RowCount() As Integer Implements IClsQB.RowCount
        Get
            Return Table.Rows.Count
        End Get
    End Property
    Public ReadOnly Property Table() As DataTable Implements IClsQB.Table
        Get
            Return dt
        End Get
    End Property
    Public Property StringQuery() As String Implements IClsQB.StringQuery
    Public Property Transaction() As Boolean Implements IClsQB.Transaction

    Public ReadOnly Property RowsEffected() As Integer Implements IClsQB.RowsEffected
        Get
            Return rowsAffected
        End Get
    End Property
#End Region

#Region "Navigation ..."

    Public Sub NextRow() Implements IClsQB.NextRow
        If irows = RowCount - 1 Then Exit Sub
        irows += 1
    End Sub

    Public Sub PrevRow() Implements IClsQB.PrevRow
        If irows = 0 Then Exit Sub
        irows -= 1
    End Sub

    Public Sub MoveLastRow() Implements IClsQB.MoveLastRow
        irows = Table.Rows.Count - 1
    End Sub

    Public Sub MoveFirstRow() Implements IClsQB.MoveFirstRow
        irows = 0
    End Sub

#End Region

#Region "Function.."
    Public Sub TestConnection() Implements IClsQB.TestConnection
        ValidasiConn()
    End Sub
    Public Function AutoNumberIfLastKey(ByVal Field As String, ByVal Tabel As String) As String Implements IClsQB.AutoNumberIfLastKey
        Dim temp As String
        StringQuery = QSelect(Field, Tabel)
        Execute()
        If RowCount = 0 Then
            Return ""
            Exit Function
        End If
        Dim NilaiMax As Integer = 0
        Dim StartIndex As Integer = GetIndexNumeric(Collumn(Field).ToString)
        Dim tempField As String = ""
        Dim tempString As String = Collumn(Field).ToString.Substring(0, StartIndex)
        MoveLastRow()
        Dim tempkolom As String = Collumn(Field).ToString
        Dim batasKolom As Integer = Collumn(Field).ToString.Length - StartIndex
        tempField = tempkolom.Substring(StartIndex, batasKolom)
        NilaiMax = CInt(tempField)
        NilaiMax += 1
        temp = tempString & GetNol((Collumn(Field).ToString.Length) - NilaiMax.ToString.Length - StartIndex) & NilaiMax.ToString
        irows = 0
        Return temp
    End Function


    Public Function AutoNumber(ByVal Field As String, ByVal Tabel As String) As String Implements IClsQB.AutoNumber
        Dim temp As String
        StringQuery = QSelect(Field, Tabel)
        Execute()
        If RowCount = 0 Then
            Return ""
            Exit Function
        End If
        Dim NilaiMax As Integer = 0
        Dim StartIndex As Integer = GetIndexNumeric(Collumn(Field).ToString)
        Dim tempField As String = ""
        Dim tempString As String = Collumn(Field).ToString.Substring(0, StartIndex)
        For i As Integer = 0 To RowCount - 1
            Dim tempkolom As String = Collumn(Field).ToString
            Dim batasKolom As Integer = Collumn(Field).ToString.Length - StartIndex
            tempField = tempkolom.Substring(StartIndex, batasKolom)
            If CInt(tempField) > NilaiMax Then
                NilaiMax = CInt(tempField)
            End If
            NextRow()
        Next
        NilaiMax += 1
        temp = tempString & GetNol((Collumn(Field).ToString.Length) - NilaiMax.ToString.Length - StartIndex) & NilaiMax.ToString
        irows = 0
        Return temp
    End Function

#End Region

#Region "Action ..."

    Sub New()

    End Sub

    Sub New(dbComponent As DBComponent, Optional ByVal xTimeout As Integer = 0)
        cmd = dbComponent.dbCommand
        connection = dbComponent.dbConnection
        dataAdapter = dbComponent.dbAdapter
        If xTimeout > 0 Then TimeOut = xTimeout
    End Sub

    Public Function MultipleQuery(ByVal Querynya As List(Of String)) As Integer Implements IClsQB.MultipleQuery
        Dim i As Byte = 0
        Dim rc As Integer = 0
        Dim batas As Byte
        ValidasiConn()
        cmd.Connection = connection
        Try
            cmd.Transaction = cmd.Connection.BeginTransaction
            batas = Querynya.Count
            For i = 0 To batas - 1
                cmd.CommandText = Querynya.Item(i).ToString
                rc += cmd.ExecuteNonQuery()
            Next
            cmd.Transaction.Commit()
            Dispose()
        Catch ex As Exception
            cmd.Transaction.Rollback()
            rc = 0
        End Try
        rowsAffected = rc
        Return rc
    End Function

    Public Function Execute(Optional ByVal Query As String = "") As DataTable Implements IClsQB.Execute
        If Query = "" Then Query = StringQuery
        If Query = "" Then Throw New ArgumentException("Query not Set")
        If Query.ToUpper Like "SELECT*" Or Query.ToUpper Like "*EXEC*" Then
            dt = ViewDataManual(Query)
        Else
            ManualQuery(Query)
        End If
        Return dt
    End Function

#End Region

#Region "Transaction ..."

    Public Sub BeginsTrans() Implements IClsQB.BeginsTrans

        If connection.State = ConnectionState.Open Then connection.Close()
        connection.Open()
        cmd.Connection = connection
        cmd.Transaction = cmd.Connection.BeginTransaction()
        _Transaction = True
    End Sub

    Public Sub CommitTrans() Implements IClsQB.CommitTrans
        _Transaction = False
        cmd.Transaction.Commit()
        connection.Close()
        cmd.Dispose()
    End Sub

    Public Sub RollBackTrans() Implements IClsQB.RollBackTrans
        _Transaction = False
        cmd.Transaction.Rollback()
        connection.Close()
        cmd.Dispose()
    End Sub

#End Region

#Region "Private..."

    Private Function GetNol(ByVal CountZero As String) As String
        Dim temp As String = ""
        For i As Integer = 0 To CountZero - 1
            temp += "0"
        Next
        Return temp
    End Function

    Private Function GetIndexNumeric(ByVal Str As String) As Integer
        Dim temp As Integer
        For i As Integer = 0 To Str.Length - 1
            temp = i
            If IsNumeric(Str.Substring(i, 1)) = True Then
                Exit For
            End If
        Next
        Return temp
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        If _Transaction = True Then Exit Sub
        dt.Dispose()
        connection.Close()
        connection.Dispose()
        cmd.Dispose()
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        Dispose()
    End Sub


    Private Function ManualQuery(ByVal Query As String) As Integer
        Dim temp As Integer = 0
        ValidasiConn()
        _StringQuery = Query
        cmd.Connection = connection
        cmd.CommandText = Query
        cmd.CommandTimeout = TimeOut
        temp = cmd.ExecuteNonQuery()
        rowsAffected = temp
        Dispose()
        Return temp
    End Function

    Private Sub ValidasiConn()
        If _Transaction = True Then Exit Sub
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If

        connection.Open()
    End Sub

    Private Function ViewDataManual(ByVal Query As String) As DataTable
        Dim _temp As New DataTable
        _temp.TableName = "DT1"
        ValidasiConn()
        _StringQuery = Query
        cmd.CommandText = Query
        cmd.Connection = connection
        dataAdapter.SelectCommand = cmd
        Dim dataSet As New DataSet()
        dataAdapter.Fill(dataSet)
        Dispose()
        irows = 0
        Return dataSet.Tables(0)
    End Function

#End Region

End Class