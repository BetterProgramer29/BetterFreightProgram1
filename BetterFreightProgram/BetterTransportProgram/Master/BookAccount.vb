Imports System.Text

Public Class Bookaccount
    Public _IsNew as Boolean
    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        If _IsNew = True Then
            SaveBookaccount(1)
        Else
            SaveBookaccount(0)
        End If
    End Sub
    Private Sub SaveBookaccount(_insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateBookaccount ")
            SQLcommand.append("'" & CInt(txtIdent.Text) & "'") 'Ident
            SQLcommand.append(",'" & txtBookingNo.Text & "'") 'BookingNo
            SQLcommand.append(",'" & txtaccountName.Text & "'") 'accountName
            SQLcommand.append(",'" & txtaccountType.Text & "'") 'accountType
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
    Private Sub addNewBook()
        txtIdent.Text = "0" 'Ident
        txtBookingNo.ResetText() 'BookingNo
        txtaccountName.ResetText() 'accountName
        txtaccountType.ResetText() 'accountType
        _IsNew = True
    End Sub

    Private Sub Bookaccount_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        addNewBook()
    End Sub

    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        addNewBook()
    End Sub

    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [BookingNo],[accountName],[accountType]  FROM [Bookaccount] WHERE 1=1  order by [BookingNo] ", MainConnection)
        If isSearchOK Then
            txtBookingNo.Text = dr("BookingNo").ToString
            txtaccountName.Text = dr("accountName").ToString
            txtaccountType.Text = dr("accountType").ToString
        End If
    End Sub
End Class