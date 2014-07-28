VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "Comdlg32.ocx"
Begin VB.Form TournamentD 
   BackColor       =   &H00453E2E&
   Caption         =   "Tournament"
   ClientHeight    =   7035
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   7545
   Icon            =   "Tournament.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   ScaleHeight     =   469
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   503
   Begin VB.CheckBox AllowNearest 
      BackColor       =   &H00453E2E&
      Caption         =   "Allow Nearest"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   5280
      TabIndex        =   15
      Top             =   1680
      Width           =   975
   End
   Begin VB.ListBox TheDirList 
      Height          =   450
      Left            =   4440
      TabIndex        =   44
      TabStop         =   0   'False
      Top             =   4800
      Width           =   1815
      Visible         =   0   'False
   End
   Begin VB.CheckBox PrintLog 
      BackColor       =   &H00453E2E&
      Caption         =   "Print Log (slows down!)"
      ForeColor       =   &H00FAFAFA&
      Height          =   735
      Left            =   6360
      TabIndex        =   16
      Top             =   2640
      Width           =   1215
   End
   Begin VB.TextBox SlaveTextHP 
      Height          =   375
      Left            =   6600
      TabIndex        =   43
      Text            =   "12"
      Top             =   240
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CheckBox AskBeforeOverwriting 
      BackColor       =   &H00453E2E&
      Caption         =   "Ask before overwriting results file"
      ForeColor       =   &H00FFC0C0&
      Height          =   375
      Left            =   120
      TabIndex        =   18
      Top             =   6600
      Value           =   1  'Checked
      Width           =   2775
      Visible         =   0   'False
   End
   Begin MSComDlg.CommonDialog CommonDialogSelectLocation 
      Left            =   6720
      Top             =   4080
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      CancelError     =   -1  'True
      DialogTitle     =   "Please choose a location for the tournament results text file"
      FileName        =   "Tournament Results"
      Filter          =   "Text File (.txt)|*.txt|"
   End
   Begin VB.ListBox RobotList 
      Height          =   3765
      ItemData        =   "Tournament.frx":0E42
      Left            =   4440
      List            =   "Tournament.frx":0E44
      TabIndex        =   28
      TabStop         =   0   'False
      Top             =   1680
      Width           =   1815
      Visible         =   0   'False
   End
   Begin VB.CommandButton ChangeLocation 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Change"
      Height          =   255
      Left            =   6720
      Style           =   1  'Graphical
      TabIndex        =   17
      Top             =   6120
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CheckBox AllowDrones 
      BackColor       =   &H00453E2E&
      Caption         =   "Allow Drones"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   3600
      TabIndex        =   12
      Top             =   1680
      Width           =   1095
   End
   Begin VB.CheckBox CheckEnergy 
      BackColor       =   &H00453E2E&
      Caption         =   "Allow -200 > Energy"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   3600
      TabIndex        =   11
      Top             =   1200
      Width           =   1215
   End
   Begin VB.CheckBox CheckMoveAndShoot 
      BackColor       =   &H00453E2E&
      Caption         =   "Allow Move and Shoot"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   2400
      TabIndex        =   8
      Top             =   1200
      Width           =   1215
   End
   Begin VB.TextBox GRN 
      Height          =   300
      Left            =   5040
      TabIndex        =   20
      Text            =   "6"
      Top             =   4440
      Width           =   1215
   End
   Begin VB.CommandButton RemoveAll 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Remove All"
      Height          =   255
      Left            =   6360
      Style           =   1  'Graphical
      TabIndex        =   30
      TabStop         =   0   'False
      Top             =   2280
      Width           =   1095
      Visible         =   0   'False
   End
   Begin VB.CommandButton Command1 
      BackColor       =   &H00E4D2B4&
      Caption         =   "To RoboWar Folder"
      Height          =   495
      Left            =   120
      Style           =   1  'Graphical
      TabIndex        =   25
      TabStop         =   0   'False
      Top             =   5520
      Width           =   1050
      Visible         =   0   'False
   End
   Begin VB.CommandButton PrevButton 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Prev"
      Enabled         =   0   'False
      Height          =   375
      Left            =   3480
      Style           =   1  'Graphical
      TabIndex        =   21
      Top             =   6600
      Width           =   1215
   End
   Begin VB.CommandButton NextButton 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Next"
      Height          =   375
      Left            =   4920
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   6600
      Width           =   1215
   End
   Begin VB.CommandButton Run 
      BackColor       =   &H00DBC284&
      Caption         =   "Run!"
      Default         =   -1  'True
      Height          =   495
      Left            =   6360
      Style           =   1  'Graphical
      TabIndex        =   31
      Top             =   6480
      Width           =   1095
      Visible         =   0   'False
   End
   Begin VB.CommandButton RemoveRobot 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Remove Robot"
      Height          =   495
      Left            =   6360
      Style           =   1  'Graphical
      TabIndex        =   29
      TabStop         =   0   'False
      Top             =   1680
      Width           =   1095
      Visible         =   0   'False
   End
   Begin VB.CheckBox CheckNoHPLimit 
      BackColor       =   &H00453E2E&
      Caption         =   "No Hardware Points Limit"
      ForeColor       =   &H00FAFAFA&
      Height          =   375
      Left            =   5280
      TabIndex        =   14
      Top             =   1200
      Width           =   2055
   End
   Begin VB.CheckBox CheckScoring 
      BackColor       =   &H00453E2E&
      Caption         =   "Mac Scoring (4.5.2)"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   3600
      TabIndex        =   10
      Top             =   720
      Width           =   1215
   End
   Begin VB.TextBox TextHP 
      Height          =   375
      Left            =   6600
      TabIndex        =   13
      Text            =   "9"
      Top             =   720
      Width           =   735
   End
   Begin VB.CheckBox AllowLasers 
      BackColor       =   &H00453E2E&
      Caption         =   "Allow Lasers"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   2400
      TabIndex        =   9
      Top             =   1680
      Value           =   1  'Checked
      Width           =   1095
   End
   Begin VB.CommandButton AddBot 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Add Robot"
      Height          =   255
      Left            =   2400
      Style           =   1  'Graphical
      TabIndex        =   27
      TabStop         =   0   'False
      Top             =   5520
      Width           =   975
      Visible         =   0   'False
   End
   Begin VB.CommandButton AddDir 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Add Directory"
      Height          =   255
      Left            =   1230
      Style           =   1  'Graphical
      TabIndex        =   24
      TabStop         =   0   'False
      Top             =   5520
      Width           =   1080
      Visible         =   0   'False
   End
   Begin VB.DriveListBox Drive 
      Height          =   315
      Left            =   120
      TabIndex        =   22
      TabStop         =   0   'False
      Top             =   960
      Width           =   1215
      Visible         =   0   'False
   End
   Begin VB.OptionButton OptionMortal 
      BackColor       =   &H00453E2E&
      Caption         =   "Motral"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   120
      TabIndex        =   1
      Top             =   600
      Value           =   -1  'True
      Width           =   1215
   End
   Begin VB.OptionButton OptionTitan 
      BackColor       =   &H00453E2E&
      Caption         =   "Titan"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   120
      TabIndex        =   2
      TabStop         =   0   'False
      Top             =   1080
      Width           =   1215
   End
   Begin VB.OptionButton OptionLittleLeague 
      BackColor       =   &H00453E2E&
      Caption         =   "Little League"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   120
      TabIndex        =   3
      TabStop         =   0   'False
      Top             =   1560
      Width           =   1215
   End
   Begin VB.OptionButton OptionTeam 
      BackColor       =   &H00453E2E&
      Caption         =   "Team"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   120
      TabIndex        =   4
      Top             =   2040
      Width           =   1215
   End
   Begin VB.OptionButton OptionAustralian 
      BackColor       =   &H00453E2E&
      Caption         =   """Australian Rules"""
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   120
      TabIndex        =   5
      Top             =   2520
      Width           =   1215
   End
   Begin VB.OptionButton OptionCustom 
      BackColor       =   &H00453E2E&
      Caption         =   "Custom"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   120
      TabIndex        =   6
      Top             =   3000
      Width           =   1215
   End
   Begin VB.CheckBox CheckWinnerCircle 
      BackColor       =   &H00453E2E&
      Caption         =   "Winners' Circle"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   2400
      TabIndex        =   7
      Top             =   720
      Value           =   1  'Checked
      Width           =   1215
   End
   Begin VB.DirListBox Directory 
      Height          =   3690
      Left            =   120
      TabIndex        =   23
      TabStop         =   0   'False
      Top             =   1680
      Width           =   2175
      Visible         =   0   'False
   End
   Begin VB.FileListBox File 
      Height          =   3795
      Left            =   2400
      Pattern         =   "*.RWR"
      TabIndex        =   26
      TabStop         =   0   'False
      Top             =   1680
      Width           =   1935
      Visible         =   0   'False
   End
   Begin VB.TextBox DuelsNumber 
      Height          =   300
      Left            =   5040
      TabIndex        =   19
      Text            =   "10"
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label HPMaster 
      BackColor       =   &H00453E2E&
      Caption         =   "Allowed Hardware Points"
      ForeColor       =   &H00FAFAFA&
      Height          =   375
      Left            =   5280
      TabIndex        =   42
      Top             =   240
      Width           =   1215
      Visible         =   0   'False
   End
   Begin VB.Label ResultsSavedIn 
      BackStyle       =   0  'Transparent
      Caption         =   "Results will be saved in"
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   120
      TabIndex        =   41
      Top             =   6120
      Width           =   1695
      Visible         =   0   'False
   End
   Begin VB.Label SavedInFolder 
      BackStyle       =   0  'Transparent
      Caption         =   "C:\Program Files\RoboWar 5\Tournament Results.txt"
      ForeColor       =   &H00FFFFFF&
      Height          =   435
      Left            =   1920
      TabIndex        =   40
      Top             =   6120
      Width           =   4650
      Visible         =   0   'False
      WordWrap        =   -1  'True
   End
   Begin VB.Label GRTimes 
      BackColor       =   &H00453E2E&
      Caption         =   "Times"
      ForeColor       =   &H00FAFAFA&
      Height          =   255
      Left            =   5520
      TabIndex        =   39
      Top             =   4800
      Width           =   735
   End
   Begin VB.Label Label1 
      BackColor       =   &H00453E2E&
      Caption         =   "Group Rounds - Robot meets each other"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   4560
      TabIndex        =   38
      Top             =   3960
      Width           =   1695
   End
   Begin VB.Label DuelTimes 
      BackColor       =   &H00453E2E&
      Caption         =   "Times"
      ForeColor       =   &H00FAFAFA&
      Height          =   255
      Left            =   5520
      TabIndex        =   37
      Top             =   3600
      Width           =   735
   End
   Begin VB.Label LabelDuels 
      BackColor       =   &H00453E2E&
      Caption         =   "Duels - Robot meets each other"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   4560
      TabIndex        =   36
      Top             =   2760
      Width           =   1695
   End
   Begin VB.Label TypeLabel 
      BackStyle       =   0  'Transparent
      Caption         =   "Type"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   18
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H8000000A&
      Height          =   495
      Left            =   120
      TabIndex        =   34
      Top             =   0
      Width           =   1095
   End
   Begin VB.Shape Rectangle 
      BorderColor     =   &H00FFFFFF&
      Height          =   2295
      Left            =   2160
      Top             =   120
      Width           =   5295
   End
   Begin VB.Label CustomOptions 
      BackStyle       =   0  'Transparent
      Caption         =   "Custom Options"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   18
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H8000000A&
      Height          =   375
      Left            =   2280
      TabIndex        =   33
      Top             =   240
      Width           =   3615
   End
   Begin VB.Label LabelHP 
      BackColor       =   &H00453E2E&
      Caption         =   "Allowed Hardware Points"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   5280
      TabIndex        =   32
      Top             =   720
      Width           =   1215
   End
   Begin VB.Label ChooseRobots 
      BackStyle       =   0  'Transparent
      Caption         =   "Choose Robots"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   18
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H8000000A&
      Height          =   495
      Left            =   120
      TabIndex        =   35
      Top             =   120
      Width           =   3495
      Visible         =   0   'False
   End
End
Attribute VB_Name = "TournamentD"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Type Robot   'Private      'Used to load robots
    Energy As Integer
    Damage As Integer
    Shield As Integer
    Prosessor As Byte
    NNE As Byte
    Turret As Byte
    Bullets As Byte
    Missiles As Byte
    TacNukes As Byte
    Hellbores As Byte
    Mines As Byte
    Stunners As Byte
    Drones As Byte
    Lasers As Byte
    Probes As Byte
    Reserved As Long
    ShieldIcon As Byte
    DeathIcon As Byte
    HitIcon As Byte
    BlockIcon As Byte
    CollisionIcon As Byte
End Type

Dim CheckCheat As String
Dim RunningTeams As Boolean

Public DuelsN As Long 'integer
Public GRNumber As Long 'integer

Private Sub AddBot_Click()
Dim Press As String
Dim CancelAdd As Integer
Dim Decided As Integer

Dim res As Byte

If File.FileName = "" Then Exit Sub

RepeatCheatChecking:

If DoesCheat(File.Path & "\" & File.FileName) Then
    If CheckCheat = "The robot seems to be broken, and cannot be loaded." Then
        MsgBox CheckCheat
        Exit Sub
    ElseIf CheckCheat = "The robot has disallowed hardware values." Then
        CancelAdd = -1
        Press = "Press Cancel to disable hardware checking"
        Decided = -1
        Press = vbCr & vbCr & "(" & Press & ".)"
    ElseIf CheckCheat = "The robot has has more hardwarepoints than the max hardwarepoints." Then
        CancelAdd = -1
        Select Case TextHP
            Case Is <= 2
                Press = "Press Cancel to change to Mortal"
                Decided = 9
            Case Is <= 9
                Press = "Press Cancel to change to Titan"
                Decided = 23
        End Select
        Press = vbCr & vbCr & "(" & Press & ".)"
    ElseIf CheckCheat = "The robot uses Lasers. You've set them to be dissallowed." Then
        CancelAdd = -1
        Press = "Press Cancel if you would like to allow lasers"
        Decided = -2
        Press = vbCr & vbCr & "(" & Press & ".)"
    ElseIf CheckCheat = "The robot uses Drones. You've set them to be dissallowed." Then
        CancelAdd = -1
        Press = "Press Cancel if you would like to allow drones"
        Decided = -3
        Press = vbCr & vbCr & "(" & Press & ".)"
    End If

    res = MsgBox(CheckCheat & vbCr & "Do you want to allow it to compete in the tournament anyway?" & Press, _
    vbYesNo + CancelAdd + vbInformation, "The Robot " & Left$(File.FileName, Len(File.FileName) - 4) & " doesn't follow the choosen set of rules.")
    
    If res = vbNo Then
        Exit Sub
    ElseIf res = vbCancel Then
        Select Case Decided
            Case Is > 0
                TextHP = Decided
            Case -3
                AllowDrones.Value = 1
            Case -2
                AllowLasers.Value = 1
            Case -1
                CheckNoHPLimit.Value = 1
        End Select
        GoTo RepeatCheatChecking
    End If
End If

RobotList.AddItem Left$(File.FileName, Len(File.FileName) - 4)
TheDirList.AddItem Directory.Path

End Sub

Private Sub AddTeamMember(TheTeamMember As String)
Dim Press As String
Dim CancelAdd As Integer
Dim Decided As Integer

Dim res As Byte

RepeatCheatChecking:

If DoesCheat(File.Path & "\" & TheTeamMember & ".RWR") Then
    If CheckCheat = "The robot seems to be broken, and cannot be loaded." Then
        MsgBox CheckCheat
        Exit Sub
    ElseIf CheckCheat = "The robot has disallowed hardware values." Then
        CancelAdd = -1
        Press = "Press Cancel to disable hardware checking"
        Decided = -1
        Press = vbCr & vbCr & "(" & Press & ".)"
    ElseIf CheckCheat = "The robot has has more hardwarepoints than the max hardwarepoints." Then
        CancelAdd = -1
        Select Case SlaveTextHP
            Case Is <= 2
                Press = "Press Cancel to change to Mortal"
                Decided = 9
            Case Is <= 9
                Press = "Press Cancel to change to Titan"
                Decided = 23
        End Select
        Press = vbCr & vbCr & "(" & Press & ".)"
    ElseIf CheckCheat = "The robot uses Lasers. You've set them to be dissallowed." Then
        CancelAdd = -1
        Press = "Press Cancel if you would like to allow lasers"
        Decided = -2
        Press = vbCr & vbCr & "(" & Press & ".)"
    ElseIf CheckCheat = "The robot uses Drones. You've set them to be dissallowed." Then
        CancelAdd = -1
        Press = "Press Cancel if you would like to allow drones"
        Decided = -3
        Press = vbCr & vbCr & "(" & Press & ".)"
    End If

    res = MsgBox(CheckCheat & vbCr & "Do you want to allow it to compete in the tournament anyway?" & Press, _
    vbYesNo + CancelAdd + vbInformation, "The Robot " & Left$(File.FileName, Len(File.FileName) - 4) & " doesn't follow the choosen set of rules.")
    
    If res = vbNo Then
        Exit Sub
    ElseIf res = vbCancel Then
        Select Case Decided
            Case Is > 0
                TextHP = Decided
            Case -3
                AllowDrones.Value = 1
            Case -2
                AllowLasers.Value = 1
            Case -1
                CheckNoHPLimit.Value = 1
        End Select
        GoTo RepeatCheatChecking
    End If
End If

RobotList.AddItem TheTeamMember
TheDirList.AddItem Directory.Path

End Sub

Private Sub AddDir_Click()
Dim counter As Integer

If RunningTeams Then
    On Error GoTo errhandler
    
    Dim Cstart As Long
    Const Crec = 116
    
    Dim TeamTag As String * 765
    
    Dim sTeam() As String

    For counter = 0 To File.ListCount - 1
        File.Selected(counter) = True
        Open File.Path & "\" & File.FileName For Binary As 1
        Get 1, Crec, Cstart
        Get 1, Cstart, TeamTag
        Close 1
        sTeam = Split(TeamTag, "\", 4)
        If sTeam(0) = "#!!Master" Then
            AddBot_Click

            If Dir(File.Path & "\" & sTeam(1) & ".RWR") = "" Then
                MsgBox "The master '" & Left$(File.FileName, Len(File.FileName) - 4) & "' is missing its servant '" & sTeam(1) & "'." & vbCr & "In order to run a team tournament this must be corrected.", vbExclamation, "Can't run Team Tournament"
                RemoveAll_Click
                Exit Sub
            End If
            
            AddTeamMember (sTeam(1))
            If Trim$(sTeam(2)) = "" Then
                AddTeamMember (sTeam(1))
            Else
                If Dir(File.Path & "\" & sTeam(2) & ".RWR") = "" Then
                    MsgBox "The master '" & Left$(File.FileName, Len(File.FileName) - 4) & "' is missing its servant '" & sTeam(2) & "'." & vbCr & "In order to run a team tournament this must be corrected.", vbExclamation, "Can't run Team Tournament"
                    RemoveAll_Click
                    Exit Sub
                End If
                AddTeamMember (sTeam(2))
            End If
        End If
    Next counter
Else
'''''''''''''''''''''''''''''''''''''''''''''''''''''
    For counter = 0 To File.ListCount - 1
        File.Selected(counter) = True
        AddBot_Click
    Next counter
End If

Exit Sub

errhandler:
MsgBox "Error with The master '" & Left$(File.FileName, Len(File.FileName) - 4) & "'" & vbCr & "This is most commonly caused that it's tags are not correctly written." & vbCr & "Please check the robots Team Tag and try again." & vbCr & vbCr & _
"The Team tag should be placed as the first line in the Master Robot and look like this:" & vbCr & _
vbTab & "#!!Master\Name of first Servant\Name of second Servant\" & vbCr & vbCr & _
"Correct: " & vbTab & vbTab & "#!!Master\MyMember1\MyMember2\" & vbCr & vbCr & _
"Incorrect: " & vbTab & "#!!Master\MyMember1.RWR\MyMember2.RWR\" & vbCr & _
"Incorrect: " & vbTab & "#!Master\MyMember1\MyMember2\" & vbCr & _
"Incorrect: " & vbTab & "#!!Master\MyMember1\MyMember2" _
, vbExclamation, "Can't run Team Tournament"
RemoveAll_Click
Close 1

End Sub

Private Sub AllowDrones_Click()
OptionCustom.Value = True
End Sub

Private Sub AllowLasers_Click()
OptionCustom.Value = True
End Sub

'Private Sub AllowNearest_Click()   'Creates interface bug
'OptionCustom.Value = True
'End Sub

Private Sub AskBeforeOverwriting_Click()
Dim valu As Integer
valu = -(AskBeforeOverwriting.Value = 1)
Put 7, 3500, valu
End Sub

Private Sub ChangeLocation_Click()
On Error GoTo didcancel
CommonDialogSelectLocation.InitDir = App.Path   'Nytt
CommonDialogSelectLocation.ShowSave

SavedInFolder = CommonDialogSelectLocation.FileName
didcancel:
End Sub

Private Sub CheckEnergy_Click()
OptionCustom.Value = True
End Sub

Private Sub CheckMoveAndShoot_Click()
OptionCustom.Value = True
End Sub

Private Sub CheckNoHPLimit_Click()
OptionCustom.Value = True

TextHP.Enabled = Not TextHP.Enabled
SlaveTextHP.Enabled = TextHP.Enabled
End Sub

Private Sub CheckScoring_Click()
OptionCustom.Value = True
End Sub

'Private Sub CheckWinnerCircle_Click()
''OptionCustom.Value = True
'End Sub

Private Sub Command1_Click()
File.Path = App.Path
Directory.Path = App.Path
Drive.Drive = App.Path
End Sub

Private Sub Directory_Change()
File.Path = Directory.Path
'If RobotList.ListCount > 0 Then RemoveAll_Click
End Sub

Private Sub Drive_Change()
Directory.Path = Drive.Drive
File.Path = Drive.Drive
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
If KeyCode = vbKeyReturn And NextButton.Visible Then NextButton_Click
If KeyCode = vbKeyBack And PrevButton.Visible Then PrevButton_Click

End Sub

'Private Sub DuelsNumber_Change()
'
'If Val(DuelsNumber.Text) < 1 Or Val(DuelsNumber.Text) > 255 Then
'MsgBox "Robot must meet each other 1 to 255 times."
'DuelsN = 10
'DuelsNumber.Text = 10
'
'Else
'DuelsN = Val(DuelsNumber.Text)
'End If
'
'End Sub

Private Sub GRN_LostFocus()

If Val(GRN.Text) < 0 Or Val(GRN.Text) > 2147483647 Then
MsgBox "Robot must meet each other 0 to 2147483647 times."
GRNumber = 6
GRN.Text = 6

Else
GRNumber = Val(GRN.Text)
End If

End Sub

Private Sub DuelsNumber_LostFocus()

If Val(DuelsNumber.Text) < 0 Or Val(DuelsNumber.Text) > 2147483647 Then
MsgBox "Robot must meet each other 0 to 2147483647 times."
DuelsN = 10
DuelsNumber.Text = 10

Else
DuelsN = Val(DuelsNumber.Text)
End If

End Sub

Private Sub File_DblClick()
If Not RunningTeams Then AddBot_Click
End Sub

Private Sub Form_Load()
'Me.Show
'
'MsgBox "Note about the tournament engine:" _
'        & vbCr & vbCr & vbTab & "You can only choose robots from ONE folder." _
'        & vbCr & vbCr & vbTab & "You can't run with fewer than 6 robots."

DuelsN = 10 '10
GRNumber = 6 '6

SavedInFolder.Caption = App.Path & "\Tournament Results.txt"
'ChangeLocation.Left = 135 + SavedInFolder.Width

Dim valu As Integer
Get 7, 3500, valu
AskBeforeOverwriting.Value = valu
End Sub

Private Sub NextButton_Click()
DuelsNumber.Enabled = False 'Disk
GRN.Enabled = False 'Disk

ResultsSavedIn.Visible = True
ChangeLocation.Visible = True
SavedInFolder.Visible = True
AskBeforeOverwriting.Visible = True
AllowNearest.Visible = False
ChooseRobots.Visible = True
Drive.Visible = True
Directory.Visible = True
AddDir.Visible = True
File.Visible = True
AddBot.Visible = True
RobotList.Visible = True
RemoveRobot.Visible = True
RemoveAll.Visible = True
'PrintLog.Visible = True
Run.Visible = True
PrevButton.Enabled = True
Command1.Visible = True

Rectangle.Visible = False
TypeLabel.Visible = False
OptionMortal.Visible = False
OptionTitan.Visible = False
OptionLittleLeague.Visible = False
OptionTeam.Visible = False
OptionAustralian.Visible = False
OptionCustom.Visible = False
CustomOptions.Visible = False
'CheckWinnerCircle.Visible = False
AllowLasers.Visible = False
AllowDrones.Visible = False
'CheckScoring.Visible = False
'CheckMoveAndShoot.Visible = False
'CheckEnergy.Visible = False
'LabelHP.Visible = False
'TextHP.Visible = False
'CheckNoHPLimit.Visible = False
'LabelChrononLimit.Visible = False
'TextChrononLimit.Visible = False
NextButton.Enabled = False

End Sub

Private Sub OptionAustralian_Click()
CheckNoHPLimit.Value = 1
TextHP.Enabled = False
OptionAustralian.Value = True
CheckWinnerCircle.Value = 1


CheckScoring.Visible = True
CheckWinnerCircle.Visible = True
Label1.Visible = True
GRN.Visible = True
GRTimes.Visible = True
HPMaster.Visible = False
SlaveTextHP.Visible = False

LabelHP.Left = 352  '352
LabelHP.Width = 81  'standard 81
LabelHP.Caption = "Allowed Hardware Points"

AddBot.Enabled = True
RemoveRobot.Enabled = True
RunningTeams = False
End Sub

Private Sub OptionLittleLeague_Click()
TextHP.Text = 2
TextHP.Enabled = True
CheckNoHPLimit.Value = 0
CheckWinnerCircle.Value = 1

OptionLittleLeague.Value = True

CheckScoring.Visible = True
CheckWinnerCircle.Visible = True
Label1.Visible = True
GRN.Visible = True
GRTimes.Visible = True
HPMaster.Visible = False
SlaveTextHP.Visible = False
AllowNearest.Value = 0

LabelHP.Left = 352  '352
LabelHP.Width = 81  'standard 81
LabelHP.Caption = "Allowed Hardware Points"

AddBot.Enabled = True
RemoveRobot.Enabled = True
RunningTeams = False
End Sub

Private Sub OptionMortal_Click()
TextHP.Enabled = True
TextHP.Text = 9
CheckNoHPLimit.Value = 0
CheckWinnerCircle.Value = 1
OptionMortal.Value = True

CheckScoring.Visible = True
CheckWinnerCircle.Visible = True
Label1.Visible = True
GRN.Visible = True
GRTimes.Visible = True
HPMaster.Visible = False
SlaveTextHP.Visible = False
AllowNearest.Value = 1

LabelHP.Left = 352  '352
LabelHP.Width = 81  'standard 81
LabelHP.Caption = "Allowed Hardware Points"

AddBot.Enabled = True
RemoveRobot.Enabled = True
RunningTeams = False
End Sub

Private Sub OptionTeam_Click()
CheckScoring.Visible = False
CheckWinnerCircle.Visible = False
Label1.Visible = False
GRN.Visible = False
GRTimes.Visible = False
HPMaster.Visible = True
SlaveTextHP.Visible = True
TextHP.Enabled = True
TextHP.Text = 12
SlaveTextHP.Enabled = True
SlaveTextHP.Text = 9
CheckNoHPLimit.Value = 0
OptionTeam.Value = True
AllowNearest.Value = 1

LabelHP.Left = 344  '352
LabelHP.Width = 89  'standard 81
LabelHP.Caption = "Allowed Hardware Points for Masters"
RemoveAll_Click

AddBot.Enabled = False
RemoveRobot.Enabled = False
RunningTeams = True
End Sub

Private Sub OptionTitan_Click()
TextHP.Text = 23
TextHP.Enabled = True
CheckNoHPLimit.Value = 0
OptionTitan.Value = True

CheckScoring.Visible = True
CheckWinnerCircle.Visible = True
Label1.Visible = True
GRN.Visible = True
GRTimes.Visible = True
HPMaster.Visible = False
SlaveTextHP.Visible = False
AllowNearest.Value = 0

LabelHP.Left = 352  '352
LabelHP.Width = 81  'standard 81
LabelHP.Caption = "Allowed Hardware Points"

AddBot.Enabled = True
RemoveRobot.Enabled = True
RunningTeams = False
End Sub

Private Sub PrevButton_Click()
DuelsNumber.Enabled = True 'Disk
GRN.Enabled = True 'Disk

SavedInFolder.Visible = False
ResultsSavedIn.Visible = False
ChangeLocation.Visible = False
AskBeforeOverwriting.Visible = False
AllowNearest.Visible = True
ChooseRobots.Visible = False
Drive.Visible = False
Directory.Visible = False
AddDir.Visible = False
File.Visible = False
AddBot.Visible = False
RobotList.Visible = False
RemoveRobot.Visible = False
RemoveAll.Visible = False
'PrintLog.Visible = False
Run.Visible = False
PrevButton.Enabled = False
Command1.Visible = False

Rectangle.Visible = True
TypeLabel.Visible = True
OptionMortal.Visible = True
OptionTitan.Visible = True
OptionLittleLeague.Visible = True
OptionTeam.Visible = True
OptionAustralian.Visible = True
OptionCustom.Visible = True
CustomOptions.Visible = True
'CheckWinnerCircle.Visible = True
AllowLasers.Visible = True
AllowDrones.Visible = True
'CheckScoring.Visible = True
'CheckMoveAndShoot.Visible = True
'CheckEnergy.Visible = True
LabelHP.Visible = True
TextHP.Visible = True
'CheckNoHPLimit.Visible = True
'LabelChrononLimit.Visible = True
'TextChrononLimit.Visible = True
NextButton.Enabled = True
End Sub

Private Sub RemoveAll_Click()
Dim counter As Integer

For counter = 0 To RobotList.ListCount - 1
RobotList.RemoveItem (0)
TheDirList.RemoveItem (0)
Next counter

'Directory.Enabled = true
'Drive.Enabled = true
End Sub

Private Sub RemoveRobot_Click()
If RobotList.ListIndex <> -1 Then
    Dim templistindex As Long
    templistindex = RobotList.ListIndex
    RobotList.RemoveItem templistindex
    TheDirList.RemoveItem templistindex
    
    If RobotList.ListCount <> 0 Then RobotList.Selected(templistindex) = True
End If

End Sub

Private Sub RobotList_DblClick()
If Not RunningTeams Then RemoveRobot_Click
End Sub

Private Sub Run_Click()
If CreatingLog.Visible Then
    MsgBox "You can not run a tournament while a log is being printed. Please cancel the printing of the log before running a new tournament.", , "Tournament Log"
    Exit Sub
End If

If SlaveTextHP.Visible Then
    If RobotList.ListCount < 6 Then
        MsgBox "You need at least to choose at least 2 teams to run a tournament.", , "Can't run tournanent"
        Exit Sub
    End If

    If Dir(SavedInFolder) <> "" And AskBeforeOverwriting.Value = 1 Then
        If MsgBox("A file with the name " & SavedInFolder & " already exits." & vbCr & "Do you want to replace it?", vbYesNo, "Save Tournament Results") = vbNo Then Exit Sub
    End If
    
    MainWindow.BattleHaltButton.Visible = False
    MainWindow.StopTournament.Visible = True
    
    MainWindow.InizTeamTournament
Else
    If GRNumber = 0 And DuelsN = 0 Then
        MsgBox "You need at least 1 duel round per robot or 1 groupround per robot to run a tournament.", , "Can't run tournanent"
        Exit Sub
    ElseIf RobotList.ListCount < 2 Then
        MsgBox "You need at least to choose at least 2 robots to run a tournament.", , "Can't run tournanent"
        Exit Sub
    ElseIf RobotList.ListCount < 6 And GRNumber <> 0 Then
        MsgBox "You need at least to choose at least 6 robots to run a tournament with grouprounds.", , "Can't run tournanent"
        Exit Sub
    End If
    
    If CheckWinnerCircle.Value = 1 And RobotList.ListCount < 7 Then
        If MsgBox("You must have at least 7 robots to run a tournament with a Winner Circle" & vbCr & _
        "Do you want to run without Winners Circle?", vbYesNo, "Can't run with Winner Cirle") = vbNo Then
            Exit Sub
        Else
            CheckWinnerCircle.Value = 0
        End If
    End If
    
    If Dir(SavedInFolder) <> "" And AskBeforeOverwriting.Value = 1 Then
        If MsgBox("A file with the name " & SavedInFolder & " already exits." & vbCr & "Do you want to replace it?", vbYesNo, "Save Tournament Results") = vbNo Then Exit Sub
    End If
    
    MainWindow.BattleHaltButton.Visible = False
    MainWindow.StopTournament.Visible = True
        
    'MainWindow.InizTournament      'borde inte den stå efter att scoren blivit raderade?
    
'    Dim counter As Integer
'
'    For counter = 0 To TournamentD.RobotList.ListCount - 1  'Sets all combatants score to 0
'        TournamentD.RobotList.ItemData(counter) = 0
'    Next counter
    
    MainWindow.InizTournament
End If
End Sub

Private Sub TextHP_Change()
OptionCustom.Value = True
End Sub

Private Function DoesCheat(ToBeChecked As String) As Boolean
Dim TheRobot As Robot

Open ToBeChecked For Binary As #254

    Get #254, , TheRobot
'
    If MainWindow.CheckInvalid(TheRobot.BlockIcon) Or MainWindow.CheckInvalid(TheRobot.CollisionIcon) Or _
    MainWindow.CheckInvalid(TheRobot.DeathIcon) Or MainWindow.CheckInvalid(TheRobot.HitIcon) Or MainWindow.CheckInvalid(TheRobot.ShieldIcon) Or _
    MainWindow.CheckInvalid(TheRobot.Hellbores) Or _
    MainWindow.CheckInvalid(TheRobot.Lasers) Or MainWindow.CheckInvalid(TheRobot.Mines) Or MainWindow.CheckInvalid(TheRobot.Missiles) Or _
    MainWindow.CheckInvalid(TheRobot.Probes) Or MainWindow.CheckInvalid(TheRobot.Stunners) Or _
    MainWindow.CheckInvalid(TheRobot.TacNukes) Then
        CheckCheat = "The robot seems to be broken, and cannot be loaded."
        DoesCheat = True
        Close #254
        Exit Function
    End If

Close #254

CheckCheat = ""

Dim HWCounter As Integer
If CheckNoHPLimit.Value = 0 Then

'Energy

Select Case TheRobot.Energy
 Case 150
    HWCounter = 3
 Case 100
    HWCounter = 2
 Case 60
    HWCounter = 1
 Case 40
 Case Else
    CheckCheat = "The robot has disallowed hardware values."
End Select
''Damage

Select Case TheRobot.Damage
 Case 150
    HWCounter = HWCounter + 3
 Case 100
    HWCounter = HWCounter + 2
 Case 60
    HWCounter = HWCounter + 1
 Case 30
 Case Else
    CheckCheat = "The robot has disallowed hardware values."
End Select
''Shield

Select Case TheRobot.Shield
 Case 100
    HWCounter = HWCounter + 3
 Case 50
    HWCounter = HWCounter + 2
 Case 25
    HWCounter = HWCounter + 1
 Case 0
 Case Else
    CheckCheat = "The robot has disallowed hardware values."
End Select
''Processor Speed

Select Case TheRobot.Prosessor
 Case 50
    HWCounter = HWCounter + 4
 Case 30
    HWCounter = HWCounter + 3
 Case 15
    HWCounter = HWCounter + 2
 Case 10
    HWCounter = HWCounter + 1
 Case 5
 Case Else
    CheckCheat = "The robot has disallowed hardware values."
End Select
''Bullets

'Select Case TheRobot.Bullets
' Case 2
'    HWCounter = HWCounter + 2
' Case 1
'    HWCounter = HWCounter + 1
' Case 0
' Case Else
'    CheckCheat = "The robot has disallowed hardware values."
'End Select

HWCounter = HWCounter + Sgn(TheRobot.Drones) + _
            TheRobot.Hellbores + TheRobot.Lasers + TheRobot.Mines + TheRobot.Missiles + _
            TheRobot.Probes + TheRobot.Stunners + TheRobot.TacNukes + _
            TheRobot.Bullets
            
If CheckCheat <> "The robot has disallowed hardware values." Then
    If TextHP.Text < HWCounter Then CheckCheat = "The robot has has more hardwarepoints than the max hardwarepoints."
    If TheRobot.Drones <> 0 And AllowDrones.Value = 0 Then CheckCheat = "The robot uses Drones. You've set them to be dissallowed."
    If TheRobot.Lasers <> 0 And AllowLasers.Value = 0 Then CheckCheat = "The robot uses Lasers. You've set them to be dissallowed."
End If

End If  'hwlimit

DoesCheat = CheckCheat <> ""
End Function
