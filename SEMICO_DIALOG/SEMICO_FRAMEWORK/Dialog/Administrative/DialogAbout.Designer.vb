<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogAbout
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelCompanyName = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        ''Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        ''Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.okButton = New System.Windows.Forms.Button()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.semico.My.Resources.Resources.MSGPNG
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LabelCompanyName)
        Me.Panel1.Controls.Add(Me.LabelVersion)
        Me.Panel1.Controls.Add(Me.LabelProductName)
        Me.Panel1.Controls.Add(Me.LogoPictureBox)
        'Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(-2, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(523, 179)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Powered by Semico Framework"
        '
        'LabelCompanyName
        '
        Me.LabelCompanyName.AutoSize = True
        Me.LabelCompanyName.BackColor = System.Drawing.Color.Transparent
        Me.LabelCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCompanyName.ForeColor = System.Drawing.Color.Gray
        Me.LabelCompanyName.Location = New System.Drawing.Point(19, 77)
        Me.LabelCompanyName.Name = "LabelCompanyName"
        Me.LabelCompanyName.Size = New System.Drawing.Size(112, 16)
        Me.LabelCompanyName.TabIndex = 3
        Me.LabelCompanyName.Text = "companyName"
        '
        'LabelVersion
        '
        Me.LabelVersion.AutoSize = True
        Me.LabelVersion.BackColor = System.Drawing.Color.Transparent
        Me.LabelVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVersion.Location = New System.Drawing.Point(18, 54)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(52, 16)
        Me.LabelVersion.TabIndex = 2
        Me.LabelVersion.Text = "version"
        '
        'LabelProductName
        '
        Me.LabelProductName.AutoSize = True
        Me.LabelProductName.BackColor = System.Drawing.Color.Transparent
        Me.LabelProductName.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProductName.ForeColor = System.Drawing.Color.Black
        Me.LabelProductName.Location = New System.Drawing.Point(15, 21)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(199, 33)
        Me.LabelProductName.TabIndex = 1
        Me.LabelProductName.Text = "productName"
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = Global.semico.My.Resources.Resources.Vision
        Me.LogoPictureBox.Location = New System.Drawing.Point(351, 21)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(155, 144)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'ShapeContainer1
        '
        'Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        'Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        'Me.ShapeContainer1.Name = "ShapeContainer1"
        'Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        'Me.ShapeContainer1.Size = New System.Drawing.Size(519, 175)
        'Me.ShapeContainer1.TabIndex = 4
        'Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        ' Me.LineShape1.Name = "LineShape1"
        'Me.LineShape1.X1 = 21
        'Me.LineShape1.X2 = 332
        'Me.LineShape1.Y1 = 75
        'Me.LineShape1.Y2 = 75
        '
        'okButton
        '
        Me.okButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.okButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.okButton.Location = New System.Drawing.Point(380, 185)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(126, 29)
        Me.okButton.TabIndex = 1
        Me.okButton.Text = "OK"
        Me.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.okButton.UseVisualStyleBackColor = True
        '
        'LabelCopyright
        '
        Me.LabelCopyright.AutoSize = True
        Me.LabelCopyright.Location = New System.Drawing.Point(18, 185)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(50, 13)
        Me.LabelCopyright.TabIndex = 2
        Me.LabelCopyright.Text = "copyright"
        '
        'DialogAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 221)
        Me.Controls.Add(Me.LabelCopyright)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogAbout"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SEMICO"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label
    Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
    'Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
