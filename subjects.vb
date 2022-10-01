Public Class subjects
    Private Sub msgtrue(ByVal txt As String)
        state2.Text = txt
        lblst(17, 118)
        Me.Controls.Add(state2)
        state2.ForeColor = Color.Blue
        Timer1.Enabled = True
    End Sub
    Private Sub msgfalse(ByVal txt As String)
        state2.Text = txt
        lblst(17, 118)
        Me.Controls.Add(state2)
        state2.ForeColor = Color.Red
        Timer1.Enabled = True
    End Sub
    Private Sub cln()
        Dim tools As Control
        For Each tools In Me.GroupBox1.Controls
            If TypeOf tools Is TextBox Or TypeOf tools Is ComboBox Then
                tools.Text = Nothing
            End If
        Next
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnext.Click
        Me.Close()
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static t As Byte
        t += 1
        If t >= 4 Then
            Me.Controls.Remove(state2)
            Timer1.Enabled = False
            t = 0
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndlt.Click
        constr()
        ds.Clear()
        If Me.nosub.Text <> Nothing And Me.syo.Text <> Nothing Then
            Dim nosy As String = Trim(Me.syo.Text) & Trim(Me.nosub.Text)
            da = New OleDb.OleDbDataAdapter("select * from subject where sub_no_sy='" & nosy & "'", conn)
            da.Fill(ds, "fnd")
            If ds.Tables("fnd").Rows.Count > 0 Then
                If MsgBox("Â· √‰  „ √ﬂœ „‰ ⁄„·Ì… «·Õ–›", MsgBoxStyle.YesNo, " ‰»ÌÂ") = MsgBoxResult.Yes Then
                    Dim dlt As New OleDb.OleDbCommand
                    dlt.Connection = conn
                    dlt.CommandType = CommandType.Text
                    dlt.CommandText = "delete from subject where sub_no_sy='" & nosy & "'"
                    conn.Open()
                    dlt.ExecuteNonQuery()
                    conn.Close()
                    msgtrue(tru)
                End If
            Else
                msgfalse("·«  ÊÃœ „«œ… »Â–« «·—ﬁ„ Ê«·—„“")
            End If
        Else
            msgfalse("√œŒ· —ﬁ„ Ê—„“ «·„«œ… «·„—«œ Õ–›Â«")
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncln.Click
        Dim tools As Control
        For Each tools In Me.GroupBox1.Controls
            If TypeOf tools Is TextBox Or TypeOf tools Is ComboBox Then
                tools.Text = Nothing
            End If
        Next
    End Sub

    Private Sub btnsav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsav.Click
        constr()
        If Me.nosub.Text <> Nothing And Me.syo.Text <> Nothing And Me.hor.Text <> Nothing And Me.numar.Text <> Nothing And Me.dept.Text <> Nothing And Me.horbng.Text <> Nothing Then
            Dim nosy As String = Trim(Me.syo.Text) & Trim(Me.nosub.Text)
            da = New OleDb.OleDbDataAdapter("select * from subject where sub_no_sy='" & nosy & "'", conn)
            da.Fill(ds, "srch")
            If Not ds.Tables("srch").Rows.Count > 0 Then
                Dim sav As New OleDb.OleDbCommand
                sav.Connection = conn
                sav.CommandType = CommandType.Text
                sav.CommandText = "insert into subject values('" & nosy & "','" & Trim(Me.numar.Text) & "','" & Trim(Me.numen.Text) & "','" & Trim(Me.dept.Text) & "'," & Val(Me.hor.Text) & "," & Val(Me.horbng.Text) & ")"
                conn.Open()
                sav.ExecuteNonQuery()
                conn.Close()
                msgtrue(tru)
            Else
                msgfalse("«·„«œ… „Õ›ÊŸ… „”»ﬁ«")
            End If
        Else
            msgfalse(fls)
        End If
    End Sub

    Private Sub btnedt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedt.Click
        constr()
        If Me.btnedt.Text = " ⁄œÌ·" Then
            ds.Clear()
            If Me.nosub.Text <> Nothing And Me.syo.Text <> Nothing Then
                Dim nosy As String = Trim(Me.syo.Text) & Trim(Me.nosub.Text)
                da = New OleDb.OleDbDataAdapter("select * from subject where sub_no_sy='" & nosy & "'", conn)
                da.Fill(ds, "show")
                If ds.Tables("show").Rows.Count > 0 Then
                    Me.nosub.Text = Mid(ds.Tables("show").Rows(0).Item(0), 4, 5)
                    Me.syo.Text = Mid(ds.Tables("show").Rows(0).Item(0), 1, 3)
                    Me.numar.Text = ds.Tables("show").Rows(0).Item(1)
                    Me.numen.Text = ds.Tables("show").Rows(0).Item(2)
                    Me.dept.Text = ds.Tables("show").Rows(0).Item(3)
                    Me.hor.Text = ds.Tables("show").Rows(0).Item(4)
                    Me.horbng.Text = ds.Tables("show").Rows(0).Item(5)
                    Me.btnedt.Text = "Õ›Ÿ «· ⁄œÌ·"
                    Me.nosub.ReadOnly = True
                    Me.syo.ReadOnly = True
                Else
                    msgfalse("·« ÊÃœ „«œ… »Â–« «·—ﬁ„ Ê«·—„“")
                End If
            Else
                msgfalse(fls)
            End If
        Else
            If Me.nosub.Text <> Nothing And Me.syo.Text <> Nothing And Me.hor.Text <> Nothing And Me.numar.Text <> Nothing And Me.dept.Text <> Nothing And Me.horbng.Text <> Nothing Then
                Dim nosy As String = Trim(Me.syo.Text) & Trim(Me.nosub.Text)
                Dim edt1 As New OleDb.OleDbCommand
                edt1.Connection = conn
                edt1.CommandType = CommandType.Text
                edt1.CommandText = "update subject set sub_name1='" & Trim(Me.numar.Text) & "',sub_name2='" & Trim(Me.numen.Text) & "',sub_dept='" & Trim(Me.dept.Text) & "',sub_hor_rly=" & Val(Me.hor.Text) & ",sub_hor_bng=" & Val(Me.horbng.Text) & " where sub_no_sy='" & nosy & "'"
                conn.Open()
                edt1.ExecuteNonQuery()
                conn.Close()
                msgtrue(tru)
                Me.btnedt.Text = " ⁄œÌ·"
                Me.nosub.ReadOnly = False
                Me.syo.ReadOnly = False
            Else
                msgfalse(fls)
            End If
        End If
    End Sub

    Private Sub dept_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dept.GotFocus
        constr()
        ds.Clear()
        Me.dept.Items.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct dept_name from department", conn)
        da.Fill(ds, "dept")
        For i = 0 To ds.Tables("dept").Rows.Count - 1
            Me.dept.Items.Add(ds.Tables("dept").Rows(i).Item(0))
        Next
    End Sub

    Private Sub dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept.SelectedIndexChanged

    End Sub
End Class