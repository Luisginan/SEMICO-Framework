<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogBackupRestore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogBackupRestore))
        Me.txtAlamatTujuan = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.CmdTutup = New System.Windows.Forms.Button
        Me.cmdBackup = New System.Windows.Forms.Button
        Me.OFD = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'txtAlamatTujuan
        '
        Me.txtAlamatTujuan.Location = New System.Drawing.Point(97, 12)
        Me.txtAlamatTujuan.Multiline = True
        Me.txtAlamatTujuan.Name = "txtAlamatTujuan"
        Me.txtAlamatTujuan.ReadOnly = True
        Me.txtAlamatTujuan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAlamatTujuan.Size = New System.Drawing.Size(221, 44)
        Me.txtAlamatTujuan.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Alamat Backup"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdBrowse.Location = New System.Drawing.Point(324, 12)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(42, 44)
        Me.cmdBrowse.TabIndex = 9
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'CmdTutup
        '
        Me.CmdTutup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdTutup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdTutup.Location = New System.Drawing.Point(276, 70)
        Me.CmdTutup.Name = "CmdTutup"
        Me.CmdTutup.Size = New System.Drawing.Size(90, 30)
        Me.CmdTutup.TabIndex = 7
        Me.CmdTutup.Text = "Tutup"
        Me.CmdTutup.UseVisualStyleBackColor = True
        '
        'cmdBackup
        '
        Me.cmdBackup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdBackup.Enabled = False
        Me.cmdBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBackup.Location = New System.Drawing.Point(175, 70)
        Me.cmdBackup.Name = "cmdBackup"
        Me.cmdBackup.Size = New System.Drawing.Size(95, 30)
        Me.cmdBackup.TabIndex = 6
        Me.cmdBackup.Text = "..."
        Me.cmdBackup.UseVisualStyleBackColor = True
        '
        'DialogBackupRestore
        '
        Me.AcceptButton = Me.cmdBrowse
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(378, 111)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmdTutup)
        Me.Controls.Add(Me.cmdBackup)
        Me.Controls.Add(Me.txtAlamatTujuan)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogBackupRestore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAlamatTujuan As System.Windows.Forms.TextBox
    Friend WithEvents CmdTutup As System.Windows.Forms.Button
    Friend WithEvents cmdBackup As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
End Class
