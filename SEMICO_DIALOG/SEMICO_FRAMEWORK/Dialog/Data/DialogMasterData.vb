Imports Semico.ClsQB_SQL
Imports Semico.ClsMessageDialog

Public Class DialogMasterData
    Public Property Title As String
    Public Property ConnectionString As String
    Private Table As SEMICO_Table
    Private conn As New ClsSqlOledb
    Private QueryString As String = ""
    Public Property TotalField As String = ""
    Public Property InputForm As Object

    Private ReadOnly Property ID As String
        Get
            Return GV.CurrentRow.Cells(Table.FieldKey).Value
        End Get
    End Property

    Private Sub BuildQueryString()
        QueryString = QSelect(Table.TableName)
        If Table.FieldCriteria.Count > 0 Then
            QueryString += " Where ("
            For i As Integer = 0 To Table.FieldCriteria.Count - 1
                Dim f = Table.FieldCriteria(i)
                If i = 0 Then QueryString += LIKES(f, "{0}")
                QueryString += AddORCriteria(LIKES(f, "{0}"))
            Next
            QueryString += ")"
        Else
            WarnMessage("Criteria Required")
            Close()
        End If
    End Sub

    Sub New(_ConnectionString As String, _Table As SEMICO_Table, Optional filter As String = "")
        InitializeComponent()
        ConnectionString = _ConnectionString
        conn = New ClsSqlOledb(ConnectionString)
        Table = _Table
        BuildQueryString()
        QueryString += filter
    End Sub

    Private Sub CountAndShowTotalField()
        If TotalField = "" Then
            lblTotal.Visible = False
            lblTotalText.Visible = False
            Exit Sub
        End If
        Dim total As Double = 0
        For Each col As DataGridViewRow In GV.Rows
            total += col.Cells(TotalField).Value
        Next
        lblTotal.Text = total.ToString("###,00")
    End Sub
    Private Sub LoadData()
        GV.AutoGenerateColumns = False
        Dim tsearch = HSQL(txtSearch.Text)
        conn.StringQuery = String.Format(QueryString, tsearch)
        Dim data = conn.Execute
        GV.DataSource = data
        Me.Text = String.Format("{0} ::. {1} Record ", Title, GV.Rows.Count)
        CountAndShowTotalField()
    End Sub

    Private Sub DialogMasterData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim source As New ClsImageAndSound
        source.SetImagesForm(Me, btnClear)
        CreateFieldGrid()
        LoadData()
        If Title = "" Then Title = Table.TableName
    End Sub

    Private Sub CreateFieldGrid()
        If Table.Field.Count = 0 Then Throw New Exception("Field not set")
        If Table.FieldKey = "" Then Throw New Exception("Field Key not set")

        Dim Field = Table.Field
        Dim FieldCaption = Table.FieldCaption
        Dim FieldKey = Table.FieldKey

        If FieldCaption.Count = 0 Then
            FieldCaption = Field
        End If

        For i As Byte = 0 To Field.Count - 1
            Using CLM As New DataGridViewTextBoxColumn() With {.HeaderText = FieldCaption(i), _
                                                               .DataPropertyName = Field(i), _
                                                               .Name = Field(i), _
                                                               .ReadOnly = True}
                GV.Columns.AddRange(New DataGridViewColumn() {CLM})
            End Using
        Next

        If FieldKey <> "" Then
            Using CLM As New DataGridViewTextBoxColumn() With {.HeaderText = FieldKey, _
                                                               .DataPropertyName = FieldKey, _
                                                               .Name = FieldKey, .ReadOnly = True, _
                                                               .Visible = False}
                GV.Columns.AddRange(New DataGridViewColumn() {CLM})
            End Using
        End If

        Using CLM As New DataGridViewButtonColumn() With {.Text = "Edit", .Name = "Edit", .HeaderText = "", .UseColumnTextForButtonValue = True}
            GV.Columns.AddRange(New DataGridViewColumn() {CLM})
        End Using
        Using CLM As New DataGridViewButtonColumn() With {.Text = "Delete", .Name = "Delete", .HeaderText = "", .UseColumnTextForButtonValue = True}
            GV.Columns.AddRange(New DataGridViewColumn() {CLM})
        End Using
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        InputForm.id = ""
        InputForm.showDialog()
        LoadData()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GV.CellMouseClick
        If e.ColumnIndex = GV.ColumnCount - 1 Then
            If AskMessage("Are you sure delete this data?") = Windows.Forms.DialogResult.Yes Then
                conn.StringQuery = QDelete(Table.TableNameOriginal, Table.FieldKey, ID)
                conn.Execute()
                LoadData()
            End If
        ElseIf e.ColumnIndex = GV.ColumnCount - 2 Then
            InputForm.id = ID
            InputForm.showDialog()
            LoadData()
        End If
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadData()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtSearch.Clear()
        LoadData()
    End Sub

End Class