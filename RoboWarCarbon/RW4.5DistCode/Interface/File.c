/* File.c */

/* Written 1/3/90 by David Harris

	This file isolates some of the file-handling routines 
	from main.
*/

#include <Carbon/Carbon.h>
#include "robotypes.h"


/* External Variables */

extern MenuHandle		myMenus[5];
extern short			mode;
extern WindowPtr		myWindow;
extern short			isBattle;
extern THPrint			printRecord;
extern CursHandle		watchCurs;
extern ControlHandle	battleButton;
extern robot			rob[maxBots];
extern short			botSelected;
extern short			numBots;
extern void 			(*updateFun[7])();
extern short			useDebugger;
extern Str255			noName;
extern short			rosterChanged;

#if __POWERPC__
	extern	QDGlobals	qd;					/* To make PowerPC happy */
#endif

/* Prototypes */

void readRobot(void);
void newRobot(void);
void openRobot(void);
void duplicateRobot(void);
void saveAsRobot(void);
void closeRobot(void);
void pageSetup(void);
void print(void);
OSErr NewMacFile( Str255 name, long type, long creator );

/* in Util.c */
extern void reportMessage(char *message1,char *message2);
extern void checkMemErr(char *proc);
extern void checkResErr(char *proc);
extern OSErr checkFileErr(OSErr err,char *proc);
extern void setVolume(short vRefNum);
extern void restoreVolume(void);
extern Boolean sameBot(short target);

/* in ArenaControl.c */
short loadRobotCode(short who);

/* in Main.c */
void universalUpdate(void);

/* in DraftingBoard.c */
void printRobotCode(TPPrPort printPort) ;

/* Code */

void readRobot(void) // -- done
{
	short i,refNum;
	long passLen;
	Handle passRes;
	Rect r;
	char msg[80], msg2[80];
	
	/* Given a robot with a name and vRefNum, this function reads
		the rest of the info.  Assumes robot is the number numBots */
	
	setVolume(rob[numBots].vRefNum);
	refNum = OpenResFile(rob[numBots].name);
	if (refNum == -1) {
		sprintf(msg,"Error opening robot %s.",rob[numBots].name);
		sprintf(msg2,"Resource Error #%d. :File:readRobot:1",ResError());
		reportMessage (msg,msg2);
		//ExitToShell();
	}
	else
	{

		passRes = GetResource('!@#$',passwordID);
		if (passRes == NULL) {
			rob[numBots].password[0] = 0;
			rob[numBots].passwordEntered = 1;
		}
		else {
			passLen = GetHandleSize(passRes);
			rob[numBots].password[0] = passLen;
			for (i=0; i<passLen; i++) 
				rob[numBots].password[i+1] = (*passRes)[i];
			rob[numBots].passwordEntered = 0;
		}
		CloseResFile(refNum);
		restoreVolume();
		if (loadRobotCode(numBots)) {
			rob[numBots].team = 0;
			r.top = 0; r.left = 302; r.right = 500; r.bottom = 205;
			InvalRect(&r);
			r.top = 252; r.bottom = 300;
			InvalRect (&r);
			r.top = 0; r.left = 0; r.right = 300;
			InvalRect(&r);
			botSelected = numBots;
			for (i=0; i<numBots; i++)
				if (sameBot(i)) rob[botSelected].passwordEntered = 1;
			numBots++;
			if (numBots == 1) {
				HiliteControl(battleButton,0);
				EnableItem(myMenus[4],debugger_); 
			}
		}
	}
}

void newRobot(void) // done
{
	//SFTypeList	types;
	SFReply		reply;
	Point		where;
	short 		i;
	Rect		r;
	
	where.h = 100; where.v = 100;
	//types[0] = 'RobW';
	SFPutFile(where,"\pName new robot:",noName,NULL,&reply);
	if (reply.good) {
		rob[numBots].vRefNum = reply.vRefNum;
		for (i=0; i<= reply.fName[0]; i++) 
			rob[numBots].name[i] = reply.fName[i];
		FSDelete(rob[numBots].name,rob[numBots].vRefNum);
		checkFileErr(Create(rob[numBots].name,rob[numBots].vRefNum,'RWAR','RobW'),
			"File:newRobot:Create");
		setVolume(rob[numBots].vRefNum);
		CreateResFile(rob[numBots].name);
		checkResErr("File:newRobot");
		restoreVolume();
		rob[numBots].password[0] = 0;
		rob[numBots].passwordEntered = 1;
		if (loadRobotCode(numBots)) {
			rob[numBots].team = 0;
			r.top = 0; r.left = 302; r.right = 500; r.bottom = 205;
			InvalRect(&r);
			r.top = 252; r.bottom = 300;
			InvalRect (&r);
			r.top = 0; r.left = 0; r.right = 300;
			InvalRect(&r);
			botSelected = numBots;
			numBots++;
			if (numBots == 1) {
				HiliteControl(battleButton,0);
				EnableItem(myMenus[4],debugger_); 
			}
		}
		rosterChanged = 1;
	}
}

void openRobot(void) // done
{
	SFTypeList			types;
	SFReply				reply;
	//StandardFileReply 	myReply;
	Point				where;
	short 				i;
	
	where.h = 100; where.v = 100;
	types[0] = 'RobW';
	SFGetFile(where,"\pOpen which robot?",NULL,1,types,NULL,&reply);
	//StandardGetFile( nil, 1, types, &myReply);

	if (reply.good) {
		rob[numBots].vRefNum = reply.vRefNum;
		for (i=0; i<= reply.fName[0]; i++) 
			rob[numBots].name[i] = reply.fName[i];
			
		readRobot(); 
		rosterChanged = 1;
	}
	
	/*if (myReply.sfGood) {
		rob[numBots].vRefNum = myReply.sfFile.vRefNum;
		for (i=0; i<= myReply.sfFile.name[0]; i++) 
			rob[numBots].name[i] = myReply.sfFile.name[i];
			
		readRobot(); 
		rosterChanged = 1;
	}*/
}

void duplicateRobot(void) // done
{
	short i;
	Rect r;
	
	if (numBots < maxBots && botSelected != maxBots) {
		rob[numBots].vRefNum = rob[botSelected].vRefNum;
		for (i=0; i<= rob[botSelected].name[0]; i++) 
			rob[numBots].name[i] = rob[botSelected].name[i];
		for (i=0; i<= rob[botSelected].password[0]; i++)
			rob[numBots].password[i] = rob[botSelected].password[i];
		rob[numBots].passwordEntered = rob[botSelected].passwordEntered;
		if (loadRobotCode(numBots)) {
			rob[numBots].team = rob[botSelected].team;
			botSelected = numBots;
			numBots++;
			r.top = 0; r.left = 302; r.right = 500; r.bottom = 205;
			InvalRect(&r);
			r.left = 0; r.right = 300; r.bottom = 300;
			InvalRect(&r);
			if (numBots == 1) HiliteControl(battleButton,0);
		}
		rosterChanged = 1;
	}
}

void saveAsRobot(void) // done
{
	SFReply		save;
	Point		where;
	short 		i,j,numTypes,numResources,theID,ref1,ref2,errFlag;
	Str255		theName;
	long		length;
	Ptr			theData;
	Handle		theResource;
	ResType		theType;
	short 		saveRefNum;
	Str255		vName;

	where.h = 100; where.v = 100;
	SFPutFile(where,"\pSave robot as:",noName,NULL,&save);
	if (save.good) {
		errFlag = 0;
		if (save.vRefNum == rob[botSelected].vRefNum) {
			errFlag = 1;
			for (i=0; i<=rob[botSelected].name[0]; i++)
				if (rob[botSelected].name[i] != save.fName[i]) errFlag = 0;
		}
		if (!errFlag) { 
			FSDelete(save.fName,save.vRefNum);
			checkFileErr(Create(save.fName,save.vRefNum,'RWAR','RobW'),
				"File:saveAsRobot:Create");
			errFlag = checkFileErr(FSOpen(rob[botSelected].name,rob[botSelected].vRefNum,&ref1),
				"File:saveAsRobot:FSOpen:1") ||
				checkFileErr(FSOpen(save.fName,save.vRefNum,&ref2),
				"File:saveAsRobot:FSOpen:2");
			if (!errFlag) {
				checkFileErr(GetEOF(ref1,&length),"File:saveAsRobot:GetEOF");
				theData = NewPtr(length);
				if (MemError()) checkMemErr("File:saveAsRobot:1");
				else {
					checkFileErr(FSRead(ref1,&length,theData),"File:saveAsRobot:FSRead");
					checkFileErr(FSWrite(ref2,&length,theData),"File:saveAsRobot:FSWrite"); 
				}
				DisposePtr(theData);
				checkMemErr("File:saveAsRobot:2");
			}
			checkFileErr(FSClose(ref1),"File:saveAsRobot:FSClose:1");
			checkFileErr(FSClose(ref2),"File:saveAsRobot:FSClose:1");
		}
		if (!errFlag) {
			GetVol(vName,&saveRefNum);
			SetVol(noName,save.vRefNum);	
			CreateResFile (save.fName);
			ref2 = OpenResFile(save.fName);
			checkResErr("File:saveAsRobot:1");
			SetVol(noName,rob[botSelected].vRefNum);	
			ref1 = OpenResFile(rob[botSelected].name);
			checkResErr("File:saveAsRobot:2");
			
			UseResFile(ref1);
			checkResErr("File:saveAsRobot:3");
			numTypes = Count1Types();
			checkResErr("File:saveAsRobot:4");
			for (i = 1; i<= numTypes; i++) {
				Get1IndType(&theType,i);
				checkResErr("File:saveAsRobot:5");
				numResources = Count1Resources(theType);
				checkResErr("File:saveAsRobot:6");
				for (j = 1; j <= numResources; j++) {
					theResource = Get1IndResource(theType,j);
					checkResErr("File:saveAsRobot:7");
					GetResInfo(theResource,&theID,&theType,theName);
					checkResErr("File:saveAsRobot:8");
					DetachResource(theResource);
					checkResErr("File:saveAsRobot:9");
					UseResFile(ref2);
					checkResErr("File:saveAsRobot:10");
					AddResource(theResource,theType,theID,theName);
					checkResErr("File:saveAsRobot:11");
					UpdateResFile(ref2);
					checkResErr("File:saveAsRobot:12");
					ReleaseResource(theResource);
					checkResErr("File:saveAsRobot:13");
					UseResFile(ref1);
				}
			}
			CloseResFile(ref1);
			checkResErr("File:saveAsRobot:14");
			CloseResFile(ref2);
			checkResErr("File:saveAsRobot:15");
			SetVol(noName,saveRefNum);
		}
		if (!errFlag) {
			FlushVol(NULL,save.vRefNum);
			for (i=0; i<= save.fName[0]; i++)
				rob[botSelected].name[i] = save.fName[i];
			rob[botSelected].vRefNum = save.vRefNum;
			InvalRect(&myWindow->portRect);
		}
		rosterChanged = 1;
	}
}

// ------------------------------------------------------------------------------------------
//--- 19 apr 97 --- Updated for Disposing of GWorlds
void closeRobot(void) // -- done
{
	short i;
	Rect r;
	
	if (numBots && botSelected != maxBots) {
		numBots--;

		for (i=0; i<10; i++) {		//for each icon
			if(rob[botSelected].gw[i] != NULL){	//if GWorld Exists
				DisposeGWorld(rob[botSelected].gw[i]);	//Dispose GWorld
				checkMemErr("File:closeRobot:2");
				rob[botSelected].gw[i] = NULL;	// make sure we know noGWorld exists here
			}
		}
		
		DisposePtr((Ptr)rob[botSelected].prog);
		checkMemErr("File:closeRobot:3");
		
		if (useDebugger == botSelected) {
			useDebugger = maxBots;
			CheckItem(myMenus[4],debugger_,0);
		}
		else if (useDebugger != maxBots && useDebugger > botSelected) 
			useDebugger--;
		for (i=botSelected; i<numBots; i++) {
			rob[i] = rob[i+1];
			rob[i].number = i;
		}
		
		// make sure gWorld's of the lastRobot (the one that was at the end of the list) 
		// are NULL so that we don't accidentally redispose of them
		for (i=0; i<10; i++)	
			rob[numBots].gw[i] = NULL;
		
		if (botSelected == numBots) {
			if (numBots == 0) botSelected = maxBots;
			else botSelected = 0;
		}
		r.top = 0; r.left = 302; r.right = 500; r.bottom = 205;
		InvalRect(&r);
		r.top = 252; r.bottom = 300;
		InvalRect(&r);
		r.left = 0; r.right = 300; r.bottom = 300; r.top = 0;
		InvalRect(&r);
		if (numBots == 0) {
			HiliteControl(battleButton,255);
			DisableItem(myMenus[4],debugger_);
		}
		rosterChanged = 1;
	}
}

// ------------------------------------------------------------------------------------------
void pageSetup(void)
{
	PrOpen();
	if (!PrError()) {
		if (printRecord == NULL) {
			printRecord = (THPrint)NewHandle(sizeof(TPrint));
			checkMemErr("File:pageSetup");
			PrintDefault(printRecord);
			if (PrError()) reportMessage ("Error","Can't initialize print record.");
		}
		PrStlDialog(printRecord);
		if (PrError()) reportMessage ("Error","Bad print record");
	}
	else reportMessage ("Error","Can't open printer driver");
	PrClose();
	if (PrError()) reportMessage ("Error","Can't close printer driver");
}

// ------------------------------------------------------------------------------------------
void print(void)
{
	TPPrPort printPort;
	TPrStatus status;
	BitMap screen;
	
	PrOpen();
	if (!PrError()) {
		screen.baseAddr = NewPtr(64*300L);
		checkMemErr("File:print:1");
		screen.rowBytes = 64;
		SetRect(&screen.bounds,0,0,500,300);
		CopyBits(&myWindow->portBits,&screen,&screen.bounds,&screen.bounds,srcCopy,NULL);
		if (printRecord == NULL) {
			printRecord = (THPrint)NewHandle(sizeof(TPrint));
			checkMemErr("File:print:2");
			PrintDefault(printRecord);
			if (PrError()) reportMessage ("Error","Can't initialize print record");
		}
		if (PrJobDialog(printRecord) && !PrError()) {
			(*updateFun[mode])();
			universalUpdate();
			SetCursor(*watchCurs);
			printPort = PrOpenDoc(printRecord,NULL,NULL);
				if (mode == draftingBoard) printRobotCode(printPort);
				else {
					PrOpenPage(printPort,NULL);
						if (PrError()) reportMessage ("Error","Can't open page");
						else {
							CopyBits(&screen,&printPort->gPort.portBits,
									 &screen.bounds,&screen.bounds,srcCopy,NULL);
							FrameRect(&screen.bounds);
							OffsetRect(&screen.bounds,1,1);
							FrameRect(&screen.bounds);
						}
					PrClosePage(printPort);
				}
				if (PrError()) reportMessage ("Error","Can't close page");
			PrCloseDoc(printPort);
			if (!PrError() && (*printRecord)->prJob.bJDocLoop == bSpoolLoop)
				PrPicFile(printRecord,NULL,NULL,NULL,&status);
		}
		DisposePtr(screen.baseAddr);
		checkMemErr("File:print:3");
	} else reportMessage ("Error","Can't open printer driver");
	PrClose();
	if (PrError()) reportMessage("Error","Can't close printer driver");
	SetPort(myWindow);
	SetCursor(&qd.arrow);
}


// ------------------------------------------------------------------------------------------
//  Creates a new file returning the name as a cstring the user chose. 
OSErr NewMacFile( Str255 name, long type, long creator )
{
	OSErr		theErr;
	FSSpec		theFileSpec;
	
	theErr = FSMakeFSSpec( 0, 0, name, &theFileSpec );
	//if( checkFileErr( theErr, "File:NewMacFile:0") != noErr )
	//	return theErr;
	
	//printf( "\n FSMakeFSSpec has Error: %d", theErr );
	
	theErr = FSpCreate(&theFileSpec, creator, type, smSystemScript);
	
	//printf( "\n FSpCreate has Error: %d", theErr );

	if( theErr == dupFNErr )
	{
		//printf( "\n File Already Exist!", theErr );
		theErr = FSpDelete(&theFileSpec);
		//printf( "\n FSpDelete has error: %d", theErr );
		theErr = FSpCreate(&theFileSpec, creator, type, smSystemScript);
		//printf( "\n FSpCreate has error: %d", theErr );
	}
	//else
	//{
		//printf( "\n File Created OK. ");
	//}
	
	checkFileErr( theErr, "File:NewMacFile:0");
	
	return theErr;
}