Public Class division
    Dim state4 As New Label
    Public Sub lblst(ByVal x1 As Int16, ByVal y1 As Int16)
        With state4
            .Location = New Point(x1, y1)
            .AutoSize = True
        End With
    End Sub
    Private Sub msgtrue(ByVal txt As String)
        state4.Text = txt
        lblst(42, 89)
        Me.Controls.Add(state4)
        state4.ForeColor = Color.Blue
        Timer1.Enabled = True
    End Sub
    Private Sub msgfalse(ByVal txt As String)
        state4.Text = txt
        lblst(42, 89)
        Me.Controls.Add(state4)
        state4.ForeColor = Color.Red
        Timer1.Enabled = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dept.GotFocus
        constr()
        ds.Clear()
        Me.dept.Items.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct dept_name from department", conn)
        da.Fill(ds, "dept")
        For i = 0 To ds.Tables("dept").Rows.Count - 1
            Me.dept.Items.Add(ds.Tables("dept").Rows(i).Item(0))
        Next
        Me.dept.Text = Me.dept.Items(0)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept.SelectedIndexChanged
        constr()
        Me.subj.Items.Clear()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct sub_name1 from subject where sub_dept='" & Me.dept.Text & "' or sub_dept='⁄«„'", conn)
        da.Fill(ds, "subj")
        For i = 0 To ds.Tables("subj").Rows.Count - 1
            Me.subj.Items.Add(ds.Tables("subj").Rows(i).Item(0))
        Next
        Me.subj.Text = Me.subj.Items(0)
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles day2to.ValueChanged

    End Sub

    Private Sub btncln_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncln.Click
        Dim tools As Control
        For Each tools In Me.GroupBox1.Controls
            If TypeOf tools Is TextBox Or TypeOf tools Is ComboBox Then
                tools.Text = Nothing
            End If
        Next
    End Sub

    Private Sub place_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles place.GotFocus
        constr()
        ds.Clear()
        Me.place.Items.Clear()
        da = New OleDb.OleDbDataAdapter("select * from rooms", conn)
        da.Fill(ds, "place")
        For i = 0 To ds.Tables("place").Rows.Count - 1
            Me.place.Items.Add(ds.Tables("place").Rows(i).Item(0).ToString & ds.Tables("place").Rows(i).Item(1))
        Next
        Me.place.Text = Me.place.Items(0)
    End Sub

    Private Sub place_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles place.KeyPress
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            msgfalse("·«Ì„ﬂ‰ ﬂ «»… Õ—› √Ê —„“ ›Ì Â–« «·Õﬁ·")
        End If
    End Sub

    Private Sub place_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles place.SelectedIndexChanged

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static t As Byte
        t += 1
        If t >= 4 Then
            Me.Controls.Remove(state4)
            Timer1.Enabled = False
            t = 0
        End If
    End Sub

    Private Sub subj_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles subj.SelectedIndexChanged
        constr()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select sub_hor_rly,sub_hor_bng from subject where sub_name1='" & Me.subj.Text & "'", conn)
        da.Fill(ds, "hor")
        If ds.Tables("hor").Rows.Count > 0 Then
            Me.horrly.Text = ds.Tables("hor").Rows(0).Item(0)
            Me.horbng.Text = ds.Tables("hor").Rows(0).Item(1)
            If Int(ds.Tables("hor").Rows(0).Item(1)) > 2 Then
                Me.day2.Enabled = True : Me.day2frm.Enabled = True : Me.day2to.Enabled = True
            Else
                Me.day2.Enabled = False : Me.day2frm.Enabled = False : Me.day2to.Enabled = False
            End If
        End If
    End Sub


    Private Sub btnsav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsav.Click
        constr()
        Dim frmday1 As String = Me.day1frm.Value.Hour & ":" & Me.day1frm.Value.Minute
        Dim today1 As String = Me.day1to.Value.Hour & ":" & Me.day1to.Value.Minute
        Dim frmday2 As String = Me.day2frm.Value.Hour & ":" & Me.day2frm.Value.Minute
        Dim today2 As String = Me.day2to.Value.Hour & ":" & Me.day2to.Value.Minute
        If Me.nodiv.Text <> Nothing And Me.place.Text <> Nothing And Me.dept.Text <> Nothing And Me.subj.Text <> Nothing And Me.day1.Text <> Nothing Then
            da = New OleDb.OleDbDataAdapter("select * from division where div_no=" & Me.nodiv.Text & " and div_sub='" & Me.subj.Text & "'", conn)
            da.Fill(ds, "fndsam")
            If Not ds.Tables("fndsam").Rows.Count > 0 Then
                Dim sql As String = "select * from division where rom_no=" & Mid(Me.place.Text, 1, 3) & " and rom_bld='" & Mid(Me.place.Text, 4, 4) & "' and ( ( div_day1='" & Me.day1.Text & "' and div_day1_frm  between '" & frmday1 & "' and '" & today1 & "') or ( div_day2='" & Me.day2.Text & "' and div_day2_frm between '" & frmday2 & "' and '" & today2 & "'))"
                da = New OleDb.OleDbDataAdapter(sql, conn)
                da.Fill(ds, "fndplc")
                If Not ds.Tables("fndplc").Rows.Count > 0 Then
                    Dim sav As New OleDb.OleDbCommand
                    sav.Connection = conn
                    sav.CommandType = CommandType.Text
                    sav.CommandText = "insert into division (div_no,div_sub,div_max,div_day1,div_day2,div_day1_frm,div_day1_to,div_day2_frm,div_day2_to,rom_no,rom_bld) values(" & Val(Me.nodiv.Text) & ",'" & Me.subj.Text & "'," & Val(Me.opci.Text) & ",'" & Me.day1.Text & "','" & Me.day2.Text & "','" & frmday1 & "','" & today1 & "','" & frmday2 & "','" & today2 & "'," & Val(Mid(Me.place.Text, 1, 3)) & ",'" & Mid(Me.place.Text, 4, 4) & "')"
                    conn.Open()
                    sav.ExecuteNonQuery()
                    conn.Close()
                    msgtrue(tru)
                Else
                    msgfalse(" «·ﬁ«⁄… «·„”Ã·… „ÕÃÊ“… ›Ì Â–« «·Êﬁ  „‰ ﬁ»· ‘⁄»… √Œ—Ï")
                End If
            Else
                msgfalse("«·‘⁄»… „”Ã·… „‰ „”»ﬁ«")
            End If
        Else
            msgfalse(fls)
        End If
        ds.Clear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.day2frm.Value = Me.day1frm.Value
        Me.day2to.Value = Me.day1to.Value
    End Sub

    Private Sub btndlt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndlt.Click
        constr()
        If Me.nodiv.Text <> Nothing And Me.dept.Text <> Nothing And Me.subj.Text <> Nothing Then
            da = New OleDb.OleDbDataAdapter("select * from join_stud_sub_div where div_no=" & Me.nodiv.Text & " and div_sub='" & Me.subj.Text & "'", conn)
            da.Fill(ds, "fndstud")
            If Not ds.Tables("fndstud").Rows.Count > 0 Then
                If MsgBox("Â· √‰  „ √ﬂœ „‰ ⁄„·Ì… «·Õ–›", MsgBoxStyle.YesNo, " ‰»ÌÂ") = MsgBoxResult.Yes Then
                    Dim dlt As New OleDb.OleDbCommand
                    dlt.Connection = conn
                    dlt.CommandType = CommandType.Text
                    dlt.CommandText = "delete from division where div_no=" & Me.nodiv.Text & " and div_sub='" & Me.subj.Text & "'"
                    conn.Open()
                    dlt.ExecuteNonQuery()
                    conn.Close()
                    msgtrue(tru)
                End If
            Else
                msgfalse("·«Ì„ﬂ‰ Õ–› Â–Â «·‘⁄»… ·√‰ Â‰«ﬂ ÿ·«» „”Ã·Ì‰ ›ÌÂ«")
            End If
        Else
            msgfalse("√œŒ· —ﬁ„ «·‘⁄»… Ê «”„ «·„«œ… «·„—«œ Õ–›Â«")
        End If
    End Sub

End Class