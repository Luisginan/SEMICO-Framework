Imports Semico.ClsQuickCode
Imports Semico
Public Class DialogFinder
    Dim SMC As New ClsQBOledb
#Region "Property"
    Public ReadOnly Property HasValue As Boolean
        Get
            If KeyValue Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
    Public Property Table As DataTable
    Public ReadOnly Property KeyValue As Object
        Get
            If FieldKey = "" Then
                Return GV.CurrentRow.Cells(0).Value
            Else
                Return GV.CurrentRow.Cells(FieldKey).Value
            End If
        End Get
    End Property
    Private Property IndexCriteria As Integer = 0
    Public Property FieldKey As String
    Public Property Field As New ArrayList
    Public Property FieldCaption As New ArrayList
    Public Property FieldCriteria As New ArrayList
    Public Property FieldCriteriaCaption As New ArrayList
    Public Property AutoQuery As Boolean = False
    Private ReadOnly sources As New ClsImageAndSound()
#End Region

    Sub New()
        InitializeComponent()
        LoadSources()
    End Sub

    Public Sub AddField(item As String, Optional SetFieldCriteriToo As Boolean = True, Optional SetFirstIndexFieldAsFieldKey As Boolean = True)
        Dim f = item.Split(",")
        Field.AddRange(f)
        If SetFieldCriteriToo Then FieldCriteria.AddRange(Field)
        If SetFirstIndexFieldAsFieldKey Then FieldKey = Field(0).ToString

    End Sub

    Public Sub AddFieldCaption(item As String)
        Dim f = item.Split(",")
        FieldCaption.AddRange(f)
    End Sub

    Public Sub AddFieldCriteria(item As String)
        Dim f = item.Split(",")
        FieldCriteria.AddRange(f)
    End Sub

    Private Sub CreateFieldGrid()
        If FieldCaption.Count = 0 Then
            FieldCaption = Field
        End If
        For i As Byte = 0 To Field.Count - 1
            Using CLM As New DataGridViewTextBoxColumn() With {.HeaderText = FieldCaption(i), .DataPropertyName = Field(i), .Name = Field(i), .ReadOnly = True}
                GV.Columns.AddRange(New DataGridViewColumn() {CLM})
            End Using
        Next
        If FieldKey <> "" Then
            Using CLM As New DataGridViewTextBoxColumn() With {.HeaderText = FieldKey, .DataPropertyName = FieldKey, .Name = FieldKey, .ReadOnly = True, .Visible = False}
                GV.Columns.AddRange(New DataGridViewColumn() {CLM})
            End Using
        End If
    End Sub

    Private Sub DialogFinder_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Using DT As New DataTable()
            DT.Columns.Add("Ctext")
            DT.Columns.Add("Cvalue")
            For i As Integer = 0 To FieldCriteria.Count - 1
                Try
                    DT.Rows.Add(FieldCriteriaCaption(i), FieldCriteria(i))
                Catch ex As Exception
                    DT.Rows.Add(FieldCriteria(i), FieldCriteria(i))
                End Try
            Next
            DDfieldCriteria.DataSource = DT
        End Using
        DDfieldCriteria.DisplayMember = "Ctext"
        DDfieldCriteria.ValueMember = "cvalue"
        If Field.Count > 0 Then CreateFieldGrid()
        BindingGridDT(Table)
    End Sub

    Public Sub LoadSources()
        cmdRefresh.Image = sources.GetImages(EnumTipeGambar.RefreshPNG)
        OK_Button.Image = sources.GetImages(EnumTipeGambar.SELECTPNG)
        Cancel_Button.Image = sources.GetImages(EnumTipeGambar.CloseFormPNG)
        btnFilter.Image = My.Resources.filterPNG
    End Sub

    Private Sub BindingGridDT(ByVal TBL As DataTable)
        If Field.Count > 0 Then
            GV.AutoGenerateColumns = False
        End If
        GV.DataSource = Nothing
        GV.DataSource = TBL
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFilter.Click
        Dim TBL As DataTable = FilterDT(Table, DDfieldCriteria.SelectedValue, txtTextCriteria.Text)
        BindingGridDT(TBL)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRefresh.Click
        BindingGridDT(Table)
    End Sub

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        Close()
    End Sub

    Private Sub DialogFinder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtTextCriteria.Focus()
        If DDfieldCriteria.Items.Count > 0 Then DDfieldCriteria.SelectedIndex = IndexCriteria
    End Sub

End Class