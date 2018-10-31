/*
 *  RoboWar.engine.combat.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Sun Jun 27 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include <Carbon/Carbon.h>
#include "RoboTypes.h"
#include "Tokens.h"

// ----- globals from main.c -----
extern short			numBots;
extern robot			rob[maxBots];
extern short			isBattle;
extern prefStruct		gPrefs;
extern shot				*shots;
extern 	short			isTournament;
extern	short			officialFlag;

// ----- globals from RoboWar.engine.control.c -----
extern unsigned long	chronon;
extern short			numAlive;
extern	short			communications[3][10];
extern short			onlyTrackingShots;		

// ----- from RoboWar.engine.feedback.c -----
extern void robotError (char *message, short shouldKillRobot);

// ----- from RoboWar.errors.c -----
extern void checkMemErr (char *procedureName);

// ----- global variables -----
extern short gBattleType;
extern robot *who;						// the robot who we are currently processing
extern short cycleNum;					// the number of <who>'s instructions processed this chronon
extern short errorInstruction;			// the instruction index for the offending instruction

void initCombat()
{
	// originally part of doCombat() from ./Engine/Arena.c
	register short i, j;
	
	// initialize Kill-Times
	for(i=0; i<numBots; i++) 
		for(j=0; j<numBots; j++)
			rob[i].killTime[j] = -1;
}

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
		//if (who->sounds[DeathSnd] != NULL) playSound(DeathSnd,who->number);
		//else playSound(ExplosionSndID,maxBots);
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
		doDamage (who,who->collision);
		
		//if (who->sounds[CollisionSnd] != NULL) playSound(CollisionSnd,who->number);
		//else playSound(CollisionSndID,maxBots);
				
	}
	if (who->wall) {
		doDamage (who, 5);
		
		//if (who->sounds[CollisionSnd] != NULL) playSound(CollisionSnd,who->number);
		//else playSound(CollisionSndID,maxBots);
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

