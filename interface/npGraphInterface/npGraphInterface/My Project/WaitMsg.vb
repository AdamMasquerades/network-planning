Public Class WaitMsg
    Private Sub WaitMsg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wmTickTimes = 0
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If wmWaitForQuery = False Then
            wmTickTimes = wmTickTimes + 1
            If Label1.Visible = False Then
                Label1.Visible = True
            ElseIf Label2.Visible = False Then
                Label2.Visible = True
            ElseIf Label3.Visible = False Then
                Label3.Visible = True
            ElseIf Label4.Visible = False Then
                Label4.Visible = True
            ElseIf Label5.Visible = False Then
                Label5.Visible = True
            ElseIf Label6.Visible = False Then
                Label6.Visible = True
            ElseIf Label7.Visible = False Then
                Label7.Visible = True
            ElseIf Label8.Visible = False Then
                Label8.Visible = True
            ElseIf Label9.Visible = False Then
                Label9.Visible = True
            ElseIf Label10.Visible = False Then
                Label10.Visible = True
            ElseIf Label11.Visible = False Then
                Label11.Visible = True
            ElseIf Label12.Visible = False Then
                Label12.Visible = True
            ElseIf Label13.Visible = False Then
                Label13.Visible = True
            ElseIf Label14.Visible = False Then
                Label14.Visible = True
            ElseIf Label15.Visible = False Then
                Label15.Visible = True
            ElseIf Label15.Visible = False Then
                Label15.Visible = True
            ElseIf Label16.Visible = False Then
                Label16.Visible = True
            ElseIf Label17.Visible = False Then
                Label17.Visible = True
            ElseIf Label18.Visible = False Then
                Label18.Visible = True
            ElseIf Label19.Visible = False Then
                Label19.Visible = True
            ElseIf Label20.Visible = False Then
                Label20.Visible = True
            ElseIf Label21.Visible = False Then
                Label21.Visible = True
            ElseIf wmTickTimes = 23 Then
                Timer1.Interval = 25
                LabelWait.Text = "Done."
            ElseIf wmTickTimes = 32 Then
                Me.Dispose()
            End If
        Else
            wmTickTimes = wmTickTimes + 1
            If Label1.Visible = False Then
                Label1.Visible = True
            ElseIf Label2.Visible = False Then
                Label2.Visible = True
            ElseIf Label3.Visible = False Then
                Label3.Visible = True
            ElseIf Label4.Visible = False Then
                Label4.Visible = True
            ElseIf Label5.Visible = False Then
                Label5.Visible = True
            ElseIf Label6.Visible = False Then
                Label6.Visible = True
            ElseIf Label7.Visible = False Then
                Label7.Visible = True
            ElseIf Label8.Visible = False Then
                Label8.Visible = True
            ElseIf Label9.Visible = False Then
                Label9.Visible = True
            ElseIf Label10.Visible = False Then
                Label10.Visible = True
            ElseIf Label11.Visible = False Then
                Label11.Visible = True
            ElseIf Label12.Visible = False Then
                Label12.Visible = True
            ElseIf Label13.Visible = False Then
                Label13.Visible = True
            ElseIf Label14.Visible = False Then
                Label14.Visible = True
            ElseIf Label15.Visible = False Then
                Label15.Visible = True
            ElseIf Label15.Visible = False Then
                Label15.Visible = True
            ElseIf Label16.Visible = False Then
                Label16.Visible = True
            ElseIf Label17.Visible = False Then
                Label17.Visible = True
            ElseIf Label18.Visible = False Then
                Label18.Visible = True
            ElseIf Label19.Visible = False Then
                Label19.Visible = True
            ElseIf Label20.Visible = False Then
                Label20.Visible = True
            ElseIf Label21.Visible = False Then
                Label21.Visible = True
            ElseIf wmTickTimes = 23 Then
                Timer1.Interval = 25
                LabelWait.Text = "Done."
            ElseIf IO.File.Exists(fileName_QuerySuccess) Then
                IO.File.Delete(fileName_QuerySuccess)
                Me.Dispose()
            ElseIf wmTickTimes > wmTimeLimit Then
                Timer1.Enabled = False
                MsgBox("Failed. Time Limit Exceeded.", MsgBoxStyle.Critical, Title:="ERROR")
                Me.Dispose()
            End If
        End If
    End Sub
End Class