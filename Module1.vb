Module Module1
    Public conn As New OleDb.OleDbConnection
    Public state2 As New Label
    Public Sub constr()
        conn.ConnectionString = "provider=microsoft.jet.oledb.4.0;data source=" & Application.StartupPath & "\db mang.mdb"
    End Sub
    Public Sub lblst(ByVal x1 As Int16, ByVal y1 As Int16)
        With state2
            .Location = New Point(x1, y1)
            .AutoSize = True
        End With
    End Sub

    Public da As New OleDb.OleDbDataAdapter
    Public ds As New DataSet
    Public dc As New OleDb.OleDbCommand
    '**********************************************
    Public i As Integer
    Public tru As String = " „  «·⁄„·Ì… »‰Ã«Õ"
    Public fls As String = "ÌÃ» ⁄·Ìﬂ ≈œŒ«· «·»Ì«‰«  «·÷—Ê—Ì…"
    '*****************************************************

End Module
