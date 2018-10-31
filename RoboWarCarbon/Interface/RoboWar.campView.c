/*
 *  RoboWar.campView.h
 *  RoboWar
 *
 *  Created by Sam Rushing on Thu Jun 24 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"

// ----- globals from main.c -----
extern WindowRef		gArenaWindow;
extern ControlRef		gCampView;
extern robot			rob[maxBots];
extern short			isBattle;
extern short			botSelected;
extern short			numBots;
extern short			useDebugger;
extern long				chronon;

// ----- from roboWar.model.robot.c -----
extern void drawRobot(short which, short whereX, short whereY, short aim, short iconNum,
				RgnHandle mask, short turretType);

void drawCampView ( void )
{
	short i;
	Rect r;
	RgnHandle oldClip;
	Str255 msg = "\pTeam  ";
	Str255 msg1,msg2;

	oldClip = NewRgn();
	GetClip(oldClip);
	
	ForeColor( blackColor );
	
	// add code to paint the bot statistics;
	for (i=0; i<numBots; i++) {
		register short j = 34 * i;
		
		// draw the robot's name
		r.left = 35; r.right = 127;
		r.top = j; r.bottom = 35+j;
		ClipRect(&r);
		TextFont (systemFont);
		TextSize (12);
		MoveTo( 35, 18+j);
		DrawString(rob[i].name);
		SetClip(oldClip);
		
		TextFont (kFontIDMonaco);
		TextSize (9);
		
		// draw the robot's team affiliation
		if (rob[i].team) {
			MoveTo ( 35, 29+j );
			msg[6] = rob[i].team+'0';
			DrawString (msg);
		}

		if (rob[i].alive) {
			NumToString(rob[i].energy, msg1 );
			NumToString(rob[i].damage, msg2 );
			MoveTo (129,12+j); DrawString("\pEnergy:");
			MoveTo (174,12+j); DrawString(msg1);
			MoveTo (129,21+j); DrawString("\pDamage:");
			MoveTo (174,21+j); DrawString(msg2);
		}
		else {
			MoveTo(129,12+j); 
			switch (rob[i].scan) {
				case 32000: DrawString ("\pBuggy"); break;
				case 32001: DrawString ("\pOverloaded"); break;
				default: 	 					
					if (rob[i].killer != -1) DrawString(rob[rob[i].killer].name);
					else DrawString("\p¥¥¥Dead¥¥¥");
					break;
			}
			NumToString( rob[i].deathTime, msg1);
			MoveTo (129,21+j); DrawString("\pTime: "); DrawString(msg1);
		}
		
		// draw the robot's icon
		drawRobot( i, 18, 17+j, 90, 0, NULL, -1);
	}
	
	if (!isBattle && botSelected != maxBots) { /* Hilite selected bot */
		r.top = 34*botSelected; r.bottom = r.top + 34;
		r.left = 0; r.right = 199;
		InvertRect(&r);
		
		// draw the robot's icon
		drawRobot( botSelected, 18, 17+34*botSelected, 90, 0, NULL, 5);
	}
	
	TextFont (systemFont);
	TextSize (12);
	for (; i<maxBots; i++) {
		MoveTo( 9, 20+34*i ); DrawString("\p<Not Selected>");
	}
}

OSStatus handleEventInCampView (EventHandlerCallRef inHandlerCallRef, EventRef inEvent, void *inUserData)
{
#pragma unused (inUserData)

	OSStatus                err = eventNotHandledErr;
	UInt32                  eventKind = GetEventKind( inEvent );

	switch ( eventKind )
	{
		case kEventControlDraw:
			drawCampView( );
			err = noErr;
		break;

		case kEventControlHit: {
			ControlPartCode index;

			err = GetEventParameter( inEvent, kEventParamControlPart, typeControlPartCode,
                    NULL, sizeof(ControlPartCode), NULL, &index );
			if (err) break;
			
			if (index<=numBots)
				botSelected = index-1;
			Draw1Control( gCampView );
		}
		break;

		case kEventControlHitTest: {
			Point wheresMyMouse;
			ControlPartCode index;
			
			err = GetEventParameter( inEvent, kEventParamMouseLocation, typeQDPoint,
                    NULL, sizeof(Point), NULL, &wheresMyMouse );
			if (err) break;
			
			index = wheresMyMouse.v / 34 + 1; // add 1 because returning 0 results in no hit!
			
			err = SetEventParameter( inEvent, kEventParamControlPart, typeControlPartCode, 
					sizeof(ControlPartCode), &index );
		}
		break;
	}
	
	return err;
}

OSStatus installCampViewEventHandler()
{
	OSStatus                err = noErr;
	static EventHandlerRef  handler = NULL;
	
	if ( handler == NULL )
	{
		EventTypeSpec       eventList[] = {
			{ kEventClassControl, kEventControlDraw },
			{ kEventClassControl, kEventControlHit },
			{ kEventClassControl, kEventControlHitTest }
		};

		err = InstallControlEventHandler(gCampView,
			NewEventHandlerUPP( handleEventInCampView ), // the proc pointer
			GetEventTypeCount( eventList ), eventList, // the events to handle
			NULL, &handler); // empty user data, null super-class
	}
	
	return err;
}

