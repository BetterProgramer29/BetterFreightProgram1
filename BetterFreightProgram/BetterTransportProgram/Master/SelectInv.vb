Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Text
Imports System.Xml.Serialization

Public Class SelectInv
    Public _IsNew as Boolean = True
    Public Selected as Boolean = True
    Private Sub Button5_Click(sender as Object, e as Eventargs)

    End Sub

    Private Sub Button4_Click(sender as Object, e as Eventargs)

    End Sub

    Private Sub cmdSave_Click(sender as Object, e as Eventargs) Handles cmdSave.Click
        If txtSoaCode.Text = "" Then
            GetRunningFormat("SOa")
            txtSoaCode.Text = CreateNumber("SOa_Header", "SoaCode", txtSoaDate.Value)
        End If
        If txtSoaCode.Text = "ERROR" Then
            MsgBox("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้ กรุณารีสตาร์ทโปรแกรม")
            Exit Sub
        End If
        If _IsNew = True Then
            SaveSoa(1)
        Else
            SaveSoa(0)
        End If
    End Sub
    Private Sub SaveSoa(_insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateSOa_Header ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtSoaCode.Text & "'") 'SoaCode
            SQLcommand.append(",'" & LetDate(txtSoaDate.Text) & "'") 'SoaDate
            SQLcommand.append(",'" & txtCustomerName.Text & "'") 'CustomerName
            SQLcommand.append(",'" & txtCustomerCode.Text & "'") 'CustomerCode
            SQLcommand.append(",'" & txtSoaRemark.Text & "'") 'SoaRemark
            SQLcommand.append(",'" & LetDate(txtPaymentDue.Text) & "'") 'PaymentDue
            SQLcommand.append(",'" & txtReceivedBy.Text & "'") 'ReceivedBy
            SQLcommand.append(",'" & LetDate(txtConfirmDate.Text) & "'") 'ConfirmDate
            SQLcommand.append(",'" & CDbl(txtadvanceamount.Text) & "'") 'advanceamount
            SQLcommand.append(",'" & CDbl(txtCustomeradv.Text) & "'") 'Customeradv
            SQLcommand.append(",'" & CDbl(txtServiceNonVat.Text) & "'") 'ServiceNonVat
            SQLcommand.append(",'" & CDbl(txtServiceVat.Text) & "'") 'ServiceVat
            SQLcommand.append(",'" & CDbl(txtTotalVat.Text) & "'") 'TotalVat
            SQLcommand.append(",'" & CDbl(txtWHT.Text) & "'") 'WHT
            SQLcommand.append(",'" & CDbl(txtNet.Text) & "'") 'Net
            SQLcommand.append(",'" & txtactive.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveSoaDetail()
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a as Integer = 0
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_CreateSoaDetail ")
            SQLcommand.append("'" & CInt(txtIdentD.Text) & "'") 'Ident
                SQLcommand.append(",'" & txtSoaCode.Text & "'")
                SQLcommand.append(",'" & txtactive.Text & "'")
                Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
            Else
                a += 1
            End If
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()

        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub addDataToInv()
        Dim amt as Double = 0 'aDV
        Dim amtSRV as Double = 0 'Charge
        Dim Totalamt as Double = 0
        If dgvInvoice.Rows.Count > 0 Then
            For i as Integer = 0 To dgvInvoice.Rows.Count - 1
                If dgvInvoice.Rows(i).Cells(25).Value = "1" Then
                    amtSRV += dgvInvoice.Rows(i).Cells(20).Value '+ dgvInvoice.Rows(i).Cells(4).Value
                    amt += dgvInvoice.Rows(i).Cells(21).Value '+ dgvInvoice.Rows(i).Cells(4).Value
                    Totalamt += dgvInvoice.Rows(i).Cells(17).Value
                End If
            Next
            txtadvanceamount.Text = amt.ToString("#,##0.00")
            txtServiceVat.Text = amtSRV.ToString("#,##0.00")
            txtNet.Text = Totalamt.ToString("#,##0.00")
        Else
            txtadvanceamount.Text = amt.ToString("#,##0.00")
            txtServiceVat.Text = amtSRV.ToString("#,##0.00")
            txtNet.Text = Totalamt.ToString("#,##0.00")
        End If
        'txtNet.Text = (CDbl(txtadvanceamount.Text) + CDbl(txtServiceVat.Text))
    End Sub
    Private Sub LoadDataToInvoice(Optional ByVal InvoiceNo as String = "")
        'Try
        '    dgvInvoice.Rows.Clear()
        '    Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
        '    Dim dt as DataTable = New DataTable()
        '    Dim nection as New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim str as String = "SELECT * FROM PRE_Invoice where JobNo='" & txtJobNo.Text & "' and active='1'"
        '    If Not String.IsNullOrEmpty(InvoiceNo) Then str &= " aND InvoiceNo='" & InvoiceNo & "' "
        '    If _IsNew Then str &= " aND Isnull(InvoiceNo,'')='' "
        '    da.SelectCommand = New OleDbCommand(str, nection)
        '    da.Fill(dt)
        '    If dt.Rows.Count > 0 Then
        '        For i as Integer = 0 To dt.Rows.Count - 1
        '            dgvInvoice.Rows.add(dt.Rows(i)("Ident").ToString(), 'Ident
        '               dt.Rows(i)("advCode").ToString(), 'advCode
        '               dt.Rows(i)("advDescription").ToString(), 'advDescription
        '               dt.Rows(i)("advType").ToString(), 'advType
        '               dt.Rows(i)("amount").ToString(), 'amount
        '               dt.Rows(i)("RecieptNo").ToString(), 'RecieptNo
        '               dt.Rows(i)("advDriver").ToString(), 'advDriver
        '               dt.Rows(i)("advContainerNo").ToString(), 'advContainerNo
        '               dt.Rows(i)("advStatus").ToString(), 'advStatus
        '               dt.Rows(i)("OrderNo").ToString(), 'OrderNo
        '               dt.Rows(i)("active").ToString(), 'active
        '               dt.Rows(i)("SysUser").ToString(), 'SysUser
        '               dt.Rows(i)("JobNo").ToString(), 'JobNo
        '               dt.Rows(i)("InvoiceNo").ToString(), 'InvoiceNo
        '               dt.Rows(i)("TaxInvNo").ToString()  'TaxInvNo
        '                )
        '        Next
        '        da = Nothing
        '        dt = Nothing
        '        nection.Close()
        '    End If
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try


    End Sub

    Private Sub SOa_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        LoadDataToInvoice()
        addNewData()
        If txtSoaCode.Text = "" Then
            GetRunningFormat("SOa")
            txtSoaCode.Text = CreateNumber("SOa_Header", "SoaCode", txtSoaDate.Value)
        End If
    End Sub

    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        txtactive.Text = "0"
        SaveSoa(0)
    End Sub
    Private Sub addNewData()
        txtIdent.Text = "0" 'Ident
        txtSoaCode.ResetText() 'SoaCode
        txtSoaDate.ResetText() 'SoaDate
        txtCustomerName.ResetText() 'CustomerName
        txtCustomerCode.ResetText() 'CustomerCode
        txtSoaRemark.ResetText() 'SoaRemark
        txtPaymentDue.ResetText() 'PaymentDue
        txtReceivedBy.ResetText() 'ReceivedBy
        txtConfirmDate.ResetText() 'ConfirmDate
        txtadvanceamount.Text = "0" 'advanceamount
        txtCustomeradv.Text = "0" 'Customeradv
        txtServiceNonVat.Text = "0" 'ServiceNonVat
        ServiceVatOld.Text = "0" 'ServiceVat
        txtTotalVat.Text = "0" 'TotalVat
        txtWHT.Text = "0" 'WHT
        txtNet.Text = "0" 'Net
        txtactive.Text = "1" 'active
        _IsNew = True
    End Sub

    Private Sub txtCustomerName_ButtonClick(sender as Object, e as Eventargs) Handles txtCustomerName.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT distinct [Customer]
      ,[CustomerCode]
      ,[Customeraddress] FROM [Invoice_Header] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtCustomerCode.Text = dr("CustomerCode").ToString
            txtCustomerName.Text = dr("Customer").ToString
            txtCustomeraddress.Text = dr("Customeraddress").ToString
            LoadDataToSoa()
            addDataToInv()
        End If
    End Sub
    Private Sub LoadDataToSoa(Optional ByVal InvoiceNo as String = "")
        Try
            dgvInvoice.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Invoice_Header where active='1' and SoaNo='" & txtSoaCode.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvInvoice.Rows.add(dt.Rows(i)("Ident").ToString(), 'Ident
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
                    dt.Rows(i)("ChangeVat").ToString(),  'ChangeVat
                    dt.Rows(i)("SoaNo").ToString(),
                    "1"
                    )
                Next
                addDataToInv()
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub cmdPrint_Click(sender as Object, e as Eventargs) Handles cmdPrint.Click
        Dim url as String = "http://203.170.129.23/transport/report/Soa?SoaNo=" & txtSoaCode.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex as Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub dgvInvoice_Rowsadded(sender as Object, e as DataGridViewRowsaddedEventargs) Handles dgvInvoice.Rowsadded
        'dgvInvoice.Row.Cells(25).Value = "1"
    End Sub

    Private Sub MetroTextBox1_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox1.ButtonClick
        If txtSoaCode.Text = "" Then
            MsgBox("Save Header First!!!!!!!!!!!!!!!")
        Else
            Dim dr as DataRow
            dr = PopUpSearch("SELECT * FROM Invoice_Header WHERE 1=1  and ISNULL(SoaNo,'')='' and active = '1'", MainConnection)
            If isSearchOK Then
                txtIdentD.Text = dr("ident").ToString
                txtInvoiceNo.Text = dr("InvoiceNo").ToString
                '_IsNew = False
                SelectConfirmation.ShowDialog()
                If Selected = True Then
                    SaveSoaDetail()
                    LoadDataToSoa()
                ElseIf Selected = False Then
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub txtInvoiceNo_TextChanged(sender as Object, e as Eventargs) Handles txtInvoiceNo.TextChanged
    End Sub

    Private Sub cmdSearch_Click(sender as Object, e as Eventargs) Handles cmdSearch.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [Ident]
        ,[SoaCode]
        ,[SoaDate]
        ,[CustomerName]
        ,[CustomerCode]
        ,[SoaRemark]
        ,[PaymentDue]
        ,[ReceivedBy]
        ,[ConfirmDate]
        ,[advanceamount]
        ,[Customeradv]
        ,[ServiceNonVat]
        ,[ServiceVat]
        ,[TotalVat]
        ,[WHT]
        ,[Net]
        ,[active] FROM [Soa_Header] WHERE 1=1 and active=1", MainConnection)
        If isSearchOK Then
            txtIdent.Text = dr("Ident").ToString
            txtSoaCode.Text = dr("SoaCode").ToString
            txtSoaDate.Value = CDate(dr("SoaDate")).ToString
            txtCustomerName.Text = dr("CustomerName").ToString
            txtCustomerCode.Text = dr("CustomerCode").ToString
            txtSoaRemark.Text = dr("SoaRemark").ToString
            txtPaymentDue.Value = CDate(dr("PaymentDue")).ToString
            txtReceivedBy.Text = dr("ReceivedBy").ToString
            txtConfirmDate.Value = CDate(dr("ConfirmDate")).ToString
            txtadvanceamount.Text = dr("advanceamount").ToString
            txtCustomeradv.Text = dr("Customeradv").ToString
            txtServiceNonVat.Text = dr("ServiceNonVat").ToString
            txtServiceVat.Text = dr("ServiceVat").ToString
            txtTotalVat.Text = dr("TotalVat").ToString
            txtWHT.Text = dr("WHT").ToString
            txtNet.Text = dr("Net").ToString
            txtactive.Text = dr("active").ToString
            _IsNew = False
            LoadDataToSoa()
            addDataToInv()
        End If
    End Sub

    Private Sub dgvInvoice_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvInvoice.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvInvoice.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdentD.Text = CInt(dgvInvoice.CurrentRow.Cells(0).Value.ToString()) 'ident
                txtInvoiceNo.Text = dgvInvoice.CurrentRow.Cells(0).Value.ToString()
            End If
        Catch ex as Exception

        End Try
    End Sub

    Private Sub MetroTextBox2_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox2.ButtonClick
        SaveSoaDetail()
    End Sub
End Class