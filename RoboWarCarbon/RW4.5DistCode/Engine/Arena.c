/* Arena.c */

/*	RoboWar 1.0
	(c) 1989 David Harris
	Written 11/13/89 by David Harris.
	Ported to Macintosh 12/26/89
	Then modified again to work with my new system.
	Upgraded to 2.0 1990 (12/23/90 to name one particular day...)
	
	This is the program that plays RoboWar.
	It uses the compiled code created by comp
	to control the robots.
	
	It works closely with ArenaControl.c, the
	set of functions that interpret the code.
*/

/* #includes */

#include <Carbon/Carbon.h>
#include "robotypes.h"
#include "Tokens.h"


/* External Globals */

extern	WindowPtr		myWindow;
extern	MenuHandle		myMenus[5];
extern	EventRecord		myEvent;
extern	double			sine[360];
extern	short			numBots;			
extern	short			isBattle;
extern	short			isTournament;
extern  short			officialFlag;
extern	robot			rob[maxBots];		
extern	short			communications[3][10];	
extern	shot			*shots;		
extern	short			numAlive;
extern	macFeatures		features;
extern 	long			chronons;
//extern	short			displayCode;
//extern	short			soundFlag;
//extern	short			battleSpeed;
extern	short			useDebugger;
extern 	short			pausedFlag;
extern	short			stepFlag;
extern	short			chrononFlag;
extern 	long			oldTime;
extern  long			oldChronons;
extern	Str255			noName;
extern 	long			messageTime;
extern  short			mode;
extern	short			botSelected;
extern prefStruct		gPrefs;



/* Globals */
short gBattleType;
robot *who;
short onlyTrackingShots;
short cycleNum;
short errorInstruction;

short		(*invokeDistance)(robot*);
short		(*invokeRadar)(robot*);
short		(*invokeCheckHitTarget)(shot*);
void		(*invokeTrackShots)(void);


/* Prototypes */
void robotError(char *type, short killBotQ);
void checkLegalEnergyDecrement(short what);
short countTeammates(robot *who);
void interpret(void);
void checkCollisions(void);
void doCollisionDamage(void);
void checkDeath(void);
short checkHitTarget (register shot *what);
void killShot(register shot *what);
void completeExplosion(register shot *what);
void completeLaser(register shot *what);
void explodeNuke (register shot *what);
void droneSeek(shot *cur);
void trackShots(void);
void doCombat(void);
void CalcKillPoints(robot* who);

/* In ArenaDos.c */
extern void (*doComparator[8])();
extern void (*doOperator[65])();

/* in ArenaControl.c */
extern void drawBits(void);
extern void drawStats(void);
extern void doSoundEffects(void);
extern void SetUpBWIcon(GWorldPtr* gw, Handle* icon);

/* In Interrupts.c */
extern void processInterrupts(robot *who);
extern void signalInterrupt(robot *who);
extern void checkRadarInterrupt(robot *who);
extern void checkRangeInterrupt(robot *who);
extern void checkChrononInterrupt(robot *who);
extern void updateOldInterruptState(robot *who);
extern void queueInterrupts(robot *who);

/* in Util.c */
extern void installButtonOutline(DialogPtr theDialog,short itemNo);
extern pascal Boolean timeOutFilter(DialogPtr,EventRecord,short*);
extern void checkMemErr(char *proc);
extern void checkResErr(char *proc);
extern void playSound(short whichSound,short whichBot);
extern void clearChannel(void);
extern void reportMessage(char *message1,char *message2);

/* in Projectile.c */
extern short findTarget(void);
extern short findLaserTarget(double *x,double *y);
extern void doGun(short what);
extern void doMissile (short what);
extern void doNuke (short what);
extern void doJoce(short what);
extern void doHellBore(short what);
extern void doDrone(short what,short target);
extern void doMine(short what);
extern void doLaser(short what,double x,double y,short target);
extern void doBullet(short what);
extern void doStunner(short what);
extern short doppler(void);

/* in Debugger.c */
extern void drawDebuggerInfo(void);
extern void setButtonsPaused(void);

/* in Main.c */
extern void mouseEvent(void);
extern void keyEvent(void);
extern void activateEvent(void);
extern void updateEvent(void);
extern void diskEvent(void);
extern void changeMode(short newMode);

/* in AssemblyLine.c */
void assembleRobot(short errorInstruction);

/* in History.c */
void initHistory(void);
void updateHistory(void);

//
//void strAppend( char* s1, char* s2 );
//void strAppendP( char* s1, unsigned char* s2 );


/* Functions */

void robotError(char *type, short killBotQ)  // -- done
{
	char msg1[255],msg2[255];
	char oldChar;
	short result = 0;
	ModalFilterUPP filterUPP;
	DialogPtr myDialog;
	
	if (isBattle == true && gPrefs.showBugyRobotDialogQ == true) {
		PtoCstr(who->name);
		
		oldChar = who->name[11];
		who->name[11] = 0; /* Truncate to 11 characters */
		
		// - Set message 2
		sprintf(msg2,"Robot: %s Instruction: %d.",who->name,who->progPtr);
		
		// - Set message 1
		sprintf(msg1,"%s",type);
		
		/* Restore string */
		who->name[11] = oldChar; 
		CtoPstr((char*)who->name);
		CtoPstr((char*)msg1);
		CtoPstr((char*)msg2);
		
		messageTime = TickCount();
		filterUPP =  NewModalFilterProc(&timeOutFilter);
		myDialog = GetNewDialog(BugDlogID,NULL,(WindowPtr)-1);
		ParamText((unsigned char*)msg1,(unsigned char*)msg2,noName,noName);
		installButtonOutline(myDialog,5);
		do {
			ModalDialog(filterUPP,&result);
		} while (result > 2);
		DisposeDialog(myDialog);
		DisposeRoutineDescriptor(filterUPP);
	}
	if (result == 2) { /* Find Error in drafting board */
		isBattle = 0;
		isTournament = 0;
		botSelected = who->number;
		errorInstruction = who->progPtr - 1;
	}
	else if( killBotQ )
	{
		who->progPtr--;
		
		who->damage = -10;
		cycleNum = who->hardware.processorSpeed;
		who->scan = 32000;
		checkDeath();
	}
}

void checkLegalEnergyDecrement(short amount) // -- done
{
	if (amount > 600 || amount < 0) robotError("Illegal energy usage.", true);
}

short countTeammates(robot *who) // -- done
{
	short i,teammates = 0;

	if (!who->team) return 0; /* not on any team */
	for (i=0; i<numBots; i++)
		if (rob[i].team == who->team && rob[i].alive && who->number != i) teammates++;
	return teammates;
}

void interpret(void) // -- done
{
	short code;

	code = who->prog[who->progPtr++];
	if (who->progPtr > who->progSize) {
		if (who->progSize < 2) robotError("Robot not compiled",true);
		else robotError ("Tried executing beyond end of program",true);
	}
	else if (code < 20000 || (code >= 20300 && code < 20400)) { /* number or variable name */
		if (who->stackPtr < stackSize) 
			who->stack[who->stackPtr++] = code;
		else robotError ("Stack overflow",true);
	}
	else if (code >= 20000 && code <= 20007) {
		doComparator[code - 20000]();
	}
	else if (code >= 20100 && code <= 20164) {
		doOperator[code - 20100]();
	}
	else {
		robotError ("Unidentified instruction",true);
	}
}

void checkCollisions(void) // -- done
{
	register short i;
	register long deltaX,deltaY;

	for (i=0; i<numBots; i++) 
		if (i != who->number && rob[i].alive) {
			deltaX = who->letters[x_]-rob[i].letters[x_];
			deltaY = who->letters[y_]-rob[i].letters[y_];
			if (abs(deltaX) < radius<<1)
				if (abs(deltaY) < radius<<1)
					if (deltaX*deltaX+deltaY*deltaY < radiusSquared<<2) {
						if (who->energy > 0 && !who->stunned) {
							who->letters[x_] -= who->speedX;
							who->letters[y_] -= who->speedY;
						}
						who->collision = 1;
						rob[i].collision = 1;
						if (who->team && who->team == rob[i].team) {
							who->friend = 1;
							rob[i].friend = 1;
						}
					}
		}
	
	if (who->letters[x_] < radius ||
		who->letters[x_] > boardSize-radius) {
		who->wall = 1;
		if (who->letters[x_] < 0) who->letters[x_] = 0;
		if (who->letters[x_] > boardSize) who->letters[x_] = boardSize;
	}
	if (who->letters[y_] < radius ||
		who->letters[y_] > boardSize-radius) {
		who->wall = 1;
		if (who->letters[y_] < 0) who->letters[y_] = 0;
		if (who->letters[y_] > boardSize) who->letters[y_] = boardSize;
	}
}

void doCollisionDamage(void) // -- done
{
	if (who->collision) {
		doDamage (who,who->collision);
		
		if (who->sounds[CollisionSnd] != NULL) playSound(CollisionSnd,who->number);
		else playSound(CollisionSndID,maxBots);
				
	}
	if (who->wall) {
		doDamage (who, 5);
		
		if (who->sounds[CollisionSnd] != NULL) playSound(CollisionSnd,who->number);
		else playSound(CollisionSndID,maxBots);
	}
}

void checkDeath(void) // -- done
{
	register shot *cur;
	register short loop,i,firstTeam,allSameTeam;
	
	if (who->damage <= 0 && who->deathTime == -1) {
		who->shield = 0;
		who->alive = 0;
		who->deathTime = chronons;
		who->aim = 1; /* Keep Death State in Aim */
		who->speedX = who->letters[x_]; /* Keep Old Position in Speed x & y */
		who->speedY = who->letters[y_];
		who->letters[x_] = 5000; /* Move body */
		who->letters[y_] = 5000; /* Out of way */
		numAlive--;	/* Decrement count of surviving bots */
		cur = shots; /* Make drones lose tracking */
		while (cur != NULL) {
			if (cur->yAngle == who->number && cur->type == drone) {
				cur->xAngle = -1;
				cur->type = explode;
			}
			cur = cur->next;
		}
		if (who->sounds[DeathSnd] != NULL) playSound(DeathSnd,who->number);
		else playSound(ExplosionSndID,maxBots);
		/* Check if all survivors are on the same team */
		loop = 0;
		while (!rob[loop].alive) loop++;
		firstTeam = rob[loop++].team;
		allSameTeam = firstTeam;
		for (i=loop; i<numBots; i++)
			if (rob[i].team != firstTeam && rob[i].alive) allSameTeam = 0;
		if (allSameTeam || numAlive <= 1) {
			onlyTrackingShots = 20; /* End after 20 chronons */
		}
	}
}

short checkHitTarget (register shot *what) //  -- done
{
	register shot *cur;
	register robot *target;
	register short i;
	register long x,y;
	register double xd, yd;
	short result = 0;
	
	for (i=0,target = rob; i<numBots && !result; i++,target++) {
		/* Quick check of position */
		x = what->xPosInt-target->letters[x_];
		if (abs(x) < radius) {
			y = what->yPosInt-target->letters[y_];
			if (abs(y) < radius) {
				/* Use full floating point accuracy on final check */
				xd = what->xPos-target->letters[x_];
				yd = what->yPos-target->letters[y_];
				if (xd*xd+yd*yd < radiusSquared) {
					result = 1;
					if (what->type == missile) what->energy += what->energy; /* 2 x damage */
					else if (what->type == gun) switch (what->gunType) {
						case 1: what->energy = what->energy/2; break; /* Rubber bullets */
						case 3: what->type = bigExplode;			  /* Exploding bullets */
								what->xAngle = 0;
								break;
						/* Normal bullets default to normal damage */
					}
					// mines do 2x damage
					else if (what->type == mine) what->energy += what->energy;
					// drones do 1/2 damage
					else if (what->type == drone) what->energy = what->energy/2;
					what->xAngle = i; // ????
					if (what->type != bigExplode)
						what->type = explode;
				}
			}
		}
	}
	
	/* Check for shooting down drones */
	if (!result && (what->type == missile || what->type == gun || 
					what->type == hellBore)) { 
		cur = shots;
		while (cur != NULL) {
			if (cur->type == drone && cur != what) {
				if (fabs(what->xPosInt-cur->xPosInt) < 5 && fabs(what->yPosInt-cur->yPosInt) < 5) {
					what->type = explode;
					what->xAngle = -1; /* Nobody */
					cur->type = explode;
					cur->xAngle = -1; /* Nobody */
					result = 1;
				}
			}
			cur = cur->next;
		}
	} 
	return result;
}


void killShot(register shot *what) // -- done
{
	register shot *cur;
	
	cur = shots;
	if (cur == what) 
		shots = what->next;
	else {
		while (cur->next != what) cur = cur->next;
		cur->next = cur->next->next;
	}
	DisposePtr((Ptr)what);
	checkMemErr("arena:killShot");
}


void completeExplosion(register shot *what) // -- done
{
	robot *who;
	short damaged = 1;
	
	if (what->xAngle != -1) {
		who = rob+(short)what->xAngle;
		if (what->gunType == hellBore) who->shield = 0;
		else if (what->gunType == stunner) who->stunned += what->energy/4;
		else damaged = doShotDamage(who,what->energy,what->owner);//, what->xAngle

		if (!damaged) {
			if (who->sounds[ShieldHitSnd] != NULL) playSound(ShieldHitSnd,who->number);
			else playSound(ShotHitSndID,maxBots);
			if (who->hit == 0) who->hit = 1; /* shield hit icon */
		}
		else {
			if (who->sounds[HitSnd] != NULL) playSound(HitSnd,who->number);
			else playSound(ShotHitSndID,maxBots);
			who->hit = 2; /* robot hit icon */
		}
	}
	else playSound(ShotHitSndID,maxBots);
	killShot(what);
}

void completeLaser(register shot *what) // -- done
{
	what->type = explode;
	what->xPosInt = what->xAngle;
	what->yPosInt = what->yAngle;
	what->xAngle = what->gunType;
	/* The following line produces buggy results: what->energy *= .2; */
	what->energy = what->energy / 5;
}

void explodeNuke (register shot *what) // -- done
{
	register short i;
	register long x,y,z;
	register shot *cur;
	
	z = (what->xAngle+radius) * (what->xAngle+radius);
	for (i=0; i<numBots; i++) { /* Blow up all nearby robots */
		x = rob[i].letters[x_] - what->xPosInt;
		y = rob[i].letters[y_] - what->yPosInt;
		if (x*x+y*y < z) doShotDamage(rob+i,what->energy*2,what->owner); //,i
	}
	playSound(BangSndID,maxBots);
	cur = shots;
	while (cur != NULL) {
		if (cur->type == drone) {
			x = cur->xPosInt-what->xPosInt;
			y = cur->yPosInt-what->yPosInt;
			if (x*x+y*y < z) {
				cur->type = explode;
				cur->xAngle = -1;
			}
		}
		cur = cur->next;
	}
	killShot(what);
}

void droneSeek(shot *cur) // -- done
{
	register short x,y,tX,tY;
					  		
	x = cur->xPosInt; y = cur->yPosInt;
	tX = rob[(short)cur->yAngle].letters[x_];
	tY = rob[(short)cur->yAngle].letters[y_];
	if (abs(tX-x) == 5) tX = x;
	if (abs(tY-y) == 5) tY = y;
	if (x < tX && y < tY) {
		cur->xPosInt += 2; cur->yPosInt += 2;
		cur->gunType = 7;
	}
	else if (x > tX && y < tY) {
		cur->xPosInt -= 2; cur->yPosInt += 2;
		cur->gunType = 5;
	}
	else if (x > tX && y > tY) {
		cur->xPosInt -= 2; cur->yPosInt -= 2;
		cur->gunType = 3;
	}
	else if (x < tX && y > tY) {
		cur->xPosInt += 2; cur->yPosInt -= 2;
		cur->gunType = 3;
	}
	else if (x < tX) {
		cur->xPosInt += 2;
		cur->gunType = 0;
	}
	else if (x > tX) {
		cur->xPosInt -= 2;
		cur->gunType = 4;
	}
	else if (y < tY) {
		cur->yPosInt += 2;
		cur->gunType = 6;
	}
	else { /* y > tY */
		cur->yPosInt -= 2;
		cur->gunType = 2;
	}
	cur->xAngle -= 1; /* Time runs out */
	if (cur->xAngle == 0) {
		cur->type = explode;
		cur->xAngle = -1;
	}
	
	// Slightly inacurate/offspeed, but good enough.
	cur->xPos = cur->xPosInt;
	cur->yPos = cur->yPosInt;
}

void trackShots(void) // -- done
{
	register shot *cur;
	cur = shots;
	while (cur != NULL) {
		/* Track shot */
		switch(cur->type) {
			case gun: cur->xPos += cur->xAngle;
					  cur->yPos += cur->yAngle;
					  cur->xPosInt = cur->xPos;
					  cur->yPosInt = cur->yPos;
					  if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
					  	  cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					  else if (!(*invokeCheckHitTarget)(cur)) {
							cur->xPos += cur->xAngle;
					  		cur->yPos += cur->yAngle;
					  		cur->xPosInt = cur->xPos;
					  		cur->yPosInt = cur->yPos;
						  	if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
						  	  	cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					  		else (*invokeCheckHitTarget)(cur);
					  }
					  break;
			case missile: cur->xPos += cur->xAngle;
						  cur->yPos += cur->yAngle;
					  	  cur->xPosInt = cur->xPos;
					  	  cur->yPosInt = cur->yPos;
						  if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
						  	  cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					 	  else (*invokeCheckHitTarget)(cur); 
						  break;
			case tacNuke: if (cur->xAngle < 50) cur->xAngle += 5;
						  else explodeNuke(cur);
						  break;
			case explode: completeExplosion(cur);
						  break;
			case bigExplode: if (cur->xAngle < 36) cur->xAngle += 12;
							 else explodeNuke(cur);
							 break;
			case hellBore: cur->xPos += cur->xAngle;
					  cur->yPos += cur->yAngle;
					  cur->xPosInt = cur->xPos;
					  cur->yPosInt = cur->yPos;
					  if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
					  	  cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					  else if (!(*invokeCheckHitTarget)(cur)) {
							cur->xPos += cur->xAngle;
					  		cur->yPos += cur->yAngle;
						  	cur->xPosInt = cur->xPos;
					 		cur->yPosInt = cur->yPos;
						  	if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
						  	  	cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					  		else (*invokeCheckHitTarget)(cur);
					  }
					  break;
			case mine: (*invokeCheckHitTarget)(cur); break;
			case newMine: cur->xAngle -= 1;
					  	  if (!cur->xAngle) cur->type = mine;
						  break;
			case drone: droneSeek(cur);
					 	(*invokeCheckHitTarget)(cur); 
						 break;
			case laser: completeLaser(cur); break;
			case stunner: cur->xPos += cur->xAngle;
					  cur->yPos += cur->yAngle;
					  cur->xPosInt = cur->xPos;
					  cur->yPosInt = cur->yPos;
					  if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
					  	  cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					  else if (!(*invokeCheckHitTarget)(cur)) {
							cur->xPos += cur->xAngle;
					  		cur->yPos += cur->yAngle;
					  		cur->xPosInt = cur->xPos;
					  		cur->yPosInt = cur->yPos;
						  	if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
						  	  	cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					  		else (*invokeCheckHitTarget)(cur);
					  }
					  break;

			default: break;
		}
		cur = cur->next;
	}
}

// -------------------------------------------------------------------------------
void checkEvents(void)
{	
	register short eventHappened;
	
	if (features.hasWaitNextEvent) 
		eventHappened = WaitNextEvent(everyEvent,&myEvent,0,NULL);
	else {
		SystemTask();
		eventHappened = GetNextEvent(everyEvent,&myEvent);
	}
	if (eventHappened) {
		switch (myEvent.what) {
			case mouseDown: mouseEvent(); break;
			case keyDown:
			case autoKey: keyEvent(); break;
			case activateEvt: activateEvent(); break;
			case updateEvt: updateEvent(); break;
			case diskEvt: diskEvent(); break;
		}
	}
}

// -------------------------------------------------------------------------------
void doCombat(void) // -- done
{
	register short i;
	short curBotNum,loop,pos;
	Rect r;
	long count;
	short hadEnergy;
	short order[maxBots];
	
	initHistory();
	
	for(i=0; i<numBots; i++) {
		who = rob+i;
		who->killTime[0] = -1;
		who->killTime[1] = -1;
		who->killTime[2] = -1;
		who->killTime[3] = -1;
		who->killTime[4] = -1;
		who->killTime[5] = -1;
	}
	
	oldTime = TickCount();
	oldChronons = 0;
	drawBits();
	drawStats();
	onlyTrackingShots = 0;
	if (!gPrefs.battleSpeed) count = 0;
	if (useDebugger == maxBots) pausedFlag = 0;
	do {
		for (i=0; i<numBots; i++) {
			rob[i].collision = 0;
			rob[i].friend = 0;
			rob[i].wall = 0;
			rob[i].hit = 0;
		}
		(*invokeTrackShots)();
		for (i=0; i<numBots; i++) {
			who = rob+i;
			if (who->alive && !who->stunned) {
				if (who->energy < who->hardware.energyMax) {
					who->energy += 2;
					if (who->energy > who->hardware.energyMax)
						who->energy = who->hardware.energyMax;
				}
				else if (who->energy > who->hardware.energyMax) {
					robotError("Energy Max exceeded",true);
				}
				if (who->shield) {
					if (who->shield > who->hardware.shieldMax) who->shield -= 2;
					else if (who->shield > 0 && chronons%2) who->shield--;
					if (who->shield < 0) who->shield = 0;
				}
				if (who->energy > 0) {
					who->letters[x_] += who->speedX;
					who->letters[y_] += who->speedY;
				}
				if (who->energy < -200) {
					who->damage = -10;
					who->scan = 32001;
				}
			}
			if (who->alive) {
				checkCollisions();
				who->haveDoneMoveOrShootQ = false;
			}
			
			CalcKillPoints(who);			
		}
		for (i=0; i<numBots; i++) {
			who = rob+i;
			if (who->alive) {
				doCollisionDamage();
				checkDeath();
			}
			order[i] = i; /* Initialize array to randomly select order of robot evaluation */
		}
		
		/* interpret all robots not in debugger mode */
		for (loop = 0; loop<numBots; loop++) {
			pos = rand()%(numBots-loop);
			curBotNum = order[pos];
			order[pos] = order[numBots-loop-1];
			who = rob+curBotNum;
			
			if (who->alive) {
				queueInterrupts(who);
				processInterrupts(who);
				checkRadarInterrupt(who);
				checkRangeInterrupt(who);
				checkChrononInterrupt(who);
				updateOldInterruptState(who);
				if (who->stunned) who->stunned--;
				else {
					if (who->energy > 0 && who->alive && !(curBotNum == useDebugger && pausedFlag)) 
						for (cycleNum=0; cycleNum<who->hardware.processorSpeed; cycleNum++)
							interpret(); 
					if (who->energy < -200) {
						who->damage = -10;
						who->scan = 32001;
						checkDeath();
					}
				}
			}
			else if (who->aim) {
				who->aim++;
	 			if (who->aim > 15) who->aim = 0; /* Done exploding */
			}
		}
		
		/* Handle debugger stuff */
		if (pausedFlag) {
			who = rob+useDebugger;
			cycleNum = 0;
			chrononFlag = 0;
			hadEnergy = who->energy;
			drawDebuggerInfo();
			if (gPrefs.displayCode == 1) drawBits();
			if (gPrefs.displayCode < 3) drawStats();
			do {
				/* Allow for single stepping */
				stepFlag = 0;
				checkEvents();
				if (stepFlag) {
					if (hadEnergy > 0 && who->alive) {
						if (!who->stunned) interpret();
						cycleNum++;
						if (gPrefs.displayCode == 1) drawBits();
						if (gPrefs.displayCode < 3) drawStats();
					}
					else chrononFlag=1;
				}
				if (chrononFlag || !pausedFlag) {
					for (;cycleNum<who->hardware.processorSpeed; cycleNum++)
						if ((hadEnergy > 0) && who->alive && !who->stunned) interpret();
				}
			} while (isBattle && cycleNum < who->hardware.processorSpeed);
		}
		else checkEvents();
		
		/* Draw screen */
		
		if (!gPrefs.battleSpeed) {
			count = (count+1)%2;
			if (count && gPrefs.displayCode == 1) drawBits();
			if (gPrefs.displayCode < 3) drawStats();
		}
		else {
			if (gPrefs.displayCode == 1) drawBits();
			if (gPrefs.displayCode < 3) drawStats();
			doSoundEffects();
			//if (gPrefs.battleSpeed != 1) {
				switch (gPrefs.battleSpeed) {
					case 1:  count = TickCount()+1; break;	// normal
					case 2:  count = TickCount()+2; break;  // slow
					case 3:  count = TickCount()+5; break;	// v slow
					case 4:  count = TickCount()+30; break;	// v very slow
				}
				while (TickCount() < count) checkEvents();
			//}
		}
		
		/* Advance to next chronon */
		chronons++;
		if (isTournament && chronons > 1500) isBattle = 0; /* End tournaments in 1500 c */
		if (onlyTrackingShots) {
			onlyTrackingShots--;  /* Conclude after 20 chronons */
			if (!onlyTrackingShots) isBattle = 0;
		}
	} while (isBattle);
	
	if( numBots == 2 || gBattleType == kTeamBattle )
	{
		for (i=0; i<numBots; i++)
		{
			who = rob+i;
			
			if (who->alive)
			{
				who->svrl = 1;
			}
		}
	}
	else
	{
		for (i=0; i<numBots; i++)
		{
			who = rob+i;
			
			if (who->alive)
			{
				who->svrl = 3;
			}
		}
	}
	
	
	r.top = 0; r.bottom = 300;
	r.left =0; r.right = 300;
	InvalRect(&r);
	r.top = 0; r.bottom = 220; 
	r.left = 302; r.right = 500;
	InvalRect(&r);
	r.top = 220; r.bottom = 248;
	r.left = 302; r.right = 500;
	InvalRect(&r);
	updateHistory();
	clearChannel();
	if (errorInstruction != -1) {
		changeMode(draftingBoard_);
		if (mode == draftingBoard) { /* Successfully changed modes */
			assembleRobot(errorInstruction);
			//GotoWordAt(errorInstruction);
		}
	}
}



void CalcKillPoints(robot* who) // -- Done
{
	short i;
	
	if( who->alive )
	{
		who->kills =( who->killTime[0] != -1 ) + 
					( who->killTime[1] != -1 ) +
					( who->killTime[2] != -1 ) +
					( who->killTime[3] != -1 ) +
					( who->killTime[4] != -1 ) +
					( who->killTime[5] != -1 );
	}
	else
	{
		who->kills =( (who->killTime[0] != -1) && ((who->deathTime - who->killTime[0]) >= 20) ) + 
					( (who->killTime[1] != -1) && ((who->deathTime - who->killTime[1]) >= 20) ) +
					( (who->killTime[2] != -1) && ((who->deathTime - who->killTime[2]) >= 20) ) +
					( (who->killTime[3] != -1) && ((who->deathTime - who->killTime[3]) >= 20) ) +
					( (who->killTime[4] != -1) && ((who->deathTime - who->killTime[4]) >= 20) ) +
					( (who->killTime[5] != -1) && ((who->deathTime - who->killTime[5]) >= 20) );
	}
	
	// --- give every Robot Alive, if there's less than 3 and more than 1, a servival point.
	// --- If there's only one robot, wait 5 chronon's before awording servival point.
	if( (numBots > 2) && (gBattleType != kTeamBattle) )
	{
		if( numAlive == 3 )
		{
			for( i=0; i < numBots; i++ )
			{
				if( rob[i].alive )
					rob[i].svrl = 1;
			}
		}
		else if( numAlive == 2 )
		{
			for( i=0; i < numBots; i++ )
			{
				if( rob[i].alive )
					rob[i].svrl = 2;
			}
		}
	}
}


/*void strAppend( char* s1, char* s2 )
{ 
	strcpy( s1 + strlen( s1 ), s2 ); 
}

void strAppendP( char* s1, unsigned char* s2 )
{ 
	strcpy( s1 + strlen( s1 ), (char*)(s2+1) ); 

}*/