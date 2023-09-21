Imports System.Text

Public Class BookingConfirm
    Public _IsNew As Boolean
    Private Sub Button4_Click(sender As Object, e As Eventargs) Handles Button4.Click
#Region "Validate Input"
        If String.IsNullOrEmpty(txtQuotationNo.Text) Then
            txtQuotationNo.Focus()
            txtQuotationNo.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล QuotationNo ", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtQuotationNo.Style = MetroFramework.MetroColorStyle.Default
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
        If String.IsNullOrEmpty(txtPlaceofReceive.Text) Then
            txtPlaceofReceive.Focus()
            txtPlaceofReceive.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PlaceOfReceive.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPlaceofReceive.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPortofLoading.Text) Then
            txtPortofLoading.Focus()
            txtPortofLoading.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PortOfLoading.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPortofLoading.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPortofDischarge.Text) Then
            txtPortofDischarge.Focus()
            txtPortofDischarge.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PortOfDischarge.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPortofDischarge.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPlaceofDelivery.Text) Then
            txtPlaceofDelivery.Focus()
            txtPlaceofDelivery.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PlaceOfDelivery.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPlaceofDelivery.Style = MetroFramework.MetroColorStyle.Default
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


        If String.IsNullOrEmpty(txtCustomerCoLoad.Text) Then
            txtCustomerCoLoad.Focus()
            txtCustomerCoLoad.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล CustomerCoLoad.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtCustomerCoLoad.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtCustomeraddress.Text) Then
            txtCustomeraddress.Focus()
            txtCustomeraddress.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Customeraddress.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtCustomeraddress.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtCustomerContact.Text) Then
            txtCustomerContact.Focus()
            txtCustomerContact.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล CustomerContact.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtCustomerContact.Style = MetroFramework.MetroColorStyle.Default
        End If
        'If String.IsNullOrEmpty(txtRemark.Text) Then
        '    txtRemark.Focus()
        '    txtRemark.Style = MetroFramework.MetroColorStyle.Red
        '    Exit Sub
        'Else
        '    txtRemark.Style = MetroFramework.MetroColorStyle.Default
        'End If
        If String.IsNullOrEmpty(txtagentCoLoad.Text) Then
            txtagentCoLoad.Focus()
            txtagentCoLoad.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล AgentCoLoad.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtagentCoLoad.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtCoLoadContact.Text) Then
            txtCoLoadContact.Focus()
            txtCoLoadContact.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล CoLoadContact.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtCoLoadContact.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVesselagent.Text) Then
            txtVesselagent.Focus()
            txtVesselagent.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล Vesselagent.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtVesselagent.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVesselContact.Text) Then
            txtVesselContact.Focus()
            txtVesselContact.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล VesselContact.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtVesselContact.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVesselBooking.Text) Then
            txtVesselBooking.Focus()
            txtVesselBooking.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล VesselBooking.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtVesselBooking.Style = MetroFramework.MetroColorStyle.Default
        End If

        If String.IsNullOrEmpty(txtPickLocation.Text) Then
            txtPickLocation.Focus()
            txtPickLocation.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PickLocation.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPickLocation.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPickContact.Text) Then
            txtPickContact.Focus()
            txtPickContact.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PickContact.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPickContact.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtLoadLocation.Text) Then
            txtLoadLocation.Focus()
            txtLoadLocation.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล LoadLocation.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtLoadLocation.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtReturnLocation.Text) Then
            txtReturnLocation.Focus()
            txtReturnLocation.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ReturnLocation.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtReturnLocation.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtReturnContact.Text) Then
            txtReturnContact.Focus()
            txtReturnContact.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ReturnContact.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtReturnContact.Style = MetroFramework.MetroColorStyle.Default
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
        If String.IsNullOrEmpty(txtDescriptionOfGoods.Text) Then
            txtDescriptionOfGoods.Focus()
            txtDescriptionOfGoods.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล DescriptionOfGoods.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtDescriptionOfGoods.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtShipperCode.Text) Then
            txtShipperCode.Focus()
            txtShipperCode.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ShipperCode.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtShipperCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtConsigneeCode.Text) Then
            txtConsigneeCode.Focus()
            txtConsigneeCode.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล ConsigneeCode.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtConsigneeCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtNotifyCode.Text) Then
            txtNotifyCode.Focus()
            txtNotifyCode.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล NotifyCode.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtNotifyCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtCustCode.Text) Then
            txtCustCode.Focus()
            txtCustCode.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล CustCode.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtCustCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtagentCode.Text) Then
            txtagentCode.Focus()
            txtagentCode.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล AgentCode.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtagentCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtVesselCode.Text) Then
            txtVesselCode.Focus()
            txtVesselCode.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล VesselCode.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtVesselCode.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(txtPartnerCode.Text) Then
            txtPartnerCode.Focus()
            txtPartnerCode.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล PartnerCode.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            txtPartnerCode.Style = MetroFramework.MetroColorStyle.Default
        End If


        If String.IsNullOrEmpty(cboBookingType.Text) Then
            cboBookingType.Focus()
            cboBookingType.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล BookingType.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            cboBookingType.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(cboNoOfOriginalBL.Text) Then
            cboNoOfOriginalBL.Focus()
            cboNoOfOriginalBL.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล NoOfOriginalBL.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            cboNoOfOriginalBL.Style = MetroFramework.MetroColorStyle.Default
        End If
        If String.IsNullOrEmpty(cboTermOfPayment.Text) Then
            cboTermOfPayment.Focus()
            cboTermOfPayment.Style = MetroFramework.MetroColorStyle.Red
            MetroFramework.MetroMessageBox.Show(Me, "กรุณากรอกข้อมูล TermOfPayment.", "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            cboTermOfPayment.Style = MetroFramework.MetroColorStyle.Default
        End If

#End Region


        If txtBookingNo.Text = "" Then
            BookingRunning()
        End If
        If _IsNew = True Then
            SaveBookingConfirm(1)
        Else
            SaveBookingConfirm(0)
        End If
    End Sub
    Private Sub SaveBookingConfirm(_Insert As Integer)
        Try
            Dim nection As OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand As StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_BookingConfirm ")
            SQLcommand.Append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.Append(",'" & txtBookingNo.Text & "'") 'BookingNo
            SQLcommand.Append(",'" & txtUserBooking.Text & "'") 'BookingUser
            SQLcommand.Append(",'" & txtQuotationNo.Text & "'") 'QuotationNo
            SQLcommand.Append(",'" & txtUserQuotation.Text & "'") 'QuotationUser
            SQLcommand.Append(",'" & txtShipper.Text & "'") 'Shipper
            SQLcommand.Append(",'" & txtShipperaddress.Text & "'") 'ShipperAddress
            SQLcommand.Append(",'" & txtShipperContact.Text & "'") 'ShipperContact
            SQLcommand.Append(",'" & txtShipperRef.Text & "'") 'ShipperRef
            SQLcommand.Append(",'" & txtConsignee.Text & "'") 'Consignee
            SQLcommand.Append(",'" & txtConsigneeaddress.Text & "'") 'ConsigneeAddress
            SQLcommand.Append(",'" & txtConsigneeContact.Text & "'") 'ConsigneeContact
            SQLcommand.Append(",'" & txtConsigneeRef.Text & "'") 'ConsigneeRef
            SQLcommand.Append(",'" & txtNotifyParty.Text & "'") 'NotifyParty
            SQLcommand.Append(",'" & txtNotifyaddress.Text & "'") 'NotifyAddress
            SQLcommand.Append(",'" & txtPlaceofReceive.Text & "'") 'PlaceOfReceive
            SQLcommand.Append(",'" & txtPortofLoading.Text & "'") 'PortOfLoading
            SQLcommand.Append(",'" & txtPortofDischarge.Text & "'") 'PortOfDischarge
            SQLcommand.Append(",'" & txtPlaceofDelivery.Text & "'") 'PlaceOfDelivery
            SQLcommand.Append(",'" & txtLocalVessel.Text & "'") 'LocalVessel
            SQLcommand.Append(",'" & txtLocalVoy.Text & "'") 'LocalVoy
            SQLcommand.Append(",'" & txtOceanVessel.Text & "'") 'OceanVessel
            SQLcommand.Append(",'" & txtOceanVoy.Text & "'") 'OceanVoy
            SQLcommand.Append(",'" & txtagentPartner.Text & "'") 'AgentPartner
            SQLcommand.Append(",'" & txtagentaddress.Text & "'") 'AgentAddress
            SQLcommand.Append(",'" & txtagentContact.Text & "'") 'AgentContact
            SQLcommand.Append(",'" & txtCustomerCoLoad.Text & "'") 'CustomerCoLoad
            SQLcommand.Append(",'" & txtCustomeraddress.Text & "'") 'CustomerAddress
            SQLcommand.Append(",'" & txtCustomerContact.Text & "'") 'CustomerContact
            SQLcommand.Append(",'" & txtRemark.Text & "'") 'Remark
            SQLcommand.Append(",'" & txtagentCoLoad.Text & "'") 'AgentCoLoad
            SQLcommand.Append(",'" & txtCoLoadContact.Text & "'") 'CoLoadContact
            SQLcommand.Append(",'" & txtVesselagent.Text & "'") 'VesselAgent
            SQLcommand.Append(",'" & txtVesselContact.Text & "'") 'VesselContact
            SQLcommand.Append(",'" & txtVesselBooking.Text & "'") 'VesselBooking
            SQLcommand.Append(",'" & CDate(dtpPickDate.Value) & "'") 'PickDate
            SQLcommand.Append(",'" & txtPickLocation.Text & "'") 'PickLocation
            SQLcommand.Append(",'" & txtPickTime.Text & "'") 'PickTime
            SQLcommand.Append(",'" & txtPickContact.Text & "'") 'PickContact
            SQLcommand.Append(",'" & CDate(dtpLoadDate.Value) & "'") 'LoadDate
            SQLcommand.Append(",'" & txtLoadLocation.Text & "'") 'LoadLocation
            SQLcommand.Append(",'" & txtLoadTime.Text & "'") 'LoadTime
            SQLcommand.Append(",'" & txtLoadContact.Text & "'") 'LoadContact
            SQLcommand.Append(",'" & CDate(dtpReturnDate.Value) & "'") 'ReturnDate
            SQLcommand.Append(",'" & txtReturnLocation.Text & "'") 'ReturnLocation
            SQLcommand.Append(",'" & txtReturnTime.Text & "'") 'ReturnTime
            SQLcommand.Append(",'" & txtReturnContact.Text & "'") 'ReturnContact
            SQLcommand.Append(",'" & CDate(dtpCloseRNDate.Value) & "'") 'CloseRNDate
            SQLcommand.Append(",'" & txtCloseRNTime.Text & "'") 'CloseRNTime
            SQLcommand.Append(",'" & CDate(dtpCloseSIDate.Value) & "'") 'CloseSIDate
            SQLcommand.Append(",'" & txtCloseSITime.Text & "'") 'CloseSITime
            SQLcommand.Append(",'" & CDate(dtpCloseVGMDate.Value) & "'") 'CloseVGMDate
            SQLcommand.Append(",'" & txtCloseVGMTime.Text & "'") 'CloseVGMTime
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
            SQLcommand.Append(",'" & CDbl(txtContainerNW2.Text) & "'") 'ContainerNW2
            SQLcommand.Append(",'" & CDbl(txtContainerGW2.Text) & "'") 'ContainerGW2
            SQLcommand.Append(",'" & cboBookingType.Text & "'") 'BookingType
            SQLcommand.Append(",'" & CDate(dtpETD.Value) & "'") 'ETD
            SQLcommand.Append(",'" & CDate(dtpETa.Value) & "'") 'ETA
            SQLcommand.Append(",'" & txtDescriptionOfGoods.Text & "'") 'DescriptionOfGoods
            SQLcommand.Append(",'" & cboNoOfOriginalBL.Text & "'") 'NoOfOriginalBL
            SQLcommand.Append(",'" & cboTermOfPayment.Text & "'") 'TermOfPayment
            SQLcommand.Append(",'" & CDate(dtpBookingNoDate.Value) & "'") 'BookingNoDate
            SQLcommand.Append(",'" & txtShipperCode.Text & "'") 'ShipperCode
            SQLcommand.Append(",'" & txtConsigneeCode.Text & "'") 'ConsigneeCode
            SQLcommand.Append(",'" & txtNotifyCode.Text & "'") 'NotifyCode
            SQLcommand.Append(",'" & txtCustCode.Text & "'") 'CustCode
            SQLcommand.Append(",'" & txtagentCode.Text & "'") 'AgentCode
            SQLcommand.Append(",'" & txtVesselCode.Text & "'") 'VesselCode
            SQLcommand.Append(",'" & txtPartnerCode.Text & "'") 'PartnerCode
            SQLcommand.Append(",'" & txtUserBooking.Text & "'")
            SQLcommand.Append(",'" & _Insert & "'") '//Insert Or Update
            Dim result As Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
                GetIdent()
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        'Try
        '    Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
        '    nection = ConnectDB()
        '    Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateFreight_BookingConfirm ")
        '    SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
        '    SQLcommand.append(",'" & txtBookingNo.Text & "'") 'BookingNo
        '    SQLcommand.append(",'" & txtUserBooking.Text & "'") 'BookingUser
        '    SQLcommand.append(",'" & txtQuotationNo.Text & "'") 'QuotationNo
        '    SQLcommand.append(",'" & txtUserQuotation.Text & "'") 'QuotationUser
        '    SQLcommand.append(",'" & txtShipper.Text & "'") 'Shipper
        '    SQLcommand.append(",'" & txtShipperaddress.Text & "'") 'Shipperaddress
        '    SQLcommand.append(",'" & txtShipperContact.Text & "'") 'ShipperContact
        '    SQLcommand.append(",'" & txtShipperRef.Text & "'") 'ShipperRef
        '    SQLcommand.append(",'" & txtConsignee.Text & "'") 'Consignee
        '    SQLcommand.append(",'" & txtConsigneeaddress.Text & "'") 'Consigneeaddress
        '    SQLcommand.append(",'" & txtConsigneeContact.Text & "'") 'ConsigneeContact
        '    SQLcommand.append(",'" & txtConsigneeRef.Text & "'") 'ConsigneeRef
        '    SQLcommand.append(",'" & txtNotifyParty.Text & "'") 'NotifyParty
        '    SQLcommand.append(",'" & txtNotifyaddress.Text & "'") 'Notifyaddress
        '    SQLcommand.append(",'" & txtPlaceofReceive.Text & "'") 'PlaceOfReceive
        '    SQLcommand.append(",'" & txtPortofLoading.Text & "'") 'PortOfLoading
        '    SQLcommand.append(",'" & txtPortofDischarge.Text & "'") 'PortOfDischarge
        '    SQLcommand.append(",'" & txtPlaceofDelivery.Text & "'") 'PlaceOfDelivery
        '    SQLcommand.append(",'" & txtLocalVessel.Text & "'") 'LocalVessel
        '    SQLcommand.append(",'" & txtLocalVoy.Text & "'") 'LocalVoy
        '    SQLcommand.append(",'" & txtOceanVessel.Text & "'") 'OceanVessel
        '    SQLcommand.append(",'" & txtOceanVoy.Text & "'") 'OceanVoy
        '    SQLcommand.append(",'" & txtagentPartner.Text & "'") 'agentPartner
        '    SQLcommand.append(",'" & txtagentaddress.Text & "'") 'agentaddress
        '    SQLcommand.append(",'" & txtagentContact.Text & "'") 'agentContact
        '    SQLcommand.append(",'" & txtCustomerCoLoad.Text & "'") 'CustomerCoLoad
        '    SQLcommand.append(",'" & txtCustomeraddress.Text & "'") 'Customeraddress
        '    SQLcommand.append(",'" & txtCustomerContact.Text & "'") 'CustomerContact
        '    SQLcommand.append(",'" & txtRemark.Text & "'") 'Remark
        '    SQLcommand.append(",'" & txtagentCoLoad.Text & "'") 'agentCoLoad
        '    SQLcommand.append(",'" & txtCoLoadContact.Text & "'") 'CoLoadContact
        '    SQLcommand.append(",'" & txtVesselagent.Text & "'") 'Vesselagent
        '    SQLcommand.append(",'" & txtVesselContact.Text & "'") 'VesselContact
        '    SQLcommand.append(",'" & txtVesselBooking.Text & "'") 'VesselBooking
        '    SQLcommand.Append(",'" & LetDate(dtpPickDate.Value) & "'") 'PickDate
        '    SQLcommand.append(",'" & txtPickLocation.Text & "'") 'PickLocation
        '    SQLcommand.append(",'" & txtPickTime.Text & "'") 'PickTime
        '    SQLcommand.append(",'" & txtPickContact.Text & "'") 'PickContact
        '    SQLcommand.Append(",'" & LetDate(dtpLoadDate.Value) & "'") 'LoadDate
        '    SQLcommand.append(",'" & txtLoadLocation.Text & "'") 'LoadLocation
        '    SQLcommand.append(",'" & txtLoadTime.Text & "'") 'LoadTime
        '    SQLcommand.append(",'" & txtLoadContact.Text & "'") 'LoadContact
        '    SQLcommand.Append(",'" & LetDate(dtpReturnDate.Value) & "'") 'ReturnDate
        '    SQLcommand.append(",'" & txtReturnLocation.Text & "'") 'ReturnLocation
        '    SQLcommand.append(",'" & txtReturnTime.Text & "'") 'ReturnTime
        '    SQLcommand.append(",'" & txtReturnContact.Text & "'") 'ReturnContact
        '    SQLcommand.Append(",'" & LetDate(dtpCloseRNDate.Value) & "'") 'CloseRNDate
        '    SQLcommand.append(",'" & txtCloseRNTime.Text & "'") 'CloseRNTime
        '    SQLcommand.Append(",'" & LetDate(dtpCloseSIDate.Value) & "'") 'CloseSIDate
        '    SQLcommand.append(",'" & txtCloseSITime.Text & "'") 'CloseSITime
        '    SQLcommand.Append(",'" & LetDate(dtpCloseVGMDate.Value) & "'") 'CloseVGMDate
        '    SQLcommand.append(",'" & txtCloseVGMTime.Text & "'") 'CloseVGMTime
        '    SQLcommand.append(",'" & txtMarkNumber.Text & "'") 'MarkNumber
        '    SQLcommand.append(",'" & txtContainer.Text & "'") 'Container
        '    SQLcommand.append(",'" & CInt(txtPackageQty.Text) & "'") 'PackageQty
        '    SQLcommand.append(",'" & txtPackageType.Text & "'") 'PackageType
        '    SQLcommand.append(",'" & CDbl(txtCBM.Text) & "'") 'CBM
        '    SQLcommand.append(",'" & CDbl(txtPackageGW.Text) & "'") 'PackageGW
        '    SQLcommand.append(",'" & CInt(txtQtyContainer1.Text) & "'") 'QtyContainer1
        '    SQLcommand.append(",'" & txtContainerType1.Text & "'") 'ContainerType1
        '    SQLcommand.append(",'" & CDbl(txtContainerNW1.Text) & "'") 'ContainerNW1
        '    SQLcommand.append(",'" & CDbl(txtContainerGW1.Text) & "'") 'ContainerGW1
        '    SQLcommand.append(",'" & CInt(txtQtyContainer2.Text) & "'") 'QtyContainer2
        '    SQLcommand.append(",'" & txtContainerType2.Text & "'") 'ContainerType2
        '    SQLcommand.append(",'" & CDbl(txtContainerNW2.Text) & "'") 'ContainerNW2
        '    SQLcommand.append(",'" & CDbl(txtContainerGW2.Text) & "'") 'ContainerGW2
        '    SQLcommand.append(",'" & cboBookingType.Text & "'") 'BookingType
        '    SQLcommand.Append(",'" & LetDate(dtpETD.Value) & "'") 'ETD
        '    SQLcommand.Append(",'" & LetDate(dtpETa.Value) & "'") 'ETa
        '    SQLcommand.append(",'" & txtDescriptionOfGoods.Text & "'") 'DescriptionOfGoods
        '    SQLcommand.append(",'" & cboNoOfOriginalBL.Text & "'") 'NoOfOriginalBL
        '    SQLcommand.append(",'" & cboTermOfPayment.Text & "'") 'TermOfPayment
        '    SQLcommand.Append(",'" & LetDate(dtpBookingNoDate.Value) & "'")
        '    SQLcommand.append(",'" & txtShipperCode.Text & "'")
        '    SQLcommand.append(",'" & txtConsigneeCode.Text & "'")
        '    SQLcommand.append(",'" & txtNotifyCode.Text & "'")
        '    SQLcommand.append(",'" & txtCustCode.Text & "'")
        '    SQLcommand.append(",'" & txtagentCode.Text & "'")
        '    SQLcommand.append(",'" & txtVesselCode.Text & "'")
        '    SQLcommand.append(",'" & txtPartnerCode.Text & "'")
        '    SQLcommand.append(",'" & _Insert & "'") '//Insert Or Update
        '    Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
        '    If result = 1 Then
        '        MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        _IsNew = True
        '    Else
        '        MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    End If
        '    nection.Close()
        'Catch ex as Exception
        '    MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try
    End Sub
    Private Sub GetIdent()
        Try
            Dim dr As DataRow
            Dim sqlstr As String = "SELECT DISTINCT Ident FROM [Freight_BookingConfirm] where BookingNo='" & txtBookingNo.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtIdent.Text = CInt(dr("Ident")).ToString
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub BookingRunning()
        GetRunningFormat("BKG")
        txtBookingNo.Text = CreateNumber("Freight_BookingConfirm", "BookingNo", dtpBookingNoDate.Value)
    End Sub

    Private Sub Button10_Click(sender As Object, e As Eventargs) Handles Button10.Click
        AddNewBooking()
    End Sub
    Private Sub AddNewBooking()
        'txtIdent.ResetText() 'Ident
        txtIdent.Text = "0"
        txtBookingNo.ResetText() 'BookingNo
        txtUserBooking.ResetText() 'BookingUser
        txtQuotationNo.ResetText() 'QuotationNo
        txtUserQuotation.ResetText() 'QuotationUser
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
        txtPlaceofReceive.ResetText() 'PlaceOfReceive
        txtPortofLoading.ResetText() 'PortOfLoading
        txtPortofDischarge.ResetText() 'PortOfDischarge
        txtPlaceofDelivery.ResetText() 'PlaceOfDelivery
        txtLocalVessel.ResetText() 'LocalVessel
        txtLocalVoy.ResetText() 'LocalVoy
        txtOceanVessel.ResetText() 'OceanVessel
        txtOceanVoy.ResetText() 'OceanVoy
        txtagentPartner.ResetText() 'agentPartner
        txtagentaddress.ResetText() 'agentaddress
        txtagentContact.ResetText() 'agentContact
        txtCustomerCoLoad.ResetText() 'CustomerCoLoad
        txtCustomeraddress.ResetText() 'Customeraddress
        txtCustomerContact.ResetText() 'CustomerContact
        txtRemark.ResetText() 'Remark
        txtagentCoLoad.ResetText() 'agentCoLoad
        txtCoLoadContact.ResetText() 'CoLoadContact
        txtVesselagent.ResetText() 'Vesselagent
        txtVesselContact.ResetText() 'VesselContact
        txtVesselBooking.ResetText() 'VesselBooking
        txtPickLocation.ResetText() 'PickLocation
        txtPickTime.ResetText() 'PickTime
        txtPickContact.ResetText() 'PickContact
        txtLoadLocation.ResetText() 'LoadLocation
        txtLoadTime.ResetText() 'LoadTime
        txtLoadContact.ResetText() 'LoadContact
        txtReturnLocation.ResetText() 'ReturnLocation
        txtReturnTime.ResetText() 'ReturnTime
        txtReturnContact.ResetText() 'ReturnContact
        txtCloseRNTime.ResetText() 'CloseRNTime
        txtCloseSITime.ResetText() 'CloseSITime
        txtCloseVGMTime.ResetText() 'CloseVGMTime
        txtMarkNumber.ResetText() 'MarkNumber
        txtContainer.ResetText() 'Container
        txtPackageQty.Text = "0" 'PackageQty
        txtPackageType.ResetText() 'PackageType
        txtCBM.Text = "0" 'CBM
        txtPackageGW.Text = "0" 'PackageGW
        txtQtyContainer1.Text = "0" 'QtyContainer1
        txtContainerType1.ResetText() 'ContainerType1
        txtContainerNW1.Text = "0" 'ContainerNW1
        txtContainerGW1.Text = "0" 'ContainerGW1
        txtQtyContainer2.Text = "0" 'QtyContainer2
        txtContainerType2.ResetText() 'ContainerType2
        txtContainerNW2.Text = "0" 'ContainerNW2
        txtContainerGW2.Text = "0" 'ContainerGW2
        txtDescriptionOfGoods.ResetText() 'DescriptionOfGoods


        txtShipperCode.ResetText() 'ShipperCode
        txtConsigneeCode.ResetText() 'ConsigneeCode
        txtNotifyCode.ResetText() 'NotifyCode
        txtCustCode.ResetText() 'CustCode
        txtagentCode.ResetText() 'AgentCode
        txtVesselCode.ResetText() 'VesselCode
        txtPartnerCode.ResetText() 'PartnerCode

        SetDigitText()

        _IsNew = True
    End Sub

    Private Sub BookingConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUserBooking.Text = UserProfile.U_FName & " " & UserProfile.U_LName
        AddNewBooking()
    End Sub

    Private Sub txtContainerGW2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtQuotationNo_ButtonClick(sender As Object, e As EventArgs) Handles txtQuotationNo.ButtonClick
        Dim dr As DataRow
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
      ,[Remark],CreateUser,[Ident]  FROM Freight_Quotation WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtQuotationNo.Text = dr("QuotationNo").ToString
            txtUserQuotation.Text = dr("CreateUser").ToString
            txtType.Text = dr("QuotationType").ToString
            If txtType.Text = "IMPORT" Then
                txtConsignee.Text = dr("Customer").ToString
                txtConsigneeaddress.Text = dr("Customeraddress").ToString
                txtConsigneeContact.Text = dr("CustomerCOntact").ToString
            ElseIf txtType.Text = "EXPORT" Then
                txtShipper.Text = dr("Customer").ToString
                txtShipperaddress.Text = dr("Customeraddress").ToString
                txtShipperContact.Text = dr("CustomerContact").ToString
            End If
            _IsNew = False
        End If
    End Sub

    Private Sub txtShipper_ButtonClick(sender As Object, e As EventArgs) Handles txtShipper.ButtonClick
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
      ,[CustEAddress]
      ,[CustDate] FROM Mas_CustomerFreight WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtShipper.Text = dr("CustCompanyName").ToString
            txtShipperCode.Text = dr("CustCompanyID").ToString
            txtShipperaddress.Text = dr("CustAddress").ToString
            txtShipperContact.Text = (dr("CustPhone") + " " + dr("CustFax")).ToString
        End If
    End Sub
    Private Sub txtConsignee_ButtonClick(sender As Object, e As EventArgs) Handles txtConsignee.ButtonClick
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
      ,[CustEAddress]
      ,[CustDate] FROM Mas_CustomerFreight WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtConsignee.Text = dr("CustCompanyName").ToString
            txtConsigneeCode.Text = dr("CustCompanyID").ToString
            txtConsigneeaddress.Text = dr("CustAddress").ToString
            txtConsigneeContact.Text = (dr("CustPhone") + " " + dr("CustFax")).ToString
        End If
    End Sub
    Private Sub txtNotifyParty_ButtonClick(sender As Object, e As EventArgs) Handles txtNotifyParty.ButtonClick
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
      ,[CustEAddress]
      ,[CustDate] FROM Mas_CustomerFreight WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtNotifyParty.Text = dr("CustCompanyName").ToString
            txtNotifyCode.Text = dr("CustCompanyID").ToString
            txtNotifyaddress.Text = dr("CustAddress").ToString
        End If
    End Sub
    Private Sub txtCustomerCoLoad_ButtonClick(sender As Object, e As EventArgs) Handles txtCustomerCoLoad.ButtonClick
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
      ,[CustEAddress]
      ,[CustDate] FROM Mas_CustomerFreight WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtCustomerCoLoad.Text = dr("CustCompanyName").ToString
            txtCustCode.Text = dr("CustCompanyID").ToString
            txtCustomeraddress.Text = dr("CustAddress").ToString
            txtCustomerContact.Text = (dr("CustPhone") + " " + dr("CustFax")).ToString
        End If
    End Sub
    Private Sub txtagentCoLoad_ButtonClick(sender As Object, e As EventArgs) Handles txtagentCoLoad.ButtonClick
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
      ,[CustEAddress]
      ,[CustDate] FROM Mas_CustomerFreight WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtagentCoLoad.Text = dr("CustCompanyName").ToString
            txtagentCode.Text = dr("CustCompanyID").ToString
            txtCoLoadContact.Text = (dr("CustPhone") + " " + dr("CustFax")).ToString
        End If
    End Sub
    Private Sub txtVesselagent_ButtonClick(sender As Object, e As EventArgs) Handles txtVesselagent.ButtonClick
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
      ,[CustEAddress]
      ,[CustDate] FROM Mas_CustomerFreight WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtVesselagent.Text = dr("CustCompanyName").ToString
            txtVesselCode.Text = dr("CustCompanyID").ToString
            txtVesselContact.Text = (dr("CustPhone") + " " + dr("CustFax")).ToString
        End If
    End Sub
    Private Sub txtagentPartner_ButtonClick(sender As Object, e As EventArgs) Handles txtagentPartner.ButtonClick
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
      ,[CustEAddress]
      ,[CustDate] FROM Mas_CustomerFreight WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtagentPartner.Text = dr("CustCompanyName").ToString
            txtPartnerCode.Text = dr("CustCompanyID").ToString
            txtagentaddress.Text = dr("CustAddress").ToString
            txtagentContact.Text = (dr("CustPhone") + " " + dr("CustFax")).ToString
        End If
    End Sub
    Private Sub txtPackageType_ButtonClick(sender As Object, e As EventArgs) Handles txtPackageType.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) PackageCode,PackageDescription  FROM Freight_PackageType WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPackageType.Text = dr("PackageCode").ToString
        End If
    End Sub
    Private Sub txtContainerType1_ButtonClick(sender As Object, e As EventArgs) Handles txtContainerType1.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) ContainerType FROM Freight_ContainerType WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtContainerType1.Text = dr("ContainerType").ToString
        End If
    End Sub
    Private Sub txtContainerType2_ButtonClick(sender As Object, e As EventArgs) Handles txtContainerType2.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) ContainerType FROM Freight_ContainerType WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtContainerType2.Text = dr("ContainerType").ToString
        End If
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
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
            txtUserBooking.Text = dr("BookingUser").ToString
            txtQuotationNo.Text = dr("QuotationNo").ToString
            txtUserQuotation.Text = dr("QuotationUser").ToString
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
            txtPlaceofReceive.Text = dr("PlaceofReceive").ToString
            txtPortofLoading.Text = dr("PortofLoading").ToString
            txtPortofDischarge.Text = dr("PortofDischarge").ToString
            txtPlaceofDelivery.Text = dr("PlaceofDelivery").ToString
            txtLocalVessel.Text = dr("LocalVessel").ToString
            txtLocalVoy.Text = dr("LocalVoy").ToString
            txtOceanVessel.Text = dr("OceanVessel").ToString
            txtOceanVoy.Text = dr("OceanVoy").ToString
            txtagentPartner.Text = dr("agentPartner").ToString
            txtagentaddress.Text = dr("agentaddress").ToString
            txtagentContact.Text = dr("agentContact").ToString
            txtCustomerCoLoad.Text = dr("CustomerCoLoad").ToString
            txtCustomeraddress.Text = dr("Customeraddress").ToString
            txtCustomerContact.Text = dr("CustomerContact").ToString
            txtRemark.Text = dr("Remark").ToString
            txtagentCoLoad.Text = dr("agentCoLoad").ToString
            txtCoLoadContact.Text = dr("CoLoadContact").ToString
            txtVesselagent.Text = dr("Vesselagent").ToString
            txtVesselContact.Text = dr("VesselContact").ToString
            txtVesselBooking.Text = dr("VesselBooking").ToString
            dtpPickDate.Value = CDate(dr("PickDate")).ToString
            txtPickLocation.Text = dr("PickLocation").ToString
            txtPickTime.Text = dr("PickTime").ToString
            txtPickContact.Text = dr("PickContact").ToString
            dtpLoadDate.Value = dr("LoadDate").ToString
            txtLoadLocation.Text = dr("LoadLocation").ToString
            txtLoadTime.Text = dr("LoadTime").ToString
            txtLoadContact.Text = dr("LoadContact").ToString
            dtpReturnDate.Value = dr("ReturnDate").ToString
            txtReturnLocation.Text = dr("ReturnLocation").ToString
            txtReturnTime.Text = dr("ReturnTime").ToString
            txtReturnContact.Text = dr("ReturnContact").ToString
            dtpCloseRNDate.Text = dr("CloseRNDate").ToString
            txtCloseRNTime.Text = dr("CloseRNTime").ToString
            dtpCloseSIDate.Text = dr("CloseSIDate").ToString
            txtCloseSITime.Text = dr("CloseSITime").ToString
            dtpCloseVGMDate.Text = dr("CloseVGMDate").ToString
            txtCloseVGMTime.Text = dr("CloseVGMTime").ToString
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
            cboBookingType.Text = dr("BookingType").ToString
            dtpETD.Value = dr("ETD").ToString
            dtpETa.Value = dr("ETa").ToString
            txtDescriptionOfGoods.Text = dr("DescriptionOfGoods").ToString
            cboNoOfOriginalBL.Text = dr("NoOfOriginalBL").ToString
            cboTermOfPayment.Text = dr("TermOfPayment").ToString
            dtpBookingNoDate.Text = dr("BookingNoDate").ToString
            txtShipperCode.Text = dr("ShipperCode").ToString
            txtConsigneeCode.Text = dr("ConsigneeCode").ToString
            txtNotifyCode.Text = dr("NotifyCode").ToString
            txtCustCode.Text = dr("CustCode").ToString
            txtagentCode.Text = dr("agentCode").ToString
            txtVesselCode.Text = dr("VesselCode").ToString
            txtPartnerCode.Text = dr("PartnerCode").ToString
            txtIdent.Text = dr("Ident").ToString
            _IsNew = False
            SetDigitText()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim url As String = "http://203.170.129.23/TESTFRIEGHT/report/Booking?BookNo=" & txtBookingNo.Text
        Try
            Process.Start("chrome.exe", url)
        Catch ex As Exception
            Process.Start(url)
        End Try
    End Sub
    Private Sub txtPlaceOfReceive_ButtonClick(sender As Object, e As EventArgs) Handles txtPlaceofReceive.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPlaceofReceive.Text = dr("PortName").ToString
        End If
    End Sub
    Private Sub txtPortOfLoading_ButtonClick(sender As Object, e As EventArgs) Handles txtPortofLoading.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPortofLoading.Text = dr("PortName").ToString
        End If
    End Sub
    Private Sub txtPortOfDischarge_ButtonClick(sender As Object, e As EventArgs) Handles txtPortofDischarge.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPortofDischarge.Text = dr("PortName").ToString
        End If
    End Sub
    Private Sub txtPlaceOfDelivery_ButtonClick(sender As Object, e As EventArgs) Handles txtPlaceofDelivery.ButtonClick
        Dim dr As DataRow
        dr = PopUpSearch("SELECT TOP(100) [PortCode]
      ,[PortName]
      ,[CountryCode]  FROM Mas_InterPort WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtPlaceofDelivery.Text = dr("PortName").ToString
        End If
    End Sub
    Private Sub MetroTextBox1_ButtonClick(sender As Object, e As EventArgs) Handles MetroTextBox1.ButtonClick
        If _IsNew = True Then
            _IsNew = False
            GetIdent()
            MsgBox("UPDATING OLD DATA!!!")
        ElseIf _IsNew = False Then
            _IsNew = True
            MsgBox("SAVING NEW DATA!!!")
        End If
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

    Private Sub txtShipperContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVesselContact.KeyPress, txtVesselBooking.KeyPress, txtShipperRef.KeyPress, txtShipperContact.KeyPress, txtReturnLocation.KeyPress, txtReturnContact.KeyPress, txtPickLocation.KeyPress, txtPickContact.KeyPress, txtLoadLocation.KeyPress, txtLoadContact.KeyPress, txtCustomerContact.KeyPress, txtContainer.KeyPress, txtConsigneeRef.KeyPress, txtConsigneeContact.KeyPress, txtCoLoadContact.KeyPress, txtagentContact.KeyPress
        CheckDash(e)
    End Sub
End Class