Attribute VB_Name = "PasteIco"
'I added this module, from www.vb-helper.com , because SaveIcon can't handle more that 4 bit icons
'SHAME ON MICROSOFT!!!!!!!!!!

Option Explicit

Type RECT
        Left As Long
        Top As Long
        Right As Long
        Bottom As Long
End Type
Type tIconInfo
    iWidth As Long
    iHeight As Long
    iBitCnt As Long
    iFileName As String
    iDC As Long
    iBitmap As Long
End Type
Type BITMAP
    bmType As Long
    bmWidth As Long
    bmHeight As Long
    bmWidthBytes As Long
    bmPlanes As Integer
    bmBitsPixel As Integer
    bmBits As Long
End Type
Type BITMAPFILEHEADER
        bfType As Integer
        bfSize As Long
        bfReserved1 As Integer
        bfReserved2 As Integer
        bfOffBits As Long
End Type
Type BITMAPINFOHEADER '40 bytes
        biSize As Long
        biWidth As Long
        biHeight As Long
        biPlanes As Integer
        biBitCount As Integer
        biCompression As Long
        biSizeImage As Long
        biXPelsPerMeter As Long
        biYPelsPerMeter As Long
        biClrUsed As Long
        biClrImportant As Long
End Type
Type RGBQUAD
        rgbBlue As Byte
        rgbGreen As Byte
        rgbRed As Byte
        rgbReserved As Byte
End Type
Type BITMAPINFO1Bit
    bmiHeader As BITMAPINFOHEADER
    bmiColors(0 To 1) As RGBQUAD
End Type
Type BITMAPINFO4Bit
    bmiHeader As BITMAPINFOHEADER
    bmiColors(0 To 15) As RGBQUAD
End Type
Type BITMAPINFO8Bit
    bmiHeader As BITMAPINFOHEADER
    bmiColors(0 To 255) As RGBQUAD
End Type
Type BITMAPINFO24Bit
    bmiHeader As BITMAPINFOHEADER
    bmiColors As RGBQUAD
End Type
Type BITMAPINFO
    bmiHeader As BITMAPINFOHEADER
    bmiColors As RGBQUAD
End Type
Type ICONDIRENTRY
   bWidth As Byte               ' Width of the image
   bHeight As Byte              ' Height of the image (times 2)
   bColorCount As Byte          ' Number of colors in image (0 if >=8bpp)
   bReserved As Byte            ' Reserved
   wPlanes As Integer           ' Color Planes
   wBitCount As Integer         ' Bits per pixel
   dwBytesInRes As Long         ' how many bytes in this resource?
   dwImageOffset As Long        ' where in the file is this image
End Type
Type ICONDIR
   idReserved As Integer   ' Reserved
   idType As Integer       ' resource type (1 for icons)
   idCount As Integer      ' how many images?
   idEntries As ICONDIRENTRY 'array follows.
End Type
Public Declare Function GetBitmapBits Lib "gdi32" (ByVal hBitmap As Long, ByVal dwCount As Long, lpBits As Any) As Long
Public Declare Function GetObject Lib "gdi32" Alias "GetObjectA" (ByVal hObject As Long, ByVal nCount As Long, lpObject As Any) As Long
Public Declare Function CreateCompatibleBitmap Lib "gdi32" (ByVal hdc As Long, ByVal nWidth As Long, ByVal nHeight As Long) As Long
Public Declare Function GetDC Lib "user32" (ByVal hwnd As Long) As Long
Public Declare Function DeleteDC Lib "gdi32" (ByVal hdc As Long) As Long
Public Declare Function CreateCompatibleDC Lib "gdi32" (ByVal hdc As Long) As Long
Public Declare Function GetDIBits Lib "gdi32" (ByVal aHDC As Long, ByVal hBitmap As Long, ByVal nStartScan As Long, ByVal nNumScans As Long, lpBits As Any, lpBI As Any, ByVal wUsage As Long) As Long
Public Declare Function CreateBitmap Lib "gdi32" (ByVal nWidth As Long, ByVal nHeight As Long, ByVal nPlanes As Long, ByVal nBitCount As Long, lpBits As Any) As Long
Public Declare Function InvertRect Lib "user32" (ByVal hdc As Long, lpRect As RECT) As Long
Public Declare Function SetBkColor Lib "gdi32" (ByVal hdc As Long, ByVal crColor As Long) As Long
Public Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (pDst As Any, pSrc As Any, ByVal ByteLen As Long)
Public Declare Function CreateDIBSection Lib "gdi32" (ByVal hdc As Long, pBitmapInfo As Any, ByVal un As Long, ByVal lplpVoid As Long, ByVal handle As Long, ByVal dw As Long) As Long
Public Declare Function SelectObject Lib "gdi32" (ByVal hdc As Long, ByVal hObject As Long) As Long
Public Declare Function BitBlt Lib "gdi32" (ByVal hDestDC As Long, ByVal X As Long, ByVal Y As Long, ByVal nWidth As Long, ByVal nHeight As Long, ByVal hSrcDC As Long, ByVal xSrc As Long, ByVal ySrc As Long, ByVal dwRop As Long) As Long
Public Declare Function DeleteObject Lib "gdi32" (ByVal hObject As Long) As Long
Public Declare Function SetRect Lib "user32" (lpRect As RECT, ByVal X1 As Long, ByVal Y1 As Long, ByVal X2 As Long, ByVal Y2 As Long) As Long
Public Declare Function CreateSolidBrush Lib "gdi32" (ByVal crColor As Long) As Long
Public Declare Function FillRect Lib "user32" (ByVal hdc As Long, lpRect As RECT, ByVal hBrush As Long) As Long
Public Declare Function SetDIBitsToDevice Lib "gdi32" (ByVal hdc As Long, ByVal X As Long, ByVal Y As Long, ByVal dx As Long, ByVal dy As Long, ByVal SrcX As Long, ByVal SrcY As Long, ByVal Scan As Long, ByVal NumScans As Long, Bits As Any, BitsInfo As BITMAPINFO, ByVal wUsage As Long) As Long

Public Const BI_RGB = 0&
Public Const DIB_RGB_COLORS = 0
Public Const DIB_PAL_COLORS = 1
Public Const TransCol = 8438015 'Color to be Transparent
'Public Const TransCol = vbWhite 'Color to be Transparent

Global BitCnt As Long, IconInfo As tIconInfo, Ubnd
Global bi24BitInfo As BITMAPINFO24Bit
Global MaskBits(0 To 127) As Byte, bBits(0 To 3071) As Byte

Public Sub SaveIcon(sFileName As String, nDC As Long, nBitmap As Long, BpP As Long)
    Dim CopyDC As Long, CopyBitmap As Long
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
    CopyBitmap = CreateDIBSection(nDC, bi24BitInfo, DIB_RGB_COLORS, ByVal 0&, ByVal 0&, ByVal 0&)
    SelectObject CopyDC, CopyBitmap
    ChangePixels IconInfo.iDC, 0, 0, 32, 32, TransCol, vbBlack, CopyDC
'    Select Case BpP
'        Case 1
'            SaveIcon1Bit sFileName, nDC, nBitmap, CopyDC, CopyBitmap
'        Case 4
'            SaveIcon4Bit sFileName, nDC, nBitmap, CopyDC, CopyBitmap
'        Case 8
'            SaveIcon8Bit sFileName, nDC, nBitmap, CopyDC, CopyBitmap ', Optimized
'        Case 24
            SaveIcon24Bit sFileName, nDC, nBitmap, CopyDC, CopyBitmap
'    End Select
    DeleteDC CopyDC
    DeleteObject CopyBitmap
End Sub
Function ChangePixels(hSrcDC As Long, X As Long, Y As Long, lWidth As Long, lHeight As Long, OldColor As Long, NewColor As Long, hDestDC As Long) As Boolean
    Dim R As RECT, mBrush As Long, CopyDC As Long, CopyBitmap As Long
    SetRect R, 0, 0, lWidth, lHeight
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
    CopyBitmap = CreateDIBSection(hSrcDC, bi24BitInfo, DIB_RGB_COLORS, ByVal 0&, ByVal 0&, ByVal 0&)
    If SelectObject(CopyDC, CopyBitmap) = 0 Then
        MsgBox "In ChangePixels - SelectObject(CopyDC, CopyBitmap) = 0"
        Exit Function
    End If
    If FillRect(CopyDC, R, mBrush) = 0 Then Exit Function
    If TransBlt(hSrcDC, X, Y, lWidth, lHeight, OldColor, CopyDC, hDestDC) = False Then Exit Function
    DeleteDC CopyDC
    DeleteObject CopyBitmap
    DeleteObject mBrush
    ChangePixels = True
End Function
Private Sub SaveIcon24Bit(sFileName As String, nDC As Long, nBitmap As Long, CopyDC As Long, CopyBitmap As Long)
    Dim fID As ICONDIR, MaskInfo As BITMAPINFO1Bit, IconInfo As BITMAPINFO4Bit
    Dim nMaskDC As Long, nMaskBitmap As Long ', bBits(0 To 3071) As Byte ', MaskBits(0 To 127) As Byte
    Dim IconPal(0 To 255) As RGBQUAD
    If Dir(App.Path & "\written.ico") <> "" Then Kill App.Path & "\written.ico"
    SetSaveData 24, nDC, MaskInfo, fID, nMaskDC, nMaskBitmap
    fID.idEntries.dwBytesInRes = 3244
    IconInfo.bmiHeader.biSize = Len(IconInfo.bmiHeader)
    IconInfo.bmiHeader.biBitCount = 24
    IconInfo.bmiHeader.biSizeImage = 1153
    IconInfo.bmiHeader.biClrUsed = 1
    IconInfo.bmiHeader.biCompression = BI_RGB
    IconInfo.bmiHeader.biHeight = 64
    IconInfo.bmiHeader.biPlanes = 1
    IconInfo.bmiHeader.biWidth = 32
    Open sFileName For Binary As #1
        Put #1, , fID
        Put #1, , IconInfo.bmiHeader
        GetIconBits bBits(), 24, CopyDC, CopyBitmap, IconInfo.bmiColors()
        Put #1, , "    "
        Put #1, , bBits()
        GetDIBits nMaskDC, nMaskBitmap, 0, 32, MaskBits(0), MaskInfo, DIB_RGB_COLORS
        Put #1, , MaskBits()
    Close #1    'La till #1 för annars stänger den alla filer
    DeleteDC nMaskDC
    DeleteObject nMaskBitmap
End Sub
Function TransBlt(hSrcDC As Long, X As Long, Y As Long, lWidth As Long, lHeight As Long, MaskColor As Long, hBackDC As Long, hDestDC As Long) As Boolean
    Dim MonoDC As Long, MonoBitmap As Long, CopyDC As Long, CopyBitmap As Long
    Dim AndDC As Long, AndBitmap As Long, R As RECT
    MonoDC = CreateCompatibleDC(hSrcDC)
    MonoBitmap = CreateBitmap(lWidth, lHeight, 1, 1, ByVal 0&)
    If SelectObject(MonoDC, MonoBitmap) = 0 Then Exit Function
    If CreateMask(hSrcDC, X, Y, lWidth, lHeight, MonoDC, MaskColor) = 0 Then Exit Function
    CopyDC = CreateCompatibleDC(hSrcDC)
    bi24BitInfo.bmiHeader.biWidth = lWidth
    bi24BitInfo.bmiHeader.biHeight = lHeight
    CopyBitmap = CreateDIBSection(hSrcDC, bi24BitInfo, DIB_RGB_COLORS, ByVal 0&, ByVal 0&, ByVal 0&)
    If SelectObject(CopyDC, CopyBitmap) = 0 Then Exit Function
    AndDC = CreateCompatibleDC(hSrcDC)
    bi24BitInfo.bmiHeader.biWidth = lWidth
    bi24BitInfo.bmiHeader.biHeight = lHeight
    AndBitmap = CreateDIBSection(hSrcDC, bi24BitInfo, DIB_RGB_COLORS, ByVal 0&, ByVal 0&, ByVal 0&)
    If SelectObject(AndDC, AndBitmap) = 0 Then Exit Function
    BitBlt AndDC, 0, 0, lWidth, lHeight, hSrcDC, X, Y, vbSrcCopy
    BitBlt CopyDC, 0, 0, lWidth, lHeight, hBackDC, 0, 0, vbSrcCopy
    BitBlt CopyDC, 0, 0, lWidth, lHeight, MonoDC, 0, 0, vbSrcAnd
    SetRect R, 0, 0, lWidth, lHeight
    InvertRect MonoDC, R
    BitBlt AndDC, 0, 0, lWidth, lHeight, MonoDC, 0, 0, vbSrcAnd
    BitBlt CopyDC, 0, 0, lWidth, lHeight, AndDC, 0, 0, vbSrcPaint
    If BitBlt(hDestDC, X, Y, lWidth, lHeight, CopyDC, 0, 0, vbSrcCopy) = 0 Then Exit Function
    DeleteDC MonoDC
    DeleteDC CopyDC
    DeleteDC AndDC
    DeleteObject MonoBitmap
    DeleteObject CopyBitmap
    DeleteObject AndBitmap
    TransBlt = True
End Function

Private Sub SetSaveData(BpP As Long, nDC As Long, MaskInfo As BITMAPINFO1Bit, fID As ICONDIR, nMaskDC As Long, nMaskBitmap As Long)
    Select Case BpP
        Case 1
            Ubnd = 1
            fID.idEntries.bColorCount = 0
        Case 4
            Ubnd = 15
            fID.idEntries.bColorCount = 16
        Case 8
            Ubnd = 255
           fID.idEntries.bColorCount = 0
       Case 24
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
    nMaskBitmap = CreateBitmap(32, 32, 1, 1, ByVal 0&)
    SelectObject nMaskDC, nMaskBitmap
    SetBkColor nDC, TransCol
    SetBkColor nMaskDC, vbBlack
    BitBlt nMaskDC, 0, 0, 32, 32, nDC, 0, 0, vbSrcCopy
End Sub
Public Sub GetIconBits(bBits() As Byte, BpP As Long, nDC As Long, nBitmap As Long, CopyArr() As RGBQUAD)
    Dim BI As BITMAPINFO8Bit
    BI.bmiHeader.biBitCount = BpP
    BI.bmiHeader.biCompression = BI_RGB
    BI.bmiHeader.biPlanes = 1
    BI.bmiHeader.biHeight = 32
    BI.bmiHeader.biWidth = 32
    BI.bmiHeader.biSize = Len(BI.bmiHeader)
    GetDIBits nDC, nBitmap, 0, 32, bBits(0), BI, DIB_RGB_COLORS
    If BpP = 1 Then
        CopyMemory CopyArr(0), BI.bmiColors(0), Len(CopyArr(0)) * 2
    ElseIf BpP = 4 Then
        CopyMemory CopyArr(0), BI.bmiColors(0), Len(CopyArr(0)) * 16
    ElseIf BpP = 8 Then
        CopyMemory CopyArr(0), BI.bmiColors(0), Len(CopyArr(0)) * 256
    End If
End Sub

Function CreateMask(hSrcDC As Long, X As Long, Y As Long, nWidth As Long, nHeight As Long, hDestDC As Long, MaskColor As Long) As Boolean
    Dim MonoDC As Long, MonoBitmap As Long, OldBkColor As Long
    MonoDC = CreateCompatibleDC(hSrcDC)
    MonoBitmap = CreateBitmap(nWidth, nHeight, 1, 1, ByVal 0&)
    If SelectObject(MonoDC, MonoBitmap) = 0 Then Exit Function
    OldBkColor = SetBkColor(hSrcDC, MaskColor)
    BitBlt MonoDC, 0, 0, nWidth, nHeight, hSrcDC, X, Y, vbSrcCopy
    If BitBlt(hDestDC, 0, 0, nWidth, nHeight, MonoDC, 0, 0, vbSrcCopy) = 0 Then Exit Function
    SetBkColor hSrcDC, OldBkColor
    DeleteObject MonoBitmap
    DeleteDC MonoDC
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

