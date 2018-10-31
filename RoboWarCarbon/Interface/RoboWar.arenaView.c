/*
 *  RoboWar.arenaView.h
 *  RoboWar
 *
 *  Created by Sam Rushing on Thu Jun 24 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "Tokens.h"

extern WindowRef		gArenaWindow;
extern ControlRef		gArenaView;
extern robot			rob[maxBots];
extern short			numBots;
extern RgnHandle		explosionMasks[8];	// Section of exploding robot to display
extern shot				*shots;				/* Head of list of shots */

extern CIconHandle		bulletGW;			//Bullet GWorlds...
extern CIconHandle		hellBoreGW;
extern CIconHandle		mineGW;
extern CIconHandle		newMineGW;
extern CIconHandle		droneGW[8];

// ----- from roboWar.model.robot.c -----
extern void drawRobot(short which, short whereX, short whereY, short aim, short iconNum,
				RgnHandle mask, short turretType);

OSStatus drawArenaView (EventHandlerCallRef inHandlerCallRef, EventRef inEvent, void *inUserData)
{
#pragma unused (inHandlerCallRef, inEvent, inUserData)

	OSStatus                err = noErr;
	short state;
	Rect r2;
	register robot * theRob;
	register shot * cur;
	register short i, y, x;

#ifdef RW_DEBUG
	//CFShow(CFSTR("drawArenaView()\n"));
#endif

	/* Draw Shots */
	cur = shots;
	while (cur != NULL) {
		switch(cur->type) {	//--- 19 apr 97 --- Most weapons ae now stored in GWorlds, 
							// 					so copybits is used.
			case gun: r2.top = cur->yPosInt-2; r2.bottom = r2.top+8;
					  r2.left = cur->xPosInt-2; r2.right = r2.left+8;
					  PlotCIcon( &r2, bulletGW );
					  //CopyBits(&((GrafPtr)bulletGW)->portBits,&qd.thePort->portBits,
					  //		   &bulletGW->portRect,&r2,transparent,NULL);
					  break;
			case missile:MoveTo ((short)cur->xPosInt,(short)cur->yPosInt);
						 LineTo ((short)(cur->xPosInt+cur->xAngle),
						 		 (short)(cur->yPosInt+cur->yAngle));
						 break;
			case tacNuke:
			case bigExplode: {
						  Pattern p;
						  i = (short)cur->xAngle;
						  r2.top = cur->yPosInt-i; r2.bottom = cur->yPosInt+i;
						  r2.left = cur->xPosInt-i; r2.right = cur->xPosInt+i;
						  PenMode(patOr);
						  GetQDGlobalsGray(&p);
						  PenPat(&p);
						  PaintOval(&r2);
						  GetQDGlobalsBlack(&p);
						  PenPat(&p);
						  PenMode(patCopy);
						  break;
					}
			case explode: r2.top = cur->yPosInt-5; r2.bottom = cur->yPosInt+5;
						  r2.left = cur->xPosInt-5; r2.right = cur->xPosInt+5;
						  PaintOval(&r2);
						  break;
			case hellBore: r2.top = cur->yPosInt-4; r2.bottom = cur->yPosInt+4;
					  r2.left = cur->xPosInt-4; r2.right = cur->xPosInt+4;
					  PlotCIcon( &r2, hellBoreGW );
					  //CopyBits(&((GrafPtr)hellBoreGW)->portBits,&qd.thePort->portBits,
					  //		   &hellBoreGW->portRect,&r2,transparent,NULL);
					  break;
			case mine: r2.top = cur->yPosInt-4; r2.bottom = cur->yPosInt+4;
					  r2.left = cur->xPosInt-4; r2.right = cur->xPosInt+4;
					  PlotCIcon( &r2, mineGW );
					  //CopyBits(&((GrafPtr)mineGW)->portBits,&qd.thePort->portBits,
					  //		   &mineGW->portRect,&r2,transparent,NULL);
					  break;
			case drone: r2.top = cur->yPosInt-5; r2.bottom = cur->yPosInt+3;
					  r2.left = cur->xPosInt-5; r2.right = cur->xPosInt+3;
					  PlotCIcon( &r2, droneGW[cur->gunType] );
					  //CopyBits(&((GrafPtr)droneGW[cur->gunType])->portBits,&qd.thePort->portBits,
					  //		   &droneGW[cur->gunType]->portRect,&r2,transparent,NULL);
					  break;
			case laser: {
						Pattern p;
						MoveTo ((short)cur->xPosInt,(short)cur->yPosInt);
						LineTo ((short)(cur->xAngle+cur->xPosInt)/2,
								(short)(cur->yAngle+cur->yPosInt)/2);
						GetQDGlobalsGray(&p);
						PenPat(&p);
						LineTo ((short)cur->xAngle,(short)cur->yAngle);
						GetQDGlobalsBlack(&p);
						PenPat(&p);
						break;
					}
			case newMine: r2.top = cur->yPosInt-4; r2.bottom = cur->yPosInt+4;
					  r2.left = cur->xPosInt-4; r2.right = cur->xPosInt+4;
					  PlotCIcon( &r2, newMineGW );
					  //CopyBits(&((GrafPtr)newMineGW)->portBits,&qd.thePort->portBits,
					  //		   &newMineGW->portRect,&r2,transparent,NULL);
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

	return err;
}

OSStatus installArenaViewEventHandler()
{
	OSStatus                err = noErr;
	static EventHandlerRef  handler = NULL;
	
	if ( handler == NULL )
	{
		EventTypeSpec       eventList[] = {
			{ kEventClassControl, kEventControlDraw },
		};

		err = InstallControlEventHandler(gArenaView,
			NewEventHandlerUPP( drawArenaView ), // the proc pointer
			GetEventTypeCount( eventList ), eventList, // the events to handle
			NULL, &handler); // empty user data, null super-class
	}
	
	return err;
}

