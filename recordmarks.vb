Public Class recordmarks
    Dim state7 As New Label

    Public Sub lblst(ByVal x1 As Int16, ByVal y1 As Int16)
        With state7
            .Location = New Point(x1, y1)
            .AutoSize = True
            .BackColor = Color.Transparent
        End With
    End Sub
    Private Sub msgtrue(ByVal txt As String)
        state7.Text = txt
        lblst(38, 107)
        Me.Controls.Add(state7)
        state7.ForeColor = Color.Blue
        Timer1.Enabled = True
    End Sub
    Private Sub msgfalse(ByVal txt As String)
        state7.Text = txt
        lblst(38, 107)
        Me.Controls.Add(state7)
        state7.ForeColor = Color.Red
        Timer1.Enabled = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        constr()
        ds.Clear()
        If Me.nostud.Text <> Nothing And Me.cmbsub.Text <> Nothing And Me.marks.Text <> Nothing Then
            da = New OleDb.OleDbDataAdapter("select sub_no_sy,sub_name2,sub_hor_rly from subject where sub_name1='" & Me.cmbsub.Text & "'", conn)
            da.Fill(ds, "subinfo")
            'MsgBox(ds.Tables("subinfo").Rows(0).Item(0).ToString)
            Dim sav As New OleDb.OleDbCommand
            Dim dltj As New OleDb.OleDbCommand
            sav.Connection = conn
            sav.CommandType = CommandType.Text
            sav.CommandText = "insert into recordmarks (rec_no,rec_sub_nosy,rec_sub_name1,rec_sub_name2,rec_sub_hour,rec_term,rec_mark,rec_grad) values(" & Me.nostud.Text & ",'" & ds.Tables("subinfo").Rows(0).Item(0) & "','" & Me.cmbsub.Text & "','" & ds.Tables("subinfo").Rows(0).Item(1) & "'," & Val(ds.Tables("subinfo").Rows(0).Item(2)) & ",'«·›’·'," & Val(Me.marks.Text) & ",'" & Me.grade.Text & "') "
            dltj.Connection = conn
            dltj.CommandType = CommandType.Text
            dltj.CommandText = "delete from join_stud_sub_div where stud_no=" & Me.nostud.Text & " and sub_no_sy='" & ds.Tables("subinfo").Rows(0).Item(0) & "'"
            conn.Open()
            sav.ExecuteNonQuery()
            dltj.ExecuteNonQuery()
            conn.Close()
            msgtrue(tru)
            Me.cmbsub.Items.Remove(Me.cmbsub.Text)
        Else
            msgfalse(fls)
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static t As Byte
        t += 1
        If t >= 4 Then
            Me.Controls.Remove(state7)
            Timer1.Enabled = False
            t = 0
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
            msgfalse("·«Ì„ﬂ‰ ﬂ «»… Õ—› √Ê —„“ ›Ì Â–« «·Õﬁ·")
        End If
    End Sub

    Private Sub nostud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nostud.LostFocus
        constr()
        Me.cmbsub.Text = Nothing : Me.cmbsub.Items.Clear()
        ds.Clear()
        If Me.nostud.Text <> Nothing Then
            Dim no As Integer = Val(Me.nostud.Text)
            da = New OleDb.OleDbDataAdapter("select stud_name,stud_dept from student where stud_no=" & no & "", conn)
            da.Fill(ds, "info")
            If ds.Tables("info").Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables("info").Rows(0).Item(0)) Then Me.namstud.Text = ds.Tables("info").Rows(0).Item(0) : Me.namstud.ForeColor = Color.Blue
                If Not IsDBNull(ds.Tables("info").Rows(0).Item(1)) Then Me.dept.Text = ds.Tables("info").Rows(0).Item(1) : Me.dept.ForeColor = Color.Blue
                da = New OleDb.OleDbDataAdapter("select sub_name1 from (subject inner join join_stud_sub_div on subject.sub_no_sy=join_stud_sub_div.sub_no_sy) inner join student on student.stud_no=join_stud_sub_div.stud_no where student.stud_no=" & no & "", conn)
                da.Fill(ds, "sub")
                If ds.Tables("sub").Rows.Count > 0 Then
                    For i = 0 To ds.Tables("sub").Rows.Count - 1
                        Me.cmbsub.Items.Add(ds.Tables("sub").Rows(i).Item(0))
                    Next

                    If Not IsDBNull(ds.Tables("sub").Rows(0).Item(0)) Then Me.cmbsub.Text = ds.Tables("sub").Rows(0).Item(0)

                Else
                    msgfalse("·«ÌÊÃœ „Ê«Ãœ „Ê«œ „”Ã·… ·Â–« «·ÿ«·»")
                End If
            Else
                msgfalse("·«ÌÊÃœ ÿ«·» »Â–« «·—ﬁ„")
            End If
        Else
            msgfalse(fls)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        constr()
        ds.Clear()
        Dim cmbsubd As New ComboBox
        cmbsubd.Items.Clear()
        cmbsubd.Location = New Point(66, 133)
        cmbsubd.Text = "--√Œ — «·„«œ…--"
        If Me.nostud.Text <> Nothing Then
            If Me.Button6.Text = "Õ–›" Then
                da = New OleDb.OleDbDataAdapter("select rec_sub_name1,rec_sub_nosy from recordmarks  where rec_no=" & Me.nostud.Text & "", conn)
                da.Fill(ds, "recno")
                If ds.Tables("recno").Rows.Count > 0 Then
                    For i = 0 To ds.Tables("recno").Rows.Count - 1
                        Me.cmbsub.Items.Add(ds.Tables("recno").Rows(i).Item(0))
                    Next
                    cmbsubd.Text = ds.Tables("recno").Rows(0).Item(0)
                    ' Me.GroupBox1.Controls.Add(cmbsubd)
                    Me.Button6.Text = " √ﬂÌœ «·Õ–›"
                Else
                    msgfalse("·«ÌÊÃœ √Ì „«œ… ··ÿ«·» ›Ì ”Ã·Â «·√ﬂ«œÌ„Ì")
                End If
            Else
                If MsgBox("Â· √‰  „ √ﬂœ „‰ ⁄„·Ì… Õ–› Â–Â «·„«œ…", MsgBoxStyle.YesNo, " ‰»ÌÂ") = MsgBoxResult.Yes Then
                    If MsgBox("”Ì „ Õ–› Â–Â «·„«œ… „‰ ”Ã· «·ÿ«·» «·√ﬂ«œÌ„Ì Ê√Ì÷« „‰ ”Ã· «·„Ê«œ «·„”Ã·… ·Â–« «· —„ ··«” „—«— ›Ì ⁄„·Ì… «·Õ–› «÷€ÿ ⁄·Ï „Ê«›ﬁ √Ê ·« ·⁄œ„ «·«” „—«—", MsgBoxStyle.YesNo, " ‰»ÌÂ!") = MsgBoxResult.Yes Then
                        Dim dlt As New OleDb.OleDbCommand
                        dlt.Connection = conn
                        dlt.CommandType = CommandType.Text
                        dlt.CommandText = "delete from recordmarks where rec_no=" & Me.nostud.Text & " and rec_sub_name1='" & Trim(cmbsub.Text) & "'"
                        conn.Open()
                        dlt.ExecuteNonQuery()
                        conn.Close()
                        msgtrue(tru)
                        Me.GroupBox1.Controls.Remove(cmbsubd) : cmbsubd.Visible = False
                        Me.Button6.Text = "Õ–›"
                        If cmbsubd.Items.Count > 0 Then cmbsubd.Text = cmbsubd.Items(0)
                    Else
                        Me.GroupBox1.Controls.Remove(cmbsubd) : cmbsubd.Visible = False
                        Me.Button6.Text = "Õ–›"
                    End If
                Else
                    Me.GroupBox1.Controls.Remove(cmbsubd) : cmbsubd.Visible = False
                    Me.Button6.Text = "Õ–›"
                End If
            End If
        Else
            msgfalse(fls)
        End If
           
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        constr()
        If Me.nostud.Text <> Nothing Then
            If Me.Button2.Text = " ⁄œÌ·" Then
                da = New OleDb.OleDbDataAdapter("select rec_sub_name1,rec_mark from recordmarks where rec_no=" & Me.nostud.Text & "", conn)
                da.Fill(ds, "namstud")
                If ds.Tables("namstud").Rows.Count > 0 Then
                    For i = 0 To ds.Tables("namstud").Rows.Count - 1
                        Me.cmbsub.Items.Add(ds.Tables("namstud").Rows(i).Item(0))
                    Next
                    Me.cmbsub.Text = ds.Tables("namstud").Rows(0).Item(0)
                    Me.Button4.Enabled = False
                    Me.Button2.Text = "Õ›Ÿ «· ⁄œÌ·"
                Else
                    msgfalse("·«ÌÊÃœ ··ÿ«·» √Ì „«œ… ›Ì ”Ã·Â «·√ﬂ«œÌ„Ì")
                End If
            Else
                Dim updt As New OleDb.OleDbCommand
                updt.Connection = conn
                updt.CommandType = CommandType.Text
                updt.CommandText = "update recordmarks set rec_mark=" & Val(Me.marks.Text) & ",rec_grad='" & Me.grade.Text & "' where rec_no=" & Me.nostud.Text & " and rec_sub_name1='" & Me.cmbsub.Text & "'"
                conn.Open()
                updt.ExecuteNonQuery()
                conn.Close()
                msgtrue(tru)
                Me.Button2.Text = " ⁄œÌ·"
                Me.Button4.Enabled = True
            End If
        Else
            msgfalse("√œŒ· —ﬁ„ «·ÿ«·» «·„—«œ  ⁄œÌ· œ—Ã Â")

        End If
    End Sub
End Class