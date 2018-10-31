/*
 *  RoboWar.engine.control.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Sat Jun 26 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 *  In order to facilitate a more MVC style debugger, I've broken out
 *  functions for different parts of the battle round (chronon). This
 *  will allow the user to either use the automatic battle (provided here)
 *  or a more tightly controlled or semi-automatic execution (provided
 *  in RoboWar.debugger.control.c).
 */

#include <Carbon/Carbon.h>
#include "RoboTypes.h"
#include "Tokens.h"

#define kMinChrononsPerFrame (10)

// ----- globals from main.c -----
extern WindowRef		gArenaWindow;
extern ControlRef		gBattleButton;
extern ControlRef		gChrononView;
extern ControlRef		gCampView;
extern ControlRef		gArenaView;
extern short			numBots;
extern robot			rob[maxBots];
extern shot				*shots;
extern short			isBattle;
extern short			isTournament;
extern prefStruct		gPrefs;
extern unsigned short   lastRandSeed;

// ----- from RoboWar.engine.feedback.c -----
extern void robotError();

// ----- from RoboWar.errors.c -----
extern void checkMemErr(char *proc);
extern void displayErr(char *errCode, char *errName,char *proc);

// ----- from RoboWar.engine.combat.c -----
extern void initCombat();
extern void checkDeath(void);
extern void CalcKillPoints(robot *who);
extern void doCollisionDamage(void);

// ----- from RoboWar.engine.history.c -----
extern void initHistory();
extern void updateHistory();

// ----- from RoboWar.engine.projectile.c -----
extern void trackShots();

// ----- from RoboWar.engine.physics.c -----
extern void checkCollisions();

// ----- from RoboWar.engine.interpreter.c -----
extern void interpret();

// ----- from RoboWar.engine.interrupts.c -----
extern void initRobotInterrupts(robot *who);
extern void queueInterrupts(robot *who);
extern void processInterrupts(robot *who);
extern void checkRadarInterrupt(robot *who);
extern void checkRangeInterrupt(robot *who);
extern void checkChrononInterrupt(robot *who);
extern void updateOldInterruptState(robot *who);


// ----- globals -----
EventLoopTimerRef   combatTimer = NULL;
EventLoopTimerRef   statsTimer = NULL;
unsigned long		chronon = 0;
unsigned long		frameStartTick;			// start time of the frame for calculating  
unsigned long		frameStartChronon;		// start chronon of the frame
unsigned long		chrononFrame = 0;		// start chronon of the frame
double				chrononsPerSecond = 0.0;

short				numAlive;				// Number of robots remaining alive
short				onlyTrackingShots;		// Number of chronons remaining in a combat conclusion.

short				gBattleType;
robot				*who;					// the robot who we are currently processing
short				cycleNum;				// the number of <who>'s instructions processed this chronon
short				errorInstruction;		// the instruction index for the offending instruction
short				communications[3][10];	// Channel & signal communications routes

short				order[maxBots];			// The order in which to execute robots
short				indexInOrder;

// ----- prototypes -----
OSStatus haltCombat ();

void updateChrononsPerSecond (EventLoopTimerRef inTimer, void * inUserData)
{
	if (chronon >= frameStartChronon + kMinChrononsPerFrame) {
		unsigned long deltaTicks = (TickCount() - frameStartTick);
		unsigned long deltaCronons = (chronon - frameStartChronon);
		
		chrononsPerSecond = ((chrononsPerSecond * chrononFrame) + (deltaTicks>0 ? deltaCronons*60.0/deltaTicks : deltaCronons*1.0 )) / (chrononFrame+1);
		chrononFrame++;
		
		frameStartTick = TickCount();
		frameStartChronon = chronon;
	}
}

short advanceCombatByOneInstruction ()
{
	if ( who->alive && cycleNum < who->hardware.processorSpeed && !who->stunned )
	{
		interpret();
		cycleNum++;
		return 1; // 
	}
	else
	{
		// decrement stun and explosion timers
		if (who->stunned) who->stunned--;
		if (!who->alive && who->aim) who->aim--;
		return 0;
	}
}

void advanceCombatByOneChronon ()
{
	// originally part of doCombat() from ./Engine/Arena.c
	short i;
	
	// draw to the screen	
	switch (gPrefs.battleSpeed)
	{
		case kRoboWarDrawArenaAndStats:
			Draw1Control(gArenaView);
		
		case kRoboWarDrawStatsOnly:
			Draw1Control(gCampView);
		
		case kRoboWarDrawNothing:
			Draw1Control(gChrononView);
	}

	// Advance to next chronon
	chronon++;
	
	// End tournaments in 1500 c
	if (isTournament && chronon > 1500)
		haltCombat(); 
	
	// conclude after the onlyTrackingShots timer runs out (20 chronons)
	if (onlyTrackingShots) {
		onlyTrackingShots--;
		if (!onlyTrackingShots) isBattle = 0;
	}
	
	// unset flags that get renewed each chronon
	for (i=0; i<numBots; i++) {
		rob[i].collision = 0;
		rob[i].friend = 0;
		rob[i].wall = 0;
		rob[i].hit = 0;
	}
	
	// make the shots move
	trackShots();
	
	// combat phase 1: check energy, shields, speed and collisions.
	for (i=0; i<numBots; i++) {
		who = rob+i;
		if (who->alive) {
			if (!who->stunned) {
				if (who->energy < -200) {
					// kill bots who bottom-out in energy.
					who->damage = -10;
					who->scan = 32001;
				}
				else {
					if (who->energy < who->hardware.energyMax) {
						// regenerate energy
						who->energy += 2;
						if (who->energy > who->hardware.energyMax)
							who->energy = who->hardware.energyMax;
					}
					else if (who->energy > who->hardware.energyMax) {
						// report buggy energy
						robotError("Energy Max exceeded",true);
					}
					if (who->shield) {
						// decimate the shield
						if (who->shield > who->hardware.shieldMax) who->shield -= 2;
						else if (who->shield > 0 && chronon%2) who->shield--;
						if (who->shield < 0) who->shield = 0;
					}
					if (who->energy > 0) {
						// make the robots move
						who->letters[x_] += who->speedX;
						who->letters[y_] += who->speedY;
					}
				}
			}
			checkCollisions();
			who->haveDoneMoveOrShootQ = false;
		}
		
		CalcKillPoints(who);			
		order[i] = numBots-i-1; /* Initialize array to randomly select order of robot evaluation */
	}
	
	// combat phase 2: do collision damage and check for robot death.
	for (i=0; i<numBots; i++) {
		// randomize the order of bot execution.
		short pos = rand()%(numBots-i);
		short temp = order[pos];
		order[pos] = order[i];
		order[i] = temp;
		
		who = rob+i;
		if (who->alive) {
			doCollisionDamage();
			checkDeath();
		}
	}
	indexInOrder = 0;
}

void handleCombatTimerFire (EventLoopTimerRef inTimer, void * inUserData)
{
#pragma unused (inTimer, inUserData)

	// step 1: complete the all remaining interpreting
	//  this is also combat phase 3 (interpret robots)
	while (indexInOrder < numBots) {
		who = rob+order[indexInOrder];
		if (who->alive && cycleNum == 0) {
			queueInterrupts(who);
			processInterrupts(who);
			checkRadarInterrupt(who);
			checkRangeInterrupt(who);
			checkChrononInterrupt(who);
			updateOldInterruptState(who);
		}
		while(advanceCombatByOneInstruction())
			; // -- empty loop
		indexInOrder++;
		cycleNum = 0;
	}
	
	// step 2: do everything else that happens between chronons
	advanceCombatByOneChronon();
}

void setupChrononFrames()
{
	frameStartTick = TickCount();
	frameStartChronon = 0;
	chrononsPerSecond = 0.0;
	chrononFrame = 0;
}

void prepareArena(void)
{
	shot *cur;
	short i,j;
	
	errorInstruction = -1;
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
	for (i=0; i<3; i++)
		for (j=0; j<10; j++)
			communications[i][j] = 0;
}

void prepareRobots(short repeatFlag)
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

short setupCombat (short repeatFlag) {
	short i;

	CFShow(CFSTR("setupCombat()"));
	
	if (numBots <= 0) {
		// a battle cannot take place without combatants
		// technically, this shouldn't ever be called -- the battle btn and menu item
		// should be disabled when there aren't any bots in the arena.
		SysBeep(30);
		displayErr("Cannot Start a Battle", "There are no combatants in the arena!", NULL);
		return false;
	}
	
	// initialize the arena stats displays
	setupChrononFrames();
	
	// other initialization
	numAlive = numBots;
	initHistory();
	initCombat();
	prepareArena();
	prepareRobots(repeatFlag);
	
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
	
	// since the timer will actually handle the end of a chronon first,
	// force the timer to skip the 1st iteration of robot code interpretation,
	indexInOrder = numBots;
	chronon = 0; // as a resul, the first real chronon will be #1.
	
	Draw1Control(gArenaView);
	Draw1Control(gCampView);
	Draw1Control(gChrononView);
	
	return true;
}

OSStatus installCombatTimer ()
{
	OSStatus err = noErr;
	
	if (combatTimer != NULL) return err;
	
	// install the statistics updating timer
	err = InstallEventLoopTimer(
			GetMainEventLoop(),
			kEventDurationSecond / 4.0,		// initial delay
			kEventDurationSecond / 4.0,   // delay between fires (as small as possible)
			NewEventLoopTimerUPP(updateChrononsPerSecond), // the callback function
			NULL,		// no user data
			&statsTimer
		);
	require_noerr( err, TimerCreationFailure );
	
	// install the main combat timer
	err = InstallEventLoopTimer(
			GetMainEventLoop(),
			kEventDurationNoWait,		// initial delay
			kEventDurationMillisecond,   // delay between fires (as small as possible)
			NewEventLoopTimerUPP(advanceCombatByOneChronon), // the callback function
			NULL,		// no user data
			&combatTimer
		);
		
TimerCreationFailure:		
	if (err == noErr) {
		SetControlTitleWithCFString(gBattleButton, CFSTR("Halt"));
		isBattle = 1;
	} else {
		combatTimer = NULL;
		CFShow(CFSTR("Creation of the combat timers failed!"));
		SysBeep(30);
	}
	
	return err;
}

OSStatus resumeCombat ()
{
	OSStatus err = noErr;

	if (isBattle && combatTimer == NULL) {
		setupChrononFrames();
		err = installCombatTimer();
	} else {
		CFShow(CFSTR("The combat EventLoopTimer is already running!"));
		SysBeep(30);
	}
	
	return err;
}

OSStatus pauseCombat ()
{
	OSStatus err = noErr;

	if (combatTimer != NULL) {
		RemoveEventLoopTimer(statsTimer);
		err = RemoveEventLoopTimer(combatTimer);
		
		if (err == noErr) {
			combatTimer = NULL;
		} else {
			CFShow(CFSTR("Removal of the combat timers failed!"));
			SysBeep(30);
		}
	}
	
	return err;
}


OSStatus haltCombat ()
{
	short i;
	OSErr err = noErr;
	
	isBattle = 0;
	SetControlTitleWithCFString(gBattleButton, CFSTR("Battle"));
		
	err = pauseCombat();
	
	if (err == noErr) {
		// adjust final survival points
		// see RoboWar.engine.combat.c:CalcKillPoints() for more survival point calcs.
		// what is defined here overrides CalcKillPoints()'s awards.
		if( numBots > 1 || gBattleType == kTeamBattle )
		{
			// award only 1 point on a draw, or team tournament match
			for (i=0; i<numBots; i++)
			{
				who = rob+i;
				if (who->alive)
					who->svrl = 1;
			}
		} else {
			// award 3 points to a bot if it is the last bot standing
			for (i=0; i<numBots; i++)
			{
				who = rob+i;
				if (who->alive)
					who->svrl = 3;
			}
		}
		
		updateHistory();
		
		// OPENISSUE -- should close sound channels and clear them.

		if (errorInstruction != -1) {
			// changeMode(draftingBoard_);
			// if (mode == draftingBoard) { /* Successfully changed modes */
			//		assembleRobot(errorInstruction);
			//}
		}
	}
	
	return err;
}

OSStatus beginCombat (short repeatFlag)
{
	OSStatus err = noErr;

	if (combatTimer == NULL) {
		if (setupCombat(repeatFlag))
			err = installCombatTimer();
	} else {
		CFShow(CFSTR("The combat EventLoopTimer is already running!"));
		SysBeep(30);
	}
	
	return noErr;
}

OSStatus replayCombat(unsigned seed)
{
	OSStatus err = noErr;

	if (combatTimer == NULL) {
		setupCombat(seed);
		
		err = installCombatTimer();
	} else {
		CFShow(CFSTR("The combat EventLoopTimer is already running!"));
		SysBeep(30);
	}
	
	return noErr;
}