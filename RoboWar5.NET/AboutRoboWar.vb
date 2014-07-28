Option Strict Off
Option Explicit On
Friend Class AboutRoboWar
	Inherits System.Windows.Forms.Form
	Const sThanksTo As String = "Christian Bauer, Lauri Pesonen," & vbCr & "Bernd Schmidt" & vbCr & "David Harris" & vbCr & "Dave Brasgalla" & vbCr & "Stefan Arvidsson, Jesper Ek" & vbCr & "Jost Schwider" & vbCr & "Danny K. - www.xi0n.com" & vbCr & "Brad Martinez - btmtz.mvps.org" & vbCr & "Wpsjr1 - www.syix.com/wpsjr1/" & vbCr & "www.vb-helper.com" & vbCr & "www.freevbcode.com" & vbCr & "www.developerfusion.co.uk" & vbCr & "www.xbeat.net/vbspeed/" & vbCr & "www.innosetup.com"
	
	Const sSpecialThanksTo As String = "Camden Elliott-Williams" & vbCr & "Sam Rushing" & vbCr & "David Forslund" & vbCr & "BlueOwl" & vbCr & "Eric Foley" & vbCr & "Viktor Tullgren" & vbCr & "Themo Therzis" & vbCr & "Edward Marchant" & vbCr & "Randy Munroe" & vbCr & "Joacim Andersson" & vbCr & "OnErrOr" & vbCr & "Austin Barton" & vbCr & "Charlie Davis" & vbCr & "Lucas Dixon" & vbCr & "Hans Nicander" & vbCr & vbCr
	
	Private Sub Close_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Close_Renamed.Click
		Me.Close()
	End Sub
	
	Private Sub AboutRoboWar_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'UPGRADE_WARNING: App property App.EXEName has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		If UCase(My.Application.Info.AssemblyName) = "ROBOWAR 5" Then 'Made it Win98 Compatible
			Version.Text = "Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
		Else
			'UPGRADE_WARNING: App property App.EXEName has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			Version.Text = "Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision & vbCr & "Debug: " & Replace(My.Application.Info.AssemblyName, "RoboWar 5 ", "",  ,  , CompareMethod.Text)
		End If
		
		'If App.EXEName = "RoboWar 5" Then
		'    Version = "Version " & App.Major & "." & App.Minor & "." & App.Revision
		'Else
		'    Version = "Version " & App.Major & "." & App.Minor & "." & App.Revision & vbCr & _
		''    "Debug: " & Replace(App.EXEName, "RoboWar 5 ", "")
		'End If
		
		ThanksTo.Text = sThanksTo
		SpecialThanksTo.Text = sSpecialThanksTo
		
	End Sub
End Class