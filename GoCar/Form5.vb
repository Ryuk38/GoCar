Imports MySql.Data.MySqlClient

Public Class Form5
    Dim connectionString As String = "server=localhost;userid=root;password=12345;database=gocars"
    Dim loadingData As Boolean = False ' Flag to indicate if data is being loaded into the DataGridView
    Private selectedBookingId As Integer = -1 ' Variable to hold the selected booking ID

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load data into ComboBoxes
        LoadCustomerIDs()
        LoadVehicleIDs()

        ' Load data into DataGridView
        loadingData = True ' Set flag to True before loading data
        LoadData()
        loadingData = False ' Set flag to False after loading data
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Public Sub LoadCustomerIDs()
        ' Clear existing items in ComboBox1
        ComboBox1.Items.Clear()

        ' Query to select all customer IDs from the Customers table
        Dim query As String = "SELECT customer_id FROM Customers"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                Try
                    ' Execute the query and read the results
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        ' Add customer IDs to ComboBox1
                        While reader.Read()
                            ComboBox1.Items.Add(reader.GetInt32("customer_id"))
                        End While
                    End Using
                Catch ex As Exception
                    ' Log any exceptions
                    MessageBox.Show("Error loading customer IDs: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Sub LoadVehicleIDs()
        ' Clear existing items in ComboBox2
        ComboBox2.Items.Clear()

        ' Query to select available vehicle IDs from the Vehicles table
        Dim query As String = "SELECT vehicle_id FROM Vehicles WHERE vehicle_id NOT IN (SELECT vehicle_id FROM Bookings)"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                Try
                    ' Execute the query and read the results
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        ' Add vehicle IDs to ComboBox2
                        While reader.Read()
                            ComboBox2.Items.Add(reader.GetInt32("vehicle_id"))
                        End While
                    End Using
                Catch ex As Exception
                    ' Log any exceptions
                    MessageBox.Show("Error loading vehicle IDs: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Insert a new booking record
        If ComboBox1.SelectedItem Is Nothing Or ComboBox2.SelectedItem Is Nothing Or TextBox4.Text = "" Then
            MessageBox.Show("Details incomplete")
            Return
        End If

        Dim customerId As Integer = CInt(ComboBox1.SelectedItem)
        Dim vehicleId As Integer = CInt(ComboBox2.SelectedItem)
        Dim totalPrice As Decimal
        If Not Decimal.TryParse(TextBox4.Text, totalPrice) Then
            MessageBox.Show("Invalid Total Price")
            Return
        End If

        ' Insert query to add a new booking record with today's date
        Dim query As String = "INSERT INTO Bookings (customer_id, vehicle_id, total_price, booking_date) VALUES (@customerId, @vehicleId, @totalPrice, CURDATE())"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@customerId", customerId)
                command.Parameters.AddWithValue("@vehicleId", vehicleId)
                command.Parameters.AddWithValue("@totalPrice", totalPrice)

                Try
                    ' Execute the query
                    command.ExecuteNonQuery()

                    ' Show success message
                    MessageBox.Show("Booking added successfully")

                    LoadCustomerIDs()
                    LoadVehicleIDs()

                    ' Refresh DataGridView
                    LoadData()
                    Form6.LoadBookingIDs()

                    ' Reset the form
                    ResetForm()

                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Update an existing booking record
        If selectedBookingId = -1 Or ComboBox1.SelectedItem Is Nothing Or ComboBox2.SelectedItem Is Nothing Or TextBox4.Text = "" Then
            MessageBox.Show("Details incomplete")
            Return
        End If

        ' Get the values from the ComboBoxes and TextBox
        Dim customerId As Integer = CInt(ComboBox1.SelectedItem)
        Dim vehicleId As Integer = CInt(ComboBox2.SelectedItem)
        Dim totalPrice As Decimal
        If Not Decimal.TryParse(TextBox4.Text, totalPrice) Then
            MessageBox.Show("Invalid Total Price")
            Return
        End If

        ' Update query to modify an existing booking record
        Dim query = "UPDATE Bookings SET customer_id = @customerId, vehicle_id = @vehicleId, total_price = @totalPrice WHERE booking_id = @bookingId"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@customerId", customerId)
                command.Parameters.AddWithValue("@vehicleId", vehicleId)
                command.Parameters.AddWithValue("@totalPrice", totalPrice)
                command.Parameters.AddWithValue("@bookingId", selectedBookingId)

                Try
                    ' Execute the query
                    command.ExecuteNonQuery()

                    ' Show success message
                    MessageBox.Show("Booking updated successfully")
                    Form6.LoadBookingIDs()

                    ' Refresh DataGridView
                    LoadData()

                    ' Reset the form
                    ResetForm()

                Catch ex As MySqlException
                    ' Check if the exception is a primary key violation
                    If ex.Number = 1062 Then
                        MessageBox.Show("Error: A booking with the same ID already exists.")
                    Else
                        MessageBox.Show("Error: " & ex.Message)
                    End If
                End Try
            End Using
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Delete an existing booking record
        If selectedBookingId = -1 Then
            MessageBox.Show("Please select a booking.")
            Return
        End If

        ' Delete query to remove the booking record
        Dim deleteQuery As String = "DELETE FROM Bookings WHERE booking_id = @bookingId"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the delete query and connection
            Using command As New MySqlCommand(deleteQuery, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@bookingId", selectedBookingId)

                Try
                    ' Execute the delete query
                    command.ExecuteNonQuery()

                    ' Show success message
                    MessageBox.Show("Booking deleted successfully")

                    ' Refresh DataGridView
                    LoadData()
                    Form6.LoadBookingIDs()

                    ' Reset the form
                    ResetForm()

                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ResetForm()
        ' Clear all ComboBoxes and TextBox
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        TextBox4.Text = ""
        selectedBookingId = -1
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        ' Only allow numeric input, decimal point, and backspace for Total Price TextBox
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If

        ' Allow only one decimal point
        If e.KeyChar = "." AndAlso (sender.Text.Contains(".") Or sender.Text = "") Then
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Check if the click is on a valid cell
        If e.RowIndex >= 0 AndAlso e.RowIndex < DataGridView1.Rows.Count Then
            ' Get the selected row
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            ' Populate the ComboBoxes and TextBoxes with the values of the selected row
            ComboBox1.SelectedItem = row.Cells("customer_id").Value
            TextBox4.Text = row.Cells("total_price").Value.ToString()

            ' Retrieve the vehicle ID of the selected row
            Dim selectedVehicleId As Integer = Convert.ToInt32(row.Cells("vehicle_id").Value)

            ' Check if the selected vehicle ID exists in the ComboBox items
            If ComboBox2.Items.Contains(selectedVehicleId) Then
                ' If the selected vehicle ID is in the ComboBox items, set it as the selected item
                ComboBox2.SelectedItem = selectedVehicleId
            Else
                ' If the selected vehicle ID is not in the ComboBox items, add it to the ComboBox items and select it
                ComboBox2.Items.Add(selectedVehicleId)
                ComboBox2.SelectedItem = selectedVehicleId
            End If

            ' Retrieve the booking ID of the selected row
            selectedBookingId = Convert.ToInt32(row.Cells("booking_id").Value)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Call the ResetForm method
        ResetForm()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form2.Show()
        Me.Hide()
    End Sub
    Private Sub LoadData()
        ' SQL query to retrieve booking data
        Dim query As String = "SELECT * FROM Bookings"

        ' Create a DataTable to hold the data
        Dim dataTable As New DataTable()

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Execute the query and fill the DataTable
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dataTable)
                End Using
            End Using
        End Using

        ' Remove the booking_order column if it exists
        If dataTable.Columns.Contains("booking_order") Then
            dataTable.Columns.Remove("booking_order")
        End If

        ' Bind the DataTable to the DataGridView
        DataGridView1.DataSource = dataTable
    End Sub

End Class
