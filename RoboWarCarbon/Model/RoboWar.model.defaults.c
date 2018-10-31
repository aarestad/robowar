/*
 *  RoboWar.model.projectiles.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Tue Jul 06 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "Tokens.h"

// ----- from main.c -----
extern RgnHandle		explosionMasks[8];	// Section of exploding robot to display
extern shot				*shots;				/* Head of list of shots */

extern CIconHandle		bulletGW;			//Bullet GWorlds...
extern CIconHandle		hellBoreGW;
extern CIconHandle		mineGW;
extern CIconHandle		newMineGW;
extern CIconHandle		droneGW[8];

extern GenericIcon		botGW[maxBots][2];  // Default robot image GWorlds
extern GenericSound		defSnds[10];  // Default robot sounds

// ----- from RoboWar.errors.c -----
extern OSErr displayErr(char *errCode, char *errName, char *proc);
extern OSStatus checkNavErr(OSStatus err, char *proc);
extern OSErr checkFileErr(OSStatus err, char *proc);
extern OSErr checkAppleEventErr(OSStatus err, char *proc);
extern OSErr checkMemErr(char *proc);
extern OSErr checkResErr(char *proc);

// ----- from RoboWar.model.icons.c -----
extern void DisposeGenericIcon( GenericIcon * icon );
extern void GetGenericIcon( SInt16 iconID, GenericIcon * icon );

// ----- from RoboWar.model.sounds.c -----
extern void DisposeGenericSound( GenericSound * sound );
extern void GetGenericSoundFromFile( CFURLRef url, GenericSound * sound, SInt32 *errorCode );

void loadDefaultIcons(void)
{
	short i;

	for (i=0; i<maxBots; i++) {
		GetGenericIcon( 500 + i, &botGW[i][0] );
		checkResErr("RoboWar.model.projectiles:loadDefaultIcons:1");
	}
	for (i=0; i<maxBots; i++) {
		GetGenericIcon( 506 + i, &botGW[i][1] );
		checkResErr("RoboWar.model.projectiles:loadDefaultIcons:1");
	}
	for (i=0; i<8; i++) {
		explosionMasks[i] = NewRgn();
		OpenRgn();
		MoveTo (0,0);
		switch (i) {
			case 0:  LineTo (16,0); LineTo (16,16); break;
			case 1:  LineTo (0,16); LineTo (16,16); break;
			case 2:  LineTo (0,16); LineTo (-16,16); break;
			case 3:  LineTo (-16,0); LineTo (-16,16); break;
			case 4:  LineTo (-16,0); LineTo (-16,-16); break;
			case 5:	 LineTo (0,-16); LineTo (-16,-16); break;
			case 6:  LineTo (0,-16); LineTo (16,-16); break;
			case 7:  LineTo (16,0); LineTo (16,-16); break;
		}
		LineTo(0,0); 
		CloseRgn(explosionMasks[i]);
	}
	
	bulletGW = GetCIcon(600);
	checkResErr("RoboWar.model.projectiles:loadDefaultIcons:2");
	
	hellBoreGW = GetCIcon(601);
	checkResErr("RoboWar.model.projectiles:loadDefaultIcons:3");
	
	newMineGW = GetCIcon(602);
	checkResErr("RoboWar.model.projectiles:loadDefaultIcons:4");
	
	mineGW = GetCIcon(603);
	checkResErr("RoboWar.model.projectiles:loadDefaultIcons:5");
	
	for (i=0; i<8; i++) {
		droneGW[i] = GetCIcon(604+i);
		checkResErr("RoboWar.model.projectiles:loadDefaultIcons:6");
	}
}

void loadDefaultSounds(void)
{
	short i;
	
	CFBundleRef bundle = CFBundleGetMainBundle();
	CFURLRef url;
	char * names[10] = {
		"Gun", "Missile", "NukeBang", "Laser", "Hellbore", 
		"Mine", "Drone", "Death", "Collision", "ShotHit"
	};
	CFStringRef wav = CFStringCreateWithCString( NULL, "wav", kCFStringEncodingUTF8 );
	CFStringRef name;
	
	for (i=0; i<10; i++) {
		name = CFStringCreateWithCString( NULL, names[i], kCFStringEncodingUTF8 );
		url = CFBundleCopyResourceURL( bundle, name, wav, NULL );
		GetGenericSoundFromFile( url, &defSnds[i], NULL );
		CFRelease( url );
		CFRelease( name );
	}
	CFRelease( wav );
}
