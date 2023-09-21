Imports System.Data.OleDb
Imports System.Text
Imports MetroFramework.Drawing.MetroPaint.BorderColor

Public Class frmWhtax
    Public _IsNewPND As Boolean
    Private _PayTaxType As Integer = 0
    Private SQLFormType As String = "SELECT [CSTCode],[CSTTName] FROM [V_MasPNDType] WHERE 1=1 "
    Private SQLTaxLawNo As String = "SELECT [CSTCode],[CSTTName] FROM [V_MasMatra] WHERE 1=1 "
    Private SQLReportPND As String = "SELECT [TBIDNT],[RptDescription] FROM [MAS_RunningReport]  where [RptDocCode]='PND' and [Active]=1 and  [CMPCode]='" + CMPProfile.PROF_Code + "' and [BranchCode]='" + CMPProfile.PROF_BrCode + "'"
    Private Sub frmWhtax_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxList(cboFormType, SQLFormType, MainConnection)
        ComboBoxList(cboTaxLawNo, SQLTaxLawNo, MainConnection)
        ComboBoxList(cboPNDReport, SQLReportPND, MainConnection)

        If Not String.IsNullOrEmpty(txtDocControlNO.Text) Then
            LoadDataPNDHeader()
        Else
            AddNewPND()
        End If




    End Sub
    Private Sub btnPNDPrint_Click(sender As Object, e As EventArgs) Handles btnPNDPrint.Click
        Try
            GetReportRunning(CInt(cboPNDReport.SelectedValue))
            Dim rptname As String = RptRunning.RptreportName
            Dim Midnt As String = ""
            If String.IsNullOrEmpty(rptname) Then Exit Sub
            If txtTBIDNTPND.Text = "0" Then Exit Sub
            If RptRunning.Ident = 0 Then Exit Sub

            Dim MyUrl As String = rptname & txtDocControlNO.Text & "&ident=" & CInt(txtTBIDNTPND.Text)
            Try
                Process.Start("Chrome", MyUrl)
            Catch ex As Exception
                Process.Start(MyUrl)
            End Try
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub btnPNDSearch_Click(sender As Object, e As EventArgs) Handles btnPNDSearch.Click
        'If String.IsNullOrEmpty(cboFormType.Text) Then
        '    MetroFramework.MetroMessageBox.Show(Me, "เลือกแบบการยื่นก่อน ", "เลือกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If
        Try
            Dim dr As DataRow
            Dim str As String = "SELECT [DocControlNO],[DocNo],[DocDate],[PAYNumber],[JobRefNo],[CancelReason],[TBIDNT] FROM [INF_WHTax] WHERE 1=1 "
            If Not String.IsNullOrEmpty(txtDocRefNo.Text) Then str &= " AND DocRefNo='" & txtDocRefNo.Text & "'"

            dr = PopUpSearch(str, MainConnection)
            If isSearchOK Then
                LoadDataPNDHeader(CInt(dr("TBIDNT").ToString))
            End If

        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataPND()
        Try
            Dim str As String = "SELECT * FROM Q_INFPNDHeader where [TBIDNTPND]='" & txtTBIDNTPND.Text & "' AND TypeY='" & txtTypeY.Text & "' "
            Dim dr As DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                txtTBIDNTPND.Text = "0" ' CInt(dr("TBIDNTPND").ToString()) 'TBIDNTPND
                'txtPFCode.Text = dr("PFCode").ToString 'PFCode
                txtDocNo.Text = dr("DocNo").ToString 'DocNo
                dtpDocDate.Value = CDate(dr("DocDate").ToString) 'DocDate
                txtDocControlNO.Text = dr("DocControlNO").ToString 'DocControlNO
                ' txtBranchCode.Text = dr("BranchCode").ToString 'BranchCode
                'txtBranchName.Text = dr("BranchName").ToString 'BranchName
                txtTCode1.Text = dr("PFCode").ToString '
                txtIDCard1.Text = dr("IDCard1").ToString 'IDCard1
                txtTaxNumber1.Text = dr("TaxNumber1").ToString 'TaxNumber1
                txtTBrCode1.Text = dr("TBrCode1").ToString 'TBrCode1
                txtTName1.Text = dr("TName1").ToString 'TName1
                txtTAddress1.Text = dr("TAddress1").ToString 'TAddress1

                txtTCode2.Text = dr("CustCode").ToString 'CustCode
                txtIDCard2.Text = dr("IDCard2").ToString 'IDCard2
                txtTaxNumber2.Text = dr("TaxNumber2").ToString 'TaxNumber2
                txtTBrCode2.Text = dr("TBrCode2").ToString 'TBrCode2
                txtTName2.Text = dr("TName2").ToString 'TName2
                txtTAddress2.Text = dr("TAddress2").ToString 'TAddress2

                txtTCode3.Text = dr("VendorCode").ToString 'VendorCode
                txtIDCard3.Text = dr("IDCard3").ToString 'IDCard3
                txtTaxNumber3.Text = dr("TaxNumber3").ToString 'TaxNumber3
                txtTBrCode3.Text = dr("TBrCode3").ToString 'TBrCode3
                txtTName3.Text = dr("TName3").ToString 'TName3
                txtTAddress3.Text = dr("TAddress3").ToString 'TAddress3

                txtSeqInForm.Text = dr("SeqInForm").ToString 'SeqInForm
                cboFormType.SelectedValue = dr("FormType").ToString 'FormType
                cboTaxLawNo.SelectedValue = dr("TaxLawNo").ToString 'TaxLawNo
                'txtIncRate.Text = dr("IncRate").ToString 'IncRate
                'txtIncOther.Text = dr("IncOther").ToString 'IncOther
                txtTotalPayAmount.Text = dr("TotalPayAmount").ToString 'TotalPayAmount
                txtTotalPayTax.Text = dr("TotalPayTax").ToString 'TotalPayTax
                txtSoLicenseNo.Text = dr("SoLicenseNo").ToString 'SoLicenseNo
                txtSoLicenseAmount.Text = dr("SoLicenseAmount").ToString 'SoLicenseAmount
                txtSoAccAmount.Text = dr("SoAccAmount").ToString 'SoAccAmount
                txtPayeeAccNo.Text = dr("PayeeAccNo").ToString 'PayeeAccNo
                txtSoTaxNo.Text = dr("SoTaxNo").ToString 'SoTaxNo
                Select Case CInt(dr("PayTaxType").ToString)
                    Case 0, 1
                        togPayTaxType1.Checked = True  'PayTaxType
                    Case 2
                        togPayTaxType2.Checked = True
                    Case 3
                        togPayTaxType3.Checked = True
                    Case 4
                        togPayTaxType4.Checked = True

                End Select

                txtPayTaxOther.Text = dr("PayTaxOther").ToString 'PayTaxOther
                ' txtTeacherAmt.Text = dr("TeacherAmt").ToString 'TeacherAmt
                txtDocRefNo.Text = dr("DocRefNo").ToString 'DocRefNo
                txtJobRefNo.Text = dr("JobRefNo").ToString 'JobRefNo
                'txtTypeY.Text = dr("TypeY").ToString 'TypeY
                txtT1ID.Text = CInt(dr("PFTBIDNT").ToString()) 'PFTBIDNT
                txtT2ID.Text = CInt(dr("CSTTBIDNT").ToString()) 'CSTTBIDNT
                txtT3ID.Text = CInt(dr("VENTBIDNT").ToString()) 'VENTBIDNT
                LoadDataPNDDetail(dr("DocNo").ToString)

                'AdNew
                GetRunningFormat("PND")
                txtDocControlNO.Text = RunningForm.Run_Formatt
                txtDocNo.Text = cboFormType.Text & "[AD]MM-######"
                dtpDocDate.ResetText()
                _IsNewPND = True
                ' cboTaxCancelReason.Enabled = False
            End If
            SetDigit(txtTotalPayAmount)
            SetDigit(txtTotalPayTax)
            SetDigit(txtSoLicenseAmount)
            SetDigit(txtSoAccAmount)
            If txtTypeY.Text = "XO" Then
                txtTCode2.ResetText()
                txtTBrCode2.ResetText()
                txtTName2.ResetText()
                txtTAddress2.ResetText()
                txtT2ID.Text = "0"
                txtTaxNumber2.ResetText()
                txtIDCard2.ResetText()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error : " & ex.Message, "รายงานผล", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub
    Private Sub LoadDataPNDDetail(_DocNo As String)
        Try
            dgvTaxDetail.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT [TBIDNT],[BranchCode],[DocNo],[ItemNo],[IncType],[PayDate],Isnull(SUM([PayAmount]),0) as [PayAmount],Isnull(Sum([PayTax]),0) as [PayTax],[PayTaxDesc],[JNo],[DocRefType],[DocRefNo],[PayRate] FROM [Q_INFPNDDetail] where [ReferenceNo]='" & _DocNo & "'"

            str &= "     GROUP BY [TBIDNT],[BranchCode],[DocNo],[ItemNo],[IncType],[PayDate],[PayTaxDesc],[JNo],[DocRefType],[DocRefNo],[PayRate] "

            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtJobRefNo.Text = dt.Rows(0)("JNo").ToString
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvTaxDetail.Rows.Add(dt.Rows(i)("TBIDNT").ToString(), 'TBIDNT
                       dt.Rows(i)("BranchCode").ToString(), 'BranchCode
                       dt.Rows(i)("DocNo").ToString(), 'DocNo
                       i + 1, 'ItemNo
                       dt.Rows(i)("IncType").ToString(), 'IncType
                       DBDate(dt.Rows(i)("PayDate").ToString()), 'PayDate
                       CDbl(dt.Rows(i)("PayAmount").ToString()).ToString("#,##0.00"), 'PayAmount
                       CDbl(dt.Rows(i)("PayTax").ToString()).ToString("#,##0.00"), 'PayTax
                       dt.Rows(i)("PayTaxDesc").ToString(), 'PayTaxDesc
                       dt.Rows(i)("JNo").ToString(), 'JNo
                       dt.Rows(i)("DocRefType").ToString(), 'DocRefType
                       dt.Rows(i)("DocRefNo").ToString(), 'DocRefNo
                       CDbl(dt.Rows(i)("PayRate").ToString()).ToString("#,##0.00"), "1"  'PayRate , New
                        )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
            CalPNDDetail()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub
    Private Sub CalPNDDetail()
        Try
            If dgvTaxDetail.Rows.Count > 0 Then
                Dim TotalPayAmount As Double = 0
                Dim TotalPayTax As Double = 0

                For row As Integer = 0 To dgvTaxDetail.Rows.Count - 2
                    dgvTaxDetail.Rows(row).Cells(3).Value = row + 1
                    TotalPayAmount += CDbl(dgvTaxDetail.Rows(row).Cells(6).Value)
                    TotalPayTax += CDbl(dgvTaxDetail.Rows(row).Cells(7).Value)
                Next
                txtTotalPayAmount.Text = TotalPayAmount.ToString("#,##0.00")
                txtTotalPayTax.Text = TotalPayTax.ToString("#,##0.00")
            Else
                SetDigit(txtTotalPayAmount)
                SetDigit(txtTotalPayTax)
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub btnPNDNew_Click(sender As Object, e As EventArgs) Handles btnPNDNew.Click
        AddNewPND()
    End Sub
    Private Sub AddNewPND()
        txtTBIDNTPND.Text = "0" 'TBIDNT
        'txtBranchCode.ResetText() 'BranchCode
        txtDocNo.ResetText() 'DocNo
        dtpDocDate.ResetText() 'DocDate
        txtDocControlNO.ResetText() 'DocControlNO
        txtIDCard1.ResetText() 'IDCard1
        txtTaxNumber1.ResetText() 'TaxNumber1
        txtTBrCode1.ResetText() 'TBrCode1
        txtTName1.ResetText() 'TName1
        txtTAddress1.ResetText() 'TAddress1
        txtIDCard2.ResetText() 'IDCard2
        txtTaxNumber2.ResetText() 'TaxNumber2
        txtTBrCode2.ResetText() 'TBrCode2
        txtTName2.ResetText() 'TName2
        txtTAddress2.ResetText() 'TAddress2
        txtIDCard3.ResetText() 'IDCard3
        txtTaxNumber3.ResetText() 'TaxNumber3
        txtTBrCode3.ResetText() 'TBrCode3
        txtTName3.ResetText() 'TName3
        txtTAddress3.ResetText() 'TAddress3
        txtSeqInForm.Text = "0" 'SeqInForm

        cboFormType.ResetText() 'FormType
        cboTaxLawNo.ResetText() 'TaxLawNo
        'txtIncRate.ResetText() 'IncRate
        'txtIncOther.ResetText() 'IncOther
        txtTotalPayAmount.ResetText() 'TotalPayAmount
        txtTotalPayTax.ResetText() 'TotalPayTax
        txtSoLicenseNo.ResetText() 'SoLicenseNo
        txtSoLicenseAmount.ResetText() 'SoLicenseAmount
        txtSoAccAmount.ResetText() 'SoAccAmount
        txtPayeeAccNo.ResetText() 'PayeeAccNo
        txtSoTaxNo.ResetText() 'SoTaxNo
        togPayTaxType1.Checked = True  'PayTaxType
        txtPayTaxOther.ResetText() 'PayTaxOther
        ' txtPayTaxOther.Enabled = False
        txtCancelProve.ResetText() 'CancelProve
        cboTaxCancelReason.ResetText() 'CancelReason
        '  cboTaxCancelReason.Enabled = False
        'txtCancelDate.ResetText() 'CancelDate
        'txtUpdateBy.ResetText() 'UpdateBy
        ' txtLastUpdate.ResetText() 'LastUpdate
        ' txtTeacherAmt.ResetText() 'TeacherAmt

        'txtDocRefNo.ResetText() 'DocRefNo
        'txtJobRefNo.ResetText() 'JobRefNo
        txtT1ID.Text = "0"
        txtT2ID.Text = "0"
        txtT3ID.Text = "0"
        'togIsCSV.Checked = False 'IsCSV
        'togActive.Checked = False 'Active
        _IsNewPND = True
        txtTCode1.ResetText()
        txtTCode2.ResetText()
        txtTCode3.ResetText()

        dgvTaxDetail.Rows.Clear()

        SetDigit(txtTotalPayAmount)
        SetDigit(txtTotalPayTax)
        SetDigit(txtSoLicenseAmount)
        SetDigit(txtSoAccAmount)


        'AdNew
        GetRunningFormat("PND")
        txtDocControlNO.Text = RunningForm.Run_Formatt
        txtDocNo.Text = cboFormType.Text & "[AD]MM-######"
        dtpDocDate.ResetText()
        _IsNewPND = True
    End Sub
    Private Sub btnPNDSave_Click(sender As Object, e As EventArgs) Handles btnPNDSave.Click
#Region "Validate Data Input"
        If String.IsNullOrEmpty(txtTCode3.Text) Or String.IsNullOrEmpty(txtTName3.Text) Then
            MetroFramework.MetroMessageBox.Show(Me, "กรุณาตรวจสอบผู้ถูกหัก ณ ที่จ่าย", "ตรวจสอบผู้ถูกหัก", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTCode3.Focus()
            Exit Sub
        End If
        If dgvTaxDetail.Rows.Count = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "ไม่มีรายการถูกหัก ณ ที่จ่าย", "ตรวจสอบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If CDbl(txtTotalPayAmount.Text) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "ไม่มียอดเงินถูกหัก ณ ที่จ่าย", "ตรวจสอบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTotalPayAmount.Focus()
            Exit Sub
        End If
        If CDbl(txtTotalPayTax.Text) = 0 Then
            MetroFramework.MetroMessageBox.Show(Me, "ไม่มียอดเงินถูกหัก ณ ที่จ่าย", "ตรวจสอบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTotalPayTax.Focus()
            Exit Sub
        End If
        If txtPayTaxOther.Enabled Then
            If String.IsNullOrEmpty(txtPayTaxOther.Text) Then
                MetroFramework.MetroMessageBox.Show(Me, "กรุณาระบุข้อมูลการออก อื่นๆ", "ตรวจสอบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPayTaxOther.Focus()
                Exit Sub
            End If
        End If
        If String.IsNullOrEmpty(cboTaxLawNo.Text) Then
            MetroFramework.MetroMessageBox.Show(Me, "กรุณาระบุข้อมูลการออก อื่นๆ", "ตรวจสอบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTaxLawNo.Focus()
            Exit Sub
        End If
#End Region

        UserAuthorize(UserProfile.U_Code, "HPND")
        If _IsNewPND Then
            If UserAuthen.IsInsertData = 1 Then
                If txtDocControlNO.Text = "" Or txtDocControlNO.Text = RunningForm.Run_Formatt Then
                    txtDocControlNO.Text = CreateNumber("INF_WHTax", "DocControlNO", txtDocControlNO.Text, CDate(dtpDocDate.Value))
                    txtDocNo.Text = CreateNumber("INF_WHTax", "DocNO", txtDocNo.Text)
                Else
                    If CheckCode("INF_WHTax", "DocControlNO", txtDocControlNO.Text) Then
                        MetroFramework.MetroMessageBox.Show(Me, "Duplicate Document Number Please Check.", "Document Number!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If
                SaveDataPND(1)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        Else
            If UserAuthen.IsEditData = 1 Then
                If Not String.IsNullOrEmpty(cboTaxCancelReason.Text) Then
                    If UserAuthen.IsCancel = 0 Then
                        MetroFramework.MetroMessageBox.Show(Me, "User Not Cancel this Document!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    If CDbl(txtTBIDNTPND.Text) > 0 Then
                        If MetroFramework.MetroMessageBox.Show(Me, "ต้องการยกเลิกรายการ " & txtDocControlNO.Text & " หรือไม่?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            Exit Sub
                        Else
                            CancelPND()
                            AddNewPND()
                        End If

                    End If
                    'LoadListPND()
                Else
                    SaveDataPND(0)
                End If
            Else
                MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

        End If
    End Sub
    Private Sub CancelPND()
        Try
            Dim seq As String = ""

            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec [sp_CancelINF_PNDHeader] ")
            SQLcommand.Append("'" & CInt(txtTBIDNTPND.Text) & "'") 'TBIDNT
            SQLcommand.Append(",'" & UserProfile.U_Code & "'") '@VCancelBy
            SQLcommand.Append(",'" & cboTaxCancelReason.Text & "'") '@VCancelReason
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            'If result = 1 Then
            '    seq = "" ' &= dgvExtraPrice.Rows(row).Cells(4).Value.ToString

            'Else
            '    seq = "ไม่"
            '    MetroFramework.MetroMessageBox.Show(Me, "บันทึกข้อมูล " + seq + "เรียบร้อย", "รายงานผล", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub SaveDataPND(_Insert As Integer)
        Try

            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateINF_WHTax ")
            SQLcommand.Append("'" & txtTBIDNTPND.Text & "'") 'TBIDNT
            SQLcommand.Append(",'" & CMPProfile.PROF_Code & "'") 'CMPCode
            SQLcommand.Append(",'" & CMPProfile.PROF_BrCode & "'") 'BranchCode
            SQLcommand.Append(",'" & txtDocNo.Text & "'") 'DocNo
            SQLcommand.Append(",'" & CDate(dtpDocDate.Value) & "'") 'DocDate
            SQLcommand.Append(",'" & txtDocControlNO.Text & "'") 'DocControlNO
            SQLcommand.Append(",'" & txtIDCard1.Text & "'") 'IDCard1
            SQLcommand.Append(",'" & txtTaxNumber1.Text & "'") 'TaxNumber1
            SQLcommand.Append(",'" & txtTBrCode1.Text & "'") 'TBrCode1
            SQLcommand.Append(",'" & txtTName1.Text & "'") 'TName1
            SQLcommand.Append(",'" & txtTAddress1.Text & "'") 'TAddress1
            SQLcommand.Append(",'" & txtIDCard2.Text & "'") 'IDCard2
            SQLcommand.Append(",'" & txtTaxNumber2.Text & "'") 'TaxNumber2
            SQLcommand.Append(",'" & txtTBrCode2.Text & "'") 'TBrCode2
            SQLcommand.Append(",'" & txtTName2.Text & "'") 'TName2
            SQLcommand.Append(",'" & txtTAddress2.Text & "'") 'TAddress2
            SQLcommand.Append(",'" & txtIDCard3.Text & "'") 'IDCard3
            SQLcommand.Append(",'" & txtTaxNumber3.Text & "'") 'TaxNumber3
            SQLcommand.Append(",'" & txtTBrCode3.Text & "'") 'TBrCode3
            SQLcommand.Append(",'" & txtTName3.Text & "'") 'TName3
            SQLcommand.Append(",'" & txtTAddress3.Text & "'") 'TAddress3
            SQLcommand.Append(",'" & txtSeqInForm.Text & "'") 'SeqInForm
            SQLcommand.Append(",'" & cboFormType.SelectedValue & "'") 'FormType
            SQLcommand.Append(",'" & cboTaxLawNo.SelectedValue & "'") 'TaxLawNo
            SQLcommand.Append(",'3'") 'IncRate
            SQLcommand.Append(",'0'") 'IncOther
            SQLcommand.Append(",'" & CDbl(txtTotalPayAmount.Text) & "'") 'TotalPayAmount
            SQLcommand.Append(",'" & CDbl(txtTotalPayTax.Text) & "'") 'TotalPayTax
            SQLcommand.Append(",'" & txtSoLicenseNo.Text & "'") 'SoLicenseNo
            SQLcommand.Append(",'" & CDbl(txtSoLicenseAmount.Text) & "'") 'SoLicenseAmount
            SQLcommand.Append(",'" & CDbl(txtSoAccAmount.Text) & "'") 'SoAccAmount
            SQLcommand.Append(",'" & txtPayeeAccNo.Text & "'") 'PayeeAccNo
            SQLcommand.Append(",'" & txtSoTaxNo.Text & "'") 'SoTaxNo
            SQLcommand.Append(",'" & _PayTaxType & "'") 'PayTaxType
            SQLcommand.Append(",'" & txtPayTaxOther.Text & "'") 'PayTaxOther
            'SQLcommand.Append(",'" & txtCancelProve.Text & "'") 'CancelProve
            'SQLcommand.Append(",'" & txtCancelReason.Text & "'") 'CancelReason
            'SQLcommand.Append(",'" & CDate(txtCancelDate.Text) & "'") 'CancelDate
            'SQLcommand.Append(",'" & txtUpdateBy.Text & "'") 'UpdateBy
            'SQLcommand.Append(",'" & CDate(txtLastUpdate.Text) & "'") 'LastUpdate
            'SQLcommand.Append(",'" & CDbl(txtTeacherAmt.Text) & "'") 'TeacherAmt
            SQLcommand.Append(",'" & txtDocRefNo.Text & "'") 'DocRefNo
            SQLcommand.Append(",'" & txtJobRefNo.Text & "'") 'JobRefNo
            ' SQLcommand.Append(",'" & togIsCSV.CheckState & "'") 'IsCSV
            SQLcommand.Append(",'1'") 'Active
            SQLcommand.Append(",'" & txtT1ID.Text & "'") 'T1ID
            SQLcommand.Append(",'" & txtT2ID.Text & "'") 'T2ID
            SQLcommand.Append(",'" & txtT3ID.Text & "'") 'T3ID
            SQLcommand.Append(",'" & txtPAYNumber.Text & "'") 'PAYNumber
            SQLcommand.Append(",'" & UserProfile.U_Code & "'") 'CreateBy
            ' SQLcommand.Append(",'" & CDate(txtCreateDate.Text) & "'") 'CreateDate
            SQLcommand.Append(",'" & txtTCode1.Text & "'") 'CCode1
            SQLcommand.Append(",'" & txtTCode2.Text & "'") 'CCode2
            SQLcommand.Append(",'" & txtTCode3.Text & "'") 'CCode3
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                SaveDataPNDDetail()
                _IsNewPND = False
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataPNDHeader()

                ' AddNewPND()
                ''Load To List
                'LoadListPND()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        'cboCancelReason.Enabled = True
    End Sub
    Private Sub SaveDataPNDDetail()
        Try
            If dgvTaxDetail.Rows.Count > 0 Then

                Dim nection As New OleDb.OleDbConnection()
                nection = ConnectDB()
                For row As Integer = 0 To dgvTaxDetail.Rows.Count - 2
                    Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateINF_WHTaxDetail ")
                    SQLcommand.Append("'" & CInt(dgvTaxDetail.Rows(row).Cells(0).Value) & "'") 'TBIDNT
                    SQLcommand.Append(",'" & dgvTaxDetail.Rows(row).Cells(1).Value.ToString & "'") 'BranchCode
                    SQLcommand.Append(",'" & txtDocControlNO.Text & "'") 'DocNo
                    SQLcommand.Append(",'" & CInt(dgvTaxDetail.Rows(row).Cells(3).Value) & "'") 'ItemNo
                    SQLcommand.Append(",'" & dgvTaxDetail.Rows(row).Cells(4).Value.ToString & "'") 'IncType
                    SQLcommand.Append(",'" & ToDBDate(dgvTaxDetail.Rows(row).Cells(5).Value) & "'") 'PayDate
                    SQLcommand.Append(",'" & CDbl(dgvTaxDetail.Rows(row).Cells(6).Value) & "'") 'PayAmount
                    SQLcommand.Append(",'" & CDbl(dgvTaxDetail.Rows(row).Cells(7).Value) & "'") 'PayTax
                    SQLcommand.Append(",'" & dgvTaxDetail.Rows(row).Cells(8).Value.ToString & "'") 'PayTaxDesc
                    SQLcommand.Append(",'" & dgvTaxDetail.Rows(row).Cells(9).Value.ToString & "'") 'JNo
                    SQLcommand.Append(",'" & dgvTaxDetail.Rows(row).Cells(10).Value.ToString & "'") 'DocRefType
                    SQLcommand.Append(",'" & dgvTaxDetail.Rows(row).Cells(11).Value.ToString & "'") 'DocRefNo
                    SQLcommand.Append(",'" & CDbl(dgvTaxDetail.Rows(row).Cells(12).Value) & "'") 'PayRate
                    SQLcommand.Append(",'" & CInt(dgvTaxDetail.Rows(row).Cells(13).Value) & "'") '//Insert Or Update
                    Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                        'MetroFramework.MetroMessageBox.Show(frmMain, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MetroFramework.MetroMessageBox.Show(Me, "Save WHTaxDetail Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                Next
                nection.Close()
            End If

        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'Private Sub LoadListPND()
    '    Try
    '        dgvPNDList.Rows.Clear()
    '        Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
    '        Dim dt As DataTable = New DataTable()
    '        Dim nection As New OleDb.OleDbConnection()
    '        nection = ConnectDB()
    '        Dim str As String = " SELECT [TBIDNT],[DocNo],[DocDate],[DocControlNO],[CancelReason] FROM [INF_WHTax] WHERE 1=1 "
    '        str &= " AND BranchCode='" & CMPProfile.PROF_BrCode & "' and CMPCode='" & CMPProfile.PROF_Code & "'"
    '        str &= " AND [PAYNumber]='" & txtPAYNumber.Text & "'"

    '        da.SelectCommand = New OleDbCommand(str, nection)
    '        da.Fill(dt)
    '        If dt.Rows.Count > 0 Then
    '            For i As Integer = 0 To dt.Rows.Count - 1
    '                dgvPNDList.Rows.Add(dt.Rows(i)("TBIDNT").ToString(), 'TBIDNT
    '                           dt.Rows(i)("DocNo").ToString(), 'DocNo
    '                           LetDate(dt.Rows(i)("DocDate").ToString()), 'DocDate
    '                           dt.Rows(i)("DocControlNO").ToString(), 'DocControlNO
    '                           dt.Rows(i)("CancelReason").ToString()
    '                            )
    '            Next

    '            da = Nothing
    '            dt = Nothing
    '            nection.Close()
    '        End If
    '    Catch ex As Exception
    '        MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    End Try
    'End Sub
    Private Sub txtPayeeAccNo_ButtonClick(sender As Object, e As EventArgs) Handles txtPayeeAccNo.ButtonClick
        Try
            Dim dr As DataRow
            Dim sqlstr As String = "SELECT [BCKCode],[BookCode],[BookName],[BankBranch] FROM [V_Mas_UnionBookBank] WHERE [CMP]='CMP' "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                ' BCKCode.Text = dr("BCKCode").ToString
                txtPayeeAccNo.Text = dr("BookCode").ToString
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtTCode1_ButtonClick(sender As Object, e As EventArgs) Handles txtTCode1.ButtonClick
        Try
            Dim dr As DataRow
            Dim sqlstr As String = "SELECT TOP 100 [CustCode],[CustBranch],[TaxNumber],[CustName],[CustContact],[CountryName],[TAddress],[TTAddress],[TBIDNT]  FROM [V_MasCustomer] where 1=1 AND [CMPCode]='" & CMPProfile.PROF_Code & "'
        AND [BranchCode]='" & CMPProfile.PROF_BrCode & "'"
            sqlstr &= " ORDER BY TBIDNT DESC "

            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                txtTCode1.Text = dr("CustCode").ToString
                txtTBrCode1.Text = dr("CustBranch").ToString
                txtTName1.Text = dr("CustName").ToString
                txtTAddress1.Text = dr("TAddress").ToString & " " & dr("TTAddress").ToString
                txtT1ID.Text = dr("TBIDNT").ToString
                txtTaxNumber1.Text = dr("TaxNumber").ToString
                txtIDCard1.Text = "" 'dr("TBIDNT").ToString
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub txtTCode1_ClearClicked() Handles txtTCode1.ClearClicked
        txtTBrCode1.ResetText()
        txtTName1.ResetText()
        txtTAddress1.ResetText()
        txtT1ID.Text = "0"
        txtTaxNumber1.ResetText()
        txtIDCard1.ResetText()

    End Sub

    Private Sub txtTCode2_ButtonClick(sender As Object, e As EventArgs) Handles txtTCode2.ButtonClick
        Try
            Dim dr As DataRow
            Dim sqlstr As String = "SELECT TOP 100 [PFCode],[PFBrCode],[PFTaxNumber],[PFName],[PFAddress1],[PFAddress2],[TBIDNT]  FROM [V_Sys_Profile]  where 1=1"
            sqlstr &= " ORDER BY TBIDNT DESC "

            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                txtTCode2.Text = dr("PFCode").ToString
                txtTBrCode2.Text = dr("PFBrCode").ToString
                txtTName2.Text = dr("PFName").ToString
                txtTAddress2.Text = dr("PFAddress1").ToString & " " & dr("PFAddress2").ToString
                txtT2ID.Text = dr("TBIDNT").ToString
                txtTaxNumber2.Text = dr("PFTaxNumber").ToString
                txtIDCard2.Text = "" 'dr("TBIDNT").ToString
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub txtTCode2_ClearClicked() Handles txtTCode2.ClearClicked
        txtTBrCode2.ResetText()
        txtTName2.ResetText()
        txtTAddress2.ResetText()
        txtT2ID.Text = "0"
        txtTaxNumber2.ResetText()
        txtIDCard2.ResetText()
    End Sub

    Private Sub txtTCode3_ButtonClick(sender As Object, e As EventArgs) Handles txtTCode3.ButtonClick
        Try
            Dim dr As DataRow
            Dim sqlstr As String = " SELECT TOP 100 [VendorID],[VendorBranch],[VenTaxID],[VendorTName],[VendorTAddress],[Ident] from Mas_VendorTransport where 1=1 "
            '"SELECT TOP 100 [VenCode],[VenBranch],[TaxNumber],[VenName],[VenContact],[CountryName],[TAddress],[TTAddress],[TBIDNT] from [V_MasVendor] where 1=1 AND [CMPCode]='" & CMPProfile.PROF_Code & "'
            'And [BranchCode]='" & CMPProfile.PROF_BrCode & "'"
            sqlstr &= " ORDER BY Ident DESC "

            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                txtTCode3.Text = dr("VendorID").ToString
                txtTBrCode3.Text = dr("VendorBranch").ToString
                txtTName3.Text = dr("VendorTName").ToString
                txtTAddress3.Text = dr("VendorTAddress").ToString '& " " & dr("TTAddress").ToString
                txtT3ID.Text = dr("Ident").ToString
                txtTaxNumber3.Text = dr("VenTaxID").ToString
                txtIDCard3.Text = "" 'dr("TBIDNT").ToString
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtTCode3_ClearClicked() Handles txtTCode3.ClearClicked
        txtTBrCode3.ResetText()
        txtTName3.ResetText()
        txtTAddress3.ResetText()
        txtT3ID.Text = "0"
        txtTaxNumber3.ResetText()
        txtIDCard3.ResetText()
    End Sub
    Private Sub togPayTaxType1_CheckedChanged(sender As Object, e As EventArgs) Handles togPayTaxType1.CheckedChanged
        If togPayTaxType1.Checked Then _PayTaxType = 1
    End Sub

    Private Sub togPayTaxType2_CheckedChanged(sender As Object, e As EventArgs) Handles togPayTaxType2.CheckedChanged
        If togPayTaxType2.Checked Then _PayTaxType = 2
    End Sub
    Private Sub MetroRadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles togPayTaxType3.CheckedChanged
        If togPayTaxType3.Checked Then _PayTaxType = 3
    End Sub
    Private Sub togPayTaxType4_CheckedChanged(sender As Object, e As EventArgs) Handles togPayTaxType4.CheckedChanged
        If togPayTaxType4.Checked Then
            txtPayTaxOther.Enabled = True
            txtPayTaxOther.Focus()
            _PayTaxType = 4
        Else
            txtPayTaxOther.ResetText()
            txtPayTaxOther.Enabled = False
        End If
    End Sub

    Private Sub cboFormType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFormType.SelectedIndexChanged
        If _IsNewPND Then
            'AdNew
            GetRunningFormat("PND")
            txtDocControlNO.Text = RunningForm.Run_Formatt
            txtDocNo.Text = cboFormType.Text & "[AD]MM-######"
            ' dtpDocDate.ResetText()
            '_IsNewPND = True
        End If

    End Sub

    Private Sub txtTotalPayAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalPayTax.KeyPress, txtTotalPayAmount.KeyPress, txtSoLicenseAmount.KeyPress, txtSoAccAmount.KeyPress
        CheckDouble(e)
        If e.KeyChar = Chr(Keys.Enter) Then
            SetDigit(sender)
        End If
    End Sub

    Private Sub txtTotalPayAmount_Leave(sender As Object, e As EventArgs) Handles txtTotalPayTax.Leave, txtTotalPayAmount.Leave, txtSoLicenseAmount.Leave, txtSoAccAmount.Leave
        SetDigit(sender)
    End Sub

    'Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
    '    If TabControl1.SelectedIndex = 2 Then LoadListPND()
    'End Sub
    'Private Sub dgvPNDList_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvPNDList.CellMouseClick
    '    UserAuthorize(UserProfile.U_Code, "HPND")
    '    If UserAuthen.IsOpenMenu = 0 Then Exit Sub
    '    Try
    '        If e.RowIndex < 0 Or e.RowIndex > dgvPNDList.Rows.Count - 1 Then Exit Sub
    '        If e.RowIndex >= 0 Then
    '            LoadDataPNDHeader(CInt(dgvPNDList.CurrentRow.Cells(0).Value))
    '            ' MsgBox(dgvAdvList.CurrentRow.Cells(0).Value.ToString)
    '        End If
    '    Catch ex As Exception
    '        MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    End Try
    'End Sub
    Private Sub LoadDataPNDHeader(Optional ByVal _ID As Integer = 0)
        Try

            Dim str As String = "" ' "SELECT * FROM [INF_WHTax] where [DocControlNO]='" & _ID & "'"
            If _ID > 0 Then
                str = "SELECT * FROM [INF_WHTax] where [TBIDNT]='" & _ID & "'"
            Else
                str = "SELECT * FROM [INF_WHTax] where [DocControlNO]='" & txtDocControlNO.Text & "'"
            End If
            Dim dr As DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                _IsNewPND = False

                txtTBIDNTPND.Text = CInt(dr("TBIDNT").ToString()) 'TBIDNT
                'txtPFCode.Text = dr("PFCode").ToString 'PFCode
                txtDocNo.Text = dr("DocNo").ToString 'DocNo
                dtpDocDate.Value = CDate(dr("DocDate").ToString) 'DocDate
                txtDocControlNO.Text = dr("DocControlNO").ToString 'DocControlNO
                ' txtBranchCode.Text = dr("BranchCode").ToString 'BranchCode
                'txtBranchName.Text = dr("BranchName").ToString 'BranchName
                ' txtTCode1.Text = dr("TCode1").ToString '
                txtTCode1.Text = dr("CCode1").ToString '
                txtIDCard1.Text = dr("IDCard1").ToString 'IDCard1
                txtTaxNumber1.Text = dr("TaxNumber1").ToString 'TaxNumber1
                txtTBrCode1.Text = dr("TBrCode1").ToString 'TBrCode1
                txtTName1.Text = dr("TName1").ToString 'TName1
                txtTAddress1.Text = dr("TAddress1").ToString 'TAddress1

                ' txtTCode2.Text = dr("TCode2").ToString 'CustCode
                txtTCode2.Text = dr("CCode2").ToString 'CustCode
                txtIDCard2.Text = dr("IDCard2").ToString 'IDCard2
                txtTaxNumber2.Text = dr("TaxNumber2").ToString 'TaxNumber2
                txtTBrCode2.Text = dr("TBrCode2").ToString 'TBrCode2
                txtTName2.Text = dr("TName2").ToString 'TName2
                txtTAddress2.Text = dr("TAddress2").ToString 'TAddress2

                'txtTCode3.Text = dr("TCode3").ToString 'VendorCode
                txtTCode3.Text = dr("CCode3").ToString 'VendorCode
                txtIDCard3.Text = dr("IDCard3").ToString 'IDCard3
                txtTaxNumber3.Text = dr("TaxNumber3").ToString 'TaxNumber3
                txtTBrCode3.Text = dr("TBrCode3").ToString 'TBrCode3
                txtTName3.Text = dr("TName3").ToString 'TName3
                txtTAddress3.Text = dr("TAddress3").ToString 'TAddress3

                txtSeqInForm.Text = dr("SeqInForm").ToString 'SeqInForm
                cboFormType.SelectedValue = dr("FormType").ToString 'FormType
                cboTaxLawNo.SelectedValue = dr("TaxLawNo").ToString 'TaxLawNo
                'txtIncRate.Text = dr("IncRate").ToString 'IncRate
                'txtIncOther.Text = dr("IncOther").ToString 'IncOther
                txtTotalPayAmount.Text = dr("TotalPayAmount").ToString 'TotalPayAmount
                txtTotalPayTax.Text = dr("TotalPayTax").ToString 'TotalPayTax
                txtSoLicenseNo.Text = dr("SoLicenseNo").ToString 'SoLicenseNo
                txtSoLicenseAmount.Text = dr("SoLicenseAmount").ToString 'SoLicenseAmount
                txtSoAccAmount.Text = dr("SoAccAmount").ToString 'SoAccAmount
                txtPayeeAccNo.Text = dr("PayeeAccNo").ToString 'PayeeAccNo
                txtSoTaxNo.Text = dr("SoTaxNo").ToString 'SoTaxNo
                Select Case CInt(dr("PayTaxType").ToString)
                    Case 0, 1
                        togPayTaxType1.Checked = True  'PayTaxType
                    Case 2
                        togPayTaxType2.Checked = True
                    Case 3
                        togPayTaxType3.Checked = True
                    Case 4
                        togPayTaxType4.Checked = True

                End Select

                txtPayTaxOther.Text = dr("PayTaxOther").ToString 'PayTaxOther
                ' txtTeacherAmt.Text = dr("TeacherAmt").ToString 'TeacherAmt
                txtDocRefNo.Text = dr("DocRefNo").ToString 'DocRefNo
                txtJobRefNo.Text = dr("JobRefNo").ToString 'JobRefNo
                'txtTypeY.Text = dr("TypeY").ToString 'TypeY
                txtT1ID.Text = CInt(dr("T1ID").ToString()) 'PFTBIDNT
                txtT2ID.Text = CInt(dr("T2ID").ToString()) 'CSTTBIDNT
                txtT3ID.Text = CInt(dr("T3ID").ToString()) 'VENTBIDNT
                txtPAYNumber.Text = dr("PAYNumber").ToString 'PAYNumber
                'Load Detail
                LoadDataWHTDetail()

                ''AdNew
                'GetRunningFormat("PND")
                'txtDocControlNO.Text = RunningForm.Run_Formatt
                'txtDocNo.Text = cboFormType.Text & "[AD]MM-######"
                'dtpDocDate.ResetText()

                txtCancelProve.Text = dr("CancelProve").ToString()
                cboTaxCancelReason.Text = dr("CancelReason").ToString()
                If String.IsNullOrEmpty(cboTaxCancelReason.Text) Then
                    cboTaxCancelReason.Enabled = True
                Else
                    cboTaxCancelReason.Enabled = False
                End If
                btnPNDSave.Enabled = cboTaxCancelReason.Enabled
            End If
            SetDigit(txtTotalPayAmount)
            SetDigit(txtTotalPayTax)
            SetDigit(txtSoLicenseAmount)
            SetDigit(txtSoAccAmount)

        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error : " & ex.Message, "รายงานผล", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataWHTDetail()
        Try
            dgvTaxDetail.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM [INF_WHTaxDetail] where [DocNo]='" & txtDocControlNO.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ' txtJobRefNo.Text = dt.Rows(0)("JNo").ToString
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvTaxDetail.Rows.Add(dt.Rows(i)("TBIDNT").ToString(), 'TBIDNT
                       dt.Rows(i)("BranchCode").ToString(), 'BranchCode
                       dt.Rows(i)("DocNo").ToString(), 'DocNo
                       dt.Rows(i)("ItemNo").ToString(), 'ItemNo
                       dt.Rows(i)("IncType").ToString(), 'IncType
                       DBDate(dt.Rows(i)("PayDate").ToString()), 'PayDate
                       CDbl(dt.Rows(i)("PayAmount").ToString()).ToString("#,##0.00"), 'PayAmount
                       CDbl(dt.Rows(i)("PayTax").ToString()).ToString("#,##0.00"), 'PayTax
                       dt.Rows(i)("PayTaxDesc").ToString(), 'PayTaxDesc
                       dt.Rows(i)("JNo").ToString(), 'JNo
                       dt.Rows(i)("DocRefType").ToString(), 'DocRefType
                       dt.Rows(i)("DocRefNo").ToString(), 'DocRefNo
                       CDbl(dt.Rows(i)("PayRate").ToString()).ToString("#,##0.00"), "0"  'PayRate , New
                        )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
            CalPNDDetail()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvTaxDetail_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvTaxDetail.RowsRemoved
        Try
            If dgvTaxDetail.Rows.Count = 0 Then Exit Sub
            CalPNDDetail()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvTaxDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvTaxDetail.DataError
        MetroFramework.MetroMessageBox.Show(Me, "Error " & e.Exception.Message, " Datagrid Cell", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub

    Private Sub dgvTaxDetail_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvTaxDetail.RowsAdded
        If dgvTaxDetail.Rows(e.RowIndex).IsNewRow Then
            dgvTaxDetail.Rows(e.RowIndex).Cells(0).Value = "0"
            dgvTaxDetail.Rows(e.RowIndex).Cells(1).Value = CMPProfile.PROF_BrCode
            dgvTaxDetail.Rows(e.RowIndex).Cells(2).Value = txtDocControlNO.Text
            dgvTaxDetail.Rows(e.RowIndex).Cells(3).Value = "1"
            dgvTaxDetail.Rows(e.RowIndex).Cells(4).Value = "PAY"
            ' dgvTaxDetail.Rows(e.RowIndex).Cells(5).Value =
            dgvTaxDetail.Rows(e.RowIndex).Cells(6).Value = "0"
            dgvTaxDetail.Rows(e.RowIndex).Cells(7).Value = "0"
            dgvTaxDetail.Rows(e.RowIndex).Cells(8).Value = ""
            dgvTaxDetail.Rows(e.RowIndex).Cells(9).Value = txtJobRefNo.Text
            dgvTaxDetail.Rows(e.RowIndex).Cells(10).Value = "PV"
            dgvTaxDetail.Rows(e.RowIndex).Cells(11).Value = txtDocRefNo.Text
            dgvTaxDetail.Rows(e.RowIndex).Cells(12).Value = "0"
            dgvTaxDetail.Rows(e.RowIndex).Cells(13).Value = "1"
            'dgvTaxDetail.Rows(e.RowIndex).Cells(8).Value = ""
        Else
            dgvTaxDetail.Rows(e.RowIndex).Cells(13).Value = "0"
        End If

    End Sub

    Private Sub dgvTaxDetail_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTaxDetail.CellEndEdit
        Try
            '  If dgvTaxDetail.Rows.Count = 0 Then Exit Sub
            CalPNDDetail()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvTaxDetail_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTaxDetail.CellValidated
        Try
            Select Case e.ColumnIndex
                Case 3
                    sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CInt(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("#,##0")
                Case 6, 7, 12 'float fields
                    sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("#,##0.00")

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvTaxDetail_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvTaxDetail.CellValidating
        Try
            If sender.Rows.Count < 1 Then Exit Sub
            'is the user clicking on the column headers? 
            If e.RowIndex = -1 Then Exit Sub
            'is it the new row? 
            If sender.Rows(e.RowIndex).IsNewRow Then Exit Sub
            If CStr(e.FormattedValue) = Nothing Then Exit Sub

            Dim newValue As Double
            Select Case e.ColumnIndex
                Case 6, 7, 12
                    If Double.TryParse(e.FormattedValue, newValue) Then
                        'are there no changes being made? 
                        If newValue = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then Exit Sub
                    Else
                        'if the value can't be parsed into a decimal, then it is invalid 
                        e.Cancel = True
                    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub
End Class