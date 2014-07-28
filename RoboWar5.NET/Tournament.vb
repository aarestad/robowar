Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class TournamentD
	Inherits System.Windows.Forms.Form
	Private Structure Robot 'Private      'Used to load robots
		Dim Energy As Short
		Dim Damage As Short
		Dim Shield As Short
		Dim Prosessor As Byte
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
	
	Dim CheckCheat As String
	Dim RunningTeams As Boolean
	
	Public DuelsN As Integer 'integer
	Public GRNumber As Integer 'integer
	
	Private Sub AddBot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AddBot.Click
		Dim Press As String
		Dim CancelAdd As Short
		Dim Decided As Short
		
		Dim res As Byte
		
		If File.FileName = "" Then Exit Sub
		
RepeatCheatChecking: 
		
		If DoesCheat(File.Path & "\" & File.FileName) Then
			If CheckCheat = "The robot seems to be broken, and cannot be loaded." Then
				MsgBox(CheckCheat)
				Exit Sub
			ElseIf CheckCheat = "The robot has disallowed hardware values." Then 
				CancelAdd = -1
				Press = "Press Cancel to disable hardware checking"
				Decided = -1
				Press = vbCr & vbCr & "(" & Press & ".)"
			ElseIf CheckCheat = "The robot has has more hardwarepoints than the max hardwarepoints." Then 
				CancelAdd = -1
				Select Case TextHP.Text
					Case Is <= CStr(2)
						Press = "Press Cancel to change to Mortal"
						Decided = 9
					Case Is <= CStr(9)
						Press = "Press Cancel to change to Titan"
						Decided = 23
				End Select
				Press = vbCr & vbCr & "(" & Press & ".)"
			ElseIf CheckCheat = "The robot uses Lasers. You've set them to be dissallowed." Then 
				CancelAdd = -1
				Press = "Press Cancel if you would like to allow lasers"
				Decided = -2
				Press = vbCr & vbCr & "(" & Press & ".)"
			ElseIf CheckCheat = "The robot uses Drones. You've set them to be dissallowed." Then 
				CancelAdd = -1
				Press = "Press Cancel if you would like to allow drones"
				Decided = -3
				Press = vbCr & vbCr & "(" & Press & ".)"
			End If
			
			res = MsgBox(CheckCheat & vbCr & "Do you want to allow it to compete in the tournament anyway?" & Press, MsgBoxStyle.YesNo + CancelAdd + MsgBoxStyle.Information, "The Robot " & VB.Left(File.FileName, Len(File.FileName) - 4) & " doesn't follow the choosen set of rules.")
			
			If res = MsgBoxResult.No Then
				Exit Sub
			ElseIf res = MsgBoxResult.Cancel Then 
				Select Case Decided
					Case Is > 0
						TextHP.Text = CStr(Decided)
					Case -3
						AllowDrones.CheckState = System.Windows.Forms.CheckState.Checked
					Case -2
						AllowLasers.CheckState = System.Windows.Forms.CheckState.Checked
					Case -1
						CheckNoHPLimit.CheckState = System.Windows.Forms.CheckState.Checked
				End Select
				GoTo RepeatCheatChecking
			End If
		End If
		
		RobotList.Items.Add(VB.Left(File.FileName, Len(File.FileName) - 4))
		TheDirList.Items.Add(Directory.Path)
		
	End Sub
	
	Private Sub AddTeamMember(ByRef TheTeamMember As String)
		Dim Press As String
		Dim CancelAdd As Short
		Dim Decided As Short
		
		Dim res As Byte
		
RepeatCheatChecking: 
		
		If DoesCheat(File.Path & "\" & TheTeamMember & ".RWR") Then
			If CheckCheat = "The robot seems to be broken, and cannot be loaded." Then
				MsgBox(CheckCheat)
				Exit Sub
			ElseIf CheckCheat = "The robot has disallowed hardware values." Then 
				CancelAdd = -1
				Press = "Press Cancel to disable hardware checking"
				Decided = -1
				Press = vbCr & vbCr & "(" & Press & ".)"
			ElseIf CheckCheat = "The robot has has more hardwarepoints than the max hardwarepoints." Then 
				CancelAdd = -1
				Select Case SlaveTextHP.Text
					Case Is <= CStr(2)
						Press = "Press Cancel to change to Mortal"
						Decided = 9
					Case Is <= CStr(9)
						Press = "Press Cancel to change to Titan"
						Decided = 23
				End Select
				Press = vbCr & vbCr & "(" & Press & ".)"
			ElseIf CheckCheat = "The robot uses Lasers. You've set them to be dissallowed." Then 
				CancelAdd = -1
				Press = "Press Cancel if you would like to allow lasers"
				Decided = -2
				Press = vbCr & vbCr & "(" & Press & ".)"
			ElseIf CheckCheat = "The robot uses Drones. You've set them to be dissallowed." Then 
				CancelAdd = -1
				Press = "Press Cancel if you would like to allow drones"
				Decided = -3
				Press = vbCr & vbCr & "(" & Press & ".)"
			End If
			
			res = MsgBox(CheckCheat & vbCr & "Do you want to allow it to compete in the tournament anyway?" & Press, MsgBoxStyle.YesNo + CancelAdd + MsgBoxStyle.Information, "The Robot " & VB.Left(File.FileName, Len(File.FileName) - 4) & " doesn't follow the choosen set of rules.")
			
			If res = MsgBoxResult.No Then
				Exit Sub
			ElseIf res = MsgBoxResult.Cancel Then 
				Select Case Decided
					Case Is > 0
						TextHP.Text = CStr(Decided)
					Case -3
						AllowDrones.CheckState = System.Windows.Forms.CheckState.Checked
					Case -2
						AllowLasers.CheckState = System.Windows.Forms.CheckState.Checked
					Case -1
						CheckNoHPLimit.CheckState = System.Windows.Forms.CheckState.Checked
				End Select
				GoTo RepeatCheatChecking
			End If
		End If
		
		RobotList.Items.Add(TheTeamMember)
		TheDirList.Items.Add(Directory.Path)
		
	End Sub
	
	Private Sub AddDir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AddDir.Click
		Dim counter As Short
		
		Dim Cstart As Integer
		Const Crec As Short = 116
		Dim TeamTag As New VB6.FixedLengthString(765)
		Dim sTeam() As String
		If RunningTeams Then
			On Error GoTo errhandler
			
			
			
			
			For counter = 0 To File.Items.Count - 1
				File.SetSelected(counter, True)
				FileOpen(1, File.Path & "\" & File.FileName, OpenMode.Binary)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, Cstart, Crec)
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, TeamTag.Value, Cstart)
				FileClose(1)
				sTeam = Split(TeamTag.Value, "\", 4)
				If sTeam(0) = "#!!Master" Then
					AddBot_Click(AddBot, New System.EventArgs())
					
					'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					If Dir(File.Path & "\" & sTeam(1) & ".RWR") = "" Then
						MsgBox("The master '" & VB.Left(File.FileName, Len(File.FileName) - 4) & "' is missing its servant '" & sTeam(1) & "'." & vbCr & "In order to run a team tournament this must be corrected.", MsgBoxStyle.Exclamation, "Can't run Team Tournament")
						RemoveAll_Click(RemoveAll, New System.EventArgs())
						Exit Sub
					End If
					
					AddTeamMember((sTeam(1)))
					If Trim(sTeam(2)) = "" Then
						AddTeamMember((sTeam(1)))
					Else
						'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
						If Dir(File.Path & "\" & sTeam(2) & ".RWR") = "" Then
							MsgBox("The master '" & VB.Left(File.FileName, Len(File.FileName) - 4) & "' is missing its servant '" & sTeam(2) & "'." & vbCr & "In order to run a team tournament this must be corrected.", MsgBoxStyle.Exclamation, "Can't run Team Tournament")
							RemoveAll_Click(RemoveAll, New System.EventArgs())
							Exit Sub
						End If
						AddTeamMember((sTeam(2)))
					End If
				End If
			Next counter
		Else
			'''''''''''''''''''''''''''''''''''''''''''''''''''''
			For counter = 0 To File.Items.Count - 1
				File.SetSelected(counter, True)
				AddBot_Click(AddBot, New System.EventArgs())
			Next counter
		End If
		
		Exit Sub
		
errhandler: 
		MsgBox("Error with The master '" & VB.Left(File.FileName, Len(File.FileName) - 4) & "'" & vbCr & "This is most commonly caused that it's tags are not correctly written." & vbCr & "Please check the robots Team Tag and try again." & vbCr & vbCr & "The Team tag should be placed as the first line in the Master Robot and look like this:" & vbCr & vbTab & "#!!Master\Name of first Servant\Name of second Servant\" & vbCr & vbCr & "Correct: " & vbTab & vbTab & "#!!Master\MyMember1\MyMember2\" & vbCr & vbCr & "Incorrect: " & vbTab & "#!!Master\MyMember1.RWR\MyMember2.RWR\" & vbCr & "Incorrect: " & vbTab & "#!Master\MyMember1\MyMember2\" & vbCr & "Incorrect: " & vbTab & "#!!Master\MyMember1\MyMember2", MsgBoxStyle.Exclamation, "Can't run Team Tournament")
		RemoveAll_Click(RemoveAll, New System.EventArgs())
		FileClose(1)
		
	End Sub
	
	'UPGRADE_WARNING: Event AllowDrones.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub AllowDrones_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AllowDrones.CheckStateChanged
		OptionCustom.Checked = True
	End Sub
	
	'UPGRADE_WARNING: Event AllowLasers.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub AllowLasers_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AllowLasers.CheckStateChanged
		OptionCustom.Checked = True
	End Sub
	
	'Private Sub AllowNearest_Click()   'Creates interface bug
	'OptionCustom.Value = True
	'End Sub
	
	'UPGRADE_WARNING: Event AskBeforeOverwriting.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub AskBeforeOverwriting_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AskBeforeOverwriting.CheckStateChanged
		Dim valu As Short
		valu = -CShort(AskBeforeOverwriting.CheckState = 1)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, valu, 3500)
	End Sub
	
	Private Sub ChangeLocation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ChangeLocation.Click
		On Error GoTo didcancel
		CommonDialogSelectLocationSave.InitialDirectory = My.Application.Info.DirectoryPath 'Nytt
		CommonDialogSelectLocationSave.ShowDialog()
		
		SavedInFolder.Text = CommonDialogSelectLocationSave.FileName
didcancel: 
	End Sub
	
	'UPGRADE_WARNING: Event CheckEnergy.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub CheckEnergy_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CheckEnergy.CheckStateChanged
		OptionCustom.Checked = True
	End Sub
	
	'UPGRADE_WARNING: Event CheckMoveAndShoot.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub CheckMoveAndShoot_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CheckMoveAndShoot.CheckStateChanged
		OptionCustom.Checked = True
	End Sub
	
	'UPGRADE_WARNING: Event CheckNoHPLimit.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub CheckNoHPLimit_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CheckNoHPLimit.CheckStateChanged
		OptionCustom.Checked = True
		
		TextHP.Enabled = Not TextHP.Enabled
		SlaveTextHP.Enabled = TextHP.Enabled
	End Sub
	
	'UPGRADE_WARNING: Event CheckScoring.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub CheckScoring_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CheckScoring.CheckStateChanged
		OptionCustom.Checked = True
	End Sub
	
	'Private Sub CheckWinnerCircle_Click()
	''OptionCustom.Value = True
	'End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		File.Path = My.Application.Info.DirectoryPath
		Directory.Path = My.Application.Info.DirectoryPath
		Drive.Drive = My.Application.Info.DirectoryPath
	End Sub
	
	Private Sub Directory_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Directory.Change
		File.Path = Directory.Path
		'If RobotList.ListCount > 0 Then RemoveAll_Click
	End Sub
	
	Private Sub Drive_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drive.SelectedIndexChanged
		Directory.Path = Drive.Drive
		File.Path = Drive.Drive
	End Sub
	
	Private Sub TournamentD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return And NextButton.Visible Then NextButton_Click(NextButton, New System.EventArgs())
		If KeyCode = System.Windows.Forms.Keys.Back And PrevButton.Visible Then PrevButton_Click(PrevButton, New System.EventArgs())
		
	End Sub
	
	'Private Sub DuelsNumber_Change()
	'
	'If Val(DuelsNumber.Text) < 1 Or Val(DuelsNumber.Text) > 255 Then
	'MsgBox "Robot must meet each other 1 to 255 times."
	'DuelsN = 10
	'DuelsNumber.Text = 10
	'
	'Else
	'DuelsN = Val(DuelsNumber.Text)
	'End If
	'
	'End Sub
	
	Private Sub GRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GRN.Leave
		
		If Val(GRN.Text) < 0 Or Val(GRN.Text) > 2147483647 Then
			MsgBox("Robot must meet each other 0 to 2147483647 times.")
			GRNumber = 6
			GRN.Text = CStr(6)
			
		Else
			GRNumber = Val(GRN.Text)
		End If
		
	End Sub
	
	Private Sub DuelsNumber_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DuelsNumber.Leave
		
		If Val(DuelsNumber.Text) < 0 Or Val(DuelsNumber.Text) > 2147483647 Then
			MsgBox("Robot must meet each other 0 to 2147483647 times.")
			DuelsN = 10
			DuelsNumber.Text = CStr(10)
			
		Else
			DuelsN = Val(DuelsNumber.Text)
		End If
		
	End Sub
	
	Private Sub File_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles File.DoubleClick
		If Not RunningTeams Then AddBot_Click(AddBot, New System.EventArgs())
	End Sub
	
	Private Sub TournamentD_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Me.Show
		'
		'MsgBox "Note about the tournament engine:" _
		''        & vbCr & vbCr & vbTab & "You can only choose robots from ONE folder." _
		''        & vbCr & vbCr & vbTab & "You can't run with fewer than 6 robots."
		
		DuelsN = 10 '10
		GRNumber = 6 '6
		
		SavedInFolder.Text = My.Application.Info.DirectoryPath & "\Tournament Results.txt"
		'ChangeLocation.Left = 135 + SavedInFolder.Width
		
		Dim valu As Short
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, valu, 3500)
		AskBeforeOverwriting.CheckState = valu
	End Sub
	
	Private Sub NextButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NextButton.Click
		DuelsNumber.Enabled = False 'Disk
		GRN.Enabled = False 'Disk
		
		ResultsSavedIn.Visible = True
		ChangeLocation.Visible = True
		SavedInFolder.Visible = True
		AskBeforeOverwriting.Visible = True
		AllowNearest.Visible = False
		ChooseRobots.Visible = True
		Drive.Visible = True
		Directory.Visible = True
		AddDir.Visible = True
		File.Visible = True
		AddBot.Visible = True
		RobotList.Visible = True
		RemoveRobot.Visible = True
		RemoveAll.Visible = True
		'PrintLog.Visible = True
		Run.Visible = True
		PrevButton.Enabled = True
		Command1.Visible = True
		
		Rectangle.Visible = False
		TypeLabel.Visible = False
		OptionMortal.Visible = False
		OptionTitan.Visible = False
		OptionLittleLeague.Visible = False
		OptionTeam.Visible = False
		OptionAustralian.Visible = False
		OptionCustom.Visible = False
		CustomOptions.Visible = False
		'CheckWinnerCircle.Visible = False
		AllowLasers.Visible = False
		AllowDrones.Visible = False
		'CheckScoring.Visible = False
		'CheckMoveAndShoot.Visible = False
		'CheckEnergy.Visible = False
		'LabelHP.Visible = False
		'TextHP.Visible = False
		'CheckNoHPLimit.Visible = False
		'LabelChrononLimit.Visible = False
		'TextChrononLimit.Visible = False
		NextButton.Enabled = False
		
	End Sub
	
	'UPGRADE_WARNING: Event OptionAustralian.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub OptionAustralian_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptionAustralian.CheckedChanged
		If eventSender.Checked Then
			CheckNoHPLimit.CheckState = System.Windows.Forms.CheckState.Checked
			TextHP.Enabled = False
			OptionAustralian.Checked = True
			CheckWinnerCircle.CheckState = System.Windows.Forms.CheckState.Checked
			
			
			CheckScoring.Visible = True
			CheckWinnerCircle.Visible = True
			Label1.Visible = True
			GRN.Visible = True
			GRTimes.Visible = True
			HPMaster.Visible = False
			SlaveTextHP.Visible = False
			
			LabelHP.Left = 352 '352
			LabelHP.Width = 81 'standard 81
			LabelHP.Text = "Allowed Hardware Points"
			
			AddBot.Enabled = True
			RemoveRobot.Enabled = True
			RunningTeams = False
		End If
	End Sub
	
	'UPGRADE_WARNING: Event OptionLittleLeague.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub OptionLittleLeague_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptionLittleLeague.CheckedChanged
		If eventSender.Checked Then
			TextHP.Text = CStr(2)
			TextHP.Enabled = True
			CheckNoHPLimit.CheckState = System.Windows.Forms.CheckState.Unchecked
			CheckWinnerCircle.CheckState = System.Windows.Forms.CheckState.Checked
			
			OptionLittleLeague.Checked = True
			
			CheckScoring.Visible = True
			CheckWinnerCircle.Visible = True
			Label1.Visible = True
			GRN.Visible = True
			GRTimes.Visible = True
			HPMaster.Visible = False
			SlaveTextHP.Visible = False
			AllowNearest.CheckState = System.Windows.Forms.CheckState.Unchecked
			
			LabelHP.Left = 352 '352
			LabelHP.Width = 81 'standard 81
			LabelHP.Text = "Allowed Hardware Points"
			
			AddBot.Enabled = True
			RemoveRobot.Enabled = True
			RunningTeams = False
		End If
	End Sub
	
	'UPGRADE_WARNING: Event OptionMortal.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub OptionMortal_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptionMortal.CheckedChanged
		If eventSender.Checked Then
			TextHP.Enabled = True
			TextHP.Text = CStr(9)
			CheckNoHPLimit.CheckState = System.Windows.Forms.CheckState.Unchecked
			CheckWinnerCircle.CheckState = System.Windows.Forms.CheckState.Checked
			OptionMortal.Checked = True
			
			CheckScoring.Visible = True
			CheckWinnerCircle.Visible = True
			Label1.Visible = True
			GRN.Visible = True
			GRTimes.Visible = True
			HPMaster.Visible = False
			SlaveTextHP.Visible = False
			AllowNearest.CheckState = System.Windows.Forms.CheckState.Checked
			
			LabelHP.Left = 352 '352
			LabelHP.Width = 81 'standard 81
			LabelHP.Text = "Allowed Hardware Points"
			
			AddBot.Enabled = True
			RemoveRobot.Enabled = True
			RunningTeams = False
		End If
	End Sub
	
	'UPGRADE_WARNING: Event OptionTeam.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub OptionTeam_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptionTeam.CheckedChanged
		If eventSender.Checked Then
			CheckScoring.Visible = False
			CheckWinnerCircle.Visible = False
			Label1.Visible = False
			GRN.Visible = False
			GRTimes.Visible = False
			HPMaster.Visible = True
			SlaveTextHP.Visible = True
			TextHP.Enabled = True
			TextHP.Text = CStr(12)
			SlaveTextHP.Enabled = True
			SlaveTextHP.Text = CStr(9)
			CheckNoHPLimit.CheckState = System.Windows.Forms.CheckState.Unchecked
			OptionTeam.Checked = True
			AllowNearest.CheckState = System.Windows.Forms.CheckState.Checked
			
			LabelHP.Left = 344 '352
			LabelHP.Width = 89 'standard 81
			LabelHP.Text = "Allowed Hardware Points for Masters"
			RemoveAll_Click(RemoveAll, New System.EventArgs())
			
			AddBot.Enabled = False
			RemoveRobot.Enabled = False
			RunningTeams = True
		End If
	End Sub
	
	'UPGRADE_WARNING: Event OptionTitan.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub OptionTitan_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptionTitan.CheckedChanged
		If eventSender.Checked Then
			TextHP.Text = CStr(23)
			TextHP.Enabled = True
			CheckNoHPLimit.CheckState = System.Windows.Forms.CheckState.Unchecked
			OptionTitan.Checked = True
			
			CheckScoring.Visible = True
			CheckWinnerCircle.Visible = True
			Label1.Visible = True
			GRN.Visible = True
			GRTimes.Visible = True
			HPMaster.Visible = False
			SlaveTextHP.Visible = False
			AllowNearest.CheckState = System.Windows.Forms.CheckState.Unchecked
			
			LabelHP.Left = 352 '352
			LabelHP.Width = 81 'standard 81
			LabelHP.Text = "Allowed Hardware Points"
			
			AddBot.Enabled = True
			RemoveRobot.Enabled = True
			RunningTeams = False
		End If
	End Sub
	
	Private Sub PrevButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PrevButton.Click
		DuelsNumber.Enabled = True 'Disk
		GRN.Enabled = True 'Disk
		
		SavedInFolder.Visible = False
		ResultsSavedIn.Visible = False
		ChangeLocation.Visible = False
		AskBeforeOverwriting.Visible = False
		AllowNearest.Visible = True
		ChooseRobots.Visible = False
		Drive.Visible = False
		Directory.Visible = False
		AddDir.Visible = False
		File.Visible = False
		AddBot.Visible = False
		RobotList.Visible = False
		RemoveRobot.Visible = False
		RemoveAll.Visible = False
		'PrintLog.Visible = False
		Run.Visible = False
		PrevButton.Enabled = False
		Command1.Visible = False
		
		Rectangle.Visible = True
		TypeLabel.Visible = True
		OptionMortal.Visible = True
		OptionTitan.Visible = True
		OptionLittleLeague.Visible = True
		OptionTeam.Visible = True
		OptionAustralian.Visible = True
		OptionCustom.Visible = True
		CustomOptions.Visible = True
		'CheckWinnerCircle.Visible = True
		AllowLasers.Visible = True
		AllowDrones.Visible = True
		'CheckScoring.Visible = True
		'CheckMoveAndShoot.Visible = True
		'CheckEnergy.Visible = True
		LabelHP.Visible = True
		TextHP.Visible = True
		'CheckNoHPLimit.Visible = True
		'LabelChrononLimit.Visible = True
		'TextChrononLimit.Visible = True
		NextButton.Enabled = True
	End Sub
	
	Private Sub RemoveAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RemoveAll.Click
		Dim counter As Short
		
		For counter = 0 To RobotList.Items.Count - 1
			RobotList.Items.RemoveAt((0))
			TheDirList.Items.RemoveAt((0))
		Next counter
		
		'Directory.Enabled = true
		'Drive.Enabled = true
	End Sub
	
	Private Sub RemoveRobot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RemoveRobot.Click
		Dim templistindex As Integer
		If RobotList.SelectedIndex <> -1 Then
			templistindex = RobotList.SelectedIndex
			RobotList.Items.RemoveAt(templistindex)
			TheDirList.Items.RemoveAt(templistindex)
			
			If RobotList.Items.Count <> 0 Then RobotList.SetSelected(templistindex, True)
		End If
		
	End Sub
	
	Private Sub RobotList_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RobotList.DoubleClick
		If Not RunningTeams Then RemoveRobot_Click(RemoveRobot, New System.EventArgs())
	End Sub
	
	Private Sub Run_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Run.Click
		If CreatingLog.Visible Then
			MsgBox("You can not run a tournament while a log is being printed. Please cancel the printing of the log before running a new tournament.",  , "Tournament Log")
			Exit Sub
		End If
		
		If SlaveTextHP.Visible Then
			If RobotList.Items.Count < 6 Then
				MsgBox("You need at least to choose at least 2 teams to run a tournament.",  , "Can't run tournanent")
				Exit Sub
			End If
			
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If Dir(SavedInFolder.Text) <> "" And AskBeforeOverwriting.CheckState = 1 Then
				If MsgBox("A file with the name " & SavedInFolder.Text & " already exits." & vbCr & "Do you want to replace it?", MsgBoxStyle.YesNo, "Save Tournament Results") = MsgBoxResult.No Then Exit Sub
			End If
			
			MainWindow.BattleHaltButton.Visible = False
			MainWindow.StopTournament.Visible = True
			
			MainWindow.InizTeamTournament()
		Else
			If GRNumber = 0 And DuelsN = 0 Then
				MsgBox("You need at least 1 duel round per robot or 1 groupround per robot to run a tournament.",  , "Can't run tournanent")
				Exit Sub
			ElseIf RobotList.Items.Count < 2 Then 
				MsgBox("You need at least to choose at least 2 robots to run a tournament.",  , "Can't run tournanent")
				Exit Sub
			ElseIf RobotList.Items.Count < 6 And GRNumber <> 0 Then 
				MsgBox("You need at least to choose at least 6 robots to run a tournament with grouprounds.",  , "Can't run tournanent")
				Exit Sub
			End If
			
			If CheckWinnerCircle.CheckState = 1 And RobotList.Items.Count < 7 Then
				If MsgBox("You must have at least 7 robots to run a tournament with a Winner Circle" & vbCr & "Do you want to run without Winners Circle?", MsgBoxStyle.YesNo, "Can't run with Winner Cirle") = MsgBoxResult.No Then
					Exit Sub
				Else
					CheckWinnerCircle.CheckState = System.Windows.Forms.CheckState.Unchecked
				End If
			End If
			
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If Dir(SavedInFolder.Text) <> "" And AskBeforeOverwriting.CheckState = 1 Then
				If MsgBox("A file with the name " & SavedInFolder.Text & " already exits." & vbCr & "Do you want to replace it?", MsgBoxStyle.YesNo, "Save Tournament Results") = MsgBoxResult.No Then Exit Sub
			End If
			
			MainWindow.BattleHaltButton.Visible = False
			MainWindow.StopTournament.Visible = True
			
			'MainWindow.InizTournament      'borde inte den stå efter att scoren blivit raderade?
			
			'    Dim counter As Integer
			'
			'    For counter = 0 To TournamentD.RobotList.ListCount - 1  'Sets all combatants score to 0
			'        TournamentD.RobotList.ItemData(counter) = 0
			'    Next counter
			
			MainWindow.InizTournament()
		End If
	End Sub
	
	'UPGRADE_WARNING: Event TextHP.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TextHP_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextHP.TextChanged
		OptionCustom.Checked = True
	End Sub
	
	Private Function DoesCheat(ByRef ToBeChecked As String) As Boolean
		Dim TheRobot As Robot
		
		FileOpen(254, ToBeChecked, OpenMode.Binary)
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, TheRobot)
		'
		If MainWindow.CheckInvalid(TheRobot.BlockIcon) Or MainWindow.CheckInvalid(TheRobot.CollisionIcon) Or MainWindow.CheckInvalid(TheRobot.DeathIcon) Or MainWindow.CheckInvalid(TheRobot.HitIcon) Or MainWindow.CheckInvalid(TheRobot.ShieldIcon) Or MainWindow.CheckInvalid(TheRobot.Hellbores) Or MainWindow.CheckInvalid(TheRobot.Lasers) Or MainWindow.CheckInvalid(TheRobot.Mines) Or MainWindow.CheckInvalid(TheRobot.Missiles) Or MainWindow.CheckInvalid(TheRobot.Probes) Or MainWindow.CheckInvalid(TheRobot.Stunners) Or MainWindow.CheckInvalid(TheRobot.TacNukes) Then
			CheckCheat = "The robot seems to be broken, and cannot be loaded."
			DoesCheat = True
			FileClose(254)
			Exit Function
		End If
		
		FileClose(254)
		
		CheckCheat = ""
		
		Dim HWCounter As Short
		If CheckNoHPLimit.CheckState = 0 Then
			
			'Energy
			
			Select Case TheRobot.Energy
				Case 150
					HWCounter = 3
				Case 100
					HWCounter = 2
				Case 60
					HWCounter = 1
				Case 40
				Case Else
					CheckCheat = "The robot has disallowed hardware values."
			End Select
			''Damage
			
			Select Case TheRobot.Damage
				Case 150
					HWCounter = HWCounter + 3
				Case 100
					HWCounter = HWCounter + 2
				Case 60
					HWCounter = HWCounter + 1
				Case 30
				Case Else
					CheckCheat = "The robot has disallowed hardware values."
			End Select
			''Shield
			
			Select Case TheRobot.Shield
				Case 100
					HWCounter = HWCounter + 3
				Case 50
					HWCounter = HWCounter + 2
				Case 25
					HWCounter = HWCounter + 1
				Case 0
				Case Else
					CheckCheat = "The robot has disallowed hardware values."
			End Select
			''Processor Speed
			
			Select Case TheRobot.Prosessor
				Case 50
					HWCounter = HWCounter + 4
				Case 30
					HWCounter = HWCounter + 3
				Case 15
					HWCounter = HWCounter + 2
				Case 10
					HWCounter = HWCounter + 1
				Case 5
				Case Else
					CheckCheat = "The robot has disallowed hardware values."
			End Select
			''Bullets
			
			'Select Case TheRobot.Bullets
			' Case 2
			'    HWCounter = HWCounter + 2
			' Case 1
			'    HWCounter = HWCounter + 1
			' Case 0
			' Case Else
			'    CheckCheat = "The robot has disallowed hardware values."
			'End Select
			
			HWCounter = HWCounter + System.Math.Sign(TheRobot.Drones) + TheRobot.Hellbores + TheRobot.Lasers + TheRobot.Mines + TheRobot.Missiles + TheRobot.Probes + TheRobot.Stunners + TheRobot.TacNukes + TheRobot.Bullets
			
			If CheckCheat <> "The robot has disallowed hardware values." Then
				If CDbl(TextHP.Text) < HWCounter Then CheckCheat = "The robot has has more hardwarepoints than the max hardwarepoints."
				If TheRobot.Drones <> 0 And AllowDrones.CheckState = 0 Then CheckCheat = "The robot uses Drones. You've set them to be dissallowed."
				If TheRobot.Lasers <> 0 And AllowLasers.CheckState = 0 Then CheckCheat = "The robot uses Lasers. You've set them to be dissallowed."
			End If
			
		End If 'hwlimit
		
		DoesCheat = CheckCheat <> ""
	End Function
End Class