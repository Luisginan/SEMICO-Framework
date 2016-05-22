Imports System.Data.OleDb
Imports Semico.ClsQB
Imports Semico.ClsQuickCode

Public Class ClsSqlOledb
    Implements IDisposable

#Region "Fields..."
    Private cmd As New OleDbCommand
    Private irows As Int64 = 0
    Private dt As New DataTable
    Private rowsAffected As Integer
    Private connection As New OleDbConnection
#End Region

#Region "property .. ."

    Public Property TimeOut() As Integer
        Get
            Return cmd.CommandTimeout
        End Get
        Set(ByVal value As Integer)
            cmd.CommandTimeout = value
        End Set
    End Property
    Public ReadOnly Property HasRows() As Boolean
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
    Default ReadOnly Property Item(ByVal idx As Integer) As Object
        Get
            Return ND(Table.Rows(irows).Item(idx))
        End Get
    End Property
    Default ReadOnly Property Item(ByVal FieldName As String) As Object
        Get
            Return Table.Rows(irows).Item(FieldName)
        End Get
    End Property
    Public ReadOnly Property Collumn() As DataRow
        Get
            Return Table.Rows(irows)
        End Get
    End Property
    Public ReadOnly Property RowCount() As Integer
        Get
            Return Table.Rows.Count
        End Get
    End Property
    Public ReadOnly Property Table() As DataTable
        Get
            Return dt
        End Get
    End Property
    Public Property StringQuery() As String
    Public Property Transaction() As Boolean
    Public Property ConnectionString() As String
    Public ReadOnly Property RowsEffected() As Integer
        Get
            Return rowsAffected
        End Get
    End Property
#End Region

#Region "Navigasi ..."

    Sub NextRow()
        If irows = RowCount - 1 Then Exit Sub
        irows += 1
    End Sub

    Sub PrevRow()
        If irows = 0 Then Exit Sub
        irows -= 1
    End Sub

    Sub MoveLastRow()
        irows = Table.Rows.Count - 1
    End Sub

    Sub MoveFirstRow()
        irows = 0
    End Sub

#End Region

#Region "Function.."
    Public Sub TestConnection()
        ValidasiConn()
    End Sub
    Public Function AutoNumberIfLastKey(ByVal Field As String, ByVal Tabel As String) As String
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

    ''' <summary>
    ''' Mendapatkan Auto Number untuk Kode Unik
    ''' </summary>
    ''' <returns>Kode Key Unik</returns>
    Public Function AutoNumber(ByVal Field As String, ByVal Tabel As String) As String
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
    Sub New(ByVal User As String, ByVal pass As String, ByVal server As String, ByVal DBname As String)
        ConnectionString = String.Format("Provider=SQLOLEDB.1;Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3}", pass, User, DBname, server)
    End Sub

    Sub New(ByVal KoneksiStringnya As String, Optional ByVal xTimeout As Integer = 0)
        ConnectionString = KoneksiStringnya
        If xTimeout > 0 Then TimeOut = xTimeout
    End Sub

    Public Function MultipleQuery(ByVal Querynya As ArrayList) As Integer
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

    Public Function Execute(ByVal StrKoneksi As String, ByVal strQuery As String) As DataTable
        ConnectionString = StrKoneksi
        If strQuery.ToUpper Like "SELECT*" Or strQuery.ToUpper Like "*EXEC*" Then
            dt = ViewDataManual(strQuery)
        Else
            ManualQuery(strQuery)
        End If
        dt = dt
        Return dt
    End Function

    Public Function Execute(Optional ByVal Query As String = "") As DataTable
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
    Sub BeginsTrans()
        If ConnectionString <> "" Then
            connection.ConnectionString = ConnectionString
        End If
        If connection.State = ConnectionState.Open Then connection.Close()
        connection.Open()
        cmd.Connection = connection
        cmd.Transaction = cmd.Connection.BeginTransaction()
        _Transaction = True
    End Sub

    Sub CommitTrans()
        _Transaction = False
        cmd.Transaction.Commit()
        connection.Close()
        cmd.Dispose()
    End Sub

    Sub RollBackTrans()
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

    ''' <summary>
    ''' Execute Query For Insert, Delete UPdate not for select
    ''' </summary>
    ''' <param name="Query">SQL Query</param>
    ''' <returns>Rows Affected by execute Query</returns>
    ''' <remarks></remarks>
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
        If ConnectionString <> "" Then
            Try
                connection.ConnectionString = ConnectionString
            Catch ex As Exception
                connection.ConnectionString = "Provider=SQLOLEDB;" & ConnectionString
            End Try
        End If
        connection.Open()
    End Sub

    Private Function ViewDataManual(ByVal Query As String) As DataTable
        Dim _temp As New DataTable
        Dim _oda As New OleDbDataAdapter
        _temp.TableName = "DT1"
        ValidasiConn()
        _StringQuery = Query
        cmd.CommandText = Query
        cmd.Connection = connection
        _oda.SelectCommand = cmd
        _oda.Fill(_temp)
        Dispose()
        irows = 0
        Return _temp
    End Function

#End Region

End Class