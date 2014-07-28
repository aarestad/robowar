<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class RWOLpen
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
	Public WithEvents WinByMe As System.Windows.Forms.Label
	Public WithEvents RoboWar As System.Windows.Forms.PictureBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RWOLpen))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.WinByMe = New System.Windows.Forms.Label
		Me.RoboWar = New System.Windows.Forms.PictureBox
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.Black
		Me.Text = "RoboWar 5"
		Me.ClientSize = New System.Drawing.Size(735, 445)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.Icon = CType(resources.GetObject("RWOLpen.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MinimizeBox = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.Name = "RWOLpen"
		Me.WinByMe.Text = "Windows version by Kevin Hertzberg"
		Me.WinByMe.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.WinByMe.Size = New System.Drawing.Size(265, 25)
		Me.WinByMe.Location = New System.Drawing.Point(208, 184)
		Me.WinByMe.TabIndex = 0
		Me.WinByMe.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.WinByMe.BackColor = System.Drawing.Color.Transparent
		Me.WinByMe.Enabled = True
		Me.WinByMe.ForeColor = System.Drawing.SystemColors.ControlText
		Me.WinByMe.Cursor = System.Windows.Forms.Cursors.Default
		Me.WinByMe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.WinByMe.UseMnemonic = True
		Me.WinByMe.Visible = True
		Me.WinByMe.AutoSize = False
		Me.WinByMe.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.WinByMe.Name = "WinByMe"
		Me.RoboWar.Size = New System.Drawing.Size(640, 432)
		Me.RoboWar.Location = New System.Drawing.Point(0, 0)
		Me.RoboWar.Image = CType(resources.GetObject("RoboWar.Image"), System.Drawing.Image)
		Me.RoboWar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.RoboWar.Enabled = True
		Me.RoboWar.Cursor = System.Windows.Forms.Cursors.Default
		Me.RoboWar.Visible = True
		Me.RoboWar.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.RoboWar.Name = "RoboWar"
		Me.Controls.Add(WinByMe)
		Me.Controls.Add(RoboWar)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class