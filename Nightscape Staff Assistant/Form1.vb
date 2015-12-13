Imports System.Threading

Public Class Form1

  Public BuildItemsList() As String
  Public MainItemsList() As String
  Public NPCsList() As String
  Public LocationsList() As String
	Public ClientCalibrated As Boolean

	Public INIHandler As New iniparser.INIFileHandler

	Public PatchMessage As String

	Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		If (Me.WindowState <> FormWindowState.Minimized) Then
			My.Settings.FormLocation = Me.Location
		End If

		If ((My.Settings.RetainInput = False) And (My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini") = True)) Then
			My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
		End If
		INIHandler.Dispose()
	End Sub

	Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Control.CheckForIllegalCrossThreadCalls = False

		SplashScreen2.StatusMsg.Text = "Initializing Session"
		If ((My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "/ns~settings.ini") = False)) Then
			'INI file does not exist, need to set it up and create it...
			INIHandler.Sections.AddSection("MAIN")
			INIHandler.Sections.AddSection("ADMIN TAB")
			INIHandler.Sections.AddSection("BUILD TAB")
			INIHandler.Sections.AddSection("ITEM TAB")
			INIHandler.Sections.AddSection("ITEM TWEAK TAB")
			INIHandler.Sections.AddSection("NPC TAB")
			INIHandler.Sections.AddSection("NPC TWEAK TAB")
			INIHandler.Sections.AddSection("GM TAB")
			INIHandler.Sections.AddSection("TRAVEL TAB")
			INIHandler.Sections.AddSection("TOOLS TAB")
			INIHandler.Sections.AddSection("SETTINGS TAB")
			INIHandler.Sections.Sections("MAIN").Settings.Add("FilePurpose", "This file is used to keep a cache of input. If input retention is disabled it will be deleted when the Staff Assistant exists, otherwise this file is persistent. Delete the file to clear the input cache.")
			INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
		Else
			INIHandler.ReadFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
		End If

		If (My.Settings.FormLocation.IsEmpty = False) Then
			If (((My.Settings.FormLocation.X > 0) And (My.Settings.FormLocation.X < My.Computer.Screen.WorkingArea.Width)) And ((My.Settings.FormLocation.Y > 0) And (My.Settings.FormLocation.Y < My.Computer.Screen.WorkingArea.Height))) Then
				Me.Location = My.Settings.FormLocation
			Else
				Me.Location = New Point(0, 0)
				My.Settings.FormLocation = New Point(0, 0)
				My.Settings.Save()
			End If
		End If

		SplashScreen2.StatusMsg.Text = "Caching Items List"
		If (My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\resources\lists\building_materials.lst")) Then
			BuildItemsList = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.CurrentDirectory & "\resources\lists\building_materials.lst").Replace(vbCrLf, "|").Split("|")
		Else
			MessageBox.Show(Application.OpenForms(0), "There was a fatal error loading the Building Creator list." & vbCrLf & vbCrLf & "The program will terminate." & vbCrLf & vbCrLf & "Please reinstall the Nightscape Staff Assistant to correct the error.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Me.Close()
			Exit Sub
		End If
		If (My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\resources\lists\items_list.lst")) Then
			MainItemsList = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.CurrentDirectory & "\resources\lists\items_list.lst").Replace(vbCrLf, "|").Split("|")
		Else
			MessageBox.Show(Application.OpenForms(0), "There was a fatal error loading the Items list." & vbCrLf & vbCrLf & "The program will terminate." & vbCrLf & vbCrLf & "Please reinstall the Nightscape Staff Assistant to correct the error.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Me.Close()
			Exit Sub
		End If
		SplashScreen2.StatusMsg.Text = "Caching NPCs List"
		If (My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\resources\lists\npc_list.lst")) Then
			NPCsList = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.CurrentDirectory & "\resources\lists\npc_list.lst").Replace(vbCrLf, "|").Split("|")
		Else
			MessageBox.Show(Application.OpenForms(0), "There was a fatal error loading the NPCs list." & vbCrLf & vbCrLf & "The program will terminate." & vbCrLf & vbCrLf & "Please reinstall the Nightscape Staff Assistant to correct the error.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Me.Close()
			Exit Sub
		End If
		SplashScreen2.StatusMsg.Text = "Caching Locations List"
		If (My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\resources\lists\locations_list.lst")) Then
			LocationsList = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.CurrentDirectory & "\resources\lists\locations_list.lst").Replace(vbCrLf, "|").Split("|")
		Else
			MessageBox.Show(Application.OpenForms(0), "There was a fatal error loading the Travel Locations list." & vbCrLf & vbCrLf & "The program will terminate." & vbCrLf & vbCrLf & "Please reinstall the Nightscape Staff Assistant to correct the error.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Me.Close()
			Exit Sub
		End If

		SplashScreen2.StatusMsg.Text = "Initializing AutoComplete"
		SearchNameMenuItem1.AutoCompleteCustomSource = My.Settings.SearchByName1_AutoComplete
		SearchIDMenuItem1.AutoCompleteCustomSource = My.Settings.SearchByID1_AutoComplete
		SearchNameMenuItem2.AutoCompleteCustomSource = My.Settings.SearchByName2_AutoComplete
		SearchIDMenuItem2.AutoCompleteCustomSource = My.Settings.SearchByID2_AutoComplete
		SearchByNameTextBox3.AutoCompleteCustomSource = My.Settings.SearchByName3_AutoComplete
		SearchByNameTextBox4.AutoCompleteCustomSource = My.Settings.SearchByName4_AutoComplete

		'AutoComplete
		If (My.Settings.AutoComplete = False) Then
			SearchNameMenuItem1.AutoCompleteMode = AutoCompleteMode.None
			SearchIDMenuItem1.AutoCompleteMode = AutoCompleteMode.None
		Else
			SearchNameMenuItem1.AutoCompleteMode = AutoCompleteMode.Suggest
			SearchIDMenuItem1.AutoCompleteMode = AutoCompleteMode.Suggest
		End If

		SplashScreen2.StatusMsg.Text = "Starting Location Tracking"
		'Track my Location
		If (My.Settings.TrackLocation = True) Then
			Dim TrackLocationThread As New System.Threading.Thread(AddressOf TrackLocation)
			TrackLocationThread.IsBackground = True
			TrackLocationThread.Priority = Threading.ThreadPriority.Lowest
			TrackLocationThread.Start()
		End If

		SplashScreen2.StatusMsg.Text = "Customizing application"
		'TOOLTIP STYLE
		If (My.Settings.TooltipStyle = "standard") Then
			ToolTip.IsBalloon = False
		Else
			ToolTip.IsBalloon = True
		End If

		'Select the specified tab to show at startup
		Select Case (My.Settings.StartupTab)
			Case "administration"
				TabControl1.SelectTab(0)
			Case "building_creator"
				TabControl1.SelectTab(1)
			Case "items"
				TabControl1.SelectTab(2)
			Case "items_tweak"
				TabControl1.SelectTab(3)
			Case "npcs"
				TabControl1.SelectTab(4)
			Case "npc_tweak"
				TabControl1.SelectTab(5)
			Case "gm"
				TabControl1.SelectTab(6)
			Case "travel"
				TabControl1.SelectTab(7)
			Case "tools"
				TabControl1.SelectTab(8)
			Case "settings"
				TabControl1.SelectTab(9)
			Case Else
				TabControl1.SelectTab(0)
		End Select

		If ((My.Settings.AutoLaunchClient = True) And (My.Settings.NightscapeLocation <> "") And (Ultima.Client.Running = False)) Then
			SplashScreen2.StatusMsg.Text = "Autolaunching Nightscape"
			Dim Client As New Process
			If ((My.Computer.FileSystem.FileExists(My.Settings.NightscapeLocation & "\nspatch.exe")) And (My.Settings.AutoLaunchType = "patch")) Then
				Client.StartInfo.FileName = "nspatch.exe"
			Else
                'Client.StartInfo.FileName = "nsclient.exe"
                Client.StartInfo.FileName = "Decrypted_client.exe"
            End If
			Client.StartInfo.UseShellExecute = True
			Client.StartInfo.WorkingDirectory = My.Settings.NightscapeLocation
			Client.EnableRaisingEvents = False
			Try
				Client.Start()
				Client.WaitForInputIdle()
			Catch ex As Exception
				MessageBox.Show("Failed to load the Nightscape Client: " & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End If

		SplashScreen2.StatusMsg.Text = "Finalizing startup"
		If (My.Settings.Opacity = "enabled") Then
			Select Case (My.Settings.OpacityLevel)
				Case 100, 99
					VisibleMenuItem_Click(sender, e)
				Case 90
					Opacity90MenuItem_Click(sender, e)
				Case 80
					Opacity80MenuItem_Click(sender, e)
				Case 70
					Opacity70MenuItem_Click(sender, e)
				Case 60
					Opacity60MenuItem_Click(sender, e)
				Case 50
					Opacity50MenuItem_Click(sender, e)
				Case 40
					Opacity40MenuItem_Click(sender, e)
				Case 30
					Opacity30MenuItem_Click(sender, e)
				Case 20
					Opacity20MenuItem_Click(sender, e)
				Case 10
					Opacity10MenuItem_Click(sender, e)
				Case Else
					OpacityCustomMenuItem_Click(sender, e)
			End Select
			Me.Opacity = ("0." & My.Settings.OpacityLevel.ToString)
		Else
			Me.Opacity = 0.99
			VisibleMenuItem_Click(sender, e)
		End If

		'Show the Quick Commands dividers based on whats enabled...
		If ((My.Settings.QC_GetInfo = False) And (My.Settings.QC_Kill = False) And (My.Settings.QC_Ressurect = False) And (My.Settings.QC_Jail = False) And (My.Settings.QC_Kick = False) And (My.Settings.QC_Hide = False)) Then
			QC_MobileCmdsSeparator.Visible = False
		End If
		If ((My.Settings.QC_Destroy = False) And (My.Settings.QC_MDestroy = False) And (My.Settings.QC_RoofCreator = False) And (My.Settings.QC_ItemInfo = False) And (My.Settings.QC_LockItem = False) And (My.Settings.QC_Lockdown5 = False) And (My.Settings.QC_Lockdown10 = False)) Then
			QC_ItemsCmdsSeparator.Visible = False
		End If
		If ((My.Settings.QC_ConcealMe = False) And (My.Settings.QC_RevealMe = False) And (My.Settings.QC_GMForm = False) And (My.Settings.QC_MyForm = False) And (My.Settings.QC_SaveShard = False) And (My.Settings.QC_Nightsight = False) And (My.Settings.QC_HelpQueue = False) And (My.Settings.QC_PropEdit = False)) Then
			QC_SeerCmdsSeparator.Visible = False
		End If

		'If (My.Settings.CheckUpdates = True) Then
		'  NotifyIcon.BalloonTipIcon = ToolTipIcon.Info
		'  NotifyIcon.BalloonTipText = "Checking for newer versions..."
		'  NotifyIcon.BalloonTipTitle = "AutoPatch"
		'  NotifyIcon.ShowBalloonTip(2000)
		'  Me.PatcherBackgroundWorker.RunWorkerAsync()
		'End If

	End Sub

	Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
		If (FormWindowState.Minimized) And (My.Settings.ShowOnTaskbar = False) Then
			Me.Hide()
		End If
	End Sub

	Private Sub NotifyIcon_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon.DoubleClick
		If (Me.WindowState = FormWindowState.Minimized) Then
			Me.Show()
			Me.WindowState = FormWindowState.Normal
			Me.Show()
			If ((Me.Location.X = -32000) Or (Me.Location.Y = -32000)) Then
				Me.Location = New Point(0, 0)
			End If
		Else
			Me.Show()
			Me.Activate()
			Me.BringToFront()
		End If
	End Sub

	'#################################################'
	'################### MAIN MENU ###################'
	'#################################################'

	Private Sub MainMenuBtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainMenuBtn.MouseDown
		MainMenuBtn.FlatAppearance.BorderSize = 1
	End Sub
	Private Sub MainMenuBtn_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainMenuBtn.MouseHover
		MainMenuBtn.FlatAppearance.BorderSize = 1
	End Sub
	Private Sub MainMenuBtn_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainMenuBtn.MouseLeave
		MainMenuBtn.FlatAppearance.BorderSize = 0
	End Sub
	Private Sub MainMenuBtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainMenuBtn.MouseUp
		MainMenuBtn.FlatAppearance.BorderSize = 0
	End Sub

	Private Sub MainMenuBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuBtn.Click
		MainMenu_ContextMenu.Show(Control.MousePosition, ToolStripDropDownDirection.BelowRight)
	End Sub

	Private Sub BuildingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuildingToolStripMenuItem.Click
		Dim BuildingToolbar As Form = Application.OpenForms("BuildingToolbar")
		Try
			BuildingToolbar.Close()
			BuildingToolbar.Dispose()
		Catch ex As Exception
			Dim BuildingToolbar2 As New BuildingToolbar
			BuildingToolbar2.TopMost = Me.TopMost
			BuildingToolbar2.Show()
		End Try
	End Sub


	'#################################################'
	'############## ADMINISTRATION TAB ###############'
	'#################################################'
	Private Sub SaveShardBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveShardBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_savenow")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub ShutdownBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_do_shutdown")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub ShutdownNowBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownNowBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_do_shutdown delayed")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub KillScriptsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KillScriptsBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim GenericStringDialog As New GenericStringDialog
			GenericStringDialog.Description.Text = "Enter the scripts process ID number..."
			GenericStringDialog.TextBox.Text = INIHandler.Sections("ADMIN TAB").Settings("KillPID")
			GenericStringDialog.TopMost = Me.TopMost
			Dim Returned As DialogResult
			Returned = GenericStringDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("KillPID", GenericStringDialog.TextBox.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.CurrentDirectory + "/ns~settings.ini")
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_killpid " & GenericStringDialog.TextBox.Text)
			End If
			GenericStringDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub UnloadScriptBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnloadScriptBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim GenericStringDialog As New GenericStringDialog
			GenericStringDialog.Description.Text = "Enter the name of the script to unload..."
			GenericStringDialog.TextBox.Text = INIHandler.Sections("ADMIN TAB").Settings("UnloadScript")
			GenericStringDialog.TopMost = Me.TopMost
			Dim Returned As DialogResult
			Returned = GenericStringDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("UnloadScript", GenericStringDialog.TextBox.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.CurrentDirectory + "/ns~settings.ini")
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_unload " & GenericStringDialog.TextBox.Text)
			End If
			GenericStringDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub UnloadAllBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnloadAllBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_unloadall")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub UnloadCFGBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnloadCFGBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim GenericStringDialog As New GenericStringDialog
			GenericStringDialog.Description.Text = "Enter the name of the cfg file to unload..."
			GenericStringDialog.TextBox.Text = INIHandler.Sections("ADMIN TAB").Settings("UnloadCFG")
			GenericStringDialog.TopMost = Me.TopMost
			Dim Returned As DialogResult
			Returned = GenericStringDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("UnloadCFG", GenericStringDialog.TextBox.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.CurrentDirectory + "/ns~settings.ini")
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_unloadcfg " & GenericStringDialog.TextBox.Text)
			End If
			GenericStringDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub CreateAccountBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateAccountBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim AddAccountDialog As New AddAccountDialog
			AddAccountDialog.TopMost = Me.TopMost
			AddAccountDialog.AccountName.Text = INIHandler.Sections("ADMIN TAB").Settings("AddAccountName")
			AddAccountDialog.Password.Text = INIHandler.Sections("ADMIN TAB").Settings("AddAccountPassword")
			AddAccountDialog.ConfirmPassword.Text = INIHandler.Sections("ADMIN TAB").Settings("AddAccountConfirmPassword")
			Dim Returned As DialogResult
			Returned = AddAccountDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("AddAccountName", AddAccountDialog.AccountName.Text)
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("AddAccountPassword", AddAccountDialog.Password.Text)
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("AddAccountConfirmPassword", AddAccountDialog.ConfirmPassword.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				If (AddAccountDialog.Password.Text <> AddAccountDialog.ConfirmPassword.Text) Then
					MessageBox.Show("Passwords did not match!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Exit Sub
				End If
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_addaccount " & AddAccountDialog.AccountName.Text & " " & AddAccountDialog.Password.Text)
			End If
			AddAccountDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub BanAccountBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BanAccountBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim GenericStringDialog As New GenericStringDialog
			GenericStringDialog.Description.Text = "Enter the name of the account to ban..."
			GenericStringDialog.TextBox.Text = INIHandler.Sections("ADMIN TAB").Settings("BanAccountName")
			GenericStringDialog.TopMost = Me.TopMost
			Dim Returned As DialogResult
            Returned = GenericStringDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("BanAccountName", GenericStringDialog.TextBox.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
                Ultima.Client.BringToTop()
                'modified
                Ultima.Client.SendText(".sa_disable_acct " & GenericStringDialog.TextBox.Text)
			End If
			GenericStringDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub UnBanAccountBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnBanAccountBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim GenericStringDialog As New GenericStringDialog
			GenericStringDialog.Description.Text = "Enter the name of the account to unban..."
			GenericStringDialog.TextBox.Text = INIHandler.Sections("ADMIN TAB").Settings("UnBanAccountName")
			GenericStringDialog.TopMost = Me.TopMost
			Dim Returned As DialogResult
			Returned = GenericStringDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("UnBanAccountName", GenericStringDialog.TextBox.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
                Ultima.Client.BringToTop()
                'modified
                Ultima.Client.SendText(".sa_enable_acct " & GenericStringDialog.TextBox.Text)
			End If
			GenericStringDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub WipeAccountBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WipeAccountBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim GenericStringDialog As New GenericStringDialog
			GenericStringDialog.Description.Text = "Enter the name of the account to wipe..."
			GenericStringDialog.TextBox.Text = INIHandler.Sections("ADMIN TAB").Settings("WipeAccountName")
			GenericStringDialog.TopMost = Me.TopMost
			Dim Returned As DialogResult
			Returned = GenericStringDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("WipeAccountName", GenericStringDialog.TextBox.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
				Ultima.Client.SendText(".nukeaccount " & GenericStringDialog.TextBox.Text)
			End If
			GenericStringDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub
    'Modified
	Private Sub SetCmdLvlBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetCmdLvlBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim SetCmdLvlDialog As New SetCmdLvlDialog
			SetCmdLvlDialog.TopMost = Me.TopMost
			If (INIHandler.Sections("ADMIN TAB").Settings("SetCMDLevel") = Nothing) Then
				SetCmdLvlDialog.CommandLevel.SelectedItem = "Player"
			Else
				SetCmdLvlDialog.CommandLevel.SelectedItem = INIHandler.Sections("ADMIN TAB").Settings("SetCMDLevel")
			End If
			Dim Returned As DialogResult
			Returned = SetCmdLvlDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("SetCMDLevel", SetCmdLvlDialog.CommandLevel.SelectedItem)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
				Select Case (SetCmdLvlDialog.CommandLevel.SelectedItem)
                    Case "Developer"
                        Ultima.Client.SendText(".sa_setcmdlvl " & "test")
					Case "Administrator"
                        Ultima.Client.SendText(".sa_setcmdlvl " & "admin")
                    Case "GM"
                        Ultima.Client.SendText(".sa_setcmdlvl " & "gm")
                    Case "Seer"
                        Ultima.Client.SendText(".sa_setcmdlvl " & "seer")
                    Case "Counsellor"
                        Ultima.Client.SendText(".sa_setcmdlvl " & "coun")
					Case "Player"
                        Ultima.Client.SendText(".sa_setcmdlvl " & "player")
				End Select
			End If
			SetCmdLvlDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub MakeSeerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeSeerBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_makeseer")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub GrantPrivBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrantPrivBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim PrivledgesDialog As New PrivledgesDialog
			PrivledgesDialog.TopMost = Me.TopMost
			If (INIHandler.Sections("ADMIN TAB").Settings("GrantPrivledge") = Nothing) Then
				PrivledgesDialog.PrivledgeList.SelectedItem = "moveany"
			Else
				PrivledgesDialog.PrivledgeList.SelectedItem = INIHandler.Sections("ADMIN TAB").Settings("GrantPrivledge")
			End If
			PrivledgesDialog.Text = "Grant Privledge"
			Dim Returned As DialogResult = PrivledgesDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("GrantPrivledge", PrivledgesDialog.PrivledgeList.SelectedItem)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_grantpriv " & PrivledgesDialog.PrivledgeList.SelectedItem.ToString)
			End If
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub RevokePrivBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevokePrivBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim PrivledgesDialog As New PrivledgesDialog
			PrivledgesDialog.TopMost = Me.TopMost
			If (INIHandler.Sections("ADMIN TAB").Settings("RevokePrivledge") = Nothing) Then
				PrivledgesDialog.PrivledgeList.SelectedItem = "moveany"
			Else
				PrivledgesDialog.PrivledgeList.SelectedItem = INIHandler.Sections("ADMIN TAB").Settings("RevokePrivledge")
			End If
			PrivledgesDialog.Text = "Revoke Privledge"
			Dim Returned As DialogResult = PrivledgesDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("RevokePrivledge", PrivledgesDialog.PrivledgeList.SelectedItem)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_revokepriv " & PrivledgesDialog.PrivledgeList.SelectedItem.ToString)
			End If
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub GetPlayerInfoBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetPlayerInfoBtn.Click, GetNPCInfo.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".info")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub KillPlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KillPlayerBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_kill")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub ResPlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResPlayerBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_res")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub RefreshPlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshPlayerBtn.Click, RefreshNPC.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_refresh")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub JailPlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JailPlayerBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_jail")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub KickPlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KickPlayerBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_kick")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub ThawPlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThawPlayerBtn.Click, ThawNPC.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_thaw")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub FreezePlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FreezePlayerBtn.Click, FreezeNPC.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_freeze")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub SquelchPlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SquelchPlayerBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_squelch")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub ForgivePlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForgivePlayerBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_forgive")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub SetPlayerSkillBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetPlayerSkillBtn.Click, SetNPCSkill.Click
		If (Ultima.Client.Running = True) Then
			Dim SetSkillDialog As New SetSkillDialog
			SetSkillDialog.TopMost = Me.TopMost
			If (INIHandler.Sections("ADMIN TAB").Settings("SetSkill") = Nothing) Then
				SetSkillDialog.SkillList.SelectedItem = "Alchemy"
			Else
				SetSkillDialog.SkillList.SelectedItem = INIHandler.Sections("ADMIN TAB").Settings("SetSkill")
			End If
			SetSkillDialog.SkillValue.Value = INIHandler.Sections("ADMIN TAB").Settings("SetSkillValue")
			Dim Returned As DialogResult = SetSkillDialog.ShowDialog
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("SetSkill", SetSkillDialog.SkillList.SelectedItem)
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("SetSkillValue", SetSkillDialog.SkillValue.Value.ToString)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
				Ultima.Client.SendText(".setskill " & SetSkillDialog.SkillList.SelectedItem & " " & SetSkillDialog.SkillValue.Value.ToString)
			End If
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub SetPlayerStatBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetPlayerStatBtn.Click, SetNPCStat.Click
		If (Ultima.Client.Running = True) Then
			Dim SetStatDialog As New SetStatDialog
			SetStatDialog.TopMost = Me.TopMost
			If ((INIHandler.Sections("ADMIN TAB").Settings("SetStat") = "str") Or (INIHandler.Sections("ADMIN TAB").Settings("SetStat") = Nothing)) Then
				SetStatDialog.Strength.Checked = True
			ElseIf (INIHandler.Sections("ADMIN TAB").Settings("SetStat") = "dex") Then
				SetStatDialog.Stamina.Checked = True
			ElseIf (INIHandler.Sections("ADMIN TAB").Settings("SetStat") = "int") Then
				SetStatDialog.Intelligence.Checked = True
			End If
			SetStatDialog.StatValue.Value = INIHandler.Sections("ADMIN TAB").Settings("SetStatValue")
			Dim Returned As DialogResult = SetStatDialog.ShowDialog
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("SetStat", SetSkillDialog.SkillList.SelectedItem)
				INIHandler.Sections.Sections("ADMIN TAB").Settings.Set("SetStatValue", SetSkillDialog.SkillValue.Value.ToString)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
				If (SetStatDialog.Strength.Checked = True) Then
					Ultima.Client.SendText(".setstat strength " & SetStatDialog.StatValue.Value.ToString)
				ElseIf (SetStatDialog.Stamina.Checked = True) Then
					Ultima.Client.SendText(".setstat stamina " & SetStatDialog.StatValue.Value.ToString)
				ElseIf (SetStatDialog.Intelligence.Checked = True) Then
					Ultima.Client.SendText(".setstat intelligence " & SetStatDialog.StatValue.Value.ToString)
				End If
			End If
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub BarberPlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarberPlayerBtn.Click, NPCBarber.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".barber")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub HidePlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HidePlayerBtn.Click, HideNPC.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".hide")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub InvulPlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvulPlayerBtn.Click, NPCSetInvul.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_invul")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub MessagePlayerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessagePlayerBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_msg")
		Else
			ShowError("noclient")
		End If
	End Sub

	'#################################################'
	'############# BUILDING CREATOR TAB ##############'
	'#################################################'
	' ALSO HANDLES SOME ELEMENTS FROM ITEMS TAB

	Private Sub BuildTab_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuildTab.Enter
		If (BldngCategoryTree.Nodes.Count = 0) Then

			' Suppress repainting the TreeView until all the objects have been created.
			BldngCategoryTree.BeginUpdate()

			' Clear the TreeView each time the method is called.
			BldngCategoryTree.Nodes.Clear()

			Dim lastCKey As Integer = -1

			For Each line As String In BuildItemsList

				If (line.StartsWith("C")) Then
					lastCKey += 1
					BldngCategoryTree.Nodes.Add(line.Substring(2, line.Length - 2), line.Substring(2, line.Length - 2))
					Continue For
				End If

				If ((line.StartsWith("S")) And (lastCKey >= 0)) Then
					BldngCategoryTree.Nodes(lastCKey).Nodes.Add(line.Substring(2, line.Length - 2), line.Substring(2, line.Length - 2))
				End If

			Next line

			' Begin repainting the TreeView.
			BldngCategoryTree.EndUpdate()
		End If
	End Sub

	Private Sub BldngCategoryTree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles BldngCategoryTree.AfterSelect
		Dim FoundParent As Boolean = False
		Dim FoundCat As Boolean = False
		Dim ParentNode As String = Nothing

		BldngItemList.BeginUpdate()
		BldngItemList.Nodes.Clear()

		Try
			ParentNode = BldngCategoryTree.SelectedNode.Parent.Text
		Catch ex As Exception
			FoundParent = True
		End Try

		For Each line As String In BuildItemsList
			If (FoundParent = False) Then
				If (BldngCategoryTree.SelectedNode.Parent.Text = line.Substring(2, line.Length - 2)) Then
					FoundParent = True
					Continue For
				End If
			End If
			If (FoundParent = True) Then
				If (BldngCategoryTree.SelectedNode.Text = line.Substring(2, line.Length - 2)) Then
					FoundCat = True
					Continue For
				End If
				If (FoundCat = True) Then
					If ((line.StartsWith("G")) Or (line.StartsWith("C")) Or (line.StartsWith("S"))) Then
						FoundCat = False
						Exit For
					End If
					If (line.StartsWith("I")) Then
						BldngItemList.Nodes.Add(line.Substring(52, line.Length - 52), line.Substring(2, 50).TrimEnd(" "))
					End If
				End If
			End If
		Next line

		BldngItemList.EndUpdate()
	End Sub

	'Collapse / Expand
	Private Sub CollapseMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollapseMenuItem1.Click
		BldngCategoryTree.CollapseAll()
	End Sub
	Private Sub ExpandMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandMenuItem1.Click
		BldngCategoryTree.ExpandAll()
	End Sub

	'Search by Name
	Private Sub SearchNameMenuItem1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchNameMenuItem1.GotFocus
		If (SearchNameMenuItem1.Text = "Search by Name") Then
			SearchNameMenuItem1.Text = ""
			SearchNameMenuItem1.ForeColor = Color.Black
		End If
	End Sub
	Private Sub SearchNameMenuItem1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchNameMenuItem1.KeyDown
		If (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return) Then
			SearchNameMenuItem1.AutoCompleteCustomSource.Add(SearchNameMenuItem1.Text)
			My.Settings.SearchByName1_AutoComplete = SearchNameMenuItem1.AutoCompleteCustomSource

			Collapse_ExpandMenu1.Hide()
			Dim LastCategory As String = Nothing
			Dim FoundItem As String = Nothing
			For Each line As String In BuildItemsList
				If (line.StartsWith("C") Or line.StartsWith("S")) Then
					LastCategory = line.Substring(2, line.Length - 2).TrimEnd(" ")
				End If
				If (line.StartsWith("I")) Then
					If (line.Substring(2, 50).TrimEnd(" ").ToLower.Contains(SearchNameMenuItem1.Text.ToLower)) Then
						FoundItem = line.Substring(52, line.Length - 52).Trim(" ")
						Exit For
					End If
				Else
					If (line.Substring(2, line.Length - 2).TrimEnd(" ").ToLower.Contains(SearchNameMenuItem1.Text.ToLower)) Then
						FoundItem = Nothing
						Exit For
					End If
				End If
			Next
			BldngCategoryTree.SelectedNode = BldngCategoryTree.Nodes.Find(LastCategory, True)(0)
			If (FoundItem IsNot Nothing) Then
				Dim FoundNode() As TreeNode = BldngItemList.Nodes.Find(FoundItem, True)
				If (FoundNode.Length > 0) Then
					BldngItemList.SelectedNode = FoundNode(0)
				End If
			End If
			e.Handled = True
			SearchNameMenuItem1.Text = "Search by Name"
			SearchNameMenuItem1.ForeColor = Color.Gray
		End If
	End Sub
	Private Sub SearchNameMenuItem1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchNameMenuItem1.LostFocus
		If (SearchNameMenuItem1.Text = "") Then
			SearchNameMenuItem1.Text = "Search by Name"
			SearchNameMenuItem1.ForeColor = Color.Gray
		End If
	End Sub

	'Seatch by ID
	Private Sub SearchIDMenuItem1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchIDMenuItem1.GotFocus
		If (SearchIDMenuItem1.Text = "Search by ID") Then
			SearchIDMenuItem1.Text = ""
			SearchIDMenuItem1.ForeColor = Color.Black
		End If
	End Sub
	Private Sub SearchIDMenuItem1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchIDMenuItem1.KeyDown
		If (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return) Then
			SearchIDMenuItem1.AutoCompleteCustomSource.Add(SearchIDMenuItem1.Text.ToString)
			My.Settings.SearchByID1_AutoComplete = SearchIDMenuItem1.AutoCompleteCustomSource
			Collapse_ExpandMenu1.Hide()
			Dim LastCategory As String = Nothing
			Dim FoundItem As String = Nothing
			For Each line As String In BuildItemsList
				If (line.StartsWith("C") Or line.StartsWith("S")) Then
					LastCategory = line.Substring(2, line.Length - 2).TrimEnd(" ")
				End If
				If (line.StartsWith("I")) Then
					If (line.Substring(52, line.Length - 52).Trim(" ").ToLower.Contains(SearchIDMenuItem1.Text.ToLower)) Then
						FoundItem = line.Substring(52, line.Length - 52).Trim(" ")
						Exit For
					End If
				End If
			Next
			BldngCategoryTree.SelectedNode = BldngCategoryTree.Nodes.Find(LastCategory, True)(0)
			If (FoundItem IsNot Nothing) Then
				Dim FoundNode() As TreeNode = BldngItemList.Nodes.Find(FoundItem, True)
				If (FoundNode.Length > 0) Then
					BldngItemList.SelectedNode = FoundNode(0)
				End If
			End If
			e.Handled = True
			SearchIDMenuItem1.Text = "Search by ID"
			SearchIDMenuItem1.ForeColor = Color.Gray
		End If
	End Sub
	Private Sub SearchIDMenuItem1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchIDMenuItem1.LostFocus
		If (SearchIDMenuItem1.Text = "") Then
			SearchIDMenuItem1.Text = "Search by ID"
			SearchIDMenuItem1.ForeColor = Color.Gray
		End If
	End Sub

    Private Sub BldngItemList_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles BldngItemList.AfterSelect
        'modified
        BldngItemPreview.Image = Ultima.Art.GetStatic(Convert.ToInt32(BldngItemList.SelectedNode.Name, 16))
        BldngItemID.Text = "ID: 0x" & BldngItemList.SelectedNode.Name.ToString
        ToolTip.SetToolTip(BldngItemID, "Hex ID number of the currently selected item." + vbCrLf + vbCrLf + "Decimal Value: " + Convert.ToInt32(BldngItemList.SelectedNode.Name, 16).ToString)
    End Sub

	Private Sub CreateFeetBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateFeetBtn1.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (BldngItemList.SelectedNode.Name IsNot Nothing) Then
					Ultima.Client.BringToTop()
                    Ultima.Client.SendText(".sa_createhere " & Convert.ToInt32(BldngItemList.SelectedNode.Name, 16).ToString)
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub CreatePackBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreatePackBtn1.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (BldngItemList.SelectedNode.Name IsNot Nothing) Then
					Ultima.Client.BringToTop()
					Ultima.Client.SendText(".create " & Convert.ToInt32(BldngItemList.SelectedNode.Name, 16).ToString)
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub CreateTargetBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateTargetBtn1.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (BldngItemList.SelectedNode.Name IsNot Nothing) Then
					Ultima.Client.BringToTop()
					Ultima.Client.SendText(".createat " & Convert.ToInt32(BldngItemList.SelectedNode.Name, 16).ToString)
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub CreateTiledBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateTiledBtn1.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (BldngItemList.SelectedNode.Name IsNot Nothing) Then
					Dim GenericNumericDialog As New GenericNumericDialog
					GenericNumericDialog.TopMost = Me.TopMost
					Int32.TryParse(INIHandler.Sections("BUILD TAB").Settings("TileHieght"), GenericNumericDialog.NumericUpDown.Value)
					GenericNumericDialog.Description.Text = "Enter the height at which to create the item(s)..."
					Dim Returned As DialogResult = GenericNumericDialog.ShowDialog()
					If (Returned = Windows.Forms.DialogResult.OK) Then
						INIHandler.Sections.Sections("BUILD TAB").Settings.Set("TileHieght", GenericNumericDialog.NumericUpDown.Value.ToString)
						INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
						Ultima.Client.BringToTop()
						Ultima.Client.SendText(".tile " & Convert.ToInt32(BldngItemList.SelectedNode.Name, 16).ToString & " " & GenericNumericDialog.NumericUpDown.Value.ToString)
					End If
					GenericNumericDialog.Dispose()
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub

	'Destroy functions also cover buttons on the Items Tab
	Private Sub DestroyBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestroyBtn1.Click, DestroyBtn2.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".destroy")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub DestroyMultipleBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestroyMultipleBtn1.Click, DestroyMultipleBtn2.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".mdestroy")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub DestroyRadiusBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestroyRadiusBtn1.Click, DestroyRadiusBtn2.Click
		If (Ultima.Client.Running = True) Then
			Dim GenericNumericDialog As New GenericNumericDialog
			GenericNumericDialog.TopMost = Me.TopMost
			Int32.TryParse(INIHandler.Sections("BUILD TAB").Settings("DestroyRadius"), GenericNumericDialog.NumericUpDown.Value)
			GenericNumericDialog.Description.Text = "Enter the tile radius to destroy..."
			Dim Returned As DialogResult = GenericNumericDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("BUILD TAB").Settings.Set("DestroyRadius", GenericNumericDialog.NumericUpDown.Value.ToString)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
				Ultima.Client.SendText(".destroyradius " & GenericNumericDialog.NumericUpDown.Value.ToString)
			End If
			GenericNumericDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub RoofCreatorBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoofCreatorBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".createroof")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub FoundationCreatorbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoundationCreatorbtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".createfoundation")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub RandomTileBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomTileBtn1.Click, RandomTileBtn2.Click
		'Randtile button also covers button on the Items Tab
		If (Ultima.Client.Running = True) Then
			Dim RandomTileDialog As New RandomTileDialog
			RandomTileDialog.TopMost = Me.TopMost
			Dim ReturnedValue As DialogResult = RandomTileDialog.ShowDialog()
			If (ReturnedValue = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("BUILD TAB").Settings.Set("RandomTileCategory", RandomTileDialog.ItemCategories.SelectedNode.Text)
				INIHandler.Sections.Sections("BUILD TAB").Settings.Set("RandomTileItem", RandomTileDialog.ItemList.SelectedNode.Name)
				INIHandler.Sections.Sections("BUILD TAB").Settings.Set("RandomTileRange", RandomTileDialog.RangeSize.Value)
				INIHandler.Sections.Sections("BUILD TAB").Settings.Set("RandomTileHeight", RandomTileDialog.HeightToCreateAt.Value)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
				Dim modifier As Integer = 1
				While (RandomTileDialog.ItemRangePreview.Items.Item(RandomTileDialog.ItemRangePreview.Items.Count - modifier).Text = "N/A")
					modifier += 1
					If (RandomTileDialog.ItemRangePreview.Items.Count - modifier < 0) Then
						MessageBox.Show("There was an error formating the command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
						Exit Sub
					End If
				End While
				Ultima.Client.SendText(".randtile " & RandomTileDialog.ItemRangePreview.Items.Item(0).Text & " " & RandomTileDialog.ItemRangePreview.Items.Item(RandomTileDialog.ItemRangePreview.Items.Count - 1).Text & " " & RandomTileDialog.HeightToCreateAt.Value)
			End If
			RandomTileDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub

	'#################################################'
	'################## ITEMS TAB ####################'
	'#################################################'
	'Destroy buttons and randtile buttons are handled by functions for Building Tab

	Private Sub ItemsTab_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemsTab.Enter
		If (ItemCategoryTree.Nodes.Count = 0) Then
			' Suppress repainting the TreeView until all the objects have been created.
			ItemCategoryTree.BeginUpdate()
			' Clear the TreeView each time the method is called.
			ItemCategoryTree.Nodes.Clear()
			Dim lastGKey As Integer = -1
			Dim lastCKey As Integer = -1
			For Each line As String In MainItemsList
				If (line.StartsWith("G")) Then
					lastGKey += 1
					lastCKey = -1
					ItemCategoryTree.Nodes.Add(line.Substring(2, line.Length - 2), line.Substring(2, line.Length - 2))
					Continue For
				End If
				If (line.StartsWith("C") And (lastGKey >= 0)) Then
					lastCKey += 1
					ItemCategoryTree.Nodes(lastGKey).Nodes.Add(line.Substring(2, line.Length - 2), line.Substring(2, line.Length - 2))
					Continue For
				End If
				If ((line.StartsWith("S")) And (lastGKey >= 0) And (lastCKey >= 0)) Then
					ItemCategoryTree.Nodes(lastGKey).Nodes(lastCKey).Nodes.Add(line.Substring(2, line.Length - 2), line.Substring(2, line.Length - 2))
				End If
			Next line
			' Begin repainting the TreeView.
			ItemCategoryTree.EndUpdate()
		End If
	End Sub
	Private Sub ItemCategoryTree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles ItemCategoryTree.AfterSelect
		Dim FoundParent As Boolean = False
		Dim FoundCat As Boolean = False
		Dim ParentNode As String = Nothing

		ItemItemList.BeginUpdate()
		ItemItemList.Nodes.Clear()

		Try
			ParentNode = ItemCategoryTree.SelectedNode.Parent.Text
		Catch ex As Exception
			FoundParent = True
		End Try

		For Each line As String In MainItemsList
			If (FoundParent = False) Then
				If (ItemCategoryTree.SelectedNode.Parent.Text = line.Substring(2, line.Length - 2)) Then
					FoundParent = True
					Continue For
				End If
			End If
			If (FoundParent = True) Then
				If (ItemCategoryTree.SelectedNode.Text = line.Substring(2, line.Length - 2)) Then
					FoundCat = True
					Continue For
				End If
				If (FoundCat = True) Then
					If ((line.StartsWith("G")) Or (line.StartsWith("C")) Or (line.StartsWith("S"))) Then
						FoundCat = False
						Exit For
					End If
					If (line.StartsWith("I")) Then
						ItemItemList.Nodes.Add(line.Substring(52, line.Length - 52), line.Substring(2, 50).TrimEnd(" "))
					End If
				End If
			End If
		Next line

		ItemItemList.EndUpdate()
	End Sub

	'Collapse / Expand
	Private Sub CollapseMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollapseMenuItem2.Click
		ItemCategoryTree.CollapseAll()
	End Sub
	Private Sub ExpandMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandMenuItem2.Click
		ItemCategoryTree.ExpandAll()
	End Sub

	'Search by Name
	Private Sub SearchNameMenuItem2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchNameMenuItem2.GotFocus
		If (SearchNameMenuItem2.Text = "Search by Name") Then
			SearchNameMenuItem2.Text = ""
			SearchNameMenuItem2.ForeColor = Color.Black
		End If
	End Sub
	Private Sub SearchNameMenuItem2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchNameMenuItem2.KeyDown
		If (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return) Then
			SearchNameMenuItem2.AutoCompleteCustomSource.Add(SearchNameMenuItem2.Text)
			My.Settings.SearchByName2_AutoComplete = SearchNameMenuItem2.AutoCompleteCustomSource
			Collapse_ExpandMenu2.Hide()
			Dim LastCategory As String = Nothing
			Dim FoundItem As String = Nothing
			For Each line As String In MainItemsList
				If (line.StartsWith("C") Or line.StartsWith("S")) Then
					LastCategory = line.Substring(2, line.Length - 2).TrimEnd(" ")
				End If
				If (line.StartsWith("I")) Then
					If (line.Substring(2, 50).TrimEnd(" ").ToLower.Contains(SearchNameMenuItem2.Text.ToLower)) Then
						FoundItem = line.Substring(52, line.Length - 52).Trim(" ")
						Exit For
					End If
				Else
					If (line.Substring(2, line.Length - 2).TrimEnd(" ").ToLower.Contains(SearchNameMenuItem2.Text.ToLower)) Then
						FoundItem = Nothing
						Exit For
					End If
				End If
			Next
			ItemCategoryTree.SelectedNode = ItemCategoryTree.Nodes.Find(LastCategory, True)(0)
			If (FoundItem IsNot Nothing) Then
				Dim FoundNode() As TreeNode = ItemItemList.Nodes.Find(FoundItem, True)
				If (FoundNode.Length > 0) Then
					ItemItemList.SelectedNode = FoundNode(0)
				End If
			End If
			e.Handled = True
			SearchNameMenuItem2.Text = "Search by Name"
			SearchNameMenuItem2.ForeColor = Color.Gray
		End If
	End Sub
	Private Sub SearchNameMenuItem2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchNameMenuItem2.LostFocus
		If (SearchNameMenuItem2.Text = "") Then
			SearchNameMenuItem2.Text = "Search by Name"
			SearchNameMenuItem2.ForeColor = Color.Gray
		End If
	End Sub

	'Seatch by ID
	Private Sub SearchIDMenuItem2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchIDMenuItem2.GotFocus
		If (SearchIDMenuItem2.Text = "Search by ID") Then
			SearchIDMenuItem2.Text = ""
			SearchIDMenuItem2.ForeColor = Color.Black
		End If
	End Sub
	Private Sub SearchIDMenuItem2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchIDMenuItem2.KeyDown
		If (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return) Then
			SearchIDMenuItem2.AutoCompleteCustomSource.Add(SearchIDMenuItem2.Text)
			My.Settings.SearchByID2_AutoComplete = SearchIDMenuItem2.AutoCompleteCustomSource
			Collapse_ExpandMenu1.Hide()
			Dim LastCategory As String = Nothing
			Dim FoundItem As String = Nothing
			For Each line As String In MainItemsList
				If (line.StartsWith("C") Or line.StartsWith("S")) Then
					LastCategory = line.Substring(2, line.Length - 2).TrimEnd(" ")
				End If
				If (line.StartsWith("I")) Then
					If (line.Substring(52, line.Length - 52).Trim(" ").ToLower.Contains(SearchIDMenuItem2.Text.ToLower)) Then
						FoundItem = line.Substring(52, line.Length - 52).Trim(" ")
						Exit For
					End If
				End If
			Next
			ItemCategoryTree.SelectedNode = ItemCategoryTree.Nodes.Find(LastCategory, True)(0)
			If (FoundItem IsNot Nothing) Then
				Dim FoundNode() As TreeNode = ItemItemList.Nodes.Find(FoundItem, True)
				If (FoundNode.Length > 0) Then
					ItemItemList.SelectedNode = FoundNode(0)
				End If
			End If
			e.Handled = True
			SearchIDMenuItem2.Text = "Search by ID"
			SearchIDMenuItem2.ForeColor = Color.Gray
		End If
	End Sub
	Private Sub SearchIDMenuItem2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchIDMenuItem2.LostFocus
		If (SearchIDMenuItem2.Text = "") Then
			SearchIDMenuItem2.Text = "Search by ID"
			SearchIDMenuItem2.ForeColor = Color.Gray
		End If
	End Sub

    Private Sub ItemItemList_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles ItemItemList.AfterSelect
        'modified
        ItemItemPreview.Image = Ultima.Art.GetStatic(Convert.ToInt32(ItemItemList.SelectedNode.Name, 16))
        ItemItemID.Text = "ID: 0x" & ItemItemList.SelectedNode.Name.ToString
        ToolTip.SetToolTip(ItemItemID, "Hex ID number of the currently selected item." + vbCrLf + vbCrLf + "Decimal Value: " + Convert.ToInt32(ItemItemList.SelectedNode.Name, 16).ToString)
    End Sub

	Private Sub CreateFeetBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateFeetBtn2.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (ItemItemList.SelectedNode.Name IsNot Nothing) Then
					Ultima.Client.BringToTop()
					Ultima.Client.SendText(".createf " & Convert.ToInt32(ItemItemList.SelectedNode.Name, 16).ToString)
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub CreatePackBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreatePackBtn2.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (ItemItemList.SelectedNode.Name IsNot Nothing) Then
					Ultima.Client.BringToTop()
					Ultima.Client.SendText(".create " & Convert.ToInt32(ItemItemList.SelectedNode.Name, 16).ToString)
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub CreateTargetBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateTargetBtn2.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (ItemItemList.SelectedNode.Name IsNot Nothing) Then
					Ultima.Client.BringToTop()
					Ultima.Client.SendText(".createat " & Convert.ToInt32(ItemItemList.SelectedNode.Name, 16).ToString)
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub CreateTiledBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateTiledBtn2.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (ItemItemList.SelectedNode.Name IsNot Nothing) Then
					Dim GenericNumericDialog As New GenericNumericDialog
					GenericNumericDialog.TopMost = Me.TopMost
					GenericNumericDialog.NumericUpDown.Value = INIHandler.Sections("ITEM TAB").Settings("TileHieght")
					GenericNumericDialog.Description.Text = "Enter the height at which to create the item(s)..."
					Dim Returned As DialogResult = GenericNumericDialog.ShowDialog()
					If (Returned = Windows.Forms.DialogResult.OK) Then
						INIHandler.Sections.Sections("ITEM TAB").Settings.Set("TileHieght", GenericNumericDialog.NumericUpDown.Value.ToString)
						INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
						Ultima.Client.BringToTop()
						Ultima.Client.SendText(".tile " & Convert.ToInt32(ItemItemList.SelectedNode.Name, 16).ToString & " " & GenericNumericDialog.NumericUpDown.Value)
					End If
					GenericNumericDialog.Dispose()
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub HueItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HueItemBtn.Click
		Dim HueItemDialog As New HueItemDialog
		HueItemDialog.TopMost = Me.TopMost
		HueItemDialog.ShowDialog()
		HueItemDialog.Dispose()
	End Sub

	'#################################################'
	'############### ITEM TWEAK TAB ##################'
	'#################################################'

	Private Sub NudgeNorthBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeNorthBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (CopyNudgeChk.Checked = True) Then
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mcy -" & NudgeVal.Value.ToString)
				Else
					Ultima.Client.SendText(".cy -" & NudgeVal.Value.ToString)
				End If
			Else
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mpy -" & NudgeVal.Value.ToString)
				Else
					Ultima.Client.SendText(".py -" & NudgeVal.Value.ToString)
				End If
			End If
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub NudgeSouthBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeSouthBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (CopyNudgeChk.Checked = True) Then
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mcy " & NudgeVal.Value.ToString)
				Else
					Ultima.Client.SendText(".cy " & NudgeVal.Value.ToString)
				End If
			Else
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mpy " & NudgeVal.Value.ToString)
				Else
					Ultima.Client.SendText(".py " & NudgeVal.Value.ToString)
				End If
			End If
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub NudgeEastBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeEastBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (CopyNudgeChk.Checked = True) Then
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mcx " & NudgeVal.Value.ToString)
				Else
					Ultima.Client.SendText(".cx " & NudgeVal.Value.ToString)
				End If
			Else
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mpx " & NudgeVal.Value.ToString)
				Else
					Ultima.Client.SendText(".px " & NudgeVal.Value.ToString)
				End If
			End If
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub NudgeWestBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeWestBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (CopyNudgeChk.Checked = True) Then
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mcx -" & NudgeVal.Value.ToString)
				Else
					Ultima.Client.SendText(".cx -" & NudgeVal.Value.ToString)
				End If
			Else
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mpx -" & NudgeVal.Value.ToString)
				Else
					Ultima.Client.SendText(".px -" & NudgeVal.Value.ToString)
				End If
			End If
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub NudgeUpBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeUpBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (CopyNudgeChk.Checked = True) Then
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mcz " & HeightVal.Value.ToString)
				Else
					Ultima.Client.SendText(".cz " & HeightVal.Value.ToString)
				End If
			Else
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mpz " & HeightVal.Value.ToString)
				Else
					Ultima.Client.SendText(".pz " & HeightVal.Value.ToString)
				End If
			End If
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub NudgeDownBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeDownBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (CopyNudgeChk.Checked = True) Then
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mcz -" & HeightVal.Value.ToString)
				Else
					Ultima.Client.SendText(".cz -" & HeightVal.Value.ToString)
				End If
			Else
				If (MultipleNudgeChk.Checked = True) Then
					Ultima.Client.SendText(".mpz -" & HeightVal.Value.ToString)
				Else
					Ultima.Client.SendText(".pz -" & HeightVal.Value.ToString)
				End If
			End If
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub CopyNudgeChk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CopyNudgeChk.CheckedChanged
		If (CopyNudgeChk.Checked = True) Then
			If (MultipleNudgeChk.Checked = True) Then
				ToolTip.SetToolTip(NudgeNorthBtn, "Copies the targeted item North multiple times.")
				ToolTip.SetToolTip(NudgeWestBtn, "Copies the targeted item West multiple times.")
				ToolTip.SetToolTip(NudgeSouthBtn, "Copies the targeted item South multiple times.")
				ToolTip.SetToolTip(NudgeEastBtn, "Copies the targeted item East multiple times.")
				ToolTip.SetToolTip(NudgeUpBtn, "Copies the targeted item Up multiple times.")
				ToolTip.SetToolTip(NudgeDownBtn, "Copies the targeted item Down multiple times.")
			Else
				ToolTip.SetToolTip(NudgeNorthBtn, "Copies the targeted item North.")
				ToolTip.SetToolTip(NudgeWestBtn, "Copies the targeted item West.")
				ToolTip.SetToolTip(NudgeSouthBtn, "Copies the targeted item South.")
				ToolTip.SetToolTip(NudgeEastBtn, "Copies the targeted item East.")
				ToolTip.SetToolTip(NudgeUpBtn, "Copies the targeted item Up.")
				ToolTip.SetToolTip(NudgeDownBtn, "Copies the targeted item Down.")
			End If
		Else
			If (MultipleNudgeChk.Checked = True) Then
				ToolTip.SetToolTip(NudgeNorthBtn, "Moves the targeted item North multiple times.")
				ToolTip.SetToolTip(NudgeWestBtn, "Moves the targeted item West multiple times.")
				ToolTip.SetToolTip(NudgeSouthBtn, "Moves the targeted item South multiple times.")
				ToolTip.SetToolTip(NudgeEastBtn, "Moves the targeted item East multiple times.")
				ToolTip.SetToolTip(NudgeUpBtn, "Moves the targeted item Up multiple times.")
				ToolTip.SetToolTip(NudgeDownBtn, "Moves the targeted item Down multiple times.")
			Else
				ToolTip.SetToolTip(NudgeNorthBtn, "Moves the targeted item North.")
				ToolTip.SetToolTip(NudgeWestBtn, "Moves the targeted item West.")
				ToolTip.SetToolTip(NudgeSouthBtn, "Moves the targeted item South.")
				ToolTip.SetToolTip(NudgeEastBtn, "Moves the targeted item East.")
				ToolTip.SetToolTip(NudgeUpBtn, "Moves the targeted item Up.")
				ToolTip.SetToolTip(NudgeDownBtn, "Moves the targeted item Down.")
			End If
		End If
	End Sub
	Private Sub MultipleNudgeChk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MultipleNudgeChk.CheckedChanged
		If (MultipleNudgeChk.Checked = True) Then
			If (CopyNudgeChk.Checked = True) Then
				ToolTip.SetToolTip(NudgeNorthBtn, "Copies the targeted item North multiple times.")
				ToolTip.SetToolTip(NudgeWestBtn, "Copies the targeted item West multiple times.")
				ToolTip.SetToolTip(NudgeSouthBtn, "Copies the targeted item South multiple times.")
				ToolTip.SetToolTip(NudgeEastBtn, "Copies the targeted item East multiple times.")
				ToolTip.SetToolTip(NudgeUpBtn, "Copies the targeted item Up multiple times.")
				ToolTip.SetToolTip(NudgeDownBtn, "Copies the targeted item Down multiple times.")
			Else
				ToolTip.SetToolTip(NudgeNorthBtn, "Moves the targeted item North multiple times.")
				ToolTip.SetToolTip(NudgeWestBtn, "Moves the targeted item West multiple times.")
				ToolTip.SetToolTip(NudgeSouthBtn, "Moves the targeted item South multiple times.")
				ToolTip.SetToolTip(NudgeEastBtn, "Moves the targeted item East multiple times.")
				ToolTip.SetToolTip(NudgeUpBtn, "Moves the targeted item Up multiple times.")
				ToolTip.SetToolTip(NudgeDownBtn, "Moves the targeted item Down multiple times.")
			End If
		Else
			If (CopyNudgeChk.Checked = True) Then
				ToolTip.SetToolTip(NudgeNorthBtn, "Copies the targeted item North.")
				ToolTip.SetToolTip(NudgeWestBtn, "Copies the targeted item West.")
				ToolTip.SetToolTip(NudgeSouthBtn, "Copies the targeted item South.")
				ToolTip.SetToolTip(NudgeEastBtn, "Copies the targeted item East.")
				ToolTip.SetToolTip(NudgeUpBtn, "Copies the targeted item Up.")
				ToolTip.SetToolTip(NudgeDownBtn, "Copies the targeted item Down.")
			Else
				ToolTip.SetToolTip(NudgeNorthBtn, "Moves the targeted item North.")
				ToolTip.SetToolTip(NudgeWestBtn, "Moves the targeted item West.")
				ToolTip.SetToolTip(NudgeSouthBtn, "Moves the targeted item South.")
				ToolTip.SetToolTip(NudgeEastBtn, "Moves the targeted item East.")
				ToolTip.SetToolTip(NudgeUpBtn, "Moves the targeted item Up.")
				ToolTip.SetToolTip(NudgeDownBtn, "Moves the targeted item Down.")
			End If
		End If
	End Sub

	Private Sub ItemInfoBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemInfoBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".iteminfo")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub RenameItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameItemBtn.Click, NPCRename.Click
		If (Ultima.Client.Running = True) Then
			Dim GenericStringDialog As New GenericStringDialog
			GenericStringDialog.TopMost = Me.TopMost
			GenericStringDialog.TextBox.Text = INIHandler.Sections("ITEM TWEAK TAB").Settings("RenameItem")
			GenericStringDialog.Description.Text = "Please specify the new name..."
			Dim Returned As DialogResult
			Returned = GenericStringDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("ITEM TWEAK TAB").Settings.Set("RenameItem", GenericStringDialog.TextBox.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_rename " & GenericStringDialog.TextBox.Text)
			End If
			GenericStringDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub LockDownBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockDownBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_lockdown")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub ReleaseItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleaseItemBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_release")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub LockRadiusBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockRadiusBtn.Click
		If (Ultima.Client.Running = True) Then
			If (NumericUpDown3.Value > 0) Then
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_lockradius " & NumericUpDown3.Value.ToString)
			End If
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub MassMoveBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MassMoveBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".massmove")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub CopyPasteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyPasteBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".copypaste")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub CopyItemsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyItemsBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".copy")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub PasteItemsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteItemsBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".paste")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub MoveItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveItemBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_moveitem")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub LockBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_lock")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub UnlockBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnlockBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_unlock")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub RelockBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelockBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_relock")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub KeyBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeyBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_makekey")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub RekeyBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RekeyBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_rekey")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub MoveContBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveContBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_movetocont")
		Else
			ShowError("noclient")
		End If

	End Sub

	'#################################################'
	'#################### NPC TAB ####################'
	'#################################################'

	Public NPCAnimation() As Ultima.Frame
	Public NPCAnimationID As Integer = 0
	Public NPCAnimationLength As Integer = 0
	Public NPCAnimationHue As Integer = 0
	Public NPCAnimationFrame As Integer = -1

	Private Sub NPCTab_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NPCTab.Enter
		If (NPCCategoryList.Nodes.Count = 0) Then
			' Suppress repainting the TreeView until all the objects have been created.
			NPCCategoryList.BeginUpdate()
			' Clear the TreeView each time the method is called.
			NPCCategoryList.Nodes.Clear()
			Dim lastGKey As Integer = -1
			For Each line As String In NPCsList
				If (line.StartsWith("G")) Then
					lastGKey += 1
					NPCCategoryList.Nodes.Add(line.Substring(2, line.Length - 2))
					Continue For
				End If
				If ((line.StartsWith("S")) And (lastGKey >= 0)) Then
					NPCCategoryList.Nodes(lastGKey).Nodes.Add(line.Substring(2, line.Length - 2))
				End If
			Next line
			' Begin repainting the TreeView.
			NPCCategoryList.EndUpdate()
		End If

		If ((NPCAnimationID <> 0) And (NPCAnimationLength <> 0) And (NPCAnimationFrame <> -1)) Then
			NPCAnimationTimer.Start()
		End If

	End Sub

	Private Sub NPCCategoryList_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles NPCCategoryList.AfterSelect
		Dim OK As Boolean = False

		' Suppress repainting the TreeView until all the objects have been created.
		NPCList.BeginUpdate()

		' Clear the TreeView each time the method is called.
		NPCList.Nodes.Clear()

		For Each line As String In NPCsList
			If (NPCCategoryList.SelectedNode.Text = line.Substring(2, line.Length - 2)) Then
				OK = True
				Continue For
			End If
			If (((line.StartsWith("G")) Or (line.StartsWith("S"))) And (OK = True)) Then
				OK = False
				Exit For
			End If
			If ((OK = True) And (line.StartsWith("N"))) Then
				NPCList.Nodes.Add(line.Substring(2, line.Length - 2))
			End If

		Next line

		' Begin repainting the TreeView.
		NPCList.EndUpdate()

	End Sub

	Private Sub CollapseMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollapseMenuItem3.Click
		NPCCategoryList.CollapseAll()
	End Sub
	Private Sub ExpandMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandMenuItem3.Click
		NPCCategoryList.ExpandAll()
	End Sub

	'Search by Name
	Private Sub SearchByNameTextBox3_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchByNameTextBox3.GotFocus
		If (SearchByNameTextBox3.Text = "Search by Name") Then
			SearchByNameTextBox3.Text = ""
			SearchByNameTextBox3.ForeColor = Color.Black
		End If
	End Sub
	Private Sub SearchByNameTextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchByNameTextBox3.KeyDown
		If (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return) Then
			SearchByNameTextBox3.AutoCompleteCustomSource.Add(SearchByNameTextBox3.Text)
			My.Settings.SearchByName3_AutoComplete = SearchByNameTextBox3.AutoCompleteCustomSource

			Collapse_ExpandMenu3.Hide()
			Dim LastCategory As String = Nothing
			Dim FoundItem As String = Nothing
			For Each line As String In NPCsList
				If (line.StartsWith("C") Or line.StartsWith("S")) Then
					LastCategory = line.Substring(2, line.Length - 2).TrimEnd(" ")
				End If
				If (line.StartsWith("I")) Then
					If (line.Substring(2, 50).TrimEnd(" ").ToLower.Contains(SearchByNameTextBox3.Text.ToLower)) Then
						FoundItem = line.Substring(52, line.Length - 52).Trim(" ")
						Exit For
					End If
				Else
					If (line.Substring(2, line.Length - 2).TrimEnd(" ").ToLower.Contains(SearchByNameTextBox3.Text.ToLower)) Then
						FoundItem = Nothing
						Exit For
					End If
				End If
			Next
			NPCCategoryList.SelectedNode = NPCCategoryList.Nodes.Find(LastCategory, True)(0)
			If (FoundItem IsNot Nothing) Then
				Dim FoundNode() As TreeNode = NPCList.Nodes.Find(FoundItem, True)
				If (FoundNode.Length > 0) Then
					NPCList.SelectedNode = FoundNode(0)
				End If
			End If
			e.Handled = True
			SearchByNameTextBox3.Text = "Search by Name"
			SearchByNameTextBox3.ForeColor = Color.Gray
		End If
	End Sub
	Private Sub SearchByNameTextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchByNameTextBox3.LostFocus
		If (SearchByNameTextBox3.Text = "") Then
			SearchByNameTextBox3.Text = "Search by Name"
			SearchByNameTextBox3.ForeColor = Color.Gray
		End If
	End Sub

	Private Sub NPCList_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles NPCList.AfterSelect
		NPCPreviewImage.Image = Nothing
		If (NPCList.SelectedNode.Text IsNot Nothing) Then
			NPCAnimationError.Visible = False

			Dim FoundNPC As Boolean = False
			For Each line As String In NPCsList
				If (line.Substring(2, line.Length - 2) = NPCList.SelectedNode.Text) Then
					FoundNPC = True
					Continue For
				End If
				If ((FoundNPC = True) And (line.StartsWith("B"))) Then
					Try
						NPCAnimationID = Convert.ToInt32(line.Substring(2, line.Length - 2), 16)
					Catch ex As Exception
						NPCAnimationTimer.Stop()
						NPCAnimationError.Visible = True
						Exit Sub
					End Try
					Try
						NPCPreviewID.Text = "ID: 0x" & line.Substring(2, line.Length - 2)
						ToolTip.SetToolTip(NPCPreviewID, "Hex ID number of the currently selected item." + vbCrLf + vbCrLf + "Decimal Value: " + Convert.ToInt32(line.Substring(2, line.Length - 2), 16).ToString)
					Catch ex As Exception
						NPCAnimationTimer.Stop()
						NPCAnimationError.Visible = True
						Exit Sub
					End Try
					Continue For
				End If
				If ((FoundNPC = True) And (line.StartsWith("C"))) Then
					Try
						NPCAnimationHue = line.Substring(2, line.Length - 2)
					Catch ex As Exception
						NPCAnimationTimer.Stop()
						NPCAnimationError.Visible = True
						Exit Sub
					End Try
					Continue For
				End If
				If ((FoundNPC = True) And (line.StartsWith("N") Or line.StartsWith("S") Or line.StartsWith("G"))) Then
					Exit For
				End If
			Next line

			If ((FoundNPC = False)) Then
				NPCAnimationTimer.Stop()
				NPCAnimationError.Visible = True
				Exit Sub
			End If

            If ((NPCAnimationID <> 0)) Then
                'modified
                NPCAnimation = Ultima.Animations.GetAnimation(NPCAnimationID, 0, 1, 0, False)

                If (NPCAnimation(0).Bitmap.Width > NPCPreviewImage.Width) Then
                    NPCPreviewImage.SizeMode = PictureBoxSizeMode.Zoom
                Else
                    NPCPreviewImage.SizeMode = PictureBoxSizeMode.CenterImage
                End If

                NPCAnimationLength = NPCAnimation.Length() - 1
                If (NPCAnimationHue > 0) Then
                    For counter As Integer = 0 To NPCAnimationLength Step +1
                        Dim Hue As Ultima.Hue = Ultima.Hues.GetHue(NPCAnimationHue)
                        Hue.ApplyTo(NPCAnimation(counter).Bitmap, False)
                    Next counter
                End If

                If (My.Settings.AnimateNPCs = True) Then
                    NPCAnimationTimer.Start()
                Else
                    'NPCPreviewImage.Image = NPCAnimation(0).Bitmap
                End If
            End If

        Else
            NPCAnimationTimer.Stop()
            NPCAnimationID = 0
            NPCAnimationLength = 0
            NPCAnimationHue = 0
            NPCAnimationFrame = -1
        End If
	End Sub

	Private Sub NPCAnimationTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NPCAnimationTimer.Tick
		NPCAnimationFrame += 1
		If (NPCAnimationFrame > NPCAnimationLength) Then
			NPCAnimationFrame = 0
		End If

        Dim ImageLocation As New Point(((GroupBox23.Size.Width / 2) - (NPCAnimation(NPCAnimationFrame).Bitmap.Width / 2)) - NPCAnimation(NPCAnimationFrame).Center.X, ((GroupBox23.Size.Height / 2) - (NPCAnimation(NPCAnimationFrame).Bitmap.Height / 2)) - (NPCAnimation(NPCAnimationFrame).Center.Y + NPCAnimation(NPCAnimationFrame).Bitmap.Height))
        NPCPreviewImage.Location.Offset(NPCAnimation(NPCAnimationFrame).Center.X, NPCAnimation(NPCAnimationFrame).Center.Y + NPCAnimation(NPCAnimationFrame).Bitmap.Height)
        NPCPreviewImage.Size = New Point(NPCAnimation(NPCAnimationFrame).Bitmap.Width, NPCAnimation(NPCAnimationFrame).Bitmap.Height)
        NPCPreviewImage.Location = ImageLocation
        'modified
        NPCPreviewImage.Image = NPCAnimation(NPCAnimationFrame).Bitmap
	End Sub

	Private Sub DecreaseAnimationSpeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DecreaseAnimationSpeed.Click
		NPCAnimationTimer.Interval = NPCAnimationTimer.Interval + 10
	End Sub
	Private Sub IncreaseAnimationSpeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncreaseAnimationSpeed.Click
		If ((NPCAnimationTimer.Interval - 10) <= 0) Then
			NPCAnimationTimer.Interval = 1
		Else
			NPCAnimationTimer.Interval = NPCAnimationTimer.Interval - 10
		End If
	End Sub

	Private Sub CreateNPC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateNPC.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (NPCList.SelectedNode.Name IsNot Nothing) Then
					Ultima.Client.BringToTop()
                    Ultima.Client.SendText(".sa_createnpc " & NPCList.SelectedNode.Text)
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub CreateNPCHidden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateNPCHidden.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (NPCList.SelectedNode.Name IsNot Nothing) Then
					Ultima.Client.BringToTop()
                    Ultima.Client.SendText(".sa_createhidden " & NPCList.SelectedNode.Text)
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub CreateGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateGroup.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (NPCList.SelectedNode.Name IsNot Nothing) Then
					Dim GenericNumericDialog As New GenericNumericDialog
					GenericNumericDialog.TopMost = Me.TopMost
					Int32.TryParse(INIHandler.Sections("NPC TAB").Settings("CreateGroup"), GenericNumericDialog.NumericUpDown.Value)
					GenericNumericDialog.NumericUpDown.Maximum = 10
					GenericNumericDialog.Description.Text = "Enter the number of NPCs to create..."
					Dim Returned As DialogResult = GenericNumericDialog.ShowDialog()
					If (Returned = Windows.Forms.DialogResult.OK) Then
						INIHandler.Sections.Sections("NPC TAB").Settings.Set("CreateGroup", GenericNumericDialog.NumericUpDown.Value.ToString)
						INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
						Ultima.Client.BringToTop()
						Ultima.Client.SendText(".creategroupnpc " & NPCList.SelectedNode.Text & " " & GenericNumericDialog.NumericUpDown.Value.ToString)
					End If
					GenericNumericDialog.Dispose()
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub KillNPC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KillNPC.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_kill")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub NPCTab_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles NPCTab.Leave
		NPCAnimationTimer.Stop()
	End Sub

	'#################################################'
	'################# NPC TWEAK TAB #################'
	'#################################################'
	'Some buttons handled by buttons of the same function under the Admin Tab

	'SetNPCSkill handled by SetPlayerSkill
	'SetNPCStat handled by SetPlayerStat
	'NPCBarber handled by BarberPlayerBtn
	'SetNPCInvul handled by InvulPlayerBtn

	'NPCRename handled by RenameItemBtn (under Item Tweak Tab)
	Private Sub CopyLook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyLook.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_copylook")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub NoTame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoTame.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_notame")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub NoProvoke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoProvoke.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_noprovoke")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub SayAbove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SayAbove.Click
		If (Ultima.Client.Running = True) Then
			Dim GenericStringDialog As New GenericStringDialog
			GenericStringDialog.Description.Text = "Enter the text to say above the mobile..."
			GenericStringDialog.TopMost = Me.TopMost
			GenericStringDialog.TextBox.Text = INIHandler.Sections("NPC TWEAK TAB").Settings("SayAbove")
			Dim Returned As DialogResult
			Returned = GenericStringDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("NPC TWEAK TAB").Settings.Set("SayAbove", GenericStringDialog.TextBox.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_sayabove " & GenericStringDialog.TextBox.Text)
			End If
			GenericStringDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Action.Click
		If (Ultima.Client.Running = True) Then
			Dim PerformActionDialog As New PerformActionDialog
			PerformActionDialog.TopMost = Me.TopMost
			If (INIHandler.Sections("NPC TWEAK TAB").Settings("PerformAction") = Nothing) Then
				PerformActionDialog.ActionList.SelectedItem = "Walk unarmed"
			Else
				PerformActionDialog.ActionList.SelectedItem = INIHandler.Sections("NPC TWEAK TAB").Settings("PerformAction")
			End If
			Dim Returned As DialogResult
			Returned = PerformActionDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("NPC TWEAK TAB").Settings.Set("PerformAction", SetCmdLvlDialog.CommandLevel.SelectedItem)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_action " & PerformActionDialog.SelectedAction)
			End If
			PerformActionDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub WalkTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WalkTo.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_walkto")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub RunTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunTo.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_runto")
		Else
			ShowError("noclient")
		End If
	End Sub

	'GetNPCInfo handled by GetPlayerInfoBtn
	'ThawNPC handled by ThawPlayerBtn
	'FreezeNPC handled by FreezePlayerBtn
	'RefreshNPC handled by RefreshPlayerBtn

	Private Sub RestartAI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartAI.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_restartai")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub Tame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tame.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_tame")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub SetNPCCriminal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetNPCCriminal.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_setprop criminal 1")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub SetNPCMurderer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetNPCMurderer.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_setprop murderer 1")
		Else
			ShowError("noclient")
		End If
	End Sub

	'HideNPC handled by HidePlayerBtn
	Private Sub EquipItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquipItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_equip")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub EquipFromTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquipFromTemplate.Click
		If (Ultima.Client.Running = True) Then
			Dim GenericStringDialog As New GenericStringDialog
			GenericStringDialog.Description.Text = "Enter the name of the template to use..."
			GenericStringDialog.TopMost = Me.TopMost
			GenericStringDialog.TextBox.Text = INIHandler.Sections("NPC TWEAK TAB").Settings("EquipFromTemplate")
			Dim Returned As DialogResult
			Returned = GenericStringDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("NPC TWEAK TAB").Settings.Set("EquipFromTemplate", GenericStringDialog.TextBox.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_equipt " & GenericStringDialog.TextBox.Text)
			End If
			GenericStringDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub

	'#################################################'
	'#################### GM TAB #####################'
	'#################################################'

	Private Sub ConcealMeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConcealMeBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_concealme")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub RevealMeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevealMeBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_unconcealme")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub ResMeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResMeBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_resme")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub RefreshMeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshMeBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_refreshme")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub GmFormBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GmFormBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_gmform")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub MyFormBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyFormBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_myform")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub ThawMeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThawMeBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_thawme")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub PowerUpBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PowerUpBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_powerup")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub PropEditBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropEditBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_propedit")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub AddObjPropBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddObjPropBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".addprop")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub SetObjPropBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetObjPropBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".setprop")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub DelObjPropBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelObjPropBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".delprop")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub AddGlobalPropBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddGlobalPropBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".addgprop")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub SetGlobalPropBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetGlobalPropBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".setgprop")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub DelGlobalPropBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelGlobalPropBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".delgprop")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub MarkBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_mark")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub RecallBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecallBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_recall")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub MakeTeleBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeTeleBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_maketele")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub AddGoBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddGoBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".addgoloc")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub LogNotifyBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogNotifyBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_lognotify")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub BroadcastBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BroadcastBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim BroadcastDialog As New BroadcastDialog
			BroadcastDialog.TopMost = Me.TopMost
			GenericStringDialog.TextBox.Text = INIHandler.Sections("GM TAB").Settings("BroadcastMessage")
			Dim Returned As DialogResult
			Returned = BroadcastDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("GM TAB").Settings.Set("BroadcastMessage", GenericStringDialog.TextBox.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
				If (BroadcastDialog.EveryoneOnline.Checked = True) Then
                    Ultima.Client.SendText(".sa_bcast " & BroadcastDialog.BCastMessage.Text)
				Else
                    Ultima.Client.SendText(".sa_gms " & BroadcastDialog.BCastMessage.Text)
				End If
			End If
			BroadcastDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub HelpQueueBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpQueueBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_counpage")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub NightsightBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NightsightBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_nsight")
		Else
			ShowError("noclient")
		End If
	End Sub
    Private Sub BankBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankBtn.Click
        If (Ultima.Client.Running = True) Then
            Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_openbank")
        Else
            ShowError("noclient")
        End If
    End Sub
    Private Sub PackBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PackBtn.Click
        If (Ultima.Client.Running = True) Then
            Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_openpack")
        Else
            ShowError("noclient")
        End If
    End Sub

	'#################################################'
	'################## TRAVEL TAB ###################'
	'#################################################'

	Private Sub TravelTab_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TravelTab.Enter
		If (TravelCategoryList.Nodes.Count = 0) Then
			' Suppress repainting the TreeView until all the objects have been created.
			TravelCategoryList.BeginUpdate()
			' Clear the TreeView each time the method is called.
			TravelCategoryList.Nodes.Clear()
			Dim lastCKey As Integer = -1
			For Each line As String In LocationsList
				If (line.StartsWith("C")) Then
					lastCKey += 1
					TravelCategoryList.Nodes.Add(line.Substring(2, line.Length - 2), line.Substring(2, line.Length - 2))
					Continue For
				End If
				If ((line.StartsWith("S")) And (lastCKey >= 0)) Then
					TravelCategoryList.Nodes(lastCKey).Nodes.Add(line.Substring(2, line.Length - 2), line.Substring(2, line.Length - 2))
				End If
			Next line
			' Begin repainting the TreeView.
			TravelCategoryList.EndUpdate()
		End If
	End Sub

	Private Sub TravelCategoryList_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TravelCategoryList.AfterSelect
		Dim OK As Boolean = False
		' Suppress repainting the TreeView until all the objects have been created.
		TravelLocationList.BeginUpdate()
		' Clear the TreeView each time the method is called.
		TravelLocationList.Nodes.Clear()
		For Each line As String In LocationsList
			If (TravelCategoryList.SelectedNode.Text = line.Substring(2, line.Length - 2)) Then
				OK = True
				Continue For
			End If
			If (((line.StartsWith("S")) Or (line.StartsWith("C"))) And (OK = True)) Then
				OK = False
				Exit For
			End If
			If ((OK = True) And (line.StartsWith("I"))) Then
				TravelLocationList.Nodes.Add(line.Substring(52, line.Length - 52), line.Substring(2, 50).TrimEnd(" "))
			End If
		Next line
		' Begin repainting the TreeView.
		TravelLocationList.EndUpdate()
	End Sub

	Private Sub CollapseMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollapseMenuItem4.Click
		TravelCategoryList.CollapseAll()
	End Sub
	Private Sub ExpandMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandMenuItem4.Click
		TravelCategoryList.ExpandAll()
	End Sub

	'Search by Name
	Private Sub SearchByNameTextBox4_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchByNameTextBox4.GotFocus
		If (SearchByNameTextBox4.Text = "Search by Name") Then
			SearchByNameTextBox4.Text = ""
			SearchByNameTextBox4.ForeColor = Color.Black
		End If
	End Sub
	Private Sub SearchByNameTextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchByNameTextBox4.KeyDown
		If (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return) Then
			SearchByNameTextBox4.AutoCompleteCustomSource.Add(SearchByNameTextBox4.Text)
			My.Settings.SearchByName4_AutoComplete = SearchByNameTextBox4.AutoCompleteCustomSource

			Collapse_ExpandMenu4.Hide()
			Dim LastCategory As String = Nothing
			Dim FoundItem As String = Nothing
			For Each line As String In LocationsList
				If (line.StartsWith("C") Or line.StartsWith("S")) Then
					LastCategory = line.Substring(2, line.Length - 2).TrimEnd(" ")
				End If
				If (line.StartsWith("I")) Then
					If (line.Substring(2, 50).TrimEnd(" ").ToLower.Contains(SearchByNameTextBox4.Text.ToLower)) Then
						FoundItem = line.Substring(52, line.Length - 52).Trim(" ")
						Exit For
					End If
				Else
					If (line.Substring(2, line.Length - 2).TrimEnd(" ").ToLower.Contains(SearchByNameTextBox4.Text.ToLower)) Then
						FoundItem = Nothing
						Exit For
					End If
				End If
			Next
			TravelCategoryList.SelectedNode = TravelCategoryList.Nodes.Find(LastCategory, True)(0)
			If (FoundItem IsNot Nothing) Then
				Dim FoundNode() As TreeNode = TravelLocationList.Nodes.Find(FoundItem, True)
				If (FoundNode.Length > 0) Then
					TravelLocationList.SelectedNode = FoundNode(0)
				End If
			End If
			e.Handled = True
			SearchByNameTextBox4.Text = "Search by Name"
			SearchByNameTextBox4.ForeColor = Color.Gray
		End If
	End Sub
	Private Sub SearchByNameTextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchByNameTextBox4.LostFocus
		If (SearchByNameTextBox4.Text = "") Then
			SearchByNameTextBox4.Text = "Search by Name"
			SearchByNameTextBox4.ForeColor = Color.Gray
		End If
	End Sub

	Private Sub TravelLocationList_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TravelLocationList.AfterSelect
		TravelCoordsText.Text = "Selected Location Coordinates: " & TravelLocationList.SelectedNode.Name.Replace(",", ", ")
	End Sub

	Private Sub GoBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoBtn.Click
		If (Ultima.Client.Running = True) Then
			Try
				If (TravelLocationList.SelectedNode.Name IsNot Nothing) Then
					Ultima.Client.BringToTop()
                    Ultima.Client.SendText(".sa_goxyz " & TravelLocationList.SelectedNode.Name.Replace(",", " "))
				End If
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub GotoBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_goto")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub GoXYZBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoXYZBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim GoXYZDialog As New GoXYZDialog
			GoXYZDialog.TopMost = Me.TopMost
			GoXYZDialog.XCoord.Text = INIHandler.Sections("TRAVEL TAB").Settings("GoXYZ_XCoord")
			GoXYZDialog.YCoord.Text = INIHandler.Sections("TRAVEL TAB").Settings("GoXYZ_YCoord")
			GoXYZDialog.ZCoord.Text = INIHandler.Sections("TRAVEL TAB").Settings("GoXYZ_ZCoord")
			Dim Returned As DialogResult
			Returned = GoXYZDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				INIHandler.Sections.Sections("TRAVEL TAB").Settings.Set("GoXYZ_XCoord", GoXYZDialog.XCoord.Text)
				INIHandler.Sections.Sections("TRAVEL TAB").Settings.Set("GoXYZ_YCoord", GoXYZDialog.YCoord.Text)
				INIHandler.Sections.Sections("TRAVEL TAB").Settings.Set("GoXYZ_ZCoord", GoXYZDialog.ZCoord.Text)
				INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
				Ultima.Client.BringToTop()
                Ultima.Client.SendText(".sa_goxyz " & GoXYZDialog.XCoord.Text & " " & GoXYZDialog.YCoord.Text & " " & GoXYZDialog.ZCoord.Text)
			End If
			GoXYZDialog.Dispose()
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub GoMenuBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoMenuBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".go")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub TeleBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TeleBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_tele")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub MTeleBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MTeleBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_mtele")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub TeleToBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TeleToBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".teleto")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub WhereBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WhereBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".where")
		Else
			ShowError("noclient")
		End If
	End Sub

	'#################################################'
	'################## TOOLS TAB ####################'
	'#################################################'

	Private Sub HexToDecBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HexToDecBtn.Click
		If (HexValueTextBox.Text IsNot Nothing) Then
			DecValueTextBox.Text = Convert.ToInt32(HexValueTextBox.Text, 16)
		End If
	End Sub
	Private Sub DecToHexBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DecToHexBtn.Click
		If (DecValueTextBox.Text IsNot Nothing) Then
			HexValueTextBox.Text = Hex(DecValueTextBox.Text)
		End If
	End Sub

	Public CalcNumber1 As Double = Nothing
	Public CalcEquation As String = Nothing
	Public CalcNumber2 As Double = Nothing

	Private Sub Calc0Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc0Btn.Click
		If (CalcEquation Is Nothing) Then
			CalcValueTextBox.Text = CalcValueTextBox.Text & "0"
			CalcNumber1 = CalcNumber1 & "0"
		Else
			If (CalcNumber2 = Nothing) Then
				CalcValueTextBox.Text = "0"
				CalcNumber2 = "0"
			Else
				CalcValueTextBox.Text = CalcValueTextBox.Text & "0"
				CalcNumber2 = CalcNumber2 & "0"
			End If
		End If
	End Sub
	Private Sub Calc1Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc1Btn.Click
		If (CalcEquation Is Nothing) Then
			CalcValueTextBox.Text = CalcValueTextBox.Text & "1"
			CalcNumber1 = CalcNumber1 & "1"
		Else
			If (CalcNumber2 = Nothing) Then
				CalcValueTextBox.Text = "1"
				CalcNumber2 = "1"
			Else
				CalcValueTextBox.Text = CalcValueTextBox.Text & "1"
				CalcNumber2 = CalcNumber2 & "1"
			End If
		End If
	End Sub
	Private Sub Calc2Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc2Btn.Click
		If (CalcEquation Is Nothing) Then
			CalcValueTextBox.Text = CalcValueTextBox.Text & "2"
			CalcNumber1 = CalcNumber1 & "2"
		Else
			If (CalcNumber2 = Nothing) Then
				CalcValueTextBox.Text = "2"
				CalcNumber2 = "2"
			Else
				CalcValueTextBox.Text = CalcValueTextBox.Text & "2"
				CalcNumber2 = CalcNumber2 & "2"
			End If
		End If
	End Sub
	Private Sub Calc3Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc3Btn.Click
		If (CalcEquation Is Nothing) Then
			CalcValueTextBox.Text = CalcValueTextBox.Text & "3"
			CalcNumber1 = CalcNumber1 & "3"
		Else
			If (CalcNumber2 = Nothing) Then
				CalcValueTextBox.Text = "3"
				CalcNumber2 = "3"
			Else
				CalcValueTextBox.Text = CalcValueTextBox.Text & "3"
				CalcNumber2 = CalcNumber2 & "3"
			End If
		End If
	End Sub
	Private Sub Calc4Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc4Btn.Click
		If (CalcEquation Is Nothing) Then
			CalcValueTextBox.Text = CalcValueTextBox.Text & "4"
			CalcNumber1 = CalcNumber1 & "4"
		Else
			If (CalcNumber2 = Nothing) Then
				CalcValueTextBox.Text = "4"
				CalcNumber2 = "4"
			Else
				CalcValueTextBox.Text = CalcValueTextBox.Text & "4"
				CalcNumber2 = CalcNumber2 & "4"
			End If
		End If
	End Sub
	Private Sub Calc5Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc5Btn.Click
		If (CalcEquation Is Nothing) Then
			CalcValueTextBox.Text = CalcValueTextBox.Text & "5"
			CalcNumber1 = CalcNumber1 & "5"
		Else
			If (CalcNumber2 = Nothing) Then
				CalcValueTextBox.Text = "5"
				CalcNumber2 = "5"
			Else
				CalcValueTextBox.Text = CalcValueTextBox.Text & "5"
				CalcNumber2 = CalcNumber2 & "5"
			End If
		End If
	End Sub
	Private Sub Calc6Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc6Btn.Click
		If (CalcEquation Is Nothing) Then
			CalcValueTextBox.Text = CalcValueTextBox.Text & "6"
			CalcNumber1 = CalcNumber1 & "6"
		Else
			If (CalcNumber2 = Nothing) Then
				CalcValueTextBox.Text = "6"
				CalcNumber2 = "6"
			Else
				CalcValueTextBox.Text = CalcValueTextBox.Text & "6"
				CalcNumber2 = CalcNumber2 & "6"
			End If
		End If
	End Sub
	Private Sub Calc7Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc7Btn.Click
		If (CalcEquation Is Nothing) Then
			CalcValueTextBox.Text = CalcValueTextBox.Text & "7"
			CalcNumber1 = CalcNumber1 & "7"
		Else
			If (CalcNumber2 = Nothing) Then
				CalcValueTextBox.Text = "7"
				CalcNumber2 = "7"
			Else
				CalcValueTextBox.Text = CalcValueTextBox.Text & "7"
				CalcNumber2 = CalcNumber2 & "7"
			End If
		End If
	End Sub
	Private Sub Calc8Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc8Btn.Click
		If (CalcEquation Is Nothing) Then
			CalcValueTextBox.Text = CalcValueTextBox.Text & "8"
			CalcNumber1 = CalcNumber1 & "8"
		Else
			If (CalcNumber2 = Nothing) Then
				CalcValueTextBox.Text = "8"
				CalcNumber2 = "8"
			Else
				CalcValueTextBox.Text = CalcValueTextBox.Text & "8"
				CalcNumber2 = CalcNumber2 & "8"
			End If
		End If
	End Sub
	Private Sub Calc9Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc9Btn.Click
		If (CalcEquation Is Nothing) Then
			CalcValueTextBox.Text = CalcValueTextBox.Text & "9"
			CalcNumber1 = CalcNumber1 & "9"
		Else
			If (CalcNumber2 = Nothing) Then
				CalcValueTextBox.Text = "9"
				CalcNumber2 = "9"
			Else
				CalcValueTextBox.Text = CalcValueTextBox.Text & "9"
				CalcNumber2 = CalcNumber2 & "9"
			End If
		End If
	End Sub

	Private Sub CalcDivideBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcDivideBtn.Click
		If (CalcEquation IsNot Nothing) Then
			CalcNumber1 = Calculate(CalcNumber1, CalcEquation, CalcNumber2)
			CalcValueTextBox.Text = CalcNumber1.ToString
			CalcNumber2 = Nothing
		End If
		CalcEquation = "/"
	End Sub
	Private Sub CalcMultiplyBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcMultiplyBtn.Click
		If (CalcEquation IsNot Nothing) Then
			CalcNumber1 = Calculate(CalcNumber1, CalcEquation, CalcNumber2)
			CalcValueTextBox.Text = CalcNumber1.ToString
			CalcNumber2 = Nothing
		End If
		CalcEquation = "*"
	End Sub
	Private Sub CalcSubtractBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcSubtractBtn.Click
		If (CalcEquation IsNot Nothing) Then
			CalcNumber1 = Calculate(CalcNumber1, CalcEquation, CalcNumber2)
			CalcValueTextBox.Text = CalcNumber1.ToString
			CalcNumber2 = Nothing
		End If
		CalcEquation = "-"
	End Sub
	Private Sub CalcAddBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcAddBtn.Click
		If (CalcEquation IsNot Nothing) Then
			CalcNumber1 = Calculate(CalcNumber1, CalcEquation, CalcNumber2)
			CalcValueTextBox.Text = CalcNumber1.ToString
			CalcNumber2 = Nothing
		End If
		CalcEquation = "+"
	End Sub

	Private Sub CalcDecimalBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcDecimalBtn.Click
		If (CalcEquation Is Nothing) Then
			CalcValueTextBox.Text = CalcValueTextBox.Text & "."
			CalcNumber1 = CalcNumber1 & "."
		Else
			If (CalcNumber2 = Nothing) Then
				CalcValueTextBox.Text = "."
				CalcNumber2 = "."
			Else
				CalcValueTextBox.Text = CalcValueTextBox.Text & "."
				CalcNumber2 = CalcNumber2 & "."
			End If
		End If
	End Sub
	Private Sub CalcPositiveNegativeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcPositiveNegativeBtn.Click
		If (CalcNumber1 <> Nothing) Then
			CalcNumber1 = (CalcNumber1 - (CalcNumber1 * 2))
			CalcValueTextBox.Text = CalcNumber1.ToString
		ElseIf (CalcNumber2 <> Nothing) Then
			CalcNumber2 = (CalcNumber2 - (CalcNumber2 * 2))
			CalcValueTextBox.Text = CalcNumber2.ToString
		End If
	End Sub

	Private Sub CalcClearBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcClearBtn.Click
		CalcValueTextBox.Text = "0"
		CalcNumber1 = Nothing
		CalcEquation = Nothing
		CalcNumber2 = Nothing
	End Sub
	Private Sub CalcEqualBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcEqualBtn.Click
		If ((CalcEquation IsNot Nothing) And (CalcNumber2 <> Nothing)) Then
			CalcNumber1 = Calculate(CalcNumber1, CalcEquation, CalcNumber2)
			CalcValueTextBox.Text = CalcNumber1.ToString
			CalcNumber2 = Nothing
			CalcEquation = Nothing
		End If
	End Sub

	Private Sub LaunchPatchClientBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaunchPatchClientBtn.Click
		If (My.Settings.NightscapeLocation <> "") Then
			Dim PatchClient As New Process
			PatchClient.StartInfo.FileName = "nspatch.exe"
			PatchClient.StartInfo.UseShellExecute = True
			PatchClient.StartInfo.WorkingDirectory = My.Settings.NightscapeLocation
			Try
				PatchClient.Start()
				PatchClient.WaitForInputIdle()
			Catch ex As Exception
				MessageBox.Show("Failed to load the Nightscape Patch Client: " & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		Else
			MessageBox.Show("Unable to launch Nightscape Patch Client." & vbCrLf & vbCrLf & "The location of the Nightscape installation has not been specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub
	Private Sub LaunchNSClientBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaunchNSClientBtn.Click
		If ((My.Settings.NightscapeLocation <> "") And (Ultima.Client.Running = False)) Then
			Dim NSClient As New Process
            'NSClient.StartInfo.FileName = "nsclient.exe"
            NSClient.StartInfo.FileName = "Decrypted_client.exe"
            NSClient.StartInfo.UseShellExecute = True
			NSClient.StartInfo.WorkingDirectory = My.Settings.NightscapeLocation
			Try
				NSClient.Start()
				NSClient.WaitForInputIdle()
				If (My.Settings.TrackLocation = True) Then
					Dim TrackLocationThread As New System.Threading.Thread(AddressOf TrackLocation)
					TrackLocationThread.IsBackground = True
					TrackLocationThread.Priority = Threading.ThreadPriority.Lowest
					TrackLocationThread.Start()
				End If
			Catch ex As Exception
				MessageBox.Show("Failed to load the Nightscape Client: " & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		Else
			MessageBox.Show("Unable to launch Nightscape Game Client." & vbCrLf & vbCrLf & "The location of the Nightscape installation has not been specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub
	Private Sub LaunchInsideUOBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaunchInsideUOBtn.Click
		If (My.Settings.InsideUOLocation <> "") Then
			Dim InsideUO As New Process
			InsideUO.StartInfo.FileName = "insideuo.exe"
			InsideUO.StartInfo.UseShellExecute = True
			InsideUO.StartInfo.WorkingDirectory = My.Settings.InsideUOLocation
			Try
				InsideUO.Start()
				InsideUO.WaitForInputIdle()
			Catch ex As Exception
				MessageBox.Show("Failed to load InsideUO: " & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		Else
			MessageBox.Show("Unable to launch InsideUO." & vbCrLf & vbCrLf & "The location of the InsideUO installation has not been specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	'User Launch Button 1
	Private Sub AssignProgramMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssignProgramMenuItem1.Click
		Dim ProgramLauncherSetupDialog As New ProgramLauncherSetupDialog
		ProgramLauncherSetupDialog.TopMost = Me.TopMost
		ProgramLauncherSetupDialog.ButtonName.Text = My.Settings.UserLaunch1_Name
		ProgramLauncherSetupDialog.Program.Text = My.Settings.UserLaunch1_Location & "\" & My.Settings.UserLaunch1_Program
		Dim Returned As DialogResult = ProgramLauncherSetupDialog.ShowDialog()
		If (Returned = Windows.Forms.DialogResult.OK) Then
			My.Settings.UserLaunch1_Name = ProgramLauncherSetupDialog.ButtonName.Text
			My.Settings.UserLaunch1_Location = GetFilePath(ProgramLauncherSetupDialog.Program.Text)
			My.Settings.UserLaunch1_Program = (ProgramLauncherSetupDialog.Program.Text.Substring(GetFilePath(ProgramLauncherSetupDialog.Program.Text).Length + 1))
			UserLaunch1Btn.Text = ProgramLauncherSetupDialog.ButtonName.Text
			ToolTip.SetToolTip(UserLaunch1Btn, "Launch " & My.Settings.UserLaunch1_Program)
		End If
		ProgramLauncherSetupDialog.Dispose()
	End Sub
	Private Sub ClearButtonMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearButtonMenuItem1.Click
		My.Settings.UserLaunch1_Name = Nothing
		My.Settings.UserLaunch1_Location = Nothing
		My.Settings.UserLaunch1_Program = Nothing
		UserLaunch1Btn.Text = ""
		ToolTip.SetToolTip(UserLaunch1Btn, Nothing)
	End Sub
	Private Sub UserLaunch1Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserLaunch1Btn.Click
		If ((My.Settings.UserLaunch1_Name = "") Or (My.Settings.UserLaunch1_Program = "") Or (My.Settings.UserLaunch1_Location = "")) Then
			Dim ProgramLauncherSetupDialog As New ProgramLauncherSetupDialog
			ProgramLauncherSetupDialog.TopMost = Me.TopMost
			ProgramLauncherSetupDialog.ButtonName.Text = My.Settings.UserLaunch1_Name
			ProgramLauncherSetupDialog.Program.Text = My.Settings.UserLaunch1_Location & "\" & My.Settings.UserLaunch1_Program
			Dim Returned As DialogResult = ProgramLauncherSetupDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				My.Settings.UserLaunch1_Name = ProgramLauncherSetupDialog.ButtonName.Text
				My.Settings.UserLaunch1_Location = GetFilePath(ProgramLauncherSetupDialog.Program.Text)
				My.Settings.UserLaunch1_Program = (ProgramLauncherSetupDialog.Program.Text.Substring(GetFilePath(ProgramLauncherSetupDialog.Program.Text).Length + 1))
				UserLaunch1Btn.Text = ProgramLauncherSetupDialog.ButtonName.Text
				ToolTip.SetToolTip(UserLaunch1Btn, "Launch " & My.Settings.UserLaunch1_Program)
			End If
			ProgramLauncherSetupDialog.Dispose()
		Else
			Dim UserLaunchProcess As New Process
			UserLaunchProcess.StartInfo.FileName = My.Settings.UserLaunch1_Program
			UserLaunchProcess.StartInfo.UseShellExecute = True
			UserLaunchProcess.StartInfo.WorkingDirectory = My.Settings.UserLaunch1_Location
			Try
				UserLaunchProcess.Start()
				UserLaunchProcess.WaitForInputIdle()
			Catch ex As Exception
				MessageBox.Show("There was an error while attempting to load the application: " & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End If
	End Sub

	'User Launch Button 2
	Private Sub AssignProgramMenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssignProgramMenuItem2.Click
		Dim ProgramLauncherSetupDialog As New ProgramLauncherSetupDialog
		ProgramLauncherSetupDialog.TopMost = Me.TopMost
		ProgramLauncherSetupDialog.ButtonName.Text = My.Settings.USerLaunch2_Name
		ProgramLauncherSetupDialog.Program.Text = My.Settings.UserLaunch2_Location & "\" & My.Settings.UserLaunch2_Program
		Dim Returned As DialogResult = ProgramLauncherSetupDialog.ShowDialog()
		If (Returned = Windows.Forms.DialogResult.OK) Then
			My.Settings.USerLaunch2_Name = ProgramLauncherSetupDialog.ButtonName.Text
			My.Settings.UserLaunch2_Location = GetFilePath(ProgramLauncherSetupDialog.Program.Text)
			My.Settings.UserLaunch2_Program = (ProgramLauncherSetupDialog.Program.Text.Substring(GetFilePath(ProgramLauncherSetupDialog.Program.Text).Length + 1))
			UserLaunch2Btn.Text = ProgramLauncherSetupDialog.ButtonName.Text
		End If
		ProgramLauncherSetupDialog.Dispose()
	End Sub
	Private Sub ClearButtonMenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearButtonMenuItem2.Click
		My.Settings.USerLaunch2_Name = ""
		My.Settings.UserLaunch2_Location = ""
		My.Settings.UserLaunch2_Program = ""
		UserLaunch2Btn.Text = ""
	End Sub
	Private Sub UserLaunch2Btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserLaunch2Btn.Click
		If ((My.Settings.USerLaunch2_Name = "") Or (My.Settings.UserLaunch2_Program = "") Or (My.Settings.UserLaunch2_Location = "")) Then
			Dim ProgramLauncherSetupDialog As New ProgramLauncherSetupDialog
			ProgramLauncherSetupDialog.TopMost = Me.TopMost
			ProgramLauncherSetupDialog.ButtonName.Text = My.Settings.USerLaunch2_Name
			ProgramLauncherSetupDialog.Program.Text = My.Settings.UserLaunch2_Location & "\" & My.Settings.UserLaunch2_Program
			Dim Returned As DialogResult = ProgramLauncherSetupDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				My.Settings.USerLaunch2_Name = ProgramLauncherSetupDialog.ButtonName.Text
				My.Settings.UserLaunch2_Location = GetFilePath(ProgramLauncherSetupDialog.Program.Text)
				My.Settings.UserLaunch2_Program = (ProgramLauncherSetupDialog.Program.Text.Substring(GetFilePath(ProgramLauncherSetupDialog.Program.Text).Length + 1))
				UserLaunch2Btn.Text = ProgramLauncherSetupDialog.ButtonName.Text
			End If
			ProgramLauncherSetupDialog.Dispose()
		Else
			Dim UserLaunchProcess As New Process
			UserLaunchProcess.StartInfo.FileName = My.Settings.UserLaunch2_Program
			UserLaunchProcess.StartInfo.UseShellExecute = True
			UserLaunchProcess.StartInfo.WorkingDirectory = My.Settings.UserLaunch2_Location
			Try
				UserLaunchProcess.Start()
				UserLaunchProcess.WaitForInputIdle()
			Catch ex As Exception
				MessageBox.Show("There was an error while attempting to load the application: " & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End If
	End Sub

	'User Launch Button 3
	Private Sub AssignProgramMenuItem3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssignProgramMenuItem3.Click
		Dim ProgramLauncherSetupDialog As New ProgramLauncherSetupDialog
		ProgramLauncherSetupDialog.TopMost = Me.TopMost
		ProgramLauncherSetupDialog.ButtonName.Text = My.Settings.UserLaunch3_Name
		ProgramLauncherSetupDialog.Program.Text = My.Settings.UserLaunch3_Location & "\" & My.Settings.UserLaunch3_Program
		Dim Returned As DialogResult = ProgramLauncherSetupDialog.ShowDialog()
		If (Returned = Windows.Forms.DialogResult.OK) Then
			My.Settings.UserLaunch3_Name = ProgramLauncherSetupDialog.ButtonName.Text
			My.Settings.UserLaunch3_Location = GetFilePath(ProgramLauncherSetupDialog.Program.Text)
			My.Settings.UserLaunch3_Program = (ProgramLauncherSetupDialog.Program.Text.Substring(GetFilePath(ProgramLauncherSetupDialog.Program.Text).Length + 1))
			UserLaunch3Btn.Text = ProgramLauncherSetupDialog.ButtonName.Text
		End If
		ProgramLauncherSetupDialog.Dispose()
	End Sub
	Private Sub ClearButtonMenuItem3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearButtonMenuItem3.Click
		My.Settings.UserLaunch3_Name = ""
		My.Settings.UserLaunch3_Location = ""
		My.Settings.UserLaunch3_Program = ""
		UserLaunch3Btn.Text = ""
	End Sub
	Private Sub UserLaunch3Btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserLaunch3Btn.Click
		If ((My.Settings.UserLaunch3_Name = "") Or (My.Settings.UserLaunch3_Program = "") Or (My.Settings.UserLaunch3_Location = "")) Then
			Dim ProgramLauncherSetupDialog As New ProgramLauncherSetupDialog
			ProgramLauncherSetupDialog.TopMost = Me.TopMost
			ProgramLauncherSetupDialog.ButtonName.Text = My.Settings.UserLaunch3_Name
			ProgramLauncherSetupDialog.Program.Text = My.Settings.UserLaunch3_Location & "\" & My.Settings.UserLaunch3_Program
			Dim Returned As DialogResult = ProgramLauncherSetupDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				My.Settings.UserLaunch3_Name = ProgramLauncherSetupDialog.ButtonName.Text
				My.Settings.UserLaunch3_Location = GetFilePath(ProgramLauncherSetupDialog.Program.Text)
				My.Settings.UserLaunch3_Program = (ProgramLauncherSetupDialog.Program.Text.Substring(GetFilePath(ProgramLauncherSetupDialog.Program.Text).Length + 1))
				UserLaunch3Btn.Text = ProgramLauncherSetupDialog.ButtonName.Text
			End If
			ProgramLauncherSetupDialog.Dispose()
		Else
			Dim UserLaunchProcess As New Process
			UserLaunchProcess.StartInfo.FileName = My.Settings.UserLaunch3_Program
			UserLaunchProcess.StartInfo.UseShellExecute = True
			UserLaunchProcess.StartInfo.WorkingDirectory = My.Settings.UserLaunch3_Location
			Try
				UserLaunchProcess.Start()
				UserLaunchProcess.WaitForInputIdle()
			Catch ex As Exception
				MessageBox.Show("There was an error while attempting to load the application: " & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End If
	End Sub

	'User Launch Button 4
	Private Sub AssignProgramMenuItem4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssignProgramMenuItem4.Click
		Dim ProgramLauncherSetupDialog As New ProgramLauncherSetupDialog
		ProgramLauncherSetupDialog.TopMost = Me.TopMost
		ProgramLauncherSetupDialog.ButtonName.Text = My.Settings.UserLaunch4_Name
		ProgramLauncherSetupDialog.Program.Text = My.Settings.UserLaunch4_Location & "\" & My.Settings.UserLaunch4_Program
		Dim Returned As DialogResult = ProgramLauncherSetupDialog.ShowDialog()
		If (Returned = Windows.Forms.DialogResult.OK) Then
			My.Settings.UserLaunch4_Name = ProgramLauncherSetupDialog.ButtonName.Text
			My.Settings.UserLaunch4_Location = GetFilePath(ProgramLauncherSetupDialog.Program.Text)
			My.Settings.UserLaunch4_Program = (ProgramLauncherSetupDialog.Program.Text.Substring(GetFilePath(ProgramLauncherSetupDialog.Program.Text).Length + 1))
			UserLaunch4Btn.Text = ProgramLauncherSetupDialog.ButtonName.Text
		End If
		ProgramLauncherSetupDialog.Dispose()
	End Sub
	Private Sub ClearButtonMenuItem4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearButtonMenuItem4.Click
		My.Settings.UserLaunch4_Name = ""
		My.Settings.UserLaunch4_Location = ""
		My.Settings.UserLaunch4_Program = ""
		UserLaunch4Btn.Text = ""
	End Sub
	Private Sub UserLaunch4Btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserLaunch4Btn.Click
		If ((My.Settings.UserLaunch4_Name = "") Or (My.Settings.UserLaunch4_Program = "") Or (My.Settings.UserLaunch4_Location = "")) Then
			Dim ProgramLauncherSetupDialog As New ProgramLauncherSetupDialog
			ProgramLauncherSetupDialog.TopMost = Me.TopMost
			ProgramLauncherSetupDialog.ButtonName.Text = My.Settings.UserLaunch4_Name
			ProgramLauncherSetupDialog.Program.Text = My.Settings.UserLaunch4_Location & "\" & My.Settings.UserLaunch4_Program
			Dim Returned As DialogResult = ProgramLauncherSetupDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				My.Settings.UserLaunch4_Name = ProgramLauncherSetupDialog.ButtonName.Text
				My.Settings.UserLaunch4_Location = GetFilePath(ProgramLauncherSetupDialog.Program.Text)
				My.Settings.UserLaunch4_Program = (ProgramLauncherSetupDialog.Program.Text.Substring(GetFilePath(ProgramLauncherSetupDialog.Program.Text).Length + 1))
				UserLaunch4Btn.Text = ProgramLauncherSetupDialog.ButtonName.Text
			End If
			ProgramLauncherSetupDialog.Dispose()
		Else
			Dim UserLaunchProcess As New Process
			UserLaunchProcess.StartInfo.FileName = My.Settings.UserLaunch4_Program
			UserLaunchProcess.StartInfo.UseShellExecute = True
			UserLaunchProcess.StartInfo.WorkingDirectory = My.Settings.UserLaunch4_Location
			Try
				UserLaunchProcess.Start()
				UserLaunchProcess.WaitForInputIdle()
			Catch ex As Exception
				MessageBox.Show("There was an error while attempting to load the application: " & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End If
	End Sub

	Private Sub TextToSpeechBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextToSpeechBtn.Click
		Dim TextReader As New TextReaderDialog
		TextReader.TopMost = Me.TopMost
		TextReader.ShowDialog()
		TextReader.Dispose()
	End Sub

	'#################################################'
	'################# SETTINGS TAB ##################'
	'#################################################'

	Private Sub BrowseNSLocationBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseNSLocationBtn.Click
		Dim BrowseNSLocation As New FolderBrowserDialog
		BrowseNSLocation.Description = "Select the folder where Nightscape is installed."
		BrowseNSLocation.RootFolder = Environment.SpecialFolder.MyComputer
		BrowseNSLocation.ShowNewFolderButton = False
		BrowseNSLocation.ShowDialog()
		'NSLocationTextBox.Text = BrowseNSLocation.SelectedPath
		My.Settings.NightscapeLocation = BrowseNSLocation.SelectedPath
		My.Settings.Save()
	End Sub

	Private Sub BrowseInsideUOLocationBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseInsideUOLocationBtn.Click
		Dim BrowseInsideUOLocation As New FolderBrowserDialog
		BrowseInsideUOLocation.Description = "Select the folder where InsideUO is installed."
		BrowseInsideUOLocation.RootFolder = Environment.SpecialFolder.MyComputer
		BrowseInsideUOLocation.ShowNewFolderButton = False
		BrowseInsideUOLocation.ShowDialog()
		'InsideUOLocationTextBox.Text = BrowseInsideUOLocation.SelectedPath
		My.Settings.InsideUOLocation = BrowseInsideUOLocation.SelectedPath
		My.Settings.Save()
	End Sub

	Private Sub AdvancedSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancedSettings.Click, PreferencesMenuItem.Click
		Dim AdvancedSettingsDialog As New AdvancedSettingsDialog
		AdvancedSettingsDialog.TopMost = Me.TopMost
		AdvancedSettingsDialog.ShowDialog()
		AdvancedSettingsDialog.Dispose()
	End Sub

	Private Sub AboutBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutBtn.Click, AboutMenuItem.Click
		Dim AboutBox As New AboutBox
		AboutBox.TopMost = Me.TopMost
		AboutBox.ShowDialog()
		AboutBox.Dispose()
	End Sub

	Private Sub ListEditorBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListEditorBtn.Click
		Dim ListEditor As New Process
		ListEditor.StartInfo.FileName = "List Editor.exe"
		ListEditor.StartInfo.UseShellExecute = True
		ListEditor.StartInfo.WorkingDirectory = My.Computer.FileSystem.CurrentDirectory()
		Try
			ListEditor.Start()
			ListEditor.WaitForInputIdle()
		Catch ex As Exception
			MessageBox.Show("Failed to load the Nightscape Staff Assistant List Editor: " & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	'#################################################'
	'##########  NOTIFY ICON CONTEXT MENU  ###########'
	'#################################################'

	Private Sub RestoreMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RestoreMenuItem.Click
		If (Me.WindowState = FormWindowState.Minimized) Then
			Me.Show()
			Me.WindowState = FormWindowState.Normal
			Me.Show()
		Else
			Me.Show()
			Me.Activate()
			Me.BringToFront()
		End If
	End Sub

	'PreferencesMenuItem handled by AdvancedSettings (SETTINGS TAB)

	' OPTIONS MENU ->
	Private Sub AlwaysOnTopMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlwaysOnTopMenuItem.CheckedChanged
		My.Settings.AlwaysOnTop = AlwaysOnTopMenuItem.Checked
		My.Settings.Save()
		Me.TopMost = AlwaysOnTopMenuItem.Checked
	End Sub

	' OPTIONS -> OPACITY MENU ->
	Private Sub VisibleMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VisibleMenuItem.Click
		If (VisibleMenuItem.Checked = True) Then
			Me.Opacity = 0.99
			My.Settings.OpacityLevel = 99
			Opacity90MenuItem.Checked = False
			Opacity80MenuItem.Checked = False
			Opacity70MenuItem.Checked = False
			Opacity60MenuItem.Checked = False
			Opacity50MenuItem.Checked = False
			Opacity40MenuItem.Checked = False
			Opacity30MenuItem.Checked = False
			Opacity20MenuItem.Checked = False
			Opacity10MenuItem.Checked = False
			OpacityCustomMenuItem.Checked = False
		Else
			VisibleMenuItem.Checked = True
		End If
	End Sub
	Private Sub Opacity90MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Opacity90MenuItem.Click
		If (Opacity90MenuItem.Checked = True) Then
			Me.Opacity = 0.9
			My.Settings.OpacityLevel = 90
			Opacity80MenuItem.Checked = False
			Opacity70MenuItem.Checked = False
			Opacity60MenuItem.Checked = False
			Opacity50MenuItem.Checked = False
			Opacity40MenuItem.Checked = False
			Opacity30MenuItem.Checked = False
			Opacity20MenuItem.Checked = False
			Opacity10MenuItem.Checked = False
			OpacityCustomMenuItem.Checked = False
			VisibleMenuItem.Checked = False
		Else
			Opacity90MenuItem.Checked = True
		End If
	End Sub
	Private Sub Opacity80MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Opacity80MenuItem.Click
		If (Opacity80MenuItem.Checked = True) Then
			Me.Opacity = 0.8
			My.Settings.OpacityLevel = 80
			Opacity90MenuItem.Checked = False
			Opacity70MenuItem.Checked = False
			Opacity60MenuItem.Checked = False
			Opacity50MenuItem.Checked = False
			Opacity40MenuItem.Checked = False
			Opacity30MenuItem.Checked = False
			Opacity20MenuItem.Checked = False
			Opacity10MenuItem.Checked = False
			OpacityCustomMenuItem.Checked = False
			VisibleMenuItem.Checked = False
		Else
			Opacity80MenuItem.Checked = True
		End If
	End Sub
	Private Sub Opacity70MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Opacity70MenuItem.Click
		If (Opacity70MenuItem.Checked = True) Then
			Me.Opacity = 0.7
			My.Settings.OpacityLevel = 70
			Opacity90MenuItem.Checked = False
			Opacity80MenuItem.Checked = False
			Opacity60MenuItem.Checked = False
			Opacity50MenuItem.Checked = False
			Opacity40MenuItem.Checked = False
			Opacity30MenuItem.Checked = False
			Opacity20MenuItem.Checked = False
			Opacity10MenuItem.Checked = False
			OpacityCustomMenuItem.Checked = False
			VisibleMenuItem.Checked = False
		Else
			Opacity70MenuItem.Checked = True
		End If
	End Sub
	Private Sub Opacity60MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Opacity60MenuItem.Click
		If (Opacity60MenuItem.Checked = True) Then
			Me.Opacity = 0.6
			My.Settings.OpacityLevel = 60
			Opacity90MenuItem.Checked = False
			Opacity80MenuItem.Checked = False
			Opacity70MenuItem.Checked = False
			Opacity50MenuItem.Checked = False
			Opacity40MenuItem.Checked = False
			Opacity30MenuItem.Checked = False
			Opacity20MenuItem.Checked = False
			Opacity10MenuItem.Checked = False
			OpacityCustomMenuItem.Checked = False
			VisibleMenuItem.Checked = False
		Else
			Opacity60MenuItem.Checked = True
		End If
	End Sub
	Private Sub Opacity50MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Opacity50MenuItem.Click
		If (Opacity50MenuItem.Checked = True) Then
			Me.Opacity = 0.5
			My.Settings.OpacityLevel = 50
			Opacity90MenuItem.Checked = False
			Opacity80MenuItem.Checked = False
			Opacity70MenuItem.Checked = False
			Opacity60MenuItem.Checked = False
			Opacity40MenuItem.Checked = False
			Opacity30MenuItem.Checked = False
			Opacity20MenuItem.Checked = False
			Opacity10MenuItem.Checked = False
			OpacityCustomMenuItem.Checked = False
			VisibleMenuItem.Checked = False
		Else
			Opacity50MenuItem.Checked = True
		End If
	End Sub
	Private Sub Opacity40MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Opacity40MenuItem.Click
		If (Opacity40MenuItem.Checked = True) Then
			Me.Opacity = 0.4
			My.Settings.OpacityLevel = 40
			Opacity90MenuItem.Checked = False
			Opacity80MenuItem.Checked = False
			Opacity70MenuItem.Checked = False
			Opacity60MenuItem.Checked = False
			Opacity50MenuItem.Checked = False
			Opacity30MenuItem.Checked = False
			Opacity20MenuItem.Checked = False
			Opacity10MenuItem.Checked = False
			OpacityCustomMenuItem.Checked = False
			VisibleMenuItem.Checked = False
		Else
			Opacity40MenuItem.Checked = True
		End If
	End Sub
	Private Sub Opacity30MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Opacity30MenuItem.Click
		If (Opacity30MenuItem.Checked = True) Then
			Me.Opacity = 0.3
			My.Settings.OpacityLevel = 30
			Opacity90MenuItem.Checked = False
			Opacity80MenuItem.Checked = False
			Opacity70MenuItem.Checked = False
			Opacity60MenuItem.Checked = False
			Opacity50MenuItem.Checked = False
			Opacity40MenuItem.Checked = False
			Opacity20MenuItem.Checked = False
			Opacity10MenuItem.Checked = False
			OpacityCustomMenuItem.Checked = False
			VisibleMenuItem.Checked = False
		Else
			Opacity30MenuItem.Checked = True
		End If
	End Sub
	Private Sub Opacity20MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Opacity20MenuItem.Click
		If (Opacity20MenuItem.Checked = True) Then
			Me.Opacity = 0.2
			My.Settings.OpacityLevel = 20
			Opacity90MenuItem.Checked = False
			Opacity80MenuItem.Checked = False
			Opacity70MenuItem.Checked = False
			Opacity60MenuItem.Checked = False
			Opacity50MenuItem.Checked = False
			Opacity40MenuItem.Checked = False
			Opacity30MenuItem.Checked = False
			Opacity10MenuItem.Checked = False
			OpacityCustomMenuItem.Checked = False
			VisibleMenuItem.Checked = False
		Else
			Opacity20MenuItem.Checked = True
		End If
	End Sub
	Private Sub Opacity10MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Opacity10MenuItem.Click
		If (Opacity10MenuItem.Checked = True) Then
			Me.Opacity = 0.1
			My.Settings.OpacityLevel = 10
			Opacity90MenuItem.Checked = False
			Opacity80MenuItem.Checked = False
			Opacity70MenuItem.Checked = False
			Opacity60MenuItem.Checked = False
			Opacity50MenuItem.Checked = False
			Opacity40MenuItem.Checked = False
			Opacity30MenuItem.Checked = False
			Opacity20MenuItem.Checked = False
			OpacityCustomMenuItem.Checked = False
			VisibleMenuItem.Checked = False
		Else
			Opacity10MenuItem.Checked = True
		End If
	End Sub
	Private Sub OpacityCustomMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpacityCustomMenuItem.Click
		If (OpacityCustomMenuItem.Checked = True) Then
			Dim GenericNumericDialog As New GenericNumericDialog
			GenericNumericDialog.Description.Text = "Enter the opacity level you would like to use..."
			GenericNumericDialog.NumericUpDown.Minimum = 10
			GenericNumericDialog.NumericUpDown.Maximum = 100
			GenericNumericDialog.NumericUpDown.Value = My.Settings.OpacityLevel
			GenericNumericDialog.TopMost = Me.TopMost
			Dim Returned As DialogResult = GenericNumericDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				Me.Opacity = ("0." & GenericNumericDialog.NumericUpDown.Value.ToString)
				My.Settings.OpacityLevel = GenericNumericDialog.NumericUpDown.Value
				Opacity90MenuItem.Checked = False
				Opacity80MenuItem.Checked = False
				Opacity70MenuItem.Checked = False
				Opacity60MenuItem.Checked = False
				Opacity50MenuItem.Checked = False
				Opacity40MenuItem.Checked = False
				Opacity30MenuItem.Checked = False
				Opacity20MenuItem.Checked = False
				Opacity10MenuItem.Checked = False
				VisibleMenuItem.Checked = False
			End If
		Else
			OpacityCustomMenuItem.Checked = True
		End If
	End Sub

	'QUICK COMMANDS MENU ->
	Private Sub QC_GetInfoMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_GetInfoMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".getinfo")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_KillMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_KillMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".kill")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_RessurectMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_RessurectMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".res")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_JailMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_JailMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".jail")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_KickMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_KickMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".kick")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_HideMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_HideMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".hide")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub QC_DestroySItemMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_DestroySItemMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".destroy")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_DestroyMItemsMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_DestroyMItemsMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".mdestroy")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_RoofCreatorMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_RoofCreatorMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".roofcreator")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_ItemInfoMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_ItemInfoMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".iteminfo")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_LockItemMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_LockItemMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".lockdown")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_LockRadius5MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_LockRadius5MenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".lockradius 5")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_LockRadius10MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_LockRadius10MenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".lockradius 10")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub QC_ConcealMeMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_ConcealMeMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_concealme")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_RevealMeMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_RevealMeMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_unconcealme")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_GMFormMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_GMFormMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_gmform")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_MyFormMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_MyFormMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_myform")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_SaveShardMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_SaveShardMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
            Ultima.Client.SendText(".sa_savenow")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_NightsightMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_NightsightMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".light")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_HelpQueueMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_HelpQueueMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".q")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_PropEditMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_PropEditMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".propedit")
		Else
			ShowError("noclient")
		End If
	End Sub

	Private Sub QC_MarkMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_MarkMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".mark")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_RecallMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_RecallMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".recall")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_WhereMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_WhereMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".where")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_GotoPlayerMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_GotoPlayerMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".goto")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_SummonPlayerMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_SummonPlayerMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".summon")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_TeleMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_TeleMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".tele")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_MTeleMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_MTeleMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".mtele")
		Else
			ShowError("noclient")
		End If
	End Sub
	Private Sub QC_TeleToMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles QC_TeleToMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".teleto")
		Else
			ShowError("noclient")
		End If
	End Sub

	'AboutMenuItem handled by AboutBtn (SETTINGS TAB)

	Private Sub ExitMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExitMenuItem.Click
		Me.Close()
	End Sub

	'#################################################'
	'##################  FUNCTIONS  ##################'
	'#################################################'
	Public Function ShowError(ByVal type)
		Select Case (type)
			Case "noclient"
				Dim Result As DialogResult
				Result = MessageBox.Show("The Nightscape Client is not running!" & vbCrLf & vbCrLf & "Would you like to start it now?", "Client Not Found...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
				If (Result = Windows.Forms.DialogResult.Yes) Then
					If (Ultima.Client.Running = False) Then
						Dim Client As New Process
                        'Client.StartInfo.FileName = "nsclient.exe"
                        Client.StartInfo.FileName = "Decrypted_client.exe"
                        Client.StartInfo.UseShellExecute = True
						Client.StartInfo.WorkingDirectory = My.Settings.NightscapeLocation
						Client.EnableRaisingEvents = False
						Try
							Client.Start()
							Client.WaitForInputIdle()
						Catch ex As Exception
							MessageBox.Show("Failed to load the Nightscape Client: " & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
						End Try
					Else
						MessageBox.Show("Failed to load the client!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
					End If
				End If
		End Select
		Return 1
	End Function

	Public Function Calculate(ByVal num1 As Double, ByVal exp As String, ByVal num2 As Double) As Double
		Select Case (exp)
			Case "+"
				Calculate = num1 + num2
			Case "-"
				Calculate = num1 - num2
			Case "*"
				Calculate = num1 * num2
			Case "/"
				Calculate = num1 / num2
		End Select
	End Function

	Public Function GetFilePath(ByVal FileName As String) As String
		Dim i As Long
		For i = Len(FileName) To 1 Step -1
			Select Case Mid(FileName, i, 1)
				Case ":"
					' colons aren't included in the result
					Exit For
				Case "\"
					' backslash aren't included in the result either
					Exit For
			End Select
		Next
		GetFilePath = Microsoft.VisualBasic.Left(FileName, i - 1)
	End Function

	'ATTEMPTED TO CHANGE THE TITLEBAR TEXT ON THE UO CLIENT; DELEGATED TO LATER VERSION.
	'Private Declare Function SetWindowText Lib "user32" Alias "SetWindowTextA" (ByVal hWnd As Long, ByVal lpString As String) As Boolean
	'Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hWnd As Long, ByVal lpString As System.Text.StringBuilder, ByVal nMaxCount As Integer) As Integer
	'Private Declare Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As Integer) As Integer

	'BACKGROUND THREAD FOR TRACKING IN-GAME LOCATION
	Private Sub TrackLocation(ByVal sender As System.Object)
		While (Thread.CurrentThread.IsAlive = True)
			While (My.Settings.TrackLocation = False)
				Me.Text = "Nightscape Staff Assistant -- Beta 3.0"
				Thread.Sleep(5000)
			End While
			If (Ultima.Client.Running = False) Then
				ClientCalibrated = False
				While (Ultima.Client.Running = False)
					Thread.Sleep(5000)
				End While
			Else
				If (ClientCalibrated = False) Then
					Ultima.Client.Calibrate()
					ClientCalibrated = True
				End If
				Dim x As Integer = 0
				Dim y As Integer = 0
				Dim z As Integer = 0
				Dim facet As Integer = 1
				Ultima.Client.FindLocation(x, y, z, facet)
				'ATTEMPTED TO CHANGE THE TITLEBAR TEXT ON THE UO CLIENT; DELEGATED TO LATER VERSION.
				'SetWindowText(Ultima.Client.Handle, GetText(Ultima.Client.Handle) & " [" & x.ToString & ", " & y.ToString & ", " & z.ToString & "]")
				Try
					Me.Text = "Nightscape Staff Assistant -- Beta 3.0 -- [" & x.ToString & ", " & y.ToString & ", " & z.ToString & "]"
				Catch
				End Try
				Thread.Sleep(500)
			End If
		End While
	End Sub

	'GET TITLEBAR TEXT OF UO CLIENT
	'Public Function GetText(ByVal hWnd As IntPtr) As String
	'  Dim length As Integer
	'  If hWnd.ToInt32 <= 0 Then
	'    Return Nothing
	'  End If
	'  length = GetWindowTextLength(hWnd)
	'  If length = 0 Then
	'    Return Nothing
	'  End If
	'  Dim sb As New System.Text.StringBuilder("", length + 1)
	'  GetWindowText(hWnd, sb, sb.Capacity)
	'  Return sb.ToString()
	'End Function


	'#################################################'
	'##############  AUTO OPAQUE CODE  ###############'
	'#################################################'

	'TODO: OPACITY CODE
	'Private Sub Form1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
	'  OpacityTimer.Interval = (My.Settings.FadeOutTime / 10)
	'  OpacityTimer.Tag = Math.Round(My.Settings.OpacityLevel / 10)
	'  OpacityTimer.Enabled = True
	'  OpacityTimer.Start()
	'End Sub

	'Private Sub OpacityTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpacityTimer.Tick
	'  If ((Me.Opacity - CDbl("0." & OpacityTimer.Tag.ToString.PadLeft(2, "0"))) < CDbl("0." & My.Settings.OpacityLevel.ToString.PadLeft(2, "0"))) Then
	'    Me.Opacity = CDbl("0." & My.Settings.OpacityLevel.ToString.PadLeft(2, "0"))
	'    OpacityTimer.Stop()
	'  Else
	'    Me.Opacity = (Me.Opacity - CDbl("0." & OpacityTimer.Tag.ToString.PadLeft(2, "0")))
	'  End If
	'End Sub

	'Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
	'  OpacityTimer.Stop()
	'  Me.Opacity = 0.99
	'End Sub

	'Private Sub Form1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
	'  OpacityTimer.Stop()
	'  Me.Opacity = 0.99
	'End Sub

	'Private Sub Form1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
	'  MyBase.OnDeactivate(e)
	'End Sub

	'#################################################'
	'##########  PATCH THREAD AND PROCESS  ###########'
	'#################################################'

	Private Sub PatcherBackgroundWorker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles PatcherBackgroundWorker.DoWork
		' Get the BackgroundWorker object that raised this event.
		Dim worker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)

		' Assign the result of the computation
		' to the Result property of the DoWorkEventArgs
		' object. This is will be available to the 
		' RunWorkerCompleted eventhandler.
		e.Result = DoPatchProcess(worker, e)
	End Sub

	Function DoPatchProcess(ByVal worker As System.ComponentModel.BackgroundWorker, ByVal e As System.ComponentModel.DoWorkEventArgs)
		Dim UpdatesAvailable As String() = {"Name|0", "Name|0", "Name|0", "Name|0", "Name|0"}

		'Make sure there is an internet connection...
		If (Not My.Computer.Network.IsAvailable) Then
			Return 0
		End If

		'Clean up the temp file if it exists by some chance...
		If (My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory() & "filelist.tmp")) Then
			My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.CurrentDirectory() & "filelist.tmp")
		End If

		'Download the filelist with all the current versions for each file...
		Try
			My.Computer.Network.DownloadFile("http://www.nightscapeonline.com/gmpatch/filelist.txt", My.Computer.FileSystem.CurrentDirectory() & "filelist.tmp", "", "", False, 6000, True)
		Catch TimeoutException As Exception When True
			Return "Unable to check for updates: connection timed out."
		Catch WebException As Exception When True
			Return "Unable to check for updates: unknown reason."
		End Try

		'Read the downloaded filelist into an array...
		Dim FileList As String()
		If (My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory() & "filelist.tmp")) Then
			FileList = System.IO.File.ReadAllLines(My.Computer.FileSystem.CurrentDirectory() & "filelist.tmp")
		Else
			Return "Unable to check for updates: unknown reason."
		End If

		'Compare filelist to locally stored version numbers and determine if any updates are needed.
		Dim LocalVersion As String()
		Dim AvailableVersion As String()

		LocalVersion = My.Settings.CoreVersion.Split(".")
		AvailableVersion = FileList(0).Split(".")
		If ((AvailableVersion(0) > LocalVersion(0)) Or (AvailableVersion(1) > LocalVersion(1)) Or (AvailableVersion(2) > LocalVersion(2)) Or (AvailableVersion(3) > LocalVersion(3))) Then
			If (My.Settings.UpdateCore = True) Then
				UpdatesAvailable(0) = "Core Executable|1"
			Else
				UpdatesAvailable(0) = "Core Executable|2"
			End If
		End If
		LocalVersion = My.Settings.BuildListVersion.Split(".")
		AvailableVersion = FileList(1).Split(".")
		If ((CInt(AvailableVersion(0)) > CInt(LocalVersion(0))) Or (CInt(AvailableVersion(1)) > CInt(LocalVersion(1))) Or (CInt(AvailableVersion(2)) > CInt(LocalVersion(2))) Or (CInt(AvailableVersion(3)) > CInt(LocalVersion(3)))) Then
			If (My.Settings.UpdateBuildList = True) Then
				UpdatesAvailable(1) = "Building List|1"
			Else
				UpdatesAvailable(1) = "Building List|2"
			End If
		End If
		LocalVersion = My.Settings.ItemListVersion.Split(".")
		AvailableVersion = FileList(2).Split(".")
		If ((AvailableVersion(0) > LocalVersion(0)) Or (AvailableVersion(1) > LocalVersion(1)) Or (AvailableVersion(2) > LocalVersion(2)) Or (AvailableVersion(3) > LocalVersion(3))) Then
			If (My.Settings.UpdateItemList = True) Then
				UpdatesAvailable(2) = "Items List|1"
			Else
				UpdatesAvailable(2) = "Items List|2"
			End If
		End If
		LocalVersion = My.Settings.NPCListVersion.Split(".")
		AvailableVersion = FileList(3).Split(".")
		If ((AvailableVersion(0) > LocalVersion(0)) Or (AvailableVersion(1) > LocalVersion(1)) Or (AvailableVersion(2) > LocalVersion(2)) Or (AvailableVersion(3) > LocalVersion(3))) Then
			If (My.Settings.UpdateNPCList = True) Then
				UpdatesAvailable(3) = "NPC Lists|1"
			Else
				UpdatesAvailable(3) = "NPC Lists|2"
			End If
		End If
		LocalVersion = My.Settings.LocationListVersion.Split(".")
		AvailableVersion = FileList(4).Split(".")
		If ((AvailableVersion(0) > LocalVersion(0)) Or (AvailableVersion(1) > LocalVersion(1)) Or (AvailableVersion(2) > LocalVersion(2)) Or (AvailableVersion(3) > LocalVersion(3))) Then
			If (My.Settings.UpdateLocationList = True) Then
				UpdatesAvailable(4) = "Locations List|1"
			Else
				UpdatesAvailable(4) = "Locations List|2"
			End If
		End If

		'Create the Update Prompt Dialog (for non-automatic updates) if needed...
		Dim PromptToUpdate As New PromptToUpdate
		Dim PromptNeeded As Boolean = False
		If (UpdatesAvailable(0).Substring(UpdatesAvailable(0).Length - 1) = 2) Then
			PromptToUpdate.Update1.Name = UpdatesAvailable(0).Substring(0, UpdatesAvailable(0).Length - 2).Replace(" ", "_")
			PromptToUpdate.Update1.Text = UpdatesAvailable(0).Substring(0, UpdatesAvailable(0).Length - 2) & "  (" & FileList(0) & ")"
			PromptToUpdate.Update1.Visible = True
			PromptNeeded = True
		End If
		If (UpdatesAvailable(1).Substring(UpdatesAvailable(1).Length - 1) = 2) Then
			PromptToUpdate.Update2.Name = UpdatesAvailable(1).Substring(0, UpdatesAvailable(1).Length - 2).Replace(" ", "_")
			PromptToUpdate.Update2.Text = UpdatesAvailable(1).Substring(0, UpdatesAvailable(1).Length - 2) & "  (" & FileList(1) & ")"
			PromptToUpdate.Update2.Visible = True
			If (PromptNeeded = True) Then
				PromptToUpdate.GroupBox1.Height += 23
				PromptToUpdate.Height += 23
			Else
				PromptNeeded = True
			End If
		End If
		If (UpdatesAvailable(2).Substring(UpdatesAvailable(2).Length - 1) = 2) Then
			PromptToUpdate.Update3.Name = UpdatesAvailable(2).Substring(0, UpdatesAvailable(2).Length - 2).Replace(" ", "_")
			PromptToUpdate.Update3.Text = UpdatesAvailable(2).Substring(0, UpdatesAvailable(2).Length - 2) & "  (" & FileList(2) & ")"
			PromptToUpdate.Update3.Visible = True
			If (PromptNeeded = True) Then
				PromptToUpdate.GroupBox1.Height += 23
				PromptToUpdate.Height += 23
			Else
				PromptNeeded = True
			End If
		End If
		If (UpdatesAvailable(3).Substring(UpdatesAvailable(3).Length - 1) = 2) Then
			PromptToUpdate.Update4.Name = UpdatesAvailable(3).Substring(0, UpdatesAvailable(3).Length - 2).Replace(" ", "_")
			PromptToUpdate.Update4.Text = UpdatesAvailable(3).Substring(0, UpdatesAvailable(3).Length - 2) & "  (" & FileList(3) & ")"
			PromptToUpdate.Update4.Visible = True
			If (PromptNeeded = True) Then
				PromptToUpdate.GroupBox1.Height += 23
				PromptToUpdate.Height += 23
			Else
				PromptNeeded = True
			End If
		End If
		If (UpdatesAvailable(4).Substring(UpdatesAvailable(4).Length - 1) = 2) Then
			PromptToUpdate.Update5.Name = UpdatesAvailable(4).Substring(0, UpdatesAvailable(4).Length - 2).Replace(" ", "_")
			PromptToUpdate.Update5.Text = UpdatesAvailable(4).Substring(0, UpdatesAvailable(4).Length - 2) & "  (" & FileList(4) & ")"
			PromptToUpdate.Update5.Visible = True
			If (PromptNeeded = True) Then
				PromptToUpdate.GroupBox1.Height += 23
				PromptToUpdate.Height += 23
			Else
				PromptNeeded = True
			End If
		End If

		If (PromptNeeded = True) Then
			PromptToUpdate.TopMost = Me.TopMost
			PromptToUpdate.ShowDialog()
			PromptToUpdate.Dispose()
		Else
			PromptToUpdate.Dispose()
		End If

		Return "Nothing was actually downloaded; but the process was successful!"
	End Function

  Private Sub PatcherBackgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles PatcherBackgroundWorker.RunWorkerCompleted
    NotifyIcon.BalloonTipIcon = ToolTipIcon.Info
    NotifyIcon.BalloonTipText = e.Result.ToString
    NotifyIcon.BalloonTipTitle = "AutoPatch"
    NotifyIcon.ShowBalloonTip(5000)
  End Sub

	Private Sub unusedBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unusedBtn.Click
		Dim ItemViewerDialog As New ItemViewer
		ItemViewerDialog.TopMost = Me.TopMost
		Dim ReturnedValue As DialogResult = ItemViewerDialog.ShowDialog()
		ItemViewerDialog.Dispose()
	End Sub

End Class