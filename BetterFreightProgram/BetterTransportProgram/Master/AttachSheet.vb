Imports System.Collections.Specialized.BitVector32
Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text

Public Class AttachSheet
    Private _IsNew As Boolean
    Private Sub AttachSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '********************** Implement Code Close this ********************* 
        If OpenConnection() = False Then
            MetroFramework.MetroMessageBox.Show(Me, "Can't To Connect Database ", "Connection was terminated", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        ''UpdateDriverStatus()
        Dim frmSystemLogin As New frmSystemLogin()
        frmSystemLogin.ShowDialog()
        If IsLogingIn Then
            Dim MemProfile As MemberProfiles
            MemProfile = GetDataProfile(SBranch.CMPCode, SBranch.BranchCode)
            CMPProfile = MemProfile
            Me.Text = UserProfile.U_FName & "  " & UserProfile.U_LName & "  " & CMPProfile.PROF_Name & " V. 1.0.1.0"

            AddNewAttachSheet()
            LoadDataAttachToDataGrid()
        Else
            MetroFramework.MetroMessageBox.Show(Me, "User login was terminated ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '*******************************************************************************************************************



        ''********************** Implement Code Open this *********************
        'AddNewAttachSheet()
        'LoadDataAttachToDataGrid()

        '*******************************************************************************************************************
    End Sub
    Private Sub LoadDataAttachToDataGrid()
        Try
            dgvAttachSheet.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_AttachSheet where 1=1 AND [Active]=1"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvAttachSheet.Rows.Add(dt.Rows(i)("TBIDENT").ToString(), 'TBIDENT
                            dt.Rows(i)("MasterBLType").ToString(), 'MasterBLType
                            dt.Rows(i)("BookingNo").ToString(), 'BookingNo
                            dt.Rows(i)("Consignee").ToString(), 'Consignee
                            dt.Rows(i)("agentPartner").ToString(), 'agentPartner
                            dt.Rows(i)("QuotationNo").ToString(), 'QuotationNo
                            "", 'BCFNo
                            dt.Rows(i)("RunNumber").ToString() 'RunNumber
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
    Private Sub txtPackageQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQtyContainer2.KeyPress, txtQtyContainer1.KeyPress, txtPackageQty.KeyPress, txtPackageGW.KeyPress, txtContainerNW2.KeyPress, txtContainerNW1.KeyPress, txtContainerGW2.KeyPress, txtContainerGW1.KeyPress, txtCBM.KeyPress
        CheckDouble(e)
        If e.KeyChar = Chr(Keys.Enter) Then
            SetTextDigit()
        End If
    End Sub
    Private Sub txtPackageQty_Leave(sender As Object, e As EventArgs) Handles txtQtyContainer2.Leave, txtQtyContainer1.Leave, txtPackageQty.Leave, txtPackageGW.Leave, txtContainerNW2.Leave, txtContainerNW1.Leave, txtContainerGW2.Leave, txtContainerGW1.Leave, txtCBM.Leave
        SetTextDigit()
    End Sub
    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        AddNewAttachSheet()
    End Sub
    Private Sub AddNewAttachSheet()
        txtTBIdent.Text = "0" 'TBIDENT
        txtRunNumber.ResetText() 'RunNumber
        txtShipper.ResetText() 'Shipper
        txtShipperID.Text = "0" 'ShipperID
        txtShipperaddress.ResetText() 'Shipperaddress
        txtShipperContact.ResetText() 'ShipperContact
        txtShipperRef.ResetText() 'ShipperRef
        txtConsignee.ResetText() 'Consignee
        txtConsigneeID.Text = "0" 'ConsigneeID
        txtConsigneeaddress.ResetText() 'Consigneeaddress
        txtConsigneeContact.ResetText() 'ConsigneeContact
        txtConsigneeRef.ResetText() 'ConsigneeRef
        txtNotifyParty.ResetText() 'NotifyParty
        txtNotifyPartyID.Text = "0" 'NotifyPartyID
        txtNotifyaddress.ResetText() 'Notifyaddress
        txtPlaceOfReceive.ResetText() 'PlaceOfReceive
        txtPlaceOfReceiveCode.ResetText() 'PlaceOfReceiveCode
        txtPortOfLoading.ResetText() 'PortOfLoading
        txtPortOfLoadingCode.ResetText() 'PortOfLoadingCode
        txtPortOfDischarge.ResetText() 'PortOfDischarge
        txtPortOfDischargeCode.ResetText() 'PortOfDischargeCode
        txtPlaceOfDelivery.ResetText() 'PlaceOfDelivery
        txtPlaceOfDeliveryCode.ResetText() 'PlaceOfDeliveryCode
        txtLocalVessel.ResetText() 'LocalVessel
        txtLocalVoy.ResetText() 'LocalVoy
        txtOceanVessel.ResetText() 'OceanVessel
        txtOceanVoy.ResetText() 'OceanVoy
        txtagentPartner.ResetText() 'agentPartner
        txtagentPartnerID.Text = "0" 'agentPartnerID
        txtagentaddress.ResetText() 'agentaddress
        txtagentContact.ResetText() 'agentContact
        txtQuotationNo.ResetText() 'QuotationNo
        txtQuotaionUser.ResetText() 'QuotaionUser
        txtBookingNo.ResetText() 'BookingNo
        txtBookingUser.ResetText() 'BookingUser
        txtSysUser.ResetText() 'SysUser
        txtMarkNumber.ResetText() 'MarkNumber
        txtContainer.ResetText() 'Container
        txtPackageQty.ResetText() 'PackageQty
        txtPackageType.ResetText() 'PackageType
        txtCBM.ResetText() 'CBM
        txtPackageGW.ResetText() 'PackageGW
        txtQtyContainer1.ResetText() 'QtyContainer1
        txtContainerType1.ResetText() 'ContainerType1
        txtContainerNW1.ResetText() 'ContainerNW1
        txtContainerGW1.ResetText() 'ContainerGW1
        txtQtyContainer2.ResetText() 'QtyContainer2
        txtContainerType2.ResetText() 'ContainerType2
        txtContainerNW2.ResetText() 'ContainerNW2
        txtContainerGW2.ResetText() 'ContainerGW2
        txtMasterBLType.ResetText() 'MasterBLType
        dtpETD.ResetText() 'ETD
        dtpETa.ResetText() 'ETA
        txtDescriptionOfGoods.ResetText() 'DescriptionOfGoods
        txtNoOfOriginalBL.ResetText() 'NoOfOriginalBL
        txtTermOfPayment.ResetText() 'TermOfPayment
        togActive.Checked = True  'Active
        txtactive.Text = "1" 'Active
        txtRunNumber.Text = "ATT-YYMM#####"
        _IsNew = True
        txtSysUser.Text = UserProfile.U_Code
        SetTextDigit()
        ' dgvAttachSheet.Rows.Clear()
        LoadDataAttachToDataGrid()

        '*************************************
        ' GetRunningFormat("BKG")
        'txtRunNumber.Text = "ATT-YYMM#####"
        'txtRunNumber.Text = CreateNumber("Freight_BookingConfirm", "RunNumber", "ATT-YYMM#####")
    End Sub
    Private Sub SetTextDigit()
        '2
        SetDigit(txtPackageQty)
        SetDigit(txtPackageGW)
        SetDigit(txtQtyContainer1)
        SetDigit(txtContainerNW1)
        SetDigit(txtContainerGW1)
        SetDigit(txtQtyContainer2)
        SetDigit(txtContainerNW2)
        SetDigit(txtContainerGW2)
        '4
        SetDigit4(txtCBM)
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        'Try
        '    Dim dr As DataRow
        '    dr = PopUpSearch("SELECT * FROM Freight_AttachSheet where  1=1", MainConnection)
        '    If isSearchOK Then
        '        txtRunNumber.Text = dr("RunNumber").ToString
        '        txtTBIdent.Text = CInt(dr("TBIDENT").ToString)
        '        LoadDataAttachSheet(txtRunNumber.Text)
        '    End If
        'Catch ex As Exception

        'End Try
        txtRunNumber.Text = "ATT-YYMM#####"
        _IsNew = True
        txtSysUser.Text = UserProfile.U_Code
    End Sub
    Private Sub LoadDataAttachSheet(_DocNo As String)
        Try
            Dim str As String = "SELECT * FROM Freight_AttachSheet where 1=1 AND RunNumber='" & _DocNo & "'"
            Dim dr As DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                'txtTBIdent.Text = CInt(dr("TBIDENT").ToString()) 'TBIDENT
                'txtRunNumber.Text = dr("RunNumber").ToString 'RunNumber
                txtShipper.Text = dr("Shipper").ToString 'Shipper
                txtShipperID.Text = CInt(dr("ShipperID").ToString()) 'ShipperID
                txtShipperaddress.Text = dr("Shipperaddress").ToString 'Shipperaddress
                txtShipperContact.Text = dr("ShipperContact").ToString 'ShipperContact
                txtShipperRef.Text = dr("ShipperRef").ToString 'ShipperRef
                txtConsignee.Text = dr("Consignee").ToString 'Consignee
                txtConsigneeID.Text = CInt(dr("ConsigneeID").ToString()) 'ConsigneeID
                txtConsigneeaddress.Text = dr("Consigneeaddress").ToString 'Consigneeaddress
                txtConsigneeContact.Text = dr("ConsigneeContact").ToString 'ConsigneeContact
                txtConsigneeRef.Text = dr("ConsigneeRef").ToString 'ConsigneeRef
                txtNotifyParty.Text = dr("NotifyParty").ToString 'NotifyParty
                txtNotifyPartyID.Text = CInt(dr("NotifyPartyID").ToString()) 'NotifyPartyID
                txtNotifyaddress.Text = dr("Notifyaddress").ToString 'Notifyaddress
                txtPlaceOfReceive.Text = dr("PlaceOfReceive").ToString 'PlaceOfReceive
                txtPlaceOfReceiveCode.Text = dr("PlaceOfReceiveCode").ToString 'PlaceOfReceiveCode
                txtPortOfLoading.Text = dr("PortOfLoading").ToString 'PortOfLoading
                txtPortOfLoadingCode.Text = dr("PortOfLoadingCode").ToString 'PortOfLoadingCode
                txtPortOfDischarge.Text = dr("PortOfDischarge").ToString 'PortOfDischarge
                txtPortOfDischargeCode.Text = dr("PortOfDischargeCode").ToString 'PortOfDischargeCode
                txtPlaceOfDelivery.Text = dr("PlaceOfDelivery").ToString 'PlaceOfDelivery
                txtPlaceOfDeliveryCode.Text = dr("PlaceOfDeliveryCode").ToString 'PlaceOfDeliveryCode
                txtLocalVessel.Text = dr("LocalVessel").ToString 'LocalVessel
                txtLocalVoy.Text = dr("LocalVoy").ToString 'LocalVoy
                txtOceanVessel.Text = dr("OceanVessel").ToString 'OceanVessel
                txtOceanVoy.Text = dr("OceanVoy").ToString 'OceanVoy
                txtagentPartner.Text = dr("agentPartner").ToString 'agentPartner
                txtagentPartnerID.Text = CInt(dr("agentPartnerID").ToString()) 'agentPartnerID
                txtagentaddress.Text = dr("agentaddress").ToString 'agentaddress
                txtagentContact.Text = dr("agentContact").ToString 'agentContact
                txtQuotationNo.Text = dr("QuotationNo").ToString 'QuotationNo
                txtQuotaionUser.Text = dr("QuotaionUser").ToString 'QuotaionUser
                txtBookingNo.Text = dr("BookingNo").ToString 'BookingNo
                txtBookingUser.Text = dr("BookingUser").ToString 'BookingUser
                txtSysUser.Text = dr("SysUser").ToString 'SysUser
                txtMarkNumber.Text = dr("MarkNumber").ToString 'MarkNumber
                txtContainer.Text = dr("Container").ToString 'Container
                txtPackageQty.Text = dr("PackageQty").ToString 'PackageQty
                txtPackageType.Text = dr("PackageType").ToString 'PackageType
                txtCBM.Text = dr("CBM").ToString 'CBM
                txtPackageGW.Text = dr("PackageGW").ToString 'PackageGW
                txtQtyContainer1.Text = dr("QtyContainer1").ToString 'QtyContainer1
                txtContainerType1.Text = dr("ContainerType1").ToString 'ContainerType1
                txtContainerNW1.Text = dr("ContainerNW1").ToString 'ContainerNW1
                txtContainerGW1.Text = dr("ContainerGW1").ToString 'ContainerGW1
                txtQtyContainer2.Text = dr("QtyContainer2").ToString 'QtyContainer2
                txtContainerType2.Text = dr("ContainerType2").ToString 'ContainerType2
                txtContainerNW2.Text = dr("ContainerNW2").ToString 'ContainerNW2
                txtContainerGW2.Text = dr("ContainerGW2").ToString 'ContainerGW2
                txtMasterBLType.Text = dr("MasterBLType").ToString 'MasterBLType
                dtpETD.Value = CDate(dr("ETD").ToString) 'ETD
                dtpETa.Value = CDate(dr("ETA").ToString) 'ETA
                txtDescriptionOfGoods.Text = dr("DescriptionOfGoods").ToString 'DescriptionOfGoods
                txtNoOfOriginalBL.Text = dr("NoOfOriginalBL").ToString 'NoOfOriginalBL
                txtTermOfPayment.Text = dr("TermOfPayment").ToString 'TermOfPayment
                togActive.Checked = CInt(dr("Active").ToString()) 'Active
                txtactive.Text = CInt(dr("Active").ToString()) 'Active
                _IsNew = False
                SetTextDigit()
            End If


        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error : " & ex.Message, "รายงานผล", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
#Region "Validate Input"
        If String.IsNullOrEmpty(txtRunNumber.Text) Then
            txtRunNumber.Focus()
            txtRunNumber.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtRunNumber.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtShipper.Text) Then
            txtShipper.Focus()
            txtShipper.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtShipper.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtShipperaddress.Text) Then
            txtShipperaddress.Focus()
            txtShipperaddress.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtShipperaddress.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtConsignee.Text) Then
            txtConsignee.Focus()
            txtConsignee.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtConsignee.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtConsigneeaddress.Text) Then
            txtConsigneeaddress.Focus()
            txtConsigneeaddress.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtConsigneeaddress.Style = MetroFramework.MetroColorStyle.Default
        End If

        If String.IsNullOrEmpty(txtNotifyParty.Text) Then
            txtNotifyParty.Focus()
            txtNotifyParty.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtNotifyParty.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtNotifyaddress.Text) Then
            txtNotifyaddress.Focus()
            txtNotifyaddress.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtNotifyaddress.Style = MetroFramework.MetroColorStyle.Default
        End If


        If String.IsNullOrEmpty(txtPlaceOfReceiveCode.Text) Then
            txtPlaceOfReceiveCode.Focus()
            txtPlaceOfReceiveCode.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtPlaceOfReceiveCode.Style = MetroFramework.MetroColorStyle.Default
        End If

        If String.IsNullOrEmpty(txtPortOfLoadingCode.Text) Then
            txtPortOfLoadingCode.Focus()
            txtPortOfLoadingCode.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtPortOfLoadingCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPortOfDischargeCode.Text) Then
            txtPortOfDischargeCode.Focus()
            txtPortOfDischargeCode.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtPortOfDischargeCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPlaceOfDeliveryCode.Text) Then
            txtPlaceOfDeliveryCode.Focus()
            txtPlaceOfDeliveryCode.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtPlaceOfDeliveryCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtagentPartner.Text) Then
            txtagentPartner.Focus()
            txtagentPartner.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtagentPartner.Style = MetroFramework.MetroColorStyle.Default
        End If

        If String.IsNullOrEmpty(txtQuotationNo.Text) Then
            txtQuotationNo.Focus()
            txtQuotationNo.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtQuotationNo.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtBookingNo.Text) Then
            txtBookingNo.Focus()
            txtBookingNo.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtBookingNo.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPackageType.Text) Then
            txtPackageType.Focus()
            txtPackageType.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtPackageType.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtContainerType1.Text) Then
            txtContainerType1.Focus()
            txtContainerType1.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtContainerType1.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtContainerType2.Text) Then
            txtContainerType2.Focus()
            txtContainerType2.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtContainerType2.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtMasterBLType.Text) Then
            txtMasterBLType.Focus()
            txtMasterBLType.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtMasterBLType.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtNoOfOriginalBL.Text) Then
            txtNoOfOriginalBL.Focus()
            txtNoOfOriginalBL.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtNoOfOriginalBL.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtTermOfPayment.Text) Then
            txtTermOfPayment.Focus()
            txtTermOfPayment.Style = MetroFramework.MetroColorStyle.Red
            Exit Sub
        Else
            txtTermOfPayment.Style = MetroFramework.MetroColorStyle.Default
        End If
#End Region
        If _IsNew Then
            txtRunNumber.Text = CreateNumber("Freight_AttachSheet", "RunNumber", txtRunNumber.Text)
            SaveDataAttachSheet(1)
        Else
            SaveDataAttachSheet(0)
        End If
    End Sub
    Private Sub SaveDataAttachSheet(_Insert As Integer)
        Try

            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_AttachSheet ")
            SQLcommand.Append("'" & CInt(txtTBIdent.Text) & "'") 'TBIDENT
            SQLcommand.Append(",'" & txtRunNumber.Text & "'") 'RunNumber
            SQLcommand.Append(",'" & txtShipper.Text & "'") 'Shipper
            SQLcommand.Append(",'" & CInt(txtShipperID.Text) & "'") 'ShipperID
            SQLcommand.Append(",'" & txtShipperaddress.Text & "'") 'Shipperaddress
            SQLcommand.Append(",'" & txtShipperContact.Text & "'") 'ShipperContact
            SQLcommand.Append(",'" & txtShipperRef.Text & "'") 'ShipperRef
            SQLcommand.Append(",'" & txtConsignee.Text & "'") 'Consignee
            SQLcommand.Append(",'" & CInt(txtConsigneeID.Text) & "'") 'ConsigneeID
            SQLcommand.Append(",'" & txtConsigneeaddress.Text & "'") 'Consigneeaddress
            SQLcommand.Append(",'" & txtConsigneeContact.Text & "'") 'ConsigneeContact
            SQLcommand.Append(",'" & txtConsigneeRef.Text & "'") 'ConsigneeRef
            SQLcommand.Append(",'" & txtNotifyParty.Text & "'") 'NotifyParty
            SQLcommand.Append(",'" & CInt(txtNotifyPartyID.Text) & "'") 'NotifyPartyID
            SQLcommand.Append(",'" & txtNotifyaddress.Text & "'") 'Notifyaddress
            SQLcommand.Append(",'" & txtPlaceOfReceive.Text & "'") 'PlaceOfReceive
            SQLcommand.Append(",'" & txtPlaceOfReceiveCode.Text & "'") 'PlaceOfReceiveCode
            SQLcommand.Append(",'" & txtPortOfLoading.Text & "'") 'PortOfLoading
            SQLcommand.Append(",'" & txtPortOfLoadingCode.Text & "'") 'PortOfLoadingCode
            SQLcommand.Append(",'" & txtPortOfDischarge.Text & "'") 'PortOfDischarge
            SQLcommand.Append(",'" & txtPortOfDischargeCode.Text & "'") 'PortOfDischargeCode
            SQLcommand.Append(",'" & txtPlaceOfDelivery.Text & "'") 'PlaceOfDelivery
            SQLcommand.Append(",'" & txtPlaceOfDeliveryCode.Text & "'") 'PlaceOfDeliveryCode
            SQLcommand.Append(",'" & txtLocalVessel.Text & "'") 'LocalVessel
            SQLcommand.Append(",'" & txtLocalVoy.Text & "'") 'LocalVoy
            SQLcommand.Append(",'" & txtOceanVessel.Text & "'") 'OceanVessel
            SQLcommand.Append(",'" & txtOceanVoy.Text & "'") 'OceanVoy
            SQLcommand.Append(",'" & txtagentPartner.Text & "'") 'agentPartner
            SQLcommand.Append(",'" & CInt(txtagentPartnerID.Text) & "'") 'agentPartnerID
            SQLcommand.Append(",'" & txtagentaddress.Text & "'") 'agentaddress
            SQLcommand.Append(",'" & txtagentContact.Text & "'") 'agentContact
            SQLcommand.Append(",'" & txtQuotationNo.Text & "'") 'QuotationNo
            SQLcommand.Append(",'" & txtQuotaionUser.Text & "'") 'QuotaionUser
            SQLcommand.Append(",'" & txtBookingNo.Text & "'") 'BookingNo
            SQLcommand.Append(",'" & txtBookingUser.Text & "'") 'BookingUser
            SQLcommand.Append(",'" & txtSysUser.Text & "'") 'SysUser
            SQLcommand.Append(",'" & txtMarkNumber.Text & "'") 'MarkNumber
            SQLcommand.Append(",'" & txtContainer.Text & "'") 'Container
            SQLcommand.Append(",'" & CDbl(txtPackageQty.Text) & "'") 'PackageQty
            SQLcommand.Append(",'" & txtPackageType.Text & "'") 'PackageType
            SQLcommand.Append(",'" & CDbl(txtCBM.Text) & "'") 'CBM
            SQLcommand.Append(",'" & CDbl(txtPackageGW.Text) & "'") 'PackageGW
            SQLcommand.Append(",'" & CDbl(txtQtyContainer1.Text) & "'") 'QtyContainer1
            SQLcommand.Append(",'" & txtContainerType1.Text & "'") 'ContainerType1
            SQLcommand.Append(",'" & CDbl(txtContainerNW1.Text) & "'") 'ContainerNW1
            SQLcommand.Append(",'" & CDbl(txtContainerGW1.Text) & "'") 'ContainerGW1
            SQLcommand.Append(",'" & CDbl(txtQtyContainer2.Text) & "'") 'QtyContainer2
            SQLcommand.Append(",'" & txtContainerType2.Text & "'") 'ContainerType2
            SQLcommand.Append(",'" & CDbl(txtContainerNW2.Text) & "'") 'ContainerNW2
            SQLcommand.Append(",'" & CDbl(txtContainerGW2.Text) & "'") 'ContainerGW2
            SQLcommand.Append(",'" & txtMasterBLType.Text & "'") 'MasterBLType
            SQLcommand.Append(",'" & CDate(dtpETD.Value) & "'") 'ETD
            SQLcommand.Append(",'" & CDate(dtpETa.Value) & "'") 'ETA
            SQLcommand.Append(",'" & txtDescriptionOfGoods.Text & "'") 'DescriptionOfGoods
            SQLcommand.Append(",'" & txtNoOfOriginalBL.Text & "'") 'NoOfOriginalBL
            SQLcommand.Append(",'" & txtTermOfPayment.Text & "'") 'TermOfPayment
            SQLcommand.Append(",'" & CInt(togActive.CheckState) & "'") 'Active
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Reload Data To Data Grid
                LoadDataAttachToDataGrid()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        Dim url As String = "http://203.170.129.23/TESTFRIEGHT/report/Booking?BookNo=" & txtRunNumber.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub txtShipper_ButtonClick(sender As Object, e As EventArgs) Handles txtShipper.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail,TBIDNT  FROM Mas_Customer WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtShipper.Text = dr("CustName").ToString
                txtShipperID.Text = dr("TBIDNT").ToString
                txtShipperaddress.Text = dr("Taddress").ToString
                txtShipperContact.Text = (dr("CustContact") + " " + dr("CustPhone") + " " + dr("CustFax")).ToString
                txtShipperRef.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtShipper_ClearClicked() Handles txtShipper.ClearClicked
        txtShipperID.Text = "0"
        txtShipperaddress.ResetText()
        txtShipperContact.ResetText()
        txtShipperRef.ResetText()

    End Sub
    Private Sub txtConsignee_ButtonClick(sender As Object, e As EventArgs) Handles txtConsignee.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail,TBIDNT  FROM Mas_Customer WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtConsignee.Text = dr("CustName").ToString
                txtConsigneeID.Text = dr("TBIDNT").ToString
                txtConsigneeaddress.Text = dr("Taddress").ToString
                txtConsigneeContact.Text = (dr("CustContact") + " " + dr("CustPhone") + " " + dr("CustFax")).ToString
                txtConsigneeRef.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtConsignee_ClearClicked() Handles txtConsignee.ClearClicked
        txtConsigneeID.Text = "0"
        txtConsigneeaddress.ResetText()
        txtConsigneeContact.ResetText()
        txtConsigneeRef.ResetText()
    End Sub

    Private Sub txtNotifyParty_ButtonClick(sender As Object, e As EventArgs) Handles txtNotifyParty.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail,TBIDNT  FROM Mas_Customer WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtNotifyParty.Text = dr("CustName").ToString
                txtNotifyPartyID.Text = dr("TBIDNT").ToString
                txtNotifyaddress.Text = dr("Taddress").ToString
                'txtConsigneeContact.Text = (dr("CustContact") + " " + dr("CustPhone") + " " + dr("CustFax")).ToString
                'txtConsigneeRef.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNotifyParty_ClearClicked() Handles txtNotifyParty.ClearClicked
        txtNotifyParty.ResetText()
        txtNotifyPartyID.Text = "0"
        txtNotifyaddress.ResetText()
    End Sub

    Private Sub txtPlaceOfReceive_ButtonClick(sender As Object, e As EventArgs) Handles txtPlaceOfReceive.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TOP(100) [PortCode],[PortName],[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtPlaceOfReceiveCode.Text = dr("PortCode").ToString
                txtPlaceOfReceive.Text = dr("PortName").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPlaceOfReceive_ClearClicked() Handles txtPlaceOfReceive.ClearClicked
        txtPlaceOfReceiveCode.ResetText()
    End Sub

    Private Sub txtPortOfLoading_ButtonClick(sender As Object, e As EventArgs) Handles txtPortOfLoading.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TOP(100) [PortCode],[PortName],[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtPortOfLoadingCode.Text = dr("PortCode").ToString
                txtPortOfLoading.Text = dr("PortName").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPortOfLoading_ClearClicked() Handles txtPortOfLoading.ClearClicked
        txtPortOfLoadingCode.ResetText()
    End Sub

    Private Sub txtPortOfDischarge_ButtonClick(sender As Object, e As EventArgs) Handles txtPortOfDischarge.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TOP(100) [PortCode],[PortName],[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtPortOfDischargeCode.Text = dr("PortCode").ToString
                txtPortOfDischarge.Text = dr("PortName").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPortOfDischarge_ClearClicked() Handles txtPortOfDischarge.ClearClicked
        txtPortOfDischarge.ResetText()
    End Sub

    Private Sub txtPlaceOfDelivery_ButtonClick(sender As Object, e As EventArgs) Handles txtPlaceOfDelivery.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TOP(100) [PortCode],[PortName],[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtPlaceOfDeliveryCode.Text = dr("PortCode").ToString
                txtPlaceOfDelivery.Text = dr("PortName").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPlaceOfDelivery_ClearClicked() Handles txtPlaceOfDelivery.ClearClicked
        txtPlaceOfDelivery.ResetText()
    End Sub

    Private Sub txtagentPartner_ButtonClick(sender As Object, e As EventArgs) Handles txtagentPartner.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail,TBIDNT  FROM Mas_Customer WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtagentPartner.Text = dr("CustName").ToString
                txtagentPartnerID.Text = dr("TBIDNT").ToString
                txtagentaddress.Text = dr("Taddress").ToString
                txtagentContact.Text = (dr("CustContact") + " " + dr("CustPhone") + " " + dr("CustFax")).ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPackageType_ButtonClick(sender As Object, e As EventArgs) Handles txtPackageType.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TOP(100) PackageCode,PackageDescription  FROM Freight_PackageType WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtPackageType.Text = dr("PackageCode").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtContainerType1_ButtonClick(sender As Object, e As EventArgs) Handles txtContainerType1.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TOP(100) ContainerType FROM Freight_ContainerType WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtContainerType1.Text = dr("ContainerType").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtContainerType2_ButtonClick(sender As Object, e As EventArgs) Handles txtContainerType2.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("SELECT TOP(100) ContainerType FROM Freight_ContainerType WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtContainerType2.Text = dr("ContainerType").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvAttachSheet_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAttachSheet.CellMouseClick
        Try
            If e.RowIndex < 0 Or e.RowIndex > dgvAttachSheet.Rows.Count - 1 Then Exit Sub
            If e.RowIndex >= 0 Then
                txtTBIdent.Text = CInt(dgvAttachSheet.CurrentRow.Cells(0).Value.ToString()) 'TBIDENT
                txtRunNumber.Text = dgvAttachSheet.CurrentRow.Cells(7).Value.ToString() 'RunNumber

                '  _IsNew = False
                LoadDataAttachSheet(txtRunNumber.Text)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtBookingNo_ButtonClick(sender As Object, e As EventArgs) Handles txtBookingNo.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("  SELECT TOP 100 [BookingNo],[BookingUser],[QuotationNo],[QuotationUser] FROM [Freight_BookingConfirm] WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtBookingNo.Text = dr("BookingNo").ToString
                txtBookingUser.Text = dr("BookingUser").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtQuotationNo_ButtonClick(sender As Object, e As EventArgs) Handles txtQuotationNo.ButtonClick
        Try
            Dim dr As DataRow
            dr = PopUpSearch("  SELECT TOP 100 [QuotationNo],[QuotationUser],[BookingNo],[BookingUser] FROM [Freight_BookingConfirm] WHERE 1=1", MainConnection)
            If isSearchOK Then
                txtQuotationNo.Text = dr("QuotationNo").ToString
                txtQuotaionUser.Text = dr("QuotationUser").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class