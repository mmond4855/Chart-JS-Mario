Imports System.Drawing

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Colors()
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
End Class