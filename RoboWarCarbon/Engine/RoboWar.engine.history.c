/*
 *  RoboWar.engine.history.c
 *  RoboWar
 *
 *  Written 3/19/95 by David Harris
 *  Ported to Carbon by Sam Rushing on Sun Jun 27 2004.
 *  Copyright (c) 2004 __MyCompanyName__. All rights reserved.
 *
 * This file contains functions to support the history
 * registers introduced in RoboWar 4.1. 
 */

#include "CarbonWrapper.h"
#include "RoboTypes.h"

// ----- Constants -----

#define historyTop		70
#define historyLeft		105
#define historyRowSize	15

// ----- globals from main.c -----
extern	short			numBots;			
extern	robot			rob[maxBots];
extern	short			rosterChanged;

// ----- from RoboWar.engine.control.c -----
extern	long			chronon;

// ----- from RoboWar.engine.combat.c -----
extern short countTeammates(robot *who);


void clearHistory(void)
{
	// originally from ./Engine/History.c
	rosterChanged = 1;
}

void initHistory(void)
{
	// originally from ./Engine/History.c
	short i,j;
	
	if (rosterChanged) {
		rosterChanged = 0;
		for (i=0; i<numBots; i++) 
			for (j=0; j<historySize; j++)
				rob[i].history[j] = 0;
	}
}

void updateHistory(void)
{
	// originally from ./Engine/History.c
	short i;
	short countAlive = 0;
	short livingTeam = 0;
	
	// count the number of robots/teams that are alive at the end of combat.
	//    If there are more than 1 teams alive at the end of a battle, then a timeout occured.
	//    A 100% accurate count is not a requisite - only that the count be greater than 1 if
	//      more than one team or solo-bot survived.
	// updated 6-27-04 -- accurately reflect timouts when teams are involved.
	//    Also discarded unnecessary calculations to find max death times.
	for (i=0; i<numBots; i++) {
		if (rob[i].alive && (rob[i].team == 0 || livingTeam != rob[i].team)) {
			livingTeam = rob[i].team;
			countAlive++;
		}
	}
	
	// update the history registers accordingly.
	for (i=0; i<numBots; i++) {
		rob[i].history[kRoboWarHistoryBattleCount]++;
		rob[i].history[kRoboWarHistoryKillsLastBattle] = rob[i].kills;
		rob[i].history[kRoboWarHistoryKillsTotal] += rob[i].kills;
		rob[i].history[kRoboWarHistorySurvivalPointsLastBattle] = rob[i].svrl;
		rob[i].history[kRoboWarHistorySurvivalPointsTotal] += rob[i].svrl;
		rob[i].history[kRoboWarHistoryTimedOutLastBattle] = (countAlive > 1);
		rob[i].history[kRoboWarHistoryTeammatesAliveAtEndOfLastBattle] = countTeammates(rob+i);
		rob[i].history[kRoboWarHistoryTeammatesAliveAtEndOfAllBattles] += rob[i].history[6];
		rob[i].history[kRoboWarHistoryDamageRemainingAtEndOfLastBattle] =
			(rob[i].alive ? rob[i].damage : 0);
		rob[i].history[kRoboWarHistoryChrononsLastBattle] = (short)chronon;
		rob[i].history[kRoboWarHistoryChrononsTotal] += (short)chronon;
		// indecies 11-29 reserved for future versions.
		// indecies 30-49 are reserved for use by the user.
	}
}
