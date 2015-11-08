Imports System.Windows.Forms

Public Class ProgramLauncherSetupDialog

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		If (Program.Text = "" Or ButtonName.Text = "") Then
			MessageBox.Show("You failed to enter a button name and/or specify a program.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Else
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.Close()
		End If
	End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Program.Text = Nothing
    ButtonName.Text = Nothing
    Me.Close()
  End Sub

  Private Sub BrowseBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseBtn.Click
    Dim OpenFileDialog As New OpenFileDialog
    OpenFileDialog.AddExtension = True
    OpenFileDialog.CheckFileExists = True
    OpenFileDialog.CheckPathExists = True
    OpenFileDialog.DefaultExt = "exe"
    OpenFileDialog.DereferenceLinks = True
    OpenFileDialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*"
    OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
    OpenFileDialog.Multiselect = False
    OpenFileDialog.ReadOnlyChecked = True
    OpenFileDialog.ShowReadOnly = False
    OpenFileDialog.ShowHelp = False
    OpenFileDialog.SupportMultiDottedExtensions = False
    OpenFileDialog.Title = "Select a program..."
    OpenFileDialog.ValidateNames = True
    Dim ReturnedValue As DialogResult = OpenFileDialog.ShowDialog()
    If (ReturnedValue = Windows.Forms.DialogResult.OK) Then
      Program.Text = OpenFileDialog.FileName
      If (ButtonName.Text = "") Then
        ButtonName.Text = System.IO.Path.GetFileNameWithoutExtension(StrConv(OpenFileDialog.FileName, VbStrConv.ProperCase))
      End If
    End If
    OpenFileDialog.Dispose()
  End Sub

  Function GetFilePath(ByVal FileName As String) As String
    Dim i As Long
    For i = Len(FileName) To 1 Step -1
      Select Case Mid(FileName, i, 1)
        Case ":"
          ' colons aren't included in the result
          GetFilePath = Microsoft.VisualBasic.Left(FileName, i - 1)
          Exit For
        Case "\"
          ' backslash aren't included in the result either
          GetFilePath = Microsoft.VisualBasic.Left(FileName, i - 1)
          Exit For
      End Select
    Next
    GetFilePath = FileName
  End Function

End Class
