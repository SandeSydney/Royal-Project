Imports MySql.Data.MySqlClient

Public Class FrmCustomer

    ' In order for the form to access and manipulate the database, the following properties have to be declared

    Dim sqlCommand As New MySqlCommand ' for sql commands
    Dim sqlReader As MySqlDataReader ' to read the sql in database
    Dim sqlDataTable As New DataTable   ' table to store data from the sql
    Dim sqlDataAdapter As New MySqlDataAdapter ' data adapter for the sql
    Dim sqlQuery As String  ' variable to hold the sql query
    Dim sqlDataset As DataSet
    Dim sqlQueryRld As String = "SELECT `customerId` as `Customer ID`, `firstname` as `Firstname`, `lastname` as `Lastname`, `telephone` as `Telephone`, `address` as `Address` FROM `customer`"

    Private bitmap As Bitmap    ' property to be used for printing the reports

    Public sqlConnection As MySqlConnection = mysqldb()  ' get connection to the database


    Private Sub FrmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' call the database manipulation function when the form loads, it initialises the database itself
        ReloadTable(sqlQueryRld, dgvCustomer)
        ' auto space the name and item columns
        dgvCustomer.Columns("Firstname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvCustomer.Columns("Lastname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvCustomer.Columns("Address").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        sqlQuery = "INSERT INTO customer(customerId, firstname, lastname, telephone, address) 
                        VALUES('" & txtCustomerId.Text & "','" & txtFirstname.Text & "','" & txtLastname.Text & "','" & txtTelephone.Text & "','" & txtAddress.Text & "')"
        SaveData(sqlQuery)
        ClearScreen(pnlCustomer)
        ReloadTable(sqlQueryRld, dgvCustomer)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ClearScreen(pnlCustomer)

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        ' open the database in order to save the updated data into it
        sqlConnection.Open()
        sqlCommand.Connection = sqlConnection

        With sqlCommand

            ' statement to gather the updated data and manipulate the database
            .CommandText = "UPDATE customer SET customerId = @customerId, firstname = @firstname, 
                               lastname = @lastname, telephone = @telephone, address = @address WHERE customerId = @customerId"

            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@customerId", txtCustomerId.Text)
            .Parameters.AddWithValue("@firstname", txtFirstname.Text)
            .Parameters.AddWithValue("@lastname", txtLastname.Text)
            .Parameters.AddWithValue("@telephone", txtTelephone.Text)
            .Parameters.AddWithValue("@address", txtAddress.Text)

        End With

        ' execute the update query
        sqlCommand.ExecuteNonQuery()
        sqlConnection.Close()
        ClearScreen(pnlCustomer)
        ReloadTable(sqlQueryRld, dgvCustomer)

    End Sub

    Private Sub dgvGarment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomer.CellClick

        ' populate the data clicked from the datagridview into the textBoxes
        Try
            txtCustomerId.Text = dgvCustomer.SelectedRows(0).Cells(0).Value.ToString
            txtFirstname.Text = dgvCustomer.SelectedRows(0).Cells(1).Value.ToString
            txtLastname.Text = dgvCustomer.SelectedRows(0).Cells(2).Value.ToString
            txtTelephone.Text = dgvCustomer.SelectedRows(0).Cells(3).Value.ToString
            txtAddress.Text = dgvCustomer.SelectedRows(0).Cells(4).Value.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        ' when the delete button is clicked, execute the following line of code
        sqlQuery = "DELETE FROM `customer` WHERE `customerId` LIKE '%" & txtCustomerId.Text & "%'"

        DeleteData(sqlQuery, "customer")
        ClearScreen(pnlCustomer)
        ReloadTable(sqlQueryRld, dgvCustomer)

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        sqlDataAdapter = New MySqlDataAdapter("SELECT `customerId` as `Customer ID`, `firstname` as `Firstname`, `lastname` as `Lastname`, `telephone` as `Telephone`, `address` as `Address` FROM `customer` WHERE `firstname` LIKE '%" & txtSearch.Text & "%'", sqlConnection)
        sqlDataset = New DataSet
        sqlDataAdapter.Fill(sqlDataset, "customer")
        dgvCustomer.DataSource = sqlDataset.Tables(0)

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'when the back button is clicked, remove the form from focus
        Me.Close()
    End Sub
End Class