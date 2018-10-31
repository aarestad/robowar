/* Password.c */

/* Written 5/18/90 by David Harris
	This file contains the functions that deal with the
	password on robots.
*/

/* #includes */

#include "CarbonWrapper.h"
#include "RoboTypes.h"

/* external variables */

extern 	robot			rob[maxBots];
extern	short			botSelected;
extern	short			numBots;
extern 	short			mode;
extern  Str255			noName;

/* Globals */

char	realMessage[255];

/* Prototypes */

short encode(char*);
OSErr tweakPassword(short);
pascal Boolean keyFilter(DialogPtr theDialog,EventRecord *theEvent,short *itemHit);
short getPassword(char*);
void recodeSource(char *newPass);
void doPassword(void);

// ----- from RoboWar.errors.c -----
extern OSErr displayErr(char *errCode, char *errName, char *proc);
extern OSErr checkFileErr(OSStatus err, char *proc);
extern OSErr checkMemErr(char *proc);
extern OSErr checkResErr(char *proc);

// ----- from RoboWar.model.robot.c -----
extern Boolean sameBot(short);

/* Functions */

short encode(char *what)
{
	short i,result = 0;
	
	for (i=1; i<= what[0]; i++) 
		result += (what[i] = (what[i]*49+what[i-1]*3)%(220+i));
	return result;
}

OSErr tweakPassword(short who)
{
	/* if the robot cheats, this procedure sets its password to a funny state */

	OSErr err;
	short fileRef,i;
	long length;
	Handle passRes, newRes;
	char msg[20] = "\pcheater";
	Ptr buffer = NULL;

	fileRef = FSpOpenResFile( &rob[who].fileSystemSpecification, fsRdWrPerm );	
		
	passRes = GetResource( '!@#$', passwordID );
	if (passRes == NULL) SysBeep(1);
	else {
		RemoveResource(passRes);
		checkResErr("RoboWar.model.password:tweakPassword:1");
		DisposeHandle(passRes);
	}
	
	encode(msg);
	newRes = NewHandle(msg[0]);
	for (i=1; i<=msg[0]; i++)
		(*newRes)[i-1] = msg[i];
	AddResource( newRes, '!@#$', passwordID, "\pZaphod" );
	err = checkResErr( "RoboWar.model.password:tweakPassword:2" );
	
	FSClose( fileRef ); fileRef = 0;
	
	// open the file's data fork with read access
	err = FSpOpenDF( &rob[who].fileSystemSpecification, fsRdWrPerm, &fileRef );
	checkFileErr( err, "RoboWar.model.password:tweakPassword:3" );
	require_noerr( err, abortTweekPassword );

	// get the length of the robot's source code.
	err = GetEOF( fileRef, &length );
	checkFileErr( err, "RoboWar.model.password:tweakPassword:4" );
	require_noerr( err, abortTweekPassword );
	
	// allocte memory for our buffer
	buffer = NewPtr( length );
	err = checkMemErr( "RoboWar.model.password:tweakPassword:5" );
	require_noerr( err, abortTweekPassword );
	
	// read the robot's source code.
	err = FSRead( fileRef, &length, buffer );
	checkFileErr( err, "RoboWar.model.password:tweakPassword:6" );
	require_noerr( err, abortTweekPassword );
	
	// scramble the source code
	for (i=0; i<length; i++)
		buffer[i] += 67 + i + msg[(i%msg[0])+1];
	
	// write the scrambled source code.
	err = FSWrite( fileRef, &length, buffer );
	checkFileErr( err, "RoboWar.model.password:tweakPassword:7" );
	require_noerr( err, abortTweekPassword );

	// set the EOF
	err = SetEOF( fileRef, length );
	checkFileErr( err, "RoboWar.model.password:tweakPassword:8" );
	
abortTweekPassword:
	if (fileRef) FSClose( fileRef );
	if (buffer) DisposePtr( buffer );
	
	return err;
}

pascal Boolean keyFilter(DialogPtr theDialog,EventRecord *theEvent,short *itemHit)
{
#pragma unused (theDialog)
	short result = 0;
	char c;
	
	if (theEvent->what == keyDown) {
		c = BitAnd(theEvent->message,charCodeMask);
		if (c == 13 || c == 3) { /* enter or return */
			*itemHit = 1;
			result = 1;
		}
		else {
			theEvent->message+= '*'-c;
			realMessage[++realMessage[0]] = c;
		}
	}
	return result;
}

short getPassword(char *realPass)
{
	DialogPtr myDialog;
	short itemHit;
	short result,result2,i;
	char check[5];
	ModalFilterUPP filterUPP;
	
	ParamText ("\pEnter the password:",noName,noName,noName);
	myDialog = GetNewDialog(PasswordDlogID,NULL,(WindowPtr)-1);
	installButtonOutline(myDialog,6);
	realMessage[0] = 0;
	filterUPP = NewModalFilterProc(&keyFilter);
	do {
		ModalDialog(filterUPP,&itemHit);
	} while (itemHit != 1);
	DisposeDialog(myDialog);
	DisposeRoutineDescriptor(filterUPP);
	
	result2 = 0;
	if (realMessage[0] == 5) {
		for (i=1; i<=5; i++) check[i-1] = toupper(realMessage[i]);
		if (check[0] == 'R' &&
			check[1] == 'O' &&
			check[2] == 'W' &&
			check[3] == 'M' &&
			check[4] == 'A') result2 = 1;
	}
	encode(realMessage);
	result = 1;
	for (i=0; i<=realMessage[0]; i++)
		if (realMessage[i] != realPass[i]) result = 0;
	return (result || result2);
}


void recodeSource(char *newPass)
{
	Ptr	buffer;
	long length;
	short i,err,refNum;
	
	if ((buffer = fileToBuffer(rob[botSelected].name,rob[botSelected].vRefNum,&length)) != NULL) {
		if (rob[botSelected].password[0]) 
			for (i=0; i<length; i++)
				buffer[i] -= (67 + i + rob[botSelected].password[(i%rob[botSelected].password[0])+1]);
		if (checkFileErr(FSOpen(rob[botSelected].name,rob[botSelected].vRefNum,&refNum),
			"Password:recodeSource:FSOpen")) err = 1;
		else {
			err = 0;
			if (newPass[0]) 
				for (i=0; i<length; i++)
					buffer[i] += 67 + i + newPass[(i%newPass[0])+1];
			if (checkFileErr(FSWrite(refNum,&length,buffer),"Password:recodeSource:FSWrite")) 
				err = 1;
			if (SetEOF(refNum,length)) err = 1;
			if (FSClose(refNum)) err = 1;
		}
		if (err) reportMessage ("Error writing robot","");
		DisposePtr(buffer);
		checkMemErr("Password:recodeSource");
	}
}

void doPassword()
{
	short refNum;
	Handle passRes;
	char userPassword[255];
	Rect r;
	DialogPtr myDialog;
	short itemHit,newPassword,i,j;
	ModalFilterUPP filterUPP;
	
	if (!rob[botSelected].passwordEntered) 
		if (!getPassword(rob[botSelected].password)) {
			reportMessage ("Sorry, incorrect password.","");
			return;
		}
	ParamText("\pSet the password: (return for none)",noName,noName,noName);
	realMessage[0] = 0;
	myDialog = GetNewDialog (PasswordDlogID,NULL,(WindowPtr)-1);
	installButtonOutline(myDialog,6);
	filterUPP = NewModalFilterProc(&keyFilter);
	do {
		ModalDialog (filterUPP,&itemHit);
	} while (itemHit != 1);
	for (i=0; i<= realMessage[0]; i++)
		userPassword[i] = realMessage[i];
	if (userPassword[0] > 19) userPassword[0] = 19;
	DisposeDialog (myDialog);
	if (userPassword[0]) {
		newPassword = 1;
		ParamText("\pVerify the password:",noName,noName,noName);
		myDialog = GetNewDialog (PasswordDlogID,NULL,(WindowPtr)-1);
		installButtonOutline(myDialog,6);
		realMessage[0] = 0;
		do {
			ModalDialog (filterUPP,&itemHit);
		} while (itemHit != 1);
		if (realMessage[0] > 19) realMessage[0] = 19;
		DisposeDialog (myDialog);
	
		for (i=0; i<= userPassword[0]; i++)
			if (realMessage[i] != userPassword[i]) newPassword = 0;
		if (!newPassword) reportMessage ("Verification failed.","Try again.");
	}
	else newPassword = 0;
	DisposeRoutineDescriptor(filterUPP);
	if (newPassword) {
		encode(userPassword);
		recodeSource(userPassword);
		for (i=0; i<=userPassword[0]; i++)
			rob[botSelected].password[i] = userPassword[i];
		setVolume(rob[botSelected].vRefNum);
		refNum = OpenResFile(rob[botSelected].name);		
		passRes = GetResource('!@#$',passwordID);
		if (passRes != NULL) {
			RemoveResource(passRes);
			checkResErr("Password:doPassword:1");
			DisposeHandle(passRes);
		}
		CloseResFile(refNum);
		refNum = OpenResFile(rob[botSelected].name);	
		passRes = NewHandle(rob[botSelected].password[0]);
		for (i=1; i<= rob[botSelected].password[0]; i++) 
			(*passRes)[i-1] = rob[botSelected].password[i];
		AddResource(passRes,'!@#$',passwordID,"\pZaphod");
		checkResErr("Password:doPassword:2");
		CloseResFile(refNum);
		restoreVolume();
	}
	else if (rob[botSelected].password[0]) { /* remove password */
		recodeSource("");
		rob[botSelected].password[0] = 0;
		setVolume(rob[botSelected].vRefNum);
		refNum = OpenResFile(rob[botSelected].name);		
		passRes = GetResource('!@#$',passwordID);
		if (passRes == NULL) SysBeep(1);
		else {
			RemoveResource(passRes);
			checkResErr("Password:doPassword:3");
			DisposeHandle(passRes);
		}
		CloseResFile(refNum);
		restoreVolume();
	}
	if (mode == draftingBoard) {
		r.top = 100; r.bottom = 110; r.left = 420; r.right = 498;
		InvalRect(&r);
	}
	rob[botSelected].passwordEntered = 1;
	for (i=0; i < numBots; i++)
		if (sameBot(i)) {
			rob[i].passwordEntered = rob[botSelected].passwordEntered;
			for (j=0; j<numBots; j++)
				rob[i].password[j] = rob[botSelected].password[j];
		}
}
