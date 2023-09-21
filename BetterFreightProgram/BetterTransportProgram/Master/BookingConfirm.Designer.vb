<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookingConfirm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing as Boolean)
        Try
            If disposing andalso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components as System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPartnerCode = New MetroFramework.Controls.MetroTextBox()
        Me.txtNotifyCode = New MetroFramework.Controls.MetroTextBox()
        Me.txtConsigneeCode = New MetroFramework.Controls.MetroTextBox()
        Me.txtVesselCode = New MetroFramework.Controls.MetroTextBox()
        Me.txtagentCode = New MetroFramework.Controls.MetroTextBox()
        Me.txtCustCode = New MetroFramework.Controls.MetroTextBox()
        Me.txtShipperCode = New MetroFramework.Controls.MetroTextBox()
        Me.txtType = New MetroFramework.Controls.MetroTextBox()
        Me.dtpBookingNoDate = New MetroFramework.Controls.MetroDateTime()
        Me.txtIdent = New MetroFramework.Controls.MetroTextBox()
        Me.txtUserQuotation = New MetroFramework.Controls.MetroTextBox()
        Me.txtUserBooking = New MetroFramework.Controls.MetroTextBox()
        Me.txtQuotationNo = New MetroFramework.Controls.MetroTextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtBookingNo = New MetroFramework.Controls.MetroTextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.cboNoOfOriginalBL = New MetroFramework.Controls.MetroComboBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.dtpETa = New MetroFramework.Controls.MetroDateTime()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.dtpETD = New MetroFramework.Controls.MetroDateTime()
        Me.cboTermOfPayment = New MetroFramework.Controls.MetroComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.cboBookingType = New MetroFramework.Controls.MetroComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtDescriptionOfGoods = New MetroFramework.Controls.MetroTextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtPackageGW = New MetroFramework.Controls.MetroTextBox()
        Me.txtCBM = New MetroFramework.Controls.MetroTextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtContainerGW2 = New MetroFramework.Controls.MetroTextBox()
        Me.txtContainerGW1 = New MetroFramework.Controls.MetroTextBox()
        Me.txtContainerNW2 = New MetroFramework.Controls.MetroTextBox()
        Me.txtContainerNW1 = New MetroFramework.Controls.MetroTextBox()
        Me.txtQtyContainer2 = New MetroFramework.Controls.MetroTextBox()
        Me.txtContainerType2 = New MetroFramework.Controls.MetroTextBox()
        Me.txtQtyContainer1 = New MetroFramework.Controls.MetroTextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtContainerType1 = New MetroFramework.Controls.MetroTextBox()
        Me.txtPackageQty = New MetroFramework.Controls.MetroTextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtPackageType = New MetroFramework.Controls.MetroTextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtContainer = New MetroFramework.Controls.MetroTextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtMarkNumber = New MetroFramework.Controls.MetroTextBox()
        Me.txtCoLoadContact = New MetroFramework.Controls.MetroTextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtagentCoLoad = New MetroFramework.Controls.MetroTextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtRemark = New MetroFramework.Controls.MetroTextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtCustomeraddress = New MetroFramework.Controls.MetroTextBox()
        Me.txtCustomerContact = New MetroFramework.Controls.MetroTextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtCustomerCoLoad = New MetroFramework.Controls.MetroTextBox()
        Me.txtCloseVGMTime = New System.Windows.Forms.MaskedTextBox()
        Me.dtpCloseVGMDate = New MetroFramework.Controls.MetroDateTime()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtCloseSITime = New System.Windows.Forms.MaskedTextBox()
        Me.dtpCloseSIDate = New MetroFramework.Controls.MetroDateTime()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.dtpPickDate = New MetroFramework.Controls.MetroDateTime()
        Me.txtagentaddress = New MetroFramework.Controls.MetroTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtagentContact = New MetroFramework.Controls.MetroTextBox()
        Me.txtVesselContact = New MetroFramework.Controls.MetroTextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtVesselagent = New MetroFramework.Controls.MetroTextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.txtagentPartner = New MetroFramework.Controls.MetroTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOceanVoy = New MetroFramework.Controls.MetroTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLocalVoy = New MetroFramework.Controls.MetroTextBox()
        Me.txtVesselBooking = New MetroFramework.Controls.MetroTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtPickLocation = New MetroFramework.Controls.MetroTextBox()
        Me.txtOceanVessel = New MetroFramework.Controls.MetroTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtLocalVessel = New MetroFramework.Controls.MetroTextBox()
        Me.txtCloseRNTime = New System.Windows.Forms.MaskedTextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtLoadLocation = New MetroFramework.Controls.MetroTextBox()
        Me.txtPlaceofDelivery = New MetroFramework.Controls.MetroTextBox()
        Me.txtReturnTime = New System.Windows.Forms.MaskedTextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtPickContact = New MetroFramework.Controls.MetroTextBox()
        Me.txtPortofDischarge = New MetroFramework.Controls.MetroTextBox()
        Me.txtLoadTime = New System.Windows.Forms.MaskedTextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtPortofLoading = New MetroFramework.Controls.MetroTextBox()
        Me.txtPickTime = New System.Windows.Forms.MaskedTextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtLoadContact = New MetroFramework.Controls.MetroTextBox()
        Me.txtPlaceofReceive = New MetroFramework.Controls.MetroTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNotifyaddress = New MetroFramework.Controls.MetroTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtReturnLocation = New MetroFramework.Controls.MetroTextBox()
        Me.txtNotifyParty = New MetroFramework.Controls.MetroTextBox()
        Me.txtReturnContact = New MetroFramework.Controls.MetroTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtConsigneeaddress = New MetroFramework.Controls.MetroTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtShipperaddress = New MetroFramework.Controls.MetroTextBox()
        Me.dtpLoadDate = New MetroFramework.Controls.MetroDateTime()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtConsigneeRef = New MetroFramework.Controls.MetroTextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpReturnDate = New MetroFramework.Controls.MetroDateTime()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpCloseRNDate = New MetroFramework.Controls.MetroDateTime()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtConsigneeContact = New MetroFramework.Controls.MetroTextBox()
        Me.txtShipperRef = New MetroFramework.Controls.MetroTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtShipperContact = New MetroFramework.Controls.MetroTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConsignee = New MetroFramework.Controls.MetroTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtShipper = New MetroFramework.Controls.MetroTextBox()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.MetroTextBox1 = New MetroFramework.Controls.MetroTextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPartnerCode)
        Me.GroupBox1.Controls.Add(Me.txtNotifyCode)
        Me.GroupBox1.Controls.Add(Me.txtConsigneeCode)
        Me.GroupBox1.Controls.Add(Me.txtVesselCode)
        Me.GroupBox1.Controls.Add(Me.txtagentCode)
        Me.GroupBox1.Controls.Add(Me.txtCustCode)
        Me.GroupBox1.Controls.Add(Me.txtShipperCode)
        Me.GroupBox1.Controls.Add(Me.txtType)
        Me.GroupBox1.Controls.Add(Me.dtpBookingNoDate)
        Me.GroupBox1.Controls.Add(Me.txtIdent)
        Me.GroupBox1.Controls.Add(Me.txtUserQuotation)
        Me.GroupBox1.Controls.Add(Me.txtUserBooking)
        Me.GroupBox1.Controls.Add(Me.txtQuotationNo)
        Me.GroupBox1.Controls.Add(Me.Label56)
        Me.GroupBox1.Controls.Add(Me.txtBookingNo)
        Me.GroupBox1.Controls.Add(Me.Label55)
        Me.GroupBox1.Controls.Add(Me.Label54)
        Me.GroupBox1.Controls.Add(Me.cboNoOfOriginalBL)
        Me.GroupBox1.Controls.Add(Me.Label53)
        Me.GroupBox1.Controls.Add(Me.dtpETa)
        Me.GroupBox1.Controls.Add(Me.Label52)
        Me.GroupBox1.Controls.Add(Me.dtpETD)
        Me.GroupBox1.Controls.Add(Me.cboTermOfPayment)
        Me.GroupBox1.Controls.Add(Me.Label51)
        Me.GroupBox1.Controls.Add(Me.cboBookingType)
        Me.GroupBox1.Controls.Add(Me.Label50)
        Me.GroupBox1.Controls.Add(Me.Label47)
        Me.GroupBox1.Controls.Add(Me.txtDescriptionOfGoods)
        Me.GroupBox1.Controls.Add(Me.Label41)
        Me.GroupBox1.Controls.Add(Me.Label40)
        Me.GroupBox1.Controls.Add(Me.txtPackageGW)
        Me.GroupBox1.Controls.Add(Me.txtCBM)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.txtContainerGW2)
        Me.GroupBox1.Controls.Add(Me.txtContainerGW1)
        Me.GroupBox1.Controls.Add(Me.txtContainerNW2)
        Me.GroupBox1.Controls.Add(Me.txtContainerNW1)
        Me.GroupBox1.Controls.Add(Me.txtQtyContainer2)
        Me.GroupBox1.Controls.Add(Me.txtContainerType2)
        Me.GroupBox1.Controls.Add(Me.txtQtyContainer1)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.txtContainerType1)
        Me.GroupBox1.Controls.Add(Me.txtPackageQty)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.txtPackageType)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Controls.Add(Me.txtContainer)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.txtMarkNumber)
        Me.GroupBox1.Controls.Add(Me.txtCoLoadContact)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.txtagentCoLoad)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.txtCustomeraddress)
        Me.GroupBox1.Controls.Add(Me.txtCustomerContact)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.txtCustomerCoLoad)
        Me.GroupBox1.Controls.Add(Me.txtCloseVGMTime)
        Me.GroupBox1.Controls.Add(Me.dtpCloseVGMDate)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.txtCloseSITime)
        Me.GroupBox1.Controls.Add(Me.dtpCloseSIDate)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label46)
        Me.GroupBox1.Controls.Add(Me.dtpPickDate)
        Me.GroupBox1.Controls.Add(Me.txtagentaddress)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtagentContact)
        Me.GroupBox1.Controls.Add(Me.txtVesselContact)
        Me.GroupBox1.Controls.Add(Me.Label48)
        Me.GroupBox1.Controls.Add(Me.txtVesselagent)
        Me.GroupBox1.Controls.Add(Me.Label49)
        Me.GroupBox1.Controls.Add(Me.txtagentPartner)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtOceanVoy)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtLocalVoy)
        Me.GroupBox1.Controls.Add(Me.txtVesselBooking)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label44)
        Me.GroupBox1.Controls.Add(Me.txtPickLocation)
        Me.GroupBox1.Controls.Add(Me.txtOceanVessel)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label45)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtLocalVessel)
        Me.GroupBox1.Controls.Add(Me.txtCloseRNTime)
        Me.GroupBox1.Controls.Add(Me.Label43)
        Me.GroupBox1.Controls.Add(Me.txtLoadLocation)
        Me.GroupBox1.Controls.Add(Me.txtPlaceofDelivery)
        Me.GroupBox1.Controls.Add(Me.txtReturnTime)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.txtPickContact)
        Me.GroupBox1.Controls.Add(Me.txtPortofDischarge)
        Me.GroupBox1.Controls.Add(Me.txtLoadTime)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtPortofLoading)
        Me.GroupBox1.Controls.Add(Me.txtPickTime)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.txtLoadContact)
        Me.GroupBox1.Controls.Add(Me.txtPlaceofReceive)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtNotifyaddress)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtReturnLocation)
        Me.GroupBox1.Controls.Add(Me.txtNotifyParty)
        Me.GroupBox1.Controls.Add(Me.txtReturnContact)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtConsigneeaddress)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtShipperaddress)
        Me.GroupBox1.Controls.Add(Me.dtpLoadDate)
        Me.GroupBox1.Controls.Add(Me.Label42)
        Me.GroupBox1.Controls.Add(Me.txtConsigneeRef)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.dtpReturnDate)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.dtpCloseRNDate)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtConsigneeContact)
        Me.GroupBox1.Controls.Add(Me.txtShipperRef)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtShipperContact)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtConsignee)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtShipper)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(1151, 772)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        '
        'txtPartnerCode
        '
        '
        '
        '
        Me.txtPartnerCode.CustomButton.Image = Nothing
        Me.txtPartnerCode.CustomButton.Location = New System.Drawing.Point(59, 2)
        Me.txtPartnerCode.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPartnerCode.CustomButton.Name = ""
        Me.txtPartnerCode.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtPartnerCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPartnerCode.CustomButton.TabIndex = 1
        Me.txtPartnerCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPartnerCode.CustomButton.UseSelectable = True
        Me.txtPartnerCode.CustomButton.Visible = False
        Me.txtPartnerCode.Lines = New String(-1) {}
        Me.txtPartnerCode.Location = New System.Drawing.Point(336, 583)
        Me.txtPartnerCode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPartnerCode.MaxLength = 32767
        Me.txtPartnerCode.Multiline = True
        Me.txtPartnerCode.Name = "txtPartnerCode"
        Me.txtPartnerCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPartnerCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPartnerCode.SelectedText = ""
        Me.txtPartnerCode.SelectionLength = 0
        Me.txtPartnerCode.SelectionStart = 0
        Me.txtPartnerCode.Size = New System.Drawing.Size(81, 24)
        Me.txtPartnerCode.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPartnerCode.TabIndex = 268
        Me.txtPartnerCode.UseCustomBackColor = True
        Me.txtPartnerCode.UseCustomForeColor = True
        Me.txtPartnerCode.UseSelectable = True
        Me.txtPartnerCode.UseStyleColors = True
        Me.txtPartnerCode.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPartnerCode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtNotifyCode
        '
        '
        '
        '
        Me.txtNotifyCode.CustomButton.Image = Nothing
        Me.txtNotifyCode.CustomButton.Location = New System.Drawing.Point(59, 2)
        Me.txtNotifyCode.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNotifyCode.CustomButton.Name = ""
        Me.txtNotifyCode.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtNotifyCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtNotifyCode.CustomButton.TabIndex = 1
        Me.txtNotifyCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtNotifyCode.CustomButton.UseSelectable = True
        Me.txtNotifyCode.CustomButton.Visible = False
        Me.txtNotifyCode.Lines = New String(-1) {}
        Me.txtNotifyCode.Location = New System.Drawing.Point(337, 320)
        Me.txtNotifyCode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNotifyCode.MaxLength = 32767
        Me.txtNotifyCode.Multiline = True
        Me.txtNotifyCode.Name = "txtNotifyCode"
        Me.txtNotifyCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNotifyCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtNotifyCode.SelectedText = ""
        Me.txtNotifyCode.SelectionLength = 0
        Me.txtNotifyCode.SelectionStart = 0
        Me.txtNotifyCode.Size = New System.Drawing.Size(81, 24)
        Me.txtNotifyCode.Style = MetroFramework.MetroColorStyle.Green
        Me.txtNotifyCode.TabIndex = 267
        Me.txtNotifyCode.UseCustomBackColor = True
        Me.txtNotifyCode.UseCustomForeColor = True
        Me.txtNotifyCode.UseSelectable = True
        Me.txtNotifyCode.UseStyleColors = True
        Me.txtNotifyCode.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtNotifyCode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtConsigneeCode
        '
        '
        '
        '
        Me.txtConsigneeCode.CustomButton.Image = Nothing
        Me.txtConsigneeCode.CustomButton.Location = New System.Drawing.Point(59, 2)
        Me.txtConsigneeCode.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConsigneeCode.CustomButton.Name = ""
        Me.txtConsigneeCode.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtConsigneeCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtConsigneeCode.CustomButton.TabIndex = 1
        Me.txtConsigneeCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtConsigneeCode.CustomButton.UseSelectable = True
        Me.txtConsigneeCode.CustomButton.Visible = False
        Me.txtConsigneeCode.Lines = New String(-1) {}
        Me.txtConsigneeCode.Location = New System.Drawing.Point(337, 169)
        Me.txtConsigneeCode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConsigneeCode.MaxLength = 32767
        Me.txtConsigneeCode.Multiline = True
        Me.txtConsigneeCode.Name = "txtConsigneeCode"
        Me.txtConsigneeCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtConsigneeCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtConsigneeCode.SelectedText = ""
        Me.txtConsigneeCode.SelectionLength = 0
        Me.txtConsigneeCode.SelectionStart = 0
        Me.txtConsigneeCode.Size = New System.Drawing.Size(81, 24)
        Me.txtConsigneeCode.Style = MetroFramework.MetroColorStyle.Green
        Me.txtConsigneeCode.TabIndex = 266
        Me.txtConsigneeCode.UseCustomBackColor = True
        Me.txtConsigneeCode.UseCustomForeColor = True
        Me.txtConsigneeCode.UseSelectable = True
        Me.txtConsigneeCode.UseStyleColors = True
        Me.txtConsigneeCode.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtConsigneeCode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtVesselCode
        '
        '
        '
        '
        Me.txtVesselCode.CustomButton.Image = Nothing
        Me.txtVesselCode.CustomButton.Location = New System.Drawing.Point(59, 2)
        Me.txtVesselCode.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVesselCode.CustomButton.Name = ""
        Me.txtVesselCode.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtVesselCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtVesselCode.CustomButton.TabIndex = 1
        Me.txtVesselCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtVesselCode.CustomButton.UseSelectable = True
        Me.txtVesselCode.CustomButton.Visible = False
        Me.txtVesselCode.Lines = New String(-1) {}
        Me.txtVesselCode.Location = New System.Drawing.Point(753, 264)
        Me.txtVesselCode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVesselCode.MaxLength = 32767
        Me.txtVesselCode.Multiline = True
        Me.txtVesselCode.Name = "txtVesselCode"
        Me.txtVesselCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtVesselCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtVesselCode.SelectedText = ""
        Me.txtVesselCode.SelectionLength = 0
        Me.txtVesselCode.SelectionStart = 0
        Me.txtVesselCode.Size = New System.Drawing.Size(81, 24)
        Me.txtVesselCode.Style = MetroFramework.MetroColorStyle.Green
        Me.txtVesselCode.TabIndex = 265
        Me.txtVesselCode.UseCustomBackColor = True
        Me.txtVesselCode.UseCustomForeColor = True
        Me.txtVesselCode.UseSelectable = True
        Me.txtVesselCode.UseStyleColors = True
        Me.txtVesselCode.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtVesselCode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtagentCode
        '
        '
        '
        '
        Me.txtagentCode.CustomButton.Image = Nothing
        Me.txtagentCode.CustomButton.Location = New System.Drawing.Point(59, 2)
        Me.txtagentCode.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtagentCode.CustomButton.Name = ""
        Me.txtagentCode.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtagentCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtagentCode.CustomButton.TabIndex = 1
        Me.txtagentCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtagentCode.CustomButton.UseSelectable = True
        Me.txtagentCode.CustomButton.Visible = False
        Me.txtagentCode.Lines = New String(-1) {}
        Me.txtagentCode.Location = New System.Drawing.Point(753, 207)
        Me.txtagentCode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtagentCode.MaxLength = 32767
        Me.txtagentCode.Multiline = True
        Me.txtagentCode.Name = "txtagentCode"
        Me.txtagentCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtagentCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtagentCode.SelectedText = ""
        Me.txtagentCode.SelectionLength = 0
        Me.txtagentCode.SelectionStart = 0
        Me.txtagentCode.Size = New System.Drawing.Size(81, 24)
        Me.txtagentCode.Style = MetroFramework.MetroColorStyle.Green
        Me.txtagentCode.TabIndex = 264
        Me.txtagentCode.UseCustomBackColor = True
        Me.txtagentCode.UseCustomForeColor = True
        Me.txtagentCode.UseSelectable = True
        Me.txtagentCode.UseStyleColors = True
        Me.txtagentCode.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtagentCode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtCustCode
        '
        '
        '
        '
        Me.txtCustCode.CustomButton.Image = Nothing
        Me.txtCustCode.CustomButton.Location = New System.Drawing.Point(59, 2)
        Me.txtCustCode.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCustCode.CustomButton.Name = ""
        Me.txtCustCode.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtCustCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCustCode.CustomButton.TabIndex = 1
        Me.txtCustCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtCustCode.CustomButton.UseSelectable = True
        Me.txtCustCode.CustomButton.Visible = False
        Me.txtCustCode.Lines = New String(-1) {}
        Me.txtCustCode.Location = New System.Drawing.Point(753, 17)
        Me.txtCustCode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCustCode.MaxLength = 32767
        Me.txtCustCode.Multiline = True
        Me.txtCustCode.Name = "txtCustCode"
        Me.txtCustCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCustCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCustCode.SelectedText = ""
        Me.txtCustCode.SelectionLength = 0
        Me.txtCustCode.SelectionStart = 0
        Me.txtCustCode.Size = New System.Drawing.Size(81, 24)
        Me.txtCustCode.Style = MetroFramework.MetroColorStyle.Green
        Me.txtCustCode.TabIndex = 263
        Me.txtCustCode.UseCustomBackColor = True
        Me.txtCustCode.UseCustomForeColor = True
        Me.txtCustCode.UseSelectable = True
        Me.txtCustCode.UseStyleColors = True
        Me.txtCustCode.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtCustCode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtShipperCode
        '
        '
        '
        '
        Me.txtShipperCode.CustomButton.Image = Nothing
        Me.txtShipperCode.CustomButton.Location = New System.Drawing.Point(59, 2)
        Me.txtShipperCode.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtShipperCode.CustomButton.Name = ""
        Me.txtShipperCode.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtShipperCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtShipperCode.CustomButton.TabIndex = 1
        Me.txtShipperCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtShipperCode.CustomButton.UseSelectable = True
        Me.txtShipperCode.CustomButton.Visible = False
        Me.txtShipperCode.Lines = New String(-1) {}
        Me.txtShipperCode.Location = New System.Drawing.Point(337, 17)
        Me.txtShipperCode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtShipperCode.MaxLength = 32767
        Me.txtShipperCode.Multiline = True
        Me.txtShipperCode.Name = "txtShipperCode"
        Me.txtShipperCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtShipperCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtShipperCode.SelectedText = ""
        Me.txtShipperCode.SelectionLength = 0
        Me.txtShipperCode.SelectionStart = 0
        Me.txtShipperCode.Size = New System.Drawing.Size(81, 24)
        Me.txtShipperCode.Style = MetroFramework.MetroColorStyle.Green
        Me.txtShipperCode.TabIndex = 262
        Me.txtShipperCode.UseCustomBackColor = True
        Me.txtShipperCode.UseCustomForeColor = True
        Me.txtShipperCode.UseSelectable = True
        Me.txtShipperCode.UseStyleColors = True
        Me.txtShipperCode.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtShipperCode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtType
        '
        '
        '
        '
        Me.txtType.CustomButton.Image = Nothing
        Me.txtType.CustomButton.Location = New System.Drawing.Point(104, 2)
        Me.txtType.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtType.CustomButton.Name = ""
        Me.txtType.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtType.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtType.CustomButton.TabIndex = 1
        Me.txtType.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtType.CustomButton.UseSelectable = True
        Me.txtType.CustomButton.Visible = False
        Me.txtType.Lines = New String(-1) {}
        Me.txtType.Location = New System.Drawing.Point(0, 0)
        Me.txtType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtType.MaxLength = 32767
        Me.txtType.Multiline = True
        Me.txtType.Name = "txtType"
        Me.txtType.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtType.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtType.SelectedText = ""
        Me.txtType.SelectionLength = 0
        Me.txtType.SelectionStart = 0
        Me.txtType.Size = New System.Drawing.Size(126, 24)
        Me.txtType.Style = MetroFramework.MetroColorStyle.Green
        Me.txtType.TabIndex = 261
        Me.txtType.UseCustomBackColor = True
        Me.txtType.UseCustomForeColor = True
        Me.txtType.UseSelectable = True
        Me.txtType.UseStyleColors = True
        Me.txtType.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtType.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'dtpBookingNoDate
        '
        Me.dtpBookingNoDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBookingNoDate.Location = New System.Drawing.Point(531, 733)
        Me.dtpBookingNoDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpBookingNoDate.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtpBookingNoDate.Name = "dtpBookingNoDate"
        Me.dtpBookingNoDate.Size = New System.Drawing.Size(151, 29)
        Me.dtpBookingNoDate.TabIndex = 260
        '
        'txtIdent
        '
        '
        '
        '
        Me.txtIdent.CustomButton.Image = Nothing
        Me.txtIdent.CustomButton.Location = New System.Drawing.Point(57, 2)
        Me.txtIdent.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIdent.CustomButton.Name = ""
        Me.txtIdent.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtIdent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtIdent.CustomButton.TabIndex = 1
        Me.txtIdent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtIdent.CustomButton.UseSelectable = True
        Me.txtIdent.CustomButton.Visible = False
        Me.txtIdent.Lines = New String() {"0"}
        Me.txtIdent.Location = New System.Drawing.Point(1068, 11)
        Me.txtIdent.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIdent.MaxLength = 32767
        Me.txtIdent.Multiline = True
        Me.txtIdent.Name = "txtIdent"
        Me.txtIdent.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIdent.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtIdent.SelectedText = ""
        Me.txtIdent.SelectionLength = 0
        Me.txtIdent.SelectionStart = 0
        Me.txtIdent.Size = New System.Drawing.Size(79, 24)
        Me.txtIdent.Style = MetroFramework.MetroColorStyle.Green
        Me.txtIdent.TabIndex = 259
        Me.txtIdent.Text = "0"
        Me.txtIdent.UseCustomBackColor = True
        Me.txtIdent.UseCustomForeColor = True
        Me.txtIdent.UseSelectable = True
        Me.txtIdent.UseStyleColors = True
        Me.txtIdent.WaterMark = "Ident"
        Me.txtIdent.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtIdent.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtUserQuotation
        '
        '
        '
        '
        Me.txtUserQuotation.CustomButton.Image = Nothing
        Me.txtUserQuotation.CustomButton.Location = New System.Drawing.Point(147, 2)
        Me.txtUserQuotation.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtUserQuotation.CustomButton.Name = ""
        Me.txtUserQuotation.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtUserQuotation.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtUserQuotation.CustomButton.TabIndex = 1
        Me.txtUserQuotation.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtUserQuotation.CustomButton.UseSelectable = True
        Me.txtUserQuotation.CustomButton.Visible = False
        Me.txtUserQuotation.Lines = New String(-1) {}
        Me.txtUserQuotation.Location = New System.Drawing.Point(104, 738)
        Me.txtUserQuotation.Margin = New System.Windows.Forms.Padding(2)
        Me.txtUserQuotation.MaxLength = 32767
        Me.txtUserQuotation.Multiline = True
        Me.txtUserQuotation.Name = "txtUserQuotation"
        Me.txtUserQuotation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUserQuotation.ReadOnly = True
        Me.txtUserQuotation.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtUserQuotation.SelectedText = ""
        Me.txtUserQuotation.SelectionLength = 0
        Me.txtUserQuotation.SelectionStart = 0
        Me.txtUserQuotation.Size = New System.Drawing.Size(169, 24)
        Me.txtUserQuotation.Style = MetroFramework.MetroColorStyle.Green
        Me.txtUserQuotation.TabIndex = 258
        Me.txtUserQuotation.UseCustomBackColor = True
        Me.txtUserQuotation.UseCustomForeColor = True
        Me.txtUserQuotation.UseSelectable = True
        Me.txtUserQuotation.UseStyleColors = True
        Me.txtUserQuotation.WaterMark = "User Quotation"
        Me.txtUserQuotation.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtUserQuotation.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtUserBooking
        '
        '
        '
        '
        Me.txtUserBooking.CustomButton.Image = Nothing
        Me.txtUserBooking.CustomButton.Location = New System.Drawing.Point(147, 2)
        Me.txtUserBooking.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtUserBooking.CustomButton.Name = ""
        Me.txtUserBooking.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtUserBooking.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtUserBooking.CustomButton.TabIndex = 1
        Me.txtUserBooking.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtUserBooking.CustomButton.UseSelectable = True
        Me.txtUserBooking.CustomButton.Visible = False
        Me.txtUserBooking.Lines = New String(-1) {}
        Me.txtUserBooking.Location = New System.Drawing.Point(358, 738)
        Me.txtUserBooking.Margin = New System.Windows.Forms.Padding(2)
        Me.txtUserBooking.MaxLength = 32767
        Me.txtUserBooking.Multiline = True
        Me.txtUserBooking.Name = "txtUserBooking"
        Me.txtUserBooking.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUserBooking.ReadOnly = True
        Me.txtUserBooking.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtUserBooking.SelectedText = ""
        Me.txtUserBooking.SelectionLength = 0
        Me.txtUserBooking.SelectionStart = 0
        Me.txtUserBooking.Size = New System.Drawing.Size(169, 24)
        Me.txtUserBooking.Style = MetroFramework.MetroColorStyle.Green
        Me.txtUserBooking.TabIndex = 257
        Me.txtUserBooking.UseCustomBackColor = True
        Me.txtUserBooking.UseCustomForeColor = True
        Me.txtUserBooking.UseSelectable = True
        Me.txtUserBooking.UseStyleColors = True
        Me.txtUserBooking.WaterMark = "User Booking"
        Me.txtUserBooking.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtUserBooking.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtQuotationNo
        '
        '
        '
        '
        Me.txtQuotationNo.CustomButton.Image = Nothing
        Me.txtQuotationNo.CustomButton.Location = New System.Drawing.Point(147, 2)
        Me.txtQuotationNo.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtQuotationNo.CustomButton.Name = ""
        Me.txtQuotationNo.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtQuotationNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtQuotationNo.CustomButton.TabIndex = 1
        Me.txtQuotationNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtQuotationNo.CustomButton.UseSelectable = True
        Me.txtQuotationNo.Lines = New String(-1) {}
        Me.txtQuotationNo.Location = New System.Drawing.Point(104, 706)
        Me.txtQuotationNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtQuotationNo.MaxLength = 32767
        Me.txtQuotationNo.Multiline = True
        Me.txtQuotationNo.Name = "txtQuotationNo"
        Me.txtQuotationNo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtQuotationNo.ReadOnly = True
        Me.txtQuotationNo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtQuotationNo.SelectedText = ""
        Me.txtQuotationNo.SelectionLength = 0
        Me.txtQuotationNo.SelectionStart = 0
        Me.txtQuotationNo.ShowButton = True
        Me.txtQuotationNo.ShowClearButton = True
        Me.txtQuotationNo.Size = New System.Drawing.Size(169, 24)
        Me.txtQuotationNo.Style = MetroFramework.MetroColorStyle.Green
        Me.txtQuotationNo.TabIndex = 256
        Me.txtQuotationNo.UseCustomBackColor = True
        Me.txtQuotationNo.UseCustomForeColor = True
        Me.txtQuotationNo.UseSelectable = True
        Me.txtQuotationNo.UseStyleColors = True
        Me.txtQuotationNo.WaterMark = "QuotationNo"
        Me.txtQuotationNo.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtQuotationNo.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(8, 713)
        Me.Label56.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(92, 17)
        Me.Label56.TabIndex = 255
        Me.Label56.Text = "Quotation No"
        '
        'txtBookingNo
        '
        '
        '
        '
        Me.txtBookingNo.CustomButton.Image = Nothing
        Me.txtBookingNo.CustomButton.Location = New System.Drawing.Point(147, 2)
        Me.txtBookingNo.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBookingNo.CustomButton.Name = ""
        Me.txtBookingNo.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtBookingNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtBookingNo.CustomButton.TabIndex = 1
        Me.txtBookingNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtBookingNo.CustomButton.UseSelectable = True
        Me.txtBookingNo.CustomButton.Visible = False
        Me.txtBookingNo.Lines = New String(-1) {}
        Me.txtBookingNo.Location = New System.Drawing.Point(358, 706)
        Me.txtBookingNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBookingNo.MaxLength = 32767
        Me.txtBookingNo.Multiline = True
        Me.txtBookingNo.Name = "txtBookingNo"
        Me.txtBookingNo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBookingNo.ReadOnly = True
        Me.txtBookingNo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtBookingNo.SelectedText = ""
        Me.txtBookingNo.SelectionLength = 0
        Me.txtBookingNo.SelectionStart = 0
        Me.txtBookingNo.Size = New System.Drawing.Size(169, 24)
        Me.txtBookingNo.Style = MetroFramework.MetroColorStyle.Green
        Me.txtBookingNo.TabIndex = 254
        Me.txtBookingNo.UseCustomBackColor = True
        Me.txtBookingNo.UseCustomForeColor = True
        Me.txtBookingNo.UseSelectable = True
        Me.txtBookingNo.UseStyleColors = True
        Me.txtBookingNo.WaterMark = "Booking No"
        Me.txtBookingNo.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtBookingNo.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(277, 713)
        Me.Label55.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(81, 17)
        Me.Label55.TabIndex = 253
        Me.Label55.Text = "Booking No"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(838, 657)
        Me.Label54.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(145, 17)
        Me.Label54.TabIndex = 252
        Me.Label54.Text = "NO OF ORIGINaL B/L"
        '
        'cboNoOfOriginalBL
        '
        Me.cboNoOfOriginalBL.FormattingEnabled = True
        Me.cboNoOfOriginalBL.ItemHeight = 23
        Me.cboNoOfOriginalBL.Items.AddRange(New Object() {"SURRENDER", "SEA WAY BILL", "ORIGINAL"})
        Me.cboNoOfOriginalBL.Location = New System.Drawing.Point(991, 647)
        Me.cboNoOfOriginalBL.Margin = New System.Windows.Forms.Padding(2)
        Me.cboNoOfOriginalBL.Name = "cboNoOfOriginalBL"
        Me.cboNoOfOriginalBL.Size = New System.Drawing.Size(149, 29)
        Me.cboNoOfOriginalBL.Style = MetroFramework.MetroColorStyle.Blue
        Me.cboNoOfOriginalBL.TabIndex = 251
        Me.cboNoOfOriginalBL.UseCustomBackColor = True
        Me.cboNoOfOriginalBL.UseCustomForeColor = True
        Me.cboNoOfOriginalBL.UseSelectable = True
        Me.cboNoOfOriginalBL.UseStyleColors = True
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(991, 389)
        Me.Label53.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(34, 17)
        Me.Label53.TabIndex = 250
        Me.Label53.Text = "ETa"
        '
        'dtpETa
        '
        Me.dtpETa.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETa.Location = New System.Drawing.Point(1039, 382)
        Me.dtpETa.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpETa.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtpETa.Name = "dtpETa"
        Me.dtpETa.Size = New System.Drawing.Size(103, 29)
        Me.dtpETa.TabIndex = 249
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(991, 356)
        Me.Label52.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(36, 17)
        Me.Label52.TabIndex = 248
        Me.Label52.Text = "ETD"
        '
        'dtpETD
        '
        Me.dtpETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETD.Location = New System.Drawing.Point(1039, 349)
        Me.dtpETD.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpETD.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtpETD.Name = "dtpETD"
        Me.dtpETD.Size = New System.Drawing.Size(103, 29)
        Me.dtpETD.TabIndex = 247
        '
        'cboTermOfPayment
        '
        Me.cboTermOfPayment.FormattingEnabled = True
        Me.cboTermOfPayment.ItemHeight = 23
        Me.cboTermOfPayment.Items.AddRange(New Object() {"FREIGHT PREPAID", "FREIGHT COLLECT"})
        Me.cboTermOfPayment.Location = New System.Drawing.Point(991, 680)
        Me.cboTermOfPayment.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTermOfPayment.Name = "cboTermOfPayment"
        Me.cboTermOfPayment.Size = New System.Drawing.Size(149, 29)
        Me.cboTermOfPayment.Style = MetroFramework.MetroColorStyle.Blue
        Me.cboTermOfPayment.TabIndex = 246
        Me.cboTermOfPayment.UseCustomBackColor = True
        Me.cboTermOfPayment.UseCustomForeColor = True
        Me.cboTermOfPayment.UseSelectable = True
        Me.cboTermOfPayment.UseStyleColors = True
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(838, 690)
        Me.Label51.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(116, 17)
        Me.Label51.TabIndex = 245
        Me.Label51.Text = "Term of Payment"
        '
        'cboBookingType
        '
        Me.cboBookingType.FormattingEnabled = True
        Me.cboBookingType.ItemHeight = 23
        Me.cboBookingType.Items.AddRange(New Object() {"CFS/CFS", "CY/CY", "CY/CFS", "CFS/CY"})
        Me.cboBookingType.Location = New System.Drawing.Point(887, 349)
        Me.cboBookingType.Margin = New System.Windows.Forms.Padding(2)
        Me.cboBookingType.Name = "cboBookingType"
        Me.cboBookingType.Size = New System.Drawing.Size(100, 29)
        Me.cboBookingType.Style = MetroFramework.MetroColorStyle.Blue
        Me.cboBookingType.TabIndex = 243
        Me.cboBookingType.UseCustomBackColor = True
        Me.cboBookingType.UseCustomForeColor = True
        Me.cboBookingType.UseSelectable = True
        Me.cboBookingType.UseStyleColors = True
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(838, 356)
        Me.Label50.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(40, 17)
        Me.Label50.TabIndex = 242
        Me.Label50.Text = "Type"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(838, 392)
        Me.Label47.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(141, 17)
        Me.Label47.TabIndex = 240
        Me.Label47.Text = "Description of Goods"
        '
        'txtDescriptionOfGoods
        '
        '
        '
        '
        Me.txtDescriptionOfGoods.CustomButton.Image = Nothing
        Me.txtDescriptionOfGoods.CustomButton.Location = New System.Drawing.Point(76, 2)
        Me.txtDescriptionOfGoods.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDescriptionOfGoods.CustomButton.Name = ""
        Me.txtDescriptionOfGoods.CustomButton.Size = New System.Drawing.Size(223, 223)
        Me.txtDescriptionOfGoods.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtDescriptionOfGoods.CustomButton.TabIndex = 1
        Me.txtDescriptionOfGoods.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtDescriptionOfGoods.CustomButton.UseSelectable = True
        Me.txtDescriptionOfGoods.CustomButton.Visible = False
        Me.txtDescriptionOfGoods.Lines = New String(-1) {}
        Me.txtDescriptionOfGoods.Location = New System.Drawing.Point(838, 415)
        Me.txtDescriptionOfGoods.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDescriptionOfGoods.MaxLength = 32767
        Me.txtDescriptionOfGoods.Multiline = True
        Me.txtDescriptionOfGoods.Name = "txtDescriptionOfGoods"
        Me.txtDescriptionOfGoods.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDescriptionOfGoods.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtDescriptionOfGoods.SelectedText = ""
        Me.txtDescriptionOfGoods.SelectionLength = 0
        Me.txtDescriptionOfGoods.SelectionStart = 0
        Me.txtDescriptionOfGoods.Size = New System.Drawing.Size(302, 228)
        Me.txtDescriptionOfGoods.Style = MetroFramework.MetroColorStyle.Green
        Me.txtDescriptionOfGoods.TabIndex = 239
        Me.txtDescriptionOfGoods.UseCustomBackColor = True
        Me.txtDescriptionOfGoods.UseCustomForeColor = True
        Me.txtDescriptionOfGoods.UseSelectable = True
        Me.txtDescriptionOfGoods.UseStyleColors = True
        Me.txtDescriptionOfGoods.WaterMark = "ชื่อสินค้า"
        Me.txtDescriptionOfGoods.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtDescriptionOfGoods.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(1062, 214)
        Me.Label41.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(36, 17)
        Me.Label41.TabIndex = 238
        Me.Label41.Text = "G.W"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(988, 214)
        Me.Label40.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(37, 17)
        Me.Label40.TabIndex = 237
        Me.Label40.Text = "CBM"
        '
        'txtPackageGW
        '
        '
        '
        '
        Me.txtPackageGW.CustomButton.Image = Nothing
        Me.txtPackageGW.CustomButton.Location = New System.Drawing.Point(53, 2)
        Me.txtPackageGW.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPackageGW.CustomButton.Name = ""
        Me.txtPackageGW.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtPackageGW.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPackageGW.CustomButton.TabIndex = 1
        Me.txtPackageGW.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPackageGW.CustomButton.UseSelectable = True
        Me.txtPackageGW.CustomButton.Visible = False
        Me.txtPackageGW.Lines = New String() {"0"}
        Me.txtPackageGW.Location = New System.Drawing.Point(1065, 237)
        Me.txtPackageGW.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPackageGW.MaxLength = 32767
        Me.txtPackageGW.Multiline = True
        Me.txtPackageGW.Name = "txtPackageGW"
        Me.txtPackageGW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPackageGW.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPackageGW.SelectedText = ""
        Me.txtPackageGW.SelectionLength = 0
        Me.txtPackageGW.SelectionStart = 0
        Me.txtPackageGW.Size = New System.Drawing.Size(75, 24)
        Me.txtPackageGW.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPackageGW.TabIndex = 236
        Me.txtPackageGW.Text = "0"
        Me.txtPackageGW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPackageGW.UseCustomBackColor = True
        Me.txtPackageGW.UseCustomForeColor = True
        Me.txtPackageGW.UseSelectable = True
        Me.txtPackageGW.UseStyleColors = True
        Me.txtPackageGW.WaterMark = "น้ำหนักรวม"
        Me.txtPackageGW.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPackageGW.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtCBM
        '
        '
        '
        '
        Me.txtCBM.CustomButton.Image = Nothing
        Me.txtCBM.CustomButton.Location = New System.Drawing.Point(45, 2)
        Me.txtCBM.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCBM.CustomButton.Name = ""
        Me.txtCBM.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtCBM.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCBM.CustomButton.TabIndex = 1
        Me.txtCBM.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtCBM.CustomButton.UseSelectable = True
        Me.txtCBM.CustomButton.Visible = False
        Me.txtCBM.Lines = New String() {"0"}
        Me.txtCBM.Location = New System.Drawing.Point(991, 237)
        Me.txtCBM.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCBM.MaxLength = 32767
        Me.txtCBM.Multiline = True
        Me.txtCBM.Name = "txtCBM"
        Me.txtCBM.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCBM.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCBM.SelectedText = ""
        Me.txtCBM.SelectionLength = 0
        Me.txtCBM.SelectionStart = 0
        Me.txtCBM.Size = New System.Drawing.Size(67, 24)
        Me.txtCBM.Style = MetroFramework.MetroColorStyle.Green
        Me.txtCBM.TabIndex = 235
        Me.txtCBM.Text = "0"
        Me.txtCBM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCBM.UseCustomBackColor = True
        Me.txtCBM.UseCustomForeColor = True
        Me.txtCBM.UseSelectable = True
        Me.txtCBM.UseStyleColors = True
        Me.txtCBM.WaterMark = "คิว"
        Me.txtCBM.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtCBM.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(1062, 269)
        Me.Label39.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(36, 17)
        Me.Label39.TabIndex = 234
        Me.Label39.Text = "G.W"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(988, 269)
        Me.Label38.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(35, 17)
        Me.Label38.TabIndex = 233
        Me.Label38.Text = "N.W"
        '
        'txtContainerGW2
        '
        '
        '
        '
        Me.txtContainerGW2.CustomButton.Image = Nothing
        Me.txtContainerGW2.CustomButton.Location = New System.Drawing.Point(53, 2)
        Me.txtContainerGW2.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerGW2.CustomButton.Name = ""
        Me.txtContainerGW2.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtContainerGW2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtContainerGW2.CustomButton.TabIndex = 1
        Me.txtContainerGW2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtContainerGW2.CustomButton.UseSelectable = True
        Me.txtContainerGW2.CustomButton.Visible = False
        Me.txtContainerGW2.Lines = New String() {"0"}
        Me.txtContainerGW2.Location = New System.Drawing.Point(1065, 322)
        Me.txtContainerGW2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerGW2.MaxLength = 32767
        Me.txtContainerGW2.Multiline = True
        Me.txtContainerGW2.Name = "txtContainerGW2"
        Me.txtContainerGW2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContainerGW2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtContainerGW2.SelectedText = ""
        Me.txtContainerGW2.SelectionLength = 0
        Me.txtContainerGW2.SelectionStart = 0
        Me.txtContainerGW2.Size = New System.Drawing.Size(75, 24)
        Me.txtContainerGW2.Style = MetroFramework.MetroColorStyle.Green
        Me.txtContainerGW2.TabIndex = 232
        Me.txtContainerGW2.Text = "0"
        Me.txtContainerGW2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtContainerGW2.UseCustomBackColor = True
        Me.txtContainerGW2.UseCustomForeColor = True
        Me.txtContainerGW2.UseSelectable = True
        Me.txtContainerGW2.UseStyleColors = True
        Me.txtContainerGW2.WaterMark = "น้ำหนักรวม"
        Me.txtContainerGW2.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtContainerGW2.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtContainerGW1
        '
        '
        '
        '
        Me.txtContainerGW1.CustomButton.Image = Nothing
        Me.txtContainerGW1.CustomButton.Location = New System.Drawing.Point(53, 2)
        Me.txtContainerGW1.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerGW1.CustomButton.Name = ""
        Me.txtContainerGW1.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtContainerGW1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtContainerGW1.CustomButton.TabIndex = 1
        Me.txtContainerGW1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtContainerGW1.CustomButton.UseSelectable = True
        Me.txtContainerGW1.CustomButton.Visible = False
        Me.txtContainerGW1.Lines = New String() {"0"}
        Me.txtContainerGW1.Location = New System.Drawing.Point(1065, 294)
        Me.txtContainerGW1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerGW1.MaxLength = 32767
        Me.txtContainerGW1.Multiline = True
        Me.txtContainerGW1.Name = "txtContainerGW1"
        Me.txtContainerGW1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContainerGW1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtContainerGW1.SelectedText = ""
        Me.txtContainerGW1.SelectionLength = 0
        Me.txtContainerGW1.SelectionStart = 0
        Me.txtContainerGW1.Size = New System.Drawing.Size(75, 24)
        Me.txtContainerGW1.Style = MetroFramework.MetroColorStyle.Green
        Me.txtContainerGW1.TabIndex = 231
        Me.txtContainerGW1.Text = "0"
        Me.txtContainerGW1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtContainerGW1.UseCustomBackColor = True
        Me.txtContainerGW1.UseCustomForeColor = True
        Me.txtContainerGW1.UseSelectable = True
        Me.txtContainerGW1.UseStyleColors = True
        Me.txtContainerGW1.WaterMark = "น้ำหนักรวม"
        Me.txtContainerGW1.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtContainerGW1.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtContainerNW2
        '
        '
        '
        '
        Me.txtContainerNW2.CustomButton.Image = Nothing
        Me.txtContainerNW2.CustomButton.Location = New System.Drawing.Point(45, 2)
        Me.txtContainerNW2.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerNW2.CustomButton.Name = ""
        Me.txtContainerNW2.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtContainerNW2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtContainerNW2.CustomButton.TabIndex = 1
        Me.txtContainerNW2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtContainerNW2.CustomButton.UseSelectable = True
        Me.txtContainerNW2.CustomButton.Visible = False
        Me.txtContainerNW2.Lines = New String() {"0"}
        Me.txtContainerNW2.Location = New System.Drawing.Point(991, 322)
        Me.txtContainerNW2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerNW2.MaxLength = 32767
        Me.txtContainerNW2.Multiline = True
        Me.txtContainerNW2.Name = "txtContainerNW2"
        Me.txtContainerNW2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContainerNW2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtContainerNW2.SelectedText = ""
        Me.txtContainerNW2.SelectionLength = 0
        Me.txtContainerNW2.SelectionStart = 0
        Me.txtContainerNW2.Size = New System.Drawing.Size(67, 24)
        Me.txtContainerNW2.Style = MetroFramework.MetroColorStyle.Green
        Me.txtContainerNW2.TabIndex = 230
        Me.txtContainerNW2.Text = "0"
        Me.txtContainerNW2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtContainerNW2.UseCustomBackColor = True
        Me.txtContainerNW2.UseCustomForeColor = True
        Me.txtContainerNW2.UseSelectable = True
        Me.txtContainerNW2.UseStyleColors = True
        Me.txtContainerNW2.WaterMark = "น้ำหนักสินค้า"
        Me.txtContainerNW2.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtContainerNW2.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtContainerNW1
        '
        '
        '
        '
        Me.txtContainerNW1.CustomButton.Image = Nothing
        Me.txtContainerNW1.CustomButton.Location = New System.Drawing.Point(45, 2)
        Me.txtContainerNW1.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerNW1.CustomButton.Name = ""
        Me.txtContainerNW1.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtContainerNW1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtContainerNW1.CustomButton.TabIndex = 1
        Me.txtContainerNW1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtContainerNW1.CustomButton.UseSelectable = True
        Me.txtContainerNW1.CustomButton.Visible = False
        Me.txtContainerNW1.Lines = New String() {"0"}
        Me.txtContainerNW1.Location = New System.Drawing.Point(991, 294)
        Me.txtContainerNW1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerNW1.MaxLength = 32767
        Me.txtContainerNW1.Multiline = True
        Me.txtContainerNW1.Name = "txtContainerNW1"
        Me.txtContainerNW1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContainerNW1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtContainerNW1.SelectedText = ""
        Me.txtContainerNW1.SelectionLength = 0
        Me.txtContainerNW1.SelectionStart = 0
        Me.txtContainerNW1.Size = New System.Drawing.Size(67, 24)
        Me.txtContainerNW1.Style = MetroFramework.MetroColorStyle.Green
        Me.txtContainerNW1.TabIndex = 229
        Me.txtContainerNW1.Text = "0"
        Me.txtContainerNW1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtContainerNW1.UseCustomBackColor = True
        Me.txtContainerNW1.UseCustomForeColor = True
        Me.txtContainerNW1.UseSelectable = True
        Me.txtContainerNW1.UseStyleColors = True
        Me.txtContainerNW1.WaterMark = "น้ำหนักสินค้า"
        Me.txtContainerNW1.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtContainerNW1.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtQtyContainer2
        '
        '
        '
        '
        Me.txtQtyContainer2.CustomButton.Image = Nothing
        Me.txtQtyContainer2.CustomButton.Location = New System.Drawing.Point(23, 2)
        Me.txtQtyContainer2.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtQtyContainer2.CustomButton.Name = ""
        Me.txtQtyContainer2.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtQtyContainer2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtQtyContainer2.CustomButton.TabIndex = 1
        Me.txtQtyContainer2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtQtyContainer2.CustomButton.UseSelectable = True
        Me.txtQtyContainer2.CustomButton.Visible = False
        Me.txtQtyContainer2.Lines = New String() {"0"}
        Me.txtQtyContainer2.Location = New System.Drawing.Point(838, 322)
        Me.txtQtyContainer2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtQtyContainer2.MaxLength = 32767
        Me.txtQtyContainer2.Multiline = True
        Me.txtQtyContainer2.Name = "txtQtyContainer2"
        Me.txtQtyContainer2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtQtyContainer2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtQtyContainer2.SelectedText = ""
        Me.txtQtyContainer2.SelectionLength = 0
        Me.txtQtyContainer2.SelectionStart = 0
        Me.txtQtyContainer2.Size = New System.Drawing.Size(45, 24)
        Me.txtQtyContainer2.Style = MetroFramework.MetroColorStyle.Green
        Me.txtQtyContainer2.TabIndex = 228
        Me.txtQtyContainer2.Text = "0"
        Me.txtQtyContainer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQtyContainer2.UseCustomBackColor = True
        Me.txtQtyContainer2.UseCustomForeColor = True
        Me.txtQtyContainer2.UseSelectable = True
        Me.txtQtyContainer2.UseStyleColors = True
        Me.txtQtyContainer2.WaterMark = "จำนวน"
        Me.txtQtyContainer2.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtQtyContainer2.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtContainerType2
        '
        '
        '
        '
        Me.txtContainerType2.CustomButton.Image = Nothing
        Me.txtContainerType2.CustomButton.Location = New System.Drawing.Point(78, 2)
        Me.txtContainerType2.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerType2.CustomButton.Name = ""
        Me.txtContainerType2.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtContainerType2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtContainerType2.CustomButton.TabIndex = 1
        Me.txtContainerType2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtContainerType2.CustomButton.UseSelectable = True
        Me.txtContainerType2.Lines = New String(-1) {}
        Me.txtContainerType2.Location = New System.Drawing.Point(887, 322)
        Me.txtContainerType2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerType2.MaxLength = 32767
        Me.txtContainerType2.Multiline = True
        Me.txtContainerType2.Name = "txtContainerType2"
        Me.txtContainerType2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContainerType2.ReadOnly = True
        Me.txtContainerType2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtContainerType2.SelectedText = ""
        Me.txtContainerType2.SelectionLength = 0
        Me.txtContainerType2.SelectionStart = 0
        Me.txtContainerType2.ShowButton = True
        Me.txtContainerType2.Size = New System.Drawing.Size(100, 24)
        Me.txtContainerType2.Style = MetroFramework.MetroColorStyle.Green
        Me.txtContainerType2.TabIndex = 226
        Me.txtContainerType2.UseCustomBackColor = True
        Me.txtContainerType2.UseCustomForeColor = True
        Me.txtContainerType2.UseSelectable = True
        Me.txtContainerType2.UseStyleColors = True
        Me.txtContainerType2.WaterMark = "ขนาดตู้"
        Me.txtContainerType2.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtContainerType2.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtQtyContainer1
        '
        '
        '
        '
        Me.txtQtyContainer1.CustomButton.Image = Nothing
        Me.txtQtyContainer1.CustomButton.Location = New System.Drawing.Point(23, 2)
        Me.txtQtyContainer1.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtQtyContainer1.CustomButton.Name = ""
        Me.txtQtyContainer1.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtQtyContainer1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtQtyContainer1.CustomButton.TabIndex = 1
        Me.txtQtyContainer1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtQtyContainer1.CustomButton.UseSelectable = True
        Me.txtQtyContainer1.CustomButton.Visible = False
        Me.txtQtyContainer1.Lines = New String() {"0"}
        Me.txtQtyContainer1.Location = New System.Drawing.Point(838, 294)
        Me.txtQtyContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtQtyContainer1.MaxLength = 32767
        Me.txtQtyContainer1.Multiline = True
        Me.txtQtyContainer1.Name = "txtQtyContainer1"
        Me.txtQtyContainer1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtQtyContainer1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtQtyContainer1.SelectedText = ""
        Me.txtQtyContainer1.SelectionLength = 0
        Me.txtQtyContainer1.SelectionStart = 0
        Me.txtQtyContainer1.Size = New System.Drawing.Size(45, 24)
        Me.txtQtyContainer1.Style = MetroFramework.MetroColorStyle.Green
        Me.txtQtyContainer1.TabIndex = 225
        Me.txtQtyContainer1.Text = "0"
        Me.txtQtyContainer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQtyContainer1.UseCustomBackColor = True
        Me.txtQtyContainer1.UseCustomForeColor = True
        Me.txtQtyContainer1.UseSelectable = True
        Me.txtQtyContainer1.UseStyleColors = True
        Me.txtQtyContainer1.WaterMark = "จำนวน"
        Me.txtQtyContainer1.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtQtyContainer1.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(838, 269)
        Me.Label37.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(107, 17)
        Me.Label37.TabIndex = 224
        Me.Label37.Text = "No of Container"
        '
        'txtContainerType1
        '
        '
        '
        '
        Me.txtContainerType1.CustomButton.Image = Nothing
        Me.txtContainerType1.CustomButton.Location = New System.Drawing.Point(78, 2)
        Me.txtContainerType1.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerType1.CustomButton.Name = ""
        Me.txtContainerType1.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtContainerType1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtContainerType1.CustomButton.TabIndex = 1
        Me.txtContainerType1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtContainerType1.CustomButton.UseSelectable = True
        Me.txtContainerType1.Lines = New String(-1) {}
        Me.txtContainerType1.Location = New System.Drawing.Point(887, 294)
        Me.txtContainerType1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainerType1.MaxLength = 32767
        Me.txtContainerType1.Multiline = True
        Me.txtContainerType1.Name = "txtContainerType1"
        Me.txtContainerType1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContainerType1.ReadOnly = True
        Me.txtContainerType1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtContainerType1.SelectedText = ""
        Me.txtContainerType1.SelectionLength = 0
        Me.txtContainerType1.SelectionStart = 0
        Me.txtContainerType1.ShowButton = True
        Me.txtContainerType1.Size = New System.Drawing.Size(100, 24)
        Me.txtContainerType1.Style = MetroFramework.MetroColorStyle.Green
        Me.txtContainerType1.TabIndex = 223
        Me.txtContainerType1.UseCustomBackColor = True
        Me.txtContainerType1.UseCustomForeColor = True
        Me.txtContainerType1.UseSelectable = True
        Me.txtContainerType1.UseStyleColors = True
        Me.txtContainerType1.WaterMark = "ขนาดตู้"
        Me.txtContainerType1.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtContainerType1.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtPackageQty
        '
        '
        '
        '
        Me.txtPackageQty.CustomButton.Image = Nothing
        Me.txtPackageQty.CustomButton.Location = New System.Drawing.Point(23, 2)
        Me.txtPackageQty.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPackageQty.CustomButton.Name = ""
        Me.txtPackageQty.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtPackageQty.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPackageQty.CustomButton.TabIndex = 1
        Me.txtPackageQty.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPackageQty.CustomButton.UseSelectable = True
        Me.txtPackageQty.CustomButton.Visible = False
        Me.txtPackageQty.Lines = New String() {"0"}
        Me.txtPackageQty.Location = New System.Drawing.Point(838, 237)
        Me.txtPackageQty.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPackageQty.MaxLength = 32767
        Me.txtPackageQty.Multiline = True
        Me.txtPackageQty.Name = "txtPackageQty"
        Me.txtPackageQty.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPackageQty.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPackageQty.SelectedText = ""
        Me.txtPackageQty.SelectionLength = 0
        Me.txtPackageQty.SelectionStart = 0
        Me.txtPackageQty.Size = New System.Drawing.Size(45, 24)
        Me.txtPackageQty.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPackageQty.TabIndex = 222
        Me.txtPackageQty.Text = "0"
        Me.txtPackageQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPackageQty.UseCustomBackColor = True
        Me.txtPackageQty.UseCustomForeColor = True
        Me.txtPackageQty.UseSelectable = True
        Me.txtPackageQty.UseStyleColors = True
        Me.txtPackageQty.WaterMark = "จำนวน"
        Me.txtPackageQty.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPackageQty.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(838, 214)
        Me.Label36.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(101, 17)
        Me.Label36.TabIndex = 221
        Me.Label36.Text = "No of Package"
        '
        'txtPackageType
        '
        '
        '
        '
        Me.txtPackageType.CustomButton.Image = Nothing
        Me.txtPackageType.CustomButton.Location = New System.Drawing.Point(78, 2)
        Me.txtPackageType.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPackageType.CustomButton.Name = ""
        Me.txtPackageType.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtPackageType.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPackageType.CustomButton.TabIndex = 1
        Me.txtPackageType.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPackageType.CustomButton.UseSelectable = True
        Me.txtPackageType.Lines = New String(-1) {}
        Me.txtPackageType.Location = New System.Drawing.Point(887, 237)
        Me.txtPackageType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPackageType.MaxLength = 32767
        Me.txtPackageType.Multiline = True
        Me.txtPackageType.Name = "txtPackageType"
        Me.txtPackageType.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPackageType.ReadOnly = True
        Me.txtPackageType.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPackageType.SelectedText = ""
        Me.txtPackageType.SelectionLength = 0
        Me.txtPackageType.SelectionStart = 0
        Me.txtPackageType.ShowButton = True
        Me.txtPackageType.Size = New System.Drawing.Size(100, 24)
        Me.txtPackageType.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPackageType.TabIndex = 220
        Me.txtPackageType.UseCustomBackColor = True
        Me.txtPackageType.UseCustomForeColor = True
        Me.txtPackageType.UseSelectable = True
        Me.txtPackageType.UseStyleColors = True
        Me.txtPackageType.WaterMark = "บรรจุภัณฑ์"
        Me.txtPackageType.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPackageType.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(838, 119)
        Me.Label35.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(149, 17)
        Me.Label35.TabIndex = 219
        Me.Label35.Text = "Container No/ Seal No"
        '
        'txtContainer
        '
        '
        '
        '
        Me.txtContainer.CustomButton.Image = Nothing
        Me.txtContainer.CustomButton.Location = New System.Drawing.Point(240, 1)
        Me.txtContainer.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainer.CustomButton.Name = ""
        Me.txtContainer.CustomButton.Size = New System.Drawing.Size(61, 61)
        Me.txtContainer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtContainer.CustomButton.TabIndex = 1
        Me.txtContainer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtContainer.CustomButton.UseSelectable = True
        Me.txtContainer.CustomButton.Visible = False
        Me.txtContainer.Lines = New String(-1) {}
        Me.txtContainer.Location = New System.Drawing.Point(838, 140)
        Me.txtContainer.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContainer.MaxLength = 32767
        Me.txtContainer.Multiline = True
        Me.txtContainer.Name = "txtContainer"
        Me.txtContainer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContainer.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtContainer.SelectedText = ""
        Me.txtContainer.SelectionLength = 0
        Me.txtContainer.SelectionStart = 0
        Me.txtContainer.Size = New System.Drawing.Size(302, 63)
        Me.txtContainer.Style = MetroFramework.MetroColorStyle.Green
        Me.txtContainer.TabIndex = 218
        Me.txtContainer.UseCustomBackColor = True
        Me.txtContainer.UseCustomForeColor = True
        Me.txtContainer.UseSelectable = True
        Me.txtContainer.UseStyleColors = True
        Me.txtContainer.WaterMark = "เบอร์ตู้"
        Me.txtContainer.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtContainer.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(838, 24)
        Me.Label32.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(128, 17)
        Me.Label32.TabIndex = 217
        Me.Label32.Text = "Mark and Numbers"
        '
        'txtMarkNumber
        '
        '
        '
        '
        Me.txtMarkNumber.CustomButton.Image = Nothing
        Me.txtMarkNumber.CustomButton.Location = New System.Drawing.Point(240, 1)
        Me.txtMarkNumber.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMarkNumber.CustomButton.Name = ""
        Me.txtMarkNumber.CustomButton.Size = New System.Drawing.Size(61, 61)
        Me.txtMarkNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtMarkNumber.CustomButton.TabIndex = 1
        Me.txtMarkNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtMarkNumber.CustomButton.UseSelectable = True
        Me.txtMarkNumber.CustomButton.Visible = False
        Me.txtMarkNumber.Lines = New String(-1) {}
        Me.txtMarkNumber.Location = New System.Drawing.Point(838, 45)
        Me.txtMarkNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMarkNumber.MaxLength = 32767
        Me.txtMarkNumber.Multiline = True
        Me.txtMarkNumber.Name = "txtMarkNumber"
        Me.txtMarkNumber.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMarkNumber.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtMarkNumber.SelectedText = ""
        Me.txtMarkNumber.SelectionLength = 0
        Me.txtMarkNumber.SelectionStart = 0
        Me.txtMarkNumber.Size = New System.Drawing.Size(302, 63)
        Me.txtMarkNumber.Style = MetroFramework.MetroColorStyle.Green
        Me.txtMarkNumber.TabIndex = 216
        Me.txtMarkNumber.UseCustomBackColor = True
        Me.txtMarkNumber.UseCustomForeColor = True
        Me.txtMarkNumber.UseSelectable = True
        Me.txtMarkNumber.UseStyleColors = True
        Me.txtMarkNumber.WaterMark = "สัญญาลักษณ์สินค้า"
        Me.txtMarkNumber.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtMarkNumber.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtCoLoadContact
        '
        '
        '
        '
        Me.txtCoLoadContact.CustomButton.Image = Nothing
        Me.txtCoLoadContact.CustomButton.Location = New System.Drawing.Point(256, 2)
        Me.txtCoLoadContact.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCoLoadContact.CustomButton.Name = ""
        Me.txtCoLoadContact.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtCoLoadContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCoLoadContact.CustomButton.TabIndex = 1
        Me.txtCoLoadContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtCoLoadContact.CustomButton.UseSelectable = True
        Me.txtCoLoadContact.CustomButton.Visible = False
        Me.txtCoLoadContact.Lines = New String(-1) {}
        Me.txtCoLoadContact.Location = New System.Drawing.Point(556, 236)
        Me.txtCoLoadContact.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCoLoadContact.MaxLength = 32767
        Me.txtCoLoadContact.Multiline = True
        Me.txtCoLoadContact.Name = "txtCoLoadContact"
        Me.txtCoLoadContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCoLoadContact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCoLoadContact.SelectedText = ""
        Me.txtCoLoadContact.SelectionLength = 0
        Me.txtCoLoadContact.SelectionStart = 0
        Me.txtCoLoadContact.Size = New System.Drawing.Size(278, 24)
        Me.txtCoLoadContact.Style = MetroFramework.MetroColorStyle.Green
        Me.txtCoLoadContact.TabIndex = 215
        Me.txtCoLoadContact.UseCustomBackColor = True
        Me.txtCoLoadContact.UseCustomForeColor = True
        Me.txtCoLoadContact.UseSelectable = True
        Me.txtCoLoadContact.UseStyleColors = True
        Me.txtCoLoadContact.WaterMark = "ติดต่อลูกค้า"
        Me.txtCoLoadContact.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtCoLoadContact.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(424, 244)
        Me.Label31.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(109, 17)
        Me.Label31.TabIndex = 214
        Me.Label31.Text = "CoLoad Contact"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(424, 217)
        Me.Label30.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(97, 17)
        Me.Label30.TabIndex = 213
        Me.Label30.Text = "agent CoLoad"
        '
        'txtagentCoLoad
        '
        '
        '
        '
        Me.txtagentCoLoad.CustomButton.Image = Nothing
        Me.txtagentCoLoad.CustomButton.Location = New System.Drawing.Point(171, 2)
        Me.txtagentCoLoad.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtagentCoLoad.CustomButton.Name = ""
        Me.txtagentCoLoad.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtagentCoLoad.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtagentCoLoad.CustomButton.TabIndex = 1
        Me.txtagentCoLoad.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtagentCoLoad.CustomButton.UseSelectable = True
        Me.txtagentCoLoad.Lines = New String(-1) {}
        Me.txtagentCoLoad.Location = New System.Drawing.Point(556, 207)
        Me.txtagentCoLoad.Margin = New System.Windows.Forms.Padding(2)
        Me.txtagentCoLoad.MaxLength = 32767
        Me.txtagentCoLoad.Multiline = True
        Me.txtagentCoLoad.Name = "txtagentCoLoad"
        Me.txtagentCoLoad.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtagentCoLoad.ReadOnly = True
        Me.txtagentCoLoad.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtagentCoLoad.SelectedText = ""
        Me.txtagentCoLoad.SelectionLength = 0
        Me.txtagentCoLoad.SelectionStart = 0
        Me.txtagentCoLoad.ShowButton = True
        Me.txtagentCoLoad.Size = New System.Drawing.Size(193, 24)
        Me.txtagentCoLoad.Style = MetroFramework.MetroColorStyle.Green
        Me.txtagentCoLoad.TabIndex = 212
        Me.txtagentCoLoad.UseCustomBackColor = True
        Me.txtagentCoLoad.UseCustomForeColor = True
        Me.txtagentCoLoad.UseSelectable = True
        Me.txtagentCoLoad.UseStyleColors = True
        Me.txtagentCoLoad.WaterMark = "เราไปโคโหลด"
        Me.txtagentCoLoad.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtagentCoLoad.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(424, 150)
        Me.Label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(57, 17)
        Me.Label29.TabIndex = 211
        Me.Label29.Text = "Remark"
        '
        'txtRemark
        '
        '
        '
        '
        Me.txtRemark.CustomButton.Image = Nothing
        Me.txtRemark.CustomButton.Location = New System.Drawing.Point(216, 1)
        Me.txtRemark.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRemark.CustomButton.Name = ""
        Me.txtRemark.CustomButton.Size = New System.Drawing.Size(61, 61)
        Me.txtRemark.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtRemark.CustomButton.TabIndex = 1
        Me.txtRemark.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtRemark.CustomButton.UseSelectable = True
        Me.txtRemark.CustomButton.Visible = False
        Me.txtRemark.Lines = New String(-1) {}
        Me.txtRemark.Location = New System.Drawing.Point(556, 140)
        Me.txtRemark.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRemark.MaxLength = 32767
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtRemark.SelectedText = ""
        Me.txtRemark.SelectionLength = 0
        Me.txtRemark.SelectionStart = 0
        Me.txtRemark.Size = New System.Drawing.Size(278, 63)
        Me.txtRemark.Style = MetroFramework.MetroColorStyle.Green
        Me.txtRemark.TabIndex = 210
        Me.txtRemark.UseCustomBackColor = True
        Me.txtRemark.UseCustomForeColor = True
        Me.txtRemark.UseSelectable = True
        Me.txtRemark.UseStyleColors = True
        Me.txtRemark.WaterMark = "หมายเหตุ"
        Me.txtRemark.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtRemark.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(424, 55)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(123, 17)
        Me.Label25.TabIndex = 209
        Me.Label25.Text = "Customer address"
        '
        'txtCustomeraddress
        '
        '
        '
        '
        Me.txtCustomeraddress.CustomButton.Image = Nothing
        Me.txtCustomeraddress.CustomButton.Location = New System.Drawing.Point(216, 1)
        Me.txtCustomeraddress.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCustomeraddress.CustomButton.Name = ""
        Me.txtCustomeraddress.CustomButton.Size = New System.Drawing.Size(61, 61)
        Me.txtCustomeraddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCustomeraddress.CustomButton.TabIndex = 1
        Me.txtCustomeraddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtCustomeraddress.CustomButton.UseSelectable = True
        Me.txtCustomeraddress.CustomButton.Visible = False
        Me.txtCustomeraddress.Lines = New String(-1) {}
        Me.txtCustomeraddress.Location = New System.Drawing.Point(556, 45)
        Me.txtCustomeraddress.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCustomeraddress.MaxLength = 32767
        Me.txtCustomeraddress.Multiline = True
        Me.txtCustomeraddress.Name = "txtCustomeraddress"
        Me.txtCustomeraddress.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCustomeraddress.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCustomeraddress.SelectedText = ""
        Me.txtCustomeraddress.SelectionLength = 0
        Me.txtCustomeraddress.SelectionStart = 0
        Me.txtCustomeraddress.Size = New System.Drawing.Size(278, 63)
        Me.txtCustomeraddress.Style = MetroFramework.MetroColorStyle.Green
        Me.txtCustomeraddress.TabIndex = 208
        Me.txtCustomeraddress.UseCustomBackColor = True
        Me.txtCustomeraddress.UseCustomForeColor = True
        Me.txtCustomeraddress.UseSelectable = True
        Me.txtCustomeraddress.UseStyleColors = True
        Me.txtCustomeraddress.WaterMark = "ที่อยู่"
        Me.txtCustomeraddress.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtCustomeraddress.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtCustomerContact
        '
        '
        '
        '
        Me.txtCustomerContact.CustomButton.Image = Nothing
        Me.txtCustomerContact.CustomButton.Location = New System.Drawing.Point(256, 2)
        Me.txtCustomerContact.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCustomerContact.CustomButton.Name = ""
        Me.txtCustomerContact.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtCustomerContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCustomerContact.CustomButton.TabIndex = 1
        Me.txtCustomerContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtCustomerContact.CustomButton.UseSelectable = True
        Me.txtCustomerContact.CustomButton.Visible = False
        Me.txtCustomerContact.Lines = New String(-1) {}
        Me.txtCustomerContact.Location = New System.Drawing.Point(556, 112)
        Me.txtCustomerContact.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCustomerContact.MaxLength = 32767
        Me.txtCustomerContact.Multiline = True
        Me.txtCustomerContact.Name = "txtCustomerContact"
        Me.txtCustomerContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCustomerContact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCustomerContact.SelectedText = ""
        Me.txtCustomerContact.SelectionLength = 0
        Me.txtCustomerContact.SelectionStart = 0
        Me.txtCustomerContact.Size = New System.Drawing.Size(278, 24)
        Me.txtCustomerContact.Style = MetroFramework.MetroColorStyle.Green
        Me.txtCustomerContact.TabIndex = 207
        Me.txtCustomerContact.UseCustomBackColor = True
        Me.txtCustomerContact.UseCustomForeColor = True
        Me.txtCustomerContact.UseSelectable = True
        Me.txtCustomerContact.UseStyleColors = True
        Me.txtCustomerContact.WaterMark = "ติดต่อลูกค้า"
        Me.txtCustomerContact.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtCustomerContact.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(424, 120)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(120, 17)
        Me.Label26.TabIndex = 206
        Me.Label26.Text = "Customer Contact"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(424, 27)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(121, 17)
        Me.Label27.TabIndex = 205
        Me.Label27.Text = "Customer CoLoad"
        '
        'txtCustomerCoLoad
        '
        '
        '
        '
        Me.txtCustomerCoLoad.CustomButton.Image = Nothing
        Me.txtCustomerCoLoad.CustomButton.Location = New System.Drawing.Point(171, 2)
        Me.txtCustomerCoLoad.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCustomerCoLoad.CustomButton.Name = ""
        Me.txtCustomerCoLoad.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtCustomerCoLoad.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCustomerCoLoad.CustomButton.TabIndex = 1
        Me.txtCustomerCoLoad.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtCustomerCoLoad.CustomButton.UseSelectable = True
        Me.txtCustomerCoLoad.Lines = New String(-1) {}
        Me.txtCustomerCoLoad.Location = New System.Drawing.Point(556, 17)
        Me.txtCustomerCoLoad.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCustomerCoLoad.MaxLength = 32767
        Me.txtCustomerCoLoad.Multiline = True
        Me.txtCustomerCoLoad.Name = "txtCustomerCoLoad"
        Me.txtCustomerCoLoad.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCustomerCoLoad.ReadOnly = True
        Me.txtCustomerCoLoad.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCustomerCoLoad.SelectedText = ""
        Me.txtCustomerCoLoad.SelectionLength = 0
        Me.txtCustomerCoLoad.SelectionStart = 0
        Me.txtCustomerCoLoad.ShowButton = True
        Me.txtCustomerCoLoad.Size = New System.Drawing.Size(193, 24)
        Me.txtCustomerCoLoad.Style = MetroFramework.MetroColorStyle.Green
        Me.txtCustomerCoLoad.TabIndex = 204
        Me.txtCustomerCoLoad.UseCustomBackColor = True
        Me.txtCustomerCoLoad.UseCustomForeColor = True
        Me.txtCustomerCoLoad.UseSelectable = True
        Me.txtCustomerCoLoad.UseStyleColors = True
        Me.txtCustomerCoLoad.WaterMark = "ลูกค้าโคโหลด"
        Me.txtCustomerCoLoad.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtCustomerCoLoad.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtCloseVGMTime
        '
        Me.txtCloseVGMTime.Location = New System.Drawing.Point(788, 687)
        Me.txtCloseVGMTime.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCloseVGMTime.Mask = "90:00"
        Me.txtCloseVGMTime.Name = "txtCloseVGMTime"
        Me.txtCloseVGMTime.Size = New System.Drawing.Size(46, 20)
        Me.txtCloseVGMTime.TabIndex = 203
        Me.txtCloseVGMTime.ValidatingType = GetType(Date)
        '
        'dtpCloseVGMDate
        '
        Me.dtpCloseVGMDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCloseVGMDate.Location = New System.Drawing.Point(557, 680)
        Me.dtpCloseVGMDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpCloseVGMDate.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtpCloseVGMDate.Name = "dtpCloseVGMDate"
        Me.dtpCloseVGMDate.Size = New System.Drawing.Size(151, 29)
        Me.dtpCloseVGMDate.TabIndex = 201
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(425, 687)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(123, 17)
        Me.Label24.TabIndex = 202
        Me.Label24.Text = "Closing VGM Date"
        '
        'txtCloseSITime
        '
        Me.txtCloseSITime.Location = New System.Drawing.Point(788, 654)
        Me.txtCloseSITime.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCloseSITime.Mask = "90:00"
        Me.txtCloseSITime.Name = "txtCloseSITime"
        Me.txtCloseSITime.Size = New System.Drawing.Size(46, 20)
        Me.txtCloseSITime.TabIndex = 200
        Me.txtCloseSITime.ValidatingType = GetType(Date)
        '
        'dtpCloseSIDate
        '
        Me.dtpCloseSIDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCloseSIDate.Location = New System.Drawing.Point(557, 647)
        Me.dtpCloseSIDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpCloseSIDate.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtpCloseSIDate.Name = "dtpCloseSIDate"
        Me.dtpCloseSIDate.Size = New System.Drawing.Size(151, 29)
        Me.dtpCloseSIDate.TabIndex = 198
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(425, 654)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 17)
        Me.Label10.TabIndex = 199
        Me.Label10.Text = "Closing SI Date"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(8, 621)
        Me.Label46.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(99, 17)
        Me.Label46.TabIndex = 197
        Me.Label46.Text = "agent address"
        '
        'dtpPickDate
        '
        Me.dtpPickDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPickDate.Location = New System.Drawing.Point(557, 351)
        Me.dtpPickDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpPickDate.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtpPickDate.Name = "dtpPickDate"
        Me.dtpPickDate.Size = New System.Drawing.Size(151, 29)
        Me.dtpPickDate.TabIndex = 40
        '
        'txtagentaddress
        '
        '
        '
        '
        Me.txtagentaddress.CustomButton.Image = Nothing
        Me.txtagentaddress.CustomButton.Location = New System.Drawing.Point(216, 1)
        Me.txtagentaddress.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtagentaddress.CustomButton.Name = ""
        Me.txtagentaddress.CustomButton.Size = New System.Drawing.Size(61, 61)
        Me.txtagentaddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtagentaddress.CustomButton.TabIndex = 1
        Me.txtagentaddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtagentaddress.CustomButton.UseSelectable = True
        Me.txtagentaddress.CustomButton.Visible = False
        Me.txtagentaddress.Lines = New String(-1) {}
        Me.txtagentaddress.Location = New System.Drawing.Point(140, 611)
        Me.txtagentaddress.Margin = New System.Windows.Forms.Padding(2)
        Me.txtagentaddress.MaxLength = 32767
        Me.txtagentaddress.Multiline = True
        Me.txtagentaddress.Name = "txtagentaddress"
        Me.txtagentaddress.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtagentaddress.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtagentaddress.SelectedText = ""
        Me.txtagentaddress.SelectionLength = 0
        Me.txtagentaddress.SelectionStart = 0
        Me.txtagentaddress.Size = New System.Drawing.Size(278, 63)
        Me.txtagentaddress.Style = MetroFramework.MetroColorStyle.Green
        Me.txtagentaddress.TabIndex = 196
        Me.txtagentaddress.UseCustomBackColor = True
        Me.txtagentaddress.UseCustomForeColor = True
        Me.txtagentaddress.UseSelectable = True
        Me.txtagentaddress.UseStyleColors = True
        Me.txtagentaddress.WaterMark = "ที่อยู่"
        Me.txtagentaddress.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtagentaddress.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(425, 330)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 17)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Vessel Booking"
        '
        'txtagentContact
        '
        '
        '
        '
        Me.txtagentContact.CustomButton.Image = Nothing
        Me.txtagentContact.CustomButton.Location = New System.Drawing.Point(256, 2)
        Me.txtagentContact.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtagentContact.CustomButton.Name = ""
        Me.txtagentContact.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtagentContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtagentContact.CustomButton.TabIndex = 1
        Me.txtagentContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtagentContact.CustomButton.UseSelectable = True
        Me.txtagentContact.CustomButton.Visible = False
        Me.txtagentContact.Lines = New String(-1) {}
        Me.txtagentContact.Location = New System.Drawing.Point(140, 678)
        Me.txtagentContact.Margin = New System.Windows.Forms.Padding(2)
        Me.txtagentContact.MaxLength = 32767
        Me.txtagentContact.Multiline = True
        Me.txtagentContact.Name = "txtagentContact"
        Me.txtagentContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtagentContact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtagentContact.SelectedText = ""
        Me.txtagentContact.SelectionLength = 0
        Me.txtagentContact.SelectionStart = 0
        Me.txtagentContact.Size = New System.Drawing.Size(278, 24)
        Me.txtagentContact.Style = MetroFramework.MetroColorStyle.Green
        Me.txtagentContact.TabIndex = 193
        Me.txtagentContact.UseCustomBackColor = True
        Me.txtagentContact.UseCustomForeColor = True
        Me.txtagentContact.UseSelectable = True
        Me.txtagentContact.UseStyleColors = True
        Me.txtagentContact.WaterMark = "ติดต่อลูกค้า"
        Me.txtagentContact.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtagentContact.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtVesselContact
        '
        '
        '
        '
        Me.txtVesselContact.CustomButton.Image = Nothing
        Me.txtVesselContact.CustomButton.Location = New System.Drawing.Point(255, 2)
        Me.txtVesselContact.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVesselContact.CustomButton.Name = ""
        Me.txtVesselContact.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtVesselContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtVesselContact.CustomButton.TabIndex = 1
        Me.txtVesselContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtVesselContact.CustomButton.UseSelectable = True
        Me.txtVesselContact.CustomButton.Visible = False
        Me.txtVesselContact.Lines = New String(-1) {}
        Me.txtVesselContact.Location = New System.Drawing.Point(557, 294)
        Me.txtVesselContact.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVesselContact.MaxLength = 32767
        Me.txtVesselContact.Multiline = True
        Me.txtVesselContact.Name = "txtVesselContact"
        Me.txtVesselContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtVesselContact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtVesselContact.SelectedText = ""
        Me.txtVesselContact.SelectionLength = 0
        Me.txtVesselContact.SelectionStart = 0
        Me.txtVesselContact.Size = New System.Drawing.Size(277, 24)
        Me.txtVesselContact.Style = MetroFramework.MetroColorStyle.Green
        Me.txtVesselContact.TabIndex = 21
        Me.txtVesselContact.UseCustomBackColor = True
        Me.txtVesselContact.UseCustomForeColor = True
        Me.txtVesselContact.UseSelectable = True
        Me.txtVesselContact.UseStyleColors = True
        Me.txtVesselContact.WaterMark = "การจองเรือ"
        Me.txtVesselContact.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtVesselContact.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(8, 686)
        Me.Label48.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(96, 17)
        Me.Label48.TabIndex = 192
        Me.Label48.Text = "agent Contact"
        '
        'txtVesselagent
        '
        '
        '
        '
        Me.txtVesselagent.CustomButton.Image = Nothing
        Me.txtVesselagent.CustomButton.Location = New System.Drawing.Point(170, 2)
        Me.txtVesselagent.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVesselagent.CustomButton.Name = ""
        Me.txtVesselagent.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtVesselagent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtVesselagent.CustomButton.TabIndex = 1
        Me.txtVesselagent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtVesselagent.CustomButton.UseSelectable = True
        Me.txtVesselagent.Lines = New String(-1) {}
        Me.txtVesselagent.Location = New System.Drawing.Point(557, 264)
        Me.txtVesselagent.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVesselagent.MaxLength = 32767
        Me.txtVesselagent.Multiline = True
        Me.txtVesselagent.Name = "txtVesselagent"
        Me.txtVesselagent.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtVesselagent.ReadOnly = True
        Me.txtVesselagent.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtVesselagent.SelectedText = ""
        Me.txtVesselagent.SelectionLength = 0
        Me.txtVesselagent.SelectionStart = 0
        Me.txtVesselagent.ShowButton = True
        Me.txtVesselagent.Size = New System.Drawing.Size(192, 24)
        Me.txtVesselagent.Style = MetroFramework.MetroColorStyle.Green
        Me.txtVesselagent.TabIndex = 22
        Me.txtVesselagent.UseCustomBackColor = True
        Me.txtVesselagent.UseCustomForeColor = True
        Me.txtVesselagent.UseSelectable = True
        Me.txtVesselagent.UseStyleColors = True
        Me.txtVesselagent.WaterMark = "ตัวแทนเรือ"
        Me.txtVesselagent.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtVesselagent.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(8, 593)
        Me.Label49.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(95, 17)
        Me.Label49.TabIndex = 191
        Me.Label49.Text = "agent Partner"
        '
        'txtagentPartner
        '
        '
        '
        '
        Me.txtagentPartner.CustomButton.Image = Nothing
        Me.txtagentPartner.CustomButton.Location = New System.Drawing.Point(171, 2)
        Me.txtagentPartner.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtagentPartner.CustomButton.Name = ""
        Me.txtagentPartner.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtagentPartner.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtagentPartner.CustomButton.TabIndex = 1
        Me.txtagentPartner.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtagentPartner.CustomButton.UseSelectable = True
        Me.txtagentPartner.Lines = New String(-1) {}
        Me.txtagentPartner.Location = New System.Drawing.Point(140, 583)
        Me.txtagentPartner.Margin = New System.Windows.Forms.Padding(2)
        Me.txtagentPartner.MaxLength = 32767
        Me.txtagentPartner.Multiline = True
        Me.txtagentPartner.Name = "txtagentPartner"
        Me.txtagentPartner.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtagentPartner.ReadOnly = True
        Me.txtagentPartner.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtagentPartner.SelectedText = ""
        Me.txtagentPartner.SelectionLength = 0
        Me.txtagentPartner.SelectionStart = 0
        Me.txtagentPartner.ShowButton = True
        Me.txtagentPartner.Size = New System.Drawing.Size(193, 24)
        Me.txtagentPartner.Style = MetroFramework.MetroColorStyle.Green
        Me.txtagentPartner.TabIndex = 190
        Me.txtagentPartner.UseCustomBackColor = True
        Me.txtagentPartner.UseCustomForeColor = True
        Me.txtagentPartner.UseSelectable = True
        Me.txtagentPartner.UseStyleColors = True
        Me.txtagentPartner.WaterMark = "เอเย่นต่างประเทศ"
        Me.txtagentPartner.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtagentPartner.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(425, 271)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 17)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Vessel agent"
        '
        'txtOceanVoy
        '
        '
        '
        '
        Me.txtOceanVoy.CustomButton.Image = Nothing
        Me.txtOceanVoy.CustomButton.Location = New System.Drawing.Point(60, 2)
        Me.txtOceanVoy.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtOceanVoy.CustomButton.Name = ""
        Me.txtOceanVoy.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtOceanVoy.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtOceanVoy.CustomButton.TabIndex = 1
        Me.txtOceanVoy.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtOceanVoy.CustomButton.UseSelectable = True
        Me.txtOceanVoy.CustomButton.Visible = False
        Me.txtOceanVoy.Lines = New String(-1) {}
        Me.txtOceanVoy.Location = New System.Drawing.Point(337, 556)
        Me.txtOceanVoy.Margin = New System.Windows.Forms.Padding(2)
        Me.txtOceanVoy.MaxLength = 32767
        Me.txtOceanVoy.Multiline = True
        Me.txtOceanVoy.Name = "txtOceanVoy"
        Me.txtOceanVoy.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtOceanVoy.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtOceanVoy.SelectedText = ""
        Me.txtOceanVoy.SelectionLength = 0
        Me.txtOceanVoy.SelectionStart = 0
        Me.txtOceanVoy.Size = New System.Drawing.Size(82, 24)
        Me.txtOceanVoy.Style = MetroFramework.MetroColorStyle.Green
        Me.txtOceanVoy.TabIndex = 189
        Me.txtOceanVoy.UseCustomBackColor = True
        Me.txtOceanVoy.UseCustomForeColor = True
        Me.txtOceanVoy.UseSelectable = True
        Me.txtOceanVoy.UseStyleColors = True
        Me.txtOceanVoy.WaterMark = "Voyage No"
        Me.txtOceanVoy.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtOceanVoy.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(426, 301)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 17)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Vessel Contact"
        '
        'txtLocalVoy
        '
        '
        '
        '
        Me.txtLocalVoy.CustomButton.Image = Nothing
        Me.txtLocalVoy.CustomButton.Location = New System.Drawing.Point(60, 2)
        Me.txtLocalVoy.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLocalVoy.CustomButton.Name = ""
        Me.txtLocalVoy.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtLocalVoy.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtLocalVoy.CustomButton.TabIndex = 1
        Me.txtLocalVoy.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtLocalVoy.CustomButton.UseSelectable = True
        Me.txtLocalVoy.CustomButton.Visible = False
        Me.txtLocalVoy.Lines = New String(-1) {}
        Me.txtLocalVoy.Location = New System.Drawing.Point(336, 528)
        Me.txtLocalVoy.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLocalVoy.MaxLength = 32767
        Me.txtLocalVoy.Multiline = True
        Me.txtLocalVoy.Name = "txtLocalVoy"
        Me.txtLocalVoy.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLocalVoy.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtLocalVoy.SelectedText = ""
        Me.txtLocalVoy.SelectionLength = 0
        Me.txtLocalVoy.SelectionStart = 0
        Me.txtLocalVoy.Size = New System.Drawing.Size(82, 24)
        Me.txtLocalVoy.Style = MetroFramework.MetroColorStyle.Green
        Me.txtLocalVoy.TabIndex = 188
        Me.txtLocalVoy.UseCustomBackColor = True
        Me.txtLocalVoy.UseCustomForeColor = True
        Me.txtLocalVoy.UseSelectable = True
        Me.txtLocalVoy.UseStyleColors = True
        Me.txtLocalVoy.WaterMark = "Voyage No"
        Me.txtLocalVoy.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtLocalVoy.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtVesselBooking
        '
        '
        '
        '
        Me.txtVesselBooking.CustomButton.Image = Nothing
        Me.txtVesselBooking.CustomButton.Location = New System.Drawing.Point(255, 2)
        Me.txtVesselBooking.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVesselBooking.CustomButton.Name = ""
        Me.txtVesselBooking.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtVesselBooking.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtVesselBooking.CustomButton.TabIndex = 1
        Me.txtVesselBooking.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtVesselBooking.CustomButton.UseSelectable = True
        Me.txtVesselBooking.CustomButton.Visible = False
        Me.txtVesselBooking.Lines = New String(-1) {}
        Me.txtVesselBooking.Location = New System.Drawing.Point(557, 323)
        Me.txtVesselBooking.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVesselBooking.MaxLength = 32767
        Me.txtVesselBooking.Multiline = True
        Me.txtVesselBooking.Name = "txtVesselBooking"
        Me.txtVesselBooking.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtVesselBooking.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtVesselBooking.SelectedText = ""
        Me.txtVesselBooking.SelectionLength = 0
        Me.txtVesselBooking.SelectionStart = 0
        Me.txtVesselBooking.Size = New System.Drawing.Size(277, 24)
        Me.txtVesselBooking.Style = MetroFramework.MetroColorStyle.Green
        Me.txtVesselBooking.TabIndex = 34
        Me.txtVesselBooking.UseCustomBackColor = True
        Me.txtVesselBooking.UseCustomForeColor = True
        Me.txtVesselBooking.UseSelectable = True
        Me.txtVesselBooking.UseStyleColors = True
        Me.txtVesselBooking.WaterMark = "เลขบุ๊คกิ้งเรือ"
        Me.txtVesselBooking.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtVesselBooking.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(425, 391)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 17)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Pickup Location"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(8, 563)
        Me.Label44.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(96, 17)
        Me.Label44.TabIndex = 187
        Me.Label44.Text = "Ocean Vessel"
        '
        'txtPickLocation
        '
        '
        '
        '
        Me.txtPickLocation.CustomButton.Image = Nothing
        Me.txtPickLocation.CustomButton.Location = New System.Drawing.Point(255, 2)
        Me.txtPickLocation.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPickLocation.CustomButton.Name = ""
        Me.txtPickLocation.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtPickLocation.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPickLocation.CustomButton.TabIndex = 1
        Me.txtPickLocation.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPickLocation.CustomButton.UseSelectable = True
        Me.txtPickLocation.CustomButton.Visible = False
        Me.txtPickLocation.Lines = New String(-1) {}
        Me.txtPickLocation.Location = New System.Drawing.Point(557, 380)
        Me.txtPickLocation.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPickLocation.MaxLength = 32767
        Me.txtPickLocation.Multiline = True
        Me.txtPickLocation.Name = "txtPickLocation"
        Me.txtPickLocation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPickLocation.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPickLocation.SelectedText = ""
        Me.txtPickLocation.SelectionLength = 0
        Me.txtPickLocation.SelectionStart = 0
        Me.txtPickLocation.Size = New System.Drawing.Size(277, 24)
        Me.txtPickLocation.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPickLocation.TabIndex = 37
        Me.txtPickLocation.UseCustomBackColor = True
        Me.txtPickLocation.UseCustomForeColor = True
        Me.txtPickLocation.UseSelectable = True
        Me.txtPickLocation.UseStyleColors = True
        Me.txtPickLocation.WaterMark = "ที่รับตู้"
        Me.txtPickLocation.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPickLocation.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtOceanVessel
        '
        '
        '
        '
        Me.txtOceanVessel.CustomButton.Image = Nothing
        Me.txtOceanVessel.CustomButton.Location = New System.Drawing.Point(170, 2)
        Me.txtOceanVessel.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtOceanVessel.CustomButton.Name = ""
        Me.txtOceanVessel.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtOceanVessel.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtOceanVessel.CustomButton.TabIndex = 1
        Me.txtOceanVessel.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtOceanVessel.CustomButton.UseSelectable = True
        Me.txtOceanVessel.Lines = New String(-1) {}
        Me.txtOceanVessel.Location = New System.Drawing.Point(140, 555)
        Me.txtOceanVessel.Margin = New System.Windows.Forms.Padding(2)
        Me.txtOceanVessel.MaxLength = 32767
        Me.txtOceanVessel.Multiline = True
        Me.txtOceanVessel.Name = "txtOceanVessel"
        Me.txtOceanVessel.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtOceanVessel.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtOceanVessel.SelectedText = ""
        Me.txtOceanVessel.SelectionLength = 0
        Me.txtOceanVessel.SelectionStart = 0
        Me.txtOceanVessel.ShowButton = True
        Me.txtOceanVessel.Size = New System.Drawing.Size(192, 24)
        Me.txtOceanVessel.Style = MetroFramework.MetroColorStyle.Green
        Me.txtOceanVessel.TabIndex = 186
        Me.txtOceanVessel.UseCustomBackColor = True
        Me.txtOceanVessel.UseCustomForeColor = True
        Me.txtOceanVessel.UseSelectable = True
        Me.txtOceanVessel.UseStyleColors = True
        Me.txtOceanVessel.WaterMark = "Ocean Vessel"
        Me.txtOceanVessel.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtOceanVessel.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(425, 361)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 17)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "Pickup Date"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(8, 535)
        Me.Label45.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(88, 17)
        Me.Label45.TabIndex = 185
        Me.Label45.Text = "Local Vessel"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(425, 478)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 17)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Loading Location"
        '
        'txtLocalVessel
        '
        '
        '
        '
        Me.txtLocalVessel.CustomButton.Image = Nothing
        Me.txtLocalVessel.CustomButton.Location = New System.Drawing.Point(170, 2)
        Me.txtLocalVessel.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLocalVessel.CustomButton.Name = ""
        Me.txtLocalVessel.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtLocalVessel.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtLocalVessel.CustomButton.TabIndex = 1
        Me.txtLocalVessel.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtLocalVessel.CustomButton.UseSelectable = True
        Me.txtLocalVessel.Lines = New String(-1) {}
        Me.txtLocalVessel.Location = New System.Drawing.Point(140, 527)
        Me.txtLocalVessel.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLocalVessel.MaxLength = 32767
        Me.txtLocalVessel.Multiline = True
        Me.txtLocalVessel.Name = "txtLocalVessel"
        Me.txtLocalVessel.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLocalVessel.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtLocalVessel.SelectedText = ""
        Me.txtLocalVessel.SelectionLength = 0
        Me.txtLocalVessel.SelectionStart = 0
        Me.txtLocalVessel.ShowButton = True
        Me.txtLocalVessel.Size = New System.Drawing.Size(192, 24)
        Me.txtLocalVessel.Style = MetroFramework.MetroColorStyle.Green
        Me.txtLocalVessel.TabIndex = 184
        Me.txtLocalVessel.UseCustomBackColor = True
        Me.txtLocalVessel.UseCustomForeColor = True
        Me.txtLocalVessel.UseSelectable = True
        Me.txtLocalVessel.UseStyleColors = True
        Me.txtLocalVessel.WaterMark = "Local Vessel"
        Me.txtLocalVessel.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtLocalVessel.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtCloseRNTime
        '
        Me.txtCloseRNTime.Location = New System.Drawing.Point(788, 621)
        Me.txtCloseRNTime.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCloseRNTime.Mask = "90:00"
        Me.txtCloseRNTime.Name = "txtCloseRNTime"
        Me.txtCloseRNTime.Size = New System.Drawing.Size(46, 20)
        Me.txtCloseRNTime.TabIndex = 134
        Me.txtCloseRNTime.ValidatingType = GetType(Date)
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(8, 507)
        Me.Label43.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(114, 17)
        Me.Label43.TabIndex = 183
        Me.Label43.Text = "Place of Delivery"
        '
        'txtLoadLocation
        '
        '
        '
        '
        Me.txtLoadLocation.CustomButton.Image = Nothing
        Me.txtLoadLocation.CustomButton.Location = New System.Drawing.Point(255, 2)
        Me.txtLoadLocation.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLoadLocation.CustomButton.Name = ""
        Me.txtLoadLocation.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtLoadLocation.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtLoadLocation.CustomButton.TabIndex = 1
        Me.txtLoadLocation.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtLoadLocation.CustomButton.UseSelectable = True
        Me.txtLoadLocation.CustomButton.Visible = False
        Me.txtLoadLocation.Lines = New String(-1) {}
        Me.txtLoadLocation.Location = New System.Drawing.Point(557, 468)
        Me.txtLoadLocation.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLoadLocation.MaxLength = 32767
        Me.txtLoadLocation.Multiline = True
        Me.txtLoadLocation.Name = "txtLoadLocation"
        Me.txtLoadLocation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLoadLocation.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtLoadLocation.SelectedText = ""
        Me.txtLoadLocation.SelectionLength = 0
        Me.txtLoadLocation.SelectionStart = 0
        Me.txtLoadLocation.Size = New System.Drawing.Size(277, 24)
        Me.txtLoadLocation.Style = MetroFramework.MetroColorStyle.Green
        Me.txtLoadLocation.TabIndex = 43
        Me.txtLoadLocation.UseCustomBackColor = True
        Me.txtLoadLocation.UseCustomForeColor = True
        Me.txtLoadLocation.UseSelectable = True
        Me.txtLoadLocation.UseStyleColors = True
        Me.txtLoadLocation.WaterMark = "สถานที่โหลด หรือโรงงาน"
        Me.txtLoadLocation.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtLoadLocation.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtPlaceofDelivery
        '
        '
        '
        '
        Me.txtPlaceofDelivery.CustomButton.Image = Nothing
        Me.txtPlaceofDelivery.CustomButton.Location = New System.Drawing.Point(256, 2)
        Me.txtPlaceofDelivery.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPlaceofDelivery.CustomButton.Name = ""
        Me.txtPlaceofDelivery.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtPlaceofDelivery.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPlaceofDelivery.CustomButton.TabIndex = 1
        Me.txtPlaceofDelivery.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPlaceofDelivery.CustomButton.UseSelectable = True
        Me.txtPlaceofDelivery.Lines = New String(-1) {}
        Me.txtPlaceofDelivery.Location = New System.Drawing.Point(140, 499)
        Me.txtPlaceofDelivery.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPlaceofDelivery.MaxLength = 32767
        Me.txtPlaceofDelivery.Multiline = True
        Me.txtPlaceofDelivery.Name = "txtPlaceofDelivery"
        Me.txtPlaceofDelivery.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPlaceofDelivery.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPlaceofDelivery.SelectedText = ""
        Me.txtPlaceofDelivery.SelectionLength = 0
        Me.txtPlaceofDelivery.SelectionStart = 0
        Me.txtPlaceofDelivery.ShowButton = True
        Me.txtPlaceofDelivery.Size = New System.Drawing.Size(278, 24)
        Me.txtPlaceofDelivery.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPlaceofDelivery.TabIndex = 182
        Me.txtPlaceofDelivery.UseCustomBackColor = True
        Me.txtPlaceofDelivery.UseCustomForeColor = True
        Me.txtPlaceofDelivery.UseSelectable = True
        Me.txtPlaceofDelivery.UseStyleColors = True
        Me.txtPlaceofDelivery.WaterMark = "สถานที่ส่งสินค้า"
        Me.txtPlaceofDelivery.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPlaceofDelivery.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtReturnTime
        '
        Me.txtReturnTime.Location = New System.Drawing.Point(788, 532)
        Me.txtReturnTime.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReturnTime.Mask = "90:00"
        Me.txtReturnTime.Name = "txtReturnTime"
        Me.txtReturnTime.Size = New System.Drawing.Size(46, 20)
        Me.txtReturnTime.TabIndex = 133
        Me.txtReturnTime.ValidatingType = GetType(Date)
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(8, 479)
        Me.Label34.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(118, 17)
        Me.Label34.TabIndex = 181
        Me.Label34.Text = "Port of Discharge"
        '
        'txtPickContact
        '
        '
        '
        '
        Me.txtPickContact.CustomButton.Image = Nothing
        Me.txtPickContact.CustomButton.Location = New System.Drawing.Point(255, 2)
        Me.txtPickContact.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPickContact.CustomButton.Name = ""
        Me.txtPickContact.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtPickContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPickContact.CustomButton.TabIndex = 1
        Me.txtPickContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPickContact.CustomButton.UseSelectable = True
        Me.txtPickContact.CustomButton.Visible = False
        Me.txtPickContact.Lines = New String(-1) {}
        Me.txtPickContact.Location = New System.Drawing.Point(557, 410)
        Me.txtPickContact.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPickContact.MaxLength = 32767
        Me.txtPickContact.Multiline = True
        Me.txtPickContact.Name = "txtPickContact"
        Me.txtPickContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPickContact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPickContact.SelectedText = ""
        Me.txtPickContact.SelectionLength = 0
        Me.txtPickContact.SelectionStart = 0
        Me.txtPickContact.Size = New System.Drawing.Size(277, 24)
        Me.txtPickContact.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPickContact.TabIndex = 44
        Me.txtPickContact.UseCustomBackColor = True
        Me.txtPickContact.UseCustomForeColor = True
        Me.txtPickContact.UseSelectable = True
        Me.txtPickContact.UseStyleColors = True
        Me.txtPickContact.WaterMark = "ติดต่อที่รับ"
        Me.txtPickContact.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPickContact.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtPortofDischarge
        '
        '
        '
        '
        Me.txtPortofDischarge.CustomButton.Image = Nothing
        Me.txtPortofDischarge.CustomButton.Location = New System.Drawing.Point(256, 2)
        Me.txtPortofDischarge.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPortofDischarge.CustomButton.Name = ""
        Me.txtPortofDischarge.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtPortofDischarge.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPortofDischarge.CustomButton.TabIndex = 1
        Me.txtPortofDischarge.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPortofDischarge.CustomButton.UseSelectable = True
        Me.txtPortofDischarge.Lines = New String(-1) {}
        Me.txtPortofDischarge.Location = New System.Drawing.Point(140, 471)
        Me.txtPortofDischarge.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPortofDischarge.MaxLength = 32767
        Me.txtPortofDischarge.Multiline = True
        Me.txtPortofDischarge.Name = "txtPortofDischarge"
        Me.txtPortofDischarge.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPortofDischarge.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPortofDischarge.SelectedText = ""
        Me.txtPortofDischarge.SelectionLength = 0
        Me.txtPortofDischarge.SelectionStart = 0
        Me.txtPortofDischarge.ShowButton = True
        Me.txtPortofDischarge.Size = New System.Drawing.Size(278, 24)
        Me.txtPortofDischarge.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPortofDischarge.TabIndex = 180
        Me.txtPortofDischarge.UseCustomBackColor = True
        Me.txtPortofDischarge.UseCustomForeColor = True
        Me.txtPortofDischarge.UseSelectable = True
        Me.txtPortofDischarge.UseStyleColors = True
        Me.txtPortofDischarge.WaterMark = "สถานที่เรือเทียบท่า"
        Me.txtPortofDischarge.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPortofDischarge.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtLoadTime
        '
        Me.txtLoadTime.Location = New System.Drawing.Point(788, 444)
        Me.txtLoadTime.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLoadTime.Mask = "90:00"
        Me.txtLoadTime.Name = "txtLoadTime"
        Me.txtLoadTime.Size = New System.Drawing.Size(46, 20)
        Me.txtLoadTime.TabIndex = 132
        Me.txtLoadTime.ValidatingType = GetType(Date)
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(8, 451)
        Me.Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(105, 17)
        Me.Label33.TabIndex = 179
        Me.Label33.Text = "Port of Loading"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(425, 420)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(102, 17)
        Me.Label17.TabIndex = 45
        Me.Label17.Text = "Pickup Contact"
        '
        'txtPortofLoading
        '
        '
        '
        '
        Me.txtPortofLoading.CustomButton.Image = Nothing
        Me.txtPortofLoading.CustomButton.Location = New System.Drawing.Point(256, 2)
        Me.txtPortofLoading.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPortofLoading.CustomButton.Name = ""
        Me.txtPortofLoading.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtPortofLoading.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPortofLoading.CustomButton.TabIndex = 1
        Me.txtPortofLoading.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPortofLoading.CustomButton.UseSelectable = True
        Me.txtPortofLoading.Lines = New String(-1) {}
        Me.txtPortofLoading.Location = New System.Drawing.Point(140, 443)
        Me.txtPortofLoading.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPortofLoading.MaxLength = 32767
        Me.txtPortofLoading.Multiline = True
        Me.txtPortofLoading.Name = "txtPortofLoading"
        Me.txtPortofLoading.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPortofLoading.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPortofLoading.SelectedText = ""
        Me.txtPortofLoading.SelectionLength = 0
        Me.txtPortofLoading.SelectionStart = 0
        Me.txtPortofLoading.ShowButton = True
        Me.txtPortofLoading.Size = New System.Drawing.Size(278, 24)
        Me.txtPortofLoading.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPortofLoading.TabIndex = 178
        Me.txtPortofLoading.UseCustomBackColor = True
        Me.txtPortofLoading.UseCustomForeColor = True
        Me.txtPortofLoading.UseSelectable = True
        Me.txtPortofLoading.UseStyleColors = True
        Me.txtPortofLoading.WaterMark = "สถานที่เรือออก"
        Me.txtPortofLoading.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPortofLoading.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtPickTime
        '
        Me.txtPickTime.Location = New System.Drawing.Point(788, 356)
        Me.txtPickTime.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPickTime.Mask = "90:00"
        Me.txtPickTime.Name = "txtPickTime"
        Me.txtPickTime.Size = New System.Drawing.Size(46, 20)
        Me.txtPickTime.TabIndex = 131
        Me.txtPickTime.ValidatingType = GetType(Date)
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(8, 423)
        Me.Label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(114, 17)
        Me.Label28.TabIndex = 177
        Me.Label28.Text = "Place of Receive"
        '
        'txtLoadContact
        '
        '
        '
        '
        Me.txtLoadContact.CustomButton.Image = Nothing
        Me.txtLoadContact.CustomButton.Location = New System.Drawing.Point(255, 2)
        Me.txtLoadContact.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLoadContact.CustomButton.Name = ""
        Me.txtLoadContact.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtLoadContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtLoadContact.CustomButton.TabIndex = 1
        Me.txtLoadContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtLoadContact.CustomButton.UseSelectable = True
        Me.txtLoadContact.CustomButton.Visible = False
        Me.txtLoadContact.Lines = New String(-1) {}
        Me.txtLoadContact.Location = New System.Drawing.Point(557, 497)
        Me.txtLoadContact.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLoadContact.MaxLength = 32767
        Me.txtLoadContact.Multiline = True
        Me.txtLoadContact.Name = "txtLoadContact"
        Me.txtLoadContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLoadContact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtLoadContact.SelectedText = ""
        Me.txtLoadContact.SelectionLength = 0
        Me.txtLoadContact.SelectionStart = 0
        Me.txtLoadContact.Size = New System.Drawing.Size(277, 24)
        Me.txtLoadContact.Style = MetroFramework.MetroColorStyle.Green
        Me.txtLoadContact.TabIndex = 46
        Me.txtLoadContact.UseCustomBackColor = True
        Me.txtLoadContact.UseCustomForeColor = True
        Me.txtLoadContact.UseSelectable = True
        Me.txtLoadContact.UseStyleColors = True
        Me.txtLoadContact.WaterMark = "ติดต่อที่โหลด"
        Me.txtLoadContact.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtLoadContact.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtPlaceofReceive
        '
        '
        '
        '
        Me.txtPlaceofReceive.CustomButton.Image = Nothing
        Me.txtPlaceofReceive.CustomButton.Location = New System.Drawing.Point(256, 2)
        Me.txtPlaceofReceive.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPlaceofReceive.CustomButton.Name = ""
        Me.txtPlaceofReceive.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtPlaceofReceive.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPlaceofReceive.CustomButton.TabIndex = 1
        Me.txtPlaceofReceive.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPlaceofReceive.CustomButton.UseSelectable = True
        Me.txtPlaceofReceive.Lines = New String(-1) {}
        Me.txtPlaceofReceive.Location = New System.Drawing.Point(140, 415)
        Me.txtPlaceofReceive.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPlaceofReceive.MaxLength = 32767
        Me.txtPlaceofReceive.Multiline = True
        Me.txtPlaceofReceive.Name = "txtPlaceofReceive"
        Me.txtPlaceofReceive.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPlaceofReceive.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPlaceofReceive.SelectedText = ""
        Me.txtPlaceofReceive.SelectionLength = 0
        Me.txtPlaceofReceive.SelectionStart = 0
        Me.txtPlaceofReceive.ShowButton = True
        Me.txtPlaceofReceive.Size = New System.Drawing.Size(278, 24)
        Me.txtPlaceofReceive.Style = MetroFramework.MetroColorStyle.Green
        Me.txtPlaceofReceive.TabIndex = 176
        Me.txtPlaceofReceive.UseCustomBackColor = True
        Me.txtPlaceofReceive.UseCustomForeColor = True
        Me.txtPlaceofReceive.UseSelectable = True
        Me.txtPlaceofReceive.UseStyleColors = True
        Me.txtPlaceofReceive.WaterMark = "สถานที่รับสินค้า"
        Me.txtPlaceofReceive.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPlaceofReceive.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 358)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 17)
        Me.Label11.TabIndex = 175
        Me.Label11.Text = "Notify address"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(425, 506)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(111, 17)
        Me.Label18.TabIndex = 47
        Me.Label18.Text = "Loading Contact"
        '
        'txtNotifyaddress
        '
        '
        '
        '
        Me.txtNotifyaddress.CustomButton.Image = Nothing
        Me.txtNotifyaddress.CustomButton.Location = New System.Drawing.Point(216, 1)
        Me.txtNotifyaddress.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNotifyaddress.CustomButton.Name = ""
        Me.txtNotifyaddress.CustomButton.Size = New System.Drawing.Size(61, 61)
        Me.txtNotifyaddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtNotifyaddress.CustomButton.TabIndex = 1
        Me.txtNotifyaddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtNotifyaddress.CustomButton.UseSelectable = True
        Me.txtNotifyaddress.CustomButton.Visible = False
        Me.txtNotifyaddress.Lines = New String(-1) {}
        Me.txtNotifyaddress.Location = New System.Drawing.Point(140, 348)
        Me.txtNotifyaddress.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNotifyaddress.MaxLength = 32767
        Me.txtNotifyaddress.Multiline = True
        Me.txtNotifyaddress.Name = "txtNotifyaddress"
        Me.txtNotifyaddress.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNotifyaddress.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtNotifyaddress.SelectedText = ""
        Me.txtNotifyaddress.SelectionLength = 0
        Me.txtNotifyaddress.SelectionStart = 0
        Me.txtNotifyaddress.Size = New System.Drawing.Size(278, 63)
        Me.txtNotifyaddress.Style = MetroFramework.MetroColorStyle.Green
        Me.txtNotifyaddress.TabIndex = 174
        Me.txtNotifyaddress.UseCustomBackColor = True
        Me.txtNotifyaddress.UseCustomForeColor = True
        Me.txtNotifyaddress.UseSelectable = True
        Me.txtNotifyaddress.UseStyleColors = True
        Me.txtNotifyaddress.WaterMark = "ที่อยู่"
        Me.txtNotifyaddress.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtNotifyaddress.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(425, 566)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(109, 17)
        Me.Label19.TabIndex = 48
        Me.Label19.Text = "Return Location"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(9, 328)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(81, 17)
        Me.Label23.TabIndex = 173
        Me.Label23.Text = "Notify Party"
        '
        'txtReturnLocation
        '
        '
        '
        '
        Me.txtReturnLocation.CustomButton.Image = Nothing
        Me.txtReturnLocation.CustomButton.Location = New System.Drawing.Point(255, 2)
        Me.txtReturnLocation.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReturnLocation.CustomButton.Name = ""
        Me.txtReturnLocation.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtReturnLocation.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtReturnLocation.CustomButton.TabIndex = 1
        Me.txtReturnLocation.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtReturnLocation.CustomButton.UseSelectable = True
        Me.txtReturnLocation.CustomButton.Visible = False
        Me.txtReturnLocation.Lines = New String(-1) {}
        Me.txtReturnLocation.Location = New System.Drawing.Point(557, 556)
        Me.txtReturnLocation.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReturnLocation.MaxLength = 32767
        Me.txtReturnLocation.Multiline = True
        Me.txtReturnLocation.Name = "txtReturnLocation"
        Me.txtReturnLocation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtReturnLocation.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtReturnLocation.SelectedText = ""
        Me.txtReturnLocation.SelectionLength = 0
        Me.txtReturnLocation.SelectionStart = 0
        Me.txtReturnLocation.Size = New System.Drawing.Size(277, 24)
        Me.txtReturnLocation.Style = MetroFramework.MetroColorStyle.Green
        Me.txtReturnLocation.TabIndex = 49
        Me.txtReturnLocation.UseCustomBackColor = True
        Me.txtReturnLocation.UseCustomForeColor = True
        Me.txtReturnLocation.UseSelectable = True
        Me.txtReturnLocation.UseStyleColors = True
        Me.txtReturnLocation.WaterMark = "สถานที่คืนตู้"
        Me.txtReturnLocation.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtReturnLocation.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtNotifyParty
        '
        '
        '
        '
        Me.txtNotifyParty.CustomButton.Image = Nothing
        Me.txtNotifyParty.CustomButton.Location = New System.Drawing.Point(170, 2)
        Me.txtNotifyParty.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNotifyParty.CustomButton.Name = ""
        Me.txtNotifyParty.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtNotifyParty.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtNotifyParty.CustomButton.TabIndex = 1
        Me.txtNotifyParty.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtNotifyParty.CustomButton.UseSelectable = True
        Me.txtNotifyParty.Lines = New String(-1) {}
        Me.txtNotifyParty.Location = New System.Drawing.Point(141, 320)
        Me.txtNotifyParty.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNotifyParty.MaxLength = 32767
        Me.txtNotifyParty.Multiline = True
        Me.txtNotifyParty.Name = "txtNotifyParty"
        Me.txtNotifyParty.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNotifyParty.ReadOnly = True
        Me.txtNotifyParty.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtNotifyParty.SelectedText = ""
        Me.txtNotifyParty.SelectionLength = 0
        Me.txtNotifyParty.SelectionStart = 0
        Me.txtNotifyParty.ShowButton = True
        Me.txtNotifyParty.Size = New System.Drawing.Size(192, 24)
        Me.txtNotifyParty.Style = MetroFramework.MetroColorStyle.Green
        Me.txtNotifyParty.TabIndex = 172
        Me.txtNotifyParty.UseCustomBackColor = True
        Me.txtNotifyParty.UseCustomForeColor = True
        Me.txtNotifyParty.UseSelectable = True
        Me.txtNotifyParty.UseStyleColors = True
        Me.txtNotifyParty.WaterMark = "ผู้ซื้อสินค้า"
        Me.txtNotifyParty.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtNotifyParty.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtReturnContact
        '
        '
        '
        '
        Me.txtReturnContact.CustomButton.Image = Nothing
        Me.txtReturnContact.CustomButton.Location = New System.Drawing.Point(255, 2)
        Me.txtReturnContact.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReturnContact.CustomButton.Name = ""
        Me.txtReturnContact.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtReturnContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtReturnContact.CustomButton.TabIndex = 1
        Me.txtReturnContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtReturnContact.CustomButton.UseSelectable = True
        Me.txtReturnContact.CustomButton.Visible = False
        Me.txtReturnContact.Lines = New String(-1) {}
        Me.txtReturnContact.Location = New System.Drawing.Point(557, 585)
        Me.txtReturnContact.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReturnContact.MaxLength = 32767
        Me.txtReturnContact.Multiline = True
        Me.txtReturnContact.Name = "txtReturnContact"
        Me.txtReturnContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtReturnContact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtReturnContact.SelectedText = ""
        Me.txtReturnContact.SelectionLength = 0
        Me.txtReturnContact.SelectionStart = 0
        Me.txtReturnContact.Size = New System.Drawing.Size(277, 24)
        Me.txtReturnContact.Style = MetroFramework.MetroColorStyle.Green
        Me.txtReturnContact.TabIndex = 50
        Me.txtReturnContact.UseCustomBackColor = True
        Me.txtReturnContact.UseCustomForeColor = True
        Me.txtReturnContact.UseSelectable = True
        Me.txtReturnContact.UseStyleColors = True
        Me.txtReturnContact.WaterMark = "ติดต่อคืนตู้"
        Me.txtReturnContact.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtReturnContact.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 207)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 17)
        Me.Label3.TabIndex = 171
        Me.Label3.Text = "Consignee address"
        '
        'txtConsigneeaddress
        '
        '
        '
        '
        Me.txtConsigneeaddress.CustomButton.Image = Nothing
        Me.txtConsigneeaddress.CustomButton.Location = New System.Drawing.Point(215, 1)
        Me.txtConsigneeaddress.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConsigneeaddress.CustomButton.Name = ""
        Me.txtConsigneeaddress.CustomButton.Size = New System.Drawing.Size(61, 61)
        Me.txtConsigneeaddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtConsigneeaddress.CustomButton.TabIndex = 1
        Me.txtConsigneeaddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtConsigneeaddress.CustomButton.UseSelectable = True
        Me.txtConsigneeaddress.CustomButton.Visible = False
        Me.txtConsigneeaddress.Lines = New String(-1) {}
        Me.txtConsigneeaddress.Location = New System.Drawing.Point(141, 197)
        Me.txtConsigneeaddress.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConsigneeaddress.MaxLength = 32767
        Me.txtConsigneeaddress.Multiline = True
        Me.txtConsigneeaddress.Name = "txtConsigneeaddress"
        Me.txtConsigneeaddress.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtConsigneeaddress.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtConsigneeaddress.SelectedText = ""
        Me.txtConsigneeaddress.SelectionLength = 0
        Me.txtConsigneeaddress.SelectionStart = 0
        Me.txtConsigneeaddress.Size = New System.Drawing.Size(277, 63)
        Me.txtConsigneeaddress.Style = MetroFramework.MetroColorStyle.Green
        Me.txtConsigneeaddress.TabIndex = 170
        Me.txtConsigneeaddress.UseCustomBackColor = True
        Me.txtConsigneeaddress.UseCustomForeColor = True
        Me.txtConsigneeaddress.UseSelectable = True
        Me.txtConsigneeaddress.UseStyleColors = True
        Me.txtConsigneeaddress.WaterMark = "ที่อยู่"
        Me.txtConsigneeaddress.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtConsigneeaddress.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(425, 595)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 17)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "Return Contact"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 17)
        Me.Label2.TabIndex = 169
        Me.Label2.Text = "Shipper address"
        '
        'txtShipperaddress
        '
        '
        '
        '
        Me.txtShipperaddress.CustomButton.Image = Nothing
        Me.txtShipperaddress.CustomButton.Location = New System.Drawing.Point(215, 1)
        Me.txtShipperaddress.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtShipperaddress.CustomButton.Name = ""
        Me.txtShipperaddress.CustomButton.Size = New System.Drawing.Size(61, 61)
        Me.txtShipperaddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtShipperaddress.CustomButton.TabIndex = 1
        Me.txtShipperaddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtShipperaddress.CustomButton.UseSelectable = True
        Me.txtShipperaddress.CustomButton.Visible = False
        Me.txtShipperaddress.Lines = New String(-1) {}
        Me.txtShipperaddress.Location = New System.Drawing.Point(141, 45)
        Me.txtShipperaddress.Margin = New System.Windows.Forms.Padding(2)
        Me.txtShipperaddress.MaxLength = 32767
        Me.txtShipperaddress.Multiline = True
        Me.txtShipperaddress.Name = "txtShipperaddress"
        Me.txtShipperaddress.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtShipperaddress.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtShipperaddress.SelectedText = ""
        Me.txtShipperaddress.SelectionLength = 0
        Me.txtShipperaddress.SelectionStart = 0
        Me.txtShipperaddress.Size = New System.Drawing.Size(277, 63)
        Me.txtShipperaddress.Style = MetroFramework.MetroColorStyle.Green
        Me.txtShipperaddress.TabIndex = 168
        Me.txtShipperaddress.UseCustomBackColor = True
        Me.txtShipperaddress.UseCustomForeColor = True
        Me.txtShipperaddress.UseSelectable = True
        Me.txtShipperaddress.UseStyleColors = True
        Me.txtShipperaddress.WaterMark = "ที่อยู่"
        Me.txtShipperaddress.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtShipperaddress.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'dtpLoadDate
        '
        Me.dtpLoadDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLoadDate.Location = New System.Drawing.Point(557, 439)
        Me.dtpLoadDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpLoadDate.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtpLoadDate.Name = "dtpLoadDate"
        Me.dtpLoadDate.Size = New System.Drawing.Size(151, 29)
        Me.dtpLoadDate.TabIndex = 52
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(10, 299)
        Me.Label42.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(101, 17)
        Me.Label42.TabIndex = 167
        Me.Label42.Text = "Consignee Ref"
        '
        'txtConsigneeRef
        '
        '
        '
        '
        Me.txtConsigneeRef.CustomButton.Image = Nothing
        Me.txtConsigneeRef.CustomButton.Location = New System.Drawing.Point(254, 2)
        Me.txtConsigneeRef.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConsigneeRef.CustomButton.Name = ""
        Me.txtConsigneeRef.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtConsigneeRef.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtConsigneeRef.CustomButton.TabIndex = 1
        Me.txtConsigneeRef.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtConsigneeRef.CustomButton.UseSelectable = True
        Me.txtConsigneeRef.CustomButton.Visible = False
        Me.txtConsigneeRef.Lines = New String(-1) {}
        Me.txtConsigneeRef.Location = New System.Drawing.Point(142, 292)
        Me.txtConsigneeRef.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConsigneeRef.MaxLength = 32767
        Me.txtConsigneeRef.Multiline = True
        Me.txtConsigneeRef.Name = "txtConsigneeRef"
        Me.txtConsigneeRef.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtConsigneeRef.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtConsigneeRef.SelectedText = ""
        Me.txtConsigneeRef.SelectionLength = 0
        Me.txtConsigneeRef.SelectionStart = 0
        Me.txtConsigneeRef.Size = New System.Drawing.Size(276, 24)
        Me.txtConsigneeRef.Style = MetroFramework.MetroColorStyle.Green
        Me.txtConsigneeRef.TabIndex = 166
        Me.txtConsigneeRef.UseCustomBackColor = True
        Me.txtConsigneeRef.UseCustomForeColor = True
        Me.txtConsigneeRef.UseSelectable = True
        Me.txtConsigneeRef.UseStyleColors = True
        Me.txtConsigneeRef.WaterMark = "ติดต่อโรงงาน"
        Me.txtConsigneeRef.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtConsigneeRef.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(425, 449)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 17)
        Me.Label20.TabIndex = 53
        Me.Label20.Text = "Loading Date"
        '
        'dtpReturnDate
        '
        Me.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReturnDate.Location = New System.Drawing.Point(557, 527)
        Me.dtpReturnDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpReturnDate.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtpReturnDate.Name = "dtpReturnDate"
        Me.dtpReturnDate.Size = New System.Drawing.Size(151, 29)
        Me.dtpReturnDate.TabIndex = 54
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(425, 537)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(85, 17)
        Me.Label21.TabIndex = 55
        Me.Label21.Text = "Return Date"
        '
        'dtpCloseRNDate
        '
        Me.dtpCloseRNDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCloseRNDate.Location = New System.Drawing.Point(557, 614)
        Me.dtpCloseRNDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpCloseRNDate.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtpCloseRNDate.Name = "dtpCloseRNDate"
        Me.dtpCloseRNDate.Size = New System.Drawing.Size(151, 29)
        Me.dtpCloseRNDate.TabIndex = 56
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 271)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 17)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Consignee Contact"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(425, 621)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 17)
        Me.Label22.TabIndex = 57
        Me.Label22.Text = "Closing RN Date"
        '
        'txtConsigneeContact
        '
        '
        '
        '
        Me.txtConsigneeContact.CustomButton.Image = Nothing
        Me.txtConsigneeContact.CustomButton.Location = New System.Drawing.Point(255, 2)
        Me.txtConsigneeContact.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConsigneeContact.CustomButton.Name = ""
        Me.txtConsigneeContact.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtConsigneeContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtConsigneeContact.CustomButton.TabIndex = 1
        Me.txtConsigneeContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtConsigneeContact.CustomButton.UseSelectable = True
        Me.txtConsigneeContact.CustomButton.Visible = False
        Me.txtConsigneeContact.Lines = New String(-1) {}
        Me.txtConsigneeContact.Location = New System.Drawing.Point(141, 264)
        Me.txtConsigneeContact.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConsigneeContact.MaxLength = 32767
        Me.txtConsigneeContact.Multiline = True
        Me.txtConsigneeContact.Name = "txtConsigneeContact"
        Me.txtConsigneeContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtConsigneeContact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtConsigneeContact.SelectedText = ""
        Me.txtConsigneeContact.SelectionLength = 0
        Me.txtConsigneeContact.SelectionStart = 0
        Me.txtConsigneeContact.Size = New System.Drawing.Size(277, 24)
        Me.txtConsigneeContact.Style = MetroFramework.MetroColorStyle.Green
        Me.txtConsigneeContact.TabIndex = 28
        Me.txtConsigneeContact.UseCustomBackColor = True
        Me.txtConsigneeContact.UseCustomForeColor = True
        Me.txtConsigneeContact.UseSelectable = True
        Me.txtConsigneeContact.UseStyleColors = True
        Me.txtConsigneeContact.WaterMark = "ติดต่อโรงงาน"
        Me.txtConsigneeContact.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtConsigneeContact.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtShipperRef
        '
        '
        '
        '
        Me.txtShipperRef.CustomButton.Image = Nothing
        Me.txtShipperRef.CustomButton.Location = New System.Drawing.Point(254, 2)
        Me.txtShipperRef.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtShipperRef.CustomButton.Name = ""
        Me.txtShipperRef.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtShipperRef.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtShipperRef.CustomButton.TabIndex = 1
        Me.txtShipperRef.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtShipperRef.CustomButton.UseSelectable = True
        Me.txtShipperRef.CustomButton.Visible = False
        Me.txtShipperRef.Lines = New String(-1) {}
        Me.txtShipperRef.Location = New System.Drawing.Point(142, 140)
        Me.txtShipperRef.Margin = New System.Windows.Forms.Padding(2)
        Me.txtShipperRef.MaxLength = 32767
        Me.txtShipperRef.Multiline = True
        Me.txtShipperRef.Name = "txtShipperRef"
        Me.txtShipperRef.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtShipperRef.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtShipperRef.SelectedText = ""
        Me.txtShipperRef.SelectionLength = 0
        Me.txtShipperRef.SelectionStart = 0
        Me.txtShipperRef.Size = New System.Drawing.Size(276, 24)
        Me.txtShipperRef.Style = MetroFramework.MetroColorStyle.Green
        Me.txtShipperRef.TabIndex = 27
        Me.txtShipperRef.UseCustomBackColor = True
        Me.txtShipperRef.UseCustomForeColor = True
        Me.txtShipperRef.UseSelectable = True
        Me.txtShipperRef.UseStyleColors = True
        Me.txtShipperRef.WaterMark = "การอ้างอิงลูกค้า"
        Me.txtShipperRef.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtShipperRef.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 148)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 17)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Shipper Ref"
        '
        'txtShipperContact
        '
        '
        '
        '
        Me.txtShipperContact.CustomButton.Image = Nothing
        Me.txtShipperContact.CustomButton.Location = New System.Drawing.Point(255, 2)
        Me.txtShipperContact.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtShipperContact.CustomButton.Name = ""
        Me.txtShipperContact.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtShipperContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtShipperContact.CustomButton.TabIndex = 1
        Me.txtShipperContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtShipperContact.CustomButton.UseSelectable = True
        Me.txtShipperContact.CustomButton.Visible = False
        Me.txtShipperContact.Lines = New String(-1) {}
        Me.txtShipperContact.Location = New System.Drawing.Point(141, 112)
        Me.txtShipperContact.Margin = New System.Windows.Forms.Padding(2)
        Me.txtShipperContact.MaxLength = 32767
        Me.txtShipperContact.Multiline = True
        Me.txtShipperContact.Name = "txtShipperContact"
        Me.txtShipperContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtShipperContact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtShipperContact.SelectedText = ""
        Me.txtShipperContact.SelectionLength = 0
        Me.txtShipperContact.SelectionStart = 0
        Me.txtShipperContact.Size = New System.Drawing.Size(277, 24)
        Me.txtShipperContact.Style = MetroFramework.MetroColorStyle.Green
        Me.txtShipperContact.TabIndex = 25
        Me.txtShipperContact.UseCustomBackColor = True
        Me.txtShipperContact.UseCustomForeColor = True
        Me.txtShipperContact.UseSelectable = True
        Me.txtShipperContact.UseStyleColors = True
        Me.txtShipperContact.WaterMark = "ติดต่อลูกค้า"
        Me.txtShipperContact.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtShipperContact.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 120)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 17)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Shipper Contact"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 177)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Consignee"
        '
        'txtConsignee
        '
        '
        '
        '
        Me.txtConsignee.CustomButton.Image = Nothing
        Me.txtConsignee.CustomButton.Location = New System.Drawing.Point(169, 2)
        Me.txtConsignee.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConsignee.CustomButton.Name = ""
        Me.txtConsignee.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtConsignee.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtConsignee.CustomButton.TabIndex = 1
        Me.txtConsignee.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtConsignee.CustomButton.UseSelectable = True
        Me.txtConsignee.Lines = New String(-1) {}
        Me.txtConsignee.Location = New System.Drawing.Point(142, 169)
        Me.txtConsignee.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConsignee.MaxLength = 32767
        Me.txtConsignee.Multiline = True
        Me.txtConsignee.Name = "txtConsignee"
        Me.txtConsignee.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtConsignee.ReadOnly = True
        Me.txtConsignee.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtConsignee.SelectedText = ""
        Me.txtConsignee.SelectionLength = 0
        Me.txtConsignee.SelectionStart = 0
        Me.txtConsignee.ShowButton = True
        Me.txtConsignee.Size = New System.Drawing.Size(191, 24)
        Me.txtConsignee.Style = MetroFramework.MetroColorStyle.Green
        Me.txtConsignee.TabIndex = 12
        Me.txtConsignee.UseCustomBackColor = True
        Me.txtConsignee.UseCustomForeColor = True
        Me.txtConsignee.UseSelectable = True
        Me.txtConsignee.UseStyleColors = True
        Me.txtConsignee.WaterMark = "ผู้นำเข้า"
        Me.txtConsignee.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtConsignee.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 27)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Shipper"
        '
        'txtShipper
        '
        '
        '
        '
        Me.txtShipper.CustomButton.Image = Nothing
        Me.txtShipper.CustomButton.Location = New System.Drawing.Point(170, 2)
        Me.txtShipper.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.txtShipper.CustomButton.Name = ""
        Me.txtShipper.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.txtShipper.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtShipper.CustomButton.TabIndex = 1
        Me.txtShipper.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtShipper.CustomButton.UseSelectable = True
        Me.txtShipper.Lines = New String(-1) {}
        Me.txtShipper.Location = New System.Drawing.Point(141, 17)
        Me.txtShipper.Margin = New System.Windows.Forms.Padding(2)
        Me.txtShipper.MaxLength = 32767
        Me.txtShipper.Multiline = True
        Me.txtShipper.Name = "txtShipper"
        Me.txtShipper.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtShipper.ReadOnly = True
        Me.txtShipper.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtShipper.SelectedText = ""
        Me.txtShipper.SelectionLength = 0
        Me.txtShipper.SelectionStart = 0
        Me.txtShipper.ShowButton = True
        Me.txtShipper.Size = New System.Drawing.Size(192, 24)
        Me.txtShipper.Style = MetroFramework.MetroColorStyle.Green
        Me.txtShipper.TabIndex = 10
        Me.txtShipper.UseCustomBackColor = True
        Me.txtShipper.UseCustomForeColor = True
        Me.txtShipper.UseSelectable = True
        Me.txtShipper.UseStyleColors = True
        Me.txtShipper.WaterMark = "ผู้ส่งออก"
        Me.txtShipper.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtShipper.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(183, 18)
        Me.Button10.Margin = New System.Windows.Forms.Padding(2)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(85, 32)
        Me.Button10.TabIndex = 136
        Me.Button10.Text = "New"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(272, 18)
        Me.Button9.Margin = New System.Windows.Forms.Padding(2)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(85, 32)
        Me.Button9.TabIndex = 121
        Me.Button9.Text = "Search"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(94, 18)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(85, 32)
        Me.Button3.TabIndex = 80
        Me.Button3.Text = "Print"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(5, 18)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(85, 32)
        Me.Button4.TabIndex = 81
        Me.Button4.Text = "Save"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.MetroTextBox1)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button9)
        Me.GroupBox2.Controls.Add(Me.Button10)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 772)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1151, 62)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        '
        'MetroTextBox1
        '
        '
        '
        '
        Me.MetroTextBox1.CustomButton.Image = Nothing
        Me.MetroTextBox1.CustomButton.Location = New System.Drawing.Point(1, 2)
        Me.MetroTextBox1.CustomButton.Margin = New System.Windows.Forms.Padding(2)
        Me.MetroTextBox1.CustomButton.Name = ""
        Me.MetroTextBox1.CustomButton.Size = New System.Drawing.Size(19, 19)
        Me.MetroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox1.CustomButton.TabIndex = 1
        Me.MetroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox1.CustomButton.UseSelectable = True
        Me.MetroTextBox1.Lines = New String(-1) {}
        Me.MetroTextBox1.Location = New System.Drawing.Point(1128, 38)
        Me.MetroTextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.MetroTextBox1.MaxLength = 32767
        Me.MetroTextBox1.Multiline = True
        Me.MetroTextBox1.Name = "MetroTextBox1"
        Me.MetroTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox1.SelectedText = ""
        Me.MetroTextBox1.SelectionLength = 0
        Me.MetroTextBox1.SelectionStart = 0
        Me.MetroTextBox1.ShowButton = True
        Me.MetroTextBox1.Size = New System.Drawing.Size(23, 24)
        Me.MetroTextBox1.Style = MetroFramework.MetroColorStyle.Green
        Me.MetroTextBox1.TabIndex = 268
        Me.MetroTextBox1.UseCustomBackColor = True
        Me.MetroTextBox1.UseCustomForeColor = True
        Me.MetroTextBox1.UseSelectable = True
        Me.MetroTextBox1.UseStyleColors = True
        Me.MetroTextBox1.WaterMark = "Booking No"
        Me.MetroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.MetroTextBox1.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'BookingConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1168, 749)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "BookingConfirm"
        Me.Text = "Booking Confirm"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 as GroupBox
    Friend WithEvents txtOceanVoy as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtLocalVoy as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label44 as Label
    Friend WithEvents txtOceanVessel as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label45 as Label
    Friend WithEvents txtLocalVessel as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label43 as Label
    Friend WithEvents txtPlaceofDelivery as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label34 as Label
    Friend WithEvents txtPortofDischarge as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label33 as Label
    Friend WithEvents txtPortofLoading as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label28 as Label
    Friend WithEvents txtPlaceofReceive as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label11 as Label
    Friend WithEvents txtNotifyaddress as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label23 as Label
    Friend WithEvents txtNotifyParty as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label3 as Label
    Friend WithEvents txtConsigneeaddress as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label2 as Label
    Friend WithEvents txtShipperaddress as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label42 as Label
    Friend WithEvents txtConsigneeRef as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Button10 as Button
    Friend WithEvents Button9 as Button
    Friend WithEvents Button3 as Button
    Friend WithEvents Button4 as Button
    Friend WithEvents Label9 as Label
    Friend WithEvents txtConsigneeContact as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtShipperRef as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label8 as Label
    Friend WithEvents txtShipperContact as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label7 as Label
    Friend WithEvents Label1 as Label
    Friend WithEvents txtConsignee as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label5 as Label
    Friend WithEvents txtShipper as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtCloseRNTime as MaskedTextBox
    Friend WithEvents txtReturnTime as MaskedTextBox
    Friend WithEvents txtLoadTime as MaskedTextBox
    Friend WithEvents txtPickTime as MaskedTextBox
    Friend WithEvents Label22 as Label
    Friend WithEvents dtpCloseRNDate as MetroFramework.Controls.MetroDateTime
    Friend WithEvents Label21 as Label
    Friend WithEvents dtpReturnDate as MetroFramework.Controls.MetroDateTime
    Friend WithEvents Label20 as Label
    Friend WithEvents dtpLoadDate as MetroFramework.Controls.MetroDateTime
    Friend WithEvents Label14 as Label
    Friend WithEvents txtReturnContact as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtReturnLocation as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label19 as Label
    Friend WithEvents Label18 as Label
    Friend WithEvents txtLoadContact as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label17 as Label
    Friend WithEvents txtPickContact as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtLoadLocation as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label16 as Label
    Friend WithEvents Label15 as Label
    Friend WithEvents dtpPickDate as MetroFramework.Controls.MetroDateTime
    Friend WithEvents txtPickLocation as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label13 as Label
    Friend WithEvents txtVesselBooking as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label12 as Label
    Friend WithEvents Label6 as Label
    Friend WithEvents txtVesselagent as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtVesselContact as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label4 as Label
    Friend WithEvents txtCoLoadContact as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label31 as Label
    Friend WithEvents Label30 as Label
    Friend WithEvents txtagentCoLoad as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label29 as Label
    Friend WithEvents txtRemark as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label25 as Label
    Friend WithEvents txtCustomeraddress as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtCustomerContact as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label26 as Label
    Friend WithEvents Label27 as Label
    Friend WithEvents txtCustomerCoLoad as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtCloseVGMTime as MaskedTextBox
    Friend WithEvents dtpCloseVGMDate as MetroFramework.Controls.MetroDateTime
    Friend WithEvents Label24 as Label
    Friend WithEvents txtCloseSITime as MaskedTextBox
    Friend WithEvents dtpCloseSIDate as MetroFramework.Controls.MetroDateTime
    Friend WithEvents Label10 as Label
    Friend WithEvents Label46 as Label
    Friend WithEvents txtagentaddress as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtagentContact as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label48 as Label
    Friend WithEvents Label49 as Label
    Friend WithEvents txtagentPartner as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label50 as Label
    Friend WithEvents Label41 as Label
    Friend WithEvents Label40 as Label
    Friend WithEvents txtPackageGW as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtCBM as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label39 as Label
    Friend WithEvents Label38 as Label
    Friend WithEvents txtContainerGW2 as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtContainerGW1 as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtContainerNW2 as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtContainerNW1 as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtQtyContainer2 as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtContainerType2 as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtQtyContainer1 as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label37 as Label
    Friend WithEvents txtContainerType1 as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtPackageQty as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label36 as Label
    Friend WithEvents txtPackageType as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label35 as Label
    Friend WithEvents txtContainer as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label32 as Label
    Friend WithEvents txtMarkNumber as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label53 as Label
    Friend WithEvents dtpETa as MetroFramework.Controls.MetroDateTime
    Friend WithEvents Label52 as Label
    Friend WithEvents dtpETD as MetroFramework.Controls.MetroDateTime
    Friend WithEvents cboTermOfPayment as MetroFramework.Controls.MetroComboBox
    Friend WithEvents Label51 as Label
    Friend WithEvents cboBookingType as MetroFramework.Controls.MetroComboBox
    Friend WithEvents Label47 as Label
    Friend WithEvents txtDescriptionOfGoods as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label54 as Label
    Friend WithEvents cboNoOfOriginalBL as MetroFramework.Controls.MetroComboBox
    Friend WithEvents txtUserBooking as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtQuotationNo as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label56 as Label
    Friend WithEvents txtBookingNo as MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label55 as Label
    Friend WithEvents txtUserQuotation as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtIdent as MetroFramework.Controls.MetroTextBox
    Friend WithEvents dtpBookingNoDate as MetroFramework.Controls.MetroDateTime
    Friend WithEvents txtType as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtNotifyCode as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtConsigneeCode as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtVesselCode as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtagentCode as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtCustCode as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtShipperCode as MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtPartnerCode as MetroFramework.Controls.MetroTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents MetroTextBox1 As MetroFramework.Controls.MetroTextBox
End Class
