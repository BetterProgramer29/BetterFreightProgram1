Imports System.Data.OleDb

Public Class Forma
    Private Sub Forma_Load(sender as Object, e as Eventargs) Handles MyBase.Load
        LoadDataDgv()
    End Sub
    Private Sub LoadDataDgv()
        Try
            MetroGrid1.Rows.Clear()
            Dim da as OleDb.OleDbDataadapter = New OleDb.OleDbDataadapter()
            Dim dt as DataTable = New DataTable()
            Dim nection as New OleDb.OleDbConnection()
            nection = ConnectDB()

            Dim str as String = "




SELECT *
,CaSE WHEN aDVPaYMENTED -(aTK+CTK)<=0 THEN aBS(aDVPaYMENTED-(aTK+CTK)) ELSE 0 END aS PaY
,CaSE WHEN aDVPaYMENTED -(aTK+CTK)>=0 THEN aDVPaYMENTED-(aTK+CTK) ELSE 0 END aS REFUND
FROM (
SELECT OrderNo
,ISNULL((SELECT sum(V_advanceRequestDetail.Chargeamount+V_advanceRequestDetail.advamount) 
FROM V_advanceRequestDetail 
WHERE V_advanceRequestDetail.OrderNo = Driver.OrderNo aND ISNULL(Driver.OrderNo,'')<>'' aND V_advanceRequestDetail.active=1  
),0) aS aDV
,ISNULL((SELECT sum(CaSE WHEN ISNULL(V_advanceRequestDetail.DocumentNo,'')<>'' THEN V_advanceRequestDetail.Chargeamount+V_advanceRequestDetail.advamount ELSE 0 END) 
FROM V_advanceRequestDetail 
WHERE V_advanceRequestDetail.OrderNo = Driver.OrderNo aND ISNULL(Driver.OrderNo,'')<>'' aND V_advanceRequestDetail.active=1  
),0) aS aDVPaYMENTED
,ISNULL((SELECT sum(TRY_CONVERT(FLOaT,aDV.amount )) 
FROM aDV where [advCode] LIKE '%aTK%'  aND aDV.OrderNo = Driver.OrderNo aND ISNULL(Driver.OrderNo,'')<>'' aND aDV.active=1  
),0) aS aTK
,ISNULL((SELECT sum(TRY_CONVERT(FLOaT,aDV.amount )) 
FROM aDV where [advCode] LIKE '%CTK%'  aND aDV.OrderNo = Driver.OrderNo aND ISNULL(Driver.OrderNo,'')<>'' aND aDV.active=1  
),0)  aS CTK
FROM Driver WHERE Driver.active=1 
) a"
            da.SelectCommand = New OleDbCommand(str, nection)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i as Integer = 0 To dt.Rows.Count - 1
                    MetroGrid1.Rows.add(dt.Rows(i)(0).ToString(), 'ident
                           dt.Rows(i)(1).ToString(),  'Code
                           dt.Rows(i)(2).ToString(),  'ContainerStatus
                           dt.Rows(i)(3).ToString(),  'advancePayment
                           dt.Rows(i)(4).ToString(),  'TruckNo
                           dt.Rows(i)(5).ToString(),  'Withdrawalamount
                           dt.Rows(i)(6).ToString()  'advanceNo
)
                    'dt.Rows(i)(39).ToString()
                Next
                da = Nothing
                dt = Nothing
                nection.Close()
            End If
        Catch ex as Exception
            MetroFramework.MetroMessageBox.Show(Me, "Error " & ex.Message, " " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub SUMaMT()
        Dim amt as Double = 0
        Dim amt1 as Double = 0
        If MetroGrid1.Rows.Count > 0 Then
            For i as Integer = 0 To MetroGrid1.Rows.Count - 1
                If MetroGrid1.Rows(i).Cells(7).Value = "1" Then
                    amt += MetroGrid1.Rows(i).Cells(5).Value
                    amt1 += MetroGrid1.Rows(i).Cells(6).Value

                End If
                'amt += dgvadvDetail.Rows(i).Cells(9).Value
            Next
            MetroTextBox1.Text = amt.ToString("#,##0.00")
            MetroTextBox2.Text = amt1.ToString("#,##0.00")
            MetroTextBox3.Text = amt - amt1
        Else
            MetroTextBox1.Text = amt.ToString("#,##0.00")
            MetroTextBox2.Text = amt1.ToString("#,##0.00")
            MetroTextBox3.Text = amt - amt1
        End If
    End Sub

    Private Sub MetroButton1_Click(sender as Object, e as Eventargs) Handles MetroButton1.Click
        SUMaMT()
    End Sub
End Class