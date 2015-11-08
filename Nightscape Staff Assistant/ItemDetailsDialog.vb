Imports System.Windows.Forms

Public Class ItemDetailsDialog

	Private Sub CreateInPackBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateInPackBtn.Click

	End Sub

	Private Sub CreateAtFeetBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateAtFeetBtn.Click

	End Sub

	Private Sub CreateAtTargetBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateAtTargetBtn.Click

	End Sub

	Private Sub CreateTiledBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateTiledBtn.Click

	End Sub

	Private Sub SaveImageBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveImageBtn.Click
		Dim SaveDialog As New SaveFileDialog
		SaveDialog.AddExtension = True
		SaveDialog.FileName = StatusBar.Items(0).Text.Split("|")(1)
		SaveDialog.DefaultExt = "bmp"
		SaveDialog.Filter = "BMP (*.bmp)|*.bmp|PNG (*.png)|*.png|GIF (*.gif)|*.gif|JPEG (*.*jpg)|*.jpg"
		SaveDialog.FilterIndex = 1
		SaveDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
		Dim ReturnedValue As DialogResult = SaveDialog.ShowDialog()
		If (ReturnedValue = Windows.Forms.DialogResult.OK) Then
			Select Case (SaveDialog.FilterIndex)
				Case 1
					PictureBoxPanel.BackgroundImage.Save(SaveDialog.FileName)
				Case 2
					PictureBoxPanel.BackgroundImage.Save(SaveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png)
				Case 3
					PictureBoxPanel.BackgroundImage.Save(SaveDialog.FileName, System.Drawing.Imaging.ImageFormat.Gif)
				Case 4
					PictureBoxPanel.BackgroundImage.Save(SaveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
			End Select
		End If
	End Sub

	Private Sub CloseBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseBtn.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

End Class
