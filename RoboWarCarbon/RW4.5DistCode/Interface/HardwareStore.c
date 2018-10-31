/* HardwareStore.c */

/*	Written 12/30/89 for RoboWar project
	(c) 1989 David Harris
	
	This file includes the information for running the
	hardware store..
*/

/* #includes */

#include <Carbon/Carbon.h>
#include "robotypes.h"

/* Globals */

hardwareInfo	hardware;				/* The robot's hardware */
ControlHandle	radioButtons[numRadio];	/* Radio buttons for advantages */
ControlHandle	checkBoxes[numCheck];	/* Check buttons for options */
short			pressed[6];				/* Which radio button is pressed in a group */

/* External Variables */

extern	WindowPtr		myWindow;
extern	EventRecord		myEvent;
extern	robot			rob[maxBots];
extern	short			controlChange;
extern 	short			numBots;
extern	short			botSelected;
extern	short			modifyFlag;
extern	Str255			noName;
extern	short			mode;
extern	ControlHandle	iconCheckBoxes[kIconCheckBoxesQty];	/* Check buttons for icon choices */

/* Prototypes */

void countAdvantages(hardwareInfo *hardware);
void adjustAdvantages(hardwareInfo *hardware);
void createRadioButtons(void);
void saveHardwareInfo(void);
hardwareInfo getHardware(void);
void initHardware(void);
void closeHardware(void);
void clickHardware(void);
void updateHardware(void);
void trackRadioButton(ControlHandle what);
void trackCheckBox(ControlHandle what);

/* in Util.c */
extern Boolean sameBot(short);
extern void reportMessage(char*,char*);
extern void checkMemErr(char *proc);
extern void checkResErr(char *proc);
extern void setVolume(short vRefNum);
extern void restoreVolume(void);

/* functions */

void countAdvantages(hardwareInfo *hardware) // done
{
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

void adjustAdvantages(hardwareInfo *hardware)
{	
	hardware->advantages = 0;
	switch (pressed[0]) {
		case 0: hardware->energyMax = 150; break;
		case 1: hardware->energyMax = 100; break;
		case 2: hardware->energyMax = 60; break;
		case 3: hardware->energyMax = 40; break;
	}
	switch (pressed[1]) {
		case 4: hardware->damageMax = 150; break;
		case 5: hardware->damageMax = 100; break;
		case 6: hardware->damageMax = 60; break;
		case 7: hardware->damageMax = 30; break;
	}
	switch (pressed[2]) {
		case 8: hardware->shieldMax = 100; break;
		case 9: hardware->shieldMax = 50; break;
		case 10: hardware->shieldMax = 25; break;
		case 11: hardware->shieldMax = 0; break;
	}
	switch (pressed[3]) {
		case 12: hardware->processorSpeed = 50; break;
		case 13: hardware->processorSpeed = 30; break;
		case 14: hardware->processorSpeed = 15; break;
		case 15: hardware->processorSpeed = 10; break;
		case 16: hardware->processorSpeed = 5; break;
	}
	switch (pressed[4]) {
		case 17: hardware->gunType = 3; break;
		case 18: hardware->gunType = 2; break;
		case 19: hardware->gunType = 1; break;
	}
	switch (pressed[5]) {
		case 20: rob[botSelected].turretType = lineTurret; break;
		case 21: rob[botSelected].turretType = dotTurret; break;
		case 22: rob[botSelected].turretType = noTurret; break;
	}
	hardware->missileFlag = GetControlValue(checkBoxes[0]);
	hardware->tacNukeFlag = GetControlValue(checkBoxes[1]);
	hardware->hellboreFlag = GetControlValue(checkBoxes[2]);
	hardware->mineFlag = GetControlValue(checkBoxes[3]);
	hardware->stunnerFlag = GetControlValue(checkBoxes[4]);
	hardware->noNegEnergy = GetControlValue(checkBoxes[5]);
	hardware->probeFlag = GetControlValue(checkBoxes[6]);
	countAdvantages(hardware);
}		

void createRadioButtons(void)
{
	register short i;
	Rect r;
	
	for (i=0; i<numRadio; i++) {
		if (i < 12) {
			r.left = 25; r.right = 133;
			r.top = 15*(i+2+2*(i>3)+2*(i>7))-3;
		}
		else if (i < 20) {
			r.left = 175; r.right = 283;
			r.top = 15*(i-10+2*(i>16))-3;
		}
		else {
			r.left = 315; r.right = 450;
			r.top = 15*(i-20)+111;
		}
		r.bottom = r.top + 15;
		radioButtons[i] = NewControl(myWindow,&r,noName,FALSE,0,0,1,radioButProc,radioRefCon);
		if (radioButtons[i] == NULL) 
			reportMessage("Error allocating controls","");
	}
	for (i=0; i<5; i++) {
		r.left = 175; r.right = 283;
		r.top = 15*i+208; r.bottom = r.top + 15;
		checkBoxes[i] = NewControl(myWindow,&r,noName,FALSE,0,0,1,checkBoxProc,checkRefCon);
		if (checkBoxes[i] == NULL) 
			reportMessage("Error allocating controls","");
	}
	r.left = 315; r.right = 480;
	r.top = 174; r.bottom = 189;
	checkBoxes[5] = NewControl(myWindow,&r,noName,FALSE,0,0,1,checkBoxProc,checkRefCon);
	if (checkBoxes[5] == NULL)
		reportMessage("Error allocating controls","");
	r.left = 25; r.right = 133;
	r.top = 274; r.bottom = 289;
	checkBoxes[6] = NewControl(myWindow,&r,noName,FALSE,0,0,1,checkBoxProc,checkRefCon);
	if (checkBoxes[6] == NULL)
		reportMessage("Error allocating controls","");

	SetControlTitle(radioButtons[0],"\p150");
	SetControlTitle(radioButtons[1],"\p100");
	SetControlTitle(radioButtons[2],"\p60");
	SetControlTitle(radioButtons[3],"\p40");
	SetControlTitle(radioButtons[4],"\p150");
	SetControlTitle(radioButtons[5],"\p100");
	SetControlTitle(radioButtons[6],"\p60");
	SetControlTitle(radioButtons[7],"\p30");
	SetControlTitle(radioButtons[8],"\p100");
	SetControlTitle(radioButtons[9],"\p50");
	SetControlTitle(radioButtons[10],"\p25");
	SetControlTitle(radioButtons[11],"\pZilch");
	SetControlTitle(radioButtons[12],"\p50");
	SetControlTitle(radioButtons[13],"\p30");
	SetControlTitle(radioButtons[14],"\p15");
	SetControlTitle(radioButtons[15],"\p10");
	SetControlTitle(radioButtons[16],"\p5");
	SetControlTitle(radioButtons[17],"\pExplosive");
	SetControlTitle(radioButtons[18],"\pNormal");
	SetControlTitle(radioButtons[19],"\pRubber");
	SetControlTitle(radioButtons[20],"\pLine");
	SetControlTitle(radioButtons[21],"\pDot");
	SetControlTitle(radioButtons[22],"\pNone");
	SetControlTitle(checkBoxes[0],"\pMissiles");
	SetControlTitle(checkBoxes[1],"\pTacNukes");
	SetControlTitle(checkBoxes[2],"\pHellbores");
	SetControlTitle(checkBoxes[3],"\pMines");
	SetControlTitle(checkBoxes[4],"\pStunner");
	SetControlTitle(checkBoxes[5],"\pNo Negative Energy");
	SetControlTitle(checkBoxes[6],"\pProbes");
	switch (hardware.energyMax) {
		case 150: SetControlValue(radioButtons[0],1);
				  pressed[0] = 0;
				  break;
		case 100: SetControlValue(radioButtons[1],1);
				  pressed[0] = 1;
				  break;
		case 60: SetControlValue(radioButtons[2],1);
				  pressed[0] = 2;
				  break;
		case 40: SetControlValue(radioButtons[3],1);
				  pressed[0] = 3;
				  break;
	}
	switch (hardware.damageMax) {
		case 150: SetControlValue(radioButtons[4],1);
				  pressed[1] = 4;
				  break;
		case 100: SetControlValue(radioButtons[5],1);
				  pressed[1] = 5;
				  break;
		case 60: SetControlValue(radioButtons[6],1);
				  pressed[1] = 6;
				  break;
		case 30: SetControlValue(radioButtons[7],1);
				  pressed[1] = 7;
				  break;
	}
	switch (hardware.shieldMax) {
		case 100: SetControlValue(radioButtons[8],1);
				  pressed[2] = 8;
				  break;
		case 50: SetControlValue(radioButtons[9],1);
				  pressed[2] = 9;
				  break;
		case 25: SetControlValue(radioButtons[10],1);
				  pressed[2] = 10;
				  break;
		case 0: SetControlValue(radioButtons[11],1);
				  pressed[2] = 11;
				  break;
	}
	switch (hardware.processorSpeed) {
		case 50: SetControlValue(radioButtons[12],1);
				  pressed[3] = 12;
				  break;
		case 30: SetControlValue(radioButtons[13],1);
				  pressed[3] = 13;
				  break;
		case 15: SetControlValue(radioButtons[14],1);
				  pressed[3] = 14;
				  break;
		case 10: SetControlValue(radioButtons[15],1);
				  pressed[3] = 15;
				  break;
		case 5: SetControlValue(radioButtons[16],1);
				  pressed[3] = 16;
				  break;
	}
	switch (hardware.gunType) {
		case 3: SetControlValue(radioButtons[17],1);
				  pressed[4] = 17;
				  break;
		case 2: SetControlValue(radioButtons[18],1);
				  pressed[4] = 18;
				  break;
		case 1: SetControlValue(radioButtons[19],1);
				  pressed[4] = 19;
				  break;
	}
	switch (rob[botSelected].turretType) {
		case lineTurret: SetControlValue(radioButtons[20],1);
						 pressed[5] = 20;
						 break;
		case dotTurret: SetControlValue(radioButtons[21],1);
						 pressed[5] = 21;
						 break;
		case noTurret: SetControlValue(radioButtons[22],1);
						 pressed[5] = 22;
						 break;
	}
	SetControlValue(checkBoxes[0],hardware.missileFlag);
	SetControlValue(checkBoxes[1],hardware.tacNukeFlag);
	SetControlValue(checkBoxes[2],hardware.hellboreFlag);
	SetControlValue(checkBoxes[3],hardware.mineFlag);
	SetControlValue(checkBoxes[4],hardware.stunnerFlag);	
	SetControlValue(checkBoxes[5],hardware.noNegEnergy);
	SetControlValue(checkBoxes[6],hardware.probeFlag);
}	

void saveHardwareInfo(void)
{
	short refNum,i;
	unsigned long dateTime;
	long **aRes;
	hardwareInfo **bRes;
	short **cRes;
	Handle res1;
	
	if (hardware.advantages > 9) 
		reportMessage("Warning:","Robot has more than 9 advantages");
	if (modifyFlag) {
	   	GetDateTime(&dateTime);
		setVolume(rob[botSelected].vRefNum);
		
		CreateResFile(rob[botSelected].name);
		if ((refNum = OpenResFile(rob[botSelected].name)) == -1)
			reportMessage ("Error writing robot resources","");
		else {
			if ((res1 = GetResource('DATE',hardwareDateID)) != NULL) {
				RemoveResource(res1);
				checkResErr("HardwareStore:saveHardwareInfo:1");
				DisposeHandle(res1);
			}
			if ((res1 = GetResource('HARD',hardwareInfoID)) != NULL) {
				RemoveResource(res1);
				checkResErr("HardwareStore:saveHardwareInfo:2");
				DisposeHandle(res1);
			}
			if ((res1 = GetResource('TURT',turretTypeID)) != NULL) {
				RemoveResource(res1);
				checkResErr("HardwareStore:saveHardwareInfo:3");
				DisposeHandle(res1);
			}
			
			aRes = (long**)NewHandle(4);
			(*aRes)[0] = dateTime;
			AddResource((Handle)aRes,'DATE',hardwareDateID,"\pHardware");
			checkResErr("HardwareStore:saveHardwareInfo:4");
				
			bRes = (hardwareInfo**)NewHandle(sizeof(hardware));
			(*bRes)[0] = hardware;
			AddResource((Handle)bRes,'HARD',hardwareInfoID,"\pHardware Info");
			checkResErr("HardwareStore:saveHardwareInfo:5");
	
			cRes = (short**)NewHandle(2);
			(*cRes)[0] = rob[botSelected].turretType;
			AddResource((Handle)cRes,'TURT',turretTypeID,"\pTurret Type");
			checkResErr("HardwareStore:saveHardwareInfo:6");
				
			CloseResFile (refNum);
		}
		restoreVolume();
		
		/* Adjust robots in camp to use new hardware */
		
		for (i=0; i < numBots; i++)
			if (sameBot(i)) {
				rob[i].turretType = rob[botSelected].turretType;
				rob[i].hardware = hardware;
			}
	}
}

// --- 7.2.99 - rewritten
// - Get Hardware - Gets a robot's hardware...
hardwareInfo getHardware(void) // done
{
	hardwareInfo 	**theRes;	// - the hardware in the resource
	hardwareInfo 	hardware;	// - the hardware in to return
	Ptr				hwPtr;		// - A pointer to the hardware in to return
	short			hardwareSize; // - size of the resource containing hardware
	short			i;			// - loop counter
	
	// - Get the hardware from the robot's resource.
	theRes = (hardwareInfo**)GetResource('HARD',hardwareInfoID);
	
	// - Set the default hardware
	hardware.energyMax = 100;
	hardware.damageMax = 100;
	hardware.shieldMax = 50;
	hardware.processorSpeed = 10;
	hardware.gunType = 2;
	hardware.missileFlag = 0;
	hardware.tacNukeFlag = 0;
	hardware.hellboreFlag = 0;
	hardware.droneFlag = 0;
	hardware.laserFlag = 0;
	hardware.mineFlag = 0;
	hardware.stunnerFlag = 0;
	hardware.noNegEnergy = 0;
	hardware.probeFlag = 0;
	hardware.deathIconFlag = 0;
	hardware.collisionIconFlag = 0;
	hardware.shieldHitIconFlag = 0;
	hardware.hitIconFlag = 0;
	hardware.shieldOnIconFlag = 1;
	
	// - if the robot has a hardware resource... then load the hardware it has.
	if (theRes != NULL)
	{
		// - hwPtr is used to set part of the default hardware to that in the robot's resource
		hwPtr = (Ptr)&hardware;
		// - we need to know the size of the resource so that we don't load more in than 
		// we have space for as would happen if loading in a newwer version of 
		// RoboWar robot. We must also not overwrite the default settings if the robot 
		// contains too little hardware for this version of robowar, in this case we should use 
		// the default settings
		hardwareSize = GetHandleSize((Handle)theRes);
		// - Limmit the size of the harware to load to the current versionof robowar hardware.
		if( hardwareSize > sizeof(hardwareInfo) )
			hardwareSize = sizeof(hardwareInfo);
		// - load the robot's hardware, byte by byte.
		for( i = 0; i < hardwareSize; i++ )
			hwPtr[i] = ((char*)(*theRes))[i];
		// - Give back resource hardware memory.
		ReleaseResource( (char**)theRes );
	}

	// retun loaded hardware.
	return hardware;
}


void initHardware(void)
{
	short refNum;
	
	setVolume(rob[botSelected].vRefNum);
	refNum = OpenResFile(rob[botSelected].name);
	hardware = getHardware();
	CloseResFile(refNum);
	restoreVolume();
	
	createRadioButtons(); 
	adjustAdvantages(&hardware);
	controlChange = 1;
	InvalRect (&myWindow->portRect);
	modifyFlag = 0;
}

void closeHardware(void) /* 5:30, time to go home */
{
	short i;
	
	saveHardwareInfo();
	for (i=0; i<numRadio; i++) 
		if (radioButtons[i] != NULL) {
			(*radioButtons[i])->contrlRect.bottom = (*radioButtons[i])->contrlRect.top;
			(*radioButtons[i])->contrlRect.right = (*radioButtons[i])->contrlRect.left;
			DisposeControl(radioButtons[i]); 
		}
	for (i=0; i<numCheck; i++) 
		if (checkBoxes[i] != NULL) {
			(*checkBoxes[i])->contrlRect.bottom = (*checkBoxes[i])->contrlRect.top;
			(*checkBoxes[i])->contrlRect.right = (*checkBoxes[i])->contrlRect.left;
			DisposeControl(checkBoxes[i]); 
		}
}

void clickHardware(void)
{
}

void updateHardware(void)
{
 	Str255 msg;
	short i;
			
	EraseRect(&myWindow->portRect);
	
	ForeColor (blueColor);
	TextFace (underline);
	TextFont (systemFont);
	TextSize (12);
	MoveTo (305,40); DrawString ("\pHardware:");
	MoveTo (305,90); DrawString ("\pSpecial Options:");
	TextFace (0);
	MoveTo (310,57); DrawString ("\pPoints:");
	
	TextFont (systemFont);
	TextSize (12);
		
	ForeColor (redColor);
	sprintf ((char*)msg,"%d",hardware.advantages);
	CtoPstr((char*)msg);
	MoveTo (360,57); DrawString (msg);
	
	/* Draw Main Panel Boxes */
	ForeColor (blueColor);
	MoveTo(15,10); LineTo(135,10); LineTo(135,89); LineTo(15,89); LineTo (15,10);
	MoveTo (16,90); LineTo (136,90); LineTo (136,11);
	MoveTo(15,100); LineTo(135,100); LineTo(135,179); LineTo(15,179); LineTo (15,100);
	MoveTo (16,180); LineTo (136,180); LineTo (136,101);
	MoveTo(15,190); LineTo(135,190); LineTo(135,269); LineTo(15,269); LineTo (15,190);
	MoveTo (16,270); LineTo (136,270); LineTo (136,191);
	MoveTo(165,10); LineTo(285,10); LineTo(285,104); LineTo(165,104); LineTo (165,10);
	MoveTo (166,105); LineTo (286,105); LineTo (286,11);
	MoveTo(165,115); LineTo(285,115); LineTo(285,179); LineTo(165,179); LineTo (165,115);
	MoveTo (166,180); LineTo (286,180); LineTo (286,116);
	MoveTo(165,190); LineTo (285,190); LineTo(285,286); LineTo(165,286); LineTo(165,190);
	MoveTo (166,287); LineTo (286,287); LineTo (286,191);
	
	/* Draw Main Panel Text */
	ForeColor (redColor);
	MoveTo (20,24); DrawString ("\pEnergy Max");
	MoveTo (20,114); DrawString ("\pDamage Max");
	MoveTo (20,204); DrawString ("\pShield Max");
	MoveTo (170,24); DrawString ("\pProcessor Speed");
	MoveTo (170,129); DrawString ("\pBullets");
	MoveTo (170,204); DrawString ("\pOther Weapons");
	MoveTo (310,108); DrawString ("\pTurret Shape");
	MoveTo (310,171); DrawString ("\pOther Options");
	ForeColor (blackColor);
	TextFont(kFontIDMonaco);
	TextSize(9);

	/* Adjust Controls */
	if (controlChange) {
		controlChange = 0;
		for (i=0; i<numRadio; i++)
			ShowControl(radioButtons[i]);
		for (i=0; i<numCheck; i++)
			ShowControl(checkBoxes[i]);
	}
}

/* Action routines */

void trackRadioButton(ControlHandle what)
{
	short i,old;
	Rect r;
	
	if (TrackControl(what,myEvent.where,NULL)) {
		modifyFlag = 1;
		for (i=0; i<numRadio; i++)
			if (radioButtons[i] == what) switch(i) {
				case 0: 
				case 1:
				case 2:
				case 3: old = pressed[0];
						pressed[0] = i;
						SetControlValue(radioButtons[old],0);
						SetControlValue(radioButtons[i],1);
						break;
				case 4: 
				case 5:
				case 6:
				case 7: old = pressed[1]; 
						pressed[1] = i;
						SetControlValue(radioButtons[old],0);
						SetControlValue(radioButtons[i],1);
						break;
				case 8:
				case 9:
				case 10:
				case 11: old = pressed[2]; 
						 pressed[2] = i;
						 SetControlValue(radioButtons[old],0);
						 SetControlValue(radioButtons[i],1);
						 break;
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:old = pressed[3]; 
						pressed[3] = i;
						SetControlValue(radioButtons[old],0);
						SetControlValue(radioButtons[i],1);
						break;
				case 17: 
				case 18:
				case 19:old = pressed[4]; 
						pressed[4] = i;
						SetControlValue(radioButtons[old],0);
						SetControlValue(radioButtons[i],1);
						break;
				case 20:
				case 21:
				case 22: old = pressed[5];
				 		 pressed[5] = i;
				 		 SetControlValue(radioButtons[old],0);
				 		 SetControlValue(radioButtons[i],1);
				 		 r.top = 254; r.bottom = 286;
				 		 r.left = 305; r.right = 337;
				 		 InvalRect(&r);
				 		 break;
			}
		adjustAdvantages(&hardware);
		r.left = 360; r.right = 500;
		r.top = 44; r.bottom = 57;
		InvalRect (&r);
	}
}

void trackCheckBox(ControlHandle what)
{
	short i;
	Rect r;
	
	if (TrackControl(what,myEvent.where,NULL)) {
		modifyFlag = 1;
		if (mode == hardwareStore) {
			for (i=0; i<numCheck; i++)
				if (checkBoxes[i] == what) 
					SetControlValue(checkBoxes[i],!GetControlValue(checkBoxes[i]));
			adjustAdvantages(&hardware);
			r.left = 360; r.right = 500;
			r.top = 44; r.bottom = 57;
			InvalRect (&r);
		}
		else if (mode == iconFactory) {
			if (iconCheckBoxes[0] == what) {
				hardware.shieldOnIconFlag = !hardware.shieldOnIconFlag;
				SetControlValue(iconCheckBoxes[0], hardware.shieldOnIconFlag);
			}
			if (iconCheckBoxes[1] == what) {
				hardware.deathIconFlag = !hardware.deathIconFlag;
				SetControlValue(iconCheckBoxes[1], hardware.deathIconFlag);
			}
			if (iconCheckBoxes[2] == what) {
				hardware.collisionIconFlag = !hardware.collisionIconFlag;
				SetControlValue(iconCheckBoxes[2], hardware.collisionIconFlag);
			}
			if (iconCheckBoxes[3] == what) {
				hardware.shieldHitIconFlag = !hardware.shieldHitIconFlag;
				SetControlValue(iconCheckBoxes[3], hardware.shieldHitIconFlag);
			}
			if (iconCheckBoxes[4] == what) {
				hardware.hitIconFlag = !hardware.hitIconFlag;
				SetControlValue(iconCheckBoxes[4], hardware.hitIconFlag);
			}
		}
		else {
			reportMessage("Internal Error:","Bad call to trackCheckBox");
		}
	}
}