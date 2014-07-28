Option Strict Off
Option Explicit On
Module PasteIco
	'I added this module, from www.vb-helper.com , because SaveIcon can't handle more that 4 bit icons
	'SHAME ON MICROSOFT!!!!!!!!!!
	
	
	Structure RECT
		'UPGRADE_NOTE: Left was upgraded to Left_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Left_Renamed As Integer
		Dim Top As Integer
		'UPGRADE_NOTE: Right was upgraded to Right_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Right_Renamed As Integer
		Dim Bottom As Integer
	End Structure
	Structure tIconInfo
		Dim iWidth As Integer
		Dim iHeight As Integer
		Dim iBitCnt As Integer
		Dim iFileName As String
		Dim iDC As Integer
		Dim iBitmap As Integer
	End Structure
	Structure BITMAP
		Dim bmType As Integer
		Dim bmWidth As Integer
		Dim bmHeight As Integer
		Dim bmWidthBytes As Integer
		Dim bmPlanes As Short
		Dim bmBitsPixel As Short
		Dim bmBits As Integer
	End Structure
	Structure BITMAPFILEHEADER
		Dim bfType As Short
		Dim bfSize As Integer
		Dim bfReserved1 As Short
		Dim bfReserved2 As Short
		Dim bfOffBits As Integer
	End Structure
	Structure BITMAPINFOHEADER '40 bytes
		Dim biSize As Integer
		Dim biWidth As Integer
		Dim biHeight As Integer
		Dim biPlanes As Short
		Dim biBitCount As Short
		Dim biCompression As Integer
		Dim biSizeImage As Integer
		Dim biXPelsPerMeter As Integer
		Dim biYPelsPerMeter As Integer
		Dim biClrUsed As Integer
		Dim biClrImportant As Integer
	End Structure
	Structure RGBQUAD
		Dim rgbBlue As Byte
		Dim rgbGreen As Byte
		Dim rgbRed As Byte
		Dim rgbReserved As Byte
	End Structure
	Structure BITMAPINFO1Bit
		Dim bmiHeader As BITMAPINFOHEADER
		<VBFixedArray(1)> Dim bmiColors() As RGBQUAD
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim bmiColors(1)
		End Sub
	End Structure
	Structure BITMAPINFO4Bit
		Dim bmiHeader As BITMAPINFOHEADER
		<VBFixedArray(15)> Dim bmiColors() As RGBQUAD
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim bmiColors(15)
		End Sub
	End Structure
	Structure BITMAPINFO8Bit
		Dim bmiHeader As BITMAPINFOHEADER
		<VBFixedArray(255)> Dim bmiColors() As RGBQUAD
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim bmiColors(255)
		End Sub
	End Structure
	Structure BITMAPINFO24Bit
		Dim bmiHeader As BITMAPINFOHEADER
		Dim bmiColors As RGBQUAD
	End Structure
	Structure BITMAPINFO
		Dim bmiHeader As BITMAPINFOHEADER
		Dim bmiColors As RGBQUAD
	End Structure
	Structure ICONDIRENTRY
		Dim bWidth As Byte ' Width of the image
		Dim bHeight As Byte ' Height of the image (times 2)
		Dim bColorCount As Byte ' Number of colors in image (0 if >=8bpp)
		Dim bReserved As Byte ' Reserved
		Dim wPlanes As Short ' Color Planes
		Dim wBitCount As Short ' Bits per pixel
		Dim dwBytesInRes As Integer ' how many bytes in this resource?
		Dim dwImageOffset As Integer ' where in the file is this image
	End Structure
	Structure ICONDIR
		Dim idReserved As Short ' Reserved
		Dim idType As Short ' resource type (1 for icons)
		Dim idCount As Short ' how many images?
		Dim idEntries As ICONDIRENTRY 'array follows.
	End Structure
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Public Declare Function GetBitmapBits Lib "gdi32" (ByVal hBitmap As Integer, ByVal dwCount As Integer, ByRef lpBits As Any) As Integer
	'UPGRADE_NOTE: GetObject was upgraded to GetObject_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Public Declare Function GetObject_Renamed Lib "gdi32"  Alias "GetObjectA"(ByVal hObject As Integer, ByVal nCount As Integer, ByRef lpObject As Any) As Integer
	Public Declare Function CreateCompatibleBitmap Lib "gdi32" (ByVal hdc As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer) As Integer
	Public Declare Function GetDC Lib "user32" (ByVal hwnd As Integer) As Integer
	Public Declare Function DeleteDC Lib "gdi32" (ByVal hdc As Integer) As Integer
	Public Declare Function CreateCompatibleDC Lib "gdi32" (ByVal hdc As Integer) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Public Declare Function GetDIBits Lib "gdi32" (ByVal aHDC As Integer, ByVal hBitmap As Integer, ByVal nStartScan As Integer, ByVal nNumScans As Integer, ByRef lpBits As Any, ByRef lpBI As Any, ByVal wUsage As Integer) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Public Declare Function CreateBitmap Lib "gdi32" (ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal nPlanes As Integer, ByVal nBitCount As Integer, ByRef lpBits As Any) As Integer
	'UPGRADE_WARNING: Structure RECT may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Public Declare Function InvertRect Lib "user32" (ByVal hdc As Integer, ByRef lpRect As RECT) As Integer
	Public Declare Function SetBkColor Lib "gdi32" (ByVal hdc As Integer, ByVal crColor As Integer) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Public Declare Sub CopyMemory Lib "kernel32"  Alias "RtlMoveMemory"(ByRef pDst As Any, ByRef pSrc As Any, ByVal ByteLen As Integer)
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Public Declare Function CreateDIBSection Lib "gdi32" (ByVal hdc As Integer, ByRef pBitmapInfo As Any, ByVal un As Integer, ByVal lplpVoid As Integer, ByVal handle As Integer, ByVal dw As Integer) As Integer
	Public Declare Function SelectObject Lib "gdi32" (ByVal hdc As Integer, ByVal hObject As Integer) As Integer
	Public Declare Function BitBlt Lib "gdi32" (ByVal hDestDC As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hSrcDC As Integer, ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal dwRop As Integer) As Integer
	Public Declare Function DeleteObject Lib "gdi32" (ByVal hObject As Integer) As Integer
	'UPGRADE_WARNING: Structure RECT may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Public Declare Function SetRect Lib "user32" (ByRef lpRect As RECT, ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer) As Integer
	Public Declare Function CreateSolidBrush Lib "gdi32" (ByVal crColor As Integer) As Integer
	'UPGRADE_WARNING: Structure RECT may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Public Declare Function FillRect Lib "user32" (ByVal hdc As Integer, ByRef lpRect As RECT, ByVal hBrush As Integer) As Integer
	'UPGRADE_WARNING: Structure BITMAPINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Public Declare Function SetDIBitsToDevice Lib "gdi32" (ByVal hdc As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal SrcX As Integer, ByVal SrcY As Integer, ByVal Scan As Integer, ByVal NumScans As Integer, ByRef Bits As Any, ByRef BitsInfo As BITMAPINFO, ByVal wUsage As Integer) As Integer
	
	Public Const BI_RGB As Short = 0
	Public Const DIB_RGB_COLORS As Short = 0
	Public Const DIB_PAL_COLORS As Short = 1
	Public Const TransCol As Integer = 8438015 'Color to be Transparent
	'Public Const TransCol = vbWhite 'Color to be Transparent
	
	Public BitCnt As Integer
	Public IconInfo As tIconInfo
	Public Ubnd As Object
	Public bi24BitInfo As BITMAPINFO24Bit
	Public MaskBits(127) As Byte
	Public bBits(3071) As Byte
	
	Public Sub SaveIcon(ByRef sFileName As String, ByRef nDC As Integer, ByRef nBitmap As Integer, ByRef BpP As Integer)
		Dim CopyDC, CopyBitmap As Integer
		CopyDC = CreateCompatibleDC(nDC)
		bi24BitInfo.bmiHeader.biWidth = 32
		bi24BitInfo.bmiHeader.biHeight = 32
		With bi24BitInfo.bmiHeader
			.biBitCount = 24
			.biCompression = BI_RGB
			.biPlanes = 1
			.biSize = Len(bi24BitInfo.bmiHeader)
			.biWidth = 32
			.biHeight = 32
		End With
		'UPGRADE_WARNING: Couldn't resolve default property of object bi24BitInfo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyBitmap = CreateDIBSection(nDC, bi24BitInfo, DIB_RGB_COLORS, 0, 0, 0)
		SelectObject(CopyDC, CopyBitmap)
		ChangePixels(IconInfo.iDC, 0, 0, 32, 32, TransCol, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), CopyDC)
		'    Select Case BpP
		'        Case 1
		'            SaveIcon1Bit sFileName, nDC, nBitmap, CopyDC, CopyBitmap
		'        Case 4
		'            SaveIcon4Bit sFileName, nDC, nBitmap, CopyDC, CopyBitmap
		'        Case 8
		'            SaveIcon8Bit sFileName, nDC, nBitmap, CopyDC, CopyBitmap ', Optimized
		'        Case 24
		SaveIcon24Bit(sFileName, nDC, nBitmap, CopyDC, CopyBitmap)
		'    End Select
		DeleteDC(CopyDC)
		DeleteObject(CopyBitmap)
	End Sub
	Function ChangePixels(ByRef hSrcDC As Integer, ByRef X As Integer, ByRef Y As Integer, ByRef lWidth As Integer, ByRef lHeight As Integer, ByRef OldColor As Integer, ByRef NewColor As Integer, ByRef hDestDC As Integer) As Boolean
		Dim R As RECT
		Dim CopyDC, mBrush, CopyBitmap As Integer
		SetRect(R, 0, 0, lWidth, lHeight)
		mBrush = CreateSolidBrush(NewColor)
		CopyDC = CreateCompatibleDC(hSrcDC)
		bi24BitInfo.bmiHeader.biWidth = lWidth
		bi24BitInfo.bmiHeader.biHeight = lHeight
		With bi24BitInfo.bmiHeader
			.biBitCount = 24
			.biCompression = BI_RGB
			.biPlanes = 1
			.biSize = Len(bi24BitInfo.bmiHeader)
		End With
		'UPGRADE_WARNING: Couldn't resolve default property of object bi24BitInfo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyBitmap = CreateDIBSection(hSrcDC, bi24BitInfo, DIB_RGB_COLORS, 0, 0, 0)
		If SelectObject(CopyDC, CopyBitmap) = 0 Then
			MsgBox("In ChangePixels - SelectObject(CopyDC, CopyBitmap) = 0")
			Exit Function
		End If
		If FillRect(CopyDC, R, mBrush) = 0 Then Exit Function
		If TransBlt(hSrcDC, X, Y, lWidth, lHeight, OldColor, CopyDC, hDestDC) = False Then Exit Function
		DeleteDC(CopyDC)
		DeleteObject(CopyBitmap)
		DeleteObject(mBrush)
		ChangePixels = True
	End Function
	Private Sub SaveIcon24Bit(ByRef sFileName As String, ByRef nDC As Integer, ByRef nBitmap As Integer, ByRef CopyDC As Integer, ByRef CopyBitmap As Integer)
		'UPGRADE_WARNING: Arrays in structure IconInfo may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		'UPGRADE_WARNING: Arrays in structure MaskInfo may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim fID As ICONDIR
		Dim MaskInfo As BITMAPINFO1Bit
		Dim IconInfo As BITMAPINFO4Bit
		Dim nMaskDC, nMaskBitmap As Integer ', bBits(0 To 3071) As Byte ', MaskBits(0 To 127) As Byte
		Dim IconPal(255) As RGBQUAD
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If Dir(My.Application.Info.DirectoryPath & "\written.ico") <> "" Then Kill(My.Application.Info.DirectoryPath & "\written.ico")
		SetSaveData(24, nDC, MaskInfo, fID, nMaskDC, nMaskBitmap)
		fID.idEntries.dwBytesInRes = 3244
		IconInfo.bmiHeader.biSize = Len(IconInfo.bmiHeader)
		IconInfo.bmiHeader.biBitCount = 24
		IconInfo.bmiHeader.biSizeImage = 1153
		IconInfo.bmiHeader.biClrUsed = 1
		IconInfo.bmiHeader.biCompression = BI_RGB
		IconInfo.bmiHeader.biHeight = 64
		IconInfo.bmiHeader.biPlanes = 1
		IconInfo.bmiHeader.biWidth = 32
		FileOpen(1, sFileName, OpenMode.Binary)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, fID)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, IconInfo.bmiHeader)
		GetIconBits(bBits, 24, CopyDC, CopyBitmap, IconInfo.bmiColors)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, "    ")
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, bBits)
		'UPGRADE_WARNING: Couldn't resolve default property of object MaskInfo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		GetDIBits(nMaskDC, nMaskBitmap, 0, 32, MaskBits(0), MaskInfo, DIB_RGB_COLORS)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, MaskBits)
		FileClose(1) 'La till #1 för annars stänger den alla filer
		DeleteDC(nMaskDC)
		DeleteObject(nMaskBitmap)
	End Sub
	Function TransBlt(ByRef hSrcDC As Integer, ByRef X As Integer, ByRef Y As Integer, ByRef lWidth As Integer, ByRef lHeight As Integer, ByRef MaskColor As Integer, ByRef hBackDC As Integer, ByRef hDestDC As Integer) As Boolean
		Dim CopyDC, MonoDC, MonoBitmap, CopyBitmap As Integer
		Dim AndDC, AndBitmap As Integer
		Dim R As RECT
		MonoDC = CreateCompatibleDC(hSrcDC)
		MonoBitmap = CreateBitmap(lWidth, lHeight, 1, 1, 0)
		If SelectObject(MonoDC, MonoBitmap) = 0 Then Exit Function
		If CreateMask(hSrcDC, X, Y, lWidth, lHeight, MonoDC, MaskColor) = 0 Then Exit Function
		CopyDC = CreateCompatibleDC(hSrcDC)
		bi24BitInfo.bmiHeader.biWidth = lWidth
		bi24BitInfo.bmiHeader.biHeight = lHeight
		'UPGRADE_WARNING: Couldn't resolve default property of object bi24BitInfo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CopyBitmap = CreateDIBSection(hSrcDC, bi24BitInfo, DIB_RGB_COLORS, 0, 0, 0)
		If SelectObject(CopyDC, CopyBitmap) = 0 Then Exit Function
		AndDC = CreateCompatibleDC(hSrcDC)
		bi24BitInfo.bmiHeader.biWidth = lWidth
		bi24BitInfo.bmiHeader.biHeight = lHeight
		'UPGRADE_WARNING: Couldn't resolve default property of object bi24BitInfo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		AndBitmap = CreateDIBSection(hSrcDC, bi24BitInfo, DIB_RGB_COLORS, 0, 0, 0)
		If SelectObject(AndDC, AndBitmap) = 0 Then Exit Function
		'UPGRADE_ISSUE: Constant vbSrcCopy was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		BitBlt(AndDC, 0, 0, lWidth, lHeight, hSrcDC, X, Y, vbSrcCopy)
		'UPGRADE_ISSUE: Constant vbSrcCopy was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		BitBlt(CopyDC, 0, 0, lWidth, lHeight, hBackDC, 0, 0, vbSrcCopy)
		'UPGRADE_ISSUE: Constant vbSrcAnd was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		BitBlt(CopyDC, 0, 0, lWidth, lHeight, MonoDC, 0, 0, vbSrcAnd)
		SetRect(R, 0, 0, lWidth, lHeight)
		InvertRect(MonoDC, R)
		'UPGRADE_ISSUE: Constant vbSrcAnd was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		BitBlt(AndDC, 0, 0, lWidth, lHeight, MonoDC, 0, 0, vbSrcAnd)
		'UPGRADE_ISSUE: Constant vbSrcPaint was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		BitBlt(CopyDC, 0, 0, lWidth, lHeight, AndDC, 0, 0, vbSrcPaint)
		'UPGRADE_ISSUE: Constant vbSrcCopy was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		If BitBlt(hDestDC, X, Y, lWidth, lHeight, CopyDC, 0, 0, vbSrcCopy) = 0 Then Exit Function
		DeleteDC(MonoDC)
		DeleteDC(CopyDC)
		DeleteDC(AndDC)
		DeleteObject(MonoBitmap)
		DeleteObject(CopyBitmap)
		DeleteObject(AndBitmap)
		TransBlt = True
	End Function
	
	Private Sub SetSaveData(ByRef BpP As Integer, ByRef nDC As Integer, ByRef MaskInfo As BITMAPINFO1Bit, ByRef fID As ICONDIR, ByRef nMaskDC As Integer, ByRef nMaskBitmap As Integer)
		Select Case BpP
			Case 1
				'UPGRADE_WARNING: Couldn't resolve default property of object Ubnd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Ubnd = 1
				fID.idEntries.bColorCount = 0
			Case 4
				'UPGRADE_WARNING: Couldn't resolve default property of object Ubnd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Ubnd = 15
				fID.idEntries.bColorCount = 16
			Case 8
				'UPGRADE_WARNING: Couldn't resolve default property of object Ubnd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Ubnd = 255
				fID.idEntries.bColorCount = 0
			Case 24
				'UPGRADE_WARNING: Couldn't resolve default property of object Ubnd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Ubnd = 0
				fID.idEntries.bColorCount = 0
		End Select
		fID.idCount = 1
		fID.idType = 1
		fID.idEntries.bHeight = 32
		fID.idEntries.bWidth = 32
		fID.idEntries.dwImageOffset = Len(fID)
		fID.idEntries.wBitCount = 0
		fID.idEntries.wPlanes = 0
		fID.idEntries.dwBytesInRes = 744
		MaskInfo.bmiHeader.biSize = Len(MaskInfo.bmiHeader)
		MaskInfo.bmiHeader.biBitCount = 1
		MaskInfo.bmiHeader.biClrUsed = 2
		MaskInfo.bmiHeader.biHeight = 32
		MaskInfo.bmiHeader.biPlanes = 1
		MaskInfo.bmiHeader.biWidth = 32
		nMaskDC = CreateCompatibleDC(GetDC(0))
		nMaskBitmap = CreateBitmap(32, 32, 1, 1, 0)
		SelectObject(nMaskDC, nMaskBitmap)
		SetBkColor(nDC, TransCol)
		SetBkColor(nMaskDC, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
		'UPGRADE_ISSUE: Constant vbSrcCopy was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		BitBlt(nMaskDC, 0, 0, 32, 32, nDC, 0, 0, vbSrcCopy)
	End Sub
	Public Sub GetIconBits(ByRef bBits() As Byte, ByRef BpP As Integer, ByRef nDC As Integer, ByRef nBitmap As Integer, ByRef CopyArr() As RGBQUAD)
		'UPGRADE_WARNING: Arrays in structure BI may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim BI As BITMAPINFO8Bit
		BI.bmiHeader.biBitCount = BpP
		BI.bmiHeader.biCompression = BI_RGB
		BI.bmiHeader.biPlanes = 1
		BI.bmiHeader.biHeight = 32
		BI.bmiHeader.biWidth = 32
		BI.bmiHeader.biSize = Len(BI.bmiHeader)
		'UPGRADE_WARNING: Couldn't resolve default property of object BI. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		GetDIBits(nDC, nBitmap, 0, 32, bBits(0), BI, DIB_RGB_COLORS)
		If BpP = 1 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object BI.bmiColors(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object CopyArr(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMemory(CopyArr(0), BI.bmiColors(0), Len(CopyArr(0)) * 2)
		ElseIf BpP = 4 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object BI.bmiColors(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object CopyArr(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMemory(CopyArr(0), BI.bmiColors(0), Len(CopyArr(0)) * 16)
		ElseIf BpP = 8 Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object BI.bmiColors(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object CopyArr(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CopyMemory(CopyArr(0), BI.bmiColors(0), Len(CopyArr(0)) * 256)
		End If
	End Sub
	
	Function CreateMask(ByRef hSrcDC As Integer, ByRef X As Integer, ByRef Y As Integer, ByRef nWidth As Integer, ByRef nHeight As Integer, ByRef hDestDC As Integer, ByRef MaskColor As Integer) As Boolean
		Dim MonoBitmap, MonoDC, OldBkColor As Integer
		MonoDC = CreateCompatibleDC(hSrcDC)
		MonoBitmap = CreateBitmap(nWidth, nHeight, 1, 1, 0)
		If SelectObject(MonoDC, MonoBitmap) = 0 Then Exit Function
		OldBkColor = SetBkColor(hSrcDC, MaskColor)
		'UPGRADE_ISSUE: Constant vbSrcCopy was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		BitBlt(MonoDC, 0, 0, nWidth, nHeight, hSrcDC, X, Y, vbSrcCopy)
		'UPGRADE_ISSUE: Constant vbSrcCopy was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		If BitBlt(hDestDC, 0, 0, nWidth, nHeight, MonoDC, 0, 0, vbSrcCopy) = 0 Then Exit Function
		SetBkColor(hSrcDC, OldBkColor)
		DeleteObject(MonoBitmap)
		DeleteDC(MonoDC)
		CreateMask = True
	End Function
	
	'Private Sub SaveIcon1Bit(sFileName As String, nDC As Long, nBitmap As Long, CopyDC As Long, CopyBitmap As Long)
	'    Dim fID As ICONDIR, MaskInfo As BITMAPINFO1Bit, IconInfo As BITMAPINFO1Bit
	'    Dim nMaskDC As Long, nMaskBitmap As Long, bBits(0 To 127) As Byte ', MaskBits(0 To 127) As Byte
	'    If Dir(sFileName) <> "" Then Kill sFileName
	'    SetSaveData 1, nDC, MaskInfo, fID, nMaskDC, nMaskBitmap
	'    fID.idEntries.wPlanes = 5
	'    fID.idEntries.wBitCount = 7
	'    fID.idEntries.dwBytesInRes = 304
	'    fID.idEntries.dwImageOffset = 22
	'    IconInfo.bmiHeader.biSize = Len(IconInfo.bmiHeader)
	'    IconInfo.bmiHeader.biBitCount = 1
	'    IconInfo.bmiHeader.biSizeImage = 128
	'    IconInfo.bmiHeader.biCompression = BI_RGB
	'    IconInfo.bmiHeader.biHeight = 64
	'    IconInfo.bmiHeader.biPlanes = 1
	'    IconInfo.bmiHeader.biWidth = 32
	'    Open sFileName For Binary As #1
	'        Put #1, , fID
	'        Put #1, , IconInfo.bmiHeader
	'        GetIconBits bBits(), 1, CopyDC, CopyBitmap, IconInfo.bmiColors()
	'        Put #1, , IconInfo.bmiColors
	'        Put #1, , bBits()
	'        GetDIBits nMaskDC, nMaskBitmap, 0, 32, MaskBits(0), MaskInfo, DIB_RGB_COLORS
	'        Put #1, , MaskBits()
	'    Close #1    'La till #1 för annars stänger den alla filer
	'    DeleteDC nMaskDC
	'    DeleteObject nMaskBitmap
	'End Sub
	'Private Sub SaveIcon4Bit(sFileName As String, nDC As Long, nBitmap As Long, CopyDC As Long, CopyBitmap As Long)
	'    Dim fID As ICONDIR, MaskInfo As BITMAPINFO1Bit, IconInfo As BITMAPINFO4Bit
	'    Dim nMaskDC As Long, nMaskBitmap As Long, bBits(0 To 511) As Byte ', MaskBits(0 To 127) As Byte
	'    If Dir(sFileName) <> "" Then Kill sFileName
	'    SetSaveData 4, nDC, MaskInfo, fID, nMaskDC, nMaskBitmap
	'    IconInfo.bmiHeader.biSize = Len(IconInfo.bmiHeader)
	'    IconInfo.bmiHeader.biBitCount = 4
	'    IconInfo.bmiHeader.biSizeImage = 2
	'    IconInfo.bmiHeader.biCompression = BI_RGB
	'    IconInfo.bmiHeader.biHeight = 64
	'    IconInfo.bmiHeader.biPlanes = 1
	'    IconInfo.bmiHeader.biWidth = 32
	'    Open sFileName For Binary As #1
	'        Put #1, , fID
	'        Put #1, , IconInfo.bmiHeader
	'        GetIconBits bBits(), 4, CopyDC, CopyBitmap, IconInfo.bmiColors()
	'        Put #1, , IconInfo.bmiColors
	'        Put #1, , bBits()
	'        GetDIBits nMaskDC, nMaskBitmap, 0, 32, MaskBits(0), MaskInfo, DIB_RGB_COLORS
	'        Put #1, , MaskBits()
	'    Close #1    'La till #1 för annars stänger den alla filer
	'    DeleteDC nMaskDC
	'    DeleteObject nMaskBitmap
	'End Sub
	'Private Sub SaveIcon8Bit(sFileName As String, nDC As Long, nBitmap As Long, CopyDC As Long, CopyBitmap As Long)
	'    Dim fID As ICONDIR, MaskInfo As BITMAPINFO1Bit, IconInfo As BITMAPINFO8Bit
	'    Dim nMaskDC As Long, nMaskBitmap As Long, bBits(0 To 1023) As Byte ', MaskBits(0 To 127) As Byte
	'    Dim IconPal(0 To 255) As RGBQUAD
	'    If Dir(sFileName) <> "" Then Kill sFileName
	'    SetSaveData 8, nDC, MaskInfo, fID, nMaskDC, nMaskBitmap
	'    fID.idEntries.dwBytesInRes = 2216
	'    IconInfo.bmiHeader.biSize = Len(IconInfo.bmiHeader)
	'    IconInfo.bmiHeader.biBitCount = 8
	'    IconInfo.bmiHeader.biSizeImage = 1152
	'    IconInfo.bmiHeader.biClrUsed = 256
	'    IconInfo.bmiHeader.biCompression = BI_RGB
	'    IconInfo.bmiHeader.biHeight = 64
	'    IconInfo.bmiHeader.biPlanes = 1
	'    IconInfo.bmiHeader.biWidth = 32
	'    Open sFileName For Binary As #1
	'        Put #1, , fID
	'        Put #1, , IconInfo.bmiHeader
	'            GetIconBits bBits(), 8, CopyDC, CopyBitmap, IconInfo.bmiColors()
	'        Put #1, , IconInfo.bmiColors
	'        Put #1, , bBits()
	'        GetDIBits nMaskDC, nMaskBitmap, 0, 32, MaskBits(0), MaskInfo, DIB_RGB_COLORS
	'        Put #1, , MaskBits()
	'    Close #1    'La till #1 för annars stänger den alla filer
	'    DeleteDC nMaskDC
	'    DeleteObject nMaskBitmap
	'End Sub
End Module