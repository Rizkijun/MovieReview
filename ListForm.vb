Imports MySql.Data.MySqlClient
Public Class ListForm
    Private Sub ListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=")
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT * FROM database_film.review", connection)

        adapter.Fill(table)

        DataGridView1.DataSource = table
    End Sub
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

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        MainForm.Show()
        Me.Hide()
    End Sub
End Class