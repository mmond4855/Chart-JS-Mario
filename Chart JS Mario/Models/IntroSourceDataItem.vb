﻿Public Class IntroSourceDataItem
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