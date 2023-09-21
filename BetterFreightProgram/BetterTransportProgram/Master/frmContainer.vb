Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Text

Public Class frmContainer
    Public JobNo as String
    Public Isactive as Boolean
    Public _IsNew1 as Boolean
    'Public _IsNewadv as Boolean
    Private OrderNo as String = ""
    Private Sub frmContainer_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        _IsNew1 = True
        LoadDataToDgv()
        LoadDataToadv()
        LoadSumadv()
        addNewDriver()
        If txtSysUser.Text = "" Then
            txtSysUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName
        End If
        'LoadDataToDgv()
        'Dim CBCell as New DataGridViewComboBoxCell()
        ''CBCell = dgvCost.Rows(0).Cells(6)
        ''CBCell.Items.add("ตั้งเบิก")
        ''CBCell.Items.add("ขอเบิก")
        ''CBCell.Items.add("อนุมัติขอเบิก")
        ''CBCell.Items.add("จ่ายแล้ว")
        ''CBCell.Items.add("รอใบเสร็จ")
        ''CBCell.Items.add("เคลียร์ใบเสร็จแล้ว")
        'CBCell = dgvCostadv.Rows(0).Cells(3)
        'CBCell.Items.add("aDV")
        'CBCell.Items.add("COST")
        'CBCell = dgvCostadv.Rows(0).Cells(8)
        'CBCell.Items.add("ตั้งเบิก")
        'CBCell.Items.add("ขอเบิก")
        'CBCell.Items.add("อนุมัติขอเบิก")
        'CBCell.Items.add("จ่ายแล้ว")
        'CBCell.Items.add("รอใบเสร็จ")
        'CBCell.Items.add("เคลียร์ใบเสร็จแล้ว")
    End Sub
    Private Sub LoadSumadv()
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT SUM([advamount]) + SUM([Chargeamount]) as SumadvCharge
  FROM [PV_Description]
  where OrderNo ='" & txtOrderNo.Text & "' and JobNo='" & txtJobNo.Text & "' and active='1'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtWithdrawalamount.Text = dr("SumadvCharge").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveDriver(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateDriver ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'ident
            SQLcommand.append(",'" & txtCode.Text & "'") 'Code
            SQLcommand.append(",'" & cboContainerStatus.Text & "'") 'ContainerStatus
            SQLcommand.append(",'" & txtadvancePayment.Text & "'") 'advancePayment
            SQLcommand.append(",'" & txtTruckNo.Text & "'") 'TruckNo
            SQLcommand.append(",'" & txtWithdrawalamount.Text & "'") 'Withdrawalamount
            SQLcommand.append(",'" & txtadvanceNo.Text & "'") 'advanceNo
            SQLcommand.append(",'" & txtDriver.Text & "'") 'Driver
            SQLcommand.append(",'" & txtHeadNo.Text & "'") 'HeadNo
            SQLcommand.append(",'" & txtTailNo.Text & "'") 'TailNo
            SQLcommand.append(",'" & txtContainerNo.Text & "'") 'ContainerNo
            SQLcommand.append(",'" & txtSealNo.Text & "'") 'SealNo
            SQLcommand.append(",'" & ToDBDate(txtarriveTruckYardDate.Text) & "'") 'arriveTruckYardDate
            SQLcommand.append(",'" & ToDBDate(txtExitYardDate.Text) & "'") 'ExitYardDate
            SQLcommand.append(",'" & ToDBDate(txtarriveFactoryDate.Text) & "'") 'arriveFactoryDate
            SQLcommand.append(",'" & ToDBDate(txtPackingDate.Text) & "'") 'PackingDate
            SQLcommand.append(",'" & ToDBDate(txtLeaveFactoryDate.Text) & "'") 'LeaveFactoryDate
            SQLcommand.append(",'" & ToDBDate(txtReturnDate.Text) & "'") 'ReturnDate
            SQLcommand.append(",'" & ToDBDate(txtDateofJobNotification.Text) & "'") 'DateofJobNotification
            SQLcommand.append(",'" & txtJobNo.Text & "'") 'JobNo
            SQLcommand.append(",'" & txtOrderNo.Text & "'") 'OrderNo
            SQLcommand.append(",'" & txtBTTLocation.Text & "'") 'BTTLocation
            SQLcommand.append(",'" & txtPickupLocation.Text & "'") 'PickupLocation
            SQLcommand.append(",'" & txtLoadingLocation.Text & "'") 'LoadingLocation
            SQLcommand.append(",'" & txtReturnLocation.Text & "'") 'ReturnLocation
            SQLcommand.append(",'" & txtarriveTruckYardTime.Text & "'") 'arriveTruckYardTime
            SQLcommand.append(",'" & txtExitYardTime.Text & "'") 'ExitYardTime
            SQLcommand.append(",'" & txtarriveFactoryTime.Text & "'") 'arriveFactoryTime
            SQLcommand.append(",'" & txtPackingTime.Text & "'") 'PackingTime
            SQLcommand.append(",'" & txtLeaveFactoryTime.Text & "'") 'LeaveFactoryTime
            SQLcommand.append(",'" & txtReturnTime.Text & "'") 'ReturnTime
            SQLcommand.append(",'" & txtTimeofJobNotification.Text & "'") 'TimeofJobNotification
            SQLcommand.append(",'" & CDbl(txtBTTDistance.Text) & "'") 'BTTDistance
            SQLcommand.append(",'" & CDbl(txtLoadDistance.Text) & "'") 'LoadDistance
            SQLcommand.append(",'" & CDbl(txtPickupDistance.Text) & "'") 'PickupDistance
            SQLcommand.append(",'" & CDbl(txtReturnDistance.Text) & "'") 'ReturnDistance
            SQLcommand.append(",'" & CDbl(txtRoute.Text) & "'") 'Route
            SQLcommand.append(",'" & CDbl(txtRoutePrice.Text) & "'") 'RoutePrice
            SQLcommand.append(",'" & CDbl(txtRouteRate.Text) & "'") 'RouteRate
            SQLcommand.append(",'" & txtBooking.Text & "'")
            SQLcommand.append(",'" & txtContainerType.Text & "'")
            SQLcommand.append(",'" & CDbl(txtQty.Text) & "'") 'Qty
            SQLcommand.append(",'" & CInt(txtactive.Text) & "'") ' active
            SQLcommand.append(",'" & txtSysUser.Text & "'")
            SQLcommand.append(",'" & txteighty.Text & "'")
            SQLcommand.append(",'" & txttwenty.Text & "'")
            SQLcommand.append(",'" & txtUnitPrice.Text & "'")
            SQLcommand.append(",'" & txtDriverRemark.Text & "'")
            SQLcommand.append(",'" & ToDBDate(txtDropDate.Text) & "'")
            SQLcommand.append(",'" & ToDBDate(txtactualReturnDate.Text) & "'")
            SQLcommand.append(",'" & txtDropTime.Text & "'")
            SQLcommand.append(",'" & txtactualReturnTime.Text & "'")
            SQLcommand.append(",'" & CInt(chkIsJob.CheckState) & "'")
            SQLcommand.append(",'" & CInt(chkIsSubContract.CheckState) & "'")
            SQLcommand.append(",'" & txtRef1.Text & "'")
            SQLcommand.append(",'" & txtRef2.Text & "'")
            SQLcommand.append(",'" & txtReceiptNo.Text & "'")
            SQLcommand.append(",'" & txtFuelDiff.Text & "'")
            SQLcommand.append(",'" & txtReceiptFuelPrice.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew1 = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        LoadDataToDgv()
    End Sub
    Private Sub LoadDataToDgv()
        Try
            dgvDriver.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a as String = txtJobNo.Text
            Dim str as String = "SELECT * FROM Driver where JobNo='" & txtJobNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvDriver.Rows.add(dt.Rows(i)(0).ToString(), 'ident
                           dt.Rows(i)(1).ToString(),  'Code
                           dt.Rows(i)(2).ToString(),  'ContainerStatus
                           dt.Rows(i)(3).ToString(),  'advancePayment
                           dt.Rows(i)(4).ToString(),  'TruckNo
                           dt.Rows(i)(5).ToString(),  'Withdrawalamount
                           dt.Rows(i)(6).ToString(),  'advanceNo
                           dt.Rows(i)(7).ToString(),  'Driver
                           dt.Rows(i)(8).ToString(),  'HeadNo
                           dt.Rows(i)(9).ToString(),  'TailNo
                           dt.Rows(i)(10).ToString(), 'ContainerNo
                           dt.Rows(i)(11).ToString(), 'SealNo
                           dt.Rows(i)(12).ToString(), 'arriveTruckYardDate
                           dt.Rows(i)(13).ToString(), 'ExitYardDate
                           dt.Rows(i)(14).ToString(), 'arriveFactoryDate
                           dt.Rows(i)(15).ToString(), 'PackingDate
                           dt.Rows(i)(16).ToString(), 'LeaveFactoryDate
                           dt.Rows(i)(17).ToString(), 'ReturnDate
                           dt.Rows(i)(18).ToString(), 'DateofJobNotification
                           dt.Rows(i)(19).ToString(), 'JobNo
                           dt.Rows(i)(20).ToString(), 'OrderNo
                           dt.Rows(i)(21).ToString(), 'BTTLocation
                           dt.Rows(i)(22).ToString(), 'PickupLocation
                           dt.Rows(i)(23).ToString(), 'LoadingLocation
                           dt.Rows(i)(24).ToString(), 'ReturnLocation
                           dt.Rows(i)(25).ToString(), 'arriveTruckYardTime
                           dt.Rows(i)(26).ToString(), 'ExitYardTime
                           dt.Rows(i)(27).ToString(), 'arriveFactoryTime
                           dt.Rows(i)(28).ToString(), 'PackingTime
                           dt.Rows(i)(29).ToString(), 'LeaveFactoryTime
                           dt.Rows(i)(30).ToString(), 'ReturnTime
                           dt.Rows(i)(31).ToString(), 'TimeofJobNotification
                           dt.Rows(i)(32).ToString(), 'BTTDistance
                           dt.Rows(i)(33).ToString(), 'LoadDistance
                           dt.Rows(i)(34).ToString(), 'PickupDistance
                           dt.Rows(i)(35).ToString(), 'ReturnDistance
                           dt.Rows(i)(36).ToString(), 'Route
                           dt.Rows(i)(37).ToString(), 'RoutePrice
                           dt.Rows(i)(38).ToString(), 'RouteRate
                           dt.Rows(i)(39).ToString(), 'Booking
                           dt.Rows(i)(40).ToString(), 'ContainerType
                           dt.Rows(i)(41).ToString(), 'Qty
                           dt.Rows(i)(42).ToString(), 'active
                           dt.Rows(i)(43).ToString(), 'SysUser
                           dt.Rows(i)(44).ToString(), 'eighty
                           dt.Rows(i)(45).ToString(), 'twenty
                           dt.Rows(i)(46).ToString(), 'UnitPrice
                           dt.Rows(i)(47).ToString(), 'DriverRemark
                           dt.Rows(i)(54).ToString(), 'Isjob
                           dt.Rows(i)(55).ToString(), 'IsSubContract
                           dt.Rows(i)(56).ToString(), 'Ref1
                           dt.Rows(i)(57).ToString(),  'Ref2
                           dt.Rows(i)(67).ToString(),
                           dt.Rows(i)(68).ToString(),
                           dt.Rows(i)(69).ToString()
                           )
                    'dt.Rows(i)(39).ToString()

                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Save_Click(sender as Object, e as Eventargs) Handles Save.Click
        'SaveDriver(1)
        'SaveCost(1)
        ' MsgBox(_IsNew)
        If txtOrderNo.Text = "ERROR" Then
            MsgBox("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้ กรุณารีสตาร์ทโปรแกรม")
            addNewDriver()
            Exit Sub
        ElseIf txtOrderNo.Text = "" Then
            MsgBox("Input Order First")
            Exit Sub
        Else
            If _IsNew1 = True Then
                SaveDriver(1)
                UpdateLog("Driver", "Open")
            Else
                SaveDriver(0)
                UpdateLog("Driver", "Edit")
            End If
        End If
        'Saveadv(1)
    End Sub
    Private Sub UpdateLog(DocType as String, actionType as String)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_UpdateLog ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'ident
            SQLcommand.append(",'" & UserProfile.U_FName & " " & UserProfile.U_LName & "'")
            SQLcommand.append(",'" & UserProfile.U_FName & " " & UserProfile.U_LName & "'")
            SQLcommand.append(",'" & UserProfile.U_FName & " " & UserProfile.U_LName & "'")
            SQLcommand.append(",'" & DocType & "'")
            SQLcommand.append(",'" & actionType & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew1 = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub txtDriver_ButtonClick(sender as Object, e as Eventargs) Handles txtDriver.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [DriverName], [DriverTruckPlate], [DriverTruckNo]  FROM [Mas_Driver] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtDriver.Text = dr("DriverName").ToString
            txtTruckNo.Text = dr("DriverTruckNo").ToString
            txtHeadNo.Text = dr("DriverTruckPlate").ToString
        End If
    End Sub
    Private Sub txtTruckNo_ButtonClick(sender as Object, e as Eventargs) Handles txtTruckNo.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [TruckNo],[TruckPlateNo],[Ident]  FROM [Mas_Truck] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtTruckNo.Text = dr("TruckNo").ToString
            txtHeadNo.Text = dr("TruckPlateNo").ToString
            txtTruckHeadRef.Text = dr("Ident").ToString
        End If
    End Sub
    Private Sub Saveadv()
        Try
            Dim a as Integer = 0
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = ""
            For row as Integer = 0 To dgvCostadv.Rows.Count - 2
                Try
                    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateadv ")
                    SQLcommand.append("'" & CInt(dgvCostadv.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(2).Value.ToString & "'") 'type
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(4).Value.ToString & "'") 'advType
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(1).Value.ToString & "'") 'type
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(8).Value.ToString & "'") 'amount
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(9).Value.ToString & "'") 'RecieptNo
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(10).Value.ToString & "'") 'advDriver
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(11).Value.ToString & "'") 'advContainerNo
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(12).Value.ToString & "'") 'advStatus
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(13).Value.ToString & "'")
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(14).Value.ToString & "'")
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(16).Value.ToString & "'")
                    SQLcommand.append(",'" & txtJobNo.Text & "'")
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(6).Value.ToString & "'")
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(7).Value.ToString & "'")
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(5).Value.ToString & "'")
                    SQLcommand.append(",'" & dgvCostadv.Rows(row).Cells(15).Value.ToString & "'") '//Insert Or Update
                    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                        ' MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        a += 1
                        'If dgvCostadv.Rows(row).Cells(2).Value IsNot Nothing Then
                        '    str &= dgvCostadv.Rows(row).Cells(2).Value.ToString & vbCrLf
                        'End If
                        'MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail " & vbCrLf & str, "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Catch ex as Exception
                    a += 1
                    'str &= dgvCostadv.Rows(row).Cells(2).Value.ToString & vbCrLf
                    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try
            Next

            If a = 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToadv()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail " & vbCrLf & str, "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            LoadDataToadv()
            addCostadv()
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    'Private Sub SaveCost(_insert as Integer)
    '    Try
    '        Dim nection as New OleDb.OleDbConnection()
    '        nection = ConnectDB()
    '        For row as Integer = 0 To dgvCost.Rows.Count - 1
    '            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateCost ")
    '            SQLcommand.append("'" & CInt(dgvCost.Rows(row).Cells(0).Value) & "'") 'Ident
    '            SQLcommand.append(",'" & dgvCost.Rows(row).Cells(1).Value.ToString & "'") 'CostCode
    '            SQLcommand.append(",'" & dgvCost.Rows(row).Cells(2).Value.ToString & "'") 'CostDriver
    '            SQLcommand.append(",'" & dgvCost.Rows(row).Cells(3).Value.ToString & "'") 'CostContainerNo
    '            SQLcommand.append(",'" & dgvCost.Rows(row).Cells(4).Value.ToString & "'") 'Cost
    '            SQLcommand.append(",'" & dgvCost.Rows(row).Cells(5).Value.ToString & "'") 'CostValue
    '            SQLcommand.append(",'" & dgvCost.Rows(row).Cells(6).Value.ToString & "'") 'CostStatus
    '            'SQLcommand.append(",'" & dgvCost.Rows(row).Cells(7).Value.ToString & "'") 'CostGLCode
    '            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
    '            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
    '            If result = 1 Then
    '                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Else
    '                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '            End If
    '            nection.Close()
    '        Next
    '    Catch ex as Exception
    '        MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    End Try
    'End Sub
    Private Sub dgvCostadv_Rowsadded(sender as Object, e as DataGridViewRowsaddedEventargs) Handles dgvCostadv.Rowsadded
        Try
            Dim CBCell as New DataGridViewComboBoxCell()
            CBCell = dgvCostadv.Rows(e.RowIndex).Cells(1)
            CBCell.Items.add("aDV")
            CBCell.Items.add("COST")
            CBCell.Items.add("aTK")
            CBCell = dgvCostadv.Rows(e.RowIndex).Cells(12)
            CBCell.Items.add("ตั้งเบิก")
            CBCell.Items.add("ขอเบิก")
            CBCell.Items.add("อนุมัติขอเบิก")
            CBCell.Items.add("จ่ายแล้ว")
            CBCell.Items.add("รอใบเสร็จ")
            CBCell.Items.add("เคลียร์ใบเสร็จแล้ว")
            dgvCostadv.Rows(e.RowIndex).Cells(13).Value = txtOrderNo.Text
            dgvCostadv.Rows(e.RowIndex).Cells(10).Value = txtDriver.Text
            dgvCostadv.Rows(e.RowIndex).Cells(11).Value = txtContainerNo.Text
            If dgvCostadv.Rows(e.RowIndex).Cells(15).Value = "" Then
                dgvCostadv.Rows(e.RowIndex).Cells(5).Value = "0"
                dgvCostadv.Rows(e.RowIndex).Cells(6).Value = "0"
                dgvCostadv.Rows(e.RowIndex).Cells(7).Value = "0"
            End If
            'dgvCostadv.Rows(e.RowIndex).Cells(11).Value = "1"
            'dgvCostadv.Rows(e.RowIndex).Cells(12).Value = "1"
            If dgvCostadv.Rows(e.RowIndex).Cells(16).Value = "" Then
                dgvCostadv.Rows(e.RowIndex).Cells(16).Value = UserProfile.U_FName & "  " & UserProfile.U_LName
            End If
            dgvCostadv.Rows(e.RowIndex).Cells(17).Value = txtJobNo.Text
            '  dgvCostadv.Rows(e.RowIndex).Cells(11).Value = "1"
            'Try
            '    If Not String.IsNullOrEmpty(dgvCostadv.Rows(e.RowIndex).Cells(2).Value.ToString) Then 'Code
            '        'dgvCostadv.Rows(e.RowIndex).Cells(10).Value = txtOrderNo.Text 'OrderNo
            '        dgvCostadv.Rows(e.RowIndex).Cells(11).Value = "1"
            '    End If
            'Catch ex as Exception
            'End Try
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub addCostandadv()
        Dim advamt as Double = 0
        Dim cstamt as Double = 0
        If dgvCostadv.Rows.Count > 0 Then
            For i as Integer = 0 To dgvCostadv.Rows.Count - 1
                If dgvCostadv.Rows(i).Cells(1).Value = "aDV" Or dgvCostadv.Rows(i).Cells(1).Value = "aTK" Then
                    advamt += dgvCostadv.Rows(i).Cells(8).Value
                Else
                    cstamt += dgvCostadv.Rows(i).Cells(8).Value
                End If
            Next
            txtadv.Text = advamt.ToString("#,##0.00")
            txtCost.Text = cstamt.ToString("#,##0.00")
        Else
            txtadv.Text = advamt.ToString("#,##0.00")
            txtCost.Text = cstamt.ToString("#,##0.00")
        End If
        txtTotalamount.Text = (CDbl(txtWithdrawalamount.Text) - (CDbl(txtadv.Text) + CDbl(txtCost.Text))).ToString("#,##0.00")
        If txtTotalamount.Text = "0" Then
            txtadvStatus.Text = "พอดี"
        ElseIf txtTotalamount.Text < "1" Then
            txtadvStatus.Text = "จ่ายเงินขาด"
        ElseIf txtTotalamount.Text =
        "จ่ายเงิน" Then
        End If
    End Sub
    Private Sub dgvDriver_CellMouseDoubleClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvDriver.CellMouseDoubleClick
        If e.RowIndex < 0 Or e.RowIndex > dgvDriver.Rows.Count - 1 Then Exit Sub
        If e.RowIndex >= 0 Then
            Dim frm as New frmadvanceRequest
            'frm.txtIdent.Text = txtIdent.Text
            frm.txtJobNo.Text = txtJobNo.Text
            frm.txtQty.Text = txtQty.Text
            frm.txtVendorName.Text = txtDriver.Text
            frm.txtBookingNo.Text = txtBooking.Text
            ' frm.txtSICode.Text = txtCode.Text
            frm.txtOrderNo.Text = txtOrderNo.Text
            'frm.txtadvamount.Text = txtWithdrawalamount.Text
            frm.txtadvNo.Text = txtadvanceNo.Text
            'frm.advamount = txtWithdrawalamount.Text
            frm.advEighty = txteighty.Text
            frm.advTwenty = txttwenty.Text
            frm.advTen = txtUnitPrice.Text
            frm.txtDriverIdent.Text = txtIdent.Text
            frm.txtContainerType.Text = txtContainerType.Text
            frm.ShowDialog()
            frm._IsNew = False
            frm._IsNewD = False
            txtWithdrawalamount.Text = frm.txtNetPayment.Text
            If txtadvanceNo.Text = vbNullString Then
                txtadvanceNo.Text = frm.txtadvNo.Text
                addadvNo(0)
            End If
            Dim advamt as Double = 0
            Dim cstamt as Double = 0
            If dgvCostadv.Rows.Count > 0 Then
                For i as Integer = 0 To dgvCostadv.Rows.Count - 1
                    If dgvCostadv.Rows(i).Cells(1).Value = "aDV" Or dgvCostadv.Rows(i).Cells(1).Value = "aTK" Then
                        advamt += dgvCostadv.Rows(i).Cells(8).Value
                    Else
                        cstamt += dgvCostadv.Rows(i).Cells(8).Value
                    End If
                Next
                txtadv.Text = advamt.ToString("#,##0.00")
                txtCost.Text = cstamt.ToString("#,##0.00")
            Else
                txtadv.Text = advamt.ToString("#,##0.00")
                txtCost.Text = cstamt.ToString("#,##0.00")
            End If
            txtTotalamount.Text = (CDbl(txtWithdrawalamount.Text) - (CDbl(txtadv.Text) + CDbl(txtCost.Text))).ToString("#,##0.00")
            If txtTotalamount.Text = "0" Then
                txtadvStatus.Text = "พอดี"
            ElseIf txtTotalamount.Text < "1" Then
                txtadvStatus.Text = "จ่ายเงินขาด"
            ElseIf txtTotalamount.Text =
            "จ่ายเงิน" Then

            End If

        End If
        LoadSumadv()
    End Sub
    Private Sub SaveNetPayment()
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a as Integer = 0
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_SaveWithdrawalamount ")
            SQLcommand.append("'" & txtWithdrawalamount.Text & "'") 'Ident
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
            Else
                a += 1
            End If
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()

        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub addadvNo(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateDriver ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'ident
            SQLcommand.append(",'" & txtCode.Text & "'") 'Code
            SQLcommand.append(",'" & cboContainerStatus.Text & "'") 'ContainerStatus
            SQLcommand.append(",'" & txtadvancePayment.Text & "'") 'advancePayment
            SQLcommand.append(",'" & txtTruckNo.Text & "'") 'TruckNo
            SQLcommand.append(",'" & txtWithdrawalamount.Text & "'") 'Withdrawalamount
            SQLcommand.append(",'" & txtadvanceNo.Text & "'") 'advanceNo
            SQLcommand.append(",'" & txtDriver.Text & "'") 'Driver
            SQLcommand.append(",'" & txtHeadNo.Text & "'") 'HeadNo
            SQLcommand.append(",'" & txtTailNo.Text & "'") 'TailNo
            SQLcommand.append(",'" & txtContainerNo.Text & "'") 'ContainerNo
            SQLcommand.append(",'" & txtSealNo.Text & "'") 'SealNo
            SQLcommand.append(",'" & ToDBDate(txtarriveTruckYardDate.Text) & "'") 'arriveTruckYardDate
            SQLcommand.append(",'" & ToDBDate(txtExitYardDate.Text) & "'") 'ExitYardDate
            SQLcommand.append(",'" & ToDBDate(txtarriveFactoryDate.Text) & "'") 'arriveFactoryDate
            SQLcommand.append(",'" & ToDBDate(txtPackingDate.Text) & "'") 'PackingDate
            SQLcommand.append(",'" & ToDBDate(txtLeaveFactoryDate.Text) & "'") 'LeaveFactoryDate
            SQLcommand.append(",'" & ToDBDate(txtReturnDate.Text) & "'") 'ReturnDate
            SQLcommand.append(",'" & ToDBDate(txtDateofJobNotification.Text) & "'") 'DateofJobNotification
            SQLcommand.append(",'" & txtJobNo.Text & "'") 'JobNo
            SQLcommand.append(",'" & txtOrderNo.Text & "'") 'OrderNo
            SQLcommand.append(",'" & txtBTTLocation.Text & "'") 'BTTLocation
            SQLcommand.append(",'" & txtPickupLocation.Text & "'") 'PickupLocation
            SQLcommand.append(",'" & txtLoadingLocation.Text & "'") 'LoadingLocation
            SQLcommand.append(",'" & txtReturnLocation.Text & "'") 'ReturnLocation
            SQLcommand.append(",'" & txtarriveTruckYardTime.Text & "'") 'arriveTruckYardTime
            SQLcommand.append(",'" & txtExitYardTime.Text & "'") 'ExitYardTime
            SQLcommand.append(",'" & txtarriveFactoryTime.Text & "'") 'arriveFactoryTime
            SQLcommand.append(",'" & txtPackingTime.Text & "'") 'PackingTime
            SQLcommand.append(",'" & txtLeaveFactoryTime.Text & "'") 'LeaveFactoryTime
            SQLcommand.append(",'" & txtReturnTime.Text & "'") 'ReturnTime
            SQLcommand.append(",'" & txtTimeofJobNotification.Text & "'") 'TimeofJobNotification
            SQLcommand.append(",'" & CDbl(txtBTTDistance.Text) & "'") 'BTTDistance
            SQLcommand.append(",'" & CDbl(txtLoadDistance.Text) & "'") 'LoadDistance
            SQLcommand.append(",'" & CDbl(txtPickupDistance.Text) & "'") 'PickupDistance
            SQLcommand.append(",'" & CDbl(txtReturnDistance.Text) & "'") 'ReturnDistance
            SQLcommand.append(",'" & CDbl(txtRoute.Text) & "'") 'Route
            SQLcommand.append(",'" & CDbl(txtRoutePrice.Text) & "'") 'RoutePrice
            SQLcommand.append(",'" & CDbl(txtRouteRate.Text) & "'") 'RouteRate
            SQLcommand.append(",'" & txtBooking.Text & "'")
            SQLcommand.append(",'" & txtContainerType.Text & "'")
            SQLcommand.append(",'" & CDbl(txtQty.Text) & "'") 'Qty
            SQLcommand.append(",'" & CInt(txtactive.Text) & "'") ' active
            SQLcommand.append(",'" & txtSysUser.Text & "'")
            SQLcommand.append(",'" & txteighty.Text & "'")
            SQLcommand.append(",'" & txttwenty.Text & "'")
            SQLcommand.append(",'" & txtUnitPrice.Text & "'")
            SQLcommand.append(",'" & txtDriverRemark.Text & "'")
            SQLcommand.append(",'" & ToDBDate(txtDropDate.Text) & "'")
            SQLcommand.append(",'" & ToDBDate(txtactualReturnDate.Text) & "'")
            SQLcommand.append(",'" & txtDropTime.Text & "'")
            SQLcommand.append(",'" & txtactualReturnTime.Text & "'")
            SQLcommand.append(",'" & CInt(chkIsJob.CheckState) & "'")
            SQLcommand.append(",'" & CInt(chkIsSubContract.CheckState) & "'")
            SQLcommand.append(",'" & txtRef1.Text & "'")
            SQLcommand.append(",'" & txtRef2.Text & "'")
            SQLcommand.append(",'" & txtReceiptNo.Text & "'")
            SQLcommand.append(",'" & txtFuelDiff.Text & "'")
            SQLcommand.append(",'" & txtReceiptFuelPrice.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                'MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew1 = False
            Else
                'MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        LoadDataToDgv()
    End Sub
    Private Sub dgvDriver_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvDriver.CellMouseClick
        _IsNew1 = False
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvDriver.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdent.Text = CInt(dgvDriver.CurrentRow.Cells(0).Value.ToString()) 'ident
                txtCode.Text = dgvDriver.CurrentRow.Cells(1).Value.ToString() 'Code
                cboContainerStatus.Text = dgvDriver.CurrentRow.Cells(2).Value.ToString() 'ContainerStatus
                txtadvancePayment.Text = dgvDriver.CurrentRow.Cells(3).Value.ToString() 'advancePayment
                txtTruckNo.Text = dgvDriver.CurrentRow.Cells(4).Value.ToString() 'TruckNo
                txtWithdrawalamount.Text = dgvDriver.CurrentRow.Cells(5).Value.ToString() 'Withdrawalamount
                txtadvanceNo.Text = dgvDriver.CurrentRow.Cells(6).Value.ToString() 'advanceNo
                txtDriver.Text = dgvDriver.CurrentRow.Cells(7).Value.ToString() 'Driver
                txtHeadNo.Text = dgvDriver.CurrentRow.Cells(8).Value.ToString() 'HeadNo
                txtTailNo.Text = dgvDriver.CurrentRow.Cells(9).Value.ToString() 'TailNo
                txtContainerNo.Text = dgvDriver.CurrentRow.Cells(10).Value.ToString() 'ContainerNo
                txtSealNo.Text = dgvDriver.CurrentRow.Cells(11).Value.ToString() 'SealNo
                txtarriveTruckYardDate.Text = DBDate(dgvDriver.CurrentRow.Cells(12).Value.ToString()) 'arriveTruckYardDate
                txtExitYardDate.Text = DBDate(dgvDriver.CurrentRow.Cells(13).Value.ToString()) 'ExitYardDate
                txtarriveFactoryDate.Text = DBDate(dgvDriver.CurrentRow.Cells(14).Value.ToString()) 'arriveFactoryDate
                txtPackingDate.Text = DBDate(dgvDriver.CurrentRow.Cells(15).Value.ToString()) 'PackingDate
                txtLeaveFactoryDate.Text = DBDate(dgvDriver.CurrentRow.Cells(16).Value.ToString()) 'LeaveFactoryDate
                txtReturnDate.Text = DBDate(dgvDriver.CurrentRow.Cells(17).Value.ToString()) 'ReturnDate
                txtDateofJobNotification.Text = DBDate(dgvDriver.CurrentRow.Cells(18).Value.ToString()) 'DateofJobNotification
                txtJobNo.Text = dgvDriver.CurrentRow.Cells(19).Value.ToString() 'JobNo
                txtOrderNo.Text = dgvDriver.CurrentRow.Cells(20).Value.ToString() 'OrderNo
                txtBTTLocation.Text = dgvDriver.CurrentRow.Cells(21).Value.ToString() 'BTTLocation
                txtPickupLocation.Text = dgvDriver.CurrentRow.Cells(22).Value.ToString() 'PickupLocation
                txtLoadingLocation.Text = dgvDriver.CurrentRow.Cells(23).Value.ToString() 'LoadingLocation
                txtReturnLocation.Text = dgvDriver.CurrentRow.Cells(24).Value.ToString() 'ReturnLocation
                txtarriveTruckYardTime.Text = dgvDriver.CurrentRow.Cells(25).Value.ToString() 'arriveTruckYardTime
                txtExitYardTime.Text = dgvDriver.CurrentRow.Cells(26).Value.ToString() 'ExitYardTime
                txtarriveFactoryTime.Text = dgvDriver.CurrentRow.Cells(27).Value.ToString() 'arriveFactoryTime
                txtPackingTime.Text = dgvDriver.CurrentRow.Cells(28).Value.ToString() 'PackingTime
                txtLeaveFactoryTime.Text = dgvDriver.CurrentRow.Cells(29).Value.ToString() 'LeaveFactoryTime
                txtReturnTime.Text = dgvDriver.CurrentRow.Cells(30).Value.ToString() 'ReturnTime
                txtTimeofJobNotification.Text = dgvDriver.CurrentRow.Cells(31).Value.ToString() 'TimeofJobNotification
                txtBTTDistance.Text = dgvDriver.CurrentRow.Cells(32).Value.ToString() 'BTTDistance
                txtLoadDistance.Text = dgvDriver.CurrentRow.Cells(33).Value.ToString() 'LoadDistance
                txtPickupDistance.Text = dgvDriver.CurrentRow.Cells(34).Value.ToString() 'PickupDistance
                txtReturnDistance.Text = dgvDriver.CurrentRow.Cells(35).Value.ToString() 'ReturnDistance
                txtRoute.Text = dgvDriver.CurrentRow.Cells(36).Value.ToString() 'Route
                txtRoutePrice.Text = dgvDriver.CurrentRow.Cells(37).Value.ToString() 'RoutePrice
                txtRouteRate.Text = dgvDriver.CurrentRow.Cells(38).Value.ToString() 'RouteRate
                txtBooking.Text = dgvDriver.CurrentRow.Cells(39).Value.ToString() 'Booking
                txtContainerType.Text = dgvDriver.CurrentRow.Cells(40).Value.ToString() 'ContainerType
                txtQty.Text = CDbl(dgvDriver.CurrentRow.Cells(41).Value.ToString()) ' Qty
                txtactive.Text = CInt(dgvDriver.CurrentRow.Cells(42).Value.ToString()) 'active
                txtSysUser.Text = dgvDriver.CurrentRow.Cells(43).Value.ToString() 'SysUser
                txteighty.Text = dgvDriver.CurrentRow.Cells(44).Value.ToString()
                txttwenty.Text = dgvDriver.CurrentRow.Cells(45).Value.ToString()
                txtUnitPrice.Text = dgvDriver.CurrentRow.Cells(46).Value.ToString() 'UnitPrice
                txtDriverRemark.Text = dgvDriver.CurrentRow.Cells(47).Value.ToString() 'DriverRemark
                chkIsJob.Checked = CInt(dgvDriver.CurrentRow.Cells(48).Value) 'Isjob
                chkIsSubContract.Checked = CInt(dgvDriver.CurrentRow.Cells(49).Value) 'IsSubContract
                txtRef1.Text = dgvDriver.CurrentRow.Cells(50).Value.ToString
                txtRef2.Text = dgvDriver.CurrentRow.Cells(51).Value.ToString
                txtReceiptNo.Text = dgvDriver.CurrentRow.Cells(52).Value.ToString
                txtFuelDiff.Text = dgvDriver.CurrentRow.Cells(53).Value.ToString
                txtReceiptFuelPrice.Text = dgvDriver.CurrentRow.Cells(54).Value.ToString
                _IsNew1 = False
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        LoadDataToadv()
        addCostadv()
        addCostandadv()
    End Sub
    Private Sub addCostadv()
        Try
            Dim adv as Double = 0
            Dim Cost as Double = 0
            If dgvCostadv.Rows.Count > 0 Then
                For i as Integer = 0 To dgvCostadv.Rows.Count - 2
                    If dgvCostadv.Rows(i).Cells(1).Value.ToString = "aDV" Then
                        adv += dgvCostadv.Rows(i).Cells(8).Value
                    Else
                        Cost += dgvCostadv.Rows(i).Cells(8).Value
                    End If
                Next
                txtadv.Text = adv.ToString("#,##0.00")
                txtCost.Text = Cost.ToString("#,##0.00")
            Else
                txtadv.Text = adv.ToString("#,##0.00")
                txtCost.Text = Cost.ToString("#,##0.00")
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

        'txtTotalamount.Text = (CDbl(txtWithdrawalamount.Text) - CDbl(txtadv.Text) - CDbl(txtCost.Text)).ToString("#,##0.00")
        'Select Case CDbl(txtTotalamount.Text)
        '    Case < 0
        '        txtadvStatus.Text = "จ่ายเพิ่มให้คนขับ"
        '    Case > 0
        '        txtadvStatus.Text = "รับเงินคืนจากคนขับ"
        '    Case = 0
        '        txtadvStatus.Text = "จ่ายเงินพอดี"
        'End Select
    End Sub
    Private Sub addNewDriver()
        txtIdent.Text = "0" 'ident
        txtCode.ResetText() 'Code
        cboContainerStatus.ResetText() 'ContainerStatus
        txtadvancePayment.ResetText() 'advancePayment
        txtTruckNo.ResetText() 'TruckNo
        txtWithdrawalamount.ResetText() 'Withdrawalamount
        txtadvanceNo.ResetText() 'advanceNo
        txtDriver.ResetText() 'Driver
        txtHeadNo.ResetText() 'HeadNo
        txtTailNo.ResetText() 'TailNo
        txtContainerNo.ResetText() 'ContainerNo
        txtSealNo.ResetText() 'SealNo
        'txtarriveTruckYardDate.ResetText() 'arriveTruckYardDate
        'txtExitYardDate.ResetText() 'ExitYardDate
        'txtarriveFactoryDate.ResetText() 'arriveFactoryDate
        'txtPackingDate.ResetText() 'PackingDate
        'txtLeaveFactoryDate.ResetText() 'LeaveFactoryDate
        'txtReturnDate.ResetText() 'ReturnDate
        txtDateofJobNotification.ResetText() 'DateofJobNotification
        txtRef1.ResetText()
        txtRef2.ResetText()
        txtactive.Text = "1"
        _IsNew1 = True
    End Sub

    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        'If dgvCostadv.Rows.Then Then
        '    Saveadv(1)
        'Else
        Saveadv()
        'End If
    End Sub

    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        addNewDriver()
        GetRunningFormat("ORDER")
        txtOrderNo.Text = CreateNumber("Driver", "OrderNo", False)
        If txtOrderNo.Text = "ERROR" Then
            MsgBox("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้ กรุณารีสตาร์ทโปรแกรม")
            addNewDriver()
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        If txtOrderNo.Text = "" Then
            GetRunningFormat("ORDER")
            txtOrderNo.Text = CreateNumber("Driver", "OrderNo", False)
            If txtOrderNo.Text = "ERROR" Then
                MsgBox("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้ กรุณารีสตาร์ทโปรแกรม")
                addNewDriver()
                Exit Sub
            End If
        End If
    End Sub


    Private Sub dgvCostadv_CellEndEdit(sender as Object, e as DataGridViewCellEventargs) Handles dgvCostadv.CellEndEdit, dgvDriver.CellContentClick
        Try
            'If (dgvCostadv.CurrentRow.Cells(e.ColumnIndex).Value = Nothing) Then Exit Sub
            'MsgBox("555")
            'Exit Sub
            dgvCostadv.CurrentRow.Cells(8).Value = CDbl(CDbl(dgvCostadv.CurrentRow.Cells(5).Value) + CDbl(dgvCostadv.CurrentRow.Cells(6).Value) - CDbl(dgvCostadv.CurrentRow.Cells(7).Value)) '- dgvCostadv.CurrentRow.Cells(1).Value)
            If Not String.IsNullOrEmpty(dgvCostadv.CurrentRow.Cells(e.ColumnIndex).Value.ToString) Then

                dgvCostadv.Rows(e.RowIndex).Cells(13).Value = txtOrderNo.Text 'OrderNo
                'dgvCostadv.Rows(e.RowIndex).Cells(11).Value = "1"
                'dgvCostadv.Rows(e.RowIndex).Cells(12).Value = "1"
            End If

        Catch ex as Exception

        End Try
    End Sub
    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click
        frmadvanceRequest.txtJobNo.Text = txtJobNo.Text
        frmadvanceRequest.txtOrderNo.Text = txtOrderNo.Text
        frmadvanceRequest.txtSICode.Text = txtCode.Text

        frmadvanceRequest.Show()
    End Sub
    Private Sub txtCode_ButtonClick(sender as Object, e as Eventargs) Handles txtCode.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [accountGroup]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[ItemName]
      ,[SIGroup] from [MaS_SICODE] where 1=1", MainConnection)
        If isSearchOK Then
            txtCode.Text = dr("SICode").ToString
        End If
    End Sub
    Private Sub LoadDataToadv()
        Try
            dgvCostadv.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT Ident,advCode
      ,advDescription
      ,advType
      ,amount
      ,RecieptNo
      ,advDriver
      ,advContainerNo
      ,advStatus
      ,OrderNo
	  ,active
	  ,SysUser
	  ,JobNo
	  ,VaTamt
	  ,WHTamt
	  ,amt FROM adv where OrderNo='" & txtOrderNo.Text & "' and active='1' and  ISNULL(OrderNo,'')<>'' "
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvCostadv.Rows.add(dt.Rows(i)(0).ToString(), 'Ident 0
                                        dt.Rows(i)(3).ToString(), 'advType 1
                                        dt.Rows(i)(1).ToString(), 'advCode 2
                                        "", 'btn 3
                                        dt.Rows(i)(2).ToString(),'advDescription 4
                                        dt.Rows(i)(15).ToString(), 'amount 5
                                        dt.Rows(i)(13).ToString(), 'RecieptNo 6
                                        dt.Rows(i)(14).ToString(), 'advDriver 7
                                        dt.Rows(i)(4).ToString(), 'advContainerNo 8
                                        dt.Rows(i)(5).ToString(), 'advStatus 9
                                        dt.Rows(i)(6).ToString(), 'order no 10
                                        dt.Rows(i)(7).ToString(), ' active 11                                        
                                        dt.Rows(i)(8).ToString, '13
                                        dt.Rows(i)(9).ToString, '14
                                        dt.Rows(i)(10).ToString,
                                        "0", 'isnew 12
                                        dt.Rows(i)(11).ToString,
                                        dt.Rows(i)(12).ToString
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

    'Private Sub LoadDataToadvCost()
    '    Try
    '        dgvCostadv.Rows.Clear()
    '        Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
    '        Dim dt as DataTable = New DataTable()
    '        Dim nection as New OleDb.OleDbConnection()
    '        nection = ConnectDB()
    '        Dim str as String = "SELECT * FROM adv where OrderNo='" & txtOrderNo.Text & "' and active='1' and  ISNULL(OrderNo,'')<>'' "
    '        da.SelectCommand = New OleDbCommand(str, nection)
    '        da.Fill(dt)
    '        If dt.Rows.Count > 0 Then
    '            For i as Integer = 0 To dt.Rows.Count - 1
    '                dgvCostadv.Rows.add(dt.Rows(i)("Ident").ToString(), 'Ident 0
    '                                    dt.Rows(i)("SICode").ToString(), 'advType 1
    '                                    dt.Rows(i)("Description").ToString(), 'advCode 2
    '                                    "", 'btn 3
    '                                    dt.Rows(i)("Type").ToString(),'advDescription 4
    '                                    dt.Rows(i)("amount").ToString(), 'amount 5
    '                                    dt.Rows(i)("Receipt").ToString(), 'RecieptNo 6
    '                                    dt.Rows(i)("Driver").ToString(), 'advDriver 7
    '                                    dt.Rows(i)("ContainerNo").ToString(), 'advContainerNo 8
    '                                    dt.Rows(i)("Status").ToString(), 'advStatus 9
    '                                    dt.Rows(i)("Order").ToString(), 'order no 10
    '                                    dt.Rows(i)("active").ToString(), ' active 11
    '                                    "0", 'isnew 12
    '                                    dt.Rows(i)("SysUser").ToString, '13
    '                                    dt.Rows(i)("Job").ToString, '14
    '                                    dt.Rows(i)("Vat").ToString,
    '                                    dt.Rows(i)("WHT").ToString,
    '                                    dt.Rows(i)("Net").ToString
    '                )
    '            Next
    '            da = Nothing
    '            dt = Nothing
    '            nection.Close()
    '        End If
    '    Catch ex as Exception
    '        MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    End Try
    'End Sub

    Private Sub txtTailNo_ButtonClick(sender as Object, e as Eventargs) Handles txtTailNo.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TailNo  FROM [Mas_Tail] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtTailNo.Text = dr("TailNo").ToString
        End If
    End Sub

    Private Sub txtBTTLocation_ButtonClick(sender as Object, e as Eventargs) Handles txtBTTLocation.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [VendorName], [Vendoraddress]  FROM [Mas_VendorTransport] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtBTTLocation.Text = dr("Vendoraddress").ToString
        End If
    End Sub

    Private Sub txtLoadingLocation_ButtonClick(sender as Object, e as Eventargs) Handles txtLoadingLocation.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [LoadingName],[Loadingaddress]  FROM [Mas_Loading] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtLoadingLocation.Text = dr("Loadingaddress").ToString
        End If
    End Sub

    Private Sub txtPickupLocation_ButtonClick(sender as Object, e as Eventargs) Handles txtPickupLocation.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [PickupName],[Pickupaddress]  FROM [Mas_Pickup] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPickupLocation.Text = dr("Pickupaddress").ToString
        End If
    End Sub

    Private Sub txtReturnLocation_ButtonClick(sender as Object, e as Eventargs) Handles txtReturnLocation.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [ReturnName],[Returnaddress]  FROM [Mas_Return] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtReturnLocation.Text = dr("Returnaddress").ToString
        End If
    End Sub

    Private Sub MetroTextBox1_ButtonClick(sender as Object, e as Eventargs) Handles txtRoute.ButtonClick
        txtRoute.Text = (CDbl(txtBTTDistance.Text) + CDbl(txtLoadDistance.Text) + CDbl(txtPickupDistance.Text) + CDbl(txtReturnDistance.Text)).ToString("#,##0.00")

    End Sub

    Private Sub txtRoutePrice_ButtonClick(sender as Object, e as Eventargs) Handles txtRoutePrice.ButtonClick
        txtRoutePrice.Text = (CDbl(txtRoute.Text) * CDbl(txtRouteRate.Text)).ToString("#,##0.00")
        txteighty.Text = (CDbl(txtRoutePrice.Text) * "0.8").ToString("#,##0.00")
        txttwenty.Text = (CDbl(txtRoutePrice.Text) * "0.2").ToString("#,##0.00")
    End Sub

    Private Sub txtLoadDistance_Leave(sender as Object, e as Eventargs) Handles txtLoadDistance.Leave

    End Sub
    Event DataGridView1ButtonClick(sender as DataGridView, e as DataGridViewCellEventargs)
    Private Sub DataGridView1_CellContentClick(sender as System.Object, e as DataGridViewCellEventargs) Handles dgvCostadv.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn andalso e.RowIndex >= 0 Then
            RaiseEvent DataGridView1ButtonClick(senderGrid, e)
        End If
    End Sub
    Private Sub DataGridView1_ButtonClick(sender as DataGridView, e as DataGridViewCellEventargs) Handles Me.DataGridView1ButtonClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvCostadv.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                If dgvCostadv.CurrentRow.Cells(1).Value.ToString = "" Then
                    MsgBox("Choose Type First!!!")
                    Exit Sub
                End If
                Dim str as String = "SELECT [accountGroup]
                ,[accountNo]
                ,[accountControl]
                ,[SICode]
                ,[accountName]
                ,[ItemName]
                ,[SIGroup]  FROM [MaS_SICODE] WHERE 1=1"
                If dgvCostadv.CurrentRow.Cells(1).Value.ToString = "aDV" Then
                    str &= " aND SIGroup<>'aDV' "
                Else
                    str &= " aND SIGroup ='" & dgvCostadv.CurrentRow.Cells(1).Value.ToString & "'"
                End If
                Dim dr as DataRow
                dr = PopUpSearch(str, MainConnection)

                If isSearchOK Then
                    dgvCostadv.CurrentRow.Cells(2).Value = dr("SICode").ToString
                    dgvCostadv.CurrentRow.Cells(4).Value = dr("ItemName").ToString
                    dgvCostadv.Rows(e.RowIndex).Cells(14).Value = "1"
                    dgvCostadv.Rows(e.RowIndex).Cells(15).Value = "1"

                End If
            End If
        Catch ex as Exception
            Exit Sub
        End Try
    End Sub

    Private Sub txtRoutePrice_TextChanged(sender as Object, e as Eventargs) Handles txtRoutePrice.TextChanged
        txteighty.Text = (CDbl(txtRoutePrice.Text) * "0.8").ToString("#,##0.00")
        txttwenty.Text = (CDbl(txtRoutePrice.Text) * "0.2").ToString("#,##0.00")
    End Sub
    Private Sub txteighty_ButtonClick(sender as Object, e as Eventargs) Handles txteighty.ButtonClick
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT [SICode],[ItemName] from [Mas_SICODE] where SICODE='CTK-0011'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtCode.Text = dr("SICode").ToString()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        Dim frm as New frmadvanceRequest
        frm.txtJobNo.Text = txtJobNo.Text
        frm.txtQty.Text = txtQty.Text
        frm.txtVendorName.Text = txtDriver.Text
        frm.txtBookingNo.Text = txtBooking.Text
        frm.txtSICode.Text = txtCode.Text
        frm.txtOrderNo.Text = txtOrderNo.Text
        'frmadvanceRequest.txtadvamount.Text = txtWithdrawalamount.Text
        frm.txtChargeamount.Text = txteighty.Text
        frm.txtadvNo.Text = txtadvanceNo.Text
        frm.ShowDialog()
        If txtadvanceNo.Text = vbNullString Then
            txtadvanceNo.Text = frm.txtadvNo.Text
            addadvNo(0)
        End If
    End Sub

    Private Sub txttwenty_ButtonClick(sender as Object, e as Eventargs) Handles txttwenty.ButtonClick
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT [SICode],[ItemName] from [Mas_SICODE] where SICODE='CTK-0012'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtCode.Text = dr("SICode").ToString()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        Dim frm as New frmadvanceRequest
        frm.txtJobNo.Text = txtJobNo.Text
        frm.txtQty.Text = txtQty.Text
        frm.txtVendorName.Text = txtDriver.Text
        frm.txtBookingNo.Text = txtBooking.Text
        frm.txtSICode.Text = txtCode.Text
        frm.txtOrderNo.Text = txtOrderNo.Text
        'frm.txtadvamount.Text = txtWithdrawalamount.Text
        frm.txtChargeamount.Text = txttwenty.Text
        frm.txtadvNo.Text = txtadvanceNo.Text
        frm.ShowDialog()
        If txtadvanceNo.Text = vbNullString Then
            txtadvanceNo.Text = frm.txtadvNo.Text
            addadvNo(0)
        End If
    End Sub

    Private Sub MetroTextBox1_ButtonClick_1(sender as Object, e as Eventargs) Handles txtUnitPrice.ButtonClick
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT [SICode],[ItemName] from [Mas_SICODE] where SICODE='CTK-0008'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtCode.Text = dr("SICode").ToString()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        Dim frm as New frmadvanceRequest
        frmadvanceRequest.txtJobNo.Text = txtJobNo.Text
        frm.txtQty.Text = txtQty.Text
        frm.txtVendorName.Text = txtDriver.Text
        frm.txtBookingNo.Text = txtBooking.Text
        frm.txtSICode.Text = txtCode.Text
        frm.txtOrderNo.Text = txtOrderNo.Text
        ' frm.txtadvamount.Text = txtWithdrawalamount.Text
        frm.txtChargeamount.Text = txtUnitPrice.Text
        frm.txtadvNo.Text = txtadvanceNo.Text
        frm.ShowDialog()
        If txtadvanceNo.Text = vbNullString Then
            txtadvanceNo.Text = frm.txtadvNo.Text
            addadvNo(0)
        End If
    End Sub

    Private Sub MetroTextBox2_TextChanged(sender as Object, e as Eventargs) Handles MetroTextBox2.TextChanged
        txtUnitPrice.Text = (CDbl(MetroTextBox2.Text) * "0.1").ToString("#,##0.00")

    End Sub

    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [RouteName],[PickupName]
        ,[Pickupaddress],[PickupContact],[BTTName],[BTTaddress]
        ,[BTTContact],[ReturnName],[Returnaddress],[ReturnContact]
        ,[FactoryName],[Factoryaddress],[FactoryContact]
        ,[RouteLength],[FuelCost],[RoutePrice],[FuelType],[BTTDistance]
        ,[PickupDistance],[DeliveryDistance],[ReturnDistance],[ShortPrice]
        ,[LongPrice]
        FROM [Mas_Route] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPickupLocation.Text = dr("Pickupaddress").ToString
            txtBTTLocation.Text = dr("BTTaddress").ToString
            txtReturnLocation.Text = dr("Returnaddress").ToString
            txtLoadingLocation.Text = dr("Factoryaddress").ToString
            txtRoutePrice.Text = dr("RouteLength").ToString
            txtBTTDistance.Text = dr("BTTDistance").ToString
            txtPickupDistance.Text = dr("PickupDistance").ToString
            txtLoadDistance.Text = dr("DeliveryDistance").ToString
            txtReturnDistance.Text = dr("ReturnDistance").ToString
        End If
    End Sub
    Private Sub Button11_Click(sender as Object, e as Eventargs) Handles Button11.Click
        If txtOrderNo.Text = "" Then
            MsgBox("Input Order Number First!!!")
            Exit Sub
        End If
        Dim url as String = "http://203.170.129.23/transport/report/TransportOrder?orderno=" & txtOrderNo.Text & "&jobno=" & txtJobNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex as Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub Button7_Click(sender as Object, e as Eventargs) Handles Button7.Click
        If txtadvanceNo.Text = "" Then
            Cancel.ShowDialog()
            If Cancel.Isactive = False Then
                txtactive.Text = "0"
                SaveDriver(0)
                UpdateLog("Driver", "Cancel")
            Else
                Exit Sub
            End If
        Else
            CantCancel.ShowDialog()
            Exit Sub
        End If
    End Sub

    Private Sub Button8_Click(sender as Object, e as Eventargs) Handles Button8.Click
        dgvCostadv.CurrentRow.Cells(14).Value = "0"
        Saveadv()
    End Sub

    Private Sub Button9_Click(sender as Object, e as Eventargs) Handles Button9.Click
        _IsNew1 = True
    End Sub

    'Private Sub MetroTextBox1_ButtonClick_2(sender as Object, e as Eventargs) 
    '    MonthCalendar1.Visible = Not MonthCalendar1.Visible = True
    'End Sub

    'Private Sub MonthCalendar1_DateSelected(sender as Object, e as DateRangeEventargs) 
    '    MaskedTextBox2.Text = LetDate(MonthCalendar1.SelectionEnd.ToShortDateString)
    '    MonthCalendar1.Visible = Not MonthCalendar1.Visible = True
    'End Sub

    Private Sub btnarriveTruckYard_ButtonClick(sender as Object, e as Eventargs) Handles btnarriveTruckYard.ButtonClick
        calarriveTruckYard.Visible = Not calarriveTruckYard.Visible = True
    End Sub

    Private Sub calarriveTruckYard_DateSelected(sender as Object, e as DateRangeEventargs) Handles calarriveTruckYard.DateSelected
        txtarriveTruckYardDate.Text = LetDate(calarriveTruckYard.SelectionEnd.ToShortDateString)
        calarriveTruckYard.Visible = Not calarriveTruckYard.Visible = True
    End Sub

    Private Sub btnExitYard_ButtonClick(sender as Object, e as Eventargs) Handles btnExitYard.ButtonClick
        calExitYard.Visible = Not calExitYard.Visible = True
    End Sub

    Private Sub calExitYard_DateSelected(sender as Object, e as DateRangeEventargs) Handles calExitYard.DateSelected
        txtExitYardDate.Text = LetDate(calExitYard.SelectionEnd.ToShortDateString)
        calExitYard.Visible = Not calExitYard.Visible = True
    End Sub

    Private Sub btnarriveFactory_ButtonClick(sender as Object, e as Eventargs) Handles btnarriveFactory.ButtonClick
        calarriveFactory.Visible = Not calarriveFactory.Visible = True
    End Sub

    Private Sub calarriveFactory_DateSelected(sender as Object, e as DateRangeEventargs) Handles calarriveFactory.DateSelected
        txtarriveFactoryDate.Text = LetDate(calarriveFactory.SelectionEnd.ToShortDateString)
        calarriveFactory.Visible = Not calarriveFactory.Visible = True
    End Sub

    Private Sub btnPacking_ButtonClick(sender as Object, e as Eventargs) Handles btnPacking.ButtonClick
        calPacking.Visible = Not calPacking.Visible = True
    End Sub

    Private Sub calPacking_DateSelected(sender as Object, e as DateRangeEventargs) Handles calPacking.DateSelected
        txtPackingDate.Text = LetDate(calPacking.SelectionEnd.ToShortDateString)
        calPacking.Visible = Not calPacking.Visible = True
    End Sub

    Private Sub btnLeaveFactory_ButtonClick(sender as Object, e as Eventargs) Handles btnLeaveFactory.ButtonClick
        calLeaveFactory.Visible = Not calLeaveFactory.Visible = True
    End Sub

    Private Sub calLeaveFactory_DateSelected(sender as Object, e as DateRangeEventargs) Handles calLeaveFactory.DateSelected
        txtLeaveFactoryDate.Text = LetDate(calLeaveFactory.SelectionEnd.ToShortDateString)
        calLeaveFactory.Visible = Not calLeaveFactory.Visible = True
    End Sub

    Private Sub btnReturn_ButtonClick(sender as Object, e as Eventargs) Handles btnReturn.ButtonClick
        calReturn.Visible = Not calReturn.Visible = True
    End Sub

    Private Sub calReturn_DateSelected(sender as Object, e as DateRangeEventargs) Handles calReturn.DateSelected
        txtReturnDate.Text = LetDate(calReturn.SelectionEnd.ToLongDateString)
        calReturn.Visible = Not calReturn.Visible = True
    End Sub

    Private Sub btnDateOfJob_ButtonClick(sender as Object, e as Eventargs) Handles btnDateOfJob.ButtonClick
        calDateofJob.Visible = Not calDateofJob.Visible = True
    End Sub

    Private Sub calDateofJob_DateSelected(sender as Object, e as DateRangeEventargs) Handles calDateofJob.DateSelected
        txtDateofJobNotification.Text = LetDate(calDateofJob.SelectionEnd.ToLongDateString)
        calDateofJob.Visible = Not calDateofJob.Visible = True
    End Sub

    Private Sub Button10_Click(sender as Object, e as Eventargs) Handles Button10.Click
        Dim url as String = "http://203.170.129.23/transport/report/DeliveryOrder?JobNo=" & txtJobNo.Text & "&OrderNo=" & txtOrderNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex as Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub MetroTextBox4_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox4.ButtonClick
        calReturnDate.Visible = Not calReturnDate.Visible = True
    End Sub

    Private Sub calReturnDate_DateSelected(sender as Object, e as DateRangeEventargs) Handles calReturnDate.DateSelected
        txtactualReturnDate.Text = LetDate(calReturnDate.SelectionEnd.ToLongDateString)
        calReturnDate.Visible = Not calReturnDate.Visible = True
    End Sub

    Private Sub txtOrderNo_TextChanged(sender as Object, e as Eventargs) Handles txtOrderNo.TextChanged
        LoadSumadv()
    End Sub

    Private Sub txtWithdrawalamount_TextChanged(sender as Object, e as Eventargs) Handles txtWithdrawalamount.TextChanged
        If txtWithdrawalamount.Text = "" Then
            txtWithdrawalamount.Text = "0"
        Else
            Exit Sub
        End If
    End Sub

    Private Sub dgvDriver_CellContentClick(sender as Object, e as DataGridViewCellEventargs)

    End Sub

    Private Sub MetroTextBox3_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox3.ButtonClick
        CalDropDate.Visible = Not CalDropDate.Visible = True

    End Sub

    Private Sub CalDropDate_DateSelected(sender as Object, e as DateRangeEventargs) Handles CalDropDate.DateSelected
        txtDropDate.Text = LetDate(CalDropDate.SelectionEnd.ToLongDateString)
        CalDropDate.Visible = Not CalDropDate.Visible = True
    End Sub

    Private Sub dgvCostadv_CellDoubleClick(sender as Object, e as DataGridViewCellEventargs) Handles dgvCostadv.CellDoubleClick

    End Sub

    Private Sub MetroTextBox6_Click(sender as Object, e as Eventargs) Handles txtReceiptNo.Click

    End Sub

    'Private Sub MetroTextBox1_ButtonClick_2(sender as Object, e as Eventargs) Handles MetroTextBox1.ButtonClick
    '    GetRunningFormat("CaDSaDWDSa")
    '    txtOrderNo.Text = CreateNumber("Driver", "OrderNo", False)
    'End Sub
End Class'