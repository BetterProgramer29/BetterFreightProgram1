Imports System.Data.OleDb
Imports System.IO
Imports System.Net.Http
Imports System.Text

Public Class UploadFilePage
    Private imgUserDialog As OpenFileDialog
    Private SourcePath As String = ""
    Private Sub AddNewUpload()


        txtTBIDNTUP.Text = "0" 'TBIDNT
        cboDCTYPE.ResetText() 'DCTYPE
        txtExtension.ResetText() 'Extension
        'txtRunNumber.ResetText() 'RunNumber
        'txtJobNumber.ResetText() 'JobNumber
        txtDocnoUp.ResetText() 'Docno
        txtDocNameUp.ResetText() 'DocName
        txtDocDescription.ResetText() 'DocDescription
        txtSourcePath.ResetText() 'SourcePath
        txtTargetPath.ResetText() 'TargetPath
        'togIscheck.Checked = False 'Ischeck
        ' txtCheckBy.ResetText() 'CheckBy
        ' txtCheckDate.ResetText() 'CheckDate
        txtCheckComment.ResetText() 'CheckComment
        txtUploadBy.ResetText() 'UploadBy
        txtUploadDate.ResetText() 'UploadDate
        txtDeleteby.ResetText() 'Deleteby
        txtDeleteDate.ResetText() 'DeleteDate
        'txtReason.ResetText() 'Reason
        togActiveUp.Checked = True  'Active
        '_IsNew = True
        'SourcePath = ""
        txtUploadBy.Text = UserProfile.U_Code
        txtUploadDate.Text = LetDate(Now.Date)
        txtIsnewUp.Text = "1"
        txtUploadNo.ResetText()
    End Sub
    Private Sub LoadDocList()
        Try
            dgvUpLoadFiles.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM INF_ATTACHFILES where [JobNumber]='" & txtMasterBLNo.Text & "' and Active=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvUpLoadFiles.Rows.Add(dt.Rows(i)("TBIDNT").ToString(), 'TBIDNT
                    dt.Rows(i)("DCTYPE").ToString(), 'DCTYPE
                    dt.Rows(i)("Extension").ToString(), 'Extension
                    dt.Rows(i)("RunNumber").ToString(), 'RunNumber
                    dt.Rows(i)("JobNumber").ToString(), 'JobNumber
                    dt.Rows(i)("Docno").ToString(), 'Docno
                    dt.Rows(i)("DocName").ToString(), 'DocName
                    dt.Rows(i)("DocDescription").ToString(), 'DocDescription
                    dt.Rows(i)("SourcePath").ToString(), 'SourcePath
                    dt.Rows(i)("TargetPath").ToString(), 'TargetPath
                    dt.Rows(i)("Ischeck").ToString(), 'Ischeck
                    dt.Rows(i)("CheckBy").ToString(), 'CheckBy
                    DBDate(dt.Rows(i)("CheckDate").ToString()), 'CheckDate
                    dt.Rows(i)("CheckComment").ToString(), 'CheckComment
                    dt.Rows(i)("UploadBy").ToString(), 'UploadBy
                    DBDate(dt.Rows(i)("UploadDate").ToString()), 'UploadDate
                    dt.Rows(i)("Deleteby").ToString(), 'Deleteby
                    DBDate(dt.Rows(i)("DeleteDate").ToString()), 'DeleteDate
                    dt.Rows(i)("Reason").ToString(), 'Reason
                    dt.Rows(i)("Active").ToString(), "0" 'Active Insert
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
    Private Sub SaveDataUpload()
        Try

            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateINF_ATTACHFILES ")
            SQLcommand.Append("'" & txtTBIDNTUP.Text & "'") 'TBIDNT
            SQLcommand.Append(",'" & cboDCTYPE.Text & "'") 'DCTYPE
            SQLcommand.Append(",'" & txtExtension.Text & "'") 'Extension
            SQLcommand.Append(",'" & txtUploadNo.Text & "'") 'RunNumber
            SQLcommand.Append(",'" & txtMasterBLNo.Text & "'") 'JobNumber
            SQLcommand.Append(",'" & txtDocnoUp.Text & "'") 'Docno
            SQLcommand.Append(",'" & txtDocNameUp.Text & "'") 'DocName
            SQLcommand.Append(",'" & txtDocDescription.Text & "'") 'DocDescription
            SQLcommand.Append(",'" & txtSourcePath.Text & "'") 'SourcePath
            SQLcommand.Append(",'" & txtTargetPath.Text & "'") 'TargetPath
            'SQLcommand.Append(",'" & togIscheck.CheckState & "'") 'Ischeck
            'SQLcommand.Append(",'" & txtCheckBy.Text & "'") 'CheckBy
            'SQLcommand.Append(",'" & CDate(txtCheckDate.Text) & "'") 'CheckDate
            SQLcommand.Append(",'" & txtCheckComment.Text & "'") 'CheckComment
            SQLcommand.Append(",'" & txtUploadBy.Text & "'") 'UploadBy
            SQLcommand.Append(",'" & CDate(txtUploadDate.Text) & "'") 'UploadDate
            'SQLcommand.Append(",'" & txtDeleteby.Text & "'") 'Deleteby
            'SQLcommand.Append(",'" & CDate(txtDeleteDate.Text) & "'") 'DeleteDate
            'SQLcommand.Append(",'" & txtReason.Text & "'") 'Reason
            SQLcommand.Append(",'" & togActiveUp.CheckState & "'") 'Active
            SQLcommand.Append(",'" & CInt(txtIsnewUp.Text) & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDocList()
                AddNewUpload()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub DeletedataUpLoad()
        Try

            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("UPDATE INF_ATTACHFILES SET Active=0")
            SQLcommand.Append(",Deleteby='" & UserProfile.U_Code & "'") 'Deleteby
            SQLcommand.Append(",DeleteDate=Convert(datetime,GETDATE(),103)") 'DeleteDate
            SQLcommand.Append(",Reason='Delete by User'") 'Reason
            SQLcommand.Append(" WHERE TBIDNT='" & txtTBIDNTUP.Text & "'") 'TBIDNT
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)

            LoadDocList()
            AddNewUpload()
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Async Function RequestLoad() As Task
        Try
            Dim client As New HttpClient '
            SourcePath = txtSourcePath.Text
            If Not File.Exists(SourcePath) Then
                Exit Function
            End If
            Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(SourcePath)
            Dim base64String As String = Convert.ToBase64String(fileBytes)
            Dim ServURL As String = CMPProfile.PROF_WEB 'txtMyUrl.Text '
            Dim u As New UploadFileXX
            u.fileBinary = base64String
            u.running = txtUploadNo.Text
            u.fileName = Trim(txtDocNameUp.Text.Trim)
            u.action = "UPLOAD"
            Dim json = Newtonsoft.Json.JsonConvert.SerializeObject(u)
            Dim StringContent = New StringContent(json, UnicodeEncoding.UTF8, "application/json")
            Dim response = Await client.PostAsync(ServURL, StringContent)
            txtTargetPath.Text = Await response.Content.ReadAsStringAsync
            'wait return path complete then save
            'txtUploadNo.Text = CreateNumber("INF_ATTACHFILES", "RunNumber", "UPL[AD]######")
            SaveDataUpload()

        Catch ex As Exception

        End Try

    End Function
    Private Async Function RequestDrop() As Task
        Try
            Dim client As New HttpClient '
            Dim ServURL As String = CMPProfile.PROF_WEB 'txtMyUrl.Text '
            Dim u As New UploadFileXX
            u.fileBinary = "" ' base64String
            u.running = txtUploadNo.Text
            u.fileName = txtDocNameUp.Text
            u.action = "DELETE"
            Dim json = Newtonsoft.Json.JsonConvert.SerializeObject(u)
            Dim StringContent = New StringContent(json, UnicodeEncoding.UTF8, "application/json")
            Dim response = Await client.PostAsync(ServURL, StringContent)
            txtTargetPath.Text = Await response.Content.ReadAsStringAsync
            'wait return path complete then save
            DeletedataUpLoad()

        Catch ex As Exception

        End Try
    End Function

    Private Sub btnNewDoc_Click(sender As Object, e As EventArgs) Handles btnNewDoc.Click
        AddNewUpload()
        'ReloadBrowser(CMPProfile.PROF_ExchangeRateURL & txtTargetPath.Text)
    End Sub
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        ' Select Case txtExtension.Text
        'Case ".xlsx", ".xls", ".docx", ".doc"
        '     WebDownLoad.Navigate(CMPProfile.PROF_ExchangeRateURL & txtTargetPath.Text)
        '  Case Else
        '       ReloadBrowser(CMPProfile.PROF_ExchangeRateURL & txtTargetPath.Text)
        'End Select
        ' ReloadBrowser(txtMyUrl.Text)
        If String.IsNullOrEmpty(txtTargetPath.Text) Then Exit Sub
        Dim url As String = CMPProfile.PROF_ExchangeRateURL & txtTargetPath.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub
    Private Sub dgvUpLoadFiles_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvUpLoadFiles.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvUpLoadFiles.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtTBIDNTUP.Text = dgvUpLoadFiles.CurrentRow.Cells(0).Value.ToString() 'TBIDNT
                cboDCTYPE.Text = dgvUpLoadFiles.CurrentRow.Cells(1).Value.ToString() 'DCTYPE
                txtExtension.Text = dgvUpLoadFiles.CurrentRow.Cells(2).Value.ToString() 'Extension
                'txtMasterBLNo.Text = dgvUpLoadFiles.CurrentRow.Cells(3).Value.ToString() 'RunNumber
                txtUploadNo.Text = dgvUpLoadFiles.CurrentRow.Cells(4).Value.ToString() 'JobNumber
                txtDocnoUp.Text = dgvUpLoadFiles.CurrentRow.Cells(5).Value.ToString() 'Docno
                txtDocNameUp.Text = dgvUpLoadFiles.CurrentRow.Cells(6).Value.ToString() 'DocName
                txtDocDescription.Text = dgvUpLoadFiles.CurrentRow.Cells(7).Value.ToString() 'DocDescription
                txtSourcePath.Text = dgvUpLoadFiles.CurrentRow.Cells(8).Value.ToString() 'SourcePath
                txtTargetPath.Text = dgvUpLoadFiles.CurrentRow.Cells(9).Value.ToString() 'TargetPath
                'togIscheck.Checked = CInt(dgvUpLoadFiles.CurrentRow.Cells(10).Value.ToString()) 'Ischeck
                'txtCheckBy.Text = dgvUpLoadFiles.CurrentRow.Cells(11).Value.ToString() 'CheckBy
                'txtCheckDate.Text = dgvUpLoadFiles.CurrentRow.Cells(12).Value.ToString() 'CheckDate
                txtCheckComment.Text = dgvUpLoadFiles.CurrentRow.Cells(13).Value.ToString() 'CheckComment
                txtUploadBy.Text = dgvUpLoadFiles.CurrentRow.Cells(14).Value.ToString() 'UploadBy
                txtUploadDate.Text = dgvUpLoadFiles.CurrentRow.Cells(15).Value.ToString() 'UploadDate
                txtDeleteby.Text = dgvUpLoadFiles.CurrentRow.Cells(16).Value.ToString() 'Deleteby
                txtDeleteDate.Text = dgvUpLoadFiles.CurrentRow.Cells(17).Value.ToString() 'DeleteDate
                ' txtReason.Text = dgvUpLoadFiles.CurrentRow.Cells(18).Value.ToString() 'Reason
                togActiveUp.Checked = CInt(dgvUpLoadFiles.CurrentRow.Cells(19).Value.ToString()) 'Active
                ' _IsNew = False
                txtIsnewUp.Text = CInt(dgvUpLoadFiles.CurrentRow.Cells(20).Value.ToString()) 'Insert

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub txtDocNameUp_ButtonClick(sender As Object, e As EventArgs) Handles txtDocNameUp.ButtonClick, txtSourcePath.ButtonClick
        Try
            imgUserDialog = New OpenFileDialog()
            If imgUserDialog.ShowDialog() = DialogResult.OK Then
                txtSourcePath.Text = System.IO.Path.GetFullPath(imgUserDialog.FileName)
                txtDocNameUp.Text = System.IO.Path.GetFileName(imgUserDialog.FileName)
                txtExtension.Text = System.IO.Path.GetExtension(imgUserDialog.FileName)
                txtUploadBy.Text = UserProfile.U_Code
                txtUploadDate.Text = LetDate(Now.Date)
            End If

        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Async Sub btnSaveDoc_Click(sender As Object, e As EventArgs) Handles btnSaveDoc.Click
#Region "validate Data"
        'If _IsNewContainer Then Exit Sub

        If String.IsNullOrEmpty(cboDCTYPE.Text) Then
            MetroFramework.MetroMessageBox.Show(Me, "เลือกประเภทเอกสารก่อน", "ตรวจสอบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDCTYPE.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDocNameUp.Text) Then
            MetroFramework.MetroMessageBox.Show(Me, "เลือกเอกสารก่อน", "ตรวจสอบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDocNameUp.Focus()
            txtDocNameUp.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtDocNameUp.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtSourcePath.Text) Then
            MetroFramework.MetroMessageBox.Show(Me, "เลือกเอกสารก่อน", "ตรวจสอบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSourcePath.Focus()
            txtSourcePath.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            If Not File.Exists(txtSourcePath.Text) Then
                MetroFramework.MetroMessageBox.Show(Me, "ไม่พบเอกสารตามที่ระบุ", "ตรวจสอบรายการ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            txtSourcePath.Style = MetroFramework.MetroColorStyle.Default
        End If
        'Set Runno Same as JobNo
        txtUploadNo.Text = txtMasterBLNo.Text
#End Region
        Await RequestLoad()
    End Sub

    Private Async Sub btnDeleteDoc_Click(sender As Object, e As EventArgs) Handles btnDeleteDoc.Click
        If txtTBIDNTUP.Text = "0" Then Exit Sub
        If MetroFramework.MetroMessageBox.Show(Me, "ต้องการลบรายการ " & txtDocNameUp.Text & " หรือไม่?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        Else
            Await RequestDrop()
        End If

    End Sub

    Private Sub btnUploadFiles_Click(sender As Object, e As EventArgs) Handles btnUploadFiles.Click
        '  RequestLoad()
    End Sub

    Private Sub UploadFilePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDocList()
    End Sub

    Private Sub togActiveUp_CheckedChanged(sender As Object, e As EventArgs) Handles togActiveUp.CheckedChanged

    End Sub

    'Private Sub btnPrintCreditNote_Click(sender As Object, e As EventArgs) Handles btnPrintCreditNote.Click
    '    Try
    '        GetReportRunning(CInt(cboReportCreditNote.SelectedValue))
    '        Dim rptname As String = RptRunning.RptreportName
    '        Dim Midnt As String = ""
    '        If String.IsNullOrEmpty(rptname) Then Exit Sub
    '        If txtTBIDNTRef.Text = "0" Then Exit Sub
    '        If RptRunning.Ident = 0 Then Exit Sub

    '        Dim MyUrl As String = rptname & txtRefPCBooking.Text & "&ident=" & CInt(txtTBIDNTRef.Text) & "&user=" & UserProfile.U_FName & "%20" & UserProfile.U_LName & "&INVTO=" & cboInvTo.Text
    '        Try
    '            Process.Start("Chrome", MyUrl)
    '        Catch ex As Exception
    '            Process.Start(MyUrl)
    '        End Try
    '    Catch ex As Exception
    '        MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    End Try
    'End Sub
End Class