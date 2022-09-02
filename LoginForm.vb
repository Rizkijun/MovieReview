Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Public Class LoginForm
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0
        Dim tmr As New Timer
        tmr.Interval = 2
        tmr.Start()
        AddHandler tmr.Tick, Sub()
                                 Me.Opacity += 0.1
                                 If Me.Opacity = 1 Then tmr.Stop()
                             End Sub
    End Sub

    Private Sub LoginForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Me.Opacity = 1
        Dim tmr As New Timer
        tmr.Interval = 1
        tmr.Start()
        AddHandler tmr.Tick, Sub()
                                 Me.Opacity -= 0.1
                                 If Me.Opacity = 0 Then
                                     e.Cancel = False
                                     tmr.Stop()
                                     Me.Dispose()
                                 End If
                             End Sub
    End Sub

    Dim draggable As Boolean
    Dim mouseX As Integer
    Dim mouseY As Integer

    Private Sub pnlLogin_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlLogin.MouseDown
        draggable = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub pnlLogin_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlLogin.MouseMove
        If draggable Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    Private Sub pnlLogin_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlLogin.MouseUp
        draggable = False
    End Sub

    Private Sub LogoPictureBox_MouseDown(sender As Object, e As MouseEventArgs) Handles LogoPictureBox.MouseDown
        draggable = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub LogoPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles LogoPictureBox.MouseMove
        If draggable Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    Private Sub LogoPictureBox_MouseUp(sender As Object, e As MouseEventArgs) Handles LogoPictureBox.MouseUp
        draggable = False
    End Sub

    Private Sub btnMasuk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasuk.Click
        Dim connection As New MySqlConnection("server=localhost;username=root;password= ;database=database_film")
        Try
            connection.Open()
        Catch myError As MySqlException
            MsgBox("Ada kesalahan dalam koneksi database")
        End Try
        Dim myAdapter As New MySqlDataAdapter
        Dim sqlquery = "SELECT * FROM login WHERE Username = '" + txtUsername.Text + "' AND Password= '" + txtPassword.Text + "'"
        Dim myCommand As New MySqlCommand
        myCommand.Connection = connection
        myCommand.CommandText = sqlquery
        myAdapter.SelectCommand = myCommand
        Dim myData As MySqlDataReader
        myData = myCommand.ExecuteReader()
        myData.Read()
        If myData.HasRows = 0 Then
            MsgBox("Username atau Password Salah!", MsgBoxStyle.Exclamation, "Error Login")
        Else
            Me.Hide()
            MsgBox("Login Berhasil, Selamat Datang " & txtUsername.Text & "!", MsgBoxStyle.Information, "Successfully Login")
            MainForm.TS1.Text = myData!username
            MainForm.Show()
        End If
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

    Private Sub Daftar_Click(sender As Object, e As EventArgs) Handles btnToDaftar.Click
        RegistrationForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        End
    End Sub
End Class