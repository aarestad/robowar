Option Strict Off
Option Explicit On
Friend Class DebuggingWindow
	Inherits System.Windows.Forms.Form
	
	Public DebuggingRes As Byte
	Public Xpos As Short
	Public DebugMsg As String
	
	Private Sub DebuggingWindow_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If Xpos = 0 Then FileGet(7, Xpos, 9000)
		Me.Left = VB6.TwipsToPixelsX(Xpos)
		
	End Sub
	
	Private Sub DebuggingWindow_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
		If VB6.PixelsToTwipsX(Me.Left) <> Xpos Then
			Xpos = VB6.PixelsToTwipsX(Me.Left)
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, Xpos, 9000)
		End If
		
		If MainWindow.BattleHaltButton.Text = "Halt" Then 'If Battle is running then
			DebuggingRes = 2
		Else 'If Battle is not running
			MainWindow.TurnOfTheDebugger()
		End If
		
	End Sub
	
	'step = 0
	'chronon = 1
	'stopdebug = 2
	'terminatebat = 3
	
	Private Sub Step_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Step_Renamed.Click
		DebuggingRes = 0
		'Unload Me
	End Sub
	
	Private Sub ChrononStep_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ChrononStep.Click
		DebuggingRes = 1
		'Unload Me
	End Sub
	
	Private Sub StopDebugging_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles StopDebugging.Click
		Me.Close()
	End Sub
	
	'Private Sub TerminateBattle_Click()
	'DebuggingRes = 3
	'Unload Me
	'End Sub
	Private Sub TerminateDebugging_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TerminateDebugging.Click
		MainWindow.InactivateDebug.Checked = True
		Me.Close()
	End Sub
End Class