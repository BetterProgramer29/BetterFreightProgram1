Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Public Class Quotation
    Public _IsNew as Boolean
    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        If txtQuotationNo.Text = "" Then
            If txtQuotationType.Text = "IMPORT" Then
                GetRunningFormat("IMQ")
                txtQuotationNo.Text = CreateNumber("Freight_Quotation", "QuotationNo", dtpQuotationDate.Value)
            ElseIf txtQuotationType.Text = "EXPORT" Then
                GetRunningFormat("EXQ")
                txtQuotationNo.Text = CreateNumber("Freight_Quotation", "QuotationNo", dtpQuotationDate.Value)
            ElseIf txtQuotationType.Text = "TRANSIT" Then
                GetRunningFormat("TRQ")
                txtQuotationNo.Text = CreateNumber("Freight_Quotation", "QuotationNo", dtpQuotationDate.Value)
            ElseIf txtQuotationType.Text = "OVERSEA" Then
                GetRunningFormat("OVQ")
                txtQuotationNo.Text = CreateNumber("Freight_Quotation", "QuotationNo", dtpQuotationDate.Value)
            End If
        End If
        If _IsNew = True Then
            SaveQuotation(1)
        Else
            SaveQuotation(0)
        End If
    End Sub
    Private Sub SaveQuotation(_insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_Quotation ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtQuotationType.Text & "'") 'QuotationType
            SQLcommand.append(",'" & txtQuotationNo.Text & "'") 'QuotationNo
            SQLcommand.append(",'" & CDate(dtpQuotationDate.Text) & "'") 'QuotationDate
            SQLcommand.append(",'" & txtCustomer.Text & "'") 'Customer
            SQLcommand.append(",'" & txtCustomeraddress.Text & "'") 'Customeraddress
            SQLcommand.append(",'" & txtCustomerContact.Text & "'") 'CustomerContact
            SQLcommand.append(",'" & txtCustomerEmail1.Text & "'") 'CustomerEmail1
            SQLcommand.append(",'" & txtCustomerEmail2.Text & "'") 'CustomerEmail2
            SQLcommand.append(",'" & txtCreditTerm.Text & "'") 'CreditTerm
            SQLcommand.append(",'" & txtFactory.Text & "'") 'Factory
            SQLcommand.append(",'" & txtFactoryContact.Text & "'") 'FactoryContact
            SQLcommand.append(",'" & txtRemark.Text & "'") 'Remark
            SQLcommand.append(",'" & txtCustCode.Text & "'")
            SQLcommand.append(",'" & txtFactoryCode.Text & "'")
            SQLcommand.Append(",'" & txtCreateUser.Text & "'")
            SQLcommand.Append(",'" & txtActive.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                GetIdent()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Quotation_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        addNewQuotation()
        txtCreateUser.Text = UserProfile.U_FName + " " + UserProfile.U_LName
    End Sub
    Event DataGridView1ButtonClick(sender as DataGridView, e as DataGridViewCellEventargs)
    Private Sub DataGridView1_CellContentClick(sender as System.Object, e as DataGridViewCellEventargs) Handles dgvOceanFreight.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn andalso e.RowIndex >= 0 Then
            RaiseEvent DataGridView1ButtonClick(senderGrid, e)
            If dgvOceanFreight.CurrentRow.Cells(19).Value = "0" Then
                dgvOceanFreight.CurrentRow.Cells(19).Value = 0
            Else
                dgvOceanFreight.CurrentRow.Cells(19).Value = 1
            End If

        End If
    End Sub
    Private Sub DataGridView1_ButtonClick(sender as DataGridView, e as DataGridViewCellEventargs) Handles Me.DataGridView1ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("Select TOP(100) [accountGroup], [ItemName]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[SIGroup]  FROM [MaS_SICODE] WHERE 1=1 AND ([SIGroup] LIKE'SVF%' OR [SIGroup] LIKE'OAF%') ", MainConnection)
        If isSearchOK Then
            dgvOceanFreight.CurrentRow.Cells(2).Value = dr("SICode").ToString
            dgvOceanFreight.CurrentRow.Cells(4).Value = dr("ItemName").ToString
            dgvOceanFreight.CurrentRow.Cells(19).Value = "1"
        End If
    End Sub
    Event DataGridView2ButtonClick(sender as DataGridView, e as DataGridViewCellEventargs)
    Private Sub DataGridView2_CellContentClick(sender as System.Object, e as DataGridViewCellEventargs) Handles dgvCustomsClearance.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn andalso e.RowIndex >= 0 Then
            RaiseEvent DataGridView2ButtonClick(senderGrid, e)
            If dgvCustomsClearance.CurrentRow.Cells(19).Value = "0" Then
                dgvCustomsClearance.CurrentRow.Cells(19).Value = 0
            Else
                dgvCustomsClearance.CurrentRow.Cells(19).Value = 1
            End If
        End If
    End Sub
    Private Sub DataGridView2_ButtonClick(sender as DataGridView, e as DataGridViewCellEventargs) Handles Me.DataGridView2ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) [accountGroup],[ItemName]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[SIGroup]  FROM [MaS_SICODE] WHERE 1=1 	AND ([SIGroup] LIKE'SVP%' OR [SIGroup] LIKE'OAP%' OR [SIGroup] LIKE'STK%' OR [SIGroup] LIKE'OAT%' ) ", MainConnection)
        If isSearchOK Then
            dgvCustomsClearance.CurrentRow.Cells(2).Value = dr("SICode").ToString
            dgvCustomsClearance.CurrentRow.Cells(4).Value = dr("ItemName").ToString
            dgvCustomsClearance.CurrentRow.Cells(19).Value = "1"
        End If
    End Sub
    Private Sub dgvOceanFreight_Rowsadded(sender as Object, e as DataGridViewRowsaddedEventargs) Handles dgvOceanFreight.Rowsadded
        Try
            Dim CBCell as New DataGridViewComboBoxCell()
            CBCell = dgvOceanFreight.Rows(e.RowIndex).Cells(7)
            CBCell.Items.add("CBM")
            CBCell.Items.add("KGS")
            CBCell.Items.add("TRIP")
            CBCell.Items.add("SHP")
            CBCell.Items.add("20GP")
            CBCell.Items.add("20HQ")
            CBCell.Items.add("40GP")
            CBCell.Items.add("40HQ")
            CBCell.Items.add("ISO TaNK")
            Dim UnitCell as New DataGridViewComboBoxCell()
            UnitCell = dgvOceanFreight.Rows(e.RowIndex).Cells(8)
            UnitCell.Items.add("THB")
            UnitCell.Items.add("USD")
            UnitCell.Items.add("CYN")
            UnitCell.Items.add("JPY")
            UnitCell.Items.add("KRW")
            UnitCell.Items.add("VND")
            'dgvOceanFreight.Rows(e.RowIndex).Cells(0).Value = "0"
            'dgvOceanFreight.Rows(e.RowIndex).Cells(6).Value = "0"
            'dgvOceanFreight.Rows(e.RowIndex).Cells(6).Value = 1 'Qty
            'dgvOceanFreight.Rows(e.RowIndex).Cells(9).Value = 1 'EXC
            'dgvOceanFreight.Rows(e.RowIndex).Cells(10).Value = 0
            'dgvOceanFreight.Rows(e.RowIndex).Cells(11).Value = 0
            dgvOceanFreight.Rows(e.RowIndex).Cells(12).Value = 0
            dgvOceanFreight.Rows(e.RowIndex).Cells(13).Value = 0
            'dgvOceanFreight.Rows(e.RowIndex).Cells(14).Value = 0
            'dgvOceanFreight.Rows(e.RowIndex).Cells(15).Value = 0
            'dgvOceanFreight.Rows(e.RowIndex).Cells(16).Value = 0
            dgvOceanFreight.Rows(e.RowIndex).Cells(18).Value = 1
            dgvOceanFreight.Rows(e.RowIndex).Cells(1).Value = "OCF"
            'dgvOceanFreight.Rows(e.RowIndex).Cells(11).Value = txtQuotationNo.Text
            'dgvOceanFreight.Rows(e.RowIndex).Cells(12).Value = "0" 'Isnew
            'dgvOceanFreight.Rows(e.RowIndex).Cells(13).Value = "1" 'active
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub dgvCustomsClearance_Rowsadded(sender as Object, e as DataGridViewRowsaddedEventargs) Handles dgvCustomsClearance.Rowsadded
        Try
            Dim CBCell as New DataGridViewComboBoxCell()
            CBCell = dgvCustomsClearance.Rows(e.RowIndex).Cells(7)
            CBCell.Items.add("CBM")
            CBCell.Items.add("KGS")
            CBCell.Items.add("TRIP")
            CBCell.Items.add("SHP")
            CBCell.Items.add("20GP")
            CBCell.Items.add("20HQ")
            CBCell.Items.add("40GP")
            CBCell.Items.add("40HQ")
            CBCell.Items.add("ISO TaNK")
            Dim UnitCell as New DataGridViewComboBoxCell()
            UnitCell = dgvCustomsClearance.Rows(e.RowIndex).Cells(8)
            UnitCell.Items.add("THB")
            UnitCell.Items.add("USD")
            UnitCell.Items.add("CYN")
            UnitCell.Items.add("JPY")
            UnitCell.Items.add("KRW")
            UnitCell.Items.add("VND")
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(0).Value = "0"
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(6).Value = "0"
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(6).Value = 1 'Qty
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(9).Value = 1 'EXC
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(10).Value = 0
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(11).Value = 0
            dgvCustomsClearance.Rows(e.RowIndex).Cells(12).Value = 0
            dgvCustomsClearance.Rows(e.RowIndex).Cells(13).Value = 0
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(14).Value = 0
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(15).Value = 0
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(16).Value = 0
            dgvCustomsClearance.Rows(e.RowIndex).Cells(18).Value = 1
            dgvCustomsClearance.Rows(e.RowIndex).Cells(1).Value = "CTC"
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(11).Value = txtQuotationNo.Text
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(12).Value = "0" 'Isnew
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(13).Value = "1" 'active
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        If txtQuotationNo.Text = "" Then
            MsgBox("SaVE DaTa FIRST!!!")
        Else
            SaveOceanFreight()
        End If

    End Sub
    Private Sub SaveOceanFreight()
        Try
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a as Integer = 0
            For row as Integer = 0 To dgvOceanFreight.Rows.Count - 2
                Try
                    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_QuotationDetail ")
                    SQLcommand.append("'" & CInt(dgvOceanFreight.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.append(",'" & dgvOceanFreight.Rows(row).Cells(1).Value & "'") 'DetailType
                    SQLcommand.append(",'" & dgvOceanFreight.Rows(row).Cells(2).Value & "'") 'SICode
                    SQLcommand.append(",'" & dgvOceanFreight.Rows(row).Cells(4).Value & "'") 'SICode Description
                    SQLcommand.append(",'" & dgvOceanFreight.Rows(row).Cells(5).Value & "'") 'Remark
                    SQLcommand.Append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(6).Value) & "'") 'Qty
                    SQLcommand.append(",'" & dgvOceanFreight.Rows(row).Cells(7).Value & "'") 'Tys
                    SQLcommand.append(",'" & dgvOceanFreight.Rows(row).Cells(8).Value & "'") 'CUr
                    SQLcommand.append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(9).Value) & "'") 'EXC
                    SQLcommand.append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(10).Value) & "'") 'UnitPrice
                    SQLcommand.append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(11).Value) & "'") 'Total
                    SQLcommand.append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(12).Value) & "'") 'VaT
                    SQLcommand.append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(13).Value) & "'") 'WHT
                    SQLcommand.append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(14).Value) & "'") 'TotalamtPlusVat
                    SQLcommand.append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(15).Value) & "'") 'TotalamtMinusWHT
                    SQLcommand.append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(16).Value) & "'") 'NetPayment
                    SQLcommand.append(",'" & txtQuotationNo.Text & "'") 'Quotation
                    SQLcommand.append(",'" & CInt(dgvOceanFreight.Rows(row).Cells(18).Value) & "'")
                    SQLcommand.append(",'" & CInt(dgvOceanFreight.Rows(row).Cells(19).Value) & "'") 'IsNew
                    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                    Else
                        a += 1
                    End If
                Catch ex as Exception
                    a += 1
                    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try
            Next
            nection.Close()
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToOceanFreight()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToOceanFreight()
        Try
            dgvOceanFreight.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Freight_QuotationDetail where QuotationDetailType = 'OCF' and QuotationNo='" & txtQuotationNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvOceanFreight.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
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
                           "0"
                            )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        SaveCustomsClearance()
    End Sub
    Private Sub SaveCustomsClearance()
        Try
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a as Integer = 0
            For row as Integer = 0 To dgvCustomsClearance.Rows.Count - 2
                Try
                    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_QuotationDetail ")
                    SQLcommand.append("'" & CInt(dgvCustomsClearance.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.append(",'" & dgvCustomsClearance.Rows(row).Cells(1).Value & "'") 'DetailType
                    SQLcommand.append(",'" & dgvCustomsClearance.Rows(row).Cells(2).Value & "'") 'SICode
                    SQLcommand.append(",'" & dgvCustomsClearance.Rows(row).Cells(4).Value & "'") 'SICode Description
                    SQLcommand.append(",'" & dgvCustomsClearance.Rows(row).Cells(5).Value & "'") 'Remark
                    SQLcommand.Append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(6).Value) & "'") 'Qty
                    SQLcommand.append(",'" & dgvCustomsClearance.Rows(row).Cells(7).Value & "'") 'Tys
                    SQLcommand.append(",'" & dgvCustomsClearance.Rows(row).Cells(8).Value & "'") 'CUr
                    SQLcommand.append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(9).Value) & "'") 'EXC
                    SQLcommand.append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(10).Value) & "'") 'UnitPrice
                    SQLcommand.append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(11).Value) & "'") 'Total
                    SQLcommand.append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(12).Value) & "'") 'VaT
                    SQLcommand.append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(13).Value) & "'") 'WHT
                    SQLcommand.append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(14).Value) & "'") 'TotalamtPlusVat
                    SQLcommand.append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(15).Value) & "'") 'TotalamtMinusWHT
                    SQLcommand.append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(16).Value) & "'") 'NetPayment
                    SQLcommand.append(",'" & txtQuotationNo.Text & "'") 'Quotation
                    SQLcommand.append(",'" & CInt(dgvCustomsClearance.Rows(row).Cells(18).Value) & "'")
                    SQLcommand.append(",'" & CInt(dgvCustomsClearance.Rows(row).Cells(19).Value) & "'") 'IsNew
                    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                    Else
                        a += 1
                    End If
                Catch ex as Exception
                    a += 1
                    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try
            Next
            nection.Close()
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToCustomClearance()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToCustomClearance()
        Try
            dgvCustomsClearance.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Freight_QuotationDetail where QuotationDetailType = 'CTC' and QuotationNo='" & txtQuotationNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(Str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvCustomsClearance.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
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
                           "0"
                            )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub txtQuotationNo_TextChanged(sender as Object, e as Eventargs) Handles txtQuotationNo.TextChanged
        'LoadDataToCustomClearance()
        'LoadDataToOceanFreight()
    End Sub
    Private Sub Button8_Click(sender as Object, e as Eventargs) Handles Button8.Click
        dgvOceanFreight.CurrentRow.Cells(18).Value = 0
        MsgBox("กดปุ่มเซฟเพื่อยืนยันการยกเลิก")
        'SaveOceanFreight()
    End Sub

    Private Sub Button10_Click(sender as Object, e as Eventargs) Handles Button10.Click
        addNewQuotation()
    End Sub
    Private Sub addNewQuotation()
        txtIdent.ResetText() 'Ident
        txtQuotationType.ResetText() 'QuotationType
        txtQuotationNo.ResetText() 'QuotationNo
        txtCustomer.ResetText() 'Customer
        txtCustomeraddress.ResetText() 'Customeraddress
        txtCustomerContact.ResetText() 'CustomerContact
        txtCustomerEmail1.ResetText() 'CustomerEmail1
        txtCustomerEmail2.ResetText() 'CustomerEmail2
        txtCreditTerm.ResetText() 'CreditTerm
        txtFactory.ResetText() 'Factory
        txtFactoryContact.ResetText() 'FactoryContact
        txtRemark.ResetText() 'Remark
        _IsNew = True
    End Sub

    Private Sub Button9_Click(sender as Object, e as Eventargs) Handles Button9.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(500) 
        [QuotationType]
        ,[QuotationNo]
        ,[QuotationDate]
        ,[Customer]
        ,[Customeraddress]
        ,[CustomerContact]
        ,[CustomerEmail1]
        ,[CustomerEmail2]
        ,[CreditTerm]
        ,[Factory]
        ,[FactoryContact]
        ,[Remark],[CreateUser],[Ident]  FROM Freight_Quotation WHERE 1=1 and Active='1'", MainConnection)
        If isSearchOK Then
            txtIdent.Text = dr("ident").ToString
            txtQuotationType.Text = dr("QuotationType").ToString
            txtQuotationNo.Text = dr("QuotationNo").ToString
            dtpQuotationDate.Text = CDate(dr("QuotationDate")).ToString
            txtCustomer.Text = dr("Customer").ToString
            txtCustomeraddress.Text = dr("Customeraddress").ToString
            txtCustomerContact.Text = dr("CustomerContact").ToString
            txtCustomerEmail1.Text = dr("CustomerEmail1").ToString
            txtCustomerEmail2.Text = dr("CustomerEmail2").ToString
            txtCreditTerm.Text = dr("CreditTerm").ToString
            txtFactory.Text = dr("Factory").ToString
            txtFactoryContact.Text = dr("FactoryContact").ToString
            txtRemark.Text = dr("Remark").ToString
            txtCreateUser.Text = dr("CreateUser").ToString
            _IsNew = False
            LoadDataToCustomClearance()
            LoadDataToOceanFreight()
        End If
    End Sub

    Private Sub txtQuotationNo_ButtonClick(sender As Object, e As Eventargs) Handles txtQuotationNo.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100)
        [QuotationType]
        ,[QuotationNo]
        ,[QuotationDate]
        ,[Customer]
        ,[Customeraddress]
        ,[CustomerContact]
        ,[CustomerEmail1]
        ,[CustomerEmail2]
        ,[CreditTerm]
        ,[Factory]
        ,[FactoryContact]
        ,[Remark]
        ,[Ident] FROM Freight_Quotation WHERE 1=1 and Active='1'", MainConnection)
        If isSearchOK Then
            'txtIdent.Text = dr("ident").ToString
            txtQuotationType.Text = dr("QuotationType").ToString
            txtPullQuotation.Text = dr("QuotationNo").ToString
            dtpQuotationDate.Text = CDate(dr("QuotationDate")).ToString
            txtCustomer.Text = dr("Customer").ToString
            txtCustomeraddress.Text = dr("Customeraddress").ToString
            txtCustomerContact.Text = dr("CustomerContact").ToString
            txtCustomerEmail1.Text = dr("CustomerEmail1").ToString
            txtCustomerEmail2.Text = dr("CustomerEmail2").ToString
            txtCreditTerm.Text = dr("CreditTerm").ToString
            txtFactory.Text = dr("Factory").ToString
            txtFactoryContact.Text = dr("FactoryContact").ToString
            txtRemark.Text = dr("Remark").ToString
            LoadDataToOceanFreightCopy()
            LoadDataToCustomClearanceCopy()
            _IsNew = True
        End If
    End Sub
    Private Sub LoadDataToOceanFreightCopy()
        Try
            dgvOceanFreight.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_QuotationDetail where QuotationDetailType = 'OCF' and QuotationNo='" & txtPullQuotation.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvOceanFreight.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
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
    Private Sub LoadDataToCustomClearanceCopy()
        Try
            dgvCustomsClearance.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_QuotationDetail where QuotationDetailType = 'CTC' and QuotationNo='" & txtPullQuotation.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvCustomsClearance.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
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
    Private Sub MetroTextBox1_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox1.ButtonClick
        If _IsNew = True Then
            _IsNew = False
            MsgBox("Update Existing Data!!!")
        Else
            _IsNew = True
            MsgBox("Insert New Data!!!")
        End If
    End Sub

    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        dgvCustomsClearance.CurrentRow.Cells(18).Value = 0
        MsgBox("กดปุ่มเซฟเพื่อยืนยันการยกเลิก")
    End Sub

    Private Sub GetIdent()
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT Ident FROM [Freight_Quotation] where QuotationNo='" & txtQuotationNo.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtIdent.Text = CInt(dr("Ident")).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtCustomer_ButtonClick(sender as Object, e as Eventargs) Handles txtCustomer.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) [CustTaxID]
      ,[CustCompanyID]
      ,[CustBranch]
      ,[CustCompanyEName]
      ,[CustEAddress]
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

      ,[CustDate]  FROM Mas_CustomerFreight WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtCustomer.Text = dr("CustCompanyEName").ToString
            txtCustCode.Text = dr("CustCompanyID").ToString
            txtCustomeraddress.Text = dr("CustEAddress").ToString
            txtCustomerContact.Text = (dr("CustPhone") + " " + dr("CustFax")).ToString
            txtCustomerEmail1.Text = dr("CustEmail").ToString
        End If
    End Sub

    Private Sub txtFactory_ButtonClick(sender as Object, e as Eventargs) Handles txtFactory.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [CustTaxID]
      ,[CustCompanyID]
      ,[CustBranch]
      ,[CustCompanyEName]
      ,[CustEAddress]
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

      ,[CustDate]  FROM Mas_CustomerFreight WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtFactory.Text = dr("CustCompanyEName").ToString
            txtFactoryCode.Text = dr("CustCompanyID").ToString
            txtCustomerContact.Text = (dr("CustPhone") + " " + dr("CustFax")).ToString
        End If
    End Sub

    Private Sub dgvOceanFreight_CellEndEdit(sender as Object, e as DataGridViewCellEventargs) Handles dgvOceanFreight.CellEndEdit
        Try
            dgvOceanFreight.CurrentRow.Cells(11).Value = ((CDbl(dgvOceanFreight.CurrentRow.Cells(6).Value) * CDbl(dgvOceanFreight.CurrentRow.Cells(10).Value)) * CDbl(dgvOceanFreight.CurrentRow.Cells(9).Value)).ToString("#,##0.00")
            dgvOceanFreight.CurrentRow.Cells(14).Value = (CDbl(dgvOceanFreight.CurrentRow.Cells(11).Value) + ((CDbl(dgvOceanFreight.CurrentRow.Cells(12).Value) / 100)) * CDbl(dgvOceanFreight.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvOceanFreight.CurrentRow.Cells(15).Value = (CDbl(dgvOceanFreight.CurrentRow.Cells(11).Value) - ((CDbl(dgvOceanFreight.CurrentRow.Cells(13).Value) / 100)) * CDbl(dgvOceanFreight.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvOceanFreight.CurrentRow.Cells(16).Value = (CDbl(dgvOceanFreight.CurrentRow.Cells(11).Value) + (CDbl(dgvOceanFreight.CurrentRow.Cells(12).Value) / 100) * CDbl(dgvOceanFreight.CurrentRow.Cells(11).Value) - (CDbl(dgvOceanFreight.CurrentRow.Cells(13).Value) / 100) * CDbl(dgvOceanFreight.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
        Catch ex as Exception

        End Try
    End Sub

    Private Sub dgvCustomsClearance_CellEndEdit(sender as Object, e as DataGridViewCellEventargs) Handles dgvCustomsClearance.CellEndEdit
        Try
            dgvCustomsClearance.CurrentRow.Cells(11).Value = ((CDbl(dgvCustomsClearance.CurrentRow.Cells(6).Value) * CDbl(dgvCustomsClearance.CurrentRow.Cells(10).Value)) * CDbl(dgvCustomsClearance.CurrentRow.Cells(9).Value)).ToString("#,##0.00")
            dgvCustomsClearance.CurrentRow.Cells(14).Value = (CDbl(dgvCustomsClearance.CurrentRow.Cells(11).Value) + ((CDbl(dgvCustomsClearance.CurrentRow.Cells(12).Value) / 100)) * CDbl(dgvCustomsClearance.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvCustomsClearance.CurrentRow.Cells(15).Value = (CDbl(dgvCustomsClearance.CurrentRow.Cells(11).Value) - ((CDbl(dgvCustomsClearance.CurrentRow.Cells(13).Value) / 100)) * CDbl(dgvCustomsClearance.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvCustomsClearance.CurrentRow.Cells(16).Value = (CDbl(dgvCustomsClearance.CurrentRow.Cells(11).Value) + (CDbl(dgvCustomsClearance.CurrentRow.Cells(12).Value) / 100) * CDbl(dgvCustomsClearance.CurrentRow.Cells(11).Value) - (CDbl(dgvCustomsClearance.CurrentRow.Cells(13).Value) / 100) * CDbl(dgvCustomsClearance.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
        Catch ex as Exception

        End Try
    End Sub

    Private Sub dgvOceanFreight_UseraddedRow(sender as Object, e as DataGridViewRowEventargs) Handles dgvOceanFreight.UseraddedRow

    End Sub

    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click
        Dim url as String = "http://203.170.129.23/TESTFRIEGHT/report/Quotation?DocNo=" & txtQuotationNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex as Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub txtQuotationNo_Click(sender As Object, e As EventArgs) Handles txtQuotationNo.Click
        'If txtQuotationNo.Text = "" Then
        '    If txtQuotationType.Text = "IMPORT" Then
        '        GetRunningFormat("IMQ")
        '        txtQuotationNo.Text = CreateNumber("Freight_Quotation", "QuotationNo", dtpQuotationDate.Value)
        '    ElseIf txtQuotationType.Text = "EXPORT" Then
        '        GetRunningFormat("EXQ")
        '        txtQuotationNo.Text = CreateNumber("Freight_Quotation", "QuotationNo", dtpQuotationDate.Value)
        '    ElseIf txtQuotationType.Text = "TRANSIT" Then
        '        GetRunningFormat("TRQ")
        '        txtQuotationNo.Text = CreateNumber("Freight_Quotation", "QuotationNo", dtpQuotationDate.Value)
        '    End If
        'End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If txtActive.Text = 1 Then
            txtActive.Text = 0
            MsgBox("กดปุ่มเซฟเพื่อยืนยันการยกเลิก")
        ElseIf txtActive.Text = 0 Then
            txtActive.Text = 1
            MsgBox("คุณได้ยกเลิกการยกเลิก")
        End If
    End Sub
End Class