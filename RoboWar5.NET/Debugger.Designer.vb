<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class DebuggingWindow
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
	Public WithEvents TerminateDebugging As System.Windows.Forms.Button
	Public WithEvents Ints As System.Windows.Forms.PictureBox
	Public WithEvents ChrononStep As System.Windows.Forms.Button
	Public WithEvents StopDebugging As System.Windows.Forms.Button
	Public WithEvents Step_Renamed As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DebuggingWindow))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.TerminateDebugging = New System.Windows.Forms.Button
		Me.Ints = New System.Windows.Forms.PictureBox
		Me.ChrononStep = New System.Windows.Forms.Button
		Me.StopDebugging = New System.Windows.Forms.Button
		Me.Step_Renamed = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.FromARGB(207, 233, 219)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Debug"
		Me.ClientSize = New System.Drawing.Size(193, 416)
		Me.Location = New System.Drawing.Point(336, 29)
		Me.Icon = CType(resources.GetObject("DebuggingWindow.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "DebuggingWindow"
		Me.TerminateDebugging.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.TerminateDebugging.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.TerminateDebugging.Text = "Terminate"
		Me.TerminateDebugging.Size = New System.Drawing.Size(89, 17)
		Me.TerminateDebugging.Location = New System.Drawing.Point(104, 392)
		Me.TerminateDebugging.TabIndex = 3
		Me.TerminateDebugging.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TerminateDebugging.CausesValidation = True
		Me.TerminateDebugging.Enabled = True
		Me.TerminateDebugging.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TerminateDebugging.Cursor = System.Windows.Forms.Cursors.Default
		Me.TerminateDebugging.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TerminateDebugging.TabStop = True
		Me.TerminateDebugging.Name = "TerminateDebugging"
		Me.Ints.BackColor = System.Drawing.Color.FromARGB(182, 201, 188)
		Me.Ints.Size = New System.Drawing.Size(89, 161)
		Me.Ints.Location = New System.Drawing.Point(104, 195)
		Me.Ints.TabIndex = 4
		Me.Ints.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Ints.Dock = System.Windows.Forms.DockStyle.None
		Me.Ints.CausesValidation = True
		Me.Ints.Enabled = True
		Me.Ints.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Ints.Cursor = System.Windows.Forms.Cursors.Default
		Me.Ints.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Ints.TabStop = True
		Me.Ints.Visible = True
		Me.Ints.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Ints.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Ints.Name = "Ints"
		Me.ChrononStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ChrononStep.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.ChrononStep.Text = "Chronon"
		Me.ChrononStep.Size = New System.Drawing.Size(89, 25)
		Me.ChrononStep.Location = New System.Drawing.Point(104, 360)
		Me.ChrononStep.TabIndex = 1
		Me.ChrononStep.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ChrononStep.CausesValidation = True
		Me.ChrononStep.Enabled = True
		Me.ChrononStep.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChrononStep.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChrononStep.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChrononStep.TabStop = True
		Me.ChrononStep.Name = "ChrononStep"
		Me.StopDebugging.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.StopDebugging.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.CancelButton = Me.StopDebugging
		Me.StopDebugging.Text = "Stop Debugging"
		Me.StopDebugging.Size = New System.Drawing.Size(89, 17)
		Me.StopDebugging.Location = New System.Drawing.Point(8, 392)
		Me.StopDebugging.TabIndex = 2
		Me.StopDebugging.TabStop = False
		Me.StopDebugging.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.StopDebugging.CausesValidation = True
		Me.StopDebugging.Enabled = True
		Me.StopDebugging.ForeColor = System.Drawing.SystemColors.ControlText
		Me.StopDebugging.Cursor = System.Windows.Forms.Cursors.Default
		Me.StopDebugging.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.StopDebugging.Name = "StopDebugging"
		Me.Step_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Step_Renamed.BackColor = System.Drawing.Color.FromARGB(180, 210, 228)
		Me.Step_Renamed.Text = "Step"
		Me.AcceptButton = Me.Step_Renamed
		Me.Step_Renamed.Size = New System.Drawing.Size(89, 25)
		Me.Step_Renamed.Location = New System.Drawing.Point(8, 360)
		Me.Step_Renamed.TabIndex = 0
		Me.Step_Renamed.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Step_Renamed.CausesValidation = True
		Me.Step_Renamed.Enabled = True
		Me.Step_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Step_Renamed.Cursor = System.Windows.Forms.Cursors.Default
		Me.Step_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Step_Renamed.TabStop = True
		Me.Step_Renamed.Name = "Step_Renamed"
		Me.Controls.Add(TerminateDebugging)
		Me.Controls.Add(Ints)
		Me.Controls.Add(ChrononStep)
		Me.Controls.Add(StopDebugging)
		Me.Controls.Add(Step_Renamed)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class