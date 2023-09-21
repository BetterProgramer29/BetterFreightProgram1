<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMasVessel
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
        Dim DataGridViewCellStyle1 as System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 as System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 as System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdNew = New MetroFramework.Controls.MetroButton()
        Me.MetroButton4 = New MetroFramework.Controls.MetroButton()
        Me.cmdSave = New MetroFramework.Controls.MetroButton()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.cmdClose = New MetroFramework.Controls.MetroButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvVesselList = New MetroFramework.Controls.MetroGrid()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.togactive = New MetroFramework.Controls.MetroToggle()
        Me.metroLabel11 = New MetroFramework.Controls.MetroLabel()
        Me.txtCountryName = New MetroFramework.Controls.MetroTextBox()
        Me.txtCountryCode = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel5 = New MetroFramework.Controls.MetroLabel()
        Me.cmbVesselType = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLabel6 = New MetroFramework.Controls.MetroLabel()
        Me.txtVesselName = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.txtRegisterNumber = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.txtVesselCode = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.txtTBIDNT = New MetroFramework.Controls.MetroTextBox()
        Me.metroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.MetroLabel8 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel7 = New MetroFramework.Controls.MetroLabel()
        Me.txtVesselNameS = New MetroFramework.Controls.MetroTextBox()
        Me.txtVesselCodeS = New MetroFramework.Controls.MetroTextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvVesselList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.add(Me.cmdNew)
        Me.Panel1.Controls.add(Me.MetroButton4)
        Me.Panel1.Controls.add(Me.cmdSave)
        Me.Panel1.Controls.add(Me.MetroButton2)
        Me.Panel1.Controls.add(Me.cmdClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 420)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 30)
        Me.Panel1.TabIndex = 3
        '
        'cmdNew
        '
        'Me.cmdNew.BackgroundImage = Global.FREIGHTCENTER.My.Resources.Resources.new_32
        Me.cmdNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdNew.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdNew.Location = New System.Drawing.Point(427, 0)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(92, 30)
        Me.cmdNew.TabIndex = 0
        Me.cmdNew.UseSelectable = True
        '
        'MetroButton4
        '
        Me.MetroButton4.Dock = System.Windows.Forms.DockStyle.Right
        Me.MetroButton4.Location = New System.Drawing.Point(519, 0)
        Me.MetroButton4.Name = "MetroButton4"
        Me.MetroButton4.Size = New System.Drawing.Size(45, 30)
        Me.MetroButton4.TabIndex = 1
        Me.MetroButton4.TabStop = False
        Me.MetroButton4.UseSelectable = True
        '
        'cmdSave
        '
        'Me.cmdSave.BackgroundImage = Global.FREIGHTCENTER.My.Resources.Resources.save_32
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdSave.Location = New System.Drawing.Point(564, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(118, 30)
        Me.cmdSave.TabIndex = 2
        Me.cmdSave.UseSelectable = True
        '
        'MetroButton2
        '
        Me.MetroButton2.Dock = System.Windows.Forms.DockStyle.Right
        Me.MetroButton2.Location = New System.Drawing.Point(682, 0)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(45, 30)
        Me.MetroButton2.TabIndex = 3
        Me.MetroButton2.TabStop = False
        Me.MetroButton2.UseSelectable = True
        '
        'cmdClose
        '
        'Me.cmdClose.BackgroundImage = Global.FREIGHTCENTER.My.Resources.Resources.close_32
        Me.cmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdClose.Location = New System.Drawing.Point(727, 0)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(73, 30)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.UseSelectable = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.add(Me.dgvVesselList)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 73)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(507, 341)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'dgvVesselList
        '
        Me.dgvVesselList.allowUserToaddRows = False
        Me.dgvVesselList.allowUserToDeleteRows = False
        Me.dgvVesselList.allowUserToResizeRows = False
        Me.dgvVesselList.BackgroundColor = System.Drawing.Color.Fromargb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvVesselList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvVesselList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvVesselList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.alignment = System.Windows.Forms.DataGridViewContentalignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Fromargb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Fromargb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Fromargb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Fromargb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVesselList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVesselList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.autoSize
        Me.dgvVesselList.Columns.addRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        DataGridViewCellStyle2.alignment = System.Windows.Forms.DataGridViewContentalignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Fromargb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Fromargb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Fromargb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Fromargb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVesselList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVesselList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVesselList.EnableHeadersVisualStyles = False
        Me.dgvVesselList.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dgvVesselList.GridColor = System.Drawing.Color.Fromargb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvVesselList.Location = New System.Drawing.Point(3, 16)
        Me.dgvVesselList.Name = "dgvVesselList"
        Me.dgvVesselList.ReadOnly = True
        Me.dgvVesselList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.alignment = System.Windows.Forms.DataGridViewContentalignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Fromargb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Fromargb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Fromargb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Fromargb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVesselList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVesselList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvVesselList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVesselList.Size = New System.Drawing.Size(501, 322)
        Me.dgvVesselList.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.HeaderText = "VesselCode"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "RegisterNumber"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        Me.Column4.HeaderText = "VesselName"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "VesselType"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "CountryCode"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "ContryName"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "active"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 60
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.add(Me.togactive)
        Me.GroupBox2.Controls.add(Me.metroLabel11)
        Me.GroupBox2.Controls.add(Me.txtCountryName)
        Me.GroupBox2.Controls.add(Me.txtCountryCode)
        Me.GroupBox2.Controls.add(Me.MetroLabel5)
        Me.GroupBox2.Controls.add(Me.cmbVesselType)
        Me.GroupBox2.Controls.add(Me.MetroLabel6)
        Me.GroupBox2.Controls.add(Me.txtVesselName)
        Me.GroupBox2.Controls.add(Me.MetroLabel4)
        Me.GroupBox2.Controls.add(Me.txtRegisterNumber)
        Me.GroupBox2.Controls.add(Me.MetroLabel2)
        Me.GroupBox2.Controls.add(Me.txtVesselCode)
        Me.GroupBox2.Controls.add(Me.MetroLabel1)
        Me.GroupBox2.Controls.add(Me.txtTBIDNT)
        Me.GroupBox2.Controls.add(Me.metroLabel3)
        Me.GroupBox2.Location = New System.Drawing.Point(525, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(263, 400)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'togactive
        '
        Me.togactive.autoSize = True
        Me.togactive.Checked = True
        Me.togactive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.togactive.Location = New System.Drawing.Point(173, 276)
        Me.togactive.Name = "togactive"
        Me.togactive.Size = New System.Drawing.Size(80, 17)
        Me.togactive.TabIndex = 7
        Me.togactive.Text = "On"
        Me.togactive.UseSelectable = True
        '
        'metroLabel11
        '
        Me.metroLabel11.autoSize = True
        Me.metroLabel11.Location = New System.Drawing.Point(123, 276)
        Me.metroLabel11.Name = "metroLabel11"
        Me.metroLabel11.Size = New System.Drawing.Size(44, 19)
        Me.metroLabel11.TabIndex = 110
        Me.metroLabel11.Text = "active"
        Me.metroLabel11.UseCustomBackColor = True
        '
        'txtCountryName
        '
        '
        '
        '
        Me.txtCountryName.CustomButton.Image = Nothing'Nothing
        Me.txtCountryName.CustomButton.Location = New System.Drawing.Point(154, 2)
        Me.txtCountryName.CustomButton.Name = ""
        Me.txtCountryName.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtCountryName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCountryName.CustomButton.TabIndex = 1
        Me.txtCountryName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtCountryName.CustomButton.UseSelectable = True
        Me.txtCountryName.CustomButton.Visible = False
        Me.txtCountryName.Lines = New String(-1) {}
        Me.txtCountryName.Location = New System.Drawing.Point(81, 203)
        Me.txtCountryName.MaxLength = 32767
        Me.txtCountryName.Name = "txtCountryName"
        Me.txtCountryName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCountryName.ReadOnly = True
        Me.txtCountryName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCountryName.SelectedText = ""
        Me.txtCountryName.SelectionLength = 0
        Me.txtCountryName.SelectionStart = 0
        Me.txtCountryName.Size = New System.Drawing.Size(176, 24)
        Me.txtCountryName.TabIndex = 6
        Me.txtCountryName.TabStop = False
        Me.txtCountryName.UseCustomBackColor = True
        Me.txtCountryName.UseSelectable = True
        Me.txtCountryName.UseStyleColors = True
        Me.txtCountryName.WaterMark = "Contry Name"
        Me.txtCountryName.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtCountryName.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtCountryCode
        '
        Me.txtCountryCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        '
        '
        '
        Me.txtCountryCode.CustomButton.Image = Nothing'Nothing
        Me.txtCountryCode.CustomButton.Location = New System.Drawing.Point(54, 2)
        Me.txtCountryCode.CustomButton.Name = ""
        Me.txtCountryCode.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtCountryCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCountryCode.CustomButton.TabIndex = 1
        Me.txtCountryCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtCountryCode.CustomButton.UseSelectable = True
        Me.txtCountryCode.Lines = New String(-1) {}
        Me.txtCountryCode.Location = New System.Drawing.Point(81, 173)
        Me.txtCountryCode.MaxLength = 32767
        Me.txtCountryCode.Name = "txtCountryCode"
        Me.txtCountryCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCountryCode.ReadOnly = True
        Me.txtCountryCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCountryCode.SelectedText = ""
        Me.txtCountryCode.SelectionLength = 0
        Me.txtCountryCode.SelectionStart = 0
        Me.txtCountryCode.ShowButton = True
        Me.txtCountryCode.ShowClearButton = True
        Me.txtCountryCode.Size = New System.Drawing.Size(76, 24)
        Me.txtCountryCode.TabIndex = 5
        Me.txtCountryCode.TabStop = False
        Me.txtCountryCode.UseSelectable = True
        Me.txtCountryCode.UseStyleColors = True
        Me.txtCountryCode.WaterMark = "Code"
        Me.txtCountryCode.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtCountryCode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel5
        '
        Me.MetroLabel5.autoSize = True
        Me.MetroLabel5.Location = New System.Drawing.Point(19, 176)
        Me.MetroLabel5.Name = "MetroLabel5"
        Me.MetroLabel5.Size = New System.Drawing.Size(56, 19)
        Me.MetroLabel5.TabIndex = 96
        Me.MetroLabel5.Text = "Country"
        Me.MetroLabel5.UseCustomBackColor = True
        Me.MetroLabel5.UseCustomForeColor = True
        '
        'cmbVesselType
        '
        Me.cmbVesselType.FormattingEnabled = True
        Me.cmbVesselType.ItemHeight = 23
        Me.cmbVesselType.Items.addRange(New Object() {"SHIPPING", "TRUCK", "TRaIN", "PLaNE", "SPECIaL"})
        Me.cmbVesselType.Location = New System.Drawing.Point(81, 138)
        Me.cmbVesselType.Name = "cmbVesselType"
        Me.cmbVesselType.Size = New System.Drawing.Size(112, 29)
        Me.cmbVesselType.TabIndex = 4
        Me.cmbVesselType.UseSelectable = True
        '
        'MetroLabel6
        '
        Me.MetroLabel6.autoSize = True
        Me.MetroLabel6.Location = New System.Drawing.Point(39, 143)
        Me.MetroLabel6.Name = "MetroLabel6"
        Me.MetroLabel6.Size = New System.Drawing.Size(36, 19)
        Me.MetroLabel6.TabIndex = 93
        Me.MetroLabel6.Text = "Type"
        Me.MetroLabel6.UseCustomBackColor = True
        Me.MetroLabel6.UseCustomForeColor = True
        '
        'txtVesselName
        '
        Me.txtVesselName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        '
        '
        '
        Me.txtVesselName.CustomButton.Image = Nothing'Nothing
        Me.txtVesselName.CustomButton.Location = New System.Drawing.Point(154, 2)
        Me.txtVesselName.CustomButton.Name = ""
        Me.txtVesselName.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtVesselName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtVesselName.CustomButton.TabIndex = 1
        Me.txtVesselName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtVesselName.CustomButton.UseSelectable = True
        Me.txtVesselName.CustomButton.Visible = False
        Me.txtVesselName.Lines = New String(-1) {}
        Me.txtVesselName.Location = New System.Drawing.Point(81, 108)
        Me.txtVesselName.MaxLength = 32767
        Me.txtVesselName.Name = "txtVesselName"
        Me.txtVesselName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtVesselName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtVesselName.SelectedText = ""
        Me.txtVesselName.SelectionLength = 0
        Me.txtVesselName.SelectionStart = 0
        Me.txtVesselName.Size = New System.Drawing.Size(176, 24)
        Me.txtVesselName.TabIndex = 3
        Me.txtVesselName.UseSelectable = True
        Me.txtVesselName.UseStyleColors = True
        Me.txtVesselName.WaterMark = "Vessel Name"
        Me.txtVesselName.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtVesselName.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel4
        '
        Me.MetroLabel4.autoSize = True
        Me.MetroLabel4.Location = New System.Drawing.Point(30, 111)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(45, 19)
        Me.MetroLabel4.TabIndex = 86
        Me.MetroLabel4.Text = "Name"
        Me.MetroLabel4.UseCustomBackColor = True
        Me.MetroLabel4.UseCustomForeColor = True
        '
        'txtRegisterNumber
        '
        Me.txtRegisterNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        '
        '
        '
        Me.txtRegisterNumber.CustomButton.Image = Nothing'Nothing
        Me.txtRegisterNumber.CustomButton.Location = New System.Drawing.Point(154, 2)
        Me.txtRegisterNumber.CustomButton.Name = ""
        Me.txtRegisterNumber.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtRegisterNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtRegisterNumber.CustomButton.TabIndex = 1
        Me.txtRegisterNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtRegisterNumber.CustomButton.UseSelectable = True
        Me.txtRegisterNumber.CustomButton.Visible = False
        Me.txtRegisterNumber.Lines = New String(-1) {}
        Me.txtRegisterNumber.Location = New System.Drawing.Point(81, 78)
        Me.txtRegisterNumber.MaxLength = 32767
        Me.txtRegisterNumber.Name = "txtRegisterNumber"
        Me.txtRegisterNumber.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRegisterNumber.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtRegisterNumber.SelectedText = ""
        Me.txtRegisterNumber.SelectionLength = 0
        Me.txtRegisterNumber.SelectionStart = 0
        Me.txtRegisterNumber.Size = New System.Drawing.Size(176, 24)
        Me.txtRegisterNumber.TabIndex = 2
        Me.txtRegisterNumber.UseSelectable = True
        Me.txtRegisterNumber.UseStyleColors = True
        Me.txtRegisterNumber.WaterMark = "Register Number"
        Me.txtRegisterNumber.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtRegisterNumber.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel2
        '
        Me.MetroLabel2.autoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(4, 82)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(74, 19)
        Me.MetroLabel2.TabIndex = 84
        Me.MetroLabel2.Text = "RegisterNo"
        Me.MetroLabel2.UseCustomBackColor = True
        Me.MetroLabel2.UseCustomForeColor = True
        '
        'txtVesselCode
        '
        '
        '
        '
        Me.txtVesselCode.CustomButton.Image = Nothing'Nothing
        Me.txtVesselCode.CustomButton.Location = New System.Drawing.Point(90, 2)
        Me.txtVesselCode.CustomButton.Name = ""
        Me.txtVesselCode.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtVesselCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtVesselCode.CustomButton.TabIndex = 1
        Me.txtVesselCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtVesselCode.CustomButton.UseSelectable = True
        Me.txtVesselCode.CustomButton.Visible = False
        Me.txtVesselCode.Lines = New String(-1) {}
        Me.txtVesselCode.Location = New System.Drawing.Point(81, 48)
        Me.txtVesselCode.MaxLength = 32767
        Me.txtVesselCode.Name = "txtVesselCode"
        Me.txtVesselCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtVesselCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtVesselCode.SelectedText = ""
        Me.txtVesselCode.SelectionLength = 0
        Me.txtVesselCode.SelectionStart = 0
        Me.txtVesselCode.ShowClearButton = True
        Me.txtVesselCode.Size = New System.Drawing.Size(112, 24)
        Me.txtVesselCode.TabIndex = 1
        Me.txtVesselCode.UseSelectable = True
        Me.txtVesselCode.UseStyleColors = True
        Me.txtVesselCode.WaterMark = "Code"
        Me.txtVesselCode.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtVesselCode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel1
        '
        Me.MetroLabel1.autoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(34, 51)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(41, 19)
        Me.MetroLabel1.TabIndex = 81
        Me.MetroLabel1.Text = "Code"
        Me.MetroLabel1.UseCustomBackColor = True
        Me.MetroLabel1.UseCustomForeColor = True
        '
        'txtTBIDNT
        '
        '
        '
        '
        Me.txtTBIDNT.CustomButton.Image = Nothing'Nothing
        Me.txtTBIDNT.CustomButton.Location = New System.Drawing.Point(20, 2)
        Me.txtTBIDNT.CustomButton.Name = ""
        Me.txtTBIDNT.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtTBIDNT.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtTBIDNT.CustomButton.TabIndex = 1
        Me.txtTBIDNT.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtTBIDNT.CustomButton.UseSelectable = True
        Me.txtTBIDNT.CustomButton.Visible = False
        Me.txtTBIDNT.Lines = New String(-1) {}
        Me.txtTBIDNT.Location = New System.Drawing.Point(81, 18)
        Me.txtTBIDNT.MaxLength = 32767
        Me.txtTBIDNT.Name = "txtTBIDNT"
        Me.txtTBIDNT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTBIDNT.ReadOnly = True
        Me.txtTBIDNT.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtTBIDNT.SelectedText = ""
        Me.txtTBIDNT.SelectionLength = 0
        Me.txtTBIDNT.SelectionStart = 0
        Me.txtTBIDNT.Size = New System.Drawing.Size(42, 24)
        Me.txtTBIDNT.TabIndex = 0
        Me.txtTBIDNT.TabStop = False
        Me.txtTBIDNT.UseSelectable = True
        Me.txtTBIDNT.UseStyleColors = True
        Me.txtTBIDNT.WaterMark = "Ident"
        Me.txtTBIDNT.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtTBIDNT.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'metroLabel3
        '
        Me.metroLabel3.autoSize = True
        Me.metroLabel3.Location = New System.Drawing.Point(54, 21)
        Me.metroLabel3.Name = "metroLabel3"
        Me.metroLabel3.Size = New System.Drawing.Size(21, 19)
        Me.metroLabel3.TabIndex = 79
        Me.metroLabel3.Text = "ID"
        Me.metroLabel3.UseCustomBackColor = True
        Me.metroLabel3.UseCustomForeColor = True
        '
        'groupBox3
        '
        Me.groupBox3.Controls.add(Me.MetroLabel8)
        Me.groupBox3.Controls.add(Me.MetroLabel7)
        Me.groupBox3.Controls.add(Me.txtVesselNameS)
        Me.groupBox3.Controls.add(Me.txtVesselCodeS)
        Me.groupBox3.Location = New System.Drawing.Point(15, 12)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(504, 55)
        Me.groupBox3.TabIndex = 0
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Search"
        '
        'MetroLabel8
        '
        Me.MetroLabel8.autoSize = True
        Me.MetroLabel8.Location = New System.Drawing.Point(160, 21)
        Me.MetroLabel8.Name = "MetroLabel8"
        Me.MetroLabel8.Size = New System.Drawing.Size(45, 19)
        Me.MetroLabel8.TabIndex = 87
        Me.MetroLabel8.Text = "Name"
        Me.MetroLabel8.UseCustomBackColor = True
        Me.MetroLabel8.UseCustomForeColor = True
        '
        'MetroLabel7
        '
        Me.MetroLabel7.autoSize = True
        Me.MetroLabel7.Location = New System.Drawing.Point(6, 21)
        Me.MetroLabel7.Name = "MetroLabel7"
        Me.MetroLabel7.Size = New System.Drawing.Size(41, 19)
        Me.MetroLabel7.TabIndex = 82
        Me.MetroLabel7.Text = "Code"
        Me.MetroLabel7.UseCustomBackColor = True
        Me.MetroLabel7.UseCustomForeColor = True
        '
        'txtVesselNameS
        '
        '
        '
        '
        Me.txtVesselNameS.CustomButton.Image = Nothing'Nothing
        Me.txtVesselNameS.CustomButton.Location = New System.Drawing.Point(219, 2)
        Me.txtVesselNameS.CustomButton.Name = ""
        Me.txtVesselNameS.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtVesselNameS.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtVesselNameS.CustomButton.TabIndex = 1
        Me.txtVesselNameS.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtVesselNameS.CustomButton.UseSelectable = True
        Me.txtVesselNameS.CustomButton.Visible = False
        Me.txtVesselNameS.Lines = New String(-1) {}
        Me.txtVesselNameS.Location = New System.Drawing.Point(211, 19)
        Me.txtVesselNameS.MaxLength = 32767
        Me.txtVesselNameS.Name = "txtVesselNameS"
        Me.txtVesselNameS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtVesselNameS.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtVesselNameS.SelectedText = ""
        Me.txtVesselNameS.SelectionLength = 0
        Me.txtVesselNameS.SelectionStart = 0
        Me.txtVesselNameS.Size = New System.Drawing.Size(241, 24)
        Me.txtVesselNameS.TabIndex = 1
        Me.txtVesselNameS.UseSelectable = True
        Me.txtVesselNameS.WaterMark = "Vessel Name"
        Me.txtVesselNameS.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtVesselNameS.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtVesselCodeS
        '
        '
        '
        '
        Me.txtVesselCodeS.CustomButton.Image = Nothing'Nothing
        Me.txtVesselCodeS.CustomButton.Location = New System.Drawing.Point(81, 2)
        Me.txtVesselCodeS.CustomButton.Name = ""
        Me.txtVesselCodeS.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtVesselCodeS.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtVesselCodeS.CustomButton.TabIndex = 1
        Me.txtVesselCodeS.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtVesselCodeS.CustomButton.UseSelectable = True
        Me.txtVesselCodeS.CustomButton.Visible = False
        Me.txtVesselCodeS.Lines = New String(-1) {}
        Me.txtVesselCodeS.Location = New System.Drawing.Point(51, 19)
        Me.txtVesselCodeS.MaxLength = 10
        Me.txtVesselCodeS.Name = "txtVesselCodeS"
        Me.txtVesselCodeS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtVesselCodeS.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtVesselCodeS.SelectedText = ""
        Me.txtVesselCodeS.SelectionLength = 0
        Me.txtVesselCodeS.SelectionStart = 0
        Me.txtVesselCodeS.Size = New System.Drawing.Size(103, 24)
        Me.txtVesselCodeS.TabIndex = 0
        Me.txtVesselCodeS.UseSelectable = True
        Me.txtVesselCodeS.WaterMark = "Vessel Code"
        Me.txtVesselCodeS.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtVesselCodeS.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'frmMasVessel
        '
        Me.autoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.autoScaleMode = System.Windows.Forms.autoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.add(Me.groupBox3)
        Me.Controls.add(Me.GroupBox2)
        Me.Controls.add(Me.GroupBox1)
        Me.Controls.add(Me.Panel1)
        Me.Name = "frmMasVessel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMasVessel"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvVesselList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 as Panel
    Friend WithEvents cmdNew as MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton4 as MetroFramework.Controls.MetroButton
    Friend WithEvents cmdSave as MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton2 as MetroFramework.Controls.MetroButton
    Friend WithEvents cmdClose as MetroFramework.Controls.MetroButton
    Friend WithEvents GroupBox1 as GroupBox
    Friend WithEvents GroupBox2 as GroupBox
    Friend WithEvents dgvVesselList as MetroFramework.Controls.MetroGrid
    Private WithEvents groupBox3 as GroupBox
    Friend WithEvents txtVesselNameS as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtVesselCodeS as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtVesselName as MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel4 as MetroFramework.Controls.MetroLabel
    Friend WithEvents txtRegisterNumber as MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel2 as MetroFramework.Controls.MetroLabel
    Friend WithEvents txtVesselCode as MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel1 as MetroFramework.Controls.MetroLabel
    Friend WithEvents txtTBIDNT as MetroFramework.Controls.MetroTextBox
    Friend WithEvents metroLabel3 as MetroFramework.Controls.MetroLabel
    Friend WithEvents txtCountryName as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtCountryCode as MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel5 as MetroFramework.Controls.MetroLabel
    Friend WithEvents cmbVesselType as MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroLabel6 as MetroFramework.Controls.MetroLabel
    Friend WithEvents togactive as MetroFramework.Controls.MetroToggle
    Friend WithEvents metroLabel11 as MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel8 as MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel7 as MetroFramework.Controls.MetroLabel
    Friend WithEvents Column1 as DataGridViewTextBoxColumn
    Friend WithEvents Column2 as DataGridViewTextBoxColumn
    Friend WithEvents Column3 as DataGridViewTextBoxColumn
    Friend WithEvents Column4 as DataGridViewTextBoxColumn
    Friend WithEvents Column5 as DataGridViewTextBoxColumn
    Friend WithEvents Column6 as DataGridViewTextBoxColumn
    Friend WithEvents Column7 as DataGridViewTextBoxColumn
    Friend WithEvents Column8 as DataGridViewTextBoxColumn
End Class
