/*
 *  RoboWar.model.robot.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Mon Jun 28 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 *  All of these functions underwent extreme makeovers to be Carbon compliant.
 *  The biggest change is that We're using Navigation Services for our dialogs
 *  now instead of the older deprecated functions. (Even though the older ones
 *  were MUCH simpler.)
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"
#include "Tokens.h"

typedef OSErr (*ForkOpenFunction)( const FSSpec * spec, SInt8 permission, short * refNum );

// ----- globals from main.c -----
extern WindowRef		gArenaWindow;
extern ControlRef		gBattleButton;
extern ControlRef		gChrononView;
extern ControlRef		gCampView;
extern ControlRef		gArenaView;
extern short			mode;
extern short			isBattle;
extern robot			rob[maxBots];
extern short			botSelected;
extern short			numBots;
extern short			useDebugger;
extern short			rosterChanged;
extern double			sine[360];			/* Sine functions for each degree */
//extern GWorldPtr		botGW[maxBots][2];  /* default bot icons */
extern GenericIcon		botGW[maxBots][2];  /* default bot icons */
extern void disableSelectionSpecificControls();
extern void enableSelectionSpecificControls();
extern void disableCampSpaceSpecificControls();
extern void enableCampSpaceSpecificControls();

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
extern void PutGenericIcon( SInt16 iconID, GenericIcon * icon );
extern void PlotGenericIcon( const Rect * theRect, GenericIcon * icon, RgnHandle mask );

extern void GetGenericSoundFromResource( SInt16 sndID, GenericSound * sound );

// ----- from RoboWar.model.hardware.c -----
extern OSErr getHardware( hardwareInfo * info );
extern short checkCheating( hardwareInfo * info );


Boolean isMatchingFSSpecs( const FSSpec *spec1, const FSSpec *spec2 )
{
	// we can use FSSpecs to see if the files are the same in Carbon
	// because Carbon ONLY allows leaf nodes to be represented as an FSSpec.
	// it doesn't allow paths in the spec.name field.

	if (spec1->vRefNum == spec2->vRefNum
	 && spec1->parID == spec2->parID) {
		int i;
		// compare the pascal string filenames.
		for (i=0;
			 i<=spec1->name[0] && rob[botSelected].name[i] == spec2->name[i];
			 i++);
		if (i == spec1->name[0]) // if the names matched,
			return TRUE;
	}
	
	return FALSE;
}

Boolean sameBot(short target)
{
	// originally from ./Misc/Util.c
	
	// simply determine if the two robots' FSSpecs are the same.
	return isMatchingFSSpecs(
			&rob[botSelected].fileSystemSpecification,
			&rob[target].fileSystemSpecification
		);
}

short loadRobotCode(short who) /* Needs the robot number and vName & vRefNum */
{
	// Originally from ./Interface/ArenaControl.c
	
	short i;
	short **res1 = NULL, **res2 = NULL;
	Handle res = NULL;
	short refNum = -1;
	short success = FALSE;
	char msg[80],msg2[80];
	long loop,dist,test;
	short	**turret;
	
	rob[who].number = who;
	
	/* Get Robot code & length */
	
	// open the file's resource fork.
	refNum = FSpOpenResFile( &rob[who].fileSystemSpecification, fsRdWrPerm );
	if (refNum == -1) {
		CopyPascalStringToC( rob[who].name, msg2 );
		sprintf( msg, "Error opening robot %s.", msg2 );
		sprintf( msg2, "Resource Error #%d.", ResError() );
		displayErr( msg, msg2, NULL );
		goto abortLoadRobotCode;
	}

	// --- Load Robot Code Length
	res1 = (short**)GetResource('RLEN',codeLengthID);
	if (res1 == NULL) rob[who].progSize = 0;
	else {
		rob[who].progSize = **res1;
		res2 = (short**)GetResource('RCOD',robotCodeID);
		if ( res2 == NULL || GetResourceSizeOnDisk( (Handle)res2 ) != 2*(**res1) ) {
			CopyPascalStringToC( rob[who].name, msg2 );
			sprintf( msg, "Error reading robot %s.", msg2 );
			sprintf( msg2, "Discrepancy between 'RLEN' and 'RCOD' resources." );
			displayErr(msg, msg2, NULL);
			goto abortLoadRobotCode;
		}
	}
		
	// --- Load Robot Icon
	// --- 06-30-04 --- the icon loading code has ben abstracted to RoboWar.model.icons.c
	
	for (loop = 0; loop < 10; loop++) // for all possible 10 icons.
		GetGenericIcon( shieldlessID+loop, &rob[who].icons[loop] ); // try to load an icon.
	
	// --- Load Robot Sounds
	for (loop = 0; loop < 10; loop++) {
		GetGenericSoundFromResource(SoundID+loop, &rob[who].sounds[loop]);
	}
	
	// --- Load Robot Program/Code
	// allocate memory for the code.
	rob[who].prog = (short*)NewPtr(rob[who].progSize*2);
	require_noerr( checkMemErr("RoboWar.model.robot:loadRobotCode:1"), abortLoadRobotCode );
	
	// copy the code into memory
	for (i=0; i<rob[who].progSize; i++)
		rob[who].prog[i] = (*res2)[i];
	ReleaseResource( (Handle)res2 );
	
	getHardware( &rob[who].hardware );
	
	// test to see if the robot is a cheater.
	if (checkCheating( &rob[who].hardware )) {
		CopyPascalStringToC( rob[who].name, msg2 );
		sprintf( msg, "Too much hardware in %s.", msg2 );
		sprintf( msg2, "(Use “Arena: Set max points”.)" );
		displayErr(msg, msg2, NULL);
		goto abortLoadRobotCode;
	}

	// --- Load Robot Turret Type
	turret = (short**)GetResource ('TURT',turretTypeID);
	if (turret == NULL)
		rob[who].turretType = lineTurret;
	else {
		rob[who].turretType = **turret;
		ReleaseResource( (Handle)turret );
	}
	
	/* Set Attributes */
	rob[who].aim = 90;
	rob[who].alive = 1;
	rob[who].shield = 0;
	rob[who].icon = 0;
	rob[who].energy = rob[who].hardware.energyMax;
	rob[who].damage = rob[who].hardware.damageMax;
	rob[who].probeParam = damage_;
	rob[who].historyParam = 1;
	for (loop = 0; loop < who; loop++) 
		if (rob[loop].letters[x_] == 5000) {
			rob[loop].letters[y_] = -40;
			rob[loop].letters[x_] = -40;
		}
	do {
		rob[who].letters[x_] = rand()%(boardSize-30)+15;
		rob[who].letters[y_] = rand()%(boardSize-30)+15;
		dist = 1000;
		for (loop = 0; loop < who; loop++) {
			test = pow(rob[who].letters[x_]-rob[loop].letters[x_],2) +
				   pow(rob[who].letters[y_]-rob[loop].letters[y_],2);
			if (test < dist) dist = test;
		}
	} while (dist <625);
	
	success = TRUE;
	
abortLoadRobotCode:
	// clean up
	if (res1) ReleaseResource( (Handle)res1 );
	if (res2) ReleaseResource( (Handle)res2 );
	if (res) ReleaseResource( res );
	if (refNum != -1) {
		CloseResFile( refNum );
		checkResErr( "RoboWar.model.robot:loadRobotCode:2" );
	}
	
	return success;
}

void makeAttemptToOpen(void)
{
	int i;
	
	// attempt to load the robot's code.
	if (loadRobotCode(numBots)) {
		// if successful, add the robot to the camp and arena.
		botSelected = numBots; // mark the new bot as selected
		
		// find out if the password was already entered
		// or rather, only make the user enter the password once.
		for (i=0; i<numBots; i++)
			if (sameBot(i)) rob[botSelected].passwordEntered = 1;
		
		// increment the bot count
		numBots++;
		
		// redraw the necessary controls
		Draw1Control(gArenaView);
		Draw1Control(gCampView);
		
		enableSelectionSpecificControls();
		disableCampSpaceSpecificControls();
		ActivateControl( gBattleButton );
		
		// minor change 6-29-04 -- only mark the roster changed on success
		// (this will clear the history at the beginning of the next battle)
		rosterChanged = 1;
	}
}

void readRobot(void)
{
	short refNum;
	Handle passRes;
	
	/* Assumes robot is the number numBots */
	
	// open the file's resource fork.
	refNum = FSpOpenResFile( &rob[numBots].fileSystemSpecification, fsRdPerm );
	if (refNum == -1) {
		char msg[80], msg2[80];
		CopyPascalStringToC( rob[numBots].name, msg2 );
		sprintf( msg, "Error opening robot %s.", msg2 );
		sprintf( msg2, "Resource Error #%d.", ResError() );
		displayErr( msg, msg2, "RoboWar.model.robot:readRobot:1" );
		return;
	}

	// get the password resource
	passRes = GetResource('!@#$',passwordID);
	if (passRes == NULL) {
		rob[numBots].password[0] = 0;
		rob[numBots].passwordEntered = 1;
	}
	else {
		// load the password as a pascal string
		long passLen;
		passLen = GetHandleSize(passRes);
		rob[numBots].password[0] = passLen;
		memcpy((rob[numBots].password+1), (*passRes), passLen);
		rob[numBots].passwordEntered = 0;
	}
	
	// close the resource fork of the file
	CloseResFile(refNum);
	
	// attempt to load the robot's code.
	makeAttemptToOpen();
}

OSStatus presentSaveDialog( CFStringRef title, CFStringRef message, Boolean * success, Str255 filename, FSSpec * target )
{
	OSStatus err;
	NavDialogRef dialog;
	NavReplyRecord reply;
	Boolean shouldDisposeReply = false;
	
	static NavDialogCreationOptions options = {
		kNavDialogCreationOptionsVersion,
		kNavNoTypePopup | kNavDontAutoTranslate | kNavDontAddTranslateItems,
		{-1, -1},
		NULL,
		NULL,
		NULL, // use default Save button text
		NULL, // use default Cancel button text
		NULL, // no default filename
		NULL, // the message
		0, // preferenceKey... since there is only 1 kind of New dialog, pass 0
		NULL, // no popup menu extensions
		kWindowModalityAppModal,
		NULL
	};
	
	*success = false;
	
	if (options.clientName == NULL) {
		options.clientName = CFSTR( "RoboWar" );
		options.parentWindow = gArenaWindow;
	}
	
	options.windowTitle = CFSTR( "New Robot" );
	options.message = CFSTR( "Name your new robot:" );
	
	// create the navigation dialog
	err = NavCreatePutFileDialog (
			&options, kRoboWarDocumentType, kRoboWarSignature, NULL, NULL, &dialog );
	checkNavErr( err, "RoboWar.model.robot:presentSaveDialog:1" );
	require_noerr( err, abortPresentSaveDialog );
	
	// show the dialog and run modal
	err = NavDialogRun( dialog );
	checkNavErr( err, "RoboWar.model.robot:presentSaveDialog:2" );
	require_noerr( err, abortPresentSaveDialog );
	
	// if the user clicked the Save button...
	if (NavDialogGetUserAction( dialog ) == kNavUserActionSaveAs) {
		AEKeyword keyword;
		DescType type;
		Size actualSize;
		FSCatalogInfo info;
		FSRef parentRef;
		
		// get the dialog's reply... find out what action the user made.
		err = NavDialogGetReply( dialog, &reply );
		checkNavErr( err, "RoboWar.model.robot:presentSaveDialog:3" );
		require_noerr( err, abortPresentSaveDialog );
		shouldDisposeReply = true;
		
		// get the filename that the user typed.
		// convert to a C string for HFS compatibility.
		CFStringGetCString( reply.saveFileName, filename, 255, CFStringGetSystemEncoding() );
		CopyCStringToPascal( filename, filename );
		
		// get the file reference for the parent directory.
		err = AEGetNthPtr( &reply.selection, 1, typeFSRef, &keyword, &type, &parentRef, sizeof(FSRef), &actualSize);
		checkAppleEventErr( (OSErr)err, "RoboWar.model.robot:presentSaveDialog:4" );
		require_noerr( err, abortPresentSaveDialog );
		
		// get the directory ID and volume ref number from the parent reference.
		err = FSGetCatalogInfo ( &parentRef,
				kFSCatInfoVolume|kFSCatInfoNodeID,
				&info,
				NULL, NULL, NULL );
		checkFileErr( (OSErr)err, "RoboWar.model.robot:presentSaveDialog:5" );
		require_noerr( err, abortPresentSaveDialog );
		
		// make the file specification for the new file. (let AppleEvents do the coersion for us)
		err = FSMakeFSSpec( info.volume, info.nodeID, filename, target );
		if (err != fnfErr) { // a file-not-found error is expected when creating a new file.
			checkFileErr( (OSErr)err, "RoboWar.model.robot:presentSaveDialog:6" );
			require_noerr( err, abortPresentSaveDialog );
		}
		
		*success = true;
	}

abortPresentSaveDialog:
	// we're done with the dialog, so fee up the memory.
	if (shouldDisposeReply) NavDisposeReply( &reply );
	if (dialog) NavDialogDispose( dialog );

	return err;
}

OSStatus newRobot(void)
{
	OSStatus err;
	Boolean success;
	
	err = presentSaveDialog(
			CFSTR( "New Robot" ),
			CFSTR( "Name your new robot:" ),
			&success,
			rob[numBots].name,
			&rob[numBots].fileSystemSpecification );
	
	if (success) {
	
		// remove the old file
		if (err != fnfErr) {
			err = FSpDelete( &rob[numBots].fileSystemSpecification );
			checkFileErr( (OSErr)err, "RoboWar.model.robot:newRobot:1" );
			require_noerr( err, abortNewRobot );
		}
		
		// create the file.
		err = FSpCreate( &rob[numBots].fileSystemSpecification,
				kRoboWarSignature, kRoboWarDocumentType, smSystemScript );
		checkFileErr( (OSErr)err, "RoboWar.model.robot:newRobot:2" );
		require_noerr( err, abortNewRobot );
		
		// attempt to load the robot's code.
		makeAttemptToOpen();
	}
	
abortNewRobot:
	return err;
}

OSStatus openRobot(void)
{
	OSStatus err;
	NavDialogRef dialog;
	NavReplyRecord reply;
	Boolean shouldDisposeReply = false;
	NavTypeListPtr typePtr;
	
	static NavDialogCreationOptions options = {
		kNavDialogCreationOptionsVersion,
		kNavNoTypePopup | kNavDontAutoTranslate | kNavDontAddTranslateItems,
		{-1, -1},
		NULL,
		NULL,
		NULL, // use default Save button text
		NULL, // use default Cancel button text
		NULL, // no default filename
		NULL, // the message
		0, // preferenceKey... since there is only 1 kind of New dialog, pass 0
		NULL, // no popup menu extensions
		kWindowModalityAppModal,
		NULL
	};
	static NavTypeList types = {
		kRoboWarSignature,
		0, // reserved
		1, // count
		{ kRoboWarDocumentType }
	};
	
	if (options.clientName == NULL) {
		options.clientName = CFSTR( "RoboWar" );
		options.windowTitle = CFSTR( "Open Robot" );
		options.message = CFSTR( "Open which robot?" );
		options.parentWindow = gArenaWindow;
	}
	
	// create the navigation dialog
	typePtr = &types;
	err = NavCreateChooseFileDialog (
			&options, &typePtr, NULL, NULL, NULL, NULL, &dialog );
	checkNavErr( err, "RoboWar.model.robot:openRobot:1" );
	require_noerr( err, abortOpenRobot );
	
	// show the dialog and run modal
	err = NavDialogRun( dialog );
	checkNavErr( err, "RoboWar.model.robot:openRobot:2" );
	require_noerr( err, abortOpenRobot );
	
	// if the user clicked the Open button...
	if (NavDialogGetUserAction( dialog ) == kNavUserActionChoose
	 || NavDialogGetUserAction( dialog ) == kNavUserActionOpen) {
		AEKeyword keyword;
		DescType type;
		Size actualSize;
		
		// get the dialog's reply... find out what action the user made.
		err = NavDialogGetReply( dialog, &reply );
		checkNavErr( err, "RoboWar.model.robot:openRobot:3" );
		require_noerr( err, abortOpenRobot );
		shouldDisposeReply = true;
	
		// get the file spec for the file. (let AppleEvents do the coersion for us)
		err = AEGetNthPtr( &reply.selection, 1, typeFSS, &keyword, &type, &rob[numBots].fileSystemSpecification, sizeof(FSSpec), &actualSize);
		checkAppleEventErr( (OSErr)err, "RoboWar.model.robot:openRobot:4" );
		require_noerr( err, abortOpenRobot );
		
		// get the robot's name from the FSSpec
		memcpy( rob[numBots].name, rob[numBots].fileSystemSpecification.name, 256 );
		
		// attempt to load the robot file.
		readRobot();
	}
	
abortOpenRobot:
	// we're done with the dialog, so fee up the memory.
	if (shouldDisposeReply) NavDisposeReply( &reply );
	if (dialog) NavDialogDispose( dialog );

	return err;
}

void duplicateRobot(void)
{
	short i;
	
	if (numBots < maxBots && botSelected != maxBots) {
		// make the bots reflect the same file
		FSMakeFSSpec(
				rob[botSelected].fileSystemSpecification.vRefNum,
				rob[botSelected].fileSystemSpecification.parID,
				rob[botSelected].fileSystemSpecification.name,
				&rob[numBots].fileSystemSpecification
			);
		
		
		// copy the bot name
		for (i=0; i<= rob[botSelected].name[0]; i++) 
			rob[numBots].name[i] = rob[botSelected].name[i];
		
		// copy the bot password
		for (i=0; i<= rob[botSelected].password[0]; i++)
			rob[numBots].password[i] = rob[botSelected].password[i];
		
		// copy the password entered flag
		rob[numBots].passwordEntered = rob[botSelected].passwordEntered;
		
		// attempt to load the robot's code.
		makeAttemptToOpen();
	}
}

OSErr copyFork( ForkOpenFunction openFork, const FSSpec * source, const FSSpec * target )
{
	Ptr theData = NULL;
	long length;
	short fileRef;
	OSErr err;
	
	// open the source file's data fork with read access
	err = openFork( source, fsRdPerm, &fileRef );
	checkFileErr( (OSErr)err, "RoboWar.model.robot:copyFork:1" );
	require_noerr( err, abortCopyFork );

	// get the length of the source robot's source code.
	err = GetEOF( fileRef, &length );
	checkFileErr( (OSErr)err, "RoboWar.model.robot:copyFork:2" );
	require_noerr( err, abortCopyFork );
	
	// allocte memory for our buffer
	theData = NewPtr( length );
	err = checkMemErr( "RoboWar.model.robot:copyFork:3" );
	require_noerr( err, abortCopyFork );
	
	// read the source robot's source code.
	err = FSRead( fileRef, &length, theData );
	checkFileErr( (OSErr)err, "RoboWar.model.robot:copyFork:4" );
	require_noerr( err, abortCopyFork );
	
	// close the source file.
	err = FSClose( fileRef ); fileRef = 0;
	checkFileErr( (OSErr)err, "RoboWar.model.robot:copyFork:5" );
	require_noerr( err, abortCopyFork );
	
	// open the target file's data fork with write access
	err = openFork( target, fsWrPerm, &fileRef );
	checkFileErr( (OSErr)err, "RoboWar.model.robot:copyFork:6" );
	require_noerr( err, abortCopyFork );
	
	// write the robot's source code to the target file.
	err = FSWrite( fileRef, &length, theData );
	checkFileErr( (OSErr)err, "RoboWar.model.robot:copyFork:7" );
	require_noerr( err, abortCopyFork );
	
	// set the EOF for the fork
	err = SetEOF( fileRef, length );
	checkFileErr( (OSErr)err, "RoboWar.model.robot:copyFork:8" );
	require_noerr( err, abortCopyFork );
	
abortCopyFork:
	if (fileRef) FSClose( fileRef ); // close the target file.
	if (theData) DisposePtr(theData);
	return err;
}

OSStatus saveAsRobot(void)
{
	OSStatus err;
	Boolean success;
	Str255 newFileName;
	FSSpec newFSS;
	
	if (botSelected == maxBots) return noErr;
	
	err = presentSaveDialog(
			CFSTR( "Save As" ),
			CFSTR( "Save robot as:" ),
			&success,
			newFileName,
			&newFSS );
	
	if (success) {

		// check to see if the destination file is the same as the source.
		if (isMatchingFSSpecs( &newFSS, &rob[botSelected].fileSystemSpecification)) {
			err = checkFileErr( fBsyErr, "RoboWar.model.robot:saveAsRobot:1" );
			goto abortSaveAsRobot;
		}
		
		// remove the old file
		if (err != fnfErr) {
			err = FSpDelete( &newFSS );
			checkFileErr( (OSErr)err, "RoboWar.model.robot:saveAsRobot:2" );
			require_noerr( err, abortSaveAsRobot );
		}
		
		// create the file. (both data and resource forks)
		err = FSpCreate( &newFSS, kRoboWarSignature, kRoboWarDocumentType, smSystemScript );
		checkFileErr( (OSErr)err, "RoboWar.model.robot:saveAsRobot:3" );
		require_noerr( err, abortSaveAsRobot );
		
		// copy the robot's source code to the new file
		err = copyFork( FSpOpenDF, &rob[botSelected].fileSystemSpecification, &newFSS );
		require_noerr( err, abortSaveAsRobot );
		
		// copy the robot's resources (icons, sounds, hardware, etc...) to the new file.
		// originally, we copied each resource 1 at a time, but this was easier... and faster.
		err = copyFork( FSpOpenRF, &rob[botSelected].fileSystemSpecification, &newFSS );
		require_noerr( err, abortSaveAsRobot );

		// make the selected bot reflect the new file
		memcpy( rob[botSelected].name, newFileName, 256); // Str255 is 256 bytes long
		memcpy( &rob[botSelected].fileSystemSpecification, &newFSS, sizeof(FSSpec) );
		
		// tell the program that the roster has changed
		// (this will clear the history at the beginning of the next battle)
		rosterChanged = 1;
		
		// draw the new camp
		Draw1Control( gCampView );
	}

abortSaveAsRobot:
	return err;
}

void closeRobot(void)
{
	short i;
	
	if (numBots && botSelected != maxBots) {
		numBots--;
		
		// dispose of the icons that the robot used.
		for (i=0; i<10; i++)
			DisposeGenericIcon( &rob[botSelected].icons[i] );
		
		// free up the memory used by the robot's source code.
		DisposePtr((Ptr)rob[botSelected].prog);
		checkMemErr("RoboWar.model.robot:closeRobot:1");
		
		// OPENISSUE -- should uncheck 'Use Debugger' menu item
		//  -- possible decrement the useDebugger variable if it is greater than botSelected
		
		// pack the remaining robots in the camp array
		for (i=botSelected; i<numBots; i++) {
			rob[i] = rob[i+1];
			rob[i].number = i;
		}
		
		// clear any pointers that have moved
		rob[numBots].prog = NULL;
		for (i=0; i<10; i++) {
			rob[numBots].icons[i].type = kGenericIconTypeNULL;
			rob[numBots].icons[i].mask = NULL;
			rob[numBots].icons[i].data = NULL;
			rob[numBots].sounds[i].type = kGenericSoundTypeNULL;
			rob[numBots].sounds[i].data = NULL;
		}
		
		// move the selection to something appropriate.
		if (botSelected == numBots) {
			if (numBots == 0) botSelected = maxBots;
			else botSelected = 0;
		}
		
		// redraw the affected controls
		Draw1Control(gArenaView);
		Draw1Control(gCampView);
		
		disableSelectionSpecificControls();
		enableCampSpaceSpecificControls();
		if ( numBots == 0 )
			DeactivateControl( gBattleButton );
		
		rosterChanged = 1;
	}
}

//--- 19 apr 97 --- Updated for Graphic Worlds
// -- 7-1-04 --- updated for Carbon
/*
void drawRobot(short which, short whereX, short whereY, short aim, short iconNum,
				RgnHandle mask, short turretType)
{

	// note: which = which robot is being drawn

	Rect srcRect, dstRect;
	short a;
	register short team, color;
	GWorldPtr	myBot;
	PixMapHandle portPixMap;
	
	if (which >= 0 && whereX < 300) {
		if (rob[which].hardware.deathIconFlag && !rob[which].alive) iconNum = 2;
		else if (rob[which].hardware.hitIconFlag && rob[which].hit == 2) iconNum = 5;
		// shield hits have lower priority
		else if (rob[which].hardware.shieldHitIconFlag && rob[which].hit == 1) iconNum = 4;
		// collision has lower priority
		else if (rob[which].hardware.collisionIconFlag && rob[which].collision) iconNum = 3;
		// shield-on has lowest priority
		else if (rob[which].hardware.shieldOnIconFlag && rob[which].shield > 0) iconNum = 1;
	}
	
	if (which == -1)	// if icon0 doesn't exist... use basic Icon0
		myBot = botGW[botSelected][0];
	else if (which == -2) {	//draw icon0 (for main screen...)
		if(rob[botSelected].gw[0] == NULL)
			myBot = botGW[botSelected][0];
		else
			myBot = rob[botSelected].gw[0];
		}
	else if (rob[which].gw[iconNum] == NULL)	//if icon doesn't exist
		myBot = botGW[which][((iconNum == 1) && rob[which].hardware.shieldOnIconFlag)];
	else  										//icon exists
		myBot = rob[which].gw[iconNum];
	
	portPixMap = GetPortPixMap( myBot );

	// if icon is 1 bit, select color
	if( (*portPixMap)->pixelSize == 1 ) {
		color = true;
		if (which > 0) { // Adjust colors to be same for team members
			team = rob[which].team;
			if (team)
				for (a = 0; a<which; a++)
					if (team == rob[a].team) which = a;
		}
		switch(which) { 
			case 0: ForeColor(redColor); break;
			case 1: ForeColor(cyanColor); break;
			case 2: ForeColor(greenColor); break;
			case 3: ForeColor(blueColor); break;
			case 4: ForeColor(magentaColor); break;
			case 5: 
				if( turretType == 5 ) ForeColor(yellowColor);
				else ForeColor(blackColor);
				break;
			case -1: ForeColor (redColor); break;
			case -2: ForeColor (redColor); break;
		}
		
	}
	else
		color = false;
		
	
	// Set the Robot's rect
	dstRect.top = whereY-16; dstRect.bottom = whereY+16;
	dstRect.left = whereX-16; dstRect.right = whereX+16;
	
	GetPortBounds( myBot, &srcRect ); // get the bounds of the icon.
	
	if (mask) {		// for explosions
		OffsetRgn( mask, whereX, whereY );
		CopyBits( GetPortBitMapForCopyBits( myBot ),
				GetPortBitMapForCopyBits( GetQDGlobalsThePort() ),
				&srcRect, &dstRect, (( color )? srcOr : transparent), mask
			);
		
		OffsetRgn( mask, -whereX, -whereY );
		ForeColor( blackColor );
	}
	else { // normal draw bot
		CopyBits( GetPortBitMapForCopyBits( myBot ),
				GetPortBitMapForCopyBits( GetQDGlobalsThePort() ),
				&srcRect, &dstRect, (( color )? srcOr : transparent), nil
			);
		
		ForeColor(blackColor);
		if (turretType == lineTurret) {
			MoveTo (whereX,whereY);
			PenMode(patXor);
			LineTo (whereX+(short)((radius-1)*sine[(aim+270)%360]),
					whereY-(short)((radius-1)*sine[aim]));
			PenMode(patCopy);
		}
		else if (turretType == dotTurret) {
			PenMode(patXor);
			PenSize(2,2);
			MoveTo (whereX+(short)((radius+2)*sine[(aim+270)%360]),
					whereY-(short)((radius+2)*sine[aim]));
			LineTo (whereX+(short)((radius+2)*sine[(aim+270)%360]),
					whereY-(short)((radius+2)*sine[aim]));
			PenSize(1,1);
			PenMode(patCopy);
		}
	}
}
*/

void drawRobot(short which, short whereX, short whereY, short aim, short iconNum,
				RgnHandle mask, short turretType)
{

	// note: which = which robot is being drawn

	Rect dstRect;
	short a;
	register short team;
	GenericIcon * myBot;
	
	if (which >= 0 && whereX < 300) {
		if (rob[which].hardware.deathIconFlag && !rob[which].alive) iconNum = 2;
		else if (rob[which].hardware.hitIconFlag && rob[which].hit == 2) iconNum = 5;
		// shield hits have lower priority
		else if (rob[which].hardware.shieldHitIconFlag && rob[which].hit == 1) iconNum = 4;
		// collision has lower priority
		else if (rob[which].hardware.collisionIconFlag && rob[which].collision) iconNum = 3;
		// shield-on has lowest priority
		else if (rob[which].hardware.shieldOnIconFlag && rob[which].shield > 0) iconNum = 1;
	}
	
	if (which == -1)	// if icon0 doesn't exist... use basic Icon0
		myBot = &botGW[botSelected][0];
	else if (which == -2) {	//draw icon0 (for main screen...)
		if(rob[which].icons[iconNum].type == kGenericIconTypeNULL)
			myBot = &botGW[botSelected][0];
		else
			myBot = &rob[botSelected].icons[0];
		}
	else if (rob[which].icons[iconNum].type == kGenericIconTypeNULL)	//if icon doesn't exist
		myBot = &botGW[which][((iconNum == 1) && rob[which].hardware.shieldOnIconFlag)];
	else  										//icon exists
		myBot = &rob[which].icons[iconNum];
	
	if (!myBot) {
		CFShow(CFSTR("NULL image!"));
		return;
	}
	
	// if icon is 1 bit, select color
	if( myBot->type == kGenericIconTypeMono ) {
		if (which > 0) { /* Adjust colors to be same for team members */
			team = rob[which].team;
			if (team)
				for (a = 0; a<which; a++)
					if (team == rob[a].team) which = a;
		}
		switch(which) { 
			case 0: ForeColor(redColor); break;
			case 1: ForeColor(cyanColor); break;
			case 2: ForeColor(greenColor); break;
			case 3: ForeColor(blueColor); break;
			case 4: ForeColor(magentaColor); break;
			case 5: 
				if( turretType == 5 ) ForeColor(yellowColor);
				else ForeColor(blackColor);
				break;
			case -1: ForeColor (redColor); break;
			case -2: ForeColor (redColor); break;
		}
		
	}
	
	// Set the Robot's rect
	dstRect.top = whereY-16; dstRect.bottom = whereY+16;
	dstRect.left = whereX-16; dstRect.right = whereX+16;
	
	if (mask) {		// for explosions
		OffsetRgn( mask, whereX, whereY );
		PlotGenericIcon( &dstRect, myBot, mask );
		
		OffsetRgn( mask, -whereX, -whereY );
		ForeColor( blackColor );
	}
	else { // normal draw bot
		PlotGenericIcon( &dstRect, myBot, NULL );
		
		ForeColor(blackColor);
		if (turretType == lineTurret) {
			MoveTo (whereX,whereY);
			PenMode(patXor);
			LineTo (whereX+(short)((radius-1)*sine[(aim+270)%360]),
					whereY-(short)((radius-1)*sine[aim]));
			PenMode(patCopy);
		}
		else if (turretType == dotTurret) {
			PenMode(patXor);
			PenSize(2,2);
			MoveTo (whereX+(short)((radius+2)*sine[(aim+270)%360]),
					whereY-(short)((radius+2)*sine[aim]));
			LineTo (whereX+(short)((radius+2)*sine[(aim+270)%360]),
					whereY-(short)((radius+2)*sine[aim]));
			PenSize(1,1);
			PenMode(patCopy);
		}
	}
}

