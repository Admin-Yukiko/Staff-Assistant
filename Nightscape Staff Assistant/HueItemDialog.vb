Imports System.Windows.Forms

Public Class HueItemDialog

	Dim hues() As Ultima.Hue = Ultima.Hues.List
	Dim HueBrush As New Drawing.SolidBrush(Color.Black)
	Dim BoxSize As New Point(12, 15)


	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub Panel1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseClick
		If (e.Button = Windows.Forms.MouseButtons.Left) Then
			'Kinda works... except if you scroll. heh
			MessageBox.Show("Was your hue " & System.Math.Floor(e.Y / BoxSize.Y) & "?")
		End If
	End Sub

	Private Sub Panel1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.MouseHover
		Panel1.Focus()
	End Sub

	'Private Sub Panel1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Panel1.Scroll
	'	If (e.Type = ScrollEventType.SmallDecrement) Then
	'		e.NewValue = e.OldValue - 15
	'		Panel1.Invalidate()
	'	End If
	'	If (e.Type = ScrollEventType.SmallIncrement) Then
	'		e.NewValue = e.OldValue + 15
	'		Panel1.Invalidate()
	'	End If
	'	Label1.Text = "new value: " & e.NewValue & ", old value: " & e.OldValue
	'End Sub

	Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
		'Panel1.SuspendLayout()

		Dim HueBox As New Drawing.Rectangle(0, Panel1.AutoScrollPosition.X, BoxSize.X, BoxSize.Y)

		'INITIALIZE THE GRAPHICS OBJECT USED FOR DRAWING
		Dim HueFill As Graphics
		HueFill = e.Graphics

		Label2.Text = "Visible: x:" & Panel1.AutoScrollPosition.X & " y:" & ((Panel1.AutoScrollPosition.Y - Panel1.AutoScrollPosition.Y) - Panel1.AutoScrollPosition.Y)

		'DEFINE THE RENDERING QUALITY
		RenderingQuality(HueFill)

		'CALCULATE WHICH HUES TO DISPLAY BASED ON THE SCROLL POSITION
		Dim FirstHue As Integer = ((Panel1.AutoScrollPosition.Y - (Panel1.AutoScrollPosition.Y * 2)) / BoxSize.Y)
		Dim LastHue As Integer = FirstHue + System.Math.Floor(299 / BoxSize.Y)

		Label3.Text = "Showing Hues: " & FirstHue & " through " & LastHue

		'FILL IN THE AREA BEHIND THE HUES WITH BLACK
		HueFill.FillRectangle(Brushes.Black, 105, 0, Panel1.Width, Panel1.Height)

		'LOOP THROUGH AND DRAW THE DISPLAYED HUES
		For hue_cnt As Integer = FirstHue To LastHue

			' DRAW THE TEXT FOR THE HUE ID.
			HueFill.DrawString(hue_cnt.ToString.PadLeft(4, " ") & " (0x" & Hex(hue_cnt).PadLeft(3, "0") & ")", New Font("Lucida Console", 9), Brushes.Black, 7, HueBox.Y + 2)

			'DRAW EACH COLOR TO MAKE UP THE HUE
			For color_cnt As Integer = 0 To 31
				HueBox.X = 105 + (color_cnt * BoxSize.X)
				HueBrush.Color = hues(hue_cnt).GetColor(color_cnt)
				HueFill.FillRectangle(HueBrush, HueBox)
			Next

			'DRAW HORIZONTAL LINE DIVIDING COLORS
			HueFill.DrawLine(Pens.Black, 0, HueBox.Y, Panel1.Width, HueBox.Y)
			'DRAW VERTICAL LINE DIVIDING HUE AND TEXT AREAS
			HueFill.DrawLine(Pens.Black, 104, 0, 104, Panel1.Height)

			'INCREMENT THE Y OFFSET FOR DRAWING THE NEXT HUE
			HueBox.Y = HueBox.Y + BoxSize.Y

		Next

	End Sub

	Public Sub RenderingQuality(ByRef HueFill As Graphics)
		Select Case My.Settings.RenderingQuality
			Case "Highest"
				HueFill.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
				HueFill.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
				HueFill.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
				HueFill.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
				HueFill.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
			Case "High"
				HueFill.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
				HueFill.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
				HueFill.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
				HueFill.InterpolationMode = Drawing2D.InterpolationMode.High
				HueFill.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
			Case "Low"
				HueFill.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
				HueFill.SmoothingMode = Drawing2D.SmoothingMode.None
				HueFill.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixel
				HueFill.InterpolationMode = Drawing2D.InterpolationMode.Low
				HueFill.PixelOffsetMode = Drawing2D.PixelOffsetMode.None
			Case Else	'Medium (default)
				HueFill.CompositingQuality = Drawing2D.CompositingQuality.AssumeLinear
				HueFill.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
				HueFill.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
				HueFill.InterpolationMode = Drawing2D.InterpolationMode.Bicubic
				HueFill.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighSpeed
		End Select
	End Sub

End Class
