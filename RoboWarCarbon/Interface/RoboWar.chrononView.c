/*
 *  RoboWar.chrononView.h
 *  RoboWar
 *
 *  Created by Sam Rushing on Thu Jun 24 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"

extern WindowRef		gArenaWindow;
extern ControlRef		gChrononView;
extern ControlRef		gCampWell[maxBots];

// ----- globals from roboWar.engine.control.c -----
extern unsigned long	chronon;
extern double			chrononsPerSecond;

OSStatus drawChrononView (EventHandlerCallRef inHandlerCallRef, EventRef inEvent, void *inUserData)
{
#pragma unused (inHandlerCallRef, inEvent, inUserData)

	OSStatus                err = noErr;
	static Str255			string;

	TextFont (kFontIDMonaco);
	TextSize (9);
	string[0] = sprintf(string+1, "Chronon: %lu", chronon);
	MoveTo(5, 17); DrawString(string);
	string[0] = sprintf(string+1, "Per Sec: %1.2f", chrononsPerSecond);
	MoveTo(104, 17); DrawString(string);
	
	return err;
}

OSStatus installChrononViewEventHandler()
{
	OSStatus                err = noErr;
	static EventHandlerRef  handler = NULL;
	
	if ( handler == NULL )
	{
		EventTypeSpec       eventList[] = {
			{ kEventClassControl, kEventControlDraw },
		};

		err = InstallControlEventHandler(gChrononView,
			NewEventHandlerUPP( drawChrononView ), // the proc pointer
			GetEventTypeCount( eventList ), eventList, // the events to handle
			NULL, &handler); // empty user data, null super-class
	}
	
	return err;
}

