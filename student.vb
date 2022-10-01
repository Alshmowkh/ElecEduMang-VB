Imports System.Threading
Public Class student
    Dim state8 As New Label
    Public Sub lblst(ByVal x1 As Int16, ByVal y1 As Int16)
        With state8
            .Location = New Point(x1, y1)
            .AutoSize = True
        End With
    End Sub
    Private Sub msgtrue(ByVal txt As String)
        state8.Text = txt
        lblst(83, 105)
        Me.Controls.Add(state8)
        state8.ForeColor = Color.Blue
        Timer1.Enabled = True
    End Sub
    Private Sub msgfalse(ByVal txt As String)
        state8.Text = txt
        lblst(83, 105)
        Me.Controls.Add(state8)
        state8.ForeColor = Color.Red
        Timer1.Enabled = True
    End Sub
   
    Private Sub delting(ByVal num As Integer, ByVal tbl As String)
        constr()
        ds.Clear()
        If num <> Nothing Then
            da = New OleDb.OleDbDataAdapter("select * from student where stud_no=" & num & "", conn)
            da.Fill(ds, "delt")
            If ds.Tables("delt").Rows.Count > 0 Then
                Me.namestud.Text = ds.Tables("delt").Rows(0).Item(1)
                Me.nation.Text = ds.Tables("delt").Rows(0).Item(2)
                Me.dept.Text = ds.Tables("delt").Rows(0).Item(3)
                Me.year.Text = ds.Tables("delt").Rows(0).Item(4)
                Me.term.Text = ds.Tables("delt").Rows(0).Item(5)
                Me.mob.Text = ds.Tables("delt").Rows(0).Item(6)
                Me.emlstud.Text = ds.Tables("delt").Rows(0).Item(7)
                Me.idstud.Text = ds.Tables("delt").Rows(0).Item(8)
                If MsgBox("Â· √‰  „ √ﬂœ „‰ ⁄„·Ì… «·Õ–›", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim delt As New OleDb.OleDbCommand
                    delt.Connection = conn
                    delt.CommandType = CommandType.Text
                    delt.CommandText = "delete from " & tbl & " where stud_no=" & num & ""
                    conn.Open()
                    delt.ExecuteNonQuery()
                    conn.Close()
                    msgtrue(tru)
                End If
            Else
                msgfalse("«·—ﬁ„ «·„œŒ· €Ì— „ÊÃÊœ")
            End If
        Else
            msgfalse("√œŒ· —ﬁ„ «·ÿ«·» «·„—«œ Õ–›Â")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ext.Click
        Me.Close()
    End Sub

    Private Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click

        If Me.namestud.Text <> Nothing And Me.year.Text <> Nothing Or Me.term.Text <> Nothing Or Me.dept.Text <> Nothing Then
            constr()
            Dim stud_year As String = Mid(Now.Year, 3, 4)
            'Dim partyear As String = stud_year
            Dim student_count As Integer
            Dim student_no As Integer
            da = New OleDb.OleDbDataAdapter("select max(stud_no) from student where stud_no like '" & stud_year & "%'", conn)
            da.Fill(ds, "count")
            student_count = ds.Tables("count").Rows(0).Item(0)
            student_no = student_count + 1
            '**********************************************************************

            Dim sav As New OleDb.OleDbCommand
            sav.Connection = conn
            sav.CommandType = CommandType.Text
            sav.CommandText = "insert into student values(" & student_no & ",'" & Trim(Me.namestud.Text) & "','" & Trim(Me.nation.Text) & "','" & Trim(Me.dept.Text) & "','" & Trim(Me.year.Text) & "','" & Trim(Me.term.Text) & "'," & Val(Me.mob.Text) & ",'" & Trim(Me.emlstud.Text) & "'," & Val(Me.idstud.Text) & ")"
            conn.Open()
            sav.ExecuteNonQuery()
            conn.Close()

            '*****************************************************************
            msgtrue(tru)
        Else
            msgfalse(fls)
        End If
    End Sub

    Private Sub clr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clr.Click

        Dim tools As Control
        For Each tools In Me.GroupBox1.Controls
            If TypeOf tools Is TextBox Or TypeOf tools Is ComboBox Then
                tools.Text = Nothing
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static t As Byte
        t += 1
        If t >= 4 Then
            Me.Controls.Remove(state8)
            Timer1.Enabled = False
            t = 0
        End If
    End Sub

    Private Sub delt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delt.Click
        delting(Val(Me.no.Text), "student")
    End Sub


    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        constr()
        If Me.no.Text <> Nothing Then
            If Me.edit.Text = " ⁄œÌ·" Then
                da = New OleDb.OleDbDataAdapter("select * from student where stud_no=" & Me.no.Text & "", conn)
                da.Fill(ds, "fnd")
                If ds.Tables("fnd").Rows.Count > 0 Then
                    Me.namestud.Text = ds.Tables("fnd").Rows(0).Item(1)
                    Me.nation.Text = ds.Tables("fnd").Rows(0).Item(2)
                    Me.dept.Text = ds.Tables("fnd").Rows(0).Item(3)
                    Me.year.Text = ds.Tables("fnd").Rows(0).Item(4)
                    Me.term.Text = ds.Tables("fnd").Rows(0).Item(5)
                    Me.mob.Text = ds.Tables("fnd").Rows(0).Item(6)
                    Me.emlstud.Text = ds.Tables("fnd").Rows(0).Item(7)
                    Me.idstud.Text = ds.Tables("fnd").Rows(0).Item(8)
                    Me.edit.Text = "Õ›Ÿ «· ⁄œÌ·"
                    Me.save.Enabled = False
                Else
                    msgfalse("·« ÌÊÃœ ÿ«·» »Â–« «·—ﬁ„")
                End If
            Else
                Dim edt As New OleDb.OleDbCommand
                edt.Connection = conn
                edt.CommandType = CommandType.Text
                edt.CommandText = "update student set stud_name='" & Trim(Me.namestud.Text) & "',stud_natio='" & Trim(Me.nation.Text) & "',stud_dept='" & Trim(Me.dept.Text) & "',stud_year='" & Trim(Me.year.Text) & "',stud_term='" & Trim(Me.term.Text) & "',stud_mob='" & Trim(Me.mob.Text) & "',stud_eml='" & Trim(Me.emlstud.Text) & "',stud_id='" & Trim(Me.idstud.Text) & "' where stud_no=" & Val(Me.no.Text) & ""
                conn.Open()
                edt.ExecuteNonQuery()
                conn.Close()
                msgtrue(tru)
                Me.edit.Text = " ⁄œÌ·"
                Me.save.Enabled = True
            End If
        Else
            msgfalse(fls)
        End If
    End Sub

    Private Sub no_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles no.GotFocus
        Me.no.BackColor = Color.Yellow
    End Sub

    Private Sub no_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles no.KeyPress
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

    Private Sub no_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles no.LostFocus
        Me.no.BackColor = Color.White
    End Sub

    Private Sub no_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles no.TextChanged

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

    Private Sub term_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles term.SelectedIndexChanged

    End Sub
End Class