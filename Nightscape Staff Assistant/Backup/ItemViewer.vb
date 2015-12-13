Imports System.Windows.Forms

Public Class ItemViewer

	Dim LastActiveControl As Control
	Dim LastItemID As Integer = 0
	Dim ItemInfo() As Ultima.ItemData = Ultima.TileData.ItemTable

	Private Sub ItemViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		PopulateWindow()
	End Sub

	Private Sub ScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles ScrollBar.Scroll
		Try
			LastActiveControl.BackColor = Color.White
		Catch ex As Exception
			'no previous control...
		End Try
		PopulateWindow()
	End Sub

	Private Sub Picture_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicPanel1.MouseDown, PicPanel2.MouseDown, PicPanel3.MouseDown, PicPanel4.MouseDown, PicPanel5.MouseDown, PicPanel6.MouseDown, PicPanel7.MouseDown, PicPanel8.MouseDown, PicPanel9.MouseDown, PicPanel10.MouseDown, PicPanel11.MouseDown, PicPanel12.MouseDown, PicPanel13.MouseDown, PicPanel14.MouseDown, PicPanel15.MouseDown, PicPanel16.MouseDown, PicPanel17.MouseDown, PicPanel18.MouseDown, PicPanel19.MouseDown, PicPanel20.MouseDown, PicPanel21.MouseDown, PicPanel22.MouseDown, PicPanel23.MouseDown, PicPanel24.MouseDown, PicPanel25.MouseDown, PicPanel26.MouseDown, PicPanel27.MouseDown, PicPanel28.MouseDown, PicPanel29.MouseDown, PicPanel30.MouseDown, PicPanel31.MouseDown, PicPanel32.MouseDown, PicPanel33.MouseDown, PicPanel34.MouseDown, PicPanel35.MouseDown, PicPanel36.MouseDown, PicPanel37.MouseDown, PicPanel38.MouseDown, PicPanel39.MouseDown, PicPanel40.MouseDown, PicPanel41.MouseDown, PicPanel42.MouseDown, PicPanel43.MouseDown, PicPanel44.MouseDown, PicPanel45.MouseDown, PicPanel46.MouseDown, PicPanel47.MouseDown, PicPanel48.MouseDown
		Try
			LastActiveControl.BackColor = Color.White
		Catch ex As Exception
			'no previous control...
		End Try
		LastActiveControl = sender
		Dim test As Control = sender
		ItemNameField.Text = test.Tag.ToString.Split("|")(1)
		ItemIDField.Text = test.Tag.ToString.Split("|")(0) & "  ( 0x" & Hex(test.Tag.ToString.Split("|")(0)) & " )"
		test.BackColor = Color.FromKnownColor(KnownColor.MenuHighlight)
	End Sub

	Private Sub CreateItemAtYourFeetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateItemAtYourFeetToolStripMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Try
				Ultima.Client.BringToTop()
				Ultima.Client.SendText(".createf " & Convert.ToInt32(LastActiveControl.Tag.ToString.Split("|")(0)).ToString)
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			Form1.ShowError("noclient")
		End If
	End Sub
	Private Sub CreateItemInYourBackpackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateItemInYourBackpackToolStripMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Try
				Ultima.Client.BringToTop()
				Ultima.Client.SendText(".create " & Convert.ToInt32(LastActiveControl.Tag.ToString.Split("|")(0)).ToString)
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			Form1.ShowError("noclient")
		End If
	End Sub
	Private Sub CreateItemAtTargetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateItemAtTargetToolStripMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Try
				Ultima.Client.BringToTop()
				Ultima.Client.SendText(".createat " & Convert.ToInt32(LastActiveControl.Tag.ToString.Split("|")(0)).ToString)
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			Form1.ShowError("noclient")
		End If
	End Sub
	Private Sub CreateItemTiledToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateItemTiledToolStripMenuItem.Click
		If (Ultima.Client.Running = True) Then
			Try
				Dim GenericNumericDialog As New GenericNumericDialog
				GenericNumericDialog.TopMost = Me.TopMost
				Int32.TryParse(Form1.INIHandler.Sections("BUILD TAB").Settings("ViewerTileHieght"), GenericNumericDialog.NumericUpDown.Value)
				GenericNumericDialog.Description.Text = "Enter the height at which to create the item(s)..."
				Dim Returned As DialogResult = GenericNumericDialog.ShowDialog()
				If (Returned = Windows.Forms.DialogResult.OK) Then
					Form1.INIHandler.Sections.Sections("BUILD TAB").Settings.Set("ViewerTileHieght", GenericNumericDialog.NumericUpDown.Value.ToString)
					Form1.INIHandler.WriteINIFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/ns~settings.ini")
					Ultima.Client.BringToTop()
					Ultima.Client.SendText(".tile " & Convert.ToInt32(LastActiveControl.Tag.ToString.Split("|")(0)).ToString & " " & GenericNumericDialog.NumericUpDown.Value.ToString)
				End If
				GenericNumericDialog.Dispose()
			Catch ex As Exception
				Exit Sub
			End Try
		Else
			Form1.ShowError("noclient")
		End If
	End Sub

	Private Sub CopyItemIDdecimalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyItemIDdecimalToolStripMenuItem.Click
		My.Computer.Clipboard.SetText(LastActiveControl.Tag.ToString.Split("|")(0).ToString)
	End Sub
	Private Sub CopyItemIDhexadecimalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyItemIDhexadecimalToolStripMenuItem.Click
		My.Computer.Clipboard.SetText("0x" & Hex(LastActiveControl.Tag.ToString.Split("|")(0)).ToString)
	End Sub
	Private Sub CopyItemNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyItemNameToolStripMenuItem.Click
		My.Computer.Clipboard.SetText(LastActiveControl.Tag.ToString.Split("|")(1))
	End Sub

	Private Sub Picture_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicPanel1.MouseDoubleClick, PicPanel2.MouseDoubleClick, PicPanel3.MouseDoubleClick, PicPanel4.MouseDoubleClick, PicPanel5.MouseDoubleClick, PicPanel6.MouseDoubleClick, PicPanel7.MouseDoubleClick, PicPanel8.MouseDoubleClick, PicPanel9.MouseDoubleClick, PicPanel10.MouseDoubleClick, PicPanel11.MouseDoubleClick, PicPanel12.MouseDoubleClick, PicPanel13.MouseDoubleClick, PicPanel14.MouseDoubleClick, PicPanel15.MouseDoubleClick, PicPanel16.MouseDoubleClick, PicPanel17.MouseDoubleClick, PicPanel18.MouseDoubleClick, PicPanel19.MouseDoubleClick, PicPanel20.MouseDoubleClick, PicPanel21.MouseDoubleClick, PicPanel22.MouseDoubleClick, PicPanel23.MouseDoubleClick, PicPanel24.MouseDoubleClick, PicPanel25.MouseDoubleClick, PicPanel26.MouseDoubleClick, PicPanel27.MouseDoubleClick, PicPanel28.MouseDoubleClick, PicPanel29.MouseDoubleClick, PicPanel30.MouseDoubleClick, PicPanel31.MouseDoubleClick, PicPanel32.MouseDoubleClick, PicPanel33.MouseDoubleClick, PicPanel34.MouseDoubleClick, PicPanel35.MouseDoubleClick, PicPanel36.MouseDoubleClick, PicPanel37.MouseDoubleClick, PicPanel38.MouseDoubleClick, PicPanel39.MouseDoubleClick, PicPanel40.MouseDoubleClick, PicPanel41.MouseDoubleClick, PicPanel42.MouseDoubleClick, PicPanel43.MouseDoubleClick, PicPanel44.MouseDoubleClick, PicPanel45.MouseDoubleClick, PicPanel46.MouseDoubleClick, PicPanel47.MouseDoubleClick, PicPanel48.MouseDoubleClick
		If (Ultima.Art.GetStatic(LastActiveControl.Tag.ToString.Split("|")(0)) IsNot Nothing) Then
			Dim ItemDetailsDialog As New ItemDetailsDialog
			ItemDetailsDialog.TopMost = Me.TopMost
			ItemDetailsDialog.ItemDetailsGrid.SelectedObject = ItemInfo(LastActiveControl.Tag.ToString.Split("|")(0))
			ItemDetailsDialog.StatusBar.Items(0).Text = LastActiveControl.Tag
			'ItemDetailsDialog.ItemNameLabel.Text = LastActiveControl.Tag.ToString.Split("|")(1)
			'ItemDetailsDialog.ItemIDLabel.Text = LastActiveControl.Tag.ToString.Split("|")(0) & "  ( 0x" & Hex(LastActiveControl.Tag.ToString.Split("|")(0)) & " )"
			ItemDetailsDialog.PictureBoxPanel.BackgroundImage = Ultima.Art.GetStatic(LastActiveControl.Tag.ToString.Split("|")(0))
			ItemDetailsDialog.PictureBoxPanel.Size = New Size(Ultima.Art.GetStatic(LastActiveControl.Tag.ToString.Split("|")(0)).Width + 1, Ultima.Art.GetStatic(LastActiveControl.Tag.ToString.Split("|")(0)).Height + 1)
			If (ItemDetailsDialog.PictureBoxPanel.Height > ItemDetailsDialog.Panel1.Height) Then
				ItemDetailsDialog.PictureBoxPanel.Location = New Point(System.Math.Floor((ItemDetailsDialog.Panel1.Width / 2) - (ItemDetailsDialog.PictureBoxPanel.Width / 2)), 0)
			Else
				ItemDetailsDialog.PictureBoxPanel.Location = New Point(System.Math.Floor((ItemDetailsDialog.Panel1.Width / 2) - (ItemDetailsDialog.PictureBoxPanel.Width / 2)), System.Math.Floor((ItemDetailsDialog.Panel1.Height / 2) - (ItemDetailsDialog.PictureBoxPanel.Height / 2)))
			End If
			'ItemDetailsDialog.PictureBoxPanel.Location = New Point(0, 0)
			Dim ReturnedValue As DialogResult = ItemDetailsDialog.ShowDialog()
			ItemDetailsDialog.Dispose()
		End If
	End Sub

	Private Sub PopulateWindow()
		Dim ItemNum As Integer = ScrollBar.Value
		Dim PanelCount As Integer = 1


		For IterCounter As Integer = ScrollBar.Value To (ScrollBar.Value + 47)
			If (ItemNum > 16382) Then
				Exit Sub
			End If

			Dim CurPicPanel As Control = Panel1.Controls.Find("PicPanel" & PanelCount, False)(0)
			Try
				CurPicPanel.BackgroundImage.Dispose()
			Catch ex As Exception
				'no previous image...
			End Try

			If (Ultima.Art.GetStatic(ItemNum) IsNot Nothing) Then
				CurPicPanel.BackgroundImage = Ultima.Art.GetStatic(ItemNum)
				CurPicPanel.Tag = ItemNum & "|" & ItemInfo(ItemNum).Name
				PanelCount += 1
			Else
				IterCounter -= 1
			End If
			ItemNum += 1
		Next

		ScrollBar.LargeChange = ItemNum - ScrollBar.Value
		LastItemID = ItemNum
	End Sub

End Class
