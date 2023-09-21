<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVCancel
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReason = New MetroFramework.Controls.MetroTextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtIdent = New MetroFramework.Controls.MetroTextBox()
        Me.txtadvNo = New MetroFramework.Controls.MetroTextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button1.Location = New System.Drawing.Point(24, 142)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(217, 99)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "ส่งใบเบิกกลับผู้อนุมัติเพื่อตรวจสอบ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Magenta
        Me.Button5.Location = New System.Drawing.Point(810, 142)
        Me.Button5.Margin = New System.Windows.Forms.Padding(2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(337, 99)
        Me.Button5.TabIndex = 19
        Me.Button5.Text = "ไม่ยกเลิกแล้วดีกว่า ทำจ่ายให้ก็ได้"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.autoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Fuchsia
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1163, 108)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "ไม่สามารถทำจ่ายให้ได้เพราะว่า"
        '
        'txtReason
        '
        Me.txtReason.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtReason.CustomButton.Image = Nothing'Nothing
        Me.txtReason.CustomButton.Location = New System.Drawing.Point(483, 2)
        Me.txtReason.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReason.CustomButton.Name = ""
        Me.txtReason.CustomButton.Size = New System.Drawing.Size(75, 75)
        Me.txtReason.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtReason.CustomButton.TabIndex = 1
        Me.txtReason.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtReason.CustomButton.UseSelectable = True
        Me.txtReason.CustomButton.Visible = False
        Me.txtReason.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtReason.Lines = New String(-1) {}
        Me.txtReason.Location = New System.Drawing.Point(245, 161)
        Me.txtReason.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReason.MaxLength = 32767
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtReason.SelectedText = ""
        Me.txtReason.SelectionLength = 0
        Me.txtReason.SelectionStart = 0
        Me.txtReason.Size = New System.Drawing.Size(561, 80)
        Me.txtReason.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtReason.TabIndex = 175
        Me.txtReason.UseCustomBackColor = True
        Me.txtReason.UseSelectable = True
        Me.txtReason.UseStyleColors = True
        Me.txtReason.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtReason.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label27
        '
        Me.Label27.autoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.BlueViolet
        Me.Label27.Location = New System.Drawing.Point(245, 130)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(321, 29)
        Me.Label27.TabIndex = 174
        Me.Label27.Text = "ต้องใส่เหตุผลของการไม่อนุมัติจ่าย"
        '
        'txtIdent
        '
        Me.txtIdent.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtIdent.CustomButton.Image = Nothing'Nothing
        Me.txtIdent.CustomButton.Location = New System.Drawing.Point(39, 2)
        Me.txtIdent.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIdent.CustomButton.Name = ""
        Me.txtIdent.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.txtIdent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtIdent.CustomButton.TabIndex = 1
        Me.txtIdent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtIdent.CustomButton.UseSelectable = True
        Me.txtIdent.CustomButton.Visible = False
        Me.txtIdent.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtIdent.Lines = New String(-1) {}
        Me.txtIdent.Location = New System.Drawing.Point(586, 105)
        Me.txtIdent.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIdent.MaxLength = 32767
        Me.txtIdent.Multiline = True
        Me.txtIdent.Name = "txtIdent"
        Me.txtIdent.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIdent.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtIdent.SelectedText = ""
        Me.txtIdent.SelectionLength = 0
        Me.txtIdent.SelectionStart = 0
        Me.txtIdent.Size = New System.Drawing.Size(65, 28)
        Me.txtIdent.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtIdent.TabIndex = 176
        Me.txtIdent.UseCustomBackColor = True
        Me.txtIdent.UseSelectable = True
        Me.txtIdent.UseStyleColors = True
        Me.txtIdent.Visible = False
        Me.txtIdent.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtIdent.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtadvNo
        '
        Me.txtadvNo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtadvNo.CustomButton.Image = Nothing'Nothing
        Me.txtadvNo.CustomButton.Location = New System.Drawing.Point(140, 2)
        Me.txtadvNo.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtadvNo.CustomButton.Name = ""
        Me.txtadvNo.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.txtadvNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtadvNo.CustomButton.TabIndex = 1
        Me.txtadvNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtadvNo.CustomButton.UseSelectable = True
        Me.txtadvNo.CustomButton.Visible = False
        Me.txtadvNo.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtadvNo.Lines = New String(-1) {}
        Me.txtadvNo.Location = New System.Drawing.Point(278, 9)
        Me.txtadvNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtadvNo.MaxLength = 32767
        Me.txtadvNo.Multiline = True
        Me.txtadvNo.Name = "txtadvNo"
        Me.txtadvNo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtadvNo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtadvNo.SelectedText = ""
        Me.txtadvNo.SelectionLength = 0
        Me.txtadvNo.SelectionStart = 0
        Me.txtadvNo.Size = New System.Drawing.Size(166, 28)
        Me.txtadvNo.Style = MetroFramework.MetroColorStyle.Teal
        Me.txtadvNo.TabIndex = 177
        Me.txtadvNo.UseCustomBackColor = True
        Me.txtadvNo.UseSelectable = True
        Me.txtadvNo.UseStyleColors = True
        Me.txtadvNo.Visible = False
        Me.txtadvNo.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtadvNo.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'PVCancel
        '
        Me.autoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.autoScaleMode = System.Windows.Forms.autoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1158, 259)
        Me.Controls.add(Me.txtadvNo)
        Me.Controls.add(Me.txtIdent)
        Me.Controls.add(Me.txtReason)
        Me.Controls.add(Me.Label27)
        Me.Controls.add(Me.Button1)
        Me.Controls.add(Me.Button5)
        Me.Controls.add(Me.Label1)
        Me.Name = "PVCancel"
        Me.Text = "PVCancel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 as Button
    Friend WithEvents Button5 as Button
    Friend WithEvents Label1 as Label
    Friend WithEvents txtReason as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label27 as Label
    Friend WithEvents txtIdent as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtadvNo as MetroFramework.Controls.MetroTextBox
End Class
