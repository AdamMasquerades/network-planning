Imports System.Windows.Forms
Imports System.IO
Imports System.Text

Module GlobalDefinitions

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
            queryHtml.Write("<td>" + itemPrereq(i).Replace(",", ", ") + "</td>" + vbCrLf)
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
            queryHtml.Write("<td>" + queryPrereq(i).Replace(",", ", ") + "</td>" + vbCrLf)
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

    Public Sub NameRegularize(ByRef name As String)
        name = Trim(name)
        While (name.Contains("  "))
            name = name.Replace("  ", " ")
        End While
        name = name.Replace(" ", "-")
    End Sub

    Public Sub PrerequisiteRegularize(ByRef prerequisite As String)   'Regualarize prerequisite to `One, Two, One-hundred`
        prerequisite = Trim(prerequisite)
        If prerequisite = "" Then Return
        If prerequisite = "," Then Return
        While (prerequisite.Substring(0, 1) = ",")
            prerequisite = prerequisite.Substring(1, prerequisite.Length - 1)
        End While
        prerequisite = Trim(prerequisite)
        While (prerequisite.Substring(prerequisite.Length - 1, 1) = ",")
            prerequisite = prerequisite.Substring(0, prerequisite.Length - 1)
        End While
        While (prerequisite.Contains("  "))
            prerequisite = prerequisite.Replace("  ", " ")
        End While
        While (prerequisite.Contains(",,"))
            prerequisite = prerequisite.Replace(",,", ",")
        End While
        While (prerequisite.Contains(", "))
            prerequisite = prerequisite.Replace(", ", ",")
        End While
        While (prerequisite.Contains(" ,"))
            prerequisite = prerequisite.Replace(" ,", ",")
        End While
        prerequisite = prerequisite.Replace(" ", "-")
        prerequisite = prerequisite.Replace(",", ", ")
    End Sub

    Public Function ConditionCheck(condition As String) As String
        If condition = "" Then Return "Invalid query. It cannot be empty."
        If condition.Contains("'") Or condition.Contains("""") Then Return "Invalid query. It cannot contain quotation marks(',"")."
        If condition.Contains("(") Or condition.Contains(")") Or condition.Contains("{") Or condition.Contains("}") Then Return "Invalid query. It cannot contain parentheses('()') or braces('{}')." + vbCrLf + "Brackets('[]') are recommended."
        If condition = "START" Or condition = "END" Or condition = "Undefined" Then Return "Invalid query. It contains a reserved word."
        If condition = "exec" Or condition = "xp_cmdshell" Then Return "Invalid query. It contains a reserved word."
        Try
            For i = 0 To condition.Length - 1
                If Asc(condition.Substring(i, 1)) > 255 Then Return "Invalid name. It contains characters that are unsupported."
            Next
        Catch
            Return "Invalid name. It contains characters that are unsupported."
        End Try
        Return "OK"
    End Function

    Public Function NameCheck(name As String, Optional exceptionId As Integer = -2, Optional range As Integer = -1) As String
        Dim i As Integer
        If name = "" Then Return "Invalid item name. It cannot be empty."
        If name.Contains(",") Then Return "Invalid item name. Item name cannot contain commas(,)."
        If name.Contains("'") Or name.Contains("""") Then Return "Invalid item name. It cannot contain quotation marks(',"")."
        If name.Contains("(") Or name.Contains(")") Or name.Contains("{") Or name.Contains("}") Then Return "Invalid item name. It cannot contain parentheses('()') or braces('{}')." + vbCrLf + "Brackets('[]') are recommended."
        If name = "START" Or name = "END" Or name = "Undefined" Then Return "Invalid item name. It contains a reserved word."
        If name = "exec" Or name = "xp_cmdshell" Then Return "Invalid item name. It contains a reserved word."
        If range = -1 Then range = currentItemNumber
        If currentItemNumber > 0 Then
            For i = 1 To range
                If name = itemName(i) And i <> exceptionId Then Return "Invalid item name. A item with the same name already exists."
            Next
        End If
        Try
            For i = 0 To name.Length - 1
                If Asc(name.Substring(i, 1)) > 255 Then Return "Invalid name. It contains characters that are unsupported."
            Next
        Catch
            Return "Invalid name. It contains characters that are unsupported."
        End Try
        Return "OK"
    End Function

    Public Function DurationCheck(duration As String) As String
        If duration = "" Then Return "Invalid item duration. It cannot be empty."
        If IsNumeric(duration) = False Or Val(duration) < 0 Then Return "Invalid item duration. It must be a positive integer."
        If duration.Contains(".") Or duration.Contains(",") Then Return "Invalid item duration. It must be an integer."
        Return "OK"
    End Function

    Public Function PrerequisiteCheck(prerequisite As String, range As Integer) As String
        Dim prereqArray() As String
        Dim prereqNumber, prereqInNames As Integer
        Dim i, j As Integer
        If prerequisite = "" Then Return "OK"
        If prerequisite = "," Then Return "Invalid prerequisite(s)."
        If prerequisite = "exec" Or prerequisite = "xp_cmdshell" Then Return "Invalid prerequisite(s). It contains a reserved word."
        If prerequisite.Contains("'") Or prerequisite.Contains("""") Then Return "Invalid prerequisite(s). It cannot contain quotation marks(',"")."
        If prerequisite.Contains("(") Or prerequisite.Contains(")") Or prerequisite.Contains("{") Or prerequisite.Contains("}") Then Return "Invalid prerequisite(s). It cannot contain parentheses('()') or braces('{}')." + vbCrLf + "Brackets('[]') are recommended."

        prereqArray = Split(prerequisite, ", ")
        prereqNumber = 1
        For i = 0 To prerequisite.Length - 1
            If prerequisite.Substring(i, 1) = "," Then prereqNumber = prereqNumber + 1
        Next

        For i = 0 To prereqNumber - 1
            prereqInNames = 0
            For j = 1 To range
                If prereqArray(i) = itemName(j) Then prereqInNames = 1
            Next
            If prereqInNames = 0 Then Return "Invalid Prerequisite(s). """ + prereqArray(i) + """ is not found."
            For j = 0 To i - 1
                If prereqArray(i) = prereqArray(j) Then
                    prereqInNames = 0
                    Return "Invalid Prerequisite(s). Repetition forbidden."
                End If
            Next
        Next

        Return "OK"

    End Function

End Module
