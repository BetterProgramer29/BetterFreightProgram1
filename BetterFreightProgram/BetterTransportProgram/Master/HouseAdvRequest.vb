Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Text

Public Class HouseadvRequest
    Public _IsNew As Boolean
    Public _IsNewD As Boolean
    Public IsCNorDN As Boolean

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtDocCreateNo.Text = "" Then
            GetRunningFormat("ADVNO")
            txtDocCreateNo.Text = CreateNumber("Freight_HouseAdvRequest", "DocCreateNo", dtpDocCreateDate.Value)
        End If
        If _IsNew = True Then
            SaveHouseadvRequest(1)
        Else
            SaveHouseadvRequest(0)
        End If

    End Sub
    Private Sub LoadCNToAdvRequest()
        Try
            dgvCostDN.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_HouseCN where DocNo='" & txtBCFNo.Text & "' and InAdvReq='0' and Active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvCostDN.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                           dt.Rows(i)(1).ToString(), 'QuotationDetailType
                           dt.Rows(i)(2).ToString(), 'SICode
                           "",
                           dt.Rows(i)(3).ToString(), 'SICodeDescription
                           dt.Rows(i)(4).ToString(), 'Remark
                           dt.Rows(i)(5).ToString(), 'Qty
                           dt.Rows(i)(6).ToString(), 'Tys
                           dt.Rows(i)(7).ToString(), 'Currency
                           CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
                           dt.Rows(i)(9).ToString(), 'UnitPrice
                           dt.Rows(i)(10).ToString(), 'Totalamount
                           CDbl(dt.Rows(i)(11).ToString()), 'VaT
                           CDbl(dt.Rows(i)(12).ToString()), 'WHT
                           CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT
                           CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT
                           CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
                           dt.Rows(i)(16).ToString(), 'QuotationNo
                           dt.Rows(i)(17).ToString(), 'active
                           dt.Rows(i)(18).ToString(), 'DocNo
                           "",
                           "",
                           dt.Rows(i)(19).ToString(),
                           dt.Rows(i)(20).ToString(),
                           "1",
                           "1"
                            )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDNToAdvRequest()
        Try
            dgvCostDN.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_HouseDN where DocNo='" & txtBCFNo.Text & "' and SICode LIKE 'OA%'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvCostDN.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                           dt.Rows(i)(1).ToString(), 'QuotationDetailType
                           dt.Rows(i)(2).ToString(), 'SICode
                           "",
                           dt.Rows(i)(3).ToString(), 'SICodeDescription
                           dt.Rows(i)(4).ToString(), 'Remark
                           dt.Rows(i)(5).ToString(), 'Qty
                           dt.Rows(i)(6).ToString(), 'Tys
                           dt.Rows(i)(7).ToString(), 'Currency
                           CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
                           dt.Rows(i)(9).ToString(), 'UnitPrice
                           dt.Rows(i)(10).ToString(), 'Totalamount
                           CDbl(dt.Rows(i)(11).ToString()), 'VaT
                           CDbl(dt.Rows(i)(12).ToString()), 'WHT
                           CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT
                           CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT
                           CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
                           dt.Rows(i)(16).ToString(), 'QuotationNo
                           dt.Rows(i)(17).ToString(), 'active
                           dt.Rows(i)(18).ToString(), 'DocNo
                           "",
                           "",
                           dt.Rows(i)(19).ToString(),
                           dt.Rows(i)(20).ToString(),
                           "1"
                            )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToAdvRequest()
        Try
            dgvCostDN.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_AdvRequestDetail where DocNo='" & txtDocCreateNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvCostDN.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                           dt.Rows(i)(1).ToString(), 'QuotationDetailType
                           dt.Rows(i)(2).ToString(), 'SICode
                           "",
                           dt.Rows(i)(3).ToString(), 'SICodeDescription
                           dt.Rows(i)(4).ToString(), 'Remark
                           dt.Rows(i)(5).ToString(), 'Qty
                           dt.Rows(i)(6).ToString(), 'Tys
                           dt.Rows(i)(7).ToString(), 'Currency
                           CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
                           dt.Rows(i)(9).ToString(), 'UnitPrice
                           dt.Rows(i)(10).ToString(), 'Totalamount
                           CDbl(dt.Rows(i)(11).ToString()), 'VaT
                           CDbl(dt.Rows(i)(12).ToString()), 'WHT
                           CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT
                           CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT
                           CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
                           dt.Rows(i)(16).ToString(), 'QuotationNo
                           dt.Rows(i)(17).ToString(), 'active
                           dt.Rows(i)(18).ToString(), 'DocNo
                           dt.Rows(i)(19).ToString(),
                           dt.Rows(i)(20).ToString(),
                           dt.Rows(i)(21).ToString(),
                           dt.Rows(i)(22).ToString(),
                           "0",
                           "0",
                           dt.Rows(i)(25).ToString()
                            )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveHouseadvRequest(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_HouseAdvRequest ")
            SQLcommand.Append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.Append(",'" & txtaDVType.Text & "'") 'advType
            SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'DocCreateNo
            SQLcommand.Append(",'" & CDate(dtpDocCreateDate.Value) & "'") 'DocCreateDate
            SQLcommand.Append(",'" & txtBookaccount.Text & "'") 'Bookaccount
            SQLcommand.Append(",'" & CDate(dtpaDVDate.Value) & "'") 'advDate
            SQLcommand.Append(",'" & txtPayFor.Text & "'") 'PayFor
            SQLcommand.Append(",'" & txtVendorName.Text & "'") 'VendorName
            SQLcommand.Append(",'" & txtInvoice.Text & "'") 'Invoice
            SQLcommand.Append(",'" & txtVendorBankNo.Text & "'") 'VendorBankNo
            SQLcommand.Append(",'" & txtTransferNo.Text & "'") 'TransferNo
            SQLcommand.Append(",'" & txtBankName.Text & "'") 'BankName
            SQLcommand.Append(",'" & txtWHTNo.Text & "'") 'WHTNo
            SQLcommand.Append(",'" & txtWHTHeader.Text & "'") 'WHTHeader
            SQLcommand.Append(",'" & CDbl(txtNetPayment.Text) & "'")
            SQLcommand.Append(",'" & txtBCFNo.Text & "'")
            SQLcommand.Append(",'" & txtMasterBL.Text & "'")
            SQLcommand.Append(",'" & txtHouseBL.Text & "'")
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaveHouseadvRequestDetail()
    End Sub
    Private Sub RunRowNo()

    End Sub
    Private Sub UpdateAdvToHBL()
        'Try
        '    Dim nection As New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim a As Integer = 0
        '    For row As Integer = 0 To dgvCostDN.Rows.Count - 2
        '        'If dgvCostDN.Rows(row).Cells(21).Value.ToString = "" Then
        '        '    GetRunningFormat("ROW")
        '        '    dgvCostDN.Rows(row).Cells(21).Value = CreateNumber("Freight_AdvRequestDetail", "ROWNo", dtpDocCreateDate.Value)
        '        'End If
        '        If dgvCostDN.Rows(row).Cells(25).Value = "1" Then
        '            Try
        '                Dim SQLcommand As StringBuilder = New StringBuilder("exec UpdateAdvRequestToHBL ")
        '                SQLcommand.Append("'" & CInt(dgvCostDN.Rows(row).Cells(0).Value) & "'")
        '                SQLcommand.Append(",'" & txtInAdvReq.Text & "'")
        '                SQLcommand.Append(",'" & txtDocCreateNo.Text & "'")

        '                Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
        '                If result = 1 Then
        '                Else
        '                    a += 1
        '                End If
        '            Catch ex As Exception
        '                a += 1
        '                MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            End Try
        '        End If
        '    Next
        '    nection.Close()
        '    If a > 0 Then
        '        MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Else
        '        MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        LoadDataToDgv()
        '    End If
        'Catch ex As Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub SaveHouseadvRequestDetail()
        Try
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a As Integer = 0
            For row As Integer = 0 To dgvCostDN.Rows.Count - 2
                'If dgvCostDN.Rows(row).Cells(21).Value.ToString = "" Then
                '    GetRunningFormat("ROW")
                '    dgvCostDN.Rows(row).Cells(21).Value = CreateNumber("Freight_AdvRequestDetail", "ROWNo", dtpDocCreateDate.Value)
                'End If
                If dgvCostDN.Rows(row).Cells(21).Value = "" Then
                    GetRunningFormat("ROW")
                    dgvCostDN.Rows(row).Cells(21).Value = CreateNumber("Freight_AdvRequestDetail", "ROWNo", dtpDocCreateDate.Value)
                End If
                If dgvCostDN.Rows(row).Cells(25).Value = "1" Then
                    Try
                        Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_AdvRequestDetail ")
                        SQLcommand.Append("'" & CInt(dgvCostDN.Rows(row).Cells(0).Value) & "'")
                        SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(1).Value & "'")
                        SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(2).Value & "'")
                        SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(4).Value & "'")
                        SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(5).Value & "'")
                        SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(6).Value) & "'")
                        SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(7).Value & "'")
                        SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(8).Value & "'")
                        SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(9).Value) & "'")
                        SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(10).Value) & "'")
                        SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(11).Value) & "'")
                        SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(12).Value) & "'")
                        SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(13).Value) & "'")
                        SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(14).Value) & "'")
                        SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(15).Value) & "'")
                        SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(16).Value) & "'")
                        SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(17).Value & "'")
                        SQLcommand.Append(",'" & CInt(dgvCostDN.Rows(row).Cells(18).Value) & "'")
                        SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(19).Value & "'")
                        SQLcommand.Append(",'" & txtDocCreateNo.Text & "'")
                        SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(21).Value & "'")
                        SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(22).Value & "'")
                        SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(23).Value & "'")
                        SQLcommand.Append(",'" & txtSysUser.Text & "'")
                        SQLcommand.Append(",'" & txtVendorName.Text & "'")
                        SQLcommand.Append(",'" & CInt(dgvCostDN.Rows(row).Cells(24).Value) & "'")
                        Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                        If result = 1 Then
                        Else
                            a += 1
                        End If
                    Catch ex As Exception
                        a += 1
                        MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End Try
                End If
            Next
            nection.Close()
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToDgv()
                UpdateAdvToHBL()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        'Try
        '    Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_HouseadvRequestDetail ")
        '    SQLcommand.Append("'" & txtIdentD.Text & "'") 'Ident
        '    SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'DocNo
        '    SQLcommand.Append(",'" & txtBCFNo.Text & "'") 'advNo
        '    SQLcommand.Append(",'" & txtBookingNo.Text & "'") 'BookingNo
        '    SQLcommand.Append(",'" & txtSICode.Text & "'") 'SICode
        '    SQLcommand.Append(",'" & txtDescription.Text & "'") 'DetailDescription
        '    SQLcommand.Append(",'" & txtRemark.Text & "'") 'Remark
        '    SQLcommand.Append(",'" & txtReceiptNo.Text & "'") 'ReceiptNo
        '    SQLcommand.Append(",'" & CInt(txtQty.Text) & "'") 'Qty
        '    SQLcommand.Append(",'" & txtDetailType.Text & "'") 'DetailType
        '    SQLcommand.Append(",'" & txtDetailCurrency.Text & "'") 'DetailCurrency
        '    SQLcommand.Append(",'" & CDbl(txtUnitamount.Text) & "'") 'Unitamount
        '    SQLcommand.Append(",'" & CDbl(txtChargeamount.Text) & "'") 'Chargeamount
        '    SQLcommand.Append(",'" & cboVaT.Text & "'") 'VaT
        '    SQLcommand.Append(",'" & cboWHT.Text & "'") 'WHT
        '    SQLcommand.Append(",'" & CDbl(txtTotalCHGamount.Text) & "'") 'TotalCHGamount
        '    SQLcommand.Append(",'" & CDbl(txtadvamount.Text) & "'") 'advamount
        '    SQLcommand.Append(",'" & CDbl(txtNetTotalamount.Text) & "'") 'NetTotalamount
        '    SQLcommand.Append(",'" & CDbl(txtNetPayment.Text) & "'") 'NetPayment
        '    SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
        '    Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
        '    If result = 1 Then
        '        MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Else
        '        MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    End If
        '    nection.Close()
        'Catch ex As Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub SaveApprove()
        Try
            If dgvCostDN.Rows.Count > 0 Then
                Dim nection As New OleDb.OleDbConnection()
                nection = ConnectDB()
                'For row As Integer = 0 To dgvCostDN.Rows.Count - 1
                Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateApproveAdvance ")
                SQLcommand.Append("'" & CInt(dgvCostDN.CurrentRow.Cells(0).Value) & "'") 'Ident
                SQLcommand.Append(",'" & UserProfile.U_FName & " " & UserProfile.U_LName & "'") 'ApproveBy
                    SQLcommand.Append(",'" & CDate(dtpCurrentDate.Value) & "'") 'ApproveDate
                    Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then

                    Else

                    End If
                'Next
                nection.Close()
            End If
            'Userauthorize(UserProfile.U_Code, "ADVR")
            'If Userauthen.IsCheckData = "1" Then
            '    EnableDetail()
            'Else
            '    DisableDetail()
            'End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub MetroGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub HouseadvRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSysUser.Text = UserProfile.U_FName & " " & UserProfile.U_LName
        MsgBox(IsCNorDN)
        If _IsNew = True Then
            If IsCNorDN = True Then
                _IsNew = True
                _IsNewD = True
                LoadCNToAdvRequest()
            Else
                _IsNew = True
                _IsNewD = True
                LoadDNToAdvRequest()
            End If
        Else
            Dim dr As DataRow
            Dim sqlstr As String = "SELECT TOP (100) 
        [AdvType]
      ,[DocCreateNo]
      ,[DocCreateDate]
      ,[BookAccount]
      ,[AdvDate]
      ,[PayFor]
      ,[VendorName]
      ,[Invoice]
      ,[VendorBankNo]
      ,[TransferNo]
      ,[BankName]
      ,[WHTNo]
      ,[WHTHeader],[Ident]
        FROM Freight_HouseAdvRequest WHERE 1=1 and DocCreateNo='" & txtDocCreateNo.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtIdent.Text = dr("Ident").ToString
                txtaDVType.Text = dr("AdvType").ToString
                dtpDocCreateDate.Value = CDate(dr("DocCreateDate")).ToString
                txtBookaccount.Text = dr("BookAccount").ToString
                dtpaDVDate.Value = CDate(dr("AdvDate")).ToString
                txtPayFor.Text = dr("PayFor").ToString
                txtVendorName.Text = dr("VendorName").ToString
                txtInvoice.Text = dr("Invoice").ToString
                txtVendorBankNo.Text = dr("VendorBankNo").ToString
                txtTransferNo.Text = dr("TransferNo").ToString
                txtBankName.Text = dr("BankName").ToString
                txtWHTNo.Text = dr("WHTNo").ToString
                txtWHTHeader.Text = dr("WHTHeader").ToString
                LoadDataToDgv()
                _IsNew = False
                _IsNewD = False
            End If
        End If

    End Sub

    Private Sub txtPayFor_ButtonClick(sender As Object, e As EventArgs) Handles txtPayFor.ButtonClick
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
            txtPayFor.Text = dr("VendorName").ToString
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
            txtVendorBankNo.Text = dr("VendorBankNo").ToString
            dgvCostDN.CurrentRow.Cells(26).Value = dr("VendorName").ToString
        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP (100) 
        [AdvType]
      ,[DocCreateNo]
      ,[DocCreateDate]
      ,[BookAccount]
      ,[AdvDate]
      ,[PayFor]
      ,[VendorName]
      ,[Invoice]
      ,[VendorBankNo]
      ,[TransferNo]
      ,[BankName]
      ,[WHTNo]
      ,[WHTHeader]
        FROM Freight_HouseAdvRequest WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtaDVType.Text = dr("AdvType").ToString
            txtDocCreateNo.Text = dr("DocCreateNo").ToString
            dtpDocCreateDate.Value = CDate(dr("DocCreateDate")).ToString
            txtBookaccount.Text = dr("BookAccount").ToString
            dtpaDVDate.Value = CDate(dr("AdvDate")).ToString
            txtPayFor.Text = dr("PayFor").ToString
            txtVendorName.Text = dr("VendorName").ToString
            txtInvoice.Text = dr("Invoice").ToString
            txtVendorBankNo.Text = dr("VendorBankNo").ToString
            txtTransferNo.Text = dr("TransferNo").ToString
            txtBankName.Text = dr("BankName").ToString
            txtWHTNo.Text = dr("WHTNo").ToString
            txtWHTHeader.Text = dr("WHTHeader").ToString
            LoadDataToDgv()
        End If
    End Sub

    Private Sub txtBookaccount_ButtonClick(sender As Object, e As EventArgs) Handles txtBookaccount.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) BookingNo,AccountName,AccountType  FROM BookAccount WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtBookaccount.Text = dr("BookingNo").ToString
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If txtInAdvReq.Text = "1" Then
            txtInAdvReq.Text = "0"
        Else
            txtInAdvReq.Text = "1"
        End If
    End Sub

    Private Sub dgvCostDN_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvCostDN.RowsAdded
        CalculateData()
        dgvCostDN.Rows(e.RowIndex).Cells(19).Value = txtBCFNo.Text
        dgvCostDN.Rows(e.RowIndex).Cells(23).Value = txtMasterBL.Text
        dgvCostDN.Rows(e.RowIndex).Cells(22).Value = txtHouseBL.Text
        If dgvCostDN.Rows(e.RowIndex).IsNewRow Then
            dgvCostDN.Rows(e.RowIndex).Cells(24).Value = "1" 'new
        Else
            dgvCostDN.Rows(e.RowIndex).Cells(24).Value = "0" 'new
        End If
    End Sub
    Private Sub CalculateData()
        Try
            Dim NET As Double = 0 'aDV
            If dgvCostDN.Rows.Count > 0 Then
                For i As Integer = 0 To dgvCostDN.Rows.Count - 2
                    If dgvCostDN.Rows(i).Cells(25).Value.ToString = "1" Then
                        NET += dgvCostDN.Rows(i).Cells(16).Value '+ dgvInvoice.Rows(i).Cells(4).Value
                    End If
                Next
                txtNetPayment.Text = NET.ToString("#,##0.00")
            Else
                txtNetPayment.Text = NET.ToString("#,##0.00")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCostDN_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostDN.CellEndEdit
        CalculateData()
        Try
            'dgvCostCN.CurrentRow.Cells(23).Value = txtHouseBLNo.Text
            dgvCostDN.CurrentRow.Cells(11).Value = ((CDbl(dgvCostDN.CurrentRow.Cells(6).Value) * CDbl(dgvCostDN.CurrentRow.Cells(10).Value)) * CDbl(dgvCostDN.CurrentRow.Cells(9).Value)).ToString("#,##0.00")
            dgvCostDN.CurrentRow.Cells(14).Value = (CDbl(dgvCostDN.CurrentRow.Cells(11).Value) + ((CDbl(dgvCostDN.CurrentRow.Cells(12).Value) / 100)) * CDbl(dgvCostDN.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvCostDN.CurrentRow.Cells(15).Value = (CDbl(dgvCostDN.CurrentRow.Cells(11).Value) - ((CDbl(dgvCostDN.CurrentRow.Cells(13).Value) / 100)) * CDbl(dgvCostDN.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvCostDN.CurrentRow.Cells(16).Value = (CDbl(dgvCostDN.CurrentRow.Cells(11).Value) + (CDbl(dgvCostDN.CurrentRow.Cells(12).Value) / 100) * CDbl(dgvCostDN.CurrentRow.Cells(11).Value) - (CDbl(dgvCostDN.CurrentRow.Cells(13).Value) / 100) * CDbl(dgvCostDN.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim url As String = "http://203.170.129.23/TESTFRIEGHT/report/AdvanceRequest?AdvNo=" & txtDocCreateNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub txtDocCreateNo_TextChanged(sender As Object, e As EventArgs) Handles txtDocCreateNo.TextChanged
        '  Dim dr As DataRow
        '  Dim sqlstr As String = "SELECT TOP (100) 
        '  [AdvType]
        ',[DocCreateNo]
        ',[DocCreateDate]
        ',[BookAccount]
        ',[AdvDate]
        ',[PayFor]
        ',[VendorName]
        ',[Invoice]
        ',[VendorBankNo]
        ',[TransferNo]
        ',[BankName]
        ',[WHTNo]
        ',[WHTHeader]
        '  FROM Freight_HouseAdvRequest WHERE 1=1 and DocCreateNo='" & txtDocCreateNo.Text & "'"
        '  dr = SelectSingleRow(sqlstr)
        '  If Not IsNothing(dr) Then
        '      txtaDVType.Text = dr("AdvType").ToString
        '      dtpDocCreateDate.Value = CDate(dr("DocCreateDate")).ToString
        '      txtBookaccount.Text = dr("BookAccount").ToString
        '      dtpaDVDate.Value = CDate(dr("AdvDate")).ToString
        '      txtPayFor.Text = dr("PayFor").ToString
        '      txtVendorName.Text = dr("VendorName").ToString
        '      txtInvoice.Text = dr("Invoice").ToString
        '      txtVendorBankNo.Text = dr("VendorBankNo").ToString
        '      txtTransferNo.Text = dr("TransferNo").ToString
        '      txtBankName.Text = dr("BankName").ToString
        '      txtWHTNo.Text = dr("WHTNo").ToString
        '      txtWHTHeader.Text = dr("WHTHeader").ToString
        '      LoadDataToDgv()
        '  End If
    End Sub
    Private Sub LoadDataToDgv()
        Try
            dgvCostDN.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_AdvRequestDetail where 1=1 and DocNo='" & txtDocCreateNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvCostDN.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'AdvType
                    dt.Rows(i)(2).ToString(), 'SICode
                    "",
                    dt.Rows(i)(3).ToString(), 'SICodeDescription
                    dt.Rows(i)(4).ToString(), 'AdvRemark
                    dt.Rows(i)(5).ToString(), 'QTY
                    dt.Rows(i)(6).ToString(), 'Tys
                    dt.Rows(i)(7).ToString(), 'Currency
                    CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
                    CDbl(dt.Rows(i)(9).ToString()), 'UnitPrice
                    CDbl(dt.Rows(i)(10).ToString()), 'Total
                    CDbl(dt.Rows(i)(11).ToString()), 'VAT
                    CDbl(dt.Rows(i)(12).ToString()), 'WHT
                    CDbl(dt.Rows(i)(13).ToString()), 'TotalAmtPlusVAT
                    CDbl(dt.Rows(i)(14).ToString()), 'TotalAmtMinusWHT
                    CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
                    dt.Rows(i)(16).ToString(), 'QuotationNo
                    dt.Rows(i)(17).ToString(), 'Active
                    dt.Rows(i)(18).ToString(), 'BCFNo
                    dt.Rows(i)(19).ToString(), 'DocNo
                    dt.Rows(i)(20).ToString(), 'ROWNo
                    dt.Rows(i)(21).ToString(), 'HBLNo
                    dt.Rows(i)(22).ToString(), 'MBLNo
                    "0", 'PVNo
                    "1", 'SysUser
                    dt.Rows(i)(25).ToString(),  'VendorName
                    dt.Rows(i)(26).ToString()
        )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Event DataGridView3ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)

    Private Sub DataGridView3_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgvCostDN.CellContentClick
        'MsgBox(e.ColumnIndex)
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent DataGridView3ButtonClick(senderGrid, e)
            dgvCostDN.CurrentRow.Cells(18).Value = "1"
            dgvCostDN.CurrentRow.Cells(25).Value = "1"
            'If dgvCostDN.CurrentRow.Cells(24).Value <> "1" Or dgvCostDN.CurrentRow.Cells(24).Value <> "0" Then
            'If dgvCostDN.CurrentRow.Cells(24).Value = "1" Or dgvCostDN.CurrentRow.Cells(24).Value = "0" Then
            '    dgvCostDN.CurrentRow.Cells(24).Value = "0"
            'Else

            '    dgvCostDN.CurrentRow.Cells(24).Value = "1"
            'End If
        End If
    End Sub
    Private Sub DataGridView3_ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles Me.DataGridView3ButtonClick
        If e.ColumnIndex = 3 Then
            Dim dr As DataRow
            dr = PopUpSearch("Select TOP(100) [accountGroup], [ItemName]
            ,[accountNo]
            ,[accountControl]
            ,[SICode]
            ,[accountName]
            ,[SIGroup]  FROM [MaS_SICODE] WHERE 1=1", MainConnection)
            If isSearchOK Then
                dgvCostDN.CurrentRow.Cells(2).Value = dr("SICode").ToString
                dgvCostDN.CurrentRow.Cells(4).Value = dr("ItemName").ToString
                dgvCostDN.CurrentRow.Cells(18).Value = "1"
                dgvCostDN.CurrentRow.Cells(25).Value = "1"
            End If
        ElseIf e.ColumnIndex = 28 Then
            SaveApprove()
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

    End Sub
End Class