Imports System.Drawing

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        GenerateCounts()
    End Sub



    Private Sub Colors()
        'Dim properties() As System.Reflection.PropertyInfo = GetType(System.Drawing.Color).GetProperties _
        '    (Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static)
        'Dim color As System.Reflection.PropertyInfo

        'Dim colors As IEnumerable(Of Color) = From colorProperty In properties
        '                                      Select colorProperty.GetValue(Nothing, Nothing)

        'For Each color In properties
        '    Dim x As Color = color.GetValue(Nothing, Nothing)
        'Next
    End Sub

    Private Sub GenerateCounts()
        Dim NumRandom As New Random
        Dim ShuffledList As New List(Of String)
        With ShuffledList
            For CurrentListIndex As Integer = 1 To 12
                Dim Value As Integer = NumRandom.Next(0, 100001)
                .Add(Value)

            Next
        End With
    End Sub
End Class