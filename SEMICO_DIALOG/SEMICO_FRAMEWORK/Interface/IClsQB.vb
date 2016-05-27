Public Interface IClsQB
    Inherits IClsQBBase
    Property TimeOut() As Integer
    ReadOnly Property HasRows() As Boolean
    Default ReadOnly Property Item(ByVal idx As Integer) As Object
    Default ReadOnly Property Item(ByVal FieldName As String) As Object
    ReadOnly Property Collumn() As DataRow
    ReadOnly Property RowCount() As Integer
    ReadOnly Property Table() As DataTable
    Property StringQuery() As String
    Property Transaction() As Boolean
    Property ConnectionString() As String
    ReadOnly Property RowsEffected() As Integer
    Sub NextRow()
    Sub PrevRow()
    Sub MoveLastRow()
    Sub MoveFirstRow()
    Sub TestConnection()
    Function AutoNumberIfLastKey(ByVal Field As String, ByVal Tabel As String) As String

    ''' <summary>
    ''' Mendapatkan Auto Number untuk Kode Unik
    ''' </summary>
    ''' <returns>Kode Key Unik</returns>
    Function AutoNumber(ByVal Field As String, ByVal Tabel As String) As String

    Function MultipleQuery(ByVal Querynya As List(Of String)) As Integer
    Function Execute(Optional ByVal Query As String = "") As DataTable
    Sub BeginsTrans()
    Sub CommitTrans()
    Sub RollBackTrans()
End Interface