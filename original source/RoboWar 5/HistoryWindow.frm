VERSION 5.00
Begin VB.Form HistoryWindow 
   BackColor       =   &H00F4F2EE&
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "History"
   ClientHeight    =   4515
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   8595
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   301
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   573
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton OKButton 
      BackColor       =   &H00DBC284&
      Cancel          =   -1  'True
      Caption         =   "Close"
      Default         =   -1  'True
      Height          =   375
      Left            =   7320
      MaskColor       =   &H00FFFFFF&
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   4080
      Width           =   1215
   End
   Begin VB.Label TotalKills6 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00404040&
      Height          =   255
      Left            =   4440
      TabIndex        =   43
      Top             =   3720
      Width           =   615
   End
   Begin VB.Label TotalKills5 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C00000&
      Height          =   255
      Left            =   4440
      TabIndex        =   42
      Top             =   3240
      Width           =   615
   End
   Begin VB.Label TotalKills4 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000080FF&
      Height          =   255
      Left            =   4440
      TabIndex        =   41
      Top             =   2760
      Width           =   615
   End
   Begin VB.Label TotalKills3 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   4440
      TabIndex        =   40
      Top             =   2280
      Width           =   615
   End
   Begin VB.Label TotalKills2 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C0C000&
      Height          =   255
      Left            =   4440
      TabIndex        =   39
      Top             =   1800
      Width           =   615
   End
   Begin VB.Label TotalKills1 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H0000C000&
      Height          =   255
      Left            =   4440
      TabIndex        =   38
      Top             =   1320
      Width           =   615
   End
   Begin VB.Label Kills6 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00404040&
      Height          =   255
      Left            =   2160
      TabIndex        =   37
      Top             =   3720
      Width           =   615
   End
   Begin VB.Label Kills5 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C00000&
      Height          =   255
      Left            =   2160
      TabIndex        =   36
      Top             =   3240
      Width           =   615
   End
   Begin VB.Label Kills4 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000080FF&
      Height          =   255
      Left            =   2160
      TabIndex        =   35
      Top             =   2760
      Width           =   615
   End
   Begin VB.Label Kills3 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   2160
      TabIndex        =   34
      Top             =   2280
      Width           =   615
   End
   Begin VB.Label Kills2 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C0C000&
      Height          =   255
      Left            =   2160
      TabIndex        =   33
      Top             =   1800
      Width           =   615
   End
   Begin VB.Label Kills1 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H0000C000&
      Height          =   255
      Left            =   2160
      TabIndex        =   32
      Top             =   1320
      Width           =   615
   End
   Begin VB.Image Image6 
      Height          =   480
      Left            =   120
      Top             =   3600
      Width           =   480
   End
   Begin VB.Image Image5 
      Height          =   480
      Left            =   120
      Top             =   3120
      Width           =   480
   End
   Begin VB.Image Image4 
      Height          =   480
      Left            =   120
      Top             =   2640
      Width           =   480
   End
   Begin VB.Image Image3 
      Height          =   480
      Left            =   120
      Top             =   2160
      Width           =   480
   End
   Begin VB.Image Image2 
      Height          =   480
      Left            =   120
      Top             =   1680
      Width           =   480
   End
   Begin VB.Image Image1 
      Height          =   480
      Left            =   120
      Top             =   1200
      Width           =   480
   End
   Begin VB.Label PR1 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H0000C000&
      Height          =   255
      Left            =   7560
      TabIndex        =   31
      Top             =   1320
      Width           =   615
   End
   Begin VB.Label PR2 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C0C000&
      Height          =   255
      Left            =   7560
      TabIndex        =   30
      Top             =   1800
      Width           =   615
   End
   Begin VB.Label PR3 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   7560
      TabIndex        =   29
      Top             =   2280
      Width           =   615
   End
   Begin VB.Label PR4 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000080FF&
      Height          =   255
      Left            =   7560
      TabIndex        =   28
      Top             =   2760
      Width           =   615
   End
   Begin VB.Label PR5 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C00000&
      Height          =   255
      Left            =   7560
      TabIndex        =   27
      Top             =   3240
      Width           =   615
   End
   Begin VB.Label PR6 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00404040&
      Height          =   255
      Left            =   7560
      TabIndex        =   26
      Top             =   3720
      Width           =   615
   End
   Begin VB.Label TS1 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H0000C000&
      Height          =   255
      Left            =   5520
      TabIndex        =   25
      Top             =   1320
      Width           =   615
   End
   Begin VB.Label TS2 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C0C000&
      Height          =   255
      Left            =   5520
      TabIndex        =   24
      Top             =   1800
      Width           =   615
   End
   Begin VB.Label TS3 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   5520
      TabIndex        =   23
      Top             =   2280
      Width           =   615
   End
   Begin VB.Label TS4 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000080FF&
      Height          =   255
      Left            =   5520
      TabIndex        =   22
      Top             =   2760
      Width           =   615
   End
   Begin VB.Label TS5 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C00000&
      Height          =   255
      Left            =   5520
      TabIndex        =   21
      Top             =   3240
      Width           =   615
   End
   Begin VB.Label TS6 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00404040&
      Height          =   255
      Left            =   5520
      TabIndex        =   20
      Top             =   3720
      Width           =   615
   End
   Begin VB.Label S6 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00404040&
      Height          =   255
      Left            =   2880
      TabIndex        =   19
      Top             =   3720
      Width           =   615
   End
   Begin VB.Label S5 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C00000&
      Height          =   255
      Left            =   2880
      TabIndex        =   18
      Top             =   3240
      Width           =   615
   End
   Begin VB.Label S4 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000080FF&
      Height          =   255
      Left            =   2880
      TabIndex        =   17
      Top             =   2760
      Width           =   615
   End
   Begin VB.Label S3 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   2880
      TabIndex        =   16
      Top             =   2280
      Width           =   615
   End
   Begin VB.Label S2 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C0C000&
      Height          =   255
      Left            =   2880
      TabIndex        =   15
      Top             =   1800
      Width           =   615
   End
   Begin VB.Label S1 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H0000C000&
      Height          =   255
      Left            =   2880
      TabIndex        =   14
      Top             =   1320
      Width           =   615
   End
   Begin VB.Label R6 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00404040&
      Height          =   225
      Left            =   720
      TabIndex        =   13
      Top             =   3720
      Width           =   1215
   End
   Begin VB.Label R5 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C00000&
      Height          =   225
      Left            =   720
      TabIndex        =   12
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label R4 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000080FF&
      Height          =   225
      Left            =   720
      TabIndex        =   11
      Top             =   2760
      Width           =   1215
   End
   Begin VB.Label R3 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H000000FF&
      Height          =   225
      Left            =   720
      TabIndex        =   10
      Top             =   2280
      Width           =   1215
   End
   Begin VB.Label R2 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H00C0C000&
      Height          =   225
      Left            =   720
      TabIndex        =   9
      Top             =   1800
      Width           =   1215
   End
   Begin VB.Label R1 
      BackStyle       =   0  'Transparent
      ForeColor       =   &H0000C000&
      Height          =   225
      Left            =   720
      TabIndex        =   8
      Top             =   1320
      Width           =   1215
   End
   Begin VB.Label Label7 
      BackStyle       =   0  'Transparent
      Caption         =   "Total Score"
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
      Left            =   7560
      TabIndex        =   7
      Top             =   960
      Width           =   1095
   End
   Begin VB.Label Label6 
      BackStyle       =   0  'Transparent
      Caption         =   "Total Survival Points"
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
      Left            =   5520
      TabIndex        =   6
      Top             =   960
      Width           =   1815
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "Total Kills"
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
      Left            =   4440
      TabIndex        =   5
      Top             =   960
      Width           =   855
   End
   Begin VB.Label Label4 
      BackStyle       =   0  'Transparent
      Caption         =   "Survival points"
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
      Left            =   2880
      TabIndex        =   4
      Top             =   960
      Width           =   1335
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "Kills"
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
      Left            =   2160
      TabIndex        =   3
      Top             =   960
      Width           =   495
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "Robot Name"
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
      Left            =   120
      TabIndex        =   2
      Top             =   960
      Width           =   1095
   End
   Begin VB.Label GenStats 
      BackStyle       =   0  'Transparent
      Caption         =   "Label1"
      Height          =   735
      Left            =   120
      TabIndex        =   1
      Top             =   120
      Width           =   2655
   End
End
Attribute VB_Name = "HistoryWindow"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub OKButton_Click()
Unload Me
End Sub

