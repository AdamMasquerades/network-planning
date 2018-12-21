<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ButtonReadIn = New System.Windows.Forms.Button()
        Me.ButtonModifyDelete = New System.Windows.Forms.Button()
        Me.ButtonSearchView = New System.Windows.Forms.Button()
        Me.ButtonDrawGraph = New System.Windows.Forms.Button()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SendFeedbackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonReadIn
        '
        Me.ButtonReadIn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonReadIn.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonReadIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonReadIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonReadIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonReadIn.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonReadIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonReadIn.Location = New System.Drawing.Point(1, 28)
        Me.ButtonReadIn.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonReadIn.Name = "ButtonReadIn"
        Me.ButtonReadIn.Size = New System.Drawing.Size(255, 125)
        Me.ButtonReadIn.TabIndex = 0
        Me.ButtonReadIn.Text = "Read-In"
        Me.ButtonReadIn.UseVisualStyleBackColor = False
        '
        'ButtonModifyDelete
        '
        Me.ButtonModifyDelete.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonModifyDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonModifyDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonModifyDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonModifyDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonModifyDelete.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonModifyDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonModifyDelete.Location = New System.Drawing.Point(1, 154)
        Me.ButtonModifyDelete.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonModifyDelete.Name = "ButtonModifyDelete"
        Me.ButtonModifyDelete.Size = New System.Drawing.Size(255, 125)
        Me.ButtonModifyDelete.TabIndex = 2
        Me.ButtonModifyDelete.Text = "Modify && Delete"
        Me.ButtonModifyDelete.UseVisualStyleBackColor = False
        '
        'ButtonSearchView
        '
        Me.ButtonSearchView.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonSearchView.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonSearchView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonSearchView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonSearchView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSearchView.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSearchView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonSearchView.Location = New System.Drawing.Point(257, 28)
        Me.ButtonSearchView.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonSearchView.Name = "ButtonSearchView"
        Me.ButtonSearchView.Size = New System.Drawing.Size(255, 125)
        Me.ButtonSearchView.TabIndex = 3
        Me.ButtonSearchView.Text = "Search && View"
        Me.ButtonSearchView.UseVisualStyleBackColor = False
        '
        'ButtonDrawGraph
        '
        Me.ButtonDrawGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonDrawGraph.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonDrawGraph.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonDrawGraph.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonDrawGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDrawGraph.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDrawGraph.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonDrawGraph.Location = New System.Drawing.Point(257, 154)
        Me.ButtonDrawGraph.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonDrawGraph.Name = "ButtonDrawGraph"
        Me.ButtonDrawGraph.Size = New System.Drawing.Size(255, 125)
        Me.ButtonDrawGraph.TabIndex = 4
        Me.ButtonDrawGraph.Text = "Draw Graph"
        Me.ButtonDrawGraph.UseVisualStyleBackColor = False
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(513, 28)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectToolStripMenuItem, Me.OpenProjectToolStripMenuItem, Me.ToolStripMenuItem1, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripMenuItem2, Me.CloseToolStripMenuItem, Me.ToolStripMenuItem5, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewProjectToolStripMenuItem
        '
        Me.NewProjectToolStripMenuItem.Name = "NewProjectToolStripMenuItem"
        Me.NewProjectToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewProjectToolStripMenuItem.Size = New System.Drawing.Size(232, 26)
        Me.NewProjectToolStripMenuItem.Text = "New..."
        '
        'OpenProjectToolStripMenuItem
        '
        Me.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem"
        Me.OpenProjectToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenProjectToolStripMenuItem.Size = New System.Drawing.Size(232, 26)
        Me.OpenProjectToolStripMenuItem.Text = "Open Project..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(229, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(232, 26)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(232, 26)
        Me.SaveAsToolStripMenuItem.Text = "Save As..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(229, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(232, 26)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(229, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(232, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewHelpToolStripMenuItem, Me.ToolStripMenuItem3, Me.SendFeedbackToolStripMenuItem, Me.ToolStripMenuItem4, Me.CheckForUpdatesToolStripMenuItem, Me.AboutToolStripMenuItem1})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(53, 24)
        Me.AboutToolStripMenuItem.Text = "Help"
        '
        'ViewHelpToolStripMenuItem
        '
        Me.ViewHelpToolStripMenuItem.Name = "ViewHelpToolStripMenuItem"
        Me.ViewHelpToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.ViewHelpToolStripMenuItem.Text = "View Help"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(213, 6)
        '
        'SendFeedbackToolStripMenuItem
        '
        Me.SendFeedbackToolStripMenuItem.Name = "SendFeedbackToolStripMenuItem"
        Me.SendFeedbackToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.SendFeedbackToolStripMenuItem.Text = "Send Feedback"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(213, 6)
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.CheckForUpdatesToolStripMenuItem.Text = "Check for Updates"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(216, 26)
        Me.AboutToolStripMenuItem1.Text = "About"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(513, 280)
        Me.Controls.Add(Me.ButtonReadIn)
        Me.Controls.Add(Me.ButtonDrawGraph)
        Me.Controls.Add(Me.ButtonSearchView)
        Me.Controls.Add(Me.ButtonModifyDelete)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(320, 200)
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Network Planning"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonReadIn As Windows.Forms.Button
    Friend WithEvents ButtonModifyDelete As Windows.Forms.Button
    Friend WithEvents ButtonSearchView As Windows.Forms.Button
    Friend WithEvents ButtonDrawGraph As Windows.Forms.Button
    Friend WithEvents MenuStrip As Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewProjectToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenProjectToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewHelpToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As Windows.Forms.ToolStripSeparator
    Friend WithEvents SendFeedbackToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As Windows.Forms.ToolStripSeparator
    Friend WithEvents CheckForUpdatesToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
End Class
