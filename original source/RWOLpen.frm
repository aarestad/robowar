VERSION 5.00
Begin VB.Form RWOLpen 
   BackColor       =   &H00000000&
   Caption         =   "RoboWar 5"
   ClientHeight    =   6675
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   11025
   FillStyle       =   0  'Solid
   Icon            =   "RWOLpen.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MinButton       =   0   'False
   ScaleHeight     =   6675
   ScaleWidth      =   11025
   WindowState     =   2  'Maximized
   Begin VB.Label WinByMe 
      BackStyle       =   0  'Transparent
      Caption         =   "Windows version by Kevin Hertzberg"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   -1  'True
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   3120
      TabIndex        =   0
      Top             =   2760
      Width           =   3975
   End
   Begin VB.Image RoboWar 
      Height          =   6480
      Left            =   0
      Picture         =   "RWOLpen.frx":0E42
      Stretch         =   -1  'True
      Top             =   0
      Width           =   9600
   End
End
Attribute VB_Name = "RWOLpen"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
Unload Me
MainWindow.Show
End Sub

Private Sub Form_Load()
'SetAttr App.Path & "\miscdata\MainPrefs.cfg", 0 'Unlock file
Open App.Path & "\miscdata\MainPrefs.cfg" For Binary As 7   'This file is the prefs file. It's open as long as the app is

Dim YesOrNo As Boolean
Get 7, 12000, YesOrNo                     'Change resolution (I think this works fine now)
                                            'No, it doesn't ;-(
If YesOrNo = True Then
    ChangeWindow_640X480 (RWOLpen.hdc)
Else
    RoboWar.Height = (Screen.Height \ Screen.TwipsPerPixelY - 48) * Screen.TwipsPerPixelY
    RoboWar.Width = Screen.Width
    WinByMe.Left = RoboWar.Width \ 2 - WinByMe.Width \ 2
    WinByMe.Top = RoboWar.Height / 2.1
End If
End Sub

Private Sub Form_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
Unload Me
MainWindow.Show
End Sub

Private Sub WinByMe_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
Unload Me
MainWindow.Show
End Sub

'Private Sub RoboWar_KeyDown(KeyCode As Integer, Shift As Integer)
'Unload Me
'MainWindow.Show
'End Sub

Private Sub RoboWar_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
Unload Me
MainWindow.Show
End Sub

