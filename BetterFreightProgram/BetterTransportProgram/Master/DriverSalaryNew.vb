Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class DriverSalaryNew
    Public _IsNew as Boolean
    Dim dayOfMonth(31) as Integer
    Private Sub Label6_Click(sender as Object, e as Eventargs)

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender as Object, e as PaintEventargs) Handles TableLayoutPanel1.Paint
    End Sub

    Private Sub DriverSalaryNew_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        _IsNew = True
        'Button1.BackColor = Color.Red
        'If Button1.BackColor = Color.Red Then
        '    Button1.BackColor = Color.Blue
        'Else
        '    Button1.BackColor = Color.Red
        'End If
        Dim ctrl as Control
        For Each ctrl In TableLayoutPanel1.Controls


            'If (ctrl.GetType() Is GetType(Button)) Then
            '    ctrl.BackColor = Color.Blue

            'Else
            ctrl.BackColor = Color.Fromargb(0, 255, 174)
            ctrl.ForeColor = Color.Black

            'End If
        Next
        Dim D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11, D12, D13, D14, D15, D16, D17, D18, D19, D20, D21, D22, D23, D24, D25, D26, D27, D28, D29, D30, D31 as Integer
        SetDigitDiver()
    End Sub

    Private Sub test()

        Dim func as String = ""
        For index as Integer = 0 To dayOfMonth.Length - 2

            dayOfMonth(index) = 1

            Dim a as String = " 
            Private Sub Button" & (index + 1) & "_Click(sender as Object, e as Eventargs) Handles Button" & (index + 1) & ".Click
                If Button" & (index + 1) & ".BackColor = Color.Red Then
                    Button" & (index + 1) & ".BackColor = Color.Fromargb(0, 255, 174)
                    Button" & (index + 1) & ".ForeColor = Color.Black
                    dayOfMonth(" & (index) & ") = 0
                Else
                    Button" & (index + 1) & ".BackColor = Color.Red
                    Button" & (index + 1) & ".ForeColor = Color.White
                    dayOfMonth(" & (index) & ") = 1
                End If
            End Sub
            "
            func = func & a
        Next

        txtDriverIdent.Text = func


    End Sub

    Private Sub addabsence()
        Dim absence as Integer = 0
        Dim DailyRate as Double = 0
        Dim Totalabsence as Double = 0
        For index as Integer = 0 To dayOfMonth.Length - 2
            If dayOfMonth(index) = 1 Then
                absence += 1
            End If
            If CDbl(txtSalary.Text) > 0 Then
                DailyRate = CDbl(txtSalary.Text) / 30
            End If

            Totalabsence = absence * DailyRate
            txtabsence.Text = Totalabsence
        Next
    End Sub

    Private Sub SelectFuelDiff()
        Dim dr as DataRow
        Dim sqlstr as String = "SELECT isnull(SUM(RoutePrice),0) aS FuelDiff FROM Driver where Driver='" & txtDriver.Text & "'and MONTH(arriveTruckYardDate)='" & txtSalaryMonth.Text & "'"
        dr = SelectSingleRow(sqlstr)
        If dr IsNot Nothing Then
            'If _IsNew = True Then
            txtFuelGiven.Text = CDbl(dr("FuelDiff")).ToString
            'End If
            Dim ctrl as Control
            For Each ctrl In TableLayoutPanel1.Controls
                ctrl.BackColor = Color.Fromargb(0, 255, 174)
                ctrl.ForeColor = Color.Black
            Next
        End If
        'If Not IsNothing(dr) Then
        '    If _IsNew = True Then
        '        txtFuelDiff.Text = CDbl(dr("RoundPrice")).ToString
        '    End If
        'End If
    End Sub

    Private Sub SelectRoundPrice()
        Dim dr as DataRow
        Dim sqlstr as String = "SELECT isnull(SUM(UnitPrice),0) as UnitPrice FROM Driver where Driver='" & txtDriver.Text & "'and MONTH(arriveTruckYardDate)='" & txtSalaryMonth.Text & "'"
        dr = SelectSingleRow(sqlstr)
        If dr IsNot Nothing Then
            'If _IsNew = True Then
            txtRoundPrice.Text = CDbl(dr("UnitPrice")).ToString
            'End If
            Dim ctrl as Control
            For Each ctrl In TableLayoutPanel1.Controls
                ctrl.BackColor = Color.Fromargb(0, 255, 174)
                ctrl.ForeColor = Color.Black
            Next
        End If
        'If Not IsNothing(dr) Then
        '    If _IsNew = True Then
        '        txtFuelDiff.Text = CDbl(dr("RoundPrice")).ToString
        '    End If
        'End If
    End Sub

    Private Sub Button1_Click(sender as Object, e as Eventargs) Handles Button1.Click
        If Button1.BackColor = Color.Red Then
            Button1.BackColor = Color.Fromargb(0, 255, 174)
            Button1.ForeColor = Color.Black
            dayOfMonth(0) = 0
        Else
            Button1.BackColor = Color.Red
            Button1.ForeColor = Color.White
            dayOfMonth(0) = 1
        End If
        addabsence()

    End Sub

    Private Sub Button2_Click(sender as Object, e as Eventargs) Handles Button2.Click
        If Button2.BackColor = Color.Red Then
            Button2.BackColor = Color.Fromargb(0, 255, 174)
            Button2.ForeColor = Color.Black
            dayOfMonth(1) = 0
        Else
            Button2.BackColor = Color.Red
            Button2.ForeColor = Color.White
            dayOfMonth(1) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button3_Click(sender as Object, e as Eventargs) Handles Button3.Click
        If Button3.BackColor = Color.Red Then
            Button3.BackColor = Color.Fromargb(0, 255, 174)
            Button3.ForeColor = Color.Black
            dayOfMonth(2) = 0
        Else
            Button3.BackColor = Color.Red
            Button3.ForeColor = Color.White
            dayOfMonth(2) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button4_Click(sender as Object, e as Eventargs) Handles Button4.Click
        If Button4.BackColor = Color.Red Then
            Button4.BackColor = Color.Fromargb(0, 255, 174)
            Button4.ForeColor = Color.Black
            dayOfMonth(3) = 0
        Else
            Button4.BackColor = Color.Red
            Button4.ForeColor = Color.White
            dayOfMonth(3) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button5_Click(sender as Object, e as Eventargs) Handles Button5.Click
        If Button5.BackColor = Color.Red Then
            Button5.BackColor = Color.Fromargb(0, 255, 174)
            Button5.ForeColor = Color.Black
            dayOfMonth(4) = 0
        Else
            Button5.BackColor = Color.Red
            Button5.ForeColor = Color.White
            dayOfMonth(4) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button6_Click(sender as Object, e as Eventargs) Handles Button6.Click
        If Button6.BackColor = Color.Red Then
            Button6.BackColor = Color.Fromargb(0, 255, 174)
            Button6.ForeColor = Color.Black
            dayOfMonth(5) = 0
        Else
            Button6.BackColor = Color.Red
            Button6.ForeColor = Color.White
            dayOfMonth(5) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button7_Click(sender as Object, e as Eventargs) Handles Button7.Click
        If Button7.BackColor = Color.Red Then
            Button7.BackColor = Color.Fromargb(0, 255, 174)
            Button7.ForeColor = Color.Black
            dayOfMonth(6) = 0
        Else
            Button7.BackColor = Color.Red
            Button7.ForeColor = Color.White
            dayOfMonth(6) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button8_Click(sender as Object, e as Eventargs) Handles Button8.Click
        If Button8.BackColor = Color.Red Then
            Button8.BackColor = Color.Fromargb(0, 255, 174)
            Button8.ForeColor = Color.Black
            dayOfMonth(7) = 0
        Else
            Button8.BackColor = Color.Red
            Button8.ForeColor = Color.White
            dayOfMonth(7) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button9_Click(sender as Object, e as Eventargs) Handles Button9.Click
        If Button9.BackColor = Color.Red Then
            Button9.BackColor = Color.Fromargb(0, 255, 174)
            Button9.ForeColor = Color.Black
            dayOfMonth(8) = 0
        Else
            Button9.BackColor = Color.Red
            Button9.ForeColor = Color.White
            dayOfMonth(8) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button10_Click(sender as Object, e as Eventargs) Handles Button10.Click
        If Button10.BackColor = Color.Red Then
            Button10.BackColor = Color.Fromargb(0, 255, 174)
            Button10.ForeColor = Color.Black
            dayOfMonth(9) = 0
        Else
            Button10.BackColor = Color.Red
            Button10.ForeColor = Color.White
            dayOfMonth(9) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button11_Click(sender as Object, e as Eventargs) Handles Button11.Click
        If Button11.BackColor = Color.Red Then
            Button11.BackColor = Color.Fromargb(0, 255, 174)
            Button11.ForeColor = Color.Black
            dayOfMonth(10) = 0
        Else
            Button11.BackColor = Color.Red
            Button11.ForeColor = Color.White
            dayOfMonth(10) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button12_Click(sender as Object, e as Eventargs) Handles Button12.Click
        If Button12.BackColor = Color.Red Then
            Button12.BackColor = Color.Fromargb(0, 255, 174)
            Button12.ForeColor = Color.Black
            dayOfMonth(11) = 0
        Else
            Button12.BackColor = Color.Red
            Button12.ForeColor = Color.White
            dayOfMonth(11) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button13_Click(sender as Object, e as Eventargs) Handles Button13.Click
        If Button13.BackColor = Color.Red Then
            Button13.BackColor = Color.Fromargb(0, 255, 174)
            Button13.ForeColor = Color.Black
            dayOfMonth(12) = 0
        Else
            Button13.BackColor = Color.Red
            Button13.ForeColor = Color.White
            dayOfMonth(12) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button14_Click(sender as Object, e as Eventargs) Handles Button14.Click
        If Button14.BackColor = Color.Red Then
            Button14.BackColor = Color.Fromargb(0, 255, 174)
            Button14.ForeColor = Color.Black
            dayOfMonth(13) = 0
        Else
            Button14.BackColor = Color.Red
            Button14.ForeColor = Color.White
            dayOfMonth(13) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button15_Click(sender as Object, e as Eventargs) Handles Button15.Click
        If Button15.BackColor = Color.Red Then
            Button15.BackColor = Color.Fromargb(0, 255, 174)
            Button15.ForeColor = Color.Black
            dayOfMonth(14) = 0
        Else
            Button15.BackColor = Color.Red
            Button15.ForeColor = Color.White
            dayOfMonth(14) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button16_Click(sender as Object, e as Eventargs) Handles Button16.Click
        If Button16.BackColor = Color.Red Then
            Button16.BackColor = Color.Fromargb(0, 255, 174)
            Button16.ForeColor = Color.Black
            dayOfMonth(15) = 0
        Else
            Button16.BackColor = Color.Red
            Button16.ForeColor = Color.White
            dayOfMonth(15) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button17_Click(sender as Object, e as Eventargs) Handles Button17.Click
        If Button17.BackColor = Color.Red Then
            Button17.BackColor = Color.Fromargb(0, 255, 174)
            Button17.ForeColor = Color.Black
            dayOfMonth(16) = 0
        Else
            Button17.BackColor = Color.Red
            Button17.ForeColor = Color.White
            dayOfMonth(16) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button18_Click(sender as Object, e as Eventargs) Handles Button18.Click
        If Button18.BackColor = Color.Red Then
            Button18.BackColor = Color.Fromargb(0, 255, 174)
            Button18.ForeColor = Color.Black
            dayOfMonth(17) = 0
        Else
            Button18.BackColor = Color.Red
            Button18.ForeColor = Color.White
            dayOfMonth(17) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button19_Click(sender as Object, e as Eventargs) Handles Button19.Click
        If Button19.BackColor = Color.Red Then
            Button19.BackColor = Color.Fromargb(0, 255, 174)
            Button19.ForeColor = Color.Black
            dayOfMonth(18) = 0
        Else
            Button19.BackColor = Color.Red
            Button19.ForeColor = Color.White
            dayOfMonth(18) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button20_Click(sender as Object, e as Eventargs) Handles Button20.Click
        If Button20.BackColor = Color.Red Then
            Button20.BackColor = Color.Fromargb(0, 255, 174)
            Button20.ForeColor = Color.Black
            dayOfMonth(19) = 0
        Else
            Button20.BackColor = Color.Red
            Button20.ForeColor = Color.White
            dayOfMonth(19) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button21_Click(sender as Object, e as Eventargs) Handles Button21.Click
        If Button21.BackColor = Color.Red Then
            Button21.BackColor = Color.Fromargb(0, 255, 174)
            Button21.ForeColor = Color.Black
            dayOfMonth(20) = 0
        Else
            Button21.BackColor = Color.Red
            Button21.ForeColor = Color.White
            dayOfMonth(20) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button22_Click(sender as Object, e as Eventargs) Handles Button22.Click
        If Button22.BackColor = Color.Red Then
            Button22.BackColor = Color.Fromargb(0, 255, 174)
            Button22.ForeColor = Color.Black
            dayOfMonth(21) = 0
        Else
            Button22.BackColor = Color.Red
            Button22.ForeColor = Color.White
            dayOfMonth(21) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button23_Click(sender as Object, e as Eventargs) Handles Button23.Click
        If Button23.BackColor = Color.Red Then
            Button23.BackColor = Color.Fromargb(0, 255, 174)
            Button23.ForeColor = Color.Black
            dayOfMonth(22) = 0
        Else
            Button23.BackColor = Color.Red
            Button23.ForeColor = Color.White
            dayOfMonth(22) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button24_Click(sender as Object, e as Eventargs) Handles Button24.Click
        If Button24.BackColor = Color.Red Then
            Button24.BackColor = Color.Fromargb(0, 255, 174)
            Button24.ForeColor = Color.Black
            dayOfMonth(23) = 0
        Else
            Button24.BackColor = Color.Red
            Button24.ForeColor = Color.White
            dayOfMonth(23) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button25_Click(sender as Object, e as Eventargs) Handles Button25.Click
        If Button25.BackColor = Color.Red Then
            Button25.BackColor = Color.Fromargb(0, 255, 174)
            Button25.ForeColor = Color.Black
            dayOfMonth(24) = 0
        Else
            Button25.BackColor = Color.Red
            Button25.ForeColor = Color.White
            dayOfMonth(24) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button26_Click(sender as Object, e as Eventargs) Handles Button26.Click
        If Button26.BackColor = Color.Red Then
            Button26.BackColor = Color.Fromargb(0, 255, 174)
            Button26.ForeColor = Color.Black
            dayOfMonth(25) = 0
        Else
            Button26.BackColor = Color.Red
            Button26.ForeColor = Color.White
            dayOfMonth(25) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button27_Click(sender as Object, e as Eventargs) Handles Button27.Click
        If Button27.BackColor = Color.Red Then
            Button27.BackColor = Color.Fromargb(0, 255, 174)
            Button27.ForeColor = Color.Black
            dayOfMonth(26) = 0
        Else
            Button27.BackColor = Color.Red
            Button27.ForeColor = Color.White
            dayOfMonth(26) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button28_Click(sender as Object, e as Eventargs) Handles Button28.Click
        If Button28.BackColor = Color.Red Then
            Button28.BackColor = Color.Fromargb(0, 255, 174)
            Button28.ForeColor = Color.Black
            dayOfMonth(27) = 0
        Else
            Button28.BackColor = Color.Red
            Button28.ForeColor = Color.White
            dayOfMonth(27) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button29_Click(sender as Object, e as Eventargs) Handles Button29.Click
        If Button29.BackColor = Color.Red Then
            Button29.BackColor = Color.Fromargb(0, 255, 174)
            Button29.ForeColor = Color.Black
            dayOfMonth(28) = 0
        Else
            Button29.BackColor = Color.Red
            Button29.ForeColor = Color.White
            dayOfMonth(28) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button30_Click(sender as Object, e as Eventargs) Handles Button30.Click
        If Button30.BackColor = Color.Red Then
            Button30.BackColor = Color.Fromargb(0, 255, 174)
            Button30.ForeColor = Color.Black
            dayOfMonth(29) = 0
        Else
            Button30.BackColor = Color.Red
            Button30.ForeColor = Color.White
            dayOfMonth(29) = 1
        End If
        addabsence()
    End Sub

    Private Sub Button31_Click(sender as Object, e as Eventargs) Handles Button31.Click
        If Button31.BackColor = Color.Red Then
            Button31.BackColor = Color.Fromargb(0, 255, 174)
            Button31.ForeColor = Color.Black
            dayOfMonth(30) = 0
        Else
            Button31.BackColor = Color.Red
            Button31.ForeColor = Color.White
            dayOfMonth(30) = 1
        End If
        addabsence()
    End Sub
    Private Sub cmdSave_Click(sender as Object, e as Eventargs) Handles cmdSave.Click
        Dim Month as Integer = 0
        Dim Year as Integer = 0
        Try
            Month = CInt(txtSalaryMonth.Text)
            Year = CInt(txtSalaryYear.Text)
        Catch ex as Exception
            MsgBox("ERROR")
            Exit Sub
        End Try
        If Month >= 1 and Month < 13 Then
            If Year >= 2023 and Year < 2123 Then
                If _IsNew = True Then
                    SaveData(1)
                Else
                    SaveData(0)
                End If
            Else
                MsgBox("Pls Input correct Year format")
                Exit Sub
            End If
        Else
            MsgBox("Pls Input correct Month format")
            Exit Sub
        End If
    End Sub

    Private Sub SaveData(_insert as Integer)
        Try

            Dim nection as OleDb.OleDbConnection = New OleDb.OleDbConnection()
            nection = ConnectDB()
            Dim SQLcommand as StringBuilder = New StringBuilder("exec sp_lnsertOrupdateDriverSalary ")
            SQLcommand.append("'" & txtIdent.Text & "'") 'Ident
            SQLcommand.append(",'" & txtDriverIdent.Text & "'") 'DriverIdent
            SQLcommand.append(",'" & txtDriver.Text & "'") 'Driver
            SQLcommand.append(",'" & CDbl(txtSalary.Text) & "'") 'Salary
            SQLcommand.append(",'" & CDbl(txtSSO.Text) & "'") 'SSO
            SQLcommand.append(",'" & CDbl(txtInsurance30k.Text) & "'") 'Insurance30k
            SQLcommand.append(",'" & CDbl(txtabsence.Text) & "'") 'absence
            SQLcommand.append(",'" & CDbl(txtLoan.Text) & "'") 'Loan
            SQLcommand.append(",'" & CDbl(txtincentive1.Text) & "'") 'incentive1
            SQLcommand.append(",'" & CDbl(txtincentive2.Text) & "'") 'incentive2
            SQLcommand.append(",'" & CDbl(txtTotal.Text) & "'") 'Total
            SQLcommand.append(",'" & CDbl(txtSalaryNet.Text) & "'")
            For index as Integer = 0 To dayOfMonth.Length - 2
                SQLcommand.append(",'" & CInt(dayOfMonth(index)) & "'") 'd1-d31
            Next
            SQLcommand.append(",'" & CDate(dtpSalaryDate.Value) & "'") 'SalaryDate
            SQLcommand.append(",'" & txtSalaryMonth.Text & "'") 'SalaryMonth
            SQLcommand.append(",'" & txtSalaryYear.Text & "'") 'SalaryYear
            SQLcommand.append(",'" & CDbl(txtInsuranceCut.Text) & "'")
            SQLcommand.append(",'" & CDbl(txtRoundPrice.Text) & "'")
            SQLcommand.append(",'" & CDbl(txtFuelDiff.Text) & "'")
            SQLcommand.append(",'" & CDbl(txtFuelGiven.Text) & "'")
            SQLcommand.append(",'" & CDbl(txtFuelUsed.Text) & "'")
            SQLcommand.append(",'" & CDbl(txtBills.Text) & "'")
            SQLcommand.append(",'" & txtTruckNo.Text & "'")
            SQLcommand.append(",'" & txtHeadNo.Text & "'")
            SQLcommand.append(",'" & _insert & "'") '//Insert Or Update
            Dim result as Integer = ExecuteNonQuery(SQLcommand.ToString(), nection)
            If result = 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Success ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _IsNew = False
            Else
                MetroFramework.MetroMessageBox.Show(Me, "Save Data Fail ", "Save Data Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            nection.Close()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub addData()
        Dim Salary as Double = 0
        Dim SSO as Double = 0
        Dim Insurance30k as Double = 0
        Dim InsuranceCut as Double = 0
        Dim absence as Double = 0
        Dim Loan as Double = 0
        Dim Insentive1 as Double = 0
        Dim Insentive2 as Double = 0
        Dim RoundPrice as Double = 0
        Dim FuelDiff as Double = 0
        Dim Total as Double = 0
        Dim Net as Double = 0
        Dim Bill as Double = 0
        Dim FuelGiven as Double = 0
        Dim FUelUsed as Double = 0
        If txtSalary.Text = "" Or txtSalary.Text = "-" Then
            Exit Sub
        ElseIf txtSSO.Text = "" Or txtSSO.Text = "-" Then
            Exit Sub
        ElseIf txtInsurance30k.Text = "" Or txtInsurance30k.Text = "-" Then
            Exit Sub
        ElseIf txtInsuranceCut.Text = "" Or txtInsuranceCut.Text = "-" Then
            Exit Sub
        ElseIf txtabsence.Text = "" Or txtabsence.Text = "-" Then
            Exit Sub
        ElseIf txtLoan.Text = "" Or txtLoan.Text = "-" Then
            Exit Sub
        ElseIf txtincentive1.Text = "" Or txtincentive1.Text = "-" Then
            Exit Sub
        ElseIf txtincentive2.Text = "" Or txtincentive2.Text = "-" Then
            Exit Sub
        ElseIf txtRoundPrice.Text = "" Or txtRoundPrice.Text = "-" Then
            Exit Sub
        ElseIf txtFuelDiff.Text = "" Or txtFuelDiff.Text = "-" Then
            Exit Sub
        ElseIf txtBills.Text = "" Or txtBills.Text = "-" Then
            Exit Sub
        Else
            'SetDigitDiver()
            Salary = txtSalary.Text
            SSO = txtSSO.Text
            Insurance30k = txtInsurance30k.Text
            InsuranceCut = txtInsuranceCut.Text
            absence = txtabsence.Text
            Loan = txtLoan.Text
            Insentive1 = txtincentive1.Text
            Insentive2 = txtincentive2.Text
            RoundPrice = txtRoundPrice.Text
            FuelDiff = txtFuelDiff.Text
            Bill = txtBills.Text
            FuelGiven = txtFuelGiven.Text
            FUelUsed = txtFuelUsed.Text
            FuelDiff = FuelGiven - FUelUsed
            txtFuelDiff.Text = FuelDiff.ToString("#,##0.00")
            Total = (Salary - SSO - InsuranceCut - absence - Loan - Bill) + Insentive1 + Insentive2 '+ FuelDiff
            txtTotal.Text = Total.ToString("#,##0.00")
            Net = Salary + Insentive1 + Insentive2 + FuelDiff + RoundPrice
            txtSalaryNet.Text = Net.ToString("#,##0.00")
        End If
    End Sub

    Private Sub txtDriver_ButtonClick(sender as Object, e as Eventargs) Handles txtDriver.ButtonClick
        Dim dr as DataRow
        dr = PopUpSearch("SELECT [DriverName], [DriverTruckPlate], [DriverTruckNo], Salary, Insurance30k, ident  FROM [Mas_Driver] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtDriver.Text = dr("DriverName").ToString
            txtDriverIdent.Text = dr("Ident").ToString
            txtTruckNo.Text = dr("DriverTruckNo").ToString
            txtHeadNo.Text = dr("DriverTruckPlate").ToString
            txtSalary.Text = dr("Salary").ToString
            txtInsurance30k.Text = dr("Insurance30k").ToString
            SelectFuelDiff()
            SelectRoundPrice()
        End If
        SetDigitDiver()
    End Sub
    Private Sub SetDigitDiver()
        SetDigit(txtSalary)
        SetDigit(txtSSO)
        SetDigit(txtInsurance30k)
        SetDigit(txtabsence)
        SetDigit(txtLoan)
        SetDigit(txtincentive1)
        SetDigit(txtincentive2)
        SetDigit(txtTotal)
        SetDigit(txtSalaryNet)

        'SetDigit(txtSalaryMonth)
        'SetDigit(txtSalaryYear) 
        SetDigit(txtInsuranceCut)
        SetDigit(txtRoundPrice)
        SetDigit(txtFuelDiff)
        SetDigit(txtFuelGiven)
        SetDigit(txtFuelUsed)
        'Reset Style

    End Sub
    Private Sub txtSalaryMonth_TextChanged(sender as Object, e as Eventargs) Handles txtSalaryMonth.TextChanged

    End Sub
    Private Sub txtSalaryMonth_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtSalaryMonth.KeyPress
        CheckNumeric(e)
    End Sub
    Private Sub txtSalaryYear_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtSalaryYear.KeyPress
        CheckNumeric(e)
    End Sub
    Private Sub txtSalary_TextChanged(sender as Object, e as Eventargs) Handles txtSalary.TextChanged
        addData()
    End Sub
    Private Sub txtSSO_TextChanged(sender as Object, e as Eventargs) Handles txtSSO.TextChanged
        addData()
    End Sub
    Private Sub txtInsurance30k_TextChanged(sender as Object, e as Eventargs) Handles txtInsurance30k.TextChanged
        addData()
    End Sub
    Private Sub txtInsuranceCut_TextChanged(sender as Object, e as Eventargs) Handles txtInsuranceCut.TextChanged
        addData()
    End Sub
    Private Sub txtabsence_TextChanged(sender as Object, e as Eventargs) Handles txtabsence.TextChanged
        addData()
    End Sub
    Private Sub txtLoan_TextChanged(sender as Object, e as Eventargs) Handles txtLoan.TextChanged
        addData()
    End Sub
    Private Sub txtincentive1_TextChanged(sender as Object, e as Eventargs) Handles txtincentive1.TextChanged
        addData()
    End Sub
    Private Sub txtincentive2_TextChanged(sender as Object, e as Eventargs) Handles txtincentive2.TextChanged
        addData()
    End Sub
    Private Sub txtRoundPrice_TextChanged(sender as Object, e as Eventargs) Handles txtRoundPrice.TextChanged
        addData()
    End Sub
    Private Sub txtFuelDiff_TextChanged(sender as Object, e as Eventargs) Handles txtFuelDiff.TextChanged
        addData()
    End Sub
    Private Sub txtTotal_TextChanged(sender as Object, e as Eventargs) Handles txtTotal.TextChanged
        addData()
    End Sub
    Private Sub txtSalaryNet_TextChanged(sender as Object, e as Eventargs) Handles txtSalaryNet.TextChanged
        addData()
    End Sub
    Private Sub txtFuelGiven_TextChanged(sender as Object, e as Eventargs) Handles txtFuelGiven.TextChanged
        addData()
    End Sub
    Private Sub txtFuelUsed_TextChanged(sender as Object, e as Eventargs) Handles txtFuelUsed.TextChanged
        addData()
    End Sub
    Private Sub txtSalary_KeyPress(sender as Object, e as KeyPressEventargs) Handles txtTotal.KeyPress, txtSSO.KeyPress, txtSalaryNet.KeyPress, txtSalary.KeyPress, txtRoundPrice.KeyPress, txtLoan.KeyPress, txtInsuranceCut.KeyPress, txtInsurance30k.KeyPress, txtincentive2.KeyPress, txtincentive1.KeyPress, txtFuelUsed.KeyPress, txtFuelGiven.KeyPress, txtFuelDiff.KeyPress, txtabsence.KeyPress
        CheckDouble(e)
        If e.KeyChar = Chr(Keys.Enter) Then
            SetDigit(sender)
        End If
    End Sub
    Private Sub txtSalary_Leave(sender as Object, e as Eventargs) Handles txtTotal.Leave, txtSSO.Leave, txtSalaryNet.Leave, txtSalary.Leave, txtRoundPrice.Leave, txtLoan.Leave, txtInsuranceCut.Leave, txtInsurance30k.Leave, txtincentive2.Leave, txtincentive1.Leave, txtFuelUsed.Leave, txtFuelGiven.Leave, txtFuelDiff.Leave, txtabsence.Leave
        SetDigit(sender)
    End Sub
    Private Sub txtBills_TextChanged(sender as Object, e as Eventargs) Handles txtBills.TextChanged
        addData()
    End Sub
    Private Sub txtSearch_Click(sender as Object, e as Eventargs) Handles txtSearch.Click
        Dim dr as DataRow
        dr = PopUpSearch("SELECT * FROM [DriverSalary] WHERE 1=1", MainConnection)
        If isSearchOK Then
            txtIdent.Text = dr("Ident").ToString
            txtDriverIdent.Text = dr("DriverIdent").ToString
            txtDriver.Text = dr("Driver").ToString
            txtDriverIdent.Text = dr("DriverIdent").ToString
            txtSalary.Text = dr("Salary").ToString
            txtSSO.Text = dr("SSO").ToString
            txtInsurance30k.Text = dr("Insurance30k").ToString
            txtInsuranceCut.Text = dr("InsuranceCut").ToString
            txtabsence.Text = dr("absence").ToString
            txtLoan.Text = dr("Loan").ToString
            txtBills.Text = dr("Bills").ToString
            txtincentive1.Text = dr("incentive1").ToString
            txtincentive2.Text = dr("incentive2").ToString
            txtFuelDiff.Text = dr("FuelDIff").ToString
            txtTotal.Text = dr("Total").ToString
            txtRoundPrice.Text = dr("RoundPrice").ToString
            txtFuelGiven.Text = dr("FuelGiven").ToString
            txtFuelUsed.Text = dr("FuelUsed").ToString
            txtSalaryNet.Text = dr("SalaryNet").ToString
            txtSalaryMonth.Text = dr("SalaryMonth").ToString
            txtSalaryYear.Text = dr("SalaryYear").ToString
            txtTruckNo.Text = dr("TruckNo").ToString
            txtHeadNo.Text = dr("HeadNo").ToString
            _IsNew = False
            LoadTruckData()
            Dim ctrl as Control
            For Each ctrl In TableLayoutPanel1.Controls
                ctrl.BackColor = Color.Fromargb(0, 255, 174)
                ctrl.ForeColor = Color.Black
            Next
            For index as Integer = 0 To dayOfMonth.Length - 2
                dayOfMonth(index) = dr("d" & (index + 1)).ToString()
                If dr("d" & (index + 1)).ToString() = "1" Then
                    Select Case (index + 1)
                        Case 1
                            Button1_Click(sender, e)
                        Case 2
                            Button2_Click(sender, e)
                        Case 3
                            Button3_Click(sender, e)
                        Case 4
                            Button4_Click(sender, e)
                        Case 5
                            Button5_Click(sender, e)
                        Case 6
                            Button6_Click(sender, e)
                        Case 7
                            Button7_Click(sender, e)
                        Case 8
                            Button8_Click(sender, e)
                        Case 9
                            Button9_Click(sender, e)
                        Case 10
                            Button10_Click(sender, e)
                        Case 11
                            Button11_Click(sender, e)
                        Case 12
                            Button12_Click(sender, e)
                        Case 13
                            Button13_Click(sender, e)
                        Case 14
                            Button14_Click(sender, e)
                        Case 15
                            Button15_Click(sender, e)
                        Case 16
                            Button16_Click(sender, e)
                        Case 17
                            Button17_Click(sender, e)
                        Case 18
                            Button18_Click(sender, e)
                        Case 19
                            Button19_Click(sender, e)
                        Case 20
                            Button20_Click(sender, e)
                        Case 21
                            Button21_Click(sender, e)
                        Case 22
                            Button22_Click(sender, e)
                        Case 23
                            Button23_Click(sender, e)
                        Case 24
                            Button24_Click(sender, e)
                        Case 25
                            Button25_Click(sender, e)
                        Case 26
                            Button26_Click(sender, e)
                        Case 27
                            Button27_Click(sender, e)
                        Case 28
                            Button28_Click(sender, e)
                        Case 29
                            Button29_Click(sender, e)
                        Case 30
                            Button30_Click(sender, e)
                        Case 31
                            Button31_Click(sender, e)
                    End Select
                Else
                End If
            Next
        End If
    End Sub
    Private Sub LoadTruckData()
        Try
            Dim dr as DataRow
            Dim sqlstr as String = "SELECT DriverTruckNo,DriverTruckPlateNo FROM [Mas_Driver] where ident='" & txtDriverIdent.Text & "'"
            dr = SelectSingleRow(sqlstr)
            If Not IsNothing(dr) Then
                txtHeadNo.Text = dr("DriverTruckPlateNo").ToString
                txtTruckNo.Text = dr("DriverTruckNo").ToString
            End If
            'New for Test
            'Load for Test
            'addDataToInv()
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
End Class