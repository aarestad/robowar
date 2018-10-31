/* Registration.c */

/* Written 1/6/91 by David Harris
   Updated 4/23/95 to support Digital Money

	This file contains routines for checking registration and saving
	RoboWar preferences.
*/

//--- 19 apr 97 --- I have deleted the colorIocnMode Variable as it was unused and 
//					is now obsoleate

/* #includes */

#include <Carbon/Carbon.h>
#include "robotypes.h"
//#include "DMIdeveloper.h.c"

/* Types */

typedef struct oldPrefStruct {
	short 		version;
	short 		displayCode;
	short 		soundFlag;
	short 		battleSpeed;
	short 		maxPoints;
	long 		code;
	char 		registered[80];
} oldPrefStruct;

/*typedef struct prefStruct {
	short 		version;
	short 		displayCode;
	short 		soundFlag;
	short 		battleSpeed;
	short 		maxPoints;
	long 		code;
	char 		registered[80];
	short		createTournyLogQ;
	short		showBugyRobotDialogQ
	short  		syntaxColoringQ;
	RGBColor  	commentColor;
	RGBColor	labelColor;
	RGBColor	mainTextColor;
} prefStruct;*/

short				sndQuality;			/* Recording rate of sound */

/* Externals */

//extern char			registered[80];		/* Null = not registered */
//extern long			code;				/* Registration code */
//extern short		displayCode;			/* 1 = Redraw Robots */
//extern short		soundFlag;			/* 1 = Play sounds in game */
extern short		oldSoundFlag;
//extern short		battleSpeed;		/* 0 = Fast, 4 = Slowest */
extern short		maxPoints;
extern MenuHandle	myMenus[8];			/* Handles to program's menus */
extern WindowPtr 	myWindow;			/* The program's window */

extern prefStruct	gPrefs;				// holds prefs
/* Globals */

short RoboWarRefNum;

/* Prototypes */

void readPrefs(void);
void readPrefsFromFile(short);
void writePrefs(void);
long encodeUserName(char*);
void initAutoPay(digiMonBlock*);
void doAutopayRegistration(void);
void doRegistration(void);
void drawRegistration(void);

/* in Util.c */
extern void reportMessage(char *message1,char *message2);
extern OSErr checkFileErr(OSErr err,char *proc);
extern void installButtonOutline(DialogPtr theDialog,short itemNo);

/* Functions */

void readPrefs(void)
{
	short refNum;
	
	GetVol(NULL,&RoboWarRefNum);
/*	if (FSOpen("\pSystem Folder:Preferences:RoboPrefs",RoboWarRefNum,&refNum) == noErr) {
		readPrefsFromFile(refNum);
	}
	else */if (FSOpen("\pRoboPrefs",RoboWarRefNum,&refNum) != noErr) { /* Can't open preferences */
		gPrefs.registered[0] = 0;
		gPrefs.displayCode = 1;
		gPrefs.soundFlag = 1;
		gPrefs.battleSpeed = 1;
		gPrefs.maxPoints = 9;
		gPrefs.version = 443;
		gPrefs.createTournyLogQ = false;
		gPrefs.showBugyRobotDialogQ = true;
		gPrefs.syntaxColoringQ = false;
		gPrefs.commentColor.red = 0xFFFF;
		gPrefs.commentColor.green = 0x0000;
		gPrefs.commentColor.blue = 0x0000;
		gPrefs.labelColor.red = 0x0000;
		gPrefs.labelColor.green = 0x0000;
		gPrefs.labelColor.blue = 0xFFFF;
		gPrefs.mainTextColor.red = 0x0000;
		gPrefs.mainTextColor.green = 0x0000;
		gPrefs.mainTextColor.blue = 0x0000;
		gPrefs.tournyCreatorType = 'ttxt';
		gPrefs.showMoveAndShootAlert = true;
		gPrefs.rules_noMoveShoot = true;
		gPrefs.rules_noLazers = true;
		gPrefs.rules_noDrones = true;
	}
	else {
		readPrefsFromFile(refNum);
	}
	oldSoundFlag = gPrefs.soundFlag;
	sndQuality = 1; /* Eventually save this in preferences file */
}

void readPrefsFromFile(short refNum)
{
	const		kVersion_RoboWar = 451;
	prefStruct prefs;
	long count;
	
	//count = sizeof(prefs);
	GetEOF(refNum, &count);
	if( count > sizeof(prefStruct) )
	{
		count = sizeof(prefStruct);
		reportMessage( "Your RoboWar prefs file is too new or damaged.", "it has been updated." );
	}
	checkFileErr( FSRead(refNum,&count,&prefs), "Registration:readPrefsFromFile");
	
	if( count != sizeof(prefStruct) )
	{
		reportMessage( "Your RoboWar prefs file is old or damaged.", "it has been updated." );
	}
	
	//if (encodeUserName(prefs.registered) == prefs.code) {
	//	code = prefs.code;
	//	strcpy(registered,prefs.registered);
	//}
	//else {
	//	code = 0;
	//	registered[0] = 0;
	//}
	
	gPrefs.version 			= prefs.version;
	gPrefs.displayCode 		= prefs.displayCode;
	if (gPrefs.displayCode == 0) 
		gPrefs.displayCode 	= 2;
	
	gPrefs.soundFlag 		= prefs.soundFlag;
	gPrefs.battleSpeed 		= prefs.battleSpeed;
	gPrefs.maxPoints 		= prefs.maxPoints;
	
	if (encodeUserName(prefs.registered) == prefs.code) {
		gPrefs.code 		= prefs.code;
		strcpy(gPrefs.registered,prefs.registered);
	}
	else {
		gPrefs.code 			= 0;
		gPrefs.registered[0] 	= 0;
	}
	
	//gPrefs.code = prefs.code;
	//gPrefs.registered = prefs.registered;
	
	if( prefs.version == kVersion_RoboWar )
	{
		gPrefs.version 					= kVersion_RoboWar;
		gPrefs.createTournyLogQ 		= prefs.createTournyLogQ;
		gPrefs.showBugyRobotDialogQ 	= prefs.showBugyRobotDialogQ;
		gPrefs.syntaxColoringQ 			= prefs.syntaxColoringQ;
		gPrefs.commentColor 			= prefs.commentColor;
		gPrefs.labelColor 				= prefs.labelColor;
		gPrefs.mainTextColor 			= prefs.mainTextColor;
		gPrefs.tournyCreatorType 		= prefs.tournyCreatorType;
		gPrefs.showMoveAndShootAlert 	= prefs.showMoveAndShootAlert;
		gPrefs.rules_noMoveShoot 		= prefs.rules_noMoveShoot;
		gPrefs.rules_noLazers 			= prefs.rules_noLazers;
		gPrefs.rules_noDrones			= prefs.rules_noDrones;
	}
	else
	{
		gPrefs.version 					= kVersion_RoboWar;
		gPrefs.createTournyLogQ 		= false;
		gPrefs.showBugyRobotDialogQ 	= true;
		gPrefs.syntaxColoringQ 			= false;
		gPrefs.commentColor.red 		= 0xFFFF;
		gPrefs.commentColor.green 		= 0x0000;
		gPrefs.commentColor.blue 		= 0x0000;
		gPrefs.labelColor.red 			= 0x0000;
		gPrefs.labelColor.green 		= 0x0000;
		gPrefs.labelColor.blue 			= 0xFFFF;
		gPrefs.mainTextColor.red 		= 0x0000;
		gPrefs.mainTextColor.green 		= 0x0000;
		gPrefs.mainTextColor.blue 		= 0x0000;
		gPrefs.tournyCreatorType 		= 'ttxt';
		gPrefs.showMoveAndShootAlert 	= true;
		gPrefs.rules_noMoveShoot 		= true;
		gPrefs.rules_noLazers 			= true;
		gPrefs.rules_noDrones 			= true;
	}
	
	FSClose(refNum);
	CheckItem(myMenus[6],gPrefs.displayCode,1);
	CheckItem(myMenus[4],sound_,!gPrefs.soundFlag);
	CheckItem(myMenus[5],gPrefs.battleSpeed+1,1);
}

void writePrefs(void)
{
	short refNum,err;
	prefStruct prefs;
	long count;
	
	/* Write preferences to System Folder:Preferences if possible, otherwise in run directory */
	/* Not yet implemented */
	
	Create("\pRoboPrefs",RoboWarRefNum,'RWAR','RobP');
	if (checkFileErr(FSOpen("\pRoboPrefs",RoboWarRefNum,&refNum),
		"Registration:writePrefs:FSOpen") == noErr) {
		prefs.version 				= 451;
		prefs.displayCode 			= gPrefs.displayCode;
		prefs.soundFlag 			= gPrefs.soundFlag;
		prefs.battleSpeed 			= gPrefs.battleSpeed;
		prefs.maxPoints 			= gPrefs.maxPoints;
		prefs.code 					= gPrefs.code;
		prefs.createTournyLogQ 		= gPrefs.createTournyLogQ;
		prefs.showBugyRobotDialogQ 	= gPrefs.showBugyRobotDialogQ;
		prefs.syntaxColoringQ 		= gPrefs.syntaxColoringQ;
		prefs.commentColor 			= gPrefs.commentColor;
		prefs.labelColor 			= gPrefs.labelColor;
		prefs.mainTextColor 		= gPrefs.mainTextColor;
		prefs.rules_noMoveShoot 	= gPrefs.rules_noMoveShoot;
		prefs.rules_noLazers		= gPrefs.rules_noLazers;
		prefs.rules_noDrones 		= gPrefs.rules_noDrones;
		
		strcpy(prefs.registered,gPrefs.registered);
		count = sizeof(prefs);
		
		prefs.tournyCreatorType = gPrefs.tournyCreatorType;
		prefs.showMoveAndShootAlert = gPrefs.showMoveAndShootAlert;
		
		err = FSWrite(refNum,&count,&prefs);
		FSClose(refNum);
	}
}

long encodeUserName(char *name)
{
	long result;
	short i = 0;
	
	result = 4224;
	while (name[i++]) 
		result += i*name[i-1]+i;
	return result;
}

void initAutoPay(digiMonBlock *myDMCB)
{
// *******************************************************************
// Copyright 1995 Digital Money, Inc.
// You may use this source code in your own applications.
//
// This is a sample Digital Money Control Block (DMCB) initialization
// for use in version 4.8 of the Digital Money AutoPay software.
// See AutoPay manual for more information.
// This code released April 5, 1995.
// *******************************************************************

	short			i;

	// General settings
	
	
	strcpy(myDMCB->programName,"RoboWar 4.1.1");
	myDMCB->returnSerialNum=1; 						// 1=true; 0=false
	myDMCB->areAdditionalItemsForSale=1;			// 1=true; 0=false
	strcpy(myDMCB->programPassword,"tempPassword");
	strcpy(myDMCB->programID,"123456");
	strcpy(myDMCB->programSource,"source1");
	

	// Security
	
	// This is a secret string of ascii characters used for encryption.
	// You should keep this key confidential, even among your own employees.
	// The string is comprised of visible ASCII characters - i.e. don't
	// use control characters. But punctuation is okay.
	
	strcpy(myDMCB->encodeMeth,"R@O#B$O%W^A&R*");

	// Screen Text
	
	// You can alter the text that appears on the top of each dialog box displayed
	// by Digital Money. Normally, Digital Money reads "styled text" resources
	// from your resource file, but if you want to change the text on the fly, so
	// to speak, you can just pass a pointer leading to the appropriate
	// text and style handle. Note that you must first initialize all 10 text pointers
	// to zero so that Digital Money can tell the difference between a zero pointer
	// (i.e. you don't want to replace the default text in the resource file) and a
	// non-zero pointer (you *do* want to change the text). See below for an example.
	
	for (i=0; i<=9; i++)
	{
		myDMCB->screenText[i]=0;
	}
	
	// Next be sure to allocate memory for any pointer that you want Digital Money
	// to use. For instance, to change the text that appears on the opening screen,
	// set the screenText[0] pointer, like this:
	
	myDMCB->screenText[0] = NewPtr(80);
	strcpy(myDMCB->screenText[0],"For $15, you can register for RoboWar.");
	
	// ...for a complete list of which array item corresponds to which dialog,
	// see printed docs.
	
	// The users name
	
	// If you already know the users name for some reason, you should send it
	// to the DM Module, so that DM doesn't have to ask the user for it. If you
	// don't know it, then **be sure** to set the usersName string to null. In
	// any case, if the user successfully completes enough of the DM transaction,
	// his name will be returned to you in this string, should you want to use it,
	// for registration splash screens or whatever.
	
	strcpy(myDMCB->usersName,""); 	// I don't know it, so it to null!
	
	// Your Product Catalog
	
	myDMCB->numItemsInCatalog=2;
 
 	// first, initialize pointers for each item in catalog
 	
 	for (i=0; i<=myDMCB->numItemsInCatalog-1; i++)	// notice first item is item #0
 	{
 		myDMCB->catalogItem[i]=(catalogItemType *)NewPtr(sizeof(catalogItemType));
 	}
 	
 	strcpy(myDMCB->catalogItem[0]->name,"Register RoboWar 4.1.1");
	strcpy(myDMCB->catalogItem[0]->prodCode,"123");
	myDMCB->catalogItem[0]->minPurchase=1;
	myDMCB->catalogItem[0]->maxPurchase=1;
	myDMCB->catalogItem[0]->price=15.00;
	myDMCB->catalogItem[0]->numVarCodes=0;
	myDMCB->catalogItem[0]->shUSA=0;
	myDMCB->catalogItem[0]->shFOR=0;
	
 	strcpy(myDMCB->catalogItem[1]->name,"RoboWar Site License");
	strcpy(myDMCB->catalogItem[1]->prodCode,"1234");
	myDMCB->catalogItem[1]->minPurchase=1;
	myDMCB->catalogItem[1]->maxPurchase=1000;
	myDMCB->catalogItem[1]->price=7.50;
	myDMCB->catalogItem[1]->numVarCodes=0;	
	
	// preselect items to be purchased
	// explanation: when the Digital Money module takes control of
	// the user interface, what items do you want to be preselected 
	// for purchase by the user? If nothing, then set the following to 0.

	myDMCB->numItemsPrepurchased=1;
	
	// Notice how the description of the preselected item precisely matches
	// the associated item in the product catalog. Please be careful and do
	// the same!
	
	// The only exception is the "editable" flag, which can be set to false
	// on a pre-selected item, even if the catalog doesn't match this. This 
	// means the user won't be able to remove or edit this preselected item.
	
	strcpy(myDMCB->prepurchaseItem[0].name,"Register RoboWar 4.1.1");
	strcpy(myDMCB->prepurchaseItem[0].prodCode,"123");
	strcpy(myDMCB->prepurchaseItem[0].varCode,"");
	myDMCB->prepurchaseItem[0].price=15.00;
	myDMCB->prepurchaseItem[0].quantity=1;
	myDMCB->prepurchaseItem[0].editable=1;			// 1=true; 0=false
	myDMCB->prepurchaseItem[0].minPurchase=1;
	myDMCB->prepurchaseItem[0].maxPurchase=1;
	myDMCB->prepurchaseItem[0].shUSA=0;
	myDMCB->prepurchaseItem[0].shFOR=0;
	
}

void doAutopayRegistration(void)
{
	typedef pascal long (*MyCodePtr) (long param);
	
	digiMonBlock 	*myDMCB;
	OSErr			result;
	MyCodePtr		*myCRHandle;
	
	myDMCB = (digiMonBlock*)NewPtr(sizeof(digiMonBlock));
	
	/* Initialize AutoPay */
	initAutoPay(myDMCB);
	
	/* Execute the AutoPay module */
	
	myCRHandle = (MyCodePtr*) GetResource('CODE',60);
	MoveHHi ((Handle)myCRHandle);
	HLock((Handle)myCRHandle);
	HideWindow(myWindow);
	result = (*myCRHandle)((long)myDMCB);
	ReleaseResource((Handle)myCRHandle);
	
	DisposePtr((Ptr)myDMCB);
	ShowWindow(myWindow);
	SetPort (myWindow);
}

/*
void doRegistration(void)
{
	DialogPtr theDialog;
	short itemHit,type;
	Handle item;
	Rect box;
	Str255 text;
	long newCode;
	
	theDialog = GetNewDialog(RegisterDlogID,NULL,(WindowPtr)-1);
	installButtonOutline(theDialog,8);
	do {
		ModalDialog(NULL,&itemHit);
	} while (itemHit != 1 && itemHit != 2);
	if (itemHit == 1) {
		GetDialogItem(theDialog,6,&type,&item,&box);
		GetDialogItemText(item,text);
		PtoCstr(text);
		if (text[0]) { /* Don't reregister if they entered null string 
			strcpy(registered,(char*)text);
			GetDialogItem(theDialog,7,&type,&item,&box);
			GetDialogItemText(item,text);
			PtoCstr(text);
			sscanf((char*)text,"%ld",&newCode);
			if (newCode == encodeUserName(registered)) code = newCode;
			else if (registered[0]) {
				reportMessage("Sorry, that registration number","is not correct.");
				registered[0] = 0;
			}
		}
	}
	DisposeDialog(theDialog);
}
*/
/*
void drawRegistration(void)
{
	Str255 msg;
	
	if (registered[0]) sprintf((char*)msg,"Registered to: %s",registered);
	else sprintf((char*)msg,"Unregistered");
	CtoPstr((char*)msg);
	MoveTo ((474-StringWidth(msg))/2,112);
	DrawString(msg);
	
	TextFont(times);
	TextSize(14);
	TextFace(bold);
	if (!registered[0]) {
		sprintf((char*)msg,"Choose Help from Apple menu to register.");
		CtoPstr((char*)msg);
		MoveTo((474-StringWidth(msg))/2,240);
		DrawString(msg);
	}
	TextFace(0);
}
 */