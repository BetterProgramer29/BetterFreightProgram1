Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Text

Public Class ReceiveVoucher
    Public _IsNew As Boolean
    Public _IsNewD As Boolean
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtDocCreateNo.Text = "" Then
            GetRunningFormat("REC")
            txtDocCreateNo.Text = CreateNumber("Freight_ReceiveVoucher", "DocCreateNo", txtDocCreateDate.Value)
        End If
        If _IsNew = True Then
            SaveReceiveVoucher(1)
        Else
            SaveReceiveVoucher(0)
        End If
    End Sub
    Private Sub SaveReceiveVoucher(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_ReceiveVoucher ")
            SQLcommand.Append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.Append(",'" & txtRVType.Text & "'") 'RVType
            SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'DocCreateNo
            SQLcommand.Append(",'" & CDate(txtDocCreateDate.Value) & "'") 'DocCreateDate
            SQLcommand.Append(",'" & txtBookaccount.Text & "'") 'Bookaccount
            SQLcommand.Append(",'" & txtReferenceNo.Text & "'") 'ReferenceNo
            SQLcommand.Append(",'" & CDate(txtRVReceivedMoneyDate.Value) & "'") 'RVReceivedMoneyDate
            SQLcommand.Append(",'" & txtRVNo.Text & "'") 'RVNo
            SQLcommand.Append(",'" & txtCustomerName.Text & "'") 'CustomerName
            SQLcommand.Append(",'" & txtReceivedFrom.Text & "'") 'ReceivedFrom
            SQLcommand.Append(",'" & txtChqNo.Text & "'") 'ChqNo
            SQLcommand.Append(",'" & txtBank.Text & "'") 'Bank
            SQLcommand.Append(",'" & CDate(dtpChqDate.Value) & "'") 'ChqDate
            SQLcommand.Append(",'" & txtTotalamountReceived.Text & "'") 'TotalamountReceived
            SQLcommand.Append(",'" & txtSearchInvoiceNo.Text & "'") 'SearchInvoiceNo
            SQLcommand.Append(",'" & txtBookingNo.Text & "'") 'BookingNo
            SQLcommand.Append(",'" & txtVesselBookingNo.Text & "'") 'VesselBookingNo
            SQLcommand.Append(",'" & txtMasterBLNo.Text & "'") 'MasterBLNo
            SQLcommand.Append(",'" & txtHouseBLNo.Text & "'") 'HouseBLNo
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
    Private Sub SaveReceiveVoucherDetail(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsert_RV ")
            SQLcommand.Append("'" & txtIdentD.Text & "'") 'Ident
            SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'SICode
            SQLcommand.Append(",'" & CDbl(dgvRV.CurrentRow.Cells(17).Value) & "'") 'SICodeDescription
            'SQLcommand.Append(txtIdentD.Text) 'Ident
            'SQLcommand.Append(",'" & txtDocCreateNo.Text & "'") 'SICode
            'SQLcommand.Append("," & CDbl(dgvRV.CurrentRow.Cells(17).Value)) 'SICodeDescription
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            Console.WriteLine(SQLcommand)
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNewD = False
                LoadToReceiveVoucher()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadToReceiveVoucher()
        Try
            dgvRV.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_ReceiveVoucherDetail where "
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvRV.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'SICode
                    dt.Rows(i)(2).ToString(), 'RVDescription
                    dt.Rows(i)(3).ToString(), 'Remark
                    dt.Rows(i)(4).ToString(), 'Qty
                    dt.Rows(i)(5).ToString(), 'DetailType
                    dt.Rows(i)(6).ToString(), 'Currency
                    CDbl(dt.Rows(i)(7).ToString()), 'Unitamount
                    CDbl(dt.Rows(i)(8).ToString()), 'Chargeamount
                    CDbl(dt.Rows(i)(9).ToString()), 'VaT
                    CDbl(dt.Rows(i)(10).ToString()), 'WHT
                    CDbl(dt.Rows(i)(11).ToString()), 'Totalamount
                    CDbl(dt.Rows(i)(12).ToString()), 'advamount
                    CDbl(dt.Rows(i)(13).ToString()), 'NetTotalamount
                    CDbl(dt.Rows(i)(14).ToString()),  'NetPayment
                    dt.Rows(i)(15).ToString()
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
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'If _IsNewD = True Then
        'SaveReceiveVoucherDetail(1)
        'Else
        'SaveReceiveVoucherDetail(0)
        'End If


        If txtDocCreateNo.Text = "" Then
            GetRunningFormat("REC")
            txtDocCreateNo.Text = CreateNumber("Freight_ReceiveVoucher", "DocCreateNo", txtDocCreateDate.Value)
        End If
        If _IsNew = True Then
            SaveReceiveVoucher(1)
        Else
            SaveReceiveVoucher(0)
        End If

        If dgvRV.Rows.Count > 0 Then
            For i As Integer = 0 To dgvRV.Rows.Count - 1
                dgvRV.Rows(i).Cells(34).Value = txtDocCreateNo.Text
            Next
        End If

    End Sub

    Private Sub txtSearchInvoiceNo_ButtonClick(sender As Object, e As EventArgs) Handles txtSearchInvoiceNo.ButtonClick
        Console.WriteLine("popup window")
        _IsNewD = True
        If txtRVType.Text = "สมุดบัญชีรับ-เงินสด(JOB)" Or txtRVType.Text = "สมุดบัญชีรับ-ลูกหนี้(JOB)" Then
            Dim dr As DataRow
            dr = PopUpSearch("SELECT 
            [InvoiceNo]
            ,[InvoiceDate]
            ,[BCFNo]
            ,[MasterBLNo]
            ,[VesselBooking]
            ,[TaxInvNo]
            ,[TaxInvDate]
            ,[Customer]
            ,[CustomerCode]
            ,[Customeraddress]
            ,[NameOfImportExport]
            ,[HouseBLNo]
            ,[PortOfLoading]
            ,[PortOfDischarge]
            ,[Remark]
            ,[FreightPrice]
            ,[WHTPrice]
            ,[VaTPrice]
            ,[advanceReceive]
            ,[TransportDiscount]
            ,[Totalamount]
            ,[TotalTransport]
            ,[ServiceCharge]
            ,[advVat]
            ,[Net]
            ,[advWHT]
            ,[Totaladv]
            ,[DueDate]
            ,[Payable]
            ,[Ident]
            FROM [Freight_Invoice] where 1=1", MainConnection) 'and InvoiceNo <> '' 
            If isSearchOK Then
                txtIdent.Text = dr("Ident").ToString
                'txtadvType.Text = dr("advType").ToString
                txtSearchInvoiceNo.Text = dr("InvoiceNo").ToString
                txtBCFNo.Text = dr("BCFNo").ToString
                'txtOrderNo.Text = dr("OrderNo").ToString
                'txtQty.Text = dr("Qty").ToString
                'txtSICodeDescription.Text = dr("advDescription").ToString
                'txtUnitamount.Text = dr("Unit").ToString
                'txtSICode.Text = dr("advCode").ToString
                'txtQty.Text = dr("Qty").ToString
                txtBookingNo.Text = dr("VesselBooking").ToString
                txtChargeamount.Text = dr("ServiceCharge").ToString
                txtadvamount.Text = dr("advanceReceive").ToString
                txtCustCode.Text = dr("CustomerCode").ToString
                txtWHTChange.Text = (CDbl(dr("advWHT")) * "0.01")
                txtTotalamount.Text = dr("Totalamount").ToString



                Try
                    'dgvRV.Rows.Clear()
                    Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
                    Dim dt As DataTable = New DataTable()
                    Dim nection As New OleDb.OleDbConnection()
                    nection = ConnectDB()
                    Dim str As String = "SELECT * FROM [Freight_Invoice] where InvoiceNo='" + dr("InvoiceNo").ToString + "'"

                    da.SelectCommand = New OleDbCommand(str, nection)
                    da.Fill(dt)
                    'dgvRV.DataSource = dt

                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            dgvRV.Rows.Add(dt.Rows(i)(0).ToString(),
                                   dt.Rows(i)(1).ToString(),
                                   dt.Rows(i)(2).ToString(),
                                   dt.Rows(i)(3).ToString(),
                                   dt.Rows(i)(4).ToString(),
                                   dt.Rows(i)(5).ToString(),
                                   dt.Rows(i)(6).ToString(),
                                   dt.Rows(i)(7).ToString(),
                                   dt.Rows(i)(8).ToString(),
                                   dt.Rows(i)(9).ToString(),
                                   dt.Rows(i)(10).ToString(),
                                   dt.Rows(i)(11).ToString(),
                                   dt.Rows(i)(12).ToString(),
                                   dt.Rows(i)(13).ToString(),
                                   dt.Rows(i)(14).ToString(),
                                   dt.Rows(i)(15).ToString(),
                                   dt.Rows(i)(16).ToString(),
                                   dt.Rows(i)(17).ToString(),
                                   dt.Rows(i)(18).ToString(),
                                   dt.Rows(i)(19).ToString(),
                                   dt.Rows(i)(20).ToString(),
                                   dt.Rows(i)(21).ToString(),
                                   dt.Rows(i)(22).ToString(),
                                   dt.Rows(i)(23).ToString(),
                                   dt.Rows(i)(24).ToString(),
                                   dt.Rows(i)(25).ToString(),
                                   dt.Rows(i)(26).ToString(),
                                   dt.Rows(i)(27).ToString(),
                                   dt.Rows(i)(28).ToString(),
                                   dt.Rows(i)(29).ToString(),
                                   dt.Rows(i)(30).ToString(),
                                   dt.Rows(i)(31).ToString(),
                                   dt.Rows(i)(32).ToString(),
                                   dt.Rows(i)(33).ToString())
                        Next



                        'Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                        'checkBoxColumn.HeaderText = ""
                        'checkBoxColumn.Width = 30
                        'checkBoxColumn.Name = "checkBoxColumn"
                        'dgvRV.Columns.Insert(0, checkBoxColumn)

                        da = Nothing
                        dt = Nothing
                        nection.Close()
                    End If
                Catch ex As Exception
                    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try






            End If
        End If
    End Sub

    Private Sub txtVaT_TextChanged(sender As Object, e As EventArgs) Handles txtVaTChange.TextChanged

    End Sub

    Private Sub txtWHT_TextChanged(sender As Object, e As EventArgs) Handles txtWHTChange.TextChanged

    End Sub

    Private Sub ReceiveVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadReceiveVoucherDetail()
    End Sub

    Private Sub dgvRV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRV.CellContentClick

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub


    Private Sub LoadReceiveVoucherDetail()
        Try
            dgvRV.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_ReceiveVoucherDetail"

            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvRV.Rows.Add(dt.Rows(i)(0).ToString(),
                           dt.Rows(i)(1).ToString(),
                           dt.Rows(i)(2).ToString(),
                           dt.Rows(i)(3).ToString(),
                           dt.Rows(i)(4).ToString(),
                           dt.Rows(i)(5).ToString(),
                           dt.Rows(i)(6).ToString(),
                           dt.Rows(i)(7).ToString(),
                           dt.Rows(i)(8).ToString(),
                           dt.Rows(i)(9).ToString(),
                           dt.Rows(i)(10).ToString(),
                           dt.Rows(i)(11).ToString(),
                           dt.Rows(i)(12).ToString(),
                           dt.Rows(i)(13).ToString(),
                           dt.Rows(i)(14).ToString(),
                           dt.Rows(i)(15).ToString())
                Next


                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.HeaderText = ""
                checkBoxColumn.Width = 30
                checkBoxColumn.Name = "checkBoxColumn"
                dgvRV.Columns.Insert(0, checkBoxColumn)

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub
End Class