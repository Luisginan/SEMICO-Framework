
Public NotInheritable Class DialogAbout
    Implements Dialog

    Dim images As New ClsImageAndSound
    Sub New()
        InitializeComponent()
    End Sub

    Sub SetlogoImages(ByVal AlamatFilenya As String)
        LogoPictureBox.Image = images.GetImages(AlamatFilenya)
    End Sub
    Sub loadSources() Implements Dialog.LoadSources
        okButton.Image = images.GetImages(EnumTipeGambar.CloseFormPNG)
    End Sub
    Private Sub LoadDialog(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        GetInformation()
        loadSources()
    End Sub
    Sub GetInformation()
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright & " Technologies. All Rights Reseved"
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
    End Sub
    Private Sub TutupDialog(ByVal sender As Object, ByVal e As EventArgs) Handles okButton.Click
        Me.Close()
    End Sub

    Public Sub TampilAsChild(ByVal Parent As Control)
        Me.MdiParent = Parent
        Me.Show()
    End Sub

    Public Sub TampilDialog() Implements Dialog.ShowMe
        Me.ShowDialog()
    End Sub

End Class
