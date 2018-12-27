Imports System.Windows.Forms
'Imports Microsoft.Office.Interop

Public Class ReadIn

    Private Sub ReadIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentItemNumber = 0
        LabelCurNumber.Text = Str(currentItemNumber)
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        Dim checkResult As String

        NameRegularize(TextBoxName.Text)
        checkResult = NameCheck(TextBoxName.Text)
        If checkResult <> "OK" Then
            MsgBox(checkResult, MsgBoxStyle.Exclamation, Title:="WARNING")
            Return
        End If

        checkResult = DurationCheck(TextBoxDuration.Text)
        If checkResult <> "OK" Then
            MsgBox(checkResult, MsgBoxStyle.Exclamation, Title:="WARNING")
            Return
        End If

        PrerequisiteRegularize(TextBoxPrereq.Text)
        checkResult = PrerequisiteCheck(TextBoxPrereq.Text, currentItemNumber)
        If checkResult <> "OK" Then
            MsgBox(checkResult, MsgBoxStyle.Exclamation, Title:="WARNING")
            Return
        End If

        currentItemNumber += 1
        LabelCurNumber.Text = Trim(Str(currentItemNumber))
        itemId(currentItemNumber) = Trim(Str(currentItemNumber))
        itemName(currentItemNumber) = Trim(TextBoxName.Text)
        itemDuration(currentItemNumber) = Trim(TextBoxDuration.Text)
        itemPrereq(currentItemNumber) = Trim(TextBoxPrereq.Text)

        itemPrereq(currentItemNumber) = itemPrereq(currentItemNumber).Replace(", ", ",")   'need a better and clearer way to converge between display text and storage.

        LabelId5.Text = LabelId4.Text
        LabelId4.Text = LabelId3.Text
        LabelId3.Text = LabelId2.Text
        LabelId2.Text = LabelId1.Text
        LabelName5.Text = LabelName4.Text
        LabelName4.Text = LabelName3.Text
        LabelName3.Text = LabelName2.Text
        LabelName2.Text = LabelName1.Text
        LabelDuration5.Text = LabelDuration4.Text
        LabelDuration4.Text = LabelDuration3.Text
        LabelDuration3.Text = LabelDuration2.Text
        LabelDuration2.Text = LabelDuration1.Text
        LabelPrereq5.Text = LabelPrereq4.Text
        LabelPrereq4.Text = LabelPrereq3.Text
        LabelPrereq3.Text = LabelPrereq2.Text
        LabelPrereq2.Text = LabelPrereq1.Text

        LabelId1.Text = Str(currentItemNumber)
        LabelName1.Text = TextBoxName.Text
        LabelDuration1.Text = TextBoxDuration.Text
        LabelPrereq1.Text = TextBoxPrereq.Text

        TextBoxName.Text = ""
        TextBoxDuration.Text = ""
        TextBoxPrereq.Text = ""

    End Sub

    Private Sub ButtonBack_Click(sender As Object, e As EventArgs) Handles ButtonBack.Click

        If currentItemNumber = 0 Then Return
        itemId(currentItemNumber) = ""
        itemName(currentItemNumber) = ""
        itemDuration(currentItemNumber) = ""
        itemPrereq(currentItemNumber) = ""

        currentItemNumber -= 1
        LabelCurNumber.Text = Str(currentItemNumber)

        TextBoxName.Text = LabelName1.Text
        TextBoxDuration.Text = LabelDuration1.Text
        TextBoxPrereq.Text = LabelPrereq1.Text

        LabelId1.Text = LabelId2.Text
        LabelId2.Text = LabelId3.Text
        LabelId3.Text = LabelId4.Text
        LabelId4.Text = LabelId5.Text
        LabelName1.Text = LabelName2.Text
        LabelName2.Text = LabelName3.Text
        LabelName3.Text = LabelName4.Text
        LabelName4.Text = LabelName5.Text
        LabelDuration1.Text = LabelDuration2.Text
        LabelDuration2.Text = LabelDuration3.Text
        LabelDuration3.Text = LabelDuration4.Text
        LabelDuration4.Text = LabelDuration5.Text
        LabelPrereq1.Text = LabelPrereq2.Text
        LabelPrereq2.Text = LabelPrereq3.Text
        LabelPrereq3.Text = LabelPrereq4.Text
        LabelPrereq4.Text = LabelPrereq5.Text

        If currentItemNumber <= 4 Then
            LabelId5.Text = ""
            LabelName5.Text = ""
            LabelDuration5.Text = ""
            LabelPrereq5.Text = ""
        Else
            LabelId5.Text = itemId(currentItemNumber - 4)
            LabelName5.Text = itemName(currentItemNumber - 4)
            LabelDuration5.Text = itemDuration(currentItemNumber - 4)
            LabelPrereq5.Text = itemPrereq(currentItemNumber - 4).Replace(",", ", ")
        End If

    End Sub

    Private Sub ButtonSubmit_Click(sender As Object, e As EventArgs) Handles ButtonSubmit.Click

        '读写.xlsx文件
        'Dim xlfilename As String
        'xlfilename = Application.StartupPath + "\originalData.xlsx"
        'If System.IO.Directory.Exists(xlfilename) = False Then File.Delete(xlfilename)
        'Dim xlapp As Excel.Application 'Excel对象
        'Dim xlbook As Excel.Workbook '工作簿
        'Dim xlsheet As Excel.Worksheet '工作表
        'Dim i As Integer
        'Dim wm As New WaitMsg
        'xlapp = CreateObject("Excel.Application") '创建EXCEL对象
        'xlbook = xlapp.Workbooks.Add '新建EXCEL工件簿文件
        'xlapp.Visible = False '设置EXCEL对象不可见
        'wm.Show()
        'xlsheet = xlbook.Worksheets(1) '设置活动工作表
        'For i = 1 To currentItemNumber
        '    xlsheet.Activate()
        '    xlsheet.Cells(i, 1) = itemId(i)
        '    xlsheet.Cells(i, 2) = itemName(i)
        '    xlsheet.Cells(i, 3) = itemDuration(i)
        '    xlsheet.Cells(i, 4) = itemPrereq(i)
        'Next
        'xlsheet.SaveAs(xlfilename)
        'xlapp.Quit()
        'xlapp = Nothing '释放xlApp对象
        'Me.Close()

        If currentItemNumber = 0 Then
            MsgBox("Empty Data.", MsgBoxStyle.Exclamation, Title:="WARNING")
            Me.DialogResult = DialogResult.None
        Else
            ShowWaitMsg(3)
            SaveNpdb()
            SaveNpd()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

End Class