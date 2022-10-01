Public Class room
    Dim state3 As New Label
    Private Sub lblst(ByVal x1 As Int16, ByVal y1 As Int16)
        With state3
            .Location = New Point(x1, y1)
            .AutoSize = True
        End With
    End Sub
    Private Sub msgtrue(ByVal txt As String)
        state3.Text = txt
        lblst(15, 106)
        Me.Controls.Add(state3)
        state3.ForeColor = Color.Blue
        Timer1.Enabled = True
    End Sub
    Private Sub msgfalse(ByVal txt As String)
        state3.Text = txt
        lblst(10, 106)
        Me.Controls.Add(state3)
        state3.ForeColor = Color.Red
        Timer1.Enabled = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnext.Click
        Me.Close()
    End Sub

    Private Sub cmbflw_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbflw.SelectedIndexChanged

    End Sub

    Private Sub btnsav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsav.Click
        constr()
        ds.Clear()
        If Me.norom.Text <> Nothing And Me.numbld.Text <> Nothing Then
            da = New OleDb.OleDbDataAdapter("select * from rooms where rom_no=" & Me.norom.Text & " and rom_bld='" & Trim(Me.numbld.Text) & "'", conn)
            da.Fill(ds, "srch")
            If Not ds.Tables("srch").Rows.Count > 0 Then
                Dim sav As New OleDb.OleDbCommand
                sav.Connection = conn
                sav.CommandType = CommandType.Text
                sav.CommandText = "insert into rooms values(" & Val(Me.norom.Text) & ",'" & Trim(Me.numbld.Text) & "','" & Me.cmbdsc.Text & "','" & Me.cmbflw.Text & "'," & Val(Me.cntdsk.Text) & ")"
                conn.Open()
                sav.ExecuteNonQuery()
                conn.Close()
                msgtrue(tru)
            Else
                msgfalse("«·ﬁ«⁄… „Õ›ÊŸ… „”»ﬁ«")
            End If
        Else
            msgfalse(fls)
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static t As Byte
        t += 1
        If t >= 4 Then
            Me.Controls.Remove(state3)
            Timer1.Enabled = False
            t = 0
        End If
    End Sub

    Private Sub btndlt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndlt.Click
        constr()
        If Me.norom.Text <> Nothing And Me.numbld.Text <> Nothing Then
            da = New OleDb.OleDbDataAdapter("select * from rooms where rom_no=" & Me.norom.Text & " and rom_bld='" & Trim(Me.numbld.Text) & "'", conn)
            da.Fill(ds, "srch")
            If ds.Tables("srch").Rows.Count > 0 Then
                If MsgBox("Â· √‰  „ √ﬂœ „‰ ⁄„·Ì… «·Õ–›", MsgBoxStyle.YesNo, " ‰»Ì…") = MsgBoxResult.Yes Then
                    Dim dlt As New OleDb.OleDbCommand
                    dlt.Connection = conn
                    dlt.CommandType = CommandType.Text
                    dlt.CommandText = "delete from rooms where rom_no=" & Me.norom.Text & " and rom_bld='" & Trim(Me.numbld.Text) & "'"
                    conn.Open()
                    dlt.ExecuteNonQuery()
                    conn.Close()
                    msgtrue(tru)
                End If
            Else
                msgfalse("«·ﬁ«⁄… «·„—«œ Õ–›Â« €Ì— „ÊÃÊœ…")
            End If
        Else
            msgfalse("√œŒ· —ﬁ„ Ê„»‰«¡ «·ﬁ«⁄… «·„—«œ Õ–›Â« ")
        End If
    End Sub

    Private Sub btnedt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedt.Click
        constr()
        If Me.btnedt.Text = " ⁄œÌ·" Then
            If Me.norom.Text <> Nothing And Me.numbld.Text <> Nothing Then
                da = New OleDb.OleDbDataAdapter("select * from rooms where rom_no=" & Me.norom.Text & " and rom_bld='" & Trim(Me.numbld.Text) & "'", conn)
                da.Fill(ds, "fnd")
                If ds.Tables("fnd").Rows.Count > 0 Then
                    Me.cmbdsc.Text = ds.Tables("fnd").Rows(0).Item(2)
                    Me.cmbflw.Text = ds.Tables("fnd").Rows(0).Item(3)
                    Me.cntdsk.Text = ds.Tables("fnd").Rows(0).Item(4)
                    Me.btnedt.Text = "Õ›Ÿ «· ⁄œÌ·"
                    Me.norom.ReadOnly = True
                    Me.numbld.ReadOnly = True
                Else
                    msgfalse("·« ÊÃœ ﬁ«⁄… »Â–« «·—ﬁ„")
                End If
            Else
                msgfalse(fls)
            End If
        Else
            Dim edt As New OleDb.OleDbCommand
            edt.Connection = conn
            edt.CommandType = CommandType.Text
            edt.CommandText = "update rooms set rom_dsc='" & Me.cmbdsc.Text & "',rom_dsc_typ='" & Me.cmbflw.Text & "',rom_dsk=" & Val(Me.cntdsk.Text) & " where rom_no=" & Me.norom.Text & " and rom_bld='" & Me.numbld.Text & "'"
            conn.Open()
            edt.ExecuteNonQuery()
            conn.Close()
            msgtrue(tru)
            Me.btnedt.Text = " ⁄œÌ·"
            Me.norom.ReadOnly = False
            Me.numbld.ReadOnly = False
        End If
    End Sub

    Private Sub btncln_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncln.Click
        Dim tools As Control
        For Each tools In Me.GroupBox1.Controls
            If TypeOf tools Is TextBox Or TypeOf tools Is ComboBox Then
                tools.Text = Nothing
            End If
        Next
    End Sub

    Private Sub cmbdsc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdsc.SelectedIndexChanged
        Me.cmbflw.Enabled = True
    End Sub

    Private Sub room_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class