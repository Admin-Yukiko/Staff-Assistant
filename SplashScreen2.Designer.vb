<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen2
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
		Me.ProgressBar = New System.Windows.Forms.ProgressBar
		Me.Label1 = New System.Windows.Forms.Label
		Me.Copyright = New System.Windows.Forms.Label
		Me.Version = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.StatusMsg = New System.Windows.Forms.Label
		Me.SuspendLayout()
		'
		'ProgressBar
		'
		Me.ProgressBar.BackColor = System.Drawing.SystemColors.Control
		Me.ProgressBar.Location = New System.Drawing.Point(53, 128)
		Me.ProgressBar.MarqueeAnimationSpeed = 40
		Me.ProgressBar.Name = "ProgressBar"
		Me.ProgressBar.Size = New System.Drawing.Size(159, 18)
		Me.ProgressBar.Step = 25
		Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
		Me.ProgressBar.TabIndex = 0
		Me.ProgressBar.UseWaitCursor = True
		'
		'Label1
		'
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.CausesValidation = False
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(56, 110)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(71, 15)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Loading..."
		Me.Label1.UseMnemonic = False
		Me.Label1.UseWaitCursor = True
		'
		'Copyright
		'
		Me.Copyright.BackColor = System.Drawing.Color.Transparent
		Me.Copyright.CausesValidation = False
		Me.Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Copyright.Location = New System.Drawing.Point(60, 390)
		Me.Copyright.Name = "Copyright"
		Me.Copyright.Size = New System.Drawing.Size(440, 13)
		Me.Copyright.TabIndex = 2
		Me.Copyright.Text = "Copyright"
		Me.Copyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Copyright.UseMnemonic = False
		Me.Copyright.UseWaitCursor = True
		'
		'Version
		'
		Me.Version.BackColor = System.Drawing.Color.Transparent
		Me.Version.CausesValidation = False
		Me.Version.Location = New System.Drawing.Point(194, 78)
		Me.Version.Name = "Version"
		Me.Version.Size = New System.Drawing.Size(92, 13)
		Me.Version.TabIndex = 3
		Me.Version.Text = "Version: 0.2.1.0"
		Me.Version.UseMnemonic = False
		Me.Version.UseWaitCursor = True
		'
		'Label4
		'
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.CausesValidation = False
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Location = New System.Drawing.Point(66, 295)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(434, 25)
		Me.Label4.TabIndex = 4
		Me.Label4.Text = "Please wait."
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Label4.UseMnemonic = False
		Me.Label4.UseWaitCursor = True
		'
		'StatusMsg
		'
		Me.StatusMsg.BackColor = System.Drawing.Color.Transparent
		Me.StatusMsg.CausesValidation = False
		Me.StatusMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.StatusMsg.Location = New System.Drawing.Point(63, 340)
		Me.StatusMsg.Name = "StatusMsg"
		Me.StatusMsg.Size = New System.Drawing.Size(437, 17)
		Me.StatusMsg.TabIndex = 5
		Me.StatusMsg.Text = "Initializing components"
		Me.StatusMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.StatusMsg.UseMnemonic = False
		Me.StatusMsg.UseWaitCursor = True
		'
		'SplashScreen2
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.BackgroundImage = Global.Nightscape_Staff_Assistant.My.Resources.Resources.splash_screen
		Me.CausesValidation = False
		Me.ClientSize = New System.Drawing.Size(516, 416)
		Me.ControlBox = False
		Me.Controls.Add(Me.StatusMsg)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Version)
		Me.Controls.Add(Me.Copyright)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.ProgressBar)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(516, 416)
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(516, 416)
		Me.Name = "SplashScreen2"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "SplashScreen2"
		Me.TopMost = True
		Me.UseWaitCursor = True
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Copyright As System.Windows.Forms.Label
	Friend WithEvents Version As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents StatusMsg As System.Windows.Forms.Label
End Class
