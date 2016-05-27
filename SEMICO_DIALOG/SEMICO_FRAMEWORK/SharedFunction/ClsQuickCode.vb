Imports System.Reflection
Imports System.Linq
Imports System.Math
Imports Semico.ClsQB_SQL

Public Class ClsQuickCode

    Private Sub New()

    End Sub
    Public Shared Function FormatRoundDecimal(ByVal value As Decimal) As Decimal
        Return Round(value, 2)
    End Function

    ''' <summary>
    ''' Mengcopy properties dari satu object ke object lain
    ''' </summary>
    ''' <param name="to">Destination Object</param>
    ''' <param name="from">Source object</param>
    ''' <param name="excludedProperties">Exclude property</param>
    ''' <remarks>15-5-2013</remarks>
    Public Shared Sub TransferProperties([to] As Object, from As Object, Optional excludedProperties As String() = Nothing)
        Dim targetType As Type = [to].[GetType](), sourceType As Type = from.[GetType]()
        Dim sourceProps As PropertyInfo() = sourceType.GetProperties()
        For Each propInfo As PropertyInfo In sourceProps
            If excludedProperties IsNot Nothing AndAlso excludedProperties.Any(Function(b) propInfo.Name.ToLower.Contains(b.ToLower)) Then
                Continue For
            End If
            Dim toProp As PropertyInfo = If((targetType = sourceType), propInfo, targetType.GetProperty(propInfo.Name))
            If toProp IsNot Nothing AndAlso toProp.CanWrite Then
                Dim value As [Object] = propInfo.GetValue(from, Nothing)
                toProp.SetValue([to], value, Nothing)
            End If
        Next
    End Sub

    ''' <summary>
    ''' jika bukan numeric berarti return = 0
    ''' </summary>
    ''' <param name="Obx"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EN(ByVal Obx As Object) As Decimal
        If IsNumeric(Obx) = False Then
            Obx = 0
        End If
        Return Obx
    End Function

    ''' <summary>
    ''' jika DBnull maka jadi Nothing
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NN(ByVal Obj As Object) As Object
        Return IIf(IsDBNull(Obj) = True, Nothing, Obj)
    End Function
    'UNDONE periksa lagi kegunaannya ya...
    ''' <summary>
    ''' jika nothing atau jam #12:00:00 AM# , string > "",datetime > Today
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NE(ByVal Obj As Object) As Object
        If Obj Is Nothing Or Obj = #12:00:00 AM# Then
            If TypeOf (Obj) Is String Then
                Obj = ""
            ElseIf TypeOf (Obj) Is DateTime Then
                Obj = Date.Today
            End If
        End If
        Return Obj
    End Function
    ''' <summary>
    ''' jika DBNull as ""
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ND(ByVal Obj As Object) As Object
        If IsDBNull(Obj) = True Then
            Obj = ""
        End If
        Return Obj
    End Function

    ''' <summary>
    ''' Mengambil Nama Fungsi
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMethodName(Optional ByVal deep As Integer = 1) As String
        Dim MethodName = New StackTrace().GetFrame(deep).GetMethod().Name
        Return MethodName
    End Function
    ''' <summary>
    ''' Memisahkan String (default '-')
    ''' </summary>
    ''' <param name="text"></param>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks>7 juni 2010 </remarks>
    Public Shared Function CSplit(ByVal text As String, ByVal index As Integer, Optional ByVal SeparatorSymbol As String = "-") As String
        Dim temp As String
        Dim value As String() = text.Split(SeparatorSymbol)
        temp = value(index)
        Return temp
    End Function
    ''' <summary>
    ''' Mengambil alamat sebuah file dalam Folder Path
    ''' </summary>
    ''' <param name="fileName">Optioanal name is file name </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function AppPath(Optional ByVal fileName As String = "") As String
        Return String.Format("{0}\{1}", My.Application.Info.DirectoryPath, fileName)
    End Function
    ''' <summary>
    ''' Mendapatkan Koneksi String Access 2003
    ''' </summary>
    ''' <param name="AlmatFile "></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function ProviderAccess(ByVal AlmatFile As String) As String
        Return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=False", AlmatFile)
    End Function
    ''' <summary>
    ''' Mendapatkan Koneksi String Access 2007
    ''' </summary>
    ''' <param name="AlmatFile "></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function ProviderAccess2007(ByVal AlmatFile As String) As String
        Return String.Format(" Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False", AlmatFile)
    End Function
    ''' <summary>
    ''' Mendapatkan Koneksi String SQL Server Menggunakan SQL Native (umumnya untuk SQL Server 2005)
    ''' </summary>
    ''' <param name="User "></param>
    ''' <param name="Password "></param>
    ''' <param name="Server "></param>
    ''' <param name="DataBase "></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function ProviderSQLserver_Net(ByVal User As String, ByVal Password As String, ByVal Server As String, ByVal DataBase As String) As String
        Return String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", Server, DataBase, User, Password)
    End Function
    ''' <summary>
    ''' Mendapatkan Koneksi String SQL Server Menggunakan SQL Server Provider (umumnya untuk SQL server 2000)
    ''' </summary>
    ''' <param name="User "></param>
    ''' <param name="Password "></param>
    ''' <param name="Server "></param>
    ''' <param name="DataBase "></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function ProviderSQLserver(ByVal User As String, ByVal Password As String, ByVal Server As String, ByVal DataBase As String) As String
        Return String.Format("Provider=SQLOLEDB.1;Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3}", Password, User, DataBase, Server)
    End Function
    ''' <summary>
    ''' Mendapatkan Koneksi String menggunakan ODBC
    ''' </summary>
    ''' <param name="DSN "></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function ProviderODBC(ByVal DSN As String, ByVal user As String, ByVal pass As String) As String
        Return String.Format("Dsn={0};uid={1};pwd={2}", DSN, user, pass)
    End Function
    ''' <summary>
    ''' Mendapatkan Koneksi String MySQL
    ''' </summary>
    ''' <param name="User "></param>
    ''' <param name="Password "></param>
    ''' <param name="Server "></param>
    ''' <param name="DataBase "></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function ProviderMySQL_NET(ByVal User As String, ByVal Password As String, ByVal Server As String, ByVal DataBase As String) As String
        Return String.Format("server={0};uid={1};pwd={2};database={3}", Server, User, Password, DataBase)
    End Function
    ''' <summary>
    ''' Membuat Penomoran datagrid UptoDate (Not set with Binding)
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <remarks></remarks>
    Public Shared Sub Numbering(ByVal Grid As DataGridView)
        Dim Row As Integer
        Dim No As Integer

        With Grid
            For Row = 0 To .Rows.Count - 1
                No = No + 1
                .Rows(Row).Cells(0).Value = No
            Next
        End With
    End Sub
    ''' <summary>
    ''' DT to Form automaticly
    ''' </summary>
    ''' <param name="Grp"></param>
    ''' <param name="DR"></param>
    ''' <param name="DT"></param>
    ''' <remarks>28 januari 2011</remarks>
    Public Shared Sub BindingGroupControl(ByVal Grp As Control, ByVal DR As DataRow, Optional ByVal DT As DataTable = Nothing)
        For Each i As Control In Grp.Controls
            Try
                If TypeOf (i) Is TextBox Then
                    Dim tb As TextBox = i
                    tb.Text = DR(tb.Tag)
                ElseIf TypeOf (i) Is ComboBox Then
                    Dim tb As ComboBox = i
                    tb.Text = DR(tb.Tag)
                ElseIf TypeOf (i) Is DateTimePicker Then
                    Dim tb As DateTimePicker = i
                    tb.Value = DR(tb.Tag)
                ElseIf TypeOf (i) Is CheckBox Then
                    Dim tb As CheckBox = i
                    tb.Checked = DR(tb.Tag)
                ElseIf TypeOf (i) Is RadioButton Then
                    Dim tb As RadioButton = i
                    tb.Checked = DR(tb.Tag)
                ElseIf TypeOf (i) Is DataGridView Then
                    Dim tb As DataGridView = i
                    tb.DataSource = DT.DefaultView
                End If
            Catch ex As Exception
                Return
            End Try
        Next
    End Sub

    Public Shared Sub BindingGroupControl2(ByVal Grp As Control, ByVal datasource As Object)
        If TypeOf datasource Is DataRow Then
            Dim DT As New DataTable
            Dim DR As DataRow = datasource
            DT = DR.Table.Copy
            datasource = DT
        End If
        Using BS As New BindingSource() With {.DataSource = datasource}
            For Each i As Control In Grp.Controls
                i.DataBindings.Clear()
                Try
                    If TypeOf (i) Is TextBox Then
                        Dim tb As TextBox = i
                        tb.DataBindings.Add("Text", BS, tb.Tag)
                    ElseIf TypeOf (i) Is ComboBox Then
                        Dim tb As ComboBox = i
                        tb.DataBindings.Add("Text", BS, tb.Tag)
                    ElseIf TypeOf (i) Is DateTimePicker Then
                        Dim tb As DateTimePicker = i
                        tb.DataBindings.Add("value", BS, tb.Tag)
                    ElseIf TypeOf (i) Is CheckBox Then
                        Dim tb As CheckBox = i
                        tb.DataBindings.Add("checked", BS, tb.Tag)
                    ElseIf TypeOf (i) Is RadioButton Then
                        Dim tb As RadioButton = i
                        tb.DataBindings.Add("checked", BS, tb.Tag)
                    ElseIf TypeOf (i) Is DataGridView Then
                        Dim tb As DataGridView = i
                        tb.DataSource = BS
                    End If
                Catch ex As Exception
                    Return
                End Try
            Next
        End Using
    End Sub
    ''' <summary>
    ''' Next Focus
    ''' </summary>
    ''' <param name="frm"></param>
    ''' <param name="sender"></param>
    ''' <remarks>28 january 2011</remarks>
    Public Shared Sub SetNextFocus(ByVal frm As Object, ByVal sender As Object)
        If Len(sender.text) = sender.MaxLength Then
            frm.SelectNextControl(sender, True, True, True, True)
        End If
    End Sub

    Public Shared Function GetAge(ByVal Tgl1 As String, ByVal Tgl2 As String) As String
        Dim V_Interval As Long
        Dim N_Interval As String
        Dim V_Bulan As Long
        Dim N_Bulan As String
        V_Interval = DateDiff("d", Tgl1, Tgl2)
        Select Case V_Interval
            Case Is <= 30
                If V_Interval = 30 Then
                    N_Interval = "1 bulan"
                Else
                    N_Interval = V_Interval & " hari"
                End If
            Case Is <= 365
                If V_Interval = 365 Then
                    N_Interval = "1 tahun"
                Else
                    N_Interval = String.Format("{0} bulan {1} hari", CInt(V_Interval / 30), V_Interval Mod 30)
                End If
            Case Else
                If V_Interval Mod 365 = 0 Then
                    N_Interval = CInt(V_Interval / 365) & " tahun"
                Else
                    V_Bulan = V_Interval Mod 365
                    If V_Bulan < 30 Then
                        N_Bulan = String.Format("0 bulan {0} hari", V_Bulan)
                    Else
                        N_Bulan = String.Format("{0} bulan {1} hari", CInt(V_Bulan / 30), V_Bulan Mod 30)
                    End If
                    N_Interval = String.Format("{0} tahun {1}", CInt(V_Interval / 365), N_Bulan)
                End If
        End Select
        GetAge = N_Interval
    End Function
    'UNDONE rubah jadi fungsi
    Public Shared Sub GetDetailAges(ByVal Tgl1 As String, ByVal Tgl2 As String, ByRef Tahun As Integer, ByRef Bulan As Integer, ByRef Hari As Integer)
        Dim V_Interval As Long
        Dim V_Bulan As Long
        V_Interval = DateDiff("d", Tgl1, Tgl2)
        Select Case V_Interval
            Case Is <= 30
                If V_Interval = 30 Then
                    Tahun = 0
                    Bulan = 1
                    Hari = 0
                Else
                    Tahun = 0
                    Bulan = 0
                    Hari = V_Interval
                End If
            Case Is <= 365
                If V_Interval = 365 Then
                    Tahun = 1
                    Bulan = 0
                    Hari = 0
                Else
                    Tahun = 0
                    Bulan = CInt(V_Interval / 30)
                    Hari = V_Interval Mod 30
                End If
            Case Else
                If V_Interval Mod 365 = 0 Then
                    Tahun = CInt(V_Interval / 365)
                    Bulan = 0
                    Hari = 0
                Else
                    V_Bulan = V_Interval Mod 365
                    If V_Bulan < 30 Then
                        Bulan = 0
                        Hari = V_Bulan
                    Else
                        Bulan = CInt(V_Bulan / 30)
                        Hari = V_Bulan Mod 30
                    End If
                    Tahun = CInt(V_Interval / 365)
                End If
        End Select
    End Sub
    ''' <summary>
    ''' Indonesian Month Name
    ''' </summary>
    ''' <param name="NomorBulan"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getMonthName(ByVal NomorBulan As Int16) As String
        getMonthName = ""
        Select Case NomorBulan
            Case 1 : Return "Januari"
            Case 2 : Return "Februari"
            Case 3 : Return "Maret"
            Case 4 : Return "April"
            Case 5 : Return "Mei"
            Case 6 : Return "Juni"
            Case 7 : Return "Juli"
            Case 8 : Return "Agustus"
            Case 9 : Return "September"
            Case 10 : Return "Oktober"
            Case 11 : Return "Nopember"
            Case 12 : Return "Desember"
        End Select
    End Function
    ''' <summary>
    ''' Latin to roman
    ''' </summary>
    ''' <param name="Angka"></param>
    ''' <returns></returns>
    ''' <remarks>M:1 januari 2011</remarks>
    Public Shared Function getRomawi(ByVal Angka As Integer) As String
        getRomawi = ""
        Return Latin2Roman(Angka)
    End Function
    ''' <summary>
    ''' Latin to Roman
    ''' </summary>
    ''' <param name="number"></param>
    ''' <returns></returns>
    ''' <remarks>A:1 januari 2011</remarks>
    Public Shared Function Latin2Roman(ByVal number As Long) As String
        Dim n As Long
        Dim j As Integer, i As Integer
        Dim Latin As Object = New Integer() {1, 4, 5, 9, _
                                                10, 40, 50, 90, _
                                                100, 400, 500, 900, _
                                                1000 _
                                            }
        Dim Romawi As String = ""
        Dim Rom As Object = New String() {"i", "iv", "v", "ix", _
                                            "x", "xl", "l", "xc", _
                                            "c", "cd", "d", "cm", _
                                            "m" _
                                         }
        For j = 12 To 0 Step -1
            n = Int(number / Latin(j))
            If n <> 0 Then
                For i = 1 To n
                    Romawi = Romawi & Rom(j)
                Next i
            End If
            number = number Mod Latin(j)
        Next
        Return Romawi
    End Function
    ''' <summary>
    ''' Roman To latin
    ''' </summary>
    ''' <param name="Romawi"></param>
    ''' <returns></returns>
    ''' <remarks>A: 1 januari 2011</remarks>
    Public Shared Function Roman2Latin(ByVal Romawi As String) As Long
        Dim n As Long = 0
        Dim i As Integer
        Dim Latin As Object = New Integer() {1, 4, 5, 9, _
                                                10, 40, 50, 90, _
                                                100, 400, 500, 900, _
                                                1000 _
                                            }

        Dim Rom As Object = New String() {"i", "1", "v", "2", _
                                            "x", "3", "l", "4", _
                                            "c", "5", "d", "6", _
                                            "m" _
                                         }

        Romawi = Replace(Romawi, "iv", "1")
        Romawi = Replace(Romawi, "ix", "2")
        Romawi = Replace(Romawi, "xl", "3")
        Romawi = Replace(Romawi, "xc", "4")
        Romawi = Replace(Romawi, "cd", "5")
        Romawi = Replace(Romawi, "cm", "6")
        For i = 12 To 0 Step -1
            While Rom(i) = Mid(Romawi, 1, 1) And Len(Romawi) > 0
                n = n + Latin(i)
                Romawi = Mid(Romawi, 2)
            End While
        Next i
        Roman2Latin = n
    End Function

    Public Shared Function FilterDT(ByVal DT As DataTable, ByVal FildName As String, ByVal Criteria As String) As DataTable
        Dim temp As DataTable
        'Methode : LINQ tidak meload lagi ke database tapi Query ke Datatable (Response lebih cepat)
        Dim f As EnumerableRowCollection(Of DataRow) = From i As DataRow In DT.AsEnumerable _
        Where i.Item(FildName).ToString.ToUpper.Contains(Criteria.ToUpper) _
        Select i
        If f.AsDataView.Count > 0 Then
            temp = f.CopyToDataTable
        Else
            temp = New DataTable()
        End If
        Return temp
    End Function

    Public Shared Function Number2Date(ByVal Number As Long) As Date
        'new 2.1
        Dim S As String = Number
        Dim D, M, Y As Integer
        M = S.Substring(4, 2)
        D = S.Substring(6, 2)
        Y = S.Substring(0, 4)
        Return New Date(Y, M, D)
    End Function

    Public Shared Function JoinString(ByVal ctrl As Control, Optional ByVal type As EnumType = 1) As String
        Dim temp As String = ""
        If TypeOf ctrl Is TextBox Then
            Dim txtbox As TextBox = ctrl
            temp = String.Format("{0}={1}", txtbox.Tag, CSQL(txtbox.Text))
        ElseIf TypeOf ctrl Is ComboBox Then
            Dim DDbox As ComboBox = ctrl
            temp = String.Format("{0}={1}", DDbox.Tag, CSQL(DDbox.Text))
        ElseIf TypeOf ctrl Is DateTimePicker Then
            Dim DTp As DateTimePicker = ctrl
            temp = String.Format("{0}={1}", DTp.Tag, CSQLdate(DTp.Value))
        ElseIf TypeOf ctrl Is Label Then
            Dim lbl As Label = ctrl
            temp = String.Format("{0}={1}", lbl.Tag, CSQL(lbl.Text))
        End If
        If type = EnumType.numeric Then temp = temp.Replace("'", "")
        Return temp
    End Function

    Public Shared Function NumbertoText(ByVal Numbers As Double) As String
        Dim crn As New ClsCurensi
        Return crn.segmentasi(Numbers)
    End Function

    Public Shared Function GetRandomNumberByTime(ByVal Identity As String) As String
        Return Identity & Date.Now.Year & Date.Now.Month & Date.Now.Day & Date.Now.Hour & Date.Now.Minute & Date.Now.Second
    End Function

    ''' <summary>
    ''' For calling other window as child window
    ''' </summary>
    ''' <typeparam name="T">must be System.Windows.Form</typeparam>
    ''' <param name="parent">Form which call this method</param>
    ''' <param name="parameters">parameters for injected to called Form's constructor</param>
    ''' <remarks>2013-11-20 </remarks>
    Public Shared Sub OpenChildWindow(Of T As Form)(ByVal parent As IWin32Window, ByVal ParamArray parameters As Object())
        Using childWindow As T = CType(Activator.CreateInstance(GetType(T), parameters), T)
            childWindow.ShowDialog(parent)
        End Using
    End Sub

    ''' <summary>
    ''' For calling other window as child window and returning value when closed
    ''' Note: returned object must be defined as Field named "ReturnedValue" in target window
    ''' </summary>
    ''' <typeparam name="T">must be System.Windows.Form</typeparam>
    ''' <typeparam name="R">can be anything depends on wished returned object's type</typeparam>
    ''' <param name="parent">Form which call this method</param>
    ''' <param name="parameters">parameters for injected to called Form's constructor</param>
    ''' <returns>R</returns>
    ''' <remarks>2013-11-20</remarks>
    Public Shared Function OpenReturnedValueChildWindow(Of T As Form, R)(ByVal parent As IWin32Window, ByVal ParamArray parameters As Object()) As R
        Const RETURNED_VALUE_FIELD_NAME As String = "ReturnedValue"
        Dim returnedValue As R = CType(Nothing, R) ' VB version of C#'s default (R)
        Using childWindow As T = CType(Activator.CreateInstance(GetType(T), parameters), T)
            Dim childWindowResult = childWindow.ShowDialog(parent)
            If childWindowResult = DialogResult.OK Then
                Dim childWindowReturnedValue As FieldInfo = childWindow.GetType().GetField(RETURNED_VALUE_FIELD_NAME)
                returnedValue = childWindowReturnedValue.GetValue(childWindow)
            End If
        End Using

        Return returnedValue
    End Function
End Class