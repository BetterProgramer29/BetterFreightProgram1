Imports System.Collections.ObjectModel
Imports System.Data.OleDb

Public Class frmSelectEngine
    Public SourceCommand as String
    Dim orderby as String = ""
    Dim SourceCn as OleDb.OleDbConnection
    Public FindSuccess as Boolean
    Public RowReturn as DataRowView
    Public indxCol as New Collection(Of Integer)()
    Public _lDT as DataTable
    Public frmtype as String = ""
    Public CMPCode as String = CMPProfile.PROF_Code
    Public BrCode as String = CMPProfile.PROF_BrCode
    Private Sub frmSelectEngine_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        txtFindRecord.ResetText()
        Me.activeControl = txtFindRecord
        FindSuccess = False
        ' // LoadCbSelectadvType(this.cbSelectadvType);
        'cbSelectadvType.SelectedValue = -99;

        ' chkSelectall.Checked = True
        _lDT = New DataTable()
        _lDT.Columns.add("Code")
        _lDT.Columns.add("SDescript")
        _lDT.Columns.add("Cost")
        _lDT.Columns.add("Price")
        _lDT.Columns.add("amt")
        _lDT.Columns.add("Currency")
        _lDT.Columns.add("CostBuy")
        _lDT.Columns.add("CostSell")
        _lDT.Columns.add("ProfitBuy")
        _lDT.Columns.add("ProfitSell")
        _lDT.Columns.add("Famt")
        _lDT.Columns.add("Isvat")
        _lDT.Columns.add("VatRate")
        _lDT.Columns.add("IncVat")
        _lDT.Columns.add("IsTax")
        _lDT.Columns.add("TaxRate")
        _lDT.Columns.add("IncTax")
        _lDT.Columns.add("active")
        _lDT.Columns.add("Insert")

    End Sub


    Private Sub txtFindRecord_TextChanged(sender as Object, e as Eventargs) Handles txtFindRecord.TextChanged
        Try
            If cbSelectField.Text <> "" Or cbSelectField.SelectedIndex > 0 Then
                Dim SQLCommand as String = SourceCommand
                Dim strWhere as String = " and " & cbSelectField.Text & " LIKE'%" & txtFindRecord.Text & "%' "
                Dim indexOrderBy as Integer = SQLCommand.IndexOf("ORDER BY")
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
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " + ex.Message, " " + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub chkSelectall_CheckStateChanged(sender as Object, e as Eventargs) Handles chkSelectall.CheckStateChanged
        If chkSelectall.Checked = True Then
            For Each litem as ListViewItem In lvService.Items
                litem.Checked = True
            Next
        Else
            For Each litem as ListViewItem In lvService.Items
                litem.Checked = False
            Next
        End If
    End Sub

    Private Sub btnaddItem_Click(sender as Object, e as Eventargs) Handles btnaddItem.Click
        Try
            For i as Integer = 0 To indxCol.Count - 1
                Dim row as DataRow = _lDT.NewRow
                row("Code") = lvService.Items(indxCol(i)).SubItems(0).Text
                row("SDescript") = lvService.Items(indxCol(i)).SubItems(1).Text
                row("Cost") = lvService.Items(indxCol(i)).SubItems(2).Text
                row("Price") = lvService.Items(indxCol(i)).SubItems(3).Text
                row("amt") = lvService.Items(indxCol(i)).SubItems(4).Text
                row("Currency") = lvService.Items(indxCol(i)).SubItems(5).Text
                row("CostBuy") = lvService.Items(indxCol(i)).SubItems(6).Text
                row("CostSell") = lvService.Items(indxCol(i)).SubItems(7).Text
                row("ProfitBuy") = lvService.Items(indxCol(i)).SubItems(8).Text
                row("ProfitSell") = lvService.Items(indxCol(i)).SubItems(9).Text
                row("Famt") = lvService.Items(indxCol(i)).SubItems(10).Text
                row("Isvat") = lvService.Items(indxCol(i)).SubItems(11).Text
                row("VatRate") = lvService.Items(indxCol(i)).SubItems(12).Text
                row("IncVat") = lvService.Items(indxCol(i)).SubItems(13).Text
                row("IsTax") = lvService.Items(indxCol(i)).SubItems(14).Text
                row("TaxRate") = lvService.Items(indxCol(i)).SubItems(15).Text
                row("IncTax") = lvService.Items(indxCol(i)).SubItems(16).Text
                row("active") = lvService.Items(indxCol(i)).SubItems(17).Text
                row("Insert") = lvService.Items(indxCol(i)).SubItems(18).Text

                _lDT.Rows.add(row)
            Next
            Me.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub btnRevItem_Click(sender as Object, e as Eventargs) Handles btnRevItem.Click
        Me.Close()
    End Sub

    Public Sub LoadGrid(SQLCommand as String, Cn as OleDbConnection)

        SourceCommand = SQLCommand.ToUpper()
        SourceCn = Cn
        ShowGrid(SourceCommand)
    End Sub
    Private Sub ShowGrid(SQLCommand as String, Optional ByVal Issearch as Boolean = False)
        Try
            If SourceCommand.IndexOf("ORDER BY".ToUpper) < 1 Then
                SourceCommand &= "ORDER BY 1"
            End If
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter(SQLCommand, SourceCn)
            Dim dt as DataTable = New DataTable
            da.Fill(dt)
            lvService.Items.Clear()
            Dim Inx as Integer = 0
            For Each dr as DataRow In dt.Rows
                Inx += 1
                Dim listItem as ListViewItem = New ListViewItem(dr("EXCode").ToString)
                listItem.SubItems.add(dr("EXName").ToString)
                listItem.SubItems.add(dr("EXCost").ToString)
                listItem.SubItems.add(dr("EXPrice").ToString)
                listItem.SubItems.add(dr("EXPrice").ToString)
                listItem.SubItems.add(dr("EXCurrency").ToString)
                listItem.SubItems.add("0")
                listItem.SubItems.add("0")
                listItem.SubItems.add("0")
                listItem.SubItems.add(dr("ExchangeRateProfitSell").ToString)
                listItem.SubItems.add("0")
                listItem.SubItems.add(dr("IsChargeVat").ToString)
                listItem.SubItems.add(dr("EXVatRate").ToString)
                listItem.SubItems.add("0")
                listItem.SubItems.add(dr("IsChargeTax").ToString)
                listItem.SubItems.add(dr("EXTaxRate").ToString)
                listItem.SubItems.add("0")
                listItem.SubItems.add("1")
                listItem.SubItems.add("1")
                lvService.Items.add(listItem)
                'listItem.SubItems.add(dr("").ToString)
            Next

            lblCount.Text = Inx.ToString()



            'If dgvFindRecord.DataSource IsNot Nothing Then
            '    If String.IsNullOrEmpty(HideColumn) = False Then
            '        For Each x In HideColumn.Split(",".ToChararray())
            '            dgvFindRecord.Columns(x).Visible = False
            '        Next
            '    End If
            'End If
            If Issearch = False Then
                cbSelectField.Items.Clear()
                For i as Integer = 0 To dt.Columns.Count - 1
                    cbSelectField.Items.add(dt.Columns(i).Caption)
                Next
                cbSelectField.SelectedIndex = 0
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " + ex.Message, " " + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        Me.txtFindRecord.Focus()
    End Sub

    Private Sub lvService_ItemCheck(sender as Object, e as ItemCheckEventargs) Handles lvService.ItemCheck
        Dim before as String = e.CurrentValue.ToString()
        Dim after as String = e.NewValue.ToString()
        If before = "Unchecked" and after = "Checked" Then
            indxCol.add(e.Index)
        ElseIf before = "Checked" and after = "Unchecked" Then
            indxCol.Remove(e.Index)
        End If


    End Sub
End Class