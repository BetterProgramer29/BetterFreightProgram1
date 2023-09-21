Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text

Public Class frmLocation
    Public _IsNewP as Boolean
    Public _IsNewD as Boolean
    Public _IsNewR as Boolean
    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        If _IsNewP = True Then
            SavePickup(1)
        Else
            SavePickup(0)
        End If
    End Sub
    Private Sub SavePickup(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_Pickup ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtPickupName.Text & "'") 'PickupName
            SQLcommand.append(",'" & txtPickupaddress.Text & "'") 'Pickupaddress
            SQLcommand.append(",'" & txtPickupContact.Text & "'") 'PickupContact
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToPickup()
                _IsNewP = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveFactory(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_Loading ")
            SQLcommand.append("'" & txtIdentF.Text & "'") 'ident
            SQLcommand.append(",'" & txtFactoryName.Text & "'") 'LoadingName
            SQLcommand.append(",'" & txtFactoryaddress.Text & "'") 'Loadingaddress
            SQLcommand.append(",'" & txtFactoryContact.Text & "'") 'LoadingContact
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToFactory()
                _IsNewD = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveReturn(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_Return ")
            SQLcommand.append("'" & txtIdentR.Text & "'") 'Ident
            SQLcommand.append(",'" & txtReturnName.Text & "'") 'ReturnName
            SQLcommand.append(",'" & txtReturnaddress.Text & "'") 'Returnaddress
            SQLcommand.append(",'" & txtReturnContact.Text & "'") 'ReturnContact
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToReturn()
                _IsNewR = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        If _IsNewD = True Then
            SaveFactory(1)
        Else
            SaveFactory(0)
        End If
    End Sub

    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        If _IsNewR = True Then
            SaveReturn(1)
        Else
            SaveReturn(0)
        End If
    End Sub

    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [PickupName], [Pickupaddress], [PickupContact]  FROM [Mas_Pickup] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPickupName.Text = dr("PickupName").ToString
            txtPickupaddress.Text = dr("Pickupaddress").ToString
            txtPickupContact.Text = dr("PickupContact").ToString
            _IsNewP = False
        End If
    End Sub

    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [LoadingName], [Loadingaddress], [LoadingContact]  FROM [Mas_Loading] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtFactoryName.Text = dr("LoadingName").ToString
            txtFactoryaddress.Text = dr("Loadingaddress").ToString
            txtFactoryContact.Text = dr("LoadingContact").ToString
            _IsNewD = False
        End If
    End Sub

    Private Sub Button8_Click(sender as Object, e as Eventargs) Handles Button8.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [ReturnName], [Returnaddress], [ReturnContact]  FROM [Mas_Return] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtReturnName.Text = dr("ReturnName").ToString
            txtReturnaddress.Text = dr("Returnaddress").ToString
            txtReturnContact.Text = dr("ReturnContact").ToString
            _IsNewR = False
        End If
    End Sub
    Private Sub addNewPickup()
        txtIdent.Text = "0" 'Ident
        txtPickupName.ResetText() 'PickupName
        txtPickupaddress.ResetText() 'Pickupaddress
        txtPickupContact.ResetText() 'PickupContact
        _IsNewP = True
    End Sub
    Private Sub addNewFactory()
        txtIdentF.Text = "0" 'ident
        txtFactoryName.ResetText() 'LoadingName
        txtFactoryaddress.ResetText() 'Loadingaddress
        txtFactoryContact.ResetText() 'LoadingContact
        _IsNewD = True
    End Sub
    Private Sub addNewReturn()
        txtIdentR.Text = "0" 'Ident
        txtReturnName.ResetText() 'ReturnName
        txtReturnaddress.ResetText() 'Returnaddress
        txtReturnContact.ResetText() 'ReturnContact
        _IsNewR = True
    End Sub

    Private Sub frmLocation_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        addNewFactory()
        addNewPickup()
        addNewReturn()
        LoadDataToFactory()
        LoadDataToPickup()
        LoadDataToReturn()
    End Sub

    Private Sub Button7_Click(sender as Object, e as Eventargs) Handles Button7.Click
        addNewPickup()
    End Sub

    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click
        addNewFactory()
    End Sub

    Private Sub Button9_Click(sender as Object, e as Eventargs) Handles Button9.Click
        addNewReturn()
    End Sub
    Private Sub LoadDataToPickup()
        Try
            dgvPickup.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Mas_Pickup where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvPickup.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'ReturnName
                    dt.Rows(i)(2).ToString(), 'Returnaddress
                    dt.Rows(i)(3).ToString()  'ReturnContact
                    )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToFactory()
        Try
            dgvDelivery.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Mas_Loading where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvDelivery.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'PickupName
                    dt.Rows(i)(2).ToString(), 'Pickupaddress
                    dt.Rows(i)(3).ToString() 'PickupContact
                    )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub
    Private Sub LoadDataToReturn()
        Try
            dgvReturn.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Mas_Return where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvReturn.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'PickupName
                    dt.Rows(i)(2).ToString(), 'Pickupaddress
                    dt.Rows(i)(3).ToString() 'PickupContact
                    )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    Private Sub dgvPickup_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvPickup.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvPickup.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdent.Text = CInt(dgvPickup.CurrentRow.Cells(0).Value.ToString()) 'Ident
                txtPickupName.Text = dgvPickup.CurrentRow.Cells(1).Value.ToString() 'PickupName
                txtPickupaddress.Text = dgvPickup.CurrentRow.Cells(2).Value.ToString() 'Pickupaddress
                txtPickupContact.Text = dgvPickup.CurrentRow.Cells(3).Value.ToString() 'PickupContact
                _IsNewP = False
            End If
        Catch ex as Exception

        End Try

    End Sub

    Private Sub dgvDelivery_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvDelivery.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvDelivery.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdentF.Text = CInt(dgvDelivery.CurrentRow.Cells(0).Value.ToString()) 'ident
                txtFactoryName.Text = dgvDelivery.CurrentRow.Cells(1).Value.ToString() 'LoadingName
                txtFactoryaddress.Text = dgvDelivery.CurrentRow.Cells(2).Value.ToString() 'Loadingaddress
                txtFactoryContact.Text = dgvDelivery.CurrentRow.Cells(3).Value.ToString() 'LoadingContact
                _IsNewD = False
            End If
        Catch ex as Exception

        End Try

    End Sub

    Private Sub dgvReturn_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvReturn.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvReturn.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdentR.Text = CInt(dgvReturn.CurrentRow.Cells(0).Value.ToString()) 'Ident
                txtReturnName.Text = dgvReturn.CurrentRow.Cells(1).Value.ToString() 'ReturnName
                txtReturnaddress.Text = dgvReturn.CurrentRow.Cells(2).Value.ToString() 'Returnaddress
                txtReturnContact.Text = dgvReturn.CurrentRow.Cells(3).Value.ToString() 'ReturnContact
                _IsNewR = False
            End If
        Catch ex as Exception

        End Try
    End Sub
    Private Sub MetroTextBox1_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox1.ButtonClick
        If _IsNewD = False Then
            _IsNewD = True
            MsgBox("Saving New Data")
        ElseIf _IsNewD = True Then
            _IsNewD = False
            MsgBox("Updating Old Data")
        End If
    End Sub
    Private Sub MetroTextBox2_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox2.ButtonClick
        If _IsNewP = False Then
            _IsNewP = True
            MsgBox("Saving New Data")
        ElseIf _IsNewP = True Then
            _IsNewP = False
            MsgBox("Updating Old Data")
        End If
    End Sub
    Private Sub MetroTextBox3_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox3.ButtonClick
        If _IsNewR = False Then
            _IsNewR = True
            MsgBox("Saving New Data")
        ElseIf _IsNewR = True Then
            _IsNewR = False
            MsgBox("Updating Old Data")
        End If
    End Sub
End Class