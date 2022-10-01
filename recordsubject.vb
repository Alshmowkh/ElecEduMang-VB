Public Class recordsubject

    Dim state5 As New Label
    Dim cmb As New ComboBox
    Dim lbl As New Label
    Dim max As Integer = 0 : Dim cont As Integer = 0
    Public Sub lblst(ByVal x1 As Int16, ByVal y1 As Int16)
        With state5
            .Location = New Point(x1, y1)
            .AutoSize = True
        End With
    End Sub
    Private Sub msgtrue(ByVal txt As String)
        state5.Text = txt
        lblst(30, 113)
        Me.Controls.Add(state5)
        state5.ForeColor = Color.Blue
        Timer1.Enabled = True
    End Sub
    Private Sub msgfalse(ByVal txt As String)
        state5.Text = txt
        lblst(30, 113)
        Me.Controls.Add(state5)
        state5.ForeColor = Color.Red
        Timer1.Enabled = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.Button1.Text = "Œ—ÊÃ" Then
            Me.Close()
        Else
            ds.Clear()
            Me.GroupBox1.Controls.Remove(cmb) : Me.GroupBox1.Controls.Remove(lbl)
            Me.Controls.Remove(cmb) : Me.Controls.Remove(lbl)
            Me.dlt.Text = "Õ–›"
            Me.record.Enabled = True
            Me.Button1.Text = "Œ—ÊÃ"
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
        Me.cmbsub.Items.Clear()
        ds.Clear()
        Dim no As Integer = Val(Me.nostud.Text)
        If no <> Nothing Then
            da = New OleDb.OleDbDataAdapter("select stud_name from student where stud_no=" & no & "", conn)
            da.Fill(ds, "no")
            If ds.Tables("no").Rows.Count > 0 Then
                Me.lblnam.Text = ds.Tables("no").Rows(0).Item(0)
                Me.lblnam.ForeColor = Color.Blue
                ' ****************************************************
                da = New OleDb.OleDbDataAdapter("select sum(rec_sub_hour) from recordmarks where rec_no=" & no & "", conn)
                da.Fill(ds, "tru")
                If Not IsDBNull(ds.Tables("tru").Rows(0).Item(0)) Then Me.lbltru.Text = ds.Tables("tru").Rows(0).Item(0)
                Me.lbltru.ForeColor = Color.Blue
                ' ****************************************************
                'Dim sql As String = "select talented.name_tld,talent.name_tlt from (talented inner join join_tld_tlt on  talented.id_tld=join_tld_tlt.id_tld)  inner join talent  on talent.no_tlt=join_tld_tlt.no_tlt   where talented.name_tld='" & Me.qrynam.Text & "'"
                ' ****************************************************
                Dim sql As String = "select sum(sub_hor_rly) from (subject inner join join_stud_sub_div on subject.sub_no_sy=join_stud_sub_div.sub_no_sy) inner join student on student.stud_no=join_stud_sub_div.stud_no where student.stud_no=" & no & ""
                da = New OleDb.OleDbDataAdapter(sql, conn)
                da.Fill(ds, "subtrm")
                If Not IsDBNull(ds.Tables("subtrm").Rows(0).Item(0)) Then Me.lblhor.Text = ds.Tables("subtrm").Rows(0).Item(0)
                Me.lblhor.ForeColor = Color.Blue
                '**************************************************************
                Dim sqlsub As String = "select sub_name1,sub_no_sy from subject where sub_dept=(select stud_dept from student where stud_no=" & Me.nostud.Text & ") or sub_dept='⁄«„'"
                da = New OleDb.OleDbDataAdapter(sqlsub, conn)
                da.Fill(ds, "allsub")
                Dim allsub As New ComboBox
                Dim fnd As New ComboBox
                Dim freesub As New ComboBox
                For i = 0 To ds.Tables("allsub").Rows.Count - 1
                    allsub.Items.Add(ds.Tables("allsub").Rows(i).Item(1))
                Next
                ' For i = 0 To ds.Tables("allsub").Rows.Count - 1
                da = New OleDb.OleDbDataAdapter("select distinct sub_no_sy from join_stud_sub_div where stud_no=" & Me.nostud.Text & "  union select distinct rec_sub_nosy from recordmarks where rec_no=" & Me.nostud.Text & "", conn)
                da.Fill(ds, "fnd")
                For j As Integer = 0 To ds.Tables("fnd").Rows.Count - 1
                    fnd.Items.Add(ds.Tables("fnd").Rows(j).Item(0))
                Next
                For k As Integer = 0 To allsub.Items.Count - 1
                    If fnd.FindString(allsub.Items(k)) = True Then
                        freesub.Items.Add(allsub.Items(k))
                    End If
                Next
                For i = 0 To freesub.Items.Count - 1
                    da = New OleDb.OleDbDataAdapter("select sub_name1 from subject where sub_no_sy='" & freesub.Items(i) & "'", conn)
                    da.Fill(ds, "namsub")
                    Me.cmbsub.Items.Add(ds.Tables("namsub").Rows(i).Item(0))
                Next

                '***********************************************************


            Else
                msgfalse("·«ÌÊÃœ ÿ«·» »Â–« «·—ﬁ„")
                Me.lblnam.Text = "«”„ «·ÿ«·»:" : Me.lbltru.Text = "0" : Me.lblhor.Text = "0"
                Me.cmbsub.Text = Nothing : Me.cmbsub.Items.Clear()
            End If
        End If
        'ds.Clear()
    End Sub

    Private Sub nostud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nostud.TextChanged

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static t As Byte
        t += 1
        If t >= 4 Then
            Me.Controls.Remove(state5)
            Timer1.Enabled = False
            t = 0
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim tools As Control
        For Each tools In Me.GroupBox1.Controls
            If TypeOf tools Is TextBox Or TypeOf tools Is ComboBox Then
                tools.Text = Nothing
            End If
        Next
        Me.lblnam.Text = "«”„ «·ÿ«·»:" : Me.lbltru.Text = "0" : Me.lblhor.Text = "0"
    End Sub

    Private Sub record_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles record.Click
        If Me.nostud.Text <> Nothing And Me.cmbsub.Text <> Nothing And Me.cmbdiv.Text <> Nothing Then
            If cont < max Then

                da = New OleDb.OleDbDataAdapter("select sub_no_sy from subject where sub_name1='" & Me.cmbsub.Text & "'", conn)
                da.Fill(ds, "syno")
                da = New OleDb.OleDbDataAdapter("select * from join_stud_sub_div where sub_no_sy='" & ds.Tables("syno").Rows(0).Item(0) & "' and stud_no=" & Me.nostud.Text & "", conn)
                da.Fill(ds, "sur")
                If Not ds.Tables("sur").Rows.Count > 0 Then
                    Dim sav As New OleDb.OleDbCommand
                    Dim divcnt As New OleDb.OleDbCommand
                    sav.Connection = conn
                    sav.CommandType = CommandType.Text
                    sav.CommandText = "insert into join_stud_sub_div values(" & Val(Me.nostud.Text) & ",'" & ds.Tables("syno").Rows(0).Item(0) & "'," & Val(Mid(Me.cmbdiv.Text, 1, 1)) & ",'" & Me.cmbsub.Text & "')"
                    divcnt.Connection = conn
                    divcnt.CommandType = CommandType.Text
                    divcnt.CommandText = "update division set div_rec =" & Val(cont + 1) & " where div_no=" & Val(Mid(Me.cmbdiv.Text, 1, 1)) & " and div_sub='" & Me.cmbsub.Text & "'"
                    conn.Open()
                    sav.ExecuteNonQuery()
                    divcnt.ExecuteNonQuery()
                    conn.Close()
                    msgtrue(tru)
                    Me.cmbsub.Items.Remove(Me.cmbsub.Text)
                    Me.cmbsub.Text = Me.cmbsub.Items(0)

                    ' ****************************************************
                    Dim sql As String = "select sum(sub_hor_rly) from (subject inner join join_stud_sub_div on subject.sub_no_sy=join_stud_sub_div.sub_no_sy) inner join student on student.stud_no=join_stud_sub_div.stud_no where student.stud_no=" & Me.nostud.Text & ""
                    da = New OleDb.OleDbDataAdapter(sql, conn)
                    da.Fill(ds, "subtrm")
                    If Not IsDBNull(ds.Tables("subtrm").Rows(0).Item(0)) Then Me.lblhor.Text = ds.Tables("subtrm").Rows(0).Item(0)
                    Me.lblhor.ForeColor = Color.Blue
                    '**************************************************************
                Else
                    msgfalse("«·„«œ… „”Ã·… ··ÿ«·» „”»ﬁ«")
                End If
            Else
                msgfalse("«‰ Â  «·„ﬁ«⁄œ ›Ì Â–Â «·‘⁄»…")
            End If
        Else
            msgfalse(fls)
        End If

    End Sub

    Private Sub cmbsub_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsub.SelectedIndexChanged
        constr()
        cmbdiv.Items.Clear()
        cmbdiv.Text = Nothing
        da = New OleDb.OleDbDataAdapter("select * from division where div_sub='" & Me.cmbsub.Text & "'", conn)
        da.Fill(ds, "divfree")
        For i = 0 To ds.Tables("divfree").Rows.Count - 1
            Me.cmbdiv.Items.Add((ds.Tables("divfree").Rows(i).Item(0)) & ":" & (ds.Tables("divfree").Rows(i).Item(3)) & "(" & (ds.Tables("divfree").Rows(i).Item(5)) & "-" & (ds.Tables("divfree").Rows(i).Item(6)) & ")")
            Me.cmbdiv.Items.Add("      :" & (ds.Tables("divfree").Rows(i).Item(4)) & "(" & (ds.Tables("divfree").Rows(i).Item(7)) & "-" & (ds.Tables("divfree").Rows(i).Item(8)) & ")")
            Me.cmbdiv.Items.Add("---------------------")
        Next
        ds.Clear()
    End Sub

    Private Sub dlt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dlt.Click
        constr()
        ds.Clear()
        cmb.Items.Clear()
        cmb.Location = New Point(60, 141)
        lbl.Location = New Point(78, 119)
        lbl.Text = "√Œ — «·„«œ… «·„—«œ Õ–›Â«"
        If Me.nostud.Text <> Nothing Then
            If Me.dlt.Text = "Õ–›" Then
                da = New OleDb.OleDbDataAdapter("select * from student where stud_no=" & Me.nostud.Text & "", conn)
                da.Fill(ds, "sur")
                If ds.Tables("sur").Rows.Count > 0 Then
                    da = New OleDb.OleDbDataAdapter("select distinct sub_no_sy from join_stud_sub_div where stud_no=" & Me.nostud.Text & "", conn) ' (subject inner join join_stud_sub_div on subject.sub_no_sy=join_stud_sub_div.sub_no_sy)inner join student on student.stud_no=join_stud_sub_div.stud_no where join_stud_sub_div.stud_no=" & Me.nostud.Text & "", conn)
                    da.Fill(ds, "fnd")
                    If ds.Tables("fnd").Rows.Count > 0 Then
                        For j As Integer = 0 To ds.Tables("fnd").Rows.Count - 1
                            da = New OleDb.OleDbDataAdapter("select sub_name1 from subject where sub_no_sy='" & ds.Tables("fnd").Rows(j).Item(0) & "'", conn)
                            da.Fill(ds, "nam")
                            cmb.Items.Add(ds.Tables("nam").Rows(j).Item(0))
                        Next
                        Me.GroupBox1.Controls.Add(cmb)
                        Me.GroupBox1.Controls.Add(lbl)
                        cmb.Visible = True
                        lbl.Visible = True
                        'cmb.Items.Remove("")
                        Me.dlt.Text = " √ﬂÌœ «·Õ–›"
                        Me.record.Enabled = False
                        Me.Button1.Text = " —«Ã⁄"
                    Else
                        msgfalse("·«ÌÊÃœ ··ÿ«·» „Ê«œ „”Ã·… ·Â– «·›’·")
                    End If
                Else
                    msgfalse("·«ÌÊÃœ ÿ«·» »Â–« «·—ﬁ„")
                End If
            ElseIf Me.nostud.Text <> Nothing And cmb.Text <> Nothing Then
                da = New OleDb.OleDbDataAdapter("select div_rec,div_no from division where div_no=(select div_no from join_stud_sub_div where stud_no=" & Me.nostud.Text & " and div_sub='" & Me.cmb.Text & "') and div_sub='" & Me.cmb.Text & "'", conn)
                da.Fill(ds, "divrec")
                Dim cntdiv As Integer = ds.Tables("divrec").Rows(0).Item(0)
                Dim dlt As New OleDb.OleDbCommand
                dlt.Connection = conn
                dlt.CommandType = CommandType.Text
                dlt.CommandText = "delete from join_stud_sub_div where stud_no=" & Me.nostud.Text & " and sub_no_sy=(select sub_no_sy from subject where sub_name1='" & cmb.Text & "')"
                Dim divcnt As New OleDb.OleDbCommand
                divcnt.Connection = conn
                divcnt.CommandType = CommandType.Text
                divcnt.CommandText = "update division set div_rec =" & Val(cntdiv - 1) & " where div_no=" & ds.Tables("divrec").Rows(0).Item(1) & " and div_sub='" & Me.cmbsub.Text & "'"
                conn.Open()
                dlt.ExecuteNonQuery()
                divcnt.ExecuteNonQuery()
                conn.Close()
                msgtrue(tru)
                Me.dlt.Text = "Õ–›"
                cmb.Visible = False : lbl.Visible = False
                Me.record.Enabled = True
                Me.Controls.Remove(cmb)
                Me.Controls.Remove(lbl)
                Me.Button1.Text = "Œ—ÊÃ"
                cmb.Text = ""
                ' ****************************************************
                Dim sql As String = "select sum(sub_hor_rly) from (subject inner join join_stud_sub_div on subject.sub_no_sy=join_stud_sub_div.sub_no_sy) inner join student on student.stud_no=join_stud_sub_div.stud_no where student.stud_no=" & Me.nostud.Text & ""
                da = New OleDb.OleDbDataAdapter(sql, conn)
                da.Fill(ds, "subtrm")
                If Not IsDBNull(ds.Tables("subtrm").Rows(0).Item(0)) Then Me.lblhor.Text = ds.Tables("subtrm").Rows(0).Item(0)
                Me.lblhor.ForeColor = Color.Blue
                '**************************************************************
                'cmb.Items.Clear()
                ' Else
                'msgfalse(fls)
                'End If
            End If
        Else
            msgfalse("√œŒ· —ﬁ„ «·ÿ«·» «·„—«œ Õ–› „«œ… ·Â")
        End If

    End Sub
    Function chk(ByVal itm As String) As Boolean
        If Me.cmbsub.FindString(itm) = True Then
            chk = True
        Else
            Me.cmbsub.Items.Remove(itm)
            chk = False
        End If
    End Function



    Private Sub cmbdiv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdiv.SelectedIndexChanged
        constr()
        Dim index As Integer = Me.cmbdiv.Items.IndexOf(Me.cmbdiv.Text)
        If Mid(Me.cmbdiv.Text, 1, 1) = " " Then
            Me.cmbdiv.Text = Me.cmbdiv.Items(index - 1)
        ElseIf Mid(Me.cmbdiv.Text, 1, 1) = "-" Then
            Me.cmbdiv.Text = Me.cmbdiv.Items(index - 2)
        End If
        max = 0 : cont = 0
        'MsgBox(Mid(Me.cmbdiv.Text, 1, 1))
        'Me.cmbdiv.Items.Clear()
        da = New OleDb.OleDbDataAdapter("select * from division where div_no=" & Val(Mid(Me.cmbdiv.Text, 1, 1)) & " and div_sub='" & Me.cmbsub.Text & "'", conn)
        da.Fill(ds, "free")
        '**************************************************
        Dim day1_d As String = Trim(ds.Tables("free").Rows(0).Item(3))
        Dim day1frm_d As String = Trim(ds.Tables("free").Rows(0).Item(5))
        Dim day1to_d As String = Trim(ds.Tables("free").Rows(0).Item(6))
        Dim day2_d As String = Trim(ds.Tables("free").Rows(0).Item(4))
        Dim day2frm_d As String = Trim(ds.Tables("free").Rows(0).Item(7))
        Dim day2to_d As String = Trim(ds.Tables("free").Rows(0).Item(8))
        '**************************************************

        'MsgBox(ds.Tables("free").Rows(0).Item(0).ToString)
        If Not IsDBNull(ds.Tables("free").Rows(0).Item(2)) Then max = ds.Tables("free").Rows(0).Item(2)
        If Not IsDBNull(ds.Tables("free").Rows(0).Item(11)) Then cont = ds.Tables("free").Rows(0).Item(11)

        If cont > max Then
            msgfalse("«‰ Â  «·„ﬁ«⁄œ ›Ì Â–Â «·‘⁄»…")
        End If
        If Val(Me.lblhor.Text) > 20 Then
            msgfalse("·«Ì„ﬂ‰ﬂ  Ã«Ê“ «·Õœ «·√ﬁ’Ï „‰ ⁄œœ «·”«⁄… ·Â–« «·›’·")
        End If

        ds.Clear()

    End Sub

    Private Sub recordsubject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
