Attribute VB_Name = "ChangeResolution"
Option Explicit

Const DM_BITSPERPEL As Long = &H40000
Const DM_PELSWIDTH As Long = &H80000
Const DM_PELSHEIGHT As Long = &H100000
Const CDS_FORCE As Long = &H80000000

Const CCDEVICENAME As Long = 32
Const CCFORMNAME As Long = 32

Private Type DEVMODE
    dmDeviceName As String * CCDEVICENAME
    dmSpecVersion As Integer
    dmDriverVersion As Integer
    dmSize As Integer
    dmDriverExtra As Integer
    dmFields As Long
    dmOrientation As Integer
    dmPaperSize As Integer
    dmPaperLength As Integer
    dmPaperWidth As Integer
    dmScale As Integer
    dmCopies As Integer
    dmDefaultSource As Integer
    dmPrintQuality As Integer
    dmColor As Integer
    dmDuplex As Integer
    dmYResolution As Integer
    dmTTOption As Integer
    dmCollate As Integer
    dmFormName As String * CCFORMNAME
    dmUnusedPadding As Integer
    dmBitsPerPel As Long
    dmPelsWidth As Long
    dmPelsHeight As Long
    dmDisplayFlags As Long
    dmDisplayFrequency As Long
End Type
Private Declare Function EnumDisplaySettings Lib "user32" Alias _
    "EnumDisplaySettingsA" (ByVal lpszDeviceName As Long, _
    ByVal modeIndex As Long, lpDevMode As Any) As Boolean
Private Declare Function ChangeDisplaySettings Lib "user32" Alias _
    "ChangeDisplaySettingsA" (lpDevMode As Any, ByVal dwflags As Long) As Long

Private Declare Function GetDeviceCaps Lib "gdi32" (ByVal hdc _
As Long, ByVal nIndex As Long) As Long

Private Const BITSPIXEL As Long = 12
Private Const VREFRESH = 116
Private Const HORZRES = 8
Private Const VERTRES = 10

Private CurrentScreenWidth As Integer
Private CurrentScreenHeight As Integer

' change the screen resolution mode
'
' returns True if the requested resolution mode is among those
' supported by the display adapter (otherwise it doesn't even
' try to change the screen resolution)

Function ChangeScreenResolution(ByVal Width As Long, ByVal Height As Long, _
    ByVal NumColors As Long, Optional Frequency As Long) As Boolean
    Dim lpDevMode As DEVMODE
    Dim index As Long
    
    ' set the DEVMODE flags and structure size
    lpDevMode.dmSize = Len(lpDevMode)
    lpDevMode.dmFields = DM_PELSWIDTH Or DM_PELSHEIGHT Or DM_BITSPERPEL
    
    ' retrieve info on the Nth display mode, exit if no more
    Do While EnumDisplaySettings(0, index, lpDevMode) > 0
        ' check whether this is the mode we're looking for
        If lpDevMode.dmPelsWidth = Width And lpDevMode.dmPelsHeight = Height _
        And lpDevMode.dmBitsPerPel = NumColors Then
            ' check that the frequency is also the one we're looking for
            If Frequency = 0 Or Frequency = lpDevMode.dmDisplayFrequency Then
                ' try changing the resolution
                If ChangeDisplaySettings(lpDevMode, CDS_FORCE) = 0 Then
                    ' zero means success
                    ChangeScreenResolution = True
                    Exit Do
                End If
            End If
        End If
        ' skip to next screen mode
        index = index + 1
    Loop

End Function

 Sub ChangeWindow_640X480(WindowHDC As Long)

Dim CurrentColorResolution As Long
Dim CurrentRefreshRate As Long

'Dim Newwidth As Integer
'Dim Newheight As Integer
Dim Succesfull As Boolean

CurrentColorResolution = GetDeviceCaps(WindowHDC, BITSPIXEL)
CurrentRefreshRate = GetDeviceCaps(WindowHDC, VREFRESH)

If GetDeviceCaps(WindowHDC, HORZRES) <> 640 Then
    CurrentScreenWidth = GetDeviceCaps(WindowHDC, HORZRES)
    CurrentScreenHeight = GetDeviceCaps(WindowHDC, VERTRES)
    Succesfull = ChangeScreenResolution(640, 480, CurrentColorResolution, CurrentRefreshRate)
    If Succesfull = False Then
        MsgBox "640x480 Mode not supported. You can run the game in other resolutions, however, but the robots will look thinny. If you don't want to see this message in the future you can uncheck 'Auto Change Resolution' in the Prefernce Menu.", vbOKOnly, "Change Resolution Failed"
    End If
Else
    Succesfull = ChangeScreenResolution(CurrentScreenWidth, CurrentScreenHeight, CurrentColorResolution, CurrentRefreshRate)
End If
End Sub

