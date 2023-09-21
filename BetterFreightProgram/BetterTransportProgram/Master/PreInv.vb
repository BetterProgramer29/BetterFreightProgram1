Imports System.Data.OleDb
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices

Public Class PreInv
    Public _IsNew As Boolean
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtPreInvoiceNo.Text = "" Then
            GetRunningFormat("PINV")
            txtPreInvoiceNo.Text = CreateNumber("Freight_PreINV", "PreInvoiceNo", False)
        End If
        If _IsNew = True Then
            SavePreInv(1)
        Else
            SavePreInv(0)
        End If
    End Sub
    Private Sub SavePreInv(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_PreInv ")
            SQLcommand.Append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.Append(",'" & txtPreInvoiceNo.Text & "'") 'PreInvoiceNo
            SQLcommand.Append(",'" & CDate(dtpPreInvoiceDate.Value) & "'") 'PreInvoiceDate
            SQLcommand.Append(",'" & txtBCFNo.Text & "'") 'BCFNo
            SQLcommand.Append(",'" & txtMasterBLNo.Text & "'") 'MasterBLNo
            SQLcommand.Append(",'" & txtVesselBooking.Text & "'") 'VesselBooking
            SQLcommand.Append(",'" & txtTaxInvNo.Text & "'") 'TaxInvNo
            SQLcommand.Append(",'" & CDate(dtpTaxInvDate.Value) & "'") 'TaxInvDate
            SQLcommand.Append(",'" & txtCustomer.Text & "'") 'Customer
            SQLcommand.Append(",'" & txtCustCode.Text & "'") 'CustomerCode
            SQLcommand.Append(",'" & txtCustomeraddress.Text & "'") 'Customeraddress
            SQLcommand.Append(",'" & txtNameOfImportExport.Text & "'") 'NameOfImportExport
            SQLcommand.Append(",'" & txtHouseBLNo.Text & "'") 'HouseBLNo
            SQLcommand.Append(",'" & txtPortOfLoading.Text & "'") 'PortOfLoading
            SQLcommand.Append(",'" & txtPortOfDischarge.Text & "'") 'PortOfDischarge
            SQLcommand.Append(",'" & txtRemark.Text & "'") 'Remark
            SQLcommand.Append(",'" & CDbl(txtFreightPrice.Text) & "'") 'FreightPrice
            SQLcommand.Append(",'" & CDbl(txtWHTPrice.Text) & "'") 'WHTPrice
            SQLcommand.Append(",'" & CDbl(txtVatPrice.Text) & "'") 'VaTPrice
            SQLcommand.Append(",'" & CDbl(txtadvanceReceive.Text) & "'") 'advanceReceive
            SQLcommand.Append(",'" & CDbl(txtTransportDiscount.Text) & "'") 'TransportDiscount
            SQLcommand.Append(",'" & CDbl(txtTotalamount.Text) & "'") 'Totalamount
            SQLcommand.Append(",'" & CDbl(txtTotalTransport.Text) & "'") 'TotalTransport
            SQLcommand.Append(",'" & CDbl(txtReinbursecharge.Text) & "'") 'ReinburseCharge
            SQLcommand.Append(",'" & CDbl(txtadvVat.Text) & "'") 'advVat
            SQLcommand.Append(",'" & CDbl(txtNet.Text) & "'") 'Net
            SQLcommand.Append(",'" & CDbl(txtadvWHT.Text) & "'") 'advWHT
            SQLcommand.Append(",'" & CDbl(txtTotaladv.Text) & "'") 'Totaladv
            SQLcommand.Append(",'" & CDate(dtpDueDate.Value) & "'") 'DueDate
            SQLcommand.Append(",'" & CInt(txtPayable.Text) & "'") 'Payable
            SQLcommand.Append(",'" & UserProfile.U_FName & " " & UserProfile.U_LName & "'")
            SQLcommand.Append(",'" & CDbl(cboChangeTax.Text.Substring(0, cboChangeTax.Text.Length - 1)) & "'")
            SQLcommand.Append(",'" & CDbl(cboChangeVat.Text.Substring(0, cboChangeVat.Text.Length - 1)) & "'")
            SQLcommand.append(",'" & _Insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                SavePreInvDetail()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SavePreInvDetail()
        Try
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a as Integer = 0
            For row As Integer = 0 To dgvPreInv.Rows.Count - 1


                'If dgvPreInv.Rows(row).Cells(21).Value = 1 Then
                'Try
                'Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsert_PreInvDetail ")
                'SQLcommand.Append("'" & CInt(dgvPreInv.Rows(row).Cells(0).Value) & "'") 'Ident
                'SQLcommand.Append(",'" & txtPreInvoiceNo.Text & "'") 'DetailType
                'SQLcommand.Append(",'" & dgvPreInv.Rows(row).Cells(21).Value & "'") 'SICode
                'Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                'If result = 1 Then
                'Else
                'a += 1
                'End If
                'Catch ex As Exception
                'a += 1
                'MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'End Try
                'End If


                If dgvPreInv.Rows(row).Cells(21).Value = 1 Then
                    'If dgvPreInv.Rows(row).Cells(0).Value = True Then
                    '    Console.WriteLine("checkbox state is true")
                    'Else
                    '    Console.WriteLine("checkbox state is false")
                    'End If
                    'If dgvPreInv.Rows(row).Cells(0).Value = True Then
                    Try
                        Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsert_PreInvDetail ")
                        SQLcommand.Append("'" & CInt(dgvPreInv.Rows(row).Cells(0).Value) & "'") 'Ident
                        SQLcommand.Append(",'" & txtPreInvoiceNo.Text & "'") 'DetailType
                        SQLcommand.Append(",'" & dgvPreInv.Rows(row).Cells(21).Value & "'") 'SICode
                        Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                        If result = 1 Then
                        Else
                            a += 1
                        End If
                    Catch ex As Exception
                        a += 1
                        MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End Try
                    'End If
                End If






            Next
            nection.Close()
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub PreInv_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        _IsNew = True
        LoadDataCharge()
        cboChangeTax.SelectedIndex = 0
        cboChangeVat.SelectedIndex = 0

    End Sub

    Private Sub txtBCFNo_TextChanged(sender As Object, e As Eventargs) Handles txtBCFNo.TextChanged
    End Sub
    Private Sub LoadDataToDgv()
        Try
            dgvPreInv.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_HouseCharge where DocNo='" & txtBCFNo.Text & "' and active='1' and PreInvNo='" & txtPreInvoiceNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvPreInv.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
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
                           dt.Rows(i)(19).ToString(), '
                           dt.Rows(i)(20).ToString(),
                           "",
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

    Private Sub LoadDataCharge()
        Try
            dgvPreInv.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            'Dim str As String = "SELECT * FROM Freight_HouseCharge where DocNo='" & txtBCFNo.Text & "' and active='1' and ISNULL(PreInvNo,'')=''"
            'System.Console.WriteLine(str)
            'Dim str As String = "SELECT * FROM Freight_HouseCharge"
            'Dim str As String = "SELECT * FROM Freight_HouseCharge where DocNo='" & txtBCFNo.Text & "' and active='1' and PreInvNo  ''"
            Dim str As String = "SELECT * FROM Freight_HouseCharge where DocNo='" & txtBCFNo.Text & "' and active='1' and PreInvNo!=''"


            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvPreInv.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
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
                           dt.Rows(i)(19).ToString(), '
                           dt.Rows(i)(20).ToString(),
                           "",
                           "1"
                            )
                Next


                'Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                'checkBoxColumn.HeaderText = ""
                'checkBoxColumn.Width = 30
                'checkBoxColumn.Name = "checkBoxColumn"
                'dgvPreInv.Columns.Insert(0, checkBoxColumn)



                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub CalculateData()
        Try
            Dim FreightPrice As Double = txtFreightPrice.Text
            Dim WHTPrice As Double = CDbl(cboChangeTax.Text.Substring(0, cboChangeTax.Text.Length - 1))
            Dim VATPrice As Double = CDbl(cboChangeVat.Text.Substring(0, cboChangeVat.Text.Length - 1))
            Dim ReinWHTPrice As Double
            Dim ReinVATPrice As Double
            Dim FreightWHTPrice As Double
            Dim FreightVATPrice As Double
            Dim AdvanceReceive As Double = txtadvanceReceive.Text
            Dim TransportDiscount As Double = txtTransportDiscount.Text
            Dim TotalAmount As Double = txtTotalamount.Text
            Dim TotalTransport As Double = txtTotalTransport.Text
            Dim ReinburseCharge As Double = txtReinbursecharge.Text
            Dim AdvVat As Double = txtadvVat.Text
            Dim Net As Double = txtNet.Text
            Dim AdvWHT As Double = txtadvWHT.Text
            Dim TotalAdv As Double = txtTotaladv.Text
            ReinWHTPrice = (ReinburseCharge) * (WHTPrice / 100)
            ReinVATPrice = (ReinburseCharge) * (VATPrice / 100)
            FreightWHTPrice = (FreightPrice) * (WHTPrice / 100)
            FreightVATPrice = (FreightPrice) * (VATPrice / 100)
            ' txtWHTPrice.Text = (ReinWHTPrice + FreightWHTPrice).ToString("#,##0.00")
            ' txtVatPrice.Text = (ReinVATPrice + FreightVATPrice).ToString("#,##0.00")
            txtWHTPrice.Text = (FreightWHTPrice).ToString("#,##0.00")
            txtVatPrice.Text = (FreightVATPrice).ToString("#,##0.00")
            WHTPrice = txtWHTPrice.Text
            VATPrice = txtVatPrice.Text
            FreightPrice = FreightPrice + FreightVATPrice - AdvanceReceive - TransportDiscount
            'ReinburseCharge = ReinburseCharge' - ReinWHTPrice + ReinVATPrice
            TotalTransport = FreightPrice
            txtTotalTransport.Text = TotalTransport.ToString("#,##0.00")
            TotalAmount = (TotalTransport + ReinburseCharge) - WHTPrice
            Net = ReinburseCharge + AdvVat
            txtNet.Text = Net.ToString("#,##0.00")
            TotalAdv = Net - AdvWHT
            txtTotalamount.Text = TotalAmount.ToString("#,##0.00")
            txtTotaladv.Text = TotalAdv.ToString("#,##0.00")
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub Button4_Click(sender As Object, e As Eventargs) Handles Button4.Click
        CalculateData()
    End Sub
    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        Dim FreightPrice As Double = 0 'ADV
        Dim ReinburseCharge As Double = 0 'Charge
        Try
            If dgvPreInv.Rows.Count > 0 Then
                For i As Integer = 0 To dgvPreInv.Rows.Count - 2
                    If dgvPreInv.Rows(i).Cells(21).Value.ToString = "1" Then
                        If CStr(dgvPreInv.Rows(i).Cells(2).Value).Contains("S") Then
                            FreightPrice += dgvPreInv.Rows(i).Cells(11).Value '+ dgvPreInv.Rows(i).Cells(4).Value
                        ElseIf CStr(dgvPreInv.Rows(i).Cells(2).Value).Contains("A") Or CStr(dgvPreInv.Rows(i).Cells(2).Value).Contains("O") Then
                            ReinburseCharge += dgvPreInv.Rows(i).Cells(11).Value '+ dgvPreInv.Rows(i).Cells(4).Value
                        Else
                            MsgBox("CANNOT FIND ANY ROW!!!")
                        End If
                    End If
                Next
                txtFreightPrice.Text = FreightPrice.ToString()
                txtReinbursecharge.Text = ReinburseCharge.ToString()
            Else
                txtFreightPrice.Text = FreightPrice.ToString()
                txtReinbursecharge.Text = ReinburseCharge.ToString()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        'txtPreInvoiceNo.Text = frmInv.txtInvoiceNo.Text
        'frmInv.ShowDialog()
        Dim frm As New frmInv
        frm.txtNameOfImportExport.Text = txtNameOfImportExport.Text
        frm.txtHouseBLNo.Text = txtHouseBLNo.Text
        frm.txtPortOfLoading.Text = txtPortOfLoading.Text
        frm.txtPortOfDischarge.Text = txtPortOfDischarge.Text
        frm.txtCustomer.Text = txtCustomer.Text
        frm.txtCustCode.Text = txtCustCode.Text
        frm.txtCustomeraddress.Text = txtCustomeraddress.Text
        frm.txtBCFNo.Text = txtBCFNo.Text
        frm.txtPreInvoiceNo.Text = txtPreInvoiceNo.Text
        frm.txtMasterBLNo.Text = txtMasterBLNo.Text
        frm.txtVesselBooking.Text = txtVesselBooking.Text
        frm.txtTaxInvNo.Text = txtTaxInvNo.Text
        frm.ShowDialog()
    End Sub

    Private Sub cmdSearch_Click(sender as Object, e as Eventargs) Handles cmdSearch.Click
        Dim dr As DataRow
        dr = PopUpSearch("SELECT 
        [PreInvoiceNo]
        ,[PreInvoiceDate]
        ,[BCFNo]
        ,[MasterBLNo]
        ,[VesselBooking]
        ,[TaxInvNo]
        ,[TaxInvDate]
        ,[Customer]
        ,[CustomerCode]
        ,[CustomerAddress]
        ,[NameOfImportExport]
        ,[HouseBLNo]
        ,[PortOfLoading]
        ,[PortOfDischarge]
        ,[Remark]
        ,[FreightPrice]
        ,[WHTPrice]
        ,[VATPrice]
        ,[AdvanceReceive]
        ,[TransportDiscount]
        ,[TotalAmount]
        ,[TotalTransport]
        ,[ReinburseCharge]
        ,[AdvVat]
        ,[Net]
        ,[AdvWHT]
        ,[TotalAdv]
        ,[DueDate]
        ,[Payable]
        ,[Ident],[TaxPercent],[VatPercent]  FROM Freight_PreInv WHERE HouseBLNo='" & txtHouseBLNo.Text & "'", MainConnection)
        If isSearchOK Then
            txtPreInvoiceNo.Text = dr("PreInvoiceNo").ToString
            dtpPreInvoiceDate.Value = CDate(dr("PreInvoiceDate")).ToString
            txtBCFNo.Text = dr("BCFNo").ToString
            txtMasterBLNo.Text = dr("MasterBLNo").ToString
            txtVesselBooking.Text = dr("VesselBooking").ToString
            txtTaxInvNo.Text = dr("TaxInvNo").ToString
            dtpTaxInvDate.Value = CDate(dr("TaxInvDate")).ToString
            txtCustomer.Text = dr("Customer").ToString
            txtCustCode.Text = dr("CustomerCode").ToString
            txtCustomeraddress.Text = dr("CustomerAddress").ToString
            txtNameOfImportExport.Text = dr("NameOfImportExport").ToString
            txtHouseBLNo.Text = dr("HouseBLNo").ToString
            txtPortOfLoading.Text = dr("PortOfLoading").ToString
            txtPortOfDischarge.Text = dr("PortofDischarge").ToString
            txtRemark.Text = dr("Remark").ToString
            txtFreightPrice.Text = dr("FreightPrice").ToString
            txtWHTPrice.Text = dr("WHTPrice").ToString
            txtVatPrice.Text = dr("VATPrice").ToString
            txtadvanceReceive.Text = dr("AdvanceReceive").ToString
            txtTransportDiscount.Text = dr("TransportDiscount").ToString
            txtTotalamount.Text = dr("TotalAmount").ToString
            txtTotalTransport.Text = dr("TotalTransport").ToString
            txtReinbursecharge.Text = dr("ReinburseCharge").ToString
            txtadvVat.Text = dr("AdvVat").ToString
            txtNet.Text = dr("Net").ToString
            txtadvWHT.Text = dr("AdvWHT").ToString
            txtTotaladv.Text = dr("TotalAdv").ToString
            dtpDueDate.Value = CDate(dr("DueDate")).ToString
            txtPayable.Text = dr("Payable").ToString
            txtIdent.Text = dr("Ident").ToString
            cboChangeTax.Text = dr("TaxPercent").ToString & "%"
            cboChangeVat.Text = dr("VatPercent").ToString & "%"
            _IsNew = False
            LoadDataToDgv()
        End If
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        Dim url As String = "http://203.170.129.23/TESTFRIEGHT/report/PRE_INVOICE?preInvNo=" & txtPreInvoiceNo.Text & "&HBLNo=" & txtHouseBLNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub dgvPreInv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvPreInv.RowsAdded
        Try
            'dgvPreInv.Rows(e.RowIndex).Cells(21).Value = "1"
            dgvPreInv.Rows(e.RowIndex).Cells(22).Value = "1"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvPreInv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPreInv.CellContentClick

    End Sub
End Class