Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Text
Imports System.ComponentModel

Module GlobalVariables
    Public currentItemNumber As Integer
    Public curFileName As String
    Public itemId(10000) As String
    Public itemName(10000) As String
    Public itemDuration(10000) As String
    Public itemPrereq(10000) As String
    Public wmTickTimes As Integer

    Public queryItemNumber As Integer = 0
    Public queryId(10000) As String
    Public queryName(10000) As String
    Public queryDuration(10000) As String
    Public queryPrereq(10000) As String
    Public wmWaitForQuery As Boolean = False
    Public wmTimeLimit As Integer = 50

    Public fileName_NewDefault As String = "new_project"

    'Paths
    Public initialDirectory As String = Application.StartupPath + "\project"
    Public filePath_DrawGraph As String = Application.StartupPath + "\npgraph"
    Public filePath_npdb As String = Application.StartupPath + "\query"

    'DRAW GRAPH: npgraph: indespensible files
    Public fileName_DrawGraphExe As String = filePath_DrawGraph + "\npgraph.exe"
    Public fileName_DrawGraphPython As String = filePath_DrawGraph + "\draw_aov.py"
    Public fileName_DrawGraphBat As String = filePath_DrawGraph + "\npgraph.bat"

    'SEARCH: query: indespensible files
    Public fileName_dbExe As String = filePath_npdb + "\database.exe"
    Public fileName_dbQueryBat As String = filePath_npdb + "\database.bat"

    'DRAW GRAPH: npgraph: temporary data files
    Public fileName_fileName As String = filePath_DrawGraph + "\fileName"

    'SEARCH: query: temporary data files
    Public fileName_npdb As String = filePath_npdb + "\npdatabase.npdb"
    Public fileName_dbQuery As String = filePath_npdb + "\dbquery.npdb"
    Public fileName_QueryHtml As String = filePath_npdb + "\queryresults.html"
    Public fileName_QuerySuccess As String = filePath_npdb + "\QuerySuccess"

    Public Sub LoadCurrentHtml(webBrowser As WebBrowser)
        Dim queryHtml As New StreamWriter(fileName_QueryHtml, False, Encoding.UTF8)
        queryHtml.Write("<style>" + vbCrLf)
        queryHtml.Write("table tr td{border-width: 1px;border-style: solid;border-color:gainsboro;}" + vbCrLf)
        queryHtml.Write("table{width: 100%;font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;text-align:center;border-collapse: collapse;}" + vbCrLf)
        queryHtml.Write("</style>" + vbCrLf)
        queryHtml.Write("<table><tr><td> ID </td><td> Name </td><td> Duration </td><td> Prerequisite(s) </td></tr>" + vbCrLf)
        For i = 1 To currentItemNumber
            queryHtml.Write("<tr>" + vbCrLf)
            queryHtml.Write("<td>" + itemId(i) + "</td>" + vbCrLf)
            queryHtml.Write("<td>" + itemName(i) + "</td>" + vbCrLf)
            queryHtml.Write("<td>" + itemDuration(i) + "</td>" + vbCrLf)
            queryHtml.Write("<td>" + itemPrereq(i) + "</td>" + vbCrLf)
            queryHtml.Write("</tr>" + vbCrLf)
        Next
        If currentItemNumber = 0 Then
            queryHtml.Write("<tr><td colspan=""4"">(Empty)</td></tr>")
        End If
        queryHtml.Write("</table>")
        queryHtml.Close()
        webBrowser.Url = New Uri(fileName_QueryHtml)
    End Sub

    Public Sub LoadQueryResultsHtml(webBrowser As WebBrowser)
        Dim dbQuery As New StreamReader(fileName_dbQuery, Encoding.UTF8)
        Dim readBufferString As String
        Dim readBufferChar() As String
        queryItemNumber = 0
        readBufferString = ""
        While (True)
            readBufferString = dbQuery.ReadLine()
            If readBufferString = "" Then
                Exit While
            Else
                queryItemNumber = queryItemNumber + 1
                readBufferChar = Split(readBufferString, vbTab)
                queryId(queryItemNumber) = Trim(readBufferChar(0))
                queryName(queryItemNumber) = Trim(readBufferChar(1))
                queryDuration(queryItemNumber) = Trim(readBufferChar(2))
                queryPrereq(queryItemNumber) = Trim(readBufferChar(3))
                queryPrereq(queryItemNumber) = queryPrereq(queryItemNumber).Replace(",", ", ")
            End If
        End While
        dbQuery.Close()

        Dim queryHtml As New StreamWriter(fileName_QueryHtml, False, Encoding.UTF8)
        queryHtml.Write("<style>" + vbCrLf)
        queryHtml.Write("table tr td{border-width: 1px;border-style: solid;border-color:gainsboro;}" + vbCrLf)
        queryHtml.Write("table{width: 100%;font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;text-align:center;border-collapse: collapse;}" + vbCrLf)
        queryHtml.Write("</style>" + vbCrLf)
        queryHtml.Write("<table><tr><td> ID </td><td> Name </td><td> Duration </td><td> Prerequisite(s) </td></tr>" + vbCrLf)
        For i = 1 To queryItemNumber
            queryHtml.Write("<tr>" + vbCrLf)
            queryHtml.Write("<td>" + queryId(i) + "</td>" + vbCrLf)
            queryHtml.Write("<td>" + queryName(i) + "</td>" + vbCrLf)
            queryHtml.Write("<td>" + queryDuration(i) + "</td>" + vbCrLf)
            queryHtml.Write("<td>" + queryPrereq(i) + "</td>" + vbCrLf)
            queryHtml.Write("</tr>" + vbCrLf)
        Next
        If queryItemNumber = 0 Then
            queryHtml.Write("<tr><td colspan=""4"">(No Results)</td></tr>")
        End If
        queryHtml.Write("</table>")
        queryHtml.Close()
        webBrowser.Url = New Uri(fileName_QueryHtml)
    End Sub

    Public Sub ShowWaitMsg(Optional interval As Integer = 25, Optional waitForQuery As Boolean = False)
        Dim wm As New WaitMsg
        wm.Timer1.Interval = interval
        wmWaitForQuery = waitForQuery
        wm.ShowDialog()
    End Sub

    Public Sub SaveNpd()
        If currentItemNumber = 0 Then
            Return
        Else
            Dim npd As New StreamWriter(curFileName, False, Encoding.ASCII)
            Dim i As Integer
            For i = 1 To currentItemNumber
                npd.Write(" " + itemId(i) + " " + itemName(i) + " " + itemDuration(i) + " " + itemPrereq(i).Replace(", ", ","))
                If i <> currentItemNumber Then npd.Write(vbCrLf)
            Next
            npd.Close()
        End If
    End Sub

    Public Sub SaveNpdb()
        Dim npdb As New StreamWriter(fileName_npdb, False, Encoding.UTF8)
        For i = 1 To currentItemNumber
            If Trim(itemPrereq(i)) = "" Then
                npdb.Write(" " + itemId(i) + vbTab + itemName(i) + vbTab + itemDuration(i) + vbTab + " ")
            Else
                npdb.Write(" " + itemId(i) + vbTab + itemName(i) + vbTab + itemDuration(i) + vbTab + itemPrereq(i).Replace(", ", ","))
            End If
            If i <> currentItemNumber Then npdb.Write(vbCrLf)
        Next
        npdb.Close()
    End Sub

End Module

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If IO.Directory.Exists(initialDirectory) = False Then
            IO.Directory.CreateDirectory(initialDirectory)
        End If
        If IO.Directory.Exists(filePath_DrawGraph) = False Then
            IO.Directory.CreateDirectory(filePath_DrawGraph)
        End If
        If IO.Directory.Exists(filePath_npdb) = False Then
            IO.Directory.CreateDirectory(filePath_npdb)
        End If

        ButtonReadIn.FlatAppearance.BorderSize = 2
        ButtonReadIn.FlatAppearance.BorderColor = Color.White
        ButtonReadIn.FlatAppearance.MouseOverBackColor = Color.White
        ButtonReadIn.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke

        ButtonSearchView.FlatAppearance.BorderSize = 2
        ButtonSearchView.FlatAppearance.BorderColor = Color.White
        ButtonSearchView.FlatAppearance.MouseOverBackColor = Color.White
        ButtonSearchView.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke

        ButtonModifyDelete.FlatAppearance.BorderSize = 2
        ButtonModifyDelete.FlatAppearance.BorderColor = Color.White
        ButtonModifyDelete.FlatAppearance.MouseOverBackColor = Color.White
        ButtonModifyDelete.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke

        ButtonDrawGraph.FlatAppearance.BorderSize = 2
        ButtonDrawGraph.FlatAppearance.BorderColor = Color.White
        ButtonDrawGraph.FlatAppearance.MouseOverBackColor = Color.White
        ButtonDrawGraph.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke

        ButtonReadIn.Enabled = False
        ButtonSearchView.Enabled = False
        ButtonModifyDelete.Enabled = False
        ButtonDrawGraph.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        SaveAsToolStripMenuItem.Enabled = False
        CloseToolStripMenuItem.Enabled = False

    End Sub

    Private Sub ButtonReadIn_MouseHover(sender As Object, e As EventArgs) Handles ButtonReadIn.MouseHover
        ButtonReadIn.FlatAppearance.BorderColor = Color.WhiteSmoke
    End Sub

    Private Sub ButtonReadIn_MouseLeave(sender As Object, e As EventArgs) Handles ButtonReadIn.MouseLeave
        ButtonReadIn.FlatAppearance.BorderColor = Color.White
    End Sub

    Private Sub ButtonSearchView_MouseHover(sender As Object, e As EventArgs) Handles ButtonSearchView.MouseHover
        ButtonSearchView.FlatAppearance.BorderColor = Color.WhiteSmoke
    End Sub

    Private Sub ButtonSearchView_MouseLeave(sender As Object, e As EventArgs) Handles ButtonSearchView.MouseLeave
        ButtonSearchView.FlatAppearance.BorderColor = Color.White
    End Sub

    Private Sub ButtonModifyDelete_MouseHover(sender As Object, e As EventArgs) Handles ButtonModifyDelete.MouseHover
        ButtonModifyDelete.FlatAppearance.BorderColor = Color.WhiteSmoke
    End Sub

    Private Sub ButtonModifyDelete_MouseLeave(sender As Object, e As EventArgs) Handles ButtonModifyDelete.MouseLeave
        ButtonModifyDelete.FlatAppearance.BorderColor = Color.White
    End Sub

    Private Sub ButtonDrawGraph_MouseHover(sender As Object, e As EventArgs) Handles ButtonDrawGraph.MouseHover
        ButtonDrawGraph.FlatAppearance.BorderColor = Color.WhiteSmoke
    End Sub

    Private Sub ButtonDrawGraph_MouseLeave(sender As Object, e As EventArgs) Handles ButtonDrawGraph.MouseLeave
        ButtonDrawGraph.FlatAppearance.BorderColor = Color.White
    End Sub

    Private Sub ButtonReadIn_Click(sender As Object, e As EventArgs) Handles ButtonReadIn.Click
        Dim ri As New ReadIn
        ri.ShowDialog()
        If ri.DialogResult = DialogResult.OK Then ButtonReadIn.Enabled = False
    End Sub

    Private Sub ButtonSearchView_Click(sender As Object, e As EventArgs) Handles ButtonSearchView.Click
        Dim sv As New SearchView
        sv.ShowDialog()
    End Sub

    Private Sub ButtonModifyDelete_Click(sender As Object, e As EventArgs) Handles ButtonModifyDelete.Click
        Dim md As New ModifyDelete
        md.ShowDialog()
    End Sub

    Private Sub ButtonDrawGraph_Click(sender As Object, e As EventArgs) Handles ButtonDrawGraph.Click
        If currentItemNumber = 0 Then
            MsgBox("Empty data.", MsgBoxStyle.Exclamation, Title:="WARNING")
            Return
        End If
        If System.IO.File.Exists(fileName_DrawGraphExe) = False Or System.IO.File.Exists(fileName_DrawGraphPython) = False Or System.IO.File.Exists(fileName_DrawGraphBat) = False Then
            MsgBox("Indispensable file missing.", MsgBoxStyle.Critical, Title:="FATAL ERROR")
            Return
        End If
        ShowWaitMsg(3)
        Dim fileNameForCpp As New StreamWriter(fileName_fileName, False, Encoding.ASCII)
        fileNameForCpp.Write(curFileName)
        fileNameForCpp.Close()
        Shell(fileName_DrawGraphBat)
    End Sub

    Private Sub NewProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewProjectToolStripMenuItem.Click
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.Title = "New..."

        saveFileDialog.InitialDirectory = initialDirectory
        saveFileDialog.Filter = "Network planning data files (*.npd)|*.npd"
        saveFileDialog.FilterIndex = 1
        saveFileDialog.RestoreDirectory = True
        saveFileDialog.FileName = fileName_NewDefault
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            curFileName = saveFileDialog.FileName()
            ButtonReadIn.Enabled = True
            ButtonSearchView.Enabled = True
            ButtonModifyDelete.Enabled = True
            ButtonDrawGraph.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            SaveAsToolStripMenuItem.Enabled = True
            CloseToolStripMenuItem.Enabled = True
            currentItemNumber = 0
            If IO.File.Exists(curFileName) = True Then
                IO.File.Delete(curFileName)
            End If
            If IO.File.Exists(fileName_npdb) = True Then
                IO.File.Delete(fileName_npdb)
            End If
        End If
    End Sub

    Private Sub OpenProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenProjectToolStripMenuItem.Click
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.InitialDirectory = initialDirectory
        openFileDialog.Filter = "Network planning data files (*.npd)|*.npd"
        openFileDialog.FilterIndex = 1
        openFileDialog.RestoreDirectory = True
        If openFileDialog.ShowDialog() <> DialogResult.OK Then Return
        curFileName = openFileDialog.FileName()
        ButtonReadIn.Enabled = False
        ButtonSearchView.Enabled = True
        ButtonModifyDelete.Enabled = True
        ButtonDrawGraph.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        SaveAsToolStripMenuItem.Enabled = True
        CloseToolStripMenuItem.Enabled = True
        Dim txtfileforcpp As New StreamReader(curFileName, Encoding.ASCII)
        Dim readBufferString As String
        Dim readBufferChar() As String
        currentItemNumber = 0
        readBufferString = ""
        Try
            While (True)
                readBufferString = txtfileforcpp.ReadLine()
                If readBufferString = "" Then
                    Exit While
                Else
                    currentItemNumber = currentItemNumber + 1
                    readBufferChar = Split(readBufferString, " ")
                    itemId(currentItemNumber) = Trim(readBufferChar(1))
                    itemName(currentItemNumber) = Trim(readBufferChar(2))
                    itemDuration(currentItemNumber) = Trim(readBufferChar(3))
                    itemPrereq(currentItemNumber) = Trim(readBufferChar(4))
                    If IsNumeric(itemId(currentItemNumber)) = False Or IsNumeric(itemDuration(currentItemNumber)) = False Then
                        Throw New Exception
                    End If
                    If itemName(currentItemNumber) = "" Or itemName(currentItemNumber).Contains(",") Then
                        Throw New Exception
                    End If
                    If itemDuration(currentItemNumber).Contains(".") Or itemDuration(currentItemNumber).Contains(",") Then
                        Throw New Exception
                    End If
                    If readBufferString.Contains(", ") Or readBufferString.Contains(", ") Then
                        Throw New Exception
                    End If

                    If itemPrereq(currentItemNumber) <> "" Then
                        Dim prereqArray() As String
                        Dim prereqNumber, prereqInNames As Integer
                        Dim prereq As String
                        prereq = itemPrereq(currentItemNumber)
                        prereqArray = Split(prereq, ",")
                        prereqNumber = 1

                        For i = 0 To prereq.Length - 1
                            If prereq.Substring(i, 1) = "," Then prereqNumber = prereqNumber + 1
                        Next

                        For i = 0 To prereqNumber - 1
                            prereqInNames = 0
                            For j = 1 To currentItemNumber - 1
                                If prereqArray(i) = itemName(j) Then prereqInNames = 1
                            Next
                            For j = 0 To i - 1
                                If prereqArray(i) = prereqArray(j) Then prereqInNames = 0
                            Next
                            If prereqInNames = 0 Then
                                Throw New Exception
                            End If
                        Next
                    End If

                    itemPrereq(currentItemNumber) = itemPrereq(currentItemNumber).Replace(",", ", ")

                End If
            End While
        Catch
            currentItemNumber = 0
            curFileName = ""
            ButtonReadIn.Enabled = False
            ButtonSearchView.Enabled = False
            ButtonModifyDelete.Enabled = False
            ButtonDrawGraph.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            SaveAsToolStripMenuItem.Enabled = False
            CloseToolStripMenuItem.Enabled = False
            MsgBox("This file is corrupted and unreadable.", MsgBoxStyle.Critical, Title:="ERROR")
        Finally
            txtfileforcpp.Close()
            SaveNpdb()
        End Try

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveNpd()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.InitialDirectory = initialDirectory
        saveFileDialog.Filter = "Network planning data files (*.npd)|*.npd"
        saveFileDialog.FilterIndex = 1
        saveFileDialog.RestoreDirectory = True
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            curFileName = saveFileDialog.FileName()
            SaveNpd()
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        curFileName = ""
        ButtonReadIn.Enabled = False
        ButtonSearchView.Enabled = False
        ButtonModifyDelete.Enabled = False
        ButtonDrawGraph.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        SaveAsToolStripMenuItem.Enabled = False
        CloseToolStripMenuItem.Enabled = False
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ViewHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewHelpToolStripMenuItem.Click
        MsgBox("There are currently no help documents available.", MsgBoxStyle.Information, Title:="Help")
    End Sub

    Private Sub SendFeedbackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendFeedbackToolStripMenuItem.Click
        InputBox("Thank you for your feedback!" + vbCrLf + "We'll keep improving!", Title:="Feedback")
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        MsgBox("There are currently no updates available.", MsgBoxStyle.Information, Title:="Check for Updates")
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        System.Diagnostics.Process.Start("https://github.com/AdamMasquerades/network-planning/blob/master/README.md")
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If IO.File.Exists(fileName_fileName) = True Then
            IO.File.Delete(fileName_fileName)
        End If
        If IO.File.Exists(fileName_npdb) = True Then
            IO.File.Delete(fileName_npdb)
        End If
        If IO.File.Exists(fileName_dbQuery) = True Then
            IO.File.Delete(fileName_dbQuery)
        End If
    End Sub
End Class