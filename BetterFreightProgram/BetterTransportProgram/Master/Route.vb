Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices
Imports System.Text

Public Class Route
    Public _IsNew as Boolean
    Public _ten as Boolean
    Public _ten1 as Boolean
    Private Sub Route_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        Userauthorize(UserProfile.U_Code, "ROUTE")
        If Userauthen.IsOpenMenu = 1 Then
            LoadDataToDgv()
            addNewData()
        Else
            MetroFramework.MetroMessageBox.Show(Me, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
    End Sub

    Private Sub GroupBox5_Enter(sender as Object, e as Eventargs) Handles GroupBox5.Enter

    End Sub

    Private Sub Save_Click(sender as Object, e as Eventargs) Handles Save.Click
        txtRouteName.Text = txtFactoryName.Text
        If _IsNew Then
            SaveRoute(1)
        Else
            SaveRoute(0)
        End If
    End Sub
    Private Sub addNewData()
        txtIdent.Text = "0" 'Ident
        txtPickupName.ResetText() 'PickupName
        txtPickupaddress.ResetText() 'Pickupaddress
        txtPickupContact.Text = "0" 'PickupContact
        txtBTTName.ResetText() 'BTTName
        txtBTTaddress.ResetText() 'BTTaddress
        txtBTTContact.Text = "0" 'BTTContact
        txtReturnName.ResetText() 'ReturnName
        txtReturnaddress.ResetText() 'Returnaddress
        txtReturnContact.Text = "0" 'ReturnContact
        txtFactoryName.ResetText() 'FactoryName
        txtFactoryaddress.ResetText() 'Factoryaddress
        txtFactoryContact.Text = "0" 'FactoryContact
        txtRouteLength.Text = "0.00" 'RouteLength
        txtFuelCost.Text = "0.00" 'FuelCost
        txtRoutePrice.Text = "0.00" 'RoutePrice
        txtFuelType.ResetText() 'FuelType
        txtBTTDistance.Text = "0.00"
        txtReturnDistance.Text = "0.00"
        txtPickupDistance.Text = "0.00"
        txtDeliveryDistance.Text = "0.00"
        ShortPrice.Text = "0.00"
        LongPrice.Text = "0.00"
        DriverFeeShort.Text = "0.00"
        DriverFeeLong.Text = "0.00"
        _IsNew = True
        _ten = True
        _ten1 = True
    End Sub
    Private Sub SaveRoute(_Insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateMas_Route ")
            SQLcommand.append("'" & CInt(txtIdent.Text) & "'") 'Ident
            SQLcommand.append(",'" & txtPickupName.Text & "'") 'PickupName
            SQLcommand.append(",'" & txtPickupaddress.Text & "'") 'Pickupaddress
            SQLcommand.append(",'" & txtPickupContact.Text & "'") 'PickupContact
            SQLcommand.append(",'" & txtBTTName.Text & "'") 'BTTName
            SQLcommand.append(",'" & txtBTTaddress.Text & "'") 'BTTaddress
            SQLcommand.append(",'" & txtBTTContact.Text & "'") 'BTTContact
            SQLcommand.append(",'" & txtReturnName.Text & "'") 'ReturnName
            SQLcommand.append(",'" & txtReturnaddress.Text & "'") 'Returnaddress
            SQLcommand.append(",'" & txtReturnContact.Text & "'") 'ReturnContact
            SQLcommand.append(",'" & txtFactoryName.Text & "'") 'FactoryName
            SQLcommand.append(",'" & txtFactoryaddress.Text & "'") 'Factoryaddress
            SQLcommand.append(",'" & txtFactoryContact.Text & "'") 'FactoryContact
            SQLcommand.append(",'" & CDbl(txtRouteLength.Text) & "'") 'RouteLength
            SQLcommand.append(",'" & CDbl(txtFuelCost.Text) & "'") 'FuelCost
            SQLcommand.append(",'" & CDbl(txtRoutePrice.Text) & "'") 'RoutePrice
            SQLcommand.append(",'" & txtFuelType.Text & "'") 'FuelType
            SQLcommand.append(",'" & txtBTTDistance.Text & "'")
            SQLcommand.append(",'" & txtPickupDistance.Text & "'")
            SQLcommand.append(",'" & txtDeliveryDistance.Text & "'")
            SQLcommand.append(",'" & txtReturnDistance.Text & "'")
            SQLcommand.append(",'" & ShortPrice.Text & "'")
            SQLcommand.append(",'" & LongPrice.Text & "'")
            SQLcommand.append(",'" & DriverFeeShort.Text & "'")
            SQLcommand.append(",'" & DriverFeeLong.Text & "'")
            SQLcommand.append(",'" & txtRouteName.Text & "'")
            SQLcommand.append(",'" & _Insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToDgv()
                _IsNew = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        txtRoutePrice.Text = (CDbl(txtRouteLength.Text) * CDbl(txtFuelCost.Text)).ToString("#,##0.00")
    End Sub

    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [VendorName]
      ,[Vendoraddress]
      ,[VendorPhone]
      FROM [Mas_VendorTransport] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtBTTName.Text = dr("VendorName").ToString
            txtBTTaddress.Text = dr("Vendoraddress").ToString
            txtBTTContact.Text = dr("VendorPhone").ToString
        End If
    End Sub

    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [PickupName]
      ,[Pickupaddress]
      ,[PickupContact]
      FROM [Mas_Pickup] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPickupName.Text = dr("PickupName").ToString
            txtPickupaddress.Text = dr("Pickupaddress").ToString
            txtPickupContact.Text = dr("PickupContact").ToString
        End If
    End Sub

    Private Sub Button8_Click(sender as Object, e as Eventargs) Handles Button8.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [LoadingName]
      ,[Loadingaddress]
      ,[LoadingContact]
      FROM [Mas_Loading] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtFactoryName.Text = dr("LoadingName").ToString
            txtFactoryaddress.Text = dr("Loadingaddress").ToString
            txtFactoryContact.Text = dr("LoadingContact").ToString
        End If
    End Sub

    Private Sub Button9_Click(sender as Object, e as Eventargs) Handles Button9.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [ReturnName]
      ,[Returnaddress]
      ,[ReturnContact]
      FROM [Mas_Return] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtReturnName.Text = dr("ReturnName").ToString
            txtReturnaddress.Text = dr("Returnaddress").ToString
            txtReturnContact.Text = dr("ReturnContact").ToString
        End If
    End Sub
    Private Sub LoadDataToDgv()
        Try
            dgvRoute.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Mas_Route where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvRoute.Rows.add(CInt(dt.Rows(i)(0).ToString()), 'Ident
                    dt.Rows(i)(1).ToString(), 'PickupName
                    dt.Rows(i)(2).ToString(), 'Pickupaddress
                    dt.Rows(i)(3).ToString(), 'PickupContact
                    dt.Rows(i)(4).ToString(), 'BTTName
                    dt.Rows(i)(5).ToString(), 'BTTaddress
                    dt.Rows(i)(6).ToString(), 'BTTContact
                    dt.Rows(i)(7).ToString(), 'ReturnName
                    dt.Rows(i)(8).ToString(), 'Returnaddress
                    dt.Rows(i)(9).ToString(), 'ReturnContact
                    dt.Rows(i)(10).ToString(), 'FactoryName
                    dt.Rows(i)(11).ToString(), 'Factoryaddress
                    dt.Rows(i)(12).ToString(), 'FactoryContact
                    CDbl(dt.Rows(i)(13).ToString()), 'RouteLength
                    CDbl(dt.Rows(i)(14).ToString()), 'FuelCost
                    CDbl(dt.Rows(i)(15).ToString()), 'RoutePrice
                    dt.Rows(i)(16).ToString(),  'FuelType
                    dt.Rows(i)(17).ToString(), 'BTTDistance
                    dt.Rows(i)(18).ToString(), 'PickDistance
                    dt.Rows(i)(19).ToString(), 'DelDistance
                    dt.Rows(i)(20).ToString(), 'ReturnDistance
                    dt.Rows(i)(21).ToString(), 'Short
                    dt.Rows(i)(22).ToString(), 'Long
                    dt.Rows(i)(23).ToString(),
                    dt.Rows(i)(24).ToString(),
                    dt.Rows(i)(25).ToString
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

    Private Sub dgvRoute_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvRoute.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvRoute.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtIdent.Text = CInt(dgvRoute.CurrentRow.Cells(0).Value) 'Ident
                txtPickupName.Text = dgvRoute.CurrentRow.Cells(1).Value.ToString() 'PickupName
                txtPickupaddress.Text = dgvRoute.CurrentRow.Cells(2).Value.ToString() 'Pickupaddress
                txtPickupContact.Text = dgvRoute.CurrentRow.Cells(3).Value.ToString() 'PickupContact
                txtBTTName.Text = dgvRoute.CurrentRow.Cells(4).Value.ToString() 'BTTName
                txtBTTaddress.Text = dgvRoute.CurrentRow.Cells(5).Value.ToString() 'BTTaddress
                txtBTTContact.Text = dgvRoute.CurrentRow.Cells(6).Value.ToString() 'BTTContact
                txtReturnName.Text = dgvRoute.CurrentRow.Cells(7).Value.ToString() 'ReturnName
                txtReturnaddress.Text = dgvRoute.CurrentRow.Cells(8).Value.ToString() 'Returnaddress
                txtReturnContact.Text = dgvRoute.CurrentRow.Cells(9).Value.ToString() 'ReturnContact
                txtFactoryName.Text = dgvRoute.CurrentRow.Cells(10).Value.ToString() 'FactoryName
                txtFactoryaddress.Text = dgvRoute.CurrentRow.Cells(11).Value.ToString() 'Factoryaddress
                txtFactoryContact.Text = dgvRoute.CurrentRow.Cells(12).Value.ToString() 'FactoryContact
                txtRouteLength.Text = CDbl(dgvRoute.CurrentRow.Cells(13).Value).ToString() 'RouteLength
                txtFuelCost.Text = CDbl(dgvRoute.CurrentRow.Cells(14).Value).ToString() 'FuelCost
                txtRoutePrice.Text = CDbl(dgvRoute.CurrentRow.Cells(15).Value).ToString() 'RoutePrice
                txtFuelType.Text = dgvRoute.CurrentRow.Cells(16).Value.ToString() 'FuelType
                txtBTTDistance.Text = dgvRoute.CurrentRow.Cells(17).Value.ToString()
                txtPickupDistance.Text = dgvRoute.CurrentRow.Cells(18).Value.ToString()
                txtDeliveryDistance.Text = dgvRoute.CurrentRow.Cells(19).Value.ToString
                txtReturnDistance.Text = dgvRoute.CurrentRow.Cells(20).Value.ToString()
                ShortPrice.Text = dgvRoute.CurrentRow.Cells(21).Value.ToString()
                LongPrice.Text = dgvRoute.CurrentRow.Cells(22).Value.ToString()
                DriverFeeShort.Text = dgvRoute.CurrentRow.Cells(23).Value.ToString()
                DriverFeeLong.Text = dgvRoute.CurrentRow.Cells(24).Value.ToString()
                txtRouteName.Text = dgvRoute.CurrentRow.Cells(25).Value.ToString
                _IsNew = False
                _ten = False
                _ten1 = False
            End If
        Catch ex as Exception

        End Try
    End Sub

    Private Sub Button10_Click(sender as Object, e as Eventargs) Handles Button10.Click
        addNewData()
    End Sub

    Private Sub Button11_Click(sender as Object, e as Eventargs) Handles Button11.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT Ident,[RouteName],[PickupName]
      ,[Pickupaddress],[PickupContact],[BTTName],[BTTaddress]
      ,[BTTContact],[ReturnName],[Returnaddress],[ReturnContact]
      ,[FactoryName],[Factoryaddress],[FactoryContact]
      ,[RouteLength],[FuelCost],[RoutePrice],[FuelType],[BTTDistance],[PickupDistance],[DeliveryDistance],[ReturnDistance],[ShortPrice],[LongPrice],DriverFeeShort,DriverFeeLong
      FROM [Mas_Route] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPickupName.Text = dr("PickupName").ToString
            txtPickupaddress.Text = dr("Pickupaddress").ToString
            txtPickupContact.Text = dr("PickupContact").ToString
            txtBTTName.Text = dr("BTTName").ToString
            txtBTTaddress.Text = dr("BTTaddress").ToString
            txtBTTContact.Text = dr("BTTContact").ToString
            txtReturnName.Text = dr("ReturnName").ToString
            txtReturnaddress.Text = dr("Returnaddress").ToString
            txtReturnContact.Text = dr("ReturnContact").ToString
            txtFactoryName.Text = dr("FactoryName").ToString
            txtFactoryaddress.Text = dr("Factoryaddress").ToString
            txtFactoryContact.Text = dr("FactoryContact").ToString
            txtRouteLength.Text = dr("RouteLength").ToString
            txtFuelCost.Text = dr("FuelCost").ToString
            txtRoutePrice.Text = dr("RoutePrice").ToString
            txtFuelType.Text = dr("FuelType").ToString
            txtBTTDistance.Text = dr("BTTDistance").ToString
            txtPickupDistance.Text = dr("PickupDistance").ToString
            txtDeliveryDistance.Text = dr("DeliveryDistance").ToString
            txtReturnDistance.Text = dr("ReturnDistance").ToString
            ShortPrice.Text = dr("ShortPrice").ToString
            LongPrice.Text = dr("LongPrice").ToString
            DriverFeeShort.Text = dr("DriverFeeShort").ToString
            DriverFeeLong.Text = dr("DriverFeeLong").ToString
            txtRouteName.Text = dr("RouteName").ToString
            txtIdent.Text = dr("Ident").ToString
            _IsNew = False
            _ten = False
            _ten1 = False
        End If
    End Sub

    Private Sub Label24_Click(sender as Object, e as Eventargs) Handles Label24.Click

    End Sub

    Private Sub MetroTextBox2_Click(sender as Object, e as Eventargs) Handles DriverFeeShort.Click
        If _ten1 = True Then
            DriverFeeShort.Text = (CDbl(DriverFeeShort.Text) * "0.1")
        End If
        _ten1 = False
    End Sub
    Private Sub txtRouteLength_Click(sender as Object, e as Eventargs) Handles txtRouteLength.Click
        txtRouteLength.Text = (CDbl(txtBTTDistance.Text) + CDbl(txtPickupDistance.Text) + CDbl(txtDeliveryDistance.Text) + CDbl(txtReturnDistance.Text)).ToString("#,##0.00")
    End Sub

    Private Sub ShortPrice_TextChanged(sender as Object, e as Eventargs) Handles ShortPrice.TextChanged
        DriverFeeShort.Text = ShortPrice.Text
    End Sub

    Private Sub LongPrice_TextChanged(sender as Object, e as Eventargs) Handles LongPrice.TextChanged
        DriverFeeLong.Text = LongPrice.Text
    End Sub

    Private Sub DriverFeeLong_Click(sender as Object, e as Eventargs) Handles DriverFeeLong.Click
        If _ten = True Then
            DriverFeeLong.Text = (CDbl(DriverFeeLong.Text) * "0.1")
        End If
        _ten = False
    End Sub

    Private Sub txtFactoryName_TextChanged(sender as Object, e as Eventargs) Handles txtFactoryName.TextChanged
        txtRouteName.Text = txtFactoryName.Text
    End Sub

    'Private Sub txtPickupDistance_TextChanged(sender as Object, e as Eventargs) Handles txtPickupDistance.TextChanged
    '    txtRouteLength.Text = (CDbl(txtBTTDistance.Text) + CDbl(txtPickupDistance.Text) + CDbl(txtDeliveryDistance.Text) + CDbl(txtReturnDistance.Text)).ToString("#,##0.00")
    'End Sub

    'Private Sub txtDeliveryDistance_TextChanged(sender as Object, e as Eventargs) Handles txtDeliveryDistance.TextChanged
    '    txtRouteLength.Text = (CDbl(txtBTTDistance.Text) + CDbl(txtPickupDistance.Text) + CDbl(txtDeliveryDistance.Text) + CDbl(txtReturnDistance.Text)).ToString("#,##0.00")
    'End Sub

    'Private Sub txtReturnDistance_TextChanged(sender as Object, e as Eventargs) Handles txtReturnDistance.TextChanged
    '    txtRouteLength.Text = (CDbl(txtBTTDistance.Text) + CDbl(txtPickupDistance.Text) + CDbl(txtDeliveryDistance.Text) + CDbl(txtReturnDistance.Text)).ToString("#,##0.00")
    'End Sub
End Class