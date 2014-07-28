Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class DraftingBoard
	Inherits System.Windows.Forms.Form
	
	' AND YET MORE DECLARATIONS
	Private Declare Function LockWindowUpdate Lib "user32" (ByVal hwnd As Integer) As Integer
	Private Declare Function RoboTranslate Lib "roboc.dll" (ByVal RoboTalkCodePtr As String, ByVal cCodePtr As String) As Integer
	Const EM_LINEINDEX As Integer = &HBB
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Function SendMessage Lib "user32"  Alias "SendMessageA"(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Any) As Integer
	
	'From Arena, when robot bugs
	Public GotoInstNr As Short
	
	'Doubleclicking
	Dim HasDCl As Boolean
	
	'Interface things
	Dim sFind As String
	Dim limit1 As Short
	Dim limit2 As Short
	Dim TheXYPos As Short
	
	'Syntax Coloring
	Dim SyntaxColoringCache As Boolean
	Const CommentRed As Short = 0 'Fungerar
	Const CommentBlue As Short = 70
	Const CommentGreen As Short = 140
	Const LabelRed As Short = 0
	Const LabelBlue As Short = 150
	Const LabelGreen As Short = 25
	
	'Instructions
	Const INSTRUCTIONLIMIT As Short = 5000
	Const iUNKOWN As Short = -32768
	
	'Robot File things
	Dim HasCanceled As Boolean
	Dim PathToRobot As String
	Dim IsCRobot As Boolean
	
	'Robot File things - New File System
	Dim Cstart As Integer
	Dim MStart As Integer
	Const MCrec As Short = 112
	Const Crec As Short = 116
	Const CPosrec As Short = 28
	Const RLock As Short = 140
	Const CRobotRec As Short = 141
	Const DroneRec As Short = 16
	
	Public Sub AboutBeginners_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AboutBeginners.Click
		Dim StoreSelStart As Integer
		StoreSelStart = RobotCode.SelectionStart + Len("# A B O U T   T H E   B E G I N N E R S   M E N U" & vbCr & "# In beginners menu you can select different things that" & vbCr & "# your robot shall do. With help of the commands" & vbCr & "# in the beginners menu, you can create your own robot very fast." & vbCr & "# Then you can go back to the manual and find ways to improve the bot." & vbCr & vbCr)
		RobotCode.Text = "# A B O U T   T H E   B E G I N N E R S   M E N U" & vbCr & "# In beginners menu you can select different things that" & vbCr & "# your robot shall do. With help of the commands" & vbCr & "# in the beginners menu, you can create your own robot very fast." & vbCr & "# Then you can go back to the manual and find ways to improve the bot." & vbCr & vbCr & RobotCode.Text
		RobotCode.SelectionStart = StoreSelStart
	End Sub
	
	Public Sub AimLoop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AimLoop.Click
		Dim NumberOfDegrees As Object
		Dim AimLoop As String
		Dim AimVal As Short
		Dim res As Short
		
redo: 
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		NumberOfDegrees = InputBox("Note: as soon as I find the source of Justin Blachards" & vbLf & "Aim Loop Generator, I'll built it in here." & vbLf & "Anyway, " & vbLf & vbLf & "How many degrees between each check?", "Aim Loop", CStr(10))
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If NumberOfDegrees = "" Then GoTo AbortCreation
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		NumberOfDegrees = Val(NumberOfDegrees)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If NumberOfDegrees > 359 Or NumberOfDegrees < 1 Then
			If MsgBox("How many degrees between each check must range from 1 to 359", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical, "Aimloop Error") = MsgBoxResult.Cancel Then GoTo AbortCreation
			GoTo redo
		End If
		
		Do While AimVal < 30
			AimLoop = AimLoop & AimVal & " aim' store" & Chr(10)
			AimLoop = AimLoop & (AimVal + 30) & " aim' store" & Chr(10)
			AimLoop = AimLoop & (AimVal + 60) & " aim' store" & Chr(10)
			AimLoop = AimLoop & (AimVal + 90) & " aim' store" & Chr(10)
			AimLoop = AimLoop & (AimVal + 120) & " aim' store" & Chr(10)
			AimLoop = AimLoop & (AimVal + 150) & " aim' store" & Chr(10)
			AimLoop = AimLoop & (AimVal + 180) & " aim' store" & Chr(10)
			AimLoop = AimLoop & (AimVal + 210) & " aim' store" & Chr(10)
			AimLoop = AimLoop & (AimVal + 240) & " aim' store" & Chr(10)
			AimLoop = AimLoop & (AimVal + 270) & " aim' store" & Chr(10)
			AimLoop = AimLoop & (AimVal + 300) & " aim' store" & Chr(10)
			AimLoop = AimLoop & (AimVal + 330) & " aim' store" & Chr(10)
			'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			AimVal = AimVal + NumberOfDegrees
		Loop 
		
		res = MsgBox(AimLoop, MsgBoxStyle.YesNoCancel, "Is this ok?")
		If res = MsgBoxResult.Cancel Then GoTo AbortCreation
		
		Dim insert As String
		insert = AimLoop
		
		AimLoop = ""
		AimVal = 0
		
		If res = MsgBoxResult.No Then GoTo redo
		
		'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.SelectedText = insert
		
AbortCreation: 
		RobotCode.SelectionStart = RobotCode.SelectionStart
		RobotCode.Focus()
	End Sub
	
	Public Sub AimLoopAnimated_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AimLoopAnimated.Click
		Dim NumberOfDegrees As Object
		Dim AimLoop As String
		Dim AimVal As Short
		Dim res As Short
		Dim IconsPerChronon As Object
		
redo: 
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		NumberOfDegrees = InputBox("This creates an aim loop that switches" & vbLf & "from icon 2 to 9." & vbLf & vbLf & "How many degrees between each check?", "Animated Aim Loop", CStr(10))
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If NumberOfDegrees = "" Then GoTo AbortCreation
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		NumberOfDegrees = CShort(NumberOfDegrees)
		
redospeed: 
		'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		IconsPerChronon = InputBox("A new icon will be viewed every x chronon." & vbLf & "Please specify x" & vbLf & "(= speed of the animation, lower is faster)", "Aim Loop", CStr(4))
		'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IconsPerChronon = "" Then GoTo AbortCreation
		'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		IconsPerChronon = Val(IconsPerChronon)
		'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IconsPerChronon > 5 Or IconsPerChronon < 1 Then
			If MsgBox("The speed must range from 1 to 5", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical, "Icon Error") = MsgBoxResult.Cancel Then GoTo AbortCreation
			GoTo redospeed
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If NumberOfDegrees = 0 Then GoTo AbortCreation 'Prevent eternal loop = Freezing
		
		Dim procposition As Short
		Dim iconnumber As Short
		Dim ProSpeed As Short
		Select Case MainWindow.SelectedRobot
			Case 1
				ProSpeed = MainWindow.Robot1ProSpeed
			Case 2
				ProSpeed = MainWindow.Robot2ProSpeed
			Case 3
				ProSpeed = MainWindow.Robot3ProSpeed
			Case 4
				ProSpeed = MainWindow.Robot4ProSpeed
			Case 5
				ProSpeed = MainWindow.Robot5ProSpeed
			Case 6
				ProSpeed = MainWindow.Robot6ProSpeed
		End Select
		
		iconnumber = 2
		Do While AimVal < 180
			procposition = procposition + 1
			
			'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If procposition >= ProSpeed * IconsPerChronon Then
				AimLoop = AimLoop & AimVal & vbCr & " icon" & iconnumber & vbCr
				procposition = 0 : iconnumber = iconnumber + 1
				If iconnumber >= 10 Then iconnumber = 2
			Else
				AimLoop = AimLoop & AimVal
			End If
			
			procposition = procposition + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If procposition >= ProSpeed * IconsPerChronon Then
				AimLoop = AimLoop & " aim'" & vbCr & " icon" & iconnumber & vbCr
				procposition = 0 : iconnumber = iconnumber + 1
				If iconnumber >= 10 Then iconnumber = 2
			Else
				AimLoop = AimLoop & " aim'"
			End If
			
			procposition = procposition + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If procposition >= ProSpeed * IconsPerChronon Then
				AimLoop = AimLoop & " store " & vbCr & " icon" & iconnumber & vbCr
				procposition = 0 : iconnumber = iconnumber + 1
				If iconnumber >= 10 Then iconnumber = 2
			Else
				AimLoop = AimLoop & " store "
			End If
			
			'''''''
			AimVal = AimVal + 180
			procposition = procposition + 1
			
			'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If procposition >= ProSpeed * IconsPerChronon Then
				AimLoop = AimLoop & AimVal & vbCr & " icon" & iconnumber & vbCr
				procposition = 0 : iconnumber = iconnumber + 1
				If iconnumber >= 10 Then iconnumber = 2
			Else
				AimLoop = AimLoop & AimVal
			End If
			
			procposition = procposition + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If procposition >= ProSpeed * IconsPerChronon Then
				AimLoop = AimLoop & " aim'" & vbCr & " icon" & iconnumber & vbCr
				procposition = 0 : iconnumber = iconnumber + 1
				If iconnumber >= 10 Then iconnumber = 2
			Else
				AimLoop = AimLoop & " aim'"
			End If
			
			procposition = procposition + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If procposition >= ProSpeed * IconsPerChronon Then
				AimLoop = AimLoop & " store " & vbCr & " icon" & iconnumber & vbCr
				procposition = 0 : iconnumber = iconnumber + 1
				If iconnumber >= 10 Then iconnumber = 2
			Else
				AimLoop = AimLoop & " store "
			End If
			AimVal = AimVal - 180
			'''''''
			'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			AimVal = AimVal + NumberOfDegrees
		Loop 
		'''' Check some extra degrees to complete the animation
		Randomize()
		Do While iconnumber < 10
			procposition = procposition + 1
			AimVal = Int((359 + 1) * Rnd())
			'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If procposition >= ProSpeed * IconsPerChronon Then
				AimLoop = AimLoop & AimVal & vbCr & " icon" & iconnumber & vbCr
				procposition = 0 : iconnumber = iconnumber + 1
			Else
				AimLoop = AimLoop & AimVal
			End If
			procposition = procposition + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If procposition >= ProSpeed * IconsPerChronon Then
				AimLoop = AimLoop & " aim'" & vbCr & " icon" & iconnumber & vbCr
				procposition = 0 : iconnumber = iconnumber + 1
			Else
				AimLoop = AimLoop & " aim'"
			End If
			procposition = procposition + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object IconsPerChronon. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If procposition >= ProSpeed * IconsPerChronon Then
				AimLoop = AimLoop & " store " & vbCr & " icon" & iconnumber & vbCr
				procposition = 0 : iconnumber = iconnumber + 1
			Else
				AimLoop = AimLoop & " store "
			End If
		Loop 
		'''''
		res = MsgBox(AimLoop, MsgBoxStyle.YesNoCancel, "Is this ok?")
		If res = MsgBoxResult.Cancel Then GoTo AbortCreation
		Dim insert As String
		insert = AimLoop
		AimLoop = ""
		AimVal = 0
		If res = MsgBoxResult.No Then GoTo redo
		'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.SelectedText = insert
AbortCreation: 
		RobotCode.SelectionStart = RobotCode.SelectionStart
		RobotCode.Focus()
	End Sub
	
	Public Sub Arena_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Arena.Click
		Me.Close()
	End Sub
	
	Public Sub AutoCompile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AutoCompile.Click
		Dim YesOrNo As Boolean
		If AutoCompile.Checked Then
			AutoCompile.Checked = False
			YesOrNo = False
		Else
			AutoCompile.Checked = True
			YesOrNo = True
		End If
		
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, YesOrNo, 8000)
	End Sub
	
	Public Sub BeginnersCollision_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BeginnersCollision.Click
		Dim counter As Short
		
		counter = InStr(RobotCode.Text, "MainLoop:")
		
		If counter Then
			RobotCode.SelectionStart = counter + 9
			'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			RobotCode.SelectedText = "collision kill if" & vbCr
			
			If InStr(RobotCode.Text, "Kill:") = 0 Then
				RobotCode.SelectionStart = Len(RobotCode.Text)
				'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				RobotCode.SelectedText = vbCr & vbCr & "Kill:" & vbCr & "aim 45 + aim' store" & vbCr & "range strongshot if" & vbCr & "collision not goback if" & vbCr & "kill jump"
			End If
			If InStr(RobotCode.Text, "GoBack:") = 0 Then
				RobotCode.SelectionStart = Len(RobotCode.Text)
				'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				RobotCode.SelectedText = vbCr & vbCr & "GoBack:" & vbCr & "drop" & vbCr & "return"
			End If
			If InStr(RobotCode.Text, "StrongShot:") = 0 Then
				RobotCode.SelectionStart = Len(RobotCode.Text)
				'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				RobotCode.SelectedText = vbCr & vbCr & "StrongShot:" & vbCr & "100 fire' store" & vbCr & "50 fire' store" & vbCr & "return"
			End If
			
			RobotCode.SelectionStart = counter + 9 + Len("collision kill if" & vbCr)
		End If
		
	End Sub
	
	Public Sub BeginnersMain_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BeginnersMain.Click
		If InStr(RobotCode.Text, "MainLoop:") Then
			MsgBox("You already have a mainloop." & vbCr & "If you would like to create a new loop, Then type in:" & vbCr & vbCr & "MyLoopsName:" & vbCr & "#Put the things you want you loop to do here" & vbCr & "MyLoopsName Jump" & vbCr & vbCr & "at the bottom of the code.")
		Else
			'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			RobotCode.SelectedText = vbCr & "MainLoop:" & vbCr & vbCr & "mainloop jump" & vbTab & vbTab & "# Jumps back to the " & Chr(34) & "MainLoop" & Chr(34) & " label"
		End If
	End Sub
	
	Public Sub BeginnersMove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BeginnersMove.Click
		Dim counter As Short
		counter = InStr(RobotCode.Text, "MainLoop:") - 1
		
		Dim RET As Integer
		If counter = -1 Then
			RET = RobotCode.SelectionStart
			RobotCode.SelectionStart = 0
			'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			RobotCode.SelectedText = "3 speedx' store" & vbTab & vbTab & "# Set speed in x direction to 3" & vbCr & "3 speedy' store" & vbTab & vbTab & "# Set speed in y direction to 3" & vbCr
			RobotCode.SelectionStart = RET + Len("3 speedx' store" & vbTab & vbTab & "# Set speed in x direction to 3" & vbCr & "3 speedy' store" & vbTab & vbTab & "# Set speed in y direction to 3" & vbCr)
		Else
			RobotCode.SelectionStart = counter
			'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			RobotCode.SelectedText = vbCr & "3 speedx' store" & vbTab & vbTab & "# Set speed in x direction to 3" & vbCr & "3 speedy' store" & vbTab & vbTab & "# Set speed in y direction to 3" & vbCr & vbCr
			RobotCode.SelectionStart = counter + Len("3 speedx' store" & vbTab & vbTab & "# Set speed in x direction to 3" & vbCr & "3 speedy' store" & vbTab & vbTab & "# Set speed in y direction to 3" & vbCr)
		End If
		
	End Sub
	
	Public Sub BeginnersRange_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BeginnersRange.Click
		Dim counter As Short
		
		counter = InStr(RobotCode.Text, "MainLoop:")
		
		If counter Then
			RobotCode.SelectionStart = counter + 9
			'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			RobotCode.SelectedText = "range 0 > shoot if" & vbTab & vbTab & "# If Range is above zero then go to " & Chr(34) & "Shoot" & Chr(34) & vbCr
			
			If InStr(RobotCode.Text, "Shoot:") = 0 Then
				RobotCode.SelectionStart = Len(RobotCode.Text)
				'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				RobotCode.SelectedText = vbCr & vbCr & "Shoot:" & vbCr & "energy fire' store" & vbTab & vbTab & "# Use all energy to shoot" & vbCr & "Return" & vbTab & vbTab & vbTab & "# Return to where we came from"
			End If
			
			RobotCode.SelectionStart = counter + 9 + Len("range 0 > shoot if" & vbTab & vbTab & "# If Range is above zero then go to " & Chr(34) & "Shoot" & Chr(34) & vbCr)
		End If
		
	End Sub
	
	Public Sub BeginnersRotateFast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BeginnersRotateFast.Click
		Dim counter As Short
		counter = InStr(RobotCode.Text, "MainLoop:")
		
		If counter Then
			RobotCode.SelectionStart = counter + 9
			'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			RobotCode.SelectedText = "aim 45 + aim' store" & vbTab & vbTab & "# Adds 45 degrees to the present aim angle" & vbCr
		End If
	End Sub
	
	Public Sub BeginnersRotateTurret_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BeginnersRotateTurret.Click
		Dim counter As Short
		counter = InStr(RobotCode.Text, "MainLoop:")
		
		If counter Then
			RobotCode.SelectionStart = counter + 9
			'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			RobotCode.SelectedText = "aim 9 + aim' store" & vbTab & vbTab & "# Adds 9 degrees to the present aim angle" & vbCr
		End If
	End Sub
	
	Public Sub BeginnersWalls_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BeginnersWalls.Click
		Dim counter As Short
		
		counter = InStr(RobotCode.Text, "MainLoop:")
		
		If counter Then
			RobotCode.SelectionStart = counter + 9
			'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			RobotCode.SelectedText = "x 275 > GoLeft if" & vbTab & vbTab & "# If x > 275 then jump to " & Chr(34) & "GoLeft" & Chr(34) & vbCr & "x 25 < GoRight if" & vbTab & vbTab & "# If x < 25 then jump to " & Chr(34) & "GoRight" & Chr(34) & vbCr & "y 275 > GoUp if" & vbTab & vbTab & "# If y > 275 then jump to " & Chr(34) & "GoUp" & Chr(34) & vbCr & "y 25 < GoDown if" & vbTab & vbTab & "# If y < 25 then jump to " & Chr(34) & "GoDown" & Chr(34) & vbCr
			
			If InStr(RobotCode.Text, "GoLeft:") = 0 Then
				RobotCode.SelectionStart = Len(RobotCode.Text)
				'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				RobotCode.SelectedText = vbCr & vbCr & "GoLeft:" & vbCr & "-4 speedx' store" & vbTab & vbTab & "# Set speed in x direction to -4" & vbCr & "Return" & vbTab & vbTab & vbTab & "# Return to where we came from"
			End If
			If InStr(RobotCode.Text, "GoRight:") = 0 Then
				RobotCode.SelectionStart = Len(RobotCode.Text)
				'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				RobotCode.SelectedText = vbCr & vbCr & "GoRight:" & vbCr & "4 speedx' store" & vbTab & vbTab & "# Set speed in x direction to 4" & vbCr & "Return" & vbTab & vbTab & vbTab & "# Return to where we came from"
			End If
			If InStr(RobotCode.Text, "GoDown:") = 0 Then
				RobotCode.SelectionStart = Len(RobotCode.Text)
				'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				RobotCode.SelectedText = vbCr & vbCr & "GoDown:" & vbCr & "4 speedy' store" & vbTab & vbTab & "# Set speed in y direction to 4" & vbCr & "Return" & vbTab & vbTab & vbTab & "# Return to where we came from"
			End If
			If InStr(RobotCode.Text, "GoUp:") = 0 Then
				RobotCode.SelectionStart = Len(RobotCode.Text)
				'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				RobotCode.SelectedText = vbCr & vbCr & "GoUp:" & vbCr & "-4 speedy' store" & vbTab & vbTab & "# Set speed in y direction to -4" & vbCr & "Return" & vbTab & vbTab & vbTab & "# Return to where we came from"
			End If
			
			RobotCode.SelectionStart = counter + 9 + Len("x 275 > GoLeft if" & vbTab & vbTab & "# If x > 275 then jump to GoLeft" & vbCr & "x 25 < GoRight if" & vbTab & vbTab & "# If x < 25 then jump to GoRight" & vbCr & "y 275 > GoUp if" & vbTab & vbTab & "# If y > 275 then jump to GoUp" & vbCr & "y 25 < GoDown if" & vbTab & vbTab & "# If y < 25 then jump to GoDown" & vbCr) + 8
		End If
		
	End Sub
	
	Public Sub CloseThisWindow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CloseThisWindow.Click
		Me.Close()
	End Sub
	
	Public Sub CRobot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CRobot.Click
		MsgBox("C-Robots are currently in Beta Stage", MsgBoxStyle.Information, "C-Robots")
		
		FileOpen(10, My.Application.Info.DirectoryPath & "\miscdata\DraftPrefsC.cfg", OpenMode.Input)
		Dim ImputFont As Object
		If EOF(10) = False Then
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeName(RobotCode.Font, ImputFont)
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeSize(RobotCode.Font, ImputFont)
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeBold(RobotCode.Font, CBool(ImputFont))
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeItalic(RobotCode.Font, CBool(ImputFont))
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeStrikeOut(RobotCode.Font, CBool(ImputFont))
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeUnderline(RobotCode.Font, CBool(ImputFont))
		End If
		FileClose(10)
		
		InizCRobots()
	End Sub
	
	Private Sub InizCRobots()
		FileOpen(2, PathToRobot, OpenMode.Binary)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(2, CByte(1), CRobotRec)
		CRobot.Checked = True
		IsCRobot = True
		RoboTalkRobot.Checked = False
		FileClose(2)
		
		SyntaxColoringCache = False
		SyntaxColoringMenu.Enabled = False
	End Sub
	
	
	Private Sub MachineCodeText_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MachineCodeText.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.F1 Then Arena_Click(Arena, New System.EventArgs()) 'Bugfix so it won't get the stupid idea to display help when F1 is pressed and the codetextbox in focus
		
	End Sub
	
	Public Sub RoboTalkRobot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RoboTalkRobot.Click
		FileOpen(1, PathToRobot, OpenMode.Binary)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, CByte(0), CRobotRec)
		CRobot.Checked = False
		IsCRobot = False
		RoboTalkRobot.Checked = True
		FileClose(1)
		
		FileOpen(10, My.Application.Info.DirectoryPath & "\miscdata\DraftPrefs.cfg", OpenMode.Input)
		Dim ImputFont As Object
		If EOF(10) = False Then
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeName(RobotCode.Font, ImputFont)
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeSize(RobotCode.Font, ImputFont)
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeBold(RobotCode.Font, CBool(ImputFont))
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeItalic(RobotCode.Font, CBool(ImputFont))
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeStrikeOut(RobotCode.Font, CBool(ImputFont))
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeUnderline(RobotCode.Font, CBool(ImputFont))
		End If
		FileClose(10)
		
		SyntaxColoringCache = SyntaxColoringMenu.Checked
		SyntaxColoringMenu.Enabled = True
	End Sub
	
	'Private Sub Command1_Click()
	'Dim rcode As String
	'rcode = RobotCode.Text
	'Dim c As Integer
	'
	'
	'    Dim Tiden As Double '!!!!--->Tidtagning
	'    Tiden = Timer '!!!!--->Tidtagning
	'
	'For c = 0 To 100
	'Compile (rcode)
	'Next c
	'
	'    Tiden = Timer - Tiden
	'    MsgBox (Tiden)
	'    'Debug.Print Tiden '!!!!--->Tidtagning
	'
	'    'Me.BackColor = RGB(Int(255 * Rnd), Int(255 * Rnd), Int(255 * Rnd))
	'End Sub
	
	Private Sub RobotCode_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles RobotCode.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 ' THE ON THE FLY SYNTAX COLORING CODE
		Dim PresenSLComment As Integer
		Dim PresentSL As Integer
		Dim GrapPart As String
		Dim NextSpace As Integer
		Dim AntiSpace As Integer
		Dim CodeMirror As String
		If SyntaxColoringCache Then
			
			
			Select Case KeyCode
				Case System.Windows.Forms.Keys.F1 'Bugfix so it won't get the stupid idea to display help when F1 is pressed and the codetextbox in focus
					Arena_Click(Arena, New System.EventArgs())
				Case 55 '{
					If Shift = 6 Then
						RobotCode.SelectionColor = System.Drawing.ColorTranslator.FromOle(RGB(CommentRed, CommentGreen, CommentBlue))
						GrapPart = RobotCode.Text
						PresentSL = RobotCode.SelectionStart
						
						If PresentSL <> 0 Then
							NextSpace = InStr(PresentSL, GrapPart, "}")
							AntiSpace = InStr(PresentSL, GrapPart, "{")
						Else
							NextSpace = InStr(GrapPart, "}")
							AntiSpace = InStr(GrapPart, "{")
						End If
						
						If (Not NextSpace > AntiSpace Or (AntiSpace = 0 And NextSpace <> 0)) And NextSpace > PresentSL + 1 Then
							LockWindowUpdate(RobotCode.Handle.ToInt32) 'LOCKS!!
							
							If PresentSL <> 0 Then RobotCode.SelectionStart = PresentSL - 1 Else RobotCode.SelectionStart = PresentSL 'disk
							RobotCode.SelectionLength = NextSpace - PresentSL + 2 ' + 1
							RobotCode.SelectionColor = System.Drawing.ColorTranslator.FromOle(RGB(CommentRed, CommentGreen, CommentBlue)) 'RÖR EJ!!!
							RobotCode.SelectionStart = PresentSL
							
							LockWindowUpdate(0) 'UNLOCKS!!
						End If
					End If
				Case 51 '#
					If Shift = 1 Then
						PresentSL = RobotCode.SelectionStart
						GrapPart = RobotCode.Text & vbCr
						If PresentSL <> 0 Then NextSpace = InStr(PresentSL, GrapPart, vbCr) - PresentSL Else NextSpace = InStr(GrapPart, vbCr) - PresentSL
						AntiSpace = InStr(PresentSL + 1, GrapPart, "#") - PresentSL 'To avoid coloring already colored things
						
						If NextSpace <= 1 Or AntiSpace = 1 Or RobotCode.SelectionLength <> 0 Then
							If System.Drawing.ColorTranslator.ToOle(RobotCode.SelectionColor) <> RGB(CommentRed, CommentGreen, CommentBlue) Then RobotCode.SelectionColor = System.Drawing.ColorTranslator.FromOle(RGB(CommentRed, CommentGreen, CommentBlue)) 'If we're inside a comment we don't need to do anything
						Else
							LockWindowUpdate(RobotCode.Handle.ToInt32) 'LOCKS!!
							
							If PresentSL <> 0 Then RobotCode.SelectionStart = PresentSL - 1 Else RobotCode.SelectionStart = PresentSL 'disk
							RobotCode.SelectionLength = NextSpace + 1
							RobotCode.SelectionColor = System.Drawing.ColorTranslator.FromOle(RGB(CommentRed, CommentGreen, CommentBlue)) 'If we're inside a comment we don't need to do anything
							RobotCode.SelectionStart = PresentSL
							
							LockWindowUpdate(0) 'UNLOCKS!!
						End If
					End If
				Case System.Windows.Forms.Keys.Return 'Return, cancels # comments '13
					If System.Drawing.ColorTranslator.ToOle(RobotCode.SelectionColor) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) Then Exit Sub
					RobotCode.SelectionColor = System.Drawing.Color.Black
				Case System.Windows.Forms.Keys.Space Or KeyCode = System.Windows.Forms.Keys.Tab Or KeyCode = 188 '188 = , and ;
					If System.Drawing.ColorTranslator.ToOle(RobotCode.SelectionColor) <> RGB(LabelRed, LabelGreen, LabelBlue) Then Exit Sub
					RobotCode.SelectionColor = System.Drawing.Color.Black
				Case 190 ':
					If Shift = 1 Then
						If System.Drawing.ColorTranslator.ToOle(RobotCode.SelectionColor) <> RGB(CommentRed, CommentGreen, CommentBlue) Then 'If we're inside a comment the label definition will be 'outcommented'
							GrapPart = StrReverse(RobotCode.Text)
							GrapPart = Replace09(GrapPart, vbLf, " ")
							GrapPart = Replace09(GrapPart, vbTab, " ")
							GrapPart = Replace09(GrapPart, ";", " ")
							GrapPart = Replace09(GrapPart, ",", " ")
							NextSpace = Len(GrapPart) - InStr(Len(GrapPart) - (RobotCode.SelectionStart - 1), GrapPart, " ") + 1
							PresentSL = RobotCode.SelectionStart
							
							LockWindowUpdate(RobotCode.Handle.ToInt32) 'LOCKS!!
							
							If NextSpace < PresentSL Then
								RobotCode.SelectionStart = NextSpace
								RobotCode.SelectionLength = PresentSL - NextSpace
							Else 'If there are no deliminers this can only mean that the beginning of the code is the deliminer
								RobotCode.SelectionStart = 0
								RobotCode.SelectionLength = PresentSL
							End If
							If System.Drawing.ColorTranslator.ToOle(RobotCode.SelectionColor) <> RGB(LabelRed, LabelGreen, LabelBlue) Then RobotCode.SelectionColor = System.Drawing.ColorTranslator.FromOle(RGB(LabelRed, LabelGreen, LabelBlue))
							
							RobotCode.SelectionStart = PresentSL
							
							LockWindowUpdate(0) 'UNLOCKS!!
						End If
					End If
				Case 48 '}
					If System.Drawing.ColorTranslator.ToOle(RobotCode.SelectionColor) <> RGB(CommentRed, CommentGreen, CommentBlue) Then 'If this case we have to recolor the entire comment green
						GrapPart = StrReverse(RobotCode.Text)
						NextSpace = Len(GrapPart) - InStr(Len(GrapPart) - (RobotCode.SelectionStart - 1), GrapPart, "{") '+ 1
						AntiSpace = Len(GrapPart) - InStr(Len(GrapPart) - (RobotCode.SelectionStart - 1), GrapPart, "}")
						
						PresentSL = RobotCode.SelectionStart
						
						If (AntiSpace > NextSpace And AntiSpace <> Len(GrapPart)) Or NextSpace > PresentSL Then Exit Sub
						
						LockWindowUpdate(RobotCode.Handle.ToInt32) 'LOCKS!!
						
						RobotCode.SelectionStart = NextSpace
						RobotCode.SelectionLength = PresentSL - NextSpace
						'If RobotCode.SelColor = RGB(CommentRed, CommentGreen, CommentBlue) Then MsgBox 4    'DEBUG'DEBUG'DEBUG'DEBUG'DEBUG
						RobotCode.SelectionColor = System.Drawing.ColorTranslator.FromOle(RGB(CommentRed, CommentGreen, CommentBlue))
						RobotCode.SelectionStart = PresentSL
						
						LockWindowUpdate(0) 'UNLOCKS!!
					End If
				Case System.Windows.Forms.Keys.Back
					
					If RobotCode.SelectionLength = 0 Then
						GrapPart = RobotCode.Text
						CodeMirror = GrapPart
						PresentSL = RobotCode.SelectionStart
						If PresentSL = 0 Then Exit Sub
						GrapPart = Mid(GrapPart, PresentSL, 1)
						
						Select Case GrapPart
							Case "#"
								If System.Drawing.ColorTranslator.ToOle(RobotCode.SelectionColor) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) Then Exit Sub
								CodeMirror = Replace09(CodeMirror, "#", vbCr) & vbCr
								PresenSLComment = InStr(PresentSL + 1, CodeMirror, vbCr)
								
								LockWindowUpdate(RobotCode.Handle.ToInt32) 'LOCKS!!
								
								RobotCode.SelectionLength = PresenSLComment - PresentSL - 1
								RobotCode.SelectionColor = System.Drawing.Color.Black
								RobotCode.SelectionStart = PresentSL
								
								LockWindowUpdate(0) 'UNLOCKS!!
							Case "{"
								If System.Drawing.ColorTranslator.ToOle(RobotCode.SelectionColor) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) Then Exit Sub
								
								NextSpace = InStr(PresentSL, CodeMirror, "}")
								AntiSpace = InStr(PresentSL, CodeMirror, "{")
								
								If (Not NextSpace < AntiSpace Or (AntiSpace = 0 And NextSpace <> 0)) And NextSpace > PresentSL + 1 Then
									
									LockWindowUpdate(RobotCode.Handle.ToInt32) 'LOCKS!!
									
									RobotCode.SelectionStart = PresentSL - 1
									RobotCode.SelectionLength = NextSpace - PresentSL + 2 ' + 1
									RobotCode.SelectionColor = System.Drawing.Color.Black
									RobotCode.SelectionStart = PresentSL
									
									LockWindowUpdate(0) 'UNLOCKS!!
								End If
							Case "}"
								GrapPart = StrReverse(CodeMirror)
								NextSpace = Len(GrapPart) - InStr(Len(GrapPart) - (RobotCode.SelectionStart - 1), GrapPart, "{") '+ 1
								AntiSpace = Len(GrapPart) - InStr(Len(GrapPart) - (RobotCode.SelectionStart - 1), GrapPart, "}")
								
								If (AntiSpace < NextSpace And AntiSpace <> Len(GrapPart)) Or NextSpace > PresentSL Then Exit Sub
								
								LockWindowUpdate(RobotCode.Handle.ToInt32) 'LOCKS!!
								
								RobotCode.SelectionStart = NextSpace
								RobotCode.SelectionLength = PresentSL - NextSpace
								'If RobotCode.SelColor = RGB(CommentRed, CommentGreen, CommentBlue) Then MsgBox 4    'DEBUG'DEBUG'DEBUG'DEBUG'DEBUG
								RobotCode.SelectionColor = System.Drawing.Color.Black
								RobotCode.SelectionStart = PresentSL
								
								LockWindowUpdate(0) 'UNLOCKS!!
							Case ":"
								If System.Drawing.ColorTranslator.ToOle(RobotCode.SelectionColor) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) Then Exit Sub
								
								CodeMirror = StrReverse(CodeMirror)
								PresenSLComment = Len(CodeMirror) - InStr(Len(CodeMirror) - PresentSL + 1, CodeMirror, vbCr)
								
								LockWindowUpdate(RobotCode.Handle.ToInt32) 'LOCKS!!
								
								If PresentSL > PresenSLComment Then
									RobotCode.SelectionStart = PresenSLComment + 2
									RobotCode.SelectionLength = PresentSL - PresenSLComment
								Else
									RobotCode.SelectionStart = 0
									RobotCode.SelectionLength = PresentSL
								End If
								
								RobotCode.SelectionColor = System.Drawing.Color.Black
								RobotCode.SelectionStart = PresentSL
								
								LockWindowUpdate(0) 'UNLOCKS!!
						End Select
					Else
						'TODO: - INSERT CODE HERE
					End If
				Case System.Windows.Forms.Keys.V
					If Shift = 2 Then 'process clipboard content
						If My.Computer.Clipboard.ContainsText(TextDataFormat.Rtf) Then
							GrapPart = My.Computer.Clipboard.GetText
							If InStr(GrapPart, ":") = 0 And InStr(GrapPart, "#") = 0 And InStr(GrapPart, "{") = 0 And InStr(GrapPart, "}") = 0 Then
								My.Computer.Clipboard.Clear() : My.Computer.Clipboard.SetText(GrapPart) 'erase format
							End If
						End If
					End If
			End Select
			
		End If
	End Sub
	
	Private Sub RobotCode_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles RobotCode.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 ' THE ON THE FLY SYNTAX COLORING CODE
		If SyntaxColoringCache Then
			
			If KeyCode = 48 Then '}
				If Shift = 6 Then
					RobotCode.SelectionColor = System.Drawing.Color.Black
				End If
				'ElseIf KeyCode = 190 Then       ':     'Doesn't seem to work properly
				'    If Shift = 1 Then
				'        RobotCode.SelColor = vbBlack
				'    End If
			End If
			
		End If
	End Sub
	
	Private Sub SyntaxColor_Click() '{lkasjd:} blir felfärgat
		Dim TheRTFCode As String
		Dim newrtftext As String
		Dim counter As Integer
		Dim TheSplit() As String
		Dim commentnumber As Integer
		
		TheRTFCode = RobotCode.RTF
		
		counter = InStr(TheRTFCode, vbCr)
		
		TheRTFCode = VB.Left(TheRTFCode, counter) & "{\colortbl ;\red" & LabelRed & "\green" & LabelGreen & "\blue" & LabelBlue & ";\red" & CommentRed & "\green" & CommentGreen & "\blue" & CommentBlue & ";}" & vbCr & VB.Right(TheRTFCode, Len(TheRTFCode) - counter)
		
		TheSplit = Split(TheRTFCode, "\par ")
		
		'''''''Nummer 0 - måste specialbehandlas-
		If InStr(TheSplit(0), "\" & Chr(123)) Then
			TheSplit(0) = Replace09(TheSplit(0), "\" & Chr(123), "\cf2\" & Chr(123))
			commentnumber = commentnumber + 1
		End If
		
		If commentnumber = 0 Then 'BUG ALERT! Den färgar "{Comment} label:" fel
			If InStr(TheSplit(0), "\cf1 ") = 0 Then
				If InStr(TheSplit(0), ":") Then
					TheSplit(0) = VB.Left(TheSplit(0), Len(TheSplit(0)) - 2) & "\cf0"
					TheSplit(0) = Replace09(TheSplit(0), "pard\", "pard\cf1\")
				End If
			End If
		End If
		
		If InStr(TheSplit(0), "\" & Chr(125)) Then
			TheSplit(0) = Replace09(TheSplit(0), "\" & Chr(125), "\" & Chr(125) & "\cf0 ")
			commentnumber = commentnumber - 1
		End If
		
		If commentnumber = 0 Then 'BUG ALERT! Den färgar "drop #Droppar" fel
			If InStr(TheSplit(0), "#") <> 0 Then
				TheSplit(0) = VB.Left(TheSplit(0), Len(TheSplit(0)) - 2) & "\cf0"
				TheSplit(0) = Replace09(TheSplit(0), "pard\", "pard\cf2\")
			End If
		End If
		''''slut 0
		
		For counter = 1 To UBound(TheSplit)
			If InStr(TheSplit(counter), "\" & Chr(123)) Then
				TheSplit(counter) = Replace09(TheSplit(counter), "\" & Chr(123), "\cf2\" & Chr(123))
				commentnumber = commentnumber + 1
			End If
			
			If commentnumber = 0 Then 'BUG ALERT! Den färgar "{Comment} label:" fel
				If InStr(TheSplit(counter), ":") Then
					TheSplit(counter) = "\cf1 " & Replace09(TheSplit(counter), ":", ":\cf0 ")
				End If
			End If
			
			If InStr(TheSplit(counter), "\" & Chr(125)) Then
				TheSplit(counter) = Replace09(TheSplit(counter), "\" & Chr(125), "\" & Chr(125) & "\cf0 ")
				commentnumber = commentnumber - 1
			End If
			
			If commentnumber = 0 Then
				If InStr(TheSplit(counter), "#") <> 0 Then
					TheSplit(counter) = Replace09(TheSplit(counter), "#", "\cf2 #") & "\cf0"
				End If
			End If
		Next counter
		
		Dim stopacumulation As String
		stopacumulation = StrReverse(TheSplit(UBound(TheSplit)))
		TheSplit(UBound(TheSplit)) = StrReverse(Replace09(stopacumulation, "} ", "}"))
		
		newrtftext = Join(TheSplit, "\par ")
		'UPGRADE_WARNING: TextRTF was upgraded to Text and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.Text = newrtftext 'Left(newrtftext, Len(newrtftext) - 2)
		
		'RobotCode.SaveFile ("E:\Test.txt")
	End Sub
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		Dim res As Byte
		res = MsgBox("Are you sure you don't want to save your changes?", MsgBoxStyle.YesNoCancel, "Don't save changes?")
		If res = MsgBoxResult.Yes Then
			HasCanceled = True
		ElseIf res = MsgBoxResult.No Then 
			HasCanceled = False
		ElseIf res = MsgBoxResult.Cancel Then 
			HasCanceled = False
			Exit Sub
		End If
		
		Me.Close()
	End Sub
	
	Private Sub compileandclose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles compileandclose.Click
		Me.Close()
	End Sub
	
	Private Sub compilebutton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles compilebutton.Click
		If RecompileLock.Checked Then
			MsgBox("This robot is recompile locked",  , "Can't compile")
		Else
			SkrivKodenSamtCompilera((False))
		End If
	End Sub
	
	Public Sub CompileMenu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CompileMenu.Click
		compilebutton_Click(compilebutton, New System.EventArgs())
	End Sub
	
	Public Sub Copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Copy.Click
		System.Windows.Forms.SendKeys.SendWait("^{C}")
	End Sub
	
	Public Sub CountInst_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CountInst.Click
		On Error GoTo CountingError
		
		Dim Stage1Code As String
		Dim CommentStartPosition As Integer 'integer
		Dim CommentWhichWillBeRomoved As String
		Stage1Code = RobotCode.SelectedText
		Stage1Code = Replace09(Stage1Code, vbLf, vbCr)
		
		Dim splitcode() As String
		Dim splitcode2() As String
		Dim SkipNum As Short
		Dim counter As Short
		
		Stage1Code = Replace09(Stage1Code, "}}", "} }") & vbCr 'it seems to have problems with }}
		splitcode = Split(Stage1Code, "}")
		Stage1Code = ""
		
		For counter = 0 To UBound(splitcode)
			If SkipNum > 0 Then
				SkipNum = SkipNum - 1
			Else
				splitcode2 = Split(splitcode(counter), "{")
				SkipNum = UBound(splitcode2) - 1
				Stage1Code = Stage1Code & " " & splitcode2(0)
				'If UBound(SplitCode2) <> -1 Then Stage1Code = Stage1Code & " " & SplitCode2(0)
			End If
		Next counter
		
		Do While InStr(Stage1Code, "#" & vbCr) <> 0 'Tar bort "#" & vbCr / vbLf
			Stage1Code = Replace09(Stage1Code, "#" & vbCr, vbCr) 'för Stjärnkommmentarsborttagaren
		Loop  'kan inte hantera dem
		
		Dim NextChar As String
		CommentStartPosition = InStr(Stage1Code, "#") 'kollar om # finns
		If CommentStartPosition = 0 Then GoTo SkipStarComnments 'går till skipstarcomments om det inte finns
		If CommentStartPosition <> 1 Then CommentStartPosition = CommentStartPosition - 1
		counter = CommentStartPosition + 1
		
		Do 
			NextChar = Mid(Stage1Code, counter, 1) 'Kollar nästa bokstav
			If NextChar = vbCr Then 'Om nästa bokstav är radbrytning då
				CommentWhichWillBeRomoved = Mid(Stage1Code, CommentStartPosition, counter - CommentStartPosition)
				Stage1Code = Replace09(Stage1Code, CommentWhichWillBeRomoved, "",  , 1)
				CommentStartPosition = InStr(Stage1Code, "#") 'Kollar om det finns fler och i så fall var
				counter = CommentStartPosition + 1 'Ställer in Counter
				If CommentStartPosition = 0 Then Exit Do
			Else
				counter = counter + 1
				NextChar = "" 'Troligen behövs denhär inte
				If counter = Len(Stage1Code) Then
					CommentWhichWillBeRomoved = Mid(Stage1Code, CommentStartPosition, counter - CommentStartPosition + 1)
					Stage1Code = Replace09(Stage1Code, CommentWhichWillBeRomoved, "",  , 1)
					Exit Do
				End If
			End If
		Loop 
		
SkipStarComnments: 
		Stage1Code = Replace09(Stage1Code, ";", " ") 'flyttad hit
		Stage1Code = Replace09(Stage1Code, ",", " ") 'nytt
		Stage1Code = Replace09(Stage1Code, vbTab, " ") 'Nya Replace09rs sedan Orb of Doom
		Stage1Code = StrConv(Stage1Code, VbStrConv.UpperCase)
		Stage1Code = Replace09(Stage1Code, vbCr, " ") 'Behövs
		Stage1Code = Trim(Stage1Code) 'detta?
		Stage1Code = Replace09(Stage1Code, " ", vbCr) '??
		
		Do While InStr(Stage1Code, vbCr & vbCr) <> 0
			Stage1Code = Replace09(Stage1Code, vbCr & vbCr, vbCr)
		Loop 
		
		Stage1Code = vbCr & Stage1Code & vbCr
		
		Stage1Code = Replace09(Stage1Code, vbCr & "NEAREST" & vbCr, vbCr & "NEAREST'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "COLLISION" & vbCr, vbCr & "COLLISION'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "AIM" & vbCr, vbCr & "AIM'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "FRIEND" & vbCr, vbCr & "FRIEND'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "DAMAGE" & vbCr, vbCr & "DAMAGE'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "DOPPLER" & vbCr, vbCr & "DOPPLER'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "HISTORY" & vbCr, vbCr & "HISTORY'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ID" & vbCr, vbCr & "ID'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "KILLS" & vbCr, vbCr & "KILLS'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "LOOK" & vbCr, vbCr & "LOOK'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "RANDOM" & vbCr, vbCr & "RANDOM'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "RANGE" & vbCr, vbCr & "RANGE'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ROBOTS" & vbCr, vbCr & "ROBOTS'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SCAN" & vbCr, vbCr & "SCAN'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SHIELD" & vbCr, vbCr & "SHIELD'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SPEEDX" & vbCr, vbCr & "SPEEDX'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SPEEDY" & vbCr, vbCr & "SPEEDY'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "TEAMMATES" & vbCr, vbCr & "NOP" & vbCr & "0" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "WALL" & vbCr, vbCr & "WALL'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "RADAR" & vbCr, vbCr & "RADAR'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SIGNAL" & vbCr, vbCr & "SIGNAL'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "CHRONON" & vbCr, vbCr & "CHRONON'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "PROBE" & vbCr, vbCr & "PROBE'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ENERGY" & vbCr, vbCr & "ENERGY'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "A" & vbCr, vbCr & "A'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "B" & vbCr, vbCr & "B'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "C" & vbCr, vbCr & "C'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "D" & vbCr, vbCr & "D'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "E" & vbCr, vbCr & "E'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "F" & vbCr, vbCr & "F'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "G" & vbCr, vbCr & "G'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "H" & vbCr, vbCr & "H'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "I" & vbCr, vbCr & "I'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "J" & vbCr, vbCr & "J'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "K" & vbCr, vbCr & "K'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "L" & vbCr, vbCr & "L'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "M" & vbCr, vbCr & "M'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "N" & vbCr, vbCr & "N'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "O" & vbCr, vbCr & "O'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "P" & vbCr, vbCr & "P'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "Q" & vbCr, vbCr & "Q'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "R" & vbCr, vbCr & "R'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "S" & vbCr, vbCr & "S'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "T" & vbCr, vbCr & "T'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "U" & vbCr, vbCr & "U'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "V" & vbCr, vbCr & "V'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "W" & vbCr, vbCr & "W'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "X" & vbCr, vbCr & "X'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "Y" & vbCr, vbCr & "Y'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "Z" & vbCr, vbCr & "Z'" & vbCr & "RECALL" & vbCr)
		
		Stage1Code = Replace09(Stage1Code, vbCr & "NEAREST" & vbCr, vbCr & "NEAREST'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "COLLISION" & vbCr, vbCr & "COLLISION'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "AIM" & vbCr, vbCr & "AIM'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "FRIEND" & vbCr, vbCr & "FRIEND'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "DAMAGE" & vbCr, vbCr & "DAMAGE'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "DOPPLER" & vbCr, vbCr & "DOPPLER'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "HISTORY" & vbCr, vbCr & "HISTORY'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ID" & vbCr, vbCr & "ID'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "KILLS" & vbCr, vbCr & "KILLS'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "LOOK" & vbCr, vbCr & "LOOK'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "RANDOM" & vbCr, vbCr & "RANDOM'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "RANGE" & vbCr, vbCr & "RANGE'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ROBOTS" & vbCr, vbCr & "ROBOTS'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SCAN" & vbCr, vbCr & "SCAN'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SHIELD" & vbCr, vbCr & "SHIELD'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SPEEDX" & vbCr, vbCr & "SPEEDX'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SPEEDY" & vbCr, vbCr & "SPEEDY'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "TEAMMATES" & vbCr, vbCr & "NOP" & vbCr & "0" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "WALL" & vbCr, vbCr & "WALL'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "RADAR" & vbCr, vbCr & "RADAR'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SIGNAL" & vbCr, vbCr & "SIGNAL'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "CHRONON" & vbCr, vbCr & "CHRONON'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "PROBE" & vbCr, vbCr & "PROBE'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ENERGY" & vbCr, vbCr & "ENERGY'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "A" & vbCr, vbCr & "A'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "B" & vbCr, vbCr & "B'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "C" & vbCr, vbCr & "C'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "D" & vbCr, vbCr & "D'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "E" & vbCr, vbCr & "E'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "F" & vbCr, vbCr & "F'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "G" & vbCr, vbCr & "G'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "H" & vbCr, vbCr & "H'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "I" & vbCr, vbCr & "I'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "J" & vbCr, vbCr & "J'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "K" & vbCr, vbCr & "K'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "L" & vbCr, vbCr & "L'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "M" & vbCr, vbCr & "M'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "N" & vbCr, vbCr & "N'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "O" & vbCr, vbCr & "O'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "P" & vbCr, vbCr & "P'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "Q" & vbCr, vbCr & "Q'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "R" & vbCr, vbCr & "R'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "S" & vbCr, vbCr & "S'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "T" & vbCr, vbCr & "T'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "U" & vbCr, vbCr & "U'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "V" & vbCr, vbCr & "V'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "W" & vbCr, vbCr & "W'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "X" & vbCr, vbCr & "X'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "Y" & vbCr, vbCr & "Y'" & vbCr & "RECALL" & vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "Z" & vbCr, vbCr & "Z'" & vbCr & "RECALL" & vbCr)
		
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON0" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON1" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON2" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON3" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON4" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON5" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON6" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON7" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON8" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON9" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON0" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON1" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON2" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON3" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON4" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON5" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON6" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON7" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON8" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "ICON9" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND0" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND1" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND2" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND3" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND4" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND5" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND6" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND7" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND8" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND9" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND0" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND1" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND2" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND3" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND4" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND5" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND6" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND7" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND8" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "SND9" & vbCr, vbCr)
		
		Stage1Code = Replace09(Stage1Code, vbCr & "DEBUG" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "DEBUGGER" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "BEEP" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "DEBUG" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "DEBUGGER" & vbCr, vbCr)
		Stage1Code = Replace09(Stage1Code, vbCr & "BEEP" & vbCr, vbCr)
		
		Stage1Code = VB.Right(Stage1Code, Len(Stage1Code) - 1)
		Stage1Code = VB.Left(Stage1Code, Len(Stage1Code) - 1) 'Nytt sedan 2004
		
		Do While InStr(Stage1Code, vbTab) <> 0 'Fungerar
			Stage1Code = Replace09(Stage1Code, vbTab, "")
		Loop 
		
		Do While InStr(Stage1Code, vbLf) <> 0
			Stage1Code = Replace09(Stage1Code, vbLf, "") 'flyttat till början
		Loop 
		
		Do While InStr(Stage1Code, vbCr & vbCr) <> 0
			Stage1Code = Replace09(Stage1Code, vbCr & vbCr, vbCr)
		Loop 
		
		splitcode = Split(Stage1Code, vbCr)
		Stage1Code = ""
		
		For counter = 0 To UBound(splitcode)
			If InStr(splitcode(counter), ":") = 0 Then Stage1Code = Stage1Code & splitcode(counter) & vbCr
		Next counter
		
		counter = UBound(Split(Stage1Code, vbCr))
		If counter < 0 Then counter = 0
		MsgBox(counter & " instructions highlighted." & vbCr & vbCr & "(Not counting zero-time-execution instructions, like SNDx, ICONx, BEEP and DEBUG).",  , "Count instructions")
		
CountingError: 
		If Err.Number <> 0 Then MsgBox("There was an error while counting instructions, probably caused by {} comments." & vbCr & "Please do a syntax check.",  , "Count Instructions Error")
		
	End Sub
	
	Public Sub CustomAimLoop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CustomAimLoop.Click
		Dim NumberOfDegrees As Object
		Dim AimLoop As String
		Dim AimVal As Short
		Dim res As Short
		Dim Templimit As Object
		
redo: 
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		NumberOfDegrees = InputBox("Note: as soon as I find the source of Justin Blachards" & vbLf & "Aim Loop Generator, I'll built it in here." & vbLf & "Anyway, " & vbLf & vbLf & "How many degrees between each check?", "Aim Loop", CStr(10))
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If NumberOfDegrees = "" Then GoTo AbortCreation
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		NumberOfDegrees = Val(NumberOfDegrees)
		'If NumberOfDegrees = 0 Then GoTo AbortCreation 'Prevent eternal loop = Freezing
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If NumberOfDegrees > 359 Or NumberOfDegrees < 1 Then
			If MsgBox("How many degrees between each check must range from 1 to 359", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical, "Aimloop Error") = MsgBoxResult.Cancel Then GoTo AbortCreation
			GoTo redo
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object Templimit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Templimit = InputBox("From", "Aim Loop", limit2 - NumberOfDegrees)
		'UPGRADE_WARNING: Couldn't resolve default property of object Templimit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Templimit = "" Then GoTo AbortCreation
		'UPGRADE_WARNING: Couldn't resolve default property of object Templimit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		limit1 = Templimit
		
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object Templimit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Templimit = InputBox("To", "Aim Loop", limit2 + 90 + NumberOfDegrees)
		'UPGRADE_WARNING: Couldn't resolve default property of object Templimit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Templimit = "" Then GoTo AbortCreation
		'UPGRADE_WARNING: Couldn't resolve default property of object Templimit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		limit2 = Templimit
		
		AimVal = limit1
		
		Do While AimVal <= limit2
			AimLoop = AimLoop & AimVal & " aim' store" & Chr(10)
			'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			AimVal = AimVal + NumberOfDegrees
		Loop 
		
		res = MsgBox(AimLoop, MsgBoxStyle.YesNoCancel, "Is this ok?")
		If res = MsgBoxResult.Cancel Then GoTo AbortCreation
		
		Dim insert As String
		insert = AimLoop
		
		AimLoop = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		limit2 = limit2 - NumberOfDegrees
		
		If res = MsgBoxResult.No Then GoTo redo
		
		'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.SelectedText = insert
		
AbortCreation: 
		RobotCode.SelectionStart = RobotCode.SelectionStart
		RobotCode.Focus()
	End Sub
	
	Public Sub Cut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cut.Click
		System.Windows.Forms.SendKeys.SendWait("^{X}")
	End Sub
	
	Public Sub DebuggingDeadloop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DebuggingDeadloop.Click
		If InStr(RobotCode.Text, "loop:") Then
			'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			RobotCode.SelectedText = "loop jump"
		Else
			'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			RobotCode.SelectedText = "loop: loop jump"
		End If
	End Sub
	
	Public Sub defaultfont_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles defaultfont_Renamed.Click
		Dim res As Short
		res = MsgBox("Are you sure?", MsgBoxStyle.OKCancel + MsgBoxStyle.DefaultButton2, "Reset To Default Font")
		
		If IsCRobot Then
			If res = MsgBoxResult.OK Then
				RobotCode.Font = VB6.FontChangeName(RobotCode.Font, "Courier New")
				RobotCode.Font = VB6.FontChangeSize(RobotCode.Font, 11)
				RobotCode.Font = VB6.FontChangeBold(RobotCode.Font, False)
				RobotCode.Font = VB6.FontChangeItalic(RobotCode.Font, False)
				RobotCode.Font = VB6.FontChangeStrikeOut(RobotCode.Font, False)
				RobotCode.Font = VB6.FontChangeUnderline(RobotCode.Font, False)
			End If
			
			FileOpen(10, My.Application.Info.DirectoryPath & "\miscdata\DraftPrefsC.cfg", OpenMode.Output)
			PrintLine(10, "Courier New" & vbCr & 11 & vbCr & 0 & vbCr & 0 & vbCr & 0 & vbCr & 0)
			FileClose(10)
		Else
			If res = MsgBoxResult.OK Then
				'UPGRADE_WARNING: Only TrueType and OpenType fonts are supported in Windows Forms. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="971F4DF4-254E-44F4-861D-3AA0031FE361"'
				RobotCode.Font = VB6.FontChangeName(RobotCode.Font, "MS Sans Serif")
				RobotCode.Font = VB6.FontChangeSize(RobotCode.Font, 8)
				RobotCode.Font = VB6.FontChangeBold(RobotCode.Font, False)
				RobotCode.Font = VB6.FontChangeItalic(RobotCode.Font, False)
				RobotCode.Font = VB6.FontChangeStrikeOut(RobotCode.Font, False)
				RobotCode.Font = VB6.FontChangeUnderline(RobotCode.Font, False)
			End If
			
			FileOpen(10, My.Application.Info.DirectoryPath & "\miscdata\DraftPrefs.cfg", OpenMode.Output)
			PrintLine(10, "MS Sans Serif" & vbCr & 8 & vbCr & 0 & vbCr & 0 & vbCr & 0 & vbCr & 0)
			FileClose(10)
		End If
		
	End Sub
	
	Public Sub DebuggingAlwaysSameXY_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DebuggingAlwaysSameXY.Click
		Dim Xpos As Short
		Dim Ypos As Short
		Dim insert As String
		Dim InputN As String
		
		If TheXYPos = 0 Then
			TheXYPos = 200
		Else
			TheXYPos = TheXYPos \ 2
		End If
		
		InputN = InputBox("X-Pos to start at?", "X-pos", CStr(TheXYPos))
		If InputN = "" Then GoTo AbortCreation
		Xpos = Val(InputN)
		InputN = InputBox("Y-Pos to start at?", "Y-pos", CStr(TheXYPos))
		If InputN = "" Then GoTo AbortCreation
		Ypos = Val(InputN)
		
		insert = "x " & Xpos & " < dbgori ifg x " & Xpos + 15 & " < dstp ifg " & Xpos + 15 & " left' setparam dstp left' setint inton -10 speedx' store dlp rti" & vbCr & "dbgori: x " & Xpos - 15 & " > dstp ifg " & Xpos - 15 & " right' setparam dstp right' setint inton 10 speedx' store dlp: dlp jump" & vbCr & "dstp: 0 speedx' store " & Xpos & " x - movex' store y " & Ypos & " < dbgwd ifg y " & Ypos + 15 & " < dbgd ifg " & Ypos + 15 & " top' setparam dbgd top' setint inton -10 speedy' store dlp rti" & vbCr & "dbgwd: y " & Ypos - 15 & " > dbgd ifg " & Ypos - 15 & " bot' setparam dbgd bot' setint inton 10 speedy' store dlp rti" & vbCr & "dbgd: 0 speedy' store " & Ypos & " y - movey' store -1 left' setint -1 top' setint -1 bot' setint -1 right' setint" & vbCr & "280 bot' setparam 20 top' setparam 280 right' setparam 20 left' setparam 97 chronon' setparam dbrgo chronon' setint dlp rti dbrgo: sync intoff dropall sync -1 chronon' setint sync"
		
		'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.SelectedText = insert
		
AbortCreation: 
		RobotCode.SelectionStart = RobotCode.SelectionStart
		RobotCode.Focus()
	End Sub
	
	Public Sub DopplerForBullets_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DopplerForBullets.Click
		'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.SelectedText = "doppler 5 * aim + aim' store"
		
	End Sub
	
	Public Sub DopplerForStunners_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DopplerForStunners.Click
		'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.SelectedText = "doppler 3 * aim + aim' store"
	End Sub
	
	Public Sub Find_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Find.Click
		sFind = InputBox("Search for", "Find", Trim(RobotCode.SelectedText))
		If RobotCode.Find(sFind, RobotCode.SelectionStart + RobotCode.SelectionLength + 1) = -1 Then RobotCode.Find(sFind, 0) ', RobotCode.SelStart + RobotCode.SelLength + 1
	End Sub
	
	Public Sub FindNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FindNext.Click
		If RobotCode.Find(sFind, RobotCode.SelectionStart + RobotCode.SelectionLength + 1) = -1 Then RobotCode.Find(sFind, 0) ', RobotCode.SelStart + RobotCode.SelLength + 1
	End Sub
	
	Private Sub SearchInst(ByRef lookingfor As Short)
		If IsCRobot Then Exit Sub
		
		On Error GoTo therewasan
		
		Dim splitcode() As String
		Dim splitcode2() As String
		Dim SourceCode As String
		
		Dim c As Integer
		Dim d As Short
		Dim SkipNum As Short
		
		SourceCode = RobotCode.Text
		SourceCode = Replace09(SourceCode, "}}", "} }") & vbCr 'it seems to have problems with }}, also includes the line under
		splitcode = Split(SourceCode, "}")
		
		SourceCode = ""
		
		For c = 0 To UBound(splitcode)
			If SkipNum > 0 Then
				SkipNum = SkipNum - 1
				SourceCode = SourceCode & ":" & New String(Chr(55), Len(splitcode(c))) '& ":"
			Else
				splitcode2 = Split(splitcode(c), "{")
				SkipNum = UBound(splitcode2) - 1
				
				'SourceCode = SourceCode & " " & SplitCode2(0)
				If UBound(splitcode2) <> -1 Then SourceCode = SourceCode & " " & splitcode2(0)
				
				For d = 1 To UBound(splitcode2)
					If Len(splitcode2(d)) > 0 Then SourceCode = SourceCode & ":" & New String(Chr(55), Len(splitcode2(d))) '& ":"
				Next d
			End If
		Next c
		
		SourceCode = VB.Right(SourceCode, Len(SourceCode) - 1)
		SourceCode = Replace09(SourceCode, vbLf, vbCr)
		
		'BUG ALERT! KLARAR INTE "#" & vbCr
		SourceCode = Replace09(SourceCode, "#" & vbCr, ":" & vbCr) 'Kanske fungerar? Eftersom jag helt glömt bort hur denhär är konstruerad...
		'This code sure is spooky
		
		Dim cpos As Integer
		If InStr(SourceCode, "#") Then
			
			splitcode = Split(SourceCode, vbCr)
			For c = 0 To UBound(splitcode)
				cpos = InStr(splitcode(c), "#")
				If cpos = 1 Then
					splitcode(c) = New String(Chr(55), Len(splitcode(c)) - 1) & ":"
				ElseIf cpos <> 0 Then 
					splitcode(c) = VB.Left(splitcode(c), cpos) & New String(Chr(55), Len(splitcode(c)) - 1 - cpos) & ":"
				End If
			Next c
			
			SourceCode = Join(splitcode, vbCr) '& vbCr
		End If
		
		SourceCode = Replace09(SourceCode, " ", vbCr)
		SourceCode = Replace09(SourceCode, vbTab, vbCr)
		SourceCode = Replace09(SourceCode, ";", vbCr)
		SourceCode = Replace09(SourceCode, ",", vbCr)
		SourceCode = UCase(SourceCode)
		
		splitcode = Split(SourceCode, vbCr)
		
		Dim WhichInst As Short
		
		For c = 0 To UBound(splitcode)
			If InStr(splitcode(c), ":") Then
				WhichInst = WhichInst - 1
			Else
				Select Case splitcode(c)
					Case "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "Z", "AIM", "CHANNEL", "CHRONON", "COLLISION", "DAMAGE", "DOPPLER", "FRIEND", "HISTORY", "ID", "KILLS", "LOOK", "ENERGY", "WALL", "PROBE", "RADAR", "RANDOM", "RANGE", "ROBOTS", "SCAN", "TEAMMATES", "SHIELD", "SIGNAL", "SPEEDX", "SPEEDY", "X", "Y", "NEAREST"
						If WhichInst = lookingfor Then Exit For
						WhichInst = WhichInst + 1
					Case ""
						WhichInst = WhichInst - 1
				End Select
			End If
			
			If WhichInst = lookingfor Then Exit For
			WhichInst = WhichInst + 1
		Next c
		
		SourceCode = ""
		
		For d = 0 To c - 1
			SourceCode = SourceCode & splitcode(d) & " "
		Next d
		
		RobotCode.SelectionStart = Len(SourceCode)
		'Highlighting the instruction
		Dim SS As Integer
		Dim nextdelim As Integer
		SS = RobotCode.SelectionStart
		Dim CodeMirror As String
		CodeMirror = RobotCode.Text
		CodeMirror = Replace09(CodeMirror, vbCr, " ")
		CodeMirror = Replace09(CodeMirror, vbLf, " ")
		CodeMirror = Replace09(CodeMirror, vbTab, " ")
		CodeMirror = Replace09(CodeMirror, ";", " ")
		CodeMirror = Replace09(CodeMirror, ",", " ")
		nextdelim = InStr(SS + 1, CodeMirror, " ")
		
		If nextdelim <> 0 Then
			RobotCode.SelectionLength = nextdelim - SS
		Else
			RobotCode.SelectionLength = Len(CodeMirror) - SS
		End If
		
		Exit Sub
		
therewasan: 
		MsgBox("There was an error. Please do a syntax check",  , "Can't find instruction")
		
	End Sub
	
	Public Sub FindInstruction_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FindInstruction.Click
Retry: 
		
		Dim insttofind As Object
		'UPGRADE_WARNING: Couldn't resolve default property of object insttofind. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		insttofind = InputBox("Please enter the instruction number to search for (0 to 4999):")
		'UPGRADE_WARNING: Couldn't resolve default property of object insttofind. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If insttofind = "" Then Exit Sub
		
		'UPGRADE_WARNING: Couldn't resolve default property of object insttofind. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IsNumeric(insttofind) And insttofind >= 0 And insttofind <= 32767 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object insttofind. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SearchInst((CShort(insttofind)))
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object insttofind. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If MsgBox("The instruction number you specified (" & insttofind & ") doesn't seem to exist." & vbCr & "Instruction numbers ranges from 0 to 4999 at most." & vbCr & vbCr & "Retry?", MsgBoxStyle.RetryCancel, "Can't find instruction") = MsgBoxResult.Retry Then GoTo Retry
		End If
		
	End Sub
	
	Private Sub DraftingBoard_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window Min/Max
		Dim YesOrNo As Boolean
		
		If MainWindow.ResolutionChanged Then
			MachineCodeText.Visible = False '       if 640x480 it always runs maximated
			RobotCode.Height = 350
		Else
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(7, YesOrNo, 4000) 'Window State
			
			If YesOrNo Then
				Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
				RobotCode.Height = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / VB6.TwipsPerPixelY - 130
				MachineCodeText.Height = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / VB6.TwipsPerPixelY - 130
			Else
				Me.WindowState = System.Windows.Forms.FormWindowState.Normal
			End If
		End If
		'Preferences
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 8000)
		AutoCompile.Checked = YesOrNo
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 10000)
		PrintLineNumbers.Checked = YesOrNo
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 5500)
		ResetCursorPosition.Checked = YesOrNo
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 10500)
		SyntaxColoringMenu.Checked = YesOrNo
		SyntaxColoringCache = YesOrNo
		
		'Code and cursor position
		Select Case MainWindow.SelectedRobot
			Case 1
				PathToRobot = MainWindow.R1path
			Case 2
				PathToRobot = MainWindow.R2path
			Case 3
				PathToRobot = MainWindow.R3path
			Case 4
				PathToRobot = MainWindow.R4path
			Case 5
				PathToRobot = MainWindow.R5path
			Case 6
				PathToRobot = MainWindow.R6path
		End Select
		
		Dim rcode As String
		Dim rlocking As Byte
		Dim cRobotSetting As Byte
		FileOpen(1, PathToRobot, OpenMode.Binary)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, rlocking, RLock)
		RecompileLock.Checked = CBool(rlocking)
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, cRobotSetting, CRobotRec)
		If CBool(cRobotSetting) Then
			InizCRobots()
		Else
			RoboTalkRobot.Checked = True
			IsCRobot = False
		End If
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, Cstart, Crec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, MStart, MCrec)
		
		Dim CursorPosition As Integer
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, CursorPosition, CPosrec)
		rcode = Space(LOF(1) - Cstart)
		'Debug.Print "Loading: CStart=" & Cstart & " LOF=" & LOF(1) & " Mstart=" & MStart
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, rcode, Cstart)
		If SyntaxColoringCache Then
			'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			If InStrB(rcode, vbNewLine) <> 0 Then rcode = Replace09(rcode, vbNewLine, vbCr) 'DISK - verkar motverka hålen
			'Troligen rör det sig om chr(128-159)
			
			'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			If InStrB(rcode, Chr(133)) <> 0 Then rcode = Replace09(rcode, Chr(133), "") 'DISK - verkar motverka hålen
			'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			If InStrB(rcode, Chr(132)) <> 0 Then rcode = Replace09(rcode, Chr(132), "") 'DISK - verkar motverka hålen
			'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			If InStrB(rcode, Chr(154)) <> 0 Then rcode = Replace09(rcode, Chr(154), "") 'DISK - verkar motverka hålen
			'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			If InStrB(rcode, Chr(140)) <> 0 Then rcode = Replace09(rcode, Chr(140), "") 'DISK - verkar motverka hålen
			'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			If InStrB(rcode, Chr(138)) <> 0 Then rcode = Replace09(rcode, Chr(138), "") 'DISK - verkar motverka hålen
			rcode = rcode & vbCr 'DISK
		End If
		
		RobotCode.Text = rcode
		Label3.Text = Len(rcode) & " Bytes"
		Label4.Text = (Cstart - MStart) \ 2 & " Instructions"
		FileClose(1)
		
		'Font
		Dim LoadCfont As String
		If IsCRobot Then LoadCfont = "C"
		
		FileOpen(10, My.Application.Info.DirectoryPath & "\miscdata\DraftPrefs" & LoadCfont & ".cfg", OpenMode.Input)
		Dim ImputFont As Object
		If EOF(10) = False Then
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeName(RobotCode.Font, ImputFont)
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeSize(RobotCode.Font, ImputFont)
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeBold(RobotCode.Font, CBool(ImputFont))
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeItalic(RobotCode.Font, CBool(ImputFont))
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeStrikeOut(RobotCode.Font, CBool(ImputFont))
			Input(10, ImputFont)
			'UPGRADE_WARNING: Couldn't resolve default property of object ImputFont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RobotCode.Font = VB6.FontChangeUnderline(RobotCode.Font, CBool(ImputFont))
		End If
		FileClose(10)
		
		'Macros
		Dim DirName As String
		Dim counter As Short
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		DirName = Dir(My.Application.Info.DirectoryPath & "\Macros\", 0)
		
		Do While DirName <> ""
			Macro(counter).Text = VB.Left(DirName, Len(DirName) - 4)
			Macro(counter).Visible = True
			counter = counter + 1
			If counter >= 6 Then Exit Do
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			DirName = Dir()
		Loop 
		
		If Macro(0).Visible = False Then Separator3.Visible = False
		
		If SyntaxColoringCache Then SyntaxColor_Click()
		
		
		If GotoInstNr > 0 Then
			SearchInst((GotoInstNr - 1))
			GotoInstNr = 0
		Else
			RobotCode.SelectionStart = CursorPosition
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Event DraftingBoard.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub DraftingBoard_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Dim YesOrNo As Boolean
		If MainWindow.ResolutionChanged = 0 Then
			
			If Me.WindowState = 0 Then
				Me.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - 450)
				RobotCode.Height = Me.ClientRectangle.Height - 55 '50
				MachineCodeText.Height = Me.ClientRectangle.Height - 55 '50
				YesOrNo = False
				'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FilePut(7, YesOrNo, 4000)
			ElseIf Me.WindowState = 2 Then 
				YesOrNo = True
				'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FilePut(7, YesOrNo, 4000)
			End If
			
		End If
	End Sub
	
	Private Sub DraftingBoard_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If Not HasCanceled Then SkrivKoden()
		HasCanceled = False 'Dethär är väldigt mystiskt, det verkar komma ihåg att DoCancel = true när
		'den stängs. Varning för kloning 'Men den verkar köra form load i alla fall
	End Sub
	
	Public Sub HardwareStore_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HardwareStore.Click
		Me.Close()
		VB6.ShowForm(HardwareWindow, 1, MainWindow)
	End Sub
	
	Public Sub HelpMenu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HelpMenu.Click
		ShowHelp()
	End Sub
	
	Public Sub IconFactory_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles IconFactory.Click
		Me.Close()
		VB6.ShowForm(ChooseIcon, 1, MainWindow)
		
	End Sub
	
	Public Sub InsertPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles InsertPrint.Click
		'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.SelectedText = "1 print drop"
	End Sub
	
	Public Sub LookRoutine_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LookRoutine.Click
		
		Dim NumberOfDegrees As Object
		Dim lookloop As String
		Dim lookval As Short
		Dim res As Short
		Dim interval As Object
		
redolook: 
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		NumberOfDegrees = InputBox("Note: as soon as I find the source of Justin Blachards" & vbLf & "Aim Loop Generator, I'll built it in here." & vbLf & "Anyway, " & vbLf & vbLf & "How many degrees between each check?", "Look routine", CStr(3))
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If NumberOfDegrees = "" Then GoTo AbortCreation
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		NumberOfDegrees = Val(NumberOfDegrees)
		'If NumberOfDegrees = 0 Then GoTo AbortCreation 'Prevent eternal loop = Freezing
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If NumberOfDegrees > 359 Or NumberOfDegrees < 1 Then
			If MsgBox("How many degrees between each check must range from 1 to 359", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical, "Aimloop Error") = MsgBoxResult.Cancel Then GoTo AbortCreation
			GoTo redolook
		End If
		
redointerval: 
		
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object interval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		interval = InputBox("Please enter the max look value.", "Look routine", CStr(NumberOfDegrees * 8))
		'UPGRADE_WARNING: Couldn't resolve default property of object interval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If interval = "" Then GoTo AbortCreation
		'UPGRADE_WARNING: Couldn't resolve default property of object interval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		interval = Val(interval)
		'If interval = 0 Then GoTo AbortCreation 'Prevent eternal loop = Freezing
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If NumberOfDegrees > 359 Or NumberOfDegrees < 1 Then
			If MsgBox("Max look value must range from 1 to 359", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical, "Aimloop Error") = MsgBoxResult.Cancel Then GoTo AbortCreation
			GoTo redointerval
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lookval = NumberOfDegrees
		
		'UPGRADE_WARNING: Couldn't resolve default property of object interval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Do While lookval <= interval
			lookloop = lookloop & lookval & " look' store" & Chr(10)
			lookloop = lookloop & -lookval & " look' store" & Chr(10)
			'UPGRADE_WARNING: Couldn't resolve default property of object NumberOfDegrees. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lookval = lookval + NumberOfDegrees
		Loop 
		
		res = MsgBox(lookloop, MsgBoxStyle.YesNoCancel, "Is this ok?")
		If res = MsgBoxResult.Cancel Then GoTo AbortCreation
		
		Dim insert As String
		insert = lookloop
		
		lookloop = ""
		lookval = 0
		
		If res = MsgBoxResult.No Then GoTo redolook
		
		'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.SelectedText = insert
		
AbortCreation: 
		RobotCode.SelectionStart = RobotCode.SelectionStart
		RobotCode.Focus()
	End Sub
	
	
	
	Public Sub Macro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Macro.Click
		Dim index As Short = Macro.GetIndex(eventSender)
		Dim MyMacro As String
		FileOpen(12, My.Application.Info.DirectoryPath & "\Macros\" & Macro(index).Text & ".txt", OpenMode.Input)
		MyMacro = InputString(12, LOF(12))
		RobotCode.SelectedText = MyMacro
		FileClose(12)
		
	End Sub
	
	Public Sub Paste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Paste.Click
		System.Windows.Forms.SendKeys.SendWait("^{V}")
	End Sub
	
	Public Sub Print_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Print_Renamed.Click
		Dim Printer As New Printer
		CommonDialog1Print.ShowDialog()
		CommonDialog1Font.MaxSize = CommonDialog1Print.PrinterSettings.MaximumPage
		CommonDialog1Font.MinSize = CommonDialog1Print.PrinterSettings.MinimumPage
		On Error GoTo printererror
		
		Printer.Orientation = CommonDialog1Print.PrinterSettings.DefaultPageSettings.Landscape
		Printer.Copies = CommonDialog1Print.PrinterSettings.Copies
		'UPGRADE_ISSUE: Printer property Printer.hdc was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		'UPGRADE_ISSUE: RichTextLib.RichTextBox method RobotCode.SelPrint was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		RobotCode.SelPrint((Printer.hdc))
		'Exit Sub
		
printererror: 
		'MsgBox Err.Description, vbCritical, "There has been a printer error."
	End Sub
	
	Public Sub PrintLineNumbers_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PrintLineNumbers.Click
		Dim YesOrNo As Boolean
		If PrintLineNumbers.Checked Then
			PrintLineNumbers.Checked = False
			YesOrNo = False
		Else
			PrintLineNumbers.Checked = True
			YesOrNo = True
		End If
		
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, YesOrNo, 10000)
	End Sub
	
	Public Sub RecompileLock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RecompileLock.Click
		FileOpen(1, PathToRobot, OpenMode.Binary)
		If RecompileLock.Checked Then
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(1, CByte(0), RLock)
			RecompileLock.Checked = False
		Else
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(1, CByte(1), RLock)
			RecompileLock.Checked = True
		End If
		FileClose(1)
	End Sub
	
	Public Sub RecordingStudio_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RecordingStudio.Click
		Me.Close()
		VB6.ShowForm(SoundEditor, 1, MainWindow)
		
	End Sub
	
	Public Sub ResetCursorPosition_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ResetCursorPosition.Click
		Dim YesOrNo As Boolean
		If ResetCursorPosition.Checked Then
			ResetCursorPosition.Checked = False
			YesOrNo = False
		Else
			ResetCursorPosition.Checked = True
			YesOrNo = True
		End If
		
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, YesOrNo, 5500)
	End Sub
	
	Public Sub ResetLook_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ResetLook.Click
		'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.SelectedText = "aim look + aim' store" & vbCr & "0 look' store"
	End Sub
	
	Private Sub RobotCode_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RobotCode.TextChanged
		NoErrors.Visible = False
	End Sub
	
	Private Sub RobotCode_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RobotCode.DoubleClick
		HasDCl = True
	End Sub
	
	Private Sub RobotCode_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles RobotCode.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim PresentSL As Integer
		Dim GrapPart As String
		Dim NextSpace As Integer
		If HasDCl Then
			'If RobotCode.SelText = "' " Or RobotCode.SelText = "'" Or RobotCode.SelText = "'  " Then
			If RTrim(RobotCode.SelectedText) = "'" Then
				GrapPart = StrReverse(RobotCode.Text)
				GrapPart = Replace09(GrapPart, vbCr, " ")
				GrapPart = Replace09(GrapPart, vbLf, " ")
				GrapPart = Replace09(GrapPart, vbTab, " ")
				GrapPart = Replace09(GrapPart, ";", " ")
				GrapPart = Replace09(GrapPart, ",", " ")
				
				NextSpace = Len(GrapPart) - InStr(Len(GrapPart) - RobotCode.SelectionStart, GrapPart, " ") + 1
				PresentSL = RobotCode.SelectionStart
				
				If PresentSL > NextSpace Then
					RobotCode.SelectionStart = NextSpace
					RobotCode.SelectionLength = PresentSL - NextSpace
				Else
					RobotCode.SelectionStart = 0
					RobotCode.SelectionLength = InStr(RobotCode.Text, "'") - 1
				End If
			End If
			
			HasDCl = False
		End If
		
	End Sub
	
	Public Sub SelectAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SelectAll.Click
		System.Windows.Forms.SendKeys.Send("^a") 'select all
	End Sub
	
	Public Sub SetEdgeInterupsLimitsto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SetEdgeInterupsLimitsto.Click
		Dim inputval As Object
		RobotCode.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left
		
Retry: 
		'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		inputval = InputBox("How near the edges would you like your robot to go?", "Set Edge Interupts Limits", CStr(15))
		
		If IsNumeric(inputval) Then
			'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			RobotCode.SelectedText = (300 - inputval) & " right' setparam" & vbCr & inputval & " left' setparam" & vbCr & (300 - inputval) & " bot' setparam" & vbCr & inputval & " top' setparam" & vbCr & vbCr
			'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ElseIf inputval <> "" Then 
			'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If MsgBox("The value " & inputval & " is invalid (not numeric)", MsgBoxStyle.RetryCancel, "Set Edge Interupts Limits") = MsgBoxResult.Retry Then GoTo Retry
		End If
		
	End Sub
	
	Public Sub SetHistory_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SetHistory.Click
		Dim index As Short = SetHistory.GetIndex(eventSender)
		Dim HistoryString As String
		Select Case index
			Case 2
				HistoryString = "Kills made in previous battle"
			Case 3
				HistoryString = "Kills made in all battles"
			Case 4
				HistoryString = "Survival points in previous battle"
			Case 5
				HistoryString = "Survival points from all battles"
			Case 6
				HistoryString = "1 if last battle timed out"
			Case 7
				HistoryString = "Teammates alive at end of last battle (excluding self)"
			Case 8
				HistoryString = "Teammates alive at end of all battle"
			Case 9
				HistoryString = "Damage at end of last battle (0 if dead)"
			Case 10
				HistoryString = "Chronons elapsed at end of last battle"
			Case 11
				HistoryString = "Chronons elapsed in all previous battles"
		End Select
		
		'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.SelectedText = index & " History' setparam" & vbTab & vbTab & "# " & HistoryString & vbLf
	End Sub
	
	Public Sub SetHistoryBattles_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SetHistoryBattles.Click
		'UPGRADE_WARNING: SelRTF was upgraded to SelectedText and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		RobotCode.SelectedText = "1 History' setparam" & vbTab & vbTab & "# Number of battles fought" & vbLf & "{Note that this is the default setting and usually doesn't have to be set}" & vbLf
		
	End Sub
	
	Public Sub Size_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Size_Renamed.Click
		'UPGRADE_ISSUE: Constant cdlCFScreenFonts was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: MSComDlg.CommonDialog property CommonDialog1.Flags was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		CommonDialog1.Flags = MSComDlg.FontsConstants.cdlCFScreenFonts
		'UPGRADE_WARNING: MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Font.ShowEffects which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		CommonDialog1Font.ShowEffects = True
		'UPGRADE_WARNING: MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Font.FontMustExist which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		CommonDialog1Font.FontMustExist = True
		'UPGRADE_WARNING: MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Font.ScriptsOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		CommonDialog1Font.ScriptsOnly = True
		'UPGRADE_ISSUE: Constant cdlCFLimitSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: MSComDlg.CommonDialog property CommonDialog1.Flags was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		CommonDialog1.Flags = MSComDlg.FontsConstants.cdlCFLimitSize
		CommonDialog1Font.MinSize = 3
		CommonDialog1Print.PrinterSettings.MinimumPage = 3
		CommonDialog1Font.MaxSize = 24
		CommonDialog1Print.PrinterSettings.MaximumPage = 24
		
		CommonDialog1Font.Font = VB6.FontChangeName(CommonDialog1Font.Font, RobotCode.Font.Name) 'Added 04 at Theo's suggestion
		'I agree that it looks more proper if a font is selected from the start when the dialog box appears.
		CommonDialog1Font.ShowDialog()
		CommonDialog1Print.PrinterSettings.MaximumPage = CommonDialog1Font.MaxSize
		CommonDialog1Print.PrinterSettings.MinimumPage = CommonDialog1Font.MinSize
		
		RobotCode.Font = VB6.FontChangeBold(RobotCode.Font, CommonDialog1Font.Font.Bold)
		RobotCode.Font = VB6.FontChangeItalic(RobotCode.Font, CommonDialog1Font.Font.Italic)
		RobotCode.Font = VB6.FontChangeSize(RobotCode.Font, CommonDialog1Font.Font.Size)
		RobotCode.Font = VB6.FontChangeStrikeOut(RobotCode.Font, CommonDialog1Font.Font.Strikeout)
		RobotCode.Font = VB6.FontChangeName(RobotCode.Font, CommonDialog1Font.Font.Name)
		RobotCode.Font = VB6.FontChangeUnderline(RobotCode.Font, CommonDialog1Font.Font.Underline)
		Dim LoadCfont As String
		If IsCRobot Then LoadCfont = "C"
		FileOpen(10, My.Application.Info.DirectoryPath & "\miscdata\DraftPrefs" & LoadCfont & ".cfg", OpenMode.Output)
		PrintLine(10, CommonDialog1Font.Font.Name & vbCr & CommonDialog1Font.Font.Size & vbCr & CShort(CommonDialog1Font.Font.Bold) & vbCr & CShort(CommonDialog1Font.Font.Italic) & vbCr & CShort(CommonDialog1Font.Font.Strikeout) & vbCr & CShort(CommonDialog1Font.Font.Underline))
		FileClose(10)
	End Sub
	
	Private Function SyntaxCheck(ByVal TheCode As String) As Boolean
		Dim TheCodeA() As String
		Dim counter As Short
		
		TheCode = Replace09(TheCode, vbCr, vbLf)
		TheCode = Replace09(TheCode, "{", vbLf & "{")
		TheCode = Replace09(TheCode, "}", vbLf & "}")
		
		SplitB04(TheCode, TheCodeA, vbLf)
		
		TheCode = ""
		
		Dim numberofparantesis As Short
		
		For counter = 0 To UBound(TheCodeA)
			If InStr(TheCodeA(counter), "#") = 0 Then
				TheCode = TheCode & TheCodeA(counter) & vbLf
			ElseIf InStr(TheCodeA(counter), "#") <> 1 Then 
				TheCode = TheCode & VB.Left(TheCodeA(counter), InStr(TheCodeA(counter), "#") - 1)
			End If
		Next counter
		
		TheCode = LCase(TheCode)
		TheCode = Replace09(TheCode, vbLf, " ")
		TheCode = Replace09(TheCode, vbTab, " ")
		TheCode = Replace09(TheCode, ";", " ")
		TheCode = Replace09(TheCode, ",", " ")
		TheCode = Replace09(TheCode, "{{", "{ {")
		TheCode = Replace09(TheCode, "}}", "} }")
		
		Do While InStr(TheCode, "  ")
			TheCode = Replace09(TheCode, "  ", " ")
		Loop 
		
		SplitB04(TheCode, TheCodeA)
		
		Dim TheLabelCollection As String
		
		For counter = 0 To UBound(TheCodeA)
			If InStr(TheCodeA(counter), "{") Then
				If InStr(TheCodeA(counter), "}") = 0 Then
					numberofparantesis = numberofparantesis + 1
				End If
			Else
				If InStr(TheCodeA(counter), "}") Then
					numberofparantesis = numberofparantesis - 1
				Else
					If InStr(TheCodeA(counter), ":") And numberofparantesis = 0 Then
						If InStr(TheLabelCollection, " " & TheCodeA(counter)) Then
							MsgBox("Duplic label.",  , "Bug Alert!")
							RobotCode.Focus()
							RobotCode.Find(TheCodeA(counter), InStr(LCase(RobotCode.Text), TheCodeA(counter)))
							SyntaxCheck = True
							Exit Function
						Else
							TheLabelCollection = TheLabelCollection & " " & TheCodeA(counter)
						End If
					End If
				End If
			End If
		Next counter
		
		If numberofparantesis < 0 Then
			MsgBox("You have too many }.",  , "Bug Alert!")
			RobotCode.Focus()
			RobotCode.SelectionStart = Len(RobotCode.Text) - InStr(StrReverse(RobotCode.Text), "}")
			RobotCode.SelectionLength = 1
			SyntaxCheck = True
			Exit Function
		ElseIf numberofparantesis > 0 Then 
			MsgBox("Comment not closed.",  , "Bug Alert!")
			RobotCode.Focus()
			RobotCode.SelectionStart = Len(RobotCode.Text) - InStr(StrReverse(RobotCode.Text), "{")
			RobotCode.SelectionLength = 1
			SyntaxCheck = True
			Exit Function
		End If
	End Function
	
	Public Sub SyntaxColoringMenu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SyntaxColoringMenu.Click
		If SyntaxColoringMenu.Checked Then
			SyntaxColoringMenu.Checked = False
			SyntaxColoringCache = False
		Else
			SyntaxColoringMenu.Checked = True
			SyntaxColoringCache = True
		End If
		
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, SyntaxColoringCache, 10500)
		
		'    MsgBox "This change takes effect the next time the Drafting Board is loaded." & vbCr & "(To do this, first close this message, then press F1, then F2.)", vbInformation, "Switch Syntax Coloring On/Off"
		MsgBox("This change takes effect the next time the Drafting Board is loaded." & vbCr & "(To do this, first close this message, then press F1, then F2.)", MsgBoxStyle.Information, "Syntax Coloring")
		If SyntaxColoringCache Then MsgBox("Syntax Coloring is currently in beta stage.",  , "Syntax Coloring")
	End Sub
	
	'Private Sub TestColor_Click()   'DEBUG - REMOVE LATER
	'RobotCode.SelColor = RGB(CommentRed, CommentGreen, CommentBlue)
	'End Sub
	'
	'Private Sub TestSave_Click()    'DEBUG - REMOVE LATER
	'RobotCode.SaveFile ("E:\Test.txt")
	'End Sub
	
	Public Sub Tutorial_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Tutorial.Click
		ShowTutorial()
	End Sub
	
	Public Sub Undo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Undo.Click
		System.Windows.Forms.SendKeys.SendWait("^{Z}")
	End Sub
	
	Private Sub SkrivKoden()
		'This sub is run every time the user exits the drafting board to save the robot
		
		Dim NewRobot As String
		Dim rcode As String
		Dim CursorPosition As Integer
		If AutoCompile.Checked And Not RecompileLock.Checked Then
			'When we should write the code and compile it gets a little tricky
			SkrivKodenSamtCompilera((True))
		Else
			' Just write the code
			rcode = RobotCode.Text
			'If RCode <> "" Then RCode = Left$(RCode, Len(RCode) - 1)    'The drafting board seems to put on an additional new row character. This compensates
			If VB.Right(rcode, 1) = vbCr Then rcode = VB.Left(rcode, Len(rcode) - 1) 'The drafting board seems to put on an additional new row character. This compensates
			'MsgBox Asc(Right(RCode, 1))
			
			FileOpen(1, PathToRobot, OpenMode.Binary)
			CursorPosition = RobotCode.SelectionStart
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If ResetCursorPosition.Checked Then
				FilePut(1, CInt(0), CPosrec)
			Else
				'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FilePut(1, CursorPosition, CPosrec)
			End If
			
			NewRobot = Space(Cstart - 1) 'Reads the robot 0 to one byte before the old code started
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, NewRobot, 1) 'I have no idea why it should be -1 however
			FileClose(1)
			
			NewRobot = NewRobot & rcode
			FileOpen(1, PathToRobot, OpenMode.Output)
			PrintLine(1, NewRobot)
			FileClose(1)
		End If
		
	End Sub
	
	Private Sub SkrivKodenSamtCompilera(ByRef SyntaxCheckDisabled As Boolean) 'Syntax check on -> full syntax check enabled. 'Syntax check off -> as fast as possible ' Just write the code
		Dim RobotDrones As Byte
		Dim NewRobot As String
		Dim rcode As String
		rcode = RobotCode.Text
		
		Dim StrMachineCode As String
		Dim StrMachineCodeArray() As String
		Dim NumberOfInstructions As Short
		
		If IsCRobot Then 'Support for C robots
			StrMachineCode = Compile(C2RoboTalk(rcode))
		Else 'Common RoboTalk Robots
			If Not SyntaxCheckDisabled Then
				If SyntaxCheck(rcode) Then Exit Sub
			End If
			
			StrMachineCode = Compile(rcode)
		End If
		
		If VB.Right(rcode, 1) = vbCr Then rcode = VB.Left(rcode, Len(rcode) - 1) 'The drafting board seems to put on an additional new row character. This compensates
		
		StrMachineCodeArray = Split(StrMachineCode, vbCr)
		NumberOfInstructions = UBound(StrMachineCodeArray) + 1
		
		FileOpen(1, PathToRobot, OpenMode.Binary)
		NewRobot = Space(MStart - 1) 'Reads the robot 0 to one byte before the old machine code started
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, NewRobot, 1)
		Cstart = MStart + NumberOfInstructions * 2
		FileClose(1)
		
		NewRobot = NewRobot & Space(NumberOfInstructions * 2) & rcode
		
		'PREPARE THE MACHINE CODE
		Dim c As Short
		Dim IntMachineCodeArray() As Short
		
		If NumberOfInstructions > INSTRUCTIONLIMIT Then
			MsgBox("A Robot's code can not be longer than " & INSTRUCTIONLIMIT & " instructions, including ICONx, SNDx, RECALLs and the END instruction." & vbCr & "Instructions after " & INSTRUCTIONLIMIT & " will not be loaded.", MsgBoxStyle.Exclamation, "Code too long.")
			NumberOfInstructions = INSTRUCTIONLIMIT
			StrMachineCodeArray(4999) = "END"
		End If
		
		NumberOfInstructions = NumberOfInstructions - 1
		
		ReDim IntMachineCodeArray(NumberOfInstructions)
		
		Dim sInst As String
		
		Dim LineNumbersCache As Boolean
		If SyntaxCheckDisabled Then 'Without syntax check and as fast as possible
			For c = 0 To NumberOfInstructions
				sInst = StrMachineCodeArray(c)
				If IsNumeric(sInst) Then
					IntMachineCodeArray(c) = CShort(StrMachineCodeArray(c))
				Else
					IntMachineCodeArray(c) = Inst2MagicNumber(StrMachineCodeArray(c))
				End If
			Next c
		Else 'With syntax check and everything
			LineNumbersCache = PrintLineNumbers.Checked
			
			For c = 0 To NumberOfInstructions
				sInst = StrMachineCodeArray(c)
				If IsNumeric(sInst) Then
					IntMachineCodeArray(c) = CShort(StrMachineCodeArray(c))
				Else
					IntMachineCodeArray(c) = Inst2MagicNumber(StrMachineCodeArray(c))
					If IntMachineCodeArray(c) = iUNKOWN Then
						MsgBox("Unknown token. " & StrMachineCodeArray(c),  , "Bug Alert!")
						RobotCode.Focus()
						If IsCRobot Then RobotCode.Find(StrMachineCodeArray(c)) Else SearchInst(c)
						Exit Sub
					End If
				End If
				
				If LineNumbersCache Then StrMachineCodeArray(c) = c & ":   " & StrMachineCodeArray(c)
			Next c
			
			Label3.Text = Len(rcode) + 1 & " Bytes"
			Label4.Text = UBound(StrMachineCodeArray) + 1 & " Instructions"
			
			If LineNumbersCache Then
				'UPGRADE_WARNING: TextRTF was upgraded to Text and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				MachineCodeText.Text = Join(StrMachineCodeArray, vbCr)
			Else
				'UPGRADE_WARNING: TextRTF was upgraded to Text and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				MachineCodeText.Text = StrMachineCode
			End If
			
			NoErrors.Visible = True
		End If
		
		'FLYTTAT HIT SÅ ATT DEN INTE SKRIVER NÅGOT OM DET BLIR KOMPILERINGSFEL
		FileOpen(1, PathToRobot, OpenMode.Output)
		PrintLine(1, NewRobot)
		FileClose(1)
		
		FileOpen(1, PathToRobot, OpenMode.Binary)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, Cstart, Crec)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, IntMachineCodeArray, MStart)
		Dim CursorPosition As Integer
		CursorPosition = RobotCode.SelectionStart
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If ResetCursorPosition.Checked Then
			FilePut(1, CInt(0), CPosrec)
		Else
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(1, CursorPosition, CPosrec)
		End If
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, RobotDrones, DroneRec)
		If RobotDrones <> 0 Then 'If drones are 1 or 2
			'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			If InStrB(StrMachineCode, "DRONE'") = 0 Then 'If it have drones equiped but do not use them
				'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FilePut(1, CByte(2), DroneRec)
			ElseIf RobotDrones = 2 Then  'If drones are used but wrongfully registred as not being used
				'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FilePut(1, CByte(1), DroneRec)
			End If
		End If
		
		'Get #1, DroneRec, RobotDrones 'DEBUG!!!
		FileClose(1)
		
		'MsgBox "Drones = " & RobotDrones
	End Sub
	
	Private Function C2RoboTalk(ByVal cCode As String) As String
		Dim res As Integer
		Dim RoboTalkCodeBuffer As String
		Dim cCodeBuffer As String
		Dim SkipNum As Integer
		
		cCodeBuffer = cCode
		
		RoboTalkCodeBuffer = Space(Len(cCodeBuffer) + 1000000) 'We give it 1 MB additional buffer
		
		res = RoboTranslate(RoboTalkCodeBuffer, cCodeBuffer)
		
		If res <> 0 Then
			'res = res + 1 'It seems to be confused by one or two lines before the actual problem
			MsgBox("C to RoboTalk compilation. Line " & res,  , "Bug Alert!")
			go_to_line(res, RobotCode)
			C2RoboTalk = ""
			Exit Function
		End If
		
		RoboTalkCodeBuffer = RTrim(RoboTalkCodeBuffer)
		
		'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		If LenB(RoboTalkCodeBuffer) > 0 Then
			SkipNum = Asc(VB.Right(RoboTalkCodeBuffer, 1))
			Do Until SkipNum <> 10 And SkipNum <> 13 And SkipNum <> 0 And SkipNum <> 32
				RoboTalkCodeBuffer = VB.Left(RoboTalkCodeBuffer, Len(RoboTalkCodeBuffer) - 1)
				'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
				If LenB(RoboTalkCodeBuffer) = 0 Then Exit Do
				SkipNum = Asc(VB.Right(RoboTalkCodeBuffer, 1))
			Loop 
		End If
		
		C2RoboTalk = RoboTalkCodeBuffer
	End Function
	
	Private Function Compile(ByVal Stage1Code As String) As String
		' This sub translates the RoboTalk code to a machine code
		' that consists a long string. The instructions are separated by Chr(13)
		
		' GENERAL STUFF
		On Error GoTo CompilingError1
		Dim splitcode() As String
		Dim splitcode2() As String
		Dim SkipNum As Integer
		Dim counter As Integer
		
		Dim LN(399) As String
		Dim LP(399) As Integer
		Dim Instructionn As String
		
		' {}-COMMENTS
		' Can handle 2147483647 nested comments, or can it...? - Klarar 2147483647 nested comments, eller gör den...?
		
		' GAMLA
		Stage1Code = Replace09(Stage1Code, "}}", "} }") & vbCr 'it seems to have problems with }}, also includes the line under
		SplitB04(Stage1Code, splitcode, "}")
		Stage1Code = ""
		
		For counter = 0 To UBound(splitcode)
			If SkipNum > 0 Then
				SkipNum = SkipNum - 1
			Else
				SplitB04(splitcode(counter), splitcode2, "{")
				SkipNum = UBound(splitcode2) - 1
				'Stage1Code = Stage1Code & " " & SplitCode2(0)
				If UBound(splitcode2) <> -1 Then Stage1Code = Stage1Code & " " & splitcode2(0)
			End If
		Next counter
		
		' #-COMMENTS
		'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		Do While InStrB(Stage1Code, vbLf) <> 0
			Stage1Code = Replace09(Stage1Code, vbLf, vbCr) 'Behövs för stjärnkommentarborttagaren om användaren skulle råkat fått in vblf
		Loop 
		
		counter = InStr(Stage1Code, "#")
		Do While counter <> 0
			Stage1Code = VB.Left(Stage1Code, counter - 1) & VB.Right(Stage1Code, Len(Stage1Code) - InStr(counter, Stage1Code, vbCr))
			counter = InStr(Stage1Code, "#")
		Loop 
		
		' DELIMINERS
		'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		Do While InStrB(Stage1Code, vbTab) <> 0
			Stage1Code = Replace09(Stage1Code, vbTab, vbCr)
		Loop 
		'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		Do While InStrB(Stage1Code, ";") <> 0
			Stage1Code = Replace09(Stage1Code, ";", vbCr)
		Loop 
		'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		Do While InStrB(Stage1Code, ",") <> 0
			Stage1Code = Replace09(Stage1Code, ",", vbCr)
		Loop 
		'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		Do While InStrB(Stage1Code, vbCr) <> 0
			Stage1Code = Replace09(Stage1Code, vbCr, " ")
		Loop 
		'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		Do While InStrB(Stage1Code, "  ") <> 0
			Stage1Code = Replace09(Stage1Code, "  ", " ")
		Loop 
		
		' RECALLS + STO -> STORE and many others as well
		' Recalls must be added before we do the labels, otherwise the labels will get wrong numbers
		
		Stage1Code = UCase(Stage1Code)
		SplitB04(Stage1Code, splitcode)
		
		'For counter = 0 To UBound(splitcode)
		'    Select Case splitcode(counter)
		'        Case "COLLISION"
		'            splitcode(counter) = "COLLISION' RECALL"
		'        Case "AIM"
		'            splitcode(counter) = "AIM' RECALL"
		'        Case "FRIEND"
		'            splitcode(counter) = "FRIEND' RECALL"
		'        Case "DAMAGE"
		'            splitcode(counter) = "DAMAGE' RECALL"
		'        Case "DOPPLER"
		'            splitcode(counter) = "DOPPLER' RECALL"
		'        Case "HISTORY"
		'            splitcode(counter) = "HISTORY' RECALL"
		'        Case "ID"
		'            splitcode(counter) = "ID' RECALL"
		'        Case "KILLS"
		'            splitcode(counter) = "KILLS' RECALL"
		'        Case "LOOK"
		'            splitcode(counter) = "LOOK' RECALL"
		'        Case "RANDOM"
		'            splitcode(counter) = "RANDOM' RECALL"
		'        Case "RANGE"
		'            splitcode(counter) = "RANGE' RECALL"
		'        Case "ROBOTS"
		'            splitcode(counter) = "ROBOTS' RECALL"
		'        Case "SCAN"
		'            splitcode(counter) = "SCAN' RECALL"
		'        Case "SHIELD"
		'            splitcode(counter) = "SHIELD' RECALL"
		'        Case "SPEEDX"
		'            splitcode(counter) = "SPEEDX' RECALL"
		'        Case "SPEEDY"
		'            splitcode(counter) = "SPEEDY' RECALL"
		'        Case "TEAMMATES"
		'            splitcode(counter) = "TEAMMATES' RECALL"
		'        Case "WALL"
		'            splitcode(counter) = "WALL' RECALL"
		'        Case "RADAR"
		'            splitcode(counter) = "RADAR' RECALL"
		'        Case "SIGNAL"
		'            splitcode(counter) = "SIGNAL' RECALL"
		'        Case "CHANNEL"
		'            splitcode(counter) = "CHANNEL' RECALL"
		'        Case "CHRONON"
		'            splitcode(counter) = "CHRONON' RECALL"
		'        Case "PROBE"
		'            splitcode(counter) = "PROBE' RECALL"
		'        Case "ENERGY"
		'            splitcode(counter) = "ENERGY' RECALL"
		'        Case "NEAREST"
		'            splitcode(counter) = "NEAREST' RECALL"
		'
		'        Case "A"
		'            splitcode(counter) = "A' RECALL"
		'        Case "B"
		'            splitcode(counter) = "B' RECALL"
		'        Case "C"
		'            splitcode(counter) = "C' RECALL"
		'        Case "D"
		'            splitcode(counter) = "D' RECALL"
		'        Case "E"
		'            splitcode(counter) = "E' RECALL"
		'        Case "F"
		'            splitcode(counter) = "F' RECALL"
		'        Case "G"
		'            splitcode(counter) = "G' RECALL"
		'        Case "H"
		'            splitcode(counter) = "H' RECALL"
		'        Case "I"
		'            splitcode(counter) = "I' RECALL"
		'        Case "J"
		'            splitcode(counter) = "J' RECALL"
		'        Case "K"
		'            splitcode(counter) = "K' RECALL"
		'        Case "L"
		'            splitcode(counter) = "L' RECALL"
		'        Case "M"
		'            splitcode(counter) = "M' RECALL"
		'        Case "N"
		'            splitcode(counter) = "N' RECALL"
		'        Case "O"
		'            splitcode(counter) = "O' RECALL"
		'        Case "P"
		'            splitcode(counter) = "P' RECALL"
		'        Case "Q"
		'            splitcode(counter) = "Q' RECALL"
		'        Case "R"
		'            splitcode(counter) = "R' RECALL"
		'        Case "S"
		'            splitcode(counter) = "S' RECALL"
		'        Case "T"
		'            splitcode(counter) = "T' RECALL"
		'        Case "U"
		'            splitcode(counter) = "U' RECALL"
		'        Case "V"
		'            splitcode(counter) = "V' RECALL"
		'        Case "W"
		'            splitcode(counter) = "W' RECALL"
		'        Case "X"
		'            splitcode(counter) = "X' RECALL"
		'        Case "Y"
		'            splitcode(counter) = "Y' RECALL"
		'        Case "Z"
		'            splitcode(counter) = "Z' RECALL"
		'
		'        Case "STO"
		'            splitcode(counter) = "STORE"
		'        Case "BOTTOM'"
		'            splitcode(counter) = "BOT'"
		'        Case "COSINE"
		'            splitcode(counter) = "COS"
		'        Case "DEBUGGER"
		'            splitcode(counter) = "DEBUG"
		'        Case "TANGENT"
		'            splitcode(counter) = "TAN"
		'        Case "SINE"
		'            splitcode(counter) = "SIN"
		'        Case "EOR"
		'            splitcode(counter) = "XOR"
		'        Case "RETURN"
		'            splitcode(counter) = "JUMP"
		'        Case "HELL'"
		'            splitcode(counter) = "HELLBORE'"
		'    End Select
		'Next
		
		For counter = 0 To UBound(splitcode)
			If splitcode(counter) = "COLLISION" Then splitcode(counter) = "COLLISION' RECALL"
			If splitcode(counter) = "AIM" Then splitcode(counter) = "AIM' RECALL"
			If splitcode(counter) = "FRIEND" Then splitcode(counter) = "FRIEND' RECALL"
			If splitcode(counter) = "DAMAGE" Then splitcode(counter) = "DAMAGE' RECALL"
			If splitcode(counter) = "DOPPLER" Then splitcode(counter) = "DOPPLER' RECALL"
			If splitcode(counter) = "HISTORY" Then splitcode(counter) = "HISTORY' RECALL"
			If splitcode(counter) = "ID" Then splitcode(counter) = "ID' RECALL"
			If splitcode(counter) = "KILLS" Then splitcode(counter) = "KILLS' RECALL"
			If splitcode(counter) = "LOOK" Then splitcode(counter) = "LOOK' RECALL"
			If splitcode(counter) = "RANDOM" Then splitcode(counter) = "RANDOM' RECALL"
			If splitcode(counter) = "RANGE" Then splitcode(counter) = "RANGE' RECALL"
			If splitcode(counter) = "ROBOTS" Then splitcode(counter) = "ROBOTS' RECALL"
			If splitcode(counter) = "SCAN" Then splitcode(counter) = "SCAN' RECALL"
			If splitcode(counter) = "SHIELD" Then splitcode(counter) = "SHIELD' RECALL"
			If splitcode(counter) = "SPEEDX" Then splitcode(counter) = "SPEEDX' RECALL"
			If splitcode(counter) = "SPEEDY" Then splitcode(counter) = "SPEEDY' RECALL"
			If splitcode(counter) = "TEAMMATES" Then splitcode(counter) = "TEAMMATES' RECALL"
			If splitcode(counter) = "WALL" Then splitcode(counter) = "WALL' RECALL"
			If splitcode(counter) = "RADAR" Then splitcode(counter) = "RADAR' RECALL"
			If splitcode(counter) = "SIGNAL" Then splitcode(counter) = "SIGNAL' RECALL"
			If splitcode(counter) = "CHANNEL" Then splitcode(counter) = "CHANNEL' RECALL"
			If splitcode(counter) = "CHRONON" Then splitcode(counter) = "CHRONON' RECALL"
			If splitcode(counter) = "PROBE" Then splitcode(counter) = "PROBE' RECALL"
			If splitcode(counter) = "ENERGY" Then splitcode(counter) = "ENERGY' RECALL"
			If splitcode(counter) = "NEAREST" Then splitcode(counter) = "NEAREST' RECALL"
			
			If splitcode(counter) = "A" Then splitcode(counter) = "A' RECALL"
			If splitcode(counter) = "B" Then splitcode(counter) = "B' RECALL"
			If splitcode(counter) = "C" Then splitcode(counter) = "C' RECALL"
			If splitcode(counter) = "D" Then splitcode(counter) = "D' RECALL"
			If splitcode(counter) = "E" Then splitcode(counter) = "E' RECALL"
			If splitcode(counter) = "F" Then splitcode(counter) = "F' RECALL"
			If splitcode(counter) = "G" Then splitcode(counter) = "G' RECALL"
			If splitcode(counter) = "H" Then splitcode(counter) = "H' RECALL"
			If splitcode(counter) = "I" Then splitcode(counter) = "I' RECALL"
			If splitcode(counter) = "J" Then splitcode(counter) = "J' RECALL"
			If splitcode(counter) = "K" Then splitcode(counter) = "K' RECALL"
			If splitcode(counter) = "L" Then splitcode(counter) = "L' RECALL"
			If splitcode(counter) = "M" Then splitcode(counter) = "M' RECALL"
			If splitcode(counter) = "N" Then splitcode(counter) = "N' RECALL"
			If splitcode(counter) = "O" Then splitcode(counter) = "O' RECALL"
			If splitcode(counter) = "P" Then splitcode(counter) = "P' RECALL"
			If splitcode(counter) = "Q" Then splitcode(counter) = "Q' RECALL"
			If splitcode(counter) = "R" Then splitcode(counter) = "R' RECALL"
			If splitcode(counter) = "S" Then splitcode(counter) = "S' RECALL"
			If splitcode(counter) = "T" Then splitcode(counter) = "T' RECALL"
			If splitcode(counter) = "U" Then splitcode(counter) = "U' RECALL"
			If splitcode(counter) = "V" Then splitcode(counter) = "V' RECALL"
			If splitcode(counter) = "W" Then splitcode(counter) = "W' RECALL"
			If splitcode(counter) = "X" Then splitcode(counter) = "X' RECALL"
			If splitcode(counter) = "Y" Then splitcode(counter) = "Y' RECALL"
			If splitcode(counter) = "Z" Then splitcode(counter) = "Z' RECALL"
			
			If splitcode(counter) = "STO" Then splitcode(counter) = "STORE"
			If splitcode(counter) = "BOTTOM'" Then splitcode(counter) = "BOT'"
			If splitcode(counter) = "COSINE" Then splitcode(counter) = "COS"
			If splitcode(counter) = "DEBUGGER" Then splitcode(counter) = "DEBUG"
			If splitcode(counter) = "TANGENT" Then splitcode(counter) = "TAN"
			If splitcode(counter) = "SINE" Then splitcode(counter) = "SIN"
			If splitcode(counter) = "EOR" Then splitcode(counter) = "XOR"
			If splitcode(counter) = "RETURN" Then splitcode(counter) = "JUMP"
			If splitcode(counter) = "HELL'" Then splitcode(counter) = "HELLBORE'"
		Next 
		
		Stage1Code = Join(splitcode)
		
		Stage1Code = " " & Stage1Code & " " 'Adds a linebrake in the beginning and end so it won't fail to fix tokens in the start and end
		
		' LABELS
		SkipNum = -1
		SplitB04(Stage1Code, splitcode)
		
		For counter = 0 To UBound(splitcode)
			Instructionn = splitcode(counter)
			'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			If InStrB(Instructionn, ":") <> 0 Then 'Checks if there's ":" in the instruction. If there is it's a label definition
				SkipNum = SkipNum + 1 'If it is then
				If SkipNum > 399 Then
					MsgBox("Your robot's code exceedes 400 labels. Please reduce the number of labels.",  , "Compiling Error")
					Compile = "END"
					Exit Function
				End If
				LP(SkipNum) = counter - SkipNum - 2 'Records which inst. nr. the label corresponds to
				LN(SkipNum) = Replace09(Instructionn, ":", "") 'Records the name of the label
				splitcode(counter) = "" 'Removes the label definition from the code
			End If
		Next counter
		
		For SkipNum = 0 To SkipNum 'Replaces labels with instruction numbers. This is the major reason why the compiler is so sluggish
			For counter = 0 To UBound(splitcode)
				If splitcode(counter) = LN(SkipNum) Then splitcode(counter) = CStr(LP(SkipNum))
			Next counter
		Next SkipNum
		
		Stage1Code = Join(splitcode, vbCr) 'Assembles the code again with label definitions removed.
		
		' EXTRA PROCESSING
		Do While VB.Left(Stage1Code, 1) = vbCr
			Stage1Code = VB.Right(Stage1Code, Len(Stage1Code) - 1)
		Loop 
		
		'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		Do While InStrB(Stage1Code, vbCr & vbCr) <> 0 'removed double vbCr created from the label recorder
			Stage1Code = Replace09(Stage1Code, vbCr & vbCr, vbCr)
		Loop 
		
		If Stage1Code <> "" Then
			Stage1Code = VB.Left(Stage1Code, Len(Stage1Code) - 1)
			Stage1Code = Stage1Code & vbCr & "END"
		Else
			Stage1Code = "END"
		End If
		
		Compile = Stage1Code
		
		Exit Function
		
		' ERROR HANDLER
		
CompilingError1: 
		MsgBox("There was a compiling error:" & vbCr & Err.Description & "." & vbCr & vbCr & "Please verify that the code you've entered is correct." & vbCr & "This is most commonly caused by nested {}-comments.",  , "Compiling Error")
		
		Compile = "END"
	End Function
	
	
	Private Function Inst2MagicNumber(ByRef Instruction As String) As Short
		
		Select Case Instruction
			Case "STORE"
				Inst2MagicNumber = 20100
			Case "AIM'"
				Inst2MagicNumber = 20330
			Case "RECALL"
				Inst2MagicNumber = 20109
			Case "LOOK'"
				Inst2MagicNumber = 20344
			Case "IFG"
				Inst2MagicNumber = 20140
			Case ">"
				Inst2MagicNumber = 20004
			Case "RANGE'"
				Inst2MagicNumber = 20329
			Case "SETINT"
				Inst2MagicNumber = 20156
			Case "SETPARAM"
				Inst2MagicNumber = 20157
			Case "<"
				Inst2MagicNumber = 20005
			Case "DUP"
				Inst2MagicNumber = 20106
			Case "CALL"
				Inst2MagicNumber = 20105
			Case "IFEG"
				Inst2MagicNumber = 20141
			Case "RADAR'"
				Inst2MagicNumber = 20343
			Case "JUMP"
				Inst2MagicNumber = 20104
			Case "+"
				Inst2MagicNumber = 20000
			Case "SCAN'"
				Inst2MagicNumber = 20345
			Case "-"
				Inst2MagicNumber = 20001
			Case "X'"
				Inst2MagicNumber = 20323
			Case "Y'"
				Inst2MagicNumber = 20324
			Case "FIRE'"
				Inst2MagicNumber = 20326
			Case "ENERGY'"
				Inst2MagicNumber = 20327
			Case "SHIELD'"
				Inst2MagicNumber = 20328
			Case "SPEEDX'"
				Inst2MagicNumber = 20331
			Case "SPEEDY'"
				Inst2MagicNumber = 20332
			Case "/"
				Inst2MagicNumber = 20003
			Case "*"
				Inst2MagicNumber = 20002
			Case "DROP"
				Inst2MagicNumber = 20101
			Case "SWAP"
				Inst2MagicNumber = 20102
			Case "ROLL"
				Inst2MagicNumber = 20103
			Case "IF"
				Inst2MagicNumber = 20107
			Case "IFE"
				Inst2MagicNumber = 20108
			Case "="
				Inst2MagicNumber = 20006
			Case "!"
				Inst2MagicNumber = 20007
			Case "NOP"
				Inst2MagicNumber = 20111
			Case "AND"
				Inst2MagicNumber = 20112
			Case "OR"
				Inst2MagicNumber = 20113
			Case "XOR"
				Inst2MagicNumber = 20114
			Case "MOD"
				Inst2MagicNumber = 20115
			Case "BEEP"
				Inst2MagicNumber = 20116
			Case "CHS"
				Inst2MagicNumber = 20117
			Case "NOT"
				Inst2MagicNumber = 20118
			Case "ARCTAN"
				Inst2MagicNumber = 20119
			Case "ABS"
				Inst2MagicNumber = 20120
			Case "SIN"
				Inst2MagicNumber = 20121
			Case "COS"
				Inst2MagicNumber = 20122
			Case "TAN"
				Inst2MagicNumber = 20123
			Case "SQRT"
				Inst2MagicNumber = 20124
			Case "ICON0"
				Inst2MagicNumber = 20125
			Case "ICON1"
				Inst2MagicNumber = 20126
			Case "ICON2"
				Inst2MagicNumber = 20127
			Case "ICON3"
				Inst2MagicNumber = 20128
			Case "ICON4"
				Inst2MagicNumber = 20129
			Case "ICON5"
				Inst2MagicNumber = 20130
			Case "ICON6"
				Inst2MagicNumber = 20131
			Case "ICON7"
				Inst2MagicNumber = 20132
			Case "ICON8"
				Inst2MagicNumber = 20133
			Case "ICON9"
				Inst2MagicNumber = 20134
			Case "PRINT"
				Inst2MagicNumber = 20135
			Case "SYNC"
				Inst2MagicNumber = 20136
			Case "VSTORE"
				Inst2MagicNumber = 20137
			Case "VRECALL"
				Inst2MagicNumber = 20138
			Case "DIST"
				Inst2MagicNumber = 20139
			Case "DEBUG"
				Inst2MagicNumber = 20142
			Case "SND0"
				Inst2MagicNumber = 20143
			Case "SND1"
				Inst2MagicNumber = 20144
			Case "SND2"
				Inst2MagicNumber = 20145
			Case "SND3"
				Inst2MagicNumber = 20146
			Case "SND4"
				Inst2MagicNumber = 20147
			Case "SND5"
				Inst2MagicNumber = 20148
			Case "SND6"
				Inst2MagicNumber = 20149
			Case "SND7"
				Inst2MagicNumber = 20150
			Case "SND8"
				Inst2MagicNumber = 20151
			Case "SND9"
				Inst2MagicNumber = 20152
			Case "INTON"
				Inst2MagicNumber = 20153
			Case "INTOFF"
				Inst2MagicNumber = 20154
			Case "RTI"
				Inst2MagicNumber = 20155
				'    Case         inst2magicNumber = 20158      'SPECIALFALL    'MRB
				'         "MRB"
			Case "DROPALL"
				Inst2MagicNumber = 20159
			Case "FLUSHINT"
				Inst2MagicNumber = 20160
			Case "MAX"
				Inst2MagicNumber = 20161
			Case "MIN"
				Inst2MagicNumber = 20162
			Case "ARCCOS"
				Inst2MagicNumber = 20163
			Case "ARCSIN"
				Inst2MagicNumber = 20164
			Case "A'"
				Inst2MagicNumber = 20300
			Case "B'"
				Inst2MagicNumber = 20301
			Case "C'"
				Inst2MagicNumber = 20302
			Case "D'"
				Inst2MagicNumber = 20303
			Case "E'"
				Inst2MagicNumber = 20304
			Case "F'"
				Inst2MagicNumber = 20305
			Case "G'"
				Inst2MagicNumber = 20306
			Case "H'"
				Inst2MagicNumber = 20307
			Case "I'"
				Inst2MagicNumber = 20308
			Case "J'"
				Inst2MagicNumber = 20309
			Case "K'"
				Inst2MagicNumber = 20310
			Case "L'"
				Inst2MagicNumber = 20311
			Case "M'"
				Inst2MagicNumber = 20312
			Case "N'"
				Inst2MagicNumber = 20313
			Case "O'"
				Inst2MagicNumber = 20314
			Case "P'"
				Inst2MagicNumber = 20315
			Case "Q'"
				Inst2MagicNumber = 20316
			Case "R'"
				Inst2MagicNumber = 20317
			Case "S'"
				Inst2MagicNumber = 20318
			Case "T'"
				Inst2MagicNumber = 20319
			Case "U'"
				Inst2MagicNumber = 20320
			Case "V'"
				Inst2MagicNumber = 20321
			Case "W'"
				Inst2MagicNumber = 20322
			Case "Z'"
				Inst2MagicNumber = 20325
			Case "DAMAGE'"
				Inst2MagicNumber = 20333
			Case "RANDOM'"
				Inst2MagicNumber = 20334
			Case "MISSILE'"
				Inst2MagicNumber = 20335
			Case "NUKE'"
				Inst2MagicNumber = 20336
			Case "COLLISION'"
				Inst2MagicNumber = 20337
			Case "CHANNEL'"
				Inst2MagicNumber = 20338
			Case "SIGNAL'"
				Inst2MagicNumber = 20339
			Case "MOVEX'"
				Inst2MagicNumber = 20340
			Case "MOVEY'"
				Inst2MagicNumber = 20341
				'    Case         inst2magicNumber = 20342      'SPECIALFALL
				'         "JOCE'"
			Case "CHRONON'"
				Inst2MagicNumber = 20346
			Case "HELLBORE'"
				Inst2MagicNumber = 20347
			Case "DRONE'"
				Inst2MagicNumber = 20348
			Case "MINE'"
				Inst2MagicNumber = 20349
			Case "LASER'"
				Inst2MagicNumber = 20350
				'    Case         inst2magicNumber = 20351      'SPECIALFALL
				'         "SUSIE'"
			Case "ROBOTS'"
				Inst2MagicNumber = 20352
			Case "FRIEND'"
				Inst2MagicNumber = 20353
			Case "BULLET'"
				Inst2MagicNumber = 20354
			Case "DOPPLER'"
				Inst2MagicNumber = 20355
			Case "STUNNER'"
				Inst2MagicNumber = 20356
			Case "TOP'"
				Inst2MagicNumber = 20357
			Case "BOT'"
				Inst2MagicNumber = 20358
			Case "LEFT'"
				Inst2MagicNumber = 20359
			Case "RIGHT'"
				Inst2MagicNumber = 20360
			Case "WALL'"
				Inst2MagicNumber = 20361
			Case "TEAMMATES'"
				Inst2MagicNumber = 20362
			Case "PROBE'"
				Inst2MagicNumber = 20363
			Case "HISTORY'"
				Inst2MagicNumber = 20364
			Case "ID'"
				Inst2MagicNumber = 20365
			Case "END"
				Inst2MagicNumber = 20110
			Case "KILLS'"
				Inst2MagicNumber = 20366
			Case "NEAREST'"
				Inst2MagicNumber = 20367
			Case "MEGANUKE'"
				Inst2MagicNumber = 20368
			Case Else
				Inst2MagicNumber = -32768
		End Select
	End Function
	
	Private Sub go_to_line(ByRef linen As Integer, ByRef editbox As System.Windows.Forms.RichTextBox)
		'Transfers the user to a specified richtextbox's line
		'programmed by Alexander Triantafyllou (BSc I.T.) alextriantf@yahoo.gr
		'feel free to use it wherever you like
		'
		'Greetings from Athens - Greece
		
		'(Modified by Kevin Hertzberg)
		
		Dim charindex As Integer
		linen = linen - 1
		charindex = SendMessage(editbox.Handle.ToInt32, EM_LINEINDEX, linen, CInt(0))
		editbox.Focus()
		
		Dim stopchar As Integer
		If charindex <> -1 Then
			LockWindowUpdate(RobotCode.Handle.ToInt32) 'LOCKS!!
			editbox.SelectionStart = charindex
			stopchar = InStr(charindex + 1, editbox.Text, vbCr)
			editbox.SelectionLength = stopchar - charindex
			LockWindowUpdate(0) 'UNLOCKS!!
		End If
		
	End Sub
	
	' This is faster variants of the VB6 native functions Replace and Split
	' Thanks to VBSpeed (http://www.xbeat.net/vbspeed/) for providing!!
	
	'UPGRADE_NOTE: Text was upgraded to Text_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function Replace09(ByRef Text_Renamed As String, ByRef sOld As String, ByRef sNew As String, Optional ByVal start As Integer = 1, Optional ByVal Count As Integer = 2147483647, Optional ByVal Compare As CompareMethod = CompareMethod.Binary) As String
		' by Jost Schwider, jost@schwider.de, 20001218
		
		'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		If LenB(sOld) Then
			
			If Compare = CompareMethod.Binary Then
				Replace09Bin(Replace09, Text_Renamed, Text_Renamed, sOld, sNew, start, Count)
			Else
				Replace09Bin(Replace09, Text_Renamed, LCase(Text_Renamed), LCase(sOld), sNew, start, Count)
			End If
			
		Else 'Suchstring ist leer:
			Replace09 = Text_Renamed
		End If
	End Function
	
	'UPGRADE_NOTE: Text was upgraded to Text_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Replace09Bin(ByRef result As String, ByRef Text_Renamed As String, ByRef Search As String, ByRef sOld As String, ByRef sNew As String, ByVal start As Integer, ByVal Count As Integer)
		' by Jost Schwider, jost@schwider.de, 20001218
		Static TextLen As Integer
		Static OldLen As Integer
		Static NewLen As Integer
		Static ReadPos As Integer
		Static WritePos As Integer
		Static CopyLen As Integer
		Static Buffer As String
		Static BufferLen As Integer
		Static BufferPosNew As Integer
		Static BufferPosNext As Integer
		
		'Ersten Treffer bestimmen:
		If start < 2 Then
			'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			start = InStrB(Search, sOld)
		Else
			'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			start = InStrB(start + start - 1, Search, sOld)
		End If
		If start Then
			
			'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			OldLen = LenB(sOld)
			'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			NewLen = LenB(sNew)
			Select Case NewLen
				Case OldLen 'einfaches Überschreiben:
					
					result = Text_Renamed
					For Count = 1 To Count
						'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
						MidB(result, start) = sNew
						'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
						start = InStrB(start + OldLen, Search, sOld)
						If start = 0 Then Exit Sub
					Next Count
					Exit Sub
					
				Case Is < OldLen 'Ergebnis wird kürzer:
					
					'Buffer initialisieren:
					'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
					TextLen = LenB(Text_Renamed)
					If TextLen > BufferLen Then
						Buffer = Text_Renamed
						BufferLen = TextLen
					End If
					
					'Ersetzen:
					ReadPos = 1
					WritePos = 1
					If NewLen Then
						
						'Einzufügenden Text beachten:
						For Count = 1 To Count
							CopyLen = start - ReadPos
							If CopyLen Then
								BufferPosNew = WritePos + CopyLen
								'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
								'UPGRADE_ISSUE: MidB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
								MidB(Buffer, WritePos) = MidB$(Text_Renamed, ReadPos, CopyLen)
								'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
								MidB(Buffer, BufferPosNew) = sNew
								WritePos = BufferPosNew + NewLen
							Else
								'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
								MidB(Buffer, WritePos) = sNew
								WritePos = WritePos + NewLen
							End If
							ReadPos = start + OldLen
							'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
							start = InStrB(ReadPos, Search, sOld)
							If start = 0 Then Exit For
						Next Count
						
					Else
						
						'Einzufügenden Text ignorieren (weil leer):
						For Count = 1 To Count
							CopyLen = start - ReadPos
							If CopyLen Then
								'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
								'UPGRADE_ISSUE: MidB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
								MidB(Buffer, WritePos) = MidB$(Text_Renamed, ReadPos, CopyLen)
								WritePos = WritePos + CopyLen
							End If
							ReadPos = start + OldLen
							'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
							start = InStrB(ReadPos, Search, sOld)
							If start = 0 Then Exit For
						Next Count
						
					End If
					
					'Ergebnis zusammenbauen:
					If ReadPos > TextLen Then
						'UPGRADE_ISSUE: LeftB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
						result = LeftB$(Buffer, WritePos - 1)
					Else
						'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
						'UPGRADE_ISSUE: MidB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
						MidB(Buffer, WritePos) = MidB$(Text_Renamed, ReadPos)
						'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
						'UPGRADE_ISSUE: LeftB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
						result = LeftB$(Buffer, WritePos + LenB(Text_Renamed) - ReadPos)
					End If
					Exit Sub
					
				Case Else 'Ergebnis wird länger:
					
					'Buffer initialisieren:
					'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
					TextLen = LenB(Text_Renamed)
					BufferPosNew = TextLen + NewLen
					If BufferPosNew > BufferLen Then
						Buffer = Space(BufferPosNew)
						'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
						BufferLen = LenB(Buffer)
					End If
					
					'Ersetzung:
					ReadPos = 1
					WritePos = 1
					For Count = 1 To Count
						CopyLen = start - ReadPos
						If CopyLen Then
							'Positionen berechnen:
							BufferPosNew = WritePos + CopyLen
							BufferPosNext = BufferPosNew + NewLen
							
							'Ggf. Buffer vergrößern:
							If BufferPosNext > BufferLen Then
								Buffer = Buffer & Space(BufferPosNext)
								'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
								BufferLen = LenB(Buffer)
							End If
							
							'String "patchen":
							'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
							'UPGRADE_ISSUE: MidB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
							MidB(Buffer, WritePos) = MidB$(Text_Renamed, ReadPos, CopyLen)
							'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
							MidB(Buffer, BufferPosNew) = sNew
						Else
							'Position bestimmen:
							BufferPosNext = WritePos + NewLen
							
							'Ggf. Buffer vergrößern:
							If BufferPosNext > BufferLen Then
								Buffer = Buffer & Space(BufferPosNext)
								'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
								BufferLen = LenB(Buffer)
							End If
							
							'String "patchen":
							'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
							MidB(Buffer, WritePos) = sNew
						End If
						WritePos = BufferPosNext
						ReadPos = start + OldLen
						'UPGRADE_ISSUE: InStrB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
						start = InStrB(ReadPos, Search, sOld)
						If start = 0 Then Exit For
					Next Count
					
					'Ergebnis zusammenbauen:
					If ReadPos > TextLen Then
						'UPGRADE_ISSUE: LeftB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
						result = LeftB$(Buffer, WritePos - 1)
					Else
						BufferPosNext = WritePos + TextLen - ReadPos
						If BufferPosNext < BufferLen Then
							'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
							'UPGRADE_ISSUE: MidB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
							MidB(Buffer, WritePos) = MidB$(Text_Renamed, ReadPos)
							'UPGRADE_ISSUE: LeftB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
							result = LeftB$(Buffer, BufferPosNext)
						Else
							'UPGRADE_ISSUE: MidB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
							'UPGRADE_ISSUE: LeftB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
							result = LeftB$(Buffer, WritePos - 1) & MidB$(Text_Renamed, ReadPos)
						End If
					End If
					Exit Sub
					
			End Select
			
		Else 'Kein Treffer:
			result = Text_Renamed
		End If
	End Sub
	
	Private Sub SplitB04(ByRef Expression As String, ByRef ResultSplit() As String, Optional ByRef Delimiter As String = " ")
		' By Chris Lucas, cdl1051@earthlink.net, 20011208
		Dim DelLen, c, SLen, tmp As Integer
		Dim Results() As Integer
		
		'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		SLen = LenB(Expression) \ 2
		'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		DelLen = LenB(Delimiter) \ 2
		
		' Bail if we were passed an empty delimiter or an empty expression
		If SLen = 0 Or DelLen = 0 Then
			ReDim Preserve ResultSplit(0)
			ResultSplit(0) = Expression
			Exit Sub
		End If
		
		' Count delimiters and remember their positions
		ReDim Preserve Results(SLen)
		tmp = InStr(Expression, Delimiter)
		
		Do While tmp
			Results(c) = tmp
			c = c + 1
			tmp = InStr(Results(c - 1) + 1, Expression, Delimiter)
		Loop 
		
		' Size our return array
		ReDim Preserve ResultSplit(c)
		
		' Populate the array
		If c = 0 Then
			' lazy man's call
			ResultSplit(0) = Expression
		Else
			' typical call
			ResultSplit(0) = VB.Left(Expression, Results(0) - 1)
			For c = 0 To c - 2
				ResultSplit(c + 1) = Mid(Expression, Results(c) + DelLen, Results(c + 1) - Results(c) - DelLen)
			Next c
			ResultSplit(c + 1) = VB.Right(Expression, SLen - Results(c) - DelLen + 1)
		End If
		
	End Sub
End Class