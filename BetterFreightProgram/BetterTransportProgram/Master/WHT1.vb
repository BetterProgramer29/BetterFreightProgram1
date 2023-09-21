Imports System.Collections.Specialized.BitVector32
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Public Class WHT1
    Private _PatyTaxType as Integer
    Private _FormType as Integer
    Public _IsNew as Boolean
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If chkPayTaxType4.Checked = True Then
            If String.IsNullOrEmpty(txtPayTaxOther.Text) Then
                MetroFramework.MetroMessageBox.Show(Me, "ระบุข้อความอื่นๆ", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtPayTaxOther.Focus()
                Exit Sub
            End If
        End If
        If txtDocControlNO.Text = "" Then
            GetRunningFormat("WHT")
            txtDocControlNO.Text = CreateNumber("Freight_WHT", "DocControlNo", dtpDocDate.Value)
        Else

        End If
        If txtDocNo.Text = "" Then
            If cboFormType.Text = "ภ.ง.ด. 1ก." Then
                GetRunningFormat("PND1a")
                txtDocNo.Text = CreateNumber("Freight_WHT", "DocNo", dtpDocDate.Value)
            ElseIf cboFormType.Text = "ภ.ง.ด. 1ก.พิเศษ" Then
                GetRunningFormat("PND1as")
                txtDocNo.Text = CreateNumber("Freight_WHT", "DocNo", dtpDocDate.Value)
            ElseIf cboFormType.Text = "ภ.ง.ด. 2" Then
                GetRunningFormat("PND2")
                txtDocNo.Text = CreateNumber("Freight_WHT", "DocNo", dtpDocDate.Value)
            ElseIf cboFormType.Text = "ภ.ง.ด. 2ก." Then
                GetRunningFormat("PND2a")
                txtDocNo.Text = CreateNumber("Freight_WHT", "DocNo", dtpDocDate.Value)
            ElseIf cboFormType.Text = "ภ.ง.ด. 3" Then
                GetRunningFormat("PND3")
                txtDocNo.Text = CreateNumber("Freight_WHT", "DocNo", dtpDocDate.Value)
            ElseIf cboFormType.Text = "ภ.ง.ด. 3ก." Then
                GetRunningFormat("PND3a")
                txtDocNo.Text = CreateNumber("Freight_WHT", "DocNo", dtpDocDate.Value)
            ElseIf cboFormType.Text = "ภ.ง.ด. 53" Then
                GetRunningFormat("PND53")
                txtDocNo.Text = CreateNumber("Freight_WHT", "DocNo", dtpDocDate.Value)
            ElseIf cboFormType.Text = "ภ.ง.ด. 53 (กระทำการแทน)" Then
                GetRunningFormat("PND53s")
                txtDocNo.Text = CreateNumber("Freight_WHT", "DocNo", dtpDocDate.Value)
            End If
        Else

        End If
        If _IsNew = True Then
            'txtDocNo.Text = CreateNumber("INF_WHTax", "DocNo", txtDocNo.Text)
            'txtDocControlNO.Text = CreateNumber("INF_WHTax", "DocControlNO", txtDocControlNO.Text)
            If txtDocNo.Text = "ERROR" Or txtDocControlNO.Text = "ERROR" Then
                MsgBox("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้ กรุณารีสตาร์ทโปรแกรม")
                Exit Sub
            End If
            'Save Method
            MsgBox(_IsNew)
            SaveWHT(1)
        Else
            MsgBox(_IsNew)
            SaveWHT(0)
        End If
    End Sub
    Private Sub SaveWHT(_insert As Integer)
        Try

            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_WHT ")
            SQLcommand.Append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.Append(",'" & cboFormType.Text & "'") 'FormType
            SQLcommand.Append(",'" & txtDocControlNO.Text & "'") 'DocControlNo
            SQLcommand.Append(",'" & CDate(dtpDocDate.Value) & "'") 'DocDate
            SQLcommand.Append(",'" & txtDocNo.Text & "'") 'DocNo
            SQLcommand.Append(",'" & txtSysUser.Text & "'") 'SysUser
            SQLcommand.Append(",'" & txtTBrCode1.Text & "'") 'TBrCode1
            SQLcommand.Append(",'" & txtTName1.Text & "'") 'TName1
            SQLcommand.Append(",'" & txtTaddress1.Text & "'") 'TAddress1
            SQLcommand.Append(",'" & txtIDCard1.Text & "'") 'IDCard1
            SQLcommand.Append(",'" & txtTaxNumber1.Text & "'") 'TaxNumber1
            SQLcommand.Append(",'" & txtTBrCode2.Text & "'") 'TBrCode2
            SQLcommand.Append(",'" & txtTName2.Text & "'") 'TName2
            SQLcommand.Append(",'" & txtTaddress2.Text & "'") 'TAddress2
            SQLcommand.Append(",'" & txtIDCard2.Text & "'") 'IDCard2
            SQLcommand.Append(",'" & txtTaxNumber2.Text & "'") 'TaxNumber2
            SQLcommand.Append(",'" & txtTBrCode3.Text & "'") 'TBrCode3
            SQLcommand.Append(",'" & txtTName3.Text & "'") 'TName3
            SQLcommand.Append(",'" & txtTaddress3.Text & "'") 'TAddress3
            SQLcommand.Append(",'" & txtIDCard3.Text & "'") 'IDCard3
            SQLcommand.Append(",'" & txtTaxNumber3.Text & "'") 'TaxNumber3
            SQLcommand.Append(",'" & CInt(chkPayTaxType1.CheckState) & "'") 'PayTaxType1
            SQLcommand.Append(",'" & CInt(chkPayTaxType2.CheckState) & "'") 'PayTaxType2
            SQLcommand.Append(",'" & CInt(chkPayTaxType3.CheckState) & "'") 'PayTaxType3
            SQLcommand.Append(",'" & CInt(chkPayTaxType4.CheckState) & "'") 'PayTaxType4
            SQLcommand.Append(",'" & txtPayTaxOther.Text & "'") 'PayTaxOther
            SQLcommand.Append(",'" & CDbl(txtTotalPayamount.Text) & "'") 'TotalPayAmount
            SQLcommand.Append(",'" & CDbl(txtTotalPayTax.Text) & "'") 'TotalPayTax
            SQLcommand.Append(",'" & txtDocRefNo.Text & "'") 'DocRefNo
            SQLcommand.Append(",'" & txtJobRefNo.Text & "'") 'JobRefNo
            SQLcommand.Append(",'" & txtCancelReason.Text & "'") 'CancelReason
            SQLcommand.Append(",'" & txtActive.Text & "'") 'Active
            SQLcommand.Append(",'" & _insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                SaveWhtDetail()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveWhtDetail()
        Try

            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a As Integer = 0
            For row As Integer = 0 To dgvWHT.Rows.Count - 1
                'If dgvWHT.Rows(row).Cells(18).Value.ToString = "1" Then
                Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_WHTDetail ")
                SQLcommand.AppendLine("'" & CInt(dgvWHT.Rows(row).Cells(0).Value).ToString() & "',") ' Ident
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(1).Value.ToString() & "',") ' DocCreateNo
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(2).Value.ToString() & "',") ' VendorName
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(3).Value.ToString() & "',") ' AdvNo
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(4).Value.ToString() & "',") ' BFTNo
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(5).Value.ToString() & "',") ' BookingNo
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(6).Value.ToString() & "',") ' MasterBLNo
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(7).Value.ToString() & "',") ' HouseBLNo
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(8).Value.ToString() & "',") ' SICode
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(9).Value.ToString() & "',") ' PVDescription
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(10).Value.ToString() & "',") ' PVRemark
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(11).Value.ToString() & "',") ' ReceiptNo
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(12).Value.ToString() & "',") ' Qty
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(13).Value.ToString() & "',") ' PVDetailType
                SQLcommand.AppendLine("'" & CInt(dgvWHT.Rows(row).Cells(14).Value).ToString() & "',") ' Currency
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(15).Value.ToString() & "',") ' ExchangeRate
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(16).Value.ToString() & "',") ' PVUnitAmount
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(17).Value.ToString() & "',") ' ChargeAmount
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(18).Value.ToString() & "',") ' ChangeVAT
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(19).Value.ToString() & "',") ' ChangeWHT
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(20).Value.ToString() & "',") ' TotalAmount
                SQLcommand.AppendLine("'" & dgvWHT.Rows(row).Cells(21).Value.ToString() & "',") ' AdvAmount
                SQLcommand.AppendLine("'" & CDbl(dgvWHT.Rows(row).Cells(22).Value).ToString() & "',") ' NetTotalAmount
                SQLcommand.AppendLine("'" & CDbl(dgvWHT.Rows(row).Cells(23).Value).ToString() & "',") ' NetPayment
                SQLcommand.AppendLine("'" & CDbl(dgvWHT.Rows(row).Cells(24).Value).ToString() & "',") ' ROWNo
                SQLcommand.AppendLine("'" & CDbl(dgvWHT.Rows(row).Cells(25).Value).ToString() & "',") ' InvoiceNo
                SQLcommand.AppendLine("'" & txtDocControlNO.Text & "',") ' DocControlNo
                SQLcommand.AppendLine("'" & txtDocNo.Text & "')") ' DocNo

                Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                If result = 1 Then
                Else
                    a += 1
                End If
                'End If
            Next
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub WHT1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtDocControlNO.Text = "" Then
            _IsNew = True
            MsgBox(_IsNew)
            'LoadDataWHTHeader()
        Else
            _IsNew = False
            MsgBox(_IsNew)
            'LoadDataDummy(txtDocRefNo.Text)
        End If

        'CalTotalWht()

    End Sub
    Private Sub LoadDataDummyDetail()
        Try
            dgvWHT.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM V_WHTDumDetail where 1=1"
            str &= " aND [DocNo]='" & txtDocRefNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvWHT.Rows.Add("0", 'TbIdnt
                    dt.Rows(i)("BranchCode").ToString(), 'BranchCode
                    dt.Rows(i)("DocNo").ToString(), 'DocNo
                    i + 1, 'ItemNo
                    dt.Rows(i)("IncType").ToString(), 'IncType
                    LetDate(dt.Rows(i)("PayDate").ToString()), 'PayDate
                    CDbl(dt.Rows(i)("Payamount").ToString()).ToString("#,##0.00"), 'Payamount
                    CDbl(dt.Rows(i)("PayTax").ToString()).ToString("#,##0.00"), 'PayTax
                    dt.Rows(i)("PayTaxDesc").ToString(), 'PayTaxDesc
                    dt.Rows(i)("JNo").ToString(), 'JNo
                    dt.Rows(i)("DocRefType").ToString(), 'DocRefType
                    dt.Rows(i)("DocRefNo").ToString(), 'DocRefNo
                    CDbl(dt.Rows(i)("PayRate").ToString()).ToString("#,##0.00"),  'PayRate
                    "1" 'Isnew
                    )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()

                CalTotalWht()

            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataDummy(PVNo As String, Optional ByVal _type As String = "XO")
        'Try
        '    Dim str as String = ""
        '    If _type = "XO" Then
        '        str = "SELECT * FROM V_WHTDumHeader where 1=1 " 'XO
        '    Else
        '        str = "SELECT * FROM V_WHTDumHeadera where 1=1 " 'XC
        '    End If
        '    str &= " aND DocRefNo='" & PVNo & "'"
        '    Dim dr as DataRow = SelectSingleRow(str)
        '    If dr IsNot Nothing Then
        '        'togPVHeaderIDent.Checked = CInt(dr("PVHeaderIDent").ToString()) 'PVHeaderIDent
        '        'txtPFCode.Text = dr("PFCode").ToString 'PFCode
        '        ' txtDocNo.Text = dr("DocNo").ToString 'DocNo
        '        'txtDocDate.Text = dr("DocDate").ToString 'DocDate
        '        txtDocTime.Text = Now.Date.ToShortTimeString
        '        txtSysUser.Text = UserProfile.U_FName & " " & UserProfile.U_LName
        '        ' txtDocControlNO.Text = dr("DocControlNO").ToString 'DocControlNO
        '        GetRunningFormat("WHT")
        '        txtDocControlNO.Text = RunningForm.Run_Formatt
        '        txtBranchCode.Text = dr("BranchCode").ToString 'BranchCode
        '        'txtBranchName.Text = dr("BranchName").ToString 'BranchName
        '        txtIDCard1.Text = dr("IDCard1").ToString 'IDCard1
        '        txtTaxNumber1.Text = dr("TaxNumber1").ToString 'TaxNumber1
        '        txtTBrCode1.Text = dr("TBrCode1").ToString 'TBrCode1
        '        txtTName1.Text = dr("TName1").ToString 'TName1
        '        txtTaddress1.Text = dr("Taddress1").ToString 'Taddress1
        '        txtIDCard2.Text = dr("IDCard2").ToString 'IDCard2
        '        txtTaxNumber2.Text = dr("TaxNumber2").ToString 'TaxNumber2
        '        txtTBrCode2.Text = dr("TBrCode2").ToString 'TBrCode2
        '        txtTName2.Text = dr("TName2").ToString 'TName2
        '        txtTaddress2.Text = dr("Taddress2").ToString 'Taddress2
        '        txtIDCard3.Text = dr("IDCard3").ToString 'IDCard3
        '        txtTaxNumber3.Text = dr("TaxNumber3").ToString 'TaxNumber3
        '        txtTBrCode3.Text = dr("TBrCode3").ToString 'TBrCode3
        '        txtTName3.Text = dr("TName3").ToString 'TName3
        '        txtTaddress3.Text = dr("Taddress3").ToString 'Taddress3
        '        'txtSeqInForm.Text = dr("SeqInForm").ToString 'SeqInForm
        '        'txtFormType.Text = dr("FormType").ToString 'FormType
        '        Select Case dr("FormType").ToString
        '            Case "1"
        '                cboFormType.SelectedIndex = 0
        '                _FormType = 1
        '                GetRunningFormat("PND1a")
        '                txtDocNo.Text = RunningForm.Run_Formatt
        '            Case "2"
        '                cboFormType.SelectedIndex = 1
        '                _FormType = 2
        '                GetRunningFormat("PND1as")
        '                txtDocNo.Text = RunningForm.Run_Formatt
        '            Case "3"
        '                cboFormType.SelectedIndex = 2
        '                _FormType = 3
        '                GetRunningFormat("PND2")
        '                txtDocNo.Text = RunningForm.Run_Formatt
        '            Case "4"
        '                cboFormType.SelectedIndex = 3
        '                _FormType = 4
        '                GetRunningFormat("PND2a")
        '                txtDocNo.Text = RunningForm.Run_Formatt
        '            Case "5"
        '                cboFormType.SelectedIndex = 4
        '                _FormType = 5
        '                GetRunningFormat("PND3")
        '                txtDocNo.Text = RunningForm.Run_Formatt
        '            Case "6"
        '                cboFormType.SelectedIndex = 5
        '                _FormType = 6
        '                GetRunningFormat("PND3a")
        '                txtDocNo.Text = RunningForm.Run_Formatt
        '            Case "7"
        '                cboFormType.SelectedIndex = 6
        '                _FormType = 7
        '                GetRunningFormat("PND53")
        '                txtDocNo.Text = RunningForm.Run_Formatt
        '            Case "8"
        '                cboFormType.SelectedIndex = 7
        '                _FormType = 8
        '                GetRunningFormat("PND53a")
        '                txtDocNo.Text = RunningForm.Run_Formatt
        '            Case Else
        '                cboFormType.SelectedIndex = 0
        '                _FormType = 9
        '                GetRunningFormat("PND1a")
        '                txtDocNo.Text = RunningForm.Run_Formatt
        '        End Select
        '        'txtTaxLawNo.Text = dr("TaxLawNo").ToString 'TaxLawNo
        '        'txtIncRate.Text = dr("IncRate").ToString 'IncRate
        '        'txtIncOther.Text = dr("IncOther").ToString 'IncOther
        '        txtTotalPayamount.Text = dr("TotalPayamount").ToString 'TotalPayamount
        '        txtTotalPayTax.Text = dr("TotalPayTax").ToString 'TotalPayTax
        '        'txtSoLicenseNo.Text = dr("SoLicenseNo").ToString 'SoLicenseNo
        '        'txtSoLicenseamount.Text = dr("SoLicenseamount").ToString 'SoLicenseamount
        '        'txtSoaccamount.Text = dr("Soaccamount").ToString 'Soaccamount
        '        'txtPayeeaccNo.Text = dr("PayeeaccNo").ToString 'PayeeaccNo
        '        'txtSoTaxNo.Text = dr("SoTaxNo").ToString 'SoTaxNo
        '        'txtPayTaxType.Text = dr("PayTaxType").ToString 'PayTaxType
        '        txtCancelReason.ResetText()
        '        Select Case dr("PayTaxType").ToString
        '            Case "1"
        '                _PatyTaxType = 1
        '                chkPayTaxType1.Checked = True
        '                chkPayTaxType2.Checked = False
        '                chkPayTaxType3.Checked = False
        '                chkPayTaxType4.Checked = False
        '            Case "2"
        '                _PatyTaxType = 2
        '                chkPayTaxType1.Checked = False
        '                chkPayTaxType2.Checked = True
        '                chkPayTaxType3.Checked = False
        '                chkPayTaxType4.Checked = False
        '            Case "3"
        '                _PatyTaxType = 3
        '                chkPayTaxType1.Checked = False
        '                chkPayTaxType2.Checked = False
        '                chkPayTaxType3.Checked = True
        '                chkPayTaxType4.Checked = False
        '            Case "4"
        '                _PatyTaxType = 4
        '                chkPayTaxType1.Checked = False
        '                chkPayTaxType2.Checked = False
        '                chkPayTaxType3.Checked = False
        '                chkPayTaxType4.Checked = True
        '            Case Else
        '                _PatyTaxType = 1
        '                chkPayTaxType1.Checked = True
        '                chkPayTaxType2.Checked = False
        '                chkPayTaxType3.Checked = False
        '                chkPayTaxType4.Checked = False
        '        End Select
        '        txtPayTaxOther.Text = dr("PayTaxOther").ToString 'PayTaxOther
        '        'txtTeacheramt.Text = dr("Teacheramt").ToString 'Teacheramt
        '        txtDocRefNo.Text = dr("DocRefNo").ToString 'DocRefNo
        '        txtJobRefNo.Text = dr("JobRefNo").ToString 'JobRefNo
        '        'txtTypeY.Text = dr("TypeY").ToString 'TypeY
        '        _IsNew = True
        '        btncancel.Enabled = True
        '        btnPrint.Enabled = True
        '        btnSave.Enabled = True
        '        LoadDataDummyDetail()
        '    End If
        '    'da = Nothing
        '    'dt = Nothing
        '    'nection.Close()
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error : " & ex.Message, "รายงานผล", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub btnaddnew_Click(sender As Object, e As EventArgs) Handles btnaddnew.Click
        addNewData()
        dgvWHT.Rows.Clear()
    End Sub
    Private Sub addNewData()
        ' togPVHeaderIDent.Checked = False 'PVHeaderIDent
        '  txtPFCode.ResetText() 'PFCode
        txtDocNo.ResetText() 'DocNo
        dtpDocDate.ResetText() 'DocDate
        txtDocTime.Text = Now.Date.ToShortTimeString
        txtDocControlNO.ResetText() 'DocControlNO
        'txtBranchCode.Text = CMPProfile.PROF_BrCode  'BranchCode
        txtIdent.Text = "0"
        'txtBranchName.ResetText() 'BranchName
        txtIDCard1.ResetText() 'IDCard1
        txtTaxNumber1.ResetText() 'TaxNumber1
        txtTBrCode1.ResetText() 'TBrCode1
        txtTName1.ResetText() 'TName1
        txtTaddress1.ResetText() 'Taddress1
        txtIDCard2.ResetText() 'IDCard2
        txtTaxNumber2.ResetText() 'TaxNumber2
        txtTBrCode2.ResetText() 'TBrCode2
        txtTName2.ResetText() 'TName2
        txtTaddress2.ResetText() 'Taddress2
        txtIDCard3.ResetText() 'IDCard3
        txtTaxNumber3.ResetText() 'TaxNumber3
        txtTBrCode3.ResetText() 'TBrCode3
        txtTName3.ResetText() 'TName3
        txtTaddress3.ResetText() 'Taddress3
        'txtSeqInForm.ResetText() 'SeqInForm
        'txtFormType.ResetText() 'FormType
        'txtTaxLawNo.ResetText() 'TaxLawNo
        'txtIncRate.ResetText() 'IncRate
        'txtIncOther.ResetText() 'IncOther
        txtTotalPayamount.Text = "0.00" 'TotalPayamount
        txtTotalPayTax.Text = "0.00" 'TotalPayTax
        'txtSoLicenseNo.ResetText() 'SoLicenseNo
        'txtSoLicenseamount.ResetText() 'SoLicenseamount
        'txtSoaccamount.ResetText() 'Soaccamount
        'txtPayeeaccNo.ResetText() 'PayeeaccNo
        'txtSoTaxNo.ResetText() 'SoTaxNo
        'txtPayTaxType.ResetText() 'PayTaxType
        chkPayTaxType1.Checked = True
        txtPayTaxOther.ResetText() 'PayTaxOther
        '  txtTeacheramt.ResetText() 'Teacheramt
        txtDocRefNo.ResetText() 'DocRefNo
        txtJobRefNo.ResetText() 'JobRefNo
        ' txtTypeY.ResetText() 'TypeY
        txtCancelReason.ResetText()
        GetRunningFormat("WHT")
        txtDocControlNO.Text = RunningForm.Run_Formatt
        cboFormType.SelectedIndex = 0
        GetRunningFormat("PND1a")
        txtDocNo.Text = RunningForm.Run_Formatt
        txtSysUser.Text = UserProfile.U_FName & " " & UserProfile.U_LName
        _IsNew = True
        btncancel.Enabled = True
        btnPrint.Enabled = True
        btnSave.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim dr As DataRow
        dr = PopUpSearch("SELECT [Ident]
        ,[DocCreateNo]
        ,[DocNoDate]
        ,[BookAccount]
        ,[PVDate]
        ,[PayFor]
        ,[VendorName]
        ,[Invoice]
        ,[InvoiceDate]
        ,[VendorBankNo]
        ,[TransferNo]
        ,[BankName]
        ,[PVNo]
        ,[PayDate]
        ,[WHTNo]
        ,[WHTUser]
        ,[NetPayment] FROM [Freight_PaymentVoucher] where 1=1 ", MainConnection)
        If isSearchOK Then
            txtDocRefNo.Text = dr("DocCreateNo").ToString
            LoadDataToDgv()
        End If
    End Sub
    Private Sub LoadDataToDgv()
        Try
            dgvWHT.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_PaymentVoucherDetail where DocCreateNo='" & txtDocRefNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvWHT.Rows.Add(dt.Rows(i)("Ident").ToString(), 'Ident
                    dt.Rows(i)("DocCreateNo").ToString(), 'DocCreateNo
                    dt.Rows(i)("VendorName").ToString(), 'VendorName
                    dt.Rows(i)("AdvNo").ToString(), 'AdvNo
                    dt.Rows(i)("BFTNo").ToString(), 'BFTNo
                    dt.Rows(i)("BookingNo").ToString(), 'BookingNo
                    dt.Rows(i)("MasterBLNo").ToString(), 'MasterBLNo
                    dt.Rows(i)("HouseBLNo").ToString(), 'HouseBLNo
                    dt.Rows(i)("SICode").ToString(), 'SICode
                    dt.Rows(i)("PVDescription").ToString(), 'PVDescription
                    dt.Rows(i)("PVRemark").ToString(), 'PVRemark
                    dt.Rows(i)("ReceiptNo").ToString(), 'ReceiptNo
                    dt.Rows(i)("Qty").ToString(), 'Qty
                    dt.Rows(i)("PVDetailType").ToString(), 'PVDetailType
                    dt.Rows(i)("Currency").ToString(), 'Currency
                    CDbl(dt.Rows(i)("ExchangeRate").ToString()), 'ExchangeRate
                    dt.Rows(i)("PVUnitAmount").ToString(), 'PVUnitAmount
                    dt.Rows(i)("ChargeAmount").ToString(), 'ChargeAmount
                    dt.Rows(i)("ChangeVAT").ToString(), 'ChangeVAT
                    dt.Rows(i)("ChangeWHT").ToString(), 'ChangeWHT
                    CDbl(dt.Rows(i)("TotalAmount").ToString()), 'TotalAmount
                    CDbl(dt.Rows(i)("AdvAmount").ToString()), 'AdvAmount
                    CDbl(dt.Rows(i)("NetTotalAmount").ToString()), 'NetTotalAmount
                    CDbl(dt.Rows(i)("NetPayment").ToString()),  'NetPayment
                    "",
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
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnSerchDoc.Click
        Dim dr As DataRow
        dr = PopUpSearch("SELECT [FormType]
      ,[DocControlNo]
      ,[DocDate]
      ,[DocNo]
      ,[SysUser]
      ,[TBrCode1]
      ,[TName1]
      ,[TAddress1]
      ,[IDCard1]
      ,[TaxNumber1]
      ,[TBrCode2]
      ,[TName2]
      ,[TAddress2]
      ,[IDCard2]
      ,[TaxNumber2]
      ,[TBrCode3]
      ,[TName3]
      ,[TAddress3]
      ,[IDCard3]
      ,[TaxNumber3]
      ,[PayTaxType1]
      ,[PayTaxType2]
      ,[PayTaxType3]
      ,[PayTaxType4]
      ,[PayTaxOther]
      ,[TotalPayAmount]
      ,[TotalPayTax]
      ,[DocRefNo]
      ,[JobRefNo]
      ,[CancelReason]
      ,[Active]  FROM [Freight_WHT] where 1=1 ", MainConnection)
        If isSearchOK Then
            txtIdent.Text = dr("TBIdnt").ToString
            txtDocNo.Text = dr("DocNo").ToString
            txtDocControlNO.Text = dr("DocControlNO").ToString
            LoadDataWhtDetail()
        End If
    End Sub
    Private Sub LoadDataWHTHeader()
        'Try
        '    If String.IsNullOrEmpty(txtDocControlNO.Text) Then Exit Sub
        '    Dim str as String = "SELECT * FROM INF_WHTax where 1=1 and [DocControlNO]='" & txtDocControlNO.Text & "'"
        '    Dim dr as DataRow = SelectSingleRow(str)
        '    If dr IsNot Nothing Then
        '        _IsNew = False
        '        txtTBIdnt.Text = CInt(dr("TBIdnt").ToString()) 'TBIdnt
        '        txtBranchCode.Text = dr("BranchCode").ToString 'BranchCode
        '        txtDocNo.Text = dr("DocNo").ToString 'DocNo
        '        dtpDocDate.Value = CDate(dr("DocDate").ToString) 'DocDate
        '        txtDocControlNO.Text = dr("DocControlNO").ToString 'DocControlNO
        '        txtIDCard1.Text = dr("IDCard1").ToString 'IDCard1
        '        txtTaxNumber1.Text = dr("TaxNumber1").ToString 'TaxNumber1
        '        txtTBrCode1.Text = dr("TBrCode1").ToString 'TBrCode1
        '        txtTName1.Text = dr("TName1").ToString 'TName1
        '        txtTaddress1.Text = dr("Taddress1").ToString 'Taddress1
        '        txtIDCard2.Text = dr("IDCard2").ToString 'IDCard2
        '        txtTaxNumber2.Text = dr("TaxNumber2").ToString 'TaxNumber2
        '        txtTBrCode2.Text = dr("TBrCode2").ToString 'TBrCode2
        '        txtTName2.Text = dr("TName2").ToString 'TName2
        '        txtTaddress2.Text = dr("Taddress2").ToString 'Taddress2
        '        txtIDCard3.Text = dr("IDCard3").ToString 'IDCard3
        '        txtTaxNumber3.Text = dr("TaxNumber3").ToString 'TaxNumber3
        '        txtTBrCode3.Text = dr("TBrCode3").ToString 'TBrCode3
        '        txtTName3.Text = dr("TName3").ToString 'TName3
        '        txtTaddress3.Text = dr("Taddress3").ToString 'Taddress3
        '        'togSeqInForm.Checked = CInt(dr("SeqInForm").ToString()) 'SeqInForm
        '        'togFormType.Checked = CInt(dr("FormType").ToString()) 'FormType
        '        Select Case dr("FormType").ToString
        '            Case "1"
        '                cboFormType.SelectedIndex = 0
        '                _FormType = 1
        '            Case "2"
        '                cboFormType.SelectedIndex = 1
        '                _FormType = 2
        '            Case "3"
        '                cboFormType.SelectedIndex = 2
        '                _FormType = 3
        '            Case "4"
        '                cboFormType.SelectedIndex = 3
        '                _FormType = 4
        '            Case "5"
        '                cboFormType.SelectedIndex = 4
        '                _FormType = 5
        '            Case "6"
        '                cboFormType.SelectedIndex = 5
        '                _FormType = 6
        '            Case "7"
        '                cboFormType.SelectedIndex = 6
        '                _FormType = 7
        '            Case "8"
        '                cboFormType.SelectedIndex = 7
        '                _FormType = 8
        '            Case Else
        '                cboFormType.SelectedIndex = 0
        '                _FormType = 9
        '        End Select
        '        'txtTaxLawNo.Text = dr("TaxLawNo").ToString 'TaxLawNo
        '        'txtIncRate.Text = dr("IncRate").ToString 'IncRate
        '        'txtIncOther.Text = dr("IncOther").ToString 'IncOther
        '        'txtUpdateBy.Text = dr("UpdateBy").ToString 'UpdateBy
        '        txtTotalPayamount.Text = CDbl(dr("TotalPayamount").ToString).ToString("#,##0.00") 'TotalPayamount
        '        txtTotalPayTax.Text = CDbl(dr("TotalPayTax").ToString).ToString("#,##0.00")  'TotalPayTax
        '        'txtSoLicenseNo.Text = dr("SoLicenseNo").ToString 'SoLicenseNo
        '        'txtSoLicenseamount.Text = dr("SoLicenseamount").ToString 'SoLicenseamount
        '        'txtSoaccamount.Text = dr("Soaccamount").ToString 'Soaccamount
        '        'txtPayeeaccNo.Text = dr("PayeeaccNo").ToString 'PayeeaccNo
        '        'txtSoTaxNo.Text = dr("SoTaxNo").ToString 'SoTaxNo
        '        'togPayTaxType.Checked = CInt(dr("PayTaxType").ToString()) 'PayTaxType
        '        Select Case dr("PayTaxType").ToString
        '            Case "1"
        '                _PatyTaxType = 1
        '                chkPayTaxType1.Checked = True
        '                chkPayTaxType2.Checked = False
        '                chkPayTaxType3.Checked = False
        '                chkPayTaxType4.Checked = False
        '            Case "2"
        '                _PatyTaxType = 2
        '                chkPayTaxType1.Checked = False
        '                chkPayTaxType2.Checked = True
        '                chkPayTaxType3.Checked = False
        '                chkPayTaxType4.Checked = False
        '            Case "3"
        '                _PatyTaxType = 3
        '                chkPayTaxType1.Checked = False
        '                chkPayTaxType2.Checked = False
        '                chkPayTaxType3.Checked = True
        '                chkPayTaxType4.Checked = False
        '            Case "4"
        '                _PatyTaxType = 4
        '                chkPayTaxType1.Checked = False
        '                chkPayTaxType2.Checked = False
        '                chkPayTaxType3.Checked = False
        '                chkPayTaxType4.Checked = True
        '            Case Else
        '                _PatyTaxType = 1
        '                chkPayTaxType1.Checked = True
        '                chkPayTaxType2.Checked = False
        '                chkPayTaxType3.Checked = False
        '                chkPayTaxType4.Checked = False
        '        End Select
        '        txtPayTaxOther.Text = dr("PayTaxOther").ToString 'PayTaxOther
        '        'txtCancelProve.Text = dr("CancelProve").ToString 'CancelProve
        '        txtCancelReason.Text = dr("CancelReason").ToString 'CancelReason
        '        'txtCancelDate.Text = dr("CancelDate").ToString 'CancelDate
        '        'txtLastUpdate.Text = dr("LastUpdate").ToString 'LastUpdate
        '        'txtTeacheramt.Text = dr("Teacheramt").ToString 'Teacheramt
        '        txtDocRefNo.Text = dr("DocRefNo").ToString 'DocRefNo
        '        txtJobRefNo.Text = dr("JobRefNo").ToString 'JobRefNo
        '        'togIsCSV.Checked = CInt(dr("IsCSV").ToString()) 'IsCSV
        '        txtSysUser.Text = dr("UpdateBy").ToString '[UpdateBy]

        '        If Not String.IsNullOrEmpty(txtCancelReason.Text) Then
        '            btncancel.Enabled = False
        '            btnPrint.Enabled = False
        '            btnSave.Enabled = False
        '        Else
        '            btncancel.Enabled = True
        '            btnPrint.Enabled = True
        '            btnSave.Enabled = True
        '        End If


        '        LoadDataWhtDetail()
        '    End If
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error : " & ex.Message, "รายงานผล", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try

    End Sub
    Private Sub LoadDataWhtDetail()
        Try
            dgvWHT.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM [INF_WHTaxDetail] where 1=1"
            str &= " aND [DocNo]='" & txtDocControlNO.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvWHT.Rows.Add(dt.Rows(i)("TbIdnt").ToString(), 'TbIdnt
                    dt.Rows(i)("BranchCode").ToString(), 'BranchCode
                    dt.Rows(i)("DocNo").ToString(), 'DocNo
                    dt.Rows(i)("ItemNo").ToString(), 'ItemNo
                    dt.Rows(i)("IncType").ToString(), 'IncType
                    LetDate(dt.Rows(i)("PayDate").ToString()), 'PayDate
                    CDbl(dt.Rows(i)("Payamount").ToString()).ToString("#,##0.00"), 'Payamount
                    CDbl(dt.Rows(i)("PayTax").ToString()).ToString("#,##0.00"), 'PayTax
                    dt.Rows(i)("PayTaxDesc").ToString(), 'PayTaxDesc
                    dt.Rows(i)("JNo").ToString(), 'JNo
                    dt.Rows(i)("DocRefType").ToString(), 'DocRefType
                    dt.Rows(i)("DocRefNo").ToString(), 'DocRefNo
                    CDbl(dt.Rows(i)("PayRate").ToString()).ToString("#,##0.00"),  'PayRate
                    "0" 'Isnew
                    )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
                CalTotalWht()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub cboFormType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFormType.SelectedIndexChanged
        'If _IsNew = False Then Exit Sub
        'Select Case cboFormType.SelectedIndex
        '    Case 0
        '        'cboFormType.SelectedIndex = 0
        '        _FormType = 1
        '        GetRunningFormat("PND1a")
        '        txtDocNo.Text = RunningForm.Run_Formatt
        '    Case 1
        '        ' cboFormType.SelectedIndex = 1
        '        _FormType = 2
        '        GetRunningFormat("PND1as")
        '        txtDocNo.Text = RunningForm.Run_Formatt
        '    Case 2
        '        'cboFormType.SelectedIndex = 2
        '        _FormType = 3
        '        GetRunningFormat("PND2")
        '        txtDocNo.Text = RunningForm.Run_Formatt
        '    Case 3
        '        'cboFormType.SelectedIndex = 3
        '        _FormType = 4
        '        GetRunningFormat("PND2a")
        '        txtDocNo.Text = RunningForm.Run_Formatt
        '    Case 4
        '        ' cboFormType.SelectedIndex = 4
        '        _FormType = 5
        '        GetRunningFormat("PND3")
        '        txtDocNo.Text = RunningForm.Run_Formatt
        '    Case 5
        '        ' cboFormType.SelectedIndex = 5
        '        _FormType = 6
        '        GetRunningFormat("PND3a")
        '        txtDocNo.Text = RunningForm.Run_Formatt
        '    Case 6
        '        ' cboFormType.SelectedIndex = 6
        '        _FormType = 7
        '        GetRunningFormat("PND53")
        '        txtDocNo.Text = RunningForm.Run_Formatt
        '    Case 7
        '        ' cboFormType.SelectedIndex = 7
        '        _FormType = 8
        '        GetRunningFormat("PND53s")
        '        txtDocNo.Text = RunningForm.Run_Formatt
        '    Case Else
        '        ' cboFormType.SelectedIndex = 0
        '        _FormType = 9
        '        GetRunningFormat("PND1a")
        '        txtDocNo.Text = RunningForm.Run_Formatt
        'End Select
    End Sub
    Private Sub CalTotalWht()
        Dim Total As Double = 0
        Dim TotalTax As Double = 0
        If dgvWHT.Rows.Count > 0 Then
            For i As Integer = 0 To dgvWHT.Rows.Count - 1
                Total += CDbl(dgvWHT.Rows(i).Cells(6).Value)
                TotalTax += CDbl(dgvWHT.Rows(i).Cells(7).Value)
            Next
            txtTotalPayamount.Text = Total.ToString("#,##0.00")
            txtTotalPayTax.Text = TotalTax.ToString("#,##0.00")
        Else
            txtTotalPayamount.Text = "0.00"
            txtTotalPayTax.Text = "0.00"
        End If
    End Sub

    Private Sub chkPayTaxType4_CheckedChanged(sender As Object, e As EventArgs) Handles chkPayTaxType4.CheckedChanged
        If chkPayTaxType4.Checked Then
            txtPayTaxOther.Enabled = True
        Else
            txtPayTaxOther.ResetText()
            txtPayTaxOther.Enabled = False
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If txtCancelReason.Text = "" Then
            MetroFramework.MetroMessageBox.Show(Me, "Input Cancel Reason First!!!", "Check Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'MsgBox("Input Cancel Reason First!!!")
            Exit Sub
        End If
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_CancelINF_WHTax ")
            SQLcommand.Append("'" & CInt(txtIdent.Text) & "'") 'TBIdnt
            SQLcommand.append(",'" & UserProfile.U_Code & "'") 'CancelProve
            SQLcommand.append(",'" & txtCancelReason.Text & "'") 'CancelReason
            SQLcommand.append(",'" & txtDocRefNo.Text & "'")
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Cancel Success ", "Cancel Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataWHTHeader()
                'btncancel.Enabled = False
                'btnPrint.Enabled = False
                'btnSave.Enabled = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Cancel Data Fail ", "Cancel Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()



        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub MetroTextBox4_ButtonClick(sender As Object, e As EventArgs) Handles MetroTextBox4.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [VenTaxID]
      ,[VendorID]
      ,[VendorBranch]
      ,[VendorName]
      ,[VendorCountry]
      ,[VendorCity]
      ,[VendorAddress]
      ,[VendorEmail]
      ,[VendorPhone]
      ,[VendorFax]
      ,[VendorPayable]
      ,[Market]
      ,[General]
      ,[VendorBankName]
      ,[VendorBankNo]
      ,[VendorTName]
      ,[VendorTAddress]  FROM Mas_VendorTransport WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtTName1.Text = dr("VendorName").ToString
            txtTaddress1.Text = dr("VendorAddress").ToString
            txtTaxNumber1.Text = dr("VenTaxID").ToString
            txtTBrCode1.Text = dr("VendorID").ToString
        End If
    End Sub

    Private Sub MetroTextBox15_ButtonClick(sender As Object, e As EventArgs) Handles MetroTextBox15.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [VenTaxID]
      ,[VendorID]
      ,[VendorBranch]
      ,[VendorName]
      ,[VendorCountry]
      ,[VendorCity]
      ,[VendorAddress]
      ,[VendorEmail]
      ,[VendorPhone]
      ,[VendorFax]
      ,[VendorPayable]
      ,[Market]
      ,[General]
      ,[VendorBankName]
      ,[VendorBankNo]
      ,[VendorTName]
      ,[VendorTAddress]  FROM Mas_VendorTransport WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtTName2.Text = dr("VendorName").ToString
            txtTaddress2.Text = dr("VendorAddress").ToString
            txtTaxNumber2.Text = dr("VenTaxID").ToString
            txtTBrCode2.Text = dr("VendorID").ToString
        End If
    End Sub

    Private Sub MetroTextBox19_ButtonClick(sender As Object, e As EventArgs) Handles MetroTextBox19.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [VenTaxID]
      ,[VendorID]
      ,[VendorBranch]
      ,[VendorName]
      ,[VendorCountry]
      ,[VendorCity]
      ,[VendorAddress]
      ,[VendorEmail]
      ,[VendorPhone]
      ,[VendorFax]
      ,[VendorPayable]
      ,[Market]
      ,[General]
      ,[VendorBankName]
      ,[VendorBankNo]
      ,[VendorTName]
      ,[VendorTAddress]  FROM Mas_VendorTransport WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtTName3.Text = dr("VendorName").ToString
            txtTaddress3.Text = dr("VendorAddress").ToString
            txtTaxNumber3.Text = dr("VenTaxID").ToString
            txtTBrCode3.Text = dr("VendorID").ToString
        End If
    End Sub
    Private Sub dgvWHT_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvWHT.RowsAdded
        'Try
        '    Dim amt As Double = 0 'ADV
        '    Dim TaxAmt As Double = 0

        '    If dgvWHT.Rows.Count > 0 Then
        '        For i As Integer = 0 To dgvWHT.Rows.Count - 1
        '            amt += dgvWHT.Rows(i).Cells(22).Value
        '            Dim NumTax As Double = CDbl(dgvWHT.Rows(i).Cells(19).Value.ToString.Substring(0, dgvWHT.Rows(i).Cells(19).Value.Text.Length - 1))
        '            TaxAmt += dgvWHT.Rows(i).Cells(22).Value * (NumTax / 100.0)

        '        Next
        '        txtTotalPayamount.Text = amt.ToString("#,##0.00")
        '        txtTotalPayTax.Text = TaxAmt.ToString("#,##0.00")
        '    Else
        '        txtTotalPayamount.Text = amt.ToString("#,##0.00")
        '        txtTotalPayTax.Text = TaxAmt.ToString("#,##0.00")
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Private Sub txtDocRefNo_TextChanged(sender As Object, e As EventArgs) Handles txtDocRefNo.TextChanged
        LoadDataToDgv()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim amt As Double = 0 'ADV
            Dim TaxAmt As Double = 0

            If dgvWHT.Rows.Count > 0 Then
                For i As Integer = 0 To dgvWHT.Rows.Count - 1
                    amt += dgvWHT.Rows(i).Cells(16).Value
                    Dim NumTax As Double = CDbl(dgvWHT.Rows(i).Cells(19).Value.ToString.Substring(0, dgvWHT.Rows(i).Cells(19).Value.Length - 1))
                    TaxAmt += dgvWHT.Rows(i).Cells(16).Value * (NumTax / 100.0)

                Next
                txtTotalPayamount.Text = amt.ToString("#,##0.00")
                txtTotalPayTax.Text = TaxAmt.ToString("#,##0.00")
            Else
                txtTotalPayamount.Text = amt.ToString("#,##0.00")
                txtTotalPayTax.Text = TaxAmt.ToString("#,##0.00")
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End Try
    End Sub
End Class