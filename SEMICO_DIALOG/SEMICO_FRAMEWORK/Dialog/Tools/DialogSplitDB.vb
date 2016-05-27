Public Class DialogSplitDB
    Implements Dialog
    Dim DBFilePath As String
    Dim sources As New ClsImageAndSound

    Sub New(ByVal parDBfilePath As String)
        InitializeComponent()
        DBFilePath = parDBfilePath
    End Sub

    Private Sub LoadDialog(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        txtfilename.Text = My.Computer.Name.ToString & Format(Date.Today, "ddMMyyyy")
        LoadSources()
    End Sub

    Sub SetlogoImages(ByVal imagePath As String)
        PictureBox1.Image = sources.GetImages(imagePath)
    End Sub

    Private Sub AddressChange(ByVal sender As Object, ByVal e As EventArgs) Handles txtadress.TextChanged
        If txtadress.Text <> "" Then
            cmdProses.Enabled = True
        Else
            cmdProses.Enabled = False
        End If
    End Sub

    Private Sub BrowseFolder(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBrowse.Click
        Dim DestDBbackupPath As String
        OFD.Description = "Select folder/Drive destination "
        OFD.ShowDialog()
        If OFD.SelectedPath = "" Then
            Exit Sub
        End If
        DestDBbackupPath = OFD.SelectedPath.ToString.Substring(OFD.SelectedPath.Length - 1, 1)
        If DestDBbackupPath = "\" Then
            txtadress.Text = OFD.SelectedPath.ToString & "Extract\"
        Else
            txtadress.Text = OFD.SelectedPath.ToString & "\Extract\"
        End If
    End Sub

    Private Sub ProcessSplit(ByVal sender As Object, ByVal e As EventArgs) Handles cmdProses.Click
        Try
            My.Computer.FileSystem.CreateDirectory(txtadress.Text)
            Shell(String.Format("C:\Program Files\WinRAR\rar a -s -m5 -v2m {0}{1} {2}", txtadress.Text, txtfilename.Text, DBFilePath), AppWinStyle.MaximizedFocus, True)
            Shell("explorer " & txtadress.Text, AppWinStyle.MaximizedFocus, True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub CloseMe(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTutup.Click
        Me.Close()
    End Sub

    Public Sub LoadSources() Implements Dialog.LoadSources
        cmdBrowse.Image = sources.GetImages(EnumTipeGambar.BrowseBesarPNG)
        cmdProses.Image = My.Resources.SplitPNG
        cmdTutup.Image = sources.GetImages(EnumTipeGambar.CloseFormPNG)
    End Sub

    Public Sub ShowAsChild(ByVal Parent As Control)
        Me.MdiParent = Parent
        Me.Show()
    End Sub

    Public Sub ShowMe() Implements Dialog.ShowMe
        Me.ShowDialog()
    End Sub

End Class
