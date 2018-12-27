<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModifyDelete
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModifyDelete))
        Me.WebBrowserQueryResults = New System.Windows.Forms.WebBrowser()
        Me.ComboBoxFunction = New System.Windows.Forms.ComboBox()
        Me.TextBoxAddName = New System.Windows.Forms.TextBox()
        Me.TextBoxAddDuration = New System.Windows.Forms.TextBox()
        Me.TextBoxAddPrereq = New System.Windows.Forms.TextBox()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.LabelID = New System.Windows.Forms.Label()
        Me.TextBoxID = New System.Windows.Forms.TextBox()
        Me.TextBoxModifyName = New System.Windows.Forms.TextBox()
        Me.TextBoxModifyDuration = New System.Windows.Forms.TextBox()
        Me.TextBoxModifyPrereq = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'WebBrowserQueryResults
        '
        Me.WebBrowserQueryResults.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.WebBrowserQueryResults.Location = New System.Drawing.Point(0, 57)
        Me.WebBrowserQueryResults.Margin = New System.Windows.Forms.Padding(0)
        Me.WebBrowserQueryResults.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowserQueryResults.Name = "WebBrowserQueryResults"
        Me.WebBrowserQueryResults.Size = New System.Drawing.Size(941, 440)
        Me.WebBrowserQueryResults.TabIndex = 1
        '
        'ComboBoxFunction
        '
        Me.ComboBoxFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFunction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxFunction.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxFunction.FormattingEnabled = True
        Me.ComboBoxFunction.Items.AddRange(New Object() {"<none>", "Add", "Modify", "Delete"})
        Me.ComboBoxFunction.Location = New System.Drawing.Point(10, 3)
        Me.ComboBoxFunction.Margin = New System.Windows.Forms.Padding(1)
        Me.ComboBoxFunction.Name = "ComboBoxFunction"
        Me.ComboBoxFunction.Size = New System.Drawing.Size(152, 31)
        Me.ComboBoxFunction.TabIndex = 2
        '
        'TextBoxAddName
        '
        Me.TextBoxAddName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxAddName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAddName.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBoxAddName.Location = New System.Drawing.Point(179, 6)
        Me.TextBoxAddName.Name = "TextBoxAddName"
        Me.TextBoxAddName.Size = New System.Drawing.Size(202, 27)
        Me.TextBoxAddName.TabIndex = 3
        Me.TextBoxAddName.Text = " Name"
        Me.TextBoxAddName.Visible = False
        '
        'TextBoxAddDuration
        '
        Me.TextBoxAddDuration.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxAddDuration.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAddDuration.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBoxAddDuration.Location = New System.Drawing.Point(387, 6)
        Me.TextBoxAddDuration.Name = "TextBoxAddDuration"
        Me.TextBoxAddDuration.Size = New System.Drawing.Size(105, 27)
        Me.TextBoxAddDuration.TabIndex = 4
        Me.TextBoxAddDuration.Text = " Duration"
        Me.TextBoxAddDuration.Visible = False
        '
        'TextBoxAddPrereq
        '
        Me.TextBoxAddPrereq.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxAddPrereq.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAddPrereq.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBoxAddPrereq.Location = New System.Drawing.Point(498, 6)
        Me.TextBoxAddPrereq.Name = "TextBoxAddPrereq"
        Me.TextBoxAddPrereq.Size = New System.Drawing.Size(289, 27)
        Me.TextBoxAddPrereq.TabIndex = 5
        Me.TextBoxAddPrereq.Text = " Prerequisite(s)"
        Me.TextBoxAddPrereq.Visible = False
        '
        'ButtonOK
        '
        Me.ButtonOK.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOK.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.Location = New System.Drawing.Point(802, 6)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(87, 28)
        Me.ButtonOK.TabIndex = 6
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        Me.ButtonOK.Visible = False
        '
        'LabelID
        '
        Me.LabelID.AutoSize = True
        Me.LabelID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelID.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelID.Location = New System.Drawing.Point(175, 9)
        Me.LabelID.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelID.Name = "LabelID"
        Me.LabelID.Size = New System.Drawing.Size(39, 23)
        Me.LabelID.TabIndex = 32
        Me.LabelID.Text = "ID="
        Me.LabelID.Visible = False
        '
        'TextBoxID
        '
        Me.TextBoxID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TextBoxID.Location = New System.Drawing.Point(217, 6)
        Me.TextBoxID.Name = "TextBoxID"
        Me.TextBoxID.Size = New System.Drawing.Size(40, 27)
        Me.TextBoxID.TabIndex = 33
        Me.TextBoxID.Visible = False
        '
        'TextBoxModifyName
        '
        Me.TextBoxModifyName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxModifyName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxModifyName.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBoxModifyName.Location = New System.Drawing.Point(271, 6)
        Me.TextBoxModifyName.Name = "TextBoxModifyName"
        Me.TextBoxModifyName.Size = New System.Drawing.Size(110, 27)
        Me.TextBoxModifyName.TabIndex = 34
        Me.TextBoxModifyName.Text = " Name"
        Me.TextBoxModifyName.Visible = False
        '
        'TextBoxModifyDuration
        '
        Me.TextBoxModifyDuration.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxModifyDuration.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxModifyDuration.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBoxModifyDuration.Location = New System.Drawing.Point(387, 6)
        Me.TextBoxModifyDuration.Name = "TextBoxModifyDuration"
        Me.TextBoxModifyDuration.Size = New System.Drawing.Size(105, 27)
        Me.TextBoxModifyDuration.TabIndex = 35
        Me.TextBoxModifyDuration.Text = " Duration"
        Me.TextBoxModifyDuration.Visible = False
        '
        'TextBoxModifyPrereq
        '
        Me.TextBoxModifyPrereq.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxModifyPrereq.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxModifyPrereq.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBoxModifyPrereq.Location = New System.Drawing.Point(498, 6)
        Me.TextBoxModifyPrereq.Name = "TextBoxModifyPrereq"
        Me.TextBoxModifyPrereq.Size = New System.Drawing.Size(289, 27)
        Me.TextBoxModifyPrereq.TabIndex = 36
        Me.TextBoxModifyPrereq.Text = " Prerequisite(s)"
        Me.TextBoxModifyPrereq.Visible = False
        '
        'ModifyDelete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(941, 497)
        Me.Controls.Add(Me.TextBoxModifyPrereq)
        Me.Controls.Add(Me.TextBoxModifyDuration)
        Me.Controls.Add(Me.TextBoxModifyName)
        Me.Controls.Add(Me.TextBoxID)
        Me.Controls.Add(Me.LabelID)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.TextBoxAddPrereq)
        Me.Controls.Add(Me.TextBoxAddDuration)
        Me.Controls.Add(Me.TextBoxAddName)
        Me.Controls.Add(Me.ComboBoxFunction)
        Me.Controls.Add(Me.WebBrowserQueryResults)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(959, 544)
        Me.Name = "ModifyDelete"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modify & Delete"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WebBrowserQueryResults As Windows.Forms.WebBrowser
    Friend WithEvents ComboBoxFunction As Windows.Forms.ComboBox
    Friend WithEvents TextBoxAddName As Windows.Forms.TextBox
    Friend WithEvents TextBoxAddDuration As Windows.Forms.TextBox
    Friend WithEvents TextBoxAddPrereq As Windows.Forms.TextBox
    Friend WithEvents ButtonOK As Windows.Forms.Button
    Friend WithEvents LabelID As Windows.Forms.Label
    Friend WithEvents TextBoxID As Windows.Forms.TextBox
    Friend WithEvents TextBoxModifyName As Windows.Forms.TextBox
    Friend WithEvents TextBoxModifyDuration As Windows.Forms.TextBox
    Friend WithEvents TextBoxModifyPrereq As Windows.Forms.TextBox
End Class
