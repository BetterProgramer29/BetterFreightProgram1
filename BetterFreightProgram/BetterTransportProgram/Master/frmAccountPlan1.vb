Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text

Public Class frmaccountPlan1
    Public _IsNew as Boolean

    Private Sub Label2_Click(sender as Object, e as Eventargs) Handles Label2.Click

    End Sub

    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        If _IsNew = True Then
            SaveData(1)
        Else
            SaveData(0)
        End If
    End Sub
    Private Sub addNewData()
        txtaccountNo.ResetText() 'accountNo
        txtaccountName.ResetText() 'accountName
        txtaccountGroup.ResetText() 'accountGroup
        txtaccountControl.ResetText() 'accountControl
        txtaccountControlName.ResetText() 'accountControlName
        togIsControl.Checked = False 'IsControl
        txtIdent.Text = "0" 'Ident
        _IsNew = True
    End Sub
    Private Sub SaveData(_Insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateaccountPlan ")
            SQLcommand.append("'" & txtaccountNo.Text & "'") 'accountNo
            SQLcommand.append(",'" & txtaccountName.Text & "'") 'accountName
            SQLcommand.append(",'" & txtaccountGroup.Text & "'") 'accountGroup
            SQLcommand.append(",'" & txtaccountControl.Text & "'") 'accountControl
            SQLcommand.append(",'" & txtaccountControlName.Text & "'") 'accountControlName
            SQLcommand.append(",'" & togIsControl.CheckState & "'") 'IsControl
            SQLcommand.append(",'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & _Insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataTodgv()
                _IsNew = False
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub frmSICodeType_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        LoadDataTodgv()
        addNewData()
    End Sub

    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        addNewData()
    End Sub

    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click

    End Sub
    Private Sub LoadDataTodgv()
        Try
            dgvaccount.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM accountPlan where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvaccount.Rows.add(dt.Rows(i)(0).ToString(), 'accountNo
                    dt.Rows(i)(1).ToString(), 'accountName
                    dt.Rows(i)(2).ToString(), 'accountGroup
                    dt.Rows(i)(3).ToString(), 'accountControl
                    dt.Rows(i)(4).ToString(), 'accountControlName
                    dt.Rows(i)(5).ToString(), 'IsControl
                    dt.Rows(i)(6).ToString() 'Ident
                    )
                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvaccount_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvaccount.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvaccount.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtaccountNo.Text = dgvaccount.CurrentRow.Cells(0).Value.ToString() 'accountNo
                txtaccountName.Text = dgvaccount.CurrentRow.Cells(1).Value.ToString() 'accountName
                txtaccountGroup.Text = dgvaccount.CurrentRow.Cells(2).Value.ToString() 'accountGroup
                txtaccountControl.Text = dgvaccount.CurrentRow.Cells(3).Value.ToString() 'accountControl
                txtaccountControlName.Text = dgvaccount.CurrentRow.Cells(4).Value.ToString() 'accountControlName
                togIsControl.Checked = CInt(dgvaccount.CurrentRow.Cells(5).Value.ToString()) 'IsControl
                txtIdent.Text = CInt(dgvaccount.CurrentRow.Cells(6).Value.ToString()) 'Ident
                _IsNew = False
            End If
        Catch ex as Exception

        End Try

    End Sub
End Class
'Public _IsNew as Boolean
'Private Sub frmSICodeType_Load(sender as Object, e as Eventargs) Handles MyBase.Load
'    LoadSICodeToDgv()
'    addNewSICode()
'End Sub
'Private Sub SaveSICode(_insert as Integer)
'    Try
'        Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
'        nection = ConnectDB()
'        Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_SICODEType ")
'        SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
'        SQLcommand.append(",'" & txtSICode.Text & "'") 'SICode
'        SQLcommand.append(",'" & txtSICodeDescription.Text & "'") 'SICodeDescription
'        SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
'        Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
'        If result = 1 Then
'            MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            LoadSICodeToDgv()
'            _IsNew = False
'        Else
'            MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
'        End If
'        nection.Close()
'    Catch ex as Exception
'        MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
'    End Try
'End Sub

'Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
'    If _IsNew = True Then
'        SaveSICode(1)
'    Else
'        SaveSICode(0)
'    End If
'End Sub

'Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
'    addNewSICode()
'End Sub
'Private Sub addNewSICode()
'    txtIdent.Text = "0" 'Ident
'    txtSICode.ResetText() 'SICode
'    txtSICodeDescription.ResetText() 'SICodeDescription
'    _IsNew = True
'End Sub
'Private Sub LoadSICodeToDgv()
'    Try
'        dgvSICode.Rows.Clear()
'        Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
'        Dim dt as DataTable = New DataTable()
'        Dim nection as New OleDb.OleDbConnection()
'        nection = ConnectDB()
'        Dim str as String = "SELECT * FROM Mas_SICODEType where 1=1"
'        da.SelectCommand = New OleDbCommand(str, nection)

'        da.Fill(dt)
'        If dt.Rows.Count > 0 Then
'            For i as Integer = 0 To dt.Rows.Count - 1
'                dgvSICode.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
'                dt.Rows(i)(1).ToString(), 'SICode
'                dt.Rows(i)(2).ToString()  'SICodeDescription
'                )
'            Next

'            da = Nothing
'            dt = Nothing
'            nection.Close()
'        End If
'    Catch ex as Exception
'        MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
'    End Try
'End Sub

'Private Sub dgvSICode_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvSICode.CellMouseClick
'    Try
'        If e.RowIndex < 0 Or e.RowIndex > dgvSICode.Rows.Count - 1 Then Exit Sub
'        If e.RowIndex >= 0 Then
'            txtIdent.Text = CInt(dgvSICode.CurrentRow.Cells(0).Value.ToString()) 'Ident
'            txtSICode.Text = dgvSICode.CurrentRow.Cells(1).Value.ToString() 'SICode
'            txtSICodeDescription.Text = dgvSICode.CurrentRow.Cells(2).Value.ToString() 'SICodeDescription
'            _IsNew = False
'        End If
'    Catch ex as Exception

'    End Try
'End Sub

'Private Sub txtSICode_TextChanged(sender as Object, e as Eventargs) Handles txtSICode.TextChanged
'    'SICODE.txtTypeName.Text = txtSICode.Text
'End Sub