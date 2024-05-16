Imports MySql.Data.MySqlClient

Public Class Form1
    ' Connection string to your MySQL database
    Dim connectionString As String = "server=localhost;userid=root;password=12345;database=gocars"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Get the username and password entered by the user
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        ' Validate username and password
        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Error: Please enter both username and password")
            Return
        End If

        If Not IsValidUsername(username) Then
            MessageBox.Show("Error: Only alphabets and spaces are allowed in the username")
            TextBox1.Text = ""
            Return
        End If

        If Not IsValidPassword(password) Then
            MessageBox.Show("Error: Only numbers are allowed in password")
            TextBox2.Text = ""
            Return
        End If

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' SQL query to check if the provided credentials exist in the Admin table
            Dim query As String = "SELECT COUNT(*) FROM Admins WHERE username = @username AND password = @password"

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@password", password)

                ' Execute the scalar query to get the count of matching records
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

                ' Check if a record with the provided credentials exists
                If count > 0 Then
                    MessageBox.Show("Login Successful")
                    ' If credentials are valid, show Form2 and hide Form1
                    Form2.Show()
                    Me.Hide()
                Else
                    ' If credentials are invalid, show error message
                    MessageBox.Show("Invalid credentials")
                End If
            End Using
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Clear the username and password fields
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Validate username input
        Dim input As String = TextBox1.Text
        If Not IsValidUsername(input) Then
            MessageBox.Show("Error: Only alphabets and spaces are allowed in username")
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        ' Validate password input
        Dim input As String = TextBox2.Text
        If Not IsValidPassword(input) Then
            MessageBox.Show("Error: Only numbers are allowed in password")
            TextBox2.Text = ""
        End If
    End Sub

    ' Function to validate username (only alphabets and spaces allowed)
    Private Function IsValidUsername(input As String) As Boolean
        Return input.All(Function(c) Char.IsLetter(c) Or c = " ")
    End Function

    ' Function to validate password (only numbers allowed)
    Private Function IsValidPassword(input As String) As Boolean
        Return input.All(Function(c) Char.IsDigit(c))
    End Function


    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Form8.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class
