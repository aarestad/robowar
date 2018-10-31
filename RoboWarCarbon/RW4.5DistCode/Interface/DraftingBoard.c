/* DraftingBoard.c */

/*  Written 12/16/89 by David Harris
	(c) 1989 David Harris

	This file includes sections of code for RoboWar that
	are unique to the DraftingBoard mode.
*/

/* #includes */

#include <Carbon/Carbon.h>
#include "robotypes.h"


/* Globals */

//short		complainLength;			/* True if robot has complained about length */
asmInfo 	info;
MenuHandle	labelMenu;

	const		kScrollBarMax = (32000);
	
/* External Variables */

extern	WindowPtr		myWindow;
extern	MenuHandle		myMenus[5];			
extern	ControlHandle	myScrollBar;
//---r 	extern 	TEHandle		myText;
extern	WEReference		myWText;
extern	THPrint			printRecord;
extern	EventRecord		myEvent;
extern	CursHandle		editCursor;
extern	ControlHandle	myScrollBar;
extern  short			controlChange;
//extern	Handle			undoText;
//extern 	short			undoState;
//extern 	long			undoStart;
//extern	long			undoEnd;
extern	Str255			findStr;
extern	Str255			replaceStr;
extern 	robot			rob[maxBots];
extern 	short			botSelected;
extern 	short			modifyFlag;
//extern	LabelList		labelsList;
extern	prefStruct		gPrefs;		

#if __POWERPC__
	extern	QDGlobals	qd;					/* To make PowerPC happy */
#endif

/* Prototypes */

void readRobotText(void);
void saveRobot(void);
void printRobotCode(TPPrPort printPort) ;
void findText(void);
void replaceText(void);
void replaceFind(void);
void doFind(void);
void doReplace(void);
void updateDrafting(void);
void updateScrolledText(void);
pascal void scrollProc(ControlHandle theControl, short theCode);
void showSelected(void);
void clickDrafting(void);
//void fixEditUndo(void);
void cutText(void);
void copyText(void);
void pasteText(void);
void clearText(void);
void undoTyping(void);
void selectAll(void);
//void fixUndo(void);
void textKey(char c, short modifiers);
void ScrollPastSomePages( long pages );
void draftingSpecial(void);
void SetScrollBarFromTextView(void);
void SetTextViewPosFromScrollBar(void);
void MyUpdateAWaste( WEReference myWText);
void InitDraftingBoard(void);
void CloseDraftingBoard(void);
void GotoLabel( short labelID );
void GotoWordAt( long pos );
void UpdateFromPrefsChange(void);

/* in Util.c */
extern Ptr fileToBuffer(Str255,short vRefNum,long *length);
extern void reportMessage(char *message1,char *message2);
extern void checkMemErr(char *proc);
extern void checkResErr(char *proc);
extern OSErr checkFileErr(OSErr err,char *proc);
extern void setVolume(short vRefNum);
extern void restoreVolume(void);
extern void installButtonOutline(DialogPtr theDialog,short itemNo);

// --- in SyntaxColoring.c
extern void SyntaxColorRange( long start, long end, WEReference wasteText);
extern void	SyntaxColorSelection(WEReference wasteText);
extern Boolean DoCharIsComment( long* pos, Handle text, long end );

// --- in Util.c
extern void myReportNum( char* msg, long num );

// --- LabelMenu.c
//LabelItem* FindLabelByID( short id, LabelItem* labelsList );
/* Functions */

void readRobotText(void)
{
	Ptr		buffer;	// Buffer holds all Robot Text...
	long 	length;
	short 	i,refNum;
	long 	**res1;
	short 	**res2;
	long	selStart,selEnd;
	char 	msg[80], msg2[80];

	if ((buffer = fileToBuffer(rob[botSelected].name,rob[botSelected].vRefNum,&length)) != NULL) {
		if (rob[botSelected].password[0]) 
			for (i=0; i<length; i++)
				buffer[i] -= (67 + i + rob[botSelected].password[(i%rob[botSelected].password[0])+1]);
		if( WEInsert( buffer, length, nil, nil, myWText) != noErr )
		{
			reportMessage("Problem! Can't use text buffer...",":DraftingBorad.c:readRobotText:0");
		}
		DisposePtr(buffer);
		if(MemError())
		{
			reportMessage("Memory Error!!",":DraftingBorad.c:readRobotText:1");
			SysBeep(1);
		}
	}
	
	modifyFlag = 0;
	
	setVolume(rob[botSelected].vRefNum);
	refNum = OpenResFile(rob[botSelected].name);
	
	if( refNum == -1 ) 
	{
		sprintf(msg,"Error opening robot %s.",rob[botSelected].name);
		sprintf(msg2,"Resource Error #%d. :DraftingBoard:readRobotText",ResError());
		reportMessage (msg,msg2);
		ExitToShell();
	}
	
	res1 = (long**)GetResource('DATE',softwareDateID);
	if (res1 == NULL) info.softDate = 0;
	else info.softDate = (**res1);
	
	res1 = (long**)GetResource('DATE',hardwareDateID);
	if (res1 == NULL) info.hardDate = 0;
	else info.hardDate = (**res1);
	
	res1 = (long**)GetResource('DATE',asmDateID);
	if (res1 == NULL) info.asmDate = 0;
	else info.asmDate = (**res1);
	
	res1 = (long**)GetResource('DATE',iconDateID);
	if (res1 == NULL) info.iconDate = 0;
	else info.iconDate = (**res1);
	
	res1 = (long**)GetResource('DATE',recordingDateID);
	if (res1 == NULL) info.recordingDate = 0;
	else info.recordingDate = (**res1);
	
	res2 = (short**)GetResource('RLEN',codeLengthID);
	if (res2 == NULL) info.codeLength = 0;
	else info.codeLength = (**res2);
	
	res1 = (long**)GetResource('CPOS',selectStartID);
	if ( (res1 == NULL) || (GetHandleSize((Handle)res1) < 4L ) )
	{
		selEnd = selStart = 0;
		WESetSelection(selStart, selEnd, myWText);
	}
	else
	{
		selStart = **res1;	//---r (*myText)->selStart = **res2;
		res1 = (long**)GetResource('CPOS',selectEndID);
		if ( (res1 == NULL) || (GetHandleSize((Handle)res1) < 4L ) )
			selEnd = selStart;
		else selEnd = **res1;
		
		WESetSelection(selStart, selEnd, myWText);
	}
	
	//--- 19 apr 97 --- count cicn's
	info.numIcons = Count1Resources('cicn');
	info.numSounds = Count1Resources('snd ');
	
	CloseResFile(refNum);
	restoreVolume();
	
	showSelected();
}


void saveRobot(void) /* Assumes current robot */
{
	short 			err = 0;
	short 			i;
	short 			refNum;
	Handle 			prog;
	long 			length;
	unsigned long 	dateTime;
	Handle 			theRes;
	long 			**aRes;
	long 			**bRes;
	long			selStart,selEnd;
	
	if (checkFileErr(FSOpen(rob[botSelected].name,rob[botSelected].vRefNum,&refNum),
		"DraftingBoard:saveRobot:FSOpen")) err = 1;
	else {
		prog = 	WEGetText( myWText );
		HLock(prog);
		length = GetHandleSize(prog);
		if (rob[botSelected].password[0])
			for (i=0; i<length; i++)
				(*prog)[i] += 67 + i + rob[botSelected].password[(i%rob[botSelected].password[0])+1];
		if (checkFileErr(FSWrite(refNum,&length,*prog),"DraftingBoard:saveRobot:FSWrite")) 
			err = 1;
		if (checkFileErr(SetEOF(refNum,length),"DraftingBoard:saveRobot:SetEOF")) err = 1;
		if (checkFileErr(FSClose(refNum),"DraftingBoard:saveRobot:FSClose")) err = 1;
		HUnlock(prog);
	}
	if (err) reportMessage ("Error saving robot","");
	//if (ZeroScrap()) reportMessage ("Unable to Zero scrap","");
	//else if ( TEToScrap() ) reportMessage ("Unable to write scrap","");	//---x TEToScrap
	
	// Update date of last modification
	
	GetDateTime(&dateTime);
	
	setVolume(rob[botSelected].vRefNum);
	CreateResFile(rob[botSelected].name);
	if ((refNum = OpenResFile(rob[botSelected].name)) == -1) {
		checkResErr("DraftingBoard:saveRobot:OpenResFile");
	}
	else {
		if ((theRes = GetResource('DATE',softwareDateID)) != NULL) {
			RemoveResource(theRes);
			checkResErr("DraftingBoard:saveRobot:1");
			DisposeHandle(theRes);
			checkMemErr("DraftingBoard:saveRobot:1");
		}
		if ((theRes = GetResource('CPOS',selectStartID)) != NULL) {
			RemoveResource(theRes);
			checkResErr("DraftingBoard:saveRobot:2");
			DisposeHandle(theRes);
		}
		if ((theRes = GetResource('CPOS',selectEndID)) != NULL) {
			RemoveResource(theRes);
			checkResErr("DraftingBoard:saveRobot:3");
			DisposeHandle(theRes);
		}
		aRes = (long**)NewHandle(4L);
		checkMemErr("DraftingBoard:saveRobot:2");
		(*aRes)[0] = dateTime;
		AddResource((Handle)aRes,'DATE',softwareDateID,"\pSoftware");
		checkResErr("DraftingBoard:saveRobot:4");
		
		WEGetSelection( &selStart, &selEnd, myWText );
		
		bRes = (long**)NewHandle(4L);
		(*bRes)[0] = selStart;
		AddResource((Handle)bRes,'CPOS',selectStartID,"\pSelection Start");
		checkResErr("DraftingBoard:saveRobot:5");

		bRes = (long**)NewHandle(4L);
		**bRes = selEnd;
		AddResource((Handle)bRes,'CPOS',selectEndID,"\pSelection End");
		checkResErr("DraftingBoard:saveRobot:6");
		
		CloseResFile (refNum);
	}
	restoreVolume();
}				

void printRobotCode(TPPrPort printPort) 
{
	short 		doneFlag = 0;
	short 		pageHeight,curLine,endLine;
	CharsHandle theText;
	short		lineHeight;
	//WERunInfo	textInfo;
	
	curLine = 0;
	//lineHeight = WEGetInfo( 0, &textInfo, myWText );
	lineHeight = WEGetHeight(0,1,myWText);
	pageHeight = (*printRecord)->prInfo.rPage.bottom / lineHeight;//  textInfo.runHeight;
	//---r 		pageHeight = (*printRecord)->prInfo.rPage.bottom / (*myText)->lineHeight-1;
	theText = 	WEGetText( myWText );//TEGetText(myText);
	MoveHHi(theText);
	HLock(theText);
	checkMemErr("DraftingBoard:printRobot‚ode:1");
	while (!doneFlag && !PrError()) {
		PrOpenPage(printPort,NULL);
			MoveTo (0, lineHeight); //(*myText)->lineHeight);
			TextFont(kFontIDMonaco);
			TextSize(9);
			endLine = curLine+pageHeight;
			if (endLine >= WECountLines(myWText))  {	// (*myText)->nLines)
				endLine = WECountLines(myWText);	// (*myText)->nLines;
				doneFlag = 1;
			}
			TETextBox (((char*)(*theText)+WEOffsetToLine(curLine, myWText)),		//(*myText)->lineStarts[curLine]),
					  (long)WEOffsetToLine(endLine, myWText) -		//((*myText)->lineStarts[endLine]-
					  WEOffsetToLine(curLine, myWText),				//(*myText)->lineStarts[curLine]),
					  &(*printRecord)->prInfo.rPage,teJustLeft); 
			curLine += pageHeight;
		PrClosePage(printPort);
	}
	HUnlock(theText);
	checkMemErr("DraftingBoard:printRobot‚ode:2");
}

void findText(void)
{
	char **code,*text;
	long i,j;
	long len;
	long start,end;
	long selStart, selEnd;
	char c;
	
	code = (Handle)WEGetText(myWText);	//TEGetText(myText);
	len = WEGetTextLength(myWText);				//(*myText)->teLength;
	text = *code;
	start = -1;
	c = tolower(findStr[0]);
	WEGetSelection( &selStart, &selEnd, myWText );
	for (i=selEnd; i<len && start == -1; i++)
		if (tolower(text[i]) == c) {
			j = 1;
			while (i+j < len && findStr[j] && 
				   tolower(findStr[j]) == tolower(text[i+j])) j++;
			if (tolower(findStr[j-1]) == tolower(text[i+j-1]) && findStr[j] == 0) {
				start = i; end = i+j;
			}
		}
	if (start != -1) {
		WESetSelection( start, end, myWText );
		//TESetSelect(start,end,myText);
		//undoState = 1;
		modifyFlag = 1;
	}
	else SysBeep(1);
}

void replaceText(void)
{
	long len;
	
	len = 0;
	while (replaceStr[len]) len++;
	//fixEditUndo();
	//---r
	// TEDelete(myText);
	// TEInsert(replaceStr,len,myText);
	WEInsert( replaceStr, len, nil, nil, myWText );
	
	SyntaxColorSelection(myWText);
}


void replaceFind(void)
{
	replaceText();
	findText();
}

void doFind(void)
{
	DialogPtr myDialog;
	short itemHit;
	short itemType;
	Handle item;
	Rect box;
	
	
	//if (ZeroScrap()) reportMessage ("Unable to Zero scrap","");
	//else if (TEToScrap()) reportMessage ("Unable to write scrap","");
	
	myDialog = GetNewDialog(FindDlogID,NULL,(WindowPtr)-1);
	installButtonOutline(myDialog,5);
	GetDialogItem(myDialog,4,&itemType,&item,&box);
	CtoPstr((char*)findStr);
	SetDialogItemText(item,findStr);
	SelectDialogItemText(myDialog,4,0,32767);
	do {
		ModalDialog(NULL,&itemHit);
	} while (itemHit != 1 && itemHit != 2);
	if (itemHit == 1) {
		GetDialogItemText(item,findStr);
		if (findStr[0]) {
			EnableItem(myMenus[2],findNext_);
			if (replaceStr[0]) EnableItem(myMenus[2],replaceFind_);
		}
		else {
			DisableItem(myMenus[2],findNext_);
			if (replaceStr[0]) DisableItem(myMenus[2],replaceFind_);
		}
	}
	DisposeDialog(myDialog);
	PtoCstr(findStr);
	if (itemHit == 1 && findStr[0]) 
		findText();
}

void doReplace(void)
{
	DialogPtr myDialog;
	short itemHit;
	short itemType;
	Handle item;
	Rect box;
	
	if (ZeroScrap()) reportMessage ("Unable to Zero scrap","");
	else if (TEToScrap()) reportMessage ("Unable to write scrap","");	//---x 

	myDialog = GetNewDialog(ReplaceDlogID,NULL,(WindowPtr)-1);
	installButtonOutline(myDialog,5);
	GetDialogItem(myDialog,4,&itemType,&item,&box);
	CtoPstr((char*)replaceStr);
	SetDialogItemText(item,replaceStr);
	SelectDialogItemText(myDialog,4,0,32767);
	do {
		ModalDialog(NULL,&itemHit);
	} while (itemHit != 1 && itemHit != 2);
	if (itemHit == 1) {
		GetDialogItemText(item,replaceStr);
		if (replaceStr[0] && findStr[0]) EnableItem(myMenus[2],replaceFind_);
		else DisableItem(myMenus[2],replaceFind_);
	}
	DisposeDialog(myDialog);
	PtoCstr(replaceStr);
	if (itemHit == 1 && replaceStr[0]) 
		replaceText();
}

void updateDrafting(void)
{
	Str255 date,time;
	Str255 msg;
	//long	selStart,selEnd;

	EraseRect(&myWindow->portRect);
	if (controlChange) {
		showSelected();
		updateScrolledText();
		DrawControls( myWindow );
		controlChange = 0;
		//complainLength = 0;
	}
	
	MyUpdateAWaste(myWText);
	
	TextFace (bold+underline);
	MoveTo (305,40); DrawString ("\pProgram Information:");
	MoveTo (305,105); DrawString ("\pPassword Information:");
	MoveTo (305,140); DrawString ("\pModification Dates:");
	TextFace (0);
	MoveTo (310,55); DrawString ("\pSoftware Length:");
	MoveTo (310,65); DrawString ("\pCode Length:");
	MoveTo (310,75); DrawString ("\pNumber of Icons:");
	MoveTo (310,85); DrawString ("\pNumber of sounds:");
	MoveTo (310,120); DrawString ("\pPassword Enabled:");
	MoveTo (310,155); DrawString ("\pSoftware:");
	MoveTo (310,165); DrawString ("\pCode:");
	MoveTo (310,175); DrawString ("\pHardware:");
	MoveTo (310,185); DrawString ("\pIcons:");
	MoveTo (310,195); DrawString ("\pSounds:");
	//---r  //(*myText)->nLines//(*myText)->teLength)

	sprintf ((char*)msg,"%5d/%5d", (UInt16)WECountLines(myWText) ,(UInt16)WEGetTextLength(myWText)) ; //%-4d
	CtoPstr((char*)msg);
	MoveTo (420,55); DrawString (msg);
	sprintf ((char*)msg,"%d",info.codeLength);
	CtoPstr((char*)msg);
	MoveTo (420,65); DrawString (msg);
	sprintf ((char*)msg,"%d",info.numIcons);
	CtoPstr((char*)msg);
	MoveTo (420,75); DrawString (msg);
	sprintf ((char*)msg,"%d",info.numSounds);
	CtoPstr((char*)msg);
	MoveTo (420,85); DrawString (msg);
	MoveTo (420,120);
	if (rob[botSelected].password[0]) DrawString ("\pYes");
	else DrawString("\pNo");
	if (info.softDate) {
		IUDateString(info.softDate,0,date);
		IUTimeString(info.softDate,FALSE,time);
		PtoCstr(date); PtoCstr(time);
		sprintf ((char*)msg,"%10s  %s",time,date);
	}
	else strcpy((char*)msg,"         Unmodified");
	CtoPstr((char*)msg);
	MoveTo (370,155); DrawString (msg);
	if (info.asmDate) {
		IUDateString(info.asmDate,0,date);
		IUTimeString(info.asmDate,FALSE,time);
		PtoCstr(date); PtoCstr(time);
		sprintf ((char*)msg,"%10s  %s",time,date);
	}
	else strcpy((char*)msg,"         Unmodified");
	CtoPstr((char*)msg);
	MoveTo (370,165); DrawString(msg);
	if (info.hardDate) {
		IUDateString(info.hardDate,0,date);
		IUTimeString(info.hardDate,FALSE,time);
		PtoCstr(date); PtoCstr(time);
		sprintf ((char*)msg,"%10s  %s",time,date);
	}
	else strcpy((char*)msg,"         Unmodified");
	CtoPstr((char*)msg);
	MoveTo (370,175); DrawString(msg);
	if (info.iconDate) {
		IUDateString(info.iconDate,0,date);
		IUTimeString(info.iconDate,FALSE,time);
		PtoCstr(date); PtoCstr(time);
		sprintf ((char*)msg,"%10s  %s",time,date);
	}
	else strcpy((char*)msg,"         Unmodified");
	CtoPstr((char*)msg);
	MoveTo (370,185); DrawString(msg);
	if (info.recordingDate) {
		IUDateString(info.recordingDate,0,date);
		IUTimeString(info.recordingDate,FALSE,time);
		PtoCstr(date); PtoCstr(time);
		sprintf ((char*)msg,"%10s  %s",time,date);
	}
	else strcpy((char*)msg,"         Unmodified");
	CtoPstr((char*)msg);
	MoveTo (370,195); DrawString(msg);
	
}

void updateScrolledText(void)
{
	SetTextViewPosFromScrollBar();
	/*long		 newScroll, delta, oldScroll;
	LongRect	vr,dr;
	//WERunInfo	textInfo;
	
	WEGetDestRect( &dr, myWText );
	WEGetViewRect( &vr, myWText );
	//WEGetInfo( 1, &textInfo, myWText );
	//vr.bottom - vr.top / (2^15);
	
	oldScroll = vr.top - dr.top;//(**myText).viewRect.top - (**myText).destRect.top;
	newScroll = (GetControlValue(myScrollBar) * (vr.bottom - vr.top )) / (2^15);// * textInfo.runHeight;//(**myText).lineHeight;
	delta = oldScroll - newScroll;
	
	if (delta != 0)
		WEScroll(0, delta, myWText );
	  //---r TEPinScroll(0, delta, myText);
	//SetScrollBarFromTextView();*/
}


pascal void scrollProc(ControlHandle theControl, short theCode)
{
//---x

	#pragma unused(theControl)
	
	long		scrollAmt, textTotalHeight;
	LongRect	destRect, viewRect;
	
	if (theCode == 0)
		return ;
	
	// --- Get the onscreen View Rect
	WEGetViewRect(&viewRect, myWText );
	
	WEGetDestRect(&destRect, myWText );
	textTotalHeight = WEGetHeight(0, WECountLines( myWText ), myWText ) - (viewRect.bottom - viewRect.top);
	
	switch (theCode) {
		case kControlUpButtonPart:
			scrollAmt = -7;
			break;
		case kControlDownButtonPart:
			scrollAmt = 7;
			break;
		case kControlPageUpPart: 
			scrollAmt = -viewHeight+1;
			break;
		case kControlPageDownPart: 
			scrollAmt = viewHeight-1;
			break;
		}
	
	if( ((-destRect.top + 1) + scrollAmt) < 0 )
		scrollAmt = -(-destRect.top + 1);
	else if( ((-destRect.top + 1) + scrollAmt) > textTotalHeight)
		scrollAmt = textTotalHeight - (-destRect.top + 1);
	
	WEScroll(0, -scrollAmt, myWText );
	
	SetScrollBarFromTextView();
	
	//SetControlValue( theControl, GetControlValue(theControl)+scrollAmt );
	//updateScrolledText();
}

void showSelected(void)
{
	//long		selStart, selEnd;
	//long		line;
	//LongRect	vr, dr;
	//WERunInfo	textInfo;
	
	//WEGetSelection( &selStart, &selEnd, myWText );
	WESelView( myWText );
	SetScrollBarFromTextView();
	//line = WEOffsetToLine( selStart, myWText );	
	
	//WEGetInfo( 0, &textInfo, myWText );
	
	//WEGetDestRect( &dr, myWText );
	//WEGetDestRect( &dr, myWText );
	
	// cur scrol val = viewPos * scrolMax / ViewMax
	//(dr.top - vr.top) * (2^15) / (vr.bottom - vr.top );
	
	//SetControlValue( myScrollBar, (textInfo.runHeight * line) * kScrollBarMax / (dr.bottom - dr.top ) );//(**myText).lineHeight;
	
	//updateScrolledText();
	
	//WEScroll(0, textInfo.runHeight * line, myWText );
	//
	//updateScrolledText();
	
	/*short	n,topLine, bottomLine, theLine;
	
	n = (**myText).nLines-viewHeight;

	if ((**myText).teLength > 0 && (*((**myText).hText))[(**myText).teLength-1]=='\r')
		n++;

	SetControlMaximum(myScrollBar, n > 0 ? n : 0);

	topLine = GetControlValue(myScrollBar);
	bottomLine = topLine + viewHeight;
	
	if ((**myText).selStart < (**myText).lineStarts[topLine] ||
			(**myText).selStart >= (**myText).lineStarts[bottomLine]) {
		for (theLine = 0; (**myText).selStart >= (**myText).lineStarts[theLine]; theLine++)
			;
		SetControlValue(myScrollBar, theLine - viewHeight/2);
		updateScrolledText();
	}
	
	if (((**myText).teLength > 32000 && !complainLength) || (**myText).teLength > 32500 ) {
		reportMessage("The program is getting too long.","Conclude soon (before len=32767).");
		complainLength = 1;
	}*/
}

void clickDrafting(void)
{
	Rect 		r;
	LongRect	vr;
	//short		tmpShort;
	//ControlHandle	inControl;
	
	WEGetViewRect( &vr, myWText );
	WELongRectToRect( &vr, &r );
	GlobalToLocal (&myEvent.where);
	
	if (PtInRect(myEvent.where,&r)) {
		//if( myEvent.modifiers & shiftKey )
		//{
			//WEClick( myEvent.where,myEvent.modifiers,TickCount(), myWText );
		//}
		//else
		//{
		WEClick( myEvent.where,myEvent.modifiers,TickCount(), myWText );
			//TEClick(myEvent.where,(myEvent.modifiers & shiftKey) > 0,myText);
			//r.top = 45; r.bottom = 55;
			//r.left = 420; r.right = 490;
			//InvalRect(&r); 
			//undoState = 1;
		modifyFlag = 1;
		//}
		//SyntaxColorSelection(myWText);
	}
	
	//if( FindControl(myEvent.where,myWindow,&inControl) )
	//{
	//	tmpShort = TrackControl( inControl, myEvent.where, (RoutineDescriptor*)-1 );
	//	if( tmpShort && inControl == labelMenu )
	//	{
	//		GotoLabel( tmpShort );
	//	}
	//}
}

/*void fixEditUndo(void)
{
	long	selStart, selEnd;
	
	undoState = 0;
	DisposeHandle(undoText);
	checkMemErr("DraftingBoard:fixEditUndo");
	undoText = (Handle)WEGetText(myWText);	//TEGetText(myText);
	if (HandToHand(&undoText)) SysBeep(1);
	//---r
	WEGetSelection( &selStart, &selEnd, myWText );
	undoStart = selStart;	//(*myText)->selStart;
	undoEnd = selEnd; //(*myText)->selEnd;
	modifyFlag = 1;
}*/

void cutText(void)
{
	//fixEditUndo();
	WECut( myWText );
	modifyFlag = 1;
	//---r TECut(myText);
	//SyntaxColorSelection(myWText);
}

void copyText(void)
{
	short	error;
	
	error = WECopy( myWText );
	
	if( error == -108 )
		reportMessage( "There's not enough memory to copy ALL that.","DraftingBoard:copyText:1" );
	else if( error == weEmptySelectionErr )
		SysBeep(0);
	else if(  error != noErr )
		reportMessage( "Error Copying Text.","DraftingBoard:copyText:1" );
	
	/*
	long 	selStart, selEnd;
	Ptr	theText;
	
	//---r 
	
	//if (ZeroScrap()) reportMessage ("Unable to Zero scrap","DraftingBoard:copyText:2");



	WEGetSelection(&selStart, &selEnd, myWText);

	theText = (*WEGetText(myWText)) + selStart;
	
	// --- limmit selection to 32k
	if( (selEnd - selStart) > 32000 )
	{
		selEnd = selStart + 32000;
		WESetSelection( selStart, selEnd, myWText );
		reportMessage ("The selection has been shortened because you can't have more than 32k of test in the clipboard.","DraftingBoard:copyText:2");
	}
	if (PutScrap(selEnd - selStart,'text', theText ) )
		reportMessage ("Couldn't copy to the clipboard.","DraftingBoard:copyText:3");
	*/
	//if ((*myText)->selStart == (*myText)->selEnd) SysBeep(1);
	//else TECopy(myText);
}

void pasteText(void)
{
	//fixEditUndo();
	//---r
	WEPaste(myWText);
	modifyFlag = 1;
	//TEPaste(myText);
	//SyntaxColorSelection(myWText);
}

void clearText(void)
{
	//fixEditUndo();
	WEDelete( myWText ) ;
	modifyFlag = 1;
	//TEDelete(myText);
	//SyntaxColorSelection(myWText);
}




void undoTyping(void)
{
	WEUndo(myWText);
	modifyFlag = 1;
	//SyntaxColorSelection(myWText);
	/*Handle 		temp;
	Rect		r;
	LongRect	vr;
	long 		start,end;
	
	//undoState = 1;
	temp = (Handle)WEGetText(myWText);	//---rTEGetText(myText);
	if (HandToHand(&temp)) SysBeep(1);
	WEGetSelection( &start, &end, myWText );
	//start = (*myText)->selStart;
	//end = (*myText)->selEnd;
	//HLock(undoText);
	//WEInsert(*undoText, GetHandleSize(undoText),nil,nil, myWText );
	//TESetText(*undoText,GetHandleSize(undoText),myText);
	//HUnlock(undoText);
	DisposeHandle(undoText);
	checkMemErr("DraftingBoard:undoTyping");
	WESetSelection(undoStart, undoEnd, myWText );
	//TESetSelect(undoStart,undoEnd,myText);
	undoText = temp;
	undoStart = start;
	undoEnd = end;
	showSelected();
	r.top = 45; r.bottom = 55;
	r.left = 420; r.right = 490;
	InvalRect(&r);
	WEGetViewRect(&vr, myWText );
	WELongRectToRect( &vr, &r );
	InvalRect(&r);*/
}

// --------------------------------------------------------------------------------
void selectAll(void)
{
	//fixEditUndo();
	WESetSelection( 0, WEGetTextLength(myWText),myWText );
	//TEDelete(myText);
	//SyntaxColorSelection(myWText);
}
//void fixUndo(void)
//{
	
	/*if (undoState) {
		undoState = 0;
		DisposeHandle(undoText);
		checkMemErr("DraftingBoard:fixUndo");
		undoText = (Handle)WEGetText(myWText);	//---rTEGetText(myText);
		if (HandToHand(&undoText)) SysBeep(1);
		WEGetSelection( &undoStart, &undoEnd, myWText);
		//undoStart = (*myText)->selStart;
		//undoEnd = (*myText)->selEnd;
	}*/
//}

// --------------------------------------------------------------------------------
void textKey(char c, short modifiers)
{
	// if key is tab and no modifiers then replace tab with three spaces
	if( c == '\t' && modifiers == 128 )
	{
		WEKey( ' ', modifiers, myWText );
		WEKey( ' ', modifiers, myWText );
		WEKey( ' ', modifiers, myWText );
		modifyFlag = 1;
	}
	else if( c == '\v' )	// page up key
	{
		ScrollPastSomePages( -1 );
	}
	else if( c == '\f' ) // page down key
	{
		ScrollPastSomePages( 1 );
	}
	else
	{
		WEKey( c, modifiers, myWText );
		modifyFlag = 1;
	}
	
	//SyntaxColorSelection(myWText);
}


// --------------------------------------------------------------------------------
void ScrollPastSomePages( long pages )
{
	LongRect 	viewRect, destRect;
	long	scrollQty, textTotalHeight, newTopPos;
	
	// - get the waste rect on screen
	WEGetViewRect(&viewRect, myWText );

	// - get the waste rect on screen
	WEGetDestRect(&destRect, myWText );

	// - scroll Qty is the screen size * num of pages.
	scrollQty = (pages * (viewRect.bottom - viewRect.top));
	
	textTotalHeight = WEGetHeight(0, WECountLines( myWText ), myWText ) - (viewRect.bottom - viewRect.top);
	
	newTopPos = (-destRect.top) + scrollQty;
	
	// - limmit the scrolling to the size of waste ie, don't scroll past bottom or top of document.
	if( newTopPos <= 0 )
		scrollQty = destRect.top; // scroll by -OldTopPos
	else if( newTopPos > textTotalHeight )
		scrollQty = (textTotalHeight - (-destRect.top)); // scroll by all - Oldtextpos
	
	// - Make Waste Scroll
	WEScroll( 0, -scrollQty, myWText );
	
	// - Set the scroll Bars
	SetScrollBarFromTextView();
}
		
// --------------------------------------------------------------------------------
// --- Special things to do when we get a drafting board event
void draftingSpecial(void)
{
	Point 		where;
	LongRect 	vr;	// view Rect 
	Rect 		r; 	// On Screen View Rect (short Rect)
	//WERunInfo	textInfo;
			
	WEIdle(nil, myWText);
	
	// * Check for mous pos and adjust WASTE cursor...
	WEGetViewRect(&vr, myWText );
	WELongRectToRect(&vr,&r);
	
	GetMouse(&where);
	if (PtInRect(where,&r))
		SetCursor (*editCursor);
	else SetCursor (&qd.arrow);
	//WEAdjustCursor(where, nil, myWText);
	
	SetScrollBarFromTextView();
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ¥ SetScrollBarFromTextView
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// - Set the ScrollBar from the WASTE text view
// - Sets the Scrollbar Max and the cur Val
void SetScrollBarFromTextView()
{
	long		scrollPos, curTextPos, textTotalHeight, scrollBarMax;//, destPos;
	LongRect	destRect, viewRect;
	short		tmpShort;
	
	// Get the on screen view rect
	WEGetViewRect(&viewRect, myWText ); 
	
	// calc total height of text
	textTotalHeight = WEGetHeight(0, WECountLines( myWText ), myWText ) - (viewRect.bottom - viewRect.top);
	
	// Get the dest rect... for finding our pos in the text
	WEGetDestRect(&destRect, myWText );
	
	curTextPos = -destRect.top + 1;
	
	// This is used when the destRect is lower than the last piece of text, 
	// at which point we want to be able to scroll up, so we need to set the 
	// totoal text height to the current pos, => we are at the bottom;
	if( curTextPos > textTotalHeight )
		textTotalHeight = curTextPos;
	
	scrollBarMax = kScrollBarMax;
	
	if( textTotalHeight > 0 )
		scrollPos = curTextPos * scrollBarMax / textTotalHeight;
	else
		scrollPos = 0;
	
	
	if( textTotalHeight > 0 )
	{
		//tmpShort = GetControlMaximum( myScrollBar );
		//if( tmpShort != kScrollBarMax )
			SetControlMaximum(myScrollBar, kScrollBarMax );
	}
	else
	{
		//tmpShort = GetControlMaximum( myScrollBar );
		//if( tmpShort != kScrollBarMax )
			SetControlMaximum(myScrollBar, 0);
	}
	
	tmpShort = GetControlValue( myScrollBar );
	if( tmpShort != scrollPos )
		SetControlValue( myScrollBar, scrollPos );
}


//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ¥ SetTextViewPosFromScrollBar
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// - 
void SetTextViewPosFromScrollBar()
{
	long		scrollPos, curTextPos, textTotalHeight, scrollBarMax, oldTextPos, changeInViewPos;
	LongRect	destRect, viewRect;
	
	if( GetControlMaximum( myScrollBar ) > 0 )
	{
		// Get the on csreen view rect
		WEGetViewRect(&viewRect, myWText ); 
		// calc total height of text
		textTotalHeight = WEGetHeight(0, WECountLines( myWText ), myWText ) - (viewRect.bottom - viewRect.top);
		
		scrollBarMax = kScrollBarMax;
		
		scrollPos = GetControlValue(myScrollBar);
		
		curTextPos = scrollPos * textTotalHeight / scrollBarMax;
		
		WEGetDestRect(&destRect, myWText );
		oldTextPos = -destRect.top + 1;
		
		changeInViewPos = oldTextPos - curTextPos;
		
		if (changeInViewPos != 0)
		{
			WEScroll(0, changeInViewPos, myWText );
		}
	}
}


//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ¥ myUpdateAWaste
// - Update a waste according to it's rect
void MyUpdateAWaste( WEReference myWText)
{
	RgnHandle	rgnH;
	LongRect	viewRect;
	Rect 		r;
	
	rgnH = NewRgn();
	
	WEGetViewRect( &viewRect, myWText );
	WELongRectToRect( &viewRect, &r );
	
	SetRectRgn( rgnH, r.left, r.top, r.right, r.bottom);
	
	WEUpdate( rgnH, myWText );
	
	DisposeRgn( rgnH );
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ¥ 
// -
void InitDraftingBoard()
{
	//Rect	r;
	
	//labelsList = nil;
	//SetRect(&r, 320, 200, 380, 216 );
	//labelMenu = GetMenu( 3001 ); //GetNewControl(3001,myWindow);
	//if(labelMenu == NULL)
	//	reportMessage("Error Loading Labels Menu", "DraftingBoard:InitDraftingBoard:1");
	
	//labelMenu = NewControl( myWindow, &r, "\pLabels", false, 0, 0, 1, popupMenuProc, 0 );
	//InsertMenu( labelMenu, nil );
	InvalMenuBar();
	   
	ShowControl(myScrollBar);
	//ShowControl(labelMenu);
	SyntaxColorRange( 0, WEGetTextLength( myWText ), myWText ); //---n 15/4/98
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ¥ 
// ---
void CloseDraftingBoard()
{
	//if( labelMenu != NULL )
	//{
	//	DeleteMenu( 3001 );
	//	DisposeMenu( labelMenu );
	//}
		//DisposeControl( labelMenu );
	
	WEDispose( myWText );
	checkMemErr("Main:resetView");
	
	InvalMenuBar();
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ¥ 
// ---
void GotoLabel( short labelID )
{
	/*LabelItem*	item;
	
	item = FindLabelByID( labelID - 1, labelsList );
	
	if( item != nil )
		GotoWordAt( item->pos );
		
	*/
	Handle	text;
	Str255	menuName;
	long 	pos;
	short	wordPos; // position in label word
	
	GetMenuItemText( labelMenu, labelID, menuName);
	
	menuName[menuName[0] + 1] = ':';
	menuName[0]++;
	
	text = WEGetText(myWText);
	
	// --- Find word code... 
	wordPos = 0;
	// for ( we ae still in the code, and we have not found the word...
	for( pos = 0; (pos < WEGetTextLength(myWText)) && (wordPos != menuName[0] + 1);  pos++ )
	{
		// skip comments...
		DoCharIsComment( &pos, WEGetText(myWText), WEGetTextLength(myWText) );
		
		// if the prev char is a deliminator ie space then check i
		//if( IsDelimCharQ( (*text)[pos-1] ) )
		//{
		// check is the current word is the label
		for( wordPos = 1; (menuName[wordPos] == (*text)[pos]) && (pos++ < WEGetTextLength(myWText)); wordPos++)
		;
		//}
	}
	
	pos -= 3;
	
	// if word found go there, else beep
	if( wordPos == menuName[0] + 1)
	{
		GotoWordAt( FindWordStart( pos, WEGetText(myWText) ) );
	}
	else
		SysBeep(0);
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ¥ 
// ---
void GotoWordAt( long pos )
{
	long	wordStart, wordEnd;
	
	if( pos >= WEGetTextLength(myWText) || pos < 0)
	{
		reportMessage("Selection Out of range. I think the robot has not been compiled.","Nothing selected.");
		return;
	}
	wordStart = pos;
	wordEnd = FindWordEnd( wordStart, WEGetText(myWText), WEGetTextLength(myWText)  );
	
	WESetSelection( wordStart, wordEnd, myWText );
	
	showSelected();
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ¥ 
// --- Update afetr a change in the prefs dialog
void UpdateFromPrefsChange(void)
{
	//short 		ok;,i;
	Rect		r;
	LongRect	wasteSizeRect, destRect;
	UInt32		weTextUsed; 

	if (modifyFlag) saveRobot();
	
	WEDispose( myWText );

	checkMemErr("Main:resetView");
	
	r.top = 1; r.bottom = 298;
	r.left = 1; r.right = 282;
	TextFont (kFontIDMonaco);
	TextSize (9);
	
	//---r myText = TENew(&r,&r);
	WERectToLongRect ( &r, &wasteSizeRect) ;
	//r.top += 1;
	//r.bottom += 1;
	WERectToLongRect ( &r, &destRect) ;
	weTextUsed = (gPrefs.syntaxColoringQ)? 0 : weDoMonoStyled;
	weTextUsed += weDoAutoScroll +
				weDoOutlineHilite +
				weDoUndo +
				weDoIntCutAndPaste +
				weDoDragAndDrop +
				weDoUseTempMem +
				weDoDrawOffscreen;
	if( WENew(  &destRect,
				&wasteSizeRect,
				weTextUsed,
				&myWText) != noErr)
	{
		reportMessage("Couldn't make new WEText area", "main:changeMode:1");
		ExitToShell();	//---x
	}
	if( WESetInfo ( weRefCon, &myWindow, myWText ) != noErr )
	{
		reportMessage("Problem with seting WATSTE info", "main:initProgram:2");
		ExitToShell();	//---x
	}
	
	readRobotText();

	SyntaxColorRange( 0, WEGetTextLength( myWText ), myWText ); //---n 15/4/98
}







// --- End Code ---