Imports System.Text

Public Class PVCancel
    Public Isactive as Boolean = True
    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        If txtReason.Text = "" Then
            MsgBox("การจะยกเลิกเอกสารต้องใส่เหตุผลให้คนอื่นเข้าใจด้วยอธิบายโดยละเอียด")
            Exit Sub
        Else
            Isactive = False
            SaveReason(1)
            Me.Close()
        End If
    End Sub
    Private Sub SaveReason(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdatePV_Reason ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtReason.Text & "'") 'Reason
            SQLcommand.append(",'" & txtadvNo.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        Isactive = True
        Me.Close()
    End Sub

    Private Sub Cancel_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        txtIdent.Text = "0"
    End Sub

    'Private Sub Button1_MouseClick(sender as Object, e as MouseEventargs) Handles Button1.MouseClick
    '    frmContainer.txtactive.Text = "0"
    'End Sub
End Class