<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Label1 = New Label()
        Label6 = New Label()
        Button4 = New Button()
        DataGridView1 = New DataGridView()
        DateTimePicker1 = New DateTimePicker()
        Label2 = New Label()
        Button1 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(558, 23)
        Label1.Margin = New Padding(5, 0, 5, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(204, 41)
        Label1.TabIndex = 0
        Label1.Text = "Report Details"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(20, 947)
        Label6.Margin = New Padding(5, 0, 5, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(81, 31)
        Label6.TabIndex = 5
        Label6.Text = "Label6"
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(1145, 23)
        Button4.Name = "Button4"
        Button4.Size = New Size(145, 50)
        Button4.TabIndex = 13
        Button4.Text = "Dashboard"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(33, 318)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(1257, 470)
        DataGridView1.TabIndex = 14
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(366, 209)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(250, 38)
        DateTimePicker1.TabIndex = 15
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(147, 213)
        Label2.Name = "Label2"
        Label2.Size = New Size(129, 31)
        Label2.TabIndex = 16
        Label2.Text = "Select Date"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(668, 209)
        Button1.Name = "Button1"
        Button1.Size = New Size(115, 38)
        Button1.TabIndex = 17
        Button1.Text = "Display"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Form7
        ' 
        AutoScaleDimensions = New SizeF(13F, 31F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1323, 813)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(DateTimePicker1)
        Controls.Add(DataGridView1)
        Controls.Add(Button4)
        Controls.Add(Label6)
        Controls.Add(Label1)
        DoubleBuffered = True
        Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(5)
        MaximizeBox = False
        Name = "Form7"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Report Id"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
End Class
