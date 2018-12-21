<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchView))
        Me.WebBrowserQueryResults = New System.Windows.Forms.WebBrowser()
        Me.PanelQuery = New System.Windows.Forms.Panel()
        Me.ButtonOrder = New System.Windows.Forms.Button()
        Me.ComboBoxOrderBy = New System.Windows.Forms.ComboBox()
        Me.TextBoxCondition = New System.Windows.Forms.TextBox()
        Me.ComboBoxCondition = New System.Windows.Forms.ComboBox()
        Me.ComboBoxItem = New System.Windows.Forms.ComboBox()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.PanelQuery.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebBrowserQueryResults
        '
        Me.WebBrowserQueryResults.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.WebBrowserQueryResults.Location = New System.Drawing.Point(0, 73)
        Me.WebBrowserQueryResults.Margin = New System.Windows.Forms.Padding(0)
        Me.WebBrowserQueryResults.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowserQueryResults.Name = "WebBrowserQueryResults"
        Me.WebBrowserQueryResults.Size = New System.Drawing.Size(1082, 512)
        Me.WebBrowserQueryResults.TabIndex = 0
        '
        'PanelQuery
        '
        Me.PanelQuery.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PanelQuery.Controls.Add(Me.ButtonOrder)
        Me.PanelQuery.Controls.Add(Me.ComboBoxOrderBy)
        Me.PanelQuery.Controls.Add(Me.TextBoxCondition)
        Me.PanelQuery.Controls.Add(Me.ComboBoxCondition)
        Me.PanelQuery.Controls.Add(Me.ComboBoxItem)
        Me.PanelQuery.Controls.Add(Me.ButtonOK)
        Me.PanelQuery.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelQuery.Location = New System.Drawing.Point(0, 0)
        Me.PanelQuery.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelQuery.Name = "PanelQuery"
        Me.PanelQuery.Size = New System.Drawing.Size(1082, 53)
        Me.PanelQuery.TabIndex = 1
        '
        'ButtonOrder
        '
        Me.ButtonOrder.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ButtonOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ButtonOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ButtonOrder.FlatAppearance.BorderSize = 0
        Me.ButtonOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ButtonOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ButtonOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOrder.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonOrder.Location = New System.Drawing.Point(942, -1)
        Me.ButtonOrder.Name = "ButtonOrder"
        Me.ButtonOrder.Size = New System.Drawing.Size(37, 33)
        Me.ButtonOrder.TabIndex = 5
        Me.ButtonOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonOrder.UseVisualStyleBackColor = False
        '
        'ComboBoxOrderBy
        '
        Me.ComboBoxOrderBy.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBoxOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxOrderBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxOrderBy.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxOrderBy.FormattingEnabled = True
        Me.ComboBoxOrderBy.Items.AddRange(New Object() {"<sort by>", "ID", "Name", "Duration"})
        Me.ComboBoxOrderBy.Location = New System.Drawing.Point(801, 2)
        Me.ComboBoxOrderBy.Name = "ComboBoxOrderBy"
        Me.ComboBoxOrderBy.Size = New System.Drawing.Size(135, 31)
        Me.ComboBoxOrderBy.TabIndex = 4
        '
        'TextBoxCondition
        '
        Me.TextBoxCondition.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxCondition.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCondition.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCondition.Location = New System.Drawing.Point(308, 6)
        Me.TextBoxCondition.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBoxCondition.Name = "TextBoxCondition"
        Me.TextBoxCondition.Size = New System.Drawing.Size(484, 27)
        Me.TextBoxCondition.TabIndex = 3
        '
        'ComboBoxCondition
        '
        Me.ComboBoxCondition.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBoxCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCondition.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxCondition.FormattingEnabled = True
        Me.ComboBoxCondition.Location = New System.Drawing.Point(165, 2)
        Me.ComboBoxCondition.Name = "ComboBoxCondition"
        Me.ComboBoxCondition.Size = New System.Drawing.Size(134, 31)
        Me.ComboBoxCondition.TabIndex = 2
        '
        'ComboBoxItem
        '
        Me.ComboBoxItem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBoxItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxItem.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxItem.FormattingEnabled = True
        Me.ComboBoxItem.Items.AddRange(New Object() {"<column>", "All", "ID", "Name", "Duration", "Prerequisite(s)"})
        Me.ComboBoxItem.Location = New System.Drawing.Point(9, 2)
        Me.ComboBoxItem.Margin = New System.Windows.Forms.Padding(1)
        Me.ComboBoxItem.Name = "ComboBoxItem"
        Me.ComboBoxItem.Size = New System.Drawing.Size(152, 31)
        Me.ComboBoxItem.TabIndex = 1
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ButtonOK.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOK.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonOK.Location = New System.Drawing.Point(998, 2)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(81, 31)
        Me.ButtonOK.TabIndex = 0
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'SearchView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1082, 585)
        Me.Controls.Add(Me.PanelQuery)
        Me.Controls.Add(Me.WebBrowserQueryResults)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1100, 450)
        Me.Name = "SearchView"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search & View"
        Me.PanelQuery.ResumeLayout(False)
        Me.PanelQuery.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WebBrowserQueryResults As Windows.Forms.WebBrowser
    Friend WithEvents PanelQuery As Windows.Forms.Panel
    Friend WithEvents ButtonOK As Windows.Forms.Button
    Friend WithEvents ComboBoxItem As Windows.Forms.ComboBox
    Friend WithEvents ComboBoxCondition As Windows.Forms.ComboBox
    Friend WithEvents TextBoxCondition As Windows.Forms.TextBox
    Friend WithEvents ButtonOrder As Windows.Forms.Button
    Friend WithEvents ComboBoxOrderBy As Windows.Forms.ComboBox
End Class
