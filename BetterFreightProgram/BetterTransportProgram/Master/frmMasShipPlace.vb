Imports System.Text

Public Class frmMasShipPlace
    Public _IsNew As Boolean
    Public BillToCustCode As String
    Public BillToCustBranch As String
    Public HIdentity As Integer
    Public CMPCode As String = CMPProfile.PROF_Code
    Public BrCode As String = CMPProfile.PROF_BrCode
    Public CustCode As String
    Public BranchCode As String
    Public EName As String
    Public Editmode As Boolean

    Private Sub frmMasBillPlace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCustCode.Text = CustCode
        txtBranch.Text = BranchCode
        If String.IsNullOrEmpty(CustCode) = False Then
            LoadData()

            If Editmode Then
                cmdNew.Enabled = False
                togActive.Enabled = False
                'cmdSearch.Visible = False
                'MetroButton6.Visible = False

                cmdCopy.Visible = False
                MetroButton8.Visible = False

                cmdNew.Visible = False
                MetroButton4.Visible = False
                _IsNew = False
            Else
                cmdNew.Enabled = True
                togActive.Enabled = True
                'cmdSearch.Visible = True
                'MetroButton6.Visible = True

                cmdCopy.Visible = True
                MetroButton8.Visible = True

                cmdNew.Visible = True
                MetroButton4.Visible = True
                _IsNew = True
            End If

        End If
        If _IsNew Then
            AddNewData()
            cmdNew.Enabled = True
            togActive.Enabled = True
            'cmdSearch.Visible = True
            'MetroButton6.Visible = True

            cmdCopy.Visible = True
            MetroButton8.Visible = True

            cmdNew.Visible = True
            MetroButton4.Visible = True
            _IsNew = True
        End If
    End Sub
    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        AddNewData()
    End Sub
    Private Sub LoadData()
        Try
            Dim str As String = "SELECT * FROM [V_MasCustomer] " &
           " where  BranchCode='" & BrCode & "' and CMPCode='" & CMPCode &
           "' and CustCode='" & txtCustCode.Text &
           "' and CustBranch='" & txtBranch.Text & "' and CustType='SHP'"

            Dim dr As DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                HIdentity = dr("TBIDNT").ToString
                txtTaxNumber.Text = dr("TaxNumber").ToString
                txtCustCode.Text = dr("CustCode").ToString
                txtBranch.Text = dr("CustBranch").ToString
                txtNameEng.Text = dr("CustName").ToString
                txtTAddress.Text = dr("TAddress").ToString
                txtTTAddress.Text = dr("TTAddress").ToString
                txtCustCity.Text = dr("Custcity").ToString
                txtPurchaseCity.Text = dr("PurchaseCity").ToString
                txtPurchaseCityName.Text = dr("CountryName").ToString
                txtCustEmail.Text = dr("CustEmail").ToString
                txtCustPhone.Text = dr("CustPhone").ToString
                txtCustFax.Text = dr("CustFax").ToString
                txtGLAccountCode.Text = dr("GLAccountCode").ToString
                'txtGLAccountName.Text = dr("AccTName").ToString
                togActive.Checked = CInt(dr("Active").ToString)
                togIsPerson.Checked = CInt(dr("IsPerson").ToString)
                _IsNew = False
                txtCustCode.ReadOnly = True

            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub AddNewData()
        Userauthorize(UserProfile.U_Code, "SHPIF")
        If Userauthen.IsInsertData = 1 Then
            ResetAllText()
            ResetStyle()
            _IsNew = True
            txtCustCode.ReadOnly = False
            txtBranch.ReadOnly = False
            GetRunningFormat("SHPIF")
            txtCustCode.Text = RunningForm.Run_Formatt
            txtCustCode.Focus()
        Else
            MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
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
        txtCustEmail.ResetText()
        txtCustPhone.ResetText()
        txtCustFax.ResetText()
        txtGLAccountCode.ResetText()
        txtGLAccountName.ResetText()
        togActive.Checked = True


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
        txtGLAccountCode.Style = MetroFramework.MetroColorStyle.Default
        txtGLAccountName.Style = MetroFramework.MetroColorStyle.Default
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

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
        Userauthorize(UserProfile.U_Code, "SHPIF")
        If _IsNew Then
            If Userauthen.IsInsertData = 1 Then
                If txtCustCode.Text = "" Or txtCustCode.Text = RunningForm.Run_Formatt Then
                    txtCustCode.Text = CreateNumber("Mas_Customer", "CustCode", True)
                Else
                    If CheckCustCode(txtCustCode.Text, txtBranch.Text, "SHP", BillToCustCode, BillToCustBranch) Then
                        MetroFramework.MetroMessageBox.Show(Me, "Shipplace Code " & txtCustCode.Text & " Branch " & txtBranch.Text & " Already Existing In Database!", "Check Existing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If
                SaveBillTo(1)
                ' SaveBillTo(1)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        Else
            If Userauthen.IsEditData = 1 Then
                SaveBillTo(0)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "User Not Authorized this menu!", "Authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If

    End Sub
    Private Sub SaveBillTo(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec [sp_lnsertOrupdateMas_CustomerRelate] ")
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
            ' SQLcommand.Append(",''") '@CustContact
            SQLcommand.Append(",'" & txtCustEmail.Text & "'") '@CustEmail
            SQLcommand.Append(",'" & txtCustPhone.Text & "'") '@CustPhone
            SQLcommand.Append(",'" & txtCustFax.Text & "'") '@CustFax
            ' SQLcommand.Append(",'" & txtGLAccountCode.Text & "'") '@GL
            SQLcommand.Append(",''") 'BillToCustcode 
            SQLcommand.Append(",''") 'BillToBranchcode 
            SQLcommand.Append(",'" & BillToCustCode & "'") 'ShipToCustcode
            SQLcommand.Append(",'" & BillToCustBranch & "'") ' ShipToBranchcode
            SQLcommand.Append(",''") '@NotifyToCustCode
            SQLcommand.Append(",''") ' @NotifyToBranch
            ' SQLcommand.Append(",'0'") '@TermOfPayment
            ' SQLcommand.Append(",''") '@AccountRemark
            SQLcommand.Append(",'SHP'") '@CustType
            SQLcommand.Append(",'" & togActive.CheckState & "'") '@Active
            SQLcommand.Append(",'" & togIsPerson.CheckState & "'") '@Person
            SQLcommand.Append(",'" & _Insert & "'") '@lnsertorupdate
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

    Private Sub txtCustCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCustCode.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtBranch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBranch.KeyPress
        'CheckQuote(e)
        CheckNumeric(e)
    End Sub

    Private Sub txtTaxNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTaxNumber.KeyPress
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

    Private Sub txtCustFax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCustFax.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtGLAccountCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGLAccountCode.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtPurchaseCity_ButtonClick(sender As Object, e As EventArgs) Handles txtPurchaseCity.ButtonClick
        SelectCountry(txtPurchaseCity, txtPurchaseCityName)
    End Sub

    Private Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click
        If HIdentity > 0 And _IsNew = False Then
            _IsNew = True
            cmdCopy.BackColor = Color.Transparent
        Else
            Dim dr As DataRow
            dr = PopUpSearch("SELECT [CustCode] ,[CustBranch] ,[TaxNumber],BillToCustCode,BillToBranch,CustType ,[CustName] ,TAddress FROM [Mas_Customer] WHERE  [CMPCode]='" & CMPCode & "' and BranchCode='" & BrCode & "' order by [CustCode] ", MainConnection)
            If (isSearchOK = True) Then
                txtCustCode.Text = dr("CustCode").ToString()
                txtBranch.Text = dr("CustBranch").ToString()
                LoadCopy()
                _IsNew = True
            End If
            dr = Nothing
        End If
    End Sub
    Private Sub LoadCopy()
        Try
            Dim str As String = "SELECT * FROM [V_MasCustomer] where  BranchCode='" &
                BrCode & "' and CMPCode='" &
                CMPCode & "' and CustCode='" &
                txtCustCode.Text & "' and CustBranch='" &
                txtBranch.Text & "'"
            Dim dr As DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                HIdentity = dr("TBIDNT").ToString
                txtTaxNumber.Text = dr("TaxNumber").ToString
                txtCustCode.Text = dr("CustCode").ToString
                txtBranch.Text = dr("CustBranch").ToString
                txtNameEng.Text = dr("CustName").ToString
                txtTAddress.Text = dr("TAddress").ToString
                txtTTAddress.Text = dr("TTAddress").ToString
                txtCustCity.Text = dr("Custcity").ToString
                txtPurchaseCity.Text = dr("PurchaseCity").ToString
                txtPurchaseCityName.Text = dr("CountryName").ToString
                txtCustEmail.Text = dr("CustEmail").ToString
                txtCustPhone.Text = dr("CustPhone").ToString
                txtCustFax.Text = dr("CustFax").ToString
                txtGLAccountCode.Text = dr("GLAccountCode").ToString
                ' txtGLAccountName.Text = dr("AccTName").ToString
                togActive.Checked = CInt(dr("Active").ToString)
                txtCustCode.ReadOnly = False
                txtBranch.ReadOnly = False
                GetRunningFormat("SHPIF")
                txtCustCode.Text = RunningForm.Run_Formatt
            Else
                AddNewData()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtTTAddress_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTTAddress.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCustPhone.KeyPress
        CheckQuote(e)
    End Sub
End Class