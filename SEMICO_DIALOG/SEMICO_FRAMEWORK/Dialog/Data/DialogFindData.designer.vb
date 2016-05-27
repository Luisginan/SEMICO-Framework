<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogFindData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogFindData))
        Me.PanelButtonResult = New System.Windows.Forms.TableLayoutPanel()
        Me.btnResultSelect = New System.Windows.Forms.Button()
        Me.btnResultCancel = New System.Windows.Forms.Button()
        Me.GroupCriteria = New System.Windows.Forms.GroupBox()
        Me.opt2 = New System.Windows.Forms.RadioButton()
        Me.opt1 = New System.Windows.Forms.RadioButton()
        Me.txtSearchBox = New System.Windows.Forms.TextBox()
        Me.GroupTips = New System.Windows.Forms.GroupBox()
        Me.txtTips = New System.Windows.Forms.TextBox()
        Me.TTBrowse = New System.Windows.Forms.ToolTip(Me.components)
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.btnDataRefresh = New System.Windows.Forms.Button()
        Me.btnAddData = New System.Windows.Forms.Button()
        Me.btnDetailData = New System.Windows.Forms.Button()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.BtnNavFirst = New System.Windows.Forms.Button()
        Me.BtnNavPrev = New System.Windows.Forms.Button()
        Me.btnNavLast = New System.Windows.Forms.Button()
        Me.btnNavNext = New System.Windows.Forms.Button()
        Me.LoadingPicture = New System.Windows.Forms.PictureBox()
        Me.BWShowData = New System.ComponentModel.BackgroundWorker()
        Me.PanelButtonResult.SuspendLayout()
        Me.GroupCriteria.SuspendLayout()
        Me.GroupTips.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButtonResult
        '
        Me.PanelButtonResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelButtonResult.ColumnCount = 2
        Me.PanelButtonResult.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.PanelButtonResult.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.PanelButtonResult.Controls.Add(Me.btnResultSelect, 0, 0)
        Me.PanelButtonResult.Controls.Add(Me.btnResultCancel, 1, 0)
        Me.PanelButtonResult.Location = New System.Drawing.Point(300, 282)
        Me.PanelButtonResult.Name = "PanelButtonResult"
        Me.PanelButtonResult.RowCount = 1
        Me.PanelButtonResult.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.PanelButtonResult.Size = New System.Drawing.Size(234, 40)
        Me.PanelButtonResult.TabIndex = 0
        '
        'btnResultSelect
        '
        Me.btnResultSelect.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnResultSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResultSelect.Location = New System.Drawing.Point(5, 7)
        Me.btnResultSelect.Name = "btnResultSelect"
        Me.btnResultSelect.Size = New System.Drawing.Size(107, 26)
        Me.btnResultSelect.TabIndex = 0
        Me.btnResultSelect.Text = "Select"
        Me.btnResultSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.TTBrowse.SetToolTip(Me.btnResultSelect, "Finish Searching Data")
        '
        'btnResultCancel
        '
        Me.btnResultCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnResultCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResultCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnResultCancel.Location = New System.Drawing.Point(121, 7)
        Me.btnResultCancel.Name = "btnResultCancel"
        Me.btnResultCancel.Size = New System.Drawing.Size(108, 26)
        Me.btnResultCancel.TabIndex = 1
        Me.btnResultCancel.Text = "Cancel"
        Me.btnResultCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.TTBrowse.SetToolTip(Me.btnResultCancel, "Cancel Searching Data")
        '
        'GroupCriteria
        '
        Me.GroupCriteria.Controls.Add(Me.opt2)
        Me.GroupCriteria.Controls.Add(Me.opt1)
        Me.GroupCriteria.Location = New System.Drawing.Point(12, 12)
        Me.GroupCriteria.Name = "GroupCriteria"
        Me.GroupCriteria.Size = New System.Drawing.Size(165, 100)
        Me.GroupCriteria.TabIndex = 2
        Me.GroupCriteria.TabStop = False
        Me.GroupCriteria.Text = "Criteria : "
        '
        'opt2
        '
        Me.opt2.AutoSize = True
        Me.opt2.Location = New System.Drawing.Point(21, 63)
        Me.opt2.Name = "opt2"
        Me.opt2.Size = New System.Drawing.Size(34, 17)
        Me.opt2.TabIndex = 1
        Me.opt2.TabStop = True
        Me.opt2.Text = "..."
        Me.opt2.UseVisualStyleBackColor = True
        '
        'opt1
        '
        Me.opt1.AutoSize = True
        Me.opt1.Location = New System.Drawing.Point(21, 28)
        Me.opt1.Name = "opt1"
        Me.opt1.Size = New System.Drawing.Size(34, 17)
        Me.opt1.TabIndex = 0
        Me.opt1.TabStop = True
        Me.opt1.Text = "..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.opt1.UseVisualStyleBackColor = True
        '
        'txtcari
        '
        Me.txtSearchBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchBox.Location = New System.Drawing.Point(12, 118)
        Me.txtSearchBox.Name = "txtcari"
        Me.txtSearchBox.Size = New System.Drawing.Size(115, 24)
        Me.txtSearchBox.TabIndex = 3
        Me.TTBrowse.SetToolTip(Me.txtSearchBox, "Enter word for searching here and then press Space")
        '
        'GroupTips
        '
        Me.GroupTips.Controls.Add(Me.txtTips)
        Me.GroupTips.Location = New System.Drawing.Point(12, 144)
        Me.GroupTips.Name = "GroupTips"
        Me.GroupTips.Size = New System.Drawing.Size(165, 124)
        Me.GroupTips.TabIndex = 5
        Me.GroupTips.TabStop = False
        Me.GroupTips.Text = "Tips :"
        '
        'txtTips
        '
        Me.txtTips.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTips.Location = New System.Drawing.Point(9, 19)
        Me.txtTips.Multiline = True
        Me.txtTips.Name = "txtTips"
        Me.txtTips.ReadOnly = True
        Me.txtTips.Size = New System.Drawing.Size(145, 95)
        Me.txtTips.TabIndex = 4
        Me.txtTips.Text = "Enter word for searching  and, {F4} for Filter ,{F5} for Refresh or {Enter} For A" & _
    "ccept Data ..."
        '
        'TTBrowse
        '
        Me.TTBrowse.ShowAlways = True
        Me.TTBrowse.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TTBrowse.ToolTipTitle = "Description :"
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.BackgroundColor = System.Drawing.Color.White
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Grid.Location = New System.Drawing.Point(192, 19)
        Me.Grid.MultiSelect = False
        Me.Grid.Name = "Grid"
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(342, 223)
        Me.Grid.TabIndex = 7
        Me.TTBrowse.SetToolTip(Me.Grid, "Klik Item untuk memilih")
        '
        'cmdRefresh
        '
        Me.btnDataRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDataRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDataRefresh.FlatAppearance.BorderSize = 0
        Me.btnDataRefresh.Location = New System.Drawing.Point(154, 118)
        Me.btnDataRefresh.Name = "cmdRefresh"
        Me.btnDataRefresh.Size = New System.Drawing.Size(25, 24)
        Me.btnDataRefresh.TabIndex = 6
        Me.TTBrowse.SetToolTip(Me.btnDataRefresh, "Refresh Data (F5)")
        Me.btnDataRefresh.UseVisualStyleBackColor = True
        '
        'BtnTambahData
        '
        Me.btnAddData.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAddData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddData.Location = New System.Drawing.Point(12, 282)
        Me.btnAddData.Name = "BtnTambahData"
        Me.btnAddData.Size = New System.Drawing.Size(101, 26)
        Me.btnAddData.TabIndex = 9
        Me.btnAddData.Text = "Add Data"
        Me.btnAddData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.TTBrowse.SetToolTip(Me.btnAddData, "Klik For Entry Data ")
        Me.btnAddData.Visible = False
        '
        'btndetil
        '
        Me.btnDetailData.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDetailData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDetailData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetailData.Location = New System.Drawing.Point(119, 282)
        Me.btnDetailData.Name = "btndetil"
        Me.btnDetailData.Size = New System.Drawing.Size(58, 26)
        Me.btnDetailData.TabIndex = 10
        Me.btnDetailData.Text = "Detail"
        Me.btnDetailData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.TTBrowse.SetToolTip(Me.btnDetailData, "Klik For Detail Information")
        Me.btnDetailData.Visible = False
        '
        'btnFilter
        '
        Me.btnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFilter.FlatAppearance.BorderSize = 0
        Me.btnFilter.Location = New System.Drawing.Point(129, 118)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(25, 24)
        Me.btnFilter.TabIndex = 11
        Me.TTBrowse.SetToolTip(Me.btnFilter, "Filter Data (F4)")
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'BtnNavFirst
        '
        Me.BtnNavFirst.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnNavFirst.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNavFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNavFirst.Location = New System.Drawing.Point(192, 246)
        Me.BtnNavFirst.Name = "BtnNavFirst"
        Me.BtnNavFirst.Size = New System.Drawing.Size(31, 26)
        Me.BtnNavFirst.TabIndex = 12
        Me.BtnNavFirst.Text = "<<"
        Me.BtnNavFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.TTBrowse.SetToolTip(Me.BtnNavFirst, "Klik For Detail Information")
        '
        'BtnNavPrev
        '
        Me.BtnNavPrev.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnNavPrev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNavPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNavPrev.Location = New System.Drawing.Point(224, 246)
        Me.BtnNavPrev.Name = "BtnNavPrev"
        Me.BtnNavPrev.Size = New System.Drawing.Size(31, 26)
        Me.BtnNavPrev.TabIndex = 13
        Me.BtnNavPrev.Text = "<"
        Me.BtnNavPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.TTBrowse.SetToolTip(Me.BtnNavPrev, "Klik For Detail Information")
        '
        'btnNavLast
        '
        Me.btnNavLast.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnNavLast.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavLast.Location = New System.Drawing.Point(288, 246)
        Me.btnNavLast.Name = "btnNavLast"
        Me.btnNavLast.Size = New System.Drawing.Size(31, 26)
        Me.btnNavLast.TabIndex = 15
        Me.btnNavLast.Text = ">>"
        Me.btnNavLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.TTBrowse.SetToolTip(Me.btnNavLast, "Klik For Detail Information")
        '
        'btnNavNext
        '
        Me.btnNavNext.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnNavNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavNext.Location = New System.Drawing.Point(256, 246)
        Me.btnNavNext.Name = "btnNavNext"
        Me.btnNavNext.Size = New System.Drawing.Size(31, 26)
        Me.btnNavNext.TabIndex = 14
        Me.btnNavNext.Text = ">"
        Me.btnNavNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.TTBrowse.SetToolTip(Me.btnNavNext, "Klik For Detail Information")
        '
        'LoadingPicture
        '
        Me.LoadingPicture.BackColor = System.Drawing.Color.White
        Me.LoadingPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LoadingPicture.Image = Global.Semico.My.Resources.Resources.Loading3Gif
        Me.LoadingPicture.Location = New System.Drawing.Point(192, 19)
        Me.LoadingPicture.Name = "LoadingPicture"
        Me.LoadingPicture.Size = New System.Drawing.Size(342, 223)
        Me.LoadingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.LoadingPicture.TabIndex = 8
        Me.LoadingPicture.TabStop = False
        '
        'BWShowData
        '
        '
        'DialogFindData
        '
        Me.AcceptButton = Me.btnResultSelect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnResultCancel
        Me.ClientSize = New System.Drawing.Size(554, 325)
        Me.Controls.Add(Me.btnNavLast)
        Me.Controls.Add(Me.btnNavNext)
        Me.Controls.Add(Me.BtnNavPrev)
        Me.Controls.Add(Me.BtnNavFirst)
        Me.Controls.Add(Me.LoadingPicture)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.btnDetailData)
        Me.Controls.Add(Me.btnAddData)
        Me.Controls.Add(Me.btnDataRefresh)
        Me.Controls.Add(Me.GroupTips)
        Me.Controls.Add(Me.txtSearchBox)
        Me.Controls.Add(Me.GroupCriteria)
        Me.Controls.Add(Me.PanelButtonResult)
        Me.Controls.Add(Me.Grid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 400)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(442, 351)
        Me.Name = "DialogFindData"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelButtonResult.ResumeLayout(False)
        Me.GroupCriteria.ResumeLayout(False)
        Me.GroupCriteria.PerformLayout()
        Me.GroupTips.ResumeLayout(False)
        Me.GroupTips.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelButtonResult As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnResultSelect As System.Windows.Forms.Button
    Friend WithEvents btnResultCancel As System.Windows.Forms.Button
    Friend WithEvents GroupCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents opt2 As System.Windows.Forms.RadioButton
    Friend WithEvents opt1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtSearchBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupTips As System.Windows.Forms.GroupBox
    Friend WithEvents btnDataRefresh As System.Windows.Forms.Button
    Friend WithEvents TTBrowse As System.Windows.Forms.ToolTip
    Friend WithEvents txtTips As System.Windows.Forms.TextBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents LoadingPicture As System.Windows.Forms.PictureBox
    Friend WithEvents btnAddData As System.Windows.Forms.Button
    Friend WithEvents BWShowData As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnDetailData As System.Windows.Forms.Button
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents BtnNavFirst As System.Windows.Forms.Button
    Friend WithEvents BtnNavPrev As System.Windows.Forms.Button
    Friend WithEvents btnNavLast As System.Windows.Forms.Button
    Friend WithEvents btnNavNext As System.Windows.Forms.Button

End Class
