Public Class SelectConfirmation
    Public Selected as Boolean = True
    Private Sub MetroButton1_Click(sender as Object, e as Eventargs) Handles MetroButton1.Click
        SelectInv.Selected = True
        Me.Close()
    End Sub

    Private Sub MetroButton2_Click(sender as Object, e as Eventargs) Handles MetroButton2.Click
        SelectInv.Selected = False
        Me.Close()
    End Sub
End Class