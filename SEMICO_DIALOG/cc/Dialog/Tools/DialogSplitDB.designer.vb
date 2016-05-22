<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogSplitDB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogSplitDB))
        Me.cmdProses = New System.Windows.Forms.Button()
        Me.txtfilename = New System.Windows.Forms.TextBox()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.txtadress = New System.Windows.Forms.TextBox()
        Me.OFD = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdTutup = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdProses
        '
        Me.cmdProses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdProses.Enabled = False
        Me.cmdProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdProses.Location = New System.Drawing.Point(156, 95)
        Me.cmdProses.Name = "cmdProses"
        Me.cmdProses.Size = New System.Drawing.Size(127, 29)
        Me.cmdProses.TabIndex = 0
        Me.cmdProses.Text = "Split"
        Me.cmdProses.UseVisualStyleBackColor = True
        '
        'txtfilename
        '
        Me.txtfilename.Location = New System.Drawing.Point(12, 12)
        Me.txtfilename.Name = "txtfilename"
        Me.txtfilename.ReadOnly = True
        Me.txtfilename.Size = New System.Drawing.Size(398, 20)
        Me.txtfilename.TabIndex = 2
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdBrowse.Location = New System.Drawing.Point(357, 38)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(52, 39)
        Me.cmdBrowse.TabIndex = 1
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtadress
        '
        Me.txtadress.Location = New System.Drawing.Point(12, 38)
        Me.txtadress.Multiline = True
        Me.txtadress.Name = "txtadress"
        Me.txtadress.ReadOnly = True
        Me.txtadress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtadress.Size = New System.Drawing.Size(340, 39)
        Me.txtadress.TabIndex = 0
        '
        'cmdTutup
        '
        Me.cmdTutup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdTutup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTutup.Location = New System.Drawing.Point(289, 95)
        Me.cmdTutup.Name = "cmdTutup"
        Me.cmdTutup.Size = New System.Drawing.Size(120, 28)
        Me.cmdTutup.TabIndex = 3
        Me.cmdTutup.Text = "Cancel"
        Me.cmdTutup.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdBrowse)
        Me.Panel1.Controls.Add(Me.txtfilename)
        Me.Panel1.Controls.Add(Me.txtadress)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(420, 89)
        Me.Panel1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(49, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Extract Database"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.semico.My.Resources.Resources.MSGPNG
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(188, 133)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'DialogSplitDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 129)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdTutup)
        Me.Controls.Add(Me.cmdProses)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogSplitDB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extract  Database"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdProses As System.Windows.Forms.Button
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtadress As System.Windows.Forms.TextBox
    Friend WithEvents txtfilename As System.Windows.Forms.TextBox
    Friend WithEvents OFD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cmdTutup As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
