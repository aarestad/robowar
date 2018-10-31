/*
 *  RoboWar.arenaWindow.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Thu Jun 24 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "CarbonWrapper.h"

extern WindowRef		gArenaWindow;


OSStatus handleEventInArenaWindow (EventHandlerCallRef inHandlerCallRef, EventRef inEvent, void *inUserData)
{
	OSStatus                err = eventNotHandledErr;
	UInt32                  eventClass = GetEventClass( inEvent );
	UInt32                  eventKind = GetEventKind( inEvent );
	
	if (eventClass == kEventClassWindow)
	{
		switch (eventKind)
		{
			// cause the application to quit when the arena window is closed.
			case kEventWindowClosed:
				err = CallNextEventHandler (inHandlerCallRef, inEvent);
				if (err == noErr || err == eventNotHandledErr) {
					QuitApplicationEventLoop();
					err = noErr;
				}
				break;
			
			// deactivate the inappropriate menu items
			case kEventWindowActivated:
				err = CallNextEventHandler (inHandlerCallRef, inEvent);
				if (err == noErr || err == eventNotHandledErr)
					; // OPENISSUE -- add this.
				break;
		}
	}
	
	return err;
}

OSStatus installArenaWindowEventHandler()
{
	OSStatus                err = noErr;
	static EventHandlerRef  handler = NULL;
	
	if ( handler == NULL )
	{
		EventTypeSpec       eventList[] = {
			{ kEventClassWindow, kEventWindowClosed },
			{ kEventClassWindow, kEventWindowActivated }
		};

		err = InstallWindowEventHandler(
			gArenaWindow,
			NewEventHandlerUPP( handleEventInArenaWindow ),
			GetEventTypeCount( eventList ),
			eventList,
			(void *)gArenaWindow,
			&handler );
	}
	
	return err;
}
