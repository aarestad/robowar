Option Strict Off
Option Explicit On
Module ChangeResolution
	
	Const DM_BITSPERPEL As Integer = &H40000
	Const DM_PELSWIDTH As Integer = &H80000
	Const DM_PELSHEIGHT As Integer = &H100000
	Const CDS_FORCE As Integer = &H80000000
	
	Const CCDEVICENAME As Integer = 32
	Const CCFORMNAME As Integer = 32
	
	Private Structure DEVMODE
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(CCDEVICENAME),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=CCDEVICENAME)> Public dmDeviceName() As Char
		Dim dmSpecVersion As Short
		Dim dmDriverVersion As Short
		Dim dmSize As Short
		Dim dmDriverExtra As Short
		Dim dmFields As Integer
		Dim dmOrientation As Short
		Dim dmPaperSize As Short
		Dim dmPaperLength As Short
		Dim dmPaperWidth As Short
		Dim dmScale As Short
		Dim dmCopies As Short
		Dim dmDefaultSource As Short
		Dim dmPrintQuality As Short
		Dim dmColor As Short
		Dim dmDuplex As Short
		Dim dmYResolution As Short
		Dim dmTTOption As Short
		Dim dmCollate As Short
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(CCFORMNAME),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=CCFORMNAME)> Public dmFormName() As Char
		Dim dmUnusedPadding As Short
		Dim dmBitsPerPel As Integer
		Dim dmPelsWidth As Integer
		Dim dmPelsHeight As Integer
		Dim dmDisplayFlags As Integer
		Dim dmDisplayFrequency As Integer
	End Structure
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Function EnumDisplaySettings Lib "user32"  Alias "EnumDisplaySettingsA"(ByVal lpszDeviceName As Integer, ByVal modeIndex As Integer, ByRef lpDevMode As Any) As Boolean
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Function ChangeDisplaySettings Lib "user32"  Alias "ChangeDisplaySettingsA"(ByRef lpDevMode As Any, ByVal dwflags As Integer) As Integer
	
	Private Declare Function GetDeviceCaps Lib "gdi32" (ByVal hdc As Integer, ByVal nIndex As Integer) As Integer
	
	Private Const BITSPIXEL As Integer = 12
	Private Const VREFRESH As Short = 116
	Private Const HORZRES As Short = 8
	Private Const VERTRES As Short = 10
	
	Private CurrentScreenWidth As Short
	Private CurrentScreenHeight As Short
	
	' change the screen resolution mode
	'
	' returns True if the requested resolution mode is among those
	' supported by the display adapter (otherwise it doesn't even
	' try to change the screen resolution)
	
	Function ChangeScreenResolution(ByVal Width As Integer, ByVal Height As Integer, ByVal NumColors As Integer, Optional ByRef Frequency As Integer = 0) As Boolean
		Dim lpDevMode As DEVMODE
		Dim index As Integer
		
		' set the DEVMODE flags and structure size
		lpDevMode.dmSize = Len(lpDevMode)
		lpDevMode.dmFields = DM_PELSWIDTH Or DM_PELSHEIGHT Or DM_BITSPERPEL
		
		' retrieve info on the Nth display mode, exit if no more
		'UPGRADE_WARNING: Couldn't resolve default property of object lpDevMode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Do While EnumDisplaySettings(0, index, lpDevMode) > 0
			' check whether this is the mode we're looking for
			If lpDevMode.dmPelsWidth = Width And lpDevMode.dmPelsHeight = Height And lpDevMode.dmBitsPerPel = NumColors Then
				' check that the frequency is also the one we're looking for
				If Frequency = 0 Or Frequency = lpDevMode.dmDisplayFrequency Then
					' try changing the resolution
					'UPGRADE_WARNING: Couldn't resolve default property of object lpDevMode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
	
	Sub ChangeWindow_640X480(ByRef WindowHDC As Integer)
		
		Dim CurrentColorResolution As Integer
		Dim CurrentRefreshRate As Integer
		
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
				MsgBox("640x480 Mode not supported. You can run the game in other resolutions, however, but the robots will look thinny. If you don't want to see this message in the future you can uncheck 'Auto Change Resolution' in the Prefernce Menu.", MsgBoxStyle.OKOnly, "Change Resolution Failed")
			End If
		Else
			Succesfull = ChangeScreenResolution(CurrentScreenWidth, CurrentScreenHeight, CurrentColorResolution, CurrentRefreshRate)
		End If
	End Sub
End Module