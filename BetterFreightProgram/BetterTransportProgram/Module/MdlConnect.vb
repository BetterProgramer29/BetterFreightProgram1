Imports System.Data.OleDb
Module MdlConnect

    Public ProjectPath, ConfigPath, ConStr, ReportPath, UserLogin, iniPath as String
    Public isRegis as Boolean = False
    Public TypeDB as String = ""
    Public ds as DataSet
    Public da as OleDbDataadapter
    Public cn as New OleDbConnection
    Public brid, contid as String 'เก็บค่า Branch ID
    Public selectedItem as Integer 'เลือก Barnch
    Public selectedcont as Integer 'เลือก contact
    Public FindSuccess as Boolean 'ค้นหาข้อมูล
    Public Sub getConnect()
        If System.Deployment.application.applicationDeployment.IsNetworkDeployed Then
            Dim str as String = My.application.Deployment.UpdateLocation.ToString
            Dim appPath as String() = str.Split("/")
            Dim str2 as String = str.Replace(appPath(appPath.Length - 1), "")
            str2 = str2.Replace("file:", "")
            ProjectPath = str2.Replace("/", "\")
            ConfigPath = ProjectPath & "\BFT.ini"
            ConStr = GetProfileINI("CONFIG", "CONNECT", ConfigPath)  '
            ' ReportPath = ProjectPath & "\ReportTax"
            ' iniPath = ProjectPath & "\Tawan.ini"
        Else
            ProjectPath = System.Windows.Forms.application.StartupPath
            ConfigPath = ProjectPath & "\BFT.ini"
            ConStr = GetProfileINI("CONFIG", "CONNECT", ConfigPath) '  
            ' ReportPath = ProjectPath & "\ReportTax"
            ' iniPath = ProjectPath & "\Tawan.ini"
        End If
    End Sub

    Public Function ConnectDB() as OleDbConnection
        getConnect()
        Dim cn as New OleDbConnection
        Try
            cn.ConnectionString = "Provider=SQLOLEDB.1;User ID=sa;Password='_betteranDme';Persist Security Info=True;Initial Catalog=BFT_FREIGHT;Data Source=203.170.129.23;" 'ConStr
            If InStr(ConStr, "mdb") > 0 Then
                TypeDB = "aCC"
            Else
                TypeDB = "SQL"
            End If
            If cn.State = ConnectionState.Open Then cn.Close()
            cn.Open()
        Catch ex as Exception
            cn.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connect")
        End Try
        Return cn
    End Function
    Public Function OpenConnection() as Boolean
        'ฟังชั่นในการเปิดคอนเน็คชั่น
        MainConnection = ConnectDB()
        If MainConnection.State = ConnectionState.Open Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
