Module MdlStructure
    Public MainConnection as OleDb.OleDbConnection
    Public UserProfile as UserData
    Public CMPProfile as MemberProfiles
    Public RunningForm as RunningForMatt
    Public RptRunning as ReportRunning
    Public SBranch as SysBranch
    Public Userauthen as UserautoStruc

    Public _IsConfirm as Boolean = False
    Public IsLogingIn as Boolean = False
    Public Iscancel as Boolean = False
    Public isSearchOK as Boolean
    Public SQLUser as String = "select * from Sys_UserSystem "

    'Public frmLogin as frmSystemLogin
    Public Structure UserData
        'โครงสร้างผู้ใช้งาน
        Dim U_Code as String
        Dim U_EntryCode as String
        Dim U_CMPCode as String
        Dim U_BrCode as String
        Dim U_FName as String
        Dim U_LName as String
        Dim U_Position as String
        Dim U_WorkLine as String
        Dim U_PhoneNo as String
        Dim U_address as String
        Dim U_ImgPath as String

        Dim U_ISCanEditUser as Integer
        Dim U_ISShowSpCost as Integer
        Dim U_ISShowCost as Integer
        Dim U_ISShowPrice as Integer
        Dim U_ISOpenOper as Integer
        Dim U_ISOpenRPT as Integer
        Dim U_ISOpenMaS as Integer
        Dim U_ISOpenSYS as Integer
        Dim U_Status as Integer
    End Structure
    Public Structure UserautoStruc
        Public CMPCode as String
        Public BranchCode as String
        Public UserID as String
        Public appID as String
        Public MenuID as String

        Public IsOpenMenu as Integer
        Public IsInsertData as Integer
        Public IsEditData as Integer
        Public IsDeleteData as Integer
        Public IsPrintData as Integer
        Public IsCheckData as Integer
        Public Isapprove as Integer
        Public IsReapprove as Integer
        Public IsCancel as Integer
        Public IsRecancel as Integer
        Public IsRevise as Integer
        Public UMaIdentity as Integer
    End Structure
    Public Structure MemberProfiles
        'โครงสร้าง Company
        Dim PROF_Code as String
        Dim PROF_BrCode as String
        Dim PROF_BranchName as String
        Dim PROF_TaxNumber as String
        Dim PROF_Name as String
        Dim PROF_address1 as String
        Dim PROF_address2 as String
        Dim PROF_Mobile as String
        Dim PROF_Telephone as String
        Dim PROF_FaX as String
        Dim PROF_WEB as String
        Dim PROF_MaIL as String
        Dim PROF_ReportDaTaBaSE as String
        Dim PROF_VaTRate as Integer
        Dim PROF_TaXRate as Integer
        Dim PROF_Currency as String
        Dim PROF_ExchangeRate as Double
        Dim PROF_ExchangeRateURL as String
        Dim PROF_ReportPath as String
        Dim PROF_Language as String
        Dim PROF_active as Integer
    End Structure
    Public Structure SysBranch
        Dim BranchPK as Integer
        Dim CMPCode as String
        Dim BranchCode as String
        Dim BranchName as String
        Dim BranchEName as String
    End Structure
    Public Structure RunningForMatt
        Dim Run_Code as String
        Dim Run_Name as String
        Dim Run_Formatt as String
        Dim Run_IsResetByMonth as Integer
        Dim Run_Startat as Integer
        Dim Run_DocExpire as Integer
        Dim Run_autoGen as Integer
    End Structure
    Public Structure ReportRunning
        Public Ident as Integer
        Public RptDocCode as String
        Public RptDescription as String
        Public RptreportName as String
        Public appID as String
    End Structure


End Module
