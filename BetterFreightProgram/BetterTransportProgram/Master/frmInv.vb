Imports System.Collections.Specialized.BitVector32
Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Text

Public Class frmInv
    Public _IsNew As Boolean
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtInvoiceNo.Text = "" Then
            GetRunningFormat("INVNO")
            txtInvoiceNo.Text = CreateNumber("Freight_Invoice", "InvoiceNo", dtpInvoiceDate.Value)
        End If
        If _IsNew = True Then
            SaveInvoice(1)
        Else
            SaveInvoice(0)
        End If
    End Sub
    Private Sub SaveInvoice(_Insert As Integer)
        Try

            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_Invoice ")
            SQLcommand.Append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.Append(",'" & txtInvoiceNo.Text & "'") 'InvoiceNo
            SQLcommand.Append(",'" & CDate(dtpInvoiceDate.Value) & "'") 'InvoiceDate
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
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                SaveInvDetail()
                LoadDataToInvoiceHeader()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveInvDetail()
        Try
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a As Integer = 0
            For row As Integer = 0 To dgvInv.Rows.Count - 2
                If dgvInv.Rows(row).Cells(21).Value = 1 Then
                    Try
                        Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsert_InvDetail ")
                        SQLcommand.Append("'" & CInt(dgvInv.Rows(row).Cells(0).Value) & "'") 'Ident
                        SQLcommand.Append(",'" & txtInvoiceNo.Text & "'") 'DetailType
                        SQLcommand.Append(",'" & dgvInv.Rows(row).Cells(21).Value & "'") 'SICode
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
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToInvoiceHeader()
        Try
            Dim str As String = "SELECT * FROM Freight_Invoice where 1=1 and InvoiceNo='" & txtInvoiceNo.Text & "'"
            Dim dr As DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                txtIdent.Text = CInt(dr("Ident").ToString()) 'Ident
                txtInvoiceNo.Text = dr("InvoiceNo").ToString 'InvoiceNo
                dtpInvoiceDate.Value = CDate(dr("InvoiceDate").ToString) 'InvoiceDate
                txtBCFNo.Text = dr("BCFNo").ToString 'BCFNo
                txtMasterBLNo.Text = dr("MasterBLNo").ToString 'MasterBLNo
                txtVesselBooking.Text = dr("VesselBooking").ToString 'VesselBooking
                txtTaxInvNo.Text = dr("TaxInvNo").ToString 'TaxInvNo
                dtpTaxInvDate.Value = CDate(dr("TaxInvDate").ToString) 'TaxInvDate
                txtCustomer.Text = dr("Customer").ToString 'Customer
                txtCustCode.Text = dr("CustomerCode").ToString 'CustomerCode
                txtCustomeraddress.Text = dr("CustomerAddress").ToString 'CustomerAddress
                txtNameOfImportExport.Text = dr("NameOfImportExport").ToString 'NameOfImportExport
                txtHouseBLNo.Text = dr("HouseBLNo").ToString 'HouseBLNo
                txtPortOfLoading.Text = dr("PortOfLoading").ToString 'PortOfLoading
                txtPortOfDischarge.Text = dr("PortOfDischarge").ToString 'PortOfDischarge
                txtRemark.Text = dr("Remark").ToString 'Remark
                txtFreightPrice.Text = dr("FreightPrice").ToString 'FreightPrice
                txtWHTPrice.Text = dr("WHTPrice").ToString 'WHTPrice
                txtVatPrice.Text = dr("VATPrice").ToString 'VATPrice
                txtadvanceReceive.Text = dr("AdvanceReceive").ToString 'AdvanceReceive
                txtTransportDiscount.Text = dr("TransportDiscount").ToString 'TransportDiscount
                txtTotalamount.Text = dr("TotalAmount").ToString 'TotalAmount
                txtTotalTransport.Text = dr("TotalTransport").ToString 'TotalTransport
                txtReinbursecharge.Text = dr("ServiceCharge").ToString 'ServiceCharge
                txtadvVat.Text = dr("AdvVat").ToString 'AdvVat
                txtNet.Text = dr("Net").ToString 'Net
                txtadvWHT.Text = dr("AdvWHT").ToString 'AdvWHT
                txtTotaladv.Text = dr("TotalAdv").ToString 'TotalAdv
                dtpDueDate.Value = CDate(dr("DueDate").ToString) 'DueDate
                txtPayable.Text = CInt(dr("Payable").ToString()) 'Payable
                LoadDataToInvoiceDetail()
            End If
            'da = Nothing
            'dt = Nothing
            'nection.Close()

        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error : " & ex.Message, "รายงานผล", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToInvoice()
        Try
            dgvInv.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_HouseCharge  where 1=1 and [PreInvNo]='" & txtPreInvoiceNo.Text & "' and active='1' and ISNULL(InvoiceNo,'')=''"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvInv.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
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
                           dt.Rows(i)(21).ToString(), '
                           dt.Rows(i)(22).ToString()
                           )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()

                _IsNew = True
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        'Try
        '    dgvInv.Rows.Clear()
        '    Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
        '    Dim dt as DataTable = New DataTable()
        '    Dim nection as New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim str as String = "SELECT * FROM Freight_HouseCharge where DocNo='" & txtBCFNo.Text & "' and active='1' and ISNULL(PreInvNo,'')=''"
        '    da.SelectCommand = New OleDbCommand(str, nection)
        '    da.Fill(dt)
        '    If dt.Rows.Count > 0 Then
        '        For i as Integer = 0 To dt.Rows.Count - 1
        '            dgvInv.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
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
        '                   dt.Rows(i)(21).ToString(), '
        '                   dt.Rows(i)(22).ToString()
        '                   )
        '        Next
        '        da = Nothing
        '        dt = Nothing
        '        nection.Close()
        '    End If
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub LoadDataToInvoiceDetail()
        Try
            dgvInv.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_HouseCharge  where 1=1 and [InvoiceNo]='" & txtInvoiceNo.Text & "' and active='1' and PreInvNo='" & txtPreInvoiceNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvInv.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
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
                           dt.Rows(i)(21).ToString(), '
                           dt.Rows(i)(22).ToString()
                           )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()

                _IsNew = True
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub frmInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _IsNew = True
    End Sub

    Private Sub txtInvoiceNo_TextChanged(sender As Object, e As EventArgs) Handles txtInvoiceNo.TextChanged
        LoadDataToInvoice()
    End Sub

    Private Sub txtPreInvoiceNo_ButtonClick(sender As Object, e As EventArgs) Handles txtPreInvoiceNo.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT [PreInvoiceNo],[PreInvoiceDate],[BCFNo],[MasterBLNo],[VesselBooking] FROM [Freight_PreInv] WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtPreInvoiceNo.Text = dr("PreInvoiceNo").ToString
                LoadDataToInvoice()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPreInvoiceNo_TextChanged(sender As Object, e As EventArgs) Handles txtPreInvoiceNo.TextChanged
        LoadDataToInvoice()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        AddDataToInv()
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
            'Dim FreightPrice As Double = txtFreightPrice.Text
            'Dim WHTPrice As Double = CDbl(cboChangeTax.Text.Substring(0, cboChangeTax.Text.Length - 1))
            'Dim VATPrice As Double = CDbl(cboChangeVat.Text.Substring(0, cboChangeVat.Text.Length - 1))
            'Dim ReinWHTPrice As Double
            'Dim ReinVATPrice As Double
            'Dim FreightWHTPrice As Double
            'Dim FreightVATPrice As Double
            'Dim AdvanceReceive As Double = txtadvanceReceive.Text
            'Dim TransportDiscount As Double = txtTransportDiscount.Text
            'Dim TotalAmount As Double = txtTotalamount.Text
            'Dim TotalTransport As Double = txtTotalTransport.Text
            'Dim ReinburseCharge As Double = txtReinbursecharge.Text
            'Dim AdvVat As Double = txtadvVat.Text
            'Dim Net As Double = txtNet.Text
            'Dim AdvWHT As Double = txtadvWHT.Text
            'Dim TotalAdv As Double = txtTotaladv.Text
            'ReinWHTPrice = (ReinburseCharge) * (WHTPrice / 100)
            'ReinVATPrice = (ReinburseCharge) * (VATPrice / 100)
            'FreightWHTPrice = (FreightPrice) * (WHTPrice / 100)
            'FreightVATPrice = (FreightPrice) * (VATPrice / 100)
            'txtWHTPrice.Text = (ReinWHTPrice + FreightWHTPrice).ToString("#,##0.00")
            'txtVatPrice.Text = (ReinVATPrice + FreightVATPrice).ToString("#,##0.00")
            'WHTPrice = txtWHTPrice.Text
            'VATPrice = txtVatPrice.Text
            'FreightPrice = FreightPrice - FreightWHTPrice + FreightVATPrice
            'ReinburseCharge = ReinburseCharge - ReinWHTPrice + ReinVATPrice
            'TotalTransport = FreightPrice - AdvanceReceive - TransportDiscount
            'TotalAdv = TotalTransport + ReinburseCharge
            'txtTotaladv.Text = TotalAdv.ToString("#,##0.00")
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        'Dim FreightPrice As Double
        'Dim WHTPrice As Double
        'Dim VatPrice As Double
        'Dim AdvanceReceive As Double
        'Dim TransportDiscount As Double
        'Dim TotalAmount As Double
        'Dim TotalTransport As Double
        'Dim ReinburseCharge As Double
        'Dim AdvVat As Double
        'Dim Net As Double
        'Dim AdvWHT As Double
        'Dim TotalAdv As Double
        'FreightPrice = txtFreightPrice.Text
        'WHTPrice = txtWHTPrice.Text
        'VatPrice = txtVatPrice.Text
        'AdvanceReceive = txtadvanceReceive.Text
        'TransportDiscount = txtTransportDiscount.Text
        'TotalAmount = txtTotalamount.Text
        'TotalTransport = txtTotalTransport.Text
        'ReinburseCharge = txtReinbursecharge.Text
        'AdvVat = txtadvVat.Text
        'Net = txtNet.Text
        'AdvWHT = txtadvWHT.Text
        'TotalAdv = txtTotaladv.Text
        'WHTPrice = FreightPrice * (WHTPrice / 100)
        'VatPrice = FreightPrice * (VatPrice / 100)
        'txtWHTPrice.Text = WHTPrice
        'txtVatPrice.Text = VatPrice

    End Sub

    Private Sub AddDataToInv()
        Try
            Dim amt As Double = 0 'aDV
            Dim amtSRV As Double = 0 'Charge
            Dim Vatamt As Double = 0 'advVat
            Dim Whtamt As Double = 0 'advWht
            Dim Net As Double = 0 'Net
            If dgvInv.Rows.Count > 0 Then
                For i As Integer = 0 To dgvInv.Rows.Count - 2
                    If dgvInv.Rows(i).Cells(21).Value.ToString = "1" Then
                        If dgvInv.Rows(i).Cells(2).Value.ToString.Contains("ADV") Or dgvInv.Rows(i).Cells(2).Value.ToString.Contains("OA") Then
                            amt += dgvInv.Rows(i).Cells(11).Value '+ dgvInvoice.Rows(i).Cells(4).Value
                            'Vatamt += dgvInv.Rows(i).Cells(16).Value
                            'Whtamt += dgvInv.Rows(i).Cells(17).Value
                            'Net += dgvInv.Rows(i).Cells(4).Value
                        ElseIf dgvInv.Rows(i).Cells(2).Value.ToString.Contains("SVP") Or dgvInv.Rows(i).Cells(2).Value.ToString.Contains("SVF") Or dgvInv.Rows(i).Cells(2).Value.ToString.Contains("SRV") Or dgvInv.Rows(i).Cells(2).Value.ToString.Contains("STK") Then
                            amtSRV += dgvInv.Rows(i).Cells(11).Value '+ dgvInvoice.Rows(i).Cells(4).Value
                        End If
                    End If
                Next
                txtReinbursecharge.Text = amt.ToString("#,##0.00")
                txtFreightPrice.Text = amtSRV.ToString("#,##0.00")
                txtadvVat.Text = Vatamt.ToString("#,##0.00")
                txtadvWHT.Text = Whtamt.ToString("#,##0.00")
                txtTotaladv.Text = Net.ToString("#,##0.00")
            Else
                txtReinbursecharge.Text = amt.ToString("#,##0.00")
                txtFreightPrice.Text = amtSRV.ToString("#,##0.00")
                txtadvVat.Text = Vatamt.ToString("#,##0.00")
                txtadvWHT.Text = Whtamt.ToString("#,##0.00")
                txtTotaladv.Text = Net.ToString("#,##0.00")
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CalculateData()
    End Sub

    Private Sub cboChangeTax_TextChanged(sender As Object, e As EventArgs) Handles cboChangeTax.TextChanged
        If cboChangeTax.Text = "1%" Then
            txtWHTPrice.Text = "1"
        ElseIf cboChangeTax.Text = "2%" Then
            txtWHTPrice.Text = "2"
        ElseIf cboChangeTax.Text = "3%" Then
            txtWHTPrice.Text = "3"
        ElseIf cboChangeTax.Text = "5%" Then
            txtWHTPrice.Text = "5"
        ElseIf cboChangeTax.Text = "7%" Then
            txtWHTPrice.Text = "7"
        ElseIf cboChangeTax.Text = "10%" Then
            txtWHTPrice.Text = "10"
        ElseIf cboChangeTax.Text = "0%" Then
            txtWHTPrice.Text = "0"
        End If
    End Sub

    Private Sub cboChangeVat_TextChanged(sender As Object, e As EventArgs) Handles cboChangeVat.TextChanged
        If cboChangeVat.Text = "1%" Then
            txtVatPrice.Text = "1"
        ElseIf cboChangeVat.Text = "2%" Then
            txtVatPrice.Text = "2"
        ElseIf cboChangeVat.Text = "3%" Then
            txtVatPrice.Text = "3"
        ElseIf cboChangeVat.Text = "5%" Then
            txtVatPrice.Text = "5"
        ElseIf cboChangeVat.Text = "7%" Then
            txtVatPrice.Text = "7"
        ElseIf cboChangeVat.Text = "10%" Then
            txtVatPrice.Text = "10"
        ElseIf cboChangeVat.Text = "0%" Then
            txtVatPrice.Text = "0"
        End If
    End Sub

    Private Sub dgvInv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvInv.RowsAdded
        dgvInv.Rows(e.RowIndex).Cells(21).Value = "1"
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        Dim url As String = "http://203.170.129.23/TESTFRIEGHT/report/INVOICE?preInvNo=" & txtPreInvoiceNo.Text & "&INVNo=" & txtInvoiceNo.Text & "&HBLNO=" & txtHouseBLNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click

    End Sub
End Class