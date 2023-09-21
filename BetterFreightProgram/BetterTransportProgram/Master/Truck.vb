Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text

Public Class Truck
    Public _IsNew as Boolean
    Public _IsNewTail as Boolean
    Public _IsNewDriver
    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        If _IsNew = True Then
            SaveTruck(1)
        Else
            SaveTruck(0)
        End If
    End Sub
    Private Sub SaveTruck(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_Truck ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtTruckNo.Text & "'") 'TruckNo
            SQLcommand.append(",'" & txtTruckPlateNo.Text & "'") 'TruckPlateNo
            SQLcommand.append(",'" & txtEngineNo.Text & "'") 'EngineNo
            SQLcommand.append(",'" & txtChassisNo.Text & "'") 'ChassisNo
            SQLcommand.append(",'" & txtTruckBrand.Text & "'") 'TruckBrand
            SQLcommand.append(",'" & txtDriverNameRef.Text & "'")
            SQLcommand.append(",'" & txtDriverIDRef.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                LoadDataToTruck()
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveTail(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_Tail")
            SQLcommand.append("'" & txtIdentT.Text & "'") 'ident
            SQLcommand.append(",'" & txtTailNo.Text & "'") 'TailNo
            SQLcommand.append(",'" & txtTailPlateNo.Text & "'") 'TailPlateNo
            SQLcommand.append(",'" & txtTailType.Text & "'") 'TailType
            SQLcommand.append(",'" & txtTailBrand.Text & "'") 'TailBrand
            SQLcommand.append(",'" & txtTailChassis.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNewTail = False
                LoadDataToTail()
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click
        If _IsNewTail = True Then
            SaveTail(1)
        Else
            SaveTail(0)
        End If
    End Sub
    Private Sub SaveDriver(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_Driver ")
            SQLcommand.append("'" & txtIdentD.Text & "'") 'ident
            SQLcommand.append(",'" & txtDriverName.Text & "'") 'DriverName
            SQLcommand.append(",'" & txtDriverStatus.Text & "'") 'DriverStatus
            SQLcommand.append(",'" & txtDriverID.Text & "'") 'DriverID
            SQLcommand.append(",'" & txtDriverLicense.Text & "'") 'DriverLicense
            SQLcommand.append(",'" & txtDriveraddress.Text & "'") 'Driveraddress
            SQLcommand.append(",'" & txtDriverBankName.Text & "'") 'DriverBankName
            SQLcommand.append(",'" & txtDriverBankNo.Text & "'") 'DriverBankNo
            SQLcommand.append(",'" & txtInsuranceName.Text & "'") 'InsuranceName
            SQLcommand.append(",'" & txtInsuranceaddress.Text & "'") 'Insuranceaddress
            SQLcommand.append(",'" & txtInsuranceTel.Text & "'") 'InsuranceTel
            SQLcommand.append(",'" & txtDriverTruckPlate.Text & "'")
            SQLcommand.append(",'" & txtDriverTruckNo.Text & "'")
            SQLcommand.append(",'" & txtSalary.Text & "'")
            SQLcommand.append(",'" & txtInsurance30k.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNewDriver = False
                LoadDataToDriver()
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button9_Click(sender as Object, e as Eventargs) Handles Button9.Click
        If _IsNewDriver = True Then
            SaveDriver(1)
        Else
            SaveDriver(0)
        End If
    End Sub

    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [TruckNo] ,[TruckPlateNo] ,[EngineNo] ,[ChassisNo] ,[TruckBrand]  FROM [Mas_Truck] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtTruckNo.Text = dr("TruckNo").ToString
            txtTruckPlateNo.Text = dr("TruckPlateNo").ToString
            txtEngineNo.Text = dr("EngineNo").ToString
            txtChassisNo.Text = dr("ChassisNo").ToString
            txtTruckBrand.Text = dr("TruckBrand").ToString
            _IsNew = False
        End If
    End Sub

    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [TailNo] ,[TailPlateNo] ,[TailType] ,[TailBrand] ,[TailChassis]  FROM [Mas_Tail] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtTailNo.Text = dr("TailNo").ToString
            txtTailPlateNo.Text = dr("TailPlateNo").ToString
            txtTailType.Text = dr("TailType").ToString
            txtTailBrand.Text = dr("TailBrand").ToString
            txtTailChassis.Text = dr("TailChassis").ToString
            _IsNewTail = False
        End If
    End Sub

    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [DriverName] ,[DriverStatus] ,[DriverID] ,[DriverLicense] ,[Driveraddress] ,[DriverBankName] ,[DriverBankNo] ,[InsuranceName] ,[Insuranceaddress] ,[InsuranceTel], Salary, Insurance30k, ident  FROM [Mas_Driver] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtIdentD.Text = dr("ident").ToString
            txtDriverName.Text = dr("DriverName").ToString
            txtDriverStatus.Text = dr("DriverStatus").ToString
            txtDriverID.Text = dr("DriverID").ToString
            txtDriverLicense.Text = dr("DriverLicense").ToString
            txtDriveraddress.Text = dr("Driveraddress").ToString
            txtDriverBankName.Text = dr("DriverBankName").ToString
            txtDriverBankNo.Text = dr("DriverBankNo").ToString
            txtInsuranceName.Text = dr("InsuranceName").ToString
            txtInsuranceaddress.Text = dr("Insuranceaddress").ToString
            txtInsuranceTel.Text = dr("InsuranceTel").ToString
            txtSalary.Text = dr("Salary").ToString
            txtInsurance30k.Text = dr("Insurance30k").ToString
            _IsNewDriver = False
        End If
    End Sub

    Private Sub Button7_Click(sender as Object, e as Eventargs) Handles Button7.Click
        addNewTruck()
    End Sub
    Private Sub addNewTruck()
        txtIdent.Text = "0" 'Ident
        txtTruckNo.ResetText() 'TruckNo
        txtTruckPlateNo.ResetText() 'TruckPlateNo
        txtEngineNo.ResetText() 'EngineNo
        txtChassisNo.ResetText() 'ChassisNo
        txtTruckBrand.ResetText() 'TruckBrand
        _IsNew = True

    End Sub
    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        addNewTail()
    End Sub
    Private Sub addNewTail()
        txtIdentT.Text = "0" 'ident
        txtTailNo.ResetText() 'TailNo
        txtTailPlateNo.ResetText() 'TailPlateNo
        txtTailType.ResetText() 'TailType
        txtTailBrand.ResetText() 'TailBrand
        txtTailChassis.ResetText()
        _IsNewTail = True

    End Sub
    Private Sub Button8_Click(sender as Object, e as Eventargs) Handles Button8.Click
        addNewDriver()
    End Sub
    Private Sub addNewDriver()
        txtIdentD.Text = "0" 'ident
        txtDriverName.ResetText() 'DriverName
        txtDriverStatus.ResetText() 'DriverStatus
        txtDriverID.ResetText() 'DriverID
        txtDriverLicense.ResetText() 'DriverLicense
        txtDriveraddress.ResetText() 'Driveraddress
        txtDriverBankName.ResetText() 'DriverBankName
        txtDriverBankNo.ResetText() 'DriverBankNo
        txtInsuranceName.ResetText() 'InsuranceName
        txtInsuranceaddress.ResetText() 'Insuranceaddress
        txtInsuranceTel.ResetText() 'InsuranceTel
        _IsNewDriver = True

    End Sub
    Private Sub Truck_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        addNewDriver()
        addNewTail()
        addNewTruck()
        LoadDataToTruck()
        LoadDataToTail()
        LoadDataToDriver()
    End Sub
    Private Sub LoadDataToTruck()
        Try
            dgvTruck.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Mas_Truck where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvTruck.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'TruckNo
                    dt.Rows(i)(2).ToString(), 'TruckPlateNo
                    dt.Rows(i)(3).ToString(), 'EngineNo
                    dt.Rows(i)(4).ToString(), 'ChassisNo
                    dt.Rows(i)(5).ToString()  'TruckBrand
                   )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToTail()
        Try
            dgvTail.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Mas_Tail where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvTail.Rows.add(dt.Rows(i)(0).ToString(), 'ident
                    dt.Rows(i)(1).ToString(), 'TailNo
                    dt.Rows(i)(2).ToString(), 'TailPlateNo
                    dt.Rows(i)(3).ToString(), 'TailType
                    dt.Rows(i)(4).ToString(),  'TailBrand
                    dt.Rows(i)(5).ToString()
                    )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToDriver()
        Try
            dgvDriver.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Mas_Driver where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvDriver.Rows.add(dt.Rows(i)(0).ToString(), 'ident
                    dt.Rows(i)(1).ToString(), 'DriverName
                    dt.Rows(i)(2).ToString(), 'DriverStatus
                    dt.Rows(i)(3).ToString(), 'DriverID
                    dt.Rows(i)(4).ToString(), 'DriverLicense
                    dt.Rows(i)(5).ToString(), 'Driveraddress
                    dt.Rows(i)(6).ToString(), 'DriverBankName
                    dt.Rows(i)(7).ToString(), 'DriverBankNo
                    dt.Rows(i)(8).ToString(), 'InsuranceName
                    dt.Rows(i)(9).ToString(), 'Insuranceaddress
                    dt.Rows(i)(10).ToString(),  'InsuranceTel
                    dt.Rows(i)(11).ToString(),
                    dt.Rows(i)(12).ToString(),
                    dt.Rows(i)(13).ToString,
                    dt.Rows(i)(14).ToString
                    )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvDriver_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvDriver.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvDriver.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdentD.Text = CInt(dgvDriver.CurrentRow.Cells(0).Value.ToString()) 'ident
                txtDriverName.Text = dgvDriver.CurrentRow.Cells(1).Value.ToString() 'DriverName
                txtDriverStatus.Text = dgvDriver.CurrentRow.Cells(2).Value.ToString() 'DriverStatus
                txtDriverID.Text = dgvDriver.CurrentRow.Cells(3).Value.ToString() 'DriverID
                txtDriverLicense.Text = dgvDriver.CurrentRow.Cells(4).Value.ToString() 'DriverLicense
                txtDriveraddress.Text = dgvDriver.CurrentRow.Cells(5).Value.ToString() 'Driveraddress
                txtDriverBankName.Text = dgvDriver.CurrentRow.Cells(6).Value.ToString() 'DriverBankName
                txtDriverBankNo.Text = dgvDriver.CurrentRow.Cells(7).Value.ToString() 'DriverBankNo
                txtInsuranceName.Text = dgvDriver.CurrentRow.Cells(8).Value.ToString() 'InsuranceName
                txtInsuranceaddress.Text = dgvDriver.CurrentRow.Cells(9).Value.ToString() 'Insuranceaddress
                txtInsuranceTel.Text = dgvDriver.CurrentRow.Cells(10).Value.ToString() 'InsuranceTel
                txtDriverTruckPlate.Text = dgvDriver.CurrentRow.Cells(11).Value.ToString
                txtDriverTruckNo.Text = dgvDriver.CurrentRow.Cells(12).Value.ToString
                txtSalary.Text = dgvDriver.CurrentRow.Cells(13).Value.ToString
                txtInsurance30k.Text = dgvDriver.CurrentRow.Cells(14).Value.ToString
                _IsNewDriver = False
            End If
        Catch ex as Exception

        End Try

    End Sub

    Private Sub dgvTail_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvTail.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvTail.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdentT.Text = CInt(dgvTail.CurrentRow.Cells(0).Value.ToString()) 'ident
                txtTailNo.Text = dgvTail.CurrentRow.Cells(1).Value.ToString() 'TailNo
                txtTailPlateNo.Text = dgvTail.CurrentRow.Cells(2).Value.ToString() 'TailPlateNo
                txtTailType.Text = dgvTail.CurrentRow.Cells(3).Value.ToString() 'TailType
                txtTailBrand.Text = dgvTail.CurrentRow.Cells(4).Value.ToString() 'TailBrand
                txtTailChassis.Text = dgvTail.CurrentRow.Cells(5).Value.ToString()
                _IsNewTail = False
            End If
        Catch ex as Exception

        End Try

    End Sub

    Private Sub dgvTruck_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvTruck.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvTruck.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdent.Text = CInt(dgvTruck.CurrentRow.Cells(0).Value.ToString()) 'Ident
                txtTruckNo.Text = dgvTruck.CurrentRow.Cells(1).Value.ToString() 'TruckNo
                txtTruckPlateNo.Text = dgvTruck.CurrentRow.Cells(2).Value.ToString() 'TruckPlateNo
                txtEngineNo.Text = dgvTruck.CurrentRow.Cells(3).Value.ToString() 'EngineNo
                txtChassisNo.Text = dgvTruck.CurrentRow.Cells(4).Value.ToString() 'ChassisNo
                txtTruckBrand.Text = dgvTruck.CurrentRow.Cells(5).Value.ToString() 'TruckBrand
                _IsNew = False
            End If
        Catch ex as Exception

        End Try

    End Sub

    Private Sub txtDriverTruckPlate_ButtonClick(sender as Object, e as Eventargs) Handles txtDriverTruckPlate.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [TruckNo],[TruckPlateNo] FROM [Mas_Truck] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtDriverTruckNo.Text = dr("TruckNo").ToString
            txtDriverTruckPlate.Text = dr("TruckPlateNo").ToString
        End If
    End Sub

    Private Sub txtDriverNameRef_ButtonClick(sender as Object, e as Eventargs) Handles txtDriverNameRef.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [DriverName],[DriverID] FROM [Mas_Driver] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtDriverNameRef.Text = dr("DriverName").ToString
            txtDriverIDRef.Text = dr("DriverID").ToString
        End If
    End Sub
End Class