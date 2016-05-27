
Public Class ClsImageAndSound
    Implements IDisposable
    Private MyImages As Image
    Private Gambar As EnumTipeGambar
    Private Sound As New Media.SoundPlayer
    Private tipe As EnumTipeSound
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If MyImages IsNot Nothing Then
                MyImages.Dispose()
                MyImages = Nothing
            End If
            If Sound IsNot Nothing Then
                Sound.Dispose()
                Sound = Nothing
            End If
        End If
    End Sub

    ''' <summary>
    ''' Mendapatkan tipe Gambar (object Image) 
    ''' </summary>
    ''' <param name="TipeGambarnya"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overridable Function GetImages(ByVal tipeGambarnya As EnumTipeGambar) As Image
        Gambar = tipeGambarnya
        Dim temp As Image = My.Resources.CloseFormPNG
        Select Case Gambar
            Case EnumTipeGambar.NewPNG : temp = My.Resources.newPNG
            Case EnumTipeGambar.SavePNG : temp = My.Resources.SavePNG
            Case EnumTipeGambar.DeletePng : temp = My.Resources.DeletePNG
            Case EnumTipeGambar.UpdatePNG : temp = My.Resources.UpdatePNG
            Case EnumTipeGambar.RefreshPNG : temp = My.Resources.RefreshPNG
            Case EnumTipeGambar.CloseFormPNG : temp = My.Resources.CloseFormPNG
            Case EnumTipeGambar.TambahItemPNG : temp = My.Resources.TambahPNG
            Case EnumTipeGambar.DeleteItemPNG : temp = My.Resources.DeleteItemPNG
            Case EnumTipeGambar.BrowseKecilPNG : temp = My.Resources.Browse_kecilPNG
            Case EnumTipeGambar.BrowseBesarPNG : temp = My.Resources.BrowsePNG
            Case EnumTipeGambar.CancelPNG : temp = My.Resources.BatalPNG
            Case EnumTipeGambar.SearchPNG : temp = My.Resources.CariPNG
            Case EnumTipeGambar.DuplicatePNG : temp = My.Resources.DuplicatePNG
            Case EnumTipeGambar.ViewPNG : temp = My.Resources.ViewPNG
            Case EnumTipeGambar.Loading3GIF : temp = My.Resources.Loading3Gif
            Case EnumTipeGambar.OKPNG : temp = My.Resources.ceklistPNG
            Case EnumTipeGambar.SELECTPNG : temp = My.Resources.SelectPNG
            Case EnumTipeGambar.PRINTER : temp = My.Resources.printerPNG
            Case EnumTipeGambar.CEKLIST : temp = My.Resources.ceklistPNG
        End Select
        MyImages = temp
        Return MyImages
    End Function
    ''' <summary>
    ''' Setting otomatis Button control dalam sebuah dialog
    ''' </summary>
    ''' <param name="Lbutton"></param>
    ''' <remarks></remarks>
    Public Sub SetImagesButton(ByVal Lbutton As List(Of Button))
        For Each item As Button In Lbutton
            item.TextImageRelation = TextImageRelation.ImageBeforeText
            item.TextAlign = ContentAlignment.MiddleCenter
            Dim FNT As New Font("Tahoma", 8, FontStyle.Bold)

            item.Font = FNT
            item.Cursor = Cursors.Hand

            If item.Text.ToUpper Like "*SUSPEND*" Or item.Text.ToUpper Like "*DUPLICATE*" Or item.Text.ToUpper Like "*ADD*" Then
                item.Image = GetImages(EnumTipeGambar.DuplicatePNG)
            End If
            If item.Text.ToUpper Like "*VIEW*" Or item.Text.ToUpper Like "*LIHAT*" Or item.Text.ToUpper Like "*ADD*" Then
                item.Image = GetImages(EnumTipeGambar.ViewPNG)
            End If

            If item.Text.ToUpper Like "*TAMBAH*" Or item.Text.ToUpper Like "*BARU*" Or item.Text.ToUpper Like "*ADD*" Then
                item.Image = GetImages(EnumTipeGambar.NewPNG)
            End If

            If item.Text.ToUpper Like "*SIMPAN*" Or item.Text.ToUpper Like "*SAVE*" Then
                item.Image = GetImages(EnumTipeGambar.SavePNG)
            End If

            If item.Text.ToUpper Like "*BATAL*" Or item.Text.ToUpper Like "*CANCEL*" Or item.Text.ToUpper Like "*NO*" Then
                item.Image = GetImages(EnumTipeGambar.CancelPNG)
            End If

            If item.Text.ToUpper Like "*PRINT*" Or item.Text.ToUpper Like "*CETAK*" Then
                item.Image = GetImages(EnumTipeGambar.PRINTER)
            End If

            If item.Text.ToUpper Like "*EDIT*" Or item.Text.ToUpper Like "*EDIT*" Then
                item.Image = GetImages(EnumTipeGambar.UpdatePNG)
            End If

            If item.Text.ToUpper Like "*UPDATE*" Or item.Text.ToUpper Like "*UPDATE*" Then
                item.Image = GetImages(EnumTipeGambar.UpdatePNG)
            End If

            If item.Text.ToUpper Like "*OK*" Or item.Text.ToUpper Like "*YES*" Then
                item.Image = GetImages(EnumTipeGambar.OKPNG)
            End If

            If item.Text.ToUpper Like "*TUTUP*" Or item.Text.ToUpper Like "*CLOSE*" Then
                item.Image = GetImages(EnumTipeGambar.CloseFormPNG)
            End If

            If item.Text.ToUpper Like "*HAPUS*" Or item.Text.ToUpper Like "*DELETE*" Then
                item.Image = GetImages(EnumTipeGambar.DeletePng)
            End If

            If item.Text.ToUpper Like "*CARI*" Or item.Text.ToUpper Like "*SEARCH*" Then
                item.Image = GetImages(EnumTipeGambar.SearchPNG)
            End If

            If item.Text.ToUpper Like "*PILIH*" Or item.Text.ToUpper Like "*SELECT*" Then
                item.Image = GetImages(EnumTipeGambar.SELECTPNG)
            End If

            If item.Text.ToUpper Like "" Then
                item.Image = GetImages(EnumTipeGambar.BrowseKecilPNG)
            End If
        Next

    End Sub
    ''' <summary>
    ''' Mendapatkan Gambar dari external
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetImages(ByVal FilePath As String) As Image
        MyImages = Image.FromFile(FilePath)
        Return MyImages
    End Function
    ''' <summary>
    ''' Mengeluarkan suara 
    ''' </summary>
    ''' <param name="Soundnya"></param>
    ''' <remarks></remarks>
    Overridable Sub PlaySound(ByVal Soundnya As EnumTipeSound)
        tipe = Soundnya
        Dim temp As System.IO.Stream = My.Resources.SNDNotify
        Select Case tipe
            Case EnumTipeSound.baloon : temp = My.Resources.SNDWindows_XP_Balloon
            Case EnumTipeSound.errors : temp = My.Resources.SNDCritical
            Case EnumTipeSound.delete : temp = My.Resources.SNDrecycle
            Case EnumTipeSound.information : temp = My.Resources.SNDchimes
            Case EnumTipeSound.Click : temp = My.Resources.SNDstart
            Case EnumTipeSound.maximize : temp = My.Resources.SNDWindows_XP_Restore
            Case EnumTipeSound.menuClick : temp = My.Resources.SNDWindows_XP_Menu_Command
            Case EnumTipeSound.minimize : temp = My.Resources.SNDWindows_XP_Minimize
            Case EnumTipeSound.popup : temp = My.Resources.SNDWindows_XP_Pop_up_Blocked
            Case EnumTipeSound.print : temp = My.Resources.SNDWindows_XP_Print_complete
            Case EnumTipeSound.warning : temp = My.Resources.SNDWarning
            Case EnumTipeSound.Ask : temp = My.Resources.notify
            Case EnumTipeSound.Shield : temp = My.Resources.SNDShield
        End Select
        Sound.Stream = temp
        Sound.Play()
    End Sub
    Public Sub SetImagesForm(ByVal frm As Control, Optional exceptionControl As Control = Nothing)
        Dim Ctrl As New Control
        Dim Lbutton As New List(Of Button)
        Dim Lcontrol As Control.ControlCollection = frm.Controls
        For Each Ctrl In Lcontrol
            If Ctrl.Equals(exceptionControl) Then Continue For
            If TypeOf Ctrl Is Panel And Ctrl.Name.ToUpper Like "*JUDUL*" Then
                Dim pnl As New Panel
                pnl = Ctrl
                pnl.BackgroundImage = GetImages(EnumTipeGambar.TopBarJPG)
                SetImagesForm(Ctrl)
            ElseIf TypeOf Ctrl Is Label And Ctrl.Name.ToUpper Like "*JUDUL*" Then
                Dim lbl As New Label
                lbl = Ctrl
                lbl.Font = New Font(lbl.Font.FontFamily, lbl.Font.Size, FontStyle.Bold)
                lbl.ForeColor = Color.White
                lbl.BackColor = Color.Transparent
            ElseIf TypeOf Ctrl Is GroupBox Then
                SetImagesForm(Ctrl)
            ElseIf TypeOf Ctrl Is Button Then
                Lbutton.Add(Ctrl)
            End If
        Next
        If Lbutton.Count > 0 Then
            SetImagesButton(Lbutton)
        End If
    End Sub
    ''' <summary>
    ''' Mengeuarkan Suara dari eksternal
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <remarks></remarks>
    Sub PlaySound(ByVal FilePath As String)
        Sound.SoundLocation = FilePath
        Sound.Play()
    End Sub
End Class

