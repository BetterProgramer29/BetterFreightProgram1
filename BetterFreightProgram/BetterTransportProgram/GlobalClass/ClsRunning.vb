Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class ClsRunning
#Region "variable"
    Private tablename as String = ""
    Private fieldname as String = ""
    Private sqlwhere as String = ""
    Private fieldmask as String = ""
    Private formatvalue as String = ""

    Private year as String = ""
    Private month as String = ""
    Private day as String = ""
    Private AD As String = ""
    Private BE as String = ""

    Private company as String = ""
    Private jobtype as String = ""
    Private shipby as String = ""

    Private timestamp as Date = Today.Date

    Private connectionstring = ""
    Private errorstr as String = ""

    Private isBuddhistYear as Boolean = False
    Private isconnect as Boolean = False

    Private cn as New OleDb.OleDbConnection
    Private replacearray as New List(Of replaceset)
    Public Property ResetByMonth as Boolean
    Private Startat as Integer = 1
    Private Cst as String = ""
#End Region
    Public Property StartatNumber as Integer
        Get
            Return Startat
        End Get
        Set(value as Integer)
            Startat = value
        End Set
    End Property

    Public Property CustCode as String
        Get
            Return Cst
        End Get
        Set(value as String)
            Cst = value
        End Set
    End Property
    Public Property UseBuddhistYear() as Boolean
        Get
            Return isBuddhistYear
        End Get
        Set(ByVal value as Boolean)
            isBuddhistYear = value
        End Set
    End Property
    Public Property OnDate() as Date
        Get
            Return timestamp
        End Get
        Set(ByVal value as Date)
            timestamp = value
        End Set
    End Property
    Public Property Where() as String
        Get
            Return sqlwhere
        End Get
        Set(ByVal value as String)
            sqlwhere = value
        End Set
    End Property
    Public Property Field() as String
        Get
            Return fieldname
        End Get
        Set(ByVal value as String)
            fieldname = value
        End Set
    End Property
    Public Property Table() as String
        Get
            Return tablename
        End Get
        Set(ByVal value as String)
            tablename = value
        End Set
    End Property
    Public Property Mask() as String
        Get
            Return fieldmask
        End Get
        Set(ByVal value as String)
            fieldmask = value
        End Set
    End Property
    Public Property CompanyCode() as String
        Get
            Return company
        End Get
        Set(ByVal value as String)
            company = value
        End Set
    End Property
    Public ReadOnly Property ErrorMessage() as String
        Get
            Return errorstr
        End Get
    End Property
    Public Property JobTypeCode() as String
        Get
            Return jobtype
        End Get
        Set(ByVal value as String)
            jobtype = value
        End Set
    End Property
    Public Property ShipByCode() as String
        Get
            Return shipby
        End Get
        Set(ByVal value as String)
            shipby = value
        End Set
    End Property
    Private Structure replaceset
        Dim type as String
        Dim value as String
    End Structure
    Public Sub New(ByVal connectstring as String)
        connectionstring = connectstring
        isconnect = OpenConnection()
    End Sub
    Public Sub New(ByVal tbname as String, ByVal fldname as String, ByVal mask as String, ByVal connectstring as String)
        connectionstring = connectstring
        isconnect = OpenConnection()
        tablename = tbname
        fieldname = fldname
        fieldmask = mask
    End Sub
    Public Sub New(ByVal tbname as String, ByVal fldname as String, ByVal mask as String, ByVal connectstring as String, Optional ByVal CMP as String = "")
        connectionstring = connectstring
        isconnect = OpenConnection()
        tablename = tbname
        fieldname = fldname
        fieldmask = mask
    End Sub
    Private Sub ExtractDate()
        Dim yyyy as Integer = timestamp.Year
        If isBuddhistYear = True Then
            If yyyy < 2500 Then yyyy = yyyy + 543

        Else
            If yyyy > 2500 Then yyyy = yyyy - 543

        End If
        year = Format(yyyy, "0000")
        month = Format(timestamp.Month, "00")
        day = Format(timestamp.Day, "00")
        BE = Format(yyyy + 543, "00")
        AD = Format(yyyy, "00")
    End Sub
    Private Function OpenConnection() as Boolean
        Try
            errorstr = ""
            cn = New OleDb.OleDbConnection
            cn.ConnectionString = connectionstring
            cn.Open()
            If cn.State = ConnectionState.Open Then
                Return True
            Else
                Return False
            End If
        Catch ex as Exception
            errorstr = ex.Message
            Return False
        End Try
    End Function
    Public Sub addReplace(ByVal format as String, ByVal value as String)
        Dim data as replaceset
        data.type = format
        data.value = value
        replacearray.add(data)
    End Sub
    Public Sub Reset()
        replacearray.Clear()
    End Sub
    Public Function CreateMask() as String
        ExtractDate()
        Dim str as String = fieldmask.ToUpper
        Dim count as Integer = fieldmask.Count(Function(x) UCase(x) = "#")
        formatvalue = ""
        For i as Integer = 1 To count
            formatvalue = formatvalue & "0"
        Next
        str = str.Replace("#", "_")
        str = str.Replace("YYYY", year)
        str = str.Replace("YY", Right(year, 2))
        str = str.Replace("MM", month)
        '*****
        str = str.Replace("[BE]", BE.Substring(BE.Length - 2, 2)) '; //Buddhhism 2 digit
        str = str.Replace("[BE4]", BE) '; //Buddhhism 4 digit
        str = str.Replace("[AD]", AD.Substring(AD.Length - 2, 2)) '; //Cristian 2 digit
        str = str.Replace("[AD4]", AD) '; //Cristian 4 digit

        '  str = str.Replace("M", month.Substring(month.Length - 1, 1))
        str = str.Replace("HH", Format(timestamp.TimeOfDay.Hours, "00"))
        ' str = str.Replace("H", Format(timestamp.TimeOfDay.Hours, "0"))
        str = str.Replace("ss", Format(timestamp.TimeOfDay.Seconds, "00"))
        str = str.Replace("SS", Format(timestamp.TimeOfDay.Seconds, "00"))
        str = str.Replace("DD", day)

        'str = str.Replace("[OWN]", company.PadRight(3)) 'Case Use only 3 characters
        str = str.Replace("[OWN]", company)
        str = str.Replace("[CST]", Cst)

        str = str.Replace("DD", day)
        str = str.Replace("[JS]", jobtype & shipby)
        str = str.Replace("[J]", jobtype)
        str = str.Replace("[S]", shipby)
        ''Run By ETa ETa Full Year
        'str = str.Replace("[ETa]", year & month)
        'str = str.Replace("[ETD]", year & month)
        ''Run By ETa ETa 2 point Year
        'str = str.Replace("ETa", aD.Substring(aD.Length - 2, 2) & month)
        'str = str.Replace("ETD", aD.Substring(aD.Length - 2, 2) & month)

        If replacearray.Count > 0 Then
            For Each Data as replaceset In replacearray
                str = str.Replace(Data.type.ToUpper, Data.value)
            Next
        End If
        Return str
    End Function
    Public Function GetValue(Optional ByVal RunBy as String = "") as String
        Dim max as Long = 0
        Dim mask as String = CreateMask()
        Dim MaskQry as String = fieldmask.ToUpper()
        Dim prefix as String = mask.Replace("_", "")
        Dim value as String = "" ' prefix & Format(max, formatvalue)
        Dim temp as String = "0"
        Try
            value = prefix & Format(max, formatvalue)
            If ResetByMonth = False Then
                ' //// Defualt Year [New medthod]
                MaskQry = MaskQry.Replace("yyyy", year)
                MaskQry = MaskQry.Replace("YYYY", year)
                MaskQry = MaskQry.Replace("yy", year.Substring(year.Length - 2, 2))
                MaskQry = MaskQry.Replace("YY", year.Substring(year.Length - 2, 2))
                '  //**
                MaskQry = MaskQry.Replace("[BE]", BE.Substring(BE.Length - 2, 2)) ' //Buddhhism 2 digit
                MaskQry = MaskQry.Replace("[BE4]", BE) ' //Buddhhism 4 digit
                MaskQry = MaskQry.Replace("[AD]", AD.Substring(AD.Length - 2, 2)) ' //Cristian 2 digit
                MaskQry = MaskQry.Replace("[AD4]", AD) ' //Cristian 4 digit
                MaskQry = MaskQry.Replace("MM", "__")
                MaskQry = MaskQry.Replace("DD", "__")
                MaskQry = MaskQry.Replace("#", "_")
                MaskQry = MaskQry.Replace("[CST]", Cst)
                MaskQry = MaskQry.Replace("[OWN]", company)

            Else
                MaskQry = mask
            End If
            If isconnect Then
                Dim SQLStrMax as String = ""
                If RunBy = "PD" Then
                    SQLStrMax = "select convert(int,dbo.mtb_GetNumbers(MaX(Replace(" & fieldname & ",'" & CustCode & "','')))) as maxvalue from " & tablename & " where " & fieldname & " like'" & MaskQry & "'  " & sqlwhere
                Else
                    'If fieldmask.ToUpper().IndexOf("#") = 0 Then
                    '    SQLStrMax = "select dbo.GetStringSplit(dbo.mtb_GetNumbers(MaX(" & fieldname & ")), ',', 1) as maxvalue from " & tablename & " where " & fieldname & " like'" & MaskQry & "'  " & sqlwhere
                    'ElseIf fieldmask.ToUpper().IndexOf("#") > 0 Then
                    '    SQLStrMax = "select dbo.GetStringSplit(dbo.mtb_GetNumbers(MaX(" & fieldname & ")), ',', 2) as maxvalue from " & tablename & " where " & fieldname & " like'" & MaskQry & "'  " & sqlwhere
                    'Else
                    SQLStrMax = "select MaX(" & fieldname & ") as maxvalue from " & tablename & " where " & fieldname & " like'" & MaskQry & "'  " & sqlwhere
                    'End If
                End If
                Dim rd as OleDbDataReader = New OleDbCommand(SQLStrMax, cn).ExecuteReader
                If rd.Read() Then
                    temp = rd(0).ToString()
                    If String.IsNullOrEmpty(temp) Then
                        temp = "0"
                    Else
                        temp = temp.Replace(prefix, "")
                    End If
                    If IsNumeric(temp) Then
                        If Integer.Parse(temp) = 0 Then max = Integer.Parse(temp) + Startat
                        If Integer.Parse(temp) > 0 Then max = Integer.Parse(temp) + 1
                    Else
                        max = 1
                    End If
                Else
                    temp = temp.Replace(prefix, "")
                    max = 1
                End If
                value = New Regex("_+").Replace(mask, Format(max, formatvalue))
            Else 'case connection Error
                'mask = CreateMask()
                'prefix = mask.Replace("_", "")
                'max = 1
                'Return value = New Regex("_+").Replace(mask, Format(max, formatvalue))
                value = "ERROR"
            End If
            Return value
        Catch ex as Exception
            'errorstr &= ex.Message & vbCrLf
            'mask = CreateMask()
            'prefix = mask.Replace("_", "")
            'max = 1
            'Return value = New Regex("_+").Replace(mask, Format(max, formatvalue))
            Return "ERROR"
        End Try
    End Function

End Class
