/*
 *  RoboWar.engine.events.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Fri Jul 02 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "RoboWar.model.preferences.h"

// ----- globals from main.c -----
extern short			isBattle;
extern ControlRef		gChrononView;
extern ControlRef		gCampView;
extern ControlRef		gArenaView;

// ----- from RoboWar.engine.combat.c -----
extern unsigned long	chronon;
extern short			pausedFlag;
extern void doRoundOfCombat(void);

// ----- from RoboWar.engine.control.c -----
extern void finishBattle( void );

// ----- globals from RoboWar.engine.control.c -----
extern void fireBattleEvent ( void );


/*
	handleBattleEvent() is like the quarterback in the battle loop. It receives the battle event
	from the Event Queue and tells the main battle code to execute, then redraws whatever controls
	need to be redrawn.
 */
OSStatus handleBattleEvent (EventHandlerCallRef inHandlerCallRef, EventRef inEvent, void *inUserData)
{
	if (isBattle) {
		doRoundOfCombat();
		
		// avoid as much event-handling overhead as possible without
		// being noticable to the end-user. we should end up with an
		// effective 12 event checks per second. observed: up to 1/4
		// second delay between mouse click and UI reaction. -- acceptable.
		if (gPrefs.battleSpeed == kRoboWarDisplayFast) {
			if (gPrefs.displayCode == kRoboWarDrawNothing) {
				long tick = TickCount() + 5;
				do {
					doRoundOfCombat();
				} while (TickCount() < tick);
			}
			else doRoundOfCombat();
		}
		
		// this is where we cause the views to be redrawn as needed
		switch (gPrefs.displayCode) {
			case kRoboWarDrawArenaAndStats:
				Draw1Control( gArenaView );
			
			case kRoboWarDrawStatsOnly:
				Draw1Control( gCampView );
			
			// case kRoboWarDrawNothing:
				Draw1Control( gChrononView );
		}
		
		if((gPrefs.battleSpeed == kRoboWarDisplayFast) || pausedFlag)
			fireBattleEvent(); // immediately fire the battle event, instead of waiting on timers.
	} else
		finishBattle();
			
	return noErr;
}

OSStatus installBattleEventHandler()
{
	OSStatus                err = noErr;
	static EventHandlerRef  handler = NULL;
	
	if ( handler == NULL )
	{
		EventTypeSpec       eventList[] = {
			{ kRoboWarSignature, kRoboWarBattleEvent }
		};

		err = InstallApplicationEventHandler(
			NewEventHandlerUPP( handleBattleEvent ),
			GetEventTypeCount( eventList ),
			eventList,
			NULL,
			&handler );
	}
	
	return err;
}
