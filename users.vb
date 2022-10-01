Public Class users

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        On Error Resume Next
        constr()
        Dim sudusr As New OleDb.OleDbCommand
        sudusr.Connection = conn
        sudusr.CommandType = CommandType.Text
        If Me.addusr.Checked = True Then
            If Not Me.cmbusr.Text = "" And Not Me.passusr.Text = "" Then
                da = New OleDb.OleDbDataAdapter("select * from users where name_usr='" & Me.cmbusr.Text & "' or pass_usr='" & Me.passusr.Text & "'", conn)
                da.Fill(ds, "find")
                If ds.Tables("find").Rows.Count < 1 Then
                    sudusr.CommandText = "insert into users (name_usr,pass_usr)values('" & Me.cmbusr.Text & "','" & Me.passusr.Text & "')"
                    conn.Open()
                    sudusr.ExecuteNonQuery()
                    conn.Close()
                    MsgBox(" „  «·≈÷«›… »‰Ã«Õ", MsgBoxStyle.Information, "‰ÃÕ  «·⁄„·Ì…")
                Else
                    MsgBox("ﬂ·„… «·„—Ê— √Ê «”„ «·„” Œœ„ „ÊÃÊœ „”»ﬁ« .. ", MsgBoxStyle.Information, "›‘· «·⁄„·Ì…")
                End If
            Else
                MsgBox("«œŒ· «”„ «·„” Œœ„ Êﬂ·„… «·„—Ê—", MsgBoxStyle.Critical, "√œŒ· «·»Ì«‰« ")
            End If
        ElseIf Me.updusr.Checked = True Then
            If Not Me.passusr.Text = "" And Not Me.cmbusr.Text = "" Then
                da = New OleDb.OleDbDataAdapter("select * from users where pass_usr='" & Me.passusr.Text & "'", conn)
                da.Fill(ds, "fndpass")
                If ds.Tables("fndpass").Rows.Count > 0 Then
                    sudusr.CommandText = "update users set name_usr='" & Trim(Me.cmbusr.Text) & "',pass_usr='" & Me.passusr.Text & "' where pass_usr='" & Me.passusr.Text & "'"
                    conn.Open()
                    sudusr.ExecuteNonQuery()
                    conn.Close()
                    MsgBox(" „ «· ⁄œÌ· »‰Ã«Õ", MsgBoxStyle.Information, "‰ÃÕ  «·⁄„·Ì…")
                Else
                    MsgBox("ﬂ·„… «·„—Ê— Œÿ√", MsgBoxStyle.Critical, "›‘· «·⁄„·Ì…")
                End If
            Else
                MsgBox("·«Ì„ﬂ‰ﬂ «· ⁄œÌ· ≈·« »Ê«”ÿ… ﬂ·„… «·„—Ê— «·Œ«’Â »ﬂ", MsgBoxStyle.Information, "›‘· «·⁄„·Ì…")
            End If
        ElseIf Me.dltusr.Checked = True Then
            If Not Me.passusr.Text = "" Then
                da = New OleDb.OleDbDataAdapter("select * from users where pass_usr='" & Me.passusr.Text & "'", conn)
                da.Fill(ds, "fndpass2")
                If ds.Tables("fndpass2").Rows.Count > 0 Then
                    sudusr.CommandText = "delete from users where pass_usr='" & Me.passusr.Text & "'"
                    conn.Open()
                    sudusr.ExecuteNonQuery()
                    conn.Close()
                    MsgBox(" „ «·Õ–› »‰Ã«Õ", MsgBoxStyle.Information, "‰ÃÕ  «·⁄„·Ì…")
                Else
                    MsgBox("ﬂ·„… «·„—Ê— Œÿ√", MsgBoxStyle.Critical, "›‘· «·⁄„·Ì…")
                End If
            Else
                MsgBox("·«Ì„ﬂ‰ﬂ «·Õ–› ≈·« »Ê«”ÿ… ﬂ·„… «·„—Ê— «·’ÕÌÕ… Ê «·Œ«’Â »ﬂ", MsgBoxStyle.Information, "›‘· «·⁄„·Ì…")
            End If

        Else
            MsgBox("ÌÃ» ⁄·Ìﬂ «Œ Ì«— ⁄·„·Ì… (≈÷«›…° ⁄œÌ·°Õ–›) ﬁ»· «·÷€ÿ ⁄·Ï „Ê«›ﬁ")
        End If
        '***************************************************************
        cmbusr.Items.Clear()
        ds.Clear()
        da = New OleDb.OleDbDataAdapter("select distinct name_usr from users ", conn)
        da.Fill(ds, "cmbusr")
        For i = 0 To ds.Tables("cmbusr").Rows.Count - 1
            Me.cmbusr.Items.Add(ds.Tables("cmbusr").Rows(i).Item(0))
        Next
        ds.Clear()
        'ds.Tables("find").Clear() : ds.Tables("fndpass").Clear() : ds.Tables("fndpass2").Clear()
        Dim rdo1 As Control
        For Each rdo1 In Me.Panel5.Controls
            If TypeOf rdo1 Is RadioButton Then
                rdo1.Refresh()
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class