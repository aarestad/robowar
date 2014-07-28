<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class TournamentResults
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
	Public WithEvents OKButton As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TournamentResults))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.OKButton = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.FromARGB(181, 200, 208)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Tournament Results"
		Me.ClientSize = New System.Drawing.Size(238, 365)
		Me.Location = New System.Drawing.Point(184, 250)
		Me.Icon = CType(resources.GetObject("TournamentResults.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "TournamentResults"
		Me.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.OKButton.BackColor = System.Drawing.Color.FromARGB(134, 157, 202)
		Me.CancelButton = Me.OKButton
		Me.OKButton.Text = "OK"
		Me.AcceptButton = Me.OKButton
		Me.OKButton.Size = New System.Drawing.Size(81, 25)
		Me.OKButton.Location = New System.Drawing.Point(152, 336)
		Me.OKButton.TabIndex = 0
		Me.OKButton.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OKButton.CausesValidation = True
		Me.OKButton.Enabled = True
		Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OKButton.TabStop = True
		Me.OKButton.Name = "OKButton"
		Me.Controls.Add(OKButton)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class