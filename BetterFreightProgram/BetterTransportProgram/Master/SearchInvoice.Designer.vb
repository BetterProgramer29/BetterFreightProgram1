<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchInvoice
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing as Boolean)
        Try
            If disposing andalso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components as System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle4 as System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 as System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 as System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.MetroComboBox1 = New MetroFramework.Controls.MetroComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MetroDateTime2 = New MetroFramework.Controls.MetroDateTime()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MetroDateTime1 = New MetroFramework.Controls.MetroDateTime()
        Me.txtSearchInvoice = New MetroFramework.Controls.MetroTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchCustomer = New MetroFramework.Controls.MetroTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSearchBLNo = New MetroFramework.Controls.MetroTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSearchBooking = New MetroFramework.Controls.MetroTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearchJob = New MetroFramework.Controls.MetroTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtIdent = New MetroFramework.Controls.MetroTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvRV = New MetroFramework.Controls.MetroGrid()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvRV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.add(Me.MetroComboBox1)
        Me.GroupBox3.Controls.add(Me.Label8)
        Me.GroupBox3.Controls.add(Me.Label7)
        Me.GroupBox3.Controls.add(Me.MetroDateTime2)
        Me.GroupBox3.Controls.add(Me.Label6)
        Me.GroupBox3.Controls.add(Me.MetroDateTime1)
        Me.GroupBox3.Controls.add(Me.txtSearchInvoice)
        Me.GroupBox3.Controls.add(Me.Label1)
        Me.GroupBox3.Controls.add(Me.txtSearchCustomer)
        Me.GroupBox3.Controls.add(Me.Label5)
        Me.GroupBox3.Controls.add(Me.txtSearchBLNo)
        Me.GroupBox3.Controls.add(Me.Label4)
        Me.GroupBox3.Controls.add(Me.txtSearchBooking)
        Me.GroupBox3.Controls.add(Me.Label2)
        Me.GroupBox3.Controls.add(Me.txtSearchJob)
        Me.GroupBox3.Controls.add(Me.Button2)
        Me.GroupBox3.Controls.add(Me.txtIdent)
        Me.GroupBox3.Controls.add(Me.Label3)
        Me.GroupBox3.Controls.add(Me.dgvRV)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 1)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(1443, 726)
        Me.GroupBox3.TabIndex = 94
        Me.GroupBox3.TabStop = False
        '
        'MetroComboBox1
        '
        Me.MetroComboBox1.FormattingEnabled = True
        Me.MetroComboBox1.ItemHeight = 23
        Me.MetroComboBox1.Items.addRange(New Object() {"ค้างแจ้งหนี้", "แจ้งหนี้แล้ว"})
        Me.MetroComboBox1.Location = New System.Drawing.Point(631, 674)
        Me.MetroComboBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MetroComboBox1.Name = "MetroComboBox1"
        Me.MetroComboBox1.Size = New System.Drawing.Size(118, 29)
        Me.MetroComboBox1.TabIndex = 194
        Me.MetroComboBox1.UseSelectable = True
        Me.MetroComboBox1.Visible = False
        '
        'Label8
        '
        Me.Label8.autoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(470, 682)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 17)
        Me.Label8.TabIndex = 193
        Me.Label8.Text = "สถานะใบแจ้งหนี้"
        Me.Label8.Visible = False
        '
        'Label7
        '
        Me.Label7.autoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(256, 682)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 17)
        Me.Label7.TabIndex = 183
        Me.Label7.Text = "Date to"
        Me.Label7.Visible = False
        '
        'MetroDateTime2
        '
        Me.MetroDateTime2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MetroDateTime2.Location = New System.Drawing.Point(345, 674)
        Me.MetroDateTime2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MetroDateTime2.MinimumSize = New System.Drawing.Size(0, 29)
        Me.MetroDateTime2.Name = "MetroDateTime2"
        Me.MetroDateTime2.Size = New System.Drawing.Size(118, 29)
        Me.MetroDateTime2.TabIndex = 182
        Me.MetroDateTime2.Visible = False
        '
        'Label6
        '
        Me.Label6.autoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 682)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 17)
        Me.Label6.TabIndex = 181
        Me.Label6.Text = "Date from"
        Me.Label6.Visible = False
        '
        'MetroDateTime1
        '
        Me.MetroDateTime1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MetroDateTime1.Location = New System.Drawing.Point(134, 674)
        Me.MetroDateTime1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MetroDateTime1.MinimumSize = New System.Drawing.Size(0, 29)
        Me.MetroDateTime1.Name = "MetroDateTime1"
        Me.MetroDateTime1.Size = New System.Drawing.Size(118, 29)
        Me.MetroDateTime1.TabIndex = 180
        Me.MetroDateTime1.Visible = False
        '
        'txtSearchInvoice
        '
        Me.txtSearchInvoice.BackColor = System.Drawing.SystemColors.ButtonFace
        '
        '
        '
        Me.txtSearchInvoice.CustomButton.Image = Nothing'Nothing
        Me.txtSearchInvoice.CustomButton.Location = New System.Drawing.Point(71, 2)
        Me.txtSearchInvoice.CustomButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSearchInvoice.CustomButton.Name = ""
        Me.txtSearchInvoice.CustomButton.Size = New System.Drawing.Size(14, 15)
        Me.txtSearchInvoice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSearchInvoice.CustomButton.TabIndex = 1
        Me.txtSearchInvoice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtSearchInvoice.CustomButton.UseSelectable = True
        Me.txtSearchInvoice.CustomButton.Visible = False
        Me.txtSearchInvoice.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtSearchInvoice.Lines = New String(-1) {}
        Me.txtSearchInvoice.Location = New System.Drawing.Point(134, 640)
        Me.txtSearchInvoice.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSearchInvoice.MaxLength = 32767
        Me.txtSearchInvoice.Multiline = True
        Me.txtSearchInvoice.Name = "txtSearchInvoice"
        Me.txtSearchInvoice.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearchInvoice.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSearchInvoice.SelectedText = ""
        Me.txtSearchInvoice.SelectionLength = 0
        Me.txtSearchInvoice.SelectionStart = 0
        Me.txtSearchInvoice.Size = New System.Drawing.Size(117, 24)
        Me.txtSearchInvoice.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSearchInvoice.TabIndex = 179
        Me.txtSearchInvoice.UseCustomBackColor = True
        Me.txtSearchInvoice.UseSelectable = True
        Me.txtSearchInvoice.UseStyleColors = True
        Me.txtSearchInvoice.Visible = False
        Me.txtSearchInvoice.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtSearchInvoice.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label1
        '
        Me.Label1.autoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 650)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 17)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "Search Invoice"
        Me.Label1.Visible = False
        '
        'txtSearchCustomer
        '
        Me.txtSearchCustomer.BackColor = System.Drawing.SystemColors.ButtonFace
        '
        '
        '
        Me.txtSearchCustomer.CustomButton.Image = Nothing'Nothing
        Me.txtSearchCustomer.CustomButton.Location = New System.Drawing.Point(71, 2)
        Me.txtSearchCustomer.CustomButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSearchCustomer.CustomButton.Name = ""
        Me.txtSearchCustomer.CustomButton.Size = New System.Drawing.Size(14, 15)
        Me.txtSearchCustomer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSearchCustomer.CustomButton.TabIndex = 1
        Me.txtSearchCustomer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtSearchCustomer.CustomButton.UseSelectable = True
        Me.txtSearchCustomer.CustomButton.Visible = False
        Me.txtSearchCustomer.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtSearchCustomer.Lines = New String(-1) {}
        Me.txtSearchCustomer.Location = New System.Drawing.Point(1107, 642)
        Me.txtSearchCustomer.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSearchCustomer.MaxLength = 32767
        Me.txtSearchCustomer.Multiline = True
        Me.txtSearchCustomer.Name = "txtSearchCustomer"
        Me.txtSearchCustomer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearchCustomer.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSearchCustomer.SelectedText = ""
        Me.txtSearchCustomer.SelectionLength = 0
        Me.txtSearchCustomer.SelectionStart = 0
        Me.txtSearchCustomer.Size = New System.Drawing.Size(117, 24)
        Me.txtSearchCustomer.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSearchCustomer.TabIndex = 177
        Me.txtSearchCustomer.UseCustomBackColor = True
        Me.txtSearchCustomer.UseSelectable = True
        Me.txtSearchCustomer.UseStyleColors = True
        Me.txtSearchCustomer.Visible = False
        Me.txtSearchCustomer.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtSearchCustomer.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label5
        '
        Me.Label5.autoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(986, 648)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 17)
        Me.Label5.TabIndex = 176
        Me.Label5.Text = "Search Customer"
        Me.Label5.Visible = False
        '
        'txtSearchBLNo
        '
        Me.txtSearchBLNo.BackColor = System.Drawing.SystemColors.ButtonFace
        '
        '
        '
        Me.txtSearchBLNo.CustomButton.Image = Nothing'Nothing
        Me.txtSearchBLNo.CustomButton.Location = New System.Drawing.Point(71, 2)
        Me.txtSearchBLNo.CustomButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSearchBLNo.CustomButton.Name = ""
        Me.txtSearchBLNo.CustomButton.Size = New System.Drawing.Size(14, 15)
        Me.txtSearchBLNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSearchBLNo.CustomButton.TabIndex = 1
        Me.txtSearchBLNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtSearchBLNo.CustomButton.UseSelectable = True
        Me.txtSearchBLNo.CustomButton.Visible = False
        Me.txtSearchBLNo.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtSearchBLNo.Lines = New String(-1) {}
        Me.txtSearchBLNo.Location = New System.Drawing.Point(860, 642)
        Me.txtSearchBLNo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSearchBLNo.MaxLength = 32767
        Me.txtSearchBLNo.Multiline = True
        Me.txtSearchBLNo.Name = "txtSearchBLNo"
        Me.txtSearchBLNo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearchBLNo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSearchBLNo.SelectedText = ""
        Me.txtSearchBLNo.SelectionLength = 0
        Me.txtSearchBLNo.SelectionStart = 0
        Me.txtSearchBLNo.Size = New System.Drawing.Size(117, 24)
        Me.txtSearchBLNo.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSearchBLNo.TabIndex = 175
        Me.txtSearchBLNo.UseCustomBackColor = True
        Me.txtSearchBLNo.UseSelectable = True
        Me.txtSearchBLNo.UseStyleColors = True
        Me.txtSearchBLNo.Visible = False
        Me.txtSearchBLNo.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtSearchBLNo.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label4
        '
        Me.Label4.autoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(753, 648)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 17)
        Me.Label4.TabIndex = 174
        Me.Label4.Text = "Search B/L No"
        Me.Label4.Visible = False
        '
        'txtSearchBooking
        '
        Me.txtSearchBooking.BackColor = System.Drawing.SystemColors.ButtonFace
        '
        '
        '
        Me.txtSearchBooking.CustomButton.Image = Nothing'Nothing
        Me.txtSearchBooking.CustomButton.Location = New System.Drawing.Point(71, 2)
        Me.txtSearchBooking.CustomButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSearchBooking.CustomButton.Name = ""
        Me.txtSearchBooking.CustomButton.Size = New System.Drawing.Size(14, 15)
        Me.txtSearchBooking.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSearchBooking.CustomButton.TabIndex = 1
        Me.txtSearchBooking.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtSearchBooking.CustomButton.UseSelectable = True
        Me.txtSearchBooking.CustomButton.Visible = False
        Me.txtSearchBooking.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtSearchBooking.Lines = New String(-1) {}
        Me.txtSearchBooking.Location = New System.Drawing.Point(631, 642)
        Me.txtSearchBooking.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSearchBooking.MaxLength = 32767
        Me.txtSearchBooking.Multiline = True
        Me.txtSearchBooking.Name = "txtSearchBooking"
        Me.txtSearchBooking.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearchBooking.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSearchBooking.SelectedText = ""
        Me.txtSearchBooking.SelectionLength = 0
        Me.txtSearchBooking.SelectionStart = 0
        Me.txtSearchBooking.Size = New System.Drawing.Size(117, 24)
        Me.txtSearchBooking.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSearchBooking.TabIndex = 173
        Me.txtSearchBooking.UseCustomBackColor = True
        Me.txtSearchBooking.UseSelectable = True
        Me.txtSearchBooking.UseStyleColors = True
        Me.txtSearchBooking.Visible = False
        Me.txtSearchBooking.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtSearchBooking.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label2
        '
        Me.Label2.autoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(470, 648)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 17)
        Me.Label2.TabIndex = 172
        Me.Label2.Text = "Search Vessel Booking"
        Me.Label2.Visible = False
        '
        'txtSearchJob
        '
        Me.txtSearchJob.BackColor = System.Drawing.SystemColors.ButtonFace
        '
        '
        '
        Me.txtSearchJob.CustomButton.Image = Nothing'Nothing
        Me.txtSearchJob.CustomButton.Location = New System.Drawing.Point(71, 2)
        Me.txtSearchJob.CustomButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSearchJob.CustomButton.Name = ""
        Me.txtSearchJob.CustomButton.Size = New System.Drawing.Size(14, 15)
        Me.txtSearchJob.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSearchJob.CustomButton.TabIndex = 1
        Me.txtSearchJob.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtSearchJob.CustomButton.UseSelectable = True
        Me.txtSearchJob.CustomButton.Visible = False
        Me.txtSearchJob.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtSearchJob.Lines = New String(-1) {}
        Me.txtSearchJob.Location = New System.Drawing.Point(345, 642)
        Me.txtSearchJob.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSearchJob.MaxLength = 32767
        Me.txtSearchJob.Multiline = True
        Me.txtSearchJob.Name = "txtSearchJob"
        Me.txtSearchJob.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearchJob.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSearchJob.SelectedText = ""
        Me.txtSearchJob.SelectionLength = 0
        Me.txtSearchJob.SelectionStart = 0
        Me.txtSearchJob.Size = New System.Drawing.Size(117, 24)
        Me.txtSearchJob.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSearchJob.TabIndex = 169
        Me.txtSearchJob.UseCustomBackColor = True
        Me.txtSearchJob.UseSelectable = True
        Me.txtSearchJob.UseStyleColors = True
        Me.txtSearchJob.Visible = False
        Me.txtSearchJob.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtSearchJob.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(4, 17)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 40)
        Me.Button2.TabIndex = 167
        Me.Button2.Text = "Search Job"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtIdent
        '
        Me.txtIdent.BackColor = System.Drawing.SystemColors.ButtonFace
        '
        '
        '
        Me.txtIdent.CustomButton.Image = Nothing'Nothing
        Me.txtIdent.CustomButton.Location = New System.Drawing.Point(12, 2)
        Me.txtIdent.CustomButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtIdent.CustomButton.Name = ""
        Me.txtIdent.CustomButton.Size = New System.Drawing.Size(16, 17)
        Me.txtIdent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtIdent.CustomButton.TabIndex = 1
        Me.txtIdent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtIdent.CustomButton.UseSelectable = True
        Me.txtIdent.CustomButton.Visible = False
        Me.txtIdent.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtIdent.Lines = New String(-1) {}
        Me.txtIdent.Location = New System.Drawing.Point(1279, 682)
        Me.txtIdent.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtIdent.MaxLength = 32767
        Me.txtIdent.Multiline = True
        Me.txtIdent.Name = "txtIdent"
        Me.txtIdent.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIdent.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtIdent.SelectedText = ""
        Me.txtIdent.SelectionLength = 0
        Me.txtIdent.SelectionStart = 0
        Me.txtIdent.Size = New System.Drawing.Size(40, 26)
        Me.txtIdent.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtIdent.TabIndex = 165
        Me.txtIdent.UseCustomBackColor = True
        Me.txtIdent.UseSelectable = True
        Me.txtIdent.UseStyleColors = True
        Me.txtIdent.Visible = False
        Me.txtIdent.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtIdent.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label3
        '
        Me.Label3.autoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(256, 648)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "Search Job"
        Me.Label3.Visible = False
        '
        'dgvRV
        '
        Me.dgvRV.allowUserToResizeRows = False
        Me.dgvRV.BackgroundColor = System.Drawing.Color.Fromargb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvRV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvRV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.alignment = System.Windows.Forms.DataGridViewContentalignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Fromargb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Fromargb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRV.ColumnHeadersHeight = 29
        Me.dgvRV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvRV.Columns.addRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Column4, Me.Column3, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column15, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column1, Me.Column2})
        DataGridViewCellStyle5.alignment = System.Windows.Forms.DataGridViewContentalignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Fromargb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Fromargb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Fromargb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Fromargb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRV.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRV.EnableHeadersVisualStyles = False
        Me.dgvRV.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dgvRV.GridColor = System.Drawing.Color.Fromargb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvRV.Location = New System.Drawing.Point(0, 61)
        Me.dgvRV.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dgvRV.Name = "dgvRV"
        Me.dgvRV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.alignment = System.Windows.Forms.DataGridViewContentalignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Fromargb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Fromargb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRV.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRV.RowHeadersVisible = False
        Me.dgvRV.RowHeadersWidth = 51
        Me.dgvRV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvRV.RowTemplate.Height = 24
        Me.dgvRV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRV.Size = New System.Drawing.Size(1439, 652)
        Me.dgvRV.TabIndex = 146
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Ident"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 125
        '
        'Column4
        '
        Me.Column4.HeaderText = "Customer"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 125
        '
        'Column3
        '
        Me.Column3.HeaderText = "InvoiceNo"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 125
        '
        'Column6
        '
        Me.Column6.HeaderText = "JOB NO"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 125
        '
        'Column7
        '
        Me.Column7.HeaderText = "BOOKING NO"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 125
        '
        'Column8
        '
        Me.Column8.HeaderText = "SI CODE"
        Me.Column8.MinimumWidth = 6
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 125
        '
        'Column9
        '
        Me.Column9.HeaderText = "DESCRIPTION"
        Me.Column9.MinimumWidth = 6
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 125
        '
        'Column15
        '
        Me.Column15.HeaderText = "Container"
        Me.Column15.MinimumWidth = 6
        Me.Column15.Name = "Column15"
        Me.Column15.Width = 125
        '
        'Column10
        '
        Me.Column10.HeaderText = "QTY"
        Me.Column10.MinimumWidth = 6
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 125
        '
        'Column11
        '
        Me.Column11.HeaderText = "UNIT"
        Me.Column11.MinimumWidth = 6
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 125
        '
        'Column12
        '
        Me.Column12.HeaderText = "WHT"
        Me.Column12.MinimumWidth = 6
        Me.Column12.Name = "Column12"
        Me.Column12.Width = 125
        '
        'Column13
        '
        Me.Column13.HeaderText = "aDV aMOUNT"
        Me.Column13.MinimumWidth = 6
        Me.Column13.Name = "Column13"
        Me.Column13.Width = 125
        '
        'Column14
        '
        Me.Column14.HeaderText = "CHaRGE aMOUNT"
        Me.Column14.MinimumWidth = 6
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 125
        '
        'Column1
        '
        Me.Column1.HeaderText = "RV No"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 125
        '
        'Column2
        '
        Me.Column2.HeaderText = "Tax No"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 125
        '
        'SearchInvoice
        '
        Me.autoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.autoScaleMode = System.Windows.Forms.autoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1443, 726)
        Me.Controls.add(Me.GroupBox3)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "SearchInvoice"
        Me.Text = "ค้นหาใบแจ้งหนี้"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvRV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox3 as GroupBox
    Friend WithEvents Label2 as Label
    Friend WithEvents txtSearchJob as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Button2 as Button
    Friend WithEvents txtIdent as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label3 as Label
    Friend WithEvents dgvRV as MetroFramework.Controls.MetroGrid
    Friend WithEvents txtSearchInvoice as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label1 as Label
    Friend WithEvents txtSearchCustomer as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label5 as Label
    Friend WithEvents txtSearchBLNo as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label4 as Label
    Friend WithEvents txtSearchBooking as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label7 as Label
    Friend WithEvents MetroDateTime2 as MetroFramework.Controls.MetroDateTime
    Friend WithEvents Label6 as Label
    Friend WithEvents MetroDateTime1 as MetroFramework.Controls.MetroDateTime
    Friend WithEvents MetroComboBox1 as MetroFramework.Controls.MetroComboBox
    Friend WithEvents Label8 as Label
    Friend WithEvents DataGridViewTextBoxColumn1 as DataGridViewTextBoxColumn
    Friend WithEvents Column4 as DataGridViewTextBoxColumn
    Friend WithEvents Column3 as DataGridViewTextBoxColumn
    Friend WithEvents Column6 as DataGridViewTextBoxColumn
    Friend WithEvents Column7 as DataGridViewTextBoxColumn
    Friend WithEvents Column8 as DataGridViewTextBoxColumn
    Friend WithEvents Column9 as DataGridViewTextBoxColumn
    Friend WithEvents Column15 as DataGridViewTextBoxColumn
    Friend WithEvents Column10 as DataGridViewTextBoxColumn
    Friend WithEvents Column11 as DataGridViewTextBoxColumn
    Friend WithEvents Column12 as DataGridViewTextBoxColumn
    Friend WithEvents Column13 as DataGridViewTextBoxColumn
    Friend WithEvents Column14 as DataGridViewTextBoxColumn
    Friend WithEvents Column1 as DataGridViewTextBoxColumn
    Friend WithEvents Column2 as DataGridViewTextBoxColumn
End Class
