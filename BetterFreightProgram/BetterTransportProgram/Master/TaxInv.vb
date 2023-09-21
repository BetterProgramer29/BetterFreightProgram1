Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text

Public Class TaxInv
    Public _IsNew As Boolean
    Public _IsNewD As Boolean
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtDocCreateNo.Text = "" Then
            GetRunningFormat("TAXINV")
            txtDocCreateNo.Text = CreateNumber("Freight_TaxInv", "DocCreateNo", dtpDocNoDate.Value)
        End If
        If _IsNew = True Then
            SaveTaxInv(1)
        Else
            SaveTaxInv(0)
        End If
    End Sub
    Private Sub SaveTaxInv(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_TaxInv ")
            SQLcommand.Append("'" & txtIdent.Text & "'") 'ident
            SQLcommand.Append(",'" & txtTaxType.Text & "'") 'TaxType
            SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'DocCreateNo
            SQLcommand.Append(",'" & CDate(dtpDocNoDate.Value) & "'") 'DocCreateDate
            SQLcommand.Append(",'" & txtBookaccount.Text & "'") 'Bookaccount
            SQLcommand.Append(",'" & txtReferenceNo.Text & "'") 'ReferenceNo
            SQLcommand.Append(",'" & txtCustomerName.Text & "'") 'CustomerName
            SQLcommand.Append(",'" & txtReceiveFrom.Text & "'") 'ReceiveFrom
            SQLcommand.Append(",'" & CDbl(txtamountReceived.Text) & "'") 'amountReceived
            SQLcommand.Append(",'" & txtChqNo.Text & "'") 'ChqNo
            SQLcommand.Append(",'" & CDate(dtpChqDate.Value) & "'") 'ChqDate
            SQLcommand.Append(",'" & txtTaxInvNo.Text & "'") 'TaxInvNo
            SQLcommand.Append(",'" & CDate(dtpTaXDate.Value) & "'") 'TaxInvDate
            SQLcommand.Append(",'" & txtBankNo.Text & "'") 'BankNo
            SQLcommand.Append(",'" & txtRVNo.Text & "'") 'RVNo
            SQLcommand.Append(",'" & CDbl(txtTotaladvance.Text) & "'") 'Totaladvance
            SQLcommand.Append(",'" & CDbl(txtTotalCharge.Text) & "'") 'TotalCharge
            SQLcommand.Append(",'" & CDbl(txtTotalWHT.Text) & "'") 'TotalWHT
            SQLcommand.Append(",'" & CDbl(txtTotalTotalamount.Text) & "'") 'TotalTotalamount
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
        SaveTaxInvDetail()
    End Sub
    Private Sub SaveTaxInvDetail()
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a As Integer = 0
            For row As Integer = 0 To dgvTaxInv.Rows.Count - 1
                If dgvTaxInv.Rows(row).Cells(33).Value.ToString = "1" Then
                    Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsert_TaxInv ")
                    SQLcommand.Append("'" & CInt(dgvTaxInv.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'SICode
                    SQLcommand.Append(",'" & CDbl(dgvTaxInv.Rows(row).Cells(33).Value) & "'") 'SICodeDescription
                    Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                    Else
                        a += 1
                    End If
                End If
            Next
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub txtRVNo_ButtonClick(sender As Object, e As EventArgs) Handles txtRVNo.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT [RVType]
        ,[DocCreateNo]
        ,[DocCreateDate]
        ,[BookAccount]
        ,[ReferenceNo]
        ,[RVReceivedMoneyDate]
        ,[RVNo]
        ,[CustomerName]
        ,[ReceivedFrom]
        ,[ChqNo]
        ,[Bank]
        ,[ChqDate]
        ,[TotalAmountReceived]
        ,[SearchInvoiceNo]
        ,[BookingNo]
        ,[VesselBookingNo]
        ,[MasterBLNo]
        ,[HouseBLNo]
         FROM [Freight_ReceiveVoucher] where 1=1", MainConnection)
        If isSearchOK Then
            txtRVNo.Text = dr("DocCreateNo").ToString
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
            Dim str As String = "SELECT * FROM Freight_Invoice where RVNo='" & txtRVNo.Text & "' and ISNULL(TINVNo,'')=''"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvTaxInv.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'InvoiceNo
                    dt.Rows(i)(2).ToString(), 'InvoiceDate
                    dt.Rows(i)(3).ToString(), 'TaxInvNo
                    dt.Rows(i)(4).ToString(), 'TaxInvDate
                    dt.Rows(i)(5).ToString(), 'Customer
                    dt.Rows(i)(6).ToString(), 'CustomerCode
                    dt.Rows(i)(7).ToString(), 'Customeraddress
                    dt.Rows(i)(8).ToString(), 'BTTLocation
                    dt.Rows(i)(9).ToString(), 'PickupLocation
                    dt.Rows(i)(10).ToString(), 'LoadingLocation
                    dt.Rows(i)(11).ToString(), 'ReturnLocation
                    dt.Rows(i)(12).ToString(), 'JobNo
                    dt.Rows(i)(13).ToString(), 'VesselBooking
                    dt.Rows(i)(14).ToString(), 'BLNo
                    CDbl(dt.Rows(i)(15).ToString()), 'TransportCharge
                    CDbl(dt.Rows(i)(16).ToString()), 'Reinbursement
                    CDbl(dt.Rows(i)(17).ToString()), 'Totalamount
                    dt.Rows(i)(18).ToString(), 'CurrentUser ////___|
                    dt.Rows(i)(19).ToString(), 'active|     |  |   | 
                    CDbl(dt.Rows(i)(20).ToString()), 'InvSum
                    CDbl(dt.Rows(i)(21).ToString()), 'ReinburseCharge
                    dt.Rows(i)(22).ToString(), 'ChangeTax
                    dt.Rows(i)(23).ToString(), 'ChangeVat
                    dt.Rows(i)(24).ToString(), 'SoaNo
                    dt.Rows(i)(25).ToString(), 'SELECTSOa
                    CDbl(dt.Rows(i)(26).ToString()), 'advanceRecieve
                    CDbl(dt.Rows(i)(27).ToString()), 'TransportDiscount
                    dt.Rows(i)(28).ToString()  'RVNo
        )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
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
    Private Sub LoadDataToInv()
        Try
            dgvTaxInv.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_Invoice where RVNo='" & txtRVNo.Text & "' and TINVNo = '" & txtDocCreateNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvTaxInv.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'InvoiceNo
                    dt.Rows(i)(2).ToString(), 'InvoiceDate
                    dt.Rows(i)(3).ToString(), 'TaxInvNo
                    dt.Rows(i)(4).ToString(), 'TaxInvDate
                    dt.Rows(i)(5).ToString(), 'Customer
                    dt.Rows(i)(6).ToString(), 'CustomerCode
                    dt.Rows(i)(7).ToString(), 'Customeraddress
                    dt.Rows(i)(8).ToString(), 'BTTLocation
                    dt.Rows(i)(9).ToString(), 'PickupLocation
                    dt.Rows(i)(10).ToString(), 'LoadingLocation
                    dt.Rows(i)(11).ToString(), 'ReturnLocation
                    dt.Rows(i)(12).ToString(), 'JobNo
                    dt.Rows(i)(13).ToString(), 'VesselBooking
                    dt.Rows(i)(14).ToString(), 'BLNo
                    CDbl(dt.Rows(i)(15).ToString()), 'TransportCharge
                    CDbl(dt.Rows(i)(16).ToString()), 'Reinbursement
                    CDbl(dt.Rows(i)(17).ToString()), 'Totalamount
                    dt.Rows(i)(18).ToString(), 'CurrentUser ////___|
                    dt.Rows(i)(19).ToString(), 'active|     |  |   |
                    CDbl(dt.Rows(i)(20).ToString()), 'InvSum
                    CDbl(dt.Rows(i)(21).ToString()), 'ReinburseCharge
                    dt.Rows(i)(22).ToString(), 'ChangeTax
                    dt.Rows(i)(23).ToString(), 'ChangeVat
                    dt.Rows(i)(24).ToString(), 'SoaNo
                    dt.Rows(i)(25).ToString(), 'SELECTSOa
                    CDbl(dt.Rows(i)(26).ToString()), 'advanceRecieve
                    CDbl(dt.Rows(i)(27).ToString()), 'TransportDiscount
                    dt.Rows(i)(28).ToString()  'RVNo
        )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
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
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [TaxType]
      ,[DocCreateNo]
      ,[DocCreateDate]
      ,[BookAccount]
      ,[ReferenceNo]
      ,[CustomerName]
      ,[ReceiveFrom]
      ,[AmountReceived]
      ,[ChqNo]
      ,[ChqDate]
      ,[TaxInvNo]
      ,[TaxInvDate]
      ,[BankNo]
      ,[RVNo]
      ,[TotalAdvance]
      ,[TotalCharge]
      ,[TotalWHT]
      ,[TotalTotalAmount],ident  FROM Freight_TaxInv where 1=1", MainConnection)
        If isSearchOK Then
            txtTaxType.Text = dr("TaxType").ToString
            txtDocCreateNo.Text = dr("DocCreateNo").ToString()
            dtpDocNoDate.Value = CDate(dr("DocCreateDate")).ToString()
            txtBookaccount.Text = dr("BookAccount").ToString()
            txtReferenceNo.Text = dr("ReferenceNo").ToString()
            txtCustomerName.Text = dr("CustomerName").ToString()
            txtReceiveFrom.Text = dr("ReceiveFrom").ToString()
            txtamountReceived.Text = dr("AmountReceived").ToString()
            txtChqNo.Text = dr("ChqNo").ToString()
            dtpChqDate.Value = CDate(dr("ChqDate")).ToString()
            txtTaxInvNo.Text = dr("TaxInvNo").ToString()
            dtpTaXDate.Value = CDate(dr("TaxInvDate")).ToString()
            txtBankNo.Text = dr("BankNo").ToString()
            txtRVNo.Text = dr("RVNo").ToString()
            txtTotaladvance.Text = dr("TotalAdvance").ToString()
            txtTotalCharge.Text = dr("TotalCharge").ToString()
            txtTotalWHT.Text = dr("TotalWHT").ToString()
            txtTotalTotalamount.Text = dr("TotalTotalAmount").ToString()
            _IsNew = False
            LoadDataToInv()
        End If
    End Sub

    Private Sub txtCustomerName_ButtonClick(sender As Object, e As EventArgs) Handles txtCustomerName.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail  FROM Mas_Customer WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtCustomerName.Text = dr("CustName").ToString
        End If
    End Sub

    Private Sub txtReceiveFrom_ButtonClick(sender As Object, e As EventArgs) Handles txtReceiveFrom.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail  FROM Mas_Customer WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtReceiveFrom.Text = dr("CustName").ToString
        End If
    End Sub

    Private Sub txtBookaccount_ButtonClick(sender As Object, e As EventArgs) Handles txtBookaccount.ButtonClick

    End Sub

    Private Sub TaxInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _IsNew = True
    End Sub
End Class