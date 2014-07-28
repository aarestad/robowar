Option Strict Off
Option Explicit On
Friend Class WelcomeHelp
	Inherits System.Windows.Forms.Form
	
	'Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
	'MainWindow.SetFocus        'Äsch :/
	'SendKeys
	'End Sub
	
	'Private Sub Form_Load()
	'HelpText = "Welcome to RoboWar!" & vbCrLf & _
	''"Thanks for downloading and trying out my game!" & vbCrLf & vbCrLf & _
	''"Click the Battle Button to watch the Robots fight." & vbCrLf & vbCrLf & _
	''"Click the buttons next to the Robots name to load another Robot." & vbCrLf & vbCrLf & _
	''"Remove robots from the Arena can be done by clicking the Robots name and select 'Close Robot' from the File menu (Ctrl-W)." & vbCrLf & _
	''"If you feel daring enough to create your own Robot, select new Robot from the file menu. "
	'
	'End Sub
	
	
	
	Private Sub Close_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Close_Renamed.Click
		MainWindow.WelcomeWindowSwitchMenu.Checked = False
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, True, 7000)
		Me.Close()
	End Sub
	
	
	'UPGRADE_WARNING: Form event WelcomeHelp.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub WelcomeHelp_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated '?
		Me.Activate()
	End Sub
	
	Private Sub Hide_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Hide_Renamed.Click
		Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
		MainWindow.Activate()
	End Sub
End Class