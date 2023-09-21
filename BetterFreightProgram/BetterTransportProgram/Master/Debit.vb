Imports System.Collections.Specialized.BitVector32
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text
Imports MetroFramework
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Logging

Public Class Debit
    Public _IsNew As Boolean
    Public _DCTYP As String
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
#Region "Validate Input"
        If String.IsNullOrEmpty(txtBCFNo.Text) Then
            txtBCFNo.Focus()
            txtBCFNo.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล BCFNo ", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtBCFNo.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtMasterBLNo.Text) Then
            txtMasterBLNo.Focus()
            txtMasterBLNo.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล MasterBLNo ", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtMasterBLNo.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVesselBooking.Text) Then
            txtVesselBooking.Focus()
            txtVesselBooking.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล VesselBooking ", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtVesselBooking.Style = MetroFramework.MetroColorStyle.Default
        End If
#End Region
        'Cal before Save
        CalculateData()

        If txtDebitNo.Text = "" Then
            If _DCTYP = "CN" Then
                GetRunningFormat("CDN")
            Else
                GetRunningFormat("ODN")
            End If

            txtDebitNo.Text = CreateNumber("Freight_OverseaDebitNote", "DebitNo", dtpDebitDate.Value)
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
            Dim SQLcommand As StringBuilder = New StringBuilder("exec [sp_lnsertOrupdateFreight_OverseaDebitNote] ")
            SQLcommand.Append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.Append(",'" & txtDebitNo.Text & "'") 'PreInvoiceNo
            SQLcommand.Append(",'" & CDate(dtpDebitDate.Value) & "'") 'PreInvoiceDate
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
            SQLcommand.Append(",'" & CDbl(txtadvanceReceive.Text) & "'") 'advanceReceive
            SQLcommand.Append(",'" & CDbl(txtTransportDiscount.Text) & "'") 'TransportDiscount
            SQLcommand.Append(",'" & CDbl(txtTotalamount.Text) & "'") 'Totalamount
            SQLcommand.Append(",'" & CDate(dtpDueDate.Value) & "'") 'DueDate
            SQLcommand.Append(",'" & CInt(txtPayable.Text) & "'") 'Payable
            SQLcommand.Append(",'" & UserProfile.U_FName & " " & UserProfile.U_LName & "'")
            SQLcommand.Append(",'" & _DCTYP & "'") '_DCTYP
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            'System.Console.WriteLine(SQLcommand.ToString())
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False

                SaveDebitNoteDetail()
                'SavePreInvDetail()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveDebitNoteDetail()
        Try
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            For row As Integer = 0 To dgvPreInv.Rows.Count - 1
                If CInt(dgvPreInv.Rows(row).Cells(0).Value) = 1 Or dgvPreInv.Rows(row).Cells(0).Value.ToString = "True" Then
                    Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_HouseDNCreate ")
                    SQLcommand.Append("'" & CInt(dgvPreInv.Rows(row).Cells(1).Value) & "'") 'Ident
                    SQLcommand.Append(",'" & dgvPreInv.Rows(row).Cells(2).Value.ToString & "'") 'QuotationDetailType
                    SQLcommand.Append(",'" & dgvPreInv.Rows(row).Cells(3).Value.ToString & "'") 'SICode
                    SQLcommand.Append(",'" & dgvPreInv.Rows(row).Cells(4).Value.ToString & "'") 'SICodeDescription
                    SQLcommand.Append(",'" & dgvPreInv.Rows(row).Cells(5).Value.ToString & "'") 'Remark
                    SQLcommand.Append(",'" & CInt(dgvPreInv.Rows(row).Cells(6).Value) & "'") 'Qty
                    SQLcommand.Append(",'" & dgvPreInv.Rows(row).Cells(7).Value.ToString & "'") 'Tys
                    SQLcommand.Append(",'" & dgvPreInv.Rows(row).Cells(8).Value.ToString & "'") 'Currency
                    SQLcommand.Append(",'" & CDbl(dgvPreInv.Rows(row).Cells(9).Value) & "'") 'ExchangeRate
                    SQLcommand.Append(",'" & CDbl(dgvPreInv.Rows(row).Cells(10).Value) & "'") 'UnitPrice
                    SQLcommand.Append(",'" & CDbl(dgvPreInv.Rows(row).Cells(11).Value) & "'") 'TotalAmount
                    SQLcommand.Append(",'" & CDbl(dgvPreInv.Rows(row).Cells(12).Value) & "'") 'VAT
                    SQLcommand.Append(",'" & CDbl(dgvPreInv.Rows(row).Cells(13).Value) & "'") 'WHT
                    SQLcommand.Append(",'" & CDbl(dgvPreInv.Rows(row).Cells(14).Value) & "'") 'TotalAmtPlusVAT
                    SQLcommand.Append(",'" & CDbl(dgvPreInv.Rows(row).Cells(15).Value) & "'") 'TotalAmtMinusWHT
                    SQLcommand.Append(",'" & CDbl(dgvPreInv.Rows(row).Cells(16).Value) & "'") 'NetPayment
                    SQLcommand.Append(",'" & dgvPreInv.Rows(row).Cells(17).Value.ToString & "'") 'QuotationNo
                    SQLcommand.Append(",'" & CInt(dgvPreInv.Rows(row).Cells(18).Value) & "'") 'Active
                    SQLcommand.Append(",'" & dgvPreInv.Rows(row).Cells(19).Value.ToString & "'") 'DocNo
                    SQLcommand.Append(",'" & txtHouseBLNo.Text & "'") 'HBLNo 20
                    SQLcommand.Append(",'" & txtMasterBLNo.Text & "'") 'MBLNo 21
                    SQLcommand.Append(",'" & txtDebitNo.Text & "'") 'DebitNo 22  
                    SQLcommand.Append(",'" & UserProfile.U_FName & " " & UserProfile.U_LName & "'")
                    SQLcommand.Append(",'" & CInt(dgvPreInv.Rows(row).Cells(23).Value) & "'")  '//Insert Or Update 23
                    Dim result1 As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result1 = 1 Then
                        '  MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If

            Next
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Debit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _IsNew = True
        LoadDataCharge()
        SetdigitHeader()
    End Sub
    Private Sub SetdigitHeader()
        SetDigit(txtFreightPrice)
        SetDigit(txtadvanceReceive)
        SetDigit(txtTransportDiscount)
        SetDigit(txtTotalamount)
    End Sub

    Private Sub LoadDataToDgv()
        Try
            dgvPreInv.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM [Freight_HouseDN] where DocNo='" & txtBCFNo.Text & "' and Active =1 and DebitNo='" & txtDebitNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    dgvPreInv.Rows.Add("1", 'check box (Alway Check Defult)
                            dt.Rows(i)(0).ToString(), 'Ident 1
                            dt.Rows(i)(1).ToString(), 'QuotationDetailType 2
                            dt.Rows(i)(2).ToString(), 'SICode 3 
                            dt.Rows(i)(3).ToString(), 'SICodeDescription 4
                            dt.Rows(i)(4).ToString(), 'Remark 5 
                            CDbl(dt.Rows(i)(5).ToString()), 'Qty 6 
                            dt.Rows(i)(6).ToString(), 'Tys 7
                            dt.Rows(i)(7).ToString(), 'Currency 8
                            CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate 9
                            CDbl(dt.Rows(i)(9).ToString()), 'UnitPrice 10 
                            CDbl(dt.Rows(i)(10).ToString()), 'Totalamount 11
                            CDbl(dt.Rows(i)(11).ToString()), 'VaT 12
                            CDbl(dt.Rows(i)(12).ToString()), 'WHT 13
                            CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT 14
                            CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT 15
                            CDbl(dt.Rows(i)(15).ToString()), 'NetPayment 16
                            dt.Rows(i)(16).ToString(), 'QuotationNo 17
                            dt.Rows(i)(17).ToString(), 'active 18
                            dt.Rows(i)(18).ToString(), 'DocNo 19
                            dt.Rows(i)(19).ToString(), 'HBL 20
                            dt.Rows(i)(20).ToString(),'MBL 21
                            dt.Rows(i)(21).ToString(),'debit 22
                            "0"'isnew false 23
                            )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
            SetdigitHeader()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub LoadDataCharge()
        Try
            dgvPreInv.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_HouseDN where DocNo='" & txtBCFNo.Text & "' and HBLNo = '" & txtHouseBLNo.Text & "' and MBLNo = '" & txtMasterBLNo.Text & "' and active='1' and ISNULL(DebitNo,'')='' "
            If _DCTYP = "CN" Then str &= "  and SICode LIKE 'OC%'"
            If _DCTYP = "DN" Then str &= "  and SICode LIKE 'OA%'"

            System.Console.WriteLine(str)
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvPreInv.Rows.Add("1", 'check box
                                       dt.Rows(i)(0).ToString(), 'Ident 1
                           dt.Rows(i)(1).ToString(), 'QuotationDetailType 2
                           dt.Rows(i)(2).ToString(), 'SICode 3 
                           dt.Rows(i)(3).ToString(), 'SICodeDescription 4
                           dt.Rows(i)(4).ToString(), 'Remark 5 
                           CDbl(dt.Rows(i)(5).ToString()), 'Qty 6 
                           dt.Rows(i)(6).ToString(), 'Tys 7
                           dt.Rows(i)(7).ToString(), 'Currency 8
                           CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate 9
                           CDbl(dt.Rows(i)(9).ToString()), 'UnitPrice 10 
                           CDbl(dt.Rows(i)(10).ToString()), 'Totalamount 11
                           CDbl(dt.Rows(i)(11).ToString()), 'VaT 12
                           CDbl(dt.Rows(i)(12).ToString()), 'WHT 13
                           CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT 14
                           CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT 15
                           CDbl(dt.Rows(i)(15).ToString()), 'NetPayment 16
                           dt.Rows(i)(16).ToString(), 'QuotationNo 17
                           dt.Rows(i)(17).ToString(), 'active 18
                           dt.Rows(i)(18).ToString(), 'DocNo 19
                           dt.Rows(i)(19).ToString(), 'HBL 20
                           dt.Rows(i)(20).ToString(),'MBL 21
                           dt.Rows(i)(21).ToString(),'debit 22
                           "0"'isnew false 23
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
    Private Sub CalculateData()
        Try
            CalDatDetail()
            Dim FreightPrice As Double = CDbl(txtFreightPrice.Text)
            Dim AdvanceReceive As Double = CDbl(txtadvanceReceive.Text)
            Dim TransportDiscount As Double = CDbl(txtTransportDiscount.Text)
            Dim TotalAmount As Double = CDbl(txtTotalamount.Text)
            TotalAmount = FreightPrice - AdvanceReceive - TransportDiscount
            txtTotalamount.Text = TotalAmount.ToString("#,##0.00")
            SetdigitHeader()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub CalDatDetail()
        Dim FreightPrice As Double = 0 'ADV
        Dim ReinburseCharge As Double = 0 'Charge
        Try
            If dgvPreInv.Rows.Count > 0 Then
                For i As Integer = 0 To dgvPreInv.Rows.Count - 1
                    If CInt(dgvPreInv.Rows(i).Cells(0).Value) = 1 Or dgvPreInv.Rows(i).Cells(0).Value.ToString = "True" Then
                        FreightPrice += dgvPreInv.Rows(i).Cells(11).Value '+ dgvPreInv.Rows(i).Cells(4).Value
                    End If
                Next
                txtFreightPrice.Text = FreightPrice.ToString("#,##0.00")
            Else
                txtFreightPrice.Text = FreightPrice.ToString("#,##0.00")
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CalculateData()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim FreightPrice As Double = 0 'ADV
        Dim ReinburseCharge As Double = 0 'Charge
        Try
            If dgvPreInv.Rows.Count > 0 Then
                For i As Integer = 0 To dgvPreInv.Rows.Count - 1
                    If CInt(dgvPreInv.Rows(i).Cells(0).Value) = 1 Or dgvPreInv.Rows(i).Cells(0).Value.ToString = "True" Then
                        FreightPrice += dgvPreInv.Rows(i).Cells(11).Value '+ dgvPreInv.Rows(i).Cells(4).Value
                    End If
                Next
                txtFreightPrice.Text = FreightPrice.ToString("#,##0.00")
            Else
                txtFreightPrice.Text = FreightPrice.ToString("#,##0.00")
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmInv
        frm.txtNameOfImportExport.Text = txtNameOfImportExport.Text
        frm.txtHouseBLNo.Text = txtHouseBLNo.Text
        frm.txtPortOfLoading.Text = txtPortOfLoading.Text
        frm.txtPortOfDischarge.Text = txtPortOfDischarge.Text
        frm.txtCustomer.Text = txtCustomer.Text
        frm.txtCustCode.Text = txtCustCode.Text
        frm.txtCustomeraddress.Text = txtCustomeraddress.Text
        frm.txtBCFNo.Text = txtBCFNo.Text
        frm.txtPreInvoiceNo.Text = txtDebitNo.Text
        frm.txtMasterBLNo.Text = txtMasterBLNo.Text
        frm.txtVesselBooking.Text = txtVesselBooking.Text
        frm.txtTaxInvNo.Text = txtTaxInvNo.Text
        frm.ShowDialog()
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Dim dr As DataRow
        Dim str As String = "SELECT   
      [DebitNo],[DebitDate],[BCFNo],[MasterBLNo],[VesselBooking],[TaxInvNo],[TaxInvDate],[Customer],[CustomerCode],[CustomerAddress]
,[NameOfImportExport],[HouseBLNo],[PortOfLoading],[PortOfDischarge],[Remark],[FreightPrice],[AdvanceReceive],[TransportDiscount],[TotalAmount],[DueDate]
,[Payable],[SysUser],[Ident] FROM Freight_OverseaDebitNote WHERE HouseBLNo='" & txtHouseBLNo.Text & "'"

        If _DCTYP = "CN" Then
            str &= " AND DCTYP='CN'"
        Else
            str &= " AND DCTYP='DN'"
        End If
        dr = PopUpSearch(str, MainConnection)
        If isSearchOK Then
            txtDebitNo.Text = dr("DebitNo").ToString
            dtpDebitDate.Value = CDate(dr("DebitDate")).ToString
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
            txtadvanceReceive.Text = dr("AdvanceReceive").ToString
            txtTransportDiscount.Text = dr("TransportDiscount").ToString
            txtTotalamount.Text = dr("TotalAmount").ToString
            dtpDueDate.Value = CDate(dr("DueDate")).ToString
            txtPayable.Text = dr("Payable").ToString
            txtIdent.Text = dr("Ident").ToString
            _IsNew = False
            LoadDataToDgv()
        End If
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click

        If _IsNew Then Exit Sub
        Dim url As String
        If _DCTYP = "CN" Then
            url = "http://203.170.129.23/TESTFRIEGHT/report/oversea_cn?DebitNo=" & txtDebitNo.Text & "&HBLNo=" & txtHouseBLNo.Text
        Else
            url = "http://203.170.129.23/TESTFRIEGHT/report/oversea_dn?DebitNo=" & txtDebitNo.Text & "&HBLNo=" & txtHouseBLNo.Text
        End If
        Try
            Process.Start("chrome.exe", url)
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub


    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click

    End Sub

    Private Sub dgvPreInv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPreInv.CellEndEdit
        Try
            CalculateData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFreightPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTransportDiscount.KeyPress, txtTotalamount.KeyPress, txtFreightPrice.KeyPress, txtadvanceReceive.KeyPress
        CheckDouble(e)
        If e.KeyChar = Chr(Keys.Enter) Then
            CalculateData()
        End If
    End Sub

    Private Sub txtFreightPrice_Leave(sender As Object, e As EventArgs) Handles txtTransportDiscount.Leave, txtTotalamount.Leave, txtFreightPrice.Leave, txtadvanceReceive.Leave
        CalculateData()
    End Sub
End Class