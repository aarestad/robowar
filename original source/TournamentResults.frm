VERSION 5.00
Begin VB.Form TournamentResults 
   AutoRedraw      =   -1  'True
   BackColor       =   &H00D0C8B5&
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Tournament Results"
   ClientHeight    =   5475
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   3570
   Icon            =   "TournamentResults.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   365
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   238
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton OKButton 
      BackColor       =   &H00CA9D86&
      Cancel          =   -1  'True
      Caption         =   "OK"
      Default         =   -1  'True
      Height          =   375
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   5040
      Width           =   1215
   End
End
Attribute VB_Name = "TournamentResults"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public TheTournamentResults As String

'Window flashing
Private Type FLASHWINFO
  cbSize As Long
  hwnd As Long
  dwflags As Long
  uCount As Long
  dwTimeout As Long
End Type

Private Const FLASHW_TRAY = 2

Private Declare Function LoadLibrary Lib "kernel32" _
  Alias "LoadLibraryA" (ByVal lpLibFileName As String) As Long

Private Declare Function GetProcAddress Lib "kernel32" _
  (ByVal hModule As Long, ByVal lpProcName As String) As Long

Private Declare Function FreeLibrary Lib "kernel32" _
  (ByVal hLibModule As Long) As Long

Private Declare Function FlashWindowEx Lib "user32" _
   (FWInfo As FLASHWINFO) As Boolean
'End Window flashing

Private Sub Form_Activate()

Me.Print TheTournamentResults
Me.Picture = Me.Image

End Sub

Private Sub Form_Load()
Dim SizeCheck() As String
SizeCheck = Split(TheTournamentResults, vbCr)

If Right$(SizeCheck(0), 5) = "Final" Then
    Me.Width = 6660
    OKButton.Left = 352
End If

Me.Height = ((UBound(SizeCheck) + 1) * 13 + 80) * Screen.TwipsPerPixelY
OKButton.Top = (UBound(SizeCheck) + 1) * 13 + 20

If MainWindow.WindowState = 1 Then
    Dim YesOrNo As Boolean
    Get 7, 4500, YesOrNo                       'Window State MainWindow
    If YesOrNo Then MainWindow.WindowState = 2 Else MainWindow.WindowState = 0
    FlashWindow (MainWindow.hwnd)
End If

End Sub

Private Sub OKButton_Click()
Unload Me
End Sub

'More Window Flashing
Private Sub FlashWindow(hwnd As Long, _
  Optional NumberOfFlashes As Integer = 5)
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

If Not APIFunctionPresent("FlashWindowEx", "user32") _
   Then Exit Sub

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

Private Function APIFunctionPresent(ByVal FunctionName _
   As String, ByVal DllName As String) As Boolean

'USAGE:
'Dim bAvail as boolean
'bAvail = APIFunctionPresent("GetDiskFreeSpaceExA", "kernel32")

    Dim lHandle As Long
    Dim lAddr  As Long

    lHandle = LoadLibrary(DllName)
    If lHandle <> 0 Then
        lAddr = GetProcAddress(lHandle, FunctionName)
        FreeLibrary lHandle
    End If
    
    APIFunctionPresent = (lAddr <> 0)

End Function

'End More Window Flashing


