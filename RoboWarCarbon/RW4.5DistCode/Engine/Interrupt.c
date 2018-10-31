/* Interrupt.c */

/* Written 8/16/93 by David Harris

	This file contains procedures that handle interrupt
	stuff for robots in RoboWar 3.0.
*/

/* #includes */

#include <Carbon/Carbon.h>
#include "robotypes.h"
#include "Tokens.h"

/* External variables */

extern	robot			rob[maxBots];		
extern	robot 			*who;
extern	short			numAlive;
extern	long			chronons;

extern short		(*invokeDistance)(robot*);
extern short		(*invokeRadar)(robot*);

/* Prototypes */

void initRobotInterrupts(robot *who);
void doIntOn(void);
void doIntOff(void);
void doRti(void);
void doSetInt(void);
void doSetParam(void);
void setProbeParam(void);
void setHistoryParam(void);
void doFlushInt(void);
void updateOldInterruptState(robot *who);
void queueInterrupts(robot *who);
void checkRadarInterrupt(robot *who);
void checkRangeInterrupt(robot *who);
void checkChrononInterrupt(robot *who);
void signalInterrupt(robot *who);
void processInterrupts(robot *who);

/* in Arena.c */
extern void robotError(char *type, short killBotQ);
extern short countTeammates(robot *who);

/* Functions */

void initRobotInterrupts(robot *who)
{ 
	who->intmask = 0;
	who->collisionInt.proc = -1;
	who->collisionInt.param = 0;
	who->wallInt.proc = -1;
	who->wallInt.param = 0;
	who->damageInt.proc = -1;
	who->damageInt.param = 150;
	who->rangeInt.proc = -1;
	who->rangeInt.param = 600;
	who->radarInt.proc = -1;
	who->radarInt.param = 600;
	who->shieldInt.proc = -1;
	who->shieldInt.param = 25;
	who->topInt.proc = -1;
	who->topInt.param = 20;
	who->botInt.proc = -1;
	who->botInt.param = 280;
	who->leftInt.proc = -1;
	who->leftInt.param = 20;
	who->rightInt.proc = -1;
	who->rightInt.param = 280;
	who->teammatesInt.proc = -1;
	who->teammatesInt.param = 5;
	who->robotsInt.proc = -1;
	who->robotsInt.param = 6;
	who->signalInt.proc = -1;
	who->signalInt.param = 0;
	who->chrononInt.proc = -1;
	who->chrononInt.param = 0;
	doFlushInt();
	updateOldInterruptState(who); 
}

void doIntOn(void)
{ 
	who->intmask = 1;
	processInterrupts(who); 
}

void doIntOff(void)
{ 
	who->intmask = 0; 
}

void doRti(void)
{ 
	short where;

	if (who->stackPtr < 1) robotError ("Stack underflow", true);
	else {
		who->stackPtr -= 1;
		where = who->stack[who->stackPtr];
		if (where <= who->progSize && where >= 0) {
			who->progPtr = where;
			who->intmask = 1;
			processInterrupts(who);
		}
		else robotError ("Jump destination not in program", true);
	} 
}

void doSetInt(void)
{ 
	if (who->stackPtr < 2) robotError ("Stack underflow", true);
	else {
		who->stackPtr -= 2;
		if( who->stackPtr > who->progSize || who->stackPtr < 0 )
			robotError ("Interupt destination not in program", true);
		
		switch (who->stack[who->stackPtr+1]-20300) {
			case collision_: who->collisionInt.proc = who->stack[who->stackPtr]; break;
			case wall_: who->wallInt.proc = who->stack[who->stackPtr]; break;
			case damage_: who->damageInt.proc = who->stack[who->stackPtr]; break;
			case range_: who->rangeInt.proc = who->stack[who->stackPtr]; break;
			case radar_: who->radarInt.proc = who->stack[who->stackPtr]; break;
			case shield_: who->shieldInt.proc = who->stack[who->stackPtr]; break;
			case top_: who->topInt.proc = who->stack[who->stackPtr]; break;
			case bottom_: who->botInt.proc = who->stack[who->stackPtr]; break;
			case left_: who->leftInt.proc = who->stack[who->stackPtr]; break;
			case right_: who->rightInt.proc = who->stack[who->stackPtr]; break;
			case teammates_: who->teammatesInt.proc = who->stack[who->stackPtr]; break;
			case robots_: who->robotsInt.proc = who->stack[who->stackPtr]; break;
			case signal_: who->signalInt.proc = who->stack[who->stackPtr]; break;
			case chronon_: who->chrononInt.proc = who->stack[who->stackPtr]; break;
			default:  robotError ("SetInt:  Illegal interrupt name", true); break;
		}
	} 
}

void doSetParam(void)
{ 
	if (who->stackPtr < 2) robotError ("Stack underflow", true);
	else {
		who->stackPtr -= 2;
		switch (who->stack[who->stackPtr+1]-20300) {
			case collision_: who->collisionInt.param = who->stack[who->stackPtr]; break;
			case wall_: who->wallInt.param = who->stack[who->stackPtr]; break;
			case damage_: who->damageInt.param = who->stack[who->stackPtr]; break;
			case range_: who->rangeInt.param = who->stack[who->stackPtr]; break;
			case radar_: who->radarInt.param = who->stack[who->stackPtr]; break;
			case shield_: who->shieldInt.param = who->stack[who->stackPtr]; break;
			case top_: who->topInt.param = who->stack[who->stackPtr]; break;
			case bottom_: who->botInt.param = who->stack[who->stackPtr]; break;
			case left_: who->leftInt.param = who->stack[who->stackPtr]; break;
			case right_: who->rightInt.param = who->stack[who->stackPtr]; break;
			case teammates_: who->teammatesInt.param = who->stack[who->stackPtr]; break;
			case robots_: who->robotsInt.param = who->stack[who->stackPtr]; break;
			case signal_: who->signalInt.param = who->stack[who->stackPtr]; break;
			case chronon_: who->chrononInt.param = who->stack[who->stackPtr]; break;
			case probe_: setProbeParam(); break;
			case history_: setHistoryParam(); break;
			default:  robotError ("SetInt:  Illegal interrupt name", true); break;
		}
	} 
}

void setProbeParam(void)
{
	short what;
	
	
	what = who->stack[who->stackPtr]-20300;
	if (what != id_ &&  what != teammates_ && what != energy_ && what != damage_ && what != shield_
		&& what != aim_ && what != look_ && what != scan_)
		 robotError ("SetParam:  Illegal probe register", true);
	else who->probeParam = what;
}

void setHistoryParam(void)
{
	short what;
	
	what = who->stack[who->stackPtr];
	if (what <= 0 || what > historySize) robotError ("SetParam:  Illegal history value", true);
	else who->historyParam = what;
}

void doFlushInt(void)
{
	who->intq.numPending = 0;
	who->intq.collision = 0;
	who->intq.wall = 0;
	who->intq.damage = 0; 		/* why wasn't this here in version 3.1? */
	who->intq.shield = 0;
	who->intq.top = 0;
	who->intq.bot = 0;
	who->intq.left = 0;
	who->intq.right = 0;
	who->intq.signal = 0;
	who->intq.teammates = 0;
	who->intq.robots = 0;
}

void updateOldInterruptState(robot *who)
{ 
	who->collisionInt.old = who->collision;
	who->wallInt.old = 	who->letters[y_] < radius || 
						who->letters[y_] > boardSize-radius ||
						who->letters[x_] < radius ||
						who->letters[x_] > boardSize-radius;
	who->damageInt.old = who->damage;
	who->shieldInt.old = who->shield;
	who->topInt.old = who->letters[y_];
	who->leftInt.old = who->letters[x_];
	who->teammatesInt.old = countTeammates(who);
	who->robotsInt.old = numAlive;
}

void queueInterrupts(robot *who)
{ 
	if (who->collisionInt.proc != -1 && who->intq.collision == 0)
		if (who->collision && !who->collisionInt.old) {
			who->intq.collision = 1;
			who->intq.numPending++;
		}
	if (who->wallInt.proc != -1 && who->intq.wall == 0)
		if (who->wallInt.old == 0)
			if (who->letters[y_] < radius || 
				who->letters[y_] > boardSize-radius ||
				who->letters[x_] < radius ||
				who->letters[x_] > boardSize-radius) {
					who->intq.wall = 1;
					who->intq.numPending++;
				}
	if (who->damageInt.proc != -1 && who->intq.damage == 0)
		if (who->damage != who->damageInt.old && 
			who->damage < who->damageInt.param) {
			who->intq.damage = 1;
			who->intq.numPending++;
		}
	if (who->shieldInt.proc != -1 && who->intq.shield == 0)
		if (who->shieldInt.old >= who->shieldInt.param && 
			who->shield < who->shieldInt.param) {
			who->intq.shield = 1;
			who->intq.numPending++;
		}
	if (who->topInt.proc != -1 && who->intq.top == 0)
		if (who->letters[y_] <= who->topInt.param &&
			who->topInt.old > who->topInt.param) {
			who->intq.top = 1;
			who->intq.numPending++;
		}
	if (who->botInt.proc != -1 && who->intq.bot == 0)
		if (who->letters[y_] >= who->botInt.param &&
			who->topInt.old < who->botInt.param) {
			who->intq.bot = 1;
			who->intq.numPending++;
		}
	if (who->leftInt.proc != -1 && who->intq.left == 0)
		if (who->letters[x_] <= who->leftInt.param &&
			who->leftInt.old > who->leftInt.param) {
			who->intq.left = 1;
			who->intq.numPending++;
		}
	if (who->rightInt.proc != -1 && who->intq.right == 0)
		if (who->letters[x_] >= who->rightInt.param &&
			who->leftInt.old < who->rightInt.param) {
			who->intq.right = 1;
			who->intq.numPending++;
		}
	//if (who->rightInt.proc != -1 && who->intq.right == 0)
	//	if (who->letters[x_] >= who->rightInt.param &&
	//		who->leftInt.old < who->rightInt.param) {
	//		who->intq.right = 1;
	//		who->intq.numPending++;
	//	}
	if (who->teammatesInt.proc != -1 && who->intq.teammates == 0)
		if (who->teammatesInt.old <= who->teammatesInt.param &&
			countTeammates(who) < who->teammatesInt.old) {
			who->intq.teammates = 1;
			who->intq.numPending++;
		}
	if (who->robotsInt.proc != -1 && who->intq.robots == 0)
		if (who->robotsInt.old <= who->robotsInt.param &&
			numAlive < who->robotsInt.old) {
			who->intq.robots = 1;
			who->intq.numPending++;
		}
}

void checkRadarInterrupt(robot *who)
{ 
	short dist;
	
	if (who->intmask) 
		if (who->radarInt.proc != -1 && who->intq.numPending == 0) {
			dist = (*invokeRadar)(who);
			if (dist > 0 && dist <= who->radarInt.param) {
				who->intmask = 0;
				if (who->stackPtr < stackSize) {
					who->stack[who->stackPtr++] = who->progPtr;
					who->progPtr = who->radarInt.proc;
				}
				else robotError("Interrupt caused stack overflow", true);
			}
		} 
}

void checkRangeInterrupt(robot *who)
{
	short dist;
	
	if (who->intmask) 
		if (who->rangeInt.proc != -1 && who->intq.numPending == 0) {
			dist = (*invokeDistance)(who);
			if (dist > 0 && dist <= who->rangeInt.param) {
				who->intmask = 0;
				if (who->stackPtr < stackSize) {
					who->stack[who->stackPtr++] = who->progPtr;
					who->progPtr = who->rangeInt.proc;
				}
				else robotError("Interrupt caused stack overflow", true);
			}
		} 
}

void checkChrononInterrupt(robot *who)
{
	if (who->intmask)
		if (who->chrononInt.proc != -1 && who->intq.numPending == 0 &&
			chronons >= who->chrononInt.param) {
			who->intmask = 0;
			if (who->stackPtr < stackSize) {
				who->stack[who->stackPtr++] = who->progPtr;
				who->progPtr = who->chrononInt.proc;
			}
			else robotError("Interrupt caused stack overflow", true);
		}
}

void signalInterrupt(robot *who)
{
	if (who->signalInt.proc != -1 && who->intq.signal == 0) {
		who->intq.signal = 1;
		who->intq.numPending++;
	}	
}

void processInterrupts(robot *who)
{ 
	if (who->intq.numPending) {
		if (who->intmask) 
			if (who->intq.collision) {
				who->intq.numPending--;
				who->intq.collision = 0;
				if (who->collisionInt.proc != -1) {
					who->intmask = 0;
					if (who->stackPtr < stackSize) {
						who->stack[who->stackPtr++] = who->progPtr;
						who->progPtr = who->collisionInt.proc;
					}
					else robotError("Interrupt caused stack overflow", true);
				}				
			}
		if (who->intmask) 
			if (who->intq.wall) {
				who->intq.numPending--;
				who->intq.wall = 0;
				if (who->wallInt.proc != -1) {
					who->intmask = 0;
					if (who->stackPtr < stackSize) {
						who->stack[who->stackPtr++] = who->progPtr;
						who->progPtr = who->wallInt.proc;
					}
					else robotError("Interrupt caused stack overflow", true);
				}
			}
		if (who->intmask) 
			if (who->intq.damage) {
				who->intq.numPending--;
				who->intq.damage = 0;
				if (who->damageInt.proc != -1) {
					who->intmask = 0;
					if (who->stackPtr < stackSize) {
						who->stack[who->stackPtr++] = who->progPtr;
						who->progPtr = who->damageInt.proc;
					}
					else robotError("Interrupt caused stack overflow", true);
				}
			}
		if (who->intmask) 
			if (who->intq.shield) {
				who->intq.numPending--;
				who->intq.shield = 0;
				if (who->shieldInt.proc != -1) {
					who->intmask = 0;
					if (who->stackPtr < stackSize) {
						who->stack[who->stackPtr++] = who->progPtr;
						who->progPtr = who->shieldInt.proc;
					}
					else robotError("Interrupt caused stack overflow", true);
				}
			}
		if (who->intmask) 
			if (who->intq.top) {
				who->intq.numPending--;
				who->intq.top = 0;
				if (who->topInt.proc != -1) {
					who->intmask = 0;
					if (who->stackPtr < stackSize) {
						who->stack[who->stackPtr++] = who->progPtr;
						who->progPtr = who->topInt.proc;
					}
					else robotError("Interrupt caused stack overflow", true);
				}
			}
		if (who->intmask) 
			if (who->intq.bot) {
				who->intq.numPending--;
				who->intq.bot = 0;
				if (who->botInt.proc != -1) {
					who->intmask = 0;
					if (who->stackPtr < stackSize) {
						who->stack[who->stackPtr++] = who->progPtr;
						who->progPtr = who->botInt.proc;
					}
					else robotError("Interrupt caused stack overflow", true);
				}
			}
		if (who->intmask) 
			if (who->intq.left) {
				who->intq.numPending--;
				who->intq.left = 0;
				if (who->leftInt.proc != -1) {
					who->intmask = 0;
					if (who->stackPtr < stackSize) {
						who->stack[who->stackPtr++] = who->progPtr;
						who->progPtr = who->leftInt.proc;
					}
					else robotError("Interrupt caused stack overflow", true);
				}
			}
		if (who->intmask) 
			if (who->intq.right) {
				who->intq.numPending--;
				who->intq.right = 0;
				if (who->rightInt.proc != -1) {
					who->intmask = 0;
					if (who->stackPtr < stackSize) {
						who->stack[who->stackPtr++] = who->progPtr;
						who->progPtr = who->rightInt.proc;
					}
					else robotError("Interrupt caused stack overflow", true);
				}
			}
		if (who->intmask) 
			if (who->intq.teammates) {
				who->intq.numPending--;
				who->intq.teammates = 0;
				if (who->teammatesInt.proc != -1) {
					who->intmask = 0;
					if (who->stackPtr < stackSize) {
						who->stack[who->stackPtr++] = who->progPtr;
						who->progPtr = who->teammatesInt.proc;
					}
					else robotError("Interrupt caused stack overflow", true);
				}
			}
		if (who->intmask) 
			if (who->intq.robots) {
				who->intq.numPending--;
				who->intq.robots = 0;
				if (who->robotsInt.proc != -1) {
					who->intmask = 0;
					if (who->stackPtr < stackSize) {
						who->stack[who->stackPtr++] = who->progPtr;
						who->progPtr = who->robotsInt.proc;
					}
					else robotError("Interrupt caused stack overflow", true);
				}
			}
		if (who->intmask) 
			if (who->intq.signal) {
				who->intq.numPending--;
				who->intq.signal = 0;
				if (who->signalInt.proc != -1) {
					who->intmask = 0;
					if (who->stackPtr < stackSize) {
						who->stack[who->stackPtr++] = who->progPtr;
						who->progPtr = who->signalInt.proc;
					}
					else robotError("Interrupt caused stack overflow", true);
				}
			}
	}	
}