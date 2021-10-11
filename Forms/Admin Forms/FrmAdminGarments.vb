Imports MySql.Data.MySqlClient

Public Class FrmAdminGarments

    ' In order for the form to access and manipulate the database, the following properties have to be declared

    Dim sqlCommand As New MySqlCommand ' for sql commands
    Dim sqlReader As MySqlDataReader ' to read the sql in database
    Dim sqlDataTable As New DataTable   ' table to store data from the sql
    Dim sqlDataAdapter As New MySqlDataAdapter ' data adapter for the sql
    Dim sqlQuery As String  ' variable to hold the sql query
    Dim sqlDataset As DataSet
    Dim sqlQueryRld As String = "SELECT `garmentId` as `Garment ID`, `customerId` as `Customer ID`, `type` as `Type`, `color` as `Color`, `quantity` as `Quantity`, `dispatched` as `Dispatched` FROM `garments`"

    Private bitmap As Bitmap    ' property to be used for printing the reports

    Public sqlConnection As MySqlConnection = mysqldb()  ' get connection to the database


    Private Sub FrmAdminGarments_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' call the database manipulation function when the form loads, it initialises the database itself
        ReloadTable(sqlQueryRld, dgvGarment)
        ' auto space the name and item columns
        dgvGarment.Columns("Garment ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvGarment.Columns("Customer ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        sqlQuery = "INSERT INTO garments(garmentId, customerId, type, color, quantity, dispatched) 
                        VALUES('" & txtGarmentId.Text & "','" & txtCustomerId.Text & "','" & txtType.Text & "','" & txtQuantity.Text & "','" & cmbDispatched.Text & "')"
        SaveData(sqlQuery)
        ClearScreen(pnlGarment)
        ReloadTable(sqlQueryRld, dgvGarment)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ClearScreen(pnlGarment)

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        ' open the database in order to save the updated data into it
        sqlConnection.Open()
        sqlCommand.Connection = sqlConnection

        With sqlCommand

            ' statement to gather the updated data and manipulate the database
            .CommandText = "UPDATE garments SET garmentId = @garmentId, customerId = @customerId, 
                               type = @type, color = @color, quantity = @quantity, dispatched = @dispatched WHERE garmentId = @garmentId"

            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@garmentId", txtGarmentId.Text)
            .Parameters.AddWithValue("@customerId", txtCustomerId.Text)
            .Parameters.AddWithValue("@type", txtType.Text)
            .Parameters.AddWithValue("@color", txtType.Text)
            .Parameters.AddWithValue("@quantity", txtQuantity.Text)
            .Parameters.AddWithValue("@dispatched", cmbDispatched.Text)

        End With

        ' execute the update query
        sqlCommand.ExecuteNonQuery()
        sqlConnection.Close()
        ClearScreen(pnlGarment)
        ReloadTable(sqlQueryRld, dgvGarment)

    End Sub

    Private Sub dgvGarment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGarment.CellClick

        ' populate the data clicked from the datagridview into the textBoxes
        Try
            txtGarmentId.Text = dgvGarment.SelectedRows(0).Cells(0).Value.ToString
            txtCustomerId.Text = dgvGarment.SelectedRows(0).Cells(1).Value.ToString
            txtType.Text = dgvGarment.SelectedRows(0).Cells(2).Value.ToString
            txtType.Text = dgvGarment.SelectedRows(0).Cells(3).Value.ToString
            txtQuantity.Text = dgvGarment.SelectedRows(0).Cells(4).Value.ToString
            cmbDispatched.Text = dgvGarment.SelectedRows(0).Cells(5).Value.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        ' when the delete button is clicked, execute the following line of code
        sqlQuery = "DELETE FROM `garments` WHERE `garmentId` LIKE '%" & txtGarmentId.Text & "%'"

        DeleteData(sqlQuery, "garments")
        ClearScreen(pnlGarment)
        ReloadTable(sqlQueryRld, dgvGarment)

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        sqlDataAdapter = New MySqlDataAdapter("SELECT `garmentId` as `Garment ID`, `customerId` as `Customer ID`, `type` as `Type`, `color` as `Color`, `quantity` as `Quantity`, `dispatched` as `Dispatched` FROM `garments` WHERE `garmentId` LIKE '%" & txtSearch.Text & "%'", sqlConnection)
        sqlDataset = New DataSet
        sqlDataAdapter.Fill(sqlDataset, "garments")
        dgvGarment.DataSource = sqlDataset.Tables(0)

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'when the back button is clicked, remove the form from focus
        Me.Close()
    End Sub
End Class