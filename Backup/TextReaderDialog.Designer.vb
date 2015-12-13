<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextReaderDialog
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextReaderDialog))
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.BrowseBtn = New System.Windows.Forms.Button
		Me.ScriptFile = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.ScriptFileLines = New System.Windows.Forms.CheckedListBox
		Me.GroupBox1 = New System.Windows.Forms.GroupBox
		Me.FastForwardBtn = New System.Windows.Forms.Button
		Me.StopBtn = New System.Windows.Forms.Button
		Me.ForwardBtn = New System.Windows.Forms.Button
		Me.PlayPauseBtn = New System.Windows.Forms.Button
		Me.ReverseBtn = New System.Windows.Forms.Button
		Me.RewindBtn = New System.Windows.Forms.Button
		Me.YellSpeechChk = New System.Windows.Forms.CheckBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.HelpProvider = New System.Windows.Forms.HelpProvider
		Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
		Me.GroupBox2 = New System.Windows.Forms.GroupBox
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.SpeechSpeed = New System.Windows.Forms.TrackBar
		Me.TableLayoutPanel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.SpeechSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 1
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 0, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(280, 286)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(74, 58)
		Me.TableLayoutPanel1.TabIndex = 0
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(3, 17)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
		Me.Cancel_Button.TabIndex = 1
		Me.Cancel_Button.Text = "Close"
		'
		'BrowseBtn
		'
		Me.BrowseBtn.Location = New System.Drawing.Point(280, 23)
		Me.BrowseBtn.Name = "BrowseBtn"
		Me.BrowseBtn.Size = New System.Drawing.Size(75, 23)
		Me.BrowseBtn.TabIndex = 1
		Me.BrowseBtn.Text = "Browse..."
		Me.BrowseBtn.UseVisualStyleBackColor = True
		'
		'ScriptFile
		'
		Me.ScriptFile.BackColor = System.Drawing.SystemColors.Window
		Me.ScriptFile.Location = New System.Drawing.Point(12, 25)
		Me.ScriptFile.Name = "ScriptFile"
		Me.ScriptFile.ReadOnly = True
		Me.ScriptFile.Size = New System.Drawing.Size(258, 20)
		Me.ScriptFile.TabIndex = 2
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(53, 13)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Script File"
		'
		'ScriptFileLines
		'
		Me.ScriptFileLines.CheckOnClick = True
		Me.ScriptFileLines.FormattingEnabled = True
		Me.ScriptFileLines.HorizontalScrollbar = True
		Me.ScriptFileLines.Location = New System.Drawing.Point(11, 84)
		Me.ScriptFileLines.Name = "ScriptFileLines"
		Me.ScriptFileLines.ScrollAlwaysVisible = True
		Me.HelpProvider.SetShowHelp(Me.ScriptFileLines, True)
		Me.ScriptFileLines.Size = New System.Drawing.Size(343, 139)
		Me.ScriptFileLines.TabIndex = 4
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.FastForwardBtn)
		Me.GroupBox1.Controls.Add(Me.StopBtn)
		Me.GroupBox1.Controls.Add(Me.ForwardBtn)
		Me.GroupBox1.Controls.Add(Me.PlayPauseBtn)
		Me.GroupBox1.Controls.Add(Me.ReverseBtn)
		Me.GroupBox1.Controls.Add(Me.RewindBtn)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 229)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(343, 51)
		Me.GroupBox1.TabIndex = 5
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Controls"
		'
		'FastForwardBtn
		'
		Me.FastForwardBtn.Image = Global.Nightscape_Staff_Assistant.My.Resources.Resources.fast_forward
		Me.FastForwardBtn.Location = New System.Drawing.Point(275, 19)
		Me.FastForwardBtn.Name = "FastForwardBtn"
		Me.FastForwardBtn.Size = New System.Drawing.Size(52, 23)
		Me.FastForwardBtn.TabIndex = 5
		Me.ToolTip.SetToolTip(Me.FastForwardBtn, "Fast Forward")
		Me.FastForwardBtn.UseVisualStyleBackColor = True
		'
		'StopBtn
		'
		Me.StopBtn.Image = Global.Nightscape_Staff_Assistant.My.Resources.Resources.stop_icon
		Me.StopBtn.Location = New System.Drawing.Point(166, 19)
		Me.StopBtn.Name = "StopBtn"
		Me.StopBtn.Size = New System.Drawing.Size(51, 23)
		Me.StopBtn.TabIndex = 4
		Me.ToolTip.SetToolTip(Me.StopBtn, "Stop")
		Me.StopBtn.UseVisualStyleBackColor = True
		'
		'ForwardBtn
		'
		Me.ForwardBtn.Image = Global.Nightscape_Staff_Assistant.My.Resources.Resources.forward
		Me.ForwardBtn.Location = New System.Drawing.Point(223, 19)
		Me.ForwardBtn.Name = "ForwardBtn"
		Me.ForwardBtn.Size = New System.Drawing.Size(46, 23)
		Me.ForwardBtn.TabIndex = 3
		Me.ToolTip.SetToolTip(Me.ForwardBtn, "Forward 1 Line")
		Me.ForwardBtn.UseVisualStyleBackColor = True
		'
		'PlayPauseBtn
		'
		Me.PlayPauseBtn.Image = Global.Nightscape_Staff_Assistant.My.Resources.Resources.play
		Me.PlayPauseBtn.Location = New System.Drawing.Point(112, 19)
		Me.PlayPauseBtn.Name = "PlayPauseBtn"
		Me.PlayPauseBtn.Size = New System.Drawing.Size(48, 23)
		Me.PlayPauseBtn.TabIndex = 2
		Me.ToolTip.SetToolTip(Me.PlayPauseBtn, "Play")
		Me.PlayPauseBtn.UseVisualStyleBackColor = True
		'
		'ReverseBtn
		'
		Me.ReverseBtn.Image = Global.Nightscape_Staff_Assistant.My.Resources.Resources.reverse
		Me.ReverseBtn.Location = New System.Drawing.Point(59, 19)
		Me.ReverseBtn.Name = "ReverseBtn"
		Me.ReverseBtn.Size = New System.Drawing.Size(47, 23)
		Me.ReverseBtn.TabIndex = 1
		Me.ToolTip.SetToolTip(Me.ReverseBtn, "Back 1 Line")
		Me.ReverseBtn.UseVisualStyleBackColor = True
		'
		'RewindBtn
		'
		Me.RewindBtn.Image = Global.Nightscape_Staff_Assistant.My.Resources.Resources.rewind
		Me.RewindBtn.Location = New System.Drawing.Point(6, 19)
		Me.RewindBtn.Name = "RewindBtn"
		Me.RewindBtn.Size = New System.Drawing.Size(47, 23)
		Me.RewindBtn.TabIndex = 0
		Me.ToolTip.SetToolTip(Me.RewindBtn, "Rewind")
		Me.RewindBtn.UseVisualStyleBackColor = True
		'
		'YellSpeechChk
		'
		Me.YellSpeechChk.AutoSize = True
		Me.YellSpeechChk.Location = New System.Drawing.Point(258, 61)
		Me.YellSpeechChk.Name = "YellSpeechChk"
		Me.YellSpeechChk.Size = New System.Drawing.Size(96, 17)
		Me.YellSpeechChk.TabIndex = 6
		Me.YellSpeechChk.Text = "Yell all Speech"
		Me.YellSpeechChk.UseVisualStyleBackColor = True
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(12, 68)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(34, 13)
		Me.Label2.TabIndex = 7
		Me.Label2.Text = "Script"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.Label7)
		Me.GroupBox2.Controls.Add(Me.Label6)
		Me.GroupBox2.Controls.Add(Me.Label5)
		Me.GroupBox2.Controls.Add(Me.Label4)
		Me.GroupBox2.Controls.Add(Me.Label3)
		Me.GroupBox2.Controls.Add(Me.SpeechSpeed)
		Me.GroupBox2.Location = New System.Drawing.Point(11, 286)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(263, 58)
		Me.GroupBox2.TabIndex = 8
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Speech Speed in Seconds"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(241, 41)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(13, 13)
		Me.Label7.TabIndex = 5
		Me.Label7.Text = "5"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(183, 41)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(13, 13)
		Me.Label6.TabIndex = 4
		Me.Label6.Text = "4"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(126, 41)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(13, 13)
		Me.Label5.TabIndex = 3
		Me.Label5.Text = "3"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(68, 41)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(13, 13)
		Me.Label4.TabIndex = 2
		Me.Label4.Text = "2"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(10, 41)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(13, 13)
		Me.Label3.TabIndex = 1
		Me.Label3.Text = "1"
		'
		'SpeechSpeed
		'
		Me.SpeechSpeed.AutoSize = False
		Me.SpeechSpeed.LargeChange = 1
		Me.SpeechSpeed.Location = New System.Drawing.Point(7, 17)
		Me.SpeechSpeed.Maximum = 5
		Me.SpeechSpeed.Minimum = 1
		Me.SpeechSpeed.Name = "SpeechSpeed"
		Me.SpeechSpeed.Size = New System.Drawing.Size(250, 21)
		Me.SpeechSpeed.TabIndex = 0
		Me.SpeechSpeed.Value = 3
		'
		'TextReaderDialog
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(366, 356)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.YellSpeechChk)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.ScriptFileLines)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.ScriptFile)
		Me.Controls.Add(Me.BrowseBtn)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.HelpButton = True
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "TextReaderDialog"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Text to Speech Reader"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		CType(Me.SpeechSpeed, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents BrowseBtn As System.Windows.Forms.Button
	Friend WithEvents ScriptFile As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents ScriptFileLines As System.Windows.Forms.CheckedListBox
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents YellSpeechChk As System.Windows.Forms.CheckBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
	Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
	Friend WithEvents FastForwardBtn As System.Windows.Forms.Button
	Friend WithEvents StopBtn As System.Windows.Forms.Button
	Friend WithEvents ForwardBtn As System.Windows.Forms.Button
	Friend WithEvents PlayPauseBtn As System.Windows.Forms.Button
	Friend WithEvents ReverseBtn As System.Windows.Forms.Button
	Friend WithEvents RewindBtn As System.Windows.Forms.Button
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents SpeechSpeed As System.Windows.Forms.TrackBar
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
