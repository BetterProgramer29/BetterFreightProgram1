<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SICODE
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtIdent = New MetroFramework.Controls.MetroTextBox()
        Me.dgvSICode = New MetroFramework.Controls.MetroGrid()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtaccountControl = New MetroFramework.Controls.MetroTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtaccountName = New MetroFramework.Controls.MetroTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtaccountGroup = New MetroFramework.Controls.MetroTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtaccountNo = New MetroFramework.Controls.MetroTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSICode = New MetroFramework.Controls.MetroTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtItemName = New MetroFramework.Controls.MetroTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cboSIGroup = New MetroFramework.Controls.MetroComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.dgvSICode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtIdent
        '
        Me.txtIdent.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtIdent.CustomButton.Image = Nothing
        Me.txtIdent.CustomButton.Location = New System.Drawing.Point(22, 2)
        Me.txtIdent.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIdent.CustomButton.Name = ""
        Me.txtIdent.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtIdent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtIdent.CustomButton.TabIndex = 1
        Me.txtIdent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtIdent.CustomButton.UseSelectable = True
        Me.txtIdent.CustomButton.Visible = False
        Me.txtIdent.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtIdent.Lines = New String(-1) {}
        Me.txtIdent.Location = New System.Drawing.Point(204, 12)
        Me.txtIdent.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIdent.MaxLength = 32767
        Me.txtIdent.Multiline = True
        Me.txtIdent.Name = "txtIdent"
        Me.txtIdent.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIdent.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtIdent.SelectedText = ""
        Me.txtIdent.SelectionLength = 0
        Me.txtIdent.SelectionStart = 0
        Me.txtIdent.Size = New System.Drawing.Size(44, 24)
        Me.txtIdent.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtIdent.TabIndex = 167
        Me.txtIdent.UseCustomBackColor = True
        Me.txtIdent.UseSelectable = True
        Me.txtIdent.UseStyleColors = True
        Me.txtIdent.Visible = False
        Me.txtIdent.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtIdent.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'dgvSICode
        '
        Me.dgvSICode.AllowUserToResizeRows = False
        Me.dgvSICode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSICode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSICode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSICode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSICode.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvSICode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSICode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSICode.ColumnHeadersHeight = 29
        Me.dgvSICode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSICode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSICode.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSICode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSICode.EnableHeadersVisualStyles = False
        Me.dgvSICode.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dgvSICode.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSICode.Location = New System.Drawing.Point(3, 16)
        Me.dgvSICode.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvSICode.MultiSelect = False
        Me.dgvSICode.Name = "dgvSICode"
        Me.dgvSICode.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSICode.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvSICode.RowHeadersVisible = False
        Me.dgvSICode.RowHeadersWidth = 51
        Me.dgvSICode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvSICode.RowTemplate.Height = 24
        Me.dgvSICode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSICode.Size = New System.Drawing.Size(1873, 341)
        Me.dgvSICode.TabIndex = 170
        '
        'Column8
        '
        Me.Column8.HeaderText = "Ident"
        Me.Column8.MinimumWidth = 6
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        Me.Column8.Width = 66
        '
        'Column1
        '
        Me.Column1.HeaderText = "accountGroup"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 125
        '
        'Column2
        '
        Me.Column2.HeaderText = "accountNo"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 104
        '
        'Column3
        '
        Me.Column3.HeaderText = "accountControl"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 133
        '
        'Column4
        '
        Me.Column4.HeaderText = "SICode"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 79
        '
        'Column5
        '
        Me.Column5.HeaderText = "accountName"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 124
        '
        'Column6
        '
        Me.Column6.HeaderText = "ItemName"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 102
        '
        'Column7
        '
        Me.Column7.HeaderText = "SIGroup"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 85
        '
        'txtaccountControl
        '
        Me.txtaccountControl.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtaccountControl.CustomButton.Image = Nothing
        Me.txtaccountControl.CustomButton.Location = New System.Drawing.Point(689, 2)
        Me.txtaccountControl.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtaccountControl.CustomButton.Name = ""
        Me.txtaccountControl.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtaccountControl.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtaccountControl.CustomButton.TabIndex = 1
        Me.txtaccountControl.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtaccountControl.CustomButton.UseSelectable = True
        Me.txtaccountControl.CustomButton.Visible = False
        Me.txtaccountControl.Lines = New String() {"1000-00"}
        Me.txtaccountControl.Location = New System.Drawing.Point(793, 16)
        Me.txtaccountControl.Margin = New System.Windows.Forms.Padding(2)
        Me.txtaccountControl.MaxLength = 32767
        Me.txtaccountControl.Multiline = True
        Me.txtaccountControl.Name = "txtaccountControl"
        Me.txtaccountControl.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtaccountControl.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtaccountControl.SelectedText = ""
        Me.txtaccountControl.SelectionLength = 0
        Me.txtaccountControl.SelectionStart = 0
        Me.txtaccountControl.Size = New System.Drawing.Size(711, 24)
        Me.txtaccountControl.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtaccountControl.TabIndex = 176
        Me.txtaccountControl.Text = "1000-00"
        Me.txtaccountControl.UseCustomBackColor = True
        Me.txtaccountControl.UseSelectable = True
        Me.txtaccountControl.UseStyleColors = True
        Me.txtaccountControl.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtaccountControl.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(721, 24)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 17)
        Me.Label2.TabIndex = 175
        Me.Label2.Text = "บัญชีคุม"
        '
        'txtaccountName
        '
        Me.txtaccountName.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtaccountName.CustomButton.Image = Nothing
        Me.txtaccountName.CustomButton.Location = New System.Drawing.Point(993, 2)
        Me.txtaccountName.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtaccountName.CustomButton.Name = ""
        Me.txtaccountName.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtaccountName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtaccountName.CustomButton.TabIndex = 1
        Me.txtaccountName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtaccountName.CustomButton.UseSelectable = True
        Me.txtaccountName.CustomButton.Visible = False
        Me.txtaccountName.Lines = New String(-1) {}
        Me.txtaccountName.Location = New System.Drawing.Point(489, 74)
        Me.txtaccountName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtaccountName.MaxLength = 32767
        Me.txtaccountName.Multiline = True
        Me.txtaccountName.Name = "txtaccountName"
        Me.txtaccountName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtaccountName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtaccountName.SelectedText = ""
        Me.txtaccountName.SelectionLength = 0
        Me.txtaccountName.SelectionStart = 0
        Me.txtaccountName.Size = New System.Drawing.Size(1015, 24)
        Me.txtaccountName.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtaccountName.TabIndex = 174
        Me.txtaccountName.UseCustomBackColor = True
        Me.txtaccountName.UseSelectable = True
        Me.txtaccountName.UseStyleColors = True
        Me.txtaccountName.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtaccountName.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(387, 82)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "ชื่อบัญชี"
        '
        'txtaccountGroup
        '
        Me.txtaccountGroup.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtaccountGroup.CustomButton.Image = Nothing
        Me.txtaccountGroup.CustomButton.Location = New System.Drawing.Point(206, 2)
        Me.txtaccountGroup.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtaccountGroup.CustomButton.Name = ""
        Me.txtaccountGroup.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtaccountGroup.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtaccountGroup.CustomButton.TabIndex = 1
        Me.txtaccountGroup.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtaccountGroup.CustomButton.UseSelectable = True
        Me.txtaccountGroup.Lines = New String(-1) {}
        Me.txtaccountGroup.Location = New System.Drawing.Point(489, 16)
        Me.txtaccountGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.txtaccountGroup.MaxLength = 32767
        Me.txtaccountGroup.Multiline = True
        Me.txtaccountGroup.Name = "txtaccountGroup"
        Me.txtaccountGroup.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtaccountGroup.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtaccountGroup.SelectedText = ""
        Me.txtaccountGroup.SelectionLength = 0
        Me.txtaccountGroup.SelectionStart = 0
        Me.txtaccountGroup.ShowButton = True
        Me.txtaccountGroup.Size = New System.Drawing.Size(228, 24)
        Me.txtaccountGroup.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtaccountGroup.TabIndex = 172
        Me.txtaccountGroup.UseCustomBackColor = True
        Me.txtaccountGroup.UseSelectable = True
        Me.txtaccountGroup.UseStyleColors = True
        Me.txtaccountGroup.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtaccountGroup.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(387, 24)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 17)
        Me.Label9.TabIndex = 171
        Me.Label9.Text = "หมวดบัญชี"
        '
        'txtaccountNo
        '
        Me.txtaccountNo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtaccountNo.CustomButton.Image = Nothing
        Me.txtaccountNo.CustomButton.Location = New System.Drawing.Point(206, 2)
        Me.txtaccountNo.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtaccountNo.CustomButton.Name = ""
        Me.txtaccountNo.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtaccountNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtaccountNo.CustomButton.TabIndex = 1
        Me.txtaccountNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtaccountNo.CustomButton.UseSelectable = True
        Me.txtaccountNo.Lines = New String(-1) {}
        Me.txtaccountNo.Location = New System.Drawing.Point(489, 45)
        Me.txtaccountNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtaccountNo.MaxLength = 32767
        Me.txtaccountNo.Multiline = True
        Me.txtaccountNo.Name = "txtaccountNo"
        Me.txtaccountNo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtaccountNo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtaccountNo.SelectedText = ""
        Me.txtaccountNo.SelectionLength = 0
        Me.txtaccountNo.SelectionStart = 0
        Me.txtaccountNo.ShowButton = True
        Me.txtaccountNo.Size = New System.Drawing.Size(228, 24)
        Me.txtaccountNo.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtaccountNo.TabIndex = 178
        Me.txtaccountNo.UseCustomBackColor = True
        Me.txtaccountNo.UseSelectable = True
        Me.txtaccountNo.UseStyleColors = True
        Me.txtaccountNo.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtaccountNo.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(387, 53)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 17)
        Me.Label3.TabIndex = 177
        Me.Label3.Text = "เลขที่บัญชี"
        '
        'txtSICode
        '
        Me.txtSICode.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtSICode.CustomButton.Image = Nothing
        Me.txtSICode.CustomButton.Location = New System.Drawing.Point(689, 2)
        Me.txtSICode.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSICode.CustomButton.Name = ""
        Me.txtSICode.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtSICode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSICode.CustomButton.TabIndex = 1
        Me.txtSICode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtSICode.CustomButton.UseSelectable = True
        Me.txtSICode.CustomButton.Visible = False
        Me.txtSICode.Lines = New String(-1) {}
        Me.txtSICode.Location = New System.Drawing.Point(793, 45)
        Me.txtSICode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSICode.MaxLength = 32767
        Me.txtSICode.Multiline = True
        Me.txtSICode.Name = "txtSICode"
        Me.txtSICode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSICode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSICode.SelectedText = ""
        Me.txtSICode.SelectionLength = 0
        Me.txtSICode.SelectionStart = 0
        Me.txtSICode.Size = New System.Drawing.Size(711, 24)
        Me.txtSICode.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtSICode.TabIndex = 180
        Me.txtSICode.UseCustomBackColor = True
        Me.txtSICode.UseSelectable = True
        Me.txtSICode.UseStyleColors = True
        Me.txtSICode.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtSICode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(721, 53)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 17)
        Me.Label4.TabIndex = 179
        Me.Label4.Text = "SICode"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtItemName.CustomButton.Image = Nothing
        Me.txtItemName.CustomButton.Location = New System.Drawing.Point(993, 2)
        Me.txtItemName.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtItemName.CustomButton.Name = ""
        Me.txtItemName.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtItemName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtItemName.CustomButton.TabIndex = 1
        Me.txtItemName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtItemName.CustomButton.UseSelectable = True
        Me.txtItemName.CustomButton.Visible = False
        Me.txtItemName.Lines = New String(-1) {}
        Me.txtItemName.Location = New System.Drawing.Point(489, 104)
        Me.txtItemName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtItemName.MaxLength = 32767
        Me.txtItemName.Multiline = True
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtItemName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtItemName.SelectedText = ""
        Me.txtItemName.SelectionLength = 0
        Me.txtItemName.SelectionStart = 0
        Me.txtItemName.Size = New System.Drawing.Size(1015, 24)
        Me.txtItemName.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtItemName.TabIndex = 182
        Me.txtItemName.UseCustomBackColor = True
        Me.txtItemName.UseSelectable = True
        Me.txtItemName.UseStyleColors = True
        Me.txtItemName.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtItemName.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(387, 112)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 17)
        Me.Label5.TabIndex = 181
        Me.Label5.Text = "ชื่อรายการ"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(480, 3)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(85, 40)
        Me.Button3.TabIndex = 166
        Me.Button3.Text = "SAVE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(658, 3)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 40)
        Me.Button2.TabIndex = 165
        Me.Button2.Text = "ADD NEW"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(49, 16)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 184
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'cboSIGroup
        '
        Me.cboSIGroup.FormattingEnabled = True
        Me.cboSIGroup.ItemHeight = 23
        Me.cboSIGroup.Items.AddRange(New Object() {"ADV", "ASP", "AVF", "ATK", "OAP", "OAF", "OAK", "SVP", "SVF", "STK", "CSP", "CVF", "CTK", "OCP", "OCF", "OCK", "EXP"})
        Me.cboSIGroup.Location = New System.Drawing.Point(489, 133)
        Me.cboSIGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.cboSIGroup.Name = "cboSIGroup"
        Me.cboSIGroup.Size = New System.Drawing.Size(92, 29)
        Me.cboSIGroup.TabIndex = 185
        Me.cboSIGroup.UseSelectable = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(387, 141)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 17)
        Me.Label6.TabIndex = 186
        Me.Label6.Text = "SIGroup"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtaccountGroup)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboSIGroup)
        Me.GroupBox1.Controls.Add(Me.txtaccountName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtItemName)
        Me.GroupBox1.Controls.Add(Me.txtaccountControl)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSICode)
        Me.GroupBox1.Controls.Add(Me.txtaccountNo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1879, 174)
        Me.GroupBox1.TabIndex = 188
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvSICode)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1879, 360)
        Me.GroupBox2.TabIndex = 189
        Me.GroupBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.txtIdent)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 534)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1879, 47)
        Me.Panel1.TabIndex = 190
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.RefreshToolStripMenuItem, Me.ToolStripSeparator2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(114, 38)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(110, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(110, 6)
        '
        'SICODE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1879, 581)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "SICODE"
        Me.Text = "SICODE"
        CType(Me.dgvSICode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtIdent as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Button3 as Button
    Friend WithEvents Button2 as Button
    Friend WithEvents dgvSICode as MetroFramework.Controls.MetroGrid
    Friend WithEvents txtaccountControl as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label2 as Label
    Friend WithEvents txtaccountName as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label1 as Label
    Friend WithEvents txtaccountGroup as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label9 as Label
    Friend WithEvents txtaccountNo as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label3 as Label
    Friend WithEvents txtSICode as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label4 as Label
    Friend WithEvents txtItemName as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label5 as Label
    Friend WithEvents CheckBox1 as CheckBox
    Friend WithEvents cboSIGroup as MetroFramework.Controls.MetroComboBox
    Friend WithEvents Label6 as Label
    Friend WithEvents GroupBox1 as GroupBox
    Friend WithEvents GroupBox2 as GroupBox
    Friend WithEvents Panel1 as Panel
    Friend WithEvents ContextMenuStrip1 as ContextMenuStrip
    Friend WithEvents ToolStripSeparator1 as ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem as ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 as ToolStripSeparator
    Friend WithEvents Column8 as DataGridViewTextBoxColumn
    Friend WithEvents Column1 as DataGridViewTextBoxColumn
    Friend WithEvents Column2 as DataGridViewTextBoxColumn
    Friend WithEvents Column3 as DataGridViewTextBoxColumn
    Friend WithEvents Column4 as DataGridViewTextBoxColumn
    Friend WithEvents Column5 as DataGridViewTextBoxColumn
    Friend WithEvents Column6 as DataGridViewTextBoxColumn
    Friend WithEvents Column7 as DataGridViewTextBoxColumn
End Class
