Imports System.Windows.Forms

Public Class AdvancedSettingsDialog

  Private Sub AdvancedSettingsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    My.Settings.Reload()

		'Enable Tooltips
		If (My.Settings.EnableTooltips = False) Then
			StandardStyleToolTip.Enabled = False
			BalloonStyleTooltip.Enabled = False
		End If

    'Tooltip Style
    If (My.Settings.TooltipStyle = "standard") Then
      StandardStyleToolTip.Checked = True
    Else
      BalloonStyleTooltip.Checked = True
    End If

		'Splash Screen
    If (My.Settings.ShowSplashScreen = True) Then
			My.Application.SplashScreen = Nightscape_Staff_Assistant.SplashScreen2
    Else
			My.Application.SplashScreen = Nothing
    End If

    'Auto Launch Nightscape Client
    If (My.Settings.AutoLaunchClient = True) Then
			If (My.Settings.AutoLaunchType = "patch") Then
				AutoLaunchPatchClient.Checked = True
			Else
				AutoLaunchNSClient.Checked = True
			End If
      AutoLaunchPatchClient.Enabled = True
      AutoLaunchNSClient.Enabled = True
		Else
			If (My.Settings.AutoLaunchType = "patch") Then
				AutoLaunchPatchClient.Checked = True
			Else
				AutoLaunchNSClient.Checked = True
			End If
			AutoLaunchPatchClient.Enabled = False
			AutoLaunchNSClient.Enabled = False
		End If

		'feature disabled!!
    SystrayIconGroup.Enabled = False

    'Show on Taskbar
    If (My.Settings.ShowOnTaskbar = True) Then
			If (My.Settings.TaskbarType = "always") Then
				ShowOnTaskbarAlways.Checked = True
				ShowOnTaskbarMaximized.Checked = False
			Else
				ShowOnTaskbarAlways.Checked = False
				ShowOnTaskbarMaximized.Checked = True
			End If
      ShowOnTaskbarAlways.Enabled = True
      ShowOnTaskbarMaximized.Enabled = True
    Else
			If (My.Settings.TaskbarType = "always") Then
				ShowOnTaskbarAlways.Checked = True
				ShowOnTaskbarMaximized.Checked = False
			Else
				ShowOnTaskbarAlways.Checked = False
				ShowOnTaskbarMaximized.Checked = True
			End If
      ShowOnTaskbarAlways.Enabled = False
      ShowOnTaskbarMaximized.Enabled = False
    End If

    'OPACITY TAB SETTINGS
    'Check to make sure they're using XP or 2K, otherwise, disable Opacity
    Dim OperatingSystemName As String
    Try
      OperatingSystemName = My.Computer.Info.OSFullName
    Catch ex As Exception
      OperatingSystemName = "Unknown"
      MessageBox.Show("Could not determine your operating system version! Opacity options will remain disabled until this is corrected." & vbCrLf & vbCrLf & "A possible cause for this failure is if Windows Management Instrumentation (WMI) is not installed on the current computer." & vbCrLf & vbCrLf & "For more information about WMI and how to install it, go to http://support.microsoft.com and search for 'Windows Management Instrumentation Core'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    End Try
    If (OperatingSystemName.Contains("XP") Or OperatingSystemName.Contains("2000")) Then
      OpacityGroup.Enabled = True
      OpacityLevel.Value = My.Settings.OpacityLevel
      OpacitySelectedLevel.Text = (My.Settings.OpacityLevel + 1).ToString & "%"
      OpacityFadeInTimer.Value = My.Settings.FadeInTime
      FadeInTime.Text = My.Settings.FadeInTime.ToString & "ms"
      OpacityFadeOutTimer.Value = My.Settings.FadeOutTime
      FadeOutTime.Text = My.Settings.FadeOutTime.ToString & "ms"
      If (My.Settings.Opacity = "disabled") Then
        OpacityDisabled.Checked = True
        OpacityLevelGroup.Enabled = False
        AutoOpaqueGroup.Enabled = False
      ElseIf (My.Settings.Opacity = "enabled") Then
        OpacityEnabled.Checked = True
        AutoOpaqueGroup.Enabled = False
      ElseIf (My.Settings.Opacity = "onfocus") Then
        OpacityEnabled.Checked = True
        'OpacityOnFocus.Checked = True
        'AutoOpaqueGroup.Enabled = True
      ElseIf (My.Settings.Opacity = "onhover") Then
        OpacityEnabled.Checked = True
        'OpacityOnHover.Checked = True
        'AutoOpaqueGroup.Enabled = True
      Else
        OpacityDisabled.Checked = True
        My.Settings.Opacity = "disabled"
        OpacityLevelGroup.Enabled = False
        AutoOpaqueGroup.Enabled = False
      End If
    Else
      OpacityDisabled.Checked = True
      OpacityGroup.Enabled = False
      My.Settings.Opacity = "disabled"
    End If

    'AUTO UPDATE SETTINGS
    If (My.Settings.UpdateInterval = "always") Then
      AutoUpdateEveryTime.Checked = True
    ElseIf (My.Settings.UpdateInterval = "daily") Then
      AutoUpdateOnceDay.Checked = True
    ElseIf (My.Settings.UpdateInterval = "weekly") Then
      AutoUpdateOnceWeek.Checked = True
    Else
      AutoUpdateEveryTime.Checked = True
      My.Settings.UpdateInterval = "always"
    End If

    If (My.Settings.CheckUpdates = True) Then
			AutoUpdateEveryTime.Enabled = True
      AutoUpdateOnceDay.Enabled = True
      AutoUpdateOnceWeek.Enabled = True
      FilesToUpdateGroup.Enabled = True
    Else
            AutoUpdateEveryTime.Enabled = False
      AutoUpdateOnceDay.Enabled = False
      AutoUpdateOnceWeek.Enabled = False
      FilesToUpdateGroup.Enabled = False
    End If

        Dim fontFamilies() As FontFamily
    Dim installedFontCollection As New Drawing.Text.InstalledFontCollection()

    ' POPULATE THE FONT-FAMILY LISTBOX WITH INSTALLED FONTS
    fontFamilies = installedFontCollection.Families
    Dim count As Integer = fontFamilies.Length
    Dim j As Integer
    While j < count
      FontList.Items.Add(fontFamilies(j).Name)
      j += 1
    End While

    ' DISABLE THE INDEX-CHANGED EVENT FOR THE FONT CONTROLS
        RemoveHandler FontList.SelectedIndexChanged, AddressOf FontList_SelectedIndexChanged
        RemoveHandler FontStyleList.SelectedIndexChanged, AddressOf FontStyleList_SelectedIndexChanged
        RemoveHandler FontSizeList.SelectedIndexChanged, AddressOf FontSizeList_SelectedIndexChanged

    ' SET THE FONT PREVIEW TO THE INITIAL SELECTIONS
    FontList.SelectedItem = "Microsoft Sans Serif"
    FontStyleList.SelectedItem = "Regular"
    FontSizeList.SelectedItem = "8"
    Dim fontFamily As New FontFamily(FontList.SelectedItem.ToString)
    Dim fontStyleNum As Integer
    Select Case (FontStyleList.SelectedItem.ToString)
      Case "Regular"
        fontStyleNum = 0
      Case "Italic"
        fontStyleNum = 2
      Case "Bold"
        fontStyleNum = 1
      Case "Bold Italic"
        fontStyleNum = 3
      Case Else
        fontStyleNum = 0
    End Select
    If (fontFamily.IsStyleAvailable(fontStyleNum)) Then
      Dim previewfont As New Font(fontFamily, FontSizeList.SelectedItem, fontStyleNum, GraphicsUnit.Point)
      FontPreview.Font = previewfont
    End If

    ' ENABLE THE INDEX-CHANGED EVENT FOR THE FONT CONTROLS
    AddHandler FontList.SelectedIndexChanged, AddressOf FontList_SelectedIndexChanged
    AddHandler FontStyleList.SelectedIndexChanged, AddressOf FontStyleList_SelectedIndexChanged
    AddHandler FontSizeList.SelectedIndexChanged, AddressOf FontSizeList_SelectedIndexChanged
  End Sub

  '#################################################'
  '########### GENERAL PREFERENCES TAB #############'
  '#################################################'

  'Always on Top
  Private Sub AlwaysOnTopChk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlwaysOnTopChk.CheckedChanged
    My.Settings.AlwaysOnTop = AlwaysOnTopChk.Checked
    Form1.TopMost = AlwaysOnTopChk.Checked
  End Sub

  'Enable AutoComplete
  Private Sub AutoComplete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoComplete.CheckedChanged
    My.Settings.AutoComplete = AutoComplete.Checked
  End Sub

  'Animate NPCs
  Private Sub AnimateNPCs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnimateNPCs.CheckedChanged
    My.Settings.AnimateNPCs = AnimateNPCs.Checked
  End Sub

  'Track my Location
  Private Sub TrackLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackLocation.CheckedChanged
    My.Settings.TrackLocation = TrackLocation.Checked
  End Sub

	'Retain input across sessions.
	Private Sub RetainInputChk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetainInputChk.CheckedChanged
		My.Settings.RetainInput = RetainInputChk.Checked
	End Sub

  'Tooltip Settings
  Private Sub EnableTooltips_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableTooltips.CheckedChanged
    If (EnableTooltips.Checked = False) Then
      StandardStyleToolTip.Enabled = False
      BalloonStyleTooltip.Enabled = False
      Form1.ToolTip.Active = False
    Else
      StandardStyleToolTip.Enabled = True
      BalloonStyleTooltip.Enabled = True
      Form1.ToolTip.Active = True
    End If
    My.Settings.EnableTooltips = EnableTooltips.Checked
  End Sub
  Private Sub StandardStyleToolTip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardStyleToolTip.CheckedChanged
    If (StandardStyleToolTip.Checked = True) Then
      Form1.ToolTip.IsBalloon = False
      My.Settings.TooltipStyle = "standard"
    End If
  End Sub
  Private Sub BalloonStyleTooltip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalloonStyleTooltip.CheckedChanged
    Form1.ToolTip.IsBalloon = True
    My.Settings.TooltipStyle = "balloon"
  End Sub

  'Startup Tab
	Private Sub StartupTabList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		My.Settings.StartupTab = StartupTabList.SelectedItem.ToString.ToLower.Replace(" ", "_")
	End Sub

  'Show splash Screen
	Private Sub ShowSplashScreenChk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		My.Application.SplashScreen = Nothing
	End Sub

  'Auto Launch Nightscape Client
	Private Sub AutoLaunchNSChk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		If (AutoLaunchNSChk.Checked = False) Then
			AutoLaunchPatchClient.Enabled = False
			AutoLaunchNSClient.Enabled = False
			My.Settings.AutoLaunchClient = False
		Else
			AutoLaunchPatchClient.Enabled = True
			AutoLaunchNSClient.Enabled = True
			My.Settings.AutoLaunchClient = True
		End If
	End Sub
	Private Sub AutoLaunchPatchClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		My.Settings.AutoLaunchType = "patch"
	End Sub
	Private Sub AutoLaunchNSClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
		My.Settings.AutoLaunchType = "client"
	End Sub

  'Show In System Tray
  Private Sub ShowInSystray_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowInSystray.CheckedChanged
    If ((ShowInSystray.Checked = False) And ((ShowOnTaskbar.Checked = False) Or ((ShowOnTaskbar.Checked = True) And (ShowOnTaskbarMaximized.Checked = True)))) Then
      Dim ReturnedValue As DialogResult = MessageBox.Show("The combination of settings you have chosen would mean that when minimized the Nightscape Staff Assistant could not be restored." & vbCrLf & vbCrLf & "Are you sure you want to disable ""Show in System Tray""?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
      If (ReturnedValue = Windows.Forms.DialogResult.No) Then
        ShowInSystray.Checked = True
        Exit Sub
      End If
    End If
    If (ShowInSystray.Checked = False) Then
      SystrayIconGroup.Enabled = False
      Form1.NotifyIcon.Visible = False
    Else
      SystrayIconGroup.Enabled = True
      Form1.NotifyIcon.Visible = True
    End If
    My.Settings.ShowInTray = ShowInSystray.Checked

    'feature disabled!!
    SystrayIconGroup.Enabled = False
    Me.BringToFront()
  End Sub

  'Show On Taskbar
  Private Sub ShowOnTaskbar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowOnTaskbar.CheckedChanged
    If (ShowOnTaskbar.Checked = False) Then
      ShowOnTaskbarAlways.Enabled = False
      ShowOnTaskbarMaximized.Enabled = False
      Form1.ShowInTaskbar = False
    Else
      ShowOnTaskbarAlways.Enabled = True
      ShowOnTaskbarMaximized.Enabled = True
      Form1.ShowInTaskbar = True
    End If
    My.Settings.ShowOnTaskbar = ShowOnTaskbar.Checked
    Me.BringToFront()
  End Sub
  Private Sub ShowOnTaskbarAlways_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowOnTaskbarAlways.CheckedChanged
    My.Settings.TaskbarType = "always"
  End Sub
  Private Sub ShowOnTaskbarMaximized_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowOnTaskbarMaximized.CheckedChanged
    My.Settings.TaskbarType = "maximized"
  End Sub

  '#################################################'
  '################### FONTS TAB ###################'
  '#################################################'

  Private Sub FontList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontList.SelectedIndexChanged
    FontBox.Text = FontList.SelectedItem.ToString
    Dim fontFamily As New FontFamily(FontList.SelectedItem.ToString)
    Dim fontStyleNum As Integer
    Select Case (FontStyleList.SelectedItem.ToString)
      Case "Regular"
        fontStyleNum = 0
      Case "Italic"
        fontStyleNum = 2
      Case "Bold"
        fontStyleNum = 1
      Case "Bold Italic"
        fontStyleNum = 3
      Case Else
        fontStyleNum = 0
    End Select
    If (fontFamily.IsStyleAvailable(fontStyleNum)) Then
      Dim previewfont As New Font(fontFamily, FontSizeList.SelectedItem, fontStyleNum, GraphicsUnit.Point)
      FontPreview.Font = previewfont
    End If
  End Sub

  Private Sub FontStyleList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontStyleList.SelectedIndexChanged
    FontStyleBox.Text = FontStyleList.SelectedItem.ToString
    Dim fontFamily As New FontFamily(FontList.SelectedItem.ToString)
    Dim fontStyleNum As Integer
    Select Case (FontStyleList.SelectedItem.ToString)
      Case "Regular"
        fontStyleNum = 0
      Case "Italic"
        fontStyleNum = 2
      Case "Bold"
        fontStyleNum = 1
      Case "Bold Italic"
        fontStyleNum = 3
      Case Else
        fontStyleNum = 0
    End Select
    If (fontFamily.IsStyleAvailable(fontStyleNum)) Then
      Dim previewfont As New Font(fontFamily, FontSizeList.SelectedItem, fontStyleNum, GraphicsUnit.Point)
      FontPreview.Font = previewfont
    End If
  End Sub

  Private Sub FontSizeList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontSizeList.SelectedIndexChanged
    FontSizeBox.Text = FontSizeList.SelectedItem.ToString
    Dim fontFamily As New FontFamily(FontList.SelectedItem.ToString)
    Dim fontStyleNum As Integer
    Select Case (FontStyleList.SelectedItem.ToString)
      Case "Regular"
        fontStyleNum = 0
      Case "Italic"
        fontStyleNum = 2
      Case "Bold"
        fontStyleNum = 1
      Case "Bold Italic"
        fontStyleNum = 3
      Case Else
        fontStyleNum = 0
    End Select
    If (fontFamily.IsStyleAvailable(fontStyleNum)) Then
      Dim previewfont As New Font(fontFamily, FontSizeList.SelectedItem, fontStyleNum, GraphicsUnit.Point)
      FontPreview.Font = previewfont
    End If
  End Sub

  '#################################################'
  '################## COLORS TAB ###################'
  '#################################################'

  Private Sub DefineFGColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefineFGColor.Click
    Dim DefineCustomColor As New ColorDialog
    DefineCustomColor.AllowFullOpen = True
    DefineCustomColor.AnyColor = True
    DefineCustomColor.FullOpen = True
    DefineCustomColor.SolidColorOnly = False
    DefineCustomColor.ShowDialog()
    CustomFGColor.BackColor = DefineCustomColor.Color
    DefineCustomColor.Dispose()
  End Sub

  Private Sub DefineBGColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefineBGColor.Click
    Dim DefineCustomColor As New ColorDialog
    DefineCustomColor.AllowFullOpen = True
    DefineCustomColor.AnyColor = True
    DefineCustomColor.FullOpen = True
    DefineCustomColor.SolidColorOnly = False
    DefineCustomColor.ShowDialog()
    CustomBGColor.BackColor = DefineCustomColor.Color
    DefineCustomColor.Dispose()
  End Sub

  '#################################################'
  '################## OPACITY TAB ##################'
  '#################################################'

  Private Sub OpacityDisabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpacityDisabled.CheckedChanged
    If (OpacityDisabled.Checked = True) Then
      OpacityLevelGroup.Enabled = False
      AutoOpaqueGroup.Enabled = False
      My.Settings.Opacity = "disabled"
      Form1.Opacity = 0.99
      AutoOpaqueGroup.Enabled = False
    End If
  End Sub
  Private Sub OpacityEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpacityEnabled.CheckedChanged
    If (OpacityEnabled.Checked = True) Then
      My.Settings.Opacity = "enabled"
      Form1.Opacity = CDbl("0." & OpacityLevel.Value.ToString.PadLeft(2, "0"))
			AutoOpaqueGroup.Enabled = False
			OpacityLevelGroup.Enabled = True
    End If
  End Sub
  Private Sub OpacityOnFocus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpacityOnFocus.CheckedChanged
    If (OpacityOnFocus.Checked = True) Then
      My.Settings.Opacity = "onfocus"
      Form1.Opacity = 0.99
			AutoOpaqueGroup.Enabled = True
			OpacityLevelGroup.Enabled = True
    End If
  End Sub
  Private Sub OpacityOnHover_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpacityOnHover.CheckedChanged
    If (OpacityOnHover.Checked = True) Then
      My.Settings.Opacity = "onhover"
      Form1.Opacity = 0.99
			AutoOpaqueGroup.Enabled = True
			OpacityLevelGroup.Enabled = True
    End If
  End Sub

  Private Sub OpacityLevel_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpacityLevel.Scroll
    OpacitySelectedLevel.Text = (OpacityLevel.Value + 1).ToString & "%"
    My.Settings.OpacityLevel = OpacityLevel.Value
    If (OpacityEnabled.Checked = True) Then
      Form1.Opacity = ("0." & OpacityLevel.Value.ToString)
    End If
  End Sub

  Private Sub OpacityFadeInTimer_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpacityFadeInTimer.Scroll
    FadeInTime.Text = OpacityFadeInTimer.Value.ToString & "ms"
    My.Settings.FadeInTime = OpacityFadeInTimer.Value
  End Sub

  Private Sub OpacityFadeOutTimer_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpacityFadeOutTimer.Scroll
    FadeOutTime.Text = OpacityFadeOutTimer.Value.ToString & "ms"
    My.Settings.FadeOutTime = OpacityFadeOutTimer.Value
  End Sub

  '#################################################'
  '############## QUICK COMMANDS TAB ###############'
  '#################################################'

  Private Sub QC_CommonSeer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_CommonSeer.Click
    QC_GetInfo.Checked = True
    QC_Kill.Checked = True
    QC_Ressurect.Checked = True
    QC_Jail.Checked = True
    QC_Kick.Checked = True
    QC_Hide.Checked = True
    QC_Destroy.Checked = True
    QC_MDestroy.Checked = False
    QC_RoofCreator.Checked = False
    QC_ItemInfo.Checked = True
    QC_LockdownItem.Checked = False
    QC_LockRadius5.Checked = False
    QC_LockRadius10.Checked = False
    QC_ConcealMe.Checked = True
    QC_RevealMe.Checked = True
    QC_GMForm.Checked = True
    QC_MyForm.Checked = True
    QC_SaveShard.Checked = True
    QC_Nightsight.Checked = True
    QC_HelpQueue.Checked = True
    QC_PropEdit.Checked = False
    QC_Mark.Checked = True
    QC_Recall.Checked = True
    QC_Goto.Checked = True
    QC_SummonPlayer.Checked = True
    QC_Tele.Checked = True
    QC_MTele.Checked = True
    QC_TeleTo.Checked = True
    QC_Where.Checked = True

  End Sub
  Private Sub QC_CommonBuilder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_CommonBuilder.Click
    QC_GetInfo.Checked = False
    QC_Kill.Checked = False
    QC_Ressurect.Checked = False
    QC_Jail.Checked = False
    QC_Kick.Checked = False
    QC_Hide.Checked = False
    QC_Destroy.Checked = True
    QC_MDestroy.Checked = True
    QC_RoofCreator.Checked = True
    QC_ItemInfo.Checked = True
    QC_LockdownItem.Checked = True
    QC_LockRadius5.Checked = True
    QC_LockRadius10.Checked = True
    QC_ConcealMe.Checked = False
    QC_RevealMe.Checked = False
    QC_GMForm.Checked = False
    QC_MyForm.Checked = False
    QC_SaveShard.Checked = True
    QC_Nightsight.Checked = True
    QC_HelpQueue.Checked = False
    QC_PropEdit.Checked = True
    QC_Mark.Checked = False
    QC_Recall.Checked = False
    QC_Goto.Checked = True
    QC_SummonPlayer.Checked = False
    QC_Tele.Checked = True
    QC_MTele.Checked = True
    QC_TeleTo.Checked = True
    QC_Where.Checked = True
  End Sub

  Private Sub QC_GetInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_GetInfo.CheckedChanged
    If (QC_GetInfo.Checked = True) Then
      Form1.QC_GetInfoMenuItem.Visible = True
    Else
      Form1.QC_GetInfoMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Kill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Kill.CheckedChanged
    If (QC_Kill.Checked = True) Then
      Form1.QC_KillMenuItem.Visible = True
    Else
      Form1.QC_KillMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Ressurect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Ressurect.CheckedChanged
    If (QC_Ressurect.Checked = True) Then
      Form1.QC_RessurectMenuItem.Visible = True
    Else
      Form1.QC_RessurectMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Jail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Jail.CheckedChanged
    If (QC_Jail.Checked = True) Then
      Form1.QC_JailMenuItem.Visible = True
    Else
      Form1.QC_JailMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Kick_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Kick.CheckedChanged
    If (QC_Kick.Checked = True) Then
      Form1.QC_KickMenuItem.Visible = True
    Else
      Form1.QC_KickMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Hide_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Hide.CheckedChanged
    If (QC_Hide.Checked = True) Then
      Form1.QC_HideMenuItem.Visible = True
    Else
      Form1.QC_HideMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Destroy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Destroy.CheckedChanged
    If (QC_Destroy.Checked = True) Then
      Form1.QC_DestroySItemMenuItem.Visible = True
    Else
      Form1.QC_DestroySItemMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_MDestroy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_MDestroy.CheckedChanged
    If (QC_MDestroy.Checked = True) Then
      Form1.QC_DestroyMItemsMenuItem.Visible = True
    Else
      Form1.QC_DestroyMItemsMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_RoofCreator_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_RoofCreator.CheckedChanged
    If (QC_RoofCreator.Checked = True) Then
      Form1.QC_RoofCreatorMenuItem.Visible = True
    Else
      Form1.QC_RoofCreatorMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_ItemInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_ItemInfo.CheckedChanged
    If (QC_ItemInfo.Checked = True) Then
      Form1.QC_ItemInfoMenuItem.Visible = True
    Else
      Form1.QC_ItemInfoMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_LockdownItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_LockdownItem.CheckedChanged
    If (QC_LockdownItem.Checked = True) Then
      Form1.QC_LockItemMenuItem.Visible = True
    Else
      Form1.QC_LockItemMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_LockRadius5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_LockRadius5.CheckedChanged
    If (QC_LockRadius5.Checked = True) Then
      Form1.QC_LockRadius5MenuItem.Visible = True
    Else
      Form1.QC_LockRadius5MenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_LockRadius10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_LockRadius10.CheckedChanged
    If (QC_LockRadius10.Checked = True) Then
      Form1.QC_LockRadius10MenuItem.Visible = True
    Else
      Form1.QC_LockRadius10MenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_ConcealMe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_ConcealMe.CheckedChanged
    If (QC_ConcealMe.Checked = True) Then
      Form1.QC_ConcealMeMenuItem.Visible = True
    Else
      Form1.QC_ConcealMeMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_RevealMe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_RevealMe.CheckedChanged
    If (QC_RevealMe.Checked = True) Then
      Form1.QC_RevealMeMenuItem.Visible = True
    Else
      Form1.QC_RevealMeMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_GMForm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_GMForm.CheckedChanged
    If (QC_GMForm.Checked = True) Then
      Form1.QC_GMFormMenuItem.Visible = True
    Else
      Form1.QC_GMFormMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_MyForm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_MyForm.CheckedChanged
    If (QC_MyForm.Checked = True) Then
      Form1.QC_MyFormMenuItem.Visible = True
    Else
      Form1.QC_MyFormMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_SaveShard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_SaveShard.CheckedChanged
    If (QC_SaveShard.Checked = True) Then
      Form1.QC_SaveShardMenuItem.Visible = True
    Else
      Form1.QC_SaveShardMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Nightsight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Nightsight.CheckedChanged
    If (QC_Nightsight.Checked = True) Then
      Form1.QC_NightsightMenuItem.Visible = True
    Else
      Form1.QC_NightsightMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_HelpQueue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_HelpQueue.CheckedChanged
    If (QC_HelpQueue.Checked = True) Then
      Form1.QC_HelpQueueMenuItem.Visible = True
    Else
      Form1.QC_HelpQueueMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_PropEdit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_PropEdit.CheckedChanged
    If (QC_PropEdit.Checked = True) Then
      Form1.QC_PropEditMenuItem.Visible = True
    Else
      Form1.QC_PropEditMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Mark_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Mark.CheckedChanged
    If (QC_Mark.Checked = True) Then
      Form1.QC_MarkMenuItem.Visible = True
    Else
      Form1.QC_MarkMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Recall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Recall.CheckedChanged
    If (QC_Recall.Checked = True) Then
      Form1.QC_RecallMenuItem.Visible = True
    Else
      Form1.QC_RecallMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Where_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Where.CheckedChanged
    If (QC_Where.Checked = True) Then
      Form1.QC_WhereMenuItem.Visible = True
    Else
      Form1.QC_WhereMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Goto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Goto.CheckedChanged
    If (QC_Goto.Checked = True) Then
      Form1.QC_GotoPlayerMenuItem.Visible = True
    Else
      Form1.QC_GotoPlayerMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_Tele_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_Tele.CheckedChanged
    If (QC_Tele.Checked = True) Then
      Form1.QC_TeleMenuItem.Visible = True
    Else
      Form1.QC_TeleMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_MTele_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_MTele.CheckedChanged
    If (QC_MTele.Checked = True) Then
      Form1.QC_MTeleMenuItem.Visible = True
    Else
      Form1.QC_MTeleMenuItem.Visible = False
    End If
  End Sub
  Private Sub QC_TeleTo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC_TeleTo.CheckedChanged
    If (QC_TeleTo.Checked = True) Then
      Form1.QC_TeleToMenuItem.Visible = True
    Else
      Form1.QC_TeleToMenuItem.Visible = False
    End If
  End Sub

  '#################################################'
  '################## UPDATES TAB ##################'
  '#################################################'

  Private Sub AutoUpdates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoUpdates.CheckedChanged
    If (AutoUpdates.Checked = False) Then
      AutoUpdateEveryTime.Enabled = False
      AutoUpdateOnceDay.Enabled = False
      AutoUpdateOnceWeek.Enabled = False
      FilesToUpdateGroup.Enabled = False
    Else
      AutoUpdateEveryTime.Enabled = True
      AutoUpdateOnceDay.Enabled = True
      AutoUpdateOnceWeek.Enabled = True
      FilesToUpdateGroup.Enabled = True
    End If
  End Sub



  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    My.Settings.Save()
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    My.Settings.Reload()
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

End Class
