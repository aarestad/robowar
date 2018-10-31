/* ArenaControl.c */

/* 	Written 12/28/89
	(c) 1989 David Harris
	These routines handle the initialize, draw, and update
	commands for the arena.
*/

/* #includes */

#include <Carbon/Carbon.h>
#include "robotypes.h"
#include "Tokens.h"


/* External Globals */

extern	WindowPtr		myWindow;
extern	MenuHandle		myMenus[5];
extern	EventRecord		myEvent;
extern	GWorldPtr		bulletGW;		//<--- Changed!	//Bullet GWorlds...
extern	GWorldPtr		hellBoreGW;
extern	GWorldPtr		mineGW;
extern	GWorldPtr		newMineGW;
extern	GWorldPtr		droneGW[8];
extern  GWorldPtr		botGW[maxBots][2];//<--- Changed! --- Added ---
extern	RgnHandle		explosionMasks[8];
extern	ControlHandle	goButton;	
extern	ControlHandle	pauseButton;	
extern	ControlHandle	stepButton;
extern  ControlHandle	chrononButton;
extern	ControlHandle	battleButton;		
extern	short			controlChange;	
extern	short			mode;
extern	robot			rob[maxBots];
extern	short			numBots;			
extern  short			botSelected;
extern	macFeatures		features;
extern	short			isBattle;
extern 	short			isTournament;
//extern	short			displayCode;	/* 1 = Everything, 2 = only stats, 3 = nothing */
//extern 	short			soundFlag;
extern	short			oldSoundFlag;
//extern 	short			battleSpeed;
extern	short			useDebugger;
extern	short			pausedFlag;
extern  short			lowBitMapMemoryFlag;
extern	shot			*shots;
extern  Str255			noName;
extern	short			errorInstruction;

extern	short			gBattleType;

extern	short		(*invokeDistance)(robot*);
extern	short		(*invokeRadar)(robot*);
extern	short		(*invokeCheckHitTarget)(shot*);
extern	void		(*invokeTrackShots)(void);

extern prefStruct	gPrefs;				// preferences struct

/* Globals */

GWorldPtr	boardPix;				/* Pixel map of arena */
GDHandle	deepDeviceHdl;			/* Handle to deepest GDevice */

short		communications[3][10];		/* Channel & signal communications routes */
short		numAlive;					/* Number of robots remaining alive */
long		chronons;					/* Length of battle */
long		oldTime;					/* Time of last TickCount() call */
long		oldChronons;				/* chronon per sec was last updated */
//short		maxPoints;					/* Maximum number of advantages a robot can have */
extern unsigned short lastRandSeed;		/* Retain random seed to repeat battles */

/* Prototypes */

void initArena(void);
void closeArena(void);
void updateArena(void);
void setArenaFunctions(void);
void createBitMaps(void);
void doSoundFlag(void);
void doSetSpeed(short speed);
void doSetDisplay(short display);
void doSetMaxPoints(void);
void battle(short repeatFlag);
short checkCheating(short who);
short loadRobotCode(short who);
void loadRobots(void);
void prepareArena(void);
void prepareRobots(short repeatFlag);
void prepareBitMap(void);
void allocateColorBitMap(short bitDepth);
void drawBits(void);
void doSoundEffects(void);
char* itoa(short num);
void drawStats(void);
//--- Changed! ---
void SetUpColorIcon(GWorldPtr* gw, CIconHandle* cicn);
void SetUpBWIcon(GWorldPtr* gw, Handle* icon);
void DrawRobotPoints( short robPosID );
void UpdateRobotPoints( short robPosID );

/* in Arena.c */
extern void doCombat(void);

/* in Password.c */
extern short getPassword(char*);

/* in Debugger.c */
void drawDebuggerInfo(void);
extern void drawDebuggerBackground(void);

/* in Tournament.c */
extern void groupStart(short,short,short[]);
extern void groupEnd(short,short,short[]);
extern void recordResults(short,short);

/* in Util.c */
extern void reportMessage(char *message1,char *message2);
extern void drawRobot(short,short,short,short,short,RgnHandle,short);
extern void checkMemErr(char *proc);
extern void checkResErr(char *proc);
extern void installButtonOutline(DialogPtr theDialog,short itemNo);
extern void setVolume(short vRefNum);
extern void restoreVolume(void);
void playSound(short whichSound,short whichBot);

/* in HardwareStore.c */
void countAdvantages(hardwareInfo *hardware);
hardwareInfo getHardware(void);

/* Projectile.c */
extern short	distance(robot*);
extern short	radar(robot*);
extern short	checkHitTarget(shot*);
extern void		trackShots(void);

/* in Interrupts.c */
extern void initRobotInterrupts(robot *who);


/* Functions */

void initArena(void)
{	
	isBattle = 0;
	isTournament = 0;
	chronons = 0;
	controlChange = 1;
	HiliteControl(battleButton,255*(numBots < 1)); 
	InvalRect (&myWindow->portRect);
	drawBits();
}


//--- Updated for GWorlds
void closeArena(void)
{	
	isBattle = 0;
	/*if (!features.hasColorQD) {
		DisposePtr(boardBits.baseAddr);
		checkMemErr("ArenaControl:closeArena:1");
	}
	else {
		HUnlock((Handle)boardPix.portPixMap);
		checkMemErr("ArenaControl:closeArena:2");
		DisposePtr((*boardPix.portPixMap)->baseAddr);
		checkMemErr("ArenaControl:closeArena:3");
		ClosePort((GrafPtr)&boardPix);
	}*/
	DisposeGWorld(boardPix);
	checkMemErr("ArenaControl:closeArena");
	boardPix = NULL;
}

void updateArena(void)
{
	short i;
	Rect r,r1,r2;
	RgnHandle oldClip;
	Str255 msg = "\pTeam  ";
	Str255 msg1,msg2,msg3;
	BitMap bug;
	Handle icon;
	//Point p;
	
	if (isBattle && useDebugger != maxBots) drawDebuggerBackground();
	else {
		//r.top = 0; r.bottom = 300;
		//r.left = 0; r.right = 300;
		//BackColor(blackColor);
		//EraseRect(&r);
		r.top = 0; r.bottom = 300;
		r.left = 300; r.right = 500;
		BackColor(whiteColor);
		EraseRect(&r);
		TextFont (systemFont);
		TextSize (12);
		for (i=numBots; i<6; i++) {
			MoveTo(310,20+34*i);
			DrawString("\p<Not Selected>");
		}
		if (useDebugger != maxBots) {
			r1.top = 21+34*useDebugger;
			r1.left = 340+50*(rob[useDebugger].team != 0);
			r1.right = 372+50*(rob[useDebugger].team != 0);
			r1.bottom = 53+34*useDebugger;
			// - don't need to offset to global as we are drawing on the window.
			//p.h = 0; p.v = 0; LocalToGlobal(&p);
			//OffsetRect(&r1,p.h,p.v);
			r2.top = 0; r2.left = 0; r2.bottom = 32; r2.right = 32;
			icon = GetIcon(bugIcon);
			bug.baseAddr = *icon;
			bug.rowBytes = 4;
			bug.bounds = r2;
			// - What what what!!! Don't draw directly to screen you fool!
			//CopyBits(&bug,&qd.screenBits,&r2,&r1,srcOr,NULL);
			// - 1.4.99 Now we are going to draw to the window like we should...
			CopyBits(&bug,&myWindow->portBits,&r2,&r1,srcOr,NULL);
		}
		oldClip = NewRgn();
		GetClip(oldClip);
		for (i=0; i<numBots; i++) {		//draw robots loaded...
			//SetRect(&r, 303, 2+34*i, 335, 34+34*i);
			drawRobot(i,319,17+34*i,90,0,NULL,-1);	// y offset changed from 18 to 17
			r.left = 336; r.right = 428;
			r.top = 34*i; r.bottom = 35+34*i;
			ClipRect(&r);
			TextFont (systemFont);
			TextSize (12);
			MoveTo(336,18+34*i);
			DrawString(rob[i].name);
			SetClip(oldClip);
			TextFont (kFontIDMonaco);
			TextSize (9);
			if (rob[i].team) {
				MoveTo (336,29+34*i);
				msg[6] = rob[i].team+'0';
				DrawString (msg);
			}

			if (rob[i].alive) {
				NumToString(rob[i].energy, msg1 );
				NumToString(rob[i].damage, msg2 );
				MoveTo (430,12+34*i); DrawString("\pEnergy:");
				MoveTo (475,12+34*i); DrawString(msg1);
				MoveTo (430,21+34*i); DrawString("\pDamage:");
				MoveTo (475,21+34*i); DrawString(msg2);
			}
			else {
		 		MoveTo(430,12+34*i); 
		 		switch (rob[i].scan) {
	 				case 32000: DrawString ("\pBuggy"); break;
	 				case 32001: DrawString ("\pOverloaded"); break;
	 				default: 	 					
	 					if (rob[i].killer != -1) DrawString(rob[rob[i].killer].name);
	 					else DrawString("\p¥¥¥Dead¥¥¥");
	 					break;
	 			}
	 			NumToString( rob[i].deathTime, msg1);
	 			MoveTo (430,21+34*i); DrawString("\pTime: "); DrawString(msg1);
		 	}
		 	// --- Draw Current Robot Points ---
		 	DrawRobotPoints(i);
		}
		if (botSelected != maxBots && !isBattle) { /* Hilite selected bot */
			r.top = 34*botSelected; r.bottom = r.top + 34;
			r.left = 302; r.right = 500;
			InvertRect(&r);
			// turret type = 5 to show that no turret should be used and that the robot is selected
			drawRobot(botSelected,319,17+34*botSelected,90,0,NULL,5);
		}
		DisposeRgn(oldClip);
		checkMemErr("ArenaControl:updateArena");

	}
	TextFont (kFontIDMonaco);
	TextSize (9);
	NumToString(chronons, msg3);
	MoveTo (305,216); DrawString("\pChronons:");
	MoveTo (365,216); DrawString(msg3);
	MoveTo (405,216); DrawString("\pPer Sec:");
	if (controlChange) {
		controlChange = 0;
		ShowControl(battleButton);
	}
	drawBits();
}

void setArenaFunctions(void)
{
	if (0 /*features.hasCoprocessor*/) { /* disable 68881 code */
/*		invokeDistance = distance881;
		invokeRadar = radar881;
		invokeCheckHitTarget = checkHitTarget881;
		invokeTrackShots = trackShots881; */
	}
	else {
		invokeDistance = distance;
		invokeRadar = radar;
		invokeCheckHitTarget = checkHitTarget;
		invokeTrackShots = trackShots;
	}
}

void createBitMaps(void) // done
{
	CIconHandle	cicn;
	short i,shield;

	for (shield = 0; shield <2; shield++) 
		for (i=0; i<maxBots; i++) {
			cicn = GetCIcon(500 + i + (shield*6) );	//<--- Changed! --- Added ---
			checkResErr("ArenaControl:createBitMaps:1");
			SetUpColorIcon(&botGW[i][shield], &cicn);
			DisposeCIcon(cicn);
			checkMemErr("ArenaControl:createBitMaps:1");
		}
	for (i=0; i<8; i++) {
		explosionMasks[i] = NewRgn();
		OpenRgn();
		MoveTo (0,0);
		switch (i) {
			case 0:  LineTo (16,0); LineTo (16,16); break;
			case 1:  LineTo (0,16); LineTo (16,16); break;
			case 2:  LineTo (0,16); LineTo (-16,16); break;
			case 3:  LineTo (-16,0); LineTo (-16,16); break;
			case 4:  LineTo (-16,0); LineTo (-16,-16); break;
			case 5:	 LineTo (0,-16); LineTo (-16,-16); break;
			case 6:  LineTo (0,-16); LineTo (16,-16); break;
			case 7:  LineTo (16,0); LineTo (16,-16); break;
		}
		LineTo(0,0); 
		CloseRgn(explosionMasks[i]);
	}
	cicn = GetCIcon(600);
	checkResErr("ArenaControl:createBitMaps:2");
	SetUpColorIcon(&bulletGW, &cicn);
	DisposeCIcon(cicn);
	
	cicn = GetCIcon(601);
	checkResErr("ArenaControl:createBitMaps:3");
	SetUpColorIcon(&hellBoreGW, &cicn);
	DisposeCIcon(cicn);
	
	cicn = GetCIcon(602);
	checkResErr("ArenaControl:createBitMaps:4");
	SetUpColorIcon(&newMineGW, &cicn);
	DisposeCIcon(cicn);
	
	cicn = GetCIcon(603);
	checkResErr("ArenaControl:createBitMaps:5");
	SetUpColorIcon(&mineGW, &cicn);
	DisposeCIcon(cicn);
	
	for (i=0; i<8; i++) {
		cicn = GetCIcon(604+i);
		checkResErr("ArenaControl:createBitMaps:6");
		SetUpColorIcon(&droneGW[i], &cicn);
		DisposeCIcon(cicn);
	}
}

void doSoundFlag(void)
{	
	CheckItem(myMenus[4],sound_,gPrefs.soundFlag);
	gPrefs.soundFlag = !gPrefs.soundFlag;
	oldSoundFlag = gPrefs.soundFlag;
}

void doSetSpeed(short speed)
{
	CheckItem(myMenus[5],gPrefs.battleSpeed+1,0);
	CheckItem(myMenus[5],speed,1);
	gPrefs.battleSpeed = speed-1;
}

void doSetDisplay(short display)
{
	CheckItem(myMenus[6],gPrefs.displayCode,0);
	CheckItem(myMenus[6],display,1);
	gPrefs.displayCode = display;
}

void doSetMaxPoints(void)
{
	DialogPtr myDialog;
	short itemHit,itemType,newPts;
	Handle item;
	Rect box;
	Str255 pts;
	
	myDialog = GetNewDialog(PointsDlogID,NULL,(WindowPtr)-1);
	installButtonOutline(myDialog,3);
	//-sprintf((char*)pts,"%d",maxPoints);
	//-CtoPstr((char*)pts);
	NumToString( gPrefs.maxPoints, pts );
	ParamText(pts,noName,noName,noName);
	GetDialogItem(myDialog,6,&itemType,&item,&box);
	SetDialogItemText(item,pts);
	SelectDialogItemText(myDialog,6,0,32767);
	do {
		ModalDialog(NULL,&itemHit);
	} while (itemHit > 2);
	if (itemHit == 1) {
		GetDialogItemText(item,pts);
		PtoCstr(pts);
		sscanf((char*)pts,"%hd",&newPts);
		if (newPts >= 0 && newPts < 100) gPrefs.maxPoints = newPts;
		else SysBeep(1);
	}
	DisposeDialog(myDialog);
}

void battle(short repeatFlag) // -- done
{
	Rect r;
	short passwordGood;
	short ok;
	short i;
	
	prepareArena();
	prepareRobots(repeatFlag);
	
	// invalidate (and hense, redraw) the whole window
	r.top = 0; r.bottom = 220; r.left = 302; r.right = 500;
	InvalRect(&r);
	
	// don't let the user change the debugger settings during a battle
	DisableItem(myMenus[4],debugger_);
	
	// don't allow the user to debug a password-protected bot unless he's entered the password
	passwordGood = 1;
	if (useDebugger != maxBots) {
		controlChange = 1;
		pausedFlag = 1; // start the battle paused if we're debugging
		if (!rob[useDebugger].passwordEntered) {
			ok = getPassword(rob[useDebugger].password);
			if (!ok) {
				reportMessage ("Sorry, incorrect password.","");
				passwordGood = 0;
			}
			else rob[useDebugger].passwordEntered = 1;
		}
	}
	else pausedFlag = 0;
	
	// determine what type of battle this is
	gBattleType = 0;
	for( i = 0; i < numBots ; i++ )
	{
		if( rob[i].team != 0 )
		{
			i = numBots;
			gBattleType = kTeamBattle;
		}
	}
	if( (numBots > 2) && (gBattleType == 0) )
		gBattleType = kGroupBattle;
	else if( gBattleType == 0 )
		gBattleType = kDuelBattle;
	
	// start the battle
	if (passwordGood) doCombat();
	
	// clean up after the battle
	isBattle = 0;
	SetControlTitle(battleButton,"\pBattle \021B");
	HideControl(goButton);
	HideControl(pauseButton);
	HideControl(stepButton);
	HideControl(chrononButton);
	EnableItem(myMenus[4],debugger_);
}

short checkCheating(short who) // done
{
	short cheat = 0;
	short adv = 0,dis = 0;
	hardwareInfo info;
	
	countAdvantages(&rob[who].hardware);
	
	info=rob[who].hardware;
	
	switch(info.energyMax) {
		case 40:
		case 60:
		case 100:
		case 150: break;
		default: cheat++;
	}
	switch (info.damageMax) {
		case 30:
		case 60:
		case 100:
		case 150: break;
		default: cheat++;
	}
	switch (info.shieldMax) {
		case 0:
		case 25:
		case 50:
		case 100: break;
		default: cheat++;
	}
	switch (info.processorSpeed) {
		case 5:
		case 10:
		case 15:
		case 30:
		case 50: break; 
		default: cheat++;
	}
	switch (info.gunType) {
		case 1:
		case 2:
		case 3: break;
		default: cheat++;
	}
	if (info.advantages > gPrefs.maxPoints) cheat++;
	if (gPrefs.maxPoints == 99) cheat = 0;
	return cheat;	
}

short loadRobotCode(short who) // done
/* Needs the robot number and vName & vRefNum */
{
	short i;
	short **res1, **res2;
	Handle res;
	CIconHandle	cicn;
	short refNum,okFlag = 1;
	char msg[80],msg2[80];
	long loop,dist,test;
	short	**turret;
	
	rob[who].number = who;
	
	//RotateCursor(0);//--- Animate Cursor - 30/5/97
	
	/* Get Robot code & length */
	setVolume(rob[who].vRefNum);
	if ((refNum = OpenResFile(rob[who].name)) == -1) {
		
		//strcpy( msg, "Error opening robot " );
		//strAppend( msg, rob[who].name);
		//strAppend( msg, ".");
		
		sprintf(msg,"Error opening robot %s.",rob[who].name);
		
		//strcpy( msg, "Resource Error " );
		//NumToString( ResError(), (unsigned char*)(msg + 40) );
		//strAppend( msg, (char*)(msg + 21));
		//strAppend( msg, ".");
		
		sprintf(msg2,"Resource Error #%d.",ResError());
		reportMessage (msg,msg2);
		okFlag = 0;
	} 
	else {
		// --- Load Robot Code Length
		res1 = (short**)GetResource('RLEN',codeLengthID);
		if (res1 == NULL) rob[who].progSize = 0;
		else {
			rob[who].progSize = **res1;
			res2 = (short**)GetResource('RCOD',robotCodeID);
			if (res2 == NULL) {
				PtoCstr(rob[who].name);
				//strcpy( msg, "Error reading robot ");
				//strAppend( msg, rob[who].name );
				//strAppend( msg, "." );
				sprintf(msg,"Error reading robot %s.",rob[who].name);
				reportMessage(msg,"");
				okFlag = 0;
			}
		}
		
		// --- Load Robot Icon
		//--- 19 apr 97 --- the icon loading code has been re-written to get color icons.
		for (loop = 0; loop < 10; loop++) {					// for all possible 10 icons.
			cicn = GetCIcon(shieldlessID+loop);				// try to get a cicn.
			checkMemErr("ArenaControl:loadRobotCode:1");
			//RotateCursor(TickCount());//--- Animate Cursor - 30/5/97
			if( (cicn != nil) && !MemError()) {										// if cicn exists:
				SetUpColorIcon(&rob[who].gw[loop], &cicn);	// setup th robot icon as a color icon.
				DisposeCIcon(cicn);
			}
			else{											// otherwise get a ICON resource
				res = GetResource('ICON',shieldlessID+loop);
				checkMemErr("ArenaControl:loadRobotCode:2");
				if (res != nil) {									// if ICON exists:
					SetUpBWIcon(&rob[who].gw[loop], &res);	// Setup a monocrome icon.
					ReleaseResource(res);
				}
				else
					rob[who].gw[loop] = NULL;				// make sure we know that no icon exists.
			}
		}
		
		// --- Load Robot Sounds
		for (loop = 0; loop < 10; loop++) {
			//RotateCursor(TickCount());//--- Animate Cursor - 30/5/97
			res = GetResource('snd ',SoundID+loop);
			if (ResError() != noErr && ResError() != resNotFound) {
				SysBeep(1);
				rob[who].sounds[loop] = NULL;
			}
			else if (res != NULL) {
				rob[who].sounds[loop] = res;
				if (HandToHand(&rob[who].sounds[loop])) SysBeep(1);
				HPurge(rob[who].sounds[loop]);
				ReleaseResource(res);
			}
			else rob[who].sounds[loop] = NULL;
		}
		
		// --- Load Robot Program/Code
		rob[who].prog = (short*)NewPtr(rob[who].progSize*2);
		if (MemError()) okFlag = 0;
		checkMemErr("ArenaControl:loadRobotCode:3");
		for (i=0; i<rob[who].progSize; i++)
			rob[who].prog[i] = (*res2)[i];
		rob[who].hardware = getHardware();
		if (checkCheating(who)) {
			PtoCstr(rob[who].name);
			//strcpy( msg, "Too much hardware in ");
			//strAppend( msg, rob[who].name );
			//strAppend( msg, "." );
			sprintf (msg,"Too much hardware in %s",rob[who].name);
			reportMessage(msg,"(Use ÒArena: Set max pointsÓ.)");
			okFlag = 0;
		}
		// --- Load Robot Turret Type
		turret = (short**)GetResource ('TURT',turretTypeID);
		if (turret == NULL) rob[who].turretType = lineTurret;
		else rob[who].turretType = **turret;
		CloseResFile(refNum);
		checkResErr("ArenaControl:loadRobotCode");
	}
	restoreVolume();
	
	/* Set Attributes */
	rob[who].aim = 90;
	rob[who].alive = 1;
	rob[who].shield = 0;
	rob[who].icon = 0;
	rob[who].energy = rob[who].hardware.energyMax;
	rob[who].damage = rob[who].hardware.damageMax;
	rob[who].probeParam = damage_;
	rob[who].historyParam = 1;
	for (loop = 0; loop < who; loop++) 
		if (rob[loop].letters[x_] == 5000) {
			rob[loop].letters[y_] = -40;
			rob[loop].letters[x_] = -40;
		}
	do {
		rob[who].letters[x_] = rand()%(boardSize-30)+15;
		rob[who].letters[y_] = rand()%(boardSize-30)+15;
		dist = 1000;
		for (loop = 0; loop < who; loop++) {
			test = pow(rob[who].letters[x_]-rob[loop].letters[x_],2) +
				   pow(rob[who].letters[y_]-rob[loop].letters[y_],2);
			if (test < dist) dist = test;
		}
	} while (dist <625);
	
	//InitCursor();//--- Animate Cursor off - 30/5/97
	return okFlag;
}

void loadRobots(void)
{
	srand((unsigned short)TickCount());
	prepareBitMap();
}

void prepareArena(void) // -- done
{
	shot *cur;
	short i,j;
	
	errorInstruction = -1;
	isBattle = 1;
	chronons = 0;
	numAlive = numBots;
	if (shots != NULL) {
		cur = shots->next;
		do {
			DisposePtr((Ptr)shots);
			checkMemErr("ArenaControl:prepareArena");
			shots = cur;
			cur = shots->next;
		} while (shots != NULL);
	}
	SetControlTitle(battleButton,"\pHalt \021H");
	for (i=0; i<3; i++)
		for (j=0; j<10; j++)
			communications[i][j] = 0;
}

void prepareRobots(short repeatFlag) // -- done
{
	short who,i;
	short loop,dist,test;

	if (!repeatFlag)
		lastRandSeed += 1 + rand() + TickCount();
	srand(lastRandSeed);
	for (who=0; who<numBots; who++) {
		for (i=0; i<26; i++)
			rob[who].letters[i] = 0;
		for (i=0; i<101; i++)
			rob[who].vector[i] = 0;
		rob[who].number = who;
		rob[who].progPtr = 0;
		rob[who].stackPtr = 0;
		rob[who].energy = rob[who].hardware.energyMax;
		rob[who].damage = rob[who].hardware.damageMax;
		rob[who].aim = 90;
		rob[who].look = 0;
		rob[who].scan = 0;
		rob[who].speedX = 0;
		rob[who].speedY = 0;
		rob[who].alive = 1;
		rob[who].shield = 0;
		rob[who].channel = 1;
		rob[who].collision = 0;
		rob[who].wall = 0;
		rob[who].deathTime = -1;
		rob[who].icon = 0;
		rob[who].stunned = 0;
		rob[who].kills = 0;
		rob[who].svrl = 0;
		rob[who].killer = -1;
		rob[who].hit = 0;
		rob[who].probeParam = damage_;
		initRobotInterrupts(rob+who);
		do {
			rob[who].letters[x_] = rand()%(boardSize-30)+15;
			rob[who].letters[y_] = rand()%(boardSize-30)+15;
			dist = 1500;
			for (loop = 0; loop < who; loop++) {
				test = pow(rob[who].letters[x_]-rob[loop].letters[x_],2) +
					   pow(rob[who].letters[y_]-rob[loop].letters[y_],2);
				if (test < dist) dist = test;
			}
		} while (dist <1500); /* Insure that bots are far apart */
	}
}

//--- 19 apr 97 --- we are now using a graphic world.
void prepareBitMap(void)
{
	if (features.hasColorQD) {
		allocateColorBitMap(features.bitDepth);
		SetPort(myWindow); 
	}
	else {
		reportMessage("RoboWar will only work if your Mac has ColorQuickDraw.", 
			"You can only use RoboWar version 4.1.2 and older on this Mac.");
	}
}

//--- 19 apr 97 --- We now prepare a graphic world not a bitmap.
void allocateColorBitMap(short bitDepth)
{
	CGrafPtr origPort;
	GDHandle origDev;
	Rect r;
	Ptr reservedPtr;
	long offset,memAvail;
	QDErr	myErr;

	r.top = 0; r.bottom = 300;
	r.left = 0; r.right = 300;
	
	reservedPtr = NewPtr(10000); // save some memory for later use above pixmap
	checkMemErr("AreanaControl:allocateColorBitMap:1");
	memAvail = MaxMem(&offset); /* Save a bit of memory for a good cause */
	//if( bitDepth > 8 )
	//	bitDepth = 8;
	if (memAvail < 38L*300*bitDepth) {
		reportMessage("Please reduce number of colors","or increase RoboWar's memory.");
		bitDepth = 8;
		lowBitMapMemoryFlag = TRUE;
	}
	
	GetGWorld(&origPort, &origDev);
	if(!lowBitMapMemoryFlag){
		myErr = NewGWorld(&boardPix, bitDepth, &r, nil, nil, 0);
		checkMemErr("ArenaControl:allocateColorBitMap:2");	
		if(boardPix == nil || myErr !=noErr)
		{
			reportMessage("Graphics Problem-out of memory?", "ArenaControl:allocateColorBitMap:2.5");
			ExitToShell();
		}
	}
	DisposePtr(reservedPtr);  // return the memory for later use
	checkMemErr("AreanaControl:allocateColorBitMap:3");
	SetGWorld(origPort,origDev);
}

//--- 19 apr 97 --- we now copy an offscreen graphic world
void drawBits(void)
{
	register GDHandle oldDevice;
	Rect r,r2;
	short bitDepth,state;
	register short i,x,y;
	register shot *cur;
	register robot *theRob;
	
	r.top = 0; r.bottom = 300;
	r.left = 0; r.right = 300;
	
	oldDevice = GetGDevice();
	deepDeviceHdl = GetMainDevice();	// (&qd.screenBits.bounds);
	bitDepth = (*(*deepDeviceHdl)->gdPMap)->pixelSize;
	/*if (bitDepth > 8) bitDepth = 8;*/
	if ((bitDepth > (*boardPix->portPixMap)->pixelSize && !lowBitMapMemoryFlag) ||
		 bitDepth < (*boardPix->portPixMap)->pixelSize) {
		DisposeGWorld(boardPix);
		checkMemErr("ArenaControl:drawBits:1");
		boardPix = NULL;
		allocateColorBitMap(bitDepth);
	}
	SetGDevice(deepDeviceHdl);
	SetPort((GrafPtr)boardPix);
	//RGBBackColor(&selectedBackColor);
	EraseRect(&boardPix->portRect);
	//BackColor(whiteColor);
	
	/* Draw Shots */
	cur = shots;
	while (cur != NULL) {
		switch(cur->type) {	//--- 19 apr 97 --- Most weapons ae now stored in GWorlds, 
							// 					so copybits is used.
			case gun: r2.top = cur->yPosInt-2; r2.bottom = r2.top+8;
					  r2.left = cur->xPosInt-2; r2.right = r2.left+8;
					  CopyBits(&((GrafPtr)bulletGW)->portBits,&qd.thePort->portBits,
					  		   &bulletGW->portRect,&r2,transparent,NULL);
					  break;
			case missile:MoveTo ((short)cur->xPosInt,(short)cur->yPosInt);
						 LineTo ((short)(cur->xPosInt+cur->xAngle),
						 		 (short)(cur->yPosInt+cur->yAngle));
						 break;
			case tacNuke:
			case bigExplode: i = (short)cur->xAngle;
						  r2.top = cur->yPosInt-i; r2.bottom = cur->yPosInt+i;
						  r2.left = cur->xPosInt-i; r2.right = cur->xPosInt+i;
						  PenMode(patOr);
						  PenPat(&qd.gray);
						  PaintOval(&r2);
						  PenPat(&qd.black);
						  PenMode(patCopy);
						  break;
			case explode: r2.top = cur->yPosInt-5; r2.bottom = cur->yPosInt+5;
						  r2.left = cur->xPosInt-5; r2.right = cur->xPosInt+5;
						  PaintOval(&r2);
						  break;
			case hellBore: r2.top = cur->yPosInt-4; r2.bottom = cur->yPosInt+4;
					  r2.left = cur->xPosInt-4; r2.right = cur->xPosInt+4;
					  CopyBits(&((GrafPtr)hellBoreGW)->portBits,&qd.thePort->portBits,
					  		   &hellBoreGW->portRect,&r2,transparent,NULL);
					  break;
			case mine: r2.top = cur->yPosInt-4; r2.bottom = cur->yPosInt+4;
					  r2.left = cur->xPosInt-4; r2.right = cur->xPosInt+4;
					  CopyBits(&((GrafPtr)mineGW)->portBits,&qd.thePort->portBits,
					  		   &mineGW->portRect,&r2,transparent,NULL);
					  break;
			case drone: r2.top = cur->yPosInt-5; r2.bottom = cur->yPosInt+3;
					  r2.left = cur->xPosInt-5; r2.right = cur->xPosInt+3;
					  CopyBits(&((GrafPtr)droneGW[cur->gunType])->portBits,&qd.thePort->portBits,
					  		   &droneGW[cur->gunType]->portRect,&r2,transparent,NULL);
					  break;
			case laser: MoveTo ((short)cur->xPosInt,(short)cur->yPosInt);
						LineTo ((short)(cur->xAngle+cur->xPosInt)/2,
								(short)(cur->yAngle+cur->yPosInt)/2);
						PenPat(&qd.gray);
						LineTo ((short)cur->xAngle,(short)cur->yAngle);
						PenPat(&qd.black);
						break;
			case newMine: r2.top = cur->yPosInt-4; r2.bottom = cur->yPosInt+4;
					  r2.left = cur->xPosInt-4; r2.right = cur->xPosInt+4;
					  CopyBits(&((GrafPtr)newMineGW)->portBits,&qd.thePort->portBits,
					  		   &newMineGW->portRect,&r2,transparent,NULL);
					  break;
			case stunner:MoveTo ((short)cur->xPosInt-2,(short)cur->yPosInt-2);
						 LineTo ((short)cur->xPosInt+2,(short)cur->yPosInt+2);
						 MoveTo ((short)cur->xPosInt+2,(short)cur->yPosInt-2);
						 LineTo ((short)cur->xPosInt-2,(short)cur->yPosInt+2);
						 break;
			default: SysBeep(1); break;
		}
		cur = cur->next;
	}
	
	/* Draw Robots */
	for (i=0; i<numBots; i++) {
		theRob = rob+i; //set robot
		if (theRob->alive) { //bot is alive.
			x = theRob->letters[x_]; //SetX
			y = theRob->letters[y_]; //SetY
			drawRobot(i,x,y,theRob->aim,theRob->icon,NULL,rob[i].turretType); // i = which = which robot is being drawn
	 	}
	 	else if (theRob->aim) { // if bot is dead then draw Explosion.
	 		x = theRob->speedX;
	 		y = theRob->speedY;
	 		state = theRob->aim;
	 		drawRobot(i,x+2*state,y+state,0,theRob->icon,explosionMasks[0],0);
	 		drawRobot(i,x+state,y+2*state,0,theRob->icon,explosionMasks[1],0);
	 		drawRobot(i,x-state,y+2*state,0,theRob->icon,explosionMasks[2],0);
	 		drawRobot(i,x-2*state,y+state,0,theRob->icon,explosionMasks[3],0);
	 		drawRobot(i,x-2*state,y-state,0,theRob->icon,explosionMasks[4],0);
	 		drawRobot(i,x-state,y-2*state,0,theRob->icon,explosionMasks[5],0);
	 		drawRobot(i,x+state,y-2*state,0,theRob->icon,explosionMasks[6],0);
	 		drawRobot(i,x+2*state,y-state,0,theRob->icon,explosionMasks[7],0);
	 	}
	 }
		
	// the final copybits bord drawn to screen for Colour
		SetGDevice(oldDevice);
		SetPort(myWindow);
		CopyBits((BitMap*)&(*(*boardPix->portPixMap)),&myWindow->portBits,
				 &r,&r, 
				 srcCopy,NULL); 
}

void doSoundEffects(void)
{
	register shot *cur;
	
	/* Play sounds of launched weapons */
	cur = shots;
	while (cur != NULL) {
		if (cur->soundFlag) {
			switch(cur->type) {
				case gun: playSound(GunSndID,maxBots);
						  break;
				case missile: playSound(MissileSndID,maxBots);
							 break;
				case hellBore: playSound(HellSndID,maxBots);
						  break;
				case drone: playSound(DroneSndID,maxBots);
						  break;
				case laser: playSound(LaserSndID,maxBots);
							break;
				case newMine: playSound(MineSndID,maxBots);
						  break;
			}
			cur->soundFlag = 0;
		}
		cur = cur->next;
	}	

}


char* itoa(short num)
{
	char result[8];
	char c;
	short len = 0;
	short a,b,sign;

	if ((sign = num) < 0)
		num = -num;
	do {
		result[len++] = num % 10 + '0';
	} while ((num /= 10) > 0);
	if (sign < 0) result[len++] = '-';
	result[len] = 0;
	for (a = 0, b=len-1; a<b; a++,b--)
		c = result[a], result[a] = result[b], result[b] = c;
	return result;
}

// -------------------------------------------------------------------------------
void drawStats()
{
	register short i,j;
	Str255 msg1[maxBots],msg2[maxBots],msg3;
	Rect r;
	long tmp;
	double avg;
	short div;
	
	if (useDebugger == maxBots) {
		for (i=0; i<numBots; i++) 
			if (rob[i].alive) {
				NumToString( rob[i].energy, msg1[i] );
				NumToString( rob[i].damage, msg2[i] );
			}
			else {
				msg1[i][0] = sprintf ((char*)msg1[i]+1,"Time: %ld",rob[i].deathTime);
			}
	 	
		for (i=0,j=9; i<numBots; i++,j+=34) 
		{
			r.top = j-4; r.bottom = 13+j; r.right = 500;
			if (rob[i].alive) {
				r.left = 475;
				EraseRect(&r);
				MoveTo (475,4+j - 1); DrawString(msg1[i]);
				MoveTo (475,13+j - 1); DrawString(msg2[i]);
	 		}
	 		else if (rob[i].aim)
	 		{
				r.left = 430;
				EraseRect(&r);
	 			MoveTo(430,4+j - 1);
	 			
	 			switch (rob[i].scan)
	 			{
	 				case 32000: DrawString ("\pBuggy"); break;
	 				case 32001: DrawString ("\pOverloaded"); break;
	 				default: 
	 					if (rob[i].killer != -1) DrawString(rob[rob[i].killer].name);
	 					else DrawString("\p¥¥¥Dead¥¥¥");
	 					break;
	 			}
 				MoveTo(430,13+j); DrawString(msg1[i]);
 				MoveTo (430,21+j); DrawString("\pPnts:");
 			}
 			r.top += 18; r.bottom += 10;
	 		r.left = 465; r.right = 471;
			EraseRect(&r);
	 		UpdateRobotPoints( i );
 		//NumToString( rob[i].kills, msg2[i] );
		//MoveTo (475,21+j); DrawString(msg2[i]);
	 	}
	}
	else drawDebuggerInfo();
	r.top = 206; r.bottom =216; r.left = 365; r.right = 404;
	NumToString( chronons, msg3 );
	EraseRect(&r);
	MoveTo (365,216);
	DrawString(msg3);
	r.left = 460; r.right = 500;
	if (!(chronons%5) && !pausedFlag) {
		tmp = TickCount();
		if (tmp - oldTime > 30 || chronons < 10) {
			avg = (tmp-oldTime)/(60.0*(chronons-oldChronons));
			div = 100.0/avg;
			div = (div < 0) ? ((-div) % 100) : (div % 100);
			msg3[0] = sprintf ((char*)msg3+1,"%d.%d",(short)(1.0/avg),div);
			oldTime = tmp;
			oldChronons = chronons;
			EraseRect(&r);
			MoveTo (460,216);
			DrawString(msg3);
			if (gPrefs.displayCode == 1) ObscureCursor();
		}
	}
}


//--- 19 apr 97 ---
/*
	Gets a pointer to a Color Icon Handle, then sets up a graphic world based on that icon. 
	The GWorld is setup at the current screen depth, and at a size of 32 by 32. 
	
	If you pass a already existing GWorld, this procdure will dispose it and setup a new GWorld
	in it's place.
	
	If 'nil' (or NULL) is passed as the colorIconHandle then this procedure will setup a new,
	white gWorld.

	cicn: is a Pointer to a ColorIconHandle, this is the cicn that is drawn to the GWorld as default.
	
	gw: is a Handle to a non-setup GWorld, when finished it will contain a fully created GWorld.
	
	WARNING: After a GWorld is disposed make sure the GWorldPtr = nil (or NULL) as a GWorldPtr passed 
	here which has been disposed but not set to nil will be redisposed, causing the computer to crash.
*/
void SetUpColorIcon(GWorldPtr* gw, CIconHandle* cicn) // done
{
	CGrafPtr origPort;
	GDHandle origDev;
	QDErr	myErr = noErr;
	Boolean	goodQ;
	PixMapHandle offPixMapHandle;
	Rect	r = {0,0,32,32};
	
	GetGWorld(&origPort, &origDev);		// Get the origenal port and device.
	
	if(*gw != NULL)						// Dispose of already existing GWorlds.
		DisposeGWorld(*gw);
	*gw = NULL;
	
	// make new GWorld at screen depth.
	myErr = NewGWorld(gw, 0, &r, nil,  nil, noNewDevice);	// make a new GWorld in the Variable gw;
	
	checkMemErr("ArenaControl:SetUpColorIcon");
	
	if(*gw == nil || myErr != noErr){	// if newGWorld Failed, we probably ran out of memory.
		reportMessage("Can't load icon - out of memory...", "ArenaControl:SetUpColorIcon:1");
		ExitToShell();
	}
	else{
		SetGWorld(*gw, nil);	// Set the graphic World to gw...
		
		offPixMapHandle = GetGWorldPixMap(*gw);	// enable drawing to the GWorld.
		goodQ = LockPixels(offPixMapHandle);
		
		if(!goodQ) {
			reportMessage("Can't Lock Pixels - unknown", "ArenaControl:SetUpColorIcon:2");
			ExitToShell();
		}
		else{
			EraseRect(&r);	// make the gWorld white.
			if(cicn)		// if a cicn has been passed draw it to the GWorld (stretch/Shrink);
				PlotCIcon(&r, *cicn);
			UnlockPixels(offPixMapHandle);	// We've finished drawing to the GWorld.
		}
	}
	SetGWorld(origPort, origDev);	// Use the origenal GWorld(probably the window) and Device.
}


//--- 19 apr 97 --- This works in exactly the same way as SetUpColorIcon, except that it uses an icon,
// and it also creates a 1 bit in depth GWorld.
void SetUpBWIcon(GWorldPtr* gw, Handle* icon) // done
{
	CGrafPtr origPort;
	GDHandle origDev;
	QDErr	myErr = noErr;
	Boolean	goodQ;
	PixMapHandle offPixMapHandle;
	Rect	r = {0,0,32,32};
	
	GetGWorld(&origPort, &origDev);
	
	if(*gw != NULL)
		DisposeGWorld(*gw);
	*gw = NULL;
	
	myErr = NewGWorld(gw, 1, &r, nil, nil, 0);
	checkMemErr("ArenaControl:SetUpBWIcon");
	
	if(*gw == nil || myErr !=noErr){
		reportMessage("Can't load icon - out of memory...", "ArenaControl:SetUpBWIcon:1");
		ExitToShell();
	}
	else{
		SetGWorld(*gw, nil);
		
		offPixMapHandle = GetGWorldPixMap(*gw);
		goodQ = LockPixels(offPixMapHandle);
		if(!goodQ) {
			reportMessage("Can't Lock Pixels - unknown", "ArenaControl:SetUpBWIcon:2");
			ExitToShell();
		}
		else{
			EraseRect(&r);
			if(icon != nil)
				PlotIcon(&r, *icon);
			UnlockPixels(offPixMapHandle);
		}
	}
	SetGWorld(origPort, origDev);
}


// --- Draw Current Robot Points ---
void DrawRobotPoints( short robPosID )
{
	#define		kRobotCurKills		rob[robPosID].history[3]
	#define		kRobotCurSv			rob[robPosID].history[1]
	#define		kRobotTotKills		rob[robPosID].history[4]
	#define		kRobotTotSv			rob[robPosID].history[2]
	
	Str255		msg;
	
	// --- Draw Info String
	MoveTo (430,30+34*robPosID); DrawString("\pPnts:");
	
	// --- Draw Cur Points
	ForeColor( redColor );
	NumToString( kRobotCurKills + kRobotCurSv, msg );
	MoveTo (465,30+34*robPosID); DrawString(msg);
	
	// --- Draw Total Kills
	ForeColor( blackColor );
	MoveTo (471,30+34*robPosID);
	DrawString("\p/");
	ForeColor( blueColor );
	NumToString( kRobotTotKills + kRobotTotSv, msg );
	DrawString(msg);
	
	// --- Reset Back Color
	ForeColor( blackColor );
}

void UpdateRobotPoints( short robPosID )
{
	Str255		msg;
	
	// --- Draw Cur Points
	NumToString( rob[robPosID].kills + rob[robPosID].svrl, msg );
	ForeColor( redColor );
	MoveTo (465,30+34*robPosID); DrawString(msg);
	
	// --- Reset Back Color
	ForeColor( blackColor );
}