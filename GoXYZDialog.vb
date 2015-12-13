Imports System.Windows.Forms

Public Class GoXYZDialog

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    If ((XCoord.Text = Nothing) Or (YCoord.Text = Nothing) Or (ZCoord.Text = Nothing)) Then
      MessageBox.Show("You failed tp specify one or more coordinates.", "Missing Coordinate(s)...", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
