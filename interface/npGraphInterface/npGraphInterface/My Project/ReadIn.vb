Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Text
Imports System.Drawing

Public Class ReadIn

    Private Sub ReadIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentItemNumber = 0
        LabelCurNumber.Text = Str(currentItemNumber)
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        Dim prereq As String
        Dim prereqArray() As String
        Dim prereqNumber, prereqInNames As Integer
        Dim i, j As Integer

        TextBoxName.Text = Trim(TextBoxName.Text)
        While (TextBoxName.Text.Contains("  "))
            TextBoxName.Text = TextBoxName.Text.Replace("  ", " ")
        End While
        TextBoxName.Text = TextBoxName.Text.Replace(" ", "-")

        If TextBoxName.Text = "" Then
            MsgBox("Invalid item name.", MsgBoxStyle.Exclamation, Title:="WARNING")
            Return
        End If
        If TextBoxName.Text.Contains(",") Then
            MsgBox("Invalid item name. Item name cannot contain commas(,).", MsgBoxStyle.Exclamation, Title:="WARNING")
            Return
        End If
        If TextBoxName.Text = "START" Or TextBoxName.Text = "END" Or TextBoxName.Text = "Undefined" Then
            MsgBox("Invalid item name.", MsgBoxStyle.Exclamation, Title:="WARNING")
            Return
        End If
        If currentItemNumber > 0 Then
            For i = 1 To currentItemNumber
                If TextBoxName.Text = itemName(i) Then
                    MsgBox("Invalid item name.", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If
            Next
        End If
        If TextBoxDuration.Text = "" Or IsNumeric(TextBoxDuration.Text) = False Or Val(TextBoxDuration.Text) < 0 Then
            MsgBox("Invalid item duration.", MsgBoxStyle.Exclamation, Title:="WARNING")
            Return
        End If
        If TextBoxDuration.Text.Contains(".") Or TextBoxDuration.Text.Contains(",") Then
            MsgBox("Invalid item duration. Durations must be integers.", MsgBoxStyle.Exclamation, Title:="WARNING")
            Return
        End If

        If TextBoxPrereq.Text <> "" Then
            prereq = TextBoxPrereq.Text             'Regualarize prereq to "One, Two, One-hundred"
            prereq = Trim(prereq)
            While (prereq.Substring(0, 1) = ",")
                prereq = prereq.Substring(1, prereq.Length - 1)
            End While
            prereq = Trim(prereq)
            While (prereq.Substring(prereq.Length - 1, 1) = ",")
                prereq = prereq.Substring(0, prereq.Length - 1)
            End While
            While (prereq.Contains("  "))
                prereq = prereq.Replace("  ", " ")
            End While
            While (prereq.Contains(",,"))
                prereq = prereq.Replace(",,", ",")
            End While
            While (prereq.Contains(", "))
                prereq = prereq.Replace(", ", ",")
            End While
            While (prereq.Contains(" ,"))
                prereq = prereq.Replace(" ,", ",")
            End While
            prereq = prereq.Replace(" ", "-")
            prereq = prereq.Replace(",", ", ")

            prereqArray = Split(prereq, ", ")
            prereqNumber = 1
            For i = 0 To prereq.Length - 1
                If prereq.Substring(i, 1) = "," Then prereqNumber = prereqNumber + 1
            Next

            For i = 0 To prereqNumber - 1
                prereqInNames = 0
                For j = 1 To currentItemNumber
                    If prereqArray(i) = itemName(j) Then prereqInNames = 1
                Next
                For j = 0 To i - 1
                    If prereqArray(i) = prereqArray(j) Then prereqInNames = 0
                Next
                If prereqInNames = 0 Then
                    MsgBox("Invalid Prerequisite(s).", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If
            Next

            TextBoxPrereq.Text = prereq
        End If


        currentItemNumber += 1
        LabelCurNumber.Text = Trim(Str(currentItemNumber))
        itemId(currentItemNumber) = Trim(Str(currentItemNumber))
        itemName(currentItemNumber) = Trim(TextBoxName.Text)
        itemDuration(currentItemNumber) = Trim(TextBoxDuration.Text)
        itemPrereq(currentItemNumber) = Trim(TextBoxPrereq.Text)

        itemPrereq(currentItemNumber) = itemPrereq(currentItemNumber).Replace(", ", ",")

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