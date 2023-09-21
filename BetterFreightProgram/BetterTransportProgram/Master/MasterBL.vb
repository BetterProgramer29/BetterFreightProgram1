Imports System.Data.OleDb
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text

Public Class MasterBL
    Public _IsNew as Boolean
    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click
#Region "Validate Input"
        If String.IsNullOrEmpty(txtMasterType.Text) Then
            txtMasterType.Focus()
            txtMasterType.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล MasterType ", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtMasterType.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVSLBKG.Text) Then
            txtVSLBKG.Focus()
            txtVSLBKG.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Vessel Booking (ของสายเรือ)  ", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtVSLBKG.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtMBLNo.Text) Then
            txtMBLNo.Focus()
            txtMBLNo.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Master B\L (ของสายเรือ)", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtMBLNo.Style = MetroFramework.MetroColorStyle.Default
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
        '    MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล QuotaionUser.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        '    MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล BookingNo.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'Else
        '    txtBookingUser.Style = MetroFramework.MetroColorStyle.Default
        'End If
        If String.IsNullOrEmpty(txtSysUser.Text) Then
            '    txtSysUser.Focus()
            '    txtSysUser.Style = MetroFramework.MetroColorStyle.Red
            '    Exit Sub
            'Else
            '    txtSysUser.Style = MetroFramework.MetroColorStyle.Default
            txtSysUser.Text = UserProfile.U_FName & " " & UserProfile.U_LName

        End If
#End Region


        If txtBCFNo.Text = "" Then
            If txtMasterBLType.Text.ToString.Contains("Export") Then
                GetRunningFormat("BCF")
                txtBCFNo.Text = CreateNumber("Freight_MasterBL", "BCFNo", dtpETD.Value)
            Else
                GetRunningFormat("BCF")
                txtBCFNo.Text = CreateNumber("Freight_MasterBL", "BCFNo", dtpETa.Value)
            End If
        End If
        If _IsNew = True Then
            SaveMasterBL(1)
        Else
            SaveMasterBL(0)
        End If
    End Sub
    Private Sub SaveMasterBL(_Insert as Integer)
        Try
            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_MasterBL ")
            SQLcommand.Append("'" & CInt(txtIdent.Text) & "'") 'Ident
            SQLcommand.append(",'" & txtMasterType.Text & "'") 'MasterType
            SQLcommand.append(",'" & txtBCFNo.Text & "'") 'BCFNo
            SQLcommand.append(",'" & txtVSLBKG.Text & "'") 'VSLBKG
            SQLcommand.append(",'" & txtMBLNo.Text & "'") 'MBLNo
            SQLcommand.append(",'" & txtShipper.Text & "'") 'Shipper
            SQLcommand.append(",'" & txtShipperaddress.Text & "'") 'Shipperaddress
            SQLcommand.append(",'" & txtShipperContact.Text & "'") 'ShipperContact
            SQLcommand.append(",'" & txtShipperRef.Text & "'") 'ShipperRef
            SQLcommand.append(",'" & txtConsignee.Text & "'") 'Consignee
            SQLcommand.append(",'" & txtConsigneeaddress.Text & "'") 'Consigneeaddress
            SQLcommand.append(",'" & txtConsigneeContact.Text & "'") 'ConsigneeContact
            SQLcommand.append(",'" & txtConsigneeRef.Text & "'") 'ConsigneeRef
            SQLcommand.append(",'" & txtNotifyParty.Text & "'") 'NotifyParty
            SQLcommand.append(",'" & txtNotifyaddress.Text & "'") 'Notifyaddress
            SQLcommand.append(",'" & txtPlaceOfReceive.Text & "'") 'PlaceOfReceive
            SQLcommand.append(",'" & txtPortOfLoading.Text & "'") 'PortOfLoading
            SQLcommand.append(",'" & txtPortOfDischarge.Text & "'") 'PortOfDischarge
            SQLcommand.append(",'" & txtPlaceOfDelivery.Text & "'") 'PlaceOfDelivery
            SQLcommand.append(",'" & txtLocalVessel.Text & "'") 'LocalVessel
            SQLcommand.append(",'" & txtLocalVoy.Text & "'") 'LocalVoy
            SQLcommand.append(",'" & txtOceanVessel.Text & "'") 'OceanVessel
            SQLcommand.append(",'" & txtOceanVoy.Text & "'") 'OceanVoy
            SQLcommand.append(",'" & txtagentPartner.Text & "'") 'agentPartner
            SQLcommand.append(",'" & txtagentaddress.Text & "'") 'agentaddress
            SQLcommand.append(",'" & txtagentContact.Text & "'") 'agentContact
            SQLcommand.append(",'" & txtMarkNumber.Text & "'") 'MarkNumber
            SQLcommand.append(",'" & txtContainer.Text & "'") 'Container
            SQLcommand.Append(",'" & CInt(txtPackageQty.Text) & "'") 'PackageQty
            SQLcommand.append(",'" & txtPackageType.Text & "'") 'PackageType
            SQLcommand.append(",'" & CDbl(txtCBM.Text) & "'") 'CBM
            SQLcommand.append(",'" & CDbl(txtPackageGW.Text) & "'") 'PackageGW
            SQLcommand.Append(",'" & CInt(txtQtyContainer1.Text) & "'") 'QtyContainer1
            SQLcommand.append(",'" & txtContainerType1.Text & "'") 'ContainerType1
            SQLcommand.append(",'" & CDbl(txtContainerNW1.Text) & "'") 'ContainerNW1
            SQLcommand.append(",'" & CDbl(txtContainerGW1.Text) & "'") 'ContainerGW1
            SQLcommand.Append(",'" & CInt(txtQtyContainer2.Text) & "'") 'QtyContainer2
            SQLcommand.append(",'" & txtContainerType2.Text & "'") 'ContainerType2
            SQLcommand.append(",'" & txtContainerNW2.Text & "'") 'ContainerNW2
            SQLcommand.append(",'" & txtContainerGW2.Text & "'") 'ContainerGW2
            SQLcommand.append(",'" & txtMasterBLType.Text & "'") 'MasterBLType
            SQLcommand.append(",'" & CDate(dtpETD.Value) & "'") 'ETD
            SQLcommand.append(",'" & CDate(dtpETa.Value) & "'") 'ETa
            SQLcommand.append(",'" & txtDescriptionOfGoods.Text & "'") 'DescriptionOfGoods
            SQLcommand.append(",'" & txtNoOfOriginalBL.Text & "'") 'NoOfOriginalBL
            SQLcommand.append(",'" & txtTermOfPayment.Text & "'") 'TermOfPayment
            SQLcommand.append(",'" & txtQuotationNo.Text & "'") 'QuotationNo
            SQLcommand.append(",'" & txtQuotaionUser.Text & "'") 'QuotaionUser
            SQLcommand.append(",'" & txtBookingNo.Text & "'") 'BookingNo
            SQLcommand.append(",'" & txtBookingUser.Text & "'") 'BookingUser
            SQLcommand.Append(",'" & CInt(txtactive.Text) & "'")
            SQLcommand.Append(",'" & txtSysUser.Text & "'")
            SQLcommand.append(",'" & _Insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                GetIdent()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub GetIdent()
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT Ident FROM [Freight_MasterBL] where BCFNo='" & txtBCFNo.Text & "' and MBLNo='" & txtMBLNo.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtIdent.Text = CInt(dr("Ident")).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub dgvPrice_DoubleClick(sender as Object, e as Eventargs)
        'MasterBLPop.Show()
    End Sub

    Private Sub MetroGrid1_DoubleClick(sender as Object, e as Eventargs)
        'MasterBLPop.Show()
    End Sub

    Private Sub MetroGrid2_DoubleClick(sender as Object, e as Eventargs) Handles dgvMasterBLCost.DoubleClick
        'MasterBLPop.Show()
    End Sub

    Private Sub txtPackageType_ButtonClick(sender as Object, e as Eventargs) Handles txtPackageType.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) PackageCode,PackageDescription  FROM Freight_PackageType WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPackageType.Text = dr("PackageCode").ToString
        End If
    End Sub

    Private Sub txtContainerType1_ButtonClick(sender as Object, e as Eventargs) Handles txtContainerType1.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) ContainerType FROM Freight_ContainerType WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtContainerType1.Text = dr("ContainerType").ToString
        End If
    End Sub

    Private Sub txtContainerType2_ButtonClick(sender as Object, e as Eventargs) Handles txtContainerType2.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) ContainerType FROM Freight_ContainerType WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtContainerType2.Text = dr("ContainerType").ToString
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender as Object, e as Eventargs) Handles GroupBox2.Enter

    End Sub

    Private Sub txtBookingNo_ButtonClick(sender as Object, e as Eventargs) Handles txtBookingNo.ButtonClick
        If txtMasterBLType.Text = "Export Console" Or txtMasterBLType.Text = "Import Console ขาเข้าคอนโซล" Then
            MsgBox("ไปดึงบุ๊กกิ้งในหน้า HBL เท่านั้น")
            Exit Sub
        End If
        Dim dr As DataRow
        dr = PopUpSearch("SELECT  TOP(100)
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

    Private Sub txtQuotationNo_ButtonClick(sender as Object, e as Eventargs) Handles txtQuotationNo.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT  TOP(100)
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

    Private Sub MetroGrid2_CellContentClick(sender as Object, e as DataGridViewCellEventargs) Handles dgvMasterBLCost.CellContentClick

    End Sub

    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        If txtBCFNo.Text = "" Then
            MsgBox("SaVE MaSTER BL FIRST!!!")
        Else
            SaveMasterBLCost()
        End If
    End Sub
    Private Sub SaveMasterBLCost()
        Try
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim a as Integer = 0
            For row as Integer = 0 To dgvMasterBLCost.Rows.Count - 2
                Try
                    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_MasterBLCost ")
                    SQLcommand.append("'" & CInt(dgvMasterBLCost.Rows(row).Cells(0).Value) & "'") 'Ident
                    SQLcommand.append(",'" & txtBCFNo.Text & "'") 'DetailType
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(3).Value & "'") 'SICode
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(4).Value & "'") 'SICode Description
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(6).Value & "'") 'Remark
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(7).Value & "'") 'Qty
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(8).Value & "'") 'Tys
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(9).Value & "'") 'CUr
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(10).Value & "'") 'UnitPrice
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(11).Value & "'") 'Total
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(12).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(13).Value & "'") 'IsNew
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(14).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(15).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(16).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(17).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(18).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(19).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(20).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(21).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(22).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(23).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(24).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(25).Value & "'")
                    SQLcommand.append(",'" & dgvMasterBLCost.Rows(row).Cells(26).Value & "'")
                    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
                    If result = 1 Then
                    Else
                        a += 1
                    End If
                Catch ex as Exception
                    a += 1
                    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try
            Next
            nection.Close()
            If a > 0 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Detail Error ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToMasterCost()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub LoadDataToMasterCost()
        Try
            dgvMasterBLCost.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Freight_MasterBLCost where DocNo='" & txtBCFNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvMasterBLCost.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
                    dt.Rows(i)(1).ToString(), 'DocNo
                    dt.Rows(i)(2).ToString(), 'aDVREQ
                    dt.Rows(i)(3).ToString(), 'SICode
                    dt.Rows(i)(4).ToString(), 'CostDescription
                    dt.Rows(i)(5).ToString(), 'VendorName
                    dt.Rows(i)(6).ToString(), 'HouseBL
                    dt.Rows(i)(7).ToString(), 'Remark
                    dt.Rows(i)(8).ToString(), 'QTYs
                    dt.Rows(i)(9).ToString(), 'PackageType
                    dt.Rows(i)(10).ToString(), 'Currency
                    CDbl(dt.Rows(i)(11).ToString()), 'Unitamount
                    CDbl(dt.Rows(i)(12).ToString()), 'Totalamount
                    CDbl(dt.Rows(i)(13).ToString()), 'EXC
                    CDbl(dt.Rows(i)(14).ToString()), 'WHT
                    CDbl(dt.Rows(i)(15).ToString()), 'WHTamount
                    CDbl(dt.Rows(i)(16).ToString()), 'aDVamount
                    CDbl(dt.Rows(i)(17).ToString()), 'NoVat
                    CDbl(dt.Rows(i)(18).ToString()), 'VaT
                    CDbl(dt.Rows(i)(19).ToString()), 'VaTamount
                    CDbl(dt.Rows(i)(20).ToString()), 'NetPayment
                    dt.Rows(i)(21).ToString(), 'RequestNo
                    dt.Rows(i)(22).ToString(), 'active
                    dt.Rows(i)(23).ToString() 'CreateUser
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

    Private Sub dgvMasterBLCost_Rowsadded(sender as Object, e as DataGridViewRowsaddedEventargs) Handles dgvMasterBLCost.Rowsadded
        'Try
        '    Dim CBCell as New DataGridViewComboBoxCell()
        '    CBCell = dgvMasterBLCost.Rows(e.RowIndex).Cells(11)
        '    CBCell.Items.add("CBM")
        '    CBCell.Items.add("KGS")
        '    CBCell.Items.add("TRIP")
        '    CBCell.Items.add("SHP")
        '    CBCell.Items.add("20GP")
        '    CBCell.Items.add("20HQ")
        '    CBCell.Items.add("40GP")
        '    CBCell.Items.add("40HQ")
        '    CBCell.Items.add("ISO TaNK")
        '    Dim UnitCell as New DataGridViewComboBoxCell()
        '    UnitCell = dgvMasterBLCost.Rows(e.RowIndex).Cells(12)
        '    UnitCell.Items.add("THB")
        '    UnitCell.Items.add("USD")
        '    UnitCell.Items.add("CYN")
        '    UnitCell.Items.add("JPY")
        '    UnitCell.Items.add("KRW")
        '    UnitCell.Items.add("VND")
        '    Dim WHTCell as New DataGridViewComboBoxCell()
        '    WHTCell = dgvMasterBLCost.Rows(e.RowIndex).Cells(16)
        '    WHTCell.Items.add("0")
        '    WHTCell.Items.add("1")
        '    WHTCell.Items.add("3")
        '    WHTCell.Items.add("5")
        '    Dim VaTCell as New DataGridViewComboBoxCell()
        '    VaTCell = dgvMasterBLCost.Rows(e.RowIndex).Cells(20)
        '    VaTCell.Items.add("0")
        '    VaTCell.Items.add("1")
        '    VaTCell.Items.add("7")
        '    'dgvCustomsClearance.Rows(e.RowIndex).Cells(0).Value = "0"
        '    dgvMasterBLCost.Rows(e.RowIndex).Cells(10).Value = "1" 'QTY
        '    dgvMasterBLCost.Rows(e.RowIndex).Cells(24).Value = "1"
        '    dgvMasterBLCost.Rows(e.RowIndex).Cells(25).Value = UserProfile.U_Code  'CreateUser
        '    dgvMasterBLCost.Rows(e.RowIndex).Cells(26).Value = "1" 'IsNew
        '    dgvMasterBLCost.Rows(e.RowIndex).Cells(27).Value = UserProfile.U_Code 'CuurentUser
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub txtShipper_ButtonClick(sender as Object, e as Eventargs) Handles txtShipper.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail  FROM Mas_Customer WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtShipper.Text = dr("CustName").ToString
            txtShipperaddress.Text = dr("Taddress").ToString
            txtShipperContact.Text = (dr("CustContact") + " " + dr("CustPhone") + " " + dr("CustFax")).ToString
        End If
    End Sub

    Private Sub txtConsignee_ButtonClick(sender as Object, e as Eventargs) Handles txtConsignee.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail  FROM Mas_Customer WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtConsignee.Text = dr("CustName").ToString
            txtConsigneeaddress.Text = dr("Taddress").ToString
            txtConsigneeContact.Text = (dr("CustContact") + " " + dr("CustPhone") + " " + dr("CustFax")).ToString
        End If
    End Sub

    Private Sub txtNotifyParty_ButtonClick(sender as Object, e as Eventargs) Handles txtNotifyParty.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) CustName,CustCode,Taddress,CustContact,CustPhone,CustFax,CustEmail  FROM Mas_Customer WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtNotifyParty.Text = dr("CustName").ToString
            txtNotifyaddress.Text = dr("Taddress").ToString
        End If
    End Sub
    Private Sub LoadDataCharge()
        'Try
        '    dgvCharge.Rows.Clear()
        '    Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
        '    Dim dt as DataTable = New DataTable()
        '    Dim nection as New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim str as String = "SELECT * FROM Freight_HouseCharge where DocNo='" & txtBCFNo.Text & "' and active='1'"
        '    da.SelectCommand = New OleDbCommand(str, nection)
        '    da.Fill(dt)
        '    If dt.Rows.Count > 0 Then
        '        For i as Integer = 0 To dt.Rows.Count - 1
        '            dgvCharge.Rows.add(dt.Rows(i)(0).ToString(), 'Ident
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
        '                   dt.Rows(i)(19).ToString(),
        '                   "0"
        '                    )
        '        Next
        '        da = Nothing
        '        dt = Nothing
        '        nection.Close()
        '    End If
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub LoadDataDN()
        Try
            dgvCostDN.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str as String = "SELECT * FROM Freight_HouseDN where DocNo='" & txtBCFNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
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
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub MasterBL_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        txtSysUser.Text = UserProfile.U_FName + " " + UserProfile.U_LName
        'LoadDataCharge()
        LoadDataDN()
        LoadDataToMasterCost()
        _IsNew = True
        txtIdent.Text = "0"
        SetDigitText()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        HouseBL.IsNotMaster = False
        HouseBL.IsNotNew = False
        HouseBL._IsNew = True

        If txtBCFNo.Text = "" Then
            MsgBox("Save Data First")
        Else
            If txtMBLNo.Text = "" Then
                MsgBox("Input Master BL First!!!")
            Else
                HouseBL.txtMasterBLNo.Text = txtMBLNo.Text
                HouseBL.txtHouseBLNo.Text = txtMBLNo.Text
                HouseBL.txtBCFNo.Text = txtBCFNo.Text
                HouseBL.txtHouseType.Text = txtMasterType.Text
                HouseBL.txtBookingNo.Text = txtBookingNo.Text
                HouseBL.txtVSLBKG.Text = txtVSLBKG.Text
                HouseBL.txtBookingUser.Text = txtBookingUser.Text
                HouseBL.txtQuotationNo.Text = txtQuotationNo.Text
                HouseBL.txtQuotaionUser.Text = txtQuotaionUser.Text
                'HouseBL.txtShipper.Text = txtShipper.Text
                'HouseBL.txtShipperaddress.Text = txtShipperaddress.rText
                'HouseBL.txtShipperContact.Text = txtShipperContact.Text
                'HouseBL.txtShipperRef.Text = txtShipperRef.Text
                'HouseBL.txtConsignee.Text = txtConsignee.Text
                'HouseBL.txtConsigneeaddress.Text = txtConsigneeaddress.Text
                'HouseBL.txtConsigneeContact.Text = txtConsigneeContact.Text
                'HouseBL.txtConsigneeRef.Text = txtConsigneeRef.Text
                'HouseBL.txtNotifyParty.Text = txtNotifyParty.Text
                'HouseBL.txtNotifyaddress.Text = txtNotifyaddress.Text
                HouseBL.txtPlaceOfReceive.Text = txtPlaceOfReceive.Text
                HouseBL.txtPortOfLoading.Text = txtPortOfLoading.Text
                HouseBL.txtPortOfDischarge.Text = txtPortOfDischarge.Text
                HouseBL.txtPlaceOfDelivery.Text = txtPlaceOfDelivery.Text
                HouseBL.txtLocalVessel.Text = txtLocalVessel.Text
                HouseBL.txtLocalVoy.Text = txtLocalVoy.Text
                HouseBL.txtOceanVessel.Text = txtOceanVessel.Text
                HouseBL.txtOceanVoy.Text = txtOceanVoy.Text
                HouseBL.txtagentPartner.Text = txtagentPartner.Text
                HouseBL.txtagentaddress.Text = txtagentaddress.Text
                HouseBL.txtagentContact.Text = txtagentContact.Text
                HouseBL.txtMarkNumber.Text = txtMarkNumber.Text
                HouseBL.txtContainer.Text = txtContainer.Text
                HouseBL.txtPackageQty.Text = txtPackageQty.Text
                HouseBL.txtPackageType.Text = txtPackageType.Text
                HouseBL.txtCBM.Text = txtCBM.Text
                HouseBL.txtPackageGW.Text = txtPackageGW.Text
                HouseBL.txtQtyContainer1.Text = txtQtyContainer1.Text
                HouseBL.txtContainerType1.Text = txtContainerType1.Text
                HouseBL.txtContainerNW1.Text = txtContainerNW1.Text
                HouseBL.txtContainerGW1.Text = txtContainerGW1.Text
                HouseBL.txtQtyContainer2.Text = txtQtyContainer2.Text
                HouseBL.txtContainerType2.Text = txtContainerType2.Text
                HouseBL.txtContainerNW2.Text = txtContainerNW2.Text
                HouseBL.txtContainerGW2.Text = txtContainerGW2.Text
                HouseBL.dtpETD.Text = dtpETD.Text
                HouseBL.dtpETa.Text = dtpETa.Text
                HouseBL.txtDescriptionOfGoods.Text = txtDescriptionOfGoods.Text
                HouseBL.ShowDialog()
                LoadDataHouseBL()
            End If
        End If

    End Sub
    Event DataGridView1ButtonClick(sender as DataGridView, e as DataGridViewCellEventargs)
    Private Sub DataGridView1_CellContentClick(sender as System.Object, e as DataGridViewCellEventargs) Handles dgvMasterBLCost.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn andalso e.RowIndex >= 0 Then
            RaiseEvent DataGridView1ButtonClick(senderGrid, e)
            dgvMasterBLCost.CurrentRow.Cells(24).Value = "1"
            If dgvMasterBLCost.CurrentRow.Cells(26).Value = "0" Then
                dgvMasterBLCost.CurrentRow.Cells(26).Value = "0"
            Else
                dgvMasterBLCost.CurrentRow.Cells(26).Value = "1"
            End If

        End If
    End Sub
    Private Sub DataGridView2_ButtonClick(sender as DataGridView, e as DataGridViewCellEventargs) Handles Me.DataGridView1ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("Select TOP(100) [accountGroup], [ItemName]
      ,[accountNo]
      ,[accountControl]
      ,[SICode]
      ,[accountName]
      ,[SIGroup]  FROM [MaS_SICODE] WHERE 1=1", MainConnection)
        If isSearchOK Then
            dgvMasterBLCost.CurrentRow.Cells(4).Value = dr("SICode").ToString
            dgvMasterBLCost.CurrentRow.Cells(6).Value = dr("ItemName").ToString
            dgvMasterBLCost.CurrentRow.Cells(24).Value = "1"
            dgvMasterBLCost.CurrentRow.Cells(26).Value = "1"
        End If
    End Sub

    Private Sub Button9_Click(sender as Object, e as Eventargs) Handles Button9.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP 100
        [BCFNo],[MasterType],[VSLBKG],[MBLNo],[Shipper],[Shipperaddress],[ShipperContact],[ShipperRef],[Consignee],[Consigneeaddress]
        ,[ConsigneeContact],[ConsigneeRef],[NotifyParty],[Notifyaddress],[PlaceOfReceive],[PortOfLoading],[PortOfDischarge]
        ,[PlaceOfDelivery],[LocalVessel],[LocalVoy],[OceanVessel],[OceanVoy],[agentPartner],[agentaddress],[agentContact],[MarkNumber]
        ,[Container],[PackageQty],[PackageType],[CBM],[PackageGW],[QtyContainer1],[ContainerType1],[ContainerNW1],[ContainerGW1]
        ,[QtyContainer2],[ContainerType2],[ContainerNW2],[ContainerGW2],[MasterBLType],[ETD],[ETa],[DescriptionOfGoods],[NoOfOriginalBL]
        ,[TermOfPayment],[QuotationNo],[QuotaionUser],[BookingNo],[BookingUser]
        ,[Ident]  FROM Freight_MasterBL WHERE 1=1 and Active = '1'", MainConnection)
        If isSearchOK Then
            txtMasterType.Text = dr("MasterType").ToString
            txtBCFNo.Text = dr("BCFNo").ToString
            txtMBLNo.Text = dr("MBLNo").ToString
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
            txtNoOfOriginalBL.Text = dr("NoOfOriginalBL").ToString
            txtTermOfPayment.Text = dr("TermOfPayment").ToString
            txtMasterBLType.Text = dr("MasterBLType").ToString
            _IsNew = False
            LoadDataCharge()
            LoadDataDN()
            LoadDataHouseBL()
            LoadDataToMasterCost()
            SetDigitText()
        End If
    End Sub
    Private Sub LoadDataHouseBL()
        Try
            dgvCharge.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim str As String = "SELECT * FROM Freight_HouseBL where BCFNo='" & txtBCFNo.Text & "' and active='1'"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    dgvCharge.Rows.add(dt.Rows(i)(0).ToString(), '0 Ident',
                   dt.Rows(i)(1).ToString(),
                   dt.Rows(i)(50).ToString(), '1 HouseType',
                   dt.Rows(i)(9).ToString(),
                   dt.Rows(i)(23).ToString(),
                   dt.Rows(i)(4).ToString(), '2 BCFNo',
                   dt.Rows(i)(2).ToString() '3 VSLBKG',
                   )
                    'dt.Rows(i)(4).ToString(), '4 MBLNo',
                    'dt.Rows(i)(5).ToString(), '5 Shipper',
                    'dt.Rows(i)(6).ToString(), '6 Shipperaddress',
                    'dt.Rows(i)(7).ToString(), '7 ShipperContact',
                    'dt.Rows(i)(8).ToString(), '8 ShipperRef',
                    'dt.Rows(i)(9).ToString(), '9 Consignee',
                    'dt.Rows(i)(10).ToString(), '10 Consigneeaddress',
                    'dt.Rows(i)(11).ToString(), '11 ConsigneeContact',
                    'dt.Rows(i)(12).ToString(), '12 ConsigneeRef',
                    'dt.Rows(i)(13).ToString(), '13 NotifyParty',
                    'dt.Rows(i)(14).ToString(), '14 Notifyaddress',
                    'dt.Rows(i)(15).ToString(), '15 PlaceOfReceive',
                    'dt.Rows(i)(16).ToString(), '16 PortOfLoading',
                    'dt.Rows(i)(17).ToString(), '17 PortOfDischarge',
                    'dt.Rows(i)(18).ToString(), '18 PlaceOfDelivery',
                    'dt.Rows(i)(19).ToString(), '19 LocalVessel',
                    'dt.Rows(i)(20).ToString(), '20 LocalVoy',
                    'dt.Rows(i)(21).ToString(), '21 OceanVessel',
                    'dt.Rows(i)(22).ToString(), '22 OceanVoy',
                    'dt.Rows(i)(23).ToString(), '23 agentPartner',
                    'dt.Rows(i)(24).ToString(), '24 agentaddress',
                    'dt.Rows(i)(25).ToString(), '25 agentContact',
                    'dt.Rows(i)(26).ToString(), '26 MarkNumber',
                    'dt.Rows(i)(27).ToString(), '27 Container',
                    'dt.Rows(i)(28).ToString(), '28 PackageQty',
                    'dt.Rows(i)(29).ToString(), '29 PackageType',
                    'CDbl(dt.Rows(i)(30).ToString()), '30 CBM',
                    'CDbl(dt.Rows(i)(31).ToString()), '31 PackageGW',
                    'dt.Rows(i)(32).ToString(), '32 QtyContainer1',
                    'dt.Rows(i)(33).ToString(), '33 ContainerType1',
                    'CDbl(dt.Rows(i)(34).ToString()), '34 ContainerNW1',
                    'CDbl(dt.Rows(i)(35).ToString()), '35 ContainerGW1',
                    'dt.Rows(i)(36).ToString(), '36 QtyContainer2',
                    'dt.Rows(i)(37).ToString(), '37 ContainerType2',
                    'dt.Rows(i)(38).ToString(), '38 ContainerNW2',
                    'dt.Rows(i)(39).ToString(), '39 ContainerGW2',
                    'dt.Rows(i)(40).ToString(), '40 MasterBLType',
                    'dt.Rows(i)(41).ToString(), '41 ETD',
                    'dt.Rows(i)(42).ToString(), '42 ETa',
                    'dt.Rows(i)(43).ToString(), '43 DescriptionOfGoods',
                    'dt.Rows(i)(44).ToString(), '44 NoOfOriginalBL',
                    'dt.Rows(i)(45).ToString(), '45 TermOfPayment',
                    'dt.Rows(i)(46).ToString(), '46 QuotationNo',
                    'dt.Rows(i)(47).ToString(), '47 QuotationUser',
                    'dt.Rows(i)(48).ToString(), '48 BookingNo',
                    'dt.Rows(i)(49).ToString(), '49 BookingUser',
                    'dt.Rows(i)(50).ToString(), '50 HBLNo',
                    'dt.Rows(i)(51).ToString() '51 CurrentLetter'

                Next

                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    Private Sub Button19_Click(sender as Object, e as Eventargs) Handles Button19.Click
        txtactive.Text = "0"
        MsgBox("Please Save To Confirm Your action")
    End Sub

    Private Sub dgvCharge_CellMouseDoubleClick(sender as Object, e as DataGridViewCellMouseEventargs) Handles dgvCharge.CellMouseDoubleClick
        HouseBL.txtIdent.Text = dgvCharge.CurrentRow.Cells(0).Value
        HouseBL.txtHouseBLNo.Text = dgvCharge.CurrentRow.Cells(2).Value
        HouseBL.txtMasterBLNo.Text = dgvCharge.CurrentRow.Cells(5).Value
        HouseBL.txtBCFNo.Text = dgvCharge.CurrentRow.Cells(6).Value
        HouseBL.txtHouseType.Text = txtMasterType.Text
        HouseBL.txtBookingNo.Text = txtBookingNo.Text
        HouseBL.txtVSLBKG.Text = txtVSLBKG.Text
        HouseBL.txtBookingUser.Text = txtBookingUser.Text
        HouseBL.txtQuotationNo.Text = txtQuotationNo.Text
        HouseBL.txtQuotaionUser.Text = txtQuotaionUser.Text
        'HouseBL.txtShipper.Text = txtShipper.Text
        'HouseBL.txtShipperaddress.Text = txtShipperaddress.Text
        'HouseBL.txtShipperContact.Text = txtShipperContact.Text
        'HouseBL.txtShipperRef.Text = txtShipperRef.Text
        'HouseBL.txtConsignee.Text = txtConsignee.Text
        'HouseBL.txtConsigneeaddress.Text = txtConsigneeaddress.Text
        'HouseBL.txtConsigneeContact.Text = txtConsigneeContact.Text
        'HouseBL.txtConsigneeRef.Text = txtConsigneeRef.Text
        'HouseBL.txtNotifyParty.Text = txtNotifyParty.Text
        'HouseBL.txtNotifyaddress.Text = txtNotifyaddress.Text
        HouseBL.txtPlaceOfReceive.Text = txtPlaceOfReceive.Text
        HouseBL.txtPortOfLoading.Text = txtPortOfLoading.Text
        HouseBL.txtPortOfDischarge.Text = txtPortOfDischarge.Text
        HouseBL.txtPlaceOfDelivery.Text = txtPlaceOfDelivery.Text
        HouseBL.txtLocalVessel.Text = txtLocalVessel.Text
        HouseBL.txtLocalVoy.Text = txtLocalVoy.Text
        HouseBL.txtOceanVessel.Text = txtOceanVessel.Text
        HouseBL.txtOceanVoy.Text = txtOceanVoy.Text
        HouseBL.txtagentPartner.Text = txtagentPartner.Text
        HouseBL.txtagentaddress.Text = txtagentaddress.Text
        HouseBL.txtagentContact.Text = txtagentContact.Text
        'HouseBL.txtMarkNumber.Text = txtMarkNumber.Text
        'HouseBL.txtContainer.Text = txtContainer.Text
        'HouseBL.txtPackageQty.Text = txtPackageQty.Text
        'HouseBL.txtPackageType.Text = txtPackageType.Text
        'HouseBL.txtCBM.Text = txtCBM.Text
        'HouseBL.txtPackageGW.Text = txtPackageGW.Text
        'HouseBL.txtQtyContainer1.Text = txtQtyContainer1.Text
        'HouseBL.txtContainerType1.Text = txtContainerType1.Text
        'HouseBL.txtContainerNW1.Text = txtContainerNW1.Text
        'HouseBL.txtContainerGW1.Text = txtContainerGW1.Text
        'HouseBL.txtQtyContainer2.Text = txtQtyContainer2.Text
        'HouseBL.txtContainerType2.Text = txtContainerType2.Text
        'HouseBL.txtContainerNW2.Text = txtContainerNW2.Text
        'HouseBL.txtContainerGW2.Text = txtContainerGW2.Text
        HouseBL.dtpETD.Text = dtpETD.Text
        'HouseBL.dtpETa.Text = dtpETa.Text
        'HouseBL.txtDescriptionOfGoods.Text = txtDescriptionOfGoods.Text
        HouseBL.IsNotMaster = False
        HouseBL.IsNotNew = True
        HouseBL._IsNew = False
        HouseBL.ShowDialog()
        LoadDataHouseBL()
    End Sub

    Private Sub txtagentPartner_ButtonClick(sender as Object, e as Eventargs) Handles txtagentPartner.ButtonClick
        Dim dr as DataRow
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

    Private Sub txtLocalVessel_ButtonClick(sender as Object, e as Eventargs) Handles txtLocalVessel.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) [VesselCode]
        ,[RegisterNumber]
        ,[VesselName]
        ,[VesselType]
        ,[CountryCode]  FROM Mas_Vessel WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtLocalVessel.Text = dr("VesselName").ToString
        End If
    End Sub

    Private Sub txtOceanVessel_ButtonClick(sender as Object, e as Eventargs) Handles txtOceanVessel.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) [VesselCode]
        ,[RegisterNumber]
        ,[VesselName]
        ,[VesselType]
        ,[CountryCode]  FROM Mas_Vessel WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtOceanVessel.Text = dr("VesselName").ToString
        End If
    End Sub

    Private Sub txtPlaceOfReceive_ButtonClick(sender as Object, e as Eventargs) Handles txtPlaceOfReceive.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPlaceOfReceive.Text = dr("PortName").ToString
        End If
    End Sub

    Private Sub txtPortOfLoading_ButtonClick(sender as Object, e as Eventargs) Handles txtPortOfLoading.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPortOfLoading.Text = dr("PortName").ToString
        End If
    End Sub

    Private Sub txtPortOfDischarge_ButtonClick(sender as Object, e as Eventargs) Handles txtPortOfDischarge.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPortOfDischarge.Text = dr("PortName").ToString
        End If
    End Sub

    Private Sub txtPlaceOfDelivery_ButtonClick(sender as Object, e as Eventargs) Handles txtPlaceOfDelivery.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPlaceOfDelivery.Text = dr("PortName").ToString
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim url As String = "http://203.170.129.23/TESTFRIEGHT/report/BillOfLading?BCFNo=" & txtBCFNo.Text & "&MBLNo=" & txtMBLNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub

    Private Sub MetroTextBox1_ButtonClick(sender As Object, e As EventArgs) Handles MetroTextBox1.ButtonClick

    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
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
            'SelectCNData()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        HouseadvRequest.txtBCFNo.Text = txtBCFNo.Text
        HouseadvRequest.IsCNorDN = True
        HouseadvRequest.ShowDialog()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If String.IsNullOrEmpty(txtBCFNo.Text) Then Exit Sub
        UploadFilePage.txtMasterBLNo.Text = txtBCFNo.Text
        UploadFilePage.ShowDialog()
    End Sub

    Private Sub dgvMasterBLCost_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMasterBLCost.CellEndEdit
        'CalValueItem()
    End Sub
    Private Sub CalValueItem()
        Dim WHT As Double = 0
        Dim VAT As Double = 0
        If dgvMasterBLCost.Rows.Count > 0 Then
            For row As Integer = 0 To dgvMasterBLCost.Rows.Count - 2
                'Total Amount Qty*UnitAmt
                dgvMasterBLCost.Rows(row).Cells(14).Value = CDbl(dgvMasterBLCost.Rows(row).Cells(10).Value) * CDbl(dgvMasterBLCost.Rows(row).Cells(13).Value)
                WHT = CDbl(dgvMasterBLCost.Rows(row).Cells(16).Value)
                'wht amt
                dgvMasterBLCost.Rows(row).Cells(17).Value = (CDbl(dgvMasterBLCost.Rows(row).Cells(14).Value) * WHT / 100).ToString("#,##0.00")
                VAT = CDbl(dgvMasterBLCost.Rows(row).Cells(20).Value)
                'Vat amt
                dgvMasterBLCost.Rows(row).Cells(21).Value = (CDbl(dgvMasterBLCost.Rows(row).Cells(14).Value) * VAT / 100).ToString("#,##0.00")
                'Net
                dgvMasterBLCost.Rows(row).Cells(22).Value = (CDbl(dgvMasterBLCost.Rows(row).Cells(14).Value) + CDbl(dgvMasterBLCost.Rows(row).Cells(21).Value) + CDbl(dgvMasterBLCost.Rows(row).Cells(18).Value) - CDbl(dgvMasterBLCost.Rows(row).Cells(17).Value)).ToString("#,##0.00")
            Next
        End If

    End Sub

    Private Sub dgvMasterBLCost_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMasterBLCost.CellValidated
        'Try
        '    Select Case e.ColumnIndex
        '        Case 10 'float fields
        '            sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("#,##0.0000")
        '        Case 13, 14, 15, 17, 18, 19, 21, 22 'float fields
        '            sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value).ToString("#,##0.00")
        '    End Select
        'Catch ex As Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub

    Private Sub dgvMasterBLCost_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvMasterBLCost.CellValidating
        'Try
        '    If sender.Rows.Count < 1 Then Exit Sub
        '    'is the user clicking on the column headers? 
        '    If e.RowIndex = -1 Then Exit Sub
        '    'is it the new row? 
        '    If sender.Rows(e.RowIndex).IsNewRow Then Exit Sub
        '    If CStr(e.FormattedValue) = Nothing Then Exit Sub

        '    Dim newValue As Double
        '    Select Case e.ColumnIndex
        '        Case 10, 13, 14, 15, 17, 18, 19, 21, 22
        '            If Double.TryParse(e.FormattedValue, newValue) Then
        '                'are there no changes being made? 
        '                If newValue = CDbl(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then Exit Sub
        '            Else
        '                'if the value can't be parsed into a decimal, then it is invalid 
        '                e.Cancel = True
        '            End If

        '    End Select

        'Catch ex As Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub

    Private Sub txtPackageQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQtyContainer2.KeyPress, txtQtyContainer1.KeyPress, txtPackageQty.KeyPress, txtPackageGW.KeyPress, txtContainerNW2.KeyPress, txtContainerNW1.KeyPress, txtContainerGW2.KeyPress, txtContainerGW1.KeyPress, txtCBM.KeyPress
        CheckDouble(e)
        If e.KeyChar = Chr(Keys.Enter) Then
            SetDigitText()
        End If
    End Sub

    Private Sub txtPackageQty_Leave(sender As Object, e As EventArgs) Handles txtQtyContainer2.Leave, txtQtyContainer1.Leave, txtPackageQty.Leave, txtPackageGW.Leave, txtContainerNW2.Leave, txtContainerNW1.Leave, txtContainerGW2.Leave, txtContainerGW1.Leave, txtCBM.Leave
        SetDigitText()
    End Sub

    Private Sub txtPackageQty_Click(sender As Object, e As EventArgs) Handles txtQtyContainer2.Click, txtQtyContainer1.Click, txtPackageQty.Click, txtPackageGW.Click, txtContainerNW2.Click, txtContainerNW1.Click, txtContainerGW2.Click, txtContainerGW1.Click, txtCBM.Click
        SelectTextall(sender)
    End Sub
    Private Sub SetDigitText()

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
End Class