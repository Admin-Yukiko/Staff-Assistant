Imports System.Windows.Forms

Public Class PerformActionDialog

  Public SelectedAction As String = Nothing

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub ActionList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionList.SelectedIndexChanged
    If (ActionList.SelectedItem = Nothing) Then
      Exit Sub
    End If
    Select Case (ActionList.SelectedItem.ToString)
			Case "Walk unarmed"
				SelectedAction = "0x0000"
			Case "Walk armed"
				SelectedAction = "0x0001"
			Case "Run unarmed"
				SelectedAction = "0x0002"
			Case "Run armed"
				SelectedAction = "0x0003"
			Case "Stand"
				SelectedAction = "0x0004"
			Case "Twist a little (look around?)"
				SelectedAction = "0x0005"
			Case "Look down"
				SelectedAction = "0x0006"
			Case "Stand 1 handed attack"
				SelectedAction = "0x0007"
			Case "Stand 2 handed attack"
				SelectedAction = "0x0008"
			Case "Attack 1 handed wide (sword/any)"
				SelectedAction = "0x0009"
			Case "Attack 1 handed jab (fencing)"
				SelectedAction = "0x000a"
			Case "Attack 1 handed down (mace)"
				SelectedAction = "0x000b"
			Case "Attack 2 handed jab (mace)"
				SelectedAction = "0x000c"
			Case "Attack 2 handed wide"
				SelectedAction = "0x000d"
			Case "Attack 2 handed jab (spear)"
				SelectedAction = "0x000e"
			Case "Attack bow"
				SelectedAction = "0x0012"
			Case "Attack xbow"
				SelectedAction = "0x0013"
			Case "Walk in warmode"
				SelectedAction = "0x000f"
			Case "Spellcasting direction"
				SelectedAction = "0x0010"
			Case "Spellcasting area"
				SelectedAction = "0x0011"
			Case "Get hit"
				SelectedAction = "0x0014"
			Case "Die backward"
				SelectedAction = "0x0015"
			Case "Die forward"
				SelectedAction = "0x0016"
			Case "Bow"
				SelectedAction = "0x0020"
			Case "Salute"
				SelectedAction = "0x0021"
			Case "Eat"
				SelectedAction = "0x0022"
		End Select
  End Sub

End Class
