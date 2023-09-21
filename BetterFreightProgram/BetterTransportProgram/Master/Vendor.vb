Imports System.Data.OleDb
Imports System.Resources
Imports System.Text

Public Class Vendor
    Public _IsNew as Boolean
    Private Sub Vendor_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        addNewVendor()
        LoadVendorTodgv()
    End Sub

    Private Sub SaveVendor(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_VendorTransport ")
            SQLcommand.append("'" & CInt(txtIdent.Text) & "'") 'Ident
            SQLcommand.append(",'" & txtVenTaxID.Text & "'") 'VenTaxID
            SQLcommand.append(",'" & txtVendorID.Text & "'") 'VendorID
            SQLcommand.append(",'" & txtVendorBranch.Text & "'") 'VendorBranch
            SQLcommand.append(",'" & txtVendorName.Text & "'") 'VendorName
            SQLcommand.append(",'" & txtVendorCountry.Text & "'") 'VendorCountry
            SQLcommand.append(",'" & txtVendorCity.Text & "'") 'VendorCity
            SQLcommand.append(",'" & txtVendoraddress.Text & "'") 'Vendoraddress
            SQLcommand.append(",'" & txtVendorEmail.Text & "'") 'VendorEmail
            SQLcommand.append(",'" & txtVendorPhone.Text & "'") 'VendorPhone
            SQLcommand.append(",'" & txtVendorFax.Text & "'") 'VendorFax
            SQLcommand.append(",'" & txtVendorPayable.Text & "'") 'VendorPayable
            SQLcommand.append(",'" & CInt(togMarket.CheckState) & "'") 'Market
            SQLcommand.append(",'" & CInt(togGeneral.CheckState) & "'") 'General
            SQLcommand.append(",'" & txtVendorBankName.Text & "'")
            SQLcommand.Append(",'" & txtVendorBankNo.Text & "'")
            SQLcommand.Append(",'" & txtVendorTName.Text & "'")
            SQLcommand.Append(",'" & txtVendorTAddress.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadVendorTodgv()
                _IsNew = False
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub RunVendorID()
        GetRunningFormat("VENDOR")
        txtVendorID.Text = CreateNumber("Mas_VendorTransport", "VendorID", False)
    End Sub

    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        Dim a = txtVenTaxID.Text.Length.ToString
        Dim b = txtVendorBranch.Text.Length.ToString
        If a = "13" Then
            If b = "5" Then
                If togMarket.Checked = False and togGeneral.Checked = False Then
                    MsgBox("Must Choose between เจ้าหนี้การค้า and เจ้าหนี้ทั่วไป or both")
                Else
                    If txtVendorID.Text = "" Then
                        RunVendorID()
                    End If
                    If _IsNew = True Then
                        SaveVendor(1)
                    Else
                        SaveVendor(0)
                    End If
                End If
            Else
                MsgBox("Branch must be 5 characters")
            End If
        Else
            MsgBox("Tax ID must be 13 characters")
        End If

        'If togMarket.Checked = True and togGeneral.Checked = True Then
        '    If a = "13" Then
        '        If b = "5" Then
        '            If _IsNew = True Then
        '                RunVendorID()
        '                SaveVendor(1)
        '            Else
        '                SaveVendor(0)
        '            End If
        '        Else
        '            MsgBox("Branch must be 5 characters")
        '        End If
        '    Else
        '        MsgBox("Tax ID must be 13 characters")
        '    End If
        'End If
        'If togMarket.Checked = False and togGeneral.Checked = True Then
        '    If a = "13" Then
        '        If b = "5" Then
        '            If _IsNew = True Then
        '                RunVendorID()
        '                SaveVendor(1)
        '            Else
        '                SaveVendor(0)
        '            End If
        '        Else
        '            MsgBox("Branch must be 5 characters")
        '        End If
        '    Else
        '        MsgBox("Tax ID must be 13 characters")
        '    End If
        'End If
        'If togMarket.Checked = True and togGeneral.Checked = False Then
        '    If a = "13" Then
        '        If b = "5" Then
        '            If _IsNew = True Then
        '                RunVendorID()
        '                SaveVendor(1)
        '            Else
        '                SaveVendor(0)
        '            End If
        '        Else
        '            MsgBox("Branch must be 5 characters")
        '        End If
        '    Else
        '        MsgBox("Tax ID must be 13 characters")
        '    End If
        'End If

    End Sub

    Private Sub txtVendorCountry_ButtonClick(sender as Object, e as Eventargs) Handles txtVendorCountry.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [CountryName] from Mas_Country where 1=1 order by CountryName", MainConnection)
        If isSearchOK Then
            txtVendorCountry.Text = dr("CountryName").ToString
        End If
    End Sub
    Private Sub addNewVendor()
        txtIdent.Text = "0" 'Ident
        txtVenTaxID.Text = "0000000000000" 'VenTaxID
        txtVendorID.ResetText() 'VendorID
        txtVendorBranch.Text = "00000" 'VendorBranch
        txtVendorName.ResetText() 'VendorName
        txtVendorCountry.ResetText() 'VendorCountry
        txtVendorCity.ResetText() 'VendorCity
        txtVendoraddress.ResetText() 'Vendoraddress
        txtVendorEmail.ResetText() 'VendorEmail
        txtVendorPhone.ResetText() 'VendorPhone
        txtVendorFax.ResetText() 'VendorFax
        txtVendorPayable.ResetText() 'VendorPayable
        togMarket.Checked = False
        togGeneral.Checked = False
        txtVendorBankName.ResetText()
        txtVendorBankNo.ResetText()
        _IsNew = True
    End Sub
    Private Sub LoadVendorTodgv()
        Try
            dgvVendor.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Mas_VendorTransport where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvVendor.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'VenTaxID
                    dt.Rows(i)(2).ToString(), 'VendorID
                    dt.Rows(i)(3).ToString(), 'VendorBranch
                    dt.Rows(i)(4).ToString(), 'VendorName
                    dt.Rows(i)(5).ToString(), 'VendorCountry
                    dt.Rows(i)(6).ToString(), 'VendorCity
                    dt.Rows(i)(7).ToString(), 'Vendoraddress
                    dt.Rows(i)(8).ToString(), 'VendorEmail
                    dt.Rows(i)(9).ToString(), 'VendorPhone
                    dt.Rows(i)(10).ToString(), 'VendorPayable
                    dt.Rows(i)(11).ToString(),
                    dt.Rows(i)(12).ToString(),
                    dt.Rows(i)(13).ToString(),
                    dt.Rows(i)(14).ToString(),
                    dt.Rows(i)(15).ToString(),
                    dt.Rows(i)(16).ToString(),
                    dt.Rows(i)(17).ToString
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

    Private Sub dgvVendor_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvVendor.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvVendor.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdent.Text = CInt(dgvVendor.CurrentRow.Cells(0).Value.ToString()) 'Ident
                txtVenTaxID.Text = dgvVendor.CurrentRow.Cells(1).Value.ToString() 'VenTaxID
                txtVendorID.Text = dgvVendor.CurrentRow.Cells(2).Value.ToString() 'VendorID
                txtVendorBranch.Text = dgvVendor.CurrentRow.Cells(3).Value.ToString() 'VendorBranch
                txtVendorName.Text = dgvVendor.CurrentRow.Cells(4).Value.ToString() 'VendorName
                txtVendorCountry.Text = dgvVendor.CurrentRow.Cells(5).Value.ToString() 'VendorCountry
                txtVendorCity.Text = dgvVendor.CurrentRow.Cells(6).Value.ToString() 'VendorCity
                txtVendoraddress.Text = dgvVendor.CurrentRow.Cells(7).Value.ToString() 'Vendoraddress
                txtVendorEmail.Text = dgvVendor.CurrentRow.Cells(8).Value.ToString() 'VendorEmail
                txtVendorPhone.Text = dgvVendor.CurrentRow.Cells(9).Value.ToString() 'VendorPhone
                txtVendorFax.Text = dgvVendor.CurrentRow.Cells(10).Value.ToString() 'VendorFax
                txtVendorPayable.Text = dgvVendor.CurrentRow.Cells(11).Value.ToString() 'VendorPayable
                togMarket.CheckState = CInt(dgvVendor.CurrentRow.Cells(12).Value.ToString()) 'Market
                togGeneral.CheckState = CInt(dgvVendor.CurrentRow.Cells(13).Value.ToString()) 'General
                txtVendorBankName.Text = dgvVendor.CurrentRow.Cells(14).Value.ToString()
                txtVendorBankNo.Text = dgvVendor.CurrentRow.Cells(15).Value.ToString()
                txtVendorTName.Text = dgvVendor.CurrentRow.Cells(16).Value.ToString
                txtVendorTAddress.Text = dgvVendor.CurrentRow.Cells(17).Value.ToString
                _IsNew = False
            End If
        Catch ex as Exception

        End Try

    End Sub

    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        addNewVendor()
    End Sub

    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [VenTaxID]
      ,[VendorID]
      ,[VendorBranch]
      ,[VendorName]
      ,[VendorCountry]
      ,[VendorCity]
      ,[Vendoraddress]
      ,[VendorEmail]
      ,[VendorPhone]
      ,[VendorFax]
      ,[VendorPayable]
      ,[Market]
      ,[General]
      ,[VendorBankName]
      ,[VendorBankNo],Ident,VendorTName,VendorTAddress from Mas_VendorTransport where 1=1 order by VendorID", MainConnection)
        If isSearchOK Then
            txtIdent.Text = dr("Ident").ToString
            txtVenTaxID.Text = dr("VenTaxID").ToString
            txtVendorID.Text = dr("VendorID").ToString
            txtVendorBranch.Text = dr("VendorBranch").ToString
            txtVendorName.Text = dr("VendorName").ToString
            txtVendorCountry.Text = dr("VendorCountry").ToString
            txtVendorCity.Text = dr("VendorCity").ToString
            txtVendoraddress.Text = dr("Vendoraddress").ToString
            txtVendorEmail.Text = dr("VendorEmail").ToString
            txtVendorPhone.Text = dr("VendorPhone").ToString
            txtVendorFax.Text = dr("VendorFax").ToString
            txtVendorPayable.Text = dr("VendorPayable").ToString
            togGeneral.CheckState = CInt(dr("Market").ToString)
            togMarket.CheckState = CInt(dr("General").ToString)
            txtVendorBankName.Text = dr("VendorBankName").ToString
            txtVendorBankNo.Text = dr("VendorBankNo").ToString
            txtVendorTName.Text = dr("VendorTName").ToString
            txtVendorTAddress.Text = dr("VendorTAddress").ToString
            _IsNew = False
        End If
    End Sub

    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click

    End Sub
End Class