Option Strict Off
Option Explicit On
Module mOLELoadPicture
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
	
	
	'_________________________________________________________________________________
	'
	' API Declarations
	'_________________________________________________________________________________
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_WARNING: Structure CBoolean may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function CreateStreamOnHGlobal Lib "ole32" (ByVal hGlobal As Integer, ByVal fDeleteOnRelease As CBoolean, ByRef ppstm As Any) As Integer
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_WARNING: Structure GUID may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'UPGRADE_WARNING: Structure CBoolean may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Function OleLoadPicture Lib "olepro32" (ByRef pStream As Any, ByVal lSize As Integer, ByVal fRunmode As CBoolean, ByRef riid As GUID, ByRef ppvObj As Any) As Integer
	
	'UPGRADE_WARNING: Structure GUID may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Function CLSIDFromString Lib "ole32" (ByVal lpsz As Any, ByRef pclsid As GUID) As Integer
	
	Private Declare Function GlobalAlloc Lib "kernel32" (ByVal uFlags As Integer, ByVal dwBytes As Integer) As Integer
	
	Private Declare Function GlobalLock Lib "kernel32" (ByVal hMem As Integer) As Integer
	
	Private Declare Function GlobalUnlock Lib "kernel32" (ByVal hMem As Integer) As Integer
	
	Private Declare Function GlobalFree Lib "kernel32" (ByVal hMem As Integer) As Integer
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Sub CopyMemory Lib "kernel32"  Alias "RtlMoveMemory"(ByRef Destination As Any, ByRef Source As Any, ByVal Length As Integer)
	
	
	
	'_________________________________________________________________________________
	'
	' UDT Declarations
	'_________________________________________________________________________________
	
	Public Structure GUID ' 16 bytes (128 bits)
		Dim dwData1 As Integer ' 4 bytes
		Dim wData2 As Short ' 2 bytes
		Dim wData3 As Short ' 2 bytes
		<VBFixedArray(7)> Dim abData4() As Byte ' 8 bytes, zero based
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim abData4(7)
		End Sub
	End Structure
	
	Public Enum CBoolean
		cFalse = 0 ' 0&
		cTrue ' 1&
	End Enum
	
	'_________________________________________________________________________________
	'
	' Constants
	'_________________________________________________________________________________
	
	
	'string for IPicture Class
	Private Const sIID_IPicture As String = "{7BF80980-BF32-101A-8BBB-00AA00300CAB}"
	
	'defines what type of memory to allocate
	Private Const GMEM_MOVEABLE As Integer = &H2
	
	'I included error codes for the following
	'to add better error handling in the future...
	
	'Return values for CreateStreamOnHGlobal
	Private Const S_OK As Integer = &H0
	Private Const E_INVALIDARG As Integer = &H80070057
	Private Const E_OUTOFMEMORY As Integer = &H8007000E
	
	'Return values for CLSIDFromString
	Private Const NOERROR As Short = 0
	Private Const CO_E_CLASSSTRING As Integer = &H800401F3
	Private Const REGDB_E_WRITEREGDB As Integer = &H80040151
	
	'_________________________________________________________________________________
	'
	' Function to convert picture data (in string format) to an IPicture object
	'_________________________________________________________________________________
	
	'Public Function PicFromBits(sData As String) As IPicture
	Public Function LoadRobotIcon(ByRef sData As String) As System.Drawing.Image
		
		On Error GoTo Errored
		
		Dim lReturn As Integer 'long return value
		Dim lSize As Integer 'long size of byte array
		Dim hMem As Integer 'handle to allocated memory
		Dim lpMem As Integer 'long pointer to allocated memory
		'UPGRADE_WARNING: Arrays in structure CLSID_IPicture may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim CLSID_IPicture As GUID 'Class Identifier for IPicture
		Dim oIStream As stdole.IUnknown 'IStream Oject
		
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
		CopyMemory(lpMem, sData, lSize)
		Call GlobalUnlock(hMem)
		
		'create an IStream object from the pic data
		'UPGRADE_WARNING: Couldn't resolve default property of object oIStream. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lReturn = CreateStreamOnHGlobal(hMem, CBoolean.cTrue, oIStream)
		If lReturn <> S_OK Then GoTo Errored
		
		'convert our IPicture string to GUID
		'UPGRADE_ISSUE: StrPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		lReturn = CLSIDFromString(StrPtr(sIID_IPicture), CLSID_IPicture)
		If lReturn <> NOERROR Then GoTo Errored
		
		'create an IPicture object from IStream and return LoadRobotIcon as pointer
		'UPGRADE_WARNING: Couldn't resolve default property of object LoadRobotIcon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_ISSUE: ObjPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		lReturn = OleLoadPicture(ObjPtr(oIStream), lSize, CBoolean.cFalse, CLSID_IPicture, LoadRobotIcon)
		If lReturn <> S_OK Then GoTo Errored
		
Errored: 
		
		'clean up if needed
		If hMem <> 0 Then GlobalFree(hMem)
		
	End Function
End Module