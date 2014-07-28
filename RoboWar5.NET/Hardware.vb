Option Strict Off
Option Explicit On
Friend Class HardwareWindow
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
	
	Dim HasCanceled As Boolean
	
	' Bullets      '1 = Normal 2 = Explosive   0 = Rubber
	' Turret     '1 = Line   2 = Dot         0 = None
	' Drones    '0 = Not equiped    1 = Equipped    2 = Equipped but never used in the code (common for pre doppler titans)
	
	Dim TheRobot As Robot
	Dim LoadRobotPath As String
	Const MCrec As Short = 112
	Dim CodeDrones As Boolean
	Const insDRONE As Short = 20348
	Const insEND As Short = 20110
	
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
	
	'UPGRADE_WARNING: Event DDrone.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub DDrone_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DDrone.CheckStateChanged
		Dim choseddrones As Byte
		choseddrones = DDrone.CheckState
		
		If choseddrones = 1 And Not CodeDrones Then choseddrones = 2
		
		TheRobot.Drones = choseddrones
		Räkna()
	End Sub
	
	'UPGRADE_WARNING: Event DHellbore.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub DHellbore_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DHellbore.CheckStateChanged
		TheRobot.Hellbores = DHellbore.CheckState
		Räkna()
	End Sub
	
	'UPGRADE_WARNING: Event DLaser.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub DLaser_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DLaser.CheckStateChanged
		TheRobot.Lasers = DLaser.CheckState
		Räkna()
	End Sub
	
	'UPGRADE_WARNING: Event DMine.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub DMine_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DMine.CheckStateChanged
		TheRobot.Mines = DMine.CheckState
		Räkna()
	End Sub
	
	'UPGRADE_WARNING: Event DMissile.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub DMissile_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DMissile.CheckStateChanged
		TheRobot.Missiles = DMissile.CheckState
		Räkna()
	End Sub
	
	'UPGRADE_WARNING: Event DProbes.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub DProbes_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DProbes.CheckStateChanged
		TheRobot.Probes = DProbes.CheckState
		Räkna()
	End Sub
	
	'UPGRADE_WARNING: Event DStunner.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub DStunner_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DStunner.CheckStateChanged
		TheRobot.Stunners = DStunner.CheckState
		Räkna()
	End Sub
	
	'UPGRADE_WARNING: Event DTacNuke.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub DTacNuke_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DTacNuke.CheckStateChanged
		TheRobot.TacNukes = DTacNuke.CheckState
		Räkna()
	End Sub
	
	'UPGRADE_WARNING: Form event HardwareWindow.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub HardwareWindow_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		If TheRobot.Bullets < 0 Or TheRobot.Bullets > 2 Then
			MsgBox("Please rechoose the type of bullets your robot should use.", MsgBoxStyle.Exclamation, "Invalid settings for Bullets")
			TheRobot.Bullets = 1
		End If
		
		If TheRobot.Turret < 0 Or TheRobot.Turret > 2 Then
			MsgBox("Please rechoose the turret shape your robot should use.", MsgBoxStyle.Exclamation, "Invalid settings for Turret")
			TheRobot.Turret = 1
		End If
	End Sub
	
	Private Sub HardwareWindow_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case System.Windows.Forms.Keys.F1
				'SkrivHardware
				Me.Close()
				''MainWindow.ViewMenu.Enabled = True
			Case System.Windows.Forms.Keys.F2
				'SkrivHardware
				Me.Close()
				VB6.ShowForm(DraftingBoard, 1, MainWindow)
			Case System.Windows.Forms.Keys.F4
				'SkrivHardware
				Me.Close()
				VB6.ShowForm(ChooseIcon, 1, MainWindow)
			Case System.Windows.Forms.Keys.F5
				'SkrivHardware
				Me.Close()
				VB6.ShowForm(SoundEditor, 1, MainWindow)
		End Select
	End Sub
	
	Private Sub HardwareWindow_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Ladda Hardware
		'Load the Hardware
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
		
		CodeDrones = False
		
		FileOpen(1, LoadRobotPath, OpenMode.Binary)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, TheRobot)
		
		Dim RNN As Integer
		Dim InputInsts(4999) As Short
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, RNN, MCrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, InputInsts, RNN)
		
		For RNN = 0 To 4999
			If InputInsts(RNN) = insDRONE Then CodeDrones = True
			If InputInsts(RNN) = insEND Then Exit For
		Next RNN
		FileClose(1)
		
		KollaHW()
	End Sub
	
	Private Sub HardwareWindow_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If Not HasCanceled Then SkrivHardware()
		HasCanceled = False 'Dethär är väldigt mystiskt, det verkar komma ihåg att DoCancel = true när
		'den stängs. Varning för kloning 'Men den verkar köra form load i alla fall
	End Sub
	
	Private Sub Label10_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label10.Click
		BulletPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#1.gif")
		TheRobot.Bullets = 2
		Räkna()
	End Sub
	
	Private Sub Label13_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label13.Click
		DamagePict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#3.gif")
		TheRobot.Damage = 60
		Räkna()
	End Sub
	
	Private Sub Label14_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label14.Click
		TurretPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#1.gif")
		TheRobot.Turret = 1
		'MainWindow.Turret(MainWindow.SelectedRobot).Visible = True
	End Sub
	
	Private Sub Label15_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label15.Click
		TurretPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#2.gif")
		TheRobot.Turret = 2
	End Sub
	
	Private Sub Label16_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label16.Click
		TurretPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#3.gif")
		TheRobot.Turret = 0
		'MainWindow.Turret(MainWindow.SelectedRobot).Visible = False
	End Sub
	
	Private Sub Label17_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label17.Click
		DamagePict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#2.gif")
		TheRobot.Damage = 100
		Räkna()
	End Sub
	
	Private Sub Label19_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label19.Click
		DamagePict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#1.gif")
		TheRobot.Damage = 150
		Räkna()
	End Sub
	
	Private Sub Label2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label2.Click
		EnergyPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#1.gif")
		TheRobot.Energy = 150
		Räkna()
	End Sub
	
	Private Sub Label20_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label20.Click
		ShieldPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#4.gif")
		TheRobot.Shield = 0
		Räkna()
	End Sub
	
	Private Sub Label21_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label21.Click
		ShieldPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#3.gif")
		TheRobot.Shield = 25
		Räkna()
	End Sub
	
	Private Sub Label22_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label22.Click
		ShieldPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#2.gif")
		TheRobot.Shield = 50
		Räkna()
	End Sub
	
	Private Sub Label23_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label23.Click
		ShieldPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#1.gif")
		TheRobot.Shield = 100
		Räkna()
	End Sub
	
	Private Sub Label24_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label24.Click
		SpeedPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control5#3.gif")
		TheRobot.Speed = 15
		Räkna()
	End Sub
	
	Private Sub Label25_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label25.Click
		SpeedPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control5#2.gif")
		TheRobot.Speed = 30
		Räkna()
	End Sub
	
	Private Sub Label26_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label26.Click
		SpeedPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control5#1.gif")
		TheRobot.Speed = 50
		Räkna()
	End Sub
	
	Private Sub Label27_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label27.Click
		SpeedPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control5#5.gif")
		TheRobot.Speed = 5
		Räkna()
	End Sub
	
	Private Sub Label28_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label28.Click
		BulletPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#2.gif")
		TheRobot.Bullets = 1
		Räkna()
	End Sub
	
	Private Sub Label29_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label29.Click
		BulletPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#3.gif")
		TheRobot.Bullets = 0
		Räkna()
	End Sub
	
	Private Sub Label4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label4.Click
		EnergyPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#2.gif")
		TheRobot.Energy = 100
		Räkna()
	End Sub
	
	Private Sub Label6_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label6.Click
		EnergyPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#3.gif")
		TheRobot.Energy = 60
		Räkna()
	End Sub
	
	Private Sub Label7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label7.Click
		EnergyPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#4.gif")
		TheRobot.Energy = 40
		Räkna()
	End Sub
	
	Private Sub Label8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label8.Click
		SpeedPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control5#4.gif")
		TheRobot.Speed = 10
		Räkna()
	End Sub
	
	Private Sub Label9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label9.Click
		DamagePict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#4.gif")
		TheRobot.Damage = 30
		Räkna()
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		'SkrivHardware
		Me.Close()
	End Sub
	
	
	Private Sub KollaHW()
		
		'Energy
		
		Select Case TheRobot.Energy
			Case 150
				EnergyPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#1.gif")
			Case 100
				EnergyPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#2.gif")
			Case 60
				EnergyPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#3.gif")
			Case 40
				EnergyPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#4.gif")
		End Select
		
		'Damage
		
		Select Case TheRobot.Damage
			Case 150
				DamagePict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#1.gif")
			Case 100
				DamagePict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#2.gif")
			Case 60
				DamagePict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#3.gif")
			Case 30
				DamagePict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#4.gif")
		End Select
		
		'Shield
		
		Select Case TheRobot.Shield
			Case 100
				ShieldPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#1.gif")
			Case 50
				ShieldPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#2.gif")
			Case 25
				ShieldPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#3.gif")
			Case 0
				ShieldPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control4#4.gif")
		End Select
		
		'Processor Speed
		
		Select Case TheRobot.Speed
			Case 50
				SpeedPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control5#1.gif")
			Case 30
				SpeedPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control5#2.gif")
			Case 15
				SpeedPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control5#3.gif")
			Case 10
				SpeedPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control5#4.gif")
			Case 5
				SpeedPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control5#5.gif")
		End Select
		
		'Bullets
		
		Select Case TheRobot.Bullets
			Case 2
				BulletPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#1.gif")
			Case 1
				BulletPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#2.gif")
			Case 0
				BulletPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#3.gif")
		End Select
		
		'Turret
		
		Select Case TheRobot.Turret
			Case 2
				TurretPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#2.gif")
			Case 1
				TurretPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#1.gif")
			Case 0
				TurretPict.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\Control3#3.gif")
		End Select
		
		DMissile.CheckState = TheRobot.Missiles
		DTacNuke.CheckState = TheRobot.TacNukes
		DHellbore.CheckState = TheRobot.Hellbores
		DMine.CheckState = TheRobot.Mines
		DStunner.CheckState = TheRobot.Stunners
		DDrone.CheckState = System.Math.Sign(TheRobot.Drones)
		DLaser.CheckState = TheRobot.Lasers
		DProbes.CheckState = TheRobot.Probes
		
		Räkna()
	End Sub
	
	Private Sub Räkna()
		Dim TotalCost As Short
		
		TotalCost = 0
		
		Select Case TheRobot.Energy
			Case Is > 150
				Class_Renamed.Text = "Australian Ruler"
				DispTotalPoints.Text = "23" & vbCr & Chr(160) & Chr(160) & ">"
				Exit Sub
			Case 150
				TotalCost = 3
			Case 100
				TotalCost = 2
			Case 60
				TotalCost = 1
			Case Is <> 40
				DispTotalPoints.Text = "?"
				Exit Sub
		End Select
		
		Select Case TheRobot.Damage
			Case Is > 150
				Class_Renamed.Text = "Australian Ruler"
				DispTotalPoints.Text = "23" & vbCr & Chr(160) & Chr(160) & ">"
				Exit Sub
			Case 150
				TotalCost = TotalCost + 3
			Case 100
				TotalCost = TotalCost + 2
			Case 60
				TotalCost = TotalCost + 1
			Case Is <> 30
				DispTotalPoints.Text = "?"
				Exit Sub
		End Select
		
		Select Case TheRobot.Shield
			Case Is > 100
				Class_Renamed.Text = "Australian Ruler"
				DispTotalPoints.Text = "23" & vbCr & Chr(160) & Chr(160) & ">"
				Exit Sub
			Case 100
				TotalCost = TotalCost + 3
			Case 50
				TotalCost = TotalCost + 2
			Case 25
				TotalCost = TotalCost + 1
			Case Is <> 0
				DispTotalPoints.Text = "?"
				Exit Sub
		End Select
		
		Select Case TheRobot.Speed
			Case Is > 50
				Class_Renamed.Text = "Australian Ruler"
				DispTotalPoints.Text = "23" & vbCr & Chr(160) & Chr(160) & ">"
				Exit Sub
			Case 50
				TotalCost = TotalCost + 4
			Case 30
				TotalCost = TotalCost + 3
			Case 15
				TotalCost = TotalCost + 2
			Case 10
				TotalCost = TotalCost + 1
			Case Is <> 5
				DispTotalPoints.Text = "?"
				Exit Sub
		End Select
		
		Select Case TheRobot.Bullets
			Case 2
				TotalCost = TotalCost + 2
			Case 1
				TotalCost = TotalCost + 1
				'    Case Is <> 0
				'        MsgBox ("This robot has invalide bullets. Please rechoose the robots again.")
		End Select
		
		TotalCost = TotalCost + TheRobot.Missiles
		TotalCost = TotalCost + TheRobot.Probes
		TotalCost = TotalCost + TheRobot.TacNukes
		TotalCost = TotalCost + TheRobot.Stunners
		TotalCost = TotalCost + TheRobot.Hellbores
		TotalCost = TotalCost + TheRobot.Mines
		TotalCost = TotalCost + System.Math.Sign(TheRobot.Drones)
		TotalCost = TotalCost + TheRobot.Lasers
		
		DispTotalPoints.Text = CStr(TotalCost)
		
		Select Case TotalCost
			Case 0 To 2
				Class_Renamed.Text = "Little Leaguer"
			Case 3 To 9
				Class_Renamed.Text = "Mortal"
			Case 10 To 23
				Class_Renamed.Text = "Titan"
				'    Case Else                              Behövs inte
				'        Class.Caption = "Austalian Ruler"  Not necesery anymore
		End Select
		
	End Sub
	
	Private Sub RefreshHW(ByRef WhichRobot As Short)
		Select Case WhichRobot
			Case 1
				MainWindow.ER(1).Text = CStr(TheRobot.Energy)
				MainWindow.DR(1).Text = CStr(TheRobot.Damage)
				MainWindow.Robot1Energy = TheRobot.Energy
				MainWindow.Robot1Damage = TheRobot.Damage
				MainWindow.Robot1Shield = TheRobot.Shield
				MainWindow.Robot1ProSpeed = TheRobot.Speed
				MainWindow.Robot1Bullets = TheRobot.Bullets
				MainWindow.Robot1Probes = TheRobot.Probes
				MainWindow.Robot1Missiles = TheRobot.Missiles
				MainWindow.Robot1TacNukes = TheRobot.TacNukes
				MainWindow.Robot1Hellbores = TheRobot.Hellbores
				MainWindow.Robot1Drones = TheRobot.Drones
				MainWindow.Robot1Stunners = TheRobot.Stunners
				MainWindow.Robot1Mines = TheRobot.Mines
				MainWindow.Robot1Lasers = TheRobot.Lasers
				MainWindow.Robot1Turret = TheRobot.Turret
			Case 2
				MainWindow.ER(2).Text = CStr(TheRobot.Energy)
				MainWindow.DR(2).Text = CStr(TheRobot.Damage)
				MainWindow.Robot2Energy = TheRobot.Energy
				MainWindow.Robot2Damage = TheRobot.Damage
				MainWindow.Robot2Shield = TheRobot.Shield
				MainWindow.Robot2ProSpeed = TheRobot.Speed
				MainWindow.Robot2Bullets = TheRobot.Bullets
				MainWindow.Robot2Probes = TheRobot.Probes
				MainWindow.Robot2Missiles = TheRobot.Missiles
				MainWindow.Robot2TacNukes = TheRobot.TacNukes
				MainWindow.Robot2Hellbores = TheRobot.Hellbores
				MainWindow.Robot2Drones = TheRobot.Drones
				MainWindow.Robot2Stunners = TheRobot.Stunners
				MainWindow.Robot2Mines = TheRobot.Mines
				MainWindow.Robot2Lasers = TheRobot.Lasers
				MainWindow.Robot2Turret = TheRobot.Turret
			Case 3
				MainWindow.ER(3).Text = CStr(TheRobot.Energy)
				MainWindow.DR(3).Text = CStr(TheRobot.Damage)
				MainWindow.Robot3Energy = TheRobot.Energy
				MainWindow.Robot3Damage = TheRobot.Damage
				MainWindow.Robot3Shield = TheRobot.Shield
				MainWindow.Robot3ProSpeed = TheRobot.Speed
				MainWindow.Robot3Bullets = TheRobot.Bullets
				MainWindow.Robot3Probes = TheRobot.Probes
				MainWindow.Robot3Missiles = TheRobot.Missiles
				MainWindow.Robot3TacNukes = TheRobot.TacNukes
				MainWindow.Robot3Hellbores = TheRobot.Hellbores
				MainWindow.Robot3Drones = TheRobot.Drones
				MainWindow.Robot3Stunners = TheRobot.Stunners
				MainWindow.Robot3Mines = TheRobot.Mines
				MainWindow.Robot3Lasers = TheRobot.Lasers
				MainWindow.Robot3Turret = TheRobot.Turret
			Case 4
				MainWindow.ER(4).Text = CStr(TheRobot.Energy)
				MainWindow.DR(4).Text = CStr(TheRobot.Damage)
				MainWindow.Robot4Energy = TheRobot.Energy
				MainWindow.Robot4Damage = TheRobot.Damage
				MainWindow.Robot4Shield = TheRobot.Shield
				MainWindow.Robot4ProSpeed = TheRobot.Speed
				MainWindow.Robot4Bullets = TheRobot.Bullets
				MainWindow.Robot4Probes = TheRobot.Probes
				MainWindow.Robot4Missiles = TheRobot.Missiles
				MainWindow.Robot4TacNukes = TheRobot.TacNukes
				MainWindow.Robot4Hellbores = TheRobot.Hellbores
				MainWindow.Robot4Drones = TheRobot.Drones
				MainWindow.Robot4Stunners = TheRobot.Stunners
				MainWindow.Robot4Mines = TheRobot.Mines
				MainWindow.Robot4Lasers = TheRobot.Lasers
				MainWindow.Robot4Turret = TheRobot.Turret
			Case 5
				MainWindow.ER(5).Text = CStr(TheRobot.Energy)
				MainWindow.DR(5).Text = CStr(TheRobot.Damage)
				MainWindow.Robot5Energy = TheRobot.Energy
				MainWindow.Robot5Damage = TheRobot.Damage
				MainWindow.Robot5Shield = TheRobot.Shield
				MainWindow.Robot5ProSpeed = TheRobot.Speed
				MainWindow.Robot5Bullets = TheRobot.Bullets
				MainWindow.Robot5Probes = TheRobot.Probes
				MainWindow.Robot5Missiles = TheRobot.Missiles
				MainWindow.Robot5TacNukes = TheRobot.TacNukes
				MainWindow.Robot5Hellbores = TheRobot.Hellbores
				MainWindow.Robot5Drones = TheRobot.Drones
				MainWindow.Robot5Stunners = TheRobot.Stunners
				MainWindow.Robot5Mines = TheRobot.Mines
				MainWindow.Robot5Lasers = TheRobot.Lasers
				MainWindow.Robot5Turret = TheRobot.Turret
			Case 6
				MainWindow.ER(6).Text = CStr(TheRobot.Energy)
				MainWindow.DR(6).Text = CStr(TheRobot.Damage)
				MainWindow.Robot6Energy = TheRobot.Energy
				MainWindow.Robot6Damage = TheRobot.Damage
				MainWindow.Robot6Shield = TheRobot.Shield
				MainWindow.Robot6ProSpeed = TheRobot.Speed
				MainWindow.Robot6Bullets = TheRobot.Bullets
				MainWindow.Robot6Probes = TheRobot.Probes
				MainWindow.Robot6Missiles = TheRobot.Missiles
				MainWindow.Robot6TacNukes = TheRobot.TacNukes
				MainWindow.Robot6Hellbores = TheRobot.Hellbores
				MainWindow.Robot6Drones = TheRobot.Drones
				MainWindow.Robot6Stunners = TheRobot.Stunners
				MainWindow.Robot6Mines = TheRobot.Mines
				MainWindow.Robot6Lasers = TheRobot.Lasers
				MainWindow.Robot6Turret = TheRobot.Turret
		End Select
	End Sub
	
	Private Sub SkrivHardware()
		
		'RefreshHW (MainWindow.SelectedRobot)
		
		If MainWindow.R1path = LoadRobotPath Then RefreshHW((1)) 'It doesn't mater if
		If MainWindow.R2path = LoadRobotPath Then RefreshHW((2)) 'it refreshes non-existing robots
		If MainWindow.R3path = LoadRobotPath Then RefreshHW((3)) '(I think =S)
		If MainWindow.R4path = LoadRobotPath Then RefreshHW((4))
		If MainWindow.R5path = LoadRobotPath Then RefreshHW((5))
		If MainWindow.R6path = LoadRobotPath Then RefreshHW((6))
		
		FileOpen(1, LoadRobotPath, OpenMode.Binary)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, TheRobot)
		FileClose(1)
		
		'MsgBox MainWindow.Robot1Drones
	End Sub
End Class