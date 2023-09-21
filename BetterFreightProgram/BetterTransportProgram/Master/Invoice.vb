Imports System.Collections.Specialized.BitVector32
Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Public Class Invoice
    Public _IsNew as Boolean
    Public addamount as Boolean
    Private Sub Invoice_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        'LoadDataToInvoice()
        'addNewInvoice()
        If String.IsNullOrEmpty(txtInvoiceNo.Text) Then
            _IsNew = True
        Else
            _IsNew = False
        End If
        txtInvoiceactive.Text = txtInvoiceNo.Text
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT Custaddress,CustPayable FROM [Mas_CustomerTransport] where CustCompanyID='" & txtCustCode.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                If _IsNew = True Then
                    txtCustomeraddress.Text = dr("Custaddress").ToString
                    txtPayable.Text = dr("CustPayable").ToString
                    dtpDueDate.Value = dtpDueDate.Value.addDays(CInt(dr("CustPayable")))
                End If
            End If
            ''New for Test

            ''Load for Test
            'LoadDataToInvoice()
            ''addDataToInv()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        If txtCurrentUser.Text = "" Then
            txtCurrentUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName
        End If
    End Sub
    Private Sub addDataToInv()
        'Try
        Dim amt as Double = 0 'aDV
        Dim amtSRV as Double = 0 'Charge
        Dim Vatamt as Double = 0 'advVat
        Dim Whtamt as Double = 0 'advWht
        Dim Net as Double = 0 'Net
        If dgvInvoice.Rows.Count > 0 Then
            For i as Integer = 0 To dgvInvoice.Rows.Count - 1
                If dgvInvoice.Rows(i).Cells(18).Value.ToString = "1" Then
                    If dgvInvoice.Rows(i).Cells(3).Value.ToString = "aDV" Or dgvInvoice.Rows(i).Cells(3).Value.ToString = "aTK" Then
                        amt += dgvInvoice.Rows(i).Cells(5).Value '+ dgvInvoice.Rows(i).Cells(4).Value
                        Vatamt += dgvInvoice.Rows(i).Cells(16).Value
                        Whtamt += dgvInvoice.Rows(i).Cells(17).Value
                        Net += dgvInvoice.Rows(i).Cells(4).Value
                    ElseIf dgvInvoice.Rows(i).Cells(3).Value.ToString = "CHG" Then
                        amtSRV += dgvInvoice.Rows(i).Cells(5).Value '+ dgvInvoice.Rows(i).Cells(4).Value
                    End If

                End If
            Next
            txtReinbursecharge.Text = amt.ToString("#,##0.00")
            txtSuM.Text = amtSRV.ToString("#,##0.00")
            txtadvVat.Text = Vatamt.ToString("#,##0.00")
            txtadvWHT.Text = Whtamt.ToString("#,##0.00")
            txtTotaladv.Text = Net.ToString("#,##0.00")
        Else
            txtReinbursecharge.Text = amt.ToString("#,##0.00")
            txtSuM.Text = amtSRV.ToString("#,##0.00")
            txtadvVat.Text = Vatamt.ToString("#,##0.00")
            txtadvWHT.Text = Whtamt.ToString("#,##0.00")
            txtTotaladv.Text = Net.ToString("#,##0.00")
        End If
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles cmdSave.Click
        If txtInvoiceNo.Text = "" Then
            GetRunningFormat("INVNO")
            txtInvoiceNo.Text = CreateNumber("Invoice_Header", "InvoiceNo", dtpInvoiceDate.Value)
        End If
        If txtInvoiceNo.Text = "ERROR" Then
            MsgBox("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้ กรุณารีสตาร์ทโปรแกรม")
            Exit Sub
        End If
        txtInvoiceactive.Text = txtInvoiceNo.Text
        If _IsNew = True Then
            SaveInvoice(1)
        Else
            SaveInvoice(0)
        End If
    End Sub
    Private Sub LoadDataToInvoice(Optional ByVal InvoiceNo As String = "")
        Try
            dgvInvoice.Rows.Clear()
            Dim da As OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM [Freight_PreInvDetail] where 1=1 and [PreInvNo]='" & txtPreInvoiceNo.Text & "' and active='1' " '  '" & txtInvoiceNo.Text & "'"
            'If _IsNew Then
            '    str &= " and ISNULL(InvoiceNo,'')=''"
            'Else
            '    str &= " and InvoiceNo ='" & txtInvoiceNo.Text & "'"
            'End If
            'If Not String.IsNullOrEmpty(InvoiceNo) Then str &= " aND InvoiceNo='" & InvoiceNo & "' "
            'If _IsNew Then str &= " aND Isnull(InvoiceNo,'')='' "
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvInvoice.Rows.add(dt.Rows(i)("Ident").ToString(), 'Ident
                       dt.Rows(i)("advCode").ToString(), 'advCode
                       dt.Rows(i)("advDescription").ToString(), 'advDescription
                       dt.Rows(i)("advType").ToString(), 'advType
                       dt.Rows(i)("Net").ToString(),
                       dt.Rows(i)("amount").ToString(), 'amount
                       dt.Rows(i)("RecieptNo").ToString(), 'RecieptNo
                       dt.Rows(i)("advDriver").ToString(), 'advDriver
                       dt.Rows(i)("advContainerNo").ToString(), 'advContainerNo
                       dt.Rows(i)("advStatus").ToString(), 'advStatus
                       dt.Rows(i)("OrderNo").ToString(), 'OrderNo
                       dt.Rows(i)("active").ToString(), 'active
                       dt.Rows(i)("SysUser").ToString(), 'SysUser
                       dt.Rows(i)("JobNo").ToString(), 'JobNo
                       dt.Rows(i)("InvoiceNo").ToString(), 'InvoiceNo
                       dt.Rows(i)("TaxInvNo").ToString(),  'TaxInvNo
                       dt.Rows(i)("VaTamt").ToString(),
                       dt.Rows(i)("WHTamt").ToString(),
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
    Private Sub LoadDataToInvoice()
        Try
            dgvInvoice.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_HouseCharge  where 1=1 and [PreInvNo]='" & txtPreInvoiceNo.Text & "' and active='1' "
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvInvoice.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
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
    Private Sub addNewInvoice()
        txtIdent.Text = "0" 'Ident
        txtJobNo.ResetText() 'JobNo
        txtVesselBooking.ResetText() 'VesselBooking
        txtBLNo.ResetText() 'BLNo
        txtCustomer.ResetText() 'Customer
        txtCustomeraddress.ResetText() 'Customeraddress
        'txtFactory.ResetText() 'Factory
        txtBTTLocation.ResetText() 'BTTLocation
        txtPickupLocation.ResetText() 'PickupLocation
        txtLoadingLocation.ResetText() 'LoadingLocation
        txtReturnLocation.ResetText() 'ReturnLocation
        txtTotalamount.ResetText() 'Totalamount
        txtInvoiceNo.ResetText() 'InvoiceNo
        txtTransportCharge.Text = "0.00" 'TaX
        txtReinbursement.Text = "0.00" 'VaT
        'txtInvoiceStatus.ResetText() 'InvoiceStatus
        _IsNew = True
    End Sub
    Private Sub SaveInvoice(_insert as Integer)
        MsgBox(_IsNew)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateInvoice_Header ")
            SQLcommand.append("'" & CInt(txtIdent.Text) & "'") 'Ident
            SQLcommand.append(",'" & txtInvoiceNo.Text & "'") 'InvoiceNo
            SQLcommand.append(",'" & LetDate(dtpInvoiceDate.Value) & "'") 'InvoiceDate
            SQLcommand.append(",'" & txtTaxInvNo.Text & "'") 'TaxInvNo
            SQLcommand.append(",'" & LetDate(dtpTaxInvDate.Value) & "'") 'TaxInvDate
            SQLcommand.append(",'" & txtCustomer.Text & "'") 'Customer
            SQLcommand.append(",'" & txtCustCode.Text & "'")
            SQLcommand.append(",'" & txtCustomeraddress.Text & "'") 'Customeraddress
            SQLcommand.append(",'" & txtBTTLocation.Text & "'") 'BTTLocation
            SQLcommand.append(",'" & txtPickupLocation.Text & "'") 'PickupLocation
            SQLcommand.append(",'" & txtLoadingLocation.Text & "'") 'LoadingLocation
            SQLcommand.append(",'" & txtReturnLocation.Text & "'") 'ReturnLocation
            SQLcommand.append(",'" & txtJobNo.Text & "'") 'JobNo
            SQLcommand.append(",'" & txtVesselBooking.Text & "'") 'VesselBooking
            SQLcommand.append(",'" & txtBLNo.Text & "'") 'BLNo
            SQLcommand.append(",'" & CDbl(txtTransportCharge.Text) & "'") 'TransportCharge
            SQLcommand.append(",'" & CDbl(txtReinbursement.Text) & "'") 'Reinbursement
            SQLcommand.append(",'" & CDbl(txtTotalamount.Text) & "'") 'Totalamount
            SQLcommand.append(",'" & txtCurrentUser.Text & "'") 'CurrentUser
            SQLcommand.append(",'" & txtactive.Text & "'") 'active
            SQLcommand.append(",'" & CDbl(txtSuM.Text) & "'")
            SQLcommand.append(",'" & CDbl(txtReinbursecharge.Text) & "'")
            SQLcommand.append(",'" & cboChangeTax.Text & "'")
            SQLcommand.append(",'" & cboChangeVat.Text & "'")
            SQLcommand.append(",'" & txtadvanceRecieve.Text & "'")
            SQLcommand.append(",'" & txtTransportDiscount.Text & "'")
            SQLcommand.append(",'" & LetDate(dtpDueDate.Text) & "'")
            SQLcommand.append(",'" & CInt(txtPayable.Text) & "'")
            SQLcommand.append(",'" & txtRemark.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)

            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SaveInvoiceDetail()
                txtactive.Text = "1"
                _IsNew = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        'Try

        '    Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateInvoice ")
        '    SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
        '    SQLcommand.append(",'" & txtJobNo.Text & "'") 'JobNo
        '    SQLcommand.append(",'" & txtVesselBooking.Text & "'") 'VesselBooking
        '    SQLcommand.append(",'" & txtBLNo.Text & "'") 'BLNo
        '    SQLcommand.append(",'" & txtCustomer.Text & "'") 'Customer
        '    SQLcommand.append(",'" & txtCustomeraddress.Text & "'") 'Customeraddress
        '    'SQLcommand.append(",'" & txtFactory.Text & "'") 'Factory
        '    SQLcommand.append(",'" & txtBTTLocation.Text & "'") 'BTTLocation
        '    SQLcommand.append(",'" & txtPickupLocation.Text & "'") 'PickupLocation
        '    SQLcommand.append(",'" & txtLoadingLocation.Text & "'") 'LoadingLocation
        '    SQLcommand.append(",'" & txtReturnLocation.Text & "'") 'ReturnLocation
        '    SQLcommand.append(",'" & txtTotalamount.Text & "'") 'Totalamount
        '    SQLcommand.append(",'" & txtInvoiceNo.Text & "'") 'InvoiceNo
        '    SQLcommand.append(",'" & txtTaX.Text & "'") 'TaX
        '    SQLcommand.append(",'" & txtVaT.Text & "'") 'VaT
        '    'SQLcommand.append(",'" & txtInvoiceStatus.Text & "'") 'InvoiceStatus
        '    SQLcommand.append(",'" & txtSysUser.Text & "'")
        '    SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
        '    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
        '    If result = 1 Then
        '        MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        _IsNew = False
        '    Else
        '        MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    End If
        '    nection.Close()
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub SaveInvoiceDetail()
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a as Integer = 0
            For row as Integer = 0 To dgvInvoice.Rows.Count - 1
                If dgvInvoice.Rows(row).Cells(18).Value.ToString = "1" Then
                    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_CreateInvoiceDetail ")
                    SQLcommand.append("'" & CInt(dgvInvoice.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.append(",'" & dgvInvoice.Rows(row).Cells(3).Value.ToString & "'") 'aDVType
                    SQLcommand.append(",'" & txtInvoiceNo.Text & "'") 'InvoiceNo
                    SQLcommand.append(",'" & dgvInvoice.Rows(row).Cells(18).Value.ToString & "'")
                    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
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
            txtInvoiceactive.Text = txtInvoiceNo.Text
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles cmdPrint.Click
        'If txtChangeType.Text = "ต้นฉบับ" Then
        'Dim url As String = "http://203.170.129.23/TESTFRIEGHT/report/INVOICE?preInvNo=" & txtPreInvoiceNo.Text & "&INVNo=" & txtInvoiceNo.Text & "&HBLNO=" & txt
        'Try
        '        Process.Start("chrome.exe", url)
        '    Catch ex as Exception
        '        Process.Start(url)
        '    End Try
        'Else
        '    Dim url as String = "http://203.170.129.23/transport/report/InvoiceTypeTwo?invno=" & txtInvoiceNo.Text & "&JobNo=" & txtJobNo.Text
        '    Try
        '        Process.Start("chrome.exe", url)
        '    Catch ex as Exception
        '        Process.Start(url)
        '    End Try
        'End If
    End Sub

    Private Sub GroupBox3_Enter(sender as Object, e as Eventargs) Handles GroupBox3.Enter
    End Sub
    Private Sub cmdSearch_Click(sender as Object, e as Eventargs) Handles cmdSearch.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT * FROM [Invoice_Header] WHERE 1=1 order by [InvoiceNo] desc ", MainConnection)
        If isSearchOK Then
            txtInvoiceNo.Text = dr("InvoiceNo").ToString
            LoadInvoiceHeader()
            'addDataToInv()

        End If
    End Sub
    Private Sub LoadInvoiceHeader()
        Try
            Dim str as String = "SELECT * FROM Invoice_Header where InvoiceNo='" & txtInvoiceNo.Text & "' "
            Dim dr as DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                txtIdent.Text = CInt(dr("Ident").ToString()) 'Ident
                txtInvoiceNo.Text = dr("InvoiceNo").ToString 'InvoiceNo
                dtpInvoiceDate.Value = CDate(dr("InvoiceDate").ToString) 'InvoiceDate
                txtTaxInvNo.Text = dr("TaxInvNo").ToString 'TaxInvNo
                dtpTaxInvDate.Value = CDate(dr("TaxInvDate").ToString) 'TaxInvDate
                txtCustomer.Text = dr("Customer").ToString 'Customer
                txtCustCode.Text = dr("CustomerCode").ToString 'CustomerCode
                txtCustomeraddress.Text = dr("Customeraddress").ToString 'Customeraddress
                txtBTTLocation.Text = dr("BTTLocation").ToString 'BTTLocation
                txtPickupLocation.Text = dr("PickupLocation").ToString 'PickupLocation
                txtLoadingLocation.Text = dr("LoadingLocation").ToString 'LoadingLocation
                txtReturnLocation.Text = dr("ReturnLocation").ToString 'ReturnLocation
                txtJobNo.Text = dr("JobNo").ToString 'JobNo
                txtVesselBooking.Text = dr("VesselBooking").ToString 'VesselBooking
                txtBLNo.Text = dr("BLNo").ToString 'BLNo
                txtTransportCharge.Text = dr("TransportCharge").ToString 'TransportCharge
                txtReinbursement.Text = dr("Reinbursement").ToString 'Reinbursement
                txtTotalamount.Text = dr("Totalamount").ToString 'Totalamount
                txtCurrentUser.Text = dr("CurrentUser").ToString 'CurrentUser
                'txtCreateDate.Text = dr("CreateDate").ToString 'CreateDate
                'txtCreateTime.Text = dr("CreateTime").ToString 'CreateTime
                'txtCancelBy.Text = dr("CancelBy").ToString 'CancelBy
                'txtCancelDate.Text = dr("CancelDate").ToString 'CancelDate
                'txtCancelTime.Text = dr("CancelTime").ToString 'CancelTime
                'txtCancelRemark.Text = dr("CancelRemark").ToString 'CancelRemark
                txtactive.Text = CInt(dr("active").ToString()) 'active
                dtpDueDate.Value = CDate(dr("DueDate").ToString)
                txtPayable.Text = CInt(dr("Payable").ToString)
                txtRemark.Text = dr("Remark").ToString
                LoadDataToInvoice()
                _IsNew = False
            End If
            da = Nothing

        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error : " & ex.Message, "รายงานผล", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    Private Sub cmdNew_Click(sender as Object, e as Eventargs) Handles cmdNew.Click
        _IsNew = True
        LoadDataToInvoice()

    End Sub

    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        'LoadDataToInvoice()
        'addNewInvoice()
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT Custaddress FROM [Mas_CustomerTransport] where CustCompanyID='" & txtCustCode.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtCustomeraddress.Text = dr("Custaddress").ToString
            End If
            'New for Test
            _IsNew = True
            'Load for Test
            LoadDataToInvoice()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        If txtCurrentUser.Text = "" Then
            txtCurrentUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName
        End If
    End Sub

    Private Sub cboChangeTax_TextChanged(sender as Object, e as Eventargs) Handles cboChangeTax.TextChanged
        If cboChangeTax.Text = "1%" Then
            txtChangeTax.Text = "1"
        ElseIf cboChangeTax.Text = "2%" Then
            txtChangeTax.Text = "2"
        ElseIf cboChangeTax.Text = "3%" Then
            txtChangeTax.Text = "3"
        ElseIf cboChangeTax.Text = "5%" Then
            txtChangeTax.Text = "5"
        ElseIf cboChangeTax.Text = "7%" Then
            txtChangeTax.Text = "7"
        ElseIf cboChangeTax.Text = "10%" Then
            txtChangeTax.Text = "10"
        ElseIf cboChangeTax.Text = "0%" Then
            txtChangeTax.Text = "0"
        End If
    End Sub

    Private Sub cboChangeVat_TextChanged(sender as Object, e as Eventargs) Handles cboChangeVat.TextChanged
        If cboChangeVat.Text = "1%" Then
            txtReinbursement.Text = "1"
        ElseIf cboChangeVat.Text = "2%" Then
            txtReinbursement.Text = "2"
        ElseIf cboChangeVat.Text = "3%" Then
            txtReinbursement.Text = "3"
        ElseIf cboChangeVat.Text = "5%" Then
            txtReinbursement.Text = "5"
        ElseIf cboChangeVat.Text = "10%" Then
            txtReinbursement.Text = "10"
        ElseIf cboChangeVat.Text = "0%" Then
            txtReinbursement.Text = "0"
        End If
    End Sub

    Private Sub txtSuM_TextChanged(sender as Object, e as Eventargs) Handles txtSuM.TextChanged
        'Dim TransCharge as Integer
        'TransCharge = txtTransportCharge.Text / "100"
        'MsgBox(TransCharge)
    End Sub

    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click
        If addamount = True Then
            Dim a as Double
            Dim b as Double
            Dim c as Double
            Dim d as Double
            Dim ed as Double
            Dim f as Double
            Dim g as Double
            Dim Vatadv as Double
            Dim WHTadv as Double
            Dim Net as Double
            Dim Totaladv as Double
            a = txtSuM.Text
            b = txtChangeTax.Text
            d = txtReinbursecharge.Text
            ed = txtadvanceRecieve.Text
            f = txtTransportDiscount.Text
            Vatadv = txtadvVat.Text
            WHTadv = txtadvWHT.Text
            Net = txtNet.Text
            Totaladv = txtTotaladv.Text
            txtNet.Text = d + Vatadv
            c = a - ((b / CDbl("100")) * a)
            txtTransportCharge.Text = CDbl(b / CDbl("100") * a)
            txtTotalTransport.Text = c
            g = c + Totaladv - f
            'g = c + d - ed - f
            txtTotalamount.Text = g.ToString("0.00,#,##")
            MsgBox(g)
            '*************************************************************************************
            'OLD:
            'Dim TransCharge as Double
            'Dim Vat as Double
            'Dim value as Double = "100"
            'TransCharge = (CDbl(txtTransportCharge.Text) / value)
            'txtTax.Text = (txtSuM.Text * TransCharge)
            'txtTotalTransport.Text = (CDbl(txtSuM.Text) - CDbl(txtTax.Text))
            'txtTotalamount.Text = (CDbl(txtReinbursecharge.Text) + CDbl(txtTotalTransport.Text))
            '*************************************************************************************
        End If
        '''''''''''''''''''''''''''''''''''''Dim TransCharge as Double
        '''''''''''''''''''''''''''''''''''''Dim Vat as Double
        '''''''''''''''''''''''''''''''''''''Dim value as Double = "100"
        '''''''''''''''''''''''''''''''''''''TransCharge = (CDbl(txtTransportCharge.Text) / value)
        '''''''''''''''''''''''''''''''''''''txtTax.Text = (TransCharge * txtSuM.Text)
        '''''''''''''''''''''''''''''''''''''Vat = (CDbl(txtReinbursement.Text) / value)
        '''''''''''''''''''''''''''''''''''''txtTotalTransport.Text = (CDbl(txtTransportCharge.Text) - CDbl(txtTransportCharge.Text))
        '''''''''''''''''''''''''''''''''''''txtTotalamount.Text = (txtSuM.Text + Vat - txtTransportCharge.Text + txtReinbursecharge.Text)
        '''''''''''''''''''''''''''''''''''''addamount = False
        '''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub Button5_Click_1(sender as Object, e as Eventargs) Handles Button5.Click
        addDataToInv()
        addamount = True
    End Sub

    Private Sub Button2_Click_1(sender as Object, e as Eventargs) Handles Button2.Click
        txtInvoiceactive.Text = ""
        SaveInvoiceDetail()
    End Sub

    Private Sub GroupBox2_Enter(sender as Object, e as Eventargs) Handles GroupBox2.Enter

    End Sub

    Private Sub dgvInvoice_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        txtInvoiceactive.Text = dgvInvoice.CurrentRow.Cells(13).Value.ToString
    End Sub

    Private Sub txtCustCode_TextChanged(sender as Object, e as Eventargs) Handles txtCustCode.TextChanged

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
End Class