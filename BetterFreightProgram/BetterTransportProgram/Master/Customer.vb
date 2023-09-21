Imports System.Data.OleDb
Imports System.Text

Public Class Customer
    Public _IsNew as Boolean
    Private Sub Customer_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        addNewCustomer()
        LoadCustTodgv()
    End Sub
    Private Sub SaveCustomer(_insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_CustomerFreight ")
            SQLcommand.append("'" & CInt(txtIdent.Text) & "'") 'Ident
            SQLcommand.append(",'" & txtCustTaxID.Text & "'") 'CustTaxID
            SQLcommand.append(",'" & txtCustCompanyID.Text & "'") 'CustCompanyID
            SQLcommand.append(",'" & txtCustBranch.Text & "'") 'CustBranch
            SQLcommand.append(",'" & txtCustCompanyName.Text & "'") 'CustCompanyName
            SQLcommand.append(",'" & txtCustCountry.Text & "'") 'CustCountry
            SQLcommand.append(",'" & txtCustCity.Text & "'") 'CustCity
            SQLcommand.append(",'" & txtCustaddress.Text & "'") 'Custaddress
            SQLcommand.append(",'" & txtCustEmail.Text & "'") 'CustEmail
            SQLcommand.append(",'" & txtCustPhone.Text & "'") 'CustPhone
            SQLcommand.append(",'" & txtCustFax.Text & "'") 'CustFax
            SQLcommand.append(",'" & txtCustPayable.Text & "'") 'CustPayable
            SQLcommand.append(",'" & CInt(togFactory.CheckState) & "'") 'CustFactory
            SQLcommand.append(",'" & CInt(togCustomer.CheckState) & "'") 'CustCustomer
            SQLcommand.append(",'" & txtSysUserName.Text & "'")
            SQLcommand.Append(",'" & txtSysUser.Text & "'")
            SQLcommand.Append(",'" & txtCustCompanyEName.Text & "'")
            SQLcommand.Append(",'" & txtCustEaddress.Text & "'")
            SQLcommand.Append(",'" & CDate(dtpCustDate.Value) & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadCustTodgv()
                _IsNew = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        If txtCustCompanyID.Text = "" Then
            RunCustomerID()
        End If
        Dim a = txtCustTaxID.Text.Length.ToString
        Dim b = txtCustBranch.Text.Length.ToString
        If togFactory.Checked = True and togCustomer.Checked = True Then
            If a = "13" Then
                If b = "5" Then
                    If _IsNew = True Then
                        SaveCustomer(1)
                    Else
                        SaveCustomer(0)
                    End If
                Else
                    MsgBox("Branch must be 5 characters")
                End If
            Else
                MsgBox("Tax ID must be 13 characters")
            End If
        End If
        If togFactory.Checked = False and togCustomer.Checked = True Then
            If a = "13" Then
                If b = "5" Then
                    If _IsNew = True Then
                        SaveCustomer(1)
                    Else
                        SaveCustomer(0)
                    End If
                Else
                    MsgBox("Branch must be 5 characters")
                End If
            Else
                MsgBox("Tax ID must be 13 characters")
            End If
        End If
        If togFactory.Checked = True and togCustomer.Checked = False Then
            If a = "13" Then
                If b = "5" Then
                    If _IsNew = True Then
                        SaveCustomer(1)
                    Else
                        SaveCustomer(0)
                    End If
                Else
                    MsgBox("Branch must be 5 characters")
                End If
            Else
                MsgBox("Tax ID must be 13 characters")
            End If
        End If
        If togFactory.Checked = False and togCustomer.Checked = False Then
            MsgBox("Must Choose between Factory and Customer or both")
        End If

    End Sub
    Private Sub RunCustomerID()
        GetRunningFormat("CUSTOMER")
        txtCustCompanyID.Text = CreateNumber("Mas_CustomerFreight", "CustCompanyID", dtpCustDate.Value)
    End Sub
    Private Sub addNewCustomer()
        txtIdent.Text = "0" 'Ident
        txtCustTaxID.Text = "0000000000000" 'CustTaxID
        txtCustCompanyID.ResetText() 'CustCompanyID
        txtCustBranch.Text = "00000" 'CustBranch
        txtCustCompanyName.ResetText() 'CustCompanyName
        txtCustCountry.ResetText() 'CustCountry
        txtCustCity.ResetText() 'CustCity
        txtCustaddress.ResetText() 'Custaddress
        txtCustEmail.ResetText() 'CustEmail
        txtCustPhone.ResetText() 'CustPhone
        txtCustFax.ResetText() 'CustFax
        txtCustPayable.Text = "0" 'CustPayable
        togFactory.CheckState = False
        togCustomer.CheckState = False
        _IsNew = True
    End Sub
    Private Sub LoadCustTodgv()
        Try
            dgvCust.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Mas_CustomerFreight where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvCust.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'CustTaxID
                    dt.Rows(i)(2).ToString(), 'CustCompanyID
                    dt.Rows(i)(3).ToString(), 'CustBranch
                    dt.Rows(i)(4).ToString(), 'CustCompanyName
                    dt.Rows(i)(5).ToString(), 'CustCountry
                    dt.Rows(i)(6).ToString(), 'CustCity
                    dt.Rows(i)(7).ToString(), 'Custaddress
                    dt.Rows(i)(8).ToString(), 'CustEmail
                    dt.Rows(i)(9).ToString(), 'CustPhone
                    dt.Rows(i)(10).ToString(), 'CustFax
                    dt.Rows(i)(11).ToString(), 'CustPayable
                    dt.Rows(i)(12).ToString(), 'Factory
                    dt.Rows(i)(13).ToString(), 'Customer
                    dt.Rows(i)(14).ToString(),
                    dt.Rows(i)(15).ToString()
                    )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvCust_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvCust.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvCust.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdent.Text = CInt(dgvCust.CurrentRow.Cells(0).Value.ToString()) 'Ident
                txtCustTaxID.Text = dgvCust.CurrentRow.Cells(1).Value.ToString() 'CustTaxID
                txtCustCompanyID.Text = dgvCust.CurrentRow.Cells(2).Value.ToString() 'CustCompanyID
                txtCustBranch.Text = dgvCust.CurrentRow.Cells(3).Value.ToString() 'CustBranch
                txtCustCompanyName.Text = dgvCust.CurrentRow.Cells(4).Value.ToString() 'CustCompanyName
                txtCustCountry.Text = dgvCust.CurrentRow.Cells(5).Value.ToString() 'CustCountry
                txtCustCity.Text = dgvCust.CurrentRow.Cells(6).Value.ToString() 'CustCity
                txtCustaddress.Text = dgvCust.CurrentRow.Cells(7).Value.ToString() 'Custaddress
                txtCustEmail.Text = dgvCust.CurrentRow.Cells(8).Value.ToString() 'CustEmail
                txtCustPhone.Text = dgvCust.CurrentRow.Cells(9).Value.ToString() 'CustPhone
                txtCustFax.Text = dgvCust.CurrentRow.Cells(10).Value.ToString() 'CustFax
                txtCustPayable.Text = dgvCust.CurrentRow.Cells(11).Value.ToString() 'CustPayable
                togFactory.Checked = CInt(dgvCust.CurrentRow.Cells(12).Value.ToString()) 'CustFactory
                togCustomer.Checked = CInt(dgvCust.CurrentRow.Cells(13).Value.ToString()) 'CustCustomer
                txtSysUserName.Text = dgvCust.CurrentRow.Cells(14).Value.ToString()
                txtSysUser.Text = dgvCust.CurrentRow.Cells(15).Value.ToString()
                _IsNew = False
            End If
        Catch ex as Exception

        End Try

    End Sub
    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        addNewCustomer()
    End Sub
    Private Sub txtCustCountry_ButtonClick(sender as Object, e as Eventargs) Handles txtCustCountry.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [CountryName] from Mas_Country where 1=1 order by CountryName", MainConnection)
        If isSearchOK Then
            txtCustCountry.Text = dr("CountryName").ToString
        End If
    End Sub
    Private Sub txtCustTaxID_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtCustTaxID.KeyPress
        CheckNumeric(e)
    End Sub
    Private Sub txtCustBranch_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtCustBranch.KeyPress
        CheckNumeric(e)

    End Sub

    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click
        Dim dr as DataRow
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
      ,[CustEAddress],[Ident]
      from Mas_CustomerFreight where 1=1 order by CustCompanyID", MainConnection)
        If isSearchOK Then
            txtCustTaxID.Text = dr("CustTaxID").ToString
            txtCustCompanyID.Text = dr("CustCompanyID").ToString
            txtCustBranch.Text = dr("CustBranch").ToString
            txtCustCompanyName.Text = dr("CustCompanyName").ToString
            txtCustCountry.Text = dr("CustCountry").ToString
            txtCustCity.Text = dr("CustCity").ToString
            txtCustaddress.Text = dr("Custaddress").ToString
            txtCustEmail.Text = dr("CustEmail").ToString
            txtCustPhone.Text = dr("CustPhone").ToString
            txtCustFax.Text = dr("CustFax").ToString
            txtCustPayable.Text = dr("CustPayable").ToString
            togFactory.CheckState = CInt(dr("CustFactory").ToString)
            togCustomer.CheckState = CInt(dr("CustCustomer").ToString)
            txtCustCompanyEName.Text = dr("CustCompanyEName").ToString
            txtCustEaddress.Text = dr("CustEAddress").ToString
            txtIdent.Text = dr("Ident").ToString
            _IsNew = False
        End If
    End Sub

    Private Sub txtSysUser_ButtonClick(sender as Object, e as Eventargs) Handles txtSysUser.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT UCode, UFName from Sys_UserSystem where 1=1", MainConnection)
        If isSearchOK Then
            txtSysUser.Text = dr("UCode").ToString
            txtSysUserName.Text = dr("UFName").ToString
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub
End Class