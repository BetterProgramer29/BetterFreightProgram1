Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Text

Public Class HouseBL
    Public _IsNew As Boolean
    Public MustSave As Boolean = True
    Public counter As Integer = 0
    Public counter2 As Integer = 0
    Public IsNotMaster As Boolean
    Public IsNotNew As Boolean
    Private Sub MetroGrid3_DoubleClick(sender As Object, e As EventArgs)
        HouseBLPop.Show()
    End Sub

    Private Sub MetroGrid1_DoubleClick(sender As Object, e As EventArgs) Handles MetroGrid1.DoubleClick
        HouseBLPop.Show()
    End Sub

    Private Sub MetroGrid2_DoubleClick(sender As Object, e As EventArgs) Handles MetroGrid2.DoubleClick
        HouseBLPop.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
#Region "Validate Input"
        If String.IsNullOrEmpty(txtHouseType.Text) Then
            txtHouseType.Focus()
            txtHouseType.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล HouseType ", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtHouseType.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVSLBKG.Text) Then
            txtVSLBKG.Focus()
            txtVSLBKG.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Vessel Booking (ของสายเรือ)  ", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtVSLBKG.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtMasterBLNo.Text) Then
            txtMasterBLNo.Focus()
            txtMasterBLNo.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Master B\L (ของสายเรือ)", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtMasterBLNo.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtShipper.Text) Then
            txtShipper.Focus()
            txtShipper.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Shipper", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtShipper.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtShipperaddress.Text) Then
            txtShipperaddress.Focus()
            txtShipperaddress.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Shipperaddress", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtShipperaddress.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtShipperContact.Text) Then
            txtShipperContact.Focus()
            txtShipperContact.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ShipperContact", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtShipperContact.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtShipperRef.Text) Then
            txtShipperRef.Focus()
            txtShipperRef.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ShipperRef", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtShipperRef.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtConsignee.Text) Then
            txtConsignee.Focus()
            txtConsignee.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Consignee", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtConsignee.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtConsigneeaddress.Text) Then
            txtConsigneeaddress.Focus()
            txtConsigneeaddress.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Consigneeaddress", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtConsigneeaddress.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtConsigneeContact.Text) Then
            txtConsigneeContact.Focus()
            txtConsigneeContact.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ConsigneeContact", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtConsigneeContact.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtConsigneeRef.Text) Then
            txtConsigneeRef.Focus()
            txtConsigneeRef.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ConsigneeRef", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtConsigneeRef.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtNotifyParty.Text) Then
            txtNotifyParty.Focus()
            txtNotifyParty.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล NotifyParty", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtNotifyParty.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtNotifyaddress.Text) Then
            txtNotifyaddress.Focus()
            txtNotifyaddress.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Notifyaddress.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtNotifyaddress.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPlaceOfReceive.Text) Then
            txtPlaceOfReceive.Focus()
            txtPlaceOfReceive.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PlaceOfReceive.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPlaceOfReceive.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPortOfLoading.Text) Then
            txtPortOfLoading.Focus()
            txtPortOfLoading.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PortOfLoading.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPortOfLoading.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPortOfDischarge.Text) Then
            txtPortOfDischarge.Focus()
            txtPortOfDischarge.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PortOfDischarge.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPortOfDischarge.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPlaceOfDelivery.Text) Then
            txtPlaceOfDelivery.Focus()
            txtPlaceOfDelivery.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PlaceOfDelivery.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPlaceOfDelivery.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtLocalVessel.Text) Then
            txtLocalVessel.Focus()
            txtLocalVessel.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล LocalVessel.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtLocalVessel.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtLocalVoy.Text) Then
            txtLocalVoy.Focus()
            txtLocalVoy.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล LocalVoy.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtLocalVoy.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtOceanVessel.Text) Then
            txtOceanVessel.Focus()
            txtOceanVessel.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล OceanVessel.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtOceanVessel.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtOceanVoy.Text) Then
            txtOceanVoy.Focus()
            txtOceanVoy.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล OceanVoy.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtOceanVoy.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtagentPartner.Text) Then
            txtagentPartner.Focus()
            txtagentPartner.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล agentPartner.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtagentPartner.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtagentaddress.Text) Then
            txtagentaddress.Focus()
            txtagentaddress.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Agentaddress.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtagentaddress.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtagentContact.Text) Then
            txtagentContact.Focus()
            txtagentContact.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล AgentContact.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtagentContact.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtMarkNumber.Text) Then
            txtMarkNumber.Focus()
            txtMarkNumber.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล MarkNumber.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtMarkNumber.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtContainer.Text) Then
            txtContainer.Focus()
            txtContainer.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Container.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtContainer.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPackageType.Text) Then
            txtPackageType.Focus()
            txtPackageType.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PackageType.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPackageType.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtContainerType1.Text) Then
            txtContainerType1.Focus()
            txtContainerType1.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ContainerType.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtContainerType1.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtContainerType2.Text) Then
            txtContainerType2.Focus()
            txtContainerType2.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ContainerType.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtContainerType2.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtContainerNW2.Text) Then
            txtContainerNW2.Focus()
            txtContainerNW2.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ContainerNW.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtContainerNW2.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtContainerGW2.Text) Then
            txtContainerGW2.Focus()
            txtContainerGW2.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ContainerGW.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtContainerGW2.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtMasterBLType.Text) Then
            txtMasterBLType.Focus()
            txtMasterBLType.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล MasterBLType.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtMasterBLType.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtDescriptionOfGoods.Text) Then
            txtDescriptionOfGoods.Focus()
            txtDescriptionOfGoods.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล DescriptionOfGoods.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtDescriptionOfGoods.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtNoOfOriginalBL.Text) Then
            txtNoOfOriginalBL.Focus()
            txtNoOfOriginalBL.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล NoOfOriginalBL.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtNoOfOriginalBL.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtTermOfPayment.Text) Then
            txtTermOfPayment.Focus()
            txtTermOfPayment.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล TermOfPayment.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtTermOfPayment.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtQuotationNo.Text) Then
            txtQuotationNo.Focus()
            txtQuotationNo.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล QuotationNo.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtQuotationNo.Style = MetroFramework.MetroColorStyle.Default
        End If
        'If String.IsNullOrEmpty(txtQuotaionUser.Text) Then
        '    txtQuotaionUser.Focus()
        '    txtQuotaionUser.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtQuotaionUser.Style = MetroFramework.MetroColorStyle.Default
        'End If
        If String.IsNullOrEmpty(txtBookingNo.Text) Then
            txtBookingNo.Focus()
            txtBookingNo.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล BookingNo.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtBookingNo.Style = MetroFramework.MetroColorStyle.Default
        End If
        'If String.IsNullOrEmpty(txtBookingUser.Text) Then
        '    txtBookingUser.Focus()
        '    txtBookingUser.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtBookingUser.Style = MetroFramework.MetroColorStyle.Default
        'End If
        If String.IsNullOrEmpty(txtHouseBLNo.Text) Then
            txtHouseBLNo.Focus()
            txtHouseBLNo.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล HouseBLNo.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtHouseBLNo.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtSysUser.Text) Then
            '    txtSysUser.Focus()
            '    txtSysUser.Style = MetroFramework.MetroColorStyle.Red
            '    Exit Sub
            'Else
            '    txtSysUser.Style = MetroFramework.MetroColorStyle.Default
            txtSysUser.Text = UserProfile.U_FName & " " & UserProfile.U_LName
        End If
#End Region

        'If txtBookingNo.Text = "" Then
        '    MsgBox("ให้ใส่บุ๊คกิ้งด้วย")
        '    Exit Sub
        'End If
        If txtBCFNo.Text = "" Then
            GetRunningFormat("HBCF")
            txtBCFNo.Text = CreateNumber("Freight_HouseBL", "BCFNo", False)
        End If
        If _IsNew = True Then
            SaveHouseBL(1)
        Else
            SaveHouseBL(0)
        End If
    End Sub
    Private Sub LoadDataToHouseBL()
        Try
            Dim dr As DataRow
            Dim sqlstr As String = "SELECT 
        [HouseType]
        ,[BCFNo]
        ,[VSLBKG]
        ,[MBLNo]
        ,[HBLNo]
        ,[Shipper]
        ,[Shipperaddress]
        ,[ShipperContact]
        ,[ShipperRef]
        ,[Consignee]
        ,[Consigneeaddress]
        ,[ConsigneeContact]
        ,[ConsigneeRef]
        ,[NotifyParty]
        ,[Notifyaddress]
        ,[PlaceOfReceive]
        ,[PortOfLoading]
        ,[PortOfDischarge]
        ,[PlaceOfDelivery]
        ,[LocalVessel]
        ,[LocalVoy]
        ,[OceanVessel]
        ,[OceanVoy]
        ,[agentPartner]
        ,[agentaddress]
        ,[agentContact]
        ,[MarkNumber]
        ,[Container]
        ,[PackageQty]
        ,[PackageType]
        ,[CBM]
        ,[PackageGW]
        ,[QtyContainer1]
        ,[ContainerType1]
        ,[ContainerNW1]
        ,[ContainerGW1]
        ,[QtyContainer2]
        ,[ContainerType2]
        ,[ContainerNW2]
        ,[ContainerGW2]
        ,[MasterBLType]
        ,[ETD]
        ,[ETa]
        ,[DescriptionOfGoods]
        ,[NoOfOriginalBL]
        ,[TermOfPayment]
        ,[QuotationNo]
        ,[QuotaionUser]
        ,[BookingNo]
        ,[BookingUser]
        ,[CurrentLetter]
        ,[Ident]  FROM Freight_HouseBL WHERE 1=1 and HBLNo='" & txtHouseBLNo.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtHouseType.Text = dr("HouseType").ToString
                txtBCFNo.Text = dr("BCFNo").ToString
                txtMasterBLNo.Text = dr("MBLNo").ToString
                txtHouseBLNo.Text = dr("HBLNo").ToString
                txtBookingNo.Text = dr("BookingNo").ToString
                txtVSLBKG.Text = dr("VSLBKG").ToString
                txtBookingUser.Text = dr("BookingUser").ToString
                txtQuotationNo.Text = dr("QuotationNo").ToString
                txtQuotaionUser.Text = dr("QuotaionUser").ToString
                txtShipper.Text = dr("Shipper").ToString
                txtShipperaddress.Text = dr("Shipperaddress").ToString
                txtShipperContact.Text = dr("ShipperContact").ToString
                txtShipperRef.Text = dr("ShipperRef").ToString
                txtConsignee.Text = dr("Consignee").ToString
                txtConsigneeaddress.Text = dr("Consigneeaddress").ToString
                txtConsigneeContact.Text = dr("ConsigneeContact").ToString
                txtConsigneeRef.Text = dr("ConsigneeRef").ToString
                txtNotifyParty.Text = dr("NotifyParty").ToString
                txtNotifyaddress.Text = dr("Notifyaddress").ToString
                txtPlaceOfReceive.Text = dr("PlaceofReceive").ToString
                txtPortOfLoading.Text = dr("PortofLoading").ToString
                txtPortOfDischarge.Text = dr("PortofDischarge").ToString
                txtPlaceOfDelivery.Text = dr("PlaceofDelivery").ToString
                txtLocalVessel.Text = dr("LocalVessel").ToString
                txtLocalVoy.Text = dr("LocalVoy").ToString
                txtOceanVessel.Text = dr("OceanVessel").ToString
                txtOceanVoy.Text = dr("OceanVoy").ToString
                txtagentPartner.Text = dr("agentPartner").ToString
                txtagentaddress.Text = dr("agentaddress").ToString
                txtagentContact.Text = dr("agentContact").ToString
                txtMarkNumber.Text = dr("MarkNumber").ToString
                txtContainer.Text = dr("Container").ToString
                txtPackageQty.Text = dr("PackageQty").ToString
                txtPackageType.Text = dr("PackageType").ToString
                txtCBM.Text = dr("CBM").ToString
                txtPackageGW.Text = dr("PackageGW").ToString
                txtQtyContainer1.Text = dr("QtyContainer1").ToString
                txtContainerType1.Text = dr("ContainerType1").ToString
                txtContainerNW1.Text = dr("ContainerNW1").ToString
                txtContainerGW1.Text = dr("ContainerGW1").ToString
                txtQtyContainer2.Text = dr("QtyContainer2").ToString
                txtContainerType2.Text = dr("ContainerType2").ToString
                txtContainerNW2.Text = dr("ContainerNW2").ToString
                txtContainerGW2.Text = dr("ContainerGW2").ToString
                dtpETD.Value = dr("ETD").ToString
                dtpETa.Value = dr("ETa").ToString
                txtDescriptionOfGoods.Text = dr("DescriptionOfGoods").ToString
                txtIdent.Text = dr("Ident").ToString
                currentLetter = dr("CurrentLetter").ToString
                _IsNew = False
                MustSave = False
                LoadDataCharge()
                LoadDataCN()
                LoadDataDN()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub GetIdent()
        Try
            Dim dr As DataRow
            Dim sqlstr As String = "SELECT DISTINCT Ident FROM [Freight_HouseBL] where BCFNo='" & txtBCFNo.Text & "' and MBLNo='" & txtMasterBLNo.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtIdent.Text = CInt(dr("Ident")).ToString
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SaveHouseBL(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_HouseBL ")
            SQLcommand.Append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.Append(",'" & txtHouseType.Text & "'") 'MasterType
            SQLcommand.Append(",'" & txtBCFNo.Text & "'") 'BCFNo
            SQLcommand.Append(",'" & txtVSLBKG.Text & "'") 'VSLBKG
            SQLcommand.Append(",'" & txtMasterBLNo.Text & "'") 'MBLNo
            SQLcommand.Append(",'" & txtShipper.Text & "'") 'Shipper
            SQLcommand.Append(",'" & txtShipperaddress.Text & "'") 'Shipperaddress
            SQLcommand.Append(",'" & txtShipperContact.Text & "'") 'ShipperContact
            SQLcommand.Append(",'" & txtShipperRef.Text & "'") 'ShipperRef
            SQLcommand.Append(",'" & txtConsignee.Text & "'") 'Consignee
            SQLcommand.Append(",'" & txtConsigneeaddress.Text & "'") 'Consigneeaddress
            SQLcommand.Append(",'" & txtConsigneeContact.Text & "'") 'ConsigneeContact
            SQLcommand.Append(",'" & txtConsigneeRef.Text & "'") 'ConsigneeRef
            SQLcommand.Append(",'" & txtNotifyParty.Text & "'") 'NotifyParty
            SQLcommand.Append(",'" & txtNotifyaddress.Text & "'") 'Notifyaddress
            SQLcommand.Append(",'" & txtPlaceOfReceive.Text & "'") 'PlaceOfReceive
            SQLcommand.Append(",'" & txtPortOfLoading.Text & "'") 'PortOfLoading
            SQLcommand.Append(",'" & txtPortOfDischarge.Text & "'") 'PortOfDischarge
            SQLcommand.Append(",'" & txtPlaceOfDelivery.Text & "'") 'PlaceOfDelivery
            SQLcommand.Append(",'" & txtLocalVessel.Text & "'") 'LocalVessel
            SQLcommand.Append(",'" & txtLocalVoy.Text & "'") 'LocalVoy
            SQLcommand.Append(",'" & txtOceanVessel.Text & "'") 'OceanVessel
            SQLcommand.Append(",'" & txtOceanVoy.Text & "'") 'OceanVoy
            SQLcommand.Append(",'" & txtagentPartner.Text & "'") 'agentPartner
            SQLcommand.Append(",'" & txtagentaddress.Text & "'") 'agentaddress
            SQLcommand.Append(",'" & txtagentContact.Text & "'") 'agentContact
            SQLcommand.Append(",'" & txtMarkNumber.Text & "'") 'MarkNumber
            SQLcommand.Append(",'" & txtContainer.Text & "'") 'Container
            SQLcommand.Append(",'" & CInt(txtPackageQty.Text) & "'") 'PackageQty
            SQLcommand.Append(",'" & txtPackageType.Text & "'") 'PackageType
            SQLcommand.Append(",'" & CDbl(txtCBM.Text) & "'") 'CBM
            SQLcommand.Append(",'" & CDbl(txtPackageGW.Text) & "'") 'PackageGW
            SQLcommand.Append(",'" & CInt(txtQtyContainer1.Text) & "'") 'QtyContainer1
            SQLcommand.Append(",'" & txtContainerType1.Text & "'") 'ContainerType1
            SQLcommand.Append(",'" & CDbl(txtContainerNW1.Text) & "'") 'ContainerNW1
            SQLcommand.Append(",'" & CDbl(txtContainerGW1.Text) & "'") 'ContainerGW1
            SQLcommand.Append(",'" & CInt(txtQtyContainer2.Text) & "'") 'QtyContainer2
            SQLcommand.Append(",'" & txtContainerType2.Text & "'") 'ContainerType2
            SQLcommand.Append(",'" & txtContainerNW2.Text & "'") 'ContainerNW2
            SQLcommand.Append(",'" & txtContainerGW2.Text & "'") 'ContainerGW2
            SQLcommand.Append(",'" & txtMasterBLType.Text & "'") 'MasterBLType
            SQLcommand.Append(",'" & CDate(dtpETD.Value) & "'") 'ETD
            SQLcommand.Append(",'" & CDate(dtpETa.Value) & "'") 'ETa
            SQLcommand.Append(",'" & txtDescriptionOfGoods.Text & "'") 'DescriptionOfGoods
            SQLcommand.Append(",'" & txtNoOfOriginalBL.Text & "'") 'NoOfOriginalBL
            SQLcommand.Append(",'" & txtTermOfPayment.Text & "'") 'TermOfPayment
            SQLcommand.Append(",'" & txtQuotationNo.Text & "'") 'QuotationNo
            SQLcommand.Append(",'" & txtQuotaionUser.Text & "'") 'QuotaionUser
            SQLcommand.Append(",'" & txtBookingNo.Text & "'") 'BookingNo
            SQLcommand.Append(",'" & txtBookingUser.Text & "'") 'BookingUser
            SQLcommand.Append(",'" & txtHouseBLNo.Text & "'")
            SQLcommand.Append(",'" & txtCurrentLetter.Text & "'")
            SQLcommand.Append(",'" & CInt(txtactive.Text) & "'")
            SQLcommand.Append(",'" & txtSysUser.Text & "'")
            SQLcommand.Append(",'" & txtADVNo.Text & "'")
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                MustSave = False
                LoadDataCN()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadCurrentLetter()
        Try
            Dim dr As DataRow
            Dim sqlstr As String = "  SELECT MBLNo,MAX(CurrentLetter) as CurrentLetter from [Freight_HouseBL] where MBLNo='" & txtMasterBLNo.Text & "'  group by MBLNo"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                currentLetter = dr("CurrentLetter").ToString
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim dr As DataRow
        dr = PopUpSearch("SELECT 
        [HouseType]
        ,[BCFNo]
        ,[VSLBKG]
        ,[MBLNo]
        ,[HBLNo]
        ,[Shipper]
        ,[Shipperaddress]
        ,[ShipperContact]
        ,[ShipperRef]
        ,[Consignee]
        ,[Consigneeaddress]
        ,[ConsigneeContact]
        ,[ConsigneeRef]
        ,[NotifyParty]
        ,[Notifyaddress]
        ,[PlaceOfReceive]
        ,[PortOfLoading]
        ,[PortOfDischarge]
        ,[PlaceOfDelivery]
        ,[LocalVessel]
        ,[LocalVoy]
        ,[OceanVessel]
        ,[OceanVoy]
        ,[agentPartner]
        ,[agentaddress]
        ,[agentContact]
        ,[MarkNumber]
        ,[Container]
        ,[PackageQty]
        ,[PackageType]
        ,[CBM]
        ,[PackageGW]
        ,[QtyContainer1]
        ,[ContainerType1]
        ,[ContainerNW1]
        ,[ContainerGW1]
        ,[QtyContainer2]
        ,[ContainerType2]
        ,[ContainerNW2]
        ,[ContainerGW2]
        ,[MasterBLType]
        ,[ETD]
        ,[ETa]
        ,[DescriptionOfGoods]
        ,[NoOfOriginalBL]
        ,[TermOfPayment]
        ,[QuotationNo]
        ,[QuotaionUser]
        ,[BookingNo]
        ,[BookingUser]
        ,[CurrentLetter]
        ,[Ident]  FROM Freight_HouseBL WHERE 1=1 and MBLNo='" & txtMasterBLNo.Text & "' and BCFNo='" & txtBCFNo.Text & "' and active='1'", MainConnection)
        If isSearchOK Then
            txtHouseType.Text = dr("HouseType").ToString
            txtBCFNo.Text = dr("BCFNo").ToString
            txtMasterBLNo.Text = dr("MBLNo").ToString
            txtHouseBLNo.Text = dr("HBLNo").ToString
            txtBookingNo.Text = dr("BookingNo").ToString
            txtVSLBKG.Text = dr("VSLBKG").ToString
            txtBookingUser.Text = dr("BookingUser").ToString
            txtQuotationNo.Text = dr("QuotationNo").ToString
            txtQuotaionUser.Text = dr("QuotaionUser").ToString
            txtShipper.Text = dr("Shipper").ToString
            txtShipperaddress.Text = dr("Shipperaddress").ToString
            txtShipperContact.Text = dr("ShipperContact").ToString
            txtShipperRef.Text = dr("ShipperRef").ToString
            txtConsignee.Text = dr("Consignee").ToString
            txtConsigneeaddress.Text = dr("Consigneeaddress").ToString
            txtConsigneeContact.Text = dr("ConsigneeContact").ToString
            txtConsigneeRef.Text = dr("ConsigneeRef").ToString
            txtNotifyParty.Text = dr("NotifyParty").ToString
            txtNotifyaddress.Text = dr("Notifyaddress").ToString
            txtPlaceOfReceive.Text = dr("PlaceofReceive").ToString
            txtPortOfLoading.Text = dr("PortofLoading").ToString
            txtPortOfDischarge.Text = dr("PortofDischarge").ToString
            txtPlaceOfDelivery.Text = dr("PlaceofDelivery").ToString
            txtLocalVessel.Text = dr("LocalVessel").ToString
            txtLocalVoy.Text = dr("LocalVoy").ToString
            txtOceanVessel.Text = dr("OceanVessel").ToString
            txtOceanVoy.Text = dr("OceanVoy").ToString
            txtagentPartner.Text = dr("agentPartner").ToString
            txtagentaddress.Text = dr("agentaddress").ToString
            txtagentContact.Text = dr("agentContact").ToString
            txtMarkNumber.Text = dr("MarkNumber").ToString
            txtContainer.Text = dr("Container").ToString
            txtPackageQty.Text = dr("PackageQty").ToString
            txtPackageType.Text = dr("PackageType").ToString
            txtCBM.Text = dr("CBM").ToString
            txtPackageGW.Text = dr("PackageGW").ToString
            txtQtyContainer1.Text = dr("QtyContainer1").ToString
            txtContainerType1.Text = dr("ContainerType1").ToString
            txtContainerNW1.Text = dr("ContainerNW1").ToString
            txtContainerGW1.Text = dr("ContainerGW1").ToString
            txtQtyContainer2.Text = dr("QtyContainer2").ToString
            txtContainerType2.Text = dr("ContainerType2").ToString
            txtContainerNW2.Text = dr("ContainerNW2").ToString
            txtContainerGW2.Text = dr("ContainerGW2").ToString
            dtpETD.Value = dr("ETD").ToString
            dtpETa.Value = dr("ETa").ToString
            txtDescriptionOfGoods.Text = dr("DescriptionOfGoods").ToString
            txtIdent.Text = dr("Ident").ToString
            currentLetter = dr("CurrentLetter").ToString
            txtMasterBLType.Text = dr("MasterBLType").ToString
            txtNoOfOriginalBL.Text = dr("NoOfOriginalBL").ToString
            txtTermOfPayment.Text = dr("TermOfPayment").ToString
            _IsNew = False
            MustSave = False
            LoadDataCharge()
            LoadDataCN()
            LoadDataDN()
            SetdigitText()
        End If
    End Sub

    Private Sub txtBookingNo_ButtonClick(sender As Object, e As EventArgs) Handles txtBookingNo.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT 
        [BookingNo],[BookingUser],[QuotationNo],[QuotationUser],[Shipper],[Shipperaddress],[ShipperContact]
        ,[ShipperRef],[Consignee],[Consigneeaddress],[ConsigneeContact],[ConsigneeRef],[NotifyParty]
        ,[Notifyaddress],[PlaceOfReceive],[PortOfLoading],[PortOfDischarge],[PlaceOfDelivery],[LocalVessel]
        ,[LocalVoy],[OceanVessel],[OceanVoy],[agentPartner],[agentaddress],[agentContact],[CustomerCoLoad]
        ,[Customeraddress],[CustomerContact],[Remark],[agentCoLoad],[CoLoadContact],[Vesselagent],[VesselContact]
        ,[VesselBooking],[PickDate],[PickLocation],[PickTime],[PickContact],[LoadDate],[LoadLocation],[LoadTime]
        ,[LoadContact],[ReturnDate],[ReturnLocation],[ReturnTime],[ReturnContact],[CloseRNDate],[CloseRNTime]
        ,[CloseSIDate],[CloseSITime],[CloseVGMDate],[CloseVGMTime],[MarkNumber],[Container],[PackageQty],[PackageType]
        ,[CBM],[PackageGW],[QtyContainer1],[ContainerType1],[ContainerNW1],[ContainerGW1],[QtyContainer2],[ContainerType2]
        ,[ContainerNW2],[ContainerGW2],[BookingType],[ETD],[ETa],[DescriptionOfGoods],[NoOfOriginalBL],[TermOfPayment]
        ,[BookingNoDate],[ShipperCode],[ConsigneeCode],[NotifyCode],[CustCode],[agentCode],[VesselCode],[PartnerCode]
        ,[Ident]  FROM Freight_BookingConfirm WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtBookingNo.Text = dr("BookingNo").ToString
            txtBookingUser.Text = dr("BookingUser").ToString
            txtQuotationNo.Text = dr("QuotationNo").ToString
            txtQuotaionUser.Text = dr("QuotationUser").ToString
            txtShipper.Text = dr("Shipper").ToString
            txtShipperaddress.Text = dr("Shipperaddress").ToString
            txtShipperContact.Text = dr("ShipperContact").ToString
            txtShipperRef.Text = dr("ShipperRef").ToString
            txtConsignee.Text = dr("Consignee").ToString
            txtConsigneeaddress.Text = dr("Consigneeaddress").ToString
            txtConsigneeContact.Text = dr("ConsigneeContact").ToString
            txtConsigneeRef.Text = dr("ConsigneeRef").ToString
            txtNotifyParty.Text = dr("NotifyParty").ToString
            txtNotifyaddress.Text = dr("Notifyaddress").ToString
            txtPlaceOfReceive.Text = dr("PlaceofReceive").ToString
            txtPortOfLoading.Text = dr("PortofLoading").ToString
            txtPortOfDischarge.Text = dr("PortofDischarge").ToString
            txtPlaceOfDelivery.Text = dr("PlaceofDelivery").ToString
            txtLocalVessel.Text = dr("LocalVessel").ToString
            txtLocalVoy.Text = dr("LocalVoy").ToString
            txtOceanVessel.Text = dr("OceanVessel").ToString
            txtOceanVoy.Text = dr("OceanVoy").ToString
            txtagentPartner.Text = dr("agentPartner").ToString
            txtagentaddress.Text = dr("agentaddress").ToString
            txtagentContact.Text = dr("agentContact").ToString
            txtMarkNumber.Text = dr("MarkNumber").ToString
            txtContainer.Text = dr("Container").ToString
            txtPackageQty.Text = dr("PackageQty").ToString
            txtPackageType.Text = dr("PackageType").ToString
            txtCBM.Text = dr("CBM").ToString
            txtVSLBKG.Text = dr("VesselBooking")
            txtPackageGW.Text = dr("PackageGW").ToString
            txtQtyContainer1.Text = dr("QtyContainer1").ToString
            txtContainerType1.Text = dr("ContainerType1").ToString
            txtContainerNW1.Text = dr("ContainerNW1").ToString
            txtContainerGW1.Text = dr("ContainerGW1").ToString
            txtQtyContainer2.Text = dr("QtyContainer2").ToString
            txtContainerType2.Text = dr("ContainerType2").ToString
            txtContainerNW2.Text = dr("ContainerNW2").ToString
            txtContainerGW2.Text = dr("ContainerGW2").ToString
            dtpETD.Value = dr("ETD").ToString
            dtpETa.Value = dr("ETa").ToString
            txtDescriptionOfGoods.Text = dr("DescriptionOfGoods").ToString
        End If
    End Sub

    Private Sub txtQuotationNo_ButtonClick(sender As Object, e As EventArgs) Handles txtQuotationNo.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT 
      [QuotationType]
      ,[QuotationNo]
      ,[QuotationDate]
      ,[Customer]
      ,[Customeraddress]
      ,[CustomerContact]
      ,[CustomerEmail1]
      ,[CustomerEmail2]
      ,[CreditTerm]
      ,[Factory]
      ,[FactoryContact]
      ,[Remark],CreateUser,[Ident]  FROM Freight_Quotation WHERE 1=1 and Active='1'", MainConnection)
        If isSearchOK Then
            txtQuotationNo.Text = dr("QuotationNo").ToString
            txtQuotaionUser.Text = dr("CreateUser").ToString
        End If
    End Sub

    Private Sub MetroGrid3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim dr As DataRow
        dr = PopUpSearch("SELECT 
        [QuotationType]
        ,[QuotationNo]
        ,[QuotationDate]
        ,[Customer]
        ,[Customeraddress]
        ,[CustomerContact]
        ,[CustomerEmail1]
        ,[CustomerEmail2]
        ,[CreditTerm]
        ,[Factory]
        ,[FactoryContact]
        ,[Remark],CreateUser,[Ident]  FROM Freight_Quotation WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtRefNo.Text = dr("QuotationNo").ToString
            SelectChargeData()
        End If
    End Sub
    Private Sub SelectChargeData()
        Try
            dgvCharge.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_QuotationDetail where QuotationNo='" & txtRefNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvCharge.Rows.Add("0", 'Ident
                           dt.Rows(i)(1).ToString(), 'QuotationDetailType
                           dt.Rows(i)(2).ToString(), 'SICode
                           "",
                           dt.Rows(i)(3).ToString(), 'SICodeDescription
                           dt.Rows(i)(4).ToString(), 'Remark
                           dt.Rows(i)(5).ToString(), 'Qty
                           dt.Rows(i)(6).ToString(), 'Tys
                           dt.Rows(i)(7).ToString(), 'Currency
                           CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
                           dt.Rows(i)(9).ToString(), 'UnitPrice
                           dt.Rows(i)(10).ToString(), 'Totalamount
                           CDbl(dt.Rows(i)(11).ToString()), 'VaT
                           CDbl(dt.Rows(i)(12).ToString()), 'WHT
                           CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT
                           CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT
                           CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
                           dt.Rows(i)(16).ToString(), 'QuotationNo
                           dt.Rows(i)(17).ToString(), 'active
                           "",
                           "",
                           "1"
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
    Private Sub LoadDataCharge()
        Try
            dgvCharge.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_HouseCharge where DocNo='" & txtBCFNo.Text & "' and active='1' and HBLNo='" & txtHouseBLNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvCharge.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                           dt.Rows(i)(1).ToString(), 'QuotationDetailType
                           dt.Rows(i)(2).ToString(), 'SICode
                           "",
                           dt.Rows(i)(3).ToString(), 'SICodeDescription
                           dt.Rows(i)(4).ToString(), 'Remark
                           dt.Rows(i)(5).ToString(), 'Qty
                           dt.Rows(i)(6).ToString(), 'Tys
                           dt.Rows(i)(7).ToString(), 'Currency
                           CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
                           dt.Rows(i)(9).ToString(), 'UnitPrice
                           dt.Rows(i)(10).ToString(), 'Totalamount
                           CDbl(dt.Rows(i)(11).ToString()), 'VaT
                           CDbl(dt.Rows(i)(12).ToString()), 'WHT
                           CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT
                           CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT
                           CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
                           dt.Rows(i)(16).ToString(), 'QuotationNo
                           dt.Rows(i)(17).ToString(), 'active
                           dt.Rows(i)(18).ToString(), 'DocNo
                           dt.Rows(i)(19).ToString(),
                           "0"
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
    Private Sub dgvCharge_Rowsadded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvCharge.RowsAdded
        Try
            Dim CBCell As New DataGridViewComboBoxCell()
            CBCell = dgvCharge.Rows(e.RowIndex).Cells(7)
            CBCell.Items.Add("CBM")
            CBCell.Items.Add("KGS")
            CBCell.Items.Add("TRIP")
            CBCell.Items.Add("SHP")
            CBCell.Items.Add("20GP")
            CBCell.Items.Add("20HQ")
            CBCell.Items.Add("40GP")
            CBCell.Items.Add("40HQ")
            CBCell.Items.Add("ISO TaNK")
            Dim UnitCell As New DataGridViewComboBoxCell()
            UnitCell = dgvCharge.Rows(e.RowIndex).Cells(8)
            UnitCell.Items.Add("THB")
            UnitCell.Items.Add("USD")
            UnitCell.Items.Add("CYN")
            UnitCell.Items.Add("JPY")
            UnitCell.Items.Add("KRW")
            UnitCell.Items.Add("VND")
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(0).Value = "0"
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(6).Value = "0"
            dgvCharge.Rows(e.RowIndex).Cells(1).Value = "CTC"
            dgvCharge.Rows(e.RowIndex).Cells(6).Value = "1" 'qty
            dgvCharge.Rows(e.RowIndex).Cells(9).Value = "1" 'exc
            dgvCharge.Rows(e.RowIndex).Cells(18).Value = "1" 'active
            'If _IsNew Then
            '    dgvCharge.Rows(e.RowIndex).Cells(21).Value = "1" 'new
            'Else
            '    dgvCharge.Rows(e.RowIndex).Cells(21).Value = "0" 'new
            'End If
            If dgvCharge.Rows(e.RowIndex).IsNewRow Then
                dgvCharge.Rows(e.RowIndex).Cells(21).Value = "1" 'new
            Else
                dgvCharge.Rows(e.RowIndex).Cells(21).Value = "0" 'new
            End If
            dgvCharge.Rows(e.RowIndex).Cells(22).Value = UserProfile.U_Code
            dgvCharge.Rows(e.RowIndex).Cells(23).Value = txtHouseBLNo.Text
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(11).Value = txtQuotationNo.Text
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(12).Value = "0" 'Isnew
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(13).Value = "1" 'active
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvCostDN_Rowsadded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvCostDN.RowsAdded
        Try
            Dim CBCell As New DataGridViewComboBoxCell()
            CBCell = dgvCostDN.Rows(e.RowIndex).Cells(7)
            CBCell.Items.Add("CBM")
            CBCell.Items.Add("KGS")
            CBCell.Items.Add("TRIP")
            CBCell.Items.Add("SHP")
            CBCell.Items.Add("20GP")
            CBCell.Items.Add("20HQ")
            CBCell.Items.Add("40GP")
            CBCell.Items.Add("40HQ")
            CBCell.Items.Add("ISO TaNK")
            Dim UnitCell As New DataGridViewComboBoxCell()
            UnitCell = dgvCostDN.Rows(e.RowIndex).Cells(8)
            UnitCell.Items.Add("THB")
            UnitCell.Items.Add("USD")
            UnitCell.Items.Add("CYN")
            UnitCell.Items.Add("JPY")
            UnitCell.Items.Add("KRW")
            UnitCell.Items.Add("VND")
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(0).Value = "0"
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(6).Value = "0"
            dgvCostDN.Rows(e.RowIndex).Cells(1).Value = "CTC"
            dgvCostDN.Rows(e.RowIndex).Cells(6).Value = "1" 'qty
            dgvCostDN.Rows(e.RowIndex).Cells(9).Value = "1" 'exc
            dgvCostDN.Rows(e.RowIndex).Cells(18).Value = "1" 'active
            If dgvCostDN.Rows(e.RowIndex).IsNewRow Then
                dgvCostDN.Rows(e.RowIndex).Cells(20).Value = "1" 'new
            Else
                dgvCostDN.Rows(e.RowIndex).Cells(20).Value = "0" 'new
            End If

            dgvCostDN.Rows(e.RowIndex).Cells(21).Value = UserProfile.U_Code  'UserProfile.U_FName & " " & UserProfile.U_LName
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(11).Value = txtQuotationNo.Text
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(12).Value = "0" 'Isnew
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(13).Value = "1" 'active
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvCostCN_Rowsadded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvCostCN.RowsAdded
        Try
            Dim CBCell As New DataGridViewComboBoxCell()
            CBCell = dgvCostCN.Rows(e.RowIndex).Cells(7)
            CBCell.Items.Add("CBM")
            CBCell.Items.Add("KGS")
            CBCell.Items.Add("TRIP")
            CBCell.Items.Add("SHP")
            CBCell.Items.Add("20GP")
            CBCell.Items.Add("20HQ")
            CBCell.Items.Add("40GP")
            CBCell.Items.Add("40HQ")
            CBCell.Items.Add("ISO TaNK")
            Dim UnitCell As New DataGridViewComboBoxCell()
            UnitCell = dgvCostCN.Rows(e.RowIndex).Cells(8)
            UnitCell.Items.Add("THB")
            UnitCell.Items.Add("USD")
            UnitCell.Items.Add("CYN")
            UnitCell.Items.Add("JPY")
            UnitCell.Items.Add("KRW")
            UnitCell.Items.Add("VND")
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(0).Value = "0"
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(6).Value = "0"
            dgvCostCN.Rows(e.RowIndex).Cells(1).Value = "CTC"
            dgvCostCN.Rows(e.RowIndex).Cells(6).Value = "1" 'qty
            dgvCostCN.Rows(e.RowIndex).Cells(18).Value = "1" 'active
            If dgvCostCN.Rows(e.RowIndex).IsNewRow Then
                dgvCostCN.Rows(e.RowIndex).Cells(20).Value = "1" 'new
                dgvCostCN.Rows(e.RowIndex).Cells(0).Value = "0"
                dgvCostCN.Rows(e.RowIndex).Cells(9).Value = "1" 'exc
            Else
                dgvCostCN.Rows(e.RowIndex).Cells(20).Value = "0" 'new
            End If

            dgvCostCN.Rows(e.RowIndex).Cells(21).Value = UserProfile.U_Code  'UserProfile.U_FName & " " & UserProfile.U_LName
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(11).Value = txtQuotationNo.Text
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(12).Value = "0" 'Isnew
            'dgvCustomsClearance.Rows(e.RowIndex).Cells(13).Value = "1" 'active
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If txtBCFNo.Text = "" Then
            MsgBox("Pls Save HouseBL First")
            Exit Sub
        Else
            SaveCharge()
        End If
    End Sub
    Private Sub SaveCharge()
        Try
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a As Integer = 0
            For row As Integer = 0 To dgvCharge.Rows.Count - 2
                Try
                    Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_HouseCharge ")
                    SQLcommand.Append("'" & CInt(dgvCharge.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.Append(",'" & dgvCharge.Rows(row).Cells(1).Value & "'") 'DetailType
                    SQLcommand.Append(",'" & dgvCharge.Rows(row).Cells(2).Value & "'") 'SICode
                    SQLcommand.Append(",'" & dgvCharge.Rows(row).Cells(4).Value & "'") 'SICode Description
                    SQLcommand.Append(",'" & dgvCharge.Rows(row).Cells(5).Value & "'") 'Remark
                    SQLcommand.Append(",'" & CDbl(dgvCharge.Rows(row).Cells(6).Value) & "'") 'Qty
                    SQLcommand.Append(",'" & dgvCharge.Rows(row).Cells(7).Value & "'") 'Tys
                    SQLcommand.Append(",'" & dgvCharge.Rows(row).Cells(8).Value & "'") 'CUr
                    SQLcommand.Append(",'" & dgvCharge.Rows(row).Cells(9).Value & "'") 'EXC
                    SQLcommand.Append(",'" & CDbl(dgvCharge.Rows(row).Cells(10).Value) & "'") 'UnitPrice
                    SQLcommand.Append(",'" & CDbl(dgvCharge.Rows(row).Cells(11).Value) & "'") 'Total
                    SQLcommand.Append(",'" & CDbl(dgvCharge.Rows(row).Cells(12).Value) & "'") 'VaT
                    SQLcommand.Append(",'" & CDbl(dgvCharge.Rows(row).Cells(13).Value) & "'") 'WHT
                    SQLcommand.Append(",'" & CDbl(dgvCharge.Rows(row).Cells(14).Value) & "'") 'TotalamtPlusVat
                    SQLcommand.Append(",'" & CDbl(dgvCharge.Rows(row).Cells(15).Value) & "'") 'TotalamtMinusWHT
                    SQLcommand.Append(",'" & CDbl(dgvCharge.Rows(row).Cells(16).Value) & "'") 'NetPayment
                    SQLcommand.Append(",'" & dgvCharge.Rows(row).Cells(17).Value & "'") 'Quotation
                    SQLcommand.Append(",'" & CInt(dgvCharge.Rows(row).Cells(18).Value) & "'")
                    SQLcommand.Append(",'" & txtBCFNo.Text & "'")
                    SQLcommand.Append(",'" & dgvCharge.Rows(row).Cells(22).Value & "'")
                    SQLcommand.Append(",'" & dgvCharge.Rows(row).Cells(23).Value & "'")
                    SQLcommand.append(",'" & CInt(dgvCharge.Rows(row).Cells(21).Value) & "'") 'IsNew
                    Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                    Else
                        a += 1
                    End If
                Catch ex As Exception
                    a += 1
                    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try
            Next
            nection.Close()
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataCharge()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As Eventargs) Handles Button13.Click
        dgvCharge.CurrentRow.Cells(18).Value = 0
        MsgBox("กดปุ่มเซฟเพื่อยืนยันการยกเลิก")
    End Sub

    Private Sub Button17_Click(sender As Object, e As Eventargs) Handles Button17.Click
        Dim dr As DataRow
        dr = PopUpSearch("SELECT 
        [QuotationType]
        ,[QuotationNo]
        ,[QuotationDate]
        ,[Customer]
        ,[CustomerAddress]
        ,[CustomerContact]
        ,[CustomerEmail1]
        ,[CustomerEmail2]
        ,[CreditTerm]
        ,[Factory]
        ,[FactoryContact]
        ,[Remark]
        ,[CustCode]
        ,[FactoryCode]
        ,[CreateUser],[Ident]  FROM Freight_Quotation WHERE QuotationType='OVERSEA'", MainConnection)
        If isSearchOK Then
            txtDNRefNo.Text = dr("QuotationNo").ToString
            SelectDNData()
        End If
    End Sub
    Private Sub SelectDNData()
        Try
            dgvCostDN.Rows.Clear()
            Dim da As OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_QuotationDetail where QuotationNo='" & txtDNRefNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvCostDN.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                           dt.Rows(i)(1).ToString(), 'QuotationDetailType
                           dt.Rows(i)(2).ToString(), 'SICode
                           "",
                           dt.Rows(i)(3).ToString(), 'SICodeDescription
                           dt.Rows(i)(4).ToString(), 'Remark
                           dt.Rows(i)(5).ToString(), 'Qty
                           dt.Rows(i)(6).ToString(), 'Tys
                           dt.Rows(i)(7).ToString(), 'Currency
                           CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
                           dt.Rows(i)(9).ToString(), 'UnitPrice
                           dt.Rows(i)(10).ToString(), 'Totalamount
                           CDbl(dt.Rows(i)(11).ToString()), 'VaT
                           CDbl(dt.Rows(i)(12).ToString()), 'WHT
                           CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT
                           CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT
                           CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
                           dt.Rows(i)(16).ToString(), 'QuotationNo
                           dt.Rows(i)(17).ToString() 'active
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

    Private Sub SavDN()
        Try
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a As Integer = 0
            For row As Integer = 0 To dgvCostDN.Rows.Count - 2
                Try
                    Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_HouseDN ")
                    SQLcommand.append("'" & CInt(dgvCostDN.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.append(",'" & dgvCostDN.Rows(row).Cells(1).Value & "'") 'DetailType
                    SQLcommand.append(",'" & dgvCostDN.Rows(row).Cells(2).Value & "'") 'SICode
                    SQLcommand.append(",'" & dgvCostDN.Rows(row).Cells(4).Value & "'") 'SICode Description
                    SQLcommand.append(",'" & dgvCostDN.Rows(row).Cells(5).Value & "'") 'Remark
                    SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(6).Value) & "'") 'Qty
                    SQLcommand.append(",'" & dgvCostDN.Rows(row).Cells(7).Value & "'") 'Tys
                    SQLcommand.append(",'" & dgvCostDN.Rows(row).Cells(8).Value & "'") 'CUr
                    SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(9).Value) & "'") 'EXC
                    SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(10).Value) & "'") 'UnitPrice
                    SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(11).Value) & "'") 'Total
                    SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(12).Value) & "'") 'VaT
                    SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(13).Value) & "'") 'WHT
                    SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(14).Value) & "'") 'TotalamtPlusVat
                    SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(15).Value) & "'") 'TotalamtMinusWHT
                    SQLcommand.Append(",'" & CDbl(dgvCostDN.Rows(row).Cells(16).Value) & "'") 'NetPayment
                    SQLcommand.append(",'" & dgvCostDN.Rows(row).Cells(17).Value & "'") 'Quotation
                    SQLcommand.append(",'" & CInt(dgvCostDN.Rows(row).Cells(18).Value) & "'")
                    SQLcommand.Append(",'" & txtBCFNo.Text & "'")
                    SQLcommand.Append(",'" & txtHouseBLNo.Text & "'")
                    SQLcommand.Append(",'" & txtMasterBLNo.Text & "'")
                    SQLcommand.Append(",''")
                    'SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(21).Value & "'")
                    SQLcommand.Append(",'" & UserProfile.U_FName & " " & UserProfile.U_LName & "'")
                    SQLcommand.Append(",'" & dgvCostDN.Rows(row).Cells(20).Value & "'")
                    Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                    Else
                        a += 1
                    End If
                Catch ex As Exception
                    a += 1
                    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try
            Next
            nection.Close()
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataDN()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub Button11_Click(sender As Object, e As Eventargs) Handles Button11.Click
        If txtBCFNo.Text = "" Then
            MsgBox("Pls Save HouseBL First")
            Exit Sub
        Else
            SavDN()
        End If

    End Sub
    Private Sub LoadDataDN()
        Try
            dgvCostDN.Rows.Clear()
            Dim da As OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_HouseDN where DocNo='" & txtBCFNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvCostDN.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                           dt.Rows(i)(1).ToString(), 'QuotationDetailType
                           dt.Rows(i)(2).ToString(), 'SICode
                           "",
                           dt.Rows(i)(3).ToString(), 'SICodeDescription
                           dt.Rows(i)(4).ToString(), 'Remark
                           dt.Rows(i)(5).ToString(), 'Qty
                           dt.Rows(i)(6).ToString(), 'Tys
                           dt.Rows(i)(7).ToString(), 'Currency
                           CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
                           dt.Rows(i)(9).ToString(), 'UnitPrice
                           dt.Rows(i)(10).ToString(), 'Totalamount
                           CDbl(dt.Rows(i)(11).ToString()), 'VaT
                           CDbl(dt.Rows(i)(12).ToString()), 'WHT
                           CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT
                           CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT
                           CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
                           dt.Rows(i)(16).ToString(), 'QuotationNo
                           dt.Rows(i)(17).ToString(), 'active
                           dt.Rows(i)(18).ToString(), 'DocNo
                           "0"
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

    Private Sub Button7_Click(sender As Object, e As Eventargs) Handles Button7.Click
        dgvCostDN.CurrentRow.Cells(18).Value = 0
        MsgBox("กดปุ่มเซฟเพื่อยืนยันการยกเลิก")
    End Sub

    Private Sub Button18_Click(sender As Object, e As Eventargs) Handles Button18.Click
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100)
        [CostType]
      ,[CostNo]
      ,[CostDate]
      ,[Vendor]
      ,[Vendoraddress]
      ,[VendorContact]
      ,[VendorEmail1]
      ,[VendorEmail2]
      ,[CreditTerm]
      ,[actualVendor]
      ,[actualVendorContact]
      ,[Remark]
      ,[VenCode]
      ,[actVenCode]
      ,[CreateUser],[Ident]  FROM Freight_Cost WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtCNRefNo.Text = dr("CostNo").ToString
            SelectCNData()
        End If
    End Sub
    Private Sub SelectCNData()
        Try
            dgvCostCN.Rows.Clear()
            Dim da As OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_CostDetail where CostNo='" & txtCNRefNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvCostCN.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                           dt.Rows(i)(1).ToString(), 'QuotationDetailType
                           dt.Rows(i)(2).ToString(), 'SICode
                           "",
                           dt.Rows(i)(3).ToString(), 'SICodeDescription
                           dt.Rows(i)(4).ToString(), 'Remark
                           dt.Rows(i)(5).ToString(), 'Qty
                           dt.Rows(i)(6).ToString(), 'Tys
                           dt.Rows(i)(7).ToString(), 'Currency
                           CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
                           dt.Rows(i)(9).ToString(), 'UnitPrice
                           dt.Rows(i)(10).ToString(), 'Totalamount
                           CDbl(dt.Rows(i)(11).ToString()), 'VaT
                           CDbl(dt.Rows(i)(12).ToString()), 'WHT
                           CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT
                           CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT
                           CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
                           dt.Rows(i)(16).ToString(), 'QuotationNo
                           dt.Rows(i)(17).ToString(), 'active
                           "0"
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
    Private Sub SaveCN()
        Try
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a As Integer = 0
            For row As Integer = 0 To dgvCostCN.Rows.Count - 2
                Try
                    Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_HouseCN ")
                    SQLcommand.append("'" & CInt(dgvCostCN.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.append(",'" & dgvCostCN.Rows(row).Cells(1).Value & "'") 'DetailType
                    SQLcommand.append(",'" & dgvCostCN.Rows(row).Cells(2).Value & "'") 'SICode
                    SQLcommand.append(",'" & dgvCostCN.Rows(row).Cells(4).Value & "'") 'SICode Description
                    SQLcommand.append(",'" & dgvCostCN.Rows(row).Cells(5).Value & "'") 'Remark
                    SQLcommand.append(",'" & CInt(dgvCostCN.Rows(row).Cells(6).Value) & "'") 'Qty
                    SQLcommand.append(",'" & dgvCostCN.Rows(row).Cells(7).Value & "'") 'Tys
                    SQLcommand.append(",'" & dgvCostCN.Rows(row).Cells(8).Value & "'") 'CUr
                    SQLcommand.Append(",'" & CDbl(dgvCostCN.Rows(row).Cells(9).Value) & "'") 'EXC
                    SQLcommand.Append(",'" & CDbl(dgvCostCN.Rows(row).Cells(10).Value) & "'") 'UnitPrice
                    SQLcommand.Append(",'" & CDbl(dgvCostCN.Rows(row).Cells(11).Value) & "'") 'Total
                    SQLcommand.Append(",'" & CDbl(dgvCostCN.Rows(row).Cells(12).Value) & "'") 'VaT
                    SQLcommand.Append(",'" & CDbl(dgvCostCN.Rows(row).Cells(13).Value) & "'") 'WHT
                    SQLcommand.Append(",'" & CDbl(dgvCostCN.Rows(row).Cells(14).Value) & "'") 'TotalamtPlusVat
                    SQLcommand.Append(",'" & CDbl(dgvCostCN.Rows(row).Cells(15).Value) & "'") 'TotalamtMinusWHT
                    SQLcommand.Append(",'" & CDbl(dgvCostCN.Rows(row).Cells(16).Value) & "'") 'NetPayment
                    SQLcommand.Append(",'" & dgvCostCN.Rows(row).Cells(17).Value & "'") 'Quotation
                    SQLcommand.append(",'" & CInt(dgvCostCN.Rows(row).Cells(18).Value) & "'")
                    SQLcommand.Append(",'" & txtBCFNo.Text & "'")
                    SQLcommand.Append(",'" & txtHouseBLNo.Text & "'")
                    SQLcommand.Append(",'" & txtMasterBLNo.Text & "'")
                    SQLcommand.Append(",'" & dgvCostCN.Rows(row).Cells(21).Value & "'")
                    SQLcommand.Append(",'" & dgvCostCN.Rows(row).Cells(20).Value & "'")
                    Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                    Else
                        a += 1
                    End If
                Catch ex As Exception
                    a += 1
                    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try
            Next
            nection.Close()
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataCN()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataCN()
        Try
            dgvAdvReq.Rows.Clear()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter()
            Dim dt As DataTable = New DataTable()
            Dim nection As New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_AdvRequestDetail where 1=1 and DocNo='" & txtADVNo.Text & "'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgvAdvReq.Rows.Add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'AdvType
                    dt.Rows(i)(2).ToString(), 'SICode
                    "",
                    dt.Rows(i)(3).ToString(), 'SICodeDescription
                    dt.Rows(i)(4).ToString(), 'AdvRemark
                    dt.Rows(i)(5).ToString(), 'QTY
                    dt.Rows(i)(6).ToString(), 'Tys
                    dt.Rows(i)(7).ToString(), 'Currency
                    CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
                    CDbl(dt.Rows(i)(9).ToString()), 'UnitPrice
                    CDbl(dt.Rows(i)(10).ToString()), 'Total
                    CDbl(dt.Rows(i)(11).ToString()), 'VAT
                    CDbl(dt.Rows(i)(12).ToString()), 'WHT
                    CDbl(dt.Rows(i)(13).ToString()), 'TotalAmtPlusVAT
                    CDbl(dt.Rows(i)(14).ToString()), 'TotalAmtMinusWHT
                    CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
                    dt.Rows(i)(16).ToString(), 'QuotationNo
                    dt.Rows(i)(17).ToString(), 'Active
                    dt.Rows(i)(18).ToString(), 'BCFNo
                    dt.Rows(i)(19).ToString(), 'DocNo
                    dt.Rows(i)(20).ToString(), 'ROWNo
                    dt.Rows(i)(21).ToString(), 'HBLNo
                    dt.Rows(i)(22).ToString(), 'MBLNo
                    "0", 'PVNo
                    "1", 'SysUser
                    dt.Rows(i)(25).ToString()  'VendorName
        )
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        'Try
        '    dgvCostCN.Rows.Clear()
        '    Dim da As OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
        '    Dim dt As DataTable = New DataTable()
        '    Dim nection As New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim str As String = "SELECT * FROM Freight_HouseCN where DocNo='" & txtBCFNo.Text & "' and active='1'"
        '    da.SelectCommand = New OleDbCommand(str, nection)
        '    da.Fill(dt)
        '    If dt.Rows.Count > 0 Then
        '        For i As Integer = 0 To dt.Rows.Count - 1
        '            dgvCostCN.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
        '                   dt.Rows(i)(1).ToString(), 'QuotationDetailType
        '                   dt.Rows(i)(2).ToString(), 'SICode
        '                   "",
        '                   dt.Rows(i)(3).ToString(), 'SICodeDescription
        '                   dt.Rows(i)(4).ToString(), 'Remark
        '                   dt.Rows(i)(5).ToString(), 'Qty
        '                   dt.Rows(i)(6).ToString(), 'Tys
        '                   dt.Rows(i)(7).ToString(), 'Currency
        '                   CDbl(dt.Rows(i)(8).ToString()), 'ExchangeRate
        '                   dt.Rows(i)(9).ToString(), 'UnitPrice
        '                   dt.Rows(i)(10).ToString(), 'Totalamount
        '                   CDbl(dt.Rows(i)(11).ToString()), 'VaT
        '                   CDbl(dt.Rows(i)(12).ToString()), 'WHT
        '                   CDbl(dt.Rows(i)(13).ToString()), 'TotalamtPlusVaT
        '                   CDbl(dt.Rows(i)(14).ToString()), 'TotalamtMinusWHT
        '                   CDbl(dt.Rows(i)(15).ToString()), 'NetPayment
        '                   dt.Rows(i)(16).ToString(), 'QuotationNo
        '                   dt.Rows(i)(17).ToString(), 'active
        '                   dt.Rows(i)(18).ToString(), 'DocNo
        '                   "0"
        '                    )
        '        Next
        '        da = Nothing
        '        dt = Nothing
        '        nection.Close()
        '    End If
        'Catch ex As Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As Eventargs) Handles Button2.Click
        If txtBCFNo.Text = "" Then
            MsgBox("Pls Save HouseBL First")
            Exit Sub
        Else
            SaveCN()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As Eventargs) Handles Button8.Click
        dgvCostCN.CurrentRow.Cells(18).Value = 0
        MsgBox("กดปุ่มเซฟเพื่อยืนยันการยกเลิก")
    End Sub

    Private Sub txtShipper_ButtonClick(sender As Object, e As Eventargs) Handles txtShipper.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail  FROM Mas_Customer WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtShipper.Text = dr("CustName").ToString
            txtShipperaddress.Text = dr("Taddress").ToString
            txtShipperContact.Text = (dr("CustContact") + " " + dr("CustPhone") + " " + dr("CustFax")).ToString
        End If
    End Sub

    Private Sub txtConsignee_ButtonClick(sender As Object, e As Eventargs) Handles txtConsignee.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail  FROM Mas_Customer WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtConsignee.Text = dr("CustName").ToString
            txtConsigneeaddress.Text = dr("Taddress").ToString
            txtConsigneeContact.Text = (dr("CustContact") + " " + dr("CustPhone") + " " + dr("CustFax")).ToString
        End If
    End Sub

    Private Sub txtNotifyParty_ButtonClick(sender As Object, e As Eventargs) Handles txtNotifyParty.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail  FROM Mas_Customer WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtNotifyParty.Text = dr("CustName").ToString
            txtNotifyaddress.Text = dr("Taddress").ToString
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As Eventargs) Handles Button12.Click
        PreInv.txtBCFNo.Text = txtBCFNo.Text
        PreInv.txtMasterBLNo.Text = txtMasterBLNo.Text
        If txtHouseType.Text.Contains("Import") Then
            PreInv.txtCustomer.Text = txtShipper.Text
            PreInv.txtCustomeraddress.Text = txtShipperaddress.Text
        Else
            PreInv.txtCustomer.Text = txtConsignee.Text
            PreInv.txtCustomeraddress.Text = txtConsigneeaddress.Text
        End If
        PreInv.txtPortOfLoading.Text = txtPortOfLoading.Text
        PreInv.txtPortOfDischarge.Text = txtPortOfDischarge.Text
        PreInv.txtHouseBLNo.Text = txtHouseBLNo.Text
        PreInv.txtVesselBooking.Text = txtVSLBKG.Text
        PreInv.ShowDialog()
    End Sub

    Private Sub HouseBL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_IsNew = True
        'MsgBox(IsNotMaster)
        txtSysUser.Text = UserProfile.U_FName + " " + UserProfile.U_LName
        If IsNotMaster = False Then
            If IsNotNew = True Then
                LoadCurrentLetter()
                LoadHBL()
                '  MsgBox(_IsNew)
                LoadDataCharge()
                LoadDataCN()
                LoadDataDN()
            End If
        Else
            currentLetter = "A"
        End If
        SetdigitText()

        'MustSave = True
        'LoadDataToHouseBL()
    End Sub
    Private Sub LoadHBL()
        Dim dr As DataRow
        Dim sqlstr As String = "SELECT * from [Freight_HouseBL] where BCFNo='" & txtBCFNo.Text & "' and HBLNo='" & txtHouseBLNo.Text & "' and MBLNo='" & txtMasterBLNo.Text & "'"
        dr = SelectSingleRow(sqlstr)
        If Not IsNothing(dr) Then

            'txtIdent.Text = dr("Ident").ToString()
            txtHouseType.Text = dr("HouseType").ToString()
            'txtBCFNo.Text = dr("BCFNo").ToString()
            txtVSLBKG.Text = dr("VSLBKG").ToString()
            'txtMasterBLNo.Text = dr("MBLNo").ToString()
            txtShipper.Text = dr("Shipper").ToString()
            txtShipperaddress.Text = dr("ShipperAddress").ToString()
            txtShipperContact.Text = dr("ShipperContact").ToString()
            txtShipperRef.Text = dr("ShipperRef").ToString()
            txtConsignee.Text = dr("Consignee").ToString()
            txtConsigneeaddress.Text = dr("ConsigneeAddress").ToString()
            txtConsigneeContact.Text = dr("ConsigneeContact").ToString()
            txtConsigneeRef.Text = dr("ConsigneeRef").ToString()
            txtNotifyParty.Text = dr("NotifyParty").ToString()
            txtNotifyaddress.Text = dr("NotifyAddress").ToString()
            txtPlaceOfReceive.Text = dr("PlaceOfReceive").ToString()
            txtPortOfLoading.Text = dr("PortOfLoading").ToString()
            txtPortOfDischarge.Text = dr("PortOfDischarge").ToString()
            txtPlaceOfDelivery.Text = dr("PlaceOfDelivery").ToString()
            txtLocalVessel.Text = dr("LocalVessel").ToString()
            txtLocalVoy.Text = dr("LocalVoy").ToString()
            txtOceanVessel.Text = dr("OceanVessel").ToString()
            txtOceanVoy.Text = dr("OceanVoy").ToString()
            txtagentPartner.Text = dr("AgentPartner").ToString()
            txtagentaddress.Text = dr("AgentAddress").ToString()
            txtagentContact.Text = dr("AgentContact").ToString()
            txtMarkNumber.Text = dr("MarkNumber").ToString()
            txtContainer.Text = dr("Container").ToString()
            txtPackageQty.Text = dr("PackageQty").ToString()
            txtPackageType.Text = dr("PackageType").ToString()
            txtCBM.Text = dr("CBM").ToString()
            txtPackageGW.Text = dr("PackageGW").ToString()
            txtQtyContainer1.Text = dr("QtyContainer1").ToString()
            txtContainerType1.Text = dr("ContainerType1").ToString()
            txtContainerNW1.Text = dr("ContainerNW1").ToString()
            txtContainerGW1.Text = dr("ContainerGW1").ToString()
            txtQtyContainer2.Text = dr("QtyContainer2").ToString()
            txtContainerType2.Text = dr("ContainerType2").ToString()
            txtContainerNW2.Text = dr("ContainerNW2").ToString()
            txtContainerGW2.Text = dr("ContainerGW2").ToString()
            txtMasterBLType.Text = dr("MasterBLType").ToString()
            dtpETD.Value = CDate(dr("ETD")).ToString()
            dtpETa.Text = CDate(dr("ETA")).ToString()
            txtDescriptionOfGoods.Text = dr("DescriptionOfGoods").ToString()
            txtNoOfOriginalBL.Text = dr("NoOfOriginalBL").ToString()
            txtTermOfPayment.Text = dr("TermOfPayment").ToString()
            txtQuotationNo.Text = dr("QuotationNo").ToString()
            txtQuotaionUser.Text = dr("QuotaionUser").ToString()
            txtBookingNo.Text = dr("BookingNo").ToString()
            txtBookingUser.Text = dr("BookingUser").ToString()
            'txtHouseBLNo.Text = dr("HBLNo").ToString()
            'txtCurrentLetter.Text = dr("CurrentLetter").ToString()
            txtactive.Text = dr("Active").ToString()
            txtADVNo.Text = dr("ADVNo").ToString
        End If
    End Sub
    Private Sub GroupBox1_Enter(sender As Object, e As Eventargs) Handles GroupBox1.Enter

    End Sub
    Event DataGridView1ButtonClick(sender As DataGridView, e As DataGridViewCellEventargs)
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As DataGridViewCellEventargs) Handles dgvCharge.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent DataGridView1ButtonClick(senderGrid, e)
            dgvCharge.CurrentRow.Cells(18).Value = "1"
            'If dgvCharge.CurrentRow.Cells(21).Value < 0 Or dgvCharge.CurrentRow.Cells(21).Value = "" Then
            '    dgvCharge.CurrentRow.Cells(21).Value = "1"
            'ElseIf dgvCharge.CurrentRow.Cells(21).Value <> "0" Then
            '    dgvCharge.CurrentRow.Cells(21).Value = "0"
            'End If
        End If
    End Sub
    Private Sub DataGridView1_ButtonClick(sender As DataGridView, e As DataGridViewCellEventargs) Handles Me.DataGridView1ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("Select TOP(100) [accountGroup], [ItemName]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[SIGroup]  FROM [MaS_SICODE] WHERE 1=1", MainConnection)
        If isSearchOK Then
            dgvCharge.CurrentRow.Cells(2).Value = dr("SICode").ToString
            dgvCharge.CurrentRow.Cells(4).Value = dr("ItemName").ToString
            dgvCharge.CurrentRow.Cells(18).Value = "1"
            'dgvCharge.CurrentRow.Cells(21).Value = "1"
        End If
    End Sub
    Event DataGridView2ButtonClick(sender As DataGridView, e As DataGridViewCellEventargs)
    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As DataGridViewCellEventargs) Handles dgvCostDN.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent DataGridView2ButtonClick(senderGrid, e)
            dgvCostDN.CurrentRow.Cells(18).Value = "1"
            'If dgvCostDN.CurrentRow.Cells(20).Value = "" Then
            'dgvCostDN.CurrentRow.Cells(20).Value = "1"
            'Else
            'dgvCostDN.CurrentRow.Cells(20).Value = "0"
            'End If
        End If
    End Sub
    Private Sub DataGridView2_ButtonClick(sender As DataGridView, e As DataGridViewCellEventargs) Handles Me.DataGridView2ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("Select [accountGroup], [ItemName]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[SIGroup]  FROM [MaS_SICODE] WHERE SIGroup LIKE 'O%'", MainConnection)
        If isSearchOK Then
            dgvCostDN.CurrentRow.Cells(2).Value = dr("SICode").ToString
            dgvCostDN.CurrentRow.Cells(4).Value = dr("ItemName").ToString
            dgvCostDN.CurrentRow.Cells(18).Value = "1"
            'dgvCostDN.CurrentRow.Cells(20).Value = "1"
        End If
    End Sub

    Event DataGridView3ButtonClick(sender As DataGridView, e As DataGridViewCellEventargs)
    Private Sub DataGridView3_CellContentClick(sender As System.Object, e As DataGridViewCellEventargs) Handles dgvCostCN.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent DataGridView3ButtonClick(senderGrid, e)
            dgvCostCN.CurrentRow.Cells(18).Value = "1"
            If dgvCostCN.CurrentRow.Cells(20).Value <> "1" Or dgvCostCN.CurrentRow.Cells(20).Value <> "0" Then
                dgvCostCN.CurrentRow.Cells(20).Value = "1"
            Else
                dgvCostCN.CurrentRow.Cells(20).Value = "0"
            End If
        End If
    End Sub
    Private Sub DataGridView3_ButtonClick(sender As DataGridView, e As DataGridViewCellEventargs) Handles Me.DataGridView3ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("Select TOP(100) [accountGroup], [ItemName]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[SIGroup]  FROM [MaS_SICODE] WHERE 1=1", MainConnection)
        If isSearchOK Then
            dgvCostCN.CurrentRow.Cells(2).Value = dr("SICode").ToString
            dgvCostCN.CurrentRow.Cells(4).Value = dr("ItemName").ToString
            dgvCostCN.CurrentRow.Cells(18).Value = "1"
            dgvCostCN.CurrentRow.Cells(20).Value = "1"
        End If
    End Sub
    Private currentLetter As String = "A"
    Private Sub Button10_Click(sender As Object, e As Eventargs) Handles Button10.Click
        'If MustSave = True Then
        '    MsgBox("SaVe DaTa FiRsT!!!")
        '    Exit Sub
        'Else
        '    MsgBox("ADD MORE HOUSE BL")
        '    txtCurrentLetter.Text = currentLetter
        '    txtHouseBLNo.Text = txtMasterBLNo.Text
        '    txtHouseBLNo.Text = txtHouseBLNo.Text + txtCurrentLetter.Text
        '    UpdateCurrentLetter()
        '    addNewHouseBL()
        '    _IsNew = True
        'End If

        '  MsgBox("ADD MORE HOUSE BL")
        txtCurrentLetter.Text = currentLetter
        txtHouseBLNo.Text = txtMasterBLNo.Text
        txtHouseBLNo.Text = txtHouseBLNo.Text + txtCurrentLetter.Text
        UpdateCurrentLetter()
        addNewHouseBL()
        _IsNew = True

    End Sub
    Private Sub UpdateCurrentLetter()
        'If currentLetter = "Z" Then
        'currentLetter = "AA"
        'Else
        '    Dim lastChar As Char = currentLetter(currentLetter.Length - 1)
        '    If lastChar = "Z" Then
        '        Dim prefix As String = currentLetter.Substring(0, currentLetter.Length - 1)
        '        Dim newLastChar As Char = "A"
        '        currentLetter = prefix & newLastChar
        '    Else
        '        Dim newLastChar As Char = Chr(Asc(lastChar) + 1)
        '        currentLetter = currentLetter.Substring(0, currentLetter.Length - 1) & newLastChar
        '    End If
        'End If
        'MustSave = True
    End Sub
    Private Sub addNewHouseBL()
        txtVSLBKG.ResetText() 'VSLBKG
        txtShipper.ResetText() 'Shipper
        txtShipperaddress.ResetText() 'Shipperaddress
        txtShipperContact.ResetText() 'ShipperContact
        txtShipperRef.ResetText() 'ShipperRef 
        txtConsignee.ResetText() 'Consignee
        txtConsigneeaddress.ResetText() 'Consigneeaddress 
        txtConsigneeContact.ResetText() 'ConsigneeContact
        txtConsigneeRef.ResetText() 'ConsigneeRef 
        txtNotifyParty.ResetText() 'NotifyParty
        txtNotifyaddress.ResetText() 'Notifyaddress
    End Sub
    Private Sub txtPackageType_ButtonClick(sender As Object, e As Eventargs) Handles txtPackageType.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) PackageCode,PackageDescription  FROM Freight_PackageType WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPackageType.Text = dr("PackageCode").ToString
        End If
    End Sub
    Private Sub txtContainerType1_ButtonClick(sender As Object, e As Eventargs) Handles txtContainerType1.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) ContainerType FROM Freight_ContainerType WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtContainerType1.Text = dr("ContainerType").ToString
        End If
    End Sub
    Private Sub txtContainerType2_ButtonClick(sender As Object, e As Eventargs) Handles txtContainerType2.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) ContainerType FROM Freight_ContainerType WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtContainerType2.Text = dr("ContainerType").ToString
        End If
    End Sub
    Private Sub Button19_Click(sender As Object, e As Eventargs) Handles Button19.Click
        txtactive.Text = "0"
        MsgBox("Please Save To Confirm Your action!!!")
    End Sub
    Private Sub txtagentPartner_ButtonClick(sender As Object, e As Eventargs) Handles txtagentPartner.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [CustTaxID]
      ,[CustCompanyID]
      ,[CustBranch]
      ,[CustCompanyName]
      ,[CustCountry]
      ,[CustCity]
      ,[CustAddress]
      ,[CustEmail]
      ,[CustPhone]
      ,[CustFax]
      ,[CustPayable]
      ,[CustFactory]
      ,[CustCustomer]
      ,[UserName]
      ,[UserCode]
      ,[CustCompanyEName]
      ,[CustEAddress]  FROM Mas_CustomerFreight WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtagentPartner.Text = dr("CustCompanyName").ToString
            txtagentaddress.Text = dr("CustAddress").ToString
        End If
    End Sub
    Private Sub txtLocalVessel_ButtonClick(sender As Object, e As Eventargs) Handles txtLocalVessel.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [VesselCode]
        ,[RegisterNumber]
        ,[VesselName] 
        ,[VesselType] 
        ,[CountryCode]  FROM Mas_Vessel WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtLocalVessel.Text = dr("VesselName").ToString
        End If
    End Sub
    Private Sub txtOceanVessel_ButtonClick(sender As Object, e As Eventargs) Handles txtOceanVessel.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [VesselCode]
        ,[RegisterNumber]
        ,[VesselName]
        ,[VesselType]
        ,[CountryCode]  FROM Mas_Vessel WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtOceanVessel.Text = dr("VesselName").ToString
        End If
    End Sub
    Private Sub txtPlaceOfReceive_ButtonClick(sender As Object, e As EventArgs) Handles txtPlaceOfReceive.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPlaceOfReceive.Text = dr("PortName").ToString
        End If
    End Sub

    Private Sub txtPortOfLoading_ButtonClick(sender As Object, e As EventArgs) Handles txtPortOfLoading.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPortOfLoading.Text = dr("PortName").ToString
        End If
    End Sub

    Private Sub txtPortOfDischarge_ButtonClick(sender As Object, e As EventArgs) Handles txtPortOfDischarge.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPortOfDischarge.Text = dr("PortName").ToString
        End If
    End Sub

    Private Sub txtPlaceOfDelivery_ButtonClick(sender As Object, e As EventArgs) Handles txtPlaceOfDelivery.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPlaceOfDelivery.Text = dr("PortName").ToString
        End If
    End Sub
    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter
    End Sub
    Private Sub Button1_Click(sender As Object, e As Eventargs) Handles Button1.Click
        HouseadvRequest.txtBCFNo.Text = txtBCFNo.Text
        HouseadvRequest.txtHouseBL.Text = txtHouseBLNo.Text
        HouseadvRequest.txtMasterBL.Text = txtMasterBLNo.Text
        If txtADVNo.Text = "" Then
            HouseadvRequest._IsNew = True
            HouseadvRequest.IsCNorDN = True
        Else
            HouseadvRequest._IsNew = False
        End If

        HouseadvRequest.txtDocCreateNo.Text = txtADVNo.Text
        HouseadvRequest.ShowDialog()
        txtADVNo.Text = HouseadvRequest.txtDocCreateNo.Text
        SaveHouseBL(0)
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'HouseadvRequest.txtBCFNo.Text = txtBCFNo.Text
        'HouseadvRequest.IsCNorDN = False
        'HouseadvRequest.ShowDialog()
        Dim frm As New Debit
        frm.txtBCFNo.Text = txtBCFNo.Text
        frm.txtMasterBLNo.Text = txtMasterBLNo.Text
        frm.txtHouseBLNo.Text = txtHouseBLNo.Text
        frm.txtVesselBooking.Text = Me.txtVSLBKG.Text
        frm._DCTYP = "CN"
        'Debit.IsCNorDN = True
        frm.ShowDialog()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim url As String = "http://203.170.129.23/TESTFRIEGHT/report/HouseBL?BCFNo=" & txtBCFNo.Text & "&HBLNo=" & txtHouseBLNo.Text & "&MBLNo=" & txtMasterBLNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub dgvCharge_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCharge.CellEndEdit
        Try
            dgvCharge.CurrentRow.Cells(23).Value = txtHouseBLNo.Text
            dgvCharge.CurrentRow.Cells(11).Value = ((CDbl(dgvCharge.CurrentRow.Cells(6).Value) * CDbl(dgvCharge.CurrentRow.Cells(10).Value)) * CDbl(dgvCharge.CurrentRow.Cells(9).Value)).ToString("#,##0.00")
            dgvCharge.CurrentRow.Cells(14).Value = (CDbl(dgvCharge.CurrentRow.Cells(11).Value) + ((CDbl(dgvCharge.CurrentRow.Cells(12).Value) / 100)) * CDbl(dgvCharge.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvCharge.CurrentRow.Cells(15).Value = (CDbl(dgvCharge.CurrentRow.Cells(11).Value) - ((CDbl(dgvCharge.CurrentRow.Cells(13).Value) / 100)) * CDbl(dgvCharge.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvCharge.CurrentRow.Cells(16).Value = (CDbl(dgvCharge.CurrentRow.Cells(11).Value) + (CDbl(dgvCharge.CurrentRow.Cells(12).Value) / 100) * CDbl(dgvCharge.CurrentRow.Cells(11).Value) - (CDbl(dgvCharge.CurrentRow.Cells(13).Value) / 100) * CDbl(dgvCharge.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim frm As New Debit
        frm.txtBCFNo.Text = txtBCFNo.Text
        frm.txtMasterBLNo.Text = txtMasterBLNo.Text
        frm.txtHouseBLNo.Text = txtHouseBLNo.Text
        frm.txtVesselBooking.Text = Me.txtVSLBKG.Text
        frm._DCTYP = "DN"
        'Debit.IsCNorDN = True
        frm.ShowDialog()
    End Sub

    Private Sub dgvCharge_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCharge.CellValidated
        Try
            Select Case e.ColumnIndex
                Case 6 'float fields
                    sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("#,##0.0000")
                Case 9, 10, 11, 12, 13, 14, 15, 16 'float fields
                    sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("#,##0.00")
            End Select
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvCharge_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvCharge.CellValidating
        Try
            If sender.Rows.Count < 1 Then Exit Sub
            'is the user clicking on the column headers? 
            If e.RowIndex = -1 Then Exit Sub
            'is it the new row? 
            If sender.Rows(e.RowIndex).IsNewRow Then Exit Sub
            If CStr(e.FormattedValue) = Nothing Then Exit Sub

            Dim newValue As Double
            Select Case e.ColumnIndex
                Case 6, 9, 10, 11, 12, 13, 14, 15, 16
                    If Double.TryParse(e.FormattedValue, newValue) Then
                        'are there no changes being made? 
                        If newValue = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then Exit Sub
                    Else
                        'if the value can't be parsed into a decimal, then it is invalid 
                        e.Cancel = True
                    End If

            End Select

        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvCostDN_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostDN.CellEndEdit
        Try
            'dgvCostDN.CurrentRow.Cells(23).Value = txtHouseBLNo.Text
            dgvCostDN.CurrentRow.Cells(11).Value = ((CDbl(dgvCostDN.CurrentRow.Cells(6).Value) * CDbl(dgvCostDN.CurrentRow.Cells(10).Value)) * CDbl(dgvCostDN.CurrentRow.Cells(9).Value)).ToString("#,##0.00")
            dgvCostDN.CurrentRow.Cells(14).Value = (CDbl(dgvCostDN.CurrentRow.Cells(11).Value) + ((CDbl(dgvCostDN.CurrentRow.Cells(12).Value) / 100)) * CDbl(dgvCostDN.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvCostDN.CurrentRow.Cells(15).Value = (CDbl(dgvCostDN.CurrentRow.Cells(11).Value) - ((CDbl(dgvCostDN.CurrentRow.Cells(13).Value) / 100)) * CDbl(dgvCostDN.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvCostDN.CurrentRow.Cells(16).Value = (CDbl(dgvCostDN.CurrentRow.Cells(11).Value) + (CDbl(dgvCostDN.CurrentRow.Cells(12).Value) / 100) * CDbl(dgvCostDN.CurrentRow.Cells(11).Value) - (CDbl(dgvCostDN.CurrentRow.Cells(13).Value) / 100) * CDbl(dgvCostDN.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCostDN_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvCostDN.CellValidating
        Try
            If sender.Rows.Count < 1 Then Exit Sub
            'is the user clicking on the column headers? 
            If e.RowIndex = -1 Then Exit Sub
            'is it the new row? 
            If sender.Rows(e.RowIndex).IsNewRow Then Exit Sub
            If CStr(e.FormattedValue) = Nothing Then Exit Sub

            Dim newValue As Double
            Select Case e.ColumnIndex
                Case 6, 9, 10, 11, 12, 13, 14, 15, 16
                    If Double.TryParse(e.FormattedValue, newValue) Then
                        'are there no changes being made? 
                        If newValue = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then Exit Sub
                    Else
                        'if the value can't be parsed into a decimal, then it is invalid 
                        e.Cancel = True
                    End If

            End Select

        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvCostDN_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostDN.CellValidated
        Try
            Select Case e.ColumnIndex
                Case 6 'float fields
                    sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("#,##0.0000")
                Case 9, 10, 11, 12, 13, 14, 15, 16 'float fields
                    sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("#,##0.00")
            End Select
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvCostCN_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostCN.CellEndEdit
        Try
            'dgvCostCN.CurrentRow.Cells(23).Value = txtHouseBLNo.Text
            dgvCostCN.CurrentRow.Cells(11).Value = ((CDbl(dgvCostCN.CurrentRow.Cells(6).Value) * CDbl(dgvCostCN.CurrentRow.Cells(10).Value)) * CDbl(dgvCostCN.CurrentRow.Cells(9).Value)).ToString("#,##0.00")
            dgvCostCN.CurrentRow.Cells(14).Value = (CDbl(dgvCostCN.CurrentRow.Cells(11).Value) + ((CDbl(dgvCostCN.CurrentRow.Cells(12).Value) / 100)) * CDbl(dgvCostCN.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvCostCN.CurrentRow.Cells(15).Value = (CDbl(dgvCostCN.CurrentRow.Cells(11).Value) - ((CDbl(dgvCostCN.CurrentRow.Cells(13).Value) / 100)) * CDbl(dgvCostCN.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
            dgvCostCN.CurrentRow.Cells(16).Value = (CDbl(dgvCostCN.CurrentRow.Cells(11).Value) + (CDbl(dgvCostCN.CurrentRow.Cells(12).Value) / 100) * CDbl(dgvCostCN.CurrentRow.Cells(11).Value) - (CDbl(dgvCostCN.CurrentRow.Cells(13).Value) / 100) * CDbl(dgvCostCN.CurrentRow.Cells(11).Value)).ToString("#,##0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCostCN_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostCN.CellValidated
        Try
            Select Case e.ColumnIndex
                Case 6 'float fields
                    sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("#,##0.0000")
                Case 9, 10, 11, 12, 13, 14, 15, 16 'float fields
                    sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("#,##0.00")
            End Select
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub dgvCostCN_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvCostCN.CellValidating
        Try
            If sender.Rows.Count < 1 Then Exit Sub
            'is the user clicking on the column headers? 
            If e.RowIndex = -1 Then Exit Sub
            'is it the new row? 
            If sender.Rows(e.RowIndex).IsNewRow Then Exit Sub
            If CStr(e.FormattedValue) = Nothing Then Exit Sub

            Dim newValue As Double
            Select Case e.ColumnIndex
                Case 6, 9, 10, 11, 12, 13, 14, 15, 16
                    If Double.TryParse(e.FormattedValue, newValue) Then
                        'are there no changes being made? 
                        If newValue = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then Exit Sub
                    Else
                        'if the value can't be parsed into a decimal, then it is invalid 
                        e.Cancel = True
                    End If

            End Select

        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub txtPackageQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQtyContainer2.KeyPress, txtQtyContainer1.KeyPress, txtPackageQty.KeyPress, txtPackageGW.KeyPress, txtContainerNW2.KeyPress, txtContainerNW1.KeyPress, txtContainerGW2.KeyPress, txtContainerGW1.KeyPress, txtCBM.KeyPress
        CheckDouble(e)
        If e.KeyChar = Chr(Keys.Enter) Then
            SetdigitText()
        End If
    End Sub

    Private Sub txtPackageQty_Leave(sender As Object, e As EventArgs) Handles txtQtyContainer2.Leave, txtQtyContainer1.Leave, txtPackageQty.Leave, txtPackageGW.Leave, txtContainerNW2.Leave, txtContainerNW1.Leave, txtContainerGW2.Leave, txtContainerGW1.Leave, txtCBM.Leave
        SetdigitText()
    End Sub

    Private Sub txtPackageQty_Click(sender As Object, e As EventArgs) Handles txtQtyContainer2.Click, txtQtyContainer1.Click, txtPackageQty.Click, txtPackageGW.Click, txtContainerNW2.Click, txtContainerNW1.Click, txtContainerGW2.Click, txtContainerGW1.Click, txtCBM.Click
        SelectTextall(sender)
    End Sub
    Private Sub SetdigitText()

        SetDigit4(txtCBM)
        SetDigit(txtPackageQty)
        SetDigit(txtPackageGW)
        SetDigit(txtQtyContainer1)
        SetDigit(txtContainerNW1)
        SetDigit(txtContainerGW1)
        SetDigit(txtQtyContainer2)
        SetDigit(txtContainerNW2)
        SetDigit(txtContainerGW2)

    End Sub
    Private Function CheckDash(ByVal pkey As System.Windows.Forms.KeyPressEventArgs)

        If Asc(pkey.KeyChar) = 45 Then
            MetroFramework.MetroMessageBox.Show(Me, "ห้ามใส่ - เด็ดขาด กรุณากรอกข้อมูลให้ครบ", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Function

    Private Sub txtShipperContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtShipperRef.KeyPress, txtShipperContact.KeyPress, txtContainer.KeyPress, txtConsigneeRef.KeyPress, txtConsigneeContact.KeyPress, txtagentContact.KeyPress
        CheckDash(e)
    End Sub


    'Private Sub Button10_Click(sender as Object, e as Eventargs) Handles Button10.Click
    '    Try
    '        If MustSave = True Then
    '            MsgBox("SaVE FIRST!!!")
    '            Exit Sub
    '        End If
    '        txtHouseBLNo.Text = txtMasterBLNo.Text
    '        'txtHouseBLNo.Text = txtMasterBLNo.Text
    '        'txtSprintNo.Text = CInt(txtSprintNo.Text) + 1
    '        'txtHouseBLNo.Text = txtHouseBLNo.Text + txtSprintNo.Text
    '        'MsgBox(counter)
    '        Dim letter as Char = Chr(asc("a") + counter)
    '        txtaToZ.Text = letter.ToString()
    '        counter = (counter + 1)
    '        txtCounter.Text = counter
    '        txtCounter2.Text = counter2
    '        counter2 = (counter2 + 1)
    '        'txtHouseBLNo.Text = txtHouseBLNo.Text + txtaToZ.Text + txtSprintNo.Text
    '        'If txtaToZ.Text = "Z" Then
    '        '    counter = 0
    '        '    counter2 = 1
    '        '    MsgBox(counter)
    '        'End If
    '        If counter2 = 26 Then
    '            'MsgBox(counter2)
    '            counter = 0
    '        End If
    '        If counter2 >= 27 Then
    '            'MsgBox(counter2)
    '            'MsgBox(counter)
    '            'counter2 = 0
    '            txtHouseBLNo.Text = txtMasterBLNo.Text
    '            If txtaToZ.Text = "a" Then
    '                txtSprintNo.Text = CInt(txtSprintNo.Text) + 1
    '            End If
    '            txtHouseBLNo.Text = txtHouseBLNo.Text + txtaToZ.Text + txtSprintNo.Text
    '        Else
    '            txtHouseBLNo.Text = txtHouseBLNo.Text + txtaToZ.Text
    '        End If
    '        MustSave = True
    '    Catch ex as Exception
    '    End Try
    '    'Dim letter as Char = Chr(asc("a") + counter)
    '    'txtaToZ.Text = letter.ToString()
    '    'counter = (counter + 1)
    '    'txtHouseBLNo.Text = txtHouseBLNo.Text + txtaToZ.Text
    '    'If counter = 26 Then
    '    '    txtHouseBLNo.Text = txtMasterBLNo.Text
    '    '    txtSprintNo.Text = CInt(txtSprintNo.Text) + 1
    '    '    counter = 0
    '    '    txtHouseBLNo.Text = txtHouseBLNo.Text + txtaToZ.Text + txtSprintNo.Text
    '    'End If
    '    'Dim builder as New StringBuilder()
    '    'For letterCode as Integer = asc("a") To asc("Z")
    '    '    Dim letter as Char = Chr(letterCode)
    '    '    builder.append(letter)
    '    'Next
    '    'txtaToZ.Text = builder.ToString()
    'End Sub
End Class