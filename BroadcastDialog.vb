Imports System.Windows.Forms

Public Class BroadcastDialog

  Private Sub BroadcastDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    BCastMessage.AutoCompleteCustomSource = My.Settings.BCastMessage_AutoComplete
  End Sub

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    If (BCastMessage.Text <> Nothing) Then
      BCastMessage.AutoCompleteCustomSource.Add(BCastMessage.Text)
      My.Settings.BCastMessage_AutoComplete = BCastMessage.AutoCompleteCustomSource
      My.Settings.Save()
    Else
      MessageBox.Show("You failed to supply a message to broadcast", "Missing message...", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Label1.ForeColor = Color.Red
      Exit Sub
    End If
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
