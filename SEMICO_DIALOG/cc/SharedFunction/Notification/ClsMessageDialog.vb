
Public Class ClsMessageDialog

    Private Shared MSG As DialogMessage
    Private Const TextTitleTips As String = "Tips"
    Private Const TextTitleError As String = "Error"
    Private Const TextTitleInfo As String = "Information"
    Private Const TextTitleWarn As String = "Warning"
    Private Const TextTitleAsk As String = "Confirm"
    Private Const TextTitleAskShileld As String = "Security Confirm"


    Public Shared Sub TipsMessage(ByVal messages As String, Optional ByVal title As String = TextTitleTips)
        MSG = New DialogMessage(messages, title, EnumTipeMessage.Tips)
        MSG.Show()
        MSG.Dispose()
    End Sub

    Public Shared Sub InfoMessage(ByVal messages As String, Optional ByVal title As String = "")
        If title = "" Then title = TextTitleInfo
        Dim MSG As New DialogMessage(messages, title, EnumTipeMessage.Information)
        MSG.Show()
    End Sub

    Public Shared Sub ShieldMessage(ByVal messages As String, Optional ByVal title As String = TextTitleAskShileld)
        MSG = New DialogMessage(messages, title, EnumTipeMessage.NoAcces)
        MSG.Show()
        MSG.Dispose()
    End Sub

    ''' <summary>
    ''' Warning Message
    ''' </summary>
    ''' <param name="Messages"></param>
    ''' <param name="Title"></param>
    ''' <remarks></remarks>
    Shared Sub WarnMessage(ByVal messages As String, Optional ByVal title As String = TextTitleWarn)
        MSG = New DialogMessage(messages, title, EnumTipeMessage.Exlamation)
        MSG.Show()
        MSG.Dispose()
    End Sub

    ''' <summary>
    ''' Error Message
    ''' </summary>
    ''' <param name="Messages"></param>
    ''' <param name="Title"></param>
    ''' <remarks></remarks>
    Shared Sub ErrorMessage(ByVal messages As String, Optional ByVal title As String = TextTitleError)
        MSG = New DialogMessage(messages, title, EnumTipeMessage.Eror)
        MSG.Show()
        MSG.Dispose()
    End Sub

    ''' <summary>
    ''' Ask Message
    ''' </summary>
    ''' <param name="Messages"></param>
    ''' <param name="Title"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function AskMessage(ByVal messages As String, Optional ByVal title As String = TextTitleAsk) As DialogResult
        MSG = New DialogMessage(messages, title, EnumTipeMessage.Question)
        MSG.Show()
        Dim temp As DialogResult = MSG.Value
        MSG.Dispose()
        Return temp
    End Function

    Shared Function AskShieldMesage(ByVal messages As String, Optional ByVal title As String = TextTitleAskShileld) As DialogResult
        Dim MSG As New DialogMessage(messages, title, EnumTipeMessage.AskShield)
        MSG.Show()
        Dim temp As DialogResult = MSG.Value
        MSG.Dispose()
        Return temp
    End Function
End Class

