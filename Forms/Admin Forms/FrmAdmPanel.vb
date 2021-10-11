Public Class FrmAdmPanel

    Private Sub btnViewAddUsers_Click(sender As Object, e As EventArgs) Handles btnViewAddUsers.Click
        ' when the button has been clicked, this will create a new Users Form
        ' and display it on the screen
        Dim frmAdminUser As New FrmAdmUser()
        frmAdminUser.ShowDialog()
    End Sub

    Private Sub btnViewAddGarm_Click(sender As Object, e As EventArgs) Handles btnViewAddGarm.Click
        ' when the button has been clicked, this will create a new Garments Form
        ' and display it on the screen
        Dim frmAdminGarments As New FrmAdminGarments()
        frmAdminGarments.ShowDialog()
    End Sub

    Private Sub btnViewAddCust_Click(sender As Object, e As EventArgs) Handles btnViewAddCust.Click
        ' when the button has been clicked, this will create a new Customer Form
        ' and display it on the screen
        Dim frmAdminCust As New FrmAdminCust()
        frmAdminCust.ShowDialog()
    End Sub
End Class