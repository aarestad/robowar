/* Tournament.c */

/* Written 1/26/91 by David Harris.

	This file contains the code to run tournaments given a list of 
	battles.
	
	Comments on the Survival Scoring System
	Individual Scores = 1 for survive, 0 for die
	Team Score = 3 for survive, 2 for die last, 1 for die next to last
	n = number of bots in arena
	p = prob of robot winning battle
	
	Individual Score = (n-1) * p * numDuels
	Group Score = rounds participating * 6 * p
		
	Scale factor to make group total = individual total:
		numDuels*(n-1)/ (6*rounds participating)
		
	Individual Final = 40/3 * p * numDuels
	Group Final = rounds participating * 6 * p
	
	Scale factor to make individual final = 1/2 individual score:
		(n-1)*3/80
	Scale factor to make group final = 1/2 individual score:
		numDuels*(n-1) / (12*rounds participating)
	
*/

/* #includes */

#include <Carbon/Carbon.h>
#include "robotypes.h"

/* Constants */

#define maxEntries 	100
#define groupBouts	6

/* Globals */

short					battleCount,numEntries;
short					numDuels,numGroups;
Str255 					desc[4];
ControlHandle 			tournButtons[4];
long    				totalChronons;
unsigned long			startTime;
individualRoster 		*roster;
short					circle[6];
short					changedSaveName;
FILE					*tlog;



/* External Variables */

extern MenuHandle 		myMenus[5];
extern WindowPtr		myWindow;
extern ControlHandle 	battleButton;
extern robot			rob[maxBots];
extern short			numBots;
extern short			botSelected;
extern short			isTournament;
extern short			isBattle;
extern long				chronons;
extern Str255			noName;
extern short			useDebugger;
extern short			mode;
extern short			aggressiveFlag;
extern short			officialFlag;
extern short			rosterChanged;
extern unsigned short lastRandSeed;		/* Retain random seed to repeat battles */
extern char				registered[80];

extern prefStruct		gPrefs; // prefs
//- from arena.c
extern short 			gBattleType;



/* Prototypes */

void setupTournament(void);
void addTournament(char*,short,DialogPtr);
void setTournamentSelection(DialogPtr,short);
void clearCamp(void);
void runBattle(char *title);
short selectRobotDirectory(short*);
short initTournament(unsigned char* name);
void runDuel(short,short,short,short);
void runGroup(short,short,short);
void printElapsedTime(FILE*);
void endTournament(void);
void individualTournament(char*);
void teamTournament(char*);
void completeTournament(char*);
void testTournament(char*);
void initTournamentLog(void);
void closeTournamentLog(void);

/* in Util.c */
extern void reportMessage(char *message1,char *message2);
extern void installButtonOutline(DialogPtr theDialog,short itemNo);
extern void checkMemErr(char *proc);
extern OSErr checkFileErr(OSErr err,char *proc);
extern void setVolume(short vRefNum);
extern void restoreVolume(void);

/* in ArenaControl.c */
extern void prepareArena(void);
extern void prepareRobots(short repeatFlag);

/* in Arena.c */
extern void doCombat(void);

/* in File.c */
extern void readRobot(void);
extern void closeRobot(void);
extern OSErr NewMacFile( Str255 name, long type, long creator );

/* in Debugger.c */
extern void setDebuggerBot(short);


/* Functions */

void setupTournament(void)
{
	DialogPtr myDialog;
	short itemHit,itemType;
	Handle descItem;
	ControlHandle checkBox1, checkBox2;
	Rect box;
	short kind;
	Str255 save,val;
	
	myDialog = GetNewDialog(TournDlogID,NULL,(WindowPtr)-1);
	changedSaveName = 0;
	
	/* Outline OK button */
	installButtonOutline(myDialog,3);
	
	/* Create Radio Buttons */
	addTournament((char*)"\pComplete",0,myDialog);
	addTournament((char*)"\pTeam of 2",1,myDialog);
	addTournament((char*)"\pBasic",2,myDialog);
	addTournament((char*)"\pTesting",3,myDialog);
	kind = 0;
	
	/* Prepare Check Box */
	GetDialogItem(myDialog,11,&itemType,(Handle*)&checkBox1,&box);
	SetControlValue(checkBox1,aggressiveFlag); 
	
	/* Prepare Check Box */
	GetDialogItem(myDialog,19,&itemType,(Handle*)&checkBox2,&box);
	SetControlValue(checkBox2,officialFlag); 

	/* Set repetition options */
	setTournamentSelection(myDialog,kind);
	
	do {
		ModalDialog(NULL,&itemHit);
		if (itemHit > 6 && itemHit < 11) {
			SetControlValue(tournButtons[kind],0);
			kind = itemHit-7;
			setTournamentSelection(myDialog,kind);
		}
		else if (itemHit == 11) {
			SetControlValue(checkBox1,!GetControlValue(checkBox1));
		}
		else if (itemHit == 19) {
			SetControlValue(checkBox2,!GetControlValue(checkBox2));
		}
		else if (itemHit == 6 || itemHit == 14 || itemHit == 15) changedSaveName = 1;
	} while (itemHit != 1 && itemHit != 18);
	
	if (itemHit == 1) {
		/* Read Save File Name and repetitions */
		aggressiveFlag = GetControlValue(checkBox1);
		officialFlag = GetControlValue(checkBox2);
		GetDialogItem(myDialog,6,&itemType,&descItem,&box);
		GetDialogItemText(descItem,save);
		GetDialogItem(myDialog,14,&itemType,&descItem,&box);
		GetDialogItemText(descItem,val);
		val[val[0]+1] = 0;
		sscanf((char*)val+1,"%hd",&numDuels);
		GetDialogItem(myDialog,15,&itemType,&descItem,&box);
		GetDialogItemText(descItem,val);
		val[val[0]+1] = 0;
		sscanf((char*)val+1,"%hd",&numGroups);
	}
	DisposeDialog(myDialog);
	
	if (itemHit == 1) {
		/* Make sure debugger is off before running tournament */
		setDebuggerBot(maxBots);
		
		if( gPrefs.createTournyLogQ == true )
			initTournamentLog();
		switch(kind) {
			case 0:  completeTournament((char*)save); break;
			case 1:  teamTournament((char*)save); break;
			case 2:  individualTournament((char*)save); break;
			case 3:  testTournament((char*)save); break;
		}
		if( gPrefs.createTournyLogQ == true )
			closeTournamentLog();
	}
}

void addTournament(char *name,short id,DialogPtr myDialog)
{
	Rect r;
	
	GetIndString((unsigned char*)&desc[id],1000,id+1);
	
	r.top = 30+20*id; r.left = 15;
	r.bottom = r.top + 16; r.right = 100;
	tournButtons[id] = NewControl(myDialog,&r,(unsigned char*)name,1,0,0,1,radioButProc,0);
	SetDialogItem(myDialog,7+id,ctrlItem+radCtrl,(Handle)tournButtons[id],&r);
}

void setTournamentSelection(DialogPtr myDialog,short kind)
{
	short itemType;
	Handle item;
	Rect box;

	/* Mark radio button */
	SetControlValue(tournButtons[kind],1);

	/* Set description text */
	GetDialogItem(myDialog,4,&itemType,&item,&box);
	SetDialogItemText(item,desc[kind]);
	
	/* Set default save name */
	if (!changedSaveName) {
		GetDialogItem(myDialog,6,&itemType,&item,&box);
		switch (kind) {
			case 0:  SetDialogItemText(item,"\pTournament Results"); break; /* Complete */
			case 1:  SetDialogItemText(item,"\pTeam Results"); break; /* Team */
			case 2:  SetDialogItemText(item,"\pDuel & Group Results"); break; /* Individual */
			case 3:  SetDialogItemText(item,"\pTest Results"); break; /* Test */
		}
		SelectDialogItemText(myDialog,6,0,32767);
		
		/* Set repetition options */
		GetDialogItem(myDialog,14,&itemType,&item,&box);
		switch (kind) {
			case 0: SetDialogItemText(item,"\p10"); break; /* Complete */
			case 1: SetDialogItemText(item,"\p10"); break; /* Team */
			case 2: SetDialogItemText(item,"\p10"); break; /* Individual */
			case 3: SetDialogItemText(item,"\p10"); break; /* Test */
		}
		GetDialogItem(myDialog,15,&itemType,&item,&box);
		switch (kind) {
			case 0: SetDialogItemText(item,"\p6"); break; /* Complete */
			case 1: SetDialogItemText(item,"\p0"); break; /* Team */
			case 2: SetDialogItemText(item,"\p6"); break; /* Individual */
			case 3: SetDialogItemText(item,"\p20"); break; /* Test */
		}
	}
}

//--- 19 apr 97 - Updated for Graphic Worlds --- 7 may 97 - rewritten to use closeRobot
void clearCamp(void)
{	
	/* Clear list of old robots */
	
	while (numBots > 0)
	{
		botSelected = numBots - 1;
		closeRobot();
	}
	rosterChanged = 1;
	botSelected = maxBots;
}

void runBattle(char *title)
{
	Rect r;
	
	CtoPstr(title);
	SetWTitle(myWindow,(unsigned char*)title);
	prepareArena();
	prepareRobots(0);
	r.top = 0; r.bottom = 220;
	r.left = 302; r.right = 500;
	InvalRect(&r);
	doCombat();
	isBattle = 0;
}

short selectRobotDirectory(short *whichSelected)
{
	short i,len,count;
	Point where;
	SFTypeList myTypes;
	SFReply reply;
	HParmBlkPtr pb;
	char name[80];
	
	roster = (individualRoster*)NewPtr(sizeof(individualRoster)*maxEntries);
	numEntries = 0;
	where.h = 100; where.v = 100;
	myTypes[0] = 'RobW';
	SFGetFile(where,noName,NULL,1,myTypes,NULL,&reply);
	if (reply.good) {
		reply.fName[reply.fName[0]+1] = 0;
		pb = (HParmBlkPtr)NewPtr(80L); /* Allocate parameter block ptr */
		((HFileParam*)pb)->ioVRefNum = reply.vRefNum;
		((HFileParam*)pb)->ioFVersNum = (SignedByte)0;
		((HFileParam*)pb)->ioFDirIndex = (short)1;
		((HFileParam*)pb)->ioDirID = 0L;
		((HFileParam*)pb)->ioNamePtr = (StringPtr)name;
		count = 0;
		while (PBHGetFInfoSync(pb) == noErr && numEntries < maxEntries && count++ < 1500) {
			if (((HFileParam*)pb)->ioFlFndrInfo.fdType == 'RobW') { /* file is a robot */
				/* So extract name, vRefNum */
				len = ((HFileParam*)pb)->ioNamePtr[0];
				for (i=0; i<=len; i++)
					roster[numEntries].name[i] = ((HFileParam*)pb)->ioNamePtr[i];
				roster[numEntries].name[i] = 0;
				roster[numEntries].vRefNum = reply.vRefNum;
				roster[numEntries].soloScore = 0;
				roster[numEntries].groupScore=0;
				roster[numEntries].winnerCircle = 0;
				roster[numEntries].soloFinal = 0;
				roster[numEntries].groupFinal = 0;
				roster[numEntries].numGroupFights = 0;
				if (strcmp((char*)reply.fName,(char*)roster[numEntries].name) == 0) 
					*whichSelected = numEntries;
				numEntries++;
			}
			((HFileParam*)pb)->ioDirID = 0L;
			((HFileParam*)pb)->ioFDirIndex++;
		}
	}
	DisposePtr((Ptr)pb);
	HiliteMenu(0);
	if (numEntries == 0) return 1;
	if (count >= 1500) 
		reportMessage ("Looped 1500 times looking for robots","May be error in RoboWar");
	if (numEntries >= maxEntries) 
		reportMessage ("Maximum number of entries is 99","Some robots may be skipped");
	if (numEntries < 2) {
		reportMessage ("Tournament aborted","At least two robots needed");
		return 1;
	}
	else return 0;
}


// ----------------------------------------------------------------------------------------
//  initTournament takes as an argument the name of the tounament file to create.
//  initTournament returns 
//		-1 if it failed to create the tournament file
//		0 if everything is OK.
// ----------------------------------------------------------------------------------------
short initTournament(unsigned char* name)
{
	short i;
	
	CheckItem(myMenus[4],automate_,TRUE);
	isTournament = 1;
	GetDateTime(&startTime);
	totalChronons = 0; 
	if( gPrefs.createTournyLogQ == true )
	{
		fprintf(tlog,"Tournament Roster:\n");
		for (i=0; i<numEntries; i++) {
			fprintf(tlog,"%-3d: %-20s\n",i,roster[i].name+1);
		}
		fprintf(tlog,"\n");
	}
	
	if( NewMacFile( name, 'TEXT', gPrefs.tournyCreatorType ) != noErr )
	{
		reportMessage( "Unable to save tournament.", "Canceled Tournament" );
		return -1;
	}
	
	return 0;
}

// ----------------------------------------------------------------------------------------
void runDuel(short rob1,short rob2,short totalRounds,short finalsFlag)
{
	short loop,repeats;
	char title[80];
	short score[2], delta[2];
	short i,num;
	char killcode[80];
	
	if (numDuels > 0) {
		if( gPrefs.createTournyLogQ == true )
		{
			fprintf(tlog,"Duel %d of %d\n", battleCount, totalRounds);
			fprintf(tlog,"%-23s%-9s%-9s%-9s%-9s%-9s\n",
				"Robot","Score","Alive","Kills","Killer","Chronon");
		}
		clearCamp();
		strcpy((char*)rob[numBots].name,roster[rob1].name);
		rob[numBots].vRefNum = roster[rob1].vRefNum;
		readRobot();
		strcpy((char*)rob[numBots].name,roster[rob2].name);
		rob[numBots].vRefNum = roster[rob2].vRefNum;
		readRobot();
		repeats = finalsFlag ? 8*numDuels/3 : numDuels;
		if (numBots != 2) isTournament = 0;
		score[0] = 0; score[1] = 0;
		for (loop=0; loop<repeats && isTournament; loop++) {
			sprintf(title,"%sDuel %d of %d: Bout %d of %d  Total Chronons %ld",
				finalsFlag ? "Winner's Circle " : "",
				battleCount,totalRounds,loop+1,repeats,totalChronons);
			if( gPrefs.createTournyLogQ == true ) fprintf(tlog,"Bout %d of %d\n", loop+1, repeats);
			gBattleType = kDuelBattle;
			runBattle(title);
			delta[0] = rob[0].alive;
			delta[1] = rob[1].alive;
			if (aggressiveFlag) {
				delta[0] += rob[0].kills;
				delta[1] += rob[1].kills;
			}
			score[0] += delta[0];
			score[1] += delta[1];
			totalChronons += chronons-1;
			
			/* Write tournament log */
			for (i=0; i<2; i++) {
				if (i==0) num = rob1; 
				else num = rob2;
				if (rob[i].scan == 32000) sprintf(killcode, "Buggy");
				else if (rob[i].scan == 32001) sprintf(killcode, "Overload");
				else if (rob[i].alive || rob[i].killer == -1) sprintf(killcode, "n/a");
				else sprintf(killcode,"%d",rob[i].killer ? rob2 : rob1);
				if( gPrefs.createTournyLogQ == true )
					fprintf(tlog,"%-3d%-20s%-9d%-9d%-9d%-9s%-9d\n", num, rob[i].name + 1,
						delta[i], rob[i].alive, rob[i].kills, killcode, rob[i].deathTime);
			}
		}
		if (finalsFlag) {
			roster[rob1].soloFinal+= score[0];
			roster[rob2].soloFinal+= score[1];
		}
		else {
			roster[rob1].soloScore+= score[0];
			roster[rob2].soloScore+= score[1];
		}
		battleCount++;
		
		/* Write duel summary */
		if( gPrefs.createTournyLogQ == true )
		{
			fprintf(tlog,"Summary\n");
			for (i=0; i<2; i++) {
				if (i==0) num = rob1; 
				else num = rob2;
				fprintf(tlog,"%-3d%-20s%-9d\n", num, rob[i].name + 1, score[i]);
			}
			fprintf(tlog,"\n");
		}
	}
}


void runGroup(short testBot,short totalRounds,short finalsFlag)
{
	short j,k,valid,next,numAlive, num;
	long max;
	short group[6], delta[6], score[6];
	char title[80], killcode[80];
	
	if (!(finalsFlag && battleCount > 1)) {
		clearCamp();
		for (j=0; j<6 && j<numEntries; j++) {
			if (finalsFlag) group[j] = circle[j];
			else do {
				if (j==0 && testBot != -1) group[j] = testBot;
				else group[j] = rand()%numEntries;
				valid = 1;
				for (k=0; k<j; k++) 
					if (group[k] == group[j]) valid = 0;
			} while (!valid);
			strcpy((char*)rob[numBots].name,roster[group[j]].name);
			rob[numBots].vRefNum = roster[group[j]].vRefNum;
			readRobot();
		}
	}
	for (j=0; j<6 && j<numEntries; j++) {
		roster[group[j]].numGroupFights++;
		score[j] = 0;
	}
	
	if( gPrefs.createTournyLogQ == true )
	{
		fprintf(tlog,"Group %d of %d\n", battleCount, totalRounds);
		fprintf(tlog,"%-23s%-9s%-9s%-9s%-9s%-9s\n",
			"Robot","Score","Alive","Kills","Killer","Chronon");
	}
	
	if (numBots != 6 && numBots != numEntries) isTournament = 0;
	for (j=0; j<groupBouts && isTournament; j++) {
		sprintf (title,"%sGroup Round %d of %d: Bout %d of %d   Total Chronons %ld",
			finalsFlag ? "Winner's Circle " : "",
			battleCount,totalRounds,j+1,groupBouts,totalChronons);
		if( gPrefs.createTournyLogQ == true ) fprintf(tlog,"Bout %d of %d\n", j+1, groupBouts);
		gBattleType = kGroupBattle;
		runBattle(title);
		totalChronons += chronons-1;
		max = 0; numAlive = 0; next = 0;
		for (k=0; k<6 && k <numEntries; k++) {
			if (rob[k].deathTime > max) {
				max = rob[k].deathTime;
			}
			if (rob[k].alive) numAlive++;
		}
		for (k=0; k<6 && k <numEntries; k++) {
			if (rob[k].deathTime > next && rob[k].deathTime != max) {
				next = rob[k].deathTime;
			}
		}
		/* If this code is changed, also change history stuff */
		for (k=0; k<6 && k < numEntries; k++) {
			delta[k] = 0;
			if (rob[k].alive) delta[k]+=3;
			else if (rob[k].deathTime == max) delta[k]+=2;
			else if (rob[k].deathTime == next) delta[k]+=1;
			delta[k] += rob[k].kills;			
			if (finalsFlag) {
				roster[group[k]].groupFinal += delta[k];
			}
			else {
				roster[group[k]].groupScore += delta[k];
			}
			score[k] += delta[k];
		}
		/* Write tournament log */
		for (k=0; k<6 && k < numEntries; k++) {
			num = group[k];
			if (rob[k].scan == 32000) sprintf(killcode, "Buggy");
			else if (rob[k].scan == 32001) sprintf(killcode, "Overload");
			else if (rob[k].alive || rob[k].killer == -1) sprintf(killcode, "n/a");
			else sprintf(killcode,"%d",group[rob[k].killer]);
			
			if( gPrefs.createTournyLogQ == true )
				fprintf(tlog,"%-3d%-20s%-9d%-9d%-9d%-9s%-9d\n", num, rob[k].name + 1,
					delta[k], rob[k].alive, rob[k].kills, killcode, rob[k].deathTime);
		}
	}
	/* Write group summary */
	if( gPrefs.createTournyLogQ == true )
	{
		fprintf(tlog,"Summary\n");
		for (k=0; k<6 && k < numEntries; k++) {
			num = group[k];
			fprintf(tlog,"%-3d%-20s%-9d\n", num, rob[k].name + 1, score[k]);
		}
		fprintf(tlog,"\n");
	}
	battleCount++;
}

void printElapsedTime(FILE *fptr)
{
	unsigned long dateTime;
	Str255 date,time;
	char msg[80];
	
	GetDateTime(&dateTime);
	IUDateString(dateTime,0,date);
	IUTimeString(dateTime,FALSE,time);
	PtoCstr(date); PtoCstr(time);
	sprintf ((char*)msg,"%10s  %s",time,date);
	fprintf(fptr,"Tournament Completed %s\n",msg);
	
	dateTime -= startTime;
	if (dateTime <= 0) dateTime = 1;
	
	fprintf(fptr,"Elapsed Time: %.2ld:%.2ld:%.2ld\n",dateTime / 3600,
			(dateTime % 3600)/60,dateTime%60);
	
	fprintf(fptr,"Total Chronons Simulated: %ld\n",totalChronons);
	fprintf(fptr,"Average Chronons / Sec: %ld\n",totalChronons / dateTime);
	
	fprintf(fptr,"\n");
}

void endTournament(void)
{
	SetWTitle (myWindow,"\pRoboWar");
	SetControlTitle(battleButton,"\pBattle \021B");
	if (mode == arena) botSelected = maxBots; /* Deselect unless debugging error */
	CheckItem(myMenus[4],automate_,FALSE);
	isTournament = 0;
}

void individualTournament(char *name)
{
	short i,j;
	long which,total,max;
	FILE *fptr;
	
	if (selectRobotDirectory(&i) == 0) {
		/* Write tournament log */
		if( gPrefs.createTournyLogQ == true )
			fprintf(tlog,"Tournament Type: Individual\n\n");

		if( initTournament((unsigned char*)name) == -1 )
			return;
			
		/* Individual rounds */
		battleCount = 1;
		for (i=0; i<numEntries; i++) 
			for (j=i+1; j<numEntries && isTournament; j++) {
				runDuel(i,j,numEntries*(numEntries-1)/2,FALSE);
			}
			
		/* Group rounds */
		battleCount = 1;
		for (i=0; i<numEntries*numGroups && isTournament; i++) {
			runGroup(-1,numEntries*numGroups,FALSE);
		}
		
		/* Write scores */
		PtoCstr((unsigned char*)name);
		if ((fptr = fopen(name,"w")) == NULL) 
			reportMessage ("Can't save results","Tournament:individualTournament:0");
		else {
			printElapsedTime(fptr);
			fprintf (fptr,"%-20s%-12s%-12s%-12s\n","Robot Name","Solo Score",
				"Group Score","Total");
			
			for (i=0; i<numEntries; i++) { 
				/* scale group score to equal indivdual score on average*/
				if (!roster[i].numGroupFights) roster[i].numGroupFights = 1;
				if (numDuels > 0) roster[i].groupScore *= numDuels*(numEntries-1)/ 
								   	   					  (2.0*groupBouts*roster[i].numGroupFights);
			}				
			for (i=0; i<numEntries; i++) {
				max = -1; which = -1;
				/* Print in order of rank */
				for (j=0; j<numEntries; j++) {
					total = roster[j].soloScore+roster[j].groupScore;
					if (total > max) {
						max = total;
						which = j;
					}
				}	
				PtoCstr((unsigned char*)roster[which].name);
				roster[which].name[19] = 0;
				fprintf (fptr,"%-20s%-12ld%-12ld%-12ld\n",roster[which].name,
					roster[which].soloScore,
					roster[which].groupScore,
					roster[which].soloScore+roster[which].groupScore);
				roster[which].soloScore = -10;
				roster[which].groupScore = -1;
			}
			fclose(fptr);
		}
		endTournament();
	}		
	DisposePtr((Ptr)roster);
}

void teamTournament(char *name)
{
	short numEntries,i,j,k;
	long max,best;
	Point where;
	SFTypeList myTypes;
	SFReply reply;
	char title[80];
	FILE *fptr;
	teamRoster *roster;
	
	roster = (teamRoster*)NewPtr(sizeof(teamRoster)*maxEntries);
	numEntries = 0;
	where.h = 100; where.v = 100;
	myTypes[0] = 'RobW';
	do {
		SFGetFile(where,noName,NULL,1,myTypes,NULL,&reply);
		if (reply.good) {
			reply.fName[reply.fName[0]+1] = 0;
			strcpy(roster[numEntries].name1,(char*)reply.fName);
			roster[numEntries].vRefNum1 = reply.vRefNum;
			SFGetFile(where,noName,NULL,1,myTypes,NULL,&reply);
			if (reply.good) {
				reply.fName[reply.fName[0]+1] = 0;
				strcpy(roster[numEntries].name2,(char*)reply.fName);
				roster[numEntries].vRefNum2 = reply.vRefNum;
				roster[numEntries++].score = 0;
			}
			else numEntries = -1;
		}
	} while (reply.good && numEntries < maxEntries);
	HiliteMenu(0);
	if (numEntries < 2) reportMessage ("Tournament aborted","At least two teams needed");
	else {
		/* Write tournament log */
		if( gPrefs.createTournyLogQ == true )
		{
			fprintf(tlog,"Tournament Type: Team\n\n");
			fprintf(tlog,"Sorry, no data logging for team tournaments.\n");
		}
		
		if( initTournament((unsigned char*)name) == -1 )
			return;

		/* Team Rounds */
		battleCount = 1;
		for (i=0; i<numEntries; i++) 
			for (j=i+1; j<numEntries && isTournament; j++) {
				clearCamp();
				strcpy((char*)rob[0].name,roster[i].name1);
				rob[0].vRefNum = roster[i].vRefNum1;
				readRobot();
				rob[0].team = 1;
				strcpy((char*)rob[1].name,roster[i].name2);
				rob[1].vRefNum = roster[i].vRefNum2;
				readRobot();
				rob[1].team = 1;
				strcpy((char*)rob[2].name,roster[j].name1);
				rob[2].vRefNum = roster[j].vRefNum1;
				readRobot();
				rob[2].team = 2;
				strcpy((char*)rob[3].name,roster[j].name2);
				rob[3].vRefNum = roster[j].vRefNum2;
				readRobot();
				rob[3].team = 2;
				gBattleType = kTeamBattle;
				for (k=0; k<numDuels && isTournament; k++) {
					sprintf(title,"Team Duel %d of %d: Bout %d of %d   Total Chronons %ld",
						battleCount,numEntries*(numEntries-1)/2,k+1,numDuels,totalChronons);
					runBattle(title);
					if (aggressiveFlag) {
						roster[i].score += rob[0].alive+rob[0].kills+rob[1].alive+rob[1].kills;
						roster[j].score += rob[2].alive+rob[2].kills+rob[3].alive+rob[3].kills;
					}
					else {
						if (rob[0].alive || rob[1].alive) roster[i].score++;
						if (rob[2].alive || rob[3].alive) roster[j].score++;
					}
					totalChronons += chronons-1;
				}
				battleCount++;
			}
		
		/* Report scores */
		PtoCstr((unsigned char*)name);
		if ((fptr = fopen(name,"w")) == NULL) 
			reportMessage ("Can't save results","Tournament:teamTournament");
		else {
			printElapsedTime(fptr);
			fprintf (fptr,"%-20s%-20s%-12s\n","Robot 1","Robot 2","Score");
			/* Print scores */
			for (i=0; i<numEntries; i++) {
				/* Sort scores */
				max = -1;
				for (j=0; j<numEntries; j++) {
					if (roster[j].score > max) {
						max = roster[j].score;
						best = j;
					}
				}
				PtoCstr((unsigned char*)roster[best].name1);
				PtoCstr((unsigned char*)roster[best].name2);
				roster[best].name1[19] = 0;
				roster[best].name2[19] = 0;
				fprintf (fptr,"%-20s%-20s%-12ld\n",roster[best].name1,
					roster[best].name2,roster[best].score);
				roster[best].score = - 2;
			}
			if (numGroups > 0)
				fprintf (fptr,"\nTeam group battles not yet supported\n");
			fclose(fptr);
		}
		SetWTitle (myWindow,"\pRoboWar");
		SetControlTitle(battleButton,"\pBattle \021B");
		if (mode == arena) botSelected = maxBots; /* Deselect unless debugging error */
		CheckItem(myMenus[4],automate_,FALSE);
	}		
	DisposePtr((Ptr)roster);
	isTournament = 0;
}

void completeTournament(char *name)
{
	short i,j;
	long total,max,which;
	FILE *fptr;
	
	if (selectRobotDirectory(&i) == 0) {
		if (numEntries < 6) reportMessage ("Complete tournaments require","at least 6 robots");
		else {
			/* Write tournament log */
			if( gPrefs.createTournyLogQ == true )
				fprintf(tlog,"Tournament Type: Complete\n\n");
			
			if( initTournament((unsigned char*)name) == -1 )
				return;
	
			/* Individual rounds */
			battleCount = 1;
			for (i=0; i<numEntries; i++) 
				for (j=i+1; j<numEntries && isTournament; j++) {
					runDuel(i,j,numEntries*(numEntries-1)/2,FALSE);
				}
				
			/* Group rounds */
			battleCount = 1;
			for (i=0; i<numEntries*numGroups && isTournament; i++) {
				runGroup(-1,numEntries*numGroups,FALSE);
			}
			
			/* Mark top 6 in Winners' Circle */
			for (i=0; i<numEntries; i++) { 
				/* scale group score to equal indivdual score on average*/
				if (!roster[i].numGroupFights) roster[i].numGroupFights = 1;
				if (numDuels > 0) roster[i].groupScore *= numDuels*(numEntries-1)/ 
								   	   					  (2.0*groupBouts*roster[i].numGroupFights);
				roster[i].winnerCircle = roster[i].soloScore + roster[i].groupScore;
				roster[i].numGroupFights = 0;
			}
			for (i=0; i<6; i++) {
				max = -1; which = -1;
				for (j=0; j<numEntries; j++) {
					if (roster[j].winnerCircle > max) {
						max = roster[j].winnerCircle;
						which = j;
					}
				}
				circle[i] = which;
				roster[which].winnerCircle = -1;
			}
			
			/* Write tournament log */
			if( gPrefs.createTournyLogQ == true )
				fprintf(tlog,"Winners' Circle\n\n");

			/* Individual WC rounds */
			battleCount = 1;
			for (i=0; i<6; i++) 
				for (j=i+1; j<6 && isTournament; j++) {
					runDuel(circle[i],circle[j],15,TRUE);
				}
				
			/* Group WC rounds */
			battleCount = 1;
			for (i=0; i<numGroups*16 && isTournament; i++) {
				runGroup(-1,numGroups*16,TRUE);
			}
			
			
			
			/* Write scores */
			PtoCstr((unsigned char*)name);
			if ((fptr = fopen(name,"w")) == NULL) 
				reportMessage ("Can't save results","Tournament:completeTournament");
			else {
				/* Scale Final scores to weigh 50% as much as main scores */
				for (i=0; i<6; i++) {
					if (!roster[circle[i]].numGroupFights) roster[circle[i]].numGroupFights = 1;
					roster[circle[i]].soloFinal *= (numEntries -1) * 3 / 80.0;
					roster[circle[i]].groupFinal *= (numEntries -1)*numDuels / 
													(4.0*groupBouts*roster[circle[i]].numGroupFights);
				}
				
				printElapsedTime(fptr);
				fprintf (fptr,"%-20s%-12s%-12s%-9s%-9s%-9s%-9s\n","Robot Name","Solo Score",
					"Group Score","Total","WC Solo","WC Group","Final");
				for (i=0; i<numEntries; i++) {
					max = -1; which = -1;
					/* Print in order of rank */
					for (j=0; j<numEntries; j++) {
						total = roster[j].soloScore+roster[j].groupScore+
								roster[j].soloFinal+roster[j].groupFinal;
						if (total > max) {
							max = total;
							which = j;
						}
					}	
					PtoCstr((unsigned char*)roster[which].name);
					roster[which].name[19] = 0;
					if (i < 6) 
						fprintf (fptr,"%-20s%-12ld%-12ld%-9ld%-9ld%-9ld%-9ld\n",roster[which].name,
							roster[which].soloScore,
							roster[which].groupScore,
							roster[which].soloScore+roster[which].groupScore,
							roster[which].soloFinal,
							roster[which].groupFinal,
							max);
					else 
						fprintf (fptr,"%-20s%-12ld%-12ld%-9ld\n",roster[which].name,
							roster[which].soloScore,
							roster[which].groupScore,
							max);
					roster[which].soloScore = -1;
					roster[which].groupScore = -1;
					roster[which].soloFinal = -1;
					roster[which].groupFinal = -1;
				}
				fclose(fptr);
			}
		}
		endTournament();
	} 
	DisposePtr((Ptr)roster);
}

void testTournament(char *name)
{
	short i,j,testBot;
	long which,max;
	long total;
	FILE *fptr;
	
	if (selectRobotDirectory(&testBot) == 0) {
		/* Write tournament log */
		if( gPrefs.createTournyLogQ == true )
			fprintf(tlog,"Tournament Type: Test\n\n");

		if( initTournament((unsigned char*)name) == -1 )
			return;

		PtoCstr((unsigned char*)name);
		if ((fptr = fopen(name,"w")) == NULL) 
			reportMessage ("Can't save results","Tournament:testTournament");

		/* Individual rounds */
		battleCount = 1;
		total = 0;
		
		if (numDuels > 0) {
		fprintf (fptr,"%-20s%-20s%-20s\n","",roster[testBot].name+1,"Opponent");
			for (i=0; i<numEntries; i++) {
				if (i != testBot) {
					runDuel(testBot,i,numEntries-1,FALSE);
					fprintf (fptr,"%-20s%-20ld%-20ld\n",roster[i].name+1,roster[testBot].soloScore,
													roster[i].soloScore);
					total += roster[testBot].soloScore;
					roster[testBot].soloScore = 0;
				}
			}
			fprintf(fptr,"\nSolo Total = %ld = %ld%c win record\n",total,100*total/
					((1+aggressiveFlag)*numDuels*(numEntries-1)),'%');
		}
		
		/* Group rounds */
		battleCount = 1;
		if (numGroups > 0) {
			for (i=0; i<numGroups && isTournament; i++) {
				runGroup(testBot,numGroups,FALSE);
			}
			fprintf (fptr,"\n%-20s%-20s\n","Robot Name","Normalized Group Score");
			for (i=0; i<numEntries; i++) {
				if (!roster[i].numGroupFights) roster[i].numGroupFights = 1;
				roster[i].groupScore *= (double)numGroups/roster[i].numGroupFights;
			}
			for (i=0; i<numEntries; i++) {
				max = -1; which = -1;
				/* Print in order of rank */
				for (j=0; j<numEntries; j++) {
					if (roster[j].groupScore > max) {
						max = roster[j].groupScore;
						which = j;
					}
				}	
				PtoCstr((unsigned char*)roster[which].name);
				roster[which].name[19] = 0;
				fprintf (fptr,"%-20s%-20ld\n",roster[which].name,roster[which].groupScore);
				roster[which].groupScore = -1;
			}
		}
		fprintf (fptr,"\n");
		
		/* Wrap up */
		printElapsedTime(fptr);
		fclose(fptr);
		endTournament();
	}		
	DisposePtr((Ptr)roster);
}

void initTournamentLog(void)
{
	//if( gPrefs.createTournyLogQ == false )
	//	return;
	
	unsigned long dateTime;
	Str255 date,time;
	char msg[80];
	Str255	name;
	
	strncpy( (char*)name, (char*)("\pTournament Log"), 15 );
	
	if( NewMacFile( name, 'TEXT', gPrefs.tournyCreatorType ) != noErr )
	{
		reportMessage("Can't make MacFile, Tournament Log Disabled","");
		gPrefs.createTournyLogQ = false;
		return;
	}
	
	if ((tlog = fopen("Tournament Log", "w")) == NULL) {
		reportMessage("Unable to write","Tournament Log");
		restoreVolume();
		return;
	}
	
	restoreVolume();

	GetDateTime(&dateTime);
	IUDateString(dateTime,0,date);
	IUTimeString(dateTime,FALSE,time);
	PtoCstr(date); PtoCstr(time);
	sprintf ((char*)msg,"%10s  %s",time,date);
	fprintf(tlog,"####################################################\n");
	fprintf(tlog,"# RoboWar Tournament Log:  Starting %s\n",msg);
	fprintf(tlog,"####################################################\n\n");
	fprintf(tlog,"Tournament Duels: %d\n",numDuels);
	fprintf(tlog,"Tournament Groups: %d\n",numGroups);
}

void closeTournamentLog(void)
{
	//if( gPrefs.createTournyLogQ == false )
	//	return;
		
	fprintf(tlog,"####################################################\n");
	printElapsedTime(tlog);
	fclose(tlog);
}