Namespace My

  ' The following events are availble for MyApplication:
  ' 
  ' Startup: Raised when the application starts, before the startup form is created.
  ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
  ' UnhandledException: Raised if the application encounters an unhandled exception.
  ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
  ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
  Partial Friend Class MyApplication

    Protected Overrides Function OnInitialize(ByVal commandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean
			' Set the display time to 2500 milliseconds (3.0 seconds). 
			Me.MinimumSplashScreenDisplayTime = 3000
			Return MyBase.OnInitialize(commandLineArgs)
		End Function

  End Class

	Public Class OptimizedPanel
		Inherits System.Windows.Forms.Panel

		Public Sub New()
			MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
			MyBase.SetStyle(ControlStyles.ResizeRedraw, False)
		End Sub
	End Class

End Namespace
