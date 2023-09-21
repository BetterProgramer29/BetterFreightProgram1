Imports System.Data.SqlClient
Public Class frmSeachEngine
    Dim SourceCommand As String
    Dim orderby As String = ""
    Dim SourceCn As OleDb.OleDbConnection
    Public FindSuccess As Boolean
    Public RowReturn As DataRowView
    Public Property HideColumn As String
    Sub LoadGrid(ByVal SQLCommand As String, ByVal Cn As OleDb.OleDbConnection)
        SourceCommand = Nothing
        SourceCommand = SQLCommand.ToUpper
        SourceCn = Cn
        ShowGrid(SQLCommand)
        Me.txtFindRecord.Focus()
        'Try
        '    If SourceCn Is Nothing Then SourceCn = Cn
        '    If SourceCommand = "" Then SourceCommand = getDataSplit(SQLCommand, "order by", 0)
        '    If orderby = "" Then
        '        orderby = getDataSplit(SQLCommand, "order by", 1)
        '        If orderby <> "" Then
        '            orderby = " ORDER BY " & orderby
        '        End If
        '    End If
        '    Dim da As New OleDb.OleDbDataAdapter(SQLCommand, Cn)
        '    Dim dt As New DataTable
        '    Dim i As Integer = 0
        '    da.Fill(dt)
        '    DataGridView1.DataSource = dt
        '    If ComboBox1.Items.Count = 0 Then
        '        ComboBox1.Items.Clear()
        '        For i = 0 To dt.Columns.Count - 1
        '            ComboBox1.Items.Add(dt.Columns(i).Caption)
        '        Next
        '        ComboBox1.SelectedIndex = 0
        '    End If
        'Catch ex As Exception
        '    Exit Try
        'End Try
    End Sub
    Private Sub ShowGrid(SQLCommand As String, Optional ByVal Isfind As Integer = 0)
        Try
            If SourceCommand.IndexOf("ORDER BY".ToUpper) < 1 Then
                SourceCommand &= "ORDER BY 1"
            End If
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(SQLCommand, SourceCn)
            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            dgvFindRecord.DataSource = Nothing
            dgvFindRecord.DataSource = dt
            If dgvFindRecord.DataSource IsNot Nothing Then
                If String.IsNullOrEmpty(HideColumn) = False Then
                    For Each x In HideColumn.Split(",".ToCharArray())
                        dgvFindRecord.Columns(x).Visible = False
                    Next
                End If
            End If
            If Isfind = 0 Then
                cbSelectField.Items.Clear()
                For i As Integer = 0 To dt.Columns.Count - 1
                    cbSelectField.Items.Add(dt.Columns(i).Caption)
                Next
                cbSelectField.SelectedIndex = 0
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " + ex.Message, " " + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        Me.txtFindRecord.Focus()
    End Sub
    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.cbSelectField.SelectedIndex = dgvFindRecord.SortedColumn.Index
        Me.txtFindRecord.Focus()
    End Sub

    Private Sub FrmFindRecord_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FindSuccess = False
        txtFindRecord.ResetText()
        Me.txtFindRecord.Focus()
        'txtFindRecord.Focus()
    End Sub

    Private Sub btnApply_Click_1(sender As Object, e As EventArgs) Handles btnApply.Click
        Try
            If dgvFindRecord.Rows.Count = 0 Then Exit Sub
            RowReturn = DirectCast(dgvFindRecord.CurrentRow.DataBoundItem, DataRowView)
            FindSuccess = True
            txtFindRecord.ResetText()
            Me.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " + ex.Message, " " + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtFindRecord.TextChanged
        Try
            If cbSelectField.Text <> "" Or cbSelectField.SelectedIndex > 0 Then
                Dim SQLCommand As String = SourceCommand
                Dim strWhere As String = " and " & cbSelectField.Text & " LIKE'%" & txtFindRecord.Text & "%' "
                Dim indexOrderBy As Integer = SQLCommand.IndexOf("ORDER BY")
                If indexOrderBy < 1 Then
                    SQLCommand &= strWhere
                    SQLCommand &= "ORDER BY 1 "
                Else
                    orderby = ""
                    orderby = SQLCommand.Substring(indexOrderBy, (SQLCommand.Length - indexOrderBy))
                    SQLCommand = SQLCommand.Substring(0, indexOrderBy)
                    SQLCommand &= strWhere
                    SQLCommand &= " " & orderby
                End If
                ShowGrid(SQLCommand, 1)
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " + ex.Message, " " + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFindRecord.KeyPress
        CheckQuote(e)
        If e.KeyChar = Chr(Keys.Enter) Then
            Try
                If cbSelectField.Text <> "" Or cbSelectField.SelectedIndex > 0 Then
                    Dim SQLCommand As String = SourceCommand
                    Dim strWhere As String = " and " & cbSelectField.Text & " LIKE'%" & txtFindRecord.Text & "%' "
                    Dim indexOrderBy As Integer = SQLCommand.IndexOf("ORDER BY")
                    If indexOrderBy < 1 Then
                        SQLCommand &= strWhere
                        SQLCommand &= "ORDER BY 1 "
                    Else
                        orderby = ""
                        orderby = SQLCommand.Substring(indexOrderBy, (SQLCommand.Length - indexOrderBy))
                        SQLCommand = SQLCommand.Substring(0, indexOrderBy)
                        SQLCommand &= strWhere
                        SQLCommand &= " " & orderby
                    End If
                    ShowGrid(SQLCommand, 1)
                End If
            Catch ex As Exception
                MetroFramework.MetroMessageBox.Show(Main, "Error " + ex.Message, " " + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFindRecord.CellDoubleClick
        'If e.RowIndex >= 0 Then
        '    RowReturn = DirectCast(dgvFindRecord.Rows(e.RowIndex).DataBoundItem, DataRowView)
        '    FindSuccess = True
        '    Me.Hide()
        'End If
    End Sub

    Private Sub dgvFindRecord_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvFindRecord.CellMouseDoubleClick
        If e.RowIndex >= 0 Then
            RowReturn = DirectCast(dgvFindRecord.Rows(e.RowIndex).DataBoundItem, DataRowView)
            FindSuccess = True
            txtFindRecord.ResetText()
            Me.Close()
        End If
    End Sub

    Private Sub dgvFindRecord_Sorted(sender As Object, e As EventArgs) Handles dgvFindRecord.Sorted
        Me.cbSelectField.SelectedIndex = dgvFindRecord.SortedColumn.Index
        Me.txtFindRecord.Focus()

    End Sub

    Private Sub txtFindRecord_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFindRecord.KeyDown
        CheckKey(e)
        Me.txtFindRecord.Focus()
    End Sub
End Class