Imports System.Data.OleDb
Imports System.Text

Public Class frmMasagency
    Public CMPCode as String = CMPProfile.PROF_Code
    Public BrCode as String = CMPProfile.PROF_BrCode
    Public HIdentity as Integer
    Public _IsNew as Boolean
    Public _IsNewCont as Boolean
    Public _IsNewVessel as Boolean
    Public VenCode as String
    Public BranchCode as String
    Public VenType as String = "aGN"
    Private Sub FrmMasagency_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        If HIdentity > 0 Then
            LoadData()
        Else
            addNewData()
            addNewContact()
            addNewVessel()
        End If

    End Sub

    Private Sub cmdNew_Click(sender as Object, e as Eventargs) Handles cmdNew.Click
        addNewData()
        addNewContact()
        addNewVessel()
    End Sub
    Private Sub addNewData()
        txtTaxNumber.ResetText()
        txtCustCode.ResetText()
        txtBranch.Text = "000000"
        txtNameEng.ResetText()
        txtTaddress.ResetText()
        txtTTaddress.ResetText()
        txtCustCity.ResetText()
        txtPurchaseCity.ResetText()
        txtPurchaseCityName.ResetText()
        txtVenContact.ResetText()
        txtCustEmail.ResetText()
        txtCustPhone.ResetText()
        txtCustFax.ResetText()
        txtTermOfPayment.Text = "0"

        txtBillCondition.ResetText()

        togIs_OverSea.Checked = False 'Is_OverSea
        togIsagentCoLoader.Checked = False 'IsagentCoLoader
        togIsShipper.Checked = False 'IsShipper
        togIsConsign.Checked = False 'IsConsign
        togIsNotify.Checked = False 'IsNotify
        togIsagentPartner.Checked = False 'IsagentPartner
        togIs_Local.Checked = False 'Is_Local
        togIsLocalCoLoader.Checked = False 'IsLocalCoLoader
        togIsactualShipper.Checked = False 'IsactualShipper
        togIsactualConsignee.Checked = False 'IsactualConsignee
        togIsactualNotify.Checked = False 'IsactualNotify
        togIsCustomsBroker.Checked = False 'IsCustomsBroker
        togIs_Line.Checked = False 'Is_Line
        togIsagentLineCoLoader.Checked = False 'IsagentLineCoLoader
        togIsagentLine.Checked = False 'IsagentLine
        togIsairLine.Checked = False 'IsairLine
        togIsTrucking.Checked = False 'IsTrucking
        togIsTrain.Checked = False 'IsTrain
        togIs_WareHouse.Checked = False 'Is_WareHouse
        togIs_ContainerYard.Checked = False 'Is_ContainerYard
        togactive.Checked = True
        _IsNew = True

        txtBranch.ReadOnly = False
        txtCustCode.ReadOnly = False
        dgvContact.Rows.Clear()
        dgvVesselList.Rows.Clear()
        CaseRunning()
    End Sub
    Private Sub CaseRunning()
        If _IsNew = False Then Exit Sub
        Select Case cmbVenGroup.Text
            Case "OverSea"
                GetRunningFormat("SOVS")
            Case "Local"
                GetRunningFormat("SLOC")
            Case "Line"
                GetRunningFormat("SLIN")
        End Select
        txtCustCode.Text = RunningForm.Run_Formatt
    End Sub
    Private Sub txtTermOfPayment_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtTermOfPayment.KeyPress
        CheckNumeric(e)
    End Sub

    Private Sub txtPurchaseCity_ButtonClick(sender as Object, e as Eventargs) Handles txtPurchaseCity.ButtonClick
        SelectCountry(txtPurchaseCity, txtPurchaseCityName)
    End Sub

    Private Sub cmdSearch_Click(sender as Object, e as Eventargs) Handles cmdSearch.Click
        Try
            Dim dr as DataRow
            dr = PopUpSearch("SELECT TBIDNT,[VenCode] ,[VenBranch] ,[TaxNumber] ,[VenName],Taddress  FROM [V_Masagency] WHERE VenType='" & VenType & "'  aND [CMPCode]='" & CMPCode & "' and BranchCode='" & BrCode & "' aND VenCode='" & VenCode & "' aND VenBranch='" & BranchCode & "' order by [VenCode] ", MainConnection)
            If isSearchOK Then
                HIdentity = CInt(dr("TBIDNT").ToString)
                LoadData()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadData()

        Try
            Dim str as String = "SELECT * FROM [V_Masagency] where VenType='" & VenType & "' "
            If HIdentity > 0 Then str &= " and TBIDNT='" & HIdentity & "'"
            Dim dr as DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                _IsNew = False

                HIdentity = dr("TBIDNT").ToString
                txtTaxNumber.Text = dr("TaxNumber").ToString
                txtCustCode.Text = dr("VenCode").ToString
                txtBranch.Text = dr("VenBranch").ToString
                txtNameEng.Text = dr("VenName").ToString
                txtTaddress.Text = dr("Taddress").ToString
                txtTTaddress.Text = dr("TTaddress").ToString
                txtCustCity.Text = dr("Vencity").ToString
                txtPurchaseCity.Text = dr("PurchaseCity").ToString
                txtPurchaseCityName.Text = dr("CountryName").ToString
                txtVenContact.Text = dr("VenContact").ToString
                txtCustEmail.Text = dr("VenEmail").ToString
                txtCustPhone.Text = dr("VenPhone").ToString
                txtCustFax.Text = dr("VenFax").ToString
                ' txtGLaccountCode.Text = dr("GLaccountCode").ToString
                ' txtGLaccountName.Text = dr("accTName").ToString
                txtTermOfPayment.Text = dr("TermOfPayment").ToString
                txtBillCondition.Text = dr("BillCondition").ToString

                cmbVenGroup.Text = dr("VenGroup").ToString 'VenGroup
                togIs_OverSea.Checked = CInt(dr("Is_OverSea").ToString()) 'Is_OverSea
                togIsagentCoLoader.Checked = CInt(dr("IsagentCoLoader").ToString()) 'IsagentCoLoader
                togIsShipper.Checked = CInt(dr("IsShipper").ToString()) 'IsShipper
                togIsConsign.Checked = CInt(dr("IsConsign").ToString()) 'IsConsign
                togIsNotify.Checked = CInt(dr("IsNotify").ToString()) 'IsNotify
                togIsagentPartner.Checked = CInt(dr("IsagentPartner").ToString()) 'IsagentPartner
                togIs_Local.Checked = CInt(dr("Is_Local").ToString()) 'Is_Local
                togIsLocalCoLoader.Checked = CInt(dr("IsLocalCoLoader").ToString()) 'IsLocalCoLoader
                togIsactualShipper.Checked = CInt(dr("IsactualShipper").ToString()) 'IsactualShipper
                togIsactualConsignee.Checked = CInt(dr("IsactualConsignee").ToString()) 'IsactualConsignee
                togIsactualNotify.Checked = CInt(dr("IsactualNotify").ToString()) 'IsactualNotify
                togIsCustomsBroker.Checked = CInt(dr("IsCustomsBroker").ToString()) 'IsCustomsBroker
                togIs_Line.Checked = CInt(dr("Is_Line").ToString()) 'Is_Line
                togIsagentLineCoLoader.Checked = CInt(dr("IsagentLineCoLoader").ToString()) 'IsagentLineCoLoader
                togIsagentLine.Checked = CInt(dr("IsagentLine").ToString()) 'IsagentLine
                togIsairLine.Checked = CInt(dr("IsairLine").ToString()) 'IsairLine
                togIsTrucking.Checked = CInt(dr("IsTrucking").ToString()) 'IsTrucking
                togIsTrain.Checked = CInt(dr("IsTrain").ToString()) 'IsTrain
                togIs_WareHouse.Checked = CInt(dr("Is_WareHouse").ToString()) 'Is_WareHouse
                togIs_ContainerYard.Checked = CInt(dr("Is_ContainerYard").ToString()) 'Is_ContainerYard
                togactive.Checked = CInt(dr("active").ToString)

                LoadContact()
                LoadVessel()
                addNewContact()

                txtCustCode.ReadOnly = True
                txtBranch.ReadOnly = True
            Else
                addNewData()
                addNewContact()
                addNewVessel()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadContact()
        Try
            dgvContact.Rows.Clear()
            Dim da as New OleDb.OleDbDataadapter()
            Dim dt as New DataTable()
            Dim str as String
            str = "SELECT [TBIDNT],[VenContactName],[ContactDescription],[ContactPhone],[ContactMobile],[ContactFaX],[ContactEmail],[VenCode],[VenBranch],[active]  FROM Mas_VendorContact where VenCode='" & txtCustCode.Text & "' and VenBranch='" & txtBranch.Text & "' aND [ContackType]='" & VenType & "' order by [TBIDNT]"
            da.SelectCommand = New OleDb.OleDbCommand(str, MainConnection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvContact.Rows.add(i + 1,
                    dt(i)(1).ToString, '
                    dt(i)(2).ToString, '
                    dt(i)(3).ToString, '
                    dt(i)(4).ToString, '
                    dt(i)(5).ToString, '
                    dt(i)(6).ToString,'
                    dt(i)(7).ToString, '
                    dt(i)(8).ToString, '
                    dt(i)(9).ToString, '
                    dt(i)(0).ToString '
                    )
                Next
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadVessel()
        Try
            dgvVesselList.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM V_MasVesselList where 1=1 aND VendorCode='" & txtCustCode.Text & "' aND VendorBrCode='" & txtBranch.Text & "' aND Ventype='" & VenType & "'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvVesselList.Rows.add(dt.Rows(i)("TBIDNT").ToString(), 'TBIDNT
                        dt.Rows(i)("VendorCode").ToString(), 'VendorCode
                        dt.Rows(i)("VendorBrCode").ToString(), 'VendorBrCode
                        dt.Rows(i)("VenName").ToString(), 'VenName
                        dt.Rows(i)("VesselCode").ToString(), 'VesselCode
                        dt.Rows(i)("VesselName").ToString(), 'VesselName
                        dt.Rows(i)("FeederCode").ToString(), 'FeederCode
                        dt.Rows(i)("FeederName").ToString(), 'FeederName
                        dt.Rows(i)("MasterCode").ToString(), 'MasterCode
                        dt.Rows(i)("MasterName").ToString(), 'MasterName
                        dt.Rows(i)("active").ToString() 'active
                        )
                Next
                'Dim str as String = "SELECT * FROM V_MasVessel where [VendorCode]='" & txtCustCode.Text & "' and [BranchCode]='" & txtBranch.Text & "' aND [VenType]='" & VenType & "' "
                'da.SelectCommand = New OleDbCommand(str, nection)
                'da.Fill(dt)
                'If dt.Rows.Count > 0 Then
                '    For i as Integer = 0 To dt.Rows.Count - 1
                '        dgvVesselList.Rows.add(dt.Rows(i)("TBIDNT").ToString(), 'TBIDNT
                '               dt.Rows(i)("VendorCode").ToString(), 'VendorCode
                '               dt.Rows(i)("BranchCode").ToString(), 'BranchCode
                '               dt.Rows(i)("RegisterNumber").ToString(), 'RegisterNumber
                '               dt.Rows(i)("VesselName").ToString(), 'VesselName
                '               dt.Rows(i)("VesselType").ToString(), 'VesselType
                '               dt.Rows(i)("CountryCode").ToString(), 'CountryCode
                '               dt.Rows(i)("CountryName").ToString(), 'CountryCode
                '               dt.Rows(i)("active").ToString() 'active
                '                )
                '    Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub cmdSave_Click(sender as Object, e as Eventargs) Handles cmdSave.Click

        'Check Exist Code Before Save Data
        If String.IsNullOrEmpty(cmbVenGroup.Text) Then
            cmbVenGroup.Style = MetroFramework.MetroColorStyle.Red
            cmbVenGroup.Focus()
            Exit Sub
        Else
            cmbVenGroup.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtCustCode.Text) Then
            txtCustCode.Style = MetroFramework.MetroColorStyle.Red
            txtCustCode.Focus()
            Exit Sub
        Else
            txtCustCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtBranch.Text) Then
            txtBranch.Style = MetroFramework.MetroColorStyle.Red
            txtBranch.Focus()
            Exit Sub
        Else
            txtBranch.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtNameEng.Text) Then
            txtNameEng.Style = MetroFramework.MetroColorStyle.Red
            txtNameEng.Focus()
            Exit Sub
        Else
            txtNameEng.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtTaddress.Text) Then
            txtTaddress.Style = MetroFramework.MetroColorStyle.Red
            txtTaddress.Focus()
            Exit Sub
        Else
            txtTaddress.Style = MetroFramework.MetroColorStyle.Default
        End If

        If String.IsNullOrEmpty(txtPurchaseCity.Text) Then
            txtPurchaseCity.Style = MetroFramework.MetroColorStyle.Red
            txtPurchaseCity.Focus()
            Exit Sub
        Else
            txtPurchaseCity.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtCustEmail.Text) = False Then
            If txtCustEmail.Text.Contains("@") = False Then
                MetroFramework.MetroMessageBox.Show(Main, "Email incorected format!", "Check format", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtCustEmail.Style = MetroFramework.MetroColorStyle.Red
                txtCustEmail.Focus()
                Exit Sub
            Else
                txtCustEmail.Style = MetroFramework.MetroColorStyle.Default
            End If

        Else
            txtCustEmail.Style = MetroFramework.MetroColorStyle.Default
        End If

        Userauthorize(UserProfile.U_Code, "aGNIF")
        If _IsNew Then
            If Userauthen.IsInsertData = 1 Then
                If txtCustCode.Text = "" Or txtCustCode.Text = RunningForm.Run_Formatt Then
                    txtCustCode.Text = CreateNumber("Mas_Vendor", "VenCode", True)
                Else
                    If CheckagentCode(txtCustCode.Text, txtBranch.Text, VenType, VenCode, BranchCode) Then
                        MetroFramework.MetroMessageBox.Show(Main, "agent Code " & txtCustCode.Text & " Branch " & txtBranch.Text & " already Existing In Database!", "Check agent Code!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If
                SaveData(1)
            Else
                MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        Else
            If Userauthen.IsEditData = 1 Then
                SaveData(0)
            Else
                MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If
    End Sub
    Private Sub SaveData(_Insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec [sp_lnsertOrupdateMas_agency] ")
            SQLcommand.append("'" & HIdentity & "'") '@MIdent
            SQLcommand.append(",'" & CMPCode & "'") 'CMPCode
            SQLcommand.append(",'" & BrCode & "'") ' BrCode
            SQLcommand.append(",'" & txtCustCode.Text & "'") 'Custcode
            SQLcommand.append(",'" & txtBranch.Text & "'") ' Branchcode
            SQLcommand.append(",'" & txtTaxNumber.Text & "'") '@TaxNumber
            SQLcommand.append(",'" & txtPurchaseCity.Text & "'") '@PurchaseCity
            SQLcommand.append(",'" & txtNameEng.Text & "'") '@NameEng
            SQLcommand.append(",'" & txtTaddress.Text & "'") '@Taddress
            SQLcommand.append(",'" & txtTTaddress.Text & "'") '@Taddress
            SQLcommand.append(",'" & txtCustCity.Text & "'") '@CustCity
            SQLcommand.append(",'" & txtVenContact.Text & "'") '@VenContact
            SQLcommand.append(",'" & txtCustEmail.Text & "'") '@CustEmail
            SQLcommand.append(",'" & txtCustPhone.Text & "'") '@CustPhone
            SQLcommand.append(",'" & txtCustFax.Text & "'") '@CustFax
            '  SQLcommand.append(",'" & txtGLaccountCode.Text & "'") 'GLCode
            SQLcommand.append(",'" & VenCode & "'") 'Vendor Code
            SQLcommand.append(",'" & BranchCode & "'") 'Vendor Branch
            SQLcommand.append(",'" & txtTermOfPayment.Text & "'") '@TermOfPayment
            SQLcommand.append(",'" & VenType & "'") '@CustType
            SQLcommand.append(",'" & cmbVenGroup.Text & "'") 'VenGroup
            SQLcommand.append(",'" & txtBillCondition.Text & "'") '@accountRemark

            SQLcommand.append(",'" & togIs_OverSea.CheckState & "'") 'Is_OverSea
            SQLcommand.append(",'" & togIsagentCoLoader.CheckState & "'") 'IsagentCoLoader
            SQLcommand.append(",'" & togIsShipper.CheckState & "'") 'IsShipper
            SQLcommand.append(",'" & togIsConsign.CheckState & "'") 'IsConsign
            SQLcommand.append(",'" & togIsNotify.CheckState & "'") 'IsNotify
            SQLcommand.append(",'" & togIsagentPartner.CheckState & "'") 'IsagentPartner
            SQLcommand.append(",'" & togIs_Local.CheckState & "'") 'Is_Local
            SQLcommand.append(",'" & togIsLocalCoLoader.CheckState & "'") 'IsLocalCoLoader
            SQLcommand.append(",'" & togIsactualShipper.CheckState & "'") 'IsactualShipper
            SQLcommand.append(",'" & togIsactualConsignee.CheckState & "'") 'IsactualConsignee
            SQLcommand.append(",'" & togIsactualNotify.CheckState & "'") 'IsactualNotify
            SQLcommand.append(",'" & togIsCustomsBroker.CheckState & "'") 'IsCustomsBroker
            SQLcommand.append(",'" & togIs_Line.CheckState & "'") 'Is_Line
            SQLcommand.append(",'" & togIsagentLineCoLoader.CheckState & "'") 'IsagentLineCoLoader
            SQLcommand.append(",'" & togIsagentLine.CheckState & "'") 'IsagentLine
            SQLcommand.append(",'" & togIsairLine.CheckState & "'") 'IsairLine
            SQLcommand.append(",'" & togIsTrucking.CheckState & "'") 'IsTrucking
            SQLcommand.append(",'" & togIsTrain.CheckState & "'") 'IsTrain
            SQLcommand.append(",'" & togIs_WareHouse.CheckState & "'") 'Is_WareHouse
            SQLcommand.append(",'" & togIs_ContainerYard.CheckState & "'") 'Is_ContainerYard
            SQLcommand.append(",'" & togactive.CheckState & "'") '@active
            SQLcommand.append(",'" & _Insert & "'") '@lnsertorupdate
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                '  LoadData()
                txtCustCode.ReadOnly = True
                txtBranch.ReadOnly = True
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub cmdClearContr_Click(sender as Object, e as Eventargs) Handles cmdClearContr.Click
        addNewContact()
    End Sub
    Private Sub addNewContact()
        txtCID.ResetText()
        txtContactName.ResetText()
        txtContactDescription.ResetText()
        txtTel.ResetText()
        txtFaX.ResetText()
        txtEmail.ResetText()
        togContractactive.Checked = True
        'dgvContact.Rows.Clear()
        _IsNewCont = True
        txtContactName.Focus()

    End Sub

    Private Sub cmdSaveContract_Click(sender as Object, e as Eventargs) Handles cmdSaveContract.Click
        If String.IsNullOrEmpty(txtCustCode.Text) Then
            txtCustCode.Style = MetroFramework.MetroColorStyle.Red
            txtCustCode.Focus()
            Exit Sub
        Else
            txtCustCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtBranch.Text) Then
            txtBranch.Style = MetroFramework.MetroColorStyle.Red
            txtBranch.Focus()
            Exit Sub
        Else
            txtBranch.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtContactName.Text) Then
            txtContactName.Style = MetroFramework.MetroColorStyle.Red
            txtContactName.Focus()
            Exit Sub
        Else
            txtContactName.Style = MetroFramework.MetroColorStyle.Default
        End If
        If _IsNewCont Then
            SaveContact(1)
        Else
            SaveContact(0)
        End If
        LoadContact()
        addNewContact()
    End Sub
    Private Sub SaveContact(_Insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec [sp_lnsertOrupdateMas_VendorContact] ")
            SQLcommand.append("'" & txtCID.Text & "'") '@@CID
            SQLcommand.append(",'" & txtCustCode.Text & "'") '@CustCode
            SQLcommand.append(",'" & txtBranch.Text & "'") ' BrCode
            SQLcommand.append(",'" & txtContactName.Text & "'") '@ContactName
            SQLcommand.append(",'" & txtContactDescription.Text & "'") ' @ContactDescription
            SQLcommand.append(",'" & txtTel.Text & "'") '@@Tel
            SQLcommand.append(",'" & txtFaX.Text & "'") '@@FaX
            SQLcommand.append(",'" & txtEmail.Text & "'") '@@Email
            SQLcommand.append(",'" & VenType & "'") '@@ContackType
            SQLcommand.append(",'" & togContractactive.CheckState & "'") '@active
            SQLcommand.append(",'" & _Insert & "'") '@lnsertorupdate
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNewCont = False
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub


    Private Sub dgvContact_CellMouseDoubleClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvContact.CellMouseDoubleClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvContact.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtCID.Text = dgvContact.Rows(e.RowIndex).Cells(10).Value.ToString
                txtContactName.Text = dgvContact.Rows(e.RowIndex).Cells(1).Value.ToString
                txtContactDescription.Text = dgvContact.Rows(e.RowIndex).Cells(2).Value.ToString
                txtTel.Text = dgvContact.Rows(e.RowIndex).Cells(3).Value.ToString
                ' txtMobile.Text = dgvContact.Rows(e.RowIndex).Cells(4).Value.ToString
                txtFaX.Text = dgvContact.Rows(e.RowIndex).Cells(5).Value.ToString
                txtEmail.Text = dgvContact.Rows(e.RowIndex).Cells(6).Value.ToString
                togContractactive.Checked = CInt(dgvContact.Rows(e.RowIndex).Cells(9).Value.ToString)
                _IsNewCont = False
            End If
        Catch ex as Exception

        End Try
    End Sub

    Private Sub cmdClose_Click(sender as Object, e as Eventargs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub btnaddNewVessel_Click(sender as Object, e as Eventargs) Handles btnaddNewVessel.Click
        addNewVessel()
    End Sub
    Private Sub addNewVessel()
        txtTBIDNT.Text = "0"  'TBIDNT
        txtVesselCode.ResetText() 'RegisterNumber
        txtVesselName.ResetText() 'VesselName
        txtFeederCode.ResetText()
        txtFeederName.ResetText()
        txtMasterCode.ResetText()
        txtMasterName.ResetText()
        togVesselactive.Checked = True  'active
        _IsNewVessel = True
        txtVesselCode.Focus()

    End Sub
    Private Sub btnSaveVessel_Click(sender as Object, e as Eventargs) Handles btnSaveVessel.Click
        If String.IsNullOrEmpty(txtCustCode.Text) Then
            txtCustCode.Style = MetroFramework.MetroColorStyle.Red
            txtCustCode.Focus()
            Exit Sub
        Else
            txtCustCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtBranch.Text) Then
            txtBranch.Style = MetroFramework.MetroColorStyle.Red
            txtBranch.Focus()
            Exit Sub
        Else
            txtBranch.Style = MetroFramework.MetroColorStyle.Default
        End If

        If String.IsNullOrEmpty(txtVesselCode.Text) Then
            txtVesselCode.Focus()
            txtVesselCode.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtVesselCode.Style = MetroFramework.MetroColorStyle.Default
        End If

        Userauthorize(UserProfile.U_Code, "aGNIF")
        If _IsNewVessel Then
            If Userauthen.IsInsertData = 1 Then
                SaveVessel(1)
            Else
                MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            If Userauthen.IsEditData = 1 Then
                SaveVessel(0)
            Else
                MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub
    Private Sub SaveVessel(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_VesselVendor ")
            SQLcommand.append("'" & txtTBIDNT.Text & "'") 'TBIDNT
            SQLcommand.append(",'" & txtCustCode.Text & "'") 'VendorCode
            SQLcommand.append(",'" & txtBranch.Text & "'") 'VendorBrCode
            SQLcommand.append(",'" & txtVesselCode.Text & "'") 'VesselCode
            SQLcommand.append(",'" & txtFeederCode.Text & "'") 'FeederCode
            SQLcommand.append(",'" & txtMasterCode.Text & "'") 'MasterCode
            SQLcommand.append(",'" & VenType & "'") 'VenType
            SQLcommand.append(",'" & togVesselactive.CheckState & "'") 'active
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadVessel()
                addNewVessel()
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        'Try
        '    Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_Vessel ")
        '    SQLcommand.append("'" & txtCIdent.Text & "'") 'TBIDNT
        '    SQLcommand.append(",'" & txtCustCode.Text & "'") 'VendorCode
        '    SQLcommand.append(",'" & txtBranch.Text & "'") 'BranchCode
        '    SQLcommand.append(",'" & txtRegisterNumber.Text & "'") 'RegisterNumber
        '    SQLcommand.append(",'" & txtVesselName.Text & "'") 'VesselName
        '    SQLcommand.append(",'" & cmbVesselType.Text & "'") 'VesselType
        '    SQLcommand.append(",'" & txtCountryCode.Text & "'") 'CountryCode
        '    SQLcommand.append(",'" & VenType & "'") 'VenType
        '    SQLcommand.append(",'" & togactive.CheckState & "'") 'active
        '    SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
        '    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
        '    If result = 1 Then
        '        MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        LoadVessel()
        '        addNewVessel()
        '    Else
        '        MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    End If
        '    nection.Close()
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub

    Private Sub dgvVesselList_CellMouseDoubleClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvVesselList.CellMouseDoubleClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvVesselList.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtTBIDNT.Text = dgvVesselList.CurrentRow.Cells(0).Value.ToString() 'TBIDNT
                txtVesselCode.Text = dgvVesselList.CurrentRow.Cells(4).Value.ToString() 'VesselCode
                txtVesselName.Text = dgvVesselList.CurrentRow.Cells(5).Value.ToString() 'VesselName
                txtFeederCode.Text = dgvVesselList.CurrentRow.Cells(6).Value.ToString() 'FeederCode
                txtFeederName.Text = dgvVesselList.CurrentRow.Cells(7).Value.ToString() 'FeederName
                txtMasterCode.Text = dgvVesselList.CurrentRow.Cells(8).Value.ToString() 'MasterCode
                txtMasterName.Text = dgvVesselList.CurrentRow.Cells(9).Value.ToString() 'MasterName
                togVesselactive.Checked = CInt(dgvVesselList.CurrentRow.Cells(10).Value.ToString()) 'active
                _IsNewVessel = False
            End If
        Catch ex as Exception

        End Try
        'Try
        '    If e.RowIndex < 0 Or e.RowIndex > dgvVesselList.Rows.Count - 1 Then Exit Sub
        '    If e.RowIndex >= 0 Then
        '        txtCIdent.Text = CInt(dgvVesselList.CurrentRow.Cells(0).Value.ToString()) 'TBIDNT
        '        txtRegisterNumber.Text = dgvVesselList.CurrentRow.Cells(3).Value.ToString() 'RegisterNumber
        '        txtVesselName.Text = dgvVesselList.CurrentRow.Cells(4).Value.ToString() 'VesselName
        '        cmbVesselType.Text = dgvVesselList.CurrentRow.Cells(5).Value.ToString() 'VesselType
        '        txtCountryCode.Text = dgvVesselList.CurrentRow.Cells(6).Value.ToString() 'CountryCode
        '        txtCountryName.Text = dgvVesselList.CurrentRow.Cells(7).Value.ToString() 'CountryName
        '        togVesselactive.Checked = CInt(dgvVesselList.CurrentRow.Cells(8).Value.ToString()) 'active
        '        _IsNewVessel = False
        '    End If
        'Catch ex as Exception

        'End Try
    End Sub

    Private Sub txtTaxNumber_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtTaxNumber.KeyPress
        CheckNumeric(e)
    End Sub

    Private Sub cmdCopy_Click(sender as Object, e as Eventargs) Handles cmdCopy.Click
        'txtCustCode.ReadOnly = False
        'txtBranch.ReadOnly = False
        _IsNew = True
        If HIdentity > 0 and _IsNew = False Then
            txtCustCode.ReadOnly = False
            txtBranch.ReadOnly = False
            cmdCopy.BackColor = Color.Transparent
        Else
            Try
                Dim dr as DataRow
                dr = PopUpSearch("SELECT TBIDNT,[VenCode] ,[VenBranch] ,[TaxNumber] ,[VenName],[Taddress],[VenType]  FROM [V_MasVendorUnionagent] WHERE 1=1  aND [CMPCode]='" & CMPCode & "' and BranchCode='" & BrCode & "' order by [VenCode] ", MainConnection)
                If isSearchOK Then
                    HIdentity = CInt(dr("TBIDNT").ToString)
                    LoadCopy()
                End If
            Catch ex as Exception
                MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End If
    End Sub
    Private Sub LoadCopy()
        Try
            Dim str as String = "SELECT * FROM [V_MasVendorUnionagent] where 1=1 "
            If HIdentity > 0 Then str &= " and TBIDNT='" & HIdentity & "'"
            Dim dr as DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                _IsNew = True

                HIdentity = dr("TBIDNT").ToString
                txtTaxNumber.Text = dr("TaxNumber").ToString
                txtCustCode.Text = dr("VenCode").ToString
                txtBranch.Text = dr("VenBranch").ToString
                txtNameEng.Text = dr("VenName").ToString
                txtTaddress.Text = dr("Taddress").ToString
                txtTTaddress.Text = dr("TTaddress").ToString
                txtCustCity.Text = dr("Vencity").ToString
                txtPurchaseCity.Text = dr("PurchaseCity").ToString
                txtPurchaseCityName.Text = dr("CountryName").ToString
                txtCustEmail.Text = dr("VenEmail").ToString
                txtCustPhone.Text = dr("VenPhone").ToString
                txtCustFax.Text = dr("VenFax").ToString
                ' txtGLaccountCode.Text = dr("GLaccountCode").ToString
                ' txtGLaccountName.Text = dr("accTName").ToString
                txtTermOfPayment.Text = dr("TermOfPayment").ToString
                txtBillCondition.Text = dr("BillCondition").ToString

                cmbVenGroup.Text = dr("VenGroup").ToString 'VenGroup
                togIs_OverSea.Checked = CInt(dr("Is_OverSea").ToString()) 'Is_OverSea
                togIsagentCoLoader.Checked = CInt(dr("IsagentCoLoader").ToString()) 'IsagentCoLoader
                togIsShipper.Checked = CInt(dr("IsShipper").ToString()) 'IsShipper
                togIsConsign.Checked = CInt(dr("IsConsign").ToString()) 'IsConsign
                togIsNotify.Checked = CInt(dr("IsNotify").ToString()) 'IsNotify
                togIsagentPartner.Checked = CInt(dr("IsagentPartner").ToString()) 'IsagentPartner
                togIs_Local.Checked = CInt(dr("Is_Local").ToString()) 'Is_Local
                togIsLocalCoLoader.Checked = CInt(dr("IsLocalCoLoader").ToString()) 'IsLocalCoLoader
                togIsactualShipper.Checked = CInt(dr("IsactualShipper").ToString()) 'IsactualShipper
                togIsactualConsignee.Checked = CInt(dr("IsactualConsignee").ToString()) 'IsactualConsignee
                togIsactualNotify.Checked = CInt(dr("IsactualNotify").ToString()) 'IsactualNotify
                togIsCustomsBroker.Checked = CInt(dr("IsCustomsBroker").ToString()) 'IsCustomsBroker
                togIs_Line.Checked = CInt(dr("Is_Line").ToString()) 'Is_Line
                togIsagentLineCoLoader.Checked = CInt(dr("IsagentLineCoLoader").ToString()) 'IsagentLineCoLoader
                togIsagentLine.Checked = CInt(dr("IsagentLine").ToString()) 'IsagentLine
                togIsairLine.Checked = CInt(dr("IsairLine").ToString()) 'IsairLine
                togIsTrucking.Checked = CInt(dr("IsTrucking").ToString()) 'IsTrucking
                togIsTrain.Checked = CInt(dr("IsTrain").ToString()) 'IsTrain
                togIs_WareHouse.Checked = CInt(dr("Is_WareHouse").ToString()) 'Is_WareHouse
                togIs_ContainerYard.Checked = CInt(dr("Is_ContainerYard").ToString()) 'Is_ContainerYard
                togactive.Checked = CInt(dr("active").ToString)

                txtCustCode.ReadOnly = False
                txtBranch.ReadOnly = False
                addNewContact()
                addNewVessel()

            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtVesselCode_ButtonClick(sender as Object, e as Eventargs) Handles txtVesselCode.ButtonClick
        SelectVessel(txtVesselCode, txtVesselName)
    End Sub

    Private Sub txtVesselCode_ClearClicked() Handles txtVesselCode.ClearClicked
        txtVesselName.ResetText()
    End Sub

    Private Sub txtFeederCode_ButtonClick(sender as Object, e as Eventargs) Handles txtFeederCode.ButtonClick
        SelectVessel(txtFeederCode, txtFeederName)
    End Sub

    Private Sub txtFeederCode_ClearClicked() Handles txtFeederCode.ClearClicked
        txtFeederName.ResetText()
    End Sub

    Private Sub txtMasterCode_ButtonClick(sender as Object, e as Eventargs) Handles txtMasterCode.ButtonClick
        SelectVessel(txtMasterCode, txtMasterName)
    End Sub

    Private Sub txtMasterCode_ClearClicked() Handles txtMasterCode.ClearClicked
        txtMasterName.ResetText()
    End Sub

    Private Sub cmbVenGroup_SelectedIndexChanged(sender as Object, e as Eventargs) Handles cmbVenGroup.SelectedIndexChanged
        If _IsNew Then CaseRunning()
    End Sub

    Private Sub txtBranch_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtBranch.KeyPress
        CheckNumeric(e)
    End Sub

    Private Sub txtTTaddress_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtTTaddress.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustCode_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtVenContact.KeyPress, txtTaddress.KeyPress, txtNameEng.KeyPress, txtCustPhone.KeyPress, txtCustFax.KeyPress, txtCustEmail.KeyPress, txtCustCode.KeyPress, txtCustCity.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtContactName_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtTel.KeyPress, txtFaX.KeyPress, txtEmail.KeyPress, txtContactName.KeyPress, txtContactDescription.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtBillCondition_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtBillCondition.KeyPress
        CheckQuote(e)
    End Sub
End Class