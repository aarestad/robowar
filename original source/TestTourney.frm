VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "Comdlg32.ocx"
Begin VB.Form TestTourney 
   BackColor       =   &H005A413A&
   Caption         =   "Test Robot"
   ClientHeight    =   7485
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   8655
   Icon            =   "TestTourney.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   ScaleHeight     =   499
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   577
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox TheDirList 
      Height          =   450
      Left            =   6000
      TabIndex        =   29
      TabStop         =   0   'False
      Top             =   1920
      Width           =   2415
      Visible         =   0   'False
   End
   Begin VB.CheckBox PrintLog 
      BackColor       =   &H005A413A&
      Caption         =   "Print Log (slows down!)"
      ForeColor       =   &H00FAFAFA&
      Height          =   615
      Left            =   2280
      TabIndex        =   28
      Top             =   3840
      Width           =   1095
   End
   Begin VB.OptionButton NormalTest 
      BackColor       =   &H005A413A&
      Caption         =   "Normal"
      ForeColor       =   &H00FAFAFA&
      Height          =   255
      Left            =   2520
      TabIndex        =   26
      Top             =   3120
      Value           =   -1  'True
      Width           =   825
   End
   Begin VB.CommandButton ChangeLocation 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Change"
      Height          =   255
      Left            =   6720
      Style           =   1  'Graphical
      TabIndex        =   22
      Top             =   7080
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.CheckBox CheckScoring 
      BackColor       =   &H005A413A&
      Caption         =   "Mac Scoring"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   2280
      TabIndex        =   21
      Top             =   5160
      Width           =   975
   End
   Begin VB.CheckBox MandS 
      BackColor       =   &H005A413A&
      Caption         =   "Allow Move and Shoot"
      ForeColor       =   &H00FAFAFA&
      Height          =   615
      Left            =   2280
      TabIndex        =   20
      Top             =   4560
      Width           =   1095
   End
   Begin VB.CommandButton RWDir 
      BackColor       =   &H00E4D2B4&
      Caption         =   "To RoboWar Directory"
      Height          =   255
      Left            =   120
      Style           =   1  'Graphical
      TabIndex        =   18
      Top             =   5400
      Width           =   1815
   End
   Begin VB.CommandButton Run 
      BackColor       =   &H00DBC284&
      Caption         =   "Run"
      Height          =   495
      Left            =   7800
      Style           =   1  'Graphical
      TabIndex        =   17
      Top             =   6840
      Width           =   735
   End
   Begin VB.CommandButton RemoveRobot 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Remove Robot"
      Height          =   495
      Left            =   6000
      Style           =   1  'Graphical
      TabIndex        =   16
      Top             =   6525
      Width           =   735
   End
   Begin VB.CommandButton RemoveAll 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Remove All"
      Height          =   495
      Left            =   6840
      Style           =   1  'Graphical
      TabIndex        =   15
      Top             =   6525
      Width           =   735
   End
   Begin VB.PictureBox RobotPict 
      Appearance      =   0  'Flat
      BackColor       =   &H00EFEFE0&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   480
      Left            =   2880
      ScaleHeight     =   480
      ScaleWidth      =   480
      TabIndex        =   14
      Top             =   1440
      Width           =   480
      Visible         =   0   'False
   End
   Begin VB.TextBox GroupNR 
      Height          =   285
      Left            =   1680
      TabIndex        =   9
      Text            =   "20"
      Top             =   6240
      Width           =   615
   End
   Begin VB.TextBox DuelsNR 
      Height          =   285
      Left            =   120
      TabIndex        =   8
      Text            =   "20"
      Top             =   6240
      Width           =   615
   End
   Begin VB.CommandButton AddAll 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose all as opponents"
      Height          =   495
      Left            =   4800
      Style           =   1  'Graphical
      TabIndex        =   7
      Top             =   6525
      Width           =   1095
   End
   Begin VB.CommandButton Add 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose for opponent"
      Height          =   495
      Left            =   3480
      Style           =   1  'Graphical
      TabIndex        =   6
      Top             =   6525
      Width           =   975
   End
   Begin VB.CommandButton Testing 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose for testing"
      Height          =   495
      Left            =   2520
      Style           =   1  'Graphical
      TabIndex        =   4
      Top             =   840
      Width           =   855
   End
   Begin VB.ListBox RobotList 
      Height          =   5715
      Left            =   6000
      TabIndex        =   3
      Top             =   720
      Width           =   2415
   End
   Begin VB.FileListBox File1 
      Height          =   5745
      Left            =   3480
      Pattern         =   "*.RWR"
      TabIndex        =   2
      Top             =   720
      Width           =   2415
   End
   Begin VB.DirListBox Dir1 
      Height          =   4590
      Left            =   120
      TabIndex        =   1
      Top             =   720
      Width           =   2055
   End
   Begin VB.DriveListBox Drive1 
      Height          =   315
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   1215
   End
   Begin MSComDlg.CommonDialog CommonDialogSelectLocation 
      Left            =   2400
      Top             =   2280
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      CancelError     =   -1  'True
      DialogTitle     =   "Please choose a location for the tournament results text file"
      FileName        =   "Tournament Results"
      Filter          =   "Text File (.txt)|*.txt|"
   End
   Begin VB.CheckBox AskBeforeOverwriting 
      BackColor       =   &H005A413A&
      Caption         =   "Ask before overwriting results file"
      ForeColor       =   &H00FFC0C0&
      Height          =   210
      Left            =   120
      TabIndex        =   25
      Top             =   6750
      Value           =   1  'Checked
      Width           =   3015
      Visible         =   0   'False
   End
   Begin VB.OptionButton TeamTest 
      BackColor       =   &H005A413A&
      Caption         =   "Teams"
      ForeColor       =   &H00FAFAFA&
      Height          =   255
      Left            =   2520
      TabIndex        =   27
      Top             =   3480
      Width           =   855
   End
   Begin VB.Label SavedInFolder 
      BackStyle       =   0  'Transparent
      Caption         =   "C:\Program Files\RoboWar 5\Test Results.txt"
      ForeColor       =   &H00FFFFFF&
      Height          =   435
      Left            =   1920
      TabIndex        =   24
      Top             =   7080
      Width           =   4770
      Visible         =   0   'False
      WordWrap        =   -1  'True
   End
   Begin VB.Label ResultsSavedIn 
      BackStyle       =   0  'Transparent
      Caption         =   "Results will be saved in"
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   120
      TabIndex        =   23
      Top             =   7080
      Width           =   1695
      Visible         =   0   'False
   End
   Begin VB.Shape Shape2 
      BorderWidth     =   2
      Height          =   855
      Left            =   1635
      Shape           =   4  'Rounded Rectangle
      Top             =   5760
      Width           =   1665
   End
   Begin VB.Label Label1 
      BackColor       =   &H005A413A&
      Caption         =   "Test against:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FAFAFA&
      Height          =   255
      Left            =   6000
      TabIndex        =   19
      Top             =   480
      Width           =   1215
   End
   Begin VB.Shape Shape1 
      BorderWidth     =   2
      Height          =   855
      Left            =   75
      Shape           =   4  'Rounded Rectangle
      Top             =   5760
      Width           =   1530
   End
   Begin VB.Label Label5 
      BackColor       =   &H005A413A&
      Caption         =   "Times"
      ForeColor       =   &H00FAFAFA&
      Height          =   255
      Left            =   2400
      TabIndex        =   13
      Top             =   6240
      Width           =   735
   End
   Begin VB.Label Label4 
      BackColor       =   &H005A413A&
      Caption         =   "Times"
      ForeColor       =   &H00FAFAFA&
      Height          =   255
      Left            =   840
      TabIndex        =   12
      Top             =   6240
      Width           =   735
   End
   Begin VB.Label Label3 
      BackColor       =   &H005A413A&
      Caption         =   "Grouprounds - Robots meet each others"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   1680
      TabIndex        =   11
      Top             =   5760
      Width           =   1575
   End
   Begin VB.Label Label2 
      BackColor       =   &H005A413A&
      Caption         =   "Duels - Robots meet each other"
      ForeColor       =   &H00FAFAFA&
      Height          =   495
      Left            =   120
      TabIndex        =   10
      Top             =   5760
      Width           =   1455
   End
   Begin VB.Label WhoIsTested 
      BackColor       =   &H005A413A&
      Caption         =   "No Robot is chosen for testing"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FAFAFA&
      Height          =   360
      Left            =   1800
      TabIndex        =   5
      Top             =   120
      Width           =   6855
   End
End
Attribute VB_Name = "TestTourney"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public IamChoosedForTesting As String
Public TeamPath As String
Public DuelsN As Integer
Public GroupN As Integer

'New RWR file format constants
'Const sndrec = 32
Const iconrec = 72
'Const MCrec = 112
'Const Crec = 116
Const zeroexists = 130  'same as iconspresent
'Const soundspresent = 120

Private Sub Add_Click()

If File1.FileName = "" Then Exit Sub

RobotList.AddItem Left$(File1.FileName, Len(File1.FileName) - 4)
TheDirList.AddItem Dir1.Path
End Sub

Private Sub AddAll_Click()
Dim counter As Integer
''''''''''''''''''''''''''''''''''''''''
If TeamTest.Value Then
    On Error GoTo errhandler
    
    Dim Cstart As Long
    Const Crec = 116

    Dim TeamTag As String * 765
    
    Dim sTeam() As String

    For counter = 0 To File1.ListCount - 1
        File1.Selected(counter) = True
        If File1.Path & "\" & File1.FileName <> IamChoosedForTesting Then
            Open File1.Path & "\" & File1.FileName For Binary As 1
            Get 1, Crec, Cstart
            Get 1, Cstart, TeamTag
            Close 1
            sTeam = Split(TeamTag, "\", 4)
            If sTeam(0) = "#!!Master" Then
                Add_Click
    
                If Dir(File1.Path & "\" & sTeam(1) & ".RWR") = "" Then
                    MsgBox "The master '" & Left$(File1.FileName, Len(File1.FileName) - 4) & "' is missing its servant '" & sTeam(1) & "'." & vbCr & "In order to run a team tournament this must be corrected.", vbExclamation, "Can't run Team Tournament"
                    RemoveAll_Click
                    Exit Sub
                End If
                
                RobotList.AddItem sTeam(1)
                TheDirList.AddItem Dir1.Path
                If Trim$(sTeam(2)) = "" Then
                    RobotList.AddItem sTeam(1)
                    TheDirList.AddItem Dir1.Path
                Else
                    If Dir(File1.Path & "\" & sTeam(2) & ".RWR") = "" Then
                        MsgBox "The master '" & Left$(File1.FileName, Len(File1.FileName) - 4) & "' is missing its servant '" & sTeam(2) & "'." & vbCr & "In order to run a team tournament this must be corrected.", vbExclamation, "Can't run Team Tournament"
                        RemoveAll_Click
                        Exit Sub
                    End If
                    RobotList.AddItem sTeam(2)
                    TheDirList.AddItem Dir1.Path
                End If
            End If
        End If
    Next counter
Else
'''''''''''''''''''''''''''''''''''''''
For counter = 0 To File1.ListCount - 1

File1.Selected(counter) = True
If File1.Path & "\" & File1.FileName <> IamChoosedForTesting Then Add_Click

Next counter

End If


Exit Sub

errhandler:
MsgBox "Error with The master '" & Left$(File1.FileName, Len(File1.FileName) - 4) & "'" & vbCr & "This is most commonly caused that it's tags are not correctly written." & vbCr & "Please check the robots Team Tag and try again." & vbCr & vbCr & _
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

Private Sub AskBeforeOverwriting_Click()
Dim valu As Integer
valu = -(AskBeforeOverwriting.Value = 1)
Put 7, 3250, valu
End Sub

Private Sub ChangeLocation_Click()
On Error GoTo didcancel
CommonDialogSelectLocation.InitDir = App.Path   'Nytt
CommonDialogSelectLocation.ShowSave

'Dim noext As String
'noext = CommonDialogSelectLocation.FileName
'SavedInFolder = Left(noext, Len(noext) - 4)
SavedInFolder = CommonDialogSelectLocation.FileName
didcancel:
End Sub

Private Sub Dir1_Change()
File1.Path = Dir1.Path
'If RobotList.ListCount > 0 Then RemoveAll_Click
End Sub

Private Sub Drive1_Change()
Dir1.Path = Drive1.Drive
'File1.path = Drive1.Drive
End Sub

Private Sub DuelsNR_LostFocus()
'Public DuelsN As Integer
'Public GroupN As Integer
If Val(DuelsNR.Text) < 0 Or Val(DuelsNR.Text) > 32767 Then
    MsgBox "Please insert a number between 0 and 32767"
    DuelsNR.Text = 20
    DuelsNR.SetFocus
    DuelsNR.SelLength = Len(DuelsNR.Text)
Else
    DuelsN = Val(DuelsNR.Text)
End If

End Sub

Private Sub File1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
'varje fält är 13 pixlar
If Button <> 1 Then
    Dim WhichRobot As Long
    WhichRobot = (Y / Screen.TwipsPerPixelY) \ 13 + File1.TopIndex
    If WhichRobot < File1.ListCount Then
        File1.Selected(WhichRobot) = True
        Testing_Click
    End If
End If
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
If KeyCode = vbKeyReturn Then Run_Click
End Sub

Private Sub Form_Load()
DuelsN = Val(DuelsNR.Text)
GroupN = Val(GroupNR.Text)
'MandS.Value = -CInt(Not MainWindow.MoveAndShoot.Checked)
Dim valu As Integer
Get 7, 3250, valu
AskBeforeOverwriting.Value = valu
End Sub

Private Sub GroupNR_LostFocus()
'Public DuelsN As Integer
'Public GroupN As Integer
If Val(GroupNR.Text) < 0 Or Val(GroupNR.Text) > 32767 Then
    MsgBox "Please insert a number between 0 and 32767"
    GroupNR.Text = 20
    GroupNR.SetFocus
    GroupNR.SelLength = Len(GroupNR.Text)
Else
    GroupN = Val(GroupNR.Text)
End If
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

Private Sub File1_DblClick()
If NormalTest.Value Then
RobotList.AddItem Left$(File1.FileName, Len(File1.FileName) - 4)
TheDirList.AddItem Dir1.Path
End If
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
If NormalTest.Value Then RemoveRobot_Click
End Sub

Private Sub Run_Click()
If IamChoosedForTesting = "" Or RobotList.ListCount = 0 Then Exit Sub

If CreatingLog.Visible Then
    MsgBox "You can not run a tournament while a log is being printed. Please cancel the printing of the log before running a new tournament.", , "Tournament Log"
    Exit Sub
End If

If NormalTest.Value Then
    If RobotList.ListCount < 5 And GroupN <> 0 Then
        MsgBox "You need to choose at least 5 opponents if you want to test you robot in grouprounds.", , "Can't run testing"
        Exit Sub
    End If
    
    If Dir(SavedInFolder) <> "" And AskBeforeOverwriting.Value = 1 Then
        If MsgBox("A file with the name " & SavedInFolder & " already exits." & vbCr & "Do you want to replace it?", vbYesNo, "Save Tournament Results") = vbNo Then Exit Sub
    End If
    
    MainWindow.BattleHaltButton.Visible = False
    MainWindow.StopTournament.Visible = True
    
    MainWindow.InizTestTournament
Else
    MainWindow.BattleHaltButton.Visible = False
    MainWindow.StopTournament.Visible = True
    MainWindow.InizTeamTestTournament
End If

End Sub

Private Sub RWDir_Click()
File1.Path = App.Path
Dir1.Path = App.Path
Drive1.Drive = App.Path
End Sub

Private Sub TeamTest_Click()
Add.Enabled = False
RemoveRobot.Enabled = False
Shape2.Visible = False
Label5.Visible = False
Label3.Visible = False
GroupNR.Visible = False

RemoveAll_Click
End Sub

Private Sub NormalTest_Click()
Add.Enabled = True
RemoveRobot.Enabled = True
Shape2.Visible = True
Label5.Visible = True
Label3.Visible = True
GroupNR.Visible = True
End Sub

Private Sub Testing_Click()
If TeamTest.Value Then
    On Error GoTo errhandler
    
    Dim Cstart As Long
    Const Crec = 116

    Dim TeamTag As String * 765
    
    Dim sTeam() As String

    Open File1.Path & "\" & File1.FileName For Binary As 1
    Get 1, Crec, Cstart
    Get 1, Cstart, TeamTag
    Close 1
    sTeam = Split(TeamTag, "\", 4)
    If sTeam(0) <> "#!!Master" Then
        MsgBox "To choose a Team for testing, please click on the master of that Team." & vbCr & vbCr & "To define a master:" & vbCr & vbCr & _
        "The Team tag should be placed as the first line in the Master Robot and look like this:" & vbCr & _
        vbTab & "#!!Master\Name of first Servant\Name of second Servant\" & vbCr & vbCr & _
        "Correct: " & vbTab & vbTab & "#!!Master\MyMember1\MyMember2\" & vbCr & vbCr & _
        "Incorrect: " & vbTab & "#!!Master\MyMember1.RWR\MyMember2.RWR\" & vbCr & _
        "Incorrect: " & vbTab & "#!Master\MyMember1\MyMember2\" & vbCr & _
        "Incorrect: " & vbTab & "#!!Master\MyMember1\MyMember2" _
        , vbInformation, "Test Team"
        Exit Sub
    End If
End If
TeamPath = File1.Path   'Should maybe be under the above if?

Dim ProperName As String

ProperName = File1.FileName
If ProperName = "" Then Exit Sub

IamChoosedForTesting = File1.Path & "\" & ProperName

ProperName = Left$(ProperName, Len(ProperName) - 4)

SavedInFolder = App.Path & "\Test Results -" & ProperName & ".txt"
CommonDialogSelectLocation.FileName = App.Path & "\Test Results -" & ProperName & ".txt"


WhoIsTested = "The Robot " & ProperName & " is choosed for testing"

Dim RecIconStart(1) As Long
Dim IconZeroExists As Byte
Dim IconZero As String

On Error GoTo Errorhandler

Open IamChoosedForTesting For Binary As #254
    Get #254, iconrec, RecIconStart
    Get #254, zeroexists, IconZeroExists
    
    If IconZeroExists <> 0 Then
        IconZero = Space(RecIconStart(1) - RecIconStart(0))
        Get #254, RecIconStart(0), IconZero
        RobotPict = LoadRobotIcon(IconZero)
    Else
        RobotPict = LoadPicture(App.Path & "\miscdata\1#0.ico")
    End If
Close #254

RobotPict.Visible = True

SavedInFolder.Visible = True
ResultsSavedIn.Visible = True
ChangeLocation.Visible = True
AskBeforeOverwriting.Visible = True
Exit Sub

Errorhandler:
MsgBox "The robot '" & ProperName & "' seems to be broken, and cannot be tested.", vbCritical, "Test Robot"
Close #254

IamChoosedForTesting = ""
WhoIsTested = "No Robot is chosen for testing"
RobotPict.Visible = False
SavedInFolder.Visible = False
ResultsSavedIn.Visible = False
ChangeLocation.Visible = False
AskBeforeOverwriting.Visible = False


Exit Sub

errhandler:
MsgBox "Error with The master '" & Left$(File1.FileName, Len(File1.FileName) - 4) & "'" & vbCr & "This is most commonly caused that it's tags are not correctly written." & vbCr & "Please check the robots Team Tag and try again." & vbCr & vbCr & _
"The Team tag should be placed as the first line in the Master Robot and look like this:" & vbCr & _
vbTab & "#!!Master\Name of first Servant\Name of second Servant\" & vbCr & vbCr & _
"Correct: " & vbTab & vbTab & "#!!Master\MyMember1\MyMember2\" & vbCr & vbCr & _
"Incorrect: " & vbTab & "#!!Master\MyMember1.RWR\MyMember2.RWR\" & vbCr & _
"Incorrect: " & vbTab & "#!Master\MyMember1\MyMember2\" & vbCr & _
"Incorrect: " & vbTab & "#!!Master\MyMember1\MyMember2" _
, vbExclamation, "Can't run Team Tournament"
Close 1

End Sub


