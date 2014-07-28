<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class CreatingLog
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
	Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents Percent As System.Windows.Forms.Label
	Public WithEvents Progress As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CreatingLog))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Cancel = New System.Windows.Forms.Button
		Me.Percent = New System.Windows.Forms.Label
		Me.Progress = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Creating Tournament Log"
		Me.ClientSize = New System.Drawing.Size(254, 29)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "CreatingLog"
		Me.Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Cancel.Text = "Cancel"
		Me.Cancel.Size = New System.Drawing.Size(81, 25)
		Me.Cancel.Location = New System.Drawing.Point(170, 2)
		Me.Cancel.TabIndex = 0
		Me.Cancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Cancel.BackColor = System.Drawing.SystemColors.Control
		Me.Cancel.CausesValidation = True
		Me.Cancel.Enabled = True
		Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Cancel.TabStop = True
		Me.Cancel.Name = "Cancel"
		Me.Percent.Text = "%"
		Me.Percent.Size = New System.Drawing.Size(14, 17)
		Me.Percent.Location = New System.Drawing.Point(18, 8)
		Me.Percent.TabIndex = 2
		Me.Percent.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Percent.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Percent.BackColor = System.Drawing.SystemColors.Control
		Me.Percent.Enabled = True
		Me.Percent.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Percent.Cursor = System.Windows.Forms.Cursors.Default
		Me.Percent.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Percent.UseMnemonic = True
		Me.Percent.Visible = True
		Me.Percent.AutoSize = False
		Me.Percent.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Percent.Name = "Percent"
		Me.Progress.Text = "100"
		Me.Progress.Size = New System.Drawing.Size(22, 17)
		Me.Progress.Location = New System.Drawing.Point(0, 8)
		Me.Progress.TabIndex = 1
		Me.Progress.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Progress.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Progress.BackColor = System.Drawing.SystemColors.Control
		Me.Progress.Enabled = True
		Me.Progress.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Progress.Cursor = System.Windows.Forms.Cursors.Default
		Me.Progress.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Progress.UseMnemonic = True
		Me.Progress.Visible = True
		Me.Progress.AutoSize = False
		Me.Progress.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Progress.Name = "Progress"
		Me.Controls.Add(Cancel)
		Me.Controls.Add(Percent)
		Me.Controls.Add(Progress)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class