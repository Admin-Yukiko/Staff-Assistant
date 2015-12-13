<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetSkillDialog
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
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.GroupBox1 = New System.Windows.Forms.GroupBox
		Me.SkillList = New System.Windows.Forms.ComboBox
		Me.GroupBox2 = New System.Windows.Forms.GroupBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.SkillValue = New System.Windows.Forms.NumericUpDown
		Me.Label1 = New System.Windows.Forms.Label
		Me.TableLayoutPanel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.SkillValue, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(96, 196)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
		Me.TableLayoutPanel1.TabIndex = 2
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.OK_Button.Location = New System.Drawing.Point(3, 3)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(67, 23)
		Me.OK_Button.TabIndex = 0
		Me.OK_Button.Text = "OK"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
		Me.Cancel_Button.TabIndex = 1
		Me.Cancel_Button.Text = "Cancel"
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.SkillList)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(229, 75)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Select a skill to modify..."
		'
		'SkillList
        '
        Me.SkillList.FormattingEnabled = True
		Me.SkillList.Items.AddRange(New Object() {"Alchemy", "Anatomy", "AnimalLore", "ItemId", "ArmsLore", "Parry", "Begging", "Blacksmithy", "Bowcraft", "Peacemaking", "Camping", "Woodworking", "Cartography", "Cooking", "DetectingHidden", "Enticement", "EvaluatingIntelligence", "Healing", "Fishing", "ForensicEvaluation", "Herding", "Hiding", "Provocation", "Inscription", "Lockpicking", "Magery", "MagicResistance", "Tactics", "Snooping", "Musicianship", "Poisoning", "Archery", "SpiritSpeak", "Stealing", "Tailoring", "AnimalTaming", "TasteIdentification", "Tinkering", "Tracking", "Veterinary", "Swordsmanship", "Macefighting", "Fencing", "Wrestling", "Lumberjacking", "Mining", "Meditation", "Stealth", "RemoveTrap", "Necro", "Focus", "Chivalry", "Bushido", "Ninjitsu"})
		Me.SkillList.Location = New System.Drawing.Point(15, 29)
		Me.SkillList.Name = "SkillList"
		Me.SkillList.Size = New System.Drawing.Size(199, 21)
		Me.SkillList.TabIndex = 0
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.Label2)
		Me.GroupBox2.Controls.Add(Me.SkillValue)
		Me.GroupBox2.Controls.Add(Me.Label1)
		Me.GroupBox2.Location = New System.Drawing.Point(12, 93)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(229, 89)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Enter a value..."
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Location = New System.Drawing.Point(12, 64)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(203, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Note: A value of '1000' is equal to '100.0'."
		'
		'SkillValue
		'
		Me.SkillValue.Location = New System.Drawing.Point(80, 30)
		Me.SkillValue.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
		Me.SkillValue.Name = "SkillValue"
		Me.SkillValue.Size = New System.Drawing.Size(134, 20)
		Me.SkillValue.TabIndex = 0
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 32)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(62, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "New Value:"
		'
		'SetSkillDialog
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(254, 237)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "SetSkillDialog"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Set Skill..."
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		CType(Me.SkillValue, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents SkillList As System.Windows.Forms.ComboBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents SkillValue As System.Windows.Forms.NumericUpDown

End Class
