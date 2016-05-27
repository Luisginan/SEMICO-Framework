Imports Semico.ClsMessageDialog
Imports Semico.ClsQB_SQL

Public Class DialogFindData
    Implements Dialog

    Private _Value As String = "-"
    Private _StrSQL As String = ""
    Private _Strfields As String = ""
    Private _IntItem As Integer
    Private _SMC As ClsSqlOledb
    Private _cancel As Boolean

    Private Property rowsCount As Double
    Private _StrQuery As String = ""
    Private ReadOnly Property StrQuery() As String
        Get
            _StrQuery = QSelectPages(String.Format("{0},{1}", Field1, Field2), _
                                     Table, _
                                     PageIndex, _
                                     PageCount, _
                                     IIf(txtSearchBox.Text = "", "", "Where " & FirstLIKES(_Strfields, txtSearchBox.Text)) & IIf(Criteria = "", "", " and  " & Criteria), True)
            Return _StrQuery
        End Get
    End Property
    Private ReadOnly Property StrQueryCount() As String
        Get
            _StrQuery = QSelectCOUNT(Field1, Table) & IIf(txtSearchBox.Text = "", "", String.Format(" Where {0} like '{1}%'", _Strfields, txtSearchBox.Text)) & IIf(Criteria = "", "", " and  " & Criteria)
            Return _StrQuery
        End Get
    End Property
    Private PageIndex As Integer = 1
    Public Property PageCount As Integer = 30
    Public Property Criteria() As String
    Public Property IndexSearchCollumnFocus As Integer = 0
    Public Property AutoQuery() As Boolean
    Public ReadOnly Property Value() As String
        Get
            Return _Value
        End Get
    End Property
    Public Property FieldCollection() As List(Of String)
    Public Property Field1() As String = ""
    Public Property Field2() As String = ""
    Public Property Tips() As String
        Get
            Return txtTips.Text
        End Get
        Set(ByVal value As String)
            txtTips.Text = value
        End Set
    End Property
    Public Property StringConection() As String = ""
    Private _hasValue As Boolean
    Public ReadOnly Property HasValue() As Boolean
        Get
            Return _hasValue
        End Get
    End Property
    Private _title As String = ""
    Public Property TITLE() As String
        Get
            If _title = "" Then
                Return "Find " & Table
            Else
                Return _title
            End If
        End Get
        Set(value As String)
            _title = value
        End Set
    End Property
    Public Property Table() As String
    Public Property DisplayField1() As String
    Public Property DisplayField2() As String
    Private _DetailForm As Object
    Public Property DetailForm As Object
        Get
            Return _DetailForm
        End Get
        Set(ByVal value As Object)
            btnDetailData.Visible = True
            _DetailForm = value
        End Set
    End Property
    Private _inputForm As Object
    ''' <summary>
    ''' Input Form is form Master
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InputForm() As Object
        Get
            Return _inputForm
        End Get
        Set(ByVal value As Object)
            btnAddData.Visible = True
            _inputForm = value
        End Set
    End Property

    Private Sub initObject(ByVal _table As String, ByVal _stringConn As String, ByVal _type1 As String, ByVal _type2 As String)
        InitializeComponent()
        StringConection = _stringConn
        Field1 = _type1
        Field2 = _type2
        _Strfields = Field1
        opt1.Checked = True
        Table = _table
    End Sub
    Sub New(_table As String, ByVal _stringConn As String, ByVal _type1 As String, ByVal _type2 As String)
        initObject(_table, _stringConn, _type1, _type2)
    End Sub

    Sub New(_table As String, ByVal _stringConn As String, ByVal _type1 As String)
        initObject(_table, _stringConn, _type1, "")
    End Sub

    Sub FormNotBusy(ByVal sts As Boolean)
        GroupCriteria.Enabled = sts
        GroupTips.Enabled = sts
        txtSearchBox.Enabled = sts
        PanelButtonResult.Enabled = sts
        btnAddData.Enabled = sts
        btnDetailData.Enabled = sts
        btnDataRefresh.Enabled = sts
    End Sub

    Public Sub LoadSources() Implements Dialog.LoadSources
        Dim sources As New ClsImageAndSound()
        btnDataRefresh.Image = sources.GetImages(EnumTipeGambar.RefreshPNG)
        btnResultSelect.Image = sources.GetImages(EnumTipeGambar.SELECTPNG)
        btnAddData.Image = sources.GetImages(EnumTipeGambar.NewPNG)
        btnResultCancel.Image = sources.GetImages(EnumTipeGambar.CloseFormPNG)
        btnFilter.Image = My.Resources.filterPNG
    End Sub

    Private Sub SetPageIndex(ByVal ParPageIndex As Integer)
        PageIndex = ParPageIndex
        If PageIndex <= 0 Then PageIndex = 1
        If PageIndex > rowsCount Then PageIndex = 1
    End Sub

    Private Sub ShowData(Optional Query As Boolean = True, Optional ParPageIndex As Integer = 1)
        SetPageIndex(ParPageIndex)
        If Query Then
            _StrSQL = StrQuery
        End If
        LoadingPicture.Visible = True
        FormNotBusy(False)
        BWShowData.RunWorkerAsync()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFilter.Click
        ShowData()
    End Sub

    Private Sub btndetil_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDetailData.Click
        Try
            If InputForm Is Nothing Then
                WarnMessage("Input Form not set")
                Exit Sub
            End If
            Dim detail As Object = DetailForm
            detail.value = Grid.CurrentRow.Cells(0).Value.ToString
            detail.showDialog()
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BuildDataGridCollomns()
        Grid.DataSource = Nothing
        Grid.Columns.Clear()
        Grid.Columns.Add("No", "No")
        Grid.Columns(0).DataPropertyName = "rowindex"
        Grid.Columns(0).ReadOnly = True

        If DisplayField1 <> "" Then
            Grid.Columns.Add(DisplayField1, DisplayField1)
            Grid.Columns(1).DataPropertyName = Field1
            Grid.Columns(1).ReadOnly = True
        Else
            Grid.Columns.Add(Field1, Field1)
            Grid.Columns(1).DataPropertyName = Field1
            Grid.Columns(1).ReadOnly = True
        End If
        If Field2 <> "" Then
            If DisplayField2 <> "" Then
                Grid.Columns.Add(DisplayField2, DisplayField2)
                Grid.Columns(2).DataPropertyName = Field2
                Grid.Columns(2).ReadOnly = True
            Else
                Grid.Columns.Add(Field2, Field2)
                Grid.Columns(2).DataPropertyName = Field2
                Grid.Columns(2).ReadOnly = True
            End If
        End If
    End Sub
    Private Sub SetSeizeDataGridCollumns()
        Grid.Columns(0).Width = 30
        If Field2 <> "" Then
            Grid.Columns(2).Width = 190
        Else
            Grid.Columns(1).Width = 280
        End If
    End Sub
    Private Sub BindDatasourceToGrid()
        Grid.AutoGenerateColumns = False
        Grid.DataSource = _SMC.Table.AsDataView
        Grid.CurrentCell = Grid.Item(0, 0)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWShowData.RunWorkerCompleted
        Application.DoEvents()
        BuildDataGridCollomns()
        Text = String.Format("{0} :: ({1} Record Found)", TITLE, rowsCount)
        If _SMC.RowCount > 0 Then BindDatasourceToGrid()
        SetSeizeDataGridCollumns()
        FormNotBusy(True)
        LoadingPicture.Visible = False
        txtSearchBox.Focus()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWShowData.DoWork
        Try
            Dim tempSQL As String = _StrSQL
            rowsCount = _SMC.Execute(StrQueryCount).Rows(0)(0)
            _SMC.Execute(tempSQL)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub BtnAddData_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddData.Click
        Try
            InputForm.ShowDialog()
            ShowData(False)
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

    Private Sub SetOptionControlSearchIndex()
        If IndexSearchCollumnFocus = 0 Then
            opt1.Checked = True
        Else
            opt2.Checked = True
        End If
    End Sub
    Private Sub DialogCariData_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        ShowData(False)
        SetOptionControlSearchIndex()
    End Sub

    Private Sub Grid_RowStateChanged(ByVal sender As Object, ByVal e As DataGridViewRowStateChangedEventArgs) Handles Grid.RowStateChanged
        txtSearchBox.Focus()
    End Sub

    Private Sub SelectDataOnGrid(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Grid.MouseDoubleClick
        btnResultSelect.PerformClick()
    End Sub

    Private Sub RefreshData(ByVal sender As Object, ByVal e As EventArgs) Handles btnDataRefresh.Click
        PageIndex = 1
        txtSearchBox.Clear()
    End Sub

    Private Sub ChangeText(ByVal sender As Object, ByVal e As EventArgs) Handles txtSearchBox.TextChanged
        If AutoQuery = True Then
            ShowData()
        End If
    End Sub

    Private Sub txtcari_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtSearchBox.KeyDown
        If e.KeyCode = Keys.Up Then
            If Grid.CurrentCell.RowIndex = 0 Then Exit Sub
            Grid.CurrentCell = Grid.Item(0, Grid.CurrentCell.RowIndex - 1)
        ElseIf e.KeyCode = Keys.Down Then
            If Grid.CurrentCell.RowIndex = PageCount - 1 Then Exit Sub
            Grid.CurrentCell = Grid.Item(0, Grid.CurrentCell.RowIndex + 1)
        ElseIf e.KeyCode = Keys.F5 Then
            btnDataRefresh.PerformClick()
        ElseIf e.KeyCode = Keys.F4 Then
            btnFilter.PerformClick()
        ElseIf e.KeyCode = Keys.Right Then
            btnNavNext.PerformClick()
        ElseIf e.KeyCode = Keys.Left Then
            BtnNavPrev.PerformClick()
        End If
    End Sub

    Private Sub ChangeOpt2(ByVal sender As Object, ByVal e As EventArgs) Handles opt2.CheckedChanged
        _Strfields = Field2
        _IntItem = 1
    End Sub

    Private Sub ChangeOpt1(ByVal sender As Object, ByVal e As EventArgs) Handles opt1.CheckedChanged
        _Strfields = Field1
        _IntItem = 0
    End Sub

    Private Function ValidationProperty() As Boolean
        Dim result = False
        If Table = "" Then
            ErrorMessage("Table not set")
            result = True
        End If

        If Field1 = "" Then
            ErrorMessage("Field1 not set")
            result = True
        End If

        Return result
    End Function

    Private Sub SetupOptionControlSearch()
        If DisplayField1 = "" Then
            opt1.Text = Field1
        Else
            opt1.Text = DisplayField1
        End If
        If Field2 = "" Then
            opt2.Enabled = False
        Else
            If DisplayField2 = "" Then
                opt2.Text = Field2
            Else
                opt2.Text = DisplayField2
            End If
        End If
        SetOptionControlSearchIndex()
    End Sub



    Private Sub SetStrQuery()
        If Field2 = "" Then
            _StrSQL = QSelect(Field1, Table)
        Else
            _StrSQL = QSelect(String.Format("{0},{1}", Field1, Field2), Table)
        End If
        _StrQuery = _StrSQL
    End Sub
    Private Sub LoadDialog(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If StrQuery <> "" Then
            _StrSQL = StrQuery
        Else
            If ValidationProperty() Then Return
            SetStrQuery()
        End If
        SetupOptionControlSearch()
        _SMC = New ClsSqlOledb(StringConection)
        LoadSources()
    End Sub

    Private Sub CloseMe(ByVal sender As Object, ByVal e As EventArgs) Handles btnResultCancel.Click
        _cancel = True
        DialogResult = DialogResult.Cancel
        _hasValue = False
        Close()
    End Sub

    Private Sub SetSuccessValue()
        DialogResult = DialogResult.OK
        _Value = Grid.CurrentRow.Cells(1).Value.ToString
        _hasValue = True
    End Sub
    Private Sub SelectDataAndFinish(ByVal sender As Object, ByVal e As EventArgs) Handles btnResultSelect.Click
        Try
            If Grid.RowCount > 0 Then
                Try
                    _SMC.Execute(StrQuery & AddAndCriteria(Equal(Field1, CSQL(Grid.CurrentRow.Cells(1).Value.ToString))))
                Catch ex As Exception
                    _SMC.Execute(StrQuery & AddAndCriteria(Equal(Field1, Grid.CurrentRow.Cells(1).Value.ToString)))
                End Try

                If _SMC.RowCount = 0 Then
                    WarnMessage("Data not Found")
                Else
                    SetSuccessValue()
                    Close()
                End If
            Else
                WarnMessage("Data don't be blank")
            End If
        Catch ex As Exception
            WarnMessage(ex.Message)
        End Try
    End Sub

#Region "Interface"

    Public Sub ShowMe() Implements Dialog.ShowMe
        ShowDialog()
    End Sub

#End Region

#Region "Navigation"
    Private Sub btnNavNext_Click(sender As Object, e As EventArgs) Handles btnNavNext.Click
        Dim ParPageIndex As Integer = PageIndex + PageCount
        ShowData(True, ParPageIndex)
    End Sub

    Private Sub BtnNavPrev_Click(sender As Object, e As EventArgs) Handles BtnNavPrev.Click
        ShowData(True, PageIndex - PageCount)
    End Sub

    Private Sub btnNavLast_Click(sender As Object, e As EventArgs) Handles btnNavLast.Click
        ShowData(True, (rowsCount - PageCount) + 1)
    End Sub

    Private Sub BtnNavFirst_Click(sender As Object, e As EventArgs) Handles BtnNavFirst.Click
        ShowData()
    End Sub
#End Region

End Class