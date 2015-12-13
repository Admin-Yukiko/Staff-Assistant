Public Class SplashScreen2
	Private Sub SplashScreen2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Version.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
		Copyright.Text = "Designed exclusively for the Nightscape Shard by:" & My.Application.Info.Copyright
	End Sub
End Class