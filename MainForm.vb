Public Class MainForm
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Hide()
        End
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub btnMenu1_Click(sender As Object, e As EventArgs) Handles btnMenu1.Click
        lblSelected1.Visible = True
        lblSelected3.Visible = False
        lblSelected4.Visible = False
        lblSelected5.Visible = False
    End Sub

    Private Sub btnMenu2_Click(sender As Object, e As EventArgs) Handles btnMenu2.Click
        lblSelected1.Visible = False
        lblSelected3.Visible = True
        lblSelected4.Visible = False
        lblSelected5.Visible = False
        ListForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnMenu3_Click(sender As Object, e As EventArgs) Handles btnMenu3.Click
        lblSelected1.Visible = False
        lblSelected3.Visible = False
        lblSelected4.Visible = True
        lblSelected5.Visible = False
        AboutForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        lblSelected1.Visible = False
        lblSelected3.Visible = False
        lblSelected4.Visible = False
        lblSelected5.Visible = True
        LoginForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnRev1_Click(sender As Object, e As EventArgs) Handles btnRev1.Click
        ReviewForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnRev2_Click(sender As Object, e As EventArgs) Handles btnRev2.Click
        ReviewForm2.Show()
        Me.Hide()
    End Sub

    Private Sub btnRev3_Click(sender As Object, e As EventArgs) Handles btnRev3.Click
        ReviewForm3.Show()
        Me.Hide()
    End Sub

    Private Sub btnRev4_Click(sender As Object, e As EventArgs) Handles btnRev4.Click
        ReviewForm4.Show()
        Me.Hide()
    End Sub

    Private Sub pnlContent1_Paint(sender As Object, e As PaintEventArgs) Handles pnlContent1.Paint

    End Sub
End Class
