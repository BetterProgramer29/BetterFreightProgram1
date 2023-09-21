Imports System.Data.OleDb
Imports System.Net.Mime.MediaTypeNames
Imports System.Reflection.Emit
Imports System.Resources
Imports System.Text

Public Class addTransport
    Public _IsNew as Boolean = True

    Private Sub Button2_Click(sender as Object, e as Eventargs)

    End Sub
    Event DataGridView1ButtonClick(sender as DataGridView, e as DataGridViewCellEventargs)

    Private Sub DataGridView1_CellContentClick(sender as System.Object, e as DataGridViewCellEventargs) Handles dgvPrice.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn andalso e.RowIndex >= 0 Then
            RaiseEvent DataGridView1ButtonClick(senderGrid, e)
        End If
    End Sub

    Private Sub DataGridView1_ButtonClick(sender as DataGridView, e as DataGridViewCellEventargs) Handles Me.DataGridView1ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [accountGroup]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[ItemName]
      ,[SIGroup]  FROM [MaS_SICODE] WHERE SICode like 'S%'", MainConnection)
        If isSearchOK Then
            dgvPrice.CurrentRow.Cells(1).Value = dr("SICode").ToString
            dgvPrice.CurrentRow.Cells(3).Value = dr("ItemName").ToString
            dgvPrice.CurrentRow.Cells(12).Value = "1"

        End If
    End Sub
    Private Sub SearchSICode()

    End Sub
    Private Sub SaveDataToMain(_insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateaddTransport ")
            SQLcommand.append("'" & togident.Text & "'") 'ident
            SQLcommand.append(",'" & txtJobNo.Text & "'") 'JobNo
            SQLcommand.append(",'" & txtCustomer.Text & "'") 'Customer
            SQLcommand.append(",'" & txtCustomerContact.Text & "'") 'CustomerContact
            SQLcommand.append(",'" & txtCustomerRef.Text & "'") 'CustomerRef
            SQLcommand.append(",'" & txtFactory.Text & "'") 'Factory
            SQLcommand.append(",'" & txtFactoryContact.Text & "'") 'FactoryContact
            SQLcommand.append(",'" & txtVesselagent.Text & "'") 'Vesselagent
            SQLcommand.append(",'" & txtVesselBooking.Text & "'") 'VesselBooking
            SQLcommand.append(",'" & txtBLNo.Text & "'") 'BLNo
            SQLcommand.append(",'" & LetDate(txtPickDate.Value) & "'") 'PickDate
            SQLcommand.append(",'" & txtPickLocation.Text & "'") 'PickLocation
            SQLcommand.append(",'" & txtPickContact.Text & "'") 'PickContact
            SQLcommand.append(",'" & LetDate(txtLoadDate.Value) & "'") 'LoadDate
            SQLcommand.append(",'" & txtLoadLocation.Text & "'") 'LoadLocation
            SQLcommand.append(",'" & txtLoadContact.Text & "'") 'LoadContact
            SQLcommand.append(",'" & LetDate(txtReturnDate.Value) & "'") 'ReturnDate
            SQLcommand.append(",'" & txtReturnLocation.Text & "'") 'ReturnLocation
            SQLcommand.append(",'" & txtReturnContact.Text & "'") 'ReturnContact
            SQLcommand.append(",'" & LetDate(txtCloseDate.Value) & "'") 'CloseDate
            SQLcommand.append(",'" & txtFactoryRule.Text & "'") 'FactoryRule
            SQLcommand.append(",'" & txtVolume.Text & "'") 'Volume
            SQLcommand.append(",'" & txtProduct.Text & "'") 'Product
            SQLcommand.append(",'" & txtNet.Text & "'") 'Net
            SQLcommand.append(",'" & txtGross.Text & "'") 'Gross
            SQLcommand.append(",'" & txtTaxInv.Text & "'") 'TaxInv
            SQLcommand.append(",'" & txtPrice.Text & "'") 'Price
            SQLcommand.append(",'" & txtTotal.Text & "'") 'Total
            SQLcommand.append(",'" & CDbl(txtRoutePrice.Text) & "'") 'RoutePrice
            SQLcommand.append(",'" & ToDBDate(txtBTTDate.Text) & "'") 'BTTDate
            SQLcommand.append(",'" & txtBTTLocation.Text & "'") 'BTTLocation
            SQLcommand.append(",'" & txtBTTContact.Text & "'") 'BTTContact
            SQLcommand.append(",'" & txtBTTTime.Text & "'") 'BTTTime
            SQLcommand.append(",'" & txtPickupTime.Text & "'") 'PickupTime
            SQLcommand.append(",'" & txtLoadingTime.Text & "'") 'LoadingTime
            SQLcommand.append(",'" & txtReturnTime.Text & "'") 'ReturnTime
            SQLcommand.append(",'" & txtClosingTime.Text & "'") 'ClosingTime
            SQLcommand.append(",'" & CDbl(txtBTTDistance.Text) & "'") 'BTTDistance
            SQLcommand.append(",'" & CDbl(txtPickupDistance.Text) & "'") 'PickupDistance
            SQLcommand.append(",'" & CDbl(txtLoadDistance.Text) & "'") 'LoadDistance
            SQLcommand.append(",'" & CDbl(txtReturnDistance.Text) & "'") 'ReturnDistance
            SQLcommand.append(",'" & txtContainerType.Text & "'")
            SQLcommand.append(",'" & txtCustCode.Text & "'")
            SQLcommand.append(",'" & txtFactoryCode.Text & "'")
            SQLcommand.append(",'" & LetDate(dtpCreateDate.Value) & "'")
            SQLcommand.append(",'" & txtSysUser.Text & "'")
            SQLcommand.append(",'" & txtRemark.Text & "'")
            SQLcommand.append(",'" & txtFactoryRef.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub UpdateLog(DocType as String, actionType as String)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_UpdateLog ")
            SQLcommand.append("'" & togident.Text & "'") 'ident
            SQLcommand.append(",'" & UserProfile.U_FName & " " & UserProfile.U_LName & "'")
            SQLcommand.append(",'" & UserProfile.U_FName & " " & UserProfile.U_LName & "'")
            SQLcommand.append(",'" & UserProfile.U_FName & " " & UserProfile.U_LName & "'")
            SQLcommand.append(",'" & DocType & "'")
            SQLcommand.append(",'" & actionType & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Function CheckOldData() as Boolean
        Try
            Dim str as String = ""
            str = "SELECT VesselBooking FROM addTransport where JobNo='" & txtJobNo.Text & "' and VesselBooking='" & txtVesselBooking.Text & "'"
            Dim dr as DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return True
        End Try
    End Function
    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click

        If txtJobNo.Text = "" Then
            RunJobNo()
        End If
        If txtJobNo.Text = "ERROR" Then
            MsgBox("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้ กรุณารีสตาร์ทโปรแกรม")
            Exit Sub
        End If
        If CheckJob(txtJobNo.Text) Then
            MetroFramework.MetroMessageBox.Show(Me, "Duplicated Job number ", "Save Job", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If _IsNew Then
            If cboType.Text = "" Then
                MsgBox("Input Type First!!!")
                Exit Sub
            Else
                If CheckOldData() Then
                    MsgBox("Duplicate Booking")
                    Exit Sub
                Else
                    SaveDataToMain(1)
                    UpdateLog("addTransport", "Open")
                End If
            End If
        Else
            SaveDataToMain(0)
            UpdateLog("addTransport", "Edit")
        End If
    End Sub
    Private Sub txtCustomer_ButtonClick(sender as Object, e as Eventargs) Handles txtCustomer.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [CustTaxID]
      ,[CustCompanyID]
      ,[CustBranch]
      ,[CustCompanyName]
      ,[CustCountry]
      ,[CustCity]
      ,[Custaddress]
      ,[CustEmail]
      ,[CustPhone]
      ,[CustFax]
      ,[CustPayable]
      ,[CustFactory]
      ,[CustCustomer]  FROM [Mas_CustomerTransport] WHERE 1=1 order by [CustCompanyName] ", MainConnection)
        If isSearchOK Then
            txtCustomer.Text = dr("CustCompanyName").ToString
            txtCustomerContact.Text = dr("CustPhone").ToString
            txtCustCode.Text = dr("CustCompanyID").ToString
            txtFactory.Text = dr("CustCompanyName").ToString
            txtFactoryContact.Text = dr("CustPhone").ToString
            txtFactoryCode.Text = dr("CustCompanyID").ToString
        End If
    End Sub
    Private Sub txtVesselagent_ButtonClick(sender as Object, e as Eventargs) Handles txtVesselagent.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [VesselagentName], [VesselBooking]  FROM [Mas_Vesselagent] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtVesselagent.Text = dr("VesselagentName").ToString
            txtVesselBooking.Text = dr("VesselBooking").ToString
        End If
    End Sub
    Private Sub txtPickLocation_ButtonClick(sender as Object, e as Eventargs) Handles txtPickLocation.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [Pickupaddress], [PickupContact]  FROM [Mas_Pickup] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPickLocation.Text = dr("Pickupaddress").ToString
            txtPickContact.Text = dr("PickupContact").ToString
        End If
    End Sub
    Private Sub txtLoadLocation_ButtonClick(sender as Object, e as Eventargs) Handles txtLoadLocation.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [Loadingaddress], [LoadingContact]  FROM [Mas_Loading] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtLoadLocation.Text = dr("Loadingaddress").ToString
            txtLoadContact.Text = dr("LoadingContact").ToString
        End If
    End Sub
    Private Sub txtReturnLocation_ButtonClick(sender as Object, e as Eventargs) Handles txtReturnLocation.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [Returnaddress], [ReturnContact]  FROM [Mas_Return] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtReturnLocation.Text = dr("Returnaddress").ToString
            txtReturnContact.Text = dr("ReturnContact").ToString
        End If
    End Sub
    Private Sub txtFactory_ButtonClick(sender as Object, e as Eventargs) Handles txtFactory.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [CustTaxID]
        ,[CustCompanyID]
        ,[CustBranch]
        ,[CustCompanyName]
        ,[CustCountry]
        ,[CustCity]
        ,[Custaddress]
        ,[CustEmail]
        ,[CustPhone]
        ,[CustFax]
        ,[CustPayable]
        ,[CustFactory]
        ,[CustCustomer]  FROM [Mas_CustomerTransport] WHERE 1=1 order by [CustCompanyName] ", MainConnection)
        If isSearchOK Then
            txtFactory.Text = dr("CustCompanyName").ToString
            txtFactoryContact.Text = dr("CustPhone").ToString
            txtFactoryCode.Text = dr("CustCompanyID").ToString
        End If
    End Sub
    Private Sub RunJobNo()
        If cboType.Text = "Pickup Truck" Then
            GetRunningFormat("PT")
            txtJobNo.Text = CreateNumber("addTransport", "JobNo", txtPickDate.Value)
        End If
        If cboType.Text = "6-Wheel" Then
            GetRunningFormat("6W")
            txtJobNo.Text = CreateNumber("addTransport", "JobNo", txtPickDate.Value)
        End If
        If cboType.Text = "10-Wheel" Then
            GetRunningFormat("10W")
            txtJobNo.Text = CreateNumber("addTransport", "JobNo", txtPickDate.Value)
        End If
        If cboType.Text = "Trailer Head" Then
            GetRunningFormat("TR")
            txtJobNo.Text = CreateNumber("addTransport", "JobNo", txtPickDate.Value)
        End If
    End Sub
    'Private Sub Button2_Click_1(sender as Object, e as Eventargs) Handles Button2.Click
    '    txtTotal.Text = (CDbl(txtVolume.Text) * CDbl(txtPrice.Text)).ToString("#,##0.00")
    '    If cboType.Text = "Pickup Truck" Then
    '        GetRunningFormat("PT")
    '        txtJobNo.Text = CreateNumber("addTransport", "JobNo", txtPickDate.Value)
    '    End If
    '    If cboType.Text = "6-Wheel" Then
    '        GetRunningFormat("6W")
    '        txtJobNo.Text = CreateNumber("addTransport", "JobNo", txtPickDate.Value)
    '    End If
    '    If cboType.Text = "10-Wheel" Then
    '        GetRunningFormat("10W")
    '        txtJobNo.Text = CreateNumber("addTransport", "JobNo", txtPickDate.Value)
    '    End If
    '    If cboType.Text = "Trailer Head" Then
    '        GetRunningFormat("TR")
    '        txtJobNo.Text = CreateNumber("addTransport", "JobNo", txtPickDate.Value)
    '    End If
    'End Sub
    Private Sub addTransport_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        If _IsNew = True Then
            addNewJob()
        End If
        If txtSysUser.Text = "" Then
            txtSysUser.Text = UserProfile.U_FName & "  " & UserProfile.U_LName
        End If
        Userauthorize(UserProfile.U_Code, "OPJOB")
        If Userauthen.IsOpenMenu = 1 Then
            togident.Text = "0"
            UpdateStatus()
            LoadDataToadv()
            LoadDataToCost()
            LoadDataToaddTransport()
            LoadaddTransport()
            LoadPriceTodgv()
        Else
            MetroFramework.MetroMessageBox.Show(Me, "User Not authorized this menu!", "authority User", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
    End Sub
    Private Sub UpdateStatus()
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_UpdateJobStatus ")
            SQLcommand.append("'" & txtJobNo.Text & "'")
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub addNewJob()
        togident.Text = "0" 'ident
        txtJobNo.ResetText() 'JobNo
        txtCustomer.ResetText() 'Customer
        txtCustomerContact.ResetText() 'CustomerContact
        txtCustomerRef.ResetText() 'CustomerRef
        txtFactory.ResetText() 'Factory
        txtFactoryContact.ResetText() 'FactoryContact
        txtVesselagent.ResetText() 'Vesselagent
        txtVesselBooking.ResetText() 'VesselBooking
        txtBLNo.ResetText() 'BLNo
        txtPickDate.ResetText() 'PickDate
        txtPickLocation.ResetText() 'PickLocation
        txtPickContact.ResetText() 'PickContact
        txtLoadDate.ResetText() 'LoadDate
        txtLoadLocation.ResetText() 'LoadLocation
        txtLoadContact.ResetText() 'LoadContact
        txtReturnDate.ResetText() 'ReturnDate
        txtReturnLocation.ResetText() 'ReturnLocation
        txtReturnContact.ResetText() 'ReturnContact
        txtCloseDate.ResetText() 'CloseDate
        txtFactoryRule.ResetText() 'FactoryRule
        txtVolume.Text = "0" 'Volume
        txtProduct.ResetText() 'Product
        txtNet.ResetText() 'Net
        txtGross.ResetText() 'Gross
        txtTaxInv.ResetText() 'TaxInv
        txtPrice.ResetText() 'Price
        txtTotal.Text = "0" 'Total
        txtRoutePrice.ResetText() 'RoutePrice
        txtBTTDate.ResetText() 'BTTDate
        txtBTTLocation.ResetText() 'BTTLocation
        txtBTTContact.ResetText() 'BTTContact
        txtBTTTime.ResetText() 'BTTTime
        txtPickupTime.ResetText() 'PickupTime
        txtLoadingTime.ResetText() 'LoadingTime
        txtReturnTime.ResetText() 'ReturnTime
        txtClosingTime.ResetText() 'ClosingTime
        txtBTTDistance.Text = "0" 'BTTDistance
        txtPickupDistance.Text = "0" 'PickupDistance
        txtLoadDistance.Text = "0" 'LoadDistance
        txtReturnDistance.Text = "0" 'ReturnDistance
        txtContainerType.ResetText() 'ContainerType
        txtCustCode.ResetText()
        txtFactoryCode.ResetText()
        txtFactoryRef.ResetText()
        _IsNew = True
    End Sub
    Private Sub LoadaddTransport()
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT [Customer],[CustomerContact]
            ,[CustomerRef],[Factory],[FactoryContact],[Vesselagent],[VesselBooking],[BLNo],[PickDate]
            ,[PickLocation],[PickContact],[LoadDate],[LoadLocation],[LoadContact],[ReturnDate]
            ,[ReturnLocation],[ReturnContact],[CloseDate],[FactoryRule],[Volume],[Product],[Net]
            ,[Gross],[TaxInv],[Price],[Total],[RoutePrice],[BTTDate],[BTTLocation],[BTTContact]
            ,[BTTTime],[PickupTime],[LoadingTime],[ReturnTime],[ClosingTime],[BTTDistance]
            ,[PickupDistance],[LoadDistance],[ReturnDistance],[ContainerType],[ident],[CustCode],[FactoryCode]
            ,[CreateDate],SysUser,JobStatus,Remark,FactoryRef from [addTransport] where JobNo='" & txtJobNo.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                togident.Text = dr("ident").ToString
                txtCustomer.Text = dr("Customer").ToString
                txtCustomerContact.Text = dr("CustomerContact").ToString
                txtCustomerRef.Text = dr("CustomerRef").ToString
                txtFactory.Text = dr("Factory").ToString
                txtFactoryContact.Text = dr("FactoryContact").ToString
                txtVesselagent.Text = dr("Vesselagent").ToString
                txtVesselBooking.Text = dr("VesselBooking").ToString
                txtBooking.Text = dr("VesselBooking")
                txtBLNo.Text = dr("BLNo").ToString
                txtPickDate.Value = dr("PickDate").ToString
                txtPickLocation.Text = dr("PickLocation").ToString
                txtPickContact.Text = dr("PickContact").ToString
                txtLoadDate.Value = dr("LoadDate").ToString
                txtLoadLocation.Text = dr("LoadLocation").ToString
                txtLoadContact.Text = dr("LoadContact").ToString
                txtReturnDate.Value = dr("ReturnDate").ToString
                txtReturnLocation.Text = dr("ReturnLocation").ToString
                txtReturnContact.Text = dr("ReturnContact").ToString
                txtCloseDate.Value = dr("CloseDate").ToString
                txtFactoryRule.Text = dr("FactoryRule").ToString
                txtVolume.Text = dr("Volume").ToString
                txtProduct.Text = dr("Product").ToString
                txtNet.Text = dr("Net").ToString
                txtGross.Text = dr("Gross").ToString
                txtTaxInv.Text = dr("TaxInv").ToString
                txtPrice.Text = dr("Price").ToString
                txtTotal.Text = dr("Total").ToString
                txtRoutePrice.Text = dr("RoutePrice").ToString
                txtBTTLocation.Text = dr("BTTLocation").ToString
                txtBTTDate.Text = DBDate(dr("BTTDate").ToString)
                txtBTTTime.Text = dr("BTTTime").ToString
                txtPickupTime.Text = dr("PickupTime").ToString
                txtLoadingTime.Text = dr("LoadingTime").ToString
                txtReturnTime.Text = dr("ReturnTime").ToString
                txtBTTDistance.Text = dr("BTTDistance").ToString
                txtReturnDistance.Text = dr("ReturnDistance").ToString
                txtLoadDistance.Text = dr("LoadDistance").ToString
                txtPickupDistance.Text = dr("PickupDistance").ToString
                txtContainerType.Text = dr("ContainerType").ToString
                txtCustCode.Text = dr("CustCode").ToString
                txtFactoryCode.Text = dr("FactoryCode").ToString
                dtpCreateDate.Value = dr("CreateDate").ToString
                txtSysUser.Text = dr("SysUser").ToString
                txtStatus.Text = dr("JobStatus").ToString
                txtRemark.Text = dr("Remark").ToString
                txtFactoryRef.Text = dr("FactoryRef").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToaddTransport()
        'Dim dr as DataRow
        'dr = PopUpSearch("SELECT [JobNo],[Customer],[CustomerContact],[CustomerRef],[Factory]
        ',[FactoryContact],[Vesselagent],[VesselBooking],[BLNo],[PickDate],[PickLocation],[PickContact]
        ',[LoadDate],[LoadLocation],[LoadContact],[ReturnDate],[ReturnLocation],[ReturnContact],[CloseDate]
        ',[FactoryRule],[Volume],[Product],[Net],[Gross],[TaxInv],[Price],[Total],[RoutePrice]  FROM addTransport WHERE JobNo='" & txtJobNo.Text & "'", MainConnection)
        'If isSearchOK Then
        '    txtJobNo.Text = dr("JobNo").ToString
        '    txtCustomer.Text = dr("Customer").ToString
        '    txtCustomerContact.Text = dr("CustomerContact").ToString
        '    txtCustomerRef.Text = dr("CustomerRef").ToString
        '    txtFactory.Text = dr("Factory").ToString
        '    txtFactoryContact.Text = dr("FactoryContact").ToString
        '    txtVesselagent.Text = dr("Vesselagent").ToString
        '    txtVesselBooking.Text = dr("VesselBooking").ToString
        '    txtBooking.Text = dr("VesselBooking")
        '    txtBLNo.Text = dr("BLNo").ToString
        '    txtPickDate.Value = CDate(dr("PickDate").ToString)
        '    txtPickLocation.Text = dr("PickLocation").ToString
        '    txtPickContact.Text = dr("PickContact").ToString
        '    txtLoadDate.Value = dr("LoadDate").ToString
        '    txtLoadLocation.Text = dr("LoadLocation").ToString
        '    txtLoadContact.Text = dr("LoadContact").ToString
        '    txtReturnDate.Value = CDate(dr("ReturnDate").ToString)
        '    txtReturnLocation.Text = dr("ReturnLocation").ToString
        '    txtReturnContact.Text = dr("ReturnContact").ToString
        '    txtCloseDate.Value = (dr("CloseDate").ToString)
        '    txtFactoryRule.Text = dr("FactoryRule").ToString
        '    txtVolume.Text = dr("Volume").ToString
        '    txtProduct.Text = dr("Product").ToString
        '    txtNet.Text = dr("Net").ToString
        '    txtGross.Text = dr("Gross").ToString
        '    txtTaxInv.Text = dr("TaxInv").ToString
        '    txtPrice.Text = dr("Price").ToString
        '    txtTotal.Text = dr("Total").ToString
        '    txtRoutePrice.Text = dr("RoutePrice").ToString
        'End If
    End Sub
    Private Sub LoadDataToadv()
        Try
            dgvCostadv.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM adv where advType = 'aTK' and JobNo='" & txtJobNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvCostadv.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'advCode
                    dt.Rows(i)(2).ToString(), 'advDescription
                    dt.Rows(i)(3).ToString(), 'advType
                    dt.Rows(i)(4).ToString(), 'amount
                    dt.Rows(i)(5).ToString(), 'RecieptNo
                    dt.Rows(i)(6).ToString(), 'advDriver
                    dt.Rows(i)(7).ToString(), 'advContainerNo
                    dt.Rows(i)(8).ToString(), 'advStatus
                    dt.Rows(i)(9).ToString()  'OrderNo
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
    Private Sub LoadDataToCost()
        Try
            dgvCost.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM adv where advType = 'COST' and JobNo='" & txtJobNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvCost.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'advCode
                    dt.Rows(i)(2).ToString(), 'advDescription
                    dt.Rows(i)(3).ToString(), 'advType
                    dt.Rows(i)(4).ToString(), 'amount
                    dt.Rows(i)(5).ToString(), 'RecieptNo
                    dt.Rows(i)(6).ToString(), 'advDriver
                    dt.Rows(i)(7).ToString(), 'advContainerNo
                    dt.Rows(i)(8).ToString(), 'advStatus
                    dt.Rows(i)(9).ToString()  'OrderNo
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
    Private Sub GroupBox1_Enter(sender as Object, e as Eventargs) Handles GroupBox1.Enter

    End Sub
    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        Dim frm as New frmContainer
        frm.txtQty.Text = txtVolume.Text
        frm.txtJobNo.Text = txtJobNo.Text
        frm.txtarriveTruckYardDate.Text = txtPickDate.Text
        frm.txtarriveFactoryDate.Text = txtLoadDate.Text
        frm.txtReturnDate.Text = txtReturnDate.Text
        frm.txtBTTDistance.Text = txtBTTDistance.Text
        frm.txtPickupDistance.Text = txtPickupDistance.Text
        frm.txtReturnDistance.Text = txtReturnDistance.Text
        frm.txtLoadDistance.Text = txtLoadDistance.Text
        frm.txtBooking.Text = txtBooking.Text
        frm.MetroTextBox2.Text = txtPrice.Text
        frm.txtBTTLocation.Text = txtBTTLocation.Text
        frm.txtPickupLocation.Text = txtPickLocation.Text
        frm.txtReturnLocation.Text = txtReturnLocation.Text
        frm.txtLoadingLocation.Text = txtLoadLocation.Text
        frm.Show()

        'LoadRoute()
    End Sub
    Private Sub LoadRoute()
        frmContainer.txtBTTLocation.Text = txtBTTLocation.Text
        frmContainer.txtPickupLocation.Text = txtPickLocation.Text
        frmContainer.txtReturnLocation.Text = txtReturnLocation.Text
        frmContainer.txtLoadingLocation.Text = txtLoadLocation.Text
    End Sub
    Private Sub Button2_Click_1(sender as Object, e as Eventargs) Handles Button2.Click
        Route.ShowDialog()
        Route.txtBTTaddress.Text = txtBTTLocation.Text
    End Sub

    Private Sub VScrollBar1_Scroll(sender as Object, e as ScrollEventargs)

    End Sub

    Private Sub Button8_Click(sender as Object, e as Eventargs) Handles Button8.Click
        'If dgvPrice.CurrentRow.Cells(12).Value = "1" Then
        SavePrice()
        'Else
        '    SavePrice(0)
        'End If

    End Sub
    Private Sub LoadPriceTodgv()
        Try
            dgvPrice.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Price where JobNo='" & txtJobNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvPrice.Rows.add(dt.Rows(i)(0).ToString(), 'Ident 0
                    dt.Rows(i)(1).ToString(), 'SICode 1
                    "", '2
                    dt.Rows(i)(2).ToString(), 'PriceDescription 3
                    dt.Rows(i)(3).ToString(), 'ContainerNo 4
                    dt.Rows(i)(4).ToString(), 'Qty 5
                    dt.Rows(i)(5).ToString(), 'Unit 6
                    dt.Rows(i)(6).ToString(), 'Totalamount 7
                    dt.Rows(i)(7).ToString(), 'Status 8
                    dt.Rows(i)(8).ToString(), 'WHT 9
                    dt.Rows(i)(9).ToString(),  'ReceiptNo 10
                    dt.Rows(i)(10).ToString(),  'JobNo 11
                    "0", 'Isnew Detail 12
                    dt.Rows(i)(11).ToString(),
                    "",
                    "",
                    dt.Rows(i)(18).ToString
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
    Private Sub SavePrice()
        Try
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a as Integer = 0
            For row as Integer = 0 To dgvPrice.Rows.Count - 2
                Try
                    'MsgBox(",'" & dgvCostadv.Rows(row).Cells(1).Value.ToString & "'")
                    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdatePrice ")
                    SQLcommand.append("'" & CInt(dgvPrice.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.append(",'" & dgvPrice.Rows(row).Cells(1).Value.ToString & "'") 'SICode
                    'SQLcommand.append(",'" & dgvPrice.Rows(row).Cells(2).Value.ToString & "'")
                    SQLcommand.append(",'" & dgvPrice.Rows(row).Cells(3).Value.ToString & "'") 'PriceDescription
                    SQLcommand.append(",'" & dgvPrice.Rows(row).Cells(4).Value.ToString & "'") 'ContainerNo
                    SQLcommand.append(",'" & CDbl(dgvPrice.Rows(row).Cells(5).Value) & "'") 'Qty
                    SQLcommand.append(",'" & CDbl(dgvPrice.Rows(row).Cells(6).Value) & "'") 'Unit
                    SQLcommand.append(",'" & CDbl(dgvPrice.Rows(row).Cells(7).Value) & "'") 'Totalamount
                    SQLcommand.append(",'" & dgvPrice.Rows(row).Cells(8).Value.ToString & "'") 'Status
                    SQLcommand.append(",'" & CDbl(dgvPrice.Rows(row).Cells(9).Value) & "'") 'WHT
                    SQLcommand.append(",'" & dgvPrice.Rows(row).Cells(10).Value.ToString & "'") 'ReceiptNo
                    SQLcommand.append(",'" & txtJobNo.Text & "'") 'JobNo
                    SQLcommand.append(",'" & dgvPrice.Rows(row).Cells(15).Value & "'")
                    SQLcommand.append(",'" & txtSysUser.Text & "'")
                    SQLcommand.append(",'" & CInt(dgvPrice.Rows(row).Cells(16).Value) & "'")
                    SQLcommand.append(",'" & CInt(dgvPrice.Rows(row).Cells(12).Value) & "'") 'IsNew
                    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                    Else
                        a += 1
                        'If dgvCostadv.Rows(row).Cells(2).Value IsNot Nothing Then
                        '    str &= dgvCostadv.Rows(row).Cells(2).Value.ToString & vbCrLf
                        'End If
                        'MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail " & vbCrLf & str, "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                Catch ex as Exception
                    a += 1
                    'str &= dgvCostadv.Rows(row).Cells(2).Value.ToString & vbCrLf
                    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try
            Next
            nection.Close()
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPriceTodgv()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button9_Click(sender as Object, e as Eventargs) Handles Button9.Click
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
      ,[ReturnDistance],[ContainerType],[ident],[CustCode]
      ,[FactoryCode]
      ,[CreateDate],SysUser,Remark,FactoryRef  FROM addTransport WHERE 1=1", MainConnection)
        If isSearchOK Then
            togident.Text = dr("ident").ToString
            txtJobNo.Text = dr("JobNo").ToString
            txtCustomer.Text = dr("Customer").ToString
            txtCustomerContact.Text = dr("CustomerContact").ToString
            txtCustomerRef.Text = dr("CustomerRef").ToString
            txtFactory.Text = dr("Factory").ToString
            txtFactoryContact.Text = dr("FactoryContact").ToString
            txtVesselagent.Text = dr("Vesselagent").ToString
            txtVesselBooking.Text = dr("VesselBooking").ToString
            txtBooking.Text = dr("VesselBooking")
            txtBLNo.Text = dr("BLNo").ToString
            txtPickDate.Value = dr("PickDate").ToString
            txtPickLocation.Text = dr("PickLocation").ToString
            txtPickContact.Text = dr("PickContact").ToString
            txtLoadDate.Value = dr("LoadDate").ToString
            txtLoadLocation.Text = dr("LoadLocation").ToString
            txtLoadContact.Text = dr("LoadContact").ToString
            txtReturnDate.Value = dr("ReturnDate").ToString
            txtReturnLocation.Text = dr("ReturnLocation").ToString
            txtReturnContact.Text = dr("ReturnContact").ToString
            txtCloseDate.Value = dr("CloseDate").ToString
            txtFactoryRule.Text = dr("FactoryRule").ToString
            txtVolume.Text = dr("Volume").ToString
            txtProduct.Text = dr("Product").ToString
            txtNet.Text = dr("Net").ToString
            txtGross.Text = dr("Gross").ToString
            txtTaxInv.Text = dr("TaxInv").ToString
            txtPrice.Text = dr("Price").ToString
            txtTotal.Text = dr("Total").ToString
            txtRoutePrice.Text = dr("RoutePrice").ToString
            txtBTTLocation.Text = dr("BTTLocation").ToString
            txtBTTDate.Text = DBDate(dr("BTTDate").ToString)
            txtBTTTime.Text = dr("BTTTime").ToString
            txtPickupTime.Text = dr("PickupTime").ToString
            txtLoadingTime.Text = dr("LoadingTime").ToString
            txtReturnTime.Text = dr("ReturnTime").ToString
            txtBTTDistance.Text = dr("BTTDistance").ToString
            txtReturnDistance.Text = dr("ReturnDistance").ToString
            txtLoadDistance.Text = dr("LoadDistance").ToString
            txtPickupDistance.Text = dr("PickupDistance").ToString
            txtContainerType.Text = dr("ContainerType").ToString
            txtCustCode.Text = dr("CustCode").ToString
            txtFactoryCode.Text = dr("FactoryCode").ToString
            dtpCreateDate.Value = dr("CreateDate").ToString
            txtSysUser.Text = dr("SysUser").ToString
            txtRemark.Text = dr("Remark").ToString
            txtFactoryRef.Text = dr("FactoryRef").ToString
            _IsNew = False
            LoadPriceTodgv()
        End If
    End Sub
    Private Sub MetroButton1_Click(sender as Object, e as Eventargs) Handles MetroButton1.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [RouteName],[PickupName]
        ,[Pickupaddress],[PickupContact],[BTTName],[BTTaddress]
        ,[BTTContact],[ReturnName],[Returnaddress],[ReturnContact]
        ,[FactoryName],[Factoryaddress],[FactoryContact]
        ,[RouteLength],[FuelCost],[RoutePrice],[FuelType],[BTTDistance]
        ,[PickupDistance],[DeliveryDistance],[ReturnDistance],[ShortPrice]
        ,[LongPrice]
        FROM [Mas_Route] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPickLocation.Text = dr("Pickupaddress").ToString
            txtPickContact.Text = dr("PickupContact").ToString
            txtBTTLocation.Text = dr("BTTaddress").ToString
            txtBTTContact.Text = dr("BTTContact").ToString
            txtReturnLocation.Text = dr("Returnaddress").ToString
            txtReturnContact.Text = dr("ReturnContact").ToString
            txtLoadLocation.Text = dr("Factoryaddress").ToString
            txtLoadContact.Text = dr("FactoryContact").ToString
            txtRoutePrice.Text = dr("RouteLength").ToString
            txtBTTDistance.Text = dr("BTTDistance").ToString
            txtPickupDistance.Text = dr("PickupDistance").ToString
            txtLoadDistance.Text = dr("DeliveryDistance").ToString
            txtReturnDistance.Text = dr("ReturnDistance").ToString
            LongPrice.Text = dr("LongPrice").ToString
            ShortPrice.Text = dr("ShortPrice").ToString
        End If
    End Sub
    Private Sub Button10_Click(sender as Object, e as Eventargs) Handles Button10.Click
        addNewJob()
    End Sub
    Private Sub txtTaxInv_ButtonClick(sender as Object, e as Eventargs) Handles txtTaxInv.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [CustTaxID]
      ,[CustCompanyID]
      ,[CustBranch]
      ,[CustCompanyName]
      ,[CustCountry]
      ,[CustCity]
      ,[Custaddress]
      ,[CustEmail]
      ,[CustPhone]
      ,[CustFax]
      ,[CustPayable]
      ,[CustFactory]
      ,[CustCustomer]  FROM [Mas_CustomerTransport] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtTaxInv.Text = dr("CustTaxID").ToString & dr("CustCompanyName").ToString & dr("Custaddress").ToString
        End If
    End Sub
    Private Sub MetroTextBox1_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox1.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [CustTaxID]
      ,[CustCompanyID]
      ,[CustBranch]
      ,[CustCompanyName]
      ,[CustCountry]
      ,[CustCity]
      ,[Custaddress]
      ,[CustEmail]
      ,[CustPhone]
      ,[CustFax]
      ,[CustPayable] 
      ,[CustFactory]
      ,[CustCustomer]  FROM [Mas_CustomerTransport] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtTaxInv.Text = "เลขประจำตัวผู้เสียภาษี " & dr("CustTaxID").ToString & " สาขา " & dr("CustBranch").ToString & vbCrLf & dr("CustCompanyName").ToString & vbCrLf & dr("Custaddress").ToString
        End If
    End Sub
    Private Sub txtTotal_Click(sender as Object, e as Eventargs) Handles txtTotal.Click
        txtTotal.Text = (CInt(txtVolume.Text) * CInt(txtPrice.Text))
    End Sub
    Private Sub dgvPrice_Rowsadded(sender as Object, e as DataGridViewRowsaddedEventargs) Handles dgvPrice.Rowsadded
        Try
            Dim CBCell as New DataGridViewComboBoxCell()
            CBCell = dgvPrice.Rows(e.RowIndex).Cells(8)
            CBCell.Items.add("รอแจ้งงานรถ")
            CBCell.Items.add("กำลังทำงาน")
            CBCell.Items.add("รอแจ้งหนี้")
            CBCell.Items.add("ออกใบเสร็จแล้ว")
            CBCell.Items.add("ค้างชำระเกินดิว")
            CBCell.Items.add("ชำระมาแค่บางส่วน")
            Dim UnitCell as New DataGridViewComboBoxCell()
            UnitCell = dgvPrice.Rows(e.RowIndex).Cells(15)
            UnitCell.Items.add("20 GP")
            UnitCell.Items.add("40 GP")
            UnitCell.Items.add("40 HC")
            UnitCell.Items.add("45 HC")
            UnitCell.Items.add("ISO Tank 20")
            UnitCell.Items.add("ISO Tank 40")
            UnitCell.Items.add("6-Wheel")
            UnitCell.Items.add("10-Wheel")
            UnitCell.Items.add("Pickup Truck")
            dgvPrice.Rows(e.RowIndex).Cells(16).Value = "1" 'Isnew
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub dgvPrice_DataError(sender as Object, e as DataGridViewDataErrorEventargs) Handles dgvPrice.DataError
        MetroFramework.MetroMessageBox.Show(Me, "Error ", "dgvPrice", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub
    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        Dim frm as New Invoice
        frm.txtJobNo.Text = txtJobNo.Text
        frm.txtVesselBooking.Text = txtVesselBooking.Text
        frm.txtBLNo.Text = txtBLNo.Text
        frm.txtCustCode.Text = txtCustCode.Text
        frm.txtCustomer.Text = txtCustomer.Text
        frm.txtBTTLocation.Text = txtBTTLocation.Text
        frm.txtPickupLocation.Text = txtPickLocation.Text
        frm.txtLoadingLocation.Text = txtLoadLocation.Text
        frm.txtReturnLocation.Text = txtReturnLocation.Text
        frm.ShowDialog()
    End Sub
    Private Sub dgvPrice_CellEndEdit(sender as Object, e as DataGridViewCellEventargs) Handles dgvPrice.CellEndEdit
        dgvPrice.CurrentRow.Cells(7).Value = (dgvPrice.CurrentRow.Cells(5).Value * dgvPrice.CurrentRow.Cells(6).Value)
        'If dgvPrice.CurrentRow.IsNewRow Then
        '    dgvPrice.Rows(e.RowIndex).Cells(12).Value = "1"
        'Else
        '    dgvPrice.Rows(e.RowIndex).Cells(12).Value = "1"
        'End If
    End Sub
    Private Sub MetroTextBox2_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox2.ButtonClick
        LoadDataToadv()
        LoadDataToCost()
    End Sub
    Private Sub Button11_Click(sender as Object, e as Eventargs) Handles Button11.Click
        Dim url as String = "http://203.170.129.23/transport/report/JobSummary?JobNo=" & txtJobNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex as Exception
            Process.Start(url)
        End Try
    End Sub
    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        Dim url as String = "http://203.170.129.23/transport/report/BookingConfirm?JobNo=" & txtJobNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex as Exception
            Process.Start(url)
        End Try
    End Sub
    Private Sub addTransport_FormClosing(sender as Object, e as FormClosingEventargs) Handles MyBase.FormClosing
        UpdateStatus()
    End Sub

    Private Sub GroupBox2_Enter(sender as Object, e as Eventargs) Handles GroupBox2.Enter

    End Sub

    Private Sub MetroTextBox2_Click(sender as Object, e as Eventargs) Handles MetroTextBox2.Click

    End Sub

    Private Sub Button12_Click(sender as Object, e as Eventargs) Handles Button12.Click
        dgvPrice.CurrentRow.Cells(16).Value = "0"
    End Sub
    'Private Sub MetroTextBox2_ButtonClick(sender as Object, e as Eventargs) Handles MetroTextBox2.ButtonClick
    '    If txtJobNo.Text = "" Then
    '        RunJobNo()
    '    End If
    'End Sub    
End Class