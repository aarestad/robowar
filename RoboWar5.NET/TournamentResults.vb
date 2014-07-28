Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class TournamentResults
	Inherits System.Windows.Forms.Form
	Public TheTournamentResults As String
	
	'Window flashing
	Private Structure FLASHWINFO
		Dim cbSize As Integer
		Dim hwnd As Integer
		Dim dwflags As Integer
		Dim uCount As Integer
		Dim dwTimeout As Integer
	End Structure
	
	Private Const FLASHW_TRAY As Short = 2
	
	Private Declare Function LoadLibrary Lib "kernel32"  Alias "LoadLibraryA"(ByVal lpLibFileName As String) As Integer
	
	Private Declare Function GetProcAddress Lib "kernel32" (ByVal hModule As Integer, ByVal lpProcName As String) As Integer
	
	Private Declare Function FreeLibrary Lib "kernel32" (ByVal hLibModule As Integer) As Integer
	
	'UPGRADE_WARNING: Structure FLASHWINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function FlashWindowEx Lib "user32" (ByRef FWInfo As FLASHWINFO) As Boolean
	'End Window flashing
	
	'UPGRADE_WARNING: Form event TournamentResults.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub TournamentResults_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'UPGRADE_ISSUE: Form method TournamentResults.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Me.Print(TheTournamentResults)
		'UPGRADE_ISSUE: Form property TournamentResults.Image was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = Me.Image
		
	End Sub
	
	Private Sub TournamentResults_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim SizeCheck() As String
		SizeCheck = Split(TheTournamentResults, vbCr)
		
		If VB.Right(SizeCheck(0), 5) = "Final" Then
			Me.Width = VB6.TwipsToPixelsX(6660)
			OKButton.Left = 352
		End If
		
		Me.Height = VB6.TwipsToPixelsY(((UBound(SizeCheck) + 1) * 13 + 80) * VB6.TwipsPerPixelY)
		OKButton.Top = (UBound(SizeCheck) + 1) * 13 + 20
		
		Dim YesOrNo As Boolean
		If MainWindow.WindowState = 1 Then
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(7, YesOrNo, 4500) 'Window State MainWindow
			If YesOrNo Then MainWindow.WindowState = System.Windows.Forms.FormWindowState.Maximized Else MainWindow.WindowState = System.Windows.Forms.FormWindowState.Normal
			FlashWindow((MainWindow.Handle.ToInt32))
		End If
		
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		Me.Close()
	End Sub
	
	'More Window Flashing
	Private Sub FlashWindow(ByRef hwnd As Integer, Optional ByRef NumberOfFlashes As Short = 5)
		'***************************************************
		'Purpose: Flashes a Window in the taskbar in order to notify
		'a user of an event within a program
		
		'Parameters: Hwnd=hwnd of frm to flash
		'NumberofFlashes = Number of times to
		'flash
		
		'Notes: WINDOWS 98 OR 2000 is REQUIRED
		
		'Uses FlashWindowEx API, which  substitutes
		'for bringing you window to the foreground
		'obtrusively (e.g., on startup or when siginficant
		'event occurs in your program) Windows 98/2000 no
		'longer permits this
		
		'Example:
		
		'FlashWindow me.hwnd
		
		'***************************************************
		'Prevent Errors by checking if
		'the API function is available on the
		'Current OS
		
		If Not APIFunctionPresent("FlashWindowEx", "user32") Then Exit Sub
		
		Dim bRet As Boolean
		Dim udtFWInfo As FLASHWINFO
		
		With udtFWInfo
			.cbSize = 20
			.hwnd = hwnd
			.dwflags = FLASHW_TRAY
			.uCount = NumberOfFlashes 'flash window 5 times
			.dwTimeout = 0
		End With
		
		bRet = FlashWindowEx(udtFWInfo)
	End Sub
	
	Private Function APIFunctionPresent(ByVal FunctionName As String, ByVal DllName As String) As Boolean
		
		'USAGE:
		'Dim bAvail as boolean
		'bAvail = APIFunctionPresent("GetDiskFreeSpaceExA", "kernel32")
		
		Dim lHandle As Integer
		Dim lAddr As Integer
		
		lHandle = LoadLibrary(DllName)
		If lHandle <> 0 Then
			lAddr = GetProcAddress(lHandle, FunctionName)
			FreeLibrary(lHandle)
		End If
		
		APIFunctionPresent = (lAddr <> 0)
		
	End Function
	
	'End More Window Flashing
End Class