Option Strict Off
Option Explicit On
Friend Class SoundEditor
	Inherits System.Windows.Forms.Form
	'First we have to declare the API call
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Function sndPlaySound Lib "winmm"  Alias "sndPlaySoundA"(ByRef SoundData As Any, ByVal uFlags As Integer) As Integer
	'Then we have to declare the constants that go along with the If PlaySounds  Then sndPlaySound function
	Const SND_ASYNC As Integer = &H1 'ASYNC allows us to play waves with the ability to interrupt
	'Const SND_LOOP = &H8        'LOOP causes to sound to be continuously replayed
	Const SND_NODEFAULT As Integer = &H2 'NODEFAULT causes no sound to be played if the wav can't be found
	'Const SND_SYNC = &H0        'SYNC plays a wave file without returning control to the calling program until it's finished
	'Const SND_NOSTOP = &H10     'NOSTOP ensures that we don't stop another wave from playing
	Const SND_MEMORY As Integer = &H4 'MEMORY plays a wave file stored in memory
	
	Const sndrec As Short = 32
	Const iconrec As Short = 72
	'Const MCrec = 112
	'Const Crec = 116
	'Const zeroexists = 130  'same as iconspresent
	Const soundspresent As Short = 120
	Const lenfirstpart As Short = 141 'sound0 start - 1
	
	Dim LoadRobotPath As String 'Robotens namn utan tillägg
	Dim RecordSound(9) As String
	Dim SoundsExist(9) As Byte
	Dim RecSoundStart(10) As Integer '10 is really the Icon 0 start
	Dim Diff As Integer
	Dim DoCancel As Boolean
	
	Dim snd0() As Byte
	Dim snd1() As Byte
	Dim snd2() As Byte
	Dim snd3() As Byte
	Dim snd4() As Byte
	Dim snd5() As Byte
	Dim snd6() As Byte
	Dim snd7() As Byte
	Dim snd8() As Byte
	Dim snd9() As Byte
	
	'New file system in game aproximately 22:44 31/5 2005
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
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
	
	Private Sub Choose_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Choose_Renamed.Click
		Dim index As Short = Choose_Renamed.GetIndex(eventSender)
		On Error GoTo errhandler
		
		ChooseSoundOpen.ShowDialog()
		Dim sName As String
		
		sName = ChooseSoundOpen.FileName
		
		FileOpen(1, sName, OpenMode.Binary)
		RecordSound(index) = InputString(1, LOF(1))
		loadbinarysound((index))
		FileClose(1)
		
		SoundsExist(index) = 1
		
		Play(index).Visible = True
		Delete(index).Visible = True
		Choose_Renamed(index).Visible = False
		If index = 0 Then
			SoundText(0).Text = "Death"
		ElseIf index = 1 Then 
			SoundText(1).Text = "Collision"
		ElseIf index = 2 Then 
			SoundText(2).Text = "Block"
		ElseIf index = 3 Then 
			SoundText(3).Text = "Hit"
		Else
			SoundText(index).Text = "Sound " & index
		End If
		Play(index).Focus()
		
		Exit Sub
		
errhandler: 
		If Err.Number <> 32755 Then MsgBox(Err.Description, MsgBoxStyle.Exclamation, "Error")
		
	End Sub
	
	Private Sub loadbinarysound(ByRef snr As Short)
		Select Case snr
			Case 0
				ReDim snd0(LOF(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd0, 1)
			Case 1
				ReDim snd1(LOF(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd1, 1)
			Case 2
				ReDim snd2(LOF(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd2, 1)
			Case 3
				ReDim snd3(LOF(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd3, 1)
			Case 4
				ReDim snd4(LOF(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd4, 1)
			Case 5
				ReDim snd5(LOF(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd5, 1)
			Case 6
				ReDim snd6(LOF(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd6, 1)
			Case 7
				ReDim snd7(LOF(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd7, 1)
			Case 8
				ReDim snd8(LOF(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd8, 1)
			Case 9
				ReDim snd9(LOF(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd9, 1)
		End Select
	End Sub
	
	Private Sub loadbinarysoundII(ByRef snr As Short, ByRef start As Integer, ByRef lenght As Integer)
		Select Case snr
			Case 0
				ReDim snd0(lenght)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd0, start)
			Case 1
				ReDim snd1(lenght)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd1, start)
			Case 2
				ReDim snd2(lenght)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd2, start)
			Case 3
				ReDim snd3(lenght)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd3, start)
			Case 4
				ReDim snd4(lenght)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd4, start)
			Case 5
				ReDim snd5(lenght)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd5, start)
			Case 6
				ReDim snd6(lenght)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd6, start)
			Case 7
				ReDim snd7(lenght)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd7, start)
			Case 8
				ReDim snd8(lenght)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd8, start)
			Case 9
				ReDim snd9(lenght)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, snd9, start)
		End Select
	End Sub
	
	Private Sub Delete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Delete.Click
		Dim index As Short = Delete.GetIndex(eventSender)
		SoundsExist(index) = 0
		Delete(index).Visible = False
		Play(index).Visible = False
		Choose_Renamed(index).Visible = True
		SoundText(index).Text = "No Sound"
		
		Choose_Renamed(index).Focus()
	End Sub
	
	Private Sub SoundEditor_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
			Case System.Windows.Forms.Keys.F4
				Me.Close()
				VB6.ShowForm(ChooseIcon, 1, MainWindow)
		End Select
	End Sub
	
	Private Sub SoundEditor_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
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
		
		Dim c As Short
		
		FileOpen(1, LoadRobotPath, OpenMode.Binary)
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, RecSoundStart, sndrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, SoundsExist, soundspresent)
		
		For c = 0 To 9
			If SoundsExist(c) <> 0 Then 'soundS 0-9
				RecordSound(c) = Space(RecSoundStart(c + 1) - RecSoundStart(c))
				
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, RecordSound(c), RecSoundStart(c))
				loadbinarysoundII(c, RecSoundStart(c), Len(RecordSound(c)))
				
				Play(c).Visible = True
				Delete(c).Visible = True
				Choose_Renamed(c).Visible = False
				
				If c = 0 Then
					SoundText(0).Text = "Death"
				ElseIf c = 1 Then 
					SoundText(1).Text = "Collision"
				ElseIf c = 2 Then 
					SoundText(2).Text = "Block"
				ElseIf c = 3 Then 
					SoundText(3).Text = "Hit"
				Else
					SoundText(c).Text = "Sound " & c
				End If
			End If
		Next c
		FileClose(1)
		
		Diff = RecSoundStart(10) - RecSoundStart(0)
		
		'Debug.Print "Läser ljud"
		'For c = 0 To 9  'debug
		'    If SoundsExist(c) = 1 Then Debug.Print vbTab & c & " finns, startar " & RecSoundStart(c) & " slutar " & RecSoundStart(c + 1)
		'Next c
	End Sub
	
	Private Sub SoundEditor_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If Not DoCancel Then PrintSounds()
		DoCancel = False
	End Sub
	
	Private Sub PrintSounds()
		Dim c As Short
		'Dim sSound As String
		Dim sAllsounds As String
		'Dim highestSound As Integer
		
		'Debug.Print "Skriver sounds"
		
		For c = 0 To 9
			If SoundsExist(c) = 1 Then
				RecSoundStart(c) = RecSoundStart(0) + Len(sAllsounds)
				sAllsounds = sAllsounds & RecordSound(c)
				RecSoundStart(c + 1) = RecSoundStart(0) + Len(sAllsounds)
				'highestSound = c
			End If
		Next c
		
		'For c = 0 To 9  'debug
		'    If SoundsExist(c) = 1 Then Debug.Print vbTab & c & " finns, startar " & RecSoundStart(c) & " slutar " & RecSoundStart(c + 1)
		'Next c
		
		'VERKAR FUNGERA
		Dim CodeIconPart As String 'Icons 0 - 9 + machinecode + code
		Dim FirstPart As New VB6.FixedLengthString(lenfirstpart) 'dims space for the first part
		Dim IconCodeStarts(11) As Integer 'old start positions for icons and sounds
		
		FileOpen(1, LoadRobotPath, OpenMode.Binary)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, IconCodeStarts, iconrec) 'gets old start positions for icons and sounds
		
		Diff = Len(sAllsounds) - Diff 'How much longer/shorter is the new soundrec than the old?
		CodeIconPart = Space(LOF(1) - IconCodeStarts(0) - 1)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, CodeIconPart, IconCodeStarts(0)) 'gets icons 0-9 + code + machine code
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, SoundsExist, soundspresent) 'sets which sounds are present
		
		For c = 0 To 11
			IconCodeStarts(c) = IconCodeStarts(c) + Diff 'adjust them for the new sound rec
		Next c
		
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, RecSoundStart, sndrec)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, IconCodeStarts, iconrec) 'Puts the adjusted values back
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, FirstPart.Value, 1) 'gets hardware and rec reference
		FileClose(1)
		
		FileOpen(1, LoadRobotPath, OpenMode.Output)
		PrintLine(1, FirstPart.Value & sAllsounds & CodeIconPart)
		FileClose(1)
		
	End Sub
	
	Private Sub Play_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Play.Click
		Dim index As Short = Play.GetIndex(eventSender)
		'playbinarysound (index)
		Select Case index
			Case 0
				sndPlaySound(snd0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 1
				sndPlaySound(snd1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 2
				sndPlaySound(snd2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 3
				sndPlaySound(snd3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 4
				sndPlaySound(snd4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 5
				sndPlaySound(snd5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 6
				sndPlaySound(snd6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 7
				sndPlaySound(snd7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 8
				sndPlaySound(snd8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 9
				sndPlaySound(snd9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
		End Select
	End Sub
	
	Private Sub TheOKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TheOKButton.Click
		Me.Close()
	End Sub
End Class