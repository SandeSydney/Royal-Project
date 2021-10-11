Imports MySql.Data.MySqlClient

Module DB_Crud

    Public sqlConnection As MySqlConnection = mysqldb()  ' get connection to the database

    ' In order for the form to access and manipulate the database, the following properties have to be declared

    Dim sqlCommand As New MySqlCommand ' for sql commands
    Dim sqlReader As MySqlDataReader ' to read the sql in database
    Dim sqlDataTable As New DataTable   ' table to store data from the sql
    Dim sqlDataAdapter As New MySqlDataAdapter ' data adapter for the sql
    Dim sqlQuery As String  ' variable to hold the sql query
    Dim sqlQueryRld As String  ' variable to hold the sql query to reload datagrid


    Private bitmap As Bitmap    ' property to be used for printing the reports
    Dim sqlDataset As DataSet
    ' the following is a function that will be used to manipulate all the strings to the database
    Sub ReloadTable(sqlQueryRld As String, dataGv As DataGridView)
        ' This code is used to refresh the the data in the datagridview

        ' This part of the code closes the sqlConnection if it is open
        If sqlConnection.State = ConnectionState.Open Then
            sqlConnection.Close()
        End If

        Try
            sqlConnection.Open() ' open the sql connection to the database
            sqlCommand.Connection = sqlConnection   ' get the connection to the db
            sqlDataAdapter = New MySqlDataAdapter(sqlQueryRld, sqlConnection) ' get information from the database and the right table for the form
            sqlDataset = New DataSet
            sqlDataAdapter.Fill(sqlDataset, "garments")
            dataGv.DataSource = sqlDataset.Tables(0)

        Catch ex As Exception
            MsgBox(ex.Message)  ' catch the error message and print it to the screen via a MessageBox
        End Try

        sqlConnection.Close()   ' close the created database connection

    End Sub

    ' function to add data into the database
    Sub SaveData(sqlQuery As String)
        Try
            sqlConnection.Open()
            sqlCommand = New MySqlCommand(sqlQuery, sqlConnection)
            sqlReader = sqlCommand.ExecuteReader
            sqlConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sqlConnection.Dispose()
        End Try
    End Sub

    'function to clear entry screen
    Sub ClearScreen(panelName As Panel)
        Try
            For Each txt In panelName.Controls
                If TypeOf txt Is TextBox Then
                    txt.ResetText()
                ElseIf TypeOf txt Is ComboBox Then
                    txt.ResetText()
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ' function to delete the selected row from the datagridview
    Sub DeleteData(sqlQuery As String, table As String)

        ' confirm with sender whether to delete the selected data
        Dim strDelete = MsgBox("Are you sure To delete?", vbYesNo)

        ' delete if Yes is clicked
        If strDelete = vbYes Then
            sqlDataAdapter = New MySqlDataAdapter(sqlQuery, sqlConnection)
            sqlDataset = New DataSet
            sqlDataAdapter.Fill(sqlDataset, table)
        End If
    End Sub

End Module
