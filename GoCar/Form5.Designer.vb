<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Label1 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        TextBox4 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        DataGridView1 = New DataGridView()
        ComboBox1 = New ComboBox()
        ComboBox2 = New ComboBox()
        Button4 = New Button()
        Button3 = New Button()
        Button5 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(520, 45)
        Label1.Name = "Label1"
        Label1.Size = New Size(300, 54)
        Label1.TabIndex = 0
        Label1.Text = "Booking Details"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Verdana", 12F)
        Label3.Location = New Point(105, 302)
        Label3.Name = "Label3"
        Label3.Size = New Size(136, 25)
        Label3.TabIndex = 2
        Label3.Text = "Customer Id"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Verdana", 12F)
        Label4.Location = New Point(105, 357)
        Label4.Name = "Label4"
        Label4.Size = New Size(111, 25)
        Label4.TabIndex = 3
        Label4.Text = "Vehicle Id"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Verdana", 12F)
        Label5.Location = New Point(105, 422)
        Label5.Name = "Label5"
        Label5.Size = New Size(116, 25)
        Label5.TabIndex = 4
        Label5.Text = "Total price"
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Verdana", 12F)
        TextBox4.Location = New Point(307, 419)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(224, 32)
        TextBox4.TabIndex = 8
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Verdana", 12F)
        Button1.Location = New Point(38, 544)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 45)
        Button1.TabIndex = 11
        Button1.Text = "Book"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Verdana", 12F)
        Button2.Location = New Point(185, 544)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 45)
        Button2.TabIndex = 12
        Button2.Text = "Edit"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(637, 183)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(677, 423)
        DataGridView1.TabIndex = 15
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Segoe UI", 12F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(307, 297)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(224, 36)
        ComboBox1.TabIndex = 17
        ' 
        ' ComboBox2
        ' 
        ComboBox2.Font = New Font("Segoe UI", 12F)
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(307, 357)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(224, 36)
        ComboBox2.TabIndex = 18
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Verdana", 12F)
        Button4.Location = New Point(499, 544)
        Button4.Name = "Button4"
        Button4.Size = New Size(94, 45)
        Button4.TabIndex = 19
        Button4.Text = "Reset"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Verdana", 12F)
        Button3.Location = New Point(344, 544)
        Button3.Name = "Button3"
        Button3.Size = New Size(94, 45)
        Button3.TabIndex = 20
        Button3.Text = "Cancel"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Font = New Font("Verdana", 12F)
        Button5.Location = New Point(1220, 12)
        Button5.Name = "Button5"
        Button5.Size = New Size(94, 45)
        Button5.TabIndex = 21
        Button5.Text = "Home"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1335, 805)
        Controls.Add(Button5)
        Controls.Add(Button3)
        Controls.Add(Button4)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        Controls.Add(DataGridView1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(TextBox4)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        MaximizeBox = False
        Name = "Form5"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form5"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button5 As Button
End Class
