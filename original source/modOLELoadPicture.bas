Attribute VB_Name = "mOLELoadPicture"
'______________________________________________________________________________________
'
'   Original Author   : Brad Martinez - http://www.mvps.org
'   Original Site     : http://www.mvps.org/btmtz/gfxfromfrx/
'
'   Modified by       : Danny K. (http://www.xi0n.com)
'   Filename          : modOLELoadPicture.bas
'
'   Description :
'
'           This will give the ability to create a picture object from a String.
'           Uses would include loading a picture from within a binary file, or
'           loading a picture from a winsock packet. Unlike LoadPicture(), this doesnt
'           require you to save the data to a temp file.
'
'______________________________________________________________________________________

Option Explicit

'_________________________________________________________________________________
'
' API Declarations
'_________________________________________________________________________________

Private Declare Function CreateStreamOnHGlobal Lib "ole32" _
        (ByVal hGlobal As Long, _
        ByVal fDeleteOnRelease As CBoolean, _
        ppstm As Any) As Long

Private Declare Function OleLoadPicture Lib "olepro32" _
        (pStream As Any, _
        ByVal lSize As Long, _
        ByVal fRunmode As CBoolean, _
        riid As GUID, _
        ppvObj As Any) As Long

Private Declare Function CLSIDFromString Lib "ole32" ( _
        ByVal lpsz As Any, _
        pclsid As GUID) As Long

Private Declare Function GlobalAlloc Lib "kernel32" ( _
        ByVal uFlags As Long, _
        ByVal dwBytes As Long) As Long
        
Private Declare Function GlobalLock Lib "kernel32" ( _
        ByVal hMem As Long) As Long
        
Private Declare Function GlobalUnlock Lib "kernel32" ( _
        ByVal hMem As Long) As Long

Private Declare Function GlobalFree Lib "kernel32" ( _
        ByVal hMem As Long) As Long

Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" ( _
        Destination As Any, _
        Source As Any, _
        ByVal Length As Long)



'_________________________________________________________________________________
'
' UDT Declarations
'_________________________________________________________________________________

Public Type GUID        ' 16 bytes (128 bits)
  dwData1 As Long       ' 4 bytes
  wData2 As Integer     ' 2 bytes
  wData3 As Integer     ' 2 bytes
  abData4(7) As Byte    ' 8 bytes, zero based
End Type

Public Enum CBoolean
  cFalse = 0            ' 0&
  cTrue                 ' 1&
End Enum

'_________________________________________________________________________________
'
' Constants
'_________________________________________________________________________________


'string for IPicture Class
Private Const sIID_IPicture = "{7BF80980-BF32-101A-8BBB-00AA00300CAB}"

'defines what type of memory to allocate
Private Const GMEM_MOVEABLE = &H2

'I included error codes for the following
'to add better error handling in the future...

'Return values for CreateStreamOnHGlobal
Private Const S_OK = &H0
Private Const E_INVALIDARG = &H80070057
Private Const E_OUTOFMEMORY = &H8007000E

'Return values for CLSIDFromString
Private Const NOERROR = 0
Private Const CO_E_CLASSSTRING = &H800401F3
Private Const REGDB_E_WRITEREGDB = &H80040151

'_________________________________________________________________________________
'
' Function to convert picture data (in string format) to an IPicture object
'_________________________________________________________________________________

'Public Function PicFromBits(sData As String) As IPicture
Public Function LoadRobotIcon(sData As String) As IPicture
    
  On Error GoTo Errored
  
  Dim lReturn As Long               'long return value
  Dim lSize As Long                 'long size of byte array
  Dim hMem  As Long                 'handle to allocated memory
  Dim lpMem  As Long                'long pointer to allocated memory
  Dim CLSID_IPicture As GUID        'Class Identifier for IPicture
  Dim oIStream As stdole.IUnknown   'IStream Oject
      
  'get data size
  lSize = Len(sData)
  If lSize = 0 Then GoTo Errored
  
  'allocate global memory object and return handle
  hMem = GlobalAlloc(GMEM_MOVEABLE, lSize)
  If hMem = 0 Then GoTo Errored
    
  'lock the memory by handle and return pointer to it
  lpMem = GlobalLock(hMem)
  If lpMem = 0 Then GoTo Errored

  'copy the picture data to the memory and unlock the handle
  CopyMemory ByVal lpMem, ByVal sData, lSize
  Call GlobalUnlock(hMem)
      
  'create an IStream object from the pic data
  lReturn = CreateStreamOnHGlobal(hMem, cTrue, oIStream)
  If lReturn <> S_OK Then GoTo Errored
  
  'convert our IPicture string to GUID
  lReturn = CLSIDFromString(StrPtr(sIID_IPicture), CLSID_IPicture)
  If lReturn <> NOERROR Then GoTo Errored
          
  'create an IPicture object from IStream and return LoadRobotIcon as pointer
  lReturn = OleLoadPicture(ByVal ObjPtr(oIStream), lSize, cFalse, CLSID_IPicture, LoadRobotIcon)
  If lReturn <> S_OK Then GoTo Errored
      
Errored:
    
    'clean up if needed
    If hMem <> 0 Then GlobalFree (hMem)
    
End Function





