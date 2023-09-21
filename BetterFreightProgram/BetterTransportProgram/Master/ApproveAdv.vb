Public Class approveadv
    Public willclose as Boolean
    Public Isapproveadv as Boolean
    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        willclose = True
        Me.Isapproveadv = True
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        willclose = True
        Me.Isapproveadv = False
        Me.Close()
    End Sub

    Private Sub approveadv_FormClosing(sender as Object, e as FormClosingEventargs) Handles MyBase.FormClosing
        If willclose = True Then
        Else
            MsgBox("เลือกหนึ่งตัวเลือก")
            e.Cancel = True
        End If
    End Sub

    Private Sub approveadv_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        willclose = False
    End Sub
End Class