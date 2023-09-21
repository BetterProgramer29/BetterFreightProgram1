'Imports System.Text

'Public Class Factory
'    Private Sub Factory_Load(sender as Object, e as Eventargs) Handles MyBase.Load

'    End Sub
'    Private Sub SaveFactory()
'        Try
'            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
'            nection = ConnectDB()
'            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_FactoryTransport ")
'            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
'            SQLcommand.append(",'" & txtFactoryTaxID.Text & "'") 'FactoryTaxID
'            SQLcommand.append(",'" & txtFactoryCompanyID.Text & "'") 'FactoryCompanyID
'            SQLcommand.append(",'" & txtFactoryBranch.Text & "'") 'FactoryBranch
'            SQLcommand.append(",'" & txtFactoryCompanyName.Text & "'") 'FactoryCompanyName
'            SQLcommand.append(",'" & txtFactoryCountry.Text & "'") 'FactoryCountry
'            SQLcommand.append(",'" & txtFactoryCity.Text & "'") 'FactoryCity
'            SQLcommand.append(",'" & txtFactoryaddress.Text & "'") 'Factoryaddress
'            SQLcommand.append(",'" & txtFactoryEmail.Text & "'") 'FactoryEmail
'            SQLcommand.append(",'" & txtFactoryPhone.Text & "'") 'FactoryPhone
'            SQLcommand.append(",'" & txtFactoryFax.Text & "'") 'FactoryFax
'            SQLcommand.append(",'" & txtFactoryPayable.Text & "'") 'FactoryPayable
'            SQLcommand.append(",'" & togFactoryFactory.CheckState & "'") 'FactoryFactory
'            SQLcommand.append(",'" & togFactoryCustomer.CheckState & "'") 'FactoryCustomer
'            SQLcommand.append(",'" & _Insert & "'") '//Insert Or Update
'            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
'            If result = 1 Then
'                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Else
'                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
'            End If
'            nection.Close()
'        Catch ex as Exception
'            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
'        End Try
'    End Sub
'End Class