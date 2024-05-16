<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        TextBox4 = New TextBox()
        TextBox5 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Label6 = New Label()
        Label7 = New Label()
        TextBox6 = New TextBox()
        DataGridView1 = New DataGridView()
        Button4 = New Button()
        Button5 = New Button()
        TextBox7 = New TextBox()
        Label8 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(90, 232)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 28)
        Label2.TabIndex = 1
        Label2.Text = "Model"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(90, 291)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 28)
        Label3.TabIndex = 2
        Label3.Text = "Year"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(90, 353)
        Label4.Name = "Label4"
        Label4.Size = New Size(57, 28)
        Label4.TabIndex = 3
        Label4.Text = "color"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(90, 415)
        Label5.Name = "Label5"
        Label5.Size = New Size(121, 28)
        Label5.TabIndex = 4
        Label5.Text = "No of owner"
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 12F)
        TextBox2.Location = New Point(252, 229)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(169, 34)
        TextBox2.TabIndex = 6
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Segoe UI", 12F)
        TextBox3.Location = New Point(249, 291)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(169, 34)
        TextBox3.TabIndex = 7
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Segoe UI", 12F)
        TextBox4.Location = New Point(249, 353)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(169, 34)
        TextBox4.TabIndex = 8
        ' 
        ' TextBox5
        ' 
        TextBox5.Font = New Font("Segoe UI", 12F)
        TextBox5.Location = New Point(249, 415)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(169, 34)
        TextBox5.TabIndex = 9
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.Location = New Point(28, 619)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 42)
        Button1.TabIndex = 10
        Button1.Text = "Add"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 12F)
        Button2.Location = New Point(168, 619)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 42)
        Button2.TabIndex = 11
        Button2.Text = "Edit"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Segoe UI", 12F)
        Button3.Location = New Point(321, 619)
        Button3.Name = "Button3"
        Button3.Size = New Size(94, 42)
        Button3.TabIndex = 12
        Button3.Text = "Delete"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.ButtonFace
        Label6.Location = New Point(552, 27)
        Label6.Name = "Label6"
        Label6.Size = New Size(222, 41)
        Label6.TabIndex = 13
        Label6.Text = "Vehicles Details"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F)
        Label7.Location = New Point(90, 477)
        Label7.Name = "Label7"
        Label7.Size = New Size(79, 28)
        Label7.TabIndex = 14
        Label7.Text = "Km Ran"
        ' 
        ' TextBox6
        ' 
        TextBox6.Font = New Font("Segoe UI", 12F)
        TextBox6.Location = New Point(249, 477)
        TextBox6.Name = "TextBox6"
        TextBox6.Size = New Size(172, 34)
        TextBox6.TabIndex = 15
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(645, 128)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(701, 427)
        DataGridView1.TabIndex = 17
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Segoe UI", 12F)
        Button4.Location = New Point(484, 619)
        Button4.Name = "Button4"
        Button4.Size = New Size(94, 42)
        Button4.TabIndex = 18
        Button4.Text = "Reset"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(1240, 27)
        Button5.Name = "Button5"
        Button5.Size = New Size(94, 29)
        Button5.TabIndex = 19
        Button5.Text = "Dashboard"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' TextBox7
        ' 
        TextBox7.Font = New Font("Segoe UI", 12F)
        TextBox7.Location = New Point(246, 171)
        TextBox7.Name = "TextBox7"
        TextBox7.Size = New Size(172, 34)
        TextBox7.TabIndex = 23
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F)
        Label8.Location = New Point(90, 177)
        Label8.Name = "Label8"
        Label8.Size = New Size(105, 28)
        Label8.TabIndex = 22
        Label8.Text = "Vehicle No"
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1410, 783)
        Controls.Add(TextBox7)
        Controls.Add(Label8)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(DataGridView1)
        Controls.Add(TextBox6)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(TextBox5)
        Controls.Add(TextBox4)
        Controls.Add(TextBox3)
        Controls.Add(TextBox2)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Form4"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form4"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label8 As Label
End Class
