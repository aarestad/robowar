Option Strict Off
Option Explicit On
Friend Class HistoryWindow
	Inherits System.Windows.Forms.Form
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		Me.Close()
	End Sub
End Class