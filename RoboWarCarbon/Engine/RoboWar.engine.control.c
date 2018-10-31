/*
 *  RoboWar.engine.control.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Sat Jun 26 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 *  SR - 7/20/2004 - I have isoladed all the Event Timer and battle control
 *  functions in this file. That means that when the battle engine is ported,
 *  only this file and RoboWar.engine.events.c will need to be updated.
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "Tokens.h"
#include "RoboWar.model.preferences.h"
#include <sys/time.h>

#define kMinChrononsPerFrame (10)

// ----- globals from main.c -----
extern ControlRef		gBattleButton;
extern ControlRef		gChrononView;
extern ControlRef		gCampView;
extern ControlRef		gArenaView;
extern short			controlChange;
extern short			pausedFlag;
extern short			numBots;
extern short			botSelected;
extern short			useDebugger;
extern robot			rob[maxBots];
extern shot				*shots;
extern short			isBattle;
extern short			isTournament;
extern unsigned short   lastRandSeed;
extern void enableSelectionSpecificControls();
extern void disableSelectionSpecificControls();

// ----- from RoboWar.engine.feedback.c -----
extern void robotError();
extern void reportMessage(char *message1,char *message2);

// ----- from RoboWar.errors.c -----
extern void checkMemErr(char *proc);
extern void displayErr(char *errCode, char *errName,char *proc);

// ----- from RoboWar.engine.combat.c -----
extern unsigned long	chronon;
extern short			numAlive;
extern short			communications[3][10];
extern short			onlyTrackingShots;
extern short setupCombat(short repeatFlag);
extern void cleanUpAfterCombat(void);
extern void doRoundOfCombat(void);

// ----- from RoboWar.engine.interrupts.c -----
extern void initRobotInterrupts(robot *who);

// ----- globals -----
EventLoopTimerRef   statsTimer = NULL;
EventLoopTimerRef   battleTimer = NULL;

struct timeval		battleStartTime;		// start time of the battle
unsigned long		battleStartChronon;		// start chronon of the battle

unsigned long		frameStartTick;			// start time of the frame for calculating  
unsigned long		frameStartChronon;		// start chronon of the frame
double				chrononsPerSecond = 0.0;

void finishBattle( void );


void updateChrononsPerSecond (EventLoopTimerRef inTimer, void * inUserData)
{
	if (chronon >= frameStartChronon + kMinChrononsPerFrame) {
		unsigned long deltaTicks = (TickCount() - frameStartTick);
		unsigned long deltaCronons = (chronon - frameStartChronon);
		
		// chrononsPerSecond = ((chrononsPerSecond * chrononFrame) + (deltaTicks>0 ? deltaCronons*60.0/deltaTicks : deltaCronons*1.0 )) / (chrononFrame+1);
		chrononsPerSecond = (deltaTicks>0 ? deltaCronons*60.0/deltaTicks : deltaCronons*1.0 );
		
		frameStartTick = TickCount();
		frameStartChronon = chronon;
	}
}

void fireBattleEvent ( void )
{
	EventRef theEvent;
	if (CreateEvent( NULL, kRoboWarSignature, kRoboWarBattleEvent, 0, kEventAttributeNone, &theEvent ) != noErr
	 || PostEventToQueue( GetMainEventQueue(), theEvent, kEventPriorityStandard ) != noErr) {
		// do some error handling.
		displayErr( "Error while firing the Battle Timer!", "", NULL );
		
		finishBattle();
		// OPENISSUE -- we should probably unregister the faulty timer here.
	}
	
	// service the quicktime movies so the sound will play
	if (gPrefs.soundFlag && gPrefs.displayCode < kRoboWarDrawNothing)
		MoviesTask( NULL, 0 );
}

void _fireBattleEvent ( EventLoopTimerRef inTimer, void * inUserData )
{
	// this wrapper function allows us to modularize the Carbon-specific code.
	fireBattleEvent();
}

void setupChrononFrames()
{
	frameStartTick = TickCount();
	frameStartChronon = chronon;
	chrononsPerSecond = 0.0;
}

void setupChrononBattle()
{
	gettimeofday(&battleStartTime, NULL);
	battleStartChronon = chronon;
}

OSStatus InstallBattleTimer( )
{
	// this should not be called if the battle speed is "Fast" because the timer will never fire.
	
	static EventTimerInterval speed[5] =
		{ 0.001, 0.0167, 0.0333, 0.1000, 0.5000 };
	//  1000c/s   60c/s   30c/s   10c/s    2c/s
	
	// check for memory leaks.
	if (battleTimer) {
		displayErr( "Could not start the Battle Timer!", "", NULL );
		return eventInternalErr;
	}
	
	// reset the chronons per second calculation variables
	setupChrononBattle();
	
	// install the statistics updating timer
	return InstallEventLoopTimer(
			GetMainEventLoop(),
			kEventDurationNoWait,		// initial delay
			speed[gPrefs.battleSpeed],		// delay between fires
			NewEventLoopTimerUPP( _fireBattleEvent ), // the callback function
			NULL,		// no user data
			&battleTimer
		);
}

OSStatus InstallChrononsPerSecondTimer()
{
	// check for memory leaks.
	if (statsTimer) {
		displayErr( "Could not start the Chronon Monitor!", "", NULL );
		return eventInternalErr;
	}
	
	// reset the chronons per second calculation variables
	setupChrononFrames();
	
	// install the statistics updating timer
	return InstallEventLoopTimer(
			GetMainEventLoop(),
			kEventDurationSecond / 4.0,		// initial delay
			kEventDurationSecond / 4.0,		// delay between fires
			NewEventLoopTimerUPP(updateChrononsPerSecond), // the callback function
			NULL,		// no user data
			&statsTimer
		);
}

OSStatus PauseBattleTimer()
{
	if (battleTimer)
		return SetEventLoopTimerNextFireTime( battleTimer, kEventDurationForever );
	return eventInternalErr;
}

OSStatus PauseChrononsPerSecondTimer()
{
	if (statsTimer)
		return SetEventLoopTimerNextFireTime( statsTimer, kEventDurationForever );
	return eventInternalErr;
}

OSStatus RemoveBattleTimer()
{
	if (battleTimer) {
		OSStatus err = RemoveEventLoopTimer( battleTimer );
		battleTimer = NULL;
		return err;
	}
	return eventInternalErr;
}

OSStatus RemoveChrononsPerSecondTimer()
{
	if (statsTimer) {
		OSStatus err = RemoveEventLoopTimer( statsTimer );
		statsTimer = NULL;
		return err;
	}
	return eventInternalErr;
}

OSStatus ResumeBattleTimer()
{
	if (battleTimer && RemoveBattleTimer() == noErr) {
		return InstallBattleTimer();
	}
	return eventInternalErr;
}

OSStatus ResumeChrononsPerSecondTimer()
{
	if (statsTimer && RemoveChrononsPerSecondTimer() == noErr) {
		return InstallChrononsPerSecondTimer();
	}
	return eventInternalErr;
}

void finishBattle( void )
{
	if (chronon >= battleStartChronon + kMinChrononsPerFrame) {
		struct timeval tp;
		unsigned long deltaCronons = (chronon - battleStartChronon);
		double deltas;
		gettimeofday(&tp, NULL);
		deltas = (tp.tv_sec-battleStartTime.tv_sec)*1.0+(tp.tv_usec-battleStartTime.tv_usec)*0.000001;
		// printf("%i.%06i - %i.%06i = %f\n", tp.tv_sec, tp.tv_usec, battleStartTime.tv_sec, battleStartTime.tv_usec, deltas);
		chrononsPerSecond = (deltas>0.001 ? deltaCronons/deltas : deltaCronons*1.0 );
	}
	
	RemoveBattleTimer();
	RemoveChrononsPerSecondTimer();
	
	cleanUpAfterCombat();
	
	// clean up after the battle
	SetControlTitleWithCFString( gBattleButton, CFSTR("Battle") );
	// HideControl(goButton);
	// HideControl(pauseButton);
	// HideControl(stepButton);
	// HideControl(chrononButton);

	enableSelectionSpecificControls();
	
	Draw1Control( gArenaView );
	Draw1Control( gCampView );
	Draw1Control( gChrononView );
}

void startBattle(short repeatFlag)
{
	OSStatus err = noErr;
	
	// start the battle
	if (setupCombat(repeatFlag)) {
		SetControlTitleWithCFString( gBattleButton, CFSTR("Halt") );
		
		// redraw the whole window
		Draw1Control( gArenaView );
		Draw1Control( gCampView );
		Draw1Control( gChrononView );
		
		// don't let the user change robot settings during a battle
		disableSelectionSpecificControls();
		
		err = InstallChrononsPerSecondTimer();
		if (err == noErr) {
			if (gPrefs.battleSpeed != kRoboWarDisplayFast)
				err = InstallBattleTimer();
			else {
				// reset the chronons per second calculation variables
				setupChrononBattle();
				fireBattleEvent();
			}
		}
	}
	
	if (err != noErr)
		finishBattle();
}
