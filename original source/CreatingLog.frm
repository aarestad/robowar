VERSION 5.00
Begin VB.Form CreatingLog 
   Caption         =   "Creating Tournament Log"
   ClientHeight    =   435
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   3810
   LinkTopic       =   "Form1"
   ScaleHeight     =   29
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   254
   Begin VB.CommandButton Cancel 
      Caption         =   "Cancel"
      Height          =   375
      Left            =   2550
      TabIndex        =   0
      Top             =   30
      Width           =   1215
   End
   Begin VB.Label Percent 
      Caption         =   "%"
      Height          =   255
      Left            =   270
      TabIndex        =   2
      Top             =   120
      Width           =   210
   End
   Begin VB.Label Progress 
      Caption         =   "100"
      Height          =   255
      Left            =   0
      TabIndex        =   1
      Top             =   120
      Width           =   330
   End
End
Attribute VB_Name = "CreatingLog"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Public CanceledLog As Boolean

Private Sub Cancel_Click()
CanceledLog = True
End Sub

Private Sub Form_Load()
CanceledLog = False
End Sub
