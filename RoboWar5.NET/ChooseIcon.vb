Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class ChooseIcon
	Inherits System.Windows.Forms.Form
	
	Private Structure Robot 'Private      'Used to load robots
		Dim Energy As Short
		Dim Damage As Short
		Dim Shield As Short
		Dim Speed As Byte
		Dim NNE As Byte
		Dim Turret As Byte
		Dim Bullets As Byte
		Dim Missiles As Byte
		Dim TacNukes As Byte
		Dim Hellbores As Byte
		Dim Mines As Byte
		Dim Stunners As Byte
		Dim Drones As Byte
		Dim Lasers As Byte
		Dim Probes As Byte
		Dim Reserved As Integer
		Dim ShieldIcon As Byte
		Dim DeathIcon As Byte
		Dim HitIcon As Byte
		Dim BlockIcon As Byte
		Dim CollisionIcon As Byte
	End Structure
	
	Dim DoCancel As Boolean
	Dim SelectedIcon As Short
	Dim ShiftDown As Boolean
	Dim PastingIcon As Boolean
	
	Dim TheRobot As Robot
	Dim LoadRobotPath As String
	'Dim sIcons(9) As String
	
	'New RWR file format constants
	Dim RecIconStart(10) As Integer '10 is really the machine code start
	Dim IconsExist(9) As Byte
	'Const sndrec = 32
	Const iconrec As Short = 72
	Const MCrec As Short = 112
	Const Crec As Short = 116
	Const zeroexists As Short = 130 'same as iconspresent
	Const xBitIconSize As Short = 3266 'For 24 bit ico:s it's 3266
	'Const soundspresent = 120
	Dim RecordIcon(9) As String
	
	'undo stuff
	
	
	Dim UndoSystem As Boolean
	Const SYS1 As Boolean = False 'System 1 is for deleting and copy paste
	Const SYS2 As Boolean = True 'System 2 is for cut and paste within the icon factory so both icons (the cutted and the pasted) change back
	
	Dim Ziconchanged As Integer 'For system 1. System 1 is very uncomplex. Ziconchanged is the number of the icon the user changed (0 in case the user has not changed anything).
	Dim thebackupicon As System.Drawing.Image 'For system 1. TheBackupicon is a variable that stores the previous icon itself (that the user can undo back too).
	
	'UPGRADE_WARNING: Lower bound of array bac was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim bac(2) As System.Drawing.Image 'For system 2. System 2 is the same as system 1. It stores the previous icon bac(1) and also the icon before that icon (bac(2))
	'UPGRADE_WARNING: Lower bound of array changed was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim changed(2) As Integer 'For system 2. Same as ZIconchanged. Records which icon that bac 1 & 2 continiues.
	Dim DidCut As Boolean 'For the switching to system 2.
	
	Private Sub ChooseIcon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		Me.Cursor = System.Windows.Forms.Cursors.Default
		PastingIcon = False
	End Sub
	
	Private Sub ChooseIcon_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		SelectedIcon = 0
		ShiftDown = False
		PastingIcon = False
		
		Select Case MainWindow.SelectedRobot
			Case 1
				LoadRobotPath = MainWindow.R1path
			Case 2
				LoadRobotPath = MainWindow.R2path
			Case 3
				LoadRobotPath = MainWindow.R3path
			Case 4
				LoadRobotPath = MainWindow.R4path
			Case 5
				LoadRobotPath = MainWindow.R5path
			Case 6
				LoadRobotPath = MainWindow.R6path
		End Select
		
		FileOpen(1, LoadRobotPath, OpenMode.Binary)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, TheRobot)
		
		If TheRobot.ShieldIcon = 0 Then Icon1Text.Text = "Icon 1"
		If TheRobot.DeathIcon = 0 Then Icon2Text.Text = "Icon 2"
		If TheRobot.CollisionIcon = 0 Then Icon3Text.Text = "Icon 3"
		If TheRobot.BlockIcon = 0 Then Icon4Text.Text = "Icon 4"
		If TheRobot.HitIcon = 0 Then Icon5Text.Text = "Icon 5"
		
		If TheRobot.Turret = 0 Then
			NoneChoosed.Checked = True
		ElseIf TheRobot.Turret = 1 Then 
			LineChoosed.Checked = True
		End If
		
		'ICONS
		Dim c As Short
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, RecIconStart, iconrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, IconsExist, zeroexists)
		
		'Debug.Print "Laddar icons"
		
		For c = 0 To 9
			If IconsExist(c) <> 0 Then 'ICONS 0-9
				RecordIcon(c) = Space(RecIconStart(c + 1) - RecIconStart(c))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, RecordIcon(c), RecIconStart(c))
				'Debug.Print vbTab & c & " finns, startar " & RecIconStart(c) & " slutar " & RecIconStart(c + 1)
				
				IconN(c).Image = LoadRobotIcon(RecordIcon(c))
			End If
		Next c
		FileClose(1)
		
	End Sub
	
	Private Sub ChooseIcon_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If Not DoCancel Then SkrivIcon()
		DoCancel = False
	End Sub
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		Dim res As Byte
		res = MsgBox("Are you sure you don't want to save your changes?", MsgBoxStyle.YesNoCancel, "Don't save changes?")
		If res = MsgBoxResult.Yes Then
			DoCancel = True
		ElseIf res = MsgBoxResult.No Then 
			DoCancel = False
		ElseIf res = MsgBoxResult.Cancel Then 
			DoCancel = False
			Exit Sub
		End If
		
		Me.Close()
	End Sub
	
	Private Sub Icon1Text_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Icon1Text.Click
		If Icon1Text.Text = "Shield" Then
			Icon1Text.Text = "Icon 1"
			TheRobot.ShieldIcon = 0
		Else
			Icon1Text.Text = "Shield"
			TheRobot.ShieldIcon = 1
		End If
		
	End Sub
	
	Private Sub Icon2Text_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Icon2Text.Click
		If Icon2Text.Text = "Death" Then
			Icon2Text.Text = "Icon 2"
			TheRobot.DeathIcon = 0
		Else
			Icon2Text.Text = "Death"
			TheRobot.DeathIcon = 1
		End If
	End Sub
	
	Private Sub Icon3Text_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Icon3Text.Click
		If Icon3Text.Text = "Collision" Then
			Icon3Text.Text = "Icon 3"
			TheRobot.CollisionIcon = 0
		Else
			Icon3Text.Text = "Collision"
			TheRobot.CollisionIcon = 1
		End If
	End Sub
	
	Private Sub Icon4Text_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Icon4Text.Click
		If Icon4Text.Text = "Block" Then
			Icon4Text.Text = "Icon 4"
			TheRobot.BlockIcon = 0
		Else
			Icon4Text.Text = "Block"
			TheRobot.BlockIcon = 1
		End If
	End Sub
	
	Private Sub Icon5Text_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Icon5Text.Click
		If Icon5Text.Text = "Hit" Then
			Icon5Text.Text = "Icon 5"
			TheRobot.HitIcon = 0
		Else
			Icon5Text.Text = "Hit"
			TheRobot.HitIcon = 1
		End If
	End Sub
	
	Private Sub SkrivIcon()
		'RefreshIcon (MainWindow.SelectedRobot)
		If MainWindow.R1path = LoadRobotPath Then RefreshIcon((1)) 'It doesn't mater if
		If MainWindow.R2path = LoadRobotPath Then RefreshIcon((2)) 'it refreshes non-existing robots
		If MainWindow.R3path = LoadRobotPath Then RefreshIcon((3)) '(I think =S)
		If MainWindow.R4path = LoadRobotPath Then RefreshIcon((4))
		If MainWindow.R5path = LoadRobotPath Then RefreshIcon((5))
		If MainWindow.R6path = LoadRobotPath Then RefreshIcon((6))
		
		''Skriv ikonerna
		Dim c As Short
		'Dim sicon As String
		Dim sAllIcons As String
		Dim highesticon As Short
		
		'Debug.Print "Skriver icons"
		
		For c = 0 To 9
			If IconsExist(c) = 1 Then
				RecIconStart(c) = RecIconStart(0) + Len(sAllIcons)
				sAllIcons = sAllIcons & RecordIcon(c)
				RecIconStart(c + 1) = RecIconStart(0) + Len(sAllIcons)
				highesticon = c
			End If
		Next c
		
		'FUNGERAR MEN ÄR NÅGOT LÅNGSAM
		Dim MCStart As Integer 'Old MC Start
		Dim Cstart As Integer 'Old CStart
		Dim CodePart As String
		Dim FirstPart As String
		
		FileOpen(1, LoadRobotPath, OpenMode.Binary)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, MCStart, MCrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, Cstart, Crec)
		CodePart = Space(LOF(1) - MCStart - 1)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, CodePart, MCStart)
		
		Cstart = Cstart - MCStart 'Len of the code
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, TheRobot, 1) 'The icon settings must be saved
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, IconsExist, zeroexists)
		
		If IconsExist(highesticon) Then
			Cstart = RecIconStart(highesticon + 1) + Cstart
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(1, RecIconStart, iconrec)
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(1, RecIconStart(highesticon + 1), MCrec)
			
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(1, sAllIcons, RecIconStart(0))
			FirstPart = Space(RecIconStart(highesticon + 1) - 1)
		Else 'if it doesn't have any icons - RecIconStart / sAllIcons isn't needed because the user has deleted all icons
			Cstart = RecIconStart(0) + Cstart
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(1, RecIconStart(0), MCrec)
			FirstPart = Space(RecIconStart(0) - 1) 'The get/space sizers seems to work better with -1?
		End If
		
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, Cstart, Crec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, FirstPart, 1) 'Be very carefull which order we put the get put statements considering this one
		FileClose(1)
		
		FileOpen(1, LoadRobotPath, OpenMode.Output)
		PrintLine(1, FirstPart & CodePart)
		FileClose(1)
		
	End Sub
	
	Private Function Icon2String() As String
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\WrittenIcon", OpenMode.Binary)
		Icon2String = InputString(1, LOF(1))
		FileClose(1)
	End Function
	
	Private Sub IconZeroDelete()
		Select Case MainWindow.SelectedRobot
			Case 1
				MainWindow.R1Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\1#0.ico")
			Case 2
				MainWindow.R2Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\2#0.ico")
			Case 3
				MainWindow.R3Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\3#0.ico")
			Case 4
				MainWindow.R4Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\4#0.ico")
			Case 5
				MainWindow.R5Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\5#0.ico")
			Case 6
				MainWindow.R6Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\6#0.ico")
		End Select
	End Sub
	
	Private Sub IconZeroRefresh()
		Select Case MainWindow.SelectedRobot
			Case 1
				MainWindow.R1Icon.Image = LoadRobotIcon(RecordIcon(0))
			Case 2
				MainWindow.R2Icon.Image = LoadRobotIcon(RecordIcon(0))
			Case 3
				MainWindow.R3Icon.Image = LoadRobotIcon(RecordIcon(0))
			Case 4
				MainWindow.R4Icon.Image = LoadRobotIcon(RecordIcon(0))
			Case 5
				MainWindow.R5Icon.Image = LoadRobotIcon(RecordIcon(0))
			Case 6
				MainWindow.R6Icon.Image = LoadRobotIcon(RecordIcon(0))
		End Select
	End Sub
	
	
	Private Sub RefreshIcon(ByRef WhichRobot As Short)
		
		Select Case WhichRobot 'flyttat hit pga att robotar blev raderade vid fel annars
			Case 1
				MainWindow.Robot1ShieldIcon = TheRobot.ShieldIcon
				MainWindow.Robot1HitIcon = TheRobot.HitIcon
				MainWindow.Robot1BlockIcon = TheRobot.BlockIcon
				MainWindow.Robot1DeathIcon = TheRobot.DeathIcon
				MainWindow.Robot1CollisionIcon = TheRobot.CollisionIcon
			Case 2
				MainWindow.Robot2ShieldIcon = TheRobot.ShieldIcon
				MainWindow.Robot2HitIcon = TheRobot.HitIcon
				MainWindow.Robot2BlockIcon = TheRobot.BlockIcon
				MainWindow.Robot2DeathIcon = TheRobot.DeathIcon
				MainWindow.Robot2CollisionIcon = TheRobot.CollisionIcon
			Case 3
				MainWindow.Robot3ShieldIcon = TheRobot.ShieldIcon
				MainWindow.Robot3HitIcon = TheRobot.HitIcon
				MainWindow.Robot3BlockIcon = TheRobot.BlockIcon
				MainWindow.Robot3DeathIcon = TheRobot.DeathIcon
				MainWindow.Robot3CollisionIcon = TheRobot.CollisionIcon
			Case 4
				MainWindow.Robot4ShieldIcon = TheRobot.ShieldIcon
				MainWindow.Robot4HitIcon = TheRobot.HitIcon
				MainWindow.Robot4BlockIcon = TheRobot.BlockIcon
				MainWindow.Robot4DeathIcon = TheRobot.DeathIcon
				MainWindow.Robot4CollisionIcon = TheRobot.CollisionIcon
			Case 5
				MainWindow.Robot5ShieldIcon = TheRobot.ShieldIcon
				MainWindow.Robot5HitIcon = TheRobot.HitIcon
				MainWindow.Robot5BlockIcon = TheRobot.BlockIcon
				MainWindow.Robot5DeathIcon = TheRobot.DeathIcon
				MainWindow.Robot5CollisionIcon = TheRobot.CollisionIcon
			Case 6
				MainWindow.Robot6ShieldIcon = TheRobot.ShieldIcon
				MainWindow.Robot6HitIcon = TheRobot.HitIcon
				MainWindow.Robot6BlockIcon = TheRobot.BlockIcon
				MainWindow.Robot6DeathIcon = TheRobot.DeathIcon
				MainWindow.Robot6CollisionIcon = TheRobot.CollisionIcon
		End Select
		
	End Sub
	
	
	
	
	
	'UPGRADE_WARNING: Event LineChoosed.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub LineChoosed_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LineChoosed.CheckedChanged
		If eventSender.Checked Then
			TheRobot.Turret = 1
		End If
	End Sub
	
	'UPGRADE_WARNING: Event DotChoosed.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub DotChoosed_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DotChoosed.CheckedChanged
		If eventSender.Checked Then
			TheRobot.Turret = 2
		End If
	End Sub
	
	'UPGRADE_WARNING: Event NoneChoosed.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub NoneChoosed_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NoneChoosed.CheckedChanged
		If eventSender.Checked Then
			TheRobot.Turret = 0
		End If
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		Me.Close()
	End Sub
	
	Private Sub ChooseIcon_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.D Then
			Me.Cursor = System.Windows.Forms.Cursors.Default
			ShiftDown = False
		End If
	End Sub
	
	Private Sub WriteIco()
		' This sub converts a bmp or an ico with transparency
		
		Dim pixelx As Byte
		Dim pixely As Byte
		Dim backwardspixel As Short
		backwardspixel = 31
		
		For pixely = 0 To 31
			For pixelx = 0 To 31 'from right to left
				'UPGRADE_ISSUE: PictureBox method PicBmp.Point was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				If PicBmp.Point(pixelx, pixely) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) Then
					'UPGRADE_ISSUE: PictureBox method PicBmp.PSet was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					PicBmp.PSet (pixelx, pixely), 8438015
				Else
					Exit For
				End If
			Next pixelx
			For backwardspixel = -31 To 0
				'UPGRADE_ISSUE: PictureBox method PicBmp.Point was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				If PicBmp.Point(-backwardspixel, pixely) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) Then
					'UPGRADE_ISSUE: PictureBox method PicBmp.PSet was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					PicBmp.PSet (-backwardspixel, pixely), 8438015
				Else
					Exit For
				End If
			Next backwardspixel
		Next pixely
		
		''''''side
		For pixelx = 0 To 31
			For pixely = 0 To 31 'from right to left
				'UPGRADE_ISSUE: PictureBox method PicBmp.Point was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				If PicBmp.Point(pixelx, pixely) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) Or PicBmp.Point(pixelx, pixely) = 8438015 Then
					'UPGRADE_ISSUE: PictureBox method PicBmp.PSet was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					PicBmp.PSet (pixelx, pixely), 8438015
				Else
					Exit For
				End If
			Next pixely
			For backwardspixel = -31 To 0
				'UPGRADE_ISSUE: PictureBox method PicBmp.Point was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				If PicBmp.Point(pixelx, -backwardspixel) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) Or PicBmp.Point(pixelx, -backwardspixel) = 8438015 Then
					'UPGRADE_ISSUE: PictureBox method PicBmp.PSet was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					PicBmp.PSet (pixelx, -backwardspixel), 8438015
				Else
					Exit For
				End If
			Next backwardspixel
		Next pixelx
		'8438015 could be used if the user wants transparency somewhere else but in the edges
		'8438015 is an extremly ungy color
		
		'''Here starts the code takes from vbhelper.com (I don't know how to write .ico:s)
		Dim RET As Object
		Dim bmpPicInfo As BITMAPINFO
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		With bmpPicInfo.bmiHeader
			.biBitCount = 24
			.biCompression = BI_RGB
			.biPlanes = 1
			.biSize = Len(bmpPicInfo.bmiHeader)
			.biWidth = 32
			.biHeight = 32
		End With
		IconInfo.iDC = CreateCompatibleDC(0)
		IconInfo.iWidth = 32
		IconInfo.iHeight = 32
		bi24BitInfo.bmiHeader.biWidth = 32
		bi24BitInfo.bmiHeader.biHeight = 32
		'UPGRADE_WARNING: Couldn't resolve default property of object bmpPicInfo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		IconInfo.iBitmap = CreateDIBSection(IconInfo.iDC, bmpPicInfo, DIB_RGB_COLORS, 0, 0, 0)
		SelectObject(IconInfo.iDC, IconInfo.iBitmap)
		'UPGRADE_ISSUE: Constant vbSrcCopy was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: PictureBox property PicBmp.hdc was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		'UPGRADE_WARNING: Couldn't resolve default property of object RET. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		RET = BitBlt(IconInfo.iDC, 0, 0, 32, 32, PicBmp.hdc, 0, 0, vbSrcCopy)
		'UPGRADE_WARNING: Couldn't resolve default property of object RET. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If RET = 0 Then
			MsgBox("Unable to BitBlt Picture.")
			Exit Sub
		End If
		System.Windows.Forms.Application.DoEvents()
		SaveIcon(My.Application.Info.DirectoryPath & "\miscdata\WrittenIcon", IconInfo.iDC, IconInfo.iBitmap, 24) ', CLng(SaveTypeIn)"
		IconInfo.iFileName = My.Application.Info.DirectoryPath & "\miscdata\WrittenIcon" '24 = antal bitar
		DeleteDC(IconInfo.iDC)
		DeleteObject(IconInfo.iBitmap)
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		System.Windows.Forms.Application.DoEvents()
	End Sub
	
	Private Sub ChooseIcon_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case System.Windows.Forms.Keys.F1
				Me.Close()
			Case System.Windows.Forms.Keys.F2
				Me.Close()
				VB6.ShowForm(DraftingBoard, 1, MainWindow)
			Case System.Windows.Forms.Keys.F3
				Me.Close()
				VB6.ShowForm(HardwareWindow, 1, MainWindow)
			Case System.Windows.Forms.Keys.F5
				Me.Close()
				VB6.ShowForm(SoundEditor, 1, MainWindow)
			Case System.Windows.Forms.Keys.D
				'UPGRADE_ISSUE: Form property ChooseIcon.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
				Me.Cursor = vbCustom
				ShiftDown = True
				PastingIcon = False
			Case System.Windows.Forms.Keys.V And ((Shift And VB6.ShiftConstants.CtrlMask) > 0) And (CDbl(CObj(My.Computer.Clipboard.GetImage())) <> 0)
				Me.Cursor = System.Windows.Forms.Cursors.Cross
				PastingIcon = True
				ShiftDown = False
			Case System.Windows.Forms.Keys.Escape
				Me.Cursor = System.Windows.Forms.Cursors.Default
				PastingIcon = False
				ShiftDown = False
			Case System.Windows.Forms.Keys.C And ((Shift And VB6.ShiftConstants.CtrlMask) > 0) And (Not PastingIcon)
				copyico()
			Case System.Windows.Forms.Keys.X And ((Shift And VB6.ShiftConstants.CtrlMask) > 0) And (Not PastingIcon)
				cutico()
			Case System.Windows.Forms.Keys.Z And ((Shift And VB6.ShiftConstants.CtrlMask) > 0) And (Not PastingIcon)
				If Ziconchanged <> 0 Then restoreicon()
		End Select
	End Sub
	
	Private Sub copyico()
		If CDbl(CObj(IconN(SelectedIcon).Image)) <> 0 Then
			SwitchSys1()
			My.Computer.Clipboard.Clear()
			PicPst.Image = Nothing
			'UPGRADE_ISSUE: PictureBox method PicPst.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			PicPst.PaintPicture(IconN(SelectedIcon), 0, 0)
			'UPGRADE_ISSUE: PictureBox property PicPst.Image was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			PicPst.Image = PicPst.Image
			My.Computer.Clipboard.SetImage(PicPst.Image)
		End If
	End Sub
	
	Private Sub cutico()
		If CDbl(CObj(IconN(SelectedIcon).Image)) <> 0 Then
			SwitchSys1()
			DidCut = True
			backupicon((SelectedIcon))
			IconsExist(SelectedIcon) = 0
			My.Computer.Clipboard.Clear()
			PicPst.Image = Nothing
			'UPGRADE_ISSUE: PictureBox method PicPst.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			PicPst.PaintPicture(IconN(SelectedIcon), 0, 0)
			'UPGRADE_ISSUE: PictureBox property PicPst.Image was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			PicPst.Image = PicPst.Image
			My.Computer.Clipboard.SetImage(PicPst.Image)
			IconN(SelectedIcon).Image = Nothing
			If SelectedIcon = 0 Then IconZeroDelete()
		End If
	End Sub
	
	Private Sub IconN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles IconN.Click
		Dim index As Short = IconN.GetIndex(eventSender)
		Dim sicon As String
		Dim p As System.Drawing.Image
		If ShiftDown Then
			backupicon((index))
			SwitchSys1()
			IconN(index).Image = Nothing
			Shape(index).BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent
			IconsExist(index) = 0
			If index = 0 Then IconZeroDelete()
			Exit Sub
		ElseIf PastingIcon Then 
			backupicon((index))
			If DidCut Then UndoSystem = SYS2 Else SwitchSys1()
			DidCut = False 'Here to prevent that several icons change when the user cuts and does paste multiple times after the cut
			'If UndoSystem = SYS2 Then Beep 'DEBUGG
			
			p = My.Computer.Clipboard.GetImage()
			PicBmp.Image = p
			WriteIco()
			sicon = Icon2String
			' If we paste an icon, it's _allways_ the same size
			' that stops the problem with icons getting 2 bytes bigger every time they're pasted
			RecordIcon(index) = VB.Left(sicon, xBitIconSize)
			'RecordIcon(index) = sicon 'Left$(sicon, Len(sicon) - 2), the old solution, it destroyed 1 bit icons pretty badly
			
			IconN(index).Image = p
			Me.Cursor = System.Windows.Forms.Cursors.Default
			PastingIcon = False
			IconsExist(index) = 1
			If index = 0 Then IconZeroRefresh()
		End If
		
		Dim c As Short
		
		SelectedIcon = index
		Shape(index).BorderColor = System.Drawing.Color.Black
		
		For c = 0 To 9
			If c <> index Then Shape(c).BorderColor = System.Drawing.ColorTranslator.FromOle(&HA76B43)
		Next c
		
	End Sub
	
	Private Sub backupicon(ByRef ziconnumber As Integer)
		'''''' System 1
		Ziconchanged = ziconnumber
		thebackupicon = IconN(ziconnumber)
		
		'''''' System 2
		bac(2) = bac(1)
		changed(2) = changed(1)
		
		bac(1) = IconN(ziconnumber)
		changed(1) = ziconnumber
	End Sub
	
	Private Sub SwitchSys1()
		UndoSystem = SYS1
		DidCut = False
	End Sub
	
	Private Sub restoreicon()
		If UndoSystem = SYS1 Then
			IconN(Ziconchanged).Image = thebackupicon
			If CDbl(CObj(thebackupicon)) = 0 Then IconsExist(Ziconchanged) = 0 Else IconsExist(Ziconchanged) = 1
		Else
			IconN(changed(1)).Image = bac(1)
			IconN(changed(2)).Image = bac(2)
			If CDbl(CObj(IconN(changed(1)).Image)) = 0 Then IconsExist(changed(1)) = 0 Else IconsExist(changed(1)) = 1
			If CDbl(CObj(IconN(changed(2)).Image)) = 0 Then IconsExist(changed(2)) = 0 Else IconsExist(changed(2)) = 1
			SwitchSys1()
		End If
		
		'    Debug.Print IconN(ziconchanged)
		'    Debug.Print IconN(changed(1))
		'    Debug.Print IconN(changed(2))
	End Sub
End Class