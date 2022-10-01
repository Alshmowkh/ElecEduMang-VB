Public Class department
    Private Sub msgtrue(ByVal txt As String)
        state2.Text = txt
        lblst(43, 148)
        Me.Controls.Add(state2)
        state2.ForeColor = Color.Blue
        Timer1.Enabled = True
    End Sub
    Private Sub msgfalse(ByVal txt As String)
        state2.Text = txt
        lblst(43, 148)
        Me.Controls.Add(state2)
        state2.ForeColor = Color.Red
        Timer1.Enabled = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnext.Click
        Me.Close()
    End Sub

    Private Sub btncln_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncln.Click
        Dim tools As Control
        For Each tools In Me.GroupBox1.Controls
            If TypeOf tools Is TextBox Or TypeOf tools Is ComboBox Then
                tools.Text = Nothing
            End If
        Next
    End Sub

    Private Sub btnsav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsav.Click
        constr()
        ds.Clear()
        If Me.nodept.Text <> Nothing And Me.namdept.Text <> Nothing Then
            da = New OleDb.OleDbDataAdapter("select * from department where dept_no=" & Me.nodept.Text & " or dept_name='" & Trim(Me.namdept.Text) & "'", conn)
            da.Fill(ds, "srch")
            If Not ds.Tables("srch").Rows.Count > 0 Then
                Dim sav As New OleDb.OleDbCommand
                sav.Connection = conn
                sav.CommandType = CommandType.Text
                sav.CommandText = "insert into department values(" & Val(Me.nodept.Text) & ",'" & Trim(Me.namdept.Text) & "','" & Me.datdept.Value & "')"
                conn.Open()
                sav.ExecuteNonQuery()
                conn.Close()
                msgtrue(tru)
            Else
                msgfalse("—ﬁ„ «·ﬁ”„ √Ê √”„Â „ÊÃÊœ")
            End If
        Else
            msgfalse(fls)
        End If
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

    Private Sub btnedt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedt.Click
        constr()
        If Me.btnedt.Text = " ⁄œÌ·" Then
            If Me.nodept.Text <> Nothing And Me.namdept.Text <> Nothing Then
                da = New OleDb.OleDbDataAdapter("select * from department where dept_no=" & Me.nodept.Text & " and dept_name='" & Trim(Me.namdept.Text) & "'", conn)
                da.Fill(ds, "fnd")
                If ds.Tables("fnd").Rows.Count > 0 Then
                    Me.namdept.Text = ds.Tables("fnd").Rows(0).Item(1)
                    Me.datdept.Value = ds.Tables("fnd").Rows(0).Item(2)
                    Me.btnedt.Text = "Õ›Ÿ «· ⁄œÌ·"
                    Me.nodept.ReadOnly = True
                Else
                    msgfalse("·«ÌÊÃœ ﬁ”„ »Â–« «·—ﬁ„")
                End If
            Else
                msgfalse(fls)
            End If
        Else
            Dim edt As New OleDb.OleDbCommand
            edt.Connection = conn
            edt.CommandType = CommandType.Text
            edt.CommandText = "update department set dept_name='" & Me.namdept.Text & "',dept_date='" & Me.datdept.Value & "' where dept_no=" & Me.nodept.Text & ""
            conn.Open()
            edt.ExecuteNonQuery()
            conn.Close()
            msgtrue(tru)
            Me.btnedt.Text = " ⁄œÌ·"
            Me.nodept.ReadOnly = False
        End If
    End Sub

    Private Sub btndlt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndlt.Click
        constr()
        If Me.nodept.Text <> Nothing And Me.namdept.Text <> Nothing Then
            da = New OleDb.OleDbDataAdapter("select * from department where dept_no=" & Me.nodept.Text & "", conn)
            da.Fill(ds, "srch")
            If ds.Tables("srch").Rows.Count > 0 Then
                If MsgBox("Â· √‰  „ √ﬂœ „‰ ⁄„·Ì… «·Õ–›", MsgBoxStyle.YesNo, " ‰»Ì…") = MsgBoxResult.Yes Then
                    Dim dlt As New OleDb.OleDbCommand
                    dlt.Connection = conn
                    dlt.CommandType = CommandType.Text
                    dlt.CommandText = "delete from department where dept_no=" & Me.nodept.Text & ""
                    conn.Open()
                    dlt.ExecuteNonQuery()
                    conn.Close()
                    msgtrue(tru)
                End If
            Else
                msgfalse("«·ﬁ”„ «·„—«œ Õ–›Â €Ì— „ÊÃÊœ")
            End If
        Else
            msgfalse("√œŒ· —ﬁ„ «·ﬁ”„ «·„—«œ Õ–›Â ")
        End If
    End Sub
End Class