Imports System.Text

Public Class frmMasUser
    Public Property UIdentity as Integer
    Public Property UMaIdentity as Integer
    Public Property Hname as String
    Public Property UserCodeCoppy as String

    Public CMPCode as String = CMPProfile.PROF_Code
    Public BrCode as String = CMPProfile.PROF_BrCode
    Public _IsNew as Boolean
    Public IsNewauthen as Boolean

    Private imgUserDialog as OpenFileDialog
    Private strPath as String = "" ' //'ที่อยู่ของภาพที่เลือกมาจาก dialog
    Private Sub frmMasUser_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        Userauthorize(UserProfile.U_Code, "USRIF")
        If Userauthen.IsOpenMenu = 1 Then
            addDataNew()
        Else
            MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

    End Sub

    Private Sub cmdSearch_Click(sender as Object, e as Eventargs) Handles cmdSearch.Click
        Try
            Dim dr as DataRow
            dr = PopUpSearch("SELECT [UCode] ,[UBrCode] ,[UCMPCode] ,[UFName] ,[ULName] ,[UPosition]  ,[active] FROM [Sys_UserSystem] where UCMPCode='" & CMPCode & "' and UPosition<>'ZEW'", MainConnection)
            If isSearchOK Then
                txtU_Code.Text = dr("UCode").ToString
                LoadData()
            End If
            dr = Nothing
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub cmdNew_Click(sender as Object, e as Eventargs) Handles cmdNew.Click
        addDataNew()
    End Sub

    Private Sub cmdSave_Click(sender as Object, e as Eventargs) Handles cmdSave.Click
        Userauthorize(UserProfile.U_Code, "USRIF")
        'If txtU_Code.Text = "" Then
        '    txtU_Code.Focus()
        '    txtU_Code.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtU_Code.Style = MetroFramework.MetroColorStyle.Default
        'End If
        'If txtU_EntryCode.Text = "" Then
        '    txtU_EntryCode.Focus()
        '    txtU_EntryCode.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtU_EntryCode.Style = MetroFramework.MetroColorStyle.Default
        'End If
        If txtConfirmPassword.Visible = True Then
            If txtConfirmPassword.Text <> txtU_EntryCode.Text Then
                MetroFramework.MetroMessageBox.Show(Main, "ConfirmPassword again", "ConfirmPassword", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtConfirmPassword.Focus()
                Exit Sub
            End If
        End If
        'If txtU_BrCode.Text = "" Then
        '    txtU_BrCode.Focus()
        '    txtU_BrCode.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtU_BrCode.Style = MetroFramework.MetroColorStyle.Default
        'End If
        'If txtU_FName.Text = "" Then
        '    txtU_FName.Focus()
        '    txtU_FName.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtU_FName.Style = MetroFramework.MetroColorStyle.Default
        'End If
        'If txtU_LName.Text = "" Then
        '    txtU_LName.Focus()
        '    txtU_LName.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtU_LName.Style = MetroFramework.MetroColorStyle.Default
        'End If
        'If txtU_Position.Text = "" Then
        '    txtU_Position.Focus()
        '    txtU_Position.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtU_Position.Style = MetroFramework.MetroColorStyle.Default
        'End If
        'If txtU_WorkLine.Text = "" Then
        '    txtU_WorkLine.Focus()
        '    txtU_WorkLine.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtU_WorkLine.Style = MetroFramework.MetroColorStyle.Default
        'End If
        If _IsNew Then
            If Userauthen.IsInsertData = 1 Then
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
    Private Sub SaveData(ByVal _Insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateSys_UserSystem ")
            SQLcommand.append("'" & UIdentity & "'") 'UIdentity
            SQLcommand.append(",'" & txtU_Code.Text & "'") 'U_Code
            SQLcommand.append(",'" & txtU_EntryCode.Text & "'") 'U_EntryCode
            SQLcommand.append(",'" & txtU_BrCode.Text & "'") 'U_BrCode
            SQLcommand.append(",'" & CMPProfile.PROF_Code & "'") 'U_CMPCode
            SQLcommand.append(",'" & txtU_FName.Text & "'") 'U_FName
            SQLcommand.append(",'" & txtU_LName.Text & "'") 'U_LName
            SQLcommand.append(",'" & txtU_Position.Text & "'") 'U_Position
            SQLcommand.append(",'" & txtU_WorkLine.Text & "'") 'U_WorkLine
            SQLcommand.append(",'" & txtU_Phoneno.Text & "'") 'U_Phoneno
            SQLcommand.append(",'" & txtU_ImgPath.Text & "'") 'U_ImgPath
            SQLcommand.append(",'" & togU_ISCanEditUser.CheckState & "'") 'U_ISCanEditUser
            SQLcommand.append(",'" & togU_ISShowCost.CheckState & "'") 'U_ISShowCost
            SQLcommand.append(",'" & togUISShowSpCost.CheckState & "'") 'U_ISShowSpecialCost
            SQLcommand.append(",'" & togU_ISShowPrice.CheckState & "'") 'U_ISShowPrice
            SQLcommand.append(",'" & togUISOpenOper.CheckState & "'") 'UISOpenOper
            SQLcommand.append(",'" & togUISOpenRPT.CheckState & "'") 'UISOpenRPT
            SQLcommand.append(",'" & togUISOpenMaS.CheckState & "'") 'UISOpenMaS
            SQLcommand.append(",'" & togUISOpenSYS.CheckState & "'") 'UISOpenSYS
            SQLcommand.append(",'" & togU_Status.CheckState & "'") 'U_Status
            SQLcommand.append(",'" & _Insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub Saveauthorize(ByVal _Insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateSys_UserMenuauth ")
            SQLcommand.append("'" & CMPCode & "'") '; //CMPCode 
            SQLcommand.append(",'" & BrCode & "'") '; //BranchCode 
            SQLcommand.append(",'" & txtU_Code.Text & "'") '; //UserID 
            SQLcommand.append(",'" & txtappID.Text & "'") '; //appID 
            SQLcommand.append(",'" & txtMenuID.Text & "'") '; //MenuID 
            SQLcommand.append(",'" & CInt(togIsOpenMenu.CheckState) & "'") '; //IsOpenMenu 
            SQLcommand.append(",'" & CInt(togIsInsertData.CheckState) & "'") '; //IsInsertData 
            SQLcommand.append(",'" & CInt(togIsEditData.CheckState) & "'") '; //IsEditData 
            SQLcommand.append(",'" & CInt(togIsDeleteData.CheckState) & "'") '; //IsDeleteData 
            SQLcommand.append(",'" & CInt(togIsPrintData.CheckState) & "'") '; //IsPrintData 
            SQLcommand.append(",'" & CInt(togIsCheckData.CheckState) & "'") '; //IsCheckData 
            SQLcommand.append(",'" & CInt(togIsapprove.CheckState) & "'") '; //Isapprove 
            SQLcommand.append(",'" & CInt(togIsReapprove.CheckState) & "'") '; //IsReapprove 
            SQLcommand.append(",'" & CInt(togIsCancel.CheckState) & "'") '; //IsCancel 
            SQLcommand.append(",'" & CInt(togIsRecancel.CheckState) & "'") '; //IsRecancel 
            SQLcommand.append(",'" & Userauthen.UMaIdentity & "'") '; //UMaIdentity 
            SQLcommand.append(",'" & _Insert & "'") '; //Insert Or Update"
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub addDataNew()
        Userauthorize(UserProfile.U_Code, "USRIF")
        If Userauthen.IsInsertData = 1 Then
            ResetallText()
            ResetStyle()
            _IsNew = True
            IsNewauthen = True
            txtU_Code.ReadOnly = False
            txtU_Code.Focus()
        Else
            MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'Me.Close()
        End If
    End Sub
    Private Sub ResetallText()
        'Reset Code 
        UIdentity = 0
        txtU_Code.ResetText()
        txtU_EntryCode.ResetText()
        txtU_BrCode.ResetText()
        txtU_FName.ResetText()
        txtU_LName.ResetText()
        txtU_Position.ResetText()
        txtU_WorkLine.ResetText()
        txtU_Phoneno.ResetText()
        txtU_ImgPath.ResetText()
        togU_ISCanEditUser.Checked = False
        togU_ISShowCost.Checked = False
        togU_ISShowPrice.Checked = False
        togUISOpenOper.Checked = False 'UISOpenOper
        togUISOpenRPT.Checked = False 'UISOpenRPT
        togUISOpenMaS.Checked = False 'UISOpenMaS
        togUISOpenSYS.Checked = False 'UISOpenSYS
        togU_Status.Checked = False
        UserImage.ImageLocation = Nothing
        dgvMenuList.Rows.Clear()

    End Sub
    Private Sub ResetStyle()
        txtU_Code.Style = MetroFramework.MetroColorStyle.Default
        txtU_EntryCode.Style = MetroFramework.MetroColorStyle.Default
        txtU_BrCode.Style = MetroFramework.MetroColorStyle.Default
        txtU_FName.Style = MetroFramework.MetroColorStyle.Default
        txtU_LName.Style = MetroFramework.MetroColorStyle.Default
        txtU_Position.Style = MetroFramework.MetroColorStyle.Default
        txtU_WorkLine.Style = MetroFramework.MetroColorStyle.Default
        txtU_Phoneno.Style = MetroFramework.MetroColorStyle.Default
        txtU_ImgPath.Style = MetroFramework.MetroColorStyle.Default
    End Sub
    Private Sub LoadData()
        Try
            Dim str as String = "Select *  FROM [V_Sys_UserSystem] where UCode='" & txtU_Code.Text & "' and UCMPCode='" & CMPCode & "'" ' and U_BrCode='" & BrCode & "'"
            Dim dr as DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                UIdentity = CInt(dr("TBIDNT").ToString)    'UIdentity
                txtU_Code.Text = dr("UCode").ToString  'U_Code
                txtU_EntryCode.Text = dr("UEntryCode").ToString   'U_EntryCode
                txtU_BrCode.Text = dr("UBrCode").ToString  'U_BrCode
                txtU_BrName.Text = dr("BranchName").ToString
                txtU_FName.Text = dr("UFName").ToString   'U_FName
                txtU_LName.Text = dr("ULName").ToString   'U_LName
                txtU_Position.Text = dr("UPosition").ToString   'U_Position
                txtU_PositionName.Text = dr("PositionName").ToString
                txtU_WorkLine.Text = dr("UDepartment").ToString   'U_WorkLine
                txtU_WorkLineName.Text = dr("DepartmentName").ToString
                txtU_Phoneno.Text = dr("UPhoneno").ToString   'U_Phoneno
                txtU_ImgPath.Text = dr("UImgPath").ToString  'U_ImgPath
                UserImage.ImageLocation = txtU_ImgPath.Text
                togU_ISCanEditUser.Checked = CInt(dr("UISCanEditUser").ToString)   'U_ISCanEditUser
                togU_ISShowCost.Checked = CInt(dr("UISShowCost").ToString)  'U_ISShowCost
                togUISShowSpCost.Checked = CInt(dr("UISShowSpCost").ToString)  'U_ISShowCost
                togU_ISShowPrice.Checked = CInt(dr("UISShowPrice").ToString) 'U_ISShowPrice
                togUISOpenOper.Checked = CInt(dr("UISOpenOper").ToString) 'UISOpenOper
                togUISOpenRPT.Checked = CInt(dr("UISOpenRPT").ToString) 'UISOpenRPT
                togUISOpenMaS.Checked = CInt(dr("UISOpenMaS").ToString) 'UISOpenMaS
                togUISOpenSYS.Checked = CInt(dr("UISOpenSYS").ToString) 'UISOpenSYS
                togU_Status.Checked = CInt(dr("active").ToString)  'U_Status
                ' UserImage.ImageLocation = ProjectPath & "\OKPPic.jpg" 'txtU_ImgPath.Text
                txtU_Code.ReadOnly = True
                _IsNew = False
            End If
            dr = Nothing
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub LoadMenu()
        Try
            dgvMenuList.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter
            Dim dt as New DataTable
            Dim str as String = "SELECT [MEITEMNO] ,[NameTH] ,[NameEN] ,[appID] ,[MenuGroup]  , [TBIDNT] ,[active] FROM [Sys_Menu] where  [MenuGroup]='" & Hname & "' and [active]=1"
            If String.IsNullOrEmpty(Hname) Then Exit Sub
            da.SelectCommand = New OleDb.OleDbCommand(str, MainConnection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvMenuList.Rows.add(
                      dt.Rows(i)(0).ToString(), 'MEITEMNO MEIdent
                     dt.Rows(i)(1).ToString(), 'NameTH CMPCode
                     dt.Rows(i)(2).ToString(), 'NameEN BranchCode
                     dt.Rows(i)(3).ToString(), 'appID
                     dt.Rows(i)(4).ToString(), '[MenuGroup]
                     dt.Rows(i)(5).ToString(), 'TBIDNT
                     dt.Rows(i)(6).ToString() 'active
                        )
                Next

            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub cmdClose_Click(sender as Object, e as Eventargs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub txtU_BrCode_ButtonClick(sender as Object, e as Eventargs) Handles txtU_BrCode.ButtonClick
        Try
            Dim dr as DataRow
            dr = PopUpSearch("SELECT [BranchCode] ,[BranchName] ,[BranchEName] FROM [V_SysBranch] where CMPCode='" & CMPCode & "' ", MainConnection)
            If isSearchOK Then
                txtU_BrCode.Text = dr("BranchCode").ToString
                txtU_BrName.Text = dr("BranchName").ToString
            End If
            dr = Nothing
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub txtU_BrCode_ClearClicked() Handles txtU_BrCode.ClearClicked
        txtU_BrName.ResetText()
    End Sub

    Private Sub txtU_BrCode_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtU_BrCode.KeyPress
        txtU_BrCode_ButtonClick(sender, e)
        e.Handled = True
    End Sub

    Private Sub txtU_Position_ButtonClick(sender as Object, e as Eventargs) Handles txtU_Position.ButtonClick
        Try
            Dim dr as DataRow
            dr = PopUpSearch("SELECT [PositionCode] ,[PositionName] ,[PositionRemark] FROM [V_MasUserPosition] where 1=1 ", MainConnection)
            If isSearchOK Then
                txtU_Position.Text = dr("PositionCode").ToString
                txtU_PositionName.Text = dr("PositionName").ToString
            End If
            dr = Nothing
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub txtU_Position_ClearClicked() Handles txtU_Position.ClearClicked
        txtU_PositionName.ResetText()
    End Sub

    Private Sub txtU_Position_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtU_Position.KeyPress
        txtU_Position_ButtonClick(sender, e)
        e.Handled = True
    End Sub

    Private Sub txtU_WorkLine_ButtonClick(sender as Object, e as Eventargs) Handles txtU_WorkLine.ButtonClick
        Try
            Dim dr as DataRow
            dr = PopUpSearch("SELECT [DepartmentCode],[DepartmentName],[DepartmentRemark] FROM [V_MasUserDepartment] where 1=1 ", MainConnection)
            If isSearchOK Then
                txtU_WorkLine.Text = dr("DepartmentCode").ToString
                txtU_WorkLineName.Text = dr("DepartmentName").ToString
            End If
            dr = Nothing
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub txtU_WorkLine_ClearClicked() Handles txtU_WorkLine.ClearClicked
        txtU_WorkLineName.ResetText()
    End Sub

    Private Sub txtU_WorkLine_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtU_WorkLine.KeyPress
        txtU_WorkLine_ButtonClick(sender, e)
        e.Handled = True
    End Sub

    Private Sub txtU_ImgPath_ButtonClick(sender as Object, e as Eventargs) Handles txtU_ImgPath.ButtonClick
        Try
            imgUserDialog = New OpenFileDialog()
            If imgUserDialog.ShowDialog() = DialogResult.OK Then
                strPath = System.IO.Path.GetFullPath(imgUserDialog.FileName)
                txtU_ImgPath.Text = strPath
                If String.IsNullOrEmpty(strPath) = False Then
                    UserImage.ImageLocation = strPath
                    txtU_ImgPath.Text = strPath
                End If
            End If

        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtU_ImgPath_ClearClicked() Handles txtU_ImgPath.ClearClicked
        UserImage.ImageLocation = Nothing
    End Sub

    Private Sub btnOperation_Click(sender as Object, e as Eventargs) Handles btnOperation.Click
        Hname = "OPR"
        LoadMenu()
        togSelectall_CheckedChanged(sender, e)
    End Sub

    Private Sub btnMaster_Click(sender as Object, e as Eventargs) Handles btnMaster.Click
        Hname = "MaS"
        LoadMenu()
        togSelectall_CheckedChanged(sender, e)
    End Sub

    Private Sub btnReport_Click(sender as Object, e as Eventargs) Handles btnReport.Click
        Hname = "RPT"
        LoadMenu()
        togSelectall_CheckedChanged(sender, e)
    End Sub
    Private Sub btnSysConfig_Click(sender as Object, e as Eventargs) Handles btnSysConfig.Click
        Hname = "SYS"
        LoadMenu()
        togSelectall_CheckedChanged(sender, e)
    End Sub

    Private Sub btnSaveauthorize_Click(sender as Object, e as Eventargs) Handles btnSaveauthorize.Click
        If String.IsNullOrEmpty(txtU_Code.Text) Then Exit Sub
        If IsNewauthen Then
            Saveauthorize(1)
        Else
            Saveauthorize(0)
        End If
    End Sub

    Private Sub txtU_EntryCode_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtU_EntryCode.KeyPress
        txtConfirmPassword.Visible = True
    End Sub

    Private Sub dgvMenuList_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvMenuList.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvMenuList.RowCount - 1 Then Exit Sub

            If e.RowIndex >= 0 Then
                togSelectall.Checked = False
                Userauthorize(txtU_Code.Text, dgvMenuList.CurrentRow.Cells(3).Value.ToString())
                txtappID.Text = Userauthen.appID
                txtMenuID.Text = Userauthen.MenuID
                UMaIdentity = Userauthen.UMaIdentity
                If UMaIdentity = 0 Then
                    txtappID.Text = dgvMenuList.CurrentRow.Cells(3).Value.ToString()
                    txtMenuID.Text = "1"
                    IsNewauthen = True
                Else
                    IsNewauthen = False
                End If
                togIsOpenMenu.Checked = Userauthen.IsOpenMenu.ToString()
                togIsInsertData.Checked = Userauthen.IsInsertData.ToString()
                togIsEditData.Checked = Userauthen.IsEditData.ToString()
                togIsDeleteData.Checked = Userauthen.IsDeleteData.ToString()
                togIsPrintData.Checked = Userauthen.IsPrintData.ToString()
                togIsCheckData.Checked = Userauthen.IsCheckData.ToString()
                togIsapprove.Checked = Userauthen.Isapprove.ToString()
                togIsReapprove.Checked = Userauthen.IsReapprove.ToString()
                togIsCancel.Checked = Userauthen.IsCancel.ToString()
                togIsRecancel.Checked = Userauthen.IsRecancel.ToString()
            End If

        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub togSelectall_CheckedChanged(sender as Object, e as Eventargs) Handles togSelectall.CheckedChanged
        If togSelectall.Checked Then
            togIsOpenMenu.Checked = True
            togIsInsertData.Checked = True
            togIsEditData.Checked = True
            togIsDeleteData.Checked = True
            togIsPrintData.Checked = True
            togIsCheckData.Checked = True
            togIsapprove.Checked = True
            togIsReapprove.Checked = True
            togIsCancel.Checked = True
            togIsRecancel.Checked = True
        Else
            togIsOpenMenu.Checked = False
            togIsInsertData.Checked = False
            togIsEditData.Checked = False
            togIsDeleteData.Checked = False
            togIsPrintData.Checked = False
            togIsCheckData.Checked = False
            togIsapprove.Checked = False
            togIsReapprove.Checked = False
            togIsCancel.Checked = False
            togIsRecancel.Checked = False
        End If
    End Sub

    Private Sub cmdCopy_Click(sender as Object, e as Eventargs) Handles cmdCopy.Click

    End Sub
End Class