/* Debugger.c */

/* Written 1/6/92 by David Harris

	This file contains routines for the RoboTalk debugger.
*/

/* #includes */

#include <Carbon/Carbon.h>
#include "robotypes.h"
#include "tokens.h"


/* Externals */

extern	short			useDebugger;
extern	short			botSelected;
extern	robot			rob[maxBots];
extern 	MenuHandle		myMenus[5];	
extern	ControlHandle	goButton;	
extern	ControlHandle	pauseButton;
extern	ControlHandle	chrononButton;
extern	ControlHandle	stepButton;
extern  ControlHandle	chrononButton;
extern  short			controlChange;
extern	short			pausedFlag;
extern	robot 			*who;
extern	short			communications[3][10];	
extern	WindowPtr		myWindow;

/* Globals */

extern	short		(*invokeDistance)(robot*);
extern	short		(*invokeRadar)(robot*);

/* Prototypes */

void doDebugger(void);
void setDebuggerBot(short);
void setButtonsPaused(void);
void getVarName(short code,char *name);
void getOperatorName(short code,char *name);
void drawDebuggerInfo(void);
void drawDebuggerBackground(void);

/* in Util.c */
extern void drawRobot(short,short,short,short,short,RgnHandle,short);

/* Implementation */

void doDebugger(void)
{
	if (botSelected == useDebugger) {
		setDebuggerBot(maxBots);
	}
	else {
		setDebuggerBot(botSelected);
	}
}

void setDebuggerBot(short which)
{
	Rect r;
	
	useDebugger = which;
	if (which == maxBots) CheckItem(myMenus[4],debugger_,0);
	else CheckItem(myMenus[4],debugger_,1);
	r.top = 0; r.left = 302; r.bottom = 204; r.right = 500;
	InvalRect(&r);
}

void setButtonsPaused(void)
{
	HiliteControl (goButton,0);
	HiliteControl (pauseButton,255);
	HiliteControl (stepButton,0);
	HiliteControl (chrononButton,0);
}

void getVarName(short code,char *name)
{
	switch (code-20300) {
		case 26: strcpy(name,"FIRE"); break;
		case 27: strcpy(name,"ENERGY");break;
		case 28: strcpy(name,"SHIELD");break;
		case 29: strcpy(name,"RANGE");break;
		case 30: strcpy(name,"AIM");break;
		case 31: strcpy(name,"SPEEDX");break;
		case 32: strcpy(name,"SPEEDY");break;
		case 33: strcpy(name,"DAMAGE");break;
		case 34: strcpy(name,"RANDOM");break;
		case 35: strcpy(name,"MISSILE");break;
		case 36: strcpy(name,"NUKE");break;
		case 37: strcpy(name,"COLLIDE");break;
		case 38: strcpy(name,"CHANNEL");break;
		case 39: strcpy(name,"SIGNAL");break;
		case 40: strcpy(name,"MOVEX");break;
		case 41: strcpy(name,"MOVEY");break;
		case 42: strcpy(name,"?????");break;
		case 43: strcpy(name,"RADAR");break;
		case 44: strcpy(name,"LOOK");break;
		case 45: strcpy(name,"SCAN");break;
		case 46: strcpy(name,"CHRONON");break;
		case 47: strcpy(name,"HELL");break;
		case 48: strcpy(name,"DRONE");break;
		case 49: strcpy(name,"MINE");break;
		case 50: strcpy(name,"LASER");break;
		case 51: strcpy(name,"?????");break;
		case 52: strcpy(name,"ROBOT");break;
		case 53: strcpy(name,"FRIEND");break;
		case 54: strcpy(name,"BULLET");break;
		case 55: strcpy(name,"DOPPLER");break;
		case 56: strcpy(name,"STUNNER"); break;
		case 57: strcpy(name,"TOP"); break;
		case 58: strcpy(name,"BOTTOM"); break;
		case 59: strcpy(name,"LEFT"); break;
		case 60: strcpy(name,"RIGHT"); break;
		case 61: strcpy(name,"WALL"); break;
		case 62: strcpy(name,"TEAMMAT"); break;
		case 63: strcpy(name,"PROBE"); break;
		case 64: strcpy(name,"HISTORY"); break;
		case 65: strcpy(name,"ID"); break;
		case 66: strcpy(name,"KILLS"); break;
		default:  if (code-20300 < 26)
					//-name[0] = code-20300+'A';
					sprintf(name,"%c",code-20300+'A');
				  else
				  {
				  	//-NumToString( code, (unsigned char*)name );
				  	//-PToCStr( code );
				    sprintf(name,"%d",code);
				  }
	}
} 

void getOperatorName(short code,char *name)
{
	switch (code) {
		case 20000: strcpy(name,"+"); break;
		case 20001: strcpy(name,"-"); break;
		case 20002: strcpy(name,"*"); break;
		case 20003: strcpy(name,"/"); break;
		case 20004: strcpy(name,">"); break;
		case 20005: strcpy(name,"<"); break;
		case 20006: strcpy(name,"="); break;
		case 20007: strcpy(name,"!="); break;
		case 20100: strcpy(name,"STORE"); break;
		case 20101: strcpy(name,"DROP"); break;
		case 20102: strcpy(name,"SWAP"); break;
		case 20103: strcpy(name,"ROLL"); break;
		case 20104: strcpy(name,"JUMP"); break;
		case 20105: strcpy(name,"CALL"); break;
		case 20106: strcpy(name,"DUP"); break;
		case 20107: strcpy(name,"IF"); break;
		case 20108: strcpy(name,"IFE"); break;
		case 20109: strcpy(name,"RECALL"); break;
		case 20110: strcpy(name,"END"); break;
		case 20111: strcpy(name,"NOP"); break;
		case 20112: strcpy(name,"AND"); break;
		case 20113: strcpy(name,"OR"); break;
		case 20114: strcpy(name,"XOR"); break;
		case 20115: strcpy(name,"MOD"); break;
		case 20116: strcpy(name,"BEEP"); break;
		case 20117: strcpy(name,"CHS"); break;
		case 20118: strcpy(name,"NOT"); break;
		case 20119: strcpy(name,"ARCTAN"); break;
		case 20120: strcpy(name,"ABS"); break;
		case 20121: strcpy(name,"SIN"); break;
		case 20122: strcpy(name,"COS"); break;
		case 20123: strcpy(name,"TAN"); break;
		case 20124: strcpy(name,"SQRT"); break;
		case 20125: strcpy(name,"ICON0"); break;
		case 20126: strcpy(name,"ICON1"); break;
		case 20127: strcpy(name,"ICON2"); break;
		case 20128: strcpy(name,"ICON3"); break;
		case 20129: strcpy(name,"ICON4"); break;
		case 20130: strcpy(name,"ICON5"); break;
		case 20131: strcpy(name,"ICON6"); break;
		case 20132: strcpy(name,"ICON7"); break;
		case 20133: strcpy(name,"ICON8"); break;
		case 20134: strcpy(name,"ICON9"); break;
		case 20135: strcpy(name,"PRINT"); break;
		case 20136: strcpy(name,"SYNC"); break;
		case 20137: strcpy(name,"VSTORE"); break;
		case 20138: strcpy(name,"VRECALL"); break;
		case 20139: strcpy(name,"DIST"); break;
		case 20140: strcpy(name,"IFG"); break;
		case 20141: strcpy(name,"IFEG"); break;
		case 20142: strcpy(name,"DEBUG"); break;
		case 20143: strcpy(name,"SND0"); break;
		case 20144: strcpy(name,"SND1"); break;
		case 20145: strcpy(name,"SND2"); break;
		case 20146: strcpy(name,"SND3"); break;
		case 20147: strcpy(name,"SND4"); break;
		case 20148: strcpy(name,"SND5"); break;
		case 20149: strcpy(name,"SND6"); break;
		case 20150: strcpy(name,"SND7"); break;
		case 20151: strcpy(name,"SND8"); break;
		case 20152: strcpy(name,"SND9"); break;
		case 20153: strcpy(name,"INTON"); break;
		case 20154: strcpy(name,"INTOFF"); break;
		case 20155: strcpy(name,"RTI"); break;
		case 20156: strcpy(name,"SETINT"); break;
		case 20157: strcpy(name,"SETPARAM"); break;
		case 20158: strcpy(name,"?????"); break;
		case dropall_: strcpy(name,"DROPALL"); break;
		case flushint_: strcpy(name,"FLUSHINT"); break;
		case max_: strcpy(name,"MAX"); break;
		case min_: strcpy(name,"MIN"); break;
		case arccos_: strcpy(name,"ARCCOS"); break;
		case arcsin_: strcpy(name,"ARCSIN"); break;
		default: {
				  	//NumToString( code, (unsigned char*)name );
				  	//PToCStr( code );
				  	sprintf (name,"%d",code);
				  }
	}
}

void drawDebuggerInfo(void)
{	
	Rect r;
	short i,signal,friend,sp,pp;
	char stats[16][20];
	Str255 msg1;
	
	who = rob+useDebugger;

	if (who->alive) {
		if (who->team) signal = communications[who->team-1][who->channel-1];
		else signal = 0;
		if (who->collision) friend = who->friend;
		else friend = 0;
		sprintf (stats[0],"%d",who->damage);
		sprintf (stats[1],"%d",who->energy);
		sprintf (stats[2],"%d",who->shield);
		sprintf (stats[3],"%d",who->aim);
		sprintf (stats[4],"%d",who->look);
		sprintf (stats[5],"%d",who->scan);
		sprintf (stats[6],"%d",invokeDistance(who));
		sprintf (stats[7],"%d",invokeRadar(who));
		sprintf (stats[8],"%d",who->letters[x_]);
		sprintf (stats[9],"%d",who->letters[y_]);
		sprintf (stats[10],"%d",who->speedX);
		sprintf (stats[11],"%d",who->speedY);
		sprintf (stats[12],"%d",who->collision);
		sprintf (stats[13],"%d",friend);
		sprintf (stats[14],"%d",who->channel);
		sprintf (stats[15],"%d",signal);
		
		for (i=0; i<16; i++) CtoPstr(stats[i]);
		
		r.top = 98; r.left = 370; r.bottom = 180; r.right = 399;
		EraseRect(&r);
		for (i=0; i<8; i++) {
			MoveTo(370,106+i*10);
			DrawString((unsigned char*)stats[i]);
		}
		r.left = 465; r.right = 499;
		EraseRect(&r);
		for (i=0; i<8; i++) {
			MoveTo(465,106+i*10);
			DrawString((unsigned char*)stats[i+8]);
		}
		
		//sprintf (stats[15],"%d",who->codepos);
		//MoveTo(465,106+i*10);
		//	DrawString((unsigned char*)stats[15]);
		
	}
	else {
		r.top = 98; r.left = 370; r.bottom = 180; r.right = 399;
		EraseRect(&r);
		MoveTo (370,106); DrawString ("\p0");
		r.left = 465; r.right = 499;
		EraseRect(&r);
		r.left = 430; r.right = 500;
		r.top = 0; r.bottom = 25;
		EraseRect(&r);
 		MoveTo(430,10); 
 		switch (who->scan) {
 			case 32000: DrawString ("\pBuggy"); break;
 			case 32001: DrawString ("\pOverloaded"); break;
 			default: DrawString ("\p¥¥¥Dead¥¥¥"); break;
 		}
		sprintf ((char*)msg1,"Time: %ld",who->deathTime);
		CtoPstr((char*)msg1);
 		MoveTo(430,19); DrawString(msg1); 
	}
	if (/*pausedFlag*/1) {
		/* Print Stack */
		for (i = 0; i<5 && i < who->stackPtr; i++) {
			sp=who->stackPtr-i-1;
			if (who->stack[sp] >=20300 && who->stack[sp] < 20400) 
				getVarName(who->stack[sp],(char*)msg1);
			else sprintf ((char*)msg1,"%d",who->stack[sp]);
			sprintf (stats[i],"%2d: %7s",sp,msg1);
			CtoPstr(stats[i]);
		}
	 	r.top = 38; r.bottom = 92; r.left = 406; r.right = 494;
	 	EraseRect (&r);
	 	for (i=0; i< 5 && i < who->stackPtr; i++) {
	 		MoveTo (408,48+i*10);
	 		DrawString((unsigned char*)stats[i]);
	 	}
		if (who->stackPtr == 0) {
			MoveTo (408,48);
			DrawString ("\p<Empty Stack>");
		}
			 	
	 	/* Print Program */
	 	for (i=0; i<5; i++) {
	 		pp = who->progPtr+i;
	 		if (pp >= who->progSize) strcpy (stats[i],"");
	 		else {
	 			if (who->prog[pp] >= 20300 && who->prog[pp] < 20400)
	 				getVarName(who->prog[pp],(char*)msg1);
	 			else if (who->prog[pp] >= 20000 && who->prog[pp] < 20200)
	 				getOperatorName(who->prog[pp],(char*)msg1);
	 			else sprintf ((char*)msg1,"%d",who->prog[pp]);
	 			sprintf (stats[i],"%4d: %7s",pp,msg1);
	 			CtoPstr(stats[i]);
	 		}
	 	}
	 	r.top = 38; r.bottom = 92; r.left = 306; r.right = 394;
		EraseRect(&r);
		for (i=0; i<5; i++) {
			MoveTo (308,48+i*10);
			DrawString((unsigned char*)stats[i]);
		}
	 }
	 else {
	 	r.top = 38; r.bottom = 92; r.left = 406; r.right = 494;
	 	EraseRect (&r);
	 	r.left = 306; r.right = 394;
	 	EraseRect(&r);
	 }
}

void drawDebuggerBackground(void)
{
	Rect r;
	RgnHandle oldClip;
	
	r.top = 0; r.bottom = 179;
	if (controlChange) r.bottom = 205; 
	r.left = 300; r.right = 500;
	EraseRect(&r);
	
	MoveTo (300,205); LineTo (500,205);
	
	drawRobot(useDebugger,319,18,90,0,NULL,rob[useDebugger].turretType);
	
	oldClip = NewRgn();
	GetClip(oldClip);
	r.top = 0; r.bottom = 35;
	r.left = 336; r.right = 428;
	ClipRect(&r);
	TextFont (systemFont);
	TextSize (12);
	MoveTo(336,18);
	DrawString(rob[useDebugger].name);
	SetClip(oldClip);
	DisposeRgn(oldClip);
	
	MoveTo (306,93); LineTo (395,93); LineTo (395,38); 
	r.top = 37; r.left = 305; r.bottom = 93; r.right = 395;
	FrameRect(&r);
	r.left = 405; r.right = 495;
	FrameRect(&r);
	MoveTo(406,93); LineTo (495,93); LineTo(495,38);
	
	TextFont(kFontIDMonaco);
	TextSize(9);
	MoveTo (348,34); DrawString ("\pProgram");
	MoveTo (410,34); DrawString ("\pStack");
	
	MoveTo (320,106); DrawString ("\pDamage:");
	MoveTo (320,106+10); DrawString ("\pEnergy:");
	MoveTo (320,106+20); DrawString ("\pShield:");
	MoveTo (320,106+30); DrawString ("\pAim:");
	MoveTo (320,106+40); DrawString ("\pLook:");
	MoveTo (320,106+50); DrawString ("\pScan:");	
	MoveTo (320,106+60); DrawString ("\pRange:");
	MoveTo (320,106+70); DrawString ("\pRadar:");
	MoveTo (400,106); DrawString ("\pX:");
	MoveTo (400,106+10); DrawString ("\pY:");
	MoveTo (400,106+20); DrawString ("\pSpeedX:");
	MoveTo (400,106+30); DrawString ("\pSpeedY:");
	MoveTo (400,106+40); DrawString ("\pCollision:");
	MoveTo (400,106+50); DrawString ("\pFriend:");
	MoveTo (400,106+60); DrawString ("\pChannel:");
	MoveTo (400,106+70); DrawString ("\pSignal:");
	
	if (controlChange) {
		controlChange = 0;
		setButtonsPaused();
		ShowControl(goButton);
		ShowControl(pauseButton);
		ShowControl(stepButton);
		ShowControl(chrononButton);
	}
}