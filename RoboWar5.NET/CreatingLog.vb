Option Strict Off
Option Explicit On
Friend Class CreatingLog
	Inherits System.Windows.Forms.Form
	
	Public CanceledLog As Boolean
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		CanceledLog = True
	End Sub
	
	Private Sub CreatingLog_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		CanceledLog = False
	End Sub
End Class