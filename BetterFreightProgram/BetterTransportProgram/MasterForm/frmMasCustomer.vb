Imports System.Text

Public Class frmMasCustomer
    Public CMPCode As String = CMPProfile.PROF_Code
    Public BrCode As String = CMPProfile.PROF_BrCode
    Public HIdentity As Integer
    Public _IsNew As Boolean
    Public _IsNewCont As Boolean
    Public CustCode As String
    Public BranchCode As String
    Private Sub frmMasCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddNewData()
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        AddNewData()
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT [CustCode] ,[CustBranch] ,[TaxNumber] ,[CustName],TAddress,TBIDNT  FROM [V_MasCustomer] WHERE CustType='CST' AND [CMPCode]='" & CMPCode & "' and BranchCode='" & BrCode & "' order by [CustCode] ", MainConnection)
            If isSearchOK Then
                HIdentity = CInt(dr("TBIDNT").ToString)
                LoadData()

            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

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
        If String.IsNullOrEmpty(txtTAddress.Text) Then
            txtTAddress.Style = MetroFramework.MetroColorStyle.Red
            txtTAddress.Focus()
            Exit Sub
        Else
            txtTAddress.Style = MetroFramework.MetroColorStyle.Default
        End If
        'If String.IsNullOrEmpty(txtCustCity.Text) Then
        '    txtCustCity.Style = MetroFramework.MetroColorStyle.Red
        '    txtCustCity.Focus()
        '    Exit Sub
        'Else
        '    txtCustCity.Style = MetroFramework.MetroColorStyle.Default
        'End If
        If String.IsNullOrEmpty(txtPurchaseCity.Text) Then
            txtPurchaseCity.Style = MetroFramework.MetroColorStyle.Red
            txtPurchaseCity.Focus()
            Exit Sub
        Else
            txtPurchaseCity.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtCustEmail.Text) = False Then
            If txtCustEmail.Text.Contains("@") = False Then
                MetroFramework.MetroMessageBox.Show(frmMain, "Email incorected format!", "Check format", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtCustEmail.Style = MetroFramework.MetroColorStyle.Red
                txtCustEmail.Focus()
                Exit Sub
            Else
                txtCustEmail.Style = MetroFramework.MetroColorStyle.Default
            End If

        Else
            txtCustEmail.Style = MetroFramework.MetroColorStyle.Default
        End If
        UserAuthorize(UserProfile.U_Code, "CSTIF")
        If _IsNew Then
            If UserAuthen.IsInsertData = 1 Then
                If txtCustCode.Text = "" Or txtCustCode.Text = RunningForm.Run_Formatt Then
                    txtCustCode.Text = CreateNumber("Mas_Customer", "CustCode", True)
                Else
                    If CheckCustCode(txtCustCode.Text, txtBranch.Text, "CST") Then
                        MetroFramework.MetroMessageBox.Show(frmMain, "Customer Code " & txtCustCode.Text & " Branch " & txtBranch.Text & " Already Existing In Database!", "Check Existing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    SaveData(1)
                End If
            Else
                MetroFramework.MetroMessageBox.Show(frmMain, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        Else
            If UserAuthen.IsEditData = 1 Then
                SaveData(0)
            Else
                MetroFramework.MetroMessageBox.Show(frmMain, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub SaveData(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec [sp_lnsertOrupdateMas_Customer] ")
            SQLcommand.Append("'" & HIdentity & "'") '@MIdent
            SQLcommand.Append(",'" & CMPCode & "'") 'CMPCode
            SQLcommand.Append(",'" & BrCode & "'") ' BrCode
            SQLcommand.Append(",'" & txtCustCode.Text & "'") 'Custcode
            SQLcommand.Append(",'" & txtBranch.Text & "'") ' Branchcode
            SQLcommand.Append(",'" & txtTaxNumber.Text & "'") '@TaxNumber
            SQLcommand.Append(",'" & txtPurchaseCity.Text & "'") '@PurchaseCity
            SQLcommand.Append(",'" & txtNameEng.Text & "'") '@NameEng
            SQLcommand.Append(",'" & txtTAddress.Text & "'") '@TAddress
            SQLcommand.Append(",'" & txtTTAddress.Text & "'") '@TTAddress
            SQLcommand.Append(",'" & txtCustCity.Text & "'") '@CustCity
            SQLcommand.Append(",'" & txtCustContact.Text & "'") '@CustContact
            SQLcommand.Append(",'" & txtCustEmail.Text & "'") '@CustEmail
            SQLcommand.Append(",'" & txtCustPhone.Text & "'") '@CustPhone
            SQLcommand.Append(",'" & txtCustFax.Text & "'") '@CustFax
            SQLcommand.Append(",'" & txtGLAccountCode.Text & "'") 'GLCode
            If _Insert = 1 Then
                SQLcommand.Append(",'" & txtCustCode.Text & "'") 'Custcode
                SQLcommand.Append(",'" & txtBranch.Text & "'") ' Branchcode
                SQLcommand.Append(",'" & txtCustCode.Text & "'") 'Custcode
                SQLcommand.Append(",'" & txtBranch.Text & "'") ' Branchcode
            Else
                SQLcommand.Append(",'" & txtBillToCustCode.Text & "'") '@BillToCustCode
                SQLcommand.Append(",'" & txtBillToBranch.Text & "'") '@BillToBranch
                SQLcommand.Append(",'" & txtShipToCustCode.Text & "'") '@ShipToCustCode
                SQLcommand.Append(",'" & txtShipToBranch.Text & "'") '@ShipToBranch
            End If

            SQLcommand.Append(",'" & txtTermOfPayment.Text & "'") '@TermOfPayment
            SQLcommand.Append(",'" & txtNotifyToCustCode.Text & "'") 'NotifyToCustCode
            SQLcommand.Append(",'" & txtNotifyToBranch.Text & "'") 'NotifyToBranch
            SQLcommand.Append(",'" & txtBillCondition.Text & "'") '@AccountRemark
            SQLcommand.Append(",'" & txtCustPayContract.Text & "'") 'CustPayContract
            SQLcommand.Append(",'CST'") '@CustType

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
            SQLcommand.Append(",'" & togActive.CheckState & "'") '@Active
            SQLcommand.Append(",'" & _Insert & "'") '@lnsertorupdate
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(frmMain, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                If _Insert = 1 Then
                    SaveBillTo(1)
                    SaveShipTo(1)
                End If
                ' LoadData()
                txtCustCode.ReadOnly = True
                txtBranch.ReadOnly = True
            Else
                MetroFramework.MetroMessageBox.Show(frmMain, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveBillTo(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec [sp_lnsertOrupdateMas_Customer] ")
            SQLcommand.Append("'" & HIdentity & "'") '@MIdent
            SQLcommand.Append(",'" & CMPCode & "'") 'CMPCode
            SQLcommand.Append(",'" & BrCode & "'") ' BrCode
            SQLcommand.Append(",'" & txtCustCode.Text & "'") 'Custcode
            SQLcommand.Append(",'" & txtBranch.Text & "'") ' Branchcode
            SQLcommand.Append(",'" & txtTaxNumber.Text & "'") '@TaxNumber
            SQLcommand.Append(",'" & txtPurchaseCity.Text & "'") '@PurchaseCity
            SQLcommand.Append(",'" & txtNameEng.Text & "'") '@NameEng
            SQLcommand.Append(",'" & txtTAddress.Text & "'") '@TAddress
            SQLcommand.Append(",'" & txtTTAddress.Text & "'") '@TAddress
            SQLcommand.Append(",'" & txtCustCity.Text & "'") '@CustCity
            SQLcommand.Append(",'" & txtCustContact.Text & "'") '@CustContact
            SQLcommand.Append(",'" & txtCustEmail.Text & "'") '@CustEmail
            SQLcommand.Append(",'" & txtCustPhone.Text & "'") '@CustPhone
            SQLcommand.Append(",'" & txtCustFax.Text & "'") '@CustFax
            SQLcommand.Append(",'" & txtGLAccountCode.Text & "'") '@GL
            SQLcommand.Append(",'" & txtCustCode.Text & "'") 'Custcode
            SQLcommand.Append(",'" & txtBranch.Text & "'") ' Branchcode
            SQLcommand.Append(",'" & txtCustCode.Text & "'") 'Custcode
            SQLcommand.Append(",'" & txtBranch.Text & "'") ' Branchcode
            SQLcommand.Append(",'" & txtTermOfPayment.Text & "'") '@TermOfPayment
            SQLcommand.Append(",'" & txtNotifyToCustCode.Text & "'") 'NotifyToCustCode
            SQLcommand.Append(",'" & txtNotifyToBranch.Text & "'") 'NotifyToBranch
            'SQLcommand.Append(",'" & txtBillCondition.Text & "'") '@AccountRemark
            SQLcommand.Append(",''") '@AccountRemark
            SQLcommand.Append(",'" & txtCustPayContract.Text & "'") 'CustPayContract
            SQLcommand.Append(",'BILL'") '@CustType
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
            SQLcommand.Append(",'" & togActive.CheckState & "'") '@Active
            SQLcommand.Append(",'" & _Insert & "'") '@lnsertorupdate
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                ' MetroFramework.MetroMessageBox.Show(frmMain, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroFramework.MetroMessageBox.Show(frmMain, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveShipTo(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec [sp_lnsertOrupdateMas_Customer] ")
            SQLcommand.Append("'" & HIdentity & "'") '@MIdent
            SQLcommand.Append(",'" & CMPCode & "'") 'CMPCode
            SQLcommand.Append(",'" & BrCode & "'") ' BrCode
            SQLcommand.Append(",'" & txtCustCode.Text & "'") 'Custcode
            SQLcommand.Append(",'" & txtBranch.Text & "'") ' Branchcode
            SQLcommand.Append(",'" & txtTaxNumber.Text & "'") '@TaxNumber
            SQLcommand.Append(",'" & txtPurchaseCity.Text & "'") '@PurchaseCity
            SQLcommand.Append(",'" & txtNameEng.Text & "'") '@NameEng
            SQLcommand.Append(",'" & txtTAddress.Text & "'") '@TAddress
            SQLcommand.Append(",'" & txtTTAddress.Text & "'") '@TAddress
            SQLcommand.Append(",'" & txtCustCity.Text & "'") '@CustCity
            SQLcommand.Append(",'" & txtCustContact.Text & "'") '@CustContact
            SQLcommand.Append(",'" & txtCustEmail.Text & "'") '@CustEmail
            SQLcommand.Append(",'" & txtCustPhone.Text & "'") '@CustPhone
            SQLcommand.Append(",'" & txtCustFax.Text & "'") '@CustFax
            SQLcommand.Append(",'" & txtGLAccountCode.Text & "'") '@GL
            SQLcommand.Append(",'" & txtCustCode.Text & "'") 'Custcode
            SQLcommand.Append(",'" & txtBranch.Text & "'") ' Branchcode
            SQLcommand.Append(",'" & txtCustCode.Text & "'") 'Custcode
            SQLcommand.Append(",'" & txtBranch.Text & "'") ' Branchcode
            SQLcommand.Append(",'" & txtTermOfPayment.Text & "'") '@TermOfPayment
            SQLcommand.Append(",'" & txtNotifyToCustCode.Text & "'") 'NotifyToCustCode
            SQLcommand.Append(",'" & txtNotifyToBranch.Text & "'") 'NotifyToBranch
            'SQLcommand.Append(",'" & txtBillCondition.Text & "'") '@AccountRemark
            SQLcommand.Append(",''") '@AccountRemark
            SQLcommand.Append(",'" & txtCustPayContract.Text & "'") 'CustPayContract
            SQLcommand.Append(",'SHP'") '@CustType
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
            SQLcommand.Append(",'" & togActive.CheckState & "'") '@Active
            SQLcommand.Append(",'" & _Insert & "'") '@lnsertorupdate
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                ' MetroFramework.MetroMessageBox.Show(frmMain, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroFramework.MetroMessageBox.Show(frmMain, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadData()
        Try
            Dim str As String = "SELECT * FROM [V_MasCustomer] where CustType='CST' "
            If HIdentity > 0 Then str &= " and TBIDNT='" & HIdentity & "'"
            Dim dr As DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                _IsNew = False
                HIdentity = dr("TBIDNT").ToString
                MetroTextBox1.Text = dr("TBIDNT").ToString 'test
                txtTaxNumber.Text = dr("TaxNumber").ToString
                txtCustCode.Text = dr("CustCode").ToString
                txtBranch.Text = dr("CustBranch").ToString
                txtNameEng.Text = dr("CustName").ToString
                txtTAddress.Text = dr("TAddress").ToString
                txtTTAddress.Text = dr("TTAddress").ToString
                txtCustCity.Text = dr("Custcity").ToString
                txtPurchaseCity.Text = dr("PurchaseCity").ToString
                txtPurchaseCityName.Text = dr("CountryName").ToString
                txtCustContact.Text = dr("CustContact").ToString
                txtCustEmail.Text = dr("CustEmail").ToString
                txtCustPhone.Text = dr("CustPhone").ToString
                txtCustFax.Text = dr("CustFax").ToString
                txtGLAccountCode.Text = dr("GLAccountCode").ToString
                ' txtGLAccountName.Text = dr("AccTName").ToString
                txtTermOfPayment.Text = dr("TermOfPayment").ToString
                togActive.Checked = CInt(dr("Active").ToString)

                txtBillToCustCode.Text = dr("BillToCustCode").ToString
                txtBillToBranch.Text = dr("BillToBranch").ToString
                txtBillToCustName.Text = dr("BillCustName").ToString

                txtShipToCustCode.Text = dr("ShipToCustCode").ToString
                txtShipToBranch.Text = dr("ShipToBranch").ToString
                txtShipToName.Text = dr("ShipCustName").ToString

                txtNotifyToCustCode.Text = dr("NotifyToCustCode").ToString 'NotifyToCustCode
                txtNotifyToBranch.Text = dr("NotifyToBranch").ToString 'NotifyToBranch
                txtNotifyName.Text = dr("NotifyCustName").ToString 'NotifyToBranch

                txtBillCondition.Text = dr("BillCondition").ToString
                txtCustPayContract.Text = dr("CustPayContract").ToString
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

                txtCustCode.ReadOnly = True
                LoadBillTo()
                LoadShipTo()
                LoadNotify()
                LoadContact()
                groupplace.Visible = True
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub LoadBillTo()
        Try
            dgvBillPlace.Rows.Clear()
            Dim da As New OleDb.OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim str As String
            str = "SELECT [CustCode],[CustBranch],[CustName],[CustCity],[CMPCode],[BranchCode],[Active], [TBIDNT]  FROM [Mas_Customer] where [CustType]='BILL' and [BillToCustCode] = '" & txtCustCode.Text & "' and [BillToBranch] = '" & txtBranch.Text & "'" & " and BranchCode='" & BrCode & "' and CMPCode='" & CMPCode & "'"
            da.SelectCommand = New OleDb.OleDbCommand(str, MainConnection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvBillPlace.Rows.Add(i + 1,
                    dt(i)(0).ToString, 'CustCode
                    dt(i)(1).ToString, 'Branch
                    dt(i)(2).ToString, 'NameEng
                    dt(i)(3).ToString, 'CustCity
                    dt(i)(4).ToString, 'CMPCode
                    dt(i)(5).ToString,'BranchCode
                    dt(i)(6).ToString, 'Active
                    dt(i)(7).ToString 'MIdent
                    )
                Next
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub LoadShipTo()
        Try
            dgvShipPlace.Rows.Clear()
            Dim da As New OleDb.OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim str As String
            str = "SELECT [CustCode],[CustBranch],[CustName],[CustCity],[CMPCode],[BranchCode],[Active], [TBIDNT] FROM [Mas_Customer] where [CustType]='SHP' and [ShipToCustCode] = '" & txtCustCode.Text & "' and [ShipToBranch] = '" & txtBranch.Text & "'" & " and BranchCode='" & BrCode & "' and CMPCode='" & CMPCode & "'"
            da.SelectCommand = New OleDb.OleDbCommand(str, MainConnection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvShipPlace.Rows.Add(i + 1,
                    dt(i)(0).ToString, 'CustCode
                    dt(i)(1).ToString, 'Branch
                    dt(i)(2).ToString, 'NameEng
                    dt(i)(3).ToString, 'CustCity
                    dt(i)(4).ToString, 'CMPCode
                    dt(i)(5).ToString,'BranchCode
                    dt(i)(6).ToString, 'Active
                    dt(i)(7).ToString 'MIdent
                    )
                Next
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub LoadNotify()
        Try
            dgvNotify.Rows.Clear()
            Dim da As New OleDb.OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim str As String
            str = "SELECT [CustCode],[CustBranch],[CustName],[CustCity],[CMPCode],[BranchCode],[Active]
                    , [TBIDNT] FROM [Mas_Customer] where [CustType]='NFP' and [NotifyToCustCode] = '" & txtCustCode.Text & "' 
                    and [NotifyToBranch] = '" & txtBranch.Text & "'" & " and BranchCode='" & BrCode & "' 
                    and CMPCode='" & CMPCode & "'"
            da.SelectCommand = New OleDb.OleDbCommand(str, MainConnection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvNotify.Rows.Add(i + 1,
                    dt(i)(0).ToString, 'CustCode
                    dt(i)(1).ToString, 'Branch
                    dt(i)(2).ToString, 'NameEng
                    dt(i)(3).ToString, 'CustCity
                    dt(i)(4).ToString, 'CMPCode
                    dt(i)(5).ToString,'BranchCode
                    dt(i)(6).ToString, 'Active
                    dt(i)(7).ToString 'MIdent
                    )
                Next
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadContact()
        Try
            dgvContact.Rows.Clear()
            Dim da As New OleDb.OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim str As String
            str = "SELECT [TBIDNT],[ContactName],[ContactDescription],[ContactPhone],[ContactMobile],[ContactFAX],[ContactEmail],[CustCode],[CustBranch],[Active]  FROM Mas_CustomerContact where CustCode='" & txtCustCode.Text & "' and CustBranch='" & txtBranch.Text & "' order by [TBIDNT]"
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
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub AddNewData()
        groupplace.Visible = False
        UserAuthorize(UserProfile.U_Code, "CSTIF")
        If UserAuthen.IsInsertData = 1 Then
            _IsNew = True
            ResetAllText()
            ResetStyle()
            CaseRunning()
            txtCustCode.ReadOnly = False
            txtBranch.ReadOnly = False
            txtCustCode.Focus()
        Else
            MetroFramework.MetroMessageBox.Show(frmMain, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
    Private Sub CaseRunning()
        If _IsNew = False Then Exit Sub
        Select Case cmbVenGroup.Text
            Case "OverSea"
                GetRunningFormat("COVS")
            Case "Local"
                GetRunningFormat("CLOC")
            Case "Line"
                GetRunningFormat("CLIN")
        End Select
        txtCustCode.Text = RunningForm.Run_Formatt
    End Sub
    Private Sub ResetAllText()
        txtTaxNumber.ResetText()
        txtCustCode.ResetText()
        txtBranch.Text = "000000"
        txtNameEng.ResetText()
        txtTAddress.ResetText()
        txtTTAddress.ResetText()
        txtCustCity.ResetText()
        txtPurchaseCity.ResetText()
        txtPurchaseCityName.ResetText()
        txtCustContact.ResetText()
        txtCustEmail.ResetText()
        txtCustPhone.ResetText()
        txtCustFax.ResetText()
        txtTermOfPayment.Text = "0"
        togActive.Checked = True
        txtBillToCustCode.ResetText()
        txtBillToBranch.ResetText()
        txtBillToCustName.ResetText()
        txtShipToCustCode.ResetText()
        txtShipToBranch.ResetText()
        txtShipToName.ResetText()
        'txtGLAccountCode.ResetText()
        'txtGLAccountName.ResetText()
        txtNotifyToCustCode.ResetText() 'NotifyToCustCode
        txtNotifyToBranch.ResetText() 'NotifyToBranch
        txtNotifyName.ResetText()
        txtBillCondition.ResetText() 'BillCondition
        txtCustPayContract.ResetText() 'CustPayContract
        cmbVenGroup.ResetText() 'VenGroup
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

        dgvBillPlace.Rows.Clear()
        dgvShipPlace.Rows.Clear()
        dgvNotify.Rows.Clear()
        dgvContact.Rows.Clear()
        AddNewContact()

    End Sub
    Private Sub ResetStyle()
        txtTaxNumber.Style = MetroFramework.MetroColorStyle.Default
        txtCustCode.Style = MetroFramework.MetroColorStyle.Default
        txtBranch.Style = MetroFramework.MetroColorStyle.Default
        txtNameEng.Style = MetroFramework.MetroColorStyle.Default
        txtTAddress.Style = MetroFramework.MetroColorStyle.Default
        txtCustCity.Style = MetroFramework.MetroColorStyle.Default
        txtPurchaseCity.Style = MetroFramework.MetroColorStyle.Default
        txtPurchaseCityName.Style = MetroFramework.MetroColorStyle.Default

        txtCustEmail.Style = MetroFramework.MetroColorStyle.Default
        txtCustPhone.Style = MetroFramework.MetroColorStyle.Default
        txtCustFax.Style = MetroFramework.MetroColorStyle.Default
        txtTermOfPayment.Style = MetroFramework.MetroColorStyle.Default
        txtBillToCustCode.Style = MetroFramework.MetroColorStyle.Default
        txtBillToBranch.Style = MetroFramework.MetroColorStyle.Default
        txtBillToCustName.Style = MetroFramework.MetroColorStyle.Default
        txtShipToCustCode.Style = MetroFramework.MetroColorStyle.Default
        txtShipToBranch.Style = MetroFramework.MetroColorStyle.Default
        txtShipToName.Style = MetroFramework.MetroColorStyle.Default
    End Sub

    Private Sub txtTaxNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTaxNumber.KeyPress
        CheckNumeric(e)
    End Sub

    Private Sub txtCustCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCustCode.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtBranch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBranch.KeyPress
        'CheckQuote(e)
        CheckNumeric(e)
    End Sub

    Private Sub txtNameEng_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNameEng.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtTAddress_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTAddress.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustCity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCustCity.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCustEmail.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCustPhone.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustFax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCustFax.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtTermOfPayment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTermOfPayment.KeyPress
        CheckNumeric(e)
    End Sub

    Private Sub txtContactName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactName.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtContactDescription_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactDescription.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtPurchaseCity_ButtonClick(sender As Object, e As EventArgs) Handles txtPurchaseCity.ButtonClick
        SelectCountry(txtPurchaseCity, txtPurchaseCityName)
    End Sub

    Private Sub txtBillToCustCode_ButtonClick(sender As Object, e As EventArgs) Handles txtBillToCustCode.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT [CustCode] ,[CustBranch] ,[TaxNumber] ,[CustName] ,[TAddress] FROM [Mas_Customer] WHERE CustType='BILL' and [Active]=1 and [CMPCode]='" & CMPCode & "' and BranchCode='" & BrCode & "' and BillToCustCode='" & txtCustCode.Text & "' and BillToBranch='" & txtBranch.Text & "' order by [CustCode] ", MainConnection)
            If isSearchOK Then
                txtBillToCustCode.Text = dr("CustCode").ToString()
                txtBillToBranch.Text = dr("CustBranch").ToString()
                txtBillToCustName.Text = dr("CustName").ToString()
            End If
            dr = Nothing
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtShipToCustCode_ButtonClick(sender As Object, e As EventArgs)
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT [CustCode] ,[CustBranch] ,[TaxNumber] ,[CustName] ,[TAddress] FROM [Mas_Customer] WHERE CustType='SHP' and [Active]=1 and [CMPCode]='" & CMPCode & "' and BranchCode='" & BrCode & "' and ShipToCustCode='" & txtCustCode.Text & "' and ShipToBranch='" & txtBranch.Text & "' order by [CustCode] ", MainConnection)
            If isSearchOK Then
                txtShipToCustCode.Text = dr("CustCode").ToString()
                txtShipToBranch.Text = dr("CustBranch").ToString()
                txtShipToName.Text = dr("CustName").ToString()
            End If
            dr = Nothing
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
    End Sub
    Private Sub SaveContact(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec [sp_lnsertOrupdateMas_CustomerContact] ")
            SQLcommand.Append("'" & txtCID.Text & "'") '@@CID
            SQLcommand.Append(",'" & txtCustCode.Text & "'") '@CustCode
            SQLcommand.Append(",'" & txtBranch.Text & "'") ' BrCode
            SQLcommand.Append(",'" & txtContactName.Text & "'") '@ContactName
            SQLcommand.Append(",'" & txtContactDescription.Text & "'") ' @ContactDescription
            SQLcommand.Append(",'" & txtTel.Text & "'") '@@Tel
            SQLcommand.Append(",'" & txtFAX.Text & "'") '@@FAX
            SQLcommand.Append(",'" & txtEmail.Text & "'") '@@Email
            SQLcommand.Append(",'" & togContractActive.CheckState & "'") '@Active
            SQLcommand.Append(",'" & _Insert & "'") '@lnsertorupdate
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(frmMain, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '  _IsNewCont = False
                AddNewContact()
            Else
                MetroFramework.MetroMessageBox.Show(frmMain, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvBillPlace_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvBillPlace.CellMouseDoubleClick
        Try
            UserAuthorize(UserProfile.U_Code, "BILIF")
            If e.RowIndex < 0 Or e.RowIndex > dgvBillPlace.RowCount - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                If UserAuthen.IsEditData = 1 Then
                    frmMasBillPlace.CustCode = dgvBillPlace.CurrentRow.Cells(1).Value.ToString
                    frmMasBillPlace.BranchCode = dgvBillPlace.CurrentRow.Cells(2).Value.ToString
                    frmMasBillPlace.BillToCustCode = txtCustCode.Text
                    frmMasBillPlace.BillToCustBranch = txtBranch.Text
                    frmMasBillPlace.Editmode = True
                    frmMasBillPlace.ShowDialog()
                    LoadBillTo()

                Else
                    MetroFramework.MetroMessageBox.Show(frmMain, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtGLAccountCode_ButtonClick(sender As Object, e As EventArgs) Handles txtGLAccountCode.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT [AccCode],[AccTName] FROM [Mas_Account] WHERE  [IsActive]=1 and [CMPCode]='" & CMPCode & "' and BranchCode='" & BrCode & "' order by [AccCode] ", MainConnection)
            If isSearchOK Then
                txtGLAccountCode.Text = dr("AccCode").ToString()
                txtGLAccountName.Text = dr("AccTName").ToString()
            End If
            dr = Nothing
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub btnAddBill_Click(sender As Object, e As EventArgs) Handles btnAddBill.Click
        UserAuthorize(UserProfile.U_Code, "BILIF")
        If UserAuthen.IsInsertData = 0 Then
            MetroFramework.MetroMessageBox.Show(frmMain, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If _IsNew Then Exit Sub
        Try
            frmMasBillPlace._IsNew = True
            frmMasBillPlace.Editmode = False
            frmMasBillPlace.BillToCustCode = txtCustCode.Text
            frmMasBillPlace.BillToCustBranch = txtBranch.Text
            frmMasBillPlace.ShowDialog()
            LoadBillTo()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    Private Sub btnDeleteBill_Click(sender As Object, e As EventArgs)
        UserAuthorize(UserProfile.U_Code, "BILIF")
        If UserAuthen.IsDeleteData = 0 Then
            MetroFramework.MetroMessageBox.Show(frmMain, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
    End Sub

    Private Sub btnAddShip_Click(sender As Object, e As EventArgs) Handles btnAddShip.Click
        UserAuthorize(UserProfile.U_Code, "SHPIF")
        If UserAuthen.IsInsertData = 0 Then
            MetroFramework.MetroMessageBox.Show(frmMain, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If _IsNew Then Exit Sub
        Try
            frmMasShipPlace._IsNew = True
            frmMasShipPlace.Editmode = False
            frmMasShipPlace.BillToCustCode = txtCustCode.Text
            frmMasShipPlace.BillToCustBranch = txtBranch.Text
            frmMasShipPlace.ShowDialog()
            LoadShipTo()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub btnDeleteShip_Click(sender As Object, e As EventArgs)
        UserAuthorize(UserProfile.U_Code, "SHPIF")
        If UserAuthen.IsDeleteData = 0 Then
            MetroFramework.MetroMessageBox.Show(frmMain, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
    End Sub

    Private Sub dgvShipPlace_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvShipPlace.CellMouseDoubleClick
        Try
            UserAuthorize(UserProfile.U_Code, "SHPIF")
            If e.RowIndex < 0 Or e.RowIndex > dgvShipPlace.RowCount - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                If UserAuthen.IsEditData = 1 Then
                    frmMasShipPlace.CustCode = dgvShipPlace.CurrentRow.Cells(1).Value.ToString
                    frmMasShipPlace.BranchCode = dgvShipPlace.CurrentRow.Cells(2).Value.ToString
                    frmMasShipPlace.BillToCustCode = txtCustCode.Text
                    frmMasShipPlace.BillToCustBranch = txtBranch.Text
                    frmMasShipPlace.Editmode = True
                    frmMasShipPlace.ShowDialog()
                    LoadBillTo()

                Else
                    MetroFramework.MetroMessageBox.Show(frmMain, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MetroTextBox4_Click(sender As Object, e As EventArgs) Handles txtNotifyName.Click

    End Sub

    Private Sub txtShipToCustCode_ButtonClick_1(sender As Object, e As EventArgs) Handles txtShipToCustCode.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT [CustCode] ,[CustBranch] ,[TaxNumber] ,[CustName] ,[TAddress] FROM [Mas_Customer]
WHERE CustType='SHP' and [Active]=1 and [CMPCode]='" & CMPCode & "' 
and BranchCode='" & BrCode & "' and ShipToCustCode='" & txtCustCode.Text & "' 
and ShipToBranch='" & txtBranch.Text & "' order by [CustCode] ", MainConnection)
            If isSearchOK Then
                txtShipToCustCode.Text = dr("CustCode").ToString()
                txtShipToCustCode.Text = dr("CustBranch").ToString()
                txtShipToName.Text = dr("CustName").ToString()
            End If
            dr = Nothing
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtBillToCustCode_ClearClicked() Handles txtBillToCustCode.ClearClicked
        txtBillToBranch.ResetText()
        txtBillToCustName.ResetText()
    End Sub

    Private Sub txtShipToCustCode_ClearClicked() Handles txtShipToCustCode.ClearClicked
        txtShipToBranch.ResetText()
        txtShipToName.ResetText()
    End Sub

    Private Sub txtNotifyToCustCode_ButtonClick(sender As Object, e As EventArgs) Handles txtNotifyToCustCode.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT [CustCode] ,[CustBranch] ,[TaxNumber] ,[CustName] ,[TAddress] FROM [Mas_Customer]
WHERE CustType='NFP' and [Active]=1 and [CMPCode]='" & CMPCode & "' 
and BranchCode='" & BrCode & "' and NotifyToCustCode='" & txtCustCode.Text & "' 
and NotifyToBranch='" & txtBranch.Text & "' order by [CustCode] ", MainConnection)
            If isSearchOK Then
                txtNotifyToCustCode.Text = dr("CustCode").ToString()
                txtNotifyToBranch.Text = dr("CustBranch").ToString()
                txtNotifyName.Text = dr("CustName").ToString()
            End If
            dr = Nothing
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtNotifyToCustCode_ClearClicked() Handles txtNotifyToCustCode.ClearClicked
        txtNotifyToBranch.ResetText()
        txtNotifyName.ResetText()
    End Sub

    Private Sub cmbVenGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVenGroup.SelectedIndexChanged
        If _IsNew Then CaseRunning()
    End Sub

    Private Sub btnAddNotify_Click(sender As Object, e As EventArgs) Handles btnAddNotify.Click
        UserAuthorize(UserProfile.U_Code, "NFPIF")
        If UserAuthen.IsInsertData = 0 Then
            MetroFramework.MetroMessageBox.Show(frmMain, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If _IsNew Then Exit Sub
        Try
            frmMasNotify._IsNew = True
            frmMasNotify.Editmode = False
            frmMasNotify.BillToCustCode = txtCustCode.Text
            frmMasNotify.BillToCustBranch = txtBranch.Text
            frmMasNotify.ShowDialog()
            LoadNotify()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmMain, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvNotify_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvNotify.CellMouseDoubleClick
        Try
            UserAuthorize(UserProfile.U_Code, "NFPIF")
            If e.RowIndex < 0 Or e.RowIndex > dgvNotify.RowCount - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                If UserAuthen.IsEditData = 1 Then
                    frmMasNotify.CustCode = dgvNotify.CurrentRow.Cells(1).Value.ToString
                    frmMasNotify.BranchCode = dgvNotify.CurrentRow.Cells(2).Value.ToString
                    frmMasNotify.BillToCustCode = txtCustCode.Text
                    frmMasNotify.BillToCustBranch = txtBranch.Text
                    frmMasNotify.Editmode = True
                    frmMasNotify.ShowDialog()
                    LoadNotify()
                Else
                    MetroFramework.MetroMessageBox.Show(frmMain, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtTTAddress_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTTAddress.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCustContact.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtBillCondition_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBillCondition.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustPayContract_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCustPayContract.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtTel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTel.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtFAX_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFAX.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtPurchaseCity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPurchaseCity.KeyPress
        SelectCountryName(txtPurchaseCity.Text, txtPurchaseCityName)
    End Sub

    Private Sub txtPurchaseCity_Leave(sender As Object, e As EventArgs) Handles txtPurchaseCity.Leave
        SelectCountryName(txtPurchaseCity.Text, txtPurchaseCityName)
    End Sub
End Class