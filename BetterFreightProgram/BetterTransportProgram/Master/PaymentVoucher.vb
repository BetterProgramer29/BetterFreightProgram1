Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Reflection.Emit
Imports System.Text

Public Class PaymentVoucher
    Public _IsNew As Boolean
    Public _IsNewD As Boolean
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtDocCreateNo.Text = "" Then
            If cboPVType.Text = "สมุดบัญชีจ่าย-เงินสด(PAY)" Or cboPVType.Text = "สมุดบัญชีจ่าย-ตั้งหนี้(PAY)" Then
                GetRunningFormat("PAY")
                txtDocCreateNo.Text = CreateNumber("Freight_PaymentVoucher", "DocCreateNo", dtpDocNoDate.Value)
            Else
                GetRunningFormat("PAY")
                txtDocCreateNo.Text = CreateNumber("Freight_PaymentVoucher", "DocCreateNo", dtpDocNoDate.Value)
            End If

        End If
        If _IsNew = True Then
            '   MsgBox(_IsNew)
            SavePaymentVoucher(1)
        Else
            ' MsgBox(_IsNew)
            SavePaymentVoucher(0)
        End If
    End Sub

    Private Sub SavePaymentVoucher(_Insert As Integer)
        Try

            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_PaymentVoucher ")
            SQLcommand.Append("'" & CInt(txtIdent.Text) & "'") 'Ident
            SQLcommand.Append(",'" & cboPVType.Text & "'") 'PVType
            SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'DocCreateNo
            SQLcommand.Append(",'" & CDate(dtpDocNoDate.Value) & "'") 'DocNoDate
            SQLcommand.Append(",'" & txtBookaccount.Text & "'") 'BookAccount
            SQLcommand.Append(",'" & CDate(dtpPVDate.Value) & "'") 'PVDate
            SQLcommand.Append(",'" & txtPayFor.Text & "'") 'PayFor
            SQLcommand.Append(",'" & txtVendorName.Text & "'") 'VendorName
            SQLcommand.Append(",'" & txtInvoice.Text & "'") 'Invoice
            SQLcommand.Append(",'" & CDate(dtpInvoiceDate.Value) & "'") 'InvoiceDate
            SQLcommand.Append(",'" & txtVendorBankNo.Text & "'") 'VendorBankNo
            SQLcommand.Append(",'" & txtTransferNo.Text & "'") 'TransferNo
            SQLcommand.Append(",'" & txtBankName.Text & "'") 'BankName
            SQLcommand.Append(",'" & txtPVNo.Text & "'") 'PVNo
            SQLcommand.Append(",'" & CDate(dtpPayDate.Value) & "'") 'PayDate
            SQLcommand.Append(",'" & txtWHTNo.Text & "'") 'WHTNo
            SQLcommand.Append(",'" & txtWHTUser.Text & "'") 'WHTUser
            SQLcommand.Append(",'" & CDbl(txtNetPayment.Text) & "'") 'NetPayment
            SQLcommand.Append(",'" & txtSysUser.Text & "'") 'SysUser
            SQLcommand.Append(",'" & txtReceiptNo.Text & "'")
            SQLcommand.Append(",'" & CDate(dtpReceiptDate.Value) & "'")
            SQLcommand.Append(",'" & txtActiveHeader.Text & "'")
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToPV()
                _IsNew = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SavePaymentVoucherDetail(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_PaymentVoucherDetail ")
            SQLcommand.Append("'" & txtIdentD.Text & "'") 'Ident
            SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'DocCreateNo
            SQLcommand.Append(",'" & txtVendorName.Text & "'")
            SQLcommand.Append(",'" & txtadvNo.Text & "'") 'advNo
            SQLcommand.Append(",'" & txtBFTNo.Text & "'") 'BFTNo
            SQLcommand.Append(",'" & txtBookingNo.Text & "'") 'BookingNo
            SQLcommand.Append(",'" & txtMasterBLNo.Text & "'") 'MasterBLNo
            SQLcommand.Append(",'" & txtHouseBLNo.Text & "'") 'HouseBLNo
            SQLcommand.Append(",'" & txtSICode.Text & "'") 'SICode
            SQLcommand.Append(",'" & txtPVDescription.Text & "'") 'PVDescription
            SQLcommand.Append(",'" & txtPVRemark.Text & "'") 'PVRemark
            SQLcommand.Append(",'" & txtReceiptNo.Text & "'") 'ReceiptNo
            SQLcommand.Append(",'" & CDbl(txtQty.Text) & "'") 'Qty
            SQLcommand.Append(",'" & txtPVDetailType.Text & "'") 'PVDetailType
            SQLcommand.Append(",'" & txtCurrency.Text & "'") 'Currency
            SQLcommand.Append(",'" & CDbl(txtExchangeRate.Text) & "'") 'ExchangeRate
            SQLcommand.Append(",'" & txtPVUnitamount.Text & "'") 'PVUnitamount
            SQLcommand.Append(",'" & txtChargeamount.Text & "'") 'Chargeamount
            SQLcommand.Append(",'" & cboChangeVaT.Text & "'") 'ChangeVaT
            SQLcommand.Append(",'" & cboChangeWHT.Text & "'") 'ChangeWHT
            SQLcommand.Append(",'" & CDbl(txtTotalamount.Text) & "'") 'Totalamount
            SQLcommand.Append(",'" & CDbl(txtadvamount.Text) & "'") 'advamount
            SQLcommand.Append(",'" & CDbl(txtNetTotalamount.Text) & "'") 'NetTotalamount
            SQLcommand.Append(",'" & CDbl(txtNetPayment.Text) & "'") 'NetPayment
            SQLcommand.Append(",'" & txtROWNo.Text & "'")
            SQLcommand.Append(",'" & txtInvoice.Text & "'")
            SQLcommand.Append(",'" & txtVATAmount.Text & "'")
            SQLcommand.Append(",'" & txtWHTAmount.Text & "'")
            SQLcommand.Append(",'" & txtActiveDetail.Text & "'")
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToPV()
                AddNewDetail()
                UpdatePVNoToAdv()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub UpdatePVNoToAdv()
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_UpdatePVToAdvReq ")
            SQLcommand.Append("'" & txtIdentAdv.Text & "'") 'Ident
            SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'DocCreateNo
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                'MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Update Data To PV Fail ", "Update Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'MsgBox(_IsNewD)
        If _IsNewD = True Then
            SavePaymentVoucherDetail(1)
        Else
            SavePaymentVoucherDetail(0)
        End If
    End Sub
    Private Sub txtadvNo_ButtonClick(sender As Object, e As EventArgs) Handles txtadvNo.ButtonClick
        AddNewDetail()
        Dim dr As DataRow
        dr = PopUpSearch("SELECT [ROWNo]
        ,[AdvType]
        ,[SICode]
        ,[SICodeDescription]
        ,[AdvRemark]
        ,[QTY]
        ,[Tys]
        ,[Currency]
        ,[ExchangeRate]
        ,[UnitPrice]
        ,[Total]
        ,[VAT]
        ,[WHT]
        ,[TotalAmtPlusVAT]
        ,[TotalAmtMinusWHT]
        ,[NetPayment]
        ,[QuotationNo]
        ,[Active]
        ,[BCFNo]
        ,[DocNo]
        ,[Ident]
        ,[HBLNo]
        ,[MBLNo]
         FROM [Freight_AdvRequestDetail] where 1=1 and ISNULL(PVNo,'')='' and ISNULL(ApproveBy,'')<>'' and Active = '1'", MainConnection)
        If isSearchOK Then
            txtSICode.Text = dr("SICode").ToString
            txtPVDescription.Text = dr("SICodeDescription").ToString
            txtROWNo.Text = dr("ROWNo").ToString
            txtadvNo.Text = dr("DocNo").ToString
            txtBFTNo.Text = dr("BCFNo").ToString
            txtHouseBLNo.Text = dr("HBLNo").ToString
            txtMasterBLNo.Text = dr("MBLNo").ToString
            txtIdentAdv.Text = dr("Ident").ToString
            txtPVUnitamount.Text = dr("UnitPrice").ToString()
            txtQty.Text = dr("QTY").ToString
            _IsNewD = True
            'LoadDataToPV()
        End If
    End Sub

    Private Sub PaymentVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _IsNew = True
        _IsNewD = True
        txtSysUser.Text = UserProfile.U_FName + " " + UserProfile.U_LName
        'SubstractDate()
        AddNewData()
        AddNewDetail()
    End Sub
    Private Sub SubstractDate()
        dtpDocNoDate.Value = dtpDocNoDate.Value.AddDays(-365)
        dtpInvoiceDate.Value = dtpInvoiceDate.Value.AddDays(-365)
        dtpReceiptDate.Value = dtpReceiptDate.Value.AddDays(-365)
        dtpPVDate.Value = dtpPVDate.Value.AddDays(-365)
        dtpPayDate.Value = dtpPayDate.Value.AddDays(-365)
    End Sub
    Private Sub LoadDataToPV()
        Try
            dgvPV.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_PaymentVoucherDetail where DocCreateNo='" & txtDocCreateNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvPV.Rows.Add(dt.Rows(i)("Ident").ToString(), 'Ident
                    dt.Rows(i)("DocCreateNo").ToString(), 'DocCreateNo
                    dt.Rows(i)("VendorName").ToString(), 'VendorName
                    dt.Rows(i)("AdvNo").ToString(), 'AdvNo
                    dt.Rows(i)("BFTNo").ToString(), 'BFTNo
                    dt.Rows(i)("BookingNo").ToString(), 'BookingNo
                    dt.Rows(i)("MasterBLNo").ToString(), 'MasterBLNo
                    dt.Rows(i)("HouseBLNo").ToString(), 'HouseBLNo
                    dt.Rows(i)("SICode").ToString(), 'SICode
                    dt.Rows(i)("PVDescription").ToString(), 'PVDescription
                    dt.Rows(i)("PVRemark").ToString(), 'PVRemark
                    dt.Rows(i)("ReceiptNo").ToString(), 'ReceiptNo
                    dt.Rows(i)("Qty").ToString(), 'Qty
                    dt.Rows(i)("PVDetailType").ToString(), 'PVDetailType
                    dt.Rows(i)("Currency").ToString(), 'Currency
                    CDbl(dt.Rows(i)("ExchangeRate").ToString()), 'ExchangeRate
                    dt.Rows(i)("PVUnitAmount").ToString(), 'PVUnitAmount
                    dt.Rows(i)("ChargeAmount").ToString(), 'ChargeAmount
                    dt.Rows(i)("ChangeVAT").ToString(), 'ChangeVAT
                    dt.Rows(i)("ChangeWHT").ToString(), 'ChangeWHT
                    CDbl(dt.Rows(i)("TotalAmount").ToString()), 'TotalAmount
                    CDbl(dt.Rows(i)("AdvAmount").ToString()), 'AdvAmount
                    CDbl(dt.Rows(i)("NetTotalAmount").ToString()), 'NetTotalAmount
                    CDbl(dt.Rows(i)("NetPayment").ToString())  'NetPayment
                    )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        'Try
        '    dgvCostDN.Rows.Clear()
        '    Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
        '    Dim dt As DataTable = New DataTable()
        '    Dim nection As New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim str As String = "SELECT * FROM Freight_AdvRequestDetail where DocNo='" & txtadvNo.Text & "' and ROWNo='" & txtROWNo.Text & "'"
        '    da.SelectCommand = New OleDbCommand(str, nection)
        '    da.Fill(dt)
        '    If dt.Rows.Count > 0 Then
        '        For i As Integer = 0 To dt.Rows.Count - 1
        '            dgvCostDN.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
        '                   dt.Rows(i)(1).ToString(), 'QuotationDetailType
        '                   dt.Rows(i)(2).ToString(), 'SICode
        '                   "",
        '                   dt.Rows(i)(3).ToString(), 'SICodeDescription
        '                   dt.Rows(i)(4).ToString(), 'Remark
        '                   dt.Rows(i)(5).ToString(), 'Qty
        '                   dt.Rows(i)(6).ToString(), 'Tys
        '                   dt.Rows(i)(7).ToString(), 'Currency
        '                   CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
        '                   dt.Rows(i)(9).ToString(), 'UnitPrice
        '                   dt.Rows(i)(10).ToString(), 'Totalamount
        '                   CDbl(dt.Rows(i)(11).ToString()), 'VaT
        '                   CDbl(dt.Rows(i)(12).ToString()), 'WHT
        '                   CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT
        '                   CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT
        '                   CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
        '                   dt.Rows(i)(16).ToString(), 'QuotationNo
        '                   dt.Rows(i)(17).ToString(), 'active
        '                   dt.Rows(i)(18).ToString(), 'DocNo
        '                   dt.Rows(i)(19).ToString(),
        '                   dt.Rows(i)(20).ToString(),
        '                   "0"
        '                    )
        '        Next
        '        da = Nothing
        '        dt = Nothing
        '        nection.Close()
        '    End If
        'Catch ex As Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter
    End Sub
    Private Sub txtPayFor_ButtonClick(sender As Object, e As EventArgs) Handles txtPayFor.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [CustTaxID]
      ,[CustCompanyID]
      ,[CustBranch]
      ,[CustCompanyName]
      ,[CustCountry]
      ,[CustCity]
      ,[CustAddress]
      ,[CustEmail]
      ,[CustPhone]
      ,[CustFax]
      ,[CustPayable]
      ,[CustFactory]
      ,[CustCustomer]
      ,[UserName]
      ,[UserCode]
      ,[CustCompanyEName]
      ,[CustEAddress]  FROM Mas_CustomerFreight WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPayFor.Text = dr("CustCompanyEName").ToString
        End If
    End Sub
    Private Sub txtVendorName_ButtonClick(sender As Object, e As EventArgs) Handles txtVendorName.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [VenTaxID]
      ,[VendorID]
      ,[VendorBranch]
      ,[VendorName]
      ,[VendorCountry]
      ,[VendorCity]
      ,[VendorAddress]
      ,[VendorEmail]
      ,[VendorPhone]
      ,[VendorFax]
      ,[VendorPayable]
      ,[Market]
      ,[General]
      ,[VendorBankName]
      ,[VendorBankNo]
      ,[VendorTName]
      ,[VendorTAddress]  FROM Mas_VendorTransport WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtVendorName.Text = dr("VendorName").ToString
            txtVendorBankNo.Text = (dr("VendorBankName") & " " & dr("VendorBankNo"))
        End If
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        AddNewData()
        dgvPV.Rows.Clear()
        ' LoadNewDataToPV()
        AddNewDetail()
    End Sub
    Private Sub LoadNewDataToPV()
        Try
            dgvPV.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_PaymentVoucherDetail where 1=0"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvPV.Rows.Add(dt.Rows(i)("Ident").ToString(), 'Ident
                    dt.Rows(i)("DocCreateNo").ToString(), 'DocCreateNo
                    dt.Rows(i)("VendorName").ToString(), 'VendorName
                    dt.Rows(i)("AdvNo").ToString(), 'AdvNo
                    dt.Rows(i)("BFTNo").ToString(), 'BFTNo
                    dt.Rows(i)("BookingNo").ToString(), 'BookingNo
                    dt.Rows(i)("MasterBLNo").ToString(), 'MasterBLNo
                    dt.Rows(i)("HouseBLNo").ToString(), 'HouseBLNo
                    dt.Rows(i)("SICode").ToString(), 'SICode
                    dt.Rows(i)("PVDescription").ToString(), 'PVDescription
                    dt.Rows(i)("PVRemark").ToString(), 'PVRemark
                    dt.Rows(i)("ReceiptNo").ToString(), 'ReceiptNo
                    dt.Rows(i)("Qty").ToString(), 'Qty
                    dt.Rows(i)("PVDetailType").ToString(), 'PVDetailType
                    dt.Rows(i)("Currency").ToString(), 'Currency
                    CDbl(dt.Rows(i)("ExchangeRate").ToString()), 'ExchangeRate
                    dt.Rows(i)("PVUnitAmount").ToString(), 'PVUnitAmount
                    dt.Rows(i)("ChargeAmount").ToString(), 'ChargeAmount
                    dt.Rows(i)("ChangeVAT").ToString(), 'ChangeVAT
                    dt.Rows(i)("ChangeWHT").ToString(), 'ChangeWHT
                    CDbl(dt.Rows(i)("TotalAmount").ToString()), 'TotalAmount
                    CDbl(dt.Rows(i)("AdvAmount").ToString()), 'AdvAmount
                    CDbl(dt.Rows(i)("NetTotalAmount").ToString()), 'NetTotalAmount
                    CDbl(dt.Rows(i)("NetPayment").ToString())  'NetPayment
                    )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        'Try
        '    dgvCostDN.Rows.Clear()
        '    Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
        '    Dim dt As DataTable = New DataTable()
        '    Dim nection As New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim str As String = "SELECT * FROM Freight_AdvRequestDetail where DocNo='" & txtadvNo.Text & "' and ROWNo='" & txtROWNo.Text & "'"
        '    da.SelectCommand = New OleDbCommand(str, nection)
        '    da.Fill(dt)
        '    If dt.Rows.Count > 0 Then
        '        For i As Integer = 0 To dt.Rows.Count - 1
        '            dgvCostDN.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
        '                   dt.Rows(i)(1).ToString(), 'QuotationDetailType
        '                   dt.Rows(i)(2).ToString(), 'SICode
        '                   "",
        '                   dt.Rows(i)(3).ToString(), 'SICodeDescription
        '                   dt.Rows(i)(4).ToString(), 'Remark
        '                   dt.Rows(i)(5).ToString(), 'Qty
        '                   dt.Rows(i)(6).ToString(), 'Tys
        '                   dt.Rows(i)(7).ToString(), 'Currency
        '                   CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
        '                   dt.Rows(i)(9).ToString(), 'UnitPrice
        '                   dt.Rows(i)(10).ToString(), 'Totalamount
        '                   CDbl(dt.Rows(i)(11).ToString()), 'VaT
        '                   CDbl(dt.Rows(i)(12).ToString()), 'WHT
        '                   CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT
        '                   CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT
        '                   CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
        '                   dt.Rows(i)(16).ToString(), 'QuotationNo
        '                   dt.Rows(i)(17).ToString(), 'active
        '                   dt.Rows(i)(18).ToString(), 'DocNo
        '                   dt.Rows(i)(19).ToString(),
        '                   dt.Rows(i)(20).ToString(),
        '                   "0"
        '                    )
        '        Next
        '        da = Nothing
        '        dt = Nothing
        '        nection.Close()
        '    End If
        'Catch ex As Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub AddNewDetail()
        txtIdentD.Text = 0 'Ident
        'txtDocCreateNo.ResetText() 'DocCreateNo
        'txtVendorName.ResetText() 'VendorName
        txtadvNo.ResetText() 'AdvNo
        txtBFTNo.ResetText() 'BFTNo
        txtBookingNo.ResetText() 'BookingNo
        txtMasterBLNo.ResetText() 'MasterBLNo
        txtHouseBLNo.ResetText() 'HouseBLNo
        txtSICode.ResetText() 'SICode
        txtPVDescription.ResetText() 'PVDescription
        txtPVRemark.ResetText() 'PVRemark
        txtReceiptNo.ResetText() 'ReceiptNo
        txtQty.Text = 0 'Qty
        txtPVDetailType.ResetText() 'PVDetailType
        txtCurrency.ResetText() 'Currency
        txtExchangeRate.Text = "0" 'ExchangeRate
        txtPVUnitamount.Text = "0" 'PVUnitAmount
        txtChargeamount.Text = "0.00" 'ChargeAmount
        cboChangeVaT.ResetText() 'ChangeVAT
        cboChangeWHT.ResetText() 'ChangeWHT
        txtTotalamount.Text = "0.00" 'TotalAmount
        txtadvamount.Text = "0.00" 'AdvAmount
        txtNetTotalamount.Text = "0.00" 'NetTotalAmount
        txtIdentAdv.ResetText()
        _IsNewD = True
    End Sub
    Private Sub AddNewData()
        txtIdent.Text = 0 'Ident
        txtDocCreateNo.ResetText() 'DocCreateNo
        txtBookaccount.ResetText() 'BookAccount
        txtPayFor.ResetText() 'PayFor
        txtVendorName.ResetText() 'VendorName
        txtInvoice.ResetText() 'Invoice
        txtVendorBankNo.ResetText() 'VendorBankNo
        txtTransferNo.ResetText() 'TransferNo
        txtBankName.ResetText() 'BankName
        txtPVNo.ResetText() 'PVNo
        txtWHTNo.ResetText() 'WHTNo
        txtWHTUser.ResetText() 'WHTUser
        txtNetPayment.Text = "0.00" 'NetPayment
        _IsNew = True
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If cboPVType.Text = "สมุดบัญชีจ่าย-เงินสด(JOB)" Or cboPVType.Text = "สมุดบัญชีจ่าย-ตั้งหนี้(JOB)" Then
            Dim url As String = "http://203.170.129.23/TESTFRIEGHT/report/PaymentVoucher?DocCreateNo=" & txtDocCreateNo.Text
            Try
                Process.Start("chrome.exe", url)
            Catch ex As Exception
                Process.Start(url)
            End Try
        ElseIf cboPVType.Text = "สมุดบัญชีจ่าย-เงินสด(ทั่วไป)" Or cboPVType.Text = "สมุดบัญชีจ่าย-ตั้งหนี้(ทั่วไป)" Then
            Dim url As String = "http://203.170.129.23/TESTFRIEGHT/report/PaymentVoucherNoJob?DocCreateNo=" & txtDocCreateNo.Text
            Try
                Process.Start("chrome.exe", url)
            Catch ex As Exception
                Process.Start(url)
            End Try
        End If
    End Sub
    Private Sub dgvPV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPV.CellContentClick

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP (100) 
        [DocCreateNo]
        ,[DocNoDate]
        ,[BookAccount]
        ,[PVDate]
        ,[PayFor]
        ,[VendorName]
        ,[Invoice]
        ,[InvoiceDate]
        ,[VendorBankNo]
        ,[TransferNo]
        ,[BankName]
        ,[PVNo]
        ,[PayDate]
        ,[WHTNo]
        ,[WHTUser]
        ,[NetPayment],Ident,ReceiptNo, ReceiptDate, PVType
        FROM Freight_PaymentVoucher WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtIdent.Text = dr("Ident").ToString
            txtDocCreateNo.Text = dr("DocCreateNo").ToString
            dtpDocNoDate.Value = CDate(dr("DocNoDate")).ToString
            txtBookaccount.Text = dr("BookAccount").ToString
            dtpPVDate.Value = CDate(dr("PVDate")).ToString
            txtPayFor.Text = dr("PayFor").ToString
            txtVendorName.Text = dr("VendorName").ToString
            txtInvoice.Text = dr("Invoice").ToString
            dtpInvoiceDate.Value = CDate(dr("InvoiceDate")).ToString
            txtVendorBankNo.Text = dr("VendorBankNo").ToString
            txtTransferNo.Text = dr("TransferNo").ToString
            txtBankName.Text = dr("BankName").ToString
            txtPVNo.Text = dr("PVNo").ToString
            dtpPayDate.Value = CDate(dr("PayDate")).ToString
            txtWHTNo.Text = dr("WHTNo").ToString
            txtWHTUser.Text = dr("WHTUser").ToString
            txtNetPayment.Text = dr("NetPayment").ToString
            txtReceiptNo.Text = dr("ReceiptNo").ToString
            dtpReceiptDate.Text = CDate(dr("ReceiptDate")).ToString
            cboPVType.Text = dr("PVType").ToString
            _IsNew = False
            LoadDataToPV()
        End If
    End Sub
    Private Sub txtBookaccount_ButtonClick(sender As Object, e As EventArgs) Handles txtBookaccount.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) BookingNo,AccountName,AccountType  FROM BookAccount WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtBookaccount.Text = dr("BookingNo").ToString
        End If
    End Sub
    Private Sub txtSICode_ButtonClick(sender As Object, e As EventArgs) Handles txtSICode.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("Select TOP(100) [accountGroup], [ItemName]
        ,[accountNo]
        ,[accountControl]
        ,[SICode]
        ,[accountName]
        ,[SIGroup]  FROM [MaS_SICODE] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtSICode.Text = dr("SICode").ToString
            txtPVDescription.Text = dr("ItemName").ToString
        End If
    End Sub
    Private Sub dgvPV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvPV.CellMouseClick
        Try
            _IsNewD = False
            If e.RowIndex < 0 Or e.RowIndex > dgvPV.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdentD.Text = CInt(dgvPV.CurrentRow.Cells(0).Value.ToString()) 'Ident
                txtDocCreateNo.Text = dgvPV.CurrentRow.Cells(1).Value.ToString() 'DocCreateNo
                txtVendorName.Text = dgvPV.CurrentRow.Cells(2).Value.ToString() 'VendorName
                txtadvNo.Text = dgvPV.CurrentRow.Cells(3).Value.ToString() 'AdvNo
                txtBFTNo.Text = dgvPV.CurrentRow.Cells(4).Value.ToString() 'BFTNo
                txtBookingNo.Text = dgvPV.CurrentRow.Cells(5).Value.ToString() 'BookingNo
                txtMasterBLNo.Text = dgvPV.CurrentRow.Cells(6).Value.ToString() 'MasterBLNo
                txtHouseBLNo.Text = dgvPV.CurrentRow.Cells(7).Value.ToString() 'HouseBLNo
                txtSICode.Text = dgvPV.CurrentRow.Cells(8).Value.ToString() 'SICode
                txtPVDescription.Text = dgvPV.CurrentRow.Cells(9).Value.ToString() 'PVDescription
                txtPVRemark.Text = dgvPV.CurrentRow.Cells(10).Value.ToString() 'PVRemark
                'txtReceiptNo.Text = dgvPV.CurrentRow.Cells(11).Value.ToString() 'ReceiptNo
                txtQty.Text = CDbl(dgvPV.CurrentRow.Cells(12).Value.ToString()) 'Qty
                txtPVDetailType.Text = dgvPV.CurrentRow.Cells(13).Value.ToString() 'PVDetailType
                txtCurrency.Text = dgvPV.CurrentRow.Cells(14).Value.ToString() 'Currency
                txtExchangeRate.Text = CDbl(dgvPV.CurrentRow.Cells(15).Value).ToString("#,##0.00") 'ExchangeRate
                txtPVUnitamount.Text = dgvPV.CurrentRow.Cells(16).Value.ToString() 'PVUnitAmount
                txtChargeamount.Text = dgvPV.CurrentRow.Cells(17).Value.ToString() 'ChargeAmount
                cboChangeVaT.Text = dgvPV.CurrentRow.Cells(18).Value.ToString() 'ChangeVAT
                cboChangeWHT.Text = dgvPV.CurrentRow.Cells(19).Value.ToString() 'ChangeWHT
                txtTotalamount.Text = CDbl(dgvPV.CurrentRow.Cells(20).Value).ToString("#,##0.00") 'TotalAmount
                txtadvamount.Text = CDbl(dgvPV.CurrentRow.Cells(21).Value).ToString("#,##0.00") 'AdvAmount
                txtNetTotalamount.Text = CDbl(dgvPV.CurrentRow.Cells(22).Value).ToString("#,##0.00") 'NetTotalAmount
                'txtNetPayment.Text = CDbl(dgvPV.CurrentRow.Cells(23).Value).ToString("#,##0.00") 'NetPayment
                txtROWNo.Text = dgvPV.CurrentRow.Cells(24).Value.ToString() 'ROWNo
                'txtInvoiceNo.Text = dgvPV.CurrentRow.Cells(25).Value.ToString() 'InvoiceNo
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub
    Private Sub btnCreateWHT_Click(sender As Object, e As EventArgs) Handles btnCreateWHT.Click
        'If Not String.IsNullOrEmpty(txtDocCreateNo.Text) Then
        '    Dim frm As New WHT1
        '    frm.txtDocControlNO.Text = Me.txtWHTNo.Text
        '    frm.txtDocRefNo.Text = Me.txtDocCreateNo.Text
        '    frm.ShowDialog()
        '    Me.txtWHTNo.Text = frm.txtDocControlNO.Text
        'End If

        If Not String.IsNullOrEmpty(txtDocCreateNo.Text) Then
            Dim frm As New frmWhtax
            frm.txtDocControlNO.Text = Me.txtWHTNo.Text
            frm.txtDocRefNo.Text = Me.txtDocCreateNo.Text
            frm.txtPAYNumber.Text = Me.txtPVNo.Text
            frm.txtJobRefNo.Text = Me.txtBFTNo.Text
            frm.ShowDialog()
            If Not frm._IsNewPND Then
                Me.txtWHTNo.Text = frm.txtDocControlNO.Text
                SavePaymentVoucher(0)
            End If


        End If

    End Sub
    Private Sub LoadDataPVHeader()
        Dim str As String = " SELECT [DocCreateNo]
        ,[DocNoDate]
        ,[BookAccount]
        ,[PVDate]
        ,[PayFor]
        ,[VendorName]
        ,[Invoice]
        ,[InvoiceDate]
        ,[VendorBankNo]
        ,[TransferNo]
        ,[BankName]
        ,[PVNo]
        ,[PayDate]
        ,[WHTNo]
        ,[WHTUser]
        ,[NetPayment],Ident FROM [Freight_PaymentVoucher] WHERE Active='1' AND DocCreateNo='" & txtDocCreateNo.Text & "'"
        Dim dr As DataRow = SelectSingleRow(str)
        If isSearchOK Then
            txtIdent.Text = dr("Ident").ToString
            txtDocCreateNo.Text = dr("DocCreateNo").ToString
            dtpDocNoDate.Value = CDate(dr("DocNoDate")).ToString
            txtBookaccount.Text = dr("BookAccount").ToString
            dtpPVDate.Value = CDate(dr("PVDate")).ToString
            txtPayFor.Text = dr("PayFor").ToString
            txtVendorName.Text = dr("VendorName").ToString
            txtInvoice.Text = dr("Invoice").ToString
            dtpInvoiceDate.Value = CDate(dr("InvoiceDate")).ToString
            txtVendorBankNo.Text = dr("VendorBankNo").ToString
            txtTransferNo.Text = dr("TransferNo").ToString
            txtBankName.Text = dr("BankName").ToString
            txtPVNo.Text = dr("PVNo").ToString
            dtpPayDate.Value = CDate(dr("PayDate")).ToString
            txtWHTNo.Text = dr("WHTNo").ToString
            txtWHTUser.Text = dr("WHTUser").ToString
            txtNetPayment.Text = dr("NetPayment").ToString
            _IsNew = False
            LoadDataToPV()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetRunningFormat("PV")
        txtPVNo.Text = CreateNumber("Freight_PaymentVoucher", "PVNo", dtpPVDate.Value)
    End Sub
    Private Sub cboChangeVaT_TextChanged(sender As Object, e As EventArgs) Handles cboChangeVaT.TextChanged
        txtVATAmount.Text = cboChangeVaT.Text.Substring(0, cboChangeVaT.Text.Length - 1)
    End Sub
    Private Sub cboChangeWHT_TextChanged(sender As Object, e As EventArgs) Handles cboChangeWHT.TextChanged
        txtWHTAmount.Text = cboChangeWHT.Text.Substring(0, cboChangeWHT.Text.Length - 1)
    End Sub
    Private Sub CalculateData()
        Try
            Dim Qty As Double
            Dim ExchangeRate As Double
            Dim UnitAmount As Double
            Dim ChargeAmount As Double
            Dim VATAmount As Double
            Dim WHTAmount As Double
            Dim TotalAmount As Double
            Dim AdvAmount As Double
            Dim NetTotalamount As Double
            Qty = txtQty.Text
            ExchangeRate = txtExchangeRate.Text
            Unitamount = txtPVUnitamount.Text
            Chargeamount = txtChargeamount.Text
            VATAmount = txtVATAmount.Text
            WHTAmount = txtWHTAmount.Text
            AdvAmount = txtadvamount.Text
            TotalAmount = Qty * (ExchangeRate * UnitAmount)
            txtTotalamount.Text = TotalAmount
            txtVATAmount.Text = CDbl((CDbl(cboChangeVaT.Text.Substring(0, cboChangeVaT.Text.Length - 1)) / 100.0) * CDbl(txtTotalamount.Text))
            txtWHTAmount.Text = CDbl((CDbl(cboChangeWHT.Text.Substring(0, cboChangeWHT.Text.Length - 1)) / 100.0) * CDbl(txtTotalamount.Text))
            VATAmount = txtVATAmount.Text
            WHTAmount = txtWHTAmount.Text
            NetTotalamount = TotalAmount + VATAmount - WHTAmount
            txtNetTotalamount.Text = NetTotalamount
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        CalculateData()
    End Sub

    Private Sub txtExchangeRate_TextChanged(sender As Object, e As EventArgs) Handles txtExchangeRate.TextChanged
        CalculateData()
    End Sub

    Private Sub txtPVUnitamount_TextChanged(sender As Object, e As EventArgs) Handles txtPVUnitamount.TextChanged
        CalculateData()
    End Sub

    Private Sub txtChargeamount_TextChanged(sender As Object, e As EventArgs) Handles txtChargeamount.TextChanged
        CalculateData()
    End Sub

    Private Sub txtVATAmount_TextChanged(sender As Object, e As EventArgs) Handles txtVATAmount.TextChanged
        'CalculateData()
    End Sub

    Private Sub txtWHTAmount_TextChanged(sender As Object, e As EventArgs) Handles txtWHTAmount.TextChanged
        'CalculateData()
    End Sub

    Private Sub txtTotalamount_TextChanged(sender As Object, e As EventArgs) Handles txtTotalamount.TextChanged
        CalculateData()
    End Sub

    Private Sub txtadvamount_TextChanged(sender As Object, e As EventArgs) Handles txtadvamount.TextChanged
        CalculateData()
    End Sub

    Private Sub txtNetTotalamount_TextChanged(sender As Object, e As EventArgs) Handles txtNetTotalamount.TextChanged
        CalculateData()
    End Sub

    Private Sub txtNetPayment_TextChanged(sender As Object, e As EventArgs) Handles txtNetPayment.TextChanged
        CalculateData()
    End Sub

    Private Sub dgvPV_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvPV.RowsAdded
        Dim Net As Double
        Try
            If dgvPV.Rows.Count > 0 Then
                For i As Integer = 0 To dgvPV.Rows.Count - 2
                    Net += dgvPV.Rows(i).Cells(22).Value '+ dgvPreInv.Rows(i).Cells(4).Value
                Next
                txtNetPayment.Text = Net.ToString()
            Else
                txtNetPayment.Text = Net.ToString()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub MetroTextBox1_ButtonClick(sender As Object, e As EventArgs) Handles MetroTextBox1.ButtonClick
        If _IsNewD = True Then
            _IsNewD = False
        Else
            _IsNewD = True
        End If
    End Sub


End Class