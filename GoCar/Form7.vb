Imports MySql.Data.MySqlClient

Public Class Form7

    Dim connectionString As String = "server=localhost;userid=root;password=12345;database=gocars"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Get the selected date from the DateTimePicker
        Dim selectedDate As Date = DateTimePicker1.Value.Date

        ' Validate if the selected date is on or before the system date
        If selectedDate > Date.Today Then
            MessageBox.Show("Please select a date on or before the current system date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Fetch report data based on the selected date
        Dim reportData As DataTable = GenerateReport(selectedDate)

        ' Display the report data in the DataGridView
        DataGridView1.DataSource = reportData
    End Sub

    Private Function GenerateReport(selectedDate As Date) As DataTable
        Dim reportData As New DataTable()

        ' SQL query to retrieve the total booking, total revenue, and vehicle IDs for the selected date
        Dim query As String = "SELECT COUNT(booking_id) AS TotalBooking, SUM(total_price) AS TotalRevenue, GROUP_CONCAT(vehicle_id) AS VehicleIDs FROM Bookings WHERE booking_date = @selectedDate"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameter for selected date
                command.Parameters.AddWithValue("@selectedDate", selectedDate)

                ' Execute the query and fill the DataTable
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(reportData)
                End Using
            End Using
        End Using

        Return reportData
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        ' Set the minimum date of the DateTimePicker to the system date
        DateTimePicker1.MaxDate = Date.Today
    End Sub
End Class
