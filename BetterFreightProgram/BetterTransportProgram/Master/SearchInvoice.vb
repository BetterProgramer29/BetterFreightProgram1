Imports System.Data.OleDb

Public Class SearchInvoice
    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [JobNo]
      ,[Customer]
      ,[CustomerContact]
      ,[CustomerRef]
      ,[Factory]
      ,[FactoryContact]
      ,[Vesselagent]
      ,[VesselBooking]
      ,[BLNo]
      ,[PickDate]
      ,[PickLocation]
      ,[PickContact]
      ,[LoadDate]
      ,[LoadLocation]
      ,[LoadContact]
      ,[ReturnDate]
      ,[ReturnLocation]
      ,[ReturnContact]
      ,[CloseDate]
      ,[FactoryRule]
      ,[Volume]
      ,[Product]
      ,[Net]
      ,[Gross]
      ,[TaxInv]
      ,[Price]
      ,[Total]
      ,[RoutePrice]
      ,[BTTDate]
      ,[BTTLocation]
      ,[BTTContact]
      ,[BTTTime]
      ,[PickupTime]
      ,[LoadingTime]
      ,[ReturnTime]
      ,[ClosingTime]
      ,[BTTDistance]
      ,[PickupDistance]
      ,[LoadDistance]
      ,[ReturnDistance]
      ,[ContainerType] FROM [addTransport] WHERE 1=1 order by JobNo ", MainConnection)
        If isSearchOK Then
            Invoice._IsNew = False
            Invoice.txtJobNo.Text = dr("JobNo").ToString
            Invoice.Show()
        End If
    End Sub
End Class
'Private Sub SearchInvoice_Load(sender as Object, e as Eventargs) Handles MyBase.Load
'End Sub
'Private Sub txtSearchBooking_ButtonClick(sender as Object, e as Eventargs) Handles txtsearchinvoice.ButtonClick
'    Try
'        dgvRV.Rows.Clear()
'        Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
'        Dim dt as DataTable = New DataTable()
'        Dim nection as New OleDb.OleDbConnection()
'        nection = ConnectDB()
'        Dim str as String = "SELECT * FROM Invoice where InvoiceNo='" & txtSearchInvoice.Text & "'"
'        da.SelectCommand = New OleDbCommand(str, nection)
'        da.Fill(dt)
'        If dt.Rows.Count > 0 Then
'            For i as Integer = 0 To dt.Rows.Count - 1
'                dgvRV.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
'                dt.Rows(i)(1).ToString(), 'JobNo
'                dt.Rows(i)(2).ToString(), 'VesselBooking
'                dt.Rows(i)(3).ToString(), 'BLNo
'                dt.Rows(i)(4).ToString(), 'Customer
'                dt.Rows(i)(5).ToString(), 'Customeraddress
'                dt.Rows(i)(6).ToString(), 'Factory
'                dt.Rows(i)(7).ToString(), 'BTTLocation
'                dt.Rows(i)(8).ToString(), 'PickupLocation
'                dt.Rows(i)(9).ToString(), 'LoadingLocation
'                dt.Rows(i)(10).ToString(), 'ReturnLocation
'                dt.Rows(i)(11).ToString(), 'Totalamount
'                dt.Rows(i)(12).ToString(), 'InvoiceNo
'                dt.Rows(i)(13).ToString(), 'TaX
'                dt.Rows(i)(14).ToString(), 'VaT
'                dt.Rows(i)(15).ToString()  'InvoiceStatus
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

'Private Sub txtSearchCustomer_ButtonClick(sender as Object, e as Eventargs) Handles txtSearchCustomer.ButtonClick
'    Try
'        dgvRV.Rows.Clear()
'        Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
'        Dim dt as DataTable = New DataTable()
'        Dim nection as New OleDb.OleDbConnection()
'        nection = ConnectDB()
'        Dim str as String = "SELECT * FROM Invoice where Customer='" & txtSearchCustomer.Text & "'"
'        da.SelectCommand = New OleDbCommand(str, nection)

'        da.Fill(dt)
'        If dt.Rows.Count > 0 Then
'            For i as Integer = 0 To dt.Rows.Count - 1
'                dgvRV.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
'                dt.Rows(i)(1).ToString(), 'JobNo
'                dt.Rows(i)(2).ToString(), 'VesselBooking
'                dt.Rows(i)(3).ToString(), 'BLNo
'                dt.Rows(i)(4).ToString(), 'Customer
'                dt.Rows(i)(5).ToString(), 'Customeraddress
'                dt.Rows(i)(6).ToString(), 'Factory
'                dt.Rows(i)(7).ToString(), 'BTTLocation
'                dt.Rows(i)(8).ToString(), 'PickupLocation
'                dt.Rows(i)(9).ToString(), 'LoadingLocation
'                dt.Rows(i)(10).ToString(), 'ReturnLocation
'                dt.Rows(i)(11).ToString(), 'Totalamount
'                dt.Rows(i)(12).ToString(), 'InvoiceNo
'                dt.Rows(i)(13).ToString(), 'TaX
'                dt.Rows(i)(14).ToString(), 'VaT
'                dt.Rows(i)(15).ToString()  'InvoiceStatus
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