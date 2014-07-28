<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class MainWindow
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents NewRobot As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents LoadRobot As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Duplicate As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents SaveAs As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Close_Renamed As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents RenameRobot As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents DelateRobot As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator1 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Quit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Area As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Drafting As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Hardware As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Icon_Renamed As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Studio As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator4 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Password As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents NoTeam As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Team1 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Team2 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Team3 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator5 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents ResetHistory As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents History As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents RepeatBattle As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator6 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Tournament As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents TestRobot As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator18 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Scoring As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator16 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents SetGameSpeed As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents ArenaMenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Fast As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Normal As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Slow As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Slower As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Slowest As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents AutoRedrawFast As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents NoDisplay As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Ultra As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents SpeedMenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator8 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Sounds As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator9 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents ChronorsLimit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MoveAndShoot As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Overloading As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator14 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents AutoNoSound As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents resolution As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator15 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents ChangeResolution As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator11 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents ShowMoveAndShoot As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents InactivateDebug As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents PreferenceMenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Help As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Tutorial As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents About As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents KnownBugs As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents WelcomeWindowSwitchMenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Separator13 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Debugger As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents StartAtChronon As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents TitleTimer As System.Windows.Forms.Timer
	Public WithEvents StopTournament As System.Windows.Forms.Button
	Public WithEvents _EnergyDisplay_6 As System.Windows.Forms.PictureBox
	Public WithEvents _EnergyDisplay_5 As System.Windows.Forms.PictureBox
	Public WithEvents _EnergyDisplay_4 As System.Windows.Forms.PictureBox
	Public WithEvents _EnergyDisplay_3 As System.Windows.Forms.PictureBox
	Public WithEvents _EnergyDisplay_2 As System.Windows.Forms.PictureBox
	Public WithEvents _EnergyDisplay_1 As System.Windows.Forms.PictureBox
	Public WithEvents NumerOfCrononsDisplay As System.Windows.Forms.PictureBox
	Public WithEvents Arena As System.Windows.Forms.PictureBox
	Public WithEvents CPRTimer As System.Windows.Forms.Timer
	Public CommonDialog3Save As System.Windows.Forms.SaveFileDialog
	Public CommonDialog2Open As System.Windows.Forms.OpenFileDialog
	Public CommonDialog2Save As System.Windows.Forms.SaveFileDialog
	Public CommonDialog2Font As System.Windows.Forms.FontDialog
	Public CommonDialog2Color As System.Windows.Forms.ColorDialog
	Public CommonDialog2Print As System.Windows.Forms.PrintDialog
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public WithEvents BattleHaltButton As System.Windows.Forms.Button
	Public WithEvents R1Icon As System.Windows.Forms.PictureBox
	Public WithEvents R2Icon As System.Windows.Forms.PictureBox
	Public WithEvents R3Icon As System.Windows.Forms.PictureBox
	Public WithEvents R4Icon As System.Windows.Forms.PictureBox
	Public WithEvents R5Icon As System.Windows.Forms.PictureBox
	Public WithEvents R6Icon As System.Windows.Forms.PictureBox
	Public WithEvents Image2 As System.Windows.Forms.PictureBox
	Public WithEvents _TeamLabel_6 As System.Windows.Forms.Label
	Public WithEvents _TeamLabel_5 As System.Windows.Forms.Label
	Public WithEvents _TeamLabel_4 As System.Windows.Forms.Label
	Public WithEvents _TeamLabel_3 As System.Windows.Forms.Label
	Public WithEvents _TeamLabel_2 As System.Windows.Forms.Label
	Public WithEvents _TeamLabel_1 As System.Windows.Forms.Label
	Public WithEvents _RobotDead_6 As System.Windows.Forms.Label
	Public WithEvents _RobotDead_5 As System.Windows.Forms.Label
	Public WithEvents _RobotDead_4 As System.Windows.Forms.Label
	Public WithEvents _RobotDead_3 As System.Windows.Forms.Label
	Public WithEvents _RobotDead_2 As System.Windows.Forms.Label
	Public WithEvents _RobotDead_1 As System.Windows.Forms.Label
	Public WithEvents Chronors As System.Windows.Forms.Label
	Public WithEvents ReplayText As System.Windows.Forms.Label
	Public WithEvents _Image1_5 As System.Windows.Forms.PictureBox
	Public WithEvents _Image1_4 As System.Windows.Forms.PictureBox
	Public WithEvents _Image1_3 As System.Windows.Forms.PictureBox
	Public WithEvents _Image1_2 As System.Windows.Forms.PictureBox
	Public WithEvents _Image1_1 As System.Windows.Forms.PictureBox
	Public WithEvents _Image1_6 As System.Windows.Forms.PictureBox
	Public WithEvents CPRLabel As System.Windows.Forms.Label
	Public WithEvents PerSecond As System.Windows.Forms.Label
	Public WithEvents Robot1 As System.Windows.Forms.Label
	Public WithEvents _DR_6 As System.Windows.Forms.Label
	Public WithEvents Robot6 As System.Windows.Forms.Label
	Public WithEvents Robot5 As System.Windows.Forms.Label
	Public WithEvents Robot4 As System.Windows.Forms.Label
	Public WithEvents Robot3 As System.Windows.Forms.Label
	Public WithEvents Robot2 As System.Windows.Forms.Label
	Public WithEvents Load6 As System.Windows.Forms.Label
	Public WithEvents Load2 As System.Windows.Forms.Label
	Public WithEvents Load5 As System.Windows.Forms.Label
	Public WithEvents Load3 As System.Windows.Forms.Label
	Public WithEvents Load4 As System.Windows.Forms.Label
	Public WithEvents Load1 As System.Windows.Forms.Label
	Public WithEvents PR6 As System.Windows.Forms.Label
	Public WithEvents PR5 As System.Windows.Forms.Label
	Public WithEvents PR4 As System.Windows.Forms.Label
	Public WithEvents PR3 As System.Windows.Forms.Label
	Public WithEvents PR2 As System.Windows.Forms.Label
	Public WithEvents PR1 As System.Windows.Forms.Label
	Public WithEvents _DR_5 As System.Windows.Forms.Label
	Public WithEvents _DR_4 As System.Windows.Forms.Label
	Public WithEvents _DR_3 As System.Windows.Forms.Label
	Public WithEvents _DR_2 As System.Windows.Forms.Label
	Public WithEvents _DR_1 As System.Windows.Forms.Label
	Public WithEvents _ER_6 As System.Windows.Forms.Label
	Public WithEvents _ER_5 As System.Windows.Forms.Label
	Public WithEvents _ER_4 As System.Windows.Forms.Label
	Public WithEvents _ER_3 As System.Windows.Forms.Label
	Public WithEvents _ER_2 As System.Windows.Forms.Label
	Public WithEvents _ER_1 As System.Windows.Forms.Label
	Public WithEvents Energy6X As System.Windows.Forms.Label
	Public WithEvents Damage6X As System.Windows.Forms.Label
	Public WithEvents Points6X As System.Windows.Forms.Label
	Public WithEvents Energy5X As System.Windows.Forms.Label
	Public WithEvents Damage5X As System.Windows.Forms.Label
	Public WithEvents Points5X As System.Windows.Forms.Label
	Public WithEvents Energy4X As System.Windows.Forms.Label
	Public WithEvents Damage4X As System.Windows.Forms.Label
	Public WithEvents Points4X As System.Windows.Forms.Label
	Public WithEvents Energy3X As System.Windows.Forms.Label
	Public WithEvents Damage3X As System.Windows.Forms.Label
	Public WithEvents Points3X As System.Windows.Forms.Label
	Public WithEvents Energy2X As System.Windows.Forms.Label
	Public WithEvents Damage2X As System.Windows.Forms.Label
	Public WithEvents Points2X As System.Windows.Forms.Label
	Public WithEvents Points1X As System.Windows.Forms.Label
	Public WithEvents Damage1X As System.Windows.Forms.Label
	Public WithEvents Energy1X As System.Windows.Forms.Label
	Public WithEvents DR As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents ER As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents EnergyDisplay As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents Image1 As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents RobotDead As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents TeamLabel As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainWindow))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip
		Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem
		Me.NewRobot = New System.Windows.Forms.ToolStripMenuItem
		Me.LoadRobot = New System.Windows.Forms.ToolStripMenuItem
		Me.Duplicate = New System.Windows.Forms.ToolStripMenuItem
		Me.SaveAs = New System.Windows.Forms.ToolStripMenuItem
		Me.Close_Renamed = New System.Windows.Forms.ToolStripMenuItem
		Me.RenameRobot = New System.Windows.Forms.ToolStripMenuItem
		Me.DelateRobot = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator1 = New System.Windows.Forms.ToolStripSeparator
		Me.Quit = New System.Windows.Forms.ToolStripMenuItem
		Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem
		Me.Area = New System.Windows.Forms.ToolStripMenuItem
		Me.Drafting = New System.Windows.Forms.ToolStripMenuItem
		Me.Hardware = New System.Windows.Forms.ToolStripMenuItem
		Me.Icon_Renamed = New System.Windows.Forms.ToolStripMenuItem
		Me.Studio = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator4 = New System.Windows.Forms.ToolStripSeparator
		Me.Password = New System.Windows.Forms.ToolStripMenuItem
		Me.ArenaMenu = New System.Windows.Forms.ToolStripMenuItem
		Me.NoTeam = New System.Windows.Forms.ToolStripMenuItem
		Me.Team1 = New System.Windows.Forms.ToolStripMenuItem
		Me.Team2 = New System.Windows.Forms.ToolStripMenuItem
		Me.Team3 = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator5 = New System.Windows.Forms.ToolStripSeparator
		Me.ResetHistory = New System.Windows.Forms.ToolStripMenuItem
		Me.History = New System.Windows.Forms.ToolStripMenuItem
		Me.RepeatBattle = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator6 = New System.Windows.Forms.ToolStripSeparator
		Me.Tournament = New System.Windows.Forms.ToolStripMenuItem
		Me.TestRobot = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator18 = New System.Windows.Forms.ToolStripSeparator
		Me.Scoring = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator16 = New System.Windows.Forms.ToolStripSeparator
		Me.SetGameSpeed = New System.Windows.Forms.ToolStripMenuItem
		Me.PreferenceMenu = New System.Windows.Forms.ToolStripMenuItem
		Me.SpeedMenu = New System.Windows.Forms.ToolStripMenuItem
		Me.Fast = New System.Windows.Forms.ToolStripMenuItem
		Me.Normal = New System.Windows.Forms.ToolStripMenuItem
		Me.Slow = New System.Windows.Forms.ToolStripMenuItem
		Me.Slower = New System.Windows.Forms.ToolStripMenuItem
		Me.Slowest = New System.Windows.Forms.ToolStripMenuItem
		Me.AutoRedrawFast = New System.Windows.Forms.ToolStripMenuItem
		Me.NoDisplay = New System.Windows.Forms.ToolStripMenuItem
		Me.Ultra = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator8 = New System.Windows.Forms.ToolStripSeparator
		Me.Sounds = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator9 = New System.Windows.Forms.ToolStripSeparator
		Me.ChronorsLimit = New System.Windows.Forms.ToolStripMenuItem
		Me.MoveAndShoot = New System.Windows.Forms.ToolStripMenuItem
		Me.Overloading = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator14 = New System.Windows.Forms.ToolStripSeparator
		Me.AutoNoSound = New System.Windows.Forms.ToolStripMenuItem
		Me.resolution = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator15 = New System.Windows.Forms.ToolStripSeparator
		Me.ChangeResolution = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator11 = New System.Windows.Forms.ToolStripSeparator
		Me.ShowMoveAndShoot = New System.Windows.Forms.ToolStripMenuItem
		Me.InactivateDebug = New System.Windows.Forms.ToolStripMenuItem
		Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem
		Me.Help = New System.Windows.Forms.ToolStripMenuItem
		Me.Tutorial = New System.Windows.Forms.ToolStripMenuItem
		Me.About = New System.Windows.Forms.ToolStripMenuItem
		Me.KnownBugs = New System.Windows.Forms.ToolStripMenuItem
		Me.WelcomeWindowSwitchMenu = New System.Windows.Forms.ToolStripMenuItem
		Me.Separator13 = New System.Windows.Forms.ToolStripSeparator
		Me.Debugger = New System.Windows.Forms.ToolStripMenuItem
		Me.StartAtChronon = New System.Windows.Forms.ToolStripMenuItem
		Me.TitleTimer = New System.Windows.Forms.Timer(components)
		Me.StopTournament = New System.Windows.Forms.Button
		Me._EnergyDisplay_6 = New System.Windows.Forms.PictureBox
		Me._EnergyDisplay_5 = New System.Windows.Forms.PictureBox
		Me._EnergyDisplay_4 = New System.Windows.Forms.PictureBox
		Me._EnergyDisplay_3 = New System.Windows.Forms.PictureBox
		Me._EnergyDisplay_2 = New System.Windows.Forms.PictureBox
		Me._EnergyDisplay_1 = New System.Windows.Forms.PictureBox
		Me.NumerOfCrononsDisplay = New System.Windows.Forms.PictureBox
		Me.Arena = New System.Windows.Forms.PictureBox
		Me.CPRTimer = New System.Windows.Forms.Timer(components)
		Me.CommonDialog3Save = New System.Windows.Forms.SaveFileDialog
		Me.CommonDialog2Open = New System.Windows.Forms.OpenFileDialog
		Me.CommonDialog2Save = New System.Windows.Forms.SaveFileDialog
		Me.CommonDialog2Font = New System.Windows.Forms.FontDialog
		Me.CommonDialog2Color = New System.Windows.Forms.ColorDialog
		Me.CommonDialog2Print = New System.Windows.Forms.PrintDialog
		Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
		Me.BattleHaltButton = New System.Windows.Forms.Button
		Me.R1Icon = New System.Windows.Forms.PictureBox
		Me.R2Icon = New System.Windows.Forms.PictureBox
		Me.R3Icon = New System.Windows.Forms.PictureBox
		Me.R4Icon = New System.Windows.Forms.PictureBox
		Me.R5Icon = New System.Windows.Forms.PictureBox
		Me.R6Icon = New System.Windows.Forms.PictureBox
		Me.Image2 = New System.Windows.Forms.PictureBox
		Me._TeamLabel_6 = New System.Windows.Forms.Label
		Me._TeamLabel_5 = New System.Windows.Forms.Label
		Me._TeamLabel_4 = New System.Windows.Forms.Label
		Me._TeamLabel_3 = New System.Windows.Forms.Label
		Me._TeamLabel_2 = New System.Windows.Forms.Label
		Me._TeamLabel_1 = New System.Windows.Forms.Label
		Me._RobotDead_6 = New System.Windows.Forms.Label
		Me._RobotDead_5 = New System.Windows.Forms.Label
		Me._RobotDead_4 = New System.Windows.Forms.Label
		Me._RobotDead_3 = New System.Windows.Forms.Label
		Me._RobotDead_2 = New System.Windows.Forms.Label
		Me._RobotDead_1 = New System.Windows.Forms.Label
		Me.Chronors = New System.Windows.Forms.Label
		Me.ReplayText = New System.Windows.Forms.Label
		Me._Image1_5 = New System.Windows.Forms.PictureBox
		Me._Image1_4 = New System.Windows.Forms.PictureBox
		Me._Image1_3 = New System.Windows.Forms.PictureBox
		Me._Image1_2 = New System.Windows.Forms.PictureBox
		Me._Image1_1 = New System.Windows.Forms.PictureBox
		Me._Image1_6 = New System.Windows.Forms.PictureBox
		Me.CPRLabel = New System.Windows.Forms.Label
		Me.PerSecond = New System.Windows.Forms.Label
		Me.Robot1 = New System.Windows.Forms.Label
		Me._DR_6 = New System.Windows.Forms.Label
		Me.Robot6 = New System.Windows.Forms.Label
		Me.Robot5 = New System.Windows.Forms.Label
		Me.Robot4 = New System.Windows.Forms.Label
		Me.Robot3 = New System.Windows.Forms.Label
		Me.Robot2 = New System.Windows.Forms.Label
		Me.Load6 = New System.Windows.Forms.Label
		Me.Load2 = New System.Windows.Forms.Label
		Me.Load5 = New System.Windows.Forms.Label
		Me.Load3 = New System.Windows.Forms.Label
		Me.Load4 = New System.Windows.Forms.Label
		Me.Load1 = New System.Windows.Forms.Label
		Me.PR6 = New System.Windows.Forms.Label
		Me.PR5 = New System.Windows.Forms.Label
		Me.PR4 = New System.Windows.Forms.Label
		Me.PR3 = New System.Windows.Forms.Label
		Me.PR2 = New System.Windows.Forms.Label
		Me.PR1 = New System.Windows.Forms.Label
		Me._DR_5 = New System.Windows.Forms.Label
		Me._DR_4 = New System.Windows.Forms.Label
		Me._DR_3 = New System.Windows.Forms.Label
		Me._DR_2 = New System.Windows.Forms.Label
		Me._DR_1 = New System.Windows.Forms.Label
		Me._ER_6 = New System.Windows.Forms.Label
		Me._ER_5 = New System.Windows.Forms.Label
		Me._ER_4 = New System.Windows.Forms.Label
		Me._ER_3 = New System.Windows.Forms.Label
		Me._ER_2 = New System.Windows.Forms.Label
		Me._ER_1 = New System.Windows.Forms.Label
		Me.Energy6X = New System.Windows.Forms.Label
		Me.Damage6X = New System.Windows.Forms.Label
		Me.Points6X = New System.Windows.Forms.Label
		Me.Energy5X = New System.Windows.Forms.Label
		Me.Damage5X = New System.Windows.Forms.Label
		Me.Points5X = New System.Windows.Forms.Label
		Me.Energy4X = New System.Windows.Forms.Label
		Me.Damage4X = New System.Windows.Forms.Label
		Me.Points4X = New System.Windows.Forms.Label
		Me.Energy3X = New System.Windows.Forms.Label
		Me.Damage3X = New System.Windows.Forms.Label
		Me.Points3X = New System.Windows.Forms.Label
		Me.Energy2X = New System.Windows.Forms.Label
		Me.Damage2X = New System.Windows.Forms.Label
		Me.Points2X = New System.Windows.Forms.Label
		Me.Points1X = New System.Windows.Forms.Label
		Me.Damage1X = New System.Windows.Forms.Label
		Me.Energy1X = New System.Windows.Forms.Label
		Me.DR = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.ER = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.EnergyDisplay = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.Image1 = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.RobotDead = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.TeamLabel = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.MainMenu1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DR, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ER, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.EnergyDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.RobotDead, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TeamLabel, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "RoboWar 5 - Arena"
		Me.ClientSize = New System.Drawing.Size(634, 391)
		Me.Location = New System.Drawing.Point(3, 49)
		Me.ForeColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me.Icon_Renamed.Enabled = 0
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.Name = "MainWindow"
		Me.FileMenu.Name = "FileMenu"
		Me.FileMenu.Text = "File"
		Me.FileMenu.Checked = False
		Me.FileMenu.Enabled = True
		Me.FileMenu.Visible = True
		Me.NewRobot.Name = "NewRobot"
		Me.NewRobot.Text = "New Robot"
		Me.NewRobot.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.N, System.Windows.Forms.Keys)
		Me.NewRobot.Checked = False
		Me.NewRobot.Enabled = True
		Me.NewRobot.Visible = True
		Me.LoadRobot.Name = "LoadRobot"
		Me.LoadRobot.Text = "Load Robot"
		Me.LoadRobot.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.O, System.Windows.Forms.Keys)
		Me.LoadRobot.Checked = False
		Me.LoadRobot.Enabled = True
		Me.LoadRobot.Visible = True
		Me.Duplicate.Name = "Duplicate"
		Me.Duplicate.Text = "Duplicate"
		Me.Duplicate.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.D, System.Windows.Forms.Keys)
		Me.Duplicate.Checked = False
		Me.Duplicate.Enabled = True
		Me.Duplicate.Visible = True
		Me.SaveAs.Name = "SaveAs"
		Me.SaveAs.Text = "Save Robot As"
		Me.SaveAs.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.A, System.Windows.Forms.Keys)
		Me.SaveAs.Checked = False
		Me.SaveAs.Enabled = True
		Me.SaveAs.Visible = True
		Me.Close_Renamed.Name = "Close"
		Me.Close_Renamed.Text = "Close"
		Me.Close_Renamed.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.W, System.Windows.Forms.Keys)
		Me.Close_Renamed.Checked = False
		Me.Close_Renamed.Enabled = True
		Me.Close_Renamed.Visible = True
		Me.RenameRobot.Name = "RenameRobot"
		Me.RenameRobot.Text = "Rename Robot"
		Me.RenameRobot.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.F, System.Windows.Forms.Keys)
		Me.RenameRobot.Checked = False
		Me.RenameRobot.Enabled = True
		Me.RenameRobot.Visible = True
		Me.DelateRobot.Name = "DelateRobot"
		Me.DelateRobot.Text = "Delete Robot"
		Me.DelateRobot.ShortcutKeys = CType(System.Windows.Forms.Keys.Shift or System.Windows.Forms.Keys.Delete, System.Windows.Forms.Keys)
		Me.DelateRobot.Checked = False
		Me.DelateRobot.Enabled = True
		Me.DelateRobot.Visible = True
		Me.Separator1.Enabled = True
		Me.Separator1.Visible = True
		Me.Separator1.Name = "Separator1"
		Me.Quit.Name = "Quit"
		Me.Quit.Text = "Quit"
		Me.Quit.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.Q, System.Windows.Forms.Keys)
		Me.Quit.Checked = False
		Me.Quit.Enabled = True
		Me.Quit.Visible = True
		Me.ViewMenu.Name = "ViewMenu"
		Me.ViewMenu.Text = "View"
		Me.ViewMenu.Checked = False
		Me.ViewMenu.Enabled = True
		Me.ViewMenu.Visible = True
		Me.Area.Name = "Area"
		Me.Area.Text = "Arena"
		Me.Area.Checked = True
		Me.Area.ShortcutKeys = CType(System.Windows.Forms.Keys.F1, System.Windows.Forms.Keys)
		Me.Area.Enabled = True
		Me.Area.Visible = True
		Me.Drafting.Name = "Drafting"
		Me.Drafting.Text = "Drafting Board"
		Me.Drafting.ShortcutKeys = CType(System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys)
		Me.Drafting.Checked = False
		Me.Drafting.Enabled = True
		Me.Drafting.Visible = True
		Me.Hardware.Name = "Hardware"
		Me.Hardware.Text = "Hardware Store"
		Me.Hardware.ShortcutKeys = CType(System.Windows.Forms.Keys.F3, System.Windows.Forms.Keys)
		Me.Hardware.Checked = False
		Me.Hardware.Enabled = True
		Me.Hardware.Visible = True
		Me.Icon_Renamed.Name = "Icon"
		Me.Icon_Renamed.Text = "Icon Factory"
		Me.Icon_Renamed.ShortcutKeys = CType(System.Windows.Forms.Keys.F4, System.Windows.Forms.Keys)
		Me.Icon_Renamed.Checked = False
		Me.Icon_Renamed.Enabled = True
		Me.Icon_Renamed.Visible = True
		Me.Studio.Name = "Studio"
		Me.Studio.Text = "Recording Studio"
		Me.Studio.ShortcutKeys = CType(System.Windows.Forms.Keys.F5, System.Windows.Forms.Keys)
		Me.Studio.Checked = False
		Me.Studio.Enabled = True
		Me.Studio.Visible = True
		Me.Separator4.Enabled = True
		Me.Separator4.Visible = True
		Me.Separator4.Name = "Separator4"
		Me.Password.Name = "Password"
		Me.Password.Text = "Set Password"
		Me.Password.Checked = False
		Me.Password.Enabled = True
		Me.Password.Visible = True
		Me.ArenaMenu.Name = "ArenaMenu"
		Me.ArenaMenu.Text = "Arena"
		Me.ArenaMenu.Checked = False
		Me.ArenaMenu.Enabled = True
		Me.ArenaMenu.Visible = True
		Me.NoTeam.Name = "NoTeam"
		Me.NoTeam.Text = "No Team"
		Me.NoTeam.ShortcutKeys = CType(System.Windows.Forms.Keys.Shift or System.Windows.Forms.Keys.F4, System.Windows.Forms.Keys)
		Me.NoTeam.Checked = False
		Me.NoTeam.Enabled = True
		Me.NoTeam.Visible = True
		Me.Team1.Name = "Team1"
		Me.Team1.Text = "Team 1"
		Me.Team1.ShortcutKeys = CType(System.Windows.Forms.Keys.Shift or System.Windows.Forms.Keys.F1, System.Windows.Forms.Keys)
		Me.Team1.Checked = False
		Me.Team1.Enabled = True
		Me.Team1.Visible = True
		Me.Team2.Name = "Team2"
		Me.Team2.Text = "Team 2"
		Me.Team2.ShortcutKeys = CType(System.Windows.Forms.Keys.Shift or System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys)
		Me.Team2.Checked = False
		Me.Team2.Enabled = True
		Me.Team2.Visible = True
		Me.Team3.Name = "Team3"
		Me.Team3.Text = "Team 3"
		Me.Team3.ShortcutKeys = CType(System.Windows.Forms.Keys.Shift or System.Windows.Forms.Keys.F3, System.Windows.Forms.Keys)
		Me.Team3.Checked = False
		Me.Team3.Enabled = True
		Me.Team3.Visible = True
		Me.Separator5.Enabled = True
		Me.Separator5.Visible = True
		Me.Separator5.Name = "Separator5"
		Me.ResetHistory.Name = "ResetHistory"
		Me.ResetHistory.Text = "Reset History"
		Me.ResetHistory.ShortcutKeys = CType(System.Windows.Forms.Keys.Delete, System.Windows.Forms.Keys)
		Me.ResetHistory.Checked = False
		Me.ResetHistory.Enabled = True
		Me.ResetHistory.Visible = True
		Me.History.Name = "History"
		Me.History.Text = "Show History"
		Me.History.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.H, System.Windows.Forms.Keys)
		Me.History.Checked = False
		Me.History.Enabled = True
		Me.History.Visible = True
		Me.RepeatBattle.Name = "RepeatBattle"
		Me.RepeatBattle.Text = "Repeat Battle"
		Me.RepeatBattle.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.R, System.Windows.Forms.Keys)
		Me.RepeatBattle.Checked = False
		Me.RepeatBattle.Enabled = True
		Me.RepeatBattle.Visible = True
		Me.Separator6.Enabled = True
		Me.Separator6.Visible = True
		Me.Separator6.Name = "Separator6"
		Me.Tournament.Name = "Tournament"
		Me.Tournament.Text = "Tournament"
		Me.Tournament.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.T, System.Windows.Forms.Keys)
		Me.Tournament.Checked = False
		Me.Tournament.Enabled = True
		Me.Tournament.Visible = True
		Me.TestRobot.Name = "TestRobot"
		Me.TestRobot.Text = "Test Robot"
		Me.TestRobot.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.Y, System.Windows.Forms.Keys)
		Me.TestRobot.Checked = False
		Me.TestRobot.Enabled = True
		Me.TestRobot.Visible = True
		Me.Separator18.Enabled = True
		Me.Separator18.Visible = True
		Me.Separator18.Name = "Separator18"
		Me.Scoring.Name = "Scoring"
		Me.Scoring.Text = "Scoring: Standard"
		Me.Scoring.Checked = False
		Me.Scoring.Enabled = True
		Me.Scoring.Visible = True
		Me.Separator16.Enabled = True
		Me.Separator16.Visible = True
		Me.Separator16.Name = "Separator16"
		Me.SetGameSpeed.Name = "SetGameSpeed"
		Me.SetGameSpeed.Text = "Set Game Speed"
		Me.SetGameSpeed.Checked = False
		Me.SetGameSpeed.Enabled = True
		Me.SetGameSpeed.Visible = True
		Me.PreferenceMenu.Name = "PreferenceMenu"
		Me.PreferenceMenu.Text = "Preference"
		Me.PreferenceMenu.Checked = False
		Me.PreferenceMenu.Enabled = True
		Me.PreferenceMenu.Visible = True
		Me.SpeedMenu.Name = "SpeedMenu"
		Me.SpeedMenu.Text = "Speed"
		Me.SpeedMenu.Checked = False
		Me.SpeedMenu.Enabled = True
		Me.SpeedMenu.Visible = True
		Me.Fast.Name = "Fast"
		Me.Fast.Text = "Fast"
		Me.Fast.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.F5, System.Windows.Forms.Keys)
		Me.Fast.Checked = False
		Me.Fast.Enabled = True
		Me.Fast.Visible = True
		Me.Normal.Name = "Normal"
		Me.Normal.Text = "Normal"
		Me.Normal.Checked = True
		Me.Normal.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.F4, System.Windows.Forms.Keys)
		Me.Normal.Enabled = True
		Me.Normal.Visible = True
		Me.Slow.Name = "Slow"
		Me.Slow.Text = "Slow"
		Me.Slow.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.F3, System.Windows.Forms.Keys)
		Me.Slow.Checked = False
		Me.Slow.Enabled = True
		Me.Slow.Visible = True
		Me.Slower.Name = "Slower"
		Me.Slower.Text = "Slower"
		Me.Slower.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys)
		Me.Slower.Checked = False
		Me.Slower.Enabled = True
		Me.Slower.Visible = True
		Me.Slowest.Name = "Slowest"
		Me.Slowest.Text = "Slowest"
		Me.Slowest.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.F1, System.Windows.Forms.Keys)
		Me.Slowest.Checked = False
		Me.Slowest.Enabled = True
		Me.Slowest.Visible = True
		Me.AutoRedrawFast.Name = "AutoRedrawFast"
		Me.AutoRedrawFast.Text = "Auto Redraw Fast"
		Me.AutoRedrawFast.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.F8, System.Windows.Forms.Keys)
		Me.AutoRedrawFast.Visible = False
		Me.AutoRedrawFast.Checked = False
		Me.AutoRedrawFast.Enabled = True
		Me.NoDisplay.Name = "NoDisplay"
		Me.NoDisplay.Text = "No Display (Faster)"
		Me.NoDisplay.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.F6, System.Windows.Forms.Keys)
		Me.NoDisplay.Checked = False
		Me.NoDisplay.Enabled = True
		Me.NoDisplay.Visible = True
		Me.Ultra.Name = "Ultra"
		Me.Ultra.Text = "Ultra (Fastest)"
		Me.Ultra.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.F7, System.Windows.Forms.Keys)
		Me.Ultra.Checked = False
		Me.Ultra.Enabled = True
		Me.Ultra.Visible = True
		Me.Separator8.Enabled = True
		Me.Separator8.Visible = True
		Me.Separator8.Name = "Separator8"
		Me.Sounds.Name = "Sounds"
		Me.Sounds.Text = "Sounds"
		Me.Sounds.Checked = True
		Me.Sounds.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.S, System.Windows.Forms.Keys)
		Me.Sounds.Enabled = True
		Me.Sounds.Visible = True
		Me.Separator9.Enabled = True
		Me.Separator9.Visible = True
		Me.Separator9.Name = "Separator9"
		Me.ChronorsLimit.Name = "ChronorsLimit"
		Me.ChronorsLimit.Text = "1500 Chronors Limit"
		Me.ChronorsLimit.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.L, System.Windows.Forms.Keys)
		Me.ChronorsLimit.Checked = False
		Me.ChronorsLimit.Enabled = True
		Me.ChronorsLimit.Visible = True
		Me.MoveAndShoot.Name = "MoveAndShoot"
		Me.MoveAndShoot.Text = "Disallow Move and Shoot "
		Me.MoveAndShoot.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.M, System.Windows.Forms.Keys)
		Me.MoveAndShoot.Checked = False
		Me.MoveAndShoot.Enabled = True
		Me.MoveAndShoot.Visible = True
		Me.Overloading.Name = "Overloading"
		Me.Overloading.Text = "Allow less than -200 Energy"
		Me.Overloading.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.E, System.Windows.Forms.Keys)
		Me.Overloading.Checked = False
		Me.Overloading.Enabled = True
		Me.Overloading.Visible = True
		Me.Separator14.Enabled = True
		Me.Separator14.Visible = True
		Me.Separator14.Name = "Separator14"
		Me.AutoNoSound.Name = "AutoNoSound"
		Me.AutoNoSound.Text = "Auto No Sound"
		Me.AutoNoSound.Visible = False
		Me.AutoNoSound.Checked = False
		Me.AutoNoSound.Enabled = True
		Me.resolution.Name = "resolution"
		Me.resolution.Text = "Auto Change Resolution"
		Me.resolution.Checked = False
		Me.resolution.Enabled = True
		Me.resolution.Visible = True
		Me.Separator15.Enabled = True
		Me.Separator15.Visible = True
		Me.Separator15.Name = "Separator15"
		Me.ChangeResolution.Name = "ChangeResolution"
		Me.ChangeResolution.Text = "Change Resolution"
		Me.ChangeResolution.Checked = False
		Me.ChangeResolution.Enabled = True
		Me.ChangeResolution.Visible = True
		Me.Separator11.Enabled = True
		Me.Separator11.Visible = True
		Me.Separator11.Name = "Separator11"
		Me.ShowMoveAndShoot.Name = "ShowMoveAndShoot"
		Me.ShowMoveAndShoot.Text = "Show Move + shoot messages"
		Me.ShowMoveAndShoot.Checked = True
		Me.ShowMoveAndShoot.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.V, System.Windows.Forms.Keys)
		Me.ShowMoveAndShoot.Enabled = True
		Me.ShowMoveAndShoot.Visible = True
		Me.InactivateDebug.Name = "InactivateDebug"
		Me.InactivateDebug.Text = "Deactivate the ""Debug"" inst"
		Me.InactivateDebug.Checked = True
		Me.InactivateDebug.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.I, System.Windows.Forms.Keys)
		Me.InactivateDebug.Enabled = True
		Me.InactivateDebug.Visible = True
		Me.HelpMenu.Name = "HelpMenu"
		Me.HelpMenu.Text = "Help"
		Me.HelpMenu.Checked = False
		Me.HelpMenu.Enabled = True
		Me.HelpMenu.Visible = True
		Me.Help.Name = "Help"
		Me.Help.Text = "Help"
		Me.Help.Checked = False
		Me.Help.Enabled = True
		Me.Help.Visible = True
		Me.Tutorial.Name = "Tutorial"
		Me.Tutorial.Text = "Tutorial"
		Me.Tutorial.Checked = False
		Me.Tutorial.Enabled = True
		Me.Tutorial.Visible = True
		Me.About.Name = "About"
		Me.About.Text = "About RoboWar 5"
		Me.About.Checked = False
		Me.About.Enabled = True
		Me.About.Visible = True
		Me.KnownBugs.Name = "KnownBugs"
		Me.KnownBugs.Text = "Known Bugs"
		Me.KnownBugs.Checked = False
		Me.KnownBugs.Enabled = True
		Me.KnownBugs.Visible = True
		Me.WelcomeWindowSwitchMenu.Name = "WelcomeWindowSwitchMenu"
		Me.WelcomeWindowSwitchMenu.Text = "Show Welcome Window at Startup"
		Me.WelcomeWindowSwitchMenu.Checked = False
		Me.WelcomeWindowSwitchMenu.Enabled = True
		Me.WelcomeWindowSwitchMenu.Visible = True
		Me.Separator13.Enabled = True
		Me.Separator13.Visible = True
		Me.Separator13.Name = "Separator13"
		Me.Debugger.Name = "Debugger"
		Me.Debugger.Text = "Use Debugger"
		Me.Debugger.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.B, System.Windows.Forms.Keys)
		Me.Debugger.Checked = False
		Me.Debugger.Enabled = True
		Me.Debugger.Visible = True
		Me.StartAtChronon.Name = "StartAtChronon"
		Me.StartAtChronon.Text = "Repeat and Debug before crash"
		Me.StartAtChronon.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.C, System.Windows.Forms.Keys)
		Me.StartAtChronon.Checked = False
		Me.StartAtChronon.Enabled = True
		Me.StartAtChronon.Visible = True
		Me.TitleTimer.Enabled = False
		Me.TitleTimer.Interval = 1500
		Me.StopTournament.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.StopTournament.BackColor = System.Drawing.Color.FromARGB(132, 194, 219)
		Me.StopTournament.Text = "Stop Tournament"
		Me.StopTournament.Size = New System.Drawing.Size(81, 33)
		Me.StopTournament.Location = New System.Drawing.Point(544, 336)
		Me.StopTournament.TabIndex = 2
		Me.StopTournament.Visible = False
		Me.StopTournament.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.StopTournament.CausesValidation = True
		Me.StopTournament.Enabled = True
		Me.StopTournament.ForeColor = System.Drawing.SystemColors.ControlText
		Me.StopTournament.Cursor = System.Windows.Forms.Cursors.Default
		Me.StopTournament.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.StopTournament.TabStop = True
		Me.StopTournament.Name = "StopTournament"
		Me._EnergyDisplay_6.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._EnergyDisplay_6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._EnergyDisplay_6.ForeColor = System.Drawing.Color.White
		Me._EnergyDisplay_6.Size = New System.Drawing.Size(25, 17)
		Me._EnergyDisplay_6.Location = New System.Drawing.Point(424, 296)
		Me._EnergyDisplay_6.TabIndex = 79
		Me._EnergyDisplay_6.TabStop = False
		Me._EnergyDisplay_6.Visible = False
		Me._EnergyDisplay_6.Dock = System.Windows.Forms.DockStyle.None
		Me._EnergyDisplay_6.CausesValidation = True
		Me._EnergyDisplay_6.Enabled = True
		Me._EnergyDisplay_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._EnergyDisplay_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._EnergyDisplay_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._EnergyDisplay_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._EnergyDisplay_6.Name = "_EnergyDisplay_6"
		Me._EnergyDisplay_5.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._EnergyDisplay_5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._EnergyDisplay_5.ForeColor = System.Drawing.Color.White
		Me._EnergyDisplay_5.Size = New System.Drawing.Size(25, 17)
		Me._EnergyDisplay_5.Location = New System.Drawing.Point(424, 248)
		Me._EnergyDisplay_5.TabIndex = 78
		Me._EnergyDisplay_5.TabStop = False
		Me._EnergyDisplay_5.Visible = False
		Me._EnergyDisplay_5.Dock = System.Windows.Forms.DockStyle.None
		Me._EnergyDisplay_5.CausesValidation = True
		Me._EnergyDisplay_5.Enabled = True
		Me._EnergyDisplay_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._EnergyDisplay_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._EnergyDisplay_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._EnergyDisplay_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._EnergyDisplay_5.Name = "_EnergyDisplay_5"
		Me._EnergyDisplay_4.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._EnergyDisplay_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._EnergyDisplay_4.ForeColor = System.Drawing.Color.White
		Me._EnergyDisplay_4.Size = New System.Drawing.Size(25, 17)
		Me._EnergyDisplay_4.Location = New System.Drawing.Point(424, 200)
		Me._EnergyDisplay_4.TabIndex = 77
		Me._EnergyDisplay_4.TabStop = False
		Me._EnergyDisplay_4.Visible = False
		Me._EnergyDisplay_4.Dock = System.Windows.Forms.DockStyle.None
		Me._EnergyDisplay_4.CausesValidation = True
		Me._EnergyDisplay_4.Enabled = True
		Me._EnergyDisplay_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._EnergyDisplay_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._EnergyDisplay_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._EnergyDisplay_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._EnergyDisplay_4.Name = "_EnergyDisplay_4"
		Me._EnergyDisplay_3.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._EnergyDisplay_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._EnergyDisplay_3.ForeColor = System.Drawing.Color.White
		Me._EnergyDisplay_3.Size = New System.Drawing.Size(25, 17)
		Me._EnergyDisplay_3.Location = New System.Drawing.Point(424, 152)
		Me._EnergyDisplay_3.TabIndex = 76
		Me._EnergyDisplay_3.TabStop = False
		Me._EnergyDisplay_3.Visible = False
		Me._EnergyDisplay_3.Dock = System.Windows.Forms.DockStyle.None
		Me._EnergyDisplay_3.CausesValidation = True
		Me._EnergyDisplay_3.Enabled = True
		Me._EnergyDisplay_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._EnergyDisplay_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._EnergyDisplay_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._EnergyDisplay_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._EnergyDisplay_3.Name = "_EnergyDisplay_3"
		Me._EnergyDisplay_2.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._EnergyDisplay_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._EnergyDisplay_2.ForeColor = System.Drawing.Color.White
		Me._EnergyDisplay_2.Size = New System.Drawing.Size(25, 17)
		Me._EnergyDisplay_2.Location = New System.Drawing.Point(424, 104)
		Me._EnergyDisplay_2.TabIndex = 75
		Me._EnergyDisplay_2.TabStop = False
		Me._EnergyDisplay_2.Visible = False
		Me._EnergyDisplay_2.Dock = System.Windows.Forms.DockStyle.None
		Me._EnergyDisplay_2.CausesValidation = True
		Me._EnergyDisplay_2.Enabled = True
		Me._EnergyDisplay_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._EnergyDisplay_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._EnergyDisplay_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._EnergyDisplay_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._EnergyDisplay_2.Name = "_EnergyDisplay_2"
		Me._EnergyDisplay_1.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._EnergyDisplay_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._EnergyDisplay_1.ForeColor = System.Drawing.Color.White
		Me._EnergyDisplay_1.Size = New System.Drawing.Size(25, 17)
		Me._EnergyDisplay_1.Location = New System.Drawing.Point(424, 56)
		Me._EnergyDisplay_1.TabIndex = 74
		Me._EnergyDisplay_1.TabStop = False
		Me._EnergyDisplay_1.Visible = False
		Me._EnergyDisplay_1.Dock = System.Windows.Forms.DockStyle.None
		Me._EnergyDisplay_1.CausesValidation = True
		Me._EnergyDisplay_1.Enabled = True
		Me._EnergyDisplay_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._EnergyDisplay_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._EnergyDisplay_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._EnergyDisplay_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._EnergyDisplay_1.Name = "_EnergyDisplay_1"
		Me.NumerOfCrononsDisplay.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me.NumerOfCrononsDisplay.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NumerOfCrononsDisplay.ForeColor = System.Drawing.Color.White
		Me.NumerOfCrononsDisplay.Size = New System.Drawing.Size(57, 17)
		Me.NumerOfCrononsDisplay.Location = New System.Drawing.Point(480, 336)
		Me.NumerOfCrononsDisplay.TabIndex = 72
		Me.NumerOfCrononsDisplay.TabStop = False
		Me.NumerOfCrononsDisplay.Dock = System.Windows.Forms.DockStyle.None
		Me.NumerOfCrononsDisplay.CausesValidation = True
		Me.NumerOfCrononsDisplay.Enabled = True
		Me.NumerOfCrononsDisplay.Cursor = System.Windows.Forms.Cursors.Default
		Me.NumerOfCrononsDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.NumerOfCrononsDisplay.Visible = True
		Me.NumerOfCrononsDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.NumerOfCrononsDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.NumerOfCrononsDisplay.Name = "NumerOfCrononsDisplay"
		Me.Arena.BackColor = System.Drawing.Color.White
		Me.Arena.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Arena.Size = New System.Drawing.Size(302, 302)
		Me.Arena.Location = New System.Drawing.Point(8, 32)
		Me.Arena.TabIndex = 71
		Me.Arena.TabStop = False
		Me.Arena.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Arena.Dock = System.Windows.Forms.DockStyle.None
		Me.Arena.CausesValidation = True
		Me.Arena.Enabled = True
		Me.Arena.Cursor = System.Windows.Forms.Cursors.Default
		Me.Arena.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Arena.Visible = True
		Me.Arena.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Arena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Arena.Name = "Arena"
		Me.CPRTimer.Enabled = False
		Me.CPRTimer.Interval = 1000
		Me.CommonDialog3Save.Filter = "Robot|*.RWR|"
		Me.CommonDialog2Open.Title = "Delete Robot"
		Me.CommonDialog2Open.Filter = "Robots|*.RWR|All Files|*.*|"
		Me.CommonDialog1Open.DefaultExt = "rwr"
		Me.CommonDialog1Open.Title = "Please choose a Robot"
		Me.CommonDialog1Open.Filter = "Robots|*.RWR|All Files|*.*|"
		Me.BattleHaltButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.BattleHaltButton.BackColor = System.Drawing.Color.FromARGB(132, 194, 219)
		Me.BattleHaltButton.Text = "Battle"
		Me.BattleHaltButton.CausesValidation = False
		Me.AcceptButton = Me.BattleHaltButton
		Me.BattleHaltButton.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BattleHaltButton.Size = New System.Drawing.Size(81, 33)
		Me.BattleHaltButton.Location = New System.Drawing.Point(320, 336)
		Me.BattleHaltButton.TabIndex = 1
		Me.BattleHaltButton.Enabled = True
		Me.BattleHaltButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.BattleHaltButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.BattleHaltButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.BattleHaltButton.TabStop = True
		Me.BattleHaltButton.Name = "BattleHaltButton"
		Me.R1Icon.BackColor = System.Drawing.Color.White
		Me.R1Icon.ForeColor = System.Drawing.SystemColors.WindowText
		Me.R1Icon.Size = New System.Drawing.Size(34, 34)
		Me.R1Icon.Location = New System.Drawing.Point(328, 32)
		Me.R1Icon.TabIndex = 0
		Me.R1Icon.TabStop = False
		Me.R1Icon.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.R1Icon.Dock = System.Windows.Forms.DockStyle.None
		Me.R1Icon.CausesValidation = True
		Me.R1Icon.Enabled = True
		Me.R1Icon.Cursor = System.Windows.Forms.Cursors.Default
		Me.R1Icon.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.R1Icon.Visible = True
		Me.R1Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.R1Icon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.R1Icon.Name = "R1Icon"
		Me.R2Icon.BackColor = System.Drawing.SystemColors.Window
		Me.R2Icon.ForeColor = System.Drawing.SystemColors.WindowText
		Me.R2Icon.Size = New System.Drawing.Size(34, 34)
		Me.R2Icon.Location = New System.Drawing.Point(328, 80)
		Me.R2Icon.TabIndex = 3
		Me.R2Icon.TabStop = False
		Me.R2Icon.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.R2Icon.Dock = System.Windows.Forms.DockStyle.None
		Me.R2Icon.CausesValidation = True
		Me.R2Icon.Enabled = True
		Me.R2Icon.Cursor = System.Windows.Forms.Cursors.Default
		Me.R2Icon.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.R2Icon.Visible = True
		Me.R2Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.R2Icon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.R2Icon.Name = "R2Icon"
		Me.R3Icon.BackColor = System.Drawing.SystemColors.Window
		Me.R3Icon.ForeColor = System.Drawing.SystemColors.WindowText
		Me.R3Icon.Size = New System.Drawing.Size(34, 34)
		Me.R3Icon.Location = New System.Drawing.Point(328, 128)
		Me.R3Icon.TabIndex = 4
		Me.R3Icon.TabStop = False
		Me.R3Icon.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.R3Icon.Dock = System.Windows.Forms.DockStyle.None
		Me.R3Icon.CausesValidation = True
		Me.R3Icon.Enabled = True
		Me.R3Icon.Cursor = System.Windows.Forms.Cursors.Default
		Me.R3Icon.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.R3Icon.Visible = True
		Me.R3Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.R3Icon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.R3Icon.Name = "R3Icon"
		Me.R4Icon.BackColor = System.Drawing.SystemColors.Window
		Me.R4Icon.ForeColor = System.Drawing.SystemColors.WindowText
		Me.R4Icon.Size = New System.Drawing.Size(34, 34)
		Me.R4Icon.Location = New System.Drawing.Point(328, 176)
		Me.R4Icon.TabIndex = 5
		Me.R4Icon.TabStop = False
		Me.R4Icon.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.R4Icon.Dock = System.Windows.Forms.DockStyle.None
		Me.R4Icon.CausesValidation = True
		Me.R4Icon.Enabled = True
		Me.R4Icon.Cursor = System.Windows.Forms.Cursors.Default
		Me.R4Icon.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.R4Icon.Visible = True
		Me.R4Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.R4Icon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.R4Icon.Name = "R4Icon"
		Me.R5Icon.BackColor = System.Drawing.SystemColors.Window
		Me.R5Icon.ForeColor = System.Drawing.SystemColors.WindowText
		Me.R5Icon.Size = New System.Drawing.Size(34, 34)
		Me.R5Icon.Location = New System.Drawing.Point(328, 224)
		Me.R5Icon.TabIndex = 6
		Me.R5Icon.TabStop = False
		Me.R5Icon.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.R5Icon.Dock = System.Windows.Forms.DockStyle.None
		Me.R5Icon.CausesValidation = True
		Me.R5Icon.Enabled = True
		Me.R5Icon.Cursor = System.Windows.Forms.Cursors.Default
		Me.R5Icon.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.R5Icon.Visible = True
		Me.R5Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.R5Icon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.R5Icon.Name = "R5Icon"
		Me.R6Icon.BackColor = System.Drawing.SystemColors.Window
		Me.R6Icon.ForeColor = System.Drawing.SystemColors.WindowText
		Me.R6Icon.Size = New System.Drawing.Size(34, 34)
		Me.R6Icon.Location = New System.Drawing.Point(328, 272)
		Me.R6Icon.TabIndex = 7
		Me.R6Icon.TabStop = False
		Me.R6Icon.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.R6Icon.Dock = System.Windows.Forms.DockStyle.None
		Me.R6Icon.CausesValidation = True
		Me.R6Icon.Enabled = True
		Me.R6Icon.Cursor = System.Windows.Forms.Cursors.Default
		Me.R6Icon.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.R6Icon.Visible = True
		Me.R6Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.R6Icon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.R6Icon.Name = "R6Icon"
		Me.Image2.Size = New System.Drawing.Size(223, 52)
		Me.Image2.Location = New System.Drawing.Point(16, 339)
		Me.Image2.Image = CType(resources.GetObject("Image2.Image"), System.Drawing.Image)
		Me.Image2.Enabled = True
		Me.Image2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image2.Visible = True
		Me.Image2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Image2.Name = "Image2"
		Me._TeamLabel_6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._TeamLabel_6.BackColor = System.Drawing.Color.Black
		Me._TeamLabel_6.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._TeamLabel_6.Size = New System.Drawing.Size(34, 14)
		Me._TeamLabel_6.Location = New System.Drawing.Point(592, 304)
		Me._TeamLabel_6.TabIndex = 61
		Me._TeamLabel_6.Visible = False
		Me._TeamLabel_6.Enabled = True
		Me._TeamLabel_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._TeamLabel_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._TeamLabel_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TeamLabel_6.UseMnemonic = True
		Me._TeamLabel_6.AutoSize = False
		Me._TeamLabel_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._TeamLabel_6.Name = "_TeamLabel_6"
		Me._TeamLabel_5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._TeamLabel_5.BackColor = System.Drawing.Color.Black
		Me._TeamLabel_5.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._TeamLabel_5.Size = New System.Drawing.Size(34, 14)
		Me._TeamLabel_5.Location = New System.Drawing.Point(592, 256)
		Me._TeamLabel_5.TabIndex = 60
		Me._TeamLabel_5.Visible = False
		Me._TeamLabel_5.Enabled = True
		Me._TeamLabel_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._TeamLabel_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._TeamLabel_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TeamLabel_5.UseMnemonic = True
		Me._TeamLabel_5.AutoSize = False
		Me._TeamLabel_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._TeamLabel_5.Name = "_TeamLabel_5"
		Me._TeamLabel_4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._TeamLabel_4.BackColor = System.Drawing.Color.Black
		Me._TeamLabel_4.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._TeamLabel_4.Size = New System.Drawing.Size(34, 14)
		Me._TeamLabel_4.Location = New System.Drawing.Point(592, 208)
		Me._TeamLabel_4.TabIndex = 59
		Me._TeamLabel_4.Visible = False
		Me._TeamLabel_4.Enabled = True
		Me._TeamLabel_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._TeamLabel_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._TeamLabel_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TeamLabel_4.UseMnemonic = True
		Me._TeamLabel_4.AutoSize = False
		Me._TeamLabel_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._TeamLabel_4.Name = "_TeamLabel_4"
		Me._TeamLabel_3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._TeamLabel_3.BackColor = System.Drawing.Color.Black
		Me._TeamLabel_3.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._TeamLabel_3.Size = New System.Drawing.Size(34, 14)
		Me._TeamLabel_3.Location = New System.Drawing.Point(592, 160)
		Me._TeamLabel_3.TabIndex = 58
		Me._TeamLabel_3.Visible = False
		Me._TeamLabel_3.Enabled = True
		Me._TeamLabel_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._TeamLabel_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._TeamLabel_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TeamLabel_3.UseMnemonic = True
		Me._TeamLabel_3.AutoSize = False
		Me._TeamLabel_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._TeamLabel_3.Name = "_TeamLabel_3"
		Me._TeamLabel_2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._TeamLabel_2.BackColor = System.Drawing.Color.Black
		Me._TeamLabel_2.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._TeamLabel_2.Size = New System.Drawing.Size(34, 14)
		Me._TeamLabel_2.Location = New System.Drawing.Point(592, 112)
		Me._TeamLabel_2.TabIndex = 57
		Me._TeamLabel_2.Visible = False
		Me._TeamLabel_2.Enabled = True
		Me._TeamLabel_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._TeamLabel_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._TeamLabel_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TeamLabel_2.UseMnemonic = True
		Me._TeamLabel_2.AutoSize = False
		Me._TeamLabel_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._TeamLabel_2.Name = "_TeamLabel_2"
		Me._TeamLabel_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._TeamLabel_1.BackColor = System.Drawing.Color.Black
		Me._TeamLabel_1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._TeamLabel_1.ForeColor = System.Drawing.Color.Black
		Me._TeamLabel_1.Size = New System.Drawing.Size(34, 14)
		Me._TeamLabel_1.Location = New System.Drawing.Point(592, 64)
		Me._TeamLabel_1.TabIndex = 56
		Me._TeamLabel_1.Visible = False
		Me._TeamLabel_1.Enabled = True
		Me._TeamLabel_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._TeamLabel_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TeamLabel_1.UseMnemonic = True
		Me._TeamLabel_1.AutoSize = False
		Me._TeamLabel_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._TeamLabel_1.Name = "_TeamLabel_1"
		Me._RobotDead_6.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._RobotDead_6.Text = "Dead - Time:"
		Me._RobotDead_6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._RobotDead_6.ForeColor = System.Drawing.Color.White
		Me._RobotDead_6.Size = New System.Drawing.Size(153, 17)
		Me._RobotDead_6.Location = New System.Drawing.Point(376, 296)
		Me._RobotDead_6.TabIndex = 67
		Me._RobotDead_6.Visible = False
		Me._RobotDead_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._RobotDead_6.Enabled = True
		Me._RobotDead_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._RobotDead_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._RobotDead_6.UseMnemonic = True
		Me._RobotDead_6.AutoSize = False
		Me._RobotDead_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._RobotDead_6.Name = "_RobotDead_6"
		Me._RobotDead_5.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._RobotDead_5.Text = "Dead - Time:"
		Me._RobotDead_5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._RobotDead_5.ForeColor = System.Drawing.Color.White
		Me._RobotDead_5.Size = New System.Drawing.Size(153, 17)
		Me._RobotDead_5.Location = New System.Drawing.Point(376, 248)
		Me._RobotDead_5.TabIndex = 66
		Me._RobotDead_5.Visible = False
		Me._RobotDead_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._RobotDead_5.Enabled = True
		Me._RobotDead_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._RobotDead_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._RobotDead_5.UseMnemonic = True
		Me._RobotDead_5.AutoSize = False
		Me._RobotDead_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._RobotDead_5.Name = "_RobotDead_5"
		Me._RobotDead_4.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._RobotDead_4.Text = "Dead - Time:"
		Me._RobotDead_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._RobotDead_4.ForeColor = System.Drawing.Color.White
		Me._RobotDead_4.Size = New System.Drawing.Size(153, 17)
		Me._RobotDead_4.Location = New System.Drawing.Point(376, 200)
		Me._RobotDead_4.TabIndex = 65
		Me._RobotDead_4.Visible = False
		Me._RobotDead_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._RobotDead_4.Enabled = True
		Me._RobotDead_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._RobotDead_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._RobotDead_4.UseMnemonic = True
		Me._RobotDead_4.AutoSize = False
		Me._RobotDead_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._RobotDead_4.Name = "_RobotDead_4"
		Me._RobotDead_3.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._RobotDead_3.Text = "Dead - Time:"
		Me._RobotDead_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._RobotDead_3.ForeColor = System.Drawing.Color.White
		Me._RobotDead_3.Size = New System.Drawing.Size(153, 17)
		Me._RobotDead_3.Location = New System.Drawing.Point(376, 152)
		Me._RobotDead_3.TabIndex = 64
		Me._RobotDead_3.Visible = False
		Me._RobotDead_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._RobotDead_3.Enabled = True
		Me._RobotDead_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._RobotDead_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._RobotDead_3.UseMnemonic = True
		Me._RobotDead_3.AutoSize = False
		Me._RobotDead_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._RobotDead_3.Name = "_RobotDead_3"
		Me._RobotDead_2.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._RobotDead_2.Text = "Dead - Time:"
		Me._RobotDead_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._RobotDead_2.ForeColor = System.Drawing.Color.White
		Me._RobotDead_2.Size = New System.Drawing.Size(153, 17)
		Me._RobotDead_2.Location = New System.Drawing.Point(376, 104)
		Me._RobotDead_2.TabIndex = 63
		Me._RobotDead_2.Visible = False
		Me._RobotDead_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._RobotDead_2.Enabled = True
		Me._RobotDead_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._RobotDead_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._RobotDead_2.UseMnemonic = True
		Me._RobotDead_2.AutoSize = False
		Me._RobotDead_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._RobotDead_2.Name = "_RobotDead_2"
		Me._RobotDead_1.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me._RobotDead_1.Text = "Dead - Time:"
		Me._RobotDead_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._RobotDead_1.ForeColor = System.Drawing.Color.White
		Me._RobotDead_1.Size = New System.Drawing.Size(153, 17)
		Me._RobotDead_1.Location = New System.Drawing.Point(376, 56)
		Me._RobotDead_1.TabIndex = 62
		Me._RobotDead_1.Visible = False
		Me._RobotDead_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._RobotDead_1.Enabled = True
		Me._RobotDead_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._RobotDead_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._RobotDead_1.UseMnemonic = True
		Me._RobotDead_1.AutoSize = False
		Me._RobotDead_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._RobotDead_1.Name = "_RobotDead_1"
		Me.Chronors.Text = "Chronons:"
		Me.Chronors.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Chronors.ForeColor = System.Drawing.Color.White
		Me.Chronors.Size = New System.Drawing.Size(73, 17)
		Me.Chronors.Location = New System.Drawing.Point(408, 336)
		Me.Chronors.TabIndex = 73
		Me.Chronors.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Chronors.BackColor = System.Drawing.Color.Transparent
		Me.Chronors.Enabled = True
		Me.Chronors.Cursor = System.Windows.Forms.Cursors.Default
		Me.Chronors.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Chronors.UseMnemonic = True
		Me.Chronors.Visible = True
		Me.Chronors.AutoSize = False
		Me.Chronors.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Chronors.Name = "Chronors"
		Me.ReplayText.Text = "Replay"
		Me.ReplayText.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ReplayText.ForeColor = System.Drawing.Color.White
		Me.ReplayText.Size = New System.Drawing.Size(41, 17)
		Me.ReplayText.Location = New System.Drawing.Point(576, 352)
		Me.ReplayText.TabIndex = 70
		Me.ReplayText.Visible = False
		Me.ReplayText.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.ReplayText.BackColor = System.Drawing.Color.Transparent
		Me.ReplayText.Enabled = True
		Me.ReplayText.Cursor = System.Windows.Forms.Cursors.Default
		Me.ReplayText.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ReplayText.UseMnemonic = True
		Me.ReplayText.AutoSize = False
		Me.ReplayText.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.ReplayText.Name = "ReplayText"
		Me._Image1_5.Size = New System.Drawing.Size(47, 24)
		Me._Image1_5.Location = New System.Drawing.Point(584, 242)
		Me._Image1_5.Image = CType(resources.GetObject("_Image1_5.Image"), System.Drawing.Image)
		Me._Image1_5.Visible = False
		Me._Image1_5.Enabled = True
		Me._Image1_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._Image1_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._Image1_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Image1_5.Name = "_Image1_5"
		Me._Image1_4.Size = New System.Drawing.Size(47, 24)
		Me._Image1_4.Location = New System.Drawing.Point(584, 194)
		Me._Image1_4.Image = CType(resources.GetObject("_Image1_4.Image"), System.Drawing.Image)
		Me._Image1_4.Visible = False
		Me._Image1_4.Enabled = True
		Me._Image1_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._Image1_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._Image1_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Image1_4.Name = "_Image1_4"
		Me._Image1_3.Size = New System.Drawing.Size(47, 24)
		Me._Image1_3.Location = New System.Drawing.Point(584, 146)
		Me._Image1_3.Image = CType(resources.GetObject("_Image1_3.Image"), System.Drawing.Image)
		Me._Image1_3.Visible = False
		Me._Image1_3.Enabled = True
		Me._Image1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Image1_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._Image1_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Image1_3.Name = "_Image1_3"
		Me._Image1_2.Size = New System.Drawing.Size(47, 24)
		Me._Image1_2.Location = New System.Drawing.Point(584, 98)
		Me._Image1_2.Image = CType(resources.GetObject("_Image1_2.Image"), System.Drawing.Image)
		Me._Image1_2.Visible = False
		Me._Image1_2.Enabled = True
		Me._Image1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Image1_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._Image1_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Image1_2.Name = "_Image1_2"
		Me._Image1_1.Size = New System.Drawing.Size(47, 24)
		Me._Image1_1.Location = New System.Drawing.Point(584, 50)
		Me._Image1_1.Image = CType(resources.GetObject("_Image1_1.Image"), System.Drawing.Image)
		Me._Image1_1.Visible = False
		Me._Image1_1.Enabled = True
		Me._Image1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Image1_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._Image1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Image1_1.Name = "_Image1_1"
		Me._Image1_6.Size = New System.Drawing.Size(47, 24)
		Me._Image1_6.Location = New System.Drawing.Point(584, 290)
		Me._Image1_6.Image = CType(resources.GetObject("_Image1_6.Image"), System.Drawing.Image)
		Me._Image1_6.Visible = False
		Me._Image1_6.Enabled = True
		Me._Image1_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._Image1_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._Image1_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Image1_6.Name = "_Image1_6"
		Me.CPRLabel.BackColor = System.Drawing.Color.Transparent
		Me.CPRLabel.ForeColor = System.Drawing.Color.White
		Me.CPRLabel.Size = New System.Drawing.Size(64, 17)
		Me.CPRLabel.Location = New System.Drawing.Point(456, 360)
		Me.CPRLabel.TabIndex = 69
		Me.CPRLabel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CPRLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.CPRLabel.Enabled = True
		Me.CPRLabel.Cursor = System.Windows.Forms.Cursors.Default
		Me.CPRLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CPRLabel.UseMnemonic = True
		Me.CPRLabel.Visible = True
		Me.CPRLabel.AutoSize = False
		Me.CPRLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CPRLabel.Name = "CPRLabel"
		Me.PerSecond.BackColor = System.Drawing.Color.Transparent
		Me.PerSecond.Text = "/second"
		Me.PerSecond.ForeColor = System.Drawing.Color.White
		Me.PerSecond.Size = New System.Drawing.Size(41, 17)
		Me.PerSecond.Location = New System.Drawing.Point(408, 360)
		Me.PerSecond.TabIndex = 68
		Me.PerSecond.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PerSecond.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.PerSecond.Enabled = True
		Me.PerSecond.Cursor = System.Windows.Forms.Cursors.Default
		Me.PerSecond.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.PerSecond.UseMnemonic = True
		Me.PerSecond.Visible = True
		Me.PerSecond.AutoSize = False
		Me.PerSecond.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.PerSecond.Name = "PerSecond"
		Me.Robot1.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me.Robot1.Text = "No Robot Selected"
		Me.Robot1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Robot1.ForeColor = System.Drawing.Color.White
		Me.Robot1.Size = New System.Drawing.Size(209, 20)
		Me.Robot1.Location = New System.Drawing.Point(376, 32)
		Me.Robot1.TabIndex = 49
		Me.Robot1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Robot1.Enabled = True
		Me.Robot1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Robot1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Robot1.UseMnemonic = True
		Me.Robot1.Visible = True
		Me.Robot1.AutoSize = False
		Me.Robot1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Robot1.Name = "Robot1"
		Me._DR_6.Text = "0"
		Me._DR_6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._DR_6.ForeColor = System.Drawing.Color.White
		Me._DR_6.Size = New System.Drawing.Size(25, 17)
		Me._DR_6.Location = New System.Drawing.Point(504, 296)
		Me._DR_6.TabIndex = 55
		Me._DR_6.Visible = False
		Me._DR_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._DR_6.BackColor = System.Drawing.Color.Transparent
		Me._DR_6.Enabled = True
		Me._DR_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._DR_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._DR_6.UseMnemonic = True
		Me._DR_6.AutoSize = False
		Me._DR_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._DR_6.Name = "_DR_6"
		Me.Robot6.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me.Robot6.Text = "No Robot Selected"
		Me.Robot6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Robot6.ForeColor = System.Drawing.Color.White
		Me.Robot6.Size = New System.Drawing.Size(209, 20)
		Me.Robot6.Location = New System.Drawing.Point(376, 272)
		Me.Robot6.TabIndex = 54
		Me.Robot6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Robot6.Enabled = True
		Me.Robot6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Robot6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Robot6.UseMnemonic = True
		Me.Robot6.Visible = True
		Me.Robot6.AutoSize = False
		Me.Robot6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Robot6.Name = "Robot6"
		Me.Robot5.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me.Robot5.Text = "No Robot Selected"
		Me.Robot5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Robot5.ForeColor = System.Drawing.Color.White
		Me.Robot5.Size = New System.Drawing.Size(209, 20)
		Me.Robot5.Location = New System.Drawing.Point(376, 224)
		Me.Robot5.TabIndex = 53
		Me.Robot5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Robot5.Enabled = True
		Me.Robot5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Robot5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Robot5.UseMnemonic = True
		Me.Robot5.Visible = True
		Me.Robot5.AutoSize = False
		Me.Robot5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Robot5.Name = "Robot5"
		Me.Robot4.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me.Robot4.Text = "No Robot Selected"
		Me.Robot4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Robot4.ForeColor = System.Drawing.Color.White
		Me.Robot4.Size = New System.Drawing.Size(209, 20)
		Me.Robot4.Location = New System.Drawing.Point(376, 176)
		Me.Robot4.TabIndex = 52
		Me.Robot4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Robot4.Enabled = True
		Me.Robot4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Robot4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Robot4.UseMnemonic = True
		Me.Robot4.Visible = True
		Me.Robot4.AutoSize = False
		Me.Robot4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Robot4.Name = "Robot4"
		Me.Robot3.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me.Robot3.Text = "No Robot Selected"
		Me.Robot3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Robot3.ForeColor = System.Drawing.Color.White
		Me.Robot3.Size = New System.Drawing.Size(209, 20)
		Me.Robot3.Location = New System.Drawing.Point(376, 128)
		Me.Robot3.TabIndex = 51
		Me.Robot3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Robot3.Enabled = True
		Me.Robot3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Robot3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Robot3.UseMnemonic = True
		Me.Robot3.Visible = True
		Me.Robot3.AutoSize = False
		Me.Robot3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Robot3.Name = "Robot3"
		Me.Robot2.BackColor = System.Drawing.Color.FromARGB(30, 81, 123)
		Me.Robot2.Text = "No Robot Selected"
		Me.Robot2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Robot2.ForeColor = System.Drawing.Color.White
		Me.Robot2.Size = New System.Drawing.Size(209, 20)
		Me.Robot2.Location = New System.Drawing.Point(376, 80)
		Me.Robot2.TabIndex = 50
		Me.Robot2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Robot2.Enabled = True
		Me.Robot2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Robot2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Robot2.UseMnemonic = True
		Me.Robot2.Visible = True
		Me.Robot2.AutoSize = False
		Me.Robot2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Robot2.Name = "Robot2"
		Me.Load6.BackColor = System.Drawing.Color.FromARGB(3, 46, 78)
		Me.Load6.Text = "Load"
		Me.Load6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Load6.ForeColor = System.Drawing.Color.White
		Me.Load6.Size = New System.Drawing.Size(33, 17)
		Me.Load6.Location = New System.Drawing.Point(592, 272)
		Me.Load6.TabIndex = 48
		Me.Load6.Visible = False
		Me.Load6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Load6.Enabled = True
		Me.Load6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Load6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Load6.UseMnemonic = True
		Me.Load6.AutoSize = False
		Me.Load6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Load6.Name = "Load6"
		Me.Load2.BackColor = System.Drawing.Color.FromARGB(3, 46, 78)
		Me.Load2.Text = "Load"
		Me.Load2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Load2.ForeColor = System.Drawing.Color.White
		Me.Load2.Size = New System.Drawing.Size(33, 17)
		Me.Load2.Location = New System.Drawing.Point(592, 80)
		Me.Load2.TabIndex = 47
		Me.Load2.Visible = False
		Me.Load2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Load2.Enabled = True
		Me.Load2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Load2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Load2.UseMnemonic = True
		Me.Load2.AutoSize = False
		Me.Load2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Load2.Name = "Load2"
		Me.Load5.BackColor = System.Drawing.Color.FromARGB(3, 46, 78)
		Me.Load5.Text = "Load"
		Me.Load5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Load5.ForeColor = System.Drawing.Color.White
		Me.Load5.Size = New System.Drawing.Size(33, 17)
		Me.Load5.Location = New System.Drawing.Point(592, 224)
		Me.Load5.TabIndex = 46
		Me.Load5.Visible = False
		Me.Load5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Load5.Enabled = True
		Me.Load5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Load5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Load5.UseMnemonic = True
		Me.Load5.AutoSize = False
		Me.Load5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Load5.Name = "Load5"
		Me.Load3.BackColor = System.Drawing.Color.FromARGB(3, 46, 78)
		Me.Load3.Text = "Load"
		Me.Load3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Load3.ForeColor = System.Drawing.Color.White
		Me.Load3.Size = New System.Drawing.Size(33, 17)
		Me.Load3.Location = New System.Drawing.Point(592, 128)
		Me.Load3.TabIndex = 45
		Me.Load3.Visible = False
		Me.Load3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Load3.Enabled = True
		Me.Load3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Load3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Load3.UseMnemonic = True
		Me.Load3.AutoSize = False
		Me.Load3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Load3.Name = "Load3"
		Me.Load4.BackColor = System.Drawing.Color.FromARGB(3, 46, 78)
		Me.Load4.Text = "Load"
		Me.Load4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Load4.ForeColor = System.Drawing.Color.White
		Me.Load4.Size = New System.Drawing.Size(33, 17)
		Me.Load4.Location = New System.Drawing.Point(592, 176)
		Me.Load4.TabIndex = 44
		Me.Load4.Visible = False
		Me.Load4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Load4.Enabled = True
		Me.Load4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Load4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Load4.UseMnemonic = True
		Me.Load4.AutoSize = False
		Me.Load4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Load4.Name = "Load4"
		Me.Load1.BackColor = System.Drawing.Color.FromARGB(3, 46, 78)
		Me.Load1.Text = "Load"
		Me.Load1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Load1.ForeColor = System.Drawing.SystemColors.Window
		Me.Load1.Size = New System.Drawing.Size(33, 17)
		Me.Load1.Location = New System.Drawing.Point(592, 32)
		Me.Load1.TabIndex = 43
		Me.Load1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Load1.Enabled = True
		Me.Load1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Load1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Load1.UseMnemonic = True
		Me.Load1.Visible = True
		Me.Load1.AutoSize = False
		Me.Load1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Load1.Name = "Load1"
		Me.PR6.Text = "0"
		Me.PR6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PR6.ForeColor = System.Drawing.Color.White
		Me.PR6.Size = New System.Drawing.Size(27, 17)
		Me.PR6.Location = New System.Drawing.Point(568, 296)
		Me.PR6.TabIndex = 42
		Me.PR6.Visible = False
		Me.PR6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.PR6.BackColor = System.Drawing.Color.Transparent
		Me.PR6.Enabled = True
		Me.PR6.Cursor = System.Windows.Forms.Cursors.Default
		Me.PR6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.PR6.UseMnemonic = True
		Me.PR6.AutoSize = False
		Me.PR6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.PR6.Name = "PR6"
		Me.PR5.Text = "0"
		Me.PR5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PR5.ForeColor = System.Drawing.Color.White
		Me.PR5.Size = New System.Drawing.Size(27, 17)
		Me.PR5.Location = New System.Drawing.Point(568, 248)
		Me.PR5.TabIndex = 41
		Me.PR5.Visible = False
		Me.PR5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.PR5.BackColor = System.Drawing.Color.Transparent
		Me.PR5.Enabled = True
		Me.PR5.Cursor = System.Windows.Forms.Cursors.Default
		Me.PR5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.PR5.UseMnemonic = True
		Me.PR5.AutoSize = False
		Me.PR5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.PR5.Name = "PR5"
		Me.PR4.Text = "0"
		Me.PR4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PR4.ForeColor = System.Drawing.Color.White
		Me.PR4.Size = New System.Drawing.Size(27, 17)
		Me.PR4.Location = New System.Drawing.Point(568, 200)
		Me.PR4.TabIndex = 40
		Me.PR4.Visible = False
		Me.PR4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.PR4.BackColor = System.Drawing.Color.Transparent
		Me.PR4.Enabled = True
		Me.PR4.Cursor = System.Windows.Forms.Cursors.Default
		Me.PR4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.PR4.UseMnemonic = True
		Me.PR4.AutoSize = False
		Me.PR4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.PR4.Name = "PR4"
		Me.PR3.Text = "0"
		Me.PR3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PR3.ForeColor = System.Drawing.Color.White
		Me.PR3.Size = New System.Drawing.Size(27, 17)
		Me.PR3.Location = New System.Drawing.Point(568, 152)
		Me.PR3.TabIndex = 39
		Me.PR3.Visible = False
		Me.PR3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.PR3.BackColor = System.Drawing.Color.Transparent
		Me.PR3.Enabled = True
		Me.PR3.Cursor = System.Windows.Forms.Cursors.Default
		Me.PR3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.PR3.UseMnemonic = True
		Me.PR3.AutoSize = False
		Me.PR3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.PR3.Name = "PR3"
		Me.PR2.Text = "0"
		Me.PR2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PR2.ForeColor = System.Drawing.Color.White
		Me.PR2.Size = New System.Drawing.Size(27, 17)
		Me.PR2.Location = New System.Drawing.Point(568, 104)
		Me.PR2.TabIndex = 38
		Me.PR2.Visible = False
		Me.PR2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.PR2.BackColor = System.Drawing.Color.Transparent
		Me.PR2.Enabled = True
		Me.PR2.Cursor = System.Windows.Forms.Cursors.Default
		Me.PR2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.PR2.UseMnemonic = True
		Me.PR2.AutoSize = False
		Me.PR2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.PR2.Name = "PR2"
		Me.PR1.Text = "0"
		Me.PR1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PR1.ForeColor = System.Drawing.Color.White
		Me.PR1.Size = New System.Drawing.Size(27, 17)
		Me.PR1.Location = New System.Drawing.Point(568, 56)
		Me.PR1.TabIndex = 37
		Me.PR1.Visible = False
		Me.PR1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.PR1.BackColor = System.Drawing.Color.Transparent
		Me.PR1.Enabled = True
		Me.PR1.Cursor = System.Windows.Forms.Cursors.Default
		Me.PR1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.PR1.UseMnemonic = True
		Me.PR1.AutoSize = False
		Me.PR1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.PR1.Name = "PR1"
		Me._DR_5.Text = "0"
		Me._DR_5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._DR_5.ForeColor = System.Drawing.Color.White
		Me._DR_5.Size = New System.Drawing.Size(25, 17)
		Me._DR_5.Location = New System.Drawing.Point(504, 248)
		Me._DR_5.TabIndex = 36
		Me._DR_5.Visible = False
		Me._DR_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._DR_5.BackColor = System.Drawing.Color.Transparent
		Me._DR_5.Enabled = True
		Me._DR_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._DR_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._DR_5.UseMnemonic = True
		Me._DR_5.AutoSize = False
		Me._DR_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._DR_5.Name = "_DR_5"
		Me._DR_4.Text = "0"
		Me._DR_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._DR_4.ForeColor = System.Drawing.Color.White
		Me._DR_4.Size = New System.Drawing.Size(25, 17)
		Me._DR_4.Location = New System.Drawing.Point(504, 200)
		Me._DR_4.TabIndex = 35
		Me._DR_4.Visible = False
		Me._DR_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._DR_4.BackColor = System.Drawing.Color.Transparent
		Me._DR_4.Enabled = True
		Me._DR_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._DR_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._DR_4.UseMnemonic = True
		Me._DR_4.AutoSize = False
		Me._DR_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._DR_4.Name = "_DR_4"
		Me._DR_3.Text = "0"
		Me._DR_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._DR_3.ForeColor = System.Drawing.Color.White
		Me._DR_3.Size = New System.Drawing.Size(25, 17)
		Me._DR_3.Location = New System.Drawing.Point(504, 152)
		Me._DR_3.TabIndex = 34
		Me._DR_3.Visible = False
		Me._DR_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._DR_3.BackColor = System.Drawing.Color.Transparent
		Me._DR_3.Enabled = True
		Me._DR_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._DR_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._DR_3.UseMnemonic = True
		Me._DR_3.AutoSize = False
		Me._DR_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._DR_3.Name = "_DR_3"
		Me._DR_2.Text = "0"
		Me._DR_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._DR_2.ForeColor = System.Drawing.Color.White
		Me._DR_2.Size = New System.Drawing.Size(25, 17)
		Me._DR_2.Location = New System.Drawing.Point(504, 104)
		Me._DR_2.TabIndex = 33
		Me._DR_2.Visible = False
		Me._DR_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._DR_2.BackColor = System.Drawing.Color.Transparent
		Me._DR_2.Enabled = True
		Me._DR_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._DR_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._DR_2.UseMnemonic = True
		Me._DR_2.AutoSize = False
		Me._DR_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._DR_2.Name = "_DR_2"
		Me._DR_1.Text = "0"
		Me._DR_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._DR_1.ForeColor = System.Drawing.Color.White
		Me._DR_1.Size = New System.Drawing.Size(25, 17)
		Me._DR_1.Location = New System.Drawing.Point(504, 56)
		Me._DR_1.TabIndex = 32
		Me._DR_1.Visible = False
		Me._DR_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._DR_1.BackColor = System.Drawing.Color.Transparent
		Me._DR_1.Enabled = True
		Me._DR_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._DR_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._DR_1.UseMnemonic = True
		Me._DR_1.AutoSize = False
		Me._DR_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._DR_1.Name = "_DR_1"
		Me._ER_6.Text = "0"
		Me._ER_6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ER_6.ForeColor = System.Drawing.Color.White
		Me._ER_6.Size = New System.Drawing.Size(25, 17)
		Me._ER_6.Location = New System.Drawing.Point(424, 296)
		Me._ER_6.TabIndex = 31
		Me._ER_6.Visible = False
		Me._ER_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._ER_6.BackColor = System.Drawing.Color.Transparent
		Me._ER_6.Enabled = True
		Me._ER_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._ER_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ER_6.UseMnemonic = True
		Me._ER_6.AutoSize = False
		Me._ER_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._ER_6.Name = "_ER_6"
		Me._ER_5.Text = "0"
		Me._ER_5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ER_5.ForeColor = System.Drawing.Color.White
		Me._ER_5.Size = New System.Drawing.Size(25, 17)
		Me._ER_5.Location = New System.Drawing.Point(424, 248)
		Me._ER_5.TabIndex = 30
		Me._ER_5.Visible = False
		Me._ER_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._ER_5.BackColor = System.Drawing.Color.Transparent
		Me._ER_5.Enabled = True
		Me._ER_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._ER_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ER_5.UseMnemonic = True
		Me._ER_5.AutoSize = False
		Me._ER_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._ER_5.Name = "_ER_5"
		Me._ER_4.Text = "0"
		Me._ER_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ER_4.ForeColor = System.Drawing.Color.White
		Me._ER_4.Size = New System.Drawing.Size(25, 17)
		Me._ER_4.Location = New System.Drawing.Point(424, 200)
		Me._ER_4.TabIndex = 29
		Me._ER_4.Visible = False
		Me._ER_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._ER_4.BackColor = System.Drawing.Color.Transparent
		Me._ER_4.Enabled = True
		Me._ER_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._ER_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ER_4.UseMnemonic = True
		Me._ER_4.AutoSize = False
		Me._ER_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._ER_4.Name = "_ER_4"
		Me._ER_3.Text = "0"
		Me._ER_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ER_3.ForeColor = System.Drawing.Color.White
		Me._ER_3.Size = New System.Drawing.Size(25, 17)
		Me._ER_3.Location = New System.Drawing.Point(424, 152)
		Me._ER_3.TabIndex = 28
		Me._ER_3.Visible = False
		Me._ER_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._ER_3.BackColor = System.Drawing.Color.Transparent
		Me._ER_3.Enabled = True
		Me._ER_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._ER_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ER_3.UseMnemonic = True
		Me._ER_3.AutoSize = False
		Me._ER_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._ER_3.Name = "_ER_3"
		Me._ER_2.Text = "0"
		Me._ER_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ER_2.ForeColor = System.Drawing.Color.White
		Me._ER_2.Size = New System.Drawing.Size(25, 17)
		Me._ER_2.Location = New System.Drawing.Point(424, 104)
		Me._ER_2.TabIndex = 27
		Me._ER_2.Visible = False
		Me._ER_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._ER_2.BackColor = System.Drawing.Color.Transparent
		Me._ER_2.Enabled = True
		Me._ER_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._ER_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ER_2.UseMnemonic = True
		Me._ER_2.AutoSize = False
		Me._ER_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._ER_2.Name = "_ER_2"
		Me._ER_1.Text = "0"
		Me._ER_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ER_1.ForeColor = System.Drawing.Color.White
		Me._ER_1.Size = New System.Drawing.Size(25, 17)
		Me._ER_1.Location = New System.Drawing.Point(424, 56)
		Me._ER_1.TabIndex = 26
		Me._ER_1.Visible = False
		Me._ER_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._ER_1.BackColor = System.Drawing.Color.Transparent
		Me._ER_1.Enabled = True
		Me._ER_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._ER_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ER_1.UseMnemonic = True
		Me._ER_1.AutoSize = False
		Me._ER_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._ER_1.Name = "_ER_1"
		Me.Energy6X.BackColor = System.Drawing.Color.Transparent
		Me.Energy6X.Text = "Energy:"
		Me.Energy6X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Energy6X.ForeColor = System.Drawing.Color.White
		Me.Energy6X.Size = New System.Drawing.Size(57, 17)
		Me.Energy6X.Location = New System.Drawing.Point(376, 296)
		Me.Energy6X.TabIndex = 25
		Me.Energy6X.Visible = False
		Me.Energy6X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Energy6X.Enabled = True
		Me.Energy6X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Energy6X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Energy6X.UseMnemonic = True
		Me.Energy6X.AutoSize = False
		Me.Energy6X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Energy6X.Name = "Energy6X"
		Me.Damage6X.BackColor = System.Drawing.Color.Transparent
		Me.Damage6X.Text = "Damage:"
		Me.Damage6X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Damage6X.ForeColor = System.Drawing.Color.White
		Me.Damage6X.Size = New System.Drawing.Size(57, 17)
		Me.Damage6X.Location = New System.Drawing.Point(448, 296)
		Me.Damage6X.TabIndex = 24
		Me.Damage6X.Visible = False
		Me.Damage6X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Damage6X.Enabled = True
		Me.Damage6X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Damage6X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Damage6X.UseMnemonic = True
		Me.Damage6X.AutoSize = False
		Me.Damage6X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Damage6X.Name = "Damage6X"
		Me.Points6X.BackColor = System.Drawing.Color.Transparent
		Me.Points6X.Text = "Points:"
		Me.Points6X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Points6X.ForeColor = System.Drawing.Color.White
		Me.Points6X.Size = New System.Drawing.Size(38, 17)
		Me.Points6X.Location = New System.Drawing.Point(528, 296)
		Me.Points6X.TabIndex = 23
		Me.Points6X.Visible = False
		Me.Points6X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Points6X.Enabled = True
		Me.Points6X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Points6X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Points6X.UseMnemonic = True
		Me.Points6X.AutoSize = False
		Me.Points6X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Points6X.Name = "Points6X"
		Me.Energy5X.BackColor = System.Drawing.Color.Transparent
		Me.Energy5X.Text = "Energy:"
		Me.Energy5X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Energy5X.ForeColor = System.Drawing.Color.White
		Me.Energy5X.Size = New System.Drawing.Size(57, 17)
		Me.Energy5X.Location = New System.Drawing.Point(376, 248)
		Me.Energy5X.TabIndex = 22
		Me.Energy5X.Visible = False
		Me.Energy5X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Energy5X.Enabled = True
		Me.Energy5X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Energy5X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Energy5X.UseMnemonic = True
		Me.Energy5X.AutoSize = False
		Me.Energy5X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Energy5X.Name = "Energy5X"
		Me.Damage5X.BackColor = System.Drawing.Color.Transparent
		Me.Damage5X.Text = "Damage:"
		Me.Damage5X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Damage5X.ForeColor = System.Drawing.Color.White
		Me.Damage5X.Size = New System.Drawing.Size(57, 17)
		Me.Damage5X.Location = New System.Drawing.Point(448, 248)
		Me.Damage5X.TabIndex = 21
		Me.Damage5X.Visible = False
		Me.Damage5X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Damage5X.Enabled = True
		Me.Damage5X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Damage5X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Damage5X.UseMnemonic = True
		Me.Damage5X.AutoSize = False
		Me.Damage5X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Damage5X.Name = "Damage5X"
		Me.Points5X.BackColor = System.Drawing.Color.Transparent
		Me.Points5X.Text = "Points:"
		Me.Points5X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Points5X.ForeColor = System.Drawing.Color.White
		Me.Points5X.Size = New System.Drawing.Size(38, 17)
		Me.Points5X.Location = New System.Drawing.Point(528, 248)
		Me.Points5X.TabIndex = 20
		Me.Points5X.Visible = False
		Me.Points5X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Points5X.Enabled = True
		Me.Points5X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Points5X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Points5X.UseMnemonic = True
		Me.Points5X.AutoSize = False
		Me.Points5X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Points5X.Name = "Points5X"
		Me.Energy4X.BackColor = System.Drawing.Color.Transparent
		Me.Energy4X.Text = "Energy:"
		Me.Energy4X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Energy4X.ForeColor = System.Drawing.Color.White
		Me.Energy4X.Size = New System.Drawing.Size(57, 17)
		Me.Energy4X.Location = New System.Drawing.Point(376, 200)
		Me.Energy4X.TabIndex = 19
		Me.Energy4X.Visible = False
		Me.Energy4X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Energy4X.Enabled = True
		Me.Energy4X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Energy4X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Energy4X.UseMnemonic = True
		Me.Energy4X.AutoSize = False
		Me.Energy4X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Energy4X.Name = "Energy4X"
		Me.Damage4X.BackColor = System.Drawing.Color.Transparent
		Me.Damage4X.Text = "Damage:"
		Me.Damage4X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Damage4X.ForeColor = System.Drawing.Color.White
		Me.Damage4X.Size = New System.Drawing.Size(57, 17)
		Me.Damage4X.Location = New System.Drawing.Point(448, 200)
		Me.Damage4X.TabIndex = 18
		Me.Damage4X.Visible = False
		Me.Damage4X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Damage4X.Enabled = True
		Me.Damage4X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Damage4X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Damage4X.UseMnemonic = True
		Me.Damage4X.AutoSize = False
		Me.Damage4X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Damage4X.Name = "Damage4X"
		Me.Points4X.BackColor = System.Drawing.Color.Transparent
		Me.Points4X.Text = "Points:"
		Me.Points4X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Points4X.ForeColor = System.Drawing.Color.White
		Me.Points4X.Size = New System.Drawing.Size(38, 17)
		Me.Points4X.Location = New System.Drawing.Point(528, 200)
		Me.Points4X.TabIndex = 17
		Me.Points4X.Visible = False
		Me.Points4X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Points4X.Enabled = True
		Me.Points4X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Points4X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Points4X.UseMnemonic = True
		Me.Points4X.AutoSize = False
		Me.Points4X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Points4X.Name = "Points4X"
		Me.Energy3X.BackColor = System.Drawing.Color.Transparent
		Me.Energy3X.Text = "Energy:"
		Me.Energy3X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Energy3X.ForeColor = System.Drawing.Color.White
		Me.Energy3X.Size = New System.Drawing.Size(57, 17)
		Me.Energy3X.Location = New System.Drawing.Point(376, 152)
		Me.Energy3X.TabIndex = 16
		Me.Energy3X.Visible = False
		Me.Energy3X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Energy3X.Enabled = True
		Me.Energy3X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Energy3X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Energy3X.UseMnemonic = True
		Me.Energy3X.AutoSize = False
		Me.Energy3X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Energy3X.Name = "Energy3X"
		Me.Damage3X.BackColor = System.Drawing.Color.Transparent
		Me.Damage3X.Text = "Damage:"
		Me.Damage3X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Damage3X.ForeColor = System.Drawing.Color.White
		Me.Damage3X.Size = New System.Drawing.Size(57, 17)
		Me.Damage3X.Location = New System.Drawing.Point(448, 152)
		Me.Damage3X.TabIndex = 15
		Me.Damage3X.Visible = False
		Me.Damage3X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Damage3X.Enabled = True
		Me.Damage3X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Damage3X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Damage3X.UseMnemonic = True
		Me.Damage3X.AutoSize = False
		Me.Damage3X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Damage3X.Name = "Damage3X"
		Me.Points3X.BackColor = System.Drawing.Color.Transparent
		Me.Points3X.Text = "Points:"
		Me.Points3X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Points3X.ForeColor = System.Drawing.Color.White
		Me.Points3X.Size = New System.Drawing.Size(38, 17)
		Me.Points3X.Location = New System.Drawing.Point(528, 152)
		Me.Points3X.TabIndex = 14
		Me.Points3X.Visible = False
		Me.Points3X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Points3X.Enabled = True
		Me.Points3X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Points3X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Points3X.UseMnemonic = True
		Me.Points3X.AutoSize = False
		Me.Points3X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Points3X.Name = "Points3X"
		Me.Energy2X.BackColor = System.Drawing.Color.Transparent
		Me.Energy2X.Text = "Energy:"
		Me.Energy2X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Energy2X.ForeColor = System.Drawing.Color.White
		Me.Energy2X.Size = New System.Drawing.Size(57, 17)
		Me.Energy2X.Location = New System.Drawing.Point(376, 104)
		Me.Energy2X.TabIndex = 13
		Me.Energy2X.Visible = False
		Me.Energy2X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Energy2X.Enabled = True
		Me.Energy2X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Energy2X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Energy2X.UseMnemonic = True
		Me.Energy2X.AutoSize = False
		Me.Energy2X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Energy2X.Name = "Energy2X"
		Me.Damage2X.BackColor = System.Drawing.Color.Transparent
		Me.Damage2X.Text = "Damage:"
		Me.Damage2X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Damage2X.ForeColor = System.Drawing.Color.White
		Me.Damage2X.Size = New System.Drawing.Size(57, 17)
		Me.Damage2X.Location = New System.Drawing.Point(448, 104)
		Me.Damage2X.TabIndex = 12
		Me.Damage2X.Visible = False
		Me.Damage2X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Damage2X.Enabled = True
		Me.Damage2X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Damage2X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Damage2X.UseMnemonic = True
		Me.Damage2X.AutoSize = False
		Me.Damage2X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Damage2X.Name = "Damage2X"
		Me.Points2X.BackColor = System.Drawing.Color.Transparent
		Me.Points2X.Text = "Points:"
		Me.Points2X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Points2X.ForeColor = System.Drawing.Color.White
		Me.Points2X.Size = New System.Drawing.Size(38, 17)
		Me.Points2X.Location = New System.Drawing.Point(528, 104)
		Me.Points2X.TabIndex = 11
		Me.Points2X.Visible = False
		Me.Points2X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Points2X.Enabled = True
		Me.Points2X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Points2X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Points2X.UseMnemonic = True
		Me.Points2X.AutoSize = False
		Me.Points2X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Points2X.Name = "Points2X"
		Me.Points1X.BackColor = System.Drawing.Color.Transparent
		Me.Points1X.Text = "Points:"
		Me.Points1X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Points1X.ForeColor = System.Drawing.Color.White
		Me.Points1X.Size = New System.Drawing.Size(38, 17)
		Me.Points1X.Location = New System.Drawing.Point(528, 56)
		Me.Points1X.TabIndex = 10
		Me.Points1X.Visible = False
		Me.Points1X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Points1X.Enabled = True
		Me.Points1X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Points1X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Points1X.UseMnemonic = True
		Me.Points1X.AutoSize = False
		Me.Points1X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Points1X.Name = "Points1X"
		Me.Damage1X.BackColor = System.Drawing.Color.Transparent
		Me.Damage1X.Text = "Damage:"
		Me.Damage1X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Damage1X.ForeColor = System.Drawing.Color.White
		Me.Damage1X.Size = New System.Drawing.Size(57, 17)
		Me.Damage1X.Location = New System.Drawing.Point(448, 56)
		Me.Damage1X.TabIndex = 9
		Me.Damage1X.Visible = False
		Me.Damage1X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Damage1X.Enabled = True
		Me.Damage1X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Damage1X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Damage1X.UseMnemonic = True
		Me.Damage1X.AutoSize = False
		Me.Damage1X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Damage1X.Name = "Damage1X"
		Me.Energy1X.BackColor = System.Drawing.Color.Transparent
		Me.Energy1X.Text = "Energy:"
		Me.Energy1X.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Energy1X.ForeColor = System.Drawing.Color.White
		Me.Energy1X.Size = New System.Drawing.Size(57, 17)
		Me.Energy1X.Location = New System.Drawing.Point(376, 56)
		Me.Energy1X.TabIndex = 8
		Me.Energy1X.Visible = False
		Me.Energy1X.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Energy1X.Enabled = True
		Me.Energy1X.Cursor = System.Windows.Forms.Cursors.Default
		Me.Energy1X.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Energy1X.UseMnemonic = True
		Me.Energy1X.AutoSize = False
		Me.Energy1X.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Energy1X.Name = "Energy1X"
		Me.Controls.Add(StopTournament)
		Me.Controls.Add(_EnergyDisplay_6)
		Me.Controls.Add(_EnergyDisplay_5)
		Me.Controls.Add(_EnergyDisplay_4)
		Me.Controls.Add(_EnergyDisplay_3)
		Me.Controls.Add(_EnergyDisplay_2)
		Me.Controls.Add(_EnergyDisplay_1)
		Me.Controls.Add(NumerOfCrononsDisplay)
		Me.Controls.Add(Arena)
		Me.Controls.Add(BattleHaltButton)
		Me.Controls.Add(R1Icon)
		Me.Controls.Add(R2Icon)
		Me.Controls.Add(R3Icon)
		Me.Controls.Add(R4Icon)
		Me.Controls.Add(R5Icon)
		Me.Controls.Add(R6Icon)
		Me.Controls.Add(Image2)
		Me.Controls.Add(_TeamLabel_6)
		Me.Controls.Add(_TeamLabel_5)
		Me.Controls.Add(_TeamLabel_4)
		Me.Controls.Add(_TeamLabel_3)
		Me.Controls.Add(_TeamLabel_2)
		Me.Controls.Add(_TeamLabel_1)
		Me.Controls.Add(_RobotDead_6)
		Me.Controls.Add(_RobotDead_5)
		Me.Controls.Add(_RobotDead_4)
		Me.Controls.Add(_RobotDead_3)
		Me.Controls.Add(_RobotDead_2)
		Me.Controls.Add(_RobotDead_1)
		Me.Controls.Add(Chronors)
		Me.Controls.Add(ReplayText)
		Me.Controls.Add(_Image1_5)
		Me.Controls.Add(_Image1_4)
		Me.Controls.Add(_Image1_3)
		Me.Controls.Add(_Image1_2)
		Me.Controls.Add(_Image1_1)
		Me.Controls.Add(_Image1_6)
		Me.Controls.Add(CPRLabel)
		Me.Controls.Add(PerSecond)
		Me.Controls.Add(Robot1)
		Me.Controls.Add(_DR_6)
		Me.Controls.Add(Robot6)
		Me.Controls.Add(Robot5)
		Me.Controls.Add(Robot4)
		Me.Controls.Add(Robot3)
		Me.Controls.Add(Robot2)
		Me.Controls.Add(Load6)
		Me.Controls.Add(Load2)
		Me.Controls.Add(Load5)
		Me.Controls.Add(Load3)
		Me.Controls.Add(Load4)
		Me.Controls.Add(Load1)
		Me.Controls.Add(PR6)
		Me.Controls.Add(PR5)
		Me.Controls.Add(PR4)
		Me.Controls.Add(PR3)
		Me.Controls.Add(PR2)
		Me.Controls.Add(PR1)
		Me.Controls.Add(_DR_5)
		Me.Controls.Add(_DR_4)
		Me.Controls.Add(_DR_3)
		Me.Controls.Add(_DR_2)
		Me.Controls.Add(_DR_1)
		Me.Controls.Add(_ER_6)
		Me.Controls.Add(_ER_5)
		Me.Controls.Add(_ER_4)
		Me.Controls.Add(_ER_3)
		Me.Controls.Add(_ER_2)
		Me.Controls.Add(_ER_1)
		Me.Controls.Add(Energy6X)
		Me.Controls.Add(Damage6X)
		Me.Controls.Add(Points6X)
		Me.Controls.Add(Energy5X)
		Me.Controls.Add(Damage5X)
		Me.Controls.Add(Points5X)
		Me.Controls.Add(Energy4X)
		Me.Controls.Add(Damage4X)
		Me.Controls.Add(Points4X)
		Me.Controls.Add(Energy3X)
		Me.Controls.Add(Damage3X)
		Me.Controls.Add(Points3X)
		Me.Controls.Add(Energy2X)
		Me.Controls.Add(Damage2X)
		Me.Controls.Add(Points2X)
		Me.Controls.Add(Points1X)
		Me.Controls.Add(Damage1X)
		Me.Controls.Add(Energy1X)
		Me.DR.SetIndex(_DR_6, CType(6, Short))
		Me.DR.SetIndex(_DR_5, CType(5, Short))
		Me.DR.SetIndex(_DR_4, CType(4, Short))
		Me.DR.SetIndex(_DR_3, CType(3, Short))
		Me.DR.SetIndex(_DR_2, CType(2, Short))
		Me.DR.SetIndex(_DR_1, CType(1, Short))
		Me.ER.SetIndex(_ER_6, CType(6, Short))
		Me.ER.SetIndex(_ER_5, CType(5, Short))
		Me.ER.SetIndex(_ER_4, CType(4, Short))
		Me.ER.SetIndex(_ER_3, CType(3, Short))
		Me.ER.SetIndex(_ER_2, CType(2, Short))
		Me.ER.SetIndex(_ER_1, CType(1, Short))
		Me.EnergyDisplay.SetIndex(_EnergyDisplay_6, CType(6, Short))
		Me.EnergyDisplay.SetIndex(_EnergyDisplay_5, CType(5, Short))
		Me.EnergyDisplay.SetIndex(_EnergyDisplay_4, CType(4, Short))
		Me.EnergyDisplay.SetIndex(_EnergyDisplay_3, CType(3, Short))
		Me.EnergyDisplay.SetIndex(_EnergyDisplay_2, CType(2, Short))
		Me.EnergyDisplay.SetIndex(_EnergyDisplay_1, CType(1, Short))
		Me.Image1.SetIndex(_Image1_5, CType(5, Short))
		Me.Image1.SetIndex(_Image1_4, CType(4, Short))
		Me.Image1.SetIndex(_Image1_3, CType(3, Short))
		Me.Image1.SetIndex(_Image1_2, CType(2, Short))
		Me.Image1.SetIndex(_Image1_1, CType(1, Short))
		Me.Image1.SetIndex(_Image1_6, CType(6, Short))
		Me.RobotDead.SetIndex(_RobotDead_6, CType(6, Short))
		Me.RobotDead.SetIndex(_RobotDead_5, CType(5, Short))
		Me.RobotDead.SetIndex(_RobotDead_4, CType(4, Short))
		Me.RobotDead.SetIndex(_RobotDead_3, CType(3, Short))
		Me.RobotDead.SetIndex(_RobotDead_2, CType(2, Short))
		Me.RobotDead.SetIndex(_RobotDead_1, CType(1, Short))
		Me.TeamLabel.SetIndex(_TeamLabel_6, CType(6, Short))
		Me.TeamLabel.SetIndex(_TeamLabel_5, CType(5, Short))
		Me.TeamLabel.SetIndex(_TeamLabel_4, CType(4, Short))
		Me.TeamLabel.SetIndex(_TeamLabel_3, CType(3, Short))
		Me.TeamLabel.SetIndex(_TeamLabel_2, CType(2, Short))
		Me.TeamLabel.SetIndex(_TeamLabel_1, CType(1, Short))
		CType(Me.TeamLabel, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.RobotDead, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.EnergyDisplay, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ER, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DR, System.ComponentModel.ISupportInitialize).EndInit()
		MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me.FileMenu, Me.ViewMenu, Me.ArenaMenu, Me.PreferenceMenu, Me.HelpMenu})
		FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.NewRobot, Me.LoadRobot, Me.Duplicate, Me.SaveAs, Me.Close_Renamed, Me.RenameRobot, Me.DelateRobot, Me.Separator1, Me.Quit})
		ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.Area, Me.Drafting, Me.Hardware, Me.Icon_Renamed, Me.Studio, Me.Separator4, Me.Password})
		ArenaMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.NoTeam, Me.Team1, Me.Team2, Me.Team3, Me.Separator5, Me.ResetHistory, Me.History, Me.RepeatBattle, Me.Separator6, Me.Tournament, Me.TestRobot, Me.Separator18, Me.Scoring, Me.Separator16, Me.SetGameSpeed})
		PreferenceMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.SpeedMenu, Me.Separator8, Me.Sounds, Me.Separator9, Me.ChronorsLimit, Me.MoveAndShoot, Me.Overloading, Me.Separator14, Me.AutoNoSound, Me.resolution, Me.Separator15, Me.ChangeResolution, Me.Separator11, Me.ShowMoveAndShoot, Me.InactivateDebug})
		SpeedMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.Fast, Me.Normal, Me.Slow, Me.Slower, Me.Slowest, Me.AutoRedrawFast, Me.NoDisplay, Me.Ultra})
		HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.Help, Me.Tutorial, Me.About, Me.KnownBugs, Me.WelcomeWindowSwitchMenu, Me.Separator13, Me.Debugger, Me.StartAtChronon})
		Me.Controls.Add(MainMenu1)
		Me.MainMenu1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class