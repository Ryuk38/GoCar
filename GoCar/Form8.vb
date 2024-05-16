Imports MySql.Data.MySqlClient

Public Class Form8

    Dim connectionString As String = "server=localhost;userid=root;password=12345;database=gocars"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Perform validation before registering the admin
        If ValidateInputs() Then
            ' If validation passes, proceed with registration
            RegisterAdmin()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Clear the form fields
        ResetForm()
    End Sub

    Private Function ValidateInputs() As Boolean
        ' Check if username field is empty
        If TextBox1.Text.Trim() = "" Then
            MessageBox.Show("Please enter a username.")
            Return False
        End If

        ' Check if password field is empty
        If TextBox2.Text.Trim() = "" Then
            MessageBox.Show("Please enter a password.")
            Return False
        End If

        ' Validation passed
        Return True
    End Function

    Private Sub RegisterAdmin()
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text.Trim()

        ' Query to insert admin data into the database
        Dim query As String = "INSERT INTO Admins (username, password) VALUES (@username, @password)"

        ' Create a MySqlConnection object
        Using connection As New MySqlConnection(connectionString)
            ' Open the database connection
            connection.Open()

            ' Create a MySqlCommand object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@password", password)

                Try
                    ' Execute the query
                    command.ExecuteNonQuery()

                    ' Show success message
                    MessageBox.Show("Admin registered successfully!")

                    ' Reset the form
                    ResetForm()
                Catch ex As MySqlException
                    ' Check if the error code indicates a duplicate entry
                    If ex.Number = 1062 Then
                        MessageBox.Show("Username already exists. Please choose a different username.")
                    Else
                        MessageBox.Show("Error occurred while registering admin: " & ex.Message)
                    End If
                End Try
            End Using
        End Using
    End Sub

    Private Sub ResetForm()
        ' Clear all text boxes
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class

