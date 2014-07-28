<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class TestTourney
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
	Public WithEvents TheDirList As System.Windows.Forms.ListBox
	Public WithEvents PrintLog As System.Windows.Forms.CheckBox
	Public WithEvents NormalTest As System.Windows.Forms.RadioButton
	Public WithEvents ChangeLocation As System.Windows.Forms.Button
	Public WithEvents CheckScoring As System.Windows.Forms.CheckBox
	Public WithEvents MandS As System.Windows.Forms.CheckBox
	Public WithEvents RWDir As System.Windows.Forms.Button
	Public WithEvents Run As System.Windows.Forms.Button
	Public WithEvents RemoveRobot As System.Windows.Forms.Button
	Public WithEvents RemoveAll As System.Windows.Forms.Button
	Public WithEvents RobotPict As System.Windows.Forms.PictureBox
	Public WithEvents GroupNR As System.Windows.Forms.TextBox
	Public WithEvents DuelsNR As System.Windows.Forms.TextBox
	Public WithEvents AddAll As System.Windows.Forms.Button
	Public WithEvents Add_Renamed As System.Windows.Forms.Button
	Public WithEvents Testing As System.Windows.Forms.Button
	Public WithEvents RobotList As System.Windows.Forms.ListBox
	Public WithEvents File1 As Microsoft.VisualBasic.Compatibility.VB6.FileListBox
	Public WithEvents Dir1 As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
	Public WithEvents Drive1 As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
	Public CommonDialogSelectLocationSave As System.Windows.Forms.SaveFileDialog
	Public WithEvents AskBeforeOverwriting As System.Windows.Forms.CheckBox
	Public WithEvents TeamTest As System.Windows.Forms.RadioButton
	Public WithEvents SavedInFolder As System.Windows.Forms.Label
	Public WithEvents ResultsSavedIn As System.Windows.Forms.Label
	Public WithEvents Shape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Shape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents WhoIsTested As System.Windows.Forms.Label
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TestTourney))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.TheDirList = New System.Windows.Forms.ListBox
		Me.PrintLog = New System.Windows.Forms.CheckBox
		Me.NormalTest = New System.Windows.Forms.RadioButton
		Me.ChangeLocation = New System.Windows.Forms.Button
		Me.CheckScoring = New System.Windows.Forms.CheckBox
		Me.MandS = New System.Windows.Forms.CheckBox
		Me.RWDir = New System.Windows.Forms.Button
		Me.Run = New System.Windows.Forms.Button
		Me.RemoveRobot = New System.Windows.Forms.Button
		Me.RemoveAll = New System.Windows.Forms.Button
		Me.RobotPict = New System.Windows.Forms.PictureBox
		Me.GroupNR = New System.Windows.Forms.TextBox
		Me.DuelsNR = New System.Windows.Forms.TextBox
		Me.AddAll = New System.Windows.Forms.Button
		Me.Add_Renamed = New System.Windows.Forms.Button
		Me.Testing = New System.Windows.Forms.Button
		Me.RobotList = New System.Windows.Forms.ListBox
		Me.File1 = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox
		Me.Dir1 = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox
		Me.Drive1 = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
		Me.CommonDialogSelectLocationSave = New System.Windows.Forms.SaveFileDialog
		Me.AskBeforeOverwriting = New System.Windows.Forms.CheckBox
		Me.TeamTest = New System.Windows.Forms.RadioButton
		Me.SavedInFolder = New System.Windows.Forms.Label
		Me.ResultsSavedIn = New System.Windows.Forms.Label
		Me.Shape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me.Label1 = New System.Windows.Forms.Label
		Me.Shape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.WhoIsTested = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.Text = "Test Robot"
		Me.ClientSize = New System.Drawing.Size(577, 499)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.Icon = CType(resources.GetObject("TestTourney.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
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
		Me.Name = "TestTourney"
		Me.TheDirList.Size = New System.Drawing.Size(161, 33)
		Me.TheDirList.Location = New System.Drawing.Point(400, 128)
		Me.TheDirList.TabIndex = 29
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
		Me.PrintLog.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.PrintLog.Text = "Print Log (slows down!)"
		Me.PrintLog.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.PrintLog.Size = New System.Drawing.Size(73, 41)
		Me.PrintLog.Location = New System.Drawing.Point(152, 256)
		Me.PrintLog.TabIndex = 28
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
		Me.NormalTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.NormalTest.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.NormalTest.Text = "Normal"
		Me.NormalTest.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.NormalTest.Size = New System.Drawing.Size(55, 17)
		Me.NormalTest.Location = New System.Drawing.Point(168, 208)
		Me.NormalTest.TabIndex = 26
		Me.NormalTest.Checked = True
		Me.NormalTest.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NormalTest.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.NormalTest.CausesValidation = True
		Me.NormalTest.Enabled = True
		Me.NormalTest.Cursor = System.Windows.Forms.Cursors.Default
		Me.NormalTest.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.NormalTest.Appearance = System.Windows.Forms.Appearance.Normal
		Me.NormalTest.TabStop = True
		Me.NormalTest.Visible = True
		Me.NormalTest.Name = "NormalTest"
		Me.ChangeLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ChangeLocation.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.ChangeLocation.Text = "Change"
		Me.ChangeLocation.Size = New System.Drawing.Size(57, 17)
		Me.ChangeLocation.Location = New System.Drawing.Point(448, 472)
		Me.ChangeLocation.TabIndex = 22
		Me.ChangeLocation.Visible = False
		Me.ChangeLocation.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ChangeLocation.CausesValidation = True
		Me.ChangeLocation.Enabled = True
		Me.ChangeLocation.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChangeLocation.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChangeLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChangeLocation.TabStop = True
		Me.ChangeLocation.Name = "ChangeLocation"
		Me.CheckScoring.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.CheckScoring.Text = "Mac Scoring"
		Me.CheckScoring.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.CheckScoring.Size = New System.Drawing.Size(65, 33)
		Me.CheckScoring.Location = New System.Drawing.Point(152, 344)
		Me.CheckScoring.TabIndex = 21
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
		Me.MandS.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.MandS.Text = "Allow Move and Shoot"
		Me.MandS.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.MandS.Size = New System.Drawing.Size(73, 41)
		Me.MandS.Location = New System.Drawing.Point(152, 304)
		Me.MandS.TabIndex = 20
		Me.MandS.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MandS.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.MandS.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.MandS.CausesValidation = True
		Me.MandS.Enabled = True
		Me.MandS.Cursor = System.Windows.Forms.Cursors.Default
		Me.MandS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.MandS.Appearance = System.Windows.Forms.Appearance.Normal
		Me.MandS.TabStop = True
		Me.MandS.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.MandS.Visible = True
		Me.MandS.Name = "MandS"
		Me.RWDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.RWDir.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.RWDir.Text = "To RoboWar Directory"
		Me.RWDir.Size = New System.Drawing.Size(121, 17)
		Me.RWDir.Location = New System.Drawing.Point(8, 360)
		Me.RWDir.TabIndex = 18
		Me.RWDir.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RWDir.CausesValidation = True
		Me.RWDir.Enabled = True
		Me.RWDir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.RWDir.Cursor = System.Windows.Forms.Cursors.Default
		Me.RWDir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.RWDir.TabStop = True
		Me.RWDir.Name = "RWDir"
		Me.Run.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Run.BackColor = System.Drawing.Color.FromARGB(132, 194, 219)
		Me.Run.Text = "Run"
		Me.Run.Size = New System.Drawing.Size(49, 33)
		Me.Run.Location = New System.Drawing.Point(520, 456)
		Me.Run.TabIndex = 17
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
		Me.RemoveRobot.Size = New System.Drawing.Size(49, 33)
		Me.RemoveRobot.Location = New System.Drawing.Point(400, 435)
		Me.RemoveRobot.TabIndex = 16
		Me.RemoveRobot.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RemoveRobot.CausesValidation = True
		Me.RemoveRobot.Enabled = True
		Me.RemoveRobot.ForeColor = System.Drawing.SystemColors.ControlText
		Me.RemoveRobot.Cursor = System.Windows.Forms.Cursors.Default
		Me.RemoveRobot.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.RemoveRobot.TabStop = True
		Me.RemoveRobot.Name = "RemoveRobot"
		Me.RemoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.RemoveAll.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.RemoveAll.Text = "Remove All"
		Me.RemoveAll.Size = New System.Drawing.Size(49, 33)
		Me.RemoveAll.Location = New System.Drawing.Point(456, 435)
		Me.RemoveAll.TabIndex = 15
		Me.RemoveAll.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RemoveAll.CausesValidation = True
		Me.RemoveAll.Enabled = True
		Me.RemoveAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.RemoveAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.RemoveAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.RemoveAll.TabStop = True
		Me.RemoveAll.Name = "RemoveAll"
		Me.RobotPict.BackColor = System.Drawing.Color.FromARGB(224, 239, 239)
		Me.RobotPict.ForeColor = System.Drawing.SystemColors.WindowText
		Me.RobotPict.Size = New System.Drawing.Size(32, 32)
		Me.RobotPict.Location = New System.Drawing.Point(192, 96)
		Me.RobotPict.TabIndex = 14
		Me.RobotPict.Visible = False
		Me.RobotPict.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RobotPict.Dock = System.Windows.Forms.DockStyle.None
		Me.RobotPict.CausesValidation = True
		Me.RobotPict.Enabled = True
		Me.RobotPict.Cursor = System.Windows.Forms.Cursors.Default
		Me.RobotPict.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.RobotPict.TabStop = True
		Me.RobotPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.RobotPict.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.RobotPict.Name = "RobotPict"
		Me.GroupNR.AutoSize = False
		Me.GroupNR.Size = New System.Drawing.Size(41, 19)
		Me.GroupNR.Location = New System.Drawing.Point(112, 416)
		Me.GroupNR.TabIndex = 9
		Me.GroupNR.Text = "20"
		Me.GroupNR.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupNR.AcceptsReturn = True
		Me.GroupNR.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.GroupNR.BackColor = System.Drawing.SystemColors.Window
		Me.GroupNR.CausesValidation = True
		Me.GroupNR.Enabled = True
		Me.GroupNR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.GroupNR.HideSelection = True
		Me.GroupNR.ReadOnly = False
		Me.GroupNR.Maxlength = 0
		Me.GroupNR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.GroupNR.MultiLine = False
		Me.GroupNR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.GroupNR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.GroupNR.TabStop = True
		Me.GroupNR.Visible = True
		Me.GroupNR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.GroupNR.Name = "GroupNR"
		Me.DuelsNR.AutoSize = False
		Me.DuelsNR.Size = New System.Drawing.Size(41, 19)
		Me.DuelsNR.Location = New System.Drawing.Point(8, 416)
		Me.DuelsNR.TabIndex = 8
		Me.DuelsNR.Text = "20"
		Me.DuelsNR.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DuelsNR.AcceptsReturn = True
		Me.DuelsNR.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.DuelsNR.BackColor = System.Drawing.SystemColors.Window
		Me.DuelsNR.CausesValidation = True
		Me.DuelsNR.Enabled = True
		Me.DuelsNR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.DuelsNR.HideSelection = True
		Me.DuelsNR.ReadOnly = False
		Me.DuelsNR.Maxlength = 0
		Me.DuelsNR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.DuelsNR.MultiLine = False
		Me.DuelsNR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DuelsNR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.DuelsNR.TabStop = True
		Me.DuelsNR.Visible = True
		Me.DuelsNR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.DuelsNR.Name = "DuelsNR"
		Me.AddAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.AddAll.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.AddAll.Text = "Choose all as opponents"
		Me.AddAll.Size = New System.Drawing.Size(73, 33)
		Me.AddAll.Location = New System.Drawing.Point(320, 435)
		Me.AddAll.TabIndex = 7
		Me.AddAll.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AddAll.CausesValidation = True
		Me.AddAll.Enabled = True
		Me.AddAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.AddAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.AddAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.AddAll.TabStop = True
		Me.AddAll.Name = "AddAll"
		Me.Add_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Add_Renamed.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.Add_Renamed.Text = "Choose for opponent"
		Me.Add_Renamed.Size = New System.Drawing.Size(65, 33)
		Me.Add_Renamed.Location = New System.Drawing.Point(232, 435)
		Me.Add_Renamed.TabIndex = 6
		Me.Add_Renamed.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Add_Renamed.CausesValidation = True
		Me.Add_Renamed.Enabled = True
		Me.Add_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Add_Renamed.Cursor = System.Windows.Forms.Cursors.Default
		Me.Add_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Add_Renamed.TabStop = True
		Me.Add_Renamed.Name = "Add_Renamed"
		Me.Testing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Testing.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.Testing.Text = "Choose for testing"
		Me.Testing.Size = New System.Drawing.Size(57, 33)
		Me.Testing.Location = New System.Drawing.Point(168, 56)
		Me.Testing.TabIndex = 4
		Me.Testing.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Testing.CausesValidation = True
		Me.Testing.Enabled = True
		Me.Testing.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Testing.Cursor = System.Windows.Forms.Cursors.Default
		Me.Testing.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Testing.TabStop = True
		Me.Testing.Name = "Testing"
		Me.RobotList.Size = New System.Drawing.Size(161, 384)
		Me.RobotList.Location = New System.Drawing.Point(400, 48)
		Me.RobotList.TabIndex = 3
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
		Me.RobotList.TabStop = True
		Me.RobotList.Visible = True
		Me.RobotList.MultiColumn = False
		Me.RobotList.Name = "RobotList"
		Me.File1.Size = New System.Drawing.Size(161, 383)
		Me.File1.Location = New System.Drawing.Point(232, 48)
		Me.File1.Pattern = "*.RWR"
		Me.File1.TabIndex = 2
		Me.File1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.File1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.File1.Archive = True
		Me.File1.BackColor = System.Drawing.SystemColors.Window
		Me.File1.CausesValidation = True
		Me.File1.Enabled = True
		Me.File1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.File1.Hidden = False
		Me.File1.Cursor = System.Windows.Forms.Cursors.Default
		Me.File1.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.File1.Normal = True
		Me.File1.ReadOnly = True
		Me.File1.System = False
		Me.File1.TabStop = True
		Me.File1.TopIndex = 0
		Me.File1.Visible = True
		Me.File1.Name = "File1"
		Me.Dir1.Size = New System.Drawing.Size(137, 306)
		Me.Dir1.Location = New System.Drawing.Point(8, 48)
		Me.Dir1.TabIndex = 1
		Me.Dir1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Dir1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Dir1.BackColor = System.Drawing.SystemColors.Window
		Me.Dir1.CausesValidation = True
		Me.Dir1.Enabled = True
		Me.Dir1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Dir1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Dir1.TabStop = True
		Me.Dir1.Visible = True
		Me.Dir1.Name = "Dir1"
		Me.Drive1.Size = New System.Drawing.Size(81, 21)
		Me.Drive1.Location = New System.Drawing.Point(16, 16)
		Me.Drive1.TabIndex = 0
		Me.Drive1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Drive1.BackColor = System.Drawing.SystemColors.Window
		Me.Drive1.CausesValidation = True
		Me.Drive1.Enabled = True
		Me.Drive1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Drive1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Drive1.TabStop = True
		Me.Drive1.Visible = True
		Me.Drive1.Name = "Drive1"
		Me.CommonDialogSelectLocationSave.Title = "Please choose a location for the tournament results text file"
		Me.CommonDialogSelectLocationSave.FileName = "Tournament Results"
		Me.CommonDialogSelectLocationSave.Filter = "Text File (.txt)|*.txt|"
		Me.AskBeforeOverwriting.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.AskBeforeOverwriting.Text = "Ask before overwriting results file"
		Me.AskBeforeOverwriting.ForeColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.AskBeforeOverwriting.Size = New System.Drawing.Size(201, 14)
		Me.AskBeforeOverwriting.Location = New System.Drawing.Point(8, 450)
		Me.AskBeforeOverwriting.TabIndex = 25
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
		Me.TeamTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.TeamTest.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.TeamTest.Text = "Teams"
		Me.TeamTest.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.TeamTest.Size = New System.Drawing.Size(57, 17)
		Me.TeamTest.Location = New System.Drawing.Point(168, 232)
		Me.TeamTest.TabIndex = 27
		Me.TeamTest.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TeamTest.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.TeamTest.CausesValidation = True
		Me.TeamTest.Enabled = True
		Me.TeamTest.Cursor = System.Windows.Forms.Cursors.Default
		Me.TeamTest.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TeamTest.Appearance = System.Windows.Forms.Appearance.Normal
		Me.TeamTest.TabStop = True
		Me.TeamTest.Checked = False
		Me.TeamTest.Visible = True
		Me.TeamTest.Name = "TeamTest"
		Me.SavedInFolder.Text = "C:\Program Files\RoboWar 5\Test Results.txt"
		Me.SavedInFolder.ForeColor = System.Drawing.Color.White
		Me.SavedInFolder.Size = New System.Drawing.Size(318, 29)
		Me.SavedInFolder.Location = New System.Drawing.Point(128, 472)
		Me.SavedInFolder.TabIndex = 24
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
		Me.ResultsSavedIn.Text = "Results will be saved in"
		Me.ResultsSavedIn.ForeColor = System.Drawing.Color.White
		Me.ResultsSavedIn.Size = New System.Drawing.Size(113, 17)
		Me.ResultsSavedIn.Location = New System.Drawing.Point(8, 472)
		Me.ResultsSavedIn.TabIndex = 23
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
		Me.Shape2.BorderWidth = 2
		Me.Shape2.Size = New System.Drawing.Size(111, 57)
		Me.Shape2.Location = New System.Drawing.Point(109, 384)
		Me.Shape2.CornerRadius = 7
		Me.Shape2.BackColor = System.Drawing.SystemColors.Window
		Me.Shape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent
		Me.Shape2.BorderColor = System.Drawing.SystemColors.WindowText
		Me.Shape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Shape2.FillColor = System.Drawing.Color.Black
		Me.Shape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me.Shape2.Visible = True
		Me.Shape2.Name = "Shape2"
		Me.Label1.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.Label1.Text = "Test against:"
		Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.Label1.Size = New System.Drawing.Size(81, 17)
		Me.Label1.Location = New System.Drawing.Point(400, 32)
		Me.Label1.TabIndex = 19
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Shape1.BorderWidth = 2
		Me.Shape1.Size = New System.Drawing.Size(102, 57)
		Me.Shape1.Location = New System.Drawing.Point(5, 384)
		Me.Shape1.CornerRadius = 7
		Me.Shape1.BackColor = System.Drawing.SystemColors.Window
		Me.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent
		Me.Shape1.BorderColor = System.Drawing.SystemColors.WindowText
		Me.Shape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Shape1.FillColor = System.Drawing.Color.Black
		Me.Shape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me.Shape1.Visible = True
		Me.Shape1.Name = "Shape1"
		Me.Label5.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.Label5.Text = "Times"
		Me.Label5.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.Label5.Size = New System.Drawing.Size(49, 17)
		Me.Label5.Location = New System.Drawing.Point(160, 416)
		Me.Label5.TabIndex = 13
		Me.Label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.Enabled = True
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.Label4.Text = "Times"
		Me.Label4.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.Label4.Size = New System.Drawing.Size(49, 17)
		Me.Label4.Location = New System.Drawing.Point(56, 416)
		Me.Label4.TabIndex = 12
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.Label3.Text = "Grouprounds - Robots meet each others"
		Me.Label3.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.Label3.Size = New System.Drawing.Size(105, 33)
		Me.Label3.Location = New System.Drawing.Point(112, 384)
		Me.Label3.TabIndex = 11
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.Label2.Text = "Duels - Robots meet each other"
		Me.Label2.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.Label2.Size = New System.Drawing.Size(97, 33)
		Me.Label2.Location = New System.Drawing.Point(8, 384)
		Me.Label2.TabIndex = 10
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.WhoIsTested.BackColor = System.Drawing.Color.FromARGB(58, 65, 90)
		Me.WhoIsTested.Text = "No Robot is chosen for testing"
		Me.WhoIsTested.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.WhoIsTested.ForeColor = System.Drawing.Color.FromARGB(250, 250, 250)
		Me.WhoIsTested.Size = New System.Drawing.Size(457, 24)
		Me.WhoIsTested.Location = New System.Drawing.Point(120, 8)
		Me.WhoIsTested.TabIndex = 5
		Me.WhoIsTested.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.WhoIsTested.Enabled = True
		Me.WhoIsTested.Cursor = System.Windows.Forms.Cursors.Default
		Me.WhoIsTested.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WhoIsTested.UseMnemonic = True
		Me.WhoIsTested.Visible = True
		Me.WhoIsTested.AutoSize = False
		Me.WhoIsTested.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WhoIsTested.Name = "WhoIsTested"
		Me.Controls.Add(TheDirList)
		Me.Controls.Add(PrintLog)
		Me.Controls.Add(NormalTest)
		Me.Controls.Add(ChangeLocation)
		Me.Controls.Add(CheckScoring)
		Me.Controls.Add(MandS)
		Me.Controls.Add(RWDir)
		Me.Controls.Add(Run)
		Me.Controls.Add(RemoveRobot)
		Me.Controls.Add(RemoveAll)
		Me.Controls.Add(RobotPict)
		Me.Controls.Add(GroupNR)
		Me.Controls.Add(DuelsNR)
		Me.Controls.Add(AddAll)
		Me.Controls.Add(Add_Renamed)
		Me.Controls.Add(Testing)
		Me.Controls.Add(RobotList)
		Me.Controls.Add(File1)
		Me.Controls.Add(Dir1)
		Me.Controls.Add(Drive1)
		Me.Controls.Add(AskBeforeOverwriting)
		Me.Controls.Add(TeamTest)
		Me.Controls.Add(SavedInFolder)
		Me.Controls.Add(ResultsSavedIn)
		Me.ShapeContainer1.Shapes.Add(Shape2)
		Me.Controls.Add(Label1)
		Me.ShapeContainer1.Shapes.Add(Shape1)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(WhoIsTested)
		Me.Controls.Add(ShapeContainer1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class