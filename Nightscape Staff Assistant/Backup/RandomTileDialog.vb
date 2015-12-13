Imports System.Windows.Forms

Public Class RandomTileDialog

	Public FirstRun As Boolean = True

	Private Sub RandomTileDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		'Form1.BuildItemsList
		'Form1.MainItemsList

		' Suppress repainting the TreeView until all the objects have been created.
		ItemCategories.BeginUpdate()

		' Clear the TreeView each time the method is called.
		ItemCategories.Nodes.Clear()

		'Dim lastGIndex As Integer = -1
		'Dim lastCIndex As Integer = -1

		Dim lastGIndex As String = Nothing
		Dim lastCIndex As String = Nothing

		For Each line As String In Form1.MainItemsList

			If (line.StartsWith("G")) Then
				'lastGIndex += 1
				lastGIndex = line.Substring(2, line.Length - 2)
				ItemCategories.Nodes.Add(lastGIndex, lastGIndex)
				Continue For
			End If

			If ((line.StartsWith("C")) And (lastGIndex <> Nothing)) Then
				'lastCIndex += 1
				lastCIndex = line.Substring(2, line.Length - 2)
				ItemCategories.Nodes(lastGIndex).Nodes.Add(lastCIndex, lastCIndex)
				Continue For
			End If

			If ((line.StartsWith("S")) And (lastCIndex <> Nothing) And (lastGIndex <> Nothing)) Then
				ItemCategories.Nodes(lastGIndex).Nodes(lastCIndex).Nodes.Add(line.Substring(2, line.Length - 2), line.Substring(2, line.Length - 2))
			End If

		Next line

		'lastCIndex = -1
		lastCIndex = Nothing

		For Each line As String In Form1.BuildItemsList

			If (line.StartsWith("C")) Then
				'lastCIndex += 1
				lastCIndex = line.Substring(2, line.Length - 2)
				ItemCategories.Nodes.Add(lastCIndex, lastCIndex)
				Continue For
			End If

			If ((line.StartsWith("S")) And (lastCIndex <> Nothing)) Then
				ItemCategories.Nodes(lastCIndex).Nodes.Add(line.Substring(2, line.Length - 2), line.Substring(2, line.Length - 2))
			End If

		Next line

		' Begin repainting the TreeView.
		ItemCategories.EndUpdate()

		If (Int32.TryParse(Form1.INIHandler.Sections("BUILD TAB").Settings("RandomTileRange"), Nothing) = True) Then
			Int32.TryParse(Form1.INIHandler.Sections("BUILD TAB").Settings("RandomTileRange"), RangeSize.Value)
		End If
		If (Int32.TryParse(Form1.INIHandler.Sections("BUILD TAB").Settings("RandomTileRange"), Nothing) = True) Then
			Int32.TryParse(Form1.INIHandler.Sections("BUILD TAB").Settings("RandomTileHeight"), HeightToCreateAt.Value)
		End If

		If (Form1.INIHandler.Sections("BUILD TAB").Settings("RandomTileCategory") <> Nothing) Then
			ItemCategories.SelectedNode = ItemCategories.Nodes.Find(Form1.INIHandler.Sections("BUILD TAB").Settings("RandomTileCategory"), True)(0)
		End If

	End Sub

	Private Sub ItemCategories_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles ItemCategories.AfterSelect
		Dim FoundParent As Boolean = False
		Dim FoundCat As Boolean = False
		Dim ParentNode As String = Nothing


		ItemList.BeginUpdate()
		ItemList.Nodes.Clear()

		Try
			ParentNode = ItemCategories.SelectedNode.Parent.Text
		Catch ex As Exception
			FoundParent = True
		End Try

		For Each line As String In Form1.MainItemsList
			If (FoundParent = False) Then
				If (ItemCategories.SelectedNode.Parent.Text = line.Substring(2, line.Length - 2)) Then
					FoundParent = True
					Continue For
				End If
			End If
			If (FoundParent = True) Then
				If (ItemCategories.SelectedNode.Text = line.Substring(2, line.Length - 2)) Then
					FoundCat = True
					Continue For
				End If
				If (FoundCat = True) Then
					If ((line.StartsWith("G")) Or (line.StartsWith("C")) Or (line.StartsWith("S"))) Then
						FoundCat = False
						Exit For
					End If
					If (line.StartsWith("I")) Then
						ItemList.Nodes.Add(line.Substring(52, line.Length - 52), line.Substring(2, 50).TrimEnd(" "))
					End If
				End If
			End If
		Next line

		'For Each line As String In Form1.MainItemsList
		'If (ItemCategories.SelectedNode.Text = line.Substring(2, line.Length - 2)) Then
		'INNER_OK = True
		'Continue For
		'End If
		'If (((line.StartsWith("G")) Or (line.StartsWith("C")) Or (line.StartsWith("S"))) And (INNER_OK = True)) Then
		'INNER_OK = False
		'Exit For
		'End If
		'If ((INNER_OK = True) And (line.StartsWith("I"))) Then
		'ItemList.Nodes.Add(line.Substring(52, line.Length - 52), line.Substring(2, 50).TrimEnd(" "))
		'End If
		'Next line

		If (FoundCat = True) Then
			For Each line As String In Form1.BuildItemsList
				If (FoundParent = False) Then
					If (ItemCategories.SelectedNode.Parent.Text = line.Substring(2, line.Length - 2)) Then
						FoundParent = True
						Continue For
					End If
				End If
				If (FoundParent = True) Then
					If (ItemCategories.SelectedNode.Text = line.Substring(2, line.Length - 2)) Then
						FoundCat = True
						Continue For
					End If
					If (FoundCat = True) Then
						If ((line.StartsWith("G")) Or (line.StartsWith("C")) Or (line.StartsWith("S"))) Then
							FoundCat = False
							Exit For
						End If
						If (line.StartsWith("I")) Then
							ItemList.Nodes.Add(line.Substring(52, line.Length - 52), line.Substring(2, 50).TrimEnd(" "))
						End If
					End If
				End If
			Next line
		End If

		'If (INNER_OK = True) Then
		'	For Each line As String In Form1.BuildItemsList
		'		If (ItemCategories.SelectedNode.Text = line.Substring(2, line.Length - 2)) Then
		'			INNER_OK = True
		'			Continue For
		'		End If
		'		If (((line.StartsWith("G")) Or (line.StartsWith("C")) Or (line.StartsWith("S"))) And (INNER_OK = True)) Then
		'			INNER_OK = False
		'			Exit For
		'		End If
		'		If ((INNER_OK = True) And (line.StartsWith("I"))) Then
		'			ItemList.Nodes.Add(line.Substring(52, line.Length - 52), line.Substring(2, 50).TrimEnd(" "))
		'		End If
		'	Next line
		'End If

		ItemList.EndUpdate()

		If ((Form1.INIHandler.Sections("BUILD TAB").Settings("RandomTileItem") <> Nothing) And (FirstRun = True)) Then
			FirstRun = False
			ItemList.Focus()
			ItemList.Select()
			ItemList.SelectedNode = ItemList.Nodes.Find(Form1.INIHandler.Sections("BUILD TAB").Settings("RandomTileItem"), True)(0)
		End If

	End Sub

  Private Sub ItemList_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles ItemList.AfterSelect

    ItemRangePreview.BeginUpdate()

    ItemRangePreview.LargeImageList.Images.Clear()
    ItemRangePreview.Clear()

    Dim ItemID As Integer = Convert.ToInt32(ItemList.SelectedNode.Name, 16)

    If (RangeSize.Value <= 0) Then
      RangeSize.Value = 1
    End If
    GapWarning.Visible = False
    For i As Integer = 0 To RangeSize.Value - 1
      If ((ItemID + i) > 16382) Then
        Exit For
      End If
      If (Ultima.Art.GetStatic(ItemID + i) Is Nothing) Then

        ItemRangePreview.LargeImageList.Images.Add(System.Drawing.Bitmap.FromFile(My.Computer.FileSystem.CurrentDirectory() & "\resources\graphics\unused_tile.bmp"))
        ItemRangePreview.Items.Add("N/A", (i))

        GapWarning.Visible = True
        Continue For
      Else
        ItemRangePreview.LargeImageList.Images.Add(Ultima.Art.GetStatic(ItemID + i))
        ItemRangePreview.Items.Add((ItemID + i).ToString, (i))
      End If
    Next i

    ItemRangePreview.EndUpdate()

  End Sub

  Private Sub RangeSize_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RangeSize.ValueChanged
    'RemoveHandler RangeSize.ValueChanged, AddressOf RangeSize_ValueChanged
    'AddHandler RangeSize.ValueChanged, AddressOf RangeSize_ValueChanged

		Try
			If (String.IsNullOrEmpty(ItemList.SelectedNode.Name)) Then
				Exit Sub
			End If
		Catch ex As Exception
			Exit Sub
		End Try

		ItemRangePreview.BeginUpdate()

		ItemRangePreview.LargeImageList.Images.Clear()
		ItemRangePreview.Clear()

		Dim ItemID As Integer = Convert.ToInt32(ItemList.SelectedNode.Name, 16)

		If (RangeSize.Value <= 0) Then
			RangeSize.Value = 1
		End If
		GapWarning.Visible = False
		For i As Integer = 0 To RangeSize.Value - 1
			If ((ItemID + i) > 16382) Then
				Exit For
			End If
			If (Ultima.Art.GetStatic(ItemID + i) Is Nothing) Then
				ItemRangePreview.LargeImageList.Images.Add(My.Resources.unused_tile)
				ItemRangePreview.Items.Add("N/A", (i))

				GapWarning.Visible = True
				Continue For
			Else
				ItemRangePreview.LargeImageList.Images.Add(Ultima.Art.GetStatic(ItemID + i))
				ItemRangePreview.Items.Add((ItemID + i).ToString, i)
			End If
		Next i

		ItemRangePreview.EndUpdate()

	End Sub

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

End Class
