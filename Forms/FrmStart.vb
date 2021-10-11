Public Class FrmStart
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' when the Login button has been clicked, this will create a new Login Form
        ' and display it on the screen
        Dim frmLogin As New FrmLogin()
        frmLogin.ShowDialog()
    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        ' when the Admin button has been clicked, this will create a new admin Form
        ' and display it on the screen
        Dim frmAdminLogin As New FrmAdmLogin()
        frmAdminLogin.ShowDialog()
    End Sub
End Class
