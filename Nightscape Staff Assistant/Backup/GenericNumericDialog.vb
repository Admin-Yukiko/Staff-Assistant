Imports System.Windows.Forms

Public Class GenericNumericDialog

	Private Sub GenericNumericDialog_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
		NumericUpDown.Focus()
	End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

	Private Sub NumericUpDown_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown.Enter
		NumericUpDown.Select(0, NumericUpDown.Value.ToString.Length)
	End Sub
End Class
