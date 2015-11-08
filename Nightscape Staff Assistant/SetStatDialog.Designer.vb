<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetStatDialog
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
		Me.Stamina = New System.Windows.Forms.RadioButton
		Me.Intelligence = New System.Windows.Forms.RadioButton
		Me.Strength = New System.Windows.Forms.RadioButton
		Me.GroupBox2 = New System.Windows.Forms.GroupBox
		Me.StatValue = New System.Windows.Forms.NumericUpDown
		Me.Label1 = New System.Windows.Forms.Label
		Me.TableLayoutPanel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.StatValue, System.ComponentModel.ISupportInitialize).BeginInit()
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
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(67, 197)
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
		Me.GroupBox1.Controls.Add(Me.Stamina)
		Me.GroupBox1.Controls.Add(Me.Intelligence)
		Me.GroupBox1.Controls.Add(Me.Strength)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(200, 98)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Select stat to modify..."
		'
		'Stamina
		'
		Me.Stamina.AutoSize = True
		Me.Stamina.Location = New System.Drawing.Point(18, 44)
		Me.Stamina.Name = "Stamina"
		Me.Stamina.Size = New System.Drawing.Size(63, 17)
		Me.Stamina.TabIndex = 1
		Me.Stamina.Text = "Stamina"
		Me.Stamina.UseVisualStyleBackColor = True
		'
		'Intelligence
		'
		Me.Intelligence.AutoSize = True
		Me.Intelligence.Location = New System.Drawing.Point(18, 67)
		Me.Intelligence.Name = "Intelligence"
		Me.Intelligence.Size = New System.Drawing.Size(79, 17)
		Me.Intelligence.TabIndex = 2
		Me.Intelligence.Text = "Intelligence"
		Me.Intelligence.UseVisualStyleBackColor = True
		'
		'Strength
		'
		Me.Strength.AutoSize = True
		Me.Strength.Checked = True
		Me.Strength.Location = New System.Drawing.Point(18, 21)
		Me.Strength.Name = "Strength"
		Me.Strength.Size = New System.Drawing.Size(65, 17)
		Me.Strength.TabIndex = 0
		Me.Strength.TabStop = True
		Me.Strength.Text = "Strength"
		Me.Strength.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.StatValue)
		Me.GroupBox2.Controls.Add(Me.Label1)
		Me.GroupBox2.Location = New System.Drawing.Point(12, 116)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(200, 69)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Enter a value..."
		'
		'StatValue
		'
		Me.StatValue.Location = New System.Drawing.Point(83, 27)
		Me.StatValue.Name = "StatValue"
		Me.StatValue.Size = New System.Drawing.Size(97, 20)
		Me.StatValue.TabIndex = 0
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(15, 29)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(62, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "New Value:"
		'
		'SetStatDialog
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(225, 238)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "SetStatDialog"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Set Stat..."
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		CType(Me.StatValue, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Stamina As System.Windows.Forms.RadioButton
  Friend WithEvents Intelligence As System.Windows.Forms.RadioButton
  Friend WithEvents Strength As System.Windows.Forms.RadioButton
  Friend WithEvents StatValue As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
