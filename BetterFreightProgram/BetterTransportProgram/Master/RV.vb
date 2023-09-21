Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Imports MetroFramework.Controls

Public Class RV
    Public _IsNew as Boolean
    Public _IsNewD as Boolean
    Private Sub RV_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        addNewRV()
        'LoadDataToRV()
    End Sub
    Private Sub addNewRV()
        txtIdent.Text = "0" 'Ident
        txtRVType.ResetText() 'RVType
        txtDocNo.ResetText() 'DocNo
        txtDocCreateDate.ResetText() 'DocCreateDate
        txtDocCreateTime.ResetText() 'DocCreateTime
        txtBookaccount.ResetText() 'Bookaccount
        txtReferenceNo.ResetText() 'ReferenceNo
        txtRVReceivedMoneyDate.ResetText() 'RVReceivedMoneyDate
        txtRVNo.ResetText() 'RVNo
        'txtTransferNo.ResetText() 'TransferNo
        txtTotalamountReceived.ResetText() 'TotalamountReceived
        txtBankNoDate.ResetText() 'BankNoDate
        txtReceivedFrom.ResetText() 'ReceivedFrom
        txtCustomerName.ResetText() 'CustomerName
        txtCurrentUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName
        _IsNew = True
    End Sub
    Private Sub addNewRVDetail()
        txtSearchInvoiceNo.ResetText()
        txtJobNo.ResetText()
        txtOrderNo.ResetText()
        txtBookingNo.ResetText()
        txtSICode.ResetText()
        txtSICodeDescription.ResetText()
        txtRVRemark.ResetText()
        txtQty.ResetText()
        txtUnit.ResetText()
        txtUnitamount.ResetText()
        txtVaT.Text = "0"
        txtWHT.Text = "0"
        txtadvamount.Text = "0"
        txtChargeamount.Text = "0"
        txtIdent.Text = "0"
        _IsNewD = True
    End Sub
    Private Sub SaveRV(_insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateRV_Header ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtRVType.Text & "'") 'RVType
            SQLcommand.append(",'" & txtDocNo.Text & "'") 'DocNo
            SQLcommand.append(",'" & ToDBDate(txtDocCreateDate.Value) & "'") 'DocCreateDate
            SQLcommand.append(",'" & txtDocCreateTime.Text & "'") 'DocCreateTime
            SQLcommand.append(",'" & txtBookaccount.Text & "'") 'Bookaccount
            SQLcommand.append(",'" & txtReferenceNo.Text & "'") 'ReferenceNo
            SQLcommand.append(",'" & ToDBDate(txtRVReceivedMoneyDate.Value) & "'") 'RVReceivedMoneyDate
            SQLcommand.append(",'" & txtRVNo.Text & "'") 'RVNo
            SQLcommand.append(",'" & ToDBDate(dtpChqDate.Value) & "'") 'TransferNo
            SQLcommand.append(",'" & txtTotalamountReceived.Text & "'") 'TotalamountReceived
            SQLcommand.append(",'" & txtBankNoDate.Text & "'") 'BankNoDate
            SQLcommand.append(",'" & txtReceivedFrom.Text & "'") 'ReceivedFrom
            SQLcommand.append(",'" & txtCustomerName.Text & "'") 'CustomerName
            SQLcommand.append(",'" & txtCurrentUser.Text & "'")
            SQLcommand.append(",'" & txtactive.Text & "'")
            SQLcommand.append(",'" & CDbl(txtPaymentDiff.Text) & "'")
            SQLcommand.append(",'" & CDbl(txtTotaladvance.Text) & "'")
            SQLcommand.append(",'" & CDbl(txtTotalCharge.Text) & "'")
            SQLcommand.append(",'" & CDbl(txtTotalWHT.Text) & "'")
            SQLcommand.append(",'" & CDbl(txtTotalTotalamount.Text) & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                txtactive.Text = "1"
                LoadDataToRV()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub addData()
        Dim Totaladvance as Double = 0
        Dim TotalCharge as Double = 0
        Dim TotalWHT as Double = 0
        Dim TotalTotalamount as Double = 0
        'Dim amt as Double = 0
        If dgvRV.Rows.Count > 0 Then
            For i as Integer = 0 To dgvRV.Rows.Count - 1
                'amt += dgvRV.Rows(i).Cells(9).Value
                Totaladvance += CDbl(dgvRV.Rows(i).Cells(21).Value) ' + dgvRV.Rows(i).Cells(10).Value 
                TotalCharge += CDbl(dgvRV.Rows(i).Cells(20).Value)
                TotalWHT += CDbl(dgvRV.Rows(i).Cells(15).Value)
                TotalTotalamount += CDbl(dgvRV.Rows(i).Cells(17).Value)
            Next
            txtTotaladvance.Text = Totaladvance.ToString("#,##0.00")
            txtTotalCharge.Text = TotalCharge.ToString("#,##0.00")
            txtTotalWHT.Text = TotalWHT.ToString("#,##0.00")
            txtTotalTotalamount.Text = TotalTotalamount.ToString("#,##0.00")
        Else
            txtTotaladvance.Text = Totaladvance.ToString("#,##0.00")
            txtTotalCharge.Text = TotalCharge.ToString("#,##0.00")
            txtTotalWHT.Text = TotalWHT.ToString("#,##0.00")
            txtTotalTotalamount.Text = TotalTotalamount.ToString("#,##0.00")
        End If
    End Sub
    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        If txtDocNo.Text = "" Then
            If txtRVType.Text = "สมุดบัญชีรับ-เงินสด(JOB)" Or txtRVType.Text = "สมุดบัญชีรับ-ลูกหนี้(JOB)" Then
                RunREC()
            Else
                RunGEP()
            End If
            If txtDocNo.Text = "ERROR" Then
                MsgBox("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้ กรุณารีสตาร์ทโปรแกรม")
                Exit Sub
            End If
        Else
        End If
        If _IsNew = True Then
            SaveRV(1)
        Else
            SaveRV(0)
        End If
    End Sub
    Private Sub RunGEP()
        GetRunningFormat("GEP")
        txtDocNo.Text = CreateNumber("RV_Header", "DocNo", txtDocCreateDate.Value)
    End Sub
    Private Sub RunREC()
        GetRunningFormat("REC")
        txtDocNo.Text = CreateNumber("RV_Header", "DocNo", txtDocCreateDate.Value)
    End Sub
    Private Sub MetroTextBox2_ButtonClick(sender as Object, e as Eventargs) Handles txtSearchInvoiceNo.ButtonClick
        _IsNewD = True
        If txtRVType.Text = "สมุดบัญชีรับ-เงินสด(JOB)" Or txtRVType.Text = "สมุดบัญชีรับ-ลูกหนี้(JOB)" Then
            Dim dr as DataRow
            dr = PopUpSearch("SELECT [Ident]
            ,[InvoiceNo]
            ,[InvoiceDate]
            ,[TaxInvNo]
            ,[TaxInvDate]
            ,[Customer]
            ,[CustomerCode]
            ,[Customeraddress]
            ,[BTTLocation]
            ,[PickupLocation]
            ,[LoadingLocation]
            ,[ReturnLocation]
            ,[JobNo]
            ,[VesselBooking]
            ,[BLNo]
            ,[TransportCharge]
            ,[Reinbursement]
            ,[Totalamount]
            ,[CurrentUser]
            ,[active]
            ,[InvSum]
            ,[ReinburseCharge]
            ,[ChangeTax]
            ,[ChangeVat]
            ,[SoaNo]
            FROM [Invoice_Header] where 1=1 and RVNo is NULL", MainConnection) 'and InvoiceNo <> '' 
            If isSearchOK Then
                addNewRVDetail()
                txtIdent.Text = dr("Ident").ToString
                'txtadvType.Text = dr("advType").ToString
                txtSearchInvoiceNo.Text = dr("InvoiceNo").ToString
                txtJobNo.Text = dr("JobNo").ToString
                'txtOrderNo.Text = dr("OrderNo").ToString
                'txtQty.Text = dr("Qty").ToString
                'txtSICodeDescription.Text = dr("advDescription").ToString
                'txtUnitamount.Text = dr("Unit").ToString
                'txtSICode.Text = dr("advCode").ToString
                'txtQty.Text = dr("Qty").ToString
                txtBookingNo.Text = dr("VesselBooking").ToString
                txtChargeamount.Text = dr("InvSum").ToString
                txtadvamount.Text = dr("ReinburseCharge").ToString
                txtCustCode.Text = dr("CustomerCode").ToString
                txtWHT.Text = (CDbl(dr("ReinburseCharge")) * "0.01")
                txtTotalamount.Text = dr("Totalamount").ToString
            End If
        ElseIf txtRVType.Text = "สมุดบัญชีรับ-เงินสด(ทั่วไป)" Or txtRVType.Text = "สมุดบัญชีรับ-ลูกหนี้(ทั่วไป)" Then
            Dim dr as DataRow
            dr = PopUpSearch("SELECT [Ident]
            ,[advCode]
            ,[advDescription]
            ,[advType]
            ,[amount]
            ,[advContainerNo]
            ,[advStatus]
            ,[OrderNo]
            ,[active]
            ,[SysUser]
            ,[JobNo]
            ,[InvoiceNo]
            ,[TaxInvNo]
            ,[SoaNo]
            ,[SelectInv]
            ,[CustCode]
            ,[Qty]
            ,[Unit] FROM [Pre_Invoice] where 1=1 and InvoiceNo <> ''", MainConnection)
            If isSearchOK Then
                addNewRVDetail()
                txtadvType.Text = dr("advType").ToString
                txtSearchInvoiceNo.Text = dr("InvoiceNo").ToString
                txtJobNo.Text = dr("JobNo").ToString
                txtOrderNo.Text = dr("OrderNo").ToString
                txtQty.Text = dr("Qty").ToString
                txtSICodeDescription.Text = dr("advDescription").ToString
                txtUnitamount.Text = dr("Unit").ToString
                txtSICode.Text = dr("advCode").ToString
                txtQty.Text = dr("Qty").ToString
                If dr("advType").ToString = "CHG" Then
                    txtChargeamount.Text = dr("amount").ToString
                Else
                    txtadvamount.Text = dr("amount").ToString
                End If
            End If
        End If
    End Sub
    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        txtactive.Text = "0"
    End Sub

    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        If _IsNewD = True Then
            SaveRvDetail()
        Else
            SaveRvDetail()
        End If
    End Sub
    Private Sub SaveRvDetail()
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_UpdateRVIntoInvoice_Header ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtDocNo.Text & "'") 'DocCreateNo
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToRV()
                _IsNewD = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    'Try
    '    Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
    '    nection = ConnectDB()
    '    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_CreateRVDetail ")
    '    SQLcommand.append("'" & CInt(txtIdent.Text) & "'") 'Ident
    '    SQLcommand.append(",'" & txtadvType.Text & "'") 'advType
    '    SQLcommand.append(",'" & txtDocNo.Text & "'") 'RVNo
    '    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
    '    If result = 1 Then
    '        MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        _IsNew = False
    '        txtactive.Text = "1"
    '    Else
    '        MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    End If
    '    nection.Close()
    'Catch ex as Exception
    '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    'End Try
    Private Sub LoadDataToRV()
        Try
            dgvRV.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Invoice_Header where RVNo='" & txtDocNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvRV.Rows.add(dt.Rows(i)("Ident").ToString(), 'Ident
                    dt.Rows(i)("InvoiceNo").ToString(), 'InvoiceNo
                    dt.Rows(i)("InvoiceDate").ToString(), 'InvoiceDate
                    dt.Rows(i)("TaxInvNo").ToString(), 'TaxInvNo
                    dt.Rows(i)("TaxInvDate").ToString(), 'TaxInvDate
                    dt.Rows(i)("Customer").ToString(), 'Customer
                    dt.Rows(i)("CustomerCode").ToString(), 'CustomerCode
                    dt.Rows(i)("Customeraddress").ToString(), 'Customeraddress
                    dt.Rows(i)("BTTLocation").ToString(), 'BTTLocation
                    dt.Rows(i)("PickupLocation").ToString(), 'PickupLocation
                    dt.Rows(i)("LoadingLocation").ToString(), 'LoadingLocation
                    dt.Rows(i)("ReturnLocation").ToString(), 'ReturnLocation
                    dt.Rows(i)("JobNo").ToString(), 'JobNo
                    dt.Rows(i)("VesselBooking").ToString(), 'VesselBooking
                    dt.Rows(i)("BLNo").ToString(), 'BLNo
                    CDbl(dt.Rows(i)("TransportCharge").ToString()), 'TransportCharge
                    CDbl(dt.Rows(i)("Reinbursement").ToString()), 'Reinbursement
                    CDbl(dt.Rows(i)("Totalamount").ToString()), 'Totalamount
                    dt.Rows(i)("CurrentUser").ToString(), 'CurrentUser
                    dt.Rows(i)("active").ToString(), 'active
                    CDbl(dt.Rows(i)("InvSum").ToString()), 'InvSum
                    CDbl(dt.Rows(i)("ReinburseCharge").ToString()), 'ReinburseCharge
                    dt.Rows(i)("ChangeTax").ToString(), 'ChangeTax
                    dt.Rows(i)("ChangeVat").ToString(), 'ChangeVat
                    dt.Rows(i)("SoaNo").ToString(), 'SoaNo
                    dt.Rows(i)("SELECTSOa").ToString(), 'SELECTSOa
                    CDbl(dt.Rows(i)("advanceRecieve").ToString()), 'advanceRecieve
                    CDbl(dt.Rows(i)("TransportDiscount").ToString()), 'TransportDiscount
                    dt.Rows(i)("RVNo").ToString()  'RVNo
        )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
                addData()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

        Dim amt as Double = 0
        If dgvRV.Rows.Count > 0 Then
            For i as Integer = 0 To dgvRV.Rows.Count - 1
                If dgvRV.Rows(i).Cells(19).Value = "1" Then
                    amt += dgvRV.Rows(i).Cells(17).Value
                End If
            Next
            txtNetPayment.Text = amt.ToString("#,##0.00")
        Else
            txtNetPayment.Text = amt.ToString("#,##0.00")
        End If
        'Try
        '    'dgvPlanning.Rows.Clear()
        '    dgvRV.DataSource = Nothing
        '    Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
        '    Dim dt as DataTable = New DataTable()
        '    Dim nection as New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim str as String = "SELECT * FROM Invoice_Header where 1=1 and RVNo='" & txtDocNo.Text & "'"
        '    'str &= " ORDER BY PickDate DESC "
        '    da.SelectCommand = New OleDbCommand(str, nection)
        '    da.Fill(dt)
        '    If dt.Rows.Count > 0 Then
        '        dgvRV.DataSource = dt

        '        da = Nothing
        '        dt = Nothing
        '        nection.Close()
        '    End If
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
        'Try
        '    dgvRV.Rows.Clear()
        '    Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
        '    Dim dt as DataTable = New DataTable()
        '    Dim nection as New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim str as String = "SELECT * FROM Invoice_Header where 1=1 and RVNo='" & txtDocNo.Text & "'"
        '    da.SelectCommand = New OleDbCommand(str, nection)
        '    da.Fill(dt)
        '    If dt.Rows.Count > 0 Then
        '        'For i as Integer = 0 To dt.Rows.Count - 1
        '        '    dgvRV.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
        '        '           dt.Rows(i)(1).ToString(), 'InvoiceNo
        '        '           dt.Rows(i)(2).ToString(), 'JobNo
        '        '           dt.Rows(i)(3).ToString(), 'OrderNo
        '        '           dt.Rows(i)(4).ToString(), 'BookingNo
        '        '           dt.Rows(i)(5).ToString(), 'SICode
        '        '           dt.Rows(i)(6).ToString(), 'SICodeDescription
        '        '           dt.Rows(i)(7).ToString(), 'RVRemark
        '        '           dt.Rows(i)(8).ToString(), 'Qty
        '        '           dt.Rows(i)(9).ToString(), 'Unit
        '        '           CDbl(dt.Rows(i)(10).ToString()), 'Unitamount
        '        '           CDbl(dt.Rows(i)(11).ToString()), 'VaT
        '        '           CDbl(dt.Rows(i)(12).ToString()), 'WHT
        '        '           CDbl(dt.Rows(i)(13).ToString()), 'advamount
        '        '           CDbl(dt.Rows(i)(14).ToString()), 'Chargeamount
        '        '           dt.Rows(i)(15).ToString(), 'DateFrom
        '        '           dt.Rows(i)(16).ToString(), 'DateTo
        '        '           dt.Rows(i)(17).ToString(), 'RVStatus
        '        '           dt.Rows(i)(18).ToString()  'DocNo
        '        '            )
        '        'Next
        '        da = Nothing
        '        dt = Nothing
        '        nection.Close()
        '    End If
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
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
            txtSICodeDescription.Text = dr("ItemName").ToString
        End If
    End Sub

    Private Sub txtCustomerName_ButtonClick(sender as Object, e as Eventargs) Handles txtCustomerName.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [CustTaxID]
      ,[CustCompanyID]
      ,[CustBranch]
      ,[CustCompanyName]
      ,[CustCountry]
      ,[CustCity]
      ,[Custaddress]
      ,[CustEmail]
      ,[CustPhone]
      ,[CustFax]
      ,[CustPayable]
      ,[CustFactory]
      ,[CustCustomer]  FROM [Mas_CustomerTransport] WHERE 1=1 order by [CustCompanyName] ", MainConnection)
        If isSearchOK Then
            txtCustomerName.Text = dr("CustCompanyName").ToString
        End If
    End Sub

    Private Sub txtReceivedFrom_ButtonClick(sender as Object, e as Eventargs) Handles txtReceivedFrom.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [CustTaxID]
      ,[CustCompanyID]
      ,[CustBranch]
      ,[CustCompanyName]
      ,[CustCountry]
      ,[CustCity]
      ,[Custaddress]
      ,[CustEmail]
      ,[CustPhone]
      ,[CustFax]
      ,[CustPayable]
      ,[CustFactory]
      ,[CustCustomer]  FROM [Mas_CustomerTransport] WHERE 1=1 order by [CustCompanyName] ", MainConnection)
        If isSearchOK Then
            txtReceivedFrom.Text = dr("CustCompanyName").ToString
        End If
    End Sub

    Private Sub txtDocNo_Click(sender as Object, e as Eventargs) Handles txtDocNo.Click
        If txtRVNo.Text = "" Then
            If txtRVType.Text = "สมุดบัญชีรับ-เงินสด(JOB)" Or txtRVType.Text = "สมุดบัญชีรับ-ลูกหนี้(JOB)" Then
                RunREC()
            Else
                RunGEP()
            End If
        End If
    End Sub

    Private Sub txtSearchInvoiceNo_BindingContextChanged(sender as Object, e as Eventargs) Handles txtSearchInvoiceNo.BindingContextChanged

    End Sub

    Private Sub dgvRV_CellContentClick(sender as Object, e as DataGridViewCellEventargs) Handles dgvRV.CellContentClick

    End Sub

    Private Sub txtTotalamountReceived_TextChanged(sender as Object, e as Eventargs) Handles txtTotalamountReceived.TextChanged
        If txtNetPayment.Text = "" Then
            txtNetPayment.Text = "0"
        End If
        If txtTotalamountReceived.Text <> "" Then
            txtPaymentDiff.Text = CDbl(txtNetPayment.Text - txtTotalamountReceived.Text).ToString("#,##0.00")
        Else
            txtTotalamountReceived.Text = "0"
        End If
    End Sub

    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [Ident]
      ,[RVType]
      ,[DocNo]
      ,[DocCreateDate]
      ,[DocCreateTime]
      ,[Bookaccount]
      ,[ReferenceNo]
      ,[RVReceivedMoneyDate]
      ,[RVNo]
      ,[ChqDate]
      ,[TotalamountReceived]
      ,[BankNoDate] as ChqNo
      ,[ReceivedFrom]
      ,[CustomerName]
      ,[CurrentUser]
      ,[active]
      ,[TaxInvDocNo]
      ,[PaymentDiff]
      ,[Netadvance]
      ,[NetCharge]
      ,[NetWHT]
      ,[NetPayment]  FROM [RV_Header] WHERE 1=1 order by [DocNo] ", MainConnection)
        If isSearchOK Then
            txtIdent.Text = dr("Ident").ToString
            txtRVType.Text = dr("RVType").ToString
            txtDocNo.Text = dr("DocNo").ToString
            txtDocCreateDate.Value = CDate(dr("DocCreateDate")).ToString
            txtDocCreateTime.Text = dr("DocCreateTime").ToString
            txtBookaccount.Text = dr("Bookaccount").ToString
            txtReferenceNo.Text = dr("ReferenceNo").ToString
            txtRVReceivedMoneyDate.Value = CDate(dr("RVReceivedMoneyDate")).ToString
            txtRVNo.Text = dr("RVNo").ToString
            dtpChqDate.Value = CDate(dr("ChqDate")).ToString
            txtTotalamountReceived.Text = dr("TotalamountReceived").ToString
            txtBankNoDate.Text = dr("ChqNo").ToString
            txtReceivedFrom.Text = dr("ReceivedFrom").ToString
            txtCustomerName.Text = dr("CustomerName").ToString
            txtCurrentUser.Text = dr("CurrentUser").ToString
            txtactive.Text = dr("active").ToString
            txtPaymentDiff.Text = dr("PaymentDiff").ToString
            txtTotaladvance.Text = dr("Netadvance").ToString
            txtTotalCharge.Text = dr("NetCharge").ToString
            txtTotalWHT.Text = dr("NetWHT").ToString
            txtNetPayment.Text = dr("NetPayment").ToString
            LoadDataToRV()
            _IsNew = False
        End If
    End Sub

    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click
        Dim url as String = "http://203.170.129.23/transport/report/RV?DocCreateNo=" & txtDocNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex as Exception
            Process.Start(url)
        End Try
    End Sub
End Class