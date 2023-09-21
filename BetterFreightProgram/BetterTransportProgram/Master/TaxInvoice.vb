Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Public Class TaxInvoice
    Public _IsNew As Boolean
    Public _IsNewD As Boolean
    Private Sub TaxInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtSysUser.Text = "" Then
            txtSysUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName
        End If
        addNewHeader()
        addNewDetail()
    End Sub
    Private Sub LoadDataToDetail()
        Try
            dgvTaxInv.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Invoice_Header where 1=1 and TaxInvDocNo='" & txtDocCreateNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvTaxInv.Rows.Add(dt.Rows(i)("Ident").ToString(), 'Ident
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
                           dt.Rows(i)("RVNo").ToString(), 'RVNo
                           dt.Rows(i)("TaxInvDocNo").ToString()  'TaxInvDocNo
                            )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
            addData()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub addNewHeader()
        txtIdentH.Text = "0" 'Ident
        cboTaxType.ResetText() 'TaxType
        txtDocCreateNo.ResetText() 'DocCreateNo
        txtDocTime.ResetText() 'DocTime
        txtBookaccount.ResetText() 'Bookaccount
        txtReferenceNo.ResetText() 'ReferenceNo
        txtTaxInvNo.ResetText() 'TaxInvNo
        txtChqNo.ResetText() 'TransferNo
        txtInvoice.ResetText() 'Invoice
        txtBankNo.ResetText() 'BankNo
        txtPayFor.ResetText() 'PayFor
        txtVendorName.ResetText() 'VendorName
        txtDateFrom.ResetText() 'DateFrom
        txtDateTo.ResetText() 'DateTo
        txtTaxStatus.ResetText() 'TaxStatus
        txtSysUser.ResetText() 'SysUser
        _IsNew = True
    End Sub
    Private Sub addNewDetail()
        txtIdentD.Text = "0" 'Ident
        txtJobNo.ResetText() 'JobNo
        txtOrderNo.ResetText() 'OrderNo
        txtBookingNo.ResetText() 'BookingNo
        txtadvType.ResetText() 'advType
        'txtSICode.ResetText() 'SICode
        'txtSICodeDescription.ResetText() 'SICodeDescription
        'txtTaxInvRemark.ResetText() 'TaxInvRemark
        'txtQty.ResetText() 'Qty
        'txtUnit.ResetText() 'Unit
        'txtUnitamount.ResetText() 'Unitamount
        'txtVaT.ResetText() 'VaT
        'txtWHT.ResetText() 'WHT
        'txtadvamount.ResetText() 'advamount
        'txtChargeamount.ResetText() 'Chargeamount
        txtDateFrom.ResetText() 'DateFrom
        txtDateTo.ResetText() 'DateTo
        txtTaxStatus.ResetText() 'RVStatus
        txtTaxInvNo.ResetText() 'TaxInvNo
        txtSearchInvoiceNo.ResetText() 'InvoiceNo
        _IsNewD = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetRunningFormat("TaXINV")
        txtTaxInvNo.Text = CreateNumber("addTransport", "JobNo", dtpTaXDate.Value)
    End Sub
    Private Sub SaveTaxHeader(_insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateTaxInvoiceHeader ")
            SQLcommand.Append("'" & txtIdentH.Text & "'") 'Ident
            SQLcommand.Append(",'" & cboTaxType.Text & "'") 'TaxType 
            SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'DocCreateNo
            SQLcommand.Append(",'" & LetDate(dtpDocNoDate.Value) & "'") 'DocNoDate
            SQLcommand.Append(",'" & txtDocTime.Text & "'") 'DocTime 
            SQLcommand.Append(",'" & txtBookaccount.Text & "'") 'Bookaccount
            SQLcommand.Append(",'" & txtReferenceNo.Text & "'") 'ReferenceNo
            SQLcommand.Append(",'" & LetDate(dtpTaXDate.Value) & "'") 'TaxDate 
            SQLcommand.Append(",'" & txtTaxInvNo.Text & "'") 'TaxInvNo
            SQLcommand.Append(",'" & txtChqNo.Text & "'") 'TransferNo
            SQLcommand.Append(",'" & txtInvoice.Text & "'") 'Invoice 
            SQLcommand.Append(",'" & txtBankNo.Text & "'") 'BankNo
            SQLcommand.Append(",'" & txtPayFor.Text & "'") 'PayFor
            SQLcommand.Append(",'" & txtVendorName.Text & "'") 'VendorName
            SQLcommand.Append(",'" & LetDate(txtDateFrom.Value) & "'") 'DateFrom 
            SQLcommand.Append(",'" & LetDate(txtDateTo.Value) & "'") 'DateTo
            SQLcommand.Append(",'" & txtTaxStatus.Text & "'") 'TaxStatus
            SQLcommand.Append(",'" & txtSysUser.Text & "'") 'SysUser
            SQLcommand.Append(",'" & CDbl(txtTotaladvance.Text) & "'")
            SQLcommand.Append(",'" & CDbl(txtTotalCharge.Text) & "'")
            SQLcommand.Append(",'" & CDbl(txtTotalWHT.Text) & "'")
            SQLcommand.Append(",'" & CDbl(txtTotalTotalamount.Text) & "'")
            SQLcommand.Append(",'" & _insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveRVHeader()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtDocCreateNo.Text = "" Then
            GetRunningFormat("REB")
            txtDocCreateNo.Text = CreateNumber("TaxInvoiceHeader", "DocCreateNo", dtpDocNoDate.Value)
        End If
        If txtDocCreateNo.Text = "ERROR" Then
            MsgBox("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้ กรุณารีสตาร์ทโปรแกรม")
            Exit Sub
        End If
        If _IsNew = True Then
            SaveTaxHeader(1)
        Else
            SaveTaxHeader(0)
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MsgBox(_IsNewD)
        If _IsNewD = True Then
            SaveTaxInvDetail(1)
        Else
            SaveTaxInvDetail(0)
        End If
    End Sub
    Private Sub SaveTaxInvDetail(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            For row As Integer = 0 To dgvTaxInv.Rows.Count - 1

                Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_UpdateTaxInvIntoInvoice_Header ")
                SQLcommand.Append("'" & CInt(dgvTaxInv.Rows(row).Cells(0).Value) & "'") 'Ident 
                SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'DocCreateNo
                Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                If result = 1 Then
                    MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _IsNewD = False
                Else
                    MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Next
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        ''Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
        ''nection = ConnectDB() 
        ''Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateTaxInv_Detail ")
        ''SQLcommand.append("'" & txtIdentD.Text & "'") 'Ident
        ''SQLcommand.append(",'" & txtJobNo.Text & "'") 'JobNo 
        ''SQLcommand.append(",'" & txtOrderNo.Text & "'") 'OrderNo
        ''SQLcommand.append(",'" & txtBookingNo.Text & "'") 'BookingNo
        ''SQLcommand.append(",'" & txtadvType.Text & "'") 'advType 
        ''SQLcommand.append(",'" & txtSICode.Text & "'") 'SICode 
        ''SQLcommand.append(",'" & txtSICodeDescription.Text & "'") 'SICodeDescription
        ''SQLcommand.append(",'" & txtTaxInvRemark.Text & "'") 'TaxInvRemark 
        ''SQLcommand.append(",'" & CDbl(txtQty.Text) & "'") 'Qty
        ''SQLcommand.append(",'" & txtUnit.Text & "'") 'Unit 
        ''SQLcommand.append(",'" & CDbl(txtUnitamount.Text) & "'") 'Unitamount
        ''SQLcommand.append(",'" & CDbl(txtVaT.Text) & "'") 'VaT 
        ''SQLcommand.append(",'" & CDbl(txtWHT.Text) & "'") 'WHT
        ''SQLcommand.append(",'" & CDbl(txtadvamount.Text) & "'") 'advamount
        ''SQLcommand.append(",'" & CDbl(txtChargeamount.Text) & "'") 'Chargeamount 
        ''SQLcommand.append(",'" & LetDate(txtDateFrom.Text) & "'") 'DateFrom
        ''SQLcommand.append(",'" & LetDate(txtDateTo.Text) & "'") 'DateTo
        ''SQLcommand.append(",'" & txtTaxStatus.Text & "'") 'RVStatus 
        ''SQLcommand.append(",'" & txtTaxInvNo.Text & "'") 'TaxInvNo
        ''SQLcommand.append(",'" & txtSearchInvoiceNo.Text & "'") 'InvoiceNo 
        ''SQLcommand.append(",'" & txtDocCreateNo.Text & "'") 'DocCreateNo
        ''SQLcommand.append(",'" & txtTotalamount.Text & "'") 
        ''SQLcommand.append(",'" & _Insert & "'") '//Insert Or Update
        ''Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection) 
        ''If result = 1 Then
        ''    MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''    _IsNewD = False 
        ''Else
        ''    MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        ''End If 
        ''nection.Close()
    End Sub

    Private Sub txtSearchInv_ButtonClick(sender As Object, e As EventArgs) Handles txtSearchInv.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT [DocNo]
         FROM [RV_Header] where 1=1", MainConnection)
        If isSearchOK Then
            txtSearchInv.Text = dr("DocNo").ToString
            LoadInvTodgv()
        End If
    End Sub
    Private Sub LoadInvTodgv()
        Try
            dgvTaxInv.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Invoice_Header where RVNo='" & txtSearchInv.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvTaxInv.Rows.Add(dt.Rows(i)("Ident").ToString(), 'Ident
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
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

        'Dim amt as Double = 0
        'If dgvRV.Rows.Count > 0 Then
        '    For i as Integer = 0 To dgvRV.Rows.Count - 1
        '        If dgvRV.Rows(i).Cells(19).Value = "1" Then
        '            amt += dgvRV.Rows(i).Cells(20).Value + dgvRV.Rows(i).Cells(21).Value
        '        End If
        '    Next
        '    txtNetPayment.Text = amt.ToString("#,##0.00")
        'Else
        '    txtNetPayment.Text = amt.ToString("#,##0.00")
        'End If
    End Sub
    Private Sub addData()
        Dim Totaladvance As Double = 0
        Dim TotalCharge As Double = 0
        Dim TotalWHT As Double = 0
        Dim TotalTotalamount As Double = 0
        'Dim amt as Double = 0
        If dgvTaxInv.Rows.Count > 0 Then
            For i As Integer = 0 To dgvTaxInv.Rows.Count - 1
                'amt += dgvTaxInv.Rows(i).Cells(9).Value
                Totaladvance += CDbl(dgvTaxInv.Rows(i).Cells(21).Value) ' + dgvTaxInv.Rows(i).Cells(10).Value 
                TotalCharge += CDbl(dgvTaxInv.Rows(i).Cells(20).Value)
                TotalWHT += CDbl(dgvTaxInv.Rows(i).Cells(15).Value)
                TotalTotalamount += CDbl(dgvTaxInv.Rows(i).Cells(17).Value)
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
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dr As DataRow
        dr = PopUpSearch("SELECT [Ident]
        ,[TaxType]
        ,[DocCreateNo] 
        ,[DocNoDate]
        ,[DocTime]
        ,[Bookaccount] 
        ,[ReferenceNo]
        ,[TaxDate] 
        ,[TaxInvNo]
        ,[TransferNo]
        ,[Invoice] 
        ,[BankNo]
        ,[PayFor]
        ,[VendorName]
        ,[DateFrom] 
        ,[DateTo]
        ,[TaxStatus] 
        ,[SysUser]
        FROM [TaxInvoiceHeader] where 1=1", MainConnection)
        If isSearchOK Then
            txtIdentH.Text = dr("ident").ToString
            cboTaxType.Text = dr("TaxType").ToString
            txtDocCreateNo.Text = dr("DocCreateNo").ToString
            dtpDocNoDate.Text = LetDate(dr("DocNoDate")).ToString
            txtDocTime.Text = dr("DocTime").ToString
            txtBookaccount.Text = dr("Bookaccount").ToString
            txtReferenceNo.Text = dr("ReferenceNo").ToString
            dtpTaXDate.Text = LetDate(dr("TaxDate")).ToString
            txtTaxInvNo.Text = dr("TaxInvNo").ToString
            txtChqNo.Text = dr("TransferNo").ToString
            txtInvoice.Text = dr("Invoice").ToString
            txtBankNo.Text = dr("BankNo").ToString
            txtPayFor.Text = dr("PayFor").ToString
            txtVendorName.Text = dr("VendorName").ToString
            txtDateFrom.Text = LetDate(dr("DateFrom")).ToString
            txtDateTo.Text = LetDate(dr("DateTo")).ToString
            txtTaxStatus.Text = dr("TaxStatus").ToString
            txtSysUser.Text = dr("SysUser").ToString
            _IsNew = False
            LoadDataToDetail()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim url As String = "http://203.170.129.23/transport/report/TaxInv?DocCreateNo=" & txtDocCreateNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub dgvTaxInv_Rowsadded(sender As Object, e As DataGridViewRowsAddedEventArgs)
        Dim Totaladvance As Double = 0
        Dim TotalCharge As Double = 0
        Dim TotalWHT As Double = 0
        Dim TotalTotalamount As Double = 0
        'Dim amt as Double = 0
        If dgvTaxInv.Rows.Count > 0 Then
            For i As Integer = 0 To dgvTaxInv.Rows.Count - 1
                'amt += dgvTaxInv.Rows(i).Cells(9).Value
                Totaladvance += CDbl(dgvTaxInv.Rows(i).Cells(21).Value) ' + dgvTaxInv.Rows(i).Cells(10).Value 
                TotalCharge += CDbl(dgvTaxInv.Rows(i).Cells(20).Value)
                TotalWHT += CDbl(dgvTaxInv.Rows(i).Cells(15).Value)
                TotalTotalamount += CDbl(dgvTaxInv.Rows(i).Cells(17).Value)
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

    Private Sub txtVendorName_ButtonClick(sender As Object, e As EventArgs) Handles txtVendorName.ButtonClick
        Dim dr As DataRow
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
            txtVendorName.Text = dr("CustCompanyName").ToString
        End If
    End Sub

    Private Sub txtBookaccount_ButtonClick(sender As Object, e As EventArgs) Handles txtBookaccount.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT [BookingNo],[accountName],[accountType]  FROM [Bookaccount] WHERE 1=1  order by [BookingNo] ", MainConnection)
        If isSearchOK Then
            txtBookaccount.Text = dr("BookingNo").ToString
        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub txtPayFor_ButtonClick(sender As Object, e As EventArgs) Handles txtPayFor.ButtonClick
        Dim dr As DataRow
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
            txtPayFor.Text = dr("CustCompanyName").ToString
        End If
    End Sub
End Class