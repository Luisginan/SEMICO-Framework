Imports Semico.ClsMessageDialog
Imports Semico.ClsQB


Public Class DialogChangePassword

    Dim ErrorProvider1 As New ErrorProvider
    Dim ErrorProvider2 As New ErrorProvider

    Public Property FIELD_USERID() As String
    Public Property FIELD_PASSWORD() As String
    Public Property TABLE() As String
    Public Property StringConnection() As String
    Public Property Password() As String
    Public Property USERID() As String

    Sub New()
        InitializeComponent()
        Dim c As New ClsImageAndSound
        c.SetImagesForm(Me)
    End Sub

    Private Sub txtRypePassword_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRypePassword.Validating
        If txtNewPassword.Text = "" Then Exit Sub
        If txtNewPassword.Text.ToUpper <> txtRypePassword.Text.ToUpper Then
            ErrorProvider1.Icon = My.Resources.warning
            ErrorProvider1.SetError(txtRypePassword, "Password not Match")
            ErrorProvider1.SetIconAlignment(txtRypePassword, ErrorIconAlignment.MiddleLeft)
            ErrorProvider1.SetIconPadding(txtRypePassword, 5)
        Else
            ErrorProvider1.Icon = My.Resources.valid
            ErrorProvider1.SetError(txtRypePassword, "Match")
            ErrorProvider1.SetIconAlignment(txtRypePassword, ErrorIconAlignment.MiddleLeft)
            ErrorProvider1.SetIconPadding(txtRypePassword, 5)
        End If
    End Sub

    Private Sub Frm_ChangeUser_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If StringConnection = "" Then Throw New ArgumentException("StringConnection not set")
        Me.Text += " For " & USERID.ToUpper
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub txtOldPassword_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOldPassword.Validating
        If txtOldPassword.Text = "" Then Exit Sub
        If txtOldPassword.Text <> Me.Password Then
            ErrorProvider2.SetError(txtOldPassword, "Invalid password")
            ErrorProvider2.Icon = My.Resources.warning
            ErrorProvider2.SetIconAlignment(txtOldPassword, ErrorIconAlignment.MiddleLeft)
            ErrorProvider2.SetIconPadding(txtOldPassword, 5)
        Else
            ErrorProvider2.SetError(txtOldPassword, "Match")
            ErrorProvider2.Icon = My.Resources.valid
            ErrorProvider2.SetIconAlignment(txtOldPassword, ErrorIconAlignment.MiddleLeft)
            ErrorProvider2.SetIconPadding(txtOldPassword, 5)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Dim conn As New ClsQBOledb(StringConnection)
        If txtNewPassword.Text = txtRypePassword.Text And txtOldPassword.Text = Password Then
            If AskMessage("Password will be change for Permanent?") = Windows.Forms.DialogResult.Yes Then
                conn.Execute(String.Format("Update {0} set [{1}]= {2} where [{3}]={4}", TABLE, FIELD_PASSWORD, CSQL(txtNewPassword.Text), FIELD_USERID, CSQL(USERID)))
                If conn.RowsEffected = 0 Then
                    WarnMessage("Failed update password")
                Else
                    Me.Close()
                End If
            End If
        Else
            ShieldMessage("Data not complete")
        End If
    End Sub
End Class