VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "Comdlg32.ocx"
Begin VB.Form MainWindow 
   BackColor       =   &H007B511E&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "RoboWar 5 - Arena"
   ClientHeight    =   5505
   ClientLeft      =   45
   ClientTop       =   735
   ClientWidth     =   9510
   DrawMode        =   2  'Blackness
   FillColor       =   &H00A1A1A2&
   FillStyle       =   0  'Solid
   ForeColor       =   &H007B511E&
   Icon            =   "MainWindow.frx":0000
   LinkTopic       =   "Form1"
   MouseIcon       =   "MainWindow.frx":0E42
   ScaleHeight     =   367
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   634
   WindowState     =   2  'Maximized
   Begin VB.Timer TitleTimer 
      Enabled         =   0   'False
      Interval        =   1500
      Left            =   3600
      Top             =   4920
   End
   Begin VB.CommandButton StopTournament 
      BackColor       =   &H00DBC284&
      Caption         =   "Stop Tournament"
      Height          =   495
      Left            =   8160
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   4680
      Width           =   1215
      Visible         =   0   'False
   End
   Begin VB.PictureBox EnergyDisplay 
      Appearance      =   0  'Flat
      BackColor       =   &H007B511E&
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   6
      Left            =   6360
      ScaleHeight     =   255
      ScaleWidth      =   375
      TabIndex        =   79
      TabStop         =   0   'False
      Top             =   4080
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.PictureBox EnergyDisplay 
      Appearance      =   0  'Flat
      BackColor       =   &H007B511E&
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   5
      Left            =   6360
      ScaleHeight     =   255
      ScaleWidth      =   375
      TabIndex        =   78
      TabStop         =   0   'False
      Top             =   3360
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.PictureBox EnergyDisplay 
      Appearance      =   0  'Flat
      BackColor       =   &H007B511E&
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   4
      Left            =   6360
      ScaleHeight     =   255
      ScaleWidth      =   375
      TabIndex        =   77
      TabStop         =   0   'False
      Top             =   2640
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.PictureBox EnergyDisplay 
      Appearance      =   0  'Flat
      BackColor       =   &H007B511E&
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   3
      Left            =   6360
      ScaleHeight     =   255
      ScaleWidth      =   375
      TabIndex        =   76
      TabStop         =   0   'False
      Top             =   1920
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.PictureBox EnergyDisplay 
      Appearance      =   0  'Flat
      BackColor       =   &H007B511E&
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   2
      Left            =   6360
      ScaleHeight     =   255
      ScaleWidth      =   375
      TabIndex        =   75
      TabStop         =   0   'False
      Top             =   1200
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.PictureBox EnergyDisplay 
      Appearance      =   0  'Flat
      BackColor       =   &H007B511E&
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   1
      Left            =   6360
      ScaleHeight     =   255
      ScaleWidth      =   375
      TabIndex        =   74
      TabStop         =   0   'False
      Top             =   480
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.PictureBox NumerOfCrononsDisplay 
      Appearance      =   0  'Flat
      BackColor       =   &H007B511E&
      BorderStyle     =   0  'None
      FillColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   7200
      ScaleHeight     =   255
      ScaleWidth      =   855
      TabIndex        =   72
      TabStop         =   0   'False
      Top             =   4680
      Width           =   855
   End
   Begin VB.PictureBox Arena 
      Appearance      =   0  'Flat
      AutoRedraw      =   -1  'True
      BackColor       =   &H00FFFFFF&
      DrawMode        =   9  'Not Mask Pen
      FillStyle       =   0  'Solid
      ForeColor       =   &H80000008&
      Height          =   4530
      Left            =   120
      MouseIcon       =   "MainWindow.frx":1B0C
      ScaleHeight     =   300
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   300
      TabIndex        =   71
      TabStop         =   0   'False
      Top             =   120
      Width           =   4530
   End
   Begin VB.Timer CPRTimer 
      Enabled         =   0   'False
      Interval        =   1000
      Left            =   4320
      Top             =   4920
   End
   Begin MSComDlg.CommonDialog CommonDialog3 
      Left            =   8520
      Top             =   4920
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      CancelError     =   -1  'True
      Filter          =   "Robot|*.RWR|"
   End
   Begin MSComDlg.CommonDialog CommonDialog2 
      Left            =   9000
      Top             =   4440
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      DialogTitle     =   "Delete Robot"
      Filter          =   "Robots|*.RWR|All Files|*.*|"
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   9000
      Top             =   4920
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      DefaultExt      =   "rwr"
      DialogTitle     =   "Please choose a Robot"
      Filter          =   "Robots|*.RWR|All Files|*.*|"
      MaxFileSize     =   9999
   End
   Begin VB.CommandButton BattleHaltButton 
      BackColor       =   &H00DBC284&
      Caption         =   "Battle"
      CausesValidation=   0   'False
      Default         =   -1  'True
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   4800
      MaskColor       =   &H00FFFFFF&
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   4680
      Width           =   1215
   End
   Begin VB.PictureBox R1Icon 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      ForeColor       =   &H80000008&
      Height          =   510
      Left            =   4920
      ScaleHeight     =   32
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   32
      TabIndex        =   0
      TabStop         =   0   'False
      Top             =   120
      Width           =   510
   End
   Begin VB.PictureBox R2Icon 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      ForeColor       =   &H80000008&
      Height          =   510
      Left            =   4920
      ScaleHeight     =   32
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   32
      TabIndex        =   3
      TabStop         =   0   'False
      Top             =   840
      Width           =   510
   End
   Begin VB.PictureBox R3Icon 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      ForeColor       =   &H80000008&
      Height          =   510
      Left            =   4920
      ScaleHeight     =   32
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   32
      TabIndex        =   4
      TabStop         =   0   'False
      Top             =   1560
      Width           =   510
   End
   Begin VB.PictureBox R4Icon 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      ForeColor       =   &H80000008&
      Height          =   510
      Left            =   4920
      ScaleHeight     =   32
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   32
      TabIndex        =   5
      TabStop         =   0   'False
      Top             =   2280
      Width           =   510
   End
   Begin VB.PictureBox R5Icon 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      ForeColor       =   &H80000008&
      Height          =   510
      Left            =   4920
      ScaleHeight     =   32
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   32
      TabIndex        =   6
      TabStop         =   0   'False
      Top             =   3000
      Width           =   510
   End
   Begin VB.PictureBox R6Icon 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      ForeColor       =   &H80000008&
      Height          =   510
      Left            =   4920
      ScaleHeight     =   32
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   32
      TabIndex        =   7
      TabStop         =   0   'False
      Top             =   3720
      Width           =   510
   End
   Begin VB.Image Image2 
      Height          =   780
      Left            =   240
      Picture         =   "MainWindow.frx":23D6
      Top             =   4725
      Width           =   3345
   End
   Begin VB.Label TeamLabel 
      Alignment       =   2  'Center
      BackColor       =   &H00000000&
      BeginProperty Font 
         Name            =   "Arial Narrow"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   210
      Index           =   6
      Left            =   8880
      TabIndex        =   61
      Top             =   4200
      Width           =   510
      Visible         =   0   'False
   End
   Begin VB.Label TeamLabel 
      Alignment       =   2  'Center
      BackColor       =   &H00000000&
      BeginProperty Font 
         Name            =   "Arial Narrow"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   210
      Index           =   5
      Left            =   8880
      TabIndex        =   60
      Top             =   3480
      Width           =   510
      Visible         =   0   'False
   End
   Begin VB.Label TeamLabel 
      Alignment       =   2  'Center
      BackColor       =   &H00000000&
      BeginProperty Font 
         Name            =   "Arial Narrow"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   210
      Index           =   4
      Left            =   8880
      TabIndex        =   59
      Top             =   2760
      Width           =   510
      Visible         =   0   'False
   End
   Begin VB.Label TeamLabel 
      Alignment       =   2  'Center
      BackColor       =   &H00000000&
      BeginProperty Font 
         Name            =   "Arial Narrow"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   210
      Index           =   3
      Left            =   8880
      TabIndex        =   58
      Top             =   2040
      Width           =   510
      Visible         =   0   'False
   End
   Begin VB.Label TeamLabel 
      Alignment       =   2  'Center
      BackColor       =   &H00000000&
      BeginProperty Font 
         Name            =   "Arial Narrow"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   210
      Index           =   2
      Left            =   8880
      TabIndex        =   57
      Top             =   1320
      Width           =   510
      Visible         =   0   'False
   End
   Begin VB.Label TeamLabel 
      Alignment       =   2  'Center
      BackColor       =   &H00000000&
      BeginProperty Font 
         Name            =   "Arial Narrow"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   210
      Index           =   1
      Left            =   8880
      TabIndex        =   56
      Top             =   600
      Width           =   510
      Visible         =   0   'False
   End
   Begin VB.Label RobotDead 
      BackColor       =   &H007B511E&
      Caption         =   "Dead - Time:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   6
      Left            =   5640
      TabIndex        =   67
      Top             =   4080
      Width           =   2295
      Visible         =   0   'False
   End
   Begin VB.Label RobotDead 
      BackColor       =   &H007B511E&
      Caption         =   "Dead - Time:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   5
      Left            =   5640
      TabIndex        =   66
      Top             =   3360
      Width           =   2295
      Visible         =   0   'False
   End
   Begin VB.Label RobotDead 
      BackColor       =   &H007B511E&
      Caption         =   "Dead - Time:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   4
      Left            =   5640
      TabIndex        =   65
      Top             =   2640
      Width           =   2295
      Visible         =   0   'False
   End
   Begin VB.Label RobotDead 
      BackColor       =   &H007B511E&
      Caption         =   "Dead - Time:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   3
      Left            =   5640
      TabIndex        =   64
      Top             =   1920
      Width           =   2295
      Visible         =   0   'False
   End
   Begin VB.Label RobotDead 
      BackColor       =   &H007B511E&
      Caption         =   "Dead - Time:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   2
      Left            =   5640
      TabIndex        =   63
      Top             =   1200
      Width           =   2295
      Visible         =   0   'False
   End
   Begin VB.Label RobotDead 
      BackColor       =   &H007B511E&
      Caption         =   "Dead - Time:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   1
      Left            =   5640
      TabIndex        =   62
      Top             =   480
      Width           =   2295
      Visible         =   0   'False
   End
   Begin VB.Label Chronors 
      BackStyle       =   0  'Transparent
      Caption         =   "Chronons:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   6120
      TabIndex        =   73
      Top             =   4680
      Width           =   1095
   End
   Begin VB.Label ReplayText 
      BackStyle       =   0  'Transparent
      Caption         =   "Replay"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8640
      TabIndex        =   70
      Top             =   4920
      Width           =   615
      Visible         =   0   'False
   End
   Begin VB.Image Image1 
      Appearance      =   0  'Flat
      Height          =   360
      Index           =   5
      Left            =   8760
      Picture         =   "MainWindow.frx":2D01
      Top             =   3270
      Width           =   705
      Visible         =   0   'False
   End
   Begin VB.Image Image1 
      Appearance      =   0  'Flat
      Height          =   360
      Index           =   4
      Left            =   8760
      Picture         =   "MainWindow.frx":2E83
      Top             =   2550
      Width           =   705
      Visible         =   0   'False
   End
   Begin VB.Image Image1 
      Appearance      =   0  'Flat
      Height          =   360
      Index           =   3
      Left            =   8760
      Picture         =   "MainWindow.frx":3005
      Top             =   1830
      Width           =   705
      Visible         =   0   'False
   End
   Begin VB.Image Image1 
      Appearance      =   0  'Flat
      Height          =   360
      Index           =   2
      Left            =   8760
      Picture         =   "MainWindow.frx":3187
      Top             =   1110
      Width           =   705
      Visible         =   0   'False
   End
   Begin VB.Image Image1 
      Appearance      =   0  'Flat
      Height          =   360
      Index           =   1
      Left            =   8760
      Picture         =   "MainWindow.frx":3309
      Top             =   390
      Width           =   705
      Visible         =   0   'False
   End
   Begin VB.Image Image1 
      Appearance      =   0  'Flat
      Height          =   360
      Index           =   6
      Left            =   8760
      Picture         =   "MainWindow.frx":348B
      Top             =   3990
      Width           =   705
      Visible         =   0   'False
   End
   Begin VB.Label CPRLabel 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   6840
      TabIndex        =   69
      Top             =   5040
      Width           =   960
   End
   Begin VB.Label PerSecond 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "/second"
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   6120
      TabIndex        =   68
      Top             =   5040
      Width           =   615
   End
   Begin VB.Label Robot1 
      BackColor       =   &H007B511E&
      Caption         =   "No Robot Selected"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   11.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   300
      Left            =   5640
      TabIndex        =   49
      Top             =   120
      Width           =   3135
   End
   Begin VB.Label DR 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   6
      Left            =   7560
      TabIndex        =   55
      Top             =   4080
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label Robot6 
      BackColor       =   &H007B511E&
      Caption         =   "No Robot Selected"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   11.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   300
      Left            =   5640
      TabIndex        =   54
      Top             =   3720
      Width           =   3135
   End
   Begin VB.Label Robot5 
      BackColor       =   &H007B511E&
      Caption         =   "No Robot Selected"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   11.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   300
      Left            =   5640
      TabIndex        =   53
      Top             =   3000
      Width           =   3135
   End
   Begin VB.Label Robot4 
      BackColor       =   &H007B511E&
      Caption         =   "No Robot Selected"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   11.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   300
      Left            =   5640
      TabIndex        =   52
      Top             =   2280
      Width           =   3135
   End
   Begin VB.Label Robot3 
      BackColor       =   &H007B511E&
      Caption         =   "No Robot Selected"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   11.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   300
      Left            =   5640
      TabIndex        =   51
      Top             =   1560
      Width           =   3135
   End
   Begin VB.Label Robot2 
      BackColor       =   &H007B511E&
      Caption         =   "No Robot Selected"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   11.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   300
      Left            =   5640
      TabIndex        =   50
      Top             =   840
      Width           =   3135
   End
   Begin VB.Label Load6 
      Appearance      =   0  'Flat
      BackColor       =   &H004E2E03&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Load"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8880
      TabIndex        =   48
      Top             =   3720
      Width           =   495
      Visible         =   0   'False
   End
   Begin VB.Label Load2 
      Appearance      =   0  'Flat
      BackColor       =   &H004E2E03&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Load"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8880
      TabIndex        =   47
      Top             =   840
      Width           =   495
      Visible         =   0   'False
   End
   Begin VB.Label Load5 
      Appearance      =   0  'Flat
      BackColor       =   &H004E2E03&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Load"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8880
      TabIndex        =   46
      Top             =   3000
      Width           =   495
      Visible         =   0   'False
   End
   Begin VB.Label Load3 
      Appearance      =   0  'Flat
      BackColor       =   &H004E2E03&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Load"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8880
      TabIndex        =   45
      Top             =   1560
      Width           =   495
      Visible         =   0   'False
   End
   Begin VB.Label Load4 
      Appearance      =   0  'Flat
      BackColor       =   &H004E2E03&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Load"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8880
      TabIndex        =   44
      Top             =   2280
      Width           =   495
      Visible         =   0   'False
   End
   Begin VB.Label Load1 
      Appearance      =   0  'Flat
      BackColor       =   &H004E2E03&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Load"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000005&
      Height          =   255
      Left            =   8880
      TabIndex        =   43
      Top             =   120
      Width           =   495
   End
   Begin VB.Label PR6 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8520
      TabIndex        =   42
      Top             =   4080
      Width           =   405
      Visible         =   0   'False
   End
   Begin VB.Label PR5 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8520
      TabIndex        =   41
      Top             =   3360
      Width           =   405
      Visible         =   0   'False
   End
   Begin VB.Label PR4 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8520
      TabIndex        =   40
      Top             =   2640
      Width           =   405
      Visible         =   0   'False
   End
   Begin VB.Label PR3 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8520
      TabIndex        =   39
      Top             =   1920
      Width           =   405
      Visible         =   0   'False
   End
   Begin VB.Label PR2 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8520
      TabIndex        =   38
      Top             =   1200
      Width           =   405
      Visible         =   0   'False
   End
   Begin VB.Label PR1 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   8520
      TabIndex        =   37
      Top             =   480
      Width           =   405
      Visible         =   0   'False
   End
   Begin VB.Label DR 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   5
      Left            =   7560
      TabIndex        =   36
      Top             =   3360
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label DR 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   4
      Left            =   7560
      TabIndex        =   35
      Top             =   2640
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label DR 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   3
      Left            =   7560
      TabIndex        =   34
      Top             =   1920
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label DR 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   2
      Left            =   7560
      TabIndex        =   33
      Top             =   1200
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label DR 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   1
      Left            =   7560
      TabIndex        =   32
      Top             =   480
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label ER 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   6
      Left            =   6360
      TabIndex        =   31
      Top             =   4080
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label ER 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   5
      Left            =   6360
      TabIndex        =   30
      Top             =   3360
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label ER 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   4
      Left            =   6360
      TabIndex        =   29
      Top             =   2640
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label ER 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   3
      Left            =   6360
      TabIndex        =   28
      Top             =   1920
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label ER 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   2
      Left            =   6360
      TabIndex        =   27
      Top             =   1200
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label ER 
      BackStyle       =   0  'Transparent
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Index           =   1
      Left            =   6360
      TabIndex        =   26
      Top             =   480
      Width           =   375
      Visible         =   0   'False
   End
   Begin VB.Label Energy6X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Energy:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   5640
      TabIndex        =   25
      Top             =   4080
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Label Damage6X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Damage:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   6720
      TabIndex        =   24
      Top             =   4080
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Label Points6X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Points:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   7920
      TabIndex        =   23
      Top             =   4080
      Width           =   570
      Visible         =   0   'False
   End
   Begin VB.Label Energy5X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Energy:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   5640
      TabIndex        =   22
      Top             =   3360
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Label Damage5X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Damage:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   6720
      TabIndex        =   21
      Top             =   3360
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Label Points5X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Points:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   7920
      TabIndex        =   20
      Top             =   3360
      Width           =   570
      Visible         =   0   'False
   End
   Begin VB.Label Energy4X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Energy:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   5640
      TabIndex        =   19
      Top             =   2640
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Label Damage4X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Damage:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   6720
      TabIndex        =   18
      Top             =   2640
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Label Points4X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Points:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   7920
      TabIndex        =   17
      Top             =   2640
      Width           =   570
      Visible         =   0   'False
   End
   Begin VB.Label Energy3X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Energy:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   5640
      TabIndex        =   16
      Top             =   1920
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Label Damage3X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Damage:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   6720
      TabIndex        =   15
      Top             =   1920
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Label Points3X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Points:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   7920
      TabIndex        =   14
      Top             =   1920
      Width           =   570
      Visible         =   0   'False
   End
   Begin VB.Label Energy2X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Energy:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   5640
      TabIndex        =   13
      Top             =   1200
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Label Damage2X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Damage:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   6720
      TabIndex        =   12
      Top             =   1200
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Label Points2X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Points:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   7920
      TabIndex        =   11
      Top             =   1200
      Width           =   570
      Visible         =   0   'False
   End
   Begin VB.Label Points1X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Points:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   7920
      TabIndex        =   10
      Top             =   480
      Width           =   570
      Visible         =   0   'False
   End
   Begin VB.Label Damage1X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Damage:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   6720
      TabIndex        =   9
      Top             =   480
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Label Energy1X 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Energy:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   5640
      TabIndex        =   8
      Top             =   480
      Width           =   855
      Visible         =   0   'False
   End
   Begin VB.Menu FileMenu 
      Caption         =   "File"
      Begin VB.Menu NewRobot 
         Caption         =   "New Robot"
         Shortcut        =   ^N
      End
      Begin VB.Menu LoadRobot 
         Caption         =   "Load Robot"
         Shortcut        =   ^O
      End
      Begin VB.Menu Duplicate 
         Caption         =   "Duplicate"
         Shortcut        =   ^D
      End
      Begin VB.Menu SaveAs 
         Caption         =   "Save Robot As"
         Shortcut        =   ^A
      End
      Begin VB.Menu Close 
         Caption         =   "Close"
         Shortcut        =   ^W
      End
      Begin VB.Menu RenameRobot 
         Caption         =   "Rename Robot"
         Shortcut        =   ^F
      End
      Begin VB.Menu DelateRobot 
         Caption         =   "Delete Robot"
         Shortcut        =   +{DEL}
      End
      Begin VB.Menu Separator1 
         Caption         =   "-"
      End
      Begin VB.Menu Quit 
         Caption         =   "Quit"
         Shortcut        =   ^Q
      End
   End
   Begin VB.Menu ViewMenu 
      Caption         =   "View"
      Begin VB.Menu Area 
         Caption         =   "Arena"
         Checked         =   -1  'True
         Shortcut        =   {F1}
      End
      Begin VB.Menu Drafting 
         Caption         =   "Drafting Board"
         Shortcut        =   {F2}
      End
      Begin VB.Menu Hardware 
         Caption         =   "Hardware Store"
         Shortcut        =   {F3}
      End
      Begin VB.Menu Icon 
         Caption         =   "Icon Factory"
         Shortcut        =   {F4}
      End
      Begin VB.Menu Studio 
         Caption         =   "Recording Studio"
         Shortcut        =   {F5}
      End
      Begin VB.Menu Separator4 
         Caption         =   "-"
      End
      Begin VB.Menu Password 
         Caption         =   "Set Password"
      End
   End
   Begin VB.Menu ArenaMenu 
      Caption         =   "Arena"
      Begin VB.Menu NoTeam 
         Caption         =   "No Team"
         Shortcut        =   +{F4}
      End
      Begin VB.Menu Team1 
         Caption         =   "Team 1"
         Shortcut        =   +{F1}
      End
      Begin VB.Menu Team2 
         Caption         =   "Team 2"
         Shortcut        =   +{F2}
      End
      Begin VB.Menu Team3 
         Caption         =   "Team 3"
         Shortcut        =   +{F3}
      End
      Begin VB.Menu Separator5 
         Caption         =   "-"
      End
      Begin VB.Menu ResetHistory 
         Caption         =   "Reset History"
         Shortcut        =   {DEL}
      End
      Begin VB.Menu History 
         Caption         =   "Show History"
         Shortcut        =   ^H
      End
      Begin VB.Menu RepeatBattle 
         Caption         =   "Repeat Battle"
         Shortcut        =   ^R
      End
      Begin VB.Menu Separator6 
         Caption         =   "-"
      End
      Begin VB.Menu Tournament 
         Caption         =   "Tournament"
         Shortcut        =   ^T
      End
      Begin VB.Menu TestRobot 
         Caption         =   "Test Robot"
         Shortcut        =   ^Y
      End
      Begin VB.Menu Separator18 
         Caption         =   "-"
      End
      Begin VB.Menu Scoring 
         Caption         =   "Scoring: Standard"
      End
      Begin VB.Menu Separator16 
         Caption         =   "-"
      End
      Begin VB.Menu SetGameSpeed 
         Caption         =   "Set Game Speed"
      End
   End
   Begin VB.Menu PreferenceMenu 
      Caption         =   "Preference"
      Begin VB.Menu SpeedMenu 
         Caption         =   "Speed"
         Begin VB.Menu Fast 
            Caption         =   "Fast"
            Shortcut        =   ^{F5}
         End
         Begin VB.Menu Normal 
            Caption         =   "Normal"
            Checked         =   -1  'True
            Shortcut        =   ^{F4}
         End
         Begin VB.Menu Slow 
            Caption         =   "Slow"
            Shortcut        =   ^{F3}
         End
         Begin VB.Menu Slower 
            Caption         =   "Slower"
            Shortcut        =   ^{F2}
         End
         Begin VB.Menu Slowest 
            Caption         =   "Slowest"
            Shortcut        =   ^{F1}
         End
         Begin VB.Menu AutoRedrawFast 
            Caption         =   "Auto Redraw Fast"
            Shortcut        =   ^{F8}
            Visible         =   0   'False
         End
         Begin VB.Menu NoDisplay 
            Caption         =   "No Display (Faster)"
            Shortcut        =   ^{F6}
         End
         Begin VB.Menu Ultra 
            Caption         =   "Ultra (Fastest)"
            Shortcut        =   ^{F7}
         End
      End
      Begin VB.Menu Separator8 
         Caption         =   "-"
      End
      Begin VB.Menu Sounds 
         Caption         =   "Sounds"
         Checked         =   -1  'True
         Shortcut        =   ^S
      End
      Begin VB.Menu Separator9 
         Caption         =   "-"
      End
      Begin VB.Menu ChronorsLimit 
         Caption         =   "1500 Chronors Limit"
         Shortcut        =   ^L
      End
      Begin VB.Menu MoveAndShoot 
         Caption         =   "Disallow Move and Shoot "
         Shortcut        =   ^M
      End
      Begin VB.Menu Overloading 
         Caption         =   "Allow less than -200 Energy"
         Shortcut        =   ^E
      End
      Begin VB.Menu Separator14 
         Caption         =   "-"
      End
      Begin VB.Menu AutoNoSound 
         Caption         =   "Auto No Sound"
         Visible         =   0   'False
      End
      Begin VB.Menu resolution 
         Caption         =   "Auto Change Resolution"
      End
      Begin VB.Menu Separator15 
         Caption         =   "-"
      End
      Begin VB.Menu ChangeResolution 
         Caption         =   "Change Resolution"
      End
      Begin VB.Menu Separator11 
         Caption         =   "-"
      End
      Begin VB.Menu ShowMoveAndShoot 
         Caption         =   "Show Move + shoot messages"
         Checked         =   -1  'True
         Shortcut        =   ^V
      End
      Begin VB.Menu InactivateDebug 
         Caption         =   "Deactivate the ""Debug"" inst"
         Checked         =   -1  'True
         Shortcut        =   ^I
      End
   End
   Begin VB.Menu HelpMenu 
      Caption         =   "Help"
      Begin VB.Menu Help 
         Caption         =   "Help"
      End
      Begin VB.Menu Tutorial 
         Caption         =   "Tutorial"
      End
      Begin VB.Menu About 
         Caption         =   "About RoboWar 5"
      End
      Begin VB.Menu KnownBugs 
         Caption         =   "Known Bugs"
      End
      Begin VB.Menu WelcomeWindowSwitchMenu 
         Caption         =   "Show Welcome Window at Startup"
      End
      Begin VB.Menu Separator13 
         Caption         =   "-"
      End
      Begin VB.Menu Debugger 
         Caption         =   "Use Debugger"
         Shortcut        =   ^B
      End
      Begin VB.Menu StartAtChronon 
         Caption         =   "Repeat and Debug before crash"
         Shortcut        =   ^C
      End
   End
End
Attribute VB_Name = "MainWindow"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'               ##################
'            ####        ############
'          ##            ##############                 R O B O W A R  5
'        ##              ################
'       ##               #################             By Kevin Hertzberg
'      ##                ##################
'      ##                ##################           A Windows port of the Mac game RoboWar
'     ##                 ###################
'    ##                              ########
'    ##      ################################
'    ##                  ####################
'     ##                 ###################
'      ##                ##################
'      ##                ##################
'      ##                ##################
'      ##                      ############
'       ##         ##        #############
'        ##          ###################
'          ##            ##############
'            ##          ############
'              ###       #########
'                 ###############
'              Dialectix is a hero,
'         for all the dashers it killed.
'
'           + this "picture" is nice

'Thanks for reading the source code for RoboWar 5. If you have suggestions for
'improvements, you could email me at khertzberg@spray.se.

'Here's some things you should know about the code:

'I priorotize somewhat differently compared to the general standard

'Highest priority are Remove bugs, Backwards compatibility with the old version,
'Speed in non-displayed battles and tournaments, Confortability for the players
'Code maintability, Code readability are having lower priority

'Some people have expressed that the combat / dontshowbattle subroutines would be
'way easier to read if I split them up in subroutines. Calling subroutines is slower!

'The code for the following parts are messy and poorly written, but
'since the code works, optimizing it will only create more bugs:
'Loading, Closing, Duplicating, Save As, Renaming and the Tournament Engine
'Some of the code comments might also be a little outdated


Option Explicit
' **** API CALL'S DECLARATIONS

' PEEKMESSAGE API   -   To increase battle speed
                                 'looks at message and removes/leaves it if there is one
                                 'returns nonzero if a message was in event queue
Private Declare Function PeekMessage Lib "user32" Alias "PeekMessageA" (lpMsg As MSG, ByVal hwnd As Long, ByVal wMsgFilterMin As Long, ByVal wMsgFilterMax As Long, ByVal wRemoveMsg As Long) As Long
'                                 'dispatches message calls the right message handling procedure
'Private Declare Function DispatchMessage Lib "user32" Alias "DispatchMessageA" (lpMsg As MSG) As Long
'                                 'virtual accelerator key translator
'                                 'dont worry about what it does just leave it there
'Private Declare Function TranslateMessage Lib "user32" (lpMsg As MSG) As Long
'                                 'holds elapsed time since windows was started
'Private Declare Function GetTickCount Lib "kernel32" () As Long
'                                 'gets next message in event queue
'Private Declare Function GetMessage Lib "user32" Alias "GetMessageA" (lpMsg As MSG, ByVal hwnd As Long, ByVal wMsgFilterMin As Long, ByVal wMsgFilterMax As Long) As Long
'                                 'checks if there is a message in event queue
'Private Declare Function GetQueueStatus Lib "user32" (ByVal fuFlags As Long) As Long

                           
'Private Const MY_WM_QUIT = &HA1     'WM_QUIT in api viewer is wrong this is the right constant
'
'Private Const PM_REMOVE = &H1       'paramater on peekmessage to remove or leave message in queue
Private Const PM_NOREMOVE = &H0
'                                    'type of events that can happen with window
'Private Const QS_MOUSEBUTTON = &H4
'Private Const QS_MOUSEMOVE = &H2
'Private Const QS_PAINT = &H20
'Private Const QS_POSTMESSAGE = &H8  'any other message
'Private Const QS_TIMER = &H10
'Private Const QS_HOTKEY = &H80
'Private Const QS_KEY = &H1
'Private Const QS_MOUSE = (QS_MOUSEMOVE Or QS_MOUSEBUTTON)
'Private Const QS_INPUT = (QS_MOUSE Or QS_KEY)
'Private Const QS_ALLEVENTS = (QS_INPUT Or QS_POSTMESSAGE Or QS_TIMER Or QS_PAINT Or QS_HOTKEY)
'
''extra messages that can be sent (not used in example)
'Private Const QS_SENDMESSAGE = &H40    'message sent by other thread or app
'Private Const QS_ALLINPUT = (QS_SENDMESSAGE Or QS_PAINT Or QS_TIMER Or QS_POSTMESSAGE Or QS_MOUSEBUTTON Or QS_MOUSEMOVE Or QS_HOTKEY Or QS_KEY)
''*************************

Private Type POINTAPI
   X As Long
   Y As Long
End Type

Private Type MSG
   hwnd     As Long        'window where message occured
   Message  As Long        'message id itself
   wParam   As Long        'further defines message
   lParam   As Long        'further defines message
   time     As Long        'time of message event
   pt       As POINTAPI    'position of mouse
End Type

Dim Message As MSG         'holds message recieved from queue

' SNDPLAYSOUND API      -       To play sounds (no kidding?)
Private Declare Function sndPlaySound Lib "winmm" Alias "sndPlaySoundA" (SoundData As Any, ByVal uFlags As Long) As Long
'Then we have to declare the constants that go along with the sndPlaySound function
Const SND_ASYNC = &H1       'ASYNC allows us to play waves with the ability to interrupt
'Const SND_LOOP = &H8        'LOOP causes to sound to be continuously replayed
Const SND_NODEFAULT = &H2   'NODEFAULT causes no sound to be played if the wav can't be found
'Const SND_SYNC = &H0        'SYNC plays a wave file without returning control to the calling program until it's finished
'Const SND_NOSTOP = &H10     'NOSTOP ensures that we don't stop another wave from playing
Const SND_MEMORY = &H4      'MEMORY plays a wave file stored in memory

' **** GOBAL / MODULE LEVEL DECLARATIONS (NON API)

'New RWR file format constants
Const sndrec = 32
Const iconrec = 72
Const MCrec = 112
Const Crec = 116
Const zeroexists = 130  'same as iconspresent
Const soundspresent = 120
Const recsoundstartzero = 142   'Where we will find sound 0
'Const CPosrec = 28

'The weapon constans, so we don't have to keep in mind which weapon represented by which number
Const Missile As Long = 0
Const Hellbore As Long = 1
Const Bullet As Long = 2 'Used for Rubber bullets too
Const ExplosiveBullet As Long = 3
Const XplosiveBulletDetonation As Long = 4    'Detonation
Const Mine As Long = 5
Const TakeNuke As Long = 6
Const Stunner As Long = 7
Const Laser As Long = 208    'Higher than 199 won't show up on the radar
Const Drone As Long = 9
Const MegaNuke As Long = 10
Const NOSHOT As Long = 200
Const SHOTHIT As Long = 150

'Adjustment constants for the new weapons
Const MegaNukeBLASTRADIUS = 20
Const MegaNukePOWER = 1.5
Const MegaNukeOUTERRINGCOLOR = &HFF80FF
Const MegaNukeFILLCOLOR = &HFFC0FF

'Instructions constants - Magic Numbers
Const insPLUS = 20000
Const insMINUS = 20001
Const insTIMES = 20002
Const insDIVISION = 20003
Const insMORE = 20004
Const insLESS = 20005
Const insSAME = 20006
Const insNOT_SAME = 20007
Const insSTORE = 20100
Const insDROP = 20101
Const insSWAP = 20102
Const insROLL = 20103
Const insJUMP = 20104
Const insCALL = 20105
Const insDUP = 20106
Const insIF = 20107
Const insIFE = 20108
Const insRECALL = 20109
Const insEND = 20110
Const insNOP = 20111
Const insAND = 20112
Const insOR = 20113
Const insXOR = 20114
Const insMOD = 20115
Const insBEEP = 20116
Const insCHS = 20117
Const insNOT = 20118
Const insARCTAN = 20119
Const insABS = 20120
Const insSIN = 20121
Const insCOS = 20122
Const insTAN = 20123
Const insSQRT = 20124
Const insICON0 = 20125
Const insICON1 = 20126
Const insICON2 = 20127
Const insICON3 = 20128
Const insICON4 = 20129
Const insICON5 = 20130
Const insICON6 = 20131
Const insICON7 = 20132
Const insICON8 = 20133
Const insICON9 = 20134
Const insPRINT = 20135
Const insSYNC = 20136
Const insVSTORE = 20137
Const insVRECALL = 20138
Const insDIST = 20139
Const insIFG = 20140
Const insIFEG = 20141
Const insDEBUG = 20142
Const insSND0 = 20143
Const insSND1 = 20144
Const insSND2 = 20145
Const insSND3 = 20146
Const insSND4 = 20147
Const insSND5 = 20148
Const insSND6 = 20149
Const insSND7 = 20150
Const insSND8 = 20151
Const insSND9 = 20152
Const insINTON = 20153
Const insINTOFF = 20154
Const insRTI = 20155
Const insSETINT = 20156
Const insSETPARAM = 20157
'Const insMRB = 20158
Const insDROPALL = 20159
Const insFLUSHINT = 20160
Const insMAX = 20161
Const insMIN = 20162
Const insARCCOS = 20163
Const insARCSIN = 20164
Const insA = 20300
Const insB = 20301
Const insC = 20302
Const insD = 20303
Const insE = 20304
Const insF = 20305
Const insG = 20306
Const insH = 20307
Const insI = 20308
Const insJ = 20309
Const insK = 20310
Const insL = 20311
Const insM = 20312
Const insN = 20313
Const insO = 20314
Const insP = 20315
Const insQ = 20316
Const insR = 20317
Const insS = 20318
Const Inst = 20319
Const insU = 20320
Const insV = 20321
Const insW = 20322
Const insX = 20323
Const insY = 20324
Const insZ = 20325
Const insFIRE = 20326
Const insENERGY = 20327
Const insSHIELD = 20328
Const insRANGE = 20329
Const insAIM = 20330
Const insSPEEDX = 20331
Const insSPEEDY = 20332
Const insDAMAGE = 20333
Const insRANDOM = 20334
Const insMISSILE = 20335
Const insNUKE = 20336
Const insCOLLISION = 20337
Const insCHANNEL = 20338
Const insSIGNAL = 20339
Const insMOVEX = 20340
Const insMOVEY = 20341
'Const insJOCE = 20342
Const insRADAR = 20343
Const insLOOK = 20344
Const insSCAN = 20345
Const insCHRONON = 20346
Const insHELLBORE = 20347
Const insDRONE = 20348
Const insMINE = 20349
Const insLASER = 20350
'Const insSUSIE = 20351
Const insROBOTS = 20352
Const insFRIEND = 20353
Const insBULLET = 20354
Const insDOPPLER = 20355
Const insSTUNNER = 20356
Const insTOP = 20357
Const insBOT = 20358
Const insLEFT = 20359
Const insRIGHT = 20360
Const insWALL = 20361
Const insTEAMMATES = 20362
Const insPROBE = 20363
Const insHISTORY = 20364
Const insID = 20365
Const insKILLS = 20366

Const insNEAREST = 20367
Const insMEGANUKE = 20368

Const TOPREGISTER = 20368

'Error Messages
Const BuggyDivRelated = 11
Const BuggyUnknownOrIllegal = 0
Const BuggyUnderflow = -1
Const BuggyOverflow = -2
Const BuggyRecall = -3
Const BuggySquare = -4
Const BuggyDestination = -5
Const BuggyChannel = -6
Const BuggyNearest = -7
'Const BuggyUnknown = -8
Const BuggyNumberOutofBounds = -9
Const BuggyMissiles = -10
Const BuggyDivision = -11
Const BuggyStunners = -12
Const BuggyTacNukes = -13
Const BuggyHellbores = -14
Const BuggyMines = -15
Const BuggyLasers = -16
Const BuggyDrones = -17
Const BuggyProbes = -18
Const BuggySetparam = -200
Const BuggySetint = -201
Const BuggyStore = -202


' Team Color constants
Const ColorTeam1 = &HFF8080
Const ColorTeam2 = vbGreen
Const ColorTeam3 = &HFF&

' Background color
Const BackgroundColor = &H7B511E

'Trigonometry translation constants
Const PIO As Double = 0.01745329252    'Pi / 180
Const TPI As Double = 57.2957795131    '180 / Pi

' Trig Cache
Dim Sine(720) As Double
Dim Cosine(720) As Double

Dim Sin10(360) As Double
Dim Cos10(360) As Double

Dim Sin11(360) As Double
Dim Cos11(360) As Double

Dim Sin5(360) As Double
Dim Cos5(360) As Double

Dim Sin14(360) As Double
Dim Cos14(360) As Double

Dim Sin12(360) As Double
Dim Cos12(360) As Double

Dim Sin6(360) As Double
Dim Cos6(360) As Double

'Square Cache
Dim Square(180000) As Double
Dim FixSquare(180000) As Long

'Wall Collision Cache
Dim WCX(-20 To 320) As Boolean
Dim WCY(-20 To 320) As Boolean

' Game and Preference related Stuff
Private Type Robot   'Object used to load robots easier
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

Public ResolutionChanged As Long
Dim DebuggedRobot As Long

Dim StartDebuggerAt As Long
Dim WillBeDebugged As Long
Const DEBUGATNOTSET As Long = -32768

Dim MaxChronon As Long
Public SelectedRobot As Long
Dim Chronon As Long
Dim CprTimerCount As Long   'Used for the Chronons per second counting
Dim PlaySounds As Boolean   'Cached Mirror of Sounds.Checked
Dim Replaying As Boolean    'Cached Mirror of RepeatBattle.Checked
Dim EnableOverloading As Boolean 'Cached Mirror of Overloading.Checked
Dim MoveAndShotAllowed As Boolean 'Cached Inverted Mirror of DisallowMoveAndShoot.Checked
Dim StandardScoring As Boolean  'True = Standard, False = 4.5.2
Dim BattleSpeed As Single
Dim TheSpeedConstant As Single
Dim Draging As Long     'Which robot is dragged around
Dim DroneR As Picture, DroneL As Picture, DroneU As Picture, DroneD As Picture
Dim DroneDiagonally(3 To 6) As Picture
Dim NumberOfRobotsPresent As Long
Dim HighestToLowest As Boolean  'Which evaluation order we're using. False = Robot 1 to Robot 6, True = Robot 1 to Robot 6
Dim RunningTournament As Boolean
Dim DebuggerAutoStart As Boolean
Dim HideBattle As Boolean   'Cached NoDisplay.Checked and Ultra.Checked
Dim UltraWarning As Byte

Private Type ShotPrivateType
    ShotType As Long
    ShotX As Single 'Single
    ShotY As Single 'Single
    ShotFireTime As Long
    ShotPower As Long
    ShotAngle As Long
    Shooter As Long
End Type

' Tournament Log Vars and Types
Private Type TournamentLogType
    WhosWho(1 To 6) As String
    killer(1 To 6) As Integer
    DeathTime(1 To 6) As Integer
    Kills(1 To 6) As Integer
    SurvivalPoints(1 To 6) As Integer
End Type

Dim TournamentLog() As TournamentLogType
Dim PrintTournamentLog As Boolean
Dim LogWhichBattle As Long
Dim WindowMini As Boolean
Dim sMainWindowCaption As String

'Robot Interface Properties
Dim RobotTeam(1 To 6) As Long
Dim LastStartPosX(1 To 6) As Long, LastStartPosY(1 To 6) As Long

Dim R1Present As Boolean, R2Present As Boolean, R3Present As Boolean, R4Present As Boolean, R5Present As Boolean, R6Present As Boolean
Public R1path As String, R2path As String, R3path As String, R4path As String, R5path As String, R6path As String

Public Robot1Energy As Long, Robot2Energy As Long, Robot3Energy As Long, Robot4Energy As Long, Robot5Energy As Long, Robot6Energy As Long
Public Robot1Damage As Long, Robot2Damage As Long, Robot3Damage As Long, Robot4Damage As Long, Robot5Damage As Long, Robot6Damage As Long
Public Robot1Shield As Long, Robot2Shield As Long, Robot3Shield As Long, Robot4Shield As Long, Robot5Shield As Long, Robot6Shield As Long
Public Robot1ProSpeed As Long, Robot2ProSpeed As Long, Robot3ProSpeed As Long, Robot4ProSpeed As Long, Robot5ProSpeed As Long, Robot6ProSpeed As Long
Public Robot1Bullets As Long, Robot2Bullets As Long, Robot3Bullets As Long, Robot4Bullets As Long, Robot5Bullets As Long, Robot6Bullets As Long
Public Robot1Turret As Long, Robot2Turret As Long, Robot3Turret As Long, Robot4Turret As Long, Robot5Turret As Long, Robot6Turret As Long
Public Robot1Probes As Long, Robot2Probes As Long, Robot3Probes As Long, Robot4Probes As Long, Robot5Probes As Long, Robot6Probes As Long
Public Robot1Missiles As Long, Robot2Missiles As Long, Robot3Missiles As Long, Robot4Missiles As Long, Robot5Missiles As Long, Robot6Missiles As Long
Public Robot1TacNukes As Long, Robot2TacNukes As Long, Robot3TacNukes As Long, Robot4TacNukes As Long, Robot5TacNukes As Long, Robot6TacNukes As Long
Public Robot1Hellbores As Long, Robot2Hellbores As Long, Robot3Hellbores As Long, Robot4Hellbores As Long, Robot5Hellbores As Long, Robot6Hellbores As Long
Public Robot1Drones As Long, Robot2Drones As Long, Robot3Drones As Long, Robot4Drones As Long, Robot5Drones As Long, Robot6Drones As Long
Public Robot1Stunners As Long, Robot2Stunners As Long, Robot3Stunners As Long, Robot4Stunners As Long, Robot5Stunners As Long, Robot6Stunners As Long
Public Robot1Mines As Long, Robot2Mines As Long, Robot3Mines As Long, Robot4Mines As Long, Robot5Mines As Long, Robot6Mines As Long
Public Robot1Lasers As Long, Robot2Lasers As Long, Robot3Lasers As Long, Robot4Lasers As Long, Robot5Lasers As Long, Robot6Lasers As Long

Public Robot1ShieldIcon As Long, Robot2ShieldIcon As Long, Robot3ShieldIcon As Long, Robot4ShieldIcon As Long, Robot5ShieldIcon As Long, Robot6ShieldIcon As Long
Public Robot1HitIcon As Long, Robot2HitIcon As Long, Robot3HitIcon As Long, Robot4HitIcon As Long, Robot5HitIcon As Long, Robot6HitIcon As Long
Public Robot1BlockIcon As Long, Robot2BlockIcon As Long, Robot3BlockIcon As Long, Robot4BlockIcon As Long, Robot5BlockIcon As Long, Robot6BlockIcon As Long
Public Robot1DeathIcon As Long, Robot2DeathIcon As Long, Robot3DeathIcon As Long, Robot4DeathIcon As Long, Robot5DeathIcon As Long, Robot6DeathIcon As Long
Public Robot1CollisionIcon As Long, Robot2CollisionIcon As Long, Robot3CollisionIcon As Long, Robot4CollisionIcon As Long, Robot5CollisionIcon As Long, Robot6CollisionIcon As Long

Dim MasterCode(1 To 6, 4999) As Long

Dim RobotDeathSound(1 To 6) As Boolean  'Keeps track of if the robot uses it's own sounds or the standard ones
Dim RobotCollisionSound(1 To 6) As Boolean
Dim RobotBlockSound(1 To 6) As Boolean
Dim RobotHitSound(1 To 6) As Boolean

'Robot variabler - De som var objektegenskaper tidigare
Dim TurretX2(1 To 6) As Long
Dim TurretY2(1 To 6) As Long
Dim RobotLeft(1 To 6) As Long
Dim RobotTop(1 To 6) As Long
Dim RobotMasterIcon(10 To 69) As Picture
'Dim RobotMasterSound(10 To 69) As String       'Yeah, the sound system ain't perfect... :P
Dim missilesound() As Byte, hellboresound() As Byte, bulletsound() As Byte, minesound() As Byte, takenukesound() As Byte, lasersound() As Byte, DroneSound() As Byte
Dim hitsound() As Byte, deathsound() As Byte, collisionsound() As Byte, beepsound() As Byte
Dim r1s0() As Byte, r1s1() As Byte, r1s2() As Byte, r1s3() As Byte, r1s4() As Byte, r1s5() As Byte, r1s6() As Byte, r1s7() As Byte, r1s8() As Byte, r1s9() As Byte
Dim r2s0() As Byte, r2s1() As Byte, r2s2() As Byte, r2s3() As Byte, r2s4() As Byte, r2s5() As Byte, r2s6() As Byte, r2s7() As Byte, r2s8() As Byte, r2s9() As Byte
Dim r3s0() As Byte, r3s1() As Byte, r3s2() As Byte, r3s3() As Byte, r3s4() As Byte, r3s5() As Byte, r3s6() As Byte, r3s7() As Byte, r3s8() As Byte, r3s9() As Byte
Dim r4s0() As Byte, r4s1() As Byte, r4s2() As Byte, r4s3() As Byte, r4s4() As Byte, r4s5() As Byte, r4s6() As Byte, r4s7() As Byte, r4s8() As Byte, r4s9() As Byte
Dim r5s0() As Byte, r5s1() As Byte, r5s2() As Byte, r5s3() As Byte, r5s4() As Byte, r5s5() As Byte, r5s6() As Byte, r5s7() As Byte, r5s8() As Byte, r5s9() As Byte
Dim r6s0() As Byte, r6s1() As Byte, r6s2() As Byte, r6s3() As Byte, r6s4() As Byte, r6s5() As Byte, r6s6() As Byte, r6s7() As Byte, r6s8() As Byte, r6s9() As Byte

Dim RangedRobot(1 To 6) As Long 'Moduleglobal because it's set in the Range Subroutine

Dim RobotShieldIcon(1 To 6) As Long 'Keeps track of if the robot automatically switches on icon 1 when shielding
Dim RobotHitIcon(1 To 6) As Long
Dim RobotBlockIcon(1 To 6) As Long
Dim RobotDeathIcon(1 To 6) As Long
Dim RobotCollisionIcon(1 To 6) As Long

Dim Robot_(1 To 6) As Picture

Dim HistoryRec(1 To 6, 1 To 50) As Long
Dim BackupHistoryRec(1 To 6, 1 To 50) As Long   'Used for repeat battle
Dim RandomRegister() As Long 'Used for repeat battle
Dim NotRandomEmergency As Boolean
Dim KR(1 To 6) As Long           'Number of kills the bot has made


Private Sub Form_Load()
Dim check As Long
Dim YesOrNo As Boolean
Dim NameVar1 As String

'    Get 7, 4000                               'Window State DraftingBoard
    Get 7, 4500, YesOrNo                       'Window State MainWindow
        If YesOrNo = False Then MainWindow.WindowState = 0
'    Get 7, 7000, 'First Time Startup?   '(var bakgrundsfärg tidigare)
Me.Show
    Get 7, 1000, YesOrNo                       'Sounds
        If YesOrNo Then PlaySounds = True Else Sounds.Checked = False
'    Get 7, 2000, 'Tom (var Auto No Sound Warning tidigare)
    Get 7, 2500, YesOrNo                       'Scoring System
        If YesOrNo Then
            Scoring.Caption = "Scoring: Mac (4.5.2)"
        Else
            'Scoring.Caption = "Scoring: Standard"
            StandardScoring = True
        End If
    Get 7, 3000, YesOrNo                       'Chrononlimit
        If YesOrNo Then
            ChronorsLimit.Checked = True
            MaxChronon = 1500
        Else
            ChronorsLimit.Checked = False
            MaxChronon = -1
        End If
    '3250 Overwrite Tournament
    '3500 Overwrite Testing
    '4000 Window state DraftingBoard
    '4500 Window state MainWindow
    Get 7, 5000, YesOrNo                       'Move and shoot
         MoveAndShoot.Checked = YesOrNo
         MoveAndShotAllowed = Not YesOrNo
'   Get 7, 5500,                               'Reset Cursor Position
    Get 7, 6000, YesOrNo                       'Overload
        Overloading.Checked = YesOrNo
        EnableOverloading = Not YesOrNo
'    Get 7, 6500, YesOrNo                       'Move and shoot message
'        ShowMoveAndShoot.Checked = YesOrNo
'    Get 7, 7000,                               First Time Startup? Tidigare Bakgrundsfärg
    Get 7, 7500, UltraWarning                   '            Ultravarning
'    Get 7, 8000,                               Auto Recompile
'    Get 7, 9000                                'DebuggingWindow Position
'    Get 7, 10000,                             'Skriv ut intructionsnumret
'    Get 7, 10500,                             'Syntax Coloring
'    Get 7, 11000, RSpeed
    Get 7, 12000, YesOrNo                     'Change resolution
        If YesOrNo Then
            resolution.Checked = True
            ResolutionChanged = 1
        End If
    Get 7, 12500, TheSpeedConstant
'    Get 7, 13000   'Auto no sound
Dim RSpeed As Long                  'Speed
    Get 7, 11000, RSpeed
        Select Case RSpeed
            Case 1
                Slowest.Checked = True
                Normal.Checked = False
                BattleSpeed = 0.5 * TheSpeedConstant
            Case 2
                Slower.Checked = True
                Normal.Checked = False
                BattleSpeed = 1 / 12 * TheSpeedConstant
            Case 3
                Slow.Checked = True
                Normal.Checked = False
                BattleSpeed = 1 / 30 * TheSpeedConstant
            Case 4
                BattleSpeed = 1 / 70 * TheSpeedConstant
            Case 5
                Normal.Checked = False
                Fast.Checked = True
                Arena.AutoRedraw = False
                BattleSpeed = 1E-37
            Case 6
                Normal.Checked = False
                AutoRedrawFast.Checked = True
                BattleSpeed = 1E-37
            Case 7
                Normal.Checked = False
                NoDisplay.Checked = True
                Arena.AutoRedraw = False
                BattleSpeed = 1E-37
                HideBattle = True
            Case 8
                Normal.Checked = False
                Ultra.Checked = True
                Arena.AutoRedraw = False
                BattleSpeed = 1E-37
                HideBattle = True
        End Select

'******** I've disabled Auto No Sound, due that it was probably very few people that was using it and knew what it meant
'    Get 7, 13000, YesOrNo                     'Auto no sound - Must be after battlespeed
'        If YesOrNo Then
            'AutoNoSound.Checked = True     'We enabled it on the menu editor.
            Sounds.Enabled = Not (Fast.Checked Or AutoRedrawFast.Checked Or HideBattle)
            PlaySounds = Not (Fast.Checked Or AutoRedrawFast.Checked Or HideBattle) And Sounds.Checked
'        End If

'Här låg det blocket som ligger sist förut (Robotladdningsblocket)


'Trig Cache
For check = 0 To 360
    Sine(check) = Sin(check * PIO)
    Cosine(check) = Cos(check * PIO)
    Sine(check + 360) = Sine(check)
    Cosine(check + 360) = Cosine(check)

    Sin11(check) = 11 * Sine(check)
    Cos11(check) = 11 * Cosine(check)

    Sin10(check) = 10 * Sine(check)
    Cos10(check) = 10 * Cosine(check)

    Sin5(check) = 5 * Sine(check)
    Cos5(check) = 5 * Cosine(check)

    Sin14(check) = 14 * Sine(check)
    Cos14(check) = 14 * Cosine(check)

    Sin12(check) = 12 * Sine(check)
    Cos12(check) = 12 * Cosine(check)
    
    Sin6(check) = 6 * Sine(check)
    Cos6(check) = 6 * Cosine(check)
Next check

For check = 0 To 180000
    Square(check) = Sqr(check)
    FixSquare(check) = Fix(Square(check))
Next

For check = -20 To 9
    WCX(check) = True
    WCY(check) = True
Next check

For check = 291 To 320
    WCX(check) = True
    WCY(check) = True
Next check

'Loads the drones
Set DroneD = LoadPicture(App.Path & "\miscdata\droned.bmp")
Set DroneL = LoadPicture(App.Path & "\miscdata\dronel.bmp")
Set DroneU = LoadPicture(App.Path & "\miscdata\droneu.bmp")
Set DroneR = LoadPicture(App.Path & "\miscdata\droner.bmp")

Set DroneDiagonally(3) = LoadPicture(App.Path & "\miscdata\dronelu.bmp")
Set DroneDiagonally(4) = LoadPicture(App.Path & "\miscdata\droneld.bmp")
Set DroneDiagonally(5) = LoadPicture(App.Path & "\miscdata\droneru.bmp")
Set DroneDiagonally(6) = LoadPicture(App.Path & "\miscdata\dronerd.bmp")

'Random Number Generator
Randomize

'Start debugging at
StartDebuggerAt = DEBUGATNOTSET

'InizSounds
Open App.Path & "\miscdata\Missile.wav" For Binary As #1
    ReDim missilesound(LOF(1)): Get #1, , missilesound
Close 1
Open App.Path & "\miscdata\Hellbore.wav" For Binary As #1
    ReDim hellboresound(LOF(1)): Get #1, , hellboresound
Close 1
Open App.Path & "\miscdata\Gun.wav" For Binary As #1
    ReDim bulletsound(LOF(1)): Get #1, , bulletsound
Close 1
Open App.Path & "\miscdata\Mine.wav" For Binary As #1
    ReDim minesound(LOF(1)): Get #1, , minesound
Close 1
Open App.Path & "\miscdata\Nukebang.wav" For Binary As #1
    ReDim takenukesound(LOF(1)): Get #1, , takenukesound
Close 1
Open App.Path & "\miscdata\Laser.wav" For Binary As #1
    ReDim lasersound(LOF(1)): Get #1, , lasersound
Close 1
Open App.Path & "\miscdata\Drone.wav" For Binary As #1
    ReDim DroneSound(LOF(1)): Get #1, , DroneSound
Close 1
Open App.Path & "\miscdata\shothit.wav" For Binary As #1
    ReDim hitsound(LOF(1)): Get #1, , hitsound
Close 1
Open App.Path & "\miscdata\Death.wav" For Binary As #1
    ReDim deathsound(LOF(1)): Get #1, , deathsound
Close 1
Open App.Path & "\miscdata\collision.wav" For Binary As #1
    ReDim collisionsound(LOF(1)): Get #1, , collisionsound
Close 1
Open App.Path & "\miscdata\Sosumi.wav" For Binary As #1
    ReDim beepsound(LOF(1)): Get #1, , beepsound
Close 1


'Robotladdningsblocket 'ROBOT LOADING AT STARTUP (If any)
If Command <> "" Then   'The user clicked a Robot in Windows
    Load2.Visible = True
    R1path = Command
    R1path = Replace(R1path, Chr(34), "")
    NameVar1 = StrReverse$(R1path)
    NameVar1 = Right$(R1path, InStr(NameVar1, "\") - 1)
    Robot1.Caption = Left$(NameVar1, Len(NameVar1) - 4)

    CommonDialog1.InitDir = Left$(R1path, Len(R1path) - Len(NameVar1))  'New, makes the directory the user opened a robot from the default

    R1Present = True
    SelectedRobot = 1
    Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    LoadRobot1
Else
    Get 7, 7000, YesOrNo
    'YesOrNo = False    'DEBUG - Enable first time startup
    If YesOrNo Then 'Not first time
        For check = 2 To 6      'Place not present robots outside arena so they wont get hit
            RobotLeft(check) = -check * 100
        Next check
        SelectedRobot = -1
    Else    'First time
        FirstTimeStartUp
    End If
End If

End Sub

Private Sub FirstTimeStartUp()
'Put 7, 7000, True  'Moved to WelcomeHelp_Close

'NotRandomEmergency = False     'tror inte denhär behövs?
WelcomeWindowSwitchMenu.Checked = True

CommonDialog1.InitDir = App.Path & "\Miscellaneous Bots\"
R1Present = True                                'Sets the global variable R1Present
R2Present = True                                'Sets the global variable R1Present
R3Present = True                                'Sets the global variable R1Present
R4Present = True                                'Sets the global variable R1Present
R5Present = True                                'Sets the global variable R1Present
R6Present = True                                'Sets the global variable R1Present
Load2.Visible = True
Load3.Visible = True
Load4.Visible = True
Load5.Visible = True
Load6.Visible = True
    SelectedRobot = 1
    Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite

Const StartupBot1 = "Zolad Alive"
Const StartupBot2 = "5 drop 5"
Const StartupBot3 = "CHANGER 2"
Const StartupBot4 = "Dialectix"
Const StartupBot5 = "Carne"
Const StartupBot6 = "JEST.ALT"

R1path = App.Path & "\Miscellaneous Bots\" & StartupBot1 & ".RWR"               'Sets the global variable R1Path
Robot1.Caption = StartupBot1
LoadRobot1                                     'A huge subroutine that loads hardware, icon and icon settings

R2path = App.Path & "\Miscellaneous Bots\" & StartupBot2 & ".RWR"               'Sets the global variable R2Path
Robot2.Caption = StartupBot2
LoadRobot2                                     'A huge subroutine that loads hardware, icon and icon settings

R3path = App.Path & "\Miscellaneous Bots\" & StartupBot3 & ".RWR"               'Sets the global variable R3Path
Robot3.Caption = StartupBot3
LoadRobot3                                     'A huge subroutine that loads hardware, icon and icon settings

R4path = App.Path & "\Miscellaneous Bots\" & StartupBot4 & ".RWR"               'Sets the global variable R4Path
Robot4.Caption = StartupBot4
LoadRobot4                                     'A huge subroutine that loads hardware, icon and icon settings

R5path = App.Path & "\Miscellaneous Bots\" & StartupBot5 & ".RWR"               'Sets the global variable R5Path
Robot5.Caption = StartupBot5
LoadRobot5                                     'A huge subroutine that loads hardware, icon and icon settings

R6path = App.Path & "\Miscellaneous Bots\" & StartupBot6 & ".RWR"               'Sets the global variable R6Path
Robot6.Caption = StartupBot6
LoadRobot6                                     'A huge subroutine that loads hardware, icon and icon settings


WelcomeHelp.Show

'MainWindow.SetFocus
'MsgBox "Welcome to RoboWar!" & vbCrLf & _
'"Thanks for downloading and trying out my game!" & vbCrLf & vbCrLf & _
'"Click the Battle Button to watch the Robots fight." & vbCrLf & _
'"Click the buttons next to the Robots name to load another Robot." & vbCrLf & _
'"Remove robots from the Arena can be done by clicking the Robots name and select 'Close Robot' from the File menu (Ctrl-W)." & vbCrLf & _
'"If you feel daring enough to create your own Robot, select new Robot from the file menu. "



End Sub
Private Sub About_Click()
AboutRoboWar.Show vbModal, MainWindow
End Sub

Private Sub Arena_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
Dim counter As Long

For counter = 1 To NumberOfRobotsPresent
    If (X - RobotLeft(counter)) ^ 2 + (Y - RobotTop(counter)) ^ 2 < 100 Then
        Arena.MousePointer = 99
        Draging = counter
    End If
Next counter

    If DebuggedRobot <> 0 And Draging <> 0 Then
        Arena.DrawMode = 13
        Arena.Line (RobotLeft(Draging) - 16, RobotTop(Draging) - 16)-(RobotLeft(Draging) + 16, RobotTop(Draging) + 16), BackgroundColor, BF
        Arena.DrawMode = 9
        
        DebuggingWindow.Show
    End If

End Sub

Private Sub Arena_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

If Arena.MousePointer = 99 Then
    TurretX2(Draging) = X + TurretX2(Draging) - RobotLeft(Draging)
    TurretY2(Draging) = Y + TurretY2(Draging) - RobotTop(Draging)
    RobotLeft(Draging) = X
    RobotTop(Draging) = Y
    Arena.MousePointer = vbDefault
    
    If DebuggedRobot <> 0 Then
        Dim Turret As Long
        Arena.PaintPicture Robot_(Draging), RobotLeft(Draging) - 16, RobotTop(Draging) - 16
        Select Case Draging
            Case 1
                Turret = Robot1Turret
            Case 2
                Turret = Robot2Turret
            Case 3
                Turret = Robot3Turret
            Case 4
                Turret = Robot4Turret
            Case 5
                Turret = Robot5Turret
            Case 6
                Turret = Robot6Turret
        End Select
        If Turret = 1 Then
            Arena.Line (RobotLeft(Draging), RobotTop(Draging))-(TurretX2(Draging), TurretY2(Draging)), vbBlack
        ElseIf Turret = 2 Then
            Arena.Circle (TurretX2(Draging), TurretY2(Draging)), 1, vbBlack
        End If

        DebuggingWindow.DebugMsg = Replace(DebuggingWindow.DebugMsg, vbLf & "x ", "old1")
        DebuggingWindow.DebugMsg = Replace(DebuggingWindow.DebugMsg, vbLf & "Speedx ", "old2" & vbLf & "Speedx ")

        Turret = InStr(DebuggingWindow.DebugMsg, "old1")

        DebuggingWindow.DebugMsg = Replace(DebuggingWindow.DebugMsg, _
        (Mid$(DebuggingWindow.DebugMsg, Turret, InStr(DebuggingWindow.DebugMsg, "old2") + 4 - Turret)), _
        vbLf & "x " & RobotLeft(Draging) & vbLf & "y " & RobotTop(Draging))
    
        DebuggingWindow.Cls
        DebuggingWindow.Print DebuggingWindow.DebugMsg

        Draging = 0
        Exit Sub
    End If
    
    Draging = 0
End If

If RunningTournament Then StopTournament.SetFocus Else BattleHaltButton.SetFocus

End Sub

'Private Sub AutoNoSound_Click()
'Dim YesOrNo As Boolean
'
'If AutoNoSound.Checked Then
'    If MsgBox("You've selected AutoNoSound to disabeld." & vbCr & _
'    "This is not recommended if you have a fast computer." & vbCr & vbCr & _
'    "Auto no sound automacticly disables sound if you set the battlespeed to fast." & vbCr & _
'    "Sound will bug out if battlespeed is over 50 chronons per second" & vbCr & _
'    "because then there will simply be too many sounds at one time." & vbCr & vbCr & _
'    "Since sounds are automaticly switched off if fast is choosen" & vbCr & _
'    "keeping the auto no sound option prevent this problem." & vbCr & vbCr & _
'    "Are you sure you want to disable Auto No Sound?" _
'    , vbYesNo + vbDefaultButton2 + vbExclamation, "Sound problems can occur if Auto No Sound is switched off") = vbNo Then Exit Sub
'
'    AutoNoSound.Checked = False
'    YesOrNo = False
'    Sounds.Enabled = True
'Else
'    AutoNoSound.Checked = True
'    YesOrNo = True
'    Sounds.Enabled = Not (HideBattle Or Fast.Checked Or AutoRedrawFast.Checked)
'End If
'
'Put 7, 13000, YesOrNo
'End Sub

Private Function S(MagicNumber As Long) As String
'Used by the debugger (and some other stuff too I think) to translate the
'magic numbers which represents the instructions to strings
Select Case MagicNumber
    Case -19999 To 19999
        S = MagicNumber
    Case 20100
        S = "STORE"
    Case 20330
        S = "AIM'"
    Case 20109
        S = "RECALL"
    Case 20140
        S = "IFG"
    Case 20104
        S = "JUMP"
    Case 20153
        S = "INTON"
    Case 20155
        S = "RTI"
    Case 20355
        S = "DOPPLER'"
    Case 20156
        S = "SETINT"
    Case 20157
        S = "SETPARAM"
    Case 20329
        S = "RANGE'"
    Case 20004
        S = ">"
    Case 20005
        S = "<"
    Case 20000
        S = "+"
    Case 20002
        S = "*"
    Case 20136
        S = "SYNC"
    Case 20328
        S = "SHIELD'"
    Case 20331
        S = "SPEEDX'"
    Case 20332
        S = "SPEEDY'"
    Case 20340
        S = "MOVEX'"
    Case 20341
        S = "MOVEY'"
    Case 20343
        S = "RADAR'"
    Case 20006
        S = "="
    Case 20107
        S = "IF"
    Case 20326
        S = "FIRE'"
    Case 20356
        S = "STUNNER'"
    Case 20335
        S = "MISSILE'"
    Case 20125
        S = "ICON0"
    Case 20126
        S = "ICON1"
    Case 20127
        S = "ICON2"
    Case 20128
        S = "ICON3"
    Case 20129
        S = "ICON4"
    Case 20130
        S = "ICON5"
    Case 20131
        S = "ICON6"
    Case 20132
        S = "ICON7"
    Case 20133
        S = "ICON8"
    Case 20134
        S = "ICON9"
    Case 20159
        S = "DROPALL"
    Case 20001
        S = "-"
    Case 20003
        S = "/"
    Case 20007
        S = "!"
    Case 20101
        S = "DROP"
    Case 20102
        S = "SWAP"
    Case 20103
        S = "ROLL"
    Case 20105
        S = "CALL"
    Case 20106
        S = "DUP"
    Case 20108
        S = "IFE"
    Case 20111
        S = "NOP"
    Case 20112
        S = "AND"
    Case 20113
        S = "OR"
    Case 20114
        S = "XOR"
    Case 20115
        S = "MOD"
    Case 20117
        S = "CHS"
    Case 20118
        S = "NOT"
    Case 20119
        S = "ARCTAN"
    Case 20120
        S = "ABS"
    Case 20121
        S = "SIN"
    Case 20122
        S = "COS"
    Case 20123
        S = "TAN"
    Case 20137
        S = "VSTORE"
    Case 20138
        S = "VRECALL"
    Case 20139
        S = "DIST"
    Case 20141
        S = "IFEG"
    Case 20142
        S = "DEBUG"
    Case 20143
        S = "SND0"
    Case 20144
        S = "SND1"
    Case 20145
        S = "SND2"
    Case 20146
        S = "SND3"
    Case 20147
        S = "SND4"
    Case 20148
        S = "SND5"
    Case 20149
        S = "SND6"
    Case 20150
        S = "SND7"
    Case 20151
        S = "SND8"
    Case 20152
        S = "SND9"
    Case 20154
        S = "INTOFF"
    Case 20160
        S = "FLUSHINT"
    Case 20161
        S = "MAX"
    Case 20162
        S = "MIN"
    Case 20163
        S = "ARCCOS"
    Case 20164
        S = "ARCSIN"
    Case 20300
        S = "A'"
    Case 20301
        S = "B'"
    Case 20302
        S = "C'"
    Case 20303
        S = "D'"
    Case 20304
        S = "E'"
    Case 20305
        S = "F'"
    Case 20306
        S = "G'"
    Case 20307
        S = "H'"
    Case 20308
        S = "I'"
    Case 20309
        S = "J'"
    Case 20310
        S = "K'"
    Case 20311
        S = "L'"
    Case 20312
        S = "M'"
    Case 20313
        S = "N'"
    Case 20314
        S = "O'"
    Case 20315
        S = "P'"
    Case 20316
        S = "Q'"
    Case 20317
        S = "R'"
    Case 20318
        S = "S'"
    Case 20319
        S = "T'"
    Case 20320
        S = "U'"
    Case 20321
        S = "V'"
    Case 20322
        S = "W'"
    Case 20323
        S = "X'"
    Case 20324
        S = "Y'"
    Case 20325
        S = "Z'"
    Case 20333
        S = "DAMAGE'"
    Case 20334
        S = "RANDOM'"
    Case 20336
        S = "NUKE'"
    Case 20337
        S = "COLLISION'"
    Case 20327
        S = "ENERGY'"
    Case 20344
        S = "LOOK'"
    Case 20345
        S = "SCAN'"
    Case 20346
        S = "CHRONON'"
    Case 20347
        S = "HELLBORE'"
    Case 20348
        S = "DRONE'"
    Case 20349
        S = "MINE'"
    Case 20350
        S = "LASER'"
    Case 20352
        S = "ROBOTS'"
    Case 20353
        S = "FRIEND'"
    Case 20354
        S = "BULLET'"
    Case 20357
        S = "TOP'"
    Case 20358
        S = "BOT'"
    Case 20359
        S = "LEFT'"
    Case 20360
        S = "RIGHT'"
    Case 20361
        S = "WALL'"
    Case 20363
        S = "PROBE'"
    Case 20364
        S = "HISTORY'"
    Case 20365
        S = "ID'"
    Case 20135
        S = "PRINT"
    Case 20124
        S = "SQRT"
    Case 20116
        S = "BEEP"
    Case 20366
        S = "KILLS'"
    Case 20110  'END
        S = "END"
    Case 20362
        S = "TEAMMATES'"
    Case 20338
        S = "CHANNEL'"
    Case 20339
        S = "SIGNAL'"
    Case insNEAREST
        S = "NEAREST'"
    Case insMEGANUKE
        S = "MEGANUKE'"
    Case Else
        S = "????"
End Select
End Function

Private Function Inst2MagicNumber(Instruction) As Long
' Used by the built in converter which translates robots from the old RWR file format to the new one
Select Case Instruction
    Case -19999 To 19999
        Inst2MagicNumber = Instruction
    Case "+"
        Inst2MagicNumber = 20000
    Case "-"
        Inst2MagicNumber = 20001
    Case "*"
        Inst2MagicNumber = 20002
    Case "/"
        Inst2MagicNumber = 20003
    Case ">"
        Inst2MagicNumber = 20004
    Case "<"
        Inst2MagicNumber = 20005
    Case "="
        Inst2MagicNumber = 20006
    Case "!"
        Inst2MagicNumber = 20007
    Case "STORE"
        Inst2MagicNumber = 20100
    Case "DROP"
        Inst2MagicNumber = 20101
    Case "SWAP"
        Inst2MagicNumber = 20102
    Case "ROLL"
        Inst2MagicNumber = 20103
    Case "JUMP"
        Inst2MagicNumber = 20104
    Case "CALL"
        Inst2MagicNumber = 20105
    Case "DUP"
        Inst2MagicNumber = 20106
    Case "IF"
        Inst2MagicNumber = 20107
    Case "IFE"
        Inst2MagicNumber = 20108
    Case "RECALL"
        Inst2MagicNumber = 20109
    Case "END"
        Inst2MagicNumber = 20110
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
    Case "IFG"
        Inst2MagicNumber = 20140
    Case "IFEG"
        Inst2MagicNumber = 20141
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
    Case "SETINT"
        Inst2MagicNumber = 20156
    Case "SETPARAM"
        Inst2MagicNumber = 20157
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
    Case "X'"
        Inst2MagicNumber = 20323
    Case "Y'"
        Inst2MagicNumber = 20324
    Case "Z'"
        Inst2MagicNumber = 20325
    Case "FIRE'"
        Inst2MagicNumber = 20326
    Case "ENERGY'"
        Inst2MagicNumber = 20327
    Case "SHIELD'"
        Inst2MagicNumber = 20328
    Case "RANGE'"
        Inst2MagicNumber = 20329
    Case "AIM'"
        Inst2MagicNumber = 20330
    Case "SPEEDX'"
        Inst2MagicNumber = 20331
    Case "SPEEDY'"
        Inst2MagicNumber = 20332
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
    Case "RADAR'"
        Inst2MagicNumber = 20343
    Case "LOOK'"
        Inst2MagicNumber = 20344
    Case "SCAN'"
        Inst2MagicNumber = 20345
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
    Case "KILLS'"
        Inst2MagicNumber = 20366
    Case Else
        Inst2MagicNumber = -20001
End Select
End Function

Private Sub BattleHaltButton_Click()

If R1Present Then
    If BattleHaltButton.Caption = "Halt" Then
        TerminateBattle
    Else
        If Ultra.Checked Then
            ULTRAMODE
        ElseIf NoDisplay.Checked Then
            DONTSHOWBATTLE
        Else
            Combat
        End If
    End If
Else
    MsgBox "To load a robot, choose 'Load Robot' from the file menu.", , "No Robot Loaded"
End If

End Sub

Private Sub Combat()
'This is the battleengine - Some things are external procedures, but most things are controlled here

'Debugging variables
Dim ChrononStepping As Long
Dim ErrorCode As Long
Dim RandomCounter As Long
Dim fStart As Single
        
'Robotarnas maskinkod - The robots' machinecode
Dim MachineCode(1 To 6, 4999) As Long    '0-4999 = RobotInstructions
Dim RobotInstPos(1 To 6) As Long
                                        
'Robotarnas Stack - The robots' Stacks
Dim RobotStack(1 To 6, 1 To 100) As Long    'long
Dim RobotStackPos(1 To 6) As Long           'How many numbers the robots has on it's stack

'Robotarnas Interupptsköer - The robots' interupps ques
Dim RobotIntQue(1 To 6, 1 To 100) As Long
Dim RobotQuePos(1 To 6) As Long
Dim IntID(1 To 6, 1 To 100) As Long

'Robots hardware
Dim RobotShield(1 To 6) As Long
Dim RobotEnergy(1 To 6) As Long
Dim RobotProSpeed(1 To 6) As Long
Dim RobotMissiles(1 To 6) As Long
Dim RobotTacNukes(1 To 6) As Long
Dim RobotBullets(1 To 6) As Long
Dim RobotStunners(1 To 6) As Long
Dim RobotHellbores(1 To 6) As Long
Dim RobotMines(1 To 6) As Long
Dim RobotLasers(1 To 6) As Long
Dim RobotDrones(1 To 6) As Long
Dim RobotProbes(1 To 6) As Long

'Which icon to display? What type of turret does the robot have, if any?
Dim RobotIconNumber(1 To 6) As Long
Dim RobotTurretType(1 To 6) As Long
Dim DroneSoundPlayed(1 To 6) As Long

'Robotarnas variabler - The robots' variables
Dim RA(1 To 6) As Long
Dim RB(1 To 6) As Long
Dim RC(1 To 6) As Long
Dim RD(1 To 6) As Long
Dim RE(1 To 6) As Long
Dim RF(1 To 6) As Long
Dim RG(1 To 6) As Long
Dim RH(1 To 6) As Long
Dim RI(1 To 6) As Long
Dim RJ(1 To 6) As Long
Dim RK(1 To 6) As Long
Dim RL(1 To 6) As Long
Dim RM(1 To 6) As Long
Dim RN(1 To 6) As Long
Dim RO(1 To 6) As Long
Dim RP(1 To 6) As Long
Dim RQ(1 To 6) As Long
Dim RR(1 To 6) As Long
Dim RS(1 To 6) As Long
Dim RT(1 To 6) As Long
Dim RU(1 To 6) As Long
Dim RV(1 To 6) As Long
Dim RZ(1 To 6) As Long
Dim RW(1 To 6) As Long
Dim RVRECALL(1 To 6, 100) As Long

'Probes and Interupps
Dim ProbeSet(1 To 6) As Long '0 = Damage 1 = Energy 2 = Shield 3 = ID '5 = Aim 6 = look 7 = scan 4 = Teammates - Currently disabled 'cause of no teams

Dim Inton(1 To 6) As Boolean
Dim RangeInst(1 To 6) As Long
Dim RangeParam(1 To 6) As Long
Dim RadarInst(1 To 6) As Long
Dim RadarParam(1 To 6) As Long
Dim ChrononInst(1 To 6) As Long  'Måste alltid dras ifrån en då denna sätts för att mataren matar fram + 1
Dim ChrononParam(1 To 6) As Long
Dim RobotsInst(1 To 6) As Long
Dim RobotsParam(1 To 6) As Long
Dim RightParam(1 To 6) As Long
Dim LeftParam(1 To 6) As Long
Dim TopParam(1 To 6) As Long
Dim BotParam(1 To 6) As Long
Dim RightInst(1 To 6) As Long
Dim LeftInst(1 To 6) As Long
Dim TopInst(1 To 6) As Long
Dim BotInst(1 To 6) As Long
Dim CollisionInst(1 To 6) As Long
Dim WallInst(1 To 6) As Long
Dim DamageInst(1 To 6) As Long
Dim DamageParam(1 To 6) As Long
Dim ShieldInst(1 To 6) As Long
Dim ShieldParam(1 To 6) As Long
Dim HistoryParam(1 To 6) As Long

'Things that can be recalled
Dim RCollision(1 To 6)  As Long
Dim RWall(1 To 6)  As Long
Dim REnergy(1 To 6) As Long
Dim RDamage(1 To 6) As Long
Dim RShield(1 To 6) As Long
Dim RSpeedx(1 To 6) As Long
Dim RSpeedy(1 To 6) As Long
Dim RAim(1 To 6) As Long
Dim RLook(1 To 6) As Long
Dim RScan(1 To 6) As Long
Dim RRadar As Long   'Kanske kan byggas ihop? Bytas ut?
Dim RRange As Long

' Team Variables
Dim RSignal(1 To 3, 1 To 10) As Long
Dim RChannel(1 To 6) As Long
Dim TeammatesInst(1 To 6) As Long
Dim TeammatesParam(1 To 6) As Long
Dim SignalInst(1 To 6) As Long
Dim SignalParam(1 To 6) As Long

'Robot Specific Game Vars
Dim RobotAlive(1 To 6) As Long 'Boolean
Dim RStunned(1 To 6) As Long     'The number of chronons the robot is stunned
                                    'Hasmoved skall ha 2 funktioner. Dels MoveAndShot, dels så att LEFT' RIGHT' TOP' BOT'
                                    'skall kunna triggas med movex
Dim LastHiter(1 To 6) As Long   'To determinate the killer of the robot
Dim HasMoved As Long            'For the Move and Shoot restriction
Dim DroneShotDown As Boolean

'Vars neccesary for running the game
Dim RNN As Long              'Stands for Robot ruNniNg or something like that (I don't remember exactly what to be honest). Correspond aproximately to the variable "who" in Mac RoboWar
Dim ChrononExecutor1 As Long 'Correspons to "cycleNum"
Dim HowManyLeft As Long      'Used to determine when to cancel battle. Set to 2 if only one robot is present, to avoid that battle breaks at Chronon 20
Dim tempnumber As Long    'temporary placeholder for longs
Dim TDouble As Double      'To avoid trig calculations to get truncated

'Shot vars
Dim FreeShot As Long
FreeShot = -1
Dim shotcounter As Long
Dim NotAnyShotsAtAll As Boolean
Dim shot(32768) As ShotPrivateType
Dim ShotNumber As Long  'Number of shots (including "dead" shots) that are in the arena
Dim trigx As Single
Dim trigy As Single

InizBattle
        'Battle Starts. The robots get randomly placed in the Arena

'Robot 1. Allways Present
        REnergy(1) = Robot1Energy
        RDamage(1) = Robot1Damage
        RobotTurretType(1) = Robot1Turret
        
'Laddar machinkoden till Robotarna
'Dim thetime As Single
'thetime = Timer

        For RNN = 0 To 4999
            MachineCode(1, RNN) = MasterCode(1, RNN)
            'If (MachineCode(1, RNN) >= insICON0 And MachineCode(1, RNN) <= insICON9) Or (MachineCode(1, RNN) >= insDEBUG And MachineCode(1, RNN) <= insSND9) Then MachineCode(1, RNN) = insBEEP
            If MachineCode(1, RNN) = insEND Then Exit For
        Next RNN

        If R2Present Then
            RobotTurretType(2) = Robot2Turret

            For RNN = 0 To 4999
                MachineCode(2, RNN) = MasterCode(2, RNN)
                'If (MachineCode(2, RNN) >= insICON0 And MachineCode(2, RNN) <= insICON9) Or (MachineCode(2, RNN) >= insDEBUG And MachineCode(2, RNN) <= insSND9) Then MachineCode(2, RNN) = insBEEP
                If MachineCode(2, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace2        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(2) = Robot2Energy
            RDamage(2) = Robot2Damage
        End If

        If R3Present Then
            RobotTurretType(3) = Robot3Turret
            
            For RNN = 0 To 4999
                MachineCode(3, RNN) = MasterCode(3, RNN)
                'If (MachineCode(3, RNN) >= insICON0 And MachineCode(3, RNN) <= insICON9) Or (MachineCode(3, RNN) >= insDEBUG And MachineCode(3, RNN) <= insSND9) Then MachineCode(3, RNN) = insBEEP
                If MachineCode(3, RNN) = insEND Then Exit For
            Next RNN
            
            MasterPlace3
            REnergy(3) = Robot3Energy
            RDamage(3) = Robot3Damage
        End If

        If R4Present Then
            RobotTurretType(4) = Robot4Turret

            For RNN = 0 To 4999
                MachineCode(4, RNN) = MasterCode(4, RNN)
                'If (MachineCode(4, RNN) >= insICON0 And MachineCode(4, RNN) <= insICON9) Or (MachineCode(4, RNN) >= insDEBUG And MachineCode(4, RNN) <= insSND9) Then MachineCode(4, RNN) = insBEEP
                If MachineCode(4, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace4        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(4) = Robot4Energy
            RDamage(4) = Robot4Damage
        End If

        If R5Present Then
            RobotTurretType(5) = Robot5Turret

            For RNN = 0 To 4999
                MachineCode(5, RNN) = MasterCode(5, RNN)
                'If (MachineCode(5,RNN) >= insICON0 And MachineCode(5,RNN) <= insICON9) Or (MachineCode(5,RNN) >= insDEBUG And MachineCode(5,RNN) <= insSND9) Then MachineCode(5,RNN) = insBEEP
                If MachineCode(5, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace5        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(5) = Robot5Energy
            RDamage(5) = Robot5Damage
        End If

        If R6Present Then
            RobotTurretType(6) = Robot6Turret

            For RNN = 0 To 4999
                MachineCode(6, RNN) = MasterCode(6, RNN)
                'If (MachineCode(6, RNN) >= insICON0 And MachineCode(6, RNN) <= insICON9) Or (MachineCode(6, RNN) >= insDEBUG And MachineCode(6, RNN) <= insSND9) Then MachineCode(6, RNN) = insBEEP
                If MachineCode(6, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace6        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(6) = Robot6Energy
            RDamage(6) = Robot6Damage
        End If

'        thetime = Timer - thetime
'        Debug.Print thetime

HowManyLeft = CheckHowManyLeft

'Syncs Hardware to array
RobotShield(1) = Robot1Shield
RobotEnergy(1) = Robot1Energy
RobotProSpeed(1) = Robot1ProSpeed
RobotMissiles(1) = Robot1Missiles
RobotTacNukes(1) = Robot1TacNukes
RobotBullets(1) = Robot1Bullets
RobotStunners(1) = Robot1Stunners
RobotHellbores(1) = Robot1Hellbores
RobotMines(1) = Robot1Mines
RobotLasers(1) = Robot1Lasers
RobotDrones(1) = Robot1Drones
RobotProbes(1) = Robot1Probes
RobotShield(2) = Robot2Shield
RobotEnergy(2) = Robot2Energy
RobotProSpeed(2) = Robot2ProSpeed
RobotMissiles(2) = Robot2Missiles
RobotTacNukes(2) = Robot2TacNukes
RobotBullets(2) = Robot2Bullets
RobotStunners(2) = Robot2Stunners
RobotHellbores(2) = Robot2Hellbores
RobotMines(2) = Robot2Mines
RobotLasers(2) = Robot2Lasers
RobotDrones(2) = Robot2Drones
RobotProbes(2) = Robot2Probes
RobotShield(3) = Robot3Shield
RobotEnergy(3) = Robot3Energy
RobotProSpeed(3) = Robot3ProSpeed
RobotMissiles(3) = Robot3Missiles
RobotTacNukes(3) = Robot3TacNukes
RobotBullets(3) = Robot3Bullets
RobotStunners(3) = Robot3Stunners
RobotHellbores(3) = Robot3Hellbores
RobotMines(3) = Robot3Mines
RobotLasers(3) = Robot3Lasers
RobotDrones(3) = Robot3Drones
RobotProbes(3) = Robot3Probes
RobotShield(4) = Robot4Shield
RobotEnergy(4) = Robot4Energy
RobotProSpeed(4) = Robot4ProSpeed
RobotMissiles(4) = Robot4Missiles
RobotTacNukes(4) = Robot4TacNukes
RobotBullets(4) = Robot4Bullets
RobotStunners(4) = Robot4Stunners
RobotHellbores(4) = Robot4Hellbores
RobotMines(4) = Robot4Mines
RobotLasers(4) = Robot4Lasers
RobotDrones(4) = Robot4Drones
RobotProbes(4) = Robot4Probes
RobotShield(5) = Robot5Shield
RobotEnergy(5) = Robot5Energy
RobotProSpeed(5) = Robot5ProSpeed
RobotMissiles(5) = Robot5Missiles
RobotTacNukes(5) = Robot5TacNukes
RobotBullets(5) = Robot5Bullets
RobotStunners(5) = Robot5Stunners
RobotHellbores(5) = Robot5Hellbores
RobotMines(5) = Robot5Mines
RobotLasers(5) = Robot5Lasers
RobotDrones(5) = Robot5Drones
RobotProbes(5) = Robot5Probes
RobotShield(6) = Robot6Shield
RobotEnergy(6) = Robot6Energy
RobotProSpeed(6) = Robot6ProSpeed
RobotMissiles(6) = Robot6Missiles
RobotTacNukes(6) = Robot6TacNukes
RobotBullets(6) = Robot6Bullets
RobotStunners(6) = Robot6Stunners
RobotHellbores(6) = Robot6Hellbores
RobotMines(6) = Robot6Mines
RobotLasers(6) = Robot6Lasers
RobotDrones(6) = Robot6Drones
RobotProbes(6) = Robot6Probes
'End Syncs Hardware to array

For tempnumber = 1 To NumberOfRobotsPresent
    RobotInstPos(tempnumber) = -1 'Sets robot RobotInstPos to -1 'cause t have to start with 0 (= -1 + 1 )
    RAim(tempnumber) = 90
    RobotAlive(tempnumber) = 1
    LastHiter(tempnumber) = tempnumber

    RChannel(tempnumber) = 1
    TeammatesInst(tempnumber) = -1
    TeammatesParam(tempnumber) = 5
    SignalInst(tempnumber) = -1

    RadarInst(tempnumber) = -1
    RangeInst(tempnumber) = -1
    ChrononInst(tempnumber) = -1
    CollisionInst(tempnumber) = -1
    WallInst(tempnumber) = -1
    TopInst(tempnumber) = -1
    BotInst(tempnumber) = -1
    LeftInst(tempnumber) = -1
    RightInst(tempnumber) = -1
    RobotsInst(tempnumber) = -1
    DamageInst(tempnumber) = -1
    ShieldInst(tempnumber) = -1
    RobotsParam(tempnumber) = 6
    RadarParam(tempnumber) = 600
    RangeParam(tempnumber) = 600
    TopParam(tempnumber) = 20
    BotParam(tempnumber) = 280
    LeftParam(tempnumber) = 20
    RightParam(tempnumber) = 280
    DamageParam(tempnumber) = RDamage(tempnumber)
    ShieldParam(tempnumber) = 25
    
    HistoryParam(tempnumber) = 1
    
    If RobotDrones(tempnumber) = 1 Then DroneShotDown = True
Next tempnumber

' Avläsningen av koden (BÖRJAN)
'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*

'On Error GoTo CodeError1

Do While Chronon <> MaxChronon  '<>

fStart = Timer

'ROBOT LOADING LOOP - The New Collision Stunning Shield Energy Wall Loop
For RNN = 1 To NumberOfRobotsPresent
    If RobotAlive(RNN) = 1 Then
        If RStunned(RNN) = 0 Then
            If RShield(RNN) = 0 Then
               If RobotIconNumber(RNN) = 1 Then
                   RobotIconNumber(RNN) = 0
                   Set Robot_(RNN) = RobotMasterIcon(RNN * 10)
               End If
            Else
               If RobotShield(RNN) < RShield(RNN) Then
                   RShield(RNN) = RShield(RNN) - 2
                   If RShield(RNN) < 0 Then RShield(RNN) = 0       'Behövs
               Else
                   If Chronon Mod 2 = 0 Then RShield(RNN) = RShield(RNN) - 1
               End If
               
               If RobotIconNumber(RNN) = 0 Then
                   If RobotShieldIcon(RNN) <> 0 Then
                       Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 1)
                       RobotIconNumber(RNN) = 1
                   End If
               End If
            End If

            If REnergy(RNN) <> RobotEnergy(RNN) Then
                If REnergy(RNN) >= -200 Then
                    REnergy(RNN) = REnergy(RNN) + 2
                    If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN)
                Else
                    If EnableOverloading Then RobotAlive(RNN) = 255 Else REnergy(RNN) = REnergy(RNN) + 2
                End If
                
                EnergyDisplay(RNN).Cls
                EnergyDisplay(RNN).Print REnergy(RNN)
            End If
    
            If REnergy(RNN) >= 1 Then
                If RSpeedx(RNN) <> 0 Or RSpeedy(RNN) <> 0 Then 'Boosts battlespeed and reduces flickering for robots that stads still.
                    RobotLeft(RNN) = RobotLeft(RNN) + RSpeedx(RNN)
                    RobotTop(RNN) = RobotTop(RNN) + RSpeedy(RNN)
                    TurretX2(RNN) = TurretX2(RNN) + RSpeedx(RNN)
                    TurretY2(RNN) = TurretY2(RNN) + RSpeedy(RNN)
                End If
            End If
        End If 'RStunned
        
        'PREPARING THE COLLISION WITH EACH OTHER LOOP
        If RobotIconNumber(RNN) >= 100 Then     'Switches off the collision/block/hit icons if it's on
            RobotIconNumber(RNN) = RobotIconNumber(RNN) - 100   'Switches back from collisionicon
            If RobotIconNumber(RNN) <> 10 Then Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + RobotIconNumber(RNN)) Else Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 1)
        End If

        For tempnumber = 1 To NumberOfRobotsPresent '''Kollision med varandra, Skall Nu vara nästintill perfekt (Haha! Kul! ;))
            If RNN <> tempnumber Then
                If RobotAlive(tempnumber) = 1 Then
                    If (RobotLeft(RNN) - RobotLeft(tempnumber)) * (RobotLeft(RNN) - RobotLeft(tempnumber)) + (RobotTop(RNN) - RobotTop(tempnumber)) * (RobotTop(RNN) - RobotTop(tempnumber)) <= 400 Then
                        If RCollision(RNN) = 0 Then
                            RCollision(RNN) = tempnumber   '' Var 1 förut nu registrerar den vilken robot den kolliderar med
                            If RShield(RNN) > 0 Then RShield(RNN) = RShield(RNN) - 1 Else RDamage(RNN) = RDamage(RNN) - 1     'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
                            DR(RNN) = RDamage(RNN) 'DR(RNN).Refresh
                            
                            If PlaySounds Then
                                If RobotCollisionSound(tempnumber) Then
                                    PlaySnd1 (tempnumber)
                                ElseIf RobotCollisionSound(RNN) Then
                                    PlaySnd1 (RNN)
                                Else
                                    sndPlaySound collisionsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
                                End If
                            End If
                            
                            If RStunned(RNN) = 0 And REnergy(RNN) >= 1 Then
                                RobotLeft(RNN) = RobotLeft(RNN) - RSpeedx(RNN)
                                RobotTop(RNN) = RobotTop(RNN) - RSpeedy(RNN)
                                TurretX2(RNN) = TurretX2(RNN) - RSpeedx(RNN)
                                TurretY2(RNN) = TurretY2(RNN) - RSpeedy(RNN)
                            End If
                        End If
        
                        If RCollision(tempnumber) = 0 Then
                            RCollision(tempnumber) = RNN
                            If RShield(tempnumber) > 0 Then RShield(tempnumber) = RShield(tempnumber) - 1 Else RDamage(tempnumber) = RDamage(tempnumber) - 1     'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
                            DR(tempnumber) = RDamage(tempnumber) 'DR(TempNumber).Refresh
        
                            'If RStunned(TempNumber) = 0 And REnergy(TempNumber) >= 1 Then
                            If RStunned(tempnumber) = 0 And REnergy(tempnumber) - 2 * (tempnumber > RNN) >= 1 Then
                                RobotLeft(tempnumber) = RobotLeft(tempnumber) - RSpeedx(tempnumber)
                                RobotTop(tempnumber) = RobotTop(tempnumber) - RSpeedy(tempnumber)
                                TurretX2(tempnumber) = TurretX2(tempnumber) - RSpeedx(tempnumber)
                                TurretY2(tempnumber) = TurretY2(tempnumber) - RSpeedy(tempnumber)
                            End If
                        End If
                    End If
                End If
            End If
        Next tempnumber

        'KOLLISION MED VÄGGARNA - WALL COLLISION
        If WCX(RobotLeft(RNN)) Or WCY(RobotTop(RNN)) Then
            RWall(RNN) = 1
            RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - 5 + RShield(RNN)))
            RShield(RNN) = ZeroOrMore(RShield(RNN) - 5)
            DR(RNN) = RDamage(RNN)
            If PlaySounds Then
                If RobotCollisionSound(RNN) Then
                    PlaySnd1 (RNN)
                Else
                    sndPlaySound collisionsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
                End If
            End If

            If RobotLeft(RNN) > 300 Then  'otherwise it can use SPEEDX to run outside the areana
                TurretX2(RNN) = 300 + TurretX2(RNN) - RobotLeft(RNN)
                RobotLeft(RNN) = 300
            ElseIf RobotLeft(RNN) < 0 Then
                TurretX2(RNN) = TurretX2(RNN) - RobotLeft(RNN)
                RobotLeft(RNN) = 0
            End If
            If RobotTop(RNN) > 300 Then
                TurretY2(RNN) = 300 + TurretY2(RNN) - RobotTop(RNN)
                RobotTop(RNN) = 300
            ElseIf RobotTop(RNN) < 0 Then
                TurretY2(RNN) = TurretY2(RNN) - RobotTop(RNN)
                RobotTop(RNN) = 0
            End If
        Else
            RWall(RNN) = 0
        End If
    End If  'Alive if
Next RNN

For RNN = 1 To NumberOfRobotsPresent
If HighestToLowest Then RNN = NumberOfRobotsPresent - RNN + 1   'Turns on backwards evaluation if it's enabled
                                                                'Kan räknas ut i förväg??
If RobotAlive(RNN) = 1 Then
'ROBOT 1 CHRONON EXECUTOR
    If RStunned(RNN) = 0 And REnergy(RNN) >= 1 Then

    '''*********INTERUPPSKODEN*********
    'Each interrupt has a particular priority.  From highest priority to lowest, the interrupts are:
    'COLLISION, WALL, DAMAGE, SHIELD, TOP, BOTTOM, LEFT, RIGHT, RADAR, RANGE, TEAMMATES, ROBOTS,
    'SIGNAL, CHRONON.  If two interrupts occur at exactly the same time, the one with higher priority
    'is processed first.
    
    'riktig                 'Min
    'COLLISION  q           'COLLISION  q
    'WALL       q           'WALL       q
    'DAMAGE     q           'DAMAGE     q
    'SHIELD     q           'SHIELD     q
    'TOP        q           'TOP        ql
    'BOTTOM     q           'BOTTOM     ql
    'LEFT       q           'LEFT       ql
    'RIGHT      q           'RIGHT      ql
    'RADAR      n           'TEAMMATES  qss
    'RANGE      n           'ROBOTS !!  qss     'Fel ordning i kön  'Vi skulle kunna sänka till botten genom att sätta RobotInstPos på dödskoden istället
    'TEAMMATES  q           'SIGNAL     qsss
    'ROBOTS     q           'RADAR      n
    'SIGNAL     q           'RANGE      n
    'CHRONON    n           'CHRONON    n
 
        If TopInst(RNN) >= 0 Then
            If RSpeedy(RNN) < 0 Then
                If RobotTop(RNN) <= TopParam(RNN) Then
                    If RobotTop(RNN) - RSpeedy(RNN) > TopParam(RNN) Then
                        RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                        RobotIntQue(RNN, RobotQuePos(RNN)) = TopInst(RNN)
                        IntID(RNN, RobotQuePos(RNN)) = 1
                    End If
                End If
            End If
        End If
        If BotInst(RNN) >= 0 Then
            If RSpeedy(RNN) > 0 Then
                If RobotTop(RNN) >= BotParam(RNN) Then
                    If RobotTop(RNN) - RSpeedy(RNN) < BotParam(RNN) Then
                        RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                        RobotIntQue(RNN, RobotQuePos(RNN)) = BotInst(RNN)
                        IntID(RNN, RobotQuePos(RNN)) = 2
                    End If
                End If
            End If
        End If
        If LeftInst(RNN) >= 0 Then
            If RSpeedx(RNN) < 0 Then
                If RobotLeft(RNN) <= LeftParam(RNN) Then
                    If RobotLeft(RNN) - RSpeedx(RNN) > LeftParam(RNN) Then
                        RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                        RobotIntQue(RNN, RobotQuePos(RNN)) = LeftInst(RNN)
                        IntID(RNN, RobotQuePos(RNN)) = 3
                    End If
                End If
            End If
        End If
        If RightInst(RNN) >= 0 Then
            If RSpeedx(RNN) > 0 Then
                If RobotLeft(RNN) >= RightParam(RNN) Then
                    If RobotLeft(RNN) - RSpeedx(RNN) < RightParam(RNN) Then
                        RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                        RobotIntQue(RNN, RobotQuePos(RNN)) = RightInst(RNN)
                        IntID(RNN, RobotQuePos(RNN)) = 4
                    End If
                End If
            End If
        End If
        
        If ShieldInst(RNN) >= 0 Then            'If it's using the shield int
            If RShield(RNN) < ShieldParam(RNN) Then            'If we're in low shield
                If ShieldInst(RNN) < 5000 Then    'And we weren't in low shield last chronon (then shieldinst should be > 4999)
                    RobotQuePos(RNN) = RobotQuePos(RNN) + 1                 'que the
                    RobotIntQue(RNN, RobotQuePos(RNN)) = ShieldInst(RNN) 'interupt
                    IntID(RNN, RobotQuePos(RNN)) = 5
                    ShieldInst(RNN) = ShieldInst(RNN) + 5000
                End If
            Else    'If we're not in low shield anymore
                If ShieldInst(RNN) > 4999 Then   'and our shieldinst is set to a weird value then
                    ShieldInst(RNN) = ShieldInst(RNN) - 5000  'Sets back shieldinst to it's real value
                End If
            End If
        End If
        If DamageInst(RNN) >= 0 Then
            If RDamage(RNN) < DamageParam(RNN) Then
                RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                RobotIntQue(RNN, RobotQuePos(RNN)) = DamageInst(RNN)
                IntID(RNN, RobotQuePos(RNN)) = 6
                DamageParam(RNN) = RDamage(RNN)
            End If
        End If
        If WallInst(RNN) >= 0 Then            'If it's using the wall int
            If RWall(RNN) <> 0 Then            'If we're in wall
                If WallInst(RNN) < 5000 Then    'And we weren't in wall last chronon (then wallinst should be > 4999)
                    RobotQuePos(RNN) = RobotQuePos(RNN) + 1                 'que the
                    RobotIntQue(RNN, RobotQuePos(RNN)) = WallInst(RNN) 'interupt
                    IntID(RNN, RobotQuePos(RNN)) = 7
                    WallInst(RNN) = WallInst(RNN) + 5000
                End If
            Else    'If we're not in wall anymore
                If WallInst(RNN) > 4999 Then   'and our wall inst is set to a weird value then
                    WallInst(RNN) = WallInst(RNN) - 5000  'Sets back wallinst to it's real value
                End If
            End If                 'COLLISION AND WALL SHOULD BE MUCH MORE CAREFULLY TESTED!!
        End If
        If CollisionInst(RNN) >= 0 Then            'If it's using the collision int
            If RCollision(RNN) <> 0 Then            'If we're in collision
                If CollisionInst(RNN) < 5000 Then    'And we weren't in collision last chronon (then collisioninst should be > 4999)
                    RobotQuePos(RNN) = RobotQuePos(RNN) + 1                 'que the
                    RobotIntQue(RNN, RobotQuePos(RNN)) = CollisionInst(RNN) 'interupt
                    IntID(RNN, RobotQuePos(RNN)) = 8
                    CollisionInst(RNN) = CollisionInst(RNN) + 5000
                End If
            Else    'If we're not in collision anymore
                If CollisionInst(RNN) > 4999 Then   'and our collision inst is set to a weird value then
                    CollisionInst(RNN) = CollisionInst(RNN) - 5000  'Sets back collisioninst to it's real value
                End If
            End If
        End If

        If RobotQuePos(RNN) > 1 Then        'This is hopefully only a temporary solution for doubletrigging problems
            If RobotIntQue(RNN, RobotQuePos(RNN)) = RobotIntQue(RNN, RobotQuePos(RNN) - 1) And IntID(RNN, RobotQuePos(RNN)) = IntID(RNN, RobotQuePos(RNN) - 1) Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
        End If

        If Inton(RNN) Then
            If RobotQuePos(RNN) > 0 Then
                If RobotStackPos(RNN) > 99 Then
                    ErrorCode = BuggyOverflow: GoTo Buggy
                End If
                RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
                RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1    'qued ints subtracted when triggered             'jumps shall be done
                Inton(RNN) = False
                RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                GoTo SkipTheRestOfTheInts
            ElseIf RadarInst(RNN) >= 0 Then
                'RADAR
                RRadar = 0
                For shotcounter = 1 To ShotNumber
                    If shot(shotcounter).ShotType < 200 Then
                        'This is David Harris radar code, ported to Visual Basic by me.
                        trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                        trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                        
                        If trigx <> 0 Then   'atan2
                            tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                        Else
                            tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                        End If          '''''''
                        
                        If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                        
                        If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                            RRange = FixSquare(trigx * trigx + trigy * trigy)
                            If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                        End If
                    End If
                Next shotcounter
                '/RADAR
                If RRadar <> 0 Then
                    If RRadar <= RadarParam(RNN) Then   'intrange sends back 601 for no range instead of 0
                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
                        RobotInstPos(RNN) = RadarInst(RNN) - 1 ' -1 är nytt
                        Inton(RNN) = False
                        GoTo SkipTheRestOfTheInts
                    End If
                End If
            End If
            If RangeInst(RNN) >= 0 Then
            'intrange is faster than ordinary range, but it returns 601 when nobody is ranged
                RRange = 601
                RRadar = RAim(RNN) + RLook(RNN)
            
                For shotcounter = 1 To NumberOfRobotsPresent
                    If shotcounter <> RNN Then   'Skip checking range to self. It'll be too short
                        tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
                        trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
                        trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
            
                        If trigx * trigx + trigy * trigy > 91 Then tempnumber = 601 'This should be faster
            
                        If tempnumber < RRange Then
                            RRange = tempnumber
                            RangedRobot(RNN) = shotcounter
                        End If
                    End If
                Next shotcounter
                
                If RobotTeam(RNN) <> 0 Then
                    If RRange <> 601 Then
                        If RobotTeam(RNN) = RobotTeam(RangedRobot(RNN)) Then RRange = 601
                    End If
                End If
            '''''''''''
                If RRange <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                    If RobotAlive(RangedRobot(RNN)) = 1 Then
                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
                        RobotInstPos(RNN) = RangeInst(RNN) - 1 ' -1 är nytt
                        Inton(RNN) = False
                        GoTo SkipTheRestOfTheInts
                    End If
                End If
            End If
            If ChrononInst(RNN) >= 0 Then
                If ChrononParam(RNN) <= Chronon Then
                    If RobotStackPos(RNN) > 99 Then
                        ErrorCode = BuggyOverflow: GoTo Buggy
                    End If
                    RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                    RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
                    RobotInstPos(RNN) = ChrononInst(RNN) - 1
                    Inton(RNN) = False
                End If
            End If
        End If

SkipTheRestOfTheInts:
        
        '''Slut INTERUPPSKODEN
        
    'Typ här skall hasmoved bli falskt
    HasMoved = 0

        For ChrononExecutor1 = 1 To RobotProSpeed(RNN)
            RobotInstPos(RNN) = RobotInstPos(RNN) + 1
                If DebuggedRobot = RNN Or (StartDebuggerAt = Chronon And ChrononExecutor1 = 1 And RNN = WillBeDebugged) Then     '*******THE DEBUGGER - For robots that's not out of energy
                    If ChrononStepping <= Chronon Then
                        ChrononStart 'This sub is required when the debugger is set to start at a certain chronon

                        Arena.Cls
                        For shotcounter = 1 To ShotNumber           'Repaint all shots
                            DebuggerPaintShot shot(shotcounter)
                        Next shotcounter
                        For shotcounter = 1 To NumberOfRobotsPresent    'Repaint the robots
                            DebuggerPaint RobotAlive(shotcounter), RobotTurretType(shotcounter), shotcounter
                        Next shotcounter

                        RRange = Range(RNN, RAim(RNN) + RLook(RNN))     'Calculate range
                        If RRange <> 0 Then
                            If RobotAlive(RangedRobot(RNN)) <> 1 Then RRange = 0
                        End If
                        If RRange = 0 Then RangedRobot(RNN) = 0     'Kan inte flyttas eller trixas med se raden ovan

                        RRadar = 0
                        For shotcounter = 1 To ShotNumber           'Calculate radar
                            If shot(shotcounter).ShotType < 200 Then
                                tempnumber = Radar(RNN, (shot(shotcounter).ShotX), (shot(shotcounter).ShotY), (RAim(RNN) + RScan(RNN)))
                                If (tempnumber < RRadar Or RRadar = 0) And tempnumber <> 0 Then RRadar = tempnumber
                            End If
                        Next shotcounter

                        If RobotStackPos(RNN) <= 96 Then tempnumber = ((RobotStackPos(RNN) - 1) \ 6) * 6 Else tempnumber = 0

                        PrintDebuggingInfo _
                            RobotInstPos(RNN), MachineCode(RNN, RobotInstPos(RNN)), RobotStackPos(RNN), _
                            RobotStack(RNN, 1 + tempnumber), RobotStack(RNN, 2 + tempnumber), RobotStack(RNN, 3 + tempnumber), _
                            RobotStack(RNN, 4 + tempnumber), RobotStack(RNN, 5 + tempnumber), RobotStack(RNN, 6 + tempnumber), _
                            RobotStack(RNN, 100), RobotStack(RNN, 99), RobotStack(RNN, 98), RobotStack(RNN, 97), _
                            ChrononExecutor1, RAim(RNN), RShield(RNN), RRange, RangedRobot(RNN), RRadar, RLook(RNN), _
                            RScan(RNN), RSpeedx(RNN), RSpeedy(RNN), REnergy(RNN)

                        PrintInts Inton(RNN), _
                                  LeftParam(RNN), RightParam(RNN), TopParam(RNN), BotParam(RNN), _
                                  LeftInst(RNN), RightInst(RNN), TopInst(RNN), BotInst(RNN), _
                                  RadarParam(RNN), RadarInst(RNN), RangeInst(RNN), RangeParam(RNN), _
                                  RobotQuePos(RNN), RobotIntQue(RNN, 1), RobotIntQue(RNN, 2)
                        ReturnMacAdd     'ReturnMacAdd contains the stop/resume execution instructions

                        If DebuggingWindow.DebuggingRes = 1 Then    'Determine what button in the debugger
                            ChrononStepping = Chronon + 1           'the user pressed
                            SetTabIndex1
                        ElseIf DebuggingWindow.DebuggingRes = 2 Then
                            TurnOfTheDebugger
                        ElseIf DebuggingWindow.DebuggingRes = 3 Then
                            GoTo Peace
                        Else
                            SetTabIndex2
                        End If
                    End If
                End If

                Select Case MachineCode(RNN, RobotInstPos(RNN))  'Interpret the current instruction
                    Case -19999 To 19999
                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
                    Case insA To TOPREGISTER
                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
                    Case insSTORE
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If

                        Select Case RobotStack(RNN, RobotStackPos(RNN))
                            Case insAIM 'ins
                                RAim(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Mod 360
'                                If RAim(RNN) > 359 Then RAim(RNN) = RAim(RNN) Mod 360
'                                If RAim(RNN) < 0 Then RAim(RNN) = RAim(RNN) Mod 360 + 360
                                If RAim(RNN) < 0 Or RAim(RNN) > 359 Then RAim(RNN) = RAim(RNN) Mod 360 - 360 * (RAim(RNN) < 0)

                                TurretX2(RNN) = RobotLeft(RNN) + Sin10(RAim(RNN))
                                TurretY2(RNN) = RobotTop(RNN) - Cos10(RAim(RNN))
                                If Inton(RNN) Then  '**********Interuppskod************'
                                    If RadarInst(RNN) >= 0 Then
                                        'RADAR
                                        RRadar = 0
                                        For shotcounter = 1 To ShotNumber
                                            If shot(shotcounter).ShotType < 200 Then
                                                'This is David Harris radar code, ported to Visual Basic by me.
                                                trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                                                trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                                                
                                                If trigx <> 0 Then   'atan2
                                                    tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                                                Else
                                                    tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                                                End If          '''''''
                                                
                                                If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                                                
                                                If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                                                    RRange = FixSquare(trigx * trigx + trigy * trigy)
                                                    If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                                                End If
                                            End If
                                        Next shotcounter
                                        '/RADAR
                                        If RRadar <> 0 Then
                                            If RRadar <= RadarParam(RNN) Then   'intrange sends back 601 for no range instead of 0
                                                RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                RobotInstPos(RNN) = RadarInst(RNN) - 1
                                                Inton(RNN) = False
                                                GoTo NoStackRemoval
                                            End If
                                        End If
                                    End If
                                    If RangeInst(RNN) >= 0 Then
                                    'intrange is faster than ordinary range, but it returns 601 when nobody is ranged
                                        RRange = 601
                                        RRadar = RAim(RNN) + RLook(RNN)
                                    
                                        For shotcounter = 1 To NumberOfRobotsPresent
                                            If shotcounter <> RNN Then   'Skip checking range to self. It'll be too short
                                                tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
                                                trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
                                                trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
                                    
                                                If trigx * trigx + trigy * trigy > 91 Then tempnumber = 601 'This should be faster
                                    
                                                If tempnumber < RRange Then
                                                    RRange = tempnumber
                                                    RangedRobot(RNN) = shotcounter
                                                End If
                                            End If
                                        Next shotcounter
                                        
                                        If RobotTeam(RNN) <> 0 Then
                                            If RRange <> 601 Then
                                                If RobotTeam(RNN) = RobotTeam(RangedRobot(RNN)) Then RRange = 601
                                            End If
                                        End If
                                    '''''''''''
                                        If RRange <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                            If RobotAlive(RangedRobot(RNN)) = 1 Then
                                                RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
                                                Inton(RNN) = False
                                                GoTo NoStackRemoval
                                            End If
                                        End If
                                    End If
                                End If '**********Slut Interuppskod************'
                            Case insSPEEDX 'ins
                                If Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RSpeedx(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
                                RSpeedx(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSPEEDY 'ins
                                If Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RSpeedy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
                                RSpeedy(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insMISSILE 'ins
                                If RobotMissiles(RNN) = 0 Then
                                    ErrorCode = BuggyMissiles
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
                                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If PlaySounds Then sndPlaySound missilesound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT 'Or SND_NOSTOP
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotAngle = RAim(RNN)
                                                shot(ShotNumber).ShotType = Missile
                                                shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotAngle = RAim(RNN)
                                                shot(FreeShot).ShotType = Missile
                                                shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insFIRE 'ins
Robot1Fire:
                                If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                    REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    If HasMoved <> 5 Or MoveAndShotAllowed Then
                                        If PlaySounds Then sndPlaySound bulletsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
                                        If FreeShot = -1 Then
                                            ShotNumber = ShotNumber + 1
                                            shot(ShotNumber).ShotAngle = RAim(RNN)
                                            shot(ShotNumber).ShotType = Bullet
                                            shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                            shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                            shot(ShotNumber).Shooter = RNN
                                            Select Case RobotBullets(RNN)
                                                Case 0
                                                    shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2  '/
                                                Case 2
                                                    shot(ShotNumber).ShotType = ExplosiveBullet
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case 20
                                                    RobotBullets(RNN) = 2
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case Else
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            End Select
                                        Else
                                            shot(FreeShot).ShotAngle = RAim(RNN)
                                            shot(FreeShot).ShotType = Bullet
                                            shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                            shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                            shot(FreeShot).Shooter = RNN
                                            Select Case RobotBullets(RNN)
                                                Case 0
                                                    shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2    '
                                                Case 2
                                                    shot(FreeShot).ShotType = ExplosiveBullet
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case 20
                                                    RobotBullets(RNN) = 2
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case Else
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            End Select
                                            FreeShot = -1
                                        End If
                                        HasMoved = 20
                                    Else
                                        ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                    End If
                                End If
                            Case insSHIELD 'ins
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then         'Prevent negative shield
                                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > 150 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 150 'Prevent shield over 150
                                        REnergy(RNN) = REnergy(RNN) + RShield(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Takes or energy restores energy to/from shield
                                        If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN)         'Prevent energy higher than Robots Energy Max
                                        RShield(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)                  'Sets shield
                                    End If
                            Case insSTUNNER 'ins
                                If RobotStunners(RNN) = 0 Then
                                    ErrorCode = BuggyStunners
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
                                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then      'Stunner don't use freeshots because of the (Stunstreamer - Freeshot) visual bug which is fixed so they do
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotAngle = RAim(RNN)
                                                shot(ShotNumber).ShotType = Stunner
                                                shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4     'Int((RobotStack(RNN, RobotStackPos(RNN) - 1)) / 4)
                                            Else
                                                shot(FreeShot).ShotAngle = RAim(RNN)
                                                shot(FreeShot).ShotType = Stunner
                                                shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insMOVEX 'ins
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                If HasMoved <> 20 Or MoveAndShotAllowed Then
                                    RobotLeft(RNN) = RobotLeft(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    TurretX2(RNN) = TurretX2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    If RobotLeft(RNN) > 300 Then  'otherwise it can use MOVEX to jump outside the areana!!!
                                        RobotLeft(RNN) = 300
                                        TurretX2(RNN) = 300 + TurretX2(RNN) - RobotLeft(RNN)
                                    ElseIf RobotLeft(RNN) < 0 Then
                                        RobotLeft(RNN) = 0
                                        TurretX2(RNN) = TurretX2(RNN) - RobotLeft(RNN)
                                    End If
                                    HasMoved = 5
                                Else
                                    ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                End If
                            Case insMOVEY 'ins
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                If HasMoved <> 20 Or MoveAndShotAllowed Then
                                    RobotTop(RNN) = RobotTop(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    TurretY2(RNN) = TurretY2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    If RobotTop(RNN) > 300 Then 'otherwise it can use MOVEX to jump outside the areana!!!
                                        RobotTop(RNN) = 300
                                        TurretY2(RNN) = 300 + TurretY2(RNN) - RobotTop(RNN)
                                    ElseIf RobotTop(RNN) < 0 Then
                                        RobotTop(RNN) = 0
                                        TurretY2(RNN) = TurretY2(RNN) - RobotTop(RNN)
                                    End If
                                    HasMoved = 5
                                Else
                                    ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                End If
                            Case insHELLBORE 'ins
                                If RobotHellbores(RNN) = 0 Then
                                    ErrorCode = BuggyHellbores
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 3 And RobotStack(RNN, RobotStackPos(RNN) - 1) < 21 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If PlaySounds Then sndPlaySound hellboresound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotAngle = RAim(RNN)
                                                shot(ShotNumber).ShotType = Hellbore
                                                shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            Else
                                                shot(FreeShot).ShotAngle = RAim(RNN)
                                                shot(FreeShot).ShotType = Hellbore
                                                shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insA: RA(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insB: RB(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insC: RC(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insD: RD(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insE: RE(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insF: RF(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insG: RG(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insH: RH(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insI: RI(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insJ: RJ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insK: RK(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insL: RL(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insM: RM(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insN: RN(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insO: RO(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insP: RP(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insQ: RQ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insR: RR(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insS: RS(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case Inst: RT(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insU: RU(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insV: RV(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insZ: RZ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insW: RW(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insLOOK 'ins
                                RLook(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RLook(RNN) > 359 Then RLook(RNN) = RLook(RNN) Mod 360
                                If RLook(RNN) < 0 Then RLook(RNN) = RLook(RNN) Mod 360 + 360
                                If Inton(RNN) And RangeInst(RNN) >= 0 Then '**********Interuppskod************
                                'intrange is faster than ordinary range, but it returns 601 when nobody is ranged
                                    RRange = 601
                                    RRadar = RAim(RNN) + RLook(RNN)
                                
                                    For shotcounter = 1 To NumberOfRobotsPresent
                                        If shotcounter <> RNN Then   'Skip checking range to self. It'll be too short
                                            tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
                                            trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
                                            trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
                                
                                            If trigx * trigx + trigy * trigy > 91 Then tempnumber = 601 'This should be faster
                                
                                            If tempnumber < RRange Then
                                                RRange = tempnumber
                                                RangedRobot(RNN) = shotcounter
                                            End If
                                        End If
                                    Next shotcounter
                                    
                                    If RobotTeam(RNN) <> 0 Then
                                        If RRange <> 601 Then
                                            If RobotTeam(RNN) = RobotTeam(RangedRobot(RNN)) Then RRange = 601
                                        End If
                                    End If
                                '''''''''''
                                    If RRange <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                        
                                        If RobotAlive(RangedRobot(RNN)) = 1 Then
                                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                            RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
                                            Inton(RNN) = False
                                            GoTo NoStackRemoval
                                        End If
                                    End If
                                End If '**********Slut Interuppskod************'
                            Case insBULLET 'ins                                 'It seems like a robot can mess up it's explosive
                                If RobotBullets(RNN) = 2 Then RobotBullets(RNN) = 20      'bullets by firing negative shots. It's certainly
                                GoTo Robot1Fire                                 'not an adventage, so it' can't be considered cheating
                            Case insNUKE 'ins
                                If RobotTacNukes(RNN) = 0 Then
                                    ErrorCode = BuggyTacNukes
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotFireTime = Chronon
                                                shot(ShotNumber).ShotType = TakeNuke
                                                shot(ShotNumber).ShotX = RobotLeft(RNN)
                                                shot(ShotNumber).ShotY = RobotTop(RNN)
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotFireTime = Chronon
                                                shot(FreeShot).ShotType = TakeNuke
                                                shot(FreeShot).ShotX = RobotLeft(RNN)
                                                shot(FreeShot).ShotY = RobotTop(RNN)
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insMEGANUKE 'ins
                                If RobotTacNukes(RNN) = 0 Then
                                    ErrorCode = BuggyTacNukes
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotFireTime = Chronon
                                                shot(ShotNumber).ShotType = MegaNuke
                                                shot(ShotNumber).ShotX = RobotLeft(RNN)
                                                shot(ShotNumber).ShotY = RobotTop(RNN)
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotFireTime = Chronon
                                                shot(FreeShot).ShotType = MegaNuke
                                                shot(FreeShot).ShotX = RobotLeft(RNN)
                                                shot(FreeShot).ShotY = RobotTop(RNN)
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insMINE 'ins
                                If RobotMines(RNN) = 0 Then
                                    ErrorCode = BuggyMines
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) - 5 > 0 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If PlaySounds Then sndPlaySound minesound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotFireTime = Chronon
                                                shot(ShotNumber).ShotType = Mine
                                                shot(ShotNumber).ShotX = RobotLeft(RNN)
                                                shot(ShotNumber).ShotY = RobotTop(RNN)
                                                shot(ShotNumber).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotFireTime = Chronon
                                                shot(FreeShot).ShotType = Mine
                                                shot(FreeShot).ShotX = RobotLeft(RNN)
                                                shot(FreeShot).ShotY = RobotTop(RNN)
                                                shot(FreeShot).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insLASER 'ins
                                If RobotLasers(RNN) = 0 Then
                                    ErrorCode = BuggyLasers
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then ' It is possible in the Mac version to shoot laser shots that actually doesn't do any harm
                                        If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then  'It seems to be possible to shoot laser at dead robots
                                            If RobotAlive(RangedRobot(RNN)) = 1 Then
                                                'If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                                If RobotStack(RNN, RobotStackPos(RNN) - 1) > REnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = REnergy(RNN)
                                                
                                                REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                If HasMoved <> 5 Or MoveAndShotAllowed Then
                                                    If PlaySounds Then sndPlaySound lasersound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
'                                                   TurretX2(RNN) = RobotLeft(RNN) + sin10(RAim(RNN))  'FOR UNDISPLAYED!!!
'                                                   TurretY2(RNN) = RobotTop(RNN) - cos10(RAim(RNN))  'FOR UNDISPLAYED!!!

                                                    If FreeShot = -1 Then
                                                        ShotNumber = ShotNumber + 1
                                                        shot(ShotNumber).ShotType = Laser
                                                        shot(ShotNumber).ShotAngle = RangedRobot(RNN)
                                                        shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
                                                        shot(ShotNumber).Shooter = RNN
                                                        shot(ShotNumber).ShotFireTime = RAim(RNN)         'Ta bort i undisplayed!
                                                        shot(ShotNumber).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN)    'Shows laser on radar instantly
                                                        shot(ShotNumber).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
                                                    Else
                                                        shot(FreeShot).ShotType = Laser
                                                        shot(FreeShot).ShotAngle = RangedRobot(RNN)
                                                        shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
                                                        shot(FreeShot).Shooter = RNN
                                                        shot(FreeShot).ShotFireTime = RAim(RNN)         'Ta bort i undisplayed!
                                                        shot(FreeShot).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN)    'Shows laser on radar instantly
                                                        shot(FreeShot).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
                                                        FreeShot = -1
                                                    End If
                                                    HasMoved = 20
                                                Else
                                                    ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Case insDRONE 'ins
                                If RobotDrones(RNN) = 0 Then
                                    ErrorCode = BuggyDrones
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 And Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then    'Range <> 0
                                        If RobotAlive(RangedRobot(RNN)) = 1 Then  'Cuts down the shot power to the Robots energy max
                                            If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                            REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            If HasMoved <> 5 Or MoveAndShotAllowed Then
                                                If PlaySounds Then
                                                    If Chronon - DroneSoundPlayed(RNN) >= 3 Or Not (Normal.Checked Or Slow.Checked) Or DebuggedRobot = RNN Then
                                                        sndPlaySound DroneSound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
                                                        DroneSoundPlayed(RNN) = Chronon
                                                    End If
                                                End If
                                                If FreeShot = -1 Then
                                                    ShotNumber = ShotNumber + 1
                                                    shot(ShotNumber).ShotAngle = RangedRobot(RNN)   'Shootangle represents tracking robot
                                                    shot(ShotNumber).ShotFireTime = Chronon + 100   'ShotFireTime represents the chronon the drone die
                                                    shot(ShotNumber).ShotType = Drone
                                                    shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                    shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
                                                    shot(ShotNumber).Shooter = RNN
                                                Else
                                                    shot(FreeShot).ShotAngle = RangedRobot(RNN)   'Shootangle represents tracking robot
                                                    shot(FreeShot).ShotFireTime = Chronon + 100   'ShotFireTime represents the chronon the drone die
                                                    shot(FreeShot).ShotType = Drone
                                                    shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                    shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
                                                    shot(FreeShot).Shooter = RNN
                                                    FreeShot = -1
                                                End If
                                                HasMoved = 20
                                            Else
                                                ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                            End If
                                        End If
                                    End If
                                End If
                            Case insSCAN 'ins
                                RScan(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RScan(RNN) > 359 Then RScan(RNN) = RScan(RNN) Mod 360
                                If RScan(RNN) < 0 Then RScan(RNN) = RScan(RNN) Mod 360 + 360
                                If Inton(RNN) And RadarInst(RNN) >= 0 Then
                                    'RADAR
                                    RRadar = 0
                                    For shotcounter = 1 To ShotNumber
                                        If shot(shotcounter).ShotType < 200 Then
                                            'This is David Harris radar code, ported to Visual Basic by me.
                                            trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                                            trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                                            
                                            If trigx <> 0 Then   'atan2
                                                tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                                            Else
                                                tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                                            End If          '''''''
                                            
                                            If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                                            
                                            If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                                                RRange = FixSquare(trigx * trigx + trigy * trigy)
                                                If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                                            End If
                                        End If
                                    Next shotcounter
                                    '/RADAR
                                    If RRadar <> 0 Then
                                        If RRadar <= RadarParam(RNN) Then
                                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                            RobotInstPos(RNN) = RadarInst(RNN) - 1 ' - 1 nytt
                                            Inton(RNN) = False
                                            GoTo NoStackRemoval
                                        End If
                                    End If
                                End If
                            Case insHISTORY 'ins
                                If HistoryParam(RNN) >= 31 Then HistoryRec(RNN, HistoryParam(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSIGNAL
                                If RobotTeam(RNN) <> 0 Then
                                    RSignal(RobotTeam(RNN), RChannel(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
   
                                    For tempnumber = 1 To NumberOfRobotsPresent
                                        If RobotTeam(RNN) = RobotTeam(tempnumber) Then
                                            If tempnumber <> RNN Then
                                                If SignalInst(tempnumber) >= 0 Then
                                                    If SignalParam(tempnumber) = RChannel(RNN) Then
                                                        RobotQuePos(tempnumber) = RobotQuePos(tempnumber) + 1
                                                        RobotIntQue(tempnumber, RobotQuePos(tempnumber)) = SignalInst(tempnumber)
                                                        IntID(tempnumber, RobotQuePos(tempnumber)) = 11
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next tempnumber
                                End If
                            Case insCHANNEL
                                RChannel(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RChannel(RNN) > 10 Or RChannel(RNN) < 1 Then
                                    ErrorCode = BuggyChannel: GoTo Buggy
                                End If
                            Case Else
                                ErrorCode = BuggyStore
                                GoTo Buggy
                            End Select
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
NoStackRemoval:
                    Case insRECALL       'Removing the Reversed Recalls took exactly 3 hours and 29 minutes, including speed testing but
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        Select Case RobotStack(RNN, RobotStackPos(RNN))     'excluding recompiling all robots
                            Case insRANGE 'ins
                                RRange = Range(RNN, RAim(RNN) + RLook(RNN))
                                If RRange <> 0 Then
                                    If RobotAlive(RangedRobot(RNN)) <> 1 Then RRange = 0
                                End If
                                RobotStack(RNN, RobotStackPos(RNN)) = RRange
                            Case insAIM 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RAim(RNN)
                            Case insX 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RobotLeft(RNN)
                            Case insY 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RobotTop(RNN)
                            Case insRADAR 'ins
                                'RADAR
                                RRadar = 0 'RRadar
                                For shotcounter = 1 To ShotNumber
                                    If shot(shotcounter).ShotType < 200 Then
                                        'This is David Harris radar code, ported to Visual Basic by me.
                                        trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                                        trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                                        
                                        If trigx <> 0 Then   'atan2
                                            tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                                        Else
                                            tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                                        End If          '''''''
                                        
                                        If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                                        
                                        If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                                            RRange = FixSquare(trigx * trigx + trigy * trigy)
                                            If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                                        End If
                                    End If
                                Next shotcounter
                                '/RADAR
                                RobotStack(RNN, RobotStackPos(RNN)) = RRadar
                            Case insSPEEDX 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RSpeedx(RNN)
                            Case insSPEEDY 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RSpeedy(RNN)
                            Case insENERGY 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RNN)
                            Case insSHIELD 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RShield(RNN)
                            Case insLOOK 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RLook(RNN)
                            Case insDOPPLER 'ins
                                'Many Thanks to Sam Rushing who helped me out
                                'and explained how the Doppler routine worked.    'Dead robot are set to E = -10
                                
                                'Prfnoff's version - Robots with E -1 has doppler?
                                '4.5.2 - Robots med E -1 doesn't have doppler

                                If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'Med allra allra största sannolikhet skall jag använda RealStunned
                                    If REnergy(RangedRobot(RNN)) <= 0 Or RStunned(RangedRobot(RNN)) <> 0 Or RCollision(RangedRobot(RNN)) <> 0 Then    'RWall(RangedRobot(RNN)) <> 0 Or
                                        RobotStack(RNN, RobotStackPos(RNN)) = 0
                                    Else
                                        RRange = RobotLeft(RNN) - RobotLeft(RangedRobot(RNN))    'xdiff
                                        RRadar = RobotTop(RNN) - RobotTop(RangedRobot(RNN))      'ydiff
                                        'Ej testat om det skall vara round eller fix, kolla
                                        RobotStack(RNN, RobotStackPos(RNN)) = Round((RSpeedx(RangedRobot(RNN)) * RRadar - RRange * RSpeedy(RangedRobot(RNN))) / Square(RRadar * RRadar + RRange * RRange))  'Round
                                    End If
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                End If
                            Case insNEAREST
                                If RobotProSpeed(RNN) <= 10 Then
                                    If NumberOfRobotsPresent > 1 Then
                                        tempnumber = Nearest(RNN)
                                        If RobotAlive(tempnumber) = 1 Then
                                            If RobotTop(tempnumber) <> RobotTop(RNN) Then
                                                If RobotTop(RNN) > RobotTop(tempnumber) Then
                                                    RobotStack(RNN, RobotStackPos(RNN)) = (Round(TPI * Atn((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN))))) - RAim(RNN)
                                                Else
                                                    RobotStack(RNN, RobotStackPos(RNN)) = (Round(TPI * Atn((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN)))) + 180) - RAim(RNN)
                                                End If
                                            Else
                                                If RobotLeft(RNN) < RobotLeft(tempnumber) Then
                                                    RobotStack(RNN, RobotStackPos(RNN)) = 90 - RAim(RNN)
                                                Else
                                                    RobotStack(RNN, RobotStackPos(RNN)) = 270 - RAim(RNN)
                                                End If
                                            End If
                                            
                                            If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 360
                                        Else
                                            RobotStack(RNN, RobotStackPos(RNN)) = -1
                                        End If
                                    Else
                                        RobotStack(RNN, RobotStackPos(RNN)) = -1
                                    End If
                                Else
                                    ErrorCode = BuggyNearest
                                    GoTo Buggy
                                End If
                            Case insROBOTS 'ins
                                If HowManyLeft = 255 Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = 1
                                ElseIf R2Present Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = HowManyLeft
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 1
                                End If
                            Case insCHRONON 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = Chronon
                            Case insCOLLISION 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = Sgn(RCollision(RNN))
                            Case insA 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RA(RNN)
                            Case insB 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RB(RNN)
                            Case insC 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RC(RNN)
                            Case insD 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RD(RNN)
                            Case insE 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RE(RNN)
                            Case insF 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RF(RNN)
                            Case insG 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RG(RNN)
                            Case insH 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RH(RNN)
                            Case insI 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RI(RNN)
                            Case insJ 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RJ(RNN)
                            Case insK 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RK(RNN)
                            Case insL 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RL(RNN)
                            Case insM 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RM(RNN)
                            Case insN 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RN(RNN)
                            Case insO 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RO(RNN)
                            Case insP 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RP(RNN)
                            Case insQ 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RQ(RNN)
                            Case insR 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RR(RNN)
                            Case insS 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RS(RNN)
                            Case Inst 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RT(RNN)
                            Case insU 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RU(RNN)
                            Case insV 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RV(RNN)
                            Case insZ 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RZ(RNN)
                            Case insW 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RW(RNN)
                            Case insPROBE 'ins
                                If RobotProbes(RNN) = 0 Then
                                    ErrorCode = BuggyProbes
                                    GoTo Buggy
                                Else
                                    If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then
                                        If RobotAlive(RangedRobot(RNN)) <> 1 Then
                                            RobotStack(RNN, RobotStackPos(RNN)) = 0
                                        Else
                                            Select Case ProbeSet(RNN)
                                                '0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
                                                '4 = Teammates - Currently disabled 'cause of no teams
                                                Case 1
                                                    RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RangedRobot(RNN))
                                                Case 0
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RangedRobot(RNN))
                                                Case 2
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RShield(RangedRobot(RNN))
                                                Case 7
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RScan(RangedRobot(RNN))
                                                Case 3
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RangedRobot(RNN) - 1 '0 to 5
                                                Case 5
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RAim(RangedRobot(RNN))
                                                Case 6
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RLook(RangedRobot(RNN))
                                                Case 4
                                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                                    For tempnumber = 1 To NumberOfRobotsPresent
                                                        If tempnumber <> RangedRobot(RNN) Then
                                                            If RobotTeam(tempnumber) = RobotTeam(RangedRobot(RNN)) Then
                                                                If RobotAlive(tempnumber) = 1 Then
                                                                    RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
                                                                End If
                                                            End If
                                                        End If
                                                    Next tempnumber
                                            End Select
                                        End If
                                    Else
                                        RobotStack(RNN, RobotStackPos(RNN)) = 0
                                    End If
                                End If
                            Case insWALL 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RWall(RNN)
                            Case insDAMAGE 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RNN)
                            Case insRANDOM 'ins
                                If RunningTournament Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = Round((359 + 1) * Rnd)  'Int
                                Else
                                    If Replaying And NotRandomEmergency Then
                                        RobotStack(RNN, RobotStackPos(RNN)) = RandomRegister(RandomCounter)
                                    Else
                                        RobotStack(RNN, RobotStackPos(RNN)) = Round((359 + 1) * Rnd)  'Int
                                        ReDim Preserve RandomRegister(RandomCounter)
                                        RandomRegister(RandomCounter) = RobotStack(RNN, RobotStackPos(RNN))
                                    End If
                                    RandomCounter = RandomCounter + 1
                                End If
                            Case insSCAN 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RScan(RNN)
                            Case insID 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RNN - 1 '0 to 5
                            Case insHISTORY 'ins     'If repeat battle is checked we should read from the backup rec, unless we're using user defined history, in case we should read from the regular rec, since regular rec 31-50 is reset at the end of a repeated battle
                                If Replaying And HistoryParam(RNN) < 31 Then RobotStack(RNN, RobotStackPos(RNN)) = BackupHistoryRec(RNN, HistoryParam(RNN)) Else RobotStack(RNN, RobotStackPos(RNN)) = HistoryRec(RNN, HistoryParam(RNN))
                            Case insKILLS 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = KR(RNN)
                            Case insSIGNAL
                                If RobotTeam(RNN) <> 0 Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = RSignal(RobotTeam(RNN), RChannel(RNN))
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                End If
                            Case insFRIEND
                                If RCollision(RNN) <> 0 And RobotTeam(RNN) <> 0 Then
                                    If RobotTeam(RCollision(RNN)) = RobotTeam(RNN) Then RobotStack(RNN, RobotStackPos(RNN)) = 1 Else RobotStack(RNN, RobotStackPos(RNN)) = 0
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                End If
                            Case insCHANNEL
                                RobotStack(RNN, RobotStackPos(RNN)) = RChannel(RNN)
                            Case insTEAMMATES
                                RobotStack(RNN, RobotStackPos(RNN)) = 0
                                For tempnumber = 1 To NumberOfRobotsPresent
                                    If tempnumber <> RNN Then
                                        If RobotTeam(tempnumber) = RobotTeam(RNN) Then
                                            If RobotAlive(tempnumber) = 1 Then
                                                RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
                                            End If
                                        End If
                                    End If
                                Next tempnumber
                            Case Else
                                ErrorCode = BuggyRecall '& RobotStack(RNN, RobotStackPos(RNN))
                                GoTo Buggy
                        End Select
                    Case insIF 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                        Else
                            tempnumber = RobotInstPos(RNN) + 1
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        End If
                    Case insMORE
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) >= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insJUMP 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                            RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                        Else
                            ErrorCode = BuggyDestination: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insIFG 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insPLUS
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + RobotStack(RNN, RobotStackPos(RNN) + 1)
                        If Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
                            ErrorCode = BuggyNumberOutofBounds: GoTo Buggy
                        End If
                    Case insLESS
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                    
                        If RobotStack(RNN, RobotStackPos(RNN)) <= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSYNC 'Rep'
                        Exit For
                    Case insDUP 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If

                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                    Case insSETINT 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If

                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > 4999 Or RobotStack(RNN, RobotStackPos(RNN) - 1) < -1 Then
                            ErrorCode = BuggyDestination: GoTo Buggy
                        End If

                        Select Case RobotStack(RNN, RobotStackPos(RNN))
                            Case insRANGE ' 'Rep'
                                RangeInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insLEFT ' 'Rep'
                                LeftInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If LeftInst(RNN) = -1 Then          'BUG ALERT!! Detta klarar bara om första stacknumret är
                                    If RobotQuePos(RNN) <> 0 Then   'hett! Tillfällig lösning
                                        If IntID(RNN, RobotQuePos(RNN)) = 3 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insRIGHT ' 'Rep'
                                RightInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RightInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 4 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insTOP ' 'Rep'
                                TopInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If TopInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 1 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insBOT ' 'Rep'
                                BotInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If BotInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 2 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insWALL ' 'Rep'
                                WallInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If WallInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 7 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insCOLLISION ' 'Rep'
                                CollisionInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If CollisionInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 8 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insROBOTS ' 'Rep'
                                RobotsInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RobotsInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 9 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insCHRONON ' 'Rep'
                                ChrononInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insRADAR ' 'Rep'
                                RadarInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insDAMAGE ' 'Rep'
                                DamageInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If DamageInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 6 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insSHIELD ' 'Rep'
                                ShieldInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If ShieldInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 5 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                Else    'Else är nytt - tidigare stod If Rshieled utanför if
                                    If RShield(RNN) < ShieldParam(RNN) Then ShieldInst(RNN) = ShieldInst(RNN) + 5000
                                End If
                            Case insTEAMMATES ' 'Rep'
                                TeammatesInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If TeammatesInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 10 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insSIGNAL ' 'Rep'
                                SignalInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If SignalInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 11 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case Else
                                ErrorCode = BuggySetint
                                GoTo Buggy
                        End Select
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insRTI 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        Inton(RNN) = True
                        If RobotQuePos(RNN) <= 0 Then
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        Else
                            RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1    'qued ints subtracted when triggered             'jumps shall be done
                            Inton(RNN) = False
                            RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                        End If
                    Case insSETPARAM 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        Select Case RobotStack(RNN, RobotStackPos(RNN))
                            Case insRANGE ' 'Rep'
                                RangeParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insLEFT ' 'Rep'
                                LeftParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insRIGHT ' 'Rep'
                                RightParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insTOP ' 'Rep'
                                TopParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insBOT ' 'Rep'
                                BotParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insPROBE ' 'Rep'
                            '0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
                            '4 = Teammates - Currently disabled 'cause of no teams
                                Select Case RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    Case insDAMAGE ' 'Rep'
                                        ProbeSet(RNN) = 0
                                    Case insENERGY ' 'Rep'
                                        ProbeSet(RNN) = 1
                                    Case insSHIELD ' 'Rep'
                                        ProbeSet(RNN) = 2
                                    Case insSCAN ' 'Rep'
                                        ProbeSet(RNN) = 7
                                    Case insID ' 'Rep'
                                        ProbeSet(RNN) = 3
                                    Case insAIM ' 'Rep'
                                        ProbeSet(RNN) = 5
                                    Case insLOOK ' 'Rep'
                                        ProbeSet(RNN) = 6
                                    Case insTEAMMATES ' 'Rep'
                                        ProbeSet(RNN) = 4
'                                    Case Else
'                                        ErrorCode =  'Rep'Illegal 'PROBE' register  'Rep' & RobotStack(RNN, RobotStackPos(RNN))
'                                        GoTo Buggy
                                End Select
                            Case insRADAR ' 'Rep'
                                RadarParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insCHRONON ' 'Rep'
                                ChrononParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insROBOTS ' 'Rep'
                                RobotsParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insDAMAGE ' 'Rep'
                                DamageParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If DamageParam(RNN) > RDamage(RNN) Then DamageParam(RNN) = RDamage(RNN)
                            Case insHISTORY ' 'Rep'
                                HistoryParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSHIELD ' 'Rep'
                                ShieldParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insTEAMMATES ' 'Rep'
                                TeammatesParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSIGNAL
                                SignalParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case Else
                                ErrorCode = BuggySetparam
                                GoTo Buggy
                            End Select
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insCALL 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        tempnumber = RobotInstPos(RNN) + 1
                        If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                            RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                        Else
                            ErrorCode = BuggyDestination: GoTo Buggy
                        End If
                        RobotStack(RNN, RobotStackPos(RNN)) = tempnumber
                    Case insAND 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 Or RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insMINUS
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) - RobotStack(RNN, RobotStackPos(RNN) + 1)
                        If Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
                            ErrorCode = BuggyNumberOutofBounds: GoTo Buggy
                        End If
                    Case insINTON 'Rep'
                        Inton(RNN) = True
                        If RobotQuePos(RNN) > 0 Then
                            If RobotStackPos(RNN) > 99 Then
                                ErrorCode = BuggyOverflow: GoTo Buggy
                            End If
                            RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
                            RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1    'qued ints subtracted when triggered             'jumps shall be done
                            Inton(RNN) = False
                            RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                        End If
                    Case insDIVISION
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
                            ErrorCode = BuggyDivision: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) \ RobotStack(RNN, RobotStackPos(RNN) + 1)
                    Case insTIMES
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) * RobotStack(RNN, RobotStackPos(RNN) + 1)
                        If Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
                            ErrorCode = BuggyNumberOutofBounds: GoTo Buggy
                        End If
                    Case insSAME
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
'                    case insBEEP 'Rep' 'Represents all icon snd instructions, debug, print and beep  for undisplayed
'                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insICON0 'Rep'
                        RobotIconNumber(RNN) = 0
                        Set Robot_(RNN) = RobotMasterIcon(RNN * 10)
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insICON1 'Rep'
                        Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 1)
                        RobotIconNumber(RNN) = 10       'To prevent setting back when shield drops
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insICON2 'Rep'
                        Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 2)
                        RobotIconNumber(RNN) = 2
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insICON3 'Rep'
                        Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 3)
                        RobotIconNumber(RNN) = 3
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insICON4 'Rep'
                        Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 4)
                        RobotIconNumber(RNN) = 4
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insICON5 'Rep'
                        Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 5)
                        RobotIconNumber(RNN) = 5
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insICON6 'Rep'
                        Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 6)
                        RobotIconNumber(RNN) = 6
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insICON7 'Rep'
                        Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 7)
                        RobotIconNumber(RNN) = 7
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insICON8 'Rep'
                        Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 8)
                        RobotIconNumber(RNN) = 8
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insICON9 'Rep'
                        Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 9)
                        RobotIconNumber(RNN) = 9
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insSND0 'Rep'
                        If PlaySounds Then PlaySnd0 (RNN)
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insSND1 'Rep'
                        If PlaySounds Then PlaySnd1 (RNN)
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insSND2 'Rep'
                        If PlaySounds Then PlaySnd2 (RNN)
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insSND3 'Rep'
                        If PlaySounds Then PlaySnd3 (RNN)
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insSND4 'Rep'
                        If PlaySounds Then PlaySnd4 (RNN)
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insSND5 'Rep'
                        If PlaySounds Then PlaySnd5 (RNN)
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insSND6 'Rep'
                        If PlaySounds Then PlaySnd6 (RNN)
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insSND7 'Rep'
                        If PlaySounds Then PlaySnd7 (RNN)
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insSND8 'Rep'
                        If PlaySounds Then PlaySnd8 (RNN)
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insSND9 'Rep'
                        If PlaySounds Then PlaySnd9 (RNN)
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insARCTAN 'Rep'                                       'Shall not use Fix!!
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = Round(TPI * Atn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)) + 90 - (90 * (Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1)) - 1)))
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * Sgn(RobotStack(RNN, RobotStackPos(RNN))) * (Sgn(RobotStack(RNN, RobotStackPos(RNN))) + 1)
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insDROPALL 'Rep'
                        RobotStackPos(RNN) = 0
                    Case insNOT 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
                            RobotStack(RNN, RobotStackPos(RNN)) = 1
                        Else
                            RobotStack(RNN, RobotStackPos(RNN)) = 0     'Nej, dethär går inte att förenkla
                        End If
                    Case insDROP 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSWAP 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        tempnumber = RobotStack(RNN, RobotStackPos(RNN))
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
                    Case insIFEG 'Rep'
                        If RobotStackPos(RNN) < 3 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                        Else
                            If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 3
                    Case insVRECALL 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) < 0 Or RobotStack(RNN, RobotStackPos(RNN)) > 100 Then
                            RobotStack(RNN, RobotStackPos(RNN)) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN)) = RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN)))
                        End If
                    Case insMOD 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN) - 1) Mod RobotStack(RNN, RobotStackPos(RNN))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insOR 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 And RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insIFE 'Rep'
                        If RobotStackPos(RNN) < 3 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
                            tempnumber = RobotInstPos(RNN) + 1
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                        Else
                            tempnumber = RobotInstPos(RNN) + 1       'Samma sak här, det borde funka med tempnumber
                            If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                        End If
                    Case insMAX 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) > RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSIN 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * Sin(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insCOS 'Rep'              'Fix avrundar exact som Mac RoboWar!!
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * Cos(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insINTOFF 'Rep'
                        Inton(RNN) = False
                    Case insVSTORE 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) >= 0 And RobotStack(RNN, RobotStackPos(RNN)) <= 100 Then
                            RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN))) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insCHS 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN)) = -RobotStack(RNN, RobotStackPos(RNN)) '* -1
                    Case insABS 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN)) = Abs(RobotStack(RNN, RobotStackPos(RNN)))

                    Case insTAN '       BUG ALERT!! Hur är det med 90 + de nya optimeringarna?
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        TDouble = Fix(RobotStack(RNN, RobotStackPos(RNN)) * Tan((90 - RobotStack(RNN, RobotStackPos(RNN) - 1)) * PIO))
                        If Abs(TDouble) > 19999 Then TDouble = 19999 * Sgn(TDouble)
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = TDouble
                    Case insNOT_SAME 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insROLL 'Rep'
                        If RobotStackPos(RNN) < RobotStack(RNN, RobotStackPos(RNN)) + 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        tempnumber = RobotStack(RNN, RobotStackPos(RNN) - 1)     'Stores the number to roll back in tempstack
                        For shotcounter = RobotStackPos(RNN) - 1 To RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) Step -1 'decides what stack numbers moving up
                            RobotStack(RNN, shotcounter) = RobotStack(RNN, shotcounter - 1)       'adjust stack numbers affected by roll
                        Next shotcounter
                        RobotStack(RNN, RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) - 1) = tempnumber   'Do the roll
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1 'Adjusts stack number because top operand has been removed
                    Case insMIN 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) < RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insNOP 'Rep'
                    Case insDIST 'Rep'     'Totally useless, it can be precalculated!
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(Sqr(RobotStack(RNN, RobotStackPos(RNN)) ^ 2 + RobotStack(RNN, RobotStackPos(RNN) - 1) ^ 2))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insFLUSHINT 'Rep'
                        RobotQuePos(RNN) = 0
                    Case insXOR 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If (RobotStack(RNN, RobotStackPos(RNN)) <> 0) Xor (RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insARCSIN 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Asn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * Sgn(RobotStack(RNN, RobotStackPos(RNN))) * Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1))
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insARCCOS 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Acn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = -180 * (Sgn(RobotStack(RNN, RobotStackPos(RNN))) <> Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1)))
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSQRT 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then
                            ErrorCode = BuggySquare: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN)) = FixSquare(RobotStack(RNN, RobotStackPos(RNN)))
                    Case insBEEP 'Rep'     'beep will continiue battle, placed before print and debug cause of that
                        If PlaySounds Then sndPlaySound beepsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insPRINT 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If Not RunningTournament Then
                            tempnumber = MsgBox(RobotStack(RNN, RobotStackPos(RNN)) & vbCr & vbCr & "Would you like to stop the Battle?", vbYesNo + vbDefaultButton2, "Print " & GetRobot(RNN))
                            If tempnumber = vbYes Then GoTo Peace
                        End If
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insDEBUG 'Rep'
                        If DebuggedRobot = 0 And Not (RunningTournament Or InactivateDebug.Checked) Then
                            DebuggerAutoStart = True
                            DebuggedRobot = RNN
                            Image1(RNN).Visible = True  'Är ej med i variant 2
                        End If
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case Else
CodeError1:
                        ErrorCode = Err
Buggy:
                        If RunningTournament Then
                            tempnumber = vbNo
                        ElseIf ErrorCode <= -200 Then
                            tempnumber = ShowErrorMessageParam(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), RobotStack(RNN, RobotStackPos(RNN)))
                        Else
                            tempnumber = ShowErrorMessage(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), MachineCode(RNN, RobotInstPos(RNN)))                   'Response
                        End If

                        RobotAlive(RNN) = 255
                        RScan(RNN) = 9999  'nytt
                        If tempnumber = vbCancel Then GoTo Peace
                        If tempnumber = vbYes Then
                            SelectedRobot = RNN
                            DraftingBoard.GotoInstNr = RobotInstPos(RNN) + 1
                            DraftingBoard.Show 1, MainWindow
                            EndBattleWhenGotoInst
                            Exit Sub
                        End If
                        If Err = 0 Then Exit For Else Resume BackFromError
                    End Select
        Next ChrononExecutor1
    Else        'Energyig + Stunnedif
        If DebuggedRobot = RNN Or (StartDebuggerAt = Chronon And RNN = WillBeDebugged) Then 'DEBUGGER for robots that's out of energy or stunned    'Fixar så den inte skriver fel Energi och sköld
            ChrononStart    'This sub is required when the debugger is set to start at a certain chronon

            If RobotStackPos(RNN) <= 96 Then tempnumber = ((RobotStackPos(RNN) - 1) \ 6) * 6 Else tempnumber = 0
            PrintDebuggingInfo _
                RobotInstPos(RNN) + 1, MachineCode(RNN, RobotInstPos(RNN) + 1), RobotStackPos(RNN), _
                RobotStack(RNN, 1 + tempnumber), RobotStack(RNN, 2 + tempnumber), RobotStack(RNN, 3 + tempnumber), _
                RobotStack(RNN, 4 + tempnumber), RobotStack(RNN, 5 + tempnumber), RobotStack(RNN, 6 + tempnumber), _
                RobotStack(RNN, 100), RobotStack(RNN, 99), RobotStack(RNN, 98), RobotStack(RNN, 97), _
                0, RAim(RNN), RShield(RNN), " ", RangedRobot(RNN), " ", RLook(RNN), _
                RScan(RNN), RSpeedx(RNN), RSpeedy(RNN), REnergy(RNN)    'We have to add 1 to RobotInstPos(RNN) because of the "3 fire' store 0 jump"-bug
            PrintInts Inton(RNN), _
                      LeftParam(RNN), RightParam(RNN), TopParam(RNN), BotParam(RNN), _
                      LeftInst(RNN), RightInst(RNN), TopInst(RNN), BotInst(RNN), _
                      RadarParam(RNN), RadarInst(RNN), RangeInst(RNN), RangeParam(RNN), _
                      RobotQuePos(RNN), RobotIntQue(RNN, 1), RobotIntQue(RNN, 2)
            ReturnMacAdd     'ReturnMacAdd also contains the stop/resume execution instructions
            If DebuggingWindow.DebuggingRes = 1 Then
                SetTabIndex1
            ElseIf DebuggingWindow.DebuggingRes = 2 Then
                TurnOfTheDebugger
            ElseIf DebuggingWindow.DebuggingRes = 3 Then
                GoTo Peace
            Else
                SetTabIndex2
            End If
        End If
    End If          'Stunned if 'energyif
End If          'RobotAlive(RNN) if
BackFromError:
    If HighestToLowest Then RNN = 1 + NumberOfRobotsPresent - RNN   'Turns off backwards evaluation if it's enabled
Next RNN 'Nästa robot loopen

For RNN = 1 To NumberOfRobotsPresent
    If RStunned(RNN) > 0 Then RStunned(RNN) = RStunned(RNN) - 1
    If RCollision(RNN) <> 0 Then
        If RobotCollisionIcon(RNN) Then
            Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 3)
            RobotIconNumber(RNN) = RobotIconNumber(RNN) + 100   'Preserve the Icon the robot had before collision
        End If
    End If
Next RNN

'Shot Manager

NotAnyShotsAtAll = True
Arena.Cls

For shotcounter = 1 To ShotNumber
'ErrorCode = "ShotCounter = " & ShotCounter & Chr(10) & "ShotNumber = " & ShotNumber & Chr(10) & Chr(10) & "FireTime = " & Shot(ShotCounter).ShotFireTime & Chr(10) & "X = " & Shot(ShotCounter).ShotX & Chr(10) & "Y = " & Shot(ShotCounter).ShotY & Chr(10) & "Damage = " & Shot(ShotCounter).ShotPower & Chr(10) & Chr(10) & "FreeShot = " & FreeShot
'If MsgBox(ErrorCode, vbOKCancel, "Debug") = vbCancel Then GoTo Peace

'Fillstyle är som standard = 0. Om det måste ändras måste den sättas tillbaka sen

Select Case shot(shotcounter).ShotType
    Case 200
        FreeShot = shotcounter

    Case Missile
        NotAnyShotsAtAll = False
        trigx = Sin5(shot(shotcounter).ShotAngle)
        trigy = Cos5(shot(shotcounter).ShotAngle)
        shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy

'       shot(ShotCounter).ShotX = shot(ShotCounter).ShotX + sin5(shot(ShotCounter).ShotAngle) 'För undisplayed
'       shot(ShotCounter).ShotY = shot(ShotCounter).ShotY - cos5(shot(ShotCounter).ShotAngle) 'För undisplayed

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then    'BUG ALERT!!! Skall syncas!!!
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 1     'Which robot is hit?
                LastHiter(1) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 2     'Which robot is hit?
                LastHiter(2) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 3     'Which robot is hit?
                LastHiter(3) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 4     'Which robot is hit?
                LastHiter(4) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 5     'Which robot is hit?
                LastHiter(5) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 6     'Which robot is hit?
                LastHiter(6) = shot(shotcounter).Shooter
            Else
                Arena.Line (shot(shotcounter).ShotX, shot(shotcounter).ShotY)-(shot(shotcounter).ShotX + trigx, shot(shotcounter).ShotY - trigy), vbBlack
            End If
        End If

    Case Hellbore
        NotAnyShotsAtAll = False
        trigx = shot(shotcounter).ShotPower * Sine(shot(shotcounter).ShotAngle)
        trigy = shot(shotcounter).ShotPower * Cosine(shot(shotcounter).ShotAngle)

        shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy

        trigx = shot(shotcounter).ShotX - trigx / 2
        trigy = shot(shotcounter).ShotY + trigy / 2

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then      'HELLBORE!!!
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or _
             (trigx - RobotLeft(1)) * (trigx - RobotLeft(1)) + (trigy - RobotTop(1)) * (trigy - RobotTop(1)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 1000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or _
             (trigx - RobotLeft(2)) * (trigx - RobotLeft(2)) + (trigy - RobotTop(2)) * (trigy - RobotTop(2)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 2000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or _
             (trigx - RobotLeft(3)) * (trigx - RobotLeft(3)) + (trigy - RobotTop(3)) * (trigy - RobotTop(3)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 3000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or _
             (trigx - RobotLeft(4)) * (trigx - RobotLeft(4)) + (trigy - RobotTop(4)) * (trigy - RobotTop(4)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 4000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or _
             (trigx - RobotLeft(5)) * (trigx - RobotLeft(5)) + (trigy - RobotTop(5)) * (trigy - RobotTop(5)) < 100 Then
              shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 5000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or _
             (trigx - RobotLeft(6)) * (trigx - RobotLeft(6)) + (trigy - RobotTop(6)) * (trigy - RobotTop(6)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 6000     'Which robot is hit? *1000 for hellbore
            Else
                Arena.FillColor = &H808080         'Creates new shotprojection
                Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbBlack
            End If      'HELLBORE!!!
        End If

    Case Stunner
        NotAnyShotsAtAll = False
        trigx = Sin14(shot(shotcounter).ShotAngle)
        trigy = Cos14(shot(shotcounter).ShotAngle)

        shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy

        trigx = shot(shotcounter).ShotX - trigx
        trigy = trigy + shot(shotcounter).ShotY

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then      'STUNNER!!!
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbGreen: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbGreen
                shot(shotcounter).ShotAngle = 100     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbGreen: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbGreen
                shot(shotcounter).ShotAngle = 200     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbGreen: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbGreen
                shot(shotcounter).ShotAngle = 300     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbGreen: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbGreen
                shot(shotcounter).ShotAngle = 400     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbGreen: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbGreen
                shot(shotcounter).ShotAngle = 500     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbGreen: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbGreen
                shot(shotcounter).ShotAngle = 600     'Which robot is hit? *100 for stunners
            Else
                Arena.Line (shot(shotcounter).ShotX - 2, shot(shotcounter).ShotY - 2)-(shot(shotcounter).ShotX + 3, shot(shotcounter).ShotY + 3), vbBlack
                Arena.Line (shot(shotcounter).ShotX + 2, shot(shotcounter).ShotY - 2)-(shot(shotcounter).ShotX - 3, shot(shotcounter).ShotY + 3), vbBlack
            End If      'STUNNER!!!
        End If

    Case XplosiveBulletDetonation
ExplosiveBullets:
        NotAnyShotsAtAll = False
        If Chronon - shot(shotcounter).ShotFireTime < 4 Then '10
            Arena.FillColor = &HA1A1A2       '&HA1A1A2    '&H80000013
            Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 12 * (Chronon - shot(shotcounter).ShotFireTime), &H808080
        Else
            If PlaySounds Then sndPlaySound takenukesound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
            shot(shotcounter).ShotType = NOSHOT

            For RNN = 1 To NumberOfRobotsPresent
                If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 2025 Then     '45*45?????
                    RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN))): RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
                    DR(RNN) = RDamage(RNN)
                    LastHiter(RNN) = shot(shotcounter).Shooter
                End If
            Next RNN
            
            If DroneShotDown Then
                For RNN = 1 To ShotNumber
                    If shot(RNN).ShotType = Drone Then
                        If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 2025 Then
                            shot(RNN).ShotType = NOSHOT
                            Arena.FillColor = vbBlack: Arena.Circle (shot(RNN).ShotX, shot(RNN).ShotY), 4, vbBlack
                        End If
                    End If
                Next RNN
            End If
        End If
    
    Case TakeNuke
'OldStyleExplosiveBullets:
        NotAnyShotsAtAll = False
        Arena.FillColor = &HA1A1A2    '&H80000013
        Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 5 * (Chronon - shot(shotcounter).ShotFireTime), &H808080
    
        If Chronon - shot(shotcounter).ShotFireTime >= 10 Then '10
            If PlaySounds Then sndPlaySound takenukesound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
            shot(shotcounter).ShotType = NOSHOT

            For RNN = 1 To NumberOfRobotsPresent    '1020
                If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
                    RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN))): RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
                    DR(RNN) = RDamage(RNN)
                    LastHiter(RNN) = shot(shotcounter).Shooter
                    'DR(RNN).Refresh
                End If
            Next RNN
            
            If DroneShotDown Then
                For RNN = 1 To ShotNumber
                    If shot(RNN).ShotType = Drone Then
                        If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then
                            shot(RNN).ShotType = NOSHOT
                            Arena.FillColor = vbBlack: Arena.Circle (shot(RNN).ShotX, shot(RNN).ShotY), 4, vbBlack
                        End If
                    End If
                Next RNN
            End If
        End If

    Case MegaNuke
        NotAnyShotsAtAll = False
        Arena.FillColor = MegaNukeFILLCOLOR ' &HA1A1A2    '&H80000013
        Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 5 * (Chronon - shot(shotcounter).ShotFireTime), MegaNukeOUTERRINGCOLOR
    
        If Chronon - shot(shotcounter).ShotFireTime >= MegaNukeBLASTRADIUS Then '10
            If PlaySounds Then sndPlaySound takenukesound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
            shot(shotcounter).ShotType = NOSHOT

            For RNN = 1 To NumberOfRobotsPresent    '1020
                If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
                    RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower + RShield(RNN))): RShield(RNN) = ZeroOrMore(RShield(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower)
                    DR(RNN) = RDamage(RNN)
                    LastHiter(RNN) = shot(shotcounter).Shooter
                    'DR(RNN).Refresh
                End If
            Next RNN
            
            If DroneShotDown Then
                For RNN = 1 To ShotNumber
                    If shot(RNN).ShotType = Drone Then
                        If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then
                            shot(RNN).ShotType = NOSHOT
                            Arena.FillColor = vbBlack: Arena.Circle (shot(RNN).ShotX, shot(RNN).ShotY), 4, vbBlack
                        End If
                    End If
                Next RNN
            End If
        End If

    Case Mine       'Minor skall ge damage 1 chronon efter
        NotAnyShotsAtAll = False

        Arena.FillStyle = 1
        Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbBlack
        Arena.FillStyle = 0
        Arena.FillColor = vbBlack
        Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 2, vbBlack
        
        If Chronon - shot(shotcounter).ShotFireTime >= 10 Then
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 1     'Which robot is hit?
                LastHiter(1) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 2     'Which robot is hit?
                LastHiter(2) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 3     'Which robot is hit?
                LastHiter(3) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 4     'Which robot is hit?
                LastHiter(4) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 5     'Which robot is hit?
                LastHiter(5) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 6     'Which robot is hit?
                LastHiter(6) = shot(shotcounter).Shooter
            End If
        End If

    Case Drone
        NotAnyShotsAtAll = False

        If RobotAlive(shot(shotcounter).ShotAngle) = 1 And Chronon <= shot(shotcounter).ShotFireTime Then
'Checks drone shotdown
            For tempnumber = 0 To ShotNumber        'This is still extremly buggy
                'If Shot(TempNumber).ShotType = Missile Or Shot(TempNumber).ShotType = Hellbore Or Shot(TempNumber).ShotType = Bullet Or Shot(TempNumber).ShotType = ExplosiveBullet Then
                If shot(tempnumber).ShotType < 4 Then
                    If (shot(tempnumber).ShotX - shot(shotcounter).ShotX) * (shot(tempnumber).ShotX - shot(shotcounter).ShotX) + (shot(tempnumber).ShotY - shot(shotcounter).ShotY) * (shot(tempnumber).ShotY - shot(shotcounter).ShotY) < 50 Then
                        shot(tempnumber).ShotType = NOSHOT
                        shot(shotcounter).ShotType = NOSHOT
                        'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
                        GoTo dontrundronecode
                    End If
                End If
            Next tempnumber
''***************************'Nytt försök med drones     'Succé!! Yay!!
'            'moves te drone towards the tracking robot moves and paints the drone
            'LÄGG TILL IIF, DET KANSKE GÅR SNABBARE
            If Abs(shot(shotcounter).ShotY - RobotTop(shot(shotcounter).ShotAngle)) <= 8 Then   '2 '8
                If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
                    Arena.PaintPicture DroneR, shot(shotcounter).ShotX, shot(shotcounter).ShotY - 2
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2
                Else
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2
                    Arena.PaintPicture DroneL, shot(shotcounter).ShotX - 2, shot(shotcounter).ShotY - 2
                End If
            ElseIf Abs(shot(shotcounter).ShotX - RobotLeft(shot(shotcounter).ShotAngle)) <= 8 Then '2 '8
                If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then
                    Arena.PaintPicture DroneD, shot(shotcounter).ShotX - 2, shot(shotcounter).ShotY
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2
                Else
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2
                    Arena.PaintPicture DroneU, shot(shotcounter).ShotX - 2, shot(shotcounter).ShotY - 2 '- 2 för att den börjar måla den i vänstra hörnet
                End If
            Else
                If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2 '1.41421356237 '2*cos 45 = 2*sin 45 = 1.41421356237
                    RNN = 2
                Else
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2 '1.41421356237
                    RNN = 0
                End If
                If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then 'RobotTop(shot(ShotCounter).ShotAngle) + 16 'Varför + 16??
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2 '1.41421356237
                    RNN = RNN + 4
                Else
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2 '1.41421356237
                    RNN = RNN + 3
                End If
                Arena.PaintPicture DroneDiagonally(RNN), shot(shotcounter).ShotX - 2, shot(shotcounter).ShotY - 2
            End If
''            end paint and move
'Checks hit
            For tempnumber = 1 To NumberOfRobotsPresent
                If (shot(shotcounter).ShotX - RobotLeft(tempnumber)) * (shot(shotcounter).ShotX - RobotLeft(tempnumber)) + (shot(shotcounter).ShotY - RobotTop(tempnumber)) * (shot(shotcounter).ShotY - RobotTop(tempnumber)) < 100 Then
                    shot(shotcounter).ShotType = SHOTHIT
                    Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                    shot(shotcounter).ShotAngle = tempnumber     'Which robot is hit?
                    'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
                    LastHiter(tempnumber) = shot(shotcounter).Shooter
                End If
            Next tempnumber
        Else
            shot(shotcounter).ShotType = NOSHOT    'destroy drone
        End If
dontrundronecode:
    Case Laser      'shot(ShotCounter).ShotAngle = bot som beskjuts
        NotAnyShotsAtAll = False
        shot(shotcounter).ShotType = SHOTHIT
        'Arena.Line (TurretX2(shot(ShotCounter).Shooter), TurretY2(shot(ShotCounter).Shooter))-(shot(ShotCounter).ShotX, shot(ShotCounter).ShotY), vbBlue
        Arena.Line (RobotLeft(shot(shotcounter).Shooter) + Sin10(shot(shotcounter).ShotFireTime), RobotTop(shot(shotcounter).Shooter) - Cos10(shot(shotcounter).ShotFireTime))-(shot(shotcounter).ShotX, shot(shotcounter).ShotY), vbBlue
        Arena.FillColor = vbBlue: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbBlue
        LastHiter(shot(shotcounter).ShotAngle) = shot(shotcounter).Shooter
        
    Case SHOTHIT    'ShotHit
        If shot(shotcounter).ShotAngle < 100 Then    'Regular
            Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
            RShield(shot(shotcounter).ShotAngle) = RShield(shot(shotcounter).ShotAngle) - shot(shotcounter).ShotPower
            If RShield(shot(shotcounter).ShotAngle) < 0 Then 'If Shield still is above 0 the shot only hit the shield
                RDamage(shot(shotcounter).ShotAngle) = RDamage(shot(shotcounter).ShotAngle) + RShield(shot(shotcounter).ShotAngle)
                RShield(shot(shotcounter).ShotAngle) = 0
                DR(shot(shotcounter).ShotAngle) = RDamage(shot(shotcounter).ShotAngle) ': DR(1).Refresh
                If PlaySounds Then
                    If RobotHitSound(shot(shotcounter).ShotAngle) Then PlaySnd3 (shot(shotcounter).ShotAngle) Else sndPlaySound hitsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
                End If
                If RobotHitIcon(shot(shotcounter).ShotAngle) Then   'Skall EJ vara <= 100!
                    If RobotIconNumber(shot(shotcounter).ShotAngle) < 100 Then RobotIconNumber(shot(shotcounter).ShotAngle) = RobotIconNumber(shot(shotcounter).ShotAngle) + 100
                    Set Robot_(shot(shotcounter).ShotAngle) = RobotMasterIcon(shot(shotcounter).ShotAngle * 10 + 5)
                End If
            Else    'Blocked shot with shield
                If PlaySounds Then
                    If RobotBlockSound(shot(shotcounter).ShotAngle) Then PlaySnd2 (shot(shotcounter).ShotAngle) Else sndPlaySound hitsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
                End If
                If RobotBlockIcon(shot(shotcounter).ShotAngle) Then
                    If RobotIconNumber(shot(shotcounter).ShotAngle) < 100 Then RobotIconNumber(shot(shotcounter).ShotAngle) = RobotIconNumber(shot(shotcounter).ShotAngle) + 100
                    Set Robot_(shot(shotcounter).ShotAngle) = RobotMasterIcon(shot(shotcounter).ShotAngle * 10 + 4)
                End If
            End If
        ElseIf shot(shotcounter).ShotAngle < 1000 Then   'Stunner
            RNN = shot(shotcounter).ShotAngle \ 100
            Arena.FillColor = vbGreen: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbGreen
            If PlaySounds Then
                If RobotHitSound(RNN) Then PlaySnd3 (RNN) Else sndPlaySound hitsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
            End If
            If RobotHitIcon(RNN) Then
                If RobotIconNumber(RNN) < 100 Then RobotIconNumber(RNN) = RobotIconNumber(RNN) + 100
                Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 5)
            End If
            RStunned(RNN) = RStunned(RNN) + shot(shotcounter).ShotPower
        Else    'Hellbore   'Since Hellbore practically are only shooted with other shots, they don't have to make sound OR Red/Green Spots
            RNN = shot(shotcounter).ShotAngle \ 1000
            If RobotHitIcon(RNN) Then
                If RobotIconNumber(RNN) < 100 Then RobotIconNumber(RNN) = RobotIconNumber(RNN) + 100
                Set Robot_(RNN) = RobotMasterIcon(RNN * 10 + 5)
            End If
            RShield(RNN) = 0
        End If
        shot(shotcounter).ShotType = NOSHOT

    Case Else
        NotAnyShotsAtAll = False
        trigx = Sin12(shot(shotcounter).ShotAngle)
        trigy = Cos12(shot(shotcounter).ShotAngle)

        shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy

        trigy = trigy + shot(shotcounter).ShotY
        trigx = shot(shotcounter).ShotX - trigx

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then
                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
'                    Shot(ShotCounter).ShotType = TakeNuke      'Old fashion Explosive Bullets
'                    GoTo OldStyleExplosiveBullets                      'Do not erase
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If
                shot(shotcounter).ShotType = SHOTHIT
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 1     'Which robot is hit?
                LastHiter(1) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then
                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If
                shot(shotcounter).ShotType = SHOTHIT
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 2     'Which robot is hit?
                LastHiter(2) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then
                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If
                shot(shotcounter).ShotType = SHOTHIT
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 3     'Which robot is hit?
                LastHiter(3) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then
                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If
                shot(shotcounter).ShotType = SHOTHIT
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 4     'Which robot is hit?
                LastHiter(4) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then
                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If
                shot(shotcounter).ShotType = SHOTHIT
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 5     'Which robot is hit?
                LastHiter(5) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then
                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If
                shot(shotcounter).ShotType = SHOTHIT
                Arena.FillColor = vbRed: Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, vbRed
                shot(shotcounter).ShotAngle = 6     'Which robot is hit?
                LastHiter(6) = shot(shotcounter).Shooter
            Else
                Arena.FillColor = vbBlack      'Creates new shotprojection
                Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 2, vbBlack
            End If
        End If
    End Select
Next shotcounter

If NotAnyShotsAtAll Then
    ShotNumber = 0
    FreeShot = -1
End If

'Checks if the robots have any damage left and paint the robots
'Kollar om robotarna har dött av skada samt ritar robotar och aim
For RNN = 1 To NumberOfRobotsPresent
    If RobotAlive(RNN) = 1 Then
        If RDamage(RNN) >= 1 Then
            Arena.PaintPicture Robot_(RNN), RobotLeft(RNN) - 16, RobotTop(RNN) - 16
            If RobotTurretType(RNN) = 1 Then
                Arena.Line (RobotLeft(RNN), RobotTop(RNN))-(TurretX2(RNN), TurretY2(RNN)), vbBlack
            ElseIf RobotTurretType(RNN) = 2 Then
                Arena.Circle (TurretX2(RNN), TurretY2(RNN)), 1, vbBlack
            End If
        Else
            RobotAlive(RNN) = 255
        End If
    End If
Next RNN

'Dödar döda robotar - Kills off dead robots
For RNN = 1 To NumberOfRobotsPresent
If RobotAlive(RNN) > 230 Then
    If RobotAlive(RNN) <> 255 Then
        If RobotAlive(RNN) > 237 Then DeathAnimation RNN, RobotAlive(RNN)
        If RobotAlive(RNN) = 231 Then RobotAlive(RNN) = 1  '1 - 1 = 0 see code below
    Else 'RobotAlive(RNN) <> 255 Then
        DeathAnimationInitz RNN, RobotIconNumber(RNN)
        RobotLeft(RNN) = -50
        RobotTop(RNN) = 150
        EnergyDisplay(RNN).Visible = False

        If REnergy(RNN) < -200 And EnableOverloading Then    'BUG ALERT!! BUG ALERT!! Skillnad i overloading mot den jävla Mac versionen: dels så sker skälva "döden" 1 chronon senare i
            RobotDead(RNN) = "Overloaded - Time: " & Chronon
            tempnumber = -2 '3 * CInt(Not StandardScoring)
            LastHiter(RNN) = 253
        ElseIf RScan(RNN) = 9999 Then
            RobotDead(RNN) = "Buggy - Time: " & Chronon
            tempnumber = -1 '2 * CInt(Not StandardScoring)
            LastHiter(RNN) = 254
        Else
            RobotDead(RNN) = "Dead - Time: " & Chronon              'Windows (vet inte om det har nån betydelse?), dels så slutar striden inte mindre än 2 chronon senare senare i Windows (om Mac scoring används)
            If (RCollision(RNN) = 0 Or RDamage(RNN) + 1 <= 0) And (RWall(RNN) = 0 Or RDamage(RNN) + 5 <= 0) And LastHiter(RNN) <> RNN And RLook(LastHiter(RNN)) <> 9999 And (RobotTeam(RNN) = 0 Or (RobotTeam(RNN) <> RobotTeam(LastHiter(RNN)))) Then
                KR(LastHiter(RNN)) = KR(LastHiter(RNN)) + 1 'Also prevents robots from getting kill score for killing itself
            Else
                LastHiter(RNN) = 255     'Records that the robot died from a Wall Collision, Collision or suicided (for 4.5.2)
            End If
            tempnumber = 0 'CInt(Not StandardScoring)
        End If
        
        RobotDead(RNN).Visible = True
        
        HowManyLeft = HowManyLeft - 1

        'Robots Int
        For shotcounter = 1 To NumberOfRobotsPresent
            If RobotsInst(shotcounter) >= 0 And HowManyLeft < RobotsParam(shotcounter) Then
                 RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
                 RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = RobotsInst(shotcounter)
                 IntID(shotcounter, RobotQuePos(shotcounter)) = 9
            End If
        Next shotcounter

        'Teammates Int
        RRadar = 0                                       'Calculates how many teammates there is left
        For shotcounter = 1 To NumberOfRobotsPresent    'If a robot is in the same team that the robot who just died + it's alive it's a living teammate
            If RobotTeam(shotcounter) = RobotTeam(RNN) And RobotAlive(shotcounter) = 1 Then RRadar = RRadar + 1
        Next shotcounter

        For shotcounter = 1 To NumberOfRobotsPresent
            If RobotTeam(shotcounter) = RobotTeam(RNN) Then     'If they're not in the same team we can ignore the teammates int
                If TeammatesInst(shotcounter) >= 0 Then         'If it uses the teammates inst
                    If RRadar <= TeammatesParam(shotcounter) Then    'If the teammates in the team no is below teammatesparam
                        RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
                        RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = TeammatesInst(shotcounter)
                        IntID(shotcounter, RobotQuePos(shotcounter)) = 10
                    End If
                End If
            End If
        Next shotcounter
        
        If RRadar = 0 Then HowManyLeft = 0
        
        'End Team Stuff

        If HowManyLeft <= 1 Then
            MaxChronon = Chronon + 20 - tempnumber * (Not StandardScoring)    'MaxChronon = Chronon + 21 + CInt(StandardScoring) + TempNumber
            HowManyLeft = 255   'If the solitare robot should die we prevent the battle from going on an additional 20 chronons this way
        End If

        REnergy(RNN) = -10    'To prevent false dopplering
    End If
    RobotAlive(RNN) = RobotAlive(RNN) - 1
End If

RCollision(RNN) = 0  'Resets collision to zero before the collision loop
Next RNN
    
    Chronon = Chronon + 1
    NumerOfCrononsDisplay.Cls: NumerOfCrononsDisplay.Print Chronon
    DoEvents

    If BattleSpeed <> 1E-37 Then    'Hastighetsbegränsaren - Speed Limiter
        Do While Timer - fStart < BattleSpeed
            If BattleHaltButton.Caption = "Battle" Then GoTo Peace 'Added this line as fix for the slowest battlespeed halt pressed bug.
                                                                 'I've allways HATED that bug
            DoEvents
        Loop
    End If
    Do While Draging <> 0   'Pauses the battle if the user is dragging around a robot
        DoEvents
    Loop
Loop
'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*

' Striden avslutas
Peace:
    For RNN = 1 To NumberOfRobotsPresent    'Just so ER should correspond to energydisplay
        ER(RNN) = REnergy(RNN)      'so the player can see how much energy robot had when battle ended

        If Not Replaying Then
            BackupHistory (RNN)
            HistoryRec(RNN, 9) = RDamage(RNN) * (RobotAlive(RNN) = 1)
        End If
    Next RNN
    
    KillPoints LastHiter, RobotAlive
    RewardPoints RobotAlive(1), RobotAlive(2), RobotAlive(3), RobotAlive(4), RobotAlive(5), RobotAlive(6)
    EndBattle
End Sub

Private Sub backupcustom()
Dim counter As Long
Dim robotcounter As Long

For robotcounter = 1 To NumberOfRobotsPresent
    For counter = 31 To 50
        BackupHistoryRec(robotcounter, counter) = HistoryRec(robotcounter, counter)
    Next counter
Next robotcounter
End Sub

Private Sub resetcustom()
Dim counter As Long
Dim robotcounter As Long

For robotcounter = 1 To NumberOfRobotsPresent
    For counter = 31 To 50
        HistoryRec(robotcounter, counter) = BackupHistoryRec(robotcounter, counter)
    Next counter
Next robotcounter
End Sub

Private Sub BackupHistory(HRN As Long)
Dim counter As Long

For counter = 1 To 30
    BackupHistoryRec(HRN, counter) = HistoryRec(HRN, counter)
Next counter

End Sub

Private Sub KillPoints(killer() As Long, RAlive() As Long)
Dim c As Long
Dim DeathTimeString As String
Dim DeathTime(1 To 6) As Long

For c = 1 To NumberOfRobotsPresent
    If RAlive(c) <> 1 Then
        DeathTimeString = Replace(RobotDead(c), "Dead - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
        DeathTime(c) = Val(DeathTimeString)
        If killer(c) > 200 Then DeathTime(c) = DeathTime(c) + (255 - killer(c)) * CInt(Not StandardScoring)    'Mac offset, to gain perfect compatibility
    Else
        DeathTime(c) = 32767
    End If
Next c

' Killer = 253 means that the robot overloaded
' Killer = 254 means that the robot died from a bug
' Killer = 255 means that the robot suicided, died from a collision or wall collision
' Hence no kill points should be substracted since none was rewarded
' We also have to check if the killer died from overloading, since then it should only get points for kills prior it it's death

' DeathTime = 32767 means that the robots still alive.
' It totally doesn't makes sense to reward anyone kill points for a robot thats still alive ;)

If StandardScoring Then        'Win Scoring
    For c = 1 To NumberOfRobotsPresent
        If killer(c) < 7 And DeathTime(c) <> 32767 Then
            If killer(killer(c)) <> 253 Then 'If the bot was not overloaded kills up top 20 chronons after it's death counts
                If DeathTime(killer(c)) - DeathTime(c) < -20 Then KR(killer(c)) = KR(killer(c)) - 1
            Else    'If the bot was overloaded only kills prior to it's death counts
                If DeathTime(killer(c)) < DeathTime(c) Then KR(killer(c)) = KR(killer(c)) - 1
            End If
        End If
    Next c
Else                           'Mac 4.5.2 Scoring
    For c = 1 To NumberOfRobotsPresent
        If killer(c) < 7 And DeathTime(c) <> 32767 Then
            If DeathTime(killer(c)) - DeathTime(c) < 20 Then KR(killer(c)) = KR(killer(c)) - 1
        End If
    Next c
End If

If PrintTournamentLog Then
    For c = 1 To NumberOfRobotsPresent
        TournamentLog(LogWhichBattle).WhosWho(c) = GetRobot(c)
        TournamentLog(LogWhichBattle).killer(c) = killer(c) 'TranslateKiller(Killer(c), RAlive(c))
        TournamentLog(LogWhichBattle).DeathTime(c) = DeathTime(c)
        TournamentLog(LogWhichBattle).Kills(c) = KR(c)
    Next c
End If

End Sub

Private Sub RewardPoints(Robot1Alive As Long, Robot2Alive As Long, Robot3Alive As Long, Robot4Alive As Long, Robot5Alive As Long, Robot6Alive As Long)
If Replaying Then Exit Sub   'No points for repeated battles
Dim counter As Long
Dim TeamsRunning As Boolean

For counter = 1 To 6
    HistoryRec(counter, 4) = 0
    HistoryRec(counter, 9) = -HistoryRec(counter, 9)    'because CInt(RobotAlive(RNN) = 1) = -1
    If RobotTeam(counter) <> 0 Then TeamsRunning = True
Next counter

If TeamsRunning Then
    Dim DidOverload As Boolean
    Dim d As Long
    Dim RobotAlive(1 To 6) As Long
    
    RobotAlive(1) = Robot1Alive
    RobotAlive(2) = Robot2Alive
    RobotAlive(3) = Robot3Alive
    RobotAlive(4) = Robot4Alive
    RobotAlive(5) = Robot5Alive
    RobotAlive(6) = Robot6Alive

    For d = 1 To 6
        HistoryRec(d, 7) = 0
        For counter = 1 To 6
            If counter <> d And RobotTeam(counter) = RobotTeam(d) And RobotAlive(counter) = 1 Then HistoryRec(d, 7) = HistoryRec(d, 7) + 1
        Next counter
        
        HistoryRec(d, 8) = HistoryRec(d, 8) + HistoryRec(d, 7)
    Next d

    If R6Present Then   'Modern Trinity Teams
        For counter = 1 To 3
            If InStr(RobotDead(counter), "Overloaded") <> 0 Then DidOverload = True
        Next
        If Not DidOverload Then
            If Robot1Alive = 1 Xor Robot4Alive = 1 Then HistoryRec(1, 4) = -9 * (Robot1Alive = 1)
            HistoryRec(1, 4) = HistoryRec(1, 4) - (Robot1Alive = 1)
            HistoryRec(2, 4) = -(Robot2Alive = 1)
            HistoryRec(3, 4) = -(Robot3Alive = 1)
        End If
            
        For counter = 4 To 6
            If InStr(RobotDead(counter), "Overloaded") <> 0 Then DidOverload = True
        Next
        If Not DidOverload Then
            If Robot1Alive = 1 Xor Robot4Alive = 1 Then HistoryRec(4, 4) = -9 * (Robot4Alive = 1)
            HistoryRec(4, 4) = HistoryRec(4, 4) - (Robot4Alive = 1)
            HistoryRec(5, 4) = -(Robot5Alive = 1)
            HistoryRec(6, 4) = -(Robot6Alive = 1)
        End If
    Else    'Classic Teams
        For counter = 1 To 2
            If InStr(RobotDead(counter), "Overloaded") <> 0 Then DidOverload = True
        Next
        If Not DidOverload Then
            HistoryRec(1, 4) = -(Robot1Alive = 1)
            HistoryRec(2, 4) = -(Robot2Alive = 1)
        End If
        For counter = 3 To 4
            If InStr(RobotDead(counter), "Overloaded") <> 0 Then DidOverload = True
        Next
        If Not DidOverload Then
            HistoryRec(3, 4) = -(Robot3Alive = 1)
            HistoryRec(4, 4) = -(Robot4Alive = 1)
        End If
    End If
    
    PR1 = PR1 + HistoryRec(1, 4)
    PR2 = PR2 + HistoryRec(2, 4)
    PR3 = PR3 + HistoryRec(3, 4)
    PR4 = PR4 + HistoryRec(4, 4)
    PR5 = PR5 + HistoryRec(5, 4)
    PR6 = PR6 + HistoryRec(6, 4)
ElseIf Not R3Present Then                 'Duel
        PR1 = PR1 - (Robot1Alive = 1)
        HistoryRec(1, 4) = -(Robot1Alive = 1)
        PR2 = PR2 - (Robot2Alive = 1)
        HistoryRec(2, 4) = -(Robot2Alive = 1)
ElseIf R6Present Then                                   'Grouprounds
'    If (Robot1Alive = 1) + (Robot2Alive = 1) + (Robot3Alive = 1) + (Robot4Alive = 1) + (Robot5Alive = 1) + (Robot6Alive = 1) >= -3 Then
    Dim DeathTimeString As String
    Dim DeathTime(1 To 6) As Long
    If Robot1Alive <> 1 Then
        DeathTimeString = Replace(RobotDead(1), "Dead - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
        DeathTime(1) = Val(DeathTimeString)
    Else
        DeathTime(1) = 32767
    End If

    If Robot2Alive <> 1 Then
        DeathTimeString = Replace(RobotDead(2), "Dead - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
        DeathTime(2) = Val(DeathTimeString)
    Else
        DeathTime(2) = 32767
    End If

    If Robot3Alive <> 1 Then
        DeathTimeString = Replace(RobotDead(3), "Dead - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
        DeathTime(3) = Val(DeathTimeString)
    Else
        DeathTime(3) = 32767
    End If

    If Robot4Alive <> 1 Then
        DeathTimeString = Replace(RobotDead(4), "Dead - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
        DeathTime(4) = Val(DeathTimeString)
    Else
        DeathTime(4) = 32767
    End If

    If Robot5Alive <> 1 Then
        DeathTimeString = Replace(RobotDead(5), "Dead - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
        DeathTime(5) = Val(DeathTimeString)
    Else
        DeathTime(5) = 32767
    End If

    If Robot6Alive <> 1 Then
        DeathTimeString = Replace(RobotDead(6), "Dead - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
        DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
        DeathTime(6) = Val(DeathTimeString)
    Else
        DeathTime(6) = 32767
    End If

    Dim MaxDeathTime As Long
    Dim TieFlag As Long
    Dim c As Long
    
    MaxDeathTime = Max(DeathTime(1), DeathTime(2)): MaxDeathTime = Max(MaxDeathTime, DeathTime(3)): MaxDeathTime = Max(MaxDeathTime, DeathTime(4)): MaxDeathTime = Max(MaxDeathTime, DeathTime(5)): MaxDeathTime = Max(MaxDeathTime, DeathTime(6))
    TieFlag = -(1 + CInt(MaxDeathTime = DeathTime(1)) + CInt(MaxDeathTime = DeathTime(2)) + CInt(MaxDeathTime = DeathTime(3)) + CInt(MaxDeathTime = DeathTime(4)) + CInt(MaxDeathTime = DeathTime(5)) + CInt(MaxDeathTime = DeathTime(6)))
    
    For c = 1 To 6
        If DeathTime(c) = MaxDeathTime Then
            HistoryRec(c, 4) = 3
            DeathTime(c) = -3
        End If
    Next c

    'Check how many bots that ties
    MaxDeathTime = Max(DeathTime(1), DeathTime(2)): MaxDeathTime = Max(MaxDeathTime, DeathTime(3)): MaxDeathTime = Max(MaxDeathTime, DeathTime(4)): MaxDeathTime = Max(MaxDeathTime, DeathTime(5)): MaxDeathTime = Max(MaxDeathTime, DeathTime(6))
    
    If MaxDeathTime <> -3 Then
        TieFlag = TieFlag - (1 + CInt(MaxDeathTime = DeathTime(1)) + CInt(MaxDeathTime = DeathTime(2)) + CInt(MaxDeathTime = DeathTime(3)) + CInt(MaxDeathTime = DeathTime(4)) + CInt(MaxDeathTime = DeathTime(5)) + CInt(MaxDeathTime = DeathTime(6)))
        'Reward 2nd if there is any
        For c = 1 To 6
            If DeathTime(c) = MaxDeathTime Then
                HistoryRec(c, 4) = ZeroOrMore(2 - TieFlag)
                DeathTime(c) = -2
            End If
        Next c
    
        'Check how many bots that ties again
        MaxDeathTime = Max(DeathTime(1), DeathTime(2)): MaxDeathTime = Max(MaxDeathTime, DeathTime(3)): MaxDeathTime = Max(MaxDeathTime, DeathTime(4)): MaxDeathTime = Max(MaxDeathTime, DeathTime(5)): MaxDeathTime = Max(MaxDeathTime, DeathTime(6))
        TieFlag = TieFlag - (1 + CInt(MaxDeathTime = DeathTime(1)) + CInt(MaxDeathTime = DeathTime(2)) + CInt(MaxDeathTime = DeathTime(3)) + CInt(MaxDeathTime = DeathTime(4)) + CInt(MaxDeathTime = DeathTime(5)) + CInt(MaxDeathTime = DeathTime(6)))
    
        'Reward 3rd if there is any
        For c = 1 To 6
            If DeathTime(c) = MaxDeathTime Then
                HistoryRec(c, 4) = ZeroOrMore(1 - TieFlag)
            End If
        Next c
    End If
    
    PR1 = PR1 + HistoryRec(1, 4)
    PR2 = PR2 + HistoryRec(2, 4)
    PR3 = PR3 + HistoryRec(3, 4)
    PR4 = PR4 + HistoryRec(4, 4)
    PR5 = PR5 + HistoryRec(5, 4)
    PR6 = PR6 + HistoryRec(6, 4)
'    End If
Else
    PR1 = PR1 - (Robot1Alive = 1)
    PR2 = PR2 - (Robot2Alive = 1)
    PR3 = PR3 - (Robot3Alive = 1)
    PR4 = PR4 - (Robot4Alive = 1)
    PR5 = PR5 - (Robot5Alive = 1)
    PR6 = PR6 - (Robot6Alive = 1)
    
    HistoryRec(1, 4) = -(Robot1Alive = 1)
    HistoryRec(2, 4) = -(Robot2Alive = 1)
    HistoryRec(3, 4) = -(Robot3Alive = 1)
    HistoryRec(4, 4) = -(Robot4Alive = 1)
    HistoryRec(5, 4) = -(Robot5Alive = 1)
    HistoryRec(6, 4) = -(Robot6Alive = 1)
End If

'Record history - All but damage
'PR1 = Val(PR1) + Val(KR(1))

PR1 = PR1 + KR(1)
PR2 = PR2 + KR(2)
PR3 = PR3 + KR(3)
PR4 = PR4 + KR(4)
PR5 = PR5 + KR(5)
PR6 = PR6 + KR(6)

For counter = 1 To 6
    HistoryRec(counter, 1) = HistoryRec(counter, 1) + 1
    HistoryRec(counter, 2) = KR(counter)
    HistoryRec(counter, 3) = HistoryRec(counter, 3) + HistoryRec(counter, 2)
    HistoryRec(counter, 5) = HistoryRec(counter, 5) + HistoryRec(counter, 4)
    HistoryRec(counter, 6) = -(NumberOfRobotsPresent = -((Robot1Alive = 1) + (Robot2Alive = 1) + (Robot3Alive = 1) + (Robot4Alive = 1) + (Robot5Alive = 1) + (Robot6Alive = 1)))
    '9 exists but is not recorded here
    HistoryRec(counter, 10) = Chronon
    HistoryRec(counter, 11) = HistoryRec(counter, 11) + Chronon
Next counter

If PrintTournamentLog Then
    For counter = 1 To NumberOfRobotsPresent
        TournamentLog(LogWhichBattle).SurvivalPoints(counter) = HistoryRec(counter, 4)
    Next counter
    
    LogWhichBattle = LogWhichBattle + 1
End If

End Sub

Private Sub EndBattle()

If Not RunningTournament Then
    If R1Present Then ER(1).Visible = True
    If R2Present Then ER(2).Visible = True
    If R3Present Then ER(3).Visible = True
    If R4Present Then ER(4).Visible = True
    If R5Present Then ER(5).Visible = True
    If R6Present Then ER(6).Visible = True
    EnergyDisplay(1).Visible = False 'Turns of the much faster EnergyDisplay in favor for the  more stable ER
    EnergyDisplay(2).Visible = False
    EnergyDisplay(3).Visible = False
    EnergyDisplay(4).Visible = False
    EnergyDisplay(5).Visible = False
    EnergyDisplay(6).Visible = False

    If DebuggedRobot <> 0 And DebuggerAutoStart Then
        Unload DebuggingWindow  'ej disk!!
        TurnOfTheDebugger
    End If
    
    FileMenu.Enabled = True
    ArenaMenu.Enabled = True
    ViewMenu.Enabled = True
    BattleHaltButton.Enabled = True
    BattleHaltButton.SetFocus
    NotRandomEmergency = True
End If
        
BattleHaltButton.Caption = "Battle"
CPRTimer.Enabled = False

'CleanUpAllDeathIcons
    
End Sub

Private Sub EndBattleWhenGotoInst()
'If Not RunningTournament Then
    If R1Present Then ER(1).Visible = True
    If R2Present Then ER(2).Visible = True
    If R3Present Then ER(3).Visible = True
    If R4Present Then ER(4).Visible = True
    If R5Present Then ER(5).Visible = True
    If R6Present Then ER(6).Visible = True
    EnergyDisplay(1).Visible = False 'Turns of the much faster EnergyDisplay in favor for the  more stable ER
    EnergyDisplay(2).Visible = False
    EnergyDisplay(3).Visible = False
    EnergyDisplay(4).Visible = False
    EnergyDisplay(5).Visible = False
    EnergyDisplay(6).Visible = False
    
    If DebuggedRobot <> 0 And DebuggerAutoStart Then
        Unload DebuggingWindow  'ej disk!!
        TurnOfTheDebugger
    End If
    
    FileMenu.Enabled = True
    ArenaMenu.Enabled = True
    ViewMenu.Enabled = True
    BattleHaltButton.Enabled = True
'End If
        
BattleHaltButton.Caption = "Battle"
CPRTimer.Enabled = False
'CleanUpAllDeathIcons
    
Dim sDup As String

Select Case SelectedRobot
    Case 1
        Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
        sDup = R1path
    Case 2
        Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = vbBlack: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
        sDup = R2path
    Case 3
        Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = vbBlack: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
        sDup = R3path
    Case 4
        Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = vbBlack: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
        sDup = R4path
    Case 5
        Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = vbBlack: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
        sDup = R5path
    Case 6
        Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = vbBlack: Robot6.ForeColor = vbWhite
        sDup = R6path
End Select

If R1path = sDup Then RefreshCode R1path, 1
If R2path = sDup Then RefreshCode R2path, 2
If R3path = sDup Then RefreshCode R3path, 3
If R4path = sDup Then RefreshCode R4path, 4
If R5path = sDup Then RefreshCode R5path, 5
If R6path = sDup Then RefreshCode R6path, 6
End Sub

Private Sub InizBattle()

If ChronorsLimit.Checked Then MaxChronon = 1500 Else MaxChronon = -1   'Nödvändig
NumberOfRobotsPresent = -(CInt(R2Present) + CInt(R3Present) + CInt(R4Present) + CInt(R5Present) + CInt(R6Present) - 1) 'Moved here because MasterIconHandler needs it nowdays

Chronon = 0

BattleHaltButton.Caption = "Halt"
FileMenu.Enabled = False
ArenaMenu.Enabled = False
ViewMenu.Enabled = False

KR(1) = 0: KR(2) = 0: KR(3) = 0: KR(4) = 0: KR(5) = 0: KR(6) = 0    'ny
If R2Present Then   'This conditional sets the evaluation order to the opposite of the order in the last battle
    If Not Replaying Then HighestToLowest = Not HighestToLowest  'unless repeat battle is checked
Else                            'or we only have one robot. False => 1 to 6, True => 6 to 1
    HighestToLowest = False     'If there's only one robot is doesn't
End If                          'mater, and standard will probably be faser.

If Not RunningTournament Then
    If Replaying Then
        resetcustom
    Else
        backupcustom
        ReDim RandomRegister(0)
    End If
End If

'FixRobot1   'Moved here because of the 64K limit
PlaceRobot (1)
PlaceRobotTurret (1)

RobotDead(1).Visible = False    's
RobotDead(2).Visible = False
RobotDead(3).Visible = False
RobotDead(4).Visible = False
RobotDead(5).Visible = False
RobotDead(6).Visible = False
DoEvents                    's

If Not HideBattle Then
    ER(1).Visible = False       'Turns of the more stable ER in favor for the much faster EnergyDisplay
    ER(2).Visible = False       's
    ER(3).Visible = False
    ER(4).Visible = False
    ER(5).Visible = False
    ER(6).Visible = False
    'DoEvents                    's
    MasterIconHandler           's
    CprTimerCount = 0           's

    Arena.Cls       's
    CPRTimer.Enabled = True     's
    EnergyDisplay(1).Visible = True     's
    DoEvents        'Fixes Dark Knight cosmetic bug     's
    
    Set Robot_(1) = R1Icon '.picture        's
    
    DR(1) = Robot1Damage        's
    EnergyDisplay(1).Cls        's
    EnergyDisplay(1).Print Robot1Energy     's
    
    'Seticonsettings
    RobotShieldIcon(1) = Robot1ShieldIcon
    RobotHitIcon(1) = Robot1HitIcon
    RobotBlockIcon(1) = Robot1BlockIcon
    RobotDeathIcon(1) = Robot1DeathIcon
    RobotCollisionIcon(1) = Robot1CollisionIcon
    
    If StartDebuggerAt <> DEBUGATNOTSET Then BattleSpeed = 1E-37
End If

End Sub

Private Sub PlaceRobot(RNr As Long)
    If Not Replaying Or LastStartPosX(RNr) = 0 Then
        RobotLeft(RNr) = Round(270 * Rnd) + 15 'Int
        RobotTop(RNr) = Round(270 * Rnd) + 15  'Int
        LastStartPosX(RNr) = RobotLeft(RNr)
        LastStartPosY(RNr) = RobotTop(RNr)
    Else
        RobotLeft(RNr) = LastStartPosX(RNr)
        RobotTop(RNr) = LastStartPosY(RNr)
    End If
End Sub

Private Sub PlaceRobotTurret(RNr As Long)
        TurretX2(RNr) = RobotLeft(RNr) + 10
        TurretY2(RNr) = RobotTop(RNr)
End Sub

Private Sub MasterPlace2()
Replace2:
            PlaceRobot (2)
'Kollar om robotarna är för nära varandra
' Robot 1 and Robot 2
        If DistBwtn(RobotLeft(1), RobotTop(1), RobotLeft(2), RobotTop(2)) <= 40 Then GoTo Replace2
        PlaceRobotTurret (2)

If Not HideBattle Then
        EnergyDisplay(2).Visible = True
        DoEvents        'Fixes Dark Knight cosmetic bug
        Set Robot_(2) = R2Icon '.picture
        'ER(2) = Robot2Energy
        DR(2) = Robot2Damage
        EnergyDisplay(2).Cls
        EnergyDisplay(2).Print Robot2Energy

        RobotShieldIcon(2) = Robot2ShieldIcon
        RobotHitIcon(2) = Robot2HitIcon
        RobotBlockIcon(2) = Robot2BlockIcon
        RobotDeathIcon(2) = Robot2DeathIcon
        RobotCollisionIcon(2) = Robot2CollisionIcon
End If

End Sub
Private Sub MasterPlace3()
Replace3:
        PlaceRobot (3)
'Kollar om robotarna är för nära varandra - Checks if the robots are to close to each other
' Robot 1 and Robot 3
        If DistBwtn(RobotLeft(1), RobotTop(1), RobotLeft(3), RobotTop(3)) <= 40 Then GoTo Replace3
' Robot 2 and Robot 3
        If DistBwtn(RobotLeft(2), RobotTop(2), RobotLeft(3), RobotTop(3)) <= 40 Then GoTo Replace3
        PlaceRobotTurret (3)
        
If Not HideBattle Then
        EnergyDisplay(3).Visible = True
        DoEvents        'Fixes Dark Knight cosmetic bug
        Set Robot_(3) = R3Icon '.picture
        'ER(3) = Robot3Energy
        DR(3) = Robot3Damage
        EnergyDisplay(3).Cls
        EnergyDisplay(3).Print Robot3Energy
        
        RobotShieldIcon(3) = Robot3ShieldIcon
        RobotHitIcon(3) = Robot3HitIcon
        RobotBlockIcon(3) = Robot3BlockIcon
        RobotDeathIcon(3) = Robot3DeathIcon
        RobotCollisionIcon(3) = Robot3CollisionIcon
End If

End Sub

Private Sub MasterPlace4()
Replace4:
        PlaceRobot (4)
' Robot 1 and Robot 4
        If DistBwtn(RobotLeft(1), RobotTop(1), RobotLeft(4), RobotTop(4)) <= 40 Then GoTo Replace4
' Robot 2 and Robot 4
        If DistBwtn(RobotLeft(2), RobotTop(2), RobotLeft(4), RobotTop(4)) <= 40 Then GoTo Replace4
' Robot 3 and Robot 4
        If DistBwtn(RobotLeft(3), RobotTop(3), RobotLeft(4), RobotTop(4)) <= 40 Then GoTo Replace4
        PlaceRobotTurret (4)
        
If Not HideBattle Then
        EnergyDisplay(4).Visible = True
        DoEvents        'Fixes Dark Knight cosmetic bug
        Set Robot_(4) = R4Icon '.picture
        'ER(4) = Robot4Energy
        DR(4) = Robot4Damage
        EnergyDisplay(4).Cls
        EnergyDisplay(4).Print Robot4Energy

        RobotShieldIcon(4) = Robot4ShieldIcon
        RobotHitIcon(4) = Robot4HitIcon
        RobotBlockIcon(4) = Robot4BlockIcon
        RobotDeathIcon(4) = Robot4DeathIcon
        RobotCollisionIcon(4) = Robot4CollisionIcon
End If

End Sub


Private Sub MasterPlace5()
Replace5:
        PlaceRobot (5)
'Kollar om robotarna är för nära varandra
' Robot 1 and Robot 5
        If DistBwtn(RobotLeft(1), RobotTop(1), RobotLeft(5), RobotTop(5)) <= 40 Then GoTo Replace5
' Robot 2 and Robot 5
        If DistBwtn(RobotLeft(2), RobotTop(2), RobotLeft(5), RobotTop(5)) <= 40 Then GoTo Replace5
' Robot 3 and Robot 5
        If DistBwtn(RobotLeft(3), RobotTop(3), RobotLeft(5), RobotTop(5)) <= 40 Then GoTo Replace5
' Robot 4 and Robot 5
        If DistBwtn(RobotLeft(4), RobotTop(4), RobotLeft(5), RobotTop(5)) <= 40 Then GoTo Replace5
        PlaceRobotTurret (5)

If Not HideBattle Then
        EnergyDisplay(5).Visible = True
        DoEvents        'Fixes Dark Knight cosmetic bug
        Set Robot_(5) = R5Icon '.picture
        'ER(5) = Robot5Energy
        DR(5) = Robot5Damage
        EnergyDisplay(5).Cls
        EnergyDisplay(5).Print Robot5Energy

        RobotShieldIcon(5) = Robot5ShieldIcon
        RobotHitIcon(5) = Robot5HitIcon
        RobotBlockIcon(5) = Robot5BlockIcon
        RobotDeathIcon(5) = Robot5DeathIcon
        RobotCollisionIcon(5) = Robot5CollisionIcon
End If

End Sub

Private Sub MasterPlace6()
Replace6:
        PlaceRobot (6)
'Kollar om robotarna är för nära varandra
' Robot 1 and Robot 6
        If DistBwtn(RobotLeft(1), RobotTop(1), RobotLeft(6), RobotTop(6)) <= 40 Then GoTo Replace6
' Robot 2 and Robot 6
        If DistBwtn(RobotLeft(2), RobotTop(2), RobotLeft(6), RobotTop(6)) <= 40 Then GoTo Replace6
' Robot 3 and Robot 6
        If DistBwtn(RobotLeft(3), RobotTop(3), RobotLeft(6), RobotTop(6)) <= 40 Then GoTo Replace6
' Robot 4 and Robot 6
        If DistBwtn(RobotLeft(4), RobotTop(4), RobotLeft(6), RobotTop(6)) <= 40 Then GoTo Replace6
' Robot 5 and Robot 6
        If DistBwtn(RobotLeft(5), RobotTop(5), RobotLeft(6), RobotTop(6)) <= 40 Then GoTo Replace6
        PlaceRobotTurret (6)

If Not HideBattle Then
        EnergyDisplay(6).Visible = True
        DoEvents        'Fixes Dark Knight cosmetic bug
        Set Robot_(6) = R6Icon '.picture
        'ER(6) = Robot6Energy
        DR(6) = Robot6Damage
        EnergyDisplay(6).Cls
        EnergyDisplay(6).Print Robot6Energy

        RobotShieldIcon(6) = Robot6ShieldIcon
        RobotHitIcon(6) = Robot6HitIcon
        RobotBlockIcon(6) = Robot6BlockIcon
        RobotDeathIcon(6) = Robot6DeathIcon
        RobotCollisionIcon(6) = Robot6CollisionIcon
End If

End Sub

Private Function GetRobot(RobotNumberToGet As Long) As String
Select Case RobotNumberToGet
    Case 1
    GetRobot = Robot1
    Case 2
    GetRobot = Robot2
    Case 3
    GetRobot = Robot3
    Case 4
    GetRobot = Robot4
    Case 5
    GetRobot = Robot5
    Case 6
    GetRobot = Robot6
    Case Else
    GetRobot = "-"
End Select

End Function



Private Sub TerminateBattle()
        BattleHaltButton.Caption = "Battle"
        MaxChronon = Chronon + 1
End Sub

Private Sub BattleHaltButton_KeyDown(KeyCode As Integer, Shift As Integer)
Select Case KeyCode

Case vbKeyPageDown
SelectedRobot = SelectedRobot + 1

Case vbKeyPageUp
SelectedRobot = SelectedRobot - 1

Case vbKey1
 Slowest_Click
 Exit Sub
 
Case vbKey2
 Slower_Click
 Exit Sub
 
Case vbKey3
 Slow_Click
 Exit Sub
 
Case vbKey4
 Normal_Click
 Exit Sub
 
Case vbKey5
 Fast_Click
 Exit Sub
 
Case vbKey6
 NoDisplay_Click
 Exit Sub

Case vbKey7
 Ultra_Click
 Exit Sub
 
Case vbKeyNumpad1
    Team1_Click
     Exit Sub
Case vbKeyNumpad2
    Team2_Click
     Exit Sub
Case vbKeyNumpad3
    Team3_Click
     Exit Sub
Case vbKeyNumpad0
    NoTeam_Click
     Exit Sub
Case vbKeyAdd
    AutoSetTeams
    Exit Sub
Case vbKeySubtract
    ClearTeams
     Exit Sub
End Select

Select Case SelectedRobot

Case 1
If R1Present Then
Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
Else
SelectedRobot = 1
End If

Case 2
If R2Present Then
Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = vbBlack: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
Else
Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
SelectedRobot = 1
End If

Case 3
If R3Present Then
Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = vbBlack: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
Else
Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
SelectedRobot = 1
End If

Case 4
If R4Present Then
Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = vbBlack: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
Else
Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
SelectedRobot = 1
End If

Case 5
If R5Present Then
Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = vbBlack: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
Else
Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
SelectedRobot = 1
End If

Case 6
If R6Present Then
Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = vbBlack: Robot6.ForeColor = vbWhite
Else
Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
SelectedRobot = 1
End If

Case 7
Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
SelectedRobot = 1

Case Is < 1
    If R6Present Then
Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = vbBlack: Robot6.ForeColor = vbWhite
    SelectedRobot = 6
    Exit Sub
    End If

    If R5Present Then
Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = vbBlack: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    SelectedRobot = 5
    Exit Sub
    End If
    
    If R4Present Then
Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = vbBlack: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    SelectedRobot = 4
    Exit Sub
    End If
    
    If R3Present Then
Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = vbBlack: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    SelectedRobot = 3
    Exit Sub
    End If
    
    If R2Present Then
Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = vbBlack: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    SelectedRobot = 2
    Exit Sub
    End If
    
    If R1Present Then
Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    SelectedRobot = 1
    Exit Sub
    End If

Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
SelectedRobot = -1
End Select

End Sub

Private Sub ClearTeams()
Dim c As Integer
    For c = 1 To 6
        TeamLabel(c).Visible = False
        RobotTeam(c) = 0
    Next c
End Sub

Private Sub AutoSetTeams()
    Dim c As Integer

    If R6Present Then
        For c = 1 To 3
            RobotTeam(c) = 1
            TeamLabel(c) = "Team 1"
            TeamLabel(c).ForeColor = ColorTeam1 'RGB(200, 241, 18)
            TeamLabel(c).Visible = True
        Next
        For c = 4 To 6
            RobotTeam(c) = 2
            TeamLabel(c) = "Team 2"
            TeamLabel(c).ForeColor = ColorTeam2 'RGB(200, 241, 18)
            TeamLabel(c).Visible = True
        Next
    ElseIf R4Present Then
        For c = 1 To 2
            RobotTeam(c) = 1
            TeamLabel(c) = "Team 1"
            TeamLabel(c).ForeColor = ColorTeam1 'RGB(200, 241, 18)
            TeamLabel(c).Visible = True
        Next
        For c = 3 To 4
            RobotTeam(c) = 2
            TeamLabel(c) = "Team 2"
            TeamLabel(c).ForeColor = ColorTeam2 'RGB(200, 241, 18)
            TeamLabel(c).Visible = True
        Next
    End If
End Sub

Public Sub TurnOfTheDebugger()  'Can be called from debuggingwindow
    If DebuggedRobot <> 0 Then
        Image1(DebuggedRobot).Visible = False
        DebuggedRobot = 0
    End If
    
    If Normal.Checked Then
        Normal_Click
    ElseIf Fast.Checked Then
        Fast_Click
    ElseIf AutoRedrawFast.Checked Then
        AutoRedrawFast_Click
    ElseIf Ultra.Checked Then
        Ultra_Click
    ElseIf Slow.Checked Then
        Slow_Click
    ElseIf Slower.Checked Then
        Slower_Click
    ElseIf Slowest.Checked Then
        Slowest_Click
    End If
    
End Sub

Private Sub SetTabIndex1()      'I hate I hate I hate the 64 K code limit
DebuggingWindow.ChrononStep.TabIndex = 0
DebuggingWindow.Step.TabIndex = 4
End Sub

Private Sub SetTabIndex2()
DebuggingWindow.Step.TabIndex = 0
DebuggingWindow.ChrononStep.TabIndex = 1
End Sub

Private Sub PrintDebuggingInfo(I_RobotInstPos As Long, I_MachineCode As Long, DRobotStackPos As Long, _
MPlus1 As Long, MPlus2 As Long, MPlus3 As Long, MPlus4 As Long, MPlus5 As Long, MPlus6 As Long, _
RobotStack100 As Long, RobotStack99 As Long, RobotStack98 As Long, RobotStack97 As Long, _
D_ChrononExecutor1 As Long, D_RAim As Long, D_RShield As Long, D_RRange, D_RangedRobot As Long, _
D_RRadar, D_RLook As Long, D_RScan As Long, D_RSpeedx As Long, D_RSpeedy As Long, D_REnergy As Long)

BattleSpeed = (1 / 70)  '70 är för normal
Arena.AutoRedraw = True

Dim DebuggingInfo As String

DebuggingInfo = "Debugging " & GetRobot(DebuggedRobot) & vbLf & "Chronon = " & Chronon & vbLf & vbLf & "Instruction No. = " & I_RobotInstPos & vbLf & "Instruction = " & S(I_MachineCode) & vbLf & vbLf

If DRobotStackPos <= 96 Then
    DebuggingInfo = DebuggingInfo & _
    "StackPos" & 6 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus6, 6 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf & _
    "StackPos" & 5 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus5, 5 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf & _
    "StackPos" & 4 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus4, 4 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf & _
    "StackPos" & 3 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus3, 3 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf & _
    "StackPos" & 2 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus2, 2 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf & _
    "StackPos" & 1 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus1, 1 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf
Else
    DebuggingInfo = DebuggingInfo & _
    "StackPos 100 = " & DbTr(RobotStack100, 100, DRobotStackPos) & vbLf & _
    "StackPos 99 = " & DbTr(RobotStack99, 99, DRobotStackPos) & vbLf & _
    "StackPos 98 = " & DbTr(RobotStack98, 98, DRobotStackPos) & vbLf & _
    "StackPos 97 = " & DbTr(RobotStack97, 97, DRobotStackPos) & vbLf & vbLf & vbLf
End If

DebuggingInfo = DebuggingInfo & vbLf & _
"Processor Position = " & D_ChrononExecutor1 & vbLf & vbLf & "Energy " & D_REnergy & vbLf & "Aim " & D_RAim & vbLf & "Shield " & D_RShield & vbLf & _
"Range " & D_RRange & vbLf & "Ranging " & GetRobot(D_RangedRobot) & vbLf & "Radar " & D_RRadar & vbLf & _
"Look " & D_RLook & vbLf & "Scan " & D_RScan & vbLf & "x " & RobotLeft(DebuggedRobot) & vbLf & "y " & RobotTop(DebuggedRobot) & vbLf & _
"Speedx " & D_RSpeedx & vbLf & "Speedy " & D_RSpeedy

EnergyDisplay(DebuggedRobot).Cls
EnergyDisplay(DebuggedRobot).Print D_REnergy

DebuggingWindow.Cls
DebuggingWindow.Print DebuggingInfo
DebuggingWindow.DebugMsg = DebuggingInfo
End Sub

Private Function DbTr(Instruction As Long, currentnr As Long, highestnr As Long) As String
If currentnr > highestnr Then DbTr = "" Else DbTr = S(Instruction)
End Function

Private Sub ReturnMacAdd()
    DebuggingWindow.Show

    DebuggingWindow.DebuggingRes = 5

    Do While DebuggingWindow.DebuggingRes = 5  'Pauses the battle till the user has pressed a button in the debuggingwindow
        If BattleHaltButton.Caption = "Battle" Then DebuggingWindow.DebuggingRes = 3    'or the battle halt button
        DoEvents
    Loop

End Sub

Private Function Min(Compare1 As Long, Compare2 As Long) As Long
If Compare1 > Compare2 Then Min = Compare2 Else Min = Compare1
End Function

Private Function Max(Compare1 As Long, Compare2 As Long) As Long
If Compare1 < Compare2 Then Max = Compare2 Else Max = Compare1
End Function

Private Function ZeroOrMore(MakeToZeroOrMore As Long) As Long
If MakeToZeroOrMore > 0 Then ZeroOrMore = MakeToZeroOrMore 'Else ZeroOrMore = 0
End Function

Private Function CheckHowManyLeft() As Long
If R2Present Then CheckHowManyLeft = NumberOfRobotsPresent Else CheckHowManyLeft = 2
End Function

Private Sub ChangeResolution_Click()
If ResolutionChanged = 1 Then
    ResolutionChanged = 0
    ChangeResolution.Caption = "Change Resolution"
Else
    ResolutionChanged = 1
    ChangeResolution.Caption = "Change Back"
End If

ChangeWindow_640X480 (MainWindow.hdc)
End Sub

Private Sub TransferCode(ToRobot As Long, FromRobot As Long)
Dim c As Long

For c = 0 To 4999
MasterCode(ToRobot, c) = MasterCode(FromRobot, c)
Next c

End Sub

Private Sub Close_Click()
NotRandomEmergency = False

NewRobot.Enabled = True
LoadRobot.Enabled = True
Duplicate.Enabled = True
SaveAs.Enabled = True

Select Case SelectedRobot
    Case 1
        If R2Present = False Then
            R1Present = False
            RobotTeam(1) = 0
            Energy1X.Visible = False
            Damage1X.Visible = False
            Points1X.Visible = False
            Robot1.Caption = "No Robot Selected"
            ER(1).Visible = False
            DR(1).Visible = False
            PR1.Visible = False
            R1Icon.Picture = LoadPicture()
            SelectedRobot = -1
            Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
        Else
            R1path = R2path
            TransferCode 1, 2
            RobotTeam(1) = RobotTeam(2): TeamLabel(1) = TeamLabel(2): TeamLabel(1).ForeColor = TeamLabel(2).ForeColor
            Energy1X.Caption = Energy2X.Caption
            Damage1X.Caption = Damage2X.Caption
            Points1X.Caption = Points2X.Caption
            Robot1.Caption = Robot2.Caption
            ER(1).Caption = ER(2).Caption
            DR(1).Caption = DR(2).Caption
            PR1.Caption = PR2.Caption
            R1Icon.Picture = R2Icon.Picture
            Robot1Energy = Robot2Energy
            Robot1Damage = Robot2Damage
            Robot1Shield = Robot2Shield
            Robot1ProSpeed = Robot2ProSpeed
            Robot1Bullets = Robot2Bullets
            Robot1Probes = Robot2Probes
            Robot1Missiles = Robot2Missiles
            Robot1TacNukes = Robot2TacNukes
            Robot1Hellbores = Robot2Hellbores
            Robot1Drones = Robot2Drones
            Robot1Stunners = Robot2Stunners
            Robot1Mines = Robot2Mines
            Robot1Lasers = Robot2Lasers
            Robot1Turret = Robot2Turret
            Robot1ShieldIcon = Robot2ShieldIcon
            Robot1HitIcon = Robot2HitIcon
            Robot1BlockIcon = Robot2BlockIcon
            Robot1DeathIcon = Robot2DeathIcon
            Robot1CollisionIcon = Robot2CollisionIcon
            'Whoo! Det här blir komplicerat
            If R3Present = False Then
                R2Present = False
                RobotTeam(2) = 0
                RobotLeft(2) = -100
                Energy2X.Visible = False
                Damage2X.Visible = False
                Points2X.Visible = False
                Robot2.Caption = "No Robot Selected"
                ER(2).Visible = False
                DR(2).Visible = False
                PR2.Visible = False
                R2Icon.Picture = LoadPicture()
            Else
                R2path = R3path
                TransferCode 2, 3
                RobotTeam(2) = RobotTeam(3): TeamLabel(2) = TeamLabel(3): TeamLabel(2).ForeColor = TeamLabel(3).ForeColor
                Energy2X.Caption = Energy3X.Caption
                Damage2X.Caption = Damage3X.Caption
                Points2X.Caption = Points3X.Caption
                Robot2.Caption = Robot3.Caption
                ER(2).Caption = ER(3).Caption
                DR(2).Caption = DR(3).Caption
                PR2.Caption = PR3.Caption
                R2Icon.Picture = R3Icon.Picture
                Robot2Energy = Robot3Energy
                Robot2Damage = Robot3Damage
                Robot2Shield = Robot3Shield
                Robot2ProSpeed = Robot3ProSpeed
                Robot2Bullets = Robot3Bullets
                Robot2Probes = Robot3Probes
                Robot2Missiles = Robot3Missiles
                Robot2TacNukes = Robot3TacNukes
                Robot2Hellbores = Robot3Hellbores
                Robot2Drones = Robot3Drones
                Robot2Stunners = Robot3Stunners
                Robot2Mines = Robot3Mines
                Robot2Lasers = Robot3Lasers
                Robot2Turret = Robot3Turret
                Robot2ShieldIcon = Robot3ShieldIcon
                Robot2HitIcon = Robot3HitIcon
                Robot2BlockIcon = Robot3BlockIcon
                Robot2DeathIcon = Robot3DeathIcon
                Robot2CollisionIcon = Robot3CollisionIcon
                If R4Present = False Then
                    R3Present = False
                    RobotTeam(3) = 0
                    RobotLeft(3) = -200
                    Energy3X.Visible = False
                    Damage3X.Visible = False
                    Points3X.Visible = False
                    Robot3.Caption = "No Robot Selected"
                    ER(3).Visible = False
                    DR(3).Visible = False
                    PR3.Visible = False
                    R3Icon.Picture = LoadPicture()
                Else
                    R3path = R4path
                    TransferCode 3, 4
                    RobotTeam(3) = RobotTeam(4): TeamLabel(3) = TeamLabel(4): TeamLabel(3).ForeColor = TeamLabel(4).ForeColor
                    Energy3X.Caption = Energy4X.Caption
                    Damage3X.Caption = Damage4X.Caption
                    Points3X.Caption = Points4X.Caption
                    Robot3.Caption = Robot4.Caption
                    ER(3).Caption = ER(4).Caption
                    DR(3).Caption = DR(4).Caption
                    PR3.Caption = PR4.Caption
                    R3Icon.Picture = R4Icon.Picture
                    Robot3Energy = Robot4Energy
                    Robot3Damage = Robot4Damage
                    Robot3Shield = Robot4Shield
                    Robot3ProSpeed = Robot4ProSpeed
                    Robot3Bullets = Robot4Bullets
                    Robot3Probes = Robot4Probes
                    Robot3Missiles = Robot4Missiles
                    Robot3TacNukes = Robot4TacNukes
                    Robot3Hellbores = Robot4Hellbores
                    Robot3Drones = Robot4Drones
                    Robot3Stunners = Robot4Stunners
                    Robot3Mines = Robot4Mines
                    Robot3Lasers = Robot4Lasers
                    Robot3Turret = Robot4Turret
                    Robot3ShieldIcon = Robot4ShieldIcon
                    Robot3HitIcon = Robot4HitIcon
                    Robot3BlockIcon = Robot4BlockIcon
                    Robot3DeathIcon = Robot4DeathIcon
                    Robot3CollisionIcon = Robot4CollisionIcon
                    If R5Present = False Then
                        R4Present = False
                        RobotTeam(4) = 0
                        RobotLeft(4) = -300
                        Energy4X.Visible = False
                        Damage4X.Visible = False
                        Points4X.Visible = False
                        Robot4.Caption = "No Robot Selected"
                        ER(4).Visible = False
                        DR(4).Visible = False
                        PR4.Visible = False
                        R4Icon.Picture = LoadPicture()
                    Else
                        R4path = R5path
                        TransferCode 4, 5
                        RobotTeam(4) = RobotTeam(5): TeamLabel(4) = TeamLabel(5): TeamLabel(4).ForeColor = TeamLabel(5).ForeColor
                        Energy4X.Caption = Energy5X.Caption
                        Damage4X.Caption = Damage5X.Caption
                        Points4X.Caption = Points5X.Caption
                        Robot4.Caption = Robot5.Caption
                        ER(4).Caption = ER(5).Caption
                        DR(4).Caption = DR(5).Caption
                        PR4.Caption = PR5.Caption
                        R4Icon.Picture = R5Icon.Picture
                        Robot4Energy = Robot5Energy
                        Robot4Damage = Robot5Damage
                        Robot4Shield = Robot5Shield
                        Robot4ProSpeed = Robot5ProSpeed
                        Robot4Bullets = Robot5Bullets
                        Robot4Probes = Robot5Probes
                        Robot4Missiles = Robot5Missiles
                        Robot4TacNukes = Robot5TacNukes
                        Robot4Hellbores = Robot5Hellbores
                        Robot4Drones = Robot5Drones
                        Robot4Stunners = Robot5Stunners
                        Robot4Mines = Robot5Mines
                        Robot4Lasers = Robot5Lasers
                        Robot4Turret = Robot5Turret
                        Robot4ShieldIcon = Robot5ShieldIcon
                        Robot4HitIcon = Robot5HitIcon
                        Robot4BlockIcon = Robot5BlockIcon
                        Robot4DeathIcon = Robot5DeathIcon
                        Robot4CollisionIcon = Robot5CollisionIcon
                        If R6Present = False Then
                            R5Present = False
                            RobotTeam(5) = 0
                            RobotLeft(5) = -400
                            Energy5X.Visible = False
                            Damage5X.Visible = False
                            Points5X.Visible = False
                            Robot5.Caption = "No Robot Selected"
                            ER(5).Visible = False
                            DR(5).Visible = False
                            PR5.Visible = False
                            R5Icon.Picture = LoadPicture()
                        Else
                            R5path = R6path
                            TransferCode 5, 6
                            RobotTeam(5) = RobotTeam(6): TeamLabel(5) = TeamLabel(6): TeamLabel(5).ForeColor = TeamLabel(6).ForeColor
                            Energy5X.Caption = Energy6X.Caption
                            Damage5X.Caption = Damage6X.Caption
                            Points5X.Caption = Points6X.Caption
                            Robot5.Caption = Robot6.Caption
                            ER(5).Caption = ER(6).Caption
                            DR(5).Caption = DR(6).Caption
                            
                            PR5.Caption = PR6.Caption
                            R5Icon.Picture = R6Icon.Picture
                            Robot5Energy = Robot6Energy
                            Robot5Damage = Robot6Damage
                            Robot5Shield = Robot6Shield
                            Robot5ProSpeed = Robot6ProSpeed
                            Robot5Bullets = Robot6Bullets
                            Robot5Probes = Robot6Probes
                            Robot5Missiles = Robot6Missiles
                            Robot5TacNukes = Robot6TacNukes
                            Robot5Hellbores = Robot6Hellbores
                            Robot5Drones = Robot6Drones
                            Robot5Stunners = Robot6Stunners
                            Robot5Mines = Robot6Mines
                            Robot5Lasers = Robot6Lasers
                            Robot5Turret = Robot6Turret
                            Robot5ShieldIcon = Robot6ShieldIcon
                            Robot5HitIcon = Robot6HitIcon
                            Robot5BlockIcon = Robot6BlockIcon
                            Robot5DeathIcon = Robot6DeathIcon
                            Robot5CollisionIcon = Robot6CollisionIcon
                    
                            R6Present = False
                            TeamLabel(6).Visible = False: RobotTeam(6) = 0
                            RobotLeft(6) = -500
                            Energy6X.Visible = False
                            Damage6X.Visible = False
                            Points6X.Visible = False
                            Robot6.Caption = "No Robot Selected"
                            ER(6).Visible = False
                            DR(6).Visible = False
                            
                            PR6.Visible = False
                            R6Icon.Picture = LoadPicture()
                        End If
                    End If
                End If
            End If
        End If
    Case 6
        R6Present = False
        RobotTeam(6) = 0
        RobotLeft(6) = -100
        Energy6X.Visible = False
        Damage6X.Visible = False
        Points6X.Visible = False
        Robot6.Caption = "No Robot Selected"
        ER(6).Visible = False
        
        DR(6).Visible = False
        
        PR6.Visible = False
        R6Icon.Picture = LoadPicture()
        SelectedRobot = 5
        Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = vbBlack: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    Case 5
        If R6Present = False Then
            R5Present = False
            RobotTeam(5) = 0
            RobotLeft(5) = -100
            Energy5X.Visible = False
            Damage5X.Visible = False
            Points5X.Visible = False
            Robot5.Caption = "No Robot Selected"
            ER(5).Visible = False
            DR(5).Visible = False
            PR5.Visible = False
            R5Icon.Picture = LoadPicture()
            SelectedRobot = 4
            Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = vbBlack: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
        Else
            R5path = R6path
            TransferCode 5, 6
            RobotTeam(5) = RobotTeam(6): TeamLabel(5) = TeamLabel(6): TeamLabel(5).ForeColor = TeamLabel(6).ForeColor
            Energy5X.Caption = Energy6X.Caption
            Damage5X.Caption = Damage6X.Caption
            Points5X.Caption = Points6X.Caption
            Robot5.Caption = Robot6.Caption
            ER(5).Caption = ER(6).Caption
            DR(5).Caption = DR(6).Caption
            
            PR5.Caption = PR6.Caption
            R5Icon.Picture = R6Icon.Picture
            Robot5Energy = Robot6Energy
            Robot5Damage = Robot6Damage
            Robot5Shield = Robot6Shield
            Robot5ProSpeed = Robot6ProSpeed
            Robot5Bullets = Robot6Bullets
            Robot5Probes = Robot6Probes
            Robot5Missiles = Robot6Missiles
            Robot5TacNukes = Robot6TacNukes
            Robot5Hellbores = Robot6Hellbores
            Robot5Drones = Robot6Drones
            Robot5Stunners = Robot6Stunners
            Robot5Mines = Robot6Mines
            Robot5Lasers = Robot6Lasers
            Robot5Turret = Robot6Turret
            Robot5ShieldIcon = Robot6ShieldIcon
            Robot5HitIcon = Robot6HitIcon
            Robot5BlockIcon = Robot6BlockIcon
            Robot5DeathIcon = Robot6DeathIcon
            Robot5CollisionIcon = Robot6CollisionIcon
            
            R6Present = False
            RobotTeam(6) = 0
            RobotLeft(6) = -100
            Energy6X.Visible = False
            Damage6X.Visible = False
            Points6X.Visible = False
            Robot6.Caption = "No Robot Selected"
            ER(6).Visible = False
            DR(6).Visible = False
            
            PR6.Visible = False
            R6Icon.Picture = LoadPicture()
        End If
    Case 4
        If R5Present = False Then
            R4Present = False
            RobotTeam(4) = 0
            RobotLeft(4) = -100
            Energy4X.Visible = False
            Damage4X.Visible = False
            Points4X.Visible = False
            Robot4.Caption = "No Robot Selected"
            ER(4).Visible = False
            DR(4).Visible = False
            PR4.Visible = False
            R4Icon.Picture = LoadPicture()
            SelectedRobot = 3
            Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = vbBlack: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
        Else
            R4path = R5path
            TransferCode 4, 5
            RobotTeam(4) = RobotTeam(5): TeamLabel(4) = TeamLabel(5): TeamLabel(4).ForeColor = TeamLabel(5).ForeColor
            Energy4X.Caption = Energy5X.Caption
            Damage4X.Caption = Damage5X.Caption
            Points4X.Caption = Points5X.Caption
            Robot4.Caption = Robot5.Caption
            ER(4).Caption = ER(5).Caption
            DR(4).Caption = DR(5).Caption
            PR4.Caption = PR5.Caption
            R4Icon.Picture = R5Icon.Picture
            Robot4Energy = Robot5Energy
            Robot4Damage = Robot5Damage
            Robot4Shield = Robot5Shield
            Robot4ProSpeed = Robot5ProSpeed
            Robot4Bullets = Robot5Bullets
            Robot4Probes = Robot5Probes
            Robot4Missiles = Robot5Missiles
            Robot4TacNukes = Robot5TacNukes
            Robot4Hellbores = Robot5Hellbores
            Robot4Drones = Robot5Drones
            Robot4Stunners = Robot5Stunners
            Robot4Mines = Robot5Mines
            Robot4Lasers = Robot5Lasers
            Robot4Turret = Robot5Turret
            Robot4ShieldIcon = Robot5ShieldIcon
            Robot4HitIcon = Robot5HitIcon
            Robot4BlockIcon = Robot5BlockIcon
            Robot4DeathIcon = Robot5DeathIcon
            Robot4CollisionIcon = Robot5CollisionIcon
            If R6Present = False Then
                R5Present = False
                RobotTeam(5) = 0
                RobotLeft(5) = -100
                Energy5X.Visible = False
                Damage5X.Visible = False
                Points5X.Visible = False
                Robot5.Caption = "No Robot Selected"
                ER(5).Visible = False
                DR(5).Visible = False
                PR5.Visible = False
                R5Icon.Picture = LoadPicture()
            Else
                R5path = R6path
                TransferCode 5, 6
                RobotTeam(5) = RobotTeam(6): TeamLabel(5) = TeamLabel(6): TeamLabel(5).ForeColor = TeamLabel(6).ForeColor
                Energy5X.Caption = Energy6X.Caption
                Damage5X.Caption = Damage6X.Caption
                Points5X.Caption = Points6X.Caption
                Robot5.Caption = Robot6.Caption
                ER(5).Caption = ER(6).Caption
                DR(5).Caption = DR(6).Caption
                
                PR5.Caption = PR6.Caption
                R5Icon.Picture = R6Icon.Picture
                Robot5Energy = Robot6Energy
                Robot5Damage = Robot6Damage
                Robot5Shield = Robot6Shield
                Robot5ProSpeed = Robot6ProSpeed
                Robot5Bullets = Robot6Bullets
                Robot5Probes = Robot6Probes
                Robot5Missiles = Robot6Missiles
                Robot5TacNukes = Robot6TacNukes
                Robot5Hellbores = Robot6Hellbores
                Robot5Drones = Robot6Drones
                Robot5Stunners = Robot6Stunners
                Robot5Mines = Robot6Mines
                Robot5Lasers = Robot6Lasers
                Robot5Turret = Robot6Turret
                Robot5ShieldIcon = Robot6ShieldIcon
                Robot5HitIcon = Robot6HitIcon
                Robot5BlockIcon = Robot6BlockIcon
                Robot5DeathIcon = Robot6DeathIcon
                Robot5CollisionIcon = Robot6CollisionIcon
                
                R6Present = False
                RobotTeam(6) = 0
                RobotLeft(6) = -100
                Energy6X.Visible = False
                Damage6X.Visible = False
                Points6X.Visible = False
                Robot6.Caption = "No Robot Selected"
                ER(6).Visible = False
                DR(6).Visible = False
                
                PR6.Visible = False
                R6Icon.Picture = LoadPicture()
            End If
        End If
    Case 3
        If R4Present = False Then
            R3Present = False
            RobotTeam(3) = 0
            RobotLeft(3) = -100
            Energy3X.Visible = False
            Damage3X.Visible = False
            Points3X.Visible = False
            Robot3.Caption = "No Robot Selected"
            ER(3).Visible = False
            DR(3).Visible = False
            PR3.Visible = False
            R3Icon.Picture = LoadPicture()
            SelectedRobot = 2
            Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = vbBlack: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
        Else
            R3path = R4path
            TransferCode 3, 4
            RobotTeam(3) = RobotTeam(4): TeamLabel(3) = TeamLabel(4): TeamLabel(3).ForeColor = TeamLabel(4).ForeColor
            Energy3X.Caption = Energy4X.Caption
            Damage3X.Caption = Damage4X.Caption
            Points3X.Caption = Points4X.Caption
            Robot3.Caption = Robot4.Caption
            ER(3).Caption = ER(4).Caption
            DR(3).Caption = DR(4).Caption
            PR3.Caption = PR4.Caption
            R3Icon.Picture = R4Icon.Picture
            Robot3Energy = Robot4Energy
            Robot3Damage = Robot4Damage
            Robot3Shield = Robot4Shield
            Robot3ProSpeed = Robot4ProSpeed
            Robot3Bullets = Robot4Bullets
            Robot3Probes = Robot4Probes
            Robot3Missiles = Robot4Missiles
            Robot3TacNukes = Robot4TacNukes
            Robot3Hellbores = Robot4Hellbores
            Robot3Drones = Robot4Drones
            Robot3Stunners = Robot4Stunners
            Robot3Mines = Robot4Mines
            Robot3Lasers = Robot4Lasers
            Robot3Turret = Robot4Turret
            Robot3ShieldIcon = Robot4ShieldIcon
            Robot3HitIcon = Robot4HitIcon
            Robot3BlockIcon = Robot4BlockIcon
            Robot3DeathIcon = Robot4DeathIcon
            Robot3CollisionIcon = Robot4CollisionIcon
            If R5Present = False Then
                R4Present = False
                RobotTeam(4) = 0
                RobotLeft(4) = -100
                Energy4X.Visible = False
                Damage4X.Visible = False
                Points4X.Visible = False
                Robot4.Caption = "No Robot Selected"
                ER(4).Visible = False
                DR(4).Visible = False
                PR4.Visible = False
                R4Icon.Picture = LoadPicture()
            Else
                R4path = R5path
                TransferCode 4, 5
                RobotTeam(4) = RobotTeam(5): TeamLabel(4) = TeamLabel(5): TeamLabel(4).ForeColor = TeamLabel(5).ForeColor
                Energy4X.Caption = Energy5X.Caption
                Damage4X.Caption = Damage5X.Caption
                Points4X.Caption = Points5X.Caption
                Robot4.Caption = Robot5.Caption
                ER(4).Caption = ER(5).Caption
                DR(4).Caption = DR(5).Caption
                PR4.Caption = PR5.Caption
                R4Icon.Picture = R5Icon.Picture
                Robot4Energy = Robot5Energy
                Robot4Damage = Robot5Damage
                Robot4Shield = Robot5Shield
                Robot4ProSpeed = Robot5ProSpeed
                Robot4Bullets = Robot5Bullets
                Robot4Probes = Robot5Probes
                Robot4Missiles = Robot5Missiles
                Robot4TacNukes = Robot5TacNukes
                Robot4Hellbores = Robot5Hellbores
                Robot4Drones = Robot5Drones
                Robot4Stunners = Robot5Stunners
                Robot4Mines = Robot5Mines
                Robot4Lasers = Robot5Lasers
                Robot4Turret = Robot5Turret
                Robot4ShieldIcon = Robot5ShieldIcon
                Robot4HitIcon = Robot5HitIcon
                Robot4BlockIcon = Robot5BlockIcon
                Robot4DeathIcon = Robot5DeathIcon
                Robot4CollisionIcon = Robot5CollisionIcon
                If R6Present = False Then
                    R5Present = False
                    RobotTeam(5) = 0
                    RobotLeft(5) = -100
                    Energy5X.Visible = False
                    Damage5X.Visible = False
                    Points5X.Visible = False
                    Robot5.Caption = "No Robot Selected"
                    ER(5).Visible = False
                    DR(5).Visible = False
                    PR5.Visible = False
                    R5Icon.Picture = LoadPicture()
                Else
                    R5path = R6path
                    TransferCode 5, 6
                    RobotTeam(5) = RobotTeam(6): TeamLabel(5) = TeamLabel(6): TeamLabel(5).ForeColor = TeamLabel(6).ForeColor
                    Energy5X.Caption = Energy6X.Caption
                    Damage5X.Caption = Damage6X.Caption
                    Points5X.Caption = Points6X.Caption
                    Robot5.Caption = Robot6.Caption
                    ER(5).Caption = ER(6).Caption
                    DR(5).Caption = DR(6).Caption
                    
                    PR5.Caption = PR6.Caption
                    R5Icon.Picture = R6Icon.Picture
                    Robot5Energy = Robot6Energy
                    Robot5Damage = Robot6Damage
                    Robot5Shield = Robot6Shield
                    Robot5ProSpeed = Robot6ProSpeed
                    Robot5Bullets = Robot6Bullets
                    Robot5Probes = Robot6Probes
                    Robot5Missiles = Robot6Missiles
                    Robot5TacNukes = Robot6TacNukes
                    Robot5Hellbores = Robot6Hellbores
                    Robot5Drones = Robot6Drones
                    Robot5Stunners = Robot6Stunners
                    Robot5Mines = Robot6Mines
                    Robot5Lasers = Robot6Lasers
                    Robot5Turret = Robot6Turret
                    Robot5ShieldIcon = Robot6ShieldIcon
                    Robot5HitIcon = Robot6HitIcon
                    Robot5BlockIcon = Robot6BlockIcon
                    Robot5DeathIcon = Robot6DeathIcon
                    Robot5CollisionIcon = Robot6CollisionIcon
                    
                    R6Present = False
                    RobotTeam(6) = 0
                    RobotLeft(6) = -100
                    Energy6X.Visible = False
                    Damage6X.Visible = False
                    Points6X.Visible = False
                    Robot6.Caption = "No Robot Selected"
                    ER(6).Visible = False
                    DR(6).Visible = False
                    
                    PR6.Visible = False
                    R6Icon.Picture = LoadPicture()
                End If
            End If
        End If
    Case 2
        If R3Present = False Then
            R2Present = False
            RobotTeam(2) = 0
            RobotLeft(2) = -100
            Energy2X.Visible = False
            Damage2X.Visible = False
            Points2X.Visible = False
            Robot2.Caption = "No Robot Selected"
            ER(2).Visible = False
            DR(2).Visible = False
            PR2.Visible = False
            R2Icon.Picture = LoadPicture()
            SelectedRobot = 1
            Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
        Else
            R2path = R3path
            TransferCode 2, 3
            RobotTeam(2) = RobotTeam(3): TeamLabel(2) = TeamLabel(3): TeamLabel(2).ForeColor = TeamLabel(3).ForeColor
            Energy2X.Caption = Energy3X.Caption
            Damage2X.Caption = Damage3X.Caption
            Points2X.Caption = Points3X.Caption
            Robot2.Caption = Robot3.Caption
            ER(2).Caption = ER(3).Caption
            DR(2).Caption = DR(3).Caption
            PR2.Caption = PR3.Caption
            R2Icon.Picture = R3Icon.Picture
            Robot2Energy = Robot3Energy
            Robot2Damage = Robot3Damage
            Robot2Shield = Robot3Shield
            Robot2ProSpeed = Robot3ProSpeed
            Robot2Bullets = Robot3Bullets
            Robot2Probes = Robot3Probes
            Robot2Missiles = Robot3Missiles
            Robot2TacNukes = Robot3TacNukes
            Robot2Hellbores = Robot3Hellbores
            Robot2Drones = Robot3Drones
            Robot2Stunners = Robot3Stunners
            Robot2Mines = Robot3Mines
            Robot2Lasers = Robot3Lasers
            Robot2Turret = Robot3Turret
            Robot2ShieldIcon = Robot3ShieldIcon
            Robot2HitIcon = Robot3HitIcon
            Robot2BlockIcon = Robot3BlockIcon
            Robot2DeathIcon = Robot3DeathIcon
            Robot2CollisionIcon = Robot3CollisionIcon
            If R4Present = False Then
                R3Present = False
                RobotTeam(3) = 0
                RobotLeft(3) = -100
                Energy3X.Visible = False
                Damage3X.Visible = False
                Points3X.Visible = False
                Robot3.Caption = "No Robot Selected"
                ER(3).Visible = False
                DR(3).Visible = False
                PR3.Visible = False
                R3Icon.Picture = LoadPicture()
            Else
                R3path = R4path
                TransferCode 3, 4
                RobotTeam(3) = RobotTeam(4): TeamLabel(3) = TeamLabel(4): TeamLabel(3).ForeColor = TeamLabel(4).ForeColor
                Energy3X.Caption = Energy4X.Caption
                Damage3X.Caption = Damage4X.Caption
                Points3X.Caption = Points4X.Caption
                Robot3.Caption = Robot4.Caption
                ER(3).Caption = ER(4).Caption
                DR(3).Caption = DR(4).Caption
                PR3.Caption = PR4.Caption
                R3Icon.Picture = R4Icon.Picture
                Robot3Energy = Robot4Energy
                Robot3Damage = Robot4Damage
                Robot3Shield = Robot4Shield
                Robot3ProSpeed = Robot4ProSpeed
                Robot3Bullets = Robot4Bullets
                Robot3Probes = Robot4Probes
                Robot3Missiles = Robot4Missiles
                Robot3TacNukes = Robot4TacNukes
                Robot3Hellbores = Robot4Hellbores
                Robot3Drones = Robot4Drones
                Robot3Stunners = Robot4Stunners
                Robot3Mines = Robot4Mines
                Robot3Lasers = Robot4Lasers
                Robot3Turret = Robot4Turret
                Robot3ShieldIcon = Robot4ShieldIcon
                Robot3HitIcon = Robot4HitIcon
                Robot3BlockIcon = Robot4BlockIcon
                Robot3DeathIcon = Robot4DeathIcon
                Robot3CollisionIcon = Robot4CollisionIcon
                If R5Present = False Then
                    R4Present = False
                    RobotTeam(4) = 0
                    RobotLeft(4) = -100
                    Energy4X.Visible = False
                    Damage4X.Visible = False
                    Points4X.Visible = False
                    Robot4.Caption = "No Robot Selected"
                    ER(4).Visible = False
                    DR(4).Visible = False
                    PR4.Visible = False
                    R4Icon.Picture = LoadPicture()
                Else
                    R4path = R5path
                    TransferCode 4, 5
                    RobotTeam(4) = RobotTeam(5): TeamLabel(4) = TeamLabel(5): TeamLabel(4).ForeColor = TeamLabel(5).ForeColor
                    Energy4X.Caption = Energy5X.Caption
                    Damage4X.Caption = Damage5X.Caption
                    Points4X.Caption = Points5X.Caption
                    Robot4.Caption = Robot5.Caption
                    ER(4).Caption = ER(5).Caption
                    DR(4).Caption = DR(5).Caption
                    PR4.Caption = PR5.Caption
                    R4Icon.Picture = R5Icon.Picture
                    Robot4Energy = Robot5Energy
                    Robot4Damage = Robot5Damage
                    Robot4Shield = Robot5Shield
                    Robot4ProSpeed = Robot5ProSpeed
                    Robot4Bullets = Robot5Bullets
                    Robot4Probes = Robot5Probes
                    Robot4Missiles = Robot5Missiles
                    Robot4TacNukes = Robot5TacNukes
                    Robot4Hellbores = Robot5Hellbores
                    Robot4Drones = Robot5Drones
                    Robot4Stunners = Robot5Stunners
                    Robot4Mines = Robot5Mines
                    Robot4Lasers = Robot5Lasers
                    Robot4Turret = Robot5Turret
                    Robot4ShieldIcon = Robot5ShieldIcon
                    Robot4HitIcon = Robot5HitIcon
                    Robot4BlockIcon = Robot5BlockIcon
                    Robot4DeathIcon = Robot5DeathIcon
                    Robot4CollisionIcon = Robot5CollisionIcon
                    If R6Present = False Then
                        R5Present = False
                        RobotTeam(5) = 0
                        RobotLeft(5) = -100
                        Energy5X.Visible = False
                        Damage5X.Visible = False
                        Points5X.Visible = False
                        Robot5.Caption = "No Robot Selected"
                        ER(5).Visible = False
                        DR(5).Visible = False
                        PR5.Visible = False
                        R5Icon.Picture = LoadPicture()
                    Else
                        R5path = R6path
                        TransferCode 5, 6
                        RobotTeam(5) = RobotTeam(6): TeamLabel(5) = TeamLabel(6): TeamLabel(5).ForeColor = TeamLabel(6).ForeColor
                        Energy5X.Caption = Energy6X.Caption
                        Damage5X.Caption = Damage6X.Caption
                        Points5X.Caption = Points6X.Caption
                        Robot5.Caption = Robot6.Caption
                        ER(5).Caption = ER(6).Caption
                        DR(5).Caption = DR(6).Caption
                        
                        PR5.Caption = PR6.Caption
                        R5Icon.Picture = R6Icon.Picture
                        Robot5Energy = Robot6Energy
                        Robot5Damage = Robot6Damage
                        Robot5Shield = Robot6Shield
                        Robot5ProSpeed = Robot6ProSpeed
                        Robot5Bullets = Robot6Bullets
                        Robot5Probes = Robot6Probes
                        Robot5Missiles = Robot6Missiles
                        Robot5TacNukes = Robot6TacNukes
                        Robot5Hellbores = Robot6Hellbores
                        Robot5Drones = Robot6Drones
                        Robot5Stunners = Robot6Stunners
                        Robot5Mines = Robot6Mines
                        Robot5Lasers = Robot6Lasers
                        Robot5Turret = Robot6Turret
                        Robot5ShieldIcon = Robot6ShieldIcon
                        Robot5HitIcon = Robot6HitIcon
                        Robot5BlockIcon = Robot6BlockIcon
                        Robot5DeathIcon = Robot6DeathIcon
                        Robot5CollisionIcon = Robot6CollisionIcon
                    
                        R6Present = False
                        RobotTeam(6) = 0
                        RobotLeft(6) = -100
                        Energy6X.Visible = False
                        Damage6X.Visible = False
                        Points6X.Visible = False
                        Robot6.Caption = "No Robot Selected"
                        ER(6).Visible = False
                        DR(6).Visible = False
                        
                        PR6.Visible = False
                        R6Icon.Picture = LoadPicture()
                    End If
                End If
            End If
        End If
End Select

Load2.Visible = R1Present
Load3.Visible = R2Present
Load4.Visible = R3Present
Load5.Visible = R4Present
Load6.Visible = R5Present

Dim c As Long
For c = 1 To 6  'We set all teamlabels visible or not here. It was way to complicated to transfer. If it's a member of a team it visible, it's as simple as that
    TeamLabel(c).Visible = RobotTeam(c) <> 0
Next

End Sub

Private Sub CPRTimer_Timer()

CPRLabel.Caption = Chronon - CprTimerCount
CprTimerCount = Chronon
CPRLabel.Refresh        'Snabbar upp!!!!???!!?!

End Sub

Private Sub Debugger_Click()

If DebuggedRobot > 6 Or SelectedRobot = -1 Then
DebuggedRobot = DebuggedRobot \ 10

Else
    If DebuggedRobot <> SelectedRobot Then
        If DebuggedRobot <> 0 Then Image1(DebuggedRobot).Visible = False
        DebuggedRobot = SelectedRobot
        Image1(SelectedRobot).Visible = True
        'InactivateDebug.Checked = False
        DebuggerAutoStart = False
        If HideBattle Then Normal_Click  'disk
    Else
        DebuggedRobot = 0
        Image1(SelectedRobot).Visible = False
        
        If Normal.Checked Then
            Normal_Click
        ElseIf Fast.Checked Then
            Fast_Click
        ElseIf AutoRedrawFast.Checked Then
            AutoRedrawFast_Click
        ElseIf Ultra.Checked Then
            Ultra_Click
        ElseIf Slow.Checked Then
            Slow_Click
        ElseIf Slower.Checked Then
            Slower_Click
        ElseIf Slowest.Checked Then
            Slowest_Click
        End If
    End If
End If

End Sub

Private Sub DelateRobot_Click()
Dim RobotensNamn As String
Dim FileName As String

Select Case SelectedRobot
    Case 1
        FileName = R1path
        RobotensNamn = Robot1.Caption
    Case 2
        FileName = R2path
        RobotensNamn = Robot2.Caption
    Case 3
        FileName = R3path
        RobotensNamn = Robot3.Caption
    Case 4
        FileName = R4path
        RobotensNamn = Robot4.Caption
    Case 5
        FileName = R5path
        RobotensNamn = Robot5.Caption
    Case 6
        FileName = R6path
        RobotensNamn = Robot6.Caption
    Case Else
        MsgBox "There is no Robot present to delete.", vbOKOnly, "No Robot Present"
        Exit Sub
End Select

If MsgBox("Are you sure you want to delete '" & RobotensNamn & "'?", vbYesNo, "Delete") = 7 Then Exit Sub

Kill FileName

Close_Click
End Sub

Private Sub Drafting_Click()

If SelectedRobot < 1 Then
    MsgBox "Can't show Drafting Board because no robot is selected. To select a robot, use the PageUp and PageDown keys.", vbOKOnly, "No Robot Selected"
Else
    DraftingBoard.Show 1, MainWindow

    Dim sDup As String
    Select Case SelectedRobot
        Case 1
            sDup = R1path
        Case 2
            sDup = R2path
        Case 3
            sDup = R3path
        Case 4
            sDup = R4path
        Case 5
            sDup = R5path
        Case 6
            sDup = R6path
    End Select

    If R1path = sDup Then RefreshCode R1path, 1
    If R2path = sDup Then RefreshCode R2path, 2
    If R3path = sDup Then RefreshCode R3path, 3
    If R4path = sDup Then RefreshCode R4path, 4
    If R5path = sDup Then RefreshCode R5path, 5
    If R6path = sDup Then RefreshCode R6path, 6
End If

End Sub

Private Sub RefreshCode(DupPath As String, DupNr As Long)
    Dim RNN As Long     ' Reload the code in case it was changed
    Dim InputInsts(4999) As Integer

    Open DupPath For Binary As #254
    Get #254, MCrec, RNN
    Get #254, RNN, InputInsts
    For RNN = 0 To 4999
        MasterCode(DupNr, RNN) = InputInsts(RNN)
        If InputInsts(RNN) = insEND Then Exit For
    Next RNN
    Close 254       'End Reload
End Sub

Private Sub Duplicate_Click()
If R1Present = False Then
    MsgBox "No robot present to duplicate.", vbOKOnly, "No Robot Present"
Else
    NotRandomEmergency = False
    Dim DuplicatePath As String
    Dim DuplicateName As String
    Dim DupRobotTeam As Integer
    Dim TeamCaption As String
    Dim TeamColor As Long
    DupRobotTeam = RobotTeam(SelectedRobot)
    TeamCaption = TeamLabel(SelectedRobot)
    TeamColor = TeamLabel(SelectedRobot).ForeColor
    
    Select Case SelectedRobot
        Case 1
            DuplicatePath = R1path
            DuplicateName = Robot1.Caption
        Case 2
            DuplicatePath = R2path
            DuplicateName = Robot2.Caption
        Case 3
            DuplicatePath = R3path
            DuplicateName = Robot3.Caption
        Case 4
            DuplicatePath = R4path
            DuplicateName = Robot4.Caption
        Case 5
            DuplicatePath = R5path
            DuplicateName = Robot5.Caption
    End Select
    
    If R2Present = False Then
        R2Present = True
        R2path = DuplicatePath
        Robot2.Caption = DuplicateName
        Load3.Visible = True
        RobotTeam(2) = DupRobotTeam
        TeamLabel(2) = TeamCaption
        TeamLabel(2).ForeColor = TeamColor
        LoadRobot2
        Exit Sub
    End If
    
    If R3Present = False Then
        R3Present = True
        R3path = DuplicatePath
        Robot3.Caption = DuplicateName
        Load4.Visible = True
        RobotTeam(3) = DupRobotTeam
        TeamLabel(3) = TeamCaption
        TeamLabel(3).ForeColor = TeamColor
        LoadRobot3
        Exit Sub
    End If
    
    If R4Present = False Then
        R4Present = True
        R4path = DuplicatePath
        Robot4.Caption = DuplicateName
        Load5.Visible = True
        RobotTeam(4) = DupRobotTeam
        TeamLabel(4) = TeamCaption
        TeamLabel(4).ForeColor = TeamColor
        LoadRobot4
        Exit Sub
    End If
    
    If R5Present = False Then
        R5Present = True
        R5path = DuplicatePath
        Robot5.Caption = DuplicateName
        Load6.Visible = True
        RobotTeam(5) = DupRobotTeam
        TeamLabel(5) = TeamCaption
        TeamLabel(5).ForeColor = TeamColor
        LoadRobot5
        Exit Sub
    End If
    
    If R6Present = False Then
        R6Present = True
        R6path = DuplicatePath
        Robot6.Caption = DuplicateName
        LoadRobot.Enabled = False
        Duplicate.Enabled = False
        SaveAs.Enabled = False
        RobotTeam(6) = DupRobotTeam
        TeamLabel(6) = TeamCaption
        TeamLabel(6).ForeColor = TeamColor
        LoadRobot6
    End If
End If

End Sub

Private Sub Form_Resize()
If RunningTournament Then
    Dim YesOrNo As Boolean
    
    Select Case Me.WindowState
        Case Normal
            YesOrNo = False
            Put 7, 4500, YesOrNo
            WindowMini = False
            TitleTimer.Enabled = False
        Case Maximized
            YesOrNo = True
            Put 7, 4500, YesOrNo
        Case Minimized
            WindowMini = True
            TitleTimer.Enabled = True
    End Select
End If
End Sub

Private Sub Form_Unload(Cancel As Integer)
If ResolutionChanged = 1 Then ChangeWindow_640X480 (MainWindow.hdc)
End
End Sub

Private Sub Hardware_Click()

If SelectedRobot < 1 Then
    MsgBox "Can't show Hardware Store because no robot is selected. To select a robot, use the PageUp and PageDown keys.", vbOKOnly, "No Robot Selected"
Else
    HardwareWindow.Show 1, MainWindow
End If
End Sub

Private Sub Help_Click()
ShowHelp
End Sub

Private Sub History_Click()

If R1Present Then
    HistoryWindow.GenStats = _
    "Number of battles fought: " & HistoryRec(1, 1) & vbLf & _
    "Chronons in last battle: " & HistoryRec(1, 10) & vbLf & _
    "Chronons in all battles: " & HistoryRec(1, 11) & vbLf

    HistoryWindow.R1 = Robot1.Caption
    HistoryWindow.S1 = HistoryRec(1, 4)
    HistoryWindow.TS1 = HistoryRec(1, 5)
    HistoryWindow.PR1 = PR1
    HistoryWindow.Image1 = R1Icon
    HistoryWindow.Kills1 = HistoryRec(1, 2)
    HistoryWindow.TotalKills1 = HistoryRec(1, 3)
    
    If R2Present Then
    HistoryWindow.R2 = Robot2.Caption
    HistoryWindow.S2 = HistoryRec(2, 4)
    HistoryWindow.TS2 = HistoryRec(2, 5)
    HistoryWindow.PR2 = PR2
    HistoryWindow.Image2 = R2Icon
    HistoryWindow.Kills2 = HistoryRec(2, 2)
    HistoryWindow.TotalKills2 = HistoryRec(2, 3)
    End If
    
    If R3Present Then
    HistoryWindow.R3 = Robot3.Caption
    HistoryWindow.S3 = HistoryRec(3, 4)
    HistoryWindow.TS3 = HistoryRec(3, 5)
    HistoryWindow.PR3 = PR3
    HistoryWindow.Image3 = R3Icon
    HistoryWindow.Kills3 = HistoryRec(3, 2)
    HistoryWindow.TotalKills3 = HistoryRec(3, 3)
    End If
    
    If R4Present Then
    HistoryWindow.R4 = Robot4.Caption
    HistoryWindow.S4 = HistoryRec(4, 4)
    HistoryWindow.TS4 = HistoryRec(4, 5)
    HistoryWindow.PR4 = PR4
    HistoryWindow.Image4 = R4Icon
    HistoryWindow.Kills4 = HistoryRec(4, 2)
    HistoryWindow.TotalKills4 = HistoryRec(4, 3)
    End If
    
    If R5Present Then
    HistoryWindow.R5 = Robot5.Caption
    HistoryWindow.S5 = HistoryRec(5, 4)
    HistoryWindow.TS5 = HistoryRec(5, 5)
    HistoryWindow.PR5 = PR5
    HistoryWindow.Image5 = R5Icon
    HistoryWindow.Kills5 = HistoryRec(5, 2)
    HistoryWindow.TotalKills5 = HistoryRec(5, 3)
    End If
    
    If R6Present Then
    HistoryWindow.R6 = Robot6.Caption
    HistoryWindow.S6 = HistoryRec(6, 4)
    HistoryWindow.TS6 = HistoryRec(6, 5)
    HistoryWindow.PR6 = PR6
    HistoryWindow.Image6 = R6Icon
    HistoryWindow.Kills6 = HistoryRec(6, 2)
    HistoryWindow.TotalKills6 = HistoryRec(6, 3)
    End If

    HistoryWindow.Show 1
Else
    MsgBox "To load a robot, choose 'Load Robot' from the file menu.", , "No Robot Loaded"
End If

End Sub

Private Sub Icon_Click()

If SelectedRobot < 1 Then
    MsgBox "Can't show Icon Factory because no robot is selected. To select a robot, use the PageUp and PageDown keys.", vbOKOnly, "No Robot Selected"
Else
    ChooseIcon.Show 1, MainWindow
End If

End Sub

Private Sub InactivateDebug_Click()
InactivateDebug.Checked = Not InactivateDebug.Checked
End Sub

Private Sub KnownBugs_Click()
Dim ErMsg As String
'ErMsg = ErMsg & vbtab & "Pearl doens't survive as long as it does in the mac version."

'ErMsg = ErMsg & vbcr & vbcr & vbtab & "Sounds bugs out if they're enabled and battlespeed is above ~50 chronons per sec."

'ErMsg = ErMsg & vbcr & vbcr & vbtab & "Have you ever seen that Japanese movie 'Ringu'? There was this girl who could "
'ErMsg = ErMsg & vbcr & vbtab & "wish people dead. Robots can do that too sometimes."
'ErMsg = ErMsg & vbcr & vbcr & "Unconfirmed:"

'ErMsg = ErMsg & vbcr & vbcr & "I'm not sure if the last two exists or not. Range got all better since I fixed the collision system" '& vbcr
'ErMsg = ErMsg & vbcr & "and the 'Ringu-bug' is very rare." '& vbcr

ErMsg = "Drones don't behave as in the Mac version." _
        & vbCr & vbCr & "Drones are also EXTREME slowdowners. Battles with 6 Carne can slow down below" & vbCr & "700 Chronons per second, even on fast computers."

ErMsg = ErMsg & vbCr & vbCr & "Left' Right' Top' and Bot' interupps aren't triggered by movex' and movey'."

'ErMsg = ErMsg & vbcr & vbcr & vbtab & "Robots can jump over shots with movex and movey."    'Kan den i Mac versionen med
ErMsg = ErMsg & vbCr & vbCr & "The Turret Shapes doesn't look like they do in the Mac version."

ErMsg = ErMsg & vbCr & vbCr & "The Interupts system can misbehave under extreme pressure."

'ErMsg = ErMsg & vbCr & vbCr & "Here a list of features that doesn't exist yet:" & vbcr _
'             & vbTab & "Some things I've forgot to list here."
'Den 16:onde Juli, klockan 01:57 blev denna lista tom. Precis alltig som finns i Mac versionen finns i Windows versionen.

MsgBox ErMsg, vbOKOnly + vbInformation, "Know Bugs"

End Sub

Private Sub Load1_Click()
NotRandomEmergency = False

Dim NameVar1 As String  '-:-
Dim namevar2 As Long '-:-

If BattleHaltButton.Caption = "Halt" Then Exit Sub  'If there's an ongoing battle, do nothing

CommonDialog1.ShowOpen                          'Shows the Open dialog by using Comdlg32.ocx, the dialog pops up, no problem with that
If CommonDialog1.FileName = "" Then Exit Sub    'It the user has clicked cancel, then do nothing

If CommonDialog1.InitDir <> "" Then CommonDialog1.InitDir = ""      'Nytt

Load2.Visible = True

R1path = CommonDialog1.FileName                 'Sets the global variable R1Path

NameVar1 = CommonDialog1.FileTitle
namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
Robot1.Caption = Left$(NameVar1, namevar2)      'Replaces the caption 'No Robot Selected' with the robots name

R1Present = True                                'Sets the global variable R1Present

If SelectedRobot > 6 Or SelectedRobot < 1 Then                       'Selects the recently opened robot, if there's no other robot selected
    SelectedRobot = 1
    Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
End If

CommonDialog1.FileName = ""                     'Resets the file name, so cancel will work

LoadRobot1                                      'A huge subroutine that loads hardware, icon and icon settings
If Not Replaying Then ResetHistory_Click                              'Another sub routine that erases the history of previous battles
End Sub
Private Sub Load2_Click()
NotRandomEmergency = False

Dim NameVar1 As String  '-:-
Dim namevar2 As Long '-:-

If BattleHaltButton.Caption = "Halt" Then Exit Sub
If Me.Visible = False Then Exit Sub

CommonDialog1.ShowOpen
If CommonDialog1.FileName = "" Then Exit Sub

If CommonDialog1.InitDir <> "" Then CommonDialog1.InitDir = ""      'Nytt

Load3.Visible = True

R2path = CommonDialog1.FileName

NameVar1 = CommonDialog1.FileTitle              'Tar bort .RWR från namnet
namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
Robot2.Caption = Left$(NameVar1, namevar2)

R2Present = True

'SelectedRobot = 2
'Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = vbBlack: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
CommonDialog1.FileName = ""

LoadRobot2
If Not Replaying Then ResetHistory_Click
End Sub
Private Sub Load3_Click()
NotRandomEmergency = False

Dim NameVar1 As String  '-:-
Dim namevar2 As Long '-:-

If BattleHaltButton.Caption = "Halt" Then Exit Sub
If Me.Visible = False Then Exit Sub

CommonDialog1.ShowOpen
If CommonDialog1.FileName = "" Then Exit Sub

If CommonDialog1.InitDir <> "" Then CommonDialog1.InitDir = ""      'Nytt

Load4.Visible = True

R3path = CommonDialog1.FileName

NameVar1 = CommonDialog1.FileTitle              'Tar bort .RWR från namnet
namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
Robot3.Caption = Left$(NameVar1, namevar2)

R3Present = True

'SelectedRobot = 3
'Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = vbBlack: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
CommonDialog1.FileName = ""

LoadRobot3
If Not Replaying Then ResetHistory_Click
End Sub
Private Sub Load4_Click()
NotRandomEmergency = False

Dim NameVar1 As String  '-:-
Dim namevar2 As Long '-:-

If BattleHaltButton.Caption = "Halt" Then Exit Sub
If Me.Visible = False Then Exit Sub

CommonDialog1.ShowOpen
If CommonDialog1.FileName = "" Then Exit Sub

If CommonDialog1.InitDir <> "" Then CommonDialog1.InitDir = ""      'Nytt

Load5.Visible = True

R4path = CommonDialog1.FileName

NameVar1 = CommonDialog1.FileTitle              'Tar bort .RWR från namnet
namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
Robot4.Caption = Left$(NameVar1, namevar2)

R4Present = True

'SelectedRobot = 4
'Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = vbBlack: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
CommonDialog1.FileName = ""

LoadRobot4
If Not Replaying Then ResetHistory_Click
End Sub
Private Sub Load5_Click()
NotRandomEmergency = False

Dim NameVar1 As String  '-:-
Dim namevar2 As Long '-:-

If BattleHaltButton.Caption = "Halt" Then Exit Sub
If Me.Visible = False Then Exit Sub

CommonDialog1.ShowOpen
If CommonDialog1.FileName = "" Then Exit Sub

If CommonDialog1.InitDir <> "" Then CommonDialog1.InitDir = ""      'Nytt

Load6.Visible = True

R5path = CommonDialog1.FileName

NameVar1 = CommonDialog1.FileTitle              'Tar bort .RWR från namnet
namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
Robot5.Caption = Left$(NameVar1, namevar2)

R5Present = True

'SelectedRobot = 5
'Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = vbBlack: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
CommonDialog1.FileName = ""
LoadRobot5
If Not Replaying Then ResetHistory_Click
End Sub
Private Sub Load6_Click()
NotRandomEmergency = False

Dim NameVar1 As String  '-:-
Dim namevar2 As Long '-:-

If BattleHaltButton.Caption = "Halt" Then Exit Sub
If Me.Visible = False Then Exit Sub

CommonDialog1.ShowOpen
If CommonDialog1.FileName = "" Then Exit Sub

If CommonDialog1.InitDir <> "" Then CommonDialog1.InitDir = ""      'Nytt

R6path = CommonDialog1.FileName

NameVar1 = CommonDialog1.FileTitle              'Tar bort .RWR från namnet
namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
Robot6.Caption = Left$(NameVar1, namevar2)

R6Present = True

'SelectedRobot = 6
'Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = vbBlack: Robot6.ForeColor = vbWhite
CommonDialog1.FileName = ""

NewRobot.Enabled = False
LoadRobot.Enabled = False
Duplicate.Enabled = False
SaveAs.Enabled = False

LoadRobot6
If Not Replaying Then ResetHistory_Click
End Sub

Private Sub ChronorsLimit_Click()
Dim YesOrNo As Boolean
    
    If ChronorsLimit.Checked = False Then
        ChronorsLimit.Checked = True
        MaxChronon = 1500
        YesOrNo = True
        Put 7, 3000, YesOrNo
    Else
        ChronorsLimit.Checked = False
        MaxChronon = -1
        YesOrNo = False
        Put 7, 3000, YesOrNo
    End If
End Sub

Private Sub MoveAndShoot_Click()
Dim YesOrNo As Boolean
    
    If MoveAndShoot.Checked = False Then
        MoveAndShoot.Checked = True
        YesOrNo = True
        Put 7, 5000, YesOrNo
    Else
        MoveAndShoot.Checked = False
        YesOrNo = False
        Put 7, 5000, YesOrNo
    End If
    
    MoveAndShotAllowed = Not MoveAndShoot.Checked
End Sub

Private Sub NewRobot_Click()
NotRandomEmergency = False

Dim NameVar1 As String  '-:-
Dim namevar2 As Long '-:-

On Error GoTo OpenNoMoreRobot

CommonDialog3.ShowSave

If Dir(CommonDialog3.FileName) <> "" Then
    If MsgBox("Do you want to replace " & CommonDialog3.FileTitle & "?", vbOKCancel, "Robot already exists") = vbCancel Then Exit Sub
End If

FileCopy App.Path & "\miscdata\Standard.RWR", CommonDialog3.FileName

'Hämtat från Loadrobot
If R1Present = False Then
    NameVar1 = CommonDialog3.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot1.Caption = Left$(NameVar1, namevar2)
    
    R1Present = True
    R1path = CommonDialog3.FileName
    Load2.Visible = True
    
    LoadRobot1
    Exit Sub
ElseIf R2Present = False Then
    NameVar1 = CommonDialog3.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot2.Caption = Left$(NameVar1, namevar2)
    
    R2Present = True
    R2path = CommonDialog3.FileName
    Load2.Visible = True
    Load3.Visible = True
    
    LoadRobot2
ElseIf R3Present = False Then
    NameVar1 = CommonDialog3.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot3.Caption = Left$(NameVar1, namevar2)
    
    R3Present = True
    R3path = CommonDialog3.FileName
    Load3.Visible = True
    Load4.Visible = True
    
    LoadRobot3
ElseIf R4Present = False Then
    NameVar1 = CommonDialog3.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot4.Caption = Left$(NameVar1, namevar2)
    
    R4Present = True
    R4path = CommonDialog3.FileName
    Load4.Visible = True
    Load5.Visible = True
    
    LoadRobot4
ElseIf R5Present = False Then
    NameVar1 = CommonDialog3.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot5.Caption = Left$(NameVar1, namevar2)
    
    R5Present = True
    R5path = CommonDialog3.FileName
    Load5.Visible = True
    Load6.Visible = True
    
    LoadRobot5
ElseIf R6Present = False Then
    NameVar1 = CommonDialog3.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot6.Caption = Left$(NameVar1, namevar2)
    
    R6Present = True
    R6path = CommonDialog3.FileName
    Load6.Visible = True
    
    NewRobot.Enabled = False
    LoadRobot.Enabled = False
    Duplicate.Enabled = False
    SaveAs.Enabled = False
    
    LoadRobot6
End If

OpenNoMoreRobot:
End Sub

Private Sub NoTeam_Click()
If SelectedRobot >= 1 Then
RobotTeam(SelectedRobot) = 0
TeamLabel(SelectedRobot).Visible = False
End If
End Sub

Private Sub Overloading_Click()
Dim YesOrNo As Boolean
    
    If Overloading.Checked = False Then
        Overloading.Checked = True
        YesOrNo = True
        Put 7, 6000, YesOrNo
    Else
        Overloading.Checked = False
        YesOrNo = False
        Put 7, 6000, YesOrNo
    End If
    
    EnableOverloading = Not YesOrNo
End Sub

Private Sub Password_Click()
MsgBox "This feuture doesn't work yet." & vbCr & "I'm not sure if I'll ever implement it, since passwords are removed in the lastest mac version.", vbOKOnly, "Sorry"
End Sub

Private Sub Quit_Click()
If ResolutionChanged = 1 Then ChangeWindow_640X480 (MainWindow.hdc)
End
End Sub

Private Sub R1Icon_Click()
Robot1_Click
If RunningTournament Then StopTournament.SetFocus Else BattleHaltButton.SetFocus
End Sub

Private Sub R2Icon_Click()
Robot2_Click
If RunningTournament Then StopTournament.SetFocus Else BattleHaltButton.SetFocus
End Sub

Private Sub R3Icon_Click()
Robot3_Click
If RunningTournament Then StopTournament.SetFocus Else BattleHaltButton.SetFocus
End Sub

Private Sub R4Icon_Click()
Robot4_Click
If RunningTournament Then StopTournament.SetFocus Else BattleHaltButton.SetFocus
End Sub

Private Sub R5Icon_Click()
Robot5_Click
If RunningTournament Then StopTournament.SetFocus Else BattleHaltButton.SetFocus
End Sub

Private Sub R6Icon_Click()
Robot6_Click
If RunningTournament Then StopTournament.SetFocus Else BattleHaltButton.SetFocus
End Sub

Private Sub R1Icon_GotFocus()
If RunningTournament Then
    StopTournament.SetFocus
Else
    BattleHaltButton.SetFocus
    BattleHaltButton_KeyDown vbKeyPageUp, 0
End If
End Sub

Private Sub R2Icon_GotFocus()
If RunningTournament Then
    StopTournament.SetFocus
Else
    BattleHaltButton.SetFocus
    BattleHaltButton_KeyDown vbKeyPageDown, 0
End If
End Sub

Private Sub RenameRobot_Click()
Dim ThePath As String, Name1 As String, Name2 As String, Name1plusRWR As String, Name2plusRWR As String
Dim Remove As Long

Select Case SelectedRobot
    Case 1
        Name1 = Robot1.Caption
        ThePath = R1path
    Case 2
        Name1 = Robot2.Caption
        ThePath = R2path
    Case 3
        Name1 = Robot3.Caption
        ThePath = R3path
    Case 4
        Name1 = Robot4.Caption
        ThePath = R4path
    Case 5
        Name1 = Robot5.Caption
        ThePath = R5path
    Case 6
        Name1 = Robot6.Caption
        ThePath = R6path
    Case Else
        MsgBox "There is no robot present to rename.", , "Can't rename"
        Exit Sub
End Select

Remove = Len(ThePath) - Len(Name1) - 4
ThePath = Left$(ThePath, Remove)

Retry:
Name2 = InputBox("Please enter the new name for '" & Name1 & "'.", , Name1, 100, 100)

If Name2 = "" Then
    Exit Sub
ElseIf InStr(Name2, "?") Or InStr(Name2, "/") Or InStr(Name2, "\") Or InStr(Name2, ":") Or InStr(Name2, "*") Or InStr(Name2, "*") Or InStr(Name2, Chr(34)) Then
    Dim ans As Long
    ans = MsgBox("The name you've specified contain a character that Windows doesn't allow to be used in filenames." _
    & vbNewLine & "The following characters can't be used: ? / \ : * " & Chr(34), vbRetryCancel, "Illegal character in the new file name")
    If ans = vbRetry Then GoTo Retry Else Exit Sub
ElseIf Dir(Name2 & ".RWR") <> "" And UCase(Name1) <> UCase(Name2) Then
    If MsgBox("Do you want to replace " & Name2 & "?", vbOKCancel, "Robot already exists") = vbCancel Then Exit Sub Else Kill Name2 & ".RWR"
End If

Name1plusRWR = ThePath & Name1 & ".RWR"
Name2plusRWR = ThePath & Name2 & ".RWR"
Name Name1plusRWR As Name2plusRWR

Select Case SelectedRobot
    Case 1
        Robot1.Caption = Name2
        R1path = Name2plusRWR
    Case 2
        Robot2.Caption = Name2
        R2path = Name2plusRWR
    Case 3
        Robot3.Caption = Name2
        R3path = Name2plusRWR
    Case 4
        Robot4.Caption = Name2
        R4path = Name2plusRWR
    Case 5
        Robot5.Caption = Name2
        R5path = Name2plusRWR
    Case 6
        R6path = Name2plusRWR
        Robot6.Caption = Name2
End Select

End Sub

Private Sub RepeatBattle_Click()
If Replaying And StartDebuggerAt >= 0 Then StartDebuggerAt = DEBUGATNOTSET     'Disable start debug at

Replaying = Not (Replaying)
RepeatBattle.Checked = Replaying

If LastStartPosX(1) = 0 Then
    Dim counter As Long
    
    For counter = 1 To 6
            LastStartPosX(counter) = Round((268 * Rnd) + 8) 'Int
            LastStartPosY(counter) = Round((268 * Rnd) + 8)
    Next counter
End If

ReplayText.Visible = Replaying
End Sub

Private Sub ResetHistory_Click()
PR1 = 0
PR2 = 0
PR3 = 0
PR4 = 0
PR5 = 0
PR6 = 0

Dim counter As Long
For counter = 1 To 50
    HistoryRec(1, counter) = 0
    HistoryRec(2, counter) = 0
    HistoryRec(3, counter) = 0
    HistoryRec(4, counter) = 0
    HistoryRec(5, counter) = 0
    HistoryRec(6, counter) = 0
Next counter

End Sub

Private Sub resolution_Click()
Dim YesOrNo As Boolean

If resolution.Checked = False Then
    resolution.Checked = True
    YesOrNo = True
Else
    resolution.Checked = False
    YesOrNo = False
End If
    Put 7, 12000, YesOrNo
End Sub

Private Sub Robot2_Click()
If R2Present Then
    SelectedRobot = 2
    
    Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite
    Robot2.BackColor = vbBlack: Robot2.ForeColor = vbWhite
    Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite
    Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite
    Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite
    Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
End If
End Sub

Private Sub Robot1_Click()
If R1Present Then
    SelectedRobot = 1
    
    Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite
    Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite
    Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite
    Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite
    Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite
    Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
End If
End Sub

Private Sub Robot6_Click()
If R6Present Then
    SelectedRobot = 6
    
    Robot6.BackColor = vbBlack: Robot6.ForeColor = vbWhite
    Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite
    Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite
    Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite
    Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite
    Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite
End If
End Sub

Private Sub Robot4_Click()
If R4Present Then
    SelectedRobot = 4
    
    Robot4.BackColor = vbBlack: Robot4.ForeColor = vbWhite
    Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite
    Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite
    Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite
    Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite
    Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
End If
End Sub

Private Sub Robot5_Click()
If R5Present Then
    SelectedRobot = 5
    
    Robot5.BackColor = vbBlack: Robot5.ForeColor = vbWhite
    Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite
    Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite
    Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite
    Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite
    Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
End If
End Sub

Private Sub Robot3_Click()
If R3Present Then
    SelectedRobot = 3
    
    Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite
    Robot3.BackColor = vbBlack: Robot3.ForeColor = vbWhite
    Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite
    Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite
    Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite
    Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
End If
End Sub

Private Sub SaveAs_Click()
NotRandomEmergency = False

On Error GoTo didcancel

If SelectedRobot < 1 Then
    MsgBox "There is no Robot present as source.", vbOKOnly, "No Robot Present"
    Exit Sub
End If

CommonDialog3.ShowSave

If CommonDialog3.FileName = "" Then
    Exit Sub
ElseIf Dir(CommonDialog3.FileName) <> "" Then
    If MsgBox("Do you want to replace " & CommonDialog3.FileTitle & "?", vbOKCancel, "Robot already exists") = vbCancel Then Exit Sub
End If

Dim Source As String
Dim Target As String
Dim FreeRobot As Long
Dim NameVar1 As String
Dim namevar2 As Long

Target = CommonDialog3.FileName

Select Case SelectedRobot
    Case 1
        Source = R1path
    Case 2
        Source = R2path
    Case 3
        Source = R3path
    Case 4
        Source = R4path
    Case 5
        Source = R5path
    Case 6
        Source = R6path
End Select

FileCopy Source, Target
Duplicate_Click
FreeRobot = -(CInt(R2Present) + CInt(R3Present) + CInt(R4Present) + CInt(R5Present) + CInt(R6Present) - 1)

NameVar1 = CommonDialog3.FileTitle              'Tar bort .RWR från namnet
namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
NameVar1 = Left$(NameVar1, namevar2)

Select Case FreeRobot
    Case 2
        R2path = Target
        Robot2.Caption = NameVar1
    Case 3
        R3path = Target
        Robot3.Caption = NameVar1
    Case 4
        R4path = Target
        Robot4.Caption = NameVar1
    Case 5
        R5path = Target
        Robot5.Caption = NameVar1
    Case 6
        R6path = Target
        Robot6.Caption = NameVar1
End Select

didcancel:
End Sub

Private Sub Scoring_Click()
If Scoring.Caption = "Scoring: Standard" Then
    Scoring.Caption = "Scoring: Mac (4.5.2)"
    Put 7, 2500, True
    StandardScoring = False
Else
    Scoring.Caption = "Scoring: Standard"
    Put 7, 2500, False
    StandardScoring = True
End If

End Sub

Private Sub SetGameSpeed_Click()
'TheSpeedConstant = 1

RepeatSpeed:
On Error GoTo TooHigh

Dim res As Variant

res = InputBox("Please type the in how fast you would like the game running (relative value). Standard = 100." & vbCr & vbCr & "Will only affect the game when Normal, Slower or Slowest is chosen.", "Set Speed", (1 / TheSpeedConstant) * 100)
If res = "" Then Exit Sub

If IsNumeric(res) And res > 0 And res <= 2000000000 Then
    TheSpeedConstant = res / 100
    TheSpeedConstant = 1 / TheSpeedConstant
    Put 7, 12500, TheSpeedConstant
    If Normal.Checked Then
        Normal_Click
    ElseIf Slow.Checked Then
        Slow_Click
    ElseIf Slower.Checked Then
        Slower_Click
    ElseIf Slowest.Checked Then
        Slowest_Click
    End If
Else
    If MsgBox("Invalid value entered. Highest allowed is 2 000 000 000. Would you like to try again?", vbYesNo) = vbYes Then GoTo RepeatSpeed
End If

TooHigh:
If Err <> 0 Then
    If MsgBox("Invalid value entered. Highest allowed is 2 000 000 000. Would you like to try again?", vbYesNo) = vbYes Then Resume RepeatSpeed
End If

End Sub

Private Sub ShowMoveAndShoot_Click()
ShowMoveAndShoot.Checked = Not ShowMoveAndShoot.Checked
'Put 7, 6500, ShowMoveAndShoot.Checked
End Sub

Private Sub Slow_Click()
Slow.Checked = True
Slower.Checked = False
Slowest.Checked = False
Normal.Checked = False
Fast.Checked = False
NoDisplay.Checked = False
AutoRedrawFast.Checked = False  'ny
Ultra.Checked = False
HideBattle = False

Dim RSpeed As Long                  'Speed
RSpeed = 3
Put 7, 11000, RSpeed
    
BattleSpeed = (1 / 30) * TheSpeedConstant

'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = True
If Sounds.Checked Then PlaySounds = True

Sounds.Enabled = True
Arena.AutoRedraw = True
End Sub

Private Sub Slower_Click()
Slow.Checked = False
Slower.Checked = True
Slowest.Checked = False
Normal.Checked = False
Fast.Checked = False
NoDisplay.Checked = False
AutoRedrawFast.Checked = False  'ny
Ultra.Checked = False
HideBattle = False

Dim RSpeed As Long                  'Speed
RSpeed = 2
Put 7, 11000, RSpeed

BattleSpeed = (1 / 12) * TheSpeedConstant

'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = True
If Sounds.Checked Then PlaySounds = True

Sounds.Enabled = True
Arena.AutoRedraw = True
End Sub
Private Sub Slowest_Click()
Slow.Checked = False
Slower.Checked = False
Slowest.Checked = True
Normal.Checked = False
Fast.Checked = False
NoDisplay.Checked = False
AutoRedrawFast.Checked = False  'ny
Ultra.Checked = False
HideBattle = False

Dim RSpeed As Long                  'Speed
RSpeed = 1
Put 7, 11000, RSpeed

BattleSpeed = 0.5 * TheSpeedConstant

'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = True
 If Sounds.Checked Then PlaySounds = True
   
Sounds.Enabled = True
Arena.AutoRedraw = True
End Sub
Private Sub Normal_Click()
Slow.Checked = False
Slower.Checked = False
Slowest.Checked = False
Normal.Checked = True
Fast.Checked = False
NoDisplay.Checked = False
AutoRedrawFast.Checked = False  'ny
Ultra.Checked = False
HideBattle = False

Dim RSpeed As Long                  'Speed
RSpeed = 4
Put 7, 11000, RSpeed

BattleSpeed = (1 / 70) * TheSpeedConstant

'If AutoNoSound.Checked And Sounds.Checked Then
'    PlaySounds = True
'End If
If Sounds.Checked Then PlaySounds = True

Sounds.Enabled = True
Arena.AutoRedraw = True
End Sub

Private Sub Fast_Click()
Slow.Checked = False
Slower.Checked = False
Slowest.Checked = False
Normal.Checked = False
Fast.Checked = True
NoDisplay.Checked = False
Ultra.Checked = False
AutoRedrawFast.Checked = False  'ny
HideBattle = False

Dim RSpeed As Long                  'Speed
    RSpeed = 5
    Put 7, 11000, RSpeed
BattleSpeed = 1E-37

'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = False
'
'If AutoNoSound.Checked Then Sounds.Enabled = False
PlaySounds = False
Sounds.Enabled = False

Arena = LoadPicture()

Arena.AutoRedraw = False
End Sub

Private Sub AutoRedrawFast_Click()
Slow.Checked = False
Slower.Checked = False
Slowest.Checked = False
Normal.Checked = False
Fast.Checked = False
AutoRedrawFast.Checked = True
NoDisplay.Checked = False
Ultra.Checked = False
HideBattle = False

Dim RSpeed As Long                  'Speed
RSpeed = 6
Put 7, 11000, RSpeed

BattleSpeed = 1E-37

'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = False
'If AutoNoSound.Checked Then Sounds.Enabled = False
PlaySounds = False
Sounds.Enabled = False

Arena.AutoRedraw = True
End Sub

Private Sub NoDisplay_Click()
Slow.Checked = False
Slower.Checked = False
Slowest.Checked = False
Normal.Checked = False
Fast.Checked = False
NoDisplay.Checked = True
Ultra.Checked = False
AutoRedrawFast.Checked = False  'ny
HideBattle = True

Dim RSpeed As Long                  'Speed
    RSpeed = 7
    Put 7, 11000, RSpeed
BattleSpeed = 1E-37

'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = False
'If AutoNoSound.Checked Then Sounds.Enabled = False
PlaySounds = False
Sounds.Enabled = False

Arena = LoadPicture()
Arena.AutoRedraw = False
End Sub

Private Sub Ultra_Click()
    Dim res As Integer
    
    If UltraWarning <> 250 Then
    res = MsgBox("The Ultra Speed Mode (Fastest) will drain time from Windows (and other programs) to RoboWar." & _
    "This means playing mp3 in the background or surfing internet might not work while on ultra. Are you sure " & _
    "you want to enable ultra?" & vbCr & vbCr & "(If you don't want to see this message again, press Cancel.)", _
    vbYesNoCancel, "Enable Ultra?")
    End If

    If res = vbYes Or res = vbCancel Or res = 0 Then
        Slow.Checked = False
        Slower.Checked = False
        Slowest.Checked = False
        Normal.Checked = False
        Fast.Checked = False
        NoDisplay.Checked = False
        Ultra.Checked = True
        AutoRedrawFast.Checked = False  'ny
        HideBattle = True
        
        Dim RSpeed As Long                  'Speed
            RSpeed = 8
            Put 7, 11000, RSpeed
        BattleSpeed = 1E-37
        
'        If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = False
'        If AutoNoSound.Checked Then Sounds.Enabled = False
PlaySounds = False
Sounds.Enabled = False
        
        Arena = LoadPicture()
        Arena.AutoRedraw = False
        
        If res = vbCancel Then
            UltraWarning = 250
            Put 7, 7500, UltraWarning
        End If
    End If
End Sub

Private Sub Sounds_Click()
Dim YesOrNo As Boolean

If Sounds.Checked Then
    Sounds.Checked = False
    YesOrNo = False
    Put 7, 1000, YesOrNo
    PlaySounds = False
Else
    Sounds.Checked = True
    YesOrNo = True
    Put 7, 1000, YesOrNo
    PlaySounds = True
End If

End Sub

Private Sub LoadRobot_Click()
NotRandomEmergency = False

Dim NameVar1 As String  '-:-
Dim namevar2 As Long '-:-

CommonDialog1.ShowOpen

If CommonDialog1.FileName = "" Then Exit Sub

If CommonDialog1.InitDir <> "" Then CommonDialog1.InitDir = ""      'Nytt

If R1Present = False Then
    NameVar1 = CommonDialog1.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot1.Caption = Left$(NameVar1, namevar2)
    
    R1Present = True
    R1path = CommonDialog1.FileName
    Load2.Visible = True

    CommonDialog1.FileName = ""
    SelectedRobot = 1
    Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    LoadRobot1
    GoTo OpenNoMoreRobot
ElseIf R2Present = False Then
    NameVar1 = CommonDialog1.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot2.Caption = Left$(NameVar1, namevar2)
    
    R2Present = True
    R2path = CommonDialog1.FileName
    Load2.Visible = True
    Load3.Visible = True

    CommonDialog1.FileName = ""
    SelectedRobot = 2
    Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = vbBlack: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    LoadRobot2
    GoTo OpenNoMoreRobot
ElseIf R3Present = False Then
    NameVar1 = CommonDialog1.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot3.Caption = Left$(NameVar1, namevar2)
    
    R3Present = True
    R3path = CommonDialog1.FileName
    Load3.Visible = True
    Load4.Visible = True
    
    CommonDialog1.FileName = ""
    SelectedRobot = 3
    Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = vbBlack: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    LoadRobot3
    GoTo OpenNoMoreRobot
ElseIf R4Present = False Then
    NameVar1 = CommonDialog1.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot4.Caption = Left$(NameVar1, namevar2)
    
    R4Present = True
    R4path = CommonDialog1.FileName
    Load4.Visible = True
    Load5.Visible = True
    
    CommonDialog1.FileName = ""
    SelectedRobot = 4
    Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = vbBlack: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    LoadRobot4
    GoTo OpenNoMoreRobot
ElseIf R5Present = False Then
    NameVar1 = CommonDialog1.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot5.Caption = Left$(NameVar1, namevar2)
    
    R5Present = True
    R5path = CommonDialog1.FileName
    Load5.Visible = True
    Load6.Visible = True
    
    CommonDialog1.FileName = ""
    SelectedRobot = 5
    Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = vbBlack: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
    LoadRobot5
    GoTo OpenNoMoreRobot
ElseIf R6Present = False Then
    NameVar1 = CommonDialog1.FileTitle              'Tar bort .RWR från namnet
    namevar2 = Len(NameVar1) - 4                    'Removes .RWR from the name
    Robot6.Caption = Left$(NameVar1, namevar2)
    
    R6Present = True
    R6path = CommonDialog1.FileName
    Load6.Visible = True

    NewRobot.Enabled = False
    LoadRobot.Enabled = False
    Duplicate.Enabled = False
    SaveAs.Enabled = False
    CommonDialog1.FileName = ""
    SelectedRobot = 6
    Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = vbBlack: Robot6.ForeColor = vbWhite
    LoadRobot6
End If

OpenNoMoreRobot:
If Not Replaying Then ResetHistory_Click
End Sub

Public Function CheckInvalid(TheNumber As Byte) As Boolean
If TheNumber = 1 Or TheNumber = 0 Then CheckInvalid = False Else CheckInvalid = True
End Function

Private Sub Conversion(RobotNr As Long)
    Close 254

    If MsgBox("This is not a New RWR Windows Robot. This robot might be using the old multifile robot format." & vbCr & _
            "Would you like it to have it converted to the new file format?" & vbCr & vbCr & "A backup copy of the old robot will be saved in" & vbCr & App.Path & "\Backups\" & vbCr & "before converting.", vbOKCancel + vbQuestion, "Loading Robot") = vbOK Then
        Convert (RobotNr)
    Else
        SelectedRobot = RobotNr
        Close_Click
    End If
End Sub

Private Sub Convert(RobotNr As Long)
On Error GoTo failed

Dim robotpath As String
Dim RobotCode As String
Dim c As Long
Dim TheNewRobot As Robot
Dim RecordIcon(9) As String
Dim RecordSound(9) As String
Dim RobotNameOnly As String
Dim NameVar1 As String

If Dir(App.Path & "\Backups\", vbDirectory) = "" Then
    MkDir App.Path & "\Backups\"
End If

Select Case RobotNr
    Case 1
        robotpath = R1path
        NameVar1 = StrReverse$(robotpath)
        NameVar1 = Right$(robotpath, InStr(NameVar1, "\") - 1)
        RobotNameOnly = Left$(NameVar1, Len(NameVar1))
        FileCopy robotpath, App.Path & "\Backups\" & RobotNameOnly
    Case 2
        robotpath = R2path
        NameVar1 = StrReverse$(robotpath)
        NameVar1 = Right$(robotpath, InStr(NameVar1, "\") - 1)
        RobotNameOnly = Left$(NameVar1, Len(NameVar1))
        FileCopy robotpath, App.Path & "\Backups\" & RobotNameOnly
    Case 3
        robotpath = R3path
        NameVar1 = StrReverse$(robotpath)
        NameVar1 = Right$(robotpath, InStr(NameVar1, "\") - 1)
        RobotNameOnly = Left$(NameVar1, Len(NameVar1))
        FileCopy robotpath, App.Path & "\Backups\" & RobotNameOnly
    Case 4
        robotpath = R4path
        NameVar1 = StrReverse$(robotpath)
        NameVar1 = Right$(robotpath, InStr(NameVar1, "\") - 1)
        RobotNameOnly = Left$(NameVar1, Len(NameVar1))
        FileCopy robotpath, App.Path & "\Backups\" & RobotNameOnly
    Case 5
        robotpath = R5path
        NameVar1 = StrReverse$(robotpath)
        NameVar1 = Right$(robotpath, InStr(NameVar1, "\") - 1)
        RobotNameOnly = Left$(NameVar1, Len(NameVar1))
        FileCopy robotpath, App.Path & "\Backups\" & RobotNameOnly
    Case 6
        robotpath = R6path
        NameVar1 = StrReverse$(robotpath)
        NameVar1 = Right$(robotpath, InStr(NameVar1, "\") - 1)
        RobotNameOnly = Left$(NameVar1, Len(NameVar1))
        FileCopy robotpath, App.Path & "\Backups\" & RobotNameOnly
End Select

Dim PathNoExt As String
PathNoExt = Left(robotpath, Len(robotpath) - 4)

Dim TheRobot As String
Dim hardwaretag As String
Dim icontag As String
Dim machinecodetag As String

Open robotpath For Input As #1
TheRobot = Input(LOF(1), 1)

Dim tagstart As Long

tagstart = InStr(TheRobot, "<Code>") + 7
RobotCode = Mid(TheRobot, tagstart, InStr(TheRobot, "</Code>") - tagstart)

tagstart = InStr(TheRobot, "<Hardware>") + 11
hardwaretag = Mid(TheRobot, tagstart, InStr(TheRobot, "</Hardware>") - tagstart)

tagstart = InStr(TheRobot, "<Icon>") + 7
icontag = Mid(TheRobot, tagstart, InStr(TheRobot, "</Icon>") - tagstart)

tagstart = InStr(TheRobot, "<Machinecode>") + 14
machinecodetag = Mid(TheRobot, tagstart, InStr(TheRobot, "</Machinecode>") - tagstart)

Close 1

Dim ha() As String
Dim iA() As String

ha = Split(hardwaretag, vbCr)
iA = Split(icontag, vbCr)

For c = 0 To 2
ha(c) = Val(Right(ha(c), 3))
Next c

For c = 3 To 13 'UBound(ha)
ha(c) = Val(Right(ha(c), 2))
Next c

For c = 0 To 4 'UBound(ia)
iA(c) = Val(Right(iA(c), 1))
Next c

With TheNewRobot
.Energy = ha(0)
.Damage = ha(1)
.Shield = ha(2)
.Prosessor = ha(3)
.Bullets = ha(4)
.Turret = ha(5)
.Missiles = ha(6)
.TacNukes = ha(7)
.Hellbores = ha(8)
.Mines = ha(9)
.Stunners = ha(10)
.Drones = ha(11)
.Lasers = ha(12)
.Probes = ha(13)
.ShieldIcon = iA(0)
.DeathIcon = iA(1)
.CollisionIcon = iA(2)
.BlockIcon = iA(3)
.HitIcon = iA(4)
End With

 Dim ma() As String
 ma = Split(machinecodetag, vbCr)

Dim MachineCode() As Integer 'Long
ReDim MachineCode(UBound(ma) - 1)

For c = 0 To UBound(MachineCode)
MachineCode(c) = Inst2MagicNumber(ma(c))
Next c

For c = 0 To 9
    If Dir(PathNoExt & "#" & c & ".ico") <> "" Then
        Open PathNoExt & "#" & c & ".ico" For Binary As #1
           RecordIcon(c) = Input(LOF(1), #1)
        Close 1
    Else
        RecordIcon(c) = ""
    End If
Next c
For c = 0 To 9
    If Dir(PathNoExt & "#" & c & ".WAV") <> "" Then
        Open PathNoExt & "#" & c & ".WAV" For Binary As #1
           RecordSound(c) = Input(LOF(1), #1)
        Close 1
    Else
        RecordSound(c) = ""
    End If
Next c
'''''''''''''''''''''''''''''''''''''''
Kill robotpath 'fixar Norobot bugget

Dim RecIconStart(9) As Long
Dim RecSoundStart(9) As Long
Dim MCStart As Long
Dim Cstart As Long
Dim IconExists(9) As Byte
Dim SoundExists(9) As Byte

RecSoundStart(0) = recsoundstartzero
For c = 0 To 8
RecSoundStart(c + 1) = RecSoundStart(c) + Len(RecordSound(c))
Next c

RecIconStart(0) = RecSoundStart(9) + Len(RecordSound(9))

For c = 0 To 8
    RecIconStart(c + 1) = RecIconStart(c) + Len(RecordIcon(c))
Next c
MCStart = RecIconStart(9) + Len(RecordIcon(9))
Cstart = MCStart + (UBound(MachineCode) + 1) * 2

For c = 0 To 9
    If RecordIcon(c) = "" Then IconExists(c) = 0 Else IconExists(c) = 1
    If RecordSound(c) = "" Then SoundExists(c) = 0 Else SoundExists(c) = 1
Next c

Open robotpath For Binary As #1
Put #1, , TheNewRobot
Put #1, iconrec, RecIconStart
Put #1, sndrec, RecSoundStart
Put #1, zeroexists, IconExists
Put #1, soundspresent, SoundExists
Put #1, MCrec, MCStart
Put #1, Crec, Cstart

For c = 0 To 9
    If IconExists(c) <> 0 Then Put #1, RecIconStart(c), RecordIcon(c)
    If SoundExists(c) <> 0 Then Put #1, RecSoundStart(c), RecordSound(c)
Next c

Put #1, MCStart, MachineCode
Put #1, Cstart, RobotCode & vbCr    'I have no idea why, but it Seems to need a cr to work properly

Close #1

Select Case RobotNr
    Case 1
        LoadRobot1
    Case 2
        LoadRobot2
    Case 3
        LoadRobot3
    Case 4
        LoadRobot4
    Case 5
        LoadRobot5
    Case 6
        LoadRobot6
End Select

robotpath = Left(robotpath, Len(robotpath) - 4)
RobotNameOnly = Left(RobotNameOnly, Len(RobotNameOnly) - 4)

For c = 0 To 9
    If Dir(robotpath & "#" & c & ".ico") <> "" Then
        FileCopy robotpath & "#" & c & ".ico", App.Path & "\Backups\" & RobotNameOnly & "#" & c & ".ico"
        Kill robotpath & "#" & c & ".ico"
    End If
    If Dir(robotpath & "#" & c & ".WAV") <> "" Then
        FileCopy robotpath & "#" & c & ".WAV", App.Path & "\Backups\" & RobotNameOnly & "#" & c & ".WAV"
        Kill robotpath & "#" & c & ".WAV"
    End If
Next c

Exit Sub

failed:
MsgBox "Totally =(. The bot might be destroyed.", vbExclamation, "Robot failed conversion"
Close 1

SelectedRobot = RobotNr
Close_Click
End Sub

'LADDA ROBOT 1 - LOAD ROBOT 1
Private Sub LoadRobot1()
Dim TheRobot As Robot
Dim RecIconStart(1) As Long
Dim IconZeroExists As Byte
Dim IconZero As String

Open R1path For Binary As #254

    Get #254, , TheRobot

    If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or _
        CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or _
        CheckInvalid(TheRobot.Hellbores) Or _
        CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or _
        CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or _
        CheckInvalid(TheRobot.TacNukes) Then
            Conversion (1)
        Exit Sub
    End If

    Get #254, iconrec, RecIconStart
    Get #254, zeroexists, IconZeroExists
    
    If IconZeroExists <> 0 Then
        IconZero = Space(RecIconStart(1) - RecIconStart(0))
        Get #254, RecIconStart(0), IconZero
        R1Icon = LoadRobotIcon(IconZero)
    Else
        R1Icon = LoadPicture(App.Path & "\miscdata\1#0.ico")
    End If

    Dim RNN As Long
    Dim InputInsts(4999) As Integer

    Get #254, MCrec, RNN
    Get #254, RNN, InputInsts

    For RNN = 0 To 4999
        MasterCode(1, RNN) = InputInsts(RNN)
        If InputInsts(RNN) = insEND Then Exit For
    Next RNN
Close #254

Points1X.Visible = True
PR1.Visible = True
'PR1.Caption = 0

Robot1DeathIcon = TheRobot.DeathIcon
Robot1CollisionIcon = TheRobot.CollisionIcon
Robot1BlockIcon = TheRobot.BlockIcon
Robot1HitIcon = TheRobot.HitIcon
Robot1ShieldIcon = TheRobot.ShieldIcon

Robot1Energy = TheRobot.Energy
ER(1).Caption = Robot1Energy
ER(1).Visible = True
Energy1X.Visible = True
Robot1Damage = TheRobot.Damage
DR(1).Caption = Robot1Damage
DR(1).Visible = True
Damage1X.Visible = True

Robot1Shield = TheRobot.Shield
Robot1ProSpeed = TheRobot.Prosessor
Robot1Bullets = TheRobot.Bullets
Robot1Turret = TheRobot.Turret
Robot1Missiles = TheRobot.Missiles
Robot1TacNukes = TheRobot.TacNukes
Robot1Hellbores = TheRobot.Hellbores
Robot1Mines = TheRobot.Mines
Robot1Stunners = TheRobot.Stunners
Robot1Drones = TheRobot.Drones
Robot1Lasers = TheRobot.Lasers
Robot1Probes = TheRobot.Probes
End Sub

'LADDA ROBOT 2 - LOAD ROBOT 2
Private Sub LoadRobot2()
Dim TheRobot As Robot
Dim RecIconStart(1) As Long
Dim IconZeroExists As Byte
Dim IconZero As String

Open R2path For Binary As #254

    Get #254, , TheRobot
'
    If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or _
        CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or _
        CheckInvalid(TheRobot.Hellbores) Or _
        CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or _
        CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or _
        CheckInvalid(TheRobot.TacNukes) Then
            Conversion (2)
        Exit Sub
    End If
'
    Get #254, iconrec, RecIconStart
    Get #254, zeroexists, IconZeroExists
    
    If IconZeroExists <> 0 Then
        IconZero = Space(RecIconStart(1) - RecIconStart(0))
        Get #254, RecIconStart(0), IconZero
        R2Icon = LoadRobotIcon(IconZero)
    Else
        R2Icon = LoadPicture(App.Path & "\miscdata\2#0.ico")
    End If

    Dim RNN As Long
    Dim InputInsts(4999) As Integer

    Get #254, MCrec, RNN
    Get #254, RNN, InputInsts

    For RNN = 0 To 4999
        MasterCode(2, RNN) = InputInsts(RNN)
        If InputInsts(RNN) = insEND Then Exit For
    Next RNN
Close #254

Points2X.Visible = True
PR2.Visible = True
'PR2.Caption = 0

Robot2DeathIcon = TheRobot.DeathIcon
Robot2CollisionIcon = TheRobot.CollisionIcon
Robot2BlockIcon = TheRobot.BlockIcon
Robot2HitIcon = TheRobot.HitIcon
Robot2ShieldIcon = TheRobot.ShieldIcon

Robot2Energy = TheRobot.Energy
ER(2).Caption = Robot2Energy
ER(2).Visible = True
Energy2X.Visible = True
Robot2Damage = TheRobot.Damage
DR(2).Caption = Robot2Damage
DR(2).Visible = True
Damage2X.Visible = True

Robot2Shield = TheRobot.Shield
Robot2ProSpeed = TheRobot.Prosessor
Robot2Bullets = TheRobot.Bullets
Robot2Turret = TheRobot.Turret
Robot2Missiles = TheRobot.Missiles
Robot2TacNukes = TheRobot.TacNukes
Robot2Hellbores = TheRobot.Hellbores
Robot2Mines = TheRobot.Mines
Robot2Stunners = TheRobot.Stunners
Robot2Drones = TheRobot.Drones
Robot2Lasers = TheRobot.Lasers
Robot2Probes = TheRobot.Probes
End Sub

'LADDA ROBOT 3 - LOAD ROBOT 3
Private Sub LoadRobot3()
Dim TheRobot As Robot
Dim RecIconStart(1) As Long
Dim IconZeroExists As Byte
Dim IconZero As String

Open R3path For Binary As #254

    Get #254, , TheRobot
'
    If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or _
        CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or _
        CheckInvalid(TheRobot.Hellbores) Or _
        CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or _
        CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or _
        CheckInvalid(TheRobot.TacNukes) Then
            Conversion (3)
        Exit Sub
    End If
'
    Get #254, iconrec, RecIconStart
    Get #254, zeroexists, IconZeroExists
    
    If IconZeroExists <> 0 Then
        IconZero = Space(RecIconStart(1) - RecIconStart(0))
        Get #254, RecIconStart(0), IconZero
        R3Icon = LoadRobotIcon(IconZero)
    Else
        R3Icon = LoadPicture(App.Path & "\miscdata\3#0.ico")
    End If

    Dim RNN As Long
    Dim InputInsts(4999) As Integer

    Get #254, MCrec, RNN
    Get #254, RNN, InputInsts

    For RNN = 0 To 4999
        MasterCode(3, RNN) = InputInsts(RNN)
        If InputInsts(RNN) = insEND Then Exit For
    Next RNN
Close #254

Points3X.Visible = True
PR3.Visible = True
'PR3.Caption = 0

Robot3DeathIcon = TheRobot.DeathIcon
Robot3CollisionIcon = TheRobot.CollisionIcon
Robot3BlockIcon = TheRobot.BlockIcon
Robot3HitIcon = TheRobot.HitIcon
Robot3ShieldIcon = TheRobot.ShieldIcon

Robot3Energy = TheRobot.Energy
ER(3).Caption = Robot3Energy
ER(3).Visible = True
Energy3X.Visible = True
Robot3Damage = TheRobot.Damage
DR(3).Caption = Robot3Damage
DR(3).Visible = True
Damage3X.Visible = True

Robot3Shield = TheRobot.Shield
Robot3ProSpeed = TheRobot.Prosessor
Robot3Bullets = TheRobot.Bullets
Robot3Turret = TheRobot.Turret
Robot3Missiles = TheRobot.Missiles
Robot3TacNukes = TheRobot.TacNukes
Robot3Hellbores = TheRobot.Hellbores
Robot3Mines = TheRobot.Mines
Robot3Stunners = TheRobot.Stunners
Robot3Drones = TheRobot.Drones
Robot3Lasers = TheRobot.Lasers
Robot3Probes = TheRobot.Probes
End Sub

'LADDA ROBOT 4 - LOAD ROBOT 4
Private Sub LoadRobot4()
Dim TheRobot As Robot
Dim RecIconStart(1) As Long
Dim IconZeroExists As Byte
Dim IconZero As String

Open R4path For Binary As #254

    Get #254, , TheRobot
'
    If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or _
        CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or _
        CheckInvalid(TheRobot.Hellbores) Or _
        CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or _
        CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or _
        CheckInvalid(TheRobot.TacNukes) Then
            Conversion (4)
        Exit Sub
    End If
'
    Get #254, iconrec, RecIconStart
    Get #254, zeroexists, IconZeroExists
    
    If IconZeroExists <> 0 Then
        IconZero = Space(RecIconStart(1) - RecIconStart(0))
        Get #254, RecIconStart(0), IconZero
        R4Icon = LoadRobotIcon(IconZero)
    Else
        R4Icon = LoadPicture(App.Path & "\miscdata\4#0.ico")
    End If

    Dim RNN As Long
    Dim InputInsts(4999) As Integer

    Get #254, MCrec, RNN
    Get #254, RNN, InputInsts

    For RNN = 0 To 4999
        MasterCode(4, RNN) = InputInsts(RNN)
        If InputInsts(RNN) = insEND Then Exit For
    Next RNN
Close #254

Points4X.Visible = True
PR4.Visible = True
'PR4.Caption = 0

Robot4DeathIcon = TheRobot.DeathIcon
Robot4CollisionIcon = TheRobot.CollisionIcon
Robot4BlockIcon = TheRobot.BlockIcon
Robot4HitIcon = TheRobot.HitIcon
Robot4ShieldIcon = TheRobot.ShieldIcon

Robot4Energy = TheRobot.Energy
ER(4).Caption = Robot4Energy
ER(4).Visible = True
Energy4X.Visible = True
Robot4Damage = TheRobot.Damage
DR(4).Caption = Robot4Damage
DR(4).Visible = True
Damage4X.Visible = True

Robot4Shield = TheRobot.Shield
Robot4ProSpeed = TheRobot.Prosessor
Robot4Bullets = TheRobot.Bullets
Robot4Turret = TheRobot.Turret
Robot4Missiles = TheRobot.Missiles
Robot4TacNukes = TheRobot.TacNukes
Robot4Hellbores = TheRobot.Hellbores
Robot4Mines = TheRobot.Mines
Robot4Stunners = TheRobot.Stunners
Robot4Drones = TheRobot.Drones
Robot4Lasers = TheRobot.Lasers
Robot4Probes = TheRobot.Probes
End Sub

'LADDA ROBOT 5 - LOAD ROBOT 5
Private Sub LoadRobot5()
Dim TheRobot As Robot
Dim RecIconStart(1) As Long
Dim IconZeroExists As Byte
Dim IconZero As String

Open R5path For Binary As #254

    Get #254, , TheRobot
'
    If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or _
        CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or _
        CheckInvalid(TheRobot.Hellbores) Or _
        CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or _
        CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or _
        CheckInvalid(TheRobot.TacNukes) Then
            Conversion (5)
        Exit Sub
    End If
'
    Get #254, iconrec, RecIconStart
    Get #254, zeroexists, IconZeroExists
    
    If IconZeroExists <> 0 Then
        IconZero = Space(RecIconStart(1) - RecIconStart(0))
        Get #254, RecIconStart(0), IconZero
        R5Icon = LoadRobotIcon(IconZero)
    Else
        R5Icon = LoadPicture(App.Path & "\miscdata\5#0.ico")
    End If

    Dim RNN As Long
    Dim InputInsts(4999) As Integer

    Get #254, MCrec, RNN
    Get #254, RNN, InputInsts

    For RNN = 0 To 4999
        MasterCode(5, RNN) = InputInsts(RNN)
        If InputInsts(RNN) = insEND Then Exit For
    Next RNN
Close #254

Points5X.Visible = True
PR5.Visible = True
'PR5.Caption = 0

Robot5DeathIcon = TheRobot.DeathIcon
Robot5CollisionIcon = TheRobot.CollisionIcon
Robot5BlockIcon = TheRobot.BlockIcon
Robot5HitIcon = TheRobot.HitIcon
Robot5ShieldIcon = TheRobot.ShieldIcon

Robot5Energy = TheRobot.Energy
ER(5).Caption = Robot5Energy
ER(5).Visible = True
Energy5X.Visible = True
Robot5Damage = TheRobot.Damage
DR(5).Caption = Robot5Damage
DR(5).Visible = True
Damage5X.Visible = True

Robot5Shield = TheRobot.Shield
Robot5ProSpeed = TheRobot.Prosessor
Robot5Bullets = TheRobot.Bullets
Robot5Turret = TheRobot.Turret
Robot5Missiles = TheRobot.Missiles
Robot5TacNukes = TheRobot.TacNukes
Robot5Hellbores = TheRobot.Hellbores
Robot5Mines = TheRobot.Mines
Robot5Stunners = TheRobot.Stunners
Robot5Drones = TheRobot.Drones
Robot5Lasers = TheRobot.Lasers
Robot5Probes = TheRobot.Probes
End Sub


'LADDA ROBOT 6 - LOAD ROBOT 6
Private Sub LoadRobot6()
Dim TheRobot As Robot
Dim RecIconStart(1) As Long
Dim IconZeroExists As Byte
Dim IconZero As String

Open R6path For Binary As #254

    Get #254, , TheRobot
'
    If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or _
        CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or _
        CheckInvalid(TheRobot.Hellbores) Or _
        CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or _
        CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or _
        CheckInvalid(TheRobot.TacNukes) Then
            Conversion (6)
        Exit Sub
    End If
'
    Get #254, iconrec, RecIconStart
    Get #254, zeroexists, IconZeroExists
    
    If IconZeroExists <> 0 Then
        IconZero = Space(RecIconStart(1) - RecIconStart(0))
        Get #254, RecIconStart(0), IconZero
        R6Icon = LoadRobotIcon(IconZero)
    Else
        R6Icon = LoadPicture(App.Path & "\miscdata\6#0.ico")
    End If

    Dim RNN As Long
    Dim InputInsts(4999) As Integer

    Get #254, MCrec, RNN
    Get #254, RNN, InputInsts

    For RNN = 0 To 4999
        MasterCode(6, RNN) = InputInsts(RNN)
        If InputInsts(RNN) = insEND Then Exit For
    Next RNN
Close #254

Points6X.Visible = True
PR6.Visible = True
'PR6.Caption = 0

Robot6DeathIcon = TheRobot.DeathIcon
Robot6CollisionIcon = TheRobot.CollisionIcon
Robot6BlockIcon = TheRobot.BlockIcon
Robot6HitIcon = TheRobot.HitIcon
Robot6ShieldIcon = TheRobot.ShieldIcon

Robot6Energy = TheRobot.Energy
ER(6).Caption = Robot6Energy
ER(6).Visible = True
Energy6X.Visible = True
Robot6Damage = TheRobot.Damage
DR(6).Caption = Robot6Damage
DR(6).Visible = True
Damage6X.Visible = True

Robot6Shield = TheRobot.Shield
Robot6ProSpeed = TheRobot.Prosessor
Robot6Bullets = TheRobot.Bullets
Robot6Turret = TheRobot.Turret
Robot6Missiles = TheRobot.Missiles
Robot6TacNukes = TheRobot.TacNukes
Robot6Hellbores = TheRobot.Hellbores
Robot6Mines = TheRobot.Mines
Robot6Stunners = TheRobot.Stunners
Robot6Drones = TheRobot.Drones
Robot6Lasers = TheRobot.Lasers
Robot6Probes = TheRobot.Probes
End Sub

Private Sub StartAtChronon_Click()
If RunningTournament Then Exit Sub

If Not R1Present Then
    MsgBox "There is no Robot present to debug.", vbOKOnly, "No Robot Present"
    Exit Sub
End If

Dim inputval As Variant
Dim c As Integer
Dim CrashTime As Long
CrashTime = DEBUGATNOTSET

For c = 1 To 6
    If InStr(RobotDead(c), "Buggy - Time: ") <> 0 And RobotDead(c).Visible Then
        CrashTime = Val(Replace(RobotDead(c), "Buggy - Time: ", "")) - 1
        WillBeDebugged = c
        Exit For
    End If
Next c

If CrashTime = DEBUGATNOTSET Then
    For c = 1 To 6
        If InStr(RobotDead(c), "Overloaded - Time: ") <> 0 And RobotDead(c).Visible Then
            CrashTime = Val(Replace(RobotDead(c), "Overloaded - Time: ", "")) - 1
            WillBeDebugged = c
            Exit For
        End If
    Next c
End If

If CrashTime = DEBUGATNOTSET Then
    For c = 1 To 6
        If InStr(RobotDead(c), "Dead - Time: ") <> 0 And RobotDead(c).Visible Then
            CrashTime = Val(Replace(RobotDead(c), "Dead - Time: ", "")) - 5
            WillBeDebugged = c
            Exit For
        End If
    Next c
End If

If StartDebuggerAt = DEBUGATNOTSET Then
    If CrashTime < 0 Then CrashTime = 10
    If WillBeDebugged < 1 Then WillBeDebugged = 1
Else
    CrashTime = StartDebuggerAt
End If

Retry:
inputval = InputBox("Please select the chronon when to start the debugger" & vbCr & "To disable debugger from starting at a certain chronon, enter a negative value.", "Start Debugger at", CrashTime)

If IsNumeric(inputval) And inputval >= 0 Then
    StartDebuggerAt = inputval
retry2:
    inputval = InputBox("Debug Robot number", "Start Debugger at", WillBeDebugged)
    If IsNumeric(inputval) And inputval >= 1 And inputval <= 6 Then     'Everything's fine
        WillBeDebugged = inputval
        If Not Replaying Then RepeatBattle_Click
        'Fast_Click
        If HideBattle Then Normal_Click  'disk
        
        If DebuggedRobot <> 0 Then
            DebuggedRobot = 0
            Image1(SelectedRobot).Visible = False
            Unload DebuggingWindow
        End If
    ElseIf (IsNumeric(inputval) And inputval <= 0) Or inputval = "" Then       'Pressed Cancel
        StartDebuggerAt = DEBUGATNOTSET
    Else            'Invalid Value
        If MsgBox("The value specified (" & inputval & ") is not a valid robot.", vbRetryCancel, "Start Debugger at") = vbRetry Then GoTo retry2
    End If
ElseIf (IsNumeric(inputval) And inputval <= 0) Or inputval = "" Then
    StartDebuggerAt = DEBUGATNOTSET
Else
    If MsgBox("The value specified (" & inputval & ") is not a valid chronon.", vbRetryCancel, "Can't start debugger this chronon ") = vbRetry Then GoTo Retry
End If

End Sub

Private Sub ChrononStart() 'This sub is required when the debugger is set to start at a certain chronon
If DebuggedRobot = 0 Then
    DebuggerAutoStart = True
    DebuggedRobot = WillBeDebugged  'For startdebuggerat
    Image1(DebuggedRobot).Visible = True
    
'    If Normal.Checked Then     'Onödigt?
'        Normal_Click
'    ElseIf Fast.Checked Then
'        Fast_Click
'    ElseIf AutoRedrawFast.Checked Then
'        AutoRedrawFast_Click
'    ElseIf Slow.Checked Then
'        Slow_Click
'    ElseIf Slower.Checked Then
'        Slower_Click
'    ElseIf Slowest.Checked Then
'        Slowest_Click
'    End If
End If
End Sub

Private Sub StopTournament_KeyDown(KeyCode As Integer, Shift As Integer)
Select Case KeyCode
    Case vbKey1
        Slowest_Click
    Case vbKey2
        Slower_Click
    Case vbKey3
        Slow_Click
    Case vbKey4
        Normal_Click
    Case vbKey5
        Fast_Click
    Case vbKey6
        NoDisplay_Click
    Case vbKey7
        Ultra_Click
End Select
End Sub

Private Sub Studio_Click()

If SelectedRobot < 1 Then
    MsgBox "Can't show Recording Studio because no robot is selected. To select a robot, use the PageUp and PageDown keys.", vbOKOnly, "No Robot Selected"
Else
    SoundEditor.Show 1, MainWindow
End If

End Sub

Private Sub Team1_Click()
If SelectedRobot >= 1 Then
RobotTeam(SelectedRobot) = 1
TeamLabel(SelectedRobot) = "Team 1"
TeamLabel(SelectedRobot).ForeColor = ColorTeam1 'RGB(18, 200, 241)
TeamLabel(SelectedRobot).Visible = True
End If
End Sub

Private Sub Team2_Click()
If SelectedRobot >= 1 Then
RobotTeam(SelectedRobot) = 2
TeamLabel(SelectedRobot) = "Team 2"
TeamLabel(SelectedRobot).ForeColor = ColorTeam2 'RGB(18, 241, 200)
TeamLabel(SelectedRobot).Visible = True
End If
End Sub

Private Sub Team3_Click()
If SelectedRobot >= 1 Then
RobotTeam(SelectedRobot) = 3
TeamLabel(SelectedRobot) = "Team 3"
TeamLabel(SelectedRobot).ForeColor = RGB(200, 241, 18) 'ColorTeam3 'RGB(200, 241, 18)
TeamLabel(SelectedRobot).Visible = True
End If
End Sub

Private Sub TestRobot_Click()
TestTourney.Show
End Sub

Private Sub TitleTimer_Timer()
If Len(sMainWindowCaption) > 0 Then Me.Caption = sMainWindowCaption
End Sub

Private Sub Tournament_Click()
TournamentD.Show
End Sub

Private Sub DeathAnimationInitz(RDN As Long, TheIconNumber As Long)
Dim RobotConstant As Long
RobotConstant = RDN * 10

If PlaySounds Then
    If RobotDeathSound(RDN) Then
        PlaySnd0 (RDN)
    Else
        sndPlaySound deathsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    End If
End If

If RobotDeathIcon(RDN) = 1 Then
    Set Robot_(RDN) = RobotMasterIcon(RobotConstant + 2)
Else
    If TheIconNumber >= 100 Then     'Switches off the collision/block/hit icons if it's on
        TheIconNumber = TheIconNumber - 100
        If TheIconNumber <> 10 Then Set Robot_(RDN) = RobotMasterIcon(RDN * 10 + TheIconNumber) Else Set Robot_(RDN) = RobotMasterIcon(RDN * 10 + 1)
    End If
End If

TurretX2(RDN) = RobotLeft(RDN)
TurretY2(RDN) = RobotTop(RDN)

DeathAnimation RDN, 255
End Sub

Private Sub DeathAnimation(RobotNr As Long, ByVal d As Long)
Dim RobotConstant As Long
RobotConstant = RobotNr * 10
d = 255 - d
Arena.PaintPicture Robot_(RobotNr), TurretX2(RobotNr) - d - 16, TurretY2(RobotNr) - d - 16, 16, 16, 0, 0, 16, 16
Arena.PaintPicture Robot_(RobotNr), TurretX2(RobotNr) + d, TurretY2(RobotNr) - d - 16, 16, 16, 16, 0, 16, 16
Arena.PaintPicture Robot_(RobotNr), TurretX2(RobotNr) + d, TurretY2(RobotNr) + d, 16, 16, 16, 16, 16, 16
Arena.PaintPicture Robot_(RobotNr), TurretX2(RobotNr) - d - 16, TurretY2(RobotNr) + d, 16, 16, 0, 16, 16, 16
End Sub

Private Sub MasterIconHandler()
'This sub loads the robots' specific icons and sounds

'ICONS
Dim RecIconStart(10) As Long    '10 is really the machine code start
Dim RecSoundStart(10) As Long   '10 is really the Icon 0 start
Dim RecordIcon(1 To 9) As String
Dim IconsExist(9) As Byte
Dim SoundsExist(9) As Byte
Dim c As Long
Dim d As Long

Set RobotMasterIcon(10) = R1Icon      'STANDARD ICON - (ICON0)

Open R1path For Binary As #1
If R2Present Then
    Open R2path For Binary As #2
    Set RobotMasterIcon(20) = R2Icon
    
    If R3Present Then
        Open R3path For Binary As #3
        Set RobotMasterIcon(30) = R3Icon
        
        If R4Present Then
            Open R4path For Binary As #4
            Set RobotMasterIcon(40) = R4Icon
            
            If R5Present Then
                Open R5path For Binary As #5
                Set RobotMasterIcon(50) = R5Icon
                
                If R6Present Then
                    Open R6path For Binary As #6
                    Set RobotMasterIcon(60) = R6Icon
                End If
            End If
        End If
    End If
End If

For d = 1 To NumberOfRobotsPresent
    Get #d, iconrec, RecIconStart
    Get #d, zeroexists, IconsExist
    
    If IconsExist(1) <> 0 Then      'SHIELD ICON - (ICON1)
        RecordIcon(1) = Space(RecIconStart(2) - RecIconStart(1))
        Get #d, RecIconStart(1), RecordIcon(1)
        Set RobotMasterIcon(d * 10 + 1) = LoadRobotIcon(RecordIcon(1))
    Else
        Set RobotMasterIcon(d * 10 + 1) = LoadPicture(App.Path & "\miscdata\" & d & "#1.ico")
    End If

    For c = 2 To 9
        If IconsExist(c) <> 0 Then      'ICONS 2-8
            RecordIcon(c) = Space(RecIconStart(c + 1) - RecIconStart(c))
            Get #d, RecIconStart(c), RecordIcon(c)
            Set RobotMasterIcon(10 * d + c) = LoadRobotIcon(RecordIcon(c))
        Else
            Set RobotMasterIcon(10 * d + c) = LoadPicture(App.Path & "\miscdata\NoIcon#" & c & ".ico")
        End If
    Next c

Close #d
Next d

'SOUNDS

'Robot 1
Open R1path For Binary As #1
    Get #1, sndrec, RecSoundStart
    Get #1, soundspresent, SoundsExist
If SoundsExist(0) <> 0 Then
    ReDim r1s0(RecSoundStart(1) - RecSoundStart(0))
    Get #1, RecSoundStart(0), r1s0
    RobotDeathSound(1) = True
Else
    RobotDeathSound(1) = False
    ReDim r1s0(0)
End If
If SoundsExist(1) <> 0 Then
    ReDim r1s1(RecSoundStart(2) - RecSoundStart(1))
    Get #1, RecSoundStart(1), r1s1
    RobotCollisionSound(1) = True
Else
    RobotCollisionSound(1) = False
    ReDim r1s1(0)
End If
If SoundsExist(2) <> 0 Then
    ReDim r1s2(RecSoundStart(3) - RecSoundStart(2))
    Get #1, RecSoundStart(2), r1s2
    RobotBlockSound(1) = True
Else
    RobotBlockSound(1) = False
    ReDim r1s2(0)
End If
If SoundsExist(3) <> 0 Then
    ReDim r1s3(RecSoundStart(4) - RecSoundStart(3))
    Get #1, RecSoundStart(3), r1s3
    RobotHitSound(1) = True
Else
    RobotHitSound(1) = False
    ReDim r1s3(0)
End If
If SoundsExist(4) <> 0 Then
    ReDim r1s4(RecSoundStart(5) - RecSoundStart(4))
    Get #1, RecSoundStart(4), r1s4
Else
    ReDim r1s4(0)
End If
If SoundsExist(5) <> 0 Then
    ReDim r1s5(RecSoundStart(6) - RecSoundStart(5))
    Get #1, RecSoundStart(5), r1s5
Else
    ReDim r1s5(0)
End If
If SoundsExist(6) <> 0 Then
    ReDim r1s6(RecSoundStart(7) - RecSoundStart(6))
    Get #1, RecSoundStart(6), r1s6
Else
    ReDim r1s6(0)
End If
If SoundsExist(7) <> 0 Then
    ReDim r1s7(RecSoundStart(8) - RecSoundStart(7))
    Get #1, RecSoundStart(7), r1s7
Else
    ReDim r1s7(0)
End If
If SoundsExist(8) <> 0 Then
    ReDim r1s8(RecSoundStart(9) - RecSoundStart(8))
    Get #1, RecSoundStart(8), r1s8
Else
    ReDim r1s8(0)
End If
If SoundsExist(9) <> 0 Then
    ReDim r1s9(RecSoundStart(10) - RecSoundStart(9))
    Get #1, RecSoundStart(9), r1s9
Else
    ReDim r1s9(0)
End If
Close 1
'Robot 2
If R2Present Then
    Open R2path For Binary As #1
        Get #1, sndrec, RecSoundStart
        Get #1, soundspresent, SoundsExist
    If SoundsExist(0) <> 0 Then
        ReDim r2s0(RecSoundStart(1) - RecSoundStart(0))
        Get #1, RecSoundStart(0), r2s0
        RobotDeathSound(2) = True
    Else
        RobotDeathSound(2) = False
        ReDim r2s0(0)
    End If
    If SoundsExist(1) <> 0 Then
        ReDim r2s1(RecSoundStart(2) - RecSoundStart(1))
        Get #1, RecSoundStart(1), r2s1
        RobotCollisionSound(2) = True
    Else
        RobotCollisionSound(2) = False
        ReDim r2s1(0)
    End If
    If SoundsExist(2) <> 0 Then
        ReDim r2s2(RecSoundStart(3) - RecSoundStart(2))
        Get #1, RecSoundStart(2), r2s2
        RobotBlockSound(2) = True
    Else
        RobotBlockSound(2) = False
        ReDim r2s2(0)
    End If
    If SoundsExist(3) <> 0 Then
        ReDim r2s3(RecSoundStart(4) - RecSoundStart(3))
        Get #1, RecSoundStart(3), r2s3
        RobotHitSound(2) = True
    Else
        RobotHitSound(2) = False
        ReDim r2s3(0)
    End If
    If SoundsExist(4) <> 0 Then
        ReDim r2s4(RecSoundStart(5) - RecSoundStart(4))
        Get #1, RecSoundStart(4), r2s4
    Else
        ReDim r2s4(0)
    End If
    If SoundsExist(5) <> 0 Then
        ReDim r2s5(RecSoundStart(6) - RecSoundStart(5))
        Get #1, RecSoundStart(5), r2s5
    Else
        ReDim r2s5(0)
    End If
    If SoundsExist(6) <> 0 Then
        ReDim r2s6(RecSoundStart(7) - RecSoundStart(6))
        Get #1, RecSoundStart(6), r2s6
    Else
        ReDim r2s6(0)
    End If
    If SoundsExist(7) <> 0 Then
        ReDim r2s7(RecSoundStart(8) - RecSoundStart(7))
        Get #1, RecSoundStart(7), r2s7
    Else
        ReDim r2s7(0)
    End If
    If SoundsExist(8) <> 0 Then
        ReDim r2s8(RecSoundStart(9) - RecSoundStart(8))
        Get #1, RecSoundStart(8), r2s8
    Else
        ReDim r2s8(0)
    End If
    If SoundsExist(9) <> 0 Then
        ReDim r2s9(RecSoundStart(10) - RecSoundStart(9))
        Get #1, RecSoundStart(9), r2s9
    Else
        ReDim r2s9(0)
    End If
    Close 1
End If

'Robot 3
If R3Present Then
    Open R3path For Binary As #1
        Get #1, sndrec, RecSoundStart
        Get #1, soundspresent, SoundsExist
    If SoundsExist(0) <> 0 Then
        ReDim r3s0(RecSoundStart(1) - RecSoundStart(0))
        Get #1, RecSoundStart(0), r3s0
        RobotDeathSound(3) = True
    Else
        RobotDeathSound(3) = False
        ReDim r3s0(0)
    End If
    If SoundsExist(1) <> 0 Then
        ReDim r3s1(RecSoundStart(2) - RecSoundStart(1))
        Get #1, RecSoundStart(1), r3s1
        RobotCollisionSound(3) = True
    Else
        RobotCollisionSound(3) = False
        ReDim r3s1(0)
    End If
    If SoundsExist(2) <> 0 Then
        ReDim r3s2(RecSoundStart(3) - RecSoundStart(2))
        Get #1, RecSoundStart(2), r3s2
        RobotBlockSound(3) = True
    Else
        RobotBlockSound(3) = False
        ReDim r3s2(0)
    End If
    If SoundsExist(3) <> 0 Then
        ReDim r3s3(RecSoundStart(4) - RecSoundStart(3))
        Get #1, RecSoundStart(3), r3s3
        RobotHitSound(3) = True
    Else
        RobotHitSound(3) = False
        ReDim r3s3(0)
    End If
    If SoundsExist(4) <> 0 Then
        ReDim r3s4(RecSoundStart(5) - RecSoundStart(4))
        Get #1, RecSoundStart(4), r3s4
    Else
        ReDim r3s4(0)
    End If
    If SoundsExist(5) <> 0 Then
        ReDim r3s5(RecSoundStart(6) - RecSoundStart(5))
        Get #1, RecSoundStart(5), r3s5
    Else
        ReDim r3s5(0)
    End If
    If SoundsExist(6) <> 0 Then
        ReDim r3s6(RecSoundStart(7) - RecSoundStart(6))
        Get #1, RecSoundStart(6), r3s6
    Else
        ReDim r3s6(0)
    End If
    If SoundsExist(7) <> 0 Then
        ReDim r3s7(RecSoundStart(8) - RecSoundStart(7))
        Get #1, RecSoundStart(7), r3s7
    Else
        ReDim r3s7(0)
    End If
    If SoundsExist(8) <> 0 Then
        ReDim r3s8(RecSoundStart(9) - RecSoundStart(8))
        Get #1, RecSoundStart(8), r3s8
    Else
        ReDim r3s8(0)
    End If
    If SoundsExist(9) <> 0 Then
        ReDim r3s9(RecSoundStart(10) - RecSoundStart(9))
        Get #1, RecSoundStart(9), r3s9
    Else
        ReDim r3s9(0)
    End If
    Close 1
End If

'Robot 4
If R4Present Then
    Open R4path For Binary As #1
        Get #1, sndrec, RecSoundStart
        Get #1, soundspresent, SoundsExist
    If SoundsExist(0) <> 0 Then
        ReDim r4s0(RecSoundStart(1) - RecSoundStart(0))
        Get #1, RecSoundStart(0), r4s0
        RobotDeathSound(4) = True
    Else
        RobotDeathSound(4) = False
        ReDim r4s0(0)
    End If
    If SoundsExist(1) <> 0 Then
        ReDim r4s1(RecSoundStart(2) - RecSoundStart(1))
        Get #1, RecSoundStart(1), r4s1
        RobotCollisionSound(4) = True
    Else
        RobotCollisionSound(4) = False
        ReDim r4s1(0)
    End If
    If SoundsExist(2) <> 0 Then
        ReDim r4s2(RecSoundStart(3) - RecSoundStart(2))
        Get #1, RecSoundStart(2), r4s2
        RobotBlockSound(4) = True
    Else
        RobotBlockSound(4) = False
        ReDim r4s2(0)
    End If
    If SoundsExist(3) <> 0 Then
        ReDim r4s3(RecSoundStart(4) - RecSoundStart(3))
        Get #1, RecSoundStart(3), r4s3
        RobotHitSound(4) = True
    Else
        RobotHitSound(4) = False
        ReDim r4s3(0)
    End If
    If SoundsExist(4) <> 0 Then
        ReDim r4s4(RecSoundStart(5) - RecSoundStart(4))
        Get #1, RecSoundStart(4), r4s4
    Else
        ReDim r4s4(0)
    End If
    If SoundsExist(5) <> 0 Then
        ReDim r4s5(RecSoundStart(6) - RecSoundStart(5))
        Get #1, RecSoundStart(5), r4s5
    Else
        ReDim r4s5(0)
    End If
    If SoundsExist(6) <> 0 Then
        ReDim r4s6(RecSoundStart(7) - RecSoundStart(6))
        Get #1, RecSoundStart(6), r4s6
    Else
        ReDim r4s6(0)
    End If
    If SoundsExist(7) <> 0 Then
        ReDim r4s7(RecSoundStart(8) - RecSoundStart(7))
        Get #1, RecSoundStart(7), r4s7
    Else
        ReDim r4s7(0)
    End If
    If SoundsExist(8) <> 0 Then
        ReDim r4s8(RecSoundStart(9) - RecSoundStart(8))
        Get #1, RecSoundStart(8), r4s8
    Else
        ReDim r4s8(0)
    End If
    If SoundsExist(9) <> 0 Then
        ReDim r4s9(RecSoundStart(10) - RecSoundStart(9))
        Get #1, RecSoundStart(9), r4s9
    Else
        ReDim r4s9(0)
    End If
    Close 1
End If

'Robot 5
If R5Present Then
    Open R5path For Binary As #1
        Get #1, sndrec, RecSoundStart
        Get #1, soundspresent, SoundsExist
    If SoundsExist(0) <> 0 Then
        ReDim r5s0(RecSoundStart(1) - RecSoundStart(0))
        Get #1, RecSoundStart(0), r5s0
        RobotDeathSound(5) = True
    Else
        ReDim r5s0(0)
        RobotDeathSound(5) = False
    End If
    If SoundsExist(1) <> 0 Then
        ReDim r5s1(RecSoundStart(2) - RecSoundStart(1))
        Get #1, RecSoundStart(1), r5s1
        RobotCollisionSound(5) = True
    Else
        ReDim r5s1(0)
        RobotCollisionSound(5) = False
    End If
    If SoundsExist(2) <> 0 Then
        ReDim r5s2(RecSoundStart(3) - RecSoundStart(2))
        Get #1, RecSoundStart(2), r5s2
        RobotBlockSound(5) = True
    Else
        ReDim r5s2(0)
        RobotBlockSound(5) = False
    End If
    If SoundsExist(3) <> 0 Then
        ReDim r5s3(RecSoundStart(4) - RecSoundStart(3))
        Get #1, RecSoundStart(3), r5s3
        RobotHitSound(5) = True
    Else
        ReDim r5s3(0)
        RobotHitSound(5) = False
    End If
    If SoundsExist(4) <> 0 Then
        ReDim r5s4(RecSoundStart(5) - RecSoundStart(4))
        Get #1, RecSoundStart(4), r5s4
    Else
        ReDim r5s4(0)
    End If
    If SoundsExist(5) <> 0 Then
        ReDim r5s5(RecSoundStart(6) - RecSoundStart(5))
        Get #1, RecSoundStart(5), r5s5
    Else
        ReDim r5s5(0)
    End If
    If SoundsExist(6) <> 0 Then
        ReDim r5s6(RecSoundStart(7) - RecSoundStart(6))
        Get #1, RecSoundStart(6), r5s6
    Else
        ReDim r5s6(0)
    End If
    If SoundsExist(7) <> 0 Then
        ReDim r5s7(RecSoundStart(8) - RecSoundStart(7))
        Get #1, RecSoundStart(7), r5s7
    Else
        ReDim r5s7(0)
    End If
    If SoundsExist(8) <> 0 Then
        ReDim r5s8(RecSoundStart(9) - RecSoundStart(8))
        Get #1, RecSoundStart(8), r5s8
    Else
        ReDim r5s8(0)
    End If
    If SoundsExist(9) <> 0 Then
        ReDim r5s9(RecSoundStart(10) - RecSoundStart(9))
        Get #1, RecSoundStart(9), r5s9
    Else
        ReDim r5s9(0)
    End If
    Close 1
End If

'Robot 6
If R6Present Then
    Open R6path For Binary As #1
        Get #1, sndrec, RecSoundStart
        Get #1, soundspresent, SoundsExist
    If SoundsExist(0) <> 0 Then
        ReDim r6s0(RecSoundStart(1) - RecSoundStart(0))
        Get #1, RecSoundStart(0), r6s0
        RobotDeathSound(6) = True
    Else
        ReDim r6s0(0)
        RobotDeathSound(6) = False
    End If
    If SoundsExist(1) <> 0 Then
        ReDim r6s1(RecSoundStart(2) - RecSoundStart(1))
        Get #1, RecSoundStart(1), r6s1
        RobotCollisionSound(6) = True
    Else
        ReDim r6s1(0)
        RobotCollisionSound(6) = False
    End If
    If SoundsExist(2) <> 0 Then
        ReDim r6s2(RecSoundStart(3) - RecSoundStart(2))
        Get #1, RecSoundStart(2), r6s2
        RobotBlockSound(6) = True
    Else
        ReDim r6s2(0)
        RobotBlockSound(6) = False
    End If
    If SoundsExist(3) <> 0 Then
        ReDim r6s3(RecSoundStart(4) - RecSoundStart(3))
        Get #1, RecSoundStart(3), r6s3
        RobotHitSound(6) = True
    Else
        ReDim r6s3(0)
        RobotHitSound(6) = False
    End If
    If SoundsExist(4) <> 0 Then
        ReDim r6s4(RecSoundStart(5) - RecSoundStart(4))
        Get #1, RecSoundStart(4), r6s4
    Else
        ReDim r6s4(0)
    End If
    If SoundsExist(5) <> 0 Then
        ReDim r6s5(RecSoundStart(6) - RecSoundStart(5))
        Get #1, RecSoundStart(5), r6s5
    Else
        ReDim r6s5(0)
    End If
    If SoundsExist(6) <> 0 Then
        ReDim r6s6(RecSoundStart(7) - RecSoundStart(6))
        Get #1, RecSoundStart(6), r6s6
    Else
        ReDim r6s6(0)
    End If
    If SoundsExist(7) <> 0 Then
        ReDim r6s7(RecSoundStart(8) - RecSoundStart(7))
        Get #1, RecSoundStart(7), r6s7
    Else
        ReDim r6s7(0)
    End If
    If SoundsExist(8) <> 0 Then
        ReDim r6s8(RecSoundStart(9) - RecSoundStart(8))
        Get #1, RecSoundStart(8), r6s8
    Else
        ReDim r6s8(0)
    End If
    If SoundsExist(9) <> 0 Then
        ReDim r6s9(RecSoundStart(10) - RecSoundStart(9))
        Get #1, RecSoundStart(9), r6s9
    Else
        ReDim r6s9(0)
    End If
    Close 1
End If
End Sub

Private Sub PlaySnd0(RNr As Long)
Select Case RNr
    Case 1
        If UBound(r1s0) > 0 Then sndPlaySound r1s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 2
        If UBound(r2s0) > 0 Then sndPlaySound r2s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 3
        If UBound(r3s0) > 0 Then sndPlaySound r3s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 4
        If UBound(r4s0) > 0 Then sndPlaySound r4s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 5
        If UBound(r5s0) > 0 Then sndPlaySound r5s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 6
        If UBound(r6s0) > 0 Then sndPlaySound r6s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
End Select
End Sub

Private Sub PlaySnd1(RNr As Long)
Select Case RNr
    Case 1
        If UBound(r1s1) > 0 Then sndPlaySound r1s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 2
        If UBound(r2s1) > 0 Then sndPlaySound r2s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 3
        If UBound(r3s1) > 0 Then sndPlaySound r3s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 4
        If UBound(r4s1) > 0 Then sndPlaySound r4s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 5
        If UBound(r5s1) > 0 Then sndPlaySound r5s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 6
        If UBound(r6s1) > 0 Then sndPlaySound r6s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
End Select
End Sub

Private Sub PlaySnd2(RNr As Long)
Select Case RNr
    Case 1
        If UBound(r1s2) > 0 Then sndPlaySound r1s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 2
        If UBound(r2s2) > 0 Then sndPlaySound r2s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 3
        If UBound(r3s2) > 0 Then sndPlaySound r3s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 4
        If UBound(r4s2) > 0 Then sndPlaySound r4s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 5
        If UBound(r5s2) > 0 Then sndPlaySound r5s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 6
        If UBound(r6s2) > 0 Then sndPlaySound r6s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
End Select
End Sub

Private Sub PlaySnd3(RNr As Long)
Select Case RNr
    Case 1
        If UBound(r1s3) > 0 Then sndPlaySound r1s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 2
        If UBound(r2s3) > 0 Then sndPlaySound r2s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 3
        If UBound(r3s3) > 0 Then sndPlaySound r3s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 4
        If UBound(r4s3) > 0 Then sndPlaySound r4s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 5
        If UBound(r5s3) > 0 Then sndPlaySound r5s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 6
        If UBound(r6s3) > 0 Then sndPlaySound r6s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
End Select
End Sub

Private Sub PlaySnd4(RNr As Long)
Select Case RNr
    Case 1
        If UBound(r1s4) > 0 Then sndPlaySound r1s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 2
        If UBound(r2s4) > 0 Then sndPlaySound r2s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 3
        If UBound(r3s4) > 0 Then sndPlaySound r3s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 4
        If UBound(r4s4) > 0 Then sndPlaySound r4s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 5
        If UBound(r5s4) > 0 Then sndPlaySound r5s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 6
        If UBound(r6s4) > 0 Then sndPlaySound r6s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
End Select
End Sub

Private Sub PlaySnd5(RNr As Long)
Select Case RNr
    Case 1
        If UBound(r1s5) > 0 Then sndPlaySound r1s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 2
        If UBound(r2s5) > 0 Then sndPlaySound r2s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 3
        If UBound(r3s5) > 0 Then sndPlaySound r3s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 4
        If UBound(r4s5) > 0 Then sndPlaySound r4s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 5
        If UBound(r5s5) > 0 Then sndPlaySound r5s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 6
        If UBound(r6s5) > 0 Then sndPlaySound r6s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
End Select
End Sub

Private Sub PlaySnd6(RNr As Long)
Select Case RNr
    Case 1
        If UBound(r1s6) > 0 Then sndPlaySound r1s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 2
        If UBound(r2s6) > 0 Then sndPlaySound r2s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 3
        If UBound(r3s6) > 0 Then sndPlaySound r3s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 4
        If UBound(r4s6) > 0 Then sndPlaySound r4s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 5
        If UBound(r5s6) > 0 Then sndPlaySound r5s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 6
        If UBound(r6s6) > 0 Then sndPlaySound r6s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
End Select
End Sub

Private Sub PlaySnd7(RNr As Long)
Select Case RNr
    Case 1
        If UBound(r1s7) > 0 Then sndPlaySound r1s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 2
        If UBound(r2s7) > 0 Then sndPlaySound r2s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 3
        If UBound(r3s7) > 0 Then sndPlaySound r3s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 4
        If UBound(r4s7) > 0 Then sndPlaySound r4s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 5
        If UBound(r5s7) > 0 Then sndPlaySound r5s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 6
        If UBound(r6s7) > 0 Then sndPlaySound r6s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
End Select
End Sub

Private Sub PlaySnd8(RNr As Long)
Select Case RNr
    Case 1
        If UBound(r1s8) > 0 Then sndPlaySound r1s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 2
        If UBound(r2s8) > 0 Then sndPlaySound r2s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 3
        If UBound(r3s8) > 0 Then sndPlaySound r3s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 4
        If UBound(r4s8) > 0 Then sndPlaySound r4s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 5
        If UBound(r5s8) > 0 Then sndPlaySound r5s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 6
        If UBound(r6s8) > 0 Then sndPlaySound r6s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
End Select
End Sub

Private Sub PlaySnd9(RNr As Long)
Select Case RNr
    Case 1
        If UBound(r1s9) > 0 Then sndPlaySound r1s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 2
        If UBound(r2s9) > 0 Then sndPlaySound r2s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 3
        If UBound(r3s9) > 0 Then sndPlaySound r3s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 4
        If UBound(r4s9) > 0 Then sndPlaySound r4s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 5
        If UBound(r5s9) > 0 Then sndPlaySound r5s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
    Case 6
        If UBound(r6s9) > 0 Then sndPlaySound r6s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT
End Select
End Sub

Private Function Range(RobotWhoChecks As Long, AimValue As Long) As Long
'This is David Harris range code, ported to Visual Basic by me.
    Dim counter As Long
    Dim T As Long
    Dim dx As Single, dy As Single    'This more similar to what Dave Harris used
    For counter = 1 To NumberOfRobotsPresent
        If counter <> RobotWhoChecks Then   'Skip needless calculations (range to itself allways = 0)
            T = FixSquare((RobotLeft(RobotWhoChecks) - RobotLeft(counter)) * (RobotLeft(RobotWhoChecks) - RobotLeft(counter)) + (RobotTop(RobotWhoChecks) - RobotTop(counter)) * (RobotTop(RobotWhoChecks) - RobotTop(counter)))

            dx = Sine(AimValue) * T - RobotLeft(counter) + RobotLeft(RobotWhoChecks)
            dy = RobotTop(RobotWhoChecks) - Cosine(AimValue) * T - RobotTop(counter)

            If dx * dx + dy * dy > 91 Then T = 0
            If (T < Range Or Range = 0) And T <> 0 Then
                Range = T
                RangedRobot(RobotWhoChecks) = counter
            End If
        End If
    Next counter
    
    If RobotTeam(RobotWhoChecks) <> 0 Then
        If Range <> 0 Then
            If RobotTeam(RobotWhoChecks) = RobotTeam(RangedRobot(RobotWhoChecks)) Then Range = 0
        End If
    End If
End Function

Private Function Nearest(RobotWhoChecks As Long) As Long
Dim T As Long
Dim NearestDist As Long
Dim counter As Long

NearestDist = 2147483647

For counter = 1 To NumberOfRobotsPresent
    If counter <> RobotWhoChecks Then   'Skip needless calculations (range to itself allways = 0)
        T = (RobotLeft(RobotWhoChecks) - RobotLeft(counter)) ^ 2 + (RobotTop(RobotWhoChecks) - RobotTop(counter)) ^ 2
        If T < NearestDist Then
            NearestDist = T
            Nearest = counter
        End If
    End If
Next counter
    
End Function

'Private Function rrange(RobotWhoChecks As Long, AimValue As Long) As Long
''intrange is faster than ordinary range, but it returns 601 when nobody is ranged
'    Dim counter As Long
'    Dim t As Long
'    Dim dx As Single, dy As Single
'
'    rrange = 601
'
'    For counter = 1 To NumberOfRobotsPresent
'        If counter <> RobotWhoChecks Then   'Skip checking range to self. It'll be too short
'            t = FixSquare((RobotLeft(RobotWhoChecks) - RobotLeft(counter)) * (RobotLeft(RobotWhoChecks) - RobotLeft(counter)) + (RobotTop(RobotWhoChecks) - RobotTop(counter)) * (RobotTop(RobotWhoChecks) - RobotTop(counter)))
'            dx = Sine(AimValue) * t - RobotLeft(counter) + RobotLeft(RobotWhoChecks)
'            dy = RobotTop(RobotWhoChecks) - Cosine(AimValue) * t - RobotTop(counter)
'
'            If dx * dx + dy * dy > 91 Then t = 601 'This should be faster
'
'            If t < rrange Then
'                rrange = t
'                RangedRobot(RobotWhoChecks) = counter
'            End If
'        End If
'    Next counter
'
'    If RobotTeam(RobotWhoChecks) <> 0 Then
'        If rrange <> 601 Then
'            If RobotTeam(RobotWhoChecks) = RobotTeam(RangedRobot(RobotWhoChecks)) Then rrange = 601
'        End If
'    End If
'End Function
'Short Radar(robot * who)
'{
'    register shot *cur;
'    register short x,y,theta,scan;
'    long range,close = 1000000,result;
'
'    cur = shots;
'    x = who->letters[x_];
'    y = who->letters[y_];
'    scan = (who->aim+who->scan)%360;
'    while (cur != NULL) {
'        if (cur->type != laser) {
'            theta = (short)(450-atan2(y-cur->yPosInt,cur->xPosInt-x)*radToDeg)%360;
'            if ((abs(theta-scan) < 20) || (abs(theta-scan) > 340)) {
'                range = (y-cur->yPosInt)*(long)(y-cur->yPosInt) +
'                        (x-cur->xPosInt)*(long)(x-cur->xPosInt);
'                if (range < close) close = range;
'            }
'        }
'        cur = cur->next;
'    }
'    if (close == 1000000) result = 0;
'    else result = sqrt(close);
'    return result;
'}

Private Function Radar(RobotWhoChecks As Long, a As Single, b As Single, AimValue As Long) As Long
'This function in only called from the debugger. Besides in the debugger, robots calculates radar inline
Dim theta As Long

a = RobotLeft(RobotWhoChecks) - Fix(a)  'This is to make sure that we cut floats like C does
b = RobotTop(RobotWhoChecks) - Fix(b)  'This is absolutely nessecary

If a = 0 Then   'atan2
    theta = 90 * Sgn(b)
Else
    theta = TPI * Atn(b / -a) - 180 * (a >= 0)
End If          '''''''

theta = Abs(450 - theta - AimValue)
If theta > 359 Then theta = theta - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(theta) = 627

If theta < 20 Or theta > 340 Then   '< 19  341 >        '24 och 336
    Radar = FixSquare(a * a + b * b)
Else
    Radar = 0
End If

End Function

Private Function Asn(X As Single) As Single
Asn = Atn(X / Sqr(-X * X + 1))
End Function

Private Function Acn(X As Single) As Single
Acn = Atn(-X / Sqr(-X * X + 1)) + 2 * Atn(1)
End Function

Private Function DistBwtn(cx1 As Long, cy1 As Long, cx2 As Long, cy2 As Long) As Long 'long
DistBwtn = Sqr((cx1 - cx2) ^ 2 + (cy1 - cy2) ^ 2)
'DistBwtn = Sqr((cx1 - cx2) * (cx1 - cx2) + (cy1 - cy2) * (cy1 - cy2))
End Function

Private Sub Tutorial_Click()
ShowTutorial
End Sub

Public Sub InizTournament()
' This is the tournament engine
' I agree that it's needlessly complicated and messy.
' The explaination for that is that it was built in parts, it was partitially rebuilt, and it seems to work
' as it is right now so I don't feel any strong urge to rebuilt it in a less messy version
' SoloScore( ) is the same thing as the robots solo score

' Bugs
' It requires 6 robots to run and not 2 as supposed to.
' You can only choose robots from one folder.

TournamentD.Hide

If RunningTournament Then MsgBox "You're already running a tournament!", , "Can't run two tournaments at the same time": Exit Sub

Dim ClockTime As Single
ClockTime = Timer

ClearTeams
PrintTournamentLog = TournamentD.PrintLog.Value
If PrintTournamentLog Then ReDim TournamentLog(((TournamentD.RobotList.ListCount - 1) / 2 * TournamentD.RobotList.ListCount) * TournamentD.DuelsN + TournamentD.RobotList.ListCount * TournamentD.GRNumber * 6 _
    + TournamentD.CheckWinnerCircle.Value * (15 * (TournamentD.DuelsN * 8 \ 3) + 96 * TournamentD.GRNumber))

Dim TCA As Long 'integer
Dim TCB As Long 'integer
Dim WhichFight As Long 'integer
Dim DuelScore1 As Long 'integer
Dim DuelScore2 As Long 'integer
TCB = 1
TCA = 1

RunningTournament = True
R1Present = True
R2Present = True
R3Present = False
R4Present = False
R5Present = False
R6Present = False
R3Icon = LoadPicture()
R4Icon = LoadPicture()
R5Icon = LoadPicture()
R6Icon = LoadPicture()

Robot3 = "No Robot Selected"
Robot4 = "No Robot Selected"
Robot5 = "No Robot Selected"
Robot6 = "No Robot Selected"

Dim counter As Long

For counter = 3 To 6
    RobotLeft(counter) = -counter * 100
    DR(counter).Visible = False
    EnergyDisplay(counter).Visible = False  'Ny
    ER(counter).Visible = False
Next counter
PR3.Visible = False: PR4.Visible = False: PR5.Visible = False: PR6.Visible = False
Points3X.Visible = False: Points4X.Visible = False: Points5X.Visible = False: Points6X.Visible = False
Damage3X.Visible = False: Damage4X.Visible = False: Damage5X.Visible = False: Damage6X.Visible = False
Energy3X.Visible = False: Energy4X.Visible = False: Energy5X.Visible = False: Energy6X.Visible = False

If Not ChronorsLimit.Checked Then ChronorsLimit_Click
If TournamentD.CheckEnergy.Value = 0 Eqv Overloading.Checked Then Overloading_Click
If TournamentD.CheckMoveAndShoot.Value = 1 Eqv MoveAndShoot.Checked Then MoveAndShoot_Click
If TournamentD.CheckScoring.Value = 1 Eqv StandardScoring Then Scoring_Click
If Replaying Then RepeatBattle_Click

ResetHistory_Click


HighestToLowest = (Int(2 * Rnd) = 1)

'   Run Tournament
Dim TournamentSwitch As Long
Dim NumberOfGRBattles() As Long 'long
Dim GRScore() As Long 'long
Dim SoloScore() As Long
ReDim SoloScore(TournamentD.RobotList.ListCount)
Dim RandomRobot(1 To 6) As Long

If TournamentD.DuelsN = 0 Then      'If the user has choosed to not run duel
    TCB = TournamentD.RobotList.ListCount
    WhichFight = TournamentD.DuelsN
End If

If TournamentD.GRNumber = 0 And SelectedRobot > 2 Then
    SelectedRobot = 1
    Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite
    Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite
    Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite
    Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite
    Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite
    Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
End If

Do While RunningTournament
    If TournamentSwitch = 1 Then
        If TournamentD.GRNumber <> 0 Then
            If TCB Mod 6 = 0 Then    'Load new robots
                GRScore(RandomRobot(1)) = GRScore(RandomRobot(1)) + PR1
                GRScore(RandomRobot(2)) = GRScore(RandomRobot(2)) + PR2
                GRScore(RandomRobot(3)) = GRScore(RandomRobot(3)) + PR3
                GRScore(RandomRobot(4)) = GRScore(RandomRobot(4)) + PR4
                GRScore(RandomRobot(5)) = GRScore(RandomRobot(5)) + PR5
                GRScore(RandomRobot(6)) = GRScore(RandomRobot(6)) + PR6
            
                RandomRobot(1) = Int(TournamentD.RobotList.ListCount * Rnd)
                NumberOfGRBattles(RandomRobot(1)) = NumberOfGRBattles(RandomRobot(1)) + 1
redorandom2:
                RandomRobot(2) = Int(TournamentD.RobotList.ListCount * Rnd)
                If RandomRobot(2) = RandomRobot(1) Then GoTo redorandom2
                NumberOfGRBattles(RandomRobot(2)) = NumberOfGRBattles(RandomRobot(2)) + 1
redorandom3:
                RandomRobot(3) = Int(TournamentD.RobotList.ListCount * Rnd)
                If RandomRobot(3) = RandomRobot(1) Or RandomRobot(3) = RandomRobot(2) Then GoTo redorandom3
                NumberOfGRBattles(RandomRobot(3)) = NumberOfGRBattles(RandomRobot(3)) + 1
redorandom4:
                RandomRobot(4) = Int(TournamentD.RobotList.ListCount * Rnd)
                If RandomRobot(4) = RandomRobot(1) Or RandomRobot(4) = RandomRobot(3) Or RandomRobot(4) = RandomRobot(2) Then GoTo redorandom4
                NumberOfGRBattles(RandomRobot(4)) = NumberOfGRBattles(RandomRobot(4)) + 1
redorandom5:
                RandomRobot(5) = Int(TournamentD.RobotList.ListCount * Rnd)
                If RandomRobot(5) = RandomRobot(1) Or RandomRobot(5) = RandomRobot(4) Or RandomRobot(5) = RandomRobot(3) Or RandomRobot(5) = RandomRobot(2) Then GoTo redorandom5
                NumberOfGRBattles(RandomRobot(5)) = NumberOfGRBattles(RandomRobot(5)) + 1
redorandom6:
                RandomRobot(6) = Int(TournamentD.RobotList.ListCount * Rnd) ' + 1
                If RandomRobot(6) = RandomRobot(1) Or RandomRobot(6) = RandomRobot(5) Or RandomRobot(6) = RandomRobot(4) Or RandomRobot(6) = RandomRobot(3) Or RandomRobot(6) = RandomRobot(2) Then GoTo redorandom6
                NumberOfGRBattles(RandomRobot(6)) = NumberOfGRBattles(RandomRobot(6)) + 1
                
                Robot1.Caption = TournamentD.RobotList.List(RandomRobot(1))
                R1path = TournamentD.TheDirList.List(RandomRobot(1)) & "\" & TournamentD.RobotList.List(RandomRobot(1)) & ".RWR"
                LoadRobot1
                Robot2.Caption = TournamentD.RobotList.List(RandomRobot(2))
                R2path = TournamentD.TheDirList.List(RandomRobot(2)) & "\" & TournamentD.RobotList.List(RandomRobot(2)) & ".RWR"
                LoadRobot2
                Robot3.Caption = TournamentD.RobotList.List(RandomRobot(3))
                R3path = TournamentD.TheDirList.List(RandomRobot(3)) & "\" & TournamentD.RobotList.List(RandomRobot(3)) & ".RWR"
                LoadRobot3
                Robot4.Caption = TournamentD.RobotList.List(RandomRobot(4))
                R4path = TournamentD.TheDirList.List(RandomRobot(4)) & "\" & TournamentD.RobotList.List(RandomRobot(4)) & ".RWR"
                LoadRobot4
                Robot5.Caption = TournamentD.RobotList.List(RandomRobot(5))
                R5path = TournamentD.TheDirList.List(RandomRobot(5)) & "\" & TournamentD.RobotList.List(RandomRobot(5)) & ".RWR"
                LoadRobot5
                Robot6.Caption = TournamentD.RobotList.List(RandomRobot(6))
                R6path = TournamentD.TheDirList.List(RandomRobot(6)) & "\" & TournamentD.RobotList.List(RandomRobot(6)) & ".RWR"
                LoadRobot6
        
                PR1 = 0: PR2 = 0: PR3 = 0: PR4 = 0: PR5 = 0: PR6 = 0
                For counter = 1 To 50
                    HistoryRec(1, counter) = 0: HistoryRec(2, counter) = 0: HistoryRec(3, counter) = 0: HistoryRec(4, counter) = 0: HistoryRec(5, counter) = 0: HistoryRec(6, counter) = 0
                Next counter
            End If

            TCB = TCB + 1
            If WindowMini Then
            sMainWindowCaption = "RoboWar 5 - Tournament: GroupRound " & TCB & " of " & TournamentD.RobotList.ListCount * TournamentD.GRNumber * 6 & " is running."
            Else
            MainWindow.Caption = "RoboWar 5 - Tournament: GroupRound " & TCB & " of " & TournamentD.RobotList.ListCount * TournamentD.GRNumber * 6 & " is running."
            End If
            
            BattleHaltButton_Click
        Else
            TCB = TournamentD.RobotList.ListCount * TournamentD.GRNumber * 6
        End If
        
        If TCB = TournamentD.RobotList.ListCount * TournamentD.GRNumber * 6 Then
'            'Tournament is over, showing score
            Dim TotalScore() As Long ' long
            ReDim TotalScore(TournamentD.RobotList.ListCount)

            Dim TournamnetScore As String
            Dim highestscore As Long 'long
            Dim counter2 As Long
            Dim ZingGRScore As Double

            If TournamentD.DuelsN <> 0 And TournamentD.GRNumber <> 0 Then
                For counter = 0 To TournamentD.RobotList.ListCount - 1
    '    if (numDuels > 0) roster[i].groupScore *= numDuels*(numEntries-1)/
    '                                                          (2.0*groupBouts*roster[i].numGroupFights);
                    ZingGRScore = GRScore(counter)
    '                             - NEW - Camden's formula - Works with all rations, not just 10/6
    '                ZingGRScore = ZingGRScore * ((TournamentD.RobotList.ListCount - 1) * TournamentD.DuelsN / (12 * NumberOfGRBattles(counter)))
    
                    ZingGRScore = ZingGRScore * TournamentD.DuelsN / (12 * NumberOfGRBattles(counter))  'Same as above
                    ZingGRScore = ZingGRScore * (TournamentD.RobotList.ListCount - 1)     'but splitted to avoid overflow bugs
    
                    GRScore(counter) = ZingGRScore
    
                    TotalScore(counter) = GRScore(counter) + SoloScore(counter)
                Next counter
            ElseIf TournamentD.DuelsN = 0 Then
                For counter = 0 To TournamentD.RobotList.ListCount - 1
                    ZingGRScore = GRScore(counter)      'BUG ALERT!!    BUG ALERT!!     är dethär samma som Macversionen?
                    ZingGRScore = ZingGRScore * TournamentD.GRNumber / (12 * NumberOfGRBattles(counter))  'ZingGRScore / (12 * NumberOfGRBattles(counter))
                    ZingGRScore = ZingGRScore * (TournamentD.RobotList.ListCount - 1)     'but splitted to avoid overflow bugs
                    GRScore(counter) = ZingGRScore
                    TotalScore(counter) = GRScore(counter) + SoloScore(counter)
                Next counter
            Else
                For counter = 0 To TournamentD.RobotList.ListCount - 1
                    TotalScore(counter) = SoloScore(counter)
                Next counter
            End If
            
            Dim WinnerCircleNumbers(1 To 6) As Long
            Dim WinnerCircleCounter As Long

            For counter2 = 0 To TournamentD.RobotList.ListCount - 1
                For counter = 0 To TournamentD.RobotList.ListCount - 1
                    If TotalScore(counter) > TotalScore(highestscore) Then highestscore = counter
                Next counter
                
                If WinnerCircleCounter < 6 Then
                WinnerCircleCounter = WinnerCircleCounter + 1
                WinnerCircleNumbers(WinnerCircleCounter) = highestscore
                End If
                'Kolla hur långt namnet är
                TournamnetScore = TournamnetScore & vbCr & TFixTabs2(TournamentD.RobotList.List(highestscore)) & vbTab & SoloScore(highestscore) & vbTab & GRScore(highestscore) & vbTab & TotalScore(highestscore)
                TotalScore(highestscore) = -1
            Next counter2

            Dim WinnerCircleAddString As String

            If TournamentD.CheckWinnerCircle.Value = 1 Then 'Runs Winner circle if set to do so
                If TournamentD.DuelsN <> 0 Then
                    Dim WinnerCirleSolo(1 To 6) As Long
                
                    TCB = 1: TCA = 1: WhichFight = 0
                    R3Present = False: R4Present = False: R5Present = False: R6Present = False: ResetHistory_Click
                    R3Icon = LoadPicture(): R4Icon = LoadPicture(): R5Icon = LoadPicture(): R6Icon = LoadPicture()
                    Robot3 = "No Robot Selected": Robot4 = "No Robot Selected": Robot5 = "No Robot Selected": Robot6 = "No Robot Selected"
                    For counter = 3 To 6
                        RobotLeft(counter) = -counter * 100: DR(counter).Visible = False: EnergyDisplay(counter).Visible = False: ER(counter).Visible = False
                    Next counter
                    PR3.Visible = False: PR4.Visible = False: PR5.Visible = False: PR6.Visible = False
                    Points3X.Visible = False: Points4X.Visible = False: Points5X.Visible = False: Points6X.Visible = False
                    Damage3X.Visible = False: Damage4X.Visible = False: Damage5X.Visible = False: Damage6X.Visible = False
                    Energy3X.Visible = False: Energy4X.Visible = False: Energy5X.Visible = False: Energy6X.Visible = False
    
                    Dim WinnerCircleDuels As Long
                    WinnerCircleDuels = TournamentD.DuelsN * 8 \ 3
        
                    Do While RunningTournament
                    If TCB >= 6 And WhichFight >= WinnerCircleDuels Then
                        Exit Do
                    ElseIf WhichFight >= WinnerCircleDuels Or WhichFight = 0 Then  'Loading Robots
                        PR1 = 0
                        PR2 = 0
                        
                        For counter = 1 To 50
                            HistoryRec(1, counter) = 0: HistoryRec(2, counter) = 0
                        Next counter
                        
                        TCA = TCA + 1
                
                        Robot1.Caption = TournamentD.RobotList.List(WinnerCircleNumbers(TCB))
                        R1path = TournamentD.TheDirList.List(WinnerCircleNumbers(TCB)) & "\" & TournamentD.RobotList.List(WinnerCircleNumbers(TCB)) & ".RWR"
                        LoadRobot1
                        
                        Robot2.Caption = TournamentD.RobotList.List(WinnerCircleNumbers(TCA))
                        R2path = TournamentD.TheDirList.List(WinnerCircleNumbers(TCA)) & "\" & TournamentD.RobotList.List(WinnerCircleNumbers(TCA)) & ".RWR"
                        LoadRobot2
                
                        DuelScore1 = TCB
                        DuelScore2 = TCA    'Set which to give score after rond WinnerCircleDuels
                        
                        If TCA = 6 Then '6
                            TCA = TCB + 1
                            TCB = TCB + 1
                        End If
                        WhichFight = 1
                    Else
                        WhichFight = WhichFight + 1
                    End If
                    
                        If WindowMini Then
                        sMainWindowCaption = "RoboWar 5 - Tournament: Winner Circle - Robot " & DuelScore1 & " vs Robot " & DuelScore2 & " - Round " & WhichFight & " of " & WinnerCircleDuels
                        Else
                        MainWindow.Caption = "RoboWar 5 - Tournament: Winner Circle - Robot " & DuelScore1 & " vs Robot " & DuelScore2 & " - Round " & WhichFight & " of " & WinnerCircleDuels
                        End If
                        
                        BattleHaltButton_Click
                        If WhichFight >= WinnerCircleDuels Then
                            WinnerCirleSolo(DuelScore1) = WinnerCirleSolo(DuelScore1) + PR1
                            WinnerCirleSolo(DuelScore2) = WinnerCirleSolo(DuelScore2) + PR2
                        End If
                    Loop
                End If  'Solo If
                'WC Group
                
                If TournamentD.GRNumber <> 0 Then
                    R3Present = True: R4Present = True: R5Present = True: R6Present = True: PR1 = 0: PR2 = 0
                    For counter = 1 To 50
                        HistoryRec(1, counter) = 0: HistoryRec(2, counter) = 0
                    Next counter
                    
                    Robot1.Caption = TournamentD.RobotList.List(WinnerCircleNumbers(1))
                    R1path = TournamentD.TheDirList.List(WinnerCircleNumbers(1)) & "\" & TournamentD.RobotList.List(WinnerCircleNumbers(1)) & ".RWR"
                    LoadRobot1
                    Robot2.Caption = TournamentD.RobotList.List(WinnerCircleNumbers(2))
                    R2path = TournamentD.TheDirList.List(WinnerCircleNumbers(2)) & "\" & TournamentD.RobotList.List(WinnerCircleNumbers(2)) & ".RWR"
                    LoadRobot2
                    Robot3.Caption = TournamentD.RobotList.List(WinnerCircleNumbers(3))
                    R3path = TournamentD.TheDirList.List(WinnerCircleNumbers(3)) & "\" & TournamentD.RobotList.List(WinnerCircleNumbers(3)) & ".RWR"
                    LoadRobot3
                    Robot4.Caption = TournamentD.RobotList.List(WinnerCircleNumbers(4))
                    R4path = TournamentD.TheDirList.List(WinnerCircleNumbers(4)) & "\" & TournamentD.RobotList.List(WinnerCircleNumbers(4)) & ".RWR"
                    LoadRobot4
                    Robot5.Caption = TournamentD.RobotList.List(WinnerCircleNumbers(5))
                    R5path = TournamentD.TheDirList.List(WinnerCircleNumbers(5)) & "\" & TournamentD.RobotList.List(WinnerCircleNumbers(5)) & ".RWR"
                    LoadRobot5
                    Robot6.Caption = TournamentD.RobotList.List(WinnerCircleNumbers(6))
                    R6path = TournamentD.TheDirList.List(WinnerCircleNumbers(6)) & "\" & TournamentD.RobotList.List(WinnerCircleNumbers(6)) & ".RWR"
                    LoadRobot6
                    
                    For counter = 1 To 96 * TournamentD.GRNumber    '6 * 16 = 96
                        If Not RunningTournament Then Exit For

                        If WindowMini Then
                        sMainWindowCaption = "RoboWar 5 - Tournament: Winner Circle Group - Battle " & counter & " of " & 96 * TournamentD.GRNumber
                        Else
                        MainWindow.Caption = "RoboWar 5 - Tournament: Winner Circle Group - Battle " & counter & " of " & 96 * TournamentD.GRNumber
                        End If
                        
                        BattleHaltButton_Click
                    Next counter
                End If
                
                WinnerCircleAddString = vbTab & "WC Solo" & vbTab & "WC Group" & vbTab & "Final"
   
                'Normalizing Winners' Cirle Group
'                    roster[circle[i]].soloFinal *= (numEntries -1) * 3 / 80.0;
'                    roster[circle[i]].groupFinal *= (numEntries -1)*numDuels /
'                                                    (4.0*groupBouts*roster[circle[i]].numGroupFights);
'    Scale factor to make group final = 1/2 individual score:
'        numDuels*(n-1) / (12*rounds participating)

                If TournamentD.DuelsN <> 0 And TournamentD.GRNumber <> 0 Then
                    PR1 = Fix(PR1 * (TournamentD.RobotList.ListCount - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber))
                    PR2 = Fix(PR2 * (TournamentD.RobotList.ListCount - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber))
                    PR3 = Fix(PR3 * (TournamentD.RobotList.ListCount - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber))
                    PR4 = Fix(PR4 * (TournamentD.RobotList.ListCount - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber))
                    PR5 = Fix(PR5 * (TournamentD.RobotList.ListCount - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber))
                    PR6 = Fix(PR6 * (TournamentD.RobotList.ListCount - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber))
                ElseIf TournamentD.DuelsN = 0 Then
                    PR1 = Fix(PR1 * (TournamentD.RobotList.ListCount - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber))   'BUG ALERT!!    BUG ALERT!!
                    PR2 = Fix(PR2 * (TournamentD.RobotList.ListCount - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber))   'Gör Mac versionen såhär?
                    PR3 = Fix(PR3 * (TournamentD.RobotList.ListCount - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber))
                    PR4 = Fix(PR4 * (TournamentD.RobotList.ListCount - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber))
                    PR5 = Fix(PR5 * (TournamentD.RobotList.ListCount - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber))
                    PR6 = Fix(PR6 * (TournamentD.RobotList.ListCount - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber))
                Else
                    PR1 = 0
                    PR2 = 0
                End If
                
                'Normalizing Winners' Cirle Solo
                'roster[circle[i]].soloFinal *= (numEntries -1) * 3 / 80.0;
                For counter = 1 To 6
                    WinnerCirleSolo(counter) = Fix(WinnerCirleSolo(counter) * (TournamentD.RobotList.ListCount - 1) * 3 / 80) '80
                Next counter

                Dim newscore() As String
                Dim Final(1 To 6) As Long 'long
                Final(1) = GRScore(WinnerCircleNumbers(1)) + SoloScore(WinnerCircleNumbers(1)) + PR1 + WinnerCirleSolo(1)
                Final(2) = GRScore(WinnerCircleNumbers(2)) + SoloScore(WinnerCircleNumbers(2)) + PR2 + WinnerCirleSolo(2)
                Final(3) = GRScore(WinnerCircleNumbers(3)) + SoloScore(WinnerCircleNumbers(3)) + PR3 + WinnerCirleSolo(3)
                Final(4) = GRScore(WinnerCircleNumbers(4)) + SoloScore(WinnerCircleNumbers(4)) + PR4 + WinnerCirleSolo(4)
                Final(5) = GRScore(WinnerCircleNumbers(5)) + SoloScore(WinnerCircleNumbers(5)) + PR5 + WinnerCirleSolo(5)
                Final(6) = GRScore(WinnerCircleNumbers(6)) + SoloScore(WinnerCircleNumbers(6)) + PR6 + WinnerCirleSolo(6)

                newscore = Split(TournamnetScore, vbCr)
                newscore(1) = newscore(1) & vbTab & WinnerCirleSolo(1) & vbTab & vbTab & PR1 & vbTab & vbTab & Final(1)
                newscore(2) = newscore(2) & vbTab & WinnerCirleSolo(2) & vbTab & vbTab & PR2 & vbTab & vbTab & Final(2)

                If Final(2) > Final(1) Then
                    TournamnetScore = newscore(1): newscore(1) = newscore(2): newscore(2) = TournamnetScore: counter = Final(1): Final(1) = Final(2): Final(2) = counter
                End If
                
                newscore(3) = newscore(3) & vbTab & WinnerCirleSolo(3) & vbTab & vbTab & PR3 & vbTab & vbTab & Final(3)
                
                If Final(3) > Final(2) Then
                    TournamnetScore = newscore(2): newscore(2) = newscore(3): newscore(3) = TournamnetScore: counter = Final(2): Final(2) = Final(3): Final(3) = counter
                End If
                If Final(2) > Final(1) Then
                    TournamnetScore = newscore(1): newscore(1) = newscore(2): newscore(2) = TournamnetScore: counter = Final(1): Final(1) = Final(2): Final(2) = counter
                End If
                
                newscore(4) = newscore(4) & vbTab & WinnerCirleSolo(4) & vbTab & vbTab & PR4 & vbTab & vbTab & Final(4)
                
                If Final(4) > Final(3) Then
                    TournamnetScore = newscore(3): newscore(3) = newscore(4): newscore(4) = TournamnetScore: counter = Final(3): Final(3) = Final(4): Final(4) = counter
                End If
                If Final(3) > Final(2) Then
                    TournamnetScore = newscore(2): newscore(2) = newscore(3): newscore(3) = TournamnetScore: counter = Final(2): Final(2) = Final(3): Final(3) = counter
                End If
                If Final(2) > Final(1) Then
                    TournamnetScore = newscore(1): newscore(1) = newscore(2): newscore(2) = TournamnetScore: counter = Final(1): Final(1) = Final(2): Final(2) = counter
                End If
                
                newscore(5) = newscore(5) & vbTab & WinnerCirleSolo(5) & vbTab & vbTab & PR5 & vbTab & vbTab & Final(5)

                If Final(5) > Final(4) Then
                    TournamnetScore = newscore(4): newscore(4) = newscore(5): newscore(5) = TournamnetScore: counter = Final(4): Final(4) = Final(5): Final(5) = counter
                End If
                If Final(4) > Final(3) Then
                    TournamnetScore = newscore(3): newscore(3) = newscore(4): newscore(4) = TournamnetScore: counter = Final(3): Final(3) = Final(4): Final(4) = counter
                End If
                If Final(3) > Final(2) Then
                    TournamnetScore = newscore(2): newscore(2) = newscore(3): newscore(3) = TournamnetScore: counter = Final(2): Final(2) = Final(3): Final(3) = counter
                End If
                If Final(2) > Final(1) Then
                    TournamnetScore = newscore(1): newscore(1) = newscore(2): newscore(2) = TournamnetScore: counter = Final(1): Final(1) = Final(2): Final(2) = counter
                End If

                newscore(6) = newscore(6) & vbTab & WinnerCirleSolo(6) & vbTab & vbTab & PR6 & vbTab & vbTab & Final(6)
                
                If Final(6) > Final(5) Then
                    TournamnetScore = newscore(5): newscore(5) = newscore(6): newscore(6) = TournamnetScore: counter = Final(5): Final(5) = Final(6): Final(6) = counter
                End If
                If Final(5) > Final(4) Then
                    TournamnetScore = newscore(4): newscore(4) = newscore(5): newscore(5) = TournamnetScore: counter = Final(4): Final(4) = Final(5): Final(5) = counter
                End If
                If Final(4) > Final(3) Then
                    TournamnetScore = newscore(3): newscore(3) = newscore(4): newscore(4) = TournamnetScore: counter = Final(3): Final(3) = Final(4): Final(4) = counter
                End If
                If Final(3) > Final(2) Then
                    TournamnetScore = newscore(2): newscore(2) = newscore(3): newscore(3) = TournamnetScore: counter = Final(2): Final(2) = Final(3): Final(3) = counter
                End If
                If Final(2) > Final(1) Then
                    TournamnetScore = newscore(1): newscore(1) = newscore(2): newscore(2) = TournamnetScore: counter = Final(1): Final(1) = Final(2): Final(2) = counter
                End If
                
                TournamnetScore = ""
                
                For counter = 1 To UBound(newscore)
                    TournamnetScore = TournamnetScore & vbCr & newscore(counter)
                Next counter
            End If
            'End Winner circle
            ClockTime = Round((Timer - ClockTime) / 60, 1)
            Dim timestring As String
            timestring = Date & ", " & time

            TournamnetScore = "Name" & vbTab & vbTab & vbTab & "Solo" & vbTab & "Group" & vbTab & "Total" & WinnerCircleAddString & TournamnetScore

            TournamentResults.TheTournamentResults = TournamnetScore
            TournamentResults.Show 1, MainWindow

            TournamnetScore = Replace(TournamnetScore, "Name" & vbTab & vbTab & vbTab, "Name" & String$(5, vbTab))
            TournamnetScore = TournamnetScore & vbCr & vbCr & vbCr & "********" & vbCr & vbCr & _
            "Tournament completed " & timestring & vbCr & _
            "Completed in " & ClockTime & " minutes " & vbCr & _
            "Duels " & TournamentD.DuelsN & " - Groups " & TournamentD.GRNumber & vbCr & _
            Scoring.Caption & vbCr & _
            "RoboWar Version " & App.Major & "." & App.Minor & "." & App.Revision
            
            Open TournamentD.SavedInFolder For Output As 30
                Print #30, TournamnetScore
            Close 30

            If TournamentD.GRNumber <> 0 Then
                Load2.Visible = True: Load3.Visible = True: Load4.Visible = True: Load5.Visible = True: Load6.Visible = True
            Else
                Load2.Visible = True: Load3.Visible = True: Load4.Visible = False: Load5.Visible = False: Load6.Visible = False
                R3Present = False: R4Present = False: R5Present = False: R6Present = False
            End If
            
            RunningTournament = False
            TitleTimer.Enabled = False
            MainWindow.Caption = "RoboWar 5 - Arena"
            StopTournament.Visible = False
            BattleHaltButton.Visible = True
            BattleHaltButton.SetFocus
            FileMenu.Enabled = True
            ArenaMenu.Enabled = True
            ViewMenu.Enabled = True
            
            If PrintTournamentLog Then ProcessLog

            Exit Sub
        End If
    ElseIf TCB >= TournamentD.RobotList.ListCount And WhichFight >= TournamentD.DuelsN Then 'End Tournament
        'Duels are over iniz grouprounds
        TournamentSwitch = 1
        TCA = 0
        TCB = 0

        R3Present = True: R4Present = True: R5Present = True: R6Present = True
        
        ReDim NumberOfGRBattles(TournamentD.RobotList.ListCount)
        ReDim GRScore(TournamentD.RobotList.ListCount)
        
        PR1 = 0: PR2 = 0
        For counter = 1 To 50
            HistoryRec(1, counter) = 0: HistoryRec(2, counter) = 0
        Next counter
    ElseIf WhichFight >= TournamentD.DuelsN Or WhichFight = 0 Then  'Loading Robots
        PR1 = 0
        PR2 = 0

        For counter = 1 To 50
            HistoryRec(1, counter) = 0: HistoryRec(2, counter) = 0
        Next counter

        TCA = TCA + 1

        Robot1.Caption = TournamentD.RobotList.List(TCB - 1)
        R1path = TournamentD.TheDirList.List(TCB - 1) & "\" & TournamentD.RobotList.List(TCB - 1) & ".RWR"
        LoadRobot1
        
        Robot2.Caption = TournamentD.RobotList.List(TCA - 1)
        R2path = TournamentD.TheDirList.List(TCA - 1) & "\" & TournamentD.RobotList.List(TCA - 1) & ".RWR"
        LoadRobot2

        DuelScore1 = TCB - 1    'Set which to give score after rond TournamentD.DuelsN
        DuelScore2 = TCA - 1    'Set which to give score after rond TournamentD.DuelsN
    
        If TCA = TournamentD.RobotList.ListCount Then
            TCA = TCB + 1
            TCB = TCB + 1
        End If
        WhichFight = 1
    Else
        WhichFight = WhichFight + 1
    End If
    
    If TournamentSwitch = 0 Then
        If WindowMini Then
        sMainWindowCaption = "RoboWar 5 - Tournament: Duel " & (2 * TournamentD.RobotList.ListCount - DuelScore1 - 1) * DuelScore1 \ 2 + DuelScore2 - DuelScore1 & " of " & (TournamentD.RobotList.ListCount - 1) / 2 * TournamentD.RobotList.ListCount & _
        " - Round " & WhichFight & " of " & TournamentD.DuelsN
        Else
        MainWindow.Caption = "RoboWar 5 - Tournament: Duel " & (2 * TournamentD.RobotList.ListCount - DuelScore1 - 1) * DuelScore1 \ 2 + DuelScore2 - DuelScore1 & " of " & (TournamentD.RobotList.ListCount - 1) / 2 * TournamentD.RobotList.ListCount & _
        " - Round " & WhichFight & " of " & TournamentD.DuelsN
        End If
        
        BattleHaltButton_Click
        If WhichFight >= TournamentD.DuelsN Then
            SoloScore(DuelScore1) = SoloScore(DuelScore1) + PR1
            SoloScore(DuelScore2) = SoloScore(DuelScore2) + PR2
        End If
    End If
Loop

End Sub

Private Sub StopTournament_Click()
If MsgBox("Are you sure?", vbYesNo + vbDefaultButton2, "Stop the Tournament") = vbNo Then Exit Sub

RunningTournament = False
TitleTimer.Enabled = False
StopTournament.Visible = False
TitleTimer.Enabled = False
MainWindow.Caption = "RoboWar 5 - Arena"
BattleHaltButton.Visible = True

Load2.Visible = True
Load3.Visible = True

If R6Present Then
    Load4.Visible = True
    Load5.Visible = True
    Load6.Visible = True
Else
    Load4.Visible = False
    Load5.Visible = False
    Load6.Visible = False
End If

If PrintTournamentLog Then
    PrintTournamentLog = False
    Erase TournamentLog
    LogWhichBattle = 0
End If

If BattleHaltButton.Caption = "Halt" Then BattleHaltButton_Click
End Sub

Public Sub InizTeamTournament()
TournamentD.Hide

If RunningTournament Then MsgBox "You're already running a tournament!", , "Can't run two tournaments at the same time": Exit Sub

Dim ClockTime As Single
ClockTime = Timer

PrintTournamentLog = TournamentD.PrintLog.Value
If PrintTournamentLog Then ReDim TournamentLog(((TournamentD.RobotList.ListCount \ 3 - 1) / 2 * (TournamentD.RobotList.ListCount \ 3)) * TournamentD.DuelsN)

RunningTournament = True
R1Present = True: R2Present = True: R3Present = True: R4Present = True: R5Present = True: R6Present = True
AutoSetTeams

PR1.Visible = False: PR2.Visible = False: PR3.Visible = False: PR4.Visible = False: PR5.Visible = False: PR6.Visible = False
Points1X.Visible = False: Points2X.Visible = False: Points3X.Visible = False: Points4X.Visible = False: Points5X.Visible = False: Points6X.Visible = False
Damage1X.Visible = False: Damage2X.Visible = False: Damage3X.Visible = False: Damage4X.Visible = False: Damage5X.Visible = False: Damage6X.Visible = False
Energy1X.Visible = False: Energy2X.Visible = False: Energy3X.Visible = False: Energy4X.Visible = False: Energy5X.Visible = False: Energy6X.Visible = False

If Not ChronorsLimit.Checked Then ChronorsLimit_Click
If Replaying Then RepeatBattle_Click
If TestTourney.MandS.Value = 1 Eqv MoveAndShoot.Checked Then MoveAndShoot_Click
If TestTourney.CheckScoring.Value = 1 Eqv StandardScoring Then Scoring_Click

ResetHistory_Click

HighestToLowest = (Int(2 * Rnd) = 1)

Dim TCA As Long
Dim TCB As Long
Dim BattleNumber As Long

Dim Score() As Long
ReDim Score(TournamentD.RobotList.ListCount)
    
For TCA = 0 To TournamentD.RobotList.ListCount - 3 Step 3
    
    Robot1.Caption = TournamentD.RobotList.List(TCA)
    R1path = TournamentD.TheDirList.List(TCA) & "\" & TournamentD.RobotList.List(TCA) & ".RWR"
    LoadRobot1
    
    Robot2.Caption = TournamentD.RobotList.List(TCA + 1)
    R2path = TournamentD.TheDirList.List(TCA + 1) & "\" & TournamentD.RobotList.List(TCA + 1) & ".RWR"
    LoadRobot2
    
    Robot3.Caption = TournamentD.RobotList.List(TCA + 2)
    R3path = TournamentD.TheDirList.List(TCA + 2) & "\" & TournamentD.RobotList.List(TCA + 2) & ".RWR"
    LoadRobot3

    For TCB = TCA + 3 To TournamentD.RobotList.ListCount - 2 Step 3
        Robot4.Caption = TournamentD.RobotList.List(TCB)
        R4path = TournamentD.TheDirList.List(TCB) & "\" & TournamentD.RobotList.List(TCB) & ".RWR"
        LoadRobot4
        
        Robot5.Caption = TournamentD.RobotList.List(TCB + 1)
        R5path = TournamentD.TheDirList.List(TCB + 1) & "\" & TournamentD.RobotList.List(TCB + 1) & ".RWR"
        LoadRobot5
        
        Robot6.Caption = TournamentD.RobotList.List(TCB + 2)
        R6path = TournamentD.TheDirList.List(TCB + 2) & "\" & TournamentD.RobotList.List(TCB + 2) & ".RWR"
        LoadRobot6

        For BattleNumber = 1 To TournamentD.DuelsN
            If Not RunningTournament Then Exit Sub
            MainWindow.Caption = "RoboWar 5 - Tournament: Team " & (TCA \ 3 + 1) & " vs Team " & (TCB \ 3 + 1) & " - Duel " & BattleNumber & " of " & TournamentD.DuelsN
            
            BattleHaltButton_Click
        Next BattleNumber
        
        Score(TCA) = Val(PR1) + Val(PR2) + Val(PR3)
        Score(TCB) = Val(PR4) + Val(PR5) + Val(PR6)
        
        ResetHistory_Click
    Next
Next

Dim TheRecord As String
Dim highestscore As Long

TheRecord = "Team" & vbTab & vbTab & vbTab & vbTab & "Score" & vbCr

For TCB = 0 To TournamentD.RobotList.ListCount - 1 Step 3
    For TCA = 0 To TournamentD.RobotList.ListCount - 1 Step 3
        If Score(TCA) > Score(highestscore) Then highestscore = TCA
    Next TCA
    
    TheRecord = TheRecord & TFixTabs2(TournamentD.RobotList.List(highestscore)) & vbTab & vbTab & Score(highestscore) & vbCr
    
    Score(highestscore) = -1
Next TCB

TheRecord = Left$(TheRecord, Len(TheRecord) - 1)

RunningTournament = False
TitleTimer.Enabled = False
MainWindow.Caption = "RoboWar 5 - Arena"
StopTournament.Visible = False
BattleHaltButton.Visible = True
BattleHaltButton.SetFocus
FileMenu.Enabled = True
ArenaMenu.Enabled = True
ViewMenu.Enabled = True

ClockTime = Round((Timer - ClockTime) / 60, 1)
Dim timestring As String
timestring = Date & ", " & time

If TournamentD.DuelsN > 0 Then
    TournamentResults.TheTournamentResults = TheRecord
    TournamentResults.Caption = "Team Results"
    TournamentResults.Width = 210 * Screen.TwipsPerPixelX
    TournamentResults.OKButton.Left = 120
    
    Dim ControlLenght() As String
    ControlLenght = Split(TheRecord, vbCr)
    ControlLenght = Split(ControlLenght(0), vbTab)
    TournamentResults.Show 1, MainWindow
End If

TheRecord = TheRecord & vbCr & vbCr & vbCr & "********" & vbCr & vbCr & _
"Tournament completed " & timestring & vbCr & _
"Completed in " & ClockTime & " minutes " & vbCr & _
"Rounds " & TournamentD.DuelsN & vbCr & _
Scoring.Caption & vbCr & _
"RoboWar Version " & App.Major & "." & App.Minor & "." & App.Revision

Open TournamentD.SavedInFolder For Output As 30
    Print #30, TheRecord
Close 30

If PrintTournamentLog Then ProcessLog
End Sub

Public Sub InizTeamTestTournament()
TestTourney.Hide

If RunningTournament Then MsgBox "You're already running a tournament!", , "Can't run two tournaments at the same time": Exit Sub

Dim ClockTime As Single
ClockTime = Timer

PrintTournamentLog = TestTourney.PrintLog.Value
If PrintTournamentLog Then ReDim TournamentLog(TestTourney.RobotList.ListCount * TestTourney.DuelsN)

RunningTournament = True
R1Present = True: R2Present = True: R3Present = True: R4Present = True: R5Present = True: R6Present = True
AutoSetTeams

PR1.Visible = False: PR2.Visible = False: PR3.Visible = False: PR4.Visible = False: PR5.Visible = False: PR6.Visible = False
Points1X.Visible = False: Points2X.Visible = False: Points3X.Visible = False: Points4X.Visible = False: Points5X.Visible = False: Points6X.Visible = False
Damage1X.Visible = False: Damage2X.Visible = False: Damage3X.Visible = False: Damage4X.Visible = False: Damage5X.Visible = False: Damage6X.Visible = False
Energy1X.Visible = False: Energy2X.Visible = False: Energy3X.Visible = False: Energy4X.Visible = False: Energy5X.Visible = False: Energy6X.Visible = False

If Not ChronorsLimit.Checked Then ChronorsLimit_Click
If Replaying Then RepeatBattle_Click
If TestTourney.MandS.Value = 1 Eqv MoveAndShoot.Checked Then MoveAndShoot_Click
If TestTourney.CheckScoring.Value = 1 Eqv StandardScoring Then Scoring_Click

ResetHistory_Click

HighestToLowest = (Int(2 * Rnd) = 1)

Dim TCA As Long
Dim TCB As Long
Dim BattleNumber As Long

Dim Score As Long

Dim ProperName As String
ProperName = TestTourney.IamChoosedForTesting
ProperName = Right$(ProperName, InStr(StrReverse(ProperName), "\") - 1)
ProperName = Left$(ProperName, Len(ProperName) - 4)

R1path = TestTourney.IamChoosedForTesting
Robot1.Caption = ProperName
LoadRobot1

'''
Dim Cstart As Long
Const Crec = 116
Dim TeamTag As String * 765
Dim sTeam() As String

Open R1path For Binary As 1
Get 1, Crec, Cstart
Get 1, Cstart, TeamTag
Close 1
sTeam = Split(TeamTag, "\", 4)

Robot2.Caption = sTeam(1)
R2path = TestTourney.TeamPath & "\" & sTeam(1) & ".RWR"
LoadRobot2

If sTeam(2) = " " Then
    Robot3.Caption = sTeam(1)
    R3path = TestTourney.TeamPath & "\" & sTeam(1) & ".RWR"
    LoadRobot3
Else
    Robot3.Caption = sTeam(2)
    R3path = TestTourney.TeamPath & "\" & sTeam(2) & ".RWR"
    LoadRobot3
End If

Dim TheRecord As String
TheRecord = vbTab & vbTab & vbTab & "Opponent" & vbTab & ProperName

For TCB = 0 To TestTourney.RobotList.ListCount - 2 Step 3
    Robot4.Caption = TestTourney.RobotList.List(TCB)
    R4path = TestTourney.TheDirList.List(TCB) & "\" & TestTourney.RobotList.List(TCB) & ".RWR"
    LoadRobot4
    
    Robot5.Caption = TestTourney.RobotList.List(TCB + 1)
    R5path = TestTourney.TheDirList.List(TCB + 1) & "\" & TestTourney.RobotList.List(TCB + 1) & ".RWR"
    LoadRobot5
    
    Robot6.Caption = TestTourney.RobotList.List(TCB + 2)
    R6path = TestTourney.TheDirList.List(TCB + 2) & "\" & TestTourney.RobotList.List(TCB + 2) & ".RWR"
    LoadRobot6

    For BattleNumber = 1 To TestTourney.DuelsN
        If Not RunningTournament Then Exit Sub
        MainWindow.Caption = "RoboWar 5 - Tournament: Team " & (TCA \ 3 + 1) & " vs Team " & (TCB \ 3 + 1) & " - Duel " & BattleNumber & " of " & TestTourney.DuelsN
        BattleHaltButton_Click
    Next BattleNumber
    
    TheRecord = TheRecord & vbCr & TFixTabs2(TestTourney.RobotList.List(TCB)) & vbTab & Str(Val(PR4) + Val(PR5) + Val(PR6)) & vbTab & vbTab & Str(Val(PR1) + Val(PR2) + Val(PR3))
    Score = Score + Val(PR1) + Val(PR2) + Val(PR3)
    
    ResetHistory_Click
Next

'Dim highestscore As Long

RunningTournament = False
TitleTimer.Enabled = False
MainWindow.Caption = "RoboWar 5 - Arena"
StopTournament.Visible = False
BattleHaltButton.Visible = True
BattleHaltButton.SetFocus
FileMenu.Enabled = True
ArenaMenu.Enabled = True
ViewMenu.Enabled = True

ClockTime = Round((Timer - ClockTime) / 60, 1)
Dim timestring As String
timestring = Date & ", " & time

TournamentResults.TheTournamentResults = TheRecord

Dim ControlLenght() As String
ControlLenght = Split(TheRecord, vbCr)
ControlLenght = Split(ControlLenght(0), vbTab)

TournamentResults.Width = (210 + 6 * Len(ControlLenght(4))) * Screen.TwipsPerPixelX
TournamentResults.Caption = "Team Results"
TournamentResults.Show 1, MainWindow

TheRecord = TheRecord & vbCr & vbCr & vbCr & "********" & vbCr & vbCr & _
"Test runned " & timestring & vbCr & _
"Completed in " & ClockTime & " minutes " & vbCr & _
"Rounds " & TestTourney.DuelsN & vbCr & _
Scoring.Caption & vbCr & _
"RoboWar Version " & App.Major & "." & App.Minor & "." & App.Revision

Open TestTourney.SavedInFolder For Output As 30
    Print #30, TheRecord
Close 30

If PrintTournamentLog Then ProcessLog
End Sub

Public Sub InizTestTournament() ''''test tournament
TestTourney.Hide

If RunningTournament Then MsgBox "You're already running a tournament!", , "Can't run two tournaments at the same time": Exit Sub

Dim ClockTime As Single
ClockTime = Timer

ClearTeams

PrintTournamentLog = TestTourney.PrintLog.Value
If PrintTournamentLog Then ReDim TournamentLog(TestTourney.RobotList.ListCount * TestTourney.DuelsN + TestTourney.GroupN * 6)

Dim GRRecord As String
RunningTournament = True
R1Present = True
R2Present = True
R3Present = False
R4Present = False
R5Present = False
R6Present = False
R3Icon = LoadPicture()
R4Icon = LoadPicture()
R5Icon = LoadPicture()
R6Icon = LoadPicture()

Robot3 = "No Robot Selected"
Robot4 = "No Robot Selected"
Robot5 = "No Robot Selected"
Robot6 = "No Robot Selected"

If TestTourney.GroupN = 0 And SelectedRobot > 2 Then
    SelectedRobot = 1
    Robot1.BackColor = vbBlack: Robot1.ForeColor = vbWhite
    Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite
    Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite
    Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite
    Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite
    Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
End If

Dim counter As Long

For counter = 3 To 6
    RobotLeft(counter) = -counter * 100
    DR(counter).Visible = False
    EnergyDisplay(counter).Visible = False  'Ny
    ER(counter).Visible = False  'Ny
Next counter
PR3.Visible = False: PR4.Visible = False: PR5.Visible = False: PR6.Visible = False
Points3X.Visible = False: Points4X.Visible = False: Points5X.Visible = False: Points6X.Visible = False
Damage3X.Visible = False: Damage4X.Visible = False: Damage5X.Visible = False: Damage6X.Visible = False
Energy3X.Visible = False: Energy4X.Visible = False: Energy5X.Visible = False: Energy6X.Visible = False

If Not ChronorsLimit.Checked Then ChronorsLimit_Click
If Replaying Then RepeatBattle_Click
If TestTourney.MandS.Value = 1 Eqv MoveAndShoot.Checked Then MoveAndShoot_Click
If TestTourney.CheckScoring.Value = 1 Eqv StandardScoring Then Scoring_Click

ResetHistory_Click

HighestToLowest = (Int(2 * Rnd) = 1)
'Loading the robot set for test
Dim ProperName As String
ProperName = TestTourney.IamChoosedForTesting
ProperName = Right$(ProperName, InStr(StrReverse(ProperName), "\") - 1)
ProperName = Left$(ProperName, Len(ProperName) - 4)

Robot1.Caption = ProperName

R1path = TestTourney.IamChoosedForTesting
LoadRobot1
''''''''''''''''''''''''''
Dim TheRecord As String
Dim OpponentNumber As Long
Dim BattleNumber As Long
Dim MyTotalScore As Long

For OpponentNumber = 0 To TestTourney.RobotList.ListCount - 1
        PR1 = 0: PR2 = 0
    
        For counter = 1 To 50
            HistoryRec(1, counter) = 0: HistoryRec(2, counter) = 0
        Next counter
    
        Robot2.Caption = TestTourney.RobotList.List(OpponentNumber)
        R2path = TestTourney.TheDirList.List(OpponentNumber) & "\" & TestTourney.RobotList.List(OpponentNumber) & ".RWR"
        LoadRobot2
    
        For BattleNumber = 1 To TestTourney.DuelsN
            If Not RunningTournament Then Exit Sub
            MainWindow.Caption = "RoboWar 5 - Testing " & ProperName & ": Against Robot " & (OpponentNumber + 1) & " of " & TestTourney.RobotList.ListCount & " - Duel " & BattleNumber & " of " & TestTourney.DuelsN
            BattleHaltButton_Click
        Next BattleNumber
        
        MyTotalScore = MyTotalScore + PR1
        TheRecord = TheRecord & TFixTabs2(Robot2.Caption) & vbTab & PR2 & vbTab & vbTab & PR1 & vbCr
Next OpponentNumber

If TestTourney.DuelsN <> 0 Then
    TheRecord = vbTab & vbTab & vbTab & "Opponent" & vbTab & ProperName & vbCr & TheRecord
    Dim WinRecord As Single     'That what it's all about
    WinRecord = MyTotalScore / (TestTourney.RobotList.ListCount * 2)    'Splited to avoid
    WinRecord = WinRecord / TestTourney.DuelsN * 100                    'overflow
    TheRecord = TheRecord & vbCr & vbCr & Round(WinRecord) & "% WinRecord"
End If

''''GR
If TestTourney.GroupN <> 0 Then

Dim GRScore() As Long
Dim NumberOfGRBattles() As Long
Dim RandomRobot(2 To 6) As Long
ReDim GRScore(TestTourney.RobotList.ListCount)
ReDim NumberOfGRBattles(TestTourney.RobotList.ListCount)
Dim RobotGRScore As Long

R3Present = True: R4Present = True: R5Present = True: R6Present = True

PR1 = 0: PR2 = 0: PR3 = 0: PR4 = 0: PR5 = 0: PR6 = 0
For counter = 1 To 50
    HistoryRec(1, counter) = 0: HistoryRec(2, counter) = 0
    HistoryRec(3, counter) = 0: HistoryRec(4, counter) = 0
    HistoryRec(5, counter) = 0: HistoryRec(6, counter) = 0
Next counter

For OpponentNumber = 1 To TestTourney.GroupN
    RobotGRScore = RobotGRScore + PR1
    GRScore(RandomRobot(2)) = GRScore(RandomRobot(2)) + PR2
    GRScore(RandomRobot(3)) = GRScore(RandomRobot(3)) + PR3
    GRScore(RandomRobot(4)) = GRScore(RandomRobot(4)) + PR4
    GRScore(RandomRobot(5)) = GRScore(RandomRobot(5)) + PR5
    GRScore(RandomRobot(6)) = GRScore(RandomRobot(6)) + PR6
    
    RandomRobot(2) = Int(TestTourney.RobotList.ListCount * Rnd)
    NumberOfGRBattles(RandomRobot(2)) = NumberOfGRBattles(RandomRobot(2)) + 1
redorandom3:
    RandomRobot(3) = Int(TestTourney.RobotList.ListCount * Rnd)
    If RandomRobot(3) = RandomRobot(2) Then GoTo redorandom3
    NumberOfGRBattles(RandomRobot(3)) = NumberOfGRBattles(RandomRobot(3)) + 1
redorandom4:
    RandomRobot(4) = Int(TestTourney.RobotList.ListCount * Rnd)
    If RandomRobot(4) = RandomRobot(3) Or RandomRobot(4) = RandomRobot(2) Then GoTo redorandom4
    NumberOfGRBattles(RandomRobot(4)) = NumberOfGRBattles(RandomRobot(4)) + 1
redorandom5:
    RandomRobot(5) = Int(TestTourney.RobotList.ListCount * Rnd)
    If RandomRobot(5) = RandomRobot(4) Or RandomRobot(5) = RandomRobot(3) Or RandomRobot(5) = RandomRobot(2) Then GoTo redorandom5
    NumberOfGRBattles(RandomRobot(5)) = NumberOfGRBattles(RandomRobot(5)) + 1
redorandom6:
    RandomRobot(6) = Int(TestTourney.RobotList.ListCount * Rnd) ' + 1
    If RandomRobot(6) = RandomRobot(5) Or RandomRobot(6) = RandomRobot(4) Or RandomRobot(6) = RandomRobot(3) Or RandomRobot(6) = RandomRobot(2) Then GoTo redorandom6
    NumberOfGRBattles(RandomRobot(6)) = NumberOfGRBattles(RandomRobot(6)) + 1
    
    Robot2.Caption = TestTourney.RobotList.List(RandomRobot(2))
    R2path = TestTourney.TheDirList.List(RandomRobot(2)) & "\" & TestTourney.RobotList.List(RandomRobot(2)) & ".RWR"
    LoadRobot2
    Robot3.Caption = TestTourney.RobotList.List(RandomRobot(3))
    R3path = TestTourney.TheDirList.List(RandomRobot(3)) & "\" & TestTourney.RobotList.List(RandomRobot(3)) & ".RWR"
    LoadRobot3
    Robot4.Caption = TestTourney.RobotList.List(RandomRobot(4))
    R4path = TestTourney.TheDirList.List(RandomRobot(4)) & "\" & TestTourney.RobotList.List(RandomRobot(4)) & ".RWR"
    LoadRobot4
    Robot5.Caption = TestTourney.RobotList.List(RandomRobot(5))
    R5path = TestTourney.TheDirList.List(RandomRobot(5)) & "\" & TestTourney.RobotList.List(RandomRobot(5)) & ".RWR"
    LoadRobot5
    Robot6.Caption = TestTourney.RobotList.List(RandomRobot(6))
    R6path = TestTourney.TheDirList.List(RandomRobot(6)) & "\" & TestTourney.RobotList.List(RandomRobot(6)) & ".RWR"
    LoadRobot6

    PR1 = 0: PR2 = 0: PR3 = 0: PR4 = 0: PR5 = 0: PR6 = 0
    For counter = 1 To 50
        HistoryRec(1, counter) = 0: HistoryRec(2, counter) = 0: HistoryRec(3, counter) = 0: HistoryRec(4, counter) = 0: HistoryRec(5, counter) = 0: HistoryRec(6, counter) = 0
    Next counter

    For BattleNumber = 1 To 6
        If Not RunningTournament Then Exit Sub
        MainWindow.Caption = "RoboWar 5 - Testing " & ProperName & ": Group Round " & OpponentNumber & " of " & TestTourney.GroupN & _
        " - Bout " & BattleNumber & " of 6"
        BattleHaltButton_Click
    Next BattleNumber
Next OpponentNumber

'Print GR Score
'roster[i].groupScore *= (double)numGroups/roster[i].numGroupFights;

For counter = 0 To TestTourney.RobotList.ListCount - 1
    If NumberOfGRBattles(counter) > 0 Then
        GRScore(counter) = GRScore(counter) * TestTourney.GroupN / NumberOfGRBattles(counter)
    Else
        GRScore(counter) = 0
    End If
Next counter

Dim highestscore As Long

For OpponentNumber = 0 To TestTourney.RobotList.ListCount - 1
    For counter = 0 To TestTourney.RobotList.ListCount - 1
        If GRScore(counter) > GRScore(highestscore) Then highestscore = counter
    Next counter

    If RobotGRScore > GRScore(highestscore) Then
        GRRecord = GRRecord & vbCr & TFixTabs2(ProperName) & vbTab & RobotGRScore
        RobotGRScore = -2
    End If
    
    GRRecord = GRRecord & vbCr & TFixTabs2(TestTourney.RobotList.List(highestscore)) & vbTab & GRScore(highestscore)
    GRScore(highestscore) = -1
Next OpponentNumber

If RobotGRScore <> -2 Then GRRecord = GRRecord & vbCr & TFixTabs2(ProperName) & vbTab & RobotGRScore    'In case it finishes last

Load2.Visible = True: Load3.Visible = True
Load4.Visible = True: Load5.Visible = True
Load5.Visible = True: Load6.Visible = True
Else
    Load2.Visible = True
    Load3.Visible = True
End If
    
RunningTournament = False
TitleTimer.Enabled = False
MainWindow.Caption = "RoboWar 5 - Arena"
StopTournament.Visible = False
BattleHaltButton.Visible = True
BattleHaltButton.SetFocus
FileMenu.Enabled = True
ArenaMenu.Enabled = True
ViewMenu.Enabled = True

ClockTime = Round((Timer - ClockTime) / 60, 1)
Dim timestring As String
timestring = Date & ", " & time

If TestTourney.DuelsN > 0 Then
    TournamentResults.TheTournamentResults = TheRecord
    TournamentResults.Caption = "Testing Results - Duel"
    
    Dim ControlLenght() As String
    ControlLenght = Split(TheRecord, vbCr)
    ControlLenght = Split(ControlLenght(0), vbTab)
    TournamentResults.Width = (210 + 6 * Len(ControlLenght(4))) * Screen.TwipsPerPixelX
    TournamentResults.Show 1, MainWindow
Else
    TheRecord = ""
End If

If TestTourney.GroupN > 0 Then
    TournamentResults.TheTournamentResults = Right$(GRRecord, Len(GRRecord) - 1)
    TournamentResults.Caption = "Testing Results - Group Rounds"
    TournamentResults.Width = 3800
    
    TournamentResults.Show 1, MainWindow
    
    GRRecord = vbCr & vbCr & vbCr & " GROUP" & vbCr & GRRecord
End If

TheRecord = vbCr & " DUEL" & vbCr & vbCr & TheRecord & GRRecord

TheRecord = TheRecord & vbCr & vbCr & vbCr & "********" & vbCr & vbCr & _
"Test runned " & timestring & vbCr & _
"Completed in " & ClockTime & " minutes " & vbCr & _
"Duels " & TestTourney.DuelsN & " - Groups " & TestTourney.GroupN & vbCr & _
Scoring.Caption & vbCr & _
"RoboWar Version " & App.Major & "." & App.Minor & "." & App.Revision

Open TestTourney.SavedInFolder For Output As 30
    Print #30, TheRecord
Close 30

If PrintTournamentLog Then ProcessLog

End Sub

Private Sub ProcessLog()
'KILLS OCH KILLER
' kommer inte alltid att stämma med varandra eftersom kills kan bli borttagna

PrintTournamentLog = False
LogWhichBattle = 0

Dim TheLog As String

TheLog = "Name" & vbTab & vbTab & vbTab & vbTab & " Killer" & vbTab & vbTab & vbTab & vbTab & "Death Time" & vbTab & "Kill Points" & vbTab & "Survival Points" & vbCr

Dim c As Long
Dim i As Long
Dim TheKiller As String
Dim TheDeathTime As String

CreatingLog.Show
Dim Done As Long
Done = UBound(TournamentLog)

Dim LogFileName As String
LogFileName = App.Path & "\TournamentLog.txt"

If Dir(LogFileName) <> "" Then Kill LogFileName
Open LogFileName For Append As #100

For c = 0 To UBound(TournamentLog)

    For i = 1 To 6
        If LenB(TournamentLog(c).WhosWho(i)) = 0 Then Exit For
    
        If TournamentLog(c).DeathTime(i) = 32767 Then
            TheKiller = "-" & vbTab & vbTab & vbTab & vbTab
            TheDeathTime = "-"
        ElseIf TournamentLog(c).killer(i) <= 6 Then
            TheKiller = TFixTabs3(TournamentLog(c).WhosWho(TournamentLog(c).killer(i)))
            TheDeathTime = TournamentLog(c).DeathTime(i)
        Else
            Select Case TournamentLog(c).killer(i)
                Case 253
                    TheKiller = "Overloaded" & vbTab & vbTab & vbTab
                Case 254
                    TheKiller = "Bugged" & vbTab & vbTab & vbTab
                Case 255
                    TheKiller = "Collision/Suicide" & vbTab
            End Select
            TheDeathTime = TournamentLog(c).DeathTime(i)
        End If
    
        TheLog = TheLog & _
        TFixTabs3(TournamentLog(c).WhosWho(i)) & _
        TheKiller & vbTab & _
        TheDeathTime & vbTab & vbTab & _
        TournamentLog(c).Kills(i) & vbTab & vbTab & _
        TournamentLog(c).SurvivalPoints(i) & _
        vbCr
    Next i

    TheLog = TheLog & vbCr
    
    CreatingLog.Progress = Round((c / Done) * 100)
    DoEvents
    
    If LenB(TheLog) >= 50000 Then '50000
        Print #100, TheLog
        TheLog = vbCr
    End If
    
    If CreatingLog.CanceledLog Then GoTo didcancel
Next c

Print #100, TheLog

didcancel:
Unload CreatingLog
Close 100
Erase TournamentLog
End Sub

Private Function TFixTabs3(TheName As String) As String
Dim HowLongNameIs As Long       'Used for tournament log
HowLongNameIs = Len(TheName)

If HowLongNameIs < 25 Then  '25
    TFixTabs3 = TheName & Space(25 - HowLongNameIs) '25
Else
    TFixTabs3 = Left$(TheName, 23) & "  "  '25
End If

End Function

Private Sub DebuggerPaint(DbgRobotAlive As Long, DbgTurretType As Long, DNN As Long)

If DbgRobotAlive = 1 Then
    Arena.PaintPicture Robot_(DNN), RobotLeft(DNN) - 16, RobotTop(DNN) - 16
    If DbgTurretType = 1 Then
        Arena.Line (RobotLeft(DNN), RobotTop(DNN))-(TurretX2(DNN), TurretY2(DNN)), vbBlack
    ElseIf DbgTurretType = 2 Then
        Arena.Circle (TurretX2(DNN), TurretY2(DNN)), 1, vbBlack
    End If
ElseIf DbgRobotAlive > 230 Then
    DeathAnimation DNN, DbgRobotAlive
End If

End Sub

Private Sub DebuggerPaintShot(TheShot As ShotPrivateType)
Select Case TheShot.ShotType
    Case 200
    Case Missile
        Arena.Line (TheShot.ShotX, TheShot.ShotY)-(TheShot.ShotX + Sin5(TheShot.ShotAngle), TheShot.ShotY - Cos5(TheShot.ShotAngle)), vbBlack
    Case Hellbore
        Arena.FillColor = vbApplicationWorkspace      'Creates new shotprojection
        Arena.Circle (TheShot.ShotX, TheShot.ShotY), 4, vbBlack
    Case Stunner
        Arena.Line (TheShot.ShotX - 2, TheShot.ShotY - 2)-(TheShot.ShotX + 3, TheShot.ShotY + 3), vbBlack
        Arena.Line (TheShot.ShotX + 2, TheShot.ShotY - 2)-(TheShot.ShotX - 3, TheShot.ShotY + 3), vbBlack
    Case XplosiveBulletDetonation
        If Chronon - TheShot.ShotFireTime <= 4 Then '10
            Arena.FillColor = &HA1A1A2
            Arena.Circle (TheShot.ShotX, TheShot.ShotY), 12 * (Chronon - TheShot.ShotFireTime) - 12, &H808080
        End If
    Case TakeNuke
        If Chronon - TheShot.ShotFireTime <= 10 Then '10
            Arena.FillColor = &HA1A1A2
            Arena.Circle (TheShot.ShotX, TheShot.ShotY), 5 * (Chronon - TheShot.ShotFireTime), &H808080
        End If
    Case MegaNuke
        If Chronon - TheShot.ShotFireTime <= MegaNukeBLASTRADIUS Then '10
            Arena.FillColor = &H80000013
            Arena.Circle (TheShot.ShotX, TheShot.ShotY), 5 * (Chronon - TheShot.ShotFireTime), &H808080
        End If
    Case Mine
        Arena.FillStyle = 1
        Arena.Circle (TheShot.ShotX, TheShot.ShotY), 4, vbBlack
        Arena.FillStyle = 0
        Arena.FillColor = vbBlack
        Arena.Circle (TheShot.ShotX, TheShot.ShotY), 2, vbBlack
    Case Drone
        Dim DNR As Long
        If Abs(TheShot.ShotY - RobotTop(TheShot.ShotAngle)) <= 8 Then   '2 '8
            If TheShot.ShotX < RobotLeft(TheShot.ShotAngle) Then
                Arena.PaintPicture DroneR, TheShot.ShotX - 2, TheShot.ShotY - 2
            Else
                Arena.PaintPicture DroneL, TheShot.ShotX - 2, TheShot.ShotY - 2
            End If
        ElseIf Abs(TheShot.ShotX - RobotLeft(TheShot.ShotAngle)) <= 8 Then '2 '8
            If TheShot.ShotY < RobotTop(TheShot.ShotAngle) Then
                Arena.PaintPicture DroneD, TheShot.ShotX - 2, TheShot.ShotY - 2
            Else
                Arena.PaintPicture DroneU, TheShot.ShotX - 2, TheShot.ShotY - 2 '- 2 för att den börjar måla den i vänstra hörnet
            End If
        Else
            If TheShot.ShotX < RobotLeft(TheShot.ShotAngle) Then DNR = 2 Else DNR = 0
            If TheShot.ShotY < RobotTop(TheShot.ShotAngle) + 16 Then DNR = DNR + 4 Else DNR = DNR + 3
            Arena.PaintPicture DroneDiagonally(DNR), TheShot.ShotX - 2, TheShot.ShotY - 2
        End If
    Case Laser
        Arena.Line (TurretX2(TheShot.Shooter), TurretY2(TheShot.Shooter))-(TheShot.ShotX, TheShot.ShotY), vbBlue
        Arena.FillColor = vbBlue: Arena.Circle (TheShot.ShotX, TheShot.ShotY), 4, vbBlue
    Case SHOTHIT
        If TheShot.ShotAngle < 100 Then    'Regular
            Arena.FillColor = vbRed: Arena.Circle (TheShot.ShotX, TheShot.ShotY), 4, vbRed
        ElseIf TheShot.ShotAngle < 1000 Then   'Stunner
            Arena.FillColor = vbGreen: Arena.Circle (TheShot.ShotX, TheShot.ShotY), 4, vbGreen
        End If
    Case Else
        Arena.FillColor = vbBlack      'Creates new shotprojection
        Arena.Circle (TheShot.ShotX, TheShot.ShotY), 2, vbBlack
End Select
End Sub

Private Sub PrintInts(DInton As Boolean, _
                      DLeftParam As Long, DRightParam As Long, DTopParam As Long, DBotParam As Long, _
                      DLeftInst As Long, DRightInst As Long, DTopInst As Long, DBotInst As Long, _
                      DRadarParam As Long, DRadarInst As Long, DRangeInst As Long, DRangeParam As Long, _
                      DRobotQuePos As Long, RobotIntQue1 As Long, RobotIntQue2 As Long)

Dim mess As String

mess = "Inton = " & DInton _
& vbLf & "Left: " & DLeftParam & " / " & DLeftInst _
& vbLf & "Right: " & DRightParam & " / " & DRightInst _
& vbLf & "Top: " & DTopParam & " / " & DTopInst _
& vbLf & "Bot: " & DBotParam & " / " & DBotInst _
& vbLf & "Range: " & DRangeParam & " / " & DRangeInst _
& vbLf & "Radar: " & DRadarParam & " / " & DRadarInst _
& vbLf & "QueNum: " & DRobotQuePos

If DRobotQuePos >= 1 Then
mess = mess & vbLf & "QuePos1: " & RobotIntQue1
End If

If DRobotQuePos >= 2 Then
mess = mess & vbLf & "QuePos2: " & RobotIntQue2
End If

DebuggingWindow.Ints.Cls
DebuggingWindow.Ints.Print mess
End Sub

Private Function TFixTabs2(TheName As String) As String
Dim HowLongNameIs As Long       'Used for tournament results
HowLongNameIs = Len(TheName)

If HowLongNameIs < 25 Then  '25
    TFixTabs2 = TheName & Space(25 - HowLongNameIs) '25
Else
    TFixTabs2 = Left$(TheName, 20)  '25
End If

End Function

''Nya error handler

Private Function ShowErrorMessageParam(MessageCode As Long, RNN_R As Long, Chronon As Long, ChrononExecutor1_R As Long, RobotInstPos_R As Long, TopStack As Long) As Long
Dim ReturnError As String
Dim sTopStack As String
sTopStack = S(TopStack)

Select Case MessageCode
    Case BuggyStore
        ReturnError = "Illegal 'STORE' parameter " & sTopStack
    Case BuggySetparam
        ReturnError = "Illegal 'SETPARAM' parameter " & sTopStack
    Case BuggySetint
        ReturnError = "Illegal 'SETINT' parameter " & sTopStack
    Case Else
        ReturnError = "Bug in the game. Please report this bug."
End Select
    
ReturnError = ReturnError & vbLf & "Instruction No. " & RobotInstPos_R & vbLf & vbLf & GetRobot(RNN_R) & vbTab & "(Robot Numer " & RNN_R & ")" & vbCr & "Chronon " & Chronon & vbTab & vbTab & "Processor Position " & ChrononExecutor1_R & vbLf & vbCr & vbCr & "Would you like to have the instruction that caused this crash highlighted?" & vbCr & "(Press cancel to stop the battle.)"

ShowErrorMessageParam = MsgBox(ReturnError, vbCritical + vbYesNoCancel + vbDefaultButton2, "Bug Alert")                  'Response
End Function

Private Function ShowErrorMessage(MessageCode As Long, RNN_R As Long, Chronon As Long, ChrononExecutor1_R As Long, RobotInstPos_R As Long, MachineCode_R As Long) As Long
Dim ReturnError As String
Dim sMachineCode_R As String
sMachineCode_R = S(MachineCode_R)

If MachineCode_R = insEND Then
    If ChrononExecutor1_R = 0 And RobotInstPos_R = 0 Then
        ReturnError = "Robot not compiled"
    Else
        ReturnError = "End of code reached"
    End If
Else
    Select Case MessageCode
        Case BuggyDivRelated
            If MachineCode_R = insMOD Then
                ReturnError = "Mod by zero" '& sMachineCode_R
            Else
                ReturnError = "Division by zero " & sMachineCode_R
            End If
        Case BuggyOverflow
            ReturnError = "Stack overflow " & sMachineCode_R
        Case BuggyDivision
            ReturnError = "Division by zero /" '& sMachineCode_R
        Case BuggySquare
            ReturnError = "Square root of negative number"
        Case BuggyRecall
            ReturnError = "Variable not provided RECALL"
        Case BuggyNearest
            ReturnError = "Processor speed to high to use NEAREST"
        Case BuggyDestination
            ReturnError = "Jump destination not in program " & sMachineCode_R
        Case BuggyUnderflow
            ReturnError = "Stack underflow " & sMachineCode_R
        Case BuggyUnknownOrIllegal
            ReturnError = "Unknown or illegal instruction " & sMachineCode_R
        Case BuggyNumberOutofBounds
            ReturnError = "Number out of bounds " & sMachineCode_R
        Case BuggyChannel
            ReturnError = "Invalid channel (Channels ranges from 1 to 10)"
        Case BuggyMissiles
            ReturnError = "Missiles not enabled."
        Case BuggyStunners
            ReturnError = "Stunners not enabled."
        Case BuggyTacNukes
            ReturnError = "TacNukes not enabled."
        Case BuggyHellbores
            ReturnError = "Hellbores not enabled."
        Case BuggyMines
            ReturnError = "Mines not enabled."
        Case BuggyLasers
            ReturnError = "Lasers not enabled."
        Case BuggyDrones
            ReturnError = "Drones not enabled."
        Case BuggyProbes
            ReturnError = "Probes not enabled."
        Case Else
            ReturnError = "Bug in the game. Please report this bug. " & sMachineCode_R
'        Case Else
'            ReturnError = "An error in the error handler has occured. We don't know why your robot died."
    End Select
End If
    
ReturnError = ReturnError & vbLf & "Instruction No. " & RobotInstPos_R & vbLf & vbLf & GetRobot(RNN_R) & vbTab & "(Robot Numer " & RNN_R & ")" & vbCr & "Chronon " & Chronon & vbTab & vbTab & "Processor Position " & ChrononExecutor1_R & vbLf & vbCr & vbCr & "Would you like to have the instruction that caused this crash highlighted?" & vbCr & "(Press cancel to stop the battle.)"

ShowErrorMessage = MsgBox(ReturnError, vbCritical + vbYesNoCancel + vbDefaultButton2, "Bug Alert")                  'Response
End Function

Private Sub ShowMoveAndShootMessage(MoveShootingRobot As Long, ChrononExecutor1_MSR As Long, RobotInstPos_MSR As Long)
If Not RunningTournament Then
    If ShowMoveAndShoot.Checked Then
        Dim MoveAndShootErrorMessage As String
        
        MoveAndShootErrorMessage = _
        "A robot can not move and shoot in the same chronon. The energy for the second operation is lost." & vbLf & vbLf & _
        GetRobot(MoveShootingRobot) & vbTab & "(Robot Numer " & MoveShootingRobot & ")" & vbCr & _
        "Instruction No. " & RobotInstPos_MSR & vbLf & _
        "Chronon " & Chronon & vbTab & vbTab & "Processor Position " & ChrononExecutor1_MSR & vbCr & vbCr & _
        "Would you like to disable Move and Shoot messages?"
        
        If MsgBox(MoveAndShootErrorMessage, vbYesNo + vbDefaultButton2, "Move and Shoot violation") = vbYes Then ShowMoveAndShoot.Checked = False
    End If
End If

End Sub
                                       
Private Sub DONTSHOWBATTLE()
'This is the nondisplayed battle engine
'which isn't anything else than the regular battle engine with all graphical and sounds stuffs removed

    'Pros and cons compared to have a hybrid battle engine for both
'Pros
'+ It's faster than a hybrid battle engine would have been
'+ It doesn't slow down the regular battle engine with alot of "If BattleAreDisplayed then"
' (As we all know, painting shots are integrated in the routine that moves them, therefore it'll be a lot of
' "If BattleAreDisplayed then" if I would construct it the other way instead.)
'+ No need to make the code more messy with alot of "If BattleAreDisplayed then"

'Cons
'- No possibility to switch between displayed and nondisplayed battle during a battle
'   (This isn't that bad IMO. It doesn't take that long to finish the ongoing battle in a tournament in displayed-fast. Has honestly never bothered me that I can't switch in the same battle.)
'- I have to update two codes

'Debugging variables
Dim ErrorCode As Long
Dim RandomCounter As Long

'Robotarnas maskinkod - The robots' machinecode
Dim MachineCode(1 To 6, 4999) As Long    '0-4999 = RobotInstructions
Dim RobotInstPos(1 To 6) As Long
                                        
'Robotarnas Stack - The robots' Stacks
Dim RobotStack(1 To 6, 1 To 100) As Long     'long
Dim RobotStackPos(1 To 6) As Long           'How many numbers the robots has on it's stack

'Robotarnas Interupptsköer - The robots' interupps ques
Dim RobotIntQue(1 To 6, 1 To 100) As Long
Dim RobotQuePos(1 To 6) As Long
Dim IntID(1 To 6, 1 To 100) As Long

'Robots hardware
Dim RobotShield(1 To 6) As Long
Dim RobotEnergy(1 To 6) As Long
Dim RobotProSpeed(1 To 6) As Long
Dim RobotMissiles(1 To 6) As Long
Dim RobotTacNukes(1 To 6) As Long
Dim RobotBullets(1 To 6) As Long
Dim RobotStunners(1 To 6) As Long
Dim RobotHellbores(1 To 6) As Long
Dim RobotMines(1 To 6) As Long
Dim RobotLasers(1 To 6) As Long
Dim RobotDrones(1 To 6) As Long
Dim RobotProbes(1 To 6) As Long

'Robotarnas variabler - The robots' variables
Dim RA(1 To 6) As Long
Dim RB(1 To 6) As Long
Dim RC(1 To 6) As Long
Dim RD(1 To 6) As Long
Dim RE(1 To 6) As Long
Dim RF(1 To 6) As Long
Dim RG(1 To 6) As Long
Dim RH(1 To 6) As Long
Dim RI(1 To 6) As Long
Dim RJ(1 To 6) As Long 'Used to be ints, but it seems like people using them
Dim RK(1 To 6) As Long 'to store placerecalls
Dim RL(1 To 6) As Long 'For example "radar' a' store" won't work with longs
Dim RM(1 To 6) As Long 'long is slower, but robots simply doesn't work otherwise.
Dim RN(1 To 6) As Long
Dim RO(1 To 6) As Long
Dim RP(1 To 6) As Long
Dim RQ(1 To 6) As Long
Dim RR(1 To 6) As Long
Dim RS(1 To 6) As Long
Dim RT(1 To 6) As Long
Dim RU(1 To 6) As Long
Dim RV(1 To 6) As Long
Dim RZ(1 To 6) As Long
Dim RW(1 To 6) As Long
Dim RVRECALL(1 To 6, 100) As Long

'Probes and Interupps
Dim ProbeSet(1 To 6) As Long '0 = Damage 1 = Energy 2 = Shield 3 = ID '5 = Aim 6 = look 7 = scan 4 = Teammates - Currently disabled 'cause of no teams

Dim Inton(1 To 6) As Boolean
Dim RangeInst(1 To 6) As Long
Dim RangeParam(1 To 6) As Long
Dim RadarInst(1 To 6) As Long
Dim RadarParam(1 To 6) As Long
Dim ChrononInst(1 To 6) As Long  'Måste alltid dras ifrån en då denna sätts för att mataren matar fram + 1
Dim ChrononParam(1 To 6) As Long
Dim RobotsInst(1 To 6) As Long
Dim RobotsParam(1 To 6) As Long
Dim RightParam(1 To 6) As Long
Dim LeftParam(1 To 6) As Long
Dim TopParam(1 To 6) As Long
Dim BotParam(1 To 6) As Long
Dim RightInst(1 To 6) As Long
Dim LeftInst(1 To 6) As Long
Dim TopInst(1 To 6) As Long
Dim BotInst(1 To 6) As Long
Dim CollisionInst(1 To 6) As Long
Dim WallInst(1 To 6) As Long
Dim DamageInst(1 To 6) As Long
Dim DamageParam(1 To 6) As Long
Dim ShieldInst(1 To 6) As Long
Dim ShieldParam(1 To 6) As Long
Dim HistoryParam(1 To 6) As Long

' Team Variables
Dim RSignal(1 To 3, 1 To 10) As Long
Dim RChannel(1 To 6) As Long
Dim TeammatesInst(1 To 6) As Long
Dim TeammatesParam(1 To 6) As Long
Dim SignalInst(1 To 6) As Long
Dim SignalParam(1 To 6) As Long

'Things that can be recalled
Dim RCollision(1 To 6)  As Long
Dim RWall(1 To 6)  As Long
Dim REnergy(1 To 6) As Long
Dim RDamage(1 To 6) As Long
Dim RShield(1 To 6) As Long 'Byte
Dim RSpeedx(1 To 6) As Long
Dim RSpeedy(1 To 6) As Long
Dim RAim(1 To 6) As Long
Dim RLook(1 To 6) As Long
Dim RScan(1 To 6) As Long
Dim RRadar As Long   'Kanske kan byggas ihop? Bytas ut?
Dim RRange As Long

'Robot Specific Game Vars
Dim RobotAlive(1 To 6) As Long 'Boolean
Dim RStunned(1 To 6) As Long     'The number of chronons the robot is stunned
                                    'Hasmoved skall ha 2 funktioner. Dels MoveAndShot, dels så att LEFT' RIGHT' TOP' BOT'
                                    'skall kunna triggas med movex
Dim LastHiter(1 To 6) As Long
Dim HasMoved As Long
Dim DroneShotDown As Boolean    'This var decides wether we have to check through every shot when a x-bullet or a tacnuke explode.
'If there's robots using drones, we have to. If there's no robots using drones, we can skip this a benifit speed.

'Vars neccesary for running the game
'Dim NextEvents As Long     'For the Nextevents optimization
Dim RNN As Long              'Stands for Robot ruNniNg or something like that (I don't remember exactly what to be honest). Correspond aproximately to the variable "who" in Mac RoboWar
Dim ChrononExecutor1 As Long 'Correspons to "cycleNum"
Dim HowManyLeft As Long      'Used to determine when to cancel battle. Set to 2 if only one robot is present, to avoid that battle breaks at Chronon 20
Dim tempnumber As Long    'temporary placeholder for longs
Dim TDouble As Double      'To avoid trig calculations to get truncated

'Shot vars
Dim FreeShot As Long
FreeShot = -1
Dim shotcounter As Long  'Kan användas i debuggern istället för RRadar?
Dim NotAnyShotsAtAll As Boolean
Dim shot(32768) As ShotPrivateType
Dim ShotNumber As Long

Dim trigx As Single
Dim trigy As Single

InizBattle
        'Battle Starts. The robots get randomly placed in the Arena

'Robot 1. Allways Present
        REnergy(1) = Robot1Energy
        RDamage(1) = Robot1Damage
        
'Laddar machinkoden till Robotarna
        For RNN = 0 To 4999
            MachineCode(1, RNN) = MasterCode(1, RNN)
            If (MachineCode(1, RNN) >= insICON0 And MachineCode(1, RNN) <= insICON9) Or (MachineCode(1, RNN) >= insDEBUG And MachineCode(1, RNN) <= insSND9) Then MachineCode(1, RNN) = insBEEP
            If MachineCode(1, RNN) = insEND Then Exit For
        Next RNN

        If R2Present Then
            For RNN = 0 To 4999
                MachineCode(2, RNN) = MasterCode(2, RNN)
                If (MachineCode(2, RNN) >= insICON0 And MachineCode(2, RNN) <= insICON9) Or (MachineCode(2, RNN) >= insDEBUG And MachineCode(2, RNN) <= insSND9) Then MachineCode(2, RNN) = insBEEP
                If MachineCode(2, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace2        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(2) = Robot2Energy
            RDamage(2) = Robot2Damage
        End If

        If R3Present Then
            For RNN = 0 To 4999
                MachineCode(3, RNN) = MasterCode(3, RNN)
                If (MachineCode(3, RNN) >= insICON0 And MachineCode(3, RNN) <= insICON9) Or (MachineCode(3, RNN) >= insDEBUG And MachineCode(3, RNN) <= insSND9) Then MachineCode(3, RNN) = insBEEP
                If MachineCode(3, RNN) = insEND Then Exit For
            Next RNN
            
            MasterPlace3
            REnergy(3) = Robot3Energy
            RDamage(3) = Robot3Damage
        End If

        If R4Present Then
            For RNN = 0 To 4999
                MachineCode(4, RNN) = MasterCode(4, RNN)
                If (MachineCode(4, RNN) >= insICON0 And MachineCode(4, RNN) <= insICON9) Or (MachineCode(4, RNN) >= insDEBUG And MachineCode(4, RNN) <= insSND9) Then MachineCode(4, RNN) = insBEEP
                If MachineCode(4, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace4        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(4) = Robot4Energy
            RDamage(4) = Robot4Damage
        End If

        If R5Present Then
            For RNN = 0 To 4999
                MachineCode(5, RNN) = MasterCode(5, RNN)
                If (MachineCode(5, RNN) >= insICON0 And MachineCode(5, RNN) <= insICON9) Or (MachineCode(5, RNN) >= insDEBUG And MachineCode(5, RNN) <= insSND9) Then MachineCode(5, RNN) = insBEEP
                If MachineCode(5, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace5        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(5) = Robot5Energy
            RDamage(5) = Robot5Damage
        End If

        If R6Present Then
            For RNN = 0 To 4999
                MachineCode(6, RNN) = MasterCode(6, RNN)
                If (MachineCode(6, RNN) >= insICON0 And MachineCode(6, RNN) <= insICON9) Or (MachineCode(6, RNN) >= insDEBUG And MachineCode(6, RNN) <= insSND9) Then MachineCode(6, RNN) = insBEEP
                If MachineCode(6, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace6        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(6) = Robot6Energy
            RDamage(6) = Robot6Damage
        End If
        
HowManyLeft = CheckHowManyLeft

'Syncs Hardware to array
RobotShield(1) = Robot1Shield
RobotEnergy(1) = Robot1Energy
RobotProSpeed(1) = Robot1ProSpeed
RobotMissiles(1) = Robot1Missiles
RobotTacNukes(1) = Robot1TacNukes
RobotBullets(1) = Robot1Bullets
RobotStunners(1) = Robot1Stunners
RobotHellbores(1) = Robot1Hellbores
RobotMines(1) = Robot1Mines
RobotLasers(1) = Robot1Lasers
RobotDrones(1) = Robot1Drones
RobotProbes(1) = Robot1Probes
RobotShield(2) = Robot2Shield
RobotEnergy(2) = Robot2Energy
RobotProSpeed(2) = Robot2ProSpeed
RobotMissiles(2) = Robot2Missiles
RobotTacNukes(2) = Robot2TacNukes
RobotBullets(2) = Robot2Bullets
RobotStunners(2) = Robot2Stunners
RobotHellbores(2) = Robot2Hellbores
RobotMines(2) = Robot2Mines
RobotLasers(2) = Robot2Lasers
RobotDrones(2) = Robot2Drones
RobotProbes(2) = Robot2Probes
RobotShield(3) = Robot3Shield
RobotEnergy(3) = Robot3Energy
RobotProSpeed(3) = Robot3ProSpeed
RobotMissiles(3) = Robot3Missiles
RobotTacNukes(3) = Robot3TacNukes
RobotBullets(3) = Robot3Bullets
RobotStunners(3) = Robot3Stunners
RobotHellbores(3) = Robot3Hellbores
RobotMines(3) = Robot3Mines
RobotLasers(3) = Robot3Lasers
RobotDrones(3) = Robot3Drones
RobotProbes(3) = Robot3Probes
RobotShield(4) = Robot4Shield
RobotEnergy(4) = Robot4Energy
RobotProSpeed(4) = Robot4ProSpeed
RobotMissiles(4) = Robot4Missiles
RobotTacNukes(4) = Robot4TacNukes
RobotBullets(4) = Robot4Bullets
RobotStunners(4) = Robot4Stunners
RobotHellbores(4) = Robot4Hellbores
RobotMines(4) = Robot4Mines
RobotLasers(4) = Robot4Lasers
RobotDrones(4) = Robot4Drones
RobotProbes(4) = Robot4Probes
RobotShield(5) = Robot5Shield
RobotEnergy(5) = Robot5Energy
RobotProSpeed(5) = Robot5ProSpeed
RobotMissiles(5) = Robot5Missiles
RobotTacNukes(5) = Robot5TacNukes
RobotBullets(5) = Robot5Bullets
RobotStunners(5) = Robot5Stunners
RobotHellbores(5) = Robot5Hellbores
RobotMines(5) = Robot5Mines
RobotLasers(5) = Robot5Lasers
RobotDrones(5) = Robot5Drones
RobotProbes(5) = Robot5Probes
RobotShield(6) = Robot6Shield
RobotEnergy(6) = Robot6Energy
RobotProSpeed(6) = Robot6ProSpeed
RobotMissiles(6) = Robot6Missiles
RobotTacNukes(6) = Robot6TacNukes
RobotBullets(6) = Robot6Bullets
RobotStunners(6) = Robot6Stunners
RobotHellbores(6) = Robot6Hellbores
RobotMines(6) = Robot6Mines
RobotLasers(6) = Robot6Lasers
RobotDrones(6) = Robot6Drones
RobotProbes(6) = Robot6Probes
'End Syncs Hardware to array

For tempnumber = 1 To NumberOfRobotsPresent
    RobotInstPos(tempnumber) = -1 'Sets robot RobotInstPos to -1 'cause t have to start with 0 (= -1 + 1 )
    RAim(tempnumber) = 90
    RobotAlive(tempnumber) = 1
    LastHiter(tempnumber) = tempnumber

    RChannel(tempnumber) = 1
    TeammatesInst(tempnumber) = -1
    TeammatesParam(tempnumber) = 5
    SignalInst(tempnumber) = -1

    RadarInst(tempnumber) = -1
    RangeInst(tempnumber) = -1
    ChrononInst(tempnumber) = -1
    CollisionInst(tempnumber) = -1
    WallInst(tempnumber) = -1
    TopInst(tempnumber) = -1
    BotInst(tempnumber) = -1
    LeftInst(tempnumber) = -1
    RightInst(tempnumber) = -1
    RobotsInst(tempnumber) = -1
    DamageInst(tempnumber) = -1
    ShieldInst(tempnumber) = -1
    RobotsParam(tempnumber) = 6
    RadarParam(tempnumber) = 600
    RangeParam(tempnumber) = 600
    TopParam(tempnumber) = 20
    BotParam(tempnumber) = 280
    LeftParam(tempnumber) = 20
    RightParam(tempnumber) = 280
    DamageParam(tempnumber) = RDamage(tempnumber)
    ShieldParam(tempnumber) = 25
    SignalParam(tempnumber) = 1
    
    HistoryParam(tempnumber) = 1

    If RobotDrones(tempnumber) = 1 Then DroneShotDown = True
Next tempnumber

' Avläsningen av koden (BÖRJAN)
'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*

On Error GoTo CodeError1

Dim StartTime As Single
StartTime = Timer

Do While Chronon <> MaxChronon  '<>
    If RobotAlive(1) = 1 Then
        If RStunned(1) = 0 Then
            If RShield(1) > 0 Then
               If RobotShield(1) < RShield(1) Then
                   RShield(1) = RShield(1) - 2
                   If RShield(1) < 0 Then RShield(1) = 0       'Behövs
               Else
                   If Chronon Mod 2 = 0 Then RShield(1) = RShield(1) - 1
               End If
            End If

            If REnergy(1) <> RobotEnergy(1) Then
                If REnergy(1) >= -200 Then
                    REnergy(1) = REnergy(1) + 2
                    If REnergy(1) > RobotEnergy(1) Then REnergy(1) = RobotEnergy(1)
                Else
                    If EnableOverloading Then RobotAlive(1) = 255 Else REnergy(1) = REnergy(1) + 2
                End If
            End If
    
            If REnergy(1) >= 1 Then
                If RSpeedx(1) <> 0 Or RSpeedy(1) <> 0 Then 'Boosts battlespeed and reduces flickering for robots that stads still.
                    RobotLeft(1) = RobotLeft(1) + RSpeedx(1)
                    RobotTop(1) = RobotTop(1) + RSpeedy(1)
                End If
            End If
        End If 'RStunned

        '''Kollision med varandra, Skall Nu vara nästintill perfekt
        For tempnumber = 2 To NumberOfRobotsPresent
                If RobotAlive(tempnumber) = 1 Then
                    If (RobotLeft(1) - RobotLeft(tempnumber)) * (RobotLeft(1) - RobotLeft(tempnumber)) + (RobotTop(1) - RobotTop(tempnumber)) * (RobotTop(1) - RobotTop(tempnumber)) <= 400 Then
                        If RCollision(1) = 0 Then
                            RCollision(1) = tempnumber   '' Var 1 förut nu registrerar den vilken robot den kolliderar med
                            If RShield(1) > 0 Then RShield(1) = RShield(1) - 1 Else RDamage(1) = RDamage(1) - 1     'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
                       
                            If RStunned(1) = 0 And REnergy(1) >= 1 Then
                                RobotLeft(1) = RobotLeft(1) - RSpeedx(1)
                                RobotTop(1) = RobotTop(1) - RSpeedy(1)
                            End If
                        End If
        
                        If RCollision(tempnumber) = 0 Then
                            RCollision(tempnumber) = 1
                            If RShield(tempnumber) > 0 Then RShield(tempnumber) = RShield(tempnumber) - 1 Else RDamage(tempnumber) = RDamage(tempnumber) - 1     'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
        
                            'If RStunned(TempNumber) = 0 And REnergy(TempNumber) >= 1 Then
                            If RStunned(tempnumber) = 0 And REnergy(tempnumber) - 2 * (tempnumber > 1) >= 1 Then
                                RobotLeft(tempnumber) = RobotLeft(tempnumber) - RSpeedx(tempnumber)
                                RobotTop(tempnumber) = RobotTop(tempnumber) - RSpeedy(tempnumber)
                            End If
                        End If
                    End If
                End If
        Next tempnumber

        'KOLLISION MED VÄGGARNA - WALL COLLISION
        If WCX(RobotLeft(1)) Or WCY(RobotTop(1)) Then
            RWall(1) = 1
            RDamage(1) = Min(RDamage(1), (RDamage(1) - 5 + RShield(1)))
            RShield(1) = ZeroOrMore(RShield(1) - 5)

            If RobotLeft(1) > 300 Then  'otherwise it can use SPEEDX to run outside the areana!!!
                RobotLeft(1) = 300      'den har inte flyttats någonstans, vi har istället lagt till på movex
            ElseIf RobotLeft(1) < 0 Then
                RobotLeft(1) = 0
            End If
            If RobotTop(1) > 300 Then
                RobotTop(1) = 300
            ElseIf RobotTop(1) < 0 Then
                RobotTop(1) = 0
            End If
        Else
            RWall(1) = 0
        End If
    End If  'Alive if

'ROBOT LOADING LOOP - The New Collision Stunning Shield Energy Wall Loop
For RNN = 2 To NumberOfRobotsPresent
    If RobotAlive(RNN) = 1 Then
        If RStunned(RNN) = 0 Then
            If RShield(RNN) > 0 Then
               If RobotShield(RNN) < RShield(RNN) Then
                   RShield(RNN) = RShield(RNN) - 2
                   If RShield(RNN) < 0 Then RShield(RNN) = 0       'Behövs
               Else
                   If Chronon Mod 2 = 0 Then RShield(RNN) = RShield(RNN) - 1
               End If
            End If

            If REnergy(RNN) <> RobotEnergy(RNN) Then
                If REnergy(RNN) >= -200 Then
                    REnergy(RNN) = REnergy(RNN) + 2
                    If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN)
                Else
                    If EnableOverloading Then RobotAlive(RNN) = 255 Else REnergy(RNN) = REnergy(RNN) + 2
                End If
            End If
    
            If REnergy(RNN) >= 1 Then
                If RSpeedx(RNN) <> 0 Or RSpeedy(RNN) <> 0 Then 'Boosts battlespeed and reduces flickering for robots that stads still.
                    RobotLeft(RNN) = RobotLeft(RNN) + RSpeedx(RNN)
                    RobotTop(RNN) = RobotTop(RNN) + RSpeedy(RNN)
                End If
            End If
        End If 'RStunned

        '''Kollision med varandra, Skall Nu vara nästintill perfekt
        For tempnumber = 1 To NumberOfRobotsPresent
            If RNN <> tempnumber Then
                If RobotAlive(tempnumber) = 1 Then
                    If (RobotLeft(RNN) - RobotLeft(tempnumber)) * (RobotLeft(RNN) - RobotLeft(tempnumber)) + (RobotTop(RNN) - RobotTop(tempnumber)) * (RobotTop(RNN) - RobotTop(tempnumber)) <= 400 Then
                        If RCollision(RNN) = 0 Then
                            RCollision(RNN) = tempnumber   '' Var 1 förut nu registrerar den vilken robot den kolliderar med
                            If RShield(RNN) > 0 Then RShield(RNN) = RShield(RNN) - 1 Else RDamage(RNN) = RDamage(RNN) - 1     'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
                       
                            If RStunned(RNN) = 0 And REnergy(RNN) >= 1 Then
                                RobotLeft(RNN) = RobotLeft(RNN) - RSpeedx(RNN)
                                RobotTop(RNN) = RobotTop(RNN) - RSpeedy(RNN)
                            End If
                        End If
        
                        If RCollision(tempnumber) = 0 Then
                            RCollision(tempnumber) = RNN
                            If RShield(tempnumber) > 0 Then RShield(tempnumber) = RShield(tempnumber) - 1 Else RDamage(tempnumber) = RDamage(tempnumber) - 1     'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
        
                            'If RStunned(TempNumber) = 0 And REnergy(TempNumber) >= 1 Then
                            If RStunned(tempnumber) = 0 And REnergy(tempnumber) - 2 * (tempnumber > RNN) >= 1 Then
                                RobotLeft(tempnumber) = RobotLeft(tempnumber) - RSpeedx(tempnumber)
                                RobotTop(tempnumber) = RobotTop(tempnumber) - RSpeedy(tempnumber)
                            End If
                        End If
                    End If
                End If
            End If
        Next tempnumber

        'KOLLISION MED VÄGGARNA - WALL COLLISION
        If WCX(RobotLeft(RNN)) Or WCY(RobotTop(RNN)) Then
            RWall(RNN) = 1
            RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - 5 + RShield(RNN)))
            RShield(RNN) = ZeroOrMore(RShield(RNN) - 5)

            If RobotLeft(RNN) > 300 Then  'otherwise it can use SPEEDX to run outside the areana!!!
                RobotLeft(RNN) = 300      'den har inte flyttats någonstans, vi har istället lagt till på movex
            ElseIf RobotLeft(RNN) < 0 Then
                RobotLeft(RNN) = 0
            End If
            If RobotTop(RNN) > 300 Then
                RobotTop(RNN) = 300
            ElseIf RobotTop(RNN) < 0 Then
                RobotTop(RNN) = 0
            End If
        Else
            RWall(RNN) = 0
        End If
    End If  'Alive if
Next RNN

'ROBOT 1 CHRONON EXECUTOR
For RNN = 1 To NumberOfRobotsPresent
If HighestToLowest Then RNN = NumberOfRobotsPresent - RNN + 1   'Turns on backwards evaluation if it's enabled

If RobotAlive(RNN) = 1 Then
    If REnergy(RNN) >= 1 Then
        If RStunned(RNN) = 0 Then
        
            If TopInst(RNN) >= 0 Then
                If RSpeedy(RNN) < 0 Then
                    If RobotTop(RNN) <= TopParam(RNN) Then
                        If RobotTop(RNN) - RSpeedy(RNN) > TopParam(RNN) Then
                            RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                            RobotIntQue(RNN, RobotQuePos(RNN)) = TopInst(RNN)
                            IntID(RNN, RobotQuePos(RNN)) = 1
                        End If
                    End If
                End If
            End If
            If BotInst(RNN) >= 0 Then
                If RSpeedy(RNN) > 0 Then
                    If RobotTop(RNN) >= BotParam(RNN) Then
                        If RobotTop(RNN) - RSpeedy(RNN) < BotParam(RNN) Then
                            RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                            RobotIntQue(RNN, RobotQuePos(RNN)) = BotInst(RNN)
                            IntID(RNN, RobotQuePos(RNN)) = 2
                        End If
                    End If
                End If
            End If
            If LeftInst(RNN) >= 0 Then
                If RSpeedx(RNN) < 0 Then
                    If RobotLeft(RNN) <= LeftParam(RNN) Then
                        If RobotLeft(RNN) - RSpeedx(RNN) > LeftParam(RNN) Then
                            RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                            RobotIntQue(RNN, RobotQuePos(RNN)) = LeftInst(RNN)
                            IntID(RNN, RobotQuePos(RNN)) = 3
                        End If
                    End If
                End If
            End If
            If RightInst(RNN) >= 0 Then
                If RSpeedx(RNN) > 0 Then
                    If RobotLeft(RNN) >= RightParam(RNN) Then
                        If RobotLeft(RNN) - RSpeedx(RNN) < RightParam(RNN) Then
                            RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                            RobotIntQue(RNN, RobotQuePos(RNN)) = RightInst(RNN)
                            IntID(RNN, RobotQuePos(RNN)) = 4
                        End If
                    End If
                End If
            End If

            If ShieldInst(RNN) >= 0 Then            'If it's using the shield int
                If RShield(RNN) < ShieldParam(RNN) Then            'If we're in low shield
                    If ShieldInst(RNN) < 5000 Then    'And we weren't in low shield last chronon (then shieldinst should be > 4999)
                        RobotQuePos(RNN) = RobotQuePos(RNN) + 1                 'que the
                        RobotIntQue(RNN, RobotQuePos(RNN)) = ShieldInst(RNN) 'interupt
                        IntID(RNN, RobotQuePos(RNN)) = 5
                        ShieldInst(RNN) = ShieldInst(RNN) + 5000
                    End If
                Else    'If we're not in low shield anymore
                    If ShieldInst(RNN) > 4999 Then   'and our shieldinst is set to a weird value then
                        ShieldInst(RNN) = ShieldInst(RNN) - 5000  'Sets back shieldinst to it's real value
                    End If
                End If
            End If
            If DamageInst(RNN) >= 0 Then
                If RDamage(RNN) < DamageParam(RNN) Then
                    RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                    RobotIntQue(RNN, RobotQuePos(RNN)) = DamageInst(RNN)
                    IntID(RNN, RobotQuePos(RNN)) = 6
                    DamageParam(RNN) = RDamage(RNN)
                End If
            End If
            If WallInst(RNN) >= 0 Then            'If it's using the wall int
                If RWall(RNN) <> 0 Then            'If we're in wall
                    If WallInst(RNN) < 5000 Then    'And we weren't in wall last chronon (then wallinst should be > 4999)
                        RobotQuePos(RNN) = RobotQuePos(RNN) + 1                 'que the
                        RobotIntQue(RNN, RobotQuePos(RNN)) = WallInst(RNN) 'interupt
                        IntID(RNN, RobotQuePos(RNN)) = 7
                        WallInst(RNN) = WallInst(RNN) + 5000
                    End If
                Else    'If we're not in wall anymore
                    If WallInst(RNN) > 4999 Then   'and our wall inst is set to a weird value then
                        WallInst(RNN) = WallInst(RNN) - 5000  'Sets back wallinst to it's real value
                    End If
                End If                 'COLLISION AND WALL SHOULD BE MUCH MORE CAREFULLY TESTED!!
            End If
            If CollisionInst(RNN) >= 0 Then            'If it's using the collision int
                If RCollision(RNN) <> 0 Then            'If we're in collision
                    If CollisionInst(RNN) < 5000 Then    'And we weren't in collision last chronon (then collisioninst should be > 4999)
                        RobotQuePos(RNN) = RobotQuePos(RNN) + 1                 'que the
                        RobotIntQue(RNN, RobotQuePos(RNN)) = CollisionInst(RNN) 'interupt
                        IntID(RNN, RobotQuePos(RNN)) = 8
                        CollisionInst(RNN) = CollisionInst(RNN) + 5000
                    End If
                Else    'If we're not in collision anymore
                    If CollisionInst(RNN) > 4999 Then   'and our collision inst is set to a weird value then
                        CollisionInst(RNN) = CollisionInst(RNN) - 5000  'Sets back collisioninst to it's real value
                    End If
                End If
            End If

            If RobotQuePos(RNN) > 1 Then        'This is hopefully only a temporary solution for doubletrigging problems
                If RobotIntQue(RNN, RobotQuePos(RNN)) = RobotIntQue(RNN, RobotQuePos(RNN) - 1) And IntID(RNN, RobotQuePos(RNN)) = IntID(RNN, RobotQuePos(RNN) - 1) Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
            End If

            If Inton(RNN) Then
                If RobotQuePos(RNN) > 0 Then
                    If RobotStackPos(RNN) > 99 Then
                        ErrorCode = BuggyOverflow: GoTo Buggy
                    End If
                    RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                    RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
                    RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1    'qued ints subtracted when triggered             'jumps shall be done
                    Inton(RNN) = False
                    RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                    GoTo SkipTheRestOfTheInts
                ElseIf RadarInst(RNN) >= 0 Then
                    'RADAR
                    RRadar = 0
                    For shotcounter = 1 To ShotNumber
                        If shot(shotcounter).ShotType < 200 Then
                            'This is David Harris radar code, ported to Visual Basic by me.
                            trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                            trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                            
                            If trigx <> 0 Then   'atan2
                                tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                            Else
                                tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                            End If          '''''''
                            
                            If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                            
                            If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                                RRange = FixSquare(trigx * trigx + trigy * trigy)
                                If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                            End If
                        End If
                    Next shotcounter
                    '/RADAR
                    If RRadar <> 0 Then
                        If RRadar <= RadarParam(RNN) Then   'intrange sends back 601 for no range instead of 0
                            If RobotStackPos(RNN) > 99 Then
                                ErrorCode = BuggyOverflow: GoTo Buggy
                            End If
                            RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
                            RobotInstPos(RNN) = RadarInst(RNN) - 1 ' -1 är nytt
                            Inton(RNN) = False
                            GoTo SkipTheRestOfTheInts
                        End If
                    End If
                End If
                If RangeInst(RNN) >= 0 Then
                'specialrange.. designed for 1 time per chronon checking
                    RRadar = RAim(RNN) + RLook(RNN)
                    If 1 <> RNN Then   'Skip checking range to self. It'll be too short
                        tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
                        trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
                        trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
            
                        If trigx * trigx + trigy * trigy <= 91 Then
                            If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                If RobotAlive(1) = 1 Then
                                    If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
                                        If RobotStackPos(RNN) > 99 Then
                                            ErrorCode = BuggyOverflow: GoTo Buggy
                                        End If
                                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                                        RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
                                        RobotInstPos(RNN) = RangeInst(RNN) - 1 ' -1 är nytt
                                        Inton(RNN) = False
                                        GoTo SkipTheRestOfTheInts
                                    End If
                                End If
                            End If
                        End If
                    End If
                    
                    For shotcounter = 2 To NumberOfRobotsPresent
                        If shotcounter <> RNN Then   'Skip checking range to self. It'll be too short
                            tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
                            trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
                            trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
                
                            If trigx * trigx + trigy * trigy <= 91 Then
                                If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                    If RobotAlive(shotcounter) = 1 Then
                                        If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
                                            If RobotStackPos(RNN) > 99 Then
                                                ErrorCode = BuggyOverflow: GoTo Buggy
                                            End If
                                            RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
                                            RobotInstPos(RNN) = RangeInst(RNN) - 1 ' -1 är nytt
                                            Inton(RNN) = False
                                            GoTo SkipTheRestOfTheInts
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next shotcounter
                '''''''''''
                End If
                If ChrononInst(RNN) >= 0 Then
                    If ChrononParam(RNN) <= Chronon Then
                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
                        RobotInstPos(RNN) = ChrononInst(RNN) - 1
                        Inton(RNN) = False
                    End If
                End If
            End If

SkipTheRestOfTheInts:

        'Typ här skall hasmoved bli falskt
        HasMoved = 0
        
        '''Slut INTERUPPSKODEN
        For ChrononExecutor1 = 1 To RobotProSpeed(RNN)
            RobotInstPos(RNN) = RobotInstPos(RNN) + 1

'It my tests shows, that in the following Select Case coditional, best speed results are gained when the most
'common instructions are placed first.

                Select Case MachineCode(RNN, RobotInstPos(RNN))  'MachineCode
                    Case -19999 To 19999
                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
                    Case insA To TOPREGISTER
                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
                    Case insSTORE
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                    
                        Select Case RobotStack(RNN, RobotStackPos(RNN))
                            Case insAIM 'ins
                                RAim(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Mod 360
                                If RAim(RNN) < 0 Or RAim(RNN) > 359 Then RAim(RNN) = RAim(RNN) Mod 360 - 360 * (RAim(RNN) < 0)

                                If Inton(RNN) Then  '**********Interuppskod************'
                                    If RadarInst(RNN) >= 0 Then
                                        'RADAR
                                        RRadar = 0
                                        For shotcounter = 1 To ShotNumber
                                            If shot(shotcounter).ShotType < 200 Then
                                                'This is David Harris radar code, ported to Visual Basic by me.
                                                trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                                                trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                                                
                                                If trigx <> 0 Then   'atan2
                                                    tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                                                Else
                                                    tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                                                End If          '''''''
                                                
                                                If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                                                
                                                If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                                                    RRange = FixSquare(trigx * trigx + trigy * trigy)
                                                    If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                                                End If
                                            End If
                                        Next shotcounter
                                        '/RADAR
                                        If RRadar <> 0 Then
                                            If RRadar <= RadarParam(RNN) Then   'intrange sends back 601 for no range instead of 0
                                                RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                RobotInstPos(RNN) = RadarInst(RNN) - 1
                                                Inton(RNN) = False
                                                GoTo NoStackRemoval
                                            End If
                                        End If
                                    End If
                                    If RangeInst(RNN) >= 0 Then
                                    'specialrange.. designed för look and aim instructions
                                        RRadar = RAim(RNN) + RLook(RNN)
                                        If 1 <> RNN Then   'Skip checking range to self. It'll be too short
                                            tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
                                            trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
                                            trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
                                
                                            If trigx * trigx + trigy * trigy <= 91 Then
                                                If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                                    If RobotAlive(1) = 1 Then
                                                        If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
                                                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                            RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
                                                            Inton(RNN) = False
                                                            GoTo NoStackRemoval
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                        
                                        For shotcounter = 2 To NumberOfRobotsPresent
                                            If shotcounter <> RNN Then   'Skip checking range to self. It'll be too short
                                                tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
                                                trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
                                                trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
                                    
                                                If trigx * trigx + trigy * trigy <= 91 Then
                                                    If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                                        If RobotAlive(shotcounter) = 1 Then
                                                            If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
                                                                RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                                RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                                RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
                                                                Inton(RNN) = False
                                                                GoTo NoStackRemoval
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Next shotcounter
                                    '''''''''''
                                    End If
                                End If '**********Slut Interuppskod************'
                            Case insSPEEDX 'ins
                                If Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RSpeedx(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
                                RSpeedx(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSPEEDY 'ins
                                If Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RSpeedy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
                                RSpeedy(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insMISSILE 'ins
                                If RobotMissiles(RNN) = 0 Then
                                    ErrorCode = BuggyMissiles
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
                                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotAngle = RAim(RNN)
                                                shot(ShotNumber).ShotType = Missile
                                                shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotAngle = RAim(RNN)
                                                shot(FreeShot).ShotType = Missile
                                                shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insFIRE 'ins
Robot1Fire:
                                If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                    REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    If HasMoved <> 5 Or MoveAndShotAllowed Then
                                        If FreeShot = -1 Then
                                            ShotNumber = ShotNumber + 1
                                            shot(ShotNumber).ShotAngle = RAim(RNN)
                                            shot(ShotNumber).ShotType = Bullet
                                            shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                            shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                            shot(ShotNumber).Shooter = RNN
                                            Select Case RobotBullets(RNN)
                                                Case 0
                                                    shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2  '/
                                                Case 2
                                                    shot(ShotNumber).ShotType = ExplosiveBullet
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case 20
                                                    RobotBullets(RNN) = 2
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case Else
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            End Select
                                        Else
                                            shot(FreeShot).ShotAngle = RAim(RNN)
                                            shot(FreeShot).ShotType = Bullet
                                            shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                            shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                            shot(FreeShot).Shooter = RNN
                                            Select Case RobotBullets(RNN)
                                                Case 0
                                                    shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2    '
                                                Case 2
                                                    shot(FreeShot).ShotType = ExplosiveBullet
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case 20
                                                    RobotBullets(RNN) = 2
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case Else
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            End Select
                                            FreeShot = -1
                                        End If
                                        HasMoved = 20
                                    Else
                                        ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                    End If
                                End If
                            Case insSHIELD 'ins
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then         'Prevent negative shield
                                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > 150 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 150 'Prevent shield over 150
                                        REnergy(RNN) = REnergy(RNN) + RShield(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Takes or energy restores energy to/from shield
                                        If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN)         'Prevent energy higher than Robots Energy Max
                                        RShield(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)                  'Sets shield
                                    End If
                            Case insSTUNNER 'ins
                                If RobotStunners(RNN) = 0 Then
                                    ErrorCode = BuggyStunners
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
                                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then      'Stunner don't use freeshots because of the (Stunstreamer - Freeshot) visual bug which is fixed so they do
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotAngle = RAim(RNN)
                                                shot(ShotNumber).ShotType = Stunner
                                                shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4     'Int((RobotStack(RNN, RobotStackPos(RNN) - 1)) / 4)
                                            Else
                                                shot(FreeShot).ShotAngle = RAim(RNN)
                                                shot(FreeShot).ShotType = Stunner
                                                shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insMOVEX 'ins
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                If HasMoved <> 20 Or MoveAndShotAllowed Then
                                    RobotLeft(RNN) = RobotLeft(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    'TurretX2(RNN) = TurretX2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    If RobotLeft(RNN) > 300 Then  'otherwise it can use MOVEX to jump outside the areana!!!
                                        RobotLeft(RNN) = 300
                                        'TurretX2(RNN) = 300 + TurretX2(RNN) - RobotLeft(RNN)
                                    ElseIf RobotLeft(RNN) < 0 Then
                                        RobotLeft(RNN) = 0
                                        'TurretX2(RNN) = TurretX2(RNN) - RobotLeft(RNN)
                                    End If
                                    HasMoved = 5
                                Else
                                    ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                End If
                            Case insMOVEY 'ins
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                If HasMoved <> 20 Or MoveAndShotAllowed Then
                                    RobotTop(RNN) = RobotTop(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    'TurretY2(RNN) = TurretY2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    If RobotTop(RNN) > 300 Then 'otherwise it can use MOVEX to jump outside the areana!!!
                                        RobotTop(RNN) = 300
                                        'TurretY2(RNN) = 300 + TurretY2(RNN) - RobotTop(RNN)
                                    ElseIf RobotTop(RNN) < 0 Then
                                        RobotTop(RNN) = 0
                                        'TurretY2(RNN) = TurretY2(RNN) - RobotTop(RNN)
                                    End If
                                    HasMoved = 5
                                Else
                                    ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                End If
                            Case insHELLBORE 'ins
                                If RobotHellbores(RNN) = 0 Then
                                    ErrorCode = BuggyHellbores
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 3 And RobotStack(RNN, RobotStackPos(RNN) - 1) < 21 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotAngle = RAim(RNN)
                                                shot(ShotNumber).ShotType = Hellbore
                                                shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            Else
                                                shot(FreeShot).ShotAngle = RAim(RNN)
                                                shot(FreeShot).ShotType = Hellbore
                                                shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insA: RA(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insB: RB(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insC: RC(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insD: RD(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insE: RE(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insF: RF(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insG: RG(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insH: RH(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insI: RI(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insJ: RJ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insK: RK(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insL: RL(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insM: RM(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insN: RN(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insO: RO(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insP: RP(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insQ: RQ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insR: RR(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insS: RS(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case Inst: RT(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insU: RU(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insV: RV(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insZ: RZ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insW: RW(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insLOOK 'ins
                                RLook(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RLook(RNN) > 359 Then RLook(RNN) = RLook(RNN) Mod 360
                                If RLook(RNN) < 0 Then RLook(RNN) = RLook(RNN) Mod 360 + 360
                                If Inton(RNN) And RangeInst(RNN) >= 0 Then '**********Interuppskod************
                                'specialrange.. designed för look and aim instructions
                                    RRadar = RAim(RNN) + RLook(RNN)
                                    If 1 <> RNN Then   'Skip checking range to self. It'll be too short
                                        tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
                                        trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
                                        trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
                            
                                        If trigx * trigx + trigy * trigy <= 91 Then
                                            If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                                If RobotAlive(1) = 1 Then
                                                    If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
                                                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                        RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                        RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
                                                        Inton(RNN) = False
                                                        GoTo NoStackRemoval
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                    
                                    For shotcounter = 2 To NumberOfRobotsPresent
                                        If shotcounter <> RNN Then   'Skip checking range to self. It'll be too short
                                            tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
                                            trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
                                            trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
                                
                                            If trigx * trigx + trigy * trigy <= 91 Then
                                                If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                                    If RobotAlive(shotcounter) = 1 Then
                                                        If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
                                                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                            RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
                                                            Inton(RNN) = False
                                                            GoTo NoStackRemoval
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next shotcounter
                                '''''''''''
                                End If '**********Slut Interuppskod************'
                            Case insBULLET 'ins                                 'It seems like a robot can mess up it's explosive
                                If RobotBullets(RNN) = 2 Then RobotBullets(RNN) = 20      'bullets by firing negative shots. It's certainly
                                GoTo Robot1Fire                                 'not an adventage, so it' can't be considered cheating
                            Case insNUKE 'ins
                                If RobotTacNukes(RNN) = 0 Then
                                    ErrorCode = BuggyTacNukes
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotFireTime = Chronon
                                                shot(ShotNumber).ShotType = TakeNuke
                                                shot(ShotNumber).ShotX = RobotLeft(RNN)
                                                shot(ShotNumber).ShotY = RobotTop(RNN)
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotFireTime = Chronon
                                                shot(FreeShot).ShotType = TakeNuke
                                                shot(FreeShot).ShotX = RobotLeft(RNN)
                                                shot(FreeShot).ShotY = RobotTop(RNN)
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insMEGANUKE 'ins
                                If RobotTacNukes(RNN) = 0 Then
                                    ErrorCode = BuggyTacNukes
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotFireTime = Chronon
                                                shot(ShotNumber).ShotType = MegaNuke
                                                shot(ShotNumber).ShotX = RobotLeft(RNN)
                                                shot(ShotNumber).ShotY = RobotTop(RNN)
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotFireTime = Chronon
                                                shot(FreeShot).ShotType = MegaNuke
                                                shot(FreeShot).ShotX = RobotLeft(RNN)
                                                shot(FreeShot).ShotY = RobotTop(RNN)
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insMINE 'ins
                                If RobotMines(RNN) = 0 Then
                                    ErrorCode = BuggyMines
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) - 5 > 0 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotFireTime = Chronon
                                                shot(ShotNumber).ShotType = Mine
                                                shot(ShotNumber).ShotX = RobotLeft(RNN)
                                                shot(ShotNumber).ShotY = RobotTop(RNN)
                                                shot(ShotNumber).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotFireTime = Chronon
                                                shot(FreeShot).ShotType = Mine
                                                shot(FreeShot).ShotX = RobotLeft(RNN)
                                                shot(FreeShot).ShotY = RobotTop(RNN)
                                                shot(FreeShot).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insLASER 'ins
                                If RobotLasers(RNN) = 0 Then
                                    ErrorCode = BuggyLasers
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then ' It is possible in the Mac version to shoot laser shots that actually doesn't do any harm
                                        If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then  'It seems to be possible to shoot laser at dead robots
                                            'If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                            If RobotAlive(RangedRobot(RNN)) = 1 Then
                                                If RobotStack(RNN, RobotStackPos(RNN) - 1) > REnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = REnergy(RNN)
                                                
                                                REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                If HasMoved <> 5 Or MoveAndShotAllowed Then
                                                    TurretX2(RNN) = RobotLeft(RNN) + Sin10(RAim(RNN))  'Sets the turret x2 for the aim
                                                    TurretY2(RNN) = RobotTop(RNN) - Cos10(RAim(RNN))   'since it's used in non-displayed for laser

                                                    If FreeShot = -1 Then
                                                        ShotNumber = ShotNumber + 1
                                                        shot(ShotNumber).ShotType = Laser
                                                        shot(ShotNumber).ShotAngle = RangedRobot(RNN)
                                                        shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
                                                        shot(ShotNumber).Shooter = RNN
                                                        shot(ShotNumber).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN)    'Shows laser on radar instantly
                                                        shot(ShotNumber).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
                                                    Else
                                                        shot(FreeShot).ShotType = Laser
                                                        shot(FreeShot).ShotAngle = RangedRobot(RNN)
                                                        shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
                                                        shot(FreeShot).Shooter = RNN
                                                        shot(FreeShot).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN)    'Shows laser on radar instantly
                                                        shot(FreeShot).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
                                                        FreeShot = -1
                                                    End If
                                                    HasMoved = 20
                                                Else
                                                    ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Case insDRONE 'ins
                                If RobotDrones(RNN) = 0 Then
                                    ErrorCode = BuggyDrones
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 And Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then    'Range <> 0
                                        If RobotAlive(RangedRobot(RNN)) = 1 Then  'Cuts down the shot power to the Robots energy max
                                            If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                            REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            If HasMoved <> 5 Or MoveAndShotAllowed Then
                                                If FreeShot = -1 Then
                                                    ShotNumber = ShotNumber + 1
                                                    shot(ShotNumber).ShotAngle = RangedRobot(RNN)   'Shootangle represents tracking robot
                                                    shot(ShotNumber).ShotFireTime = Chronon + 100   'ShotFireTime represents the chronon the drone die
                                                    shot(ShotNumber).ShotType = Drone
                                                    shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                    shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
                                                    shot(ShotNumber).Shooter = RNN
                                                Else
                                                    shot(FreeShot).ShotAngle = RangedRobot(RNN)   'Shootangle represents tracking robot
                                                    shot(FreeShot).ShotFireTime = Chronon + 100   'ShotFireTime represents the chronon the drone die
                                                    shot(FreeShot).ShotType = Drone
                                                    shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                    shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
                                                    shot(FreeShot).Shooter = RNN
                                                    FreeShot = -1
                                                End If
                                                HasMoved = 20
                                            Else
                                                ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                            End If
                                        End If
                                    End If
                                End If
                            Case insSCAN 'ins
                                RScan(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RScan(RNN) > 359 Then RScan(RNN) = RScan(RNN) Mod 360
                                If RScan(RNN) < 0 Then RScan(RNN) = RScan(RNN) Mod 360 + 360
                                If Inton(RNN) And RadarInst(RNN) >= 0 Then
                                    'RADAR
                                    RRadar = 0
                                    For shotcounter = 1 To ShotNumber
                                        If shot(shotcounter).ShotType < 200 Then
                                            'This is David Harris radar code, ported to Visual Basic by me.
                                            trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                                            trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                                            
                                            If trigx <> 0 Then   'atan2
                                                tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                                            Else
                                                tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                                            End If          '''''''
                                            
                                            If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                                            
                                            If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                                                RRange = FixSquare(trigx * trigx + trigy * trigy)
                                                If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                                            End If
                                        End If
                                    Next shotcounter
                                    '/RADAR
                                    If RRadar <> 0 Then
                                        If RRadar <= RadarParam(RNN) Then
                                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                            RobotInstPos(RNN) = RadarInst(RNN) - 1 ' - 1 nytt
                                            Inton(RNN) = False
                                            GoTo NoStackRemoval
                                        End If
                                    End If
                                End If
                            Case insHISTORY 'ins
                                If HistoryParam(RNN) >= 31 Then HistoryRec(RNN, HistoryParam(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSIGNAL
                                If RobotTeam(RNN) <> 0 Then
                                    RSignal(RobotTeam(RNN), RChannel(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
   
                                    For tempnumber = 1 To NumberOfRobotsPresent
                                        If RobotTeam(RNN) = RobotTeam(tempnumber) Then
                                            If tempnumber <> RNN Then
                                                If SignalInst(tempnumber) >= 0 Then
                                                    If SignalParam(tempnumber) = RChannel(RNN) Then
                                                        RobotQuePos(tempnumber) = RobotQuePos(tempnumber) + 1
                                                        RobotIntQue(tempnumber, RobotQuePos(tempnumber)) = SignalInst(tempnumber)
                                                        IntID(tempnumber, RobotQuePos(tempnumber)) = 11
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next tempnumber
                                End If
                            Case insCHANNEL
                                RChannel(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RChannel(RNN) > 10 Or RChannel(RNN) < 1 Then
                                    ErrorCode = BuggyChannel: GoTo Buggy
                                End If
                            Case Else
                                ErrorCode = BuggyStore
                                GoTo Buggy
                            End Select
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
NoStackRemoval:
                    Case insRECALL       'Removing the Reversed Recalls took exactly 3 hours and 29 minutes, including speed testing but
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyRecall: GoTo Buggy
                        End If
                        
                        Select Case RobotStack(RNN, RobotStackPos(RNN))     'excluding recompiling all robots
                            Case insRANGE 'ins
                                RRange = Range(RNN, RAim(RNN) + RLook(RNN))
                                If RRange <> 0 Then
                                    If RobotAlive(RangedRobot(RNN)) <> 1 Then RRange = 0
                                End If
                                RobotStack(RNN, RobotStackPos(RNN)) = RRange
                            Case insAIM 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RAim(RNN)
                            Case insX 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RobotLeft(RNN)
                            Case insY 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RobotTop(RNN)
                            Case insRADAR 'ins
                                'RADAR
                                RRadar = 0 'RRadar
                                For shotcounter = 1 To ShotNumber
                                    If shot(shotcounter).ShotType < 200 Then
                                        'This is David Harris radar code, ported to Visual Basic by me.
                                        trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                                        trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                                        
                                        If trigx <> 0 Then   'atan2
                                            tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                                        Else
                                            tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                                        End If          '''''''
                                        
                                        If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                                        
                                        If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                                            RRange = FixSquare(trigx * trigx + trigy * trigy)
                                            If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                                        End If
                                    End If
                                Next shotcounter
                                '/RADAR
                                RobotStack(RNN, RobotStackPos(RNN)) = RRadar
                            Case insSPEEDX 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RSpeedx(RNN)
                            Case insSPEEDY 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RSpeedy(RNN)
                            Case insENERGY 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RNN)
                            Case insSHIELD 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RShield(RNN)
                            Case insLOOK 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RLook(RNN)
                            Case insDOPPLER 'ins
                                'Many Thanks to Sam Rushing who helped me out
                                'and explained how the Doppler routine worked.    'Dead robot are set to E = -10
                                
                                'Prfnoff's version - Robots with E -1 has doppler?
                                '4.5.2 - Robots med E -1 doesn't have doppler

                                If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'Med allra allra största sannolikhet skall jag använda RealStunned
                                    If REnergy(RangedRobot(RNN)) <= 0 Or RStunned(RangedRobot(RNN)) <> 0 Or RCollision(RangedRobot(RNN)) <> 0 Then    'RWall(RangedRobot(RNN)) <> 0 Or
                                        RobotStack(RNN, RobotStackPos(RNN)) = 0
                                    Else
                                        RRange = RobotLeft(RNN) - RobotLeft(RangedRobot(RNN))    'xdiff
                                        RRadar = RobotTop(RNN) - RobotTop(RangedRobot(RNN))      'ydiff
                                        'Ej testat om det skall vara round eller fix, kolla
                                        RobotStack(RNN, RobotStackPos(RNN)) = Round((RSpeedx(RangedRobot(RNN)) * RRadar - RRange * RSpeedy(RangedRobot(RNN))) / Square(RRadar * RRadar + RRange * RRange))  'Round
                                    End If
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                End If
                            Case insNEAREST
                                If RobotProSpeed(RNN) <= 10 Then
                                    If NumberOfRobotsPresent > 1 Then
                                        tempnumber = Nearest(RNN)
                                        If RobotAlive(tempnumber) = 1 Then
                                            If RobotTop(tempnumber) <> RobotTop(RNN) Then
                                                If RobotTop(RNN) > RobotTop(tempnumber) Then
                                                    RobotStack(RNN, RobotStackPos(RNN)) = (Round(TPI * Atn((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN))))) - RAim(RNN)
                                                Else
                                                    RobotStack(RNN, RobotStackPos(RNN)) = (Round(TPI * Atn((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN)))) + 180) - RAim(RNN)
                                                End If
                                            Else
                                                If RobotLeft(RNN) < RobotLeft(tempnumber) Then
                                                    RobotStack(RNN, RobotStackPos(RNN)) = 90 - RAim(RNN)
                                                Else
                                                    RobotStack(RNN, RobotStackPos(RNN)) = 270 - RAim(RNN)
                                                End If
                                            End If
                                            
                                            If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 360
                                        Else
                                            RobotStack(RNN, RobotStackPos(RNN)) = -1
                                        End If
                                    Else
                                        RobotStack(RNN, RobotStackPos(RNN)) = -1
                                    End If
                                Else
                                    ErrorCode = BuggyNearest
                                    GoTo Buggy
                                End If
                            Case insROBOTS 'ins
                                If HowManyLeft = 255 Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = 1
                                ElseIf R2Present Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = HowManyLeft
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 1
                                End If
                            Case insCHRONON 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = Chronon
                            Case insCOLLISION 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = Sgn(RCollision(RNN))
                            Case insA 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RA(RNN)
                            Case insB 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RB(RNN)
                            Case insC 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RC(RNN)
                            Case insD 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RD(RNN)
                            Case insE 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RE(RNN)
                            Case insF 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RF(RNN)
                            Case insG 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RG(RNN)
                            Case insH 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RH(RNN)
                            Case insI 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RI(RNN)
                            Case insJ 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RJ(RNN)
                            Case insK 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RK(RNN)
                            Case insL 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RL(RNN)
                            Case insM 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RM(RNN)
                            Case insN 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RN(RNN)
                            Case insO 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RO(RNN)
                            Case insP 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RP(RNN)
                            Case insQ 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RQ(RNN)
                            Case insR 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RR(RNN)
                            Case insS 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RS(RNN)
                            Case Inst 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RT(RNN)
                            Case insU 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RU(RNN)
                            Case insV 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RV(RNN)
                            Case insZ 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RZ(RNN)
                            Case insW 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RW(RNN)
                            Case insPROBE 'ins
                                If RobotProbes(RNN) = 0 Then
                                    ErrorCode = BuggyProbes
                                    GoTo Buggy
                                Else
                                    If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then
                                        If RobotAlive(RangedRobot(RNN)) <> 1 Then
                                            RobotStack(RNN, RobotStackPos(RNN)) = 0
                                        Else
                                            Select Case ProbeSet(RNN)
                                                '0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
                                                '4 = Teammates - Currently disabled 'cause of no teams
                                                Case 1
                                                    RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RangedRobot(RNN))
                                                Case 0
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RangedRobot(RNN))
                                                Case 2
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RShield(RangedRobot(RNN))
                                                Case 7
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RScan(RangedRobot(RNN))
                                                Case 3
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RangedRobot(RNN) - 1 '0 to 5
                                                Case 5
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RAim(RangedRobot(RNN))
                                                Case 6
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RLook(RangedRobot(RNN))
                                                Case 4
                                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                                    For tempnumber = 1 To NumberOfRobotsPresent
                                                        If tempnumber <> RangedRobot(RNN) Then
                                                            If RobotTeam(tempnumber) = RobotTeam(RangedRobot(RNN)) Then
                                                                If RobotAlive(tempnumber) = 1 Then
                                                                    RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
                                                                End If
                                                            End If
                                                        End If
                                                    Next tempnumber
                                            End Select
                                        End If
                                    Else
                                        RobotStack(RNN, RobotStackPos(RNN)) = 0
                                    End If
                                End If
                            Case insWALL 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RWall(RNN)
                            Case insDAMAGE 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RNN)
                            Case insRANDOM 'ins
                                If RunningTournament Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = Round((359 + 1) * Rnd)  'Int
                                Else
                                    If Replaying And NotRandomEmergency Then
                                        RobotStack(RNN, RobotStackPos(RNN)) = RandomRegister(RandomCounter)
                                    Else
                                        RobotStack(RNN, RobotStackPos(RNN)) = Round((359 + 1) * Rnd)  'Int
                                        ReDim Preserve RandomRegister(RandomCounter)
                                        RandomRegister(RandomCounter) = RobotStack(RNN, RobotStackPos(RNN))
                                    End If
                                    RandomCounter = RandomCounter + 1
                                End If
                            Case insSCAN 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RScan(RNN)
                            Case insID 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RNN - 1 '0 to 5
                            Case insHISTORY 'ins     'If repeat battle is checked we should read from the backup rec, unless we're using user defined history, in case we should read from the regular rec, since regular rec 31-50 is reset at the end of a repeated battle
                                If Replaying And HistoryParam(RNN) < 31 Then RobotStack(RNN, RobotStackPos(RNN)) = BackupHistoryRec(RNN, HistoryParam(RNN)) Else RobotStack(RNN, RobotStackPos(RNN)) = HistoryRec(RNN, HistoryParam(RNN))
                            Case insKILLS 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = KR(RNN)
                           Case insSIGNAL
                                If RobotTeam(RNN) <> 0 Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = RSignal(RobotTeam(RNN), RChannel(RNN))
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                End If
                            Case insFRIEND
                                If RCollision(RNN) <> 0 And RobotTeam(RNN) <> 0 Then
                                    If RobotTeam(RCollision(RNN)) = RobotTeam(RNN) Then RobotStack(RNN, RobotStackPos(RNN)) = 1 Else RobotStack(RNN, RobotStackPos(RNN)) = 0
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                End If
                            Case insCHANNEL
                                RobotStack(RNN, RobotStackPos(RNN)) = RChannel(RNN)
                            Case insTEAMMATES
                                RobotStack(RNN, RobotStackPos(RNN)) = 0
                                For tempnumber = 1 To NumberOfRobotsPresent
                                    If tempnumber <> RNN Then
                                        If RobotTeam(tempnumber) = RobotTeam(RNN) Then
                                            If RobotAlive(tempnumber) = 1 Then
                                                RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
                                            End If
                                        End If
                                    End If
                                Next tempnumber
                            Case Else
                                ErrorCode = BuggyRecall '& RobotStack(RNN, RobotStackPos(RNN))
                                GoTo Buggy
                        End Select
                    Case insIF 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                        Else
                            tempnumber = RobotInstPos(RNN) + 1   'Tempnumber gav ingen hastighetsökning
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        End If
                    Case insMORE
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) >= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insJUMP 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                            RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                        Else
                            ErrorCode = BuggyDestination: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insIFG 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insPLUS
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + RobotStack(RNN, RobotStackPos(RNN) + 1)
                        If Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
                            ErrorCode = BuggyNumberOutofBounds: GoTo Buggy
                        End If
                    Case insLESS
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                    
                        If RobotStack(RNN, RobotStackPos(RNN)) <= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSYNC 'Rep'
                        Exit For
                    Case insDUP 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If

                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                    Case insSETINT 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If

                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > 4999 Or RobotStack(RNN, RobotStackPos(RNN) - 1) < -1 Then
                            ErrorCode = BuggyDestination: GoTo Buggy
                        End If

                        Select Case RobotStack(RNN, RobotStackPos(RNN))
                            Case insRANGE ' 'Rep'
                                RangeInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insLEFT ' 'Rep'
                                LeftInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If LeftInst(RNN) = -1 Then          'BUG ALERT!! Detta klarar bara om första stacknumret är
                                    If RobotQuePos(RNN) <> 0 Then   'hett! Tillfällig lösning
                                        If IntID(RNN, RobotQuePos(RNN)) = 3 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insRIGHT ' 'Rep'
                                RightInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RightInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 4 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insTOP ' 'Rep'
                                TopInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If TopInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 1 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insBOT ' 'Rep'
                                BotInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If BotInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 2 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insWALL ' 'Rep'
                                WallInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If WallInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 7 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insCOLLISION ' 'Rep'
                                CollisionInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If CollisionInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 8 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insROBOTS ' 'Rep'
                                RobotsInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RobotsInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 9 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insCHRONON ' 'Rep'
                                ChrononInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insRADAR ' 'Rep'
                                RadarInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insDAMAGE ' 'Rep'
                                DamageInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If DamageInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 6 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insSHIELD ' 'Rep'
                                ShieldInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If ShieldInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 5 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                Else    'Else är nytt - tidigare stod If Rshieled utanför if
                                    If RShield(RNN) < ShieldParam(RNN) Then ShieldInst(RNN) = ShieldInst(RNN) + 5000
                                End If
                            Case insTEAMMATES ' 'Rep'
                                TeammatesInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If TeammatesInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 10 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insSIGNAL ' 'Rep'
                                SignalInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If SignalInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 11 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case Else
                                ErrorCode = BuggySetint
                                GoTo Buggy
                        End Select
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insRTI 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        Inton(RNN) = True
                        If RobotQuePos(RNN) <= 0 Then
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        Else
                            RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1    'qued ints subtracted when triggered             'jumps shall be done
                            Inton(RNN) = False
                            RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                        End If
                    Case insSETPARAM 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        Select Case RobotStack(RNN, RobotStackPos(RNN))
                            Case insRANGE ' 'Rep'
                                RangeParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insLEFT ' 'Rep'
                                LeftParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insRIGHT ' 'Rep'
                                RightParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insTOP ' 'Rep'
                                TopParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insBOT ' 'Rep'
                                BotParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insPROBE ' 'Rep'
                            '0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
                            '4 = Teammates - Currently disabled 'cause of no teams
                                Select Case RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    Case insDAMAGE ' 'Rep'
                                        ProbeSet(RNN) = 0
                                    Case insENERGY ' 'Rep'
                                        ProbeSet(RNN) = 1
                                    Case insSHIELD ' 'Rep'
                                        ProbeSet(RNN) = 2
                                    Case insSCAN ' 'Rep'
                                        ProbeSet(RNN) = 7
                                    Case insID ' 'Rep'
                                        ProbeSet(RNN) = 3
                                    Case insAIM ' 'Rep'
                                        ProbeSet(RNN) = 5
                                    Case insLOOK ' 'Rep'
                                        ProbeSet(RNN) = 6
                                    Case insTEAMMATES ' 'Rep'
                                        ProbeSet(RNN) = 4
'                                    Case Else
'                                        ErrorCode =  'Rep'Illegal 'PROBE' register  'Rep' & RobotStack(RNN, RobotStackPos(RNN))
'                                        GoTo Buggy
                                End Select
                            Case insRADAR ' 'Rep'
                                RadarParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insCHRONON ' 'Rep'
                                ChrononParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insROBOTS ' 'Rep'
                                RobotsParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insDAMAGE ' 'Rep'
                                DamageParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If DamageParam(RNN) > RDamage(RNN) Then DamageParam(RNN) = RDamage(RNN)
                            Case insHISTORY ' 'Rep'
                                HistoryParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSHIELD ' 'Rep'
                                ShieldParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insTEAMMATES ' 'Rep'
                                TeammatesParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSIGNAL
                                SignalParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case Else
                                ErrorCode = BuggySetparam
                                GoTo Buggy
                            End Select
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insCALL 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        tempnumber = RobotInstPos(RNN) + 1
                        If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                            RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                        Else
                            ErrorCode = BuggyDestination: GoTo Buggy
                        End If
                        RobotStack(RNN, RobotStackPos(RNN)) = tempnumber
                    Case insAND 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 Or RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insMINUS
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) - RobotStack(RNN, RobotStackPos(RNN) + 1)
                        If Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
                            ErrorCode = BuggyNumberOutofBounds: GoTo Buggy
                        End If
                    Case insINTON 'Rep'
                        Inton(RNN) = True
                        If RobotQuePos(RNN) > 0 Then
                            If RobotStackPos(RNN) > 99 Then
                                ErrorCode = BuggyOverflow: GoTo Buggy
                            End If
                            RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
                            RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1    'qued ints subtracted when triggered             'jumps shall be done
                            Inton(RNN) = False
                            RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                        End If
                    Case insDIVISION
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
                            ErrorCode = BuggyDivision: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) \ RobotStack(RNN, RobotStackPos(RNN) + 1)
                    Case insTIMES
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) * RobotStack(RNN, RobotStackPos(RNN) + 1)
                        If Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
                            ErrorCode = BuggyNumberOutofBounds: GoTo Buggy
                        End If
                    Case insSAME
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insBEEP 'Rep' 'Represents all icon snd instructions, debug, print and beep  for undisplayed
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insARCTAN 'Rep'                                       'Shall not use Fix!!
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = Round(TPI * Atn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)) + 90 - (90 * (Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1)) - 1)))
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * Sgn(RobotStack(RNN, RobotStackPos(RNN))) * (Sgn(RobotStack(RNN, RobotStackPos(RNN))) + 1)
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insDROPALL 'Rep'
                        RobotStackPos(RNN) = 0
                    Case insNOT 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
                            RobotStack(RNN, RobotStackPos(RNN)) = 1
                        Else
                            RobotStack(RNN, RobotStackPos(RNN)) = 0     'Nej, dethär går inte att förenkla
                        End If
                    Case insDROP 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSWAP 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        tempnumber = RobotStack(RNN, RobotStackPos(RNN))
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
                    Case insIFEG 'Rep'
                        If RobotStackPos(RNN) < 3 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                        Else
                            If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 3
                    Case insVRECALL 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) < 0 Or RobotStack(RNN, RobotStackPos(RNN)) > 100 Then
                            RobotStack(RNN, RobotStackPos(RNN)) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN)) = RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN)))
                        End If
                    Case insMOD 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN) - 1) Mod RobotStack(RNN, RobotStackPos(RNN))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insOR 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 And RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insIFE 'Rep'
                        If RobotStackPos(RNN) < 3 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
                            tempnumber = RobotInstPos(RNN) + 1
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                        Else
                            tempnumber = RobotInstPos(RNN) + 1       'Samma sak här, det borde funka med tempnumber
                            If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                        End If
                    Case insMAX 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) > RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSIN 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * Sin(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insCOS 'Rep'              'Fix avrundar exact som Mac RoboWar!!
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * Cos(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insINTOFF 'Rep'
                        Inton(RNN) = False
                    Case insVSTORE 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) >= 0 And RobotStack(RNN, RobotStackPos(RNN)) <= 100 Then
                            RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN))) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insCHS 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN)) = -RobotStack(RNN, RobotStackPos(RNN)) '* -1
                    Case insABS 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN)) = Abs(RobotStack(RNN, RobotStackPos(RNN)))
                    Case insTAN '       BUG ALERT!! Hur är det med 90 + de nya optimeringarna?
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        TDouble = Fix(RobotStack(RNN, RobotStackPos(RNN)) * Tan((90 - RobotStack(RNN, RobotStackPos(RNN) - 1)) * PIO))
                        If Abs(TDouble) > 19999 Then TDouble = 19999 * Sgn(TDouble)
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = TDouble
                    Case insNOT_SAME 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insROLL 'Rep'
                        If RobotStackPos(RNN) < RobotStack(RNN, RobotStackPos(RNN)) + 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        tempnumber = RobotStack(RNN, RobotStackPos(RNN) - 1)     'Stores the number to roll back in tempstack
                        For shotcounter = RobotStackPos(RNN) - 1 To RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) Step -1 'decides what stack numbers moving up
                            RobotStack(RNN, shotcounter) = RobotStack(RNN, shotcounter - 1)       'adjust stack numbers affected by roll
                        Next shotcounter
                        RobotStack(RNN, RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) - 1) = tempnumber   'Do the roll
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1 'Adjusts stack number because top operand has been removed
                    Case insMIN 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) < RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insNOP 'Rep'
                    Case insDIST 'Rep'     'Totally useless, it can be precalculated!
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(Sqr(RobotStack(RNN, RobotStackPos(RNN)) ^ 2 + RobotStack(RNN, RobotStackPos(RNN) - 1) ^ 2))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insFLUSHINT 'Rep'
                        RobotQuePos(RNN) = 0
                    Case insXOR 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If (RobotStack(RNN, RobotStackPos(RNN)) <> 0) Xor (RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insARCSIN 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Asn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * Sgn(RobotStack(RNN, RobotStackPos(RNN))) * Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1))
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insARCCOS 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Acn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = -180 * (Sgn(RobotStack(RNN, RobotStackPos(RNN))) <> Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1)))
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSQRT 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then
                            ErrorCode = BuggySquare: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN)) = FixSquare(RobotStack(RNN, RobotStackPos(RNN)))
                    Case insPRINT 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If Not RunningTournament Then
                            tempnumber = MsgBox(RobotStack(RNN, RobotStackPos(RNN)) & vbCr & vbCr & "Would you like to stop the Battle?", vbYesNo + vbDefaultButton2, "Print " & GetRobot(RNN))
                            If tempnumber = vbYes Then GoTo Peace
                        End If
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case Else
CodeError1:
                        ErrorCode = Err
Buggy:
                        If RunningTournament Then
                            tempnumber = vbNo
                        ElseIf ErrorCode <= -200 Then
                            tempnumber = ShowErrorMessageParam(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), RobotStack(RNN, RobotStackPos(RNN)))
                        Else
                            tempnumber = ShowErrorMessage(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), MachineCode(RNN, RobotInstPos(RNN)))                   'Response
                        End If

                        RobotAlive(RNN) = 255
                        RScan(RNN) = 9999  'nytt
                        If tempnumber = vbCancel Then GoTo Peace
                        If tempnumber = vbYes Then
                            SelectedRobot = RNN
                            DraftingBoard.GotoInstNr = RobotInstPos(RNN) + 1
                            DraftingBoard.Show 1, MainWindow
                            EndBattleWhenGotoInst
                            Exit Sub
                        End If
                        If Err = 0 Then Exit For Else Resume BackFromError
                    End Select
            Next ChrononExecutor1
        End If  'Stunned if
    End If      'energyif
End If         'RobotAlive(RNN) if

BackFromError:
If HighestToLowest Then RNN = 1 + NumberOfRobotsPresent - RNN   'Turns off backwards evaluation if it's enabled
Next RNN 'Nästa robot loopen


If RStunned(1) > 0 Then RStunned(1) = RStunned(1) - 1
For RNN = 2 To NumberOfRobotsPresent
    If RStunned(RNN) > 0 Then RStunned(RNN) = RStunned(RNN) - 1
Next RNN

' Avläsningen av koden ALLMÄNT(SLUTET)

'Shot Manager

NotAnyShotsAtAll = True

For shotcounter = 1 To ShotNumber
'errorcode = "ShotCounter = " & ShotCounter & Chr(10) & "ShotNumber = " & ShotNumber & Chr(10) & Chr(10) & "FireTime = " & Shot(ShotCounter).ShotFireTime & Chr(10) & "X = " & Shot(ShotCounter).ShotX & Chr(10) & "Y = " & Shot(ShotCounter).ShotY & Chr(10) & "Damage = " & Shot(ShotCounter).ShotPower & Chr(10) & Chr(10) & "FreeShot = " & FreeShot
'Response = MsgBox(errorcode, vbOKCancel, "Debug")
'If Response = vbCancel Then GoTo Peace

'Fillstyle är som standard = 0. Om det måste ändras måste den sättas tillbaka sen

Select Case shot(shotcounter).ShotType
    Case 200
        FreeShot = shotcounter
    'Disables some redims. Might speed up?

    Case Missile
        NotAnyShotsAtAll = False
        shot(shotcounter).ShotX = shot(shotcounter).ShotX + Sin5(shot(shotcounter).ShotAngle)
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - Cos5(shot(shotcounter).ShotAngle)

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then    'BUG ALERT!!! Skall syncas!!!
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 1     'Which robot is hit?
                LastHiter(1) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 2     'Which robot is hit?
                LastHiter(2) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 3     'Which robot is hit?
                LastHiter(3) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 4     'Which robot is hit?
                LastHiter(4) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 5     'Which robot is hit?
                LastHiter(5) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 6     'Which robot is hit?
                LastHiter(6) = shot(shotcounter).Shooter
            End If
        End If

    Case Hellbore
        NotAnyShotsAtAll = False
        trigx = shot(shotcounter).ShotPower * Sine(shot(shotcounter).ShotAngle)
        trigy = shot(shotcounter).ShotPower * Cosine(shot(shotcounter).ShotAngle)

        shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy

        trigx = shot(shotcounter).ShotX - trigx / 2
        trigy = shot(shotcounter).ShotY + trigy / 2

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then      'HELLBORE!!!
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or _
             (trigx - RobotLeft(1)) * (trigx - RobotLeft(1)) + (trigy - RobotTop(1)) * (trigy - RobotTop(1)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 1000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or _
             (trigx - RobotLeft(2)) * (trigx - RobotLeft(2)) + (trigy - RobotTop(2)) * (trigy - RobotTop(2)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 2000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or _
             (trigx - RobotLeft(3)) * (trigx - RobotLeft(3)) + (trigy - RobotTop(3)) * (trigy - RobotTop(3)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 3000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or _
             (trigx - RobotLeft(4)) * (trigx - RobotLeft(4)) + (trigy - RobotTop(4)) * (trigy - RobotTop(4)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 4000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or _
             (trigx - RobotLeft(5)) * (trigx - RobotLeft(5)) + (trigy - RobotTop(5)) * (trigy - RobotTop(5)) < 100 Then
              shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 5000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or _
             (trigx - RobotLeft(6)) * (trigx - RobotLeft(6)) + (trigy - RobotTop(6)) * (trigy - RobotTop(6)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 6000     'Which robot is hit? *1000 for hellbore
            End If      'HELLBORE!!!
        End If

    Case Stunner
        NotAnyShotsAtAll = False
        trigx = Sin14(shot(shotcounter).ShotAngle)
        trigy = Cos14(shot(shotcounter).ShotAngle)

        shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy

        trigx = shot(shotcounter).ShotX - trigx
        trigy = trigy + shot(shotcounter).ShotY

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then      'STUNNER!!!
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 100     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 200     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 300     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 400     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 500     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 600     'Which robot is hit? *100 for stunners
            End If      'STUNNER!!!
        End If

    Case XplosiveBulletDetonation
ExplosiveBullets:
        NotAnyShotsAtAll = False
        If Chronon - shot(shotcounter).ShotFireTime >= 4 Then '10
            shot(shotcounter).ShotType = NOSHOT

            For RNN = 1 To NumberOfRobotsPresent
                If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 2025 Then     '45*45?????
                    RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN))): RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
                    LastHiter(RNN) = shot(shotcounter).Shooter
                End If
            Next RNN
            
            If DroneShotDown Then
                For RNN = 1 To ShotNumber
                    If shot(RNN).ShotType = Drone Then
                        If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 2025 Then shot(RNN).ShotType = NOSHOT
                    End If
                Next RNN
            End If
        End If
    
    Case TakeNuke
'OldStyleExplosiveBullets:
        NotAnyShotsAtAll = False

        If Chronon - shot(shotcounter).ShotFireTime >= 10 Then '10
            shot(shotcounter).ShotType = NOSHOT

            For RNN = 1 To NumberOfRobotsPresent    '1020
                If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
                    RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN))): RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
                    LastHiter(RNN) = shot(shotcounter).Shooter
                End If
            Next RNN
            
            If DroneShotDown Then
                For RNN = 1 To ShotNumber
                    If shot(RNN).ShotType = Drone Then
                        If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then shot(RNN).ShotType = NOSHOT
                    End If
                Next RNN
            End If
        End If

    Case MegaNuke
'OldStyleExplosiveBullets:
        NotAnyShotsAtAll = False

        If Chronon - shot(shotcounter).ShotFireTime >= MegaNukeBLASTRADIUS Then '10
            shot(shotcounter).ShotType = NOSHOT

            For RNN = 1 To NumberOfRobotsPresent    '1020
                If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
                    RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower + RShield(RNN))): RShield(RNN) = ZeroOrMore(RShield(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower)
                    LastHiter(RNN) = shot(shotcounter).Shooter
                End If
            Next RNN
            
            If DroneShotDown Then
                For RNN = 1 To ShotNumber
                    If shot(RNN).ShotType = Drone Then
                        If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then shot(RNN).ShotType = NOSHOT
                    End If
                Next RNN
            End If
        End If

    Case Mine       'Minor skall ge damage 1 chronon efter
        NotAnyShotsAtAll = False

        If Chronon - shot(shotcounter).ShotFireTime >= 10 Then
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 1     'Which robot is hit?
                LastHiter(1) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 2     'Which robot is hit?
                LastHiter(2) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 3     'Which robot is hit?
                LastHiter(3) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 4     'Which robot is hit?
                LastHiter(4) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 5     'Which robot is hit?
                LastHiter(5) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 6     'Which robot is hit?
                LastHiter(6) = shot(shotcounter).Shooter
            End If
        End If

    Case Drone
        NotAnyShotsAtAll = False

        If RobotAlive(shot(shotcounter).ShotAngle) = 1 And Chronon <= shot(shotcounter).ShotFireTime Then
'Checks drone shotdown
            For tempnumber = 0 To ShotNumber        'This is still extremly buggy
                'If Shot(TempNumber).ShotType = Missile Or Shot(TempNumber).ShotType = Hellbore Or Shot(TempNumber).ShotType = Bullet Or Shot(TempNumber).ShotType = ExplosiveBullet Then
                If shot(tempnumber).ShotType < 4 Then
                    If (shot(tempnumber).ShotX - shot(shotcounter).ShotX) * (shot(tempnumber).ShotX - shot(shotcounter).ShotX) + (shot(tempnumber).ShotY - shot(shotcounter).ShotY) * (shot(tempnumber).ShotY - shot(shotcounter).ShotY) < 50 Then
                        shot(tempnumber).ShotType = NOSHOT
                        shot(shotcounter).ShotType = NOSHOT
                        'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
                        GoTo dontrundronecode
                    End If
                End If
            Next tempnumber
''***************************'Nytt försök med drones     'Succé!! Yay!!
'            'moves te drone towards the tracking robot moves and paints the drone
            'LÄGG TILL IIF, DET KANSKE GÅR SNABBARE
            If Abs(shot(shotcounter).ShotY - RobotTop(shot(shotcounter).ShotAngle)) <= 8 Then   '2 '8
                If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2
                Else
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2
                End If
            ElseIf Abs(shot(shotcounter).ShotX - RobotLeft(shot(shotcounter).ShotAngle)) <= 8 Then '2 '8
                If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2
                Else
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2
                End If
            Else
                If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2 '1.41421356237 '2*cos 45 = 2*sin 45 = 1.41421356237
                Else
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2 '1.41421356237
                End If
                If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2 '1.41421356237
                Else
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2 '1.41421356237
                End If
            End If
''            end paint and move
'Checks hit
            For tempnumber = 1 To NumberOfRobotsPresent     'Undre raden fungerar men är insparad pga 64 K
                If (shot(shotcounter).ShotX - RobotLeft(tempnumber)) * (shot(shotcounter).ShotX - RobotLeft(tempnumber)) + (shot(shotcounter).ShotY - RobotTop(tempnumber)) * (shot(shotcounter).ShotY - RobotTop(tempnumber)) < 100 Then
                    shot(shotcounter).ShotType = SHOTHIT
                    shot(shotcounter).ShotAngle = tempnumber     'Which robot is hit?
                    'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
                    LastHiter(tempnumber) = shot(shotcounter).Shooter
                End If
            Next tempnumber
        Else
            shot(shotcounter).ShotType = NOSHOT    'destroy drone
        End If
dontrundronecode:
    Case Laser
        NotAnyShotsAtAll = False
        shot(shotcounter).ShotType = SHOTHIT
        LastHiter(shot(shotcounter).ShotAngle) = shot(shotcounter).Shooter

    Case SHOTHIT    'ShotHit
        If shot(shotcounter).ShotAngle < 100 Then    'Regular
            RShield(shot(shotcounter).ShotAngle) = RShield(shot(shotcounter).ShotAngle) - shot(shotcounter).ShotPower
            If RShield(shot(shotcounter).ShotAngle) < 0 Then 'If Shield still is above 0 the shot only hit the shield
                RDamage(shot(shotcounter).ShotAngle) = RDamage(shot(shotcounter).ShotAngle) + RShield(shot(shotcounter).ShotAngle)
                RShield(shot(shotcounter).ShotAngle) = 0
            End If
        ElseIf shot(shotcounter).ShotAngle < 1000 Then   'Stunner
            RStunned(shot(shotcounter).ShotAngle \ 100) = RStunned(shot(shotcounter).ShotAngle \ 100) + shot(shotcounter).ShotPower
        Else    'Hellbore
            RShield(shot(shotcounter).ShotAngle \ 1000) = 0
        End If
        shot(shotcounter).ShotType = NOSHOT

    Case Else
        NotAnyShotsAtAll = False
        trigx = Sin12(shot(shotcounter).ShotAngle)
        trigy = Cos12(shot(shotcounter).ShotAngle)

        shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy

        trigy = trigy + shot(shotcounter).ShotY
        trigx = shot(shotcounter).ShotX - trigx

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then

                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
'                    Shot(ShotCounter).ShotType = TakeNuke      'Old fashion Explosive Bullets
'                    GoTo OldStyleExplosiveBullets                      'Do not erase
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If

                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 1     'Which robot is hit?
                LastHiter(1) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then
                
                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If
                
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 2     'Which robot is hit?
                LastHiter(2) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then

                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If

                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 3     'Which robot is hit?
                LastHiter(3) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then

                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If

                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 4     'Which robot is hit?
                LastHiter(4) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then

                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If

                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 5     'Which robot is hit?
                LastHiter(5) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then

                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If

                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 6     'Which robot is hit?
                LastHiter(6) = shot(shotcounter).Shooter
            End If
        End If
End Select

Next shotcounter

If NotAnyShotsAtAll Then
    ShotNumber = 0
    FreeShot = -1
End If
   
 
    If RobotAlive(1) = 1 Then
        If RDamage(1) <= 0 Then           'Checks if the robots have any damage left.
RunDeath1:
            RobotAlive(1) = 0           'If the robot just died we set RobotAlive to 255 (means it died this chronon).
            RobotLeft(1) = -50
            RobotTop(1) = 150
            EnergyDisplay(1).Visible = False
    
            If REnergy(1) < -200 And EnableOverloading Then    'BUG ALERT!! BUG ALERT!! Skillnad i overloading mot den jävla Mac versionen: dels så sker skälva "döden" 1 chronon senare i
                RobotDead(1) = "Overloaded - Time: " & Chronon
                tempnumber = -2 '3 * CInt(Not StandardScoring)
                LastHiter(1) = 253
            ElseIf RScan(1) = 9999 Then
                RobotDead(1) = "Buggy - Time: " & Chronon
                tempnumber = -1 '2 * CInt(Not StandardScoring)
                LastHiter(1) = 254
            Else
                RobotDead(1) = "Dead - Time: " & Chronon              'Windows (vet inte om det har nån betydelse?), dels så slutar striden inte mindre än 2 chronon senare senare i Windows (om Mac scoring används)
                If (RCollision(1) = 0 Or RDamage(1) + 1 <= 0) And (RWall(1) = 0 Or RDamage(1) + 5 <= 0) And LastHiter(1) <> 1 And RLook(LastHiter(1)) <> 9999 And (RobotTeam(1) = 0 Or (RobotTeam(1) <> RobotTeam(LastHiter(1)))) Then
                    KR(LastHiter(1)) = KR(LastHiter(1)) + 1 'Also prevents robots from getting kill score for killing itself
                Else
                    LastHiter(1) = 255     'Records that the robot died from a Wall Collision, Collision or suicided (for 4.5.2)
                End If
                tempnumber = 0 'CInt(Not StandardScoring)
            End If
            
            If Not RunningTournament Then
            RobotDead(1).Visible = True
            'DoEvents               'For the Nextevents optimization
            End If
            
            HowManyLeft = HowManyLeft - 1
            
            'Robots Int
            For shotcounter = 1 To NumberOfRobotsPresent
                If RobotsInst(shotcounter) >= 0 And HowManyLeft < RobotsParam(shotcounter) Then
                     RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
                     RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = RobotsInst(shotcounter)
                     IntID(shotcounter, RobotQuePos(shotcounter)) = 9
                End If
            Next shotcounter
    
            'Teammates Int
            RRadar = 0                                       'Calculates how many teammates there is left
            For shotcounter = 1 To NumberOfRobotsPresent    'If a robot is in the same team that the robot who just died + it's alive it's a living teammate
                If RobotTeam(shotcounter) = RobotTeam(1) And RobotAlive(shotcounter) = 1 Then RRadar = RRadar + 1
            Next shotcounter
    
            For shotcounter = 1 To NumberOfRobotsPresent
                If RobotTeam(shotcounter) = RobotTeam(1) Then     'If they're not in the same team we can ignore the teammates int
                    If TeammatesInst(shotcounter) >= 0 Then         'If it uses the teammates inst
                        If RRadar < TeammatesParam(shotcounter) Then    'If the teammates in the team no is below teammatesparam
                            RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
                            RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = TeammatesInst(shotcounter)
                            IntID(shotcounter, RobotQuePos(shotcounter)) = 10
                        End If
                    End If
                End If
            Next shotcounter
            
            If RRadar = 0 Then HowManyLeft = 0
            
            'End Team Stuff

            If HowManyLeft <= 1 Then        'If there's one or less than one robot left the battle should be stopped
                MaxChronon = Chronon + 20 + tempnumber * CInt(Not StandardScoring)
                HowManyLeft = 255           'If the solitare robot should die we prevent the battle from going on an additional 20 chronons this way
            End If
            
            REnergy(1) = -10    'To prevent false dopplering
        End If
    ElseIf RobotAlive(1) = 255 Then
        GoTo RunDeath1
    End If
    
    RCollision(1) = 0  'Resets collision to zero before the collision loop

                                        '*DEATH. This is the loop that checks for Robots death, and handles kill scoring.
For RNN = 2 To NumberOfRobotsPresent    'To increase battle speed, it's a lot different than the one displayed battle is using.
    If RobotAlive(RNN) = 1 Then
        If RDamage(RNN) <= 0 Then           'Checks if the robots have any damage left.
RunDeath:
            RobotAlive(RNN) = 0           'If the robot just died we set RobotAlive to 255 (means it died this chronon).
            RobotLeft(RNN) = -50
            RobotTop(RNN) = 150
            EnergyDisplay(RNN).Visible = False
    
            If REnergy(RNN) < -200 And EnableOverloading Then    'BUG ALERT!! BUG ALERT!! Skillnad i overloading mot den jävla Mac versionen: dels så sker skälva "döden" 1 chronon senare i
                RobotDead(RNN) = "Overloaded - Time: " & Chronon
                tempnumber = -2 '3 * CInt(Not StandardScoring)
                LastHiter(RNN) = 253
            ElseIf RScan(RNN) = 9999 Then
                RobotDead(RNN) = "Buggy - Time: " & Chronon
                tempnumber = -1 '2 * CInt(Not StandardScoring)
                LastHiter(RNN) = 254
            Else
                RobotDead(RNN) = "Dead - Time: " & Chronon              'Windows (vet inte om det har nån betydelse?), dels så slutar striden inte mindre än 2 chronon senare senare i Windows (om Mac scoring används)
                If (RCollision(RNN) = 0 Or RDamage(RNN) + 1 <= 0) And (RWall(RNN) = 0 Or RDamage(RNN) + 5 <= 0) And LastHiter(RNN) <> RNN And RLook(LastHiter(RNN)) <> 9999 And (RobotTeam(RNN) = 0 Or (RobotTeam(RNN) <> RobotTeam(LastHiter(RNN)))) Then
                    KR(LastHiter(RNN)) = KR(LastHiter(RNN)) + 1 'Also prevents robots from getting kill score for killing itself
                Else
                    LastHiter(RNN) = 255     'Records that the robot died from a Wall Collision, Collision or suicided (for 4.5.2)
                End If
                tempnumber = 0 'CInt(Not StandardScoring)
            End If
            
            If Not RunningTournament Then
                RobotDead(RNN).Visible = True
                'DoEvents       'For the Nextevents optimization
            End If
            
            HowManyLeft = HowManyLeft - 1
            
            'Robots Int
            For shotcounter = 1 To NumberOfRobotsPresent
                If RobotsInst(shotcounter) >= 0 And HowManyLeft < RobotsParam(shotcounter) Then
                     RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
                     RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = RobotsInst(shotcounter)
                     IntID(shotcounter, RobotQuePos(shotcounter)) = 9
                End If
            Next shotcounter
    
            'Teammates Int
            RRadar = 0                                       'Calculates how many teammates there is left
            For shotcounter = 1 To NumberOfRobotsPresent    'If a robot is in the same team that the robot who just died + it's alive it's a living teammate
                If RobotTeam(shotcounter) = RobotTeam(RNN) And RobotAlive(shotcounter) = 1 Then RRadar = RRadar + 1
            Next shotcounter
    
            For shotcounter = 1 To NumberOfRobotsPresent
                If RobotTeam(shotcounter) = RobotTeam(RNN) Then     'If they're not in the same team we can ignore the teammates int
                    If TeammatesInst(shotcounter) >= 0 Then         'If it uses the teammates inst
                        If RRadar < TeammatesParam(shotcounter) Then    'If the teammates in the team no is below teammatesparam
                            RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
                            RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = TeammatesInst(shotcounter)
                            IntID(shotcounter, RobotQuePos(shotcounter)) = 10
                        End If
                    End If
                End If
            Next shotcounter
            
            If RRadar = 0 Then HowManyLeft = 0
            
            'End Team Stuff

            If HowManyLeft <= 1 Then        'If there's one or less than one robot left the battle should be stopped
                MaxChronon = Chronon + 20 + tempnumber * CInt(Not StandardScoring)
                HowManyLeft = 255           'If the solitare robot should die we prevent the battle from going on an additional 20 chronons this way
            End If
            
            REnergy(RNN) = -10    'To prevent false dopplering
        End If
    ElseIf RobotAlive(RNN) = 255 Then
        GoTo RunDeath
    End If
    
    RCollision(RNN) = 0  'Resets collision to zero before the collision loop
Next RNN

'    If Chronon = NextEvents Then                           'For the Nextevents optimization
'        NextEvents = NextEvents + 167                      'Just remove comments to enable
''**************************doevent2**************************
      If PeekMessage(Message, 0, 0, 0, PM_NOREMOVE) Then      'checks for a message in the queue
         DoEvents                                             'dispatches any messages in the queue
      End If
''************************************************************
'    End If
    Chronon = Chronon + 1
Loop

StartTime = Timer - StartTime
If StartTime >= 1 Then      'We must have av least 1 sec of measuring otherwise the
    StartTime = Chronon / StartTime     'measuring will be very inaccurate
    CPRLabel = Format(StartTime, "#")
End If
'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*
' Striden avslutas
Peace:
    For RNN = 1 To NumberOfRobotsPresent    'Just so ER should correspond to energydisplay
        If Not Replaying Then
            BackupHistory (RNN)
            HistoryRec(RNN, 9) = RDamage(RNN) * (RobotAlive(RNN) = 1)
        End If
    Next RNN

    KillPoints LastHiter, RobotAlive
    RewardPoints RobotAlive(1), RobotAlive(2), RobotAlive(3), RobotAlive(4), RobotAlive(5), RobotAlive(6)
    EndBattle
End Sub


Private Sub ULTRAMODE()
'This is yet another clone of the undisplayed battle engine, with the ultra mode enabled
'Changes should be in the No-Display battle engine, then clone it to ultra

'Debugging variables
Dim ErrorCode As Long
Dim RandomCounter As Long

'Robotarnas maskinkod - The robots' machinecode
Dim MachineCode(1 To 6, 4999) As Long    '0-4999 = RobotInstructions
Dim RobotInstPos(1 To 6) As Long
                                        
'Robotarnas Stack - The robots' Stacks
Dim RobotStack(1 To 6, 1 To 100) As Long     'long
Dim RobotStackPos(1 To 6) As Long           'How many numbers the robots has on it's stack

'Robotarnas Interupptsköer - The robots' interupps ques
Dim RobotIntQue(1 To 6, 1 To 100) As Long
Dim RobotQuePos(1 To 6) As Long
Dim IntID(1 To 6, 1 To 100) As Long

'Robots hardware
Dim RobotShield(1 To 6) As Long
Dim RobotEnergy(1 To 6) As Long
Dim RobotProSpeed(1 To 6) As Long
Dim RobotMissiles(1 To 6) As Long
Dim RobotTacNukes(1 To 6) As Long
Dim RobotBullets(1 To 6) As Long
Dim RobotStunners(1 To 6) As Long
Dim RobotHellbores(1 To 6) As Long
Dim RobotMines(1 To 6) As Long
Dim RobotLasers(1 To 6) As Long
Dim RobotDrones(1 To 6) As Long
Dim RobotProbes(1 To 6) As Long

'Robotarnas variabler - The robots' variables
Dim RA(1 To 6) As Long
Dim RB(1 To 6) As Long
Dim RC(1 To 6) As Long
Dim RD(1 To 6) As Long
Dim RE(1 To 6) As Long
Dim RF(1 To 6) As Long
Dim RG(1 To 6) As Long
Dim RH(1 To 6) As Long
Dim RI(1 To 6) As Long
Dim RJ(1 To 6) As Long 'Used to be ints, but it seems like people using them
Dim RK(1 To 6) As Long 'to store placerecalls
Dim RL(1 To 6) As Long 'For example "radar' a' store" won't work with longs
Dim RM(1 To 6) As Long 'long is slower, but robots simply doesn't work otherwise.
Dim RN(1 To 6) As Long
Dim RO(1 To 6) As Long
Dim RP(1 To 6) As Long
Dim RQ(1 To 6) As Long
Dim RR(1 To 6) As Long
Dim RS(1 To 6) As Long
Dim RT(1 To 6) As Long
Dim RU(1 To 6) As Long
Dim RV(1 To 6) As Long
Dim RZ(1 To 6) As Long
Dim RW(1 To 6) As Long
Dim RVRECALL(1 To 6, 100) As Long

'Probes and Interupps
Dim ProbeSet(1 To 6) As Long '0 = Damage 1 = Energy 2 = Shield 3 = ID '5 = Aim 6 = look 7 = scan 4 = Teammates - Currently disabled 'cause of no teams

Dim Inton(1 To 6) As Boolean
Dim RangeInst(1 To 6) As Long
Dim RangeParam(1 To 6) As Long
Dim RadarInst(1 To 6) As Long
Dim RadarParam(1 To 6) As Long
Dim ChrononInst(1 To 6) As Long  'Måste alltid dras ifrån en då denna sätts för att mataren matar fram + 1
Dim ChrononParam(1 To 6) As Long
Dim RobotsInst(1 To 6) As Long
Dim RobotsParam(1 To 6) As Long
Dim RightParam(1 To 6) As Long
Dim LeftParam(1 To 6) As Long
Dim TopParam(1 To 6) As Long
Dim BotParam(1 To 6) As Long
Dim RightInst(1 To 6) As Long
Dim LeftInst(1 To 6) As Long
Dim TopInst(1 To 6) As Long
Dim BotInst(1 To 6) As Long
Dim CollisionInst(1 To 6) As Long
Dim WallInst(1 To 6) As Long
Dim DamageInst(1 To 6) As Long
Dim DamageParam(1 To 6) As Long
Dim ShieldInst(1 To 6) As Long
Dim ShieldParam(1 To 6) As Long
Dim HistoryParam(1 To 6) As Long

' Team Variables
Dim RSignal(1 To 3, 1 To 10) As Long
Dim RChannel(1 To 6) As Long
Dim TeammatesInst(1 To 6) As Long
Dim TeammatesParam(1 To 6) As Long
Dim SignalInst(1 To 6) As Long
Dim SignalParam(1 To 6) As Long

'Things that can be recalled
Dim RCollision(1 To 6)  As Long
Dim RWall(1 To 6)  As Long
Dim REnergy(1 To 6) As Long
Dim RDamage(1 To 6) As Long
Dim RShield(1 To 6) As Long 'Byte
Dim RSpeedx(1 To 6) As Long
Dim RSpeedy(1 To 6) As Long
Dim RAim(1 To 6) As Long
Dim RLook(1 To 6) As Long
Dim RScan(1 To 6) As Long
Dim RRadar As Long   'Kanske kan byggas ihop? Bytas ut?
Dim RRange As Long

'Robot Specific Game Vars
Dim RobotAlive(1 To 6) As Long 'Boolean
Dim RStunned(1 To 6) As Long     'The number of chronons the robot is stunned
                                    'Hasmoved skall ha 2 funktioner. Dels MoveAndShot, dels så att LEFT' RIGHT' TOP' BOT'
                                    'skall kunna triggas med movex
Dim LastHiter(1 To 6) As Long
Dim HasMoved As Long
Dim DroneShotDown As Boolean    'This var decides wether we have to check through every shot when a x-bullet or a tacnuke explode.
'If there's robots using drones, we have to. If there's no robots using drones, we can skip this a benifit speed.

'Vars neccesary for running the game
Dim NextEvents As Long     'For the Nextevents optimization
Dim RNN As Long              'Stands for Robot ruNniNg or something like that (I don't remember exactly what to be honest). Correspond aproximately to the variable "who" in Mac RoboWar
Dim ChrononExecutor1 As Long 'Correspons to "cycleNum"
Dim HowManyLeft As Long      'Used to determine when to cancel battle. Set to 2 if only one robot is present, to avoid that battle breaks at Chronon 20
Dim tempnumber As Long    'temporary placeholder for longs
Dim TDouble As Double      'To avoid trig calculations to get truncated

'Shot vars
Dim FreeShot As Long
FreeShot = -1
Dim shotcounter As Long  'Kan användas i debuggern istället för RRadar?
Dim NotAnyShotsAtAll As Boolean
Dim shot(32768) As ShotPrivateType
Dim ShotNumber As Long

Dim trigx As Single
Dim trigy As Single

InizBattle
        'Battle Starts. The robots get randomly placed in the Arena

'Robot 1. Allways Present
        REnergy(1) = Robot1Energy
        RDamage(1) = Robot1Damage
        
'Laddar machinkoden till Robotarna
        For RNN = 0 To 4999
            MachineCode(1, RNN) = MasterCode(1, RNN)
            If (MachineCode(1, RNN) >= insICON0 And MachineCode(1, RNN) <= insICON9) Or (MachineCode(1, RNN) >= insDEBUG And MachineCode(1, RNN) <= insSND9) Then MachineCode(1, RNN) = insBEEP
            If MachineCode(1, RNN) = insEND Then Exit For
        Next RNN

        If R2Present Then
            For RNN = 0 To 4999
                MachineCode(2, RNN) = MasterCode(2, RNN)
                If (MachineCode(2, RNN) >= insICON0 And MachineCode(2, RNN) <= insICON9) Or (MachineCode(2, RNN) >= insDEBUG And MachineCode(2, RNN) <= insSND9) Then MachineCode(2, RNN) = insBEEP
                If MachineCode(2, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace2        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(2) = Robot2Energy
            RDamage(2) = Robot2Damage
        End If

        If R3Present Then
            For RNN = 0 To 4999
                MachineCode(3, RNN) = MasterCode(3, RNN)
                If (MachineCode(3, RNN) >= insICON0 And MachineCode(3, RNN) <= insICON9) Or (MachineCode(3, RNN) >= insDEBUG And MachineCode(3, RNN) <= insSND9) Then MachineCode(3, RNN) = insBEEP
                If MachineCode(3, RNN) = insEND Then Exit For
            Next RNN
            
            MasterPlace3
            REnergy(3) = Robot3Energy
            RDamage(3) = Robot3Damage
        End If

        If R4Present Then
            For RNN = 0 To 4999
                MachineCode(4, RNN) = MasterCode(4, RNN)
                If (MachineCode(4, RNN) >= insICON0 And MachineCode(4, RNN) <= insICON9) Or (MachineCode(4, RNN) >= insDEBUG And MachineCode(4, RNN) <= insSND9) Then MachineCode(4, RNN) = insBEEP
                If MachineCode(4, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace4        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(4) = Robot4Energy
            RDamage(4) = Robot4Damage
        End If

        If R5Present Then
            For RNN = 0 To 4999
                MachineCode(5, RNN) = MasterCode(5, RNN)
                If (MachineCode(5, RNN) >= insICON0 And MachineCode(5, RNN) <= insICON9) Or (MachineCode(5, RNN) >= insDEBUG And MachineCode(5, RNN) <= insSND9) Then MachineCode(5, RNN) = insBEEP
                If MachineCode(5, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace5        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(5) = Robot5Energy
            RDamage(5) = Robot5Damage
        End If

        If R6Present Then
            For RNN = 0 To 4999
                MachineCode(6, RNN) = MasterCode(6, RNN)
                If (MachineCode(6, RNN) >= insICON0 And MachineCode(6, RNN) <= insICON9) Or (MachineCode(6, RNN) >= insDEBUG And MachineCode(6, RNN) <= insSND9) Then MachineCode(6, RNN) = insBEEP
                If MachineCode(6, RNN) = insEND Then Exit For
            Next RNN

            MasterPlace6        'This sub places the robot and checks that it wasn't placed too near another robot
            REnergy(6) = Robot6Energy
            RDamage(6) = Robot6Damage
        End If
        
HowManyLeft = CheckHowManyLeft

'Syncs Hardware to array
RobotShield(1) = Robot1Shield
RobotEnergy(1) = Robot1Energy
RobotProSpeed(1) = Robot1ProSpeed
RobotMissiles(1) = Robot1Missiles
RobotTacNukes(1) = Robot1TacNukes
RobotBullets(1) = Robot1Bullets
RobotStunners(1) = Robot1Stunners
RobotHellbores(1) = Robot1Hellbores
RobotMines(1) = Robot1Mines
RobotLasers(1) = Robot1Lasers
RobotDrones(1) = Robot1Drones
RobotProbes(1) = Robot1Probes
RobotShield(2) = Robot2Shield
RobotEnergy(2) = Robot2Energy
RobotProSpeed(2) = Robot2ProSpeed
RobotMissiles(2) = Robot2Missiles
RobotTacNukes(2) = Robot2TacNukes
RobotBullets(2) = Robot2Bullets
RobotStunners(2) = Robot2Stunners
RobotHellbores(2) = Robot2Hellbores
RobotMines(2) = Robot2Mines
RobotLasers(2) = Robot2Lasers
RobotDrones(2) = Robot2Drones
RobotProbes(2) = Robot2Probes
RobotShield(3) = Robot3Shield
RobotEnergy(3) = Robot3Energy
RobotProSpeed(3) = Robot3ProSpeed
RobotMissiles(3) = Robot3Missiles
RobotTacNukes(3) = Robot3TacNukes
RobotBullets(3) = Robot3Bullets
RobotStunners(3) = Robot3Stunners
RobotHellbores(3) = Robot3Hellbores
RobotMines(3) = Robot3Mines
RobotLasers(3) = Robot3Lasers
RobotDrones(3) = Robot3Drones
RobotProbes(3) = Robot3Probes
RobotShield(4) = Robot4Shield
RobotEnergy(4) = Robot4Energy
RobotProSpeed(4) = Robot4ProSpeed
RobotMissiles(4) = Robot4Missiles
RobotTacNukes(4) = Robot4TacNukes
RobotBullets(4) = Robot4Bullets
RobotStunners(4) = Robot4Stunners
RobotHellbores(4) = Robot4Hellbores
RobotMines(4) = Robot4Mines
RobotLasers(4) = Robot4Lasers
RobotDrones(4) = Robot4Drones
RobotProbes(4) = Robot4Probes
RobotShield(5) = Robot5Shield
RobotEnergy(5) = Robot5Energy
RobotProSpeed(5) = Robot5ProSpeed
RobotMissiles(5) = Robot5Missiles
RobotTacNukes(5) = Robot5TacNukes
RobotBullets(5) = Robot5Bullets
RobotStunners(5) = Robot5Stunners
RobotHellbores(5) = Robot5Hellbores
RobotMines(5) = Robot5Mines
RobotLasers(5) = Robot5Lasers
RobotDrones(5) = Robot5Drones
RobotProbes(5) = Robot5Probes
RobotShield(6) = Robot6Shield
RobotEnergy(6) = Robot6Energy
RobotProSpeed(6) = Robot6ProSpeed
RobotMissiles(6) = Robot6Missiles
RobotTacNukes(6) = Robot6TacNukes
RobotBullets(6) = Robot6Bullets
RobotStunners(6) = Robot6Stunners
RobotHellbores(6) = Robot6Hellbores
RobotMines(6) = Robot6Mines
RobotLasers(6) = Robot6Lasers
RobotDrones(6) = Robot6Drones
RobotProbes(6) = Robot6Probes
'End Syncs Hardware to array

For tempnumber = 1 To NumberOfRobotsPresent
    RobotInstPos(tempnumber) = -1 'Sets robot RobotInstPos to -1 'cause t have to start with 0 (= -1 + 1 )
    RAim(tempnumber) = 90
    RobotAlive(tempnumber) = 1
    LastHiter(tempnumber) = tempnumber

    RChannel(tempnumber) = 1
    TeammatesInst(tempnumber) = -1
    TeammatesParam(tempnumber) = 5
    SignalInst(tempnumber) = -1

    RadarInst(tempnumber) = -1
    RangeInst(tempnumber) = -1
    ChrononInst(tempnumber) = -1
    CollisionInst(tempnumber) = -1
    WallInst(tempnumber) = -1
    TopInst(tempnumber) = -1
    BotInst(tempnumber) = -1
    LeftInst(tempnumber) = -1
    RightInst(tempnumber) = -1
    RobotsInst(tempnumber) = -1
    DamageInst(tempnumber) = -1
    ShieldInst(tempnumber) = -1
    RobotsParam(tempnumber) = 6
    RadarParam(tempnumber) = 600
    RangeParam(tempnumber) = 600
    TopParam(tempnumber) = 20
    BotParam(tempnumber) = 280
    LeftParam(tempnumber) = 20
    RightParam(tempnumber) = 280
    DamageParam(tempnumber) = RDamage(tempnumber)
    ShieldParam(tempnumber) = 25
    SignalParam(tempnumber) = 1
    
    HistoryParam(tempnumber) = 1

    If RobotDrones(tempnumber) = 1 Then DroneShotDown = True
Next tempnumber

' Avläsningen av koden (BÖRJAN)
'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*

On Error GoTo CodeError1

Dim StartTime As Single
StartTime = Timer

Do While Chronon <> MaxChronon  '<>
    If RobotAlive(1) = 1 Then
        If RStunned(1) = 0 Then
            If RShield(1) > 0 Then
               If RobotShield(1) < RShield(1) Then
                   RShield(1) = RShield(1) - 2
                   If RShield(1) < 0 Then RShield(1) = 0       'Behövs
               Else
                   If Chronon Mod 2 = 0 Then RShield(1) = RShield(1) - 1
               End If
            End If

            If REnergy(1) <> RobotEnergy(1) Then
                If REnergy(1) >= -200 Then
                    REnergy(1) = REnergy(1) + 2
                    If REnergy(1) > RobotEnergy(1) Then REnergy(1) = RobotEnergy(1)
                Else
                    If EnableOverloading Then RobotAlive(1) = 255 Else REnergy(1) = REnergy(1) + 2
                End If
            End If
    
            If REnergy(1) >= 1 Then
                If RSpeedx(1) <> 0 Or RSpeedy(1) <> 0 Then 'Boosts battlespeed and reduces flickering for robots that stads still.
                    RobotLeft(1) = RobotLeft(1) + RSpeedx(1)
                    RobotTop(1) = RobotTop(1) + RSpeedy(1)
                End If
            End If
        End If 'RStunned

        '''Kollision med varandra, Skall Nu vara nästintill perfekt
        For tempnumber = 2 To NumberOfRobotsPresent
                If RobotAlive(tempnumber) = 1 Then
                    If (RobotLeft(1) - RobotLeft(tempnumber)) * (RobotLeft(1) - RobotLeft(tempnumber)) + (RobotTop(1) - RobotTop(tempnumber)) * (RobotTop(1) - RobotTop(tempnumber)) <= 400 Then
                        If RCollision(1) = 0 Then
                            RCollision(1) = tempnumber   '' Var 1 förut nu registrerar den vilken robot den kolliderar med
                            If RShield(1) > 0 Then RShield(1) = RShield(1) - 1 Else RDamage(1) = RDamage(1) - 1     'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
                       
                            If RStunned(1) = 0 And REnergy(1) >= 1 Then
                                RobotLeft(1) = RobotLeft(1) - RSpeedx(1)
                                RobotTop(1) = RobotTop(1) - RSpeedy(1)
                            End If
                        End If
        
                        If RCollision(tempnumber) = 0 Then
                            RCollision(tempnumber) = 1
                            If RShield(tempnumber) > 0 Then RShield(tempnumber) = RShield(tempnumber) - 1 Else RDamage(tempnumber) = RDamage(tempnumber) - 1     'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
        
                            'If RStunned(TempNumber) = 0 And REnergy(TempNumber) >= 1 Then
                            If RStunned(tempnumber) = 0 And REnergy(tempnumber) - 2 * (tempnumber > 1) >= 1 Then
                                RobotLeft(tempnumber) = RobotLeft(tempnumber) - RSpeedx(tempnumber)
                                RobotTop(tempnumber) = RobotTop(tempnumber) - RSpeedy(tempnumber)
                            End If
                        End If
                    End If
                End If
        Next tempnumber

        'KOLLISION MED VÄGGARNA - WALL COLLISION
        If WCX(RobotLeft(1)) Or WCY(RobotTop(1)) Then
            RWall(1) = 1
            RDamage(1) = Min(RDamage(1), (RDamage(1) - 5 + RShield(1)))
            RShield(1) = ZeroOrMore(RShield(1) - 5)

            If RobotLeft(1) > 300 Then  'otherwise it can use SPEEDX to run outside the areana!!!
                RobotLeft(1) = 300      'den har inte flyttats någonstans, vi har istället lagt till på movex
            ElseIf RobotLeft(1) < 0 Then
                RobotLeft(1) = 0
            End If
            If RobotTop(1) > 300 Then
                RobotTop(1) = 300
            ElseIf RobotTop(1) < 0 Then
                RobotTop(1) = 0
            End If
        Else
            RWall(1) = 0
        End If
    End If  'Alive if

'ROBOT LOADING LOOP - The New Collision Stunning Shield Energy Wall Loop
For RNN = 2 To NumberOfRobotsPresent
    If RobotAlive(RNN) = 1 Then
        If RStunned(RNN) = 0 Then
            If RShield(RNN) > 0 Then
               If RobotShield(RNN) < RShield(RNN) Then
                   RShield(RNN) = RShield(RNN) - 2
                   If RShield(RNN) < 0 Then RShield(RNN) = 0       'Behövs
               Else
                   If Chronon Mod 2 = 0 Then RShield(RNN) = RShield(RNN) - 1
               End If
            End If

            If REnergy(RNN) <> RobotEnergy(RNN) Then
                If REnergy(RNN) >= -200 Then
                    REnergy(RNN) = REnergy(RNN) + 2
                    If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN)
                Else
                    If EnableOverloading Then RobotAlive(RNN) = 255 Else REnergy(RNN) = REnergy(RNN) + 2
                End If
            End If
    
            If REnergy(RNN) >= 1 Then
                If RSpeedx(RNN) <> 0 Or RSpeedy(RNN) <> 0 Then 'Boosts battlespeed and reduces flickering for robots that stads still.
                    RobotLeft(RNN) = RobotLeft(RNN) + RSpeedx(RNN)
                    RobotTop(RNN) = RobotTop(RNN) + RSpeedy(RNN)
                End If
            End If
        End If 'RStunned

        '''Kollision med varandra, Skall Nu vara nästintill perfekt
        For tempnumber = 1 To NumberOfRobotsPresent
            If RNN <> tempnumber Then
                If RobotAlive(tempnumber) = 1 Then
                    If (RobotLeft(RNN) - RobotLeft(tempnumber)) * (RobotLeft(RNN) - RobotLeft(tempnumber)) + (RobotTop(RNN) - RobotTop(tempnumber)) * (RobotTop(RNN) - RobotTop(tempnumber)) <= 400 Then
                        If RCollision(RNN) = 0 Then
                            RCollision(RNN) = tempnumber   '' Var 1 förut nu registrerar den vilken robot den kolliderar med
                            If RShield(RNN) > 0 Then RShield(RNN) = RShield(RNN) - 1 Else RDamage(RNN) = RDamage(RNN) - 1     'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
                       
                            If RStunned(RNN) = 0 And REnergy(RNN) >= 1 Then
                                RobotLeft(RNN) = RobotLeft(RNN) - RSpeedx(RNN)
                                RobotTop(RNN) = RobotTop(RNN) - RSpeedy(RNN)
                            End If
                        End If
        
                        If RCollision(tempnumber) = 0 Then
                            RCollision(tempnumber) = RNN
                            If RShield(tempnumber) > 0 Then RShield(tempnumber) = RShield(tempnumber) - 1 Else RDamage(tempnumber) = RDamage(tempnumber) - 1     'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
        
                            'If RStunned(TempNumber) = 0 And REnergy(TempNumber) >= 1 Then
                            If RStunned(tempnumber) = 0 And REnergy(tempnumber) - 2 * (tempnumber > RNN) >= 1 Then
                                RobotLeft(tempnumber) = RobotLeft(tempnumber) - RSpeedx(tempnumber)
                                RobotTop(tempnumber) = RobotTop(tempnumber) - RSpeedy(tempnumber)
                            End If
                        End If
                    End If
                End If
            End If
        Next tempnumber

        'KOLLISION MED VÄGGARNA - WALL COLLISION
        If WCX(RobotLeft(RNN)) Or WCY(RobotTop(RNN)) Then
            RWall(RNN) = 1
            RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - 5 + RShield(RNN)))
            RShield(RNN) = ZeroOrMore(RShield(RNN) - 5)

            If RobotLeft(RNN) > 300 Then  'otherwise it can use SPEEDX to run outside the areana!!!
                RobotLeft(RNN) = 300      'den har inte flyttats någonstans, vi har istället lagt till på movex
            ElseIf RobotLeft(RNN) < 0 Then
                RobotLeft(RNN) = 0
            End If
            If RobotTop(RNN) > 300 Then
                RobotTop(RNN) = 300
            ElseIf RobotTop(RNN) < 0 Then
                RobotTop(RNN) = 0
            End If
        Else
            RWall(RNN) = 0
        End If
    End If  'Alive if
Next RNN

'ROBOT 1 CHRONON EXECUTOR
For RNN = 1 To NumberOfRobotsPresent
If HighestToLowest Then RNN = NumberOfRobotsPresent - RNN + 1   'Turns on backwards evaluation if it's enabled

If RobotAlive(RNN) = 1 Then
    If REnergy(RNN) >= 1 Then
        If RStunned(RNN) = 0 Then
        
            If TopInst(RNN) >= 0 Then
                If RSpeedy(RNN) < 0 Then
                    If RobotTop(RNN) <= TopParam(RNN) Then
                        If RobotTop(RNN) - RSpeedy(RNN) > TopParam(RNN) Then
                            RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                            RobotIntQue(RNN, RobotQuePos(RNN)) = TopInst(RNN)
                            IntID(RNN, RobotQuePos(RNN)) = 1
                        End If
                    End If
                End If
            End If
            If BotInst(RNN) >= 0 Then
                If RSpeedy(RNN) > 0 Then
                    If RobotTop(RNN) >= BotParam(RNN) Then
                        If RobotTop(RNN) - RSpeedy(RNN) < BotParam(RNN) Then
                            RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                            RobotIntQue(RNN, RobotQuePos(RNN)) = BotInst(RNN)
                            IntID(RNN, RobotQuePos(RNN)) = 2
                        End If
                    End If
                End If
            End If
            If LeftInst(RNN) >= 0 Then
                If RSpeedx(RNN) < 0 Then
                    If RobotLeft(RNN) <= LeftParam(RNN) Then
                        If RobotLeft(RNN) - RSpeedx(RNN) > LeftParam(RNN) Then
                            RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                            RobotIntQue(RNN, RobotQuePos(RNN)) = LeftInst(RNN)
                            IntID(RNN, RobotQuePos(RNN)) = 3
                        End If
                    End If
                End If
            End If
            If RightInst(RNN) >= 0 Then
                If RSpeedx(RNN) > 0 Then
                    If RobotLeft(RNN) >= RightParam(RNN) Then
                        If RobotLeft(RNN) - RSpeedx(RNN) < RightParam(RNN) Then
                            RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                            RobotIntQue(RNN, RobotQuePos(RNN)) = RightInst(RNN)
                            IntID(RNN, RobotQuePos(RNN)) = 4
                        End If
                    End If
                End If
            End If

            If ShieldInst(RNN) >= 0 Then            'If it's using the shield int
                If RShield(RNN) < ShieldParam(RNN) Then            'If we're in low shield
                    If ShieldInst(RNN) < 5000 Then    'And we weren't in low shield last chronon (then shieldinst should be > 4999)
                        RobotQuePos(RNN) = RobotQuePos(RNN) + 1                 'que the
                        RobotIntQue(RNN, RobotQuePos(RNN)) = ShieldInst(RNN) 'interupt
                        IntID(RNN, RobotQuePos(RNN)) = 5
                        ShieldInst(RNN) = ShieldInst(RNN) + 5000
                    End If
                Else    'If we're not in low shield anymore
                    If ShieldInst(RNN) > 4999 Then   'and our shieldinst is set to a weird value then
                        ShieldInst(RNN) = ShieldInst(RNN) - 5000  'Sets back shieldinst to it's real value
                    End If
                End If
            End If
            If DamageInst(RNN) >= 0 Then
                If RDamage(RNN) < DamageParam(RNN) Then
                    RobotQuePos(RNN) = RobotQuePos(RNN) + 1
                    RobotIntQue(RNN, RobotQuePos(RNN)) = DamageInst(RNN)
                    IntID(RNN, RobotQuePos(RNN)) = 6
                    DamageParam(RNN) = RDamage(RNN)
                End If
            End If
            If WallInst(RNN) >= 0 Then            'If it's using the wall int
                If RWall(RNN) <> 0 Then            'If we're in wall
                    If WallInst(RNN) < 5000 Then    'And we weren't in wall last chronon (then wallinst should be > 4999)
                        RobotQuePos(RNN) = RobotQuePos(RNN) + 1                 'que the
                        RobotIntQue(RNN, RobotQuePos(RNN)) = WallInst(RNN) 'interupt
                        IntID(RNN, RobotQuePos(RNN)) = 7
                        WallInst(RNN) = WallInst(RNN) + 5000
                    End If
                Else    'If we're not in wall anymore
                    If WallInst(RNN) > 4999 Then   'and our wall inst is set to a weird value then
                        WallInst(RNN) = WallInst(RNN) - 5000  'Sets back wallinst to it's real value
                    End If
                End If                 'COLLISION AND WALL SHOULD BE MUCH MORE CAREFULLY TESTED!!
            End If
            If CollisionInst(RNN) >= 0 Then            'If it's using the collision int
                If RCollision(RNN) <> 0 Then            'If we're in collision
                    If CollisionInst(RNN) < 5000 Then    'And we weren't in collision last chronon (then collisioninst should be > 4999)
                        RobotQuePos(RNN) = RobotQuePos(RNN) + 1                 'que the
                        RobotIntQue(RNN, RobotQuePos(RNN)) = CollisionInst(RNN) 'interupt
                        IntID(RNN, RobotQuePos(RNN)) = 8
                        CollisionInst(RNN) = CollisionInst(RNN) + 5000
                    End If
                Else    'If we're not in collision anymore
                    If CollisionInst(RNN) > 4999 Then   'and our collision inst is set to a weird value then
                        CollisionInst(RNN) = CollisionInst(RNN) - 5000  'Sets back collisioninst to it's real value
                    End If
                End If
            End If

            If RobotQuePos(RNN) > 1 Then        'This is hopefully only a temporary solution for doubletrigging problems
                If RobotIntQue(RNN, RobotQuePos(RNN)) = RobotIntQue(RNN, RobotQuePos(RNN) - 1) And IntID(RNN, RobotQuePos(RNN)) = IntID(RNN, RobotQuePos(RNN) - 1) Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
            End If

            If Inton(RNN) Then
                If RobotQuePos(RNN) > 0 Then
                    If RobotStackPos(RNN) > 99 Then
                        ErrorCode = BuggyOverflow: GoTo Buggy
                    End If
                    RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                    RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
                    RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1    'qued ints subtracted when triggered             'jumps shall be done
                    Inton(RNN) = False
                    RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                    GoTo SkipTheRestOfTheInts
                ElseIf RadarInst(RNN) >= 0 Then
                    'RADAR
                    RRadar = 0
                    For shotcounter = 1 To ShotNumber
                        If shot(shotcounter).ShotType < 200 Then
                            'This is David Harris radar code, ported to Visual Basic by me.
                            trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                            trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                            
                            If trigx <> 0 Then   'atan2
                                tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                            Else
                                tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                            End If          '''''''
                            
                            If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                            
                            If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                                RRange = FixSquare(trigx * trigx + trigy * trigy)
                                If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                            End If
                        End If
                    Next shotcounter
                    '/RADAR
                    If RRadar <> 0 Then
                        If RRadar <= RadarParam(RNN) Then   'intrange sends back 601 for no range instead of 0
                            If RobotStackPos(RNN) > 99 Then
                                ErrorCode = BuggyOverflow: GoTo Buggy
                            End If
                            RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
                            RobotInstPos(RNN) = RadarInst(RNN) - 1 ' -1 är nytt
                            Inton(RNN) = False
                            GoTo SkipTheRestOfTheInts
                        End If
                    End If
                End If
                If RangeInst(RNN) >= 0 Then
                'specialrange.. designed for 1 time per chronon checking
                    RRadar = RAim(RNN) + RLook(RNN)
                    If 1 <> RNN Then   'Skip checking range to self. It'll be too short
                        tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
                        trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
                        trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
            
                        If trigx * trigx + trigy * trigy <= 91 Then
                            If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                If RobotAlive(1) = 1 Then
                                    If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
                                        If RobotStackPos(RNN) > 99 Then
                                            ErrorCode = BuggyOverflow: GoTo Buggy
                                        End If
                                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                                        RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
                                        RobotInstPos(RNN) = RangeInst(RNN) - 1 ' -1 är nytt
                                        Inton(RNN) = False
                                        GoTo SkipTheRestOfTheInts
                                    End If
                                End If
                            End If
                        End If
                    End If
                    
                    For shotcounter = 2 To NumberOfRobotsPresent
                        If shotcounter <> RNN Then   'Skip checking range to self. It'll be too short
                            tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
                            trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
                            trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
                
                            If trigx * trigx + trigy * trigy <= 91 Then
                                If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                    If RobotAlive(shotcounter) = 1 Then
                                        If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
                                            If RobotStackPos(RNN) > 99 Then
                                                ErrorCode = BuggyOverflow: GoTo Buggy
                                            End If
                                            RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
                                            RobotInstPos(RNN) = RangeInst(RNN) - 1 ' -1 är nytt
                                            Inton(RNN) = False
                                            GoTo SkipTheRestOfTheInts
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next shotcounter
                '''''''''''
                End If
                If ChrononInst(RNN) >= 0 Then
                    If ChrononParam(RNN) <= Chronon Then
                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
                        RobotInstPos(RNN) = ChrononInst(RNN) - 1
                        Inton(RNN) = False
                    End If
                End If
            End If

SkipTheRestOfTheInts:

        'Typ här skall hasmoved bli falskt
        HasMoved = 0
        
        '''Slut INTERUPPSKODEN
        For ChrononExecutor1 = 1 To RobotProSpeed(RNN)
            RobotInstPos(RNN) = RobotInstPos(RNN) + 1

'It my tests shows, that in the following Select Case coditional, best speed results are gained when the most
'common instructions are placed first.

                Select Case MachineCode(RNN, RobotInstPos(RNN))  'MachineCode
                    Case -19999 To 19999
                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
                    Case insA To TOPREGISTER
                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
                    Case insSTORE
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                    
                        Select Case RobotStack(RNN, RobotStackPos(RNN))
                            Case insAIM 'ins
                                RAim(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Mod 360
                                If RAim(RNN) < 0 Or RAim(RNN) > 359 Then RAim(RNN) = RAim(RNN) Mod 360 - 360 * (RAim(RNN) < 0)

                                If Inton(RNN) Then  '**********Interuppskod************'
                                    If RadarInst(RNN) >= 0 Then
                                        'RADAR
                                        RRadar = 0
                                        For shotcounter = 1 To ShotNumber
                                            If shot(shotcounter).ShotType < 200 Then
                                                'This is David Harris radar code, ported to Visual Basic by me.
                                                trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                                                trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                                                
                                                If trigx <> 0 Then   'atan2
                                                    tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                                                Else
                                                    tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                                                End If          '''''''
                                                
                                                If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                                                
                                                If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                                                    RRange = FixSquare(trigx * trigx + trigy * trigy)
                                                    If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                                                End If
                                            End If
                                        Next shotcounter
                                        '/RADAR
                                        If RRadar <> 0 Then
                                            If RRadar <= RadarParam(RNN) Then   'intrange sends back 601 for no range instead of 0
                                                RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                RobotInstPos(RNN) = RadarInst(RNN) - 1
                                                Inton(RNN) = False
                                                GoTo NoStackRemoval
                                            End If
                                        End If
                                    End If
                                    If RangeInst(RNN) >= 0 Then
                                    'specialrange.. designed för look and aim instructions
                                        RRadar = RAim(RNN) + RLook(RNN)
                                        If 1 <> RNN Then   'Skip checking range to self. It'll be too short
                                            tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
                                            trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
                                            trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
                                
                                            If trigx * trigx + trigy * trigy <= 91 Then
                                                If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                                    If RobotAlive(1) = 1 Then
                                                        If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
                                                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                            RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
                                                            Inton(RNN) = False
                                                            GoTo NoStackRemoval
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                        
                                        For shotcounter = 2 To NumberOfRobotsPresent
                                            If shotcounter <> RNN Then   'Skip checking range to self. It'll be too short
                                                tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
                                                trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
                                                trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
                                    
                                                If trigx * trigx + trigy * trigy <= 91 Then
                                                    If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                                        If RobotAlive(shotcounter) = 1 Then
                                                            If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
                                                                RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                                RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                                RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
                                                                Inton(RNN) = False
                                                                GoTo NoStackRemoval
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Next shotcounter
                                    '''''''''''
                                    End If
                                End If '**********Slut Interuppskod************'
                            Case insSPEEDX 'ins
                                If Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RSpeedx(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
                                RSpeedx(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSPEEDY 'ins
                                If Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RSpeedy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
                                RSpeedy(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insMISSILE 'ins
                                If RobotMissiles(RNN) = 0 Then
                                    ErrorCode = BuggyMissiles
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
                                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotAngle = RAim(RNN)
                                                shot(ShotNumber).ShotType = Missile
                                                shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotAngle = RAim(RNN)
                                                shot(FreeShot).ShotType = Missile
                                                shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insFIRE 'ins
Robot1Fire:
                                If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                    REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    If HasMoved <> 5 Or MoveAndShotAllowed Then
                                        If FreeShot = -1 Then
                                            ShotNumber = ShotNumber + 1
                                            shot(ShotNumber).ShotAngle = RAim(RNN)
                                            shot(ShotNumber).ShotType = Bullet
                                            shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                            shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                            shot(ShotNumber).Shooter = RNN
                                            Select Case RobotBullets(RNN)
                                                Case 0
                                                    shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2  '/
                                                Case 2
                                                    shot(ShotNumber).ShotType = ExplosiveBullet
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case 20
                                                    RobotBullets(RNN) = 2
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case Else
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            End Select
                                        Else
                                            shot(FreeShot).ShotAngle = RAim(RNN)
                                            shot(FreeShot).ShotType = Bullet
                                            shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                            shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                            shot(FreeShot).Shooter = RNN
                                            Select Case RobotBullets(RNN)
                                                Case 0
                                                    shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2    '
                                                Case 2
                                                    shot(FreeShot).ShotType = ExplosiveBullet
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case 20
                                                    RobotBullets(RNN) = 2
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                Case Else
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            End Select
                                            FreeShot = -1
                                        End If
                                        HasMoved = 20
                                    Else
                                        ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                    End If
                                End If
                            Case insSHIELD 'ins
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then         'Prevent negative shield
                                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > 150 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 150 'Prevent shield over 150
                                        REnergy(RNN) = REnergy(RNN) + RShield(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Takes or energy restores energy to/from shield
                                        If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN)         'Prevent energy higher than Robots Energy Max
                                        RShield(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)                  'Sets shield
                                    End If
                            Case insSTUNNER 'ins
                                If RobotStunners(RNN) = 0 Then
                                    ErrorCode = BuggyStunners
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
                                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then      'Stunner don't use freeshots because of the (Stunstreamer - Freeshot) visual bug which is fixed so they do
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotAngle = RAim(RNN)
                                                shot(ShotNumber).ShotType = Stunner
                                                shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4     'Int((RobotStack(RNN, RobotStackPos(RNN) - 1)) / 4)
                                            Else
                                                shot(FreeShot).ShotAngle = RAim(RNN)
                                                shot(FreeShot).ShotType = Stunner
                                                shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insMOVEX 'ins
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                If HasMoved <> 20 Or MoveAndShotAllowed Then
                                    RobotLeft(RNN) = RobotLeft(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    'TurretX2(RNN) = TurretX2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    If RobotLeft(RNN) > 300 Then  'otherwise it can use MOVEX to jump outside the areana!!!
                                        RobotLeft(RNN) = 300
                                        'TurretX2(RNN) = 300 + TurretX2(RNN) - RobotLeft(RNN)
                                    ElseIf RobotLeft(RNN) < 0 Then
                                        RobotLeft(RNN) = 0
                                        'TurretX2(RNN) = TurretX2(RNN) - RobotLeft(RNN)
                                    End If
                                    HasMoved = 5
                                Else
                                    ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                End If
                            Case insMOVEY 'ins
                                REnergy(RNN) = REnergy(RNN) - 2 * Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                If HasMoved <> 20 Or MoveAndShotAllowed Then
                                    RobotTop(RNN) = RobotTop(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    'TurretY2(RNN) = TurretY2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    If RobotTop(RNN) > 300 Then 'otherwise it can use MOVEX to jump outside the areana!!!
                                        RobotTop(RNN) = 300
                                        'TurretY2(RNN) = 300 + TurretY2(RNN) - RobotTop(RNN)
                                    ElseIf RobotTop(RNN) < 0 Then
                                        RobotTop(RNN) = 0
                                        'TurretY2(RNN) = TurretY2(RNN) - RobotTop(RNN)
                                    End If
                                    HasMoved = 5
                                Else
                                    ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                End If
                            Case insHELLBORE 'ins
                                If RobotHellbores(RNN) = 0 Then
                                    ErrorCode = BuggyHellbores
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 3 And RobotStack(RNN, RobotStackPos(RNN) - 1) < 21 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotAngle = RAim(RNN)
                                                shot(ShotNumber).ShotType = Hellbore
                                                shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            Else
                                                shot(FreeShot).ShotAngle = RAim(RNN)
                                                shot(FreeShot).ShotType = Hellbore
                                                shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insA: RA(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insB: RB(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insC: RC(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insD: RD(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insE: RE(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insF: RF(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insG: RG(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insH: RH(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insI: RI(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insJ: RJ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insK: RK(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insL: RL(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insM: RM(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insN: RN(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insO: RO(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insP: RP(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insQ: RQ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insR: RR(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insS: RS(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case Inst: RT(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insU: RU(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insV: RV(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insZ: RZ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insW: RW(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insLOOK 'ins
                                RLook(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RLook(RNN) > 359 Then RLook(RNN) = RLook(RNN) Mod 360
                                If RLook(RNN) < 0 Then RLook(RNN) = RLook(RNN) Mod 360 + 360
                                If Inton(RNN) And RangeInst(RNN) >= 0 Then '**********Interuppskod************
                                'specialrange.. designed för look and aim instructions
                                    RRadar = RAim(RNN) + RLook(RNN)
                                    If 1 <> RNN Then   'Skip checking range to self. It'll be too short
                                        tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
                                        trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
                                        trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
                            
                                        If trigx * trigx + trigy * trigy <= 91 Then
                                            If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                                If RobotAlive(1) = 1 Then
                                                    If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
                                                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                        RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                        RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
                                                        Inton(RNN) = False
                                                        GoTo NoStackRemoval
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                    
                                    For shotcounter = 2 To NumberOfRobotsPresent
                                        If shotcounter <> RNN Then   'Skip checking range to self. It'll be too short
                                            tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
                                            trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
                                            trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
                                
                                            If trigx * trigx + trigy * trigy <= 91 Then
                                                If tempnumber <= RangeParam(RNN) Then    'intrange sends back 601 for no range instead of 0
                                                    If RobotAlive(shotcounter) = 1 Then
                                                        If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
                                                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                                            RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
                                                            Inton(RNN) = False
                                                            GoTo NoStackRemoval
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next shotcounter
                                '''''''''''
                                End If '**********Slut Interuppskod************'
                            Case insBULLET 'ins                                 'It seems like a robot can mess up it's explosive
                                If RobotBullets(RNN) = 2 Then RobotBullets(RNN) = 20      'bullets by firing negative shots. It's certainly
                                GoTo Robot1Fire                                 'not an adventage, so it' can't be considered cheating
                            Case insNUKE 'ins
                                If RobotTacNukes(RNN) = 0 Then
                                    ErrorCode = BuggyTacNukes
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotFireTime = Chronon
                                                shot(ShotNumber).ShotType = TakeNuke
                                                shot(ShotNumber).ShotX = RobotLeft(RNN)
                                                shot(ShotNumber).ShotY = RobotTop(RNN)
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotFireTime = Chronon
                                                shot(FreeShot).ShotType = TakeNuke
                                                shot(FreeShot).ShotX = RobotLeft(RNN)
                                                shot(FreeShot).ShotY = RobotTop(RNN)
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insMEGANUKE 'ins
                                If RobotTacNukes(RNN) = 0 Then
                                    ErrorCode = BuggyTacNukes
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotFireTime = Chronon
                                                shot(ShotNumber).ShotType = MegaNuke
                                                shot(ShotNumber).ShotX = RobotLeft(RNN)
                                                shot(ShotNumber).ShotY = RobotTop(RNN)
                                                shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotFireTime = Chronon
                                                shot(FreeShot).ShotType = MegaNuke
                                                shot(FreeShot).ShotX = RobotLeft(RNN)
                                                shot(FreeShot).ShotY = RobotTop(RNN)
                                                shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insMINE 'ins
                                If RobotMines(RNN) = 0 Then
                                    ErrorCode = BuggyMines
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) - 5 > 0 Then
                                        REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
                                        If HasMoved <> 5 Or MoveAndShotAllowed Then
                                            If FreeShot = -1 Then
                                                ShotNumber = ShotNumber + 1
                                                shot(ShotNumber).ShotFireTime = Chronon
                                                shot(ShotNumber).ShotType = Mine
                                                shot(ShotNumber).ShotX = RobotLeft(RNN)
                                                shot(ShotNumber).ShotY = RobotTop(RNN)
                                                shot(ShotNumber).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
                                                shot(ShotNumber).Shooter = RNN
                                            Else
                                                shot(FreeShot).ShotFireTime = Chronon
                                                shot(FreeShot).ShotType = Mine
                                                shot(FreeShot).ShotX = RobotLeft(RNN)
                                                shot(FreeShot).ShotY = RobotTop(RNN)
                                                shot(FreeShot).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
                                                shot(FreeShot).Shooter = RNN
                                                FreeShot = -1
                                            End If
                                            HasMoved = 20
                                        Else
                                            ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                        End If
                                    End If
                                End If
                            Case insLASER 'ins
                                If RobotLasers(RNN) = 0 Then
                                    ErrorCode = BuggyLasers
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then ' It is possible in the Mac version to shoot laser shots that actually doesn't do any harm
                                        If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then  'It seems to be possible to shoot laser at dead robots
                                            'If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                            If RobotAlive(RangedRobot(RNN)) = 1 Then
                                                If RobotStack(RNN, RobotStackPos(RNN) - 1) > REnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = REnergy(RNN)
                                                
                                                REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                                If HasMoved <> 5 Or MoveAndShotAllowed Then
                                                    TurretX2(RNN) = RobotLeft(RNN) + Sin10(RAim(RNN))  'Sets the turret x2 for the aim
                                                    TurretY2(RNN) = RobotTop(RNN) - Cos10(RAim(RNN))   'since it's used in non-displayed for laser

                                                    If FreeShot = -1 Then
                                                        ShotNumber = ShotNumber + 1
                                                        shot(ShotNumber).ShotType = Laser
                                                        shot(ShotNumber).ShotAngle = RangedRobot(RNN)
                                                        shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
                                                        shot(ShotNumber).Shooter = RNN
                                                        shot(ShotNumber).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN)    'Shows laser on radar instantly
                                                        shot(ShotNumber).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
                                                    Else
                                                        shot(FreeShot).ShotType = Laser
                                                        shot(FreeShot).ShotAngle = RangedRobot(RNN)
                                                        shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
                                                        shot(FreeShot).Shooter = RNN
                                                        shot(FreeShot).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN)    'Shows laser on radar instantly
                                                        shot(FreeShot).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
                                                        FreeShot = -1
                                                    End If
                                                    HasMoved = 20
                                                Else
                                                    ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Case insDRONE 'ins
                                If RobotDrones(RNN) = 0 Then
                                    ErrorCode = BuggyDrones
                                    GoTo Buggy
                                Else
                                    If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 And Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then    'Range <> 0
                                        If RobotAlive(RangedRobot(RNN)) = 1 Then  'Cuts down the shot power to the Robots energy max
                                            If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
                                            REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
                                            If HasMoved <> 5 Or MoveAndShotAllowed Then
                                                If FreeShot = -1 Then
                                                    ShotNumber = ShotNumber + 1
                                                    shot(ShotNumber).ShotAngle = RangedRobot(RNN)   'Shootangle represents tracking robot
                                                    shot(ShotNumber).ShotFireTime = Chronon + 100   'ShotFireTime represents the chronon the drone die
                                                    shot(ShotNumber).ShotType = Drone
                                                    shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                    shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                    shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
                                                    shot(ShotNumber).Shooter = RNN
                                                Else
                                                    shot(FreeShot).ShotAngle = RangedRobot(RNN)   'Shootangle represents tracking robot
                                                    shot(FreeShot).ShotFireTime = Chronon + 100   'ShotFireTime represents the chronon the drone die
                                                    shot(FreeShot).ShotType = Drone
                                                    shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
                                                    shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
                                                    shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
                                                    shot(FreeShot).Shooter = RNN
                                                    FreeShot = -1
                                                End If
                                                HasMoved = 20
                                            Else
                                                ShowMoveAndShootMessage RNN, ChrononExecutor1, RobotInstPos(RNN)
                                            End If
                                        End If
                                    End If
                                End If
                            Case insSCAN 'ins
                                RScan(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RScan(RNN) > 359 Then RScan(RNN) = RScan(RNN) Mod 360
                                If RScan(RNN) < 0 Then RScan(RNN) = RScan(RNN) Mod 360 + 360
                                If Inton(RNN) And RadarInst(RNN) >= 0 Then
                                    'RADAR
                                    RRadar = 0
                                    For shotcounter = 1 To ShotNumber
                                        If shot(shotcounter).ShotType < 200 Then
                                            'This is David Harris radar code, ported to Visual Basic by me.
                                            trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                                            trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                                            
                                            If trigx <> 0 Then   'atan2
                                                tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                                            Else
                                                tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                                            End If          '''''''
                                            
                                            If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                                            
                                            If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                                                RRange = FixSquare(trigx * trigx + trigy * trigy)
                                                If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                                            End If
                                        End If
                                    Next shotcounter
                                    '/RADAR
                                    If RRadar <> 0 Then
                                        If RRadar <= RadarParam(RNN) Then
                                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
                                            RobotInstPos(RNN) = RadarInst(RNN) - 1 ' - 1 nytt
                                            Inton(RNN) = False
                                            GoTo NoStackRemoval
                                        End If
                                    End If
                                End If
                            Case insHISTORY 'ins
                                If HistoryParam(RNN) >= 31 Then HistoryRec(RNN, HistoryParam(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSIGNAL
                                If RobotTeam(RNN) <> 0 Then
                                    RSignal(RobotTeam(RNN), RChannel(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
   
                                    For tempnumber = 1 To NumberOfRobotsPresent
                                        If RobotTeam(RNN) = RobotTeam(tempnumber) Then
                                            If tempnumber <> RNN Then
                                                If SignalInst(tempnumber) >= 0 Then
                                                    If SignalParam(tempnumber) = RChannel(RNN) Then
                                                        RobotQuePos(tempnumber) = RobotQuePos(tempnumber) + 1
                                                        RobotIntQue(tempnumber, RobotQuePos(tempnumber)) = SignalInst(tempnumber)
                                                        IntID(tempnumber, RobotQuePos(tempnumber)) = 11
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next tempnumber
                                End If
                            Case insCHANNEL
                                RChannel(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RChannel(RNN) > 10 Or RChannel(RNN) < 1 Then
                                    ErrorCode = BuggyChannel: GoTo Buggy
                                End If
                            Case Else
                                ErrorCode = BuggyStore
                                GoTo Buggy
                            End Select
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
NoStackRemoval:
                    Case insRECALL       'Removing the Reversed Recalls took exactly 3 hours and 29 minutes, including speed testing but
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyRecall: GoTo Buggy
                        End If
                        
                        Select Case RobotStack(RNN, RobotStackPos(RNN))     'excluding recompiling all robots
                            Case insRANGE 'ins
                                RRange = Range(RNN, RAim(RNN) + RLook(RNN))
                                If RRange <> 0 Then
                                    If RobotAlive(RangedRobot(RNN)) <> 1 Then RRange = 0
                                End If
                                RobotStack(RNN, RobotStackPos(RNN)) = RRange
                            Case insAIM 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RAim(RNN)
                            Case insX 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RobotLeft(RNN)
                            Case insY 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RobotTop(RNN)
                            Case insRADAR 'ins
                                'RADAR
                                RRadar = 0 'RRadar
                                For shotcounter = 1 To ShotNumber
                                    If shot(shotcounter).ShotType < 200 Then
                                        'This is David Harris radar code, ported to Visual Basic by me.
                                        trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX)  'This is to make sure that we cut floats like C does
                                        trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY)   'This is absolutely nessecary
                                        
                                        If trigx <> 0 Then   'atan2
                                            tempnumber = Abs(450 - TPI * Atn(trigy / -trigx) + 180 * (trigx >= 0) - RAim(RNN) - RScan(RNN))
                                        Else
                                            tempnumber = Abs(450 - 90 * Sgn(trigy) - RAim(RNN) - RScan(RNN))
                                        End If          '''''''
                                        
                                        If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
                                        
                                        If tempnumber < 20 Or tempnumber > 340 Then   '< 19  341 >        '24 och 336
                                            RRange = FixSquare(trigx * trigx + trigy * trigy)
                                            If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
                                        End If
                                    End If
                                Next shotcounter
                                '/RADAR
                                RobotStack(RNN, RobotStackPos(RNN)) = RRadar
                            Case insSPEEDX 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RSpeedx(RNN)
                            Case insSPEEDY 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RSpeedy(RNN)
                            Case insENERGY 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RNN)
                            Case insSHIELD 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RShield(RNN)
                            Case insLOOK 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RLook(RNN)
                            Case insDOPPLER 'ins
                                'Many Thanks to Sam Rushing who helped me out
                                'and explained how the Doppler routine worked.    'Dead robot are set to E = -10
                                
                                'Prfnoff's version - Robots with E -1 has doppler?
                                '4.5.2 - Robots med E -1 doesn't have doppler

                                If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'Med allra allra största sannolikhet skall jag använda RealStunned
                                    If REnergy(RangedRobot(RNN)) <= 0 Or RStunned(RangedRobot(RNN)) <> 0 Or RCollision(RangedRobot(RNN)) <> 0 Then    'RWall(RangedRobot(RNN)) <> 0 Or
                                        RobotStack(RNN, RobotStackPos(RNN)) = 0
                                    Else
                                        RRange = RobotLeft(RNN) - RobotLeft(RangedRobot(RNN))    'xdiff
                                        RRadar = RobotTop(RNN) - RobotTop(RangedRobot(RNN))      'ydiff
                                        'Ej testat om det skall vara round eller fix, kolla
                                        RobotStack(RNN, RobotStackPos(RNN)) = Round((RSpeedx(RangedRobot(RNN)) * RRadar - RRange * RSpeedy(RangedRobot(RNN))) / Square(RRadar * RRadar + RRange * RRange))  'Round
                                    End If
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                End If
                            Case insNEAREST
                                If RobotProSpeed(RNN) <= 10 Then
                                    If NumberOfRobotsPresent > 1 Then
                                        tempnumber = Nearest(RNN)
                                        If RobotAlive(tempnumber) = 1 Then
                                            If RobotTop(tempnumber) <> RobotTop(RNN) Then
                                                If RobotTop(RNN) > RobotTop(tempnumber) Then
                                                    RobotStack(RNN, RobotStackPos(RNN)) = (Round(TPI * Atn((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN))))) - RAim(RNN)
                                                Else
                                                    RobotStack(RNN, RobotStackPos(RNN)) = (Round(TPI * Atn((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN)))) + 180) - RAim(RNN)
                                                End If
                                            Else
                                                If RobotLeft(RNN) < RobotLeft(tempnumber) Then
                                                    RobotStack(RNN, RobotStackPos(RNN)) = 90 - RAim(RNN)
                                                Else
                                                    RobotStack(RNN, RobotStackPos(RNN)) = 270 - RAim(RNN)
                                                End If
                                            End If
                                            
                                            If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 360
                                        Else
                                            RobotStack(RNN, RobotStackPos(RNN)) = -1
                                        End If
                                    Else
                                        RobotStack(RNN, RobotStackPos(RNN)) = -1
                                    End If
                                Else
                                    ErrorCode = BuggyNearest
                                    GoTo Buggy
                                End If
                            Case insROBOTS 'ins
                                If HowManyLeft = 255 Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = 1
                                ElseIf R2Present Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = HowManyLeft
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 1
                                End If
                            Case insCHRONON 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = Chronon
                            Case insCOLLISION 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = Sgn(RCollision(RNN))
                            Case insA 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RA(RNN)
                            Case insB 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RB(RNN)
                            Case insC 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RC(RNN)
                            Case insD 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RD(RNN)
                            Case insE 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RE(RNN)
                            Case insF 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RF(RNN)
                            Case insG 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RG(RNN)
                            Case insH 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RH(RNN)
                            Case insI 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RI(RNN)
                            Case insJ 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RJ(RNN)
                            Case insK 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RK(RNN)
                            Case insL 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RL(RNN)
                            Case insM 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RM(RNN)
                            Case insN 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RN(RNN)
                            Case insO 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RO(RNN)
                            Case insP 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RP(RNN)
                            Case insQ 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RQ(RNN)
                            Case insR 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RR(RNN)
                            Case insS 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RS(RNN)
                            Case Inst 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RT(RNN)
                            Case insU 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RU(RNN)
                            Case insV 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RV(RNN)
                            Case insZ 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RZ(RNN)
                            Case insW 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RW(RNN)
                            Case insPROBE 'ins
                                If RobotProbes(RNN) = 0 Then
                                    ErrorCode = BuggyProbes
                                    GoTo Buggy
                                Else
                                    If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then
                                        If RobotAlive(RangedRobot(RNN)) <> 1 Then
                                            RobotStack(RNN, RobotStackPos(RNN)) = 0
                                        Else
                                            Select Case ProbeSet(RNN)
                                                '0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
                                                '4 = Teammates - Currently disabled 'cause of no teams
                                                Case 1
                                                    RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RangedRobot(RNN))
                                                Case 0
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RangedRobot(RNN))
                                                Case 2
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RShield(RangedRobot(RNN))
                                                Case 7
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RScan(RangedRobot(RNN))
                                                Case 3
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RangedRobot(RNN) - 1 '0 to 5
                                                Case 5
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RAim(RangedRobot(RNN))
                                                Case 6
                                                    RobotStack(RNN, RobotStackPos(RNN)) = RLook(RangedRobot(RNN))
                                                Case 4
                                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                                    For tempnumber = 1 To NumberOfRobotsPresent
                                                        If tempnumber <> RangedRobot(RNN) Then
                                                            If RobotTeam(tempnumber) = RobotTeam(RangedRobot(RNN)) Then
                                                                If RobotAlive(tempnumber) = 1 Then
                                                                    RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
                                                                End If
                                                            End If
                                                        End If
                                                    Next tempnumber
                                            End Select
                                        End If
                                    Else
                                        RobotStack(RNN, RobotStackPos(RNN)) = 0
                                    End If
                                End If
                            Case insWALL 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RWall(RNN)
                            Case insDAMAGE 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RNN)
                            Case insRANDOM 'ins
                                If RunningTournament Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = Round((359 + 1) * Rnd)  'Int
                                Else
                                    If Replaying And NotRandomEmergency Then
                                        RobotStack(RNN, RobotStackPos(RNN)) = RandomRegister(RandomCounter)
                                    Else
                                        RobotStack(RNN, RobotStackPos(RNN)) = Round((359 + 1) * Rnd)  'Int
                                        ReDim Preserve RandomRegister(RandomCounter)
                                        RandomRegister(RandomCounter) = RobotStack(RNN, RobotStackPos(RNN))
                                    End If
                                    RandomCounter = RandomCounter + 1
                                End If
                            Case insSCAN 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RScan(RNN)
                            Case insID 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = RNN - 1 '0 to 5
                            Case insHISTORY 'ins     'If repeat battle is checked we should read from the backup rec, unless we're using user defined history, in case we should read from the regular rec, since regular rec 31-50 is reset at the end of a repeated battle
                                If Replaying And HistoryParam(RNN) < 31 Then RobotStack(RNN, RobotStackPos(RNN)) = BackupHistoryRec(RNN, HistoryParam(RNN)) Else RobotStack(RNN, RobotStackPos(RNN)) = HistoryRec(RNN, HistoryParam(RNN))
                            Case insKILLS 'ins
                                RobotStack(RNN, RobotStackPos(RNN)) = KR(RNN)
                           Case insSIGNAL
                                If RobotTeam(RNN) <> 0 Then
                                    RobotStack(RNN, RobotStackPos(RNN)) = RSignal(RobotTeam(RNN), RChannel(RNN))
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                End If
                            Case insFRIEND
                                If RCollision(RNN) <> 0 And RobotTeam(RNN) <> 0 Then
                                    If RobotTeam(RCollision(RNN)) = RobotTeam(RNN) Then RobotStack(RNN, RobotStackPos(RNN)) = 1 Else RobotStack(RNN, RobotStackPos(RNN)) = 0
                                Else
                                    RobotStack(RNN, RobotStackPos(RNN)) = 0
                                End If
                            Case insCHANNEL
                                RobotStack(RNN, RobotStackPos(RNN)) = RChannel(RNN)
                            Case insTEAMMATES
                                RobotStack(RNN, RobotStackPos(RNN)) = 0
                                For tempnumber = 1 To NumberOfRobotsPresent
                                    If tempnumber <> RNN Then
                                        If RobotTeam(tempnumber) = RobotTeam(RNN) Then
                                            If RobotAlive(tempnumber) = 1 Then
                                                RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
                                            End If
                                        End If
                                    End If
                                Next tempnumber
                            Case Else
                                ErrorCode = BuggyRecall '& RobotStack(RNN, RobotStackPos(RNN))
                                GoTo Buggy
                        End Select
                    Case insIF 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                        Else
                            tempnumber = RobotInstPos(RNN) + 1   'Tempnumber gav ingen hastighetsökning
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        End If
                    Case insMORE
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) >= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insJUMP 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                            RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                        Else
                            ErrorCode = BuggyDestination: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insIFG 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insPLUS
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + RobotStack(RNN, RobotStackPos(RNN) + 1)
                        If Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
                            ErrorCode = BuggyNumberOutofBounds: GoTo Buggy
                        End If
                    Case insLESS
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                    
                        If RobotStack(RNN, RobotStackPos(RNN)) <= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSYNC 'Rep'
                        Exit For
                    Case insDUP 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If

                        If RobotStackPos(RNN) > 99 Then
                            ErrorCode = BuggyOverflow: GoTo Buggy
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                    Case insSETINT 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If

                        If RobotStack(RNN, RobotStackPos(RNN) - 1) > 4999 Or RobotStack(RNN, RobotStackPos(RNN) - 1) < -1 Then
                            ErrorCode = BuggyDestination: GoTo Buggy
                        End If

                        Select Case RobotStack(RNN, RobotStackPos(RNN))
                            Case insRANGE ' 'Rep'
                                RangeInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insLEFT ' 'Rep'
                                LeftInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If LeftInst(RNN) = -1 Then          'BUG ALERT!! Detta klarar bara om första stacknumret är
                                    If RobotQuePos(RNN) <> 0 Then   'hett! Tillfällig lösning
                                        If IntID(RNN, RobotQuePos(RNN)) = 3 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insRIGHT ' 'Rep'
                                RightInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RightInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 4 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insTOP ' 'Rep'
                                TopInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If TopInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 1 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insBOT ' 'Rep'
                                BotInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If BotInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 2 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insWALL ' 'Rep'
                                WallInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If WallInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 7 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insCOLLISION ' 'Rep'
                                CollisionInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If CollisionInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 8 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insROBOTS ' 'Rep'
                                RobotsInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If RobotsInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 9 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insCHRONON ' 'Rep'
                                ChrononInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insRADAR ' 'Rep'
                                RadarInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insDAMAGE ' 'Rep'
                                DamageInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If DamageInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 6 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insSHIELD ' 'Rep'
                                ShieldInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If ShieldInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 5 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                Else    'Else är nytt - tidigare stod If Rshieled utanför if
                                    If RShield(RNN) < ShieldParam(RNN) Then ShieldInst(RNN) = ShieldInst(RNN) + 5000
                                End If
                            Case insTEAMMATES ' 'Rep'
                                TeammatesInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If TeammatesInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 10 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case insSIGNAL ' 'Rep'
                                SignalInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If SignalInst(RNN) = -1 Then
                                    If RobotQuePos(RNN) <> 0 Then
                                        If IntID(RNN, RobotQuePos(RNN)) = 11 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                                    End If
                                End If
                            Case Else
                                ErrorCode = BuggySetint
                                GoTo Buggy
                        End Select
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insRTI 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        Inton(RNN) = True
                        If RobotQuePos(RNN) <= 0 Then
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        Else
                            RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1    'qued ints subtracted when triggered             'jumps shall be done
                            Inton(RNN) = False
                            RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                        End If
                    Case insSETPARAM 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        Select Case RobotStack(RNN, RobotStackPos(RNN))
                            Case insRANGE ' 'Rep'
                                RangeParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insLEFT ' 'Rep'
                                LeftParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insRIGHT ' 'Rep'
                                RightParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insTOP ' 'Rep'
                                TopParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insBOT ' 'Rep'
                                BotParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insPROBE ' 'Rep'
                            '0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
                            '4 = Teammates - Currently disabled 'cause of no teams
                                Select Case RobotStack(RNN, RobotStackPos(RNN) - 1)
                                    Case insDAMAGE ' 'Rep'
                                        ProbeSet(RNN) = 0
                                    Case insENERGY ' 'Rep'
                                        ProbeSet(RNN) = 1
                                    Case insSHIELD ' 'Rep'
                                        ProbeSet(RNN) = 2
                                    Case insSCAN ' 'Rep'
                                        ProbeSet(RNN) = 7
                                    Case insID ' 'Rep'
                                        ProbeSet(RNN) = 3
                                    Case insAIM ' 'Rep'
                                        ProbeSet(RNN) = 5
                                    Case insLOOK ' 'Rep'
                                        ProbeSet(RNN) = 6
                                    Case insTEAMMATES ' 'Rep'
                                        ProbeSet(RNN) = 4
'                                    Case Else
'                                        ErrorCode =  'Rep'Illegal 'PROBE' register  'Rep' & RobotStack(RNN, RobotStackPos(RNN))
'                                        GoTo Buggy
                                End Select
                            Case insRADAR ' 'Rep'
                                RadarParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insCHRONON ' 'Rep'
                                ChrononParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insROBOTS ' 'Rep'
                                RobotsParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insDAMAGE ' 'Rep'
                                DamageParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                                If DamageParam(RNN) > RDamage(RNN) Then DamageParam(RNN) = RDamage(RNN)
                            Case insHISTORY ' 'Rep'
                                HistoryParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSHIELD ' 'Rep'
                                ShieldParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insTEAMMATES ' 'Rep'
                                TeammatesParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case insSIGNAL
                                SignalParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                            Case Else
                                ErrorCode = BuggySetparam
                                GoTo Buggy
                            End Select
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insCALL 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        tempnumber = RobotInstPos(RNN) + 1
                        If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                            RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                        Else
                            ErrorCode = BuggyDestination: GoTo Buggy
                        End If
                        RobotStack(RNN, RobotStackPos(RNN)) = tempnumber
                    Case insAND 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 Or RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insMINUS
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) - RobotStack(RNN, RobotStackPos(RNN) + 1)
                        If Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
                            ErrorCode = BuggyNumberOutofBounds: GoTo Buggy
                        End If
                    Case insINTON 'Rep'
                        Inton(RNN) = True
                        If RobotQuePos(RNN) > 0 Then
                            If RobotStackPos(RNN) > 99 Then
                                ErrorCode = BuggyOverflow: GoTo Buggy
                            End If
                            RobotStackPos(RNN) = RobotStackPos(RNN) + 1
                            RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
                            RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1    'qued ints subtracted when triggered             'jumps shall be done
                            Inton(RNN) = False
                            RobotQuePos(RNN) = RobotQuePos(RNN) - 1
                        End If
                    Case insDIVISION
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
                            ErrorCode = BuggyDivision: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) \ RobotStack(RNN, RobotStackPos(RNN) + 1)
                    Case insTIMES
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) * RobotStack(RNN, RobotStackPos(RNN) + 1)
                        If Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
                            ErrorCode = BuggyNumberOutofBounds: GoTo Buggy
                        End If
                    Case insSAME
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insBEEP 'Rep' 'Represents all icon snd instructions, debug, print and beep  for undisplayed
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case insARCTAN 'Rep'                                       'Shall not use Fix!!
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = Round(TPI * Atn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)) + 90 - (90 * (Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1)) - 1)))
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * Sgn(RobotStack(RNN, RobotStackPos(RNN))) * (Sgn(RobotStack(RNN, RobotStackPos(RNN))) + 1)
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insDROPALL 'Rep'
                        RobotStackPos(RNN) = 0
                    Case insNOT 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
                            RobotStack(RNN, RobotStackPos(RNN)) = 1
                        Else
                            RobotStack(RNN, RobotStackPos(RNN)) = 0     'Nej, dethär går inte att förenkla
                        End If
                    Case insDROP 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSWAP 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        tempnumber = RobotStack(RNN, RobotStackPos(RNN))
                        RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
                    Case insIFEG 'Rep'
                        If RobotStackPos(RNN) < 3 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                        Else
                            If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 3
                    Case insVRECALL 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) < 0 Or RobotStack(RNN, RobotStackPos(RNN)) > 100 Then
                            RobotStack(RNN, RobotStackPos(RNN)) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN)) = RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN)))
                        End If
                    Case insMOD 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN) - 1) Mod RobotStack(RNN, RobotStackPos(RNN))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insOR 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = 0 And RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insIFE 'Rep'
                        If RobotStackPos(RNN) < 3 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
                            tempnumber = RobotInstPos(RNN) + 1
                            If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                        Else
                            tempnumber = RobotInstPos(RNN) + 1       'Samma sak här, det borde funka med tempnumber
                            If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
                                RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
                            Else
                                ErrorCode = BuggyDestination: GoTo Buggy
                            End If
                            RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
                            RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                        End If
                    Case insMAX 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) > RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSIN 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * Sin(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insCOS 'Rep'              'Fix avrundar exact som Mac RoboWar!!
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * Cos(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insINTOFF 'Rep'
                        Inton(RNN) = False
                    Case insVSTORE 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) >= 0 And RobotStack(RNN, RobotStackPos(RNN)) <= 100 Then
                            RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN))) = RobotStack(RNN, RobotStackPos(RNN) - 1)
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 2
                    Case insCHS 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN)) = -RobotStack(RNN, RobotStackPos(RNN)) '* -1
                    Case insABS 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN)) = Abs(RobotStack(RNN, RobotStackPos(RNN)))
                    Case insTAN '       BUG ALERT!! Hur är det med 90 + de nya optimeringarna?
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        TDouble = Fix(RobotStack(RNN, RobotStackPos(RNN)) * Tan((90 - RobotStack(RNN, RobotStackPos(RNN) - 1)) * PIO))
                        If Abs(TDouble) > 19999 Then TDouble = 19999 * Sgn(TDouble)
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                        RobotStack(RNN, RobotStackPos(RNN)) = TDouble
                    Case insNOT_SAME 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insROLL 'Rep'
                        If RobotStackPos(RNN) < RobotStack(RNN, RobotStackPos(RNN)) + 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        tempnumber = RobotStack(RNN, RobotStackPos(RNN) - 1)     'Stores the number to roll back in tempstack
                        For shotcounter = RobotStackPos(RNN) - 1 To RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) Step -1 'decides what stack numbers moving up
                            RobotStack(RNN, shotcounter) = RobotStack(RNN, shotcounter - 1)       'adjust stack numbers affected by roll
                        Next shotcounter
                        RobotStack(RNN, RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) - 1) = tempnumber   'Do the roll
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1 'Adjusts stack number because top operand has been removed
                    Case insMIN 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) < RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insNOP 'Rep'
                    Case insDIST 'Rep'     'Totally useless, it can be precalculated!
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(Sqr(RobotStack(RNN, RobotStackPos(RNN)) ^ 2 + RobotStack(RNN, RobotStackPos(RNN) - 1) ^ 2))
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insFLUSHINT 'Rep'
                        RobotQuePos(RNN) = 0
                    Case insXOR 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If (RobotStack(RNN, RobotStackPos(RNN)) <> 0) Xor (RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insARCSIN 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Asn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * Sgn(RobotStack(RNN, RobotStackPos(RNN))) * Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1))
                        End If
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insARCCOS 'Rep'
                        If RobotStackPos(RNN) < 2 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Acn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
                        Else
                            RobotStack(RNN, RobotStackPos(RNN) - 1) = -180 * (Sgn(RobotStack(RNN, RobotStackPos(RNN))) <> Sgn(RobotStack(RNN, RobotStackPos(RNN) - 1)))
                        End If
                        
                        RobotStackPos(RNN) = RobotStackPos(RNN) - 1
                    Case insSQRT 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then
                            ErrorCode = BuggySquare: GoTo Buggy
                        End If
                        
                        RobotStack(RNN, RobotStackPos(RNN)) = FixSquare(RobotStack(RNN, RobotStackPos(RNN)))
                    Case insPRINT 'Rep'
                        If RobotStackPos(RNN) < 1 Then
                            ErrorCode = BuggyUnderflow: GoTo Buggy
                        End If
                        
                        If Not RunningTournament Then
                            tempnumber = MsgBox(RobotStack(RNN, RobotStackPos(RNN)) & vbCr & vbCr & "Would you like to stop the Battle?", vbYesNo + vbDefaultButton2, "Print " & GetRobot(RNN))
                            If tempnumber = vbYes Then GoTo Peace
                        End If
                        ChrononExecutor1 = ChrononExecutor1 - 1
                    Case Else
CodeError1:
                        ErrorCode = Err
Buggy:
                        If RunningTournament Then
                            tempnumber = vbNo
                        ElseIf ErrorCode <= -200 Then
                            tempnumber = ShowErrorMessageParam(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), RobotStack(RNN, RobotStackPos(RNN)))
                        Else
                            tempnumber = ShowErrorMessage(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), MachineCode(RNN, RobotInstPos(RNN)))                   'Response
                        End If

                        RobotAlive(RNN) = 255
                        RScan(RNN) = 9999  'nytt
                        If tempnumber = vbCancel Then GoTo Peace
                        If tempnumber = vbYes Then
                            SelectedRobot = RNN
                            DraftingBoard.GotoInstNr = RobotInstPos(RNN) + 1
                            DraftingBoard.Show 1, MainWindow
                            EndBattleWhenGotoInst
                            Exit Sub
                        End If
                        If Err = 0 Then Exit For Else Resume BackFromError
                    End Select
            Next ChrononExecutor1
        End If  'Stunned if
    End If      'energyif
End If         'RobotAlive(RNN) if

BackFromError:
If HighestToLowest Then RNN = 1 + NumberOfRobotsPresent - RNN   'Turns off backwards evaluation if it's enabled
Next RNN 'Nästa robot loopen


If RStunned(1) > 0 Then RStunned(1) = RStunned(1) - 1
For RNN = 2 To NumberOfRobotsPresent
    If RStunned(RNN) > 0 Then RStunned(RNN) = RStunned(RNN) - 1
Next RNN

' Avläsningen av koden ALLMÄNT(SLUTET)

'Shot Manager

NotAnyShotsAtAll = True

For shotcounter = 1 To ShotNumber
'errorcode = "ShotCounter = " & ShotCounter & Chr(10) & "ShotNumber = " & ShotNumber & Chr(10) & Chr(10) & "FireTime = " & Shot(ShotCounter).ShotFireTime & Chr(10) & "X = " & Shot(ShotCounter).ShotX & Chr(10) & "Y = " & Shot(ShotCounter).ShotY & Chr(10) & "Damage = " & Shot(ShotCounter).ShotPower & Chr(10) & Chr(10) & "FreeShot = " & FreeShot
'Response = MsgBox(errorcode, vbOKCancel, "Debug")
'If Response = vbCancel Then GoTo Peace

'Fillstyle är som standard = 0. Om det måste ändras måste den sättas tillbaka sen

Select Case shot(shotcounter).ShotType
    Case 200
        FreeShot = shotcounter
    'Disables some redims. Might speed up?

    Case Missile
        NotAnyShotsAtAll = False
        shot(shotcounter).ShotX = shot(shotcounter).ShotX + Sin5(shot(shotcounter).ShotAngle)
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - Cos5(shot(shotcounter).ShotAngle)

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then    'BUG ALERT!!! Skall syncas!!!
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 1     'Which robot is hit?
                LastHiter(1) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 2     'Which robot is hit?
                LastHiter(2) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 3     'Which robot is hit?
                LastHiter(3) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 4     'Which robot is hit?
                LastHiter(4) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 5     'Which robot is hit?
                LastHiter(5) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 6     'Which robot is hit?
                LastHiter(6) = shot(shotcounter).Shooter
            End If
        End If

    Case Hellbore
        NotAnyShotsAtAll = False
        trigx = shot(shotcounter).ShotPower * Sine(shot(shotcounter).ShotAngle)
        trigy = shot(shotcounter).ShotPower * Cosine(shot(shotcounter).ShotAngle)

        shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy

        trigx = shot(shotcounter).ShotX - trigx / 2
        trigy = shot(shotcounter).ShotY + trigy / 2

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then      'HELLBORE!!!
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or _
             (trigx - RobotLeft(1)) * (trigx - RobotLeft(1)) + (trigy - RobotTop(1)) * (trigy - RobotTop(1)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 1000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or _
             (trigx - RobotLeft(2)) * (trigx - RobotLeft(2)) + (trigy - RobotTop(2)) * (trigy - RobotTop(2)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 2000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or _
             (trigx - RobotLeft(3)) * (trigx - RobotLeft(3)) + (trigy - RobotTop(3)) * (trigy - RobotTop(3)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 3000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or _
             (trigx - RobotLeft(4)) * (trigx - RobotLeft(4)) + (trigy - RobotTop(4)) * (trigy - RobotTop(4)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 4000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or _
             (trigx - RobotLeft(5)) * (trigx - RobotLeft(5)) + (trigy - RobotTop(5)) * (trigy - RobotTop(5)) < 100 Then
              shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 5000     'Which robot is hit? *1000 for hellbore
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or _
             (trigx - RobotLeft(6)) * (trigx - RobotLeft(6)) + (trigy - RobotTop(6)) * (trigy - RobotTop(6)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 6000     'Which robot is hit? *1000 for hellbore
            End If      'HELLBORE!!!
        End If

    Case Stunner
        NotAnyShotsAtAll = False
        trigx = Sin14(shot(shotcounter).ShotAngle)
        trigy = Cos14(shot(shotcounter).ShotAngle)

        shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy

        trigx = shot(shotcounter).ShotX - trigx
        trigy = trigy + shot(shotcounter).ShotY

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then      'STUNNER!!!
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 100     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 200     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 300     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 400     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 500     'Which robot is hit? *100 for stunners
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 51 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 600     'Which robot is hit? *100 for stunners
            End If      'STUNNER!!!
        End If

    Case XplosiveBulletDetonation
ExplosiveBullets:
        NotAnyShotsAtAll = False
        If Chronon - shot(shotcounter).ShotFireTime >= 4 Then '10
            shot(shotcounter).ShotType = NOSHOT

            For RNN = 1 To NumberOfRobotsPresent
                If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 2025 Then     '45*45?????
                    RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN))): RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
                    LastHiter(RNN) = shot(shotcounter).Shooter
                End If
            Next RNN
            
            If DroneShotDown Then
                For RNN = 1 To ShotNumber
                    If shot(RNN).ShotType = Drone Then
                        If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 2025 Then shot(RNN).ShotType = NOSHOT
                    End If
                Next RNN
            End If
        End If
    
    Case TakeNuke
'OldStyleExplosiveBullets:
        NotAnyShotsAtAll = False

        If Chronon - shot(shotcounter).ShotFireTime >= 10 Then '10
            shot(shotcounter).ShotType = NOSHOT

            For RNN = 1 To NumberOfRobotsPresent    '1020
                If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
                    RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN))): RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
                    LastHiter(RNN) = shot(shotcounter).Shooter
                End If
            Next RNN
            
            If DroneShotDown Then
                For RNN = 1 To ShotNumber
                    If shot(RNN).ShotType = Drone Then
                        If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then shot(RNN).ShotType = NOSHOT
                    End If
                Next RNN
            End If
        End If

    Case MegaNuke
'OldStyleExplosiveBullets:
        NotAnyShotsAtAll = False

        If Chronon - shot(shotcounter).ShotFireTime >= MegaNukeBLASTRADIUS Then '10
            shot(shotcounter).ShotType = NOSHOT

            For RNN = 1 To NumberOfRobotsPresent    '1020
                If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
                    RDamage(RNN) = Min(RDamage(RNN), (RDamage(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower + RShield(RNN))): RShield(RNN) = ZeroOrMore(RShield(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower)
                    LastHiter(RNN) = shot(shotcounter).Shooter
                End If
            Next RNN
            
            If DroneShotDown Then
                For RNN = 1 To ShotNumber
                    If shot(RNN).ShotType = Drone Then
                        If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then shot(RNN).ShotType = NOSHOT
                    End If
                Next RNN
            End If
        End If

    Case Mine       'Minor skall ge damage 1 chronon efter
        NotAnyShotsAtAll = False

        If Chronon - shot(shotcounter).ShotFireTime >= 10 Then
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 1     'Which robot is hit?
                LastHiter(1) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 2     'Which robot is hit?
                LastHiter(2) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 3     'Which robot is hit?
                LastHiter(3) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 4     'Which robot is hit?
                LastHiter(4) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 5     'Which robot is hit?
                LastHiter(5) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then
                shot(shotcounter).ShotType = SHOTHIT    'Make the shot into a hit
                shot(shotcounter).ShotAngle = 6     'Which robot is hit?
                LastHiter(6) = shot(shotcounter).Shooter
            End If
        End If

    Case Drone
        NotAnyShotsAtAll = False

        If RobotAlive(shot(shotcounter).ShotAngle) = 1 And Chronon <= shot(shotcounter).ShotFireTime Then
'Checks drone shotdown
            For tempnumber = 0 To ShotNumber        'This is still extremly buggy
                'If Shot(TempNumber).ShotType = Missile Or Shot(TempNumber).ShotType = Hellbore Or Shot(TempNumber).ShotType = Bullet Or Shot(TempNumber).ShotType = ExplosiveBullet Then
                If shot(tempnumber).ShotType < 4 Then
                    If (shot(tempnumber).ShotX - shot(shotcounter).ShotX) * (shot(tempnumber).ShotX - shot(shotcounter).ShotX) + (shot(tempnumber).ShotY - shot(shotcounter).ShotY) * (shot(tempnumber).ShotY - shot(shotcounter).ShotY) < 50 Then
                        shot(tempnumber).ShotType = NOSHOT
                        shot(shotcounter).ShotType = NOSHOT
                        'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
                        GoTo dontrundronecode
                    End If
                End If
            Next tempnumber
''***************************'Nytt försök med drones     'Succé!! Yay!!
'            'moves te drone towards the tracking robot moves and paints the drone
            'LÄGG TILL IIF, DET KANSKE GÅR SNABBARE
            If Abs(shot(shotcounter).ShotY - RobotTop(shot(shotcounter).ShotAngle)) <= 8 Then   '2 '8
                If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2
                Else
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2
                End If
            ElseIf Abs(shot(shotcounter).ShotX - RobotLeft(shot(shotcounter).ShotAngle)) <= 8 Then '2 '8
                If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2
                Else
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2
                End If
            Else
                If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2 '1.41421356237 '2*cos 45 = 2*sin 45 = 1.41421356237
                Else
                    shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2 '1.41421356237
                End If
                If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2 '1.41421356237
                Else
                    shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2 '1.41421356237
                End If
            End If
''            end paint and move
'Checks hit
            For tempnumber = 1 To NumberOfRobotsPresent     'Undre raden fungerar men är insparad pga 64 K
                If (shot(shotcounter).ShotX - RobotLeft(tempnumber)) * (shot(shotcounter).ShotX - RobotLeft(tempnumber)) + (shot(shotcounter).ShotY - RobotTop(tempnumber)) * (shot(shotcounter).ShotY - RobotTop(tempnumber)) < 100 Then
                    shot(shotcounter).ShotType = SHOTHIT
                    shot(shotcounter).ShotAngle = tempnumber     'Which robot is hit?
                    'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
                    LastHiter(tempnumber) = shot(shotcounter).Shooter
                End If
            Next tempnumber
        Else
            shot(shotcounter).ShotType = NOSHOT    'destroy drone
        End If
dontrundronecode:
    Case Laser
        NotAnyShotsAtAll = False
        shot(shotcounter).ShotType = SHOTHIT
        LastHiter(shot(shotcounter).ShotAngle) = shot(shotcounter).Shooter

    Case SHOTHIT    'ShotHit
        If shot(shotcounter).ShotAngle < 100 Then    'Regular
            RShield(shot(shotcounter).ShotAngle) = RShield(shot(shotcounter).ShotAngle) - shot(shotcounter).ShotPower
            If RShield(shot(shotcounter).ShotAngle) < 0 Then 'If Shield still is above 0 the shot only hit the shield
                RDamage(shot(shotcounter).ShotAngle) = RDamage(shot(shotcounter).ShotAngle) + RShield(shot(shotcounter).ShotAngle)
                RShield(shot(shotcounter).ShotAngle) = 0
            End If
        ElseIf shot(shotcounter).ShotAngle < 1000 Then   'Stunner
            RStunned(shot(shotcounter).ShotAngle \ 100) = RStunned(shot(shotcounter).ShotAngle \ 100) + shot(shotcounter).ShotPower
        Else    'Hellbore
            RShield(shot(shotcounter).ShotAngle \ 1000) = 0
        End If
        shot(shotcounter).ShotType = NOSHOT

    Case Else
        NotAnyShotsAtAll = False
        trigx = Sin12(shot(shotcounter).ShotAngle)
        trigy = Cos12(shot(shotcounter).ShotAngle)

        shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
        shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy

        trigy = trigy + shot(shotcounter).ShotY
        trigx = shot(shotcounter).ShotX - trigx

        If shot(shotcounter).ShotX < 0 Or _
            shot(shotcounter).ShotX > 300 Or _
            shot(shotcounter).ShotY < 0 Or _
            shot(shotcounter).ShotY > 300 Then
            shot(shotcounter).ShotType = NOSHOT
        Else
            If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or _
            (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then

                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
'                    Shot(ShotCounter).ShotType = TakeNuke      'Old fashion Explosive Bullets
'                    GoTo OldStyleExplosiveBullets                      'Do not erase
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If

                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 1     'Which robot is hit?
                LastHiter(1) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then
                
                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If
                
                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 2     'Which robot is hit?
                LastHiter(2) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then

                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If

                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 3     'Which robot is hit?
                LastHiter(3) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then

                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If

                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 4     'Which robot is hit?
                LastHiter(4) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then

                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If

                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 5     'Which robot is hit?
                LastHiter(5) = shot(shotcounter).Shooter
            ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or _
                    (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then

                If shot(shotcounter).ShotType = ExplosiveBullet Then
                    If (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
                        shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle): shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
                    End If
                    shot(shotcounter).ShotFireTime = Chronon
                    shot(shotcounter).ShotType = XplosiveBulletDetonation
                    GoTo ExplosiveBullets
                End If

                shot(shotcounter).ShotType = SHOTHIT
                shot(shotcounter).ShotAngle = 6     'Which robot is hit?
                LastHiter(6) = shot(shotcounter).Shooter
            End If
        End If
End Select

Next shotcounter

If NotAnyShotsAtAll Then
    ShotNumber = 0
    FreeShot = -1
End If
   
 
    If RobotAlive(1) = 1 Then
        If RDamage(1) <= 0 Then           'Checks if the robots have any damage left.
RunDeath1:
            RobotAlive(1) = 0           'If the robot just died we set RobotAlive to 255 (means it died this chronon).
            RobotLeft(1) = -50
            RobotTop(1) = 150
            EnergyDisplay(1).Visible = False
    
            If REnergy(1) < -200 And EnableOverloading Then    'BUG ALERT!! BUG ALERT!! Skillnad i overloading mot den jävla Mac versionen: dels så sker skälva "döden" 1 chronon senare i
                RobotDead(1) = "Overloaded - Time: " & Chronon
                tempnumber = -2 '3 * CInt(Not StandardScoring)
                LastHiter(1) = 253
            ElseIf RScan(1) = 9999 Then
                RobotDead(1) = "Buggy - Time: " & Chronon
                tempnumber = -1 '2 * CInt(Not StandardScoring)
                LastHiter(1) = 254
            Else
                RobotDead(1) = "Dead - Time: " & Chronon              'Windows (vet inte om det har nån betydelse?), dels så slutar striden inte mindre än 2 chronon senare senare i Windows (om Mac scoring används)
                If (RCollision(1) = 0 Or RDamage(1) + 1 <= 0) And (RWall(1) = 0 Or RDamage(1) + 5 <= 0) And LastHiter(1) <> 1 And RLook(LastHiter(1)) <> 9999 And (RobotTeam(1) = 0 Or (RobotTeam(1) <> RobotTeam(LastHiter(1)))) Then
                    KR(LastHiter(1)) = KR(LastHiter(1)) + 1 'Also prevents robots from getting kill score for killing itself
                Else
                    LastHiter(1) = 255     'Records that the robot died from a Wall Collision, Collision or suicided (for 4.5.2)
                End If
                tempnumber = 0 'CInt(Not StandardScoring)
            End If
            
            If Not RunningTournament Then
            RobotDead(1).Visible = True
            DoEvents               'For the Nextevents optimization
            End If
            
            HowManyLeft = HowManyLeft - 1
            
            'Robots Int
            For shotcounter = 1 To NumberOfRobotsPresent
                If RobotsInst(shotcounter) >= 0 And HowManyLeft < RobotsParam(shotcounter) Then
                     RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
                     RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = RobotsInst(shotcounter)
                     IntID(shotcounter, RobotQuePos(shotcounter)) = 9
                End If
            Next shotcounter
    
            'Teammates Int
            RRadar = 0                                       'Calculates how many teammates there is left
            For shotcounter = 1 To NumberOfRobotsPresent    'If a robot is in the same team that the robot who just died + it's alive it's a living teammate
                If RobotTeam(shotcounter) = RobotTeam(1) And RobotAlive(shotcounter) = 1 Then RRadar = RRadar + 1
            Next shotcounter
    
            For shotcounter = 1 To NumberOfRobotsPresent
                If RobotTeam(shotcounter) = RobotTeam(1) Then     'If they're not in the same team we can ignore the teammates int
                    If TeammatesInst(shotcounter) >= 0 Then         'If it uses the teammates inst
                        If RRadar < TeammatesParam(shotcounter) Then    'If the teammates in the team no is below teammatesparam
                            RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
                            RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = TeammatesInst(shotcounter)
                            IntID(shotcounter, RobotQuePos(shotcounter)) = 10
                        End If
                    End If
                End If
            Next shotcounter
            
            If RRadar = 0 Then HowManyLeft = 0
            
            'End Team Stuff

            If HowManyLeft <= 1 Then        'If there's one or less than one robot left the battle should be stopped
                MaxChronon = Chronon + 20 + tempnumber * CInt(Not StandardScoring)
                HowManyLeft = 255           'If the solitare robot should die we prevent the battle from going on an additional 20 chronons this way
            End If
            
            REnergy(1) = -10    'To prevent false dopplering
        End If
    ElseIf RobotAlive(1) = 255 Then
        GoTo RunDeath1
    End If
    
    RCollision(1) = 0  'Resets collision to zero before the collision loop

                                        '*DEATH. This is the loop that checks for Robots death, and handles kill scoring.
For RNN = 2 To NumberOfRobotsPresent    'To increase battle speed, it's a lot different than the one displayed battle is using.
    If RobotAlive(RNN) = 1 Then
        If RDamage(RNN) <= 0 Then           'Checks if the robots have any damage left.
RunDeath:
            RobotAlive(RNN) = 0           'If the robot just died we set RobotAlive to 255 (means it died this chronon).
            RobotLeft(RNN) = -50
            RobotTop(RNN) = 150
            EnergyDisplay(RNN).Visible = False
    
            If REnergy(RNN) < -200 And EnableOverloading Then    'BUG ALERT!! BUG ALERT!! Skillnad i overloading mot den jävla Mac versionen: dels så sker skälva "döden" 1 chronon senare i
                RobotDead(RNN) = "Overloaded - Time: " & Chronon
                tempnumber = -2 '3 * CInt(Not StandardScoring)
                LastHiter(RNN) = 253
            ElseIf RScan(RNN) = 9999 Then
                RobotDead(RNN) = "Buggy - Time: " & Chronon
                tempnumber = -1 '2 * CInt(Not StandardScoring)
                LastHiter(RNN) = 254
            Else
                RobotDead(RNN) = "Dead - Time: " & Chronon              'Windows (vet inte om det har nån betydelse?), dels så slutar striden inte mindre än 2 chronon senare senare i Windows (om Mac scoring används)
                If (RCollision(RNN) = 0 Or RDamage(RNN) + 1 <= 0) And (RWall(RNN) = 0 Or RDamage(RNN) + 5 <= 0) And LastHiter(RNN) <> RNN And RLook(LastHiter(RNN)) <> 9999 And (RobotTeam(RNN) = 0 Or (RobotTeam(RNN) <> RobotTeam(LastHiter(RNN)))) Then
                    KR(LastHiter(RNN)) = KR(LastHiter(RNN)) + 1 'Also prevents robots from getting kill score for killing itself
                Else
                    LastHiter(RNN) = 255     'Records that the robot died from a Wall Collision, Collision or suicided (for 4.5.2)
                End If
                tempnumber = 0 'CInt(Not StandardScoring)
            End If
            
            If Not RunningTournament Then
                RobotDead(RNN).Visible = True
                DoEvents       'For the Nextevents optimization
            End If
            
            HowManyLeft = HowManyLeft - 1
            
            'Robots Int
            For shotcounter = 1 To NumberOfRobotsPresent
                If RobotsInst(shotcounter) >= 0 And HowManyLeft < RobotsParam(shotcounter) Then
                     RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
                     RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = RobotsInst(shotcounter)
                     IntID(shotcounter, RobotQuePos(shotcounter)) = 9
                End If
            Next shotcounter
    
            'Teammates Int
            RRadar = 0                                       'Calculates how many teammates there is left
            For shotcounter = 1 To NumberOfRobotsPresent    'If a robot is in the same team that the robot who just died + it's alive it's a living teammate
                If RobotTeam(shotcounter) = RobotTeam(RNN) And RobotAlive(shotcounter) = 1 Then RRadar = RRadar + 1
            Next shotcounter
    
            For shotcounter = 1 To NumberOfRobotsPresent
                If RobotTeam(shotcounter) = RobotTeam(RNN) Then     'If they're not in the same team we can ignore the teammates int
                    If TeammatesInst(shotcounter) >= 0 Then         'If it uses the teammates inst
                        If RRadar < TeammatesParam(shotcounter) Then    'If the teammates in the team no is below teammatesparam
                            RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
                            RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = TeammatesInst(shotcounter)
                            IntID(shotcounter, RobotQuePos(shotcounter)) = 10
                        End If
                    End If
                End If
            Next shotcounter
            
            If RRadar = 0 Then HowManyLeft = 0
            
            'End Team Stuff

            If HowManyLeft <= 1 Then        'If there's one or less than one robot left the battle should be stopped
                MaxChronon = Chronon + 20 + tempnumber * CInt(Not StandardScoring)
                HowManyLeft = 255           'If the solitare robot should die we prevent the battle from going on an additional 20 chronons this way
            End If
            
            REnergy(RNN) = -10    'To prevent false dopplering
        End If
    ElseIf RobotAlive(RNN) = 255 Then
        GoTo RunDeath
    End If
    
    RCollision(RNN) = 0  'Resets collision to zero before the collision loop
Next RNN

    If Chronon = NextEvents Then                           'For the Nextevents optimization
        NextEvents = NextEvents + 167                      'Just remove comments to enable
'**************************doevent2**************************
      If PeekMessage(Message, 0, 0, 0, PM_NOREMOVE) Then      'checks for a message in the queue
         DoEvents                                             'dispatches any messages in the queue
      End If
'************************************************************
    End If
    Chronon = Chronon + 1
Loop

StartTime = Timer - StartTime
If StartTime >= 1 Then      'We must have av least 1 sec of measuring otherwise the
    StartTime = Chronon / StartTime     'measuring will be very inaccurate
    CPRLabel = Format(StartTime, "#")
End If
'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*
' Striden avslutas
Peace:
    For RNN = 1 To NumberOfRobotsPresent    'Just so ER should correspond to energydisplay
        If Not Replaying Then
            BackupHistory (RNN)
            HistoryRec(RNN, 9) = RDamage(RNN) * (RobotAlive(RNN) = 1)
        End If
    Next RNN

    KillPoints LastHiter, RobotAlive
    RewardPoints RobotAlive(1), RobotAlive(2), RobotAlive(3), RobotAlive(4), RobotAlive(5), RobotAlive(6)
    EndBattle
End Sub






Private Sub WelcomeWindowSwitchMenu_Click()
'Dim Val As Boolean
'Val = Not WelcomeWindowSwitchMenu.Checked
'
'WelcomeWindowSwitchMenu.Checked = Val

If WelcomeWindowSwitchMenu.Checked Then
    WelcomeWindowSwitchMenu.Checked = False
    Put 7, 7000, True   'Correct
    Unload WelcomeHelp
Else
    WelcomeWindowSwitchMenu.Checked = True
    Put 7, 7000, False   'Correct
    WelcomeHelp.Show
End If
End Sub
