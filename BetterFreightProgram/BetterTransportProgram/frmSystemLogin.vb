Public Class frmSystemLogin
    Public StandBy As Boolean = False

    Private ScmdUserBranch As String = "SELECT [TBIDNT],[BranchCode] + ' - ' + [BranchEName] as Branch FROM [V_SysBranch]"
    Private Sub frmSystemLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ComboBoxList(cboUserBranch, ScmdUserBranch, MainConnection)
            ' LoadCbo(cboUserBranch, ScmdUserBranch)
            cboUserBranch.SelectedIndex = 0
            txtU_Code.Focus()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub btnSetLogin_Click(sender As Object, e As EventArgs) Handles btnSetLogin.Click
        If txtU_Code.Text = "" Then
            txtU_Code.Focus()
            txtU_Code.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtU_Code.Style = MetroFramework.MetroColorStyle.Blue
        End If
        If txtU_EntryCode.Text = "" Then
            txtU_EntryCode.Focus()
            txtU_EntryCode.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtU_EntryCode.Style = MetroFramework.MetroColorStyle.Blue
        End If
        LoginUser()
    End Sub
    Private Sub LoginUser(Optional ByRef Islogin As Boolean = False)
        Try
            LoadSysBranch(CInt(cboUserBranch.SelectedValue.ToString))
            Dim userinfo As UserData = GetDataUser(txtU_Code.Text, SBranch.CMPCode, SBranch.BranchCode)
            If userinfo.U_Code <> "" And userinfo.U_Code <> Nothing Then
                If (txtU_EntryCode.Text = userinfo.U_EntryCode) Then
                    UserProfile = userinfo
                    IsLogingIn = True
                    StandBy = False
                    'SaveLogInLog()
                    txtU_EntryCode.ResetText()
                    txtU_Code.ReadOnly = False
                    Me.Close()
                Else
                    txtU_EntryCode.Focus()
                    txtU_EntryCode.Style = MetroFramework.MetroColorStyle.Red
                End If
            Else
                txtU_Code.Focus()
                txtU_Code.Style = MetroFramework.MetroColorStyle.Red
                IsLogingIn = False
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub
    Private Sub SaveLogInLog()
        Dim rs As New ClsRecordset
        Dim Tim As Integer
        rs.Connection = MainConnection
        rs.Recordsource = "select U_LoginTime from Sys_UserSystem where UCode='" & UserProfile.U_Code & "'"
        If rs.RecordCount > 0 Then
            Tim = rs.DataSource.Rows(0)(0) + 1
            rs.RunSQLCommand("Update Sys_UserSystem set U_LoginTime='" & Tim & "',U_LoinLastDate=" & SQLDate(DateTime.Now) & " where U_Code='" & UserProfile.U_Code & "' ")
        End If
        If rs.HasError Then
            MsgBox(rs.ErrorMessage)
        End If
    End Sub
    Private Sub ChkLogOut(ByVal IsLogOut As Boolean)
        If IsLogOut Then
            Exit Sub
        Else
            If IsLogingIn Then
                Exit Sub
            Else
                End
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ChkLogOut(StandBy)
    End Sub

    Private Sub txtU_Code_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtU_Code.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            LoginUser()
            e.Handled = True
        End If
    End Sub

    Private Sub txtU_EntryCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtU_EntryCode.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            LoginUser()
            e.Handled = True
        End If
    End Sub

    Private Sub cboUserBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUserBranch.SelectedIndexChanged
        ''MsgBox("Item : " & cboUserBranch.SelectedItem.ToString)
        ''MsgBox("Value : " & cboUserBranch.SelectedValue.ToString)
        ''MsgBox("Index : " & cboUserBranch.SelectedIndex.ToString)
        ''If CInt(cboUserBranch.SelectedItem) > 0 Then
        '' LoadSysBranch(cboUserBranch.SelectedValue)
        ''End If
        'LoginUser()
        Try
            LoadSysBranch(CInt(cboUserBranch.SelectedValue.ToString))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboUserBranch_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboUserBranch.SelectionChangeCommitted
        'LoadSysBranch(CInt(cboUserBranch.SelectedValue))
    End Sub
End Class