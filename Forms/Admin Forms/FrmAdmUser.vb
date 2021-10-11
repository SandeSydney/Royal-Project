Imports MySql.Data.MySqlClient

Public Class FrmAdmUser

    ' In order for the form to access and manipulate the database, the following properties have to be declared

    Dim sqlCommand As New MySqlCommand ' for sql commands
    Dim sqlReader As MySqlDataReader ' to read the sql in database
    Dim sqlDataTable As New DataTable   ' table to store data from the sql
    Dim sqlDataAdapter As New MySqlDataAdapter ' data adapter for the sql
    Dim sqlQuery As String  ' variable to hold the sql query
    Dim sqlDataset As DataSet
    Dim sqlQueryRld As String = "SELECT `userId` as `User ID`, `firstname` as `Firstname`, `lastname` as `Lastname`, `password` as `Password`, `role` as `Role` FROM `users`"

    Private bitmap As Bitmap    ' property to be used for printing the reports

    Public sqlConnection As MySqlConnection = mysqldb()  ' get connection to the database


    Private Sub FrmAdmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' call the database manipulation function when the form loads, it initialises the database itself
        ReloadTable(sqlQueryRld, dgvUsers)
        ' auto space the name and item columns
        dgvUsers.Columns("Firstname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvUsers.Columns("Lastname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        sqlQuery = "INSERT INTO users(userId, firstname, lastname, password, role) 
                        VALUES('" & txtUserId.Text & "','" & txtFirstname.Text & "','" & txtLastname.Text & "','" & txtPassword.Text & "','" & cmbRole.Text & "')"
        SaveData(sqlQuery)
        ClearScreen(pnlUsers)
        ReloadTable(sqlQueryRld, dgvUsers)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ClearScreen(pnlUsers)

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        ' open the database in order to save the updated data into it
        sqlConnection.Open()
        sqlCommand.Connection = sqlConnection

        With sqlCommand

            ' statement to gather the updated data and manipulate the database
            .CommandText = "UPDATE users SET userId = @userId, firstname = @firstname, 
                               lastname = @lastname, password = @password, role = @role WHERE userId = @userId"

            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@userId", txtUserId.Text)
            .Parameters.AddWithValue("@firstname", txtFirstname.Text)
            .Parameters.AddWithValue("@lastname", txtLastname.Text)
            .Parameters.AddWithValue("@password", txtPassword.Text)
            .Parameters.AddWithValue("@role", cmbRole.Text)

        End With

        ' execute the update query
        sqlCommand.ExecuteNonQuery()
        sqlConnection.Close()
        ClearScreen(pnlUsers)
        ReloadTable(sqlQueryRld, dgvUsers)

    End Sub

    Private Sub dgvGarment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick

        ' populate the data clicked from the datagridview into the textBoxes
        Try
            txtUserId.Text = dgvUsers.SelectedRows(0).Cells(0).Value.ToString
            txtFirstname.Text = dgvUsers.SelectedRows(0).Cells(1).Value.ToString
            txtLastname.Text = dgvUsers.SelectedRows(0).Cells(2).Value.ToString
            txtPassword.Text = dgvUsers.SelectedRows(0).Cells(3).Value.ToString
            cmbRole.Text = dgvUsers.SelectedRows(0).Cells(4).Value.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        ' when the delete button is clicked, execute the following line of code
        sqlQuery = "DELETE FROM `users` WHERE `userId` LIKE '%" & txtUserId.Text & "%'"

        DeleteData(sqlQuery, "users")
        ClearScreen(pnlUsers)
        ReloadTable(sqlQueryRld, dgvUsers)

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        sqlDataAdapter = New MySqlDataAdapter("SELECT `userId` as `User ID`, `firstname` as `Firstname`, `lastname` as `Lastname`, `password` as `Password`, `role` as `Role` FROM `users` WHERE `firstname` LIKE '%" & txtSearch.Text & "%'", sqlConnection)
        sqlDataset = New DataSet
        sqlDataAdapter.Fill(sqlDataset, "users")
        dgvUsers.DataSource = sqlDataset.Tables(0)

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'when the back button is clicked, remove the form from focus
        Me.Close()
    End Sub
End Class