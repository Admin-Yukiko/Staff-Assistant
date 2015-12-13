<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PromptToUpdate
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
    Me.Label1 = New System.Windows.Forms.Label
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.Update1 = New System.Windows.Forms.CheckBox
    Me.Update2 = New System.Windows.Forms.CheckBox
    Me.Update3 = New System.Windows.Forms.CheckBox
    Me.Update4 = New System.Windows.Forms.CheckBox
    Me.Update5 = New System.Windows.Forms.CheckBox
    Me.CheckBox6 = New System.Windows.Forms.CheckBox
    Me.TableLayoutPanel1.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.ColumnCount = 3
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 2, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 1, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBox6, 0, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 108)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(297, 36)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'OK_Button
    '
    Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.OK_Button.Location = New System.Drawing.Point(150, 6)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(67, 23)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Location = New System.Drawing.Point(225, 6)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Cancel"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(268, 26)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Updates are available for the following items, which you" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "chose not to download a" & _
        "nd install automatically"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Update5)
    Me.GroupBox1.Controls.Add(Me.Update4)
    Me.GroupBox1.Controls.Add(Me.Update3)
    Me.GroupBox1.Controls.Add(Me.Update2)
    Me.GroupBox1.Controls.Add(Me.Update1)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 49)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(297, 49)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Select the updates to install..."
    '
    'Update1
    '
    Me.Update1.AutoSize = True
    Me.Update1.Location = New System.Drawing.Point(18, 21)
    Me.Update1.Name = "Update1"
    Me.Update1.Size = New System.Drawing.Size(67, 17)
    Me.Update1.TabIndex = 0
    Me.Update1.Text = "Update1"
    Me.Update1.UseVisualStyleBackColor = True
    Me.Update1.Visible = False
    '
    'Update2
    '
    Me.Update2.AutoSize = True
    Me.Update2.Location = New System.Drawing.Point(18, 44)
    Me.Update2.Name = "Update2"
    Me.Update2.Size = New System.Drawing.Size(67, 17)
    Me.Update2.TabIndex = 1
    Me.Update2.Text = "Update2"
    Me.Update2.UseVisualStyleBackColor = True
    Me.Update2.Visible = False
    '
    'Update3
    '
    Me.Update3.AutoSize = True
    Me.Update3.Location = New System.Drawing.Point(18, 67)
    Me.Update3.Name = "Update3"
    Me.Update3.Size = New System.Drawing.Size(67, 17)
    Me.Update3.TabIndex = 2
    Me.Update3.Text = "Update3"
    Me.Update3.UseVisualStyleBackColor = True
    Me.Update3.Visible = False
    '
    'Update4
    '
    Me.Update4.AutoSize = True
    Me.Update4.Location = New System.Drawing.Point(18, 90)
    Me.Update4.Name = "Update4"
    Me.Update4.Size = New System.Drawing.Size(67, 17)
    Me.Update4.TabIndex = 3
    Me.Update4.Text = "Update4"
    Me.Update4.UseVisualStyleBackColor = True
    Me.Update4.Visible = False
    '
    'Update5
    '
    Me.Update5.AutoSize = True
    Me.Update5.Location = New System.Drawing.Point(18, 113)
    Me.Update5.Name = "Update5"
    Me.Update5.Size = New System.Drawing.Size(67, 17)
    Me.Update5.TabIndex = 4
    Me.Update5.Text = "Update5"
    Me.Update5.UseVisualStyleBackColor = True
    Me.Update5.Visible = False
    '
    'CheckBox6
    '
    Me.CheckBox6.AutoSize = True
    Me.CheckBox6.Location = New System.Drawing.Point(3, 3)
    Me.CheckBox6.Name = "CheckBox6"
    Me.CheckBox6.Size = New System.Drawing.Size(140, 30)
    Me.CheckBox6.TabIndex = 3
    Me.CheckBox6.Text = "Do not prompt me about" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "these in the future."
    Me.CheckBox6.UseVisualStyleBackColor = True
    '
    'PromptToUpdate
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(321, 154)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "PromptToUpdate"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Updates available..."
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.TableLayoutPanel1.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Update5 As System.Windows.Forms.CheckBox
  Friend WithEvents Update4 As System.Windows.Forms.CheckBox
  Friend WithEvents Update3 As System.Windows.Forms.CheckBox
  Friend WithEvents Update2 As System.Windows.Forms.CheckBox
  Friend WithEvents Update1 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox

End Class
