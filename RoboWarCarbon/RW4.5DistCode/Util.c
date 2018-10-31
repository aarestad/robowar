/* Util.c */

/* Written 1/3/91 by David Harris 

	This file has utility routines extracted from main.
*/

///--------------------------------------------------------------------------------------
#include <Carbon/Carbon.h>
#include "robotypes.h"


///--------------------------------------------------------------------------------------
/* Global Variables */

Handle              gSndHandle;
SndChannelPtr    	gChan;
Handle				mSndHandle[maxChannels];
SndChannelPtr		mChan[maxChannels];
long				messageTime;
short				curChannel;
short				saveRefNum;
 

///--------------------------------------------------------------------------------------
/* External Variables */

extern Str255		title;
extern Str255		noName;
extern CursHandle	watchCurs;
extern GWorldPtr	botGW[maxBots][2];//--- 19 apr 97 --- Changed.
extern double		sine[360];
extern robot		rob[maxBots];
extern short		botSelected;
//extern short		soundFlag;
extern macFeatures	features;
extern UniversalProcPtr hiliteButtonUPP;
extern short		isTournament;
extern prefStruct	gPrefs;
//extern QDGlobals qd;							/* To make PowerPC happy */


///--------------------------------------------------------------------------------------
/* Prototypes */

pascal Boolean	timeOutFilter(DialogPtr theDialog,EventRecord *theEvent,short *itemHit);
void 			reportMessage(char *message1,char *message2);
void 			myReportNum( char* msg, long num );
void 			reportFatalError(char *message);
void 			fatalError(short code);
void 			displayErr(char *errCode,char *errName,char *proc);
void 			checkMemErr(char *proc);
void 			checkResErr(char *proc);
void 			checkSndErr(OSErr err,char *proc);
OSErr 			checkFileErr(OSErr err,char *proc);
void 			setTitle(char *what);
pascal void 	hiliteButtonProc(WindowPtr theWindow,short itemNo);
void 			installButtonOutline(DialogPtr theDialog,short itemNo);
Ptr 			fileToBuffer(Str255 fName,short vRefNum,long *length);
void 			drawRobot(short,short,short,short,short,RgnHandle,short);
Boolean 		compareString(char *str1,char *str2);
Boolean 		sameBot(short target);
void 			setVolume(short vRefNum);
void 			restoreVolume(void);
void 			play2Sound(short whichSnd);
void 			initSounds(void);
void 			clearStereoChannel(short which);
void 			clearChannel(void);
void 			playSound(short whichSound,short whichBot);
short 			NumToolboxTraps(void);
TrapType 		GetTrapType(short theTrap) ;
short 			TrapAvailable(short theTrap);
void 			getFeatures(void);


///--------------------------------------------------------------------------------------
/* in Recording Studio */
extern void bringSoundToMemory(short bot,short snd);

/* Code */

///--------------------------------------------------------------------------------------
pascal Boolean timeOutFilter(DialogPtr theDialog,EventRecord *theEvent,short *itemHit) // done
{
#pragma unused (theDialog)

	char c;
	
	if (TickCount()-messageTime > (900-600*isTournament)) {
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

///--------------------------------------------------------------------------------------
void reportMessage(char *message1,char *message2) // -- done
{
	short err; 
	short i;
	Str255 dup1,dup2;
	ModalFilterUPP filterUPP;
	
	i = 0;
	do {
		dup1[i] = message1[i];
	} while (message1[i++]);
	
	i = 0;
	do {
		dup2[i] = message2[i];
	} while (message2[i++]);

	CtoPstr((char*)dup1);
	CtoPstr((char*)dup2);
	ParamText(dup1,dup2,noName,noName);
	messageTime = TickCount();
	filterUPP =  NewModalFilterProc(&timeOutFilter);
	err = Alert(AlertID,filterUPP);
	DisposeRoutineDescriptor(filterUPP);
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ¥ For Debugging mostly, outputs a string and as number
// - 
void myReportNum( char* inText, long num )
{
	unsigned char	numText[32];
	
	NumToString( num, numText );

	numText[ numText[0] + 1 ] = '\0';
	
	reportMessage( inText, (char*)(numText+1) );
}

///--------------------------------------------------------------------------------------
void reportFatalError(char *message)
{
	short err; 
	short i;
	Str255 text;
	
	for (i=0; message[i] != 0; i++)
		text[i+1] = message[i];
	text[0] = i;
	ParamText(text,noName,noName,noName);
	err = StopAlert(StopAlertID,NULL);
}

///--------------------------------------------------------------------------------------
void fatalError(short code)
{
	switch(code) {
		case 1: reportFatalError("Fatal Error:  Unable to load menus"); break;
		case 2: reportFatalError("Fatal Error:  Unable to load window"); break;
		case 3: reportFatalError("Fatal Error:  Unable to load picture"); break;
		case 4: reportFatalError("Fatal Error:  Unable to load control"); break;
		default: reportFatalError("Fatal Error"); break;
	}
	exit(1);
}

///--------------------------------------------------------------------------------------
void displayErr(char *errCode,char *errName,char *proc) // -- done
{
	short i,err;
	Str255 dup0,dup1,dup2;


	i = 0;
	do {
		dup0[i] = errCode[i];
	} while (errCode[i++]);
	
	i = 0;
	do {
		dup1[i] = errName[i];
	} while (errName[i++]);
	
	i = 0;
	do {
		dup2[i] = proc[i];
	} while (proc[i++]);
	CtoPstr((char*)dup0);
	CtoPstr((char*)dup1);
	CtoPstr((char*)dup2);
	
	ParamText(dup0,dup1,dup2,noName);
	err = Alert(ErrAlertID,NULL);
	if (err) SysBeep(1);
}

void checkMemErr(char *proc) // -- done
{
	short err;
	char errCode[80],errName[80];
	
	if (err = MemError()) {
		sprintf (errCode,"Internal Memory Error %d",err);
		switch (err) {
			case memFullErr:  strcpy(errName,"Out of memory"); break;
			case nilHandleErr:  strcpy(errName,"NULL handle"); break;
			case memAdrErr:  strcpy(errName,"Invalid memory address"); break;
			case memPurErr:  strcpy(errName,"Invalid purge operation"); break;
			case memWZErr:  strcpy(errName,"Invalid operation on free block"); break;
			case memLockedErr:  strcpy(errName,"Trying to move locked block"); break;
			default: strcpy(errName,"Unknown"); break;
		}
		displayErr(errCode,errName,proc);
	}	
}

void checkResErr(char *proc) // done
{
	short err;
	char errCode[80],errName[80];
	
	if (err = ResError()) {
		sprintf (errCode,"Internal Resource Error %d",err);
		switch (err) {
			case resNotFound:  strcpy(errName,"Resource not found"); break;
			case resFNotFound:  strcpy(errName,"Resource file not found"); break;
			case addResFailed:  strcpy(errName,"Add resource failed"); break;
			case rmvResFailed:  strcpy(errName,"Remove resource failed"); break;
			case mapReadErr:  strcpy(errName,"Corrupt resource map"); break;
			default: strcpy(errName,"Unknown"); break;
		}
		displayErr(errCode,errName,proc);
	}	
}

void checkSndErr(OSErr err,char *proc) // done
{
	char errCode[80],errName[80];
	
	if (err) {
		sprintf (errCode,"Internal Sound Error %d",err);
		switch (err) {
			case badChannel:   strcpy(errName,"Channel corrupt or unusable"); break;
			case resProblem:   strcpy(errName,"Problem loading the resource"); break;
			case badFormat:    strcpy(errName,"Snd resource is corrupt or unusable"); break;
			case userCanceledErr: strcpy(errName,"User canceled operation"); break;
			case siBadSoundInDevice: strcpy(errName,"Invalid sound input device"); break;
			case siUnknownQuality: strcpy(errName,"Unknown sound quality"); break;
			case noHardwareErr: strcpy(errName,"Required hardware unavailable"); break;
			case notEnoughHardwareErr: strcpy(errName,"Insufficient hardware"); break;
			case channelBusy: strcpy(errName,"Channel busy"); break;
			case noMoreRealTime: strcpy(errName,"Not enough CPU time available"); break;
			case siBadDeviceName: strcpy(errName,"Invalid device name"); break;
			case siBadRefNum: strcpy(errName,"Invalid reference number"); break;
			default: strcpy(errName,"Unknown"); break;
		}
		displayErr(errCode,errName,proc);
	}	
}

OSErr checkFileErr(OSErr err,char *proc) // done
{
	char errCode[80],errName[80];
	
	if (err) {
		sprintf (errCode,"File Manager Error %d",err);
		switch (err) {
			case bdNamErr:		strcpy(errName,"Bad name"); break;
			case fBsyErr:		strcpy(errName,"File is busy"); break;
			case fLckdErr:		strcpy(errName,"File is locked"); break;
			case fnfErr:		strcpy(errName,"File not found"); break;
			case ioErr:			strcpy(errName,"I/O Error"); break;
			case nsvErr:		strcpy(errName,"No such volume"); break;
			case vLckdErr:		strcpy(errName,"Volume is locked"); break;
			case wPrErr:		strcpy(errName,"Disk is write-protected"); break;
			case tmfoErr:		strcpy(errName,"Too many files open"); break;
			case opWrErr:		strcpy(errName,"File already open for write"); break;
			case extFSErr:		strcpy(errName,"External file system"); break;
			case eofErr:		strcpy(errName,"End of file"); break;
			case fnOpnErr:		strcpy(errName,"File not open"); break;
			case rfNumErr:		strcpy(errName,"Bad file refnum"); break;
			case dskFulErr:		strcpy(errName,"Disk full"); break;
			case wrPermErr:		strcpy(errName,"No write permissions"); break;
			case dupFNErr:		strcpy(errName,"Duplicate filename"); break;
			default: strcpy(errName,"Unknown"); break;
		}
		displayErr(errCode,errName,proc);
	}	
	return err;
}

void setTitle(char *what)
{
	short i;
	
	i = 0;
	do {
		title[i] = what[i];
	} while (what[i++] != 0);
	CtoPstr((char*)title);
}

pascal void hiliteButtonProc(WindowPtr theWindow,short itemNo)
{
	short itemType;
	Handle item;
	Rect box;
	
	GetDialogItem(theWindow,itemNo,&itemType,&item,&box);
	PenSize(3,3);
	InsetRect(&box,-4,-4);
	FrameRoundRect(&box,16,16);
	PenSize(1,1);
}

void installButtonOutline(DialogPtr theDialog,short itemNo)
{
	short itemType;
	Handle item;
	Rect box;
	
	GetDialogItem(theDialog,itemNo,&itemType,&item,&box);
	SetDialogItem(theDialog,itemNo,itemType,(Handle)hiliteButtonUPP,&box);
}

Ptr fileToBuffer(Str255 fName,short vRefNum,long *length) 
{							/* Note, fName must be P-string */
	short err = 0;
	short refNum;
	Ptr	buffer;
	
	SetCursor(*watchCurs);
	if (checkFileErr(FSOpen(fName,vRefNum,&refNum),"Util:fileToBuffer:FSOpen")) err = 1;
	else {
		if (!(err=(GetEOF(refNum,length)))) {
			if ((buffer = NewPtr(*length)) == NULL) err = 2;
			else if (FSRead(refNum,length,buffer)) err = 1;
		}
		if (FSClose(refNum)) err = 1;
	}
	SetCursor(&qd.arrow);
	if (!err) return buffer;
	else {
		reportMessage ("Error reading robot","");
		return NULL;
	}
}	


//--- 19 apr 97 --- Updated for Graphic Worlds
void drawRobot(short which,short whereX,short whereY,short aim,short iconNum,
				RgnHandle mask,short turretType)
{

	// note: which = which robot is being drawn

	Rect r;
	short a;
	register short team,color;
	GWorldPtr	myBot;
	
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
	
	// if icon is 1 bit, select color
	if( (**(myBot->portPixMap)).pixelSize == 1 ) {
		color = true;
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
	else
		color = false;
		
	
	
	// Set the Robot's rect
	r.top = whereY-16; r.bottom = whereY+16;
	r.left = whereX-16; r.right = whereX+16;
	
	if (mask) {		// for explosions
		OffsetRgn(mask,whereX,whereY);
		CopyBits(&( ((GrafPtr)myBot)->portBits ), &(qd.thePort->portBits),
			&((myBot)->portRect), &r, ( color )? srcOr : transparent, mask);
		
		OffsetRgn(mask,-whereX,-whereY);
		ForeColor(blackColor);
	}
	//( turretType > 4 )? notSrcCopy : srcOr
	else { // normal draw bot
		CopyBits(&( ((GrafPtr)myBot)->portBits ), &(qd.thePort->portBits),
			&((myBot)->portRect), &r, ( color )? srcOr : transparent, nil);
		
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

Boolean compareString(char *str1,char *str2)
{
	short i = 0;
	Boolean result = TRUE;
	
	do {
		if (str1[i] != str2[i]) result = FALSE;
	} while (i++ < str1[0] && result);
	
	return result;
}

Boolean sameBot(short target) // done
{
	short i;
	
	if (rob[target].vRefNum != rob[botSelected].vRefNum) return FALSE;
	for (i=0; i<= rob[botSelected].name[0]; i++)
		if (rob[target].name[i] != rob[botSelected].name[i]) return FALSE;
	return TRUE;
}

void setVolume(short vRefNum)
{
	Str255 vName;
	
	GetVol(vName,&saveRefNum);
	SetVol(noName,vRefNum);
//	SetVol(vName,vRefNum);
}

void restoreVolume(void)
{
	SetVol(noName,saveRefNum);
}

/* My old sound-playing routine  */

void play2Sound(short whichSnd)
{
	SndListHandle mySnd;
	SndChannelPtr chan;
	OSErr err;
		
	if (gPrefs.soundFlag) {
		chan = NULL;
		mySnd = (SndListHandle)GetResource('snd ',whichSnd);
		if (err = SndPlay(chan,mySnd,TRUE))
			reportMessage ("Error playing sound.","");
	}
} 

/*------------------------------------------------------------
	Async sound routines from Dave Blumenthal at Cornell */

void initSounds(void)
{
	short i;
	
	gChan = NULL;
	gSndHandle = NULL;
	curChannel = 0;
	for (i=0; i < maxChannels; i++) {
		mChan[i] = NULL;
		mSndHandle[i] = NULL;
	}
}

void clearStereoChannel(short which)
{
	OSErr myErr;
	
	/* Steps to get "Error disposing of sound" bug:
	
		1) Open IntBot2
		2) Select sound 2
		3) Play
		4) Cut
		5) Select sound 1
		6) Play
		7) Quit
		
		Memory Error -111 occurs on HUnlock and HPurge.
		Pointer seems reasonable.
		
		Error -205 on SndDisposeChannel on Radius Rocket
	*/
	
	if (mChan[which] != NULL) {
    	myErr = SndDisposeChannel(mChan[which], TRUE);
    	checkSndErr(myErr,"Util:clearStereoChannel");
		mChan[which] = NULL;
    }
    if (mSndHandle[which] != NULL) {
    	if (*mSndHandle[which] != NULL) {
	    	HUnlock(mSndHandle[which]);
			checkMemErr("Util:clearStereoChannel:1");
	        HPurge(mSndHandle[which]);
	      	checkMemErr("Util:clearStereoChannel:2");
	    }
    	mSndHandle[which] = NULL;
    }
}

void clearChannel(void)
/*This will wipe out any channel and clear the chanPtr.  If the
 channel is in use, it will stop any sound and then clear it.*/
 
{ 
	OSErr   myErr;
	short 	i;

	if (features.hasStereoCapability) {
		curChannel = 0;
		for (i=0; i < maxChannels; i++) 
			clearStereoChannel(i);
	}
    if (gChan != NULL) {
           myErr = SndDisposeChannel(gChan, TRUE);
    	   checkSndErr(myErr,"Util:clearChannel");
           gChan = NULL;
    }
    if (gSndHandle != NULL) {
    	if (*gSndHandle != NULL) {
           	HUnlock(gSndHandle);
           	HPurge(gSndHandle);
       		checkMemErr("Util:clearChannel");
      	}
        gSndHandle = NULL;
    }
}

void playSound(short whichSound,short whichBot)

/*This will call SndPlay.  The snd must be either a format 2 or
 format 1 that contains synth information.  We use a global
 resouce handle for the snd.*/
 
/* There's a problem with this routine.  It's giving me a bomb:
	"Unassigned interrupt #$00D (format $9) at $A0829528 
	
	Is this bug still here?  (5/20/93) */
	
/* The whichBot parameter specifies which robot's sounds to play, or
	maxBots means to play a sound from RoboWar's resource file. */
	
/* Getting error -201 on SndNewChannel on Radius Rocket */
 
{
	OSErr myErr;
    short   retries;
   
    if (gPrefs.soundFlag) {
    	if (features.hasStereoCapability) {
    		retries = 0;
    		do {
   	 			clearStereoChannel(curChannel);
		    	myErr = SndNewChannel(&mChan[curChannel], sampledSynth, 0, NULL);
		    	retries++;
		    	if (myErr == notEnoughHardwareErr) {
		    		mChan[curChannel] = NULL;
		    	}
	   			else if (!myErr) {
	   				if (whichBot == maxBots) {
	   					mSndHandle[curChannel] = GetResource('snd ',whichSound);
	   					checkResErr("Util:playSound:1");
	   				}
	   				else if (rob[whichBot].sounds[whichSound] != NULL) {
						bringSoundToMemory(whichBot,whichSound);
						mSndHandle[curChannel] = rob[whichBot].sounds[whichSound];
	   				}
	   				else mSndHandle[curChannel] = NULL;
	   				if (*mSndHandle[curChannel] == NULL) {
	   					/* reportMessage ("Error: sound purged",""); */
	   					mSndHandle[curChannel] = NULL;
	   				}
	   				else if (mSndHandle[curChannel] != NULL) {
		   				HLock(mSndHandle[curChannel]);
		   				checkMemErr("Util:playSound:1");
		   				HNoPurge(mSndHandle[curChannel]);
		   				checkMemErr("Util:playSound:2");
		   				myErr = SndPlay(mChan[curChannel],
		   						(SndListHandle)mSndHandle[curChannel],TRUE);
		   				checkSndErr(myErr,"Util:playSound:1");
	   				}
	   				else {
	   					clearStereoChannel(curChannel);
	   				}
	   				myErr = 0;
	   			}
	   			curChannel++;
	   			if (curChannel >= maxChannels) curChannel = 0;
   			} while (myErr != 0 && retries <= maxChannels);
    	}
    	else {
		    clearChannel();
		    if (whichBot == maxBots) {
		    	gSndHandle = GetResource('snd ',whichSound);
	   			checkResErr("Util:playSound:2");
	   		}
   			else if (rob[whichBot].sounds[whichSound] != NULL) {
				bringSoundToMemory(whichBot,whichSound);
				gSndHandle = rob[whichBot].sounds[whichSound];
   			}
		    if (*gSndHandle == NULL) {
		    	/* reportMessage("Error: sound purged",""); */
		    	gSndHandle = NULL;
		    }
		    else if (gSndHandle != NULL) {
				HLock(gSndHandle);		
		   		HNoPurge(gSndHandle);
			    myErr = SndNewChannel(&gChan, 0, 0, NULL);
		   		checkSndErr(myErr,"Util:playSound:2");
			    if (!myErr) {
			         myErr = SndPlay(gChan, (SndListHandle)gSndHandle, TRUE);
		   			 checkSndErr(myErr,"Util:playSound:3");
			    }
			}
		}
	}
}

/* Be sure to call ClearChannel() when your program quits and when you
detect that RW has been moved to background under multifinder.
If you don't, other programs won't be able to use the sound channel,
which ain't very nice.  I'd really like to be able to use that
CallBack routine, but I just can't get it to happen.  I know that 
you have to twiddle with the A5 register before and after setting
the global variable within theCallBack that says "hey, the sound's
over," and I really thought I was doing it correctly but I obviously
wasn't.  Sigh.
*/

/* Checking available features */

short NumToolboxTraps(void)
{
	/* Weird, but published in Inside Macintosh VI */
	
	if (NGetTrapAddress(_InitGraf,ToolTrap) == NGetTrapAddress(0xAA6E,ToolTrap)) return 0x200;
	else return 0x400;
}

TrapType GetTrapType(short theTrap) 
{
	if (theTrap & 0x0800 > 0) return ToolTrap;
	else return OSTrap;
}

short TrapAvailable(short theTrap)
{
	TrapType tType;
	
	tType = GetTrapType(theTrap);
	if (tType == ToolTrap) {
		theTrap = theTrap & 0x07FF;
		if (theTrap > NumToolboxTraps()) theTrap = _Unimplemented;
	}
	return (NGetTrapAddress(theTrap,tType) != NGetTrapAddress(_Unimplemented,ToolTrap));
}


//--- 19 apr 97 --- Updated for GWorlds
void getFeatures(void)
{
	SysEnvRec info;
	long test,result;
	//GDHandle dev;

	//dev = GetMainDevice();	//<--- Changed! --- Added
	features.bitDepth = (**(**(GetMainDevice())).gdPMap).pixelSize;

	features.hasWaitNextEvent = TrapAvailable(_WaitNextEvent);
	features.hasGestalt = TrapAvailable(_Gestalt);
	
	if (features.hasGestalt) {
		features.hasDragAndDrop = (Gestalt(gestaltDragMgrPresent,&test) != noErr )? 1 : 0;
		if (Gestalt(gestaltFPUType,&test) != noErr) SysBeep(1);
		features.hasCoprocessor = test > 0;
		if (Gestalt(gestaltQuickdrawVersion,&test) != noErr) SysBeep(1);
		features.hasColorQD = ((test & 0xFF00) > 0);
		if (Gestalt(gestaltSoundAttr,&test) != noErr) SysBeep(1);
		if (BitTst(&test,31-gestaltStereoCapability)) features.hasStereoCapability = 1;
		else features.hasStereoCapability = 0;
		if (BitTst(&test,31-gestaltSoundIOMgrPresent)) features.hasSoundIO = 1;
		else features.hasSoundIO = 0;
		if (BitTst(&test,31-gestaltHasSoundInputDevice)) features.hasSoundDevice = 1;
		else features.hasSoundDevice = 0;
		result = Gestalt(gestaltSpeechAttr,&test);
		if (result == gestaltUndefSelectorErr) features.hasSpeech = 0;
		else if (result != noErr) {
			SysBeep(1);
			features.hasSpeech = 0;
		}
		else features.hasSpeech = (BitTst(&test,31-gestaltSpeechMgrPresent));
		if (Gestalt(gestaltAppleEventsAttr,&test) != noErr) SysBeep(1);
		if (BitTst(&test,31-gestaltAppleEventsPresent)) features.hasAppleEventManager = 1;
		else features.hasAppleEventManager = 0;
		// - Check to see if this Mac has FileSpec Calls, set the features struct.
		if (Gestalt(gestaltFSAttr,&test) != noErr) { SysBeep(1); test = 0; }
		features.hasFSSpecCalls = ((test & gestaltHasFSSpecCalls) > 0); /*supports FSSpec records*/
	}
	else {
		SysEnvirons(1,&info);
		features.hasCoprocessor = info.hasFPU;
		features.hasColorQD = info.hasColorQD;
		features.hasSoundIO = 0;
		features.hasSoundDevice = 0;
		features.hasStereoCapability = 0;
		features.hasAppleEventManager = 0;
		features.hasSpeech = 0;
		features.hasAppleEventManager = 0;
		features.hasFSSpecCalls = 0;
	}
}