
Public Class DialogMessage
    Private SRC As New ClsImageAndSound
    Public Property Mode() As EnumTipeMessage
    Private Property StringMessage() As String
    Private _Value As DialogResult = Nothing
    Public ReadOnly Property Value() As DialogResult
        Get
            Return _Value
        End Get
    End Property

    Sub New(ByVal Pesannya As String, ByVal Judulnya As String, Optional mode As EnumTipeMessage = EnumTipeMessage.Tips)
        InitializeComponent()
        StringMessage = Pesannya
        If StringMessage.Length > 100 Then
            StringMessage = StringMessage.Replace(".", "." & vbCrLf)
        End If
        txtPesan.Text = StringMessage
        Me.Width = Me.Width + IIf(txtPesan.Width > 85, txtPesan.Width - 85, 0)
        Me.Text = Judulnya
        Me.Mode = mode
        Me.Height = Me.Height + IIf(txtPesan.Height > 0, txtPesan.Height, 0)
        Me.Panel1.BackgroundImage = My.Resources.MSGPNG
    End Sub

    Private Sub Message_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If _Value = Nothing Then
            e.Cancel = True
        End If
    End Sub

    Private Sub SetLayout(image As Bitmap, btn1Vis As Boolean, btn1Text As String, btn2Text As String, sound As EnumTipeSound)
        PictureBox1.Image = image
        Btn1.Visible = btn1Vis
        btn2.Text = btn2Text
        Btn1.Text = btn1Text
        SRC.PlaySound(sound)
    End Sub
    Private Sub MessageBox_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Select Case Mode
            Case EnumTipeMessage.Information
                SetLayout(My.Resources.dialog_information, False, "", "OK", EnumTipeSound.information)
            Case EnumTipeMessage.Eror
                SetLayout(My.Resources.dialog_error, False, "", "OK", EnumTipeSound.errors)
            Case EnumTipeMessage.Exlamation
                SetLayout(My.Resources.Dialog_Dalert, False, "OK", "", EnumTipeSound.warning)
            Case EnumTipeMessage.Question
                SetLayout(My.Resources.Dialog_Question, True, "YES", "NO", EnumTipeSound.Ask)
            Case EnumTipeMessage.NoAcces
                SetLayout(My.Resources.Dialog_Shield, False, "", "OK", EnumTipeSound.Shield)
            Case EnumTipeMessage.Tips
                SetLayout(My.Resources.dialog_Tips, False, "", "OK", EnumTipeSound.popup)
            Case EnumTipeMessage.AskShield
                SetLayout(My.Resources.Dialog_Shield, True, "YES", "NO", EnumTipeSound.Shield)
        End Select
        Dim Lbutton As New List(Of Button)
        Lbutton.Add(Btn1)
        Lbutton.Add(btn2)
        SRC.SetImagesButton(Lbutton)
    End Sub

    Public Overloads Function Show() As DialogResult
        Me.ShowDialog()
    End Function

    Private Sub btn2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn2.Click
        _Value = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub Btn1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn1.Click
        _Value = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub
End Class