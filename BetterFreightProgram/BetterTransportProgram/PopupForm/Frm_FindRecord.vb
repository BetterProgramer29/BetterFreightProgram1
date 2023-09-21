Imports System.Data.OleDb
Public Class Frm_FindRecord
    Dim SourceCommand As String = ""
    Dim orderby, iwhere As String
    Dim SourceCn As OleDb.OleDbConnection
    Public RowReturn As DataRowCollection
    Public RowRetrn As DataRowView
    Sub LoadGrid(ByVal SQLCommand As String, ByVal Cn As OleDb.OleDbConnection)
        ' Try
        If SourceCn Is Nothing Then SourceCn = Cn
            If SourceCommand = "" Then
                SourceCommand = getDataSplit(SQLCommand, "order by", 0)
                SourceCommand = getDataSplit(SourceCommand, "where", 0)
            End If
            If iwhere = "" Then
                iwhere = getDataSplit(SQLCommand, "order by", 0)
                iwhere = getDataSplit(iwhere, "where", 1)
                If iwhere <> "" Then
                    iwhere = " where " & iwhere
                End If
            End If
            If orderby = "" Then
                orderby = getDataSplit(SQLCommand, "order by", 1)
                If orderby <> "" Then
                    orderby = " order by " & orderby
                End If
            End If
            Dim da As New OleDb.OleDbDataAdapter(SQLCommand, Cn)
            Dim dt As New DataTable
            Dim i As Integer = 0
            da.Fill(dt)
            DataGridView1.DataSource = dt
            RowReturn = dt.Rows
            If ComboBox1.Items.Count = 0 Then
                ComboBox1.Items.Clear()
                For i = 0 To dt.Columns.Count - 1
                    ComboBox1.Items.Add(dt.Columns(i).Caption)
                Next
                ComboBox1.SelectedIndex = 0
            End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        '    Exit Try
        'End Try
    End Sub
    'Private Sub finding()
    '    Dim da As New OleDbDataAdapter
    '    Dim ds = New DataSet
    '    da.SelectCommand = New OleDbCommand("SELECT TaxBranch,TName from Mas_TaxCode", cn)
    '    da.Fill(ds, "countpt")
    '    If ds.Tables("countpt").Rows.Count = 0 Then
    '        MsgBox("ไม่มีข้อมูล", MsgBoxStyle.Information, "รายงานสถานะ")
    '        Exit Sub
    '    End If

    '    DataGridView1.DataSource = ds.Tables("countpt")
    '    With DataGridView1
    '        .Columns(0).HeaderText = "หมายเลขผู้เสียภาษี"
    '        .Columns(1).HeaderText = "ชื่อบริษัท"
    '        '.Columns(2).HeaderText = "ที่อยู่"
    '        '.Columns(3).HeaderText = "เบอร์โทร"
    '        '.Columns(4).HeaderText = "วัน เวลา ที่มา"
    '        '.Columns(5).HeaderText = "วัน เวลา ที่มา"

    '        .Columns(0).Width = 150
    '        .Columns(1).Width = 150
    '        '.Columns(2).Width = 150
    '        '.Columns(3).Width = 150
    '        '.Columns(4).Width = 150
    '        '.Columns(4).Width = 150

    '        .Columns(0).ReadOnly = True
    '        .Columns(1).ReadOnly = True
    '        '.Columns(2).ReadOnly = True
    '        '.Columns(3).ReadOnly = True
    '    End With

    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If e.RowIndex >= 0 Then
            FindSuccess = True
            Me.Hide()
        End If
    End Sub

    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        Me.ComboBox1.SelectedIndex = DataGridView1.SortedColumn.Index
        Me.TextBox1.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If ComboBox1.SelectedIndex > -1 Then
            Dim strwhere As String
            If iwhere <> "" Then
                strwhere = iwhere & " and " & ComboBox1.Text & " Like '" & TextBox1.Text & "%'"
            Else
                strwhere = " where " & ComboBox1.Text & " Like '" & TextBox1.Text & "%'"
            End If
            Call LoadGrid(SourceCommand & strwhere & orderby, SourceCn)
        End If
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        FindSuccess = True
        Me.Hide()
    End Sub

    Private Sub Frm_FindRecord_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        CheckKey(e)
    End Sub

    Private Sub Frm_FindRecord_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        FindSuccess = False
        RowRetrn = Nothing
        'Call finding()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class