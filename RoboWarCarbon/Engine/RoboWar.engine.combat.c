/*
 *  RoboWar.engine.combat.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Sun Jun 27 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "Tokens.h"
#include "RoboWar.engine.states.h"
#include "RoboWar.model.preferences.h"

// ----- locally defined globals -----

ArenaState				gArenaState;
short					gArenaCurBotNum;

// ----- globals from main.c -----
// extern ControlRef		gArenaView;
// extern ControlRef		gChrononView;
// extern ControlRef		gCampView;
extern short			numBots;
extern robot			rob[maxBots];
extern short			isBattle;
extern shot				*shots;
extern short			isTournament;
extern short			officialFlag;
extern short			pausedFlag;
extern short			stepFlag;
extern short			chrononFlag;
extern short			useDebugger;
extern unsigned short 		lastRandSeed;
extern GenericSound	defSnds[10];  // Default robot sounds


// ----- from RoboWar.engine.feedback.c -----
extern void robotError (char *message, short shouldKillRobot);
void reportMessage(char *message1,char *message2);
void doSoundEffects(shot *cur);

// ----- from RoboWar.errors.c -----
extern void checkMemErr (char *procedureName);

// ----- from RoboWar.engine.history.c -----
extern void initHistory();
extern void updateHistory();

// ----- from RoboWar.engine.projectile.c -----
extern void trackShots();

// ----- from RoboWar.engine.physics.c -----
extern void checkCollisions( robot * who );

// ----- from RoboWar.engine.interpreter.c -----
extern void interpret();

// ----- from RoboWar.model.sounds.c -----
extern void PlayGenericSound( GenericSound * sound );

// ----- from RoboWar.engine.interrupts.c -----
extern void initRobotInterrupts(robot *who);
extern void queueInterrupts(robot *who);
extern void processInterrupts(robot *who);
extern void checkRadarInterrupt(robot *who);
extern void checkRangeInterrupt(robot *who);
extern void checkChrononInterrupt(robot *who);
extern void updateOldInterruptState(robot *who);

// ----- global variables -----
unsigned long		chronon = 0;
short				numAlive;				// Number of robots remaining alive
short				onlyTrackingShots;		// Number of chronons remaining in a combat conclusion.
robot				*who;					// the robot who we are currently processing
short				gBattleType;
short				cycleNum;				// the number of <who>'s instructions processed this chronon
short				errorInstruction;		// the instruction index for the offending instruction
short				communications[3][10];	// Channel & signal communications routes

short countTeammates(robot *who)
{
	// originally from ./Engine/Arena.c
	// this function literally counts the number of live teammates a robot has.
	short i, teammates = 0;

	if (!who->team) return 0; /* not on any team */
	for (i=0; i<numBots; i++)
		if (rob[i].team == who->team && rob[i].alive && who->number != i) teammates++;
	return teammates;
}

void checkDeath(void)
{
	// originally from ./Engine/Arena.c
	register shot *cur;
	register short loop,i,firstTeam,allSameTeam;
	
	if (who->damage <= 0 && who->deathTime == -1) {
		who->shield = 0;
		who->alive = 0;
		who->deathTime = chronon;
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
		if (who->sounds[DeathSnd].type != kGenericSoundTypeNULL)
			PlayGenericSound(&who->sounds[DeathSnd]);
		else PlayGenericSound(&defSnds[ExplosionSndID]);
		
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

void checkLegalEnergyDecrement(short amount) 
{
	// originally from ./Engine/Arena.c
	if (amount > 600 || amount < 0)
		robotError("Illegal energy usage.", true);
}

void doDamage (robot *which,short amount)
{
	// originally from ./Engine/ArenaDos.c
	if (which->shield == 0) {
		which->damage -= amount;
	}
	else if (which->shield < amount) {
		which->damage -= (amount-which->shield);
		which->shield = 0;
	}
	else which->shield -= amount;
}

short doShotDamage (robot *which, short amount, short owner) //, short hitBotID
{
	// originally from ./Engine/ArenaDos.c
	short 	oldDamage;

	/* Attribute kills to proper owner */
	oldDamage = which->damage;
	doDamage(which,amount);
	if (which->damage <= 0 && oldDamage > 0 &&  which->number != owner
		&& (rob[owner].energy > -200) && !(which->team != 0 && (which->team == rob[owner].team))) {
		rob[owner].kills++;
		//if( which->number >= 0 && which->number < 6 )
			rob[owner].killTime[ which->number ] = chronon;
		//else
		//	reportMessage("MESS UP! - killed a nonexistant robot!", "Arena:doShotDamage");
		which->killer = owner;
	}
	return which->damage < oldDamage; /* return true if robot took damage */
}

void doCollisionDamage(void)
{
	// originally from ./Engine/Arena.c
	
// OPENISSUE -- add sound support
	
	if (who->collision) {
		doDamage (who, who->collision);
		
		if (who->sounds[CollisionSnd].type != kGenericSoundTypeNULL)
			PlayGenericSound(&who->sounds[CollisionSnd]);
		else PlayGenericSound(&defSnds[CollisionSndID]);
	}
	if (who->wall) {
		doDamage (who, 5);
		
		if (who->sounds[CollisionSnd].type != kGenericSoundTypeNULL)
			PlayGenericSound(&who->sounds[CollisionSnd]);
		else PlayGenericSound(&defSnds[CollisionSndID]);
	}
}

void CalcKillPoints(robot* who)
{
	// originally from ./Engine/Arena.c
	short i;
	
	// award kill-points to 
	who->kills = 0;
	for (i=0; i<numBots; i++)
		who->kills += ( (who->killTime[i] != -1)
					 && ( who->alive || ((who->deathTime - who->killTime[i]) >= 20)) );
		
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

void doEnergyUpkeep( robot * which )
{
	if (which->alive && !which->stunned) {
		if (which->energy < which->hardware.energyMax) {
			which->energy += 2;
			if (which->energy > which->hardware.energyMax)
				which->energy = which->hardware.energyMax;
		}
		else if (who->energy > who->hardware.energyMax) {
			robot * save = who;
			who = which;
			robotError("Energy Max exceeded",true);
			who = save;
		}
		if (which->shield) {
			if (which->shield > which->hardware.shieldMax) which->shield -= 2;
			else if (which->shield > 0 && chronon%2) which->shield--;
			if (which->shield < 0) which->shield = 0;
		}
		if (which->energy < -200) { // check for energy overload
			which->damage = -10;
			which->scan = 32001;
		}
	}
}

void updateRobotState( robot * who )
{
	RobotState *state = &gArenaState.robots[who->number];
	
	state->alive = who->alive;
	state->team = who->team;
	state->x = who->letters[x_];
	state->y = who->letters[y_];
	if (who->energy < 0 || who->stunned || who->collision || who->wall) {
		state->speedX = 0;
		state->speedY = 0;
	} else {
		state->speedX = who->speedX;
		state->speedY = who->speedY;
	}
	state->teammates = countTeammates( who );
	state->energy = who->energy;
	state->shield = who->shield;
	state->aim = who->aim;
	state->damage = who->damage;
	state->look = who->look;
	state->scan = who->scan;
}



void addQueuedShots( void )
{
	if (gArenaState.shotQueueHead) {
		doSoundEffects(gArenaState.shotQueueHead);
		gArenaState.shotQueueTail->next = shots;
		shots = gArenaState.shotQueueHead;
		gArenaState.shotQueueHead = NULL;
	}
}

void addShotToQueue( shot * shot )
{
	// prepends a shot to the ArenaState's queue of shots.
	if (!gArenaState.shotQueueHead) {
		gArenaState.shotQueueTail = shot;
	}
	shot->next = gArenaState.shotQueueHead;
	gArenaState.shotQueueHead = shot;
}

void doBeginningOfChronon(void)
{
	register short i;
	
	// clear registers that change each chronon
	for (i=0; i<numBots; i++) {
		rob[i].collision = 0;
		rob[i].friend = 0;
		rob[i].wall = 0;
		rob[i].hit = 0;
	}
	
	// do shot tracking
	trackShots();
	
	// do energy maintenance, affect speeds, check for death
	for (i=0; i<numBots; i++) {
		who = rob+i;
		doEnergyUpkeep( who );
		
		if (who->alive) {
			if (who->energy > 0) {
				who->letters[x_] += who->speedX;
				who->letters[y_] += who->speedY;
			}
			who->haveDoneMoveOrShootQ = false;
		}
		
		CalcKillPoints( who ); // for the stats displays
	}
	for (i=0; i<numBots; i++) {
		who = rob+i;
		if (who->alive) {
			checkCollisions( who ); 
			doCollisionDamage();
			checkDeath();
			updateRobotState( who ); /* update all RobotStates */
		}
		// order[i] = i; /* Initialize array to randomly select order of robot evaluation */
	}
	
	gArenaCurBotNum = 0;
	cycleNum = 0;
	chrononFlag = 0;
}

void doEndingOfChronon(void)
{
	/* add the queued shots */
	addQueuedShots();
	
	/* Advance to next chronon */
	chronon++;
	if (isTournament && chronon > 1500) isBattle = 0; /* End tournaments in 1500 c */
	if (onlyTrackingShots) {
		onlyTrackingShots--;  /* Conclude after 20 chronons */
		if (!onlyTrackingShots) isBattle = 0;
	}
	
	gArenaCurBotNum = -1;
}

/*
	doRoundOfCombat() does whatever computation is necessary to take the progression of the
	battle to the next event-stop. For normal battles, event-stops occur once a chronon at
	the end of the chronon. For debugger battles, event-stops occur every instruction of the
	bot being debugged. Simple, eh? -- SR
 */
void doRoundOfCombat(void)
{
	if (gArenaCurBotNum == -1)
		doBeginningOfChronon();
	
	/* interpret all robots not in debugger mode */
	if (gArenaCurBotNum >= 0)
	while( gArenaCurBotNum<numBots ) {
		who = rob+gArenaCurBotNum;
		
		if (who->alive) {
			queueInterrupts(who);
			processInterrupts(who);
			checkRadarInterrupt(who);
			checkRangeInterrupt(who);
			checkChrononInterrupt(who);
			updateOldInterruptState(who);
			if (who->stunned) who->stunned--;
			else {
				if (who->energy > 0 && who->alive && !(gArenaCurBotNum == useDebugger && pausedFlag)) 
					for (cycleNum = 0; cycleNum<who->hardware.processorSpeed; cycleNum++)
						interpret();
/*
				// since we've changed the interactions of the robots so that
				// they are interacting ONLY with the gArenaState, this becomes
				// not only unnecessary, but also bad. -- SR
				if (who->energy < -200) {
					who->damage = -10;
					who->scan = 32001;
					checkDeath();
				}
*/
			}
		}
		else if (who->aim) {
			who->aim++;
			if (who->aim > 15) who->aim = 0; /* Done exploding */
		}
		gArenaCurBotNum++;
		cycleNum = -1;
	}
	
	/* Handle debugger stuff */
	if (pausedFlag) {
		if (cycleNum == -1) {
			gArenaCurBotNum = -2;
			who = rob+useDebugger;
			cycleNum = 0;
			stepFlag = 0;
		}
		if (stepFlag) {
			if ((gArenaState.robots[who->number].energy) > 0 && who->alive) {
				if (!who->stunned) interpret();
				cycleNum++;
			}
			else chrononFlag=1;
			stepFlag = 0;
		}
		if (chrononFlag) {
			for (;cycleNum<who->hardware.processorSpeed; cycleNum++)
				if ((gArenaState.robots[who->number].energy > 0) && who->alive && !who->stunned) interpret();
			chrononFlag = 0;
		}
		if (cycleNum >= who->hardware.processorSpeed)
			gArenaCurBotNum = numBots;
	}
	
	if(gArenaCurBotNum == numBots);
		doEndingOfChronon();
}

void prepareRobots(short repeatFlag)
{
	short who,i;
	short loop,dist,test;

	// set the seed for the random number generator
	if (!repeatFlag)
		lastRandSeed += 1 + rand() + TickCount();
	srand(lastRandSeed);
	
	// initialize all robot variables
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

void prepareArena(void)
{
	shot *cur;
	short i,j;
	
	// clear the error instruction variable so when the battle ends, we don't try
	// to go to the assembly code unless a NEW error occurs.
	errorInstruction = -1;
	
	// start with all the bots alive
	numAlive = numBots;
	
	// empty the shot list
	if (shots != NULL) {
		do {
			cur = shots->next;
			DisposePtr((Ptr)shots);
			checkMemErr("ArenaControl:prepareArena");
			shots = cur;
		} while (shots != NULL);
	}
	
	//Êclear the signal channels for each team
	for (i=0; i<3; i++)
		for (j=0; j<10; j++)
			communications[i][j] = 0;
	
	chronon = 0;
}

short setupCombat(short repeatFlag)
{
	register short i;
	short passwordGood;
	short ok;
	
	prepareArena();
	prepareRobots(repeatFlag);
	
	// don't allow the user to debug a password-protected bot unless he's entered the password
	passwordGood = 1;
	if (useDebugger != maxBots) {
		// controlChange = 1; // this had something to do with displaying controlls for the debugger
		pausedFlag = 1; // start the battle paused if we're debugging
		if (!rob[useDebugger].passwordEntered) {
			// ok = getPassword(rob[useDebugger].password);
			// OPENISSUE -- add this back!
			ok = 1;
			if (!ok) {
				reportMessage ("Sorry, incorrect password.","");
				passwordGood = 0;
			}
			else rob[useDebugger].passwordEntered = 1;
		}
	}
	else pausedFlag = 0;
	
	if(passwordGood) {
		
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
		
		isBattle = 1;
		
		initHistory();
		
		// reset the robots' kill-time variables.
		for(i=0; i<numBots; i++) {
			who = rob+i;
			who->killTime[0] = -1;
			who->killTime[1] = -1;
			who->killTime[2] = -1;
			who->killTime[3] = -1;
			who->killTime[4] = -1;
			who->killTime[5] = -1;
		}
		
		// reset the game-end timer.
		onlyTrackingShots = 0;
		
		// if we're not using the debugger, make sure we're not paused.
		if (useDebugger == maxBots) pausedFlag = 0;
	}
	return passwordGood;
}

void cleanUpAfterCombat()
{
	register short i;

	isBattle = 0; // probably not necessary.
	
	if( numBots == 2 || gBattleType == kTeamBattle )
	{
		for (i=0; i<numBots; i++)
			if (rob[i].alive)
				rob[i].svrl = 1;
	}
	else
	{
		for (i=0; i<numBots; i++)
			if (rob[i].alive)
				rob[i].svrl = 3;
	}
	
	updateHistory();
	// clearChannel(); // -- stop any errant sound.
	
	/*
	if (errorInstruction != -1) {
		changeMode(draftingBoard_);
		if (mode == draftingBoard) { // Successfully changed modes
			assembleRobot(errorInstruction);
			//GotoWordAt(errorInstruction);
		}
	}
	*/
}
