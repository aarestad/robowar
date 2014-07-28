<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class TournamentD
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
	Public WithEvents AllowNearest As System.Windows.Forms.CheckBox
	Public WithEvents TheDirList As System.Windows.Forms.ListBox
	Public WithEvents PrintLog As System.Windows.Forms.CheckBox
	Public WithEvents SlaveTextHP As System.Windows.Forms.TextBox
	Public WithEvents AskBeforeOverwriting As System.Windows.Forms.CheckBox
	Public CommonDialogSelectLocationSave As System.Windows.Forms.SaveFileDialog
	Public WithEvents RobotList As System.Windows.Forms.ListBox
	Public WithEvents ChangeLocation As System.Windows.Forms.Button
	Public WithEvents AllowDrones As System.Windows.Forms.CheckBox
	Public WithEvents CheckEnergy As System.Windows.Forms.CheckBox
	Public WithEvents CheckMoveAndShoot As System.Windows.Forms.CheckBox
	Public WithEvents GRN As System.Windows.Forms.TextBox
	Public WithEvents RemoveAll As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents PrevButton As System.Windows.Forms.Button
	Public WithEvents NextButton As System.Windows.Forms.Button
	Public WithEvents Run As System.Windows.Forms.Button
	Public WithEvents RemoveRobot As System.Windows.Forms.Button
	Public WithEvents CheckNoHPLimit As System.Windows.Forms.CheckBox
	Public WithEvents CheckScoring As System.Windows.Forms.CheckBox
	Public WithEvents TextHP As System.Windows.Forms.TextBox
	Public WithEvents AllowLasers As System.Windows.Forms.CheckBox
	Public WithEvents AddBot As System.Windows.Forms.Button
	Public WithEvents AddDir As System.Windows.Forms.Button
	Public WithEvents Drive As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
	Public WithEvents OptionMortal As System.Windows.Forms.RadioButton
	Public WithEvents OptionTitan As System.Windows.Forms.RadioButton
	Public WithEvents OptionLittleLeague As System.Windows.Forms.RadioButton
	Public WithEvents OptionTeam As System.Windows.Forms.RadioButton
	Public WithEvents OptionAustralian As System.Windows.Forms.RadioButton
	Public WithEvents OptionCustom As System.Windows.Forms.RadioButton
	Public WithEvents CheckWinnerCircle As System.Windows.Forms.CheckBox
	Public WithEvents Directory As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
	Public WithEvents File As Microsoft.VisualBasic.Compatibility.VB6.FileListBox
	Public WithEvents DuelsNumber As System.Windows.Forms.TextBox
	Public WithEvents HPMaster As System.Windows.Forms.Label
	Public WithEvents ResultsSavedIn As System.Windows.Forms.Label
	Public WithEvents SavedInFolder As System.Windows.Forms.Label
	Public WithEvents GRTimes As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents DuelTimes As System.Windows.Forms.Label
	Public WithEvents LabelDuels As System.Windows.Forms.Label
	Public WithEvents TypeLabel As System.Windows.Forms.Label
	Public WithEvents Rectangle As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents CustomOptions As System.Windows.Forms.Label
	Public WithEvents LabelHP As System.Windows.Forms.Label
	Public WithEvents ChooseRobots As System.Windows.Forms.Label
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TournamentD))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.AllowNearest = New System.Windows.Forms.CheckBox
		Me.TheDirList = New System.Windows.Forms.ListBox
		Me.PrintLog = New System.Windows.Forms.CheckBox
		Me.SlaveTextHP = New System.Windows.Forms.TextBox
		Me.AskBeforeOverwriting = New System.Windows.Forms.CheckBox
		Me.CommonDialogSelectLocationSave = New System.Windows.Forms.SaveFileDialog
		Me.RobotList = New System.Windows.Forms.ListBox
		Me.ChangeLocation = New System.Windows.Forms.Button
		Me.AllowDrones = New System.Windows.Forms.CheckBox
		Me.CheckEnergy = New System.Windows.Forms.CheckBox
		Me.CheckMoveAndShoot = New System.Windows.Forms.CheckBox
		Me.GRN = New System.Windows.Forms.TextBox
		Me.RemoveAll = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me.PrevButton = New System.Windows.Forms.Button
		Me.NextButton = New System.Windows.Forms.Button
		Me.Run = New System.Windows.Forms.Button
		Me.RemoveRobot = New System.Windows.Forms.Button
		Me.CheckNoHPLimit = New System.Windows.Forms.CheckBox
		Me.CheckScoring = New System.Windows.Forms.CheckBox
		Me.TextHP = New System.Windows.Forms.TextBox
		Me.AllowLasers = New System.Windows.Forms.CheckBox
		Me.AddBot = New System.Windows.Forms.Button
		Me.AddDir = New System.Windows.Forms.Button
		Me.Drive = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
		Me.OptionMortal = New System.Windows.Forms.RadioButton
		Me.OptionTitan = New System.Windows.Forms.RadioButton
		Me.OptionLittleLeague = New System.Windows.Forms.RadioButton
		Me.OptionTeam = New System.Windows.Forms.RadioButton
		Me.OptionAustralian = New System.Windows.Forms.RadioButton
		Me.OptionCustom = New System.Windows.Forms.RadioButton
		Me.CheckWinnerCircle = New System.Windows.Forms.CheckBox
		Me.Directory = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox
		Me.File = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox
		Me.DuelsNumber = New System.Windows.Forms.TextBox
		Me.HPMaster = New System.Windows.Forms.Label
		Me.ResultsSavedIn = New System.Windows.Forms.Label
		Me.SavedInFolder = New System.Windows.Forms.Label
		Me.GRTimes = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.DuelTimes = New System.Windows.Forms.Label
		Me.LabelDuels = New System.Windows.Forms.Label
		Me.TypeLabel = New System.Windows.Forms.Label
		Me.Rectangle = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me.CustomOptions = New System.Windows.Forms.Label
		Me.LabelHP = New System.Windows.Forms.Label
		Me.ChooseRobots = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.Text = "Tournament"
		Me.ClientSize = New System.Drawing.Size(503, 469)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.Icon = CType(resources.GetObject("TournamentD.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "TournamentD"
		Me.AllowNearest.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.AllowNearest.Text = "Allow Nearest"
		Me.AllowNearest.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.AllowNearest.Size = New System.Drawing.Size(65, 33)
		Me.AllowNearest.Location = New System.Drawing.Point(352, 112)
		Me.AllowNearest.TabIndex = 15
		Me.AllowNearest.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AllowNearest.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.AllowNearest.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.AllowNearest.CausesValidation = True
		Me.AllowNearest.Enabled = True
		Me.AllowNearest.Cursor = System.Windows.Forms.Cursors.Default
		Me.AllowNearest.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.AllowNearest.Appearance = System.Windows.Forms.Appearance.Normal
		Me.AllowNearest.TabStop = True
		Me.AllowNearest.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.AllowNearest.Visible = True
		Me.AllowNearest.Name = "AllowNearest"
		Me.TheDirList.Size = New System.Drawing.Size(121, 33)
		Me.TheDirList.Location = New System.Drawing.Point(296, 320)
		Me.TheDirList.TabIndex = 44
		Me.TheDirList.TabStop = False
		Me.TheDirList.Visible = False
		Me.TheDirList.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TheDirList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TheDirList.BackColor = System.Drawing.SystemColors.Window
		Me.TheDirList.CausesValidation = True
		Me.TheDirList.Enabled = True
		Me.TheDirList.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TheDirList.IntegralHeight = True
		Me.TheDirList.Cursor = System.Windows.Forms.Cursors.Default
		Me.TheDirList.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.TheDirList.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TheDirList.Sorted = False
		Me.TheDirList.MultiColumn = False
		Me.TheDirList.Name = "TheDirList"
		Me.PrintLog.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.PrintLog.Text = "Print Log (slows down!)"
		Me.PrintLog.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.PrintLog.Size = New System.Drawing.Size(81, 49)
		Me.PrintLog.Location = New System.Drawing.Point(424, 176)
		Me.PrintLog.TabIndex = 16
		Me.PrintLog.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PrintLog.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.PrintLog.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.PrintLog.CausesValidation = True
		Me.PrintLog.Enabled = True
		Me.PrintLog.Cursor = System.Windows.Forms.Cursors.Default
		Me.PrintLog.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.PrintLog.Appearance = System.Windows.Forms.Appearance.Normal
		Me.PrintLog.TabStop = True
		Me.PrintLog.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.PrintLog.Visible = True
		Me.PrintLog.Name = "PrintLog"
		Me.SlaveTextHP.AutoSize = False
		Me.SlaveTextHP.Size = New System.Drawing.Size(49, 25)
		Me.SlaveTextHP.Location = New System.Drawing.Point(440, 16)
		Me.SlaveTextHP.TabIndex = 43
		Me.SlaveTextHP.Text = "12"
		Me.SlaveTextHP.Visible = False
		Me.SlaveTextHP.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SlaveTextHP.AcceptsReturn = True
		Me.SlaveTextHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.SlaveTextHP.BackColor = System.Drawing.SystemColors.Window
		Me.SlaveTextHP.CausesValidation = True
		Me.SlaveTextHP.Enabled = True
		Me.SlaveTextHP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.SlaveTextHP.HideSelection = True
		Me.SlaveTextHP.ReadOnly = False
		Me.SlaveTextHP.Maxlength = 0
		Me.SlaveTextHP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.SlaveTextHP.MultiLine = False
		Me.SlaveTextHP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.SlaveTextHP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.SlaveTextHP.TabStop = True
		Me.SlaveTextHP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.SlaveTextHP.Name = "SlaveTextHP"
		Me.AskBeforeOverwriting.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.AskBeforeOverwriting.Text = "Ask before overwriting results file"
		Me.AskBeforeOverwriting.ForeColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.AskBeforeOverwriting.Size = New System.Drawing.Size(185, 25)
		Me.AskBeforeOverwriting.Location = New System.Drawing.Point(8, 440)
		Me.AskBeforeOverwriting.TabIndex = 18
		Me.AskBeforeOverwriting.CheckState = System.Windows.Forms.CheckState.Checked
		Me.AskBeforeOverwriting.Visible = False
		Me.AskBeforeOverwriting.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AskBeforeOverwriting.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.AskBeforeOverwriting.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.AskBeforeOverwriting.CausesValidation = True
		Me.AskBeforeOverwriting.Enabled = True
		Me.AskBeforeOverwriting.Cursor = System.Windows.Forms.Cursors.Default
		Me.AskBeforeOverwriting.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.AskBeforeOverwriting.Appearance = System.Windows.Forms.Appearance.Normal
		Me.AskBeforeOverwriting.TabStop = True
		Me.AskBeforeOverwriting.Name = "AskBeforeOverwriting"
		Me.CommonDialogSelectLocationSave.Title = "Please choose a location for the tournament results text file"
		Me.CommonDialogSelectLocationSave.FileName = "Tournament Results"
		Me.CommonDialogSelectLocationSave.Filter = "Text File (.txt)|*.txt|"
		Me.RobotList.Size = New System.Drawing.Size(121, 254)
		Me.RobotList.Location = New System.Drawing.Point(296, 112)
		Me.RobotList.TabIndex = 28
		Me.RobotList.TabStop = False
		Me.RobotList.Visible = False
		Me.RobotList.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RobotList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.RobotList.BackColor = System.Drawing.SystemColors.Window
		Me.RobotList.CausesValidation = True
		Me.RobotList.Enabled = True
		Me.RobotList.ForeColor = System.Drawing.SystemColors.WindowText
		Me.RobotList.IntegralHeight = True
		Me.RobotList.Cursor = System.Windows.Forms.Cursors.Default
		Me.RobotList.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.RobotList.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.RobotList.Sorted = False
		Me.RobotList.MultiColumn = False
		Me.RobotList.Name = "RobotList"
		Me.ChangeLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ChangeLocation.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.ChangeLocation.Text = "Change"
		Me.ChangeLocation.Size = New System.Drawing.Size(49, 17)
		Me.ChangeLocation.Location = New System.Drawing.Point(448, 408)
		Me.ChangeLocation.TabIndex = 17
		Me.ChangeLocation.Visible = False
		Me.ChangeLocation.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ChangeLocation.CausesValidation = True
		Me.ChangeLocation.Enabled = True
		Me.ChangeLocation.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChangeLocation.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChangeLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChangeLocation.TabStop = True
		Me.ChangeLocation.Name = "ChangeLocation"
		Me.AllowDrones.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.AllowDrones.Text = "Allow Drones"
		Me.AllowDrones.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.AllowDrones.Size = New System.Drawing.Size(73, 33)
		Me.AllowDrones.Location = New System.Drawing.Point(240, 112)
		Me.AllowDrones.TabIndex = 12
		Me.AllowDrones.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AllowDrones.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.AllowDrones.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.AllowDrones.CausesValidation = True
		Me.AllowDrones.Enabled = True
		Me.AllowDrones.Cursor = System.Windows.Forms.Cursors.Default
		Me.AllowDrones.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.AllowDrones.Appearance = System.Windows.Forms.Appearance.Normal
		Me.AllowDrones.TabStop = True
		Me.AllowDrones.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.AllowDrones.Visible = True
		Me.AllowDrones.Name = "AllowDrones"
		Me.CheckEnergy.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.CheckEnergy.Text = "Allow -200 > Energy"
		Me.CheckEnergy.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.CheckEnergy.Size = New System.Drawing.Size(81, 33)
		Me.CheckEnergy.Location = New System.Drawing.Point(240, 80)
		Me.CheckEnergy.TabIndex = 11
		Me.CheckEnergy.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CheckEnergy.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.CheckEnergy.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.CheckEnergy.CausesValidation = True
		Me.CheckEnergy.Enabled = True
		Me.CheckEnergy.Cursor = System.Windows.Forms.Cursors.Default
		Me.CheckEnergy.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CheckEnergy.Appearance = System.Windows.Forms.Appearance.Normal
		Me.CheckEnergy.TabStop = True
		Me.CheckEnergy.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.CheckEnergy.Visible = True
		Me.CheckEnergy.Name = "CheckEnergy"
		Me.CheckMoveAndShoot.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.CheckMoveAndShoot.Text = "Allow Move and Shoot"
		Me.CheckMoveAndShoot.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.CheckMoveAndShoot.Size = New System.Drawing.Size(81, 33)
		Me.CheckMoveAndShoot.Location = New System.Drawing.Point(160, 80)
		Me.CheckMoveAndShoot.TabIndex = 8
		Me.CheckMoveAndShoot.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CheckMoveAndShoot.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.CheckMoveAndShoot.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.CheckMoveAndShoot.CausesValidation = True
		Me.CheckMoveAndShoot.Enabled = True
		Me.CheckMoveAndShoot.Cursor = System.Windows.Forms.Cursors.Default
		Me.CheckMoveAndShoot.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CheckMoveAndShoot.Appearance = System.Windows.Forms.Appearance.Normal
		Me.CheckMoveAndShoot.TabStop = True
		Me.CheckMoveAndShoot.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.CheckMoveAndShoot.Visible = True
		Me.CheckMoveAndShoot.Name = "CheckMoveAndShoot"
		Me.GRN.AutoSize = False
		Me.GRN.Size = New System.Drawing.Size(81, 20)
		Me.GRN.Location = New System.Drawing.Point(336, 296)
		Me.GRN.TabIndex = 20
		Me.GRN.Text = "6"
		Me.GRN.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GRN.AcceptsReturn = True
		Me.GRN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.GRN.BackColor = System.Drawing.SystemColors.Window
		Me.GRN.CausesValidation = True
		Me.GRN.Enabled = True
		Me.GRN.ForeColor = System.Drawing.SystemColors.WindowText
		Me.GRN.HideSelection = True
		Me.GRN.ReadOnly = False
		Me.GRN.Maxlength = 0
		Me.GRN.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.GRN.MultiLine = False
		Me.GRN.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.GRN.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.GRN.TabStop = True
		Me.GRN.Visible = True
		Me.GRN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.GRN.Name = "GRN"
		Me.RemoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.RemoveAll.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.RemoveAll.Text = "Remove All"
		Me.RemoveAll.Size = New System.Drawing.Size(73, 17)
		Me.RemoveAll.Location = New System.Drawing.Point(424, 152)
		Me.RemoveAll.TabIndex = 30
		Me.RemoveAll.TabStop = False
		Me.RemoveAll.Visible = False
		Me.RemoveAll.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RemoveAll.CausesValidation = True
		Me.RemoveAll.Enabled = True
		Me.RemoveAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.RemoveAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.RemoveAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.RemoveAll.Name = "RemoveAll"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.Command1.Text = "To RoboWar Folder"
		Me.Command1.Size = New System.Drawing.Size(70, 33)
		Me.Command1.Location = New System.Drawing.Point(8, 368)
		Me.Command1.TabIndex = 25
		Me.Command1.TabStop = False
		Me.Command1.Visible = False
		Me.Command1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.Name = "Command1"
		Me.PrevButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.PrevButton.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.PrevButton.Text = "Prev"
		Me.PrevButton.Enabled = False
		Me.PrevButton.Size = New System.Drawing.Size(81, 25)
		Me.PrevButton.Location = New System.Drawing.Point(232, 440)
		Me.PrevButton.TabIndex = 21
		Me.PrevButton.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PrevButton.CausesValidation = True
		Me.PrevButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.PrevButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.PrevButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.PrevButton.TabStop = True
		Me.PrevButton.Name = "PrevButton"
		Me.NextButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.NextButton.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.NextButton.Text = "Next"
		Me.NextButton.Size = New System.Drawing.Size(81, 25)
		Me.NextButton.Location = New System.Drawing.Point(328, 440)
		Me.NextButton.TabIndex = 0
		Me.NextButton.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NextButton.CausesValidation = True
		Me.NextButton.Enabled = True
		Me.NextButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.NextButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.NextButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.NextButton.TabStop = True
		Me.NextButton.Name = "NextButton"
		Me.Run.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Run.BackColor = System.Drawing.Color.FromARGB(132, 194, 219)
		Me.Run.Text = "Run!"
		Me.AcceptButton = Me.Run
		Me.Run.Size = New System.Drawing.Size(73, 33)
		Me.Run.Location = New System.Drawing.Point(424, 432)
		Me.Run.TabIndex = 31
		Me.Run.Visible = False
		Me.Run.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Run.CausesValidation = True
		Me.Run.Enabled = True
		Me.Run.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Run.Cursor = System.Windows.Forms.Cursors.Default
		Me.Run.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Run.TabStop = True
		Me.Run.Name = "Run"
		Me.RemoveRobot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.RemoveRobot.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.RemoveRobot.Text = "Remove Robot"
		Me.RemoveRobot.Size = New System.Drawing.Size(73, 33)
		Me.RemoveRobot.Location = New System.Drawing.Point(424, 112)
		Me.RemoveRobot.TabIndex = 29
		Me.RemoveRobot.TabStop = False
		Me.RemoveRobot.Visible = False
		Me.RemoveRobot.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RemoveRobot.CausesValidation = True
		Me.RemoveRobot.Enabled = True
		Me.RemoveRobot.ForeColor = System.Drawing.SystemColors.ControlText
		Me.RemoveRobot.Cursor = System.Windows.Forms.Cursors.Default
		Me.RemoveRobot.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.RemoveRobot.Name = "RemoveRobot"
		Me.CheckNoHPLimit.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.CheckNoHPLimit.Text = "No Hardware Points Limit"
		Me.CheckNoHPLimit.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.CheckNoHPLimit.Size = New System.Drawing.Size(137, 25)
		Me.CheckNoHPLimit.Location = New System.Drawing.Point(352, 80)
		Me.CheckNoHPLimit.TabIndex = 14
		Me.CheckNoHPLimit.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CheckNoHPLimit.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.CheckNoHPLimit.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.CheckNoHPLimit.CausesValidation = True
		Me.CheckNoHPLimit.Enabled = True
		Me.CheckNoHPLimit.Cursor = System.Windows.Forms.Cursors.Default
		Me.CheckNoHPLimit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CheckNoHPLimit.Appearance = System.Windows.Forms.Appearance.Normal
		Me.CheckNoHPLimit.TabStop = True
		Me.CheckNoHPLimit.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.CheckNoHPLimit.Visible = True
		Me.CheckNoHPLimit.Name = "CheckNoHPLimit"
		Me.CheckScoring.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.CheckScoring.Text = "Mac Scoring (4.5.2)"
		Me.CheckScoring.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.CheckScoring.Size = New System.Drawing.Size(81, 33)
		Me.CheckScoring.Location = New System.Drawing.Point(240, 48)
		Me.CheckScoring.TabIndex = 10
		Me.CheckScoring.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CheckScoring.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.CheckScoring.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.CheckScoring.CausesValidation = True
		Me.CheckScoring.Enabled = True
		Me.CheckScoring.Cursor = System.Windows.Forms.Cursors.Default
		Me.CheckScoring.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CheckScoring.Appearance = System.Windows.Forms.Appearance.Normal
		Me.CheckScoring.TabStop = True
		Me.CheckScoring.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.CheckScoring.Visible = True
		Me.CheckScoring.Name = "CheckScoring"
		Me.TextHP.AutoSize = False
		Me.TextHP.Size = New System.Drawing.Size(49, 25)
		Me.TextHP.Location = New System.Drawing.Point(440, 48)
		Me.TextHP.TabIndex = 13
		Me.TextHP.Text = "9"
		Me.TextHP.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TextHP.AcceptsReturn = True
		Me.TextHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TextHP.BackColor = System.Drawing.SystemColors.Window
		Me.TextHP.CausesValidation = True
		Me.TextHP.Enabled = True
		Me.TextHP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TextHP.HideSelection = True
		Me.TextHP.ReadOnly = False
		Me.TextHP.Maxlength = 0
		Me.TextHP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TextHP.MultiLine = False
		Me.TextHP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TextHP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TextHP.TabStop = True
		Me.TextHP.Visible = True
		Me.TextHP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TextHP.Name = "TextHP"
		Me.AllowLasers.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.AllowLasers.Text = "Allow Lasers"
		Me.AllowLasers.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.AllowLasers.Size = New System.Drawing.Size(73, 33)
		Me.AllowLasers.Location = New System.Drawing.Point(160, 112)
		Me.AllowLasers.TabIndex = 9
		Me.AllowLasers.CheckState = System.Windows.Forms.CheckState.Checked
		Me.AllowLasers.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AllowLasers.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.AllowLasers.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.AllowLasers.CausesValidation = True
		Me.AllowLasers.Enabled = True
		Me.AllowLasers.Cursor = System.Windows.Forms.Cursors.Default
		Me.AllowLasers.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.AllowLasers.Appearance = System.Windows.Forms.Appearance.Normal
		Me.AllowLasers.TabStop = True
		Me.AllowLasers.Visible = True
		Me.AllowLasers.Name = "AllowLasers"
		Me.AddBot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.AddBot.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.AddBot.Text = "Add Robot"
		Me.AddBot.Size = New System.Drawing.Size(65, 17)
		Me.AddBot.Location = New System.Drawing.Point(160, 368)
		Me.AddBot.TabIndex = 27
		Me.AddBot.TabStop = False
		Me.AddBot.Visible = False
		Me.AddBot.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AddBot.CausesValidation = True
		Me.AddBot.Enabled = True
		Me.AddBot.ForeColor = System.Drawing.SystemColors.ControlText
		Me.AddBot.Cursor = System.Windows.Forms.Cursors.Default
		Me.AddBot.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.AddBot.Name = "AddBot"
		Me.AddDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.AddDir.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.AddDir.Text = "Add Directory"
		Me.AddDir.Size = New System.Drawing.Size(72, 17)
		Me.AddDir.Location = New System.Drawing.Point(82, 368)
		Me.AddDir.TabIndex = 24
		Me.AddDir.TabStop = False
		Me.AddDir.Visible = False
		Me.AddDir.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AddDir.CausesValidation = True
		Me.AddDir.Enabled = True
		Me.AddDir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.AddDir.Cursor = System.Windows.Forms.Cursors.Default
		Me.AddDir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.AddDir.Name = "AddDir"
		Me.Drive.Size = New System.Drawing.Size(81, 21)
		Me.Drive.Location = New System.Drawing.Point(8, 64)
		Me.Drive.TabIndex = 22
		Me.Drive.TabStop = False
		Me.Drive.Visible = False
		Me.Drive.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Drive.BackColor = System.Drawing.SystemColors.Window
		Me.Drive.CausesValidation = True
		Me.Drive.Enabled = True
		Me.Drive.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Drive.Cursor = System.Windows.Forms.Cursors.Default
		Me.Drive.Name = "Drive"
		Me.OptionMortal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionMortal.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.OptionMortal.Text = "Motral"
		Me.OptionMortal.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.OptionMortal.Size = New System.Drawing.Size(81, 33)
		Me.OptionMortal.Location = New System.Drawing.Point(8, 40)
		Me.OptionMortal.TabIndex = 1
		Me.OptionMortal.Checked = True
		Me.OptionMortal.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OptionMortal.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionMortal.CausesValidation = True
		Me.OptionMortal.Enabled = True
		Me.OptionMortal.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptionMortal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptionMortal.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptionMortal.TabStop = True
		Me.OptionMortal.Visible = True
		Me.OptionMortal.Name = "OptionMortal"
		Me.OptionTitan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionTitan.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.OptionTitan.Text = "Titan"
		Me.OptionTitan.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.OptionTitan.Size = New System.Drawing.Size(81, 33)
		Me.OptionTitan.Location = New System.Drawing.Point(8, 72)
		Me.OptionTitan.TabIndex = 2
		Me.OptionTitan.TabStop = False
		Me.OptionTitan.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OptionTitan.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionTitan.CausesValidation = True
		Me.OptionTitan.Enabled = True
		Me.OptionTitan.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptionTitan.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptionTitan.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptionTitan.Checked = False
		Me.OptionTitan.Visible = True
		Me.OptionTitan.Name = "OptionTitan"
		Me.OptionLittleLeague.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionLittleLeague.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.OptionLittleLeague.Text = "Little League"
		Me.OptionLittleLeague.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.OptionLittleLeague.Size = New System.Drawing.Size(81, 33)
		Me.OptionLittleLeague.Location = New System.Drawing.Point(8, 104)
		Me.OptionLittleLeague.TabIndex = 3
		Me.OptionLittleLeague.TabStop = False
		Me.OptionLittleLeague.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OptionLittleLeague.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionLittleLeague.CausesValidation = True
		Me.OptionLittleLeague.Enabled = True
		Me.OptionLittleLeague.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptionLittleLeague.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptionLittleLeague.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptionLittleLeague.Checked = False
		Me.OptionLittleLeague.Visible = True
		Me.OptionLittleLeague.Name = "OptionLittleLeague"
		Me.OptionTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionTeam.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.OptionTeam.Text = "Team"
		Me.OptionTeam.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.OptionTeam.Size = New System.Drawing.Size(81, 33)
		Me.OptionTeam.Location = New System.Drawing.Point(8, 136)
		Me.OptionTeam.TabIndex = 4
		Me.OptionTeam.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OptionTeam.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionTeam.CausesValidation = True
		Me.OptionTeam.Enabled = True
		Me.OptionTeam.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptionTeam.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptionTeam.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptionTeam.TabStop = True
		Me.OptionTeam.Checked = False
		Me.OptionTeam.Visible = True
		Me.OptionTeam.Name = "OptionTeam"
		Me.OptionAustralian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionAustralian.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.OptionAustralian.Text = """Australian Rules"""
		Me.OptionAustralian.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.OptionAustralian.Size = New System.Drawing.Size(81, 33)
		Me.OptionAustralian.Location = New System.Drawing.Point(8, 168)
		Me.OptionAustralian.TabIndex = 5
		Me.OptionAustralian.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OptionAustralian.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionAustralian.CausesValidation = True
		Me.OptionAustralian.Enabled = True
		Me.OptionAustralian.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptionAustralian.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptionAustralian.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptionAustralian.TabStop = True
		Me.OptionAustralian.Checked = False
		Me.OptionAustralian.Visible = True
		Me.OptionAustralian.Name = "OptionAustralian"
		Me.OptionCustom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionCustom.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.OptionCustom.Text = "Custom"
		Me.OptionCustom.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.OptionCustom.Size = New System.Drawing.Size(81, 33)
		Me.OptionCustom.Location = New System.Drawing.Point(8, 200)
		Me.OptionCustom.TabIndex = 6
		Me.OptionCustom.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OptionCustom.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptionCustom.CausesValidation = True
		Me.OptionCustom.Enabled = True
		Me.OptionCustom.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptionCustom.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptionCustom.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptionCustom.TabStop = True
		Me.OptionCustom.Checked = False
		Me.OptionCustom.Visible = True
		Me.OptionCustom.Name = "OptionCustom"
		Me.CheckWinnerCircle.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.CheckWinnerCircle.Text = "Winners' Circle"
		Me.CheckWinnerCircle.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.CheckWinnerCircle.Size = New System.Drawing.Size(81, 33)
		Me.CheckWinnerCircle.Location = New System.Drawing.Point(160, 48)
		Me.CheckWinnerCircle.TabIndex = 7
		Me.CheckWinnerCircle.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CheckWinnerCircle.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CheckWinnerCircle.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.CheckWinnerCircle.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.CheckWinnerCircle.CausesValidation = True
		Me.CheckWinnerCircle.Enabled = True
		Me.CheckWinnerCircle.Cursor = System.Windows.Forms.Cursors.Default
		Me.CheckWinnerCircle.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CheckWinnerCircle.Appearance = System.Windows.Forms.Appearance.Normal
		Me.CheckWinnerCircle.TabStop = True
		Me.CheckWinnerCircle.Visible = True
		Me.CheckWinnerCircle.Name = "CheckWinnerCircle"
		Me.Directory.Size = New System.Drawing.Size(145, 246)
		Me.Directory.Location = New System.Drawing.Point(8, 112)
		Me.Directory.TabIndex = 23
		Me.Directory.TabStop = False
		Me.Directory.Visible = False
		Me.Directory.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Directory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Directory.BackColor = System.Drawing.SystemColors.Window
		Me.Directory.CausesValidation = True
		Me.Directory.Enabled = True
		Me.Directory.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Directory.Cursor = System.Windows.Forms.Cursors.Default
		Me.Directory.Name = "Directory"
		Me.File.Size = New System.Drawing.Size(129, 253)
		Me.File.Location = New System.Drawing.Point(160, 112)
		Me.File.Pattern = "*.RWR"
		Me.File.TabIndex = 26
		Me.File.TabStop = False
		Me.File.Visible = False
		Me.File.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.File.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.File.Archive = True
		Me.File.BackColor = System.Drawing.SystemColors.Window
		Me.File.CausesValidation = True
		Me.File.Enabled = True
		Me.File.ForeColor = System.Drawing.SystemColors.WindowText
		Me.File.Hidden = False
		Me.File.Cursor = System.Windows.Forms.Cursors.Default
		Me.File.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.File.Normal = True
		Me.File.ReadOnly = True
		Me.File.System = False
		Me.File.TopIndex = 0
		Me.File.Name = "File"
		Me.DuelsNumber.AutoSize = False
		Me.DuelsNumber.Size = New System.Drawing.Size(81, 20)
		Me.DuelsNumber.Location = New System.Drawing.Point(336, 216)
		Me.DuelsNumber.TabIndex = 19
		Me.DuelsNumber.Text = "10"
		Me.DuelsNumber.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DuelsNumber.AcceptsReturn = True
		Me.DuelsNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.DuelsNumber.BackColor = System.Drawing.SystemColors.Window
		Me.DuelsNumber.CausesValidation = True
		Me.DuelsNumber.Enabled = True
		Me.DuelsNumber.ForeColor = System.Drawing.SystemColors.WindowText
		Me.DuelsNumber.HideSelection = True
		Me.DuelsNumber.ReadOnly = False
		Me.DuelsNumber.Maxlength = 0
		Me.DuelsNumber.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.DuelsNumber.MultiLine = False
		Me.DuelsNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DuelsNumber.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.DuelsNumber.TabStop = True
		Me.DuelsNumber.Visible = True
		Me.DuelsNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.DuelsNumber.Name = "DuelsNumber"
		Me.HPMaster.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.HPMaster.Text = "Allowed Hardware Points"
		Me.HPMaster.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.HPMaster.Size = New System.Drawing.Size(81, 25)
		Me.HPMaster.Location = New System.Drawing.Point(352, 16)
		Me.HPMaster.TabIndex = 42
		Me.HPMaster.Visible = False
		Me.HPMaster.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.HPMaster.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.HPMaster.Enabled = True
		Me.HPMaster.Cursor = System.Windows.Forms.Cursors.Default
		Me.HPMaster.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HPMaster.UseMnemonic = True
		Me.HPMaster.AutoSize = False
		Me.HPMaster.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.HPMaster.Name = "HPMaster"
		Me.ResultsSavedIn.Text = "Results will be saved in"
		Me.ResultsSavedIn.ForeColor = System.Drawing.Color.White
		Me.ResultsSavedIn.Size = New System.Drawing.Size(113, 17)
		Me.ResultsSavedIn.Location = New System.Drawing.Point(8, 408)
		Me.ResultsSavedIn.TabIndex = 41
		Me.ResultsSavedIn.Visible = False
		Me.ResultsSavedIn.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ResultsSavedIn.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.ResultsSavedIn.BackColor = System.Drawing.Color.Transparent
		Me.ResultsSavedIn.Enabled = True
		Me.ResultsSavedIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.ResultsSavedIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ResultsSavedIn.UseMnemonic = True
		Me.ResultsSavedIn.AutoSize = False
		Me.ResultsSavedIn.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.ResultsSavedIn.Name = "ResultsSavedIn"
		Me.SavedInFolder.Text = "C:\Program Files\RoboWar 5\Tournament Results.txt"
		Me.SavedInFolder.ForeColor = System.Drawing.Color.White
		Me.SavedInFolder.Size = New System.Drawing.Size(310, 29)
		Me.SavedInFolder.Location = New System.Drawing.Point(128, 408)
		Me.SavedInFolder.TabIndex = 40
		Me.SavedInFolder.Visible = False
		Me.SavedInFolder.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SavedInFolder.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.SavedInFolder.BackColor = System.Drawing.Color.Transparent
		Me.SavedInFolder.Enabled = True
		Me.SavedInFolder.Cursor = System.Windows.Forms.Cursors.Default
		Me.SavedInFolder.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.SavedInFolder.UseMnemonic = True
		Me.SavedInFolder.AutoSize = False
		Me.SavedInFolder.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.SavedInFolder.Name = "SavedInFolder"
		Me.GRTimes.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.GRTimes.Text = "Times"
		Me.GRTimes.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.GRTimes.Size = New System.Drawing.Size(49, 17)
		Me.GRTimes.Location = New System.Drawing.Point(368, 320)
		Me.GRTimes.TabIndex = 39
		Me.GRTimes.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GRTimes.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.GRTimes.Enabled = True
		Me.GRTimes.Cursor = System.Windows.Forms.Cursors.Default
		Me.GRTimes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.GRTimes.UseMnemonic = True
		Me.GRTimes.Visible = True
		Me.GRTimes.AutoSize = False
		Me.GRTimes.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.GRTimes.Name = "GRTimes"
		Me.Label1.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.Label1.Text = "Group Rounds - Robot meets each other"
		Me.Label1.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.Label1.Size = New System.Drawing.Size(113, 33)
		Me.Label1.Location = New System.Drawing.Point(304, 264)
		Me.Label1.TabIndex = 38
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.DuelTimes.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.DuelTimes.Text = "Times"
		Me.DuelTimes.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.DuelTimes.Size = New System.Drawing.Size(49, 17)
		Me.DuelTimes.Location = New System.Drawing.Point(368, 240)
		Me.DuelTimes.TabIndex = 37
		Me.DuelTimes.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DuelTimes.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.DuelTimes.Enabled = True
		Me.DuelTimes.Cursor = System.Windows.Forms.Cursors.Default
		Me.DuelTimes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DuelTimes.UseMnemonic = True
		Me.DuelTimes.Visible = True
		Me.DuelTimes.AutoSize = False
		Me.DuelTimes.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.DuelTimes.Name = "DuelTimes"
		Me.LabelDuels.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.LabelDuels.Text = "Duels - Robot meets each other"
		Me.LabelDuels.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.LabelDuels.Size = New System.Drawing.Size(113, 33)
		Me.LabelDuels.Location = New System.Drawing.Point(304, 184)
		Me.LabelDuels.TabIndex = 36
		Me.LabelDuels.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelDuels.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.LabelDuels.Enabled = True
		Me.LabelDuels.Cursor = System.Windows.Forms.Cursors.Default
		Me.LabelDuels.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LabelDuels.UseMnemonic = True
		Me.LabelDuels.Visible = True
		Me.LabelDuels.AutoSize = False
		Me.LabelDuels.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LabelDuels.Name = "LabelDuels"
		Me.TypeLabel.Text = "Type"
		Me.TypeLabel.Font = New System.Drawing.Font("Arial", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TypeLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder
		Me.TypeLabel.Size = New System.Drawing.Size(73, 33)
		Me.TypeLabel.Location = New System.Drawing.Point(8, 0)
		Me.TypeLabel.TabIndex = 34
		Me.TypeLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.TypeLabel.BackColor = System.Drawing.Color.Transparent
		Me.TypeLabel.Enabled = True
		Me.TypeLabel.Cursor = System.Windows.Forms.Cursors.Default
		Me.TypeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TypeLabel.UseMnemonic = True
		Me.TypeLabel.Visible = True
		Me.TypeLabel.AutoSize = False
		Me.TypeLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TypeLabel.Name = "TypeLabel"
		Me.Rectangle.BorderColor = System.Drawing.Color.White
		Me.Rectangle.Size = New System.Drawing.Size(353, 153)
		Me.Rectangle.Location = New System.Drawing.Point(144, 8)
		Me.Rectangle.BackColor = System.Drawing.SystemColors.Window
		Me.Rectangle.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent
		Me.Rectangle.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Rectangle.BorderWidth = 1
		Me.Rectangle.FillColor = System.Drawing.Color.Black
		Me.Rectangle.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me.Rectangle.Visible = True
		Me.Rectangle.Name = "Rectangle"
		Me.CustomOptions.Text = "Custom Options"
		Me.CustomOptions.Font = New System.Drawing.Font("Arial", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CustomOptions.ForeColor = System.Drawing.SystemColors.ActiveBorder
		Me.CustomOptions.Size = New System.Drawing.Size(241, 25)
		Me.CustomOptions.Location = New System.Drawing.Point(152, 16)
		Me.CustomOptions.TabIndex = 33
		Me.CustomOptions.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.CustomOptions.BackColor = System.Drawing.Color.Transparent
		Me.CustomOptions.Enabled = True
		Me.CustomOptions.Cursor = System.Windows.Forms.Cursors.Default
		Me.CustomOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CustomOptions.UseMnemonic = True
		Me.CustomOptions.Visible = True
		Me.CustomOptions.AutoSize = False
		Me.CustomOptions.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CustomOptions.Name = "CustomOptions"
		Me.LabelHP.BackColor = System.Drawing.Color.FromARGB(46, 62, 69)
		Me.LabelHP.Text = "Allowed Hardware Points"
		Me.LabelHP.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.LabelHP.Size = New System.Drawing.Size(81, 33)
		Me.LabelHP.Location = New System.Drawing.Point(352, 48)
		Me.LabelHP.TabIndex = 32
		Me.LabelHP.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelHP.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.LabelHP.Enabled = True
		Me.LabelHP.Cursor = System.Windows.Forms.Cursors.Default
		Me.LabelHP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LabelHP.UseMnemonic = True
		Me.LabelHP.Visible = True
		Me.LabelHP.AutoSize = False
		Me.LabelHP.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LabelHP.Name = "LabelHP"
		Me.ChooseRobots.Text = "Choose Robots"
		Me.ChooseRobots.Font = New System.Drawing.Font("Arial", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ChooseRobots.ForeColor = System.Drawing.SystemColors.ActiveBorder
		Me.ChooseRobots.Size = New System.Drawing.Size(233, 33)
		Me.ChooseRobots.Location = New System.Drawing.Point(8, 8)
		Me.ChooseRobots.TabIndex = 35
		Me.ChooseRobots.Visible = False
		Me.ChooseRobots.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.ChooseRobots.BackColor = System.Drawing.Color.Transparent
		Me.ChooseRobots.Enabled = True
		Me.ChooseRobots.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChooseRobots.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChooseRobots.UseMnemonic = True
		Me.ChooseRobots.AutoSize = False
		Me.ChooseRobots.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.ChooseRobots.Name = "ChooseRobots"
		Me.Controls.Add(AllowNearest)
		Me.Controls.Add(TheDirList)
		Me.Controls.Add(PrintLog)
		Me.Controls.Add(SlaveTextHP)
		Me.Controls.Add(AskBeforeOverwriting)
		Me.Controls.Add(RobotList)
		Me.Controls.Add(ChangeLocation)
		Me.Controls.Add(AllowDrones)
		Me.Controls.Add(CheckEnergy)
		Me.Controls.Add(CheckMoveAndShoot)
		Me.Controls.Add(GRN)
		Me.Controls.Add(RemoveAll)
		Me.Controls.Add(Command1)
		Me.Controls.Add(PrevButton)
		Me.Controls.Add(NextButton)
		Me.Controls.Add(Run)
		Me.Controls.Add(RemoveRobot)
		Me.Controls.Add(CheckNoHPLimit)
		Me.Controls.Add(CheckScoring)
		Me.Controls.Add(TextHP)
		Me.Controls.Add(AllowLasers)
		Me.Controls.Add(AddBot)
		Me.Controls.Add(AddDir)
		Me.Controls.Add(Drive)
		Me.Controls.Add(OptionMortal)
		Me.Controls.Add(OptionTitan)
		Me.Controls.Add(OptionLittleLeague)
		Me.Controls.Add(OptionTeam)
		Me.Controls.Add(OptionAustralian)
		Me.Controls.Add(OptionCustom)
		Me.Controls.Add(CheckWinnerCircle)
		Me.Controls.Add(Directory)
		Me.Controls.Add(File)
		Me.Controls.Add(DuelsNumber)
		Me.Controls.Add(HPMaster)
		Me.Controls.Add(ResultsSavedIn)
		Me.Controls.Add(SavedInFolder)
		Me.Controls.Add(GRTimes)
		Me.Controls.Add(Label1)
		Me.Controls.Add(DuelTimes)
		Me.Controls.Add(LabelDuels)
		Me.Controls.Add(TypeLabel)
		Me.ShapeContainer1.Shapes.Add(Rectangle)
		Me.Controls.Add(CustomOptions)
		Me.Controls.Add(LabelHP)
		Me.Controls.Add(ChooseRobots)
		Me.Controls.Add(ShapeContainer1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class