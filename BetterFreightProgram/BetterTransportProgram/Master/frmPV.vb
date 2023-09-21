Imports System.Data.OleDb
Imports System.Resources
Imports System.Text
Public Class frmPV
    Public _IsNew as Boolean
    Public _IsNewH as Boolean
    Private Sub frmPV_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        If txtSysUser.Text = "" Then
            txtSysUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName
        End If
        Userauthorize(UserProfile.U_Code, "PV")
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
            MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        LoadPVtodgv()
        cboChangeWHT.Text = "0%"
        '_IsNewH = Truex
        '_IsNew = True
        'txtIdent.Text = "0"
        'txtIdentH.Text = "0"
    End Sub
    Private Sub txtadvNo_ButtonClick(sender as Object, e as Eventargs) Handles txtadvNo.ButtonClick
        _IsNew = True
        If cboPVType.Text = "สมุดบัญชีจ่าย-เงินสด(JOB)" Or cboPVType.Text = "สมุดบัญชีจ่าย-ตั้งหนี้(JOB)" Then
            Dim dr as DataRow
            dr = PopUpSearch("  SELECT * From SelectadvPv WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtJobNo.Text = dr("JobNo").ToString
                txtadvNo.Text = dr("advNo").ToString
                txtOrderNo.Text = dr("OrderNo").ToString
                txtBookingNo.Text = dr("BookingNo").ToString
                txtSICode.Text = dr("SICode").ToString
                txtPVDescription.Text = dr("advDescription").ToString
                txtQty.Text = dr("Qty").ToString
                txtUnit.Text = dr("Unit").ToString
                txtWHT.Text = dr("WHT").ToString
                txtadvamount.Text = dr("advamount").ToString
                txtChargeamount.Text = dr("Chargeamount").ToString
                txtPVRemark.Text = dr("advRemark").ToString
                txtRequestadv.Text = dr("Requestadv").ToString
                txtPVUnitamount.Text = dr("UnitPrice").ToString
                'PVVat.Text = dr("PVVat").ToString
            End If
        End If
    End Sub
    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        If _IsNew = True Then
            SavePV(1)
        Else
            SavePV(0)
        End If
    End Sub
    Private Sub SavePV(_insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdatePV_Description ")
            SQLcommand.append("'" & CInt(txtIdent.Text) & "'") 'Ident
            SQLcommand.append(",'" & txtJobNo.Text & "'") 'JobNo
            SQLcommand.append(",'" & txtOrderNo.Text & "'") 'OrderNo
            SQLcommand.append(",'" & txtBookingNo.Text & "'") 'BookingNo
            SQLcommand.append(",'" & txtSICode.Text & "'") 'SICode
            SQLcommand.append(",'" & txtPVDescription.Text & "'") 'PVDescription
            SQLcommand.append(",'" & CDbl(txtQty.Text) & "'") 'Qty
            SQLcommand.append(",'" & txtUnit.Text & "'") 'Unit
            SQLcommand.append(",'" & CDbl(txtWHT.Text) & "'") 'WHT
            SQLcommand.append(",'" & CDbl(txtadvamount.Text) & "'") 'advamount
            SQLcommand.append(",'" & CDbl(txtChargeamount.Text) & "'") 'Chargeamount
            SQLcommand.append(",'" & txtadvNo.Text & "'") 'aDVNo
            SQLcommand.append(",'" & txtPVRemark.Text & "'") 'PVRemark
            SQLcommand.append(",'" & CDbl(txtPVUnitamount.Text) & "'") 'PVUnitamount
            SQLcommand.append(",'" & txtPVVat.Text & "'") 'PVVat
            SQLcommand.append(",'" & txtDocCreateNo.Text & "'")
            SQLcommand.append(",'" & CInt(txtactive.Text) & "'")
            SQLcommand.append(",'" & txtRequestadv.Text & "'")
            SQLcommand.append(",'" & txtReceiptNo.Text & "'")
            SQLcommand.append(",'" & LetDate(dtpRecieptNoDate.Value) & "'")
            SQLcommand.append(",'" & txtVendorName.Text & "'")
            SQLcommand.append(",'" & CDbl(txtTotalamount.Text) & "'")
            SQLcommand.append(",'" & CDbl(txtNetTotalamount.Text) & "'")
            SQLcommand.append(",'" & txtPVVat.Text & "'")
            SQLcommand.append(",'" & txtInvoice.Text & "'")
            SQLcommand.append(",'" & LetDate(dtpInvoiceDate.Value) & "'")
            SQLcommand.append(",'" & txtVendorName.Text & "'")
            SQLcommand.append(",'" & txtVendorCode.Text & "'")
            'SQLcommand.append(",'" & txtIsPV.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPVtodgv()
                _IsNew = False
                _IsNewH = False
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadPVtodgv()
        Try
            dgvPV.Rows.Clear()
            If txtDocCreateNo.Text = "" Then
                addNewData()
                addNewDetail()
                Exit Sub
            End If
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM PV_Description where 1=1 and active='1'"
            If Not String.IsNullOrEmpty(txtDocCreateNo.Text) Then str &= " aND DocumentNo='" & txtDocCreateNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvPV.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'aDVNo
                    dt.Rows(i)(2).ToString(), 'JobNo
                    dt.Rows(i)(3).ToString(), 'OrderNo
                    dt.Rows(i)(4).ToString(), 'BookingNo
                    dt.Rows(i)(5).ToString(), 'SICode
                    dt.Rows(i)(6).ToString(), 'PVDescription
                    dt.Rows(i)(7).ToString(), 'Qty
                    dt.Rows(i)(8).ToString(), 'Unit
                    dt.Rows(i)(9).ToString(), 'WHT
                    dt.Rows(i)(10).ToString(), 'advamount
                    dt.Rows(i)(11).ToString(), 'Chargeamount
                    dt.Rows(i)(12).ToString(), 'WHT
                    dt.Rows(i)(13).ToString(), 'advamount
                    dt.Rows(i)(14).ToString(), 'Chargeamount
                    dt.Rows(i)(15).ToString(),
                    dt.Rows(i)(16).ToString(),
                    dt.Rows(i)(17).ToString(),
                    dt.Rows(i)(18).ToString(),
                    dt.Rows(i)(19).ToString(),
                    dt.Rows(i)(20).ToString(),
                    dt.Rows(i)(21).ToString(),
                    dt.Rows(i)(22).ToString
                    )
                    'dt.Rows(i)(12).ToString()
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
                _IsNewH = False
                _IsNew = False
                addNetPayment()
                'txtIdent.Text = "0"
                'txtIdentH.Text = "0"
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        txtPVUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName
        GetRunningFormat("PV")
        txtPVNo.Text = CreateNumber("PV_Header", "PVNo", dtpPVDate.Value)
    End Sub
    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        If txtDocCreateNo.Text = "" Then
            RunPV()
        End If
        If txtDocCreateNo.Text = "ERROR" Then
            MsgBox("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้ กรุณารีสตาร์ทโปรแกรม")
            Exit Sub
        End If
        '  MsgBox(_IsNewH)
        If _IsNewH = True Then
            If CheckDup("PV_Header", "DocCreateNo", txtDocCreateNo.Text) Then
                MetroFramework.MetroMessageBox.Show(Main, "Duplicated Job number ", "Save Job", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            SaveHeader(1)
        Else
            SaveHeader(0)
        End If

    End Sub
    Private Sub RunPV()
        If cboPVType.Text = "สมุดบัญชีจ่าย-เงินสด(JOB)" Then
            GetRunningFormat("JOB")
            txtDocCreateNo.Text = CreateNumber("PV_Header", "DocCreateNo", dtpDocNoDate.Value)
        End If
        If cboPVType.Text = "สมุดบัญชีจ่าย-ตั้งหนี้(JOB)" Then
            GetRunningFormat("JOB")
            txtDocCreateNo.Text = CreateNumber("PV_Header", "DocCreateNo", dtpDocNoDate.Value)
        End If
        If cboPVType.Text = "สมุดบัญชีจ่าย-เงินสด(ทั่วไป)" Then
            GetRunningFormat("GEN")
            txtDocCreateNo.Text = CreateNumber("PV_Header", "DocCreateNo", dtpDocNoDate.Value)
        End If
        If cboPVType.Text = "สมุดบัญชีจ่าย-ตั้งหนี้(ทั่วไป)" Then
            GetRunningFormat("GEN")
            txtDocCreateNo.Text = CreateNumber("PV_Header", "DocCreateNo", dtpDocNoDate.Value)
        End If
    End Sub
    Private Sub SaveHeader(_insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdatePV_Header ")
            SQLcommand.append("'" & txtIdentH.Text & "'") 'Ident
            SQLcommand.append(",'" & cboPVType.Text & "'") 'PVType
            SQLcommand.append(",'" & txtDocCreateNo.Text & "'") 'DocCreateNo
            SQLcommand.append(",'" & LetDate(dtpDocNoDate.Value) & "'") 'DocNoDate
            SQLcommand.append(",'" & txtDocTime.Text & "'") 'DocTime
            SQLcommand.append(",'" & txtBookaccount.Text & "'") 'Bookaccount
            SQLcommand.append(",'" & txtTransferNo.Text & "'") 'TransferNo
            SQLcommand.append(",'" & LetDate(dtpPVDate.Value) & "'") 'PVDate
            SQLcommand.append(",'" & txtVendorName.Text & "'") 'VendorName
            SQLcommand.append(",'" & txtPayFor.Text & "'") 'PsyFor
            SQLcommand.append(",'" & txtVendorBankNo.Text & "'") 'BankNo
            SQLcommand.append(",'" & txtInvoice.Text & "'") 'Invoice
            SQLcommand.append(",'" & LetDate(dtpPayDate.Value) & "'") 'PayDate
            SQLcommand.append(",'" & txtPVNo.Text & "'") 'PVNo
            SQLcommand.append(",'" & txtReceiptNo.Text & "'") 'ReceiptNo
            SQLcommand.append(",'" & txtactive.Text & "'")
            SQLcommand.append(",'" & txtSysUser.Text & "'")
            SQLcommand.append(",'" & txtBankName.Text & "'")
            SQLcommand.append(",'" & txtPVUser.Text & "'")
            SQLcommand.append(",'" & txtVenID.Text & "'")
            SQLcommand.append(",'" & txtNetPayment.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNewH = False
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub txtVendorName_ButtonClick(sender as Object, e as Eventargs) Handles txtVendorName.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [VendorName],[VendorID],VendorBankName,Ident  FROM [Mas_VendorTransport] WHERE 1=1 order by [VendorName] ", MainConnection)
        If isSearchOK Then
            txtVendorName.Text = dr("VendorName").ToString
            txtBankName.Text = dr("VendorBankName").ToString
            txtVenID.Text = dr("Ident").ToString
            txtVendorCode.Text = dr("VendorID").ToString
        End If
    End Sub
    Private Sub txtPayFor_ButtonClick(sender as Object, e as Eventargs) Handles txtPayFor.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [VendorName],[VendorBankName],[VendorBankNo]  FROM [Mas_VendorTransport] WHERE 1=1 order by [VendorName] ", MainConnection)
        If isSearchOK Then
            txtPayFor.Text = dr("VendorName").ToString
            txtVendorBankNo.Text = dr("VendorBankNo").ToString
        End If
    End Sub
    Private Sub txtBookaccount_ButtonClick(sender as Object, e as Eventargs) Handles txtBookaccount.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [BookingNo],[accountName],[accountType]  FROM [Bookaccount] WHERE 1=1  order by [BookingNo] ", MainConnection)
        If isSearchOK Then
            txtBookaccount.Text = dr("BookingNo").ToString
        End If
    End Sub
    Private Sub txtSICode_ButtonClick(sender as Object, e as Eventargs) Handles txtSICode.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [accountGroup]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[ItemName]
      ,[SIGroup]  FROM [MaS_SICODE] WHERE 1=1  order by SICode ", MainConnection)
        If isSearchOK Then
            txtSICode.Text = dr("SICode").ToString()
            txtPVDescription.Text = dr("ItemName").ToString
        End If
    End Sub
    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        If txtSysUser.Text = "" Then
            txtSysUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName
        End If
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [DocCreateNo]
      ,[PVType]
      ,[DocNoDate]
      ,[DocTime]
      ,[Bookaccount]
      ,[TransferNo]
      ,[PVDate]
      ,[VendorName]
      ,[PsyFor]
      ,[BankNo]
      ,[Invoice]
      ,[PayDate]
      ,[PVNo]
      ,[ReceiptNo]
      ,[active]
      ,[SysUser]
      ,[BankName]
      ,[PVUser]
      ,[VenIdent]
      ,[PVCreateDate]
      ,[PVUpdateDate]
      ,[WHTDOCNO]
,Ident FROM [PV_Header] WHERE active='1'  order by DocCreateNo ", MainConnection)
        If isSearchOK Then
            txtIdentH.Text = dr("ident").ToString
            txtDocCreateNo.Text = dr("DocCreateNo").ToString
            LoadDataPVHeader()

        End If
    End Sub
    Private Sub LoadDataPVHeader()
        'Try
        Dim str as String = " SELECT * FROM [PV_Header] WHERE active='1'  "
        str &= " aND DocCreateNo='" & txtDocCreateNo.Text & "'"
        Dim dr as DataRow = SelectSingleRow(str)
        If dr IsNot Nothing Then
            txtIdentH.Text = dr("ident").ToString
            cboPVType.Text = dr("PVType").ToString
            txtDocCreateNo.Text = dr("DocCreateNo").ToString
            dtpDocNoDate.Text = dr("DocNoDate").ToString
            txtDocTime.Text = dr("DocTime").ToString
            txtBookaccount.Text = dr("Bookaccount").ToString
            txtTransferNo.Text = dr("TransferNo").ToString
            dtpPVDate.Text = dr("PVDate").ToString
            txtVendorName.Text = dr("VendorName").ToString
            txtPayFor.Text = dr("PsyFor").ToString
            txtVendorBankNo.Text = dr("BankNo").ToString
            txtInvoice.Text = dr("Invoice").ToString
            dtpPayDate.Text = dr("PayDate").ToString
            txtPVNo.Text = dr("PVNo").ToString
            txtReceiptNo.Text = dr("ReceiptNo").ToString
            txtHactive.Text = dr("active").ToString
            txtBankName.Text = dr("BanKName").ToString
            txtSysUser.Text = dr("SysUser").ToString
            txtVenID.Text = dr("VenIdent").ToString
            txtWHTDOCNO.Text = dr("WHTDOCNO").ToString
            LoadPVtodgv()
            _IsNewH = False
            _IsNew = False
        End If
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click
        If txtDocCreateNo.Text.Substring(0, 3) <> "GEN" Then
            Dim url as String = "http://203.170.129.23/transport/report/voucher?docCreateNo=" & txtDocCreateNo.Text
            Try
                Process.Start("chrome.exe", url)
            Catch ex as Exception
                Process.Start(url)
            End Try
        Else
            Dim url as String = "http://203.170.129.23/transport/report/pvnojob?docCreateNo=" & txtDocCreateNo.Text
            Try
                Process.Start("chrome.exe", url)
            Catch ex as Exception
                Process.Start(url)
            End Try
        End If
    End Sub

    Private Sub Button7_Click(sender as Object, e as Eventargs) Handles Button7.Click
        txtadvNo.Text = PVCancel.txtadvNo.Text
        PVCancel.ShowDialog()
        If PVCancel.Isactive = False Then
            txtactive.Text = "0"
            SavePV(0)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub dgvPV_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvPV.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvPV.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdent.Text = CInt(dgvPV.CurrentRow.Cells(0).Value.ToString()) 'Ident
                txtJobNo.Text = dgvPV.CurrentRow.Cells(1).Value.ToString() 'JobNo
                txtOrderNo.Text = dgvPV.CurrentRow.Cells(2).Value.ToString() 'OrderNo
                txtBookingNo.Text = dgvPV.CurrentRow.Cells(3).Value.ToString() 'BookingNo
                txtSICode.Text = dgvPV.CurrentRow.Cells(4).Value.ToString() 'SICode
                txtPVDescription.Text = dgvPV.CurrentRow.Cells(5).Value.ToString() 'PVDescription
                txtQty.Text = CInt(dgvPV.CurrentRow.Cells(6).Value.ToString()) 'Qty
                txtUnit.Text = dgvPV.CurrentRow.Cells(7).Value.ToString() 'Unit
                txtWHT.Text = CInt(dgvPV.CurrentRow.Cells(8).Value.ToString()) 'WHT
                txtadvamount.Text = dgvPV.CurrentRow.Cells(9).Value.ToString() 'advamount
                txtChargeamount.Text = dgvPV.CurrentRow.Cells(10).Value.ToString() 'Chargeamount
                txtadvNo.Text = dgvPV.CurrentRow.Cells(11).Value.ToString() 'aDVNo
                txtPVRemark.Text = dgvPV.CurrentRow.Cells(12).Value.ToString() 'PVRemark
                txtPVUnitamount.Text = dgvPV.CurrentRow.Cells(13).Value.ToString() 'PVUnitamount
                txtPVVat.Text = dgvPV.CurrentRow.Cells(14).Value.ToString() 'PVVat
                'txtDocCreateNo.Text = dgvPV.CurrentRow.Cells(15).Value.ToString() 'DocumentNo
                txtactive.Text = dgvPV.CurrentRow.Cells(16).Value.ToString() 'active
                txtRequestadv.Text = dgvPV.CurrentRow.Cells(17).Value.ToString()
                txtReceiptNo.Text = dgvPV.CurrentRow.Cells(18).Value.ToString()
                dtpRecieptNoDate.Value = dgvPV.CurrentRow.Cells(19).Value.ToString()
                txtVendorName.Text = dgvPV.CurrentRow.Cells(20).Value.ToString()
                _IsNew = False
                'CalPvItem()
            End If
        Catch ex as Exception

        End Try
    End Sub

    Private Sub addNetPayment()
        Dim NetPayment as Double = 0
        'Dim amt as Double = 0
        If dgvPV.Rows.Count > 0 Then
            For i as Integer = 0 To dgvPV.Rows.Count - 1
                'amt += dgvRV.Rows(i).Cells(9).Value
                NetPayment += CDbl(dgvPV.Rows(i).Cells(22).Value) ' + dgvRV.Rows(i).Cells(10).Value
            Next
            txtNetPayment.Text = NetPayment.ToString("#,##0.00")
        Else
            txtNetPayment.Text = NetPayment.ToString("#,##0.00")
        End If
    End Sub

    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        Cancel.ShowDialog()
        If Cancel.Isactive = False Then
            txtHactive.Text = "0"
            SaveHeader(0)
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub dgvPV_CellContentClick(sender as Object, e as DataGridViewCellEventargs) Handles dgvPV.CellContentClick

    End Sub

    Private Sub Button8_Click(sender as Object, e as Eventargs) Handles Button8.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT
        [Ident]
        ,[JobNo]
        ,[OrderNo]
        ,[BookingNo]
        ,[SICode]
        ,[PVDescription]
        ,[Qty]
        ,[Unit]
        ,[WHT]
        ,[advamount]
        ,[Chargeamount]
        ,[aDVNo]
        ,[PVRemark]
        ,[PVUnitamount]
        ,[PVVat]
        ,[DocumentNo]
        ,[active],[PVRequest]  FROM [PV_Description] WHERE active='1'  order by JobNo", MainConnection)
        If isSearchOK Then
            txtDocCreateNo.Text = dr("DocumentNo").ToString
        End If

    End Sub
    Private Sub LoadDataToPV()
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [Ident]
      ,[PVType]
      ,[DocCreateNo]
      ,[DocNoDate]
      ,[DocTime]
      ,[Bookaccount]
      ,[TransferNo]
      ,[PVDate]
      ,[VendorName]
      ,[PsyFor]
      ,[BankNo]
      ,[Invoice]
      ,[PayDate]
      ,[PVNo]
      ,[ReceiptNo]
      ,[active]
      ,[SysUser]
      ,[BankName] where DocCreateNo='" & txtDocCreateNo.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtIdentH.Text = dr("ident").ToString
                cboPVType.Text = dr("PVType").ToString
                txtDocCreateNo.Text = dr("DocCreateNo").ToString
                dtpDocNoDate.Text = dr("DocNoDate").ToString
                txtDocTime.Text = dr("DocTime").ToString
                txtBookaccount.Text = dr("Bookaccount").ToString
                txtTransferNo.Text = dr("TransferNo").ToString
                dtpPVDate.Text = dr("PVDate").ToString
                txtVendorName.Text = dr("VendorName").ToString
                txtPayFor.Text = dr("PsyFor").ToString
                txtVendorBankNo.Text = dr("BankNo").ToString
                txtInvoice.Text = dr("Invoice").ToString
                dtpPayDate.Text = dr("PayDate").ToString
                txtPVNo.Text = dr("PVNo").ToString
                txtReceiptNo.Text = dr("ReceiptNo").ToString
                txtHactive.Text = dr("active").ToString
                txtBankName.Text = dr("BanKName").ToString
                txtSysUser.Text = dr("SysUser").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtNetPayment_Click(sender as Object, e as Eventargs) Handles txtNetPayment.Click

    End Sub

    Private Sub Button9_Click(sender as Object, e as Eventargs) Handles Button9.Click
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT Requestadv from [advanceRequestDetail] where advNo='" & txtadvNo.Text & "'and SICode='" & txtSICode.Text & "' and advamount='" & txtadvamount.Text & "' and Chargeamount='" & txtChargeamount.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtRequestadv.Text = dr("Requestadv").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button10_Click(sender as Object, e as Eventargs) Handles Button10.Click
        If txtSysUser.Text = "" Then
            txtSysUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName
        End If
        addNewData()
        addNewDetail()
    End Sub
    Private Sub addNewData()
        txtIdentH.Text = "0" 'Ident
        cboPVType.ResetText() 'PVType
        txtDocCreateNo.ResetText() 'DocCreateNo
        dtpDocNoDate.ResetText() 'DocNoDate
        txtDocTime.ResetText() 'DocTime
        txtBookaccount.ResetText() 'Bookaccount
        txtTransferNo.ResetText() 'TransferNo
        dtpPVDate.ResetText() 'PVDate
        txtVendorName.ResetText() 'VendorName
        txtPayFor.ResetText() 'PsyFor
        txtVendorBankNo.ResetText() 'BankNo
        txtInvoice.ResetText() 'Invoice
        dtpPayDate.ResetText() 'PayDate
        txtPVNo.ResetText() 'PVNo
        txtReceiptNo.ResetText() 'ReceiptNo
        txtactive.Text = "1" 'active
        txtSysUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName 'SysUser
        txtBankName.ResetText() 'BankName
        txtVenID.Text = "0"
        _IsNewH = True
    End Sub
    Private Sub addNewDetail()
        txtIdent.Text = "0" 'Ident
        txtJobNo.ResetText() 'JobNo
        txtOrderNo.ResetText() 'OrderNo
        txtBookingNo.ResetText() 'BookingNo
        txtSICode.ResetText() 'SICode
        txtPVDescription.ResetText() 'PVDescription
        txtQty.ResetText() 'Qty
        txtUnit.ResetText() 'Unit
        txtWHT.ResetText() 'WHT
        txtadvamount.ResetText() 'advamount
        txtChargeamount.ResetText() 'Chargeamount
        txtadvNo.ResetText() 'aDVNo
        txtPVRemark.ResetText() 'PVRemark
        txtPVUnitamount.ResetText() 'PVUnitamount
        txtPVVat.ResetText() 'PVVat
        txtactive.Text = "1" 'active
        _IsNew = True
    End Sub

    Private Sub MetroComboBox1_TextChanged(sender as Object, e as Eventargs) Handles cboChangeWHT.TextChanged
        If cboChangeWHT.Text = "1%" Then
            txtWHT.Text = "1"
        ElseIf cboChangeWHT.Text = "1.5%" Then
            txtWHT.Text = "1.5"
        ElseIf cboChangeWHT.Text = "2%" Then
            txtWHT.Text = "2"
        ElseIf cboChangeWHT.Text = "3%" Then
            txtWHT.Text = "3"
        ElseIf cboChangeWHT.Text = "4%" Then
            txtWHT.Text = "4"
        ElseIf cboChangeWHT.Text = "5%" Then
            txtWHT.Text = "5"
        ElseIf cboChangeWHT.Text = "6%" Then
            txtWHT.Text = "6"
        ElseIf cboChangeWHT.Text = "7%" Then
            txtWHT.Text = "7"
        ElseIf cboChangeWHT.Text = "8%" Then
            txtWHT.Text = "8"
        ElseIf cboChangeWHT.Text = "9%" Then
            txtWHT.Text = "9"
        ElseIf cboChangeWHT.Text = "10%" Then
            txtWHT.Text = "10"
        ElseIf cboChangeWHT.Text = "15%" Then
            txtWHT.Text = "15"
        ElseIf cboChangeWHT.Text = "20%" Then
            txtWHT.Text = "20"
        ElseIf cboChangeWHT.Text = "0%" Then
            txtWHT.Text = "0"
        End If
    End Sub

    Private Sub frmPV_FormClosing(sender as Object, e as FormClosingEventargs)

    End Sub


    Private Sub CalPvItem()
        If txtChargeamount.Text = "0" Then
            txtChargeamount.Text = txtPVUnitamount.Text
        End If
        If txtPVUnitamount.Text = "0" Then
            txtPVUnitamount.Text = txtChargeamount.Text
        End If
        Dim qty as Double = CDbl(txtQty.Text)
        Dim UnitPrice as Double = CDbl(txtPVUnitamount.Text)
        txtChargeamount.Text = (qty * UnitPrice).ToString("#,##0.00")
        Dim chr as Double = CDbl(txtChargeamount.Text)
        Dim Vamt as Double = 0
        Dim Vrate as Double = CDbl(txtPVVat.Text)
        Dim amtVat as Double = 0

        Dim Trate as Double = CDbl(txtWHT.Text)
        Dim Tamt as Double = 0
        Dim amtT as Double = 0
        Dim NetTotal as Double = 0
        Dim Total as Double = 0

        If Vrate > 0 Then
            Vamt = (Vrate / 100) * chr
            '    amtVat = Vamt + chr
            'Else
            '    amtVat = chr
        End If

        If Trate > 0 Then
            Tamt = (Trate / 100) * chr
            ' amtT = amtVat - Tamt
        End If
        Total = chr + Vamt
        NetTotal = chr + Vamt - Tamt
        txtNetTotalamount.Text = NetTotal.ToString("#,##0.000")
        txtTotalamount.Text = Total.ToString("#,##0.000")
    End Sub

    Private Sub txtQty_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtQty.KeyPress, txtPVVat.KeyPress, txtPVUnitamount.KeyPress, txtChargeamount.KeyPress
        CheckDouble(e)
        If e.KeyChar = Chr(Keys.Enter) Then
            CalPvItem()
        End If
    End Sub

    Private Sub Button11_Click(sender as Object, e as Eventargs) Handles btnCreateWHT.Click
        If Not String.IsNullOrEmpty(txtDocCreateNo.Text) Then
            If txtWHTDOCNO.Text <> "" Then
                Dim frm as New WHT1
                frm.txtDocControlNO.Text = Me.txtWHTDOCNO.Text
                frm.ShowDialog()
                ' Exit Sub
            Else
                Dim frm as New WHT1
                frm.txtDocRefNo.Text = Me.txtDocCreateNo.Text
                frm.ShowDialog()
            End If

            LoadDataPVHeader()
        End If

    End Sub

    Private Sub frmPV_FormClosing_1(sender as Object, e as FormClosingEventargs) Handles MyBase.FormClosing
        If MetroFramework.MetroMessageBox.Show(Me, "Do You Want to Close The Program", "Form Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub txtWHT_TextChanged(sender as Object, e as Eventargs) Handles txtWHT.TextChanged
        If txtWHT.Text = "0" Then
            cboChangeWHT.Text = "0%"
        ElseIf txtWHT.Text = "1" Then
            cboChangeWHT.Text = "1%"
        ElseIf txtWHT.Text = "1.5" Then
            cboChangeWHT.Text = "1.5%"
        ElseIf txtWHT.Text = "2" Then
            cboChangeWHT.Text = "2%"
        ElseIf txtWHT.Text = "3" Then
            cboChangeWHT.Text = "3%"
        ElseIf txtWHT.Text = "4" Then
            cboChangeWHT.Text = "4%"
        ElseIf txtWHT.Text = "5" Then
            cboChangeWHT.Text = "5%"
        ElseIf txtWHT.Text = "6" Then
            cboChangeWHT.Text = "6%"
        ElseIf txtWHT.Text = "7" Then
            cboChangeWHT.Text = "7%"
        ElseIf txtWHT.Text = "8" Then
            cboChangeWHT.Text = "8%"
        ElseIf txtWHT.Text = "9" Then
            cboChangeWHT.Text = "9%"
        ElseIf txtWHT.Text = "10" Then
            cboChangeWHT.Text = "10%"
        ElseIf txtWHT.Text = "15" Then
            cboChangeWHT.Text = "15%"
        ElseIf txtWHT.Text = "20" Then
            cboChangeWHT.Text = "20%"
        End If
    End Sub

    Private Sub MetroTextBox2_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox2.ButtonClick
        If _IsNew = True Then
            _IsNew = False
            MsgBox("แก้ไขรายการใหม่")
        ElseIf _IsNew = False Then
            _IsNew = True
            MsgBox("เพิ่มรายการใหม่")
        End If
    End Sub
End Class