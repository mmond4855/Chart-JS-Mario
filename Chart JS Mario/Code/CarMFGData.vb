Imports System.Drawing
Imports System.IO
Imports Newtonsoft.Json

Public Class CarMFGData

    Private Property CurrentDate As Date = Date.Now
    Private Property CarMFGs As New List(Of String) From {"Subaru", "BMW", "Ford", "Toyota", "Jeep"}
    Private Property CarSalesData As List(Of CarManufacturer) = GenerateCarSalesList(Me.CarMFGs)

    Public Sub New()

    End Sub

    Public Function GetCarSalesAmountData() As String
        Dim JSONString As String = ""

        'Each month will represent a XAxisLabel.
        Dim CreateXAxisLabels As Func(Of Date, List(Of String)) = Function(x)
                                                                      Dim MonthList As New List(Of String)
                                                                      With MonthList
                                                                          For i = 1 To 12
                                                                              Dim MonthName As String = x.AddMonths(-i).ToString("MMMM yyyy")
                                                                              .Add(MonthName)
                                                                          Next

                                                                          .Reverse()
                                                                      End With
                                                                      Return MonthList
                                                                  End Function


        Dim XAxisLabels As List(Of String) = CreateXAxisLabels(Me.CurrentDate)

        'Functions used to get monthly data by car mfg. 
        Dim GetMonthlyCarSalesAmount As Func(Of CarManufacturer, List(Of String)) = Function(Car) Car.YearlySalesAmtValues
        Dim GetMonthlyCarSoldCount As Func(Of CarManufacturer, List(Of String)) = Function(Car) Car.YearlySoldValues

        'List of each monthly value functions.
        Dim JSDataSetFunctions As New List(Of [Delegate]) From {GetMonthlyCarSalesAmount}

        'List of Each Monthly Metric Function by name.
        Dim JSDataSetFunctionNames As New List(Of String) From {"Monthly Sales Amount"}

        'This function converts a System.Drawing.Color to a Hexadecimal String.
        Dim HexaDecimalConv As Func(Of Color, String) = Function(SelectedColor) String.Format("#{0:X2}{1:X2}{2:X2}", SelectedColor.R, SelectedColor.G, SelectedColor.B).Trim

        'System selected colors for the chart.
        Dim SystemSelectedColors As New List(Of String)
        With SystemSelectedColors
            Dim Index As Integer = 0

            'Picks four colors for each metric function.
            Do Until .Count = Me.CarMFGs.Count
                Dim JSColors As New ChartJSColors()
                Dim SystemSelectedColor As String = HexaDecimalConv(JSColors.SelectedColor)

                If .Contains(SystemSelectedColor) = False Then
                    .Add(SystemSelectedColor)
                End If
            Loop
        End With

        'Group of datasets. Should be a total of two.
        Dim JSDataSets As New ChartJSDatasets() With {.ChartJSDatasetsLabels = XAxisLabels}
        With JSDataSets
            .MainChartTitle = ""

            For i = 0 To Me.CarSalesData.Count - 1

                'Chart JS Dataset. For this code each data set represents the metric.
                Dim JSDataSet As New ChartJSDataset()
                With JSDataSet
                    Dim JSDataSetName As String = CarSalesData(i).MFGName
                    Dim JSSelectedBarColor As String = SystemSelectedColors(i) 'Gets the system selected color.

                    Dim Values As List(Of String) = CarSalesData(i).YearlySalesAmtValues

                    .YValues = Values

                    .ChartJSTooltipLabel = JSDataSetName 'Label for Tooltip
                    .BackgroundColor = JSSelectedBarColor 'Selected Background Color
                    .BorderColor = JSSelectedBarColor 'Selected Border Color
                End With

                .ChartJsDatasets.Add(JSDataSet)
            Next

        End With

        'Chart JS Configuration Object.
        Dim ChartJSLeadsConfig As New ChartJSConfig() With {.ChartJSMainType = "bar", .ChartJSDatasets = JSDataSets}

        'Converts Chart JS Configuration into JSON and return a JSON String.
        Dim ChartJSONSerializer As New JsonSerializer() With {.Formatting = Formatting.Indented}
        Dim ChartJSONStringWriter As New StringWriter()

        Dim JSONWriter As New JsonTextWriter(ChartJSONStringWriter)

        ChartJSONSerializer.Serialize(JSONWriter, ChartJSLeadsConfig)
        JSONWriter.Close()

        JSONString = ChartJSONStringWriter.ToString()

        Return JSONString

    End Function

    Public Function GenerateCarSalesList(ByVal CarMFGs As List(Of String)) As List(Of CarManufacturer)
        Dim CarMFGList As New List(Of CarManufacturer)
        With CarMFGList
            For Each CarMFG In CarMFGs
                .Add(New CarManufacturer() With {.MFGName = CarMFG})
            Next

        End With
        Return CarMFGList

    End Function

    Private Sub GenerateSales()
        Dim NumRandom As New Random
        Dim ShuffledList As New List(Of String)
        With ShuffledList
            For CurrentListIndex As Integer = 1 To 12
                Dim Value As Integer = NumRandom.Next(100000, 3000000)
                .Add(Value)
            Next
        End With

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
