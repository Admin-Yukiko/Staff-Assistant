Imports System.Windows.Forms

Public Class BuildingToolbar

	Private Sub BuildingToolbar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		My.Settings.ShowBuildingToolbar = True

		If (My.Settings.BuildingToolbarLocation.IsEmpty = False) Then
			If (((My.Settings.BuildingToolbarLocation.X > 0) And (My.Settings.FormLocation.X < My.Computer.Screen.WorkingArea.Width)) And ((My.Settings.BuildingToolbarLocation.Y > 0) And (My.Settings.BuildingToolbarLocation.Y < My.Computer.Screen.WorkingArea.Height))) Then
				Me.Location = My.Settings.BuildingToolbarLocation
			Else
				Me.Location = New Point(0, 0)
				My.Settings.BuildingToolbarLocation = New Point(0, 0)
				My.Settings.Save()
			End If
		End If

	End Sub

	Private Sub NudgeNBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeNBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (My.Computer.Keyboard.ShiftKeyDown = True) Then
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mcy -1")
				Else
					Ultima.Client.SendText(".cy -1")
				End If
			Else
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mpy -1")
				Else
					Ultima.Client.SendText(".py -1")
				End If
			End If
		Else
			Form1.ShowError("noclient")
		End If
	End Sub
	Private Sub NudgeWBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeWBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (My.Computer.Keyboard.ShiftKeyDown = True) Then
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mcx -1")
				Else
					Ultima.Client.SendText(".cx -1")
				End If
			Else
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mpx -1")
				Else
					Ultima.Client.SendText(".px -1")
				End If
			End If
		Else
			Form1.ShowError("noclient")
		End If
	End Sub
	Private Sub NudgeEBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeEBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (My.Computer.Keyboard.ShiftKeyDown = True) Then
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mcx 1")
				Else
					Ultima.Client.SendText(".cx 1")
				End If
			Else
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mpx 1")
				Else
					Ultima.Client.SendText(".px 1")
				End If
			End If
		Else
			Form1.ShowError("noclient")
		End If
	End Sub
	Private Sub NudgeSBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeSBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (My.Computer.Keyboard.ShiftKeyDown = True) Then
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mcy 1")
				Else
					Ultima.Client.SendText(".cy 1")
				End If
			Else
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mpy 1")
				Else
					Ultima.Client.SendText(".py 1")
				End If
			End If
		Else
			Form1.ShowError("noclient")
		End If
	End Sub

	Private Sub NudgeUBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeUBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (My.Computer.Keyboard.ShiftKeyDown = True) Then
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mcz 1")
				Else
					Ultima.Client.SendText(".cz 1")
				End If
			Else
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mpz 1")
				Else
					Ultima.Client.SendText(".pz 1")
				End If
			End If
		Else
			Form1.ShowError("noclient")
		End If
	End Sub
	Private Sub NudgeDBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudgeDBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			If (My.Computer.Keyboard.ShiftKeyDown = True) Then
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mcz -1")
				Else
					Ultima.Client.SendText(".cz -1")
				End If
			Else
				If (My.Computer.Keyboard.CtrlKeyDown = True) Then
					Ultima.Client.SendText(".mpz -1")
				Else
					Ultima.Client.SendText(".pz -1")
				End If
			End If
		Else
			Form1.ShowError("noclient")
		End If
	End Sub

	Private Sub RandTileBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandTileBtn.Click
		'Randtile button also covers button on the Items Tab
		If (Ultima.Client.Running = True) Then
			Dim RandomTileDialog As New RandomTileDialog
			RandomTileDialog.TopMost = Me.TopMost
			Dim ReturnedValue As DialogResult = RandomTileDialog.ShowDialog()
			If (ReturnedValue = Windows.Forms.DialogResult.OK) Then
				Form1.INIHandler.Sections.Sections("BUILD TAB").Settings.Set("RandomTileCategory", RandomTileDialog.ItemCategories.SelectedNode.Text)
				Form1.INIHandler.Sections.Sections("BUILD TAB").Settings.Set("RandomTileItem", RandomTileDialog.ItemList.SelectedNode.Name)
				Form1.INIHandler.Sections.Sections("BUILD TAB").Settings.Set("RandomTileRange", RandomTileDialog.RangeSize.Value)
				Form1.INIHandler.Sections.Sections("BUILD TAB").Settings.Set("RandomTileHeight", RandomTileDialog.HeightToCreateAt.Value)
                Form1.INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/sa~settings.ini")
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
			Form1.ShowError("noclient")
		End If
	End Sub

	Private Sub MassMoveBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MassMoveBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".massmove")
		Else
			Form1.ShowError("noclient")
		End If
	End Sub

	Private Sub CopyPasteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyPasteBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".copypaste")
		Else
			Form1.ShowError("noclient")
		End If
	End Sub

	Private Sub DestroyBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestroyBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".destroy")
		Else
			Form1.ShowError("noclient")
		End If
	End Sub

	Private Sub LockRadiusBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockRadiusBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".lockradius 5")
		Else
			Form1.ShowError("noclient")
		End If
	End Sub

	Private Sub RenameBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameBtn.Click
		If (Ultima.Client.Running = True) Then
			Dim GenericStringDialog As New GenericStringDialog
			GenericStringDialog.TopMost = Me.TopMost
			GenericStringDialog.TextBox.Text = Form1.INIHandler.Sections("ITEM TWEAK TAB").Settings("RenameItem")
			GenericStringDialog.Description.Text = "Please specify the new name..."
			Dim Returned As DialogResult
			Returned = GenericStringDialog.ShowDialog()
			If (Returned = Windows.Forms.DialogResult.OK) Then
				Form1.INIHandler.Sections.Sections("ITEM TWEAK TAB").Settings.Set("RenameItem", GenericStringDialog.TextBox.Text)
                Form1.INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/sa~settings.ini")
				Ultima.Client.BringToTop()
				Ultima.Client.SendText(".rename " & GenericStringDialog.TextBox.Text)
			End If
			GenericStringDialog.Dispose()
		Else
			Form1.ShowError("noclient")
		End If
	End Sub

	Private Sub MReplaceBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MReplaceBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".mreplace")
		Else
			Form1.ShowError("noclient")
		End If
	End Sub

	Private Sub TeleBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TeleBtn.Click
		If (Ultima.Client.Running = True) Then
			Ultima.Client.BringToTop()
			Ultima.Client.SendText(".tele")
		Else
			Form1.ShowError("noclient")
		End If
	End Sub

	Private Sub BuildingToolbar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		My.Settings.ShowBuildingToolbar = False
		My.Settings.BuildingToolbarLocation = Me.Location
	End Sub
End Class
