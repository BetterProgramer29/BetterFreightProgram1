Public Class ClsRecordset
    Private sqlsource as String = ""
    Private cn as OleDb.OleDbConnection
    Private da as OleDb.OleDbDataadapter
    Private cm as OleDb.OleDbCommandBuilder
    Private dt as DataTable
    Private isconnectok as Boolean = False 'สถานะการติดต่อฐานข้อมูล
    Private isfounddata as Boolean = False 'สถานะการมีข้อมูลของ Datatable
    Private iserror as Boolean = False 'สถานะข้อผิดพลาดการทำงาน
    Private errorstr as String = "" 'ตัวแปรเก็บข้อผิดพลาด
    Private totalrec as Long = 0 'ตัวแปรเก็บจำนวนเรคคอร์ด
    Public Sub New()
        'default การกำหนดค่าเริ่มต้น
        setVariable()
    End Sub
    Public Sub New(ByVal connectionstring as String)
        'กรณีส่ง connectionstring มาอย่างเดียว
        setVariable()
        cn = New OleDb.OleDbConnection(connectionstring)
        cn.Open()
        CheckConnect()
    End Sub
    Public Sub New(ByVal sqlcommand as String, ByVal connectionstring as String)
        'กรณีส่งคำสั่ง SQL กับ connectionstring มาจะเปิด Datatable ทันที
        setVariable()
        cn = New OleDb.OleDbConnection(connectionstring)
        cn.Open()
        CheckConnect()
        Recordsource = sqlcommand
    End Sub
    Public Property Recordsource() as String
        'ฟังชั่นในการรับค่า SQL Command และอ่านค่าข้อมูลลง Datatable
        Get
            Return sqlsource
        End Get
        Set(ByVal value as String)
            sqlsource = value
            ReadData()
        End Set
    End Property
    Public Function ReadData() as Boolean
        'ฟังชั่นในการอ่านข้อมูลเข้า Datatable
        setVariable()
        isfounddata = False
        totalrec = 0
        errorstr = "Data Not Found"
        If (isconnectok = True) Then
            Try
                da = New OleDb.OleDbDataadapter(sqlsource, cn)
                cm = New OleDb.OleDbCommandBuilder(da)
                dt = New DataTable
                da.Fill(dt)
                errorstr = ""
                totalrec = dt.Rows.Count
                If (totalrec > 0) Then
                    isfounddata = True
                End If
            Catch ex as Exception
                iserror = True
                errorstr = ex.Message
            End Try
        Else
            setErrorConnectFail()
        End If
        Return isfounddata
    End Function
    Public ReadOnly Property HasError() as Boolean
        Get
            Return iserror
        End Get
    End Property
    Public ReadOnly Property ErrorMessage() as String
        'เก็บค่า error message
        Get
            Return errorstr
        End Get
    End Property
    Public ReadOnly Property RecordCount() as Long
        'จำนวนเรคคอร์ดทั้งหมด
        Get
            Return totalrec
        End Get
    End Property
    Public Property DataSource() as DataTable
        'รับและคืนค่าข้อมูลที่อ่านมาได้
        Get
            Return dt
        End Get
        Set(ByVal value as DataTable)
            dt = value
        End Set
    End Property
    Public ReadOnly Property HasData() as Boolean
        Get
            Return isfounddata
        End Get
    End Property
    Public Function GetData(Optional ByVal recordno as Long = 0) as DataRow
        'ฟังชั่นคืนค่าแถวในเรคอร์ดเป็น Datarow
        Dim row as DataRow = dt.NewRow
        iserror = False
        Try
            If (dt.Rows.Count > 0) Then
                row = dt.Rows(recordno)
            End If
        Catch ex as Exception
            iserror = True
            errorstr = ex.Message
        End Try
        Return row
    End Function
    Public Function UpdateData(ByVal row as DataRow, Optional ByVal recordno as Long = 0) as Boolean
        'ฟังชั่นสำหรับการอัพเดตข้อมูลของ Datarow ที่รับเข้ามา
        setVariable()
        Dim iscomplete as Boolean = False
        If (isconnectok = True) Then
            Try
                da = New OleDb.OleDbDataadapter(sqlsource, cn)
                cm = New OleDb.OleDbCommandBuilder(da)
                dt = New DataTable
                da.Fill(dt)
                Dim dr as DataRow = dt.NewRow
                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(recordno)
                End If
                For i as Integer = 0 To dt.Columns.Count - 1
                    dr(i) = row(dt.Columns(i).ColumnName)
                Next
                If dr.RowState = DataRowState.Detached Then
                    dt.Rows.add(dr)
                End If
                da.Update(dt)
                iscomplete = True
            Catch ex as Exception
                iserror = True
                errorstr = ex.Message
            End Try
        Else
            setErrorConnectFail()
        End If
        Return iscomplete
    End Function
    Public Function UpdateData(Optional ByVal recordno as Long = 0) as Boolean
        'ฟังชั่นสำหรับการอัพเดตข้อมูลของ Datatable ที่รับเข้ามา
        setVariable()
        Dim iscomplete as Boolean = False
        If (isconnectok = True) Then
            Try
                Dim ds as DataTable = dt
                da = New OleDb.OleDbDataadapter(sqlsource, cn)
                cm = New OleDb.OleDbCommandBuilder(da)
                dt = New DataTable
                da.Fill(dt)
                Dim dr as DataRow = dt.NewRow
                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(recordno)
                End If
                For i as Integer = 0 To dt.Columns.Count - 1
                    dr(i) = ds.Rows(recordno)(dt.Columns(i).ColumnName)
                Next
                If dr.RowState = DataRowState.Detached Then
                    dt.Rows.add(dr)
                End If
                da.Update(dt)
                iscomplete = True
            Catch ex as Exception
                iserror = True
                errorstr = ex.Message
            End Try
        Else
            setErrorConnectFail()
        End If
        Return iscomplete
    End Function
    Public Property Connection() as OleDb.OleDbConnection
        'รับ/ส่งค่า connection เข้ามาใช้ใน class
        Get
            Return cn
        End Get
        Set(ByVal value as OleDb.OleDbConnection)
            cn = value
            CheckConnect()
        End Set
    End Property
    Public ReadOnly Property IsConnect() as Boolean
        Get
            Return isconnectok
        End Get
    End Property
    Public Property ConnectionString() as String
        Get
            Return cn.ConnectionString
        End Get
        Set(ByVal value as String)
            Try
                setVariable()
                cn = New OleDb.OleDbConnection
                cn.ConnectionString = value
                cn.Open()
                CheckConnect()
            Catch ex as Exception
                iserror = True
                errorstr = ex.Message
            End Try
        End Set
    End Property
    Private Sub CheckConnect()
        'ฟังชั่นนี้สำหรับตรวจสอบสถานะของคอนเน็คชั่น
        If (cn.State = ConnectionState.Open) Then
            isconnectok = True
        Else
            isconnectok = False
            setErrorConnectFail()
        End If
    End Sub
    Private Sub setErrorConnectFail()
        iserror = True
        errorstr = "Can't open connection"
    End Sub
    Private Sub setVariable()
        iserror = False
        errorstr = ""
    End Sub
    Public Function RunSQLCommand(ByVal strSQL as String) as Boolean
        'ฟังชั่นนี้สำหรับการรันคำสั่ง SQL พวก Insert/Update/Delete ตาม connection ที่กำหนด
        setVariable()
        If isconnectok = True Then
            Try
                Dim cm as OleDb.OleDbCommand = New OleDb.OleDbCommand
                cm.Connection = cn
                cm.CommandType = CommandType.Text
                cm.CommandText = strSQL
                cm.ExecuteNonQuery()
            Catch ex as Exception
                iserror = True
                errorstr = ex.Message
            End Try
        Else
            setErrorConnectFail()
        End If
        Return Not iserror
    End Function
    Public Sub Close()
        Try
            cn.Close()
        Catch ex as Exception

        End Try
    End Sub
End Class
