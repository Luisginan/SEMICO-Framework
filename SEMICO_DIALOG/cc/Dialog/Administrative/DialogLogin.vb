Imports Semico.ClsMessageDialog
Imports Semico.ClsQB

Public Class DialogLogin
    Implements Dialog

    Private _Criteria As String
    Private _ValueUserID As String
    Private _ValuePassword As String
    Private _HasValue As Boolean = False
    Private Const INVALID_LOGIN As String = "Incorrect username/password combination"
    Private _Value As String = "Illegal User"
    Private _StrTabel, _StrFieldUser, _StrFieldPassword As String
    Private _StrKoneksi As String
    Private _Source As New ClsImageAndSound

    Private Property errorLogin As String = "Invalid login"
    Public ReadOnly Property HASVALUE() As Boolean
        Get
            Return _HasValue
        End Get
    End Property
    Public ReadOnly Property VALUE() As String
        Get
            Return _Value
        End Get
    End Property
    Public ReadOnly Property VALUE_PASSWORD() As String
        Get
            Return _ValuePassword
        End Get
    End Property
    Public ReadOnly Property VALUE_USERID() As String
        Get
            Return _ValueUserID
        End Get
    End Property
    Public Property CRITERIA() As String
        Get
            Return IIf(_Criteria = "", _Criteria, " and " & _Criteria)
        End Get
        Set(ByVal value As String)
            _Criteria = value
        End Set
    End Property
    Public Property FOR_DEMO() As Boolean

    ''' <summary>
    ''' For Demo Only
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        InitializeComponent()
    End Sub

    Sub New(ByVal connectionString As String, ByVal table As String, ByVal userNameField As String, ByVal passwordField As String)
        InitializeComponent()
        _StrKoneksi = connectionString
        _StrFieldUser = userNameField
        _StrFieldPassword = passwordField
        _StrTabel = table
    End Sub

    Public Sub SetLogoImages(ByVal FilePath As String)
        LogoPictureBox.Image = _Source.GetImages(FilePath)
    End Sub

    Private Sub SetValueForDemo()
        _HasValue = True
        _Value = txtUserName.Text
        _ValueUserID = txtUserName.Text
        _ValuePassword = txtPassword.Text
    End Sub
    Private Sub ValidateControls(ByRef result As Boolean)
        result = False
        If txtUserName.Text = "" Then
            WarnMessage("Username can't be blank ")
            txtUserName.Focus()
            result = True : Exit Sub
        End If
    End Sub
    Private Sub OK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK.Click
        Dim result As Boolean
        ValidateControls(result)
        If result Then
            Return
        End If
        Try
            If FOR_DEMO = True Then
                SetValueForDemo()
                Me.Close()
            End If
            If GetStatusLogin(txtUserName.Text, txtPassword.Text) = False Then
                ShieldMessage(errorLogin)
            Else
                _HasValue = True
                Me.Close()
            End If
        Catch ex As Exception
            ErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub CloseME(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoadSources() Implements Dialog.LoadSources
        OK.Image = _Source.GetImages(EnumTipeGambar.CEKLIST)
        Cancel.Image = _Source.GetImages(EnumTipeGambar.CloseFormPNG)
    End Sub

    Private Sub LoadDialog(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadSources()
    End Sub

    Private Sub SetValueSuccess()
        _Value = txtUserName.Text
        _ValueUserID = txtUserName.Text
        _ValuePassword = txtPassword.Text
    End Sub
    Function GetStatusLogin(ByVal TextUser As String, ByVal TextPassword As String) As Boolean
        Dim conn As New ClsSqlOledb(_StrKoneksi)
        Dim BoStatusLogin As Boolean = False
        Dim sql As String = String.Format("select * from {0} where [{1}]={2} {3}", _StrTabel, _StrFieldUser, CSQL(TextUser), CRITERIA)
        If conn.Execute(sql).Rows.Count = 0 Then
            BoStatusLogin = False
            errorLogin = INVALID_LOGIN
            txtUserName.Focus()
        Else
            If TextPassword.Equals(conn(_StrFieldPassword)) Then
                BoStatusLogin = True
                SetValueSuccess()
            Else
                errorLogin = INVALID_LOGIN
                txtPassword.Focus()
            End If
        End If
        Return BoStatusLogin
    End Function

    Public Sub ShowMe() Implements Dialog.ShowMe
        Me.ShowDialog()
    End Sub

    Private Sub DialogLogin_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        txtUserName.Focus()
    End Sub
End Class