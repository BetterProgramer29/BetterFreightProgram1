<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeachEngine
    '   Inherits System.Windows.Forms.Form
    Inherits MetroFramework.Forms.MetroForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeachEngine))
        Me.btnClose = New MetroFramework.Controls.MetroButton()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.cbSelectField = New MetroFramework.Controls.MetroComboBox()
        Me.txtFindRecord = New MetroFramework.Controls.MetroTextBox()
        Me.MetroPanel2 = New MetroFramework.Controls.MetroPanel()
        Me.btnApply = New MetroFramework.Controls.MetroButton()
        Me.dgvFindRecord = New MetroFramework.Controls.MetroGrid()
        Me.MetroPanel1.SuspendLayout()
        Me.MetroPanel2.SuspendLayout()
        CType(Me.dgvFindRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnClose.Location = New System.Drawing.Point(769, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 35)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseCustomBackColor = True
        Me.btnClose.UseCustomForeColor = True
        Me.btnClose.UseSelectable = True
        Me.btnClose.UseStyleColors = True
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.cbSelectField)
        Me.MetroPanel1.Controls.Add(Me.txtFindRecord)
        Me.MetroPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(20, 60)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(878, 29)
        Me.MetroPanel1.TabIndex = 0
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'cbSelectField
        '
        Me.cbSelectField.Dock = System.Windows.Forms.DockStyle.Left
        Me.cbSelectField.FormattingEnabled = True
        Me.cbSelectField.ItemHeight = 23
        Me.cbSelectField.Location = New System.Drawing.Point(0, 0)
        Me.cbSelectField.Name = "cbSelectField"
        Me.cbSelectField.Size = New System.Drawing.Size(224, 29)
        Me.cbSelectField.TabIndex = 1
        Me.cbSelectField.UseSelectable = True
        '
        'txtFindRecord
        '
        '
        '
        '
        Me.txtFindRecord.CustomButton.Image = Nothing'Nothing
        Me.txtFindRecord.CustomButton.Location = New System.Drawing.Point(599, 1)
        Me.txtFindRecord.CustomButton.Name = ""
        Me.txtFindRecord.CustomButton.Size = New System.Drawing.Size(27, 27)
        Me.txtFindRecord.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtFindRecord.CustomButton.TabIndex = 1
        Me.txtFindRecord.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtFindRecord.CustomButton.UseSelectable = True
        Me.txtFindRecord.CustomButton.Visible = False
        Me.txtFindRecord.DisplayIcon = True
        Me.txtFindRecord.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtFindRecord.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtFindRecord.IconRight = True
        Me.txtFindRecord.Lines = New String(-1) {}
        Me.txtFindRecord.Location = New System.Drawing.Point(251, 0)
        Me.txtFindRecord.MaxLength = 32767
        Me.txtFindRecord.Name = "txtFindRecord"
        Me.txtFindRecord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFindRecord.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtFindRecord.SelectedText = ""
        Me.txtFindRecord.SelectionLength = 0
        Me.txtFindRecord.SelectionStart = 0
        Me.txtFindRecord.Size = New System.Drawing.Size(627, 29)
        Me.txtFindRecord.TabIndex = 2
        Me.txtFindRecord.UseSelectable = True
        Me.txtFindRecord.WaterMark = "พิมพ์ค้นหา"
        Me.txtFindRecord.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtFindRecord.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroPanel2
        '
        Me.MetroPanel2.Controls.Add(Me.btnClose)
        Me.MetroPanel2.Controls.Add(Me.btnApply)
        Me.MetroPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroPanel2.HorizontalScrollbarBarColor = True
        Me.MetroPanel2.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.HorizontalScrollbarSize = 10
        Me.MetroPanel2.Location = New System.Drawing.Point(20, 400)
        Me.MetroPanel2.Name = "MetroPanel2"
        Me.MetroPanel2.Size = New System.Drawing.Size(878, 41)
        Me.MetroPanel2.TabIndex = 2
        Me.MetroPanel2.VerticalScrollbarBarColor = True
        Me.MetroPanel2.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.VerticalScrollbarSize = 10
        '
        'btnApply
        '
        Me.btnApply.AutoSize = True
        Me.btnApply.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnApply.Location = New System.Drawing.Point(495, 3)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(106, 35)
        Me.btnApply.TabIndex = 3
        Me.btnApply.Text = "OK"
        Me.btnApply.UseCustomBackColor = True
        Me.btnApply.UseCustomForeColor = True
        Me.btnApply.UseSelectable = True
        Me.btnApply.UseStyleColors = True
        '
        'dgvFindRecord
        '
        Me.dgvFindRecord.AllowUserToAddRows = False
        Me.dgvFindRecord.AllowUserToDeleteRows = False
        Me.dgvFindRecord.AllowUserToResizeRows = False
        Me.dgvFindRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFindRecord.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFindRecord.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvFindRecord.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvFindRecord.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvFindRecord.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFindRecord.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFindRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFindRecord.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFindRecord.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvFindRecord.EnableHeadersVisualStyles = False
        Me.dgvFindRecord.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dgvFindRecord.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvFindRecord.Location = New System.Drawing.Point(20, 95)
        Me.dgvFindRecord.MultiSelect = False
        Me.dgvFindRecord.Name = "dgvFindRecord"
        Me.dgvFindRecord.ReadOnly = True
        Me.dgvFindRecord.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFindRecord.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFindRecord.RowHeadersWidth = 20
        Me.dgvFindRecord.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvFindRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFindRecord.Size = New System.Drawing.Size(878, 305)
        Me.dgvFindRecord.Style = MetroFramework.MetroColorStyle.Blue
        Me.dgvFindRecord.TabIndex = 1
        Me.dgvFindRecord.Theme = MetroFramework.MetroThemeStyle.Light
        '
        'frmSeachEngine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 461)
        Me.Controls.Add(Me.dgvFindRecord)
        Me.Controls.Add(Me.MetroPanel2)
        Me.Controls.Add(Me.MetroPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeachEngine"
        Me.Text = "ค้นหาข้อมูล"
        Me.MetroPanel1.ResumeLayout(False)
        Me.MetroPanel2.ResumeLayout(False)
        Me.MetroPanel2.PerformLayout()
        CType(Me.dgvFindRecord, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnApply As MetroFramework.Controls.MetroButton
    Friend WithEvents btnClose As MetroFramework.Controls.MetroButton
    Friend WithEvents txtFindRecord As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroPanel2 As MetroFramework.Controls.MetroPanel
    Friend WithEvents dgvFindRecord As MetroFramework.Controls.MetroGrid
    Friend WithEvents cbSelectField As MetroFramework.Controls.MetroComboBox
End Class
