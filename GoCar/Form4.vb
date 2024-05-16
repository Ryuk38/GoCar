Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class Form4
    ' Connection string to your MySQL database
    Dim connectionString As String = "server=localhost;userid=root;password=12345;database=gocars"

    ' Load event handler for Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        ' Load data into DataGridView
        LoadData()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Check if the clicked cell is not the header row
        If e.RowIndex >= 0 Then
            ' Get the DataGridViewRow corresponding to the clicked cell
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            ' Populate the textboxes with data from the selected row
            TextBox7.Text = selectedRow.Cells("vehicleno").Value.ToString()
            TextBox2.Text = selectedRow.Cells("model").Value.ToString()
            TextBox3.Text = selectedRow.Cells("year").Value.ToString()
            TextBox4.Text = selectedRow.Cells("color").Value.ToString()
            TextBox5.Text = selectedRow.Cells("no_of_owners").Value.ToString()
            TextBox6.Text = selectedRow.Cells("km_ran").Value.ToString()
        End If
    End Sub

    ' Method to load data into DataGridView
    Private Sub LoadData()
        ' SQL query to select all vehicles
        Dim query As String = "SELECT * FROM Vehicles"

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Adding a new vehicle record
        If TextBox7.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MessageBox.Show("Details incomplete")
            Return
        End If

        ' Get the values from the text boxes

        Dim model As String = TextBox2.Text
        Dim year As String = TextBox3.Text

        ' Validate year format (should be exactly 4 digits and only contain digits)
        If Not Regex.IsMatch(year, "^\d{4}$") Then
            MessageBox.Show("Invalid Year. Please enter a 4-digit numeric year.")
            Return
        End If

        Dim color As String = TextBox4.Text
        Dim noOfOwners As Integer
        If Not Integer.TryParse(TextBox5.Text, noOfOwners) Then
            MessageBox.Show("Invalid Number of Owners")
            Return
        End If

        Dim kmRan As Integer
        If Not Integer.TryParse(TextBox6.Text, kmRan) Then
            MessageBox.Show("Invalid Kilometers Ran")
            Return
        End If
        Dim vehicleNo As String = TextBox7.Text

        ' Check if the vehicle number already exists
        If VehicleNumberExists(vehicleNo) Then
            MessageBox.Show("Vehicle number already exists. Please enter a unique vehicle number.")
            Return
        End If

        ' Generate a new vehicle ID
        Dim vehicleID As Integer = GenerateVehicleID()

        ' Insert query to add a new vehicle record
        Dim query As String = "INSERT INTO Vehicles (vehicle_id, vehicleno, model, year, color, no_of_owners, km_ran) VALUES (@vehicleID, @vehicleNo, @model, @year, @color, @noOfOwners, @kmRan)"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@vehicleID", vehicleID)
                command.Parameters.AddWithValue("@vehicleNo", vehicleNo)
                command.Parameters.AddWithValue("@model", model)
                command.Parameters.AddWithValue("@year", year)
                command.Parameters.AddWithValue("@color", color)
                command.Parameters.AddWithValue("@noOfOwners", noOfOwners)
                command.Parameters.AddWithValue("@kmRan", kmRan)

                Try
                    ' Execute the query
                    command.ExecuteNonQuery()

                    ' Show success message
                    MessageBox.Show("Vehicle added successfully")
                    LoadData()
                    Form5.LoadVehicleIDs()

                    ' Reset the form
                    ResetForm()

                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
    ' Method to generate a new Vehicle ID
    ' Method to get the maximum existing Vehicle ID
    Private Function GetMaxVehicleID() As Integer
        ' SQL query to get the maximum existing Vehicle ID
        Dim query As String = "SELECT MAX(vehicle_id) FROM Vehicles"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Execute the query and get the maximum Vehicle ID
                Dim maxID As Object = command.ExecuteScalar()

                ' If there are no existing vehicles, return 0
                If maxID IsNot DBNull.Value Then
                    Return Convert.ToInt32(maxID)
                Else
                    Return 0
                End If
            End Using
        End Using
    End Function


    ' Click event handler for Button2 (Edit Vehicle)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Editing an existing vehicle record
        If TextBox7.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MessageBox.Show("Details incomplete")
            Return
        End If

        ' Get the values from the text boxes
        Dim vehicleNo As String = TextBox7.Text ' Get the edited vehicle number
        Dim model As String = TextBox2.Text
        Dim year As Integer
        If Not Integer.TryParse(TextBox3.Text, year) Then
            MessageBox.Show("Invalid Year")
            Return
        End If

        Dim color As String = TextBox4.Text
        Dim owners As Integer
        If Not Integer.TryParse(TextBox5.Text, owners) Then
            MessageBox.Show("Invalid Number of Owners")
            Return
        End If

        Dim kmRan As Integer
        If Not Integer.TryParse(TextBox6.Text, kmRan) Then
            MessageBox.Show("Invalid KM Ran")
            Return
        End If

        ' Update query to modify an existing vehicle record
        Dim query As String = "UPDATE Vehicles SET vehicleno = @vehicleNo, model = @model, year = @year, color = @color, no_of_owners = @owners, km_ran = @kmRan WHERE vehicle_id = @vehicleID"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@vehicleNo", vehicleNo)
                command.Parameters.AddWithValue("@model", model)
                command.Parameters.AddWithValue("@year", year)
                command.Parameters.AddWithValue("@color", color)
                command.Parameters.AddWithValue("@owners", owners)
                command.Parameters.AddWithValue("@kmRan", kmRan)

                Try
                    ' Execute the query
                    command.ExecuteNonQuery()

                    ' Show success message
                    MessageBox.Show("Vehicle updated successfully")

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


    ' Click event handler for Button3 (Delete Vehicle)
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Check if any row is selected in the DataGridView
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a vehicle to delete.")
            Return
        End If

        ' Get the selected row
        Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

        ' Get the vehicle ID from the selected row
        Dim vehicleID As Integer = Convert.ToInt32(selectedRow.Cells("vehicle_id").Value)

        ' Delete query to remove the selected vehicle record based on vehicle_id
        Dim query As String = "DELETE FROM Vehicles WHERE vehicle_id = @vehicleID"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@vehicleID", vehicleID)

                Try
                    ' Execute the query
                    command.ExecuteNonQuery()

                    ' Show success message
                    MessageBox.Show("Vehicle deleted successfully")

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

    ' Method to reset the form
    Private Sub ResetForm()
        ' Clear all text boxes
        TextBox7.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub

    ' Click event handler for Button5 (Return to Form2)
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ResetForm()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        ' Allow only alphabets in TextBox4
        Dim pattern As String = "^[a-zA-Z\s]*$" ' Regular expression to match alphabets and spaces
        Dim regex As New Regex(pattern)

        If Not regex.IsMatch(TextBox4.Text) Then
            ' If the input does not match the pattern, remove the last character
            TextBox4.Text = TextBox4.Text.Substring(0, TextBox4.Text.Length - 1)
            ' Move the cursor to the end of the TextBox
            TextBox4.SelectionStart = TextBox4.Text.Length
        End If
    End Sub
    Private Function VehicleNumberExists(vehicleNo As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM Vehicles WHERE vehicleno = @vehicleNo"

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@vehicleNo", vehicleNo)
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

                ' If count > 0, vehicle number already exists
                Return count > 0
            End Using
        End Using
    End Function
    ' Method to generate a new Vehicle ID
    Private Function GenerateVehicleID() As Integer
        ' SQL query to get the maximum existing Vehicle ID
        Dim query As String = "SELECT MAX(vehicle_id) FROM Vehicles"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Execute the query and get the maximum Vehicle ID
                Dim maxID As Object = command.ExecuteScalar()

                ' If there are no existing vehicles, set newID to 1
                Dim newID As Integer = If(maxID IsNot DBNull.Value, Convert.ToInt32(maxID) + 1, 1)

                ' Return the new ID
                Return newID
            End Using
        End Using
    End Function

End Class
