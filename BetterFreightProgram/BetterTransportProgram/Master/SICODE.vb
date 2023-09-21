Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Imports MetroFramework.Controls
Public Class SICODE
    Public _IsNew as Boolean
    Private Sub SICODE_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        addNewaccount()
        LoadDataTodgv()
    End Sub
    Private Sub addNewaccount()
        txtIdent.Text = "0" 'Ident
        txtaccountGroup.ResetText() 'accountGroup
        txtaccountNo.ResetText() 'accountNo
        txtaccountControl.ResetText() 'accountControl
        txtSICode.ResetText() 'SICode
        txtaccountName.ResetText() 'accountName
        txtItemName.ResetText() 'txtItemName
        _IsNew = True
    End Sub
    Private Sub LoadDataTodgv()
        Try
            dgvSICode.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM MaS_SICODE where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvSICode.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                           dt.Rows(i)(1).ToString(), 'accountGroup
                           dt.Rows(i)(2).ToString(), 'accountNo
                           dt.Rows(i)(3).ToString(), 'accountControl
                           dt.Rows(i)(4).ToString(), 'SICode
                           dt.Rows(i)(5).ToString(), 'accountName
                           dt.Rows(i)(6).ToString(),  'txtItemName
                           dt.Rows(i)(7).ToString()
                           )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveData(_Insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMaS_SICODE ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtaccountGroup.Text & "'") 'accountGroup
            SQLcommand.append(",'" & txtaccountNo.Text & "'") 'accountNo
            SQLcommand.append(",'" & txtaccountControl.Text & "'") 'accountControl
            SQLcommand.append(",'" & txtSICode.Text & "'") 'SICode
            SQLcommand.append(",'" & txtaccountName.Text & "'") 'accountName
            SQLcommand.append(",'" & txtItemName.Text & "'") 'txtItemName
            SQLcommand.append(",'" & cboSIGroup.Text & "'")
            SQLcommand.append(",'" & _Insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataTodgv()
                _IsNew = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        If txtItemName.Text = "" Then
            MsgBox("กรุณาใส่ชื่อรายการ")
        Else
            If txtSICode.Text = "" Then
                'txtaccountNo.Text = CreateNumber("addTransport", "JobNo", txtaccountControl.Text.Replace("-00", "-##"))
                'If txtaccountNo.Text = "1504-06" Then
                '    RunningaTK()
                'ElseIf txtaccountNo.Text = "2403-04" Then
                '    RunningTTK()
                'ElseIf txtaccountNo.Text = "4200-04" Then
                '    RunningSTK()
                'ElseIf txtaccountNo.Text = "2102-00" Or txtaccountNo.Text = "5200-04" Or txtaccountNo.Text = "5202-01" Or txtaccountNo.Text = "5202-02" Or txtaccountNo.Text = "5202-03" Or txtaccountNo.Text = "2102-02" Or txtaccountNo.Text = "1900-01" Or txtaccountNo.Text = "5400-09" Then
                '    RunningCTK()
                'ElseIf txtaccountNo.Text = "1000-04" Then
                '    RunningaDV()
                'End If
                If cboSIGroup.Text = "ADV" Then
                    RunningaDV()
                ElseIf cboSIGroup.Text = "CTK" Then
                    RunningCTK()
                ElseIf cboSIGroup.Text = "ATK" Then
                    RunningaTK()
                ElseIf cboSIGroup.Text = "TTK" Then
                    RunningTTK()
                ElseIf cboSIGroup.Text = "STK" Then
                    RunningSTK()
                ElseIf cboSIGroup.Text = "SRV" Then
                    RunningSRV()
                ElseIf cboSIGroup.Text = "EXP" Then
                    RunningEXP()
                ElseIf cboSIGroup.Text = "ASP" Then
                    RunningaSP()
                ElseIf cboSIGroup.Text = "AVF" Then
                    RunningaVF()
                ElseIf cboSIGroup.Text = "OAP" Then
                    RunningOaP()
                ElseIf cboSIGroup.Text = "OAF" Then
                    RunningOaF()
                ElseIf cboSIGroup.Text = "OAK" Then
                    RunningOaK()
                ElseIf cboSIGroup.Text = "SVP" Then
                    RunningSVP()
                ElseIf cboSIGroup.Text = "SVF" Then
                    RunningSVF()
                ElseIf cboSIGroup.Text = "CSP" Then
                    RunningCSP()
                ElseIf cboSIGroup.Text = "CVF" Then
                    RunningCVF()
                ElseIf cboSIGroup.Text = "OCP" Then
                    RunningOCP()
                ElseIf cboSIGroup.Text = "OCF" Then
                    RunningOCF()
                ElseIf cboSIGroup.Text = "OCK" Then
                    RunningOCK()
                Else
                    MsgBox("ThenUnexpect case")
                    Exit Sub
                End If

            End If
            If _IsNew = True Then
                SaveData(1)
            Else
                SaveData(0)
            End If
        End If
    End Sub
    Private Sub txtaccountControl_ButtonClick(sender as Object, e as Eventargs) Handles txtaccountControl.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [accountNo],[accountName] FROM [accountPlan] WHERE IsControl=1", MainConnection)
        If isSearchOK Then
            txtaccountControl.Text = dr("accountNo").ToString
        End If
    End Sub

    Private Sub txtaccountGroup_ButtonClick(sender as Object, e as Eventargs) Handles txtaccountGroup.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [accountGroup],[accountControl]  FROM [accountPlan] WHERE accountNo ='2000-00'or accountNo='1000-00' or accountNo='3000-00' or accountNo='4000-00' or accountNo='5000-00' ", MainConnection)
        If isSearchOK Then
            txtaccountGroup.Text = dr("accountGroup").ToString
            txtaccountControl.Text = dr("accountControl").ToString
        End If
    End Sub

    Private Sub txtaccountNo_ButtonClick(sender as Object, e as Eventargs) Handles txtaccountNo.ButtonClick
        If txtaccountControl.Text = "5000-00" Then
            Dim dr as DataRow
            dr = PopUpSearch("Select [accountNo],[accountName]  FROM [accountPlan] WHERE accountControl Like '5%'", MainConnection)
            If isSearchOK Then
                txtaccountNo.Text = dr("accountNo").ToString
                txtaccountName.Text = dr("accountName").ToString
            End If
        ElseIf txtaccountControl.Text = "4000-00" Then
            Dim dr as DataRow
            dr = PopUpSearch("Select [accountNo],[accountName]  FROM [accountPlan] WHERE accountControl Like '4%'", MainConnection)
            If isSearchOK Then
                txtaccountNo.Text = dr("accountNo").ToString
                txtaccountName.Text = dr("accountName").ToString
            End If
        ElseIf txtaccountControl.Text = "3000-00" Then
            Dim dr as DataRow
            dr = PopUpSearch("Select [accountNo],[accountName]  FROM [accountPlan] WHERE accountControl Like '3%'", MainConnection)
            If isSearchOK Then
                txtaccountNo.Text = dr("accountNo").ToString
                txtaccountName.Text = dr("accountName").ToString
            End If
        ElseIf txtaccountControl.Text = "2000-00" Then
            Dim dr as DataRow
            dr = PopUpSearch("Select [accountNo],[accountName]  FROM [accountPlan] WHERE accountControl Like '2%'", MainConnection)
            If isSearchOK Then
                txtaccountNo.Text = dr("accountNo").ToString
                txtaccountName.Text = dr("accountName").ToString
            End If
        ElseIf txtaccountControl.Text = "1000-00" Then
            Dim dr as DataRow
            dr = PopUpSearch("Select [accountNo],[accountName]  FROM [accountPlan] WHERE accountControl Like '1%'", MainConnection)
            If isSearchOK Then
                txtaccountNo.Text = dr("accountNo").ToString
                txtaccountName.Text = dr("accountName").ToString
            End If
        End If
    End Sub
    Private Sub RunningaTK()
        GetRunningFormat("ATK")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningTTK()
        GetRunningFormat("TTK")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningSTK()
        GetRunningFormat("STK")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningCTK()
        GetRunningFormat("CTK")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningaDV()
        GetRunningFormat("ADV")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningSRV()
        GetRunningFormat("SRV")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningEXP()
        GetRunningFormat("EXP")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningaSP()
        GetRunningFormat("ASP")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningaVF()
        GetRunningFormat("AVF")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningOaP()
        GetRunningFormat("OAP")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningOaF()
        GetRunningFormat("OAF")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningOaK()
        GetRunningFormat("OAK")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningSVP()
        GetRunningFormat("SVP")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningSVF()
        GetRunningFormat("SVF")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningCSP()
        GetRunningFormat("CSP")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningCVF()
        GetRunningFormat("CVF")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningOCP()
        GetRunningFormat("OCP")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningOCF()
        GetRunningFormat("OCF")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub RunningOCK()
        GetRunningFormat("OCK")
        txtSICode.Text = CreateNumber("MaS_SICODE", "SICode", False)
    End Sub
    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        addNewaccount()
    End Sub

    Private Sub dgvSICode_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvSICode.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvSICode.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdent.Text = CInt(dgvSICode.CurrentRow.Cells(0).Value.ToString()) 'Ident
                txtaccountGroup.Text = dgvSICode.CurrentRow.Cells(1).Value.ToString() 'accountGroup
                txtaccountNo.Text = dgvSICode.CurrentRow.Cells(2).Value.ToString() 'accountNo
                txtaccountControl.Text = dgvSICode.CurrentRow.Cells(3).Value.ToString() 'accountControl
                txtSICode.Text = dgvSICode.CurrentRow.Cells(4).Value.ToString() 'SICode
                txtaccountName.Text = dgvSICode.CurrentRow.Cells(5).Value.ToString() 'accountName
                txtItemName.Text = dgvSICode.CurrentRow.Cells(6).Value.ToString() 'ItemName
                cboSIGroup.Text = dgvSICode.CurrentRow.Cells(7).Value.ToString() 'SIGroup
                _IsNew = False
            End If
        Catch ex as Exception

        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender as Object, e as Eventargs) Handles RefreshToolStripMenuItem.Click
        LoadDataTodgv()
    End Sub

    Private Sub Button1_Click(sender as Object, e as Eventargs)

    End Sub
End Class
'    Public _IsNew as Boolean
'    Public Open as Boolean = False
'    Private Sub SICODE_Load(sender as Object, e as Eventargs) Handles MyBase.Load
'        LoadDataToDgv()
'        addNewData()
'        MetroTextBox2.Text = CreateNumber("addTransport", "JobNo", MetroTextBox1.Text)
'    End Sub
'    Private Sub SaveSICode(_insert as Integer)
'        Try
'            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
'            nection = ConnectDB()
'            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMaS_SICODE ")
'            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
'            SQLcommand.append(",'" & txtTypeName.Text & "'") 'TypeName
'            SQLcommand.append(",'" & txtCodeName.Text & "'") 'CodeName
'            SQLcommand.append(",'" & txtCodeDescription.Text & "'") 'CodeDescription
'            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
'            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
'            If result = 1 Then
'                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                LoadDataToDgv()
'                _IsNew = False
'            Else
'                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
'            End If
'            nection.Close()
'        Catch ex as Exception
'            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
'        End Try
'    End Sub

'    Private Sub txtTypeName_ButtonClick(sender as Object, e as Eventargs)
'        SICodeOpen()
'        'If Open = False Then

'        'End If
'    End Sub
'    Private Sub SICodeOpen()
'        'Open = True
'        frmSICodeType.Show()
'    End Sub

'    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
'        If _IsNew = True Then
'            SaveSICode(1)
'        Else
'            SaveSICode(0)
'        End If
'    End Sub
'    Private Sub LoadDataToDgv()
'        Try
'            dgvSICode.Rows.Clear()
'            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
'            Dim dt as DataTable = New DataTable()
'            Dim nection as New OleDb.OleDbConnection()
'            nection = ConnectDB()
'            Dim str as String = "SELECT * FROM MaS_SICODE where 1=1"
'            da.SelectCommand = New OleDbCommand(str, nection)

'            da.Fill(dt)
'            If dt.Rows.Count > 0 Then
'                For i as Integer = 0 To dt.Rows.Count - 1
'                    dgvSICode.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
'                    dt.Rows(i)(1).ToString(), 'TypeName
'                    dt.Rows(i)(2).ToString(), 'CodeName
'                    dt.Rows(i)(3).ToString()  'CodeDescription
'                    )
'                Next

'                da = Nothing
'                dt = Nothing
'                nection.Close()
'            End If
'        Catch ex as Exception
'            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
'        End Try
'    End Sub
'    Private Sub addNewData()
'        txtIdent.Text = "0" 'Ident
'        txtTypeName.ResetText() 'TypeName
'        txtCodeName.ResetText() 'CodeName
'        txtCodeDescription.ResetText() 'CodeDescription
'        _IsNew = True
'    End Sub

'    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
'        addNewData()
'    End Sub

'    Private Sub dgvSICode_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvSICode.CellMouseClick
'        Try
'            If e.RowIndex < 0 Or e.RowIndex > dgvSICode.Rows.Count - 1 Then Exit Sub
'            If e.RowIndex >= 0 Then
'                txtIdent.Text = CInt(dgvSICode.CurrentRow.Cells(0).Value.ToString()) 'Ident
'                txtTypeName.Text = dgvSICode.CurrentRow.Cells(1).Value.ToString() 'TypeName
'                txtCodeName.Text = dgvSICode.CurrentRow.Cells(2).Value.ToString() 'CodeName
'                txtCodeDescription.Text = dgvSICode.CurrentRow.Cells(3).Value.ToString() 'CodeDescription
'                _IsNew = False
'            End If
'        Catch ex as Exception

'        End Try

'    End Sub