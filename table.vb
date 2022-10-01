Public Class table
    Dim state6 As New Label

    Public Sub lblst(ByVal x1 As Int16, ByVal y1 As Int16)
        With state6
            .Location = New Point(x1, y1)
            .AutoSize = True
            .BackColor = Color.Transparent
        End With
    End Sub
    Private Sub msgtrue(ByVal txt As String)
        state6.Text = txt
        lblst(354, 106)
        Me.Controls.Add(state6)
        state6.ForeColor = Color.Blue
        Timer1.Enabled = True
    End Sub
    Private Sub msgfalse(ByVal txt As String)
        state6.Text = txt
        lblst(354, 106)
        Me.Controls.Add(state6)
        state6.ForeColor = Color.Red
        Timer1.Enabled = True
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ext.Click
        Me.Close()
    End Sub

    Private Sub btngo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngo.Click
        Try

        
            constr()
            ds.Clear()
            dgv.Refresh() : dgv.DataMember = ""
            If Me.nostud.Text <> Nothing And Me.nostud.Text <> "ÑÞã ÇáØÇáÈ" Then
                Dim no As Integer = Val(Me.nostud.Text)
                Dim horsub As Integer = 0
                da = New OleDb.OleDbDataAdapter("select stud_name,stud_dept from student where stud_no=" & no & "", conn)
                da.Fill(ds, "info")
                da = New OleDb.OleDbDataAdapter("select sum(rec_sub_hour) from recordmarks where rec_no=" & no & "", conn) : da.Fill(ds, "allhor")

                If ds.Tables("info").Rows.Count > 0 Then
                    Me.lblnam.Text = ds.Tables("info").Rows(0).Item(0) : Me.lblnam.ForeColor = Color.Blue
                    Me.dept.Text = ds.Tables("info").Rows(0).Item(1) : Me.dept.ForeColor = Color.Blue
                Else
                    msgfalse("áÇíæÌÏ ØÇáÈ ÈåÐÇ ÇáÑÞã")
                End If
                If Not IsDBNull(ds.Tables("allhor").Rows(0).Item(0)) Then Me.allhor.Text = ds.Tables("allhor").Rows(0).Item(0) : Me.allhor.ForeColor = Color.Blue
                da = New OleDb.OleDbDataAdapter("select sub_no_sy from join_stud_sub_div where stud_no=" & no & "", conn)
                da.Fill(ds, "nosy")
                For i = 0 To ds.Tables("nosy").Rows.Count - 1
                    da = New OleDb.OleDbDataAdapter("select sub_hor_rly from subject where sub_no_sy='" & ds.Tables("nosy").Rows(i).Item(0) & "'", conn)
                    da.Fill(ds, "num")
                    horsub += ds.Tables("num").Rows(i).Item(0)
                Next
                Me.hortrm.Text = horsub : Me.hortrm.ForeColor = Color.Blue
                '**********************************************************************************
                Dim sqltbl1, arr() As String
                sqltbl1 = "select * from join_stud_sub_div where stud_no=" & no & ""
                da = New OleDb.OleDbDataAdapter(sqltbl1, conn)
                da.Fill(ds, "tb1")
                ReDim arr(ds.Tables("tb1").Rows.Count)
                For k As Integer = 0 To ds.Tables("tb1").Rows.Count - 1
                    da = New OleDb.OleDbDataAdapter("select sub_name1 from subject where sub_no_sy='" & ds.Tables("tb1").Rows(k).Item(1) & "'", conn)
                    da.Fill(ds, "nam")
                    arr(k) = ds.Tables("nam").Rows(k).Item(0)
                Next
                For j As Integer = 0 To ds.Tables("tb1").Rows.Count - 1
                    da = New OleDb.OleDbDataAdapter("select subject.sub_no_sy as 'ÑÞã æÑãÒ ÇáãÇÏÉ',division.div_no as 'ÑÞã ÇáÔÚÈÉ',subject.sub_name1 as 'ÇÓã ÇáãÇÏÉ',division.div_day1 as 'Çáíæã ÇáÃæá',division.div_day1_frm as 'ãä1',division.div_day1_to as 'Åáì1',division.div_day2 as 'Çáíæã ÇáËÇäí',division.div_day2_frm as 'ãä2',division.div_day2_to as 'Åáì2',division.rom_no as 'ÑÞã ÇáÞÇÚÉ',division.rom_bld as 'ÑÞã ÇáãÈäì' from division,subject where division.div_no=" & ds.Tables("tb1").Rows(j).Item(2) & " and division.div_sub='" & arr(j) & "' and subject.sub_no_sy='" & ds.Tables("tb1").Rows(j).Item(1) & "'", conn)
                    da.Fill(ds, "table1")
                Next
                dgv.DataSource = ds
                dgv.DataMember = "table1"
                dgv.Columns(0).Width = 90 : dgv.Columns(1).Width = 50 : dgv.Columns(2).Width = 110 : dgv.Columns(3).Width = 50 : dgv.Columns(4).Width = 50 : dgv.Columns(5).Width = 50 : dgv.Columns(6).Width = 50 : dgv.Columns(7).Width = 50 : dgv.Columns(8).Width = 50 : dgv.Columns(9).Width = 50 : dgv.Columns(10).Width = 50
                '***********************************************************
            Else
                msgfalse("ÃÏÎá ÑÞã ÇáØÇáÈ")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub nostud_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nostud.GotFocus
        If Me.nostud.Text = "ÑÞã ÇáØÇáÈ" Then
            Me.nostud.Text = ""
        End If
    End Sub

    Private Sub nostud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nostud.KeyPress
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            msgfalse("áÇíãßä ßÊÇÈÉ ÍÑÝ Ãæ ÑãÒ Ýí åÐÇ ÇáÍÞá")
        End If
    End Sub

    Private Sub nostud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nostud.LostFocus
        If Me.nostud.Text = Nothing Then
            Me.nostud.Text = "ÑÞã ÇáØÇáÈ"
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub nostud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nostud.TextChanged

    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static t As Byte
        t += 1
        If t >= 4 Then
            Me.Controls.Remove(state6)
            Timer1.Enabled = False
            t = 0
        End If
    End Sub

    Private Sub table_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class