Imports MySql.Data.MySqlClient

Public Class Form6
    Dim connectionString As String = "server=localhost;userid=root;password=12345;database=gocars"

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPaymentData()
        LoadBookingIDs()
        ComboBox2.Items.AddRange({"Cash", "Credit Card", "Debit Card", "Bank Transfer"}) ' Add payment methods to ComboBox2
        Me.WindowState = FormWindowState.Maximized
        Dim currentDate As Date = Date.Today
        DateTimePicker1.MinDate = currentDate
        DateTimePicker1.MaxDate = currentDate
        DateTimePicker1.Value = currentDate
    End Sub

    Public Sub LoadBookingIDs()
        ' Clear existing items in ComboBox1
        ComboBox1.Items.Clear()

        ' Query to select all booking IDs from the Bookings table
        Dim query As String = "SELECT booking_id FROM Bookings"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                Try
                    ' Execute the query and read the results
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        ' Add booking IDs to ComboBox1
                        While reader.Read()
                            ComboBox1.Items.Add(reader.GetInt32("booking_id"))
                        End While
                    End Using
                Catch ex As Exception
                    ' Log any exceptions
                    MessageBox.Show("Error loading booking IDs: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' When a booking ID is selected, populate TextBox2 with the corresponding amount
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim bookingId As Integer = CInt(ComboBox1.SelectedItem)
            Dim amount As Decimal = GetBookingAmount(bookingId)
            TextBox2.Text = amount.ToString()
        End If
    End Sub

    Private Function GetBookingAmount(bookingId As Integer) As Decimal
        ' Query to select the total price for the given booking ID
        Dim query As String = "SELECT total_price FROM Bookings WHERE booking_id = @bookingId"

        ' Variable to store the amount
        Dim amount As Decimal = 0

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameter for booking ID
                command.Parameters.AddWithValue("@bookingId", bookingId)

                ' Execute the query and read the amount
                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        amount = reader.GetDecimal("total_price")
                    End If
                End Using
            End Using
        End Using

        Return amount
    End Function

    Private Sub LoadPaymentData()
        ' SQL query to retrieve payment data
        Dim query As String = "SELECT * FROM Payments"

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

        ' Bind the DataTable to the DataGridView
        DataGridView1.DataSource = dataTable
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Get the values from the controls
        Dim bookingId As Integer = If(ComboBox1.SelectedItem IsNot Nothing, CInt(ComboBox1.SelectedItem), -1)
        Dim amount As Decimal = Decimal.Parse(TextBox2.Text)
        Dim paymentMethod As String = If(ComboBox2.SelectedItem IsNot Nothing, ComboBox2.SelectedItem.ToString(), "")
        Dim paymentDate As Date = DateTimePicker1.Value ' Get the selected date from DateTimePicker
        Dim paymentStatus As String = "Confirmed"

        ' Validate payment date
        If paymentDate.Date < Date.Today Then
            MessageBox.Show("Payment date cannot be before the current date.")
            Return
        End If
        If ComboBox2.SelectedText = "" Then
            MessageBox.Show("details incomplete")
        End If

        ' Generate a new payment ID
        Dim paymentId As Integer = GeneratePaymentId()

        ' Insert query to add a new payment record
        Dim query As String = "INSERT INTO Payments (payment_id, booking_id, amount, payment_method, payment_date, payment_status) VALUES (@paymentId, @bookingId, @amount, @paymentMethod, @paymentDate, @paymentStatus)"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@paymentId", paymentId)
                command.Parameters.AddWithValue("@bookingId", bookingId)
                command.Parameters.AddWithValue("@amount", amount)
                command.Parameters.AddWithValue("@paymentMethod", paymentMethod)
                command.Parameters.AddWithValue("@paymentDate", paymentDate)
                command.Parameters.AddWithValue("@paymentStatus", paymentStatus)

                Try
                    ' Execute the query
                    command.ExecuteNonQuery()

                    ' Show success message
                    MessageBox.Show("Payment added successfully")

                    ' Reset the form
                    ResetForm()

                    ' Reload and display payment data in DataGridView
                    LoadPaymentData()

                Catch ex As MySqlException
                    ' Check if the exception is a primary key violation
                    If ex.Number = 1062 Then
                        MessageBox.Show("Error: A payment with the same ID already exists.")
                    Else
                        MessageBox.Show("Error: " & ex.Message)
                    End If
                End Try
            End Using
        End Using

    End Sub

    Private Function GeneratePaymentId() As Integer
        ' Query to get the maximum payment ID from the Payments table
        Dim query As String = "SELECT MAX(payment_id) FROM Payments"

        ' Variable to store the new payment ID
        Dim newPaymentId As Integer = 1

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Execute the query and get the maximum payment ID
                Dim result = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    newPaymentId = Convert.ToInt32(result) + 1
                End If
            End Using
        End Using

        Return newPaymentId
    End Function

    Private Sub ResetForm()
        ' Clear all controls
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1

        TextBox2.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.Show()
        Me.Hide()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Reset the form
        ResetForm()
    End Sub
End Class
