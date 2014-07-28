VERSION 5.00
Begin VB.Form HardwareWindow 
   BackColor       =   &H00D0C899&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Hardware Store"
   ClientHeight    =   6300
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   7350
   ForeColor       =   &H0080FF80&
   Icon            =   "Hardware.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MinButton       =   0   'False
   ScaleHeight     =   6300
   ScaleWidth      =   7350
   ShowInTaskbar   =   0   'False
   Begin VB.CheckBox DProbes 
      BackColor       =   &H00D0C899&
      Caption         =   "Probes"
      Height          =   495
      Left            =   360
      TabIndex        =   14
      TabStop         =   0   'False
      Top             =   5520
      Width           =   1215
   End
   Begin VB.CheckBox DStunner 
      BackColor       =   &H00D0C899&
      Caption         =   "Stunners"
      Height          =   495
      Left            =   3000
      TabIndex        =   13
      TabStop         =   0   'False
      Top             =   5160
      Width           =   1215
   End
   Begin VB.CheckBox DTacNuke 
      BackColor       =   &H00D0C899&
      Caption         =   "TacNukes"
      Height          =   495
      Left            =   3000
      TabIndex        =   12
      TabStop         =   0   'False
      Top             =   4080
      Width           =   1215
   End
   Begin VB.CheckBox DMine 
      BackColor       =   &H00D0C899&
      Caption         =   "Mines"
      Height          =   495
      Left            =   3000
      TabIndex        =   11
      TabStop         =   0   'False
      Top             =   4800
      Width           =   1215
   End
   Begin VB.CheckBox DLaser 
      BackColor       =   &H00D0C899&
      Caption         =   "Lasers"
      Height          =   495
      Left            =   3000
      TabIndex        =   10
      TabStop         =   0   'False
      Top             =   5880
      Width           =   1215
   End
   Begin VB.CheckBox DHellbore 
      BackColor       =   &H00D0C899&
      Caption         =   "Hellbores"
      Height          =   495
      Left            =   3000
      TabIndex        =   9
      TabStop         =   0   'False
      Top             =   4440
      Width           =   1215
   End
   Begin VB.CheckBox DDrone 
      BackColor       =   &H00D0C899&
      Caption         =   "Drones"
      Height          =   495
      Left            =   3000
      TabIndex        =   8
      TabStop         =   0   'False
      Top             =   5520
      Width           =   1215
   End
   Begin VB.CheckBox DMissile 
      BackColor       =   &H00D0C899&
      Caption         =   "Missiles"
      Height          =   495
      Left            =   3000
      TabIndex        =   7
      TabStop         =   0   'False
      Top             =   3720
      Width           =   1215
   End
   Begin VB.CommandButton CancelButton 
      BackColor       =   &H00E4D2B4&
      Caption         =   "Cancel"
      Height          =   375
      Left            =   6000
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   5280
      Width           =   1215
   End
   Begin VB.CommandButton OKButton 
      BackColor       =   &H00DBC284&
      Caption         =   "Allright"
      Default         =   -1  'True
      Height          =   375
      Left            =   6000
      MaskColor       =   &H000080FF&
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   5760
      Width           =   1215
   End
   Begin VB.Label Label10 
      BackStyle       =   0  'Transparent
      Caption         =   "      Explosive"
      Height          =   255
      Left            =   3000
      TabIndex        =   43
      Top             =   2520
      Width           =   1095
   End
   Begin VB.Label Label16 
      BackStyle       =   0  'Transparent
      Caption         =   "      None"
      Height          =   255
      Left            =   6120
      TabIndex        =   42
      Top             =   3120
      Width           =   855
   End
   Begin VB.Label Label15 
      BackStyle       =   0  'Transparent
      Caption         =   "      Dot"
      Height          =   255
      Left            =   6120
      TabIndex        =   41
      Top             =   2880
      Width           =   855
   End
   Begin VB.Label Label14 
      BackStyle       =   0  'Transparent
      Caption         =   "      Line"
      Height          =   255
      Left            =   6120
      TabIndex        =   40
      Top             =   2640
      Width           =   855
   End
   Begin VB.Label Label29 
      BackStyle       =   0  'Transparent
      Caption         =   "      Rubber"
      Height          =   255
      Left            =   3000
      TabIndex        =   39
      Top             =   3000
      Width           =   1095
   End
   Begin VB.Label Label28 
      BackStyle       =   0  'Transparent
      Caption         =   "      Normal"
      Height          =   255
      Left            =   3000
      TabIndex        =   38
      Top             =   2760
      Width           =   1095
   End
   Begin VB.Label Label27 
      BackStyle       =   0  'Transparent
      Caption         =   "      5"
      Height          =   255
      Left            =   3000
      TabIndex        =   37
      Top             =   1440
      Width           =   855
   End
   Begin VB.Label Label26 
      BackStyle       =   0  'Transparent
      Caption         =   "      50"
      Height          =   255
      Left            =   3000
      TabIndex        =   36
      Top             =   480
      Width           =   855
   End
   Begin VB.Label Label25 
      BackStyle       =   0  'Transparent
      Caption         =   "      30"
      Height          =   255
      Left            =   3000
      TabIndex        =   35
      Top             =   720
      Width           =   855
   End
   Begin VB.Label Label24 
      BackStyle       =   0  'Transparent
      Caption         =   "      15"
      Height          =   255
      Left            =   3000
      TabIndex        =   34
      Top             =   960
      Width           =   855
   End
   Begin VB.Label Label8 
      BackStyle       =   0  'Transparent
      Caption         =   "      10"
      Height          =   255
      Left            =   3000
      TabIndex        =   33
      Top             =   1200
      Width           =   855
   End
   Begin VB.Image SpeedPict 
      Height          =   1125
      Left            =   3000
      Picture         =   "Hardware.frx":0E42
      Top             =   500
      Width           =   165
   End
   Begin VB.Label Label23 
      BackStyle       =   0  'Transparent
      Caption         =   "      100"
      Height          =   255
      Left            =   360
      TabIndex        =   32
      Top             =   4200
      Width           =   855
   End
   Begin VB.Label Label22 
      BackStyle       =   0  'Transparent
      Caption         =   "      50"
      Height          =   255
      Left            =   360
      TabIndex        =   31
      Top             =   4440
      Width           =   855
   End
   Begin VB.Label Label21 
      BackStyle       =   0  'Transparent
      Caption         =   "      25"
      Height          =   255
      Left            =   360
      TabIndex        =   30
      Top             =   4680
      Width           =   855
   End
   Begin VB.Label Label20 
      BackStyle       =   0  'Transparent
      Caption         =   "      Zilch"
      Height          =   255
      Left            =   360
      TabIndex        =   29
      Top             =   4920
      Width           =   855
   End
   Begin VB.Image TurretPict 
      Height          =   645
      Left            =   6120
      Picture         =   "Hardware.frx":0F1E
      Top             =   2650
      Width           =   165
   End
   Begin VB.Label Label19 
      BackStyle       =   0  'Transparent
      Caption         =   "      150"
      Height          =   255
      Left            =   360
      TabIndex        =   28
      Top             =   2160
      Width           =   855
   End
   Begin VB.Label Label17 
      BackStyle       =   0  'Transparent
      Caption         =   "      100"
      Height          =   255
      Left            =   360
      TabIndex        =   27
      Top             =   2400
      Width           =   855
   End
   Begin VB.Label Label13 
      BackStyle       =   0  'Transparent
      Caption         =   "      60"
      Height          =   255
      Left            =   360
      TabIndex        =   26
      Top             =   2640
      Width           =   855
   End
   Begin VB.Label Label9 
      BackStyle       =   0  'Transparent
      Caption         =   "      30"
      Height          =   255
      Left            =   360
      TabIndex        =   25
      Top             =   2880
      Width           =   855
   End
   Begin VB.Label Label7 
      BackStyle       =   0  'Transparent
      Caption         =   "      40"
      Height          =   255
      Left            =   360
      TabIndex        =   24
      Top             =   1200
      Width           =   855
   End
   Begin VB.Label Label6 
      BackStyle       =   0  'Transparent
      Caption         =   "      60"
      Height          =   255
      Left            =   360
      TabIndex        =   23
      Top             =   960
      Width           =   855
   End
   Begin VB.Label Label4 
      BackStyle       =   0  'Transparent
      Caption         =   "      100"
      Height          =   255
      Left            =   360
      TabIndex        =   22
      Top             =   720
      Width           =   855
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "      150"
      Height          =   255
      Left            =   360
      TabIndex        =   21
      Top             =   480
      Width           =   855
   End
   Begin VB.Image BulletPict 
      Height          =   645
      Left            =   3000
      Picture         =   "Hardware.frx":0FC2
      Top             =   2540
      Width           =   165
   End
   Begin VB.Image ShieldPict 
      Height          =   885
      Left            =   360
      Picture         =   "Hardware.frx":1063
      Top             =   4220
      Width           =   165
   End
   Begin VB.Image DamagePict 
      Height          =   885
      Left            =   360
      Picture         =   "Hardware.frx":1125
      Top             =   2180
      Width           =   165
   End
   Begin VB.Image EnergyPict 
      Height          =   885
      Left            =   360
      Picture         =   "Hardware.frx":11E7
      Top             =   510
      Width           =   165
   End
   Begin VB.Label Class 
      BackColor       =   &H00D0C899&
      Caption         =   "Titan"
      BeginProperty Font 
         Name            =   "Times New Roman"
         Size            =   15
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   -1  'True
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Left            =   5880
      TabIndex        =   20
      Top             =   4440
      Width           =   1215
   End
   Begin VB.Label Label18 
      BackColor       =   &H00D0C899&
      Caption         =   "Class:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   5760
      TabIndex        =   19
      Top             =   4080
      Width           =   855
   End
   Begin VB.Label DispTurret 
      BackStyle       =   0  'Transparent
      Caption         =   "Turret Shape"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   5640
      TabIndex        =   18
      Top             =   2040
      Width           =   1695
   End
   Begin VB.Label DispTotalPoints 
      BackStyle       =   0  'Transparent
      Caption         =   "14"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   18
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1035
      Left            =   6840
      TabIndex        =   17
      Top             =   480
      Width           =   390
   End
   Begin VB.Label Label12 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Weapons"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   3000
      TabIndex        =   16
      Top             =   3360
      Width           =   1215
   End
   Begin VB.Label Label11 
      BackStyle       =   0  'Transparent
      Caption         =   "Hardware Points:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   18
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Left            =   5640
      TabIndex        =   15
      Top             =   0
      Width           =   1695
   End
   Begin VB.Label DispBullets 
      BackStyle       =   0  'Transparent
      Caption         =   "Bullets"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   3000
      TabIndex        =   6
      Top             =   2040
      Width           =   1215
   End
   Begin VB.Label DispProcessor 
      BackStyle       =   0  'Transparent
      Caption         =   "Processor Speed"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   3000
      TabIndex        =   5
      Top             =   0
      Width           =   2295
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "Max Steady Shield"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   360
      TabIndex        =   4
      Top             =   3360
      Width           =   2295
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "Max Damage"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   360
      TabIndex        =   3
      Top             =   1680
      Width           =   2175
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "Max Energy"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   360
      TabIndex        =   2
      Top             =   0
      Width           =   2175
   End
End
Attribute VB_Name = "HardwareWindow"
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

Dim HasCanceled As Boolean

' Bullets      '1 = Normal 2 = Explosive   0 = Rubber
' Turret     '1 = Line   2 = Dot         0 = None
' Drones    '0 = Not equiped    1 = Equipped    2 = Equipped but never used in the code (common for pre doppler titans)

Dim TheRobot As Robot
Dim LoadRobotPath As String
Const MCrec = 112
Dim CodeDrones As Boolean
Const insDRONE = 20348
Const insEND = 20110

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

Private Sub DDrone_Click()
Dim choseddrones As Byte
choseddrones = DDrone.Value

If choseddrones = 1 And Not CodeDrones Then choseddrones = 2

TheRobot.Drones = choseddrones
Räkna
End Sub

Private Sub DHellbore_Click()
TheRobot.Hellbores = DHellbore.Value
Räkna
End Sub

Private Sub DLaser_Click()
TheRobot.Lasers = DLaser.Value
Räkna
End Sub

Private Sub DMine_Click()
TheRobot.Mines = DMine.Value
Räkna
End Sub

Private Sub DMissile_Click()
TheRobot.Missiles = DMissile.Value
Räkna
End Sub

Private Sub DProbes_Click()
TheRobot.Probes = DProbes.Value
Räkna
End Sub

Private Sub DStunner_Click()
TheRobot.Stunners = DStunner.Value
Räkna
End Sub

Private Sub DTacNuke_Click()
TheRobot.TacNukes = DTacNuke.Value
Räkna
End Sub

Private Sub Form_Activate()
If TheRobot.Bullets < 0 Or TheRobot.Bullets > 2 Then
    MsgBox "Please rechoose the type of bullets your robot should use.", vbExclamation, "Invalid settings for Bullets"
    TheRobot.Bullets = 1
End If

If TheRobot.Turret < 0 Or TheRobot.Turret > 2 Then
        MsgBox "Please rechoose the turret shape your robot should use.", vbExclamation, "Invalid settings for Turret"
    TheRobot.Turret = 1
    End If
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
    Select Case KeyCode
        Case vbKeyF1
            'SkrivHardware
            Unload Me
            ''MainWindow.ViewMenu.Enabled = True
        Case vbKeyF2
            'SkrivHardware
            Unload Me
            DraftingBoard.Show 1, MainWindow
        Case vbKeyF4
            'SkrivHardware
            Unload Me
            ChooseIcon.Show 1, MainWindow
        Case vbKeyF5
            'SkrivHardware
            Unload Me
            SoundEditor.Show 1, MainWindow
    End Select
End Sub

Private Sub Form_Load()
'Ladda Hardware
'Load the Hardware
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

CodeDrones = False

Open LoadRobotPath For Binary As #1
    Get #1, , TheRobot
    
    Dim RNN As Long
    Dim InputInsts(4999) As Integer

    Get #1, MCrec, RNN
    Get #1, RNN, InputInsts

    For RNN = 0 To 4999
        If InputInsts(RNN) = insDRONE Then CodeDrones = True
        If InputInsts(RNN) = insEND Then Exit For
    Next RNN
Close 1

KollaHW
End Sub

Private Sub Form_Unload(Cancel As Integer)
If Not HasCanceled Then SkrivHardware
HasCanceled = False    'Dethär är väldigt mystiskt, det verkar komma ihåg att DoCancel = true när
'den stängs. Varning för kloning 'Men den verkar köra form load i alla fall
End Sub

Private Sub Label10_Click()
BulletPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#1.gif")
TheRobot.Bullets = 2
Räkna
End Sub

Private Sub Label13_Click()
DamagePict.Picture = LoadPicture(App.Path & "\miscdata\Control4#3.gif")
TheRobot.Damage = 60
Räkna
End Sub

Private Sub Label14_Click()
TurretPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#1.gif")
TheRobot.Turret = 1
'MainWindow.Turret(MainWindow.SelectedRobot).Visible = True
End Sub

Private Sub Label15_Click()
TurretPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#2.gif")
TheRobot.Turret = 2
End Sub

Private Sub Label16_Click()
TurretPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#3.gif")
TheRobot.Turret = 0
'MainWindow.Turret(MainWindow.SelectedRobot).Visible = False
End Sub

Private Sub Label17_Click()
DamagePict.Picture = LoadPicture(App.Path & "\miscdata\Control4#2.gif")
TheRobot.Damage = 100
Räkna
End Sub

Private Sub Label19_Click()
DamagePict.Picture = LoadPicture(App.Path & "\miscdata\Control4#1.gif")
TheRobot.Damage = 150
Räkna
End Sub

Private Sub Label2_Click()
EnergyPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#1.gif")
TheRobot.Energy = 150
Räkna
End Sub

Private Sub Label20_Click()
ShieldPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#4.gif")
TheRobot.Shield = 0
Räkna
End Sub

Private Sub Label21_Click()
ShieldPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#3.gif")
TheRobot.Shield = 25
Räkna
End Sub

Private Sub Label22_Click()
ShieldPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#2.gif")
TheRobot.Shield = 50
Räkna
End Sub

Private Sub Label23_Click()
ShieldPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#1.gif")
TheRobot.Shield = 100
Räkna
End Sub

Private Sub Label24_Click()
SpeedPict.Picture = LoadPicture(App.Path & "\miscdata\Control5#3.gif")
TheRobot.Speed = 15
Räkna
End Sub

Private Sub Label25_Click()
SpeedPict.Picture = LoadPicture(App.Path & "\miscdata\Control5#2.gif")
TheRobot.Speed = 30
Räkna
End Sub

Private Sub Label26_Click()
SpeedPict.Picture = LoadPicture(App.Path & "\miscdata\Control5#1.gif")
TheRobot.Speed = 50
Räkna
End Sub

Private Sub Label27_Click()
SpeedPict.Picture = LoadPicture(App.Path & "\miscdata\Control5#5.gif")
TheRobot.Speed = 5
Räkna
End Sub

Private Sub Label28_Click()
BulletPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#2.gif")
TheRobot.Bullets = 1
Räkna
End Sub

Private Sub Label29_Click()
BulletPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#3.gif")
TheRobot.Bullets = 0
Räkna
End Sub

Private Sub Label4_Click()
EnergyPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#2.gif")
TheRobot.Energy = 100
Räkna
End Sub

Private Sub Label6_Click()
EnergyPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#3.gif")
TheRobot.Energy = 60
Räkna
End Sub

Private Sub Label7_Click()
EnergyPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#4.gif")
TheRobot.Energy = 40
Räkna
End Sub

Private Sub Label8_Click()
SpeedPict.Picture = LoadPicture(App.Path & "\miscdata\Control5#4.gif")
TheRobot.Speed = 10
Räkna
End Sub

Private Sub Label9_Click()
DamagePict.Picture = LoadPicture(App.Path & "\miscdata\Control4#4.gif")
TheRobot.Damage = 30
Räkna
End Sub

Private Sub OKButton_Click()
'SkrivHardware
Unload Me
End Sub


Private Sub KollaHW()

'Energy

Select Case TheRobot.Energy
    Case 150
    EnergyPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#1.gif")
    Case 100
    EnergyPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#2.gif")
    Case 60
    EnergyPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#3.gif")
    Case 40
    EnergyPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#4.gif")
End Select

'Damage

Select Case TheRobot.Damage
    Case 150
    DamagePict.Picture = LoadPicture(App.Path & "\miscdata\Control4#1.gif")
    Case 100
    DamagePict.Picture = LoadPicture(App.Path & "\miscdata\Control4#2.gif")
    Case 60
    DamagePict.Picture = LoadPicture(App.Path & "\miscdata\Control4#3.gif")
    Case 30
    DamagePict.Picture = LoadPicture(App.Path & "\miscdata\Control4#4.gif")
End Select

'Shield

Select Case TheRobot.Shield
    Case 100
    ShieldPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#1.gif")
    Case 50
    ShieldPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#2.gif")
    Case 25
    ShieldPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#3.gif")
    Case 0
    ShieldPict.Picture = LoadPicture(App.Path & "\miscdata\Control4#4.gif")
End Select

'Processor Speed

Select Case TheRobot.Speed
    Case 50
    SpeedPict.Picture = LoadPicture(App.Path & "\miscdata\Control5#1.gif")
    Case 30
    SpeedPict.Picture = LoadPicture(App.Path & "\miscdata\Control5#2.gif")
    Case 15
    SpeedPict.Picture = LoadPicture(App.Path & "\miscdata\Control5#3.gif")
    Case 10
    SpeedPict.Picture = LoadPicture(App.Path & "\miscdata\Control5#4.gif")
    Case 5
    SpeedPict.Picture = LoadPicture(App.Path & "\miscdata\Control5#5.gif")
End Select

'Bullets

Select Case TheRobot.Bullets
    Case 2
    BulletPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#1.gif")
    Case 1
    BulletPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#2.gif")
    Case 0
    BulletPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#3.gif")
End Select

'Turret

Select Case TheRobot.Turret
    Case 2
    TurretPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#2.gif")
    Case 1
    TurretPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#1.gif")
    Case 0
    TurretPict.Picture = LoadPicture(App.Path & "\miscdata\Control3#3.gif")
End Select

    DMissile.Value = TheRobot.Missiles
    DTacNuke.Value = TheRobot.TacNukes
    DHellbore.Value = TheRobot.Hellbores
    DMine.Value = TheRobot.Mines
    DStunner.Value = TheRobot.Stunners
    DDrone.Value = Sgn(TheRobot.Drones)
    DLaser.Value = TheRobot.Lasers
    DProbes.Value = TheRobot.Probes
    
Räkna
End Sub

Private Sub Räkna()
Dim TotalCost As Integer

TotalCost = 0

Select Case TheRobot.Energy
    Case Is > 150
        Class.Caption = "Australian Ruler"
        DispTotalPoints = "23" & vbCr & Chr(160) & Chr(160) & ">"
        Exit Sub
    Case 150
        TotalCost = 3
    Case 100
        TotalCost = 2
    Case 60
        TotalCost = 1
    Case Is <> 40
        DispTotalPoints = "?"
        Exit Sub
End Select

Select Case TheRobot.Damage
    Case Is > 150
        Class.Caption = "Australian Ruler"
        DispTotalPoints = "23" & vbCr & Chr(160) & Chr(160) & ">"
        Exit Sub
    Case 150
        TotalCost = TotalCost + 3
    Case 100
        TotalCost = TotalCost + 2
    Case 60
        TotalCost = TotalCost + 1
    Case Is <> 30
        DispTotalPoints = "?"
        Exit Sub
End Select

Select Case TheRobot.Shield
    Case Is > 100
        Class.Caption = "Australian Ruler"
        DispTotalPoints = "23" & vbCr & Chr(160) & Chr(160) & ">"
        Exit Sub
    Case 100
        TotalCost = TotalCost + 3
    Case 50
        TotalCost = TotalCost + 2
    Case 25
        TotalCost = TotalCost + 1
    Case Is <> 0
        DispTotalPoints = "?"
        Exit Sub
End Select

Select Case TheRobot.Speed
    Case Is > 50
        Class.Caption = "Australian Ruler"
        DispTotalPoints = "23" & vbCr & Chr(160) & Chr(160) & ">"
        Exit Sub
    Case 50
        TotalCost = TotalCost + 4
    Case 30
        TotalCost = TotalCost + 3
    Case 15
        TotalCost = TotalCost + 2
    Case 10
        TotalCost = TotalCost + 1
    Case Is <> 5
        DispTotalPoints = "?"
        Exit Sub
End Select

Select Case TheRobot.Bullets
    Case 2
        TotalCost = TotalCost + 2
    Case 1
        TotalCost = TotalCost + 1
'    Case Is <> 0
'        MsgBox ("This robot has invalide bullets. Please rechoose the robots again.")
End Select

TotalCost = TotalCost + TheRobot.Missiles
TotalCost = TotalCost + TheRobot.Probes
TotalCost = TotalCost + TheRobot.TacNukes
TotalCost = TotalCost + TheRobot.Stunners
TotalCost = TotalCost + TheRobot.Hellbores
TotalCost = TotalCost + TheRobot.Mines
TotalCost = TotalCost + Sgn(TheRobot.Drones)
TotalCost = TotalCost + TheRobot.Lasers

DispTotalPoints.Caption = TotalCost

Select Case TotalCost
    Case 0 To 2
        Class.Caption = "Little Leaguer"
    Case 3 To 9
        Class.Caption = "Mortal"
    Case 10 To 23
        Class.Caption = "Titan"
'    Case Else                              Behövs inte
'        Class.Caption = "Austalian Ruler"  Not necesery anymore
End Select

End Sub

Private Sub RefreshHW(WhichRobot As Integer)
Select Case WhichRobot
    Case 1
        MainWindow.ER(1).Caption = TheRobot.Energy
        MainWindow.DR(1).Caption = TheRobot.Damage
        MainWindow.Robot1Energy = TheRobot.Energy
        MainWindow.Robot1Damage = TheRobot.Damage
        MainWindow.Robot1Shield = TheRobot.Shield
        MainWindow.Robot1ProSpeed = TheRobot.Speed
        MainWindow.Robot1Bullets = TheRobot.Bullets
        MainWindow.Robot1Probes = TheRobot.Probes
        MainWindow.Robot1Missiles = TheRobot.Missiles
        MainWindow.Robot1TacNukes = TheRobot.TacNukes
        MainWindow.Robot1Hellbores = TheRobot.Hellbores
        MainWindow.Robot1Drones = TheRobot.Drones
        MainWindow.Robot1Stunners = TheRobot.Stunners
        MainWindow.Robot1Mines = TheRobot.Mines
        MainWindow.Robot1Lasers = TheRobot.Lasers
        MainWindow.Robot1Turret = TheRobot.Turret
    Case 2
        MainWindow.ER(2).Caption = TheRobot.Energy
        MainWindow.DR(2).Caption = TheRobot.Damage
        MainWindow.Robot2Energy = TheRobot.Energy
        MainWindow.Robot2Damage = TheRobot.Damage
        MainWindow.Robot2Shield = TheRobot.Shield
        MainWindow.Robot2ProSpeed = TheRobot.Speed
        MainWindow.Robot2Bullets = TheRobot.Bullets
        MainWindow.Robot2Probes = TheRobot.Probes
        MainWindow.Robot2Missiles = TheRobot.Missiles
        MainWindow.Robot2TacNukes = TheRobot.TacNukes
        MainWindow.Robot2Hellbores = TheRobot.Hellbores
        MainWindow.Robot2Drones = TheRobot.Drones
        MainWindow.Robot2Stunners = TheRobot.Stunners
        MainWindow.Robot2Mines = TheRobot.Mines
        MainWindow.Robot2Lasers = TheRobot.Lasers
        MainWindow.Robot2Turret = TheRobot.Turret
    Case 3
        MainWindow.ER(3).Caption = TheRobot.Energy
        MainWindow.DR(3).Caption = TheRobot.Damage
        MainWindow.Robot3Energy = TheRobot.Energy
        MainWindow.Robot3Damage = TheRobot.Damage
        MainWindow.Robot3Shield = TheRobot.Shield
        MainWindow.Robot3ProSpeed = TheRobot.Speed
        MainWindow.Robot3Bullets = TheRobot.Bullets
        MainWindow.Robot3Probes = TheRobot.Probes
        MainWindow.Robot3Missiles = TheRobot.Missiles
        MainWindow.Robot3TacNukes = TheRobot.TacNukes
        MainWindow.Robot3Hellbores = TheRobot.Hellbores
        MainWindow.Robot3Drones = TheRobot.Drones
        MainWindow.Robot3Stunners = TheRobot.Stunners
        MainWindow.Robot3Mines = TheRobot.Mines
        MainWindow.Robot3Lasers = TheRobot.Lasers
        MainWindow.Robot3Turret = TheRobot.Turret
    Case 4
        MainWindow.ER(4).Caption = TheRobot.Energy
        MainWindow.DR(4).Caption = TheRobot.Damage
        MainWindow.Robot4Energy = TheRobot.Energy
        MainWindow.Robot4Damage = TheRobot.Damage
        MainWindow.Robot4Shield = TheRobot.Shield
        MainWindow.Robot4ProSpeed = TheRobot.Speed
        MainWindow.Robot4Bullets = TheRobot.Bullets
        MainWindow.Robot4Probes = TheRobot.Probes
        MainWindow.Robot4Missiles = TheRobot.Missiles
        MainWindow.Robot4TacNukes = TheRobot.TacNukes
        MainWindow.Robot4Hellbores = TheRobot.Hellbores
        MainWindow.Robot4Drones = TheRobot.Drones
        MainWindow.Robot4Stunners = TheRobot.Stunners
        MainWindow.Robot4Mines = TheRobot.Mines
        MainWindow.Robot4Lasers = TheRobot.Lasers
        MainWindow.Robot4Turret = TheRobot.Turret
    Case 5
        MainWindow.ER(5).Caption = TheRobot.Energy
        MainWindow.DR(5).Caption = TheRobot.Damage
        MainWindow.Robot5Energy = TheRobot.Energy
        MainWindow.Robot5Damage = TheRobot.Damage
        MainWindow.Robot5Shield = TheRobot.Shield
        MainWindow.Robot5ProSpeed = TheRobot.Speed
        MainWindow.Robot5Bullets = TheRobot.Bullets
        MainWindow.Robot5Probes = TheRobot.Probes
        MainWindow.Robot5Missiles = TheRobot.Missiles
        MainWindow.Robot5TacNukes = TheRobot.TacNukes
        MainWindow.Robot5Hellbores = TheRobot.Hellbores
        MainWindow.Robot5Drones = TheRobot.Drones
        MainWindow.Robot5Stunners = TheRobot.Stunners
        MainWindow.Robot5Mines = TheRobot.Mines
        MainWindow.Robot5Lasers = TheRobot.Lasers
        MainWindow.Robot5Turret = TheRobot.Turret
    Case 6
        MainWindow.ER(6).Caption = TheRobot.Energy
        MainWindow.DR(6).Caption = TheRobot.Damage
        MainWindow.Robot6Energy = TheRobot.Energy
        MainWindow.Robot6Damage = TheRobot.Damage
        MainWindow.Robot6Shield = TheRobot.Shield
        MainWindow.Robot6ProSpeed = TheRobot.Speed
        MainWindow.Robot6Bullets = TheRobot.Bullets
        MainWindow.Robot6Probes = TheRobot.Probes
        MainWindow.Robot6Missiles = TheRobot.Missiles
        MainWindow.Robot6TacNukes = TheRobot.TacNukes
        MainWindow.Robot6Hellbores = TheRobot.Hellbores
        MainWindow.Robot6Drones = TheRobot.Drones
        MainWindow.Robot6Stunners = TheRobot.Stunners
        MainWindow.Robot6Mines = TheRobot.Mines
        MainWindow.Robot6Lasers = TheRobot.Lasers
        MainWindow.Robot6Turret = TheRobot.Turret
    End Select
End Sub

Private Sub SkrivHardware()

'RefreshHW (MainWindow.SelectedRobot)
    
If MainWindow.R1path = LoadRobotPath Then RefreshHW (1)     'It doesn't mater if
If MainWindow.R2path = LoadRobotPath Then RefreshHW (2)     'it refreshes non-existing robots
If MainWindow.R3path = LoadRobotPath Then RefreshHW (3)     '(I think =S)
If MainWindow.R4path = LoadRobotPath Then RefreshHW (4)
If MainWindow.R5path = LoadRobotPath Then RefreshHW (5)
If MainWindow.R6path = LoadRobotPath Then RefreshHW (6)

Open LoadRobotPath For Binary As #1
    Put #1, , TheRobot
Close 1

'MsgBox MainWindow.Robot1Drones
End Sub
