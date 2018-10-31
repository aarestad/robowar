/*
 *  RoboWar.engine.projectiles.c
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
extern short			isTournament;
extern short			officialFlag;
extern GenericSound	defSnds[10];  // Default robot sounds

// ----- from RoboWar.engine.control.c -----
extern unsigned long	chronon;
extern short			numAlive;

// ----- from RoboWar.engine.combat.c -----
extern ArenaState		gArenaState;
extern robot			*who;			// the robot who we are currently processing
extern short doShotDamage (robot *which, short amount, short owner);
extern void	checkLegalEnergyDecrement(short what);
extern void addShotToQueue( shot * shot );

// ----- from RoboWar.engine.physics.c -----
extern short checkHitTarget (register shot *what);

// ----- from RoboWar.engine.feedback.c -----
extern void robotError(char *type, Boolean KillRobotQ);
extern void reportMessage(char *message1,char *message2);

// ----- from RoboWar.errors.c -----
extern void checkMemErr(char *proc);

// ----- from RoboWar.model.sounds.c -----
extern void PlayGenericSound( GenericSound * sound );


void killShot(register shot *what)
{
	// originally from ./Engine/Arena.c
	register shot *cur;
	
	cur = shots;
	if (cur == what) 
		shots = what->next;
	else {
		while (cur->next != what) cur = cur->next;
		cur->next = cur->next->next;
	}
	DisposePtr((Ptr)what);
	checkMemErr("RoboWar.engine.combat:killShot");
}

void completeExplosion(register shot *what)
{
	// originally from ./Engine/Arena.c
	// SR 07-22-04 -- modified so that shots do damage to all hit bots.
	
// OPENISSUE -- add sound support
	robot *who;
	short damaged = 1;
	short i;
	
	for (i=0; i<maxBots; i++) {
		if ((unsigned int)what->xAngle & (1<<i)) {
			who = rob+i;
			if (what->gunType == hellBore) who->shield = 0;
			else if (what->gunType == stunner) who->stunned += what->energy/4;
			else damaged = doShotDamage(who,what->energy,what->owner);//, what->xAngle

			if (!damaged) {
				if (who->sounds[ShieldHitSnd].type != kGenericSoundTypeNULL)
					PlayGenericSound(&who->sounds[ShieldHitSnd]);
				else PlayGenericSound(&defSnds[ShotHitSndID]);
				if (who->hit == 0) who->hit = 1; /* shield hit icon */
			}
			else {
				if (who->sounds[HitSnd].type != kGenericSoundTypeNULL)
					PlayGenericSound(&who->sounds[HitSnd]);
				else PlayGenericSound(&defSnds[ShotHitSndID]);
				who->hit = 2; /* robot hit icon */
			}
		}
		else PlayGenericSound(&defSnds[ShotHitSndID]);
	}
	killShot(what);
}

void completeLaser(register shot *what)
{
	// originally from ./Engine/Arena.c
	what->type = explode;
	what->xPosInt = what->xAngle;
	what->yPosInt = what->yAngle;
	what->xAngle = what->gunType;
	/* The following line produces buggy results: what->energy *= .2; */
	what->energy = what->energy / 5;
}

void explodeNuke (register shot *what)
{
	// originally from ./Engine/Arena.c
	
// OPENISSUE -- add sound support
	register short i;
	register long x,y,z;
	register shot *cur;
	
	/* Blow up all nearby robots */
	z = (what->xAngle+radius) * (what->xAngle+radius);
	for (i=0; i<numBots; i++) {
		// since shots get tracked before ArenaStates are updated, read directly from the bot.
		x = rob[i].letters[x_] - what->xPosInt;
		y = rob[i].letters[y_] - what->yPosInt;
		if (x*x+y*y < z) doShotDamage(rob+i,what->energy*2,what->owner); //,i
	}
	PlayGenericSound(&defSnds[BangSndID]);
	
	/* Blow up all nearby drones */
	z = what->xAngle * what->xAngle; // recalculate r^2 since shots have no radius. -- SR 7/22/04
	for (cur = shots; cur != NULL; cur = cur->next)
		if (cur->type == drone) {
			x = cur->xPosInt-what->xPosInt;
			y = cur->yPosInt-what->yPosInt;
			if (x*x+y*y < z) {
				cur->type = explode;
				cur->xAngle = 0; // damage nobody on clean-up
			}
		}
	
	killShot(what);
}

void droneSeek(shot *cur)
{
	// originally from ./Engine/Arena.c
	register short x,y,tX,tY;
					  		
	x = cur->xPosInt; y = cur->yPosInt;
	tX = gArenaState.robots[(short)cur->yAngle].x;
	tY = gArenaState.robots[(short)cur->yAngle].y;
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

void trackShots(void)
{
	// originally from ./Engine/Arena.c
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
					  else if (!checkHitTarget(cur)) {
							cur->xPos += cur->xAngle;
					  		cur->yPos += cur->yAngle;
					  		cur->xPosInt = cur->xPos;
					  		cur->yPosInt = cur->yPos;
						  	if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
						  	  	cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					  		else checkHitTarget(cur);
					  }
					  break;
			case missile: cur->xPos += cur->xAngle;
						  cur->yPos += cur->yAngle;
					  	  cur->xPosInt = cur->xPos;
					  	  cur->yPosInt = cur->yPos;
						  if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
						  	  cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					 	  else checkHitTarget(cur); 
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
					  else if (!checkHitTarget(cur)) {
							cur->xPos += cur->xAngle;
					  		cur->yPos += cur->yAngle;
						  	cur->xPosInt = cur->xPos;
					 		cur->yPosInt = cur->yPos;
						  	if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
						  	  	cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					  		else checkHitTarget(cur);
					  }
					  break;
			case mine: checkHitTarget(cur); break;
			case newMine: cur->xAngle -= 1;
					  	  if (!cur->xAngle) cur->type = mine;
						  break;
			case drone: droneSeek(cur);
					 	checkHitTarget(cur); 
						break;
			case laser: completeLaser(cur); break;
			case stunner: cur->xPos += cur->xAngle;
					  cur->yPos += cur->yAngle;
					  cur->xPosInt = cur->xPos;
					  cur->yPosInt = cur->yPos;
					  if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
					  	  cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					  else if (!checkHitTarget(cur)) {
							cur->xPos += cur->xAngle;
					  		cur->yPos += cur->yAngle;
					  		cur->xPosInt = cur->xPos;
					  		cur->yPosInt = cur->yPos;
						  	if (cur->xPosInt>boardSize || cur->xPosInt<0 ||
						  	  	cur->yPosInt>boardSize || cur->yPosInt<0) killShot(cur);
					  		else checkHitTarget(cur);
					  }
					  break;

			default: break;
		}
		cur = cur->next;
	}
}

inline void getTargetAndDistance( robot * who, short theta, short * id, short * distance )
{
	/* Range algorithm:  see what robots intersect line of sight.
	
		t = distance along line of sight closest to target being checked
		m = cos (angle)
		n = sin (angle)
		
		1) Compute t, distance along aim vector
		2) Use crude check to see if target is in general area
		3) Use precise formula to see if robot circle is hit

		SR -- Good lord! Harris used Vector math like water. It's all over the
		place and really hard to figure out. I've done my best to comment
		what I can and simplify where I can.
	*/

	/* for paramaterized line of fire */
	/* x=m*t + x', y=n*t + y' */
	// [m n] is the unit vector pointing in the direction os the tracking robot's AIM register.
	register double m = sine[(theta+270)%360];
	register double n = -sine[(theta)%360];
	
	double t; // temporary distance register
	
	short i, target = maxBots;
	short dist = 0;
	
	for (i=0; i< numBots; i++)
		if (gArenaState.robots[i].alive && i != who->number) {
			// [dx dy] is the distance vector pointing directly toward the target bot.
			register double dx = gArenaState.robots[i].x - who->letters[x_];
			register double dy = gArenaState.robots[i].y - who->letters[y_];
			
			/* step 1: compute the distance */
			// Compute magnitude of R projected onto A where R is the range vector and A is the aim unit vector.
			// NOTE: replaced the following line, because SOMEONE forgot the law of sines: sin^2 + cos^2 == 1
			//       not to mention that the unit vector always has a magnitude of 1.
			// ALSO: a side affect of this whole formula is that the the target will appear to be SLIGHTLY
			//       farther away if the tracking robot has the aim dead-on centered on the target. What this
			//       formula essentially does is draw a circle centered exactly halfway between the bots
			//       with its perimeter running through the center of both. Then t is actually the length of
			//       the chord from the center of the tracking bot, across this circle and passing through the
			//       actually seen point. 
			// t = (m*c + n*d - m*a - n*b)/(m*m+n*n);
			t = (m*dx + n*dy); // == R¥A/|A| == R¥A/1 == R¥A
			
			/* check if the target is in sights */
			// -- SR added: step 2 (from prev. distance()), and using short-circuit conditions
			// instead of nested IF statements
			
			// first, check if the target is within 90 deg to either side of the tracker's AIM
			if (t > 0) {
				// T = [tx ty] is the vector from the 'seen' point of the target bot to the center of the
				// target bot. It makes a right angle the tle line 't' (calculated above). This is not from
				// the actually seen point, but from the spot on the endpoint of the chord. The actually seen
				// point would be between 0 and 10 units along the chord.
				register double tx;
				register double ty;
				
				/* step 2: based on the Manhattan Metric check */
				// this determines if the distance vector T falls within the target robot's 20x20 square.
				// an ACTUAL MM check would use the formula: (fabs(ty)+fabs(tx) <= 20)
				// I've combined this step with the calculations of tx and ty to avoid unnecessary calculations.
				if ((fabs(tx = m*t-dx) <= radius) && (fabs(ty = n*t-dy) <= radius)
				
				 /* step 3: a full-precision check */
				 // SR 7/22/04 -- added the cast to double so the Left side would not get cast to int.
				 && ( tx*tx + ty*ty < (double)(radiusSquared-9))
				 
				 /* now we know that the robot is in sights, so check if it is the closest */
				 && (dist == 0 || t < dist)) {
					// if all of the above, record this robot as the closest target.
					dist = (short)t;
					target = i;
				}
			}
		}
	
	/* don't shoot own team member */
	if (dist && (who->team == 0 || who->team != gArenaState.robots[target].team)) {
		*distance = dist;
		*id = target;
	} else {
		*distance = 0;
		*id = -1;
	}
}

short findTarget(void) /* For finding drone targets */
{
	short target, dist;
	
	getTargetAndDistance( who, who->aim+who->look, &target, &dist );
	
	return target;
}

short findLaserTarget(double *x,double *y)
{
	/* for paramaterized line of fire */
	/* tx=sin(theta)*dist + x', ty=cos(theta)*dist + y' */
	double sineTheta = sine[(who->aim+who->look+270)%360]; // previously: m
	double cosineTheta = -sine[(who->aim+who->look)%360]; // previously: n
	
	double t;
	
	/* coordinates of robots */
	register long x1,y1, x2,y2; // previously: a,b, c,d
	register long tx,ty; // see the formula above.
	
	short i, target = maxBots;
	short dist = 0;
	
	x1 = who->letters[x_];
	y1 = who->letters[y_];
	
	for (i=0; i< numBots; i++)
		if (gArenaState.robots[i].alive && i != who->number) {
			x2 = gArenaState.robots[i].x;
			y2 = gArenaState.robots[i].y;
			
			/* compute the distance */
			// replaced the following line, because SOMEONE forgot the law of sines: sin^2 + cos^2 == 1
			t = (sineTheta*x2 + cosineTheta*y2 - sineTheta*x1 - cosineTheta*y1);
			// t = (m*c + n*d - m*a - n*b)/(m*m+n*n);
			
			/* check if the target is in sights */
			// skips step 2 from the above function.
			tx = (sineTheta*t+x1-x2); ty = (cosineTheta*t+y1-y2);
			if ((t > 0) && ((tx*tx)+(ty*ty) < (radiusSquared-9))
			 && (dist == 0 || t < dist)) {
				dist = (short)t;
				target = i;
				
				/* additions from the function above specifically for Lasers */
				*x = sineTheta*t + x1;
				*y = cosineTheta*t + y1;
			}
		}
		
	/* Don't shoot own team member */
	if (who->team && who->team == gArenaState.robots[target].team)
	 	dist = 0;
	
	if (dist) return target;
	else return -1;
}

shot *newShot(BYTE type)
{
	register shot *cur;

	cur = (shot*)NewPtr(sizeof(shot));
	
	cur->type = type;
	cur->gunType = type;
	cur->owner = who->number;
	cur->next = NULL;
	//cur->soundFlag = 1;
	
	addShotToQueue( cur );
	
	return cur;
}

void doGun(short what)
{
	register shot *cur;
	register double x,y;

	if( gPrefs.rules_noMoveShoot && who->haveDoneMoveOrShootQ == 2 && gPrefs.showMoveAndShootAlert )
		robotError( "A Robot can't move and shoot in the same chronon, energy for the second operation is lost",false );

	if( (!gPrefs.rules_noMoveShoot) || who->haveDoneMoveOrShootQ != 2 )
	{
		cur = newShot(gun);
		x = sine[(270+who->aim)%360];
		y = -sine[who->aim];
		cur->xPos = who->letters[x_]+x*(radius+1);
		cur->yPos = who->letters[y_]+y*(radius+1);
		cur->xPosInt = cur->xPos;
		cur->yPosInt = cur->yPos;
		cur->xAngle = x*6.0;
		cur->yAngle = y*6.0;
		cur->gunType = who->hardware.gunType;
		
		if (what > who->hardware.energyMax) what = who->hardware.energyMax;
		if (who->hardware.noNegEnergy && what > who->energy) 
			what = who->energy;
		checkLegalEnergyDecrement(what);
		cur->energy = what;
		//who->energy -= what;
		
		who->haveDoneMoveOrShootQ = 1;
	}
	
	if (what > who->hardware.energyMax) what = who->hardware.energyMax;
	if (who->hardware.noNegEnergy && what > who->energy) 
		what = who->energy;
	checkLegalEnergyDecrement(what);
	who->energy -= what;
}

void doMissile (short what)
{
	register shot *cur;
	register double x,y;
	
	if (!who->hardware.missileFlag) 
		robotError("Missiles not enabled.",true);
	else {
	
		if( gPrefs.rules_noMoveShoot && who->haveDoneMoveOrShootQ == 2 && gPrefs.showMoveAndShootAlert )
			robotError( "A Robot can't move and shoot in the same chronon, energy for the second operation is lost",false );
			
		if( (!gPrefs.rules_noMoveShoot) || who->haveDoneMoveOrShootQ != 2 )
		{
			cur = newShot(missile);
			x = sine[(270+who->aim)%360];
			y = -sine[who->aim];
			cur->xPos = who->letters[x_]+x*(radius+1);
			cur->yPos = who->letters[y_]+y*(radius+1);
			cur->xPosInt = cur->xPos;
			cur->yPosInt = cur->yPos;
			cur->xAngle = x*5;
			cur->yAngle = y*5;
			if (fabs(cur->xAngle) < 0.001) cur->xAngle = 0;
			if (fabs(cur->yAngle) < 0.001) cur->yAngle = 0;
			//cur->gunType = missile;
			//cur->soundFlag = 1;
			
			if (what > who->hardware.energyMax) what = who->hardware.energyMax;
			if (who->hardware.noNegEnergy && what > who->energy) 
				what = who->energy;
			checkLegalEnergyDecrement(what);
			cur->energy = what;
			//who->energy -= what;
		
			who->haveDoneMoveOrShootQ = 1;
		}
		
		if (what > who->hardware.energyMax) what = who->hardware.energyMax;
		if (who->hardware.noNegEnergy && what > who->energy) 
			what = who->energy;
		checkLegalEnergyDecrement(what);
		who->energy -= what;
	}
}

void doNuke (short what) /* TacNuke!!!! */
{
	register shot *cur;

	if (!who->hardware.tacNukeFlag) 
		robotError("TacNukes not enabled.",true);
	else {
		if( gPrefs.rules_noMoveShoot && who->haveDoneMoveOrShootQ == 2 && gPrefs.showMoveAndShootAlert )
			robotError( "A Robot can't move and shoot in the same chronon, energy for the second operation is lost", false );
		if( (!gPrefs.rules_noMoveShoot) || who->haveDoneMoveOrShootQ != 2 )
		{
			cur = newShot(tacNuke);
			cur->xPos = who->letters[x_];
			cur->yPos = who->letters[y_];
			cur->xPosInt = cur->xPos;
			cur->yPosInt = cur->yPos;
			cur->xAngle = 0; /* stage of device */
			cur->yAngle = 0;
			//cur->gunType = tacNuke;
			//cur->soundFlag = 0;
			
			if (what > who->hardware.energyMax) what = who->hardware.energyMax;
			if (who->hardware.noNegEnergy && what > who->energy) 
				what = who->energy;
			checkLegalEnergyDecrement(what);
			cur->energy = what;
			//who->energy -= what;
		
			who->haveDoneMoveOrShootQ = 1;
		}
		
		if (what > who->hardware.energyMax) what = who->hardware.energyMax;
		if (who->hardware.noNegEnergy && what > who->energy) 
			what = who->energy;
		checkLegalEnergyDecrement(what);
		who->energy -= what;
	}
}

void doJoce(short what)
{
#pragma unused (what)

	register shot *cur;

	if (isTournament && officialFlag) robotError ("No undocumented commands in tournaments",true);
	else {
		cur = newShot(tacNuke);
		cur->xPos = who->letters[x_];
		cur->yPos = who->letters[y_];
		cur->xPosInt = cur->xPos;
		cur->yPosInt = cur->yPos;
		cur->xAngle = 0; /* stage of device */
		cur->yAngle = 0;
		//cur->gunType = tacNuke;
		//cur->soundFlag = 0;
		cur->energy = 200;
		who->damage = 0;
	}
}

void doHellBore(short what)
{
	register shot *cur;
	register double x,y;

	if (!who->hardware.hellboreFlag) 
		robotError("Hellbores not enabled.",true);
	else {
		if( gPrefs.rules_noMoveShoot && who->haveDoneMoveOrShootQ == 2 && gPrefs.showMoveAndShootAlert )
			robotError( "A Robot can't move and shoot in the same chronon, energy for the second operation is lost",false );
	
		if( (!gPrefs.rules_noMoveShoot) || who->haveDoneMoveOrShootQ != 2 )
		{
			cur = newShot(hellBore);
			x = sine[(270+who->aim)%360];
			y = -sine[who->aim];
			cur->xPos = who->letters[x_]+x*(radius+1);
			cur->yPos = who->letters[y_]+y*(radius+1);
			cur->xPosInt = cur->xPos;
			cur->yPosInt = cur->yPos;
			cur->xAngle = x*what/2.0;
			cur->yAngle = y*what/2.0;
			//cur->gunType = hellBore;
			//cur->soundFlag = 1;
			
			if (what > who->hardware.energyMax) what = who->hardware.energyMax;
			if (who->hardware.noNegEnergy && what > who->energy) 
				what = who->energy;
			cur->energy = what;
			checkLegalEnergyDecrement(what);
			//who->energy -= what;
		
			who->haveDoneMoveOrShootQ = 1;
		}
		
		if (what > who->hardware.energyMax) what = who->hardware.energyMax;
		if (who->hardware.noNegEnergy && what > who->energy) 
			what = who->energy;
		checkLegalEnergyDecrement(what);
		who->energy -= what;
	}
}

void doDrone(short what,short target)
{
	register double x,y;
	register shot *cur;
	
	if (isTournament && officialFlag) robotError ("No undocumented commands in tournaments",true);
	else if (gPrefs.rules_noDrones) robotError ("Robots are not allowed to use Drones",true);
	else if (!who->hardware.droneFlag) robotError("Drones not enabled.",true);
	else {
		if( gPrefs.rules_noMoveShoot && who->haveDoneMoveOrShootQ && gPrefs.showMoveAndShootAlert )
			robotError( "A Robot can't move and shoot in the same chronon, energy for the second operation is lost",false );

		if( (!gPrefs.rules_noMoveShoot) || who->haveDoneMoveOrShootQ != 2 )
		{
			cur = newShot(drone);
			x = sine[(270+who->aim)%360];
			y = -sine[who->aim];
			cur->xPos = who->letters[x_]+x*(radius+1);
			cur->yPos = who->letters[y_]+y*(radius+1);
			cur->xPosInt = cur->xPos;
			cur->yPosInt = cur->yPos;
			cur->xAngle = 100; /* Life span of drone */
			cur->yAngle = target; /* Target robot */
			//cur->gunType = drone;
			//cur->soundFlag = 1;
			//cur->gunType = 1;
			
			if (what > who->hardware.energyMax) what = who->hardware.energyMax;
			if (who->hardware.noNegEnergy && what > who->energy) 
				what = who->energy;
			cur->energy = what;
			checkLegalEnergyDecrement(what);
			//who->energy -= what;
		
			who->haveDoneMoveOrShootQ = 1;
		}
		if (what > who->hardware.energyMax) what = who->hardware.energyMax;
		if (who->hardware.noNegEnergy && what > who->energy) 
			what = who->energy;
		checkLegalEnergyDecrement(what);
		who->energy -= what;
	}
}

void doMine(short what)
{
	register shot *cur;

	if (!who->hardware.mineFlag) 
		robotError("Mines not enabled.",true);
	else {
	
		if( gPrefs.rules_noMoveShoot && who->haveDoneMoveOrShootQ == 2 && gPrefs.showMoveAndShootAlert )
			robotError( "A Robot can't move and shoot in the same chronon, energy for the second operation is lost",false );

		if (what > who->hardware.energyMax) what = who->hardware.energyMax;
		if (who->hardware.noNegEnergy && what > who->energy)
			what = who->energy;
		if (what < 6)
			return;
		
		if( (!gPrefs.rules_noMoveShoot) || who->haveDoneMoveOrShootQ != 2 )
		{
			cur = newShot(newMine);
			cur->xPos = who->letters[x_];
			cur->yPos = who->letters[y_];
			cur->xPosInt = cur->xPos;
			cur->yPosInt = cur->yPos;
			cur->xAngle = 10; /* stage of device */
			cur->yAngle = 0;
			//cur->soundFlag = 1;
			
			cur->energy = what - 5;
			checkLegalEnergyDecrement(what);
			//who->energy -= what;
			
			who->haveDoneMoveOrShootQ = 1;
		}
		checkLegalEnergyDecrement(what);
		who->energy -= what;
	}
}

void doLaser(short what,double x,double y,short target)
{
	register shot *cur;
	short	tmp;

	if (isTournament && officialFlag) robotError ("No undocumented commands in tournaments",true);
	else if (gPrefs.rules_noLazers) robotError ("Robots are not allowed to use Lasers",true);
	else if (!who->hardware.laserFlag) robotError("Lasers not enabled.",true);
	else {
	
		if( gPrefs.rules_noMoveShoot && who->haveDoneMoveOrShootQ == 2 && gPrefs.showMoveAndShootAlert )
			robotError( "A Robot can't move and shoot in the same chronon, energy for the second operation is lost",false);

		if( (!gPrefs.rules_noMoveShoot) || who->haveDoneMoveOrShootQ != 2 )
		{
			cur = newShot(laser);
			cur->gunType = target;
			cur->xAngle = x;
			cur->yAngle = y;
			x = sine[(270+who->aim)%360];
			y = -sine[who->aim];
			cur->xPos = who->letters[x_]+x*(radius+1);
			cur->yPos = who->letters[y_]+y*(radius+1);
			cur->xPosInt = cur->xPos;
			cur->yPosInt = cur->yPos;
			//cur->soundFlag = 1;
					
			if (what > who->hardware.energyMax) what = who->hardware.energyMax;
			if (who->hardware.noNegEnergy && what > who->energy) 
				what = who->energy;
			tmp = who->energy;
			if (tmp < 0) tmp = 0;
			checkLegalEnergyDecrement(what);
			//who->energy -= what;
			if (what > tmp) what = tmp;
			cur->energy = what;
		
			who->haveDoneMoveOrShootQ = 1;
		}
		
		if (what > who->hardware.energyMax) what = who->hardware.energyMax;
		if (who->hardware.noNegEnergy && what > who->energy) 
			what = who->energy;
		tmp = who->energy;
		if (tmp < 0) tmp = 0;
		checkLegalEnergyDecrement(what);
		who->energy -= what;
	}
}

void doBullet(short what)
{
	register shot *cur;
	register double x,y;

	if (who->hardware.gunType == 1) 
		robotError("Normal bullets not available.",true);
	else {
		if( gPrefs.rules_noMoveShoot && who->haveDoneMoveOrShootQ == 2 && gPrefs.showMoveAndShootAlert )
			robotError( "A Robot can't move and shoot in the same chronon, energy for the second operation is lost",false );

		if( (!gPrefs.rules_noMoveShoot) || who->haveDoneMoveOrShootQ != 2 )
		{
			cur = newShot(gun);
			x = sine[(270+who->aim)%360];
			y = -sine[who->aim];
			cur->xPos = who->letters[x_]+x*(radius+1);
			cur->yPos = who->letters[y_]+y*(radius+1);
			cur->xPosInt = cur->xPos;
			cur->yPosInt = cur->yPos;
			cur->xAngle = x*6.0;
			cur->yAngle = y*6.0;
			//cur->gunType = 2; /* Fire normal bullet */
			//cur->soundFlag = 1;
			
			if (what > who->hardware.energyMax) what = who->hardware.energyMax;
			if (who->hardware.noNegEnergy && what > who->energy) 
				what = who->energy;
			cur->energy = what;
			checkLegalEnergyDecrement(what);
			//who->energy -= what;
		
			who->haveDoneMoveOrShootQ = 1;
		}
		if (what > who->hardware.energyMax) what = who->hardware.energyMax;
		if (who->hardware.noNegEnergy && what > who->energy) 
			what = who->energy;
		checkLegalEnergyDecrement(what);
		who->energy -= what;
	}
}

void doStunner(short what)
{
	register shot *cur;
	register double x,y;

	if (!who->hardware.stunnerFlag) 
		robotError("Stunners not enabled.",true);
	else {
		if( gPrefs.rules_noMoveShoot && who->haveDoneMoveOrShootQ == 2 && gPrefs.showMoveAndShootAlert )
			robotError( "A Robot can't move and shoot in the same chronon, energy for the second operation is lost",false );

		if( (!gPrefs.rules_noMoveShoot) || who->haveDoneMoveOrShootQ != 2 )
		{
			cur = newShot(stunner);
			x = sine[(270+who->aim)%360];
			y = -sine[who->aim];
			cur->xPos = who->letters[x_]+x*(radius+1);
			cur->yPos = who->letters[y_]+y*(radius+1);
			cur->xPosInt = cur->xPos;
			cur->yPosInt = cur->yPos;
			cur->xAngle = x*7.0;
			cur->yAngle = y*7.0;
			//cur->gunType = stunner;
			//cur->soundFlag = 1;
				
			if (what > who->hardware.energyMax) what = who->hardware.energyMax;
			if (who->hardware.noNegEnergy && what > who->energy) 
				what = who->energy;
			cur->energy = what;
			checkLegalEnergyDecrement(what);
			//who->energy -= what;
			
			who->haveDoneMoveOrShootQ = 1;
		}
		if (what > who->hardware.energyMax) what = who->hardware.energyMax;
		if (who->hardware.noNegEnergy && what > who->energy) 
			what = who->energy;
		checkLegalEnergyDecrement(what);
		who->energy -= what;
	}
}

short distance(robot *who)
{
	short target, dist;
	
	getTargetAndDistance( who, who->aim+who->look, &target, &dist );
	
	return dist;
}

short radar(robot *who)
{
	register shot *cur;
	register short x, y, theta, scan;
	long range, close = 1000000, result;
	
	cur = shots;
	x = who->letters[x_];
	y = who->letters[y_];
	scan = (who->aim+who->scan)%360;
	while (cur != NULL) {
		if (cur->type != laser) {
			theta = (short)(450-atan2(y-cur->yPosInt,cur->xPosInt-x)*radToDeg)%360;
			if ((abs(theta-scan) < 20) || (abs(theta-scan) > 340)) {
				range = (y-cur->yPosInt)*(long)(y-cur->yPosInt) + 
						(x-cur->xPosInt)*(long)(x-cur->xPosInt);
				if (range < close) close = range;
			}
		}
		cur = cur->next;
	}
	if (close == 1000000) result = 0;
	else result = sqrt(close);
	return result;
}

short doppler(void)
{
	short dist, target;
	
	/* Doppler computes the velocity of the robot detected by range perpendicular
		to the aim vector.  It neglects any movement of the tracking robot.
		
		Doppler first finds the nearest robot in sight, if there is one.  Then it
		uses the following formula to compute perpendicular velocity:  
		(v = velocity vector of target, r = vector from tracker to target)
		
		             ------------------
		            /          (r¥v)^2
		dop = ± \  /  |v|^2  - -------  ; original formula
		         \/             |r|^2
		
		    = ± sqrt( (|v|^2 * |r|^2 - (|v||r|cos(theta))^2 ) / |r|^2 ) ; definition of dot product
			= ± sqrt( (|v|^2 * |r|^2)(1 - cos^2(theta)) / |r|^2 ) ; commutative multiplication
			= ± sqrt( (|v|^2 * |r|^2)(sin^2(theta)) / |r|^2 ) ; law of sines.
			= |v||r|sin(theta) / |r| ; square root
		
		dop = |v x r| / |r|  ; definition of cross-product
		
		since v and r are 2D vectors, v x r == |v x r| == (ry*vx - rx*vy)
		(v x r points out in the z direction, since v and r both have z components of 0)
	*/
	
	getTargetAndDistance( who, who->aim+who->look, &target, &dist );
	
	if (dist) {
		register double sx = gArenaState.robots[target].speedX;
		register double sy = gArenaState.robots[target].speedY;
		if (sx == 0 && sy == 0)
			return 0; // save time on stationary targets
		else {
			// r = [a b]; v = [sx sy]; v x r = (b*sx - a*sy);
			register double a = (who->letters[x_] - gArenaState.robots[target].x); /* a = rx */
			register double b = (who->letters[y_] - gArenaState.robots[target].y); /* b = ry */
			
			double dop = (b*sx - a*sy) / sqrt(a*a+b*b);
			
			if (dop-(long)dop > 0.5) dop += 1.0; // round to nearest integer value.
			
			return dop;
		}
	}
	
	return 0;
}


// ---
// Approach computes the speed at which the robot's are moving towards the viewing robot
// Note: I've used the approach code but swpaped x and y hence dopppler -> approach
// -- SR - a few words:
//   a: it looks like this code is never used!
//   b: the formula was originally wrong anyway. I've changed it. Hopefully it is accurate now.
//      the original formula was a repeat of the doppler formula with x and y coordinates switched,
//      and that was wrong in many ways. The new formula is the correct formula for calculating
//      the magnitude of the projected vector of one vector onto the line formed by another.
// ---
short approach(void)
{
	short dist, target;
	
	/* Approach computes the velocity of the robot detected by range parallel
		to the aim vector.  It neglects any movement of the tracking robot.
		
		Approach first finds the nearest robot in sight, if there is one.  Then it
		uses the following formula to compute parallel velocity:  
		(v = velocity vector of target, r = vector from target to tracker)
		(NOTE: r is completely inverted from what is used in the doppler formula)
		
		app = ±|v|cos(theta); + if acute, - if obtuse.
		    = |r||v|cos(theta) / |r| ; multiply by 1
			
		app = r¥v / |r| ; definition of dot-product
		
		This is the formula for the magnitude of the vector projection of
		vector v onto the vector r.
	*/
	
	getTargetAndDistance( who, who->aim+who->look, &target, &dist );
	
	if (dist) {
		register double sx = gArenaState.robots[target].speedX;
		register double sy = gArenaState.robots[target].speedY;
		if (sx == 0 && sy == 0)
			return 0;
		else {
			// r = [a b]; v = [sx sy]; r¥v = (a*sx + b*sy); 
			register double a = (gArenaState.robots[target].x - who->letters[x_]); /* a = rx */
			register double b = (gArenaState.robots[target].y - who->letters[y_]); /* b = ry */
			
			double app = (a*sx + b*sy) / sqrt(a*a+b*b); // dot product (r¥v) over magnatude of r (|r|)
			
			if (app-(long)app > 0.5) app += 1.0; // round to nearest integer value.
			
			return app;
		}
	}
	
	return 0;
}

