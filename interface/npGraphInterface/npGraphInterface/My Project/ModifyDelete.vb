Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
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
                Dim prereq As String
                Dim prereqArray() As String
                Dim prereqNumber, prereqInNames As Integer
                Dim i, j As Integer
                If TextBoxAddName.Text = "" Or TextBoxAddName.Text = " Name" Then
                    MsgBox("Invalid item name.", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

                TextBoxAddName.Text = Trim(TextBoxAddName.Text)
                While (TextBoxAddName.Text.Contains("  "))
                    TextBoxAddName.Text = TextBoxAddName.Text.Replace("  ", " ")
                End While
                TextBoxAddName.Text = TextBoxAddName.Text.Replace(" ", "-")

                If TextBoxAddName.Text.Contains(",") Then
                    MsgBox("Invalid item name. Item name cannot contain commas(,).", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If
                If currentItemNumber > 0 Then
                    For i = 1 To currentItemNumber
                        If TextBoxAddName.Text = itemName(i) Then
                            MsgBox("Invalid item name.", MsgBoxStyle.Exclamation, Title:="WARNING")
                            Return
                        End If
                    Next
                End If
                If TextBoxAddDuration.Text = "" Or IsNumeric(TextBoxAddDuration.Text) = False Or Val(TextBoxAddDuration.Text) < 0 Then
                    MsgBox("Invalid item duration.", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If
                If TextBoxAddDuration.Text.Contains(".") Or TextBoxAddDuration.Text.Contains(",") Then
                    MsgBox("Invalid item duration. Durations must be integers.", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

                If TextBoxAddPrereq.Text <> "" Then
                    prereq = TextBoxAddPrereq.Text             'Regualarize prereq to "One, Two, One-hundred"
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

                    TextBoxAddPrereq.Text = prereq
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
                If IsNumeric(TextBoxID.Text) = False Or TextBoxID.Text.Contains(".") Or Val(TextBoxID.Text) > currentItemNumber Or Val(TextBoxID.Text) <= 0 Then
                    MsgBox("Invalid ID", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If
                Dim prereq As String
                Dim prereqArray() As String
                Dim prereqNumber, prereqInNames As Integer
                Dim i, j As Integer
                If TextBoxModifyName.Text = "" Or TextBoxModifyName.Text = " Name" Then
                    MsgBox("Invalid item name.", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

                TextBoxModifyName.Text = Trim(TextBoxModifyName.Text)
                While (TextBoxModifyName.Text.Contains("  "))
                    TextBoxModifyName.Text = TextBoxModifyName.Text.Replace("  ", " ")
                End While
                TextBoxModifyName.Text = TextBoxModifyName.Text.Replace(" ", "-")

                If TextBoxModifyName.Text.Contains(",") Then
                    MsgBox("Invalid item name. Item name cannot contain commas(,).", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If
                If currentItemNumber > 0 Then
                    For i = 1 To currentItemNumber
                        If TextBoxModifyName.Text = itemName(i) And i <> Val(TextBoxID.Text) Then
                            MsgBox("Invalid item name.", MsgBoxStyle.Exclamation, Title:="WARNING")
                            Return
                        End If
                    Next
                End If
                If TextBoxModifyDuration.Text = "" Or IsNumeric(TextBoxModifyDuration.Text) = False Or Val(TextBoxAddDuration.Text) < 0 Then
                    MsgBox("Invalid item duration.", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If
                If TextBoxModifyDuration.Text.Contains(".") Or TextBoxModifyDuration.Text.Contains(",") Then
                    MsgBox("Invalid item duration. Durations must be integers.", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

                If TextBoxModifyPrereq.Text <> "" Then
                    prereq = TextBoxModifyPrereq.Text             'Regualarize prereq to "One, Two, One-hundred"
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
                        For j = 1 To Val(TextBoxID.Text) - 1
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

                    TextBoxModifyPrereq.Text = prereq
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
                If Val(TextBoxID.Text) <> currentItemNumber Then
                    'If IsNumeric(TextBoxID.Text) = False Or TextBoxID.Text.Contains(".") Or Val(TextBoxID.Text) > currentItemNumber Then
                    MsgBox("Invalid ID", MsgBoxStyle.Exclamation, Title:="WARNING")
                    Return
                End If

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
            TextBoxModifyName.Text = itemName(Val(TextBoxID.Text))
            TextBoxModifyDuration.Text = itemDuration(Val(TextBoxID.Text))
            TextBoxModifyPrereq.Text = itemPrereq(Val(TextBoxID.Text))
            TextBoxModifyName.ForeColor = Color.Black
            TextBoxModifyDuration.ForeColor = Color.Black
            TextBoxModifyPrereq.ForeColor = Color.Black
        Else
            TextBoxModifyName.Text = ""
            TextBoxModifyDuration.Text = ""
            TextBoxModifyPrereq.Text = ""
        End If
    End Sub
End Class