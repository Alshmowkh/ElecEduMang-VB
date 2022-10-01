Public Class logon

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        If Me.TextBox1.Text <> "" And Me.TextBox2.Text <> "" Then
            Dim rdtm As Integer = GetSetting("ap", "se", "ke", "0000")
            Static t As Byte
            Dim tmnow As Integer = DatePart(DateInterval.Hour, Now) & DatePart(DateInterval.Minute, Now)
            ' Try
            If rdtm + 5 <= tmnow Then
                On Error GoTo errorend
                constr()
                ds.Clear()
                da = New OleDb.OleDbDataAdapter("select name_usr,pass_usr from users where name_usr='" + (Me.TextBox1.Text) + "' and pass_usr='" + Me.TextBox2.Text + "'", conn)
                da.Fill(ds, "sureuser")
                If ds.Tables("sureuser").Rows.Count > 0 Then
                    ds.Clear()
                    t = 0
                    SaveSetting("ap", "se", "ke", 0)
                    Dim frm As New home
                    frm.Show()
                    Me.Hide()
                Else
                    MsgBox("ﬂ·„… «·„—Ê— √Ê √”„ «·„” Œœ„ Œÿ«", MsgBoxStyle.Critical)
                    t += 1
                    If t > 3 Then
                        MsgBox("·ﬁœ «” ‰›œ  ÃÌ„⁄ «·›—’ «·„ «Õ… ··Œÿ√", MsgBoxStyle.Information, "œŒÊ· Œ«ÿ∆")
                        SaveSetting("ap", "se", "ke", tmnow)
                        MsgBox("·«Ì„ﬂ‰ﬂ «·œŒÊ· ⁄·Ï «·‰Ÿ«„ ≈·« »⁄œ 5 œﬁ«∆ﬁ ⁄·Ï «·√ﬁ·", MsgBoxStyle.Information)
                    End If
                End If
            Else
                MsgBox("·«Ì„ﬂ‰ﬂ «·œŒÊ· ⁄·Ï «·‰Ÿ«„ ≈·« »⁄œ 5 œﬁ«∆ﬁ ⁄·Ï «·√ﬁ·.......", MsgBoxStyle.Information)
                t = 0
            End If
            ' Catch ex As Exception
            ' joindb.ShowDialog()
            'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)

            ' End Try
        Else
            MsgBox("Ì—ÃÏ √œŒ«· »Ì«‰«  «·„” Œœ„", MsgBoxStyle.Critical, " ”ÃÌ· «·œŒÊ·")
        End If
errorend:
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

        End
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        Me.TextBox1.Text = Nothing
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If Me.TextBox1.Text = Nothing Then
            Me.TextBox1.Text = "«”„ «·„” Œœ„..ø"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        Me.TextBox2.Text = Nothing
        Me.TextBox2.PasswordChar = "*"
    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If Me.TextBox2.Text = Nothing Then
            Me.TextBox2.PasswordChar = ""
            Me.TextBox2.Text = "ﬂ·„… «·„—Ê—..ø"
        End If
    End Sub

End Class