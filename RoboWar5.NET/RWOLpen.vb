Option Strict Off
Option Explicit On
Friend Class RWOLpen
	Inherits System.Windows.Forms.Form
	
	Private Sub RWOLpen_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Me.Close()
		MainWindow.Show()
	End Sub
	
	Private Sub RWOLpen_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'SetAttr App.Path & "\miscdata\MainPrefs.cfg", 0 'Unlock file
		FileOpen(7, My.Application.Info.DirectoryPath & "\miscdata\MainPrefs.cfg", OpenMode.Binary) 'This file is the prefs file. It's open as long as the app is
		
		Dim YesOrNo As Boolean
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 12000) 'Change resolution (I think this works fine now)
		'No, it doesn't ;-(
		If YesOrNo = True Then
			'UPGRADE_ISSUE: Form property RWOLpen.hdc was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			ChangeWindow_640X480((Me.hdc))
		Else
			RoboWar.Height = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) \ VB6.TwipsPerPixelY - 48) * VB6.TwipsPerPixelY)
			RoboWar.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
			WinByMe.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(RoboWar.Width) \ 2 - VB6.PixelsToTwipsX(WinByMe.Width) \ 2)
			WinByMe.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(RoboWar.Height) / 2.1)
		End If
	End Sub
	
	Private Sub RWOLpen_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Me.Close()
		MainWindow.Show()
	End Sub
	
	Private Sub WinByMe_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WinByMe.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Me.Close()
		MainWindow.Show()
	End Sub
	
	'Private Sub RoboWar_KeyDown(KeyCode As Integer, Shift As Integer)
	'Unload Me
	'MainWindow.Show
	'End Sub
	
	Private Sub RoboWar_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles RoboWar.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Me.Close()
		MainWindow.Show()
	End Sub
End Class