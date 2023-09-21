Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Text

Public Class frmMasVessel
    Public _IsNew as Boolean

    Private Sub frmMasVessel_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        addNewData()
        LoadData()
    End Sub

    Private Sub cmdNew_Click(sender as Object, e as Eventargs) Handles cmdNew.Click
        addNewData()
    End Sub

    Private Sub cmdSave_Click(sender as Object, e as Eventargs) Handles cmdSave.Click
        If String.IsNullOrEmpty(txtVesselCode.Text) Then
            txtVesselCode.Focus()
            txtVesselCode.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtVesselCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        'If String.IsNullOrEmpty(txtRegisterNumber.Text) Then
        '    txtRegisterNumber.Focus()
        '    txtRegisterNumber.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtRegisterNumber.Style = MetroFramework.MetroColorStyle.Default
        'End If
        If String.IsNullOrEmpty(txtVesselName.Text) Then
            txtVesselName.Focus()
            txtVesselName.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtVesselName.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(cmbVesselType.Text) Then
            cmbVesselType.Focus()
            cmbVesselType.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            cmbVesselType.Style = MetroFramework.MetroColorStyle.Default
        End If
        'If String.IsNullOrEmpty(txtCountryCode.Text) Then
        '    txtCountryCode.Focus()
        '    txtCountryCode.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtCountryCode.Style = MetroFramework.MetroColorStyle.Default
        'End If
        If _IsNew Then
            If txtVesselCode.Text = "" Or txtVesselCode.Text = RunningForm.Run_Formatt Then
                txtVesselCode.Text = CreateNumber("Mas_Vessel", "VesselCode", False)
            Else
                If CheckCode("Mas_Vessel", "VesselCode", txtVesselCode.Text) Then
                    MetroFramework.MetroMessageBox.Show(Main, "Duplicate Document Number Please Check.", "Document Number!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If
            SaveData(1)
        Else
            'MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        'If Userauthen.IsEditData = 1 Then
        SaveData(0)
        'Else
        'MetroFramework.MetroMessageBox.Show(Main, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Exit Sub
        'End If

    End Sub

    Private Sub cmdClose_Click(sender as Object, e as Eventargs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub addNewData()
        txtTBIDNT.Text = "0" 'TBIDNT
        txtVesselCode.ResetText() 'VendorCode
        txtRegisterNumber.ResetText() 'RegisterNumber
        txtVesselName.ResetText() 'VesselName
        cmbVesselType.ResetText() 'VesselType
        txtCountryCode.ResetText() 'CountryCode
        txtCountryName.ResetText()
        togactive.Checked = True  'active
        _IsNew = True
        GetRunningFormat("VSL")
        txtVesselCode.Text = RunningForm.Run_Formatt
        txtVesselCode.Focus()

    End Sub
    Private Sub LoadData()
        Try
            dgvVesselList.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM V_MasVessel where 1=1 "
            If Not String.IsNullOrEmpty(txtVesselCodeS.Text) Then str &= " aND [VesselCode] LIKE'%" & txtVesselCodeS.Text & "%'"
            If Not String.IsNullOrEmpty(txtVesselNameS.Text) Then str &= " aND [VesselName] LIKE'%" & txtVesselNameS.Text & "%'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvVesselList.Rows.add(dt.Rows(i)("TBIDNT").ToString(), 'TBIDNT
                        dt.Rows(i)("VesselCode").ToString(), 'VesselCode
                        dt.Rows(i)("RegisterNumber").ToString(), 'RegisterNumber
                        dt.Rows(i)("VesselName").ToString(), 'VesselName
                        dt.Rows(i)("VesselType").ToString(), 'VesselType
                        dt.Rows(i)("CountryCode").ToString(), 'CountryCode
                        dt.Rows(i)("CountryName").ToString(), 'CountryName
                        dt.Rows(i)("active").ToString() 'active
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
    Private Sub SaveData(_Insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_Vessel ")
            SQLcommand.append("'" & txtTBIDNT.Text & "'") 'TBIDNT
            SQLcommand.append(",'" & txtVesselCode.Text & "'") 'VesselCode
            SQLcommand.append(",'" & txtRegisterNumber.Text & "'") 'RegisterNumber
            SQLcommand.append(",'" & txtVesselName.Text & "'") 'VesselName
            SQLcommand.append(",'" & cmbVesselType.Text & "'") 'VesselType
            SQLcommand.append(",'" & txtCountryCode.Text & "'") 'CountryCode
            SQLcommand.append(",'" & togactive.CheckState & "'") 'active
            SQLcommand.append(",'" & _Insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                addNewData()
            Else
                MetroFramework.MetroMessageBox.Show(Main, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtVesselCodeS_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtVesselCodeS.KeyPress

    End Sub

    Private Sub txtVesselNameS_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtVesselNameS.KeyPress

    End Sub

    Private Sub dgvVesselList_CellMouseDoubleClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvVesselList.CellMouseDoubleClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvVesselList.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtTBIDNT.Text = dgvVesselList.CurrentRow.Cells(0).Value.ToString() 'TBIDNT
                txtVesselCode.Text = dgvVesselList.CurrentRow.Cells(1).Value.ToString() 'VesselCode
                txtRegisterNumber.Text = dgvVesselList.CurrentRow.Cells(2).Value.ToString() 'RegisterNumber
                txtVesselName.Text = dgvVesselList.CurrentRow.Cells(3).Value.ToString() 'VesselName
                cmbVesselType.Text = dgvVesselList.CurrentRow.Cells(4).Value.ToString() 'VesselType
                txtCountryCode.Text = dgvVesselList.CurrentRow.Cells(5).Value.ToString() 'CountryCode
                txtCountryName.Text = dgvVesselList.CurrentRow.Cells(6).Value.ToString() 'CountryName
                togactive.Checked = CInt(dgvVesselList.CurrentRow.Cells(7).Value.ToString()) 'active
                _IsNew = False
            End If
        Catch ex as Exception

        End Try

    End Sub

    Private Sub txtCountryCode_ButtonClick(sender as Object, e as Eventargs) Handles txtCountryCode.ButtonClick
        SelectCountry(txtCountryCode, txtCountryName)
    End Sub

    Private Sub txtCountryCode_ClearClicked() Handles txtCountryCode.ClearClicked
        txtCountryName.ResetText()
    End Sub

    Private Sub txtVesselCode_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtVesselName.KeyPress, txtVesselCode.KeyPress, txtRegisterNumber.KeyPress
        CheckQuote(e)
    End Sub

    Private Sub txtVesselCodeS_KeyPress_1(sender as Object, e as KeyPressEventargs) Handles txtVesselNameS.KeyPress, txtVesselCodeS.KeyPress
        CheckQuote(e)
    End Sub
End Class