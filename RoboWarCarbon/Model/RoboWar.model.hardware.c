/*
 *  RoboWar.model.hardware.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Wed Jun 30 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "Tokens.h"
#include "RoboWar.model.preferences.h"


// ----- from RoboWar.errors.c -----
extern OSErr displayErr(char *errCode, char *errName, char *proc);
extern OSStatus checkNavErr(OSStatus err, char *proc);
extern OSErr checkFileErr(OSStatus err, char *proc);
extern OSErr checkAppleEventErr(OSStatus err, char *proc);
extern OSErr checkMemErr(char *proc);
extern OSErr checkResErr(char *proc);


OSErr getHardware( hardwareInfo * info )
{
	// Originally from ./Interface/HardwareStore.c
	
	hardwareInfo 	**theRes;	// - the hardware in the resource
	
	// - Get the hardware from the robot's resource.
	theRes = (hardwareInfo**)GetResource('HARD',hardwareInfoID);
	
	// - Set the default hardware
	info->energyMax = 100;
	info->damageMax = 100;
	info->shieldMax = 50;
	info->processorSpeed = 10;
	info->gunType = 2;
	info->missileFlag = 0;
	info->tacNukeFlag = 0;
	info->hellboreFlag = 0;
	info->droneFlag = 0;
	info->laserFlag = 0;
	info->mineFlag = 0;
	info->stunnerFlag = 0;
	info->noNegEnergy = 0;
	info->probeFlag = 0;
	info->deathIconFlag = 0;
	info->collisionIconFlag = 0;
	info->shieldHitIconFlag = 0;
	info->hitIconFlag = 0;
	info->shieldOnIconFlag = 1;
	
	// - if the robot has a hardware resource... then load the hardware it has.
	if (theRes != NULL)
	{
		short			hardwareSize; // - size of the resource containing hardware
		short			i;			// - loop counter
		
		// - we need to know the size of the resource so that we don't load more in than 
		// we have space for as would happen if loading in a newwer version of 
		// RoboWar robot. We must also not overwrite the default settings if the robot 
		// contains too little hardware for this version of robowar, in this case we should use 
		// the default settings
		hardwareSize = GetHandleSize((Handle)theRes);
		
		// - Limmit the size of the harware to load to the current version of robowar hardware.
		if( hardwareSize > sizeof(hardwareInfo) )
			hardwareSize = sizeof(hardwareInfo);
		
		// - load the robot's hardware, byte by byte.
		for( i = 0; i < hardwareSize; i++ )
			((Ptr)info)[i] = ((Ptr)(*theRes))[i];
		
		ReleaseResource( (Handle)theRes ); // - Give back resource hardware memory.
	}

	// retun loaded hardware.
	return ResError();
}

void countAdvantages(hardwareInfo *hardware)
{
	// Originally from ./Interface/HardwareStore.c
	
	hardware->advantages = 0;
	switch (hardware->energyMax) {
		case 150: hardware->advantages += 3; break;
		case 100: hardware->advantages += 2; break;
		case 60: hardware->advantages += 1; break;
		case 40: break;
		default: hardware->advantages += 100;
	}
	switch (hardware->damageMax) {
		case 150: hardware->advantages += 3; break;
		case 100: hardware->advantages += 2; break;
		case 60: hardware->advantages += 1; break;
		case 30: break;
		default: hardware->advantages += 100;
	}
	switch (hardware->shieldMax) {
		case 100: hardware->advantages += 3; break;
		case 50: hardware->advantages += 2; break;
		case 25: hardware->advantages += 1; break;
		case 0: break;
		default: hardware->advantages += 100;
	}
	switch (hardware->processorSpeed) {
		case 50: hardware->advantages += 4; break;
		case 30: hardware->advantages += 3; break;
		case 15: hardware->advantages += 2; break;
		case 10: hardware->advantages += 1; break;
		case 5: break;
		default: hardware->advantages += 100;
	}
	switch (hardware->gunType) {
		case 3: hardware->advantages += 2; break;
		case 2: hardware->advantages += 1; break;
		case 1: break;
		default: hardware->advantages += 100;
	}
	if (hardware->missileFlag) hardware->advantages++;
	if (hardware->tacNukeFlag) hardware->advantages++;
	if (hardware->droneFlag) hardware->advantages++;
	if (hardware->hellboreFlag) hardware->advantages++;
	if (hardware->mineFlag) hardware->advantages++;
	if (hardware->laserFlag) hardware->advantages++;
	if (hardware->stunnerFlag) hardware->advantages++;
	if (hardware->probeFlag) hardware->advantages++;
}

short checkCheating( hardwareInfo * info )
{
	// Originally from ./Interface/ArenaControl.c
	
	short cheat = 0;
	
	countAdvantages( info );
	
	switch(info->energyMax) {
		case 40:
		case 60:
		case 100:
		case 150: break;
		default: cheat++;
	}
	switch (info->damageMax) {
		case 30:
		case 60:
		case 100:
		case 150: break;
		default: cheat++;
	}
	switch (info->shieldMax) {
		case 0:
		case 25:
		case 50:
		case 100: break;
		default: cheat++;
	}
	switch (info->processorSpeed) {
		case 5:
		case 10:
		case 15:
		case 30:
		case 50: break; 
		default: cheat++;
	}
	switch (info->gunType) {
		case 1:
		case 2:
		case 3: break;
		default: cheat++;
	}
	
	if (info->advantages > gPrefs.maxPoints) cheat++;
	
	// setting maxPoints to 99 allows all cheating.
	if (gPrefs.maxPoints == 99) cheat = 0;
	
	return cheat;	
}
