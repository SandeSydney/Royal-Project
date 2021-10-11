Imports MySql.Data.MySqlClient

Public Class FrmLogin

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        ' validate that the textboxes are not empty
        ' also check if they exist in the database

        Dim connection As MySqlConnection = mysqldb()   ' get connection to the database
        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim command As New MySqlCommand("SELECT `userId`, `password` FROM `users` WHERE `userId` = @userId AND `password` = @pass", connection)

        command.Parameters.Add("@userId", MySqlDbType.VarChar).Value = txtUserId.Text
        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = txtPassword.Text

        If txtUserId.Text.Trim() = "" Or txtPassword.Text.Trim() = "" Then
            MsgBox("Enter Correct Username and Password")
        Else
            adapter.SelectCommand = command
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                Dim frmHome As New FrmHome()
                frmHome.ShowDialog()
                txtUserId.ResetText()
                txtPassword.ResetText()
            Else
                MsgBox("Not Logged In")
            End If
        End If
    End Sub

End Class