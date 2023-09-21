<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectConfirmation
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.autoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(289, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 55)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(559, 262)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(206, 100)
        Me.MetroButton1.TabIndex = 1
        Me.MetroButton1.Text = "OK"
        Me.MetroButton1.UseSelectable = True
        '
        'MetroButton2
        '
        Me.MetroButton2.Location = New System.Drawing.Point(33, 262)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(206, 100)
        Me.MetroButton2.TabIndex = 2
        Me.MetroButton2.Text = "CaNCEL"
        Me.MetroButton2.UseSelectable = True
        '
        'SelectConfirmation
        '
        Me.autoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.autoScaleMode = System.Windows.Forms.autoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 386)
        Me.Controls.add(Me.MetroButton2)
        Me.Controls.add(Me.MetroButton1)
        Me.Controls.add(Me.Label1)
        Me.Name = "SelectConfirmation"
        Me.Text = "SelectConfirmation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 as Label
    Friend WithEvents MetroButton1 as MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton2 as MetroFramework.Controls.MetroButton
End Class
