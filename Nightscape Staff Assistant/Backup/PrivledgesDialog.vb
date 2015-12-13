Imports System.Windows.Forms

Public Class PrivledgesDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

  Private Sub PrivledgeList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrivledgeList.SelectedIndexChanged
    Select Case (PrivledgeList.SelectedItem.ToString)
      Case "moveany"
        PrivledgeDescription.Text = "Allows the person to move any item."
      Case "renameany"
        PrivledgeDescription.Text = "Allows the person to rename any character or npc."
      Case "clotheany"
        PrivledgeDescription.Text = "Allows the person to manipulate the wearables of other characters and npcs through their paperdoll."
      Case "showadv"
        PrivledgeDescription.Text = "Currently this privledge is disabled and has no effect."
      Case "invul"
        PrivledgeDescription.Text = "Makes the person immune to any damage."
      Case "seehidden"
        PrivledgeDescription.Text = "Allows the person to see hidden characters or npcs."
      Case "seeghosts"
        PrivledgeDescription.Text = "Allows the person to see ghosts."
      Case "hearghosts"
        PrivledgeDescription.Text = "Allows the person to hear ghost speech."
      Case "seeinvisitems"
        PrivledgeDescription.Text = "Allows the person to see invisible items."
      Case "dblclickany"
        PrivledgeDescription.Text = "Allows the person to use any item regardless of distance or line-of-sight."
      Case "losany"
        PrivledgeDescription.Text = "Allows the person to always have line-of-sight to everything at all times."
      Case "ignoredoors"
        PrivledgeDescription.Text = "Allows the players to walk through doors*." & vbCrLf & vbCrLf & "*must be in GM form."
      Case "freemove"
        PrivledgeDescription.Text = "Makes the person immune to paralyze, frozen, stamina cost for movement, and ignores any codethat would hinder push-through."
    End Select
  End Sub
End Class
