Attribute VB_Name = "WinHelpStuff"
Option Explicit

' SHELLEXECUTE API      -       To lauch help and tutorial
Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" _
     (ByVal hwnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal _
     lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long
Const SW_SHOWNORMAL As Long = 1
Const SW_SHOWMAXIMIZED As Long = 3

Public Sub ShowHelp()
ShellExecute 0&, vbNullString, App.Path & "\" & App.HelpFile, vbNullString, vbNullString, SW_SHOWMAXIMIZED
End Sub

Public Sub ShowTutorial()
ShellExecute 0&, vbNullString, App.Path & "\Tutorial.htm", vbNullString, vbNullString, SW_SHOWNORMAL
End Sub
