<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class approveadv
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.autoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-1, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(978, 73)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "กรุณาตรวจสอบให้ดีก่อนจะอนุมัติสั่งเบิก"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 199)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(946, 83)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "ข้าพเจ้าได้ตรวจสอบความถูกต้องในการเบิกแล้ว ถ้าเกิดความเสียหายใดใดข้าพเจ้าจะชดใช้ใ" &
    "นความเสียหายนั้นทั้งหมดโดยไม่มีข้อโต้แย้งใดใด"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(12, 110)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(946, 83)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "ยังไม่กดอนุมัติ ตรวจสอบอีกรอบดีกว่า"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'approveadv
        '
        Me.autoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.autoScaleMode = System.Windows.Forms.autoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 291)
        Me.Controls.add(Me.Button2)
        Me.Controls.add(Me.Button1)
        Me.Controls.add(Me.Label1)
        Me.Name = "approveadv"
        Me.Text = "approveadv"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 as Label
    Friend WithEvents Button1 as Button
    Friend WithEvents Button2 as Button
End Class
