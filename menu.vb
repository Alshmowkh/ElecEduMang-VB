Public Class home
    Dim txt As New TextBox
    Dim lbl As New Label
    Dim cmb As New ComboBox
    Dim cmb2 As New ComboBox
    Dim cmb1 As New ComboBox
    Dim dn As New DataGridView
    Private Sub jlp(ByVal a As String, ByVal b As String, ByVal c As String, ByVal d As Integer, ByVal e As Integer, ByVal f As Integer)
        constr()
        ds.Clear()
        dgv1.DataMember = ""
        Dim sqlst As String
        If c = "" Then
            sqlst = "select * from " & a & " where " & b & "=" & d & " "
        Else
            sqlst = "select * from " & a & " where " & b & "=' & c & '"

        End If
        da = New OleDb.OleDbDataAdapter(sqlst, conn)
        da.Fill(ds, "data")
        dgv1.DataSource = ds : dgv1.DataMember = "data" : dgv1.Refresh() : dgv1.Visible = True
        sh(True)
        a = "" : b = "" : c = "" : d = 0 : e = 0 : f = 0
    End Sub
    Private Sub dg(ByVal dss As String)
        dgv1.DataMember = ""
        dgv1.DataSource = ds : dgv1.DataMember = dss : dgv1.Refresh() : dgv1.Visible = True
        sh(True)
    End Sub
    Private Sub sh(ByVal st As Boolean)
        If st = False Then
            Me.rfrsh.Visible = False : Me.prnt.Visible = False
        Else
            Me.rfrsh.Visible = True : Me.prnt.Visible = True
        End If
    End Sub
    Private Sub vsbl()
        Me.panel1.Visible = False
        Me.Panel2.Visible = False
        Me.Panel3.Visible = False
        Me.Panel4.Visible = False
        Me.Panel5.Visible = False
        Me.Panel6.Visible = False
        Me.Panel7.Visible = False
        Me.dgv1.Visible = False
    End Sub
    Private Sub home_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim close_form As DialogResult
        'close_form = MsgBox("Â·  —Ìœ «·Œ—ÊÃ", MessageBoxButtons.YesNo + MessageBoxIcon.Question, "«·Œ—ÊÃ")
        'If close_form = Windows.Forms.DialogResult.Yes Then
        '    MsgBox("‘ﬂ—« „⁄  ÕÌ«  √‰” „Õ„Êœ", MsgBoxStyle.Information)
        '    Dim iCount As Integer
        '    For iCount = 90 To 10 Step -3
        '        Me.Opacity = iCount / 100
        '        Me.Refresh()
        '        Threading.Thread.Sleep(50)
        '    Next
        'Else
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub Œ—ÊÃToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Œ—ÊÃToolStripMenuItem.Click
        room.Show()
    End Sub

    Private Sub «·„Ê«œToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·„Ê«œToolStripMenuItem.Click
        subjects.Show()
    End Sub

    Private Sub «·‘⁄»ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·‘⁄»ToolStripMenuItem.Click
        division.Show()
    End Sub

    Private Sub › Õﬁ”„ÃœÌœToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles › Õﬁ”„ÃœÌœToolStripMenuItem.Click
        department.Show()
    End Sub

    Private Sub  ”ÃÌ·«·ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles  ”ÃÌ·«·ToolStripMenuItem.Click
        recordsubject.Show()
    End Sub

    Private Sub ≈œŒ«·œ—Ã« ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ≈œŒ«·œ—Ã« ToolStripMenuItem.Click
        recordmarks.Show()
    End Sub

    Private Sub  ÕœÌÀ« ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles  ÕœÌÀ« ToolStripMenuItem.Click
        Me.Panel7.Visible = True
    End Sub

    Private Sub ÿ»«⁄…ÃœÊ·ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÿ»«⁄…ÃœÊ·ToolStripMenuItem.Click
        table.Show()
    End Sub

    Private Sub ÿ»«⁄…”Ã·ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÿ»«⁄…”Ã·ToolStripMenuItem.Click
        vsbl()
        Me.panel1.Visible = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ext.Click
        vsbl() : sh(False)
    End Sub

    Private Sub Œ—ÊÃToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Œ—ÊÃToolStripMenuItem1.Click
        End
    End Sub

    Private Sub Ì»»»»»»ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ì»»»»»»ToolStripMenuItem.Click
        student.Show()
    End Sub

    Private Sub ÿ·«»«·ﬁ”„ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÿ·«»«·ﬁ”„ToolStripMenuItem.Click
        vsbl()
        Me.Panel5.Visible = True
    End Sub

    Private Sub „⁄·Ê„« ‘⁄»…ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.panel1.Visible = True
    End Sub

    Private Sub ﬂ‘›»ÿ·«»‘⁄»…ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.panel1.Visible = True
    End Sub

    Private Sub ﬂ‘›‘⁄»…ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ﬂ‘›‘⁄»…ToolStripMenuItem.Click
        vsbl()
        Me.Panel2.Visible = True
    End Sub

    Private Sub ÿ»«⁄…„Ê«œ«·ﬁ”„ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.panel1.Visible = True
    End Sub

    Private Sub ﬂ‘›«·„Ê«œ«·⁄«„…ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ﬂ‘›«·„Ê«œ«·⁄«„…ToolStripMenuItem.Click
        constr()
        vsbl()
        da = New OleDb.OleDbDataAdapter("select * from subject where sub_dept='⁄«„'", conn)
        da.Fill(ds, "general")
        dg("general")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ﬂ‘›«·ﬁ«⁄« ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ﬂ‘›«·ﬁ«⁄« ToolStripMenuItem.Click
        vsbl()
        constr()
        Try
            ds.Clear()
            da = New OleDb.OleDbDataAdapter("select * from rooms ", conn)
            da.Fill(ds, "gsub")
            dgv1.Visible = True
            dgv1.DataSource = ds
            dgv1.DataMember = "gsub"
            dgv1.Visible = True
            sh(True)
        Catch ex As Exception
            MsgBox("ÕœÀ… „‘ﬂ·… √À‰«¡ Ã·» «·»Ì«‰« ")
        End Try
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        constr()

    End Sub

    Private Sub rfrsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rfrsh.Click
        dgv1.Refresh()
    End Sub

    Private Sub „Ê«œ«·ﬁ”„ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.panel1.Visible = True
    End Sub

    Private Sub home_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            table.Show()
        ElseIf e.KeyCode = Keys.F2 Then
            recordmarks.Show()
        ElseIf e.KeyCode = Keys.F3 Then
            division.Show()
        End If
    End Sub


    Private Sub ≈÷«›…„” Œœ„ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ≈÷«›…„” Œœ„ToolStripMenuItem.Click
        users.Show()
    End Sub

    Private Sub  ⁄œÌ·„” Œœ„ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles  ⁄œÌ·„” Œœ„ToolStripMenuItem.Click
        users.Show()
    End Sub

    Private Sub Õ–›„” Œœ„ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Õ–›„” Œœ„ToolStripMenuItem.Click
        users.Show()
    End Sub

    Private Sub «·”Ã·«·√ﬂ«œÌ„ÌToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·”Ã·«·√ﬂ«œÌ„ÌToolStripMenuItem1.Click
        vsbl()
        Me.Panel3.Visible = True

    End Sub

    Private Sub ‘⁄»„«œ…ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ‘⁄»„«œ…ToolStripMenuItem.Click
        vsbl()
        Me.Panel4.Visible = True
    End Sub

    Private Sub «·Œÿ…«·œ—«”Ì…··ﬁ”„ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·Œÿ…«·œ—«”Ì…··ﬁ”„ToolStripMenuItem.Click
        vsbl()
        Me.Panel6.Visible = True
    End Sub


    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MsgBox("·«Ì„ﬂ‰ ﬂ «»… Õ—› √Ê —„“ ›Ì Â–« «·Õﬁ·")
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 9 Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
            MsgBox("·«Ì„ﬂ‰ ﬂ «»… Õ—› √Ê —„“ ›Ì Â–« «·Õﬁ·")
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        vsbl() : sh(False)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        vsbl() : sh(False)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        vsbl() : sh(False)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        vsbl() : sh(False)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        vsbl() : sh(False)
    End Sub

    Private Sub excu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles excu.Click
        If Not Me.TextBox1.Text = "" Then
            jlp("student", "stud_no", "", Me.TextBox1.Text, 1, 1)
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        constr()
        If Not Me.ComboBox7.Text = Nothing And Not Me.ComboBox7.Text = "--«·ﬁ”„--" Then
            da = New OleDb.OleDbDataAdapter("select * from subject where sub_dept='" & Me.ComboBox7.Text & "' or sub_dept='⁄«„'", conn)
            da.Fill(ds, "khta")
            dg("khta")
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        constr()
        ds.Clear() : Me.dgv1.DataMember = ""
        If Not Me.ComboBox6.Text = Nothing And Not Me.ComboBox6.Text = "--«·ﬁ”„--" Then
            da = New OleDb.OleDbDataAdapter("select * from student where stud_dept='" & Me.ComboBox6.Text & "'", conn)
            da.Fill(ds, "dept")
            dg("dept")
        End If
    End Sub

    Private Sub ComboBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.GotFocus
        constr()
        Me.ComboBox3.Items.Clear()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct dept_name from department", conn)
        da.Fill(ds, "nam")
        If ds.Tables("nam").Rows.Count > 0 Then
            For i = 0 To ds.Tables("nam").Rows.Count - 1
                Me.ComboBox3.Items.Add(ds.Tables("nam").Rows(i).Item(0))
            Next
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        constr()
        Me.ComboBox2.Items.Clear()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct sub_name1 from subject where sub_dept='" & Me.ComboBox3.Text & "' or sub_dept='⁄«„'", conn)
        da.Fill(ds, "nam1")
        If ds.Tables("nam1").Rows.Count > 0 Then
            For i = 0 To ds.Tables("nam1").Rows.Count - 1
                Me.ComboBox2.Items.Add(ds.Tables("nam1").Rows(i).Item(0))
            Next
        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        constr()
        Me.ComboBox1.Items.Clear()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct div_no from division where div_sub='" & Me.ComboBox2.Text & "'", conn)
        da.Fill(ds, "nam2")
        If ds.Tables("nam2").Rows.Count > 0 Then
            For i = 0 To ds.Tables("nam2").Rows.Count - 1
                Me.ComboBox1.Items.Add(ds.Tables("nam2").Rows(i).Item(0))
            Next
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        constr()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select student.stud_no,student.stud_name from (student inner join join_stud_sub_div on student.stud_no=join_stud_sub_div.stud_no) inner join division on (division.div_no=join_stud_sub_div.div_no and division.div_sub=join_stud_sub_div.div_sub) where join_stud_sub_div.div_no=" & Me.ComboBox1.Text & " and join_stud_sub_div.div_sub='" & Me.ComboBox2.Text & "'", conn)
        da.Fill(ds, "nam3")
        dg("nam3")
    End Sub

    Private Sub ComboBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.GotFocus
        constr()
        Me.ComboBox4.Items.Clear()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct dept_name from department", conn)
        da.Fill(ds, "nam7")
        If ds.Tables("nam7").Rows.Count > 0 Then
            For i = 0 To ds.Tables("nam7").Rows.Count - 1
                Me.ComboBox4.Items.Add(ds.Tables("nam7").Rows(i).Item(0))
            Next
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        constr()
        Me.ComboBox5.Items.Clear()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct sub_name1 from subject where sub_dept='" & Me.ComboBox4.Text & "' or sub_dept='⁄«„'", conn)
        da.Fill(ds, "nam5")
        If ds.Tables("nam5").Rows.Count > 0 Then
            For i = 0 To ds.Tables("nam5").Rows.Count - 1
                Me.ComboBox5.Items.Add(ds.Tables("nam5").Rows(i).Item(0))
            Next
        End If

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        constr()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select * from division where div_sub='" & Me.ComboBox5.Text & "'", conn)
        da.Fill(ds, "nam6")
        dg("nam6")
    End Sub

    Private Sub ComboBox6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox6.GotFocus
        constr()
        ds.Clear() : dgv1.DataMember = "" : Me.ComboBox6.Items.Clear()
        da = New OleDb.OleDbDataAdapter("select dept_name from department", conn)
        da.Fill(ds, "dpt1")
        If ds.Tables("dpt1").Rows.Count > 0 Then
            For i = 0 To ds.Tables("dpt1").Rows.Count - 1
                Me.ComboBox6.Items.Add(ds.Tables("dpt1").Rows(i).Item(0))
            Next
        End If
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged

    End Sub

    Private Sub ComboBox7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox7.GotFocus
        constr()
        ds.Clear() : dgv1.DataMember = "" : Me.ComboBox7.Items.Clear()
        da = New OleDb.OleDbDataAdapter("select dept_name from department", conn)
        da.Fill(ds, "dpt")
        If ds.Tables("dpt").Rows.Count > 0 Then
            For i = 0 To ds.Tables("dpt").Rows.Count - 1
                Me.ComboBox7.Items.Add(ds.Tables("dpt").Rows(i).Item(0))
            Next
        End If
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Not Me.TextBox2.Text = "" Then
            jlp("recordmarks", "rec_no", "", Me.TextBox2.Text, 1, 1)
        End If
    End Sub

    Private Sub ComboBox8_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox8.GotFocus
        constr()
        Me.ComboBox8.Items.Clear()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct dept_name from department", conn)
        da.Fill(ds, "nam0")
        If ds.Tables("nam0").Rows.Count > 0 Then
            For i = 0 To ds.Tables("nam0").Rows.Count - 1
                Me.ComboBox8.Items.Add(ds.Tables("nam0").Rows(i).Item(0))
            Next
        End If
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        constr()
        Me.ComboBox9.Items.Clear()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct sub_name1 from subject where sub_dept='" & Me.ComboBox8.Text & "' or sub_dept='⁄«„'", conn)
        da.Fill(ds, "nam10")
        If ds.Tables("nam10").Rows.Count > 0 Then
            For i = 0 To ds.Tables("nam10").Rows.Count - 1
                Me.ComboBox9.Items.Add(ds.Tables("nam10").Rows(i).Item(0))
            Next
        End If

    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.SelectedIndexChanged
        constr()
        Me.ComboBox10.Items.Clear()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct div_no from division where div_sub='" & Me.ComboBox9.Text & "'", conn)
        da.Fill(ds, "nam20")
        If ds.Tables("nam20").Rows.Count > 0 Then
            For i = 0 To ds.Tables("nam20").Rows.Count - 1
                Me.ComboBox10.Items.Add(ds.Tables("nam20").Rows(i).Item(0))
            Next
        End If
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.SelectedIndexChanged
        constr()
        ds.Clear()

        da = New OleDb.OleDbDataAdapter("select student.stud_no as '—ﬁ„ «·ÿ«·»',student.stud_name as '«”„ «·ÿ«·»' from (student inner join join_stud_sub_div on student.stud_no=join_stud_sub_div.stud_no) inner join division on (division.div_no=join_stud_sub_div.div_no and division.div_sub=join_stud_sub_div.div_sub) where join_stud_sub_div.div_no=" & Me.ComboBox10.Text & " and join_stud_sub_div.div_sub='" & Me.ComboBox9.Text & "'", conn)
        da.Fill(ds, "mrk")
        dgv1.DataSource = ds
        dgv1.DataMember = "mrk"
        dgv1.Visible = True
        dgv1.Refresh() : prnt.Visible = True : rfrsh.Visible = True
        '****************************************************************
        If Me.dgv1.Columns.Count < 3 Then
            dgv1.Columns.Add(2, "«·œ—Ã…")
        End If


        dgv1.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal
        dgv1.BackgroundColor = Color.Silver
        dgv1.Columns(2).DefaultCellStyle.BackColor = Color.White


    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        vsbl() : sh(False)
    End Sub

    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick

    End Sub

    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        e.CellStyle.BackColor = Color.Brown
        e.CellStyle.SelectionBackColor = Color.WhiteSmoke
        e.CellStyle.SelectionForeColor = Color.Brown
        e.CellStyle.ForeColor = Color.WhiteSmoke
        'e.CellStyle.Font.Style.Bold()
        'e.CellStyle.Font.Size = 16em : e.CellStyle.Font.Bold = True
    End Sub

    Private Sub entermarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles entermarks.Click
        'constr()
        'ds.Clear()
        '' If Me.nostud.Text <> Nothing And Me.cmbsub.Text <> Nothing And Me.marks.Text <> Nothing Then
        'da = New OleDb.OleDbDataAdapter("select sub_no_sy,sub_name2,sub_hor_rly from subject where sub_name1='" & Me.ComboBox9.Text & "'", conn)
        'da.Fill(ds, "subinfo")
        ''MsgBox(ds.Tables("subinfo").Rows(0).Item(0).ToString)
        'Dim sav As New OleDb.OleDbCommand
        'Dim dltj As New OleDb.OleDbCommand
        'sav.Connection = conn
        'sav.CommandType = CommandType.Text
        'sav.CommandText = "insert into recordmarks (rec_no,rec_sub_nosy,rec_sub_name1,rec_sub_name2,rec_sub_hour,rec_term,rec_mark,rec_grad) values(" & Me.nostud.Text & ",'" & ds.Tables("subinfo").Rows(0).Item(0) & "','" & Me.cmbsub.Text & "','" & ds.Tables("subinfo").Rows(0).Item(1) & "'," & Val(ds.Tables("subinfo").Rows(0).Item(2)) & ",'«·›’·'," & Val(Me.marks.Text) & ",'" & Me.grade.Text & "') "
        'dltj.Connection = conn
        'dltj.CommandType = CommandType.Text
        'dltj.CommandText = "delete from join_stud_sub_div where stud_no=" & Me.nostud.Text & " and sub_no_sy='" & ds.Tables("subinfo").Rows(0).Item(0) & "'"
        'conn.Open()
        'sav.ExecuteNonQuery()
        'dltj.ExecuteNonQuery()
        'conn.Close()
        ''  msgtrue(tru)
        '' Me.cmbsub.Items.Remove(Me.cmbsub.Text)
        ''  Else
        ''  msgfalse(fls)
        '' End If

    End Sub

    Private Sub home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
