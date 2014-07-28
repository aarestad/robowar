VERSION 5.00
Begin VB.Form AboutRoboWar 
   Caption         =   "About RoboWar 5"
   ClientHeight    =   5445
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   5385
   Icon            =   "AboutRoboWar.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   5445
   ScaleWidth      =   5385
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Close 
      Caption         =   "Close"
      Default         =   -1  'True
      Height          =   375
      Left            =   4080
      TabIndex        =   0
      Top             =   4920
      Width           =   1095
   End
   Begin VB.Label Label8 
      AutoSize        =   -1  'True
      Caption         =   "Silas Warner"
      Height          =   195
      Left            =   120
      TabIndex        =   11
      Top             =   5040
      Width           =   900
   End
   Begin VB.Label Label7 
      AutoSize        =   -1  'True
      Caption         =   "Additional Credit"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   195
      Left            =   120
      TabIndex        =   10
      Top             =   4800
      Width           =   1410
   End
   Begin VB.Label Label6 
      AutoSize        =   -1  'True
      Caption         =   "Thanks to"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   195
      Left            =   120
      TabIndex        =   9
      Top             =   1560
      Width           =   870
   End
   Begin VB.Label Label5 
      AutoSize        =   -1  'True
      Caption         =   "Special Thanks to"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   195
      Left            =   2880
      TabIndex        =   8
      Top             =   1560
      Width           =   1560
   End
   Begin VB.Label Version 
      AutoSize        =   -1  'True
      Caption         =   "Version"
      Height          =   195
      Left            =   3120
      TabIndex        =   7
      Top             =   360
      Width           =   525
   End
   Begin VB.Label SpecialThanksTo 
      AutoSize        =   -1  'True
      Height          =   195
      Left            =   2880
      TabIndex        =   6
      Top             =   1800
      Width           =   45
   End
   Begin VB.Label ThanksTo 
      AutoSize        =   -1  'True
      Height          =   195
      Left            =   120
      TabIndex        =   5
      Top             =   1800
      Width           =   45
   End
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      Caption         =   "Form Design by Kevin Hertzberg and David Forslund"
      Height          =   195
      Left            =   120
      TabIndex        =   4
      Top             =   1200
      Width           =   3705
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "Windows Icons by Dave Brasgalla"
      Height          =   195
      Left            =   120
      TabIndex        =   3
      Top             =   960
      Width           =   2430
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "Created by Kevin Hertzberg"
      Height          =   195
      Left            =   120
      TabIndex        =   2
      Top             =   720
      Width           =   1950
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "RoboWar 5"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   24
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   555
      Left            =   120
      TabIndex        =   1
      Top             =   120
      Width           =   2445
   End
End
Attribute VB_Name = "AboutRoboWar"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Const sThanksTo = _
"Christian Bauer, Lauri Pesonen," & vbCr & "Bernd Schmidt" & vbCr _
& "David Harris" & vbCr & "Dave Brasgalla" & vbCr _
& "Stefan Arvidsson, Jesper Ek" & vbCr _
& "Jost Schwider" & vbCr _
& "Danny K. - www.xi0n.com" & vbCr & "Brad Martinez - btmtz.mvps.org" & vbCr _
& "Wpsjr1 - www.syix.com/wpsjr1/" & vbCr _
& "www.vb-helper.com" & vbCr & "www.freevbcode.com" & vbCr & "www.developerfusion.co.uk" & vbCr _
& "www.xbeat.net/vbspeed/" & vbCr _
& "www.innosetup.com"

Const sSpecialThanksTo = _
"Camden Elliott-Williams" & vbCr _
& "Sam Rushing" & vbCr _
& "David Forslund" & vbCr _
& "BlueOwl" & vbCr _
& "Eric Foley" & vbCr _
& "Viktor Tullgren" & vbCr _
& "Themo Therzis" & vbCr _
& "Edward Marchant" & vbCr _
& "Randy Munroe" & vbCr _
& "Joacim Andersson" & vbCr _
& "OnErrOr" & vbCr _
& "Austin Barton" & vbCr _
& "Charlie Davis" & vbCr _
& "Lucas Dixon" & vbCr _
& "Hans Nicander" & vbCr & vbCr

Private Sub Close_Click()
Unload Me
End Sub

Private Sub Form_Load()
If UCase(App.EXEName) = "ROBOWAR 5" Then   'Made it Win98 Compatible
    Version = "Version " & App.Major & "." & App.Minor & "." & App.Revision
Else
    Version = "Version " & App.Major & "." & App.Minor & "." & App.Revision & vbCr & _
    "Debug: " & Replace(App.EXEName, "RoboWar 5 ", "", , , vbTextCompare)
End If

'If App.EXEName = "RoboWar 5" Then
'    Version = "Version " & App.Major & "." & App.Minor & "." & App.Revision
'Else
'    Version = "Version " & App.Major & "." & App.Minor & "." & App.Revision & vbCr & _
'    "Debug: " & Replace(App.EXEName, "RoboWar 5 ", "")
'End If

ThanksTo = sThanksTo
SpecialThanksTo = sSpecialThanksTo

End Sub



