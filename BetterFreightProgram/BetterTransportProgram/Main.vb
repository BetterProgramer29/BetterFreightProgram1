Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text

Public Class Main
    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        addTransport.Show()
        addTransport._IsNew = True
        LoadPlanToDgv()
    End Sub
    Private Sub ChangePlanColor()
        'dgvPlanning.Rows.
    End Sub
    Private Sub LoadDataToPV()
        Try
            dgvPV.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM PV_Header where active='1'"
            If Not String.IsNullOrEmpty(txtSearchPVNo.Text) Then str &= " aND [DocCreateNo] LIKE'%" & txtSearchPVNo.Text & "%'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvPV.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                dt.Rows(i)(1).ToString(), 'PVType
                dt.Rows(i)(2).ToString(), 'DocCreateNo
                dt.Rows(i)(3).ToString(), 'DocNoDate
                dt.Rows(i)(4).ToString(), 'DocTime
                dt.Rows(i)(5).ToString(), 'Bookaccount
                dt.Rows(i)(6).ToString(), 'TransferNo
                dt.Rows(i)(7).ToString(), 'PVDate
                dt.Rows(i)(8).ToString(), 'VendorName
                dt.Rows(i)(9).ToString(), 'PsyFor
                dt.Rows(i)(10).ToString(), 'BankNo
                dt.Rows(i)(11).ToString(), 'Invoice
                dt.Rows(i)(12).ToString(), 'PayDate
                dt.Rows(i)(13).ToString(), 'PVNo
                dt.Rows(i)(14).ToString(), 'ReceiptNo
                dt.Rows(i)(15).ToString()  'active
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
    Private Sub Main_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        'MetroTabControl1.SelectedIndex = 0
        'Label4.Text = Now.Date.ToLongDateString
        'dtpFirstDate.Value = BeforeOnday()
        'dtpLastDate.Value = LastDayOfMonth()
        If OpenConnection() = False Then
            MetroFramework.MetroMessageBox.Show(Me, "Can't To Connect Database ", "Connection was terminated", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        ''UpdateDriverStatus()
        Dim frmSystemLogin as New frmSystemLogin()
        frmSystemLogin.ShowDialog()
        If IsLogingIn Then
            Dim MemProfile as MemberProfiles
            MemProfile = GetDataProfile(SBranch.CMPCode, SBranch.BranchCode)
            CMPProfile = MemProfile
            Me.Text = UserProfile.U_FName & "  " & UserProfile.U_LName & "  " & CMPProfile.PROF_Name & " V. 1.0.1.0"
            'LoadDataToPV()
            'LoadDataToDriverPlan()
            'LoadPlanToDgv()
            'LoadDriverPlan()
            LoadDataWHT()
        Else
            MetroFramework.MetroMessageBox.Show(Me, "User login was terminated ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
    End Sub
    Private Sub UpdateDriverStatus()
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_UpdateDriverStatus ")
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToDriverPlan()
        Try
            dgvDriverPlan.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM V_DriverPlan where 1=1"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    '  For a = 1 + 1 To dt.Rows.Count - 1
                    dgvDriverPlan.Rows.add(
                    dt.Rows(i)("TruckPlateNo").ToString(), 'TruckPlateNo
                    dt.Rows(i)("TailPlateNo").ToString(), 'TailPlateNo
                    dt.Rows(i)("TruckBrand").ToString(), 'TruckBrand
                    dt.Rows(i)("TruckNo").ToString(), 'TruckNo
                    dt.Rows(i)("TailNo").ToString(), 'TailNo
                    dt.Rows(i)("Driver").ToString(), 'Driver
                    dt.Rows(i)("Customer").ToString() & vbCrLf & dt.Rows(i)("JobNo").ToString() & vbCrLf & dt.Rows(i)("OrderNo").ToString(), 'Customer, JobNo, OrderNo
                    dt.Rows(i)("arriveTruckYardDate").ToString(), 'arriveTruckYardDate
                    dt.Rows(i)("arriveFactoryDate").ToString(), 'arriveFactoryDate
                    dt.Rows(i)("ReturnDate").ToString()  'ReturnDate
                    )
                    'Next
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub MetroButton1_Click(sender as Object, e as Eventargs) Handles MetroButton1.Click
        Customer.Show()
    End Sub
    Private Sub MetroButton2_Click(sender as Object, e as Eventargs) Handles MetroButton2.Click
        frmMasVessel.Show()
    End Sub
    Private Sub MetroButton3_Click(sender as Object, e as Eventargs) Handles MetroButton3.Click
        frmVesselagent.Show()
    End Sub
    Private Sub MetroButton4_Click(sender as Object, e as Eventargs) Handles MetroButton4.Click
        frmLocation.Show()
    End Sub
    Private Sub MetroButton5_Click(sender as Object, e as Eventargs) Handles MetroButton5.Click
        Truck.Show()
    End Sub
    Private Sub MetroButton6_Click(sender as Object, e as Eventargs) Handles MetroButton6.Click
        Route.Show()
    End Sub
    Private Sub LoadPlanToDgv()
        Try
            'dgvPlanning.Rows.Clear()
            MetroGrid4.DataSource = Nothing
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM V_PlanLoadInterface where 1=1 aND  orderno is not null "
            str &= " ORDER BY DStatus"
            'str &= " ORDER BY PickDate DESC "
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                MetroGrid4.DataSource = dt
                MetroGrid4.Columns(0).Visible = False 'hide Ident
                MetroGrid4.Columns("ExitYardDate").Visible = False
                MetroGrid4.Columns("arriveFactoryDate").Visible = False
                MetroGrid4.Columns("PackingDate").Visible = False
                MetroGrid4.Columns("LeaveFactoryDate").Visible = False
                MetroGrid4.Columns("DropDate").Visible = False
                MetroGrid4.Columns("DropTime").Visible = False
                MetroGrid4.Columns("actualReturnDate").Visible = False
                MetroGrid4.Columns("actualReturnTime").Visible = False
                MetroGrid4.Columns("DStatus").Visible = False
                'MetroGrid4.Columns("DStatusName").Visible = False
                For i as Integer = 0 To MetroGrid4.Rows.Count - 1
                    Select Case Replace(MetroGrid4.Rows(i).Cells("DStatus").Value, "NULL", "ORN")
                        Case "a" 'ก่อนถึงวันรับตู้ 1 วัน'
                            MetroGrid4.Rows(i).DefaultCellStyle.BackColor = Color.Khaki
                            MetroGrid4.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                        Case "B" 'วันนี้ต้องรับตู้'
                            MetroGrid4.Rows(i).DefaultCellStyle.BackColor = Color.HotPink
                            MetroGrid4.Rows(i).DefaultCellStyle.ForeColor = Color.White
                        Case "C" 'เลยกำหนดรับตู้แล้ว'
                            MetroGrid4.Rows(i).DefaultCellStyle.BackColor = Color.Crimson
                            MetroGrid4.Rows(i).DefaultCellStyle.ForeColor = Color.White
                        Case "D" 'ถึงลานรับตู้'
                            MetroGrid4.Rows(i).DefaultCellStyle.BackColor = Color.LimeGreen
                            MetroGrid4.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                        Case "E" 'ดรอปตู้ที่ลาน'
                            MetroGrid4.Rows(i).DefaultCellStyle.BackColor = Color.Orange
                            MetroGrid4.Rows(i).DefaultCellStyle.ForeColor = Color.White
                        Case "F" 'ถึงโรงงาน'
                            MetroGrid4.Rows(i).DefaultCellStyle.BackColor = Color.PaleTurquoise
                            MetroGrid4.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                        Case "G" 'เริ่มบรรจุ'
                            MetroGrid4.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
                            MetroGrid4.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                        Case "H" 'ออกจากโรงงาน'
                            MetroGrid4.Rows(i).DefaultCellStyle.BackColor = Color.MediumPurple
                            MetroGrid4.Rows(i).DefaultCellStyle.ForeColor = Color.White
                        Case "I" 'คืนตู้เสร็จ'
                            MetroGrid4.Rows(i).DefaultCellStyle.BackColor = Color.RoyalBlue
                            MetroGrid4.Rows(i).DefaultCellStyle.ForeColor = Color.White
                        Case Else 'ไม่มีเลขสั่งงาน'
                            'MetroGrid4.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                            MetroGrid4.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    End Select
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        LoadPlanToDgv()
    End Sub
    Private Sub btnPVCreate_Click_1(sender as Object, e as Eventargs) Handles btnPVCreate.Click
        frmPV.Show()
    End Sub

    Private Sub MetroButton7_Click(sender as Object, e as Eventargs) Handles MetroButton7.Click
        Vendor.Show()
    End Sub
    Private Sub dgvPlanning_CellFormatting(sender as Object, e as DataGridViewCellFormattingEventargs)

        'e.CellStyle.BackColor = Color.Red
        'e.cell
    End Sub

    Private Sub MetroButton8_Click(sender as Object, e as Eventargs) Handles MetroButton8.Click
        Invoice.Show()
    End Sub

    Private Sub MetroButton9_Click(sender as Object, e as Eventargs) Handles MetroButton9.Click
        RV.Show()
    End Sub

    Private Sub MetroButton10_Click(sender as Object, e as Eventargs) Handles MetroButton10.Click
        Bookaccount.Show()
    End Sub

    Private Sub MetroButton12_Click(sender as Object, e as Eventargs) Handles MetroButton12.Click
        SICODE.Show()
    End Sub

    Private Sub MetroButton11_Click(sender as Object, e as Eventargs) Handles MetroButton11.Click
        frmaccountPlan1.Show()
    End Sub

    Private Sub Button9_Click(sender as Object, e as Eventargs) Handles Button9.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP 100 [ident]
      ,[BCFNo]
      ,[Customer]
      ,[BCFUser]
      ,[VesselBooking]
      ,[FactoryRule]
      ,[Factory]
      ,[OrderNo]
      ,[OrderUser]
      ,[Driver]
      ,[TruckNo]
      ,[ContainerNo]
      ,[ContainerNo2]
      ,[PickDate]
      ,[LoadDate]
      ,[ReturnDate]
      ,[Volume]
      ,[Created_Order]
      ,[ContainerType]
      ,[Price]
      ,[BTTLocation]
      ,[PickupLocation]
      ,[LoadingLocation]
      ,[ReturnLocation]
      ,[arriveTruckYardTime]
      ,[ExitYardTime]
      ,[arriveFactoryTime]
      ,[PackingTime]
      ,[LeaveFactoryTime]
      ,[ReturnTime]
      ,[TimeofJobNotification]
      ,[BTTDistance]
      ,[LoadDistance]
      ,[PickupDistance]
      ,[ReturnDistance]
      ,[DriverRemark]
      ,[ExitYardDate]
      ,[arriveFactoryDate]
      ,[PackingDate]
      ,[LeaveFactoryDate]
      ,[DropDate]
      ,[DropTime]
      ,[actualReturnDate]
      ,[actualReturnTime]
      ,[DStatus]
      ,[DStatusName] FROM V_PlanLoadInterface WHERE 1=1 order by BCFNo ", MainConnection)
        If isSearchOK Then
            addTransport._IsNew = False
            addTransport.txtJobNo.Text = dr("BCFNo").ToString
            addTransport.Show()
        End If
        addTransport._IsNew = False
    End Sub
    Private Sub MetroButton13_Click(sender as Object, e as Eventargs) Handles MetroButton13.Click
        frmMasUser.Show()
    End Sub

    Private Sub dgvPlanning_CellMouseDoubleClick_1(sender as Object, e as DataGridViewCellMouseEventargs)

    End Sub

    Private Sub dgvPlanning_CellMouseClick_1(sender as Object, e as DataGridViewCellMouseEventargs)

    End Sub
    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        '  Dim dr as DataRow
        '  dr = PopUpSearch("SELECT
        '[PVType]
        ',[DocCreateNo]
        ',[DocNoDate]
        ',[DocTime]
        ',[Bookaccount]
        ',[TransferNo]
        ',[PVDate]
        ',[VendorName]
        ',[PsyFor]
        ',[BankNo]
        ',[Invoice]
        ',[PayDate]
        ',[PVNo]
        ',[ReceiptNo],active  FROM [PV_Header] WHERE active='1'  order by DocCreateNo ", MainConnection)
        '  If isSearchOK Then
        '      frmPV.txtDocCreateNo.Text = dr("DocCreateNo").ToString
        '      frmPV.Show()
        '  End If

        LoadDataToPV()

    End Sub

    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT
      [PVType]
      ,[DocCreateNo]
      ,[DocNoDate]
      ,[DocTime]
      ,[Bookaccount]
      ,[TransferNo]
      ,[PVDate]
      ,[VendorName]
      ,[PsyFor]
      ,[BankNo]
      ,[Invoice]
      ,[PayDate]
      ,[PVNo]
      ,[ReceiptNo],active  FROM [PV_Header] WHERE active='0'  order by DocCreateNo ", MainConnection)
        If isSearchOK Then
            frmPV.txtDocCreateNo.Text = dr("DocCreateNo").ToString
            frmPV.Show()
        End If
    End Sub

    Private Sub Button10_Click(sender as Object, e as Eventargs) Handles Button10.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT * FROM [addTransport]
        where jobno not in(select jobno from [Invoice_Header] where jobno=[Invoice_Header].JobNo )", MainConnection)
        If isSearchOK Then
            Invoice._IsNew = False
            Invoice.txtJobNo.Text = dr("JobNo").ToString
            Invoice.txtVesselBooking.Text = dr("VesselBooking").ToString
            Invoice.txtBLNo.Text = dr("BLNo").ToString
            Invoice.txtCustCode.Text = dr("CustCode").ToString
            Invoice.txtCustomer.Text = dr("Customer").ToString
            Invoice.txtBTTLocation.Text = dr("BTTLocation").ToString
            Invoice.txtPickupLocation.Text = dr("PickLocation").ToString
            Invoice.txtLoadingLocation.Text = dr("LoadLocation").ToString
            Invoice.txtReturnLocation.Text = dr("ReturnLocation").ToString
            Invoice.Show()
        End If
    End Sub

    Private Sub Button12_Click(sender as Object, e as Eventargs) Handles Button12.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT * FROM [Invoice_Header] where 1=1", MainConnection)
        If isSearchOK Then
            Invoice._IsNew = False
            Invoice.txtIdent.Text = dr("Ident").ToString
            Invoice.txtInvoiceNo.Text = dr("InvoiceNo").ToString
            Invoice.txtJobNo.Text = dr("JobNo").ToString
            Invoice.txtVesselBooking.Text = dr("VesselBooking").ToString
            Invoice.txtBLNo.Text = dr("BLNo").ToString
            Invoice.txtCustCode.Text = dr("CustomerCode").ToString
            Invoice.txtCustomeraddress.Text = dr("Customeraddress").ToString
            Invoice.txtCustomer.Text = dr("Customer").ToString
            Invoice.txtBTTLocation.Text = dr("BTTLocation").ToString
            Invoice.txtPickupLocation.Text = dr("PickupLocation").ToString
            Invoice.txtLoadingLocation.Text = dr("LoadingLocation").ToString
            Invoice.txtReturnLocation.Text = dr("ReturnLocation").ToString
            Invoice.Show()
        End If
    End Sub

    Private Sub Button17_Click(sender as Object, e as Eventargs) Handles Button17.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT * FROM [addTransport]
        where jobno not in(select jobno from [Invoice_Header] where jobno=[Invoice_Header].JobNo )", MainConnection)
        If isSearchOK Then
            Invoice._IsNew = False
            Invoice.txtJobNo.Text = dr("JobNo").ToString
            Invoice.txtVesselBooking.Text = dr("VesselBooking").ToString
            Invoice.txtBLNo.Text = dr("BLNo").ToString
            Invoice.txtCustCode.Text = dr("CustCode").ToString
            Invoice.txtCustomer.Text = dr("Customer").ToString
            Invoice.txtBTTLocation.Text = dr("BTTLocation").ToString
            Invoice.txtPickupLocation.Text = dr("PickLocation").ToString
            Invoice.txtLoadingLocation.Text = dr("LoadLocation").ToString
            Invoice.txtReturnLocation.Text = dr("ReturnLocation").ToString
            Invoice.Show()
        End If
    End Sub

    Private Sub Button21_Click(sender as Object, e as Eventargs) Handles Button21.Click
        RV.Show()
    End Sub

    Private Sub Button22_Click(sender as Object, e as Eventargs) Handles Button22.Click
        TaxInvoice.Show()
    End Sub

    Private Sub Button23_Click(sender as Object, e as Eventargs) Handles Button23.Click
        SOa.Show()
    End Sub

    Private Sub Button26_Click(sender as Object, e as Eventargs) Handles Button26.Click
        'WHT1.Show()
        Try
            Dim frm As New frmWhtax
            ' frm.txtDocControlNO.Text = PVNo
            frm.ShowDialog()
            LoadDataWHT()
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub MetroGrid4_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles MetroGrid4.CellMouseClick
    '    Try
    '        If e.RowIndex < 0 Or e.RowIndex > MetroGrid4.Rows.Count - 1 Then Exit Sub
    '        If e.RowIndex >= 0 Then
    '            txtJobNo.Text = MetroGrid4.CurrentRow.Cells(1).Value.ToString() 'Code
    '            addTransport._IsNew = False
    '        End If
    '    Catch ex as Exception
    '    End Try
    'End Sub

    'Private Sub MetroGrid4_CellMouseDoubleClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles MetroGrid4.CellMouseDoubleClick
    '    If Not String.IsNullOrEmpty(txtJobNo.Text) Then
    '        addTransport.txtJobNo.Text = txtJobNo.Text
    '        addTransport._IsNew = False
    '        addTransport.ShowDialog()
    '    End If
    'End Sub

    Private Sub Button27_Click(sender as Object, e as Eventargs)
        Dim url as String = "http://203.170.129.23/transport"
        Try
            Process.Start("chrome.exe", url)
        Catch ex as Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub Label5_Click(sender as Object, e as Eventargs) Handles Label5.Click
        MsgBox(dtpFirstDate.Value.addDays(1))
    End Sub

    Private Sub dtpFirstDate_ValueChanged(sender as Object, e as Eventargs) Handles dtpFirstDate.ValueChanged
        'LoadDriverPlan()
    End Sub
    Private Sub LoadDriverPlan()
        Try
            'For i as Integer = 0 To dtpFirstDate.Value - 1
            '    MsgBox(dtpFirstDate.Value.CompareTo(dtpLastDate.Value))
            'Next'
            Dim FirstDate as DateTime = dtpFirstDate.Value
            Dim subQuery as String = " ,(SELECT STUFF((
				SELECT DISTINCT ' " & vbCrLf & "'+Driver FROM Driver WHERE t.TruckNo=Driver.TruckNo 
                 aND ( Driver.arriveTruckYardDate between '" & FirstDate.ToString("yyyy-MM-dd") & "' aND '" & dtpLastDate.Value.ToString("yyyy-MM-dd") & "'  
                 OR Driver.arriveFactoryDate between '" & FirstDate.ToString("yyyy-MM-dd") & "' aND '" & dtpLastDate.Value.ToString("yyyy-MM-dd") & "'
                 OR Driver.ReturnDate between '" & FirstDate.ToString("yyyy-MM-dd") & "' aND '" & dtpLastDate.Value.ToString("yyyy-MM-dd") & "'
                 OR Driver.ExitYardDate between '" & FirstDate.ToString("yyyy-MM-dd") & "' aND '" & dtpLastDate.Value.ToString("yyyy-MM-dd") & "'
                 OR Driver.PackingDate between '" & FirstDate.ToString("yyyy-MM-dd") & "' aND '" & dtpLastDate.Value.ToString("yyyy-MM-dd") & "'
                 OR Driver.LeaveFactoryDate between '" & FirstDate.ToString("yyyy-MM-dd") & "' aND '" & dtpLastDate.Value.ToString("yyyy-MM-dd") & "'
                 )
				FOR XML PaTH(''),type).value('.','nvarchar(max)'),1,1,''
            )) as [allDriver] "

            While FirstDate.CompareTo(dtpLastDate.Value) <= 0
                '               subQuery += ",(SELECT STUFF((
                'SELECT  
                '' ' +(CaSE WHEN Driver.arriveTruckYardDate = '" & FirstDate.ToString("dd/MM/yyyy") & "' THEN addTransport.Customer+'" & vbCrLf & "'+Driver.OrderNo+'" & vbCrLf & "' +' arrive :'+Driver.arriveTruckYardDate+' '+arriveTruckYardTime+'" & vbCrLf & "' ELSE '' END)+
                '	(CaSE WHEN Driver.arriveFactoryDate = '" & FirstDate.ToString("dd/MM/yyyy") & "' THEN addTransport.Customer+'" & vbCrLf & "'+Driver.OrderNo+'" & vbCrLf & "' +' arriveFactory :'+arriveFactoryDate+' '+arriveFactoryDate+'" & vbCrLf & "' ELSE '' END)+
                '(CaSE WHEN Driver.ReturnDate = '" & FirstDate.ToString("dd/MM/yyyy") & "' THEN addTransport.Customer+'" & vbCrLf & "'+Driver.OrderNo +'" & vbCrLf & "'+' Return :'+Driver.ReturnDate+' '+Driver.ReturnTime+'" & vbCrLf & "' ELSE '' END)+
                '   (CaSE WHEN Driver.ExitYardDate = '" & FirstDate.ToString("dd/MM/yyyy") & "' THEN addTransport.Customer+'" & vbCrLf & "'+Driver.OrderNo +'" & vbCrLf & "'+' ExitYard :'+Driver.ExitYardDate+' '+Driver.ExitYardTime+'" & vbCrLf & "' ELSE '' END)+
                '   (CaSE WHEN Driver.PackingDate = '" & FirstDate.ToString("dd/MM/yyyy") & "' THEN addTransport.Customer+'" & vbCrLf & "'+Driver.OrderNo +'" & vbCrLf & "'+' Packing :'+Driver.PackingDate+' '+Driver.PackingTime+'" & vbCrLf & "' ELSE '' END)+
                '   (CaSE WHEN Driver.LeaveFactoryDate = '" & FirstDate.ToString("dd/MM/yyyy") & "' THEN addTransport.Customer+'" & vbCrLf & "'+Driver.OrderNo +'" & vbCrLf & "'+' LeaveFactory :'+Driver.LeaveFactoryDate+' '+Driver.LeaveFactoryTime+'" & vbCrLf & "' ELSE '' END)
                'FROM Driver 
                'INNER JOIN addTransport ON addTransport.JobNo = Driver.JobNo
                'WHERE Driver.TruckNo = d.TruckNo aND Driver.Driver = d.Driver  aND (Driver.arriveTruckYardDate = '" & FirstDate.ToString("dd/MM/yyyy") & "' or Driver.ReturnDate = '" & FirstDate.ToString("dd/MM/yyyy") & "'  ) 
                '   FOR XML PaTH(''),type).value('.','nvarchar(max)'),1,1,''
                '   )) as [" & FirstDate.ToString("dd/MM/yyyy") & "]"
                subQuery += ",(SELECT STUFF(( SELECT
	            ' " & vbCrLf & vbCrLf & "'+ addTransport.JobNo+' '+Driver.OrderNo+'" & vbCrLf & "'+'H:'+ Driver.HeadNo +' T:'+Driver.TailNo+'" & vbCrLf & "'+ Driver.Driver +'" & vbCrLf & "'+Driver.LoadingLocation+' " & vbCrLf & "'+
	            (CaSE WHEN Driver.arriveTruckYardDate = '" & FirstDate.ToString("yyyy-MM-dd") & "' THEN ' arrive:'+CONVERT(nvarchar,Driver.arriveTruckYardDate,103)+' '+arriveTruckYardTime+'" & vbCrLf & "' ELSE '' END)+
	            (CaSE WHEN Driver.arriveFactoryDate = '" & FirstDate.ToString("yyyy-MM-dd") & "' THEN ' arriveFactory:'+CONVERT(nvarchar,arriveFactoryDate,103)+' '+arriveFactoryTime+'" & vbCrLf & "' ELSE '' END)+
	            (CaSE WHEN Driver.ReturnDate = '" & FirstDate.ToString("yyyy-MM-dd") & "' THEN ' Return:'+CONVERT(nvarchar,Driver.ReturnDate,103)+' '+Driver.ReturnTime+'" & vbCrLf & "' ELSE '' END)+
                (CaSE WHEN Driver.ExitYardDate = '" & FirstDate.ToString("yyyy-MM-dd") & "' THEN ' ExitYard:'+CONVERT(nvarchar,Driver.ExitYardDate,103)+' '+Driver.ExitYardTime+'" & vbCrLf & "' ELSE '' END)+
                (CaSE WHEN Driver.PackingDate = '" & FirstDate.ToString("yyyy-MM-dd") & "' THEN ' Packing:'+CONVERT(nvarchar,Driver.PackingDate,103)+' '+Driver.PackingTime+'" & vbCrLf & "' ELSE '' END)+
                (CaSE WHEN Driver.LeaveFactoryDate = '" & FirstDate.ToString("yyyy-MM-dd") & "' THEN 'LeaveFactory:'+CONVERT(nvarchar,Driver.LeaveFactoryDate,103)+' '+Driver.LeaveFactoryTime+'" & vbCrLf & "' ELSE '' END)
	            FROM Driver 
	            INNER JOIN addTransport ON addTransport.JobNo = Driver.JobNo
                WHERE Driver.TruckNo = t.TruckNo 
	            aND (
		        Driver.arriveTruckYardDate = '" & FirstDate.ToString("yyyy-MM-dd") & "' 
		        or Driver.arriveFactoryDate = '" & FirstDate.ToString("yyyy-MM-dd") & "' 
		        or Driver.ReturnDate = '" & FirstDate.ToString("yyyy-MM-dd") & "'
		        or Driver.ExitYardDate = '" & FirstDate.ToString("yyyy-MM-dd") & "'
		        or Driver.PackingDate = '" & FirstDate.ToString("yyyy-MM-dd") & "'
		        or Driver.LeaveFactoryDate = '" & FirstDate.ToString("yyyy-MM-dd") & "'
	            ) 
	            aND active =1 
                FOR XML PaTH(''),type).value('.','nvarchar(max)'),1,1,''
                )) as [" & FirstDate.ToString("dd/MM/yyyy") & "]"
                FirstDate = FirstDate.addDays(1)
            End While
            Dim SQL as String = " SELECT  ROW_NUMBER() OVER(ORDER BY allDriver DESC  ) No,* FROM ( SELECT t.TruckNo,t.TruckPlateNo 
           
            " & subQuery & "
            FROM
            [Mas_Truck] aS t
            LEFT OUTER JOIN
            DRIVER aS D 
            ON t.TruckNo=D.TruckNo aND   D.active=1 aND D.IsNotJob=0
            WHERE  
            1=1
            group by t.TruckNo,t.TruckPlateNo
            ) a order by allDriver DESC"
            'MsgBox(SQL)
            'TextBox1.Text = SQL '''
            'dgvPlanning.Rows.Clear()
            dgvPlanDriver.DataSource = Nothing
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = SQL
            'str &= " ORDER BY PickDate DESC "
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                dgvPlanDriver.DataSource = dt
                ' MetroGrid5.Columns(0).Visible = False 'hide Ident
                dgvPlanDriver.Columns(1).Frozen = True
                dgvPlanDriver.Columns(2).Frozen = True
                dgvPlanDriver.Columns(3).Frozen = True
                For i as Integer = 2 To dgvPlanDriver.Rows.Count - 1
                    dgvPlanDriver.Columns(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Next
            End If
            da = Nothing
            dt = Nothing
            nection.Close()
        Catch ex as Exception
            '   MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender as Object, e as Eventargs) Handles RefreshToolStripMenuItem.Click
        LoadDriverPlan()
    End Sub
    Private Sub dtpLastDate_ValueChanged(sender as Object, e as Eventargs) Handles dtpLastDate.ValueChanged
        'LoadDriverPlan()
    End Sub
    Private Sub MetroGrid4_CellContentClick(sender as Object, e as DataGridViewCellEventargs) Handles MetroGrid4.CellContentClick

    End Sub

    Private Sub Button25_Click(sender as Object, e as Eventargs) Handles Button25.Click
        ' LoadDataToPV()
        LoadDataWHT()
    End Sub
    Private Sub LoadDataWHT()
        Try
            dgvShowWHT.DataSource = Nothing

            Dim SQL As String = "SELECT TOP 200  [TBIDNT],[DocControlNO],[DocNo],[DocDate],[TaxNumber3],[TName3],[TAddress3],[TotalPayAmount],[TotalPayTax],[DocRefNo],[JobRefNo],[PAYNumber],[CreateBy],[CreateDate]   FROM [INF_WHTax] WHERE 1=1 "
            If Not String.IsNullOrEmpty(txtDocControlNO.Text) Then SQL &= " aND [DocControlNO] LIKE'%" & txtDocControlNO.Text & "%'"
            SQL &= " ORDER BY DocControlNO DESC "
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            da.SelectCommand = New OleDbCommand(SQL, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                dgvShowWHT.DataSource = dt
                '  dgvShowWHT.Columns(0).Visible = False 'hide Ident
                ' dgvShowWHT.Columns(1).Visible = False 'Branch
            End If
            da = Nothing
            dt = Nothing
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub MetroGrid1_CellMouseDoubleClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvShowWHT.CellMouseDoubleClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvShowWHT.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                Dim PVNo As String = dgvShowWHT.CurrentRow.Cells(1).Value.ToString() 'DocControlNO
                'Dim frm as New WHT1
                'frm.txtDocControlNO.Text = PVNo

                Dim frm As New frmWhtax
                frm.txtDocControlNO.Text = PVNo
                frm.ShowDialog()
                LoadDataWHT()
            End If
        Catch ex as Exception

        End Try
    End Sub

    Private Sub dgvPV_CellMouseDoubleClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvPV.CellMouseDoubleClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvPV.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                Dim PVNo as String = dgvPV.CurrentRow.Cells(2).Value.ToString()
                Dim frm as New frmPV
                frm.txtDocCreateNo.Text = PVNo
                frm.Show()
            End If
        Catch ex as Exception

        End Try
    End Sub

    Private Sub btnReloadDriverPlan_Click(sender As Object, e As Eventargs) Handles btnReloadDriverPlan.Click
        LoadDriverPlan()
    End Sub
    Private Sub MetroButton14_Click(sender As Object, e As Eventargs) Handles btnSumReport.Click
        Dim url As String = "http://203.170.129.23/transport"
        Try
            Process.Start("chrome.exe", url)
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub
    Private Sub MetroTabControl1_SelectedIndexChanged(sender As Object, e As Eventargs) Handles MetroTabControl1.SelectedIndexChanged
        'If MetroTabControl1.SelectedIndex = 8 Then
        '    LoadDataWHT()
        'End If
    End Sub
    Private Sub Button28_Click(sender As Object, e As Eventargs) Handles Button28.Click
        Quotation.Show()
    End Sub
    Private Sub Button29_Click(sender As Object, e As Eventargs) Handles Button29.Click
        BookingConfirm.Show()
    End Sub
    Private Sub MetroButton14_Click_1(sender As Object, e As Eventargs) Handles MetroButton14.Click
        DriverSalaryNew.Show()
    End Sub
    Private Sub Button30_Click(sender As Object, e As Eventargs) Handles Button30.Click
        HouseBL.IsNotMaster = True
        HouseBL.Show()
    End Sub
    Private Sub Button27_Click_1(sender As Object, e As Eventargs) Handles Button27.Click
        MasterBL.Show()
    End Sub
    Private Sub Button31_Click(sender as Object, e as Eventargs) Handles Button31.Click
        CostPrice.Show()
    End Sub

    Private Sub Button32_Click(sender as Object, e as Eventargs) Handles Button32.Click
        ReceiveVoucher.Show()
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        TaxInv.Show()
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        PaymentVoucher.Show()
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        HouseadvRequest.Show()
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        frmInv.Show()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click

    End Sub
End Class