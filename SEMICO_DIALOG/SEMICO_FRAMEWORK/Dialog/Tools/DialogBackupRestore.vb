Imports Semico.ClsMessageDialog

Public Class DialogBackupRestore
    Implements Dialog
    Public Property StrAlamatAsal As String
    Public Property StrAlamatTujuan As String
    Public Property EnumTipeProses As EnumTipeBackupRestore
    Public Property StrExtensi As String
    Public Property AlamatFileRestore() As String


    Sub New(ByVal AlamatDatabase As String, ByVal Tipe As EnumTipeBackupRestore)
        InitializeComponent()
        StrAlamatAsal = AlamatDatabase

        Dim InfoFile As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(AlamatDatabase)
        StrExtensi = InfoFile.Extension
        EnumTipeProses = Tipe
        If Tipe = EnumTipeBackupRestore.Mode_BackupData Then
            Me.Text = "Backup"
            Me.cmdBackup.Text = "Backup"
            Me.cmdBackup.Image = My.Resources.Navigasi_go_up
            Me.Icon = My.Resources.ICO_Disket
        Else
            Me.Text = "Restore"
            Me.cmdBackup.Text = "Restore"
            Me.cmdBackup.Image = My.Resources.Navigasi_go_bottom
            Me.Icon = My.Resources.ICO_Restore
        End If
    End Sub

    Sub ProcessBackup()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim IntUkuranFileSumber As Integer = FileLen(StrAlamatAsal)
            Me.Text = String.Format("Prosesing backup {0}kb", IntUkuranFileSumber / 1024)
            My.Computer.FileSystem.CopyFile(StrAlamatAsal, txtAlamatTujuan.Text, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)
            InfoMessage("Proses Backup Sukses")
            Shell("explorer " & FBD.SelectedPath, AppWinStyle.NormalFocus, False)
        Catch ex As Exception
            WarnMessage("Proses Gagal : " & ex.Message)
        End Try
        Me.Text = "Backup"
        txtAlamatTujuan.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Sub ProcessRestore()
        Dim jawab As MsgBoxResult = MessageBox.Show("Semua data dalam database akan di timpa oleh Data baru" & vbCrLf & "dari file backup yang di rstore" & vbCrLf & "Apa Anda Yakin?", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If jawab = MsgBoxResult.Cancel Then
            Exit Sub
        End If
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim IntUkuranFileSumber As Integer = FileLen(StrAlamatAsal)
            Me.Text = String.Format("Prosesing Restore {0}kb", IntUkuranFileSumber / 1024)
            My.Computer.FileSystem.CopyFile(txtAlamatTujuan.Text, StrAlamatAsal, True)
            InfoMessage("Proses Restore Sukses")
        Catch ex As Exception
            WarnMessage("Proses gagal : " & ex.Message)
        End Try
        Me.Text = "Restore"
        txtAlamatTujuan.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Sub SelectFolderBackup()
        Dim path As String
        FBD.Description = "Pilih Folder untuk menyimpan file Backup :"
        FBD.RootFolder = Environment.SpecialFolder.MyComputer
        FBD.ShowDialog()
        Try
            path = FBD.SelectedPath.ToString.Substring(FBD.SelectedPath.Length - 1, 1)
            If path = "\" Then
                txtAlamatTujuan.Text = FBD.SelectedPath & Format(Date.Today, "ddmmyyyssMMhh") & StrExtensi
            Else
                txtAlamatTujuan.Text = String.Format("{0}\{1}{2}", FBD.SelectedPath, Format(Date.Today, "ddmmyyyssMMhh"), StrExtensi)
            End If
        Catch ex As Exception
            path = ""
        End Try
    End Sub

    Sub SelectFileRestore()
        OFD.DefaultExt = "mdb"
        OFD.Multiselect = False
        OFD.Filter = "Backup Database|*" & StrExtensi
        OFD.Title = "Pilih file Backup untuk di restore ke sistem :"
        OFD.ShowDialog()
        txtAlamatTujuan.Text = OFD.FileName
    End Sub

    Private Sub LoadDialog(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If AlamatFileRestore <> "" Then
            txtAlamatTujuan.Text = Replace(AlamatFileRestore, """", "")
        End If
        LoadSources()
    End Sub

    Private Sub CloseMe(ByVal sender As Object, ByVal e As EventArgs) Handles CmdTutup.Click
        Me.Close()
    End Sub

    Private Sub ProcessBackupRestore(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBackup.Click
        If EnumTipeProses = EnumTipeBackupRestore.Mode_BackupData Then
            ProcessBackup()
        Else
            ProcessRestore()
        End If
    End Sub

    Private Sub SelectDestinationAddress(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBrowse.Click
        If EnumTipeProses = EnumTipeBackupRestore.Mode_BackupData Then
            SelectFolderBackup()
        Else
            SelectFileRestore()
        End If
    End Sub

    Private Sub TextAddressFileChange(ByVal sender As Object, ByVal e As EventArgs) Handles txtAlamatTujuan.TextChanged
        If txtAlamatTujuan.Text <> "" Then
            cmdBackup.Enabled = True
        Else
            cmdBackup.Enabled = False
        End If
    End Sub

    Public Sub LoadSources() Implements Dialog.LoadSources
        Dim _Sources As New ClsImageAndSound
        cmdBrowse.Image = _Sources.GetImages(EnumTipeGambar.BrowseBesarPNG)
        CmdTutup.Image = _Sources.GetImages(EnumTipeGambar.CloseFormPNG)
        If EnumTipeProses = EnumTipeBackupRestore.Mode_BackupData Then
            cmdBackup.Image = My.Resources.copyPNG
        Else
            cmdBackup.Image = My.Resources.RestorePNG
        End If
    End Sub

    Public Sub ShowAsChild(ByVal Parent As Control)
        Me.MdiParent = Parent
        Me.Show()
    End Sub

    Public Sub ShowMe() Implements Dialog.ShowMe
        Me.ShowDialog()
    End Sub
End Class