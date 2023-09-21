<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bookaccount
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
        Me.txtBookingNo = New MetroFramework.Controls.MetroTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtaccountName = New MetroFramework.Controls.MetroTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtaccountType = New MetroFramework.Controls.MetroComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.txtIdent = New MetroFramework.Controls.MetroTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtBookingNo
        '
        Me.txtBookingNo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtBookingNo.CustomButton.Image = Nothing'Nothing
        Me.txtBookingNo.CustomButton.Location = New System.Drawing.Point(200, 2)
        Me.txtBookingNo.CustomButton.Name = ""
        Me.txtBookingNo.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtBookingNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtBookingNo.CustomButton.TabIndex = 1
        Me.txtBookingNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtBookingNo.CustomButton.UseSelectable = True
        Me.txtBookingNo.CustomButton.Visible = False
        Me.txtBookingNo.Lines = New String(-1) {}
        Me.txtBookingNo.Location = New System.Drawing.Point(110, 12)
        Me.txtBookingNo.MaxLength = 32767
        Me.txtBookingNo.Multiline = True
        Me.txtBookingNo.Name = "txtBookingNo"
        Me.txtBookingNo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBookingNo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtBookingNo.SelectedText = ""
        Me.txtBookingNo.SelectionLength = 0
        Me.txtBookingNo.SelectionStart = 0
        Me.txtBookingNo.Size = New System.Drawing.Size(228, 30)
        Me.txtBookingNo.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtBookingNo.TabIndex = 144
        Me.txtBookingNo.UseCustomBackColor = True
        Me.txtBookingNo.UseSelectable = True
        Me.txtBookingNo.UseStyleColors = True
        Me.txtBookingNo.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtBookingNo.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label1
        '
        Me.Label1.autoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "Book No"
        '
        'txtaccountName
        '
        Me.txtaccountName.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtaccountName.CustomButton.Image = Nothing'Nothing
        Me.txtaccountName.CustomButton.Location = New System.Drawing.Point(316, 2)
        Me.txtaccountName.CustomButton.Name = ""
        Me.txtaccountName.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtaccountName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtaccountName.CustomButton.TabIndex = 1
        Me.txtaccountName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtaccountName.CustomButton.UseSelectable = True
        Me.txtaccountName.CustomButton.Visible = False
        Me.txtaccountName.Lines = New String(-1) {}
        Me.txtaccountName.Location = New System.Drawing.Point(490, 12)
        Me.txtaccountName.MaxLength = 32767
        Me.txtaccountName.Multiline = True
        Me.txtaccountName.Name = "txtaccountName"
        Me.txtaccountName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtaccountName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtaccountName.SelectedText = ""
        Me.txtaccountName.SelectionLength = 0
        Me.txtaccountName.SelectionStart = 0
        Me.txtaccountName.Size = New System.Drawing.Size(344, 30)
        Me.txtaccountName.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtaccountName.TabIndex = 146
        Me.txtaccountName.UseCustomBackColor = True
        Me.txtaccountName.UseSelectable = True
        Me.txtaccountName.UseStyleColors = True
        Me.txtaccountName.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtaccountName.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label2
        '
        Me.Label2.autoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(346, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 20)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "account Name"
        '
        'Label3
        '
        Me.Label3.autoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 20)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = "account Type"
        '
        'txtaccountType
        '
        Me.txtaccountType.FormattingEnabled = True
        Me.txtaccountType.ItemHeight = 24
        Me.txtaccountType.Items.addRange(New Object() {"Current", "Saving"})
        Me.txtaccountType.Location = New System.Drawing.Point(151, 48)
        Me.txtaccountType.Name = "txtaccountType"
        Me.txtaccountType.Size = New System.Drawing.Size(228, 30)
        Me.txtaccountType.TabIndex = 148
        Me.txtaccountType.UseSelectable = True
        '
        'Button2
        '
        Me.Button2.Image = Nothing'Global.BetterFreightProgram.My.Resources.Resources.Untitled_6
        Me.Button2.Location = New System.Drawing.Point(722, 84)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 49)
        Me.Button2.TabIndex = 168
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Image = Nothing'Global.BetterFreightProgram.My.Resources.Resources.Untitled_2
        Me.Button6.Location = New System.Drawing.Point(603, 84)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(113, 49)
        Me.Button6.TabIndex = 169
        Me.Button6.UseVisualStyleBackColor = True
        '
        'txtIdent
        '
        Me.txtIdent.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtIdent.CustomButton.Image = Nothing'Nothing
        Me.txtIdent.CustomButton.Location = New System.Drawing.Point(63, 2)
        Me.txtIdent.CustomButton.Name = ""
        Me.txtIdent.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtIdent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtIdent.CustomButton.TabIndex = 1
        Me.txtIdent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtIdent.CustomButton.UseSelectable = True
        Me.txtIdent.CustomButton.Visible = False
        Me.txtIdent.Lines = New String(-1) {}
        Me.txtIdent.Location = New System.Drawing.Point(422, 48)
        Me.txtIdent.MaxLength = 32767
        Me.txtIdent.Multiline = True
        Me.txtIdent.Name = "txtIdent"
        Me.txtIdent.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIdent.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtIdent.SelectedText = ""
        Me.txtIdent.SelectionLength = 0
        Me.txtIdent.SelectionStart = 0
        Me.txtIdent.Size = New System.Drawing.Size(91, 30)
        Me.txtIdent.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtIdent.TabIndex = 170
        Me.txtIdent.UseCustomBackColor = True
        Me.txtIdent.UseSelectable = True
        Me.txtIdent.UseStyleColors = True
        Me.txtIdent.Visible = False
        Me.txtIdent.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtIdent.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Button1
        '
        Me.Button1.Image = Nothing'Global.BetterFreightProgram.My.Resources.Resources.Untitled_3
        Me.Button1.Location = New System.Drawing.Point(484, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 49)
        Me.Button1.TabIndex = 171
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Bookaccount
        '
        Me.autoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.autoScaleMode = System.Windows.Forms.autoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 144)
        Me.Controls.add(Me.Button1)
        Me.Controls.add(Me.txtIdent)
        Me.Controls.add(Me.Button6)
        Me.Controls.add(Me.Button2)
        Me.Controls.add(Me.txtaccountType)
        Me.Controls.add(Me.Label3)
        Me.Controls.add(Me.txtaccountName)
        Me.Controls.add(Me.Label2)
        Me.Controls.add(Me.txtBookingNo)
        Me.Controls.add(Me.Label1)
        Me.Name = "Bookaccount"
        Me.Text = "Bookaccount"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtBookingNo as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label1 as Label
    Friend WithEvents txtaccountName as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label2 as Label
    Friend WithEvents Label3 as Label
    Friend WithEvents txtaccountType as MetroFramework.Controls.MetroComboBox
    Friend WithEvents Button2 as Button
    Friend WithEvents Button6 as Button
    Friend WithEvents txtIdent as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Button1 as Button
End Class
