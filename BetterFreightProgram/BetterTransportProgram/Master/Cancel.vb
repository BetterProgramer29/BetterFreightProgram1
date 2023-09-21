Public Class Cancel
    Public Isactive as Boolean
    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        Isactive = False
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        Isactive = True
        Me.Close()
    End Sub

    Private Sub Cancel_Load(sender as Object, e as Eventargs) Handles MyBase.Load

    End Sub

    'Private Sub Button1_MouseClick(sender as Object, e as MouseEventargs) Handles Button1.MouseClick
    '    frmContainer.txtactive.Text = "0"
    'End Sub
End Class