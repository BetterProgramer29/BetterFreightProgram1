Imports System.Collections.Specialized.BitVector32
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text

Public Class frmMasVendor
    Public CMPCode As String = CMPProfile.PROF_Code
    Public BrCode As String = CMPProfile.PROF_BrCode
    Public HIdentity As Integer
    Public _IsNew As Boolean
    Public _IsNewCont As Boolean
    Public _IsNewVessel As Boolean
    Public CustCode As String
    Public BranchCode As String
    Public VenType As String = "VEN"
    Private Sub frmMasVendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddNewData()
        AddNewContact()
        AddNewVessel()
        txtTaxNumber.Focus()
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click


        UserAuthorize(UserProfile.U_Code, "VENIF")
        If UserAuthen.IsInsertData = 1 Then
            AddNewData()
            AddNewContact()
            AddNewVessel()
            AddNewBank()
            dgvAgentList.Rows.Clear()
            dgvVesselList.Rows.Clear()
            dgvVenBank.Rows.Clear()
            grpAddBank.Enabled = False
            txtTaxNumber.Focus()
        Else
            MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If



    End Sub
    Private Sub AddNewData()
        txtTaxNumber.ResetText()
        txtVenCode.ResetText()
        txtVenBranch.Text = "000000"
        txtVenName.ResetText()
        txtTAddress.ResetText()
        txtTTAddress.ResetText()
        txtVenCity.ResetText()
        txtPurchaseCity.ResetText()
        txtPurchaseCityName.ResetText()
        txtVenContact.ResetText()
        txtVenEmail.ResetText()
        txtVenPhone.ResetText()
        txtVenFax.ResetText()
        txtTermOfPayment.Text = "0"
        txtBillCondition.ResetText()

        togIs_OverSea.Checked = False 'Is_OverSea
        togIsAgentCoLoader.Checked = False 'IsAgentCoLoader
        togIsShipper.Checked = False 'IsShipper
        togIsConsign.Checked = False 'IsConsign
        togIsNotify.Checked = False 'IsNotify
        togIsAgentPartner.Checked = False 'IsAgentPartner
        togIs_Local.Checked = False 'Is_Local
        togIsLocalCoLoader.Checked = False 'IsLocalCoLoader
        togIsActualShipper.Checked = False 'IsActualShipper
        togIsActualConsignee.Checked = False 'IsActualConsignee
        togIsActualNotify.Checked = False 'IsActualNotify
        togIsCustomsBroker.Checked = False 'IsCustomsBroker
        togIs_Line.Checked = False 'Is_Line
        togIsAgentLineCoLoader.Checked = False 'IsAgentLineCoLoader
        togIsAgentLine.Checked = False 'IsAgentLine
        togIsAirLine.Checked = False 'IsAirLine
        togIsTrucking.Checked = False 'IsTrucking
        togIsTrain.Checked = False 'IsTrain
        togIs_WareHouse.Checked = False 'Is_WareHouse
        togIs_ContainerYard.Checked = False 'Is_ContainerYard

        togActive.Checked = True
        togIsPerson.Checked = False
        _IsNew = True

        txtVenBranch.ReadOnly = False
        txtVenCode.ReadOnly = False
        dgvContact.Rows.Clear()
        dgvVesselList.Rows.Clear()
        CaseRunning()
    End Sub
    Private Sub CaseRunning()
        If _IsNew = False Then Exit Sub
        Select Case cmbVenGroup.Text
            Case "OverSea"
                GetRunningFormat("VOVS")
            Case "Local"
                GetRunningFormat("VLOC")
            Case "Line"
                GetRunningFormat("VLIN")
        End Select
        txtVenCode.Text = RunningForm.Run_Formatt
    End Sub
    Private Sub txtTermOfPayment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTermOfPayment.KeyPress
        CheckNumeric(e)
    End Sub

    Private Sub txtPurchaseCity_ButtonClick(sender As Object, e As EventArgs) Handles txtPurchaseCity.ButtonClick
        SelectCountry(txtPurchaseCity, txtPurchaseCityName)
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TBIDNT,[VenCode] ,[VenBranch] ,[TaxNumber] ,[VenName],TAddress  FROM [V_MasVendor] WHERE VenType='" & VenType & "' AND [CMPCode]='" & CMPCode & "' and BranchCode='" & BrCode & "' order by [VenCode] ", MainConnection)
            If isSearchOK Then
                HIdentity = CInt(dr("TBIDNT").ToString)
                LoadData()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadData()
        Try
            ' Dim str As String = "SELECT * FROM Mas_Vendor where BranchCode='" & BrCode & "' and CMPCode='" & CMPCode & "'"
            Dim str As String = "SELECT * FROM [V_MasVendor] where VenType='" & VenType & "' "
            If HIdentity > 0 Then
                str &= " and TBIDNT='" & HIdentity & "'"
            Else
                str &= " and VenCode='" & txtVenCode.Text & "' AND VenBranch='" & txtVenBranch.Text & "'"
            End If
            Dim dr As DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                _IsNew = False

                HIdentity = dr("TBIDNT").ToString() 'TBIDNT
                MetroTextBox1.Text = dr("TBIDNT").ToString()
                'txtCMPCode.Text = dr("CMPCode").ToString 'CMPCode
                'txtBranchCode.Text = dr("BranchCode").ToString 'BranchCode
                txtVenCode.Text = dr("VenCode").ToString 'VenCode
                txtVenBranch.Text = dr("VenBranch").ToString 'VenBranch
                txtTaxNumber.Text = dr("TaxNumber").ToString 'TaxNumber
                txtPurchaseCity.Text = dr("PurchaseCity").ToString 'PurchaseCity
                txtPurchaseCityName.Text = dr("CountryName").ToString 'CountryName
                txtVenName.Text = dr("VenName").ToString 'VenName
                txtTAddress.Text = dr("TAddress").ToString 'TAddress
                txtTTAddress.Text = dr("TTAddress").ToString 'TTAddress
                txtVenCity.Text = dr("VenCity").ToString 'VenCity
                txtVenContact.Text = dr("VenContact").ToString 'VenContact
                txtVenEmail.Text = dr("VenEmail").ToString 'VenEmail
                txtVenPhone.Text = dr("VenPhone").ToString 'VenPhone
                txtVenFax.Text = dr("VenFax").ToString 'VenFax
                'txtBillToVenCode.Text = dr("BillToVenCode").ToString 'BillToVenCode
                'txtBillToBranch.Text = dr("BillToBranch").ToString 'BillToBranch
                'txtShipToVenCode.Text = dr("ShipToVenCode").ToString 'ShipToVenCode
                'txtShipToBranch.Text = dr("ShipToBranch").ToString 'ShipToBranch
                txtTermOfPayment.Text = CInt(dr("TermOfPayment").ToString()) 'TermOfPayment
                txtBillCondition.Text = dr("BillCondition").ToString 'BillCondition
                'txtCreditLimit.Text = dr("CreditLimit").ToString 'CreditLimit
                'txtVenType.Text = dr("VenType").ToString 'VenType
                cmbVenGroup.Text = dr("VenGroup").ToString 'VenGroup

                togIs_OverSea.Checked = CInt(dr("Is_OverSea").ToString()) 'Is_OverSea
                togIsAgentCoLoader.Checked = CInt(dr("IsAgentCoLoader").ToString()) 'IsAgentCoLoader
                togIsShipper.Checked = CInt(dr("IsShipper").ToString()) 'IsShipper
                togIsConsign.Checked = CInt(dr("IsConsign").ToString()) 'IsConsign
                togIsNotify.Checked = CInt(dr("IsNotify").ToString()) 'IsNotify
                togIsAgentPartner.Checked = CInt(dr("IsAgentPartner").ToString()) 'IsAgentPartner
                togIs_Local.Checked = CInt(dr("Is_Local").ToString()) 'Is_Local
                togIsLocalCoLoader.Checked = CInt(dr("IsLocalCoLoader").ToString()) 'IsLocalCoLoader
                togIsActualShipper.Checked = CInt(dr("IsActualShipper").ToString()) 'IsActualShipper
                togIsActualConsignee.Checked = CInt(dr("IsActualConsignee").ToString()) 'IsActualConsignee
                togIsActualNotify.Checked = CInt(dr("IsActualNotify").ToString()) 'IsActualNotify
                togIsCustomsBroker.Checked = CInt(dr("IsCustomsBroker").ToString()) 'IsCustomsBroker
                togIs_Line.Checked = CInt(dr("Is_Line").ToString()) 'Is_Line
                togIsAgentLineCoLoader.Checked = CInt(dr("IsAgentLineCoLoader").ToString()) 'IsAgentLineCoLoader
                togIsAgentLine.Checked = CInt(dr("IsAgentLine").ToString()) 'IsAgentLine
                togIsAirLine.Checked = CInt(dr("IsAirLine").ToString()) 'IsAirLine
                togIsTrucking.Checked = CInt(dr("IsTrucking").ToString()) 'IsTrucking
                togIsTrain.Checked = CInt(dr("IsTrain").ToString()) 'IsTrain
                togIs_WareHouse.Checked = CInt(dr("Is_WareHouse").ToString()) 'Is_WareHouse
                togIs_ContainerYard.Checked = CInt(dr("Is_ContainerYard").ToString()) 'Is_ContainerYard
                togActive.Checked = CInt(dr("Active").ToString()) 'Active
                togIsPerson.Checked = CInt(dr("IsPerson").ToString()) 'IsPerson เป็นบุคคล
                LoadContact()
                LoadVessel()
                LoadAgentList()
                LoadDataVenBank()
                AddNewBank()
                AddNewContact()
                AddNewVessel()

                txtVenCode.ReadOnly = True
                txtVenBranch.ReadOnly = True
                grpAddBank.Enabled = True
            End If

        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error : " & ex.Message, "รายงานผล", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub
    Private Sub LoadContact()
        Try
            dgvContact.Rows.Clear()
            Dim da As New OleDb.OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim str As String
            str = "SELECT [TBIDNT],[VenContactName],[ContactDescription],[ContactPhone],[ContactMobile],[ContactFAX],[ContactEmail],[VenCode],[VenBranch],[Active]  FROM Mas_VendorContact where VenCode='" & txtVenCode.Text & "' and VenBranch='" & txtVenBranch.Text & "' AND [ContackType]='" & VenType & "' order by [TBIDNT]"
            da.SelectCommand = New OleDb.OleDbCommand(str, MainConnection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvContact.Rows.Add(i + 1,
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
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadVessel()
        Try
            dgvVesselList.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM V_MasVesselList where 1=1 AND VendorCode='" & txtVenCode.Text & "' AND VendorBrCode='" & txtVenBranch.Text & "' AND Ventype='" & VenType & "'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvVesselList.Rows.Add(dt.Rows(i)("TBIDNT").ToString(), 'TBIDNT
                        dt.Rows(i)("VendorCode").ToString(), 'VendorCode
                        dt.Rows(i)("VendorBrCode").ToString(), 'VendorBrCode
                        dt.Rows(i)("VenName").ToString(), 'VenName
                        dt.Rows(i)("VesselCode").ToString(), 'VesselCode
                        dt.Rows(i)("VesselName").ToString(), 'VesselName
                        dt.Rows(i)("FeederCode").ToString(), 'FeederCode
                        dt.Rows(i)("FeederName").ToString(), 'FeederName
                        dt.Rows(i)("MasterCode").ToString(), 'MasterCode
                        dt.Rows(i)("MasterName").ToString(), 'MasterName
                        dt.Rows(i)("Active").ToString() 'Active
                        )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


        'Try
        '    dgvVesselList.Rows.Clear()
        '    Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
        '    Dim dt As DataTable = New DataTable()
        '    Dim nection As New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim str As String = "SELECT * FROM V_MasVessel where [VendorCode]='" & txtVenCode.Text & "' and [BranchCode]='" & txtVenBranch.Text & "' AND [VenType]='" & VenType & "' "
        '    da.SelectCommand = New OleDbCommand(str, nection)
        '    da.Fill(dt)
        '    If dt.Rows.Count > 0 Then
        '        For i As Integer = 0 To dt.Rows.Count - 1
        '            dgvVesselList.Rows.Add(dt.Rows(i)("TBIDNT").ToString(), 'TBIDNT
        '                   dt.Rows(i)("VendorCode").ToString(), 'VendorCode
        '                   dt.Rows(i)("BranchCode").ToString(), 'BranchCode
        '                   dt.Rows(i)("RegisterNumber").ToString(), 'RegisterNumber
        '                   dt.Rows(i)("VesselName").ToString(), 'VesselName
        '                   dt.Rows(i)("VesselType").ToString(), 'VesselType
        '                   dt.Rows(i)("CountryCode").ToString(), 'CountryCode
        '                   dt.Rows(i)("CountryName").ToString(), 'CountryCode
        '                   dt.Rows(i)("Active").ToString() 'Active
        '                    )
        '        Next
        '        da = Nothing
        '        dt = Nothing
        '        nection.Close()
        '    End If
        'Catch ex As Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub LoadAgentList()
        Try
            dgvAgentList.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM [V_MasAgency] where [BillToVenCode]='" & txtVenCode.Text & "' and [BillToBranch]='" & txtVenBranch.Text & "' "
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvAgentList.Rows.Add(dt.Rows(i)("TBIDNT").ToString(), 'TBIDNT
                           dt.Rows(i)("VenCode").ToString(), 'VendorCode
                           dt.Rows(i)("VenBranch").ToString(), 'BranchCode
                           dt.Rows(i)("TaxNumber").ToString(), 'RegisterNumber
                           dt.Rows(i)("VenName").ToString(), 'VesselName
                           dt.Rows(i)("TAddress").ToString(), 'VesselType
                           dt.Rows(i)("TTAddress").ToString(), 'CountryCode
                           dt.Rows(i)("Active").ToString() 'Active
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

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
#Region "Validate Input"
        'txtVenCode.Text = CreateNumber("Mas_Vendor", "VenCode", True)
        'Exit Sub
        If String.IsNullOrEmpty(cmbVenGroup.Text) Then
            cmbVenGroup.Style = MetroFramework.MetroColorStyle.Red
            cmbVenGroup.Focus()
            Exit Sub
        Else
            cmbVenGroup.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVenCode.Text) Then
            txtVenCode.Style = MetroFramework.MetroColorStyle.Red
            txtVenCode.Focus()
            Exit Sub
        Else
            txtVenCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVenBranch.Text) Then
            txtVenBranch.Style = MetroFramework.MetroColorStyle.Red
            txtVenBranch.Focus()
            Exit Sub
        Else
            txtVenBranch.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVenName.Text) Then
            txtVenName.Style = MetroFramework.MetroColorStyle.Red
            txtVenName.Focus()
            Exit Sub
        Else
            txtVenName.Style = MetroFramework.MetroColorStyle.Default
        End If
        'If String.IsNullOrEmpty(txtTAddress.Text) Then
        '    txtTAddress.Style = MetroFramework.MetroColorStyle.Red
        '    txtTAddress.Focus()
        '    Exit Sub
        'Else
        '    txtTAddress.Style = MetroFramework.MetroColorStyle.Default
        'End If

        'If String.IsNullOrEmpty(txtPurchaseCity.Text) Then
        '    txtPurchaseCity.Style = MetroFramework.MetroColorStyle.Red
        '    txtPurchaseCity.Focus()
        '    Exit Sub
        'Else
        '    txtPurchaseCity.Style = MetroFramework.MetroColorStyle.Default
        'End If
        If String.IsNullOrEmpty(txtVenEmail.Text) = False Then
            If txtVenEmail.Text.Contains("@") = False Then
                MetroFramework.MetroMessageBox.Show(Me, "Email incorected format!", "Check format", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtVenEmail.Style = MetroFramework.MetroColorStyle.Red
                txtVenEmail.Focus()
                Exit Sub
            Else
                txtVenEmail.Style = MetroFramework.MetroColorStyle.Default
            End If

        Else
            txtVenEmail.Style = MetroFramework.MetroColorStyle.Default
        End If
#End Region


        Userauthorize(UserProfile.U_Code, "VENIF")
        If _IsNew Then
            If Userauthen.IsInsertData = 1 Then
                If txtVenCode.Text = "" Or txtVenCode.Text = RunningForm.Run_Formatt Then
                    txtVenCode.Text = CreateNumber("Mas_Vendor", "VenCode", True)
                Else
                    If CheckagentCode(txtVenCode.Text, txtVenBranch.Text, VenType) Then
                        MetroFramework.MetroMessageBox.Show(Me, "Duplicate Vendor Code Please Check.", "Vendor Code Check!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If
                SaveData(1)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        Else
            If Userauthen.IsEditData = 1 Then
                SaveData(0)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If
    End Sub
    Private Sub SaveData(_Insert As Integer)
        Try

            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_Vendor ")
            SQLcommand.Append("'" & HIdentity & "'") 'TBIDNT
            SQLcommand.Append(",'" & CMPCode & "'") 'CMPCode
            SQLcommand.Append(",'" & BrCode & "'") 'BranchCode
            SQLcommand.Append(",'" & txtVenCode.Text & "'") 'VenCode
            SQLcommand.Append(",'" & txtVenBranch.Text & "'") 'VenBranch
            SQLcommand.Append(",'" & txtTaxNumber.Text & "'") 'TaxNumber
            SQLcommand.Append(",'" & txtPurchaseCity.Text & "'") 'PurchaseCity
            SQLcommand.Append(",'" & txtVenName.Text & "'") 'VenName
            SQLcommand.Append(",'" & txtTAddress.Text & "'") 'TAddress
            SQLcommand.Append(",'" & txtTTAddress.Text & "'") 'TTAddress
            SQLcommand.Append(",'" & txtVenCity.Text & "'") 'VenCity
            SQLcommand.Append(",'" & txtVenContact.Text & "'") 'VenContact
            SQLcommand.Append(",'" & txtVenEmail.Text & "'") 'VenEmail
            SQLcommand.Append(",'" & txtVenPhone.Text & "'") 'VenPhone
            SQLcommand.Append(",'" & txtVenFax.Text & "'") 'VenFax
            'SQLcommand.Append(",'" & txtBillToVenCode.Text & "'") 'BillToVenCode
            'SQLcommand.Append(",'" & txtBillToBranch.Text & "'") 'BillToBranch
            'SQLcommand.Append(",'" & txtShipToVenCode.Text & "'") 'ShipToVenCode
            'SQLcommand.Append(",'" & txtShipToBranch.Text & "'") 'ShipToBranch
            SQLcommand.Append(",'" & CInt(txtTermOfPayment.Text) & "'") 'TermOfPayment
            SQLcommand.Append(",'" & txtBillCondition.Text & "'") 'BillCondition
            ' SQLcommand.Append(",'" & CDbl(txtCreditLimit.Text) & "'") 'CreditLimit
            SQLcommand.Append(",'" & VenType & "'") 'VenType
            SQLcommand.Append(",'" & cmbVenGroup.Text & "'") 'VenGroup
            SQLcommand.Append(",'" & togIs_OverSea.CheckState & "'") 'Is_OverSea
            SQLcommand.Append(",'" & togIsAgentCoLoader.CheckState & "'") 'IsAgentCoLoader
            SQLcommand.Append(",'" & togIsShipper.CheckState & "'") 'IsShipper
            SQLcommand.Append(",'" & togIsConsign.CheckState & "'") 'IsConsign
            SQLcommand.Append(",'" & togIsNotify.CheckState & "'") 'IsNotify
            SQLcommand.Append(",'" & togIsAgentPartner.CheckState & "'") 'IsAgentPartner
            SQLcommand.Append(",'" & togIs_Local.CheckState & "'") 'Is_Local
            SQLcommand.Append(",'" & togIsLocalCoLoader.CheckState & "'") 'IsLocalCoLoader
            SQLcommand.Append(",'" & togIsActualShipper.CheckState & "'") 'IsActualShipper
            SQLcommand.Append(",'" & togIsActualConsignee.CheckState & "'") 'IsActualConsignee
            SQLcommand.Append(",'" & togIsActualNotify.CheckState & "'") 'IsActualNotify
            SQLcommand.Append(",'" & togIsCustomsBroker.CheckState & "'") 'IsCustomsBroker
            SQLcommand.Append(",'" & togIs_Line.CheckState & "'") 'Is_Line
            SQLcommand.Append(",'" & togIsAgentLineCoLoader.CheckState & "'") 'IsAgentLineCoLoader
            SQLcommand.Append(",'" & togIsAgentLine.CheckState & "'") 'IsAgentLine
            SQLcommand.Append(",'" & togIsAirLine.CheckState & "'") 'IsAirLine
            SQLcommand.Append(",'" & togIsTrucking.CheckState & "'") 'IsTrucking
            SQLcommand.Append(",'" & togIsTrain.CheckState & "'") 'IsTrain
            SQLcommand.Append(",'" & togIs_WareHouse.CheckState & "'") 'Is_WareHouse
            SQLcommand.Append(",'" & togIs_ContainerYard.CheckState & "'") 'Is_ContainerYard
            SQLcommand.Append(",'" & togActive.CheckState & "'") 'Active
            SQLcommand.Append(",'" & togIsPerson.CheckState & "'") 'Person
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                LoadData()
                grpAddBank.Enabled = True
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    Private Sub cmdClearContr_Click(sender As Object, e As EventArgs) Handles cmdClearContr.Click
        AddNewContact()
    End Sub
    Private Sub AddNewContact()
        txtCID.ResetText()
        txtContactName.ResetText()
        txtContactDescription.ResetText()
        txtTel.ResetText()
        txtFAX.ResetText()
        txtEmail.ResetText()
        togContractActive.Checked = True
        'dgvContact.Rows.Clear()
        _IsNewCont = True
        txtContactName.Focus()

    End Sub

    Private Sub cmdSaveContract_Click(sender As Object, e As EventArgs) Handles cmdSaveContract.Click
        If String.IsNullOrEmpty(txtVenCode.Text) Then
            txtVenCode.Style = MetroFramework.MetroColorStyle.Red
            txtVenCode.Focus()
            Exit Sub
        Else
            txtVenCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVenBranch.Text) Then
            txtVenBranch.Style = MetroFramework.MetroColorStyle.Red
            txtVenBranch.Focus()
            Exit Sub
        Else
            txtVenBranch.Style = MetroFramework.MetroColorStyle.Default
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
        AddNewContact()
    End Sub
    Private Sub SaveContact(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec [sp_lnsertOrupdateMas_VendorContact] ")
            SQLcommand.Append("'" & txtCID.Text & "'") '@@CID
            SQLcommand.Append(",'" & txtVenCode.Text & "'") '@CustCode
            SQLcommand.Append(",'" & txtVenBranch.Text & "'") ' BrCode
            SQLcommand.Append(",'" & txtContactName.Text & "'") '@ContactName
            SQLcommand.Append(",'" & txtContactDescription.Text & "'") ' @ContactDescription
            SQLcommand.Append(",'" & txtTel.Text & "'") '@@Tel
            SQLcommand.Append(",'" & txtFAX.Text & "'") '@@FAX
            SQLcommand.Append(",'" & txtEmail.Text & "'") '@@Email
            SQLcommand.Append(",'" & VenType & "'") '@@ContackType
            SQLcommand.Append(",'" & togContractActive.CheckState & "'") '@Active
            SQLcommand.Append(",'" & _Insert & "'") '@lnsertorupdate
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNewCont = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub


    Private Sub dgvContact_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvContact.CellMouseDoubleClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvContact.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtCID.Text = dgvContact.Rows(e.RowIndex).Cells(10).Value.ToString
                txtContactName.Text = dgvContact.Rows(e.RowIndex).Cells(1).Value.ToString
                txtContactDescription.Text = dgvContact.Rows(e.RowIndex).Cells(2).Value.ToString
                txtTel.Text = dgvContact.Rows(e.RowIndex).Cells(3).Value.ToString
                ' txtMobile.Text = dgvContact.Rows(e.RowIndex).Cells(4).Value.ToString
                txtFAX.Text = dgvContact.Rows(e.RowIndex).Cells(5).Value.ToString
                txtEmail.Text = dgvContact.Rows(e.RowIndex).Cells(6).Value.ToString
                togContractActive.Checked = CInt(dgvContact.Rows(e.RowIndex).Cells(9).Value.ToString)
                _IsNewCont = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub btnAddNewVessel_Click(sender As Object, e As EventArgs) Handles btnAddNewVessel.Click
        AddNewVessel()
    End Sub
    Private Sub AddNewVessel()
        txtTBIDNT.Text = "0"  'TBIDNT
        txtVesselCode.ResetText() 'RegisterNumber
        txtVesselName.ResetText() 'VesselName
        txtFeederCode.ResetText()
        txtFeederName.ResetText()
        txtMasterCode.ResetText()
        txtMasterName.ResetText()
        togVesselActive.Checked = True  'Active
        _IsNewVessel = True
        txtVesselCode.Focus()
    End Sub



    Private Sub btnSaveVessel_Click(sender As Object, e As EventArgs) Handles btnSaveVessel.Click
        If String.IsNullOrEmpty(txtVenCode.Text) Then
            txtVenCode.Style = MetroFramework.MetroColorStyle.Red
            txtVenCode.Focus()
            Exit Sub
        Else
            txtVenCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVenBranch.Text) Then
            txtVenBranch.Style = MetroFramework.MetroColorStyle.Red
            txtVenBranch.Focus()
            Exit Sub
        Else
            txtVenBranch.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVesselCode.Text) Then
            txtVesselCode.Focus()
            txtVesselCode.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtVesselCode.Style = MetroFramework.MetroColorStyle.Default
        End If


        Userauthorize(UserProfile.U_Code, "VSLIF")
        If _IsNewVessel Then
            If Userauthen.IsInsertData = 1 Then
                SaveVessel(1)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            If Userauthen.IsEditData = 1 Then
                SaveVessel(0)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub
    Private Sub SaveVessel(_insert As Integer)
        Try

            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_VesselVendor ")
            SQLcommand.Append("'" & txtTBIDNT.Text & "'") 'TBIDNT
            SQLcommand.Append(",'" & txtVenCode.Text & "'") 'VendorCode
            SQLcommand.Append(",'" & txtVenBranch.Text & "'") 'VendorBrCode
            SQLcommand.Append(",'" & txtVesselCode.Text & "'") 'VesselCode
            SQLcommand.Append(",'" & txtFeederCode.Text & "'") 'FeederCode
            SQLcommand.Append(",'" & txtMasterCode.Text & "'") 'MasterCode
            SQLcommand.Append(",'" & VenType & "'") 'VenType
            SQLcommand.Append(",'" & togVesselActive.CheckState & "'") 'Active
            SQLcommand.Append(",'" & _insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadVessel()
                AddNewVessel()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub dgvVesselList_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvVesselList.CellMouseDoubleClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvVesselList.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtTBIDNT.Text = dgvVesselList.CurrentRow.Cells(0).Value.ToString() 'TBIDNT
                'txtVenCode.Text = dgvVesselList.CurrentRow.Cells(1).Value.ToString() 'VendorCode
                'txtVenBranch.Text = dgvVesselList.CurrentRow.Cells(2).Value.ToString() 'VendorBrCode
                'txtVenName.Text = dgvVesselList.CurrentRow.Cells(3).Value.ToString() 'VenName
                txtVesselCode.Text = dgvVesselList.CurrentRow.Cells(4).Value.ToString() 'VesselCode
                txtVesselName.Text = dgvVesselList.CurrentRow.Cells(5).Value.ToString() 'VesselName
                txtFeederCode.Text = dgvVesselList.CurrentRow.Cells(6).Value.ToString() 'FeederCode
                txtFeederName.Text = dgvVesselList.CurrentRow.Cells(7).Value.ToString() 'FeederName
                txtMasterCode.Text = dgvVesselList.CurrentRow.Cells(8).Value.ToString() 'MasterCode
                txtMasterName.Text = dgvVesselList.CurrentRow.Cells(9).Value.ToString() 'MasterName
                togVesselActive.Checked = CInt(dgvVesselList.CurrentRow.Cells(10).Value.ToString()) 'Active
                _IsNewVessel = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtTaxNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTaxNumber.KeyPress
        CheckNumeric(e)
    End Sub

    Private Sub btnNewAgency_Click(sender As Object, e As EventArgs) Handles btnNewAgency.Click
        If String.IsNullOrEmpty(txtVenCode.Text) Or String.IsNullOrEmpty(txtVenBranch.Text) Then Exit Sub
        frmMasagency.VenCode = Me.txtVenCode.Text
        frmMasagency.BranchCode = Me.txtVenBranch.Text
        frmMasagency.HIdentity = 0
        'frmMasAgency._IsNew = True
        frmMasagency.ShowDialog()
        LoadAgentList()
    End Sub

    Private Sub btnEditAgency_Click(sender As Object, e As EventArgs) Handles btnEditAgency.Click
        'Try
        '    If dgvVesselList.CurrentRow.Index < 0 Or dgvVesselList.CurrentRow.Index > dgvAgentList.Rows.Count - 1 Then Exit Sub
        '    If dgvVesselList.CurrentRow.Index >= 0 Then
        '        frmMasAgency.VenCode = Me.txtVenCode.Text
        '        frmMasAgency.BranchCode = Me.txtVenBranch.Text
        '        frmMasAgency.HIdentity = CInt(dgvAgentList.CurrentRow.Cells(0).Value.ToString()) 'TBIDNT
        '        frmMasAgency.ShowDialog()
        '        LoadAgentList()
        '    End If
        'Catch ex As Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub

    Private Sub dgvAgentList_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAgentList.CellMouseDoubleClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvAgentList.Rows.Count - 1 Then Exit Sub
            'MessageBox.Show("test click")
            If e.RowIndex >= 0 Then
                frmMasagency.VenCode = Me.txtVenCode.Text
                frmMasagency.BranchCode = Me.txtVenBranch.Text
                frmMasagency.HIdentity = CInt(dgvAgentList.CurrentRow.Cells(0).Value.ToString()) 'TBIDNT
                frmMasagency.ShowDialog()
                LoadAgentList()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub txtVesselCode_ButtonClick(sender As Object, e As EventArgs) Handles txtVesselCode.ButtonClick
        SelectVessel(txtVesselCode, txtVesselName)
    End Sub

    Private Sub txtVesselCode_ClearClicked() Handles txtVesselCode.ClearClicked
        txtVesselName.ResetText()
    End Sub

    Private Sub txtFeederCode_ButtonClick(sender As Object, e As EventArgs) Handles txtFeederCode.ButtonClick
        SelectVessel(txtFeederCode, txtFeederName)
    End Sub

    Private Sub txtFeederCode_ClearClicked() Handles txtFeederCode.ClearClicked
        txtFeederName.ResetText()
    End Sub

    Private Sub txtMasterCode_ButtonClick(sender As Object, e As EventArgs) Handles txtMasterCode.ButtonClick
        SelectVessel(txtMasterCode, txtMasterName)
    End Sub

    Private Sub txtMasterCode_ClearClicked() Handles txtMasterCode.ClearClicked
        txtMasterName.ResetText()
    End Sub

    Private Sub cmbVenGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVenGroup.SelectedIndexChanged
        If _IsNew Then CaseRunning()
    End Sub

    Private Sub txtVenBranch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVenBranch.KeyPress
        CheckNumeric(e)
    End Sub

    Private Sub txtVenCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVenPhone.KeyPress, txtVenName.KeyPress, txtVenFax.KeyPress, txtVenEmail.KeyPress, txtVenContact.KeyPress, txtVenCode.KeyPress, txtVenCity.KeyPress, txtTTAddress.KeyPress, txtTAddress.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtBillCondition_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBillCondition.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtContactName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTel.KeyPress, txtFAX.KeyPress, txtEmail.KeyPress, txtContactName.KeyPress, txtContactDescription.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtPurchaseCity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPurchaseCity.KeyPress
        SelectCountryName(txtPurchaseCity.Text, txtPurchaseCityName)
    End Sub

    Private Sub txtPurchaseCity_Leave(sender As Object, e As EventArgs) Handles txtPurchaseCity.Leave
        SelectCountryName(txtPurchaseCity.Text, txtPurchaseCityName)
    End Sub

    Private Sub txtPurchaseCity_ClearClicked() Handles txtPurchaseCity.ClearClicked
        txtPurchaseCityName.ResetText()
    End Sub
    '*********************************** Bank *************************************
    Private Sub btnNewBank_Click(sender As Object, e As EventArgs) Handles btnNewBank.Click
        Userauthorize(UserProfile.U_Code, "VENBCK")
        If Userauthen.IsInsertData = 1 Then
            AddNewBank()
        Else
            MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub
    Private Sub AddNewBank()
        txtBCKCode.ResetText()
        txtBookCode.ResetText()
        txtBookName.ResetText()
        txtBankBranch.ResetText()
        txtBookName.ResetText()
        txtIsNewBank.Text = "1"
        txtIdent.Text = "0"
        togIsActive.Checked = True
        txtBCKCode.ReadOnly = False
        txtBCKCode.Focus()
    End Sub

    Private Sub btnSaveBank_Click(sender As Object, e As EventArgs) Handles btnSaveBank.Click
        If String.IsNullOrEmpty(txtVenCode.Text) Then Exit Sub
        If String.IsNullOrEmpty(txtBCKCode.Text) Then
            txtBCKCode.Focus()
            txtBCKCode.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtBCKCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtBookCode.Text) Then
            txtBookCode.Focus()
            txtBookCode.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtBookCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtBookName.Text) Then
            txtBookName.Focus()
            txtBookName.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtBookName.Style = MetroFramework.MetroColorStyle.Default
        End If
        'VENBCK
        Userauthorize(UserProfile.U_Code, "VENBCK")
        If txtIsNewBank.Text = "1" Then
            If Userauthen.IsInsertData = 1 Then
                If CheckExistCode("Mas_VendorBook", "BookCode", txtBookCode.Text) = False Then
                    SaveDataBank(1)
                Else
                    MetroFramework.MetroMessageBox.Show(Me, "BookCode Already Exist In Database!", "Check Existing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        Else
            If Userauthen.IsEditData = 1 Then
                SaveDataBank(0)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If

    End Sub
    Private Sub SaveDataBank(_Insert As Integer)
        Try

            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_VendorBook ")
            SQLcommand.Append("'" & txtIdent.Text & "'") 'TBIDNT
            SQLcommand.Append(",'" & CMPCode & "'") 'CMPCode
            SQLcommand.Append(",'" & BrCode & "'") 'BranchCode
            SQLcommand.Append(",'" & HIdentity & "'") 'VENTBIDNT
            SQLcommand.Append(",'" & txtBCKCode.Text & "'") 'BCKCode
            SQLcommand.Append(",'" & txtBookCode.Text & "'") 'BookCode
            SQLcommand.Append(",'" & txtBookName.Text & "'") 'BookName
            '  SQLcommand.Append(",'" & txtBankCode.Text & "'") 'BankCode
            SQLcommand.Append(",'" & txtBankBranch.Text & "'") 'BankBranch
            '  SQLcommand.Append(",'" & txtBCKAddress.Text & "'") 'BCKAddress
            '  SQLcommand.Append(",'" & txtBankCountry.Text & "'") 'BankCountry
            '  SQLcommand.Append(",'" & txtPhone.Text & "'") 'Phone
            '  SQLcommand.Append(",'" & txtFaxNumber.Text & "'") 'FaxNumber
            '  SQLcommand.Append(",'" & txtACType.Text & "'") 'ACType
            '  SQLcommand.Append(",'" & togIsOutLocal.CheckState & "'") 'IsOutLocal
            '  SQLcommand.Append(",'" & txtAccCode.Text & "'") 'AccCode
            SQLcommand.Append(",'" & togIsActive.CheckState & "'") 'IsActive
            SQLcommand.Append(",'" & txtVenCode.Text & "'") 'VENReF
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataVenBank()
                AddNewBank()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataVenBank()
        Try
            dgvVenBank.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Mas_VendorBook where BranchCode='" & BrCode & "' and CMPCode='" & CMPCode & "' AND VENTBIDNT='" & HIdentity & "'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvVenBank.Rows.Add(dt.Rows(i)("TBIDNT").ToString(), 'TBIDNT
                       dt.Rows(i)("CMPCode").ToString(), 'CMPCode
                       dt.Rows(i)("BranchCode").ToString(), 'BranchCode
                       dt.Rows(i)("VENTBIDNT").ToString(), 'VENTBIDNT
                       dt.Rows(i)("BCKCode").ToString(), 'BCKCode
                       dt.Rows(i)("BookCode").ToString(), 'BookCode
                       dt.Rows(i)("BookName").ToString(), 'BookName
                       dt.Rows(i)("BankBranch").ToString(), 'BankBranch
                       dt.Rows(i)("IsActive").ToString(), 'IsActive
                       "0" 'Insert
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

    Private Sub dgvVenBank_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvVenBank.CellMouseDoubleClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvVenBank.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdent.Text = dgvVenBank.CurrentRow.Cells(0).Value.ToString() 'TBIDNT
                'txtCMPCode.Text = dgvVenBank.CurrentRow.Cells(1).Value.ToString() 'CMPCode
                'txtBranchCode.Text = dgvVenBank.CurrentRow.Cells(2).Value.ToString() 'BranchCode
                'txtVENTBIDNT.te = CInt(dgvVenBank.CurrentRow.Cells(3).Value.ToString()) 'VENTBIDNT
                txtBCKCode.Text = dgvVenBank.CurrentRow.Cells(4).Value.ToString() 'BCKCode
                txtBookCode.Text = dgvVenBank.CurrentRow.Cells(5).Value.ToString() 'BookCode
                txtBookName.Text = dgvVenBank.CurrentRow.Cells(6).Value.ToString() 'BookName
                'txtBankCode.Text = dgvVenBank.CurrentRow.Cells(7).Value.ToString() 'BankCode
                txtBankBranch.Text = dgvVenBank.CurrentRow.Cells(7).Value.ToString() 'BankBranch
                'txtBCKAddress.Text = dgvVenBank.CurrentRow.Cells(9).Value.ToString() 'BCKAddress
                'txtBankCountry.Text = dgvVenBank.CurrentRow.Cells(10).Value.ToString() 'BankCountry
                'txtPhone.Text = dgvVenBank.CurrentRow.Cells(11).Value.ToString() 'Phone
                'txtFaxNumber.Text = dgvVenBank.CurrentRow.Cells(12).Value.ToString() 'FaxNumber
                'txtACType.Text = dgvVenBank.CurrentRow.Cells(13).Value.ToString() 'ACType
                'togIsOutLocal.Checked = CInt(dgvVenBank.CurrentRow.Cells(14).Value.ToString()) 'IsOutLocal
                'txtAccCode.Text = dgvVenBank.CurrentRow.Cells(15).Value.ToString() 'AccCode
                togIsActive.Checked = CInt(dgvVenBank.CurrentRow.Cells(8).Value.ToString()) 'IsActive
                txtIsNewBank.Text = dgvVenBank.CurrentRow.Cells(9).Value.ToString()
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class