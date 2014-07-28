Option Strict Off
Option Explicit On
Module WinHelpStuff
	
	' SHELLEXECUTE API      -       To lauch help and tutorial
	Private Declare Function ShellExecute Lib "shell32.dll"  Alias "ShellExecuteA"(ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer
	Const SW_SHOWNORMAL As Integer = 1
	Const SW_SHOWMAXIMIZED As Integer = 3
	
	Public Sub ShowHelp()
		'UPGRADE_ISSUE: App property App.HelpFile was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		ShellExecute(0, vbNullString, My.Application.Info.DirectoryPath & "\" & App.HelpFile, vbNullString, vbNullString, SW_SHOWMAXIMIZED)
	End Sub
	
	Public Sub ShowTutorial()
		ShellExecute(0, vbNullString, My.Application.Info.DirectoryPath & "\Tutorial.htm", vbNullString, vbNullString, SW_SHOWNORMAL)
	End Sub
End Module