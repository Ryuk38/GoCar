Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Form3
    ' Connection string to your MySQL database
    Dim connectionString As String = "server=localhost;userid=root;password=12345;database=gocars"

    ' Load event handler for Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load data into DataGridView
        LoadData()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    ' Method to load data into DataGridView
    Private Sub LoadData()
        ' SQL query to select all customers
        Dim query As String = "SELECT * FROM Customers"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Create a DataTable to store the results
                Dim dataTable As New DataTable()

                ' Create a MySqlDataAdapter to fill the DataTable
                Dim dataAdapter As New MySqlDataAdapter(command)

                ' Fill the DataTable
                dataAdapter.Fill(dataTable)

                ' Bind the DataTable to the DataGridView
                DataGridView1.DataSource = dataTable
            End Using
        End Using
    End Sub

    ' CellClick event handler for DataGridView
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Populate the TextBoxes with the data of the selected customer
            TextBox2.Text = selectedRow.Cells("name").Value.ToString()
            TextBox3.Text = selectedRow.Cells("phone_number").Value.ToString()
            TextBox4.Text = selectedRow.Cells("address").Value.ToString()
        End If
    End Sub

    ' TextChanged event handler for TextBox2 (Name)
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim input As String = TextBox2.Text
        If Not input.All(Function(c) Char.IsLetter(c) Or c = " ") AndAlso Not String.IsNullOrEmpty(input) Then
            MessageBox.Show("Error: Only alphabets are allowed in Name")
            TextBox2.Text = ""
        End If
    End Sub

    ' TextChanged event handler for TextBox3 (Phone Number)
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim input As String = TextBox3.Text
        If Not input.All(Function(c) Char.IsDigit(c)) OrElse input.Length > 10 Then
            MessageBox.Show("Error: Only numbers are allowed in phone no and maximum length is 10")
            TextBox3.Text = ""
        End If
    End Sub

    ' Click event handler for Button1 (Add Customer)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Adding a new customer record
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Details incomplete")
            Return
        End If

        ' Generate a new Customer ID
        Dim customerID As Integer = GenerateCustomerID()

        Dim name As String = TextBox2.Text
        Dim phone As String = TextBox3.Text
        Dim address As String = TextBox4.Text

        ' Insert query to add a new customer record
        Dim query As String = "INSERT INTO Customers (customer_id, name, phone_number, address) VALUES (@customerID, @name, @phone, @address)"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@customerID", customerID)
                command.Parameters.AddWithValue("@name", name)
                command.Parameters.AddWithValue("@phone", phone)
                command.Parameters.AddWithValue("@address", address)

                Try
                    ' Execute the query
                    command.ExecuteNonQuery()

                    ' Show success message
                    MessageBox.Show("Customer added successfully")

                    ' Refresh DataGridView
                    LoadData()

                    ' Reset the form
                    ResetForm()

                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    ' Method to generate a new Customer ID

    ' Click event handler for Button2 (Update Customer)
    ' Click event handler for Button2 (Edit Customer)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Updating an existing customer record
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Details incomplete")
            Return
        End If

        ' Check if a row is selected
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a customer to edit")
            Return
        End If

        ' Get the customer ID from the selected row
        Dim customerId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells(0).Value)

        ' Get the values from the text boxes
        Dim name = TextBox2.Text
        Dim phone = TextBox3.Text
        Dim address = TextBox4.Text

        ' Update query to modify an existing customer record
        Dim query = "UPDATE Customers SET name = @name, phone_number = @phone, address = @address WHERE customer_id = @customerID"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@name", name)
                command.Parameters.AddWithValue("@phone", phone)
                command.Parameters.AddWithValue("@address", address)
                command.Parameters.AddWithValue("@customerID", customerId)

                Try
                    ' Execute the query
                    command.ExecuteNonQuery()

                    ' Show success message
                    MessageBox.Show("Customer updated successfully")

                    ' Refresh DataGridView
                    LoadData()

                    ' Reset the form
                    ResetForm()

                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub


    ' Click event handler for Button3 (Delete Customer)
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Check if a row is selected
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a customer to delete")
            Return
        End If

        ' Get the customer ID from the selected row
        Dim customerId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells(0).Value)

        ' Delete query to remove an existing customer record
        Dim query As String = "DELETE FROM Customers WHERE customer_id = @customerId"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@customerId", customerId)

                Try
                    ' Execute the query
                    command.ExecuteNonQuery()

                    ' Show success message
                    MessageBox.Show("Customer deleted successfully")

                    ' Refresh DataGridView
                    LoadData()

                    ' Reset the form
                    ResetForm()

                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub


    ' Click event handler for Button4 (Reset Form)
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Resetting the form
        ResetForm()
    End Sub

    ' Method to reset the form
    Private Sub ResetForm()
        ' Clear all text boxes
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form2.Show()
        Me.Hide()
    End Sub
    ' Method to generate a new Customer ID
    Private Function GenerateCustomerID() As Integer
        ' SQL query to find the minimum unused ID greater than the deleted ID
        Dim query As String = "SELECT MIN(customer_id) FROM (SELECT customer_id + 1 AS customer_id FROM Customers WHERE NOT EXISTS (SELECT NULL FROM Customers c WHERE c.customer_id = Customers.customer_id + 1)) AS tbl"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Execute the query and get the minimum unused ID
                Dim newID As Object = command.ExecuteScalar()

                ' If there is no unused ID, increment the maximum ID by 1
                If newID IsNot DBNull.Value Then
                    Return Convert.ToInt32(newID)
                Else
                    ' If all IDs are used, increment the maximum ID by 1
                    Return GetMaxCustomerID() + 1
                End If
            End Using
        End Using
    End Function

    ' Method to get the maximum existing Customer ID
    Private Function GetMaxCustomerID() As Integer
        ' SQL query to get the maximum existing Customer ID
        Dim query As String = "SELECT MAX(customer_id) FROM Customers"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Execute the query and get the maximum Customer ID
                Dim maxID As Object = command.ExecuteScalar()

                ' If there are no existing customers, return 0
                If maxID IsNot DBNull.Value Then
                    Return Convert.ToInt32(maxID)
                Else
                    Return 0
                End If
            End Using
        End Using
    End Function

End Class
