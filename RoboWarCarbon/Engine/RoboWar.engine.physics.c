/*
 *  RoboWar.engine.physics.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Sun Jun 27 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "Tokens.h"

// ----- globals from main.c -----
extern short			numBots;
extern robot			rob[maxBots];
extern shot				*shots;

// ----- from RoboWar.engine.control.c -----
extern unsigned long	chronon;
extern short			numAlive;


void checkCollisions( robot * who )
{
	// originally from ./Engine/Arena.c

	// check for robot-robot and robot-wall collisions
	
	register short i;
	register long deltaX,deltaY;

	// check for collisions with another bot
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
	
	// check for collisions against the wall
	// and keep robots inside the arena
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

short checkHitTarget (register shot *what)
{
	// originally from ./Engine/Arena.c
	register shot *cur;
	register robot *target;
	register short i;
	register long x,y;
	register double xd, yd;
	short result = 0;
	
	// check for collisions with a robot
	// since shots get tracked before ArenaStates are updated, read directly from the bot.
	for (i=0,target = rob; i<numBots; i++,target++) {
		/* Quick check of position */
		x = what->xPosInt - target->letters[x_];
		if (abs(x) < radius) {
			y = what->yPosInt - target->letters[y_];
			if (abs(y) < radius) {
				/* Use full floating point accuracy on final check */
				xd = what->xPos - target->letters[x_];
				yd = what->yPos - target->letters[y_];
				if (xd*xd+yd*yd < radiusSquared) {
					if (!result) {
						result = 1;
						what->xAngle = 0;
					}
					
// OPENISSUE --- should move collision response to RoboWar.engine.combat.c
					
					if (what->type == missile) /* 2 x damage for missiles */
						what->energy += what->energy;
					
					else if (what->type == gun)
						switch (what->gunType) {
							case 1: /* Rubber bullets */
								what->energy = what->energy/2;
								break;
								
							/* Normal bullets default to normal damage */
							
							case 3: /* Exploding bullets */
								what->type = bigExplode;			 
								what->xAngle = 0; // this has to do with the radius of the explosion.
								break;
						}
					
					// mines do 2x damage
					else if (what->type == mine)
						what->energy += what->energy;
					
					// drones do 1/2 damage
					else if (what->type == drone)
						what->energy = what->energy/2;
					
					what->xAngle = ((unsigned int)what->xAngle | (1 << i)); // -- save the ID of the bot that gets hit.
					
					if (what->type != bigExplode)
						what->type = explode;
				}
			}
		}
	}
	
	// Check for shooting down drones
	// SR 6-27-04 -- switched the outter and inner type checks so that
	//    this loop would not be taken as often, but still be as accurate.
	if (!result && (what->type == drone)) { 
		cur = shots;
		while (cur != NULL) {
			if (cur != what
			 && (cur->type == missile || cur->type == gun || cur->type == hellBore)) {
				// drones only collide with missles, gunshots, and hellbores.
				double dx, dy;
				if ((dx = fabs(what->xPosInt - cur->xPosInt)) < 5
				 && (dy = fabs(what->yPosInt - cur->yPosInt)) < 5
				 && (dx*dx)+(dy*dy) < 25) { // added 6-27-04 - final radial check
					result = 1;
					
// OPENISSUE --- should move collision response to RoboWar.engine.combat.c
					
					what->type = explode;
					what->xAngle = -1; // Nobody
					cur->type = explode;
					cur->xAngle = -1; // Nobody
				}
			}
			cur = cur->next;
		}
	} 
	return result;
}
