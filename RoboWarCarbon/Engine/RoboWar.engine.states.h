/*
 *  RoboWar.engine.states.h
 *  RoboWar
 *
 *  Created by Sam Rushing on Sun Jul 11 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "RoboTypes.h"

#ifndef __ROBOWAR_ENGINE_STATES__
#define __ROBOWAR_ENGINE_STATES__ (1)

/*
	RobotStates will be used to hold visible/probable states that should
	only change (in the eyes of other bots) at chronon breaks.
 */
typedef struct {
	short alive;
	short team;
	short x;				// X coordinate.
	short y;				// Y coordinate.
	short speedX;			// the bot's effective speed in the X axis.
	short speedY;			// the bot's effective speed in the Y axis.
	short teammates;		// probable TEAMMATES register.
	short energy;			// probable ENERGY register.
	short shield;			// probable SHIELD register.
	short aim;				// probable AIM register.
	short damage;			// probable DAMAGE register.
	short look;				// probable LOOK register.
	short scan;				// probable SCAN register.
} RobotState;

/*
	The ArenaState holds all the values that should remain static across a chronon
	and is updated once-a-turn on the chronon break.
 */
typedef struct {
	RobotState robots[maxBots];	// the current visible states of each participating bot.
//	shot * currentShots;	// the shots still in the arena at the beginning of the chronon.
// at this point, we'll still use the 'shots' global for the main shot list.
	shot * shotQueueHead;   // the head of the queue of shots created this chronon.
	shot * shotQueueTail;   // the tail of the above queue.
} ArenaState;

#endif
