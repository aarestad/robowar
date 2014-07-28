Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class TestTourney
	Inherits System.Windows.Forms.Form
	Public IamChoosedForTesting As String
	Public TeamPath As String
	Public DuelsN As Short
	Public GroupN As Short
	
	'New RWR file format constants
	'Const sndrec = 32
	Const iconrec As Short = 72
	'Const MCrec = 112
	'Const Crec = 116
	Const zeroexists As Short = 130 'same as iconspresent
	'Const soundspresent = 120
	
	Private Sub Add_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Add_Renamed.Click
		
		If File1.FileName = "" Then Exit Sub
		
		RobotList.Items.Add(VB.Left(File1.FileName, Len(File1.FileName) - 4))
		TheDirList.Items.Add(Dir1.Path)
	End Sub
	
	Private Sub AddAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AddAll.Click
		Dim counter As Short
		''''''''''''''''''''''''''''''''''''''''
		Dim Cstart As Integer
		Const Crec As Short = 116
		Dim TeamTag As New VB6.FixedLengthString(765)
		Dim sTeam() As String
		If TeamTest.Checked Then
			On Error GoTo errhandler
			
			
			
			
			For counter = 0 To File1.Items.Count - 1
				File1.SetSelected(counter, True)
				If File1.Path & "\" & File1.FileName <> IamChoosedForTesting Then
					FileOpen(1, File1.Path & "\" & File1.FileName, OpenMode.Binary)
					'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					FileGet(1, Cstart, Crec)
					'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					FileGet(1, TeamTag.Value, Cstart)
					FileClose(1)
					sTeam = Split(TeamTag.Value, "\", 4)
					If sTeam(0) = "#!!Master" Then
						Add_Renamed_Click(Add_Renamed, New System.EventArgs())
						
						'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
						If Dir(File1.Path & "\" & sTeam(1) & ".RWR") = "" Then
							MsgBox("The master '" & VB.Left(File1.FileName, Len(File1.FileName) - 4) & "' is missing its servant '" & sTeam(1) & "'." & vbCr & "In order to run a team tournament this must be corrected.", MsgBoxStyle.Exclamation, "Can't run Team Tournament")
							RemoveAll_Click(RemoveAll, New System.EventArgs())
							Exit Sub
						End If
						
						RobotList.Items.Add(sTeam(1))
						TheDirList.Items.Add(Dir1.Path)
						If Trim(sTeam(2)) = "" Then
							RobotList.Items.Add(sTeam(1))
							TheDirList.Items.Add(Dir1.Path)
						Else
							'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
							If Dir(File1.Path & "\" & sTeam(2) & ".RWR") = "" Then
								MsgBox("The master '" & VB.Left(File1.FileName, Len(File1.FileName) - 4) & "' is missing its servant '" & sTeam(2) & "'." & vbCr & "In order to run a team tournament this must be corrected.", MsgBoxStyle.Exclamation, "Can't run Team Tournament")
								RemoveAll_Click(RemoveAll, New System.EventArgs())
								Exit Sub
							End If
							RobotList.Items.Add(sTeam(2))
							TheDirList.Items.Add(Dir1.Path)
						End If
					End If
				End If
			Next counter
		Else
			'''''''''''''''''''''''''''''''''''''''
			For counter = 0 To File1.Items.Count - 1
				
				File1.SetSelected(counter, True)
				If File1.Path & "\" & File1.FileName <> IamChoosedForTesting Then Add_Renamed_Click(Add_Renamed, New System.EventArgs())
				
			Next counter
			
		End If
		
		
		Exit Sub
		
errhandler: 
		MsgBox("Error with The master '" & VB.Left(File1.FileName, Len(File1.FileName) - 4) & "'" & vbCr & "This is most commonly caused that it's tags are not correctly written." & vbCr & "Please check the robots Team Tag and try again." & vbCr & vbCr & "The Team tag should be placed as the first line in the Master Robot and look like this:" & vbCr & vbTab & "#!!Master\Name of first Servant\Name of second Servant\" & vbCr & vbCr & "Correct: " & vbTab & vbTab & "#!!Master\MyMember1\MyMember2\" & vbCr & vbCr & "Incorrect: " & vbTab & "#!!Master\MyMember1.RWR\MyMember2.RWR\" & vbCr & "Incorrect: " & vbTab & "#!Master\MyMember1\MyMember2\" & vbCr & "Incorrect: " & vbTab & "#!!Master\MyMember1\MyMember2", MsgBoxStyle.Exclamation, "Can't run Team Tournament")
		RemoveAll_Click(RemoveAll, New System.EventArgs())
		FileClose(1)
		
	End Sub
	
	'UPGRADE_WARNING: Event AskBeforeOverwriting.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub AskBeforeOverwriting_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AskBeforeOverwriting.CheckStateChanged
		Dim valu As Short
		valu = -CShort(AskBeforeOverwriting.CheckState = 1)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, valu, 3250)
	End Sub
	
	Private Sub ChangeLocation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ChangeLocation.Click
		On Error GoTo didcancel
		CommonDialogSelectLocationSave.InitialDirectory = My.Application.Info.DirectoryPath 'Nytt
		CommonDialogSelectLocationSave.ShowDialog()
		
		'Dim noext As String
		'noext = CommonDialogSelectLocation.FileName
		'SavedInFolder = Left(noext, Len(noext) - 4)
		SavedInFolder.Text = CommonDialogSelectLocationSave.FileName
didcancel: 
	End Sub
	
	Private Sub Dir1_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Dir1.Change
		File1.Path = Dir1.Path
		'If RobotList.ListCount > 0 Then RemoveAll_Click
	End Sub
	
	Private Sub Drive1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drive1.SelectedIndexChanged
		Dir1.Path = Drive1.Drive
		'File1.path = Drive1.Drive
	End Sub
	
	Private Sub DuelsNR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DuelsNR.Leave
		'Public DuelsN As Integer
		'Public GroupN As Integer
		If Val(DuelsNR.Text) < 0 Or Val(DuelsNR.Text) > 32767 Then
			MsgBox("Please insert a number between 0 and 32767")
			DuelsNR.Text = CStr(20)
			DuelsNR.Focus()
			DuelsNR.SelectionLength = Len(DuelsNR.Text)
		Else
			DuelsN = Val(DuelsNR.Text)
		End If
		
	End Sub
	
	Private Sub File1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles File1.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'varje fält är 13 pixlar
		Dim WhichRobot As Integer
		If Button <> 1 Then
			WhichRobot = (Y / VB6.TwipsPerPixelY) \ 13 + File1.TopIndex
			If WhichRobot < File1.Items.Count Then
				File1.SetSelected(WhichRobot, True)
				Testing_Click(Testing, New System.EventArgs())
			End If
		End If
	End Sub
	
	Private Sub TestTourney_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then Run_Click(Run, New System.EventArgs())
	End Sub
	
	Private Sub TestTourney_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		DuelsN = Val(DuelsNR.Text)
		GroupN = Val(GroupNR.Text)
		'MandS.Value = -CInt(Not MainWindow.MoveAndShoot.Checked)
		Dim valu As Short
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, valu, 3250)
		AskBeforeOverwriting.CheckState = valu
	End Sub
	
	Private Sub GroupNR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GroupNR.Leave
		'Public DuelsN As Integer
		'Public GroupN As Integer
		If Val(GroupNR.Text) < 0 Or Val(GroupNR.Text) > 32767 Then
			MsgBox("Please insert a number between 0 and 32767")
			GroupNR.Text = CStr(20)
			GroupNR.Focus()
			GroupNR.SelectionLength = Len(GroupNR.Text)
		Else
			GroupN = Val(GroupNR.Text)
		End If
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
	
	Private Sub File1_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles File1.DoubleClick
		If NormalTest.Checked Then
			RobotList.Items.Add(VB.Left(File1.FileName, Len(File1.FileName) - 4))
			TheDirList.Items.Add(Dir1.Path)
		End If
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
		If NormalTest.Checked Then RemoveRobot_Click(RemoveRobot, New System.EventArgs())
	End Sub
	
	Private Sub Run_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Run.Click
		If IamChoosedForTesting = "" Or RobotList.Items.Count = 0 Then Exit Sub
		
		If CreatingLog.Visible Then
			MsgBox("You can not run a tournament while a log is being printed. Please cancel the printing of the log before running a new tournament.",  , "Tournament Log")
			Exit Sub
		End If
		
		If NormalTest.Checked Then
			If RobotList.Items.Count < 5 And GroupN <> 0 Then
				MsgBox("You need to choose at least 5 opponents if you want to test you robot in grouprounds.",  , "Can't run testing")
				Exit Sub
			End If
			
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If Dir(SavedInFolder.Text) <> "" And AskBeforeOverwriting.CheckState = 1 Then
				If MsgBox("A file with the name " & SavedInFolder.Text & " already exits." & vbCr & "Do you want to replace it?", MsgBoxStyle.YesNo, "Save Tournament Results") = MsgBoxResult.No Then Exit Sub
			End If
			
			MainWindow.BattleHaltButton.Visible = False
			MainWindow.StopTournament.Visible = True
			
			MainWindow.InizTestTournament()
		Else
			MainWindow.BattleHaltButton.Visible = False
			MainWindow.StopTournament.Visible = True
			MainWindow.InizTeamTestTournament()
		End If
		
	End Sub
	
	Private Sub RWDir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RWDir.Click
		File1.Path = My.Application.Info.DirectoryPath
		Dir1.Path = My.Application.Info.DirectoryPath
		Drive1.Drive = My.Application.Info.DirectoryPath
	End Sub
	
	'UPGRADE_WARNING: Event TeamTest.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TeamTest_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TeamTest.CheckedChanged
		If eventSender.Checked Then
			Add_Renamed.Enabled = False
			RemoveRobot.Enabled = False
			Shape2.Visible = False
			Label5.Visible = False
			Label3.Visible = False
			GroupNR.Visible = False
			
			RemoveAll_Click(RemoveAll, New System.EventArgs())
		End If
	End Sub
	
	'UPGRADE_WARNING: Event NormalTest.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub NormalTest_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NormalTest.CheckedChanged
		If eventSender.Checked Then
			Add_Renamed.Enabled = True
			RemoveRobot.Enabled = True
			Shape2.Visible = True
			Label5.Visible = True
			Label3.Visible = True
			GroupNR.Visible = True
		End If
	End Sub
	
	Private Sub Testing_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Testing.Click
		Dim Cstart As Integer
		Const Crec As Short = 116
		Dim TeamTag As New VB6.FixedLengthString(765)
		Dim sTeam() As String
		If TeamTest.Checked Then
			On Error GoTo errhandler
			
			
			
			
			FileOpen(1, File1.Path & "\" & File1.FileName, OpenMode.Binary)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, Cstart, Crec)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, TeamTag.Value, Cstart)
			FileClose(1)
			sTeam = Split(TeamTag.Value, "\", 4)
			If sTeam(0) <> "#!!Master" Then
				MsgBox("To choose a Team for testing, please click on the master of that Team." & vbCr & vbCr & "To define a master:" & vbCr & vbCr & "The Team tag should be placed as the first line in the Master Robot and look like this:" & vbCr & vbTab & "#!!Master\Name of first Servant\Name of second Servant\" & vbCr & vbCr & "Correct: " & vbTab & vbTab & "#!!Master\MyMember1\MyMember2\" & vbCr & vbCr & "Incorrect: " & vbTab & "#!!Master\MyMember1.RWR\MyMember2.RWR\" & vbCr & "Incorrect: " & vbTab & "#!Master\MyMember1\MyMember2\" & vbCr & "Incorrect: " & vbTab & "#!!Master\MyMember1\MyMember2", MsgBoxStyle.Information, "Test Team")
				Exit Sub
			End If
		End If
		TeamPath = File1.Path 'Should maybe be under the above if?
		
		Dim ProperName As String
		
		ProperName = File1.FileName
		If ProperName = "" Then Exit Sub
		
		IamChoosedForTesting = File1.Path & "\" & ProperName
		
		ProperName = VB.Left(ProperName, Len(ProperName) - 4)
		
		SavedInFolder.Text = My.Application.Info.DirectoryPath & "\Test Results -" & ProperName & ".txt"
		CommonDialogSelectLocationSave.FileName = My.Application.Info.DirectoryPath & "\Test Results -" & ProperName & ".txt"
		
		
		WhoIsTested.Text = "The Robot " & ProperName & " is choosed for testing"
		
		Dim RecIconStart(1) As Integer
		Dim IconZeroExists As Byte
		Dim IconZero As String
		
		On Error GoTo Errorhandler
		
		FileOpen(254, IamChoosedForTesting, OpenMode.Binary)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RecIconStart, iconrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, IconZeroExists, zeroexists)
		
		If IconZeroExists <> 0 Then
			IconZero = Space(RecIconStart(1) - RecIconStart(0))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(254, IconZero, RecIconStart(0))
			RobotPict.Image = LoadRobotIcon(IconZero)
		Else
			RobotPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\1#0.ico")
		End If
		FileClose(254)
		
		RobotPict.Visible = True
		
		SavedInFolder.Visible = True
		ResultsSavedIn.Visible = True
		ChangeLocation.Visible = True
		AskBeforeOverwriting.Visible = True
		Exit Sub
		
Errorhandler: 
		MsgBox("The robot '" & ProperName & "' seems to be broken, and cannot be tested.", MsgBoxStyle.Critical, "Test Robot")
		FileClose(254)
		
		IamChoosedForTesting = ""
		WhoIsTested.Text = "No Robot is chosen for testing"
		RobotPict.Visible = False
		SavedInFolder.Visible = False
		ResultsSavedIn.Visible = False
		ChangeLocation.Visible = False
		AskBeforeOverwriting.Visible = False
		
		
		Exit Sub
		
errhandler: 
		MsgBox("Error with The master '" & VB.Left(File1.FileName, Len(File1.FileName) - 4) & "'" & vbCr & "This is most commonly caused that it's tags are not correctly written." & vbCr & "Please check the robots Team Tag and try again." & vbCr & vbCr & "The Team tag should be placed as the first line in the Master Robot and look like this:" & vbCr & vbTab & "#!!Master\Name of first Servant\Name of second Servant\" & vbCr & vbCr & "Correct: " & vbTab & vbTab & "#!!Master\MyMember1\MyMember2\" & vbCr & vbCr & "Incorrect: " & vbTab & "#!!Master\MyMember1.RWR\MyMember2.RWR\" & vbCr & "Incorrect: " & vbTab & "#!Master\MyMember1\MyMember2\" & vbCr & "Incorrect: " & vbTab & "#!!Master\MyMember1\MyMember2", MsgBoxStyle.Exclamation, "Can't run Team Tournament")
		FileClose(1)
		
	End Sub
End Class