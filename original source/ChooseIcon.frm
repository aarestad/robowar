VERSION 5.00
Begin VB.Form ChooseIcon 
   BackColor       =   &H009FDBB1&
   Caption         =   "Icon Factory"
   ClientHeight    =   6330
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   4860
   FillStyle       =   0  'Solid
   ForeColor       =   &H00FF8080&
   Icon            =   "ChooseIcon.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MinButton       =   0   'False
   MouseIcon       =   "ChooseIcon.frx":0E42
   ScaleHeight     =   422
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   324
   ShowInTaskbar   =   0   'False
   Begin VB.PictureBox PicPst 
      Appearance      =   0  'Flat
      AutoRedraw      =   -1  'True
      BackColor       =   &H00FFFFFF&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   480
      Left            =   1560
      ScaleHeight     =   32
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   32
      TabIndex        =   29
      Top             =   5760
      Width           =   480
      Visible         =   0   'False
   End
   Begin VB.PictureBox PicBmp 
      Appearance      =   0  'Flat
      AutoRedraw      =   -1  'True
      BackColor       =   &H00FFFFFF&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   555
      Left            =   120
      ScaleHeight     =   37
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   37
      TabIndex        =   19
      Top             =   5640
      Width           =   555
      Visible         =   0   'False
   End
   Begin VB.PictureBox picIco 
      Appearance      =   0  'Flat
      AutoRedraw      =   -1  'True
      AutoSize        =   -1  'True
      BackColor       =   &H00C0FFC0&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   555
      Left            =   840
      ScaleHeight     =   37
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   37
      TabIndex        =   18
      Top             =   5640
      Width           =   555
      Visible         =   0   'False
   End
   Begin VB.CommandButton CancelButton 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Cancel"
      Height          =   375
      Left            =   3360
      Style           =   1  'Graphical
      TabIndex        =   4
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton OKButton 
      BackColor       =   &H00DBC284&
      Caption         =   "Allright"
      Default         =   -1  'True
      Height          =   375
      Left            =   3360
      MaskColor       =   &H000080FF&
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   5760
      Width           =   1215
   End
   Begin VB.OptionButton NoneChoosed 
      BackColor       =   &H009FDBB1&
      Caption         =   "None"
      Height          =   255
      Left            =   2880
      TabIndex        =   3
      Top             =   1500
      Width           =   1095
   End
   Begin VB.OptionButton DotChoosed 
      BackColor       =   &H009FDBB1&
      Caption         =   "Dot"
      Height          =   255
      Left            =   2880
      TabIndex        =   2
      Top             =   1200
      Value           =   -1  'True
      Width           =   1095
   End
   Begin VB.OptionButton LineChoosed 
      BackColor       =   &H009FDBB1&
      Caption         =   "Line"
      Height          =   255
      Left            =   2880
      TabIndex        =   1
      Top             =   900
      Width           =   1095
   End
   Begin VB.Label Label17 
      BackStyle       =   0  'Transparent
      Caption         =   "How to use"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   2400
      TabIndex        =   28
      Top             =   1920
      Width           =   1215
   End
   Begin VB.Label Label16 
      BackStyle       =   0  'Transparent
      Caption         =   "Recording Studio = F5"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00372626&
      Height          =   255
      Left            =   2520
      TabIndex        =   27
      Top             =   4200
      Width           =   2175
   End
   Begin VB.Label Label15 
      BackStyle       =   0  'Transparent
      Caption         =   "Hardware Store = F3"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00372626&
      Height          =   255
      Left            =   2520
      TabIndex        =   26
      Top             =   3960
      Width           =   1935
   End
   Begin VB.Label Label14 
      BackStyle       =   0  'Transparent
      Caption         =   "Drafting Board = F2"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00372626&
      Height          =   255
      Left            =   2520
      TabIndex        =   25
      Top             =   3720
      Width           =   1815
   End
   Begin VB.Label Label13 
      BackStyle       =   0  'Transparent
      Caption         =   "Arena = F1"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00372626&
      Height          =   255
      Left            =   2520
      TabIndex        =   24
      Top             =   3480
      Width           =   1215
   End
   Begin VB.Label Label7 
      BackStyle       =   0  'Transparent
      Caption         =   "Delete = Click on the icon while holding D"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00372626&
      Height          =   495
      Left            =   2520
      TabIndex        =   23
      Top             =   3000
      Width           =   2055
   End
   Begin VB.Label Label6 
      BackStyle       =   0  'Transparent
      Caption         =   "Copy = Ctrl-C"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00372626&
      Height          =   255
      Left            =   2520
      TabIndex        =   22
      Top             =   2640
      Width           =   1215
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "Cut = Ctrl-X"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00372626&
      Height          =   255
      Left            =   2520
      TabIndex        =   21
      Top             =   2400
      Width           =   1215
   End
   Begin VB.Label Label4 
      BackStyle       =   0  'Transparent
      Caption         =   "Paste = Ctrl-V"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00372626&
      Height          =   255
      Left            =   2520
      TabIndex        =   20
      Top             =   2160
      Width           =   1215
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "To turn on and off automatic icons, click on the text below the icon."
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00372626&
      Height          =   855
      Left            =   2520
      TabIndex        =   17
      Top             =   4560
      Width           =   2055
   End
   Begin VB.Label Label12 
      BackStyle       =   0  'Transparent
      Caption         =   "Turret Shape"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   2400
      TabIndex        =   16
      Top             =   600
      Width           =   1215
   End
   Begin VB.Label Label11 
      BackStyle       =   0  'Transparent
      Caption         =   "Icon 9"
      Height          =   255
      Left            =   1440
      TabIndex        =   15
      Top             =   5310
      Width           =   615
   End
   Begin VB.Label Label10 
      BackStyle       =   0  'Transparent
      Caption         =   "Icon 8"
      Height          =   255
      Left            =   360
      TabIndex        =   14
      Top             =   5310
      Width           =   615
   End
   Begin VB.Label Label9 
      BackStyle       =   0  'Transparent
      Caption         =   "Icon 7"
      Height          =   255
      Left            =   1440
      TabIndex        =   13
      Top             =   4350
      Width           =   615
   End
   Begin VB.Label Label8 
      BackStyle       =   0  'Transparent
      Caption         =   "Icon 6"
      Height          =   255
      Left            =   360
      TabIndex        =   12
      Top             =   4350
      Width           =   615
   End
   Begin VB.Label Icon5Text 
      BackStyle       =   0  'Transparent
      Caption         =   "Hit"
      Height          =   255
      Left            =   1440
      TabIndex        =   11
      Top             =   3390
      Width           =   495
   End
   Begin VB.Label Icon4Text 
      BackStyle       =   0  'Transparent
      Caption         =   "Block"
      Height          =   255
      Left            =   360
      TabIndex        =   10
      Top             =   3390
      Width           =   495
   End
   Begin VB.Label Icon3Text 
      BackStyle       =   0  'Transparent
      Caption         =   "Collision"
      Height          =   255
      Left            =   1440
      TabIndex        =   9
      Top             =   2430
      Width           =   615
   End
   Begin VB.Label Icon2Text 
      BackStyle       =   0  'Transparent
      Caption         =   "Death"
      Height          =   255
      Left            =   360
      TabIndex        =   8
      Top             =   2430
      Width           =   495
   End
   Begin VB.Label Icon1Text 
      BackStyle       =   0  'Transparent
      Caption         =   "Shield"
      Height          =   255
      Left            =   1440
      TabIndex        =   7
      Top             =   1470
      Width           =   495
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "Standard"
      Height          =   255
      Left            =   360
      TabIndex        =   6
      Top             =   1470
      Width           =   855
   End
   Begin VB.Image IconN 
      Height          =   480
      Index           =   9
      Left            =   1440
      Top             =   4800
      Width           =   480
   End
   Begin VB.Image IconN 
      Height          =   480
      Index           =   8
      Left            =   360
      Top             =   4800
      Width           =   480
   End
   Begin VB.Image IconN 
      Height          =   480
      Index           =   7
      Left            =   1440
      Top             =   3840
      Width           =   480
   End
   Begin VB.Image IconN 
      Height          =   480
      Index           =   6
      Left            =   360
      Top             =   3840
      Width           =   480
   End
   Begin VB.Image IconN 
      Height          =   480
      Index           =   4
      Left            =   360
      Top             =   2880
      Width           =   480
   End
   Begin VB.Image IconN 
      Height          =   480
      Index           =   5
      Left            =   1440
      Top             =   2880
      Width           =   480
   End
   Begin VB.Image IconN 
      Height          =   480
      Index           =   3
      Left            =   1440
      Top             =   1920
      Width           =   480
   End
   Begin VB.Image IconN 
      Height          =   480
      Index           =   2
      Left            =   360
      Top             =   1920
      Width           =   480
   End
   Begin VB.Image IconN 
      Height          =   480
      Index           =   1
      Left            =   1440
      Top             =   960
      Width           =   480
   End
   Begin VB.Image IconN 
      Height          =   480
      Index           =   0
      Left            =   360
      Top             =   960
      Width           =   480
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "Please choose an icon to edit"
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
      Left            =   0
      TabIndex        =   5
      Top             =   0
      Width           =   5895
   End
   Begin VB.Shape Shape 
      BorderColor     =   &H00000000&
      FillColor       =   &H00FF0000&
      Height          =   510
      Index           =   0
      Left            =   345
      Top             =   945
      Width           =   510
   End
   Begin VB.Shape Shape 
      BorderColor     =   &H00A76B43&
      FillColor       =   &H00FF0000&
      Height          =   510
      Index           =   1
      Left            =   1425
      Top             =   945
      Width           =   510
   End
   Begin VB.Shape Shape 
      BorderColor     =   &H00A76B43&
      FillColor       =   &H00FF0000&
      Height          =   510
      Index           =   3
      Left            =   1425
      Top             =   1905
      Width           =   510
   End
   Begin VB.Shape Shape 
      BorderColor     =   &H00A76B43&
      FillColor       =   &H00FF0000&
      Height          =   510
      Index           =   2
      Left            =   345
      Top             =   1905
      Width           =   510
   End
   Begin VB.Shape Shape 
      BorderColor     =   &H00A76B43&
      FillColor       =   &H00FF0000&
      Height          =   510
      Index           =   5
      Left            =   1425
      Top             =   2865
      Width           =   510
   End
   Begin VB.Shape Shape 
      BorderColor     =   &H00A76B43&
      FillColor       =   &H00FF0000&
      Height          =   510
      Index           =   4
      Left            =   345
      Top             =   2865
      Width           =   510
   End
   Begin VB.Shape Shape 
      BorderColor     =   &H00A76B43&
      FillColor       =   &H00FF0000&
      Height          =   510
      Index           =   6
      Left            =   345
      Top             =   3825
      Width           =   510
   End
   Begin VB.Shape Shape 
      BorderColor     =   &H00A76B43&
      FillColor       =   &H00FF0000&
      Height          =   510
      Index           =   7
      Left            =   1425
      Top             =   3825
      Width           =   510
   End
   Begin VB.Shape Shape 
      BorderColor     =   &H00A76B43&
      FillColor       =   &H00FF0000&
      Height          =   510
      Index           =   8
      Left            =   345
      Top             =   4785
      Width           =   510
   End
   Begin VB.Shape Shape 
      BorderColor     =   &H00A76B43&
      FillColor       =   &H00FF0000&
      Height          =   510
      Index           =   9
      Left            =   1425
      Top             =   4785
      Width           =   510
   End
End
Attribute VB_Name = "ChooseIcon"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Type Robot   'Private      'Used to load robots
    Energy As Integer
    Damage As Integer
    Shield As Integer
    Speed As Byte
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

Dim DoCancel As Boolean
Dim SelectedIcon As Integer
Dim ShiftDown As Boolean
Dim PastingIcon As Boolean

Dim TheRobot As Robot
Dim LoadRobotPath As String
'Dim sIcons(9) As String

'New RWR file format constants
Dim RecIconStart(10) As Long    '10 is really the machine code start
Dim IconsExist(9) As Byte
'Const sndrec = 32
Const iconrec = 72
Const MCrec = 112
Const Crec = 116
Const zeroexists = 130  'same as iconspresent
Const xBitIconSize = 3266   'For 24 bit ico:s it's 3266
'Const soundspresent = 120
Dim RecordIcon(9) As String

'undo stuff


Dim UndoSystem As Boolean
Const SYS1 = False          'System 1 is for deleting and copy paste
Const SYS2 = True           'System 2 is for cut and paste within the icon factory so both icons (the cutted and the pasted) change back

Dim Ziconchanged As Long        'For system 1. System 1 is very uncomplex. Ziconchanged is the number of the icon the user changed (0 in case the user has not changed anything).
Dim thebackupicon As Picture    'For system 1. TheBackupicon is a variable that stores the previous icon itself (that the user can undo back too).

Dim bac(1 To 2) As Picture      'For system 2. System 2 is the same as system 1. It stores the previous icon bac(1) and also the icon before that icon (bac(2))
Dim changed(1 To 2) As Long     'For system 2. Same as ZIconchanged. Records which icon that bac 1 & 2 continiues.
Dim DidCut As Boolean           'For the switching to system 2.

Private Sub Form_Click()
Me.MousePointer = 0
PastingIcon = False
End Sub

Private Sub Form_Load()
 SelectedIcon = 0
 ShiftDown = False
 PastingIcon = False

Select Case MainWindow.SelectedRobot
    Case 1
        LoadRobotPath = MainWindow.R1path
    Case 2
        LoadRobotPath = MainWindow.R2path
    Case 3
        LoadRobotPath = MainWindow.R3path
    Case 4
        LoadRobotPath = MainWindow.R4path
    Case 5
        LoadRobotPath = MainWindow.R5path
    Case 6
        LoadRobotPath = MainWindow.R6path
End Select

Open LoadRobotPath For Binary As #1
    Get #1, , TheRobot

If TheRobot.ShieldIcon = 0 Then Icon1Text = "Icon 1"
If TheRobot.DeathIcon = 0 Then Icon2Text = "Icon 2"
If TheRobot.CollisionIcon = 0 Then Icon3Text = "Icon 3"
If TheRobot.BlockIcon = 0 Then Icon4Text = "Icon 4"
If TheRobot.HitIcon = 0 Then Icon5Text = "Icon 5"

If TheRobot.Turret = 0 Then
    NoneChoosed.Value = True
ElseIf TheRobot.Turret = 1 Then
    LineChoosed.Value = True
End If

'ICONS
Dim c As Integer

    Get #1, iconrec, RecIconStart
    Get #1, zeroexists, IconsExist
    
    'Debug.Print "Laddar icons"

    For c = 0 To 9
        If IconsExist(c) <> 0 Then      'ICONS 0-9
            RecordIcon(c) = Space(RecIconStart(c + 1) - RecIconStart(c))
            Get #1, RecIconStart(c), RecordIcon(c)
            'Debug.Print vbTab & c & " finns, startar " & RecIconStart(c) & " slutar " & RecIconStart(c + 1)
            
            IconN(c).Picture = LoadRobotIcon(RecordIcon(c))
        End If
    Next c
Close 1

End Sub

Private Sub Form_Unload(Cancel As Integer)
If Not DoCancel Then SkrivIcon
DoCancel = False
End Sub

Private Sub CancelButton_Click()
Dim res As Byte
res = MsgBox("Are you sure you don't want to save your changes?", vbYesNoCancel, "Don't save changes?") _

If res = vbYes Then
    DoCancel = True
ElseIf res = vbNo Then
    DoCancel = False
ElseIf res = vbCancel Then
    DoCancel = False
    Exit Sub
End If

Unload Me
End Sub

Private Sub Icon1Text_Click()
If Icon1Text.Caption = "Shield" Then
    Icon1Text.Caption = "Icon 1"
    TheRobot.ShieldIcon = 0
Else
    Icon1Text.Caption = "Shield"
    TheRobot.ShieldIcon = 1
End If

End Sub

Private Sub Icon2Text_Click()
If Icon2Text.Caption = "Death" Then
    Icon2Text.Caption = "Icon 2"
    TheRobot.DeathIcon = 0
Else
    Icon2Text.Caption = "Death"
    TheRobot.DeathIcon = 1
End If
End Sub

Private Sub Icon3Text_Click()
If Icon3Text.Caption = "Collision" Then
    Icon3Text.Caption = "Icon 3"
    TheRobot.CollisionIcon = 0
Else
    Icon3Text.Caption = "Collision"
    TheRobot.CollisionIcon = 1
End If
End Sub

Private Sub Icon4Text_Click()
If Icon4Text.Caption = "Block" Then
    Icon4Text.Caption = "Icon 4"
    TheRobot.BlockIcon = 0
Else
    Icon4Text.Caption = "Block"
    TheRobot.BlockIcon = 1
End If
End Sub

Private Sub Icon5Text_Click()
If Icon5Text.Caption = "Hit" Then
    Icon5Text.Caption = "Icon 5"
    TheRobot.HitIcon = 0
Else
    Icon5Text.Caption = "Hit"
    TheRobot.HitIcon = 1
End If
End Sub

Private Sub SkrivIcon()
'RefreshIcon (MainWindow.SelectedRobot)
If MainWindow.R1path = LoadRobotPath Then RefreshIcon (1)     'It doesn't mater if
If MainWindow.R2path = LoadRobotPath Then RefreshIcon (2)     'it refreshes non-existing robots
If MainWindow.R3path = LoadRobotPath Then RefreshIcon (3)     '(I think =S)
If MainWindow.R4path = LoadRobotPath Then RefreshIcon (4)
If MainWindow.R5path = LoadRobotPath Then RefreshIcon (5)
If MainWindow.R6path = LoadRobotPath Then RefreshIcon (6)

''Skriv ikonerna
Dim c As Integer
'Dim sicon As String
Dim sAllIcons As String
Dim highesticon As Integer

    'Debug.Print "Skriver icons"

For c = 0 To 9
    If IconsExist(c) = 1 Then
        RecIconStart(c) = RecIconStart(0) + Len(sAllIcons)
        sAllIcons = sAllIcons & RecordIcon(c)
        RecIconStart(c + 1) = RecIconStart(0) + Len(sAllIcons)
        highesticon = c
    End If
Next c

'FUNGERAR MEN ÄR NÅGOT LÅNGSAM
Dim MCStart As Long 'Old MC Start
Dim Cstart As Long 'Old CStart
Dim CodePart As String
Dim FirstPart As String

Open LoadRobotPath For Binary As #1
    Get #1, MCrec, MCStart
    Get #1, Crec, Cstart
    CodePart = Space(LOF(1) - MCStart - 1)
    Get #1, MCStart, CodePart

    Cstart = Cstart - MCStart   'Len of the code
    Put #1, 1, TheRobot    'The icon settings must be saved
    Put #1, zeroexists, IconsExist

    If IconsExist(highesticon) Then
        Cstart = RecIconStart(highesticon + 1) + Cstart
        Put #1, iconrec, RecIconStart
        Put #1, MCrec, RecIconStart(highesticon + 1)

        Put #1, RecIconStart(0), sAllIcons
        FirstPart = Space(RecIconStart(highesticon + 1) - 1)
    Else    'if it doesn't have any icons - RecIconStart / sAllIcons isn't needed because the user has deleted all icons
        Cstart = RecIconStart(0) + Cstart
        Put #1, MCrec, RecIconStart(0)
        FirstPart = Space(RecIconStart(0) - 1)  'The get/space sizers seems to work better with -1?
    End If

    Put #1, Crec, Cstart
    Get #1, 1, FirstPart        'Be very carefull which order we put the get put statements considering this one
Close 1

Open LoadRobotPath For Output As #1
    Print #1, FirstPart & CodePart
Close 1

End Sub

Private Function Icon2String() As String
Open App.Path & "\miscdata\WrittenIcon" For Binary As #1
   Icon2String = Input(LOF(1), #1)
Close 1
End Function

Private Sub IconZeroDelete()
Select Case MainWindow.SelectedRobot
    Case 1
        MainWindow.R1Icon = LoadPicture(App.Path & "\miscdata\1#0.ico")
    Case 2
        MainWindow.R2Icon = LoadPicture(App.Path & "\miscdata\2#0.ico")
    Case 3
        MainWindow.R3Icon = LoadPicture(App.Path & "\miscdata\3#0.ico")
    Case 4
        MainWindow.R4Icon = LoadPicture(App.Path & "\miscdata\4#0.ico")
    Case 5
        MainWindow.R5Icon = LoadPicture(App.Path & "\miscdata\5#0.ico")
    Case 6
        MainWindow.R6Icon = LoadPicture(App.Path & "\miscdata\6#0.ico")
End Select
End Sub

Private Sub IconZeroRefresh()
Select Case MainWindow.SelectedRobot
    Case 1
        MainWindow.R1Icon = LoadRobotIcon(RecordIcon(0))
    Case 2
        MainWindow.R2Icon = LoadRobotIcon(RecordIcon(0))
    Case 3
        MainWindow.R3Icon = LoadRobotIcon(RecordIcon(0))
    Case 4
        MainWindow.R4Icon = LoadRobotIcon(RecordIcon(0))
    Case 5
        MainWindow.R5Icon = LoadRobotIcon(RecordIcon(0))
    Case 6
        MainWindow.R6Icon = LoadRobotIcon(RecordIcon(0))
End Select
End Sub


Private Sub RefreshIcon(WhichRobot As Integer)

Select Case WhichRobot               'flyttat hit pga att robotar blev raderade vid fel annars
    Case 1
        MainWindow.Robot1ShieldIcon = TheRobot.ShieldIcon
        MainWindow.Robot1HitIcon = TheRobot.HitIcon
        MainWindow.Robot1BlockIcon = TheRobot.BlockIcon
        MainWindow.Robot1DeathIcon = TheRobot.DeathIcon
        MainWindow.Robot1CollisionIcon = TheRobot.CollisionIcon
    Case 2
        MainWindow.Robot2ShieldIcon = TheRobot.ShieldIcon
        MainWindow.Robot2HitIcon = TheRobot.HitIcon
        MainWindow.Robot2BlockIcon = TheRobot.BlockIcon
        MainWindow.Robot2DeathIcon = TheRobot.DeathIcon
        MainWindow.Robot2CollisionIcon = TheRobot.CollisionIcon
    Case 3
        MainWindow.Robot3ShieldIcon = TheRobot.ShieldIcon
        MainWindow.Robot3HitIcon = TheRobot.HitIcon
        MainWindow.Robot3BlockIcon = TheRobot.BlockIcon
        MainWindow.Robot3DeathIcon = TheRobot.DeathIcon
        MainWindow.Robot3CollisionIcon = TheRobot.CollisionIcon
    Case 4
        MainWindow.Robot4ShieldIcon = TheRobot.ShieldIcon
        MainWindow.Robot4HitIcon = TheRobot.HitIcon
        MainWindow.Robot4BlockIcon = TheRobot.BlockIcon
        MainWindow.Robot4DeathIcon = TheRobot.DeathIcon
        MainWindow.Robot4CollisionIcon = TheRobot.CollisionIcon
    Case 5
        MainWindow.Robot5ShieldIcon = TheRobot.ShieldIcon
        MainWindow.Robot5HitIcon = TheRobot.HitIcon
        MainWindow.Robot5BlockIcon = TheRobot.BlockIcon
        MainWindow.Robot5DeathIcon = TheRobot.DeathIcon
        MainWindow.Robot5CollisionIcon = TheRobot.CollisionIcon
    Case 6
        MainWindow.Robot6ShieldIcon = TheRobot.ShieldIcon
        MainWindow.Robot6HitIcon = TheRobot.HitIcon
        MainWindow.Robot6BlockIcon = TheRobot.BlockIcon
        MainWindow.Robot6DeathIcon = TheRobot.DeathIcon
        MainWindow.Robot6CollisionIcon = TheRobot.CollisionIcon
End Select

End Sub





Private Sub LineChoosed_Click()
TheRobot.Turret = 1
End Sub

Private Sub DotChoosed_Click()
TheRobot.Turret = 2
End Sub

Private Sub NoneChoosed_Click()
TheRobot.Turret = 0
End Sub

Private Sub OKButton_Click()
Unload Me
End Sub

Private Sub Form_KeyUp(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyD Then
        Me.MousePointer = 0
        ShiftDown = False
    End If
End Sub

Private Sub WriteIco()
' This sub converts a bmp or an ico with transparency

Dim pixelx As Byte
Dim pixely As Byte
Dim backwardspixel As Integer
backwardspixel = 31

For pixely = 0 To 31
    For pixelx = 0 To 31    'from right to left
        If PicBmp.Point(pixelx, pixely) = vbWhite Then
            PicBmp.PSet (pixelx, pixely), 8438015
        Else
            Exit For
        End If
    Next pixelx
    For backwardspixel = -31 To 0
        If PicBmp.Point(-backwardspixel, pixely) = vbWhite Then
            PicBmp.PSet (-backwardspixel, pixely), 8438015
        Else
            Exit For
        End If
    Next backwardspixel
Next pixely

''''''side
For pixelx = 0 To 31
    For pixely = 0 To 31    'from right to left
        If PicBmp.Point(pixelx, pixely) = vbWhite Or PicBmp.Point(pixelx, pixely) = 8438015 Then
            PicBmp.PSet (pixelx, pixely), 8438015
        Else
            Exit For
        End If
    Next pixely
    For backwardspixel = -31 To 0
        If PicBmp.Point(pixelx, -backwardspixel) = vbWhite Or PicBmp.Point(pixelx, -backwardspixel) = 8438015 Then
            PicBmp.PSet (pixelx, -backwardspixel), 8438015
        Else
            Exit For
        End If
    Next backwardspixel
Next pixelx
'8438015 could be used if the user wants transparency somewhere else but in the edges
'8438015 is an extremly ungy color

'''Here starts the code takes from vbhelper.com (I don't know how to write .ico:s)
    Dim RET, bmpPicInfo As BITMAPINFO

    Screen.MousePointer = vbHourglass
    With bmpPicInfo.bmiHeader
        .biBitCount = 24
        .biCompression = BI_RGB
        .biPlanes = 1
        .biSize = Len(bmpPicInfo.bmiHeader)
        .biWidth = 32
        .biHeight = 32
    End With
    IconInfo.iDC = CreateCompatibleDC(0)
    IconInfo.iWidth = 32
    IconInfo.iHeight = 32
    bi24BitInfo.bmiHeader.biWidth = 32
    bi24BitInfo.bmiHeader.biHeight = 32
    IconInfo.iBitmap = CreateDIBSection(IconInfo.iDC, bmpPicInfo, DIB_RGB_COLORS, ByVal 0&, ByVal 0&, ByVal 0&)
    SelectObject IconInfo.iDC, IconInfo.iBitmap
    RET = BitBlt(IconInfo.iDC, 0, 0, 32, 32, PicBmp.hdc, 0, 0, vbSrcCopy)
    If RET = 0 Then
    MsgBox "Unable to BitBlt Picture."
    Exit Sub
    End If
    DoEvents
    SaveIcon App.Path & "\miscdata\WrittenIcon", IconInfo.iDC, IconInfo.iBitmap, 24 ', CLng(SaveTypeIn)"
    IconInfo.iFileName = App.Path & "\miscdata\WrittenIcon"                      '24 = antal bitar
    DeleteDC IconInfo.iDC
    DeleteObject IconInfo.iBitmap
    Screen.MousePointer = vbDefault
    DoEvents
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
Select Case KeyCode
    Case vbKeyF1
        Unload Me
    Case vbKeyF2
        Unload Me
        DraftingBoard.Show 1, MainWindow
    Case vbKeyF3
        Unload Me
        HardwareWindow.Show 1, MainWindow
    Case vbKeyF5
        Unload Me
        SoundEditor.Show 1, MainWindow
    Case vbKeyD
        Me.MousePointer = 99
        ShiftDown = True
        PastingIcon = False
    Case vbKeyV And ((Shift And vbCtrlMask) > 0) And (Clipboard.GetData <> 0)
        Me.MousePointer = 2
        PastingIcon = True
        ShiftDown = False
    Case vbKeyEscape
        Me.MousePointer = 0
        PastingIcon = False
        ShiftDown = False
    Case vbKeyC And ((Shift And vbCtrlMask) > 0) And (Not PastingIcon)
        copyico
    Case vbKeyX And ((Shift And vbCtrlMask) > 0) And (Not PastingIcon)
        cutico
    Case vbKeyZ And ((Shift And vbCtrlMask) > 0) And (Not PastingIcon)
        If Ziconchanged <> 0 Then restoreicon
End Select
End Sub

Private Sub copyico()
    If IconN(SelectedIcon) <> 0 Then
        SwitchSys1
        Clipboard.Clear
        PicPst = LoadPicture()
        PicPst.PaintPicture IconN(SelectedIcon), 0, 0
        PicPst = PicPst.Image
        Clipboard.SetData PicPst.Picture, 2
    End If
End Sub

Private Sub cutico()
    If IconN(SelectedIcon) <> 0 Then
        SwitchSys1
        DidCut = True
        backupicon (SelectedIcon)
        IconsExist(SelectedIcon) = 0
        Clipboard.Clear
        PicPst = LoadPicture()
        PicPst.PaintPicture IconN(SelectedIcon), 0, 0
        PicPst = PicPst.Image
        Clipboard.SetData PicPst.Picture, 2
        IconN(SelectedIcon) = LoadPicture()
        If SelectedIcon = 0 Then IconZeroDelete
    End If
End Sub

Private Sub IconN_Click(index As Integer)
If ShiftDown Then
    backupicon (index)
    SwitchSys1
    IconN(index) = LoadPicture()
    Shape(index).BackStyle = 0
    IconsExist(index) = 0
    If index = 0 Then IconZeroDelete
    Exit Sub
ElseIf PastingIcon Then
    backupicon (index)
    If DidCut Then UndoSystem = SYS2 Else SwitchSys1
    DidCut = False  'Here to prevent that several icons change when the user cuts and does paste multiple times after the cut
    'If UndoSystem = SYS2 Then Beep 'DEBUGG
    
    Dim sicon As String
    Dim p As Picture
    Set p = Clipboard.GetData
    PicBmp = p
    WriteIco
    sicon = Icon2String
    ' If we paste an icon, it's _allways_ the same size
    ' that stops the problem with icons getting 2 bytes bigger every time they're pasted
    RecordIcon(index) = Left$(sicon, xBitIconSize)
    'RecordIcon(index) = sicon 'Left$(sicon, Len(sicon) - 2), the old solution, it destroyed 1 bit icons pretty badly

    IconN(index) = p
    Me.MousePointer = 0
    PastingIcon = False
    IconsExist(index) = 1
    If index = 0 Then IconZeroRefresh
End If

Dim c As Integer

SelectedIcon = index
Shape(index).BorderColor = vbBlack

For c = 0 To 9
    If c <> index Then Shape(c).BorderColor = &HA76B43
Next c

End Sub

Private Sub backupicon(ziconnumber As Long)
'''''' System 1
    Ziconchanged = ziconnumber
    Set thebackupicon = IconN(ziconnumber)
    
'''''' System 2
    Set bac(2) = bac(1)
    changed(2) = changed(1)
    
    Set bac(1) = IconN(ziconnumber)
    changed(1) = ziconnumber
End Sub

Private Sub SwitchSys1()
UndoSystem = SYS1
DidCut = False
End Sub

Private Sub restoreicon()
If UndoSystem = SYS1 Then
    IconN(Ziconchanged) = thebackupicon
    If thebackupicon = 0 Then IconsExist(Ziconchanged) = 0 Else IconsExist(Ziconchanged) = 1
Else
    IconN(changed(1)) = bac(1)
    IconN(changed(2)) = bac(2)
    If IconN(changed(1)) = 0 Then IconsExist(changed(1)) = 0 Else IconsExist(changed(1)) = 1
    If IconN(changed(2)) = 0 Then IconsExist(changed(2)) = 0 Else IconsExist(changed(2)) = 1
    SwitchSys1
End If

'    Debug.Print IconN(ziconchanged)
'    Debug.Print IconN(changed(1))
'    Debug.Print IconN(changed(2))
End Sub


