Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System
Imports System.ComponentModel

Public Class SearchView


    Private Sub SearchView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If IO.File.Exists(fileName_QuerySuccess) Then
            IO.File.Delete(fileName_QuerySuccess)
        End If

        WebBrowserQueryResults.Height = Me.Height - 70

        ComboBoxItem.SelectedItem = "<column>"
        ComboBoxCondition.Items.Clear()
        ComboBoxCondition.Items.Add("<condition>")
        ComboBoxCondition.SelectedItem = "<condition>"
        ComboBoxCondition.Enabled = False
        TextBoxCondition.Enabled = False
        ComboBoxOrderBy.Enabled = False
        ButtonOrder.Text = "↑"
        ButtonOrder.Visible = False
        ButtonOK.Enabled = False

        LoadCurrentHtml(WebBrowserQueryResults)

    End Sub

    Private Sub SearchView_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        WebBrowserQueryResults.Height = Me.Height - 70
        PanelQuery.Height = 37
    End Sub

    Private Sub ComboBoxItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItem.SelectedIndexChanged

        If ComboBoxItem.SelectedItem = "<column>" Then
            ComboBoxCondition.Items.Clear()
            ComboBoxCondition.Items.Add("<condition>")
            ComboBoxCondition.SelectedItem = "<condition>"
            ComboBoxCondition.Enabled = False
            TextBoxCondition.Enabled = False
            ComboBoxOrderBy.SelectedItem = "<sort by>"
            ButtonOrder.Text = "↑"
            ComboBoxOrderBy.Enabled = False
            ButtonOK.Enabled = False
        End If
        If ComboBoxItem.SelectedItem = "All" Then
            ComboBoxCondition.Items.Clear()
            ComboBoxCondition.Items.Add("<condition>")
            ComboBoxCondition.SelectedItem = "<condition>"
            ComboBoxCondition.Enabled = False
            TextBoxCondition.Enabled = False
            ComboBoxOrderBy.Enabled = True
            ComboBoxOrderBy.SelectedItem = "<sort by>"
            ButtonOrder.Text = "↑"
            ButtonOK.Enabled = True
        End If
        If ComboBoxItem.SelectedItem = "ID" Then
            ComboBoxCondition.Enabled = True
            ComboBoxCondition.Items.Clear()
            ComboBoxCondition.Items.Add("=")
            ComboBoxCondition.Items.Add(">")
            ComboBoxCondition.Items.Add(">=")
            ComboBoxCondition.Items.Add("<")
            ComboBoxCondition.Items.Add("<=")
            ComboBoxCondition.SelectedItem = "="
            TextBoxCondition.Enabled = True
            ComboBoxOrderBy.Enabled = True
            ComboBoxOrderBy.SelectedItem = "<sort by>"
            ButtonOrder.Text = "↑"
            If Trim(TextBoxCondition.Text) = "" Then ButtonOK.Enabled = False
        End If
        If ComboBoxItem.SelectedItem = "Name" Then
            ComboBoxCondition.Enabled = True
            ComboBoxCondition.Items.Clear()
            ComboBoxCondition.Items.Add("equals")
            ComboBoxCondition.Items.Add("contains")
            ComboBoxCondition.SelectedItem = "equals"
            TextBoxCondition.Enabled = True
            ComboBoxOrderBy.Enabled = True
            ComboBoxOrderBy.SelectedItem = "<sort by>"
            ButtonOrder.Text = "↑"
            If Trim(TextBoxCondition.Text) = "" Then ButtonOK.Enabled = False
        End If
        If ComboBoxItem.SelectedItem = "Duration" Then
            ComboBoxCondition.Enabled = True
            ComboBoxCondition.Items.Clear()
            ComboBoxCondition.Items.Add("=")
            ComboBoxCondition.Items.Add(">")
            ComboBoxCondition.Items.Add(">=")
            ComboBoxCondition.Items.Add("<")
            ComboBoxCondition.Items.Add("<=")
            ComboBoxCondition.SelectedItem = "="
            TextBoxCondition.Enabled = True
            ComboBoxOrderBy.Enabled = True
            ComboBoxOrderBy.SelectedItem = "<sort by>"
            ButtonOrder.Text = "↑"
            If Trim(TextBoxCondition.Text) = "" Then ButtonOK.Enabled = False
        End If
        If ComboBoxItem.SelectedItem = "Prerequisite(s)" Then
            ComboBoxCondition.Enabled = True
            ComboBoxCondition.Items.Clear()
            ComboBoxCondition.Items.Add("equal(s)")
            ComboBoxCondition.Items.Add("contain(s)")
            ComboBoxCondition.SelectedItem = "contain(s)"
            TextBoxCondition.Enabled = True
            ComboBoxOrderBy.Enabled = True
            ComboBoxOrderBy.SelectedItem = "<sort by>"
            ButtonOrder.Text = "↑"
            If Trim(TextBoxCondition.Text) = "" Then ButtonOK.Enabled = False
        End If
    End Sub

    Private Sub TextBoxCondition_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCondition.TextChanged
        If Trim(TextBoxCondition.Text) = "" Then
            ButtonOK.Enabled = False
        Else
            ButtonOK.Enabled = True
        End If
        If (ComboBoxItem.SelectedItem = "Duration" Or ComboBoxItem.SelectedItem = "ID") And IsNumeric(Trim(TextBoxCondition.Text)) = False Then
            ButtonOK.Enabled = False
        Else
            ButtonOK.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxOrderBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxOrderBy.SelectedIndexChanged
        If ComboBoxOrderBy.SelectedItem <> "<sort by>" Then
            ButtonOrder.Visible = True
            ButtonOK.Enabled = True
        Else
            ButtonOrder.Visible = False
            ButtonOK.Enabled = True
        End If
    End Sub

    Private Sub ButtonOrder_Click(sender As Object, e As EventArgs) Handles ButtonOrder.Click
        If ButtonOrder.Text = "↑" Then
            ButtonOrder.Text = "↓"
            Return
        End If
        If ButtonOrder.Text = "↓" Then
            ButtonOrder.Text = "↑"
            Return
        End If
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        If IO.File.Exists(fileName_QueryHtml) Then
            IO.File.Delete(fileName_QueryHtml)
        End If

        If System.IO.File.Exists(fileName_dbExe) = False Or System.IO.File.Exists(fileName_dbQueryBat) = False Then
            MsgBox("Indispensable file missing.", MsgBoxStyle.Critical, Title:="FATAL ERROR")
            Return
        End If

        Dim sqlCommand As String

        sqlCommand = "select * from npg"

        Select Case ComboBoxItem.SelectedItem
            Case "All"
                sqlCommand = sqlCommand
            Case "ID"
                sqlCommand = sqlCommand + " where itemID"
            Case "Name"
                sqlCommand = sqlCommand + " where itemName"
            Case "Duration"
                sqlCommand = sqlCommand + " where itemDuration"
            Case "Prerequisite(s)"
                sqlCommand = sqlCommand + " where itemPrereq"
        End Select

        If ComboBoxItem.SelectedItem <> "All" Then
            Select Case ComboBoxCondition.SelectedItem
                Case "equals"
                    sqlCommand = sqlCommand + " = '" + TextBoxCondition.Text + "'"
                Case "contains"
                    sqlCommand = sqlCommand + " like '%" + TextBoxCondition.Text + "%'"
                Case "equal(s)"
                    sqlCommand = sqlCommand + " = '" + TextBoxCondition.Text + "'"
                Case "contain(s)"
                    sqlCommand = sqlCommand + " like '%" + TextBoxCondition.Text + "%'"
                Case Else
                    sqlCommand = sqlCommand + " " + ComboBoxCondition.SelectedItem + " " + TextBoxCondition.Text + " "
            End Select
        End If

        If ComboBoxOrderBy.SelectedItem <> "<sort by>" Then
            sqlCommand = sqlCommand + " order by "
            Select Case ComboBoxOrderBy.SelectedItem
                Case "ID"
                    sqlCommand = sqlCommand + "itemID"
                Case "Name"
                    sqlCommand = sqlCommand + "itemName"
                Case "Duration"
                    sqlCommand = sqlCommand + "itemDuration"
            End Select
            If ButtonOrder.Text = "↑" Then sqlCommand = sqlCommand + " asc"
            If ButtonOrder.Text = "↓" Then sqlCommand = sqlCommand + " desc"
        End If

        Dim dbQuery As New StreamWriter(fileName_dbQuery, False, Encoding.ASCII)
        dbQuery.Write(sqlCommand)
        dbQuery.Close()
        Shell(fileName_dbQueryBat)
        ShowWaitMsg(waitForQuery:=True)
        If wmTickTimes <= wmTimeLimit Then LoadQueryResultsHtml(WebBrowserQueryResults)
    End Sub

    Private Sub SearchView_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If IO.File.Exists(fileName_QueryHtml) Then
            IO.File.Delete(fileName_QueryHtml)
        End If
    End Sub
End Class