Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class MainWindow
	Inherits System.Windows.Forms.Form
	'               ##################
	'            ####        ############
	'          ##            ##############                 R O B O W A R  5
	'        ##              ################
	'       ##               #################             By Kevin Hertzberg
	'      ##                ##################
	'      ##                ##################           A Windows port of the Mac game RoboWar
	'     ##                 ###################
	'    ##                              ########
	'    ##      ################################
	'    ##                  ####################
	'     ##                 ###################
	'      ##                ##################
	'      ##                ##################
	'      ##                ##################
	'      ##                      ############
	'       ##         ##        #############
	'        ##          ###################
	'          ##            ##############
	'            ##          ############
	'              ###       #########
	'                 ###############
	'              Dialectix is a hero,
	'         for all the dashers it killed.
	'
	'           + this "picture" is nice
	
	'Thanks for reading the source code for RoboWar 5. If you have suggestions for
	'improvements, you could email me at khertzberg@spray.se.
	
	'Here's some things you should know about the code:
	
	'I priorotize somewhat differently compared to the general standard
	
	'Highest priority are Remove bugs, Backwards compatibility with the old version,
	'Speed in non-displayed battles and tournaments, Confortability for the players
	'Code maintability, Code readability are having lower priority
	
	'Some people have expressed that the combat / dontshowbattle subroutines would be
	'way easier to read if I split them up in subroutines. Calling subroutines is slower!
	
	'The code for the following parts are messy and poorly written, but
	'since the code works, optimizing it will only create more bugs:
	'Loading, Closing, Duplicating, Save As, Renaming and the Tournament Engine
	'Some of the code comments might also be a little outdated
	
	
	' **** API CALL'S DECLARATIONS
	
	' PEEKMESSAGE API   -   To increase battle speed
	'looks at message and removes/leaves it if there is one
	'returns nonzero if a message was in event queue
	'UPGRADE_WARNING: Structure MSG may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function PeekMessage Lib "user32"  Alias "PeekMessageA"(ByRef lpMsg As MSG, ByVal hwnd As Integer, ByVal wMsgFilterMin As Integer, ByVal wMsgFilterMax As Integer, ByVal wRemoveMsg As Integer) As Integer
	'                                 'dispatches message calls the right message handling procedure
	'Private Declare Function DispatchMessage Lib "user32" Alias "DispatchMessageA" (lpMsg As MSG) As Long
	'                                 'virtual accelerator key translator
	'                                 'dont worry about what it does just leave it there
	'Private Declare Function TranslateMessage Lib "user32" (lpMsg As MSG) As Long
	'                                 'holds elapsed time since windows was started
	'Private Declare Function GetTickCount Lib "kernel32" () As Long
	'                                 'gets next message in event queue
	'Private Declare Function GetMessage Lib "user32" Alias "GetMessageA" (lpMsg As MSG, ByVal hwnd As Long, ByVal wMsgFilterMin As Long, ByVal wMsgFilterMax As Long) As Long
	'                                 'checks if there is a message in event queue
	'Private Declare Function GetQueueStatus Lib "user32" (ByVal fuFlags As Long) As Long
	
	
	'Private Const MY_WM_QUIT = &HA1     'WM_QUIT in api viewer is wrong this is the right constant
	'
	'Private Const PM_REMOVE = &H1       'paramater on peekmessage to remove or leave message in queue
	Private Const PM_NOREMOVE As Integer = &H0
	'                                    'type of events that can happen with window
	'Private Const QS_MOUSEBUTTON = &H4
	'Private Const QS_MOUSEMOVE = &H2
	'Private Const QS_PAINT = &H20
	'Private Const QS_POSTMESSAGE = &H8  'any other message
	'Private Const QS_TIMER = &H10
	'Private Const QS_HOTKEY = &H80
	'Private Const QS_KEY = &H1
	'Private Const QS_MOUSE = (QS_MOUSEMOVE Or QS_MOUSEBUTTON)
	'Private Const QS_INPUT = (QS_MOUSE Or QS_KEY)
	'Private Const QS_ALLEVENTS = (QS_INPUT Or QS_POSTMESSAGE Or QS_TIMER Or QS_PAINT Or QS_HOTKEY)
	'
	''extra messages that can be sent (not used in example)
	'Private Const QS_SENDMESSAGE = &H40    'message sent by other thread or app
	'Private Const QS_ALLINPUT = (QS_SENDMESSAGE Or QS_PAINT Or QS_TIMER Or QS_POSTMESSAGE Or QS_MOUSEBUTTON Or QS_MOUSEMOVE Or QS_HOTKEY Or QS_KEY)
	''*************************
	
	Private Structure POINTAPI
		Dim X As Integer
		Dim Y As Integer
	End Structure
	
	Private Structure MSG
		Dim hwnd As Integer 'window where message occured
		Dim Message As Integer 'message id itself
		Dim wParam As Integer 'further defines message
		Dim lParam As Integer 'further defines message
		Dim time As Integer 'time of message event
		Dim pt As POINTAPI 'position of mouse
	End Structure
	
	Dim Message As MSG 'holds message recieved from queue
	
	' SNDPLAYSOUND API      -       To play sounds (no kidding?)
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    Private Declare Function sndPlaySound Lib "winmm" Alias "sndPlaySoundA" (ByRef SoundData As Byte, ByVal uFlags As Integer) As Integer
	'Then we have to declare the constants that go along with the sndPlaySound function
	Const SND_ASYNC As Integer = &H1 'ASYNC allows us to play waves with the ability to interrupt
	'Const SND_LOOP = &H8        'LOOP causes to sound to be continuously replayed
	Const SND_NODEFAULT As Integer = &H2 'NODEFAULT causes no sound to be played if the wav can't be found
	'Const SND_SYNC = &H0        'SYNC plays a wave file without returning control to the calling program until it's finished
	'Const SND_NOSTOP = &H10     'NOSTOP ensures that we don't stop another wave from playing
	Const SND_MEMORY As Integer = &H4 'MEMORY plays a wave file stored in memory
	
	' **** GOBAL / MODULE LEVEL DECLARATIONS (NON API)
	
	'New RWR file format constants
	Const sndrec As Short = 32
	Const iconrec As Short = 72
	Const MCrec As Short = 112
	Const Crec As Short = 116
	Const zeroexists As Short = 130 'same as iconspresent
	Const soundspresent As Short = 120
	Const recsoundstartzero As Short = 142 'Where we will find sound 0
	'Const CPosrec = 28
	
	'The weapon constans, so we don't have to keep in mind which weapon represented by which number
	Const Missile As Integer = 0
	Const Hellbore As Integer = 1
	Const Bullet As Integer = 2 'Used for Rubber bullets too
	Const ExplosiveBullet As Integer = 3
	Const XplosiveBulletDetonation As Integer = 4 'Detonation
	Const Mine As Integer = 5
	Const TakeNuke As Integer = 6
	Const Stunner As Integer = 7
	Const Laser As Integer = 208 'Higher than 199 won't show up on the radar
	Const Drone As Integer = 9
	Const MegaNuke As Integer = 10
	Const NOSHOT As Integer = 200
	Const SHOTHIT As Integer = 150
	
	'Adjustment constants for the new weapons
	Const MegaNukeBLASTRADIUS As Short = 20
	Const MegaNukePOWER As Double = 1.5
	Const MegaNukeOUTERRINGCOLOR As Integer = &HFF80FF
	Const MegaNukeFILLCOLOR As Integer = &HFFC0FF
	
	'Instructions constants - Magic Numbers
	Const insPLUS As Short = 20000
	Const insMINUS As Short = 20001
	Const insTIMES As Short = 20002
	Const insDIVISION As Short = 20003
	Const insMORE As Short = 20004
	Const insLESS As Short = 20005
	Const insSAME As Short = 20006
	Const insNOT_SAME As Short = 20007
	Const insSTORE As Short = 20100
	Const insDROP As Short = 20101
	Const insSWAP As Short = 20102
	Const insROLL As Short = 20103
	Const insJUMP As Short = 20104
	Const insCALL As Short = 20105
	Const insDUP As Short = 20106
	Const insIF As Short = 20107
	Const insIFE As Short = 20108
	Const insRECALL As Short = 20109
	Const insEND As Short = 20110
	Const insNOP As Short = 20111
	Const insAND As Short = 20112
	Const insOR As Short = 20113
	Const insXOR As Short = 20114
	Const insMOD As Short = 20115
	Const insBEEP As Short = 20116
	Const insCHS As Short = 20117
	Const insNOT As Short = 20118
	Const insARCTAN As Short = 20119
	Const insABS As Short = 20120
	Const insSIN As Short = 20121
	Const insCOS As Short = 20122
	Const insTAN As Short = 20123
	Const insSQRT As Short = 20124
	Const insICON0 As Short = 20125
	Const insICON1 As Short = 20126
	Const insICON2 As Short = 20127
	Const insICON3 As Short = 20128
	Const insICON4 As Short = 20129
	Const insICON5 As Short = 20130
	Const insICON6 As Short = 20131
	Const insICON7 As Short = 20132
	Const insICON8 As Short = 20133
	Const insICON9 As Short = 20134
	Const insPRINT As Short = 20135
	Const insSYNC As Short = 20136
	Const insVSTORE As Short = 20137
	Const insVRECALL As Short = 20138
	Const insDIST As Short = 20139
	Const insIFG As Short = 20140
	Const insIFEG As Short = 20141
	Const insDEBUG As Short = 20142
	Const insSND0 As Short = 20143
	Const insSND1 As Short = 20144
	Const insSND2 As Short = 20145
	Const insSND3 As Short = 20146
	Const insSND4 As Short = 20147
	Const insSND5 As Short = 20148
	Const insSND6 As Short = 20149
	Const insSND7 As Short = 20150
	Const insSND8 As Short = 20151
	Const insSND9 As Short = 20152
	Const insINTON As Short = 20153
	Const insINTOFF As Short = 20154
	Const insRTI As Short = 20155
	Const insSETINT As Short = 20156
	Const insSETPARAM As Short = 20157
	'Const insMRB = 20158
	Const insDROPALL As Short = 20159
	Const insFLUSHINT As Short = 20160
	Const insMAX As Short = 20161
	Const insMIN As Short = 20162
	Const insARCCOS As Short = 20163
	Const insARCSIN As Short = 20164
	Const insA As Short = 20300
	Const insB As Short = 20301
	Const insC As Short = 20302
	Const insD As Short = 20303
	Const insE As Short = 20304
	Const insF As Short = 20305
	Const insG As Short = 20306
	Const insH As Short = 20307
	Const insI As Short = 20308
	Const insJ As Short = 20309
	Const insK As Short = 20310
	Const insL As Short = 20311
	Const insM As Short = 20312
	Const insN As Short = 20313
	Const insO As Short = 20314
	Const insP As Short = 20315
	Const insQ As Short = 20316
	Const insR As Short = 20317
	Const insS As Short = 20318
	Const Inst As Short = 20319
	Const insU As Short = 20320
	Const insV As Short = 20321
	Const insW As Short = 20322
	Const insX As Short = 20323
	Const insY As Short = 20324
	Const insZ As Short = 20325
	Const insFIRE As Short = 20326
	Const insENERGY As Short = 20327
	Const insSHIELD As Short = 20328
	Const insRANGE As Short = 20329
	Const insAIM As Short = 20330
	Const insSPEEDX As Short = 20331
	Const insSPEEDY As Short = 20332
	Const insDAMAGE As Short = 20333
	Const insRANDOM As Short = 20334
	Const insMISSILE As Short = 20335
	Const insNUKE As Short = 20336
	Const insCOLLISION As Short = 20337
	Const insCHANNEL As Short = 20338
	Const insSIGNAL As Short = 20339
	Const insMOVEX As Short = 20340
	Const insMOVEY As Short = 20341
	'Const insJOCE = 20342
	Const insRADAR As Short = 20343
	Const insLOOK As Short = 20344
	Const insSCAN As Short = 20345
	Const insCHRONON As Short = 20346
	Const insHELLBORE As Short = 20347
	Const insDRONE As Short = 20348
	Const insMINE As Short = 20349
	Const insLASER As Short = 20350
	'Const insSUSIE = 20351
	Const insROBOTS As Short = 20352
	Const insFRIEND As Short = 20353
	Const insBULLET As Short = 20354
	Const insDOPPLER As Short = 20355
	Const insSTUNNER As Short = 20356
	Const insTOP As Short = 20357
	Const insBOT As Short = 20358
	Const insLEFT As Short = 20359
	Const insRIGHT As Short = 20360
	Const insWALL As Short = 20361
	Const insTEAMMATES As Short = 20362
	Const insPROBE As Short = 20363
	Const insHISTORY As Short = 20364
	Const insID As Short = 20365
	Const insKILLS As Short = 20366
	
	Const insNEAREST As Short = 20367
	Const insMEGANUKE As Short = 20368
	
	Const TOPREGISTER As Short = 20368
	
	'Error Messages
	Const BuggyDivRelated As Short = 11
	Const BuggyUnknownOrIllegal As Short = 0
	Const BuggyUnderflow As Short = -1
	Const BuggyOverflow As Short = -2
	Const BuggyRecall As Short = -3
	Const BuggySquare As Short = -4
	Const BuggyDestination As Short = -5
	Const BuggyChannel As Short = -6
	Const BuggyNearest As Short = -7
	'Const BuggyUnknown = -8
	Const BuggyNumberOutofBounds As Short = -9
	Const BuggyMissiles As Short = -10
	Const BuggyDivision As Short = -11
	Const BuggyStunners As Short = -12
	Const BuggyTacNukes As Short = -13
	Const BuggyHellbores As Short = -14
	Const BuggyMines As Short = -15
	Const BuggyLasers As Short = -16
	Const BuggyDrones As Short = -17
	Const BuggyProbes As Short = -18
	Const BuggySetparam As Short = -200
	Const BuggySetint As Short = -201
	Const BuggyStore As Short = -202
	
	
	' Team Color constants
	Const ColorTeam1 As Integer = &HFF8080
	'UPGRADE_NOTE: ColorTeam2 was changed from a Constant to a Variable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"'
	Dim ColorTeam2 As System.Drawing.Color = System.Drawing.Color.Lime
	Const ColorTeam3 As Integer = &HFF
	
	' Background color
	Const BackgroundColor As Integer = &H7B511E
	
	'Trigonometry translation constants
	Const PIO As Double = 0.01745329252 'Pi / 180
	Const TPI As Double = 57.2957795131 '180 / Pi
	
	' Trig Cache
	Dim Sine(720) As Double
	Dim Cosine(720) As Double
	
	Dim Sin10(360) As Double
	Dim Cos10(360) As Double
	
	Dim Sin11(360) As Double
	Dim Cos11(360) As Double
	
	Dim Sin5(360) As Double
	Dim Cos5(360) As Double
	
	Dim Sin14(360) As Double
	Dim Cos14(360) As Double
	
	Dim Sin12(360) As Double
	Dim Cos12(360) As Double
	
	Dim Sin6(360) As Double
	Dim Cos6(360) As Double
	
	'Square Cache
	Dim Square(180000) As Double
	Dim FixSquare(180000) As Integer
	
	'Wall Collision Cache
	'UPGRADE_ISSUE: Declaration type not supported: Array with lower bound less than zero. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
	Dim WCX(-20 To 320) As Boolean
	'UPGRADE_ISSUE: Declaration type not supported: Array with lower bound less than zero. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
	Dim WCY(-20 To 320) As Boolean
	
	' Game and Preference related Stuff
	Private Structure Robot 'Object used to load robots easier
		Dim Energy As Short
		Dim Damage As Short
		Dim Shield As Short
		Dim Prosessor As Byte
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
	
	Public ResolutionChanged As Integer
	Dim DebuggedRobot As Integer
	
	Dim StartDebuggerAt As Integer
	Dim WillBeDebugged As Integer
	Const DEBUGATNOTSET As Integer = -32768
	
	Dim MaxChronon As Integer
	Public SelectedRobot As Integer
	Dim Chronon As Integer
	Dim CprTimerCount As Integer 'Used for the Chronons per second counting
	Dim PlaySounds As Boolean 'Cached Mirror of Sounds.Checked
	Dim Replaying As Boolean 'Cached Mirror of RepeatBattle.Checked
	Dim EnableOverloading As Boolean 'Cached Mirror of Overloading.Checked
	Dim MoveAndShotAllowed As Boolean 'Cached Inverted Mirror of DisallowMoveAndShoot.Checked
	Dim StandardScoring As Boolean 'True = Standard, False = 4.5.2
	Dim BattleSpeed As Single
	Dim TheSpeedConstant As Single
	Dim Draging As Integer 'Which robot is dragged around
	Dim DroneU, DroneR, DroneL, DroneD As System.Drawing.Image
	'UPGRADE_WARNING: Lower bound of array DroneDiagonally was changed from 3 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim DroneDiagonally(6) As System.Drawing.Image
	Dim NumberOfRobotsPresent As Integer
	Dim HighestToLowest As Boolean 'Which evaluation order we're using. False = Robot 1 to Robot 6, True = Robot 1 to Robot 6
	Dim RunningTournament As Boolean
	Dim DebuggerAutoStart As Boolean
	Dim HideBattle As Boolean 'Cached NoDisplay.Checked and Ultra.Checked
	Dim UltraWarning As Byte
	
	Private Structure ShotPrivateType
		Dim ShotType As Integer
		Dim ShotX As Single 'Single
		Dim ShotY As Single 'Single
		Dim ShotFireTime As Integer
		Dim ShotPower As Integer
		Dim ShotAngle As Integer
		Dim Shooter As Integer
	End Structure
	
	' Tournament Log Vars and Types
	Private Structure TournamentLogType
		<VBFixedArray(6)> Dim WhosWho() As String
		<VBFixedArray(6)> Dim killer() As Short
		<VBFixedArray(6)> Dim DeathTime() As Short
		<VBFixedArray(6)> Dim Kills() As Short
		<VBFixedArray(6)> Dim SurvivalPoints() As Short
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			'UPGRADE_WARNING: Lower bound of array WhosWho was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim WhosWho(6)
			'UPGRADE_WARNING: Lower bound of array killer was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim killer(6)
			'UPGRADE_WARNING: Lower bound of array DeathTime was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim DeathTime(6)
			'UPGRADE_WARNING: Lower bound of array Kills was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim Kills(6)
			'UPGRADE_WARNING: Lower bound of array SurvivalPoints was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim SurvivalPoints(6)
		End Sub
	End Structure
	
	Dim TournamentLog() As TournamentLogType
	Dim PrintTournamentLog As Boolean
	Dim LogWhichBattle As Integer
	Dim WindowMini As Boolean
	Dim sMainWindowCaption As String
	
	'Robot Interface Properties
	'UPGRADE_WARNING: Lower bound of array RobotTeam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotTeam(6) As Integer
	'UPGRADE_WARNING: Lower bound of array LastStartPosX was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim LastStartPosX(6) As Integer
	'UPGRADE_WARNING: Lower bound of array LastStartPosY was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim LastStartPosY(6) As Integer
	
	Dim R5Present, R3Present, R1Present, R2Present, R4Present, R6Present As Boolean
	Public R5path, R3path, R1path, R2path, R4path, R6path As String
	
	Public Robot5Energy, Robot3Energy, Robot1Energy, Robot2Energy, Robot4Energy, Robot6Energy As Integer
	Public Robot5Damage, Robot3Damage, Robot1Damage, Robot2Damage, Robot4Damage, Robot6Damage As Integer
	Public Robot5Shield, Robot3Shield, Robot1Shield, Robot2Shield, Robot4Shield, Robot6Shield As Integer
	Public Robot5ProSpeed, Robot3ProSpeed, Robot1ProSpeed, Robot2ProSpeed, Robot4ProSpeed, Robot6ProSpeed As Integer
	Public Robot5Bullets, Robot3Bullets, Robot1Bullets, Robot2Bullets, Robot4Bullets, Robot6Bullets As Integer
	Public Robot5Turret, Robot3Turret, Robot1Turret, Robot2Turret, Robot4Turret, Robot6Turret As Integer
	Public Robot5Probes, Robot3Probes, Robot1Probes, Robot2Probes, Robot4Probes, Robot6Probes As Integer
	Public Robot5Missiles, Robot3Missiles, Robot1Missiles, Robot2Missiles, Robot4Missiles, Robot6Missiles As Integer
	Public Robot5TacNukes, Robot3TacNukes, Robot1TacNukes, Robot2TacNukes, Robot4TacNukes, Robot6TacNukes As Integer
	Public Robot5Hellbores, Robot3Hellbores, Robot1Hellbores, Robot2Hellbores, Robot4Hellbores, Robot6Hellbores As Integer
	Public Robot5Drones, Robot3Drones, Robot1Drones, Robot2Drones, Robot4Drones, Robot6Drones As Integer
	Public Robot5Stunners, Robot3Stunners, Robot1Stunners, Robot2Stunners, Robot4Stunners, Robot6Stunners As Integer
	Public Robot5Mines, Robot3Mines, Robot1Mines, Robot2Mines, Robot4Mines, Robot6Mines As Integer
	Public Robot5Lasers, Robot3Lasers, Robot1Lasers, Robot2Lasers, Robot4Lasers, Robot6Lasers As Integer
	
	Public Robot5ShieldIcon, Robot3ShieldIcon, Robot1ShieldIcon, Robot2ShieldIcon, Robot4ShieldIcon, Robot6ShieldIcon As Integer
	Public Robot5HitIcon, Robot3HitIcon, Robot1HitIcon, Robot2HitIcon, Robot4HitIcon, Robot6HitIcon As Integer
	Public Robot5BlockIcon, Robot3BlockIcon, Robot1BlockIcon, Robot2BlockIcon, Robot4BlockIcon, Robot6BlockIcon As Integer
	Public Robot5DeathIcon, Robot3DeathIcon, Robot1DeathIcon, Robot2DeathIcon, Robot4DeathIcon, Robot6DeathIcon As Integer
	Public Robot5CollisionIcon, Robot3CollisionIcon, Robot1CollisionIcon, Robot2CollisionIcon, Robot4CollisionIcon, Robot6CollisionIcon As Integer
	
	'UPGRADE_WARNING: Lower bound of array MasterCode was changed from 1,0 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim MasterCode(6, 4999) As Integer
	
	'UPGRADE_WARNING: Lower bound of array RobotDeathSound was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotDeathSound(6) As Boolean 'Keeps track of if the robot uses it's own sounds or the standard ones
	'UPGRADE_WARNING: Lower bound of array RobotCollisionSound was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotCollisionSound(6) As Boolean
	'UPGRADE_WARNING: Lower bound of array RobotBlockSound was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotBlockSound(6) As Boolean
	'UPGRADE_WARNING: Lower bound of array RobotHitSound was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotHitSound(6) As Boolean
	
	'Robot variabler - De som var objektegenskaper tidigare
	'UPGRADE_WARNING: Lower bound of array TurretX2 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim TurretX2(6) As Integer
	'UPGRADE_WARNING: Lower bound of array TurretY2 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim TurretY2(6) As Integer
	'UPGRADE_WARNING: Lower bound of array RobotLeft was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotLeft(6) As Integer
	'UPGRADE_WARNING: Lower bound of array RobotTop was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotTop(6) As Integer
	'UPGRADE_WARNING: Lower bound of array RobotMasterIcon was changed from 10 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotMasterIcon(69) As System.Drawing.Image
	'Dim RobotMasterSound(10 To 69) As String       'Yeah, the sound system ain't perfect... :P
	Dim missilesound() As Byte
	Dim hellboresound() As Byte
	Dim bulletsound() As Byte
	Dim minesound() As Byte
	Dim takenukesound() As Byte
	Dim lasersound() As Byte
	Dim DroneSound() As Byte
	Dim hitsound() As Byte
	Dim deathsound() As Byte
	Dim collisionsound() As Byte
	Dim beepsound() As Byte
	Dim r1s0() As Byte
	Dim r1s1() As Byte
	Dim r1s2() As Byte
	Dim r1s3() As Byte
	Dim r1s4() As Byte
	Dim r1s5() As Byte
	Dim r1s6() As Byte
	Dim r1s7() As Byte
	Dim r1s8() As Byte
	Dim r1s9() As Byte
	Dim r2s0() As Byte
	Dim r2s1() As Byte
	Dim r2s2() As Byte
	Dim r2s3() As Byte
	Dim r2s4() As Byte
	Dim r2s5() As Byte
	Dim r2s6() As Byte
	Dim r2s7() As Byte
	Dim r2s8() As Byte
	Dim r2s9() As Byte
	Dim r3s0() As Byte
	Dim r3s1() As Byte
	Dim r3s2() As Byte
	Dim r3s3() As Byte
	Dim r3s4() As Byte
	Dim r3s5() As Byte
	Dim r3s6() As Byte
	Dim r3s7() As Byte
	Dim r3s8() As Byte
	Dim r3s9() As Byte
	Dim r4s0() As Byte
	Dim r4s1() As Byte
	Dim r4s2() As Byte
	Dim r4s3() As Byte
	Dim r4s4() As Byte
	Dim r4s5() As Byte
	Dim r4s6() As Byte
	Dim r4s7() As Byte
	Dim r4s8() As Byte
	Dim r4s9() As Byte
	Dim r5s0() As Byte
	Dim r5s1() As Byte
	Dim r5s2() As Byte
	Dim r5s3() As Byte
	Dim r5s4() As Byte
	Dim r5s5() As Byte
	Dim r5s6() As Byte
	Dim r5s7() As Byte
	Dim r5s8() As Byte
	Dim r5s9() As Byte
	Dim r6s0() As Byte
	Dim r6s1() As Byte
	Dim r6s2() As Byte
	Dim r6s3() As Byte
	Dim r6s4() As Byte
	Dim r6s5() As Byte
	Dim r6s6() As Byte
	Dim r6s7() As Byte
	Dim r6s8() As Byte
	Dim r6s9() As Byte
	
	'UPGRADE_WARNING: Lower bound of array RangedRobot was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RangedRobot(6) As Integer 'Moduleglobal because it's set in the Range Subroutine
	
	'UPGRADE_WARNING: Lower bound of array RobotShieldIcon was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotShieldIcon(6) As Integer 'Keeps track of if the robot automatically switches on icon 1 when shielding
	'UPGRADE_WARNING: Lower bound of array RobotHitIcon was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotHitIcon(6) As Integer
	'UPGRADE_WARNING: Lower bound of array RobotBlockIcon was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotBlockIcon(6) As Integer
	'UPGRADE_WARNING: Lower bound of array RobotDeathIcon was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotDeathIcon(6) As Integer
	'UPGRADE_WARNING: Lower bound of array RobotCollisionIcon was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim RobotCollisionIcon(6) As Integer
	
	'UPGRADE_WARNING: Lower bound of array Robot_ was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim Robot_(6) As System.Drawing.Image
	
	'UPGRADE_WARNING: Lower bound of array HistoryRec was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim HistoryRec(6, 50) As Integer
	'UPGRADE_WARNING: Lower bound of array BackupHistoryRec was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim BackupHistoryRec(6, 50) As Integer 'Used for repeat battle
	Dim RandomRegister() As Integer 'Used for repeat battle
	Dim NotRandomEmergency As Boolean
	'UPGRADE_WARNING: Lower bound of array KR was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim KR(6) As Integer 'Number of kills the bot has made
	
	
	Private Sub MainWindow_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim check As Integer
		Dim YesOrNo As Boolean
		Dim NameVar1 As String
		
		'    Get 7, 4000                               'Window State DraftingBoard
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 4500) 'Window State MainWindow
		If YesOrNo = False Then Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		'    Get 7, 7000, 'First Time Startup?   '(var bakgrundsfärg tidigare)
		Me.Show()
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 1000) 'Sounds
		If YesOrNo Then PlaySounds = True Else Sounds.Checked = False
		'    Get 7, 2000, 'Tom (var Auto No Sound Warning tidigare)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 2500) 'Scoring System
		If YesOrNo Then
			Scoring.Text = "Scoring: Mac (4.5.2)"
		Else
			'Scoring.Caption = "Scoring: Standard"
			StandardScoring = True
		End If
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 3000) 'Chrononlimit
		If YesOrNo Then
			ChronorsLimit.Checked = True
			MaxChronon = 1500
		Else
			ChronorsLimit.Checked = False
			MaxChronon = -1
		End If
		'3250 Overwrite Tournament
		'3500 Overwrite Testing
		'4000 Window state DraftingBoard
		'4500 Window state MainWindow
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 5000) 'Move and shoot
		MoveAndShoot.Checked = YesOrNo
		MoveAndShotAllowed = Not YesOrNo
		'   Get 7, 5500,                               'Reset Cursor Position
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 6000) 'Overload
		Overloading.Checked = YesOrNo
		EnableOverloading = Not YesOrNo
		'    Get 7, 6500, YesOrNo                       'Move and shoot message
		'        ShowMoveAndShoot.Checked = YesOrNo
		'    Get 7, 7000,                               First Time Startup? Tidigare Bakgrundsfärg
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, UltraWarning, 7500) '            Ultravarning
		'    Get 7, 8000,                               Auto Recompile
		'    Get 7, 9000                                'DebuggingWindow Position
		'    Get 7, 10000,                             'Skriv ut intructionsnumret
		'    Get 7, 10500,                             'Syntax Coloring
		'    Get 7, 11000, RSpeed
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, YesOrNo, 12000) 'Change resolution
		If YesOrNo Then
			resolution.Checked = True
			ResolutionChanged = 1
		End If
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, TheSpeedConstant, 12500)
		'    Get 7, 13000   'Auto no sound
		Dim RSpeed As Integer 'Speed
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(7, RSpeed, 11000)
		Select Case RSpeed
			Case 1
				Slowest.Checked = True
				Normal.Checked = False
				BattleSpeed = 0.5 * TheSpeedConstant
			Case 2
				Slower.Checked = True
				Normal.Checked = False
				BattleSpeed = 1 / 12 * TheSpeedConstant
			Case 3
				Slow.Checked = True
				Normal.Checked = False
				BattleSpeed = 1 / 30 * TheSpeedConstant
			Case 4
				BattleSpeed = 1 / 70 * TheSpeedConstant
			Case 5
				Normal.Checked = False
				Fast.Checked = True
				BattleSpeed = 1E-37
			Case 6
				Normal.Checked = False
				AutoRedrawFast.Checked = True
				BattleSpeed = 1E-37
			Case 7
				Normal.Checked = False
				NoDisplay.Checked = True
				BattleSpeed = 1E-37
				HideBattle = True
			Case 8
				Normal.Checked = False
				Ultra.Checked = True
				BattleSpeed = 1E-37
				HideBattle = True
		End Select
		
		'******** I've disabled Auto No Sound, due that it was probably very few people that was using it and knew what it meant
		'    Get 7, 13000, YesOrNo                     'Auto no sound - Must be after battlespeed
		'        If YesOrNo Then
		'AutoNoSound.Checked = True     'We enabled it on the menu editor.
		Sounds.Enabled = Not (Fast.Checked Or AutoRedrawFast.Checked Or HideBattle)
		PlaySounds = Not (Fast.Checked Or AutoRedrawFast.Checked Or HideBattle) And Sounds.Checked
		'        End If
		
		'Här låg det blocket som ligger sist förut (Robotladdningsblocket)
		
		
		'Trig Cache
		For check = 0 To 360
			Sine(check) = System.Math.Sin(check * PIO)
			Cosine(check) = System.Math.Cos(check * PIO)
			Sine(check + 360) = Sine(check)
			Cosine(check + 360) = Cosine(check)
			
			Sin11(check) = 11 * Sine(check)
			Cos11(check) = 11 * Cosine(check)
			
			Sin10(check) = 10 * Sine(check)
			Cos10(check) = 10 * Cosine(check)
			
			Sin5(check) = 5 * Sine(check)
			Cos5(check) = 5 * Cosine(check)
			
			Sin14(check) = 14 * Sine(check)
			Cos14(check) = 14 * Cosine(check)
			
			Sin12(check) = 12 * Sine(check)
			Cos12(check) = 12 * Cosine(check)
			
			Sin6(check) = 6 * Sine(check)
			Cos6(check) = 6 * Cosine(check)
		Next check
		
		For check = 0 To 180000
			Square(check) = System.Math.Sqrt(check)
			FixSquare(check) = Fix(Square(check))
		Next 
		
		For check = -20 To 9
			WCX(check) = True
			WCY(check) = True
		Next check
		
		For check = 291 To 320
			WCX(check) = True
			WCY(check) = True
		Next check
		
		'Loads the drones
		DroneD = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\droned.bmp")
		DroneL = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\dronel.bmp")
		DroneU = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\droneu.bmp")
		DroneR = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\droner.bmp")
		
		DroneDiagonally(3) = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\dronelu.bmp")
		DroneDiagonally(4) = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\droneld.bmp")
		DroneDiagonally(5) = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\droneru.bmp")
		DroneDiagonally(6) = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\dronerd.bmp")
		
		'Random Number Generator
		Randomize()
		
		'Start debugging at
		StartDebuggerAt = DEBUGATNOTSET
		
		'InizSounds
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\Missile.wav", OpenMode.Binary)
		ReDim missilesound(LOF(1))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, missilesound)
		FileClose(1)
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\Hellbore.wav", OpenMode.Binary)
		ReDim hellboresound(LOF(1))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, hellboresound)
		FileClose(1)
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\Gun.wav", OpenMode.Binary)
		ReDim bulletsound(LOF(1))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, bulletsound)
		FileClose(1)
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\Mine.wav", OpenMode.Binary)
		ReDim minesound(LOF(1))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, minesound)
		FileClose(1)
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\Nukebang.wav", OpenMode.Binary)
		ReDim takenukesound(LOF(1))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, takenukesound)
		FileClose(1)
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\Laser.wav", OpenMode.Binary)
		ReDim lasersound(LOF(1))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, lasersound)
		FileClose(1)
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\Drone.wav", OpenMode.Binary)
		ReDim DroneSound(LOF(1))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, DroneSound)
		FileClose(1)
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\shothit.wav", OpenMode.Binary)
		ReDim hitsound(LOF(1))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, hitsound)
		FileClose(1)
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\Death.wav", OpenMode.Binary)
		ReDim deathsound(LOF(1))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, deathsound)
		FileClose(1)
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\collision.wav", OpenMode.Binary)
		ReDim collisionsound(LOF(1))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, collisionsound)
		FileClose(1)
		FileOpen(1, My.Application.Info.DirectoryPath & "\miscdata\Sosumi.wav", OpenMode.Binary)
		ReDim beepsound(LOF(1))
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, beepsound)
		FileClose(1)
		
		
		'Robotladdningsblocket 'ROBOT LOADING AT STARTUP (If any)
		If VB.Command() <> "" Then 'The user clicked a Robot in Windows
			Load2.Visible = True
			R1path = VB.Command()
			R1path = Replace(R1path, Chr(34), "")
			NameVar1 = StrReverse(R1path)
			NameVar1 = VB.Right(R1path, InStr(NameVar1, "\") - 1)
			Robot1.Text = VB.Left(NameVar1, Len(NameVar1) - 4)
			
			CommonDialog1Open.InitialDirectory = VB.Left(R1path, Len(R1path) - Len(NameVar1)) 'New, makes the directory the user opened a robot from the default
			
			R1Present = True
			SelectedRobot = 1
			Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
			LoadRobot1()
		Else
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(7, YesOrNo, 7000)
			'YesOrNo = False    'DEBUG - Enable first time startup
			If YesOrNo Then 'Not first time
				For check = 2 To 6 'Place not present robots outside arena so they wont get hit
					RobotLeft(check) = -check * 100
				Next check
				SelectedRobot = -1
			Else 'First time
				FirstTimeStartUp()
			End If
		End If
		
	End Sub
	
	Private Sub FirstTimeStartUp()
		'Put 7, 7000, True  'Moved to WelcomeHelp_Close
		
		'NotRandomEmergency = False     'tror inte denhär behövs?
		WelcomeWindowSwitchMenu.Checked = True
		
		CommonDialog1Open.InitialDirectory = My.Application.Info.DirectoryPath & "\Miscellaneous Bots\"
		R1Present = True 'Sets the global variable R1Present
		R2Present = True 'Sets the global variable R1Present
		R3Present = True 'Sets the global variable R1Present
		R4Present = True 'Sets the global variable R1Present
		R5Present = True 'Sets the global variable R1Present
		R6Present = True 'Sets the global variable R1Present
		Load2.Visible = True
		Load3.Visible = True
		Load4.Visible = True
		Load5.Visible = True
		Load6.Visible = True
		SelectedRobot = 1
		Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
		
		Const StartupBot1 As String = "Zolad Alive"
		Const StartupBot2 As String = "5 drop 5"
		Const StartupBot3 As String = "CHANGER 2"
		Const StartupBot4 As String = "Dialectix"
		Const StartupBot5 As String = "Carne"
		Const StartupBot6 As String = "JEST.ALT"
		
		R1path = My.Application.Info.DirectoryPath & "\Miscellaneous Bots\" & StartupBot1 & ".RWR" 'Sets the global variable R1Path
		Robot1.Text = StartupBot1
		LoadRobot1() 'A huge subroutine that loads hardware, icon and icon settings
		
		R2path = My.Application.Info.DirectoryPath & "\Miscellaneous Bots\" & StartupBot2 & ".RWR" 'Sets the global variable R2Path
		Robot2.Text = StartupBot2
		LoadRobot2() 'A huge subroutine that loads hardware, icon and icon settings
		
		R3path = My.Application.Info.DirectoryPath & "\Miscellaneous Bots\" & StartupBot3 & ".RWR" 'Sets the global variable R3Path
		Robot3.Text = StartupBot3
		LoadRobot3() 'A huge subroutine that loads hardware, icon and icon settings
		
		R4path = My.Application.Info.DirectoryPath & "\Miscellaneous Bots\" & StartupBot4 & ".RWR" 'Sets the global variable R4Path
		Robot4.Text = StartupBot4
		LoadRobot4() 'A huge subroutine that loads hardware, icon and icon settings
		
		R5path = My.Application.Info.DirectoryPath & "\Miscellaneous Bots\" & StartupBot5 & ".RWR" 'Sets the global variable R5Path
		Robot5.Text = StartupBot5
		LoadRobot5() 'A huge subroutine that loads hardware, icon and icon settings
		
		R6path = My.Application.Info.DirectoryPath & "\Miscellaneous Bots\" & StartupBot6 & ".RWR" 'Sets the global variable R6Path
		Robot6.Text = StartupBot6
		LoadRobot6() 'A huge subroutine that loads hardware, icon and icon settings
		
		
		WelcomeHelp.Show()
		
		'MainWindow.SetFocus
		'MsgBox "Welcome to RoboWar!" & vbCrLf & _
		''"Thanks for downloading and trying out my game!" & vbCrLf & vbCrLf & _
		''"Click the Battle Button to watch the Robots fight." & vbCrLf & _
		''"Click the buttons next to the Robots name to load another Robot." & vbCrLf & _
		''"Remove robots from the Arena can be done by clicking the Robots name and select 'Close Robot' from the File menu (Ctrl-W)." & vbCrLf & _
		''"If you feel daring enough to create your own Robot, select new Robot from the file menu. "
		
		
		
	End Sub
	Public Sub About_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles About.Click
		VB6.ShowForm(AboutRoboWar, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Private Sub Arena_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Arena.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim counter As Integer
		
		For counter = 1 To NumberOfRobotsPresent
			If (X - RobotLeft(counter)) ^ 2 + (Y - RobotTop(counter)) ^ 2 < 100 Then
                Arena.Cursor = Cursors.Default
				Draging = counter
			End If
		Next counter
		
		If DebuggedRobot <> 0 And Draging <> 0 Then
			'UPGRADE_ISSUE: PictureBox property Arena.DrawMode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			Arena.DrawMode = 13
			'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			Arena.Line (RobotLeft(Draging) - 16, RobotTop(Draging) - 16) - (RobotLeft(Draging) + 16, RobotTop(Draging) + 16), BackgroundColor, BF
			'UPGRADE_ISSUE: PictureBox property Arena.DrawMode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			Arena.DrawMode = 9
			
			DebuggingWindow.Show()
		End If
		
	End Sub
	
	Private Sub Arena_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Arena.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		
		Dim Turret As Integer
        If Arena.Cursor Is Cursors.Default Then
            TurretX2(Draging) = X + TurretX2(Draging) - RobotLeft(Draging)
            TurretY2(Draging) = Y + TurretY2(Draging) - RobotTop(Draging)
            RobotLeft(Draging) = X
            RobotTop(Draging) = Y
            Arena.Cursor = System.Windows.Forms.Cursors.Default

            If DebuggedRobot <> 0 Then
                'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                Arena.PaintPicture(Robot_(Draging), RobotLeft(Draging) - 16, RobotTop(Draging) - 16)
                Select Case Draging
                    Case 1
                        Turret = Robot1Turret
                    Case 2
                        Turret = Robot2Turret
                    Case 3
                        Turret = Robot3Turret
                    Case 4
                        Turret = Robot4Turret
                    Case 5
                        Turret = Robot5Turret
                    Case 6
                        Turret = Robot6Turret
                End Select
                If Turret = 1 Then
                    'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.Line (RobotLeft(Draging), RobotTop(Draging)) - (TurretX2(Draging), TurretY2(Draging)), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                ElseIf Turret = 2 Then
                    'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.Circle (TurretX2(Draging), TurretY2(Draging)), 1, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                End If

                DebuggingWindow.DebugMsg = Replace(DebuggingWindow.DebugMsg, vbLf & "x ", "old1")
                DebuggingWindow.DebugMsg = Replace(DebuggingWindow.DebugMsg, vbLf & "Speedx ", "old2" & vbLf & "Speedx ")

                Turret = InStr(DebuggingWindow.DebugMsg, "old1")

                DebuggingWindow.DebugMsg = Replace(DebuggingWindow.DebugMsg, Mid(DebuggingWindow.DebugMsg, Turret, InStr(DebuggingWindow.DebugMsg, "old2") + 4 - Turret), vbLf & "x " & RobotLeft(Draging) & vbLf & "y " & RobotTop(Draging))

                'UPGRADE_ISSUE: Form method DebuggingWindow.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                DebuggingWindow.Cls()
                'UPGRADE_ISSUE: Form method DebuggingWindow.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                DebuggingWindow.Print(DebuggingWindow.DebugMsg)

                Draging = 0
                Exit Sub
            End If

            Draging = 0
        End If
		
		If RunningTournament Then StopTournament.Focus() Else BattleHaltButton.Focus()
		
	End Sub
	
	'Private Sub AutoNoSound_Click()
	'Dim YesOrNo As Boolean
	'
	'If AutoNoSound.Checked Then
	'    If MsgBox("You've selected AutoNoSound to disabeld." & vbCr & _
	''    "This is not recommended if you have a fast computer." & vbCr & vbCr & _
	''    "Auto no sound automacticly disables sound if you set the battlespeed to fast." & vbCr & _
	''    "Sound will bug out if battlespeed is over 50 chronons per second" & vbCr & _
	''    "because then there will simply be too many sounds at one time." & vbCr & vbCr & _
	''    "Since sounds are automaticly switched off if fast is choosen" & vbCr & _
	''    "keeping the auto no sound option prevent this problem." & vbCr & vbCr & _
	''    "Are you sure you want to disable Auto No Sound?" _
	''    , vbYesNo + vbDefaultButton2 + vbExclamation, "Sound problems can occur if Auto No Sound is switched off") = vbNo Then Exit Sub
	'
	'    AutoNoSound.Checked = False
	'    YesOrNo = False
	'    Sounds.Enabled = True
	'Else
	'    AutoNoSound.Checked = True
	'    YesOrNo = True
	'    Sounds.Enabled = Not (HideBattle Or Fast.Checked Or AutoRedrawFast.Checked)
	'End If
	'
	'Put 7, 13000, YesOrNo
	'End Sub
	
	Private Function S(ByRef MagicNumber As Integer) As String
		'Used by the debugger (and some other stuff too I think) to translate the
		'magic numbers which represents the instructions to strings
		Select Case MagicNumber
			Case -19999 To 19999
				S = CStr(MagicNumber)
			Case 20100
				S = "STORE"
			Case 20330
				S = "AIM'"
			Case 20109
				S = "RECALL"
			Case 20140
				S = "IFG"
			Case 20104
				S = "JUMP"
			Case 20153
				S = "INTON"
			Case 20155
				S = "RTI"
			Case 20355
				S = "DOPPLER'"
			Case 20156
				S = "SETINT"
			Case 20157
				S = "SETPARAM"
			Case 20329
				S = "RANGE'"
			Case 20004
				S = ">"
			Case 20005
				S = "<"
			Case 20000
				S = "+"
			Case 20002
				S = "*"
			Case 20136
				S = "SYNC"
			Case 20328
				S = "SHIELD'"
			Case 20331
				S = "SPEEDX'"
			Case 20332
				S = "SPEEDY'"
			Case 20340
				S = "MOVEX'"
			Case 20341
				S = "MOVEY'"
			Case 20343
				S = "RADAR'"
			Case 20006
				S = "="
			Case 20107
				S = "IF"
			Case 20326
				S = "FIRE'"
			Case 20356
				S = "STUNNER'"
			Case 20335
				S = "MISSILE'"
			Case 20125
				S = "ICON0"
			Case 20126
				S = "ICON1"
			Case 20127
				S = "ICON2"
			Case 20128
				S = "ICON3"
			Case 20129
				S = "ICON4"
			Case 20130
				S = "ICON5"
			Case 20131
				S = "ICON6"
			Case 20132
				S = "ICON7"
			Case 20133
				S = "ICON8"
			Case 20134
				S = "ICON9"
			Case 20159
				S = "DROPALL"
			Case 20001
				S = "-"
			Case 20003
				S = "/"
			Case 20007
				S = "!"
			Case 20101
				S = "DROP"
			Case 20102
				S = "SWAP"
			Case 20103
				S = "ROLL"
			Case 20105
				S = "CALL"
			Case 20106
				S = "DUP"
			Case 20108
				S = "IFE"
			Case 20111
				S = "NOP"
			Case 20112
				S = "AND"
			Case 20113
				S = "OR"
			Case 20114
				S = "XOR"
			Case 20115
				S = "MOD"
			Case 20117
				S = "CHS"
			Case 20118
				S = "NOT"
			Case 20119
				S = "ARCTAN"
			Case 20120
				S = "ABS"
			Case 20121
				S = "SIN"
			Case 20122
				S = "COS"
			Case 20123
				S = "TAN"
			Case 20137
				S = "VSTORE"
			Case 20138
				S = "VRECALL"
			Case 20139
				S = "DIST"
			Case 20141
				S = "IFEG"
			Case 20142
				S = "DEBUG"
			Case 20143
				S = "SND0"
			Case 20144
				S = "SND1"
			Case 20145
				S = "SND2"
			Case 20146
				S = "SND3"
			Case 20147
				S = "SND4"
			Case 20148
				S = "SND5"
			Case 20149
				S = "SND6"
			Case 20150
				S = "SND7"
			Case 20151
				S = "SND8"
			Case 20152
				S = "SND9"
			Case 20154
				S = "INTOFF"
			Case 20160
				S = "FLUSHINT"
			Case 20161
				S = "MAX"
			Case 20162
				S = "MIN"
			Case 20163
				S = "ARCCOS"
			Case 20164
				S = "ARCSIN"
			Case 20300
				S = "A'"
			Case 20301
				S = "B'"
			Case 20302
				S = "C'"
			Case 20303
				S = "D'"
			Case 20304
				S = "E'"
			Case 20305
				S = "F'"
			Case 20306
				S = "G'"
			Case 20307
				S = "H'"
			Case 20308
				S = "I'"
			Case 20309
				S = "J'"
			Case 20310
				S = "K'"
			Case 20311
				S = "L'"
			Case 20312
				S = "M'"
			Case 20313
				S = "N'"
			Case 20314
				S = "O'"
			Case 20315
				S = "P'"
			Case 20316
				S = "Q'"
			Case 20317
				S = "R'"
			Case 20318
				S = "S'"
			Case 20319
				S = "T'"
			Case 20320
				S = "U'"
			Case 20321
				S = "V'"
			Case 20322
				S = "W'"
			Case 20323
				S = "X'"
			Case 20324
				S = "Y'"
			Case 20325
				S = "Z'"
			Case 20333
				S = "DAMAGE'"
			Case 20334
				S = "RANDOM'"
			Case 20336
				S = "NUKE'"
			Case 20337
				S = "COLLISION'"
			Case 20327
				S = "ENERGY'"
			Case 20344
				S = "LOOK'"
			Case 20345
				S = "SCAN'"
			Case 20346
				S = "CHRONON'"
			Case 20347
				S = "HELLBORE'"
			Case 20348
				S = "DRONE'"
			Case 20349
				S = "MINE'"
			Case 20350
				S = "LASER'"
			Case 20352
				S = "ROBOTS'"
			Case 20353
				S = "FRIEND'"
			Case 20354
				S = "BULLET'"
			Case 20357
				S = "TOP'"
			Case 20358
				S = "BOT'"
			Case 20359
				S = "LEFT'"
			Case 20360
				S = "RIGHT'"
			Case 20361
				S = "WALL'"
			Case 20363
				S = "PROBE'"
			Case 20364
				S = "HISTORY'"
			Case 20365
				S = "ID'"
			Case 20135
				S = "PRINT"
			Case 20124
				S = "SQRT"
			Case 20116
				S = "BEEP"
			Case 20366
				S = "KILLS'"
			Case 20110 'END
				S = "END"
			Case 20362
				S = "TEAMMATES'"
			Case 20338
				S = "CHANNEL'"
			Case 20339
				S = "SIGNAL'"
			Case insNEAREST
				S = "NEAREST'"
			Case insMEGANUKE
				S = "MEGANUKE'"
			Case Else
				S = "????"
		End Select
	End Function
	
	Private Function Inst2MagicNumber(ByRef Instruction As Object) As Integer
		' Used by the built in converter which translates robots from the old RWR file format to the new one
		Select Case Instruction
			Case -19999 To 19999
				'UPGRADE_WARNING: Couldn't resolve default property of object Instruction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Inst2MagicNumber = Instruction
			Case "+"
				Inst2MagicNumber = 20000
			Case "-"
				Inst2MagicNumber = 20001
			Case "*"
				Inst2MagicNumber = 20002
			Case "/"
				Inst2MagicNumber = 20003
			Case ">"
				Inst2MagicNumber = 20004
			Case "<"
				Inst2MagicNumber = 20005
			Case "="
				Inst2MagicNumber = 20006
			Case "!"
				Inst2MagicNumber = 20007
			Case "STORE"
				Inst2MagicNumber = 20100
			Case "DROP"
				Inst2MagicNumber = 20101
			Case "SWAP"
				Inst2MagicNumber = 20102
			Case "ROLL"
				Inst2MagicNumber = 20103
			Case "JUMP"
				Inst2MagicNumber = 20104
			Case "CALL"
				Inst2MagicNumber = 20105
			Case "DUP"
				Inst2MagicNumber = 20106
			Case "IF"
				Inst2MagicNumber = 20107
			Case "IFE"
				Inst2MagicNumber = 20108
			Case "RECALL"
				Inst2MagicNumber = 20109
			Case "END"
				Inst2MagicNumber = 20110
			Case "NOP"
				Inst2MagicNumber = 20111
			Case "AND"
				Inst2MagicNumber = 20112
			Case "OR"
				Inst2MagicNumber = 20113
			Case "XOR"
				Inst2MagicNumber = 20114
			Case "MOD"
				Inst2MagicNumber = 20115
			Case "BEEP"
				Inst2MagicNumber = 20116
			Case "CHS"
				Inst2MagicNumber = 20117
			Case "NOT"
				Inst2MagicNumber = 20118
			Case "ARCTAN"
				Inst2MagicNumber = 20119
			Case "ABS"
				Inst2MagicNumber = 20120
			Case "SIN"
				Inst2MagicNumber = 20121
			Case "COS"
				Inst2MagicNumber = 20122
			Case "TAN"
				Inst2MagicNumber = 20123
			Case "SQRT"
				Inst2MagicNumber = 20124
			Case "ICON0"
				Inst2MagicNumber = 20125
			Case "ICON1"
				Inst2MagicNumber = 20126
			Case "ICON2"
				Inst2MagicNumber = 20127
			Case "ICON3"
				Inst2MagicNumber = 20128
			Case "ICON4"
				Inst2MagicNumber = 20129
			Case "ICON5"
				Inst2MagicNumber = 20130
			Case "ICON6"
				Inst2MagicNumber = 20131
			Case "ICON7"
				Inst2MagicNumber = 20132
			Case "ICON8"
				Inst2MagicNumber = 20133
			Case "ICON9"
				Inst2MagicNumber = 20134
			Case "PRINT"
				Inst2MagicNumber = 20135
			Case "SYNC"
				Inst2MagicNumber = 20136
			Case "VSTORE"
				Inst2MagicNumber = 20137
			Case "VRECALL"
				Inst2MagicNumber = 20138
			Case "DIST"
				Inst2MagicNumber = 20139
			Case "IFG"
				Inst2MagicNumber = 20140
			Case "IFEG"
				Inst2MagicNumber = 20141
			Case "DEBUG"
				Inst2MagicNumber = 20142
			Case "SND0"
				Inst2MagicNumber = 20143
			Case "SND1"
				Inst2MagicNumber = 20144
			Case "SND2"
				Inst2MagicNumber = 20145
			Case "SND3"
				Inst2MagicNumber = 20146
			Case "SND4"
				Inst2MagicNumber = 20147
			Case "SND5"
				Inst2MagicNumber = 20148
			Case "SND6"
				Inst2MagicNumber = 20149
			Case "SND7"
				Inst2MagicNumber = 20150
			Case "SND8"
				Inst2MagicNumber = 20151
			Case "SND9"
				Inst2MagicNumber = 20152
			Case "INTON"
				Inst2MagicNumber = 20153
			Case "INTOFF"
				Inst2MagicNumber = 20154
			Case "RTI"
				Inst2MagicNumber = 20155
			Case "SETINT"
				Inst2MagicNumber = 20156
			Case "SETPARAM"
				Inst2MagicNumber = 20157
				'    Case         inst2magicNumber = 20158      'SPECIALFALL    'MRB
				'         "MRB"
			Case "DROPALL"
				Inst2MagicNumber = 20159
			Case "FLUSHINT"
				Inst2MagicNumber = 20160
			Case "MAX"
				Inst2MagicNumber = 20161
			Case "MIN"
				Inst2MagicNumber = 20162
			Case "ARCCOS"
				Inst2MagicNumber = 20163
			Case "ARCSIN"
				Inst2MagicNumber = 20164
			Case "A'"
				Inst2MagicNumber = 20300
			Case "B'"
				Inst2MagicNumber = 20301
			Case "C'"
				Inst2MagicNumber = 20302
			Case "D'"
				Inst2MagicNumber = 20303
			Case "E'"
				Inst2MagicNumber = 20304
			Case "F'"
				Inst2MagicNumber = 20305
			Case "G'"
				Inst2MagicNumber = 20306
			Case "H'"
				Inst2MagicNumber = 20307
			Case "I'"
				Inst2MagicNumber = 20308
			Case "J'"
				Inst2MagicNumber = 20309
			Case "K'"
				Inst2MagicNumber = 20310
			Case "L'"
				Inst2MagicNumber = 20311
			Case "M'"
				Inst2MagicNumber = 20312
			Case "N'"
				Inst2MagicNumber = 20313
			Case "O'"
				Inst2MagicNumber = 20314
			Case "P'"
				Inst2MagicNumber = 20315
			Case "Q'"
				Inst2MagicNumber = 20316
			Case "R'"
				Inst2MagicNumber = 20317
			Case "S'"
				Inst2MagicNumber = 20318
			Case "T'"
				Inst2MagicNumber = 20319
			Case "U'"
				Inst2MagicNumber = 20320
			Case "V'"
				Inst2MagicNumber = 20321
			Case "W'"
				Inst2MagicNumber = 20322
			Case "X'"
				Inst2MagicNumber = 20323
			Case "Y'"
				Inst2MagicNumber = 20324
			Case "Z'"
				Inst2MagicNumber = 20325
			Case "FIRE'"
				Inst2MagicNumber = 20326
			Case "ENERGY'"
				Inst2MagicNumber = 20327
			Case "SHIELD'"
				Inst2MagicNumber = 20328
			Case "RANGE'"
				Inst2MagicNumber = 20329
			Case "AIM'"
				Inst2MagicNumber = 20330
			Case "SPEEDX'"
				Inst2MagicNumber = 20331
			Case "SPEEDY'"
				Inst2MagicNumber = 20332
			Case "DAMAGE'"
				Inst2MagicNumber = 20333
			Case "RANDOM'"
				Inst2MagicNumber = 20334
			Case "MISSILE'"
				Inst2MagicNumber = 20335
			Case "NUKE'"
				Inst2MagicNumber = 20336
			Case "COLLISION'"
				Inst2MagicNumber = 20337
			Case "CHANNEL'"
				Inst2MagicNumber = 20338
			Case "SIGNAL'"
				Inst2MagicNumber = 20339
			Case "MOVEX'"
				Inst2MagicNumber = 20340
			Case "MOVEY'"
				Inst2MagicNumber = 20341
				'    Case         inst2magicNumber = 20342      'SPECIALFALL
				'         "JOCE'"
			Case "RADAR'"
				Inst2MagicNumber = 20343
			Case "LOOK'"
				Inst2MagicNumber = 20344
			Case "SCAN'"
				Inst2MagicNumber = 20345
			Case "CHRONON'"
				Inst2MagicNumber = 20346
			Case "HELLBORE'"
				Inst2MagicNumber = 20347
			Case "DRONE'"
				Inst2MagicNumber = 20348
			Case "MINE'"
				Inst2MagicNumber = 20349
			Case "LASER'"
				Inst2MagicNumber = 20350
				'    Case         inst2magicNumber = 20351      'SPECIALFALL
				'         "SUSIE'"
			Case "ROBOTS'"
				Inst2MagicNumber = 20352
			Case "FRIEND'"
				Inst2MagicNumber = 20353
			Case "BULLET'"
				Inst2MagicNumber = 20354
			Case "DOPPLER'"
				Inst2MagicNumber = 20355
			Case "STUNNER'"
				Inst2MagicNumber = 20356
			Case "TOP'"
				Inst2MagicNumber = 20357
			Case "BOT'"
				Inst2MagicNumber = 20358
			Case "LEFT'"
				Inst2MagicNumber = 20359
			Case "RIGHT'"
				Inst2MagicNumber = 20360
			Case "WALL'"
				Inst2MagicNumber = 20361
			Case "TEAMMATES'"
				Inst2MagicNumber = 20362
			Case "PROBE'"
				Inst2MagicNumber = 20363
			Case "HISTORY'"
				Inst2MagicNumber = 20364
			Case "ID'"
				Inst2MagicNumber = 20365
			Case "KILLS'"
				Inst2MagicNumber = 20366
			Case Else
				Inst2MagicNumber = -20001
		End Select
	End Function
	
	Private Sub BattleHaltButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BattleHaltButton.Click
		
		If R1Present Then
			If BattleHaltButton.Text = "Halt" Then
				TerminateBattle()
			Else
				If Ultra.Checked Then
					ULTRAMODE()
				ElseIf NoDisplay.Checked Then 
					DONTSHOWBATTLE()
				Else
					Combat()
				End If
			End If
		Else
			MsgBox("To load a robot, choose 'Load Robot' from the file menu.",  , "No Robot Loaded")
		End If
		
	End Sub
	
	Private Sub Combat()
		'This is the battleengine - Some things are external procedures, but most things are controlled here
		
		'Debugging variables
		Dim ChrononStepping As Integer
		Dim ErrorCode As Integer
		Dim RandomCounter As Integer
		Dim fStart As Single
		
		'Robotarnas maskinkod - The robots' machinecode
		'UPGRADE_WARNING: Lower bound of array MachineCode was changed from 1,0 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim MachineCode(6, 4999) As Integer '0-4999 = RobotInstructions
		'UPGRADE_WARNING: Lower bound of array RobotInstPos was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotInstPos(6) As Integer
		
		'Robotarnas Stack - The robots' Stacks
		'UPGRADE_WARNING: Lower bound of array RobotStack was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotStack(6, 100) As Integer 'long
		'UPGRADE_WARNING: Lower bound of array RobotStackPos was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotStackPos(6) As Integer 'How many numbers the robots has on it's stack
		
		'Robotarnas Interupptsköer - The robots' interupps ques
		'UPGRADE_WARNING: Lower bound of array RobotIntQue was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotIntQue(6, 100) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotQuePos was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotQuePos(6) As Integer
		'UPGRADE_WARNING: Lower bound of array IntID was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim IntID(6, 100) As Integer
		
		'Robots hardware
		'UPGRADE_WARNING: Lower bound of array RobotShield was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotShield(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotEnergy was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotEnergy(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotProSpeed was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotProSpeed(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotMissiles was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotMissiles(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotTacNukes was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotTacNukes(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotBullets was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotBullets(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotStunners was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotStunners(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotHellbores was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotHellbores(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotMines was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotMines(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotLasers was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotLasers(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotDrones was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotDrones(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotProbes was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotProbes(6) As Integer
		
		'Which icon to display? What type of turret does the robot have, if any?
		'UPGRADE_WARNING: Lower bound of array RobotIconNumber was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotIconNumber(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotTurretType was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotTurretType(6) As Integer
		'UPGRADE_WARNING: Lower bound of array DroneSoundPlayed was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim DroneSoundPlayed(6) As Integer
		
		'Robotarnas variabler - The robots' variables
		'UPGRADE_WARNING: Lower bound of array RA was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RA(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RB was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RB(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RC was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RC(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RD was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RD(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RE was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RE(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RF was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RF(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RG was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RG(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RH was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RH(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RI was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RI(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RJ was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RJ(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RK was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RK(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RL was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RL(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RM was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RM(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RN was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RN(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RO was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RO(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RP was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RP(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RQ was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RQ(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RR was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RR(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RS was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RS(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RT was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RT(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RU was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RU(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RV was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RV(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RZ was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RZ(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RW was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RW(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RVRECALL was changed from 1,0 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RVRECALL(6, 100) As Integer
		
		'Probes and Interupps
		'UPGRADE_WARNING: Lower bound of array ProbeSet was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ProbeSet(6) As Integer '0 = Damage 1 = Energy 2 = Shield 3 = ID '5 = Aim 6 = look 7 = scan 4 = Teammates - Currently disabled 'cause of no teams
		
		'UPGRADE_WARNING: Lower bound of array Inton was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim Inton(6) As Boolean
		'UPGRADE_WARNING: Lower bound of array RangeInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RangeInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RangeParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RangeParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RadarInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RadarInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RadarParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RadarParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array ChrononInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ChrononInst(6) As Integer 'Måste alltid dras ifrån en då denna sätts för att mataren matar fram + 1
		'UPGRADE_WARNING: Lower bound of array ChrononParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ChrononParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotsInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotsInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotsParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotsParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RightParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RightParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array LeftParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim LeftParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TopParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TopParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array BotParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim BotParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RightInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RightInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array LeftInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim LeftInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TopInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TopInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array BotInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim BotInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array CollisionInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim CollisionInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array WallInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim WallInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array DamageInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim DamageInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array DamageParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim DamageParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array ShieldInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ShieldInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array ShieldParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ShieldParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array HistoryParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim HistoryParam(6) As Integer
		
		'Things that can be recalled
		'UPGRADE_WARNING: Lower bound of array RCollision was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RCollision(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RWall was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RWall(6) As Integer
		'UPGRADE_WARNING: Lower bound of array REnergy was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim REnergy(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RDamage was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RDamage(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RShield was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RShield(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RSpeedx was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RSpeedx(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RSpeedy was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RSpeedy(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RAim was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RAim(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RLook was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RLook(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RScan was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RScan(6) As Integer
		Dim RRadar As Integer 'Kanske kan byggas ihop? Bytas ut?
		Dim RRange As Integer
		
		' Team Variables
		'UPGRADE_WARNING: Lower bound of array RSignal was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RSignal(3, 10) As Integer
		'UPGRADE_WARNING: Lower bound of array RChannel was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RChannel(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TeammatesInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TeammatesInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TeammatesParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TeammatesParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array SignalInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim SignalInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array SignalParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim SignalParam(6) As Integer
		
		'Robot Specific Game Vars
		'UPGRADE_WARNING: Lower bound of array RobotAlive was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotAlive(6) As Integer 'Boolean
		'UPGRADE_WARNING: Lower bound of array RStunned was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RStunned(6) As Integer 'The number of chronons the robot is stunned
		'Hasmoved skall ha 2 funktioner. Dels MoveAndShot, dels så att LEFT' RIGHT' TOP' BOT'
		'skall kunna triggas med movex
		'UPGRADE_WARNING: Lower bound of array LastHiter was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim LastHiter(6) As Integer 'To determinate the killer of the robot
		Dim HasMoved As Integer 'For the Move and Shoot restriction
		Dim DroneShotDown As Boolean
		
		'Vars neccesary for running the game
		Dim RNN As Integer 'Stands for Robot ruNniNg or something like that (I don't remember exactly what to be honest). Correspond aproximately to the variable "who" in Mac RoboWar
		Dim ChrononExecutor1 As Integer 'Correspons to "cycleNum"
		Dim HowManyLeft As Integer 'Used to determine when to cancel battle. Set to 2 if only one robot is present, to avoid that battle breaks at Chronon 20
		Dim tempnumber As Integer 'temporary placeholder for longs
		Dim TDouble As Double 'To avoid trig calculations to get truncated
		
		'Shot vars
		Dim FreeShot As Integer
		FreeShot = -1
		Dim shotcounter As Integer
		Dim NotAnyShotsAtAll As Boolean
		Dim shot(32768) As ShotPrivateType
		Dim ShotNumber As Integer 'Number of shots (including "dead" shots) that are in the arena
		Dim trigx As Single
		Dim trigy As Single
		
		InizBattle()
		'Battle Starts. The robots get randomly placed in the Arena
		
		'Robot 1. Allways Present
		REnergy(1) = Robot1Energy
		RDamage(1) = Robot1Damage
		RobotTurretType(1) = Robot1Turret
		
		'Laddar machinkoden till Robotarna
		'Dim thetime As Single
		'thetime = Timer
		
		For RNN = 0 To 4999
			MachineCode(1, RNN) = MasterCode(1, RNN)
			'If (MachineCode(1, RNN) >= insICON0 And MachineCode(1, RNN) <= insICON9) Or (MachineCode(1, RNN) >= insDEBUG And MachineCode(1, RNN) <= insSND9) Then MachineCode(1, RNN) = insBEEP
			If MachineCode(1, RNN) = insEND Then Exit For
		Next RNN
		
		If R2Present Then
			RobotTurretType(2) = Robot2Turret
			
			For RNN = 0 To 4999
				MachineCode(2, RNN) = MasterCode(2, RNN)
				'If (MachineCode(2, RNN) >= insICON0 And MachineCode(2, RNN) <= insICON9) Or (MachineCode(2, RNN) >= insDEBUG And MachineCode(2, RNN) <= insSND9) Then MachineCode(2, RNN) = insBEEP
				If MachineCode(2, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace2() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(2) = Robot2Energy
			RDamage(2) = Robot2Damage
		End If
		
		If R3Present Then
			RobotTurretType(3) = Robot3Turret
			
			For RNN = 0 To 4999
				MachineCode(3, RNN) = MasterCode(3, RNN)
				'If (MachineCode(3, RNN) >= insICON0 And MachineCode(3, RNN) <= insICON9) Or (MachineCode(3, RNN) >= insDEBUG And MachineCode(3, RNN) <= insSND9) Then MachineCode(3, RNN) = insBEEP
				If MachineCode(3, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace3()
			REnergy(3) = Robot3Energy
			RDamage(3) = Robot3Damage
		End If
		
		If R4Present Then
			RobotTurretType(4) = Robot4Turret
			
			For RNN = 0 To 4999
				MachineCode(4, RNN) = MasterCode(4, RNN)
				'If (MachineCode(4, RNN) >= insICON0 And MachineCode(4, RNN) <= insICON9) Or (MachineCode(4, RNN) >= insDEBUG And MachineCode(4, RNN) <= insSND9) Then MachineCode(4, RNN) = insBEEP
				If MachineCode(4, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace4() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(4) = Robot4Energy
			RDamage(4) = Robot4Damage
		End If
		
		If R5Present Then
			RobotTurretType(5) = Robot5Turret
			
			For RNN = 0 To 4999
				MachineCode(5, RNN) = MasterCode(5, RNN)
				'If (MachineCode(5,RNN) >= insICON0 And MachineCode(5,RNN) <= insICON9) Or (MachineCode(5,RNN) >= insDEBUG And MachineCode(5,RNN) <= insSND9) Then MachineCode(5,RNN) = insBEEP
				If MachineCode(5, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace5() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(5) = Robot5Energy
			RDamage(5) = Robot5Damage
		End If
		
		If R6Present Then
			RobotTurretType(6) = Robot6Turret
			
			For RNN = 0 To 4999
				MachineCode(6, RNN) = MasterCode(6, RNN)
				'If (MachineCode(6, RNN) >= insICON0 And MachineCode(6, RNN) <= insICON9) Or (MachineCode(6, RNN) >= insDEBUG And MachineCode(6, RNN) <= insSND9) Then MachineCode(6, RNN) = insBEEP
				If MachineCode(6, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace6() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(6) = Robot6Energy
			RDamage(6) = Robot6Damage
		End If
		
		'        thetime = Timer - thetime
		'        Debug.Print thetime
		
		HowManyLeft = CheckHowManyLeft
		
		'Syncs Hardware to array
		RobotShield(1) = Robot1Shield
		RobotEnergy(1) = Robot1Energy
		RobotProSpeed(1) = Robot1ProSpeed
		RobotMissiles(1) = Robot1Missiles
		RobotTacNukes(1) = Robot1TacNukes
		RobotBullets(1) = Robot1Bullets
		RobotStunners(1) = Robot1Stunners
		RobotHellbores(1) = Robot1Hellbores
		RobotMines(1) = Robot1Mines
		RobotLasers(1) = Robot1Lasers
		RobotDrones(1) = Robot1Drones
		RobotProbes(1) = Robot1Probes
		RobotShield(2) = Robot2Shield
		RobotEnergy(2) = Robot2Energy
		RobotProSpeed(2) = Robot2ProSpeed
		RobotMissiles(2) = Robot2Missiles
		RobotTacNukes(2) = Robot2TacNukes
		RobotBullets(2) = Robot2Bullets
		RobotStunners(2) = Robot2Stunners
		RobotHellbores(2) = Robot2Hellbores
		RobotMines(2) = Robot2Mines
		RobotLasers(2) = Robot2Lasers
		RobotDrones(2) = Robot2Drones
		RobotProbes(2) = Robot2Probes
		RobotShield(3) = Robot3Shield
		RobotEnergy(3) = Robot3Energy
		RobotProSpeed(3) = Robot3ProSpeed
		RobotMissiles(3) = Robot3Missiles
		RobotTacNukes(3) = Robot3TacNukes
		RobotBullets(3) = Robot3Bullets
		RobotStunners(3) = Robot3Stunners
		RobotHellbores(3) = Robot3Hellbores
		RobotMines(3) = Robot3Mines
		RobotLasers(3) = Robot3Lasers
		RobotDrones(3) = Robot3Drones
		RobotProbes(3) = Robot3Probes
		RobotShield(4) = Robot4Shield
		RobotEnergy(4) = Robot4Energy
		RobotProSpeed(4) = Robot4ProSpeed
		RobotMissiles(4) = Robot4Missiles
		RobotTacNukes(4) = Robot4TacNukes
		RobotBullets(4) = Robot4Bullets
		RobotStunners(4) = Robot4Stunners
		RobotHellbores(4) = Robot4Hellbores
		RobotMines(4) = Robot4Mines
		RobotLasers(4) = Robot4Lasers
		RobotDrones(4) = Robot4Drones
		RobotProbes(4) = Robot4Probes
		RobotShield(5) = Robot5Shield
		RobotEnergy(5) = Robot5Energy
		RobotProSpeed(5) = Robot5ProSpeed
		RobotMissiles(5) = Robot5Missiles
		RobotTacNukes(5) = Robot5TacNukes
		RobotBullets(5) = Robot5Bullets
		RobotStunners(5) = Robot5Stunners
		RobotHellbores(5) = Robot5Hellbores
		RobotMines(5) = Robot5Mines
		RobotLasers(5) = Robot5Lasers
		RobotDrones(5) = Robot5Drones
		RobotProbes(5) = Robot5Probes
		RobotShield(6) = Robot6Shield
		RobotEnergy(6) = Robot6Energy
		RobotProSpeed(6) = Robot6ProSpeed
		RobotMissiles(6) = Robot6Missiles
		RobotTacNukes(6) = Robot6TacNukes
		RobotBullets(6) = Robot6Bullets
		RobotStunners(6) = Robot6Stunners
		RobotHellbores(6) = Robot6Hellbores
		RobotMines(6) = Robot6Mines
		RobotLasers(6) = Robot6Lasers
		RobotDrones(6) = Robot6Drones
		RobotProbes(6) = Robot6Probes
		'End Syncs Hardware to array
		
		For tempnumber = 1 To NumberOfRobotsPresent
			RobotInstPos(tempnumber) = -1 'Sets robot RobotInstPos to -1 'cause t have to start with 0 (= -1 + 1 )
			RAim(tempnumber) = 90
			RobotAlive(tempnumber) = 1
			LastHiter(tempnumber) = tempnumber
			
			RChannel(tempnumber) = 1
			TeammatesInst(tempnumber) = -1
			TeammatesParam(tempnumber) = 5
			SignalInst(tempnumber) = -1
			
			RadarInst(tempnumber) = -1
			RangeInst(tempnumber) = -1
			ChrononInst(tempnumber) = -1
			CollisionInst(tempnumber) = -1
			WallInst(tempnumber) = -1
			TopInst(tempnumber) = -1
			BotInst(tempnumber) = -1
			LeftInst(tempnumber) = -1
			RightInst(tempnumber) = -1
			RobotsInst(tempnumber) = -1
			DamageInst(tempnumber) = -1
			ShieldInst(tempnumber) = -1
			RobotsParam(tempnumber) = 6
			RadarParam(tempnumber) = 600
			RangeParam(tempnumber) = 600
			TopParam(tempnumber) = 20
			BotParam(tempnumber) = 280
			LeftParam(tempnumber) = 20
			RightParam(tempnumber) = 280
			DamageParam(tempnumber) = RDamage(tempnumber)
			ShieldParam(tempnumber) = 25
			
			HistoryParam(tempnumber) = 1
			
			If RobotDrones(tempnumber) = 1 Then DroneShotDown = True
		Next tempnumber
		
		' Avläsningen av koden (BÖRJAN)
		'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*
		
		'On Error GoTo CodeError1
		
		Do While Chronon <> MaxChronon '<>
			
			fStart = VB.Timer()
			
			'ROBOT LOADING LOOP - The New Collision Stunning Shield Energy Wall Loop
			For RNN = 1 To NumberOfRobotsPresent
				If RobotAlive(RNN) = 1 Then
					If RStunned(RNN) = 0 Then
						If RShield(RNN) = 0 Then
							If RobotIconNumber(RNN) = 1 Then
								RobotIconNumber(RNN) = 0
								Robot_(RNN) = RobotMasterIcon(RNN * 10)
							End If
						Else
							If RobotShield(RNN) < RShield(RNN) Then
								RShield(RNN) = RShield(RNN) - 2
								If RShield(RNN) < 0 Then RShield(RNN) = 0 'Behövs
							Else
								If Chronon Mod 2 = 0 Then RShield(RNN) = RShield(RNN) - 1
							End If
							
							If RobotIconNumber(RNN) = 0 Then
								If RobotShieldIcon(RNN) <> 0 Then
									Robot_(RNN) = RobotMasterIcon(RNN * 10 + 1)
									RobotIconNumber(RNN) = 1
								End If
							End If
						End If
						
						If REnergy(RNN) <> RobotEnergy(RNN) Then
							If REnergy(RNN) >= -200 Then
								REnergy(RNN) = REnergy(RNN) + 2
								If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN)
							Else
								If EnableOverloading Then RobotAlive(RNN) = 255 Else REnergy(RNN) = REnergy(RNN) + 2
							End If
							
							'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							EnergyDisplay(RNN).Cls()
							'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							EnergyDisplay(RNN).Print(REnergy(RNN))
						End If
						
						If REnergy(RNN) >= 1 Then
							If RSpeedx(RNN) <> 0 Or RSpeedy(RNN) <> 0 Then 'Boosts battlespeed and reduces flickering for robots that stads still.
								RobotLeft(RNN) = RobotLeft(RNN) + RSpeedx(RNN)
								RobotTop(RNN) = RobotTop(RNN) + RSpeedy(RNN)
								TurretX2(RNN) = TurretX2(RNN) + RSpeedx(RNN)
								TurretY2(RNN) = TurretY2(RNN) + RSpeedy(RNN)
							End If
						End If
					End If 'RStunned
					
					'PREPARING THE COLLISION WITH EACH OTHER LOOP
					If RobotIconNumber(RNN) >= 100 Then 'Switches off the collision/block/hit icons if it's on
						RobotIconNumber(RNN) = RobotIconNumber(RNN) - 100 'Switches back from collisionicon
						If RobotIconNumber(RNN) <> 10 Then Robot_(RNN) = RobotMasterIcon(RNN * 10 + RobotIconNumber(RNN)) Else Robot_(RNN) = RobotMasterIcon(RNN * 10 + 1)
					End If
					
					For tempnumber = 1 To NumberOfRobotsPresent '''Kollision med varandra, Skall Nu vara nästintill perfekt (Haha! Kul! ;))
						If RNN <> tempnumber Then
							If RobotAlive(tempnumber) = 1 Then
								If (RobotLeft(RNN) - RobotLeft(tempnumber)) * (RobotLeft(RNN) - RobotLeft(tempnumber)) + (RobotTop(RNN) - RobotTop(tempnumber)) * (RobotTop(RNN) - RobotTop(tempnumber)) <= 400 Then
									If RCollision(RNN) = 0 Then
										RCollision(RNN) = tempnumber '' Var 1 förut nu registrerar den vilken robot den kolliderar med
										If RShield(RNN) > 0 Then RShield(RNN) = RShield(RNN) - 1 Else RDamage(RNN) = RDamage(RNN) - 1 'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
										DR(RNN).Text = CStr(RDamage(RNN)) 'DR(RNN).Refresh
										
										If PlaySounds Then
											If RobotCollisionSound(tempnumber) Then
												PlaySnd1((tempnumber))
											ElseIf RobotCollisionSound(RNN) Then 
												PlaySnd1((RNN))
											Else
												sndPlaySound(collisionsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
											End If
										End If
										
										If RStunned(RNN) = 0 And REnergy(RNN) >= 1 Then
											RobotLeft(RNN) = RobotLeft(RNN) - RSpeedx(RNN)
											RobotTop(RNN) = RobotTop(RNN) - RSpeedy(RNN)
											TurretX2(RNN) = TurretX2(RNN) - RSpeedx(RNN)
											TurretY2(RNN) = TurretY2(RNN) - RSpeedy(RNN)
										End If
									End If
									
									If RCollision(tempnumber) = 0 Then
										RCollision(tempnumber) = RNN
										If RShield(tempnumber) > 0 Then RShield(tempnumber) = RShield(tempnumber) - 1 Else RDamage(tempnumber) = RDamage(tempnumber) - 1 'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
										DR(tempnumber).Text = CStr(RDamage(tempnumber)) 'DR(TempNumber).Refresh
										
										'If RStunned(TempNumber) = 0 And REnergy(TempNumber) >= 1 Then
										If RStunned(tempnumber) = 0 And REnergy(tempnumber) - 2 * CShort(tempnumber > RNN) >= 1 Then
											RobotLeft(tempnumber) = RobotLeft(tempnumber) - RSpeedx(tempnumber)
											RobotTop(tempnumber) = RobotTop(tempnumber) - RSpeedy(tempnumber)
											TurretX2(tempnumber) = TurretX2(tempnumber) - RSpeedx(tempnumber)
											TurretY2(tempnumber) = TurretY2(tempnumber) - RSpeedy(tempnumber)
										End If
									End If
								End If
							End If
						End If
					Next tempnumber
					
					'KOLLISION MED VÄGGARNA - WALL COLLISION
					If WCX(RobotLeft(RNN)) Or WCY(RobotTop(RNN)) Then
						RWall(RNN) = 1
						RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - 5 + RShield(RNN))
						RShield(RNN) = ZeroOrMore(RShield(RNN) - 5)
						DR(RNN).Text = CStr(RDamage(RNN))
						If PlaySounds Then
							If RobotCollisionSound(RNN) Then
								PlaySnd1((RNN))
							Else
								sndPlaySound(collisionsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
							End If
						End If
						
						If RobotLeft(RNN) > 300 Then 'otherwise it can use SPEEDX to run outside the areana
							TurretX2(RNN) = 300 + TurretX2(RNN) - RobotLeft(RNN)
							RobotLeft(RNN) = 300
						ElseIf RobotLeft(RNN) < 0 Then 
							TurretX2(RNN) = TurretX2(RNN) - RobotLeft(RNN)
							RobotLeft(RNN) = 0
						End If
						If RobotTop(RNN) > 300 Then
							TurretY2(RNN) = 300 + TurretY2(RNN) - RobotTop(RNN)
							RobotTop(RNN) = 300
						ElseIf RobotTop(RNN) < 0 Then 
							TurretY2(RNN) = TurretY2(RNN) - RobotTop(RNN)
							RobotTop(RNN) = 0
						End If
					Else
						RWall(RNN) = 0
					End If
				End If 'Alive if
			Next RNN
			
			For RNN = 1 To NumberOfRobotsPresent
				If HighestToLowest Then RNN = NumberOfRobotsPresent - RNN + 1 'Turns on backwards evaluation if it's enabled
				'Kan räknas ut i förväg??
				If RobotAlive(RNN) = 1 Then
					'ROBOT 1 CHRONON EXECUTOR
					If RStunned(RNN) = 0 And REnergy(RNN) >= 1 Then
						
						'''*********INTERUPPSKODEN*********
						'Each interrupt has a particular priority.  From highest priority to lowest, the interrupts are:
						'COLLISION, WALL, DAMAGE, SHIELD, TOP, BOTTOM, LEFT, RIGHT, RADAR, RANGE, TEAMMATES, ROBOTS,
						'SIGNAL, CHRONON.  If two interrupts occur at exactly the same time, the one with higher priority
						'is processed first.
						
						'riktig                 'Min
						'COLLISION  q           'COLLISION  q
						'WALL       q           'WALL       q
						'DAMAGE     q           'DAMAGE     q
						'SHIELD     q           'SHIELD     q
						'TOP        q           'TOP        ql
						'BOTTOM     q           'BOTTOM     ql
						'LEFT       q           'LEFT       ql
						'RIGHT      q           'RIGHT      ql
						'RADAR      n           'TEAMMATES  qss
						'RANGE      n           'ROBOTS !!  qss     'Fel ordning i kön  'Vi skulle kunna sänka till botten genom att sätta RobotInstPos på dödskoden istället
						'TEAMMATES  q           'SIGNAL     qsss
						'ROBOTS     q           'RADAR      n
						'SIGNAL     q           'RANGE      n
						'CHRONON    n           'CHRONON    n
						
						If TopInst(RNN) >= 0 Then
							If RSpeedy(RNN) < 0 Then
								If RobotTop(RNN) <= TopParam(RNN) Then
									If RobotTop(RNN) - RSpeedy(RNN) > TopParam(RNN) Then
										RobotQuePos(RNN) = RobotQuePos(RNN) + 1
										RobotIntQue(RNN, RobotQuePos(RNN)) = TopInst(RNN)
										IntID(RNN, RobotQuePos(RNN)) = 1
									End If
								End If
							End If
						End If
						If BotInst(RNN) >= 0 Then
							If RSpeedy(RNN) > 0 Then
								If RobotTop(RNN) >= BotParam(RNN) Then
									If RobotTop(RNN) - RSpeedy(RNN) < BotParam(RNN) Then
										RobotQuePos(RNN) = RobotQuePos(RNN) + 1
										RobotIntQue(RNN, RobotQuePos(RNN)) = BotInst(RNN)
										IntID(RNN, RobotQuePos(RNN)) = 2
									End If
								End If
							End If
						End If
						If LeftInst(RNN) >= 0 Then
							If RSpeedx(RNN) < 0 Then
								If RobotLeft(RNN) <= LeftParam(RNN) Then
									If RobotLeft(RNN) - RSpeedx(RNN) > LeftParam(RNN) Then
										RobotQuePos(RNN) = RobotQuePos(RNN) + 1
										RobotIntQue(RNN, RobotQuePos(RNN)) = LeftInst(RNN)
										IntID(RNN, RobotQuePos(RNN)) = 3
									End If
								End If
							End If
						End If
						If RightInst(RNN) >= 0 Then
							If RSpeedx(RNN) > 0 Then
								If RobotLeft(RNN) >= RightParam(RNN) Then
									If RobotLeft(RNN) - RSpeedx(RNN) < RightParam(RNN) Then
										RobotQuePos(RNN) = RobotQuePos(RNN) + 1
										RobotIntQue(RNN, RobotQuePos(RNN)) = RightInst(RNN)
										IntID(RNN, RobotQuePos(RNN)) = 4
									End If
								End If
							End If
						End If
						
						If ShieldInst(RNN) >= 0 Then 'If it's using the shield int
							If RShield(RNN) < ShieldParam(RNN) Then 'If we're in low shield
								If ShieldInst(RNN) < 5000 Then 'And we weren't in low shield last chronon (then shieldinst should be > 4999)
									RobotQuePos(RNN) = RobotQuePos(RNN) + 1 'que the
									RobotIntQue(RNN, RobotQuePos(RNN)) = ShieldInst(RNN) 'interupt
									IntID(RNN, RobotQuePos(RNN)) = 5
									ShieldInst(RNN) = ShieldInst(RNN) + 5000
								End If
							Else 'If we're not in low shield anymore
								If ShieldInst(RNN) > 4999 Then 'and our shieldinst is set to a weird value then
									ShieldInst(RNN) = ShieldInst(RNN) - 5000 'Sets back shieldinst to it's real value
								End If
							End If
						End If
						If DamageInst(RNN) >= 0 Then
							If RDamage(RNN) < DamageParam(RNN) Then
								RobotQuePos(RNN) = RobotQuePos(RNN) + 1
								RobotIntQue(RNN, RobotQuePos(RNN)) = DamageInst(RNN)
								IntID(RNN, RobotQuePos(RNN)) = 6
								DamageParam(RNN) = RDamage(RNN)
							End If
						End If
						If WallInst(RNN) >= 0 Then 'If it's using the wall int
							If RWall(RNN) <> 0 Then 'If we're in wall
								If WallInst(RNN) < 5000 Then 'And we weren't in wall last chronon (then wallinst should be > 4999)
									RobotQuePos(RNN) = RobotQuePos(RNN) + 1 'que the
									RobotIntQue(RNN, RobotQuePos(RNN)) = WallInst(RNN) 'interupt
									IntID(RNN, RobotQuePos(RNN)) = 7
									WallInst(RNN) = WallInst(RNN) + 5000
								End If
							Else 'If we're not in wall anymore
								If WallInst(RNN) > 4999 Then 'and our wall inst is set to a weird value then
									WallInst(RNN) = WallInst(RNN) - 5000 'Sets back wallinst to it's real value
								End If
							End If 'COLLISION AND WALL SHOULD BE MUCH MORE CAREFULLY TESTED!!
						End If
						If CollisionInst(RNN) >= 0 Then 'If it's using the collision int
							If RCollision(RNN) <> 0 Then 'If we're in collision
								If CollisionInst(RNN) < 5000 Then 'And we weren't in collision last chronon (then collisioninst should be > 4999)
									RobotQuePos(RNN) = RobotQuePos(RNN) + 1 'que the
									RobotIntQue(RNN, RobotQuePos(RNN)) = CollisionInst(RNN) 'interupt
									IntID(RNN, RobotQuePos(RNN)) = 8
									CollisionInst(RNN) = CollisionInst(RNN) + 5000
								End If
							Else 'If we're not in collision anymore
								If CollisionInst(RNN) > 4999 Then 'and our collision inst is set to a weird value then
									CollisionInst(RNN) = CollisionInst(RNN) - 5000 'Sets back collisioninst to it's real value
								End If
							End If
						End If
						
						If RobotQuePos(RNN) > 1 Then 'This is hopefully only a temporary solution for doubletrigging problems
							If RobotIntQue(RNN, RobotQuePos(RNN)) = RobotIntQue(RNN, RobotQuePos(RNN) - 1) And IntID(RNN, RobotQuePos(RNN)) = IntID(RNN, RobotQuePos(RNN) - 1) Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
						End If
						
						If Inton(RNN) Then
							If RobotQuePos(RNN) > 0 Then
								If RobotStackPos(RNN) > 99 Then
                                    ErrorCode = BuggyOverflow
								End If
								RobotStackPos(RNN) = RobotStackPos(RNN) + 1
								RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
								RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1 'qued ints subtracted when triggered             'jumps shall be done
								Inton(RNN) = False
								RobotQuePos(RNN) = RobotQuePos(RNN) - 1
								GoTo SkipTheRestOfTheInts
							ElseIf RadarInst(RNN) >= 0 Then 
								'RADAR
								RRadar = 0
								For shotcounter = 1 To ShotNumber
									If shot(shotcounter).ShotType < 200 Then
										'This is David Harris radar code, ported to Visual Basic by me.
										trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
										trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
										
										If trigx <> 0 Then 'atan2
											tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
										Else
											tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
										End If '''''''
										
										If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
										
										If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
											RRange = FixSquare(trigx * trigx + trigy * trigy)
											If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
										End If
									End If
								Next shotcounter
								'/RADAR
								If RRadar <> 0 Then
									If RRadar <= RadarParam(RNN) Then 'intrange sends back 601 for no range instead of 0
										If RobotStackPos(RNN) > 99 Then
                                            ErrorCode = BuggyOverflow
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) + 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
										RobotInstPos(RNN) = RadarInst(RNN) - 1 ' -1 är nytt
										Inton(RNN) = False
										GoTo SkipTheRestOfTheInts
									End If
								End If
							End If
							If RangeInst(RNN) >= 0 Then
								'intrange is faster than ordinary range, but it returns 601 when nobody is ranged
								RRange = 601
								RRadar = RAim(RNN) + RLook(RNN)
								
								For shotcounter = 1 To NumberOfRobotsPresent
									If shotcounter <> RNN Then 'Skip checking range to self. It'll be too short
										tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
										trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
										trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
										
										If trigx * trigx + trigy * trigy > 91 Then tempnumber = 601 'This should be faster
										
										If tempnumber < RRange Then
											RRange = tempnumber
											RangedRobot(RNN) = shotcounter
										End If
									End If
								Next shotcounter
								
								If RobotTeam(RNN) <> 0 Then
									If RRange <> 601 Then
										If RobotTeam(RNN) = RobotTeam(RangedRobot(RNN)) Then RRange = 601
									End If
								End If
								'''''''''''
								If RRange <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
									If RobotAlive(RangedRobot(RNN)) = 1 Then
										If RobotStackPos(RNN) > 99 Then
                                            ErrorCode = BuggyOverflow
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) + 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
										RobotInstPos(RNN) = RangeInst(RNN) - 1 ' -1 är nytt
										Inton(RNN) = False
										GoTo SkipTheRestOfTheInts
									End If
								End If
							End If
							If ChrononInst(RNN) >= 0 Then
								If ChrononParam(RNN) <= Chronon Then
									If RobotStackPos(RNN) > 99 Then
                                        ErrorCode = BuggyOverflow
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) + 1
									RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
									RobotInstPos(RNN) = ChrononInst(RNN) - 1
									Inton(RNN) = False
								End If
							End If
						End If
						
SkipTheRestOfTheInts: 
						
						'''Slut INTERUPPSKODEN
						
						'Typ här skall hasmoved bli falskt
						HasMoved = 0
						
						For ChrononExecutor1 = 1 To RobotProSpeed(RNN)
							RobotInstPos(RNN) = RobotInstPos(RNN) + 1
							If DebuggedRobot = RNN Or (StartDebuggerAt = Chronon And ChrononExecutor1 = 1 And RNN = WillBeDebugged) Then '*******THE DEBUGGER - For robots that's not out of energy
								If ChrononStepping <= Chronon Then
									ChrononStart() 'This sub is required when the debugger is set to start at a certain chronon
									
									'UPGRADE_ISSUE: PictureBox method Arena.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									Arena.Cls()
									For shotcounter = 1 To ShotNumber 'Repaint all shots
										DebuggerPaintShot(shot(shotcounter))
									Next shotcounter
									For shotcounter = 1 To NumberOfRobotsPresent 'Repaint the robots
										DebuggerPaint(RobotAlive(shotcounter), RobotTurretType(shotcounter), shotcounter)
									Next shotcounter
									
									RRange = Range(RNN, RAim(RNN) + RLook(RNN)) 'Calculate range
									If RRange <> 0 Then
										If RobotAlive(RangedRobot(RNN)) <> 1 Then RRange = 0
									End If
									If RRange = 0 Then RangedRobot(RNN) = 0 'Kan inte flyttas eller trixas med se raden ovan
									
									RRadar = 0
									For shotcounter = 1 To ShotNumber 'Calculate radar
										If shot(shotcounter).ShotType < 200 Then
											tempnumber = Radar(RNN, shot(shotcounter).ShotX, shot(shotcounter).ShotY, RAim(RNN) + RScan(RNN))
											If (tempnumber < RRadar Or RRadar = 0) And tempnumber <> 0 Then RRadar = tempnumber
										End If
									Next shotcounter
									
									If RobotStackPos(RNN) <= 96 Then tempnumber = ((RobotStackPos(RNN) - 1) \ 6) * 6 Else tempnumber = 0
									
									PrintDebuggingInfo(RobotInstPos(RNN), MachineCode(RNN, RobotInstPos(RNN)), RobotStackPos(RNN), RobotStack(RNN, 1 + tempnumber), RobotStack(RNN, 2 + tempnumber), RobotStack(RNN, 3 + tempnumber), RobotStack(RNN, 4 + tempnumber), RobotStack(RNN, 5 + tempnumber), RobotStack(RNN, 6 + tempnumber), RobotStack(RNN, 100), RobotStack(RNN, 99), RobotStack(RNN, 98), RobotStack(RNN, 97), ChrononExecutor1, RAim(RNN), RShield(RNN), RRange, RangedRobot(RNN), RRadar, RLook(RNN), RScan(RNN), RSpeedx(RNN), RSpeedy(RNN), REnergy(RNN))
									
									PrintInts(Inton(RNN), LeftParam(RNN), RightParam(RNN), TopParam(RNN), BotParam(RNN), LeftInst(RNN), RightInst(RNN), TopInst(RNN), BotInst(RNN), RadarParam(RNN), RadarInst(RNN), RangeInst(RNN), RangeParam(RNN), RobotQuePos(RNN), RobotIntQue(RNN, 1), RobotIntQue(RNN, 2))
									ReturnMacAdd() 'ReturnMacAdd contains the stop/resume execution instructions
									
									If DebuggingWindow.DebuggingRes = 1 Then 'Determine what button in the debugger
										ChrononStepping = Chronon + 1 'the user pressed
										SetTabIndex1()
									ElseIf DebuggingWindow.DebuggingRes = 2 Then 
										TurnOfTheDebugger()
									ElseIf DebuggingWindow.DebuggingRes = 3 Then 
										GoTo Peace
									Else
										SetTabIndex2()
									End If
								End If
							End If
							
							Select Case MachineCode(RNN, RobotInstPos(RNN)) 'Interpret the current instruction
								Case -19999 To 19999
									If RobotStackPos(RNN) > 99 Then
										ErrorCode = BuggyOverflow : GoTo Buggy
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) + 1
									RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
								Case insA To TOPREGISTER
									If RobotStackPos(RNN) > 99 Then
										ErrorCode = BuggyOverflow : GoTo Buggy
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) + 1
									RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
								Case insSTORE
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									Select Case RobotStack(RNN, RobotStackPos(RNN))
										Case insAIM 'ins
											RAim(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Mod 360
											'                                If RAim(RNN) > 359 Then RAim(RNN) = RAim(RNN) Mod 360
											'                                If RAim(RNN) < 0 Then RAim(RNN) = RAim(RNN) Mod 360 + 360
											If RAim(RNN) < 0 Or RAim(RNN) > 359 Then RAim(RNN) = RAim(RNN) Mod 360 - 360 * CShort(RAim(RNN) < 0)
											
											TurretX2(RNN) = RobotLeft(RNN) + Sin10(RAim(RNN))
											TurretY2(RNN) = RobotTop(RNN) - Cos10(RAim(RNN))
											If Inton(RNN) Then '**********Interuppskod************'
												If RadarInst(RNN) >= 0 Then
													'RADAR
													RRadar = 0
													For shotcounter = 1 To ShotNumber
														If shot(shotcounter).ShotType < 200 Then
															'This is David Harris radar code, ported to Visual Basic by me.
															trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
															trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
															
															If trigx <> 0 Then 'atan2
																tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
															Else
																tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
															End If '''''''
															
															If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
															
															If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
																RRange = FixSquare(trigx * trigx + trigy * trigy)
																If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
															End If
														End If
													Next shotcounter
													'/RADAR
													If RRadar <> 0 Then
														If RRadar <= RadarParam(RNN) Then 'intrange sends back 601 for no range instead of 0
															RobotStackPos(RNN) = RobotStackPos(RNN) - 1
															RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
															RobotInstPos(RNN) = RadarInst(RNN) - 1
															Inton(RNN) = False
															GoTo NoStackRemoval
														End If
													End If
												End If
												If RangeInst(RNN) >= 0 Then
													'intrange is faster than ordinary range, but it returns 601 when nobody is ranged
													RRange = 601
													RRadar = RAim(RNN) + RLook(RNN)
													
													For shotcounter = 1 To NumberOfRobotsPresent
														If shotcounter <> RNN Then 'Skip checking range to self. It'll be too short
															tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
															trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
															trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
															
															If trigx * trigx + trigy * trigy > 91 Then tempnumber = 601 'This should be faster
															
															If tempnumber < RRange Then
																RRange = tempnumber
																RangedRobot(RNN) = shotcounter
															End If
														End If
													Next shotcounter
													
													If RobotTeam(RNN) <> 0 Then
														If RRange <> 601 Then
															If RobotTeam(RNN) = RobotTeam(RangedRobot(RNN)) Then RRange = 601
														End If
													End If
													'''''''''''
													If RRange <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
														If RobotAlive(RangedRobot(RNN)) = 1 Then
															RobotStackPos(RNN) = RobotStackPos(RNN) - 1
															RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
															RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
															Inton(RNN) = False
															GoTo NoStackRemoval
														End If
													End If
												End If
											End If '**********Slut Interuppskod************'
										Case insSPEEDX 'ins
											If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1))
											REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RSpeedx(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
											RSpeedx(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insSPEEDY 'ins
											If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1))
											REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RSpeedy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
											RSpeedy(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insMISSILE 'ins
											If RobotMissiles(RNN) = 0 Then
												ErrorCode = BuggyMissiles
												GoTo Buggy
											Else
												If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
													REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
													If HasMoved <> 5 Or MoveAndShotAllowed Then
														If PlaySounds Then sndPlaySound(missilesound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT) 'Or SND_NOSTOP
														If FreeShot = -1 Then
															ShotNumber = ShotNumber + 1
															shot(ShotNumber).ShotAngle = RAim(RNN)
															shot(ShotNumber).ShotType = Missile
															shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
															shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
															shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
															shot(ShotNumber).Shooter = RNN
														Else
															shot(FreeShot).ShotAngle = RAim(RNN)
															shot(FreeShot).ShotType = Missile
															shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
															shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
															shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
															shot(FreeShot).Shooter = RNN
															FreeShot = -1
														End If
														HasMoved = 20
													Else
														ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
													End If
												End If
											End If
										Case insFIRE 'ins
Robot1Fire: 
											If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
												If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
												REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
												If HasMoved <> 5 Or MoveAndShotAllowed Then
													If PlaySounds Then sndPlaySound(bulletsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
													If FreeShot = -1 Then
														ShotNumber = ShotNumber + 1
														shot(ShotNumber).ShotAngle = RAim(RNN)
														shot(ShotNumber).ShotType = Bullet
														shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
														shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
														shot(ShotNumber).Shooter = RNN
														Select Case RobotBullets(RNN)
															Case 0
																shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2 '/
															Case 2
																shot(ShotNumber).ShotType = ExplosiveBullet
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															Case 20
																RobotBullets(RNN) = 2
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															Case Else
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
														End Select
													Else
														shot(FreeShot).ShotAngle = RAim(RNN)
														shot(FreeShot).ShotType = Bullet
														shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
														shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
														shot(FreeShot).Shooter = RNN
														Select Case RobotBullets(RNN)
															Case 0
																shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2 '
															Case 2
																shot(FreeShot).ShotType = ExplosiveBullet
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															Case 20
																RobotBullets(RNN) = 2
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															Case Else
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
														End Select
														FreeShot = -1
													End If
													HasMoved = 20
												Else
													ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
												End If
											End If
										Case insSHIELD 'ins
											If RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then 'Prevent negative shield
												If RobotStack(RNN, RobotStackPos(RNN) - 1) > 150 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 150 'Prevent shield over 150
												REnergy(RNN) = REnergy(RNN) + RShield(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Takes or energy restores energy to/from shield
												If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN) 'Prevent energy higher than Robots Energy Max
												RShield(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Sets shield
											End If
										Case insSTUNNER 'ins
											If RobotStunners(RNN) = 0 Then
												ErrorCode = BuggyStunners
												GoTo Buggy
											Else
												If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
													REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
													If HasMoved <> 5 Or MoveAndShotAllowed Then
														If FreeShot = -1 Then 'Stunner don't use freeshots because of the (Stunstreamer - Freeshot) visual bug which is fixed so they do
															ShotNumber = ShotNumber + 1
															shot(ShotNumber).ShotAngle = RAim(RNN)
															shot(ShotNumber).ShotType = Stunner
															shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
															shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
															shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4 'Int((RobotStack(RNN, RobotStackPos(RNN) - 1)) / 4)
														Else
															shot(FreeShot).ShotAngle = RAim(RNN)
															shot(FreeShot).ShotType = Stunner
															shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
															shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
															shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4
															FreeShot = -1
														End If
														HasMoved = 20
													Else
														ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
													End If
												End If
											End If
										Case insMOVEX 'ins
											REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
											If HasMoved <> 20 Or MoveAndShotAllowed Then
												RobotLeft(RNN) = RobotLeft(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
												TurretX2(RNN) = TurretX2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RobotLeft(RNN) > 300 Then 'otherwise it can use MOVEX to jump outside the areana!!!
													RobotLeft(RNN) = 300
													TurretX2(RNN) = 300 + TurretX2(RNN) - RobotLeft(RNN)
												ElseIf RobotLeft(RNN) < 0 Then 
													RobotLeft(RNN) = 0
													TurretX2(RNN) = TurretX2(RNN) - RobotLeft(RNN)
												End If
												HasMoved = 5
											Else
												ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
											End If
										Case insMOVEY 'ins
											REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
											If HasMoved <> 20 Or MoveAndShotAllowed Then
												RobotTop(RNN) = RobotTop(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
												TurretY2(RNN) = TurretY2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RobotTop(RNN) > 300 Then 'otherwise it can use MOVEX to jump outside the areana!!!
													RobotTop(RNN) = 300
													TurretY2(RNN) = 300 + TurretY2(RNN) - RobotTop(RNN)
												ElseIf RobotTop(RNN) < 0 Then 
													RobotTop(RNN) = 0
													TurretY2(RNN) = TurretY2(RNN) - RobotTop(RNN)
												End If
												HasMoved = 5
											Else
												ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
											End If
										Case insHELLBORE 'ins
											If RobotHellbores(RNN) = 0 Then
												ErrorCode = BuggyHellbores
												GoTo Buggy
											Else
												If RobotStack(RNN, RobotStackPos(RNN) - 1) > 3 And RobotStack(RNN, RobotStackPos(RNN) - 1) < 21 Then
													REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
													If HasMoved <> 5 Or MoveAndShotAllowed Then
														If PlaySounds Then sndPlaySound(hellboresound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
														If FreeShot = -1 Then
															ShotNumber = ShotNumber + 1
															shot(ShotNumber).ShotAngle = RAim(RNN)
															shot(ShotNumber).ShotType = Hellbore
															shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
															shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
															shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
														Else
															shot(FreeShot).ShotAngle = RAim(RNN)
															shot(FreeShot).ShotType = Hellbore
															shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
															shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
															shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															FreeShot = -1
														End If
														HasMoved = 20
													Else
														ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
													End If
												End If
											End If
										Case insA : RA(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insB : RB(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insC : RC(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insD : RD(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insE : RE(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insF : RF(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insG : RG(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insH : RH(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insI : RI(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insJ : RJ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insK : RK(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insL : RL(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insM : RM(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insN : RN(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insO : RO(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insP : RP(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insQ : RQ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insR : RR(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insS : RS(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case Inst : RT(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insU : RU(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insV : RV(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insZ : RZ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insW : RW(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insLOOK 'ins
											RLook(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If RLook(RNN) > 359 Then RLook(RNN) = RLook(RNN) Mod 360
											If RLook(RNN) < 0 Then RLook(RNN) = RLook(RNN) Mod 360 + 360
											If Inton(RNN) And RangeInst(RNN) >= 0 Then '**********Interuppskod************
												'intrange is faster than ordinary range, but it returns 601 when nobody is ranged
												RRange = 601
												RRadar = RAim(RNN) + RLook(RNN)
												
												For shotcounter = 1 To NumberOfRobotsPresent
													If shotcounter <> RNN Then 'Skip checking range to self. It'll be too short
														tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
														trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
														trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
														
														If trigx * trigx + trigy * trigy > 91 Then tempnumber = 601 'This should be faster
														
														If tempnumber < RRange Then
															RRange = tempnumber
															RangedRobot(RNN) = shotcounter
														End If
													End If
												Next shotcounter
												
												If RobotTeam(RNN) <> 0 Then
													If RRange <> 601 Then
														If RobotTeam(RNN) = RobotTeam(RangedRobot(RNN)) Then RRange = 601
													End If
												End If
												'''''''''''
												If RRange <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
													
													If RobotAlive(RangedRobot(RNN)) = 1 Then
														RobotStackPos(RNN) = RobotStackPos(RNN) - 1
														RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
														RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
														Inton(RNN) = False
														GoTo NoStackRemoval
													End If
												End If
											End If '**********Slut Interuppskod************'
										Case insBULLET 'ins                                 'It seems like a robot can mess up it's explosive
											If RobotBullets(RNN) = 2 Then RobotBullets(RNN) = 20 'bullets by firing negative shots. It's certainly
											GoTo Robot1Fire 'not an adventage, so it' can't be considered cheating
										Case insNUKE 'ins
											If RobotTacNukes(RNN) = 0 Then
												ErrorCode = BuggyTacNukes
												GoTo Buggy
											Else
												If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
													REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
													If HasMoved <> 5 Or MoveAndShotAllowed Then
														If FreeShot = -1 Then
															ShotNumber = ShotNumber + 1
															shot(ShotNumber).ShotFireTime = Chronon
															shot(ShotNumber).ShotType = TakeNuke
															shot(ShotNumber).ShotX = RobotLeft(RNN)
															shot(ShotNumber).ShotY = RobotTop(RNN)
															shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															shot(ShotNumber).Shooter = RNN
														Else
															shot(FreeShot).ShotFireTime = Chronon
															shot(FreeShot).ShotType = TakeNuke
															shot(FreeShot).ShotX = RobotLeft(RNN)
															shot(FreeShot).ShotY = RobotTop(RNN)
															shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															shot(FreeShot).Shooter = RNN
															FreeShot = -1
														End If
														HasMoved = 20
													Else
														ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
													End If
												End If
											End If
										Case insMEGANUKE 'ins
											If RobotTacNukes(RNN) = 0 Then
												ErrorCode = BuggyTacNukes
												GoTo Buggy
											Else
												If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
													REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
													If HasMoved <> 5 Or MoveAndShotAllowed Then
														If FreeShot = -1 Then
															ShotNumber = ShotNumber + 1
															shot(ShotNumber).ShotFireTime = Chronon
															shot(ShotNumber).ShotType = MegaNuke
															shot(ShotNumber).ShotX = RobotLeft(RNN)
															shot(ShotNumber).ShotY = RobotTop(RNN)
															shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															shot(ShotNumber).Shooter = RNN
														Else
															shot(FreeShot).ShotFireTime = Chronon
															shot(FreeShot).ShotType = MegaNuke
															shot(FreeShot).ShotX = RobotLeft(RNN)
															shot(FreeShot).ShotY = RobotTop(RNN)
															shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															shot(FreeShot).Shooter = RNN
															FreeShot = -1
														End If
														HasMoved = 20
													Else
														ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
													End If
												End If
											End If
										Case insMINE 'ins
											If RobotMines(RNN) = 0 Then
												ErrorCode = BuggyMines
												GoTo Buggy
											Else
												If RobotStack(RNN, RobotStackPos(RNN) - 1) - 5 > 0 Then
													REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
													If HasMoved <> 5 Or MoveAndShotAllowed Then
														If PlaySounds Then sndPlaySound(minesound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
														If FreeShot = -1 Then
															ShotNumber = ShotNumber + 1
															shot(ShotNumber).ShotFireTime = Chronon
															shot(ShotNumber).ShotType = Mine
															shot(ShotNumber).ShotX = RobotLeft(RNN)
															shot(ShotNumber).ShotY = RobotTop(RNN)
															shot(ShotNumber).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
															shot(ShotNumber).Shooter = RNN
														Else
															shot(FreeShot).ShotFireTime = Chronon
															shot(FreeShot).ShotType = Mine
															shot(FreeShot).ShotX = RobotLeft(RNN)
															shot(FreeShot).ShotY = RobotTop(RNN)
															shot(FreeShot).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
															shot(FreeShot).Shooter = RNN
															FreeShot = -1
														End If
														HasMoved = 20
													Else
														ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
													End If
												End If
											End If
										Case insLASER 'ins
											If RobotLasers(RNN) = 0 Then
												ErrorCode = BuggyLasers
												GoTo Buggy
											Else
												If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then ' It is possible in the Mac version to shoot laser shots that actually doesn't do any harm
													If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'It seems to be possible to shoot laser at dead robots
														If RobotAlive(RangedRobot(RNN)) = 1 Then
															'If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
															If RobotStack(RNN, RobotStackPos(RNN) - 1) > REnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = REnergy(RNN)
															
															REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
															If HasMoved <> 5 Or MoveAndShotAllowed Then
																If PlaySounds Then sndPlaySound(lasersound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
																'                                                   TurretX2(RNN) = RobotLeft(RNN) + sin10(RAim(RNN))  'FOR UNDISPLAYED!!!
																'                                                   TurretY2(RNN) = RobotTop(RNN) - cos10(RAim(RNN))  'FOR UNDISPLAYED!!!
																
																If FreeShot = -1 Then
																	ShotNumber = ShotNumber + 1
																	shot(ShotNumber).ShotType = Laser
																	shot(ShotNumber).ShotAngle = RangedRobot(RNN)
																	shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
																	shot(ShotNumber).Shooter = RNN
																	shot(ShotNumber).ShotFireTime = RAim(RNN) 'Ta bort i undisplayed!
																	shot(ShotNumber).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN) 'Shows laser on radar instantly
																	shot(ShotNumber).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
																Else
																	shot(FreeShot).ShotType = Laser
																	shot(FreeShot).ShotAngle = RangedRobot(RNN)
																	shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
																	shot(FreeShot).Shooter = RNN
																	shot(FreeShot).ShotFireTime = RAim(RNN) 'Ta bort i undisplayed!
																	shot(FreeShot).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN) 'Shows laser on radar instantly
																	shot(FreeShot).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
																	FreeShot = -1
																End If
																HasMoved = 20
															Else
																ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
															End If
														End If
													End If
												End If
											End If
										Case insDRONE 'ins
											If RobotDrones(RNN) = 0 Then
												ErrorCode = BuggyDrones
												GoTo Buggy
											Else
												If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 And Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'Range <> 0
													If RobotAlive(RangedRobot(RNN)) = 1 Then 'Cuts down the shot power to the Robots energy max
														If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If PlaySounds Then
																If Chronon - DroneSoundPlayed(RNN) >= 3 Or Not (Normal.Checked Or Slow.Checked) Or DebuggedRobot = RNN Then
																	sndPlaySound(DroneSound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
																	DroneSoundPlayed(RNN) = Chronon
																End If
															End If
															If FreeShot = -1 Then
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotAngle = RangedRobot(RNN) 'Shootangle represents tracking robot
																shot(ShotNumber).ShotFireTime = Chronon + 100 'ShotFireTime represents the chronon the drone die
																shot(ShotNumber).ShotType = Drone
																shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
																shot(ShotNumber).Shooter = RNN
															Else
																shot(FreeShot).ShotAngle = RangedRobot(RNN) 'Shootangle represents tracking robot
																shot(FreeShot).ShotFireTime = Chronon + 100 'ShotFireTime represents the chronon the drone die
																shot(FreeShot).ShotType = Drone
																shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
																shot(FreeShot).Shooter = RNN
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											End If
										Case insSCAN 'ins
											RScan(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If RScan(RNN) > 359 Then RScan(RNN) = RScan(RNN) Mod 360
											If RScan(RNN) < 0 Then RScan(RNN) = RScan(RNN) Mod 360 + 360
											If Inton(RNN) And RadarInst(RNN) >= 0 Then
												'RADAR
												RRadar = 0
												For shotcounter = 1 To ShotNumber
													If shot(shotcounter).ShotType < 200 Then
														'This is David Harris radar code, ported to Visual Basic by me.
														trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
														trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
														
														If trigx <> 0 Then 'atan2
															tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
														Else
															tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
														End If '''''''
														
														If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
														
														If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
															RRange = FixSquare(trigx * trigx + trigy * trigy)
															If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
														End If
													End If
												Next shotcounter
												'/RADAR
												If RRadar <> 0 Then
													If RRadar <= RadarParam(RNN) Then
														RobotStackPos(RNN) = RobotStackPos(RNN) - 1
														RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
														RobotInstPos(RNN) = RadarInst(RNN) - 1 ' - 1 nytt
														Inton(RNN) = False
														GoTo NoStackRemoval
													End If
												End If
											End If
										Case insHISTORY 'ins
											If HistoryParam(RNN) >= 31 Then HistoryRec(RNN, HistoryParam(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insSIGNAL
											If RobotTeam(RNN) <> 0 Then
												RSignal(RobotTeam(RNN), RChannel(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												
												For tempnumber = 1 To NumberOfRobotsPresent
													If RobotTeam(RNN) = RobotTeam(tempnumber) Then
														If tempnumber <> RNN Then
															If SignalInst(tempnumber) >= 0 Then
																If SignalParam(tempnumber) = RChannel(RNN) Then
																	RobotQuePos(tempnumber) = RobotQuePos(tempnumber) + 1
																	RobotIntQue(tempnumber, RobotQuePos(tempnumber)) = SignalInst(tempnumber)
																	IntID(tempnumber, RobotQuePos(tempnumber)) = 11
																End If
															End If
														End If
													End If
												Next tempnumber
											End If
										Case insCHANNEL
											RChannel(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If RChannel(RNN) > 10 Or RChannel(RNN) < 1 Then
												ErrorCode = BuggyChannel : GoTo Buggy
											End If
										Case Else
											ErrorCode = BuggyStore
											GoTo Buggy
									End Select
									RobotStackPos(RNN) = RobotStackPos(RNN) - 2
NoStackRemoval: 
								Case insRECALL 'Removing the Reversed Recalls took exactly 3 hours and 29 minutes, including speed testing but
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									Select Case RobotStack(RNN, RobotStackPos(RNN)) 'excluding recompiling all robots
										Case insRANGE 'ins
											RRange = Range(RNN, RAim(RNN) + RLook(RNN))
											If RRange <> 0 Then
												If RobotAlive(RangedRobot(RNN)) <> 1 Then RRange = 0
											End If
											RobotStack(RNN, RobotStackPos(RNN)) = RRange
										Case insAIM 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RAim(RNN)
										Case insX 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RobotLeft(RNN)
										Case insY 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RobotTop(RNN)
										Case insRADAR 'ins
											'RADAR
											RRadar = 0 'RRadar
											For shotcounter = 1 To ShotNumber
												If shot(shotcounter).ShotType < 200 Then
													'This is David Harris radar code, ported to Visual Basic by me.
													trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
													trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
													
													If trigx <> 0 Then 'atan2
														tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
													Else
														tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
													End If '''''''
													
													If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
													
													If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
														RRange = FixSquare(trigx * trigx + trigy * trigy)
														If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
													End If
												End If
											Next shotcounter
											'/RADAR
											RobotStack(RNN, RobotStackPos(RNN)) = RRadar
										Case insSPEEDX 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RSpeedx(RNN)
										Case insSPEEDY 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RSpeedy(RNN)
										Case insENERGY 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RNN)
										Case insSHIELD 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RShield(RNN)
										Case insLOOK 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RLook(RNN)
										Case insDOPPLER 'ins
											'Many Thanks to Sam Rushing who helped me out
											'and explained how the Doppler routine worked.    'Dead robot are set to E = -10
											
											'Prfnoff's version - Robots with E -1 has doppler?
											'4.5.2 - Robots med E -1 doesn't have doppler
											
											If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'Med allra allra största sannolikhet skall jag använda RealStunned
												If REnergy(RangedRobot(RNN)) <= 0 Or RStunned(RangedRobot(RNN)) <> 0 Or RCollision(RangedRobot(RNN)) <> 0 Then 'RWall(RangedRobot(RNN)) <> 0 Or
													RobotStack(RNN, RobotStackPos(RNN)) = 0
												Else
													RRange = RobotLeft(RNN) - RobotLeft(RangedRobot(RNN)) 'xdiff
													RRadar = RobotTop(RNN) - RobotTop(RangedRobot(RNN)) 'ydiff
													'Ej testat om det skall vara round eller fix, kolla
													RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Round((RSpeedx(RangedRobot(RNN)) * RRadar - RRange * RSpeedy(RangedRobot(RNN))) / Square(RRadar * RRadar + RRange * RRange)) 'Round
												End If
											Else
												RobotStack(RNN, RobotStackPos(RNN)) = 0
											End If
										Case insNEAREST
											If RobotProSpeed(RNN) <= 10 Then
												If NumberOfRobotsPresent > 1 Then
													tempnumber = Nearest(RNN)
													If RobotAlive(tempnumber) = 1 Then
														If RobotTop(tempnumber) <> RobotTop(RNN) Then
															If RobotTop(RNN) > RobotTop(tempnumber) Then
																RobotStack(RNN, RobotStackPos(RNN)) = (System.Math.Round(TPI * System.Math.Atan((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN))))) - RAim(RNN)
															Else
																RobotStack(RNN, RobotStackPos(RNN)) = (System.Math.Round(TPI * System.Math.Atan((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN)))) + 180) - RAim(RNN)
															End If
														Else
															If RobotLeft(RNN) < RobotLeft(tempnumber) Then
																RobotStack(RNN, RobotStackPos(RNN)) = 90 - RAim(RNN)
															Else
																RobotStack(RNN, RobotStackPos(RNN)) = 270 - RAim(RNN)
															End If
														End If
														
														If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 360
													Else
														RobotStack(RNN, RobotStackPos(RNN)) = -1
													End If
												Else
													RobotStack(RNN, RobotStackPos(RNN)) = -1
												End If
											Else
												ErrorCode = BuggyNearest
												GoTo Buggy
											End If
										Case insROBOTS 'ins
											If HowManyLeft = 255 Then
												RobotStack(RNN, RobotStackPos(RNN)) = 1
											ElseIf R2Present Then 
												RobotStack(RNN, RobotStackPos(RNN)) = HowManyLeft
											Else
												RobotStack(RNN, RobotStackPos(RNN)) = 1
											End If
										Case insCHRONON 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = Chronon
										Case insCOLLISION 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Sign(RCollision(RNN))
										Case insA 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RA(RNN)
										Case insB 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RB(RNN)
										Case insC 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RC(RNN)
										Case insD 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RD(RNN)
										Case insE 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RE(RNN)
										Case insF 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RF(RNN)
										Case insG 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RG(RNN)
										Case insH 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RH(RNN)
										Case insI 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RI(RNN)
										Case insJ 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RJ(RNN)
										Case insK 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RK(RNN)
										Case insL 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RL(RNN)
										Case insM 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RM(RNN)
										Case insN 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RN(RNN)
										Case insO 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RO(RNN)
										Case insP 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RP(RNN)
										Case insQ 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RQ(RNN)
										Case insR 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RR(RNN)
										Case insS 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RS(RNN)
										Case Inst 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RT(RNN)
										Case insU 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RU(RNN)
										Case insV 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RV(RNN)
										Case insZ 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RZ(RNN)
										Case insW 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RW(RNN)
										Case insPROBE 'ins
											If RobotProbes(RNN) = 0 Then
												ErrorCode = BuggyProbes
												GoTo Buggy
											Else
												If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then
													If RobotAlive(RangedRobot(RNN)) <> 1 Then
														RobotStack(RNN, RobotStackPos(RNN)) = 0
													Else
														Select Case ProbeSet(RNN)
															'0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
															'4 = Teammates - Currently disabled 'cause of no teams
															Case 1
																RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RangedRobot(RNN))
															Case 0
																RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RangedRobot(RNN))
															Case 2
																RobotStack(RNN, RobotStackPos(RNN)) = RShield(RangedRobot(RNN))
															Case 7
																RobotStack(RNN, RobotStackPos(RNN)) = RScan(RangedRobot(RNN))
															Case 3
																RobotStack(RNN, RobotStackPos(RNN)) = RangedRobot(RNN) - 1 '0 to 5
															Case 5
																RobotStack(RNN, RobotStackPos(RNN)) = RAim(RangedRobot(RNN))
															Case 6
																RobotStack(RNN, RobotStackPos(RNN)) = RLook(RangedRobot(RNN))
															Case 4
																RobotStack(RNN, RobotStackPos(RNN)) = 0
																For tempnumber = 1 To NumberOfRobotsPresent
																	If tempnumber <> RangedRobot(RNN) Then
																		If RobotTeam(tempnumber) = RobotTeam(RangedRobot(RNN)) Then
																			If RobotAlive(tempnumber) = 1 Then
																				RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
																			End If
																		End If
																	End If
																Next tempnumber
														End Select
													End If
												Else
													RobotStack(RNN, RobotStackPos(RNN)) = 0
												End If
											End If
										Case insWALL 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RWall(RNN)
										Case insDAMAGE 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RNN)
										Case insRANDOM 'ins
											If RunningTournament Then
												RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Round((359 + 1) * Rnd()) 'Int
											Else
												If Replaying And NotRandomEmergency Then
													RobotStack(RNN, RobotStackPos(RNN)) = RandomRegister(RandomCounter)
												Else
													RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Round((359 + 1) * Rnd()) 'Int
													ReDim Preserve RandomRegister(RandomCounter)
													RandomRegister(RandomCounter) = RobotStack(RNN, RobotStackPos(RNN))
												End If
												RandomCounter = RandomCounter + 1
											End If
										Case insSCAN 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RScan(RNN)
										Case insID 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = RNN - 1 '0 to 5
										Case insHISTORY 'ins     'If repeat battle is checked we should read from the backup rec, unless we're using user defined history, in case we should read from the regular rec, since regular rec 31-50 is reset at the end of a repeated battle
											If Replaying And HistoryParam(RNN) < 31 Then RobotStack(RNN, RobotStackPos(RNN)) = BackupHistoryRec(RNN, HistoryParam(RNN)) Else RobotStack(RNN, RobotStackPos(RNN)) = HistoryRec(RNN, HistoryParam(RNN))
										Case insKILLS 'ins
											RobotStack(RNN, RobotStackPos(RNN)) = KR(RNN)
										Case insSIGNAL
											If RobotTeam(RNN) <> 0 Then
												RobotStack(RNN, RobotStackPos(RNN)) = RSignal(RobotTeam(RNN), RChannel(RNN))
											Else
												RobotStack(RNN, RobotStackPos(RNN)) = 0
											End If
										Case insFRIEND
											If RCollision(RNN) <> 0 And RobotTeam(RNN) <> 0 Then
												If RobotTeam(RCollision(RNN)) = RobotTeam(RNN) Then RobotStack(RNN, RobotStackPos(RNN)) = 1 Else RobotStack(RNN, RobotStackPos(RNN)) = 0
											Else
												RobotStack(RNN, RobotStackPos(RNN)) = 0
											End If
										Case insCHANNEL
											RobotStack(RNN, RobotStackPos(RNN)) = RChannel(RNN)
										Case insTEAMMATES
											RobotStack(RNN, RobotStackPos(RNN)) = 0
											For tempnumber = 1 To NumberOfRobotsPresent
												If tempnumber <> RNN Then
													If RobotTeam(tempnumber) = RobotTeam(RNN) Then
														If RobotAlive(tempnumber) = 1 Then
															RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
														End If
													End If
												End If
											Next tempnumber
										Case Else
											ErrorCode = BuggyRecall '& RobotStack(RNN, RobotStackPos(RNN))
											GoTo Buggy
									End Select
								Case insIF 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
									Else
										tempnumber = RobotInstPos(RNN) + 1
										If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
											RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
										Else
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
										RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									End If
								Case insMORE
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) >= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
									Else
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insJUMP 'Rep'
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
										RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
									Else
										ErrorCode = BuggyDestination : GoTo Buggy
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insIFG 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
										If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
											RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
										Else
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 2
								Case insPLUS
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + RobotStack(RNN, RobotStackPos(RNN) + 1)
									If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
										ErrorCode = BuggyNumberOutofBounds : GoTo Buggy
									End If
								Case insLESS
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) <= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
									Else
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insSYNC 'Rep'
									Exit For
								Case insDUP 'Rep'
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStackPos(RNN) > 99 Then
										ErrorCode = BuggyOverflow : GoTo Buggy
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) + 1
									RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
								Case insSETINT 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN) - 1) > 4999 Or RobotStack(RNN, RobotStackPos(RNN) - 1) < -1 Then
										ErrorCode = BuggyDestination : GoTo Buggy
									End If
									
									Select Case RobotStack(RNN, RobotStackPos(RNN))
										Case insRANGE ' 'Rep'
											RangeInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insLEFT ' 'Rep'
											LeftInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If LeftInst(RNN) = -1 Then 'BUG ALERT!! Detta klarar bara om första stacknumret är
												If RobotQuePos(RNN) <> 0 Then 'hett! Tillfällig lösning
													If IntID(RNN, RobotQuePos(RNN)) = 3 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
												End If
											End If
										Case insRIGHT ' 'Rep'
											RightInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If RightInst(RNN) = -1 Then
												If RobotQuePos(RNN) <> 0 Then
													If IntID(RNN, RobotQuePos(RNN)) = 4 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
												End If
											End If
										Case insTOP ' 'Rep'
											TopInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If TopInst(RNN) = -1 Then
												If RobotQuePos(RNN) <> 0 Then
													If IntID(RNN, RobotQuePos(RNN)) = 1 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
												End If
											End If
										Case insBOT ' 'Rep'
											BotInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If BotInst(RNN) = -1 Then
												If RobotQuePos(RNN) <> 0 Then
													If IntID(RNN, RobotQuePos(RNN)) = 2 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
												End If
											End If
										Case insWALL ' 'Rep'
											WallInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If WallInst(RNN) = -1 Then
												If RobotQuePos(RNN) <> 0 Then
													If IntID(RNN, RobotQuePos(RNN)) = 7 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
												End If
											End If
										Case insCOLLISION ' 'Rep'
											CollisionInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If CollisionInst(RNN) = -1 Then
												If RobotQuePos(RNN) <> 0 Then
													If IntID(RNN, RobotQuePos(RNN)) = 8 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
												End If
											End If
										Case insROBOTS ' 'Rep'
											RobotsInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If RobotsInst(RNN) = -1 Then
												If RobotQuePos(RNN) <> 0 Then
													If IntID(RNN, RobotQuePos(RNN)) = 9 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
												End If
											End If
										Case insCHRONON ' 'Rep'
											ChrononInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insRADAR ' 'Rep'
											RadarInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insDAMAGE ' 'Rep'
											DamageInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If DamageInst(RNN) = -1 Then
												If RobotQuePos(RNN) <> 0 Then
													If IntID(RNN, RobotQuePos(RNN)) = 6 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
												End If
											End If
										Case insSHIELD ' 'Rep'
											ShieldInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If ShieldInst(RNN) = -1 Then
												If RobotQuePos(RNN) <> 0 Then
													If IntID(RNN, RobotQuePos(RNN)) = 5 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
												End If
											Else 'Else är nytt - tidigare stod If Rshieled utanför if
												If RShield(RNN) < ShieldParam(RNN) Then ShieldInst(RNN) = ShieldInst(RNN) + 5000
											End If
										Case insTEAMMATES ' 'Rep'
											TeammatesInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If TeammatesInst(RNN) = -1 Then
												If RobotQuePos(RNN) <> 0 Then
													If IntID(RNN, RobotQuePos(RNN)) = 10 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
												End If
											End If
										Case insSIGNAL ' 'Rep'
											SignalInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If SignalInst(RNN) = -1 Then
												If RobotQuePos(RNN) <> 0 Then
													If IntID(RNN, RobotQuePos(RNN)) = 11 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
												End If
											End If
										Case Else
											ErrorCode = BuggySetint
											GoTo Buggy
									End Select
									RobotStackPos(RNN) = RobotStackPos(RNN) - 2
								Case insRTI 'Rep'
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									Inton(RNN) = True
									If RobotQuePos(RNN) <= 0 Then
										If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
											RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
										Else
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Else
										RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1 'qued ints subtracted when triggered             'jumps shall be done
										Inton(RNN) = False
										RobotQuePos(RNN) = RobotQuePos(RNN) - 1
									End If
								Case insSETPARAM 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									Select Case RobotStack(RNN, RobotStackPos(RNN))
										Case insRANGE ' 'Rep'
											RangeParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insLEFT ' 'Rep'
											LeftParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insRIGHT ' 'Rep'
											RightParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insTOP ' 'Rep'
											TopParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insBOT ' 'Rep'
											BotParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insPROBE ' 'Rep'
											'0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
											'4 = Teammates - Currently disabled 'cause of no teams
											Select Case RobotStack(RNN, RobotStackPos(RNN) - 1)
												Case insDAMAGE ' 'Rep'
													ProbeSet(RNN) = 0
												Case insENERGY ' 'Rep'
													ProbeSet(RNN) = 1
												Case insSHIELD ' 'Rep'
													ProbeSet(RNN) = 2
												Case insSCAN ' 'Rep'
													ProbeSet(RNN) = 7
												Case insID ' 'Rep'
													ProbeSet(RNN) = 3
												Case insAIM ' 'Rep'
													ProbeSet(RNN) = 5
												Case insLOOK ' 'Rep'
													ProbeSet(RNN) = 6
												Case insTEAMMATES ' 'Rep'
													ProbeSet(RNN) = 4
													'                                    Case Else
													'                                        ErrorCode =  'Rep'Illegal 'PROBE' register  'Rep' & RobotStack(RNN, RobotStackPos(RNN))
													'                                        GoTo Buggy
											End Select
										Case insRADAR ' 'Rep'
											RadarParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insCHRONON ' 'Rep'
											ChrononParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insROBOTS ' 'Rep'
											RobotsParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insDAMAGE ' 'Rep'
											DamageParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											If DamageParam(RNN) > RDamage(RNN) Then DamageParam(RNN) = RDamage(RNN)
										Case insHISTORY ' 'Rep'
											HistoryParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insSHIELD ' 'Rep'
											ShieldParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insTEAMMATES ' 'Rep'
											TeammatesParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case insSIGNAL
											SignalParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										Case Else
											ErrorCode = BuggySetparam
											GoTo Buggy
									End Select
									RobotStackPos(RNN) = RobotStackPos(RNN) - 2
								Case insCALL 'Rep'
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									tempnumber = RobotInstPos(RNN) + 1
									If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
										RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
									Else
										ErrorCode = BuggyDestination : GoTo Buggy
									End If
									RobotStack(RNN, RobotStackPos(RNN)) = tempnumber
								Case insAND 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) = 0 Or RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
									Else
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insMINUS
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) - RobotStack(RNN, RobotStackPos(RNN) + 1)
									If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
										ErrorCode = BuggyNumberOutofBounds : GoTo Buggy
									End If
								Case insINTON 'Rep'
									Inton(RNN) = True
									If RobotQuePos(RNN) > 0 Then
										If RobotStackPos(RNN) > 99 Then
											ErrorCode = BuggyOverflow : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) + 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
										RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1 'qued ints subtracted when triggered             'jumps shall be done
										Inton(RNN) = False
										RobotQuePos(RNN) = RobotQuePos(RNN) - 1
									End If
								Case insDIVISION
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
										ErrorCode = BuggyDivision : GoTo Buggy
									End If
									
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) \ RobotStack(RNN, RobotStackPos(RNN) + 1)
								Case insTIMES
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) * RobotStack(RNN, RobotStackPos(RNN) + 1)
									If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
										ErrorCode = BuggyNumberOutofBounds : GoTo Buggy
									End If
								Case insSAME
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
									Else
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									'                    case insBEEP 'Rep' 'Represents all icon snd instructions, debug, print and beep  for undisplayed
									'                        ChrononExecutor1 = ChrononExecutor1 - 1
								Case insICON0 'Rep'
									RobotIconNumber(RNN) = 0
									Robot_(RNN) = RobotMasterIcon(RNN * 10)
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insICON1 'Rep'
									Robot_(RNN) = RobotMasterIcon(RNN * 10 + 1)
									RobotIconNumber(RNN) = 10 'To prevent setting back when shield drops
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insICON2 'Rep'
									Robot_(RNN) = RobotMasterIcon(RNN * 10 + 2)
									RobotIconNumber(RNN) = 2
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insICON3 'Rep'
									Robot_(RNN) = RobotMasterIcon(RNN * 10 + 3)
									RobotIconNumber(RNN) = 3
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insICON4 'Rep'
									Robot_(RNN) = RobotMasterIcon(RNN * 10 + 4)
									RobotIconNumber(RNN) = 4
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insICON5 'Rep'
									Robot_(RNN) = RobotMasterIcon(RNN * 10 + 5)
									RobotIconNumber(RNN) = 5
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insICON6 'Rep'
									Robot_(RNN) = RobotMasterIcon(RNN * 10 + 6)
									RobotIconNumber(RNN) = 6
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insICON7 'Rep'
									Robot_(RNN) = RobotMasterIcon(RNN * 10 + 7)
									RobotIconNumber(RNN) = 7
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insICON8 'Rep'
									Robot_(RNN) = RobotMasterIcon(RNN * 10 + 8)
									RobotIconNumber(RNN) = 8
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insICON9 'Rep'
									Robot_(RNN) = RobotMasterIcon(RNN * 10 + 9)
									RobotIconNumber(RNN) = 9
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insSND0 'Rep'
									If PlaySounds Then PlaySnd0((RNN))
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insSND1 'Rep'
									If PlaySounds Then PlaySnd1((RNN))
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insSND2 'Rep'
									If PlaySounds Then PlaySnd2((RNN))
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insSND3 'Rep'
									If PlaySounds Then PlaySnd3((RNN))
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insSND4 'Rep'
									If PlaySounds Then PlaySnd4((RNN))
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insSND5 'Rep'
									If PlaySounds Then PlaySnd5((RNN))
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insSND6 'Rep'
									If PlaySounds Then PlaySnd6((RNN))
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insSND7 'Rep'
									If PlaySounds Then PlaySnd7((RNN))
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insSND8 'Rep'
									If PlaySounds Then PlaySnd8((RNN))
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insSND9 'Rep'
									If PlaySounds Then PlaySnd9((RNN))
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insARCTAN 'Rep'                                       'Shall not use Fix!!
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
										RobotStack(RNN, RobotStackPos(RNN) - 1) = System.Math.Round(TPI * System.Math.Atan(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)) + 90 - (90 * (System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1)) - 1)))
									Else
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) * (System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) + 1)
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insDROPALL 'Rep'
									RobotStackPos(RNN) = 0
								Case insNOT 'Rep'
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
										RobotStack(RNN, RobotStackPos(RNN)) = 1
									Else
										RobotStack(RNN, RobotStackPos(RNN)) = 0 'Nej, dethär går inte att förenkla
									End If
								Case insDROP 'Rep'
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insSWAP 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									tempnumber = RobotStack(RNN, RobotStackPos(RNN))
									RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
									RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
								Case insIFEG 'Rep'
									If RobotStackPos(RNN) < 3 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
										If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
											RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
										Else
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
									Else
										If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
											RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
										Else
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 3
								Case insVRECALL 'Rep'
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) < 0 Or RobotStack(RNN, RobotStackPos(RNN)) > 100 Then
										RobotStack(RNN, RobotStackPos(RNN)) = 0
									Else
										RobotStack(RNN, RobotStackPos(RNN)) = RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN)))
									End If
								Case insMOD 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN) - 1) Mod RobotStack(RNN, RobotStackPos(RNN))
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insOR 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) = 0 And RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
									Else
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insIFE 'Rep'
									If RobotStackPos(RNN) < 3 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
										tempnumber = RobotInstPos(RNN) + 1
										If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
											RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
										Else
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
										RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
									Else
										tempnumber = RobotInstPos(RNN) + 1 'Samma sak här, det borde funka med tempnumber
										If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
											RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
										Else
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
										RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
									End If
								Case insMAX 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) > RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insSIN 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * System.Math.Sin(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insCOS 'Rep'              'Fix avrundar exact som Mac RoboWar!!
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * System.Math.Cos(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insINTOFF 'Rep'
									Inton(RNN) = False
								Case insVSTORE 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) >= 0 And RobotStack(RNN, RobotStackPos(RNN)) <= 100 Then
										RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN))) = RobotStack(RNN, RobotStackPos(RNN) - 1)
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 2
								Case insCHS 'Rep'
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									RobotStack(RNN, RobotStackPos(RNN)) = -RobotStack(RNN, RobotStackPos(RNN)) '* -1
								Case insABS 'Rep'
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN)))
									
								Case insTAN '       BUG ALERT!! Hur är det med 90 + de nya optimeringarna?
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									TDouble = Fix(RobotStack(RNN, RobotStackPos(RNN)) * System.Math.Tan((90 - RobotStack(RNN, RobotStackPos(RNN) - 1)) * PIO))
									If System.Math.Abs(TDouble) > 19999 Then TDouble = 19999 * System.Math.Sign(TDouble)
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									RobotStack(RNN, RobotStackPos(RNN)) = TDouble
								Case insNOT_SAME 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1) Then
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
									Else
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insROLL 'Rep'
									If RobotStackPos(RNN) < RobotStack(RNN, RobotStackPos(RNN)) + 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									tempnumber = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Stores the number to roll back in tempstack
									For shotcounter = RobotStackPos(RNN) - 1 To RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) Step -1 'decides what stack numbers moving up
										RobotStack(RNN, shotcounter) = RobotStack(RNN, shotcounter - 1) 'adjust stack numbers affected by roll
									Next shotcounter
									RobotStack(RNN, RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) - 1) = tempnumber 'Do the roll
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1 'Adjusts stack number because top operand has been removed
								Case insMIN 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) < RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insNOP 'Rep'
								Case insDIST 'Rep'     'Totally useless, it can be precalculated!
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(System.Math.Sqrt(RobotStack(RNN, RobotStackPos(RNN)) ^ 2 + RobotStack(RNN, RobotStackPos(RNN) - 1) ^ 2))
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insFLUSHINT 'Rep'
									RobotQuePos(RNN) = 0
								Case insXOR 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If (RobotStack(RNN, RobotStackPos(RNN)) <> 0) Xor (RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0) Then
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
									Else
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insARCSIN 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
										RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Asn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
									Else
										RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1))
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insARCCOS 'Rep'
									If RobotStackPos(RNN) < 2 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
										RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Acn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
									Else
										RobotStack(RNN, RobotStackPos(RNN) - 1) = -180 * CShort(System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) <> System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1)))
									End If
									
									RobotStackPos(RNN) = RobotStackPos(RNN) - 1
								Case insSQRT 'Rep'
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then
										ErrorCode = BuggySquare : GoTo Buggy
									End If
									
									RobotStack(RNN, RobotStackPos(RNN)) = FixSquare(RobotStack(RNN, RobotStackPos(RNN)))
								Case insBEEP 'Rep'     'beep will continiue battle, placed before print and debug cause of that
									If PlaySounds Then sndPlaySound(beepsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insPRINT 'Rep'
									If RobotStackPos(RNN) < 1 Then
										ErrorCode = BuggyUnderflow : GoTo Buggy
									End If
									
									If Not RunningTournament Then
										tempnumber = MsgBox(RobotStack(RNN, RobotStackPos(RNN)) & vbCr & vbCr & "Would you like to stop the Battle?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Print " & GetRobot(RNN))
										If tempnumber = MsgBoxResult.Yes Then GoTo Peace
									End If
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case insDEBUG 'Rep'
									If DebuggedRobot = 0 And Not (RunningTournament Or InactivateDebug.Checked) Then
										DebuggerAutoStart = True
										DebuggedRobot = RNN
										Image1(RNN).Visible = True 'Är ej med i variant 2
									End If
									ChrononExecutor1 = ChrononExecutor1 - 1
								Case Else
CodeError1: 
									ErrorCode = Err.Number
Buggy: 
									If RunningTournament Then
										tempnumber = MsgBoxResult.No
									ElseIf ErrorCode <= -200 Then 
										tempnumber = ShowErrorMessageParam(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), RobotStack(RNN, RobotStackPos(RNN)))
									Else
										tempnumber = ShowErrorMessage(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), MachineCode(RNN, RobotInstPos(RNN))) 'Response
									End If
									
									RobotAlive(RNN) = 255
									RScan(RNN) = 9999 'nytt
									If tempnumber = MsgBoxResult.Cancel Then GoTo Peace
									If tempnumber = MsgBoxResult.Yes Then
										SelectedRobot = RNN
										DraftingBoard.GotoInstNr = RobotInstPos(RNN) + 1
										VB6.ShowForm(DraftingBoard, 1, Me)
										EndBattleWhenGotoInst()
										Exit Sub
									End If
									If Err.Number = 0 Then Exit For Else Resume BackFromError
							End Select
						Next ChrononExecutor1
					Else 'Energyig + Stunnedif
						If DebuggedRobot = RNN Or (StartDebuggerAt = Chronon And RNN = WillBeDebugged) Then 'DEBUGGER for robots that's out of energy or stunned    'Fixar så den inte skriver fel Energi och sköld
							ChrononStart() 'This sub is required when the debugger is set to start at a certain chronon
							
							If RobotStackPos(RNN) <= 96 Then tempnumber = ((RobotStackPos(RNN) - 1) \ 6) * 6 Else tempnumber = 0
							PrintDebuggingInfo(RobotInstPos(RNN) + 1, MachineCode(RNN, RobotInstPos(RNN) + 1), RobotStackPos(RNN), RobotStack(RNN, 1 + tempnumber), RobotStack(RNN, 2 + tempnumber), RobotStack(RNN, 3 + tempnumber), RobotStack(RNN, 4 + tempnumber), RobotStack(RNN, 5 + tempnumber), RobotStack(RNN, 6 + tempnumber), RobotStack(RNN, 100), RobotStack(RNN, 99), RobotStack(RNN, 98), RobotStack(RNN, 97), 0, RAim(RNN), RShield(RNN), " ", RangedRobot(RNN), " ", RLook(RNN), RScan(RNN), RSpeedx(RNN), RSpeedy(RNN), REnergy(RNN)) 'We have to add 1 to RobotInstPos(RNN) because of the "3 fire' store 0 jump"-bug
							PrintInts(Inton(RNN), LeftParam(RNN), RightParam(RNN), TopParam(RNN), BotParam(RNN), LeftInst(RNN), RightInst(RNN), TopInst(RNN), BotInst(RNN), RadarParam(RNN), RadarInst(RNN), RangeInst(RNN), RangeParam(RNN), RobotQuePos(RNN), RobotIntQue(RNN, 1), RobotIntQue(RNN, 2))
							ReturnMacAdd() 'ReturnMacAdd also contains the stop/resume execution instructions
							If DebuggingWindow.DebuggingRes = 1 Then
								SetTabIndex1()
							ElseIf DebuggingWindow.DebuggingRes = 2 Then 
								TurnOfTheDebugger()
							ElseIf DebuggingWindow.DebuggingRes = 3 Then 
								GoTo Peace
							Else
								SetTabIndex2()
							End If
						End If
					End If 'Stunned if 'energyif
				End If 'RobotAlive(RNN) if
BackFromError: 
				If HighestToLowest Then RNN = 1 + NumberOfRobotsPresent - RNN 'Turns off backwards evaluation if it's enabled
			Next RNN 'Nästa robot loopen
			
			For RNN = 1 To NumberOfRobotsPresent
				If RStunned(RNN) > 0 Then RStunned(RNN) = RStunned(RNN) - 1
				If RCollision(RNN) <> 0 Then
					If RobotCollisionIcon(RNN) Then
						Robot_(RNN) = RobotMasterIcon(RNN * 10 + 3)
						RobotIconNumber(RNN) = RobotIconNumber(RNN) + 100 'Preserve the Icon the robot had before collision
					End If
				End If
			Next RNN
			
			'Shot Manager
			
			NotAnyShotsAtAll = True
			'UPGRADE_ISSUE: PictureBox method Arena.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			Arena.Cls()
			
			For shotcounter = 1 To ShotNumber
				'ErrorCode = "ShotCounter = " & ShotCounter & Chr(10) & "ShotNumber = " & ShotNumber & Chr(10) & Chr(10) & "FireTime = " & Shot(ShotCounter).ShotFireTime & Chr(10) & "X = " & Shot(ShotCounter).ShotX & Chr(10) & "Y = " & Shot(ShotCounter).ShotY & Chr(10) & "Damage = " & Shot(ShotCounter).ShotPower & Chr(10) & Chr(10) & "FreeShot = " & FreeShot
				'If MsgBox(ErrorCode, vbOKCancel, "Debug") = vbCancel Then GoTo Peace
				
				'Fillstyle är som standard = 0. Om det måste ändras måste den sättas tillbaka sen
				
				Select Case shot(shotcounter).ShotType
					Case 200
						FreeShot = shotcounter
						
					Case Missile
						NotAnyShotsAtAll = False
						trigx = Sin5(shot(shotcounter).ShotAngle)
						trigy = Cos5(shot(shotcounter).ShotAngle)
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy
						
						'       shot(ShotCounter).ShotX = shot(ShotCounter).ShotX + sin5(shot(ShotCounter).ShotAngle) 'För undisplayed
						'       shot(ShotCounter).ShotY = shot(ShotCounter).ShotY - cos5(shot(ShotCounter).ShotAngle) 'För undisplayed
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then 'BUG ALERT!!! Skall syncas!!!
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 1 'Which robot is hit?
								LastHiter(1) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 2 'Which robot is hit?
								LastHiter(2) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 3 'Which robot is hit?
								LastHiter(3) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 4 'Which robot is hit?
								LastHiter(4) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 5 'Which robot is hit?
								LastHiter(5) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 6 'Which robot is hit?
								LastHiter(6) = shot(shotcounter).Shooter
							Else
								'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Line (shot(shotcounter).ShotX, shot(shotcounter).ShotY) - (shot(shotcounter).ShotX + trigx, shot(shotcounter).ShotY - trigy), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
							End If
						End If
						
					Case Hellbore
						NotAnyShotsAtAll = False
						trigx = shot(shotcounter).ShotPower * Sine(shot(shotcounter).ShotAngle)
						trigy = shot(shotcounter).ShotPower * Cosine(shot(shotcounter).ShotAngle)
						
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy
						
						trigx = shot(shotcounter).ShotX - trigx / 2
						trigy = shot(shotcounter).ShotY + trigy / 2
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then 'HELLBORE!!!
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or (trigx - RobotLeft(1)) * (trigx - RobotLeft(1)) + (trigy - RobotTop(1)) * (trigy - RobotTop(1)) < 100 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 1000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or (trigx - RobotLeft(2)) * (trigx - RobotLeft(2)) + (trigy - RobotTop(2)) * (trigy - RobotTop(2)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 2000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or (trigx - RobotLeft(3)) * (trigx - RobotLeft(3)) + (trigy - RobotTop(3)) * (trigy - RobotTop(3)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 3000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or (trigx - RobotLeft(4)) * (trigx - RobotLeft(4)) + (trigy - RobotTop(4)) * (trigy - RobotTop(4)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 4000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or (trigx - RobotLeft(5)) * (trigx - RobotLeft(5)) + (trigy - RobotTop(5)) * (trigy - RobotTop(5)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 5000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or (trigx - RobotLeft(6)) * (trigx - RobotLeft(6)) + (trigy - RobotTop(6)) * (trigy - RobotTop(6)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 6000 'Which robot is hit? *1000 for hellbore
							Else
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = &H808080 'Creates new shotprojection
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
							End If 'HELLBORE!!!
						End If
						
					Case Stunner
						NotAnyShotsAtAll = False
						trigx = Sin14(shot(shotcounter).ShotAngle)
						trigy = Cos14(shot(shotcounter).ShotAngle)
						
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy
						
						trigx = shot(shotcounter).ShotX - trigx
						trigy = trigy + shot(shotcounter).ShotY
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then 'STUNNER!!!
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 51 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								shot(shotcounter).ShotAngle = 100 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								shot(shotcounter).ShotAngle = 200 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								shot(shotcounter).ShotAngle = 300 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								shot(shotcounter).ShotAngle = 400 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								shot(shotcounter).ShotAngle = 500 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
								shot(shotcounter).ShotAngle = 600 'Which robot is hit? *100 for stunners
							Else
								'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Line (shot(shotcounter).ShotX - 2, shot(shotcounter).ShotY - 2) - (shot(shotcounter).ShotX + 3, shot(shotcounter).ShotY + 3), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
								'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Line (shot(shotcounter).ShotX + 2, shot(shotcounter).ShotY - 2) - (shot(shotcounter).ShotX - 3, shot(shotcounter).ShotY + 3), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
							End If 'STUNNER!!!
						End If
						
					Case XplosiveBulletDetonation
ExplosiveBullets: 
						NotAnyShotsAtAll = False
						If Chronon - shot(shotcounter).ShotFireTime < 4 Then '10
							'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							Arena.FillColor = &HA1A1A2 '&HA1A1A2    '&H80000013
							'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 12 * (Chronon - shot(shotcounter).ShotFireTime), &H808080
						Else
							If PlaySounds Then sndPlaySound(takenukesound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
							shot(shotcounter).ShotType = NOSHOT
							
							For RNN = 1 To NumberOfRobotsPresent
								If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 2025 Then '45*45?????
									RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN)) : RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
									DR(RNN).Text = CStr(RDamage(RNN))
									LastHiter(RNN) = shot(shotcounter).Shooter
								End If
							Next RNN
							
							If DroneShotDown Then
								For RNN = 1 To ShotNumber
									If shot(RNN).ShotType = Drone Then
										If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 2025 Then
											shot(RNN).ShotType = NOSHOT
											'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
											Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
											'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
											Arena.Circle (shot(RNN).ShotX, shot(RNN).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
										End If
									End If
								Next RNN
							End If
						End If
						
					Case TakeNuke
						'OldStyleExplosiveBullets:
						NotAnyShotsAtAll = False
						'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.FillColor = &HA1A1A2 '&H80000013
						'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 5 * (Chronon - shot(shotcounter).ShotFireTime), &H808080
						
						If Chronon - shot(shotcounter).ShotFireTime >= 10 Then '10
							If PlaySounds Then sndPlaySound(takenukesound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
							shot(shotcounter).ShotType = NOSHOT
							
							For RNN = 1 To NumberOfRobotsPresent '1020
								If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
									RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN)) : RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
									DR(RNN).Text = CStr(RDamage(RNN))
									LastHiter(RNN) = shot(shotcounter).Shooter
									'DR(RNN).Refresh
								End If
							Next RNN
							
							If DroneShotDown Then
								For RNN = 1 To ShotNumber
									If shot(RNN).ShotType = Drone Then
										If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then
											shot(RNN).ShotType = NOSHOT
											'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
											Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
											'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
											Arena.Circle (shot(RNN).ShotX, shot(RNN).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
										End If
									End If
								Next RNN
							End If
						End If
						
					Case MegaNuke
						NotAnyShotsAtAll = False
						'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.FillColor = MegaNukeFILLCOLOR ' &HA1A1A2    '&H80000013
						'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 5 * (Chronon - shot(shotcounter).ShotFireTime), MegaNukeOUTERRINGCOLOR
						
						If Chronon - shot(shotcounter).ShotFireTime >= MegaNukeBLASTRADIUS Then '10
							If PlaySounds Then sndPlaySound(takenukesound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
							shot(shotcounter).ShotType = NOSHOT
							
							For RNN = 1 To NumberOfRobotsPresent '1020
								If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
									RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower + RShield(RNN)) : RShield(RNN) = ZeroOrMore(RShield(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower)
									DR(RNN).Text = CStr(RDamage(RNN))
									LastHiter(RNN) = shot(shotcounter).Shooter
									'DR(RNN).Refresh
								End If
							Next RNN
							
							If DroneShotDown Then
								For RNN = 1 To ShotNumber
									If shot(RNN).ShotType = Drone Then
										If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then
											shot(RNN).ShotType = NOSHOT
											'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
											Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
											'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
											Arena.Circle (shot(RNN).ShotX, shot(RNN).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
										End If
									End If
								Next RNN
							End If
						End If
						
					Case Mine 'Minor skall ge damage 1 chronon efter
						NotAnyShotsAtAll = False
						
						'UPGRADE_ISSUE: PictureBox property Arena.FillStyle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.FillStyle = 1
						'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
						'UPGRADE_ISSUE: PictureBox property Arena.FillStyle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.FillStyle = 0
						'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
						'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 2, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
						
						If Chronon - shot(shotcounter).ShotFireTime >= 10 Then
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 1 'Which robot is hit?
								LastHiter(1) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 2 'Which robot is hit?
								LastHiter(2) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 3 'Which robot is hit?
								LastHiter(3) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 4 'Which robot is hit?
								LastHiter(4) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 5 'Which robot is hit?
								LastHiter(5) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 6 'Which robot is hit?
								LastHiter(6) = shot(shotcounter).Shooter
							End If
						End If
						
					Case Drone
						NotAnyShotsAtAll = False
						
						If RobotAlive(shot(shotcounter).ShotAngle) = 1 And Chronon <= shot(shotcounter).ShotFireTime Then
							'Checks drone shotdown
							For tempnumber = 0 To ShotNumber 'This is still extremly buggy
								'If Shot(TempNumber).ShotType = Missile Or Shot(TempNumber).ShotType = Hellbore Or Shot(TempNumber).ShotType = Bullet Or Shot(TempNumber).ShotType = ExplosiveBullet Then
								If shot(tempnumber).ShotType < 4 Then
									If (shot(tempnumber).ShotX - shot(shotcounter).ShotX) * (shot(tempnumber).ShotX - shot(shotcounter).ShotX) + (shot(tempnumber).ShotY - shot(shotcounter).ShotY) * (shot(tempnumber).ShotY - shot(shotcounter).ShotY) < 50 Then
										shot(tempnumber).ShotType = NOSHOT
										shot(shotcounter).ShotType = NOSHOT
										'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
										GoTo dontrundronecode
									End If
								End If
							Next tempnumber
							''***************************'Nytt försök med drones     'Succé!! Yay!!
							'            'moves te drone towards the tracking robot moves and paints the drone
							'LÄGG TILL IIF, DET KANSKE GÅR SNABBARE
							If System.Math.Abs(shot(shotcounter).ShotY - RobotTop(shot(shotcounter).ShotAngle)) <= 8 Then '2 '8
								If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
									'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									Arena.PaintPicture(DroneR, shot(shotcounter).ShotX, shot(shotcounter).ShotY - 2)
									shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2
								Else
									shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2
									'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									Arena.PaintPicture(DroneL, shot(shotcounter).ShotX - 2, shot(shotcounter).ShotY - 2)
								End If
							ElseIf System.Math.Abs(shot(shotcounter).ShotX - RobotLeft(shot(shotcounter).ShotAngle)) <= 8 Then  '2 '8
								If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then
									'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									Arena.PaintPicture(DroneD, shot(shotcounter).ShotX - 2, shot(shotcounter).ShotY)
									shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2
								Else
									shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2
									'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									Arena.PaintPicture(DroneU, shot(shotcounter).ShotX - 2, shot(shotcounter).ShotY - 2) '- 2 för att den börjar måla den i vänstra hörnet
								End If
							Else
								If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
									shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2 '1.41421356237 '2*cos 45 = 2*sin 45 = 1.41421356237
									RNN = 2
								Else
									shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2 '1.41421356237
									RNN = 0
								End If
								If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then 'RobotTop(shot(ShotCounter).ShotAngle) + 16 'Varför + 16??
									shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2 '1.41421356237
									RNN = RNN + 4
								Else
									shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2 '1.41421356237
									RNN = RNN + 3
								End If
								'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.PaintPicture(DroneDiagonally(RNN), shot(shotcounter).ShotX - 2, shot(shotcounter).ShotY - 2)
							End If
							''            end paint and move
							'Checks hit
							For tempnumber = 1 To NumberOfRobotsPresent
								If (shot(shotcounter).ShotX - RobotLeft(tempnumber)) * (shot(shotcounter).ShotX - RobotLeft(tempnumber)) + (shot(shotcounter).ShotY - RobotTop(tempnumber)) * (shot(shotcounter).ShotY - RobotTop(tempnumber)) < 100 Then
									shot(shotcounter).ShotType = SHOTHIT
									'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
									'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
									Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
									shot(shotcounter).ShotAngle = tempnumber 'Which robot is hit?
									'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
									LastHiter(tempnumber) = shot(shotcounter).Shooter
								End If
							Next tempnumber
						Else
							shot(shotcounter).ShotType = NOSHOT 'destroy drone
						End If
dontrundronecode: 
					Case Laser 'shot(ShotCounter).ShotAngle = bot som beskjuts
						NotAnyShotsAtAll = False
						shot(shotcounter).ShotType = SHOTHIT
						'Arena.Line (TurretX2(shot(ShotCounter).Shooter), TurretY2(shot(ShotCounter).Shooter))-(shot(ShotCounter).ShotX, shot(ShotCounter).ShotY), vbBlue
						'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.Line (RobotLeft(shot(shotcounter).Shooter) + Sin10(shot(shotcounter).ShotFireTime), RobotTop(shot(shotcounter).Shooter) - Cos10(shot(shotcounter).ShotFireTime)) - (shot(shotcounter).ShotX, shot(shotcounter).ShotY), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
						'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
						'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
						LastHiter(shot(shotcounter).ShotAngle) = shot(shotcounter).Shooter
						
					Case SHOTHIT 'ShotHit
						If shot(shotcounter).ShotAngle < 100 Then 'Regular
							'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
							'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
							RShield(shot(shotcounter).ShotAngle) = RShield(shot(shotcounter).ShotAngle) - shot(shotcounter).ShotPower
							If RShield(shot(shotcounter).ShotAngle) < 0 Then 'If Shield still is above 0 the shot only hit the shield
								RDamage(shot(shotcounter).ShotAngle) = RDamage(shot(shotcounter).ShotAngle) + RShield(shot(shotcounter).ShotAngle)
								RShield(shot(shotcounter).ShotAngle) = 0
								DR(shot(shotcounter).ShotAngle).Text = CStr(RDamage(shot(shotcounter).ShotAngle)) ': DR(1).Refresh
								If PlaySounds Then
									If RobotHitSound(shot(shotcounter).ShotAngle) Then PlaySnd3((shot(shotcounter).ShotAngle)) Else sndPlaySound(hitsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
								End If
								If RobotHitIcon(shot(shotcounter).ShotAngle) Then 'Skall EJ vara <= 100!
									If RobotIconNumber(shot(shotcounter).ShotAngle) < 100 Then RobotIconNumber(shot(shotcounter).ShotAngle) = RobotIconNumber(shot(shotcounter).ShotAngle) + 100
									Robot_(shot(shotcounter).ShotAngle) = RobotMasterIcon(shot(shotcounter).ShotAngle * 10 + 5)
								End If
							Else 'Blocked shot with shield
								If PlaySounds Then
									If RobotBlockSound(shot(shotcounter).ShotAngle) Then PlaySnd2((shot(shotcounter).ShotAngle)) Else sndPlaySound(hitsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
								End If
								If RobotBlockIcon(shot(shotcounter).ShotAngle) Then
									If RobotIconNumber(shot(shotcounter).ShotAngle) < 100 Then RobotIconNumber(shot(shotcounter).ShotAngle) = RobotIconNumber(shot(shotcounter).ShotAngle) + 100
									Robot_(shot(shotcounter).ShotAngle) = RobotMasterIcon(shot(shotcounter).ShotAngle * 10 + 4)
								End If
							End If
						ElseIf shot(shotcounter).ShotAngle < 1000 Then  'Stunner
							RNN = shot(shotcounter).ShotAngle \ 100
							'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
							'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
							If PlaySounds Then
								If RobotHitSound(RNN) Then PlaySnd3((RNN)) Else sndPlaySound(hitsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
							End If
							If RobotHitIcon(RNN) Then
								If RobotIconNumber(RNN) < 100 Then RobotIconNumber(RNN) = RobotIconNumber(RNN) + 100
								Robot_(RNN) = RobotMasterIcon(RNN * 10 + 5)
							End If
							RStunned(RNN) = RStunned(RNN) + shot(shotcounter).ShotPower
						Else 'Hellbore   'Since Hellbore practically are only shooted with other shots, they don't have to make sound OR Red/Green Spots
							RNN = shot(shotcounter).ShotAngle \ 1000
							If RobotHitIcon(RNN) Then
								If RobotIconNumber(RNN) < 100 Then RobotIconNumber(RNN) = RobotIconNumber(RNN) + 100
								Robot_(RNN) = RobotMasterIcon(RNN * 10 + 5)
							End If
							RShield(RNN) = 0
						End If
						shot(shotcounter).ShotType = NOSHOT
						
					Case Else
						NotAnyShotsAtAll = False
						trigx = Sin12(shot(shotcounter).ShotAngle)
						trigy = Cos12(shot(shotcounter).ShotAngle)
						
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy
						
						trigy = trigy + shot(shotcounter).ShotY
						trigx = shot(shotcounter).ShotX - trigx
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									'                    Shot(ShotCounter).ShotType = TakeNuke      'Old fashion Explosive Bullets
									'                    GoTo OldStyleExplosiveBullets                      'Do not erase
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								shot(shotcounter).ShotType = SHOTHIT
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 1 'Which robot is hit?
								LastHiter(1) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then 
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								shot(shotcounter).ShotType = SHOTHIT
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 2 'Which robot is hit?
								LastHiter(2) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then 
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								shot(shotcounter).ShotType = SHOTHIT
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 3 'Which robot is hit?
								LastHiter(3) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then 
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								shot(shotcounter).ShotType = SHOTHIT
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 4 'Which robot is hit?
								LastHiter(4) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then 
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								shot(shotcounter).ShotType = SHOTHIT
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 5 'Which robot is hit?
								LastHiter(5) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then 
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								shot(shotcounter).ShotType = SHOTHIT
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
								shot(shotcounter).ShotAngle = 6 'Which robot is hit?
								LastHiter(6) = shot(shotcounter).Shooter
							Else
								'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) 'Creates new shotprojection
								'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								Arena.Circle (shot(shotcounter).ShotX, shot(shotcounter).ShotY), 2, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
							End If
						End If
				End Select
			Next shotcounter
			
			If NotAnyShotsAtAll Then
				ShotNumber = 0
				FreeShot = -1
			End If
			
			'Checks if the robots have any damage left and paint the robots
			'Kollar om robotarna har dött av skada samt ritar robotar och aim
			For RNN = 1 To NumberOfRobotsPresent
				If RobotAlive(RNN) = 1 Then
					If RDamage(RNN) >= 1 Then
						'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.PaintPicture(Robot_(RNN), RobotLeft(RNN) - 16, RobotTop(RNN) - 16)
						If RobotTurretType(RNN) = 1 Then
							'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                            'Arena.Line (RobotLeft(RNN), RobotTop(RNN)) - (TurretX2(RNN), TurretY2(RNN)), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
						ElseIf RobotTurretType(RNN) = 2 Then 
							'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                            'Arena.Circle (TurretX2(RNN), TurretY2(RNN)), 1, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
						End If
					Else
						RobotAlive(RNN) = 255
					End If
				End If
			Next RNN
			
			'Dödar döda robotar - Kills off dead robots
			For RNN = 1 To NumberOfRobotsPresent
				If RobotAlive(RNN) > 230 Then
					If RobotAlive(RNN) <> 255 Then
						If RobotAlive(RNN) > 237 Then DeathAnimation(RNN, RobotAlive(RNN))
						If RobotAlive(RNN) = 231 Then RobotAlive(RNN) = 1 '1 - 1 = 0 see code below
					Else 'RobotAlive(RNN) <> 255 Then
						DeathAnimationInitz(RNN, RobotIconNumber(RNN))
						RobotLeft(RNN) = -50
						RobotTop(RNN) = 150
						EnergyDisplay(RNN).Visible = False
						
						If REnergy(RNN) < -200 And EnableOverloading Then 'BUG ALERT!! BUG ALERT!! Skillnad i overloading mot den jävla Mac versionen: dels så sker skälva "döden" 1 chronon senare i
							RobotDead(RNN).Text = "Overloaded - Time: " & Chronon
							tempnumber = -2 '3 * CInt(Not StandardScoring)
							LastHiter(RNN) = 253
						ElseIf RScan(RNN) = 9999 Then 
							RobotDead(RNN).Text = "Buggy - Time: " & Chronon
							tempnumber = -1 '2 * CInt(Not StandardScoring)
							LastHiter(RNN) = 254
						Else
							RobotDead(RNN).Text = "Dead - Time: " & Chronon 'Windows (vet inte om det har nån betydelse?), dels så slutar striden inte mindre än 2 chronon senare senare i Windows (om Mac scoring används)
							If (RCollision(RNN) = 0 Or RDamage(RNN) + 1 <= 0) And (RWall(RNN) = 0 Or RDamage(RNN) + 5 <= 0) And LastHiter(RNN) <> RNN And RLook(LastHiter(RNN)) <> 9999 And (RobotTeam(RNN) = 0 Or (RobotTeam(RNN) <> RobotTeam(LastHiter(RNN)))) Then
								KR(LastHiter(RNN)) = KR(LastHiter(RNN)) + 1 'Also prevents robots from getting kill score for killing itself
							Else
								LastHiter(RNN) = 255 'Records that the robot died from a Wall Collision, Collision or suicided (for 4.5.2)
							End If
							tempnumber = 0 'CInt(Not StandardScoring)
						End If
						
						RobotDead(RNN).Visible = True
						
						HowManyLeft = HowManyLeft - 1
						
						'Robots Int
						For shotcounter = 1 To NumberOfRobotsPresent
							If RobotsInst(shotcounter) >= 0 And HowManyLeft < RobotsParam(shotcounter) Then
								RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
								RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = RobotsInst(shotcounter)
								IntID(shotcounter, RobotQuePos(shotcounter)) = 9
							End If
						Next shotcounter
						
						'Teammates Int
						RRadar = 0 'Calculates how many teammates there is left
						For shotcounter = 1 To NumberOfRobotsPresent 'If a robot is in the same team that the robot who just died + it's alive it's a living teammate
							If RobotTeam(shotcounter) = RobotTeam(RNN) And RobotAlive(shotcounter) = 1 Then RRadar = RRadar + 1
						Next shotcounter
						
						For shotcounter = 1 To NumberOfRobotsPresent
							If RobotTeam(shotcounter) = RobotTeam(RNN) Then 'If they're not in the same team we can ignore the teammates int
								If TeammatesInst(shotcounter) >= 0 Then 'If it uses the teammates inst
									If RRadar <= TeammatesParam(shotcounter) Then 'If the teammates in the team no is below teammatesparam
										RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
										RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = TeammatesInst(shotcounter)
										IntID(shotcounter, RobotQuePos(shotcounter)) = 10
									End If
								End If
							End If
						Next shotcounter
						
						If RRadar = 0 Then HowManyLeft = 0
						
						'End Team Stuff
						
						If HowManyLeft <= 1 Then
							MaxChronon = Chronon + 20 - tempnumber * CShort(Not StandardScoring) 'MaxChronon = Chronon + 21 + CInt(StandardScoring) + TempNumber
							HowManyLeft = 255 'If the solitare robot should die we prevent the battle from going on an additional 20 chronons this way
						End If
						
						REnergy(RNN) = -10 'To prevent false dopplering
					End If
					RobotAlive(RNN) = RobotAlive(RNN) - 1
				End If
				
				RCollision(RNN) = 0 'Resets collision to zero before the collision loop
			Next RNN
			
			Chronon = Chronon + 1
			'UPGRADE_ISSUE: PictureBox method NumerOfCrononsDisplay.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			NumerOfCrononsDisplay.Cls()
			'UPGRADE_ISSUE: PictureBox method NumerOfCrononsDisplay.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			NumerOfCrononsDisplay.Print(Chronon)
			System.Windows.Forms.Application.DoEvents()
			
			If BattleSpeed <> 1E-37 Then 'Hastighetsbegränsaren - Speed Limiter
				Do While VB.Timer() - fStart < BattleSpeed
					If BattleHaltButton.Text = "Battle" Then GoTo Peace 'Added this line as fix for the slowest battlespeed halt pressed bug.
					'I've allways HATED that bug
					System.Windows.Forms.Application.DoEvents()
				Loop 
			End If
			Do While Draging <> 0 'Pauses the battle if the user is dragging around a robot
				System.Windows.Forms.Application.DoEvents()
			Loop 
		Loop 
		'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*
		
		' Striden avslutas
Peace: 
		For RNN = 1 To NumberOfRobotsPresent 'Just so ER should correspond to energydisplay
			ER(RNN).Text = CStr(REnergy(RNN)) 'so the player can see how much energy robot had when battle ended
			
			If Not Replaying Then
				BackupHistory((RNN))
				HistoryRec(RNN, 9) = RDamage(RNN) * CShort(RobotAlive(RNN) = 1)
			End If
		Next RNN
		
		KillPoints(LastHiter, RobotAlive)
		RewardPoints(RobotAlive(1), RobotAlive(2), RobotAlive(3), RobotAlive(4), RobotAlive(5), RobotAlive(6))
		EndBattle()
	End Sub
	
	Private Sub backupcustom()
		Dim counter As Integer
		Dim robotcounter As Integer
		
		For robotcounter = 1 To NumberOfRobotsPresent
			For counter = 31 To 50
				BackupHistoryRec(robotcounter, counter) = HistoryRec(robotcounter, counter)
			Next counter
		Next robotcounter
	End Sub
	
	Private Sub resetcustom()
		Dim counter As Integer
		Dim robotcounter As Integer
		
		For robotcounter = 1 To NumberOfRobotsPresent
			For counter = 31 To 50
				HistoryRec(robotcounter, counter) = BackupHistoryRec(robotcounter, counter)
			Next counter
		Next robotcounter
	End Sub
	
	Private Sub BackupHistory(ByRef HRN As Integer)
		Dim counter As Integer
		
		For counter = 1 To 30
			BackupHistoryRec(HRN, counter) = HistoryRec(HRN, counter)
		Next counter
		
	End Sub
	
	Private Sub KillPoints(ByRef killer() As Integer, ByRef RAlive() As Integer)
		Dim c As Integer
		Dim DeathTimeString As String
		'UPGRADE_WARNING: Lower bound of array DeathTime was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim DeathTime(6) As Integer
		
		For c = 1 To NumberOfRobotsPresent
			If RAlive(c) <> 1 Then
				DeathTimeString = Replace(RobotDead(c).Text, "Dead - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
				DeathTime(c) = Val(DeathTimeString)
				If killer(c) > 200 Then DeathTime(c) = DeathTime(c) + (255 - killer(c)) * CShort(Not StandardScoring) 'Mac offset, to gain perfect compatibility
			Else
				DeathTime(c) = 32767
			End If
		Next c
		
		' Killer = 253 means that the robot overloaded
		' Killer = 254 means that the robot died from a bug
		' Killer = 255 means that the robot suicided, died from a collision or wall collision
		' Hence no kill points should be substracted since none was rewarded
		' We also have to check if the killer died from overloading, since then it should only get points for kills prior it it's death
		
		' DeathTime = 32767 means that the robots still alive.
		' It totally doesn't makes sense to reward anyone kill points for a robot thats still alive ;)
		
		If StandardScoring Then 'Win Scoring
			For c = 1 To NumberOfRobotsPresent
				If killer(c) < 7 And DeathTime(c) <> 32767 Then
					If killer(killer(c)) <> 253 Then 'If the bot was not overloaded kills up top 20 chronons after it's death counts
						If DeathTime(killer(c)) - DeathTime(c) < -20 Then KR(killer(c)) = KR(killer(c)) - 1
					Else 'If the bot was overloaded only kills prior to it's death counts
						If DeathTime(killer(c)) < DeathTime(c) Then KR(killer(c)) = KR(killer(c)) - 1
					End If
				End If
			Next c
		Else 'Mac 4.5.2 Scoring
			For c = 1 To NumberOfRobotsPresent
				If killer(c) < 7 And DeathTime(c) <> 32767 Then
					If DeathTime(killer(c)) - DeathTime(c) < 20 Then KR(killer(c)) = KR(killer(c)) - 1
				End If
			Next c
		End If
		
		If PrintTournamentLog Then
			For c = 1 To NumberOfRobotsPresent
				TournamentLog(LogWhichBattle).WhosWho(c) = GetRobot(c)
				TournamentLog(LogWhichBattle).killer(c) = killer(c) 'TranslateKiller(Killer(c), RAlive(c))
				TournamentLog(LogWhichBattle).DeathTime(c) = DeathTime(c)
				TournamentLog(LogWhichBattle).Kills(c) = KR(c)
			Next c
		End If
		
	End Sub
	
	Private Sub RewardPoints(ByRef Robot1Alive As Integer, ByRef Robot2Alive As Integer, ByRef Robot3Alive As Integer, ByRef Robot4Alive As Integer, ByRef Robot5Alive As Integer, ByRef Robot6Alive As Integer)
		If Replaying Then Exit Sub 'No points for repeated battles
		Dim counter As Integer
		Dim TeamsRunning As Boolean
		
		For counter = 1 To 6
			HistoryRec(counter, 4) = 0
			HistoryRec(counter, 9) = -HistoryRec(counter, 9) 'because CInt(RobotAlive(RNN) = 1) = -1
			If RobotTeam(counter) <> 0 Then TeamsRunning = True
		Next counter
		
		Dim DidOverload As Boolean
		Dim d As Integer
		Dim DeathTimeString As String
		Dim MaxDeathTime As Integer
		Dim TieFlag As Integer
		Dim c As Integer
		'UPGRADE_WARNING: Lower bound of array DeathTime was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim DeathTime(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotAlive was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotAlive(6) As Integer
		If TeamsRunning Then
			
			RobotAlive(1) = Robot1Alive
			RobotAlive(2) = Robot2Alive
			RobotAlive(3) = Robot3Alive
			RobotAlive(4) = Robot4Alive
			RobotAlive(5) = Robot5Alive
			RobotAlive(6) = Robot6Alive
			
			For d = 1 To 6
				HistoryRec(d, 7) = 0
				For counter = 1 To 6
					If counter <> d And RobotTeam(counter) = RobotTeam(d) And RobotAlive(counter) = 1 Then HistoryRec(d, 7) = HistoryRec(d, 7) + 1
				Next counter
				
				HistoryRec(d, 8) = HistoryRec(d, 8) + HistoryRec(d, 7)
			Next d
			
			If R6Present Then 'Modern Trinity Teams
				For counter = 1 To 3
					If InStr(RobotDead(counter).Text, "Overloaded") <> 0 Then DidOverload = True
				Next 
				If Not DidOverload Then
					If Robot1Alive = 1 Xor Robot4Alive = 1 Then HistoryRec(1, 4) = -9 * CShort(Robot1Alive = 1)
					HistoryRec(1, 4) = HistoryRec(1, 4) - CShort(Robot1Alive = 1)
					HistoryRec(2, 4) = -CShort(Robot2Alive = 1)
					HistoryRec(3, 4) = -CShort(Robot3Alive = 1)
				End If
				
				For counter = 4 To 6
					If InStr(RobotDead(counter).Text, "Overloaded") <> 0 Then DidOverload = True
				Next 
				If Not DidOverload Then
					If Robot1Alive = 1 Xor Robot4Alive = 1 Then HistoryRec(4, 4) = -9 * CShort(Robot4Alive = 1)
					HistoryRec(4, 4) = HistoryRec(4, 4) - CShort(Robot4Alive = 1)
					HistoryRec(5, 4) = -CShort(Robot5Alive = 1)
					HistoryRec(6, 4) = -CShort(Robot6Alive = 1)
				End If
			Else 'Classic Teams
				For counter = 1 To 2
					If InStr(RobotDead(counter).Text, "Overloaded") <> 0 Then DidOverload = True
				Next 
				If Not DidOverload Then
					HistoryRec(1, 4) = -CShort(Robot1Alive = 1)
					HistoryRec(2, 4) = -CShort(Robot2Alive = 1)
				End If
				For counter = 3 To 4
					If InStr(RobotDead(counter).Text, "Overloaded") <> 0 Then DidOverload = True
				Next 
				If Not DidOverload Then
					HistoryRec(3, 4) = -CShort(Robot3Alive = 1)
					HistoryRec(4, 4) = -CShort(Robot4Alive = 1)
				End If
			End If
			
			PR1.Text = CStr(CDbl(PR1.Text) + HistoryRec(1, 4))
			PR2.Text = CStr(CDbl(PR2.Text) + HistoryRec(2, 4))
			PR3.Text = CStr(CDbl(PR3.Text) + HistoryRec(3, 4))
			PR4.Text = CStr(CDbl(PR4.Text) + HistoryRec(4, 4))
			PR5.Text = CStr(CDbl(PR5.Text) + HistoryRec(5, 4))
			PR6.Text = CStr(CDbl(PR6.Text) + HistoryRec(6, 4))
		ElseIf Not R3Present Then  'Duel
			PR1.Text = CStr(CShort(PR1.Text) - CShort(Robot1Alive = 1))
			HistoryRec(1, 4) = -CShort(Robot1Alive = 1)
			PR2.Text = CStr(CShort(PR2.Text) - CShort(Robot2Alive = 1))
			HistoryRec(2, 4) = -CShort(Robot2Alive = 1)
		ElseIf R6Present Then  'Grouprounds
			'    If (Robot1Alive = 1) + (Robot2Alive = 1) + (Robot3Alive = 1) + (Robot4Alive = 1) + (Robot5Alive = 1) + (Robot6Alive = 1) >= -3 Then
			If Robot1Alive <> 1 Then
				DeathTimeString = Replace(RobotDead(1).Text, "Dead - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
				DeathTime(1) = Val(DeathTimeString)
			Else
				DeathTime(1) = 32767
			End If
			
			If Robot2Alive <> 1 Then
				DeathTimeString = Replace(RobotDead(2).Text, "Dead - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
				DeathTime(2) = Val(DeathTimeString)
			Else
				DeathTime(2) = 32767
			End If
			
			If Robot3Alive <> 1 Then
				DeathTimeString = Replace(RobotDead(3).Text, "Dead - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
				DeathTime(3) = Val(DeathTimeString)
			Else
				DeathTime(3) = 32767
			End If
			
			If Robot4Alive <> 1 Then
				DeathTimeString = Replace(RobotDead(4).Text, "Dead - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
				DeathTime(4) = Val(DeathTimeString)
			Else
				DeathTime(4) = 32767
			End If
			
			If Robot5Alive <> 1 Then
				DeathTimeString = Replace(RobotDead(5).Text, "Dead - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
				DeathTime(5) = Val(DeathTimeString)
			Else
				DeathTime(5) = 32767
			End If
			
			If Robot6Alive <> 1 Then
				DeathTimeString = Replace(RobotDead(6).Text, "Dead - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Overloaded - Time: ", "")
				DeathTimeString = Replace(DeathTimeString, "Buggy - Time: ", "")
				DeathTime(6) = Val(DeathTimeString)
			Else
				DeathTime(6) = 32767
			End If
			
			
			MaxDeathTime = Max(DeathTime(1), DeathTime(2)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(3)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(4)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(5)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(6))
			TieFlag = -(1 + CShort(MaxDeathTime = DeathTime(1)) + CShort(MaxDeathTime = DeathTime(2)) + CShort(MaxDeathTime = DeathTime(3)) + CShort(MaxDeathTime = DeathTime(4)) + CShort(MaxDeathTime = DeathTime(5)) + CShort(MaxDeathTime = DeathTime(6)))
			
			For c = 1 To 6
				If DeathTime(c) = MaxDeathTime Then
					HistoryRec(c, 4) = 3
					DeathTime(c) = -3
				End If
			Next c
			
			'Check how many bots that ties
			MaxDeathTime = Max(DeathTime(1), DeathTime(2)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(3)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(4)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(5)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(6))
			
			If MaxDeathTime <> -3 Then
				TieFlag = TieFlag - (1 + CShort(MaxDeathTime = DeathTime(1)) + CShort(MaxDeathTime = DeathTime(2)) + CShort(MaxDeathTime = DeathTime(3)) + CShort(MaxDeathTime = DeathTime(4)) + CShort(MaxDeathTime = DeathTime(5)) + CShort(MaxDeathTime = DeathTime(6)))
				'Reward 2nd if there is any
				For c = 1 To 6
					If DeathTime(c) = MaxDeathTime Then
						HistoryRec(c, 4) = ZeroOrMore(2 - TieFlag)
						DeathTime(c) = -2
					End If
				Next c
				
				'Check how many bots that ties again
				MaxDeathTime = Max(DeathTime(1), DeathTime(2)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(3)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(4)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(5)) : MaxDeathTime = Max(MaxDeathTime, DeathTime(6))
				TieFlag = TieFlag - (1 + CShort(MaxDeathTime = DeathTime(1)) + CShort(MaxDeathTime = DeathTime(2)) + CShort(MaxDeathTime = DeathTime(3)) + CShort(MaxDeathTime = DeathTime(4)) + CShort(MaxDeathTime = DeathTime(5)) + CShort(MaxDeathTime = DeathTime(6)))
				
				'Reward 3rd if there is any
				For c = 1 To 6
					If DeathTime(c) = MaxDeathTime Then
						HistoryRec(c, 4) = ZeroOrMore(1 - TieFlag)
					End If
				Next c
			End If
			
			PR1.Text = CStr(CDbl(PR1.Text) + HistoryRec(1, 4))
			PR2.Text = CStr(CDbl(PR2.Text) + HistoryRec(2, 4))
			PR3.Text = CStr(CDbl(PR3.Text) + HistoryRec(3, 4))
			PR4.Text = CStr(CDbl(PR4.Text) + HistoryRec(4, 4))
			PR5.Text = CStr(CDbl(PR5.Text) + HistoryRec(5, 4))
			PR6.Text = CStr(CDbl(PR6.Text) + HistoryRec(6, 4))
			'    End If
		Else
			PR1.Text = CStr(CShort(PR1.Text) - CShort(Robot1Alive = 1))
			PR2.Text = CStr(CShort(PR2.Text) - CShort(Robot2Alive = 1))
			PR3.Text = CStr(CShort(PR3.Text) - CShort(Robot3Alive = 1))
			PR4.Text = CStr(CShort(PR4.Text) - CShort(Robot4Alive = 1))
			PR5.Text = CStr(CShort(PR5.Text) - CShort(Robot5Alive = 1))
			PR6.Text = CStr(CShort(PR6.Text) - CShort(Robot6Alive = 1))
			
			HistoryRec(1, 4) = -CShort(Robot1Alive = 1)
			HistoryRec(2, 4) = -CShort(Robot2Alive = 1)
			HistoryRec(3, 4) = -CShort(Robot3Alive = 1)
			HistoryRec(4, 4) = -CShort(Robot4Alive = 1)
			HistoryRec(5, 4) = -CShort(Robot5Alive = 1)
			HistoryRec(6, 4) = -CShort(Robot6Alive = 1)
		End If
		
		'Record history - All but damage
		'PR1 = Val(PR1) + Val(KR(1))
		
		PR1.Text = CStr(CDbl(PR1.Text) + KR(1))
		PR2.Text = CStr(CDbl(PR2.Text) + KR(2))
		PR3.Text = CStr(CDbl(PR3.Text) + KR(3))
		PR4.Text = CStr(CDbl(PR4.Text) + KR(4))
		PR5.Text = CStr(CDbl(PR5.Text) + KR(5))
		PR6.Text = CStr(CDbl(PR6.Text) + KR(6))
		
		For counter = 1 To 6
			HistoryRec(counter, 1) = HistoryRec(counter, 1) + 1
			HistoryRec(counter, 2) = KR(counter)
			HistoryRec(counter, 3) = HistoryRec(counter, 3) + HistoryRec(counter, 2)
			HistoryRec(counter, 5) = HistoryRec(counter, 5) + HistoryRec(counter, 4)
			HistoryRec(counter, 6) = -CShort(NumberOfRobotsPresent = -CShort(CShort(CShort(CShort(CShort(CShort(Robot1Alive = 1) + CShort(Robot2Alive = 1)) + CShort(Robot3Alive = 1)) + CShort(Robot4Alive = 1)) + CShort(Robot5Alive = 1)) + CShort(Robot6Alive = 1)))
			'9 exists but is not recorded here
			HistoryRec(counter, 10) = Chronon
			HistoryRec(counter, 11) = HistoryRec(counter, 11) + Chronon
		Next counter
		
		If PrintTournamentLog Then
			For counter = 1 To NumberOfRobotsPresent
				TournamentLog(LogWhichBattle).SurvivalPoints(counter) = HistoryRec(counter, 4)
			Next counter
			
			LogWhichBattle = LogWhichBattle + 1
		End If
		
	End Sub
	
	Private Sub EndBattle()
		
		If Not RunningTournament Then
			If R1Present Then ER(1).Visible = True
			If R2Present Then ER(2).Visible = True
			If R3Present Then ER(3).Visible = True
			If R4Present Then ER(4).Visible = True
			If R5Present Then ER(5).Visible = True
			If R6Present Then ER(6).Visible = True
			EnergyDisplay(1).Visible = False 'Turns of the much faster EnergyDisplay in favor for the  more stable ER
			EnergyDisplay(2).Visible = False
			EnergyDisplay(3).Visible = False
			EnergyDisplay(4).Visible = False
			EnergyDisplay(5).Visible = False
			EnergyDisplay(6).Visible = False
			
			If DebuggedRobot <> 0 And DebuggerAutoStart Then
				DebuggingWindow.Close() 'ej disk!!
				TurnOfTheDebugger()
			End If
			
			FileMenu.Enabled = True
			ArenaMenu.Enabled = True
			ViewMenu.Enabled = True
			BattleHaltButton.Enabled = True
			BattleHaltButton.Focus()
			NotRandomEmergency = True
		End If
		
		BattleHaltButton.Text = "Battle"
		CPRTimer.Enabled = False
		
		'CleanUpAllDeathIcons
		
	End Sub
	
	Private Sub EndBattleWhenGotoInst()
		'If Not RunningTournament Then
		If R1Present Then ER(1).Visible = True
		If R2Present Then ER(2).Visible = True
		If R3Present Then ER(3).Visible = True
		If R4Present Then ER(4).Visible = True
		If R5Present Then ER(5).Visible = True
		If R6Present Then ER(6).Visible = True
		EnergyDisplay(1).Visible = False 'Turns of the much faster EnergyDisplay in favor for the  more stable ER
		EnergyDisplay(2).Visible = False
		EnergyDisplay(3).Visible = False
		EnergyDisplay(4).Visible = False
		EnergyDisplay(5).Visible = False
		EnergyDisplay(6).Visible = False
		
		If DebuggedRobot <> 0 And DebuggerAutoStart Then
			DebuggingWindow.Close() 'ej disk!!
			TurnOfTheDebugger()
		End If
		
		FileMenu.Enabled = True
		ArenaMenu.Enabled = True
		ViewMenu.Enabled = True
		BattleHaltButton.Enabled = True
		'End If
		
		BattleHaltButton.Text = "Battle"
		CPRTimer.Enabled = False
		'CleanUpAllDeathIcons
		
		Dim sDup As String
		
		Select Case SelectedRobot
			Case 1
				Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				sDup = R1path
			Case 2
				Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.Color.Black : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				sDup = R2path
			Case 3
				Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.Color.Black : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				sDup = R3path
			Case 4
				Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.Color.Black : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				sDup = R4path
			Case 5
				Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.Color.Black : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				sDup = R5path
			Case 6
				Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.Color.Black : Robot6.ForeColor = System.Drawing.Color.White
				sDup = R6path
		End Select
		
		If R1path = sDup Then RefreshCode(R1path, 1)
		If R2path = sDup Then RefreshCode(R2path, 2)
		If R3path = sDup Then RefreshCode(R3path, 3)
		If R4path = sDup Then RefreshCode(R4path, 4)
		If R5path = sDup Then RefreshCode(R5path, 5)
		If R6path = sDup Then RefreshCode(R6path, 6)
	End Sub
	
	Private Sub InizBattle()
		
		If ChronorsLimit.Checked Then MaxChronon = 1500 Else MaxChronon = -1 'Nödvändig
		NumberOfRobotsPresent = -(CShort(R2Present) + CShort(R3Present) + CShort(R4Present) + CShort(R5Present) + CShort(R6Present) - 1) 'Moved here because MasterIconHandler needs it nowdays
		
		Chronon = 0
		
		BattleHaltButton.Text = "Halt"
		FileMenu.Enabled = False
		ArenaMenu.Enabled = False
		ViewMenu.Enabled = False
		
		KR(1) = 0 : KR(2) = 0 : KR(3) = 0 : KR(4) = 0 : KR(5) = 0 : KR(6) = 0 'ny
		If R2Present Then 'This conditional sets the evaluation order to the opposite of the order in the last battle
			If Not Replaying Then HighestToLowest = Not HighestToLowest 'unless repeat battle is checked
		Else 'or we only have one robot. False => 1 to 6, True => 6 to 1
			HighestToLowest = False 'If there's only one robot is doesn't
		End If 'mater, and standard will probably be faser.
		
		If Not RunningTournament Then
			If Replaying Then
				resetcustom()
			Else
				backupcustom()
				ReDim RandomRegister(0)
			End If
		End If
		
		'FixRobot1   'Moved here because of the 64K limit
		PlaceRobot((1))
		PlaceRobotTurret((1))
		
		RobotDead(1).Visible = False 's
		RobotDead(2).Visible = False
		RobotDead(3).Visible = False
		RobotDead(4).Visible = False
		RobotDead(5).Visible = False
		RobotDead(6).Visible = False
		System.Windows.Forms.Application.DoEvents() 's
		
		If Not HideBattle Then
			ER(1).Visible = False 'Turns of the more stable ER in favor for the much faster EnergyDisplay
			ER(2).Visible = False 's
			ER(3).Visible = False
			ER(4).Visible = False
			ER(5).Visible = False
			ER(6).Visible = False
			'DoEvents                    's
			MasterIconHandler() 's
			CprTimerCount = 0 's
			
			'UPGRADE_ISSUE: PictureBox method Arena.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			Arena.Cls() 's
			CPRTimer.Enabled = True 's
			EnergyDisplay(1).Visible = True 's
			System.Windows.Forms.Application.DoEvents() 'Fixes Dark Knight cosmetic bug     's
			
			Robot_(1) = R1Icon '.picture        's
			
			DR(1).Text = CStr(Robot1Damage) 's
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(1).Cls() 's
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(1).Print(Robot1Energy) 's
			
			'Seticonsettings
			RobotShieldIcon(1) = Robot1ShieldIcon
			RobotHitIcon(1) = Robot1HitIcon
			RobotBlockIcon(1) = Robot1BlockIcon
			RobotDeathIcon(1) = Robot1DeathIcon
			RobotCollisionIcon(1) = Robot1CollisionIcon
			
			If StartDebuggerAt <> DEBUGATNOTSET Then BattleSpeed = 1E-37
		End If
		
	End Sub
	
	Private Sub PlaceRobot(ByRef RNr As Integer)
		If Not Replaying Or LastStartPosX(RNr) = 0 Then
			RobotLeft(RNr) = System.Math.Round(270 * Rnd()) + 15 'Int
			RobotTop(RNr) = System.Math.Round(270 * Rnd()) + 15 'Int
			LastStartPosX(RNr) = RobotLeft(RNr)
			LastStartPosY(RNr) = RobotTop(RNr)
		Else
			RobotLeft(RNr) = LastStartPosX(RNr)
			RobotTop(RNr) = LastStartPosY(RNr)
		End If
	End Sub
	
	Private Sub PlaceRobotTurret(ByRef RNr As Integer)
		TurretX2(RNr) = RobotLeft(RNr) + 10
		TurretY2(RNr) = RobotTop(RNr)
	End Sub
	
	Private Sub MasterPlace2()
Replace2: 
		PlaceRobot((2))
		'Kollar om robotarna är för nära varandra
		' Robot 1 and Robot 2
		If DistBwtn(RobotLeft(1), RobotTop(1), RobotLeft(2), RobotTop(2)) <= 40 Then GoTo Replace2
		PlaceRobotTurret((2))
		
		If Not HideBattle Then
			EnergyDisplay(2).Visible = True
			System.Windows.Forms.Application.DoEvents() 'Fixes Dark Knight cosmetic bug
			Robot_(2) = R2Icon '.picture
			'ER(2) = Robot2Energy
			DR(2).Text = CStr(Robot2Damage)
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(2).Cls()
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(2).Print(Robot2Energy)
			
			RobotShieldIcon(2) = Robot2ShieldIcon
			RobotHitIcon(2) = Robot2HitIcon
			RobotBlockIcon(2) = Robot2BlockIcon
			RobotDeathIcon(2) = Robot2DeathIcon
			RobotCollisionIcon(2) = Robot2CollisionIcon
		End If
		
	End Sub
	Private Sub MasterPlace3()
Replace3: 
		PlaceRobot((3))
		'Kollar om robotarna är för nära varandra - Checks if the robots are to close to each other
		' Robot 1 and Robot 3
		If DistBwtn(RobotLeft(1), RobotTop(1), RobotLeft(3), RobotTop(3)) <= 40 Then GoTo Replace3
		' Robot 2 and Robot 3
		If DistBwtn(RobotLeft(2), RobotTop(2), RobotLeft(3), RobotTop(3)) <= 40 Then GoTo Replace3
		PlaceRobotTurret((3))
		
		If Not HideBattle Then
			EnergyDisplay(3).Visible = True
			System.Windows.Forms.Application.DoEvents() 'Fixes Dark Knight cosmetic bug
			Robot_(3) = R3Icon '.picture
			'ER(3) = Robot3Energy
			DR(3).Text = CStr(Robot3Damage)
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(3).Cls()
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(3).Print(Robot3Energy)
			
			RobotShieldIcon(3) = Robot3ShieldIcon
			RobotHitIcon(3) = Robot3HitIcon
			RobotBlockIcon(3) = Robot3BlockIcon
			RobotDeathIcon(3) = Robot3DeathIcon
			RobotCollisionIcon(3) = Robot3CollisionIcon
		End If
		
	End Sub
	
	Private Sub MasterPlace4()
Replace4: 
		PlaceRobot((4))
		' Robot 1 and Robot 4
		If DistBwtn(RobotLeft(1), RobotTop(1), RobotLeft(4), RobotTop(4)) <= 40 Then GoTo Replace4
		' Robot 2 and Robot 4
		If DistBwtn(RobotLeft(2), RobotTop(2), RobotLeft(4), RobotTop(4)) <= 40 Then GoTo Replace4
		' Robot 3 and Robot 4
		If DistBwtn(RobotLeft(3), RobotTop(3), RobotLeft(4), RobotTop(4)) <= 40 Then GoTo Replace4
		PlaceRobotTurret((4))
		
		If Not HideBattle Then
			EnergyDisplay(4).Visible = True
			System.Windows.Forms.Application.DoEvents() 'Fixes Dark Knight cosmetic bug
			Robot_(4) = R4Icon '.picture
			'ER(4) = Robot4Energy
			DR(4).Text = CStr(Robot4Damage)
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(4).Cls()
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(4).Print(Robot4Energy)
			
			RobotShieldIcon(4) = Robot4ShieldIcon
			RobotHitIcon(4) = Robot4HitIcon
			RobotBlockIcon(4) = Robot4BlockIcon
			RobotDeathIcon(4) = Robot4DeathIcon
			RobotCollisionIcon(4) = Robot4CollisionIcon
		End If
		
	End Sub
	
	
	Private Sub MasterPlace5()
Replace5: 
		PlaceRobot((5))
		'Kollar om robotarna är för nära varandra
		' Robot 1 and Robot 5
		If DistBwtn(RobotLeft(1), RobotTop(1), RobotLeft(5), RobotTop(5)) <= 40 Then GoTo Replace5
		' Robot 2 and Robot 5
		If DistBwtn(RobotLeft(2), RobotTop(2), RobotLeft(5), RobotTop(5)) <= 40 Then GoTo Replace5
		' Robot 3 and Robot 5
		If DistBwtn(RobotLeft(3), RobotTop(3), RobotLeft(5), RobotTop(5)) <= 40 Then GoTo Replace5
		' Robot 4 and Robot 5
		If DistBwtn(RobotLeft(4), RobotTop(4), RobotLeft(5), RobotTop(5)) <= 40 Then GoTo Replace5
		PlaceRobotTurret((5))
		
		If Not HideBattle Then
			EnergyDisplay(5).Visible = True
			System.Windows.Forms.Application.DoEvents() 'Fixes Dark Knight cosmetic bug
			Robot_(5) = R5Icon '.picture
			'ER(5) = Robot5Energy
			DR(5).Text = CStr(Robot5Damage)
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(5).Cls()
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(5).Print(Robot5Energy)
			
			RobotShieldIcon(5) = Robot5ShieldIcon
			RobotHitIcon(5) = Robot5HitIcon
			RobotBlockIcon(5) = Robot5BlockIcon
			RobotDeathIcon(5) = Robot5DeathIcon
			RobotCollisionIcon(5) = Robot5CollisionIcon
		End If
		
	End Sub
	
	Private Sub MasterPlace6()
Replace6: 
		PlaceRobot((6))
		'Kollar om robotarna är för nära varandra
		' Robot 1 and Robot 6
		If DistBwtn(RobotLeft(1), RobotTop(1), RobotLeft(6), RobotTop(6)) <= 40 Then GoTo Replace6
		' Robot 2 and Robot 6
		If DistBwtn(RobotLeft(2), RobotTop(2), RobotLeft(6), RobotTop(6)) <= 40 Then GoTo Replace6
		' Robot 3 and Robot 6
		If DistBwtn(RobotLeft(3), RobotTop(3), RobotLeft(6), RobotTop(6)) <= 40 Then GoTo Replace6
		' Robot 4 and Robot 6
		If DistBwtn(RobotLeft(4), RobotTop(4), RobotLeft(6), RobotTop(6)) <= 40 Then GoTo Replace6
		' Robot 5 and Robot 6
		If DistBwtn(RobotLeft(5), RobotTop(5), RobotLeft(6), RobotTop(6)) <= 40 Then GoTo Replace6
		PlaceRobotTurret((6))
		
		If Not HideBattle Then
			EnergyDisplay(6).Visible = True
			System.Windows.Forms.Application.DoEvents() 'Fixes Dark Knight cosmetic bug
			Robot_(6) = R6Icon '.picture
			'ER(6) = Robot6Energy
			DR(6).Text = CStr(Robot6Damage)
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(6).Cls()
			'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			EnergyDisplay(6).Print(Robot6Energy)
			
			RobotShieldIcon(6) = Robot6ShieldIcon
			RobotHitIcon(6) = Robot6HitIcon
			RobotBlockIcon(6) = Robot6BlockIcon
			RobotDeathIcon(6) = Robot6DeathIcon
			RobotCollisionIcon(6) = Robot6CollisionIcon
		End If
		
	End Sub
	
	Private Function GetRobot(ByRef RobotNumberToGet As Integer) As String
		Select Case RobotNumberToGet
			Case 1
				GetRobot = Robot1.Text
			Case 2
				GetRobot = Robot2.Text
			Case 3
				GetRobot = Robot3.Text
			Case 4
				GetRobot = Robot4.Text
			Case 5
				GetRobot = Robot5.Text
			Case 6
				GetRobot = Robot6.Text
			Case Else
				GetRobot = "-"
		End Select
		
	End Function
	
	
	
	Private Sub TerminateBattle()
		BattleHaltButton.Text = "Battle"
		MaxChronon = Chronon + 1
	End Sub
	
	Private Sub BattleHaltButton_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BattleHaltButton.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			
			Case System.Windows.Forms.Keys.PageDown
				SelectedRobot = SelectedRobot + 1
				
			Case System.Windows.Forms.Keys.PageUp
				SelectedRobot = SelectedRobot - 1
				
			Case System.Windows.Forms.Keys.D1
				Slowest_Click(Slowest, New System.EventArgs())
				Exit Sub
				
			Case System.Windows.Forms.Keys.D2
				Slower_Click(Slower, New System.EventArgs())
				Exit Sub
				
			Case System.Windows.Forms.Keys.D3
				Slow_Click(Slow, New System.EventArgs())
				Exit Sub
				
			Case System.Windows.Forms.Keys.D4
				Normal_Click(Normal, New System.EventArgs())
				Exit Sub
				
			Case System.Windows.Forms.Keys.D5
				Fast_Click(Fast, New System.EventArgs())
				Exit Sub
				
			Case System.Windows.Forms.Keys.D6
				NoDisplay_Click(NoDisplay, New System.EventArgs())
				Exit Sub
				
			Case System.Windows.Forms.Keys.D7
				Ultra_Click(Ultra, New System.EventArgs())
				Exit Sub
				
			Case System.Windows.Forms.Keys.NumPad1
				Team1_Click(Team1, New System.EventArgs())
				Exit Sub
			Case System.Windows.Forms.Keys.NumPad2
				Team2_Click(Team2, New System.EventArgs())
				Exit Sub
			Case System.Windows.Forms.Keys.NumPad3
				Team3_Click(Team3, New System.EventArgs())
				Exit Sub
			Case System.Windows.Forms.Keys.NumPad0
				NoTeam_Click(NoTeam, New System.EventArgs())
				Exit Sub
			Case System.Windows.Forms.Keys.Add
				AutoSetTeams()
				Exit Sub
			Case System.Windows.Forms.Keys.Subtract
				ClearTeams()
				Exit Sub
		End Select
		
		Select Case SelectedRobot
			
			Case 1
				If R1Present Then
					Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				Else
					SelectedRobot = 1
				End If
				
			Case 2
				If R2Present Then
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.Color.Black : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				Else
					Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
					SelectedRobot = 1
				End If
				
			Case 3
				If R3Present Then
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.Color.Black : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				Else
					Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
					SelectedRobot = 1
				End If
				
			Case 4
				If R4Present Then
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.Color.Black : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				Else
					Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
					SelectedRobot = 1
				End If
				
			Case 5
				If R5Present Then
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.Color.Black : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				Else
					Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
					SelectedRobot = 1
				End If
				
			Case 6
				If R6Present Then
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.Color.Black : Robot6.ForeColor = System.Drawing.Color.White
				Else
					Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
					SelectedRobot = 1
				End If
				
			Case 7
				Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				SelectedRobot = 1
				
			Case Is < 1
				If R6Present Then
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.Color.Black : Robot6.ForeColor = System.Drawing.Color.White
					SelectedRobot = 6
					Exit Sub
				End If
				
				If R5Present Then
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.Color.Black : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
					SelectedRobot = 5
					Exit Sub
				End If
				
				If R4Present Then
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.Color.Black : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
					SelectedRobot = 4
					Exit Sub
				End If
				
				If R3Present Then
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.Color.Black : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
					SelectedRobot = 3
					Exit Sub
				End If
				
				If R2Present Then
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.Color.Black : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
					SelectedRobot = 2
					Exit Sub
				End If
				
				If R1Present Then
					Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
					SelectedRobot = 1
					Exit Sub
				End If
				
				Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				SelectedRobot = -1
		End Select
		
	End Sub
	
	Private Sub ClearTeams()
		Dim c As Short
		For c = 1 To 6
			TeamLabel(c).Visible = False
			RobotTeam(c) = 0
		Next c
	End Sub
	
	Private Sub AutoSetTeams()
		Dim c As Short
		
		If R6Present Then
			For c = 1 To 3
				RobotTeam(c) = 1
				TeamLabel(c).Text = "Team 1"
				TeamLabel(c).ForeColor = System.Drawing.ColorTranslator.FromOle(ColorTeam1) 'RGB(200, 241, 18)
				TeamLabel(c).Visible = True
			Next 
			For c = 4 To 6
				RobotTeam(c) = 2
				TeamLabel(c).Text = "Team 2"
				TeamLabel(c).ForeColor = ColorTeam2 'RGB(200, 241, 18)
				TeamLabel(c).Visible = True
			Next 
		ElseIf R4Present Then 
			For c = 1 To 2
				RobotTeam(c) = 1
				TeamLabel(c).Text = "Team 1"
				TeamLabel(c).ForeColor = System.Drawing.ColorTranslator.FromOle(ColorTeam1) 'RGB(200, 241, 18)
				TeamLabel(c).Visible = True
			Next 
			For c = 3 To 4
				RobotTeam(c) = 2
				TeamLabel(c).Text = "Team 2"
				TeamLabel(c).ForeColor = ColorTeam2 'RGB(200, 241, 18)
				TeamLabel(c).Visible = True
			Next 
		End If
	End Sub
	
	Public Sub TurnOfTheDebugger() 'Can be called from debuggingwindow
		If DebuggedRobot <> 0 Then
			Image1(DebuggedRobot).Visible = False
			DebuggedRobot = 0
		End If
		
		If Normal.Checked Then
			Normal_Click(Normal, New System.EventArgs())
		ElseIf Fast.Checked Then 
			Fast_Click(Fast, New System.EventArgs())
		ElseIf AutoRedrawFast.Checked Then 
			AutoRedrawFast_Click(AutoRedrawFast, New System.EventArgs())
		ElseIf Ultra.Checked Then 
			Ultra_Click(Ultra, New System.EventArgs())
		ElseIf Slow.Checked Then 
			Slow_Click(Slow, New System.EventArgs())
		ElseIf Slower.Checked Then 
			Slower_Click(Slower, New System.EventArgs())
		ElseIf Slowest.Checked Then 
			Slowest_Click(Slowest, New System.EventArgs())
		End If
		
	End Sub
	
	Private Sub SetTabIndex1() 'I hate I hate I hate the 64 K code limit
		DebuggingWindow.ChrononStep.TabIndex = 0
		DebuggingWindow.Step_Renamed.TabIndex = 4
	End Sub
	
	Private Sub SetTabIndex2()
		DebuggingWindow.Step_Renamed.TabIndex = 0
		DebuggingWindow.ChrononStep.TabIndex = 1
	End Sub
	
	Private Sub PrintDebuggingInfo(ByRef I_RobotInstPos As Integer, ByRef I_MachineCode As Integer, ByRef DRobotStackPos As Integer, ByRef MPlus1 As Integer, ByRef MPlus2 As Integer, ByRef MPlus3 As Integer, ByRef MPlus4 As Integer, ByRef MPlus5 As Integer, ByRef MPlus6 As Integer, ByRef RobotStack100 As Integer, ByRef RobotStack99 As Integer, ByRef RobotStack98 As Integer, ByRef RobotStack97 As Integer, ByRef D_ChrononExecutor1 As Integer, ByRef D_RAim As Integer, ByRef D_RShield As Integer, ByRef D_RRange As Object, ByRef D_RangedRobot As Integer, ByRef D_RRadar As Object, ByRef D_RLook As Integer, ByRef D_RScan As Integer, ByRef D_RSpeedx As Integer, ByRef D_RSpeedy As Integer, ByRef D_REnergy As Integer)
		
		BattleSpeed = (1 / 70) '70 är för normal
		'UPGRADE_ISSUE: PictureBox property Arena.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.AutoRedraw = True
		
		Dim DebuggingInfo As String
		
		DebuggingInfo = "Debugging " & GetRobot(DebuggedRobot) & vbLf & "Chronon = " & Chronon & vbLf & vbLf & "Instruction No. = " & I_RobotInstPos & vbLf & "Instruction = " & S(I_MachineCode) & vbLf & vbLf
		
		If DRobotStackPos <= 96 Then
			DebuggingInfo = DebuggingInfo & "StackPos" & 6 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus6, 6 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf & "StackPos" & 5 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus5, 5 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf & "StackPos" & 4 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus4, 4 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf & "StackPos" & 3 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus3, 3 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf & "StackPos" & 2 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus2, 2 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf & "StackPos" & 1 + ((DRobotStackPos - 1) \ 6) * 6 & " = " & DbTr(MPlus1, 1 + ((DRobotStackPos - 1) \ 6) * 6, DRobotStackPos) & vbLf
		Else
			DebuggingInfo = DebuggingInfo & "StackPos 100 = " & DbTr(RobotStack100, 100, DRobotStackPos) & vbLf & "StackPos 99 = " & DbTr(RobotStack99, 99, DRobotStackPos) & vbLf & "StackPos 98 = " & DbTr(RobotStack98, 98, DRobotStackPos) & vbLf & "StackPos 97 = " & DbTr(RobotStack97, 97, DRobotStackPos) & vbLf & vbLf & vbLf
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object D_RRadar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object D_RRange. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DebuggingInfo = DebuggingInfo & vbLf & "Processor Position = " & D_ChrononExecutor1 & vbLf & vbLf & "Energy " & D_REnergy & vbLf & "Aim " & D_RAim & vbLf & "Shield " & D_RShield & vbLf & "Range " & D_RRange & vbLf & "Ranging " & GetRobot(D_RangedRobot) & vbLf & "Radar " & D_RRadar & vbLf & "Look " & D_RLook & vbLf & "Scan " & D_RScan & vbLf & "x " & RobotLeft(DebuggedRobot) & vbLf & "y " & RobotTop(DebuggedRobot) & vbLf & "Speedx " & D_RSpeedx & vbLf & "Speedy " & D_RSpeedy
		
		'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		EnergyDisplay(DebuggedRobot).Cls()
		'UPGRADE_ISSUE: PictureBox method EnergyDisplay.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		EnergyDisplay(DebuggedRobot).Print(D_REnergy)
		
		'UPGRADE_ISSUE: Form method DebuggingWindow.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		DebuggingWindow.Cls()
		'UPGRADE_ISSUE: Form method DebuggingWindow.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		DebuggingWindow.Print(DebuggingInfo)
		DebuggingWindow.DebugMsg = DebuggingInfo
	End Sub
	
	Private Function DbTr(ByRef Instruction As Integer, ByRef currentnr As Integer, ByRef highestnr As Integer) As String
		If currentnr > highestnr Then DbTr = "" Else DbTr = S(Instruction)
	End Function
	
	Private Sub ReturnMacAdd()
		DebuggingWindow.Show()
		
		DebuggingWindow.DebuggingRes = 5
		
		Do While DebuggingWindow.DebuggingRes = 5 'Pauses the battle till the user has pressed a button in the debuggingwindow
			If BattleHaltButton.Text = "Battle" Then DebuggingWindow.DebuggingRes = 3 'or the battle halt button
			System.Windows.Forms.Application.DoEvents()
		Loop 
		
	End Sub
	
	Private Function Min(ByRef Compare1 As Integer, ByRef Compare2 As Integer) As Integer
		If Compare1 > Compare2 Then Min = Compare2 Else Min = Compare1
	End Function
	
	Private Function Max(ByRef Compare1 As Integer, ByRef Compare2 As Integer) As Integer
		If Compare1 < Compare2 Then Max = Compare2 Else Max = Compare1
	End Function
	
	Private Function ZeroOrMore(ByRef MakeToZeroOrMore As Integer) As Integer
		If MakeToZeroOrMore > 0 Then ZeroOrMore = MakeToZeroOrMore 'Else ZeroOrMore = 0
	End Function
	
	Private Function CheckHowManyLeft() As Integer
		If R2Present Then CheckHowManyLeft = NumberOfRobotsPresent Else CheckHowManyLeft = 2
	End Function
	
	Public Sub ChangeResolution_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ChangeResolution.Click
		If ResolutionChanged = 1 Then
			ResolutionChanged = 0
			ChangeResolution.Text = "Change Resolution"
		Else
			ResolutionChanged = 1
			ChangeResolution.Text = "Change Back"
		End If
		
		'UPGRADE_ISSUE: Form property MainWindow.hdc was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		ChangeWindow_640X480((Me.hdc))
	End Sub
	
	Private Sub TransferCode(ByRef ToRobot As Integer, ByRef FromRobot As Integer)
		Dim c As Integer
		
		For c = 0 To 4999
			MasterCode(ToRobot, c) = MasterCode(FromRobot, c)
		Next c
		
	End Sub
	
	Public Sub Close_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Close_Renamed.Click
		NotRandomEmergency = False
		
		NewRobot.Enabled = True
		LoadRobot.Enabled = True
		Duplicate.Enabled = True
		SaveAs.Enabled = True
		
		Select Case SelectedRobot
			Case 1
				If R2Present = False Then
					R1Present = False
					RobotTeam(1) = 0
					Energy1X.Visible = False
					Damage1X.Visible = False
					Points1X.Visible = False
					Robot1.Text = "No Robot Selected"
					ER(1).Visible = False
					DR(1).Visible = False
					PR1.Visible = False
					R1Icon.Image = Nothing
					SelectedRobot = -1
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				Else
					R1path = R2path
					TransferCode(1, 2)
					RobotTeam(1) = RobotTeam(2) : TeamLabel(1).Text = TeamLabel(2).Text : TeamLabel(1).ForeColor = TeamLabel(2).ForeColor
					Energy1X.Text = Energy2X.Text
					Damage1X.Text = Damage2X.Text
					Points1X.Text = Points2X.Text
					Robot1.Text = Robot2.Text
					ER(1).Text = ER(2).Text
					DR(1).Text = DR(2).Text
					PR1.Text = PR2.Text
					R1Icon.Image = R2Icon.Image
					Robot1Energy = Robot2Energy
					Robot1Damage = Robot2Damage
					Robot1Shield = Robot2Shield
					Robot1ProSpeed = Robot2ProSpeed
					Robot1Bullets = Robot2Bullets
					Robot1Probes = Robot2Probes
					Robot1Missiles = Robot2Missiles
					Robot1TacNukes = Robot2TacNukes
					Robot1Hellbores = Robot2Hellbores
					Robot1Drones = Robot2Drones
					Robot1Stunners = Robot2Stunners
					Robot1Mines = Robot2Mines
					Robot1Lasers = Robot2Lasers
					Robot1Turret = Robot2Turret
					Robot1ShieldIcon = Robot2ShieldIcon
					Robot1HitIcon = Robot2HitIcon
					Robot1BlockIcon = Robot2BlockIcon
					Robot1DeathIcon = Robot2DeathIcon
					Robot1CollisionIcon = Robot2CollisionIcon
					'Whoo! Det här blir komplicerat
					If R3Present = False Then
						R2Present = False
						RobotTeam(2) = 0
						RobotLeft(2) = -100
						Energy2X.Visible = False
						Damage2X.Visible = False
						Points2X.Visible = False
						Robot2.Text = "No Robot Selected"
						ER(2).Visible = False
						DR(2).Visible = False
						PR2.Visible = False
						R2Icon.Image = Nothing
					Else
						R2path = R3path
						TransferCode(2, 3)
						RobotTeam(2) = RobotTeam(3) : TeamLabel(2).Text = TeamLabel(3).Text : TeamLabel(2).ForeColor = TeamLabel(3).ForeColor
						Energy2X.Text = Energy3X.Text
						Damage2X.Text = Damage3X.Text
						Points2X.Text = Points3X.Text
						Robot2.Text = Robot3.Text
						ER(2).Text = ER(3).Text
						DR(2).Text = DR(3).Text
						PR2.Text = PR3.Text
						R2Icon.Image = R3Icon.Image
						Robot2Energy = Robot3Energy
						Robot2Damage = Robot3Damage
						Robot2Shield = Robot3Shield
						Robot2ProSpeed = Robot3ProSpeed
						Robot2Bullets = Robot3Bullets
						Robot2Probes = Robot3Probes
						Robot2Missiles = Robot3Missiles
						Robot2TacNukes = Robot3TacNukes
						Robot2Hellbores = Robot3Hellbores
						Robot2Drones = Robot3Drones
						Robot2Stunners = Robot3Stunners
						Robot2Mines = Robot3Mines
						Robot2Lasers = Robot3Lasers
						Robot2Turret = Robot3Turret
						Robot2ShieldIcon = Robot3ShieldIcon
						Robot2HitIcon = Robot3HitIcon
						Robot2BlockIcon = Robot3BlockIcon
						Robot2DeathIcon = Robot3DeathIcon
						Robot2CollisionIcon = Robot3CollisionIcon
						If R4Present = False Then
							R3Present = False
							RobotTeam(3) = 0
							RobotLeft(3) = -200
							Energy3X.Visible = False
							Damage3X.Visible = False
							Points3X.Visible = False
							Robot3.Text = "No Robot Selected"
							ER(3).Visible = False
							DR(3).Visible = False
							PR3.Visible = False
							R3Icon.Image = Nothing
						Else
							R3path = R4path
							TransferCode(3, 4)
							RobotTeam(3) = RobotTeam(4) : TeamLabel(3).Text = TeamLabel(4).Text : TeamLabel(3).ForeColor = TeamLabel(4).ForeColor
							Energy3X.Text = Energy4X.Text
							Damage3X.Text = Damage4X.Text
							Points3X.Text = Points4X.Text
							Robot3.Text = Robot4.Text
							ER(3).Text = ER(4).Text
							DR(3).Text = DR(4).Text
							PR3.Text = PR4.Text
							R3Icon.Image = R4Icon.Image
							Robot3Energy = Robot4Energy
							Robot3Damage = Robot4Damage
							Robot3Shield = Robot4Shield
							Robot3ProSpeed = Robot4ProSpeed
							Robot3Bullets = Robot4Bullets
							Robot3Probes = Robot4Probes
							Robot3Missiles = Robot4Missiles
							Robot3TacNukes = Robot4TacNukes
							Robot3Hellbores = Robot4Hellbores
							Robot3Drones = Robot4Drones
							Robot3Stunners = Robot4Stunners
							Robot3Mines = Robot4Mines
							Robot3Lasers = Robot4Lasers
							Robot3Turret = Robot4Turret
							Robot3ShieldIcon = Robot4ShieldIcon
							Robot3HitIcon = Robot4HitIcon
							Robot3BlockIcon = Robot4BlockIcon
							Robot3DeathIcon = Robot4DeathIcon
							Robot3CollisionIcon = Robot4CollisionIcon
							If R5Present = False Then
								R4Present = False
								RobotTeam(4) = 0
								RobotLeft(4) = -300
								Energy4X.Visible = False
								Damage4X.Visible = False
								Points4X.Visible = False
								Robot4.Text = "No Robot Selected"
								ER(4).Visible = False
								DR(4).Visible = False
								PR4.Visible = False
								R4Icon.Image = Nothing
							Else
								R4path = R5path
								TransferCode(4, 5)
								RobotTeam(4) = RobotTeam(5) : TeamLabel(4).Text = TeamLabel(5).Text : TeamLabel(4).ForeColor = TeamLabel(5).ForeColor
								Energy4X.Text = Energy5X.Text
								Damage4X.Text = Damage5X.Text
								Points4X.Text = Points5X.Text
								Robot4.Text = Robot5.Text
								ER(4).Text = ER(5).Text
								DR(4).Text = DR(5).Text
								PR4.Text = PR5.Text
								R4Icon.Image = R5Icon.Image
								Robot4Energy = Robot5Energy
								Robot4Damage = Robot5Damage
								Robot4Shield = Robot5Shield
								Robot4ProSpeed = Robot5ProSpeed
								Robot4Bullets = Robot5Bullets
								Robot4Probes = Robot5Probes
								Robot4Missiles = Robot5Missiles
								Robot4TacNukes = Robot5TacNukes
								Robot4Hellbores = Robot5Hellbores
								Robot4Drones = Robot5Drones
								Robot4Stunners = Robot5Stunners
								Robot4Mines = Robot5Mines
								Robot4Lasers = Robot5Lasers
								Robot4Turret = Robot5Turret
								Robot4ShieldIcon = Robot5ShieldIcon
								Robot4HitIcon = Robot5HitIcon
								Robot4BlockIcon = Robot5BlockIcon
								Robot4DeathIcon = Robot5DeathIcon
								Robot4CollisionIcon = Robot5CollisionIcon
								If R6Present = False Then
									R5Present = False
									RobotTeam(5) = 0
									RobotLeft(5) = -400
									Energy5X.Visible = False
									Damage5X.Visible = False
									Points5X.Visible = False
									Robot5.Text = "No Robot Selected"
									ER(5).Visible = False
									DR(5).Visible = False
									PR5.Visible = False
									R5Icon.Image = Nothing
								Else
									R5path = R6path
									TransferCode(5, 6)
									RobotTeam(5) = RobotTeam(6) : TeamLabel(5).Text = TeamLabel(6).Text : TeamLabel(5).ForeColor = TeamLabel(6).ForeColor
									Energy5X.Text = Energy6X.Text
									Damage5X.Text = Damage6X.Text
									Points5X.Text = Points6X.Text
									Robot5.Text = Robot6.Text
									ER(5).Text = ER(6).Text
									DR(5).Text = DR(6).Text
									
									PR5.Text = PR6.Text
									R5Icon.Image = R6Icon.Image
									Robot5Energy = Robot6Energy
									Robot5Damage = Robot6Damage
									Robot5Shield = Robot6Shield
									Robot5ProSpeed = Robot6ProSpeed
									Robot5Bullets = Robot6Bullets
									Robot5Probes = Robot6Probes
									Robot5Missiles = Robot6Missiles
									Robot5TacNukes = Robot6TacNukes
									Robot5Hellbores = Robot6Hellbores
									Robot5Drones = Robot6Drones
									Robot5Stunners = Robot6Stunners
									Robot5Mines = Robot6Mines
									Robot5Lasers = Robot6Lasers
									Robot5Turret = Robot6Turret
									Robot5ShieldIcon = Robot6ShieldIcon
									Robot5HitIcon = Robot6HitIcon
									Robot5BlockIcon = Robot6BlockIcon
									Robot5DeathIcon = Robot6DeathIcon
									Robot5CollisionIcon = Robot6CollisionIcon
									
									R6Present = False
									TeamLabel(6).Visible = False : RobotTeam(6) = 0
									RobotLeft(6) = -500
									Energy6X.Visible = False
									Damage6X.Visible = False
									Points6X.Visible = False
									Robot6.Text = "No Robot Selected"
									ER(6).Visible = False
									DR(6).Visible = False
									
									PR6.Visible = False
									R6Icon.Image = Nothing
								End If
							End If
						End If
					End If
				End If
			Case 6
				R6Present = False
				RobotTeam(6) = 0
				RobotLeft(6) = -100
				Energy6X.Visible = False
				Damage6X.Visible = False
				Points6X.Visible = False
				Robot6.Text = "No Robot Selected"
				ER(6).Visible = False
				
				DR(6).Visible = False
				
				PR6.Visible = False
				R6Icon.Image = Nothing
				SelectedRobot = 5
				Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.Color.Black : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
			Case 5
				If R6Present = False Then
					R5Present = False
					RobotTeam(5) = 0
					RobotLeft(5) = -100
					Energy5X.Visible = False
					Damage5X.Visible = False
					Points5X.Visible = False
					Robot5.Text = "No Robot Selected"
					ER(5).Visible = False
					DR(5).Visible = False
					PR5.Visible = False
					R5Icon.Image = Nothing
					SelectedRobot = 4
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.Color.Black : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				Else
					R5path = R6path
					TransferCode(5, 6)
					RobotTeam(5) = RobotTeam(6) : TeamLabel(5).Text = TeamLabel(6).Text : TeamLabel(5).ForeColor = TeamLabel(6).ForeColor
					Energy5X.Text = Energy6X.Text
					Damage5X.Text = Damage6X.Text
					Points5X.Text = Points6X.Text
					Robot5.Text = Robot6.Text
					ER(5).Text = ER(6).Text
					DR(5).Text = DR(6).Text
					
					PR5.Text = PR6.Text
					R5Icon.Image = R6Icon.Image
					Robot5Energy = Robot6Energy
					Robot5Damage = Robot6Damage
					Robot5Shield = Robot6Shield
					Robot5ProSpeed = Robot6ProSpeed
					Robot5Bullets = Robot6Bullets
					Robot5Probes = Robot6Probes
					Robot5Missiles = Robot6Missiles
					Robot5TacNukes = Robot6TacNukes
					Robot5Hellbores = Robot6Hellbores
					Robot5Drones = Robot6Drones
					Robot5Stunners = Robot6Stunners
					Robot5Mines = Robot6Mines
					Robot5Lasers = Robot6Lasers
					Robot5Turret = Robot6Turret
					Robot5ShieldIcon = Robot6ShieldIcon
					Robot5HitIcon = Robot6HitIcon
					Robot5BlockIcon = Robot6BlockIcon
					Robot5DeathIcon = Robot6DeathIcon
					Robot5CollisionIcon = Robot6CollisionIcon
					
					R6Present = False
					RobotTeam(6) = 0
					RobotLeft(6) = -100
					Energy6X.Visible = False
					Damage6X.Visible = False
					Points6X.Visible = False
					Robot6.Text = "No Robot Selected"
					ER(6).Visible = False
					DR(6).Visible = False
					
					PR6.Visible = False
					R6Icon.Image = Nothing
				End If
			Case 4
				If R5Present = False Then
					R4Present = False
					RobotTeam(4) = 0
					RobotLeft(4) = -100
					Energy4X.Visible = False
					Damage4X.Visible = False
					Points4X.Visible = False
					Robot4.Text = "No Robot Selected"
					ER(4).Visible = False
					DR(4).Visible = False
					PR4.Visible = False
					R4Icon.Image = Nothing
					SelectedRobot = 3
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.Color.Black : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				Else
					R4path = R5path
					TransferCode(4, 5)
					RobotTeam(4) = RobotTeam(5) : TeamLabel(4).Text = TeamLabel(5).Text : TeamLabel(4).ForeColor = TeamLabel(5).ForeColor
					Energy4X.Text = Energy5X.Text
					Damage4X.Text = Damage5X.Text
					Points4X.Text = Points5X.Text
					Robot4.Text = Robot5.Text
					ER(4).Text = ER(5).Text
					DR(4).Text = DR(5).Text
					PR4.Text = PR5.Text
					R4Icon.Image = R5Icon.Image
					Robot4Energy = Robot5Energy
					Robot4Damage = Robot5Damage
					Robot4Shield = Robot5Shield
					Robot4ProSpeed = Robot5ProSpeed
					Robot4Bullets = Robot5Bullets
					Robot4Probes = Robot5Probes
					Robot4Missiles = Robot5Missiles
					Robot4TacNukes = Robot5TacNukes
					Robot4Hellbores = Robot5Hellbores
					Robot4Drones = Robot5Drones
					Robot4Stunners = Robot5Stunners
					Robot4Mines = Robot5Mines
					Robot4Lasers = Robot5Lasers
					Robot4Turret = Robot5Turret
					Robot4ShieldIcon = Robot5ShieldIcon
					Robot4HitIcon = Robot5HitIcon
					Robot4BlockIcon = Robot5BlockIcon
					Robot4DeathIcon = Robot5DeathIcon
					Robot4CollisionIcon = Robot5CollisionIcon
					If R6Present = False Then
						R5Present = False
						RobotTeam(5) = 0
						RobotLeft(5) = -100
						Energy5X.Visible = False
						Damage5X.Visible = False
						Points5X.Visible = False
						Robot5.Text = "No Robot Selected"
						ER(5).Visible = False
						DR(5).Visible = False
						PR5.Visible = False
						R5Icon.Image = Nothing
					Else
						R5path = R6path
						TransferCode(5, 6)
						RobotTeam(5) = RobotTeam(6) : TeamLabel(5).Text = TeamLabel(6).Text : TeamLabel(5).ForeColor = TeamLabel(6).ForeColor
						Energy5X.Text = Energy6X.Text
						Damage5X.Text = Damage6X.Text
						Points5X.Text = Points6X.Text
						Robot5.Text = Robot6.Text
						ER(5).Text = ER(6).Text
						DR(5).Text = DR(6).Text
						
						PR5.Text = PR6.Text
						R5Icon.Image = R6Icon.Image
						Robot5Energy = Robot6Energy
						Robot5Damage = Robot6Damage
						Robot5Shield = Robot6Shield
						Robot5ProSpeed = Robot6ProSpeed
						Robot5Bullets = Robot6Bullets
						Robot5Probes = Robot6Probes
						Robot5Missiles = Robot6Missiles
						Robot5TacNukes = Robot6TacNukes
						Robot5Hellbores = Robot6Hellbores
						Robot5Drones = Robot6Drones
						Robot5Stunners = Robot6Stunners
						Robot5Mines = Robot6Mines
						Robot5Lasers = Robot6Lasers
						Robot5Turret = Robot6Turret
						Robot5ShieldIcon = Robot6ShieldIcon
						Robot5HitIcon = Robot6HitIcon
						Robot5BlockIcon = Robot6BlockIcon
						Robot5DeathIcon = Robot6DeathIcon
						Robot5CollisionIcon = Robot6CollisionIcon
						
						R6Present = False
						RobotTeam(6) = 0
						RobotLeft(6) = -100
						Energy6X.Visible = False
						Damage6X.Visible = False
						Points6X.Visible = False
						Robot6.Text = "No Robot Selected"
						ER(6).Visible = False
						DR(6).Visible = False
						
						PR6.Visible = False
						R6Icon.Image = Nothing
					End If
				End If
			Case 3
				If R4Present = False Then
					R3Present = False
					RobotTeam(3) = 0
					RobotLeft(3) = -100
					Energy3X.Visible = False
					Damage3X.Visible = False
					Points3X.Visible = False
					Robot3.Text = "No Robot Selected"
					ER(3).Visible = False
					DR(3).Visible = False
					PR3.Visible = False
					R3Icon.Image = Nothing
					SelectedRobot = 2
					Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.Color.Black : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				Else
					R3path = R4path
					TransferCode(3, 4)
					RobotTeam(3) = RobotTeam(4) : TeamLabel(3).Text = TeamLabel(4).Text : TeamLabel(3).ForeColor = TeamLabel(4).ForeColor
					Energy3X.Text = Energy4X.Text
					Damage3X.Text = Damage4X.Text
					Points3X.Text = Points4X.Text
					Robot3.Text = Robot4.Text
					ER(3).Text = ER(4).Text
					DR(3).Text = DR(4).Text
					PR3.Text = PR4.Text
					R3Icon.Image = R4Icon.Image
					Robot3Energy = Robot4Energy
					Robot3Damage = Robot4Damage
					Robot3Shield = Robot4Shield
					Robot3ProSpeed = Robot4ProSpeed
					Robot3Bullets = Robot4Bullets
					Robot3Probes = Robot4Probes
					Robot3Missiles = Robot4Missiles
					Robot3TacNukes = Robot4TacNukes
					Robot3Hellbores = Robot4Hellbores
					Robot3Drones = Robot4Drones
					Robot3Stunners = Robot4Stunners
					Robot3Mines = Robot4Mines
					Robot3Lasers = Robot4Lasers
					Robot3Turret = Robot4Turret
					Robot3ShieldIcon = Robot4ShieldIcon
					Robot3HitIcon = Robot4HitIcon
					Robot3BlockIcon = Robot4BlockIcon
					Robot3DeathIcon = Robot4DeathIcon
					Robot3CollisionIcon = Robot4CollisionIcon
					If R5Present = False Then
						R4Present = False
						RobotTeam(4) = 0
						RobotLeft(4) = -100
						Energy4X.Visible = False
						Damage4X.Visible = False
						Points4X.Visible = False
						Robot4.Text = "No Robot Selected"
						ER(4).Visible = False
						DR(4).Visible = False
						PR4.Visible = False
						R4Icon.Image = Nothing
					Else
						R4path = R5path
						TransferCode(4, 5)
						RobotTeam(4) = RobotTeam(5) : TeamLabel(4).Text = TeamLabel(5).Text : TeamLabel(4).ForeColor = TeamLabel(5).ForeColor
						Energy4X.Text = Energy5X.Text
						Damage4X.Text = Damage5X.Text
						Points4X.Text = Points5X.Text
						Robot4.Text = Robot5.Text
						ER(4).Text = ER(5).Text
						DR(4).Text = DR(5).Text
						PR4.Text = PR5.Text
						R4Icon.Image = R5Icon.Image
						Robot4Energy = Robot5Energy
						Robot4Damage = Robot5Damage
						Robot4Shield = Robot5Shield
						Robot4ProSpeed = Robot5ProSpeed
						Robot4Bullets = Robot5Bullets
						Robot4Probes = Robot5Probes
						Robot4Missiles = Robot5Missiles
						Robot4TacNukes = Robot5TacNukes
						Robot4Hellbores = Robot5Hellbores
						Robot4Drones = Robot5Drones
						Robot4Stunners = Robot5Stunners
						Robot4Mines = Robot5Mines
						Robot4Lasers = Robot5Lasers
						Robot4Turret = Robot5Turret
						Robot4ShieldIcon = Robot5ShieldIcon
						Robot4HitIcon = Robot5HitIcon
						Robot4BlockIcon = Robot5BlockIcon
						Robot4DeathIcon = Robot5DeathIcon
						Robot4CollisionIcon = Robot5CollisionIcon
						If R6Present = False Then
							R5Present = False
							RobotTeam(5) = 0
							RobotLeft(5) = -100
							Energy5X.Visible = False
							Damage5X.Visible = False
							Points5X.Visible = False
							Robot5.Text = "No Robot Selected"
							ER(5).Visible = False
							DR(5).Visible = False
							PR5.Visible = False
							R5Icon.Image = Nothing
						Else
							R5path = R6path
							TransferCode(5, 6)
							RobotTeam(5) = RobotTeam(6) : TeamLabel(5).Text = TeamLabel(6).Text : TeamLabel(5).ForeColor = TeamLabel(6).ForeColor
							Energy5X.Text = Energy6X.Text
							Damage5X.Text = Damage6X.Text
							Points5X.Text = Points6X.Text
							Robot5.Text = Robot6.Text
							ER(5).Text = ER(6).Text
							DR(5).Text = DR(6).Text
							
							PR5.Text = PR6.Text
							R5Icon.Image = R6Icon.Image
							Robot5Energy = Robot6Energy
							Robot5Damage = Robot6Damage
							Robot5Shield = Robot6Shield
							Robot5ProSpeed = Robot6ProSpeed
							Robot5Bullets = Robot6Bullets
							Robot5Probes = Robot6Probes
							Robot5Missiles = Robot6Missiles
							Robot5TacNukes = Robot6TacNukes
							Robot5Hellbores = Robot6Hellbores
							Robot5Drones = Robot6Drones
							Robot5Stunners = Robot6Stunners
							Robot5Mines = Robot6Mines
							Robot5Lasers = Robot6Lasers
							Robot5Turret = Robot6Turret
							Robot5ShieldIcon = Robot6ShieldIcon
							Robot5HitIcon = Robot6HitIcon
							Robot5BlockIcon = Robot6BlockIcon
							Robot5DeathIcon = Robot6DeathIcon
							Robot5CollisionIcon = Robot6CollisionIcon
							
							R6Present = False
							RobotTeam(6) = 0
							RobotLeft(6) = -100
							Energy6X.Visible = False
							Damage6X.Visible = False
							Points6X.Visible = False
							Robot6.Text = "No Robot Selected"
							ER(6).Visible = False
							DR(6).Visible = False
							
							PR6.Visible = False
							R6Icon.Image = Nothing
						End If
					End If
				End If
			Case 2
				If R3Present = False Then
					R2Present = False
					RobotTeam(2) = 0
					RobotLeft(2) = -100
					Energy2X.Visible = False
					Damage2X.Visible = False
					Points2X.Visible = False
					Robot2.Text = "No Robot Selected"
					ER(2).Visible = False
					DR(2).Visible = False
					PR2.Visible = False
					R2Icon.Image = Nothing
					SelectedRobot = 1
					Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
				Else
					R2path = R3path
					TransferCode(2, 3)
					RobotTeam(2) = RobotTeam(3) : TeamLabel(2).Text = TeamLabel(3).Text : TeamLabel(2).ForeColor = TeamLabel(3).ForeColor
					Energy2X.Text = Energy3X.Text
					Damage2X.Text = Damage3X.Text
					Points2X.Text = Points3X.Text
					Robot2.Text = Robot3.Text
					ER(2).Text = ER(3).Text
					DR(2).Text = DR(3).Text
					PR2.Text = PR3.Text
					R2Icon.Image = R3Icon.Image
					Robot2Energy = Robot3Energy
					Robot2Damage = Robot3Damage
					Robot2Shield = Robot3Shield
					Robot2ProSpeed = Robot3ProSpeed
					Robot2Bullets = Robot3Bullets
					Robot2Probes = Robot3Probes
					Robot2Missiles = Robot3Missiles
					Robot2TacNukes = Robot3TacNukes
					Robot2Hellbores = Robot3Hellbores
					Robot2Drones = Robot3Drones
					Robot2Stunners = Robot3Stunners
					Robot2Mines = Robot3Mines
					Robot2Lasers = Robot3Lasers
					Robot2Turret = Robot3Turret
					Robot2ShieldIcon = Robot3ShieldIcon
					Robot2HitIcon = Robot3HitIcon
					Robot2BlockIcon = Robot3BlockIcon
					Robot2DeathIcon = Robot3DeathIcon
					Robot2CollisionIcon = Robot3CollisionIcon
					If R4Present = False Then
						R3Present = False
						RobotTeam(3) = 0
						RobotLeft(3) = -100
						Energy3X.Visible = False
						Damage3X.Visible = False
						Points3X.Visible = False
						Robot3.Text = "No Robot Selected"
						ER(3).Visible = False
						DR(3).Visible = False
						PR3.Visible = False
						R3Icon.Image = Nothing
					Else
						R3path = R4path
						TransferCode(3, 4)
						RobotTeam(3) = RobotTeam(4) : TeamLabel(3).Text = TeamLabel(4).Text : TeamLabel(3).ForeColor = TeamLabel(4).ForeColor
						Energy3X.Text = Energy4X.Text
						Damage3X.Text = Damage4X.Text
						Points3X.Text = Points4X.Text
						Robot3.Text = Robot4.Text
						ER(3).Text = ER(4).Text
						DR(3).Text = DR(4).Text
						PR3.Text = PR4.Text
						R3Icon.Image = R4Icon.Image
						Robot3Energy = Robot4Energy
						Robot3Damage = Robot4Damage
						Robot3Shield = Robot4Shield
						Robot3ProSpeed = Robot4ProSpeed
						Robot3Bullets = Robot4Bullets
						Robot3Probes = Robot4Probes
						Robot3Missiles = Robot4Missiles
						Robot3TacNukes = Robot4TacNukes
						Robot3Hellbores = Robot4Hellbores
						Robot3Drones = Robot4Drones
						Robot3Stunners = Robot4Stunners
						Robot3Mines = Robot4Mines
						Robot3Lasers = Robot4Lasers
						Robot3Turret = Robot4Turret
						Robot3ShieldIcon = Robot4ShieldIcon
						Robot3HitIcon = Robot4HitIcon
						Robot3BlockIcon = Robot4BlockIcon
						Robot3DeathIcon = Robot4DeathIcon
						Robot3CollisionIcon = Robot4CollisionIcon
						If R5Present = False Then
							R4Present = False
							RobotTeam(4) = 0
							RobotLeft(4) = -100
							Energy4X.Visible = False
							Damage4X.Visible = False
							Points4X.Visible = False
							Robot4.Text = "No Robot Selected"
							ER(4).Visible = False
							DR(4).Visible = False
							PR4.Visible = False
							R4Icon.Image = Nothing
						Else
							R4path = R5path
							TransferCode(4, 5)
							RobotTeam(4) = RobotTeam(5) : TeamLabel(4).Text = TeamLabel(5).Text : TeamLabel(4).ForeColor = TeamLabel(5).ForeColor
							Energy4X.Text = Energy5X.Text
							Damage4X.Text = Damage5X.Text
							Points4X.Text = Points5X.Text
							Robot4.Text = Robot5.Text
							ER(4).Text = ER(5).Text
							DR(4).Text = DR(5).Text
							PR4.Text = PR5.Text
							R4Icon.Image = R5Icon.Image
							Robot4Energy = Robot5Energy
							Robot4Damage = Robot5Damage
							Robot4Shield = Robot5Shield
							Robot4ProSpeed = Robot5ProSpeed
							Robot4Bullets = Robot5Bullets
							Robot4Probes = Robot5Probes
							Robot4Missiles = Robot5Missiles
							Robot4TacNukes = Robot5TacNukes
							Robot4Hellbores = Robot5Hellbores
							Robot4Drones = Robot5Drones
							Robot4Stunners = Robot5Stunners
							Robot4Mines = Robot5Mines
							Robot4Lasers = Robot5Lasers
							Robot4Turret = Robot5Turret
							Robot4ShieldIcon = Robot5ShieldIcon
							Robot4HitIcon = Robot5HitIcon
							Robot4BlockIcon = Robot5BlockIcon
							Robot4DeathIcon = Robot5DeathIcon
							Robot4CollisionIcon = Robot5CollisionIcon
							If R6Present = False Then
								R5Present = False
								RobotTeam(5) = 0
								RobotLeft(5) = -100
								Energy5X.Visible = False
								Damage5X.Visible = False
								Points5X.Visible = False
								Robot5.Text = "No Robot Selected"
								ER(5).Visible = False
								DR(5).Visible = False
								PR5.Visible = False
								R5Icon.Image = Nothing
							Else
								R5path = R6path
								TransferCode(5, 6)
								RobotTeam(5) = RobotTeam(6) : TeamLabel(5).Text = TeamLabel(6).Text : TeamLabel(5).ForeColor = TeamLabel(6).ForeColor
								Energy5X.Text = Energy6X.Text
								Damage5X.Text = Damage6X.Text
								Points5X.Text = Points6X.Text
								Robot5.Text = Robot6.Text
								ER(5).Text = ER(6).Text
								DR(5).Text = DR(6).Text
								
								PR5.Text = PR6.Text
								R5Icon.Image = R6Icon.Image
								Robot5Energy = Robot6Energy
								Robot5Damage = Robot6Damage
								Robot5Shield = Robot6Shield
								Robot5ProSpeed = Robot6ProSpeed
								Robot5Bullets = Robot6Bullets
								Robot5Probes = Robot6Probes
								Robot5Missiles = Robot6Missiles
								Robot5TacNukes = Robot6TacNukes
								Robot5Hellbores = Robot6Hellbores
								Robot5Drones = Robot6Drones
								Robot5Stunners = Robot6Stunners
								Robot5Mines = Robot6Mines
								Robot5Lasers = Robot6Lasers
								Robot5Turret = Robot6Turret
								Robot5ShieldIcon = Robot6ShieldIcon
								Robot5HitIcon = Robot6HitIcon
								Robot5BlockIcon = Robot6BlockIcon
								Robot5DeathIcon = Robot6DeathIcon
								Robot5CollisionIcon = Robot6CollisionIcon
								
								R6Present = False
								RobotTeam(6) = 0
								RobotLeft(6) = -100
								Energy6X.Visible = False
								Damage6X.Visible = False
								Points6X.Visible = False
								Robot6.Text = "No Robot Selected"
								ER(6).Visible = False
								DR(6).Visible = False
								
								PR6.Visible = False
								R6Icon.Image = Nothing
							End If
						End If
					End If
				End If
		End Select
		
		Load2.Visible = R1Present
		Load3.Visible = R2Present
		Load4.Visible = R3Present
		Load5.Visible = R4Present
		Load6.Visible = R5Present
		
		Dim c As Integer
		For c = 1 To 6 'We set all teamlabels visible or not here. It was way to complicated to transfer. If it's a member of a team it visible, it's as simple as that
			TeamLabel(c).Visible = RobotTeam(c) <> 0
		Next 
		
	End Sub
	
	Private Sub CPRTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CPRTimer.Tick
		
		CPRLabel.Text = CStr(Chronon - CprTimerCount)
		CprTimerCount = Chronon
		CPRLabel.Refresh() 'Snabbar upp!!!!???!!?!
		
	End Sub
	
	Public Sub Debugger_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Debugger.Click
		
		If DebuggedRobot > 6 Or SelectedRobot = -1 Then
			DebuggedRobot = DebuggedRobot \ 10
			
		Else
			If DebuggedRobot <> SelectedRobot Then
				If DebuggedRobot <> 0 Then Image1(DebuggedRobot).Visible = False
				DebuggedRobot = SelectedRobot
				Image1(SelectedRobot).Visible = True
				'InactivateDebug.Checked = False
				DebuggerAutoStart = False
				If HideBattle Then Normal_Click(Normal, New System.EventArgs()) 'disk
			Else
				DebuggedRobot = 0
				Image1(SelectedRobot).Visible = False
				
				If Normal.Checked Then
					Normal_Click(Normal, New System.EventArgs())
				ElseIf Fast.Checked Then 
					Fast_Click(Fast, New System.EventArgs())
				ElseIf AutoRedrawFast.Checked Then 
					AutoRedrawFast_Click(AutoRedrawFast, New System.EventArgs())
				ElseIf Ultra.Checked Then 
					Ultra_Click(Ultra, New System.EventArgs())
				ElseIf Slow.Checked Then 
					Slow_Click(Slow, New System.EventArgs())
				ElseIf Slower.Checked Then 
					Slower_Click(Slower, New System.EventArgs())
				ElseIf Slowest.Checked Then 
					Slowest_Click(Slowest, New System.EventArgs())
				End If
			End If
		End If
		
	End Sub
	
	Public Sub DelateRobot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DelateRobot.Click
		Dim RobotensNamn As String
		Dim FileName As String
		
		Select Case SelectedRobot
			Case 1
				FileName = R1path
				RobotensNamn = Robot1.Text
			Case 2
				FileName = R2path
				RobotensNamn = Robot2.Text
			Case 3
				FileName = R3path
				RobotensNamn = Robot3.Text
			Case 4
				FileName = R4path
				RobotensNamn = Robot4.Text
			Case 5
				FileName = R5path
				RobotensNamn = Robot5.Text
			Case 6
				FileName = R6path
				RobotensNamn = Robot6.Text
			Case Else
				MsgBox("There is no Robot present to delete.", MsgBoxStyle.OKOnly, "No Robot Present")
				Exit Sub
		End Select
		
		If MsgBox("Are you sure you want to delete '" & RobotensNamn & "'?", MsgBoxStyle.YesNo, "Delete") = 7 Then Exit Sub
		
		Kill(FileName)
		
		Close_Renamed_Click(Close_Renamed, New System.EventArgs())
	End Sub
	
	Public Sub Drafting_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drafting.Click
		
		Dim sDup As String
		If SelectedRobot < 1 Then
			MsgBox("Can't show Drafting Board because no robot is selected. To select a robot, use the PageUp and PageDown keys.", MsgBoxStyle.OKOnly, "No Robot Selected")
		Else
			VB6.ShowForm(DraftingBoard, 1, Me)
			
			Select Case SelectedRobot
				Case 1
					sDup = R1path
				Case 2
					sDup = R2path
				Case 3
					sDup = R3path
				Case 4
					sDup = R4path
				Case 5
					sDup = R5path
				Case 6
					sDup = R6path
			End Select
			
			If R1path = sDup Then RefreshCode(R1path, 1)
			If R2path = sDup Then RefreshCode(R2path, 2)
			If R3path = sDup Then RefreshCode(R3path, 3)
			If R4path = sDup Then RefreshCode(R4path, 4)
			If R5path = sDup Then RefreshCode(R5path, 5)
			If R6path = sDup Then RefreshCode(R6path, 6)
		End If
		
	End Sub
	
	Private Sub RefreshCode(ByRef DupPath As String, ByRef DupNr As Integer)
		Dim RNN As Integer ' Reload the code in case it was changed
		Dim InputInsts(4999) As Short
		
		FileOpen(254, DupPath, OpenMode.Binary)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RNN, MCrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, InputInsts, RNN)
		For RNN = 0 To 4999
			MasterCode(DupNr, RNN) = InputInsts(RNN)
			If InputInsts(RNN) = insEND Then Exit For
		Next RNN
		FileClose(254) 'End Reload
	End Sub
	
	Public Sub Duplicate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Duplicate.Click
		Dim DuplicatePath As String
		Dim DuplicateName As String
		Dim DupRobotTeam As Short
		Dim TeamCaption As String
		Dim TeamColor As Integer
		If R1Present = False Then
			MsgBox("No robot present to duplicate.", MsgBoxStyle.OKOnly, "No Robot Present")
		Else
			NotRandomEmergency = False
			DupRobotTeam = RobotTeam(SelectedRobot)
			TeamCaption = TeamLabel(SelectedRobot).Text
			TeamColor = System.Drawing.ColorTranslator.ToOle(TeamLabel(SelectedRobot).ForeColor)
			
			Select Case SelectedRobot
				Case 1
					DuplicatePath = R1path
					DuplicateName = Robot1.Text
				Case 2
					DuplicatePath = R2path
					DuplicateName = Robot2.Text
				Case 3
					DuplicatePath = R3path
					DuplicateName = Robot3.Text
				Case 4
					DuplicatePath = R4path
					DuplicateName = Robot4.Text
				Case 5
					DuplicatePath = R5path
					DuplicateName = Robot5.Text
			End Select
			
			If R2Present = False Then
				R2Present = True
				R2path = DuplicatePath
				Robot2.Text = DuplicateName
				Load3.Visible = True
				RobotTeam(2) = DupRobotTeam
				TeamLabel(2).Text = TeamCaption
				TeamLabel(2).ForeColor = System.Drawing.ColorTranslator.FromOle(TeamColor)
				LoadRobot2()
				Exit Sub
			End If
			
			If R3Present = False Then
				R3Present = True
				R3path = DuplicatePath
				Robot3.Text = DuplicateName
				Load4.Visible = True
				RobotTeam(3) = DupRobotTeam
				TeamLabel(3).Text = TeamCaption
				TeamLabel(3).ForeColor = System.Drawing.ColorTranslator.FromOle(TeamColor)
				LoadRobot3()
				Exit Sub
			End If
			
			If R4Present = False Then
				R4Present = True
				R4path = DuplicatePath
				Robot4.Text = DuplicateName
				Load5.Visible = True
				RobotTeam(4) = DupRobotTeam
				TeamLabel(4).Text = TeamCaption
				TeamLabel(4).ForeColor = System.Drawing.ColorTranslator.FromOle(TeamColor)
				LoadRobot4()
				Exit Sub
			End If
			
			If R5Present = False Then
				R5Present = True
				R5path = DuplicatePath
				Robot5.Text = DuplicateName
				Load6.Visible = True
				RobotTeam(5) = DupRobotTeam
				TeamLabel(5).Text = TeamCaption
				TeamLabel(5).ForeColor = System.Drawing.ColorTranslator.FromOle(TeamColor)
				LoadRobot5()
				Exit Sub
			End If
			
			If R6Present = False Then
				R6Present = True
				R6path = DuplicatePath
				Robot6.Text = DuplicateName
				LoadRobot.Enabled = False
				Duplicate.Enabled = False
				SaveAs.Enabled = False
				RobotTeam(6) = DupRobotTeam
				TeamLabel(6).Text = TeamCaption
				TeamLabel(6).ForeColor = System.Drawing.ColorTranslator.FromOle(TeamColor)
				LoadRobot6()
			End If
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Event MainWindow.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub MainWindow_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Dim Minimized As Object
		Dim Maximized As Object
		Dim YesOrNo As Boolean
		If RunningTournament Then
			
			'UPGRADE_WARNING: Couldn't resolve default property of object Minimized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object Maximized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Select Case Me.WindowState
				Case Normal.Enabled
					YesOrNo = False
					'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					FilePut(7, YesOrNo, 4500)
					WindowMini = False
					TitleTimer.Enabled = False
				Case Maximized
					YesOrNo = True
					'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					FilePut(7, YesOrNo, 4500)
				Case Minimized
					WindowMini = True
					TitleTimer.Enabled = True
			End Select
		End If
	End Sub
	
	Private Sub MainWindow_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_ISSUE: Form property MainWindow.hdc was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If ResolutionChanged = 1 Then ChangeWindow_640X480((Me.hdc))
		End
	End Sub
	
	Public Sub Hardware_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Hardware.Click
		
		If SelectedRobot < 1 Then
			MsgBox("Can't show Hardware Store because no robot is selected. To select a robot, use the PageUp and PageDown keys.", MsgBoxStyle.OKOnly, "No Robot Selected")
		Else
			VB6.ShowForm(HardwareWindow, 1, Me)
		End If
	End Sub
	
	Public Sub Help_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Help.Click
		ShowHelp()
	End Sub
	
	Public Sub History_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles History.Click
		
		If R1Present Then
			HistoryWindow.GenStats.Text = "Number of battles fought: " & HistoryRec(1, 1) & vbLf & "Chronons in last battle: " & HistoryRec(1, 10) & vbLf & "Chronons in all battles: " & HistoryRec(1, 11) & vbLf
			
			HistoryWindow.R1.Text = Robot1.Text
			HistoryWindow.S1.Text = CStr(HistoryRec(1, 4))
			HistoryWindow.TS1.Text = CStr(HistoryRec(1, 5))
			HistoryWindow.PR1.Text = PR1.Text
			HistoryWindow.Image1.Image = R1Icon.Image
			HistoryWindow.Kills1.Text = CStr(HistoryRec(1, 2))
			HistoryWindow.TotalKills1.Text = CStr(HistoryRec(1, 3))
			
			If R2Present Then
				HistoryWindow.R2.Text = Robot2.Text
				HistoryWindow.S2.Text = CStr(HistoryRec(2, 4))
				HistoryWindow.TS2.Text = CStr(HistoryRec(2, 5))
				HistoryWindow.PR2.Text = PR2.Text
				HistoryWindow.Image2.Image = R2Icon.Image
				HistoryWindow.Kills2.Text = CStr(HistoryRec(2, 2))
				HistoryWindow.TotalKills2.Text = CStr(HistoryRec(2, 3))
			End If
			
			If R3Present Then
				HistoryWindow.R3.Text = Robot3.Text
				HistoryWindow.S3.Text = CStr(HistoryRec(3, 4))
				HistoryWindow.TS3.Text = CStr(HistoryRec(3, 5))
				HistoryWindow.PR3.Text = PR3.Text
				HistoryWindow.Image3.Image = R3Icon.Image
				HistoryWindow.Kills3.Text = CStr(HistoryRec(3, 2))
				HistoryWindow.TotalKills3.Text = CStr(HistoryRec(3, 3))
			End If
			
			If R4Present Then
				HistoryWindow.R4.Text = Robot4.Text
				HistoryWindow.S4.Text = CStr(HistoryRec(4, 4))
				HistoryWindow.TS4.Text = CStr(HistoryRec(4, 5))
				HistoryWindow.PR4.Text = PR4.Text
				HistoryWindow.Image4.Image = R4Icon.Image
				HistoryWindow.Kills4.Text = CStr(HistoryRec(4, 2))
				HistoryWindow.TotalKills4.Text = CStr(HistoryRec(4, 3))
			End If
			
			If R5Present Then
				HistoryWindow.R5.Text = Robot5.Text
				HistoryWindow.S5.Text = CStr(HistoryRec(5, 4))
				HistoryWindow.TS5.Text = CStr(HistoryRec(5, 5))
				HistoryWindow.PR5.Text = PR5.Text
				HistoryWindow.Image5.Image = R5Icon.Image
				HistoryWindow.Kills5.Text = CStr(HistoryRec(5, 2))
				HistoryWindow.TotalKills5.Text = CStr(HistoryRec(5, 3))
			End If
			
			If R6Present Then
				HistoryWindow.R6.Text = Robot6.Text
				HistoryWindow.S6.Text = CStr(HistoryRec(6, 4))
				HistoryWindow.TS6.Text = CStr(HistoryRec(6, 5))
				HistoryWindow.PR6.Text = PR6.Text
				HistoryWindow.Image6.Image = R6Icon.Image
				HistoryWindow.Kills6.Text = CStr(HistoryRec(6, 2))
				HistoryWindow.TotalKills6.Text = CStr(HistoryRec(6, 3))
			End If
			
			HistoryWindow.ShowDialog()
		Else
			MsgBox("To load a robot, choose 'Load Robot' from the file menu.",  , "No Robot Loaded")
		End If
		
	End Sub
	
	Public Sub Icon_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Icon_Renamed.Click
		
		If SelectedRobot < 1 Then
			MsgBox("Can't show Icon Factory because no robot is selected. To select a robot, use the PageUp and PageDown keys.", MsgBoxStyle.OKOnly, "No Robot Selected")
		Else
			VB6.ShowForm(ChooseIcon, 1, Me)
		End If
		
	End Sub
	
	Public Sub InactivateDebug_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles InactivateDebug.Click
		InactivateDebug.Checked = Not InactivateDebug.Checked
	End Sub
	
	Public Sub KnownBugs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles KnownBugs.Click
		Dim ErMsg As String
		'ErMsg = ErMsg & vbtab & "Pearl doens't survive as long as it does in the mac version."
		
		'ErMsg = ErMsg & vbcr & vbcr & vbtab & "Sounds bugs out if they're enabled and battlespeed is above ~50 chronons per sec."
		
		'ErMsg = ErMsg & vbcr & vbcr & vbtab & "Have you ever seen that Japanese movie 'Ringu'? There was this girl who could "
		'ErMsg = ErMsg & vbcr & vbtab & "wish people dead. Robots can do that too sometimes."
		'ErMsg = ErMsg & vbcr & vbcr & "Unconfirmed:"
		
		'ErMsg = ErMsg & vbcr & vbcr & "I'm not sure if the last two exists or not. Range got all better since I fixed the collision system" '& vbcr
		'ErMsg = ErMsg & vbcr & "and the 'Ringu-bug' is very rare." '& vbcr
		
		ErMsg = "Drones don't behave as in the Mac version." & vbCr & vbCr & "Drones are also EXTREME slowdowners. Battles with 6 Carne can slow down below" & vbCr & "700 Chronons per second, even on fast computers."
		
		ErMsg = ErMsg & vbCr & vbCr & "Left' Right' Top' and Bot' interupps aren't triggered by movex' and movey'."
		
		'ErMsg = ErMsg & vbcr & vbcr & vbtab & "Robots can jump over shots with movex and movey."    'Kan den i Mac versionen med
		ErMsg = ErMsg & vbCr & vbCr & "The Turret Shapes doesn't look like they do in the Mac version."
		
		ErMsg = ErMsg & vbCr & vbCr & "The Interupts system can misbehave under extreme pressure."
		
		'ErMsg = ErMsg & vbCr & vbCr & "Here a list of features that doesn't exist yet:" & vbcr _
		''             & vbTab & "Some things I've forgot to list here."
		'Den 16:onde Juli, klockan 01:57 blev denna lista tom. Precis alltig som finns i Mac versionen finns i Windows versionen.
		
		MsgBox(ErMsg, MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "Know Bugs")
		
	End Sub
	
	Private Sub Load1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Load1.Click
		NotRandomEmergency = False
		
		Dim NameVar1 As String '-:-
		Dim namevar2 As Integer '-:-
		
		If BattleHaltButton.Text = "Halt" Then Exit Sub 'If there's an ongoing battle, do nothing
		
		CommonDialog1Open.ShowDialog() 'Shows the Open dialog by using Comdlg32.ocx, the dialog pops up, no problem with that
		If CommonDialog1Open.FileName = "" Then Exit Sub 'It the user has clicked cancel, then do nothing
		
		If CommonDialog1Open.InitialDirectory <> "" Then
			CommonDialog1Open.InitialDirectory = ""
		End If 'Nytt
		
		Load2.Visible = True
		
		R1path = CommonDialog1Open.FileName 'Sets the global variable R1Path
		
		'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		NameVar1 = CommonDialog1Open.FileName
		namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
		Robot1.Text = VB.Left(NameVar1, namevar2) 'Replaces the caption 'No Robot Selected' with the robots name
		
		R1Present = True 'Sets the global variable R1Present
		
		If SelectedRobot > 6 Or SelectedRobot < 1 Then 'Selects the recently opened robot, if there's no other robot selected
			SelectedRobot = 1
			Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
		End If
		
		CommonDialog1Open.FileName = "" 'Resets the file name, so cancel will work
		
		LoadRobot1() 'A huge subroutine that loads hardware, icon and icon settings
		If Not Replaying Then ResetHistory_Click(ResetHistory, New System.EventArgs()) 'Another sub routine that erases the history of previous battles
	End Sub
	Private Sub Load2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Load2.Click
		NotRandomEmergency = False
		
		Dim NameVar1 As String '-:-
		Dim namevar2 As Integer '-:-
		
		If BattleHaltButton.Text = "Halt" Then Exit Sub
		If Me.Visible = False Then Exit Sub
		
		CommonDialog1Open.ShowDialog()
		If CommonDialog1Open.FileName = "" Then Exit Sub
		
		If CommonDialog1Open.InitialDirectory <> "" Then
			CommonDialog1Open.InitialDirectory = ""
		End If 'Nytt
		
		Load3.Visible = True
		
		R2path = CommonDialog1Open.FileName
		
		'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		NameVar1 = CommonDialog1Open.FileName 'Tar bort .RWR från namnet
		namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
		Robot2.Text = VB.Left(NameVar1, namevar2)
		
		R2Present = True
		
		'SelectedRobot = 2
		'Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = vbBlack: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
		CommonDialog1Open.FileName = ""
		
		LoadRobot2()
		If Not Replaying Then ResetHistory_Click(ResetHistory, New System.EventArgs())
	End Sub
	Private Sub Load3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Load3.Click
		NotRandomEmergency = False
		
		Dim NameVar1 As String '-:-
		Dim namevar2 As Integer '-:-
		
		If BattleHaltButton.Text = "Halt" Then Exit Sub
		If Me.Visible = False Then Exit Sub
		
		CommonDialog1Open.ShowDialog()
		If CommonDialog1Open.FileName = "" Then Exit Sub
		
		If CommonDialog1Open.InitialDirectory <> "" Then
			CommonDialog1Open.InitialDirectory = ""
		End If 'Nytt
		
		Load4.Visible = True
		
		R3path = CommonDialog1Open.FileName
		
		'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		NameVar1 = CommonDialog1Open.FileName 'Tar bort .RWR från namnet
		namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
		Robot3.Text = VB.Left(NameVar1, namevar2)
		
		R3Present = True
		
		'SelectedRobot = 3
		'Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = vbBlack: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
		CommonDialog1Open.FileName = ""
		
		LoadRobot3()
		If Not Replaying Then ResetHistory_Click(ResetHistory, New System.EventArgs())
	End Sub
	Private Sub Load4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Load4.Click
		NotRandomEmergency = False
		
		Dim NameVar1 As String '-:-
		Dim namevar2 As Integer '-:-
		
		If BattleHaltButton.Text = "Halt" Then Exit Sub
		If Me.Visible = False Then Exit Sub
		
		CommonDialog1Open.ShowDialog()
		If CommonDialog1Open.FileName = "" Then Exit Sub
		
		If CommonDialog1Open.InitialDirectory <> "" Then
			CommonDialog1Open.InitialDirectory = ""
		End If 'Nytt
		
		Load5.Visible = True
		
		R4path = CommonDialog1Open.FileName
		
		'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		NameVar1 = CommonDialog1Open.FileName 'Tar bort .RWR från namnet
		namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
		Robot4.Text = VB.Left(NameVar1, namevar2)
		
		R4Present = True
		
		'SelectedRobot = 4
		'Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = vbBlack: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
		CommonDialog1Open.FileName = ""
		
		LoadRobot4()
		If Not Replaying Then ResetHistory_Click(ResetHistory, New System.EventArgs())
	End Sub
	Private Sub Load5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Load5.Click
		NotRandomEmergency = False
		
		Dim NameVar1 As String '-:-
		Dim namevar2 As Integer '-:-
		
		If BattleHaltButton.Text = "Halt" Then Exit Sub
		If Me.Visible = False Then Exit Sub
		
		CommonDialog1Open.ShowDialog()
		If CommonDialog1Open.FileName = "" Then Exit Sub
		
		If CommonDialog1Open.InitialDirectory <> "" Then
			CommonDialog1Open.InitialDirectory = ""
		End If 'Nytt
		
		Load6.Visible = True
		
		R5path = CommonDialog1Open.FileName
		
		'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		NameVar1 = CommonDialog1Open.FileName 'Tar bort .RWR från namnet
		namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
		Robot5.Text = VB.Left(NameVar1, namevar2)
		
		R5Present = True
		
		'SelectedRobot = 5
		'Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = vbBlack: Robot5.ForeColor = vbWhite: Robot6.BackColor = BackgroundColor: Robot6.ForeColor = vbWhite
		CommonDialog1Open.FileName = ""
		LoadRobot5()
		If Not Replaying Then ResetHistory_Click(ResetHistory, New System.EventArgs())
	End Sub
	Private Sub Load6_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Load6.Click
		NotRandomEmergency = False
		
		Dim NameVar1 As String '-:-
		Dim namevar2 As Integer '-:-
		
		If BattleHaltButton.Text = "Halt" Then Exit Sub
		If Me.Visible = False Then Exit Sub
		
		CommonDialog1Open.ShowDialog()
		If CommonDialog1Open.FileName = "" Then Exit Sub
		
		If CommonDialog1Open.InitialDirectory <> "" Then
			CommonDialog1Open.InitialDirectory = ""
		End If 'Nytt
		
		R6path = CommonDialog1Open.FileName
		
		'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		NameVar1 = CommonDialog1Open.FileName 'Tar bort .RWR från namnet
		namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
		Robot6.Text = VB.Left(NameVar1, namevar2)
		
		R6Present = True
		
		'SelectedRobot = 6
		'Robot1.BackColor = BackgroundColor: Robot1.ForeColor = vbWhite: Robot2.BackColor = BackgroundColor: Robot2.ForeColor = vbWhite: Robot3.BackColor = BackgroundColor: Robot3.ForeColor = vbWhite: Robot4.BackColor = BackgroundColor: Robot4.ForeColor = vbWhite: Robot5.BackColor = BackgroundColor: Robot5.ForeColor = vbWhite: Robot6.BackColor = vbBlack: Robot6.ForeColor = vbWhite
		CommonDialog1Open.FileName = ""
		
		NewRobot.Enabled = False
		LoadRobot.Enabled = False
		Duplicate.Enabled = False
		SaveAs.Enabled = False
		
		LoadRobot6()
		If Not Replaying Then ResetHistory_Click(ResetHistory, New System.EventArgs())
	End Sub
	
	Public Sub ChronorsLimit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ChronorsLimit.Click
		Dim YesOrNo As Boolean
		
		If ChronorsLimit.Checked = False Then
			ChronorsLimit.Checked = True
			MaxChronon = 1500
			YesOrNo = True
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, YesOrNo, 3000)
		Else
			ChronorsLimit.Checked = False
			MaxChronon = -1
			YesOrNo = False
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, YesOrNo, 3000)
		End If
	End Sub
	
	Public Sub MoveAndShoot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MoveAndShoot.Click
		Dim YesOrNo As Boolean
		
		If MoveAndShoot.Checked = False Then
			MoveAndShoot.Checked = True
			YesOrNo = True
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, YesOrNo, 5000)
		Else
			MoveAndShoot.Checked = False
			YesOrNo = False
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, YesOrNo, 5000)
		End If
		
		MoveAndShotAllowed = Not MoveAndShoot.Checked
	End Sub
	
	Public Sub NewRobot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NewRobot.Click
		NotRandomEmergency = False
		
		Dim NameVar1 As String '-:-
		Dim namevar2 As Integer '-:-
		
		On Error GoTo OpenNoMoreRobot
		
		CommonDialog3Save.ShowDialog()
		
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If Dir(CommonDialog3Save.FileName) <> "" Then
			'UPGRADE_WARNING: CommonDialog property CommonDialog3.FileTitle was upgraded to CommonDialog3.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			If MsgBox("Do you want to replace " & CommonDialog3Save.FileName & "?", MsgBoxStyle.OKCancel, "Robot already exists") = MsgBoxResult.Cancel Then Exit Sub
		End If
		
		FileCopy(My.Application.Info.DirectoryPath & "\miscdata\Standard.RWR", CommonDialog3Save.FileName)
		
		'Hämtat från Loadrobot
		If R1Present = False Then
			'UPGRADE_WARNING: CommonDialog property CommonDialog3.FileTitle was upgraded to CommonDialog3.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog3Save.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot1.Text = VB.Left(NameVar1, namevar2)
			
			R1Present = True
			R1path = CommonDialog3Save.FileName
			Load2.Visible = True
			
			LoadRobot1()
			Exit Sub
		ElseIf R2Present = False Then 
			'UPGRADE_WARNING: CommonDialog property CommonDialog3.FileTitle was upgraded to CommonDialog3.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog3Save.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot2.Text = VB.Left(NameVar1, namevar2)
			
			R2Present = True
			R2path = CommonDialog3Save.FileName
			Load2.Visible = True
			Load3.Visible = True
			
			LoadRobot2()
		ElseIf R3Present = False Then 
			'UPGRADE_WARNING: CommonDialog property CommonDialog3.FileTitle was upgraded to CommonDialog3.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog3Save.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot3.Text = VB.Left(NameVar1, namevar2)
			
			R3Present = True
			R3path = CommonDialog3Save.FileName
			Load3.Visible = True
			Load4.Visible = True
			
			LoadRobot3()
		ElseIf R4Present = False Then 
			'UPGRADE_WARNING: CommonDialog property CommonDialog3.FileTitle was upgraded to CommonDialog3.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog3Save.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot4.Text = VB.Left(NameVar1, namevar2)
			
			R4Present = True
			R4path = CommonDialog3Save.FileName
			Load4.Visible = True
			Load5.Visible = True
			
			LoadRobot4()
		ElseIf R5Present = False Then 
			'UPGRADE_WARNING: CommonDialog property CommonDialog3.FileTitle was upgraded to CommonDialog3.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog3Save.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot5.Text = VB.Left(NameVar1, namevar2)
			
			R5Present = True
			R5path = CommonDialog3Save.FileName
			Load5.Visible = True
			Load6.Visible = True
			
			LoadRobot5()
		ElseIf R6Present = False Then 
			'UPGRADE_WARNING: CommonDialog property CommonDialog3.FileTitle was upgraded to CommonDialog3.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog3Save.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot6.Text = VB.Left(NameVar1, namevar2)
			
			R6Present = True
			R6path = CommonDialog3Save.FileName
			Load6.Visible = True
			
			NewRobot.Enabled = False
			LoadRobot.Enabled = False
			Duplicate.Enabled = False
			SaveAs.Enabled = False
			
			LoadRobot6()
		End If
		
OpenNoMoreRobot: 
	End Sub
	
	Public Sub NoTeam_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NoTeam.Click
		If SelectedRobot >= 1 Then
			RobotTeam(SelectedRobot) = 0
			TeamLabel(SelectedRobot).Visible = False
		End If
	End Sub
	
	Public Sub Overloading_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Overloading.Click
		Dim YesOrNo As Boolean
		
		If Overloading.Checked = False Then
			Overloading.Checked = True
			YesOrNo = True
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, YesOrNo, 6000)
		Else
			Overloading.Checked = False
			YesOrNo = False
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, YesOrNo, 6000)
		End If
		
		EnableOverloading = Not YesOrNo
	End Sub
	
	Public Sub Password_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Password.Click
		MsgBox("This feuture doesn't work yet." & vbCr & "I'm not sure if I'll ever implement it, since passwords are removed in the lastest mac version.", MsgBoxStyle.OKOnly, "Sorry")
	End Sub
	
	Public Sub Quit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Quit.Click
		'UPGRADE_ISSUE: Form property MainWindow.hdc was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If ResolutionChanged = 1 Then ChangeWindow_640X480((Me.hdc))
		End
	End Sub
	
	Private Sub R1Icon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles R1Icon.Click
		Robot1_Click(Robot1, New System.EventArgs())
		If RunningTournament Then StopTournament.Focus() Else BattleHaltButton.Focus()
	End Sub
	
	Private Sub R2Icon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles R2Icon.Click
		Robot2_Click(Robot2, New System.EventArgs())
		If RunningTournament Then StopTournament.Focus() Else BattleHaltButton.Focus()
	End Sub
	
	Private Sub R3Icon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles R3Icon.Click
		Robot3_Click(Robot3, New System.EventArgs())
		If RunningTournament Then StopTournament.Focus() Else BattleHaltButton.Focus()
	End Sub
	
	Private Sub R4Icon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles R4Icon.Click
		Robot4_Click(Robot4, New System.EventArgs())
		If RunningTournament Then StopTournament.Focus() Else BattleHaltButton.Focus()
	End Sub
	
	Private Sub R5Icon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles R5Icon.Click
		Robot5_Click(Robot5, New System.EventArgs())
		If RunningTournament Then StopTournament.Focus() Else BattleHaltButton.Focus()
	End Sub
	
	Private Sub R6Icon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles R6Icon.Click
		Robot6_Click(Robot6, New System.EventArgs())
		If RunningTournament Then StopTournament.Focus() Else BattleHaltButton.Focus()
	End Sub
	
	'UPGRADE_ISSUE: PictureBox event R1Icon.GotFocus was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub R1Icon_GotFocus()
		If RunningTournament Then
			StopTournament.Focus()
		Else
			BattleHaltButton.Focus()
			BattleHaltButton_KeyDown(BattleHaltButton, New System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.PageUp Or 0 * &H10000))
		End If
	End Sub
	
	'UPGRADE_ISSUE: PictureBox event R2Icon.GotFocus was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub R2Icon_GotFocus()
		If RunningTournament Then
			StopTournament.Focus()
		Else
			BattleHaltButton.Focus()
			BattleHaltButton_KeyDown(BattleHaltButton, New System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.PageDown Or 0 * &H10000))
		End If
	End Sub
	
	Public Sub RenameRobot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RenameRobot.Click
		Dim Name1plusRWR, Name1, ThePath, Name2, Name2plusRWR As String
		Dim Remove As Integer
		
		Select Case SelectedRobot
			Case 1
				Name1 = Robot1.Text
				ThePath = R1path
			Case 2
				Name1 = Robot2.Text
				ThePath = R2path
			Case 3
				Name1 = Robot3.Text
				ThePath = R3path
			Case 4
				Name1 = Robot4.Text
				ThePath = R4path
			Case 5
				Name1 = Robot5.Text
				ThePath = R5path
			Case 6
				Name1 = Robot6.Text
				ThePath = R6path
			Case Else
				MsgBox("There is no robot present to rename.",  , "Can't rename")
				Exit Sub
		End Select
		
		Remove = Len(ThePath) - Len(Name1) - 4
		ThePath = VB.Left(ThePath, Remove)
		
Retry: 
		Name2 = InputBox("Please enter the new name for '" & Name1 & "'.",  , Name1, VB6.TwipsToPixelsX(100), VB6.TwipsToPixelsY(100))
		
		Dim ans As Integer
		If Name2 = "" Then
			Exit Sub
		ElseIf InStr(Name2, "?") Or InStr(Name2, "/") Or InStr(Name2, "\") Or InStr(Name2, ":") Or InStr(Name2, "*") Or InStr(Name2, "*") Or InStr(Name2, Chr(34)) Then 
			ans = MsgBox("The name you've specified contain a character that Windows doesn't allow to be used in filenames." & vbNewLine & "The following characters can't be used: ? / \ : * " & Chr(34), MsgBoxStyle.RetryCancel, "Illegal character in the new file name")
			If ans = MsgBoxResult.Retry Then GoTo Retry Else Exit Sub
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		ElseIf Dir(Name2 & ".RWR") <> "" And UCase(Name1) <> UCase(Name2) Then 
			If MsgBox("Do you want to replace " & Name2 & "?", MsgBoxStyle.OKCancel, "Robot already exists") = MsgBoxResult.Cancel Then Exit Sub Else Kill(Name2 & ".RWR")
		End If
		
		Name1plusRWR = ThePath & Name1 & ".RWR"
		Name2plusRWR = ThePath & Name2 & ".RWR"
		Rename(Name1plusRWR, Name2plusRWR)
		
		Select Case SelectedRobot
			Case 1
				Robot1.Text = Name2
				R1path = Name2plusRWR
			Case 2
				Robot2.Text = Name2
				R2path = Name2plusRWR
			Case 3
				Robot3.Text = Name2
				R3path = Name2plusRWR
			Case 4
				Robot4.Text = Name2
				R4path = Name2plusRWR
			Case 5
				Robot5.Text = Name2
				R5path = Name2plusRWR
			Case 6
				R6path = Name2plusRWR
				Robot6.Text = Name2
		End Select
		
	End Sub
	
	Public Sub RepeatBattle_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RepeatBattle.Click
		If Replaying And StartDebuggerAt >= 0 Then StartDebuggerAt = DEBUGATNOTSET 'Disable start debug at
		
		Replaying = Not (Replaying)
		RepeatBattle.Checked = Replaying
		
		Dim counter As Integer
		If LastStartPosX(1) = 0 Then
			
			For counter = 1 To 6
				LastStartPosX(counter) = System.Math.Round((268 * Rnd()) + 8) 'Int
				LastStartPosY(counter) = System.Math.Round((268 * Rnd()) + 8)
			Next counter
		End If
		
		ReplayText.Visible = Replaying
	End Sub
	
	Public Sub ResetHistory_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ResetHistory.Click
		PR1.Text = CStr(0)
		PR2.Text = CStr(0)
		PR3.Text = CStr(0)
		PR4.Text = CStr(0)
		PR5.Text = CStr(0)
		PR6.Text = CStr(0)
		
		Dim counter As Integer
		For counter = 1 To 50
			HistoryRec(1, counter) = 0
			HistoryRec(2, counter) = 0
			HistoryRec(3, counter) = 0
			HistoryRec(4, counter) = 0
			HistoryRec(5, counter) = 0
			HistoryRec(6, counter) = 0
		Next counter
		
	End Sub
	
	Public Sub resolution_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles resolution.Click
		Dim YesOrNo As Boolean
		
		If resolution.Checked = False Then
			resolution.Checked = True
			YesOrNo = True
		Else
			resolution.Checked = False
			YesOrNo = False
		End If
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, YesOrNo, 12000)
	End Sub
	
	Private Sub Robot2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Robot2.Click
		If R2Present Then
			SelectedRobot = 2
			
			Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White
			Robot2.BackColor = System.Drawing.Color.Black : Robot2.ForeColor = System.Drawing.Color.White
			Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White
			Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White
			Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White
			Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
		End If
	End Sub
	
	Private Sub Robot1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Robot1.Click
		If R1Present Then
			SelectedRobot = 1
			
			Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White
			Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White
			Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White
			Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White
			Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White
			Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
		End If
	End Sub
	
	Private Sub Robot6_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Robot6.Click
		If R6Present Then
			SelectedRobot = 6
			
			Robot6.BackColor = System.Drawing.Color.Black : Robot6.ForeColor = System.Drawing.Color.White
			Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White
			Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White
			Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White
			Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White
			Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White
		End If
	End Sub
	
	Private Sub Robot4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Robot4.Click
		If R4Present Then
			SelectedRobot = 4
			
			Robot4.BackColor = System.Drawing.Color.Black : Robot4.ForeColor = System.Drawing.Color.White
			Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White
			Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White
			Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White
			Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White
			Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
		End If
	End Sub
	
	Private Sub Robot5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Robot5.Click
		If R5Present Then
			SelectedRobot = 5
			
			Robot5.BackColor = System.Drawing.Color.Black : Robot5.ForeColor = System.Drawing.Color.White
			Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White
			Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White
			Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White
			Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White
			Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
		End If
	End Sub
	
	Private Sub Robot3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Robot3.Click
		If R3Present Then
			SelectedRobot = 3
			
			Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White
			Robot3.BackColor = System.Drawing.Color.Black : Robot3.ForeColor = System.Drawing.Color.White
			Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White
			Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White
			Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White
			Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
		End If
	End Sub
	
	Public Sub SaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SaveAs.Click
		NotRandomEmergency = False
		
		On Error GoTo didcancel
		
		If SelectedRobot < 1 Then
			MsgBox("There is no Robot present as source.", MsgBoxStyle.OKOnly, "No Robot Present")
			Exit Sub
		End If
		
		CommonDialog3Save.ShowDialog()
		
		If CommonDialog3Save.FileName = "" Then
			Exit Sub
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		ElseIf Dir(CommonDialog3Save.FileName) <> "" Then 
			'UPGRADE_WARNING: CommonDialog property CommonDialog3.FileTitle was upgraded to CommonDialog3.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			If MsgBox("Do you want to replace " & CommonDialog3Save.FileName & "?", MsgBoxStyle.OKCancel, "Robot already exists") = MsgBoxResult.Cancel Then Exit Sub
		End If
		
		Dim Source As String
		Dim Target As String
		Dim FreeRobot As Integer
		Dim NameVar1 As String
		Dim namevar2 As Integer
		
		Target = CommonDialog3Save.FileName
		
		Select Case SelectedRobot
			Case 1
				Source = R1path
			Case 2
				Source = R2path
			Case 3
				Source = R3path
			Case 4
				Source = R4path
			Case 5
				Source = R5path
			Case 6
				Source = R6path
		End Select
		
		FileCopy(Source, Target)
		Duplicate_Click(Duplicate, New System.EventArgs())
		FreeRobot = -(CShort(R2Present) + CShort(R3Present) + CShort(R4Present) + CShort(R5Present) + CShort(R6Present) - 1)
		
		'UPGRADE_WARNING: CommonDialog property CommonDialog3.FileTitle was upgraded to CommonDialog3.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		NameVar1 = CommonDialog3Save.FileName 'Tar bort .RWR från namnet
		namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
		NameVar1 = VB.Left(NameVar1, namevar2)
		
		Select Case FreeRobot
			Case 2
				R2path = Target
				Robot2.Text = NameVar1
			Case 3
				R3path = Target
				Robot3.Text = NameVar1
			Case 4
				R4path = Target
				Robot4.Text = NameVar1
			Case 5
				R5path = Target
				Robot5.Text = NameVar1
			Case 6
				R6path = Target
				Robot6.Text = NameVar1
		End Select
		
didcancel: 
	End Sub
	
	Public Sub Scoring_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Scoring.Click
		If Scoring.Text = "Scoring: Standard" Then
			Scoring.Text = "Scoring: Mac (4.5.2)"
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, True, 2500)
			StandardScoring = False
		Else
			Scoring.Text = "Scoring: Standard"
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, False, 2500)
			StandardScoring = True
		End If
		
	End Sub
	
	Public Sub SetGameSpeed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SetGameSpeed.Click
		'TheSpeedConstant = 1
		
RepeatSpeed: 
		On Error GoTo TooHigh
		
		Dim res As Object
		
		'UPGRADE_WARNING: Couldn't resolve default property of object res. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		res = InputBox("Please type the in how fast you would like the game running (relative value). Standard = 100." & vbCr & vbCr & "Will only affect the game when Normal, Slower or Slowest is chosen.", "Set Speed", CStr((1 / TheSpeedConstant) * 100))
		'UPGRADE_WARNING: Couldn't resolve default property of object res. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If res = "" Then Exit Sub
		
		'UPGRADE_WARNING: Couldn't resolve default property of object res. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IsNumeric(res) And res > 0 And res <= 2000000000 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object res. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TheSpeedConstant = res / 100
			TheSpeedConstant = 1 / TheSpeedConstant
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, TheSpeedConstant, 12500)
			If Normal.Checked Then
				Normal_Click(Normal, New System.EventArgs())
			ElseIf Slow.Checked Then 
				Slow_Click(Slow, New System.EventArgs())
			ElseIf Slower.Checked Then 
				Slower_Click(Slower, New System.EventArgs())
			ElseIf Slowest.Checked Then 
				Slowest_Click(Slowest, New System.EventArgs())
			End If
		Else
			If MsgBox("Invalid value entered. Highest allowed is 2 000 000 000. Would you like to try again?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then GoTo RepeatSpeed
		End If
		
TooHigh: 
		If Err.Number <> 0 Then
			If MsgBox("Invalid value entered. Highest allowed is 2 000 000 000. Would you like to try again?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Resume RepeatSpeed
		End If
		
	End Sub
	
	Public Sub ShowMoveAndShoot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ShowMoveAndShoot.Click
		ShowMoveAndShoot.Checked = Not ShowMoveAndShoot.Checked
		'Put 7, 6500, ShowMoveAndShoot.Checked
	End Sub
	
	Public Sub Slow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Slow.Click
		Slow.Checked = True
		Slower.Checked = False
		Slowest.Checked = False
		Normal.Checked = False
		Fast.Checked = False
		NoDisplay.Checked = False
		AutoRedrawFast.Checked = False 'ny
		Ultra.Checked = False
		HideBattle = False
		
		Dim RSpeed As Integer 'Speed
		RSpeed = 3
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, RSpeed, 11000)
		
		BattleSpeed = (1 / 30) * TheSpeedConstant
		
		'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = True
		If Sounds.Checked Then PlaySounds = True
		
		Sounds.Enabled = True
		'UPGRADE_ISSUE: PictureBox property Arena.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.AutoRedraw = True
	End Sub
	
	Public Sub Slower_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Slower.Click
		Slow.Checked = False
		Slower.Checked = True
		Slowest.Checked = False
		Normal.Checked = False
		Fast.Checked = False
		NoDisplay.Checked = False
		AutoRedrawFast.Checked = False 'ny
		Ultra.Checked = False
		HideBattle = False
		
		Dim RSpeed As Integer 'Speed
		RSpeed = 2
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, RSpeed, 11000)
		
		BattleSpeed = (1 / 12) * TheSpeedConstant
		
		'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = True
		If Sounds.Checked Then PlaySounds = True
		
		Sounds.Enabled = True
		'UPGRADE_ISSUE: PictureBox property Arena.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.AutoRedraw = True
	End Sub
	Public Sub Slowest_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Slowest.Click
		Slow.Checked = False
		Slower.Checked = False
		Slowest.Checked = True
		Normal.Checked = False
		Fast.Checked = False
		NoDisplay.Checked = False
		AutoRedrawFast.Checked = False 'ny
		Ultra.Checked = False
		HideBattle = False
		
		Dim RSpeed As Integer 'Speed
		RSpeed = 1
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, RSpeed, 11000)
		
		BattleSpeed = 0.5 * TheSpeedConstant
		
		'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = True
		If Sounds.Checked Then PlaySounds = True
		
		Sounds.Enabled = True
		'UPGRADE_ISSUE: PictureBox property Arena.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.AutoRedraw = True
	End Sub
	Public Sub Normal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Normal.Click
		Slow.Checked = False
		Slower.Checked = False
		Slowest.Checked = False
		Normal.Checked = True
		Fast.Checked = False
		NoDisplay.Checked = False
		AutoRedrawFast.Checked = False 'ny
		Ultra.Checked = False
		HideBattle = False
		
		Dim RSpeed As Integer 'Speed
		RSpeed = 4
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, RSpeed, 11000)
		
		BattleSpeed = (1 / 70) * TheSpeedConstant
		
		'If AutoNoSound.Checked And Sounds.Checked Then
		'    PlaySounds = True
		'End If
		If Sounds.Checked Then PlaySounds = True
		
		Sounds.Enabled = True
		'UPGRADE_ISSUE: PictureBox property Arena.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.AutoRedraw = True
	End Sub
	
	Public Sub Fast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Fast.Click
		Slow.Checked = False
		Slower.Checked = False
		Slowest.Checked = False
		Normal.Checked = False
		Fast.Checked = True
		NoDisplay.Checked = False
		Ultra.Checked = False
		AutoRedrawFast.Checked = False 'ny
		HideBattle = False
		
		Dim RSpeed As Integer 'Speed
		RSpeed = 5
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, RSpeed, 11000)
		BattleSpeed = 1E-37
		
		'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = False
		'
		'If AutoNoSound.Checked Then Sounds.Enabled = False
		PlaySounds = False
		Sounds.Enabled = False
		
		Arena.Image = Nothing
		
		'UPGRADE_ISSUE: PictureBox property Arena.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.AutoRedraw = False
	End Sub
	
	Public Sub AutoRedrawFast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AutoRedrawFast.Click
		Slow.Checked = False
		Slower.Checked = False
		Slowest.Checked = False
		Normal.Checked = False
		Fast.Checked = False
		AutoRedrawFast.Checked = True
		NoDisplay.Checked = False
		Ultra.Checked = False
		HideBattle = False
		
		Dim RSpeed As Integer 'Speed
		RSpeed = 6
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, RSpeed, 11000)
		
		BattleSpeed = 1E-37
		
		'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = False
		'If AutoNoSound.Checked Then Sounds.Enabled = False
		PlaySounds = False
		Sounds.Enabled = False
		
		'UPGRADE_ISSUE: PictureBox property Arena.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.AutoRedraw = True
	End Sub
	
	Public Sub NoDisplay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NoDisplay.Click
		Slow.Checked = False
		Slower.Checked = False
		Slowest.Checked = False
		Normal.Checked = False
		Fast.Checked = False
		NoDisplay.Checked = True
		Ultra.Checked = False
		AutoRedrawFast.Checked = False 'ny
		HideBattle = True
		
		Dim RSpeed As Integer 'Speed
		RSpeed = 7
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(7, RSpeed, 11000)
		BattleSpeed = 1E-37
		
		'If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = False
		'If AutoNoSound.Checked Then Sounds.Enabled = False
		PlaySounds = False
		Sounds.Enabled = False
		
		Arena.Image = Nothing
		'UPGRADE_ISSUE: PictureBox property Arena.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.AutoRedraw = False
	End Sub
	
	Public Sub Ultra_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ultra.Click
		Dim res As Short
		
		If UltraWarning <> 250 Then
			res = MsgBox("The Ultra Speed Mode (Fastest) will drain time from Windows (and other programs) to RoboWar." & "This means playing mp3 in the background or surfing internet might not work while on ultra. Are you sure " & "you want to enable ultra?" & vbCr & vbCr & "(If you don't want to see this message again, press Cancel.)", MsgBoxStyle.YesNoCancel, "Enable Ultra?")
		End If
		
		Dim RSpeed As Integer 'Speed
		If res = MsgBoxResult.Yes Or res = MsgBoxResult.Cancel Or res = 0 Then
			Slow.Checked = False
			Slower.Checked = False
			Slowest.Checked = False
			Normal.Checked = False
			Fast.Checked = False
			NoDisplay.Checked = False
			Ultra.Checked = True
			AutoRedrawFast.Checked = False 'ny
			HideBattle = True
			
			RSpeed = 8
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, RSpeed, 11000)
			BattleSpeed = 1E-37
			
			'        If AutoNoSound.Checked And Sounds.Checked Then PlaySounds = False
			'        If AutoNoSound.Checked Then Sounds.Enabled = False
			PlaySounds = False
			Sounds.Enabled = False
			
			Arena.Image = Nothing
			'UPGRADE_ISSUE: PictureBox property Arena.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			Arena.AutoRedraw = False
			
			If res = MsgBoxResult.Cancel Then
				UltraWarning = 250
				'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FilePut(7, UltraWarning, 7500)
			End If
		End If
	End Sub
	
	Public Sub Sounds_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Sounds.Click
		Dim YesOrNo As Boolean
		
		If Sounds.Checked Then
			Sounds.Checked = False
			YesOrNo = False
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, YesOrNo, 1000)
			PlaySounds = False
		Else
			Sounds.Checked = True
			YesOrNo = True
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, YesOrNo, 1000)
			PlaySounds = True
		End If
		
	End Sub
	
	Public Sub LoadRobot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LoadRobot.Click
		NotRandomEmergency = False
		
		Dim NameVar1 As String '-:-
		Dim namevar2 As Integer '-:-
		
		CommonDialog1Open.ShowDialog()
		
		If CommonDialog1Open.FileName = "" Then Exit Sub
		
		If CommonDialog1Open.InitialDirectory <> "" Then
			CommonDialog1Open.InitialDirectory = ""
		End If 'Nytt
		
		If R1Present = False Then
			'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog1Open.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot1.Text = VB.Left(NameVar1, namevar2)
			
			R1Present = True
			R1path = CommonDialog1Open.FileName
			Load2.Visible = True
			
			CommonDialog1Open.FileName = ""
			SelectedRobot = 1
			Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
			LoadRobot1()
			GoTo OpenNoMoreRobot
		ElseIf R2Present = False Then 
			'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog1Open.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot2.Text = VB.Left(NameVar1, namevar2)
			
			R2Present = True
			R2path = CommonDialog1Open.FileName
			Load2.Visible = True
			Load3.Visible = True
			
			CommonDialog1Open.FileName = ""
			SelectedRobot = 2
			Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.Color.Black : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
			LoadRobot2()
			GoTo OpenNoMoreRobot
		ElseIf R3Present = False Then 
			'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog1Open.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot3.Text = VB.Left(NameVar1, namevar2)
			
			R3Present = True
			R3path = CommonDialog1Open.FileName
			Load3.Visible = True
			Load4.Visible = True
			
			CommonDialog1Open.FileName = ""
			SelectedRobot = 3
			Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.Color.Black : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
			LoadRobot3()
			GoTo OpenNoMoreRobot
		ElseIf R4Present = False Then 
			'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog1Open.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot4.Text = VB.Left(NameVar1, namevar2)
			
			R4Present = True
			R4path = CommonDialog1Open.FileName
			Load4.Visible = True
			Load5.Visible = True
			
			CommonDialog1Open.FileName = ""
			SelectedRobot = 4
			Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.Color.Black : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
			LoadRobot4()
			GoTo OpenNoMoreRobot
		ElseIf R5Present = False Then 
			'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog1Open.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot5.Text = VB.Left(NameVar1, namevar2)
			
			R5Present = True
			R5path = CommonDialog1Open.FileName
			Load5.Visible = True
			Load6.Visible = True
			
			CommonDialog1Open.FileName = ""
			SelectedRobot = 5
			Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.Color.Black : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
			LoadRobot5()
			GoTo OpenNoMoreRobot
		ElseIf R6Present = False Then 
			'UPGRADE_WARNING: CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			NameVar1 = CommonDialog1Open.FileName 'Tar bort .RWR från namnet
			namevar2 = Len(NameVar1) - 4 'Removes .RWR from the name
			Robot6.Text = VB.Left(NameVar1, namevar2)
			
			R6Present = True
			R6path = CommonDialog1Open.FileName
			Load6.Visible = True
			
			NewRobot.Enabled = False
			LoadRobot.Enabled = False
			Duplicate.Enabled = False
			SaveAs.Enabled = False
			CommonDialog1Open.FileName = ""
			SelectedRobot = 6
			Robot1.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot1.ForeColor = System.Drawing.Color.White : Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White : Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White : Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White : Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White : Robot6.BackColor = System.Drawing.Color.Black : Robot6.ForeColor = System.Drawing.Color.White
			LoadRobot6()
		End If
		
OpenNoMoreRobot: 
		If Not Replaying Then ResetHistory_Click(ResetHistory, New System.EventArgs())
	End Sub
	
	Public Function CheckInvalid(ByRef TheNumber As Byte) As Boolean
		If TheNumber = 1 Or TheNumber = 0 Then CheckInvalid = False Else CheckInvalid = True
	End Function
	
	'UPGRADE_NOTE: Conversion was upgraded to Conversion_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Conversion_Renamed(ByRef RobotNr As Integer)
		FileClose(254)
		
		If MsgBox("This is not a New RWR Windows Robot. This robot might be using the old multifile robot format." & vbCr & "Would you like it to have it converted to the new file format?" & vbCr & vbCr & "A backup copy of the old robot will be saved in" & vbCr & My.Application.Info.DirectoryPath & "\Backups\" & vbCr & "before converting.", MsgBoxStyle.OKCancel + MsgBoxStyle.Question, "Loading Robot") = MsgBoxResult.OK Then
			Convert((RobotNr))
		Else
			SelectedRobot = RobotNr
			Close_Renamed_Click(Close_Renamed, New System.EventArgs())
		End If
	End Sub
	
	Private Sub Convert(ByRef RobotNr As Integer)
		On Error GoTo failed
		
		Dim robotpath As String
		Dim RobotCode As String
		Dim c As Integer
		Dim TheNewRobot As Robot
		Dim RecordIcon(9) As String
		Dim RecordSound(9) As String
		Dim RobotNameOnly As String
		Dim NameVar1 As String
		
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If Dir(My.Application.Info.DirectoryPath & "\Backups\", FileAttribute.Directory) = "" Then
			MkDir(My.Application.Info.DirectoryPath & "\Backups\")
		End If
		
		Select Case RobotNr
			Case 1
				robotpath = R1path
				NameVar1 = StrReverse(robotpath)
				NameVar1 = VB.Right(robotpath, InStr(NameVar1, "\") - 1)
				RobotNameOnly = VB.Left(NameVar1, Len(NameVar1))
				FileCopy(robotpath, My.Application.Info.DirectoryPath & "\Backups\" & RobotNameOnly)
			Case 2
				robotpath = R2path
				NameVar1 = StrReverse(robotpath)
				NameVar1 = VB.Right(robotpath, InStr(NameVar1, "\") - 1)
				RobotNameOnly = VB.Left(NameVar1, Len(NameVar1))
				FileCopy(robotpath, My.Application.Info.DirectoryPath & "\Backups\" & RobotNameOnly)
			Case 3
				robotpath = R3path
				NameVar1 = StrReverse(robotpath)
				NameVar1 = VB.Right(robotpath, InStr(NameVar1, "\") - 1)
				RobotNameOnly = VB.Left(NameVar1, Len(NameVar1))
				FileCopy(robotpath, My.Application.Info.DirectoryPath & "\Backups\" & RobotNameOnly)
			Case 4
				robotpath = R4path
				NameVar1 = StrReverse(robotpath)
				NameVar1 = VB.Right(robotpath, InStr(NameVar1, "\") - 1)
				RobotNameOnly = VB.Left(NameVar1, Len(NameVar1))
				FileCopy(robotpath, My.Application.Info.DirectoryPath & "\Backups\" & RobotNameOnly)
			Case 5
				robotpath = R5path
				NameVar1 = StrReverse(robotpath)
				NameVar1 = VB.Right(robotpath, InStr(NameVar1, "\") - 1)
				RobotNameOnly = VB.Left(NameVar1, Len(NameVar1))
				FileCopy(robotpath, My.Application.Info.DirectoryPath & "\Backups\" & RobotNameOnly)
			Case 6
				robotpath = R6path
				NameVar1 = StrReverse(robotpath)
				NameVar1 = VB.Right(robotpath, InStr(NameVar1, "\") - 1)
				RobotNameOnly = VB.Left(NameVar1, Len(NameVar1))
				FileCopy(robotpath, My.Application.Info.DirectoryPath & "\Backups\" & RobotNameOnly)
		End Select
		
		Dim PathNoExt As String
		PathNoExt = VB.Left(robotpath, Len(robotpath) - 4)
		
		Dim TheRobot As String
		Dim hardwaretag As String
		Dim icontag As String
		Dim machinecodetag As String
		
		FileOpen(1, robotpath, OpenMode.Input)
		TheRobot = InputString(1, LOF(1))
		
		Dim tagstart As Integer
		
		tagstart = InStr(TheRobot, "<Code>") + 7
		RobotCode = Mid(TheRobot, tagstart, InStr(TheRobot, "</Code>") - tagstart)
		
		tagstart = InStr(TheRobot, "<Hardware>") + 11
		hardwaretag = Mid(TheRobot, tagstart, InStr(TheRobot, "</Hardware>") - tagstart)
		
		tagstart = InStr(TheRobot, "<Icon>") + 7
		icontag = Mid(TheRobot, tagstart, InStr(TheRobot, "</Icon>") - tagstart)
		
		tagstart = InStr(TheRobot, "<Machinecode>") + 14
		machinecodetag = Mid(TheRobot, tagstart, InStr(TheRobot, "</Machinecode>") - tagstart)
		
		FileClose(1)
		
		Dim ha() As String
		Dim iA() As String
		
		ha = Split(hardwaretag, vbCr)
		iA = Split(icontag, vbCr)
		
		For c = 0 To 2
			ha(c) = CStr(Val(VB.Right(ha(c), 3)))
		Next c
		
		For c = 3 To 13 'UBound(ha)
			ha(c) = CStr(Val(VB.Right(ha(c), 2)))
		Next c
		
		For c = 0 To 4 'UBound(ia)
			iA(c) = CStr(Val(VB.Right(iA(c), 1)))
		Next c
		
		With TheNewRobot
			.Energy = CShort(ha(0))
			.Damage = CShort(ha(1))
			.Shield = CShort(ha(2))
			.Prosessor = CByte(ha(3))
			.Bullets = CByte(ha(4))
			.Turret = CByte(ha(5))
			.Missiles = CByte(ha(6))
			.TacNukes = CByte(ha(7))
			.Hellbores = CByte(ha(8))
			.Mines = CByte(ha(9))
			.Stunners = CByte(ha(10))
			.Drones = CByte(ha(11))
			.Lasers = CByte(ha(12))
			.Probes = CByte(ha(13))
			.ShieldIcon = CByte(iA(0))
			.DeathIcon = CByte(iA(1))
			.CollisionIcon = CByte(iA(2))
			.BlockIcon = CByte(iA(3))
			.HitIcon = CByte(iA(4))
		End With
		
		Dim ma() As String
		ma = Split(machinecodetag, vbCr)
		
		Dim MachineCode() As Short 'Long
		ReDim MachineCode(UBound(ma) - 1)
		
		For c = 0 To UBound(MachineCode)
			MachineCode(c) = Inst2MagicNumber(ma(c))
		Next c
		
		For c = 0 To 9
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If Dir(PathNoExt & "#" & c & ".ico") <> "" Then
				FileOpen(1, PathNoExt & "#" & c & ".ico", OpenMode.Binary)
				RecordIcon(c) = InputString(1, LOF(1))
				FileClose(1)
			Else
				RecordIcon(c) = ""
			End If
		Next c
		For c = 0 To 9
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If Dir(PathNoExt & "#" & c & ".WAV") <> "" Then
				FileOpen(1, PathNoExt & "#" & c & ".WAV", OpenMode.Binary)
				RecordSound(c) = InputString(1, LOF(1))
				FileClose(1)
			Else
				RecordSound(c) = ""
			End If
		Next c
		'''''''''''''''''''''''''''''''''''''''
		Kill(robotpath) 'fixar Norobot bugget
		
		Dim RecIconStart(9) As Integer
		Dim RecSoundStart(9) As Integer
		Dim MCStart As Integer
		Dim Cstart As Integer
		Dim IconExists(9) As Byte
		Dim SoundExists(9) As Byte
		
		RecSoundStart(0) = recsoundstartzero
		For c = 0 To 8
			RecSoundStart(c + 1) = RecSoundStart(c) + Len(RecordSound(c))
		Next c
		
		RecIconStart(0) = RecSoundStart(9) + Len(RecordSound(9))
		
		For c = 0 To 8
			RecIconStart(c + 1) = RecIconStart(c) + Len(RecordIcon(c))
		Next c
		MCStart = RecIconStart(9) + Len(RecordIcon(9))
		Cstart = MCStart + (UBound(MachineCode) + 1) * 2
		
		For c = 0 To 9
			If RecordIcon(c) = "" Then IconExists(c) = 0 Else IconExists(c) = 1
			If RecordSound(c) = "" Then SoundExists(c) = 0 Else SoundExists(c) = 1
		Next c
		
		FileOpen(1, robotpath, OpenMode.Binary)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, TheNewRobot)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, RecIconStart, iconrec)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, RecSoundStart, sndrec)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, IconExists, zeroexists)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, SoundExists, soundspresent)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, MCStart, MCrec)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, Cstart, Crec)
		
		For c = 0 To 9
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If IconExists(c) <> 0 Then FilePut(1, RecordIcon(c), RecIconStart(c))
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If SoundExists(c) <> 0 Then FilePut(1, RecordSound(c), RecSoundStart(c))
		Next c
		
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, MachineCode, MCStart)
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(1, RobotCode & vbCr, Cstart) 'I have no idea why, but it Seems to need a cr to work properly
		
		FileClose(1)
		
		Select Case RobotNr
			Case 1
				LoadRobot1()
			Case 2
				LoadRobot2()
			Case 3
				LoadRobot3()
			Case 4
				LoadRobot4()
			Case 5
				LoadRobot5()
			Case 6
				LoadRobot6()
		End Select
		
		robotpath = VB.Left(robotpath, Len(robotpath) - 4)
		RobotNameOnly = VB.Left(RobotNameOnly, Len(RobotNameOnly) - 4)
		
		For c = 0 To 9
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If Dir(robotpath & "#" & c & ".ico") <> "" Then
				FileCopy(robotpath & "#" & c & ".ico", My.Application.Info.DirectoryPath & "\Backups\" & RobotNameOnly & "#" & c & ".ico")
				Kill(robotpath & "#" & c & ".ico")
			End If
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If Dir(robotpath & "#" & c & ".WAV") <> "" Then
				FileCopy(robotpath & "#" & c & ".WAV", My.Application.Info.DirectoryPath & "\Backups\" & RobotNameOnly & "#" & c & ".WAV")
				Kill(robotpath & "#" & c & ".WAV")
			End If
		Next c
		
		Exit Sub
		
failed: 
		MsgBox("Totally =(. The bot might be destroyed.", MsgBoxStyle.Exclamation, "Robot failed conversion")
		FileClose(1)
		
		SelectedRobot = RobotNr
		Close_Renamed_Click(Close_Renamed, New System.EventArgs())
	End Sub
	
	'LADDA ROBOT 1 - LOAD ROBOT 1
	Private Sub LoadRobot1()
		Dim TheRobot As Robot
		Dim RecIconStart(1) As Integer
		Dim IconZeroExists As Byte
		Dim IconZero As String
		
		FileOpen(254, R1path, OpenMode.Binary)
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, TheRobot)
		
		If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or CheckInvalid(TheRobot.Hellbores) Or CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or CheckInvalid(TheRobot.TacNukes) Then
			Conversion_Renamed((1))
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RecIconStart, iconrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, IconZeroExists, zeroexists)
		
		If IconZeroExists <> 0 Then
			IconZero = Space(RecIconStart(1) - RecIconStart(0))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(254, IconZero, RecIconStart(0))
			R1Icon.Image = LoadRobotIcon(IconZero)
		Else
			R1Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\1#0.ico")
		End If
		
		Dim RNN As Integer
		Dim InputInsts(4999) As Short
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RNN, MCrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, InputInsts, RNN)
		
		For RNN = 0 To 4999
			MasterCode(1, RNN) = InputInsts(RNN)
			If InputInsts(RNN) = insEND Then Exit For
		Next RNN
		FileClose(254)
		
		Points1X.Visible = True
		PR1.Visible = True
		'PR1.Caption = 0
		
		Robot1DeathIcon = TheRobot.DeathIcon
		Robot1CollisionIcon = TheRobot.CollisionIcon
		Robot1BlockIcon = TheRobot.BlockIcon
		Robot1HitIcon = TheRobot.HitIcon
		Robot1ShieldIcon = TheRobot.ShieldIcon
		
		Robot1Energy = TheRobot.Energy
		ER(1).Text = CStr(Robot1Energy)
		ER(1).Visible = True
		Energy1X.Visible = True
		Robot1Damage = TheRobot.Damage
		DR(1).Text = CStr(Robot1Damage)
		DR(1).Visible = True
		Damage1X.Visible = True
		
		Robot1Shield = TheRobot.Shield
		Robot1ProSpeed = TheRobot.Prosessor
		Robot1Bullets = TheRobot.Bullets
		Robot1Turret = TheRobot.Turret
		Robot1Missiles = TheRobot.Missiles
		Robot1TacNukes = TheRobot.TacNukes
		Robot1Hellbores = TheRobot.Hellbores
		Robot1Mines = TheRobot.Mines
		Robot1Stunners = TheRobot.Stunners
		Robot1Drones = TheRobot.Drones
		Robot1Lasers = TheRobot.Lasers
		Robot1Probes = TheRobot.Probes
	End Sub
	
	'LADDA ROBOT 2 - LOAD ROBOT 2
	Private Sub LoadRobot2()
		Dim TheRobot As Robot
		Dim RecIconStart(1) As Integer
		Dim IconZeroExists As Byte
		Dim IconZero As String
		
		FileOpen(254, R2path, OpenMode.Binary)
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, TheRobot)
		'
		If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or CheckInvalid(TheRobot.Hellbores) Or CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or CheckInvalid(TheRobot.TacNukes) Then
			Conversion_Renamed((2))
			Exit Sub
		End If
		'
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RecIconStart, iconrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, IconZeroExists, zeroexists)
		
		If IconZeroExists <> 0 Then
			IconZero = Space(RecIconStart(1) - RecIconStart(0))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(254, IconZero, RecIconStart(0))
			R2Icon.Image = LoadRobotIcon(IconZero)
		Else
			R2Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\2#0.ico")
		End If
		
		Dim RNN As Integer
		Dim InputInsts(4999) As Short
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RNN, MCrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, InputInsts, RNN)
		
		For RNN = 0 To 4999
			MasterCode(2, RNN) = InputInsts(RNN)
			If InputInsts(RNN) = insEND Then Exit For
		Next RNN
		FileClose(254)
		
		Points2X.Visible = True
		PR2.Visible = True
		'PR2.Caption = 0
		
		Robot2DeathIcon = TheRobot.DeathIcon
		Robot2CollisionIcon = TheRobot.CollisionIcon
		Robot2BlockIcon = TheRobot.BlockIcon
		Robot2HitIcon = TheRobot.HitIcon
		Robot2ShieldIcon = TheRobot.ShieldIcon
		
		Robot2Energy = TheRobot.Energy
		ER(2).Text = CStr(Robot2Energy)
		ER(2).Visible = True
		Energy2X.Visible = True
		Robot2Damage = TheRobot.Damage
		DR(2).Text = CStr(Robot2Damage)
		DR(2).Visible = True
		Damage2X.Visible = True
		
		Robot2Shield = TheRobot.Shield
		Robot2ProSpeed = TheRobot.Prosessor
		Robot2Bullets = TheRobot.Bullets
		Robot2Turret = TheRobot.Turret
		Robot2Missiles = TheRobot.Missiles
		Robot2TacNukes = TheRobot.TacNukes
		Robot2Hellbores = TheRobot.Hellbores
		Robot2Mines = TheRobot.Mines
		Robot2Stunners = TheRobot.Stunners
		Robot2Drones = TheRobot.Drones
		Robot2Lasers = TheRobot.Lasers
		Robot2Probes = TheRobot.Probes
	End Sub
	
	'LADDA ROBOT 3 - LOAD ROBOT 3
	Private Sub LoadRobot3()
		Dim TheRobot As Robot
		Dim RecIconStart(1) As Integer
		Dim IconZeroExists As Byte
		Dim IconZero As String
		
		FileOpen(254, R3path, OpenMode.Binary)
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, TheRobot)
		'
		If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or CheckInvalid(TheRobot.Hellbores) Or CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or CheckInvalid(TheRobot.TacNukes) Then
			Conversion_Renamed((3))
			Exit Sub
		End If
		'
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RecIconStart, iconrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, IconZeroExists, zeroexists)
		
		If IconZeroExists <> 0 Then
			IconZero = Space(RecIconStart(1) - RecIconStart(0))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(254, IconZero, RecIconStart(0))
			R3Icon.Image = LoadRobotIcon(IconZero)
		Else
			R3Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\3#0.ico")
		End If
		
		Dim RNN As Integer
		Dim InputInsts(4999) As Short
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RNN, MCrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, InputInsts, RNN)
		
		For RNN = 0 To 4999
			MasterCode(3, RNN) = InputInsts(RNN)
			If InputInsts(RNN) = insEND Then Exit For
		Next RNN
		FileClose(254)
		
		Points3X.Visible = True
		PR3.Visible = True
		'PR3.Caption = 0
		
		Robot3DeathIcon = TheRobot.DeathIcon
		Robot3CollisionIcon = TheRobot.CollisionIcon
		Robot3BlockIcon = TheRobot.BlockIcon
		Robot3HitIcon = TheRobot.HitIcon
		Robot3ShieldIcon = TheRobot.ShieldIcon
		
		Robot3Energy = TheRobot.Energy
		ER(3).Text = CStr(Robot3Energy)
		ER(3).Visible = True
		Energy3X.Visible = True
		Robot3Damage = TheRobot.Damage
		DR(3).Text = CStr(Robot3Damage)
		DR(3).Visible = True
		Damage3X.Visible = True
		
		Robot3Shield = TheRobot.Shield
		Robot3ProSpeed = TheRobot.Prosessor
		Robot3Bullets = TheRobot.Bullets
		Robot3Turret = TheRobot.Turret
		Robot3Missiles = TheRobot.Missiles
		Robot3TacNukes = TheRobot.TacNukes
		Robot3Hellbores = TheRobot.Hellbores
		Robot3Mines = TheRobot.Mines
		Robot3Stunners = TheRobot.Stunners
		Robot3Drones = TheRobot.Drones
		Robot3Lasers = TheRobot.Lasers
		Robot3Probes = TheRobot.Probes
	End Sub
	
	'LADDA ROBOT 4 - LOAD ROBOT 4
	Private Sub LoadRobot4()
		Dim TheRobot As Robot
		Dim RecIconStart(1) As Integer
		Dim IconZeroExists As Byte
		Dim IconZero As String
		
		FileOpen(254, R4path, OpenMode.Binary)
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, TheRobot)
		'
		If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or CheckInvalid(TheRobot.Hellbores) Or CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or CheckInvalid(TheRobot.TacNukes) Then
			Conversion_Renamed((4))
			Exit Sub
		End If
		'
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RecIconStart, iconrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, IconZeroExists, zeroexists)
		
		If IconZeroExists <> 0 Then
			IconZero = Space(RecIconStart(1) - RecIconStart(0))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(254, IconZero, RecIconStart(0))
			R4Icon.Image = LoadRobotIcon(IconZero)
		Else
			R4Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\4#0.ico")
		End If
		
		Dim RNN As Integer
		Dim InputInsts(4999) As Short
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RNN, MCrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, InputInsts, RNN)
		
		For RNN = 0 To 4999
			MasterCode(4, RNN) = InputInsts(RNN)
			If InputInsts(RNN) = insEND Then Exit For
		Next RNN
		FileClose(254)
		
		Points4X.Visible = True
		PR4.Visible = True
		'PR4.Caption = 0
		
		Robot4DeathIcon = TheRobot.DeathIcon
		Robot4CollisionIcon = TheRobot.CollisionIcon
		Robot4BlockIcon = TheRobot.BlockIcon
		Robot4HitIcon = TheRobot.HitIcon
		Robot4ShieldIcon = TheRobot.ShieldIcon
		
		Robot4Energy = TheRobot.Energy
		ER(4).Text = CStr(Robot4Energy)
		ER(4).Visible = True
		Energy4X.Visible = True
		Robot4Damage = TheRobot.Damage
		DR(4).Text = CStr(Robot4Damage)
		DR(4).Visible = True
		Damage4X.Visible = True
		
		Robot4Shield = TheRobot.Shield
		Robot4ProSpeed = TheRobot.Prosessor
		Robot4Bullets = TheRobot.Bullets
		Robot4Turret = TheRobot.Turret
		Robot4Missiles = TheRobot.Missiles
		Robot4TacNukes = TheRobot.TacNukes
		Robot4Hellbores = TheRobot.Hellbores
		Robot4Mines = TheRobot.Mines
		Robot4Stunners = TheRobot.Stunners
		Robot4Drones = TheRobot.Drones
		Robot4Lasers = TheRobot.Lasers
		Robot4Probes = TheRobot.Probes
	End Sub
	
	'LADDA ROBOT 5 - LOAD ROBOT 5
	Private Sub LoadRobot5()
		Dim TheRobot As Robot
		Dim RecIconStart(1) As Integer
		Dim IconZeroExists As Byte
		Dim IconZero As String
		
		FileOpen(254, R5path, OpenMode.Binary)
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, TheRobot)
		'
		If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or CheckInvalid(TheRobot.Hellbores) Or CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or CheckInvalid(TheRobot.TacNukes) Then
			Conversion_Renamed((5))
			Exit Sub
		End If
		'
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RecIconStart, iconrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, IconZeroExists, zeroexists)
		
		If IconZeroExists <> 0 Then
			IconZero = Space(RecIconStart(1) - RecIconStart(0))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(254, IconZero, RecIconStart(0))
			R5Icon.Image = LoadRobotIcon(IconZero)
		Else
			R5Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\5#0.ico")
		End If
		
		Dim RNN As Integer
		Dim InputInsts(4999) As Short
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RNN, MCrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, InputInsts, RNN)
		
		For RNN = 0 To 4999
			MasterCode(5, RNN) = InputInsts(RNN)
			If InputInsts(RNN) = insEND Then Exit For
		Next RNN
		FileClose(254)
		
		Points5X.Visible = True
		PR5.Visible = True
		'PR5.Caption = 0
		
		Robot5DeathIcon = TheRobot.DeathIcon
		Robot5CollisionIcon = TheRobot.CollisionIcon
		Robot5BlockIcon = TheRobot.BlockIcon
		Robot5HitIcon = TheRobot.HitIcon
		Robot5ShieldIcon = TheRobot.ShieldIcon
		
		Robot5Energy = TheRobot.Energy
		ER(5).Text = CStr(Robot5Energy)
		ER(5).Visible = True
		Energy5X.Visible = True
		Robot5Damage = TheRobot.Damage
		DR(5).Text = CStr(Robot5Damage)
		DR(5).Visible = True
		Damage5X.Visible = True
		
		Robot5Shield = TheRobot.Shield
		Robot5ProSpeed = TheRobot.Prosessor
		Robot5Bullets = TheRobot.Bullets
		Robot5Turret = TheRobot.Turret
		Robot5Missiles = TheRobot.Missiles
		Robot5TacNukes = TheRobot.TacNukes
		Robot5Hellbores = TheRobot.Hellbores
		Robot5Mines = TheRobot.Mines
		Robot5Stunners = TheRobot.Stunners
		Robot5Drones = TheRobot.Drones
		Robot5Lasers = TheRobot.Lasers
		Robot5Probes = TheRobot.Probes
	End Sub
	
	
	'LADDA ROBOT 6 - LOAD ROBOT 6
	Private Sub LoadRobot6()
		Dim TheRobot As Robot
		Dim RecIconStart(1) As Integer
		Dim IconZeroExists As Byte
		Dim IconZero As String
		
		FileOpen(254, R6path, OpenMode.Binary)
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, TheRobot)
		'
		If CheckInvalid(TheRobot.BlockIcon) Or CheckInvalid(TheRobot.CollisionIcon) Or CheckInvalid(TheRobot.DeathIcon) Or CheckInvalid(TheRobot.HitIcon) Or CheckInvalid(TheRobot.ShieldIcon) Or CheckInvalid(TheRobot.Hellbores) Or CheckInvalid(TheRobot.Lasers) Or CheckInvalid(TheRobot.Mines) Or CheckInvalid(TheRobot.Missiles) Or CheckInvalid(TheRobot.Probes) Or CheckInvalid(TheRobot.Stunners) Or CheckInvalid(TheRobot.TacNukes) Then
			Conversion_Renamed((6))
			Exit Sub
		End If
		'
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RecIconStart, iconrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, IconZeroExists, zeroexists)
		
		If IconZeroExists <> 0 Then
			IconZero = Space(RecIconStart(1) - RecIconStart(0))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(254, IconZero, RecIconStart(0))
			R6Icon.Image = LoadRobotIcon(IconZero)
		Else
			R6Icon.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\6#0.ico")
		End If
		
		Dim RNN As Integer
		Dim InputInsts(4999) As Short
		
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, RNN, MCrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(254, InputInsts, RNN)
		
		For RNN = 0 To 4999
			MasterCode(6, RNN) = InputInsts(RNN)
			If InputInsts(RNN) = insEND Then Exit For
		Next RNN
		FileClose(254)
		
		Points6X.Visible = True
		PR6.Visible = True
		'PR6.Caption = 0
		
		Robot6DeathIcon = TheRobot.DeathIcon
		Robot6CollisionIcon = TheRobot.CollisionIcon
		Robot6BlockIcon = TheRobot.BlockIcon
		Robot6HitIcon = TheRobot.HitIcon
		Robot6ShieldIcon = TheRobot.ShieldIcon
		
		Robot6Energy = TheRobot.Energy
		ER(6).Text = CStr(Robot6Energy)
		ER(6).Visible = True
		Energy6X.Visible = True
		Robot6Damage = TheRobot.Damage
		DR(6).Text = CStr(Robot6Damage)
		DR(6).Visible = True
		Damage6X.Visible = True
		
		Robot6Shield = TheRobot.Shield
		Robot6ProSpeed = TheRobot.Prosessor
		Robot6Bullets = TheRobot.Bullets
		Robot6Turret = TheRobot.Turret
		Robot6Missiles = TheRobot.Missiles
		Robot6TacNukes = TheRobot.TacNukes
		Robot6Hellbores = TheRobot.Hellbores
		Robot6Mines = TheRobot.Mines
		Robot6Stunners = TheRobot.Stunners
		Robot6Drones = TheRobot.Drones
		Robot6Lasers = TheRobot.Lasers
		Robot6Probes = TheRobot.Probes
	End Sub
	
	Public Sub StartAtChronon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles StartAtChronon.Click
		If RunningTournament Then Exit Sub
		
		If Not R1Present Then
			MsgBox("There is no Robot present to debug.", MsgBoxStyle.OKOnly, "No Robot Present")
			Exit Sub
		End If
		
		Dim inputval As Object
		Dim c As Short
		Dim CrashTime As Integer
		CrashTime = DEBUGATNOTSET
		
		For c = 1 To 6
			If InStr(RobotDead(c).Text, "Buggy - Time: ") <> 0 And RobotDead(c).Visible Then
				CrashTime = Val(Replace(RobotDead(c).Text, "Buggy - Time: ", "")) - 1
				WillBeDebugged = c
				Exit For
			End If
		Next c
		
		If CrashTime = DEBUGATNOTSET Then
			For c = 1 To 6
				If InStr(RobotDead(c).Text, "Overloaded - Time: ") <> 0 And RobotDead(c).Visible Then
					CrashTime = Val(Replace(RobotDead(c).Text, "Overloaded - Time: ", "")) - 1
					WillBeDebugged = c
					Exit For
				End If
			Next c
		End If
		
		If CrashTime = DEBUGATNOTSET Then
			For c = 1 To 6
				If InStr(RobotDead(c).Text, "Dead - Time: ") <> 0 And RobotDead(c).Visible Then
					CrashTime = Val(Replace(RobotDead(c).Text, "Dead - Time: ", "")) - 5
					WillBeDebugged = c
					Exit For
				End If
			Next c
		End If
		
		If StartDebuggerAt = DEBUGATNOTSET Then
			If CrashTime < 0 Then CrashTime = 10
			If WillBeDebugged < 1 Then WillBeDebugged = 1
		Else
			CrashTime = StartDebuggerAt
		End If
		
Retry: 
		'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		inputval = InputBox("Please select the chronon when to start the debugger" & vbCr & "To disable debugger from starting at a certain chronon, enter a negative value.", "Start Debugger at", CStr(CrashTime))
		
		'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IsNumeric(inputval) And inputval >= 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			StartDebuggerAt = inputval
retry2: 
			'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			inputval = InputBox("Debug Robot number", "Start Debugger at", CStr(WillBeDebugged))
			'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If IsNumeric(inputval) And inputval >= 1 And inputval <= 6 Then 'Everything's fine
				'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				WillBeDebugged = inputval
				If Not Replaying Then RepeatBattle_Click(RepeatBattle, New System.EventArgs())
				'Fast_Click
				If HideBattle Then Normal_Click(Normal, New System.EventArgs()) 'disk
				
				If DebuggedRobot <> 0 Then
					DebuggedRobot = 0
					Image1(SelectedRobot).Visible = False
					DebuggingWindow.Close()
				End If
				'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ElseIf (IsNumeric(inputval) And inputval <= 0) Or inputval = "" Then  'Pressed Cancel
				StartDebuggerAt = DEBUGATNOTSET
			Else 'Invalid Value
				'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If MsgBox("The value specified (" & inputval & ") is not a valid robot.", MsgBoxStyle.RetryCancel, "Start Debugger at") = MsgBoxResult.Retry Then GoTo retry2
			End If
			'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ElseIf (IsNumeric(inputval) And inputval <= 0) Or inputval = "" Then 
			StartDebuggerAt = DEBUGATNOTSET
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object inputval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If MsgBox("The value specified (" & inputval & ") is not a valid chronon.", MsgBoxStyle.RetryCancel, "Can't start debugger this chronon ") = MsgBoxResult.Retry Then GoTo Retry
		End If
		
	End Sub
	
	Private Sub ChrononStart() 'This sub is required when the debugger is set to start at a certain chronon
		If DebuggedRobot = 0 Then
			DebuggerAutoStart = True
			DebuggedRobot = WillBeDebugged 'For startdebuggerat
			Image1(DebuggedRobot).Visible = True
			
			'    If Normal.Checked Then     'Onödigt?
			'        Normal_Click
			'    ElseIf Fast.Checked Then
			'        Fast_Click
			'    ElseIf AutoRedrawFast.Checked Then
			'        AutoRedrawFast_Click
			'    ElseIf Slow.Checked Then
			'        Slow_Click
			'    ElseIf Slower.Checked Then
			'        Slower_Click
			'    ElseIf Slowest.Checked Then
			'        Slowest_Click
			'    End If
		End If
	End Sub
	
	Private Sub StopTournament_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles StopTournament.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case System.Windows.Forms.Keys.D1
				Slowest_Click(Slowest, New System.EventArgs())
			Case System.Windows.Forms.Keys.D2
				Slower_Click(Slower, New System.EventArgs())
			Case System.Windows.Forms.Keys.D3
				Slow_Click(Slow, New System.EventArgs())
			Case System.Windows.Forms.Keys.D4
				Normal_Click(Normal, New System.EventArgs())
			Case System.Windows.Forms.Keys.D5
				Fast_Click(Fast, New System.EventArgs())
			Case System.Windows.Forms.Keys.D6
				NoDisplay_Click(NoDisplay, New System.EventArgs())
			Case System.Windows.Forms.Keys.D7
				Ultra_Click(Ultra, New System.EventArgs())
		End Select
	End Sub
	
	Public Sub Studio_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Studio.Click
		
		If SelectedRobot < 1 Then
			MsgBox("Can't show Recording Studio because no robot is selected. To select a robot, use the PageUp and PageDown keys.", MsgBoxStyle.OKOnly, "No Robot Selected")
		Else
			VB6.ShowForm(SoundEditor, 1, Me)
		End If
		
	End Sub
	
	Public Sub Team1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Team1.Click
		If SelectedRobot >= 1 Then
			RobotTeam(SelectedRobot) = 1
			TeamLabel(SelectedRobot).Text = "Team 1"
			TeamLabel(SelectedRobot).ForeColor = System.Drawing.ColorTranslator.FromOle(ColorTeam1) 'RGB(18, 200, 241)
			TeamLabel(SelectedRobot).Visible = True
		End If
	End Sub
	
	Public Sub Team2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Team2.Click
		If SelectedRobot >= 1 Then
			RobotTeam(SelectedRobot) = 2
			TeamLabel(SelectedRobot).Text = "Team 2"
			TeamLabel(SelectedRobot).ForeColor = ColorTeam2 'RGB(18, 241, 200)
			TeamLabel(SelectedRobot).Visible = True
		End If
	End Sub
	
	Public Sub Team3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Team3.Click
		If SelectedRobot >= 1 Then
			RobotTeam(SelectedRobot) = 3
			TeamLabel(SelectedRobot).Text = "Team 3"
			TeamLabel(SelectedRobot).ForeColor = System.Drawing.ColorTranslator.FromOle(RGB(200, 241, 18)) 'ColorTeam3 'RGB(200, 241, 18)
			TeamLabel(SelectedRobot).Visible = True
		End If
	End Sub
	
	Public Sub TestRobot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TestRobot.Click
		TestTourney.Show()
	End Sub
	
	Private Sub TitleTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TitleTimer.Tick
		If Len(sMainWindowCaption) > 0 Then Me.Text = sMainWindowCaption
	End Sub
	
	Public Sub Tournament_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Tournament.Click
		TournamentD.Show()
	End Sub
	
	Private Sub DeathAnimationInitz(ByRef RDN As Integer, ByRef TheIconNumber As Integer)
		Dim RobotConstant As Integer
		RobotConstant = RDN * 10
		
		If PlaySounds Then
			If RobotDeathSound(RDN) Then
				PlaySnd0((RDN))
			Else
				sndPlaySound(deathsound(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			End If
		End If
		
		If RobotDeathIcon(RDN) = 1 Then
			Robot_(RDN) = RobotMasterIcon(RobotConstant + 2)
		Else
			If TheIconNumber >= 100 Then 'Switches off the collision/block/hit icons if it's on
				TheIconNumber = TheIconNumber - 100
				If TheIconNumber <> 10 Then Robot_(RDN) = RobotMasterIcon(RDN * 10 + TheIconNumber) Else Robot_(RDN) = RobotMasterIcon(RDN * 10 + 1)
			End If
		End If
		
		TurretX2(RDN) = RobotLeft(RDN)
		TurretY2(RDN) = RobotTop(RDN)
		
		DeathAnimation(RDN, 255)
	End Sub
	
	Private Sub DeathAnimation(ByRef RobotNr As Integer, ByVal d As Integer)
		Dim RobotConstant As Integer
		RobotConstant = RobotNr * 10
		d = 255 - d
		'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.PaintPicture(Robot_(RobotNr), TurretX2(RobotNr) - d - 16, TurretY2(RobotNr) - d - 16, 16, 16, 0, 0, 16, 16)
		'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.PaintPicture(Robot_(RobotNr), TurretX2(RobotNr) + d, TurretY2(RobotNr) - d - 16, 16, 16, 16, 0, 16, 16)
		'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.PaintPicture(Robot_(RobotNr), TurretX2(RobotNr) + d, TurretY2(RobotNr) + d, 16, 16, 16, 16, 16, 16)
		'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Arena.PaintPicture(Robot_(RobotNr), TurretX2(RobotNr) - d - 16, TurretY2(RobotNr) + d, 16, 16, 0, 16, 16, 16)
	End Sub
	
	Private Sub MasterIconHandler()
		'This sub loads the robots' specific icons and sounds
		
		'ICONS
		Dim RecIconStart(10) As Integer '10 is really the machine code start
		Dim RecSoundStart(10) As Integer '10 is really the Icon 0 start
		'UPGRADE_WARNING: Lower bound of array RecordIcon was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RecordIcon(9) As String
		Dim IconsExist(9) As Byte
		Dim SoundsExist(9) As Byte
		Dim c As Integer
		Dim d As Integer
		
		RobotMasterIcon(10) = R1Icon 'STANDARD ICON - (ICON0)
		
		FileOpen(1, R1path, OpenMode.Binary)
		If R2Present Then
			FileOpen(2, R2path, OpenMode.Binary)
			RobotMasterIcon(20) = R2Icon
			
			If R3Present Then
				FileOpen(3, R3path, OpenMode.Binary)
				RobotMasterIcon(30) = R3Icon
				
				If R4Present Then
					FileOpen(4, R4path, OpenMode.Binary)
					RobotMasterIcon(40) = R4Icon
					
					If R5Present Then
						FileOpen(5, R5path, OpenMode.Binary)
						RobotMasterIcon(50) = R5Icon
						
						If R6Present Then
							FileOpen(6, R6path, OpenMode.Binary)
							RobotMasterIcon(60) = R6Icon
						End If
					End If
				End If
			End If
		End If
		
		For d = 1 To NumberOfRobotsPresent
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(d, RecIconStart, iconrec)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(d, IconsExist, zeroexists)
			
			If IconsExist(1) <> 0 Then 'SHIELD ICON - (ICON1)
				RecordIcon(1) = Space(RecIconStart(2) - RecIconStart(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(d, RecordIcon(1), RecIconStart(1))
				RobotMasterIcon(d * 10 + 1) = LoadRobotIcon(RecordIcon(1))
			Else
				RobotMasterIcon(d * 10 + 1) = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\" & d & "#1.ico")
			End If
			
			For c = 2 To 9
				If IconsExist(c) <> 0 Then 'ICONS 2-8
					RecordIcon(c) = Space(RecIconStart(c + 1) - RecIconStart(c))
					'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					FileGet(d, RecordIcon(c), RecIconStart(c))
					RobotMasterIcon(10 * d + c) = LoadRobotIcon(RecordIcon(c))
				Else
					RobotMasterIcon(10 * d + c) = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\miscdata\NoIcon#" & c & ".ico")
				End If
			Next c
			
			FileClose(d)
		Next d
		
		'SOUNDS
		
		'Robot 1
		FileOpen(1, R1path, OpenMode.Binary)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, RecSoundStart, sndrec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, SoundsExist, soundspresent)
		If SoundsExist(0) <> 0 Then
			ReDim r1s0(RecSoundStart(1) - RecSoundStart(0))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, r1s0, RecSoundStart(0))
			RobotDeathSound(1) = True
		Else
			RobotDeathSound(1) = False
			ReDim r1s0(0)
		End If
		If SoundsExist(1) <> 0 Then
			ReDim r1s1(RecSoundStart(2) - RecSoundStart(1))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, r1s1, RecSoundStart(1))
			RobotCollisionSound(1) = True
		Else
			RobotCollisionSound(1) = False
			ReDim r1s1(0)
		End If
		If SoundsExist(2) <> 0 Then
			ReDim r1s2(RecSoundStart(3) - RecSoundStart(2))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, r1s2, RecSoundStart(2))
			RobotBlockSound(1) = True
		Else
			RobotBlockSound(1) = False
			ReDim r1s2(0)
		End If
		If SoundsExist(3) <> 0 Then
			ReDim r1s3(RecSoundStart(4) - RecSoundStart(3))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, r1s3, RecSoundStart(3))
			RobotHitSound(1) = True
		Else
			RobotHitSound(1) = False
			ReDim r1s3(0)
		End If
		If SoundsExist(4) <> 0 Then
			ReDim r1s4(RecSoundStart(5) - RecSoundStart(4))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, r1s4, RecSoundStart(4))
		Else
			ReDim r1s4(0)
		End If
		If SoundsExist(5) <> 0 Then
			ReDim r1s5(RecSoundStart(6) - RecSoundStart(5))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, r1s5, RecSoundStart(5))
		Else
			ReDim r1s5(0)
		End If
		If SoundsExist(6) <> 0 Then
			ReDim r1s6(RecSoundStart(7) - RecSoundStart(6))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, r1s6, RecSoundStart(6))
		Else
			ReDim r1s6(0)
		End If
		If SoundsExist(7) <> 0 Then
			ReDim r1s7(RecSoundStart(8) - RecSoundStart(7))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, r1s7, RecSoundStart(7))
		Else
			ReDim r1s7(0)
		End If
		If SoundsExist(8) <> 0 Then
			ReDim r1s8(RecSoundStart(9) - RecSoundStart(8))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, r1s8, RecSoundStart(8))
		Else
			ReDim r1s8(0)
		End If
		If SoundsExist(9) <> 0 Then
			ReDim r1s9(RecSoundStart(10) - RecSoundStart(9))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, r1s9, RecSoundStart(9))
		Else
			ReDim r1s9(0)
		End If
		FileClose(1)
		'Robot 2
		If R2Present Then
			FileOpen(1, R2path, OpenMode.Binary)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, RecSoundStart, sndrec)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, SoundsExist, soundspresent)
			If SoundsExist(0) <> 0 Then
				ReDim r2s0(RecSoundStart(1) - RecSoundStart(0))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r2s0, RecSoundStart(0))
				RobotDeathSound(2) = True
			Else
				RobotDeathSound(2) = False
				ReDim r2s0(0)
			End If
			If SoundsExist(1) <> 0 Then
				ReDim r2s1(RecSoundStart(2) - RecSoundStart(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r2s1, RecSoundStart(1))
				RobotCollisionSound(2) = True
			Else
				RobotCollisionSound(2) = False
				ReDim r2s1(0)
			End If
			If SoundsExist(2) <> 0 Then
				ReDim r2s2(RecSoundStart(3) - RecSoundStart(2))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r2s2, RecSoundStart(2))
				RobotBlockSound(2) = True
			Else
				RobotBlockSound(2) = False
				ReDim r2s2(0)
			End If
			If SoundsExist(3) <> 0 Then
				ReDim r2s3(RecSoundStart(4) - RecSoundStart(3))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r2s3, RecSoundStart(3))
				RobotHitSound(2) = True
			Else
				RobotHitSound(2) = False
				ReDim r2s3(0)
			End If
			If SoundsExist(4) <> 0 Then
				ReDim r2s4(RecSoundStart(5) - RecSoundStart(4))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r2s4, RecSoundStart(4))
			Else
				ReDim r2s4(0)
			End If
			If SoundsExist(5) <> 0 Then
				ReDim r2s5(RecSoundStart(6) - RecSoundStart(5))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r2s5, RecSoundStart(5))
			Else
				ReDim r2s5(0)
			End If
			If SoundsExist(6) <> 0 Then
				ReDim r2s6(RecSoundStart(7) - RecSoundStart(6))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r2s6, RecSoundStart(6))
			Else
				ReDim r2s6(0)
			End If
			If SoundsExist(7) <> 0 Then
				ReDim r2s7(RecSoundStart(8) - RecSoundStart(7))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r2s7, RecSoundStart(7))
			Else
				ReDim r2s7(0)
			End If
			If SoundsExist(8) <> 0 Then
				ReDim r2s8(RecSoundStart(9) - RecSoundStart(8))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r2s8, RecSoundStart(8))
			Else
				ReDim r2s8(0)
			End If
			If SoundsExist(9) <> 0 Then
				ReDim r2s9(RecSoundStart(10) - RecSoundStart(9))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r2s9, RecSoundStart(9))
			Else
				ReDim r2s9(0)
			End If
			FileClose(1)
		End If
		
		'Robot 3
		If R3Present Then
			FileOpen(1, R3path, OpenMode.Binary)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, RecSoundStart, sndrec)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, SoundsExist, soundspresent)
			If SoundsExist(0) <> 0 Then
				ReDim r3s0(RecSoundStart(1) - RecSoundStart(0))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r3s0, RecSoundStart(0))
				RobotDeathSound(3) = True
			Else
				RobotDeathSound(3) = False
				ReDim r3s0(0)
			End If
			If SoundsExist(1) <> 0 Then
				ReDim r3s1(RecSoundStart(2) - RecSoundStart(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r3s1, RecSoundStart(1))
				RobotCollisionSound(3) = True
			Else
				RobotCollisionSound(3) = False
				ReDim r3s1(0)
			End If
			If SoundsExist(2) <> 0 Then
				ReDim r3s2(RecSoundStart(3) - RecSoundStart(2))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r3s2, RecSoundStart(2))
				RobotBlockSound(3) = True
			Else
				RobotBlockSound(3) = False
				ReDim r3s2(0)
			End If
			If SoundsExist(3) <> 0 Then
				ReDim r3s3(RecSoundStart(4) - RecSoundStart(3))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r3s3, RecSoundStart(3))
				RobotHitSound(3) = True
			Else
				RobotHitSound(3) = False
				ReDim r3s3(0)
			End If
			If SoundsExist(4) <> 0 Then
				ReDim r3s4(RecSoundStart(5) - RecSoundStart(4))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r3s4, RecSoundStart(4))
			Else
				ReDim r3s4(0)
			End If
			If SoundsExist(5) <> 0 Then
				ReDim r3s5(RecSoundStart(6) - RecSoundStart(5))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r3s5, RecSoundStart(5))
			Else
				ReDim r3s5(0)
			End If
			If SoundsExist(6) <> 0 Then
				ReDim r3s6(RecSoundStart(7) - RecSoundStart(6))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r3s6, RecSoundStart(6))
			Else
				ReDim r3s6(0)
			End If
			If SoundsExist(7) <> 0 Then
				ReDim r3s7(RecSoundStart(8) - RecSoundStart(7))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r3s7, RecSoundStart(7))
			Else
				ReDim r3s7(0)
			End If
			If SoundsExist(8) <> 0 Then
				ReDim r3s8(RecSoundStart(9) - RecSoundStart(8))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r3s8, RecSoundStart(8))
			Else
				ReDim r3s8(0)
			End If
			If SoundsExist(9) <> 0 Then
				ReDim r3s9(RecSoundStart(10) - RecSoundStart(9))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r3s9, RecSoundStart(9))
			Else
				ReDim r3s9(0)
			End If
			FileClose(1)
		End If
		
		'Robot 4
		If R4Present Then
			FileOpen(1, R4path, OpenMode.Binary)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, RecSoundStart, sndrec)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, SoundsExist, soundspresent)
			If SoundsExist(0) <> 0 Then
				ReDim r4s0(RecSoundStart(1) - RecSoundStart(0))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r4s0, RecSoundStart(0))
				RobotDeathSound(4) = True
			Else
				RobotDeathSound(4) = False
				ReDim r4s0(0)
			End If
			If SoundsExist(1) <> 0 Then
				ReDim r4s1(RecSoundStart(2) - RecSoundStart(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r4s1, RecSoundStart(1))
				RobotCollisionSound(4) = True
			Else
				RobotCollisionSound(4) = False
				ReDim r4s1(0)
			End If
			If SoundsExist(2) <> 0 Then
				ReDim r4s2(RecSoundStart(3) - RecSoundStart(2))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r4s2, RecSoundStart(2))
				RobotBlockSound(4) = True
			Else
				RobotBlockSound(4) = False
				ReDim r4s2(0)
			End If
			If SoundsExist(3) <> 0 Then
				ReDim r4s3(RecSoundStart(4) - RecSoundStart(3))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r4s3, RecSoundStart(3))
				RobotHitSound(4) = True
			Else
				RobotHitSound(4) = False
				ReDim r4s3(0)
			End If
			If SoundsExist(4) <> 0 Then
				ReDim r4s4(RecSoundStart(5) - RecSoundStart(4))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r4s4, RecSoundStart(4))
			Else
				ReDim r4s4(0)
			End If
			If SoundsExist(5) <> 0 Then
				ReDim r4s5(RecSoundStart(6) - RecSoundStart(5))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r4s5, RecSoundStart(5))
			Else
				ReDim r4s5(0)
			End If
			If SoundsExist(6) <> 0 Then
				ReDim r4s6(RecSoundStart(7) - RecSoundStart(6))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r4s6, RecSoundStart(6))
			Else
				ReDim r4s6(0)
			End If
			If SoundsExist(7) <> 0 Then
				ReDim r4s7(RecSoundStart(8) - RecSoundStart(7))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r4s7, RecSoundStart(7))
			Else
				ReDim r4s7(0)
			End If
			If SoundsExist(8) <> 0 Then
				ReDim r4s8(RecSoundStart(9) - RecSoundStart(8))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r4s8, RecSoundStart(8))
			Else
				ReDim r4s8(0)
			End If
			If SoundsExist(9) <> 0 Then
				ReDim r4s9(RecSoundStart(10) - RecSoundStart(9))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r4s9, RecSoundStart(9))
			Else
				ReDim r4s9(0)
			End If
			FileClose(1)
		End If
		
		'Robot 5
		If R5Present Then
			FileOpen(1, R5path, OpenMode.Binary)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, RecSoundStart, sndrec)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, SoundsExist, soundspresent)
			If SoundsExist(0) <> 0 Then
				ReDim r5s0(RecSoundStart(1) - RecSoundStart(0))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r5s0, RecSoundStart(0))
				RobotDeathSound(5) = True
			Else
				ReDim r5s0(0)
				RobotDeathSound(5) = False
			End If
			If SoundsExist(1) <> 0 Then
				ReDim r5s1(RecSoundStart(2) - RecSoundStart(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r5s1, RecSoundStart(1))
				RobotCollisionSound(5) = True
			Else
				ReDim r5s1(0)
				RobotCollisionSound(5) = False
			End If
			If SoundsExist(2) <> 0 Then
				ReDim r5s2(RecSoundStart(3) - RecSoundStart(2))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r5s2, RecSoundStart(2))
				RobotBlockSound(5) = True
			Else
				ReDim r5s2(0)
				RobotBlockSound(5) = False
			End If
			If SoundsExist(3) <> 0 Then
				ReDim r5s3(RecSoundStart(4) - RecSoundStart(3))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r5s3, RecSoundStart(3))
				RobotHitSound(5) = True
			Else
				ReDim r5s3(0)
				RobotHitSound(5) = False
			End If
			If SoundsExist(4) <> 0 Then
				ReDim r5s4(RecSoundStart(5) - RecSoundStart(4))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r5s4, RecSoundStart(4))
			Else
				ReDim r5s4(0)
			End If
			If SoundsExist(5) <> 0 Then
				ReDim r5s5(RecSoundStart(6) - RecSoundStart(5))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r5s5, RecSoundStart(5))
			Else
				ReDim r5s5(0)
			End If
			If SoundsExist(6) <> 0 Then
				ReDim r5s6(RecSoundStart(7) - RecSoundStart(6))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r5s6, RecSoundStart(6))
			Else
				ReDim r5s6(0)
			End If
			If SoundsExist(7) <> 0 Then
				ReDim r5s7(RecSoundStart(8) - RecSoundStart(7))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r5s7, RecSoundStart(7))
			Else
				ReDim r5s7(0)
			End If
			If SoundsExist(8) <> 0 Then
				ReDim r5s8(RecSoundStart(9) - RecSoundStart(8))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r5s8, RecSoundStart(8))
			Else
				ReDim r5s8(0)
			End If
			If SoundsExist(9) <> 0 Then
				ReDim r5s9(RecSoundStart(10) - RecSoundStart(9))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r5s9, RecSoundStart(9))
			Else
				ReDim r5s9(0)
			End If
			FileClose(1)
		End If
		
		'Robot 6
		If R6Present Then
			FileOpen(1, R6path, OpenMode.Binary)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, RecSoundStart, sndrec)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(1, SoundsExist, soundspresent)
			If SoundsExist(0) <> 0 Then
				ReDim r6s0(RecSoundStart(1) - RecSoundStart(0))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r6s0, RecSoundStart(0))
				RobotDeathSound(6) = True
			Else
				ReDim r6s0(0)
				RobotDeathSound(6) = False
			End If
			If SoundsExist(1) <> 0 Then
				ReDim r6s1(RecSoundStart(2) - RecSoundStart(1))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r6s1, RecSoundStart(1))
				RobotCollisionSound(6) = True
			Else
				ReDim r6s1(0)
				RobotCollisionSound(6) = False
			End If
			If SoundsExist(2) <> 0 Then
				ReDim r6s2(RecSoundStart(3) - RecSoundStart(2))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r6s2, RecSoundStart(2))
				RobotBlockSound(6) = True
			Else
				ReDim r6s2(0)
				RobotBlockSound(6) = False
			End If
			If SoundsExist(3) <> 0 Then
				ReDim r6s3(RecSoundStart(4) - RecSoundStart(3))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r6s3, RecSoundStart(3))
				RobotHitSound(6) = True
			Else
				ReDim r6s3(0)
				RobotHitSound(6) = False
			End If
			If SoundsExist(4) <> 0 Then
				ReDim r6s4(RecSoundStart(5) - RecSoundStart(4))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r6s4, RecSoundStart(4))
			Else
				ReDim r6s4(0)
			End If
			If SoundsExist(5) <> 0 Then
				ReDim r6s5(RecSoundStart(6) - RecSoundStart(5))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r6s5, RecSoundStart(5))
			Else
				ReDim r6s5(0)
			End If
			If SoundsExist(6) <> 0 Then
				ReDim r6s6(RecSoundStart(7) - RecSoundStart(6))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r6s6, RecSoundStart(6))
			Else
				ReDim r6s6(0)
			End If
			If SoundsExist(7) <> 0 Then
				ReDim r6s7(RecSoundStart(8) - RecSoundStart(7))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r6s7, RecSoundStart(7))
			Else
				ReDim r6s7(0)
			End If
			If SoundsExist(8) <> 0 Then
				ReDim r6s8(RecSoundStart(9) - RecSoundStart(8))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r6s8, RecSoundStart(8))
			Else
				ReDim r6s8(0)
			End If
			If SoundsExist(9) <> 0 Then
				ReDim r6s9(RecSoundStart(10) - RecSoundStart(9))
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, r6s9, RecSoundStart(9))
			Else
				ReDim r6s9(0)
			End If
			FileClose(1)
		End If
	End Sub
	
	Private Sub PlaySnd0(ByRef RNr As Integer)
		Select Case RNr
			Case 1
				If UBound(r1s0) > 0 Then sndPlaySound(r1s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 2
				If UBound(r2s0) > 0 Then sndPlaySound(r2s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 3
				If UBound(r3s0) > 0 Then sndPlaySound(r3s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 4
				If UBound(r4s0) > 0 Then sndPlaySound(r4s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 5
				If UBound(r5s0) > 0 Then sndPlaySound(r5s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 6
				If UBound(r6s0) > 0 Then sndPlaySound(r6s0(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
		End Select
	End Sub
	
	Private Sub PlaySnd1(ByRef RNr As Integer)
		Select Case RNr
			Case 1
				If UBound(r1s1) > 0 Then sndPlaySound(r1s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 2
				If UBound(r2s1) > 0 Then sndPlaySound(r2s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 3
				If UBound(r3s1) > 0 Then sndPlaySound(r3s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 4
				If UBound(r4s1) > 0 Then sndPlaySound(r4s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 5
				If UBound(r5s1) > 0 Then sndPlaySound(r5s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 6
				If UBound(r6s1) > 0 Then sndPlaySound(r6s1(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
		End Select
	End Sub
	
	Private Sub PlaySnd2(ByRef RNr As Integer)
		Select Case RNr
			Case 1
				If UBound(r1s2) > 0 Then sndPlaySound(r1s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 2
				If UBound(r2s2) > 0 Then sndPlaySound(r2s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 3
				If UBound(r3s2) > 0 Then sndPlaySound(r3s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 4
				If UBound(r4s2) > 0 Then sndPlaySound(r4s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 5
				If UBound(r5s2) > 0 Then sndPlaySound(r5s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 6
				If UBound(r6s2) > 0 Then sndPlaySound(r6s2(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
		End Select
	End Sub
	
	Private Sub PlaySnd3(ByRef RNr As Integer)
		Select Case RNr
			Case 1
				If UBound(r1s3) > 0 Then sndPlaySound(r1s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 2
				If UBound(r2s3) > 0 Then sndPlaySound(r2s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 3
				If UBound(r3s3) > 0 Then sndPlaySound(r3s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 4
				If UBound(r4s3) > 0 Then sndPlaySound(r4s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 5
				If UBound(r5s3) > 0 Then sndPlaySound(r5s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 6
				If UBound(r6s3) > 0 Then sndPlaySound(r6s3(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
		End Select
	End Sub
	
	Private Sub PlaySnd4(ByRef RNr As Integer)
		Select Case RNr
			Case 1
				If UBound(r1s4) > 0 Then sndPlaySound(r1s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 2
				If UBound(r2s4) > 0 Then sndPlaySound(r2s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 3
				If UBound(r3s4) > 0 Then sndPlaySound(r3s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 4
				If UBound(r4s4) > 0 Then sndPlaySound(r4s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 5
				If UBound(r5s4) > 0 Then sndPlaySound(r5s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 6
				If UBound(r6s4) > 0 Then sndPlaySound(r6s4(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
		End Select
	End Sub
	
	Private Sub PlaySnd5(ByRef RNr As Integer)
		Select Case RNr
			Case 1
				If UBound(r1s5) > 0 Then sndPlaySound(r1s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 2
				If UBound(r2s5) > 0 Then sndPlaySound(r2s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 3
				If UBound(r3s5) > 0 Then sndPlaySound(r3s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 4
				If UBound(r4s5) > 0 Then sndPlaySound(r4s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 5
				If UBound(r5s5) > 0 Then sndPlaySound(r5s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 6
				If UBound(r6s5) > 0 Then sndPlaySound(r6s5(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
		End Select
	End Sub
	
	Private Sub PlaySnd6(ByRef RNr As Integer)
		Select Case RNr
			Case 1
				If UBound(r1s6) > 0 Then sndPlaySound(r1s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 2
				If UBound(r2s6) > 0 Then sndPlaySound(r2s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 3
				If UBound(r3s6) > 0 Then sndPlaySound(r3s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 4
				If UBound(r4s6) > 0 Then sndPlaySound(r4s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 5
				If UBound(r5s6) > 0 Then sndPlaySound(r5s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 6
				If UBound(r6s6) > 0 Then sndPlaySound(r6s6(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
		End Select
	End Sub
	
	Private Sub PlaySnd7(ByRef RNr As Integer)
		Select Case RNr
			Case 1
				If UBound(r1s7) > 0 Then sndPlaySound(r1s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 2
				If UBound(r2s7) > 0 Then sndPlaySound(r2s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 3
				If UBound(r3s7) > 0 Then sndPlaySound(r3s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 4
				If UBound(r4s7) > 0 Then sndPlaySound(r4s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 5
				If UBound(r5s7) > 0 Then sndPlaySound(r5s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 6
				If UBound(r6s7) > 0 Then sndPlaySound(r6s7(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
		End Select
	End Sub
	
	Private Sub PlaySnd8(ByRef RNr As Integer)
		Select Case RNr
			Case 1
				If UBound(r1s8) > 0 Then sndPlaySound(r1s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 2
				If UBound(r2s8) > 0 Then sndPlaySound(r2s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 3
				If UBound(r3s8) > 0 Then sndPlaySound(r3s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 4
				If UBound(r4s8) > 0 Then sndPlaySound(r4s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 5
				If UBound(r5s8) > 0 Then sndPlaySound(r5s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 6
				If UBound(r6s8) > 0 Then sndPlaySound(r6s8(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
		End Select
	End Sub
	
	Private Sub PlaySnd9(ByRef RNr As Integer)
		Select Case RNr
			Case 1
				If UBound(r1s9) > 0 Then sndPlaySound(r1s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 2
				If UBound(r2s9) > 0 Then sndPlaySound(r2s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 3
				If UBound(r3s9) > 0 Then sndPlaySound(r3s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 4
				If UBound(r4s9) > 0 Then sndPlaySound(r4s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 5
				If UBound(r5s9) > 0 Then sndPlaySound(r5s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
			Case 6
				If UBound(r6s9) > 0 Then sndPlaySound(r6s9(0), SND_MEMORY Or SND_ASYNC Or SND_NODEFAULT)
		End Select
	End Sub
	
	Private Function Range(ByRef RobotWhoChecks As Integer, ByRef AimValue As Integer) As Integer
		'This is David Harris range code, ported to Visual Basic by me.
		Dim counter As Integer
		Dim T As Integer
		Dim dx, dy As Single 'This more similar to what Dave Harris used
		For counter = 1 To NumberOfRobotsPresent
			If counter <> RobotWhoChecks Then 'Skip needless calculations (range to itself allways = 0)
				T = FixSquare((RobotLeft(RobotWhoChecks) - RobotLeft(counter)) * (RobotLeft(RobotWhoChecks) - RobotLeft(counter)) + (RobotTop(RobotWhoChecks) - RobotTop(counter)) * (RobotTop(RobotWhoChecks) - RobotTop(counter)))
				
				dx = Sine(AimValue) * T - RobotLeft(counter) + RobotLeft(RobotWhoChecks)
				dy = RobotTop(RobotWhoChecks) - Cosine(AimValue) * T - RobotTop(counter)
				
				If dx * dx + dy * dy > 91 Then T = 0
				If (T < Range Or Range = 0) And T <> 0 Then
					Range = T
					RangedRobot(RobotWhoChecks) = counter
				End If
			End If
		Next counter
		
		If RobotTeam(RobotWhoChecks) <> 0 Then
			If Range <> 0 Then
				If RobotTeam(RobotWhoChecks) = RobotTeam(RangedRobot(RobotWhoChecks)) Then Range = 0
			End If
		End If
	End Function
	
	Private Function Nearest(ByRef RobotWhoChecks As Integer) As Integer
		Dim T As Integer
		Dim NearestDist As Integer
		Dim counter As Integer
		
		NearestDist = 2147483647
		
		For counter = 1 To NumberOfRobotsPresent
			If counter <> RobotWhoChecks Then 'Skip needless calculations (range to itself allways = 0)
				T = (RobotLeft(RobotWhoChecks) - RobotLeft(counter)) ^ 2 + (RobotTop(RobotWhoChecks) - RobotTop(counter)) ^ 2
				If T < NearestDist Then
					NearestDist = T
					Nearest = counter
				End If
			End If
		Next counter
		
	End Function
	
	'Private Function rrange(RobotWhoChecks As Long, AimValue As Long) As Long
	''intrange is faster than ordinary range, but it returns 601 when nobody is ranged
	'    Dim counter As Long
	'    Dim t As Long
	'    Dim dx As Single, dy As Single
	'
	'    rrange = 601
	'
	'    For counter = 1 To NumberOfRobotsPresent
	'        If counter <> RobotWhoChecks Then   'Skip checking range to self. It'll be too short
	'            t = FixSquare((RobotLeft(RobotWhoChecks) - RobotLeft(counter)) * (RobotLeft(RobotWhoChecks) - RobotLeft(counter)) + (RobotTop(RobotWhoChecks) - RobotTop(counter)) * (RobotTop(RobotWhoChecks) - RobotTop(counter)))
	'            dx = Sine(AimValue) * t - RobotLeft(counter) + RobotLeft(RobotWhoChecks)
	'            dy = RobotTop(RobotWhoChecks) - Cosine(AimValue) * t - RobotTop(counter)
	'
	'            If dx * dx + dy * dy > 91 Then t = 601 'This should be faster
	'
	'            If t < rrange Then
	'                rrange = t
	'                RangedRobot(RobotWhoChecks) = counter
	'            End If
	'        End If
	'    Next counter
	'
	'    If RobotTeam(RobotWhoChecks) <> 0 Then
	'        If rrange <> 601 Then
	'            If RobotTeam(RobotWhoChecks) = RobotTeam(RangedRobot(RobotWhoChecks)) Then rrange = 601
	'        End If
	'    End If
	'End Function
	'Short Radar(robot * who)
	'{
	'    register shot *cur;
	'    register short x,y,theta,scan;
	'    long range,close = 1000000,result;
	'
	'    cur = shots;
	'    x = who->letters[x_];
	'    y = who->letters[y_];
	'    scan = (who->aim+who->scan)%360;
	'    while (cur != NULL) {
	'        if (cur->type != laser) {
	'            theta = (short)(450-atan2(y-cur->yPosInt,cur->xPosInt-x)*radToDeg)%360;
	'            if ((abs(theta-scan) < 20) || (abs(theta-scan) > 340)) {
	'                range = (y-cur->yPosInt)*(long)(y-cur->yPosInt) +
	'                        (x-cur->xPosInt)*(long)(x-cur->xPosInt);
	'                if (range < close) close = range;
	'            }
	'        }
	'        cur = cur->next;
	'    }
	'    if (close == 1000000) result = 0;
	'    else result = sqrt(close);
	'    return result;
	'}
	
	Private Function Radar(ByRef RobotWhoChecks As Integer, ByRef a As Single, ByRef b As Single, ByRef AimValue As Integer) As Integer
		'This function in only called from the debugger. Besides in the debugger, robots calculates radar inline
		Dim theta As Integer
		
		a = RobotLeft(RobotWhoChecks) - Fix(a) 'This is to make sure that we cut floats like C does
		b = RobotTop(RobotWhoChecks) - Fix(b) 'This is absolutely nessecary
		
		If a = 0 Then 'atan2
			theta = 90 * System.Math.Sign(b)
		Else
			theta = TPI * System.Math.Atan(b / -a) - 180 * CShort(a >= 0)
		End If '''''''
		
		theta = System.Math.Abs(450 - theta - AimValue)
		If theta > 359 Then theta = theta - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(theta) = 627
		
		If theta < 20 Or theta > 340 Then '< 19  341 >        '24 och 336
			Radar = FixSquare(a * a + b * b)
		Else
			Radar = 0
		End If
		
	End Function
	
	Private Function Asn(ByRef X As Single) As Single
		Asn = System.Math.Atan(X / System.Math.Sqrt(-X * X + 1))
	End Function
	
	Private Function Acn(ByRef X As Single) As Single
		Acn = System.Math.Atan(-X / System.Math.Sqrt(-X * X + 1)) + 2 * System.Math.Atan(1)
	End Function
	
	Private Function DistBwtn(ByRef cx1 As Integer, ByRef cy1 As Integer, ByRef cx2 As Integer, ByRef cy2 As Integer) As Integer 'long
		DistBwtn = System.Math.Sqrt((cx1 - cx2) ^ 2 + (cy1 - cy2) ^ 2)
		'DistBwtn = Sqr((cx1 - cx2) * (cx1 - cx2) + (cy1 - cy2) * (cy1 - cy2))
	End Function
	
	Public Sub Tutorial_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Tutorial.Click
		ShowTutorial()
	End Sub
	
	Public Sub InizTournament()
		' This is the tournament engine
		' I agree that it's needlessly complicated and messy.
		' The explaination for that is that it was built in parts, it was partitially rebuilt, and it seems to work
		' as it is right now so I don't feel any strong urge to rebuilt it in a less messy version
		' SoloScore( ) is the same thing as the robots solo score
		
		' Bugs
		' It requires 6 robots to run and not 2 as supposed to.
		' You can only choose robots from one folder.
		
		TournamentD.Hide()
		
		If RunningTournament Then MsgBox("You're already running a tournament!",  , "Can't run two tournaments at the same time") : Exit Sub
		
		Dim ClockTime As Single
		ClockTime = VB.Timer()
		
		ClearTeams()
		PrintTournamentLog = TournamentD.PrintLog.CheckState
		If PrintTournamentLog Then ReDim TournamentLog(((TournamentD.RobotList.Items.Count - 1) / 2 * TournamentD.RobotList.Items.Count) * TournamentD.DuelsN + TournamentD.RobotList.Items.Count * TournamentD.GRNumber * 6 + TournamentD.CheckWinnerCircle.CheckState * (15 * (TournamentD.DuelsN * 8 \ 3) + 96 * TournamentD.GRNumber))
		
		Dim TCA As Integer 'integer
		Dim TCB As Integer 'integer
		Dim WhichFight As Integer 'integer
		Dim DuelScore1 As Integer 'integer
		Dim DuelScore2 As Integer 'integer
		TCB = 1
		TCA = 1
		
		RunningTournament = True
		R1Present = True
		R2Present = True
		R3Present = False
		R4Present = False
		R5Present = False
		R6Present = False
		R3Icon.Image = Nothing
		R4Icon.Image = Nothing
		R5Icon.Image = Nothing
		R6Icon.Image = Nothing
		
		Robot3.Text = "No Robot Selected"
		Robot4.Text = "No Robot Selected"
		Robot5.Text = "No Robot Selected"
		Robot6.Text = "No Robot Selected"
		
		Dim counter As Integer
		
		For counter = 3 To 6
			RobotLeft(counter) = -counter * 100
			DR(counter).Visible = False
			EnergyDisplay(counter).Visible = False 'Ny
			ER(counter).Visible = False
		Next counter
		PR3.Visible = False : PR4.Visible = False : PR5.Visible = False : PR6.Visible = False
		Points3X.Visible = False : Points4X.Visible = False : Points5X.Visible = False : Points6X.Visible = False
		Damage3X.Visible = False : Damage4X.Visible = False : Damage5X.Visible = False : Damage6X.Visible = False
		Energy3X.Visible = False : Energy4X.Visible = False : Energy5X.Visible = False : Energy6X.Visible = False
		
		If Not ChronorsLimit.Checked Then ChronorsLimit_Click(ChronorsLimit, New System.EventArgs())
		If VB6.Eqv(TournamentD.CheckEnergy.CheckState = 0, Overloading.Checked) Then Overloading_Click(Overloading, New System.EventArgs())
		If VB6.Eqv(TournamentD.CheckMoveAndShoot.CheckState = 1, MoveAndShoot.Checked) Then MoveAndShoot_Click(MoveAndShoot, New System.EventArgs())
		If VB6.Eqv(TournamentD.CheckScoring.CheckState = 1, StandardScoring) Then Scoring_Click(Scoring, New System.EventArgs())
		If Replaying Then RepeatBattle_Click(RepeatBattle, New System.EventArgs())
		
		ResetHistory_Click(ResetHistory, New System.EventArgs())
		
		
		HighestToLowest = (Int(2 * Rnd()) = 1)
		
		'   Run Tournament
		Dim TournamentSwitch As Integer
		Dim NumberOfGRBattles() As Integer 'long
		Dim GRScore() As Integer 'long
		Dim SoloScore() As Integer
		ReDim SoloScore(TournamentD.RobotList.Items.Count)
		'UPGRADE_WARNING: Lower bound of array RandomRobot was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RandomRobot(6) As Integer
		
		If TournamentD.DuelsN = 0 Then 'If the user has choosed to not run duel
			TCB = TournamentD.RobotList.Items.Count
			WhichFight = TournamentD.DuelsN
		End If
		
		If TournamentD.GRNumber = 0 And SelectedRobot > 2 Then
			SelectedRobot = 1
			Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White
			Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White
			Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White
			Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White
			Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White
			Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
		End If
		
		Dim TotalScore() As Integer
		Dim TournamnetScore As String
		Dim highestscore As Integer
		Dim counter2 As Integer
		Dim ZingGRScore As Double
		Dim WinnerCircleCounter As Integer
		Dim WinnerCircleAddString As String
		Dim WinnerCircleDuels As Integer
		Dim newscore() As String
		'UPGRADE_NOTE: timestring was upgraded to timestring_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim timestring_Renamed As String 'long
		'UPGRADE_WARNING: Lower bound of array Final was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim Final(6) As Integer
		'UPGRADE_WARNING: Lower bound of array WinnerCirleSolo was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim WinnerCirleSolo(6) As Integer
		'UPGRADE_WARNING: Lower bound of array WinnerCircleNumbers was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim WinnerCircleNumbers(6) As Integer ' long
		Do While RunningTournament
			If TournamentSwitch = 1 Then
				If TournamentD.GRNumber <> 0 Then
					If TCB Mod 6 = 0 Then 'Load new robots
						GRScore(RandomRobot(1)) = GRScore(RandomRobot(1)) + CDbl(PR1.Text)
						GRScore(RandomRobot(2)) = GRScore(RandomRobot(2)) + CDbl(PR2.Text)
						GRScore(RandomRobot(3)) = GRScore(RandomRobot(3)) + CDbl(PR3.Text)
						GRScore(RandomRobot(4)) = GRScore(RandomRobot(4)) + CDbl(PR4.Text)
						GRScore(RandomRobot(5)) = GRScore(RandomRobot(5)) + CDbl(PR5.Text)
						GRScore(RandomRobot(6)) = GRScore(RandomRobot(6)) + CDbl(PR6.Text)
						
						RandomRobot(1) = Int(TournamentD.RobotList.Items.Count * Rnd())
						NumberOfGRBattles(RandomRobot(1)) = NumberOfGRBattles(RandomRobot(1)) + 1
redorandom2: 
						RandomRobot(2) = Int(TournamentD.RobotList.Items.Count * Rnd())
						If RandomRobot(2) = RandomRobot(1) Then GoTo redorandom2
						NumberOfGRBattles(RandomRobot(2)) = NumberOfGRBattles(RandomRobot(2)) + 1
redorandom3: 
						RandomRobot(3) = Int(TournamentD.RobotList.Items.Count * Rnd())
						If RandomRobot(3) = RandomRobot(1) Or RandomRobot(3) = RandomRobot(2) Then GoTo redorandom3
						NumberOfGRBattles(RandomRobot(3)) = NumberOfGRBattles(RandomRobot(3)) + 1
redorandom4: 
						RandomRobot(4) = Int(TournamentD.RobotList.Items.Count * Rnd())
						If RandomRobot(4) = RandomRobot(1) Or RandomRobot(4) = RandomRobot(3) Or RandomRobot(4) = RandomRobot(2) Then GoTo redorandom4
						NumberOfGRBattles(RandomRobot(4)) = NumberOfGRBattles(RandomRobot(4)) + 1
redorandom5: 
						RandomRobot(5) = Int(TournamentD.RobotList.Items.Count * Rnd())
						If RandomRobot(5) = RandomRobot(1) Or RandomRobot(5) = RandomRobot(4) Or RandomRobot(5) = RandomRobot(3) Or RandomRobot(5) = RandomRobot(2) Then GoTo redorandom5
						NumberOfGRBattles(RandomRobot(5)) = NumberOfGRBattles(RandomRobot(5)) + 1
redorandom6: 
						RandomRobot(6) = Int(TournamentD.RobotList.Items.Count * Rnd()) ' + 1
						If RandomRobot(6) = RandomRobot(1) Or RandomRobot(6) = RandomRobot(5) Or RandomRobot(6) = RandomRobot(4) Or RandomRobot(6) = RandomRobot(3) Or RandomRobot(6) = RandomRobot(2) Then GoTo redorandom6
						NumberOfGRBattles(RandomRobot(6)) = NumberOfGRBattles(RandomRobot(6)) + 1
						
						Robot1.Text = VB6.GetItemString(TournamentD.RobotList, RandomRobot(1))
						R1path = VB6.GetItemString(TournamentD.TheDirList, RandomRobot(1)) & "\" & VB6.GetItemString(TournamentD.RobotList, RandomRobot(1)) & ".RWR"
						LoadRobot1()
						Robot2.Text = VB6.GetItemString(TournamentD.RobotList, RandomRobot(2))
						R2path = VB6.GetItemString(TournamentD.TheDirList, RandomRobot(2)) & "\" & VB6.GetItemString(TournamentD.RobotList, RandomRobot(2)) & ".RWR"
						LoadRobot2()
						Robot3.Text = VB6.GetItemString(TournamentD.RobotList, RandomRobot(3))
						R3path = VB6.GetItemString(TournamentD.TheDirList, RandomRobot(3)) & "\" & VB6.GetItemString(TournamentD.RobotList, RandomRobot(3)) & ".RWR"
						LoadRobot3()
						Robot4.Text = VB6.GetItemString(TournamentD.RobotList, RandomRobot(4))
						R4path = VB6.GetItemString(TournamentD.TheDirList, RandomRobot(4)) & "\" & VB6.GetItemString(TournamentD.RobotList, RandomRobot(4)) & ".RWR"
						LoadRobot4()
						Robot5.Text = VB6.GetItemString(TournamentD.RobotList, RandomRobot(5))
						R5path = VB6.GetItemString(TournamentD.TheDirList, RandomRobot(5)) & "\" & VB6.GetItemString(TournamentD.RobotList, RandomRobot(5)) & ".RWR"
						LoadRobot5()
						Robot6.Text = VB6.GetItemString(TournamentD.RobotList, RandomRobot(6))
						R6path = VB6.GetItemString(TournamentD.TheDirList, RandomRobot(6)) & "\" & VB6.GetItemString(TournamentD.RobotList, RandomRobot(6)) & ".RWR"
						LoadRobot6()
						
						PR1.Text = CStr(0) : PR2.Text = CStr(0) : PR3.Text = CStr(0) : PR4.Text = CStr(0) : PR5.Text = CStr(0) : PR6.Text = CStr(0)
						For counter = 1 To 50
							HistoryRec(1, counter) = 0 : HistoryRec(2, counter) = 0 : HistoryRec(3, counter) = 0 : HistoryRec(4, counter) = 0 : HistoryRec(5, counter) = 0 : HistoryRec(6, counter) = 0
						Next counter
					End If
					
					TCB = TCB + 1
					If WindowMini Then
						sMainWindowCaption = "RoboWar 5 - Tournament: GroupRound " & TCB & " of " & TournamentD.RobotList.Items.Count * TournamentD.GRNumber * 6 & " is running."
					Else
						Me.Text = "RoboWar 5 - Tournament: GroupRound " & TCB & " of " & TournamentD.RobotList.Items.Count * TournamentD.GRNumber * 6 & " is running."
					End If
					
					BattleHaltButton_Click(BattleHaltButton, New System.EventArgs())
				Else
					TCB = TournamentD.RobotList.Items.Count * TournamentD.GRNumber * 6
				End If
				
				If TCB = TournamentD.RobotList.Items.Count * TournamentD.GRNumber * 6 Then
					'            'Tournament is over, showing score
					ReDim TotalScore(TournamentD.RobotList.Items.Count)
					
					
					If TournamentD.DuelsN <> 0 And TournamentD.GRNumber <> 0 Then
						For counter = 0 To TournamentD.RobotList.Items.Count - 1
							'    if (numDuels > 0) roster[i].groupScore *= numDuels*(numEntries-1)/
							'                                                          (2.0*groupBouts*roster[i].numGroupFights);
							ZingGRScore = GRScore(counter)
							'                             - NEW - Camden's formula - Works with all rations, not just 10/6
							'                ZingGRScore = ZingGRScore * ((TournamentD.RobotList.ListCount - 1) * TournamentD.DuelsN / (12 * NumberOfGRBattles(counter)))
							
							ZingGRScore = ZingGRScore * TournamentD.DuelsN / (12 * NumberOfGRBattles(counter)) 'Same as above
							ZingGRScore = ZingGRScore * (TournamentD.RobotList.Items.Count - 1) 'but splitted to avoid overflow bugs
							
							GRScore(counter) = ZingGRScore
							
							TotalScore(counter) = GRScore(counter) + SoloScore(counter)
						Next counter
					ElseIf TournamentD.DuelsN = 0 Then 
						For counter = 0 To TournamentD.RobotList.Items.Count - 1
							ZingGRScore = GRScore(counter) 'BUG ALERT!!    BUG ALERT!!     är dethär samma som Macversionen?
							ZingGRScore = ZingGRScore * TournamentD.GRNumber / (12 * NumberOfGRBattles(counter)) 'ZingGRScore / (12 * NumberOfGRBattles(counter))
							ZingGRScore = ZingGRScore * (TournamentD.RobotList.Items.Count - 1) 'but splitted to avoid overflow bugs
							GRScore(counter) = ZingGRScore
							TotalScore(counter) = GRScore(counter) + SoloScore(counter)
						Next counter
					Else
						For counter = 0 To TournamentD.RobotList.Items.Count - 1
							TotalScore(counter) = SoloScore(counter)
						Next counter
					End If
					
					
					For counter2 = 0 To TournamentD.RobotList.Items.Count - 1
						For counter = 0 To TournamentD.RobotList.Items.Count - 1
							If TotalScore(counter) > TotalScore(highestscore) Then highestscore = counter
						Next counter
						
						If WinnerCircleCounter < 6 Then
							WinnerCircleCounter = WinnerCircleCounter + 1
							WinnerCircleNumbers(WinnerCircleCounter) = highestscore
						End If
						'Kolla hur långt namnet är
						TournamnetScore = TournamnetScore & vbCr & TFixTabs2(VB6.GetItemString(TournamentD.RobotList, highestscore)) & vbTab & SoloScore(highestscore) & vbTab & GRScore(highestscore) & vbTab & TotalScore(highestscore)
						TotalScore(highestscore) = -1
					Next counter2
					
					
					If TournamentD.CheckWinnerCircle.CheckState = 1 Then 'Runs Winner circle if set to do so
						If TournamentD.DuelsN <> 0 Then
							
							TCB = 1 : TCA = 1 : WhichFight = 0
							R3Present = False : R4Present = False : R5Present = False : R6Present = False : ResetHistory_Click(ResetHistory, New System.EventArgs())
							R3Icon.Image = Nothing : R4Icon.Image = Nothing : R5Icon.Image = Nothing : R6Icon.Image = Nothing
							Robot3.Text = "No Robot Selected" : Robot4.Text = "No Robot Selected" : Robot5.Text = "No Robot Selected" : Robot6.Text = "No Robot Selected"
							For counter = 3 To 6
								RobotLeft(counter) = -counter * 100 : DR(counter).Visible = False : EnergyDisplay(counter).Visible = False : ER(counter).Visible = False
							Next counter
							PR3.Visible = False : PR4.Visible = False : PR5.Visible = False : PR6.Visible = False
							Points3X.Visible = False : Points4X.Visible = False : Points5X.Visible = False : Points6X.Visible = False
							Damage3X.Visible = False : Damage4X.Visible = False : Damage5X.Visible = False : Damage6X.Visible = False
							Energy3X.Visible = False : Energy4X.Visible = False : Energy5X.Visible = False : Energy6X.Visible = False
							
							WinnerCircleDuels = TournamentD.DuelsN * 8 \ 3
							
							Do While RunningTournament
								If TCB >= 6 And WhichFight >= WinnerCircleDuels Then
									Exit Do
								ElseIf WhichFight >= WinnerCircleDuels Or WhichFight = 0 Then  'Loading Robots
									PR1.Text = CStr(0)
									PR2.Text = CStr(0)
									
									For counter = 1 To 50
										HistoryRec(1, counter) = 0 : HistoryRec(2, counter) = 0
									Next counter
									
									TCA = TCA + 1
									
									Robot1.Text = VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(TCB))
									R1path = VB6.GetItemString(TournamentD.TheDirList, WinnerCircleNumbers(TCB)) & "\" & VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(TCB)) & ".RWR"
									LoadRobot1()
									
									Robot2.Text = VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(TCA))
									R2path = VB6.GetItemString(TournamentD.TheDirList, WinnerCircleNumbers(TCA)) & "\" & VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(TCA)) & ".RWR"
									LoadRobot2()
									
									DuelScore1 = TCB
									DuelScore2 = TCA 'Set which to give score after rond WinnerCircleDuels
									
									If TCA = 6 Then '6
										TCA = TCB + 1
										TCB = TCB + 1
									End If
									WhichFight = 1
								Else
									WhichFight = WhichFight + 1
								End If
								
								If WindowMini Then
									sMainWindowCaption = "RoboWar 5 - Tournament: Winner Circle - Robot " & DuelScore1 & " vs Robot " & DuelScore2 & " - Round " & WhichFight & " of " & WinnerCircleDuels
								Else
									Me.Text = "RoboWar 5 - Tournament: Winner Circle - Robot " & DuelScore1 & " vs Robot " & DuelScore2 & " - Round " & WhichFight & " of " & WinnerCircleDuels
								End If
								
								BattleHaltButton_Click(BattleHaltButton, New System.EventArgs())
								If WhichFight >= WinnerCircleDuels Then
									WinnerCirleSolo(DuelScore1) = WinnerCirleSolo(DuelScore1) + CDbl(PR1.Text)
									WinnerCirleSolo(DuelScore2) = WinnerCirleSolo(DuelScore2) + CDbl(PR2.Text)
								End If
							Loop 
						End If 'Solo If
						'WC Group
						
						If TournamentD.GRNumber <> 0 Then
							R3Present = True : R4Present = True : R5Present = True : R6Present = True : PR1.Text = CStr(0) : PR2.Text = CStr(0)
							For counter = 1 To 50
								HistoryRec(1, counter) = 0 : HistoryRec(2, counter) = 0
							Next counter
							
							Robot1.Text = VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(1))
							R1path = VB6.GetItemString(TournamentD.TheDirList, WinnerCircleNumbers(1)) & "\" & VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(1)) & ".RWR"
							LoadRobot1()
							Robot2.Text = VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(2))
							R2path = VB6.GetItemString(TournamentD.TheDirList, WinnerCircleNumbers(2)) & "\" & VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(2)) & ".RWR"
							LoadRobot2()
							Robot3.Text = VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(3))
							R3path = VB6.GetItemString(TournamentD.TheDirList, WinnerCircleNumbers(3)) & "\" & VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(3)) & ".RWR"
							LoadRobot3()
							Robot4.Text = VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(4))
							R4path = VB6.GetItemString(TournamentD.TheDirList, WinnerCircleNumbers(4)) & "\" & VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(4)) & ".RWR"
							LoadRobot4()
							Robot5.Text = VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(5))
							R5path = VB6.GetItemString(TournamentD.TheDirList, WinnerCircleNumbers(5)) & "\" & VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(5)) & ".RWR"
							LoadRobot5()
							Robot6.Text = VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(6))
							R6path = VB6.GetItemString(TournamentD.TheDirList, WinnerCircleNumbers(6)) & "\" & VB6.GetItemString(TournamentD.RobotList, WinnerCircleNumbers(6)) & ".RWR"
							LoadRobot6()
							
							For counter = 1 To 96 * TournamentD.GRNumber '6 * 16 = 96
								If Not RunningTournament Then Exit For
								
								If WindowMini Then
									sMainWindowCaption = "RoboWar 5 - Tournament: Winner Circle Group - Battle " & counter & " of " & 96 * TournamentD.GRNumber
								Else
									Me.Text = "RoboWar 5 - Tournament: Winner Circle Group - Battle " & counter & " of " & 96 * TournamentD.GRNumber
								End If
								
								BattleHaltButton_Click(BattleHaltButton, New System.EventArgs())
							Next counter
						End If
						
						WinnerCircleAddString = vbTab & "WC Solo" & vbTab & "WC Group" & vbTab & "Final"
						
						'Normalizing Winners' Cirle Group
						'                    roster[circle[i]].soloFinal *= (numEntries -1) * 3 / 80.0;
						'                    roster[circle[i]].groupFinal *= (numEntries -1)*numDuels /
						'                                                    (4.0*groupBouts*roster[circle[i]].numGroupFights);
						'    Scale factor to make group final = 1/2 individual score:
						'        numDuels*(n-1) / (12*rounds participating)
						
						If TournamentD.DuelsN <> 0 And TournamentD.GRNumber <> 0 Then
							PR1.Text = CStr(Fix(CDbl(PR1.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber)))
							PR2.Text = CStr(Fix(CDbl(PR2.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber)))
							PR3.Text = CStr(Fix(CDbl(PR3.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber)))
							PR4.Text = CStr(Fix(CDbl(PR4.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber)))
							PR5.Text = CStr(Fix(CDbl(PR5.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber)))
							PR6.Text = CStr(Fix(CDbl(PR6.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.DuelsN / (384 * TournamentD.GRNumber)))
						ElseIf TournamentD.DuelsN = 0 Then 
							PR1.Text = CStr(Fix(CDbl(PR1.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber))) 'BUG ALERT!!    BUG ALERT!!
							PR2.Text = CStr(Fix(CDbl(PR2.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber))) 'Gör Mac versionen såhär?
							PR3.Text = CStr(Fix(CDbl(PR3.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber)))
							PR4.Text = CStr(Fix(CDbl(PR4.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber)))
							PR5.Text = CStr(Fix(CDbl(PR5.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber)))
							PR6.Text = CStr(Fix(CDbl(PR6.Text) * (TournamentD.RobotList.Items.Count - 1) * TournamentD.GRNumber / (384 * TournamentD.GRNumber)))
						Else
							PR1.Text = CStr(0)
							PR2.Text = CStr(0)
						End If
						
						'Normalizing Winners' Cirle Solo
						'roster[circle[i]].soloFinal *= (numEntries -1) * 3 / 80.0;
						For counter = 1 To 6
							WinnerCirleSolo(counter) = Fix(WinnerCirleSolo(counter) * (TournamentD.RobotList.Items.Count - 1) * 3 / 80) '80
						Next counter
						
						Final(1) = GRScore(WinnerCircleNumbers(1)) + SoloScore(WinnerCircleNumbers(1)) + CDbl(PR1.Text) + WinnerCirleSolo(1)
						Final(2) = GRScore(WinnerCircleNumbers(2)) + SoloScore(WinnerCircleNumbers(2)) + CDbl(PR2.Text) + WinnerCirleSolo(2)
						Final(3) = GRScore(WinnerCircleNumbers(3)) + SoloScore(WinnerCircleNumbers(3)) + CDbl(PR3.Text) + WinnerCirleSolo(3)
						Final(4) = GRScore(WinnerCircleNumbers(4)) + SoloScore(WinnerCircleNumbers(4)) + CDbl(PR4.Text) + WinnerCirleSolo(4)
						Final(5) = GRScore(WinnerCircleNumbers(5)) + SoloScore(WinnerCircleNumbers(5)) + CDbl(PR5.Text) + WinnerCirleSolo(5)
						Final(6) = GRScore(WinnerCircleNumbers(6)) + SoloScore(WinnerCircleNumbers(6)) + CDbl(PR6.Text) + WinnerCirleSolo(6)
						
						newscore = Split(TournamnetScore, vbCr)
						newscore(1) = newscore(1) & vbTab & WinnerCirleSolo(1) & vbTab & vbTab & PR1.Text & vbTab & vbTab & Final(1)
						newscore(2) = newscore(2) & vbTab & WinnerCirleSolo(2) & vbTab & vbTab & PR2.Text & vbTab & vbTab & Final(2)
						
						If Final(2) > Final(1) Then
							TournamnetScore = newscore(1) : newscore(1) = newscore(2) : newscore(2) = TournamnetScore : counter = Final(1) : Final(1) = Final(2) : Final(2) = counter
						End If
						
						newscore(3) = newscore(3) & vbTab & WinnerCirleSolo(3) & vbTab & vbTab & PR3.Text & vbTab & vbTab & Final(3)
						
						If Final(3) > Final(2) Then
							TournamnetScore = newscore(2) : newscore(2) = newscore(3) : newscore(3) = TournamnetScore : counter = Final(2) : Final(2) = Final(3) : Final(3) = counter
						End If
						If Final(2) > Final(1) Then
							TournamnetScore = newscore(1) : newscore(1) = newscore(2) : newscore(2) = TournamnetScore : counter = Final(1) : Final(1) = Final(2) : Final(2) = counter
						End If
						
						newscore(4) = newscore(4) & vbTab & WinnerCirleSolo(4) & vbTab & vbTab & PR4.Text & vbTab & vbTab & Final(4)
						
						If Final(4) > Final(3) Then
							TournamnetScore = newscore(3) : newscore(3) = newscore(4) : newscore(4) = TournamnetScore : counter = Final(3) : Final(3) = Final(4) : Final(4) = counter
						End If
						If Final(3) > Final(2) Then
							TournamnetScore = newscore(2) : newscore(2) = newscore(3) : newscore(3) = TournamnetScore : counter = Final(2) : Final(2) = Final(3) : Final(3) = counter
						End If
						If Final(2) > Final(1) Then
							TournamnetScore = newscore(1) : newscore(1) = newscore(2) : newscore(2) = TournamnetScore : counter = Final(1) : Final(1) = Final(2) : Final(2) = counter
						End If
						
						newscore(5) = newscore(5) & vbTab & WinnerCirleSolo(5) & vbTab & vbTab & PR5.Text & vbTab & vbTab & Final(5)
						
						If Final(5) > Final(4) Then
							TournamnetScore = newscore(4) : newscore(4) = newscore(5) : newscore(5) = TournamnetScore : counter = Final(4) : Final(4) = Final(5) : Final(5) = counter
						End If
						If Final(4) > Final(3) Then
							TournamnetScore = newscore(3) : newscore(3) = newscore(4) : newscore(4) = TournamnetScore : counter = Final(3) : Final(3) = Final(4) : Final(4) = counter
						End If
						If Final(3) > Final(2) Then
							TournamnetScore = newscore(2) : newscore(2) = newscore(3) : newscore(3) = TournamnetScore : counter = Final(2) : Final(2) = Final(3) : Final(3) = counter
						End If
						If Final(2) > Final(1) Then
							TournamnetScore = newscore(1) : newscore(1) = newscore(2) : newscore(2) = TournamnetScore : counter = Final(1) : Final(1) = Final(2) : Final(2) = counter
						End If
						
						newscore(6) = newscore(6) & vbTab & WinnerCirleSolo(6) & vbTab & vbTab & PR6.Text & vbTab & vbTab & Final(6)
						
						If Final(6) > Final(5) Then
							TournamnetScore = newscore(5) : newscore(5) = newscore(6) : newscore(6) = TournamnetScore : counter = Final(5) : Final(5) = Final(6) : Final(6) = counter
						End If
						If Final(5) > Final(4) Then
							TournamnetScore = newscore(4) : newscore(4) = newscore(5) : newscore(5) = TournamnetScore : counter = Final(4) : Final(4) = Final(5) : Final(5) = counter
						End If
						If Final(4) > Final(3) Then
							TournamnetScore = newscore(3) : newscore(3) = newscore(4) : newscore(4) = TournamnetScore : counter = Final(3) : Final(3) = Final(4) : Final(4) = counter
						End If
						If Final(3) > Final(2) Then
							TournamnetScore = newscore(2) : newscore(2) = newscore(3) : newscore(3) = TournamnetScore : counter = Final(2) : Final(2) = Final(3) : Final(3) = counter
						End If
						If Final(2) > Final(1) Then
							TournamnetScore = newscore(1) : newscore(1) = newscore(2) : newscore(2) = TournamnetScore : counter = Final(1) : Final(1) = Final(2) : Final(2) = counter
						End If
						
						TournamnetScore = ""
						
						For counter = 1 To UBound(newscore)
							TournamnetScore = TournamnetScore & vbCr & newscore(counter)
						Next counter
					End If
					'End Winner circle
					ClockTime = System.Math.Round((VB.Timer() - ClockTime) / 60, 1)
					timestring_Renamed = Today & ", " & TimeOfDay
					
					TournamnetScore = "Name" & vbTab & vbTab & vbTab & "Solo" & vbTab & "Group" & vbTab & "Total" & WinnerCircleAddString & TournamnetScore
					
					TournamentResults.TheTournamentResults = TournamnetScore
					VB6.ShowForm(TournamentResults, 1, Me)
					
					TournamnetScore = Replace(TournamnetScore, "Name" & vbTab & vbTab & vbTab, "Name" & New String(vbTab, 5))
					TournamnetScore = TournamnetScore & vbCr & vbCr & vbCr & "********" & vbCr & vbCr & "Tournament completed " & timestring_Renamed & vbCr & "Completed in " & ClockTime & " minutes " & vbCr & "Duels " & TournamentD.DuelsN & " - Groups " & TournamentD.GRNumber & vbCr & Scoring.Text & vbCr & "RoboWar Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
					
					FileOpen(30, TournamentD.SavedInFolder.Text, OpenMode.Output)
					PrintLine(30, TournamnetScore)
					FileClose(30)
					
					If TournamentD.GRNumber <> 0 Then
						Load2.Visible = True : Load3.Visible = True : Load4.Visible = True : Load5.Visible = True : Load6.Visible = True
					Else
						Load2.Visible = True : Load3.Visible = True : Load4.Visible = False : Load5.Visible = False : Load6.Visible = False
						R3Present = False : R4Present = False : R5Present = False : R6Present = False
					End If
					
					RunningTournament = False
					TitleTimer.Enabled = False
					Me.Text = "RoboWar 5 - Arena"
					StopTournament.Visible = False
					BattleHaltButton.Visible = True
					BattleHaltButton.Focus()
					FileMenu.Enabled = True
					ArenaMenu.Enabled = True
					ViewMenu.Enabled = True
					
					If PrintTournamentLog Then ProcessLog()
					
					Exit Sub
				End If
			ElseIf TCB >= TournamentD.RobotList.Items.Count And WhichFight >= TournamentD.DuelsN Then  'End Tournament
				'Duels are over iniz grouprounds
				TournamentSwitch = 1
				TCA = 0
				TCB = 0
				
				R3Present = True : R4Present = True : R5Present = True : R6Present = True
				
				ReDim NumberOfGRBattles(TournamentD.RobotList.Items.Count)
				ReDim GRScore(TournamentD.RobotList.Items.Count)
				
				PR1.Text = CStr(0) : PR2.Text = CStr(0)
				For counter = 1 To 50
					HistoryRec(1, counter) = 0 : HistoryRec(2, counter) = 0
				Next counter
			ElseIf WhichFight >= TournamentD.DuelsN Or WhichFight = 0 Then  'Loading Robots
				PR1.Text = CStr(0)
				PR2.Text = CStr(0)
				
				For counter = 1 To 50
					HistoryRec(1, counter) = 0 : HistoryRec(2, counter) = 0
				Next counter
				
				TCA = TCA + 1
				
				Robot1.Text = VB6.GetItemString(TournamentD.RobotList, TCB - 1)
				R1path = VB6.GetItemString(TournamentD.TheDirList, TCB - 1) & "\" & VB6.GetItemString(TournamentD.RobotList, TCB - 1) & ".RWR"
				LoadRobot1()
				
				Robot2.Text = VB6.GetItemString(TournamentD.RobotList, TCA - 1)
				R2path = VB6.GetItemString(TournamentD.TheDirList, TCA - 1) & "\" & VB6.GetItemString(TournamentD.RobotList, TCA - 1) & ".RWR"
				LoadRobot2()
				
				DuelScore1 = TCB - 1 'Set which to give score after rond TournamentD.DuelsN
				DuelScore2 = TCA - 1 'Set which to give score after rond TournamentD.DuelsN
				
				If TCA = TournamentD.RobotList.Items.Count Then
					TCA = TCB + 1
					TCB = TCB + 1
				End If
				WhichFight = 1
			Else
				WhichFight = WhichFight + 1
			End If
			
			If TournamentSwitch = 0 Then
				If WindowMini Then
					sMainWindowCaption = "RoboWar 5 - Tournament: Duel " & (2 * TournamentD.RobotList.Items.Count - DuelScore1 - 1) * DuelScore1 \ 2 + DuelScore2 - DuelScore1 & " of " & (TournamentD.RobotList.Items.Count - 1) / 2 * TournamentD.RobotList.Items.Count & " - Round " & WhichFight & " of " & TournamentD.DuelsN
				Else
					Me.Text = "RoboWar 5 - Tournament: Duel " & (2 * TournamentD.RobotList.Items.Count - DuelScore1 - 1) * DuelScore1 \ 2 + DuelScore2 - DuelScore1 & " of " & (TournamentD.RobotList.Items.Count - 1) / 2 * TournamentD.RobotList.Items.Count & " - Round " & WhichFight & " of " & TournamentD.DuelsN
				End If
				
				BattleHaltButton_Click(BattleHaltButton, New System.EventArgs())
				If WhichFight >= TournamentD.DuelsN Then
					SoloScore(DuelScore1) = SoloScore(DuelScore1) + CDbl(PR1.Text)
					SoloScore(DuelScore2) = SoloScore(DuelScore2) + CDbl(PR2.Text)
				End If
			End If
		Loop 
		
	End Sub
	
	Private Sub StopTournament_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles StopTournament.Click
		If MsgBox("Are you sure?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Stop the Tournament") = MsgBoxResult.No Then Exit Sub
		
		RunningTournament = False
		TitleTimer.Enabled = False
		StopTournament.Visible = False
		TitleTimer.Enabled = False
		Me.Text = "RoboWar 5 - Arena"
		BattleHaltButton.Visible = True
		
		Load2.Visible = True
		Load3.Visible = True
		
		If R6Present Then
			Load4.Visible = True
			Load5.Visible = True
			Load6.Visible = True
		Else
			Load4.Visible = False
			Load5.Visible = False
			Load6.Visible = False
		End If
		
		If PrintTournamentLog Then
			PrintTournamentLog = False
			Erase TournamentLog
			LogWhichBattle = 0
		End If
		
		If BattleHaltButton.Text = "Halt" Then BattleHaltButton_Click(BattleHaltButton, New System.EventArgs())
	End Sub
	
	Public Sub InizTeamTournament()
		TournamentD.Hide()
		
		If RunningTournament Then MsgBox("You're already running a tournament!",  , "Can't run two tournaments at the same time") : Exit Sub
		
		Dim ClockTime As Single
		ClockTime = VB.Timer()
		
		PrintTournamentLog = TournamentD.PrintLog.CheckState
		If PrintTournamentLog Then ReDim TournamentLog(((TournamentD.RobotList.Items.Count \ 3 - 1) / 2 * (TournamentD.RobotList.Items.Count \ 3)) * TournamentD.DuelsN)
		
		RunningTournament = True
		R1Present = True : R2Present = True : R3Present = True : R4Present = True : R5Present = True : R6Present = True
		AutoSetTeams()
		
		PR1.Visible = False : PR2.Visible = False : PR3.Visible = False : PR4.Visible = False : PR5.Visible = False : PR6.Visible = False
		Points1X.Visible = False : Points2X.Visible = False : Points3X.Visible = False : Points4X.Visible = False : Points5X.Visible = False : Points6X.Visible = False
		Damage1X.Visible = False : Damage2X.Visible = False : Damage3X.Visible = False : Damage4X.Visible = False : Damage5X.Visible = False : Damage6X.Visible = False
		Energy1X.Visible = False : Energy2X.Visible = False : Energy3X.Visible = False : Energy4X.Visible = False : Energy5X.Visible = False : Energy6X.Visible = False
		
		If Not ChronorsLimit.Checked Then ChronorsLimit_Click(ChronorsLimit, New System.EventArgs())
		If Replaying Then RepeatBattle_Click(RepeatBattle, New System.EventArgs())
		If VB6.Eqv(TestTourney.MandS.CheckState = 1, MoveAndShoot.Checked) Then MoveAndShoot_Click(MoveAndShoot, New System.EventArgs())
		If VB6.Eqv(TestTourney.CheckScoring.CheckState = 1, StandardScoring) Then Scoring_Click(Scoring, New System.EventArgs())
		
		ResetHistory_Click(ResetHistory, New System.EventArgs())
		
		HighestToLowest = (Int(2 * Rnd()) = 1)
		
		Dim TCA As Integer
		Dim TCB As Integer
		Dim BattleNumber As Integer
		
		Dim Score() As Integer
		ReDim Score(TournamentD.RobotList.Items.Count)
		
		For TCA = 0 To TournamentD.RobotList.Items.Count - 3 Step 3
			
			Robot1.Text = VB6.GetItemString(TournamentD.RobotList, TCA)
			R1path = VB6.GetItemString(TournamentD.TheDirList, TCA) & "\" & VB6.GetItemString(TournamentD.RobotList, TCA) & ".RWR"
			LoadRobot1()
			
			Robot2.Text = VB6.GetItemString(TournamentD.RobotList, TCA + 1)
			R2path = VB6.GetItemString(TournamentD.TheDirList, TCA + 1) & "\" & VB6.GetItemString(TournamentD.RobotList, TCA + 1) & ".RWR"
			LoadRobot2()
			
			Robot3.Text = VB6.GetItemString(TournamentD.RobotList, TCA + 2)
			R3path = VB6.GetItemString(TournamentD.TheDirList, TCA + 2) & "\" & VB6.GetItemString(TournamentD.RobotList, TCA + 2) & ".RWR"
			LoadRobot3()
			
			For TCB = TCA + 3 To TournamentD.RobotList.Items.Count - 2 Step 3
				Robot4.Text = VB6.GetItemString(TournamentD.RobotList, TCB)
				R4path = VB6.GetItemString(TournamentD.TheDirList, TCB) & "\" & VB6.GetItemString(TournamentD.RobotList, TCB) & ".RWR"
				LoadRobot4()
				
				Robot5.Text = VB6.GetItemString(TournamentD.RobotList, TCB + 1)
				R5path = VB6.GetItemString(TournamentD.TheDirList, TCB + 1) & "\" & VB6.GetItemString(TournamentD.RobotList, TCB + 1) & ".RWR"
				LoadRobot5()
				
				Robot6.Text = VB6.GetItemString(TournamentD.RobotList, TCB + 2)
				R6path = VB6.GetItemString(TournamentD.TheDirList, TCB + 2) & "\" & VB6.GetItemString(TournamentD.RobotList, TCB + 2) & ".RWR"
				LoadRobot6()
				
				For BattleNumber = 1 To TournamentD.DuelsN
					If Not RunningTournament Then Exit Sub
					Me.Text = "RoboWar 5 - Tournament: Team " & (TCA \ 3 + 1) & " vs Team " & (TCB \ 3 + 1) & " - Duel " & BattleNumber & " of " & TournamentD.DuelsN
					
					BattleHaltButton_Click(BattleHaltButton, New System.EventArgs())
				Next BattleNumber
				
				Score(TCA) = Val(PR1.Text) + Val(PR2.Text) + Val(PR3.Text)
				Score(TCB) = Val(PR4.Text) + Val(PR5.Text) + Val(PR6.Text)
				
				ResetHistory_Click(ResetHistory, New System.EventArgs())
			Next 
		Next 
		
		Dim TheRecord As String
		Dim highestscore As Integer
		
		TheRecord = "Team" & vbTab & vbTab & vbTab & vbTab & "Score" & vbCr
		
		For TCB = 0 To TournamentD.RobotList.Items.Count - 1 Step 3
			For TCA = 0 To TournamentD.RobotList.Items.Count - 1 Step 3
				If Score(TCA) > Score(highestscore) Then highestscore = TCA
			Next TCA
			
			TheRecord = TheRecord & TFixTabs2(VB6.GetItemString(TournamentD.RobotList, highestscore)) & vbTab & vbTab & Score(highestscore) & vbCr
			
			Score(highestscore) = -1
		Next TCB
		
		TheRecord = VB.Left(TheRecord, Len(TheRecord) - 1)
		
		RunningTournament = False
		TitleTimer.Enabled = False
		Me.Text = "RoboWar 5 - Arena"
		StopTournament.Visible = False
		BattleHaltButton.Visible = True
		BattleHaltButton.Focus()
		FileMenu.Enabled = True
		ArenaMenu.Enabled = True
		ViewMenu.Enabled = True
		
		ClockTime = System.Math.Round((VB.Timer() - ClockTime) / 60, 1)
		'UPGRADE_NOTE: timestring was upgraded to timestring_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim timestring_Renamed As String
		timestring_Renamed = Today & ", " & TimeOfDay
		
		Dim ControlLenght() As String
		If TournamentD.DuelsN > 0 Then
			TournamentResults.TheTournamentResults = TheRecord
			TournamentResults.Text = "Team Results"
			TournamentResults.Width = VB6.TwipsToPixelsX(210 * VB6.TwipsPerPixelX)
			TournamentResults.OKButton.Left = 120
			
			ControlLenght = Split(TheRecord, vbCr)
			ControlLenght = Split(ControlLenght(0), vbTab)
			VB6.ShowForm(TournamentResults, 1, Me)
		End If
		
		TheRecord = TheRecord & vbCr & vbCr & vbCr & "********" & vbCr & vbCr & "Tournament completed " & timestring_Renamed & vbCr & "Completed in " & ClockTime & " minutes " & vbCr & "Rounds " & TournamentD.DuelsN & vbCr & Scoring.Text & vbCr & "RoboWar Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
		
		FileOpen(30, TournamentD.SavedInFolder.Text, OpenMode.Output)
		PrintLine(30, TheRecord)
		FileClose(30)
		
		If PrintTournamentLog Then ProcessLog()
	End Sub
	
	Public Sub InizTeamTestTournament()
		TestTourney.Hide()
		
		If RunningTournament Then MsgBox("You're already running a tournament!",  , "Can't run two tournaments at the same time") : Exit Sub
		
		Dim ClockTime As Single
		ClockTime = VB.Timer()
		
		PrintTournamentLog = TestTourney.PrintLog.CheckState
		If PrintTournamentLog Then ReDim TournamentLog(TestTourney.RobotList.Items.Count * TestTourney.DuelsN)
		
		RunningTournament = True
		R1Present = True : R2Present = True : R3Present = True : R4Present = True : R5Present = True : R6Present = True
		AutoSetTeams()
		
		PR1.Visible = False : PR2.Visible = False : PR3.Visible = False : PR4.Visible = False : PR5.Visible = False : PR6.Visible = False
		Points1X.Visible = False : Points2X.Visible = False : Points3X.Visible = False : Points4X.Visible = False : Points5X.Visible = False : Points6X.Visible = False
		Damage1X.Visible = False : Damage2X.Visible = False : Damage3X.Visible = False : Damage4X.Visible = False : Damage5X.Visible = False : Damage6X.Visible = False
		Energy1X.Visible = False : Energy2X.Visible = False : Energy3X.Visible = False : Energy4X.Visible = False : Energy5X.Visible = False : Energy6X.Visible = False
		
		If Not ChronorsLimit.Checked Then ChronorsLimit_Click(ChronorsLimit, New System.EventArgs())
		If Replaying Then RepeatBattle_Click(RepeatBattle, New System.EventArgs())
		If VB6.Eqv(TestTourney.MandS.CheckState = 1, MoveAndShoot.Checked) Then MoveAndShoot_Click(MoveAndShoot, New System.EventArgs())
		If VB6.Eqv(TestTourney.CheckScoring.CheckState = 1, StandardScoring) Then Scoring_Click(Scoring, New System.EventArgs())
		
		ResetHistory_Click(ResetHistory, New System.EventArgs())
		
		HighestToLowest = (Int(2 * Rnd()) = 1)
		
		Dim TCA As Integer
		Dim TCB As Integer
		Dim BattleNumber As Integer
		
		Dim Score As Integer
		
		Dim ProperName As String
		ProperName = TestTourney.IamChoosedForTesting
		ProperName = VB.Right(ProperName, InStr(StrReverse(ProperName), "\") - 1)
		ProperName = VB.Left(ProperName, Len(ProperName) - 4)
		
		R1path = TestTourney.IamChoosedForTesting
		Robot1.Text = ProperName
		LoadRobot1()
		
		'''
		Dim Cstart As Integer
		Const Crec As Short = 116
		Dim TeamTag As New VB6.FixedLengthString(765)
		Dim sTeam() As String
		
		FileOpen(1, R1path, OpenMode.Binary)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, Cstart, Crec)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, TeamTag.Value, Cstart)
		FileClose(1)
		sTeam = Split(TeamTag.Value, "\", 4)
		
		Robot2.Text = sTeam(1)
		R2path = TestTourney.TeamPath & "\" & sTeam(1) & ".RWR"
		LoadRobot2()
		
		If sTeam(2) = " " Then
			Robot3.Text = sTeam(1)
			R3path = TestTourney.TeamPath & "\" & sTeam(1) & ".RWR"
			LoadRobot3()
		Else
			Robot3.Text = sTeam(2)
			R3path = TestTourney.TeamPath & "\" & sTeam(2) & ".RWR"
			LoadRobot3()
		End If
		
		Dim TheRecord As String
		TheRecord = vbTab & vbTab & vbTab & "Opponent" & vbTab & ProperName
		
		For TCB = 0 To TestTourney.RobotList.Items.Count - 2 Step 3
			Robot4.Text = VB6.GetItemString(TestTourney.RobotList, TCB)
			R4path = VB6.GetItemString(TestTourney.TheDirList, TCB) & "\" & VB6.GetItemString(TestTourney.RobotList, TCB) & ".RWR"
			LoadRobot4()
			
			Robot5.Text = VB6.GetItemString(TestTourney.RobotList, TCB + 1)
			R5path = VB6.GetItemString(TestTourney.TheDirList, TCB + 1) & "\" & VB6.GetItemString(TestTourney.RobotList, TCB + 1) & ".RWR"
			LoadRobot5()
			
			Robot6.Text = VB6.GetItemString(TestTourney.RobotList, TCB + 2)
			R6path = VB6.GetItemString(TestTourney.TheDirList, TCB + 2) & "\" & VB6.GetItemString(TestTourney.RobotList, TCB + 2) & ".RWR"
			LoadRobot6()
			
			For BattleNumber = 1 To TestTourney.DuelsN
				If Not RunningTournament Then Exit Sub
				Me.Text = "RoboWar 5 - Tournament: Team " & (TCA \ 3 + 1) & " vs Team " & (TCB \ 3 + 1) & " - Duel " & BattleNumber & " of " & TestTourney.DuelsN
				BattleHaltButton_Click(BattleHaltButton, New System.EventArgs())
			Next BattleNumber
			
			TheRecord = TheRecord & vbCr & TFixTabs2(VB6.GetItemString(TestTourney.RobotList, TCB)) & vbTab & Str(Val(PR4.Text) + Val(PR5.Text) + Val(PR6.Text)) & vbTab & vbTab & Str(Val(PR1.Text) + Val(PR2.Text) + Val(PR3.Text))
			Score = Score + Val(PR1.Text) + Val(PR2.Text) + Val(PR3.Text)
			
			ResetHistory_Click(ResetHistory, New System.EventArgs())
		Next 
		
		'Dim highestscore As Long
		
		RunningTournament = False
		TitleTimer.Enabled = False
		Me.Text = "RoboWar 5 - Arena"
		StopTournament.Visible = False
		BattleHaltButton.Visible = True
		BattleHaltButton.Focus()
		FileMenu.Enabled = True
		ArenaMenu.Enabled = True
		ViewMenu.Enabled = True
		
		ClockTime = System.Math.Round((VB.Timer() - ClockTime) / 60, 1)
		'UPGRADE_NOTE: timestring was upgraded to timestring_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim timestring_Renamed As String
		timestring_Renamed = Today & ", " & TimeOfDay
		
		TournamentResults.TheTournamentResults = TheRecord
		
		Dim ControlLenght() As String
		ControlLenght = Split(TheRecord, vbCr)
		ControlLenght = Split(ControlLenght(0), vbTab)
		
		TournamentResults.Width = VB6.TwipsToPixelsX((210 + 6 * Len(ControlLenght(4))) * VB6.TwipsPerPixelX)
		TournamentResults.Text = "Team Results"
		VB6.ShowForm(TournamentResults, 1, Me)
		
		TheRecord = TheRecord & vbCr & vbCr & vbCr & "********" & vbCr & vbCr & "Test runned " & timestring_Renamed & vbCr & "Completed in " & ClockTime & " minutes " & vbCr & "Rounds " & TestTourney.DuelsN & vbCr & Scoring.Text & vbCr & "RoboWar Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
		
		FileOpen(30, TestTourney.SavedInFolder.Text, OpenMode.Output)
		PrintLine(30, TheRecord)
		FileClose(30)
		
		If PrintTournamentLog Then ProcessLog()
	End Sub
	
	Public Sub InizTestTournament() ''''test tournament
		TestTourney.Hide()
		
		If RunningTournament Then MsgBox("You're already running a tournament!",  , "Can't run two tournaments at the same time") : Exit Sub
		
		Dim ClockTime As Single
		ClockTime = VB.Timer()
		
		ClearTeams()
		
		PrintTournamentLog = TestTourney.PrintLog.CheckState
		If PrintTournamentLog Then ReDim TournamentLog(TestTourney.RobotList.Items.Count * TestTourney.DuelsN + TestTourney.GroupN * 6)
		
		Dim GRRecord As String
		RunningTournament = True
		R1Present = True
		R2Present = True
		R3Present = False
		R4Present = False
		R5Present = False
		R6Present = False
		R3Icon.Image = Nothing
		R4Icon.Image = Nothing
		R5Icon.Image = Nothing
		R6Icon.Image = Nothing
		
		Robot3.Text = "No Robot Selected"
		Robot4.Text = "No Robot Selected"
		Robot5.Text = "No Robot Selected"
		Robot6.Text = "No Robot Selected"
		
		If TestTourney.GroupN = 0 And SelectedRobot > 2 Then
			SelectedRobot = 1
			Robot1.BackColor = System.Drawing.Color.Black : Robot1.ForeColor = System.Drawing.Color.White
			Robot2.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot2.ForeColor = System.Drawing.Color.White
			Robot3.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot3.ForeColor = System.Drawing.Color.White
			Robot4.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot4.ForeColor = System.Drawing.Color.White
			Robot5.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot5.ForeColor = System.Drawing.Color.White
			Robot6.BackColor = System.Drawing.ColorTranslator.FromOle(BackgroundColor) : Robot6.ForeColor = System.Drawing.Color.White
		End If
		
		Dim counter As Integer
		
		For counter = 3 To 6
			RobotLeft(counter) = -counter * 100
			DR(counter).Visible = False
			EnergyDisplay(counter).Visible = False 'Ny
			ER(counter).Visible = False 'Ny
		Next counter
		PR3.Visible = False : PR4.Visible = False : PR5.Visible = False : PR6.Visible = False
		Points3X.Visible = False : Points4X.Visible = False : Points5X.Visible = False : Points6X.Visible = False
		Damage3X.Visible = False : Damage4X.Visible = False : Damage5X.Visible = False : Damage6X.Visible = False
		Energy3X.Visible = False : Energy4X.Visible = False : Energy5X.Visible = False : Energy6X.Visible = False
		
		If Not ChronorsLimit.Checked Then ChronorsLimit_Click(ChronorsLimit, New System.EventArgs())
		If Replaying Then RepeatBattle_Click(RepeatBattle, New System.EventArgs())
		If VB6.Eqv(TestTourney.MandS.CheckState = 1, MoveAndShoot.Checked) Then MoveAndShoot_Click(MoveAndShoot, New System.EventArgs())
		If VB6.Eqv(TestTourney.CheckScoring.CheckState = 1, StandardScoring) Then Scoring_Click(Scoring, New System.EventArgs())
		
		ResetHistory_Click(ResetHistory, New System.EventArgs())
		
		HighestToLowest = (Int(2 * Rnd()) = 1)
		'Loading the robot set for test
		Dim ProperName As String
		ProperName = TestTourney.IamChoosedForTesting
		ProperName = VB.Right(ProperName, InStr(StrReverse(ProperName), "\") - 1)
		ProperName = VB.Left(ProperName, Len(ProperName) - 4)
		
		Robot1.Text = ProperName
		
		R1path = TestTourney.IamChoosedForTesting
		LoadRobot1()
		''''''''''''''''''''''''''
		Dim TheRecord As String
		Dim OpponentNumber As Integer
		Dim BattleNumber As Integer
		Dim MyTotalScore As Integer
		
		For OpponentNumber = 0 To TestTourney.RobotList.Items.Count - 1
			PR1.Text = CStr(0) : PR2.Text = CStr(0)
			
			For counter = 1 To 50
				HistoryRec(1, counter) = 0 : HistoryRec(2, counter) = 0
			Next counter
			
			Robot2.Text = VB6.GetItemString(TestTourney.RobotList, OpponentNumber)
			R2path = VB6.GetItemString(TestTourney.TheDirList, OpponentNumber) & "\" & VB6.GetItemString(TestTourney.RobotList, OpponentNumber) & ".RWR"
			LoadRobot2()
			
			For BattleNumber = 1 To TestTourney.DuelsN
				If Not RunningTournament Then Exit Sub
				Me.Text = "RoboWar 5 - Testing " & ProperName & ": Against Robot " & (OpponentNumber + 1) & " of " & TestTourney.RobotList.Items.Count & " - Duel " & BattleNumber & " of " & TestTourney.DuelsN
				BattleHaltButton_Click(BattleHaltButton, New System.EventArgs())
			Next BattleNumber
			
			MyTotalScore = MyTotalScore + CDbl(PR1.Text)
			TheRecord = TheRecord & TFixTabs2((Robot2.Text)) & vbTab & PR2.Text & vbTab & vbTab & PR1.Text & vbCr
		Next OpponentNumber
		
		Dim WinRecord As Single 'That what it's all about
		If TestTourney.DuelsN <> 0 Then
			TheRecord = vbTab & vbTab & vbTab & "Opponent" & vbTab & ProperName & vbCr & TheRecord
			WinRecord = MyTotalScore / (TestTourney.RobotList.Items.Count * 2) 'Splited to avoid
			WinRecord = WinRecord / TestTourney.DuelsN * 100 'overflow
			TheRecord = TheRecord & vbCr & vbCr & System.Math.Round(WinRecord) & "% WinRecord"
		End If
		
		''''GR
		Dim GRScore() As Integer
		Dim NumberOfGRBattles() As Integer
		Dim RobotGRScore As Integer
		Dim highestscore As Integer
		'UPGRADE_WARNING: Lower bound of array RandomRobot was changed from 2 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RandomRobot(6) As Integer
		If TestTourney.GroupN <> 0 Then
			
			ReDim GRScore(TestTourney.RobotList.Items.Count)
			ReDim NumberOfGRBattles(TestTourney.RobotList.Items.Count)
			
			R3Present = True : R4Present = True : R5Present = True : R6Present = True
			
			PR1.Text = CStr(0) : PR2.Text = CStr(0) : PR3.Text = CStr(0) : PR4.Text = CStr(0) : PR5.Text = CStr(0) : PR6.Text = CStr(0)
			For counter = 1 To 50
				HistoryRec(1, counter) = 0 : HistoryRec(2, counter) = 0
				HistoryRec(3, counter) = 0 : HistoryRec(4, counter) = 0
				HistoryRec(5, counter) = 0 : HistoryRec(6, counter) = 0
			Next counter
			
			For OpponentNumber = 1 To TestTourney.GroupN
				RobotGRScore = RobotGRScore + CDbl(PR1.Text)
				GRScore(RandomRobot(2)) = GRScore(RandomRobot(2)) + CDbl(PR2.Text)
				GRScore(RandomRobot(3)) = GRScore(RandomRobot(3)) + CDbl(PR3.Text)
				GRScore(RandomRobot(4)) = GRScore(RandomRobot(4)) + CDbl(PR4.Text)
				GRScore(RandomRobot(5)) = GRScore(RandomRobot(5)) + CDbl(PR5.Text)
				GRScore(RandomRobot(6)) = GRScore(RandomRobot(6)) + CDbl(PR6.Text)
				
				RandomRobot(2) = Int(TestTourney.RobotList.Items.Count * Rnd())
				NumberOfGRBattles(RandomRobot(2)) = NumberOfGRBattles(RandomRobot(2)) + 1
redorandom3: 
				RandomRobot(3) = Int(TestTourney.RobotList.Items.Count * Rnd())
				If RandomRobot(3) = RandomRobot(2) Then GoTo redorandom3
				NumberOfGRBattles(RandomRobot(3)) = NumberOfGRBattles(RandomRobot(3)) + 1
redorandom4: 
				RandomRobot(4) = Int(TestTourney.RobotList.Items.Count * Rnd())
				If RandomRobot(4) = RandomRobot(3) Or RandomRobot(4) = RandomRobot(2) Then GoTo redorandom4
				NumberOfGRBattles(RandomRobot(4)) = NumberOfGRBattles(RandomRobot(4)) + 1
redorandom5: 
				RandomRobot(5) = Int(TestTourney.RobotList.Items.Count * Rnd())
				If RandomRobot(5) = RandomRobot(4) Or RandomRobot(5) = RandomRobot(3) Or RandomRobot(5) = RandomRobot(2) Then GoTo redorandom5
				NumberOfGRBattles(RandomRobot(5)) = NumberOfGRBattles(RandomRobot(5)) + 1
redorandom6: 
				RandomRobot(6) = Int(TestTourney.RobotList.Items.Count * Rnd()) ' + 1
				If RandomRobot(6) = RandomRobot(5) Or RandomRobot(6) = RandomRobot(4) Or RandomRobot(6) = RandomRobot(3) Or RandomRobot(6) = RandomRobot(2) Then GoTo redorandom6
				NumberOfGRBattles(RandomRobot(6)) = NumberOfGRBattles(RandomRobot(6)) + 1
				
				Robot2.Text = VB6.GetItemString(TestTourney.RobotList, RandomRobot(2))
				R2path = VB6.GetItemString(TestTourney.TheDirList, RandomRobot(2)) & "\" & VB6.GetItemString(TestTourney.RobotList, RandomRobot(2)) & ".RWR"
				LoadRobot2()
				Robot3.Text = VB6.GetItemString(TestTourney.RobotList, RandomRobot(3))
				R3path = VB6.GetItemString(TestTourney.TheDirList, RandomRobot(3)) & "\" & VB6.GetItemString(TestTourney.RobotList, RandomRobot(3)) & ".RWR"
				LoadRobot3()
				Robot4.Text = VB6.GetItemString(TestTourney.RobotList, RandomRobot(4))
				R4path = VB6.GetItemString(TestTourney.TheDirList, RandomRobot(4)) & "\" & VB6.GetItemString(TestTourney.RobotList, RandomRobot(4)) & ".RWR"
				LoadRobot4()
				Robot5.Text = VB6.GetItemString(TestTourney.RobotList, RandomRobot(5))
				R5path = VB6.GetItemString(TestTourney.TheDirList, RandomRobot(5)) & "\" & VB6.GetItemString(TestTourney.RobotList, RandomRobot(5)) & ".RWR"
				LoadRobot5()
				Robot6.Text = VB6.GetItemString(TestTourney.RobotList, RandomRobot(6))
				R6path = VB6.GetItemString(TestTourney.TheDirList, RandomRobot(6)) & "\" & VB6.GetItemString(TestTourney.RobotList, RandomRobot(6)) & ".RWR"
				LoadRobot6()
				
				PR1.Text = CStr(0) : PR2.Text = CStr(0) : PR3.Text = CStr(0) : PR4.Text = CStr(0) : PR5.Text = CStr(0) : PR6.Text = CStr(0)
				For counter = 1 To 50
					HistoryRec(1, counter) = 0 : HistoryRec(2, counter) = 0 : HistoryRec(3, counter) = 0 : HistoryRec(4, counter) = 0 : HistoryRec(5, counter) = 0 : HistoryRec(6, counter) = 0
				Next counter
				
				For BattleNumber = 1 To 6
					If Not RunningTournament Then Exit Sub
					Me.Text = "RoboWar 5 - Testing " & ProperName & ": Group Round " & OpponentNumber & " of " & TestTourney.GroupN & " - Bout " & BattleNumber & " of 6"
					BattleHaltButton_Click(BattleHaltButton, New System.EventArgs())
				Next BattleNumber
			Next OpponentNumber
			
			'Print GR Score
			'roster[i].groupScore *= (double)numGroups/roster[i].numGroupFights;
			
			For counter = 0 To TestTourney.RobotList.Items.Count - 1
				If NumberOfGRBattles(counter) > 0 Then
					GRScore(counter) = GRScore(counter) * TestTourney.GroupN / NumberOfGRBattles(counter)
				Else
					GRScore(counter) = 0
				End If
			Next counter
			
			
			For OpponentNumber = 0 To TestTourney.RobotList.Items.Count - 1
				For counter = 0 To TestTourney.RobotList.Items.Count - 1
					If GRScore(counter) > GRScore(highestscore) Then highestscore = counter
				Next counter
				
				If RobotGRScore > GRScore(highestscore) Then
					GRRecord = GRRecord & vbCr & TFixTabs2(ProperName) & vbTab & RobotGRScore
					RobotGRScore = -2
				End If
				
				GRRecord = GRRecord & vbCr & TFixTabs2(VB6.GetItemString(TestTourney.RobotList, highestscore)) & vbTab & GRScore(highestscore)
				GRScore(highestscore) = -1
			Next OpponentNumber
			
			If RobotGRScore <> -2 Then GRRecord = GRRecord & vbCr & TFixTabs2(ProperName) & vbTab & RobotGRScore 'In case it finishes last
			
			Load2.Visible = True : Load3.Visible = True
			Load4.Visible = True : Load5.Visible = True
			Load5.Visible = True : Load6.Visible = True
		Else
			Load2.Visible = True
			Load3.Visible = True
		End If
		
		RunningTournament = False
		TitleTimer.Enabled = False
		Me.Text = "RoboWar 5 - Arena"
		StopTournament.Visible = False
		BattleHaltButton.Visible = True
		BattleHaltButton.Focus()
		FileMenu.Enabled = True
		ArenaMenu.Enabled = True
		ViewMenu.Enabled = True
		
		ClockTime = System.Math.Round((VB.Timer() - ClockTime) / 60, 1)
		'UPGRADE_NOTE: timestring was upgraded to timestring_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim timestring_Renamed As String
		timestring_Renamed = Today & ", " & TimeOfDay
		
		Dim ControlLenght() As String
		If TestTourney.DuelsN > 0 Then
			TournamentResults.TheTournamentResults = TheRecord
			TournamentResults.Text = "Testing Results - Duel"
			
			ControlLenght = Split(TheRecord, vbCr)
			ControlLenght = Split(ControlLenght(0), vbTab)
			TournamentResults.Width = VB6.TwipsToPixelsX((210 + 6 * Len(ControlLenght(4))) * VB6.TwipsPerPixelX)
			VB6.ShowForm(TournamentResults, 1, Me)
		Else
			TheRecord = ""
		End If
		
		If TestTourney.GroupN > 0 Then
			TournamentResults.TheTournamentResults = VB.Right(GRRecord, Len(GRRecord) - 1)
			TournamentResults.Text = "Testing Results - Group Rounds"
			TournamentResults.Width = VB6.TwipsToPixelsX(3800)
			
			VB6.ShowForm(TournamentResults, 1, Me)
			
			GRRecord = vbCr & vbCr & vbCr & " GROUP" & vbCr & GRRecord
		End If
		
		TheRecord = vbCr & " DUEL" & vbCr & vbCr & TheRecord & GRRecord
		
		TheRecord = TheRecord & vbCr & vbCr & vbCr & "********" & vbCr & vbCr & "Test runned " & timestring_Renamed & vbCr & "Completed in " & ClockTime & " minutes " & vbCr & "Duels " & TestTourney.DuelsN & " - Groups " & TestTourney.GroupN & vbCr & Scoring.Text & vbCr & "RoboWar Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
		
		FileOpen(30, TestTourney.SavedInFolder.Text, OpenMode.Output)
		PrintLine(30, TheRecord)
		FileClose(30)
		
		If PrintTournamentLog Then ProcessLog()
		
	End Sub
	
	Private Sub ProcessLog()
		'KILLS OCH KILLER
		' kommer inte alltid att stämma med varandra eftersom kills kan bli borttagna
		
		PrintTournamentLog = False
		LogWhichBattle = 0
		
		Dim TheLog As String
		
		TheLog = "Name" & vbTab & vbTab & vbTab & vbTab & " Killer" & vbTab & vbTab & vbTab & vbTab & "Death Time" & vbTab & "Kill Points" & vbTab & "Survival Points" & vbCr
		
		Dim c As Integer
		Dim i As Integer
		Dim TheKiller As String
		Dim TheDeathTime As String
		
		CreatingLog.Show()
		Dim Done As Integer
		Done = UBound(TournamentLog)
		
		Dim LogFileName As String
		LogFileName = My.Application.Info.DirectoryPath & "\TournamentLog.txt"
		
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If Dir(LogFileName) <> "" Then Kill(LogFileName)
		FileOpen(100, LogFileName, OpenMode.Append)
		
		For c = 0 To UBound(TournamentLog)
			
			For i = 1 To 6
				'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
				If LenB(TournamentLog(c).WhosWho(i)) = 0 Then Exit For
				
				If TournamentLog(c).DeathTime(i) = 32767 Then
					TheKiller = "-" & vbTab & vbTab & vbTab & vbTab
					TheDeathTime = "-"
				ElseIf TournamentLog(c).killer(i) <= 6 Then 
					TheKiller = TFixTabs3(TournamentLog(c).WhosWho(TournamentLog(c).killer(i)))
					TheDeathTime = CStr(TournamentLog(c).DeathTime(i))
				Else
					Select Case TournamentLog(c).killer(i)
						Case 253
							TheKiller = "Overloaded" & vbTab & vbTab & vbTab
						Case 254
							TheKiller = "Bugged" & vbTab & vbTab & vbTab
						Case 255
							TheKiller = "Collision/Suicide" & vbTab
					End Select
					TheDeathTime = CStr(TournamentLog(c).DeathTime(i))
				End If
				
				TheLog = TheLog & TFixTabs3(TournamentLog(c).WhosWho(i)) & TheKiller & vbTab & TheDeathTime & vbTab & vbTab & TournamentLog(c).Kills(i) & vbTab & vbTab & TournamentLog(c).SurvivalPoints(i) & vbCr
			Next i
			
			TheLog = TheLog & vbCr
			
			CreatingLog.Progress.Text = CStr(System.Math.Round((c / Done) * 100))
			System.Windows.Forms.Application.DoEvents()
			
			'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			If LenB(TheLog) >= 50000 Then '50000
				PrintLine(100, TheLog)
				TheLog = vbCr
			End If
			
			If CreatingLog.CanceledLog Then GoTo didcancel
		Next c
		
		PrintLine(100, TheLog)
		
didcancel: 
		CreatingLog.Close()
		FileClose(100)
		Erase TournamentLog
	End Sub
	
	Private Function TFixTabs3(ByRef TheName As String) As String
		Dim HowLongNameIs As Integer 'Used for tournament log
		HowLongNameIs = Len(TheName)
		
		If HowLongNameIs < 25 Then '25
			TFixTabs3 = TheName & Space(25 - HowLongNameIs) '25
		Else
			TFixTabs3 = VB.Left(TheName, 23) & "  " '25
		End If
		
	End Function
	
	Private Sub DebuggerPaint(ByRef DbgRobotAlive As Integer, ByRef DbgTurretType As Integer, ByRef DNN As Integer)
		
		If DbgRobotAlive = 1 Then
			'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			Arena.PaintPicture(Robot_(DNN), RobotLeft(DNN) - 16, RobotTop(DNN) - 16)
			If DbgTurretType = 1 Then
				'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.Line (RobotLeft(DNN), RobotTop(DNN)) - (TurretX2(DNN), TurretY2(DNN)), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			ElseIf DbgTurretType = 2 Then 
				'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.Circle (TurretX2(DNN), TurretY2(DNN)), 1, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			End If
		ElseIf DbgRobotAlive > 230 Then 
			DeathAnimation(DNN, DbgRobotAlive)
		End If
		
	End Sub
	
	Private Sub DebuggerPaintShot(ByRef TheShot As ShotPrivateType)
		Dim DNR As Integer '2 '8
		Select Case TheShot.ShotType
			Case 200
			Case Missile
				'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.Line (TheShot.ShotX, TheShot.ShotY) - (TheShot.ShotX + Sin5(TheShot.ShotAngle), TheShot.ShotY - Cos5(TheShot.ShotAngle)), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			Case Hellbore
				'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.SystemColors.AppWorkspace) 'Creates new shotprojection
				'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.Circle (TheShot.ShotX, TheShot.ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			Case Stunner
				'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.Line (TheShot.ShotX - 2, TheShot.ShotY - 2) - (TheShot.ShotX + 3, TheShot.ShotY + 3), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
				'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.Line (TheShot.ShotX + 2, TheShot.ShotY - 2) - (TheShot.ShotX - 3, TheShot.ShotY + 3), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			Case XplosiveBulletDetonation
				If Chronon - TheShot.ShotFireTime <= 4 Then '10
					'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.FillColor = &HA1A1A2
					'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.Circle (TheShot.ShotX, TheShot.ShotY), 12 * (Chronon - TheShot.ShotFireTime) - 12, &H808080
				End If
			Case TakeNuke
				If Chronon - TheShot.ShotFireTime <= 10 Then '10
					'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.FillColor = &HA1A1A2
					'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.Circle (TheShot.ShotX, TheShot.ShotY), 5 * (Chronon - TheShot.ShotFireTime), &H808080
				End If
			Case MegaNuke
				If Chronon - TheShot.ShotFireTime <= MegaNukeBLASTRADIUS Then '10
					'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.FillColor = &H80000013
					'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.Circle (TheShot.ShotX, TheShot.ShotY), 5 * (Chronon - TheShot.ShotFireTime), &H808080
				End If
			Case Mine
				'UPGRADE_ISSUE: PictureBox property Arena.FillStyle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.FillStyle = 1
				'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.Circle (TheShot.ShotX, TheShot.ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
				'UPGRADE_ISSUE: PictureBox property Arena.FillStyle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.FillStyle = 0
				'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
				'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.Circle (TheShot.ShotX, TheShot.ShotY), 2, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			Case Drone
				If System.Math.Abs(TheShot.ShotY - RobotTop(TheShot.ShotAngle)) <= 8 Then
					If TheShot.ShotX < RobotLeft(TheShot.ShotAngle) Then
						'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.PaintPicture(DroneR, TheShot.ShotX - 2, TheShot.ShotY - 2)
					Else
						'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.PaintPicture(DroneL, TheShot.ShotX - 2, TheShot.ShotY - 2)
					End If
				ElseIf System.Math.Abs(TheShot.ShotX - RobotLeft(TheShot.ShotAngle)) <= 8 Then  '2 '8
					If TheShot.ShotY < RobotTop(TheShot.ShotAngle) Then
						'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.PaintPicture(DroneD, TheShot.ShotX - 2, TheShot.ShotY - 2)
					Else
						'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Arena.PaintPicture(DroneU, TheShot.ShotX - 2, TheShot.ShotY - 2) '- 2 för att den börjar måla den i vänstra hörnet
					End If
				Else
					If TheShot.ShotX < RobotLeft(TheShot.ShotAngle) Then DNR = 2 Else DNR = 0
					If TheShot.ShotY < RobotTop(TheShot.ShotAngle) + 16 Then DNR = DNR + 4 Else DNR = DNR + 3
					'UPGRADE_ISSUE: PictureBox method Arena.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.PaintPicture(DroneDiagonally(DNR), TheShot.ShotX - 2, TheShot.ShotY - 2)
				End If
			Case Laser
				'UPGRADE_ISSUE: PictureBox method Arena.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.Line (TurretX2(TheShot.Shooter), TurretY2(TheShot.Shooter)) - (TheShot.ShotX, TheShot.ShotY), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
				'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
				'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.Circle (TheShot.ShotX, TheShot.ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
			Case SHOTHIT
				If TheShot.ShotAngle < 100 Then 'Regular
					'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
					'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.Circle (TheShot.ShotX, TheShot.ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
				ElseIf TheShot.ShotAngle < 1000 Then  'Stunner
					'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
					'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Arena.Circle (TheShot.ShotX, TheShot.ShotY), 4, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
				End If
			Case Else
				'UPGRADE_ISSUE: PictureBox property Arena.FillColor was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.FillColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) 'Creates new shotprojection
				'UPGRADE_ISSUE: PictureBox method Arena.Circle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				Arena.Circle (TheShot.ShotX, TheShot.ShotY), 2, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
		End Select
	End Sub
	
	Private Sub PrintInts(ByRef DInton As Boolean, ByRef DLeftParam As Integer, ByRef DRightParam As Integer, ByRef DTopParam As Integer, ByRef DBotParam As Integer, ByRef DLeftInst As Integer, ByRef DRightInst As Integer, ByRef DTopInst As Integer, ByRef DBotInst As Integer, ByRef DRadarParam As Integer, ByRef DRadarInst As Integer, ByRef DRangeInst As Integer, ByRef DRangeParam As Integer, ByRef DRobotQuePos As Integer, ByRef RobotIntQue1 As Integer, ByRef RobotIntQue2 As Integer)
		
		Dim mess As String
		
		mess = "Inton = " & DInton & vbLf & "Left: " & DLeftParam & " / " & DLeftInst & vbLf & "Right: " & DRightParam & " / " & DRightInst & vbLf & "Top: " & DTopParam & " / " & DTopInst & vbLf & "Bot: " & DBotParam & " / " & DBotInst & vbLf & "Range: " & DRangeParam & " / " & DRangeInst & vbLf & "Radar: " & DRadarParam & " / " & DRadarInst & vbLf & "QueNum: " & DRobotQuePos
		
		If DRobotQuePos >= 1 Then
			mess = mess & vbLf & "QuePos1: " & RobotIntQue1
		End If
		
		If DRobotQuePos >= 2 Then
			mess = mess & vbLf & "QuePos2: " & RobotIntQue2
		End If
		
		'UPGRADE_ISSUE: PictureBox method Ints.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		DebuggingWindow.Ints.Cls()
		'UPGRADE_ISSUE: PictureBox method Ints.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		DebuggingWindow.Ints.Print(mess)
	End Sub
	
	Private Function TFixTabs2(ByRef TheName As String) As String
		Dim HowLongNameIs As Integer 'Used for tournament results
		HowLongNameIs = Len(TheName)
		
		If HowLongNameIs < 25 Then '25
			TFixTabs2 = TheName & Space(25 - HowLongNameIs) '25
		Else
			TFixTabs2 = VB.Left(TheName, 20) '25
		End If
		
	End Function
	
	''Nya error handler
	
	Private Function ShowErrorMessageParam(ByRef MessageCode As Integer, ByRef RNN_R As Integer, ByRef Chronon As Integer, ByRef ChrononExecutor1_R As Integer, ByRef RobotInstPos_R As Integer, ByRef TopStack As Integer) As Integer
		Dim ReturnError As String
		Dim sTopStack As String
		sTopStack = S(TopStack)
		
		Select Case MessageCode
			Case BuggyStore
				ReturnError = "Illegal 'STORE' parameter " & sTopStack
			Case BuggySetparam
				ReturnError = "Illegal 'SETPARAM' parameter " & sTopStack
			Case BuggySetint
				ReturnError = "Illegal 'SETINT' parameter " & sTopStack
			Case Else
				ReturnError = "Bug in the game. Please report this bug."
		End Select
		
		ReturnError = ReturnError & vbLf & "Instruction No. " & RobotInstPos_R & vbLf & vbLf & GetRobot(RNN_R) & vbTab & "(Robot Numer " & RNN_R & ")" & vbCr & "Chronon " & Chronon & vbTab & vbTab & "Processor Position " & ChrononExecutor1_R & vbLf & vbCr & vbCr & "Would you like to have the instruction that caused this crash highlighted?" & vbCr & "(Press cancel to stop the battle.)"
		
		ShowErrorMessageParam = MsgBox(ReturnError, MsgBoxStyle.Critical + MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton2, "Bug Alert") 'Response
	End Function
	
	Private Function ShowErrorMessage(ByRef MessageCode As Integer, ByRef RNN_R As Integer, ByRef Chronon As Integer, ByRef ChrononExecutor1_R As Integer, ByRef RobotInstPos_R As Integer, ByRef MachineCode_R As Integer) As Integer
		Dim ReturnError As String
		Dim sMachineCode_R As String
		sMachineCode_R = S(MachineCode_R)
		
		If MachineCode_R = insEND Then
			If ChrononExecutor1_R = 0 And RobotInstPos_R = 0 Then
				ReturnError = "Robot not compiled"
			Else
				ReturnError = "End of code reached"
			End If
		Else
			Select Case MessageCode
				Case BuggyDivRelated
					If MachineCode_R = insMOD Then
						ReturnError = "Mod by zero" '& sMachineCode_R
					Else
						ReturnError = "Division by zero " & sMachineCode_R
					End If
				Case BuggyOverflow
					ReturnError = "Stack overflow " & sMachineCode_R
				Case BuggyDivision
					ReturnError = "Division by zero /" '& sMachineCode_R
				Case BuggySquare
					ReturnError = "Square root of negative number"
				Case BuggyRecall
					ReturnError = "Variable not provided RECALL"
				Case BuggyNearest
					ReturnError = "Processor speed to high to use NEAREST"
				Case BuggyDestination
					ReturnError = "Jump destination not in program " & sMachineCode_R
				Case BuggyUnderflow
					ReturnError = "Stack underflow " & sMachineCode_R
				Case BuggyUnknownOrIllegal
					ReturnError = "Unknown or illegal instruction " & sMachineCode_R
				Case BuggyNumberOutofBounds
					ReturnError = "Number out of bounds " & sMachineCode_R
				Case BuggyChannel
					ReturnError = "Invalid channel (Channels ranges from 1 to 10)"
				Case BuggyMissiles
					ReturnError = "Missiles not enabled."
				Case BuggyStunners
					ReturnError = "Stunners not enabled."
				Case BuggyTacNukes
					ReturnError = "TacNukes not enabled."
				Case BuggyHellbores
					ReturnError = "Hellbores not enabled."
				Case BuggyMines
					ReturnError = "Mines not enabled."
				Case BuggyLasers
					ReturnError = "Lasers not enabled."
				Case BuggyDrones
					ReturnError = "Drones not enabled."
				Case BuggyProbes
					ReturnError = "Probes not enabled."
				Case Else
					ReturnError = "Bug in the game. Please report this bug. " & sMachineCode_R
					'        Case Else
					'            ReturnError = "An error in the error handler has occured. We don't know why your robot died."
			End Select
		End If
		
		ReturnError = ReturnError & vbLf & "Instruction No. " & RobotInstPos_R & vbLf & vbLf & GetRobot(RNN_R) & vbTab & "(Robot Numer " & RNN_R & ")" & vbCr & "Chronon " & Chronon & vbTab & vbTab & "Processor Position " & ChrononExecutor1_R & vbLf & vbCr & vbCr & "Would you like to have the instruction that caused this crash highlighted?" & vbCr & "(Press cancel to stop the battle.)"
		
		ShowErrorMessage = MsgBox(ReturnError, MsgBoxStyle.Critical + MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton2, "Bug Alert") 'Response
	End Function
	
	Private Sub ShowMoveAndShootMessage(ByRef MoveShootingRobot As Integer, ByRef ChrononExecutor1_MSR As Integer, ByRef RobotInstPos_MSR As Integer)
		Dim MoveAndShootErrorMessage As String
		If Not RunningTournament Then
			If ShowMoveAndShoot.Checked Then
				
				MoveAndShootErrorMessage = "A robot can not move and shoot in the same chronon. The energy for the second operation is lost." & vbLf & vbLf & GetRobot(MoveShootingRobot) & vbTab & "(Robot Numer " & MoveShootingRobot & ")" & vbCr & "Instruction No. " & RobotInstPos_MSR & vbLf & "Chronon " & Chronon & vbTab & vbTab & "Processor Position " & ChrononExecutor1_MSR & vbCr & vbCr & "Would you like to disable Move and Shoot messages?"
				
				If MsgBox(MoveAndShootErrorMessage, MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Move and Shoot violation") = MsgBoxResult.Yes Then ShowMoveAndShoot.Checked = False
			End If
		End If
		
	End Sub
	
	Private Sub DONTSHOWBATTLE()
		'This is the nondisplayed battle engine
		'which isn't anything else than the regular battle engine with all graphical and sounds stuffs removed
		
		'Pros and cons compared to have a hybrid battle engine for both
		'Pros
		'+ It's faster than a hybrid battle engine would have been
		'+ It doesn't slow down the regular battle engine with alot of "If BattleAreDisplayed then"
		' (As we all know, painting shots are integrated in the routine that moves them, therefore it'll be a lot of
		' "If BattleAreDisplayed then" if I would construct it the other way instead.)
		'+ No need to make the code more messy with alot of "If BattleAreDisplayed then"
		
		'Cons
		'- No possibility to switch between displayed and nondisplayed battle during a battle
		'   (This isn't that bad IMO. It doesn't take that long to finish the ongoing battle in a tournament in displayed-fast. Has honestly never bothered me that I can't switch in the same battle.)
		'- I have to update two codes
		
		'Debugging variables
		Dim ErrorCode As Integer
		Dim RandomCounter As Integer
		
		'Robotarnas maskinkod - The robots' machinecode
		'UPGRADE_WARNING: Lower bound of array MachineCode was changed from 1,0 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim MachineCode(6, 4999) As Integer '0-4999 = RobotInstructions
		'UPGRADE_WARNING: Lower bound of array RobotInstPos was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotInstPos(6) As Integer
		
		'Robotarnas Stack - The robots' Stacks
		'UPGRADE_WARNING: Lower bound of array RobotStack was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotStack(6, 100) As Integer 'long
		'UPGRADE_WARNING: Lower bound of array RobotStackPos was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotStackPos(6) As Integer 'How many numbers the robots has on it's stack
		
		'Robotarnas Interupptsköer - The robots' interupps ques
		'UPGRADE_WARNING: Lower bound of array RobotIntQue was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotIntQue(6, 100) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotQuePos was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotQuePos(6) As Integer
		'UPGRADE_WARNING: Lower bound of array IntID was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim IntID(6, 100) As Integer
		
		'Robots hardware
		'UPGRADE_WARNING: Lower bound of array RobotShield was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotShield(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotEnergy was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotEnergy(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotProSpeed was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotProSpeed(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotMissiles was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotMissiles(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotTacNukes was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotTacNukes(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotBullets was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotBullets(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotStunners was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotStunners(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotHellbores was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotHellbores(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotMines was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotMines(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotLasers was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotLasers(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotDrones was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotDrones(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotProbes was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotProbes(6) As Integer
		
		'Robotarnas variabler - The robots' variables
		'UPGRADE_WARNING: Lower bound of array RA was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RA(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RB was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RB(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RC was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RC(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RD was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RD(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RE was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RE(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RF was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RF(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RG was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RG(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RH was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RH(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RI was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RI(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RJ was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RJ(6) As Integer 'Used to be ints, but it seems like people using them
		'UPGRADE_WARNING: Lower bound of array RK was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RK(6) As Integer 'to store placerecalls
		'UPGRADE_WARNING: Lower bound of array RL was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RL(6) As Integer 'For example "radar' a' store" won't work with longs
		'UPGRADE_WARNING: Lower bound of array RM was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RM(6) As Integer 'long is slower, but robots simply doesn't work otherwise.
		'UPGRADE_WARNING: Lower bound of array RN was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RN(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RO was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RO(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RP was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RP(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RQ was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RQ(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RR was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RR(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RS was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RS(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RT was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RT(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RU was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RU(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RV was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RV(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RZ was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RZ(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RW was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RW(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RVRECALL was changed from 1,0 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RVRECALL(6, 100) As Integer
		
		'Probes and Interupps
		'UPGRADE_WARNING: Lower bound of array ProbeSet was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ProbeSet(6) As Integer '0 = Damage 1 = Energy 2 = Shield 3 = ID '5 = Aim 6 = look 7 = scan 4 = Teammates - Currently disabled 'cause of no teams
		
		'UPGRADE_WARNING: Lower bound of array Inton was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim Inton(6) As Boolean
		'UPGRADE_WARNING: Lower bound of array RangeInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RangeInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RangeParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RangeParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RadarInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RadarInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RadarParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RadarParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array ChrononInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ChrononInst(6) As Integer 'Måste alltid dras ifrån en då denna sätts för att mataren matar fram + 1
		'UPGRADE_WARNING: Lower bound of array ChrononParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ChrononParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotsInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotsInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotsParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotsParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RightParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RightParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array LeftParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim LeftParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TopParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TopParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array BotParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim BotParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RightInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RightInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array LeftInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim LeftInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TopInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TopInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array BotInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim BotInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array CollisionInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim CollisionInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array WallInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim WallInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array DamageInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim DamageInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array DamageParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim DamageParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array ShieldInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ShieldInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array ShieldParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ShieldParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array HistoryParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim HistoryParam(6) As Integer
		
		' Team Variables
		'UPGRADE_WARNING: Lower bound of array RSignal was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RSignal(3, 10) As Integer
		'UPGRADE_WARNING: Lower bound of array RChannel was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RChannel(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TeammatesInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TeammatesInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TeammatesParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TeammatesParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array SignalInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim SignalInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array SignalParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim SignalParam(6) As Integer
		
		'Things that can be recalled
		'UPGRADE_WARNING: Lower bound of array RCollision was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RCollision(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RWall was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RWall(6) As Integer
		'UPGRADE_WARNING: Lower bound of array REnergy was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim REnergy(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RDamage was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RDamage(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RShield was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RShield(6) As Integer 'Byte
		'UPGRADE_WARNING: Lower bound of array RSpeedx was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RSpeedx(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RSpeedy was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RSpeedy(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RAim was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RAim(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RLook was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RLook(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RScan was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RScan(6) As Integer
		Dim RRadar As Integer 'Kanske kan byggas ihop? Bytas ut?
		Dim RRange As Integer
		
		'Robot Specific Game Vars
		'UPGRADE_WARNING: Lower bound of array RobotAlive was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotAlive(6) As Integer 'Boolean
		'UPGRADE_WARNING: Lower bound of array RStunned was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RStunned(6) As Integer 'The number of chronons the robot is stunned
		'Hasmoved skall ha 2 funktioner. Dels MoveAndShot, dels så att LEFT' RIGHT' TOP' BOT'
		'skall kunna triggas med movex
		'UPGRADE_WARNING: Lower bound of array LastHiter was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim LastHiter(6) As Integer
		Dim HasMoved As Integer
		Dim DroneShotDown As Boolean 'This var decides wether we have to check through every shot when a x-bullet or a tacnuke explode.
		'If there's robots using drones, we have to. If there's no robots using drones, we can skip this a benifit speed.
		
		'Vars neccesary for running the game
		'Dim NextEvents As Long     'For the Nextevents optimization
		Dim RNN As Integer 'Stands for Robot ruNniNg or something like that (I don't remember exactly what to be honest). Correspond aproximately to the variable "who" in Mac RoboWar
		Dim ChrononExecutor1 As Integer 'Correspons to "cycleNum"
		Dim HowManyLeft As Integer 'Used to determine when to cancel battle. Set to 2 if only one robot is present, to avoid that battle breaks at Chronon 20
		Dim tempnumber As Integer 'temporary placeholder for longs
		Dim TDouble As Double 'To avoid trig calculations to get truncated
		
		'Shot vars
		Dim FreeShot As Integer
		FreeShot = -1
		Dim shotcounter As Integer 'Kan användas i debuggern istället för RRadar?
		Dim NotAnyShotsAtAll As Boolean
		Dim shot(32768) As ShotPrivateType
		Dim ShotNumber As Integer
		
		Dim trigx As Single
		Dim trigy As Single
		
		InizBattle()
		'Battle Starts. The robots get randomly placed in the Arena
		
		'Robot 1. Allways Present
		REnergy(1) = Robot1Energy
		RDamage(1) = Robot1Damage
		
		'Laddar machinkoden till Robotarna
		For RNN = 0 To 4999
			MachineCode(1, RNN) = MasterCode(1, RNN)
			If (MachineCode(1, RNN) >= insICON0 And MachineCode(1, RNN) <= insICON9) Or (MachineCode(1, RNN) >= insDEBUG And MachineCode(1, RNN) <= insSND9) Then MachineCode(1, RNN) = insBEEP
			If MachineCode(1, RNN) = insEND Then Exit For
		Next RNN
		
		If R2Present Then
			For RNN = 0 To 4999
				MachineCode(2, RNN) = MasterCode(2, RNN)
				If (MachineCode(2, RNN) >= insICON0 And MachineCode(2, RNN) <= insICON9) Or (MachineCode(2, RNN) >= insDEBUG And MachineCode(2, RNN) <= insSND9) Then MachineCode(2, RNN) = insBEEP
				If MachineCode(2, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace2() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(2) = Robot2Energy
			RDamage(2) = Robot2Damage
		End If
		
		If R3Present Then
			For RNN = 0 To 4999
				MachineCode(3, RNN) = MasterCode(3, RNN)
				If (MachineCode(3, RNN) >= insICON0 And MachineCode(3, RNN) <= insICON9) Or (MachineCode(3, RNN) >= insDEBUG And MachineCode(3, RNN) <= insSND9) Then MachineCode(3, RNN) = insBEEP
				If MachineCode(3, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace3()
			REnergy(3) = Robot3Energy
			RDamage(3) = Robot3Damage
		End If
		
		If R4Present Then
			For RNN = 0 To 4999
				MachineCode(4, RNN) = MasterCode(4, RNN)
				If (MachineCode(4, RNN) >= insICON0 And MachineCode(4, RNN) <= insICON9) Or (MachineCode(4, RNN) >= insDEBUG And MachineCode(4, RNN) <= insSND9) Then MachineCode(4, RNN) = insBEEP
				If MachineCode(4, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace4() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(4) = Robot4Energy
			RDamage(4) = Robot4Damage
		End If
		
		If R5Present Then
			For RNN = 0 To 4999
				MachineCode(5, RNN) = MasterCode(5, RNN)
				If (MachineCode(5, RNN) >= insICON0 And MachineCode(5, RNN) <= insICON9) Or (MachineCode(5, RNN) >= insDEBUG And MachineCode(5, RNN) <= insSND9) Then MachineCode(5, RNN) = insBEEP
				If MachineCode(5, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace5() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(5) = Robot5Energy
			RDamage(5) = Robot5Damage
		End If
		
		If R6Present Then
			For RNN = 0 To 4999
				MachineCode(6, RNN) = MasterCode(6, RNN)
				If (MachineCode(6, RNN) >= insICON0 And MachineCode(6, RNN) <= insICON9) Or (MachineCode(6, RNN) >= insDEBUG And MachineCode(6, RNN) <= insSND9) Then MachineCode(6, RNN) = insBEEP
				If MachineCode(6, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace6() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(6) = Robot6Energy
			RDamage(6) = Robot6Damage
		End If
		
		HowManyLeft = CheckHowManyLeft
		
		'Syncs Hardware to array
		RobotShield(1) = Robot1Shield
		RobotEnergy(1) = Robot1Energy
		RobotProSpeed(1) = Robot1ProSpeed
		RobotMissiles(1) = Robot1Missiles
		RobotTacNukes(1) = Robot1TacNukes
		RobotBullets(1) = Robot1Bullets
		RobotStunners(1) = Robot1Stunners
		RobotHellbores(1) = Robot1Hellbores
		RobotMines(1) = Robot1Mines
		RobotLasers(1) = Robot1Lasers
		RobotDrones(1) = Robot1Drones
		RobotProbes(1) = Robot1Probes
		RobotShield(2) = Robot2Shield
		RobotEnergy(2) = Robot2Energy
		RobotProSpeed(2) = Robot2ProSpeed
		RobotMissiles(2) = Robot2Missiles
		RobotTacNukes(2) = Robot2TacNukes
		RobotBullets(2) = Robot2Bullets
		RobotStunners(2) = Robot2Stunners
		RobotHellbores(2) = Robot2Hellbores
		RobotMines(2) = Robot2Mines
		RobotLasers(2) = Robot2Lasers
		RobotDrones(2) = Robot2Drones
		RobotProbes(2) = Robot2Probes
		RobotShield(3) = Robot3Shield
		RobotEnergy(3) = Robot3Energy
		RobotProSpeed(3) = Robot3ProSpeed
		RobotMissiles(3) = Robot3Missiles
		RobotTacNukes(3) = Robot3TacNukes
		RobotBullets(3) = Robot3Bullets
		RobotStunners(3) = Robot3Stunners
		RobotHellbores(3) = Robot3Hellbores
		RobotMines(3) = Robot3Mines
		RobotLasers(3) = Robot3Lasers
		RobotDrones(3) = Robot3Drones
		RobotProbes(3) = Robot3Probes
		RobotShield(4) = Robot4Shield
		RobotEnergy(4) = Robot4Energy
		RobotProSpeed(4) = Robot4ProSpeed
		RobotMissiles(4) = Robot4Missiles
		RobotTacNukes(4) = Robot4TacNukes
		RobotBullets(4) = Robot4Bullets
		RobotStunners(4) = Robot4Stunners
		RobotHellbores(4) = Robot4Hellbores
		RobotMines(4) = Robot4Mines
		RobotLasers(4) = Robot4Lasers
		RobotDrones(4) = Robot4Drones
		RobotProbes(4) = Robot4Probes
		RobotShield(5) = Robot5Shield
		RobotEnergy(5) = Robot5Energy
		RobotProSpeed(5) = Robot5ProSpeed
		RobotMissiles(5) = Robot5Missiles
		RobotTacNukes(5) = Robot5TacNukes
		RobotBullets(5) = Robot5Bullets
		RobotStunners(5) = Robot5Stunners
		RobotHellbores(5) = Robot5Hellbores
		RobotMines(5) = Robot5Mines
		RobotLasers(5) = Robot5Lasers
		RobotDrones(5) = Robot5Drones
		RobotProbes(5) = Robot5Probes
		RobotShield(6) = Robot6Shield
		RobotEnergy(6) = Robot6Energy
		RobotProSpeed(6) = Robot6ProSpeed
		RobotMissiles(6) = Robot6Missiles
		RobotTacNukes(6) = Robot6TacNukes
		RobotBullets(6) = Robot6Bullets
		RobotStunners(6) = Robot6Stunners
		RobotHellbores(6) = Robot6Hellbores
		RobotMines(6) = Robot6Mines
		RobotLasers(6) = Robot6Lasers
		RobotDrones(6) = Robot6Drones
		RobotProbes(6) = Robot6Probes
		'End Syncs Hardware to array
		
		For tempnumber = 1 To NumberOfRobotsPresent
			RobotInstPos(tempnumber) = -1 'Sets robot RobotInstPos to -1 'cause t have to start with 0 (= -1 + 1 )
			RAim(tempnumber) = 90
			RobotAlive(tempnumber) = 1
			LastHiter(tempnumber) = tempnumber
			
			RChannel(tempnumber) = 1
			TeammatesInst(tempnumber) = -1
			TeammatesParam(tempnumber) = 5
			SignalInst(tempnumber) = -1
			
			RadarInst(tempnumber) = -1
			RangeInst(tempnumber) = -1
			ChrononInst(tempnumber) = -1
			CollisionInst(tempnumber) = -1
			WallInst(tempnumber) = -1
			TopInst(tempnumber) = -1
			BotInst(tempnumber) = -1
			LeftInst(tempnumber) = -1
			RightInst(tempnumber) = -1
			RobotsInst(tempnumber) = -1
			DamageInst(tempnumber) = -1
			ShieldInst(tempnumber) = -1
			RobotsParam(tempnumber) = 6
			RadarParam(tempnumber) = 600
			RangeParam(tempnumber) = 600
			TopParam(tempnumber) = 20
			BotParam(tempnumber) = 280
			LeftParam(tempnumber) = 20
			RightParam(tempnumber) = 280
			DamageParam(tempnumber) = RDamage(tempnumber)
			ShieldParam(tempnumber) = 25
			SignalParam(tempnumber) = 1
			
			HistoryParam(tempnumber) = 1
			
			If RobotDrones(tempnumber) = 1 Then DroneShotDown = True
		Next tempnumber
		
		' Avläsningen av koden (BÖRJAN)
		'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*
		
		On Error GoTo CodeError1
		
		Dim StartTime As Single
		StartTime = VB.Timer()
		
		Do While Chronon <> MaxChronon '<>
			If RobotAlive(1) = 1 Then
				If RStunned(1) = 0 Then
					If RShield(1) > 0 Then
						If RobotShield(1) < RShield(1) Then
							RShield(1) = RShield(1) - 2
							If RShield(1) < 0 Then RShield(1) = 0 'Behövs
						Else
							If Chronon Mod 2 = 0 Then RShield(1) = RShield(1) - 1
						End If
					End If
					
					If REnergy(1) <> RobotEnergy(1) Then
						If REnergy(1) >= -200 Then
							REnergy(1) = REnergy(1) + 2
							If REnergy(1) > RobotEnergy(1) Then REnergy(1) = RobotEnergy(1)
						Else
							If EnableOverloading Then RobotAlive(1) = 255 Else REnergy(1) = REnergy(1) + 2
						End If
					End If
					
					If REnergy(1) >= 1 Then
						If RSpeedx(1) <> 0 Or RSpeedy(1) <> 0 Then 'Boosts battlespeed and reduces flickering for robots that stads still.
							RobotLeft(1) = RobotLeft(1) + RSpeedx(1)
							RobotTop(1) = RobotTop(1) + RSpeedy(1)
						End If
					End If
				End If 'RStunned
				
				'''Kollision med varandra, Skall Nu vara nästintill perfekt
				For tempnumber = 2 To NumberOfRobotsPresent
					If RobotAlive(tempnumber) = 1 Then
						If (RobotLeft(1) - RobotLeft(tempnumber)) * (RobotLeft(1) - RobotLeft(tempnumber)) + (RobotTop(1) - RobotTop(tempnumber)) * (RobotTop(1) - RobotTop(tempnumber)) <= 400 Then
							If RCollision(1) = 0 Then
								RCollision(1) = tempnumber '' Var 1 förut nu registrerar den vilken robot den kolliderar med
								If RShield(1) > 0 Then RShield(1) = RShield(1) - 1 Else RDamage(1) = RDamage(1) - 1 'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
								
								If RStunned(1) = 0 And REnergy(1) >= 1 Then
									RobotLeft(1) = RobotLeft(1) - RSpeedx(1)
									RobotTop(1) = RobotTop(1) - RSpeedy(1)
								End If
							End If
							
							If RCollision(tempnumber) = 0 Then
								RCollision(tempnumber) = 1
								If RShield(tempnumber) > 0 Then RShield(tempnumber) = RShield(tempnumber) - 1 Else RDamage(tempnumber) = RDamage(tempnumber) - 1 'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
								
								'If RStunned(TempNumber) = 0 And REnergy(TempNumber) >= 1 Then
								If RStunned(tempnumber) = 0 And REnergy(tempnumber) - 2 * CShort(tempnumber > 1) >= 1 Then
									RobotLeft(tempnumber) = RobotLeft(tempnumber) - RSpeedx(tempnumber)
									RobotTop(tempnumber) = RobotTop(tempnumber) - RSpeedy(tempnumber)
								End If
							End If
						End If
					End If
				Next tempnumber
				
				'KOLLISION MED VÄGGARNA - WALL COLLISION
				If WCX(RobotLeft(1)) Or WCY(RobotTop(1)) Then
					RWall(1) = 1
					RDamage(1) = Min(RDamage(1), RDamage(1) - 5 + RShield(1))
					RShield(1) = ZeroOrMore(RShield(1) - 5)
					
					If RobotLeft(1) > 300 Then 'otherwise it can use SPEEDX to run outside the areana!!!
						RobotLeft(1) = 300 'den har inte flyttats någonstans, vi har istället lagt till på movex
					ElseIf RobotLeft(1) < 0 Then 
						RobotLeft(1) = 0
					End If
					If RobotTop(1) > 300 Then
						RobotTop(1) = 300
					ElseIf RobotTop(1) < 0 Then 
						RobotTop(1) = 0
					End If
				Else
					RWall(1) = 0
				End If
			End If 'Alive if
			
			'ROBOT LOADING LOOP - The New Collision Stunning Shield Energy Wall Loop
			For RNN = 2 To NumberOfRobotsPresent
				If RobotAlive(RNN) = 1 Then
					If RStunned(RNN) = 0 Then
						If RShield(RNN) > 0 Then
							If RobotShield(RNN) < RShield(RNN) Then
								RShield(RNN) = RShield(RNN) - 2
								If RShield(RNN) < 0 Then RShield(RNN) = 0 'Behövs
							Else
								If Chronon Mod 2 = 0 Then RShield(RNN) = RShield(RNN) - 1
							End If
						End If
						
						If REnergy(RNN) <> RobotEnergy(RNN) Then
							If REnergy(RNN) >= -200 Then
								REnergy(RNN) = REnergy(RNN) + 2
								If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN)
							Else
								If EnableOverloading Then RobotAlive(RNN) = 255 Else REnergy(RNN) = REnergy(RNN) + 2
							End If
						End If
						
						If REnergy(RNN) >= 1 Then
							If RSpeedx(RNN) <> 0 Or RSpeedy(RNN) <> 0 Then 'Boosts battlespeed and reduces flickering for robots that stads still.
								RobotLeft(RNN) = RobotLeft(RNN) + RSpeedx(RNN)
								RobotTop(RNN) = RobotTop(RNN) + RSpeedy(RNN)
							End If
						End If
					End If 'RStunned
					
					'''Kollision med varandra, Skall Nu vara nästintill perfekt
					For tempnumber = 1 To NumberOfRobotsPresent
						If RNN <> tempnumber Then
							If RobotAlive(tempnumber) = 1 Then
								If (RobotLeft(RNN) - RobotLeft(tempnumber)) * (RobotLeft(RNN) - RobotLeft(tempnumber)) + (RobotTop(RNN) - RobotTop(tempnumber)) * (RobotTop(RNN) - RobotTop(tempnumber)) <= 400 Then
									If RCollision(RNN) = 0 Then
										RCollision(RNN) = tempnumber '' Var 1 förut nu registrerar den vilken robot den kolliderar med
										If RShield(RNN) > 0 Then RShield(RNN) = RShield(RNN) - 1 Else RDamage(RNN) = RDamage(RNN) - 1 'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
										
										If RStunned(RNN) = 0 And REnergy(RNN) >= 1 Then
											RobotLeft(RNN) = RobotLeft(RNN) - RSpeedx(RNN)
											RobotTop(RNN) = RobotTop(RNN) - RSpeedy(RNN)
										End If
									End If
									
									If RCollision(tempnumber) = 0 Then
										RCollision(tempnumber) = RNN
										If RShield(tempnumber) > 0 Then RShield(tempnumber) = RShield(tempnumber) - 1 Else RDamage(tempnumber) = RDamage(tempnumber) - 1 'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
										
										'If RStunned(TempNumber) = 0 And REnergy(TempNumber) >= 1 Then
										If RStunned(tempnumber) = 0 And REnergy(tempnumber) - 2 * CShort(tempnumber > RNN) >= 1 Then
											RobotLeft(tempnumber) = RobotLeft(tempnumber) - RSpeedx(tempnumber)
											RobotTop(tempnumber) = RobotTop(tempnumber) - RSpeedy(tempnumber)
										End If
									End If
								End If
							End If
						End If
					Next tempnumber
					
					'KOLLISION MED VÄGGARNA - WALL COLLISION
					If WCX(RobotLeft(RNN)) Or WCY(RobotTop(RNN)) Then
						RWall(RNN) = 1
						RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - 5 + RShield(RNN))
						RShield(RNN) = ZeroOrMore(RShield(RNN) - 5)
						
						If RobotLeft(RNN) > 300 Then 'otherwise it can use SPEEDX to run outside the areana!!!
							RobotLeft(RNN) = 300 'den har inte flyttats någonstans, vi har istället lagt till på movex
						ElseIf RobotLeft(RNN) < 0 Then 
							RobotLeft(RNN) = 0
						End If
						If RobotTop(RNN) > 300 Then
							RobotTop(RNN) = 300
						ElseIf RobotTop(RNN) < 0 Then 
							RobotTop(RNN) = 0
						End If
					Else
						RWall(RNN) = 0
					End If
				End If 'Alive if
			Next RNN
			
			'ROBOT 1 CHRONON EXECUTOR
			For RNN = 1 To NumberOfRobotsPresent
				If HighestToLowest Then RNN = NumberOfRobotsPresent - RNN + 1 'Turns on backwards evaluation if it's enabled
				
				If RobotAlive(RNN) = 1 Then
					If REnergy(RNN) >= 1 Then
						If RStunned(RNN) = 0 Then
							
							If TopInst(RNN) >= 0 Then
								If RSpeedy(RNN) < 0 Then
									If RobotTop(RNN) <= TopParam(RNN) Then
										If RobotTop(RNN) - RSpeedy(RNN) > TopParam(RNN) Then
											RobotQuePos(RNN) = RobotQuePos(RNN) + 1
											RobotIntQue(RNN, RobotQuePos(RNN)) = TopInst(RNN)
											IntID(RNN, RobotQuePos(RNN)) = 1
										End If
									End If
								End If
							End If
							If BotInst(RNN) >= 0 Then
								If RSpeedy(RNN) > 0 Then
									If RobotTop(RNN) >= BotParam(RNN) Then
										If RobotTop(RNN) - RSpeedy(RNN) < BotParam(RNN) Then
											RobotQuePos(RNN) = RobotQuePos(RNN) + 1
											RobotIntQue(RNN, RobotQuePos(RNN)) = BotInst(RNN)
											IntID(RNN, RobotQuePos(RNN)) = 2
										End If
									End If
								End If
							End If
							If LeftInst(RNN) >= 0 Then
								If RSpeedx(RNN) < 0 Then
									If RobotLeft(RNN) <= LeftParam(RNN) Then
										If RobotLeft(RNN) - RSpeedx(RNN) > LeftParam(RNN) Then
											RobotQuePos(RNN) = RobotQuePos(RNN) + 1
											RobotIntQue(RNN, RobotQuePos(RNN)) = LeftInst(RNN)
											IntID(RNN, RobotQuePos(RNN)) = 3
										End If
									End If
								End If
							End If
							If RightInst(RNN) >= 0 Then
								If RSpeedx(RNN) > 0 Then
									If RobotLeft(RNN) >= RightParam(RNN) Then
										If RobotLeft(RNN) - RSpeedx(RNN) < RightParam(RNN) Then
											RobotQuePos(RNN) = RobotQuePos(RNN) + 1
											RobotIntQue(RNN, RobotQuePos(RNN)) = RightInst(RNN)
											IntID(RNN, RobotQuePos(RNN)) = 4
										End If
									End If
								End If
							End If
							
							If ShieldInst(RNN) >= 0 Then 'If it's using the shield int
								If RShield(RNN) < ShieldParam(RNN) Then 'If we're in low shield
									If ShieldInst(RNN) < 5000 Then 'And we weren't in low shield last chronon (then shieldinst should be > 4999)
										RobotQuePos(RNN) = RobotQuePos(RNN) + 1 'que the
										RobotIntQue(RNN, RobotQuePos(RNN)) = ShieldInst(RNN) 'interupt
										IntID(RNN, RobotQuePos(RNN)) = 5
										ShieldInst(RNN) = ShieldInst(RNN) + 5000
									End If
								Else 'If we're not in low shield anymore
									If ShieldInst(RNN) > 4999 Then 'and our shieldinst is set to a weird value then
										ShieldInst(RNN) = ShieldInst(RNN) - 5000 'Sets back shieldinst to it's real value
									End If
								End If
							End If
							If DamageInst(RNN) >= 0 Then
								If RDamage(RNN) < DamageParam(RNN) Then
									RobotQuePos(RNN) = RobotQuePos(RNN) + 1
									RobotIntQue(RNN, RobotQuePos(RNN)) = DamageInst(RNN)
									IntID(RNN, RobotQuePos(RNN)) = 6
									DamageParam(RNN) = RDamage(RNN)
								End If
							End If
							If WallInst(RNN) >= 0 Then 'If it's using the wall int
								If RWall(RNN) <> 0 Then 'If we're in wall
									If WallInst(RNN) < 5000 Then 'And we weren't in wall last chronon (then wallinst should be > 4999)
										RobotQuePos(RNN) = RobotQuePos(RNN) + 1 'que the
										RobotIntQue(RNN, RobotQuePos(RNN)) = WallInst(RNN) 'interupt
										IntID(RNN, RobotQuePos(RNN)) = 7
										WallInst(RNN) = WallInst(RNN) + 5000
									End If
								Else 'If we're not in wall anymore
									If WallInst(RNN) > 4999 Then 'and our wall inst is set to a weird value then
										WallInst(RNN) = WallInst(RNN) - 5000 'Sets back wallinst to it's real value
									End If
								End If 'COLLISION AND WALL SHOULD BE MUCH MORE CAREFULLY TESTED!!
							End If
							If CollisionInst(RNN) >= 0 Then 'If it's using the collision int
								If RCollision(RNN) <> 0 Then 'If we're in collision
									If CollisionInst(RNN) < 5000 Then 'And we weren't in collision last chronon (then collisioninst should be > 4999)
										RobotQuePos(RNN) = RobotQuePos(RNN) + 1 'que the
										RobotIntQue(RNN, RobotQuePos(RNN)) = CollisionInst(RNN) 'interupt
										IntID(RNN, RobotQuePos(RNN)) = 8
										CollisionInst(RNN) = CollisionInst(RNN) + 5000
									End If
								Else 'If we're not in collision anymore
									If CollisionInst(RNN) > 4999 Then 'and our collision inst is set to a weird value then
										CollisionInst(RNN) = CollisionInst(RNN) - 5000 'Sets back collisioninst to it's real value
									End If
								End If
							End If
							
							If RobotQuePos(RNN) > 1 Then 'This is hopefully only a temporary solution for doubletrigging problems
								If RobotIntQue(RNN, RobotQuePos(RNN)) = RobotIntQue(RNN, RobotQuePos(RNN) - 1) And IntID(RNN, RobotQuePos(RNN)) = IntID(RNN, RobotQuePos(RNN) - 1) Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
							End If
							
							If Inton(RNN) Then
								If RobotQuePos(RNN) > 0 Then
									If RobotStackPos(RNN) > 99 Then
										ErrorCode = BuggyOverflow : GoTo Buggy
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) + 1
									RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
									RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1 'qued ints subtracted when triggered             'jumps shall be done
									Inton(RNN) = False
									RobotQuePos(RNN) = RobotQuePos(RNN) - 1
									GoTo SkipTheRestOfTheInts
								ElseIf RadarInst(RNN) >= 0 Then 
									'RADAR
									RRadar = 0
									For shotcounter = 1 To ShotNumber
										If shot(shotcounter).ShotType < 200 Then
											'This is David Harris radar code, ported to Visual Basic by me.
											trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
											trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
											
											If trigx <> 0 Then 'atan2
												tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
											Else
												tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
											End If '''''''
											
											If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
											
											If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
												RRange = FixSquare(trigx * trigx + trigy * trigy)
												If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
											End If
										End If
									Next shotcounter
									'/RADAR
									If RRadar <> 0 Then
										If RRadar <= RadarParam(RNN) Then 'intrange sends back 601 for no range instead of 0
											If RobotStackPos(RNN) > 99 Then
												ErrorCode = BuggyOverflow : GoTo Buggy
											End If
											RobotStackPos(RNN) = RobotStackPos(RNN) + 1
											RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
											RobotInstPos(RNN) = RadarInst(RNN) - 1 ' -1 är nytt
											Inton(RNN) = False
											GoTo SkipTheRestOfTheInts
										End If
									End If
								End If
								If RangeInst(RNN) >= 0 Then
									'specialrange.. designed for 1 time per chronon checking
									RRadar = RAim(RNN) + RLook(RNN)
									If 1 <> RNN Then 'Skip checking range to self. It'll be too short
										tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
										trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
										trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
										
										If trigx * trigx + trigy * trigy <= 91 Then
											If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
												If RobotAlive(1) = 1 Then
													If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
														If RobotStackPos(RNN) > 99 Then
															ErrorCode = BuggyOverflow : GoTo Buggy
														End If
														RobotStackPos(RNN) = RobotStackPos(RNN) + 1
														RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
														RobotInstPos(RNN) = RangeInst(RNN) - 1 ' -1 är nytt
														Inton(RNN) = False
														GoTo SkipTheRestOfTheInts
													End If
												End If
											End If
										End If
									End If
									
									For shotcounter = 2 To NumberOfRobotsPresent
										If shotcounter <> RNN Then 'Skip checking range to self. It'll be too short
											tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
											trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
											trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
											
											If trigx * trigx + trigy * trigy <= 91 Then
												If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
													If RobotAlive(shotcounter) = 1 Then
														If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
															If RobotStackPos(RNN) > 99 Then
																ErrorCode = BuggyOverflow : GoTo Buggy
															End If
															RobotStackPos(RNN) = RobotStackPos(RNN) + 1
															RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
															RobotInstPos(RNN) = RangeInst(RNN) - 1 ' -1 är nytt
															Inton(RNN) = False
															GoTo SkipTheRestOfTheInts
														End If
													End If
												End If
											End If
										End If
									Next shotcounter
									'''''''''''
								End If
								If ChrononInst(RNN) >= 0 Then
									If ChrononParam(RNN) <= Chronon Then
										If RobotStackPos(RNN) > 99 Then
											ErrorCode = BuggyOverflow : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) + 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
										RobotInstPos(RNN) = ChrononInst(RNN) - 1
										Inton(RNN) = False
									End If
								End If
							End If
							
SkipTheRestOfTheInts: 
							
							'Typ här skall hasmoved bli falskt
							HasMoved = 0
							
							'''Slut INTERUPPSKODEN
							For ChrononExecutor1 = 1 To RobotProSpeed(RNN)
								RobotInstPos(RNN) = RobotInstPos(RNN) + 1
								
								'It my tests shows, that in the following Select Case coditional, best speed results are gained when the most
								'common instructions are placed first.
								
								Select Case MachineCode(RNN, RobotInstPos(RNN)) 'MachineCode
									Case -19999 To 19999
										If RobotStackPos(RNN) > 99 Then
											ErrorCode = BuggyOverflow : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) + 1
										RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
									Case insA To TOPREGISTER
										If RobotStackPos(RNN) > 99 Then
											ErrorCode = BuggyOverflow : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) + 1
										RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
									Case insSTORE
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										Select Case RobotStack(RNN, RobotStackPos(RNN))
											Case insAIM 'ins
												RAim(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Mod 360
												If RAim(RNN) < 0 Or RAim(RNN) > 359 Then RAim(RNN) = RAim(RNN) Mod 360 - 360 * CShort(RAim(RNN) < 0)
												
												If Inton(RNN) Then '**********Interuppskod************'
													If RadarInst(RNN) >= 0 Then
														'RADAR
														RRadar = 0
														For shotcounter = 1 To ShotNumber
															If shot(shotcounter).ShotType < 200 Then
																'This is David Harris radar code, ported to Visual Basic by me.
																trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
																trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
																
																If trigx <> 0 Then 'atan2
																	tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
																Else
																	tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
																End If '''''''
																
																If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
																
																If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
																	RRange = FixSquare(trigx * trigx + trigy * trigy)
																	If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
																End If
															End If
														Next shotcounter
														'/RADAR
														If RRadar <> 0 Then
															If RRadar <= RadarParam(RNN) Then 'intrange sends back 601 for no range instead of 0
																RobotStackPos(RNN) = RobotStackPos(RNN) - 1
																RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
																RobotInstPos(RNN) = RadarInst(RNN) - 1
																Inton(RNN) = False
																GoTo NoStackRemoval
															End If
														End If
													End If
													If RangeInst(RNN) >= 0 Then
														'specialrange.. designed för look and aim instructions
														RRadar = RAim(RNN) + RLook(RNN)
														If 1 <> RNN Then 'Skip checking range to self. It'll be too short
															tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
															trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
															trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
															
															If trigx * trigx + trigy * trigy <= 91 Then
																If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
																	If RobotAlive(1) = 1 Then
																		If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
																			RobotStackPos(RNN) = RobotStackPos(RNN) - 1
																			RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
																			RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
																			Inton(RNN) = False
																			GoTo NoStackRemoval
																		End If
																	End If
																End If
															End If
														End If
														
														For shotcounter = 2 To NumberOfRobotsPresent
															If shotcounter <> RNN Then 'Skip checking range to self. It'll be too short
																tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
																trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
																trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
																
																If trigx * trigx + trigy * trigy <= 91 Then
																	If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
																		If RobotAlive(shotcounter) = 1 Then
																			If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
																				RobotStackPos(RNN) = RobotStackPos(RNN) - 1
																				RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
																				RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
																				Inton(RNN) = False
																				GoTo NoStackRemoval
																			End If
																		End If
																	End If
																End If
															End If
														Next shotcounter
														'''''''''''
													End If
												End If '**********Slut Interuppskod************'
											Case insSPEEDX 'ins
												If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1))
												REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RSpeedx(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
												RSpeedx(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insSPEEDY 'ins
												If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1))
												REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RSpeedy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
												RSpeedy(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insMISSILE 'ins
												If RobotMissiles(RNN) = 0 Then
													ErrorCode = BuggyMissiles
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
														If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotAngle = RAim(RNN)
																shot(ShotNumber).ShotType = Missile
																shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
																shot(ShotNumber).Shooter = RNN
															Else
																shot(FreeShot).ShotAngle = RAim(RNN)
																shot(FreeShot).ShotType = Missile
																shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
																shot(FreeShot).Shooter = RNN
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insFIRE 'ins
Robot1Fire: 
												If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
													REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
													If HasMoved <> 5 Or MoveAndShotAllowed Then
														If FreeShot = -1 Then
															ShotNumber = ShotNumber + 1
															shot(ShotNumber).ShotAngle = RAim(RNN)
															shot(ShotNumber).ShotType = Bullet
															shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
															shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
															shot(ShotNumber).Shooter = RNN
															Select Case RobotBullets(RNN)
																Case 0
																	shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2 '/
																Case 2
																	shot(ShotNumber).ShotType = ExplosiveBullet
																	shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																Case 20
																	RobotBullets(RNN) = 2
																	shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																Case Else
																	shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															End Select
														Else
															shot(FreeShot).ShotAngle = RAim(RNN)
															shot(FreeShot).ShotType = Bullet
															shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
															shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
															shot(FreeShot).Shooter = RNN
															Select Case RobotBullets(RNN)
																Case 0
																	shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2 '
																Case 2
																	shot(FreeShot).ShotType = ExplosiveBullet
																	shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																Case 20
																	RobotBullets(RNN) = 2
																	shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																Case Else
																	shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															End Select
															FreeShot = -1
														End If
														HasMoved = 20
													Else
														ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
													End If
												End If
											Case insSHIELD 'ins
												If RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then 'Prevent negative shield
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 150 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 150 'Prevent shield over 150
													REnergy(RNN) = REnergy(RNN) + RShield(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Takes or energy restores energy to/from shield
													If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN) 'Prevent energy higher than Robots Energy Max
													RShield(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Sets shield
												End If
											Case insSTUNNER 'ins
												If RobotStunners(RNN) = 0 Then
													ErrorCode = BuggyStunners
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
														If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then 'Stunner don't use freeshots because of the (Stunstreamer - Freeshot) visual bug which is fixed so they do
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotAngle = RAim(RNN)
																shot(ShotNumber).ShotType = Stunner
																shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4 'Int((RobotStack(RNN, RobotStackPos(RNN) - 1)) / 4)
															Else
																shot(FreeShot).ShotAngle = RAim(RNN)
																shot(FreeShot).ShotType = Stunner
																shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insMOVEX 'ins
												REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
												If HasMoved <> 20 Or MoveAndShotAllowed Then
													RobotLeft(RNN) = RobotLeft(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
													'TurretX2(RNN) = TurretX2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
													If RobotLeft(RNN) > 300 Then 'otherwise it can use MOVEX to jump outside the areana!!!
														RobotLeft(RNN) = 300
														'TurretX2(RNN) = 300 + TurretX2(RNN) - RobotLeft(RNN)
													ElseIf RobotLeft(RNN) < 0 Then 
														RobotLeft(RNN) = 0
														'TurretX2(RNN) = TurretX2(RNN) - RobotLeft(RNN)
													End If
													HasMoved = 5
												Else
													ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
												End If
											Case insMOVEY 'ins
												REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
												If HasMoved <> 20 Or MoveAndShotAllowed Then
													RobotTop(RNN) = RobotTop(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
													'TurretY2(RNN) = TurretY2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
													If RobotTop(RNN) > 300 Then 'otherwise it can use MOVEX to jump outside the areana!!!
														RobotTop(RNN) = 300
														'TurretY2(RNN) = 300 + TurretY2(RNN) - RobotTop(RNN)
													ElseIf RobotTop(RNN) < 0 Then 
														RobotTop(RNN) = 0
														'TurretY2(RNN) = TurretY2(RNN) - RobotTop(RNN)
													End If
													HasMoved = 5
												Else
													ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
												End If
											Case insHELLBORE 'ins
												If RobotHellbores(RNN) = 0 Then
													ErrorCode = BuggyHellbores
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 3 And RobotStack(RNN, RobotStackPos(RNN) - 1) < 21 Then
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotAngle = RAim(RNN)
																shot(ShotNumber).ShotType = Hellbore
																shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															Else
																shot(FreeShot).ShotAngle = RAim(RNN)
																shot(FreeShot).ShotType = Hellbore
																shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insA : RA(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insB : RB(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insC : RC(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insD : RD(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insE : RE(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insF : RF(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insG : RG(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insH : RH(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insI : RI(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insJ : RJ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insK : RK(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insL : RL(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insM : RM(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insN : RN(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insO : RO(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insP : RP(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insQ : RQ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insR : RR(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insS : RS(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case Inst : RT(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insU : RU(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insV : RV(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insZ : RZ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insW : RW(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insLOOK 'ins
												RLook(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RLook(RNN) > 359 Then RLook(RNN) = RLook(RNN) Mod 360
												If RLook(RNN) < 0 Then RLook(RNN) = RLook(RNN) Mod 360 + 360
												If Inton(RNN) And RangeInst(RNN) >= 0 Then '**********Interuppskod************
													'specialrange.. designed för look and aim instructions
													RRadar = RAim(RNN) + RLook(RNN)
													If 1 <> RNN Then 'Skip checking range to self. It'll be too short
														tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
														trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
														trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
														
														If trigx * trigx + trigy * trigy <= 91 Then
															If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
																If RobotAlive(1) = 1 Then
																	If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
																		RobotStackPos(RNN) = RobotStackPos(RNN) - 1
																		RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
																		RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
																		Inton(RNN) = False
																		GoTo NoStackRemoval
																	End If
																End If
															End If
														End If
													End If
													
													For shotcounter = 2 To NumberOfRobotsPresent
														If shotcounter <> RNN Then 'Skip checking range to self. It'll be too short
															tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
															trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
															trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
															
															If trigx * trigx + trigy * trigy <= 91 Then
																If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
																	If RobotAlive(shotcounter) = 1 Then
																		If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
																			RobotStackPos(RNN) = RobotStackPos(RNN) - 1
																			RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
																			RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
																			Inton(RNN) = False
																			GoTo NoStackRemoval
																		End If
																	End If
																End If
															End If
														End If
													Next shotcounter
													'''''''''''
												End If '**********Slut Interuppskod************'
											Case insBULLET 'ins                                 'It seems like a robot can mess up it's explosive
												If RobotBullets(RNN) = 2 Then RobotBullets(RNN) = 20 'bullets by firing negative shots. It's certainly
												GoTo Robot1Fire 'not an adventage, so it' can't be considered cheating
											Case insNUKE 'ins
												If RobotTacNukes(RNN) = 0 Then
													ErrorCode = BuggyTacNukes
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotFireTime = Chronon
																shot(ShotNumber).ShotType = TakeNuke
																shot(ShotNumber).ShotX = RobotLeft(RNN)
																shot(ShotNumber).ShotY = RobotTop(RNN)
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																shot(ShotNumber).Shooter = RNN
															Else
																shot(FreeShot).ShotFireTime = Chronon
																shot(FreeShot).ShotType = TakeNuke
																shot(FreeShot).ShotX = RobotLeft(RNN)
																shot(FreeShot).ShotY = RobotTop(RNN)
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																shot(FreeShot).Shooter = RNN
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insMEGANUKE 'ins
												If RobotTacNukes(RNN) = 0 Then
													ErrorCode = BuggyTacNukes
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotFireTime = Chronon
																shot(ShotNumber).ShotType = MegaNuke
																shot(ShotNumber).ShotX = RobotLeft(RNN)
																shot(ShotNumber).ShotY = RobotTop(RNN)
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																shot(ShotNumber).Shooter = RNN
															Else
																shot(FreeShot).ShotFireTime = Chronon
																shot(FreeShot).ShotType = MegaNuke
																shot(FreeShot).ShotX = RobotLeft(RNN)
																shot(FreeShot).ShotY = RobotTop(RNN)
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																shot(FreeShot).Shooter = RNN
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insMINE 'ins
												If RobotMines(RNN) = 0 Then
													ErrorCode = BuggyMines
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) - 5 > 0 Then
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotFireTime = Chronon
																shot(ShotNumber).ShotType = Mine
																shot(ShotNumber).ShotX = RobotLeft(RNN)
																shot(ShotNumber).ShotY = RobotTop(RNN)
																shot(ShotNumber).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
																shot(ShotNumber).Shooter = RNN
															Else
																shot(FreeShot).ShotFireTime = Chronon
																shot(FreeShot).ShotType = Mine
																shot(FreeShot).ShotX = RobotLeft(RNN)
																shot(FreeShot).ShotY = RobotTop(RNN)
																shot(FreeShot).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
																shot(FreeShot).Shooter = RNN
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insLASER 'ins
												If RobotLasers(RNN) = 0 Then
													ErrorCode = BuggyLasers
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then ' It is possible in the Mac version to shoot laser shots that actually doesn't do any harm
														If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'It seems to be possible to shoot laser at dead robots
															'If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
															If RobotAlive(RangedRobot(RNN)) = 1 Then
																If RobotStack(RNN, RobotStackPos(RNN) - 1) > REnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = REnergy(RNN)
																
																REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
																If HasMoved <> 5 Or MoveAndShotAllowed Then
																	TurretX2(RNN) = RobotLeft(RNN) + Sin10(RAim(RNN)) 'Sets the turret x2 for the aim
																	TurretY2(RNN) = RobotTop(RNN) - Cos10(RAim(RNN)) 'since it's used in non-displayed for laser
																	
																	If FreeShot = -1 Then
																		ShotNumber = ShotNumber + 1
																		shot(ShotNumber).ShotType = Laser
																		shot(ShotNumber).ShotAngle = RangedRobot(RNN)
																		shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
																		shot(ShotNumber).Shooter = RNN
																		shot(ShotNumber).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN) 'Shows laser on radar instantly
																		shot(ShotNumber).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
																	Else
																		shot(FreeShot).ShotType = Laser
																		shot(FreeShot).ShotAngle = RangedRobot(RNN)
																		shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
																		shot(FreeShot).Shooter = RNN
																		shot(FreeShot).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN) 'Shows laser on radar instantly
																		shot(FreeShot).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
																		FreeShot = -1
																	End If
																	HasMoved = 20
																Else
																	ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
																End If
															End If
														End If
													End If
												End If
											Case insDRONE 'ins
												If RobotDrones(RNN) = 0 Then
													ErrorCode = BuggyDrones
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 And Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'Range <> 0
														If RobotAlive(RangedRobot(RNN)) = 1 Then 'Cuts down the shot power to the Robots energy max
															If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
															REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
															If HasMoved <> 5 Or MoveAndShotAllowed Then
																If FreeShot = -1 Then
																	ShotNumber = ShotNumber + 1
																	shot(ShotNumber).ShotAngle = RangedRobot(RNN) 'Shootangle represents tracking robot
																	shot(ShotNumber).ShotFireTime = Chronon + 100 'ShotFireTime represents the chronon the drone die
																	shot(ShotNumber).ShotType = Drone
																	shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																	shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																	shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
																	shot(ShotNumber).Shooter = RNN
																Else
																	shot(FreeShot).ShotAngle = RangedRobot(RNN) 'Shootangle represents tracking robot
																	shot(FreeShot).ShotFireTime = Chronon + 100 'ShotFireTime represents the chronon the drone die
																	shot(FreeShot).ShotType = Drone
																	shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																	shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																	shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
																	shot(FreeShot).Shooter = RNN
																	FreeShot = -1
																End If
																HasMoved = 20
															Else
																ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
															End If
														End If
													End If
												End If
											Case insSCAN 'ins
												RScan(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RScan(RNN) > 359 Then RScan(RNN) = RScan(RNN) Mod 360
												If RScan(RNN) < 0 Then RScan(RNN) = RScan(RNN) Mod 360 + 360
												If Inton(RNN) And RadarInst(RNN) >= 0 Then
													'RADAR
													RRadar = 0
													For shotcounter = 1 To ShotNumber
														If shot(shotcounter).ShotType < 200 Then
															'This is David Harris radar code, ported to Visual Basic by me.
															trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
															trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
															
															If trigx <> 0 Then 'atan2
																tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
															Else
																tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
															End If '''''''
															
															If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
															
															If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
																RRange = FixSquare(trigx * trigx + trigy * trigy)
																If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
															End If
														End If
													Next shotcounter
													'/RADAR
													If RRadar <> 0 Then
														If RRadar <= RadarParam(RNN) Then
															RobotStackPos(RNN) = RobotStackPos(RNN) - 1
															RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
															RobotInstPos(RNN) = RadarInst(RNN) - 1 ' - 1 nytt
															Inton(RNN) = False
															GoTo NoStackRemoval
														End If
													End If
												End If
											Case insHISTORY 'ins
												If HistoryParam(RNN) >= 31 Then HistoryRec(RNN, HistoryParam(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insSIGNAL
												If RobotTeam(RNN) <> 0 Then
													RSignal(RobotTeam(RNN), RChannel(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
													
													For tempnumber = 1 To NumberOfRobotsPresent
														If RobotTeam(RNN) = RobotTeam(tempnumber) Then
															If tempnumber <> RNN Then
																If SignalInst(tempnumber) >= 0 Then
																	If SignalParam(tempnumber) = RChannel(RNN) Then
																		RobotQuePos(tempnumber) = RobotQuePos(tempnumber) + 1
																		RobotIntQue(tempnumber, RobotQuePos(tempnumber)) = SignalInst(tempnumber)
																		IntID(tempnumber, RobotQuePos(tempnumber)) = 11
																	End If
																End If
															End If
														End If
													Next tempnumber
												End If
											Case insCHANNEL
												RChannel(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RChannel(RNN) > 10 Or RChannel(RNN) < 1 Then
													ErrorCode = BuggyChannel : GoTo Buggy
												End If
											Case Else
												ErrorCode = BuggyStore
												GoTo Buggy
										End Select
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
NoStackRemoval: 
									Case insRECALL 'Removing the Reversed Recalls took exactly 3 hours and 29 minutes, including speed testing but
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyRecall : GoTo Buggy
										End If
										
										Select Case RobotStack(RNN, RobotStackPos(RNN)) 'excluding recompiling all robots
											Case insRANGE 'ins
												RRange = Range(RNN, RAim(RNN) + RLook(RNN))
												If RRange <> 0 Then
													If RobotAlive(RangedRobot(RNN)) <> 1 Then RRange = 0
												End If
												RobotStack(RNN, RobotStackPos(RNN)) = RRange
											Case insAIM 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RAim(RNN)
											Case insX 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RobotLeft(RNN)
											Case insY 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RobotTop(RNN)
											Case insRADAR 'ins
												'RADAR
												RRadar = 0 'RRadar
												For shotcounter = 1 To ShotNumber
													If shot(shotcounter).ShotType < 200 Then
														'This is David Harris radar code, ported to Visual Basic by me.
														trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
														trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
														
														If trigx <> 0 Then 'atan2
															tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
														Else
															tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
														End If '''''''
														
														If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
														
														If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
															RRange = FixSquare(trigx * trigx + trigy * trigy)
															If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
														End If
													End If
												Next shotcounter
												'/RADAR
												RobotStack(RNN, RobotStackPos(RNN)) = RRadar
											Case insSPEEDX 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RSpeedx(RNN)
											Case insSPEEDY 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RSpeedy(RNN)
											Case insENERGY 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RNN)
											Case insSHIELD 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RShield(RNN)
											Case insLOOK 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RLook(RNN)
											Case insDOPPLER 'ins
												'Many Thanks to Sam Rushing who helped me out
												'and explained how the Doppler routine worked.    'Dead robot are set to E = -10
												
												'Prfnoff's version - Robots with E -1 has doppler?
												'4.5.2 - Robots med E -1 doesn't have doppler
												
												If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'Med allra allra största sannolikhet skall jag använda RealStunned
													If REnergy(RangedRobot(RNN)) <= 0 Or RStunned(RangedRobot(RNN)) <> 0 Or RCollision(RangedRobot(RNN)) <> 0 Then 'RWall(RangedRobot(RNN)) <> 0 Or
														RobotStack(RNN, RobotStackPos(RNN)) = 0
													Else
														RRange = RobotLeft(RNN) - RobotLeft(RangedRobot(RNN)) 'xdiff
														RRadar = RobotTop(RNN) - RobotTop(RangedRobot(RNN)) 'ydiff
														'Ej testat om det skall vara round eller fix, kolla
														RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Round((RSpeedx(RangedRobot(RNN)) * RRadar - RRange * RSpeedy(RangedRobot(RNN))) / Square(RRadar * RRadar + RRange * RRange)) 'Round
													End If
												Else
													RobotStack(RNN, RobotStackPos(RNN)) = 0
												End If
											Case insNEAREST
												If RobotProSpeed(RNN) <= 10 Then
													If NumberOfRobotsPresent > 1 Then
														tempnumber = Nearest(RNN)
														If RobotAlive(tempnumber) = 1 Then
															If RobotTop(tempnumber) <> RobotTop(RNN) Then
																If RobotTop(RNN) > RobotTop(tempnumber) Then
																	RobotStack(RNN, RobotStackPos(RNN)) = (System.Math.Round(TPI * System.Math.Atan((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN))))) - RAim(RNN)
																Else
																	RobotStack(RNN, RobotStackPos(RNN)) = (System.Math.Round(TPI * System.Math.Atan((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN)))) + 180) - RAim(RNN)
																End If
															Else
																If RobotLeft(RNN) < RobotLeft(tempnumber) Then
																	RobotStack(RNN, RobotStackPos(RNN)) = 90 - RAim(RNN)
																Else
																	RobotStack(RNN, RobotStackPos(RNN)) = 270 - RAim(RNN)
																End If
															End If
															
															If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 360
														Else
															RobotStack(RNN, RobotStackPos(RNN)) = -1
														End If
													Else
														RobotStack(RNN, RobotStackPos(RNN)) = -1
													End If
												Else
													ErrorCode = BuggyNearest
													GoTo Buggy
												End If
											Case insROBOTS 'ins
												If HowManyLeft = 255 Then
													RobotStack(RNN, RobotStackPos(RNN)) = 1
												ElseIf R2Present Then 
													RobotStack(RNN, RobotStackPos(RNN)) = HowManyLeft
												Else
													RobotStack(RNN, RobotStackPos(RNN)) = 1
												End If
											Case insCHRONON 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = Chronon
											Case insCOLLISION 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Sign(RCollision(RNN))
											Case insA 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RA(RNN)
											Case insB 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RB(RNN)
											Case insC 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RC(RNN)
											Case insD 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RD(RNN)
											Case insE 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RE(RNN)
											Case insF 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RF(RNN)
											Case insG 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RG(RNN)
											Case insH 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RH(RNN)
											Case insI 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RI(RNN)
											Case insJ 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RJ(RNN)
											Case insK 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RK(RNN)
											Case insL 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RL(RNN)
											Case insM 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RM(RNN)
											Case insN 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RN(RNN)
											Case insO 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RO(RNN)
											Case insP 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RP(RNN)
											Case insQ 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RQ(RNN)
											Case insR 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RR(RNN)
											Case insS 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RS(RNN)
											Case Inst 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RT(RNN)
											Case insU 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RU(RNN)
											Case insV 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RV(RNN)
											Case insZ 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RZ(RNN)
											Case insW 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RW(RNN)
											Case insPROBE 'ins
												If RobotProbes(RNN) = 0 Then
													ErrorCode = BuggyProbes
													GoTo Buggy
												Else
													If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then
														If RobotAlive(RangedRobot(RNN)) <> 1 Then
															RobotStack(RNN, RobotStackPos(RNN)) = 0
														Else
															Select Case ProbeSet(RNN)
																'0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
																'4 = Teammates - Currently disabled 'cause of no teams
																Case 1
																	RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RangedRobot(RNN))
																Case 0
																	RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RangedRobot(RNN))
																Case 2
																	RobotStack(RNN, RobotStackPos(RNN)) = RShield(RangedRobot(RNN))
																Case 7
																	RobotStack(RNN, RobotStackPos(RNN)) = RScan(RangedRobot(RNN))
																Case 3
																	RobotStack(RNN, RobotStackPos(RNN)) = RangedRobot(RNN) - 1 '0 to 5
																Case 5
																	RobotStack(RNN, RobotStackPos(RNN)) = RAim(RangedRobot(RNN))
																Case 6
																	RobotStack(RNN, RobotStackPos(RNN)) = RLook(RangedRobot(RNN))
																Case 4
																	RobotStack(RNN, RobotStackPos(RNN)) = 0
																	For tempnumber = 1 To NumberOfRobotsPresent
																		If tempnumber <> RangedRobot(RNN) Then
																			If RobotTeam(tempnumber) = RobotTeam(RangedRobot(RNN)) Then
																				If RobotAlive(tempnumber) = 1 Then
																					RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
																				End If
																			End If
																		End If
																	Next tempnumber
															End Select
														End If
													Else
														RobotStack(RNN, RobotStackPos(RNN)) = 0
													End If
												End If
											Case insWALL 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RWall(RNN)
											Case insDAMAGE 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RNN)
											Case insRANDOM 'ins
												If RunningTournament Then
													RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Round((359 + 1) * Rnd()) 'Int
												Else
													If Replaying And NotRandomEmergency Then
														RobotStack(RNN, RobotStackPos(RNN)) = RandomRegister(RandomCounter)
													Else
														RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Round((359 + 1) * Rnd()) 'Int
														ReDim Preserve RandomRegister(RandomCounter)
														RandomRegister(RandomCounter) = RobotStack(RNN, RobotStackPos(RNN))
													End If
													RandomCounter = RandomCounter + 1
												End If
											Case insSCAN 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RScan(RNN)
											Case insID 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RNN - 1 '0 to 5
											Case insHISTORY 'ins     'If repeat battle is checked we should read from the backup rec, unless we're using user defined history, in case we should read from the regular rec, since regular rec 31-50 is reset at the end of a repeated battle
												If Replaying And HistoryParam(RNN) < 31 Then RobotStack(RNN, RobotStackPos(RNN)) = BackupHistoryRec(RNN, HistoryParam(RNN)) Else RobotStack(RNN, RobotStackPos(RNN)) = HistoryRec(RNN, HistoryParam(RNN))
											Case insKILLS 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = KR(RNN)
											Case insSIGNAL
												If RobotTeam(RNN) <> 0 Then
													RobotStack(RNN, RobotStackPos(RNN)) = RSignal(RobotTeam(RNN), RChannel(RNN))
												Else
													RobotStack(RNN, RobotStackPos(RNN)) = 0
												End If
											Case insFRIEND
												If RCollision(RNN) <> 0 And RobotTeam(RNN) <> 0 Then
													If RobotTeam(RCollision(RNN)) = RobotTeam(RNN) Then RobotStack(RNN, RobotStackPos(RNN)) = 1 Else RobotStack(RNN, RobotStackPos(RNN)) = 0
												Else
													RobotStack(RNN, RobotStackPos(RNN)) = 0
												End If
											Case insCHANNEL
												RobotStack(RNN, RobotStackPos(RNN)) = RChannel(RNN)
											Case insTEAMMATES
												RobotStack(RNN, RobotStackPos(RNN)) = 0
												For tempnumber = 1 To NumberOfRobotsPresent
													If tempnumber <> RNN Then
														If RobotTeam(tempnumber) = RobotTeam(RNN) Then
															If RobotAlive(tempnumber) = 1 Then
																RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
															End If
														End If
													End If
												Next tempnumber
											Case Else
												ErrorCode = BuggyRecall '& RobotStack(RNN, RobotStackPos(RNN))
												GoTo Buggy
										End Select
									Case insIF 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
											RobotStackPos(RNN) = RobotStackPos(RNN) - 2
										Else
											tempnumber = RobotInstPos(RNN) + 1 'Tempnumber gav ingen hastighetsökning
											If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
											RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
											RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										End If
									Case insMORE
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) >= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insJUMP 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
											RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
										Else
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insIFG 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
											If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
									Case insPLUS
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + RobotStack(RNN, RobotStackPos(RNN) + 1)
										If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
											ErrorCode = BuggyNumberOutofBounds : GoTo Buggy
										End If
									Case insLESS
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) <= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insSYNC 'Rep'
										Exit For
									Case insDUP 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStackPos(RNN) > 99 Then
											ErrorCode = BuggyOverflow : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) + 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
									Case insSETINT 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 1) > 4999 Or RobotStack(RNN, RobotStackPos(RNN) - 1) < -1 Then
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
										
										Select Case RobotStack(RNN, RobotStackPos(RNN))
											Case insRANGE ' 'Rep'
												RangeInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insLEFT ' 'Rep'
												LeftInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If LeftInst(RNN) = -1 Then 'BUG ALERT!! Detta klarar bara om första stacknumret är
													If RobotQuePos(RNN) <> 0 Then 'hett! Tillfällig lösning
														If IntID(RNN, RobotQuePos(RNN)) = 3 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insRIGHT ' 'Rep'
												RightInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RightInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 4 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insTOP ' 'Rep'
												TopInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If TopInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 1 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insBOT ' 'Rep'
												BotInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If BotInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 2 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insWALL ' 'Rep'
												WallInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If WallInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 7 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insCOLLISION ' 'Rep'
												CollisionInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If CollisionInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 8 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insROBOTS ' 'Rep'
												RobotsInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RobotsInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 9 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insCHRONON ' 'Rep'
												ChrononInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insRADAR ' 'Rep'
												RadarInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insDAMAGE ' 'Rep'
												DamageInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If DamageInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 6 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insSHIELD ' 'Rep'
												ShieldInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If ShieldInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 5 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												Else 'Else är nytt - tidigare stod If Rshieled utanför if
													If RShield(RNN) < ShieldParam(RNN) Then ShieldInst(RNN) = ShieldInst(RNN) + 5000
												End If
											Case insTEAMMATES ' 'Rep'
												TeammatesInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If TeammatesInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 10 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insSIGNAL ' 'Rep'
												SignalInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If SignalInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 11 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case Else
												ErrorCode = BuggySetint
												GoTo Buggy
										End Select
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
									Case insRTI 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										Inton(RNN) = True
										If RobotQuePos(RNN) <= 0 Then
											If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
											RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										Else
											RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1 'qued ints subtracted when triggered             'jumps shall be done
											Inton(RNN) = False
											RobotQuePos(RNN) = RobotQuePos(RNN) - 1
										End If
									Case insSETPARAM 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										Select Case RobotStack(RNN, RobotStackPos(RNN))
											Case insRANGE ' 'Rep'
												RangeParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insLEFT ' 'Rep'
												LeftParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insRIGHT ' 'Rep'
												RightParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insTOP ' 'Rep'
												TopParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insBOT ' 'Rep'
												BotParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insPROBE ' 'Rep'
												'0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
												'4 = Teammates - Currently disabled 'cause of no teams
												Select Case RobotStack(RNN, RobotStackPos(RNN) - 1)
													Case insDAMAGE ' 'Rep'
														ProbeSet(RNN) = 0
													Case insENERGY ' 'Rep'
														ProbeSet(RNN) = 1
													Case insSHIELD ' 'Rep'
														ProbeSet(RNN) = 2
													Case insSCAN ' 'Rep'
														ProbeSet(RNN) = 7
													Case insID ' 'Rep'
														ProbeSet(RNN) = 3
													Case insAIM ' 'Rep'
														ProbeSet(RNN) = 5
													Case insLOOK ' 'Rep'
														ProbeSet(RNN) = 6
													Case insTEAMMATES ' 'Rep'
														ProbeSet(RNN) = 4
														'                                    Case Else
														'                                        ErrorCode =  'Rep'Illegal 'PROBE' register  'Rep' & RobotStack(RNN, RobotStackPos(RNN))
														'                                        GoTo Buggy
												End Select
											Case insRADAR ' 'Rep'
												RadarParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insCHRONON ' 'Rep'
												ChrononParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insROBOTS ' 'Rep'
												RobotsParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insDAMAGE ' 'Rep'
												DamageParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If DamageParam(RNN) > RDamage(RNN) Then DamageParam(RNN) = RDamage(RNN)
											Case insHISTORY ' 'Rep'
												HistoryParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insSHIELD ' 'Rep'
												ShieldParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insTEAMMATES ' 'Rep'
												TeammatesParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insSIGNAL
												SignalParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case Else
												ErrorCode = BuggySetparam
												GoTo Buggy
										End Select
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
									Case insCALL 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										tempnumber = RobotInstPos(RNN) + 1
										If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
											RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
										Else
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
										RobotStack(RNN, RobotStackPos(RNN)) = tempnumber
									Case insAND 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) = 0 Or RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insMINUS
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) - RobotStack(RNN, RobotStackPos(RNN) + 1)
										If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
											ErrorCode = BuggyNumberOutofBounds : GoTo Buggy
										End If
									Case insINTON 'Rep'
										Inton(RNN) = True
										If RobotQuePos(RNN) > 0 Then
											If RobotStackPos(RNN) > 99 Then
												ErrorCode = BuggyOverflow : GoTo Buggy
											End If
											RobotStackPos(RNN) = RobotStackPos(RNN) + 1
											RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
											RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1 'qued ints subtracted when triggered             'jumps shall be done
											Inton(RNN) = False
											RobotQuePos(RNN) = RobotQuePos(RNN) - 1
										End If
									Case insDIVISION
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
											ErrorCode = BuggyDivision : GoTo Buggy
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) \ RobotStack(RNN, RobotStackPos(RNN) + 1)
									Case insTIMES
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) * RobotStack(RNN, RobotStackPos(RNN) + 1)
										If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
											ErrorCode = BuggyNumberOutofBounds : GoTo Buggy
										End If
									Case insSAME
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insBEEP 'Rep' 'Represents all icon snd instructions, debug, print and beep  for undisplayed
										ChrononExecutor1 = ChrononExecutor1 - 1
									Case insARCTAN 'Rep'                                       'Shall not use Fix!!
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = System.Math.Round(TPI * System.Math.Atan(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)) + 90 - (90 * (System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1)) - 1)))
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) * (System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) + 1)
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insDROPALL 'Rep'
										RobotStackPos(RNN) = 0
									Case insNOT 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
											RobotStack(RNN, RobotStackPos(RNN)) = 1
										Else
											RobotStack(RNN, RobotStackPos(RNN)) = 0 'Nej, dethär går inte att förenkla
										End If
									Case insDROP 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insSWAP 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										tempnumber = RobotStack(RNN, RobotStackPos(RNN))
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
									Case insIFEG 'Rep'
										If RobotStackPos(RNN) < 3 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
											If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
										Else
											If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 3
									Case insVRECALL 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) < 0 Or RobotStack(RNN, RobotStackPos(RNN)) > 100 Then
											RobotStack(RNN, RobotStackPos(RNN)) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN)) = RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN)))
										End If
									Case insMOD 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN) - 1) Mod RobotStack(RNN, RobotStackPos(RNN))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insOR 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) = 0 And RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insIFE 'Rep'
										If RobotStackPos(RNN) < 3 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
											tempnumber = RobotInstPos(RNN) + 1
											If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
											RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
											RobotStackPos(RNN) = RobotStackPos(RNN) - 2
										Else
											tempnumber = RobotInstPos(RNN) + 1 'Samma sak här, det borde funka med tempnumber
											If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
											RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
											RobotStackPos(RNN) = RobotStackPos(RNN) - 2
										End If
									Case insMAX 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) > RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insSIN 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * System.Math.Sin(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insCOS 'Rep'              'Fix avrundar exact som Mac RoboWar!!
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * System.Math.Cos(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insINTOFF 'Rep'
										Inton(RNN) = False
									Case insVSTORE 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) >= 0 And RobotStack(RNN, RobotStackPos(RNN)) <= 100 Then
											RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN))) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
									Case insCHS 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN)) = -RobotStack(RNN, RobotStackPos(RNN)) '* -1
									Case insABS 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN)))
									Case insTAN '       BUG ALERT!! Hur är det med 90 + de nya optimeringarna?
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										TDouble = Fix(RobotStack(RNN, RobotStackPos(RNN)) * System.Math.Tan((90 - RobotStack(RNN, RobotStackPos(RNN) - 1)) * PIO))
										If System.Math.Abs(TDouble) > 19999 Then TDouble = 19999 * System.Math.Sign(TDouble)
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										RobotStack(RNN, RobotStackPos(RNN)) = TDouble
									Case insNOT_SAME 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insROLL 'Rep'
										If RobotStackPos(RNN) < RobotStack(RNN, RobotStackPos(RNN)) + 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										tempnumber = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Stores the number to roll back in tempstack
										For shotcounter = RobotStackPos(RNN) - 1 To RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) Step -1 'decides what stack numbers moving up
											RobotStack(RNN, shotcounter) = RobotStack(RNN, shotcounter - 1) 'adjust stack numbers affected by roll
										Next shotcounter
										RobotStack(RNN, RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) - 1) = tempnumber 'Do the roll
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1 'Adjusts stack number because top operand has been removed
									Case insMIN 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) < RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insNOP 'Rep'
									Case insDIST 'Rep'     'Totally useless, it can be precalculated!
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(System.Math.Sqrt(RobotStack(RNN, RobotStackPos(RNN)) ^ 2 + RobotStack(RNN, RobotStackPos(RNN) - 1) ^ 2))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insFLUSHINT 'Rep'
										RobotQuePos(RNN) = 0
									Case insXOR 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If (RobotStack(RNN, RobotStackPos(RNN)) <> 0) Xor (RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insARCSIN 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Asn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1))
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insARCCOS 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Acn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = -180 * CShort(System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) <> System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1)))
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insSQRT 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then
											ErrorCode = BuggySquare : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN)) = FixSquare(RobotStack(RNN, RobotStackPos(RNN)))
									Case insPRINT 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If Not RunningTournament Then
											tempnumber = MsgBox(RobotStack(RNN, RobotStackPos(RNN)) & vbCr & vbCr & "Would you like to stop the Battle?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Print " & GetRobot(RNN))
											If tempnumber = MsgBoxResult.Yes Then GoTo Peace
										End If
										ChrononExecutor1 = ChrononExecutor1 - 1
									Case Else
CodeError1: 
										ErrorCode = Err.Number
Buggy: 
										If RunningTournament Then
											tempnumber = MsgBoxResult.No
										ElseIf ErrorCode <= -200 Then 
											tempnumber = ShowErrorMessageParam(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), RobotStack(RNN, RobotStackPos(RNN)))
										Else
											tempnumber = ShowErrorMessage(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), MachineCode(RNN, RobotInstPos(RNN))) 'Response
										End If
										
										RobotAlive(RNN) = 255
										RScan(RNN) = 9999 'nytt
										If tempnumber = MsgBoxResult.Cancel Then GoTo Peace
										If tempnumber = MsgBoxResult.Yes Then
											SelectedRobot = RNN
											DraftingBoard.GotoInstNr = RobotInstPos(RNN) + 1
											VB6.ShowForm(DraftingBoard, 1, Me)
											EndBattleWhenGotoInst()
											Exit Sub
										End If
										If Err.Number = 0 Then Exit For Else Resume BackFromError
								End Select
							Next ChrononExecutor1
						End If 'Stunned if
					End If 'energyif
				End If 'RobotAlive(RNN) if
				
BackFromError: 
				If HighestToLowest Then RNN = 1 + NumberOfRobotsPresent - RNN 'Turns off backwards evaluation if it's enabled
			Next RNN 'Nästa robot loopen
			
			
			If RStunned(1) > 0 Then RStunned(1) = RStunned(1) - 1
			For RNN = 2 To NumberOfRobotsPresent
				If RStunned(RNN) > 0 Then RStunned(RNN) = RStunned(RNN) - 1
			Next RNN
			
			' Avläsningen av koden ALLMÄNT(SLUTET)
			
			'Shot Manager
			
			NotAnyShotsAtAll = True
			
			For shotcounter = 1 To ShotNumber
				'errorcode = "ShotCounter = " & ShotCounter & Chr(10) & "ShotNumber = " & ShotNumber & Chr(10) & Chr(10) & "FireTime = " & Shot(ShotCounter).ShotFireTime & Chr(10) & "X = " & Shot(ShotCounter).ShotX & Chr(10) & "Y = " & Shot(ShotCounter).ShotY & Chr(10) & "Damage = " & Shot(ShotCounter).ShotPower & Chr(10) & Chr(10) & "FreeShot = " & FreeShot
				'Response = MsgBox(errorcode, vbOKCancel, "Debug")
				'If Response = vbCancel Then GoTo Peace
				
				'Fillstyle är som standard = 0. Om det måste ändras måste den sättas tillbaka sen
				
				Select Case shot(shotcounter).ShotType
					Case 200
						FreeShot = shotcounter
						'Disables some redims. Might speed up?
						
					Case Missile
						NotAnyShotsAtAll = False
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + Sin5(shot(shotcounter).ShotAngle)
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - Cos5(shot(shotcounter).ShotAngle)
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then 'BUG ALERT!!! Skall syncas!!!
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 1 'Which robot is hit?
								LastHiter(1) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 2 'Which robot is hit?
								LastHiter(2) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 3 'Which robot is hit?
								LastHiter(3) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 4 'Which robot is hit?
								LastHiter(4) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 5 'Which robot is hit?
								LastHiter(5) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 6 'Which robot is hit?
								LastHiter(6) = shot(shotcounter).Shooter
							End If
						End If
						
					Case Hellbore
						NotAnyShotsAtAll = False
						trigx = shot(shotcounter).ShotPower * Sine(shot(shotcounter).ShotAngle)
						trigy = shot(shotcounter).ShotPower * Cosine(shot(shotcounter).ShotAngle)
						
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy
						
						trigx = shot(shotcounter).ShotX - trigx / 2
						trigy = shot(shotcounter).ShotY + trigy / 2
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then 'HELLBORE!!!
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or (trigx - RobotLeft(1)) * (trigx - RobotLeft(1)) + (trigy - RobotTop(1)) * (trigy - RobotTop(1)) < 100 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 1000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or (trigx - RobotLeft(2)) * (trigx - RobotLeft(2)) + (trigy - RobotTop(2)) * (trigy - RobotTop(2)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 2000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or (trigx - RobotLeft(3)) * (trigx - RobotLeft(3)) + (trigy - RobotTop(3)) * (trigy - RobotTop(3)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 3000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or (trigx - RobotLeft(4)) * (trigx - RobotLeft(4)) + (trigy - RobotTop(4)) * (trigy - RobotTop(4)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 4000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or (trigx - RobotLeft(5)) * (trigx - RobotLeft(5)) + (trigy - RobotTop(5)) * (trigy - RobotTop(5)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 5000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or (trigx - RobotLeft(6)) * (trigx - RobotLeft(6)) + (trigy - RobotTop(6)) * (trigy - RobotTop(6)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 6000 'Which robot is hit? *1000 for hellbore
							End If 'HELLBORE!!!
						End If
						
					Case Stunner
						NotAnyShotsAtAll = False
						trigx = Sin14(shot(shotcounter).ShotAngle)
						trigy = Cos14(shot(shotcounter).ShotAngle)
						
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy
						
						trigx = shot(shotcounter).ShotX - trigx
						trigy = trigy + shot(shotcounter).ShotY
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then 'STUNNER!!!
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 51 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 100 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 200 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 300 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 400 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 500 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 600 'Which robot is hit? *100 for stunners
							End If 'STUNNER!!!
						End If
						
					Case XplosiveBulletDetonation
ExplosiveBullets: 
						NotAnyShotsAtAll = False
						If Chronon - shot(shotcounter).ShotFireTime >= 4 Then '10
							shot(shotcounter).ShotType = NOSHOT
							
							For RNN = 1 To NumberOfRobotsPresent
								If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 2025 Then '45*45?????
									RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN)) : RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
									LastHiter(RNN) = shot(shotcounter).Shooter
								End If
							Next RNN
							
							If DroneShotDown Then
								For RNN = 1 To ShotNumber
									If shot(RNN).ShotType = Drone Then
										If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 2025 Then shot(RNN).ShotType = NOSHOT
									End If
								Next RNN
							End If
						End If
						
					Case TakeNuke
						'OldStyleExplosiveBullets:
						NotAnyShotsAtAll = False
						
						If Chronon - shot(shotcounter).ShotFireTime >= 10 Then '10
							shot(shotcounter).ShotType = NOSHOT
							
							For RNN = 1 To NumberOfRobotsPresent '1020
								If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
									RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN)) : RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
									LastHiter(RNN) = shot(shotcounter).Shooter
								End If
							Next RNN
							
							If DroneShotDown Then
								For RNN = 1 To ShotNumber
									If shot(RNN).ShotType = Drone Then
										If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then shot(RNN).ShotType = NOSHOT
									End If
								Next RNN
							End If
						End If
						
					Case MegaNuke
						'OldStyleExplosiveBullets:
						NotAnyShotsAtAll = False
						
						If Chronon - shot(shotcounter).ShotFireTime >= MegaNukeBLASTRADIUS Then '10
							shot(shotcounter).ShotType = NOSHOT
							
							For RNN = 1 To NumberOfRobotsPresent '1020
								If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
									RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower + RShield(RNN)) : RShield(RNN) = ZeroOrMore(RShield(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower)
									LastHiter(RNN) = shot(shotcounter).Shooter
								End If
							Next RNN
							
							If DroneShotDown Then
								For RNN = 1 To ShotNumber
									If shot(RNN).ShotType = Drone Then
										If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then shot(RNN).ShotType = NOSHOT
									End If
								Next RNN
							End If
						End If
						
					Case Mine 'Minor skall ge damage 1 chronon efter
						NotAnyShotsAtAll = False
						
						If Chronon - shot(shotcounter).ShotFireTime >= 10 Then
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 1 'Which robot is hit?
								LastHiter(1) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 2 'Which robot is hit?
								LastHiter(2) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 3 'Which robot is hit?
								LastHiter(3) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 4 'Which robot is hit?
								LastHiter(4) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 5 'Which robot is hit?
								LastHiter(5) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 6 'Which robot is hit?
								LastHiter(6) = shot(shotcounter).Shooter
							End If
						End If
						
					Case Drone
						NotAnyShotsAtAll = False
						
						If RobotAlive(shot(shotcounter).ShotAngle) = 1 And Chronon <= shot(shotcounter).ShotFireTime Then
							'Checks drone shotdown
							For tempnumber = 0 To ShotNumber 'This is still extremly buggy
								'If Shot(TempNumber).ShotType = Missile Or Shot(TempNumber).ShotType = Hellbore Or Shot(TempNumber).ShotType = Bullet Or Shot(TempNumber).ShotType = ExplosiveBullet Then
								If shot(tempnumber).ShotType < 4 Then
									If (shot(tempnumber).ShotX - shot(shotcounter).ShotX) * (shot(tempnumber).ShotX - shot(shotcounter).ShotX) + (shot(tempnumber).ShotY - shot(shotcounter).ShotY) * (shot(tempnumber).ShotY - shot(shotcounter).ShotY) < 50 Then
										shot(tempnumber).ShotType = NOSHOT
										shot(shotcounter).ShotType = NOSHOT
										'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
										GoTo dontrundronecode
									End If
								End If
							Next tempnumber
							''***************************'Nytt försök med drones     'Succé!! Yay!!
							'            'moves te drone towards the tracking robot moves and paints the drone
							'LÄGG TILL IIF, DET KANSKE GÅR SNABBARE
							If System.Math.Abs(shot(shotcounter).ShotY - RobotTop(shot(shotcounter).ShotAngle)) <= 8 Then '2 '8
								If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
									shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2
								Else
									shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2
								End If
							ElseIf System.Math.Abs(shot(shotcounter).ShotX - RobotLeft(shot(shotcounter).ShotAngle)) <= 8 Then  '2 '8
								If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then
									shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2
								Else
									shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2
								End If
							Else
								If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
									shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2 '1.41421356237 '2*cos 45 = 2*sin 45 = 1.41421356237
								Else
									shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2 '1.41421356237
								End If
								If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then
									shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2 '1.41421356237
								Else
									shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2 '1.41421356237
								End If
							End If
							''            end paint and move
							'Checks hit
							For tempnumber = 1 To NumberOfRobotsPresent 'Undre raden fungerar men är insparad pga 64 K
								If (shot(shotcounter).ShotX - RobotLeft(tempnumber)) * (shot(shotcounter).ShotX - RobotLeft(tempnumber)) + (shot(shotcounter).ShotY - RobotTop(tempnumber)) * (shot(shotcounter).ShotY - RobotTop(tempnumber)) < 100 Then
									shot(shotcounter).ShotType = SHOTHIT
									shot(shotcounter).ShotAngle = tempnumber 'Which robot is hit?
									'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
									LastHiter(tempnumber) = shot(shotcounter).Shooter
								End If
							Next tempnumber
						Else
							shot(shotcounter).ShotType = NOSHOT 'destroy drone
						End If
dontrundronecode: 
					Case Laser
						NotAnyShotsAtAll = False
						shot(shotcounter).ShotType = SHOTHIT
						LastHiter(shot(shotcounter).ShotAngle) = shot(shotcounter).Shooter
						
					Case SHOTHIT 'ShotHit
						If shot(shotcounter).ShotAngle < 100 Then 'Regular
							RShield(shot(shotcounter).ShotAngle) = RShield(shot(shotcounter).ShotAngle) - shot(shotcounter).ShotPower
							If RShield(shot(shotcounter).ShotAngle) < 0 Then 'If Shield still is above 0 the shot only hit the shield
								RDamage(shot(shotcounter).ShotAngle) = RDamage(shot(shotcounter).ShotAngle) + RShield(shot(shotcounter).ShotAngle)
								RShield(shot(shotcounter).ShotAngle) = 0
							End If
						ElseIf shot(shotcounter).ShotAngle < 1000 Then  'Stunner
							RStunned(shot(shotcounter).ShotAngle \ 100) = RStunned(shot(shotcounter).ShotAngle \ 100) + shot(shotcounter).ShotPower
						Else 'Hellbore
							RShield(shot(shotcounter).ShotAngle \ 1000) = 0
						End If
						shot(shotcounter).ShotType = NOSHOT
						
					Case Else
						NotAnyShotsAtAll = False
						trigx = Sin12(shot(shotcounter).ShotAngle)
						trigy = Cos12(shot(shotcounter).ShotAngle)
						
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy
						
						trigy = trigy + shot(shotcounter).ShotY
						trigx = shot(shotcounter).ShotX - trigx
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									'                    Shot(ShotCounter).ShotType = TakeNuke      'Old fashion Explosive Bullets
									'                    GoTo OldStyleExplosiveBullets                      'Do not erase
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 1 'Which robot is hit?
								LastHiter(1) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then 
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 2 'Which robot is hit?
								LastHiter(2) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then 
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 3 'Which robot is hit?
								LastHiter(3) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then 
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 4 'Which robot is hit?
								LastHiter(4) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then 
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 5 'Which robot is hit?
								LastHiter(5) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then 
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 6 'Which robot is hit?
								LastHiter(6) = shot(shotcounter).Shooter
							End If
						End If
				End Select
				
			Next shotcounter
			
			If NotAnyShotsAtAll Then
				ShotNumber = 0
				FreeShot = -1
			End If
			
			
			If RobotAlive(1) = 1 Then
				If RDamage(1) <= 0 Then 'Checks if the robots have any damage left.
RunDeath1: 
					RobotAlive(1) = 0 'If the robot just died we set RobotAlive to 255 (means it died this chronon).
					RobotLeft(1) = -50
					RobotTop(1) = 150
					EnergyDisplay(1).Visible = False
					
					If REnergy(1) < -200 And EnableOverloading Then 'BUG ALERT!! BUG ALERT!! Skillnad i overloading mot den jävla Mac versionen: dels så sker skälva "döden" 1 chronon senare i
						RobotDead(1).Text = "Overloaded - Time: " & Chronon
						tempnumber = -2 '3 * CInt(Not StandardScoring)
						LastHiter(1) = 253
					ElseIf RScan(1) = 9999 Then 
						RobotDead(1).Text = "Buggy - Time: " & Chronon
						tempnumber = -1 '2 * CInt(Not StandardScoring)
						LastHiter(1) = 254
					Else
						RobotDead(1).Text = "Dead - Time: " & Chronon 'Windows (vet inte om det har nån betydelse?), dels så slutar striden inte mindre än 2 chronon senare senare i Windows (om Mac scoring används)
						If (RCollision(1) = 0 Or RDamage(1) + 1 <= 0) And (RWall(1) = 0 Or RDamage(1) + 5 <= 0) And LastHiter(1) <> 1 And RLook(LastHiter(1)) <> 9999 And (RobotTeam(1) = 0 Or (RobotTeam(1) <> RobotTeam(LastHiter(1)))) Then
							KR(LastHiter(1)) = KR(LastHiter(1)) + 1 'Also prevents robots from getting kill score for killing itself
						Else
							LastHiter(1) = 255 'Records that the robot died from a Wall Collision, Collision or suicided (for 4.5.2)
						End If
						tempnumber = 0 'CInt(Not StandardScoring)
					End If
					
					If Not RunningTournament Then
						RobotDead(1).Visible = True
						'DoEvents               'For the Nextevents optimization
					End If
					
					HowManyLeft = HowManyLeft - 1
					
					'Robots Int
					For shotcounter = 1 To NumberOfRobotsPresent
						If RobotsInst(shotcounter) >= 0 And HowManyLeft < RobotsParam(shotcounter) Then
							RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
							RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = RobotsInst(shotcounter)
							IntID(shotcounter, RobotQuePos(shotcounter)) = 9
						End If
					Next shotcounter
					
					'Teammates Int
					RRadar = 0 'Calculates how many teammates there is left
					For shotcounter = 1 To NumberOfRobotsPresent 'If a robot is in the same team that the robot who just died + it's alive it's a living teammate
						If RobotTeam(shotcounter) = RobotTeam(1) And RobotAlive(shotcounter) = 1 Then RRadar = RRadar + 1
					Next shotcounter
					
					For shotcounter = 1 To NumberOfRobotsPresent
						If RobotTeam(shotcounter) = RobotTeam(1) Then 'If they're not in the same team we can ignore the teammates int
							If TeammatesInst(shotcounter) >= 0 Then 'If it uses the teammates inst
								If RRadar < TeammatesParam(shotcounter) Then 'If the teammates in the team no is below teammatesparam
									RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
									RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = TeammatesInst(shotcounter)
									IntID(shotcounter, RobotQuePos(shotcounter)) = 10
								End If
							End If
						End If
					Next shotcounter
					
					If RRadar = 0 Then HowManyLeft = 0
					
					'End Team Stuff
					
					If HowManyLeft <= 1 Then 'If there's one or less than one robot left the battle should be stopped
						MaxChronon = Chronon + 20 + tempnumber * CShort(Not StandardScoring)
						HowManyLeft = 255 'If the solitare robot should die we prevent the battle from going on an additional 20 chronons this way
					End If
					
					REnergy(1) = -10 'To prevent false dopplering
				End If
			ElseIf RobotAlive(1) = 255 Then 
				GoTo RunDeath1
			End If
			
			RCollision(1) = 0 'Resets collision to zero before the collision loop
			
			'*DEATH. This is the loop that checks for Robots death, and handles kill scoring.
			For RNN = 2 To NumberOfRobotsPresent 'To increase battle speed, it's a lot different than the one displayed battle is using.
				If RobotAlive(RNN) = 1 Then
					If RDamage(RNN) <= 0 Then 'Checks if the robots have any damage left.
RunDeath: 
						RobotAlive(RNN) = 0 'If the robot just died we set RobotAlive to 255 (means it died this chronon).
						RobotLeft(RNN) = -50
						RobotTop(RNN) = 150
						EnergyDisplay(RNN).Visible = False
						
						If REnergy(RNN) < -200 And EnableOverloading Then 'BUG ALERT!! BUG ALERT!! Skillnad i overloading mot den jävla Mac versionen: dels så sker skälva "döden" 1 chronon senare i
							RobotDead(RNN).Text = "Overloaded - Time: " & Chronon
							tempnumber = -2 '3 * CInt(Not StandardScoring)
							LastHiter(RNN) = 253
						ElseIf RScan(RNN) = 9999 Then 
							RobotDead(RNN).Text = "Buggy - Time: " & Chronon
							tempnumber = -1 '2 * CInt(Not StandardScoring)
							LastHiter(RNN) = 254
						Else
							RobotDead(RNN).Text = "Dead - Time: " & Chronon 'Windows (vet inte om det har nån betydelse?), dels så slutar striden inte mindre än 2 chronon senare senare i Windows (om Mac scoring används)
							If (RCollision(RNN) = 0 Or RDamage(RNN) + 1 <= 0) And (RWall(RNN) = 0 Or RDamage(RNN) + 5 <= 0) And LastHiter(RNN) <> RNN And RLook(LastHiter(RNN)) <> 9999 And (RobotTeam(RNN) = 0 Or (RobotTeam(RNN) <> RobotTeam(LastHiter(RNN)))) Then
								KR(LastHiter(RNN)) = KR(LastHiter(RNN)) + 1 'Also prevents robots from getting kill score for killing itself
							Else
								LastHiter(RNN) = 255 'Records that the robot died from a Wall Collision, Collision or suicided (for 4.5.2)
							End If
							tempnumber = 0 'CInt(Not StandardScoring)
						End If
						
						If Not RunningTournament Then
							RobotDead(RNN).Visible = True
							'DoEvents       'For the Nextevents optimization
						End If
						
						HowManyLeft = HowManyLeft - 1
						
						'Robots Int
						For shotcounter = 1 To NumberOfRobotsPresent
							If RobotsInst(shotcounter) >= 0 And HowManyLeft < RobotsParam(shotcounter) Then
								RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
								RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = RobotsInst(shotcounter)
								IntID(shotcounter, RobotQuePos(shotcounter)) = 9
							End If
						Next shotcounter
						
						'Teammates Int
						RRadar = 0 'Calculates how many teammates there is left
						For shotcounter = 1 To NumberOfRobotsPresent 'If a robot is in the same team that the robot who just died + it's alive it's a living teammate
							If RobotTeam(shotcounter) = RobotTeam(RNN) And RobotAlive(shotcounter) = 1 Then RRadar = RRadar + 1
						Next shotcounter
						
						For shotcounter = 1 To NumberOfRobotsPresent
							If RobotTeam(shotcounter) = RobotTeam(RNN) Then 'If they're not in the same team we can ignore the teammates int
								If TeammatesInst(shotcounter) >= 0 Then 'If it uses the teammates inst
									If RRadar < TeammatesParam(shotcounter) Then 'If the teammates in the team no is below teammatesparam
										RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
										RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = TeammatesInst(shotcounter)
										IntID(shotcounter, RobotQuePos(shotcounter)) = 10
									End If
								End If
							End If
						Next shotcounter
						
						If RRadar = 0 Then HowManyLeft = 0
						
						'End Team Stuff
						
						If HowManyLeft <= 1 Then 'If there's one or less than one robot left the battle should be stopped
							MaxChronon = Chronon + 20 + tempnumber * CShort(Not StandardScoring)
							HowManyLeft = 255 'If the solitare robot should die we prevent the battle from going on an additional 20 chronons this way
						End If
						
						REnergy(RNN) = -10 'To prevent false dopplering
					End If
				ElseIf RobotAlive(RNN) = 255 Then 
					GoTo RunDeath
				End If
				
				RCollision(RNN) = 0 'Resets collision to zero before the collision loop
			Next RNN
			
			'    If Chronon = NextEvents Then                           'For the Nextevents optimization
			'        NextEvents = NextEvents + 167                      'Just remove comments to enable
			''**************************doevent2**************************
			If PeekMessage(Message, 0, 0, 0, PM_NOREMOVE) Then 'checks for a message in the queue
				System.Windows.Forms.Application.DoEvents() 'dispatches any messages in the queue
			End If
			''************************************************************
			'    End If
			Chronon = Chronon + 1
		Loop 
		
		StartTime = VB.Timer() - StartTime
		If StartTime >= 1 Then 'We must have av least 1 sec of measuring otherwise the
			StartTime = Chronon / StartTime 'measuring will be very inaccurate
			CPRLabel.Text = VB6.Format(StartTime, "#")
		End If
		'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*
		' Striden avslutas
Peace: 
		For RNN = 1 To NumberOfRobotsPresent 'Just so ER should correspond to energydisplay
			If Not Replaying Then
				BackupHistory((RNN))
				HistoryRec(RNN, 9) = RDamage(RNN) * CShort(RobotAlive(RNN) = 1)
			End If
		Next RNN
		
		KillPoints(LastHiter, RobotAlive)
		RewardPoints(RobotAlive(1), RobotAlive(2), RobotAlive(3), RobotAlive(4), RobotAlive(5), RobotAlive(6))
		EndBattle()
	End Sub
	
	
	Private Sub ULTRAMODE()
		'This is yet another clone of the undisplayed battle engine, with the ultra mode enabled
		'Changes should be in the No-Display battle engine, then clone it to ultra
		
		'Debugging variables
		Dim ErrorCode As Integer
		Dim RandomCounter As Integer
		
		'Robotarnas maskinkod - The robots' machinecode
		'UPGRADE_WARNING: Lower bound of array MachineCode was changed from 1,0 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim MachineCode(6, 4999) As Integer '0-4999 = RobotInstructions
		'UPGRADE_WARNING: Lower bound of array RobotInstPos was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotInstPos(6) As Integer
		
		'Robotarnas Stack - The robots' Stacks
		'UPGRADE_WARNING: Lower bound of array RobotStack was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotStack(6, 100) As Integer 'long
		'UPGRADE_WARNING: Lower bound of array RobotStackPos was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotStackPos(6) As Integer 'How many numbers the robots has on it's stack
		
		'Robotarnas Interupptsköer - The robots' interupps ques
		'UPGRADE_WARNING: Lower bound of array RobotIntQue was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotIntQue(6, 100) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotQuePos was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotQuePos(6) As Integer
		'UPGRADE_WARNING: Lower bound of array IntID was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim IntID(6, 100) As Integer
		
		'Robots hardware
		'UPGRADE_WARNING: Lower bound of array RobotShield was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotShield(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotEnergy was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotEnergy(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotProSpeed was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotProSpeed(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotMissiles was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotMissiles(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotTacNukes was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotTacNukes(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotBullets was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotBullets(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotStunners was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotStunners(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotHellbores was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotHellbores(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotMines was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotMines(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotLasers was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotLasers(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotDrones was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotDrones(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotProbes was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotProbes(6) As Integer
		
		'Robotarnas variabler - The robots' variables
		'UPGRADE_WARNING: Lower bound of array RA was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RA(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RB was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RB(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RC was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RC(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RD was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RD(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RE was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RE(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RF was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RF(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RG was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RG(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RH was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RH(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RI was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RI(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RJ was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RJ(6) As Integer 'Used to be ints, but it seems like people using them
		'UPGRADE_WARNING: Lower bound of array RK was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RK(6) As Integer 'to store placerecalls
		'UPGRADE_WARNING: Lower bound of array RL was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RL(6) As Integer 'For example "radar' a' store" won't work with longs
		'UPGRADE_WARNING: Lower bound of array RM was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RM(6) As Integer 'long is slower, but robots simply doesn't work otherwise.
		'UPGRADE_WARNING: Lower bound of array RN was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RN(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RO was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RO(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RP was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RP(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RQ was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RQ(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RR was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RR(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RS was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RS(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RT was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RT(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RU was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RU(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RV was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RV(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RZ was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RZ(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RW was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RW(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RVRECALL was changed from 1,0 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RVRECALL(6, 100) As Integer
		
		'Probes and Interupps
		'UPGRADE_WARNING: Lower bound of array ProbeSet was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ProbeSet(6) As Integer '0 = Damage 1 = Energy 2 = Shield 3 = ID '5 = Aim 6 = look 7 = scan 4 = Teammates - Currently disabled 'cause of no teams
		
		'UPGRADE_WARNING: Lower bound of array Inton was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim Inton(6) As Boolean
		'UPGRADE_WARNING: Lower bound of array RangeInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RangeInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RangeParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RangeParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RadarInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RadarInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RadarParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RadarParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array ChrononInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ChrononInst(6) As Integer 'Måste alltid dras ifrån en då denna sätts för att mataren matar fram + 1
		'UPGRADE_WARNING: Lower bound of array ChrononParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ChrononParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotsInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotsInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RobotsParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotsParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RightParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RightParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array LeftParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim LeftParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TopParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TopParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array BotParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim BotParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RightInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RightInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array LeftInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim LeftInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TopInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TopInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array BotInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim BotInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array CollisionInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim CollisionInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array WallInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim WallInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array DamageInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim DamageInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array DamageParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim DamageParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array ShieldInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ShieldInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array ShieldParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim ShieldParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array HistoryParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim HistoryParam(6) As Integer
		
		' Team Variables
		'UPGRADE_WARNING: Lower bound of array RSignal was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RSignal(3, 10) As Integer
		'UPGRADE_WARNING: Lower bound of array RChannel was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RChannel(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TeammatesInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TeammatesInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array TeammatesParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim TeammatesParam(6) As Integer
		'UPGRADE_WARNING: Lower bound of array SignalInst was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim SignalInst(6) As Integer
		'UPGRADE_WARNING: Lower bound of array SignalParam was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim SignalParam(6) As Integer
		
		'Things that can be recalled
		'UPGRADE_WARNING: Lower bound of array RCollision was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RCollision(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RWall was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RWall(6) As Integer
		'UPGRADE_WARNING: Lower bound of array REnergy was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim REnergy(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RDamage was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RDamage(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RShield was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RShield(6) As Integer 'Byte
		'UPGRADE_WARNING: Lower bound of array RSpeedx was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RSpeedx(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RSpeedy was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RSpeedy(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RAim was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RAim(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RLook was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RLook(6) As Integer
		'UPGRADE_WARNING: Lower bound of array RScan was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RScan(6) As Integer
		Dim RRadar As Integer 'Kanske kan byggas ihop? Bytas ut?
		Dim RRange As Integer
		
		'Robot Specific Game Vars
		'UPGRADE_WARNING: Lower bound of array RobotAlive was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RobotAlive(6) As Integer 'Boolean
		'UPGRADE_WARNING: Lower bound of array RStunned was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim RStunned(6) As Integer 'The number of chronons the robot is stunned
		'Hasmoved skall ha 2 funktioner. Dels MoveAndShot, dels så att LEFT' RIGHT' TOP' BOT'
		'skall kunna triggas med movex
		'UPGRADE_WARNING: Lower bound of array LastHiter was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim LastHiter(6) As Integer
		Dim HasMoved As Integer
		Dim DroneShotDown As Boolean 'This var decides wether we have to check through every shot when a x-bullet or a tacnuke explode.
		'If there's robots using drones, we have to. If there's no robots using drones, we can skip this a benifit speed.
		
		'Vars neccesary for running the game
		Dim NextEvents As Integer 'For the Nextevents optimization
		Dim RNN As Integer 'Stands for Robot ruNniNg or something like that (I don't remember exactly what to be honest). Correspond aproximately to the variable "who" in Mac RoboWar
		Dim ChrononExecutor1 As Integer 'Correspons to "cycleNum"
		Dim HowManyLeft As Integer 'Used to determine when to cancel battle. Set to 2 if only one robot is present, to avoid that battle breaks at Chronon 20
		Dim tempnumber As Integer 'temporary placeholder for longs
		Dim TDouble As Double 'To avoid trig calculations to get truncated
		
		'Shot vars
		Dim FreeShot As Integer
		FreeShot = -1
		Dim shotcounter As Integer 'Kan användas i debuggern istället för RRadar?
		Dim NotAnyShotsAtAll As Boolean
		Dim shot(32768) As ShotPrivateType
		Dim ShotNumber As Integer
		
		Dim trigx As Single
		Dim trigy As Single
		
		InizBattle()
		'Battle Starts. The robots get randomly placed in the Arena
		
		'Robot 1. Allways Present
		REnergy(1) = Robot1Energy
		RDamage(1) = Robot1Damage
		
		'Laddar machinkoden till Robotarna
		For RNN = 0 To 4999
			MachineCode(1, RNN) = MasterCode(1, RNN)
			If (MachineCode(1, RNN) >= insICON0 And MachineCode(1, RNN) <= insICON9) Or (MachineCode(1, RNN) >= insDEBUG And MachineCode(1, RNN) <= insSND9) Then MachineCode(1, RNN) = insBEEP
			If MachineCode(1, RNN) = insEND Then Exit For
		Next RNN
		
		If R2Present Then
			For RNN = 0 To 4999
				MachineCode(2, RNN) = MasterCode(2, RNN)
				If (MachineCode(2, RNN) >= insICON0 And MachineCode(2, RNN) <= insICON9) Or (MachineCode(2, RNN) >= insDEBUG And MachineCode(2, RNN) <= insSND9) Then MachineCode(2, RNN) = insBEEP
				If MachineCode(2, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace2() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(2) = Robot2Energy
			RDamage(2) = Robot2Damage
		End If
		
		If R3Present Then
			For RNN = 0 To 4999
				MachineCode(3, RNN) = MasterCode(3, RNN)
				If (MachineCode(3, RNN) >= insICON0 And MachineCode(3, RNN) <= insICON9) Or (MachineCode(3, RNN) >= insDEBUG And MachineCode(3, RNN) <= insSND9) Then MachineCode(3, RNN) = insBEEP
				If MachineCode(3, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace3()
			REnergy(3) = Robot3Energy
			RDamage(3) = Robot3Damage
		End If
		
		If R4Present Then
			For RNN = 0 To 4999
				MachineCode(4, RNN) = MasterCode(4, RNN)
				If (MachineCode(4, RNN) >= insICON0 And MachineCode(4, RNN) <= insICON9) Or (MachineCode(4, RNN) >= insDEBUG And MachineCode(4, RNN) <= insSND9) Then MachineCode(4, RNN) = insBEEP
				If MachineCode(4, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace4() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(4) = Robot4Energy
			RDamage(4) = Robot4Damage
		End If
		
		If R5Present Then
			For RNN = 0 To 4999
				MachineCode(5, RNN) = MasterCode(5, RNN)
				If (MachineCode(5, RNN) >= insICON0 And MachineCode(5, RNN) <= insICON9) Or (MachineCode(5, RNN) >= insDEBUG And MachineCode(5, RNN) <= insSND9) Then MachineCode(5, RNN) = insBEEP
				If MachineCode(5, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace5() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(5) = Robot5Energy
			RDamage(5) = Robot5Damage
		End If
		
		If R6Present Then
			For RNN = 0 To 4999
				MachineCode(6, RNN) = MasterCode(6, RNN)
				If (MachineCode(6, RNN) >= insICON0 And MachineCode(6, RNN) <= insICON9) Or (MachineCode(6, RNN) >= insDEBUG And MachineCode(6, RNN) <= insSND9) Then MachineCode(6, RNN) = insBEEP
				If MachineCode(6, RNN) = insEND Then Exit For
			Next RNN
			
			MasterPlace6() 'This sub places the robot and checks that it wasn't placed too near another robot
			REnergy(6) = Robot6Energy
			RDamage(6) = Robot6Damage
		End If
		
		HowManyLeft = CheckHowManyLeft
		
		'Syncs Hardware to array
		RobotShield(1) = Robot1Shield
		RobotEnergy(1) = Robot1Energy
		RobotProSpeed(1) = Robot1ProSpeed
		RobotMissiles(1) = Robot1Missiles
		RobotTacNukes(1) = Robot1TacNukes
		RobotBullets(1) = Robot1Bullets
		RobotStunners(1) = Robot1Stunners
		RobotHellbores(1) = Robot1Hellbores
		RobotMines(1) = Robot1Mines
		RobotLasers(1) = Robot1Lasers
		RobotDrones(1) = Robot1Drones
		RobotProbes(1) = Robot1Probes
		RobotShield(2) = Robot2Shield
		RobotEnergy(2) = Robot2Energy
		RobotProSpeed(2) = Robot2ProSpeed
		RobotMissiles(2) = Robot2Missiles
		RobotTacNukes(2) = Robot2TacNukes
		RobotBullets(2) = Robot2Bullets
		RobotStunners(2) = Robot2Stunners
		RobotHellbores(2) = Robot2Hellbores
		RobotMines(2) = Robot2Mines
		RobotLasers(2) = Robot2Lasers
		RobotDrones(2) = Robot2Drones
		RobotProbes(2) = Robot2Probes
		RobotShield(3) = Robot3Shield
		RobotEnergy(3) = Robot3Energy
		RobotProSpeed(3) = Robot3ProSpeed
		RobotMissiles(3) = Robot3Missiles
		RobotTacNukes(3) = Robot3TacNukes
		RobotBullets(3) = Robot3Bullets
		RobotStunners(3) = Robot3Stunners
		RobotHellbores(3) = Robot3Hellbores
		RobotMines(3) = Robot3Mines
		RobotLasers(3) = Robot3Lasers
		RobotDrones(3) = Robot3Drones
		RobotProbes(3) = Robot3Probes
		RobotShield(4) = Robot4Shield
		RobotEnergy(4) = Robot4Energy
		RobotProSpeed(4) = Robot4ProSpeed
		RobotMissiles(4) = Robot4Missiles
		RobotTacNukes(4) = Robot4TacNukes
		RobotBullets(4) = Robot4Bullets
		RobotStunners(4) = Robot4Stunners
		RobotHellbores(4) = Robot4Hellbores
		RobotMines(4) = Robot4Mines
		RobotLasers(4) = Robot4Lasers
		RobotDrones(4) = Robot4Drones
		RobotProbes(4) = Robot4Probes
		RobotShield(5) = Robot5Shield
		RobotEnergy(5) = Robot5Energy
		RobotProSpeed(5) = Robot5ProSpeed
		RobotMissiles(5) = Robot5Missiles
		RobotTacNukes(5) = Robot5TacNukes
		RobotBullets(5) = Robot5Bullets
		RobotStunners(5) = Robot5Stunners
		RobotHellbores(5) = Robot5Hellbores
		RobotMines(5) = Robot5Mines
		RobotLasers(5) = Robot5Lasers
		RobotDrones(5) = Robot5Drones
		RobotProbes(5) = Robot5Probes
		RobotShield(6) = Robot6Shield
		RobotEnergy(6) = Robot6Energy
		RobotProSpeed(6) = Robot6ProSpeed
		RobotMissiles(6) = Robot6Missiles
		RobotTacNukes(6) = Robot6TacNukes
		RobotBullets(6) = Robot6Bullets
		RobotStunners(6) = Robot6Stunners
		RobotHellbores(6) = Robot6Hellbores
		RobotMines(6) = Robot6Mines
		RobotLasers(6) = Robot6Lasers
		RobotDrones(6) = Robot6Drones
		RobotProbes(6) = Robot6Probes
		'End Syncs Hardware to array
		
		For tempnumber = 1 To NumberOfRobotsPresent
			RobotInstPos(tempnumber) = -1 'Sets robot RobotInstPos to -1 'cause t have to start with 0 (= -1 + 1 )
			RAim(tempnumber) = 90
			RobotAlive(tempnumber) = 1
			LastHiter(tempnumber) = tempnumber
			
			RChannel(tempnumber) = 1
			TeammatesInst(tempnumber) = -1
			TeammatesParam(tempnumber) = 5
			SignalInst(tempnumber) = -1
			
			RadarInst(tempnumber) = -1
			RangeInst(tempnumber) = -1
			ChrononInst(tempnumber) = -1
			CollisionInst(tempnumber) = -1
			WallInst(tempnumber) = -1
			TopInst(tempnumber) = -1
			BotInst(tempnumber) = -1
			LeftInst(tempnumber) = -1
			RightInst(tempnumber) = -1
			RobotsInst(tempnumber) = -1
			DamageInst(tempnumber) = -1
			ShieldInst(tempnumber) = -1
			RobotsParam(tempnumber) = 6
			RadarParam(tempnumber) = 600
			RangeParam(tempnumber) = 600
			TopParam(tempnumber) = 20
			BotParam(tempnumber) = 280
			LeftParam(tempnumber) = 20
			RightParam(tempnumber) = 280
			DamageParam(tempnumber) = RDamage(tempnumber)
			ShieldParam(tempnumber) = 25
			SignalParam(tempnumber) = 1
			
			HistoryParam(tempnumber) = 1
			
			If RobotDrones(tempnumber) = 1 Then DroneShotDown = True
		Next tempnumber
		
		' Avläsningen av koden (BÖRJAN)
		'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*
		
		On Error GoTo CodeError1
		
		Dim StartTime As Single
		StartTime = VB.Timer()
		
		Do While Chronon <> MaxChronon '<>
			If RobotAlive(1) = 1 Then
				If RStunned(1) = 0 Then
					If RShield(1) > 0 Then
						If RobotShield(1) < RShield(1) Then
							RShield(1) = RShield(1) - 2
							If RShield(1) < 0 Then RShield(1) = 0 'Behövs
						Else
							If Chronon Mod 2 = 0 Then RShield(1) = RShield(1) - 1
						End If
					End If
					
					If REnergy(1) <> RobotEnergy(1) Then
						If REnergy(1) >= -200 Then
							REnergy(1) = REnergy(1) + 2
							If REnergy(1) > RobotEnergy(1) Then REnergy(1) = RobotEnergy(1)
						Else
							If EnableOverloading Then RobotAlive(1) = 255 Else REnergy(1) = REnergy(1) + 2
						End If
					End If
					
					If REnergy(1) >= 1 Then
						If RSpeedx(1) <> 0 Or RSpeedy(1) <> 0 Then 'Boosts battlespeed and reduces flickering for robots that stads still.
							RobotLeft(1) = RobotLeft(1) + RSpeedx(1)
							RobotTop(1) = RobotTop(1) + RSpeedy(1)
						End If
					End If
				End If 'RStunned
				
				'''Kollision med varandra, Skall Nu vara nästintill perfekt
				For tempnumber = 2 To NumberOfRobotsPresent
					If RobotAlive(tempnumber) = 1 Then
						If (RobotLeft(1) - RobotLeft(tempnumber)) * (RobotLeft(1) - RobotLeft(tempnumber)) + (RobotTop(1) - RobotTop(tempnumber)) * (RobotTop(1) - RobotTop(tempnumber)) <= 400 Then
							If RCollision(1) = 0 Then
								RCollision(1) = tempnumber '' Var 1 förut nu registrerar den vilken robot den kolliderar med
								If RShield(1) > 0 Then RShield(1) = RShield(1) - 1 Else RDamage(1) = RDamage(1) - 1 'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
								
								If RStunned(1) = 0 And REnergy(1) >= 1 Then
									RobotLeft(1) = RobotLeft(1) - RSpeedx(1)
									RobotTop(1) = RobotTop(1) - RSpeedy(1)
								End If
							End If
							
							If RCollision(tempnumber) = 0 Then
								RCollision(tempnumber) = 1
								If RShield(tempnumber) > 0 Then RShield(tempnumber) = RShield(tempnumber) - 1 Else RDamage(tempnumber) = RDamage(tempnumber) - 1 'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
								
								'If RStunned(TempNumber) = 0 And REnergy(TempNumber) >= 1 Then
								If RStunned(tempnumber) = 0 And REnergy(tempnumber) - 2 * CShort(tempnumber > 1) >= 1 Then
									RobotLeft(tempnumber) = RobotLeft(tempnumber) - RSpeedx(tempnumber)
									RobotTop(tempnumber) = RobotTop(tempnumber) - RSpeedy(tempnumber)
								End If
							End If
						End If
					End If
				Next tempnumber
				
				'KOLLISION MED VÄGGARNA - WALL COLLISION
				If WCX(RobotLeft(1)) Or WCY(RobotTop(1)) Then
					RWall(1) = 1
					RDamage(1) = Min(RDamage(1), RDamage(1) - 5 + RShield(1))
					RShield(1) = ZeroOrMore(RShield(1) - 5)
					
					If RobotLeft(1) > 300 Then 'otherwise it can use SPEEDX to run outside the areana!!!
						RobotLeft(1) = 300 'den har inte flyttats någonstans, vi har istället lagt till på movex
					ElseIf RobotLeft(1) < 0 Then 
						RobotLeft(1) = 0
					End If
					If RobotTop(1) > 300 Then
						RobotTop(1) = 300
					ElseIf RobotTop(1) < 0 Then 
						RobotTop(1) = 0
					End If
				Else
					RWall(1) = 0
				End If
			End If 'Alive if
			
			'ROBOT LOADING LOOP - The New Collision Stunning Shield Energy Wall Loop
			For RNN = 2 To NumberOfRobotsPresent
				If RobotAlive(RNN) = 1 Then
					If RStunned(RNN) = 0 Then
						If RShield(RNN) > 0 Then
							If RobotShield(RNN) < RShield(RNN) Then
								RShield(RNN) = RShield(RNN) - 2
								If RShield(RNN) < 0 Then RShield(RNN) = 0 'Behövs
							Else
								If Chronon Mod 2 = 0 Then RShield(RNN) = RShield(RNN) - 1
							End If
						End If
						
						If REnergy(RNN) <> RobotEnergy(RNN) Then
							If REnergy(RNN) >= -200 Then
								REnergy(RNN) = REnergy(RNN) + 2
								If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN)
							Else
								If EnableOverloading Then RobotAlive(RNN) = 255 Else REnergy(RNN) = REnergy(RNN) + 2
							End If
						End If
						
						If REnergy(RNN) >= 1 Then
							If RSpeedx(RNN) <> 0 Or RSpeedy(RNN) <> 0 Then 'Boosts battlespeed and reduces flickering for robots that stads still.
								RobotLeft(RNN) = RobotLeft(RNN) + RSpeedx(RNN)
								RobotTop(RNN) = RobotTop(RNN) + RSpeedy(RNN)
							End If
						End If
					End If 'RStunned
					
					'''Kollision med varandra, Skall Nu vara nästintill perfekt
					For tempnumber = 1 To NumberOfRobotsPresent
						If RNN <> tempnumber Then
							If RobotAlive(tempnumber) = 1 Then
								If (RobotLeft(RNN) - RobotLeft(tempnumber)) * (RobotLeft(RNN) - RobotLeft(tempnumber)) + (RobotTop(RNN) - RobotTop(tempnumber)) * (RobotTop(RNN) - RobotTop(tempnumber)) <= 400 Then
									If RCollision(RNN) = 0 Then
										RCollision(RNN) = tempnumber '' Var 1 förut nu registrerar den vilken robot den kolliderar med
										If RShield(RNN) > 0 Then RShield(RNN) = RShield(RNN) - 1 Else RDamage(RNN) = RDamage(RNN) - 1 'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
										
										If RStunned(RNN) = 0 And REnergy(RNN) >= 1 Then
											RobotLeft(RNN) = RobotLeft(RNN) - RSpeedx(RNN)
											RobotTop(RNN) = RobotTop(RNN) - RSpeedy(RNN)
										End If
									End If
									
									If RCollision(tempnumber) = 0 Then
										RCollision(tempnumber) = RNN
										If RShield(tempnumber) > 0 Then RShield(tempnumber) = RShield(tempnumber) - 1 Else RDamage(tempnumber) = RDamage(tempnumber) - 1 'This works for damage = damage - 1 but in Wallcoll I have to use the shot formula
										
										'If RStunned(TempNumber) = 0 And REnergy(TempNumber) >= 1 Then
										If RStunned(tempnumber) = 0 And REnergy(tempnumber) - 2 * CShort(tempnumber > RNN) >= 1 Then
											RobotLeft(tempnumber) = RobotLeft(tempnumber) - RSpeedx(tempnumber)
											RobotTop(tempnumber) = RobotTop(tempnumber) - RSpeedy(tempnumber)
										End If
									End If
								End If
							End If
						End If
					Next tempnumber
					
					'KOLLISION MED VÄGGARNA - WALL COLLISION
					If WCX(RobotLeft(RNN)) Or WCY(RobotTop(RNN)) Then
						RWall(RNN) = 1
						RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - 5 + RShield(RNN))
						RShield(RNN) = ZeroOrMore(RShield(RNN) - 5)
						
						If RobotLeft(RNN) > 300 Then 'otherwise it can use SPEEDX to run outside the areana!!!
							RobotLeft(RNN) = 300 'den har inte flyttats någonstans, vi har istället lagt till på movex
						ElseIf RobotLeft(RNN) < 0 Then 
							RobotLeft(RNN) = 0
						End If
						If RobotTop(RNN) > 300 Then
							RobotTop(RNN) = 300
						ElseIf RobotTop(RNN) < 0 Then 
							RobotTop(RNN) = 0
						End If
					Else
						RWall(RNN) = 0
					End If
				End If 'Alive if
			Next RNN
			
			'ROBOT 1 CHRONON EXECUTOR
			For RNN = 1 To NumberOfRobotsPresent
				If HighestToLowest Then RNN = NumberOfRobotsPresent - RNN + 1 'Turns on backwards evaluation if it's enabled
				
				If RobotAlive(RNN) = 1 Then
					If REnergy(RNN) >= 1 Then
						If RStunned(RNN) = 0 Then
							
							If TopInst(RNN) >= 0 Then
								If RSpeedy(RNN) < 0 Then
									If RobotTop(RNN) <= TopParam(RNN) Then
										If RobotTop(RNN) - RSpeedy(RNN) > TopParam(RNN) Then
											RobotQuePos(RNN) = RobotQuePos(RNN) + 1
											RobotIntQue(RNN, RobotQuePos(RNN)) = TopInst(RNN)
											IntID(RNN, RobotQuePos(RNN)) = 1
										End If
									End If
								End If
							End If
							If BotInst(RNN) >= 0 Then
								If RSpeedy(RNN) > 0 Then
									If RobotTop(RNN) >= BotParam(RNN) Then
										If RobotTop(RNN) - RSpeedy(RNN) < BotParam(RNN) Then
											RobotQuePos(RNN) = RobotQuePos(RNN) + 1
											RobotIntQue(RNN, RobotQuePos(RNN)) = BotInst(RNN)
											IntID(RNN, RobotQuePos(RNN)) = 2
										End If
									End If
								End If
							End If
							If LeftInst(RNN) >= 0 Then
								If RSpeedx(RNN) < 0 Then
									If RobotLeft(RNN) <= LeftParam(RNN) Then
										If RobotLeft(RNN) - RSpeedx(RNN) > LeftParam(RNN) Then
											RobotQuePos(RNN) = RobotQuePos(RNN) + 1
											RobotIntQue(RNN, RobotQuePos(RNN)) = LeftInst(RNN)
											IntID(RNN, RobotQuePos(RNN)) = 3
										End If
									End If
								End If
							End If
							If RightInst(RNN) >= 0 Then
								If RSpeedx(RNN) > 0 Then
									If RobotLeft(RNN) >= RightParam(RNN) Then
										If RobotLeft(RNN) - RSpeedx(RNN) < RightParam(RNN) Then
											RobotQuePos(RNN) = RobotQuePos(RNN) + 1
											RobotIntQue(RNN, RobotQuePos(RNN)) = RightInst(RNN)
											IntID(RNN, RobotQuePos(RNN)) = 4
										End If
									End If
								End If
							End If
							
							If ShieldInst(RNN) >= 0 Then 'If it's using the shield int
								If RShield(RNN) < ShieldParam(RNN) Then 'If we're in low shield
									If ShieldInst(RNN) < 5000 Then 'And we weren't in low shield last chronon (then shieldinst should be > 4999)
										RobotQuePos(RNN) = RobotQuePos(RNN) + 1 'que the
										RobotIntQue(RNN, RobotQuePos(RNN)) = ShieldInst(RNN) 'interupt
										IntID(RNN, RobotQuePos(RNN)) = 5
										ShieldInst(RNN) = ShieldInst(RNN) + 5000
									End If
								Else 'If we're not in low shield anymore
									If ShieldInst(RNN) > 4999 Then 'and our shieldinst is set to a weird value then
										ShieldInst(RNN) = ShieldInst(RNN) - 5000 'Sets back shieldinst to it's real value
									End If
								End If
							End If
							If DamageInst(RNN) >= 0 Then
								If RDamage(RNN) < DamageParam(RNN) Then
									RobotQuePos(RNN) = RobotQuePos(RNN) + 1
									RobotIntQue(RNN, RobotQuePos(RNN)) = DamageInst(RNN)
									IntID(RNN, RobotQuePos(RNN)) = 6
									DamageParam(RNN) = RDamage(RNN)
								End If
							End If
							If WallInst(RNN) >= 0 Then 'If it's using the wall int
								If RWall(RNN) <> 0 Then 'If we're in wall
									If WallInst(RNN) < 5000 Then 'And we weren't in wall last chronon (then wallinst should be > 4999)
										RobotQuePos(RNN) = RobotQuePos(RNN) + 1 'que the
										RobotIntQue(RNN, RobotQuePos(RNN)) = WallInst(RNN) 'interupt
										IntID(RNN, RobotQuePos(RNN)) = 7
										WallInst(RNN) = WallInst(RNN) + 5000
									End If
								Else 'If we're not in wall anymore
									If WallInst(RNN) > 4999 Then 'and our wall inst is set to a weird value then
										WallInst(RNN) = WallInst(RNN) - 5000 'Sets back wallinst to it's real value
									End If
								End If 'COLLISION AND WALL SHOULD BE MUCH MORE CAREFULLY TESTED!!
							End If
							If CollisionInst(RNN) >= 0 Then 'If it's using the collision int
								If RCollision(RNN) <> 0 Then 'If we're in collision
									If CollisionInst(RNN) < 5000 Then 'And we weren't in collision last chronon (then collisioninst should be > 4999)
										RobotQuePos(RNN) = RobotQuePos(RNN) + 1 'que the
										RobotIntQue(RNN, RobotQuePos(RNN)) = CollisionInst(RNN) 'interupt
										IntID(RNN, RobotQuePos(RNN)) = 8
										CollisionInst(RNN) = CollisionInst(RNN) + 5000
									End If
								Else 'If we're not in collision anymore
									If CollisionInst(RNN) > 4999 Then 'and our collision inst is set to a weird value then
										CollisionInst(RNN) = CollisionInst(RNN) - 5000 'Sets back collisioninst to it's real value
									End If
								End If
							End If
							
							If RobotQuePos(RNN) > 1 Then 'This is hopefully only a temporary solution for doubletrigging problems
								If RobotIntQue(RNN, RobotQuePos(RNN)) = RobotIntQue(RNN, RobotQuePos(RNN) - 1) And IntID(RNN, RobotQuePos(RNN)) = IntID(RNN, RobotQuePos(RNN) - 1) Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
							End If
							
							If Inton(RNN) Then
								If RobotQuePos(RNN) > 0 Then
									If RobotStackPos(RNN) > 99 Then
										ErrorCode = BuggyOverflow : GoTo Buggy
									End If
									RobotStackPos(RNN) = RobotStackPos(RNN) + 1
									RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
									RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1 'qued ints subtracted when triggered             'jumps shall be done
									Inton(RNN) = False
									RobotQuePos(RNN) = RobotQuePos(RNN) - 1
									GoTo SkipTheRestOfTheInts
								ElseIf RadarInst(RNN) >= 0 Then 
									'RADAR
									RRadar = 0
									For shotcounter = 1 To ShotNumber
										If shot(shotcounter).ShotType < 200 Then
											'This is David Harris radar code, ported to Visual Basic by me.
											trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
											trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
											
											If trigx <> 0 Then 'atan2
												tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
											Else
												tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
											End If '''''''
											
											If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
											
											If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
												RRange = FixSquare(trigx * trigx + trigy * trigy)
												If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
											End If
										End If
									Next shotcounter
									'/RADAR
									If RRadar <> 0 Then
										If RRadar <= RadarParam(RNN) Then 'intrange sends back 601 for no range instead of 0
											If RobotStackPos(RNN) > 99 Then
												ErrorCode = BuggyOverflow : GoTo Buggy
											End If
											RobotStackPos(RNN) = RobotStackPos(RNN) + 1
											RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
											RobotInstPos(RNN) = RadarInst(RNN) - 1 ' -1 är nytt
											Inton(RNN) = False
											GoTo SkipTheRestOfTheInts
										End If
									End If
								End If
								If RangeInst(RNN) >= 0 Then
									'specialrange.. designed for 1 time per chronon checking
									RRadar = RAim(RNN) + RLook(RNN)
									If 1 <> RNN Then 'Skip checking range to self. It'll be too short
										tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
										trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
										trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
										
										If trigx * trigx + trigy * trigy <= 91 Then
											If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
												If RobotAlive(1) = 1 Then
													If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
														If RobotStackPos(RNN) > 99 Then
															ErrorCode = BuggyOverflow : GoTo Buggy
														End If
														RobotStackPos(RNN) = RobotStackPos(RNN) + 1
														RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
														RobotInstPos(RNN) = RangeInst(RNN) - 1 ' -1 är nytt
														Inton(RNN) = False
														GoTo SkipTheRestOfTheInts
													End If
												End If
											End If
										End If
									End If
									
									For shotcounter = 2 To NumberOfRobotsPresent
										If shotcounter <> RNN Then 'Skip checking range to self. It'll be too short
											tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
											trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
											trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
											
											If trigx * trigx + trigy * trigy <= 91 Then
												If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
													If RobotAlive(shotcounter) = 1 Then
														If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
															If RobotStackPos(RNN) > 99 Then
																ErrorCode = BuggyOverflow : GoTo Buggy
															End If
															RobotStackPos(RNN) = RobotStackPos(RNN) + 1
															RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
															RobotInstPos(RNN) = RangeInst(RNN) - 1 ' -1 är nytt
															Inton(RNN) = False
															GoTo SkipTheRestOfTheInts
														End If
													End If
												End If
											End If
										End If
									Next shotcounter
									'''''''''''
								End If
								If ChrononInst(RNN) >= 0 Then
									If ChrononParam(RNN) <= Chronon Then
										If RobotStackPos(RNN) > 99 Then
											ErrorCode = BuggyOverflow : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) + 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1
										RobotInstPos(RNN) = ChrononInst(RNN) - 1
										Inton(RNN) = False
									End If
								End If
							End If
							
SkipTheRestOfTheInts: 
							
							'Typ här skall hasmoved bli falskt
							HasMoved = 0
							
							'''Slut INTERUPPSKODEN
							For ChrononExecutor1 = 1 To RobotProSpeed(RNN)
								RobotInstPos(RNN) = RobotInstPos(RNN) + 1
								
								'It my tests shows, that in the following Select Case coditional, best speed results are gained when the most
								'common instructions are placed first.
								
								Select Case MachineCode(RNN, RobotInstPos(RNN)) 'MachineCode
									Case -19999 To 19999
										If RobotStackPos(RNN) > 99 Then
											ErrorCode = BuggyOverflow : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) + 1
										RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
									Case insA To TOPREGISTER
										If RobotStackPos(RNN) > 99 Then
											ErrorCode = BuggyOverflow : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) + 1
										RobotStack(RNN, RobotStackPos(RNN)) = MachineCode(RNN, RobotInstPos(RNN))
									Case insSTORE
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										Select Case RobotStack(RNN, RobotStackPos(RNN))
											Case insAIM 'ins
												RAim(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Mod 360
												If RAim(RNN) < 0 Or RAim(RNN) > 359 Then RAim(RNN) = RAim(RNN) Mod 360 - 360 * CShort(RAim(RNN) < 0)
												
												If Inton(RNN) Then '**********Interuppskod************'
													If RadarInst(RNN) >= 0 Then
														'RADAR
														RRadar = 0
														For shotcounter = 1 To ShotNumber
															If shot(shotcounter).ShotType < 200 Then
																'This is David Harris radar code, ported to Visual Basic by me.
																trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
																trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
																
																If trigx <> 0 Then 'atan2
																	tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
																Else
																	tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
																End If '''''''
																
																If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
																
																If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
																	RRange = FixSquare(trigx * trigx + trigy * trigy)
																	If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
																End If
															End If
														Next shotcounter
														'/RADAR
														If RRadar <> 0 Then
															If RRadar <= RadarParam(RNN) Then 'intrange sends back 601 for no range instead of 0
																RobotStackPos(RNN) = RobotStackPos(RNN) - 1
																RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
																RobotInstPos(RNN) = RadarInst(RNN) - 1
																Inton(RNN) = False
																GoTo NoStackRemoval
															End If
														End If
													End If
													If RangeInst(RNN) >= 0 Then
														'specialrange.. designed för look and aim instructions
														RRadar = RAim(RNN) + RLook(RNN)
														If 1 <> RNN Then 'Skip checking range to self. It'll be too short
															tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
															trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
															trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
															
															If trigx * trigx + trigy * trigy <= 91 Then
																If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
																	If RobotAlive(1) = 1 Then
																		If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
																			RobotStackPos(RNN) = RobotStackPos(RNN) - 1
																			RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
																			RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
																			Inton(RNN) = False
																			GoTo NoStackRemoval
																		End If
																	End If
																End If
															End If
														End If
														
														For shotcounter = 2 To NumberOfRobotsPresent
															If shotcounter <> RNN Then 'Skip checking range to self. It'll be too short
																tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
																trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
																trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
																
																If trigx * trigx + trigy * trigy <= 91 Then
																	If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
																		If RobotAlive(shotcounter) = 1 Then
																			If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
																				RobotStackPos(RNN) = RobotStackPos(RNN) - 1
																				RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
																				RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
																				Inton(RNN) = False
																				GoTo NoStackRemoval
																			End If
																		End If
																	End If
																End If
															End If
														Next shotcounter
														'''''''''''
													End If
												End If '**********Slut Interuppskod************'
											Case insSPEEDX 'ins
												If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1))
												REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RSpeedx(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
												RSpeedx(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insSPEEDY 'ins
												If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1)) > 20 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 20 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1))
												REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RSpeedy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1))
												RSpeedy(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insMISSILE 'ins
												If RobotMissiles(RNN) = 0 Then
													ErrorCode = BuggyMissiles
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
														If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotAngle = RAim(RNN)
																shot(ShotNumber).ShotType = Missile
																shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
																shot(ShotNumber).Shooter = RNN
															Else
																shot(FreeShot).ShotAngle = RAim(RNN)
																shot(FreeShot).ShotType = Missile
																shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) * 2
																shot(FreeShot).Shooter = RNN
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insFIRE 'ins
Robot1Fire: 
												If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
													REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
													If HasMoved <> 5 Or MoveAndShotAllowed Then
														If FreeShot = -1 Then
															ShotNumber = ShotNumber + 1
															shot(ShotNumber).ShotAngle = RAim(RNN)
															shot(ShotNumber).ShotType = Bullet
															shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
															shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
															shot(ShotNumber).Shooter = RNN
															Select Case RobotBullets(RNN)
																Case 0
																	shot(ShotNumber).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2 '/
																Case 2
																	shot(ShotNumber).ShotType = ExplosiveBullet
																	shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																Case 20
																	RobotBullets(RNN) = 2
																	shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																Case Else
																	shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															End Select
														Else
															shot(FreeShot).ShotAngle = RAim(RNN)
															shot(FreeShot).ShotType = Bullet
															shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
															shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
															shot(FreeShot).Shooter = RNN
															Select Case RobotBullets(RNN)
																Case 0
																	shot(FreeShot).ShotPower = (RobotStack(RNN, RobotStackPos(RNN) - 1)) \ 2 '
																Case 2
																	shot(FreeShot).ShotType = ExplosiveBullet
																	shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																Case 20
																	RobotBullets(RNN) = 2
																	shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																Case Else
																	shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															End Select
															FreeShot = -1
														End If
														HasMoved = 20
													Else
														ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
													End If
												End If
											Case insSHIELD 'ins
												If RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then 'Prevent negative shield
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 150 Then RobotStack(RNN, RobotStackPos(RNN) - 1) = 150 'Prevent shield over 150
													REnergy(RNN) = REnergy(RNN) + RShield(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Takes or energy restores energy to/from shield
													If REnergy(RNN) > RobotEnergy(RNN) Then REnergy(RNN) = RobotEnergy(RNN) 'Prevent energy higher than Robots Energy Max
													RShield(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Sets shield
												End If
											Case insSTUNNER 'ins
												If RobotStunners(RNN) = 0 Then
													ErrorCode = BuggyStunners
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then 'Cuts down the shot power to the Robots energy max
														If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then 'Stunner don't use freeshots because of the (Stunstreamer - Freeshot) visual bug which is fixed so they do
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotAngle = RAim(RNN)
																shot(ShotNumber).ShotType = Stunner
																shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4 'Int((RobotStack(RNN, RobotStackPos(RNN) - 1)) / 4)
															Else
																shot(FreeShot).ShotAngle = RAim(RNN)
																shot(FreeShot).ShotType = Stunner
																shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 4
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insMOVEX 'ins
												REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
												If HasMoved <> 20 Or MoveAndShotAllowed Then
													RobotLeft(RNN) = RobotLeft(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
													'TurretX2(RNN) = TurretX2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
													If RobotLeft(RNN) > 300 Then 'otherwise it can use MOVEX to jump outside the areana!!!
														RobotLeft(RNN) = 300
														'TurretX2(RNN) = 300 + TurretX2(RNN) - RobotLeft(RNN)
													ElseIf RobotLeft(RNN) < 0 Then 
														RobotLeft(RNN) = 0
														'TurretX2(RNN) = TurretX2(RNN) - RobotLeft(RNN)
													End If
													HasMoved = 5
												Else
													ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
												End If
											Case insMOVEY 'ins
												REnergy(RNN) = REnergy(RNN) - 2 * System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
												If HasMoved <> 20 Or MoveAndShotAllowed Then
													RobotTop(RNN) = RobotTop(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
													'TurretY2(RNN) = TurretY2(RNN) + RobotStack(RNN, RobotStackPos(RNN) - 1)
													If RobotTop(RNN) > 300 Then 'otherwise it can use MOVEX to jump outside the areana!!!
														RobotTop(RNN) = 300
														'TurretY2(RNN) = 300 + TurretY2(RNN) - RobotTop(RNN)
													ElseIf RobotTop(RNN) < 0 Then 
														RobotTop(RNN) = 0
														'TurretY2(RNN) = TurretY2(RNN) - RobotTop(RNN)
													End If
													HasMoved = 5
												Else
													ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
												End If
											Case insHELLBORE 'ins
												If RobotHellbores(RNN) = 0 Then
													ErrorCode = BuggyHellbores
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 3 And RobotStack(RNN, RobotStackPos(RNN) - 1) < 21 Then
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotAngle = RAim(RNN)
																shot(ShotNumber).ShotType = Hellbore
																shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
															Else
																shot(FreeShot).ShotAngle = RAim(RNN)
																shot(FreeShot).ShotType = Hellbore
																shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insA : RA(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insB : RB(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insC : RC(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insD : RD(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insE : RE(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insF : RF(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insG : RG(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insH : RH(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insI : RI(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insJ : RJ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insK : RK(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insL : RL(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insM : RM(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insN : RN(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insO : RO(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insP : RP(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insQ : RQ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insR : RR(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insS : RS(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case Inst : RT(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insU : RU(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insV : RV(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insZ : RZ(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insW : RW(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insLOOK 'ins
												RLook(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RLook(RNN) > 359 Then RLook(RNN) = RLook(RNN) Mod 360
												If RLook(RNN) < 0 Then RLook(RNN) = RLook(RNN) Mod 360 + 360
												If Inton(RNN) And RangeInst(RNN) >= 0 Then '**********Interuppskod************
													'specialrange.. designed för look and aim instructions
													RRadar = RAim(RNN) + RLook(RNN)
													If 1 <> RNN Then 'Skip checking range to self. It'll be too short
														tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(1)) * (RobotLeft(RNN) - RobotLeft(1)) + (RobotTop(RNN) - RobotTop(1)) * (RobotTop(RNN) - RobotTop(1)))
														trigx = Sine(RRadar) * tempnumber - RobotLeft(1) + RobotLeft(RNN)
														trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(1)
														
														If trigx * trigx + trigy * trigy <= 91 Then
															If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
																If RobotAlive(1) = 1 Then
																	If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(1) Then
																		RobotStackPos(RNN) = RobotStackPos(RNN) - 1
																		RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
																		RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
																		Inton(RNN) = False
																		GoTo NoStackRemoval
																	End If
																End If
															End If
														End If
													End If
													
													For shotcounter = 2 To NumberOfRobotsPresent
														If shotcounter <> RNN Then 'Skip checking range to self. It'll be too short
															tempnumber = FixSquare((RobotLeft(RNN) - RobotLeft(shotcounter)) * (RobotLeft(RNN) - RobotLeft(shotcounter)) + (RobotTop(RNN) - RobotTop(shotcounter)) * (RobotTop(RNN) - RobotTop(shotcounter)))
															trigx = Sine(RRadar) * tempnumber - RobotLeft(shotcounter) + RobotLeft(RNN)
															trigy = RobotTop(RNN) - Cosine(RRadar) * tempnumber - RobotTop(shotcounter)
															
															If trigx * trigx + trigy * trigy <= 91 Then
																If tempnumber <= RangeParam(RNN) Then 'intrange sends back 601 for no range instead of 0
																	If RobotAlive(shotcounter) = 1 Then
																		If RobotTeam(RNN) = 0 Or RobotTeam(RNN) <> RobotTeam(shotcounter) Then
																			RobotStackPos(RNN) = RobotStackPos(RNN) - 1
																			RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
																			RobotInstPos(RNN) = RangeInst(RNN) - 1 ' - 1 nytt
																			Inton(RNN) = False
																			GoTo NoStackRemoval
																		End If
																	End If
																End If
															End If
														End If
													Next shotcounter
													'''''''''''
												End If '**********Slut Interuppskod************'
											Case insBULLET 'ins                                 'It seems like a robot can mess up it's explosive
												If RobotBullets(RNN) = 2 Then RobotBullets(RNN) = 20 'bullets by firing negative shots. It's certainly
												GoTo Robot1Fire 'not an adventage, so it' can't be considered cheating
											Case insNUKE 'ins
												If RobotTacNukes(RNN) = 0 Then
													ErrorCode = BuggyTacNukes
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotFireTime = Chronon
																shot(ShotNumber).ShotType = TakeNuke
																shot(ShotNumber).ShotX = RobotLeft(RNN)
																shot(ShotNumber).ShotY = RobotTop(RNN)
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																shot(ShotNumber).Shooter = RNN
															Else
																shot(FreeShot).ShotFireTime = Chronon
																shot(FreeShot).ShotType = TakeNuke
																shot(FreeShot).ShotX = RobotLeft(RNN)
																shot(FreeShot).ShotY = RobotTop(RNN)
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																shot(FreeShot).Shooter = RNN
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insMEGANUKE 'ins
												If RobotTacNukes(RNN) = 0 Then
													ErrorCode = BuggyTacNukes
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotFireTime = Chronon
																shot(ShotNumber).ShotType = MegaNuke
																shot(ShotNumber).ShotX = RobotLeft(RNN)
																shot(ShotNumber).ShotY = RobotTop(RNN)
																shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																shot(ShotNumber).Shooter = RNN
															Else
																shot(FreeShot).ShotFireTime = Chronon
																shot(FreeShot).ShotType = MegaNuke
																shot(FreeShot).ShotX = RobotLeft(RNN)
																shot(FreeShot).ShotY = RobotTop(RNN)
																shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1)
																shot(FreeShot).Shooter = RNN
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insMINE 'ins
												If RobotMines(RNN) = 0 Then
													ErrorCode = BuggyMines
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) - 5 > 0 Then
														REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1) 'Abs(RobotStack(RNN, RobotStackPos(RNN) - 1))
														If HasMoved <> 5 Or MoveAndShotAllowed Then
															If FreeShot = -1 Then
																ShotNumber = ShotNumber + 1
																shot(ShotNumber).ShotFireTime = Chronon
																shot(ShotNumber).ShotType = Mine
																shot(ShotNumber).ShotX = RobotLeft(RNN)
																shot(ShotNumber).ShotY = RobotTop(RNN)
																shot(ShotNumber).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
																shot(ShotNumber).Shooter = RNN
															Else
																shot(FreeShot).ShotFireTime = Chronon
																shot(FreeShot).ShotType = Mine
																shot(FreeShot).ShotX = RobotLeft(RNN)
																shot(FreeShot).ShotY = RobotTop(RNN)
																shot(FreeShot).ShotPower = 2 * (RobotStack(RNN, RobotStackPos(RNN) - 1) - 5)
																shot(FreeShot).Shooter = RNN
																FreeShot = -1
															End If
															HasMoved = 20
														Else
															ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
														End If
													End If
												End If
											Case insLASER 'ins
												If RobotLasers(RNN) = 0 Then
													ErrorCode = BuggyLasers
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 Then ' It is possible in the Mac version to shoot laser shots that actually doesn't do any harm
														If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'It seems to be possible to shoot laser at dead robots
															'If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
															If RobotAlive(RangedRobot(RNN)) = 1 Then
																If RobotStack(RNN, RobotStackPos(RNN) - 1) > REnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = REnergy(RNN)
																
																REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
																If HasMoved <> 5 Or MoveAndShotAllowed Then
																	TurretX2(RNN) = RobotLeft(RNN) + Sin10(RAim(RNN)) 'Sets the turret x2 for the aim
																	TurretY2(RNN) = RobotTop(RNN) - Cos10(RAim(RNN)) 'since it's used in non-displayed for laser
																	
																	If FreeShot = -1 Then
																		ShotNumber = ShotNumber + 1
																		shot(ShotNumber).ShotType = Laser
																		shot(ShotNumber).ShotAngle = RangedRobot(RNN)
																		shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
																		shot(ShotNumber).Shooter = RNN
																		shot(ShotNumber).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN) 'Shows laser on radar instantly
																		shot(ShotNumber).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
																	Else
																		shot(FreeShot).ShotType = Laser
																		shot(FreeShot).ShotAngle = RangedRobot(RNN)
																		shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 5
																		shot(FreeShot).Shooter = RNN
																		shot(FreeShot).ShotX = RobotLeft(RangedRobot(RNN)) - TurretX2(RNN) + RobotLeft(RNN) 'Shows laser on radar instantly
																		shot(FreeShot).ShotY = RobotTop(RangedRobot(RNN)) - TurretY2(RNN) + RobotTop(RNN)
																		FreeShot = -1
																	End If
																	HasMoved = 20
																Else
																	ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
																End If
															End If
														End If
													End If
												End If
											Case insDRONE 'ins
												If RobotDrones(RNN) = 0 Then
													ErrorCode = BuggyDrones
													GoTo Buggy
												Else
													If RobotStack(RNN, RobotStackPos(RNN) - 1) > 0 And Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'Range <> 0
														If RobotAlive(RangedRobot(RNN)) = 1 Then 'Cuts down the shot power to the Robots energy max
															If RobotStack(RNN, RobotStackPos(RNN) - 1) > RobotEnergy(RNN) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotEnergy(RNN)
															REnergy(RNN) = REnergy(RNN) - RobotStack(RNN, RobotStackPos(RNN) - 1)
															If HasMoved <> 5 Or MoveAndShotAllowed Then
																If FreeShot = -1 Then
																	ShotNumber = ShotNumber + 1
																	shot(ShotNumber).ShotAngle = RangedRobot(RNN) 'Shootangle represents tracking robot
																	shot(ShotNumber).ShotFireTime = Chronon + 100 'ShotFireTime represents the chronon the drone die
																	shot(ShotNumber).ShotType = Drone
																	shot(ShotNumber).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																	shot(ShotNumber).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																	shot(ShotNumber).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
																	shot(ShotNumber).Shooter = RNN
																Else
																	shot(FreeShot).ShotAngle = RangedRobot(RNN) 'Shootangle represents tracking robot
																	shot(FreeShot).ShotFireTime = Chronon + 100 'ShotFireTime represents the chronon the drone die
																	shot(FreeShot).ShotType = Drone
																	shot(FreeShot).ShotX = RobotLeft(RNN) + Sin11(RAim(RNN))
																	shot(FreeShot).ShotY = RobotTop(RNN) - Cos11(RAim(RNN))
																	shot(FreeShot).ShotPower = RobotStack(RNN, RobotStackPos(RNN) - 1) \ 2
																	shot(FreeShot).Shooter = RNN
																	FreeShot = -1
																End If
																HasMoved = 20
															Else
																ShowMoveAndShootMessage(RNN, ChrononExecutor1, RobotInstPos(RNN))
															End If
														End If
													End If
												End If
											Case insSCAN 'ins
												RScan(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RScan(RNN) > 359 Then RScan(RNN) = RScan(RNN) Mod 360
												If RScan(RNN) < 0 Then RScan(RNN) = RScan(RNN) Mod 360 + 360
												If Inton(RNN) And RadarInst(RNN) >= 0 Then
													'RADAR
													RRadar = 0
													For shotcounter = 1 To ShotNumber
														If shot(shotcounter).ShotType < 200 Then
															'This is David Harris radar code, ported to Visual Basic by me.
															trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
															trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
															
															If trigx <> 0 Then 'atan2
																tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
															Else
																tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
															End If '''''''
															
															If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
															
															If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
																RRange = FixSquare(trigx * trigx + trigy * trigy)
																If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
															End If
														End If
													Next shotcounter
													'/RADAR
													If RRadar <> 0 Then
														If RRadar <= RadarParam(RNN) Then
															RobotStackPos(RNN) = RobotStackPos(RNN) - 1
															RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'Vilket förfärligt bug att hitta!
															RobotInstPos(RNN) = RadarInst(RNN) - 1 ' - 1 nytt
															Inton(RNN) = False
															GoTo NoStackRemoval
														End If
													End If
												End If
											Case insHISTORY 'ins
												If HistoryParam(RNN) >= 31 Then HistoryRec(RNN, HistoryParam(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insSIGNAL
												If RobotTeam(RNN) <> 0 Then
													RSignal(RobotTeam(RNN), RChannel(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
													
													For tempnumber = 1 To NumberOfRobotsPresent
														If RobotTeam(RNN) = RobotTeam(tempnumber) Then
															If tempnumber <> RNN Then
																If SignalInst(tempnumber) >= 0 Then
																	If SignalParam(tempnumber) = RChannel(RNN) Then
																		RobotQuePos(tempnumber) = RobotQuePos(tempnumber) + 1
																		RobotIntQue(tempnumber, RobotQuePos(tempnumber)) = SignalInst(tempnumber)
																		IntID(tempnumber, RobotQuePos(tempnumber)) = 11
																	End If
																End If
															End If
														End If
													Next tempnumber
												End If
											Case insCHANNEL
												RChannel(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RChannel(RNN) > 10 Or RChannel(RNN) < 1 Then
													ErrorCode = BuggyChannel : GoTo Buggy
												End If
											Case Else
												ErrorCode = BuggyStore
												GoTo Buggy
										End Select
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
NoStackRemoval: 
									Case insRECALL 'Removing the Reversed Recalls took exactly 3 hours and 29 minutes, including speed testing but
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyRecall : GoTo Buggy
										End If
										
										Select Case RobotStack(RNN, RobotStackPos(RNN)) 'excluding recompiling all robots
											Case insRANGE 'ins
												RRange = Range(RNN, RAim(RNN) + RLook(RNN))
												If RRange <> 0 Then
													If RobotAlive(RangedRobot(RNN)) <> 1 Then RRange = 0
												End If
												RobotStack(RNN, RobotStackPos(RNN)) = RRange
											Case insAIM 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RAim(RNN)
											Case insX 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RobotLeft(RNN)
											Case insY 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RobotTop(RNN)
											Case insRADAR 'ins
												'RADAR
												RRadar = 0 'RRadar
												For shotcounter = 1 To ShotNumber
													If shot(shotcounter).ShotType < 200 Then
														'This is David Harris radar code, ported to Visual Basic by me.
														trigx = RobotLeft(RNN) - Fix(shot(shotcounter).ShotX) 'This is to make sure that we cut floats like C does
														trigy = RobotTop(RNN) - Fix(shot(shotcounter).ShotY) 'This is absolutely nessecary
														
														If trigx <> 0 Then 'atan2
															tempnumber = System.Math.Abs(450 - TPI * System.Math.Atan(trigy / -trigx) + 180 * CShort(trigx >= 0) - RAim(RNN) - RScan(RNN))
														Else
															tempnumber = System.Math.Abs(450 - 90 * System.Math.Sign(trigy) - RAim(RNN) - RScan(RNN))
														End If '''''''
														
														If tempnumber > 359 Then tempnumber = tempnumber - 360 'Max(atan2) = 359: Max(AimValue) = 718 => Max(TempNumber) = 627
														
														If tempnumber < 20 Or tempnumber > 340 Then '< 19  341 >        '24 och 336
															RRange = FixSquare(trigx * trigx + trigy * trigy)
															If RRange < RRadar Or RRadar = 0 Then RRadar = RRange
														End If
													End If
												Next shotcounter
												'/RADAR
												RobotStack(RNN, RobotStackPos(RNN)) = RRadar
											Case insSPEEDX 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RSpeedx(RNN)
											Case insSPEEDY 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RSpeedy(RNN)
											Case insENERGY 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RNN)
											Case insSHIELD 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RShield(RNN)
											Case insLOOK 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RLook(RNN)
											Case insDOPPLER 'ins
												'Many Thanks to Sam Rushing who helped me out
												'and explained how the Doppler routine worked.    'Dead robot are set to E = -10
												
												'Prfnoff's version - Robots with E -1 has doppler?
												'4.5.2 - Robots med E -1 doesn't have doppler
												
												If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then 'Med allra allra största sannolikhet skall jag använda RealStunned
													If REnergy(RangedRobot(RNN)) <= 0 Or RStunned(RangedRobot(RNN)) <> 0 Or RCollision(RangedRobot(RNN)) <> 0 Then 'RWall(RangedRobot(RNN)) <> 0 Or
														RobotStack(RNN, RobotStackPos(RNN)) = 0
													Else
														RRange = RobotLeft(RNN) - RobotLeft(RangedRobot(RNN)) 'xdiff
														RRadar = RobotTop(RNN) - RobotTop(RangedRobot(RNN)) 'ydiff
														'Ej testat om det skall vara round eller fix, kolla
														RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Round((RSpeedx(RangedRobot(RNN)) * RRadar - RRange * RSpeedy(RangedRobot(RNN))) / Square(RRadar * RRadar + RRange * RRange)) 'Round
													End If
												Else
													RobotStack(RNN, RobotStackPos(RNN)) = 0
												End If
											Case insNEAREST
												If RobotProSpeed(RNN) <= 10 Then
													If NumberOfRobotsPresent > 1 Then
														tempnumber = Nearest(RNN)
														If RobotAlive(tempnumber) = 1 Then
															If RobotTop(tempnumber) <> RobotTop(RNN) Then
																If RobotTop(RNN) > RobotTop(tempnumber) Then
																	RobotStack(RNN, RobotStackPos(RNN)) = (System.Math.Round(TPI * System.Math.Atan((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN))))) - RAim(RNN)
																Else
																	RobotStack(RNN, RobotStackPos(RNN)) = (System.Math.Round(TPI * System.Math.Atan((RobotLeft(RNN) - RobotLeft(tempnumber)) / (RobotTop(tempnumber) - RobotTop(RNN)))) + 180) - RAim(RNN)
																End If
															Else
																If RobotLeft(RNN) < RobotLeft(tempnumber) Then
																	RobotStack(RNN, RobotStackPos(RNN)) = 90 - RAim(RNN)
																Else
																	RobotStack(RNN, RobotStackPos(RNN)) = 270 - RAim(RNN)
																End If
															End If
															
															If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 360
														Else
															RobotStack(RNN, RobotStackPos(RNN)) = -1
														End If
													Else
														RobotStack(RNN, RobotStackPos(RNN)) = -1
													End If
												Else
													ErrorCode = BuggyNearest
													GoTo Buggy
												End If
											Case insROBOTS 'ins
												If HowManyLeft = 255 Then
													RobotStack(RNN, RobotStackPos(RNN)) = 1
												ElseIf R2Present Then 
													RobotStack(RNN, RobotStackPos(RNN)) = HowManyLeft
												Else
													RobotStack(RNN, RobotStackPos(RNN)) = 1
												End If
											Case insCHRONON 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = Chronon
											Case insCOLLISION 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Sign(RCollision(RNN))
											Case insA 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RA(RNN)
											Case insB 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RB(RNN)
											Case insC 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RC(RNN)
											Case insD 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RD(RNN)
											Case insE 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RE(RNN)
											Case insF 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RF(RNN)
											Case insG 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RG(RNN)
											Case insH 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RH(RNN)
											Case insI 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RI(RNN)
											Case insJ 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RJ(RNN)
											Case insK 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RK(RNN)
											Case insL 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RL(RNN)
											Case insM 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RM(RNN)
											Case insN 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RN(RNN)
											Case insO 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RO(RNN)
											Case insP 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RP(RNN)
											Case insQ 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RQ(RNN)
											Case insR 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RR(RNN)
											Case insS 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RS(RNN)
											Case Inst 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RT(RNN)
											Case insU 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RU(RNN)
											Case insV 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RV(RNN)
											Case insZ 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RZ(RNN)
											Case insW 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RW(RNN)
											Case insPROBE 'ins
												If RobotProbes(RNN) = 0 Then
													ErrorCode = BuggyProbes
													GoTo Buggy
												Else
													If Range(RNN, RAim(RNN) + RLook(RNN)) <> 0 Then
														If RobotAlive(RangedRobot(RNN)) <> 1 Then
															RobotStack(RNN, RobotStackPos(RNN)) = 0
														Else
															Select Case ProbeSet(RNN)
																'0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
																'4 = Teammates - Currently disabled 'cause of no teams
																Case 1
																	RobotStack(RNN, RobotStackPos(RNN)) = REnergy(RangedRobot(RNN))
																Case 0
																	RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RangedRobot(RNN))
																Case 2
																	RobotStack(RNN, RobotStackPos(RNN)) = RShield(RangedRobot(RNN))
																Case 7
																	RobotStack(RNN, RobotStackPos(RNN)) = RScan(RangedRobot(RNN))
																Case 3
																	RobotStack(RNN, RobotStackPos(RNN)) = RangedRobot(RNN) - 1 '0 to 5
																Case 5
																	RobotStack(RNN, RobotStackPos(RNN)) = RAim(RangedRobot(RNN))
																Case 6
																	RobotStack(RNN, RobotStackPos(RNN)) = RLook(RangedRobot(RNN))
																Case 4
																	RobotStack(RNN, RobotStackPos(RNN)) = 0
																	For tempnumber = 1 To NumberOfRobotsPresent
																		If tempnumber <> RangedRobot(RNN) Then
																			If RobotTeam(tempnumber) = RobotTeam(RangedRobot(RNN)) Then
																				If RobotAlive(tempnumber) = 1 Then
																					RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
																				End If
																			End If
																		End If
																	Next tempnumber
															End Select
														End If
													Else
														RobotStack(RNN, RobotStackPos(RNN)) = 0
													End If
												End If
											Case insWALL 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RWall(RNN)
											Case insDAMAGE 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RDamage(RNN)
											Case insRANDOM 'ins
												If RunningTournament Then
													RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Round((359 + 1) * Rnd()) 'Int
												Else
													If Replaying And NotRandomEmergency Then
														RobotStack(RNN, RobotStackPos(RNN)) = RandomRegister(RandomCounter)
													Else
														RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Round((359 + 1) * Rnd()) 'Int
														ReDim Preserve RandomRegister(RandomCounter)
														RandomRegister(RandomCounter) = RobotStack(RNN, RobotStackPos(RNN))
													End If
													RandomCounter = RandomCounter + 1
												End If
											Case insSCAN 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RScan(RNN)
											Case insID 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = RNN - 1 '0 to 5
											Case insHISTORY 'ins     'If repeat battle is checked we should read from the backup rec, unless we're using user defined history, in case we should read from the regular rec, since regular rec 31-50 is reset at the end of a repeated battle
												If Replaying And HistoryParam(RNN) < 31 Then RobotStack(RNN, RobotStackPos(RNN)) = BackupHistoryRec(RNN, HistoryParam(RNN)) Else RobotStack(RNN, RobotStackPos(RNN)) = HistoryRec(RNN, HistoryParam(RNN))
											Case insKILLS 'ins
												RobotStack(RNN, RobotStackPos(RNN)) = KR(RNN)
											Case insSIGNAL
												If RobotTeam(RNN) <> 0 Then
													RobotStack(RNN, RobotStackPos(RNN)) = RSignal(RobotTeam(RNN), RChannel(RNN))
												Else
													RobotStack(RNN, RobotStackPos(RNN)) = 0
												End If
											Case insFRIEND
												If RCollision(RNN) <> 0 And RobotTeam(RNN) <> 0 Then
													If RobotTeam(RCollision(RNN)) = RobotTeam(RNN) Then RobotStack(RNN, RobotStackPos(RNN)) = 1 Else RobotStack(RNN, RobotStackPos(RNN)) = 0
												Else
													RobotStack(RNN, RobotStackPos(RNN)) = 0
												End If
											Case insCHANNEL
												RobotStack(RNN, RobotStackPos(RNN)) = RChannel(RNN)
											Case insTEAMMATES
												RobotStack(RNN, RobotStackPos(RNN)) = 0
												For tempnumber = 1 To NumberOfRobotsPresent
													If tempnumber <> RNN Then
														If RobotTeam(tempnumber) = RobotTeam(RNN) Then
															If RobotAlive(tempnumber) = 1 Then
																RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + 1
															End If
														End If
													End If
												Next tempnumber
											Case Else
												ErrorCode = BuggyRecall '& RobotStack(RNN, RobotStackPos(RNN))
												GoTo Buggy
										End Select
									Case insIF 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
											RobotStackPos(RNN) = RobotStackPos(RNN) - 2
										Else
											tempnumber = RobotInstPos(RNN) + 1 'Tempnumber gav ingen hastighetsökning
											If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
											RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
											RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										End If
									Case insMORE
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) >= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insJUMP 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
											RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
										Else
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insIFG 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
											If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
									Case insPLUS
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) + RobotStack(RNN, RobotStackPos(RNN) + 1)
										If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
											ErrorCode = BuggyNumberOutofBounds : GoTo Buggy
										End If
									Case insLESS
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) <= RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insSYNC 'Rep'
										Exit For
									Case insDUP 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStackPos(RNN) > 99 Then
											ErrorCode = BuggyOverflow : GoTo Buggy
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) + 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
									Case insSETINT 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 1) > 4999 Or RobotStack(RNN, RobotStackPos(RNN) - 1) < -1 Then
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
										
										Select Case RobotStack(RNN, RobotStackPos(RNN))
											Case insRANGE ' 'Rep'
												RangeInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insLEFT ' 'Rep'
												LeftInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If LeftInst(RNN) = -1 Then 'BUG ALERT!! Detta klarar bara om första stacknumret är
													If RobotQuePos(RNN) <> 0 Then 'hett! Tillfällig lösning
														If IntID(RNN, RobotQuePos(RNN)) = 3 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insRIGHT ' 'Rep'
												RightInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RightInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 4 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insTOP ' 'Rep'
												TopInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If TopInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 1 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insBOT ' 'Rep'
												BotInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If BotInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 2 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insWALL ' 'Rep'
												WallInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If WallInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 7 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insCOLLISION ' 'Rep'
												CollisionInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If CollisionInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 8 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insROBOTS ' 'Rep'
												RobotsInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If RobotsInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 9 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insCHRONON ' 'Rep'
												ChrononInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insRADAR ' 'Rep'
												RadarInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insDAMAGE ' 'Rep'
												DamageInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If DamageInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 6 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insSHIELD ' 'Rep'
												ShieldInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If ShieldInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 5 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												Else 'Else är nytt - tidigare stod If Rshieled utanför if
													If RShield(RNN) < ShieldParam(RNN) Then ShieldInst(RNN) = ShieldInst(RNN) + 5000
												End If
											Case insTEAMMATES ' 'Rep'
												TeammatesInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If TeammatesInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 10 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case insSIGNAL ' 'Rep'
												SignalInst(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If SignalInst(RNN) = -1 Then
													If RobotQuePos(RNN) <> 0 Then
														If IntID(RNN, RobotQuePos(RNN)) = 11 Then RobotQuePos(RNN) = RobotQuePos(RNN) - 1
													End If
												End If
											Case Else
												ErrorCode = BuggySetint
												GoTo Buggy
										End Select
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
									Case insRTI 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										Inton(RNN) = True
										If RobotQuePos(RNN) <= 0 Then
											If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
											RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										Else
											RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1 'qued ints subtracted when triggered             'jumps shall be done
											Inton(RNN) = False
											RobotQuePos(RNN) = RobotQuePos(RNN) - 1
										End If
									Case insSETPARAM 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										Select Case RobotStack(RNN, RobotStackPos(RNN))
											Case insRANGE ' 'Rep'
												RangeParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insLEFT ' 'Rep'
												LeftParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insRIGHT ' 'Rep'
												RightParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insTOP ' 'Rep'
												TopParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insBOT ' 'Rep'
												BotParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insPROBE ' 'Rep'
												'0 = Damage '1 = Energy '2 = Shield '3 = ID '5 = Aim '6 = look '7 = scan
												'4 = Teammates - Currently disabled 'cause of no teams
												Select Case RobotStack(RNN, RobotStackPos(RNN) - 1)
													Case insDAMAGE ' 'Rep'
														ProbeSet(RNN) = 0
													Case insENERGY ' 'Rep'
														ProbeSet(RNN) = 1
													Case insSHIELD ' 'Rep'
														ProbeSet(RNN) = 2
													Case insSCAN ' 'Rep'
														ProbeSet(RNN) = 7
													Case insID ' 'Rep'
														ProbeSet(RNN) = 3
													Case insAIM ' 'Rep'
														ProbeSet(RNN) = 5
													Case insLOOK ' 'Rep'
														ProbeSet(RNN) = 6
													Case insTEAMMATES ' 'Rep'
														ProbeSet(RNN) = 4
														'                                    Case Else
														'                                        ErrorCode =  'Rep'Illegal 'PROBE' register  'Rep' & RobotStack(RNN, RobotStackPos(RNN))
														'                                        GoTo Buggy
												End Select
											Case insRADAR ' 'Rep'
												RadarParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insCHRONON ' 'Rep'
												ChrononParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insROBOTS ' 'Rep'
												RobotsParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insDAMAGE ' 'Rep'
												DamageParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
												If DamageParam(RNN) > RDamage(RNN) Then DamageParam(RNN) = RDamage(RNN)
											Case insHISTORY ' 'Rep'
												HistoryParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insSHIELD ' 'Rep'
												ShieldParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insTEAMMATES ' 'Rep'
												TeammatesParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case insSIGNAL
												SignalParam(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1)
											Case Else
												ErrorCode = BuggySetparam
												GoTo Buggy
										End Select
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
									Case insCALL 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										tempnumber = RobotInstPos(RNN) + 1
										If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
											RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
										Else
											ErrorCode = BuggyDestination : GoTo Buggy
										End If
										RobotStack(RNN, RobotStackPos(RNN)) = tempnumber
									Case insAND 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) = 0 Or RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insMINUS
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) - RobotStack(RNN, RobotStackPos(RNN) + 1)
										If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
											ErrorCode = BuggyNumberOutofBounds : GoTo Buggy
										End If
									Case insINTON 'Rep'
										Inton(RNN) = True
										If RobotQuePos(RNN) > 0 Then
											If RobotStackPos(RNN) > 99 Then
												ErrorCode = BuggyOverflow : GoTo Buggy
											End If
											RobotStackPos(RNN) = RobotStackPos(RNN) + 1
											RobotStack(RNN, RobotStackPos(RNN)) = RobotInstPos(RNN) + 1 'There is a lot of confusion about how
											RobotInstPos(RNN) = RobotIntQue(RNN, RobotQuePos(RNN)) - 1 'qued ints subtracted when triggered             'jumps shall be done
											Inton(RNN) = False
											RobotQuePos(RNN) = RobotQuePos(RNN) - 1
										End If
									Case insDIVISION
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
											ErrorCode = BuggyDivision : GoTo Buggy
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) \ RobotStack(RNN, RobotStackPos(RNN) + 1)
									Case insTIMES
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN)) * RobotStack(RNN, RobotStackPos(RNN) + 1)
										If System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN))) > 19999 Then
											ErrorCode = BuggyNumberOutofBounds : GoTo Buggy
										End If
									Case insSAME
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insBEEP 'Rep' 'Represents all icon snd instructions, debug, print and beep  for undisplayed
										ChrononExecutor1 = ChrononExecutor1 - 1
									Case insARCTAN 'Rep'                                       'Shall not use Fix!!
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0 Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = System.Math.Round(TPI * System.Math.Atan(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)) + 90 - (90 * (System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1)) - 1)))
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) * (System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) + 1)
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insDROPALL 'Rep'
										RobotStackPos(RNN) = 0
									Case insNOT 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) = 0 Then
											RobotStack(RNN, RobotStackPos(RNN)) = 1
										Else
											RobotStack(RNN, RobotStackPos(RNN)) = 0 'Nej, dethär går inte att förenkla
										End If
									Case insDROP 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insSWAP 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										tempnumber = RobotStack(RNN, RobotStackPos(RNN))
										RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										RobotStack(RNN, RobotStackPos(RNN) - 1) = tempnumber
									Case insIFEG 'Rep'
										If RobotStackPos(RNN) < 3 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
											If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
										Else
											If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 3
									Case insVRECALL 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) < 0 Or RobotStack(RNN, RobotStackPos(RNN)) > 100 Then
											RobotStack(RNN, RobotStackPos(RNN)) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN)) = RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN)))
										End If
									Case insMOD 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN) - 1) Mod RobotStack(RNN, RobotStackPos(RNN))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insOR 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) = 0 And RobotStack(RNN, RobotStackPos(RNN) - 1) = 0 Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insIFE 'Rep'
										If RobotStackPos(RNN) < 3 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN) - 2) = 0 Then
											tempnumber = RobotInstPos(RNN) + 1
											If RobotStack(RNN, RobotStackPos(RNN)) <= 4999 And RobotStack(RNN, RobotStackPos(RNN)) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN)) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
											RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
											RobotStackPos(RNN) = RobotStackPos(RNN) - 2
										Else
											tempnumber = RobotInstPos(RNN) + 1 'Samma sak här, det borde funka med tempnumber
											If RobotStack(RNN, RobotStackPos(RNN) - 1) <= 4999 And RobotStack(RNN, RobotStackPos(RNN) - 1) >= 0 Then
												RobotInstPos(RNN) = RobotStack(RNN, RobotStackPos(RNN) - 1) - 1
											Else
												ErrorCode = BuggyDestination : GoTo Buggy
											End If
											RobotStack(RNN, RobotStackPos(RNN) - 2) = tempnumber
											RobotStackPos(RNN) = RobotStackPos(RNN) - 2
										End If
									Case insMAX 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) > RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insSIN 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * System.Math.Sin(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insCOS 'Rep'              'Fix avrundar exact som Mac RoboWar!!
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(RobotStack(RNN, RobotStackPos(RNN)) * System.Math.Cos(RobotStack(RNN, RobotStackPos(RNN) - 1) * PIO))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insINTOFF 'Rep'
										Inton(RNN) = False
									Case insVSTORE 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) >= 0 And RobotStack(RNN, RobotStackPos(RNN)) <= 100 Then
											RVRECALL(RNN, RobotStack(RNN, RobotStackPos(RNN))) = RobotStack(RNN, RobotStackPos(RNN) - 1)
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 2
									Case insCHS 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN)) = -RobotStack(RNN, RobotStackPos(RNN)) '* -1
									Case insABS 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN)) = System.Math.Abs(RobotStack(RNN, RobotStackPos(RNN)))
									Case insTAN '       BUG ALERT!! Hur är det med 90 + de nya optimeringarna?
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										TDouble = Fix(RobotStack(RNN, RobotStackPos(RNN)) * System.Math.Tan((90 - RobotStack(RNN, RobotStackPos(RNN) - 1)) * PIO))
										If System.Math.Abs(TDouble) > 19999 Then TDouble = 19999 * System.Math.Sign(TDouble)
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
										RobotStack(RNN, RobotStackPos(RNN)) = TDouble
									Case insNOT_SAME 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) = RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insROLL 'Rep'
										If RobotStackPos(RNN) < RobotStack(RNN, RobotStackPos(RNN)) + 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										tempnumber = RobotStack(RNN, RobotStackPos(RNN) - 1) 'Stores the number to roll back in tempstack
										For shotcounter = RobotStackPos(RNN) - 1 To RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) Step -1 'decides what stack numbers moving up
											RobotStack(RNN, shotcounter) = RobotStack(RNN, shotcounter - 1) 'adjust stack numbers affected by roll
										Next shotcounter
										RobotStack(RNN, RobotStackPos(RNN) - RobotStack(RNN, RobotStackPos(RNN)) - 1) = tempnumber 'Do the roll
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1 'Adjusts stack number because top operand has been removed
									Case insMIN 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) < RobotStack(RNN, RobotStackPos(RNN) - 1) Then RobotStack(RNN, RobotStackPos(RNN) - 1) = RobotStack(RNN, RobotStackPos(RNN))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insNOP 'Rep'
									Case insDIST 'Rep'     'Totally useless, it can be precalculated!
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(System.Math.Sqrt(RobotStack(RNN, RobotStackPos(RNN)) ^ 2 + RobotStack(RNN, RobotStackPos(RNN) - 1) ^ 2))
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insFLUSHINT 'Rep'
										RobotQuePos(RNN) = 0
									Case insXOR 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If (RobotStack(RNN, RobotStackPos(RNN)) <> 0) Xor (RobotStack(RNN, RobotStackPos(RNN) - 1) <> 0) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 1
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 0
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insARCSIN 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Asn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = 90 * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) * System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1))
										End If
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insARCCOS 'Rep'
										If RobotStackPos(RNN) < 2 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) <> RobotStack(RNN, RobotStackPos(RNN) - 1) Then
											RobotStack(RNN, RobotStackPos(RNN) - 1) = Fix(TPI * Acn(RobotStack(RNN, RobotStackPos(RNN)) / RobotStack(RNN, RobotStackPos(RNN) - 1)))
										Else
											RobotStack(RNN, RobotStackPos(RNN) - 1) = -180 * CShort(System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN))) <> System.Math.Sign(RobotStack(RNN, RobotStackPos(RNN) - 1)))
										End If
										
										RobotStackPos(RNN) = RobotStackPos(RNN) - 1
									Case insSQRT 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If RobotStack(RNN, RobotStackPos(RNN)) < 0 Then
											ErrorCode = BuggySquare : GoTo Buggy
										End If
										
										RobotStack(RNN, RobotStackPos(RNN)) = FixSquare(RobotStack(RNN, RobotStackPos(RNN)))
									Case insPRINT 'Rep'
										If RobotStackPos(RNN) < 1 Then
											ErrorCode = BuggyUnderflow : GoTo Buggy
										End If
										
										If Not RunningTournament Then
											tempnumber = MsgBox(RobotStack(RNN, RobotStackPos(RNN)) & vbCr & vbCr & "Would you like to stop the Battle?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Print " & GetRobot(RNN))
											If tempnumber = MsgBoxResult.Yes Then GoTo Peace
										End If
										ChrononExecutor1 = ChrononExecutor1 - 1
									Case Else
CodeError1: 
										ErrorCode = Err.Number
Buggy: 
										If RunningTournament Then
											tempnumber = MsgBoxResult.No
										ElseIf ErrorCode <= -200 Then 
											tempnumber = ShowErrorMessageParam(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), RobotStack(RNN, RobotStackPos(RNN)))
										Else
											tempnumber = ShowErrorMessage(ErrorCode, RNN, Chronon, ChrononExecutor1, RobotInstPos(RNN), MachineCode(RNN, RobotInstPos(RNN))) 'Response
										End If
										
										RobotAlive(RNN) = 255
										RScan(RNN) = 9999 'nytt
										If tempnumber = MsgBoxResult.Cancel Then GoTo Peace
										If tempnumber = MsgBoxResult.Yes Then
											SelectedRobot = RNN
											DraftingBoard.GotoInstNr = RobotInstPos(RNN) + 1
											VB6.ShowForm(DraftingBoard, 1, Me)
											EndBattleWhenGotoInst()
											Exit Sub
										End If
										If Err.Number = 0 Then Exit For Else Resume BackFromError
								End Select
							Next ChrononExecutor1
						End If 'Stunned if
					End If 'energyif
				End If 'RobotAlive(RNN) if
				
BackFromError: 
				If HighestToLowest Then RNN = 1 + NumberOfRobotsPresent - RNN 'Turns off backwards evaluation if it's enabled
			Next RNN 'Nästa robot loopen
			
			
			If RStunned(1) > 0 Then RStunned(1) = RStunned(1) - 1
			For RNN = 2 To NumberOfRobotsPresent
				If RStunned(RNN) > 0 Then RStunned(RNN) = RStunned(RNN) - 1
			Next RNN
			
			' Avläsningen av koden ALLMÄNT(SLUTET)
			
			'Shot Manager
			
			NotAnyShotsAtAll = True
			
			For shotcounter = 1 To ShotNumber
				'errorcode = "ShotCounter = " & ShotCounter & Chr(10) & "ShotNumber = " & ShotNumber & Chr(10) & Chr(10) & "FireTime = " & Shot(ShotCounter).ShotFireTime & Chr(10) & "X = " & Shot(ShotCounter).ShotX & Chr(10) & "Y = " & Shot(ShotCounter).ShotY & Chr(10) & "Damage = " & Shot(ShotCounter).ShotPower & Chr(10) & Chr(10) & "FreeShot = " & FreeShot
				'Response = MsgBox(errorcode, vbOKCancel, "Debug")
				'If Response = vbCancel Then GoTo Peace
				
				'Fillstyle är som standard = 0. Om det måste ändras måste den sättas tillbaka sen
				
				Select Case shot(shotcounter).ShotType
					Case 200
						FreeShot = shotcounter
						'Disables some redims. Might speed up?
						
					Case Missile
						NotAnyShotsAtAll = False
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + Sin5(shot(shotcounter).ShotAngle)
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - Cos5(shot(shotcounter).ShotAngle)
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then 'BUG ALERT!!! Skall syncas!!!
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 1 'Which robot is hit?
								LastHiter(1) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 2 'Which robot is hit?
								LastHiter(2) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 3 'Which robot is hit?
								LastHiter(3) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 4 'Which robot is hit?
								LastHiter(4) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 5 'Which robot is hit?
								LastHiter(5) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 6 'Which robot is hit?
								LastHiter(6) = shot(shotcounter).Shooter
							End If
						End If
						
					Case Hellbore
						NotAnyShotsAtAll = False
						trigx = shot(shotcounter).ShotPower * Sine(shot(shotcounter).ShotAngle)
						trigy = shot(shotcounter).ShotPower * Cosine(shot(shotcounter).ShotAngle)
						
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy
						
						trigx = shot(shotcounter).ShotX - trigx / 2
						trigy = shot(shotcounter).ShotY + trigy / 2
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then 'HELLBORE!!!
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or (trigx - RobotLeft(1)) * (trigx - RobotLeft(1)) + (trigy - RobotTop(1)) * (trigy - RobotTop(1)) < 100 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 1000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or (trigx - RobotLeft(2)) * (trigx - RobotLeft(2)) + (trigy - RobotTop(2)) * (trigy - RobotTop(2)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 2000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or (trigx - RobotLeft(3)) * (trigx - RobotLeft(3)) + (trigy - RobotTop(3)) * (trigy - RobotTop(3)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 3000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or (trigx - RobotLeft(4)) * (trigx - RobotLeft(4)) + (trigy - RobotTop(4)) * (trigy - RobotTop(4)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 4000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or (trigx - RobotLeft(5)) * (trigx - RobotLeft(5)) + (trigy - RobotTop(5)) * (trigy - RobotTop(5)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 5000 'Which robot is hit? *1000 for hellbore
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or (trigx - RobotLeft(6)) * (trigx - RobotLeft(6)) + (trigy - RobotTop(6)) * (trigy - RobotTop(6)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 6000 'Which robot is hit? *1000 for hellbore
							End If 'HELLBORE!!!
						End If
						
					Case Stunner
						NotAnyShotsAtAll = False
						trigx = Sin14(shot(shotcounter).ShotAngle)
						trigy = Cos14(shot(shotcounter).ShotAngle)
						
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy
						
						trigx = shot(shotcounter).ShotX - trigx
						trigy = trigy + shot(shotcounter).ShotY
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then 'STUNNER!!!
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 51 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 100 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 200 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 300 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 400 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 500 'Which robot is hit? *100 for stunners
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 51 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 600 'Which robot is hit? *100 for stunners
							End If 'STUNNER!!!
						End If
						
					Case XplosiveBulletDetonation
ExplosiveBullets: 
						NotAnyShotsAtAll = False
						If Chronon - shot(shotcounter).ShotFireTime >= 4 Then '10
							shot(shotcounter).ShotType = NOSHOT
							
							For RNN = 1 To NumberOfRobotsPresent
								If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 2025 Then '45*45?????
									RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN)) : RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
									LastHiter(RNN) = shot(shotcounter).Shooter
								End If
							Next RNN
							
							If DroneShotDown Then
								For RNN = 1 To ShotNumber
									If shot(RNN).ShotType = Drone Then
										If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 2025 Then shot(RNN).ShotType = NOSHOT
									End If
								Next RNN
							End If
						End If
						
					Case TakeNuke
						'OldStyleExplosiveBullets:
						NotAnyShotsAtAll = False
						
						If Chronon - shot(shotcounter).ShotFireTime >= 10 Then '10
							shot(shotcounter).ShotType = NOSHOT
							
							For RNN = 1 To NumberOfRobotsPresent '1020
								If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
									RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - 2 * shot(shotcounter).ShotPower + RShield(RNN)) : RShield(RNN) = ZeroOrMore(RShield(RNN) - 2 * shot(shotcounter).ShotPower)
									LastHiter(RNN) = shot(shotcounter).Shooter
								End If
							Next RNN
							
							If DroneShotDown Then
								For RNN = 1 To ShotNumber
									If shot(RNN).ShotType = Drone Then
										If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then shot(RNN).ShotType = NOSHOT
									End If
								Next RNN
							End If
						End If
						
					Case MegaNuke
						'OldStyleExplosiveBullets:
						NotAnyShotsAtAll = False
						
						If Chronon - shot(shotcounter).ShotFireTime >= MegaNukeBLASTRADIUS Then '10
							shot(shotcounter).ShotType = NOSHOT
							
							For RNN = 1 To NumberOfRobotsPresent '1020
								If (shot(shotcounter).ShotX - RobotLeft(RNN)) * (shot(shotcounter).ShotX - RobotLeft(RNN)) + (shot(shotcounter).ShotY - RobotTop(RNN)) * (shot(shotcounter).ShotY - RobotTop(RNN)) < 3600 Then
									RDamage(RNN) = Min(RDamage(RNN), RDamage(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower + RShield(RNN)) : RShield(RNN) = ZeroOrMore(RShield(RNN) - MegaNukePOWER * shot(shotcounter).ShotPower)
									LastHiter(RNN) = shot(shotcounter).Shooter
								End If
							Next RNN
							
							If DroneShotDown Then
								For RNN = 1 To ShotNumber
									If shot(RNN).ShotType = Drone Then
										If (shot(shotcounter).ShotX - shot(RNN).ShotX) * (shot(shotcounter).ShotX - shot(RNN).ShotX) + (shot(shotcounter).ShotY - shot(RNN).ShotY) * (shot(shotcounter).ShotY - shot(RNN).ShotY) < 3600 Then shot(RNN).ShotType = NOSHOT
									End If
								Next RNN
							End If
						End If
						
					Case Mine 'Minor skall ge damage 1 chronon efter
						NotAnyShotsAtAll = False
						
						If Chronon - shot(shotcounter).ShotFireTime >= 10 Then
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Then
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 1 'Which robot is hit?
								LastHiter(1) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 2 'Which robot is hit?
								LastHiter(2) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 3 'Which robot is hit?
								LastHiter(3) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 4 'Which robot is hit?
								LastHiter(4) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 5 'Which robot is hit?
								LastHiter(5) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Then 
								shot(shotcounter).ShotType = SHOTHIT 'Make the shot into a hit
								shot(shotcounter).ShotAngle = 6 'Which robot is hit?
								LastHiter(6) = shot(shotcounter).Shooter
							End If
						End If
						
					Case Drone
						NotAnyShotsAtAll = False
						
						If RobotAlive(shot(shotcounter).ShotAngle) = 1 And Chronon <= shot(shotcounter).ShotFireTime Then
							'Checks drone shotdown
							For tempnumber = 0 To ShotNumber 'This is still extremly buggy
								'If Shot(TempNumber).ShotType = Missile Or Shot(TempNumber).ShotType = Hellbore Or Shot(TempNumber).ShotType = Bullet Or Shot(TempNumber).ShotType = ExplosiveBullet Then
								If shot(tempnumber).ShotType < 4 Then
									If (shot(tempnumber).ShotX - shot(shotcounter).ShotX) * (shot(tempnumber).ShotX - shot(shotcounter).ShotX) + (shot(tempnumber).ShotY - shot(shotcounter).ShotY) * (shot(tempnumber).ShotY - shot(shotcounter).ShotY) < 50 Then
										shot(tempnumber).ShotType = NOSHOT
										shot(shotcounter).ShotType = NOSHOT
										'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
										GoTo dontrundronecode
									End If
								End If
							Next tempnumber
							''***************************'Nytt försök med drones     'Succé!! Yay!!
							'            'moves te drone towards the tracking robot moves and paints the drone
							'LÄGG TILL IIF, DET KANSKE GÅR SNABBARE
							If System.Math.Abs(shot(shotcounter).ShotY - RobotTop(shot(shotcounter).ShotAngle)) <= 8 Then '2 '8
								If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
									shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2
								Else
									shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2
								End If
							ElseIf System.Math.Abs(shot(shotcounter).ShotX - RobotLeft(shot(shotcounter).ShotAngle)) <= 8 Then  '2 '8
								If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then
									shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2
								Else
									shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2
								End If
							Else
								If shot(shotcounter).ShotX < RobotLeft(shot(shotcounter).ShotAngle) Then
									shot(shotcounter).ShotX = shot(shotcounter).ShotX + 2 '1.41421356237 '2*cos 45 = 2*sin 45 = 1.41421356237
								Else
									shot(shotcounter).ShotX = shot(shotcounter).ShotX - 2 '1.41421356237
								End If
								If shot(shotcounter).ShotY < RobotTop(shot(shotcounter).ShotAngle) Then
									shot(shotcounter).ShotY = shot(shotcounter).ShotY + 2 '1.41421356237
								Else
									shot(shotcounter).ShotY = shot(shotcounter).ShotY - 2 '1.41421356237
								End If
							End If
							''            end paint and move
							'Checks hit
							For tempnumber = 1 To NumberOfRobotsPresent 'Undre raden fungerar men är insparad pga 64 K
								If (shot(shotcounter).ShotX - RobotLeft(tempnumber)) * (shot(shotcounter).ShotX - RobotLeft(tempnumber)) + (shot(shotcounter).ShotY - RobotTop(tempnumber)) * (shot(shotcounter).ShotY - RobotTop(tempnumber)) < 100 Then
									shot(shotcounter).ShotType = SHOTHIT
									shot(shotcounter).ShotAngle = tempnumber 'Which robot is hit?
									'If PlaySounds Then sndPlaySound App.path & "\miscdata\shothit.wav", SND_ASYNC Or SND_NODEFAULT
									LastHiter(tempnumber) = shot(shotcounter).Shooter
								End If
							Next tempnumber
						Else
							shot(shotcounter).ShotType = NOSHOT 'destroy drone
						End If
dontrundronecode: 
					Case Laser
						NotAnyShotsAtAll = False
						shot(shotcounter).ShotType = SHOTHIT
						LastHiter(shot(shotcounter).ShotAngle) = shot(shotcounter).Shooter
						
					Case SHOTHIT 'ShotHit
						If shot(shotcounter).ShotAngle < 100 Then 'Regular
							RShield(shot(shotcounter).ShotAngle) = RShield(shot(shotcounter).ShotAngle) - shot(shotcounter).ShotPower
							If RShield(shot(shotcounter).ShotAngle) < 0 Then 'If Shield still is above 0 the shot only hit the shield
								RDamage(shot(shotcounter).ShotAngle) = RDamage(shot(shotcounter).ShotAngle) + RShield(shot(shotcounter).ShotAngle)
								RShield(shot(shotcounter).ShotAngle) = 0
							End If
						ElseIf shot(shotcounter).ShotAngle < 1000 Then  'Stunner
							RStunned(shot(shotcounter).ShotAngle \ 100) = RStunned(shot(shotcounter).ShotAngle \ 100) + shot(shotcounter).ShotPower
						Else 'Hellbore
							RShield(shot(shotcounter).ShotAngle \ 1000) = 0
						End If
						shot(shotcounter).ShotType = NOSHOT
						
					Case Else
						NotAnyShotsAtAll = False
						trigx = Sin12(shot(shotcounter).ShotAngle)
						trigy = Cos12(shot(shotcounter).ShotAngle)
						
						shot(shotcounter).ShotX = shot(shotcounter).ShotX + trigx
						shot(shotcounter).ShotY = shot(shotcounter).ShotY - trigy
						
						trigy = trigy + shot(shotcounter).ShotY
						trigx = shot(shotcounter).ShotX - trigx
						
						If shot(shotcounter).ShotX < 0 Or shot(shotcounter).ShotX > 300 Or shot(shotcounter).ShotY < 0 Or shot(shotcounter).ShotY > 300 Then
							shot(shotcounter).ShotType = NOSHOT
						Else
							If (shot(shotcounter).ShotX - RobotLeft(1)) * (shot(shotcounter).ShotX - RobotLeft(1)) + (shot(shotcounter).ShotY - RobotTop(1)) * (shot(shotcounter).ShotY - RobotTop(1)) < 100 Or (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(1)) * (trigy - RobotTop(1)) + (shot(shotcounter).ShotX - RobotLeft(1)) * (trigx - RobotLeft(1)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									'                    Shot(ShotCounter).ShotType = TakeNuke      'Old fashion Explosive Bullets
									'                    GoTo OldStyleExplosiveBullets                      'Do not erase
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 1 'Which robot is hit?
								LastHiter(1) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(2)) * (shot(shotcounter).ShotX - RobotLeft(2)) + (shot(shotcounter).ShotY - RobotTop(2)) * (shot(shotcounter).ShotY - RobotTop(2)) < 100 Or (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then 
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(2)) * (trigy - RobotTop(2)) + (shot(shotcounter).ShotX - RobotLeft(2)) * (trigx - RobotLeft(2)) < 64 Then
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 2 'Which robot is hit?
								LastHiter(2) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(3)) * (shot(shotcounter).ShotX - RobotLeft(3)) + (shot(shotcounter).ShotY - RobotTop(3)) * (shot(shotcounter).ShotY - RobotTop(3)) < 100 Or (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then 
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(3)) * (trigy - RobotTop(3)) + (shot(shotcounter).ShotX - RobotLeft(3)) * (trigx - RobotLeft(3)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 3 'Which robot is hit?
								LastHiter(3) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(4)) * (shot(shotcounter).ShotX - RobotLeft(4)) + (shot(shotcounter).ShotY - RobotTop(4)) * (shot(shotcounter).ShotY - RobotTop(4)) < 100 Or (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then 
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(4)) * (trigy - RobotTop(4)) + (shot(shotcounter).ShotX - RobotLeft(4)) * (trigx - RobotLeft(4)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 4 'Which robot is hit?
								LastHiter(4) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(5)) * (shot(shotcounter).ShotX - RobotLeft(5)) + (shot(shotcounter).ShotY - RobotTop(5)) * (shot(shotcounter).ShotY - RobotTop(5)) < 100 Or (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then 
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(5)) * (trigy - RobotTop(5)) + (shot(shotcounter).ShotX - RobotLeft(5)) * (trigx - RobotLeft(5)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 5 'Which robot is hit?
								LastHiter(5) = shot(shotcounter).Shooter
							ElseIf (shot(shotcounter).ShotX - RobotLeft(6)) * (shot(shotcounter).ShotX - RobotLeft(6)) + (shot(shotcounter).ShotY - RobotTop(6)) * (shot(shotcounter).ShotY - RobotTop(6)) < 100 Or (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then 
								
								If shot(shotcounter).ShotType = ExplosiveBullet Then
									If (shot(shotcounter).ShotY - RobotTop(6)) * (trigy - RobotTop(6)) + (shot(shotcounter).ShotX - RobotLeft(6)) * (trigx - RobotLeft(6)) < 64 Then 'If we hit him on the half position it must explose on the half position like it does in the Mac version
										shot(shotcounter).ShotX = shot(shotcounter).ShotX - Sin6(shot(shotcounter).ShotAngle) : shot(shotcounter).ShotY = shot(shotcounter).ShotY + Cos6(shot(shotcounter).ShotAngle)
									End If
									shot(shotcounter).ShotFireTime = Chronon
									shot(shotcounter).ShotType = XplosiveBulletDetonation
									GoTo ExplosiveBullets
								End If
								
								shot(shotcounter).ShotType = SHOTHIT
								shot(shotcounter).ShotAngle = 6 'Which robot is hit?
								LastHiter(6) = shot(shotcounter).Shooter
							End If
						End If
				End Select
				
			Next shotcounter
			
			If NotAnyShotsAtAll Then
				ShotNumber = 0
				FreeShot = -1
			End If
			
			
			If RobotAlive(1) = 1 Then
				If RDamage(1) <= 0 Then 'Checks if the robots have any damage left.
RunDeath1: 
					RobotAlive(1) = 0 'If the robot just died we set RobotAlive to 255 (means it died this chronon).
					RobotLeft(1) = -50
					RobotTop(1) = 150
					EnergyDisplay(1).Visible = False
					
					If REnergy(1) < -200 And EnableOverloading Then 'BUG ALERT!! BUG ALERT!! Skillnad i overloading mot den jävla Mac versionen: dels så sker skälva "döden" 1 chronon senare i
						RobotDead(1).Text = "Overloaded - Time: " & Chronon
						tempnumber = -2 '3 * CInt(Not StandardScoring)
						LastHiter(1) = 253
					ElseIf RScan(1) = 9999 Then 
						RobotDead(1).Text = "Buggy - Time: " & Chronon
						tempnumber = -1 '2 * CInt(Not StandardScoring)
						LastHiter(1) = 254
					Else
						RobotDead(1).Text = "Dead - Time: " & Chronon 'Windows (vet inte om det har nån betydelse?), dels så slutar striden inte mindre än 2 chronon senare senare i Windows (om Mac scoring används)
						If (RCollision(1) = 0 Or RDamage(1) + 1 <= 0) And (RWall(1) = 0 Or RDamage(1) + 5 <= 0) And LastHiter(1) <> 1 And RLook(LastHiter(1)) <> 9999 And (RobotTeam(1) = 0 Or (RobotTeam(1) <> RobotTeam(LastHiter(1)))) Then
							KR(LastHiter(1)) = KR(LastHiter(1)) + 1 'Also prevents robots from getting kill score for killing itself
						Else
							LastHiter(1) = 255 'Records that the robot died from a Wall Collision, Collision or suicided (for 4.5.2)
						End If
						tempnumber = 0 'CInt(Not StandardScoring)
					End If
					
					If Not RunningTournament Then
						RobotDead(1).Visible = True
						System.Windows.Forms.Application.DoEvents() 'For the Nextevents optimization
					End If
					
					HowManyLeft = HowManyLeft - 1
					
					'Robots Int
					For shotcounter = 1 To NumberOfRobotsPresent
						If RobotsInst(shotcounter) >= 0 And HowManyLeft < RobotsParam(shotcounter) Then
							RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
							RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = RobotsInst(shotcounter)
							IntID(shotcounter, RobotQuePos(shotcounter)) = 9
						End If
					Next shotcounter
					
					'Teammates Int
					RRadar = 0 'Calculates how many teammates there is left
					For shotcounter = 1 To NumberOfRobotsPresent 'If a robot is in the same team that the robot who just died + it's alive it's a living teammate
						If RobotTeam(shotcounter) = RobotTeam(1) And RobotAlive(shotcounter) = 1 Then RRadar = RRadar + 1
					Next shotcounter
					
					For shotcounter = 1 To NumberOfRobotsPresent
						If RobotTeam(shotcounter) = RobotTeam(1) Then 'If they're not in the same team we can ignore the teammates int
							If TeammatesInst(shotcounter) >= 0 Then 'If it uses the teammates inst
								If RRadar < TeammatesParam(shotcounter) Then 'If the teammates in the team no is below teammatesparam
									RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
									RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = TeammatesInst(shotcounter)
									IntID(shotcounter, RobotQuePos(shotcounter)) = 10
								End If
							End If
						End If
					Next shotcounter
					
					If RRadar = 0 Then HowManyLeft = 0
					
					'End Team Stuff
					
					If HowManyLeft <= 1 Then 'If there's one or less than one robot left the battle should be stopped
						MaxChronon = Chronon + 20 + tempnumber * CShort(Not StandardScoring)
						HowManyLeft = 255 'If the solitare robot should die we prevent the battle from going on an additional 20 chronons this way
					End If
					
					REnergy(1) = -10 'To prevent false dopplering
				End If
			ElseIf RobotAlive(1) = 255 Then 
				GoTo RunDeath1
			End If
			
			RCollision(1) = 0 'Resets collision to zero before the collision loop
			
			'*DEATH. This is the loop that checks for Robots death, and handles kill scoring.
			For RNN = 2 To NumberOfRobotsPresent 'To increase battle speed, it's a lot different than the one displayed battle is using.
				If RobotAlive(RNN) = 1 Then
					If RDamage(RNN) <= 0 Then 'Checks if the robots have any damage left.
RunDeath: 
						RobotAlive(RNN) = 0 'If the robot just died we set RobotAlive to 255 (means it died this chronon).
						RobotLeft(RNN) = -50
						RobotTop(RNN) = 150
						EnergyDisplay(RNN).Visible = False
						
						If REnergy(RNN) < -200 And EnableOverloading Then 'BUG ALERT!! BUG ALERT!! Skillnad i overloading mot den jävla Mac versionen: dels så sker skälva "döden" 1 chronon senare i
							RobotDead(RNN).Text = "Overloaded - Time: " & Chronon
							tempnumber = -2 '3 * CInt(Not StandardScoring)
							LastHiter(RNN) = 253
						ElseIf RScan(RNN) = 9999 Then 
							RobotDead(RNN).Text = "Buggy - Time: " & Chronon
							tempnumber = -1 '2 * CInt(Not StandardScoring)
							LastHiter(RNN) = 254
						Else
							RobotDead(RNN).Text = "Dead - Time: " & Chronon 'Windows (vet inte om det har nån betydelse?), dels så slutar striden inte mindre än 2 chronon senare senare i Windows (om Mac scoring används)
							If (RCollision(RNN) = 0 Or RDamage(RNN) + 1 <= 0) And (RWall(RNN) = 0 Or RDamage(RNN) + 5 <= 0) And LastHiter(RNN) <> RNN And RLook(LastHiter(RNN)) <> 9999 And (RobotTeam(RNN) = 0 Or (RobotTeam(RNN) <> RobotTeam(LastHiter(RNN)))) Then
								KR(LastHiter(RNN)) = KR(LastHiter(RNN)) + 1 'Also prevents robots from getting kill score for killing itself
							Else
								LastHiter(RNN) = 255 'Records that the robot died from a Wall Collision, Collision or suicided (for 4.5.2)
							End If
							tempnumber = 0 'CInt(Not StandardScoring)
						End If
						
						If Not RunningTournament Then
							RobotDead(RNN).Visible = True
							System.Windows.Forms.Application.DoEvents() 'For the Nextevents optimization
						End If
						
						HowManyLeft = HowManyLeft - 1
						
						'Robots Int
						For shotcounter = 1 To NumberOfRobotsPresent
							If RobotsInst(shotcounter) >= 0 And HowManyLeft < RobotsParam(shotcounter) Then
								RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
								RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = RobotsInst(shotcounter)
								IntID(shotcounter, RobotQuePos(shotcounter)) = 9
							End If
						Next shotcounter
						
						'Teammates Int
						RRadar = 0 'Calculates how many teammates there is left
						For shotcounter = 1 To NumberOfRobotsPresent 'If a robot is in the same team that the robot who just died + it's alive it's a living teammate
							If RobotTeam(shotcounter) = RobotTeam(RNN) And RobotAlive(shotcounter) = 1 Then RRadar = RRadar + 1
						Next shotcounter
						
						For shotcounter = 1 To NumberOfRobotsPresent
							If RobotTeam(shotcounter) = RobotTeam(RNN) Then 'If they're not in the same team we can ignore the teammates int
								If TeammatesInst(shotcounter) >= 0 Then 'If it uses the teammates inst
									If RRadar < TeammatesParam(shotcounter) Then 'If the teammates in the team no is below teammatesparam
										RobotQuePos(shotcounter) = RobotQuePos(shotcounter) + 1
										RobotIntQue(shotcounter, RobotQuePos(shotcounter)) = TeammatesInst(shotcounter)
										IntID(shotcounter, RobotQuePos(shotcounter)) = 10
									End If
								End If
							End If
						Next shotcounter
						
						If RRadar = 0 Then HowManyLeft = 0
						
						'End Team Stuff
						
						If HowManyLeft <= 1 Then 'If there's one or less than one robot left the battle should be stopped
							MaxChronon = Chronon + 20 + tempnumber * CShort(Not StandardScoring)
							HowManyLeft = 255 'If the solitare robot should die we prevent the battle from going on an additional 20 chronons this way
						End If
						
						REnergy(RNN) = -10 'To prevent false dopplering
					End If
				ElseIf RobotAlive(RNN) = 255 Then 
					GoTo RunDeath
				End If
				
				RCollision(RNN) = 0 'Resets collision to zero before the collision loop
			Next RNN
			
			If Chronon = NextEvents Then 'For the Nextevents optimization
				NextEvents = NextEvents + 167 'Just remove comments to enable
				'**************************doevent2**************************
				If PeekMessage(Message, 0, 0, 0, PM_NOREMOVE) Then 'checks for a message in the queue
					System.Windows.Forms.Application.DoEvents() 'dispatches any messages in the queue
				End If
				'************************************************************
			End If
			Chronon = Chronon + 1
		Loop 
		
		StartTime = VB.Timer() - StartTime
		If StartTime >= 1 Then 'We must have av least 1 sec of measuring otherwise the
			StartTime = Chronon / StartTime 'measuring will be very inaccurate
			CPRLabel.Text = VB6.Format(StartTime, "#")
		End If
		'#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*
		' Striden avslutas
Peace: 
		For RNN = 1 To NumberOfRobotsPresent 'Just so ER should correspond to energydisplay
			If Not Replaying Then
				BackupHistory((RNN))
				HistoryRec(RNN, 9) = RDamage(RNN) * CShort(RobotAlive(RNN) = 1)
			End If
		Next RNN
		
		KillPoints(LastHiter, RobotAlive)
		RewardPoints(RobotAlive(1), RobotAlive(2), RobotAlive(3), RobotAlive(4), RobotAlive(5), RobotAlive(6))
		EndBattle()
	End Sub
	
	
	
	
	
	
	Public Sub WelcomeWindowSwitchMenu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WelcomeWindowSwitchMenu.Click
		'Dim Val As Boolean
		'Val = Not WelcomeWindowSwitchMenu.Checked
		'
		'WelcomeWindowSwitchMenu.Checked = Val
		
		If WelcomeWindowSwitchMenu.Checked Then
			WelcomeWindowSwitchMenu.Checked = False
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, True, 7000) 'Correct
			WelcomeHelp.Close()
		Else
			WelcomeWindowSwitchMenu.Checked = True
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(7, False, 7000) 'Correct
			WelcomeHelp.Show()
		End If
	End Sub
End Class