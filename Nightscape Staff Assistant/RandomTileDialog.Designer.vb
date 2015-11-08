<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RandomTileDialog
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
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.GroupBox1 = New System.Windows.Forms.GroupBox
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.ItemCategories = New System.Windows.Forms.TreeView
		Me.ItemList = New System.Windows.Forms.TreeView
		Me.GroupBox2 = New System.Windows.Forms.GroupBox
		Me.GapWarning = New System.Windows.Forms.Label
		Me.ItemRangePreview = New System.Windows.Forms.ListView
		Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
		Me.GroupBox3 = New System.Windows.Forms.GroupBox
		Me.HeightToCreateAt = New System.Windows.Forms.NumericUpDown
		Me.RangeSize = New System.Windows.Forms.NumericUpDown
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.GroupBox1.SuspendLayout()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		CType(Me.HeightToCreateAt, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.RangeSize, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.OK_Button.Location = New System.Drawing.Point(328, 344)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(95, 23)
		Me.OK_Button.TabIndex = 2
		Me.OK_Button.Text = "OK"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(328, 373)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(95, 23)
		Me.Cancel_Button.TabIndex = 3
		Me.Cancel_Button.Text = "Cancel"
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.SplitContainer1)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(434, 179)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Select Item..."
		'
		'SplitContainer1
		'
		Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.SplitContainer1.Location = New System.Drawing.Point(6, 32)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.ItemCategories)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.ItemList)
		Me.SplitContainer1.Size = New System.Drawing.Size(422, 141)
		Me.SplitContainer1.SplitterDistance = 205
		Me.SplitContainer1.SplitterWidth = 1
		Me.SplitContainer1.TabIndex = 0
		'
		'ItemCategories
		'
		Me.ItemCategories.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.ItemCategories.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ItemCategories.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ItemCategories.HideSelection = False
		Me.ItemCategories.HotTracking = True
		Me.ItemCategories.Indent = 15
		Me.ItemCategories.Location = New System.Drawing.Point(0, 0)
		Me.ItemCategories.Name = "ItemCategories"
		Me.ItemCategories.Size = New System.Drawing.Size(201, 137)
		Me.ItemCategories.TabIndex = 0
		'
		'ItemList
		'
		Me.ItemList.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.ItemList.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ItemList.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ItemList.FullRowSelect = True
		Me.ItemList.HideSelection = False
		Me.ItemList.Location = New System.Drawing.Point(0, 0)
		Me.ItemList.Name = "ItemList"
		Me.ItemList.ShowLines = False
		Me.ItemList.ShowPlusMinus = False
		Me.ItemList.ShowRootLines = False
		Me.ItemList.Size = New System.Drawing.Size(212, 137)
		Me.ItemList.TabIndex = 0
		Me.ToolTip.SetToolTip(Me.ItemList, "Select the first item in the range...")
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.GapWarning)
		Me.GroupBox2.Controls.Add(Me.ItemRangePreview)
		Me.GroupBox2.Location = New System.Drawing.Point(12, 197)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(434, 128)
		Me.GroupBox2.TabIndex = 2
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Range Preview"
		'
		'GapWarning
		'
		Me.GapWarning.AutoSize = True
		Me.GapWarning.Location = New System.Drawing.Point(7, 15)
		Me.GapWarning.Name = "GapWarning"
		Me.GapWarning.Size = New System.Drawing.Size(361, 13)
		Me.GapWarning.TabIndex = 6
		Me.GapWarning.Text = "The range shown contains gaps, only the tiles before the gaps will be used."
		Me.GapWarning.Visible = False
		'
		'ItemRangePreview
		'
		Me.ItemRangePreview.Alignment = System.Windows.Forms.ListViewAlignment.Left
		Me.ItemRangePreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ItemRangePreview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
		Me.ItemRangePreview.LabelWrap = False
		Me.ItemRangePreview.LargeImageList = Me.ImageList1
		Me.ItemRangePreview.Location = New System.Drawing.Point(3, 31)
		Me.ItemRangePreview.MultiSelect = False
		Me.ItemRangePreview.Name = "ItemRangePreview"
		Me.ItemRangePreview.ShowGroups = False
		Me.ItemRangePreview.Size = New System.Drawing.Size(428, 91)
		Me.ItemRangePreview.TabIndex = 0
		Me.ItemRangePreview.TabStop = False
		Me.ItemRangePreview.TileSize = New System.Drawing.Size(50, 50)
		Me.ToolTip.SetToolTip(Me.ItemRangePreview, "A preview of the tiles that will be used with the randtile command.")
		Me.ItemRangePreview.UseCompatibleStateImageBehavior = False
		'
		'ImageList1
		'
		Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
		Me.ImageList1.ImageSize = New System.Drawing.Size(44, 44)
		Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.HeightToCreateAt)
		Me.GroupBox3.Controls.Add(Me.RangeSize)
		Me.GroupBox3.Controls.Add(Me.Label2)
		Me.GroupBox3.Controls.Add(Me.Label1)
		Me.GroupBox3.Location = New System.Drawing.Point(12, 331)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(282, 74)
		Me.GroupBox3.TabIndex = 1
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "Random Tile Options"
		'
		'HeightToCreateAt
		'
		Me.HeightToCreateAt.Location = New System.Drawing.Point(110, 45)
		Me.HeightToCreateAt.Name = "HeightToCreateAt"
		Me.HeightToCreateAt.Size = New System.Drawing.Size(64, 20)
		Me.HeightToCreateAt.TabIndex = 1
		'
		'RangeSize
		'
		Me.RangeSize.Location = New System.Drawing.Point(110, 19)
		Me.RangeSize.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
		Me.RangeSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.RangeSize.Name = "RangeSize"
		Me.RangeSize.Size = New System.Drawing.Size(64, 20)
		Me.RangeSize.TabIndex = 0
		Me.RangeSize.Value = New Decimal(New Integer() {5, 0, 0, 0})
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(6, 47)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(98, 13)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Hieght to create at:"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(6, 21)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(65, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Range Size:"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(64, 16)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(95, 13)
		Me.Label3.TabIndex = 1
		Me.Label3.Text = "Item Categories"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.Location = New System.Drawing.Point(300, 16)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(37, 13)
		Me.Label4.TabIndex = 2
		Me.Label4.Text = "Items"
		'
		'RandomTileDialog
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(458, 417)
		Me.Controls.Add(Me.Cancel_Button)
		Me.Controls.Add(Me.OK_Button)
		Me.Controls.Add(Me.GroupBox3)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "RandomTileDialog"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Random Tile"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox3.PerformLayout()
		CType(Me.HeightToCreateAt, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.RangeSize, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents ItemRangePreview As System.Windows.Forms.ListView
  Friend WithEvents ItemCategories As System.Windows.Forms.TreeView
  Friend WithEvents ItemList As System.Windows.Forms.TreeView
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents HeightToCreateAt As System.Windows.Forms.NumericUpDown
  Friend WithEvents RangeSize As System.Windows.Forms.NumericUpDown
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
	Friend WithEvents GapWarning As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
