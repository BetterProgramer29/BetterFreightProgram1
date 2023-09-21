<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectEngine
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.cbSelectField = New MetroFramework.Controls.MetroComboBox()
        Me.txtFindRecord = New MetroFramework.Controls.MetroTextBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.chkSelectall = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lvService = New System.Windows.Forms.ListView()
        Me.Code = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Description = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cost = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Currency = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CostBuy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Costsell = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProfitBuy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProfitSell = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Famt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Isvat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.VatRate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IncVat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Wtax = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.WtaxRate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IncTax = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.active = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Insert = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRevItem = New MetroFramework.Controls.MetroButton()
        Me.btnaddItem = New MetroFramework.Controls.MetroButton()
        Me.groupBox2.SuspendLayout()
        Me.MetroPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.add(Me.MetroPanel1)
        Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBox2.Location = New System.Drawing.Point(0, 0)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(972, 53)
        Me.groupBox2.TabIndex = 45
        Me.groupBox2.TabStop = False
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.add(Me.cbSelectField)
        Me.MetroPanel1.Controls.add(Me.txtFindRecord)
        Me.MetroPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(3, 16)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(966, 29)
        Me.MetroPanel1.TabIndex = 1
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
        Me.txtFindRecord.CustomButton.Location = New System.Drawing.Point(520, 1)
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
        Me.txtFindRecord.Location = New System.Drawing.Point(418, 0)
        Me.txtFindRecord.MaxLength = 32767
        Me.txtFindRecord.Name = "txtFindRecord"
        Me.txtFindRecord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFindRecord.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtFindRecord.SelectedText = ""
        Me.txtFindRecord.SelectionLength = 0
        Me.txtFindRecord.SelectionStart = 0
        Me.txtFindRecord.Size = New System.Drawing.Size(548, 29)
        Me.txtFindRecord.TabIndex = 2
        Me.txtFindRecord.UseSelectable = True
        Me.txtFindRecord.WaterMark = "พิมพ์ค้นหา"
        Me.txtFindRecord.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtFindRecord.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'lblCount
        '
        Me.lblCount.autoSize = True
        Me.lblCount.ForeColor = System.Drawing.Color.Red
        Me.lblCount.Location = New System.Drawing.Point(69, 7)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(13, 13)
        Me.lblCount.TabIndex = 44
        Me.lblCount.Text = "0"
        '
        'label1
        '
        Me.label1.autoSize = True
        Me.label1.Location = New System.Drawing.Point(24, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(40, 13)
        Me.label1.TabIndex = 43
        Me.label1.Text = "จำนวน"
        '
        'chkSelectall
        '
        Me.chkSelectall.autoSize = True
        Me.chkSelectall.Location = New System.Drawing.Point(182, 7)
        Me.chkSelectall.Name = "chkSelectall"
        Me.chkSelectall.Size = New System.Drawing.Size(83, 17)
        Me.chkSelectall.TabIndex = 42
        Me.chkSelectall.Text = "เลือกทั้งหมด"
        Me.chkSelectall.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.add(Me.lvService)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(972, 417)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        '
        'lvService
        '
        Me.lvService.activation = System.Windows.Forms.Itemactivation.OneClick
        Me.lvService.allowDrop = True
        Me.lvService.CheckBoxes = True
        Me.lvService.Columns.addRange(New System.Windows.Forms.ColumnHeader() {Me.Code, Me.Description, Me.Cost, Me.Price, Me.amount, Me.Currency, Me.CostBuy, Me.Costsell, Me.ProfitBuy, Me.ProfitSell, Me.Famt, Me.Isvat, Me.VatRate, Me.IncVat, Me.Wtax, Me.WtaxRate, Me.IncTax, Me.active, Me.Insert})
        Me.lvService.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvService.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lvService.ForeColor = System.Drawing.Color.Fromargb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lvService.FullRowSelect = True
        Me.lvService.GridLines = True
        Me.lvService.HideSelection = False
        Me.lvService.HoverSelection = True
        Me.lvService.Location = New System.Drawing.Point(3, 16)
        Me.lvService.Name = "lvService"
        Me.lvService.Size = New System.Drawing.Size(966, 398)
        Me.lvService.TabIndex = 40
        Me.lvService.UseCompatibleStateImageBehavior = False
        Me.lvService.View = System.Windows.Forms.View.Details
        '
        'Code
        '
        Me.Code.Text = "SICode"
        Me.Code.Width = 100
        '
        'Description
        '
        Me.Description.Text = "Description"
        Me.Description.Width = 480
        '
        'Cost
        '
        Me.Cost.Text = "Cost"
        Me.Cost.Width = 0
        '
        'Price
        '
        Me.Price.Text = "Price"
        Me.Price.Textalign = System.Windows.Forms.Horizontalalignment.Right
        Me.Price.Width = 80
        '
        'amount
        '
        Me.amount.Text = "amount"
        Me.amount.Textalign = System.Windows.Forms.Horizontalalignment.Right
        Me.amount.Width = 0
        '
        'Currency
        '
        Me.Currency.Text = "Currency"
        '
        'CostBuy
        '
        Me.CostBuy.Text = "CostBuy"
        Me.CostBuy.Textalign = System.Windows.Forms.Horizontalalignment.Right
        Me.CostBuy.Width = 0
        '
        'Costsell
        '
        Me.Costsell.Text = "Costsell"
        Me.Costsell.Textalign = System.Windows.Forms.Horizontalalignment.Right
        Me.Costsell.Width = 0
        '
        'ProfitBuy
        '
        Me.ProfitBuy.Text = "ProfitBuy"
        Me.ProfitBuy.Textalign = System.Windows.Forms.Horizontalalignment.Right
        Me.ProfitBuy.Width = 0
        '
        'ProfitSell
        '
        Me.ProfitSell.Text = "ProfitSell"
        Me.ProfitSell.Textalign = System.Windows.Forms.Horizontalalignment.Right
        Me.ProfitSell.Width = 0
        '
        'Famt
        '
        Me.Famt.Text = "Famt"
        Me.Famt.Textalign = System.Windows.Forms.Horizontalalignment.Right
        Me.Famt.Width = 0
        '
        'Isvat
        '
        Me.Isvat.Text = "Vat"
        Me.Isvat.Textalign = System.Windows.Forms.Horizontalalignment.Right
        '
        'VatRate
        '
        Me.VatRate.Text = "VatRate"
        Me.VatRate.Textalign = System.Windows.Forms.Horizontalalignment.Right
        Me.VatRate.Width = 0
        '
        'IncVat
        '
        Me.IncVat.Text = "IncVat"
        Me.IncVat.Textalign = System.Windows.Forms.Horizontalalignment.Right
        Me.IncVat.Width = 0
        '
        'Wtax
        '
        Me.Wtax.Text = "WHT"
        Me.Wtax.Textalign = System.Windows.Forms.Horizontalalignment.Right
        '
        'WtaxRate
        '
        Me.WtaxRate.Text = "Rate"
        Me.WtaxRate.Textalign = System.Windows.Forms.Horizontalalignment.Right
        Me.WtaxRate.Width = 0
        '
        'IncTax
        '
        Me.IncTax.Text = "IncTax"
        Me.IncTax.Textalign = System.Windows.Forms.Horizontalalignment.Right
        Me.IncTax.Width = 0
        '
        'active
        '
        Me.active.Text = "active"
        Me.active.Width = 0
        '
        'Insert
        '
        Me.Insert.Text = "Insert"
        Me.Insert.Width = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.add(Me.lblCount)
        Me.Panel1.Controls.add(Me.btnRevItem)
        Me.Panel1.Controls.add(Me.btnaddItem)
        Me.Panel1.Controls.add(Me.chkSelectall)
        Me.Panel1.Controls.add(Me.label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 470)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(972, 36)
        Me.Panel1.TabIndex = 47
        '
        'btnRevItem
        '
        'Me.btnRevItem.BackgroundImage = Global.FREIGHTCENTER.My.Resources.Resources.close_32
        Me.btnRevItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRevItem.Location = New System.Drawing.Point(879, 3)
        Me.btnRevItem.Name = "btnRevItem"
        Me.btnRevItem.Size = New System.Drawing.Size(81, 28)
        Me.btnRevItem.TabIndex = 26
        Me.btnRevItem.UseSelectable = True
        '
        'btnaddItem
        '
        'Me.btnaddItem.BackgroundImage = Global.FREIGHTCENTER.My.Resources.Resources._Select
        Me.btnaddItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnaddItem.Location = New System.Drawing.Point(654, 3)
        Me.btnaddItem.Name = "btnaddItem"
        Me.btnaddItem.Size = New System.Drawing.Size(158, 28)
        Me.btnaddItem.TabIndex = 25
        Me.btnaddItem.UseSelectable = True
        '
        'frmSelectEngine
        '
        Me.autoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.autoScaleMode = System.Windows.Forms.autoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 506)
        Me.Controls.add(Me.GroupBox1)
        Me.Controls.add(Me.groupBox2)
        Me.Controls.add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "frmSelectEngine"
        Me.Text = "Data List"
        Me.groupBox2.ResumeLayout(False)
        Me.MetroPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents groupBox2 as GroupBox
    Private WithEvents lblCount as Label
    Private WithEvents label1 as Label
    Private WithEvents chkSelectall as CheckBox
    Friend WithEvents GroupBox1 as GroupBox
    Friend WithEvents Panel1 as Panel
    Private WithEvents btnRevItem as MetroFramework.Controls.MetroButton
    Private WithEvents btnaddItem as MetroFramework.Controls.MetroButton
    Private WithEvents lvService as ListView
    Private WithEvents Code as ColumnHeader
    Private WithEvents Description as ColumnHeader
    Private WithEvents Cost as ColumnHeader
    Private WithEvents Price as ColumnHeader
    Private WithEvents amount as ColumnHeader
    Private WithEvents Currency as ColumnHeader
    Private WithEvents CostBuy as ColumnHeader
    Private WithEvents Costsell as ColumnHeader
    Private WithEvents ProfitBuy as ColumnHeader
    Private WithEvents ProfitSell as ColumnHeader
    Private WithEvents Famt as ColumnHeader
    Private WithEvents Isvat as ColumnHeader
    Private WithEvents VatRate as ColumnHeader
    Private WithEvents IncVat as ColumnHeader
    Private WithEvents Wtax as ColumnHeader
    Private WithEvents WtaxRate as ColumnHeader
    Private WithEvents IncTax as ColumnHeader
    Friend WithEvents MetroPanel1 as MetroFramework.Controls.MetroPanel
    Friend WithEvents cbSelectField as MetroFramework.Controls.MetroComboBox
    Friend WithEvents txtFindRecord as MetroFramework.Controls.MetroTextBox
    Friend WithEvents active as ColumnHeader
    Friend WithEvents Insert as ColumnHeader
End Class
