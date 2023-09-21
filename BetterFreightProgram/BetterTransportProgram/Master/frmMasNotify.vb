Imports System.Text

Public Class frmMasNotify
    Public _IsNew as Boolean
    Public BillToCustCode as String
    Public BillToCustBranch as String
    Public HIdentity as Integer
    Public CMPCode as String = CMPProfile.PROF_Code
    Public BrCode as String = CMPProfile.PROF_BrCode
    Public CustCode as String
    Public BranchCode as String
    Public EName as String
    Public Editmode as Boolean
    Private CustType as String = "NFP"

    Private Sub frmMasBillPlace_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        txtCustCode.Text = CustCode
        txtBranch.Text = BranchCode
        If String.IsNullOrEmpty(CustCode) = False Then
            LoadData()

            If Editmode Then
                cmdNew.Enabled = False
                togactive.Enabled = False
                'cmdSearch.Visible = False
                'MetroButton6.Visible = False

                cmdCopy.Visible = False
                MetroButton8.Visible = False

                cmdNew.Visible = False
                MetroButton4.Visible = False
                _IsNew = False
            Else
                cmdNew.Enabled = True
                togactive.Enabled = True
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
            addNewData()
            cmdNew.Enabled = True
            togactive.Enabled = True
            'cmdSearch.Visible = True
            'MetroButton6.Visible = True

            cmdCopy.Visible = True
            MetroButton8.Visible = True

            cmdNew.Visible = True
            MetroButton4.Visible = True
            _IsNew = True
        End If
    End Sub
    Private Sub cmdNew_Click(sender as Object, e as Eventargs) Handles cmdNew.Click
        addNewData()
    End Sub
    Private Sub LoadData()
        Try
            Dim str as String = "SELECT * FROM [V_MasCustomer] " &
           " where  BranchCode='" & BrCode & "' and CMPCode='" & CMPCode &
           "' and CustCode='" & txtCustCode.Text &
           "' and CustBranch='" & txtBranch.Text & "' and CustType='" & CustType & "'"

            Dim dr as DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                HIdentity = dr("TBIDNT").ToString
                txtTaxNumber.Text = dr("TaxNumber").ToString
                txtCustCode.Text = dr("CustCode").ToString
                txtBranch.Text = dr("CustBranch").ToString
                txtNameEng.Text = dr("CustName").ToString
                txtTaddress.Text = dr("Taddress").ToString
                txtTTaddress.Text = dr("TTaddress").ToString
                txtCustCity.Text = dr("Custcity").ToString
                txtPurchaseCity.Text = dr("PurchaseCity").ToString
                txtPurchaseCityName.Text = dr("CountryName").ToString
                txtCustEmail.Text = dr("CustEmail").ToString
                txtCustPhone.Text = dr("CustPhone").ToString
                txtCustFax.Text = dr("CustFax").ToString
                'txtGLaccountCode.Text = dr("GLaccountCode").ToString
                ' txtGLaccountName.Text = dr("accTName").ToString
                togactive.Checked = CInt(dr("active").ToString)

                _IsNew = False
                txtCustCode.ReadOnly = True

            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub addNewData()
        Userauthorize(UserProfile.U_Code, "NFPIF")
        If Userauthen.IsInsertData = 1 Then
            ResetallText()
            ResetStyle()
            _IsNew = True
            txtCustCode.ReadOnly = False
            txtBranch.ReadOnly = False
            GetRunningFormat("NFPIF")
            txtCustCode.Text = RunningForm.Run_Formatt
            txtCustCode.Focus()
        Else
            MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
    Private Sub ResetallText()
        txtTaxNumber.ResetText()
        txtCustCode.ResetText()
        txtBranch.Text = "000000"
        txtNameEng.ResetText()
        txtTaddress.ResetText()
        txtTTaddress.ResetText()
        txtCustCity.ResetText()
        txtPurchaseCity.ResetText()
        txtPurchaseCityName.ResetText()
        txtCustEmail.ResetText()
        txtCustPhone.ResetText()
        txtCustFax.ResetText()
        txtGLaccountCode.ResetText()
        txtGLaccountName.ResetText()
        togactive.Checked = True


    End Sub
    Private Sub ResetStyle()
        txtTaxNumber.Style = MetroFramework.MetroColorStyle.Default
        txtCustCode.Style = MetroFramework.MetroColorStyle.Default
        txtBranch.Style = MetroFramework.MetroColorStyle.Default
        txtNameEng.Style = MetroFramework.MetroColorStyle.Default
        txtTaddress.Style = MetroFramework.MetroColorStyle.Default
        txtCustCity.Style = MetroFramework.MetroColorStyle.Default
        txtPurchaseCity.Style = MetroFramework.MetroColorStyle.Default
        txtPurchaseCityName.Style = MetroFramework.MetroColorStyle.Default
        txtCustEmail.Style = MetroFramework.MetroColorStyle.Default
        txtCustPhone.Style = MetroFramework.MetroColorStyle.Default
        txtCustFax.Style = MetroFramework.MetroColorStyle.Default
        txtGLaccountCode.Style = MetroFramework.MetroColorStyle.Default
        txtGLaccountName.Style = MetroFramework.MetroColorStyle.Default
    End Sub

    Private Sub cmdSave_Click(sender as Object, e as Eventargs) Handles cmdSave.Click

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

        Userauthorize(UserProfile.U_Code, "NFPIF")
        If _IsNew Then
            If Userauthen.IsInsertData = 1 Then
                If txtCustCode.Text = "" Or txtCustCode.Text = RunningForm.Run_Formatt Then
                    txtCustCode.Text = CreateNumber("Mas_Customer", "CustCode", True)
                Else
                    If CheckCustCode(txtCustCode.Text, txtBranch.Text, "NFP", BillToCustCode, BillToCustBranch) Then
                        MetroFramework.MetroMessageBox.Show(Main, "Notify Code " & txtCustCode.Text & " Branch " & txtBranch.Text & " already Existing In Database!", "Check Existing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If
                SaveBillTo(1)
            Else
                MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        Else
            If Userauthen.IsEditData = 1 Then
                SaveBillTo(0)
            Else
                MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If

    End Sub
    Private Sub SaveBillTo(_Insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec [sp_lnsertOrupdateMas_CustomerRelate] ")
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
            'SQLcommand.append(",''") '@CustContact
            SQLcommand.append(",'" & txtCustEmail.Text & "'") '@CustEmail
            SQLcommand.append(",'" & txtCustPhone.Text & "'") '@CustPhone
            SQLcommand.append(",'" & txtCustFax.Text & "'") '@CustFax
            ' SQLcommand.append(",'" & txtGLaccountCode.Text & "'") '@GL
            SQLcommand.append(",''") 'BillToCustcode
            SQLcommand.append(",''") ' BillToBranchcode
            SQLcommand.append(",''") 'ShipToCustcode
            SQLcommand.append(",''") ' ShipToBranchcode
            SQLcommand.append(",'" & BillToCustCode & "'") '@NotifyToCustCode
            SQLcommand.append(",'" & BillToCustBranch & "'") ' @NotifyToBranch
            ' SQLcommand.append(",'0'") '@TermOfPayment
            ' SQLcommand.append(",''") '@accountRemark
            SQLcommand.append(",'" & CustType & "'") '@CustType
            SQLcommand.append(",'" & togactive.CheckState & "'") '@active
            SQLcommand.append(",'" & _Insert & "'") '@lnsertorupdate
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtCustCode_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtCustCode.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtBranch_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtBranch.KeyPress
        'CheckQuote(e)
        CheckNumeric(e)
    End Sub

    Private Sub txtTaxNumber_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtTaxNumber.KeyPress
        'CheckQuote(e)
        CheckNumeric(e)
    End Sub

    Private Sub txtNameEng_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtNameEng.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtTaddress_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtTaddress.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustCity_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtCustCity.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustEmail_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtCustEmail.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustFax_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtCustFax.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtGLaccountCode_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtGLaccountCode.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub cmdSearch_Click(sender as Object, e as Eventargs)

    End Sub

    Private Sub txtPurchaseCity_ButtonClick(sender as Object, e as Eventargs) Handles txtPurchaseCity.ButtonClick
        SelectCountry(txtPurchaseCity, txtPurchaseCityName)
    End Sub

    Private Sub cmdCopy_Click(sender as Object, e as Eventargs) Handles cmdCopy.Click
        If HIdentity > 0 and _IsNew = False Then
            _IsNew = True
            cmdCopy.BackColor = Color.Transparent
        Else
            Dim dr as DataRow
            dr = PopUpSearch("SELECT [CustCode] ,[CustBranch] ,[TaxNumber],BillToCustCode,BillToBranch,CustType ,[CustName] ,Taddress FROM [Mas_Customer] WHERE  [CMPCode]='" & CMPCode & "' and BranchCode='" & BrCode & "' order by [CustCode] ", MainConnection)
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
            Dim str as String = "SELECT * FROM [V_MasCustomer] where  BranchCode='" &
                BrCode & "' and CMPCode='" &
                CMPCode & "' and CustCode='" &
                txtCustCode.Text & "' and CustBranch='" &
                txtBranch.Text & "'"
            Dim dr as DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                HIdentity = dr("TBIDNT").ToString
                txtTaxNumber.Text = dr("TaxNumber").ToString
                txtCustCode.Text = dr("CustCode").ToString
                txtBranch.Text = dr("CustBranch").ToString
                txtNameEng.Text = dr("CustName").ToString
                txtTaddress.Text = dr("Taddress").ToString
                txtTTaddress.Text = dr("TTaddress").ToString
                txtCustCity.Text = dr("Custcity").ToString
                txtPurchaseCity.Text = dr("PurchaseCity").ToString
                txtPurchaseCityName.Text = dr("CountryName").ToString
                txtCustEmail.Text = dr("CustEmail").ToString
                txtCustPhone.Text = dr("CustPhone").ToString
                txtCustFax.Text = dr("CustFax").ToString
                txtGLaccountCode.Text = dr("GLaccountCode").ToString
                ' txtGLaccountName.Text = dr("accTName").ToString
                togactive.Checked = CInt(dr("active").ToString)
                txtCustCode.ReadOnly = False
                txtBranch.ReadOnly = False
                GetRunningFormat("NFPIF")
                txtCustCode.Text = RunningForm.Run_Formatt
            Else
                addNewData()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtGLaccountCode_ButtonClick(sender as Object, e as Eventargs) Handles txtGLaccountCode.ButtonClick
        Try
            Dim dr as DataRow
            dr = PopUpSearch("SELECT [accCode],[accTName] FROM [Mas_account] WHERE  [Isactive]=1 and [CMPCode]='" & CMPCode & "' and BranchCode='" & BrCode & "' order by [accCode] ", MainConnection)
            If isSearchOK Then
                txtGLaccountCode.Text = dr("accCode").ToString()
                txtGLaccountName.Text = dr("accTName").ToString()
            End If
            dr = Nothing
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtTTaddress_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtTTaddress.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtCustPhone_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtCustPhone.KeyPress
        CheckQuote(e)
    End Sub
End Class