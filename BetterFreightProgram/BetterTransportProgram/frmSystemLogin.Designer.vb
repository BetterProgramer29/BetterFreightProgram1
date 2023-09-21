<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSystemLogin
    ' Inherits System.Windows.Forms.Form
    Inherits MetroFramework.Forms.MetroForm
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSystemLogin))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboUserBranch = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.txtU_EntryCode = New MetroFramework.Controls.MetroTextBox()
        Me.txtU_Code = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New MetroFramework.Controls.MetroButton()
        Me.btnSetLogin = New MetroFramework.Controls.MetroButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboUserBranch)
        Me.GroupBox1.Controls.Add(Me.MetroLabel3)
        Me.GroupBox1.Controls.Add(Me.txtU_EntryCode)
        Me.GroupBox1.Controls.Add(Me.txtU_Code)
        Me.GroupBox1.Controls.Add(Me.MetroLabel2)
        Me.GroupBox1.Controls.Add(Me.MetroLabel1)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 128)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cboUserBranch
        '
        Me.cboUserBranch.FormattingEnabled = True
        Me.cboUserBranch.ItemHeight = 23
        Me.cboUserBranch.Location = New System.Drawing.Point(82, 18)
        Me.cboUserBranch.Name = "cboUserBranch"
        Me.cboUserBranch.Size = New System.Drawing.Size(264, 29)
        Me.cboUserBranch.TabIndex = 7
        Me.cboUserBranch.UseSelectable = True
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(26, 21)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(49, 19)
        Me.MetroLabel3.TabIndex = 6
        Me.MetroLabel3.Text = "Branch"
        '
        'txtU_EntryCode
        '
        '
        '
        '
        Me.txtU_EntryCode.CustomButton.Image = Nothing'Nothing
        Me.txtU_EntryCode.CustomButton.Location = New System.Drawing.Point(177, 2)
        Me.txtU_EntryCode.CustomButton.Name = ""
        Me.txtU_EntryCode.CustomButton.Size = New System.Drawing.Size(19, 20)
        Me.txtU_EntryCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtU_EntryCode.CustomButton.TabIndex = 1
        Me.txtU_EntryCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtU_EntryCode.CustomButton.UseSelectable = True
        Me.txtU_EntryCode.CustomButton.Visible = False
        Me.txtU_EntryCode.Lines = New String(-1) {}
        Me.txtU_EntryCode.Location = New System.Drawing.Point(82, 89)
        Me.txtU_EntryCode.MaxLength = 32767
        Me.txtU_EntryCode.Name = "txtU_EntryCode"
        Me.txtU_EntryCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.txtU_EntryCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtU_EntryCode.SelectedText = ""
        Me.txtU_EntryCode.SelectionLength = 0
        Me.txtU_EntryCode.SelectionStart = 0
        Me.txtU_EntryCode.Size = New System.Drawing.Size(264, 30)
        Me.txtU_EntryCode.TabIndex = 3
        Me.txtU_EntryCode.UseSelectable = True
        Me.txtU_EntryCode.WaterMark = "Put You Pass word"
        Me.txtU_EntryCode.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtU_EntryCode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtU_Code
        '
        '
        '
        '
        Me.txtU_Code.CustomButton.Image = Nothing'Nothing
        Me.txtU_Code.CustomButton.Location = New System.Drawing.Point(177, 2)
        Me.txtU_Code.CustomButton.Name = ""
        Me.txtU_Code.CustomButton.Size = New System.Drawing.Size(19, 20)
        Me.txtU_Code.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtU_Code.CustomButton.TabIndex = 1
        Me.txtU_Code.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtU_Code.CustomButton.UseSelectable = True
        Me.txtU_Code.CustomButton.Visible = False
        Me.txtU_Code.Lines = New String(-1) {}
        Me.txtU_Code.Location = New System.Drawing.Point(82, 53)
        Me.txtU_Code.MaxLength = 32767
        Me.txtU_Code.Name = "txtU_Code"
        Me.txtU_Code.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtU_Code.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtU_Code.SelectedText = ""
        Me.txtU_Code.SelectionLength = 0
        Me.txtU_Code.SelectionStart = 0
        Me.txtU_Code.Size = New System.Drawing.Size(264, 30)
        Me.txtU_Code.TabIndex = 2
        Me.txtU_Code.UseSelectable = True
        Me.txtU_Code.WaterMark = "Put You ID"
        Me.txtU_Code.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtU_Code.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel2
        '
        Me.MetroLabel2.Location = New System.Drawing.Point(6, 89)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(70, 35)
        Me.MetroLabel2.TabIndex = 1
        Me.MetroLabel2.Text = "Pass Word"
        '
        'MetroLabel1
        '
        Me.MetroLabel1.Location = New System.Drawing.Point(25, 48)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(51, 35)
        Me.MetroLabel1.TabIndex = 0
        Me.MetroLabel1.Text = "User ID"
        Me.MetroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Controls.Add(Me.btnSetLogin)
        Me.GroupBox2.Location = New System.Drawing.Point(23, 197)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(420, 54)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(233, 13)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(141, 32)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseSelectable = True
        '
        'btnSetLogin
        '
        Me.btnSetLogin.Location = New System.Drawing.Point(26, 13)
        Me.btnSetLogin.Name = "btnSetLogin"
        Me.btnSetLogin.Size = New System.Drawing.Size(141, 32)
        Me.btnSetLogin.TabIndex = 0
        Me.btnSetLogin.Text = "OK"
        Me.btnSetLogin.UseSelectable = True
        '
        'frmSystemLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 274)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSystemLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "System Login"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtU_EntryCode As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtU_Code As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents btnCancel As MetroFramework.Controls.MetroButton
    Friend WithEvents btnSetLogin As MetroFramework.Controls.MetroButton
    Private WithEvents cboUserBranch As MetroFramework.Controls.MetroComboBox
    Private WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
End Class
