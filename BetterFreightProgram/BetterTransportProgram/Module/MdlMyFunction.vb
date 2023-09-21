Imports System.Reflection
Imports System.Runtime.InteropServices.Marshalasattribute
Module modUtilityFunc
    Private Declare Function GetPrivateProfileSection Lib "kernel32" alias "GetPrivateProfileSectiona" (ByVal lpappName as String, ByVal lpReturnedString as String, ByVal nSize as Integer, ByVal lpFileName as String) as Integer
    Private Declare Function GetWindowsDirectory Lib "kernel32" alias "GetWindowsDirectorya" (ByVal lpBuffer as String, ByVal nSize as Long) as Long
    Private Declare Function GetComputerName Lib "kernel32" alias "GetComputerNamea" (ByVal lpBuffer as String, ByVal nSize as Long) as Long
    Private Declare Function GetUserName Lib "advapi32.dll" alias "GetUserNamea" (ByVal lpBuffer as String, ByVal nSize as Long) as Long
    Private Declare Function FindWindow Lib "user32" alias "FindWindowa" (ByVal lpClassName as String, ByVal lpWindowName as String) as Long
    Private Declare Function PostMessage Lib "user32" alias "PostMessagea" (ByVal hwnd as Long, ByVal wMsg as Long, ByVal wParam as Long, ByVal lParam as Long) as Long
    Private Declare Function GetWindowText Lib "user32" alias "GetWindowTexta" (ByVal hwnd as Long, ByVal lpString as String, ByVal cch as Long) as Long
    Private Declare Function GetSystemDirectory Lib "kernel32" alias "GetSystemDirectorya" (ByVal lpBuffer as String, ByVal nSize as Long) as Long
    Private Declare Function ShellExecute Lib "shell32.dll" alias "ShellExecutea" (ByVal hwnd as Long, ByVal lpOperation as String, ByVal lpFile as String, ByVal lpParameters as String, ByVal lpDirectory as String, ByVal nShowCmd as Long) as Long

    Private Declare Function WritePrivateProfileString Lib "kernel32" alias "WritePrivateProfileStringa" (ByVal lpapplicationName as String, ByVal lpKeyName as String, ByVal lpString as String, ByVal lpFileName as String) as Integer
    Public Declare Function GetPrivateProfileString Lib "kernel32" alias "GetPrivateProfileStringa" (ByVal lpapplicationName as String, ByVal lpKeyName as String, ByVal lpDefault as String, ByVal lpReturnedString as String, ByVal nSize as Integer, ByVal lpFileName as String) as Integer

    Public Function GetProfileINI(ByVal pHeader as String, ByVal pKey as String, ByVal ConfigPath as String) as String
        Try
            Dim a As Long
            Dim sbuff As String = ""
            sbuff = Space(5000)
            a = GetPrivateProfileString(pHeader, pKey, "", sbuff, 5000, ConfigPath)
            If a > 0 Then
                Return Left(sbuff, a)
            Else
                Return ""
            End If
        Catch ex As Exception

        End Try

    End Function
    Function ConvertToThaiBaht(ByVal InputCurrency as Decimal) as String
        Dim DigitSave, UnitSave, DigitName, DigitName1, UnitName, Satang, StrTmp, StrTmp1, bt, b, t as String
        Dim DecimalValue, CurrDigit, PrevDigit, StrLen, DigitBase, ScanDigit as Integer
        Dim IntegerValue as Double
        b = ""
        t = ""
        ' init variable
        DigitName = "ศูนย์หนึ่งสอง  สาม  สี่  ห้า  หก   เจ็ด แปด  เก้า "    ' name of digit number
        DigitName1 = "          ยี่  สาม  สี่  ห้า  หก   เจ็ด แปด  เก้า "        ' name of digit number in another call
        UnitName = "แสน  ล้าน สิบ  ร้อย พัน  หมื่น"                             ' name of digit base
        bt = ""
        Satang = ""

        ' check for negative val
        If InputCurrency < 0 Then
            InputCurrency = -InputCurrency
            bt = "ลบ"
        End If

        StrTmp1 = Format(InputCurrency, "0.00")             ' rounds up to 2 decimals
        InputCurrency = Val(StrTmp1)
        IntegerValue = Int(InputCurrency)                           ' get integer value
        DecimalValue = (InputCurrency - IntegerValue) * 100             ' get 2 decimal values

        ' check for zeto val
        If IntegerValue = 0 and DecimalValue = 0 Then
            Satang = "ศูนย์บาทถ้วน"
            GoTo locExit
        End If

        ' translate integer val to name if necesary
        If IntegerValue > 0 Then
            StrTmp = Left(StrTmp1, Len(StrTmp1) - 3)         ' get string of integer val
            StrLen = Len(StrTmp)                                 ' get string len
            CurrDigit = 0

            ' scan integer string and compute its name
            For ScanDigit = StrLen To 1 Step -1
                ' save previous digit
                PrevDigit = CurrDigit
                ' get digit base
                DigitBase = ScanDigit Mod 6
                ' convert digit character to numeric value
                CurrDigit = asc(Mid(StrTmp, StrLen - ScanDigit + 1, 1)) - 48
                ' get unit name FROM its base
                UnitSave = RTrim(Mid(UnitName, DigitBase * 5 + 1, 5))
                ' get number name FROM Currdigit, depends on the digit base
                DigitSave = RTrim(Mid(IIf(DigitBase = 2, DigitName1, DigitName), CurrDigit * 5 + 1, 5))

                ' base ten and number 1
                If DigitBase = 1 and CurrDigit = 1 and PrevDigit <> 0 Then
                    DigitSave = "เอ็ด"
                End If

                ' first digit base may be base million or 1
                If DigitBase = 1 and ScanDigit < 6 Then
                    UnitSave = ""
                End If

                ' ignore add digit name in result string if it is zero
                If CurrDigit <> 0 Then
                    b = b + DigitSave + UnitSave
                ElseIf DigitBase = 1 Then
                    b = b + UnitSave
                End If
            Next ScanDigit

            t = bt & b & "บาท"
        End If

        ' if no decimal value
        If DecimalValue = 0 Then
            Satang = "ถ้วน"
            ' compute decimal val to name, there are only 2 digit
        Else
            StrTmp = Right(StrTmp1, 2)

            ' name ot first digit
            CurrDigit = asc(Left(StrTmp, 1)) - 48
            PrevDigit = CurrDigit

            If CurrDigit > 0 Then
                Satang = RTrim(Mid(DigitName1, CurrDigit * 5 + 1, 5)) + "สิบ"
            End If

            ' name of last digit
            CurrDigit = asc(Right(StrTmp, 1)) - 48

            If CurrDigit > 0 Then
                Satang = Satang + IIf(CurrDigit = 1 and PrevDigit <> 0, "เอ็ด", RTrim(Mid(DigitName, CurrDigit * 5 + 1, 5)))
            End If

            ' store result and unit
            Satang = Satang + "สตางค์"
        End If

locExit:
        ' store result to BahtText
        ConvertToThaiBaht = "(" + t + Satang + ")"
    End Function
    Public Function RpNull(ByVal strIn as String, Optional ByVal chgtotxt as String = "", Optional ByVal chgtoZero as Boolean = False)
        On Error Resume Next
        If strIn.ToString = "" Then
            If Len(chgtotxt) >= 1 Or Not chgtoZero Then
                Return chgtotxt
            Else
                Return 0
            End If
        Else
            If strIn = "00:00:00" Or strIn = "01/01/1900" Then strIn = "__/__/____"
            If Len(strIn) = 0 and Len(chgtotxt) > 0 Then
                Return chgtotxt
            Else
                If Len(strIn) = 0 and chgtoZero Then
                    Return 0
                Else
                    Return strIn
                End If
            End If
        End If
    End Function

    Public Function FindData(ByVal SQLCommand as String, ByVal Cn as OleDb.OleDbConnection) as String
        Dim RetStr as String = ""
        If Cn.State <> ConnectionState.Open Then
            Cn = MdlConnect.ConnectDB
        End If
        Try
            Dim cm as New OleDb.OleDbCommand(SQLCommand, Cn)
            Dim rd as OleDb.OleDbDataReader = cm.ExecuteReader
            If rd.HasRows = True Then
                rd.Read()
                RetStr = rd(0).ToString
            End If
            Return RetStr
            rd.Close()
            cm.Dispose()
        Catch ex as Exception
            'MsgBox(ex.Message)
            MetroFramework.MetroMessageBox.Show(Main, "Error : " & ex.Message & " " & ex.StackTrace, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return RetStr
        End Try
    End Function

    Public Function getDataSplit(ByVal vstring as String, ByVal delimiter as String, ByVal Index as Integer, Optional ByVal Defaultstr as String = "") as String
        Dim v as array
        If delimiter = "" Then delimiter = "|"
        v = Split(vstring, delimiter)
        If UBound(v) >= Index Then
            Return RpNull(v(Index).ToString.Trim, Defaultstr)
        Else
            Return Defaultstr.Trim
        End If
    End Function

    Public Sub SearchData(ByVal SQLCmd as String, ByVal Cn as OleDb.OleDbConnection, ByRef ReturnStr0 as String, Optional ByRef ReturnStr1 as String = "", Optional ByVal Field0 as Integer = 0, Optional ByVal Field1 as Integer = 0)
        Frm_FindRecord.LoadGrid(SQLCmd, Cn)
        Frm_FindRecord.TopMost = True
        Frm_FindRecord.ShowDialog()
        If FindSuccess = True Then
            If Frm_FindRecord.DataGridView1.Rows.Count > 0 Then
                If Field1 <> 0 Then
                    ReturnStr0 = Frm_FindRecord.DataGridView1.SelectedRows(0).Cells(Field0).Value.ToString
                    ReturnStr1 = Frm_FindRecord.DataGridView1.SelectedRows(0).Cells(Field1).Value.ToString
                Else
                    ReturnStr0 = Frm_FindRecord.DataGridView1.SelectedRows(0).Cells(0).Value.ToString
                End If

            End If
        End If
        Frm_FindRecord.Close()
    End Sub

    Public Sub CheckKey(ByVal pkey as System.Windows.Forms.KeyEventargs)
        Select Case pkey.KeyCode
            Case Windows.Forms.Keys.Return
                My.Computer.Keyboard.SendKeys("{TaB}")
        End Select
    End Sub

    Public Function strLeft(ByVal [string] as String, ByVal length as Integer) as String
        If length < [string].Length Then length = [string].Length
        Return [string].Substring(0, length)
    End Function

    Public Function strRight(ByVal s as String, ByVal i as Integer) as String
        If Not ((i >= s.Length) Or (s.Length < 1)) Then
            s = s.Substring(s.Length - i, i)
        End If
        Return (s)
    End Function

    Public Function SetCurrencyFormat(ByVal txt as System.Windows.Forms.TextBox, Optional ByVal msg as String = "") as Boolean
        If Trim(txt.Text) <> "" Then
            Try
                txt.Text = CDbl(txt.Text).ToString("#,#0.00")
            Catch ex as Exception
                If msg <> "" Then
                    'MsgBox(msg & "ไม่ถูกต้อง", MsgBoxStyle.Critical)
                    MetroFramework.MetroMessageBox.Show(Main, "Currency Format Incorrected!", "Data Input", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    txt.Focus()
                End If
                Return False
                Exit Function
            End Try
            Return True
        End If
    End Function

    Public Sub CheckDouble(ByVal pkey as System.Windows.Forms.KeyPressEventargs)
        If pkey.KeyChar = Chr(Keys.Back) Then
        ElseIf pkey.KeyChar = Chr(Keys.Enter) Then
        ElseIf Char.IsNumber(pkey.KeyChar) = True Then
        ElseIf pkey.KeyChar = "." Then
        Else
            pkey.Handled = True
            ' MsgBox("ตัวเลขหรือจุดทศนิยมเท่านั้น!!")
            MetroFramework.MetroMessageBox.Show(Main, "Numeric Format Only!", "Data Input", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Public Sub CheckNumeric(ByVal pkey as System.Windows.Forms.KeyPressEventargs)
        If pkey.KeyChar = Chr(Keys.Back) Then
        ElseIf pkey.KeyChar = Chr(Keys.Enter) Then
        ElseIf Char.IsNumber(pkey.KeyChar) = True Then
        Else
            pkey.Handled = True
            ' MsgBox("ตัวเลขเท่านั้น!!")
            MetroFramework.MetroMessageBox.Show(Main, "Numeric Format Only!", "Data Input", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
    Public Function CheckQuote(ByVal pkey as System.Windows.Forms.KeyPressEventargs) as Boolean
        If asc(pkey.KeyChar) = 39 Then
            pkey.Handled = True
            ' MsgBox("ไม่อนุญาติให้พิมพ์อักขระพิเศษ", MsgBoxStyle.Critical)
            MetroFramework.MetroMessageBox.Show(Main, "Not allow Sign!", "Data Input", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        Else
            Return True
        End If
    End Function
    Public Function CheckChar(ByVal pkey as System.Windows.Forms.KeyPressEventargs) as Boolean
        Select Case asc(pkey.KeyChar)
            Case 33 To 39 '! "#$%&'
                pkey.Handled = True
                ' MsgBox("ไม่อนุญาติให้พิมพ์อักขระพิเศษ", MsgBoxStyle.Critical)
                MetroFramework.MetroMessageBox.Show(Main, "Not allow Sign!", "Data Input", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            Case 58 To 64 ':;<=>?@
                pkey.Handled = True
                'MsgBox("ไม่อนุญาติให้พิมพ์อักขระพิเศษ", MsgBoxStyle.Critical)
                MetroFramework.MetroMessageBox.Show(Main, "Not allow Sign!", "Data Input", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            Case 91 To 94 '[\]a
                pkey.Handled = True
                'MsgBox("ไม่อนุญาติให้พิมพ์อักขระพิเศษ", MsgBoxStyle.Critical)
                MetroFramework.MetroMessageBox.Show(Main, "Not allow Sign!", "Data Input", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            Case 96, 42 '`,*
                pkey.Handled = True
                'MsgBox("ไม่อนุญาติให้พิมพ์อักขระพิเศษ", MsgBoxStyle.Critical)
                MetroFramework.MetroMessageBox.Show(Main, "Not allow Sign!", "Data Input", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            Case 123 To 126 '{|}~
                pkey.Handled = True
                'MsgBox("ไม่อนุญาติให้พิมพ์อักขระพิเศษ", MsgBoxStyle.Critical)
                MetroFramework.MetroMessageBox.Show(Main, "Not allow Sign!", "Data Input", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            Case Else
                Return True
        End Select
    End Function



    Public Sub CreateProfileINI(ByVal pHeader as String, ByVal pKey as String, ByVal pValue as String, ByVal inipath as String)
        Dim a as Long
        a = WritePrivateProfileString(pHeader, pKey, pValue, inipath)
    End Sub

    Function GetMaxByMask(ByVal Cn as OleDb.OleDbConnection, ByVal pTab as String, ByVal pFld as String, ByVal pMask as String, ByVal pCount as Integer, Optional ByVal whereC as String = "") as String
        Dim pVal as Integer = 0
        Dim pwhere as String = ""
        Dim pStr as String = ""
        Dim i as Integer = 0
        Dim cm as OleDb.OleDbCommand
        Dim rsCount as OleDb.OleDbDataReader
        pwhere = pMask & ""
        For i = 1 To pCount
            pwhere = pwhere & "_"
        Next
        If whereC <> "" Then whereC = " and " & whereC
        cm = New OleDb.OleDbCommand("select max(" & pFld & ") as fld from " & pTab & " where " & pFld & " like '" & pwhere & "' " & whereC, Cn)
        rsCount = cm.ExecuteReader
        pStr = ""
        If rsCount.HasRows Then
            rsCount.Read()
            pVal = 0
            For i = Len(rsCount("fld").ToString) To 1 Step -1
                If pVal < pCount Then
                    If IsNumeric(Mid(rsCount("fld").ToString, i, 1)) Then
                        pVal = pVal + 1
                        pStr = Mid(rsCount("fld").ToString, i, 1) & pStr
                    Else
                        Exit For
                    End If
                End If
            Next
        Else
            pStr = 0
        End If
        rsCount.Close()
        If pStr = "" Then pStr = 0
        Dim pval2 as Double = CDbl(pStr) + 1
ReOpen:
        pStr = ""
        For i = 1 To pCount
            pStr = pStr & "0"
        Next
        If Len(CInt(pval2).ToString) > pCount Then
            pStr = pMask & Format(Mid(CInt(pval2), Len(CInt(pval2)) - (pCount - 2)), pStr)
        Else
            If pStr <> "" Then
                pStr = pMask & Format(pval2, pStr)
            Else
                pStr = pMask & pval2
            End If
        End If
        If FindData("select  " & pFld & " from " & pTab & " where " & pFld & " ='" & pStr & "'", Cn) <> "" Then
            pval2 = pval2 + 1
            GoTo ReOpen
        End If
        Return pStr
    End Function

    'FirstDayOfMonth ***************************************
    Public Function FirstDayOfMonth() as String
        Return FirstDayOfMonth_addMethod(System.DateTime.Now)
    End Function
    Public Function FirstDayOfMonth_addMethod(Value as DateTime) as DateTime
        Return Value.Date.addDays(1 - Value.Day)
    End Function
    'LastDayOfMonth *********************************************************
    Public Function LastDayOfMonth() as String
        Return LastDayOfMonth_addMethod(System.DateTime.Now)
    End Function
    Public Function LastDayOfMonth_addMethod(value as DateTime) as DateTime
        Return FirstDayOfMonth_addMethod(value).addMonths(1).addDays(-1)
    End Function
    'BeforeOnday *********************************************************
    Public Function BeforeOnday() as String
        Return System.DateTime.Now.addDays(-1).ToString("dd/MM/yyyy")
    End Function

    Function SQLDate1(ByVal datein as String) as String
        Select Case TypeDB
            Case "SQL"
                Return "Convert(datetime,'" & datein & "',102)"
            Case Else
                Return "CDaTE('" & datein & "')"
        End Select
    End Function

    Function SQLDate(ByVal str as String) as String
        Return "convert(datetime,'" & convdateSQL(str) & "',102)"
        'Select Case TypeDB
        '    Case "SQL"
        '        Return "convert(datetime,'" & convdateSQL(str) & "',102)"
        '        'Return "Convert(datetime,'" & datein & "',102)"
        '    Case Else
        '        Return "CDaTE('" & str & "')"
        'End Select
        ''SQLDate = "convert(datetime,'" & convdateSQL(str) & "',102)"
    End Function
    Function convdateSQL(ByVal datestr as String) as String  '
        Dim yy as String
        Dim mm as String
        Dim dd as String

        dd = Format((CDate(datestr).Day), "00")
        mm = Format(Month(CDate(datestr)), "00")
        yy = Year(CDate(datestr))
        If Len(yy) = 2 Then
            yy = CDbl(yy) + 2000
        End If
        If CDbl(yy) > 2500 Then
            yy = CDbl(yy) - 543
        End If
        datestr = yy & "/" & mm & "/" & dd
        convdateSQL = datestr
    End Function
    Function LetDate(ByVal datestr as String) as String
        Dim yy as String
        Dim mm as String
        Dim dd as String

        dd = Format((CDate(datestr).Day), "00")
        mm = Format(Month(CDate(datestr)), "00")
        yy = Year(CDate(datestr))
        If Len(yy) = 2 Then
            yy = CDbl(yy) + 2000
        End If
        If CDbl(yy) > 2500 Then
            yy = CDbl(yy) - 543
        End If
        datestr = dd & "/" & mm & "/" & yy
        Return datestr
    End Function
    Public Function ToDBDate(strDate as String)
        Try
            If IsDate(strDate) Then
                Return LetDate(strDate)
            Else
                Return "01/01/1900"
            End If
        Catch ex as Exception
            Return "01/01/1900"
        End Try
    End Function
    Public Function DBDate(strDate as String)
        Try
            Dim dDate as Date
            Dim yy as String
            Dim mm as String
            Dim dd as String

            If IsDate(strDate) Then
                dDate = CDate(strDate)
                dd = Format((CDate(strDate).Day), "00")
                mm = Format(Month(CDate(strDate)), "00")
                yy = Year(CDate(strDate))

                If dDate.Year > 1900 Then
                    strDate = dd & "/" & mm & "/" & yy
                    Return strDate
                Else
                    Return ""
                End If
            Else
                Return ""
            End If
        Catch ex as Exception
            Return ""
        End Try

    End Function
    Public Function SetDigit(ByVal Val as String) as String
        Try
            Return CDbl(Val).ToString("#,##0.00")
        Catch ex as Exception
            Return "0.00"
        End Try
    End Function
    Public Sub SetDigit(ByVal Val as MetroFramework.Controls.MetroTextBox)
        Try
            Val.Text = CDbl(Val.Text).ToString("#,##0.00")
        Catch ex as Exception
            Val.Text = "0.00"
        End Try
    End Sub
    Public Sub SetDigit4(ByVal Val as MetroFramework.Controls.MetroTextBox)
        Try
            Val.Text = CDbl(Val.Text).ToString("#,#0.0000")
        Catch ex as Exception
            Val.Text = "0.0000"
        End Try
    End Sub
    Public Function SetDigit4(ByVal Val as String) as String
        Try
            Return CDbl(Val).ToString("#,#0.0000")
        Catch ex as Exception
            Return "0.0000"
        End Try
    End Function
    Public Sub SelectTextall(ByRef obj as MetroFramework.Controls.MetroTextBox)
        obj.Selectall()
    End Sub
    Public Function CalRateamount(ByVal Base as Double, ByVal Rate as Double) as Double
        Dim ReturnDouble as Double = 0
        Dim Drate as Double = 100
        Try
            ReturnDouble = Base * (Drate + Rate) / 100
        Catch ex as Exception
            ReturnDouble = Base
        End Try
        Return ReturnDouble
    End Function
    Public Function CalExRateamt(base as Double, rate as Double) as Double
        Dim result as Double = 0
        result = base * rate
        Return result
    End Function
    Public Function TransitTime(Begindate as Date, EndDate as Date) as String
        Dim retStr = ""
        Try
            Dim offset = New Date(1, 1, 1)
            Dim dateOne = Begindate 'dtpETD.Value
            Dim dateTwo = EndDate ' dtpETa.Value
            Dim diff as TimeSpan = dateTwo - dateOne
            Dim years = (offset + diff).Year - 1
            Dim months = (dateTwo.Month - dateOne.Month) + 12 * (dateTwo.Year - dateOne.Year)
            Dim days = diff.Days
            retStr = days.ToString & " Days "
            Return retStr
        Catch ex as Exception
            Return retStr
        End Try

        'txtTransitTime.ResetText()
        'If years > 0 Then
        '    txtTransitTime.Text = years.ToString & " Year "
        'End If
        'If months > 0 Then
        '    txtTransitTime.Text &= months.ToString & " Month "
        'End If
        'If days > 0 Then
        '    txtTransitTime.Text &= days.ToString & " Days "
        'End If
    End Function
End Module
