Imports MySql.Data.MySqlClient
Public Class ReviewForm2
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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
    Private Sub BunifuRating2_onValueChanged(sender As Object, e As EventArgs) Handles BunifuRating2.onValueChanged
        If BunifuRating2.Value = 1 Then
            MsgBox("Oof, that was bad!", MsgBoxStyle.Information, "Rating Scale")
        ElseIf BunifuRating2.Value = 2 Then
            MsgBox("Meh, it passed the time", MsgBoxStyle.Information, "Rating Scale")
        ElseIf BunifuRating2.Value = 3 Then
            MsgBox("Ok, that was pretty good", MsgBoxStyle.Information, "Rating Scale")
        ElseIf BunifuRating2.Value = 4 Then
            MsgBox("Awesome!", MsgBoxStyle.Information, "Rating Scale")
        ElseIf BunifuRating2.Value = 5 Then
            MsgBox("So Fresh, absolute must see!", MsgBoxStyle.Information, "Rating Scale")
        End If
    End Sub
    Private Sub txtReview_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtReview.Click
        If txtReview.Text = "What did you think about the movie?" Then
            txtReview.Text = ""
            txtReview.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtReview_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtReview.Text = "What did you think about the movie?" Or txtReview.Text = "" Then
            txtReview.Text = "What did you think about the movie?"
            txtReview.ForeColor = Color.Silver
        End If
    End Sub
    Private Sub txtReview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReview.Click
        If txtReview.Text = "What did you think about the movie?" Then
            txtReview.Text = ""
            txtReview.ForeColor = Color.Black
        End If
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        WebBrowser1.Navigate("https://www.youtube.com/watch?v=szby7ZHLnkA")
    End Sub
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim connection As New MySqlConnection("server=localhost; username=root; password= ; database=database_film")
        Dim command As New MySqlCommand("INSERT INTO `review`(`revsingkat`,`rate`) VALUES (@rev,@rt)", connection)
        command.Parameters.Add("@rev", MySqlDbType.VarChar).Value = txtReview.Text
        command.Parameters.Add("@rt", MySqlDbType.VarChar).Value = BunifuRating2.Value
        connection.Open()
        If command.ExecuteNonQuery() = 1 Then
            MsgBox("Review Berhasil Disimpan", MsgBoxStyle.Information)
            Me.Close()
            MainForm.Show()
        Else
            MsgBox("Anda Salah Memasukkan Data", MsgBoxStyle.Exclamation)
        End If
        connection.Close()
    End Sub

    Private Sub ReviewForm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class