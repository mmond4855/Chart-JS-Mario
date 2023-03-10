Imports Newtonsoft.Json
Imports System.Drawing

'This file will store Hilliard Chart Data in a JSON-based object.
Public Class ChartJSConfig
    <JsonProperty(PropertyName:="type")>
    Public Property ChartJSMainType As String
    <JsonProperty(PropertyName:="datasets")>
    Public Property ChartJSDatasets As New ChartJSDatasets()

    Public Sub New()

    End Sub
End Class

Public Class ChartJSDatasets
    <JsonProperty(PropertyName:="labels")>
    Public Property ChartJSDatasetsLabels As New List(Of String)
    <JsonProperty(PropertyName:="datasets")>
    Public Property ChartJsDatasets As New List(Of ChartJSDataset)
    <JsonProperty(PropertyName:="dataset")>
    Public Property ChartJSDataset As New ChartJSDataset
    <JsonProperty(PropertyName:="mainChartTitle")>
    Public Property MainChartTitle As String
    Public Property JSON As String

    Public Sub New()

    End Sub

End Class

Public Class ChartJSDataset
    <JsonProperty(PropertyName:="label")>
    Public Property ChartJSTooltipLabel As String
    <JsonProperty(PropertyName:="data")>
    Public Property YValues As New List(Of String)
    <JsonProperty(PropertyName:="borderColor")>
    Public Property BorderColor As String
    <JsonProperty(PropertyName:="backgroundColor")>
    Public Property BackgroundColor As String
    <JsonProperty(PropertyName:="backgroundColors")>
    Public Property BackgroundColors As New List(Of String)
    <JsonProperty(PropertyName:="chartTitle")>
    Public Property ChartTitle As String
    <JsonProperty(PropertyName:="order")>
    Public Property Order As Integer
    Public Property DataSetName As String '* Not for Chart.JS

    Public Sub New()

    End Sub
End Class

Public Class ChartJSMarginLine
    Inherits ChartJSDataset

    <JsonProperty(PropertyName:="type")>
    Public Property ChartJSType As String
    <JsonProperty(PropertyName:="fill")>
    Public Property ChartJSFill As Boolean
    <JsonProperty(PropertyName:="pointRadius")>
    Public Property PointRadius As Integer

    Public Sub New()

    End Sub
End Class


Public Class ChartJSColors
    Private Property SysColors As New List(Of Color) From {Color.Red, Color.Blue, Color.Orange, Color.Green, Color.Yellow, Color.Violet, Color.Indigo,
        Color.Lime, Color.Beige, Color.Chocolate, Color.Tomato, Color.Tan, Color.Purple, Color.DeepPink, Color.DarkGreen}
    Public Property SelectedColor As Color

    Public Sub New()
        Shuffle()
    End Sub

    Private Sub Shuffle()
        'Functions for Converting Drawing.Color into a hexadecimal string. 
        Dim GetSelectedColor As Func(Of IEnumerable(Of Color), Color) = Function(list)
                                                                            Dim Rnd As New Random
                                                                            Dim SelectedIndex As Integer = Rnd.Next(0, list.Count)

                                                                            Return list(SelectedIndex)
                                                                        End Function


        Dim NumRandom As New Random
        Dim ShuffledList As List(Of Color) = Me.SysColors.ToList
        For CurrentListIndex = 0 To ShuffledList.Count - 1
            Dim RandomIndex = NumRandom.Next(CurrentListIndex, ShuffledList.Count)
            If CurrentListIndex <> RandomIndex Then
                Dim TempData As Color = ShuffledList(CurrentListIndex)
                ShuffledList(CurrentListIndex) = ShuffledList(RandomIndex)
                ShuffledList(RandomIndex) = TempData
            End If
        Next

        Me.SysColors = ShuffledList
        Me.SelectedColor = GetSelectedColor(Me.SysColors.AsEnumerable())

    End Sub
End Class