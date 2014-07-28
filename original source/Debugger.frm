VERSION 5.00
Begin VB.Form DebuggingWindow 
   AutoRedraw      =   -1  'True
   BackColor       =   &H00DBE9CF&
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Debug"
   ClientHeight    =   6240
   ClientLeft      =   5040
   ClientTop       =   435
   ClientWidth     =   2895
   Icon            =   "Debugger.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   416
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   193
   Begin VB.CommandButton TerminateDebugging 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Terminate"
      Height          =   255
      Left            =   1560
      Style           =   1  'Graphical
      TabIndex        =   3
      Top             =   5880
      Width           =   1335
   End
   Begin VB.PictureBox Ints 
      AutoRedraw      =   -1  'True
      BackColor       =   &H00BCC9B6&
      BorderStyle     =   0  'None
      Height          =   2415
      Left            =   1560
      ScaleHeight     =   2415
      ScaleWidth      =   1335
      TabIndex        =   4
      Top             =   2925
      Width           =   1335
   End
   Begin VB.CommandButton ChrononStep 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Chronon"
      Height          =   375
      Left            =   1560
      MaskColor       =   &H00FFFFFF&
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   5400
      Width           =   1335
   End
   Begin VB.CommandButton StopDebugging 
      BackColor       =   &H00E4D2B4&
      Cancel          =   -1  'True
      Caption         =   "Stop Debugging"
      Height          =   255
      Left            =   120
      MaskColor       =   &H00FFFFFF&
      Style           =   1  'Graphical
      TabIndex        =   2
      TabStop         =   0   'False
      Top             =   5880
      Width           =   1335
   End
   Begin VB.CommandButton Step 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Step"
      Default         =   -1  'True
      Height          =   375
      Left            =   120
      MaskColor       =   &H00FFC0C0&
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   5400
      Width           =   1335
   End
End
Attribute VB_Name = "DebuggingWindow"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit
Public DebuggingRes As Byte
Public Xpos As Integer
Public DebugMsg As String

Private Sub Form_Load()

If Xpos = 0 Then Get 7, 9000, Xpos
DebuggingWindow.Left = Xpos

End Sub

Private Sub Form_Unload(Cancel As Integer)

If DebuggingWindow.Left <> Xpos Then
    Xpos = DebuggingWindow.Left
    Put 7, 9000, Xpos
End If

If MainWindow.BattleHaltButton.Caption = "Halt" Then    'If Battle is running then
    DebuggingRes = 2
Else                            'If Battle is not running
    MainWindow.TurnOfTheDebugger
End If

End Sub

'step = 0
'chronon = 1
'stopdebug = 2
'terminatebat = 3

Private Sub Step_Click()
DebuggingRes = 0
'Unload Me
End Sub

Private Sub ChrononStep_Click()
DebuggingRes = 1
'Unload Me
End Sub

Private Sub StopDebugging_Click()
Unload Me
End Sub

'Private Sub TerminateBattle_Click()
'DebuggingRes = 3
'Unload Me
'End Sub
Private Sub TerminateDebugging_Click()
MainWindow.InactivateDebug.Checked = True
Unload Me
End Sub
