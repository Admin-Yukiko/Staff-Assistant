<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuildingToolbar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Me.NudgeNBtn = New System.Windows.Forms.Button
		Me.NudgeWBtn = New System.Windows.Forms.Button
		Me.NudgeEBtn = New System.Windows.Forms.Button
		Me.NudgeSBtn = New System.Windows.Forms.Button
		Me.DestroyBtn = New System.Windows.Forms.Button
		Me.LockRadiusBtn = New System.Windows.Forms.Button
		Me.MassMoveBtn = New System.Windows.Forms.Button
		Me.CopyPasteBtn = New System.Windows.Forms.Button
		Me.RenameBtn = New System.Windows.Forms.Button
		Me.TeleBtn = New System.Windows.Forms.Button
		Me.RandTileBtn = New System.Windows.Forms.Button
		Me.NudgeDBtn = New System.Windows.Forms.Button
		Me.NudgeUBtn = New System.Windows.Forms.Button
		Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.MReplaceBtn = New System.Windows.Forms.Button
		Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
		Me.SuspendLayout()
		'
		'NudgeNBtn
		'
		Me.NudgeNBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NudgeNBtn.Location = New System.Drawing.Point(22, 1)
		Me.NudgeNBtn.Name = "NudgeNBtn"
		Me.NudgeNBtn.Size = New System.Drawing.Size(22, 20)
		Me.NudgeNBtn.TabIndex = 0
		Me.NudgeNBtn.Text = "N"
		Me.ToolTip.SetToolTip(Me.NudgeNBtn, "Nudge North" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hold Ctrl to nudge multiple times, Shift to copy, and both to copy" & _
						" multiple times.")
		Me.NudgeNBtn.UseVisualStyleBackColor = True
		'
		'NudgeWBtn
		'
		Me.NudgeWBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NudgeWBtn.Location = New System.Drawing.Point(0, 12)
		Me.NudgeWBtn.Name = "NudgeWBtn"
		Me.NudgeWBtn.Size = New System.Drawing.Size(22, 20)
		Me.NudgeWBtn.TabIndex = 1
		Me.NudgeWBtn.Text = "W"
		Me.ToolTip.SetToolTip(Me.NudgeWBtn, "Nudge West" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hold Ctrl to nudge multiple times, Shift to copy, and both to copy " & _
						"multiple times.")
		Me.NudgeWBtn.UseVisualStyleBackColor = True
		'
		'NudgeEBtn
		'
		Me.NudgeEBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NudgeEBtn.Location = New System.Drawing.Point(44, 12)
		Me.NudgeEBtn.Name = "NudgeEBtn"
		Me.NudgeEBtn.Size = New System.Drawing.Size(22, 20)
		Me.NudgeEBtn.TabIndex = 2
		Me.NudgeEBtn.Text = "E"
		Me.ToolTip.SetToolTip(Me.NudgeEBtn, "Nudge East" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hold Ctrl to nudge multiple times, Shift to copy, and both to copy " & _
						"multiple times.")
		Me.NudgeEBtn.UseVisualStyleBackColor = True
		'
		'NudgeSBtn
		'
		Me.NudgeSBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NudgeSBtn.Location = New System.Drawing.Point(22, 26)
		Me.NudgeSBtn.Name = "NudgeSBtn"
		Me.NudgeSBtn.Size = New System.Drawing.Size(22, 20)
		Me.NudgeSBtn.TabIndex = 3
		Me.NudgeSBtn.Text = "S"
		Me.ToolTip.SetToolTip(Me.NudgeSBtn, "Nudge South" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hold Ctrl to nudge multiple times, Shift to copy, and both to copy" & _
						" multiple times.")
		Me.NudgeSBtn.UseVisualStyleBackColor = True
		'
		'DestroyBtn
		'
		Me.DestroyBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DestroyBtn.Location = New System.Drawing.Point(0, 148)
		Me.DestroyBtn.Name = "DestroyBtn"
		Me.DestroyBtn.Size = New System.Drawing.Size(66, 25)
		Me.DestroyBtn.TabIndex = 4
		Me.DestroyBtn.Text = "Destroy"
		Me.ToolTip.SetToolTip(Me.DestroyBtn, "Destroys the selected item.")
		Me.DestroyBtn.UseVisualStyleBackColor = True
		'
		'LockRadiusBtn
		'
		Me.LockRadiusBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LockRadiusBtn.Location = New System.Drawing.Point(0, 172)
		Me.LockRadiusBtn.Name = "LockRadiusBtn"
		Me.LockRadiusBtn.Size = New System.Drawing.Size(66, 25)
		Me.LockRadiusBtn.TabIndex = 5
		Me.LockRadiusBtn.Text = "LckRadius 5"
		Me.ToolTip.SetToolTip(Me.LockRadiusBtn, "Lockdown all items within 5 tiles from you.")
		Me.LockRadiusBtn.UseVisualStyleBackColor = True
		'
		'MassMoveBtn
		'
		Me.MassMoveBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MassMoveBtn.Location = New System.Drawing.Point(0, 100)
		Me.MassMoveBtn.Name = "MassMoveBtn"
		Me.MassMoveBtn.Size = New System.Drawing.Size(66, 25)
		Me.MassMoveBtn.TabIndex = 6
		Me.MassMoveBtn.Text = "MassMove"
		Me.ToolTip.SetToolTip(Me.MassMoveBtn, "Massmove a large amount of items.")
		Me.MassMoveBtn.UseVisualStyleBackColor = True
		'
		'CopyPasteBtn
		'
		Me.CopyPasteBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CopyPasteBtn.Location = New System.Drawing.Point(0, 124)
		Me.CopyPasteBtn.Name = "CopyPasteBtn"
		Me.CopyPasteBtn.Size = New System.Drawing.Size(66, 25)
		Me.CopyPasteBtn.TabIndex = 7
		Me.CopyPasteBtn.Text = "CopyPaste"
		Me.ToolTip.SetToolTip(Me.CopyPasteBtn, "Copy an area and paste it elsewhere all in one command.")
		Me.CopyPasteBtn.UseVisualStyleBackColor = True
		'
		'RenameBtn
		'
		Me.RenameBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RenameBtn.Location = New System.Drawing.Point(0, 196)
		Me.RenameBtn.Name = "RenameBtn"
		Me.RenameBtn.Size = New System.Drawing.Size(66, 25)
		Me.RenameBtn.TabIndex = 8
		Me.RenameBtn.Text = "Rename"
		Me.ToolTip.SetToolTip(Me.RenameBtn, "Renames the selected item the name specified in the popup window.")
		Me.RenameBtn.UseVisualStyleBackColor = True
		'
		'TeleBtn
		'
		Me.TeleBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TeleBtn.Location = New System.Drawing.Point(0, 244)
		Me.TeleBtn.Name = "TeleBtn"
		Me.TeleBtn.Size = New System.Drawing.Size(66, 25)
		Me.TeleBtn.TabIndex = 9
		Me.TeleBtn.Text = "Tele"
		Me.ToolTip.SetToolTip(Me.TeleBtn, "Teleports you to the targeted location.")
		Me.TeleBtn.UseVisualStyleBackColor = True
		'
		'RandTileBtn
		'
		Me.RandTileBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RandTileBtn.Location = New System.Drawing.Point(0, 76)
		Me.RandTileBtn.Name = "RandTileBtn"
		Me.RandTileBtn.Size = New System.Drawing.Size(66, 25)
		Me.RandTileBtn.TabIndex = 10
		Me.RandTileBtn.Text = "RandTile"
		Me.ToolTip.SetToolTip(Me.RandTileBtn, "Open the Random tile dialog...")
		Me.RandTileBtn.UseVisualStyleBackColor = True
		'
		'NudgeDBtn
		'
		Me.NudgeDBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NudgeDBtn.Location = New System.Drawing.Point(35, 51)
		Me.NudgeDBtn.Name = "NudgeDBtn"
		Me.NudgeDBtn.Size = New System.Drawing.Size(22, 20)
		Me.NudgeDBtn.TabIndex = 12
		Me.NudgeDBtn.Text = "D"
		Me.ToolTip.SetToolTip(Me.NudgeDBtn, "Nudge Down" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hold Ctrl to nudge multiple times, Shift to copy, and both to copy " & _
						"multiple times.")
		Me.NudgeDBtn.UseVisualStyleBackColor = True
		'
		'NudgeUBtn
		'
		Me.NudgeUBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NudgeUBtn.Location = New System.Drawing.Point(7, 51)
		Me.NudgeUBtn.Name = "NudgeUBtn"
		Me.NudgeUBtn.Size = New System.Drawing.Size(22, 20)
		Me.NudgeUBtn.TabIndex = 11
		Me.NudgeUBtn.Text = "U"
		Me.ToolTip.SetToolTip(Me.NudgeUBtn, "Nudge Up" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hold Ctrl to nudge multiple times, Shift to copy, and both to copy mu" & _
						"ltiple times.")
		Me.NudgeUBtn.UseVisualStyleBackColor = True
		'
		'TableLayoutPanel4
		'
		Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
		Me.TableLayoutPanel4.ColumnCount = 1
		Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel4.Location = New System.Drawing.Point(1, 48)
		Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
		Me.TableLayoutPanel4.RowCount = 1
		Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel4.Size = New System.Drawing.Size(65, 2)
		Me.TableLayoutPanel4.TabIndex = 16
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
		Me.TableLayoutPanel1.ColumnCount = 1
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(1, 73)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(65, 2)
		Me.TableLayoutPanel1.TabIndex = 17
		'
		'MReplaceBtn
		'
		Me.MReplaceBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MReplaceBtn.Location = New System.Drawing.Point(0, 220)
		Me.MReplaceBtn.Name = "MReplaceBtn"
		Me.MReplaceBtn.Size = New System.Drawing.Size(66, 25)
		Me.MReplaceBtn.TabIndex = 18
		Me.MReplaceBtn.Text = "MReplace"
		Me.ToolTip.SetToolTip(Me.MReplaceBtn, "Replaces an item with the specified source item.")
		Me.MReplaceBtn.UseVisualStyleBackColor = True
		'
		'BuildingToolbar
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
		Me.ClientSize = New System.Drawing.Size(66, 269)
		Me.Controls.Add(Me.MReplaceBtn)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.Controls.Add(Me.TableLayoutPanel4)
		Me.Controls.Add(Me.NudgeDBtn)
		Me.Controls.Add(Me.NudgeUBtn)
		Me.Controls.Add(Me.RandTileBtn)
		Me.Controls.Add(Me.TeleBtn)
		Me.Controls.Add(Me.RenameBtn)
		Me.Controls.Add(Me.CopyPasteBtn)
		Me.Controls.Add(Me.MassMoveBtn)
		Me.Controls.Add(Me.LockRadiusBtn)
		Me.Controls.Add(Me.DestroyBtn)
		Me.Controls.Add(Me.NudgeSBtn)
		Me.Controls.Add(Me.NudgeEBtn)
		Me.Controls.Add(Me.NudgeWBtn)
		Me.Controls.Add(Me.NudgeNBtn)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "BuildingToolbar"
		Me.Opacity = 0.99
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "BuildBar"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents NudgeNBtn As System.Windows.Forms.Button
	Friend WithEvents NudgeWBtn As System.Windows.Forms.Button
	Friend WithEvents NudgeEBtn As System.Windows.Forms.Button
	Friend WithEvents NudgeSBtn As System.Windows.Forms.Button
	Friend WithEvents DestroyBtn As System.Windows.Forms.Button
	Friend WithEvents LockRadiusBtn As System.Windows.Forms.Button
	Friend WithEvents MassMoveBtn As System.Windows.Forms.Button
	Friend WithEvents CopyPasteBtn As System.Windows.Forms.Button
	Friend WithEvents RenameBtn As System.Windows.Forms.Button
	Friend WithEvents TeleBtn As System.Windows.Forms.Button
	Friend WithEvents RandTileBtn As System.Windows.Forms.Button
	Friend WithEvents NudgeDBtn As System.Windows.Forms.Button
	Friend WithEvents NudgeUBtn As System.Windows.Forms.Button
	Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents MReplaceBtn As System.Windows.Forms.Button
	Friend WithEvents ToolTip As System.Windows.Forms.ToolTip

End Class
