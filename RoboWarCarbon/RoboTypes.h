/* Types.h */

#include "QuickTimeWrapper.h"

#ifndef __ROBOWAR_TYPES__
#define __ROBOWAR_TYPES__ (1)

/* This file declares all the types and constants used in RoboWar */

/* Resource IDs */

#define kRoboWarSignature ('RWAR')
#define kRoboWarDocumentType ('RobW')

#define kRoboWarBattleEvent ('doBE')

#define kArenaUserPaneID (1000)
#define kCampUserPaneID (1001)
#define kBattleButtonID (1002)
#define kChrononUserPaneID (1003)

#define kApplicationMenuID (1000)
#define kFileMenuID (1001)
#define kEditMenuID (1002)
#define kViewMenuID (1003)
#define kArenaMenuID (1004)
#define kTeamMenuID (131)
#define kDisplayMenuID (129)
#define kSpeedMenuID (128)

typedef enum {
	kFileNewMenuItemIndex = 1,
	kFileOpenMenuItemIndex,
	kFileDuplicateMenuItemIndex,
	kFileCloseMenuItemIndex = 5,
	kFileSaveAsMenuItemIndex,
	kFilePageSetupMenuItemIndex = 8,
	kFilePrintMenuItemIndex
} fileMenuItemIndex;

typedef enum {
	kEditUndoMenuItemIndex = 1,
	kEditRedoMenuItemIndex,
	kEditCutMenuItemIndex = 4,
	kEditCopyMenuItemIndex,
	kEditPasteMenuItemIndex,
	kEditDeleteMenuItemIndex,
	kEditSelectAllMenuItemIndex
} editMenuItemIndex;

typedef enum {
	kViewArenaMenuItemIndex = 1,
	kViewDraftingBoardMenuItemIndex = 3,
	kViewHardwareStoreMenuItemIndex,
	kViewIconFactoryMenuItemIndex,
	kViewRecordingStudioMenuItemIndex,
	kViewCompileMenuItemIndex = 8,
	kViewSetPasswordMenuItemIndex = 10
} viewMenuItemIndex;

typedef enum {
	kArenaTeamMenuItemIndex = 1,
	kArenaUseDebuggerMenuItemIndex,
	kArenaDontPlaySoundMenuItemIndex = 4,
	kArenaDisplayMenuItemIndex,
	kArenaSpeedMenuItemIndex,
	kArenaHistoryMenuItemIndex,
	kArenaSetMaxPointsMenuItemIndex,
	kArenaTournamentMenuItemIndex = 10
} areaMenuItemIndex;

typedef enum {
	GunSndID = 0,			/* Sound of Gun -- was 1000*/
	MissileSndID,			/* Sound of Missile */
	BangSndID,				/* Sound of exploding TacNuke, Bullet, or Mine */
	LaserSndID,				/* Sound of Laser */
	HellSndID,				/* Sound of Hellbore */
	MineSndID,				/* Sound of Mine begin laid */
	DroneSndID,				/* Sound of Drone */
	ExplosionSndID,			/* Sound of robot exploding */
	CollisionSndID,			/* Sound of robot colliding */
	ShotHitSndID,			/* Sound of weapon hitting robot */
} builtInSoundIDtype;

#define SoundID			2000			/* Custom sounds on Robots */
#define DeathSnd		0
#define	CollisionSnd	1
#define ShieldHitSnd	2
#define HitSnd			3

#define susieIcon		259 			/* Icon for undocumented feature */
#define bugIcon			260
#define playIcon		261				/* Icons for Recording Studio */
#define recordIcon		262

#define softwareDateID	1000
#define hardwareDateID 	1001
#define asmDateID		1002
#define iconDateID		1003
#define recordingDateID	1004
#define codeLengthID	1000
#define robotCodeID		1000
#define hardwareInfoID	1000
#define	passwordID		1000
#define selectStartID	1000
#define selectEndID		1001
#define turretTypeID	1000

#define shieldlessID	1000

/* Interface Constants */

#define iconRowHeight 	36
#define iconLeftEdge	360

#define kIconCheckBoxesQty 5

//--- 19 apr 97 --- the rect for the color box.
#define		kColorBoxRect_left		310
#define		kColorBoxRect_right		340
#define		kColorBoxRect_top		210
#define		kColorBoxRect_bottom	240


/* Constants */

/* Development System Constants */

#define	draftingBoard	1
#define hardwareStore	2
#define arena			5
#define iconFactory		6
#define recordingStudio 4

#define radius			10				/* Radius of robot */
#define radiusSquared	100				/* radius * radius */
#define maxBots			6				/* Maximum number of bots in game */
#define boardSize		300				/* Size of arena */

#define progMaxSize		5000			/* The max size of the program */
#define maxNonCountingIntr 1000			// the max number of non-counting intructions ie icnX and sndX
#define libSize			400				/* The max size of the label lib */
#define labelBaseCode	30000
#define tokSize			100				/* The max size of a single token */
#define stackSize		100				/* Size of robot's internal stack */
#define historySize		50				/* Number of history registers */

//#define kDestHeight 	297				/* Pixels shown in Drafting Board vertically*/
#define viewHeight 		297				/* Pixels shown in Drafting Board vertically*/

#define numRadio 		23				/* Number of Radio buttons in Hardware store */
#define numCheck 		7				/* Number of check boxes in Hardware store */

#define maxChannels		6				/* Number of sound channels in Recording Studio */

#define radToDeg		57.2957795131  	/* 360/2¹ */

typedef enum {
	gun = 1,				/* Types of shots */
	missile,
	tacNuke,
	explode,
	bigExplode,
	hellBore,
	mine,
	newMine,
	drone,
	laser,
	stunner
} shotType;

typedef enum {
	lineTurret = 1,
	dotTurret,
	noTurret
} turretType;

typedef enum {
	kDuelBattle = 1,
	kGroupBattle,
	kTeamBattle
} battleType;

typedef enum {
	kRoboWarDisplayFast = 0,
	kRoboWarDisplayNormal,
	kRoboWarDisplaySlow,
	kRoboWarDisplaySlower,
	kRoboWarDisplaySlowest
} battleSpeed;

typedef enum {
	kRoboWarDrawArenaAndStats = 1,
	kRoboWarDrawStatsOnly,
	kRoboWarDrawNothing
} displayCode;

typedef enum {
	kRoboWarHistoryBattleCount = 0,
	kRoboWarHistoryKillsLastBattle,
	kRoboWarHistoryKillsTotal,
	kRoboWarHistorySurvivalPointsLastBattle,
	kRoboWarHistorySurvivalPointsTotal,
	kRoboWarHistoryTimedOutLastBattle,
	kRoboWarHistoryTeammatesAliveAtEndOfLastBattle,
	kRoboWarHistoryTeammatesAliveAtEndOfAllBattles,
	kRoboWarHistoryDamageRemainingAtEndOfLastBattle,
	kRoboWarHistoryChrononsLastBattle,
	kRoboWarHistoryChrononsTotal
} historyRegisterIndex;

typedef enum {
	kGenericIconTypeNULL = 0,
	kGenericIconTypeColor,
	kGenericIconTypeMono
} GenericIconType;

typedef enum {
	kGenericSoundTypeNULL = 0,
	kGenericSoundTypeResource,
	kGenericSoundTypeMovie
} GenericSoundType;

/* Types */

typedef unsigned char BYTE;

typedef struct {
	BYTE type;
	RgnHandle mask; // since B&W icons have no mask, and since previous versions ignored it...
	void * data; // the handle to the 'cicn' or 'ICON' resource
	
	// there should probably be am offscreen graphics buffer here too to
	// speed up display. but I'm to lazy to add that yet.
} GenericIcon;

typedef struct {
	BYTE type;
	void * data;
} GenericSound;

typedef struct library {
	char name[20];
	short code;
	short real;
	long  textPos;
} library;

typedef struct asmInfo {
	long 	length;			/* length of source code */
	short	codeLength;		/* length of object code */
	short	numIcons;		/* number of icons created */
	short	numSounds;		/* number of sounds created */
	long	softDate;		/* date of software changes */
	long	hardDate;		/* date of hardware changes */
	long	asmDate;		/* date of last assembly */
	long	iconDate;		/* date of last icon editing */
	long	recordingDate;	/* date of last sound recordings */
} asmInfo;

typedef	struct	hardwareInfo {
	short energyMax;			/* Maximum amount of energy */
	short damageMax;			/* Maximum amount of damage */
	short shieldMax;			/* Maximum shield level for normal discharge */
	short processorSpeed;	/* Instructions per chronon */
	short gunType;			/* 0 rubber, 1 normal, 2 explosive */
	short missileFlag;		/* 1 = has missiles */
	short tacNukeFlag;		/* 1 = has tacNukes */
	short advantages;		/* Number of points */
	short laserFlag;		/* 1 = lasers */
	short hellboreFlag;	/* 1 = hellbore */
	short droneFlag; 		/* 1 = drone */
	short mineFlag;		/* 1 = mine */
	short stunnerFlag;		/* 1 = stunner */
	short noNegEnergy;		/* 1 = No Negative energy */
	short probeFlag;		/* 1 = probes */
	short deathIconFlag;	/* 1 = use icon for death */
	short collisionIconFlag;	/* 1 = use icon for collision */
	short shieldHitIconFlag;	/* 1 = use icon for shield hit */
	short hitIconFlag;			/* 1 = use icon for hit */		
	short shieldOnIconFlag;	/* 1 = use icon for shieldon */
} hardwareInfo;
				
typedef struct interruptStruct {
	short proc;             /* Address of procedure to handle interrupt (-1 = none) */
	short param; 			/* Any parameter related to interrupt */
	short old;				/* Old value of condition being tested */
} intr;
				
typedef struct intqueueStruct {			/* Pending interrupts, in order of priority */
	BYTE numPending;
	BYTE collision;
	BYTE wall;
	BYTE damage;
	BYTE shield;
	BYTE top;
	BYTE bot;
	BYTE left;
	BYTE right;
	BYTE teammates;
	BYTE robots;
	BYTE signal;
} intqueue;

typedef struct robot {
	short 	number;					// Robot ID.
	short 	friend;
	BYTE 	alive;
	BYTE 	icon;
	short 	team;					/* Team number, 0 = no team */
	short 	stunned;				/* Number of chronons stunned, or 0 for functioning */
	short 	intmask;              	/* 1 = interrupts enabled */

	long	killTime[maxBots];		// Time which eacxh Robot Was Killed
	short 	kills;					/* Number of kills this robot has made */
	short 	svrl;					// Num Of servival Points this Bot has made
	short 	killer;					/* Robot which killed this robot (or -1) */
	short	hit;					/* 1 = shield hit, 2 = robot hit */
	short	haveDoneMoveOrShootQ;
	
	long 	deathTime;
	
	Str255 	name;					/* P-string */
	char 	password[20];			/* Robot's password */
	BYTE 	passwordEntered;		/* 1 = password has been correctly done */
	short 	*prog;
	short 	stack[stackSize+1];
	short 	progPtr;
	short 	stackPtr;
	short 	progSize;
	hardwareInfo hardware;
//	short 	vRefNum;				/* for file manager calls */
	FSSpec  fileSystemSpecification; //--- 6-28-04 -- for Carbon file and resourse manager calls
//	CGrafPtr gw[10];				/* graphic Worlds for robot icons*/ //--- 19 apr 97
	GenericIcon icons[10];			//--- 7-6-04 -- screw the graphics worlds.
	short 	turretType;				/* lineTurret, dotTurret, noTurret */
	GenericSound	sounds[10];
	
	short energy;
	short shield;
	short aim;
	short speedX;
	short speedY;
	short damage;
	short channel;
	short look;
	short scan;
	short collision;
	short wall;
	short letters[26];
	short vector[101];
	
	/* Parameters for probe and history registers */
	intqueue intq;				/* Queue of pending interrupts */
	intr collisionInt;			/* Procedure for collision interrupts */
	intr wallInt;				/* Procedure for wall interrupts */
	intr damageInt;				/* Procedure for damage interrupts */
	intr rangeInt;  	 		/* Procedure for range interrupts */
	intr radarInt;
	intr shieldInt;
	intr topInt;
	intr botInt;
	intr leftInt;
	intr rightInt;
	intr teammatesInt;
	intr robotsInt;
	intr signalInt;
	intr chrononInt;
	short probeParam;	
	short 	historyParam;
	short 	history[historySize]; /* History registers */
} robot;

typedef struct shot {
	double xPos;
	double yPos;
	short xPosInt;
	short yPosInt;
	double xAngle; 				/* Used as timer for TacNukes */
	double yAngle;
	BYTE type;
	BYTE gunType; 				
	short energy;
	//BYTE soundFlag;				/* Play sound if soundFlag is set */
	short owner;				/* Who shot this bullet? */
	struct shot *next;
} shot;
			   
typedef struct individualRoster {
	char name[80];
	short vRefNum;
	long soloScore;
	long groupScore;
	long numGroupFights;
	short winnerCircle;
	long soloFinal;
	long groupFinal;
} individualRoster;

typedef struct teamRoster {
	char name1[80];
	char name2[80];
	short vRefNum1;
	short vRefNum2;
	long score;
} teamRoster;

#endif