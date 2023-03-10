Imports System.Drawing

Public Class IntroSourceDataItem
    Public Property IntroCode As String
    Public Property Status As String
    Public Property IntroSourceCount As Integer

    Public Sub New()

    End Sub
End Class

Public Class QuoteItem
    Public Property QuoteMonth As String
    Public Property QuotedDollars As String = "0"
    Public Property QuoteAmount As Integer = 0

    Public Sub New()

    End Sub
End Class

Public Class CarManufacturer
    Public Property MFGName As String
    Public Property YearlySalesAmtValues As New List(Of String)
    Public Property YearlySoldValues As New List(Of String)

    Public Sub New()
        GenerateCarMFGData()
    End Sub

    Private Sub GenerateCarMFGData()
        Dim NumberRandomGenerator As New Random
        Dim ShuffledList As New List(Of String)
        With ShuffledList
            For CurrentListIndex As Integer = 1 To 12
                Dim Value As Integer = NumberRandomGenerator.Next(100000, 3000001)
                .Add(Value)
            Next
        End With

        Me.YearlySalesAmtValues = ShuffledList

        NumberRandomGenerator = New Random
        ShuffledList = New List(Of String)

        With ShuffledList
            For CurrentListIndex As Integer = 1 To 12
                Dim Value As Integer = NumberRandomGenerator.Next(0, 100001)
                .Add(Value)

            Next
        End With

        Me.YearlySoldValues = ShuffledList
    End Sub

End Class