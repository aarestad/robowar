VERSION 5.00
Begin VB.Form WelcomeHelp 
   BackColor       =   &H00C0C000&
   Caption         =   "Welcome Help"
   ClientHeight    =   6930
   ClientLeft      =   9855
   ClientTop       =   450
   ClientWidth     =   4125
   Icon            =   "WelcomeHelp.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   6930
   ScaleWidth      =   4125
   Begin VB.CommandButton Close 
      Caption         =   "Close, do not show again"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   240
      TabIndex        =   6
      Top             =   6240
      Width           =   1335
   End
   Begin VB.CommandButton Hide 
      Caption         =   "Hide, Minimize to Tray"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   2280
      TabIndex        =   5
      Top             =   6240
      Width           =   1575
   End
   Begin VB.Label HelpTextExtra 
      BackStyle       =   0  'Transparent
      Caption         =   "Remove robots from the Arena can be done by clicking the Robots name and select 'Close Robot' from the File menu (Ctrl-W)."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   1455
      Index           =   3
      Left            =   240
      TabIndex        =   2
      Top             =   3360
      Width           =   3615
   End
   Begin VB.Label HelpTextExtra 
      BackStyle       =   0  'Transparent
      Caption         =   "Click the buttons next to the Robots name to load another Robot."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   975
      Index           =   2
      Left            =   240
      TabIndex        =   1
      Top             =   2160
      Width           =   3735
   End
   Begin VB.Label HelpTextExtra 
      BackStyle       =   0  'Transparent
      Caption         =   "Click the Battle Button to watch the Robots fight."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   855
      Index           =   1
      Left            =   240
      TabIndex        =   0
      Top             =   1320
      Width           =   3495
   End
   Begin VB.Label HelpTextExtra 
      BackStyle       =   0  'Transparent
      Caption         =   "If you feel daring enough to create your own Robot, select new Robot from the file menu."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   1215
      Index           =   4
      Left            =   240
      TabIndex        =   4
      Top             =   5040
      Width           =   3615
   End
   Begin VB.Label HelpTextExtra 
      BackStyle       =   0  'Transparent
      Caption         =   "Thanks for downloading and trying out my game!"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   1215
      Index           =   0
      Left            =   240
      TabIndex        =   3
      Top             =   240
      Width           =   3495
   End
End
Attribute VB_Name = "WelcomeHelp"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

'Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
'MainWindow.SetFocus        'Äsch :/
'SendKeys
'End Sub

'Private Sub Form_Load()
'HelpText = "Welcome to RoboWar!" & vbCrLf & _
'"Thanks for downloading and trying out my game!" & vbCrLf & vbCrLf & _
'"Click the Battle Button to watch the Robots fight." & vbCrLf & vbCrLf & _
'"Click the buttons next to the Robots name to load another Robot." & vbCrLf & vbCrLf & _
'"Remove robots from the Arena can be done by clicking the Robots name and select 'Close Robot' from the File menu (Ctrl-W)." & vbCrLf & _
'"If you feel daring enough to create your own Robot, select new Robot from the file menu. "
'
'End Sub



Private Sub Close_Click()
MainWindow.WelcomeWindowSwitchMenu.Checked = False
Put 7, 7000, True
Unload Me
End Sub


Private Sub Form_Activate()     '?
Me.SetFocus
End Sub

Private Sub Hide_Click()
Me.WindowState = vbMinimized
MainWindow.SetFocus
End Sub
