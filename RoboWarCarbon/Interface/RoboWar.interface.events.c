/*
 *  RoboWar.interface.events.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Thu Jun 24 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 *  This is the bulk of the Control component of the program. Here, we'll
 *  intercept menu and button commands and take actions accordingly.
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "RoboWar.model.preferences.h"


#define RW_DEBUG

EventHotKeyRef  gStartBattleHotKey;
EventHotKeyRef  gRepeatBattleHotKey;
EventHotKeyRef  gHaltBattleHotKey;

extern short			isBattle;
extern short			numBots;
extern robot			rob[maxBots];
extern short			botSelected;
extern MenuRef			gArenaMenu;


// ----- from roboWar.engine.control.c -----
OSStatus InstallBattleTimer( );
OSStatus RemoveBattleTimer( );
OSStatus PauseBattleTimer();
OSStatus ResumeBattleTimer();
extern void startBattle(short repeatFlag);

// ----- from RoboWar.model.robot.c -----
extern OSStatus newRobot(void);
extern OSStatus openRobot(void);
extern void duplicateRobot(void);
extern OSStatus saveAsRobot(void);
extern void closeRobot(void);

/*
static _KeyCode	_keyCodes[] = {
    {@"0", 0x1D}, {@"1", 0x12}, {@"2", 0x13}, {@"3", 0x14}, 
    {@"4", 0x15}, {@"5", 0x17}, {@"6", 0x16}, {@"7", 0x1A}, 
    {@"8", 0x1C}, {@"9", 0x19}, {@"A", 0x00}, {@"B", 0x0B}, 
    {@"C", 0x08}, {@"D", 0x02}, {@"E", 0x0E}, {@"F", 0x03}, 
    {@"G", 0x05}, {@"H", 0x04}, {@"I", 0x22}, {@"J", 0x26}, 
    {@"K", 0x28}, {@"L", 0x25}, {@"M", 0x2E}, {@"N", 0x2D}, 
    {@"O", 0x1F}, {@"P", 0x23}, {@"Q", 0x0C}, {@"R", 0x0F}, 
    {@"S", 0x01}, {@"T", 0x11}, {@"U", 0x20}, {@"V", 0x09}, 
    {@"W", 0x0D}, {@"X", 0x07}, {@"Y", 0x10}, {@"Z", 0x06}, 
	{@".", 0x2F}, 
};
*/

OSStatus handleApplicationEvent (EventHandlerCallRef inHandlerCallRef, EventRef inEvent, void *inUserData)
{
	OSStatus	err = eventNotHandledErr;
	UInt32		eventClass = GetEventClass(inEvent);
	UInt32		eventKind = GetEventKind(inEvent);
	
#ifdef RW_DEBUG
	CFStringRef debugStr;
#endif
	
	if (eventClass == kEventClassCommand && eventKind == kEventCommandProcess) {
	
		HICommand command;
		err = GetEventParameter( inEvent, kEventParamDirectObject,
				typeHICommand, NULL, sizeof( HICommand ),
				NULL, &command );
		require_noerr( err, ParameterMissing );
		
#ifdef RW_DEBUG
		debugStr = CFStringCreateWithFormat(NULL, NULL, CFSTR("commandID: '%4s'"), &command.commandID);
		CFShow(debugStr);
		CFRelease(debugStr);
#endif
		
		switch (command.commandID)
		{
			case 'BATL': { // the battle button
				UInt32 modifiers = 0;
#ifdef RW_DEBUG
				CFShow(CFSTR("battle button was triggered."));
#endif
				// find out what key modifiers were held down.
				GetEventParameter( inEvent, kEventParamKeyModifiers,
						typeUInt32, NULL, sizeof( UInt32 ),
						NULL, &modifiers );
				
				if (isBattle) isBattle = 0;
				else startBattle( modifiers & optionKey );
				err = noErr;
				break;
			}

			case 'new ': // the new robot command
#ifdef RW_DEBUG
				CFShow(CFSTR("should create a new robot."));
#endif
				err = newRobot();
				break;

			case 'open': // the open robot command
#ifdef RW_DEBUG
				CFShow(CFSTR("should open robot."));
#endif
				err = openRobot();
				break;

			case 'CLOS': // the close robot command
#ifdef RW_DEBUG
				CFShow(CFSTR("should close robot."));
#endif
				closeRobot();
				err = noErr;
				break;

			case 'Dupl': // the duplicate robot command
#ifdef RW_DEBUG
				CFShow(CFSTR("should duplicate robot."));
#endif
				duplicateRobot();
				err = noErr;
				break;

			case 'svas': // the "save as..." command
#ifdef RW_DEBUG
				CFShow(CFSTR("should save as."));
#endif
				err = saveAsRobot();
				break;

			case 'page': // the page setup command
#ifdef RW_DEBUG
				CFShow(CFSTR("should handle page setup."));
#endif
				err = noErr;
				break;

			case 'prnt': // the print command
#ifdef RW_DEBUG
				CFShow(CFSTR("should print."));
#endif
				err = noErr;
				break;

			case 'AREN': // the show arena command
#ifdef RW_DEBUG
				CFShow(CFSTR("should show arena station."));
#endif
				err = noErr;
				break;

			case 'DRAF': // the show drafting board command
#ifdef RW_DEBUG
				CFShow(CFSTR("should show drafting board station."));
#endif
				err = noErr;
				break;

			case 'HARD': // the show hardware store command
#ifdef RW_DEBUG
				CFShow(CFSTR("should show hardware store station."));
#endif
				err = noErr;
				break;

			case 'ICON': // the show icon factory command
#ifdef RW_DEBUG
				CFShow(CFSTR("should show icon factory station."));
#endif
				err = noErr;
				break;

			case 'RECO': // the show recording studio command
#ifdef RW_DEBUG
				CFShow(CFSTR("should show recording studio station."));
#endif
				err = noErr;
				break;

			case 'COMP': // the compile robot command
#ifdef RW_DEBUG
				CFShow(CFSTR("should compile robot."));
#endif
				err = noErr;
				break;

			case 'SETP': // the set robot password command
#ifdef RW_DEBUG
				CFShow(CFSTR("should set robot password."));
#endif
				err = noErr;
				break;

			case 'UDBG': // the use debugger command
#ifdef RW_DEBUG
				CFShow(CFSTR("should use debugger."));
#endif
				err = noErr;
				break;

			case 'SOUN': // the toggle play sound command
#ifdef RW_DEBUG
				CFShow(CFSTR("should toggle sound support."));
#endif
				err = noErr;
				break;

			case 'SHst': // the show history command
#ifdef RW_DEBUG
				CFShow(CFSTR("should show history."));
#endif
				err = noErr;
				break;

			case 'CHst': // the clear history command
#ifdef RW_DEBUG
				CFShow(CFSTR("should clear history."));
#endif
				err = noErr;
				break;

			case 'SMPt': // the set max points command
#ifdef RW_DEBUG
				CFShow(CFSTR("should set max points."));
#endif
				err = noErr;
				break;

			case 'Tour': // the start tournament command
#ifdef RW_DEBUG
				CFShow(CFSTR("should start tournament."));
#endif
				err = noErr;
				break;

			case 'Tea0': // the set team commands
			case 'Tea1':
			case 'Tea2':
			case 'Tea3': {
				unsigned long team = command.commandID - 'Tea0';
				MenuRef menu;
#ifdef RW_DEBUG
				CFShow(CFSTR("should set robot team."));
#endif
				GetMenuItemHierarchicalMenu( gArenaMenu, kArenaTeamMenuItemIndex, &menu );
				
				CheckMenuItem ( menu, rob[botSelected].team+1, false );
				CheckMenuItem ( menu, team+1, true );
				rob[botSelected].team = team;
				
				err = noErr;
			} break;

			case 'Dsp1': // the set display commands
			case 'Dsp2':
			case 'Dsp3': {
				unsigned long display = command.commandID - 'Dsp0';
				MenuRef menu;
#ifdef RW_DEBUG
				CFShow(CFSTR("should set display type."));
#endif
				GetMenuItemHierarchicalMenu( gArenaMenu, kArenaDisplayMenuItemIndex, &menu );
				
				CheckMenuItem ( menu, gPrefs.displayCode, false );
				CheckMenuItem ( menu, display, true );
				gPrefs.displayCode = display;
				
				err = noErr;
			} break;

			case 'Spd0': // the set speed commands
			case 'Spd1':
			case 'Spd2':
			case 'Spd3':
			case 'Spd4': {
				unsigned long speed = command.commandID - 'Spd0';
				MenuRef menu;
#ifdef RW_DEBUG
				CFShow(CFSTR("should set battle speed."));
#endif
				GetMenuItemHierarchicalMenu( gArenaMenu, kArenaSpeedMenuItemIndex, &menu );
				
				CheckMenuItem ( menu, gPrefs.battleSpeed+1, false );
				CheckMenuItem ( menu, speed+1, true );
				gPrefs.battleSpeed = speed;
				
				if (RemoveBattleTimer() == noErr) {
					InstallBattleTimer();
				}
				
				err = noErr;
			} break;
		
			default:
				err = CallNextEventHandler (inHandlerCallRef, inEvent);
				break;
		}
	}
	else if (eventClass == kEventClassKeyboard && eventKind == kEventHotKeyPressed)
	{
		EventHotKeyID keyID;
		
		GetEventParameter( inEvent, kEventParamDirectObject,
				typeEventHotKeyID, NULL, sizeof( EventHotKeyID ),
				NULL, &keyID );
	
		switch ( keyID.id ) {
			case 'BATL':
				if (!isBattle && numBots > 0) startBattle( 0 );
				// CFShow(CFSTR("Got Start Battle HotKey!"));
				err = noErr;
				break;

			case 'REPB':
				if (!isBattle && numBots > 0) startBattle( optionKey );
				// CFShow(CFSTR("Got Repeat Battle HotKey!"));
				err = noErr;
				break;

			case 'HALT':
				if (isBattle) isBattle = 0;
				// CFShow(CFSTR("Got Halt Battle HotKey!"));
				break;
		}
	}
	else if (eventClass == kEventClassApplication) {
		switch (eventKind) {

			case kEventAppQuit:
				writePrefs();
				break;
			
			case kEventAppActivated: {
				EventHotKeyID keyID = { kRoboWarSignature, 'BATL' };
				
				// don't ask me why, but 0x0B is the Key Code for 'B'
				err = RegisterEventHotKey( 0x0B, cmdKey, keyID,
							GetApplicationEventTarget(), 0, &gStartBattleHotKey );
				require_noerr( err, ParameterMissing );

				keyID.id = 'REPB';
				err = RegisterEventHotKey( 0x0B, cmdKey|optionKey, keyID,
							GetApplicationEventTarget(), 0, &gRepeatBattleHotKey );
				require_noerr( err, ParameterMissing );

				// don't ask me why, but 0x2F is the Key Code for '.'
				keyID.id = 'HALT';
				err = RegisterEventHotKey( 0x2F, cmdKey, keyID,
							GetApplicationEventTarget(), 0, &gHaltBattleHotKey );
				require_noerr( err, ParameterMissing );
				
				// CFShow(CFSTR("Registered hotkeys."));
				
				break;
			}

			case kEventAppDeactivated:
				if ( gStartBattleHotKey ) {
					err = UnregisterEventHotKey( gStartBattleHotKey );
					require_noerr( err, ParameterMissing );
					gStartBattleHotKey = NULL;
				}
				
				if ( gRepeatBattleHotKey ) {
					err = UnregisterEventHotKey( gRepeatBattleHotKey );
					require_noerr( err, ParameterMissing );
					gRepeatBattleHotKey = NULL;
				}
				
				if ( gHaltBattleHotKey ) {
					err = UnregisterEventHotKey( gHaltBattleHotKey );
					require_noerr( err, ParameterMissing );
					gHaltBattleHotKey = NULL;
				}

				// CFShow(CFSTR("Unregistered hotkeys."));

				break;
		}
	}
	
ParameterMissing:
	return err;
}

OSStatus handleMenuEvent (EventHandlerCallRef inHandlerCallRef, EventRef inEvent, void *inUserData)
{
	UInt32		eventClass = GetEventClass(inEvent);
	UInt32		eventKind = GetEventKind(inEvent);
	
	if (eventClass == kEventClassMenu) {
		switch (eventKind) {
			case kEventMenuBeginTracking:
				PauseBattleTimer();
				break;
				
			case kEventMenuEndTracking:
				ResumeBattleTimer();
				break;
		}
	}
	
	return eventNotHandledErr;
}

OSStatus installRoboWarApplicationEventHandlers()
{
	OSStatus                err = noErr;
	static EventHandlerRef  ahandler = NULL;
	static EventHandlerRef  mhandler = NULL;
	
	if ( ahandler == NULL )
	{
		EventTypeSpec       appEventList[] = {
			{ kEventClassCommand, kEventCommandProcess },
			{ kEventClassKeyboard, kEventHotKeyPressed },
			{ kEventClassApplication, kEventAppQuit },
			{ kEventClassApplication, kEventAppActivated },
			{ kEventClassApplication, kEventAppDeactivated }
		};
		
		err = InstallApplicationEventHandler(
			NewEventHandlerUPP( handleApplicationEvent ),
			GetEventTypeCount( appEventList ),
			appEventList,
			NULL,
			&ahandler );
	}
	
	if (err != noErr) return err;
	
	if ( mhandler == NULL )
	{
		EventTypeSpec       menuEventList[] = {
			{ kEventClassMenu, kEventMenuBeginTracking },
			{ kEventClassMenu, kEventMenuEndTracking }
		};
		MenuRef rootMenu = AcquireRootMenu();
		
		if ( rootMenu )
		{
			err = InstallMenuEventHandler(
				rootMenu,
				NewEventHandlerUPP( handleMenuEvent ),
				GetEventTypeCount( menuEventList ),
				menuEventList,
				NULL,
				&mhandler );
			ReleaseMenu( rootMenu );
		}
		else err = -1;
	}
	
	return err;
}
