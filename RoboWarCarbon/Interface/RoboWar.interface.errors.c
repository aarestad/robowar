/*
 *  RoboWar.errors.c
 *  RoboWar
 *
 *  Created by Sam Rushing on Tue Jun 29 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 */

#include "RoboWar.interface.errors.h"

void displayErr(char *errCode, char *errName, char *proc)
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
	
	CopyCStringToPascal(errCode, errorText);
	if (proc) {
		sprintf(explanationText, "%s\n\n%s", errName, proc);
		CopyCStringToPascal(explanationText, explanationText);
	} else
		CopyCStringToPascal(errName, explanationText);
	
	err = StandardAlert(
			kAlertStopAlert,
			errorText, explanationText,
			&paramRec,
			NULL
		);
	if (err != noErr) SysBeep(30);
}

OSErr checkMemErr(char *proc)
{
	// originally from ./Misc/Util.c
	OSErr err;
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
	
	return err;
}

OSErr checkResErr(char *proc)
{
	OSErr err;
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
	
	return err;
}

OSErr checkSndErr(OSErr err,char *proc)
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
	
	return err;
}

OSErr checkAppleEventErr(OSErr err, char *proc)
{
	char errCode[80],errName[80];
	
	if (err) {
		sprintf (errCode,"Apple Event Error %d", err);
		strcpy(errName,"Unknown");
		displayErr(errCode,errName,proc);
	}
	return err;
}

OSStatus checkNavErr(OSStatus err, char *proc)
{
	char errCode[80],errName[80];
	
	if (err) {
		sprintf (errCode,"Navigation Services Error %li", err);
		switch (err) {
			case kNavWrongDialogStateErr:
				strcpy(errName,"Dialog is not in correct state for requested operation."); break;
			case kNavWrongDialogClassErr:
				strcpy(errName,"Requested operation is not valid for this type of dialog."); break;
			case kNavInvalidSystemConfigErr:
				strcpy(errName,"One or more Navigation Services–required system components is missing or out of date."); break;
			case kNavCustomControlMessageFailedErr:
				strcpy(errName,"Navigation Services did not accept a control message sent by your application."); break;
			case kNavInvalidCustomControlMessageErr:
				strcpy(errName,"Your application sent an invalid custom control message."); break;
			case kNavMissingKindStringErr:
				strcpy(errName,"No kind strings were provided to describe your application's native file types."); break;
			default: strcpy(errName,"Unknown"); break;
		}
		displayErr(errCode,errName,proc);
	}
	return err;
}

OSErr checkFileErr(OSErr err,char *proc)
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
