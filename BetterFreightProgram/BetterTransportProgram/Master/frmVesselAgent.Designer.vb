<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVesselagent
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
        Me.txtVesselBooking = New MetroFramework.Controls.MetroTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtVesselagentName = New MetroFramework.Controls.MetroTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtIdent = New MetroFramework.Controls.MetroTextBox()
        Me.SuspendLayout()
        '
        'txtVesselBooking
        '
        '
        '
        '
        Me.txtVesselBooking.CustomButton.Image = Nothing'Nothing
        Me.txtVesselBooking.CustomButton.Location = New System.Drawing.Point(240, 2)
        Me.txtVesselBooking.CustomButton.Name = ""
        Me.txtVesselBooking.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtVesselBooking.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtVesselBooking.CustomButton.TabIndex = 1
        Me.txtVesselBooking.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtVesselBooking.CustomButton.UseSelectable = True
        Me.txtVesselBooking.CustomButton.Visible = False
        Me.txtVesselBooking.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtVesselBooking.Lines = New String(-1) {}
        Me.txtVesselBooking.Location = New System.Drawing.Point(173, 50)
        Me.txtVesselBooking.MaxLength = 32767
        Me.txtVesselBooking.Multiline = True
        Me.txtVesselBooking.Name = "txtVesselBooking"
        Me.txtVesselBooking.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtVesselBooking.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtVesselBooking.SelectedText = ""
        Me.txtVesselBooking.SelectionLength = 0
        Me.txtVesselBooking.SelectionStart = 0
        Me.txtVesselBooking.Size = New System.Drawing.Size(268, 30)
        Me.txtVesselBooking.Style = MetroFramework.MetroColorStyle.Green
        Me.txtVesselBooking.TabIndex = 29
        Me.txtVesselBooking.UseCustomBackColor = True
        Me.txtVesselBooking.UseCustomForeColor = True
        Me.txtVesselBooking.UseSelectable = True
        Me.txtVesselBooking.UseStyleColors = True
        Me.txtVesselBooking.WaterMark = "ติดต่อลูกค้า"
        Me.txtVesselBooking.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtVesselBooking.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label7
        '
        Me.Label7.autoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 20)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Vessel Booking"
        '
        'txtVesselagentName
        '
        '
        '
        '
        Me.txtVesselagentName.CustomButton.Image = Nothing'Nothing
        Me.txtVesselagentName.CustomButton.Location = New System.Drawing.Point(240, 2)
        Me.txtVesselagentName.CustomButton.Name = ""
        Me.txtVesselagentName.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtVesselagentName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtVesselagentName.CustomButton.TabIndex = 1
        Me.txtVesselagentName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtVesselagentName.CustomButton.UseSelectable = True
        Me.txtVesselagentName.CustomButton.Visible = False
        Me.txtVesselagentName.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtVesselagentName.Lines = New String(-1) {}
        Me.txtVesselagentName.Location = New System.Drawing.Point(173, 14)
        Me.txtVesselagentName.MaxLength = 32767
        Me.txtVesselagentName.Multiline = True
        Me.txtVesselagentName.Name = "txtVesselagentName"
        Me.txtVesselagentName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtVesselagentName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtVesselagentName.SelectedText = ""
        Me.txtVesselagentName.SelectionLength = 0
        Me.txtVesselagentName.SelectionStart = 0
        Me.txtVesselagentName.Size = New System.Drawing.Size(268, 30)
        Me.txtVesselagentName.Style = MetroFramework.MetroColorStyle.Green
        Me.txtVesselagentName.TabIndex = 33
        Me.txtVesselagentName.UseCustomBackColor = True
        Me.txtVesselagentName.UseCustomForeColor = True
        Me.txtVesselagentName.UseSelectable = True
        Me.txtVesselagentName.UseStyleColors = True
        Me.txtVesselagentName.WaterMark = "การอ้างอิงลูกค้า"
        Me.txtVesselagentName.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtVesselagentName.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label1
        '
        Me.Label1.autoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 20)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Vessel agent"
        '
        'Button1
        '
        Me.Button1.Image = Nothing'Global.BetterFreightProgram.My.Resources.Resources.Untitled_6
        Me.Button1.Location = New System.Drawing.Point(327, 86)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 49)
        Me.Button1.TabIndex = 56
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtIdent
        '
        '
        '
        '
        Me.txtIdent.CustomButton.Image = Nothing'Nothing
        Me.txtIdent.CustomButton.Location = New System.Drawing.Point(76, 2)
        Me.txtIdent.CustomButton.Name = ""
        Me.txtIdent.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtIdent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtIdent.CustomButton.TabIndex = 1
        Me.txtIdent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtIdent.CustomButton.UseSelectable = True
        Me.txtIdent.CustomButton.Visible = False
        Me.txtIdent.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtIdent.Lines = New String(-1) {}
        Me.txtIdent.Location = New System.Drawing.Point(16, 86)
        Me.txtIdent.MaxLength = 32767
        Me.txtIdent.Multiline = True
        Me.txtIdent.Name = "txtIdent"
        Me.txtIdent.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIdent.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtIdent.SelectedText = ""
        Me.txtIdent.SelectionLength = 0
        Me.txtIdent.SelectionStart = 0
        Me.txtIdent.Size = New System.Drawing.Size(104, 30)
        Me.txtIdent.Style = MetroFramework.MetroColorStyle.Green
        Me.txtIdent.TabIndex = 57
        Me.txtIdent.UseCustomBackColor = True
        Me.txtIdent.UseCustomForeColor = True
        Me.txtIdent.UseSelectable = True
        Me.txtIdent.UseStyleColors = True
        Me.txtIdent.Visible = False
        Me.txtIdent.WaterMark = "ติดต่อลูกค้า"
        Me.txtIdent.WaterMarkColor = System.Drawing.Color.Fromargb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtIdent.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'frmVesselagent
        '
        Me.autoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.autoScaleMode = System.Windows.Forms.autoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 141)
        Me.Controls.add(Me.txtIdent)
        Me.Controls.add(Me.Button1)
        Me.Controls.add(Me.txtVesselagentName)
        Me.Controls.add(Me.Label1)
        Me.Controls.add(Me.txtVesselBooking)
        Me.Controls.add(Me.Label7)
        Me.Name = "frmVesselagent"
        Me.Text = "frmVesselagent"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVesselBooking as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label7 as Label
    Friend WithEvents txtVesselagentName as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label1 as Label
    Friend WithEvents Button1 as Button
    Friend WithEvents txtIdent as MetroFramework.Controls.MetroTextBox
End Class
