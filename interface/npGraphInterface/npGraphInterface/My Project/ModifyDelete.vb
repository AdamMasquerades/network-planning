Imports System.ComponentModel
Imports System.Drawing

Public Class ModifyDelete

    Dim textBoxAddNameInitialized As Integer
    Dim textBoxAddDurationInitialized As Integer
    Dim textBoxAddPrereqInitialized As Integer
    Dim textBoxModifyNameInitialized As Integer
    Dim textBoxModifyDurationInitialized As Integer
    Dim textBoxModifyPrereqInitialized As Integer

    Private Sub AddDisable()
        textBoxAddNameInitialized = 0
        TextBoxAddName.Text = " Name"
        TextBoxAddName.ForeColor = Color.Silver
        textBoxAddDurationInitialized = 0
        TextBoxAddDuration.Text = " Duration"
        TextBoxAddDuration.ForeColor = Color.Silver
        textBoxAddPrereqInitialized = 0
        TextBoxAddPrereq.Text = " Prerequisite(s)"
        TextBoxAddPrereq.ForeColor = Color.Silver
        TextBoxAddName.Visible = False
        TextBoxAddDuration.Visible = False
        TextBoxAddPrereq.Visible = False
    End Sub

    Private Sub ModifyDisable()
        TextBoxID.Text = ""
        textBoxModifyNameInitialized = 0
        TextBoxModifyName.Text = " Name"
        TextBoxModifyName.ForeColor = Color.Silver
        textBoxModifyDurationInitialized = 0
        TextBoxModifyDuration.Text = " Duration"
        TextBoxModifyDuration.ForeColor = Color.Silver
        textBoxModifyPrereqInitialized = 0
        TextBoxModifyPrereq.Text = " Prerequisite(s)"
        TextBoxModifyPrereq.ForeColor = Color.Silver
        LabelID.Visible = False
        TextBoxID.Visible = False
        TextBoxModifyName.Visible = False
        TextBoxModifyDuration.Visible = False
        TextBoxModifyPrereq.Visible = False
    End Sub

    Private Sub DeleteDisable()
        TextBoxID.Text = ""
        LabelID.Visible = False
        TextBoxID.Visible = False
        TextBoxModifyName.Visible = False
        TextBoxModifyDuration.Visible = False
        TextBoxModifyPrereq.Visible = False
    End Sub

    Private Sub AddSelected()
        ModifyDisable()
        DeleteDisable()
        TextBoxAddName.Visible = True
        TextBoxAddDuration.Visible = True
        TextBoxAddPrereq.Visible = True
        ButtonOK.Visible = True
    End Sub

    Private Sub ModifySelected()
        AddDisable()
        DeleteDisable()
        ButtonOK.Visible = True
        LabelID.Visible = True
        TextBoxID.Visible = True
        TextBoxModifyName.Visible = True
        TextBoxModifyDuration.Visible = True
        TextBoxModifyPrereq.Visible = True
    End Sub

    Private Sub DeleteSelected()
        AddDisable()
        ModifyDisable()
        ButtonOK.Visible = True
        LabelID.Visible = True
        TextBoxID.Visible = True
    End Sub

    Private Sub NoneSelected()
        AddDisable()
        ModifyDisable()
        DeleteDisable()
        ButtonOK.Visible = False
    End Sub

    Private Function DeleteIdCheck(id As String) As String
        If id = "" Then Return "Invalid ID. It cannot be empty."
        If IsNumeric(id) = False Or id.Contains(".") Or id.Contains(",") Then Return "Invalid ID. It must be an integer."
        Dim idVal As Integer = Val(id)
        If idVal <= 0 Then Return "Invalid ID. It must be an positive integer."
        If idVal > currentItemNumber Then Return "ID out of range."

        Dim postPrereqArray() As String
        Dim postPrereqNumber As Integer
        Dim j, k As Integer


        For j = idVal + 1 To currentItemNumber
            postPrereqArray = Split(itemPrereq(j), ",")         'note that the separator is ONLY A SINGLE comma.
            postPrereqNumber = 1
            For k = 0 To itemPrereq(j).Length - 1
                If itemPrereq(j).Substring(k, 1) = "," Then postPrereqNumber = postPrereqNumber + 1
            Next
            For k = 0 To postPrereqNumber - 1
                If itemName(idVal) = postPrereqArray(k) Then Return "This item cannot be deleted, because it serves as a prerequisite of another item (ID=" + Str(j) + ")."
            Next
        Next

        Return "OK"
    End Function

    Private Sub ModifyDelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowserQueryResults.Height = Me.Height - 70
        ComboBoxFunction.SelectedItem = "<none>"
        LoadCurrentHtml(WebBrowserQueryResults)
        textBoxAddNameInitialized = 0
        textBoxAddDurationInitialized = 0
        textBoxAddPrereqInitialized = 0
        textBoxModifyNameInitialized = 0
        textBoxModifyDurationInitialized = 0
        textBoxModifyPrereqInitialized = 0
        If IO.File.Exists(fileName_QuerySuccess) Then
            IO.File.Delete(fileName_QuerySuccess)
        End If
    End Sub

    Private Sub SearchView_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        WebBrowserQueryResults.Height = Me.Height - 70
    End Sub

    Private Sub ModifyDelete_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If IO.File.Exists(fileName_QueryHtml) Then
            IO.File.Delete(fileName_QueryHtml)
        End If
    End Sub

    Private Sub ComboBoxFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFunction.SelectedIndexChanged
        Select Case ComboBoxFunction.SelectedItem
            Case "Add"
                AddSelected()
            Case "Modify"
                ModifySelected()
            Case "Delete"
                DeleteSelected()
            Case Else
                NoneSelected()
        End Select
    End Sub

    Private Sub TextBoxAddName_Click(sender As Object, e As EventArgs) Handles TextBoxAddName.Click
        If textBoxAddNameInitialized = 0 Then
            TextBoxAddName.ForeColor = Color.Black
            TextBoxAddName.Text = ""
        End If
        textBoxAddNameInitialized = 1
    End Sub

    Private Sub TextBoxAddDuration_Click(sender As Object, e As EventArgs) Handles TextBoxAddDuration.Click
        If textBoxAddDurationInitialized = 0 Then
            TextBoxAddDuration.ForeColor = Color.Black
            TextBoxAddDuration.Text = ""
        End If
        textBoxAddDurationInitialized = 1
    End Sub

    Private Sub TextBoxAddPrereq_Click(sender As Object, e As EventArgs) Handles TextBoxAddPrereq.Click
        If textBoxAddPrereqInitialized = 0 Then
            TextBoxAddPrereq.ForeColor = Color.Black
            TextBoxAddPrereq.Text = ""
        End If
        textBoxAddPrereqInitialized = 1
    End Sub

    Private Sub TextBoxModifyName_Click(sender As Object, e As EventArgs) Handles TextBoxModifyName.Click
        If textBoxModifyNameInitialized = 0 Then
            TextBoxModifyName.ForeColor = Color.Black
            TextBoxModifyName.Text = ""
        End If
        textBoxModifyNameInitialized = 1
    End Sub

    Private Sub TextBoxModifyDuration_Click(sender As Object, e As EventArgs) Handles TextBoxModifyDuration.Click
        If textBoxModifyDurationInitialized = 0 Then
            TextBoxModifyDuration.ForeColor = Color.Black
            TextBoxModifyDuration.Text = ""
        End If
        textBoxModifyDurationInitialized = 1
    End Sub

    Private Sub TextBoxModifyPrereq_Click(sender As Object, e As EventArgs) Handles TextBoxModifyPrereq.Click
        If textBoxModifyPrereqInitialized = 0 Then
            TextBoxModifyPrereq.ForeColor = Color.Black
            TextBoxModifyPrereq.Text = ""
        End If
        textBoxModifyPrereqInitialized = 1
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Dim sqlCommand As String = ""

        Select Case ComboBoxFunction.SelectedItem
            Case "Add"

                Dim checkResult As String

                NameRegularize(TextBoxAddName.Text)
                checkResult = NameCheck(TextBoxAddName.Text)
                If checkResult <> "OK" Then
                    MsgBox(checkResult, MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

                checkResult = DurationCheck(TextBoxAddDuration.Text)
                If checkResult <> "OK" Then
                    MsgBox(checkResult, MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

                PrerequisiteRegularize(TextBoxAddPrereq.Text)
                checkResult = PrerequisiteCheck(TextBoxAddPrereq.Text, currentItemNumber)
                If checkResult <> "OK" Then
                    MsgBox(checkResult, MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

                currentItemNumber += 1
                itemId(currentItemNumber) = Trim(Str(currentItemNumber))
                itemName(currentItemNumber) = TextBoxAddName.Text
                itemDuration(currentItemNumber) = TextBoxAddDuration.Text
                itemPrereq(currentItemNumber) = TextBoxAddPrereq.Text

                itemPrereq(currentItemNumber) = itemPrereq(currentItemNumber).Replace(", ", ",")

                TextBoxAddName.Text = ""
                TextBoxAddDuration.Text = ""
                TextBoxAddPrereq.Text = ""

                'sqlCommand = "Insert into npg values('" + itemId(currentItemNumber) + "','" + itemName(currentItemNumber) + "','" + itemDuration(currentItemNumber) + "','" + itemPrereq(currentItemNumber).Replace(",", ", ") + "')"

                TextBoxID.Text = ""
                SaveNpd()
                SaveNpdb()

                LoadCurrentHtml(WebBrowserQueryResults)

            Case "Modify"

                Dim checkResult As String

                If IsNumeric(TextBoxID.Text) = False Or TextBoxID.Text.Contains(".") Or Val(TextBoxID.Text) > currentItemNumber Or Val(TextBoxID.Text) <= 0 Then
                    MsgBox("Invalid ID", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

                NameRegularize(TextBoxModifyName.Text)
                checkResult = NameCheck(TextBoxModifyName.Text, Val(TextBoxID.Text))
                If checkResult <> "OK" Then
                    MsgBox(checkResult, MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

                checkResult = DurationCheck(TextBoxModifyDuration.Text)
                If checkResult <> "OK" Then
                    MsgBox(checkResult, MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

                PrerequisiteRegularize(TextBoxModifyPrereq.Text)
                checkResult = PrerequisiteCheck(TextBoxModifyPrereq.Text, Val(TextBoxID.Text) - 1)
                If checkResult <> "OK" Then
                    MsgBox(checkResult, MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If


                itemId(Val(TextBoxID.Text)) = Trim(TextBoxID.Text)
                itemName(Val(TextBoxID.Text)) = TextBoxModifyName.Text
                itemDuration(Val(TextBoxID.Text)) = TextBoxModifyDuration.Text
                itemPrereq(Val(TextBoxID.Text)) = TextBoxModifyPrereq.Text

                itemPrereq(Val(TextBoxID.Text)) = itemPrereq(Val(TextBoxID.Text)).Replace(", ", ",")

                TextBoxModifyName.Text = ""
                TextBoxModifyDuration.Text = ""
                TextBoxModifyPrereq.Text = ""

                'sqlCommand = "Update npg set Name ='" + itemName(Val(TextBoxID.Text)) + "' , Duration= '" + itemDuration(Val(TextBoxID.Text)) + "' , Prerequisite='" + itemPrereq(Val(TextBoxID.Text)) + "' where ID ='" + Trim(TextBoxID.Text) + "'"

                TextBoxID.Text = ""
                SaveNpd()
                SaveNpdb()

                LoadCurrentHtml(WebBrowserQueryResults)

            Case "Delete"

                Dim checkResult As String
                checkResult = DeleteIdCheck(TextBoxID.Text)
                If checkResult <> "OK" Then
                    MsgBox(checkResult, MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

                Dim idVal As Integer = Val(TextBoxID.Text)
                Dim i As Integer

                If idVal <> currentItemNumber Then
                    For i = idVal To currentItemNumber - 1
                        itemName(i) = itemName(i + 1)
                        itemDuration(i) = itemDuration(i + 1)
                        itemPrereq(i) = itemPrereq(i + 1)
                    Next
                End If

                itemName(currentItemNumber) = ""
                itemDuration(currentItemNumber) = ""
                itemPrereq(currentItemNumber) = ""

                currentItemNumber = currentItemNumber - 1

                'sqlCommand = "delete from npg where ID=" + TextBoxID.Text

                TextBoxID.Text = ""
                SaveNpd()
                SaveNpdb()
                LoadCurrentHtml(WebBrowserQueryResults)
        End Select
    End Sub

    Private Sub TextBoxID_TextChanged(sender As Object, e As EventArgs) Handles TextBoxID.TextChanged
        If Val(TextBoxID.Text) > 0 And Val(TextBoxID.Text) <= currentItemNumber And ComboBoxFunction.SelectedItem = "Modify" Then
            TextBoxModifyName.ForeColor = Color.Black
            TextBoxModifyDuration.ForeColor = Color.Black
            TextBoxModifyPrereq.ForeColor = Color.Black
            textBoxModifyNameInitialized = 1
            textBoxModifyDurationInitialized = 1
            textBoxModifyPrereqInitialized = 1
            TextBoxModifyName.Text = itemName(Val(TextBoxID.Text))
            TextBoxModifyDuration.Text = itemDuration(Val(TextBoxID.Text))
            TextBoxModifyPrereq.Text = itemPrereq(Val(TextBoxID.Text))
        Else
            TextBoxModifyName.Text = ""
            TextBoxModifyDuration.Text = ""
            TextBoxModifyPrereq.Text = ""
            textBoxModifyNameInitialized = 0
            textBoxModifyDurationInitialized = 0
            textBoxModifyPrereqInitialized = 0
        End If
    End Sub
End Class