Imports System.Data.OleDb
Imports System.Drawing.Imaging
Imports System.Resources
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Imports System.Xml

Public Class frmadvanceRequest
    Public _IsNew as Boolean
    Public _IsNewD as Boolean
    Public Isapproveadv as Boolean
    Public advamount as String
    Public advEighty as String
    Public advTwenty as String
    Public advTen as String
    Private a as Double

    Private Sub SaveNetPayment()
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec BringadvNetToDriver ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtNetPayment.Text & "'") 'advNo
            'SQLcommand.append( ",'" & _insert & "'" ) '//Insert Or Update
            'MsgBox(SQLcommand.ToString())
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        MsgBox(_IsNew)
        Userauthorize(UserProfile.U_Code, "ADVR")
        SaveNetPayment()
        If Userauthen.IsOpenMenu = 1 Then
            If Not String.IsNullOrEmpty(txtSICode.Text) Then
                If String.IsNullOrEmpty(txtUnit.Text) Then
                    MetroFramework.MetroMessageBox.Show(Me, "Choose Unit First ", "Check Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If txtIsNewD.Text = "0" Then
                    dgvadvDetail.CurrentRow.Cells(0).Value = txtIdentD.Text
                    dgvadvDetail.CurrentRow.Cells(1).Value = txtJobNo.Text
                    dgvadvDetail.CurrentRow.Cells(2).Value = txtOrderNo.Text
                    dgvadvDetail.CurrentRow.Cells(3).Value = txtBookingNo.Text
                    dgvadvDetail.CurrentRow.Cells(4).Value = txtSICode.Text
                    dgvadvDetail.CurrentRow.Cells(5).Value = txtadvDescription.Text
                    dgvadvDetail.CurrentRow.Cells(6).Value = txtQty.Text
                    dgvadvDetail.CurrentRow.Cells(7).Value = txtUnit.Text
                    dgvadvDetail.CurrentRow.Cells(8).Value = txtWHT.Text
                    dgvadvDetail.CurrentRow.Cells(9).Value = txtadvamount.Text
                    dgvadvDetail.CurrentRow.Cells(10).Value = txtChargeamount.Text
                    dgvadvDetail.CurrentRow.Cells(11).Value = txtadvNo.Text
                    dgvadvDetail.CurrentRow.Cells(12).Value = txtRemark.Text
                    dgvadvDetail.CurrentRow.Cells(13).Value = txtRequestadv.Text
                    dgvadvDetail.CurrentRow.Cells(14).Value = txtIsNewD.Text
                    dgvadvDetail.CurrentRow.Cells(19).Value = txtactive.Text
                    dgvadvDetail.CurrentRow.Cells(20).Value = UserProfile.U_FName & "  " & UserProfile.U_LName
                    dgvadvDetail.CurrentRow.Cells(21).Value = txtUnitPrice.Text
                Else
                    dgvadvDetail.Rows.add("0", 'Ident
                            txtJobNo.Text, 'JobNo
                            txtOrderNo.Text,
                            txtBookingNo.Text, 'BookingNo
                            txtSICode.Text, 'SICode
                            txtadvDescription.Text, 'advDescription
                            txtQty.Text, 'Qty
                            txtUnit.Text, 'Unit
                            txtWHT.Text, 'WHT
                            txtadvamount.Text, 'Chargeamount
                            txtChargeamount.Text, 'advamount                           
                            txtadvNo.Text,  'advNo
                            txtRemark.Text,
                            "",
                            txtIsNewD.Text,
                            "",
                            "",
                            "",
                            "",
                            txtactive.Text,
                            UserProfile.U_FName & "  " & UserProfile.U_LName,
                            txtUnitPrice.Text
                            )
                End If
                'Exit Sub
                addNewDetail()
            End If
            If String.IsNullOrEmpty(txtadvNo.Text) Then
                GetRunningFormat("aDVNO")
                txtadvNo.Text = CreateNumber("advanceRequest", "advNo", dtpPayDate.Value)
            End If
            If txtadvNo.Text = "ERROR" Then
                MsgBox("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้ กรุณารีสตาร์ทโปรแกรม")
                Exit Sub
            End If
            If _IsNew = True Then
                If CheckadvNo(txtadvNo.Text) Then
                    MetroFramework.MetroMessageBox.Show(Me, "Duplicated advance number ", "Check advance Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SaveadvRequest(1)
            Else
                SaveadvRequest(0)
            End If
        Else
            MetroFramework.MetroMessageBox.Show(Me, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
    End Sub
    Private Sub UpdateadvToDriver()
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_Updateadvance ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtadvNo.Text & "'") 'advNo
            'MsgBox(SQLcommand.ToString())
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub addadvanceRequest()
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [advNo]
            ,[advNoDate]
            ,[advNoTime]
            ,[PVRef]
            ,[ClearRef]
            ,[VendorName]
            ,[PayFor]
            ,[PayForBank]
            ,[PayDate]
            ,[NetPayment],[Ident] from [advanceRequest] where advNo='" & txtadvNo.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtadvNo.Text = dr("advNo").ToString
                dtpadvNoDate.Text = dr("advNoDate").ToString
                txtadvNoTime.Text = dr("advNoTime").ToString
                txtPVRef.Text = dr("PVRef").ToString
                txtClearRef.Text = dr("ClearRef").ToString
                txtVendorName.Text = dr("VendorName").ToString
                txtPayFor.Text = dr("PayFor").ToString
                txtPayForBank.Text = dr("PayForBank").ToString
                dtpPayDate.Text = dr("PayDate").ToString
                txtNetPayment.Text = dr("NetPayment").ToString
                txtIdent.Text = dr("Ident").ToString
                LoadDataToadvDetail()
                _IsNew = False
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveadvRequest(_insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateadvanceRequest ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtadvNo.Text & "'") 'advNo
            SQLcommand.append(",'" & LetDate(dtpadvNoDate.Value) & "'") 'advNoDate
            SQLcommand.append(",'" & txtadvNoTime.Text & "'") 'advNoTime
            SQLcommand.append(",'" & txtPVRef.Text & "'") 'PVRef  
            SQLcommand.append(",'" & txtClearRef.Text & "'") 'ClearRef
            SQLcommand.append(",'" & txtVendorName.Text & "'") 'VenderName
            SQLcommand.append(",'" & txtPayFor.Text & "'") 'PayFor
            SQLcommand.append(",'" & txtPayForBank.Text & "'") 'PayForBank
            SQLcommand.append(",'" & LetDate(dtpPayDate.Value) & "'") 'PayDate
            SQLcommand.append(",'" & CDbl(txtNetPayment.Text) & "'") 'NetPayment
            SQLcommand.append(",'" & txtSysUser.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            'MsgBox(SQLcommand.ToString())
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                SaveadvDetail()
                UpdateadvToDriver()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveDetail(_insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateadvanceRequestDetail ")
            SQLcommand.append("'" & txtIdentD.Text & "'") 'Ident
            SQLcommand.append(",'" & txtJobNo.Text & "'") 'JobNo
            SQLcommand.append(",'" & txtOrderNo.Text & "'") 'OrderNo
            SQLcommand.append(",'" & txtBookingNo.Text & "'") 'BookingNo
            SQLcommand.append(",'" & txtSICode.Text & "'") 'SICode
            SQLcommand.append(",'" & txtadvDescription.Text & "'") 'advDescription
            SQLcommand.append(",'" & txtQty.Text & "'") 'Qty
            SQLcommand.append(",'" & txtUnit.Text & "'") 'Unit
            SQLcommand.append(",'" & CDbl(txtWHT.Text) & "'") 'WHT
            SQLcommand.append(",'" & CDbl(txtadvamount.Text) & "'") 'advamount
            SQLcommand.append(",'" & CDbl(txtChargeamount.Text) & "'") 'Chargeamount
            SQLcommand.append(",'" & txtadvNo.Text & "'") 'advNo
            SQLcommand.append(",'" & txtUnit.Text & "'") 'ContainerType
            SQLcommand.append(",'" & txtRemark.Text & "'") 'advRemark
            SQLcommand.append(",'" & txtRequestadv.Text & "'")
            SQLcommand.append(",'" & txtactive.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToadvDetail()
                _IsNewD = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveadvDetail()
        Try
            If dgvadvDetail.Rows.Count > 0 Then
                Dim nection as New OleDb.OleDbConnection()
                Dim str as String = ""
                Dim a as Integer
                nection = ConnectDB()
                For row as Integer = 0 To dgvadvDetail.Rows.Count - 1
                    txtRequestadv.ResetText()
                    If dgvadvDetail.Rows(row).Cells(13).Value.ToString = "" Then
                        RunningRequest()
                    End If
                    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateadvanceRequestDetail ")
                    SQLcommand.append("'" & CInt(dgvadvDetail.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(1).Value.ToString & "'") 'JobNo
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(2).Value.ToString & "'") 'OrderNo
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(3).Value.ToString & "'") 'BookingNo
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(4).Value.ToString & "'") 'SICode
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(5).Value.ToString & "'") 'advDescription
                    SQLcommand.append(",'" & CInt(dgvadvDetail.Rows(row).Cells(6).Value) & "'") 'Qty
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(7).Value.ToString & "'") 'Unit
                    SQLcommand.append(",'" & CDbl(dgvadvDetail.Rows(row).Cells(8).Value) & "'") 'WHT
                    SQLcommand.append(",'" & CDbl(dgvadvDetail.Rows(row).Cells(9).Value) & "'") 'advamount
                    SQLcommand.append(",'" & CDbl(dgvadvDetail.Rows(row).Cells(10).Value) & "'") 'Chargeamount
                    SQLcommand.append(",'" & txtadvNo.Text & "'") 'advNo
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(12).Value.ToString & "'") 'advRemark
                    If Not String.IsNullOrEmpty(txtRequestadv.Text) Then
                        SQLcommand.append(",'" & txtRequestadv.Text & "'") 'Requestadv
                    Else
                        SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(13).Value.ToString & "'") 'Requestadv
                    End If

                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(19).Value & "'")
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(20).Value & "'")
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(21).Value & "'")
                    SQLcommand.append(",'" & CInt(dgvadvDetail.Rows(row).Cells(14).Value) & "'") 'Insert or update
                    Dim sql as String = SQLcommand.ToString()


                    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)

                    If result = 1 Then
                        a += 0
                    Else
                        a += 1
                        If dgvadvDetail.Rows(row).Cells(4).Value = Nothing Then
                            str &= dgvadvDetail.Rows(row).Cells(4).Value.ToString & vbCrLf
                        End If
                    End If
                Next
                If a = 0 Then
                    MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadDataToadvDetail()
                Else
                    MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail " & vbCrLf & str, "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub frmadvanceRequest_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        If txtSysUser.Text = "" Then
            txtSysUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName
        End If
        If txtadvNo.Text = "" Then
            addNewadvRequest()
            'addDescription()
        Else
            addadvanceRequest()
        End If
        ' addNewadvRequest()
        'addDescription()
    End Sub
    Private Sub addDescription()
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT [ItemName] from [Mas_SICODE] where SICODE='" & txtSICode.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtadvDescription.Text = dr("ItemName").ToString()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub addNewadvRequest()
        txtIdent.Text = "0" 'Ident
        txtadvNo.ResetText() 'advNo
        txtadvNoTime.ResetText() 'advNoTime
        txtPVRef.ResetText() 'PVRef
        txtClearRef.ResetText() 'ClearRef
        'txtVendorName.ResetText() 'VendorName
        'txtPayFor.ResetText() 'PayFor
        'txtPayForBank.ResetText() 'PayForBank
        txtNetPayment.Text = "0.00" 'NetPayment
        _IsNew = True
        _IsNewD = True
        txtIdentD.Text = "0"
        txtactive.Text = "1"
        addNewDetail()
        'addDescription()
        dgvadvDetail.Rows.Clear()
        addNewadvanceDetail()
    End Sub

    Private Sub LoadDataToadvDetail()
        Try
            dgvadvDetail.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM advanceRequestDetail where 1=1 and advNo='" & txtadvNo.Text & "'Order BY active DESC" '& "'and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvadvDetail.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'JobNo
                    dt.Rows(i)(2).ToString(), 'BookingNo
                    dt.Rows(i)(3).ToString(), 'SICode
                    dt.Rows(i)(4).ToString(), 'advDescription
                    dt.Rows(i)(5).ToString(), 'Qty
                    dt.Rows(i)(6).ToString(), 'Unit
                    dt.Rows(i)(7).ToString(), 'WHT
                    CDbl(dt.Rows(i)(8).ToString()), 'advamount
                    CDbl(dt.Rows(i)(9).ToString()), 'Chargeamount
                    CDbl(dt.Rows(i)(10).ToString()),
                    dt.Rows(i)(11).ToString(),'advNo
                    dt.Rows(i)(13).ToString(),
                    dt.Rows(i)(14).ToString(),
                    "0",
                    dt.Rows(i)(15).ToString(),
                    dt.Rows(i)(16).ToString(),
                    dt.Rows(i)(17).ToString(),
                    "",
                    dt.Rows(i)(19).ToString(),
                    dt.Rows(i)(21).ToString
                    )
                    If dgvadvDetail.Rows(i).Cells(19).Value = "0" Then
                        dgvadvDetail.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        dgvadvDetail.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    End If
                    'JobNo
                    'dt.Rows(i)(12).ToString(), 'BookingNo
                    'dt.Rows(i)(13).ToString(), 'SICode
                    'dt.Rows(i)(14).ToString(), 'advDescription
                    'dt.Rows(i)(15).ToString(), 'Qty
                    'dt.Rows(i)(16).ToString() 'Unit)
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
            Dim amt as Double = 0
            If dgvadvDetail.Rows.Count > 0 Then
                For i as Integer = 0 To dgvadvDetail.Rows.Count - 1
                    If dgvadvDetail.Rows(i).Cells(19).Value = "1" Then
                        amt += dgvadvDetail.Rows(i).Cells(9).Value + dgvadvDetail.Rows(i).Cells(10).Value
                    End If
                Next
                txtNetPayment.Text = amt.ToString("#,##0.00")
            Else
                txtNetPayment.Text = amt.ToString("#,##0.00")
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub addNewadvanceDetail()
        Try
            dgvadvDetail.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT 
'0' as Ident
, '' as JobNo
, '' as OrderNo
, '' as BookingNo
, dbo.MaS_SICODE.SICode
, dbo.MaS_SICODE.ItemName aS advDescription
, '1' as Qty
, '" & txtContainerType.Text & "' as Unit
, '0' as WHT
, '0' as advamount
, '0' as Chargeamount
, '' as advNo
, '0' as ContainerType
, '0' as advRemark
, '0' as Requestadv
, '1' as active
FROM   dbo.MaS_SICODE 
WHERE  (dbo.MaS_SICODE.SICode IN ('aDV-0003','CTK-0011', 'CTK-0012', 'CTK-0008'))"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    Select Case dt.Rows(i)(4).ToString()
                        Case "aDV-0003"
                            dgvadvDetail.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                            txtJobNo.Text, 'JobNo
                            txtOrderNo.Text,
                            txtBookingNo.Text, 'BookingNo
                            dt.Rows(i)(4).ToString(), 'SICode
                            dt.Rows(i)(5).ToString(), 'advDescription
                            dt.Rows(i)(6).ToString, 'Qty
                            dt.Rows(i)(7).ToString(), 'Unit
                            dt.Rows(i)(8).ToString(), 'WHT
                            CDbl(advamount).ToString("#,##0.00"), 'advamount
                            CDbl(dt.Rows(i)(10).ToString()), 'Chargeamount
                            dt.Rows(i)(11).ToString(),  'advNo
                            "",
                            "",
                            "1",
                            "",
                            "",
                            "",
                            "",
                            "1"
                            )
                        Case "CTK-0011"
                            dgvadvDetail.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                            txtJobNo.Text, 'JobNo
                            txtOrderNo.Text,
                            txtBookingNo.Text, 'BookingNo
                            dt.Rows(i)(4).ToString(), 'SICode
                            dt.Rows(i)(5).ToString(), 'advDescription
                            dt.Rows(i)(6).ToString, 'Qty
                            dt.Rows(i)(7).ToString(), 'Unit
                            dt.Rows(i)(8).ToString(), 'WHT
                            CDbl(dt.Rows(i)(9).ToString()), 'Chargeamount
                            CDbl(advEighty).ToString("#,##0.00"), 'advamount                           
                            dt.Rows(i)(11).ToString(),  'advNo
                             "",
                             "",
                             "1",
                             "",
                             "",
                             "",
                             "",
                             "1"
                               )
                        Case "CTK-0012"
                            dgvadvDetail.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                            txtJobNo.Text, 'JobNo
                            txtOrderNo.Text,
                            txtBookingNo.Text, 'BookingNo
                            dt.Rows(i)(4).ToString(), 'SICode
                            dt.Rows(i)(5).ToString(), 'advDescription
                            dt.Rows(i)(6).ToString, 'Qty
                            dt.Rows(i)(7).ToString(), 'Unit
                            dt.Rows(i)(8).ToString(), 'WHT
                            CDbl(dt.Rows(i)(9).ToString()), 'Chargeamount
                            CDbl(advTwenty).ToString("#,##0.00"), 'advamount                           
                            dt.Rows(i)(11).ToString(),  'advNo
                             "",
                             "",
                             "1",
                             "",
                             "",
                             "",
                             "",
                             "1"
                            )
                        Case "CTK-0008"
                            dgvadvDetail.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                            txtJobNo.Text, 'JobNo
                            txtOrderNo.Text,
                            txtBookingNo.Text, 'BookingNo
                            dt.Rows(i)(4).ToString(), 'SICode
                            dt.Rows(i)(5).ToString(), 'advDescription
                            dt.Rows(i)(6).ToString, 'Qty
                            dt.Rows(i)(7).ToString(), 'Unit
                            dt.Rows(i)(8).ToString(), 'WHT
                            CDbl(dt.Rows(i)(9).ToString()), 'Chargeamount
                            CDbl(advTen).ToString("#,##0.00"), 'advamount                           
                            dt.Rows(i)(11).ToString(),  'advNo
                             "",
                             "",
                             "1",
                             "",
                             "",
                             "",
                             "",
                             "1"
                            )
                    End Select

                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
            Dim amt as Double = 0
            If dgvadvDetail.Rows.Count > 0 Then
                For i as Integer = 0 To dgvadvDetail.Rows.Count - 1
                    'amt += dgvadvDetail.Rows(i).Cells(9).Value
                    amt += dgvadvDetail.Rows(i).Cells(9).Value + dgvadvDetail.Rows(i).Cells(10).Value
                Next
                txtNetPayment.Text = amt.ToString("#,##0.00")
            Else
                txtNetPayment.Text = amt.ToString("#,##0.00")
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        'GetRunningFormat("aDVNO")
        'txtadvNo.Text = CreateNumber("advanceRequest", "advNo", dtpPayDate.Value)
        Userauthorize(UserProfile.U_Code, "aDVR")
        If Userauthen.IsOpenMenu = 1 Then
            'togident.Text = "0"
            'Dim CBCell as New DataGridViewComboBoxCell()
            'CBCell = dgvPrice.Rows(0).Cells(8)
            'CBCell.Items.add("รอแจ้งงานรถ")
            'CBCell.Items.add("กำลังทำงาน")
            'CBCell.Items.add("รอแจ้งหนี้")
            'CBCell.Items.add("ออกใบเสร็จแล้ว")
            'CBCell.Items.add("ค้างชำระเกินดิว")
            'CBCell.Items.add("ชำระมาแค่บางส่วน")
            'LoadDataToadv()
            'LoadDataToCost()
            'LoadDataToaddTransport()
            'LoadaddTransport()
        Else
            MetroFramework.MetroMessageBox.Show(Me, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        If txtRequestadv.Text = "" Then
            RunningRequest()
        End If
        If _IsNewD Then
            SaveDetail(1)
        Else
            SaveDetail(0)
        End If
    End Sub
    Private Sub RunningRequest()
        GetRunningFormat("REQ")
        txtRequestadv.Text = CreateNumber("advanceRequestDetail", "Requestadv", dtpCurrentDate.Value)
    End Sub
    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [advNo]
        ,[advNoDate]
        ,[advNoTime]
        ,[PVRef]
        ,[ClearRef]
        ,[VendorName]
        ,[PayFor]
        ,[PayForBank]
        ,[PayDate]
        ,[NetPayment],ident,SysUser  FROM advanceRequest WHERE 1=1", MainConnection)
        If isSearchOK Then
            addNewDetail()
            txtadvNo.Text = dr("advNo").ToString
            txtVendorName.Text = dr("VendorName").ToString
            dtpadvNoDate.Value = CDate(dr("advNoDate").ToString)
            txtadvNoTime.Text = dr("advNoTime").ToString
            txtPVRef.Text = dr("PVRef").ToString
            txtClearRef.Text = dr("ClearRef").ToString
            txtPayFor.Text = dr("PayFor").ToString
            txtPayForBank.Text = dr("PayForBank").ToString
            dtpPayDate.Value = CDate(dr("PayDate").ToString)
            txtNetPayment.Text = CDbl(dr("NetPayment").ToString)
            txtIdent.Text = CInt(dr("ident").ToString)
            txtSysUser.Text = dr("SysUser").ToString
            _IsNew = False
        End If
        LoadDataToadvDetail()
    End Sub

    Private Sub txtPayFor_ButtonClick(sender as Object, e as Eventargs) Handles txtPayFor.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [VendorName],[VendorBankName],[VendorBankNo]  FROM [Mas_VendorTransport] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPayFor.Text = dr("VendorName").ToString
            txtPayForBank.Text = dr("VendorBankName") & dr("VendorBankNo")
        End If
        'LoadDataToadvDetail()
    End Sub

    Private Sub dgvadvDetail_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvadvDetail.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvadvDetail.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdentD.Text = CInt(dgvadvDetail.CurrentRow.Cells(0).Value.ToString()) 'Ident
                'txtJobNo.Text = dgvadvDetail.CurrentRow.Cells(1).Value.ToString() 'JobNo
                'txtOrderNo.Text = dgvadvDetail.CurrentRow.Cells(2).Value.ToString() 'OrderNo
                'txtBookingNo.Text = dgvadvDetail.CurrentRow.Cells(3).Value.ToString() 'BookingNo
                txtSICode.Text = dgvadvDetail.CurrentRow.Cells(4).Value.ToString() 'SICode
                txtadvDescription.Text = dgvadvDetail.CurrentRow.Cells(5).Value.ToString() 'advDescription
                txtQty.Text = CDbl(dgvadvDetail.CurrentRow.Cells(6).Value.ToString()) 'Qty
                txtUnit.Text = dgvadvDetail.CurrentRow.Cells(7).Value.ToString() 'Unit
                txtWHT.Text = CDbl(dgvadvDetail.CurrentRow.Cells(8).Value).ToString("#,##0.00") 'WHT
                txtadvamount.Text = CDbl(dgvadvDetail.CurrentRow.Cells(9).Value).ToString("#,##0.00") 'advamount
                txtChargeamount.Text = CDbl(dgvadvDetail.CurrentRow.Cells(10).Value).ToString("#,##0.00") 'Chargeamount
                'txtadvNo.Text = dgvadvDetail.CurrentRow.Cells(11).Value.ToString() 'advNo

                txtRemark.Text = dgvadvDetail.CurrentRow.Cells(12).Value.ToString
                txtRequestadv.Text = dgvadvDetail.CurrentRow.Cells(13).Value.ToString
                txtIsNewD.Text = dgvadvDetail.CurrentRow.Cells(14).Value.ToString
                txtactive.Text = dgvadvDetail.CurrentRow.Cells(19).Value.ToString
                _IsNewD = False
            End If
            Userauthorize(UserProfile.U_Code, "aDVR")
            If Userauthen.IsCheckData = 1 Then
                EnableDetail()
            Else
                If dgvadvDetail.CurrentRow.Cells(15).Value.ToString <> "" Then
                    DisableDetail()
                ElseIf dgvadvDetail.CurrentRow.Cells(15).Value.ToString = "" Then
                    EnableDetail()
                End If
            End If

        Catch ex as Exception

        End Try
    End Sub
    Private Sub EnableDetail()
        txtSICode.Enabled = True
        txtQty.Enabled = True
        txtUnit.Enabled = True
        txtWHT.Enabled = True
        txtadvamount.Enabled = True
        txtChargeamount.Enabled = True
    End Sub

    Private Sub txtWHT_TextChanged(sender as Object, e as Eventargs) Handles txtWHT.TextChanged
    End Sub

    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        addNewDetail()
    End Sub

    Private Sub addNewDetail()
        txtIdentD.Text = "0" 'Ident
        txtadvamount.Text = "0" 'advamount
        'txtadvNo.ResetText() 'advNo
        'txtJobNo.ResetText()
        'txtOrderNo.ResetText()
        'txtBookingNo.ResetText()
        txtSICode.ResetText()
        txtadvDescription.ResetText()
        txtRemark.ResetText()
        txtQty.Text = "1"
        txtUnit.ResetText()
        txtWHT.Text = "0.00"
        txtadvamount.Text = "0.00"
        txtChargeamount.Text = "0.00"
        txtIsNewD.Text = "1"
        _IsNewD = True
        txtIsNewD.Text = "1"
    End Sub

    Private Sub addData()
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT SUM advamount from [advanceRequestDetail] where 1=1"
            dr = SelectSingleRow(sqlstr)
            'MsgBox(dr(sqlstr))
            If Not IsNothing(dr) Then
                txtNetPayment.Text = dr("advamount").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error" & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtNetPayment_Click(sender as Object, e as Eventargs) Handles txtNetPayment.Click
        addData()
    End Sub

    Private Sub txtRequestadv_Click(sender as Object, e as Eventargs) Handles txtRequestadv.Click
        'RunningRequest()
    End Sub

    Private Sub Button4_Click(sender as Object, e as Eventargs)

    End Sub

    Private Sub txtSICode_ButtonClick(sender as Object, e as Eventargs) Handles txtSICode.ButtonClick

        Try
            'txtIsNewD.Text = "1"
            txtRequestadv.ResetText()
            txtactive.Text = "1"
            Dim dr as DataRow
            dr = PopUpSearch("SELECT [accountGroup]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[ItemName]
      ,[SIGroup] from [MaS_SICODE] where 1=1", MainConnection)
            If isSearchOK Then
                sender.Text = dr("SICode").ToString
                txtadvDescription.Text = dr("ItemName").ToString
                'txtIsNewD.Text = "1"
            End If
        Catch ex as Exception

        End Try

    End Sub
    Private Sub Setdigittxt()
        SetDigit(txtQty)
        SetDigit(txtWHT)
        SetDigit(txtadvamount)
        SetDigit(txtChargeamount)
    End Sub

    Private Sub txtQty_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtWHT.KeyPress, txtQty.KeyPress, txtChargeamount.KeyPress, txtadvamount.KeyPress
        CheckDouble(e)
        If e.KeyChar = Chr(Keys.Enter) Then
            Setdigittxt()
        End If
    End Sub

    Private Sub txtQty_Leave(sender as Object, e as Eventargs) Handles txtWHT.Leave, txtQty.Leave, txtChargeamount.Leave, txtadvamount.Leave
        Setdigittxt()
    End Sub

    Event dgvadvDetailapproveButtonClick(sender as DataGridView, e as DataGridViewCellEventargs)
    Private Sub dgvadvDetail_CellContentClick(sender as Object, e as DataGridViewCellEventargs) Handles dgvadvDetail.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn andalso e.RowIndex >= 0 Then
            RaiseEvent dgvadvDetailapproveButtonClick(senderGrid, e)
        End If
    End Sub
    Private Sub Saveapprove()
        Try
            If dgvadvDetail.Rows.Count > 0 Then
                Dim nection as New OleDb.OleDbConnection()
                nection = ConnectDB()
                For row as Integer = 0 To dgvadvDetail.Rows.Count - 1
                    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateapproveadvance ")
                    SQLcommand.append("'" & CInt(dgvadvDetail.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(15).Value.ToString & "'") 'approveBy
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(16).Value.ToString & "'") 'approveDate
                    SQLcommand.append(",'" & dgvadvDetail.Rows(row).Cells(17).Value.ToString & "'") 'approveTIme
                    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then

                    Else

                    End If
                Next
                nection.Close()
            End If
            Userauthorize(UserProfile.U_Code, "aDVR")
            If Userauthen.IsCheckData = "1" Then
                EnableDetail()
            Else
                DisableDetail()
            End If

        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub DisableDetail()
        txtSICode.Enabled = False
        txtQty.Enabled = False
        txtUnit.Enabled = False
        txtWHT.Enabled = False
        txtadvamount.Enabled = False
        txtChargeamount.Enabled = False
    End Sub
    Private Sub dgvadvDetail_approveButtonClick(sender as DataGridView, e as DataGridViewCellEventargs) Handles Me.dgvadvDetailapproveButtonClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvadvDetail.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                Userauthorize(UserProfile.U_Code, "aPPaDV")
                If Userauthen.Isapprove = 1 Then
                    If String.IsNullOrEmpty(dgvadvDetail.CurrentRow.Cells(15).Value) Then
                        approveadv.ShowDialog()
                        Me.Isapproveadv = approveadv.Isapproveadv
                        'MsgBox(Isapproveadv)
                        'Exit Sub
                        If Isapproveadv = True Then
                            dgvadvDetail.CurrentRow.Cells(15).Value = UserProfile.U_FName & "  " & UserProfile.U_LName  'approveBy
                            dgvadvDetail.CurrentRow.Cells(16).Value = Now.ToShortDateString
                            dgvadvDetail.CurrentRow.Cells(17).Value = Now.ToShortTimeString
                            Saveapprove()
                        Else
                            Exit Sub
                        End If
                    Else
                        Dim frm as New frmPV
                        frm.txtJobNo.Text = dgvadvDetail.CurrentRow.Cells(1).Value.ToString
                        frm.txtOrderNo.Text = dgvadvDetail.CurrentRow.Cells(2).Value.ToString
                        frm.txtBookingNo.Text = dgvadvDetail.CurrentRow.Cells(3).Value.ToString
                        frm.txtSICode.Text = dgvadvDetail.CurrentRow.Cells(4).Value.ToString
                        frm.txtPVDescription.Text = dgvadvDetail.CurrentRow.Cells(5).Value.ToString
                        frm.txtQty.Text = dgvadvDetail.CurrentRow.Cells(6).Value.ToString
                        frm.txtUnit.Text = dgvadvDetail.CurrentRow.Cells(7).Value.ToString
                        frm.txtWHT.Text = dgvadvDetail.CurrentRow.Cells(8).Value.ToString
                        frm.txtadvamount.Text = dgvadvDetail.CurrentRow.Cells(9).Value.ToString
                        frm.txtChargeamount.Text = dgvadvDetail.CurrentRow.Cells(10).Value.ToString
                        frm.txtadvNo.Text = dgvadvDetail.CurrentRow.Cells(11).Value.ToString
                        frm.txtPVRemark.Text = dgvadvDetail.CurrentRow.Cells(12).Value.ToString
                        frm.txtRequestadv.Text = dgvadvDetail.CurrentRow.Cells(13).Value.ToString
                        'frm.dgvPV.Rows(e.RowIndex).Cells(1).Value = dgvadvDetail.Rows(e.RowIndex).Cells(1).Value
                        frm.ShowDialog()
                    End If

                Else
                    MetroFramework.MetroMessageBox.Show(Me, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Close()
                End If

            End If
        Catch ex as Exception

        End Try
    End Sub
    Private Sub dgvadvDetail_CellFormatting(sender as Object, e as DataGridViewCellFormattingEventargs) Handles dgvadvDetail.CellFormatting
        'If dgvadvDetail.CurrentRow.Cells(19).Value.ToString = "0" Then
        'e.CellStyle.BackColor = Color.Red
        'End If
    End Sub

    Private Sub Button4_Click_1(sender as Object, e as Eventargs) Handles Button4.Click
        If dgvadvDetail.CurrentRow.Cells(15).Value.ToString = "" Then

            If txtactive.Text = "1" Then
                txtactive.Text = "0"
            ElseIf txtactive.Text = "0" Then
                txtactive.Text = "1"
            End If
        Else
            Userauthorize(UserProfile.U_Code, "aDVR")
            If Userauthen.IsCheckData = "1" Then
                If txtactive.Text = "1" Then
                    txtactive.Text = "0"
                ElseIf txtactive.Text = "0" Then
                    txtactive.Text = "1"
                End If
            Else
                MsgBox("Cannot Delete approved Detail")
            End If
        End If
    End Sub

    Private Sub txtVendorName_ButtonClick(sender as Object, e as Eventargs) Handles txtVendorName.ButtonClick

    End Sub

    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        'If txtOrderNo.Text = "" Then
        '    MsgBox("Input Order Number First!!!")
        '    Exit Sub
        'End If
        Dim url as String = "http://203.170.129.23/transport/report/advancerequest?advno=" & txtadvNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex as Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub MetroTextBox1_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox1.ButtonClick
        If _IsNew = True Then
            _IsNew = False
            MsgBox("แก้ไขข้อมูลเก่า")
        Else
            _IsNew = True
            MsgBox("เพิ่มข้อมูลใหม่")
        End If
    End Sub
End Class