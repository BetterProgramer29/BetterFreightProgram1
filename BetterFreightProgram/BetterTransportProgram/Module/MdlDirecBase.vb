Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Net
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers

Module MdlDirecBase
    Public Function ExecuteNonQuery(ByVal SQLCommand as String, ByRef cn as OleDb.OleDbConnection) as Integer
        Dim exceptionCode as Integer = 0
        Try
            Dim command as OleDb.OleDbCommand = New OleDb.OleDbCommand(SQLCommand, cn)
            Dim read as OleDb.OleDbDataReader = command.ExecuteReader
            If read.HasRows and read IsNot Nothing Then
                read.Read()
                exceptionCode = 1
            End If
            read.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        Return exceptionCode
    End Function
    Public Sub LoadSysBranch(ByVal Indx as Integer)
        Try
            Dim ssbr as SysBranch = New SysBranch()
            SBranch = New SysBranch()
            Dim da as New OleDb.OleDbDataadapter
            Dim dt as DataTable = New DataTable()
            Dim Str as String = "select * from [Mas_Branch] where [TBIDNT]='" & Indx & "' "
            da.SelectCommand = New OleDb.OleDbCommand(Str, MainConnection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ssbr.BranchPK = CInt(dt.Rows(0)(0).ToString())
                ssbr.CMPCode = dt.Rows(0)(1).ToString()
                ssbr.BranchCode = dt.Rows(0)(2).ToString()
                ssbr.BranchName = dt.Rows(0)(3).ToString()
                ssbr.BranchEName = dt.Rows(0)(4).ToString()
                SBranch = ssbr
            Else
                DisposeSysBranch()
            End If

        Catch ex as Exception
            DisposeSysBranch()
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '************************** ***************** ******************* *********************** ***********************
    Public Sub LoadCbo(ByVal cbo as ComboBox, ByVal sqlstr as String)
        LoadCboDS(cbo, sqlstr, MainConnection)
    End Sub
    Public Sub LoadCboDS(ByVal cbo as System.Windows.Forms.ComboBox, ByVal SQLCommand as String, ByVal Cn as OleDb.OleDbConnection, Optional ByVal cbo_text as String = "", Optional ByVal SelectIndex as Integer = 0)
        Try
            Dim da as New OleDb.OleDbDataadapter(SQLCommand, Cn)
            Dim ds as New DataTable
            Dim tErr as String = "System.Data.DataRowView"
            da.Fill(ds)
            If cbo.Text <> "" and cbo.Text <> tErr Then cbo.Tag = cbo.Text
            cbo.DataSource = ds
            cbo.DisplayMember = ds.Columns(SelectIndex).Caption
            If ds.Columns.Count > 1 Then
                cbo.ValueMember = ds.Columns(1).Caption
            Else
                cbo.ValueMember = ds.Columns(0).Caption
            End If
            cbo.SelectedIndex = -1
            cbo.Text = cbo_text
        Catch ex as Exception

        End Try

    End Sub
    Public Sub ComboBoxList(ByVal cbo as System.Windows.Forms.ComboBox, ByVal SQLCommand as String, ByVal Cn as OleDb.OleDbConnection, Optional ByVal SelectIndex as Integer = 0)
        Try
            Dim da as New OleDb.OleDbDataadapter(SQLCommand, Cn)
            Dim dt as New DataTable
            da.Fill(dt)
            cbo.DataSource = dt
            cbo.DisplayMember = dt.Columns(1).ToString()
            cbo.ValueMember = dt.Columns(0).ToString()
        Catch ex as Exception

        End Try
    End Sub
    '********************************* ********************* ********************** *********************** *************
    Public Sub DisposeSysBranch()
        Try
            SBranch.BranchPK = 0
            SBranch.CMPCode = Nothing
            SBranch.BranchCode = Nothing
            SBranch.BranchName = Nothing
            SBranch.BranchEName = Nothing
        Catch ex as Exception

        End Try
    End Sub
    Public Function GetDataUser(ByVal userid as String, ByVal cmp as String, ByVal branch as String) as UserData
        'แบบระบุข้อมูล
        Dim rs as New ClsRecordset
        Dim user as New UserData
        Dim str as String = SQLUser & " where UCode='" & userid & "' and UBrCode='" & branch & "' and UCMPCode='" & cmp & "' and active=1"
        rs.Connection = MainConnection
        rs.Recordsource = str 'SQLUser & " where U_Code='" & userid & "' and U_BrCode='" & branch & "' and U_CMPCode='" & cmp & "' and U_Status=1"
        If rs.RecordCount > 0 Then
            user = ReadUser(rs.DataSource.Rows(0))
        End If
        Return user
    End Function
    Public Function ReadUser(ByVal dr as DataRow) as UserData
        Dim userinfo as New UserData
        userinfo.U_Code = dr("UCode").ToString()
        userinfo.U_EntryCode = dr("UEntryCode").ToString()
        userinfo.U_BrCode = dr("UBrCode").ToString()
        userinfo.U_CMPCode = dr("UCMPCode").ToString()
        userinfo.U_FName = dr("UFName").ToString()
        userinfo.U_LName = dr("ULName").ToString()
        userinfo.U_Position = dr("UPosition").ToString()
        userinfo.U_WorkLine = dr("UDepartment").ToString()
        userinfo.U_PhoneNo = dr("UPhoneno").ToString()
        userinfo.U_address = dr("Uaddress").ToString()
        userinfo.U_ImgPath = dr("UImgPath").ToString()

        userinfo.U_ISCanEditUser = dr("UISCanEditUser").ToString
        userinfo.U_ISShowSpCost = dr("UISShowSpCost").ToString
        userinfo.U_ISShowCost = dr("UISShowCost").ToString
        userinfo.U_ISShowPrice = dr("UISShowPrice").ToString
        userinfo.U_ISOpenOper = dr("UISOpenOper").ToString
        userinfo.U_ISOpenRPT = dr("UISOpenRPT").ToString
        userinfo.U_ISOpenMaS = dr("UISOpenMaS").ToString
        userinfo.U_ISOpenSYS = dr("UISOpenSYS").ToString
        userinfo.U_Status = dr("active").ToString
        Return userinfo
    End Function
    Public Sub Userauthorize(ByVal UserID as String, ByVal appID as String, Optional ByVal MenuID as String = "")
        Try
            Dim Uathu as New UserautoStruc
            Userauthen = New UserautoStruc
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter
            Dim dt as New DataTable
            Dim str as String = "select * from [Sys_Userauth] where  CMPCode='" & CMPProfile.PROF_Code & "' and BranchCode='" & CMPProfile.PROF_BrCode & "' and [UserID]='" & UserID & "' and [appID]='" & appID & "'"
            If Not String.IsNullOrEmpty(MenuID) Then str &= " and MenuID='" & MenuID & "'"

            da.SelectCommand = New OleDb.OleDbCommand(str, MainConnection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Uathu.CMPCode = dt.Rows(0)("CMPCode").ToString()
                Uathu.BranchCode = dt.Rows(0)("BranchCode").ToString()
                Uathu.UserID = dt.Rows(0)("UserID").ToString()
                Uathu.appID = dt.Rows(0)("appID").ToString()
                Uathu.MenuID = dt.Rows(0)("MenuID").ToString()

                Uathu.IsOpenMenu = CInt(dt.Rows(0)("IsOpenMenu").ToString())
                Uathu.IsInsertData = CInt(dt.Rows(0)("IsInsertData").ToString())
                Uathu.IsEditData = CInt(dt.Rows(0)("IsEditData").ToString())
                Uathu.IsDeleteData = CInt(dt.Rows(0)("IsDeleteData").ToString())
                Uathu.IsPrintData = CInt(dt.Rows(0)("IsPrintData").ToString())
                Uathu.IsCheckData = CInt(dt.Rows(0)("IsCheckData").ToString())
                Uathu.Isapprove = CInt(dt.Rows(0)("Isapprove").ToString())
                Uathu.IsReapprove = CInt(dt.Rows(0)("IsReapprove").ToString())
                Uathu.IsCancel = CInt(dt.Rows(0)("IsCancel").ToString())
                Uathu.IsRecancel = CInt(dt.Rows(0)("IsRecancel").ToString())
                Uathu.IsRevise = CInt(dt.Rows(0)("IsRevise").ToString())
                Uathu.UMaIdentity = CInt(dt.Rows(0)("TBIDNT").ToString())
                Userauthen = Uathu
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End Try
    End Sub
    Public Sub DisposeUserauthorize()
        Try
            Userauthen.CMPCode = Nothing
            Userauthen.BranchCode = Nothing
            Userauthen.UserID = Nothing
            Userauthen.appID = Nothing
            Userauthen.MenuID = Nothing

            Userauthen.IsOpenMenu = 0
            Userauthen.IsInsertData = 0
            Userauthen.IsEditData = 0
            Userauthen.IsDeleteData = 0
            Userauthen.IsPrintData = 0
            Userauthen.IsCheckData = 0
            Userauthen.Isapprove = 0
            Userauthen.IsReapprove = 0
            Userauthen.IsCancel = 0
            Userauthen.IsRecancel = 0
            Userauthen.IsRevise = 0
            Userauthen.UMaIdentity = 0
        Catch ex as Exception

        End Try
    End Sub
    Public Function GetDataProfile()
        'Defult
        Dim rs as New ClsRecordset
        Dim Profile as New MemberProfiles
        rs.Connection = MainConnection
        rs.Recordsource = "select * from Sys_Profile where active = '1'"
        If rs.RecordCount > 0 Then
            Profile = ReadProfile(rs.DataSource.Rows(0))
        End If
        Return Profile
    End Function
    Public Function GetDataProfile(CMP_Code as String, Br_Code as String)
        'Change Profile
        Dim rs as New ClsRecordset
        Dim Profile as New MemberProfiles
        rs.Connection = MainConnection
        rs.Recordsource = "select * from [V_Sys_Profile] where PFCode='" & CMP_Code & "' and PFBrCode='" & Br_Code & "' and active = '1'"
        If rs.RecordCount > 0 Then
            Profile = ReadProfile(rs.DataSource.Rows(0))
        End If
        Return Profile
    End Function
    Public Function ReadProfile(DtRow as DataRow) as MemberProfiles
        Dim ProInfo as New MemberProfiles
        ProInfo.PROF_Code = DtRow("PFCode").ToString
        ProInfo.PROF_BrCode = DtRow("PFBrCode").ToString
        ProInfo.PROF_BranchName = DtRow("BranchName").ToString
        ProInfo.PROF_TaxNumber = DtRow("PFTaxNumber").ToString
        ProInfo.PROF_Name = DtRow("PFName").ToString
        ProInfo.PROF_address1 = DtRow("PFaddress1").ToString
        ProInfo.PROF_address2 = DtRow("PFaddress2").ToString
        ProInfo.PROF_Mobile = DtRow("PFMobile").ToString
        ProInfo.PROF_Telephone = DtRow("PFTelephone").ToString
        ProInfo.PROF_FaX = DtRow("PFFaX").ToString
        ProInfo.PROF_WEB = DtRow("PFWEB").ToString
        ProInfo.PROF_MaIL = DtRow("PFMaIL").ToString
        ProInfo.PROF_ReportDaTaBaSE = DtRow("PFReportDaTaBaSE").ToString
        ProInfo.PROF_VaTRate = DtRow("PFVaTRate").ToString
        ProInfo.PROF_TaXRate = DtRow("PFTaXRate").ToString
        ProInfo.PROF_Currency = DtRow("PFCurrencyCode").ToString
        ProInfo.PROF_ExchangeRate = DtRow("PFExchangeRate").ToString
        ProInfo.PROF_ExchangeRateURL = DtRow("PFExchangeRateURL").ToString
        ProInfo.PROF_ReportPath = DtRow("PFReportPath").ToString
        ProInfo.PROF_Language = DtRow("PFLanguage").ToString
        ProInfo.PROF_active = DtRow("active").ToString
        Return ProInfo
    End Function
    Public Function CheckExistCode(TableName as String, FieldName as String, StringValue as String) as Boolean
        Try
            Dim str as String = ""
            str = "SELECT " & FieldName & " from " & TableName & " where " & FieldName &
                "='" & StringValue & "' and [CMPCode] = '" & CMPProfile.PROF_Code &
                "' and [BranchCode] = '" & CMPProfile.PROF_BrCode & "'"
            Dim dr as DataRow = SelectSingleRow(str)
            If dr IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End Try
    End Function
    Public Function CheckCode(TableName as String, FieldName as String, StringValue as String) as Boolean
        Try
            Dim str as String = ""
            str = "SELECT " & FieldName & " from " & TableName & " where " & FieldName &
                "='" & StringValue & "'"
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
    Public Function CheckVOYCTN(VOY as String, CTN as String)
        Try
            Dim str as String = ""
            str = "SELECT * from [INF_ContainerRound] where [VOYNo]='" & VOY & "' aND [ContainerNo]='" & CTN & "'"
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
    Public Function CheckBranch(Cmp as String, Brcode as String, BrType as String) as Boolean
        Try
            Dim str as String = "SELECT * FROM [V_OPTBranch] "
            str &= " WHERE [CODE]='" & Cmp & "' aND [BranchCode]='" & Brcode & "' aND [BranchType]='" & BrType & "'"
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
    Public Function SelectSingleRow(sql as String) as DataRow
        Dim records as ClsRecordset = New ClsRecordset()
        Dim Rows as DataRow = Nothing
        records.Connection = MainConnection
        records.Recordsource = sql

        If records.RecordCount > 0 Then
            Rows = records.DataSource.Rows(0)
        End If
        Return Rows
    End Function
    Public Function PopUpSearch(ByVal SQLCmd as String, ByRef cn as OleDb.OleDbConnection) as DataRow
        Dim frm as frmSeachEngine = New frmSeachEngine
        Dim drs as DataRow
        Try
            isSearchOK = False
            frm.LoadGrid(SQLCmd, cn)
            frm.TopMost = True
            frm.ShowDialog()
            If frm.FindSuccess = True Then
                isSearchOK = True
                drs = frm.RowReturn.Row
            End If
        Catch ex as Exception

        End Try
        Return drs

    End Function

    Public Sub SelectMenu(ByVal GetCode as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [appID],[NameTH],[NameEN],[MenuGroup] FROM [Sys_Menu] where 1=1 "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr(0).ToString
                ' GetRate.Text = CDbl(dr(2).ToString).ToString("#,#0.0000")
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectCurrencyCode(ByVal GetCode as MetroFramework.Controls.MetroTextBox, ByVal GetRate as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT *  FROM [V_MasCurrency] where 1=1 "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr(0).ToString
                GetRate.Text = CDbl(dr(2).ToString).ToString("#,#0.0000")
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectCurrencyCode(ByVal GetCode as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT *  FROM [V_MasCurrency] where 1=1 "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr(0).ToString
                'GetRate.Text = CDbl(dr(2).ToString).ToString("#,#0.0000")
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectCurrencyName(ByVal GetCode as MetroFramework.Controls.MetroTextBox, ByVal GetName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT *  FROM [V_MasCurrency] where 1=1 "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr("CurrencyCode").ToString
                GetName.Text = dr("CurrencyName").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub GetCurrency(ByRef GetCode as MetroFramework.Controls.MetroTextBox, ByRef GetName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DISTINCT [CurrencyCode],[CurrencyName],[LastUpdate]  FROM [V_MasCurrency] where 1=1 and CurrencyCode='" & GetCode.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                GetCode.Text = dr("CurrencyCode").ToString()
                GetName.Text = dr("CurrencyName").ToString()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectCountry(ByVal GetCode as MetroFramework.Controls.MetroTextBox, ByVal GetName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [CountryCode],[CountryName]  FROM [V_MasCountry] where 1=1  "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr(0).ToString
                GetName.Text = dr(1).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectCountryName(ByVal GetCode as String, ByVal GetName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim sqlstr as String = "SELECT [CountryCode],[CountryName]  FROM [V_MasCountry] where 1=1 aND  CountryCode='" & GetCode & "'"
            Dim dr as DataRow = SelectSingleRow(sqlstr)
            If dr IsNot Nothing Then
                GetName.Text = dr("CountryName").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Public Sub SelectVessel(ByVal GetCode as MetroFramework.Controls.MetroTextBox, ByVal GetName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT TOP 100 [VesselCode],[VesselName]  FROM [V_MasVessel] where 1=1  "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr(0).ToString
                GetName.Text = dr(1).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectVessel(ByVal VendorCode as MetroFramework.Controls.MetroTextBox, ByVal VendorBranchCode as MetroFramework.Controls.MetroTextBox, ByVal VesselCode as MetroFramework.Controls.MetroTextBox, ByVal VesselName as MetroFramework.Controls.MetroTextBox, ByVal FeederCode as MetroFramework.Controls.MetroTextBox, ByVal FeederName as MetroFramework.Controls.MetroTextBox, ByVal MasterCode as MetroFramework.Controls.MetroTextBox, ByVal MasterName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT TOP 100 [VesselCode],[VesselName],[FeederCode],[FeederName],[MasterCode],[MasterName]  
 FROM [V_MasVesselList] WHERE [VendorCode]='" & VendorCode.Text & "' aND [VendorBrCode]='" & VendorBranchCode.Text & "' aND [active]=1 "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                VesselCode.Text = dr(0).ToString
                VesselName.Text = dr(1).ToString
                FeederCode.Text = dr(2).ToString
                FeederName.Text = dr(3).ToString
                MasterCode.Text = dr(4).ToString
                MasterName.Text = dr(5).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Public Sub SelectVendor(ByRef VenCode as MetroFramework.Controls.MetroTextBox, ByRef VenBrCode as MetroFramework.Controls.MetroTextBox, ByRef VenName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT TOP 100 [VenCode],[VenBranch],[VenName],[VenContact],[CountryName],[Taddress],[TTaddress] from [V_MasVendor] where 1=1 aND [CMPCode]='" & CMPProfile.PROF_Code & "'
aND [BranchCode]='" & CMPProfile.PROF_BrCode & "'"


            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                VenCode.Text = dr("VenCode").ToString
                VenBrCode.Text = dr("VenBranch").ToString
                VenName.Text = dr("VenName").ToString
                ' Venaddress.Text = dr("Taddress").ToString & " " & dr("TTaddress").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectVendor(ByVal VendorCode as MetroFramework.Controls.MetroTextBox, ByVal VendorBranchCode as MetroFramework.Controls.MetroTextBox, ByVal VendorName as MetroFramework.Controls.MetroTextBox, ByVal VendorContactINF as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT TOP 100 [VenCode],[VenBranch],[VenName],[VenContact],[CountryName],[VenCity]
,[VenType] from [V_MasVendor] where 1=1 aND [CMPCode]='" & CMPProfile.PROF_Code & "'
aND [BranchCode]='" & CMPProfile.PROF_BrCode & "'"

            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                VendorCode.Text = dr("VenCode").ToString
                VendorBranchCode.Text = dr("VenBranch").ToString
                VendorName.Text = dr("VenName").ToString
                VendorContactINF.Text = dr("VenContact").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectVendor(ByRef VenCode as MetroFramework.Controls.MetroTextBox, ByRef VenBrCode as MetroFramework.Controls.MetroTextBox, ByRef VenName as MetroFramework.Controls.MetroTextBox, ByRef Venaddress as MetroFramework.Controls.MetroTextBox, Optional ByVal TT as String = "")
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT TOP 100 [VenCode],[VenBranch],[VenName],[VenContact],[CountryName],[Taddress],[TTaddress] from [V_MasVendor] where 1=1 aND [CMPCode]='" & CMPProfile.PROF_Code & "'
aND [BranchCode]='" & CMPProfile.PROF_BrCode & "'"


            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                VenCode.Text = dr("VenCode").ToString
                VenBrCode.Text = dr("VenBranch").ToString
                VenName.Text = dr("VenName").ToString
                Venaddress.Text = dr("Taddress").ToString & " " & dr("TTaddress").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectVenContact(ByVal VendorCode as MetroFramework.Controls.MetroTextBox, ByVal VendorBranchCode as MetroFramework.Controls.MetroTextBox, ByVal VendorContactINF as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [VenContactName],[ContactDescription],[ContactPhone],[ContactFaX],[ContactEmail] FROM [Mas_VendorContact]  WHERE [VenCode]='" & VendorCode.Text & "' aND [VenBranch]='" & VendorBranchCode.Text & "' aND [active]=1 "

            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                VendorContactINF.Text = dr("VenContactName").ToString & " " & dr("ContactDescription").ToString & " " & dr("ContactDescription").ToString & " " & dr("ContactPhone").ToString & " " & dr("ContactFaX").ToString & " " & dr("ContactEmail").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectCustomer(ByVal CustCode as MetroFramework.Controls.MetroTextBox, ByVal CustBranchCode as MetroFramework.Controls.MetroTextBox, ByVal CustName as MetroFramework.Controls.MetroTextBox, ByVal CustContactINF as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT TOP 100 [CustCode] ,[CustBranch] ,[TaxNumber] ,[CustName],[CustContact],Taddress  FROM [V_MasCustomer] WHERE  [CMPCode]='" & CMPProfile.PROF_Code & "' and BranchCode='" & CMPProfile.PROF_BrCode & "' order by [CustCode] "
            'CustType='CST' aND
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                CustCode.Text = dr("CustCode").ToString
                CustBranchCode.Text = dr("CustBranch").ToString
                CustName.Text = dr("CustName").ToString
                CustContactINF.Text = dr("CustContact").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectCustomer(ByRef CustCode as MetroFramework.Controls.MetroTextBox, ByRef CustBrCode as MetroFramework.Controls.MetroTextBox, ByRef CustName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT TOP 100 [CustCode] ,[CustBranch] ,[TaxNumber] ,[CustName],Taddress  FROM [V_MasCustomer] WHERE  [CMPCode]='" & CMPProfile.PROF_Code & "' and BranchCode='" & CMPProfile.PROF_BrCode & "' order by [CustCode] "
            'CustType='CST' aND
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                CustCode.Text = dr("CustCode").ToString
                CustBrCode.Text = dr("CustBranch").ToString
                CustName.Text = dr("CustName").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectCustomer(ByRef CustCode as MetroFramework.Controls.MetroTextBox, ByRef CustBrCode as MetroFramework.Controls.MetroTextBox, ByRef CustName as MetroFramework.Controls.MetroTextBox, ByRef Custaddress as MetroFramework.Controls.MetroTextBox, Optional ByVal TT as String = "")
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT TOP 100 [CustCode] ,[CustBranch] ,[TaxNumber] ,[CustName],Taddress,TTaddress  FROM [V_MasCustomer] WHERE [CMPCode]='" & CMPProfile.PROF_Code & "' and BranchCode='" & CMPProfile.PROF_BrCode
            If Not String.IsNullOrEmpty(TT) Then sqlstr &= "' aND CustType='" & TT & "' "
            sqlstr &= " order by [CustCode] "

            ' CustType='CST' aND
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                CustCode.Text = dr("CustCode").ToString
                CustBrCode.Text = dr("CustBranch").ToString
                CustName.Text = dr("CustName").ToString
                Custaddress.Text = dr("Taddress").ToString & " " & dr("TTaddress").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectCustomer(ByRef CustCode as MetroFramework.Controls.MetroTextBox, ByRef CustBrCode as MetroFramework.Controls.MetroTextBox, ByRef CustName as MetroFramework.Controls.MetroTextBox, ByRef Custaddress as MetroFramework.Controls.MetroTextBox, ByRef CustContact as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT TOP 100 [CustCode] ,[CustBranch] ,[TaxNumber] ,[CustName],Taddress,TTaddress,CustContact  FROM [V_MasCustomer] WHERE CustType='CST' aND [CMPCode]='" & CMPProfile.PROF_Code & "' and BranchCode='" & CMPProfile.PROF_BrCode & "' order by [CustCode] "
            '
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                CustCode.Text = dr("CustCode").ToString
                CustBrCode.Text = dr("CustBranch").ToString
                CustName.Text = dr("CustName").ToString
                Custaddress.Text = dr("Taddress").ToString & " " & dr("TTaddress").ToString
                CustContact.Text = dr("CustContact").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectCustomerContact(ByRef CustName as MetroFramework.Controls.MetroTextBox, ByVal CustCode as String, ByVal CustBrCode as String)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [ContactName],[ContactDescription] FROM [Mas_CustomerContact] WHERE 1=1 aND [CustCode]='" & CustCode & "' and [CustBranch]='" & CustBrCode & "' "

            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                ' CustCode.Text = dr("CustCode").ToString
                CustName.Text = dr("ContactName").ToString & " " & dr("ContactDescription").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Public Sub SelectUnit(ByVal GetCode as MetroFramework.Controls.MetroTextBox, ByVal GetName as MetroFramework.Controls.MetroTextBox, Optional ByVal UnitType as String = "")
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [UnitCode],[UnitTName] FROM [V_MasUnit] where 1=1  "
            If Not String.IsNullOrEmpty(UnitType) Then sqlstr &= " aND UnitType='" & UnitType & "'"
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr(0).ToString
                GetName.Text = dr(1).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectUnitCode(ByVal GetCode as MetroFramework.Controls.MetroTextBox, Optional ByVal UnitType as String = "")
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [UnitCode],[UnitTName] FROM [V_MasUnit] where 1=1  "
            If Not String.IsNullOrEmpty(UnitType) Then sqlstr &= " aND UnitType='" & UnitType & "'"
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr("UnitCode").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectCommo(ByVal GetName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT * from Q_Commodity where 1=1  "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetName.Text = dr(0).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectContainerYard(ByVal GetName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT * from V_MasContainerYard where 1=1  "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetName.Text = dr(0).ToString & ", " & dr(1).ToString & ", " & dr(2).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectInterPort(ByVal GetCode as MetroFramework.Controls.MetroTextBox, ByVal GetName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [PortCode],[PortName],[CountryCode],[CountryName]  FROM [V_MasInterPort] WHERE [active]=1 "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr(0).ToString
                GetName.Text = dr(1).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub GetInterPort(ByVal GetCode as MetroFramework.Controls.MetroTextBox, ByVal GetName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT top 2 [PortCode],[PortName],[CountryCode],[CountryName]  FROM [V_MasInterPort] WHERE [active]=1 aND PortCode='" & GetCode.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                GetCode.Text = dr(0).ToString
                GetName.Text = dr(1).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectPayable(ByVal PortName as MetroFramework.Controls.MetroTextBox, ByVal CountryName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [PortCode],[PortName],[CountryCode],[CountryName]  FROM [V_MasInterPort] WHERE [active]=1 "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                PortName.Text = dr(0).ToString
                CountryName.Text = dr(1).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectPayable(ByVal CountryName as MetroFramework.Controls.MetroTextBox)
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [PortCode],[PortName],[CountryCode],[CountryName]  FROM [V_MasInterPort] WHERE [active]=1 "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                '  PortName.Text = dr(0).ToString
                CountryName.Text = dr("PortName").ToString & "," & dr("CountryName").ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectareaPort(ByVal GetCode as MetroFramework.Controls.MetroTextBox, ByVal GetName as MetroFramework.Controls.MetroTextBox)

        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [areaCode],[areaName],[areaEName]  FROM [Mas_InternalPort] WHERE [active]=1 "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr(0).ToString
                GetName.Text = dr(1).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectVOYNo(ByVal GetCode as MetroFramework.Controls.MetroTextBox, ByRef Indx as Integer)

        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [VOYNo],[ShipRunNumber],[VendorCode],[VendorBranchCode],[VenName],[VenCity] FROM [Q_ShipRound] WHERE 1=1 "
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr(Indx).ToString
                'GetName.Text = dr(1).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub SelectContainerNo(ByVal GetCode as MetroFramework.Controls.MetroTextBox, Optional ByVal RunNo as String = "")
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT [CTNContainerNo],[CTNSealNo],[CTNTruckNo],[CTNQTONumber],[CTNContainerSizeCode],[CTNRunNumber] FROM [INF_ContainerandSeal] WHERE 1=1 "
            If Not String.IsNullOrEmpty(RunNo) Then sqlstr &= " aND CTNRunNumber='" & RunNo & "'"
            dr = PopUpSearch(sqlstr, MainConnection)
            If isSearchOK Then
                GetCode.Text = dr(0).ToString
                'GetName.Text = dr(1).ToString
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Function CheckCustCode(CustCode as String, BrCode as String, CustType as String, Optional ByVal CustTypeCode as String = "", Optional ByVal CustTypeBrCode as String = "") as Boolean
        Try
            Dim str as String = "SELECT [CustCode],[CustBranch] from [Mas_Customer] where 1=1 "
            str &= " aND CustCode='" & CustCode & "' aND CustBranch='" & BrCode & "' aND [CustType]='" & CustType & "'"
            str &= " and [CMPCode] = '" & CMPProfile.PROF_Code & "' and [BranchCode] ='" & CMPProfile.PROF_BrCode & "'"
            If String.IsNullOrEmpty(CustTypeCode) = False Then
                Select Case CustType
                    Case "BILL"
                        str &= " and [BillToCustCode]='" & CustTypeCode & "'"
                        str &= " and [BillToBranch]='" & CustTypeBrCode & "'"
                    Case "SHP"
                        str &= " and [ShipToCustCode]='" & CustTypeCode & "'"
                        str &= " and [ShipToBranch]='" & CustTypeBrCode & "'"
                End Select
            End If

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
    Public Function CheckDup(TableName as String, ColumnName as String, jno as String) as Boolean
        Try
            Dim str as String = "SELECT [" & ColumnName & " ] FROM " & TableName & " where " & ColumnName & " ='" & jno & "'"
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
    Public Function CheckJob(jno as String) as Boolean
        Try
            Dim str as String = "SELECT [JobNo] FROM [addTransport] where 1=1 "
            If Not String.IsNullOrEmpty(jno) Then
                str &= " aND Jno='" & jno & "'"
            End If

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
    Public Function CheckadvNo(jno as String) as Boolean
        Try
            Dim str as String = "SELECT advNo FROM advanceRequest where 1=1 "
            If Not String.IsNullOrEmpty(jno) Then
                str &= " aND advNo='" & jno & "'"
            End If

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
    Public Function CheckagentCode(VenCode as String, BrCode as String, VenType as String, Optional ByVal VenTypeCode as String = "", Optional ByVal VenTypeBrCode as String = "") as Boolean
        Try
            Dim str as String = "SELECT [VenCode],[VenBranch] from [Mas_Vendor] where 1=1 "
            str &= " aND [VenCode]='" & VenCode & "' aND [VenBranch]='" & BrCode & "' aND [VenType]='" & VenType & "'"
            str &= " and [CMPCode] = '" & CMPProfile.PROF_Code & "' and [BranchCode] ='" & CMPProfile.PROF_BrCode & "'"
            If String.IsNullOrEmpty(VenTypeCode) = False Then
                str &= " and [BillToVenCode]='" & VenTypeCode & "'"
                str &= " and [BillToBranch]='" & VenTypeBrCode & "'"
            End If
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
    Public Sub GetRunningFormat(RunningCode as String, Optional ByVal TableName as String = "MaS_Running")
        Try
            Dim Running as New RunningForMatt
            RunningForm = New RunningForMatt
            Dim dr as DataRow
            Dim str as String = "select * from " & TableName & " where Run_Code='" & RunningCode & "'" '  and CMPCode='" & CMPProfile.PROF_Code & "' and BranchCode='" & CMPProfile.PROF_BrCode & "'"
            dr = SelectSingleRow(str)
            If dr IsNot Nothing Then
                Running.Run_Code = dr("Run_Code").ToString()
                Running.Run_Name = dr("Run_Name").ToString()
                Running.Run_Formatt = dr("Run_Formatt").ToString()
                Running.Run_IsResetByMonth = CInt(dr("IsResetOnMonth").ToString())
                Running.Run_Startat = CInt(dr("Run_Startat").ToString())
                Running.Run_DocExpire = CInt(dr("Run_DocExpire").ToString())
                Running.Run_autoGen = CInt(dr("Run_autoGen").ToString())
                RunningForm = Running
            Else
                DisposeRunning()
            End If
            dr = Nothing
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub DisposeRunning()
        Try
            RunningForm.Run_Code = Nothing
            RunningForm.Run_Name = Nothing
            RunningForm.Run_Formatt = Nothing
            RunningForm.Run_IsResetByMonth = 0
            RunningForm.Run_Startat = 0
            RunningForm.Run_DocExpire = 0
            RunningForm.Run_autoGen = 0
        Catch ex as Exception

        End Try
    End Sub
    Public Sub GetReportRunning(Indx as Integer)
        Try
            Dim Running as New ReportRunning()
            RptRunning = New ReportRunning()
            Dim da as New OleDbDataadapter()
            Dim dt as New DataTable
            ' Dim dr as DataRow
            Dim str as String = "select * from MaS_RunningReport where [TBIDNT]='" & Indx & "'  and CMPCode='" & CMPProfile.PROF_Code & "' and BranchCode='" & CMPProfile.PROF_BrCode & "'"
            da.SelectCommand = New OleDbCommand(str, MainConnection)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Running.Ident = CInt(dt(0)("TBIDNT").ToString())
                Running.RptDocCode = dt(0)("RptDocCode").ToString()
                Running.RptDescription = dt(0)("RptDescription").ToString()
                Running.RptreportName = dt(0)("RptreportName").ToString()
                Running.appID = dt(0)("appID").ToString()
                RptRunning = Running
            Else
                DisposeReportRunning()
            End If
            'dr = PopUpSearch(str, MainConnection)
            'If (isSearchOK = True) Then
            '    Running.Ident = CInt(dr("TBIDNT").ToString())
            '    Running.RptDocCode = dr("RptDocCode").ToString()
            '    Running.RptDescription = dr("RptDescription").ToString()
            '    Running.RptreportName = dr("RptreportName").ToString()
            '    Running.appID = dr("appID").ToString()
            '    RptRunning = Running
            'Else
            '    DisposeReportRunning()
            'End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Main, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Public Sub DisposeReportRunning()
        Try
            RptRunning.Ident = 0
            RptRunning.RptDocCode = Nothing
            RptRunning.RptDescription = Nothing
            RptRunning.RptreportName = Nothing
            RptRunning.appID = Nothing
        Catch ex as Exception

        End Try
    End Sub

    Public Function CreateNumber(TableNameToCreate as String, FieldNameToCreateValue as String, ByVal ondate as Date) as String
        Dim StrReturn as String = ""
        Dim RunFormatString as String = ""
        Dim rsl as ClsRunning
        If Not String.IsNullOrEmpty(RunningForm.Run_Formatt) Then
            RunFormatString = RunningForm.Run_Formatt
        Else
            RunFormatString = "ERROR"
        End If
        ' rsl = New ClsRunning(TableNameToCreate, FieldNameToCreateValue, RunFormatString, ConnectDB.ConnectionString, CMPProfile.PROF_Code)
        rsl = New ClsRunning(TableNameToCreate, FieldNameToCreateValue, RunFormatString, ConnectDB.ConnectionString, "BFT")
        rsl.OnDate = ondate
        rsl.ResetByMonth = True
        ''If HaveCmpandBrCode Then rsl.Where = " and BranchCode = '" & CMPProfile.PROF_BrCode & "' and CMPCode = '" & CMPProfile.PROF_Code & "' "
        'If RunningForm.Run_IsResetByMonth = 1 Then
        '    rsl.ResetByMonth = True
        '    'If Not String.IsNullOrEmpty(FieldDateToReset) Then rsl.Where &= " and MONTH(" & FieldDateToReset & ") = MONTH(GETDaTE()) "
        'End If
        If RunningForm.Run_Startat = 0 Then
            rsl.StartatNumber = 1
        Else
            rsl.StartatNumber = RunningForm.Run_Startat
        End If
        'If Not String.IsNullOrEmpty(CustCode) Then rsl.CustCode = CustCode
        StrReturn = rsl.GetValue("")
        Return StrReturn
    End Function
    Public Function CreateNumberResetByMonth(TableNameToCreate as String, FieldNameToCreateValue as String, ByVal ondate as Date) as String
        Dim StrReturn as String = ""
        Dim RunFormatString as String = ""
        Dim rsl as ClsRunning
        If Not String.IsNullOrEmpty(RunningForm.Run_Formatt) Then
            RunFormatString = RunningForm.Run_Formatt
        Else
            RunFormatString = Now.ToShortDateString
        End If
        ' rsl = New ClsRunning(TableNameToCreate, FieldNameToCreateValue, RunFormatString, ConnectDB.ConnectionString, CMPProfile.PROF_Code)
        rsl = New ClsRunning(TableNameToCreate, FieldNameToCreateValue, RunFormatString, ConnectDB.ConnectionString, "BFT")
        rsl.OnDate = ondate
        rsl.ResetByMonth = True
        'If HaveCmpandBrCode Then rsl.Where = " and BranchCode = '" & CMPProfile.PROF_BrCode & "' and CMPCode = '" & CMPProfile.PROF_Code & "' "
        If RunningForm.Run_IsResetByMonth = 1 Then
            rsl.ResetByMonth = True
            'If Not String.IsNullOrEmpty(FieldDateToReset) Then rsl.Where &= " and MONTH(" & FieldDateToReset & ") = MONTH(GETDaTE()) "
        End If
        If RunningForm.Run_Startat = 0 Then
            rsl.StartatNumber = 1
        Else
            rsl.StartatNumber = RunningForm.Run_Startat
        End If
        'If Not String.IsNullOrEmpty(CustCode) Then rsl.CustCode = CustCode
        StrReturn = rsl.GetValue("")
        Return StrReturn
    End Function

    Public Function CreateNumber(TableNameToCreate as String, FieldNameToCreateValue as String, ByVal format as String) as String
        Dim StrReturn as String = ""
        Dim RunFormatString as String = ""
        Dim rsl as ClsRunning
        If Not String.IsNullOrEmpty(format) Then
            RunFormatString = format
        End If

        ' rsl = New ClsRunning(TableNameToCreate, FieldNameToCreateValue, RunFormatString, ConnectDB.ConnectionString, CMPProfile.PROF_Code)
        rsl = New ClsRunning(TableNameToCreate, FieldNameToCreateValue, RunFormatString, ConnectDB.ConnectionString, "BFT")
        rsl.OnDate = Now.Date
        rsl.ResetByMonth = False
        'If HaveCmpandBrCode Then rsl.Where = " and BranchCode = '" & CMPProfile.PROF_BrCode & "' and CMPCode = '" & CMPProfile.PROF_Code & "' "
        If RunningForm.Run_IsResetByMonth = 1 Then
            rsl.ResetByMonth = True
            'If Not String.IsNullOrEmpty(FieldDateToReset) Then rsl.Where &= " and MONTH(" & FieldDateToReset & ") = MONTH(GETDaTE()) "
        End If
        If RunningForm.Run_Startat = 0 Then
            rsl.StartatNumber = 1
        Else
            rsl.StartatNumber = RunningForm.Run_Startat
        End If
        'If Not String.IsNullOrEmpty(CustCode) Then rsl.CustCode = CustCode
        StrReturn = rsl.GetValue("")
        Return StrReturn
    End Function

    Public Function CreateNumber(TableNameToCreate as String, FieldNameToCreateValue as String, Optional ByVal HaveCmpandBrCode as Boolean = True, Optional ByVal FieldDateToReset as String = "", Optional ByVal CustCode as String = "", Optional ByVal RunBy as String = "") as String
        Dim StrReturn as String = ""
        Dim RunFormatString as String = ""
        Dim rsl as ClsRunning
        If Not String.IsNullOrEmpty(RunningForm.Run_Formatt) Then
            RunFormatString = RunningForm.Run_Formatt
        Else
            RunFormatString = "ERROR"
        End If

        ' rsl = New ClsRunning(TableNameToCreate, FieldNameToCreateValue, RunFormatString, ConnectDB.ConnectionString, CMPProfile.PROF_Code)
        rsl = New ClsRunning(TableNameToCreate, FieldNameToCreateValue, RunFormatString, ConnectDB.ConnectionString, "BFT")
        rsl.OnDate = Now.Date
        rsl.ResetByMonth = False
        If HaveCmpandBrCode Then rsl.Where = " and BranchCode = '" & CMPProfile.PROF_BrCode & "' and CMPCode = '" & CMPProfile.PROF_Code & "' "
        If RunningForm.Run_IsResetByMonth = 1 Then
            rsl.ResetByMonth = True
            If Not String.IsNullOrEmpty(FieldDateToReset) Then rsl.Where &= " and MONTH(" & FieldDateToReset & ") = MONTH(GETDaTE()) "
        End If
        If RunningForm.Run_Startat = 0 Then
            rsl.StartatNumber = 1
        Else
            rsl.StartatNumber = RunningForm.Run_Startat
        End If
        If Not String.IsNullOrEmpty(CustCode) Then rsl.CustCode = CustCode
        StrReturn = rsl.GetValue(RunBy)
        Return StrReturn
    End Function


    Public Function CreateNumber(TableNameToCreate As String, FieldNameToCreateValue As String, ByVal DateForRun As Date, Optional ByVal HaveCmpandBrCode As Boolean = True, Optional ByVal FieldDateToReset As String = "", Optional ByVal CustCode As String = "", Optional ByVal RunBy As String = "") As String
        Dim StrReturn As String = ""
        Dim RunFormatString As String = ""
        Dim rsl As ClsRunning
        If Not String.IsNullOrEmpty(RunningForm.Run_Formatt) Then
            RunFormatString = RunningForm.Run_Formatt
        Else
            RunFormatString = Now.ToShortDateString
        End If

        rsl = New ClsRunning(TableNameToCreate, FieldNameToCreateValue, RunFormatString, ConnectDB.ConnectionString, CMPProfile.PROF_Code)
        rsl.OnDate = DateForRun ' Now.Date
        rsl.ResetByMonth = False
        If HaveCmpandBrCode Then rsl.Where = " and BranchCode = '" & CMPProfile.PROF_BrCode & "' and CMPCode = '" & CMPProfile.PROF_Code & "' "
        If RunningForm.Run_IsResetByMonth = 1 Then
            rsl.ResetByMonth = True
            If Not String.IsNullOrEmpty(FieldDateToReset) Then rsl.Where &= " and MONTH(" & FieldDateToReset & ") = MONTH(GETDaTE()) "
        End If
        If RunningForm.Run_Startat = 0 Then
            rsl.StartatNumber = 1
        Else
            rsl.StartatNumber = RunningForm.Run_Startat
        End If
        If Not String.IsNullOrEmpty(CustCode) Then rsl.CustCode = CustCode
        StrReturn = rsl.GetValue(RunBy)
        Return StrReturn
    End Function

    '**** * * MdlDirecBase ****
    Public Function CreateNumber(TableNameToCreate As String, FieldNameToCreateValue As String, ByVal format As String, ByVal ondate As Date) As String
        Dim StrReturn As String = ""
        Dim RunFormatString As String = ""
        Dim rsl As ClsRunning
        If Not String.IsNullOrEmpty(format) Then
            RunFormatString = format
        End If

        ' rsl = New ClsRunning(TableNameToCreate, FieldNameToCreateValue, RunFormatString, ConnectDB.ConnectionString, CMPProfile.PROF_Code)
        rsl = New ClsRunning(TableNameToCreate, FieldNameToCreateValue, RunFormatString, ConnectDB.ConnectionString, "BFT")
        rsl.OnDate = ondate
        rsl.ResetByMonth = False
        'If HaveCmpandBrCode Then rsl.Where = " and BranchCode = '" & CMPProfile.PROF_BrCode & "' and CMPCode = '" & CMPProfile.PROF_Code & "' "
        If RunningForm.Run_IsResetByMonth = 1 Then
            rsl.ResetByMonth = True
            'If Not String.IsNullOrEmpty(FieldDateToReset) Then rsl.Where &= " and MONTH(" & FieldDateToReset & ") = MONTH(GETDaTE()) "
        End If
        If RunningForm.Run_Startat = 0 Then
            rsl.StartatNumber = 1
        Else
            rsl.StartatNumber = RunningForm.Run_Startat
        End If
        'If Not String.IsNullOrEmpty(CustCode) Then rsl.CustCode = CustCode
        StrReturn = rsl.GetValue("")
        Return StrReturn
    End Function


End Module
