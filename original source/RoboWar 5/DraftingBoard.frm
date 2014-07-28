VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "Comdlg32.ocx"
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Begin VB.Form DraftingBoard 
   BackColor       =   &H00A76B43&
   Caption         =   "RoboWar 5 - Drafting Board"
   ClientHeight    =   8550
   ClientLeft      =   60
   ClientTop       =   750
   ClientWidth     =   11880
   FillColor       =   &H00FFFFFF&
   ForeColor       =   &H00FFFFC0&
   Icon            =   "DraftingBoard.frx":0000
   LinkTopic       =   "Form1"
   MinButton       =   0   'False
   ScaleHeight     =   570
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   792
   ShowInTaskbar   =   0   'False
   WindowState     =   2  'Maximized
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   8160
      Top             =   1920
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton CancelButton 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Cancel"
      Height          =   495
      Left            =   7920
      Style           =   1  'Graphical
      TabIndex        =   5
      TabStop         =   0   'False
      Top             =   4320
      Width           =   855
   End
   Begin VB.CommandButton compilebutton 
      BackColor       =   &H00DBC284&
      Caption         =   "Compile"
      Height          =   495
      Left            =   7920
      Style           =   1  'Graphical
      TabIndex        =   4
      TabStop         =   0   'False
      Top             =   3720
      Width           =   855
   End
   Begin VB.CommandButton compileandclose 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Compile and Close"
      Height          =   495
      Left            =   7920
      Style           =   1  'Graphical
      TabIndex        =   3
      TabStop         =   0   'False
      Top             =   4920
      Width           =   855
   End
   Begin RichTextLib.RichTextBox RobotCode 
      Height          =   7725
      Left            =   120
      TabIndex        =   2
      TabStop         =   0   'False
      Top             =   720
      Width           =   7695
      _ExtentX        =   13573
      _ExtentY        =   13626
      _Version        =   393217
      Enabled         =   -1  'True
      ScrollBars      =   2
      RightMargin     =   490
      TextRTF         =   $"DraftingBoard.frx":0E42
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin RichTextLib.RichTextBox MachineCodeText 
      Height          =   7740
      Left            =   9240
      TabIndex        =   7
      TabStop         =   0   'False
      Top             =   720
      Width           =   2385
      _ExtentX        =   4207
      _ExtentY        =   13653
      _Version        =   393217
      BackColor       =   13626776
      Enabled         =   -1  'True
      ReadOnly        =   -1  'True
      ScrollBars      =   2
      RightMargin     =   160
      TextRTF         =   $"DraftingBoard.frx":0EC4
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin VB.Label NoErrors 
      BackStyle       =   0  'Transparent
      Caption         =   "No syntax errors where detected."
      ForeColor       =   &H0000C000&
      Height          =   495
      Left            =   7920
      TabIndex        =   9
      Top             =   3120
      Width           =   1215
      Visible         =   0   'False
   End
   Begin VB.Label Label4 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00000000&
      Height          =   255
      Left            =   7920
      TabIndex        =   8
      Top             =   1200
      Width           =   1335
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "Label3"
      ForeColor       =   &H00000000&
      Height          =   255
      Left            =   7920
      TabIndex        =   6
      Top             =   960
      Width           =   975
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "Code Leight"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   615
      Left            =   7920
      TabIndex        =   1
      Top             =   720
      Width           =   1095
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "Robot Code:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   18
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   2175
   End
   Begin VB.Menu File 
      Caption         =   "File"
      Begin VB.Menu Print 
         Caption         =   "Print"
         Shortcut        =   ^P
      End
      Begin VB.Menu Sep0 
         Caption         =   "-"
      End
      Begin VB.Menu CloseThisWindow 
         Caption         =   "Close and Compile"
         Shortcut        =   ^W
      End
   End
   Begin VB.Menu Edit 
      Caption         =   "Edit"
      Begin VB.Menu Undo 
         Caption         =   "Undo"
      End
      Begin VB.Menu Sep1 
         Caption         =   "-"
      End
      Begin VB.Menu Cut 
         Caption         =   "Cut"
      End
      Begin VB.Menu Copy 
         Caption         =   "Copy"
      End
      Begin VB.Menu Paste 
         Caption         =   "Paste"
      End
      Begin VB.Menu SelectAll 
         Caption         =   "Select All"
      End
      Begin VB.Menu Sep3 
         Caption         =   "-"
      End
      Begin VB.Menu Find 
         Caption         =   "Find"
         Shortcut        =   ^F
      End
      Begin VB.Menu FindNext 
         Caption         =   "Find Next"
         Shortcut        =   ^G
      End
      Begin VB.Menu Sep2 
         Caption         =   "-"
      End
      Begin VB.Menu FindInstruction 
         Caption         =   "Find Instruction"
         Shortcut        =   ^H
      End
      Begin VB.Menu CountInst 
         Caption         =   "Count Instructions"
         Shortcut        =   ^I
      End
      Begin VB.Menu Sep5 
         Caption         =   "-"
      End
      Begin VB.Menu CompileMenu 
         Caption         =   "Compile"
         Shortcut        =   ^K
      End
   End
   Begin VB.Menu View 
      Caption         =   "View"
      Begin VB.Menu Arena 
         Caption         =   "Arena"
         Shortcut        =   {F1}
      End
      Begin VB.Menu DraftingBoard 
         Caption         =   "Drafting Board"
         Checked         =   -1  'True
         Shortcut        =   {F2}
      End
      Begin VB.Menu HardwareStore 
         Caption         =   "Hardware Store"
         Shortcut        =   {F3}
      End
      Begin VB.Menu IconFactory 
         Caption         =   "Icon Factory"
         Shortcut        =   {F4}
      End
      Begin VB.Menu RecordingStudio 
         Caption         =   "Recording Studio"
         Shortcut        =   {F5}
      End
   End
   Begin VB.Menu MacroMenu 
      Caption         =   "Macros"
      Begin VB.Menu AimLoop 
         Caption         =   "Insert Aim Loop"
         Shortcut        =   ^T
      End
      Begin VB.Menu LookRoutine 
         Caption         =   "Insert Look Routine"
      End
      Begin VB.Menu CustomAimLoop 
         Caption         =   "Insert Custom Aim Loop"
      End
      Begin VB.Menu AimLoopAnimated 
         Caption         =   "Insert Animated Aim Loop"
      End
      Begin VB.Menu SetEdgeInterupsLimitsto 
         Caption         =   "Set Edge Interups Limits to"
         Shortcut        =   ^E
      End
      Begin VB.Menu DebuggingDeadloop 
         Caption         =   "Debugging - Insert Dead Loop"
         Shortcut        =   ^D
      End
      Begin VB.Menu InsertPrint 
         Caption         =   "Debugging - Insert Print Sequence"
         Shortcut        =   ^U
      End
      Begin VB.Menu DebuggingAlwaysSameXY 
         Caption         =   "Debugging - Always start at x,y"
      End
      Begin VB.Menu DopplerForBullets 
         Caption         =   "Doppler for Bullets"
         Shortcut        =   ^B
      End
      Begin VB.Menu DopplerForStunners 
         Caption         =   "Doppler for Stunners"
         Shortcut        =   ^S
      End
      Begin VB.Menu ResetLook 
         Caption         =   "Reset Look"
         Shortcut        =   ^L
      End
      Begin VB.Menu Histoy 
         Caption         =   "Histoy"
         Begin VB.Menu SetHistory 
            Caption         =   "Set History to Kills (last battle)"
            Index           =   2
         End
         Begin VB.Menu SetHistory 
            Caption         =   "Set History to Kills (total)"
            Index           =   3
         End
         Begin VB.Menu SetHistory 
            Caption         =   "Set History to Survival (last battle)"
            Index           =   4
         End
         Begin VB.Menu SetHistory 
            Caption         =   "Set History to Survival (total)"
            Index           =   5
         End
         Begin VB.Menu SetHistory 
            Caption         =   "Set History to TimeOut"
            Index           =   6
         End
         Begin VB.Menu SetHistory 
            Caption         =   "Set History to TeamMates (last battle)"
            Index           =   7
         End
         Begin VB.Menu SetHistory 
            Caption         =   "Set History to TeamMates (total)"
            Index           =   8
         End
         Begin VB.Menu SetHistory 
            Caption         =   "Set History to Damage"
            Index           =   9
         End
         Begin VB.Menu SetHistory 
            Caption         =   "Set History to Chronons (last battle)"
            Index           =   10
         End
         Begin VB.Menu SetHistory 
            Caption         =   "Set History to Chronons (total)"
            Index           =   11
         End
         Begin VB.Menu SetHistoryBattles 
            Caption         =   "Set History to Battles"
         End
      End
      Begin VB.Menu Separator3 
         Caption         =   "-"
      End
      Begin VB.Menu Macro 
         Caption         =   "Macro"
         Index           =   0
         Shortcut        =   {F6}
         Visible         =   0   'False
      End
      Begin VB.Menu Macro 
         Caption         =   "Macro"
         Index           =   1
         Shortcut        =   {F7}
         Visible         =   0   'False
      End
      Begin VB.Menu Macro 
         Caption         =   "Macro"
         Index           =   2
         Shortcut        =   {F8}
         Visible         =   0   'False
      End
      Begin VB.Menu Macro 
         Caption         =   "Macro"
         Index           =   3
         Shortcut        =   {F9}
         Visible         =   0   'False
      End
      Begin VB.Menu Macro 
         Caption         =   "Macro"
         Index           =   4
         Shortcut        =   {F11}
         Visible         =   0   'False
      End
      Begin VB.Menu Macro 
         Caption         =   "Macro"
         Index           =   5
         Shortcut        =   {F12}
         Visible         =   0   'False
      End
   End
   Begin VB.Menu RobotSettings 
      Caption         =   "Robot Settings"
      Begin VB.Menu RoboTalkRobot 
         Caption         =   "RoboTalk Robot"
      End
      Begin VB.Menu CRobot 
         Caption         =   "C Robot"
      End
      Begin VB.Menu Separator25 
         Caption         =   "-"
      End
      Begin VB.Menu RecompileLock 
         Caption         =   "Recompile Lock"
      End
   End
   Begin VB.Menu Preference 
      Caption         =   "Preference"
      Begin VB.Menu Size 
         Caption         =   "Text Font and Size"
      End
      Begin VB.Menu defaultfont 
         Caption         =   "Reset font to default"
      End
      Begin VB.Menu Separator20 
         Caption         =   "-"
      End
      Begin VB.Menu SyntaxColoringMenu 
         Caption         =   "Syntax Coloring"
         Checked         =   -1  'True
      End
      Begin VB.Menu AutoCompile 
         Caption         =   "Auto Compile"
         Checked         =   -1  'True
      End
      Begin VB.Menu PrintLineNumbers 
         Caption         =   "Print Line Numbers"
      End
      Begin VB.Menu Separator10 
         Caption         =   "-"
      End
      Begin VB.Menu ResetCursorPosition 
         Caption         =   "Reset Cursor Position"
      End
   End
   Begin VB.Menu Beginners 
      Caption         =   "Beginners"
      Begin VB.Menu AboutBeginners 
         Caption         =   "About This Menu"
      End
      Begin VB.Menu Separator4 
         Caption         =   "-"
      End
      Begin VB.Menu BeginnersMain 
         Caption         =   "Insert Main Loop (start with this)"
      End
      Begin VB.Menu BeginnersMove 
         Caption         =   "Start moving"
      End
      Begin VB.Menu BeginnersWalls 
         Caption         =   "Turn when too near walls"
      End
      Begin VB.Menu BeginnersRotateTurret 
         Caption         =   "Rotate Turret"
      End
      Begin VB.Menu BeginnersRotateFast 
         Caption         =   "Rotate Turret fast"
      End
      Begin VB.Menu BeginnersRange 
         Caption         =   "Check for opponents to shoot at"
      End
      Begin VB.Menu BeginnersCollision 
         Caption         =   "Insert Collision Checking and Loop"
      End
      Begin VB.Menu Separator2 
         Caption         =   "-"
      End
      Begin VB.Menu HelpMenu 
         Caption         =   "Help"
      End
      Begin VB.Menu Tutorial 
         Caption         =   "Tutorial"
      End
   End
End
Attribute VB_Name = "DraftingBoard"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

' AND YET MORE DECLARATIONS
Private Declare Function LockWindowUpdate Lib "user32" (ByVal hwnd As Long) As Long
Private Declare Function RoboTranslate Lib "roboc.dll" (ByVal RoboTalkCodePtr As String, ByVal cCodePtr As String) As Long
Const EM_LINEINDEX = &HBB
Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Any) As Long

'From Arena, when robot bugs
Public GotoInstNr As Integer

'Doubleclicking
Dim HasDCl As Boolean

'Interface things
Dim sFind As String
Dim limit1 As Integer
Dim limit2 As Integer
Dim TheXYPos As Integer

'Syntax Coloring
Dim SyntaxColoringCache As Boolean
Const CommentRed = 0     'Fungerar
Const CommentBlue = 70
Const CommentGreen = 140
Const LabelRed = 0
Const LabelBlue = 150
Const LabelGreen = 25

'Instructions
Const INSTRUCTIONLIMIT = 5000
Const iUNKOWN = -32768

'Robot File things
Dim HasCanceled As Boolean
Dim PathToRobot As String
Dim IsCRobot As Boolean

'Robot File things - New File System
Dim Cstart As Long
Dim MStart As Long
Const MCrec = 112
Const Crec = 116
Const CPosrec = 28
Const RLock = 140
Const CRobotRec = 141
Const DroneRec = 16

Private Sub AboutBeginners_Click()
Dim StoreSelStart As Long
StoreSelStart = RobotCode.SelStart + Len("# A B O U T   T H E   B E G I N N E R S   M E N U" & vbCr _
    & "# In beginners menu you can select different things that" & vbCr _
    & "# your robot shall do. With help of the commands" & vbCr _
    & "# in the beginners menu, you can create your own robot very fast." & vbCr _
    & "# Then you can go back to the manual and find ways to improve the bot." & vbCr & vbCr)
RobotCode.Text = "# A B O U T   T H E   B E G I N N E R S   M E N U" & vbCr _
    & "# In beginners menu you can select different things that" & vbCr _
    & "# your robot shall do. With help of the commands" & vbCr _
    & "# in the beginners menu, you can create your own robot very fast." & vbCr _
    & "# Then you can go back to the manual and find ways to improve the bot." & vbCr & vbCr _
    & RobotCode.Text
 RobotCode.SelStart = StoreSelStart
End Sub

Private Sub AimLoop_Click()
Dim NumberOfDegrees As Variant
Dim AimLoop As String
Dim AimVal As Integer
Dim res As Integer

redo:
NumberOfDegrees = InputBox("Note: as soon as I find the source of Justin Blachards" & vbLf & "Aim Loop Generator, I'll built it in here." & vbLf & "Anyway, " & vbLf & vbLf & "How many degrees between each check?", "Aim Loop", 10)
If NumberOfDegrees = "" Then GoTo AbortCreation
NumberOfDegrees = Val(NumberOfDegrees)

If NumberOfDegrees > 359 Or NumberOfDegrees < 1 Then
    If MsgBox("How many degrees between each check must range from 1 to 359", vbRetryCancel + vbCritical, "Aimloop Error") = vbCancel Then GoTo AbortCreation
    GoTo redo
End If

Do While AimVal < 30
    AimLoop = AimLoop & AimVal & " aim' store" & Chr(10)
    AimLoop = AimLoop & (AimVal + 30) & " aim' store" & Chr(10)
    AimLoop = AimLoop & (AimVal + 60) & " aim' store" & Chr(10)
    AimLoop = AimLoop & (AimVal + 90) & " aim' store" & Chr(10)
    AimLoop = AimLoop & (AimVal + 120) & " aim' store" & Chr(10)
    AimLoop = AimLoop & (AimVal + 150) & " aim' store" & Chr(10)
    AimLoop = AimLoop & (AimVal + 180) & " aim' store" & Chr(10)
    AimLoop = AimLoop & (AimVal + 210) & " aim' store" & Chr(10)
    AimLoop = AimLoop & (AimVal + 240) & " aim' store" & Chr(10)
    AimLoop = AimLoop & (AimVal + 270) & " aim' store" & Chr(10)
    AimLoop = AimLoop & (AimVal + 300) & " aim' store" & Chr(10)
    AimLoop = AimLoop & (AimVal + 330) & " aim' store" & Chr(10)
    AimVal = AimVal + NumberOfDegrees
Loop

res = MsgBox(AimLoop, vbYesNoCancel, "Is this ok?")
If res = vbCancel Then GoTo AbortCreation

Dim insert As String
insert = AimLoop

AimLoop = ""
AimVal = 0

If res = vbNo Then GoTo redo

RobotCode.SelRTF = insert

AbortCreation:
RobotCode.SelStart = RobotCode.SelStart
RobotCode.SetFocus
End Sub

Private Sub AimLoopAnimated_Click()
Dim NumberOfDegrees As Variant
Dim AimLoop As String
Dim AimVal As Integer
Dim res As Integer
Dim IconsPerChronon As Variant

redo:
NumberOfDegrees = InputBox("This creates an aim loop that switches" & vbLf & "from icon 2 to 9." & vbLf & vbLf & "How many degrees between each check?", "Animated Aim Loop", 10)
If NumberOfDegrees = "" Then GoTo AbortCreation
NumberOfDegrees = CInt(NumberOfDegrees)

redospeed:
IconsPerChronon = InputBox("A new icon will be viewed every x chronon." & vbLf & "Please specify x" & vbLf & "(= speed of the animation, lower is faster)", "Aim Loop", 4)
If IconsPerChronon = "" Then GoTo AbortCreation
IconsPerChronon = Val(IconsPerChronon)
If IconsPerChronon > 5 Or IconsPerChronon < 1 Then
    If MsgBox("The speed must range from 1 to 5", vbRetryCancel + vbCritical, "Icon Error") = vbCancel Then GoTo AbortCreation
    GoTo redospeed
End If

If NumberOfDegrees = 0 Then GoTo AbortCreation 'Prevent eternal loop = Freezing

Dim procposition As Integer
Dim iconnumber As Integer
Dim ProSpeed As Integer
Select Case MainWindow.SelectedRobot
    Case 1
        ProSpeed = MainWindow.Robot1ProSpeed
    Case 2
        ProSpeed = MainWindow.Robot2ProSpeed
    Case 3
        ProSpeed = MainWindow.Robot3ProSpeed
    Case 4
        ProSpeed = MainWindow.Robot4ProSpeed
    Case 5
        ProSpeed = MainWindow.Robot5ProSpeed
    Case 6
        ProSpeed = MainWindow.Robot6ProSpeed
End Select

iconnumber = 2
Do While AimVal < 180
    procposition = procposition + 1
    
    If procposition >= ProSpeed * IconsPerChronon Then
        AimLoop = AimLoop & AimVal & vbCr & " icon" & iconnumber & vbCr
        procposition = 0: iconnumber = iconnumber + 1
        If iconnumber >= 10 Then iconnumber = 2
    Else
        AimLoop = AimLoop & AimVal
    End If

    procposition = procposition + 1
    If procposition >= ProSpeed * IconsPerChronon Then
        AimLoop = AimLoop & " aim'" & vbCr & " icon" & iconnumber & vbCr
        procposition = 0: iconnumber = iconnumber + 1
        If iconnumber >= 10 Then iconnumber = 2
    Else
        AimLoop = AimLoop & " aim'"
    End If

    procposition = procposition + 1
    If procposition >= ProSpeed * IconsPerChronon Then
        AimLoop = AimLoop & " store " & vbCr & " icon" & iconnumber & vbCr
        procposition = 0: iconnumber = iconnumber + 1
        If iconnumber >= 10 Then iconnumber = 2
    Else
        AimLoop = AimLoop & " store "
    End If

'''''''
    AimVal = AimVal + 180
    procposition = procposition + 1
    
    If procposition >= ProSpeed * IconsPerChronon Then
        AimLoop = AimLoop & AimVal & vbCr & " icon" & iconnumber & vbCr
        procposition = 0: iconnumber = iconnumber + 1
        If iconnumber >= 10 Then iconnumber = 2
    Else
        AimLoop = AimLoop & AimVal
    End If

    procposition = procposition + 1
    If procposition >= ProSpeed * IconsPerChronon Then
        AimLoop = AimLoop & " aim'" & vbCr & " icon" & iconnumber & vbCr
        procposition = 0: iconnumber = iconnumber + 1
        If iconnumber >= 10 Then iconnumber = 2
    Else
        AimLoop = AimLoop & " aim'"
    End If

    procposition = procposition + 1
    If procposition >= ProSpeed * IconsPerChronon Then
        AimLoop = AimLoop & " store " & vbCr & " icon" & iconnumber & vbCr
        procposition = 0: iconnumber = iconnumber + 1
        If iconnumber >= 10 Then iconnumber = 2
    Else
        AimLoop = AimLoop & " store "
    End If
    AimVal = AimVal - 180
'''''''
    AimVal = AimVal + NumberOfDegrees
Loop
'''' Check some extra degrees to complete the animation
Randomize
Do While iconnumber < 10
    procposition = procposition + 1
    AimVal = Int((359 + 1) * Rnd)
    If procposition >= ProSpeed * IconsPerChronon Then
        AimLoop = AimLoop & AimVal & vbCr & " icon" & iconnumber & vbCr
        procposition = 0: iconnumber = iconnumber + 1
    Else
        AimLoop = AimLoop & AimVal
    End If
    procposition = procposition + 1
    If procposition >= ProSpeed * IconsPerChronon Then
        AimLoop = AimLoop & " aim'" & vbCr & " icon" & iconnumber & vbCr
        procposition = 0: iconnumber = iconnumber + 1
    Else
        AimLoop = AimLoop & " aim'"
    End If
    procposition = procposition + 1
    If procposition >= ProSpeed * IconsPerChronon Then
        AimLoop = AimLoop & " store " & vbCr & " icon" & iconnumber & vbCr
        procposition = 0: iconnumber = iconnumber + 1
    Else
        AimLoop = AimLoop & " store "
    End If
Loop
'''''
res = MsgBox(AimLoop, vbYesNoCancel, "Is this ok?")
If res = vbCancel Then GoTo AbortCreation
Dim insert As String
insert = AimLoop
AimLoop = ""
AimVal = 0
If res = vbNo Then GoTo redo
RobotCode.SelRTF = insert
AbortCreation:
RobotCode.SelStart = RobotCode.SelStart
RobotCode.SetFocus
End Sub

Private Sub Arena_Click()
Unload Me
End Sub

Private Sub AutoCompile_Click()
    Dim YesOrNo As Boolean
    If AutoCompile.Checked Then
        AutoCompile.Checked = False
        YesOrNo = False
    Else
        AutoCompile.Checked = True
        YesOrNo = True
    End If
    
    Put 7, 8000, YesOrNo
End Sub

Private Sub BeginnersCollision_Click()
Dim counter As Integer

counter = InStr(RobotCode.Text, "MainLoop:")

If counter Then
    RobotCode.SelStart = counter + 9
    RobotCode.SelRTF = "collision kill if" & vbCr

    If InStr(RobotCode.Text, "Kill:") = 0 Then
        RobotCode.SelStart = Len(RobotCode.Text)
        RobotCode.SelRTF = vbCr & vbCr & _
        "Kill:" & vbCr & _
        "aim 45 + aim' store" & vbCr & _
        "range strongshot if" & vbCr & _
        "collision not goback if" & vbCr & _
        "kill jump"
    End If
    If InStr(RobotCode.Text, "GoBack:") = 0 Then
        RobotCode.SelStart = Len(RobotCode.Text)
        RobotCode.SelRTF = vbCr & vbCr & _
        "GoBack:" & vbCr & _
        "drop" & vbCr & _
        "return"
    End If
    If InStr(RobotCode.Text, "StrongShot:") = 0 Then
        RobotCode.SelStart = Len(RobotCode.Text)
        RobotCode.SelRTF = vbCr & vbCr & _
        "StrongShot:" & vbCr & _
        "100 fire' store" & vbCr & _
        "50 fire' store" & vbCr & _
        "return"
    End If

    RobotCode.SelStart = counter + 9 + Len("collision kill if" & vbCr)
End If

End Sub

Private Sub BeginnersMain_Click()
If InStr(RobotCode.Text, "MainLoop:") Then
    MsgBox ("You already have a mainloop." & vbCr & "If you would like to create a new loop, Then type in:" & vbCr & vbCr & "MyLoopsName:" & vbCr & "#Put the things you want you loop to do here" & vbCr & "MyLoopsName Jump" & vbCr & vbCr & "at the bottom of the code.")
Else
    RobotCode.SelRTF = vbCr & "MainLoop:" & vbCr & vbCr & "mainloop jump" & vbTab & vbTab & "# Jumps back to the " & Chr(34) & "MainLoop" & Chr(34) & " label"
End If
End Sub

Private Sub BeginnersMove_Click()
Dim counter As Integer
counter = InStr(RobotCode.Text, "MainLoop:") - 1

If counter = -1 Then
    Dim RET As Long
    RET = RobotCode.SelStart
    RobotCode.SelStart = 0
    RobotCode.SelRTF = "3 speedx' store" & vbTab & vbTab & "# Set speed in x direction to 3" & vbCr & _
                       "3 speedy' store" & vbTab & vbTab & "# Set speed in y direction to 3" & vbCr
    RobotCode.SelStart = RET + Len("3 speedx' store" & vbTab & vbTab & "# Set speed in x direction to 3" & vbCr & "3 speedy' store" & vbTab & vbTab & "# Set speed in y direction to 3" & vbCr)
Else
    RobotCode.SelStart = counter
    RobotCode.SelRTF = vbCr & "3 speedx' store" & vbTab & vbTab & "# Set speed in x direction to 3" & vbCr & _
                       "3 speedy' store" & vbTab & vbTab & "# Set speed in y direction to 3" & vbCr & vbCr
    RobotCode.SelStart = counter + Len("3 speedx' store" & vbTab & vbTab & "# Set speed in x direction to 3" & vbCr & "3 speedy' store" & vbTab & vbTab & "# Set speed in y direction to 3" & vbCr)
End If

End Sub

Private Sub BeginnersRange_Click()
Dim counter As Integer

counter = InStr(RobotCode.Text, "MainLoop:")

If counter Then
    RobotCode.SelStart = counter + 9
    RobotCode.SelRTF = "range 0 > shoot if" & vbTab & vbTab & "# If Range is above zero then go to " & Chr(34) & "Shoot" & Chr(34) & vbCr
    
    If InStr(RobotCode.Text, "Shoot:") = 0 Then
        RobotCode.SelStart = Len(RobotCode.Text)
        RobotCode.SelRTF = vbCr & vbCr & "Shoot:" & vbCr & "energy fire' store" & vbTab & vbTab & "# Use all energy to shoot" & vbCr & "Return" & vbTab & vbTab & vbTab & "# Return to where we came from"
    End If

    RobotCode.SelStart = counter + 9 + Len("range 0 > shoot if" & vbTab & vbTab & "# If Range is above zero then go to " & Chr(34) & "Shoot" & Chr(34) & vbCr)
End If

End Sub

Private Sub BeginnersRotateFast_Click()
Dim counter As Integer
counter = InStr(RobotCode.Text, "MainLoop:")

If counter Then
    RobotCode.SelStart = counter + 9
    RobotCode.SelRTF = "aim 45 + aim' store" & vbTab & vbTab & "# Adds 45 degrees to the present aim angle" & vbCr
End If
End Sub

Private Sub BeginnersRotateTurret_Click()
Dim counter As Integer
counter = InStr(RobotCode.Text, "MainLoop:")

If counter Then
    RobotCode.SelStart = counter + 9
    RobotCode.SelRTF = "aim 9 + aim' store" & vbTab & vbTab & "# Adds 9 degrees to the present aim angle" & vbCr
End If
End Sub

Private Sub BeginnersWalls_Click()
Dim counter As Integer

counter = InStr(RobotCode.Text, "MainLoop:")

If counter Then
    RobotCode.SelStart = counter + 9
    RobotCode.SelRTF = _
    "x 275 > GoLeft if" & vbTab & vbTab & "# If x > 275 then jump to " & Chr(34) & "GoLeft" & Chr(34) & vbCr & _
    "x 25 < GoRight if" & vbTab & vbTab & "# If x < 25 then jump to " & Chr(34) & "GoRight" & Chr(34) & vbCr & _
    "y 275 > GoUp if" & vbTab & vbTab & "# If y > 275 then jump to " & Chr(34) & "GoUp" & Chr(34) & vbCr & _
    "y 25 < GoDown if" & vbTab & vbTab & "# If y < 25 then jump to " & Chr(34) & "GoDown" & Chr(34) & vbCr

    If InStr(RobotCode.Text, "GoLeft:") = 0 Then
        RobotCode.SelStart = Len(RobotCode.Text)
        RobotCode.SelRTF = vbCr & vbCr & "GoLeft:" & vbCr & "-4 speedx' store" & vbTab & vbTab & "# Set speed in x direction to -4" & vbCr & "Return" & vbTab & vbTab & vbTab & "# Return to where we came from"
    End If
    If InStr(RobotCode.Text, "GoRight:") = 0 Then
        RobotCode.SelStart = Len(RobotCode.Text)
        RobotCode.SelRTF = vbCr & vbCr & "GoRight:" & vbCr & "4 speedx' store" & vbTab & vbTab & "# Set speed in x direction to 4" & vbCr & "Return" & vbTab & vbTab & vbTab & "# Return to where we came from"
    End If
    If InStr(RobotCode.Text, "GoDown:") = 0 Then
        RobotCode.SelStart = Len(RobotCode.Text)
        RobotCode.SelRTF = vbCr & vbCr & "GoDown:" & vbCr & "4 speedy' store" & vbTab & vbTab & "# Set speed in y direction to 4" & vbCr & "Return" & vbTab & vbTab & vbTab & "# Return to where we came from"
    End If
    If InStr(RobotCode.Text, "GoUp:") = 0 Then
        RobotCode.SelStart = Len(RobotCode.Text)
        RobotCode.SelRTF = vbCr & vbCr & "GoUp:" & vbCr & "-4 speedy' store" & vbTab & vbTab & "# Set speed in y direction to -4" & vbCr & "Return" & vbTab & vbTab & vbTab & "# Return to where we came from"
    End If

    RobotCode.SelStart = counter + 9 + Len("x 275 > GoLeft if" & vbTab & vbTab & "# If x > 275 then jump to GoLeft" & vbCr & _
    "x 25 < GoRight if" & vbTab & vbTab & "# If x < 25 then jump to GoRight" & vbCr & _
    "y 275 > GoUp if" & vbTab & vbTab & "# If y > 275 then jump to GoUp" & vbCr & _
    "y 25 < GoDown if" & vbTab & vbTab & "# If y < 25 then jump to GoDown" & vbCr) + 8
End If

End Sub

Private Sub CloseThisWindow_Click()
Unload Me
End Sub

Private Sub CRobot_Click()
MsgBox "C-Robots are currently in Beta Stage", vbInformation, "C-Robots"

Open App.Path & "\miscdata\DraftPrefsC.cfg" For Input As 10
    If EOF(10) = False Then
        Dim ImputFont As Variant
        Input #10, ImputFont
        RobotCode.Font.Name = ImputFont
        Input #10, ImputFont
        RobotCode.Font.Size = ImputFont
        Input #10, ImputFont
        RobotCode.Font.Bold = CBool(ImputFont)
        Input #10, ImputFont
        RobotCode.Font.Italic = CBool(ImputFont)
        Input #10, ImputFont
        RobotCode.Font.Strikethrough = CBool(ImputFont)
        Input #10, ImputFont
        RobotCode.Font.Underline = CBool(ImputFont)
    End If
Close 10

InizCRobots
End Sub

Private Sub InizCRobots()
Open PathToRobot For Binary As #2
    Put #2, CRobotRec, CByte(1)
    CRobot.Checked = True
    IsCRobot = True
    RoboTalkRobot.Checked = False
Close 2

SyntaxColoringCache = False
SyntaxColoringMenu.Enabled = False
End Sub


Private Sub MachineCodeText_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyF1 Then Arena_Click  'Bugfix so it won't get the stupid idea to display help when F1 is pressed and the codetextbox in focus
        
End Sub

Private Sub RoboTalkRobot_Click()
Open PathToRobot For Binary As #1
    Put #1, CRobotRec, CByte(0)
    CRobot.Checked = False
    IsCRobot = False
    RoboTalkRobot.Checked = True
Close 1

Open App.Path & "\miscdata\DraftPrefs.cfg" For Input As 10
    If EOF(10) = False Then
        Dim ImputFont As Variant
        Input #10, ImputFont
        RobotCode.Font.Name = ImputFont
        Input #10, ImputFont
        RobotCode.Font.Size = ImputFont
        Input #10, ImputFont
        RobotCode.Font.Bold = CBool(ImputFont)
        Input #10, ImputFont
        RobotCode.Font.Italic = CBool(ImputFont)
        Input #10, ImputFont
        RobotCode.Font.Strikethrough = CBool(ImputFont)
        Input #10, ImputFont
        RobotCode.Font.Underline = CBool(ImputFont)
    End If
Close 10

SyntaxColoringCache = SyntaxColoringMenu.Checked
SyntaxColoringMenu.Enabled = True
End Sub

'Private Sub Command1_Click()
'Dim rcode As String
'rcode = RobotCode.Text
'Dim c As Integer
'
'
'    Dim Tiden As Double '!!!!--->Tidtagning
'    Tiden = Timer '!!!!--->Tidtagning
'
'For c = 0 To 100
'Compile (rcode)
'Next c
'
'    Tiden = Timer - Tiden
'    MsgBox (Tiden)
'    'Debug.Print Tiden '!!!!--->Tidtagning
'
'    'Me.BackColor = RGB(Int(255 * Rnd), Int(255 * Rnd), Int(255 * Rnd))
'End Sub

Private Sub RobotCode_KeyDown(KeyCode As Integer, Shift As Integer) ' THE ON THE FLY SYNTAX COLORING CODE
If SyntaxColoringCache Then

Dim PresenSLComment As Long
Dim PresentSL As Long
Dim GrapPart As String
Dim NextSpace As Long
Dim AntiSpace As Long

Select Case KeyCode
    Case vbKeyF1    'Bugfix so it won't get the stupid idea to display help when F1 is pressed and the codetextbox in focus
        Arena_Click
    Case 55    '{
        If Shift = 6 Then
            RobotCode.SelColor = RGB(CommentRed, CommentGreen, CommentBlue)
            GrapPart = RobotCode.Text
            PresentSL = RobotCode.SelStart
            
            If PresentSL <> 0 Then
                NextSpace = InStr(PresentSL, GrapPart, "}")
                AntiSpace = InStr(PresentSL, GrapPart, "{")
            Else
                NextSpace = InStr(GrapPart, "}")
                AntiSpace = InStr(GrapPart, "{")
            End If
            
            If (Not NextSpace > AntiSpace Or (AntiSpace = 0 And NextSpace <> 0)) And NextSpace > PresentSL + 1 Then
                LockWindowUpdate RobotCode.hwnd     'LOCKS!!
                
                If PresentSL <> 0 Then RobotCode.SelStart = PresentSL - 1 Else RobotCode.SelStart = PresentSL 'disk
                RobotCode.SelLength = NextSpace - PresentSL + 2 ' + 1
                RobotCode.SelColor = RGB(CommentRed, CommentGreen, CommentBlue) 'RÖR EJ!!!
                RobotCode.SelStart = PresentSL
                
                LockWindowUpdate 0                  'UNLOCKS!!
            End If
        End If
    Case 51     '#
        If Shift = 1 Then
            PresentSL = RobotCode.SelStart
            GrapPart = RobotCode.Text & vbCr
            If PresentSL <> 0 Then NextSpace = InStr(PresentSL, GrapPart, vbCr) - PresentSL Else NextSpace = InStr(GrapPart, vbCr) - PresentSL
            AntiSpace = InStr(PresentSL + 1, GrapPart, "#") - PresentSL     'To avoid coloring already colored things
            
            If NextSpace <= 1 Or AntiSpace = 1 Or RobotCode.SelLength <> 0 Then
                If RobotCode.SelColor <> RGB(CommentRed, CommentGreen, CommentBlue) Then RobotCode.SelColor = RGB(CommentRed, CommentGreen, CommentBlue) 'If we're inside a comment we don't need to do anything
            Else
                LockWindowUpdate RobotCode.hwnd         'LOCKS!!
                
                If PresentSL <> 0 Then RobotCode.SelStart = PresentSL - 1 Else RobotCode.SelStart = PresentSL 'disk
                RobotCode.SelLength = NextSpace + 1
                RobotCode.SelColor = RGB(CommentRed, CommentGreen, CommentBlue) 'If we're inside a comment we don't need to do anything
                RobotCode.SelStart = PresentSL
            
                LockWindowUpdate 0                      'UNLOCKS!!
            End If
        End If
    Case vbKeyReturn    'Return, cancels # comments '13
        If RobotCode.SelColor = vbBlack Then Exit Sub
        RobotCode.SelColor = vbBlack
    Case vbKeySpace Or KeyCode = vbKeyTab Or KeyCode = 188 '188 = , and ;
        If RobotCode.SelColor <> RGB(LabelRed, LabelGreen, LabelBlue) Then Exit Sub
        RobotCode.SelColor = vbBlack
    Case 190       ':
        If Shift = 1 Then
            If RobotCode.SelColor <> RGB(CommentRed, CommentGreen, CommentBlue) Then 'If we're inside a comment the label definition will be 'outcommented'
                GrapPart = StrReverse(RobotCode.Text)
                GrapPart = Replace09(GrapPart, vbLf, " ")
                GrapPart = Replace09(GrapPart, vbTab, " ")
                GrapPart = Replace09(GrapPart, ";", " ")
                GrapPart = Replace09(GrapPart, ",", " ")
                NextSpace = Len(GrapPart) - InStr(Len(GrapPart) - (RobotCode.SelStart - 1), GrapPart, " ") + 1
                PresentSL = RobotCode.SelStart
                
                LockWindowUpdate RobotCode.hwnd         'LOCKS!!
                
                If NextSpace < PresentSL Then
                    RobotCode.SelStart = NextSpace
                    RobotCode.SelLength = PresentSL - NextSpace
                Else    'If there are no deliminers this can only mean that the beginning of the code is the deliminer
                    RobotCode.SelStart = 0
                    RobotCode.SelLength = PresentSL
                End If
                If RobotCode.SelColor <> RGB(LabelRed, LabelGreen, LabelBlue) Then RobotCode.SelColor = RGB(LabelRed, LabelGreen, LabelBlue)
                
                RobotCode.SelStart = PresentSL
                
                LockWindowUpdate 0                      'UNLOCKS!!
            End If
        End If
    Case 48    '}
        If RobotCode.SelColor <> RGB(CommentRed, CommentGreen, CommentBlue) Then 'If this case we have to recolor the entire comment green
            GrapPart = StrReverse(RobotCode.Text)
            NextSpace = Len(GrapPart) - InStr(Len(GrapPart) - (RobotCode.SelStart - 1), GrapPart, "{") '+ 1
            AntiSpace = Len(GrapPart) - InStr(Len(GrapPart) - (RobotCode.SelStart - 1), GrapPart, "}")
            
            PresentSL = RobotCode.SelStart

            If (AntiSpace > NextSpace And AntiSpace <> Len(GrapPart)) Or NextSpace > PresentSL Then Exit Sub

            LockWindowUpdate RobotCode.hwnd         'LOCKS!!
            
            RobotCode.SelStart = NextSpace
            RobotCode.SelLength = PresentSL - NextSpace
            'If RobotCode.SelColor = RGB(CommentRed, CommentGreen, CommentBlue) Then MsgBox 4    'DEBUG'DEBUG'DEBUG'DEBUG'DEBUG
            RobotCode.SelColor = RGB(CommentRed, CommentGreen, CommentBlue)
            RobotCode.SelStart = PresentSL
            
            LockWindowUpdate 0                      'UNLOCKS!!
        End If
    Case vbKeyBack
        Dim CodeMirror As String

        If RobotCode.SelLength = 0 Then
            GrapPart = RobotCode.Text
            CodeMirror = GrapPart
            PresentSL = RobotCode.SelStart
            If PresentSL = 0 Then Exit Sub
            GrapPart = Mid(GrapPart, PresentSL, 1)
            
            Select Case GrapPart
                Case "#"
                    If RobotCode.SelColor = vbBlack Then Exit Sub
                    CodeMirror = Replace09(CodeMirror, "#", vbCr) & vbCr
                    PresenSLComment = InStr(PresentSL + 1, CodeMirror, vbCr)
                    
                    LockWindowUpdate RobotCode.hwnd         'LOCKS!!
                                    
                    RobotCode.SelLength = PresenSLComment - PresentSL - 1
                    RobotCode.SelColor = vbBlack
                    RobotCode.SelStart = PresentSL
                    
                    LockWindowUpdate 0                      'UNLOCKS!!
                Case "{"
                    If RobotCode.SelColor = vbBlack Then Exit Sub

                    NextSpace = InStr(PresentSL, CodeMirror, "}")
                    AntiSpace = InStr(PresentSL, CodeMirror, "{")
                    
                    If (Not NextSpace < AntiSpace Or (AntiSpace = 0 And NextSpace <> 0)) And NextSpace > PresentSL + 1 Then
 
                        LockWindowUpdate RobotCode.hwnd     'LOCKS!!
                        
                        RobotCode.SelStart = PresentSL - 1
                        RobotCode.SelLength = NextSpace - PresentSL + 2 ' + 1
                        RobotCode.SelColor = vbBlack
                        RobotCode.SelStart = PresentSL
                        
                        LockWindowUpdate 0                  'UNLOCKS!!
                    End If
                Case "}"
                    GrapPart = StrReverse(CodeMirror)
                    NextSpace = Len(GrapPart) - InStr(Len(GrapPart) - (RobotCode.SelStart - 1), GrapPart, "{") '+ 1
                    AntiSpace = Len(GrapPart) - InStr(Len(GrapPart) - (RobotCode.SelStart - 1), GrapPart, "}")

                    If (AntiSpace < NextSpace And AntiSpace <> Len(GrapPart)) Or NextSpace > PresentSL Then Exit Sub
                    
                    LockWindowUpdate RobotCode.hwnd         'LOCKS!!
                    
                    RobotCode.SelStart = NextSpace
                    RobotCode.SelLength = PresentSL - NextSpace
                    'If RobotCode.SelColor = RGB(CommentRed, CommentGreen, CommentBlue) Then MsgBox 4    'DEBUG'DEBUG'DEBUG'DEBUG'DEBUG
                    RobotCode.SelColor = vbBlack
                    RobotCode.SelStart = PresentSL
                    
                    LockWindowUpdate 0                      'UNLOCKS!!
                Case ":"
                    If RobotCode.SelColor = vbBlack Then Exit Sub

                    CodeMirror = StrReverse(CodeMirror)
                    PresenSLComment = Len(CodeMirror) - InStr(Len(CodeMirror) - PresentSL + 1, CodeMirror, vbCr)
                    
                    LockWindowUpdate RobotCode.hwnd         'LOCKS!!
                
                    If PresentSL > PresenSLComment Then
                        RobotCode.SelStart = PresenSLComment + 2
                        RobotCode.SelLength = PresentSL - PresenSLComment
                    Else
                        RobotCode.SelStart = 0
                        RobotCode.SelLength = PresentSL
                    End If

                    RobotCode.SelColor = vbBlack
                    RobotCode.SelStart = PresentSL
                    
                    LockWindowUpdate 0                      'UNLOCKS!!
            End Select
        Else
                    'TODO: - INSERT CODE HERE
        End If
    Case vbKeyV
        If Shift = 2 Then   'process clipboard content
            If Clipboard.GetFormat(vbCFRTF) Then
                GrapPart = Clipboard.GetText
                If InStr(GrapPart, ":") = 0 And InStr(GrapPart, "#") = 0 And InStr(GrapPart, "{") = 0 And InStr(GrapPart, "}") = 0 Then
                    Clipboard.Clear: Clipboard.SetText GrapPart 'erase format
                End If
            End If
        End If
End Select

End If
End Sub

Private Sub RobotCode_KeyUp(KeyCode As Integer, Shift As Integer) ' THE ON THE FLY SYNTAX COLORING CODE
If SyntaxColoringCache Then

If KeyCode = 48 Then    '}
    If Shift = 6 Then
        RobotCode.SelColor = vbBlack
    End If
'ElseIf KeyCode = 190 Then       ':     'Doesn't seem to work properly
'    If Shift = 1 Then
'        RobotCode.SelColor = vbBlack
'    End If
End If

End If
End Sub

Private Sub SyntaxColor_Click()    '{lkasjd:} blir felfärgat
Dim TheRTFCode As String
Dim newrtftext As String
Dim counter As Long
Dim TheSplit() As String
Dim commentnumber As Long

TheRTFCode = RobotCode.TextRTF

counter = InStr(TheRTFCode, vbCr)

TheRTFCode = Left$(TheRTFCode, counter) & _
"{\colortbl ;\red" & LabelRed & "\green" & LabelGreen & "\blue" & LabelBlue & ";\red" & CommentRed & "\green" & CommentGreen & "\blue" & CommentBlue & ";}" _
& vbCr & Right$(TheRTFCode, Len(TheRTFCode) - counter)

TheSplit = Split(TheRTFCode, "\par ")

'''''''Nummer 0 - måste specialbehandlas-
    If InStr(TheSplit(0), "\" & Chr(123)) Then
        TheSplit(0) = Replace09(TheSplit(0), "\" & Chr(123), "\cf2\" & Chr(123))
        commentnumber = commentnumber + 1
    End If

    If commentnumber = 0 Then   'BUG ALERT! Den färgar "{Comment} label:" fel
        If InStr(TheSplit(0), "\cf1 ") = 0 Then
            If InStr(TheSplit(0), ":") Then
                TheSplit(0) = Left(TheSplit(0), Len(TheSplit(0)) - 2) & "\cf0"
                TheSplit(0) = Replace09(TheSplit(0), "pard\", "pard\cf1\")
            End If
        End If
    End If

    If InStr(TheSplit(0), "\" & Chr(125)) Then
        TheSplit(0) = Replace09(TheSplit(0), "\" & Chr(125), "\" & Chr(125) & "\cf0 ")
        commentnumber = commentnumber - 1
    End If

    If commentnumber = 0 Then       'BUG ALERT! Den färgar "drop #Droppar" fel
        If InStr(TheSplit(0), "#") <> 0 Then
            TheSplit(0) = Left(TheSplit(0), Len(TheSplit(0)) - 2) & "\cf0"
            TheSplit(0) = Replace09(TheSplit(0), "pard\", "pard\cf2\")
        End If
    End If
''''slut 0

For counter = 1 To UBound(TheSplit)
    If InStr(TheSplit(counter), "\" & Chr(123)) Then
        TheSplit(counter) = Replace09(TheSplit(counter), "\" & Chr(123), "\cf2\" & Chr(123))
        commentnumber = commentnumber + 1
    End If

    If commentnumber = 0 Then   'BUG ALERT! Den färgar "{Comment} label:" fel
        If InStr(TheSplit(counter), ":") Then
            TheSplit(counter) = "\cf1 " & Replace09(TheSplit(counter), ":", ":\cf0 ")
        End If
    End If

    If InStr(TheSplit(counter), "\" & Chr(125)) Then
        TheSplit(counter) = Replace09(TheSplit(counter), "\" & Chr(125), "\" & Chr(125) & "\cf0 ")
        commentnumber = commentnumber - 1
    End If

    If commentnumber = 0 Then
        If InStr(TheSplit(counter), "#") <> 0 Then
            TheSplit(counter) = Replace09(TheSplit(counter), "#", "\cf2 #") & "\cf0"
        End If
    End If
Next counter

Dim stopacumulation As String
stopacumulation = StrReverse(TheSplit(UBound(TheSplit)))
TheSplit(UBound(TheSplit)) = StrReverse(Replace09(stopacumulation, "} ", "}"))

newrtftext = Join(TheSplit, "\par ")
RobotCode.TextRTF = newrtftext 'Left(newrtftext, Len(newrtftext) - 2)

'RobotCode.SaveFile ("E:\Test.txt")
End Sub

Private Sub CancelButton_Click()
Dim res As Byte
res = MsgBox("Are you sure you don't want to save your changes?", vbYesNoCancel, "Don't save changes?") _

If res = vbYes Then
    HasCanceled = True
ElseIf res = vbNo Then
    HasCanceled = False
ElseIf res = vbCancel Then
    HasCanceled = False
    Exit Sub
End If

Unload Me
End Sub

Private Sub compileandclose_Click()
Unload Me
End Sub

Private Sub compilebutton_Click()
If RecompileLock.Checked Then
    MsgBox "This robot is recompile locked", , "Can't compile"
Else
    SkrivKodenSamtCompilera (False)
End If
End Sub

Private Sub CompileMenu_Click()
compilebutton_Click
End Sub

Private Sub Copy_Click()
SendKeys "^{C}", True
End Sub

Private Sub CountInst_Click()
On Error GoTo CountingError

Dim Stage1Code As String
Dim CommentStartPosition As Long    'integer
Dim CommentWhichWillBeRomoved As String
Stage1Code = RobotCode.SelText
Stage1Code = Replace09(Stage1Code, vbLf, vbCr)

Dim splitcode() As String
Dim splitcode2() As String
Dim SkipNum As Integer
Dim counter As Integer

Stage1Code = Replace09(Stage1Code, "}}", "} }") & vbCr 'it seems to have problems with }}
splitcode = Split(Stage1Code, "}")
Stage1Code = ""

For counter = 0 To UBound(splitcode)
    If SkipNum > 0 Then
        SkipNum = SkipNum - 1
    Else
        splitcode2 = Split(splitcode(counter), "{")
        SkipNum = UBound(splitcode2) - 1
        Stage1Code = Stage1Code & " " & splitcode2(0)
        'If UBound(SplitCode2) <> -1 Then Stage1Code = Stage1Code & " " & SplitCode2(0)
    End If
Next counter

Do While InStr(Stage1Code, "#" & vbCr) <> 0          'Tar bort "#" & vbCr / vbLf
    Stage1Code = Replace09(Stage1Code, "#" & vbCr, vbCr)   'för Stjärnkommmentarsborttagaren
Loop                                                    'kan inte hantera dem

Dim NextChar As String
CommentStartPosition = InStr(Stage1Code, "#")           'kollar om # finns
If CommentStartPosition = 0 Then GoTo SkipStarComnments 'går till skipstarcomments om det inte finns
If CommentStartPosition <> 1 Then CommentStartPosition = CommentStartPosition - 1
counter = CommentStartPosition + 1

Do
    NextChar = Mid$(Stage1Code, counter, 1) 'Kollar nästa bokstav
    If NextChar = vbCr Then 'Om nästa bokstav är radbrytning då
        CommentWhichWillBeRomoved = Mid$(Stage1Code, CommentStartPosition, counter - CommentStartPosition)
        Stage1Code = Replace09(Stage1Code, CommentWhichWillBeRomoved, "", , 1)
        CommentStartPosition = InStr(Stage1Code, "#")   'Kollar om det finns fler och i så fall var
        counter = CommentStartPosition + 1              'Ställer in Counter
        If CommentStartPosition = 0 Then Exit Do
    Else
        counter = counter + 1
        NextChar = ""          'Troligen behövs denhär inte
        If counter = Len(Stage1Code) Then
            CommentWhichWillBeRomoved = Mid$(Stage1Code, CommentStartPosition, counter - CommentStartPosition + 1)
            Stage1Code = Replace09(Stage1Code, CommentWhichWillBeRomoved, "", , 1)
            Exit Do
        End If
    End If
Loop

SkipStarComnments:
Stage1Code = Replace09(Stage1Code, ";", " ")    'flyttad hit
Stage1Code = Replace09(Stage1Code, ",", " ")    'nytt
Stage1Code = Replace09(Stage1Code, vbTab, " ")  'Nya Replace09rs sedan Orb of Doom
Stage1Code = StrConv(Stage1Code, vbUpperCase)
Stage1Code = Replace09(Stage1Code, vbCr, " ")      'Behövs
Stage1Code = Trim$(Stage1Code)                      'detta?
Stage1Code = Replace09(Stage1Code, " ", vbCr)      '??

Do While InStr(Stage1Code, vbCr & vbCr) <> 0
    Stage1Code = Replace09(Stage1Code, vbCr & vbCr, vbCr)
Loop

Stage1Code = vbCr & Stage1Code & vbCr

Stage1Code = Replace09(Stage1Code, vbCr & "NEAREST" & vbCr, vbCr & "NEAREST'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "COLLISION" & vbCr, vbCr & "COLLISION'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "AIM" & vbCr, vbCr & "AIM'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "FRIEND" & vbCr, vbCr & "FRIEND'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "DAMAGE" & vbCr, vbCr & "DAMAGE'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "DOPPLER" & vbCr, vbCr & "DOPPLER'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "HISTORY" & vbCr, vbCr & "HISTORY'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ID" & vbCr, vbCr & "ID'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "KILLS" & vbCr, vbCr & "KILLS'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "LOOK" & vbCr, vbCr & "LOOK'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "RANDOM" & vbCr, vbCr & "RANDOM'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "RANGE" & vbCr, vbCr & "RANGE'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ROBOTS" & vbCr, vbCr & "ROBOTS'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SCAN" & vbCr, vbCr & "SCAN'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SHIELD" & vbCr, vbCr & "SHIELD'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SPEEDX" & vbCr, vbCr & "SPEEDX'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SPEEDY" & vbCr, vbCr & "SPEEDY'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "TEAMMATES" & vbCr, vbCr & "NOP" & vbCr & "0" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "WALL" & vbCr, vbCr & "WALL'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "RADAR" & vbCr, vbCr & "RADAR'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SIGNAL" & vbCr, vbCr & "SIGNAL'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "CHRONON" & vbCr, vbCr & "CHRONON'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "PROBE" & vbCr, vbCr & "PROBE'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ENERGY" & vbCr, vbCr & "ENERGY'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "A" & vbCr, vbCr & "A'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "B" & vbCr, vbCr & "B'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "C" & vbCr, vbCr & "C'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "D" & vbCr, vbCr & "D'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "E" & vbCr, vbCr & "E'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "F" & vbCr, vbCr & "F'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "G" & vbCr, vbCr & "G'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "H" & vbCr, vbCr & "H'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "I" & vbCr, vbCr & "I'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "J" & vbCr, vbCr & "J'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "K" & vbCr, vbCr & "K'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "L" & vbCr, vbCr & "L'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "M" & vbCr, vbCr & "M'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "N" & vbCr, vbCr & "N'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "O" & vbCr, vbCr & "O'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "P" & vbCr, vbCr & "P'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "Q" & vbCr, vbCr & "Q'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "R" & vbCr, vbCr & "R'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "S" & vbCr, vbCr & "S'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "T" & vbCr, vbCr & "T'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "U" & vbCr, vbCr & "U'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "V" & vbCr, vbCr & "V'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "W" & vbCr, vbCr & "W'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "X" & vbCr, vbCr & "X'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "Y" & vbCr, vbCr & "Y'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "Z" & vbCr, vbCr & "Z'" & vbCr & "RECALL" & vbCr)

Stage1Code = Replace09(Stage1Code, vbCr & "NEAREST" & vbCr, vbCr & "NEAREST'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "COLLISION" & vbCr, vbCr & "COLLISION'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "AIM" & vbCr, vbCr & "AIM'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "FRIEND" & vbCr, vbCr & "FRIEND'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "DAMAGE" & vbCr, vbCr & "DAMAGE'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "DOPPLER" & vbCr, vbCr & "DOPPLER'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "HISTORY" & vbCr, vbCr & "HISTORY'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ID" & vbCr, vbCr & "ID'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "KILLS" & vbCr, vbCr & "KILLS'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "LOOK" & vbCr, vbCr & "LOOK'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "RANDOM" & vbCr, vbCr & "RANDOM'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "RANGE" & vbCr, vbCr & "RANGE'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ROBOTS" & vbCr, vbCr & "ROBOTS'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SCAN" & vbCr, vbCr & "SCAN'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SHIELD" & vbCr, vbCr & "SHIELD'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SPEEDX" & vbCr, vbCr & "SPEEDX'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SPEEDY" & vbCr, vbCr & "SPEEDY'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "TEAMMATES" & vbCr, vbCr & "NOP" & vbCr & "0" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "WALL" & vbCr, vbCr & "WALL'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "RADAR" & vbCr, vbCr & "RADAR'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SIGNAL" & vbCr, vbCr & "SIGNAL'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "CHRONON" & vbCr, vbCr & "CHRONON'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "PROBE" & vbCr, vbCr & "PROBE'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ENERGY" & vbCr, vbCr & "ENERGY'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "A" & vbCr, vbCr & "A'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "B" & vbCr, vbCr & "B'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "C" & vbCr, vbCr & "C'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "D" & vbCr, vbCr & "D'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "E" & vbCr, vbCr & "E'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "F" & vbCr, vbCr & "F'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "G" & vbCr, vbCr & "G'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "H" & vbCr, vbCr & "H'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "I" & vbCr, vbCr & "I'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "J" & vbCr, vbCr & "J'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "K" & vbCr, vbCr & "K'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "L" & vbCr, vbCr & "L'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "M" & vbCr, vbCr & "M'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "N" & vbCr, vbCr & "N'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "O" & vbCr, vbCr & "O'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "P" & vbCr, vbCr & "P'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "Q" & vbCr, vbCr & "Q'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "R" & vbCr, vbCr & "R'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "S" & vbCr, vbCr & "S'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "T" & vbCr, vbCr & "T'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "U" & vbCr, vbCr & "U'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "V" & vbCr, vbCr & "V'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "W" & vbCr, vbCr & "W'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "X" & vbCr, vbCr & "X'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "Y" & vbCr, vbCr & "Y'" & vbCr & "RECALL" & vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "Z" & vbCr, vbCr & "Z'" & vbCr & "RECALL" & vbCr)

Stage1Code = Replace09(Stage1Code, vbCr & "ICON0" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON1" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON2" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON3" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON4" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON5" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON6" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON7" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON8" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON9" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON0" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON1" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON2" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON3" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON4" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON5" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON6" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON7" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON8" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "ICON9" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND0" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND1" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND2" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND3" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND4" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND5" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND6" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND7" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND8" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND9" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND0" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND1" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND2" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND3" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND4" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND5" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND6" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND7" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND8" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "SND9" & vbCr, vbCr)

Stage1Code = Replace09(Stage1Code, vbCr & "DEBUG" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "DEBUGGER" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "BEEP" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "DEBUG" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "DEBUGGER" & vbCr, vbCr)
Stage1Code = Replace09(Stage1Code, vbCr & "BEEP" & vbCr, vbCr)

Stage1Code = Right$(Stage1Code, Len(Stage1Code) - 1)
Stage1Code = Left$(Stage1Code, Len(Stage1Code) - 1) 'Nytt sedan 2004

Do While InStr(Stage1Code, vbTab) <> 0             'Fungerar
Stage1Code = Replace09(Stage1Code, vbTab, "")
Loop

Do While InStr(Stage1Code, vbLf) <> 0
Stage1Code = Replace09(Stage1Code, vbLf, "")         'flyttat till början
Loop

Do While InStr(Stage1Code, vbCr & vbCr) <> 0
Stage1Code = Replace09(Stage1Code, vbCr & vbCr, vbCr)
Loop

splitcode = Split(Stage1Code, vbCr)
Stage1Code = ""

For counter = 0 To UBound(splitcode)
    If InStr(splitcode(counter), ":") = 0 Then Stage1Code = Stage1Code & splitcode(counter) & vbCr
Next counter

counter = UBound(Split(Stage1Code, vbCr))
If counter < 0 Then counter = 0
MsgBox counter & " instructions highlighted." & vbCr & vbCr & "(Not counting zero-time-execution instructions, like SNDx, ICONx, BEEP and DEBUG).", , "Count instructions"

CountingError:
If Err <> 0 Then MsgBox "There was an error while counting instructions, probably caused by {} comments." & vbCr & "Please do a syntax check.", , "Count Instructions Error"

End Sub

Private Sub CustomAimLoop_Click()
Dim NumberOfDegrees As Variant
Dim AimLoop As String
Dim AimVal As Integer
Dim res As Integer
Dim Templimit As Variant

redo:
NumberOfDegrees = InputBox("Note: as soon as I find the source of Justin Blachards" & vbLf & "Aim Loop Generator, I'll built it in here." & vbLf & "Anyway, " & vbLf & vbLf & "How many degrees between each check?", "Aim Loop", 10)
If NumberOfDegrees = "" Then GoTo AbortCreation
NumberOfDegrees = Val(NumberOfDegrees)
'If NumberOfDegrees = 0 Then GoTo AbortCreation 'Prevent eternal loop = Freezing
If NumberOfDegrees > 359 Or NumberOfDegrees < 1 Then
    If MsgBox("How many degrees between each check must range from 1 to 359", vbRetryCancel + vbCritical, "Aimloop Error") = vbCancel Then GoTo AbortCreation
    GoTo redo
End If

Templimit = InputBox("From", "Aim Loop", limit2 - NumberOfDegrees)
If Templimit = "" Then GoTo AbortCreation
limit1 = Templimit

Templimit = InputBox("To", "Aim Loop", limit2 + 90 + NumberOfDegrees)
If Templimit = "" Then GoTo AbortCreation
limit2 = Templimit

AimVal = limit1

Do While AimVal <= limit2
    AimLoop = AimLoop & AimVal & " aim' store" & Chr(10)
    AimVal = AimVal + NumberOfDegrees
Loop

res = MsgBox(AimLoop, vbYesNoCancel, "Is this ok?")
If res = vbCancel Then GoTo AbortCreation

Dim insert As String
insert = AimLoop

AimLoop = ""
limit2 = limit2 - NumberOfDegrees

If res = vbNo Then GoTo redo

RobotCode.SelRTF = insert

AbortCreation:
RobotCode.SelStart = RobotCode.SelStart
RobotCode.SetFocus
End Sub

Private Sub Cut_Click()
SendKeys "^{X}", True
End Sub

Private Sub DebuggingDeadloop_Click()
If InStr(RobotCode.Text, "loop:") Then
    RobotCode.SelRTF = "loop jump"
Else
    RobotCode.SelRTF = "loop: loop jump"
End If
End Sub

Private Sub defaultfont_Click()
Dim res As Integer
res = MsgBox("Are you sure?", vbOKCancel + vbDefaultButton2, "Reset To Default Font")

If IsCRobot Then
    If res = vbOK Then
        RobotCode.Font.Name = "Courier New"
        RobotCode.Font.Size = 11
        RobotCode.Font.Bold = False
        RobotCode.Font.Italic = False
        RobotCode.Font.Strikethrough = False
        RobotCode.Font.Underline = False
    End If
    
    Open App.Path & "\miscdata\DraftPrefsC.cfg" For Output As 10
    Print #10, "Courier New" & vbCr & 11 & vbCr & 0 & vbCr & 0 & vbCr & 0 & vbCr & 0
    Close 10
Else
    If res = vbOK Then
        RobotCode.Font.Name = "MS Sans Serif"
        RobotCode.Font.Size = 8
        RobotCode.Font.Bold = False
        RobotCode.Font.Italic = False
        RobotCode.Font.Strikethrough = False
        RobotCode.Font.Underline = False
    End If
    
    Open App.Path & "\miscdata\DraftPrefs.cfg" For Output As 10
    Print #10, "MS Sans Serif" & vbCr & 8 & vbCr & 0 & vbCr & 0 & vbCr & 0 & vbCr & 0
    Close 10
End If

End Sub

Private Sub DebuggingAlwaysSameXY_Click()
Dim Xpos As Integer
Dim Ypos As Integer
Dim insert As String
Dim InputN As String

If TheXYPos = 0 Then
    TheXYPos = 200
Else
    TheXYPos = TheXYPos \ 2
End If

InputN = InputBox("X-Pos to start at?", "X-pos", TheXYPos)
If InputN = "" Then GoTo AbortCreation
Xpos = Val(InputN)
InputN = InputBox("Y-Pos to start at?", "Y-pos", TheXYPos)
If InputN = "" Then GoTo AbortCreation
Ypos = Val(InputN)

insert = _
"x " & Xpos & " < dbgori ifg x " & Xpos + 15 & " < dstp ifg " & Xpos + 15 & " left' setparam dstp left' setint inton -10 speedx' store dlp rti" & vbCr & _
"dbgori: x " & Xpos - 15 & " > dstp ifg " & Xpos - 15 & " right' setparam dstp right' setint inton 10 speedx' store dlp: dlp jump" & vbCr & _
"dstp: 0 speedx' store " & Xpos & " x - movex' store y " & Ypos & " < dbgwd ifg y " & Ypos + 15 & " < dbgd ifg " & Ypos + 15 & " top' setparam dbgd top' setint inton -10 speedy' store dlp rti" & vbCr & _
"dbgwd: y " & Ypos - 15 & " > dbgd ifg " & Ypos - 15 & " bot' setparam dbgd bot' setint inton 10 speedy' store dlp rti" & vbCr & _
"dbgd: 0 speedy' store " & Ypos & " y - movey' store -1 left' setint -1 top' setint -1 bot' setint -1 right' setint" & vbCr & _
"280 bot' setparam 20 top' setparam 280 right' setparam 20 left' setparam 97 chronon' setparam dbrgo chronon' setint dlp rti dbrgo: sync intoff dropall sync -1 chronon' setint sync"

RobotCode.SelRTF = insert

AbortCreation:
RobotCode.SelStart = RobotCode.SelStart
RobotCode.SetFocus
End Sub

Private Sub DopplerForBullets_Click()
RobotCode.SelRTF = "doppler 5 * aim + aim' store"

End Sub

Private Sub DopplerForStunners_Click()
RobotCode.SelRTF = "doppler 3 * aim + aim' store"
End Sub

Private Sub Find_Click()
sFind = InputBox("Search for", "Find", Trim$(RobotCode.SelText))
If RobotCode.Find(sFind, RobotCode.SelStart + RobotCode.SelLength + 1) = -1 Then RobotCode.Find sFind, 0 ', RobotCode.SelStart + RobotCode.SelLength + 1
End Sub

Private Sub FindNext_Click()
If RobotCode.Find(sFind, RobotCode.SelStart + RobotCode.SelLength + 1) = -1 Then RobotCode.Find sFind, 0 ', RobotCode.SelStart + RobotCode.SelLength + 1
End Sub

Private Sub SearchInst(lookingfor As Integer)
If IsCRobot Then Exit Sub

On Error GoTo therewasan

Dim splitcode() As String
Dim splitcode2() As String
Dim SourceCode As String

Dim c As Long
Dim d As Integer
Dim SkipNum As Integer

SourceCode = RobotCode.Text
SourceCode = Replace09(SourceCode, "}}", "} }") & vbCr 'it seems to have problems with }}, also includes the line under
splitcode = Split(SourceCode, "}")

SourceCode = ""

For c = 0 To UBound(splitcode)
    If SkipNum > 0 Then
        SkipNum = SkipNum - 1
        SourceCode = SourceCode & ":" & String(Len(splitcode(c)), 55) '& ":"
    Else
        splitcode2 = Split(splitcode(c), "{")
        SkipNum = UBound(splitcode2) - 1

        'SourceCode = SourceCode & " " & SplitCode2(0)
        If UBound(splitcode2) <> -1 Then SourceCode = SourceCode + " " + splitcode2(0)

        For d = 1 To UBound(splitcode2)
            If Len(splitcode2(d)) > 0 Then SourceCode = SourceCode & ":" & String(Len(splitcode2(d)), 55) '& ":"
        Next d
    End If
Next c

SourceCode = Right$(SourceCode, Len(SourceCode) - 1)
SourceCode = Replace09(SourceCode, vbLf, vbCr)

'BUG ALERT! KLARAR INTE "#" & vbCr
SourceCode = Replace09(SourceCode, "#" & vbCr, ":" & vbCr)    'Kanske fungerar? Eftersom jag helt glömt bort hur denhär är konstruerad...
'This code sure is spooky

If InStr(SourceCode, "#") Then
    Dim cpos As Long

    splitcode = Split(SourceCode, vbCr)
    For c = 0 To UBound(splitcode)
        cpos = InStr(splitcode(c), "#")
        If cpos = 1 Then
            splitcode(c) = String(Len(splitcode(c)) - 1, 55) & ":"
        ElseIf cpos <> 0 Then
            splitcode(c) = Left$(splitcode(c), cpos) & String(Len(splitcode(c)) - 1 - cpos, 55) & ":"
        End If
    Next c
    
    SourceCode = Join(splitcode, vbCr) '& vbCr
End If

SourceCode = Replace09(SourceCode, " ", vbCr)
SourceCode = Replace09(SourceCode, vbTab, vbCr)
SourceCode = Replace09(SourceCode, ";", vbCr)
SourceCode = Replace09(SourceCode, ",", vbCr)
SourceCode = UCase(SourceCode)

splitcode = Split(SourceCode, vbCr)

Dim WhichInst As Integer

For c = 0 To UBound(splitcode)
    If InStr(splitcode(c), ":") Then
        WhichInst = WhichInst - 1
    Else
        Select Case splitcode(c)
            Case "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", _
                  "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "Z", _
                  "AIM", "CHANNEL", "CHRONON", "COLLISION", "DAMAGE", "DOPPLER", _
                  "FRIEND", "HISTORY", "ID", "KILLS", "LOOK", "ENERGY", "WALL", _
                  "PROBE", "RADAR", "RANDOM", "RANGE", "ROBOTS", "SCAN", "TEAMMATES", _
                  "SHIELD", "SIGNAL", "SPEEDX", "SPEEDY", "X", "Y", "NEAREST"
                If WhichInst = lookingfor Then Exit For
                WhichInst = WhichInst + 1
            Case ""
                WhichInst = WhichInst - 1
        End Select
    End If

    If WhichInst = lookingfor Then Exit For
    WhichInst = WhichInst + 1
Next c

SourceCode = ""

For d = 0 To c - 1
    SourceCode = SourceCode & splitcode(d) & " "
Next d

RobotCode.SelStart = Len(SourceCode)
'Highlighting the instruction
Dim SS As Long
Dim nextdelim As Long
SS = RobotCode.SelStart
Dim CodeMirror As String
CodeMirror = RobotCode.Text
CodeMirror = Replace09(CodeMirror, vbCr, " ")
CodeMirror = Replace09(CodeMirror, vbLf, " ")
CodeMirror = Replace09(CodeMirror, vbTab, " ")
CodeMirror = Replace09(CodeMirror, ";", " ")
CodeMirror = Replace09(CodeMirror, ",", " ")
nextdelim = InStr(SS + 1, CodeMirror, " ")

If nextdelim <> 0 Then
RobotCode.SelLength = nextdelim - SS
Else
RobotCode.SelLength = Len(CodeMirror) - SS
End If

Exit Sub

therewasan:
MsgBox "There was an error. Please do a syntax check", , "Can't find instruction"

End Sub

Private Sub FindInstruction_Click()
Retry:

Dim insttofind As Variant
insttofind = InputBox("Please enter the instruction number to search for (0 to 4999):")
If insttofind = "" Then Exit Sub

If IsNumeric(insttofind) And insttofind >= 0 And insttofind <= 32767 Then
    SearchInst (CInt(insttofind))
Else
    If MsgBox("The instruction number you specified (" & insttofind & ") doesn't seem to exist." & vbCr & _
    "Instruction numbers ranges from 0 to 4999 at most." & vbCr & vbCr & _
    "Retry?", vbRetryCancel, "Can't find instruction") = vbRetry Then GoTo Retry
End If

End Sub

Private Sub Form_Load()
'Window Min/Max
Dim YesOrNo As Boolean

If MainWindow.ResolutionChanged Then
    MachineCodeText.Visible = False     '       if 640x480 it always runs maximated
    RobotCode.Height = 350
Else
    Get 7, 4000, YesOrNo                       'Window State

    If YesOrNo Then
        Me.WindowState = 2
        RobotCode.Height = Screen.Height / Screen.TwipsPerPixelY - 130
        MachineCodeText.Height = Screen.Height / Screen.TwipsPerPixelY - 130
    Else
        Me.WindowState = 0
    End If
End If
'Preferences
Get 7, 8000, YesOrNo
AutoCompile.Checked = YesOrNo
Get 7, 10000, YesOrNo
PrintLineNumbers.Checked = YesOrNo
Get 7, 5500, YesOrNo
ResetCursorPosition.Checked = YesOrNo
Get 7, 10500, YesOrNo
SyntaxColoringMenu.Checked = YesOrNo
SyntaxColoringCache = YesOrNo

'Code and cursor position
Select Case MainWindow.SelectedRobot
    Case 1
        PathToRobot = MainWindow.R1path
    Case 2
        PathToRobot = MainWindow.R2path
    Case 3
        PathToRobot = MainWindow.R3path
    Case 4
        PathToRobot = MainWindow.R4path
    Case 5
        PathToRobot = MainWindow.R5path
    Case 6
        PathToRobot = MainWindow.R6path
End Select

Dim rcode As String
Dim rlocking As Byte
Dim cRobotSetting As Byte
Open PathToRobot For Binary As #1
Get #1, RLock, rlocking
RecompileLock.Checked = CBool(rlocking)

Get #1, CRobotRec, cRobotSetting
If CBool(cRobotSetting) Then
    InizCRobots
Else
    RoboTalkRobot.Checked = True
    IsCRobot = False
End If

Get #1, Crec, Cstart
Get #1, MCrec, MStart

Dim CursorPosition As Long
Get #1, CPosrec, CursorPosition
rcode = Space(LOF(1) - Cstart)
'Debug.Print "Loading: CStart=" & Cstart & " LOF=" & LOF(1) & " Mstart=" & MStart

Get #1, Cstart, rcode
If SyntaxColoringCache Then
    If InStrB(rcode, vbNewLine) <> 0 Then rcode = Replace09(rcode, vbNewLine, vbCr)  'DISK - verkar motverka hålen
    'Troligen rör det sig om chr(128-159)
    
    If InStrB(rcode, Chr(133)) <> 0 Then rcode = Replace09(rcode, Chr(133), "")  'DISK - verkar motverka hålen
    If InStrB(rcode, Chr(132)) <> 0 Then rcode = Replace09(rcode, Chr(132), "")  'DISK - verkar motverka hålen
    If InStrB(rcode, Chr(154)) <> 0 Then rcode = Replace09(rcode, Chr(154), "")  'DISK - verkar motverka hålen
    If InStrB(rcode, Chr(140)) <> 0 Then rcode = Replace09(rcode, Chr(140), "")  'DISK - verkar motverka hålen
    If InStrB(rcode, Chr(138)) <> 0 Then rcode = Replace09(rcode, Chr(138), "")  'DISK - verkar motverka hålen
    rcode = rcode & vbCr            'DISK
End If
    
RobotCode.Text = rcode
Label3 = Len(rcode) & " Bytes"
Label4 = (Cstart - MStart) \ 2 & " Instructions"
Close 1

'Font
Dim LoadCfont As String
If IsCRobot Then LoadCfont = "C"

Open App.Path & "\miscdata\DraftPrefs" & LoadCfont & ".cfg" For Input As 10
    If EOF(10) = False Then
        Dim ImputFont As Variant
        Input #10, ImputFont
        RobotCode.Font.Name = ImputFont
        Input #10, ImputFont
        RobotCode.Font.Size = ImputFont
        Input #10, ImputFont
        RobotCode.Font.Bold = CBool(ImputFont)
        Input #10, ImputFont
        RobotCode.Font.Italic = CBool(ImputFont)
        Input #10, ImputFont
        RobotCode.Font.Strikethrough = CBool(ImputFont)
        Input #10, ImputFont
        RobotCode.Font.Underline = CBool(ImputFont)
    End If
Close 10

'Macros
Dim DirName As String
Dim counter As Integer
DirName = Dir$(App.Path & "\Macros\", 0)

Do While DirName <> ""
Macro(counter).Caption = Left$(DirName, Len(DirName) - 4)
Macro(counter).Visible = True
counter = counter + 1
If counter >= 6 Then Exit Do
DirName = Dir$
Loop

If Macro(0).Visible = False Then Separator3.Visible = False

If SyntaxColoringCache Then SyntaxColor_Click


If GotoInstNr > 0 Then
    SearchInst (GotoInstNr - 1)
    GotoInstNr = 0
Else
    RobotCode.SelStart = CursorPosition
End If
    
End Sub

Private Sub Form_Resize()
If MainWindow.ResolutionChanged = 0 Then

Dim YesOrNo As Boolean
If Me.WindowState = 0 Then
    Me.Height = Screen.Height - 450
    RobotCode.Height = Me.ScaleHeight - 55  '50
    MachineCodeText.Height = Me.ScaleHeight - 55    '50
    YesOrNo = False
    Put 7, 4000, YesOrNo
ElseIf Me.WindowState = 2 Then
    YesOrNo = True
    Put 7, 4000, YesOrNo
End If

End If
End Sub

Private Sub Form_Unload(Cancel As Integer)
If Not HasCanceled Then SkrivKoden
HasCanceled = False    'Dethär är väldigt mystiskt, det verkar komma ihåg att DoCancel = true när
'den stängs. Varning för kloning 'Men den verkar köra form load i alla fall
End Sub

Private Sub HardwareStore_Click()
Unload Me
HardwareWindow.Show 1, MainWindow
End Sub

Private Sub HelpMenu_Click()
ShowHelp
End Sub

Private Sub IconFactory_Click()
Unload Me
ChooseIcon.Show 1, MainWindow

End Sub

Private Sub InsertPrint_Click()
RobotCode.SelRTF = "1 print drop"
End Sub

Private Sub LookRoutine_Click()

Dim NumberOfDegrees As Variant
Dim lookloop As String
Dim lookval As Integer
Dim res As Integer
Dim interval As Variant

redolook:
NumberOfDegrees = InputBox("Note: as soon as I find the source of Justin Blachards" & vbLf & "Aim Loop Generator, I'll built it in here." & vbLf & "Anyway, " & vbLf & vbLf & "How many degrees between each check?", "Look routine", 3)
If NumberOfDegrees = "" Then GoTo AbortCreation
NumberOfDegrees = Val(NumberOfDegrees)
'If NumberOfDegrees = 0 Then GoTo AbortCreation 'Prevent eternal loop = Freezing
If NumberOfDegrees > 359 Or NumberOfDegrees < 1 Then
    If MsgBox("How many degrees between each check must range from 1 to 359", vbRetryCancel + vbCritical, "Aimloop Error") = vbCancel Then GoTo AbortCreation
    GoTo redolook
End If

redointerval:

interval = InputBox("Please enter the max look value.", "Look routine", NumberOfDegrees * 8)
If interval = "" Then GoTo AbortCreation
interval = Val(interval)
'If interval = 0 Then GoTo AbortCreation 'Prevent eternal loop = Freezing
If NumberOfDegrees > 359 Or NumberOfDegrees < 1 Then
    If MsgBox("Max look value must range from 1 to 359", vbRetryCancel + vbCritical, "Aimloop Error") = vbCancel Then GoTo AbortCreation
    GoTo redointerval
End If

lookval = NumberOfDegrees

Do While lookval <= interval
    lookloop = lookloop & lookval & " look' store" & Chr(10)
    lookloop = lookloop & -lookval & " look' store" & Chr(10)
    lookval = lookval + NumberOfDegrees
Loop

res = MsgBox(lookloop, vbYesNoCancel, "Is this ok?")
If res = vbCancel Then GoTo AbortCreation

Dim insert As String
insert = lookloop

lookloop = ""
lookval = 0

If res = vbNo Then GoTo redolook

RobotCode.SelRTF = insert

AbortCreation:
RobotCode.SelStart = RobotCode.SelStart
RobotCode.SetFocus
End Sub



Private Sub Macro_Click(index As Integer)
Dim MyMacro As String
Open App.Path & "\Macros\" & Macro(index).Caption & ".txt" For Input As #12
MyMacro = Input(LOF(12), 12)
RobotCode.SelText = MyMacro
Close 12

End Sub

Private Sub Paste_Click()
SendKeys "^{V}", True
End Sub

Private Sub Print_Click()
CommonDialog1.ShowPrinter
On Error GoTo printererror

Printer.Orientation = CommonDialog1.Orientation
Printer.Copies = CommonDialog1.Copies
RobotCode.SelPrint (Printer.hdc)
'Exit Sub

printererror:
'MsgBox Err.Description, vbCritical, "There has been a printer error."
End Sub

Private Sub PrintLineNumbers_Click()
Dim YesOrNo As Boolean
If PrintLineNumbers.Checked Then
    PrintLineNumbers.Checked = False
    YesOrNo = False
Else
    PrintLineNumbers.Checked = True
    YesOrNo = True
End If

Put 7, 10000, YesOrNo
End Sub

Private Sub RecompileLock_Click()
Open PathToRobot For Binary As #1
    If RecompileLock.Checked Then
        Put #1, RLock, CByte(0)
        RecompileLock.Checked = False
    Else
        Put #1, RLock, CByte(1)
        RecompileLock.Checked = True
    End If
Close 1
End Sub

Private Sub RecordingStudio_Click()
        Unload Me
        SoundEditor.Show 1, MainWindow

End Sub

Private Sub ResetCursorPosition_Click()
Dim YesOrNo As Boolean
If ResetCursorPosition.Checked Then
    ResetCursorPosition.Checked = False
    YesOrNo = False
Else
    ResetCursorPosition.Checked = True
    YesOrNo = True
End If

Put 7, 5500, YesOrNo
End Sub

Private Sub ResetLook_Click()
RobotCode.SelRTF = "aim look + aim' store" & vbCr & "0 look' store"
End Sub

Private Sub RobotCode_Change()
NoErrors.Visible = False
End Sub

Private Sub RobotCode_DblClick()
HasDCl = True
End Sub

Private Sub RobotCode_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
If HasDCl Then
    'If RobotCode.SelText = "' " Or RobotCode.SelText = "'" Or RobotCode.SelText = "'  " Then
    If RTrim(RobotCode.SelText) = "'" Then
        Dim PresentSL As Long
        Dim GrapPart As String
        GrapPart = StrReverse(RobotCode.Text)
        GrapPart = Replace09(GrapPart, vbCr, " ")
        GrapPart = Replace09(GrapPart, vbLf, " ")
        GrapPart = Replace09(GrapPart, vbTab, " ")
        GrapPart = Replace09(GrapPart, ";", " ")
        GrapPart = Replace09(GrapPart, ",", " ")
        
        Dim NextSpace As Long
        NextSpace = Len(GrapPart) - InStr(Len(GrapPart) - RobotCode.SelStart, GrapPart, " ") + 1
        PresentSL = RobotCode.SelStart
        
        If PresentSL > NextSpace Then
            RobotCode.SelStart = NextSpace
            RobotCode.SelLength = PresentSL - NextSpace
        Else
            RobotCode.SelStart = 0
            RobotCode.SelLength = InStr(RobotCode.Text, "'") - 1
        End If
    End If
    
    HasDCl = False
End If

End Sub

Private Sub SelectAll_Click()
SendKeys "^a" 'select all
End Sub

Private Sub SetEdgeInterupsLimitsto_Click()
Dim inputval As Variant
RobotCode.SelAlignment = rtfLeft

Retry:
inputval = InputBox("How near the edges would you like your robot to go?", "Set Edge Interupts Limits", 15)

If IsNumeric(inputval) Then
    RobotCode.SelRTF = _
    (300 - inputval) & " right' setparam" & vbCr & _
    inputval & " left' setparam" & vbCr & _
    (300 - inputval) & " bot' setparam" & vbCr & _
    inputval & " top' setparam" & vbCr & vbCr
ElseIf inputval <> "" Then
    If MsgBox("The value " & inputval & " is invalid (not numeric)", vbRetryCancel, "Set Edge Interupts Limits") = vbRetry Then GoTo Retry
End If

End Sub

Private Sub SetHistory_Click(index As Integer)
Dim HistoryString As String
Select Case index
    Case 2
        HistoryString = "Kills made in previous battle"
    Case 3
        HistoryString = "Kills made in all battles"
    Case 4
        HistoryString = "Survival points in previous battle"
    Case 5
        HistoryString = "Survival points from all battles"
    Case 6
        HistoryString = "1 if last battle timed out"
    Case 7
        HistoryString = "Teammates alive at end of last battle (excluding self)"
    Case 8
        HistoryString = "Teammates alive at end of all battle"
    Case 9
        HistoryString = "Damage at end of last battle (0 if dead)"
    Case 10
        HistoryString = "Chronons elapsed at end of last battle"
    Case 11
        HistoryString = "Chronons elapsed in all previous battles"
End Select
 
RobotCode.SelRTF = index & " History' setparam" & vbTab & vbTab & "# " & HistoryString & vbLf
End Sub

Private Sub SetHistoryBattles_Click()
RobotCode.SelRTF = "1 History' setparam" & vbTab & vbTab & "# Number of battles fought" & vbLf _
& "{Note that this is the default setting and usually doesn't have to be set}" & vbLf

End Sub

Private Sub Size_Click()
CommonDialog1.Flags = cdlCFScreenFonts Or cdlCFEffects Or cdlCFForceFontExist Or cdlCFANSIOnly Or cdlCFLimitSize
CommonDialog1.Min = 3: CommonDialog1.Max = 24

CommonDialog1.FontName = RobotCode.Font.Name    'Added 04 at Theo's suggestion
                                    'I agree that it looks more proper if a font is selected from the start when the dialog box appears.
CommonDialog1.ShowFont

RobotCode.Font.Bold = CommonDialog1.FontBold
RobotCode.Font.Italic = CommonDialog1.FontItalic
RobotCode.Font.Size = CommonDialog1.FontSize
RobotCode.Font.Strikethrough = CommonDialog1.FontStrikethru
RobotCode.Font.Name = CommonDialog1.FontName
RobotCode.Font.Underline = CommonDialog1.FontUnderline
Dim LoadCfont As String
If IsCRobot Then LoadCfont = "C"
Open App.Path & "\miscdata\DraftPrefs" & LoadCfont & ".cfg" For Output As 10
Print #10, CommonDialog1.FontName & vbCr & CommonDialog1.FontSize & vbCr & CInt(CommonDialog1.FontBold) & vbCr & _
           CInt(CommonDialog1.FontItalic) & vbCr & CInt(CommonDialog1.FontStrikethru) & vbCr & CInt(CommonDialog1.FontUnderline)
Close 10
End Sub

Private Function SyntaxCheck(ByVal TheCode As String) As Boolean
Dim TheCodeA() As String
Dim counter As Integer

TheCode = Replace09(TheCode, vbCr, vbLf)
TheCode = Replace09(TheCode, "{", vbLf & "{")
TheCode = Replace09(TheCode, "}", vbLf & "}")

SplitB04 TheCode, TheCodeA, vbLf

TheCode = ""

Dim numberofparantesis As Integer

For counter = 0 To UBound(TheCodeA)
    If InStr(TheCodeA(counter), "#") = 0 Then
        TheCode = TheCode & TheCodeA(counter) & vbLf
    ElseIf InStr(TheCodeA(counter), "#") <> 1 Then
         TheCode = TheCode & Left$(TheCodeA(counter), InStr(TheCodeA(counter), "#") - 1)
    End If
Next counter

TheCode = LCase(TheCode)
TheCode = Replace09(TheCode, vbLf, " ")
TheCode = Replace09(TheCode, vbTab, " ")
TheCode = Replace09(TheCode, ";", " ")
TheCode = Replace09(TheCode, ",", " ")
TheCode = Replace09(TheCode, "{{", "{ {")
TheCode = Replace09(TheCode, "}}", "} }")

Do While InStr(TheCode, "  ")
TheCode = Replace09(TheCode, "  ", " ")
Loop

SplitB04 TheCode, TheCodeA

Dim TheLabelCollection As String

For counter = 0 To UBound(TheCodeA)
    If InStr(TheCodeA(counter), "{") Then
        If InStr(TheCodeA(counter), "}") = 0 Then
            numberofparantesis = numberofparantesis + 1
        End If
    Else
        If InStr(TheCodeA(counter), "}") Then
            numberofparantesis = numberofparantesis - 1
        Else
            If InStr(TheCodeA(counter), ":") And numberofparantesis = 0 Then
                If InStr(TheLabelCollection, " " & TheCodeA(counter)) Then
                    MsgBox "Duplic label.", , "Bug Alert!"
                    RobotCode.SetFocus
                    RobotCode.Find TheCodeA(counter), InStr(LCase(RobotCode.Text), TheCodeA(counter))
                    SyntaxCheck = True
                    Exit Function
                Else
                    TheLabelCollection = TheLabelCollection & " " & TheCodeA(counter)
                End If
            End If
        End If
    End If
Next counter

If numberofparantesis < 0 Then
    MsgBox "You have too many }.", , "Bug Alert!"
    RobotCode.SetFocus
    RobotCode.SelStart = Len(RobotCode.Text) - InStr(StrReverse(RobotCode.Text), "}")
    RobotCode.SelLength = 1
    SyntaxCheck = True
    Exit Function
ElseIf numberofparantesis > 0 Then
    MsgBox "Comment not closed.", , "Bug Alert!"
    RobotCode.SetFocus
    RobotCode.SelStart = Len(RobotCode.Text) - InStr(StrReverse(RobotCode.Text), "{")
    RobotCode.SelLength = 1
    SyntaxCheck = True
    Exit Function
End If
End Function

Private Sub SyntaxColoringMenu_Click()
    If SyntaxColoringMenu.Checked Then
        SyntaxColoringMenu.Checked = False
        SyntaxColoringCache = False
    Else
        SyntaxColoringMenu.Checked = True
        SyntaxColoringCache = True
    End If
    
    Put 7, 10500, SyntaxColoringCache
    
'    MsgBox "This change takes effect the next time the Drafting Board is loaded." & vbCr & "(To do this, first close this message, then press F1, then F2.)", vbInformation, "Switch Syntax Coloring On/Off"
    MsgBox "This change takes effect the next time the Drafting Board is loaded." & vbCr & "(To do this, first close this message, then press F1, then F2.)", vbInformation, "Syntax Coloring"
    If SyntaxColoringCache Then MsgBox "Syntax Coloring is currently in beta stage.", , "Syntax Coloring"
End Sub

'Private Sub TestColor_Click()   'DEBUG - REMOVE LATER
'RobotCode.SelColor = RGB(CommentRed, CommentGreen, CommentBlue)
'End Sub
'
'Private Sub TestSave_Click()    'DEBUG - REMOVE LATER
'RobotCode.SaveFile ("E:\Test.txt")
'End Sub

Private Sub Tutorial_Click()
ShowTutorial
End Sub

Private Sub Undo_Click()
SendKeys "^{Z}", True
End Sub

Private Sub SkrivKoden()
'This sub is run every time the user exits the drafting board to save the robot

If AutoCompile.Checked And Not RecompileLock.Checked Then
    'When we should write the code and compile it gets a little tricky
    SkrivKodenSamtCompilera (True)
Else
    ' Just write the code
    Dim NewRobot As String
    Dim rcode As String
    rcode = RobotCode.Text
    'If RCode <> "" Then RCode = Left$(RCode, Len(RCode) - 1)    'The drafting board seems to put on an additional new row character. This compensates
    If Right(rcode, 1) = vbCr Then rcode = Left$(rcode, Len(rcode) - 1)    'The drafting board seems to put on an additional new row character. This compensates
    'MsgBox Asc(Right(RCode, 1))

    Open PathToRobot For Binary As #1
        Dim CursorPosition As Long
        CursorPosition = RobotCode.SelStart
        If ResetCursorPosition.Checked Then Put #1, CPosrec, CLng(0) Else Put #1, CPosrec, CursorPosition

        NewRobot = Space(Cstart - 1)  'Reads the robot 0 to one byte before the old code started
        Get #1, 1, NewRobot              'I have no idea why it should be -1 however
    Close 1
    
    NewRobot = NewRobot & rcode
    Open PathToRobot For Output As #1
        Print #1, NewRobot
    Close 1
End If

End Sub

Private Sub SkrivKodenSamtCompilera(SyntaxCheckDisabled As Boolean) 'Syntax check on -> full syntax check enabled. 'Syntax check off -> as fast as possible ' Just write the code
    Dim RobotDrones As Byte
    Dim NewRobot As String
    Dim rcode As String
    rcode = RobotCode.Text

    Dim StrMachineCode As String
    Dim StrMachineCodeArray() As String
    Dim NumberOfInstructions As Integer

    If IsCRobot Then      'Support for C robots
        StrMachineCode = Compile(C2RoboTalk(rcode))
    Else                        'Common RoboTalk Robots
        If Not SyntaxCheckDisabled Then
            If SyntaxCheck(rcode) Then Exit Sub
        End If
        
        StrMachineCode = Compile(rcode)
    End If

    If Right(rcode, 1) = vbCr Then rcode = Left$(rcode, Len(rcode) - 1)    'The drafting board seems to put on an additional new row character. This compensates
    
    StrMachineCodeArray = Split(StrMachineCode, vbCr)
    NumberOfInstructions = UBound(StrMachineCodeArray) + 1

    Open PathToRobot For Binary As #1
        NewRobot = Space(MStart - 1)  'Reads the robot 0 to one byte before the old machine code started
        Get #1, 1, NewRobot
        Cstart = MStart + NumberOfInstructions * 2
    Close 1

    NewRobot = NewRobot & Space(NumberOfInstructions * 2) & rcode

'PREPARE THE MACHINE CODE
    Dim c As Integer
    Dim IntMachineCodeArray() As Integer

    If NumberOfInstructions > INSTRUCTIONLIMIT Then
        MsgBox "A Robot's code can not be longer than " & INSTRUCTIONLIMIT & " instructions, including ICONx, SNDx, RECALLs and the END instruction." & vbCr & "Instructions after " & INSTRUCTIONLIMIT & " will not be loaded.", vbExclamation, "Code too long."
        NumberOfInstructions = INSTRUCTIONLIMIT
        StrMachineCodeArray(4999) = "END"
    End If

    NumberOfInstructions = NumberOfInstructions - 1

    ReDim IntMachineCodeArray(NumberOfInstructions)
    
    Dim sInst As String

If SyntaxCheckDisabled Then   'Without syntax check and as fast as possible
    For c = 0 To NumberOfInstructions
        sInst = StrMachineCodeArray(c)
        If IsNumeric(sInst) Then
            IntMachineCodeArray(c) = StrMachineCodeArray(c)
        Else
            IntMachineCodeArray(c) = Inst2MagicNumber(StrMachineCodeArray(c))
        End If
    Next c
Else        'With syntax check and everything
    Dim LineNumbersCache As Boolean
    LineNumbersCache = PrintLineNumbers.Checked

    For c = 0 To NumberOfInstructions
        sInst = StrMachineCodeArray(c)
        If IsNumeric(sInst) Then
            IntMachineCodeArray(c) = StrMachineCodeArray(c)
        Else
            IntMachineCodeArray(c) = Inst2MagicNumber(StrMachineCodeArray(c))
            If IntMachineCodeArray(c) = iUNKOWN Then
                MsgBox "Unknown token. " & StrMachineCodeArray(c), , "Bug Alert!"
                RobotCode.SetFocus
                If IsCRobot Then RobotCode.Find StrMachineCodeArray(c) Else SearchInst c
                Exit Sub
            End If
        End If
        
        If LineNumbersCache Then StrMachineCodeArray(c) = c & ":   " & StrMachineCodeArray(c)
    Next c
    
    Label3 = Len(rcode) + 1 & " Bytes"
    Label4 = UBound(StrMachineCodeArray) + 1 & " Instructions"

    If LineNumbersCache Then
        MachineCodeText = Join(StrMachineCodeArray, vbCr)
    Else
        MachineCodeText = StrMachineCode
    End If
    
    NoErrors.Visible = True
End If

'FLYTTAT HIT SÅ ATT DEN INTE SKRIVER NÅGOT OM DET BLIR KOMPILERINGSFEL
Open PathToRobot For Output As #1
    Print #1, NewRobot
Close 1

Open PathToRobot For Binary As #1
    Put #1, Crec, Cstart
    Put #1, MStart, IntMachineCodeArray
    Dim CursorPosition As Long
    CursorPosition = RobotCode.SelStart
    If ResetCursorPosition.Checked Then Put #1, CPosrec, CLng(0) Else Put #1, CPosrec, CursorPosition

    Get #1, DroneRec, RobotDrones
    If RobotDrones <> 0 Then    'If drones are 1 or 2
        If InStrB(StrMachineCode, "DRONE'") = 0 Then    'If it have drones equiped but do not use them
            Put #1, DroneRec, CByte(2)
        ElseIf RobotDrones = 2 Then 'If drones are used but wrongfully registred as not being used
            Put #1, DroneRec, CByte(1)
        End If
    End If
    
    'Get #1, DroneRec, RobotDrones 'DEBUG!!!
Close 1

'MsgBox "Drones = " & RobotDrones
End Sub

Private Function C2RoboTalk(ByVal cCode As String) As String
Dim res As Long
Dim RoboTalkCodeBuffer As String
Dim cCodeBuffer As String
Dim SkipNum As Long

cCodeBuffer = cCode

RoboTalkCodeBuffer = Space$(Len(cCodeBuffer) + 1000000)     'We give it 1 MB additional buffer

res = RoboTranslate(RoboTalkCodeBuffer, cCodeBuffer)

If res <> 0 Then
    'res = res + 1 'It seems to be confused by one or two lines before the actual problem
    MsgBox "C to RoboTalk compilation. Line " & res, , "Bug Alert!"
    go_to_line res, RobotCode
    C2RoboTalk = ""
    Exit Function
End If

RoboTalkCodeBuffer = RTrim$(RoboTalkCodeBuffer)

If LenB(RoboTalkCodeBuffer) > 0 Then
    SkipNum = Asc(Right$(RoboTalkCodeBuffer, 1))
    Do Until SkipNum <> 10 And SkipNum <> 13 And SkipNum <> 0 And SkipNum <> 32
        RoboTalkCodeBuffer = Left$(RoboTalkCodeBuffer, Len(RoboTalkCodeBuffer) - 1)
        If LenB(RoboTalkCodeBuffer) = 0 Then Exit Do
        SkipNum = Asc(Right$(RoboTalkCodeBuffer, 1))
    Loop
End If

C2RoboTalk = RoboTalkCodeBuffer
End Function

Private Function Compile(ByVal Stage1Code As String) As String
' This sub translates the RoboTalk code to a machine code
' that consists a long string. The instructions are separated by Chr(13)

' GENERAL STUFF
On Error GoTo CompilingError1
Dim splitcode() As String
Dim splitcode2() As String
Dim SkipNum As Long
Dim counter As Long

Dim LN(399) As String
Dim LP(399) As Long
Dim Instructionn As String

' {}-COMMENTS
' Can handle 2147483647 nested comments, or can it...? - Klarar 2147483647 nested comments, eller gör den...?

' GAMLA
Stage1Code = Replace09(Stage1Code, "}}", "} }") & vbCr 'it seems to have problems with }}, also includes the line under
SplitB04 Stage1Code, splitcode, "}"
Stage1Code = ""

For counter = 0 To UBound(splitcode)
    If SkipNum > 0 Then
        SkipNum = SkipNum - 1
    Else
        SplitB04 splitcode(counter), splitcode2, "{"
        SkipNum = UBound(splitcode2) - 1
        'Stage1Code = Stage1Code & " " & SplitCode2(0)
        If UBound(splitcode2) <> -1 Then Stage1Code = Stage1Code & " " & splitcode2(0)
    End If
Next counter

' #-COMMENTS
Do While InStrB(Stage1Code, vbLf) <> 0
    Stage1Code = Replace09(Stage1Code, vbLf, vbCr)        'Behövs för stjärnkommentarborttagaren om användaren skulle råkat fått in vblf
Loop

counter = InStr(Stage1Code, "#")
Do While counter <> 0
    Stage1Code = Left(Stage1Code, counter - 1) & Right(Stage1Code, Len(Stage1Code) - InStr(counter, Stage1Code, vbCr))
    counter = InStr(Stage1Code, "#")
Loop

' DELIMINERS
Do While InStrB(Stage1Code, vbTab) <> 0
    Stage1Code = Replace09(Stage1Code, vbTab, vbCr)
Loop
Do While InStrB(Stage1Code, ";") <> 0
    Stage1Code = Replace09(Stage1Code, ";", vbCr)
Loop
Do While InStrB(Stage1Code, ",") <> 0
    Stage1Code = Replace09(Stage1Code, ",", vbCr)
Loop
Do While InStrB(Stage1Code, vbCr) <> 0
    Stage1Code = Replace09(Stage1Code, vbCr, " ")
Loop
Do While InStrB(Stage1Code, "  ") <> 0
    Stage1Code = Replace09(Stage1Code, "  ", " ")
Loop

' RECALLS + STO -> STORE and many others as well
' Recalls must be added before we do the labels, otherwise the labels will get wrong numbers

Stage1Code = UCase(Stage1Code)
SplitB04 Stage1Code, splitcode

'For counter = 0 To UBound(splitcode)
'    Select Case splitcode(counter)
'        Case "COLLISION"
'            splitcode(counter) = "COLLISION' RECALL"
'        Case "AIM"
'            splitcode(counter) = "AIM' RECALL"
'        Case "FRIEND"
'            splitcode(counter) = "FRIEND' RECALL"
'        Case "DAMAGE"
'            splitcode(counter) = "DAMAGE' RECALL"
'        Case "DOPPLER"
'            splitcode(counter) = "DOPPLER' RECALL"
'        Case "HISTORY"
'            splitcode(counter) = "HISTORY' RECALL"
'        Case "ID"
'            splitcode(counter) = "ID' RECALL"
'        Case "KILLS"
'            splitcode(counter) = "KILLS' RECALL"
'        Case "LOOK"
'            splitcode(counter) = "LOOK' RECALL"
'        Case "RANDOM"
'            splitcode(counter) = "RANDOM' RECALL"
'        Case "RANGE"
'            splitcode(counter) = "RANGE' RECALL"
'        Case "ROBOTS"
'            splitcode(counter) = "ROBOTS' RECALL"
'        Case "SCAN"
'            splitcode(counter) = "SCAN' RECALL"
'        Case "SHIELD"
'            splitcode(counter) = "SHIELD' RECALL"
'        Case "SPEEDX"
'            splitcode(counter) = "SPEEDX' RECALL"
'        Case "SPEEDY"
'            splitcode(counter) = "SPEEDY' RECALL"
'        Case "TEAMMATES"
'            splitcode(counter) = "TEAMMATES' RECALL"
'        Case "WALL"
'            splitcode(counter) = "WALL' RECALL"
'        Case "RADAR"
'            splitcode(counter) = "RADAR' RECALL"
'        Case "SIGNAL"
'            splitcode(counter) = "SIGNAL' RECALL"
'        Case "CHANNEL"
'            splitcode(counter) = "CHANNEL' RECALL"
'        Case "CHRONON"
'            splitcode(counter) = "CHRONON' RECALL"
'        Case "PROBE"
'            splitcode(counter) = "PROBE' RECALL"
'        Case "ENERGY"
'            splitcode(counter) = "ENERGY' RECALL"
'        Case "NEAREST"
'            splitcode(counter) = "NEAREST' RECALL"
'
'        Case "A"
'            splitcode(counter) = "A' RECALL"
'        Case "B"
'            splitcode(counter) = "B' RECALL"
'        Case "C"
'            splitcode(counter) = "C' RECALL"
'        Case "D"
'            splitcode(counter) = "D' RECALL"
'        Case "E"
'            splitcode(counter) = "E' RECALL"
'        Case "F"
'            splitcode(counter) = "F' RECALL"
'        Case "G"
'            splitcode(counter) = "G' RECALL"
'        Case "H"
'            splitcode(counter) = "H' RECALL"
'        Case "I"
'            splitcode(counter) = "I' RECALL"
'        Case "J"
'            splitcode(counter) = "J' RECALL"
'        Case "K"
'            splitcode(counter) = "K' RECALL"
'        Case "L"
'            splitcode(counter) = "L' RECALL"
'        Case "M"
'            splitcode(counter) = "M' RECALL"
'        Case "N"
'            splitcode(counter) = "N' RECALL"
'        Case "O"
'            splitcode(counter) = "O' RECALL"
'        Case "P"
'            splitcode(counter) = "P' RECALL"
'        Case "Q"
'            splitcode(counter) = "Q' RECALL"
'        Case "R"
'            splitcode(counter) = "R' RECALL"
'        Case "S"
'            splitcode(counter) = "S' RECALL"
'        Case "T"
'            splitcode(counter) = "T' RECALL"
'        Case "U"
'            splitcode(counter) = "U' RECALL"
'        Case "V"
'            splitcode(counter) = "V' RECALL"
'        Case "W"
'            splitcode(counter) = "W' RECALL"
'        Case "X"
'            splitcode(counter) = "X' RECALL"
'        Case "Y"
'            splitcode(counter) = "Y' RECALL"
'        Case "Z"
'            splitcode(counter) = "Z' RECALL"
'
'        Case "STO"
'            splitcode(counter) = "STORE"
'        Case "BOTTOM'"
'            splitcode(counter) = "BOT'"
'        Case "COSINE"
'            splitcode(counter) = "COS"
'        Case "DEBUGGER"
'            splitcode(counter) = "DEBUG"
'        Case "TANGENT"
'            splitcode(counter) = "TAN"
'        Case "SINE"
'            splitcode(counter) = "SIN"
'        Case "EOR"
'            splitcode(counter) = "XOR"
'        Case "RETURN"
'            splitcode(counter) = "JUMP"
'        Case "HELL'"
'            splitcode(counter) = "HELLBORE'"
'    End Select
'Next

For counter = 0 To UBound(splitcode)
    If splitcode(counter) = "COLLISION" Then splitcode(counter) = "COLLISION' RECALL"
    If splitcode(counter) = "AIM" Then splitcode(counter) = "AIM' RECALL"
    If splitcode(counter) = "FRIEND" Then splitcode(counter) = "FRIEND' RECALL"
    If splitcode(counter) = "DAMAGE" Then splitcode(counter) = "DAMAGE' RECALL"
    If splitcode(counter) = "DOPPLER" Then splitcode(counter) = "DOPPLER' RECALL"
    If splitcode(counter) = "HISTORY" Then splitcode(counter) = "HISTORY' RECALL"
    If splitcode(counter) = "ID" Then splitcode(counter) = "ID' RECALL"
    If splitcode(counter) = "KILLS" Then splitcode(counter) = "KILLS' RECALL"
    If splitcode(counter) = "LOOK" Then splitcode(counter) = "LOOK' RECALL"
    If splitcode(counter) = "RANDOM" Then splitcode(counter) = "RANDOM' RECALL"
    If splitcode(counter) = "RANGE" Then splitcode(counter) = "RANGE' RECALL"
    If splitcode(counter) = "ROBOTS" Then splitcode(counter) = "ROBOTS' RECALL"
    If splitcode(counter) = "SCAN" Then splitcode(counter) = "SCAN' RECALL"
    If splitcode(counter) = "SHIELD" Then splitcode(counter) = "SHIELD' RECALL"
    If splitcode(counter) = "SPEEDX" Then splitcode(counter) = "SPEEDX' RECALL"
    If splitcode(counter) = "SPEEDY" Then splitcode(counter) = "SPEEDY' RECALL"
    If splitcode(counter) = "TEAMMATES" Then splitcode(counter) = "TEAMMATES' RECALL"
    If splitcode(counter) = "WALL" Then splitcode(counter) = "WALL' RECALL"
    If splitcode(counter) = "RADAR" Then splitcode(counter) = "RADAR' RECALL"
    If splitcode(counter) = "SIGNAL" Then splitcode(counter) = "SIGNAL' RECALL"
    If splitcode(counter) = "CHANNEL" Then splitcode(counter) = "CHANNEL' RECALL"
    If splitcode(counter) = "CHRONON" Then splitcode(counter) = "CHRONON' RECALL"
    If splitcode(counter) = "PROBE" Then splitcode(counter) = "PROBE' RECALL"
    If splitcode(counter) = "ENERGY" Then splitcode(counter) = "ENERGY' RECALL"
    If splitcode(counter) = "NEAREST" Then splitcode(counter) = "NEAREST' RECALL"

    If splitcode(counter) = "A" Then splitcode(counter) = "A' RECALL"
    If splitcode(counter) = "B" Then splitcode(counter) = "B' RECALL"
    If splitcode(counter) = "C" Then splitcode(counter) = "C' RECALL"
    If splitcode(counter) = "D" Then splitcode(counter) = "D' RECALL"
    If splitcode(counter) = "E" Then splitcode(counter) = "E' RECALL"
    If splitcode(counter) = "F" Then splitcode(counter) = "F' RECALL"
    If splitcode(counter) = "G" Then splitcode(counter) = "G' RECALL"
    If splitcode(counter) = "H" Then splitcode(counter) = "H' RECALL"
    If splitcode(counter) = "I" Then splitcode(counter) = "I' RECALL"
    If splitcode(counter) = "J" Then splitcode(counter) = "J' RECALL"
    If splitcode(counter) = "K" Then splitcode(counter) = "K' RECALL"
    If splitcode(counter) = "L" Then splitcode(counter) = "L' RECALL"
    If splitcode(counter) = "M" Then splitcode(counter) = "M' RECALL"
    If splitcode(counter) = "N" Then splitcode(counter) = "N' RECALL"
    If splitcode(counter) = "O" Then splitcode(counter) = "O' RECALL"
    If splitcode(counter) = "P" Then splitcode(counter) = "P' RECALL"
    If splitcode(counter) = "Q" Then splitcode(counter) = "Q' RECALL"
    If splitcode(counter) = "R" Then splitcode(counter) = "R' RECALL"
    If splitcode(counter) = "S" Then splitcode(counter) = "S' RECALL"
    If splitcode(counter) = "T" Then splitcode(counter) = "T' RECALL"
    If splitcode(counter) = "U" Then splitcode(counter) = "U' RECALL"
    If splitcode(counter) = "V" Then splitcode(counter) = "V' RECALL"
    If splitcode(counter) = "W" Then splitcode(counter) = "W' RECALL"
    If splitcode(counter) = "X" Then splitcode(counter) = "X' RECALL"
    If splitcode(counter) = "Y" Then splitcode(counter) = "Y' RECALL"
    If splitcode(counter) = "Z" Then splitcode(counter) = "Z' RECALL"

    If splitcode(counter) = "STO" Then splitcode(counter) = "STORE"
    If splitcode(counter) = "BOTTOM'" Then splitcode(counter) = "BOT'"
    If splitcode(counter) = "COSINE" Then splitcode(counter) = "COS"
    If splitcode(counter) = "DEBUGGER" Then splitcode(counter) = "DEBUG"
    If splitcode(counter) = "TANGENT" Then splitcode(counter) = "TAN"
    If splitcode(counter) = "SINE" Then splitcode(counter) = "SIN"
    If splitcode(counter) = "EOR" Then splitcode(counter) = "XOR"
    If splitcode(counter) = "RETURN" Then splitcode(counter) = "JUMP"
    If splitcode(counter) = "HELL'" Then splitcode(counter) = "HELLBORE'"
Next

Stage1Code = Join(splitcode)

Stage1Code = " " & Stage1Code & " " 'Adds a linebrake in the beginning and end so it won't fail to fix tokens in the start and end

' LABELS
SkipNum = -1
SplitB04 Stage1Code, splitcode

For counter = 0 To UBound(splitcode)
    Instructionn = splitcode(counter)
    If InStrB(Instructionn, ":") <> 0 Then                   'Checks if there's ":" in the instruction. If there is it's a label definition
        SkipNum = SkipNum + 1                     'If it is then
        If SkipNum > 399 Then
            MsgBox "Your robot's code exceedes 400 labels. Please reduce the number of labels.", , "Compiling Error"
            Compile = "END"
            Exit Function
        End If
        LP(SkipNum) = counter - SkipNum - 2               'Records which inst. nr. the label corresponds to
        LN(SkipNum) = Replace09(Instructionn, ":", "")   'Records the name of the label
        splitcode(counter) = ""                  'Removes the label definition from the code
    End If
Next counter

For SkipNum = 0 To SkipNum                                 'Replaces labels with instruction numbers. This is the major reason why the compiler is so sluggish
    For counter = 0 To UBound(splitcode)
        If splitcode(counter) = LN(SkipNum) Then splitcode(counter) = LP(SkipNum)
    Next counter
Next SkipNum

Stage1Code = Join(splitcode, vbCr)      'Assembles the code again with label definitions removed.

' EXTRA PROCESSING
Do While Left(Stage1Code, 1) = vbCr
    Stage1Code = Right(Stage1Code, Len(Stage1Code) - 1)
Loop

Do While InStrB(Stage1Code, vbCr & vbCr) <> 0                'removed double vbCr created from the label recorder
    Stage1Code = Replace09(Stage1Code, vbCr & vbCr, vbCr)
Loop

If Stage1Code <> "" Then
    Stage1Code = Left(Stage1Code, Len(Stage1Code) - 1)
    Stage1Code = Stage1Code & vbCr & "END"
Else
    Stage1Code = "END"
End If

Compile = Stage1Code

Exit Function

' ERROR HANDLER

CompilingError1:
MsgBox "There was a compiling error:" & vbCr & Err.Description & "." & vbCr & vbCr & "Please verify that the code you've entered is correct." & vbCr & "This is most commonly caused by nested {}-comments.", , "Compiling Error"

Compile = "END"
End Function


Private Function Inst2MagicNumber(Instruction As String) As Integer

Select Case Instruction
    Case "STORE"
        Inst2MagicNumber = 20100
    Case "AIM'"
        Inst2MagicNumber = 20330
    Case "RECALL"
        Inst2MagicNumber = 20109
    Case "LOOK'"
        Inst2MagicNumber = 20344
    Case "IFG"
        Inst2MagicNumber = 20140
    Case ">"
        Inst2MagicNumber = 20004
    Case "RANGE'"
        Inst2MagicNumber = 20329
    Case "SETINT"
        Inst2MagicNumber = 20156
    Case "SETPARAM"
        Inst2MagicNumber = 20157
    Case "<"
        Inst2MagicNumber = 20005
    Case "DUP"
        Inst2MagicNumber = 20106
    Case "CALL"
        Inst2MagicNumber = 20105
    Case "IFEG"
        Inst2MagicNumber = 20141
    Case "RADAR'"
        Inst2MagicNumber = 20343
    Case "JUMP"
        Inst2MagicNumber = 20104
    Case "+"
        Inst2MagicNumber = 20000
    Case "SCAN'"
        Inst2MagicNumber = 20345
    Case "-"
        Inst2MagicNumber = 20001
    Case "X'"
        Inst2MagicNumber = 20323
    Case "Y'"
        Inst2MagicNumber = 20324
    Case "FIRE'"
        Inst2MagicNumber = 20326
    Case "ENERGY'"
        Inst2MagicNumber = 20327
    Case "SHIELD'"
        Inst2MagicNumber = 20328
    Case "SPEEDX'"
        Inst2MagicNumber = 20331
    Case "SPEEDY'"
        Inst2MagicNumber = 20332
    Case "/"
        Inst2MagicNumber = 20003
    Case "*"
        Inst2MagicNumber = 20002
    Case "DROP"
        Inst2MagicNumber = 20101
    Case "SWAP"
        Inst2MagicNumber = 20102
    Case "ROLL"
        Inst2MagicNumber = 20103
    Case "IF"
        Inst2MagicNumber = 20107
    Case "IFE"
        Inst2MagicNumber = 20108
    Case "="
        Inst2MagicNumber = 20006
    Case "!"
        Inst2MagicNumber = 20007
    Case "NOP"
        Inst2MagicNumber = 20111
    Case "AND"
        Inst2MagicNumber = 20112
    Case "OR"
        Inst2MagicNumber = 20113
    Case "XOR"
        Inst2MagicNumber = 20114
    Case "MOD"
        Inst2MagicNumber = 20115
    Case "BEEP"
        Inst2MagicNumber = 20116
    Case "CHS"
        Inst2MagicNumber = 20117
    Case "NOT"
        Inst2MagicNumber = 20118
    Case "ARCTAN"
        Inst2MagicNumber = 20119
    Case "ABS"
        Inst2MagicNumber = 20120
    Case "SIN"
        Inst2MagicNumber = 20121
    Case "COS"
        Inst2MagicNumber = 20122
    Case "TAN"
        Inst2MagicNumber = 20123
    Case "SQRT"
        Inst2MagicNumber = 20124
    Case "ICON0"
        Inst2MagicNumber = 20125
    Case "ICON1"
        Inst2MagicNumber = 20126
    Case "ICON2"
        Inst2MagicNumber = 20127
    Case "ICON3"
        Inst2MagicNumber = 20128
    Case "ICON4"
        Inst2MagicNumber = 20129
    Case "ICON5"
        Inst2MagicNumber = 20130
    Case "ICON6"
        Inst2MagicNumber = 20131
    Case "ICON7"
        Inst2MagicNumber = 20132
    Case "ICON8"
        Inst2MagicNumber = 20133
    Case "ICON9"
        Inst2MagicNumber = 20134
    Case "PRINT"
        Inst2MagicNumber = 20135
    Case "SYNC"
        Inst2MagicNumber = 20136
    Case "VSTORE"
        Inst2MagicNumber = 20137
    Case "VRECALL"
        Inst2MagicNumber = 20138
    Case "DIST"
        Inst2MagicNumber = 20139
    Case "DEBUG"
        Inst2MagicNumber = 20142
    Case "SND0"
        Inst2MagicNumber = 20143
    Case "SND1"
        Inst2MagicNumber = 20144
    Case "SND2"
        Inst2MagicNumber = 20145
    Case "SND3"
        Inst2MagicNumber = 20146
    Case "SND4"
        Inst2MagicNumber = 20147
    Case "SND5"
        Inst2MagicNumber = 20148
    Case "SND6"
        Inst2MagicNumber = 20149
    Case "SND7"
        Inst2MagicNumber = 20150
    Case "SND8"
        Inst2MagicNumber = 20151
    Case "SND9"
        Inst2MagicNumber = 20152
    Case "INTON"
        Inst2MagicNumber = 20153
    Case "INTOFF"
        Inst2MagicNumber = 20154
    Case "RTI"
        Inst2MagicNumber = 20155
'    Case         inst2magicNumber = 20158      'SPECIALFALL    'MRB
'         "MRB"
    Case "DROPALL"
        Inst2MagicNumber = 20159
    Case "FLUSHINT"
        Inst2MagicNumber = 20160
    Case "MAX"
        Inst2MagicNumber = 20161
    Case "MIN"
        Inst2MagicNumber = 20162
    Case "ARCCOS"
        Inst2MagicNumber = 20163
    Case "ARCSIN"
        Inst2MagicNumber = 20164
    Case "A'"
        Inst2MagicNumber = 20300
    Case "B'"
        Inst2MagicNumber = 20301
    Case "C'"
        Inst2MagicNumber = 20302
    Case "D'"
        Inst2MagicNumber = 20303
    Case "E'"
        Inst2MagicNumber = 20304
    Case "F'"
        Inst2MagicNumber = 20305
    Case "G'"
        Inst2MagicNumber = 20306
    Case "H'"
        Inst2MagicNumber = 20307
    Case "I'"
        Inst2MagicNumber = 20308
    Case "J'"
        Inst2MagicNumber = 20309
    Case "K'"
        Inst2MagicNumber = 20310
    Case "L'"
        Inst2MagicNumber = 20311
    Case "M'"
        Inst2MagicNumber = 20312
    Case "N'"
        Inst2MagicNumber = 20313
    Case "O'"
        Inst2MagicNumber = 20314
    Case "P'"
        Inst2MagicNumber = 20315
    Case "Q'"
        Inst2MagicNumber = 20316
    Case "R'"
        Inst2MagicNumber = 20317
    Case "S'"
        Inst2MagicNumber = 20318
    Case "T'"
        Inst2MagicNumber = 20319
    Case "U'"
        Inst2MagicNumber = 20320
    Case "V'"
        Inst2MagicNumber = 20321
    Case "W'"
        Inst2MagicNumber = 20322
    Case "Z'"
        Inst2MagicNumber = 20325
    Case "DAMAGE'"
        Inst2MagicNumber = 20333
    Case "RANDOM'"
        Inst2MagicNumber = 20334
    Case "MISSILE'"
        Inst2MagicNumber = 20335
    Case "NUKE'"
        Inst2MagicNumber = 20336
    Case "COLLISION'"
        Inst2MagicNumber = 20337
    Case "CHANNEL'"
        Inst2MagicNumber = 20338
    Case "SIGNAL'"
        Inst2MagicNumber = 20339
    Case "MOVEX'"
        Inst2MagicNumber = 20340
    Case "MOVEY'"
        Inst2MagicNumber = 20341
'    Case         inst2magicNumber = 20342      'SPECIALFALL
'         "JOCE'"
    Case "CHRONON'"
        Inst2MagicNumber = 20346
    Case "HELLBORE'"
        Inst2MagicNumber = 20347
    Case "DRONE'"
        Inst2MagicNumber = 20348
    Case "MINE'"
        Inst2MagicNumber = 20349
    Case "LASER'"
        Inst2MagicNumber = 20350
'    Case         inst2magicNumber = 20351      'SPECIALFALL
'         "SUSIE'"
    Case "ROBOTS'"
        Inst2MagicNumber = 20352
    Case "FRIEND'"
        Inst2MagicNumber = 20353
    Case "BULLET'"
        Inst2MagicNumber = 20354
    Case "DOPPLER'"
        Inst2MagicNumber = 20355
    Case "STUNNER'"
        Inst2MagicNumber = 20356
    Case "TOP'"
        Inst2MagicNumber = 20357
    Case "BOT'"
        Inst2MagicNumber = 20358
    Case "LEFT'"
        Inst2MagicNumber = 20359
    Case "RIGHT'"
        Inst2MagicNumber = 20360
    Case "WALL'"
        Inst2MagicNumber = 20361
    Case "TEAMMATES'"
        Inst2MagicNumber = 20362
    Case "PROBE'"
        Inst2MagicNumber = 20363
    Case "HISTORY'"
        Inst2MagicNumber = 20364
    Case "ID'"
        Inst2MagicNumber = 20365
    Case "END"
        Inst2MagicNumber = 20110
    Case "KILLS'"
        Inst2MagicNumber = 20366
    Case "NEAREST'"
        Inst2MagicNumber = 20367
    Case "MEGANUKE'"
        Inst2MagicNumber = 20368
    Case Else
        Inst2MagicNumber = -32768
End Select
End Function

Private Sub go_to_line(linen As Long, editbox As RichTextBox)
'Transfers the user to a specified richtextbox's line
'programmed by Alexander Triantafyllou (BSc I.T.) alextriantf@yahoo.gr
'feel free to use it wherever you like
'
'Greetings from Athens - Greece

'(Modified by Kevin Hertzberg)

Dim charindex As Long
linen = linen - 1
charindex = SendMessage(editbox.hwnd, EM_LINEINDEX, ByVal linen, ByVal CLng(0))
editbox.SetFocus

If charindex <> -1 Then
    LockWindowUpdate RobotCode.hwnd     'LOCKS!!
    editbox.SelStart = charindex
    Dim stopchar As Long
    stopchar = InStr(charindex + 1, editbox.Text, vbCr)
    editbox.SelLength = stopchar - charindex
    LockWindowUpdate 0                  'UNLOCKS!!
End If

End Sub

' This is faster variants of the VB6 native functions Replace and Split
' Thanks to VBSpeed (http://www.xbeat.net/vbspeed/) for providing!!

Private Function Replace09(ByRef Text As String, _
    ByRef sOld As String, ByRef sNew As String, _
    Optional ByVal start As Long = 1, _
    Optional ByVal Count As Long = 2147483647, _
    Optional ByVal Compare As VbCompareMethod = vbBinaryCompare _
  ) As String
' by Jost Schwider, jost@schwider.de, 20001218

  If LenB(sOld) Then

    If Compare = vbBinaryCompare Then
      Replace09Bin Replace09, Text, Text, _
          sOld, sNew, start, Count
    Else
      Replace09Bin Replace09, Text, LCase$(Text), _
          LCase$(sOld), sNew, start, Count
    End If

  Else 'Suchstring ist leer:
    Replace09 = Text
  End If
End Function

Private Static Sub Replace09Bin(ByRef result As String, _
    ByRef Text As String, ByRef Search As String, _
    ByRef sOld As String, ByRef sNew As String, _
    ByVal start As Long, ByVal Count As Long _
  )
' by Jost Schwider, jost@schwider.de, 20001218
  Dim TextLen As Long
  Dim OldLen As Long
  Dim NewLen As Long
  Dim ReadPos As Long
  Dim WritePos As Long
  Dim CopyLen As Long
  Dim Buffer As String
  Dim BufferLen As Long
  Dim BufferPosNew As Long
  Dim BufferPosNext As Long
  
  'Ersten Treffer bestimmen:
  If start < 2 Then
    start = InStrB(Search, sOld)
  Else
    start = InStrB(start + start - 1, Search, sOld)
  End If
  If start Then
  
    OldLen = LenB(sOld)
    NewLen = LenB(sNew)
    Select Case NewLen
    Case OldLen 'einfaches Überschreiben:
    
      result = Text
      For Count = 1 To Count
        MidB$(result, start) = sNew
        start = InStrB(start + OldLen, Search, sOld)
        If start = 0 Then Exit Sub
      Next Count
      Exit Sub
    
    Case Is < OldLen 'Ergebnis wird kürzer:
    
      'Buffer initialisieren:
      TextLen = LenB(Text)
      If TextLen > BufferLen Then
        Buffer = Text
        BufferLen = TextLen
      End If
      
      'Ersetzen:
      ReadPos = 1
      WritePos = 1
      If NewLen Then
      
        'Einzufügenden Text beachten:
        For Count = 1 To Count
          CopyLen = start - ReadPos
          If CopyLen Then
            BufferPosNew = WritePos + CopyLen
            MidB$(Buffer, WritePos) = MidB$(Text, ReadPos, CopyLen)
            MidB$(Buffer, BufferPosNew) = sNew
            WritePos = BufferPosNew + NewLen
          Else
            MidB$(Buffer, WritePos) = sNew
            WritePos = WritePos + NewLen
          End If
          ReadPos = start + OldLen
          start = InStrB(ReadPos, Search, sOld)
          If start = 0 Then Exit For
        Next Count
      
      Else
      
        'Einzufügenden Text ignorieren (weil leer):
        For Count = 1 To Count
          CopyLen = start - ReadPos
          If CopyLen Then
            MidB$(Buffer, WritePos) = MidB$(Text, ReadPos, CopyLen)
            WritePos = WritePos + CopyLen
          End If
          ReadPos = start + OldLen
          start = InStrB(ReadPos, Search, sOld)
          If start = 0 Then Exit For
        Next Count
      
      End If
      
      'Ergebnis zusammenbauen:
      If ReadPos > TextLen Then
        result = LeftB$(Buffer, WritePos - 1)
      Else
        MidB$(Buffer, WritePos) = MidB$(Text, ReadPos)
        result = LeftB$(Buffer, WritePos + LenB(Text) - ReadPos)
      End If
      Exit Sub
    
    Case Else 'Ergebnis wird länger:
    
      'Buffer initialisieren:
      TextLen = LenB(Text)
      BufferPosNew = TextLen + NewLen
      If BufferPosNew > BufferLen Then
        Buffer = Space$(BufferPosNew)
        BufferLen = LenB(Buffer)
      End If
      
      'Ersetzung:
      ReadPos = 1
      WritePos = 1
      For Count = 1 To Count
        CopyLen = start - ReadPos
        If CopyLen Then
          'Positionen berechnen:
          BufferPosNew = WritePos + CopyLen
          BufferPosNext = BufferPosNew + NewLen
          
          'Ggf. Buffer vergrößern:
          If BufferPosNext > BufferLen Then
            Buffer = Buffer & Space$(BufferPosNext)
            BufferLen = LenB(Buffer)
          End If
          
          'String "patchen":
          MidB$(Buffer, WritePos) = MidB$(Text, ReadPos, CopyLen)
          MidB$(Buffer, BufferPosNew) = sNew
        Else
          'Position bestimmen:
          BufferPosNext = WritePos + NewLen
          
          'Ggf. Buffer vergrößern:
          If BufferPosNext > BufferLen Then
            Buffer = Buffer & Space$(BufferPosNext)
            BufferLen = LenB(Buffer)
          End If
          
          'String "patchen":
          MidB$(Buffer, WritePos) = sNew
        End If
        WritePos = BufferPosNext
        ReadPos = start + OldLen
        start = InStrB(ReadPos, Search, sOld)
        If start = 0 Then Exit For
      Next Count
      
      'Ergebnis zusammenbauen:
      If ReadPos > TextLen Then
        result = LeftB$(Buffer, WritePos - 1)
      Else
        BufferPosNext = WritePos + TextLen - ReadPos
        If BufferPosNext < BufferLen Then
          MidB$(Buffer, WritePos) = MidB$(Text, ReadPos)
          result = LeftB$(Buffer, BufferPosNext)
        Else
          result = LeftB$(Buffer, WritePos - 1) & MidB$(Text, ReadPos)
        End If
      End If
      Exit Sub
    
    End Select
  
  Else 'Kein Treffer:
    result = Text
  End If
End Sub

Private Sub SplitB04(Expression$, ResultSplit$(), Optional Delimiter$ = " ")
' By Chris Lucas, cdl1051@earthlink.net, 20011208
    Dim c&, SLen&, DelLen&, tmp&, Results&()

    SLen = LenB(Expression) \ 2
    DelLen = LenB(Delimiter) \ 2

    ' Bail if we were passed an empty delimiter or an empty expression
    If SLen = 0 Or DelLen = 0 Then
        ReDim Preserve ResultSplit(0 To 0)
        ResultSplit(0) = Expression
        Exit Sub
    End If

    ' Count delimiters and remember their positions
    ReDim Preserve Results(0 To SLen)
    tmp = InStr(Expression, Delimiter)

    Do While tmp
        Results(c) = tmp
        c = c + 1
        tmp = InStr(Results(c - 1) + 1, Expression, Delimiter)
    Loop

    ' Size our return array
    ReDim Preserve ResultSplit(0 To c)

    ' Populate the array
    If c = 0 Then
        ' lazy man's call
        ResultSplit(0) = Expression
    Else
        ' typical call
        ResultSplit(0) = Left$(Expression, Results(0) - 1)
        For c = 0 To c - 2
            ResultSplit(c + 1) = Mid$(Expression, _
                Results(c) + DelLen, _
                Results(c + 1) - Results(c) - DelLen)
        Next c
        ResultSplit(c + 1) = Right$(Expression, SLen - Results(c) - DelLen + 1)
    End If

End Sub



