/*
 *  RoboWar.engine.interpreter.c
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

// ----- globals from main.c -----
extern	double			sine[360];
extern short			numBots;
extern robot			rob[maxBots];
extern shot				*shots;
extern 	short			isTournament;
extern	short			officialFlag;
extern	short			isBattle;

// ----- from RoboWar.engine.control.c -----
extern unsigned long	chronon;
extern short			numAlive;
extern	short			communications[3][10];		
extern	short			cycleNum;

// ----- from RoboWar.engine.combat.c -----
extern robot *who;						// the robot who we are currently processing
extern void checkLegalEnergyDecrement(short amount);
extern short countTeammates(robot *who);
extern ArenaState		gArenaState;

// ----- from RoboWar.engine.projectiles.c -----
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
extern short approach(void);
extern short distance(robot*);
extern short radar(robot*);

// ----- from RoboWar.engine.interrupts.c -----
extern void doIntOn(void);
extern void doIntOff(void);
extern void doRti(void);
extern void doSetInt(void);
extern void doSetParam(void);
extern void doFlushInt(void);
extern void signalInterrupt(robot *who);
extern void checkRadarInterrupt(robot *who);
extern void checkRangeInterrupt(robot *who);

// ----- from RoboWar.engine.feedback.c -----
extern long robotErrorMessageTime;
extern void robotError (char *message, short shouldKillRobot);
extern void reportMessage(char *message1,char *message2);

typedef void (*robowarInterpreterProcPtr)(void);

// ----- from RoboWar.model.sounds.c -----
extern void PlayGenericSound( GenericSound * sound );

// ----- prototypes -----
short getVar(short where);

void doShield(short what)
{
	register short old;
	
	old = who->shield;
	if (what > 150) what = 150;
	if (what < 0) robotError ("Set shield below zero!", true);
	if (who->hardware.noNegEnergy && what > who->energy + old) 
		what = who->energy+old;
	who->shield = what;
	who->energy += old-what;
	if (who->energy > who->hardware.energyMax) who->energy = who->hardware.energyMax;
}

void broadcastSignal(short what)
{
	short i;
	
	communications[who->team-1][who->channel-1] = what;
	for (i=0; i<numBots; i++)
		if (rob[i].alive && rob[i].team == who->team && i != who->number)
			if (rob[i].signalInt.param == who->channel) signalInterrupt(rob+i);
}

void doSpeedX(short what)
{
	register short old,cost,delta;
	
	old = who->speedX;
	if (what > 20) what = 20;
	else if (what < -20) what = -20;
	cost = abs(what-old)<<1;
	if (who->hardware.noNegEnergy && cost > who->energy) {
		delta = who->energy/2;
		if (what < old) who->speedX -= delta;
		else who->speedX += delta;
		who->energy = 0;
	}
	else {
		who->speedX = what;
		checkLegalEnergyDecrement(cost);
		who->energy -= cost;
	}
}

void doSpeedY(short what)
{
	register short old,cost,delta;
	
	old = who->speedY;
	if (what > 20) what = 20;
	else if (what < -20) what = -20;
	cost = abs(what-old)<<1;
	if (who->hardware.noNegEnergy && cost > who->energy) {
		delta = who->energy/2;
		if (what < old) who->speedY -= delta;
		else who->speedY += delta;
		who->energy = 0;
	}
	else {
		who->speedY = what;
		checkLegalEnergyDecrement(cost);
		who->energy -= cost;
	}
}

void doMoveX(short what)
{
	if( who->haveDoneMoveOrShootQ == 1 && gPrefs.rules_noMoveShoot && gPrefs.showMoveAndShootAlert )
		robotError( "A Robot can't move and shoot in the same chronon, energy for the second operation is lost", false);
	if (who->hardware.noNegEnergy && abs(what)<<1 > who->energy) {
		if( who->haveDoneMoveOrShootQ  != 1 || !gPrefs.rules_noMoveShoot)
		{
			if (what < 0) who->letters[x_] -= who->energy/2;
			else who->letters[x_] += who->energy/2;
			
			who->haveDoneMoveOrShootQ = 2;
		}
		who->energy = 0;
	}
	else {
		if( who->haveDoneMoveOrShootQ  != 1 )
		{
			who->letters[x_] += what;
			who->haveDoneMoveOrShootQ = 2;
		}
		checkLegalEnergyDecrement(abs(what)<<1);
		who->energy -= abs(what)<<1;
	}
	
} 

void doMoveY(short what)
{
	if( who->haveDoneMoveOrShootQ == 1 && gPrefs.rules_noMoveShoot && gPrefs.showMoveAndShootAlert )
		robotError( "A Robot can't move and shoot in the same chronon, energy for the second operation is lost", false);
	if (who->hardware.noNegEnergy && abs(what)<<1 > who->energy) {
		if( who->haveDoneMoveOrShootQ != 1 || !gPrefs.rules_noMoveShoot)
		{
			if (what < 0) who->letters[y_] -= who->energy/2;
			else who->letters[y_] += who->energy/2;
			
			who->haveDoneMoveOrShootQ = 2;
		}
		who->energy = 0;
	}
	else {
		if( who->haveDoneMoveOrShootQ != 1 )
		{
			who->letters[y_] += what;
			who->haveDoneMoveOrShootQ = 2;
		}
		checkLegalEnergyDecrement(abs(what)<<1);
		who->energy -= abs(what)<<1;
	}
}


//--- 19 apr 97 --- This had to be changed so that it still worked.
void doSusie(void)
{
	//Handle theRes;
	//short num;
	
	/* She hates the name! */
	
	if (isTournament && officialFlag) robotError ("No undocumented commands in tournaments",true);
	/*
	else {
		theRes = GetResource('ICON',susieIcon);
		if (theRes != NULL) {
			for (num=0; num<numBots; num++) {
				if (num != who->number)
					SetUpBWIcon(&rob[num].gw[0], &theRes);	// this simply changes the icon to the susie icon.
			}
			ReleaseResource(theRes);
		}
		else SysBeep(1);
	}
	*/
}

void doHistoryStore(short what)
{
	if (who->historyParam > 30)
		who->history[who->historyParam-1] = what;
	else robotError ("Store to reserved history register",true);
}

void putVar(short what,short where)
{
	short target;
	double x,y;

	if (0<= where && 25 >= where && where != x_ && where != y_)
		who->letters[where] = what;
	else switch (where) {
		case x_: break;
		case y_: break;
		case fire_: if (what > 0) doGun(what); break;
		case energy_: break; /* no fair */
		case shield_: if (what >= 0) doShield(what); break;
		case range_: break; /* duh... */
		case aim_:  who->aim = what%360;
					if (who->aim < 0) who->aim = 360+who->aim;
					checkRadarInterrupt(who);
					checkRangeInterrupt(who);
					break;
		case speedx_: doSpeedX(what); break;
		case speedy_: doSpeedY(what); break;
		case damage_: break; /* no fair */
		case random_: break; /* !!!! */
		case missile_: if (what > 0) doMissile(what); break;
		case nuke_: if (what > 0) doNuke(what); break;
		case collision_: break; /* !?!? */
		case channel_: if (what > 0 && what < 11) who->channel = what;
						else robotError ("Invalid channel (1-10)",true);
					   break;
		case signal_: if (who->team) broadcastSignal(what); break;
		case movex_: doMoveX(what); break;
		case movey_: doMoveY(what); break;
		case joce_: doJoce(what); break;
		case radar_: break;
		case look_: who->look = what%360;
					if (who->look <0) who->look += 360;
					checkRangeInterrupt(who);
					break;
		case scan_: who->scan = what%360;
					if (who->scan <0) who->scan += 360;
					checkRadarInterrupt(who);
					break;
		case chronon_: break;
		case hell_: if (what >= 4 && what <= 20) doHellBore(what); break;
		case drone_: if (what > 0) {
					 	target = findTarget();
						if (target != -1) doDrone(what,target); 
					 }
					 break;
		case mine_: if (what > 5) doMine(what); break;
		case laser_: if (what > 0) {
						target = findLaserTarget(&x,&y);
						if (target != -1) doLaser(what,x,y,target); 
					 }
					 break;
		case susie_: doSusie(); break;  /* Another undocumented cheating feature. */
		case robots_: break;
		case friend_: break;
		case bullet_: if (what > 0) doBullet(what); break; /* Fix bug found by Jesse Barnum */
		case doppler_: break;
		case stunner_: if(what > 0) doStunner(what); break;
		case top_:  break;
		case bottom_:  break;
		case left_:  break;
		case right_:  break;
		case wall_: break;
		case teammates_: break;
		case probe_: break;
		case history_: doHistoryStore(what);
		case id_: break;
		case kills_: break;
		case approach_: break;
		default: robotError ("Unknown register",true); break;
	}
}

short doProbe(void)
{
	if (!who->hardware.probeFlag) 
		robotError("Probes not enabled.",true);
	else {
		short target = findTarget();
		if (target == -1) return 0; /* No target in sight */
		
		switch (who->probeParam) {
			case id_: return target;
			case teammates_: return gArenaState.robots[target].teammates;
			case energy_: return gArenaState.robots[target].energy;
			case damage_: return gArenaState.robots[target].damage;
			case shield_: return gArenaState.robots[target].shield;
			case aim_: return gArenaState.robots[target].aim;
			case look_: return gArenaState.robots[target].look;
			case scan_: return gArenaState.robots[target].scan;
		}
	}
	// technically, this schould never happen, since setparam() for probe
	// will disallow anything other than the above registers.
	return 0;
}

short doHistoryRecall(void)
{
	return who->history[who->historyParam-1];
}

short getVar(short where)
{
	if (where >= 0 && where <= 25)
		return who->letters[where];
	else switch(where) {
		case fire_: return 0; break;
		case energy_: return who->energy; break;
		case shield_: return who->shield; break;
		case range_: return distance(who); break;
		case aim_: return who->aim; break;
		case speedx_: return who->speedX; break;
		case speedy_: return who->speedY; break;
		case damage_: return who->damage; break;
		case random_: return (rand()%360); break;
		case missile_: return 0; break;
		case nuke_: return 0; break;
		case collision_: return who->collision; break;
		case channel_: return who->channel; break;
		case signal_: if (who->team)
						return communications[who->team-1][who->channel-1];
					  else return 0;
					  break;
		case movex_: return 0; break;
		case movey_: return 0; break;
		case joce_: return 0; break;
		case radar_: return radar(who); break;
		case look_: return who->look; break;
		case scan_: return who->scan; break;
		case chronon_: return chronon; break;
		case hell_: return 0; break;
		case drone_: return 0; break;
		case mine_: return 0; break;
		case laser_: return 0; break;
		case susie_: return 0; break;
		case robots_: return numAlive; break;
		case friend_: if (who->collision) return who->friend;
					  else return 0;
					  break;
		case bullet_: return 0; break;
		case doppler_: return doppler(); break;
		case stunner_: return 0; break;
		case top_:  return 0; break;
		case bottom_:  return 0; break;
		case left_:  return 0; break;
		case right_:  return 0; break;
		case wall_: return who->wall;
		case teammates_: return countTeammates(who);
		case probe_: return doProbe();
		case history_: return who->history[who->historyParam-1];
		case id_: return who->number;
		case kills_: return who->kills;
		case approach_: return approach();
		default: robotError("Unknown register",true);
	}
	return 0;
}

void doPlus(void)
{
	long val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = who->stack[who->stackPtr-1]+
			  who->stack[who->stackPtr-2];
		if (val < 20000 && val > -20000) {
			who->stackPtr -= 2;
			who->stack[who->stackPtr++] = val;
		}
		else robotError ("Number out of bounds.",true);
	}
}

void doMinus(void)
{
	long val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = who->stack[who->stackPtr-2]-
			  who->stack[who->stackPtr-1];
		if (val < 20000 && val > -20000) {
			who->stackPtr -= 2;
			who->stack[who->stackPtr++] = val;
		}
		else robotError ("Number out of bounds.",true);
	}
}

void doTimes(void)
{
	long val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = who->stack[who->stackPtr-1]*
			  who->stack[who->stackPtr-2];
		if (val < 20000 && val > -20000) {
			who->stackPtr -= 2;
			who->stack[who->stackPtr++] = val;
		}
		else robotError ("Number out of bounds.",true);
	}
}

void doDivide(void)
{
	short val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		if (who->stack[who->stackPtr-1] == 0) 
			robotError("Division by zero",true);
		else {
			val = who->stack[who->stackPtr-2]/
				  who->stack[who->stackPtr-1];
			who->stackPtr -= 2;
			who->stack[who->stackPtr++] = val;
		}
	}
}

void doGreater(void)
{
	short val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = (who->stack[who->stackPtr-2] >
			  who->stack[who->stackPtr-1]);
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doLess(void)
{
	short val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = (who->stack[who->stackPtr-2] <
			  who->stack[who->stackPtr-1]);
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doEqual(void)
{
	short val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = (who->stack[who->stackPtr-1] ==
			  who->stack[who->stackPtr-2]);
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doNotEqual(void)
{
	short val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = (who->stack[who->stackPtr-1] !=
			  who->stack[who->stackPtr-2]);
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doStore(void)
{
	short what,where;

	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		where = who->stack[who->stackPtr-1];
		if (where >= 20300 && where < 20400) {
			who->stackPtr -= 2;
			what = who->stack[who->stackPtr];
			putVar(what,where-20300);
		}
		else robotError("Variable not provided",true);
	}
}

void doDrop(void)
{
	if (who->stackPtr < 1) robotError("Stack underflow",true);
	else who->stackPtr -= 1;
}

void doSwap(void)
{
	short temp;

	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		temp = who->stack[who->stackPtr-1];
		who->stack[who->stackPtr-1] =
			who->stack[who->stackPtr-2];
		who->stack[who->stackPtr-2] = temp;
	}
}

void doRoll(void)
{
	short places,temp,i;

	if (who->stackPtr < 3) robotError ("Stack underflow",true);
	else {
		who->stackPtr -= 1;
		places = who->stack[who->stackPtr];
		if (who->stackPtr < places+1) robotError ("Stack underflow",true);
		else {
			temp = who->stack[who->stackPtr-1];
			for (i=who->stackPtr-1; i>who->stackPtr-1-places;i--)
				who->stack[i] = who->stack[i-1];
			who->stack[who->stackPtr-1-places] = temp;
		}
	}
}

void doJump(void)
{
	short where;

	if (who->stackPtr < 1) robotError ("Stack underflow",true);
	else {
		who->stackPtr -= 1;
		where = who->stack[who->stackPtr];
		if (where <= who->progSize && where >= 0)
			who->progPtr = where;
		else robotError ("Jump destination not in program",true);
	}
}

void doCall(void)
{
	short where;

	if (who->stackPtr < 1) robotError ("Stack underflow",true);
	else {
		who->stackPtr -= 1;
		where = who->stack[who->stackPtr];
		if (where <= who->progSize && where >= 0) {
			who->stack[who->stackPtr++] = who->progPtr;
			who->progPtr = where;
		}
		else robotError ("Jump destination not in program",true);
	}
}

void doDuplicate(void)
{
	short what;
	
	what = who->stack[who->stackPtr-1];
	if (who->stackPtr < stackSize) 
		who->stack[who->stackPtr++] = what;
	else robotError ("Stack overflow",true);
}

void doIf(void)
{
	short where;

	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		who->stackPtr -= 2;
		where = who->stack[who->stackPtr+1];
		if (who->stack[who->stackPtr]) {
			if (where <= who->progSize && where >= 0) {
				who->stack[who->stackPtr++] = who->progPtr;
				who->progPtr = where;
			}
			else robotError ("Jump destination not in program",true);
				who->progPtr = where;
			
		}
	}
}

void doIfe(void)
{
	short where1,where2;

	if (who->stackPtr < 3) robotError ("Stark underflow",true);
	else {
		who->stackPtr -= 3;
		where1 = who->stack[who->stackPtr+2];
		where2 = who->stack[who->stackPtr+1];
		if (who->stack[who->stackPtr]) {
			if (where2 <= who->progSize && where2 >= 0) {
				who->stack[who->stackPtr++] = who->progPtr;
				who->progPtr = where2;
			}
			else robotError ("Jump destination not in program",true);
				who->progPtr = where2;
		}
		else {
			if (where1 <= who->progSize && where1 >= 0) {
				who->stack[who->stackPtr++] = who->progPtr;
				who->progPtr = where1;
			}
			else robotError ("Jump destination not in program",true);
				who->progPtr = where1;
		}
	}
}

void doRecall(void)
{
	short what;

	who->stackPtr -= 1;
	what = who->stack[who->stackPtr];
	if (what >= 20300 && what < 20400) 
		who->stack[who->stackPtr++] = getVar(what-20300);
	else robotError ("Variable not provided",true);
}

void doAnd(void)
{
	short val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = who->stack[who->stackPtr-1] &&
			  who->stack[who->stackPtr-2];
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doOr(void)
{
	short val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = who->stack[who->stackPtr-1] ||
			  who->stack[who->stackPtr-2];
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doEor(void)
{
	short val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = (who->stack[who->stackPtr-1] ||
			  who->stack[who->stackPtr-2]) -
			  (who->stack[who->stackPtr-1] &&
			  who->stack[who->stackPtr-2]);
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doMod(void)
{
	short val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		if (who->stack[who->stackPtr-1] == 0) 
			robotError("Mod by zero",true);
		else {
			val = who->stack[who->stackPtr-2] %
				  who->stack[who->stackPtr-1];
			who->stackPtr -= 2;
			who->stack[who->stackPtr++] = val;
		}
	}
}

void doBeep(void)
{
	if (gPrefs.soundFlag) SysBeep(1);
}

void doChs(void)
{
	if (who->stackPtr < 1) robotError("Stack underflow",true);
	else who->stack[who->stackPtr-1] *= -1;
}

void doNot(void) /* a.k.a. Don't */
{
	if (who->stackPtr < 1) robotError("Stack underflow",true);
	else who->stack[who->stackPtr-1] = !who->stack[who->stackPtr-1];
}

void doArcTan(void)
{
	double val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = atan2(-who->stack[who->stackPtr-1],who->stack[who->stackPtr-2]);
		/* Note: invert y value because screen is inverted */
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = (short)(450.5-(val*radToDeg))%360;
	}
}

void doAbs(void)
{
	if (who->stackPtr < 1) robotError("Stack underflow",true);
	else who->stack[who->stackPtr-1] = abs(who->stack[who->stackPtr-1]);
}

void doSin(void)
{
	double val;
	double sgn = 1;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		if (who->stack[who->stackPtr-2] < 0) {
			who->stack[who->stackPtr-2] *= -1;
			sgn = -1.0;
		}
		val = sgn*who->stack[who->stackPtr-1]*sine[(who->stack[who->stackPtr-2]+270)%360];
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doCos(void)
{
	double val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		if (who->stack[who->stackPtr-2] < 0) who->stack[who->stackPtr-2] *= -1;
		val = who->stack[who->stackPtr-1]*sine[who->stack[who->stackPtr-2]%360];
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doTan(void)
{
	double val;
	double sgn = 1;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		if (who->stack[who->stackPtr-2] < 0) {
			who->stack[who->stackPtr-2] *= -1;
			sgn = -1.0;
		}
		val = sgn*who->stack[who->stackPtr-1]*
			  sine[who->stack[who->stackPtr-2]%360]/
			  sine[(who->stack[who->stackPtr-2]+270)%360];
		if (val > 19999) val = 19999;
		else if (val < -19999) val = -19999;
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doSqrt(void)
{
	if (who->stackPtr < 1) robotError("Stack underflow",true);
	else if (who->stack[who->stackPtr-1] < 0) 
		robotError("Square root of negative number.",true);
	else who->stack[who->stackPtr-1] = sqrt(who->stack[who->stackPtr-1]);
}

void doIcon(short which)
{
	who->icon = which;
	cycleNum--;
}

void doPrint(void)
{
	Str255 noteText, explanationText;
	
	if (who->stackPtr < 1) robotError("Stack underflow",true);
	else {
		CopyPascalStringToC(who->name, explanationText);
		sprintf (noteText, "Robot %s:", explanationText);
		sprintf (explanationText,"Prints %d",who->stack[who->stackPtr-1]);
		reportMessage(noteText, explanationText);
		
		cycleNum--; /* Prints top of stack in zero cycles, for debugging */
	}
}

void doSync(void)
{
	cycleNum = who->hardware.processorSpeed; /* Pause to end of chronon */
}

void doVStore(void)
{
	short where;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		where = who->stack[who->stackPtr-1];
		if (where >= 0 && where <= 100) /* Check that it is a legitimite address */
			who->vector[where] = who->stack[who->stackPtr-2];
		who->stackPtr -= 2;
	}	
}

void doVRecall(void)
{
	short where;
	
	if (who->stackPtr < 1) robotError("Stack underflow",true);
	else {
		where = who->stack[who->stackPtr-1];
		if (where >= 0 && where <= 100)
			who->stack[who->stackPtr-1] = who->vector[where];
		else who->stack[who->stackPtr-1] = 0;
	}
}

void doDist(void)
{
	double val;
	long a,b;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		a = who->stack[who->stackPtr-1];
		b = who->stack[who->stackPtr-2];
		val = sqrt(a*a+b*b);
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doIfg(void)
{
	short where;

	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		who->stackPtr -= 2;
		where = who->stack[who->stackPtr+1];
		if (who->stack[who->stackPtr]) {
			if (where <= who->progSize && where >= 0) who->progPtr = where;
			else robotError ("Jump destination not in program",true);
		}
	}
}

void doIfeg(void)
{
	short where1,where2;

	if (who->stackPtr < 3) robotError ("Stack underflow",true);
	else {
		who->stackPtr -= 3;
		where1 = who->stack[who->stackPtr+2];
		where2 = who->stack[who->stackPtr+1];
		if (who->stack[who->stackPtr]) {
			if (where2 <= who->progSize && where2 >= 0) who->progPtr = where2;
			else robotError ("Jump destination not in program",true);
		}
		else {
			if (where1 <= who->progSize && where1 >= 0) who->progPtr = where1;
			else robotError ("Jump destination not in program",true);
		}
	}
}

void doDebug(void)
{
/*
	if (rob+useDebugger == who) {
		drawDebuggerInfo();
		pausedFlag = 1;
		cycleNum = who->hardware.processorSpeed; // syncronize
		setButtonsPaused();
	}
	else */
	cycleNum--;
}

void doSnd(short which)
{
	PlayGenericSound(&who->sounds[which]);
	cycleNum--;
}

void doMrb(void)
{
	//short itemHit;
	//DialogPtr myDialog;
	//ModalFilterUPP filterUPP;
	
	if (isTournament && officialFlag) robotError ("No undocumented commands in tournaments",true);
	/*
	else {
		myDialog = GetNewDialog(MRBDlogID, NULL, (WindowPtr)-1);
		installButtonOutline(myDialog,3);
		messageTime = TickCount();
		
		do {
			filterUPP =  NewModalFilterProc(&timeOutFilter);
			ModalDialog(filterUPP, &itemHit);
			DisposeRoutineDescriptor(filterUPP);
		} while (itemHit != 1);
		
		DisposeDialog(myDialog);
	}
	*/
}

void doDropAll(void)
{
	who->stackPtr = 0;
}

void doMax(void)
{
	long val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = (who->stack[who->stackPtr-1] >
			  who->stack[who->stackPtr-2]) ?
			  who->stack[who->stackPtr-1]  :
			  who->stack[who->stackPtr-2];
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doMin(void)
{
	long val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = (who->stack[who->stackPtr-1] >
			  who->stack[who->stackPtr-2]) ?
			  who->stack[who->stackPtr-2]  :
			  who->stack[who->stackPtr-1];
		who->stackPtr -= 2;
		who->stack[who->stackPtr++] = val;
	}
}

void doArcCos(void)
{
	double val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = who->stack[who->stackPtr-1]/(double)who->stack[who->stackPtr-2];
		if (val < -1 || val > 1) robotError ("-1 ≤ Num / Denom ≤ 1 for arccos",true);
		else {
			val = acos(val);
			who->stackPtr -= 2;
			who->stack[who->stackPtr++] = (short)(val*radToDeg);
		}
	}
}

void doArcSin(void)
{
	double val;
	
	if (who->stackPtr < 2) robotError ("Stack underflow",true);
	else {
		val = who->stack[who->stackPtr-1]/(double)who->stack[who->stackPtr-2];
		if (val < -1 || val > 1) robotError ("-1 ≤ Num / Denom ≤ 1 for arcsin",true);
		else {
			val = asin(val);
			who->stackPtr -= 2;
			who->stack[who->stackPtr++] = (short)(val*radToDeg);
		}
	}
}

void doEnd(void) {robotError ("End of code reached",true);}
void doNop(void) {}

void doIcon0(void) {doIcon(0);}
void doIcon1(void) {doIcon(1);}
void doIcon2(void) {doIcon(2);}
void doIcon3(void) {doIcon(3);}
void doIcon4(void) {doIcon(4);}
void doIcon5(void) {doIcon(5);}
void doIcon6(void) {doIcon(6);}
void doIcon7(void) {doIcon(7);}
void doIcon8(void) {doIcon(8);}
void doIcon9(void) {doIcon(9);}

void doSnd0(void) {doSnd(0);}
void doSnd1(void) {doSnd(1);}
void doSnd2(void) {doSnd(2);}
void doSnd3(void) {doSnd(3);}
void doSnd4(void) {doSnd(4);}
void doSnd5(void) {doSnd(5);}
void doSnd6(void) {doSnd(6);}
void doSnd7(void) {doSnd(7);}
void doSnd8(void) {doSnd(8);}
void doSnd9(void) {doSnd(9);}

void interpret(void)
{
	// originally from ./Engine/Arena.c
	static robowarInterpreterProcPtr interpretComparator[8] = {
			doPlus, doMinus, doTimes, doDivide,
			doGreater, doLess, doEqual, doNotEqual
		};
	static robowarInterpreterProcPtr interpretOperator[65] = {
		doStore, doDrop, doSwap, doRoll, doJump,
		doCall, doDuplicate, doIf, doIfe, doRecall,
		doEnd, doNop, // new
		doAnd, doOr, doEor, doMod, doBeep,
		doChs, doNot, doArcTan, doAbs, doSin,
		doCos, doTan, doSqrt,
		doIcon0,doIcon1, doIcon2, doIcon3, doIcon4, // new
		doIcon5, doIcon6, doIcon7, doIcon8, doIcon9, // new
		doPrint, doSync, doVStore, doVRecall, doDist,
		doIfg, doIfeg, doDebug,
		doSnd0, doSnd1, doSnd2, doSnd3, doSnd4, // new
		doSnd5, doSnd6, doSnd7, doSnd8, doSnd9, // new
		doIntOn, //needs adjust
		doIntOff, //needs adjust
		doRti, //needs adjust
		doSetInt, //needs adjust
		doSetParam, //needs adjust
		doMrb, doDropAll,
		doFlushInt, //needs adjust
		doMax, doMin, doArcCos, doArcSin
		};
	
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
		interpretComparator[code - 20000]();
	}
	else if (code >= 20100 && code <= 20164) {
		interpretOperator[code - 20100]();
	}
	else {
		robotError ("Unidentified instruction",true);
	}
}
