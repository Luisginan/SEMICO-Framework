Imports System.Collections.Specialized
Public Class SEMICO_Table
    Sub New()
        Field = New StringCollection
        FieldCaption = New StringCollection
        FieldCriteria = New StringCollection
    End Sub

    Sub New(tableName As String, fieldKey As String, Optional tableNameOriginal As String = "")
        Me.TableName = tableName
        If tableNameOriginal = "" Then
            Me.TableNameOriginal = tableName
        Else
            Me.TableNameOriginal = tableNameOriginal
        End If


        Me.FieldKey = fieldKey

        Field = New StringCollection
        FieldCaption = New StringCollection
        FieldCriteria = New StringCollection
    End Sub

    Public Sub AddFields(item As String)
        If item = "" Then Exit Sub
        Dim f = item.Split(",")
        Field.AddRange(f)
    End Sub

    Public Sub AddFieldCaptions(item As String)
        If item = "" Then Exit Sub
        Dim f = item.Split(",")
        FieldCaption.AddRange(f)
    End Sub

    Public Sub AddFieldCriterias(item As String)
        If item = "" Then Exit Sub
        Dim f = item.Split(",")
        FieldCriteria.AddRange(f)
    End Sub

    Public ReadOnly TableName As String
    Public ReadOnly TableNameOriginal As String
    Public ReadOnly FieldKey As String
    Public ReadOnly Field As StringCollection
    Public ReadOnly FieldCaption As StringCollection
    Public ReadOnly FieldCriteria As StringCollection


End Class
