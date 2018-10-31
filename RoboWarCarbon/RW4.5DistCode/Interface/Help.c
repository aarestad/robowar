/* Help.c */

/* Written 3/29/91 by David Harris */

/* This file is designed to be a self-contained, self-configuring help/instructions
	routine.  It requires the following resources:
	
	Help DLOG   ID 2000
	Help DILT   ID 2000
	Help CNTL   ID 2000
	Help TEXT	ID 2001-200n
	
	Enter the number of sections as a constant below and enter the section titles
	as P-strings in the global variable helpSections.  Edit the TEXT resources
	and copy the DLOG, DITL, and CNTL resources into the resource fork.
	
	Notes about using Style TextEdit:  7/25/93
	1) I haven't gotten this to work yet.
	2) Be sure to not use LineHeight; it is set to -1.
	3) SetStyleHandle doesn't work right--the Styl resource in ResEdit is
		not what it needs to use.
	
2)  When I printed the instructions, I found that if I interrupted printing,
    and then attempted to print the section over again, the print job would
    begin not at the beginning of the section, but rather at where I inter-
    rupted the last print job.
*/

/* #includes */

#include <Carbon/Carbon.h>

/* Constants */

#define HelpDlogID			2000
#define helpLinesPerPage	24
#define helpScrollAmount	12
#define helpPageAmount		(helpScrollAmount*(helpLinesPerPage-1))
#define numSections			10

/* Globals */

TEHandle helpTEH;
THPrint helpPrintRecord;
ControlHandle helpScroll;
short helpSection,helpPixPerPage;
Rect helpContentsBox;
ControlActionUPP helpScrollUPP;
char helpSections[numSections][20] = {"\pI: Introduction",
									  "\pII: Stations",
									  "\pIII: RoboTalk",
									  "\pIV: Operators",
									  "\pV: Registers",
									  "\pVI: Interrupts",
									  "\pVII: Tournaments",
									  "\pVIII: History",
									  "\pA: Version History",
									  "\pB: Sample Robots"};

#if __POWERPC__
	extern	QDGlobals	qd;					/* To make PowerPC happy */
#endif
extern char			registered[80];				/* Null = not registered */

/* Prototypes */

void 			helpDialog(void);
pascal void 	helpButtonProc(WindowPtr,short);
pascal void 	helpTextProc(WindowPtr,short);
pascal void 	helpContentsProc(WindowPtr,short);
pascal Boolean 	helpFilterProc(DialogPtr,EventRecord*,short*);
pascal void 	helpScrollProc(ControlHandle,short);
void 			helpUpdateScrolledText(void);
void 			helpPrintSection(void);
void 			helpSaveToDisk(void);

/* in Util.c */
extern void reportMessage(char*,char*);
extern void checkMemErr(char *proc);
extern OSErr checkFileErr(OSErr err,char *proc);

/* Code */

void helpDialog(void)
{
	DialogPtr myDialog;
	short itemHit,itemType;
	Handle item,sectionText,sectionStyle;
	Rect box,textRect;
	GrafPtr oldPort;
	UserItemUPP textUPP,buttonUPP,contentsUPP;
	ModalFilterUPP filterUPP;
	
	
	textUPP = NewUserItemProc(&helpTextProc);
	buttonUPP = NewUserItemProc(&helpButtonProc);
	contentsUPP = NewUserItemProc(&helpContentsProc);
	filterUPP = NewModalFilterProc(&helpFilterProc);
	helpScrollUPP = NewControlActionProc(&helpScrollProc);
	
	myDialog = GetNewDialog(HelpDlogID,NULL,(WindowPtr)-1);
	GetDialogItem(myDialog,2,&itemType,&item,&textRect);
	SetDialogItem(myDialog,2,itemType,(Handle)textUPP,&textRect);
	GetDialogItem(myDialog,3,&itemType,&item,&box);
	SetDialogItem(myDialog,3,itemType,(Handle)buttonUPP,&box);
	GetDialogItem(myDialog,5,&itemType,(Handle*)&helpScroll,&box);
	GetDialogItem(myDialog,6,&itemType,&item,&helpContentsBox);
	helpContentsBox.bottom = helpContentsBox.top+14*numSections+2;
	SetDialogItem(myDialog,6,itemType,(Handle)contentsUPP,&helpContentsBox);
	
	helpSection = 1;
/*	if (registered[0]) helpSection = 1;
	else helpSection = 9; */
	sectionText = (char **)GetResource('TEXT',helpSection+2000);
	sectionStyle = (char **)GetResource('styl',helpSection+2000);
	if (sectionStyle == NULL) SysBeep(1);
	MoveHHi(sectionText);
	HLock(sectionText);
	InsetRect(&textRect,2,2); 

	GetPort(&oldPort);
	ShowWindow(myDialog);
	SetPort(myDialog);

	TextFont(kFontIDGeneva);
	TextSize(9);
	helpTEH = TEStyleNew(&textRect,&textRect);
	TEAutoView(TRUE,helpTEH);
	
	TEActivate(helpTEH);								/* MUST be active for TEStyleInsert call */
	TEStyleInsert(*sectionText,GetHandleSize(sectionText),(StScrpHandle)sectionStyle,helpTEH); 
	TESetSelect(0,0,helpTEH);
	TEDeactivate(helpTEH);
	
	HUnlock(sectionText);
	
	SetControlValue(helpScroll,0);
	helpPixPerPage = textRect.bottom-textRect.top;
	SetControlMaximum(helpScroll,TEGetHeight(32767,0,helpTEH) - helpPixPerPage);

	do {
		ModalDialog(filterUPP,&itemHit);
		if (itemHit == 4) helpPrintSection();
		if (itemHit == 7) helpSaveToDisk();
	} while (itemHit != 1);
	DisposeDialog(myDialog);
	DisposeRoutineDescriptor(textUPP);
	DisposeRoutineDescriptor(buttonUPP);
	DisposeRoutineDescriptor(contentsUPP);
	DisposeRoutineDescriptor(filterUPP);
	DisposeRoutineDescriptor(helpScrollUPP);
	SetPort(oldPort);
}

pascal void helpButtonProc(WindowPtr theWindow,short itemNo)
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

pascal void helpTextProc(WindowPtr theWindow,short itemNo)
{
	short itemType;
	Handle item;
	Rect box;
	
	GetDialogItem(theWindow,itemNo,&itemType,&item,&box);
	EraseRect(&box);
	FrameRect(&box);
	ForeColor(blueColor);
	TEUpdate(&qd.thePort->portRect,helpTEH);
	ForeColor(blackColor);
}

pascal void helpContentsProc(WindowPtr theWindow,short itemNo)
{
	short itemType;
	Handle item;
	Rect box;
	short i;
	
	GetDialogItem(theWindow,itemNo,&itemType,&item,&box);
	EraseRect(&box);
	FrameRect(&box);
	MoveTo (box.left+1,box.bottom);
	LineTo (box.right,box.bottom);
	LineTo (box.right,box.top+1);
	ForeColor(redColor);
	for (i=0; i<numSections; i++) {
		MoveTo (box.left+3,box.top+i*14+12);
		DrawString ((unsigned char*)helpSections[i]);
	}
	ForeColor(blackColor);
	box.top += helpSection*14-13;
	box.bottom = box.top+14;
	box.left += 1; box.right -= 1;
	InvertRect(&box);
}

pascal Boolean helpFilterProc(DialogPtr theDialog,EventRecord *theEvent,short *itemHit)
{
	short result = 0,part;
	char c;
	ControlHandle whichControl;
	Handle sectionText,sectionStyle;
	
	if (theEvent->what == keyDown) {
		c = BitAnd(theEvent->message,charCodeMask);
		if (c == 13 || c == 3) { /* enter or return */
			*itemHit = 1;
			result = 1;
		}
	}
	else if (theEvent->what == mouseDown) {
		GlobalToLocal(&theEvent->where);
		if (part = FindControl(theEvent->where,theDialog,&whichControl)) {
			if (whichControl == helpScroll) {
				if (part == kControlIndicatorPart) {
					TrackControl (whichControl,theEvent->where,NULL);
					helpUpdateScrolledText();
				}
				else 
					TrackControl(whichControl,theEvent->where,helpScrollUPP);
				*itemHit = 5;
				result = 1;
			}
		}
		else if (PtInRect(theEvent->where,&helpContentsBox)) {
			part = (theEvent->where.v-helpContentsBox.top-2)/14+1;
			if (part != helpSection) {
				helpSection = part;
				SetCursor(*(GetCursor(watchCursor)));
				InvalRect(&qd.thePort->portRect);
				sectionText = (char **)GetResource('TEXT',helpSection+2000);
				sectionStyle = (char **)GetResource('styl',helpSection+2000);
				MoveHHi(sectionText);
				HLock(sectionText);
				ForeColor(blueColor);
				SetControlValue(helpScroll,0);
				TEAutoView(FALSE,helpTEH);
				TESetSelect(0,32767,helpTEH);
				TEDelete(helpTEH);
				TEActivate(helpTEH);				/* MUST be active for TEStyleInsert call */
				TEStyleInsert(*sectionText,GetHandleSize(sectionText),
							(StScrpHandle)sectionStyle,helpTEH); 
				TEDeactivate(helpTEH);
				TEAutoView(TRUE,helpTEH);
				TESetSelect(0,0,helpTEH);
				SetControlMaximum(helpScroll,TEGetHeight(32767,0,helpTEH) - helpPixPerPage);
				ForeColor(blackColor);
				HUnlock(sectionText);
				SetCursor(&qd.arrow);
			}
		}
		LocalToGlobal(&theEvent->where);
	}
	return result;
}

pascal void helpScrollProc(ControlHandle theControl, short theCode)
{
	short	scrollAmt;
	
	if (theCode == 0)
		return ;
	
	switch (theCode) {
		case kControlUpButtonPart: 
			scrollAmt = -helpScrollAmount;
			break;
		case kControlDownButtonPart: 
			scrollAmt = helpScrollAmount;
			break;
		case kControlPageUpPart: 
			scrollAmt = -helpPageAmount;
			break;
		case kControlPageDownPart: 
			scrollAmt = helpPageAmount;
			break;
		}
	SetControlValue( theControl, GetControlValue(theControl)+scrollAmt );
	helpUpdateScrolledText();
}

void helpUpdateScrolledText(void)
{
	short	oldScroll, newScroll, delta;
	
	oldScroll = (**helpTEH).viewRect.top - (**helpTEH).destRect.top;
	newScroll = GetControlValue(helpScroll);
	delta = oldScroll - newScroll;
	if (delta != 0) {
	 	ForeColor(blueColor);
	  	TEPinScroll(0, delta, helpTEH);
	  	ForeColor(blackColor);
	}
}

void helpPrintSection(void)
{
	short start,end,middle;
	short pageHeight,pageNum;
	TPrStatus status;
	TPPrPort printPort;
	GrafPtr oldPort;
	Rect destRect,r,viewRect;
	char titleString[100];
	
	GetPort (&oldPort);
	PrOpen();
	if (!PrError()) {
		helpPrintRecord = (THPrint)NewHandle(sizeof(TPrint));
		checkMemErr("Help:helpPrintSection:1");
		PrintDefault(helpPrintRecord);
		if (PrError()) reportMessage ("Error","Can't initialize print record");
		if (PrJobDialog(helpPrintRecord) && !PrError()) {
			printPort = PrOpenDoc(helpPrintRecord,NULL,NULL);
				TextFont(kFontIDGeneva);
				TextSize(9);
				viewRect = (*helpTEH)->viewRect;
				destRect = (*helpTEH)->destRect;
				(*helpTEH)->destRect.left = (*helpPrintRecord)->prInfo.rPage.left+54;
				(*helpTEH)->destRect.right = (*helpPrintRecord)->prInfo.rPage.right-54;
				(*helpTEH)->destRect.top = (*helpPrintRecord)->prInfo.rPage.top+36;
				middle = ((*helpPrintRecord)->prInfo.rPage.right-
						  (*helpPrintRecord)->prInfo.rPage.left)/2;
				TECalText(helpTEH);
				pageHeight = (*helpPrintRecord)->prInfo.rPage.bottom-76;
				checkMemErr("Help:helpPrintSection:2");
				start = 0; pageNum = 1;
				r.top = 36; 
				r.left = (*helpPrintRecord)->prInfo.rPage.left+54;
				r.right = (*helpPrintRecord)->prInfo.rPage.right-54;
				(*helpTEH)->inPort = qd.thePort;
				while (start <= (*helpTEH)->nLines) {
					PrOpenPage(printPort,NULL);
						end = start+1;
						while (TEGetHeight(end,start,helpTEH) < pageHeight && 
								end <= (*helpTEH)->nLines) end++;

						r.bottom = TEGetHeight(end-1,start,helpTEH)+r.top;

						(*helpTEH)->viewRect = r;  
						TEUpdate(&r,helpTEH);
						
						if (helpSection != 9) { /* Label section */
							sprintf (titleString,
									"RoboWar Instructions:    %s  Page %d",
									helpSections[helpSection-1]+1,pageNum);
							CtoPstr(titleString);
							TextFace(bold);
							TextSize(12);
							TextFont(kFontIDGeneva);
							MoveTo (middle-(short)StringWidth((unsigned char*)titleString)/2,
									pageHeight+50);
							DrawString((unsigned char*)titleString);
						}

						(*helpTEH)->destRect.top -= TEGetHeight(end-1,start,helpTEH);
						start = end;
						pageNum++;
					PrClosePage(printPort);
				}
				(*helpTEH)->inPort = oldPort;
				(*helpTEH)->destRect = destRect;
				(*helpTEH)->viewRect = viewRect;
				TECalText(helpTEH);
				if (PrError()) reportMessage ("Error","Can't close page");
			PrCloseDoc(printPort);
			if (!PrError() && (*helpPrintRecord)->prJob.bJDocLoop == bSpoolLoop)
				PrPicFile(helpPrintRecord,NULL,NULL,NULL,&status);
		}
	} else reportMessage ("Error","Can't open printer driver");
	PrClose();
	if (PrError()) reportMessage("Error","Can't close printer driver");
	SetPort(oldPort);
}

void helpSaveToDisk(void)
{
	SFReply myReply;
	Point where = {100,100};
	short i,refNum;
	long len;
	Handle txt;
	
	SFPutFile(where,"\pSave instructions as:","\pRoboWar Instructions",NULL,&myReply);
	if (myReply.good) {
		Create(myReply.fName,myReply.vRefNum,'RWAR','TEXT');
		if (!checkFileErr(FSOpen(myReply.fName,myReply.vRefNum,&refNum),
			"Help:helpSaveToDisk:Create")) {
			for (i=0; i<numSections; i++) {
				txt = (char **)GetResource('TEXT',2000+i);
				HLock(txt);
				len = GetHandleSize(txt);
				checkFileErr(FSWrite(refNum,&len,*txt),"Help:helpSaveToDisk:FSWrite");
				DetachResource(txt);
				if (i != helpSection) {
					HUnlock(txt);
					DisposeHandle(txt);
				} 
			}
			checkFileErr(FSClose(refNum),"Help:helpSaveToDisk:FSClose");
		}
	}
}