Imports System.Data.OleDb
Imports System.Text

Public Class CostPrice
    Public _IsNew as Boolean
    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        If txtCostNo.Text = "" Then
            GetRunningFormat("CST")
            txtCostNo.Text = CreateNumber("Freight_Cost", "CostNo", False)
        End If
        If _IsNew = True Then
            SaveCost(1)
        Else
            SaveCost(0)
        End If
    End Sub
    Private Sub SaveCost(_insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_Cost ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtCostType.Text & "'") 'CostType
            SQLcommand.append(",'" & txtCostNo.Text & "'") 'CostNo
            SQLcommand.append(",'" & CDate(dtpCostDate.Text) & "'") 'CostDate
            SQLcommand.append(",'" & txtVendor.Text & "'") 'Vendor
            SQLcommand.append(",'" & txtVendoraddress.Text & "'") 'Vendoraddress
            SQLcommand.append(",'" & txtVendorContact.Text & "'") 'VendorContact
            SQLcommand.append(",'" & txtVendorEmail1.Text & "'") 'VendorEmail1
            SQLcommand.append(",'" & txtVendorEmail2.Text & "'") 'VendorEmail2
            SQLcommand.append(",'" & txtCreditTerm.Text & "'") 'CreditTerm
            SQLcommand.append(",'" & txtactualVendor.Text & "'") 'actualVendor
            SQLcommand.append(",'" & txtactualVendorContact.Text & "'") 'actualVendorContact
            SQLcommand.append(",'" & txtRemark.Text & "'") 'Remark
            SQLcommand.append(",'" & txtVenCode.Text & "'")
            SQLcommand.append(",'" & txtactVenCode.Text & "'")
            SQLcommand.append(",'" & txtCreateUser.Text & "'")
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
    Private Sub Cost_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        AddNewCost()
    End Sub
    Event DataGridView1ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgvOceanFreight.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent DataGridView1ButtonClick(senderGrid, e)
            If dgvOceanFreight.CurrentRow.Cells(19).Value = "0" Then
                dgvOceanFreight.CurrentRow.Cells(19).Value = 0
            Else
                dgvOceanFreight.CurrentRow.Cells(19).Value = 1
            End If

        End If
    End Sub
    Private Sub DataGridView1_ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles Me.DataGridView1ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("Select TOP(100) [accountGroup], [ItemName]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[SIGroup]  FROM [MaS_SICODE] WHERE 1=1 AND ([SIGroup] LIKE'CVF%' OR [SIGroup] LIKE'OCF%') ", MainConnection)
        If isSearchOK Then
            dgvOceanFreight.CurrentRow.Cells(2).Value = dr("SICode").ToString
            dgvOceanFreight.CurrentRow.Cells(4).Value = dr("ItemName").ToString
            dgvOceanFreight.CurrentRow.Cells(19).Value = "1"
        End If
    End Sub
    Event DataGridView2ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)
    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgvCustomsClearance.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent DataGridView2ButtonClick(senderGrid, e)
            If dgvCustomsClearance.CurrentRow.Cells(19).Value = "0" Then
                dgvCustomsClearance.CurrentRow.Cells(19).Value = 0
            Else
                dgvCustomsClearance.CurrentRow.Cells(19).Value = 1
            End If
        End If
    End Sub
    Private Sub DataGridView2_ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles Me.DataGridView2ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [accountGroup],[ItemName]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[SIGroup]  FROM [MaS_SICODE] WHERE 1=1 AND ([SIGroup] LIKE'CSP%' OR [SIGroup] LIKE'CTK%'  OR [SIGroup] LIKE'OCP%'  OR [SIGroup] LIKE'OCT%') ", MainConnection)
        If isSearchOK Then
            dgvCustomsClearance.CurrentRow.Cells(2).Value = dr("SICode").ToString
            dgvCustomsClearance.CurrentRow.Cells(4).Value = dr("ItemName").ToString
            dgvCustomsClearance.CurrentRow.Cells(19).Value = "1"
        End If
    End Sub
    Private Sub dgvOceanFreight_Rowsadded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvOceanFreight.RowsAdded
        Try
            Dim CBCell As New DataGridViewComboBoxCell()
            CBCell = dgvOceanFreight.Rows(e.RowIndex).Cells(7)
            CBCell.Items.Add("CBM")
            CBCell.Items.Add("KGS")
            CBCell.Items.Add("TRIP")
            CBCell.Items.Add("SHP")
            CBCell.Items.Add("20GP")
            CBCell.Items.Add("20HQ")
            CBCell.Items.Add("40GP")
            CBCell.Items.Add("40HQ")
            CBCell.Items.Add("ISO TaNK")
            Dim UnitCell As New DataGridViewComboBoxCell()
            UnitCell = dgvOceanFreight.Rows(e.RowIndex).Cells(8)
            UnitCell.Items.Add("THB")
            UnitCell.Items.Add("USD")
            UnitCell.Items.Add("CYN")
            UnitCell.Items.Add("JPY")
            UnitCell.Items.Add("KRW")
            UnitCell.Items.Add("VND")
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
            'dgvOceanFreight.Rows(e.RowIndex).Cells(11).Value = txtCostNo.Text
            'dgvOceanFreight.Rows(e.RowIndex).Cells(12).Value = "0" 'Isnew
            'dgvOceanFreight.Rows(e.RowIndex).Cells(13).Value = "1" 'active
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub dgvCustomsClearance_Rowsadded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvCustomsClearance.RowsAdded
        Try
            Dim CBCell As New DataGridViewComboBoxCell()
            CBCell = dgvCustomsClearance.Rows(e.RowIndex).Cells(7)
            CBCell.Items.Add("CBM")
            CBCell.Items.Add("KGS")
            CBCell.Items.Add("TRIP")
            CBCell.Items.Add("SHP")
            CBCell.Items.Add("20GP")
            CBCell.Items.Add("20HQ")
            CBCell.Items.Add("40GP")
            CBCell.Items.Add("40HQ")
            CBCell.Items.Add("ISO TaNK")
            Dim UnitCell As New DataGridViewComboBoxCell()
            UnitCell = dgvCustomsClearance.Rows(e.RowIndex).Cells(8)
            UnitCell.Items.Add("THB")
            UnitCell.Items.Add("USD")
            UnitCell.Items.Add("CYN")
            UnitCell.Items.Add("JPY")
            UnitCell.Items.Add("KRW")
            UnitCell.Items.Add("VND")
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
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(11).Value = txtCostNo.Text
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(12).Value = "0" 'Isnew
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(13).Value = "1" 'active
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtCostNo.Text = "" Then
            MsgBox("SaVE DaTa FIRST!!!")
        Else
            SaveOceanFreight()
        End If

    End Sub
    Private Sub SaveOceanFreight()
        Try
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a As Integer = 0
            For row As Integer = 0 To dgvOceanFreight.Rows.Count - 2
                Try
                    Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_CostDetail ")
                    SQLcommand.Append("'" & CInt(dgvOceanFreight.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.Append(",'" & dgvOceanFreight.Rows(row).Cells(1).Value & "'") 'DetailType
                    SQLcommand.Append(",'" & dgvOceanFreight.Rows(row).Cells(2).Value & "'") 'SICode
                    SQLcommand.Append(",'" & dgvOceanFreight.Rows(row).Cells(4).Value & "'") 'SICode Description
                    SQLcommand.Append(",'" & dgvOceanFreight.Rows(row).Cells(5).Value & "'") 'Remark
                    SQLcommand.Append(",'" & CInt(dgvOceanFreight.Rows(row).Cells(6).Value) & "'") 'Qty
                    SQLcommand.Append(",'" & dgvOceanFreight.Rows(row).Cells(7).Value & "'") 'Tys
                    SQLcommand.Append(",'" & dgvOceanFreight.Rows(row).Cells(8).Value & "'") 'CUr
                    SQLcommand.Append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(9).Value) & "'") 'EXC
                    SQLcommand.Append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(10).Value) & "'") 'UnitPrice
                    SQLcommand.Append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(11).Value) & "'") 'Total
                    SQLcommand.Append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(12).Value) & "'") 'VaT
                    SQLcommand.Append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(13).Value) & "'") 'WHT
                    SQLcommand.Append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(14).Value) & "'") 'TotalamtPlusVat
                    SQLcommand.Append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(15).Value) & "'") 'TotalamtMinusWHT
                    SQLcommand.Append(",'" & CDbl(dgvOceanFreight.Rows(row).Cells(16).Value) & "'") 'NetPayment
                    SQLcommand.Append(",'" & txtCostNo.Text & "'") 'Cost
                    SQLcommand.Append(",'" & CInt(dgvOceanFreight.Rows(row).Cells(18).Value) & "'")
                    SQLcommand.Append(",'" & CInt(dgvOceanFreight.Rows(row).Cells(19).Value) & "'") 'IsNew
                    Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                    Else
                        a += 1
                    End If
                Catch ex As Exception
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
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToOceanFreight()
        Try
            dgvOceanFreight.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_CostDetail where CostDetailType = 'OCF' and CostNo='" & txtCostNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvOceanFreight.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                           dt.Rows(i)(1).ToString(), 'CostDetailType
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
                           dt.Rows(i)(16).ToString(), 'CostNo
                           dt.Rows(i)(17).ToString(), 'active
                           "0"
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
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveCustomsClearance()
    End Sub
    Private Sub SaveCustomsClearance()
        Try
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a As Integer = 0
            For row As Integer = 0 To dgvCustomsClearance.Rows.Count - 2
                Try
                    Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_CostDetail ")
                    SQLcommand.Append("'" & CInt(dgvCustomsClearance.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.Append(",'" & dgvCustomsClearance.Rows(row).Cells(1).Value & "'") 'DetailType
                    SQLcommand.Append(",'" & dgvCustomsClearance.Rows(row).Cells(2).Value & "'") 'SICode
                    SQLcommand.Append(",'" & dgvCustomsClearance.Rows(row).Cells(4).Value & "'") 'SICode Description
                    SQLcommand.Append(",'" & dgvCustomsClearance.Rows(row).Cells(5).Value & "'") 'Remark
                    SQLcommand.Append(",'" & CInt(dgvCustomsClearance.Rows(row).Cells(6).Value) & "'") 'Qty
                    SQLcommand.Append(",'" & dgvCustomsClearance.Rows(row).Cells(7).Value & "'") 'Tys
                    SQLcommand.Append(",'" & dgvCustomsClearance.Rows(row).Cells(8).Value & "'") 'CUr
                    SQLcommand.Append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(9).Value) & "'") 'EXC
                    SQLcommand.Append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(10).Value) & "'") 'UnitPrice
                    SQLcommand.Append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(11).Value) & "'") 'Total
                    SQLcommand.Append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(12).Value) & "'") 'VaT
                    SQLcommand.Append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(13).Value) & "'") 'WHT
                    SQLcommand.Append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(14).Value) & "'") 'TotalamtPlusVat
                    SQLcommand.Append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(15).Value) & "'") 'TotalamtMinusWHT
                    SQLcommand.Append(",'" & CDbl(dgvCustomsClearance.Rows(row).Cells(16).Value) & "'") 'NetPayment
                    SQLcommand.Append(",'" & txtCostNo.Text & "'") 'Cost
                    SQLcommand.Append(",'" & CInt(dgvCustomsClearance.Rows(row).Cells(18).Value) & "'")
                    SQLcommand.Append(",'" & CInt(dgvCustomsClearance.Rows(row).Cells(19).Value) & "'") 'IsNew
                    Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                    Else
                        a += 1
                    End If
                Catch ex As Exception
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
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToCustomClearance()
        Try
            dgvCustomsClearance.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_CostDetail where CostDetailType = 'CTC' and CostNo='" & txtCostNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvCustomsClearance.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                           dt.Rows(i)(1).ToString(), 'CostDetailType
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
                           dt.Rows(i)(16).ToString(), 'CostNo
                           dt.Rows(i)(17).ToString(), 'active
                           "0"
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
    Private Sub txtCostNo_TextChanged(sender As Object, e As EventArgs) Handles txtCostNo.TextChanged
        'LoadDataToCustomClearance()
        'LoadDataToOceanFreight()
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        dgvOceanFreight.CurrentRow.Cells(18).Value = 0
        MsgBox("กดปุ่มเซฟเพื่อยืนยันการยกเลิก")
        'SaveOceanFreight()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        AddNewCost()
    End Sub
    Private Sub AddNewCost()
        txtIdent.ResetText() 'Ident
        txtCostType.ResetText() 'CostType
        txtCostNo.ResetText() 'CostNo
        txtVendor.ResetText() 'Vendor
        txtVendoraddress.ResetText() 'Vendoraddress
        txtVendorContact.ResetText() 'VendorContact
        txtVendorEmail1.ResetText() 'VendorEmail1
        txtVendorEmail2.ResetText() 'VendorEmail2
        txtCreditTerm.ResetText() 'CreditTerm
        txtactualVendor.ResetText() 'actualVendor
        txtactualVendorContact.ResetText() 'actualVendorContact
        txtRemark.ResetText() 'Remark
        _IsNew = True
        dgvOceanFreight.Rows.Clear()
        dgvCustomsClearance.Rows.Clear()

    End Sub

    Private Sub Button9_Click(sender as Object, e as Eventargs) Handles Button9.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) 
        [CostType]
        ,[CostNo]
        ,[CostDate]
        ,[Vendor]
        ,[Vendoraddress]
        ,[VendorContact]
        ,[VendorEmail1]
        ,[VendorEmail2]
        ,[CreditTerm]
        ,[actualVendor]
        ,[actualVendorContact]
        ,[Remark],[CreateUser],[Ident]  FROM Freight_Cost WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtIdent.Text = dr("ident").ToString
            txtCostType.Text = dr("CostType").ToString
            txtCostNo.Text = dr("CostNo").ToString
            dtpCostDate.Text = CDate(dr("CostDate")).ToString
            txtVendor.Text = dr("Vendor").ToString
            txtVendoraddress.Text = dr("Vendoraddress").ToString
            txtVendorContact.Text = dr("VendorContact").ToString
            txtVendorEmail1.Text = dr("VendorEmail1").ToString
            txtVendorEmail2.Text = dr("VendorEmail2").ToString
            txtCreditTerm.Text = dr("CreditTerm").ToString
            txtactualVendor.Text = dr("actualVendor").ToString
            txtactualVendorContact.Text = dr("actualVendorContact").ToString
            txtRemark.Text = dr("Remark").ToString
            txtCreateUser.Text = dr("CreateUser").ToString
            _IsNew = False
            LoadDataToCustomClearance()
            LoadDataToOceanFreight()
        End If
    End Sub

    Private Sub txtCostNo_ButtonClick(sender as Object, e as Eventargs) Handles txtCostNo.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100)
        [CostType]
        ,[CostNo]
        ,[CostDate]
        ,[Vendor]
        ,[Vendoraddress]
        ,[VendorContact]
        ,[VendorEmail1]
        ,[VendorEmail2]
        ,[CreditTerm]
        ,[actualVendor]
        ,[actualVendorContact]
        ,[Remark]
        ,[Ident] FROM Freight_Cost WHERE 1=1", MainConnection)
        If isSearchOK Then
            'txtIdent.Text = dr("ident").ToString
            txtCostType.Text = dr("CostType").ToString
            'txtCostNo.Text = dr("CostNo").ToString
            dtpCostDate.Text = CDate(dr("CostDate")).ToString
            txtVendor.Text = dr("Vendor").ToString
            txtVendoraddress.Text = dr("Vendoraddress").ToString
            txtVendorContact.Text = dr("VendorContact").ToString
            txtVendorEmail1.Text = dr("VendorEmail1").ToString
            txtVendorEmail2.Text = dr("VendorEmail2").ToString
            txtCreditTerm.Text = dr("CreditTerm").ToString
            txtactualVendor.Text = dr("actualVendor").ToString
            txtactualVendorContact.Text = dr("actualVendorContact").ToString
            txtRemark.Text = dr("Remark").ToString
            _IsNew = True
        End If
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
            Dim sqlstr as String = "SELECT DISTINCT Ident FROM [Freight_Cost] where CostNo='" & txtCostNo.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtIdent.Text = CInt(dr("Ident")).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtVendor_ButtonClick(sender as Object, e as Eventargs) Handles txtVendor.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail  FROM Mas_Customer WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtVendor.Text = dr("CustName").ToString
            txtVenCode.Text = dr("CustCode").ToString
            txtVendoraddress.Text = dr("Taddress").ToString
            txtVendorContact.Text = (dr("CustContact") + " " + dr("CustPhone") + " " + dr("CustFax")).ToString
            txtVendorEmail1.Text = dr("CustEmail").ToString
        End If
    End Sub

    Private Sub txtactualVendor_ButtonClick(sender as Object, e as Eventargs) Handles txtactualVendor.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail  FROM Mas_Customer WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtactualVendor.Text = dr("CustName").ToString
            txtactVenCode.Text = dr("CustCode").ToString
            txtactualVendorContact.Text = (dr("CustContact") + " " + dr("CustPhone") + " " + dr("CustFax")).ToString
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
        Dim url as String = "http://203.170.129.23/TESTFRIEGHT/report/Cost?DocNo=" & txtCostNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex as Exception
            Process.Start(url)
        End Try
    End Sub
End Class