Public Class ClsValidationWinform
    Private Shared _control As Control
    Public Shared ReadOnly Property ControlError() As Control
        Get
            Return _control
        End Get
    End Property
    ''' <summary>
    ''' Luis : Membersihkan teksbox di form , FRM adalah Form,groupbox atau panel
    ''' Misal : clearFormtextbox(Me) By Luis
    ''' </summary>
    ''' <param name="FRM"></param>
    ''' <remarks></remarks>
    Public Shared Sub clearFormtextbox(ByVal FRM As Control)
        Dim control As Control
        Dim LControl As Control.ControlCollection = FRM.Controls
        For Each control In LControl
            If TypeOf control Is TextBox Then
                control.Text = ""
            End If
        Next
    End Sub

    Public Shared Sub ClearDTpicker(ByVal FRM As Control)
        Dim control As Control
        Dim LControl As Control.ControlCollection = FRM.Controls
        For Each control In LControl
            If TypeOf control Is DateTimePicker Then
                Dim DTP As DateTimePicker = control
                DTP.Value = Date.Today
            End If
        Next
    End Sub

    Public Shared Sub ClearDatagrid(ByVal FRM As Control)
        Dim control As Control
        Dim LControl As Control.ControlCollection = FRM.Controls
        For Each control In LControl
            If TypeOf control Is DataGridView Then
                Dim DG As DataGridView = control
                Try
                    DG.Rows.Clear()
                Catch ex As Exception
                    DG.DataSource = Nothing
                End Try
            End If
        Next
    End Sub

    Public Shared Sub ClearNumericUpDown(ByVal FRM As Control)
        Dim LControl As Control.ControlCollection = FRM.Controls
        For Each Control As Control In LControl
            If TypeOf Control Is NumericUpDown Then
                Dim DG As NumericUpDown = Control
                DG.Value = 0
            End If
        Next
    End Sub

    ''' <summary>
    ''' Set enabled properties all controls in form
    ''' </summary>
    ''' <param name="FRM"> FRM as Groupbox or Panel control</param>
    ''' <param name="Status"> Status set True or False </param>
    ''' <remarks></remarks>
    Public Shared Sub EnabledFormControl(ByVal FRM As Control, Optional ByVal Status As Boolean = False)
        Dim LControl = FRM.Controls
        For Each control As Control In LControl
            If TypeOf control Is Label Then Continue For
            If TypeOf control Is GroupBox Or TypeOf control Is Panel Then
                EnabledFormControl(control, Status)
            ElseIf TypeOf control Is TextBox Then
                Dim txt As TextBox = control
                txt.ReadOnly = Not Status
            Else
                control.Enabled = Status
            End If
        Next
    End Sub

    ''' <summary>
    ''' Clear value all of control on Group
    ''' </summary>
    ''' <param name="FRM">FRM as Groupbox or Panel control</param>
    ''' <remarks></remarks>
    Public Shared Sub ClearAll(ByVal FRM As Control)
        For Each Control As Control In FRM.Controls
            If TypeOf Control Is GroupBox Or TypeOf Control Is Panel Then
                ClearAll(Control)
            ElseIf TypeOf Control Is TextBox Then
                clearFormtextbox(FRM)
            ElseIf TypeOf Control Is DataGridView Then
                ClearDatagrid(FRM)
            ElseIf TypeOf Control Is ComboBox Then
                clearFormCombobox(FRM)
            ElseIf TypeOf Control Is NumericUpDown Then
                ClearNumericUpDown(FRM)
            ElseIf TypeOf Control Is DateTimePicker Then
                ClearDTpicker(FRM)
            End If
        Next
    End Sub

    'UNDONE Tambahkan option button dan checkbox
    ''' <summary>
    ''' set Group control disable empty value
    ''' </summary>
    ''' <param name="FRM">FRM as Groupbox or Panel control</param>
    ''' <returns>return True or false </returns>
    ''' <remarks></remarks>
    Public Shared Function AllAntiNull(ByVal FRM As Control) As Boolean
        Dim status As Boolean = True
        If TeksboxAntiNull(FRM) = False Then
            status = False
        ElseIf ComboboxAntiNull(FRM) = False Then
            status = False
        ElseIf NumericUpDownAntiNull(FRM) = False Then
            status = False
        ElseIf DataGridAntiNull(FRM) = False Then
            status = False
        End If
        Return status
    End Function
    ''' <summary>
    ''' Luis : membuat semua teksbox didalam suatu form
    ''' harus diisikan, nilai kembalian true berarti valid
    ''' nilai kembalian false berarti invalid, Form,groupbox atau panel
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TeksboxAntiNull(ByVal FRM As Control) As Boolean
        Dim status As Boolean = True
        Dim ctrl As Control
        Dim Lctrl As Control.ControlCollection = FRM.Controls
        For Each ctrl In Lctrl
            If TypeOf ctrl Is TextBox Then
                If ctrl.Text = "" Or ctrl.Text.Length = 0 Then
                    _control = ctrl
                    status = False
                    Exit For
                End If
            End If
        Next
        Return status
    End Function

    Public Shared Function ComboboxAntiNull(ByVal FRM As Control) As Boolean
        Dim status As Boolean = True
        Dim ctrl As Control
        Dim Lctrl As Control.ControlCollection = FRM.Controls
        For Each ctrl In Lctrl
            If TypeOf ctrl Is ComboBox Then
                Dim CBO As ComboBox = ctrl
                If CBO.Text = "" Or CBO.SelectedIndex = -1 Then
                    _control = ctrl
                    status = False
                    Exit For
                End If
            End If
        Next
        Return status
    End Function
    ''' <summary>
    ''' Set MOde button automatic for standar input form button
    ''' </summary>
    ''' <param name="FRM">FRM as Groupbox or Panel control</param>
    ''' <param name="mode">EnumModeButton</param>
    ''' <remarks></remarks>
    Public Shared Sub SetModeButtons(ByVal FRM As Control, Optional ByVal mode As EnumModeButton = EnumModeButton.normal)
        Dim ctrl As Control
        Dim Lctrl As Control.ControlCollection = FRM.Controls

        For Each ctrl In Lctrl
            If ctrl.Name.ToUpper Like "*SAVE*" Or ctrl.Name.ToUpper Like "*SIMPAN*" Then
                If mode = EnumModeButton.normal Then
                    ctrl.Enabled = False
                ElseIf mode = EnumModeButton.edited Then
                    ctrl.Enabled = True
                ElseIf mode = EnumModeButton.added Then
                    ctrl.Enabled = True
                End If
            ElseIf ctrl.Name.ToUpper Like "*ADD*" Or ctrl.Name.ToUpper Like "*NEW*" Or ctrl.Name.ToUpper Like "*TAMBAH*" Then
                If mode = EnumModeButton.normal Then
                    ctrl.Enabled = True
                ElseIf mode = EnumModeButton.edited Then
                    ctrl.Enabled = False
                ElseIf mode = EnumModeButton.added Then
                    ctrl.Enabled = False
                End If
            ElseIf ctrl.Name.ToUpper Like "*SEARCH*" Or ctrl.Name.ToUpper Like "*CARI*" Then
                If mode = EnumModeButton.normal Then
                    ctrl.Enabled = True
                ElseIf mode = EnumModeButton.edited Then
                    ctrl.Enabled = False
                ElseIf mode = EnumModeButton.added Then
                    ctrl.Enabled = False
                End If
            ElseIf ctrl.Name.ToUpper Like "*DELETE*" Or ctrl.Name.ToUpper Like "*HAPUS*" Then
                If mode = EnumModeButton.normal Then
                    ctrl.Enabled = False
                ElseIf mode = EnumModeButton.edited Then
                    ctrl.Enabled = True
                ElseIf mode = EnumModeButton.added Then
                    ctrl.Enabled = False
                End If
            ElseIf ctrl.Name.ToUpper Like "*CANCEL*" Or ctrl.Name.ToUpper Like "*BATAL*" Then
                If mode = EnumModeButton.normal Then
                    ctrl.Enabled = False
                ElseIf mode = EnumModeButton.edited Then
                    ctrl.Enabled = True
                ElseIf mode = EnumModeButton.added Then
                    ctrl.Enabled = True
                End If
            End If
        Next
    End Sub

    Public Shared Function DataGridAntiNull(ByVal FRM As Control) As Boolean
        Dim status As Boolean = True
        Dim ctrl As Control
        Dim Lctrl As Control.ControlCollection = FRM.Controls
        For Each ctrl In Lctrl
            If TypeOf ctrl Is DataGridView Then
                Dim DGV As DataGridView = ctrl
                If DGV.RowCount = 0 Then
                    _control = ctrl
                    status = False
                    Exit For
                End If
            End If
        Next
        Return status
    End Function

    Public Shared Function NumericUpDownAntiNull(ByVal FRM As Control) As Boolean
        Dim status As Boolean = True
        Dim ctrl As Control
        Dim Lctrl As Control.ControlCollection = FRM.Controls
        For Each ctrl In Lctrl
            If TypeOf ctrl Is NumericUpDown Then
                Dim NUD As NumericUpDown = ctrl
                If NUD.Value <= 0 Then
                    _control = ctrl
                    status = False
                    Exit For
                End If
            End If
        Next
        Return status
    End Function

    ''' <summary>
    ''' Luis : Membersihkan combobox teksbox di form , FRM adalah Form,groupbox atau panel
    ''' Misal : clearFormCombobox(Me)
    ''' </summary>
    ''' <param name="FRM"></param>
    ''' <remarks></remarks>
    Public Shared Sub clearFormCombobox(ByVal FRM As Control)
        Dim control As Control
        Dim LControl As Control.ControlCollection = FRM.Controls
        For Each control In LControl
            If TypeOf control Is ComboBox Then
                Dim combo As ComboBox = control
                combo.SelectedIndex = -1
                If combo.Text <> "" Then
                    combo.Text = ""
                End If
            End If
        Next
    End Sub

    Public Shared Function KetikAngka(ByVal e As Char) As Char
        If Not IsNumeric(e) Then
            If Not ((e = ".") Or Asc(e) = 8 Or Asc(e) = 13) Then
                Return Chr(Keys.None)
            Else
                Return e
            End If
        Else
            Return e
        End If
    End Function

    ''' <summary>
    ''' Handle keypress textbox control for numeric only
    ''' put on event keypress
    ''' type InputOnlyNumeric(e)
    ''' </summary>
    ''' <param name="e">KeyPressEventArgs</param>
    ''' <remarks></remarks>
    Public Shared Sub InputOnlyNumeric(ByRef e As KeyPressEventArgs, Optional ByVal AllowMinus As Boolean = False)
        If Not IsNumeric(e.KeyChar) Then
            If AllowMinus = False Then
                If Not ((e.KeyChar = ".") Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13) Then
                    e.KeyChar = Chr(Keys.None)
                End If
            Else
                If Not ((e.KeyChar = ".") Or (e.KeyChar = "-") Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13) Then
                    e.KeyChar = Chr(Keys.None)
                End If
            End If
        End If
    End Sub

End Class