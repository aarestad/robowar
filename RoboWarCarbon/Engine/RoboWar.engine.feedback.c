/*
 *  RoboWar.engine.feedback.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Sun Jun 27 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "RoboWar.model.preferences.h"

// ----- globals from main.c -----
extern short			numBots;
extern robot			rob[maxBots];
extern short			botSelected;
extern short			isBattle;
extern short			isTournament;

// ----- from RoboWar.engine.combat.c -----
extern robot *who;
extern short errorInstruction;
extern short cycleNum;

extern void checkDeath();

// ----- from RoboWar.model.sounds.c -----
extern void PlayGenericSound( GenericSound * sound );

// ----- global variables -----
long robotErrorMessageTime;

extern GenericSound	defSnds[10];  // Default robot sounds


pascal Boolean feedbackTimeoutFilter(DialogPtr theDialog,EventRecord *theEvent,short *itemHit)
{
#pragma unused (theDialog)
	// originally from ./Misc/Util.c

	char c;
	
	if (TickCount()-robotErrorMessageTime > (900-600*isTournament)) {
		*itemHit = 1;
		return 1; 
	}
	if (theEvent->what == keyDown) {
		c = theEvent->what & charCodeMask;
		if (c == 13 || c == 3) {
			*itemHit = 1;
			return 1;
		}
	}
	return 0;
}

void robotError(char *message, short shouldKillRobot)
{
	// originally from ./Interface/ArenaControl.c
	OSErr err;
	Str255 errorText, explanationText, tempBotName;
	short result = 0;
	static AlertStdAlertParamRec paramRec = {
			false,
			false,
			NULL,
			(ConstStringPtr)kAlertDefaultOKText,
			NULL, // no cancel text
			"\pFind Error", // other text
			kAlertStdAlertOKButton, // OK button is default
			0, // no cancel button
			kWindowDefaultPosition
		};
	
	if( shouldKillRobot )
	{
		who->progPtr--;
		
		who->damage = -10;
		cycleNum = who->hardware.processorSpeed;
		who->scan = 32000;
		checkDeath();
	}
	
	if (paramRec.filterProc == NULL)
		paramRec.filterProc = NewModalFilterUPP(&feedbackTimeoutFilter);
	
	if (isBattle == true && gPrefs.showBugyRobotDialogQ == true) {
		
		CopyPascalStringToC(who->name, tempBotName);
		tempBotName[11] = 0; /* Truncate to 11 characters */
		
		// - Set message 2
		sprintf(explanationText,"Robot: %s Instruction: %d.",tempBotName,who->progPtr);
		CopyCStringToPascal(explanationText, explanationText);
		
		// - Set message 1
		sprintf(errorText, "%s", message);
		CopyCStringToPascal(errorText, errorText);
		
		robotErrorMessageTime = TickCount();
		err = StandardAlert(
				kAlertCautionAlert,
				errorText, explanationText,
				&paramRec,
				&result
			);
		if (err != noErr) SysBeep(30);
	}
	if (result == kAlertStdAlertOtherButton) { /* Find Error in drafting board */
		isBattle = 0;
		botSelected = who->number;
		errorInstruction = who->progPtr - 1;
	}
}

void reportMessage(char *message1,char *message2)
{
	// originally from ./Misc/Util.c
	OSErr err;
	Str255 errorText, explanationText;
	static AlertStdAlertParamRec paramRec = {
			false,
			false,
			NULL,
			(ConstStringPtr)kAlertDefaultOKText,
			NULL, // no cancel text
			NULL, // other text
			kAlertStdAlertOKButton, // OK button is default
			0, // no cancel button
			kWindowDefaultPosition
		};
	if (paramRec.filterProc == NULL)
		paramRec.filterProc = NewModalFilterUPP(&feedbackTimeoutFilter);
	
	CopyCStringToPascal(message1, errorText);
	CopyCStringToPascal(message2, explanationText);
	
	robotErrorMessageTime = TickCount();
	err = StandardAlert(
			kAlertNoteAlert,
			errorText, explanationText,
			&paramRec,
			NULL
		);
	if (err != noErr) SysBeep(30);
}

void doSoundEffects(shot *cur)
{
	/* Play sounds of launched weapons */
	while (cur != NULL) {
		//if (cur->soundFlag) {
			switch(cur->type) {
				case gun: PlayGenericSound(&defSnds[GunSndID]);
						  break;
				case missile: PlayGenericSound(&defSnds[MissileSndID]);
							 break;
				case hellBore: PlayGenericSound(&defSnds[HellSndID]);
						  break;
				case drone: PlayGenericSound(&defSnds[DroneSndID]);
						  break;
				case laser: PlayGenericSound(&defSnds[LaserSndID]);
							break;
				case newMine: PlayGenericSound(&defSnds[MineSndID]);
						  break;
			}
			//cur->soundFlag = 0;
		//}
		cur = cur->next;
	}	
}
