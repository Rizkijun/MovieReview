Imports MySql.Data.MySqlClient
Public Class RegistrationForm
    Private Sub btnDaftar_Click(sender As Object, e As EventArgs) Handles btnDaftar.Click
        Dim connection As New MySqlConnection("server=localhost; username=root; password= ; database=database_film")
        Dim command As New MySqlCommand("INSERT INTO `login`(`username`, `email`, `password`) VALUES (@user, @email, @pwd)", connection)
        command.Parameters.Add("@user", MySqlDbType.VarChar).Value = txtUsername.Text
        command.Parameters.Add("@email", MySqlDbType.VarChar).Value = txtEmail.Text
        command.Parameters.Add("@pwd", MySqlDbType.VarChar).Value = txtPassword.Text
        connection.Open()
        If command.ExecuteNonQuery() = 1 Then
            MsgBox("Anda Telah Berhasil Daftar", MsgBoxStyle.Information)
        Else
            MsgBox("Anda Salah Memasukkan Data", MsgBoxStyle.Exclamation)
        End If
        connection.Close()
    End Sub
    Private Sub txtUsername_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.Leave
        If txtUsername.Text = "Username" Or txtUsername.Text = "" Then
            txtUsername.ForeColor = Color.Silver
            txtUsername.Text = "Username"
        End If
    End Sub

    Private Sub txtUsername_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtUsername.MouseClick
        If txtUsername.Text = "Username" Then
            txtUsername.Clear()
            txtUsername.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged

    End Sub
    Private Sub txtEmail_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmail.Leave
        If txtEmail.Text = "Email" Or txtEmail.Text = "" Then
            txtEmail.ForeColor = Color.Silver
            txtEmail.Text = "Email"
        End If
    End Sub

    Private Sub txtEmail_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtEmail.MouseClick
        If txtEmail.Text = "Email" Then
            txtEmail.Clear()
            txtEmail.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail.TextChanged

    End Sub
    Private Sub txtPassword_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.Leave
        If txtPassword.Text = "Password" Or txtPassword.Text = "" Then
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.Silver
            txtPassword.PasswordChar = ""
        End If
    End Sub

    Private Sub txtPassword_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPassword.MouseClick
        If txtPassword.Text = "Password" Then
            txtPassword.Clear()
            txtPassword.ForeColor = Color.Black
            txtPassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text = "Username" Then
            txtPassword.ForeColor = Color.Black
        End If
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        LoginForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        End
    End Sub

    Private Sub RegistrationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
