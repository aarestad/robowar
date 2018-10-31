/* IconFactory.c */

/* Written 11/25/90 by David Harris */

/* #includes */

#include <Carbon/Carbon.h>
#include "robotypes.h"


const cOptionKeyID = 61;
const cControlKeyID = 60;
const cCommandKeyID = 48;
const cShiftKeyID = 63;

/* Variables */



short		iconSelected;
//short		oldIconIsNull;	//not used (instead I have used the value of oldIcon directly)
short 		angle;
CGrafPtr	oldIcon;			//--- 19 apr 97 --- used in Undo
Handle		scrap;				//--- 19 apr 97 --- handle to scrap...
CGrafPtr	pixGrid;			//--- 19 apr 97 --- was bitmapGrid, the big grid for drawing on.
RgnHandle	tools[8];			//was 7  //--- 19 apr 97 --- Added the ColorSelecter Tool
RGBColor	selectedColor;		//--- 19 apr 97 --- current selected color
short		selectedTool;		//--- 19 apr 97 --- current selected tool
short		modifyIconFlag[10]; //--- 19 apr 97 --- which Icons in the robot have been modified
WindowPtr	colorsWindow;		//--- 19 apr 97 --- the window used by the color selector.
ControlHandle	iconCheckBoxes[kIconCheckBoxesQty];	/* Check buttons for icon choices */


/* External Variables */

extern	short			controlChange;
extern	WindowPtr		myWindow;
extern  robot			rob[maxBots];
extern	EventRecord		myEvent;
extern	MenuHandle		myMenus[5];
extern	CursHandle		crossCurs;
extern	short			numBots;
extern	short			botSelected;
extern	short			modifyFlag;
extern	Str255			noName;
extern	double			sine[360];
//extern	short			colorIconMode;	/* in Registration.c */ //--- 19 apr 97 --- not used
extern	ControlHandle 	toolsControlHdl;	/* Tools PopUpMenu in Main */ //--- 19 apr 97 ---
extern hardwareInfo	hardware;				/* The robot's hardware */



//extern	QDGlobals		qd;						/* To make PowerPC happy */


/* Prototypes */

void getOldIcon(void);
void hiliteMenus(void);
void dimMenus(void);
void invalIcon(void);
void updateIcon(void);
void clickInIcon(void);
void clickInTool(short which);
void clickIcon(void);
void makePixmap(void);	//--- 19 apr 97 --- Updated
void initIcons(void);
void closeIcons(void);
void saveIcons(void);
void copyIcon(void);
void pasteIcon(void);
void clearIcon(void);
void cutIcon(void);
void undoIcon(void);
void iconSpecial(void);
Handle cicnFromGW( CGrafPtr gw );	//--- 19 apr 97 ---  new
void makeColorSelector(void);		//--- 19 apr 97 --- new
extern void doToolSelect(Point where);	//--- 19 apr 97 --- new
void doFill(Point cur);				//--- 19 apr 97 --- new
void doSystemColorSelect(void);		// --- 19 dec 97

/* in Util.c */
extern void reportMessage(char*,char*);
extern Boolean sameBot(short);
extern void checkMemErr(char *proc);
extern void checkResErr(char *proc);
extern void setVolume(short vRefNum);
extern void restoreVolume(void);
extern void drawRobot(short,short,short,short,short,RgnHandle,short);
extern void SetUpColorIcon(GWorldPtr* gw, CIconHandle* cicn); //--- 19 apr 97 --- 
extern void SetUpBWIcon(GWorldPtr* gw, Handle* icon); //--- 19 apr 97 --- 

/* in HardwareStore.c */
extern hardwareInfo getHardware(void);

/* Functions */


//--- 19 apr 97 --- rewritten for Graphic Worlds
void getOldIcon(void)
{
	
	if(rob[botSelected].gw[iconSelected] == NULL) {
		//oldIconIsNull = 1;
		if( oldIcon != NULL )
			DisposeGWorld(oldIcon);
		oldIcon=NULL;
	}
	else { // make an icon if we have an icon selected
		if(oldIcon == NULL)
			SetUpColorIcon(&oldIcon, nil);
		// simply use copybits to draw the old icon to the new icon
		CopyBits(	&((GrafPtr)rob[botSelected].gw[iconSelected])->portBits,
					&((GrafPtr)oldIcon)->portBits,
				 	&((GrafPtr)rob[botSelected].gw[iconSelected])->portRect,
				 	&((GrafPtr)oldIcon)->portRect,
				 	srcCopy,NULL);
	}
}

void hiliteMenus(void)
{
	EnableItem(myMenus[2],cut_);
	EnableItem(myMenus[2],copy_);
	EnableItem(myMenus[2],clear_);
}

void dimMenus(void)
{
	DisableItem(myMenus[2],cut_);
	DisableItem(myMenus[2],copy_);
	DisableItem(myMenus[2],clear_);
}

//--- 19 apr 97 --- Updated for Graphic Worlds
void invalIcon(void)
{
	Rect r;
	
	if (!iconSelected) {
		r.top = 254; r.bottom = 286; r.left = 305; r.right = 337;
		EraseRect(&r);
		if (rob[botSelected].gw[0] != NULL)
			drawRobot(-2,321,270,90,0,NULL,rob[botSelected].turretType);
		else drawRobot(-1,321,270,90,0,NULL,rob[botSelected].turretType);
	}
	
	InvalRect(&pixGrid->portRect);
	r.top = ((short)(iconSelected/2))*iconRowHeight+19;
	r.bottom = r.top + 32;
	r.left = iconLeftEdge+(iconSelected%2)*100;
	r.right = r.left + 32;
	InvalRect(&r);
}

//--- 19 apr 97 --- rewritten for Graphic Worlds
void updateIcon(void)
{
	short i,j;
	Rect r;
	Str255 msg;
	RGBColor iconPixelColor;
	GDHandle	origDev;
	CGrafPtr	origPort;
	
	GetGWorld(&origPort, &origDev);
	
	EraseRect(&myWindow->portRect);
	
	TextFont(systemFont);
	TextSize(12);
	for (i=0; i<5; i++) {
		for (j=0; j<2; j++) {
			if (rob[botSelected].gw[i+i+j]) {
				r.top = i*iconRowHeight+19;
				r.bottom = i*iconRowHeight+51;
				r.left = iconLeftEdge+j*100;
				r.right = iconLeftEdge+32+j*100;
				if( (**rob[botSelected].gw[i+i+j]->portPixMap).pixelSize == 1 )
					ForeColor(cyanColor);
				else
					ForeColor(blackColor);
				CopyBits(&((GrafPtr)rob[botSelected].gw[i+i+j])->portBits,&myWindow->portBits,
						 &((GrafPtr)rob[botSelected].gw[i+i+j])->portRect,&r,srcCopy,NULL);
			}
			ForeColor(greenColor);
			if (i)
				sprintf((char*)msg,"Icon %d",i+i+j);
			else if (j) strcpy((char*)msg,"Icon 1");
			else strcpy((char*)msg,"Normal");
			CtoPstr((char*)msg);
			MoveTo (iconLeftEdge+j*100-StringWidth(msg)-6,i*iconRowHeight+35);
			DrawString (msg);
		}
	}
	
	//write 'tool'
	MoveTo ( iconLeftEdge+40,223 );//<--- Changed! //<--- Added! 
	DrawString ("\pTool:");
	
	//write 'color' and draw the colorselector box and set the color in it to the selkected color
	MoveTo ( iconLeftEdge-37,223 );//<--- Changed! //<--- Added! 
	DrawString ("\pColor");
	SetRect(&r, iconLeftEdge+1,210, iconLeftEdge+21, 230);
	RGBForeColor(&selectedColor);
	PenPat(&qd.black);
	PaintRect(&r);
	InsetRect(&r, -2, -2 );
	ForeColor(blackColor);
	FrameRect(&r);
	
	ForeColor(blueColor);
	
	//draw the pixel grid
	CopyBits(&((GrafPtr)pixGrid)->portBits, &myWindow->portBits,	//<--- Changed! 
		&pixGrid->portRect,&pixGrid->portRect,srcOr,NULL);
	
	ForeColor(redColor);
	for (i=0; i<7; i++)
		PaintRgn(tools[i]);
		
	PenPat(&qd.gray);
	for (i=0; i<10; i++) {
		r.top = ((short)(i/2))*iconRowHeight+18;
		r.bottom = r.top + 34;
		r.left = iconLeftEdge-1+(i%2)*100;
		r.right = r.left + 34;
		FrameRect(&r);
	}
	PenPat(&qd.black);
	ForeColor(blackColor);
	r.top = ((short)(iconSelected/2))*iconRowHeight+18;
	r.bottom = r.top + 34;
	r.left = iconLeftEdge-1+(iconSelected%2)*100;
	r.right = r.left + 34;
	FrameRect(&r);
	
	// draw the icon in the grid
	if (rob[botSelected].gw[iconSelected]) {
		if(LockPixels(rob[botSelected].gw[iconSelected]->portPixMap)) //--- System 7 needs locked pixels - 21/5/97
		{	
			r.top = 23; r.bottom = 30;
			for (i=0; i<32; i++) {
				for (j=0; j<32; j++) {
					SetGWorld(rob[botSelected].gw[iconSelected], nil);
					GetCPixel(j,i, &iconPixelColor);
					if ( iconPixelColor.red != 0xFFFF ||  iconPixelColor.green != 0xFFFF || iconPixelColor.blue != 0xFFFF) {
						SetGWorld(origPort, origDev);
						RGBForeColor(&iconPixelColor);
						r.left = 23+j*8; r.right = 30+8*j;
						PaintRect(&r);
					}
				}
				r.top += 8; r.bottom += 8;
			}
		}
		else
		{
			reportMessage("Graphics Problem - Can't lock Pixels", "IconFactory:updateIcon:1");
			ExitToShell();
		}
		UnlockPixels(rob[botSelected].gw[iconSelected]->portPixMap);
	}
	
	SetGWorld(origPort, origDev);
	
	// make sure we can see the tool selector
	ShowControl(toolsControlHdl);
	DrawControls(myWindow);

	/* Adjust Controls */
	if (controlChange) {
		controlChange = 0;
		for (i=0; i< kIconCheckBoxesQty; i++)
			ShowControl(iconCheckBoxes[i]);
	} 
}


//--- 19 apr 97 --- Updated for Graphic Worlds
void clickInIcon(void)
{
	Point cur,new;
	Rect r;
	short state = 0,i,j;
	RGBColor 	tempColor;
	CGrafPtr	origPort;
	GDHandle	origDev;
	
	KeyMap keys;
	short useTool;
	
	GetGWorld(&origPort, &origDev);
	
	GetMouse(&cur);
	cur.h = (cur.h-22)/8;
	cur.v = (cur.v-22)/8;

	if (cur.v >= 0 && cur.v <= 31 && cur.h >= 0 && cur.h <= 31) {
		getOldIcon();
		EnableItem(myMenus[2],undo_);
		
		//if we clicked in the icon then make a new icon
		if (rob[botSelected].gw[iconSelected]==NULL) {
			SetUpColorIcon( &rob[botSelected].gw[iconSelected], nil );
			checkMemErr("IconFactory:clickInIcon:1");
			hiliteMenus();
		}
		
		// if the old image was B&W, 
		// then update the GWorld so that the icon is now a color icon
		if ( (**rob[botSelected].gw[iconSelected]->portPixMap).pixelSize == 1 )
			UpdateGWorld(	&rob[botSelected].gw[iconSelected],
							0,
							&((GrafPtr)rob[botSelected].gw[iconSelected])->portRect,
							nil,
							nil,
							clipPix );
			
		// if the old color we clicked on is the same as the color we have selected use the erase color(white)
		SetGWorld(rob[botSelected].gw[iconSelected], nil);
		if(!LockPixels(GetGWorldPixMap(rob[botSelected].gw[iconSelected])) )// --- needed for system 7 -  24/5/97
		{	//we need to lock the pixels before reading from, or writing to them when using a GWorld in system 7
			reportMessage("Graphics Problem - Can't lock Pixels", "IconFactory:clickInIcon:1");
			ExitToShell();
		}
		GetCPixel(cur.h,cur.v,&tempColor);
		if (tempColor.red == selectedColor.red && tempColor.green == selectedColor.green && tempColor.blue == selectedColor.blue) {
			tempColor.red = 0xFFFF;
			tempColor.green = 0xFFFF;
			tempColor.blue = 0xFFFF;
		}
		else	//as we are going to use tempColor as the color to draw with, set it to the slected color
			tempColor = selectedColor;
		
		//Set things up for drawing
		SetGWorld(origPort, origDev);
		PenPat(&qd.black);
		RGBForeColor(&tempColor);
	}
		
	GetKeys( keys );
	useTool = ( BitTst( keys, cOptionKeyID ) )? 2 : ( BitTst( keys, cControlKeyID ) )? 3 : selectedTool;
	
	while (Button() && (cur.v >= 0 && cur.v <= 31 && cur.h >= 0 && cur.h <= 31)) {

		if(useTool==1 ){ // DrawTool
			r.top = cur.v*8+23;
			r.bottom = r.top+7;
			r.left = cur.h*8+23;
			r.right = r.left+7;
		
			PaintRect(&r);
			SetGWorld(rob[botSelected].gw[iconSelected], nil);
			SetCPixel( cur.h, cur.v, &tempColor);
			SetGWorld(origPort, origDev);
		}
		else if( useTool==2 ) {	// ColorGrab Tool
			SetGWorld(rob[botSelected].gw[iconSelected], nil);
			GetCPixel(cur.h,cur.v,&selectedColor);
			SetGWorld(origPort, origDev);
			
			SetRect(&r, iconLeftEdge+1,210, iconLeftEdge+21, 230);
			RGBForeColor(&selectedColor);
			PenPat(&qd.black);
			PaintRect(&r);
		}
		else if( useTool==3 ) {	// Fill Tool
			doFill(cur);
			r.top = cur.v*8+23;
			r.bottom = r.top+7;
			r.left = cur.h*8+23;
			r.right = r.left+7;
			RGBForeColor(&selectedColor);
			FrameRect(&r);
			invalIcon();
		}
		
		do {
			GetMouse(&new);
		} while (Button() && (new.h-22)/8 == cur.h && (new.v-22)/8 == cur.v);
		cur.h = (new.h-22)/8;
		cur.v = (new.v-22)/8;
	}
	
	ForeColor(blueColor);
	PenSize(2,2);
	PenMode(patOr);
	PenPat(&qd.gray);
	r.top = 70; r.bottom = 231; r.left = 70; r.right = 231;
	FrameOval(&r);
	PenPat(&qd.black);
	PenMode(patCopy);
	PenSize(1,1);
	ForeColor(blackColor);
	
	SetGWorld(rob[botSelected].gw[iconSelected], nil);
	for (i=0; i<32; i++) {
		for (j=0; j<32 && !state; j++) {
				GetCPixel(j,i, &tempColor);
				if ( tempColor.red != 0xFFFF ||  tempColor.green != 0xFFFF || tempColor.blue != 0xFFFF)
					state = true;
		}
	}
	
	UnlockPixels(GetGWorldPixMap(rob[botSelected].gw[iconSelected]));	// --- needed for system 7 -  24/5/97
	
	SetGWorld(origPort, origDev);
	
	if (!state) { /* Empty icon */
		DisposeGWorld(rob[botSelected].gw[iconSelected]);
		checkMemErr("IconFactory:clickInIcon:2");
		rob[botSelected].gw[iconSelected] = NULL;
		invalIcon();
		dimMenus();
		if (oldIcon==NULL) DisableItem(myMenus[2],undo_);
	}
	else if (!iconSelected) {
		r.top = 254; r.bottom = 286; r.left = 305; r.right = 337;
		EraseRect(&r);
		if (rob[botSelected].gw[0] != NULL) //<--- Changed!
			drawRobot(-2,321,270,90,0,NULL,rob[botSelected].turretType);
		else drawRobot(-1,321,270,90,0,NULL,rob[botSelected].turretType);
	}
	
	modifyIconFlag[iconSelected] = 1;
	modifyFlag = 1;
}

//--- 19 apr 97 --- Updated for Graphic Worlds
void clickInTool(short which)
{
	CGrafPtr	tempGW;
	short i,j;
	Rect sourceRect,destRect;
	
	//If we clicked on oe of the modying button (eg shift left)
	if(which < 7) {	
		//if no icon exists, return
		if( !rob[botSelected].gw[iconSelected] )
			return;
		
		//get the old icon for undo
		getOldIcon();
		
		//set modify flags
		modifyIconFlag[iconSelected] = 1;
		modifyFlag = 1;
		
		//make a new GWorld, which is  copy of our icon, this is used for the tools
		tempGW=nil;
		SetUpColorIcon( &tempGW, nil);
		
		sourceRect = tempGW->portRect;
		destRect = sourceRect;
		CopyBits(	&((GrafPtr)rob[botSelected].gw[iconSelected])->portBits,
					&((GrafPtr)tempGW)->portBits,
				 	&sourceRect,
				 	&destRect,
				 	srcCopy,NULL);

		switch(which) {
			/*  Shifting 
			The shifts work by copying the tempGW to a slightly different position:
			1 pixel shift in the direction. we then copy the remaining line which 
			went over the edge of the icon
			*/
			case 0: /* Shift Up */
			case 1:	/* Shift Down */
			case 2:	/* Shift Left */
			case 3:	/* Shift Right */ 
					// position main shift
					switch(which) {
						case 0:	SetRect(&sourceRect, 0,1,32,32);
								SetRect(&destRect, 0, 0, 32, 31);
								break;
						case 1:	SetRect(&sourceRect, 0,0,32,31);
								SetRect(&destRect, 0, 1, 32, 32);
								break;
						case 2:	SetRect(&sourceRect, 1,0,32,32);
								SetRect(&destRect, 0, 0, 31, 32);
								break;
						case 3:	SetRect(&sourceRect, 0,0,31,32);
								SetRect(&destRect, 1, 0, 32, 32);
								break;
					}
					// copy main shift
					CopyBits(	&((GrafPtr)tempGW)->portBits,
								&((GrafPtr)rob[botSelected].gw[iconSelected])->portBits,
							 	&sourceRect,
							 	&destRect,
							 	srcCopy,NULL);
					// postion extra line
					switch(which) {
						case 0:	SetRect(&sourceRect, 0,0,32,1);
								SetRect(&destRect, 0, 31, 32, 32);
								break;
						case 1:	SetRect(&sourceRect, 0,31,32,32);
								SetRect(&destRect, 0, 0, 32, 1);
								break;
						case 2:	SetRect(&sourceRect, 0,0,1,32);
								SetRect(&destRect, 31, 0, 32, 32);
								break;
						case 3:
								SetRect(&sourceRect, 31,0,32,32);
								SetRect(&destRect, 0, 0, 1, 32);
								break;
					}
					//copy line
					CopyBits(	&((GrafPtr)tempGW)->portBits,
								&((GrafPtr)rob[botSelected].gw[iconSelected])->portBits,
							 	&sourceRect,
							 	&destRect,
							 	srcCopy,NULL);
					break; /* Shifting */
			/* Rotate Counterclockwise
			I've used the basic 2d 90 degree rotational matrix
			We copy the image pixel by pixel, from the tempGW to the icon
			*/
			case 4: for(i=0;i<32;i++) {
							sourceRect.top=i;
							sourceRect.bottom = sourceRect.top+1;
							destRect.left = i;
							destRect.right = destRect.left+1;
						for(j=0;j<32;j++) {
							sourceRect.left = j;
							sourceRect.right = sourceRect.left+1;
							destRect.top = 31-j;
							destRect.bottom = destRect.top+1;
							
							CopyBits(	&((GrafPtr)tempGW)->portBits,
										&((GrafPtr)rob[botSelected].gw[iconSelected])->portBits,
								 		&sourceRect,
								 		&destRect,
								 		srcCopy,NULL);
						}

					}
					break; /* Rotate Counterclockwise */
			/* Flip Horizontal 
			We copy the image line by line, from the tempGW to the icon in reverse, 
			so flipping the image horizontaly
			*/
			case 5:	for(i=0;i<32;i++) {
						sourceRect.left = i;
						sourceRect.right = i+1;
						destRect.left = 31-i;
						destRect.right = 32 - i;
						
						CopyBits(	&((GrafPtr)tempGW)->portBits,
									&((GrafPtr)rob[botSelected].gw[iconSelected])->portBits,
								 	&sourceRect,
								 	&destRect,
								 	srcCopy,NULL);
					}
					break; /* Flip Horizontal */
			/* Flip Vertical 
			We copy the image line by line, from the tempGW to the icon in reverse, 
			so flipping the image verticaly
			*/
			case 6: for(i=0;i<32;i++) {
						sourceRect.top = i;
						sourceRect.bottom = i+1;
						destRect.top = 31-i;
						destRect.bottom = 32 -i;
						
						CopyBits(	&((GrafPtr)tempGW)->portBits,
									&((GrafPtr)rob[botSelected].gw[iconSelected])->portBits,
								 	&sourceRect,
								 	&destRect,
								 	srcCopy,NULL);
					}
					break; /* Flip Vertical */
		}
		//clean up
		DisposeGWorld(tempGW);
		checkMemErr("IconFactory:clickInTool");
		tempGW = NULL;
		invalIcon();
	}
	else {	//if the selected tool is not a modifying tool then it's another one (the color selector)
		//switch(which) {
		//	case 8:
				KeyMap keys;
				GetKeys( keys );
				if( BitTst( keys, cOptionKeyID ) )
					doSystemColorSelect();
				else
					makeColorSelector();
		//		break;
		//}
	}
}


//--- 19 apr 97 --- Updated for Graphic Worlds
void clickIcon(void)
{
	short hit,i;
	Rect r;
	
	hit = iconSelected;
	GlobalToLocal(&myEvent.where);
	if (myEvent.where.h > 22 && myEvent.where.h < 280 &&
		myEvent.where.v > 22 && myEvent.where.v < 280) clickInIcon();
	else
		for (i=0; i<8; i++) 	//<--- Changed! was 7
			if (PtInRgn(myEvent.where,tools[i])) clickInTool(i);
	for (i=0; i<5; i++) 
		if (myEvent.where.v >i*iconRowHeight+18 && myEvent.where.v < i*iconRowHeight+52) {
			if (myEvent.where.h >= iconLeftEdge && myEvent.where.h <= iconLeftEdge+32) 
				hit = i+i;
			else if (myEvent.where.h >= iconLeftEdge+100 && myEvent.where.h <= iconLeftEdge+132) 
				hit = i+i+1;
		}
	if (hit != iconSelected) {
		r.top = ((short)(iconSelected/2))*iconRowHeight+18;
		r.bottom = r.top + 34;
		r.left = iconLeftEdge-1+(iconSelected%2)*100;
		r.right = r.left + 34;
		InvalRect(&r);
		iconSelected = hit;
		r.top = ((short)(iconSelected/2))*iconRowHeight+18;
		r.bottom = r.top + 34;
		r.left = iconLeftEdge-1+(iconSelected%2)*100;
		r.right = r.left + 34;
		InvalRect(&r);
		r.left = 22; r.right = 280; r.top = 22; r.bottom = 280;
		InvalRect(&r);
		
		if (rob[botSelected].gw[iconSelected]) hiliteMenus();
		else dimMenus();
		DisableItem(myMenus[2],undo_);
	}		
}


//--- 19 apr 97 --- rewritten for Graphic Worlds
void makePixmap(void)
{
	CGrafPtr		origPort;
	GDHandle		origDev;
	QDErr			myErr;
	PixMapHandle	offPixMap;
	Boolean 		good;
	Rect			sourceRect;	//, destRect;
	long i;
	Rect r;
	
	GetGWorld( &origPort, &origDev );
	
	//make a new GWorld for the grid
	SetRect(&sourceRect,0,0,300,300);
	
	myErr = NewGWorld(&pixGrid, 1, &sourceRect, nil, nil, 0);
	if(pixGrid == nil || myErr != noErr )
	{
		reportMessage("Can't create NewGWorld - Out of memory?", "IconFactory:makePixmap:1");
		ExitToShell();
	}
	
	SetGWorld(pixGrid, nil);
	
	//becasue we are editing the grid we need to use LockPixels
	offPixMap = GetGWorldPixMap(pixGrid);
	good = LockPixels(offPixMap);
	if( ! good )
		return;
	
	//draw the grid
	EraseRect(&sourceRect);
	ForeColor(blackColor);
	PenPat(&qd.gray);
	for (i=22; i<=278; i+=8) {
		MoveTo (i,22); LineTo (i,278);
		MoveTo (22,i); LineTo (278,i);
	}
	PenSize(2,2);
	r.top = 70; r.bottom = 231; r.left = 70; r.right = 231;
	FrameOval(&r);
	PenPat(&qd.black);
	r.top = 21; r.bottom = 280; r.left = 21; r.right = 280; 
	FrameRect(&r);
	PenSize(1,1);
	MoveTo (150,22); LineTo (150,278); 
	MoveTo (22,150); LineTo (278,150);
	
	SetGWorld(origPort, origDev);
	
	//Create the regions
	for (i=0; i<8; i++)		//<--- Changed! was 7
		tools[i] = NewRgn();
		
	OpenRgn();	/* Up Arrow */
		MoveTo (140,16); LineTo (160,16); LineTo (160,18);
		LineTo (140,18); LineTo (140,16);
		MoveTo (140,14); LineTo (160,14); 
		LineTo (150,4); LineTo (140,14); 
	CloseRgn(tools[0]);
	OpenRgn();	/* Down Arrow */
		MoveTo (140,285); LineTo (160,285); LineTo (160,283);
		LineTo (140,283); LineTo (140,285);
		MoveTo (140,287); LineTo (160,287); 
		LineTo (150,297); LineTo (140,287); 
	CloseRgn(tools[1]);
	OpenRgn();	/* Left Arrow */
		MoveTo (16,140); LineTo (16,160); LineTo (18,160);
		LineTo (18,140); LineTo (16,140);
		MoveTo (14,140); LineTo (14,160); 
		LineTo (4,150); LineTo (14,140); 
	CloseRgn(tools[2]);
	OpenRgn();	/* Right Arrow */
		MoveTo (285,140); LineTo (285,160); LineTo (283,160);
		LineTo (283,140); LineTo (285,140);
		MoveTo (287,140); LineTo (287,160); 
		LineTo (297,150); LineTo (287,140); 
	CloseRgn(tools[3]);
	OpenRgn(); 	/* Rotate */
		MoveTo (281,293); LineTo (289,293); LineTo (289,289);
		LineTo (285,289); LineTo (291,281); LineTo (297,289);
		LineTo (293,289); LineTo (293,297); LineTo (281,297); LineTo (281,293);
	CloseRgn(tools[4]);
	OpenRgn(); 	/* Flip Horizontal */
		MoveTo (216,291); LineTo (216,287); LineTo (224,287);
		LineTo (224,285); LineTo (228,288); LineTo (224,291);
		LineTo (224,289); LineTo (218,289); LineTo (218,291); LineTo (216,291);
		MoveTo (220,291); LineTo (220,293); LineTo (214,293);
		LineTo (214,291); LineTo (210,294); LineTo (214,297);
		LineTo (214,295); LineTo (222,295); LineTo (222,291); LineTo (220,291);
	CloseRgn(tools[5]);
	OpenRgn();	/* Flip Vertical */
		MoveTo (291,216); LineTo (287,216); LineTo (287,224);
		LineTo (285,224); LineTo (288,228); LineTo (291,224);
		LineTo (289,224); LineTo (289,218); LineTo (291,218); LineTo (291,216);
		MoveTo (291,220); LineTo (293,220); LineTo (293,214);
		LineTo (291,214); LineTo (294,210); LineTo (297,214);
		LineTo (295,214); LineTo (295,222); LineTo (291,222); LineTo (291,220); 
	CloseRgn(tools[6]);
	OpenRgn();	/* Color Selector */
		MoveTo (361,210); LineTo (381,210); LineTo (381,230);
		LineTo (361,230); LineTo (361,210);
	CloseRgn(tools[7]);
}


//--- 19 apr 97 --- Updated for Graphic Worlds
void initIcons(void)
{
	short i;
	Rect r;
	short refNum;
	
	setVolume(rob[botSelected].vRefNum);
	refNum = OpenResFile(rob[botSelected].name);
	hardware = getHardware();
	CloseResFile(refNum);
	restoreVolume();
	
	controlChange = 1;
	InvalRect (&myWindow->portRect);
	iconSelected = 0;
	angle = 90;
	if (rob[botSelected].gw[iconSelected]) hiliteMenus();
	else dimMenus();
	makePixmap();
	DisableItem(myMenus[2],undo_);
	for(i=0; i < 10; i++)
		modifyIconFlag[i] = 0;
	modifyFlag = 0;
	oldIcon = NULL;
	// Set the selected tool to the value of the control
	selectedTool = GetControlValue(toolsControlHdl);
	
	/* Create check boxes */
	for (i=0; i< kIconCheckBoxesQty; i++) {
		r.top = (short)((i+1)/2 + 1)*iconRowHeight; 
		r.bottom = r.top+15;
		r.left = iconLeftEdge + ((i+1)%2)*93 - 58; 
		r.right = r.left+57 + ((i+1)%2)*3;
		iconCheckBoxes[i] = NewControl(myWindow,&r,noName,FALSE,0,0,1,checkBoxProc,checkRefCon);
		if (iconCheckBoxes[i] == NULL)
			reportMessage("Error allocating controls","");
	}
	SetControlTitle(iconCheckBoxes[0],"\pShield");
	SetControlTitle(iconCheckBoxes[1],"\pDeath");
	SetControlTitle(iconCheckBoxes[2],"\pCollide");
	SetControlTitle(iconCheckBoxes[3],"\pBlock");
	SetControlTitle(iconCheckBoxes[4],"\pHit");
	
	SetControlValue(iconCheckBoxes[0],hardware.shieldOnIconFlag);
	SetControlValue(iconCheckBoxes[1],hardware.deathIconFlag);
	SetControlValue(iconCheckBoxes[2],hardware.collisionIconFlag);
	SetControlValue(iconCheckBoxes[3],hardware.shieldHitIconFlag);
	SetControlValue(iconCheckBoxes[4],hardware.hitIconFlag);
}

void closeIcons(void)
{
	short i;
	
	saveIcons();
	
	for (i=0; i<kIconCheckBoxesQty; i++) 
		if (iconCheckBoxes[i] != NULL) {
			(*iconCheckBoxes[i])->contrlRect.bottom = (*iconCheckBoxes[i])->contrlRect.top;
			(*iconCheckBoxes[i])->contrlRect.right = (*iconCheckBoxes[i])->contrlRect.left;
			DisposeControl(iconCheckBoxes[i]); 
		}
}

//--- 19 apr 97 --- Updated for Graphic Worlds
void saveIcons(void)
{
	short refNum,i,loop;
	Handle res;
	unsigned long dateTime;
	long **res2;
	hardwareInfo **bRes;

	if (modifyFlag) {
		setVolume(rob[botSelected].vRefNum);
		
	   	GetDateTime(&dateTime);
		CreateResFile(rob[botSelected].name);
		if ((refNum = OpenResFile(rob[botSelected].name)) == -1)
			reportMessage ("Error writing robot resources","");
		else {
			//RotateCursor(TickCount());//--- Animate Cursor - 30/5/97
			
			if ((res = GetResource('DATE',iconDateID)) != NULL) {
				RemoveResource(res);
				checkResErr("IconFactory:saveIcons:1");
				DisposeHandle(res);
			}
			
			//RotateCursor(TickCount());//--- Animate Cursor - 30/5/97
			
			res2 = (long**)NewHandle(4L);
			(*res2)[0] = dateTime;
			AddResource((Handle)res2,'DATE',iconDateID,"\pIcons");
			checkResErr("IconFactory:saveIcons:2");
			
			if ((res = GetResource('HARD',hardwareInfoID)) != NULL) {
				RemoveResource(res);
				checkResErr("HardwareStore:saveHardwareInfo:2b");
				DisposeHandle(res);
			}
			bRes = (hardwareInfo**)NewHandle(sizeof(hardware));
			(*bRes)[0] = hardware;
			AddResource((Handle)bRes,'HARD',hardwareInfoID,"\pHardware Info");
			checkResErr("IconFactory:saveIcons:2c");
					
			for (loop=0; loop<10; loop++) {
				if (modifyIconFlag[loop]) {
				
					//RotateCursor(TickCount());//--- Animate Cursor - 30/5/97
					
					// if we save the icon, remove the old ICON resource
					if ((res = GetResource('ICON',shieldlessID+loop)) != NULL) {
						RemoveResource(res);
						checkResErr("IconFactory:saveIcons:3");
						DisposeHandle(res);
					}
					
					//RotateCursor(TickCount());//--- Animate Cursor - 30/5/97
					
					// delete the old cicn
					if ((res = GetResource('cicn',shieldlessID+loop)) != NULL) {
						RemoveResource(res);
						checkResErr("IconFactory:saveIcons:4");
						DisposeHandle(res);
					}
					
					//RotateCursor(TickCount());//--- Animate Cursor - 30/5/97
					
					// if a cicn exists, save it.
					if (rob[botSelected].gw[loop] != NULL) {
						res = cicnFromGW(rob[botSelected].gw[loop]);
						AddResource(res,'cicn',shieldlessID+loop,noName);
						checkResErr("IconFactory:saveIcons:5");
					}
				}
			}
			CloseResFile (refNum);
		}
		restoreVolume();
		
		/* Adjust robots in camp to show new icons */
		
		for (i=0; i < numBots; i++)
			//RotateCursor(TickCount());//--- Animate Cursor - 30/5/97
			if (sameBot(i)) {
				for (loop = 0; loop < 10; loop++) {
					if (rob[botSelected].gw[loop] != NULL) {
						if (rob[i].gw[loop] == NULL)
							SetUpColorIcon( &rob[i].gw[loop], nil ); //<--- Changed
						
						CopyBits(	&((GrafPtr)rob[botSelected].gw[loop])->portBits,
									&((GrafPtr)rob[i].gw[loop])->portBits,
							 		&((GrafPtr)rob[botSelected].gw[loop])->portRect,
							 		&((GrafPtr)rob[i].gw[loop])->portRect,
							 		srcCopy,NULL);
					}
					else if (rob[i].gw[loop] != NULL) {
							DisposeGWorld(rob[i].gw[loop]);//<--- Changed
							checkMemErr("IconFactory:saveIcons:6");
							rob[i].gw[loop] = NULL;
						}
				}
				rob[i].hardware = hardware;
			}
	}
	DisposeGWorld(pixGrid);
	checkMemErr("IconFactory:saveIcons:7");
	pixGrid = NULL;
	for (i=0; i<8; i++)
		DisposeRgn(tools[i]);
	
	HideControl(toolsControlHdl);
	
	InitCursor();//--- Animate Cursor off - 30/5/97
}

//--- 19 apr 97 --- Updated for Graphic Worlds
void copyIcon(void)
{
	PicHandle pict;
	
	if (ZeroScrap()) reportMessage ("Unable to Zero scrap","");
	
	pict = OpenPicture(&rob[botSelected].gw[iconSelected]->portRect);	//make and open a new PICT
	
	CopyBits(	&((GrafPtr)rob[botSelected].gw[iconSelected])->portBits,	//copy our icon to teh pict
				&qd.thePort->portBits,
				&rob[botSelected].gw[iconSelected]->portRect,
				&rob[botSelected].gw[iconSelected]->portRect,
				srcCopy,NULL);
				
	ClosePicture();	//close the pict

	// put the PICT in the scrap
	HLock((Handle)pict);
	if (PutScrap((*pict)->picSize+12,'PICT',(Ptr)*pict)) SysBeep(1);
	HUnlock((Handle)pict);
	KillPicture(pict);
}

//--- 19 apr 97 --- Updated for Graphic Worlds
void pasteIcon(void)
{
	short		emptyScrap;
	long 		offset;
	Handle 		tmp;
 	GDHandle	origDev;
 	CGrafPtr	origPort;
	
	getOldIcon();
	
	if (GetScrap(NULL,'ICON',&offset) >= 0)  {
		tmp = NewHandle(128L);
		checkMemErr("IconFactory:IconToScrap:2");
		if (GetScrap(tmp,'ICON',&offset) == 128) {
			SetUpBWIcon(&rob[botSelected].gw[iconSelected], &tmp);
			emptyScrap = 0;
		}
		else emptyScrap = 1;
		DisposeHandle(tmp);
	}
	else if (GetScrap(NULL,'PICT',&offset) >= 0) {
		tmp = NewHandle(1L);
		checkMemErr("IconFactory:IconFromScrap:1");
		if (GetScrap(tmp,'PICT',&offset) > 0) {
			
			SetUpColorIcon(&rob[botSelected].gw[iconSelected], nil);	//SetUp the a new icon, deleteing the old one
			GetGWorld(&origPort, &origDev);		// get orig port/device
			SetGWorld(rob[botSelected].gw[iconSelected], nil);	//set the GWorld to our new icon
			
			//draw the PICT over our new icon scaling the image to fit the icon
			DrawPicture((PicHandle)tmp,&rob[botSelected].gw[iconSelected]->portRect);
			
			//clean up
			SetGWorld(origPort, origDev);
			emptyScrap = 0;
		}
		else
			emptyScrap = 1;
		DisposeHandle(tmp);
	}
	else
		SysBeep(0);
	
	if(!emptyScrap) {
		modifyIconFlag[iconSelected] = 1;
		modifyFlag = 1;
		invalIcon();
		EnableItem(myMenus[2],undo_);
		hiliteMenus();
	}
}

//--- 19 apr 97 --- Updated for Graphic Worlds
void clearIcon(void)
{
	getOldIcon();
	DisposeGWorld(rob[botSelected].gw[iconSelected]);
	checkMemErr("IconFactory:clearIcon");
	rob[botSelected].gw[iconSelected] = NULL;
	invalIcon();
	dimMenus();
	modifyIconFlag[iconSelected] = 1;
	modifyFlag = 1;
	EnableItem(myMenus[2],undo_);
}

void cutIcon(void)
{
	getOldIcon();
	copyIcon();
	clearIcon();
}

//--- 19 apr 97 --- Updated for Graphic Worlds
void undoIcon(void)
{
	CGrafPtr swap;	// a spare GWorld used to swap around the GWorlds
	
	// if the old icon didn't exists, dim menus
	if( oldIcon == NULL )
		dimMenus();
	else // otherwise hilite the menus
		hiliteMenus();
	
	//All we do is swap the oldIcon and icon GWorlds
	swap =  oldIcon;
	oldIcon = rob[botSelected].gw[iconSelected];
	rob[botSelected].gw[iconSelected] = swap;
		
	invalIcon();
}

//--- 19 apr 97 --- Updated for Graphic Worlds
void iconSpecial(void)
{
	GrafPtr oldPort;
	Point where;
	short x,y;
	Rect r;
	
	GetMouse(&where);
	if (PtInRect(where,&pixGrid->portRect))
		SetCursor (*crossCurs);
	else SetCursor (&qd.arrow);

	if (rob[botSelected].gw[iconSelected]) {
		angle += 1;
		angle %= 360;
		
		if (!(angle%5)) {
			GetPort (&oldPort);
			SetPort (myWindow);
			y = ((short)(iconSelected/2))*iconRowHeight+35;
			x = (iconSelected%2)*100+iconLeftEdge+16;
			r.top = y-16;
			r.bottom = y+16;
			r.left = x-16;
			r.right = x+16;
			if( (**rob[botSelected].gw[iconSelected]->portPixMap).pixelSize == 1 )
					ForeColor(cyanColor);
				else
					ForeColor(blackColor);
			CopyBits(&((GrafPtr)rob[botSelected].gw[iconSelected])->portBits,&myWindow->portBits,
						 &((GrafPtr)rob[botSelected].gw[iconSelected])->portRect,&r,srcCopy,NULL);
			ForeColor(blackColor);
			if (rob[botSelected].turretType == lineTurret) {
				MoveTo (x,y);
				LineTo (x+(short)((radius-1)*sine[(angle+270)%360]),
						y-(short)((radius-1)*sine[angle]));
			}
			else if (rob[botSelected].turretType == dotTurret) {
				PenSize(2,2);
				MoveTo (x+(short)((radius+2)*sine[(angle+270)%360]),
						y-(short)((radius+2)*sine[angle]));
				LineTo (x+(short)((radius+2)*sine[(angle+270)%360]),
						y-(short)((radius+2)*sine[angle]));
				PenSize(1,1);
			}
			SetPort (oldPort);
		}
	}
}

//--- 19 apr 97 --- new for Graphic Worlds
// This changes a GW to a cicn, used for saving. 
Handle cicnFromGW( CGrafPtr gw )
{
	Handle cicn;
	Handle basicCicn;
	short i, j;
	CGrafPtr	origPort;
	GDHandle	origDev;
	CGrafPtr	tempGW;
	QDErr		myErr;
	RGBColor	iconPixelColor;
	
	basicCicn = GetResource( 'cicn', 700 );		// Get the cicn template (cicn mask and colortable.
	
	cicn = NewHandleClear( GetHandleSize(basicCicn) ); //duplicate the basic cicn.
	
	for(i=0; i < GetHandleSize(basicCicn); i++)
		(*cicn)[i] = (*basicCicn)[i];
	
	ReleaseResource(basicCicn);	//dispose of the origenal cicn. (we can only save a copy)
	
	//make a new gworld which has 256 colors so that color conversion can be done.
	myErr = NewGWorld(&tempGW, 8, &((GrafPtr)gw)->portRect, nil, nil, 0);
	checkMemErr("IconFactory:cicnFromGW:1");
	if(tempGW == nil || myErr !=noErr){
		reportMessage("Graphics Problem-out of memory?", "IconFactory:cicnFromGW:1");
		ExitToShell();
	}
	
	GetGWorld(&origPort, &origDev); //get old GWorld
	
	if(!LockPixels(gw->portPixMap))// --- needed for system 7 -  24/5/97 - I think only for use with GWorlds
	{
		reportMessage("Graphics Problem - Can't lock Pixels", "IconFactory:cicnFromGW:1");
		ExitToShell();
	}
	//copy the GWorld to the cicn PixMap (in 256 colors)
	for (i=0; i<32; i++) { 
		for (j=0; j<32; j++) {
			SetGWorld(gw, nil);			//Get gw pixel
			GetCPixel(j,i, &iconPixelColor);
			SetGWorld(tempGW, nil);		//find value in 256 color mode
			RGBForeColor(&iconPixelColor);
			(*cicn)[i*32 + j+2266] = tempGW->fgColor;	// copy pixel index to cicn pixel.
		}
	}
	UnlockPixels(gw->portPixMap);
	
	//clean up...
	SetGWorld(origPort, origDev);
	
	DisposeGWorld(tempGW);
	checkMemErr("IconFactory:cicnFromGW:2");
	tempGW = NULL;
	return cicn;
}


//--- 19 apr 97 --- new for Graphic Worlds
// this handles Selection of colors.
void makeColorSelector(void)
{
	//the size of the window is h=160,v=40;
	#define kSmallColourBoxSize 	8
	#define	kNumOfBoxsWide 			32
	#define kNumOfBoxsHigh			8
	#define kColourWindowWidth		((kSmallColourBoxSize * kNumOfBoxsWide) + 1)
	#define kColourWindowHeight		((kSmallColourBoxSize * kNumOfBoxsHigh) + 1)
	#define kColourBoxsWidth		(kSmallColourBoxSize * kNumOfBoxsWide)
	#define kColourBoxsHeight		(kSmallColourBoxSize * kNumOfBoxsHigh)

	CTabHandle			colorTableHdl;
	short				i,j,entries, indexColor=0, usedColorIndex;
	Rect				r, tempr, tempr2;
	RGBColor			theColor;
	Point				mousePos, cBoxSize;
	
	SetPort(myWindow);	// Set Port and pos on the main window for the new window to apear
	mousePos.h = 360;
	mousePos.v = 231;
	LocalToGlobal(&mousePos);	//make that position global 
	
		// --- if our colours window will fo off the edge of the screen
	// --- limmit it to the bottom right hand corner
	if( mousePos.h + kColourWindowWidth > qd.screenBits.bounds.right )
		 mousePos.h = qd.screenBits.bounds.right - kColourWindowWidth;
	if( mousePos.v + kColourWindowHeight > qd.screenBits.bounds.bottom )
		 mousePos.v = qd.screenBits.bounds.bottom - kColourWindowHeight;
	
	SetRect(&r, mousePos.h,		// Set a Rect to hold that position.
				mousePos.v,
				mousePos.h + kColourWindowWidth,
				mousePos.v + kColourWindowHeight );
	
	GetMouse(&mousePos);	//Get the mousePos.
	
	//make a new window for the colorSelector window
	colorsWindow = NewCWindow(	nil, 		&r, 			"\pColor Selection", 
								true, 		altDBoxProc, 	(WindowPtr)-1L, 
								false,		0L );
	
	// Get number of colors on screen
	colorTableHdl = (*( ((CGrafPtr)colorsWindow)->portPixMap ))->pmTable;
	entries = (*colorTableHdl)->ctSize;
	
	//if more than 16 colors ( ie 256 or greater ) then lets limmit ourselves to 256 colors.
	// Also if entries = 0, then we are using > 256 colors, just the way MacOS is...
	if( entries > 255 || entries == 0)
	{
		colorTableHdl = GetCTable(72);
		entries = (*colorTableHdl)->ctSize;
	}
	
	// Set the box size per color depending on the number of colors.
	// so with fewer colors we can use bigger box's to represent each color
	switch( entries )
	{
		case 1:	cBoxSize.h = (kSmallColourBoxSize * kNumOfBoxsWide) / 2; //80;
				cBoxSize.v = (kSmallColourBoxSize * kNumOfBoxsHigh) / 2; //40;
				break;
		case 3: cBoxSize.h = (kSmallColourBoxSize * kNumOfBoxsWide) / 4; //cBoxSize.h = 40;
				cBoxSize.v = (kSmallColourBoxSize * kNumOfBoxsHigh) / 2; //40;
				break;
		case 15:cBoxSize.h = (kSmallColourBoxSize * kNumOfBoxsWide) / 8; //20;
				cBoxSize.v = (kSmallColourBoxSize * kNumOfBoxsHigh) / 4; //20;
				break;
				
		default:cBoxSize.h = (kSmallColourBoxSize * kNumOfBoxsWide) / 32; //cBoxSize.h = 5;
				cBoxSize.v = (kSmallColourBoxSize * kNumOfBoxsHigh) / 8; //cBoxSize.v = 5;
				break;
	}
	
	//Draw the box's and colors to the colorSelect Window.
	SetPort(colorsWindow);
	PenPat(&qd.black);
	EraseRect(&colorsWindow->portRect);
	for(i=0; i < (kColourBoxsHeight/cBoxSize.v) && indexColor <= entries; i++) {	//i = vertical position
	
		r.top = i * cBoxSize.v + 1;		//Set vertical position
		r.bottom = r.top + cBoxSize.v - 1;
		
		for(j=0; j < (kColourBoxsWidth/cBoxSize.h) && indexColor <= entries; j++) { //j = horizontal position
			
			r.left = j * cBoxSize.h + 1;	//Set horiz positin
			r.right = r.left + cBoxSize.h - 1;
			
			theColor = (*colorTableHdl)->ctTable[indexColor++].rgb;	//Get the rgb color of the current index
			RGBForeColor(&theColor);
			PaintRect(&r);	// and draw a box to represent it.
			
			if(theColor.red == selectedColor.red &&				//if the current color is the same as 
					theColor.green == selectedColor.green && 	// the selected color then:
					theColor.blue == selectedColor.blue) {
				// setup data for clearing the ouline
				// note that tempr is the outline rect and is kept for later
				tempr = r;
				InsetRect( &tempr, -1, -1);// outline the selected color
				ForeColor(blackColor);
				FrameRect(&tempr);
				// make a note of the selected color ( that way we can see if it's changed
				usedColorIndex = indexColor-1; 
			}
		}
	}
	
	//SetRect(&r, colorsWindow->portRect.left,	// limmit the selection area (otherwise we can accidentally select 
	//				colorsWindow->portRect.top,		// a color bellow the table
	//				colorsWindow->portRect.right-1,
	//				colorsWindow->portRect.bottom-1);
	
	// Set r to be the rect for the color-selection-control box
	SetRect(&r, iconLeftEdge+1,210, iconLeftEdge+21, 230);
 	
 	// Limmit teh color selection area so that we can't select a color outside 
 	// the current color table (last, lowest pixel)
 	tempr2 = colorsWindow->portRect;
 	InsetRect(  &tempr2, 1, 1 );
 	
	while(Button()) {		//while the mousebutton is held down
		GetMouse(&mousePos);
		SystemTask();
		if(PtInRect(mousePos, &tempr2)) {	// if the mouse is in the colorSelection area
			
			i = (mousePos.v / cBoxSize.v);	// Get the vertical color
			j = (mousePos.h / cBoxSize.h);	// Get the horizontal color

			if ( usedColorIndex != (i * (kColourBoxsWidth / cBoxSize.h)) + j) {	// if the color selected is now different
				usedColorIndex = (i * (kColourBoxsWidth / cBoxSize.h)) + j;	//set the used color...
				
				ForeColor(whiteColor);		// clear the old outline
				FrameRect(&tempr);
				
				tempr.top = i * cBoxSize.v;	// draw a new outline
				tempr.bottom = tempr.top + cBoxSize.v+1;
				tempr.left = j * cBoxSize.h;
				tempr.right = tempr.left + cBoxSize.h+1;
			
				ForeColor(blackColor);
				FrameRect(&tempr);
	
				SetPort(myWindow);	// use the old window again.
				// Draw the newly seleted color in the color-selection-control box.
				RGBForeColor(&(*colorTableHdl)->ctTable[usedColorIndex].rgb);
				PaintRect(&r);
				SetPort(colorsWindow);
			}
		}
		else
		{
			SetPort(myWindow);	// use the old window again.
			// Draw the old seleted color in the color-selection-control box.
			usedColorIndex = -1;
			RGBForeColor(&selectedColor);
			PaintRect(&r);
			SetPort(colorsWindow);
		}
	}
	
	SetPort(myWindow);
	// Set the iconFactory's selectedColor to the newly selected color
	if(PtInRect(mousePos, &tempr2))
		selectedColor = (*colorTableHdl)->ctTable[usedColorIndex].rgb;
	
	if( entries > 255 )	// if we made a new cTable, trash it.
		DisposeCTable(colorTableHdl);
	
	// dispose of the colorSeltion window
	DisposeWindow(colorsWindow);
}


//--- 19 apr 97 --- new
// This handles selection of tools in the Tools Popup Menu.
void doToolSelect(Point where)
{
	ControlHandle		controlHdl;
	short				startControlValue, finishControlValue;
	
	if(FindControl(where,myWindow,&controlHdl))
	{
		startControlValue = GetControlValue(controlHdl);
		TrackControl(controlHdl,where,(ControlActionUPP) -1);
		finishControlValue = GetControlValue(controlHdl);
	}

	selectedTool = finishControlValue;	//control value is the menunumber, line=1, colorSelect=2,fill=3
}


//--- 19 apr 97 --- new
// This is the fill tool - and at last it works!
// This procedure fills the current icon, from a point that is local to the robot's gWorld, 
// with the current selected color. 
void doFill(Point cur)
{
	BitMap		fillMask, colorMask;	// fillMask = the area that fill be filled
										// colorMask = the area occupied by the color at 'Point cur'
	RgnHandle	region;					// A riegion made to do the actual filling with fillrgn
	OSErr		err;					// possible error with BitMapToRgn (in theory no error is possible here)
	CGrafPtr	origPort;				// orig port and device
	GDHandle	origDev;
	short		i,j;
	RGBColor	seedColor, tempColor;	//seedColor = the color at 'Point cur' 
										// tempColor = a color compared with seedColor to generate colorMask
	
	GetGWorld(&origPort, &origDev);
	
	SetRect(&fillMask.bounds, 0,0,32,32);	//initialise the bitMaps.
	fillMask.rowBytes = 4;
	fillMask.baseAddr = NewPtr(128L);
	
	SetRect(&colorMask.bounds, 0,0,32,32);
	colorMask.rowBytes = 4;
	colorMask.baseAddr = NewPtr(128L);

	SetGWorld(rob[botSelected].gw[iconSelected], nil);	//get seedColor
	GetCPixel(cur.h,cur.v,&seedColor);
	
	for(i=0;i<32;i++) {	// create colorMask
		for(j=0;j<32;j++) {
			GetCPixel(j,i,&tempColor);
			if(tempColor.red == seedColor.red && tempColor.green == seedColor.green && tempColor.blue == seedColor.blue)
				BitClr(colorMask.baseAddr, j+i*32);
			else
				BitSet(colorMask.baseAddr, j+i*32);
		}
	}
	
	// use Quickdraw's SeedFill to create the fillmask
	SeedFill( colorMask.baseAddr, fillMask.baseAddr, 4,4,32,2, cur.h, cur.v);

	// create the region to draw fillmask onto the robots Gworld
	region = NewRgn();
	err = BitMapToRegion(region, &fillMask);
	if(err != noErr) {
		reportMessage("BUG! - There was a problem with the fill tool.", "IconFactory:doFill");
		return;
	}
	
	// Paint the region representing the fillmask onto out robot's GWorld
	SetGWorld(rob[botSelected].gw[iconSelected], nil);
	ForeColor(blackColor);
	PenPat(&qd.black);
	RGBForeColor(&selectedColor);
	PaintRgn(region);
	SetGWorld(origPort, origDev);
	
	// clean up memory
	DisposePtr(fillMask.baseAddr);
	DisposePtr(colorMask.baseAddr);
	DisposeRgn(region);
}

// --- Uses the systems color selection method to select a color to use in robowar.
// - this is done when the option key is held down, and the user clicks on the 
// - color selection control
// - 19 dec 97
void doSystemColorSelect(void)
{
	RGBColor 	theNewColor;
	Point		windowPos = { 50,20 };
	
	if( GetColor( windowPos, "\pChoose a color:", &selectedColor, &theNewColor ) )
		selectedColor = theNewColor;
}


/*--- End ---*/