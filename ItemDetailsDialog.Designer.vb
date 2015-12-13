<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemDetailsDialog
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
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.Panel1 = New System.Windows.Forms.Panel
		Me.PictureBoxPanel = New System.Windows.Forms.Panel
		Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
		Me.CloseBtn = New System.Windows.Forms.Button
		Me.SaveImageBtn = New System.Windows.Forms.Button
		Me.CreateTiledBtn = New System.Windows.Forms.Button
		Me.CreateAtTargetBtn = New System.Windows.Forms.Button
		Me.CreateAtFeetBtn = New System.Windows.Forms.Button
		Me.CreateInPackBtn = New System.Windows.Forms.Button
		Me.ItemDetailsGrid = New System.Windows.Forms.PropertyGrid
		Me.StatusBar = New System.Windows.Forms.StatusStrip
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.SplitContainer2.Panel1.SuspendLayout()
		Me.SplitContainer2.Panel2.SuspendLayout()
		Me.SplitContainer2.SuspendLayout()
		Me.StatusBar.SuspendLayout()
		Me.SuspendLayout()
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.IsSplitterFixed = True
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
		Me.SplitContainer1.Panel1MinSize = 50
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
		Me.SplitContainer1.Panel2MinSize = 140
		Me.SplitContainer1.Size = New System.Drawing.Size(368, 357)
		Me.SplitContainer1.SplitterDistance = 200
		Me.SplitContainer1.SplitterWidth = 1
		Me.SplitContainer1.TabIndex = 0
		'
		'Panel1
		'
		Me.Panel1.AutoScroll = True
		Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Panel1.BackColor = System.Drawing.SystemColors.Window
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Panel1.Controls.Add(Me.PictureBoxPanel)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(200, 357)
		Me.Panel1.TabIndex = 0
		'
		'PictureBoxPanel
		'
		Me.PictureBoxPanel.BackColor = System.Drawing.SystemColors.Window
		Me.PictureBoxPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
		Me.PictureBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.PictureBoxPanel.Location = New System.Drawing.Point(0, 0)
		Me.PictureBoxPanel.Name = "PictureBoxPanel"
		Me.PictureBoxPanel.Size = New System.Drawing.Size(50, 50)
		Me.PictureBoxPanel.TabIndex = 0
		'
		'SplitContainer2
		'
		Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer2.IsSplitterFixed = True
		Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer2.Name = "SplitContainer2"
		Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer2.Panel1
		'
		Me.SplitContainer2.Panel1.Controls.Add(Me.CloseBtn)
		Me.SplitContainer2.Panel1.Controls.Add(Me.SaveImageBtn)
		Me.SplitContainer2.Panel1.Controls.Add(Me.CreateTiledBtn)
		Me.SplitContainer2.Panel1.Controls.Add(Me.CreateAtTargetBtn)
		Me.SplitContainer2.Panel1.Controls.Add(Me.CreateAtFeetBtn)
		Me.SplitContainer2.Panel1.Controls.Add(Me.CreateInPackBtn)
		'
		'SplitContainer2.Panel2
		'
		Me.SplitContainer2.Panel2.Controls.Add(Me.ItemDetailsGrid)
		Me.SplitContainer2.Size = New System.Drawing.Size(167, 357)
		Me.SplitContainer2.SplitterDistance = 138
		Me.SplitContainer2.SplitterWidth = 1
		Me.SplitContainer2.TabIndex = 0
		'
		'CloseBtn
		'
		Me.CloseBtn.Dock = System.Windows.Forms.DockStyle.Top
		Me.CloseBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CloseBtn.Location = New System.Drawing.Point(0, 115)
		Me.CloseBtn.Name = "CloseBtn"
		Me.CloseBtn.Size = New System.Drawing.Size(167, 23)
		Me.CloseBtn.TabIndex = 5
		Me.CloseBtn.Text = "Close"
		Me.CloseBtn.UseVisualStyleBackColor = True
		'
		'SaveImageBtn
		'
		Me.SaveImageBtn.Dock = System.Windows.Forms.DockStyle.Top
		Me.SaveImageBtn.Location = New System.Drawing.Point(0, 92)
		Me.SaveImageBtn.Name = "SaveImageBtn"
		Me.SaveImageBtn.Size = New System.Drawing.Size(167, 23)
		Me.SaveImageBtn.TabIndex = 4
		Me.SaveImageBtn.Text = "Save Image"
		Me.SaveImageBtn.UseVisualStyleBackColor = True
		'
		'CreateTiledBtn
		'
		Me.CreateTiledBtn.Dock = System.Windows.Forms.DockStyle.Top
		Me.CreateTiledBtn.Location = New System.Drawing.Point(0, 69)
		Me.CreateTiledBtn.Name = "CreateTiledBtn"
		Me.CreateTiledBtn.Size = New System.Drawing.Size(167, 23)
		Me.CreateTiledBtn.TabIndex = 3
		Me.CreateTiledBtn.Text = "Create Tiled..."
		Me.CreateTiledBtn.UseVisualStyleBackColor = True
		'
		'CreateAtTargetBtn
		'
		Me.CreateAtTargetBtn.Dock = System.Windows.Forms.DockStyle.Top
		Me.CreateAtTargetBtn.Location = New System.Drawing.Point(0, 46)
		Me.CreateAtTargetBtn.Name = "CreateAtTargetBtn"
		Me.CreateAtTargetBtn.Size = New System.Drawing.Size(167, 23)
		Me.CreateAtTargetBtn.TabIndex = 2
		Me.CreateAtTargetBtn.Text = "Create at Target"
		Me.CreateAtTargetBtn.UseVisualStyleBackColor = True
		'
		'CreateAtFeetBtn
		'
		Me.CreateAtFeetBtn.Dock = System.Windows.Forms.DockStyle.Top
		Me.CreateAtFeetBtn.Location = New System.Drawing.Point(0, 23)
		Me.CreateAtFeetBtn.Name = "CreateAtFeetBtn"
		Me.CreateAtFeetBtn.Size = New System.Drawing.Size(167, 23)
		Me.CreateAtFeetBtn.TabIndex = 1
		Me.CreateAtFeetBtn.Text = "Create at Feet"
		Me.CreateAtFeetBtn.UseVisualStyleBackColor = True
		'
		'CreateInPackBtn
		'
		Me.CreateInPackBtn.Dock = System.Windows.Forms.DockStyle.Top
		Me.CreateInPackBtn.Location = New System.Drawing.Point(0, 0)
		Me.CreateInPackBtn.Name = "CreateInPackBtn"
		Me.CreateInPackBtn.Size = New System.Drawing.Size(167, 23)
		Me.CreateInPackBtn.TabIndex = 0
		Me.CreateInPackBtn.Text = "Create in Pack"
		Me.CreateInPackBtn.UseVisualStyleBackColor = True
		'
		'ItemDetailsGrid
		'
		Me.ItemDetailsGrid.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ItemDetailsGrid.HelpVisible = False
		Me.ItemDetailsGrid.Location = New System.Drawing.Point(0, 0)
		Me.ItemDetailsGrid.Name = "ItemDetailsGrid"
		Me.ItemDetailsGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
		Me.ItemDetailsGrid.Size = New System.Drawing.Size(167, 218)
		Me.ItemDetailsGrid.TabIndex = 0
		Me.ItemDetailsGrid.ToolbarVisible = False
		'
		'StatusBar
		'
		Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
		Me.StatusBar.Location = New System.Drawing.Point(0, 335)
		Me.StatusBar.Name = "StatusBar"
		Me.StatusBar.Size = New System.Drawing.Size(368, 22)
		Me.StatusBar.TabIndex = 1
		Me.StatusBar.Text = "TEST"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(111, 17)
		Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
		'
		'ItemDetailsDialog
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSize = True
		Me.ClientSize = New System.Drawing.Size(368, 357)
		Me.Controls.Add(Me.StatusBar)
		Me.Controls.Add(Me.SplitContainer1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "ItemDetailsDialog"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Item Details"
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.SplitContainer2.Panel1.ResumeLayout(False)
		Me.SplitContainer2.Panel2.ResumeLayout(False)
		Me.SplitContainer2.ResumeLayout(False)
		Me.StatusBar.ResumeLayout(False)
		Me.StatusBar.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
	Friend WithEvents CloseBtn As System.Windows.Forms.Button
	Friend WithEvents SaveImageBtn As System.Windows.Forms.Button
	Friend WithEvents CreateTiledBtn As System.Windows.Forms.Button
	Friend WithEvents CreateAtTargetBtn As System.Windows.Forms.Button
	Friend WithEvents CreateAtFeetBtn As System.Windows.Forms.Button
	Friend WithEvents CreateInPackBtn As System.Windows.Forms.Button
	Friend WithEvents ItemDetailsGrid As System.Windows.Forms.PropertyGrid
	Friend WithEvents PictureBoxPanel As System.Windows.Forms.Panel
	Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
	Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel

End Class
