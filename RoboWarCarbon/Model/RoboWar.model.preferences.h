/*
 *  RoboWar.model.preferences.h
 *  RoboWar
 *
 *  Created by Sam Rushing on Sun Jul 25 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#ifndef __ROBOWAR_MODEL_PREFERENCES__
#define __ROBOWAR_MODEL_PREFERENCES__ (1)

#include "CarbonWrapper.h"

#define kRoboWarPreferencesCurrentVersion (500)

typedef struct prefStruct {
	short 		version;			/* application version */
	short 		displayCode;		/* 1 = Draw entire field, 2 = draw just stats, 3 = nothing */
	Boolean		soundFlag;			/* 1 = Play sounds in game */
	short 		battleSpeed;		/* 0 = Fast, 4 = Slowest */
	short 		maxPoints;
	Boolean		createTournyLogQ;
	Boolean		showBugyRobotDialogQ;
	Boolean		syntaxColoringQ;
	RGBColor  	commentColor;
	RGBColor	labelColor;
	RGBColor	mainTextColor;
	Boolean		showMoveAndShootAlert;
	Boolean		rules_noMoveShoot;
	Boolean		rules_noLazers;
	Boolean		rules_noDrones;
	short		sndQuality;			/* Recording rate of sound */
} prefStruct;

extern prefStruct gPrefs;

extern void readPrefs(void);
extern void writePrefs(void);

#endif /* __ROBOWAR_MODEL_PREFERENCES__ */