VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "Comdlg32.ocx"
Begin VB.Form SoundEditor 
   BackColor       =   &H00CA9D86&
   Caption         =   "Recording Studio"
   ClientHeight    =   5700
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   3765
   ForeColor       =   &H00FF8080&
   Icon            =   "Sounds.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MinButton       =   0   'False
   ScaleHeight     =   5700
   ScaleWidth      =   3765
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton Delete 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Delete"
      Height          =   255
      Index           =   9
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   32
      Top             =   3960
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Delete 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Delete"
      Height          =   255
      Index           =   8
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   31
      Top             =   3600
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Delete 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Delete"
      Height          =   255
      Index           =   7
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   30
      Top             =   3240
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Delete 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Delete"
      Height          =   255
      Index           =   6
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   29
      Top             =   2880
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Delete 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Delete"
      Height          =   255
      Index           =   5
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   28
      Top             =   2520
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Delete 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Delete"
      Height          =   255
      Index           =   4
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   27
      Top             =   2160
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Delete 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Delete"
      Height          =   255
      Index           =   3
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   26
      Top             =   1800
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Delete 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Delete"
      Height          =   255
      Index           =   2
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   25
      Top             =   1440
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Delete 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Delete"
      Height          =   255
      Index           =   1
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   24
      Top             =   1080
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Play 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Play"
      Height          =   255
      Index           =   9
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   23
      Top             =   3960
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Play 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Play"
      Height          =   255
      Index           =   8
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   22
      Top             =   3600
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Play 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Play"
      Height          =   255
      Index           =   7
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   21
      Top             =   3240
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Play 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Play"
      Height          =   255
      Index           =   6
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   20
      Top             =   2880
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Play 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Play"
      Height          =   255
      Index           =   5
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   19
      Top             =   2520
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Play 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Play"
      Height          =   255
      Index           =   4
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   18
      Top             =   2160
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Play 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Play"
      Height          =   255
      Index           =   3
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   17
      Top             =   1800
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Play 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Play"
      Height          =   255
      Index           =   2
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   16
      Top             =   1440
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Play 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Play"
      Height          =   255
      Index           =   1
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   15
      Top             =   1080
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Delete 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Delete"
      Height          =   255
      Index           =   0
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   3
      Top             =   720
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Play 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Play"
      Height          =   255
      Index           =   0
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   720
      UseMaskColor    =   -1  'True
      Width           =   735
      Visible         =   0   'False
   End
   Begin VB.CommandButton Choose 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose"
      Height          =   255
      Index           =   9
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   14
      Top             =   3960
      UseMaskColor    =   -1  'True
      Width           =   735
   End
   Begin VB.CommandButton Choose 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose"
      Height          =   255
      Index           =   8
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   13
      Top             =   3600
      UseMaskColor    =   -1  'True
      Width           =   735
   End
   Begin VB.CommandButton Choose 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose"
      Height          =   255
      Index           =   7
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   12
      Top             =   3240
      UseMaskColor    =   -1  'True
      Width           =   735
   End
   Begin VB.CommandButton Choose 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose"
      Height          =   255
      Index           =   6
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   11
      Top             =   2880
      UseMaskColor    =   -1  'True
      Width           =   735
   End
   Begin VB.CommandButton Choose 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose"
      Height          =   255
      Index           =   5
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   10
      Top             =   2520
      UseMaskColor    =   -1  'True
      Width           =   735
   End
   Begin VB.CommandButton Choose 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose"
      Height          =   255
      Index           =   4
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   9
      Top             =   2160
      UseMaskColor    =   -1  'True
      Width           =   735
   End
   Begin VB.CommandButton Choose 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose"
      Height          =   255
      Index           =   3
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   8
      Top             =   1800
      UseMaskColor    =   -1  'True
      Width           =   735
   End
   Begin VB.CommandButton Choose 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose"
      Height          =   255
      Index           =   2
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   7
      Top             =   1440
      UseMaskColor    =   -1  'True
      Width           =   735
   End
   Begin VB.CommandButton Choose 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose"
      Height          =   255
      Index           =   1
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   6
      Top             =   1080
      UseMaskColor    =   -1  'True
      Width           =   735
   End
   Begin VB.CommandButton TheOKButton 
      BackColor       =   &H00DBC284&
      Caption         =   "Allright"
      Default         =   -1  'True
      Height          =   375
      Left            =   2400
      MaskColor       =   &H00FFC0FF&
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   5160
      UseMaskColor    =   -1  'True
      Width           =   1215
   End
   Begin VB.CommandButton Cancel 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Cancel"
      Height          =   375
      Left            =   2400
      Style           =   1  'Graphical
      TabIndex        =   4
      Top             =   4680
      Width           =   1215
   End
   Begin VB.CommandButton Choose 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Choose"
      Height          =   255
      Index           =   0
      Left            =   2280
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   720
      UseMaskColor    =   -1  'True
      Width           =   735
   End
   Begin MSComDlg.CommonDialog ChooseSound 
      Left            =   360
      Top             =   4320
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      CancelError     =   -1  'True
      DialogTitle     =   "Please choose a sound for your robot"
      Filter          =   "Windows Wave|*.wav|"
      MaxFileSize     =   9999
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "Please choose sounds"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   18
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   0
      TabIndex        =   42
      Top             =   0
      Width           =   4845
   End
   Begin VB.Label SoundText 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "No Sound"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   9
      Left            =   240
      TabIndex        =   41
      Top             =   3960
      Width           =   1095
   End
   Begin VB.Label SoundText 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "No Sound"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   8
      Left            =   240
      TabIndex        =   40
      Top             =   3600
      Width           =   1095
   End
   Begin VB.Label SoundText 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "No Sound"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   7
      Left            =   240
      TabIndex        =   39
      Top             =   3240
      Width           =   1095
   End
   Begin VB.Label SoundText 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "No Sound"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   6
      Left            =   240
      TabIndex        =   38
      Top             =   2880
      Width           =   1095
   End
   Begin VB.Label SoundText 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "No Sound"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   5
      Left            =   240
      TabIndex        =   37
      Top             =   2520
      Width           =   1095
   End
   Begin VB.Label SoundText 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "No Sound"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   4
      Left            =   240
      TabIndex        =   36
      Top             =   2160
      Width           =   1095
   End
   Begin VB.Label SoundText 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "No Sound"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   3
      Left            =   240
      TabIndex        =   35
      Top             =   1800
      Width           =   1095
   End
   Begin VB.Label SoundText 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "No Sound"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   2
      Left            =   240
      TabIndex        =   34
      Top             =   1440
      Width           =   1095
   End
   Begin VB.Label SoundText 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "No Sound"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   1
      Left            =   240
      TabIndex        =   33
      Top             =   1080
      Width           =   1095
   End
   Begin VB.Label SoundText 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "No Sound"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   0
      Left            =   240
      TabIndex        =   5
      Top             =   720
      Width           =   1095
   End
End
Attribute VB_Name = "SoundEditor"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'First we have to declare the API call
Private Declare Function sndPlaySound Lib "winmm" Alias "sndPlaySoundA" (SoundData As Any, ByVal uFlags As Long) As Long
'Then we have to declare the constants that go along with the If PlaySounds  Then sndPlaySound function
Const SND_ASYNC = &H1       'ASYNC allows us to play waves with the ability to interrupt
'Const SND_LOOP = &H8        'LOOP causes to sound to be continuously replayed
Const SND_NODEFAULT = &H2   'NODEFAULT causes no sound to be played if the wav can't be found
'Const SND_SYNC = &H0        'SYNC plays a wave file without returning control to the calling program until it's finished
'Const SND_NOSTOP = &H10     'NOSTOP ensures that we don't stop another wave from playing
Const SND_MEMORY = &H4      'MEMORY plays a wave file stored in memory

Const sndrec = 32
Const iconrec = 72
'Const MCrec = 112
'Const Crec = 116
'Const zeroexists = 130  'same as iconspresent
Const soundspresent = 120
Const lenfirstpart = 141 'sound0 start - 1

Dim LoadRobotPath As String     'Robotens namn utan tillägg
Dim RecordSound(9) As String
Dim SoundsExist(9) As Byte
Dim RecSoundStart(10) As Long   '10 is really the Icon 0 start
Dim Diff As Long
Dim DoCancel As Boolean

Dim snd0() As Byte, snd1() As Byte, snd2() As Byte, snd3() As Byte, snd4() As Byte, snd5() As Byte, snd6() As Byte, snd7() As Byte, snd8() As Byte, snd9() As Byte

'New file system in game aproximately 22:44 31/5 2005

Private Sub Cancel_Click()
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

Private Sub Choose_Click(index As Integer)
On Error GoTo errhandler

ChooseSound.ShowOpen
Dim sName As String

sName = ChooseSound.FileName

Open sName For Binary As #1
    RecordSound(index) = Input(LOF(1), #1)
    loadbinarysound (index)
Close 1

SoundsExist(index) = 1

Play(index).Visible = True
Delete(index).Visible = True
Choose(index).Visible = False
            If index = 0 Then
                SoundText(0) = "Death"
            ElseIf index = 1 Then
                SoundText(1) = "Collision"
            ElseIf index = 2 Then
                SoundText(2) = "Block"
            ElseIf index = 3 Then
                SoundText(3) = "Hit"
            Else
                SoundText(index) = "Sound " & index
            End If
Play(index).SetFocus

Exit Sub

errhandler:
If Err <> 32755 Then MsgBox Err.Description, vbExclamation, "Error"

End Sub

Private Sub loadbinarysound(snr As Integer)
Select Case snr
    Case 0
        ReDim snd0(LOF(1))
        Get 1, 1, snd0
    Case 1
        ReDim snd1(LOF(1))
        Get 1, 1, snd1
    Case 2
        ReDim snd2(LOF(1))
        Get 1, 1, snd2
    Case 3
        ReDim snd3(LOF(1))
        Get 1, 1, snd3
    Case 4
        ReDim snd4(LOF(1))
        Get 1, 1, snd4
    Case 5
        ReDim snd5(LOF(1))
        Get 1, 1, snd5
    Case 6
        ReDim snd6(LOF(1))
        Get 1, 1, snd6
    Case 7
        ReDim snd7(LOF(1))
        Get 1, 1, snd7
    Case 8
        ReDim snd8(LOF(1))
        Get 1, 1, snd8
    Case 9
        ReDim snd9(LOF(1))
        Get 1, 1, snd9
End Select
End Sub

Private Sub loadbinarysoundII(snr As Integer, start As Long, lenght As Long)
Select Case snr
    Case 0
        ReDim snd0(lenght)
        Get 1, start, snd0
    Case 1
        ReDim snd1(lenght)
        Get 1, start, snd1
    Case 2
        ReDim snd2(lenght)
        Get 1, start, snd2
    Case 3
        ReDim snd3(lenght)
        Get 1, start, snd3
    Case 4
        ReDim snd4(lenght)
        Get 1, start, snd4
    Case 5
        ReDim snd5(lenght)
        Get 1, start, snd5
    Case 6
        ReDim snd6(lenght)
        Get 1, start, snd6
    Case 7
        ReDim snd7(lenght)
        Get 1, start, snd7
    Case 8
        ReDim snd8(lenght)
        Get 1, start, snd8
    Case 9
        ReDim snd9(lenght)
        Get 1, start, snd9
End Select
End Sub

Private Sub Delete_Click(index As Integer)
SoundsExist(index) = 0
Delete(index).Visible = False
Play(index).Visible = False
Choose(index).Visible = True
SoundText(index).Caption = "No Sound"

Choose(index).SetFocus
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
    Case vbKeyF4
        Unload Me
        ChooseIcon.Show 1, MainWindow
End Select
End Sub

Private Sub Form_Load()
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

Dim c As Integer

Open LoadRobotPath For Binary As #1

    Get #1, sndrec, RecSoundStart
    Get #1, soundspresent, SoundsExist

    For c = 0 To 9
        If SoundsExist(c) <> 0 Then      'soundS 0-9
            RecordSound(c) = Space(RecSoundStart(c + 1) - RecSoundStart(c))

            Get #1, RecSoundStart(c), RecordSound(c)
            loadbinarysoundII c, RecSoundStart(c), Len(RecordSound(c))
            
            Play(c).Visible = True
            Delete(c).Visible = True
            Choose(c).Visible = False
            
            If c = 0 Then
                SoundText(0) = "Death"
            ElseIf c = 1 Then
                SoundText(1) = "Collision"
            ElseIf c = 2 Then
                SoundText(2) = "Block"
            ElseIf c = 3 Then
                SoundText(3) = "Hit"
            Else
                SoundText(c) = "Sound " & c
            End If
        End If
    Next c
Close #1

Diff = RecSoundStart(10) - RecSoundStart(0)

'Debug.Print "Läser ljud"
'For c = 0 To 9  'debug
'    If SoundsExist(c) = 1 Then Debug.Print vbTab & c & " finns, startar " & RecSoundStart(c) & " slutar " & RecSoundStart(c + 1)
'Next c
End Sub

Private Sub Form_Unload(Cancel As Integer)
If Not DoCancel Then PrintSounds
DoCancel = False
End Sub

Private Sub PrintSounds()
Dim c As Integer
'Dim sSound As String
Dim sAllsounds As String
'Dim highestSound As Integer

    'Debug.Print "Skriver sounds"

For c = 0 To 9
    If SoundsExist(c) = 1 Then
        RecSoundStart(c) = RecSoundStart(0) + Len(sAllsounds)
        sAllsounds = sAllsounds & RecordSound(c)
        RecSoundStart(c + 1) = RecSoundStart(0) + Len(sAllsounds)
        'highestSound = c
    End If
Next c

'For c = 0 To 9  'debug
'    If SoundsExist(c) = 1 Then Debug.Print vbTab & c & " finns, startar " & RecSoundStart(c) & " slutar " & RecSoundStart(c + 1)
'Next c

'VERKAR FUNGERA
Dim CodeIconPart As String  'Icons 0 - 9 + machinecode + code
Dim FirstPart As String * lenfirstpart  'dims space for the first part
Dim IconCodeStarts(11) As Long  'old start positions for icons and sounds

Open LoadRobotPath For Binary As #1
    Get #1, iconrec, IconCodeStarts 'gets old start positions for icons and sounds
    
    Diff = Len(sAllsounds) - Diff 'How much longer/shorter is the new soundrec than the old?
    CodeIconPart = Space(LOF(1) - IconCodeStarts(0) - 1)
    Get #1, IconCodeStarts(0), CodeIconPart 'gets icons 0-9 + code + machine code
    Put #1, soundspresent, SoundsExist 'sets which sounds are present
    
    For c = 0 To 11
        IconCodeStarts(c) = IconCodeStarts(c) + Diff    'adjust them for the new sound rec
    Next c
    
    Put #1, sndrec, RecSoundStart
    Put #1, iconrec, IconCodeStarts 'Puts the adjusted values back
    
    Get #1, 1, FirstPart        'gets hardware and rec reference
Close 1

Open LoadRobotPath For Output As #1
    Print #1, FirstPart & sAllsounds & CodeIconPart
Close 1

End Sub

Private Sub Play_Click(index As Integer)
'playbinarysound (index)
Select Case index
    Case 0
        sndPlaySound snd0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 1
        sndPlaySound snd1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 2
        sndPlaySound snd2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 3
        sndPlaySound snd3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 4
        sndPlaySound snd4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 5
        sndPlaySound snd5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 6
        sndPlaySound snd6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 7
        sndPlaySound snd7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 8
        sndPlaySound snd8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 9
        sndPlaySound snd9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
End Select
End Sub

Private Sub TheOKButton_Click()
Unload Me
End Sub
